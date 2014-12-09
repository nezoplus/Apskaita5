Namespace Assets

    <Serializable()> _
    Public Class OperationChronologicValidator
        Inherits ReadOnlyListBase(Of OperationChronologicValidator, OperationChronologicValidatorItem)
        Implements IChronologicValidator

#Region " Business Methods "

        Private Const DatePlaceHolder As String = "<$Date>"

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
        Private _CurrentAssetName As String = ""
        Private _AssetAcquisitionDate As Date = Date.MinValue
        Private _ParentFinancialDataCanChange As Boolean = True
        Private _ParentFinancialDataCanChangeExplanation As String = ""
        Private _BaseValidator As SimpleChronologicValidator


        Public ReadOnly Property CurrentOperationID() As Integer _
            Implements IChronologicValidator.CurrentOperationID
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationID
            End Get
        End Property

        Public ReadOnly Property CurrentOperationDate() As Date _
            Implements IChronologicValidator.CurrentOperationDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationDate
            End Get
        End Property

        Public ReadOnly Property CurrentOperationName() As String _
            Implements IChronologicValidator.CurrentOperationName
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationName.Trim
            End Get
        End Property

        Public ReadOnly Property FinancialDataCanChange() As Boolean _
            Implements IChronologicValidator.FinancialDataCanChange
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property MinDateApplicable() As Boolean _
            Implements IChronologicValidator.MinDateApplicable
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDateApplicable
            End Get
        End Property

        Public ReadOnly Property MaxDateApplicable() As Boolean _
            Implements IChronologicValidator.MaxDateApplicable
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDateApplicable
            End Get
        End Property

        Public ReadOnly Property MinDate() As Date _
            Implements IChronologicValidator.MinDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDate
            End Get
        End Property

        Public ReadOnly Property MaxDate() As Date _
            Implements IChronologicValidator.MaxDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDate
            End Get
        End Property

        Public ReadOnly Property FinancialDataCanChangeExplanation() As String _
            Implements IChronologicValidator.FinancialDataCanChangeExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChangeExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property MinDateExplanation() As String _
            Implements IChronologicValidator.MinDateExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDateExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property MaxDateExplanation() As String _
            Implements IChronologicValidator.MaxDateExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDateExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property LimitsExplanation() As String _
            Implements IChronologicValidator.LimitsExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LimitsExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property BackgroundExplanation() As String _
            Implements IChronologicValidator.BackgroundExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BackgroundExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property TypeOperation() As LtaOperationType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TypeOperation
            End Get
        End Property

        Public ReadOnly Property AssetAcquisitionDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AssetAcquisitionDate
            End Get
        End Property

        Public ReadOnly Property ParentFinancialDataCanChange() As Boolean _
        Implements IChronologicValidator.ParentFinancialDataCanChange
            Get
                Return _ParentFinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property ParentFinancialDataCanChangeExplanation() As String _
            Implements IChronologicValidator.ParentFinancialDataCanChangeExplanation
            Get
                Return _ParentFinancialDataCanChangeExplanation
            End Get
        End Property

        Public ReadOnly Property CurrentAssetName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentAssetName.Trim
            End Get
        End Property

        Public ReadOnly Property BaseValidator As SimpleChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BaseValidator
            End Get
        End Property


        Public Function GetDate(ByVal ChronologyType As OperationChronologyType, _
            ByVal OperationType As LtaOperationType, ByVal AccountType As LtaAccountChangeType) As Date

            For Each i As OperationChronologicValidatorItem In Me
                If i.OperationType = OperationType AndAlso i.ChronologyType = ChronologyType _
                    AndAlso (OperationType <> LtaOperationType.AccountChange OrElse _
                    AccountType = i.AccountChangeType) Then Return i.MaxDate
            Next
            Return Date.MinValue

        End Function

        Public Function GetDate(ByVal ChronologyType As OperationChronologyType, _
            ByVal OperationType As LtaOperationType) As Date

            For Each i As OperationChronologicValidatorItem In Me
                If i.OperationType = OperationType AndAlso _
                    i.ChronologyType = ChronologyType Then Return i.MaxDate
            Next
            Return Date.MinValue

        End Function

        Public Function GetMaxDate(ByVal ChronologyType As OperationChronologyType, _
            ByVal ParamArray OperationTypes As LtaOperationType()) As Date

            Dim result As Date = Date.MinValue

            If OperationTypes Is Nothing Then

                For Each i As OperationChronologicValidatorItem In Me
                    If i.ChronologyType = ChronologyType AndAlso i.MaxDate.Date > result.Date Then _
                        result = i.MaxDate
                Next

            Else

                For Each i As OperationChronologicValidatorItem In Me
                    If i.ChronologyType = ChronologyType AndAlso Not Array.IndexOf( _
                        OperationTypes, i.OperationType) < 0 AndAlso i.MaxDate.Date > result.Date Then _
                        result = i.MaxDate
                Next

            End If

            Return result

        End Function

        Public Function GetMinDate(ByVal ChronologyType As OperationChronologyType, _
            ByVal ParamArray OperationTypes As LtaOperationType()) As Date

            Dim result As Date = Date.MaxValue

            If OperationTypes Is Nothing Then

                For Each i As OperationChronologicValidatorItem In Me
                    If i.ChronologyType = ChronologyType AndAlso i.MaxDate.Date < result.Date Then _
                        result = i.MaxDate
                Next

            Else

                For Each i As OperationChronologicValidatorItem In Me
                    If i.ChronologyType = ChronologyType AndAlso Not Array.IndexOf( _
                        OperationTypes, i.OperationType) < 0 AndAlso i.MaxDate.Date < result.Date Then _
                        result = i.MaxDate
                Next

            End If

            Return result

        End Function

        Public Function GetBackgroundDescription() As String

            Dim result As String = ""

            Dim tmpResult As String = ""

            For Each i As OperationChronologicValidatorItem In Me
                If i.ChronologyType = OperationChronologyType.Overall Then tmpResult = _
                    AddWithNewLine(tmpResult, ConvertEnumHumanReadable(i.OperationType) _
                    & " - " & i.MaxDate.ToString("yyyy-MM-dd"), False)
            Next

            If Not String.IsNullOrEmpty(tmpResult.Trim) Then result = _
                "Paskutinės operacijos su ilgalaikiu turtu:" & vbCrLf & tmpResult

            If Not CurrentOperationID > 0 Then Return result

            tmpResult = ""

            For Each i As OperationChronologicValidatorItem In Me
                If i.ChronologyType = OperationChronologyType.LastBefore Then tmpResult = _
                    AddWithNewLine(tmpResult, ConvertEnumHumanReadable(i.OperationType) _
                    & " - " & i.MaxDate.ToString("yyyy-MM-dd"), False)
            Next

            If Not String.IsNullOrEmpty(tmpResult.Trim) Then

                If Not String.IsNullOrEmpty(result.Trim) Then
                    result = result & vbCrLf & vbCrLf & "Paskutinės operacijos su ilgalaikiu " _
                        & "turtu iki keičiamos operacijos:" & vbCrLf & tmpResult
                Else
                    result = "Paskutinės operacijos su ilgalaikiu turtu " _
                       & "iki keičiamos operacijos:" & vbCrLf & tmpResult
                End If

            End If

            tmpResult = ""

            For Each i As OperationChronologicValidatorItem In Me
                If i.ChronologyType = OperationChronologyType.FirstAfter Then tmpResult = _
                    AddWithNewLine(tmpResult, ConvertEnumHumanReadable(i.OperationType) _
                    & " - " & i.MaxDate.ToString("yyyy-MM-dd"), False)
            Next

            If Not String.IsNullOrEmpty(tmpResult.Trim) Then

                If Not String.IsNullOrEmpty(result.Trim) Then
                    result = result & vbCrLf & vbCrLf & "Pirmos operacijos su ilgalaikiu " _
                        & "turtu po keičiamos operacijos:" & vbCrLf & tmpResult
                Else
                    result = "Pirmos operacijos su ilgalaikiu turtu " _
                       & "po keičiamos operacijos:" & vbCrLf & tmpResult
                End If

            End If

            Return result

        End Function

        Public Sub ReconfigureForType(ByVal newType As LtaOperationType, ByVal newAccountType As LtaAccountChangeType)

            If newType = _TypeOperation Then
                If newType <> LtaOperationType.AccountChange OrElse newAccountType = _TypeAccount Then Exit Sub
            End If

            _TypeOperation = newType
            _TypeAccount = newAccountType
            _CurrentOperationName = """" & _CurrentAssetName & """ - " & ConvertEnumHumanReadable(_TypeOperation)
            If _TypeOperation = LtaOperationType.AccountChange Then _CurrentOperationName = _
                _CurrentOperationName & ", " & ConvertEnumHumanReadable(_TypeAccount)

            FetchLimitations()

        End Sub


        Public Function ValidateOperationDate(ByVal OperationDate As Date, ByRef ErrorMessage As String, _
            ByRef ErrorSeverity As Csla.Validation.RuleSeverity) As Boolean _
            Implements IChronologicValidator.ValidateOperationDate

            If _MinDateApplicable AndAlso OperationDate.Date < _MinDate.Date Then
                ErrorMessage = _MinDateExplanation
                ErrorSeverity = Validation.RuleSeverity.Error
                Return False
            ElseIf _MaxDateApplicable AndAlso OperationDate.Date > _MaxDate.Date Then
                ErrorMessage = _MaxDateExplanation
                ErrorSeverity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function


        Public Overrides Function ToString() As String
            Return _CurrentOperationName
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function NewOperationChronologicValidator(ByVal AssetID As Integer, _
            ByVal AssetName As String, ByVal nOperationType As LtaOperationType, _
            ByVal nAccountType As LtaAccountChangeType, ByVal nAssetAcquisitionDate As Date, _
            ByVal parentValidator As IChronologicValidator) As OperationChronologicValidator
            Return New OperationChronologicValidator(AssetID, AssetName, nOperationType, _
                nAccountType, nAssetAcquisitionDate, parentValidator)
        End Function

        Friend Shared Function NewOperationChronologicValidator(ByVal AssetID As Integer, _
            ByVal AssetName As String, ByVal nOperationType As LtaOperationType, _
            ByVal nAccountType As LtaAccountChangeType, ByVal nAssetAcquisitionDate As Date, _
            ByVal parentValidator As IChronologicValidator, ByVal DataSource As DataTable) As OperationChronologicValidator
            Return New OperationChronologicValidator(AssetID, AssetName, nOperationType, _
                nAccountType, nAssetAcquisitionDate, parentValidator, DataSource)
        End Function

        Friend Shared Function GetOperationChronologicValidator(ByVal AssetID As Integer, _
            ByVal AssetName As String, ByVal nOperationType As LtaOperationType, _
            ByVal nAccountType As LtaAccountChangeType, ByVal nAssetAcquisitionDate As Date, _
            ByVal nOperationID As Integer, ByVal nOperationDate As Date, _
            ByVal parentValidator As IChronologicValidator) As OperationChronologicValidator
            Return New OperationChronologicValidator(AssetID, AssetName, nOperationType, _
                nAccountType, nAssetAcquisitionDate, nOperationID, nOperationDate, parentValidator)
        End Function

        Friend Shared Function GetOperationChronologicValidator(ByVal AssetID As Integer, _
            ByVal AssetName As String, ByVal nOperationType As LtaOperationType, _
            ByVal nAccountType As LtaAccountChangeType, ByVal nAssetAcquisitionDate As Date, _
            ByVal nOperationID As Integer, ByVal nOperationDate As Date, _
            ByVal parentValidator As IChronologicValidator, ByVal DataSource As DataTable) _
            As OperationChronologicValidator
            Return New OperationChronologicValidator(AssetID, AssetName, nOperationType, _
                nAccountType, nAssetAcquisitionDate, nOperationID, nOperationDate, _
                parentValidator, DataSource)
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

        Private Sub New(ByVal AssetID As Integer, ByVal AssetName As String, _
            ByVal nOperationType As LtaOperationType, ByVal nAccountType As LtaAccountChangeType, _
            ByVal nAssetAcquisitionDate As Date, ByVal parentValidator As IChronologicValidator)
            ' require use of factory methods
            Create(AssetID, AssetName, nOperationType, nAccountType, nAssetAcquisitionDate, parentValidator)
        End Sub

        Private Sub New(ByVal AssetID As Integer, ByVal AssetName As String, _
            ByVal nOperationType As LtaOperationType, ByVal nAccountType As LtaAccountChangeType, _
            ByVal nAssetAcquisitionDate As Date, ByVal parentValidator As IChronologicValidator, _
            ByVal DataSource As DataTable)
            ' require use of factory methods
            Create(AssetID, AssetName, nOperationType, nAccountType, nAssetAcquisitionDate, _
                parentValidator, DataSource)
        End Sub

        Private Sub New(ByVal AssetID As Integer, ByVal AssetName As String, _
            ByVal nOperationType As LtaOperationType, ByVal nAccountType As LtaAccountChangeType, _
            ByVal nAssetAcquisitionDate As Date, ByVal nOperationID As Integer, _
            ByVal nOperationDate As Date, ByVal parentValidator As IChronologicValidator)
            ' require use of factory methods
            Fetch(AssetID, AssetName, nOperationType, nAccountType, nAssetAcquisitionDate, _
                nOperationID, nOperationDate, parentValidator)
        End Sub

        Private Sub New(ByVal AssetID As Integer, ByVal AssetName As String, _
            ByVal nOperationType As LtaOperationType, ByVal nAccountType As LtaAccountChangeType, _
            ByVal nAssetAcquisitionDate As Date, ByVal nOperationID As Integer, _
            ByVal nOperationDate As Date, ByVal parentValidator As IChronologicValidator, _
            ByVal DataSource As DataTable)
            ' require use of factory methods
            Fetch(AssetID, AssetName, nOperationType, nAccountType, nAssetAcquisitionDate, _
                nOperationID, nOperationDate, parentValidator, DataSource)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal AssetID As Integer, ByVal AssetName As String, _
            ByVal nOperationType As LtaOperationType, ByVal nAccountType As LtaAccountChangeType, _
            ByVal nAssetAcquisitionDate As Date, ByVal parentValidator As IChronologicValidator)

            Dim myComm As New SQLCommand("CreateOperationChronologicValidator")

            Using myData As DataTable = myComm.Fetch
                Create(AssetID, AssetName, nOperationType, nAccountType, nAssetAcquisitionDate, _
                    parentValidator, myData)
            End Using

        End Sub

        Private Sub Create(ByVal AssetID As Integer, ByVal AssetName As String, _
            ByVal nOperationType As LtaOperationType, ByVal nAccountType As LtaAccountChangeType, _
            ByVal nAssetAcquisitionDate As Date, ByVal parentValidator As IChronologicValidator, _
            ByVal DataSource As DataTable)

            FetchItems(DataSource, AssetID)

            _TypeOperation = nOperationType
            _TypeAccount = nAccountType
            _CurrentAssetName = AssetName
            _CurrentOperationName = """" & AssetName & """ - " & ConvertEnumHumanReadable(nOperationType)
            If nOperationType = LtaOperationType.AccountChange Then _CurrentOperationName = _
                _CurrentOperationName & ", " & ConvertEnumHumanReadable(nAccountType)
            _AssetAcquisitionDate = nAssetAcquisitionDate
            _BaseValidator = parentValidator
            If _BaseValidator Is Nothing Then _BaseValidator = _
                SimpleChronologicValidator.NewSimpleChronologicValidator("operacija su ilgalaikiu turtu")

            FetchLimitations()

        End Sub

        Private Sub Fetch(ByVal AssetID As Integer, ByVal AssetName As String, _
            ByVal nOperationType As LtaOperationType, ByVal nAccountType As LtaAccountChangeType, _
            ByVal nAssetAcquisitionDate As Date, ByVal nOperationID As Integer, _
            ByVal nOperationDate As Date, ByVal parentValidator As IChronologicValidator)

            Dim myComm As New SQLCommand("FetchOperationChronologicValidator")
            myComm.AddParam("?TD", AssetID)
            myComm.AddParam("?DT", nOperationDate)
            myComm.AddParam("?OD", nOperationID)

            Using myData As DataTable = myComm.Fetch
                Fetch(AssetID, AssetName, nOperationType, nAccountType, nAssetAcquisitionDate, _
                    nOperationID, nOperationDate, parentValidator, myData)
            End Using

        End Sub

        Private Sub Fetch(ByVal AssetID As Integer, ByVal AssetName As String, _
            ByVal nOperationType As LtaOperationType, ByVal nAccountType As LtaAccountChangeType, _
            ByVal nAssetAcquisitionDate As Date, ByVal nOperationID As Integer, _
            ByVal nOperationDate As Date, ByVal parentValidator As IChronologicValidator, _
            ByVal DataSource As DataTable)

            FetchItems(DataSource, AssetID)

            _TypeOperation = nOperationType
            _TypeAccount = nAccountType
            _CurrentAssetName = AssetName
            _CurrentOperationName = """" & AssetName & """ - " & ConvertEnumHumanReadable(nOperationType)
            If nOperationType = LtaOperationType.AccountChange Then _CurrentOperationName = _
                _CurrentOperationName & ", " & ConvertEnumHumanReadable(nAccountType)
            _CurrentOperationID = nOperationID
            _CurrentOperationDate = nOperationDate
            _AssetAcquisitionDate = nAssetAcquisitionDate
            _BaseValidator = parentValidator
            If _BaseValidator Is Nothing Then _BaseValidator = SimpleChronologicValidator. _
                GetSimpleChronologicValidator(nOperationID, nOperationDate, _CurrentOperationName)

            FetchLimitations()

        End Sub


        Private Sub FetchItems(ByVal myData As DataTable, ByVal AssetID As Integer)

            RaiseListChangedEvents = False
            IsReadOnly = False

            For Each dr As DataRow In myData.Rows
                If CIntSafe(dr.Item(0), 0) = AssetID Then
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

            SetMinDateApplicable(_AssetAcquisitionDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes tada šis turtas buvo įgytas.", True)

            If _CurrentOperationID > 0 Then

                Select Case _TypeOperation
                    Case LtaOperationType.AccountChange
                        FetchLimitationsForOldAccountChange()
                    Case LtaOperationType.AcquisitionValueIncrease
                        FetchLimitationsForOldValueIncrease()
                    Case LtaOperationType.Amortization
                        FetchLimitationsForOldAmortization()
                    Case LtaOperationType.AmortizationPeriod
                        FetchLimitationsForOldAmortizationPeriod()
                    Case LtaOperationType.Discard
                        FetchLimitationsForOldDiscard()
                    Case LtaOperationType.Transfer
                        FetchLimitationsForOldTransfer()
                    Case LtaOperationType.UsingEnd, LtaOperationType.UsingStart
                        FetchLimitationsForOldUsage()
                    Case LtaOperationType.ValueChange
                        FetchLimitationsForOldValueChange()
                    Case Else
                        Throw New NotImplementedException("Ilgalaikio turto operacijos tipas '" _
                            & _TypeOperation.ToString & "' neimplementuotas metode " _
                            & "OperationChronologicValidator.FetchLimitations .")
                End Select

            Else

                Select Case _TypeOperation
                    Case LtaOperationType.AccountChange
                        FetchLimitationsForNewAccountChange()
                    Case LtaOperationType.AcquisitionValueIncrease
                        FetchLimitationsForNewValueIncrease()
                    Case LtaOperationType.Amortization
                        FetchLimitationsForNewAmortization()
                    Case LtaOperationType.AmortizationPeriod
                        FetchLimitationsForNewAmortizationPeriod()
                    Case LtaOperationType.Discard
                        FetchLimitationsForNewDiscard()
                    Case LtaOperationType.Transfer
                        FetchLimitationsForNewTransfer()
                    Case LtaOperationType.UsingEnd, LtaOperationType.UsingStart
                        FetchLimitationsForNewUsage()
                    Case LtaOperationType.ValueChange
                        FetchLimitationsForNewValueChange()
                    Case Else
                        Throw New NotImplementedException("Ilgalaikio turto operacijos tipas '" _
                            & _TypeOperation.ToString & "' neimplementuotas metode " _
                            & "OperationChronologicValidator.FetchLimitations .")
                End Select

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

                If _BaseValidator.MaxDateApplicable Then SetMaxDateApplicable( _
                    _BaseValidator.MaxDate, _BaseValidator.MaxDateExplanation, False)

                If _BaseValidator.MinDateApplicable Then SetMinDateApplicable( _
                    _BaseValidator.MinDate, _BaseValidator.MinDateExplanation, False)

            End If

            SetLimitsExplanation()

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

        End Sub

        Private Sub SetMaxDateApplicable(ByVal nDate As Date, ByVal nExplanation As String, _
            ByVal AddOneDay As Boolean)

            If nDate = Date.MaxValue OrElse nDate = Date.MinValue Then Exit Sub

            If AddOneDay Then nDate.AddDays(-1)

            If Not nDate.Date < _MaxDate.Date Then Exit Sub

            _MaxDateApplicable = True
            _MaxDate = nDate.Date
            _MaxDateExplanation = nExplanation.Replace(DatePlaceHolder, nDate.ToString("yyyy-MM-dd"))

        End Sub

        Private Sub SetMinDateApplicable(ByVal nDate As Date, ByVal nExplanation As String, _
            ByVal AddOneDay As Boolean)

            If nDate = Date.MaxValue OrElse nDate = Date.MinValue Then Exit Sub

            If AddOneDay Then nDate.AddDays(1)

            If Not nDate.Date > _MinDate.Date Then Exit Sub

            _MinDateApplicable = True
            _MinDate = nDate.Date
            _MinDateExplanation = nExplanation.Replace(DatePlaceHolder, nDate.ToString("yyyy-MM-dd"))

        End Sub

        Private Sub SetFinancialDataCanChange(ByVal nDate As Date, ByVal nExplanation As String, _
            ByVal nDateExplanation As String, ByVal AddOneDay As Boolean)

            If nDate = Date.MaxValue OrElse nDate = Date.MinValue OrElse nExplanation Is Nothing _
                OrElse String.IsNullOrEmpty(nExplanation.Trim) Then Exit Sub

            _FinancialDataCanChange = False
            _FinancialDataCanChangeExplanation = AddWithNewLine(_FinancialDataCanChangeExplanation, _
                nExplanation, False)

            SetMaxDateApplicable(nDate, nDateExplanation, AddOneDay)

        End Sub

        Private Sub SetLimitsExplanation()

            _LimitsExplanation = ""
            If Not _FinancialDataCanChange Then _LimitsExplanation = _FinancialDataCanChangeExplanation
            If _MinDateApplicable Then _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _
                _MinDateExplanation, False)
            If _MaxDateApplicable Then _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _
                 _MaxDateExplanation, False)

        End Sub


        Private Sub FetchLimitationsForNewAccountChange()

            Dim LastSignificantDate As Date = GetMaxDate(OperationChronologyType.Overall, _
                LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
                LtaOperationType.Transfer)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        End Sub

        Private Sub FetchLimitationsForOldAccountChange()

            Dim FirstSignificantDate As Date = GetMinDate(OperationChronologyType.FirstAfter, _
                LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
                LtaOperationType.Transfer)

            SetFinancialDataCanChange(FirstSignificantDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota operacijų su turtu.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota operacijų su turtu.", False)

            Dim LastSignificantDate As Date = GetMaxDate(OperationChronologyType.LastBefore, _
                LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
                LtaOperationType.Transfer)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        End Sub

        Private Sub FetchLimitationsForNewValueIncrease()

            Dim LastSignificantDate As Date = GetMaxDate(OperationChronologyType.Overall, _
                LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
                LtaOperationType.Transfer)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        End Sub

        Private Sub FetchLimitationsForOldValueIncrease()

            If GetMaxDate(OperationChronologyType.FirstAfter, LtaOperationType.Amortization) _
                <> Date.MinValue Then

                SetMinDateApplicable(_CurrentOperationDate, "Operacijos data negali keistis " _
                    & DatePlaceHolder & ", nes po šios operacijos buvo skaičiuota amortizacija.", True)
                SetFinancialDataCanChange(_CurrentOperationDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes nes po šios operacijos buvo skaičiuota amortizacija.", _
                    "Operacijos data negali keistis " & DatePlaceHolder & ", nes po šios operacijos " _
                    & "buvo skaičiuota amortizacija.", False)

                Exit Sub

            End If

            Dim FirstSignificantDate As Date = GetMinDate(OperationChronologyType.FirstAfter, _
                LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.ValueChange, LtaOperationType.Discard, LtaOperationType.Transfer)

            SetFinancialDataCanChange(FirstSignificantDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota operacijų su turtu.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota operacijų su turtu.", False)

            Dim LastSignificantDate As Date = GetMaxDate(OperationChronologyType.LastBefore, _
                LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
                LtaOperationType.Transfer)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        End Sub

        Private Sub FetchLimitationsForNewAmortization()

            Dim LastSignificantDate As Date = GetMaxDate(OperationChronologyType.Overall, _
                LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
                LtaOperationType.Transfer)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        End Sub

        Private Sub FetchLimitationsForOldAmortization()

            If GetMaxDate(OperationChronologyType.FirstAfter, LtaOperationType.Amortization) _
                <> Date.MinValue Then

                SetMinDateApplicable(_CurrentOperationDate, "Operacijos data negali keistis " _
                    & DatePlaceHolder & ", nes po šios operacijos buvo skaičiuota amortizacija.", True)
                SetFinancialDataCanChange(_CurrentOperationDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes nes po šios operacijos buvo skaičiuota amortizacija.", _
                    "Operacijos data negali keistis " & DatePlaceHolder & ", nes po šios operacijos " _
                    & "buvo skaičiuota amortizacija.", False)

                SetLimitsExplanation()

                Exit Sub

            End If

            Dim FirstSignificantDate As Date = GetMinDate(OperationChronologyType.FirstAfter, _
                LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.ValueChange, LtaOperationType.Discard, LtaOperationType.Transfer)

            SetFinancialDataCanChange(FirstSignificantDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota operacijų su turtu.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota operacijų su turtu.", False)

            Dim LastSignificantDate As Date = GetMaxDate(OperationChronologyType.LastBefore, _
                LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.ValueChange, LtaOperationType.Discard, LtaOperationType.Transfer)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        End Sub

        Private Sub FetchLimitationsForNewAmortizationPeriod()

            Dim LastSignificantDate As Date = GetMaxDate(OperationChronologyType.Overall, _
                LtaOperationType.Amortization)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra skaičiuota amortizacija.", True)

        End Sub

        Private Sub FetchLimitationsForOldAmortizationPeriod()

            If GetMaxDate(OperationChronologyType.FirstAfter, LtaOperationType.Amortization) _
                <> Date.MinValue Then

                SetMinDateApplicable(_CurrentOperationDate, "Operacijos data negali keistis " _
                    & DatePlaceHolder & ", nes po šios operacijos buvo skaičiuota amortizacija.", True)
                SetFinancialDataCanChange(_CurrentOperationDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes nes po šios operacijos buvo skaičiuota amortizacija.", _
                    "Operacijos data negali keistis " & DatePlaceHolder & ", nes po šios operacijos " _
                    & "buvo skaičiuota amortizacija.", False)

            Else

                Dim LastSignificantDate As Date = GetMaxDate(OperationChronologyType.Overall, _
                    LtaOperationType.Amortization)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra skaičiuota amortizacija.", True)

            End If

        End Sub

        Private Sub FetchLimitationsForNewDiscard()

            Dim LastSignificantDate As Date = GetMaxDate(OperationChronologyType.Overall, _
                LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
                LtaOperationType.Transfer)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        End Sub

        Private Sub FetchLimitationsForOldDiscard()

            If GetMaxDate(OperationChronologyType.FirstAfter, LtaOperationType.Amortization) _
                <> Date.MinValue Then

                SetMinDateApplicable(_CurrentOperationDate, "Operacijos data negali keistis " _
                    & DatePlaceHolder & ", nes po šios operacijos buvo skaičiuota amortizacija.", True)
                SetFinancialDataCanChange(_CurrentOperationDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes nes po šios operacijos buvo skaičiuota amortizacija.", _
                    "Operacijos data negali keistis " & DatePlaceHolder & ", nes po šios operacijos " _
                    & "buvo skaičiuota amortizacija.", False)

                Exit Sub

            End If

            Dim FirstSignificantDate As Date = GetMinDate(OperationChronologyType.FirstAfter, _
                LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.ValueChange, LtaOperationType.Transfer)

            SetFinancialDataCanChange(FirstSignificantDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota operacijų su turtu.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota operacijų su turtu.", False)

            Dim LastSignificantDate As Date = GetMaxDate(OperationChronologyType.LastBefore, _
                LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.ValueChange, LtaOperationType.Discard, LtaOperationType.Transfer)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        End Sub

        Private Sub FetchLimitationsForNewTransfer()

            Dim LastSignificantDate As Date = GetMaxDate(OperationChronologyType.Overall, _
                LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
                LtaOperationType.Transfer)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        End Sub

        Private Sub FetchLimitationsForOldTransfer()

            If GetMaxDate(OperationChronologyType.FirstAfter, LtaOperationType.Amortization) _
                <> Date.MinValue Then

                SetMinDateApplicable(_CurrentOperationDate, "Operacijos data negali keistis " _
                    & DatePlaceHolder & ", nes po šios operacijos buvo skaičiuota amortizacija.", True)
                SetFinancialDataCanChange(_CurrentOperationDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes nes po šios operacijos buvo skaičiuota amortizacija.", _
                    "Operacijos data negali keistis " & DatePlaceHolder & ", nes po šios operacijos " _
                    & "buvo skaičiuota amortizacija.", False)

                Exit Sub

            End If

            Dim FirstSignificantDate As Date = GetMinDate(OperationChronologyType.FirstAfter, _
                LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.ValueChange, LtaOperationType.Transfer)

            SetFinancialDataCanChange(FirstSignificantDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota operacijų su turtu.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota operacijų su turtu.", False)

            Dim LastSignificantDate As Date = GetMaxDate(OperationChronologyType.LastBefore, _
                LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.ValueChange, LtaOperationType.Discard, LtaOperationType.Transfer)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        End Sub

        Private Sub FetchLimitationsForNewUsage()

            Dim LastSignificantDate As Date = GetMaxDate(OperationChronologyType.Overall, _
                LtaOperationType.Amortization, LtaOperationType.UsingStart, LtaOperationType.UsingEnd)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra skaičiuota amortizacija ir (ar) keistas " _
                & "eksploatacijos statusas.", True)

        End Sub

        Private Sub FetchLimitationsForOldUsage()

            If GetMaxDate(OperationChronologyType.FirstAfter, LtaOperationType.Amortization) _
                <> Date.MinValue Then

                SetMinDateApplicable(_CurrentOperationDate, "Operacijos data negali keistis " _
                    & DatePlaceHolder & ", nes po šios operacijos buvo skaičiuota amortizacija.", True)
                SetFinancialDataCanChange(_CurrentOperationDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes nes po šios operacijos buvo skaičiuota amortizacija.", _
                    "Operacijos data negali keistis " & DatePlaceHolder & ", nes po šios operacijos " _
                    & "buvo skaičiuota amortizacija.", False)

                Exit Sub

            End If

            Dim FirstSignificantDate As Date = GetMinDate(OperationChronologyType.FirstAfter, _
                LtaOperationType.UsingEnd, LtaOperationType.UsingStart)

            SetFinancialDataCanChange(FirstSignificantDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota eksploatacijos statuso keitimas.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruotas eksploatacijos statuso keitimas.", False)

            Dim LastSignificantDate As Date = GetMaxDate(OperationChronologyType.LastBefore, _
                LtaOperationType.Amortization, LtaOperationType.UsingStart, LtaOperationType.UsingEnd)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra skaičiuota amortizacija ir (ar) keistas " _
                & "eksploatacijos statusas.", True)

        End Sub

        Private Sub FetchLimitationsForNewValueChange()

            Dim LastSignificantDate As Date = GetMaxDate(OperationChronologyType.Overall, _
                LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
                LtaOperationType.Transfer)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        End Sub

        Private Sub FetchLimitationsForOldValueChange()

            If GetMaxDate(OperationChronologyType.FirstAfter, LtaOperationType.Amortization) _
                <> Date.MinValue Then

                SetMinDateApplicable(_CurrentOperationDate, "Operacijos data negali keistis " _
                    & DatePlaceHolder & ", nes po šios operacijos buvo skaičiuota amortizacija.", True)
                SetFinancialDataCanChange(_CurrentOperationDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes nes po šios operacijos buvo skaičiuota amortizacija.", _
                    "Operacijos data negali keistis " & DatePlaceHolder & ", nes po šios operacijos " _
                    & "buvo skaičiuota amortizacija.", False)

                Exit Sub

            End If

            Dim FirstSignificantDate As Date = GetMinDate(OperationChronologyType.FirstAfter, _
                LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.ValueChange, LtaOperationType.Discard, LtaOperationType.Transfer)

            SetFinancialDataCanChange(FirstSignificantDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota operacijų su turtu.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota operacijų su turtu.", False)

            Dim LastSignificantDate As Date = GetMaxDate(OperationChronologyType.LastBefore, _
                LtaOperationType.AccountChange, LtaOperationType.AcquisitionValueIncrease, _
                LtaOperationType.Amortization, LtaOperationType.ValueChange, LtaOperationType.Discard, _
                LtaOperationType.Transfer)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota operacijų su turtu.", True)

        End Sub

#End Region

    End Class

End Namespace