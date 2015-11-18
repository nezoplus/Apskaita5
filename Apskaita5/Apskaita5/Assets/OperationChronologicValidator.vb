Namespace Assets

    ''' <summary>
    ''' Represents an <see cref="IChronologicValidator">IChronologicValidator</see> instance 
    ''' that is used to validate long term asset operation chronologic restrains.
    ''' </summary>
    ''' <remarks>Should only be used as a child of a long term asset operation, 
    ''' e.g. <see cref="OperationAmortization">OperationAmortization</see>.</remarks>
    <Serializable()> _
    Public Class OperationChronologicValidator
        Inherits ReadOnlyListBase(Of OperationChronologicValidator, OperationChronologicValidatorItem)
        Implements IChronologicValidator

#Region " Business Methods "

        Private Const DatePlaceHolder As String = "<$Date>"

        Private Shared _syncRoot As New Object
        Private Shared _IsAffectedByDictionary As Dictionary(Of LtaOperationType, LtaOperationType())
        Private Shared _IsLockedByDictionary As Dictionary(Of LtaOperationType, LtaOperationType())

        Private _CurrentOperationID As Integer = 0
        Private _CurrentOperationDate As Date = Today
        Private _CurrentOperationName As String = ""
        Private _FinancialDataCanChange As Boolean = True
        Private _MinDateApplicable As Boolean = False
        Private _MaxDateApplicable As Boolean = False
        Private _MinDate As Date = Date.MinValue
        Private _MaxDate As Date = Date.MaxValue
        Private _FinancialDataCanChangeExplanation As String = ""
        Private _MinDateExplanation As String = ""
        Private _MaxDateExplanation As String = ""
        Private _LimitsExplanation As String = ""
        Private _BackgroundExplanation As String = ""
        Private _TypeOperation As LtaOperationType = LtaOperationType.Discard
        Private _TypeAccount As LtaAccountChangeType = LtaAccountChangeType.AcquisitionAccount
        Private _AssetAcquisitionDate As Date = Date.MinValue
        Private _ParentFinancialDataCanChange As Boolean = True
        Private _ParentFinancialDataCanChangeExplanation As String = ""
        Private _BaseValidator As IChronologicValidator


        ''' <summary>
        ''' Gets a dictionary of <see cref="LtaOperationType">long term asset operation types</see>
        ''' that affect the current operation type, i.e. the current operation type
        ''' date and financial data is limited.
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared ReadOnly Property IsAffectedByDictionary As Dictionary(Of LtaOperationType, LtaOperationType())
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitializeDescriptors()
                Return _IsAffectedByDictionary
            End Get
        End Property

        ''' <summary>
        ''' Gets a dictionary of <see cref="LtaOperationType">long term asset operation types</see>
        ''' that lock the current operation type, i.e. a subsequent operation
        ''' locks the current type operation's date and financial data.
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared ReadOnly Property IsLockedByDictionary() As Dictionary(Of LtaOperationType, LtaOperationType())
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitializeDescriptors()
                Return _IsLockedByDictionary
            End Get
        End Property


        ''' <summary>
        ''' Gets an ID of the validated (parent) long term asset operation object,
        ''' e.g. <see cref="OperationAmortization.ID">OperationAmortization.ID</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrentOperationID() As Integer _
            Implements IChronologicValidator.CurrentOperationID
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationID
            End Get
        End Property

        ''' <summary>
        ''' Gets the current date of the validated (parent) long term asset operation 
        ''' (<see cref="Today">Today</see> for a new object). 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrentOperationDate() As Date _
            Implements IChronologicValidator.CurrentOperationDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationDate
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable name of the validated (parent) long term asset operation. 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrentOperationName() As String _
            Implements IChronologicValidator.CurrentOperationName
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationName.Trim
            End Get
        End Property

        ''' <summary>
        ''' Wheather the financial data of the validated (parent) long term asset operation 
        ''' is allowed to be changed.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property FinancialDataCanChange() As Boolean _
            Implements IChronologicValidator.FinancialDataCanChange
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Wheather there is a minimum allowed date for the validated (parent) operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property MinDateApplicable() As Boolean _
            Implements IChronologicValidator.MinDateApplicable
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDateApplicable
            End Get
        End Property

        ''' <summary>
        ''' Wheather there is a maximum allowed date for the validated (parent) operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property MaxDateApplicable() As Boolean _
            Implements IChronologicValidator.MaxDateApplicable
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDateApplicable
            End Get
        End Property

        ''' <summary>
        ''' Gets a minimum allowed date for the validated (parent) operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property MinDate() As Date _
            Implements IChronologicValidator.MinDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDate
            End Get
        End Property

        ''' <summary>
        ''' Gets a maximum allowed date for the validated (parent) operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property MaxDate() As Date _
            Implements IChronologicValidator.MaxDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDate
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable explanation of why the financial data 
        ''' of the validated (parent) operation is NOT allowed to be changed.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property FinancialDataCanChangeExplanation() As String _
            Implements IChronologicValidator.FinancialDataCanChangeExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChangeExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable explanation of why there is a minimum allowed date 
        ''' for the validated (parent) operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property MinDateExplanation() As String _
            Implements IChronologicValidator.MinDateExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDateExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable explanation of why there is a maximum allowed date 
        ''' for the validated (parent) operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property MaxDateExplanation() As String _
            Implements IChronologicValidator.MaxDateExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDateExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable explanation of all the applicable business rules restrains.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property LimitsExplanation() As String _
            Implements IChronologicValidator.LimitsExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LimitsExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' A human readable explanation of the applicable business rules restrains.
        ''' </summary>
        ''' <remarks>More exhaustive than <see cref="LimitsExplanation">LimitsExplanation</see>.</remarks>
        Public ReadOnly Property BackgroundExplanation() As String _
            Implements IChronologicValidator.BackgroundExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BackgroundExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="LtaOperationType">type</see> of the validated (parent) 
        ''' long term asset operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property TypeOperation() As LtaOperationType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TypeOperation
            End Get
        End Property

        ''' <summary>
        ''' Gets the <see cref="LongTermAsset.AcquisitionDate">acquisition date
        ''' of the long term asset</see> that the validated (parent) operation operates on.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property AssetAcquisitionDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AssetAcquisitionDate
            End Get
        End Property

        ''' <summary>
        ''' Wheather the financial data of the validated (parent) long term asset operation 
        ''' is allowed to be changed by the operation's parent document.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ParentFinancialDataCanChange() As Boolean _
        Implements IChronologicValidator.ParentFinancialDataCanChange
            Get
                Return _ParentFinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable explanation of why the financial data 
        ''' of the validated (parent) operation is NOT allowed to be changed
        ''' by the operation's parent document.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ParentFinancialDataCanChangeExplanation() As String _
            Implements IChronologicValidator.ParentFinancialDataCanChangeExplanation
            Get
                Return _ParentFinancialDataCanChangeExplanation
            End Get
        End Property

        ''' <summary>
        ''' Gets the <see cref="IChronologicValidator">IChronologicValidator</see>
        ''' instance of the operation's parent document.
        ''' </summary>
        ''' <remarks>If the operation's parent document <see cref="IChronologicValidator">IChronologicValidator</see>
        ''' is a <see cref="ComplexChronologicValidator">ComplexChronologicValidator</see>
        ''' then <see cref="ComplexChronologicValidator.BaseValidator">ComplexChronologicValidator.BaseValidator</see>
        ''' is used as a base validator.
        ''' If the operation's parent document does not own an <see cref="IChronologicValidator">IChronologicValidator</see>
        ''' then a <see cref="SimpleChronologicValidator">SimpleChronologicValidator</see>
        ''' is instantiated and used as a base validator.</remarks>
        Public ReadOnly Property BaseValidator() As IChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BaseValidator
            End Get
        End Property


        ''' <summary>
        ''' Gets the maximum (latest) date of the provided <see cref="OperationChronologyType">OperationChronologyType</see>
        ''' for the provided <see cref="LtaOperationType">long term asset operation types</see>.
        ''' </summary>
        ''' <param name="chronologyType">A type of chronology rule to use.</param>
        ''' <param name="operationTypes"><see cref="LtaOperationType">Long term asset 
        ''' operation types</see> to evaluate. If null, all the operations are evaluated.</param>
        ''' <remarks>Returnes Date.MinValue if no operation match is found.</remarks>
        Public Function GetMaxDate(ByVal chronologyType As OperationChronologyType, _
            ByVal ParamArray operationTypes As LtaOperationType()) As Date

            Dim result As Date = Date.MinValue

            If OperationTypes Is Nothing Then

                For Each i As OperationChronologicValidatorItem In Me
                    If i.ChronologyType = chronologyType AndAlso _
                        i.MaxDate.Date > result.Date Then result = i.MaxDate
                Next

            Else

                For Each i As OperationChronologicValidatorItem In Me
                    If i.ChronologyType = chronologyType AndAlso Not Array.IndexOf( _
                        OperationTypes, i.OperationType) < 0 AndAlso i.MaxDate.Date > result.Date Then _
                        result = i.MaxDate
                Next

            End If

            Return result

        End Function

        ''' <summary>
        ''' Gets the minimum (most recent) date of the provided <see cref="OperationChronologyType">OperationChronologyType</see>
        ''' for the provided <see cref="LtaOperationType">long term asset operation types</see>.
        ''' </summary>
        ''' <param name="chronologyType">A type of chronology rule to use.</param>
        ''' <param name="operationTypes"><see cref="LtaOperationType">Long term asset 
        ''' operation types</see> to evaluate. If null, all the operations are evaluated.</param>
        ''' <remarks>Returnes Date.MaxValue if no operation match is found.</remarks>
        Public Function GetMinDate(ByVal chronologyType As OperationChronologyType, _
            ByVal ParamArray operationTypes As LtaOperationType()) As Date

            Dim result As Date = Date.MaxValue

            If operationTypes Is Nothing Then

                For Each i As OperationChronologicValidatorItem In Me
                    If i.ChronologyType = chronologyType AndAlso i.MaxDate.Date < result.Date Then _
                        result = i.MaxDate
                Next

            Else

                For Each i As OperationChronologicValidatorItem In Me
                    If i.ChronologyType = chronologyType AndAlso Not Array.IndexOf( _
                        operationTypes, i.OperationType) < 0 AndAlso _
                        i.MaxDate.Date < result.Date Then result = i.MaxDate
                Next

            End If

            Return result

        End Function

        <Obsolete()> _
        Public Sub ReconfigureForType(ByVal newType As LtaOperationType, ByVal newAccountType As LtaAccountChangeType)

            If newType = _TypeOperation Then
                If newType <> LtaOperationType.AccountChange OrElse newAccountType = _TypeAccount Then Exit Sub
            End If

            _TypeOperation = newType
            _TypeAccount = newAccountType
            _CurrentOperationName = GetOperationName(newType, newAccountType)

            FetchLimitations()

        End Sub


        Private Shared Sub InitializeDescriptors()

            If _IsAffectedByDictionary Is Nothing OrElse _IsLockedByDictionary Is Nothing Then

                SyncLock _syncRoot

                    If _IsAffectedByDictionary Is Nothing OrElse _IsLockedByDictionary Is Nothing Then

                        Dim list As List(Of OperationChronologicDescriptor) _
                            = GetOperationChronologicDescriptorList()

                        _IsAffectedByDictionary = GetIsAffectedByDictionary(list)
                        _IsLockedByDictionary = GetIsLockedByDictionary(list)

                    End If

                End SyncLock

            End If

        End Sub

        Private Shared Function GetOperationChronologicDescriptorList() As List(Of OperationChronologicDescriptor)

            Dim result As New List(Of OperationChronologicDescriptor)

            result.Add(OperationChronologicDescriptor.GetOperationChronologicDescriptor( _
                LtaOperationType.AccountChange, _
                New LtaOperationType() {LtaOperationType.AccountChange, _
                LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.Discard, _
                LtaOperationType.Transfer, LtaOperationType.ValueChange}, _
                Nothing, New LtaOperationType() {LtaOperationType.AccountChange, _
                LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.Discard, _
                LtaOperationType.Transfer, LtaOperationType.ValueChange}, Nothing))

            result.Add(OperationChronologicDescriptor.GetOperationChronologicDescriptor( _
                LtaOperationType.AcquisitionValueIncrease, _
                New LtaOperationType() {LtaOperationType.AccountChange, _
                LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, _
                LtaOperationType.Discard, LtaOperationType.Transfer}, Nothing, _
                New LtaOperationType() {LtaOperationType.AccountChange, _
                LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, _
                LtaOperationType.Discard, LtaOperationType.Transfer}, _
                New LtaOperationType() {LtaOperationType.Amortization}))

            result.Add(OperationChronologicDescriptor.GetOperationChronologicDescriptor( _
                LtaOperationType.Amortization, _
                New LtaOperationType() {LtaOperationType.AccountChange, _
                LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, _
                LtaOperationType.Discard, LtaOperationType.Transfer}, _
                New LtaOperationType() {LtaOperationType.AccountChange, _
                LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, _
                LtaOperationType.Discard, LtaOperationType.Transfer, _
                LtaOperationType.AmortizationPeriod, LtaOperationType.UsingEnd, _
                LtaOperationType.UsingStart}, _
                New LtaOperationType() {LtaOperationType.AccountChange, _
                LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, _
                LtaOperationType.Discard, LtaOperationType.Transfer, _
                LtaOperationType.AmortizationPeriod, LtaOperationType.UsingEnd, _
                LtaOperationType.UsingStart}, _
                New LtaOperationType() {LtaOperationType.Amortization}))

            result.Add(OperationChronologicDescriptor.GetOperationChronologicDescriptor( _
                LtaOperationType.AmortizationPeriod, _
                New LtaOperationType() {LtaOperationType.Amortization}, Nothing, _
                New LtaOperationType() {LtaOperationType.Amortization}, _
                New LtaOperationType() {LtaOperationType.Amortization}))

            result.Add(OperationChronologicDescriptor.GetOperationChronologicDescriptor( _
                LtaOperationType.Discard, _
                New LtaOperationType() {LtaOperationType.AccountChange, _
                LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, _
                LtaOperationType.Discard, LtaOperationType.Transfer}, Nothing, _
                New LtaOperationType() {LtaOperationType.AccountChange, _
                LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, _
                LtaOperationType.Discard, LtaOperationType.Transfer}, _
                New LtaOperationType() {LtaOperationType.Amortization}))

            result.Add(OperationChronologicDescriptor.GetOperationChronologicDescriptor( _
                LtaOperationType.Transfer, _
                New LtaOperationType() {LtaOperationType.AccountChange, _
                LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, _
                LtaOperationType.Discard, LtaOperationType.Transfer}, Nothing, _
                New LtaOperationType() {LtaOperationType.AccountChange, _
                LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, _
                LtaOperationType.Discard, LtaOperationType.Transfer}, _
                New LtaOperationType() {LtaOperationType.Amortization}))

            result.Add(OperationChronologicDescriptor.GetOperationChronologicDescriptor( _
                LtaOperationType.UsingEnd, _
                New LtaOperationType() {LtaOperationType.Amortization, _
                LtaOperationType.UsingEnd, LtaOperationType.UsingStart}, Nothing, _
                New LtaOperationType() {LtaOperationType.Amortization, _
                LtaOperationType.UsingEnd, LtaOperationType.UsingStart}, _
                New LtaOperationType() {LtaOperationType.Amortization}))

            result.Add(OperationChronologicDescriptor.GetOperationChronologicDescriptor( _
                LtaOperationType.UsingStart, _
                New LtaOperationType() {LtaOperationType.Amortization, _
                LtaOperationType.UsingEnd, LtaOperationType.UsingStart}, Nothing, _
                New LtaOperationType() {LtaOperationType.Amortization, _
                LtaOperationType.UsingEnd, LtaOperationType.UsingStart}, _
                New LtaOperationType() {LtaOperationType.Amortization}))

            result.Add(OperationChronologicDescriptor.GetOperationChronologicDescriptor( _
                LtaOperationType.ValueChange, _
                New LtaOperationType() {LtaOperationType.AccountChange, _
                LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, _
                LtaOperationType.Discard, LtaOperationType.Transfer}, Nothing, _
                New LtaOperationType() {LtaOperationType.AccountChange, _
                LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, _
                LtaOperationType.Discard, LtaOperationType.Transfer}, _
                New LtaOperationType() {LtaOperationType.Amortization}))

            Return result

        End Function

        Private Shared Function GetIsAffectedByDictionary( _
            ByVal list As List(Of OperationChronologicDescriptor)) _
            As Dictionary(Of LtaOperationType, LtaOperationType())

            Dim result As New Dictionary(Of LtaOperationType, LtaOperationType())

            For Each desc As OperationChronologicDescriptor In list
                result.Add(desc.OperationType, OperationChronologicDescriptor. _
                    GetAffectingTypes(list, desc.OperationType))
            Next

            Return result

        End Function

        Private Shared Function GetIsLockedByDictionary( _
            ByVal list As List(Of OperationChronologicDescriptor)) _
            As Dictionary(Of LtaOperationType, LtaOperationType())

            Dim result As New Dictionary(Of LtaOperationType, LtaOperationType())

            For Each desc As OperationChronologicDescriptor In list
                result.Add(desc.OperationType, OperationChronologicDescriptor. _
                    GetLockingTypes(list, desc.OperationType))
            Next

            Return result

        End Function


        ''' <summary>
        ''' Validates a long term asset operation date against chronological
        ''' rules contained within the object. Returns TRUE if the date is valid, 
        ''' otherwise returns FALSE.
        ''' </summary>
        ''' <param name="operationDate">A date of a long term asset operation to validate.</param>
        ''' <param name="errorMessage">Output parameter that is set to error message.</param>
        ''' <param name="errorSeverity">Output parameter that is set to error severity level.</param>
        ''' <returns>Returns TRUE if the operation date is valid, otherwise returns FALSE.</returns>
        ''' <remarks></remarks>
        Friend Function ValidateOperationDate(ByVal operationDate As Date, _
            ByRef errorMessage As String, ByRef errorSeverity As Validation.RuleSeverity) As Boolean _
            Implements IChronologicValidator.ValidateOperationDate

            If _MinDateApplicable AndAlso operationDate.Date < _MinDate.Date Then
                errorMessage = _MinDateExplanation
                ErrorSeverity = Validation.RuleSeverity.Error
                Return False
            ElseIf _MaxDateApplicable AndAlso operationDate.Date > _MaxDate.Date Then
                errorMessage = _MaxDateExplanation
                ErrorSeverity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function


        Private Shared Function GetOperationName(ByVal operationType As LtaOperationType, _
            ByVal accountType As LtaAccountChangeType) As String

            If operationType = LtaOperationType.AccountChange Then
                Return String.Format("{0} - {1}", ConvertEnumHumanReadable(operationType), _
                    ConvertEnumHumanReadable(accountType))
            Else
                Return ConvertEnumHumanReadable(operationType)
            End If

        End Function


        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Assets_OperationChronologicValidator_ToString, _
                _CurrentOperationName)
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets an OperationChronologicValidator instance for a new long term asset operation.
        ''' </summary>
        ''' <param name="assetID">An <see cref="LongTermAsset.ID"> ID of the long term asset</see>
        ''' that the operation operates on.</param>
        ''' <param name="operationType">A type of the operation.</param>
        ''' <param name="accountType">A type of the account change (only releveant
        ''' if the <paramref name="operationType">operationType</paramref>
        ''' is set to <see cref="LtaOperationType.AccountChange">LtaOperationType.AccountChange</see>, 
        ''' ignored otherwise)</param>
        ''' <param name="nAssetAcquisitionDate">An <see cref="LongTermAsset.AcquisitionDate">
        ''' acquisition date of the long term asset</see> that the operation operates on.</param>
        ''' <param name="parentValidator">The operation's parent document 
        ''' IChronologicValidator if any.</param>
        ''' <remarks></remarks>
        Friend Shared Function NewOperationChronologicValidator(ByVal assetID As Integer, _
            ByVal operationType As LtaOperationType, ByVal accountType As LtaAccountChangeType, _
            ByVal nAssetAcquisitionDate As Date, ByVal parentValidator As IChronologicValidator) _
            As OperationChronologicValidator
            Return New OperationChronologicValidator(assetID, operationType, _
                accountType, nAssetAcquisitionDate, parentValidator)
        End Function

        ''' <summary>
        ''' Gets an OperationChronologicValidator instance for a new long term asset operation.
        ''' </summary>
        ''' <param name="assetID">An <see cref="LongTermAsset.ID"> ID of the long term asset</see>
        ''' that the operation operates on.</param>
        ''' <param name="operationType">A type of the operation.</param>
        ''' <param name="accountType">A type of the account change (only releveant
        ''' if the <paramref name="operationType">operationType</paramref>
        ''' is set to <see cref="LtaOperationType.AccountChange">LtaOperationType.AccountChange</see>, 
        ''' ignored otherwise)</param>
        ''' <param name="nAssetAcquisitionDate">An <see cref="LongTermAsset.AcquisitionDate">
        ''' acquisition date of the long term asset</see> that the operation operates on.</param>
        ''' <param name="parentValidator">The operation's parent document 
        ''' IChronologicValidator if any.</param>
        ''' <param name="dataSource">A datasource, containing validation data for a complex 
        ''' document (invoke <see cref="GetDataSourceForNewComplexDocument">
        ''' GetDataSourceForNewComplexDocument</see> to fetch a datasource).</param>
        ''' <remarks></remarks>
        Friend Shared Function NewOperationChronologicValidator(ByVal assetID As Integer, _
            ByVal operationType As LtaOperationType, ByVal accountType As LtaAccountChangeType, _
            ByVal nAssetAcquisitionDate As Date, ByVal parentValidator As IChronologicValidator, _
            ByVal dataSource As DataTable) As OperationChronologicValidator
            Return New OperationChronologicValidator(assetID, operationType, _
                accountType, nAssetAcquisitionDate, parentValidator, dataSource)
        End Function


        ''' <summary>
        ''' Gets an OperationChronologicValidator instance for an existing 
        ''' long term asset operation.
        ''' </summary>
        ''' <param name="assetID">An <see cref="LongTermAsset.ID"> ID of the long term asset</see>
        ''' that the operation operates on.</param>
        ''' <param name="operationType">A type of the operation.</param>
        ''' <param name="accountType">A type of the account change (only releveant
        ''' if the <paramref name="operationType">operationType</paramref>
        ''' is set to <see cref="LtaOperationType.AccountChange">LtaOperationType.AccountChange</see>, 
        ''' ignored otherwise)</param>
        ''' <param name="nAssetAcquisitionDate">An <see cref="LongTermAsset.AcquisitionDate">
        ''' acquisition date of the long term asset</see> that the operation operates on.</param>
        ''' <param name="operationID">An ID of the long term asset operation.</param>
        ''' <param name="operationDate">A date of the long term asset operation.</param>
        ''' <param name="parentValidator">The operation's parent document 
        ''' IChronologicValidator if any.</param>
        ''' <remarks></remarks>
        Friend Shared Function GetOperationChronologicValidator(ByVal assetID As Integer, _
            ByVal operationType As LtaOperationType, ByVal accountType As LtaAccountChangeType, _
            ByVal nAssetAcquisitionDate As Date, ByVal operationID As Integer, _
            ByVal operationDate As Date, ByVal parentValidator As IChronologicValidator) As OperationChronologicValidator
            Return New OperationChronologicValidator(assetID, operationType, _
                accountType, nAssetAcquisitionDate, operationID, operationDate, parentValidator)
        End Function

        ''' <summary>
        ''' Gets an OperationChronologicValidator instance for an existing 
        ''' long term asset operation.
        ''' </summary>
        ''' <param name="assetID">An <see cref="LongTermAsset.ID"> ID of the long term asset</see>
        ''' that the operation operates on.</param>
        ''' <param name="operationType">A type of the operation.</param>
        ''' <param name="accountType">A type of the account change (only releveant
        ''' if the <paramref name="operationType">operationType</paramref>
        ''' is set to <see cref="LtaOperationType.AccountChange">LtaOperationType.AccountChange</see>, 
        ''' ignored otherwise)</param>
        ''' <param name="nAssetAcquisitionDate">An <see cref="LongTermAsset.AcquisitionDate">
        ''' acquisition date of the long term asset</see> that the operation operates on.</param>
        ''' <param name="operationID">An ID of the long term asset operation.</param>
        ''' <param name="operationDate">A date of the long term asset operation.</param>
        ''' <param name="parentValidator">The operation's parent document 
        ''' IChronologicValidator if any.</param>
        ''' <param name="dataSource">A datasource, containing validation data for a complex 
        ''' document (invoke <see cref="GetDataSourceForNewComplexDocument">
        ''' GetDataSourceForNewComplexDocument</see> to fetch a datasource).</param>
        ''' <remarks></remarks>
        Friend Shared Function GetOperationChronologicValidator(ByVal assetID As Integer, _
            ByVal operationType As LtaOperationType, ByVal accountType As LtaAccountChangeType, _
            ByVal nAssetAcquisitionDate As Date, ByVal operationID As Integer, _
            ByVal operationDate As Date, ByVal parentValidator As IChronologicValidator, _
            ByVal dataSource As DataTable) As OperationChronologicValidator
            Return New OperationChronologicValidator(assetID, operationType, _
                accountType, nAssetAcquisitionDate, operationID, operationDate, _
                parentValidator, dataSource)
        End Function


        Friend Shared Function GetDataSourceForNewComplexDocument() As DataTable
            Dim myComm As New SQLCommand("CreateOperationChronologicValidator")
            Return myComm.Fetch
        End Function

        Friend Shared Function GetDataSourceForOldComplexDocument(ByVal nID As Integer, _
            ByVal nDate As Date) As DataTable
            Dim myComm As New SQLCommand("CreateOperationChronologicValidator")
            myComm.AddParam("?OD", nID)
            myComm.AddParam("?DT", nDate)
            Return myComm.Fetch
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal assetID As Integer, ByVal operationType As LtaOperationType, _
            ByVal accountType As LtaAccountChangeType, ByVal nAssetAcquisitionDate As Date, _
            ByVal parentValidator As IChronologicValidator)
            ' require use of factory methods
            Create(assetID, operationType, accountType, nAssetAcquisitionDate, parentValidator)
        End Sub

        Private Sub New(ByVal assetID As Integer, ByVal operationType As LtaOperationType, _
            ByVal accountType As LtaAccountChangeType, ByVal nAssetAcquisitionDate As Date, _
            ByVal parentValidator As IChronologicValidator, ByVal dataSource As DataTable)
            ' require use of factory methods
            Create(assetID, operationType, accountType, nAssetAcquisitionDate, _
                parentValidator, dataSource)
        End Sub

        Private Sub New(ByVal assetID As Integer, ByVal operationType As LtaOperationType, _
            ByVal accountType As LtaAccountChangeType, ByVal nAssetAcquisitionDate As Date, _
            ByVal operationID As Integer, ByVal operationDate As Date, _
            ByVal parentValidator As IChronologicValidator)
            ' require use of factory methods
            Fetch(assetID, operationType, accountType, nAssetAcquisitionDate, _
                operationID, operationDate, parentValidator)
        End Sub

        Private Sub New(ByVal assetID As Integer, ByVal operationType As LtaOperationType, _
            ByVal accountType As LtaAccountChangeType, ByVal nAssetAcquisitionDate As Date, _
            ByVal operationID As Integer, ByVal operationDate As Date, _
            ByVal parentValidator As IChronologicValidator, ByVal dataSource As DataTable)
            ' require use of factory methods
            Fetch(assetID, operationType, accountType, nAssetAcquisitionDate, _
                operationID, operationDate, parentValidator, dataSource)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal assetID As Integer, ByVal operationType As LtaOperationType, _
            ByVal accountType As LtaAccountChangeType, ByVal nAssetAcquisitionDate As Date, _
            ByVal parentValidator As IChronologicValidator)

            If Not assetID > 0 Then
                Throw New ArgumentNullException("assetID")
            End If

            Dim myComm As New SQLCommand("CreateOperationChronologicValidator")

            Using myData As DataTable = myComm.Fetch
                Create(assetID, operationType, accountType, nAssetAcquisitionDate, _
                    parentValidator, myData)
            End Using

        End Sub

        Private Sub Create(ByVal assetID As Integer, ByVal operationType As LtaOperationType, _
            ByVal accountType As LtaAccountChangeType, ByVal nAssetAcquisitionDate As Date, _
            ByVal parentValidator As IChronologicValidator, ByVal dataSource As DataTable)

            If Not assetID > 0 Then
                Throw New ArgumentNullException("assetID")
            End If

            If dataSource Is Nothing Then
                Create(assetID, operationType, accountType, nAssetAcquisitionDate, _
                    parentValidator)
                Exit Sub
            End If

            FetchItems(dataSource, assetID)

            _TypeOperation = operationType
            _TypeAccount = accountType
            _CurrentOperationName = GetOperationName(operationType, accountType)
            _AssetAcquisitionDate = nAssetAcquisitionDate

            SetBaseValidator(parentValidator)

            FetchLimitations()

        End Sub


        Private Sub Fetch(ByVal assetID As Integer, ByVal operationType As LtaOperationType, _
            ByVal accountType As LtaAccountChangeType, ByVal nAssetAcquisitionDate As Date, _
            ByVal operationID As Integer, ByVal operationDate As Date, _
            ByVal parentValidator As IChronologicValidator)

            Dim myComm As New SQLCommand("FetchOperationChronologicValidator")
            myComm.AddParam("?TD", assetID)
            myComm.AddParam("?DT", operationDate)
            myComm.AddParam("?OD", operationID)

            Using myData As DataTable = myComm.Fetch
                Fetch(assetID, operationType, accountType, nAssetAcquisitionDate, _
                    operationID, operationDate, parentValidator, myData)
            End Using

        End Sub

        Private Sub Fetch(ByVal assetID As Integer, ByVal operationType As LtaOperationType, _
            ByVal accountType As LtaAccountChangeType, ByVal nAssetAcquisitionDate As Date, _
            ByVal operationID As Integer, ByVal operationDate As Date, _
            ByVal parentValidator As IChronologicValidator, ByVal dataSource As DataTable)

            If dataSource Is Nothing Then
                Fetch(assetID, operationType, accountType, nAssetAcquisitionDate, _
                    operationID, operationDate, parentValidator)
                Exit Sub
            End If

            FetchItems(dataSource, assetID)

            _TypeOperation = operationType
            _TypeAccount = accountType
            _CurrentOperationName = GetOperationName(operationType, accountType)
            _CurrentOperationID = operationID
            _CurrentOperationDate = operationDate
            _AssetAcquisitionDate = nAssetAcquisitionDate

            SetBaseValidator(parentValidator)

            FetchLimitations()

        End Sub


        Private Sub FetchItems(ByVal myData As DataTable, ByVal assetID As Integer)

            RaiseListChangedEvents = False
            IsReadOnly = False

            For Each dr As DataRow In myData.Rows
                If CIntSafe(dr.Item(0), 0) = assetID Then
                    Add(OperationChronologicValidatorItem.GetOperationChronologicValidatorItem(dr))
                ElseIf CIntSafe(dr.Item(1), 0) = 999 Then
                    ' obsolete
                ElseIf CIntSafe(dr.Item(1), 0) = 998 Then
                    ' obsolete
                End If
            Next

            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

        'Private Function ExcludeItem(ByVal dr As DataRow, ByVal OperationID As Integer, _
        '    ByVal OperationDate As Date) As Boolean

        '    If Not OperationID > 0 Then Return False

        '    Dim t As LtaOperationType = ConvertEnumDatabaseStringCode(Of LtaOperationType) _
        '        (CStrSafe(dr.Item(1)))
        '    Dim d As Date = CDateSafe(dr.Item(4), Date.MinValue)

        '    If d = Date.MinValue Then Return True

        '    If d.Date = OperationDate.Date AndAlso t <> LtaOperationType.AccountChange Then Return True

        '    Return False

        'End Function

        Private Sub FetchLimitations()

            SetDefaults()

            SetMinDateApplicable(_AssetAcquisitionDate, String.Format( _
                My.Resources.Assets_OperationChronologicValidator_MinDateByAcquisitionDate, _
                _AssetAcquisitionDate.ToString("yyyy-MM-dd")), True)

            If _CurrentOperationID > 0 Then
                FetchLimitationsForOldOperation()
            Else
                FetchLimitationsForNewOperation()
            End If

            If Not _BaseValidator Is Nothing AndAlso _
                (_TypeOperation = LtaOperationType.AccountChange _
                OrElse _TypeOperation = LtaOperationType.Amortization _
                OrElse _TypeOperation = LtaOperationType.Discard) Then

                If Not _BaseValidator.FinancialDataCanChange Then

                    _FinancialDataCanChange = False
                    _FinancialDataCanChangeExplanation = AddWithNewLine(_FinancialDataCanChangeExplanation, _
                        _BaseValidator.FinancialDataCanChangeExplanation, False)
                    _ParentFinancialDataCanChange = False
                    _ParentFinancialDataCanChangeExplanation = AddWithNewLine(_FinancialDataCanChangeExplanation, _
                        _BaseValidator.FinancialDataCanChangeExplanation, False)

                End If

                If _BaseValidator.MaxDateApplicable Then
                    SetMaxDateApplicable(_BaseValidator.MaxDate, _BaseValidator.MaxDateExplanation, False)
                End If

                If _BaseValidator.MinDateApplicable Then
                    SetMinDateApplicable(_BaseValidator.MinDate, _BaseValidator.MinDateExplanation, False)
                End If

            End If

            SetLimitsExplanation()

            GetBackgroundDescription()

        End Sub

        Private Sub SetDefaults()

            _FinancialDataCanChange = True
            _FinancialDataCanChangeExplanation = ""
            _ParentFinancialDataCanChange = True
            _ParentFinancialDataCanChangeExplanation = ""

            _MaxDateApplicable = False
            _MaxDate = Date.MaxValue
            _MaxDateExplanation = ""

            _MinDateApplicable = False
            _MinDate = Date.MinValue
            _MinDateExplanation = ""

            _LimitsExplanation = ""
            _BackgroundExplanation = ""

        End Sub

        Private Sub SetMaxDateApplicable(ByVal nDate As Date, ByVal nExplanation As String, _
            ByVal addOneDay As Boolean)

            If nDate = Date.MaxValue OrElse nDate = Date.MinValue Then Exit Sub

            If addOneDay Then
                nDate = nDate.AddDays(-1)
            End If

            If Not nDate.Date < _MaxDate.Date Then Exit Sub

            _MaxDateApplicable = True
            _MaxDate = nDate.Date
            _MaxDateExplanation = nExplanation

        End Sub

        Private Sub SetMinDateApplicable(ByVal nDate As Date, ByVal nExplanation As String, _
            ByVal addOneDay As Boolean)

            If nDate = Date.MaxValue OrElse nDate = Date.MinValue Then Exit Sub

            If addOneDay Then
                nDate = nDate.AddDays(1)
            End If

            If Not nDate.Date > _MinDate.Date Then Exit Sub

            _MinDateApplicable = True
            _MinDate = nDate.Date
            _MinDateExplanation = nExplanation

        End Sub

        Private Sub SetFinancialDataCanChange(ByVal nDate As Date, ByVal nExplanation As String, _
            ByVal nDateExplanation As String, ByVal addOneDay As Boolean)

            If nDate = Date.MaxValue OrElse nDate = Date.MinValue OrElse _
                StringIsNullOrEmpty(nExplanation) Then Exit Sub

            _FinancialDataCanChange = False
            _FinancialDataCanChangeExplanation = AddWithNewLine(_FinancialDataCanChangeExplanation, _
                nExplanation, False)

            SetMaxDateApplicable(nDate, nDateExplanation, addOneDay)

        End Sub

        Private Sub LockDateAndFinancialData(ByVal nExplanation As String, _
            ByVal nDateExplanation As String)

            _FinancialDataCanChange = False
            _FinancialDataCanChangeExplanation = AddWithNewLine(_FinancialDataCanChangeExplanation, _
                nExplanation, False)

            SetMinDateApplicable(_CurrentOperationDate, nDateExplanation, False)
            SetMaxDateApplicable(_CurrentOperationDate, nDateExplanation, False)

        End Sub

        Private Sub SetBaseValidator(ByVal parentValidator As IChronologicValidator)

            If parentValidator Is Nothing Then
                _BaseValidator = SimpleChronologicValidator. _
                    NewSimpleChronologicValidator(_CurrentOperationName, Nothing)
            ElseIf TypeOf parentValidator Is ComplexChronologicValidator Then
                If DirectCast(parentValidator, ComplexChronologicValidator).BaseValidator Is Nothing Then
                    _BaseValidator = SimpleChronologicValidator. _
                        NewSimpleChronologicValidator(_CurrentOperationName, Nothing)
                Else
                    _BaseValidator = DirectCast(parentValidator,  _
                        ComplexChronologicValidator).BaseValidator
                End If
            Else
                _BaseValidator = parentValidator
            End If

        End Sub

        Private Sub SetLimitsExplanation()

            _LimitsExplanation = ""

            If Not _FinancialDataCanChange Then
                _LimitsExplanation = _FinancialDataCanChangeExplanation
            End If

            If _MinDateApplicable AndAlso _MaxDateApplicable Then

                If _MinDateExplanation.Trim = _MaxDateExplanation.Trim Then
                    _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MinDateExplanation, False)
                Else
                    _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MinDateExplanation, False)
                    _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MaxDateExplanation, False)
                End If

            Else

                If _MinDateApplicable Then
                    _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MinDateExplanation, False)
                End If
                If _MaxDateApplicable Then
                    _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MaxDateExplanation, False)
                End If

            End If

        End Sub

        Private Function GetBackgroundDescription() As String

            Dim result As String = _LimitsExplanation

            If String.IsNullOrEmpty(_LimitsExplanation) Then

                result = My.Resources.Assets_OperationChronologicValidator_DescriptionLimitsNull

            Else

                result = String.Format(My.Resources.Assets_OperationChronologicValidator_DescriptionLimits, _
                    vbCrLf, _LimitsExplanation)

            End If

            Dim tmpResult As String = ""

            For Each i As OperationChronologicValidatorItem In Me
                If i.ChronologyType = OperationChronologyType.Overall Then
                    tmpResult = AddWithNewLine(tmpResult, String.Format( _
                        "{0} - {1}", ConvertEnumHumanReadable(i.OperationType), _
                        i.MaxDate.ToString("yyyy-MM-dd")), False)
                End If
            Next

            If Not String.IsNullOrEmpty(tmpResult.Trim) Then

                If Not String.IsNullOrEmpty(result.Trim) Then
                    result = result & vbCrLf & vbCrLf
                End If

                result = AddWithNewLine(result, String.Format( _
                    My.Resources.Assets_OperationChronologicValidator_DescriptionLastOperations, _
                    vbCrLf, tmpResult), False)

            End If

            If Not CurrentOperationID > 0 Then Return result

            tmpResult = ""

            For Each i As OperationChronologicValidatorItem In Me
                If i.ChronologyType = OperationChronologyType.LastBefore Then
                    tmpResult = AddWithNewLine(tmpResult, String.Format( _
                        "{0} - {1}", ConvertEnumHumanReadable(i.OperationType), _
                        i.MaxDate.ToString("yyyy-MM-dd")), False)
                End If
            Next

            If Not String.IsNullOrEmpty(tmpResult.Trim) Then

                If Not String.IsNullOrEmpty(result.Trim) Then
                    result = result & vbCrLf & vbCrLf
                End If

                result = AddWithNewLine(result, String.Format( _
                    My.Resources.Assets_OperationChronologicValidator_DescriptionLastOperationsBefore, _
                    vbCrLf, tmpResult), False)

            End If

            tmpResult = ""

            For Each i As OperationChronologicValidatorItem In Me
                If i.ChronologyType = OperationChronologyType.FirstAfter Then
                    tmpResult = AddWithNewLine(tmpResult, String.Format("{0} - {1}", _
                        ConvertEnumHumanReadable(i.OperationType), _
                        i.MaxDate.ToString("yyyy-MM-dd")), False)
                End If
            Next

            If Not String.IsNullOrEmpty(tmpResult.Trim) Then

                If Not String.IsNullOrEmpty(result.Trim) Then
                    result = result & vbCrLf & vbCrLf
                End If

                result = AddWithNewLine(result, String.Format( _
                    My.Resources.Assets_OperationChronologicValidator_DescriptionFirstOperationsAfter, _
                    vbCrLf, tmpResult), False)

            End If

            Return result

        End Function

        Private Function GetOperationListString(ByVal operations As LtaOperationType()) As String

            If operations Is Nothing OrElse operations.Length < 1 Then Return ""

            Dim result As New List(Of String)

            For Each operation As LtaOperationType In operations
                result.Add(ConvertEnumHumanReadable(operation))
            Next

            Return String.Join(", ", result.ToArray())

        End Function


        Private Sub FetchLimitationsForNewOperation()

            Dim affectingTypes As LtaOperationType() = IsAffectedByDictionary(_TypeOperation)

            If Not affectingTypes Is Nothing AndAlso affectingTypes.Length > 0 Then

                Dim lastSignificantDate As Date = GetMaxDate(OperationChronologyType.Overall, _
                affectingTypes)

                SetMinDateApplicable(lastSignificantDate, String.Format( _
                    My.Resources.Assets_OperationChronologicValidator_MinDateExplanation, _
                    lastSignificantDate.ToString("yyyy-MM-dd")), True)

            End If

        End Sub

        Private Sub FetchLimitationsForOldOperation()

            Dim lockingTypes As LtaOperationType() = IsLockedByDictionary(_TypeOperation)

            If Not lockingTypes Is Nothing AndAlso lockingTypes.Length > 0 Then

                If GetMaxDate(OperationChronologyType.FirstAfter, lockingTypes) <> Date.MinValue Then

                    LockDateAndFinancialData(My.Resources.Assets_OperationChronologicValidator_FinancialDataCanChangeExplanation, _
                        String.Format(My.Resources.Assets_OperationChronologicValidator_DateIsLockedExplanation, _
                        GetOperationListString(lockingTypes)))

                    Exit Sub

                End If

            End If

            Dim affectingTypes As LtaOperationType() = IsAffectedByDictionary(_TypeOperation)

            If Not affectingTypes Is Nothing AndAlso affectingTypes.Length > 0 Then

                Dim firstSignificantDate As Date = _
                    GetMinDate(OperationChronologyType.FirstAfter, affectingTypes)

                SetFinancialDataCanChange(firstSignificantDate, _
                    My.Resources.Assets_OperationChronologicValidator_FinancialDataCanChangeExplanation, _
                    String.Format(My.Resources.Assets_OperationChronologicValidator_MaxDateExplanation, _
                    firstSignificantDate.ToString("yyyy-MM-dd")), False)

                Dim lastSignificantDate As Date = _
                    GetMaxDate(OperationChronologyType.LastBefore, affectingTypes)

                SetMinDateApplicable(lastSignificantDate, String.Format( _
                    My.Resources.Assets_OperationChronologicValidator_MinDateExplanation, _
                    lastSignificantDate.ToString("yyyy-MM-dd")), True)

            End If

        End Sub


        'Private Sub FetchLimitationsForNewAccountChange()

        '    Dim lastSignificantDate As Date = GetMaxDate(OperationChronologyType.Overall, _
        '        LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
        '        LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
        '        LtaOperationType.Transfer)

        '    SetMinDateApplicable(lastSignificantDate, "Minimali leidžiama operacijos data yra " _
        '        & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        'End Sub

        'Private Sub FetchLimitationsForOldAccountChange()

        '    Dim firstSignificantDate As Date = GetMinDate(OperationChronologyType.FirstAfter, _
        '        LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
        '        LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
        '        LtaOperationType.Transfer)

        '    SetFinancialDataCanChange(firstSignificantDate, "Finansinių operacijos duomenų keisti " _
        '        & "negalima, nes vėlesne data yra registruota operacijų su turtu.", _
        '        "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
        '        & "yra registruota operacijų su turtu.", False)

        '    Dim lastSignificantDate As Date = GetMaxDate(OperationChronologyType.LastBefore, _
        '        LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
        '        LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
        '        LtaOperationType.Transfer)

        '    SetMinDateApplicable(lastSignificantDate, "Minimali leidžiama operacijos data yra " _
        '        & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        'End Sub

        'Private Sub FetchLimitationsForNewValueIncrease()

        '    Dim lastSignificantDate As Date = GetMaxDate(OperationChronologyType.Overall, _
        '        LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
        '        LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
        '        LtaOperationType.Transfer)

        '    SetMinDateApplicable(lastSignificantDate, "Minimali leidžiama operacijos data yra " _
        '        & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        'End Sub

        'Private Sub FetchLimitationsForOldValueIncrease()

        '    If GetMaxDate(OperationChronologyType.FirstAfter, LtaOperationType.Amortization) _
        '        <> Date.MinValue Then

        '        LockDateAndFinancialData("Finansinių operacijos duomenų keisti " _
        '            & "negalima, nes nes po šios operacijos buvo skaičiuota amortizacija.", _
        '            "Operacijos data negali keistis, nes po šios operacijos " _
        '            & "buvo skaičiuota amortizacija.")

        '        Exit Sub

        '    End If

        '    Dim firstSignificantDate As Date = GetMinDate(OperationChronologyType.FirstAfter, _
        '        LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
        '        LtaOperationType.ValueChange, LtaOperationType.Discard, LtaOperationType.Transfer)

        '    SetFinancialDataCanChange(firstSignificantDate, "Finansinių operacijos duomenų keisti " _
        '        & "negalima, nes vėlesne data yra registruota operacijų su turtu.", _
        '        "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
        '        & "yra registruota operacijų su turtu.", False)

        '    Dim lastSignificantDate As Date = GetMaxDate(OperationChronologyType.LastBefore, _
        '        LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
        '        LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
        '        LtaOperationType.Transfer)

        '    SetMinDateApplicable(lastSignificantDate, "Minimali leidžiama operacijos data yra " _
        '        & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        'End Sub

        'Private Sub FetchLimitationsForNewAmortization()

        '    Dim lastSignificantDate As Date = GetMaxDate(OperationChronologyType.Overall, _
        '        LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
        '        LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
        '        LtaOperationType.Transfer)

        '    SetMinDateApplicable(lastSignificantDate, "Minimali leidžiama operacijos data yra " _
        '        & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        'End Sub

        'Private Sub FetchLimitationsForOldAmortization()

        '    If GetMaxDate(OperationChronologyType.FirstAfter, LtaOperationType.Amortization) _
        '        <> Date.MinValue Then

        '        LockDateAndFinancialData("Finansinių operacijos duomenų keisti " _
        '            & "negalima, nes nes po šios operacijos buvo skaičiuota amortizacija.", _
        '            "Operacijos data negali keistis, nes po šios operacijos " _
        '            & "buvo skaičiuota amortizacija.")

        '        Exit Sub

        '    End If

        '    Dim firstSignificantDate As Date = GetMinDate(OperationChronologyType.FirstAfter, _
        '        LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
        '        LtaOperationType.ValueChange, LtaOperationType.Discard, LtaOperationType.Transfer)

        '    SetFinancialDataCanChange(firstSignificantDate, "Finansinių operacijos duomenų keisti " _
        '        & "negalima, nes vėlesne data yra registruota operacijų su turtu.", _
        '        "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
        '        & "yra registruota operacijų su turtu.", False)

        '    Dim LastSignificantDate As Date = GetMaxDate(OperationChronologyType.LastBefore, _
        '        LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
        '        LtaOperationType.ValueChange, LtaOperationType.Discard, LtaOperationType.Transfer)

        '    SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
        '        & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        'End Sub

        'Private Sub FetchLimitationsForNewAmortizationPeriod()

        '    Dim lastSignificantDate As Date = GetMaxDate(OperationChronologyType.Overall, _
        '        LtaOperationType.Amortization)

        '    SetMinDateApplicable(lastSignificantDate, "Minimali leidžiama operacijos data yra " _
        '        & DatePlaceHolder & ", nes prieš tai yra skaičiuota amortizacija.", True)

        'End Sub

        'Private Sub FetchLimitationsForOldAmortizationPeriod()

        '    If GetMaxDate(OperationChronologyType.FirstAfter, LtaOperationType.Amortization) _
        '        <> Date.MinValue Then

        '        LockDateAndFinancialData("Finansinių operacijos duomenų keisti " _
        '            & "negalima, nes nes po šios operacijos buvo skaičiuota amortizacija.", _
        '            "Operacijos data negali keistis, nes po šios operacijos " _
        '            & "buvo skaičiuota amortizacija.")

        '    Else

        '        Dim lastSignificantDate As Date = GetMaxDate(OperationChronologyType.Overall, _
        '            LtaOperationType.Amortization)

        '        SetMinDateApplicable(lastSignificantDate, "Minimali leidžiama operacijos data yra " _
        '            & DatePlaceHolder & ", nes prieš tai yra skaičiuota amortizacija.", True)

        '    End If

        'End Sub

        'Private Sub FetchLimitationsForNewDiscard()

        '    Dim lastSignificantDate As Date = GetMaxDate(OperationChronologyType.Overall, _
        '        LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
        '        LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
        '        LtaOperationType.Transfer)

        '    SetMinDateApplicable(lastSignificantDate, "Minimali leidžiama operacijos data yra " _
        '        & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        'End Sub

        'Private Sub FetchLimitationsForOldDiscard()

        '    If GetMaxDate(OperationChronologyType.FirstAfter, LtaOperationType.Amortization) _
        '        <> Date.MinValue Then

        '        LockDateAndFinancialData("Finansinių operacijos duomenų keisti " _
        '            & "negalima, nes nes po šios operacijos buvo skaičiuota amortizacija.", _
        '            "Operacijos data negali keistis, nes po šios operacijos " _
        '            & "buvo skaičiuota amortizacija.")

        '        Exit Sub

        '    End If

        '    Dim firstSignificantDate As Date = GetMinDate(OperationChronologyType.FirstAfter, _
        '        LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
        '        LtaOperationType.ValueChange, LtaOperationType.Transfer)

        '    SetFinancialDataCanChange(firstSignificantDate, "Finansinių operacijos duomenų keisti " _
        '        & "negalima, nes vėlesne data yra registruota operacijų su turtu.", _
        '        "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
        '        & "yra registruota operacijų su turtu.", False)

        '    Dim lastSignificantDate As Date = GetMaxDate(OperationChronologyType.LastBefore, _
        '        LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
        '        LtaOperationType.ValueChange, LtaOperationType.Discard, LtaOperationType.Transfer)

        '    SetMinDateApplicable(lastSignificantDate, "Minimali leidžiama operacijos data yra " _
        '        & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        'End Sub

        'Private Sub FetchLimitationsForNewTransfer()

        '    Dim lastSignificantDate As Date = GetMaxDate(OperationChronologyType.Overall, _
        '        LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
        '        LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
        '        LtaOperationType.Transfer)

        '    SetMinDateApplicable(lastSignificantDate, "Minimali leidžiama operacijos data yra " _
        '        & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        'End Sub

        'Private Sub FetchLimitationsForOldTransfer()

        '    If GetMaxDate(OperationChronologyType.FirstAfter, LtaOperationType.Amortization) _
        '        <> Date.MinValue Then

        '        LockDateAndFinancialData("Finansinių operacijos duomenų keisti " _
        '            & "negalima, nes nes po šios operacijos buvo skaičiuota amortizacija.", _
        '            "Operacijos data negali keistis, nes po šios operacijos " _
        '            & "buvo skaičiuota amortizacija.")

        '        Exit Sub

        '    End If

        '    Dim firstSignificantDate As Date = GetMinDate(OperationChronologyType.FirstAfter, _
        '        LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
        '        LtaOperationType.ValueChange, LtaOperationType.Transfer)

        '    SetFinancialDataCanChange(firstSignificantDate, "Finansinių operacijos duomenų keisti " _
        '        & "negalima, nes vėlesne data yra registruota operacijų su turtu.", _
        '        "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
        '        & "yra registruota operacijų su turtu.", False)

        '    Dim lastSignificantDate As Date = GetMaxDate(OperationChronologyType.LastBefore, _
        '        LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
        '        LtaOperationType.ValueChange, LtaOperationType.Discard, LtaOperationType.Transfer)

        '    SetMinDateApplicable(lastSignificantDate, "Minimali leidžiama operacijos data yra " _
        '        & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        'End Sub

        'Private Sub FetchLimitationsForNewUsage()

        '    Dim lastSignificantDate As Date = GetMaxDate(OperationChronologyType.Overall, _
        '        LtaOperationType.Amortization, LtaOperationType.UsingStart, LtaOperationType.UsingEnd)

        '    SetMinDateApplicable(lastSignificantDate, "Minimali leidžiama operacijos data yra " _
        '        & DatePlaceHolder & ", nes prieš tai yra skaičiuota amortizacija ir (ar) keistas " _
        '        & "eksploatacijos statusas.", True)

        'End Sub

        'Private Sub FetchLimitationsForOldUsage()

        '    If GetMaxDate(OperationChronologyType.FirstAfter, LtaOperationType.Amortization) _
        '        <> Date.MinValue Then

        '        LockDateAndFinancialData("Finansinių operacijos duomenų keisti " _
        '            & "negalima, nes nes po šios operacijos buvo skaičiuota amortizacija.", _
        '            "Operacijos data negali keistis, nes po šios operacijos " _
        '            & "buvo skaičiuota amortizacija.")

        '        Exit Sub

        '    End If

        '    Dim firstSignificantDate As Date = GetMinDate(OperationChronologyType.FirstAfter, _
        '        LtaOperationType.UsingEnd, LtaOperationType.UsingStart)

        '    SetFinancialDataCanChange(firstSignificantDate, "Finansinių operacijos duomenų keisti " _
        '        & "negalima, nes vėlesne data yra registruota eksploatacijos statuso keitimas.", _
        '        "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
        '        & "yra registruotas eksploatacijos statuso keitimas.", False)

        '    Dim lastSignificantDate As Date = GetMaxDate(OperationChronologyType.LastBefore, _
        '        LtaOperationType.Amortization, LtaOperationType.UsingStart, LtaOperationType.UsingEnd)

        '    SetMinDateApplicable(lastSignificantDate, "Minimali leidžiama operacijos data yra " _
        '        & DatePlaceHolder & ", nes prieš tai yra skaičiuota amortizacija ir (ar) keistas " _
        '        & "eksploatacijos statusas.", True)

        'End Sub

        'Private Sub FetchLimitationsForNewValueChange()

        '    Dim lastSignificantDate As Date = GetMaxDate(OperationChronologyType.Overall, _
        '        LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
        '        LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
        '        LtaOperationType.Transfer)

        '    SetMinDateApplicable(lastSignificantDate, "Minimali leidžiama operacijos data yra " _
        '        & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        'End Sub

        'Private Sub FetchLimitationsForOldValueChange()

        '    If GetMaxDate(OperationChronologyType.FirstAfter, LtaOperationType.Amortization) _
        '        <> Date.MinValue Then

        '        LockDateAndFinancialData("Finansinių operacijos duomenų keisti " _
        '            & "negalima, nes nes po šios operacijos buvo skaičiuota amortizacija.", _
        '            "Operacijos data negali keistis, nes po šios operacijos " _
        '            & "buvo skaičiuota amortizacija.")

        '        Exit Sub

        '    End If

        '    Dim firstSignificantDate As Date = GetMinDate(OperationChronologyType.FirstAfter, _
        '        LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
        '        LtaOperationType.ValueChange, LtaOperationType.Discard, LtaOperationType.Transfer)

        '    SetFinancialDataCanChange(firstSignificantDate, "Finansinių operacijos duomenų keisti " _
        '        & "negalima, nes vėlesne data yra registruota operacijų su turtu.", _
        '        "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
        '        & "yra registruota operacijų su turtu.", False)

        '    Dim lastSignificantDate As Date = GetMaxDate(OperationChronologyType.LastBefore, _
        '        LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
        '        LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
        '        LtaOperationType.Transfer)

        '    SetMinDateApplicable(lastSignificantDate, "Minimali leidžiama operacijos data yra " _
        '        & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        'End Sub

#End Region

    End Class

End Namespace