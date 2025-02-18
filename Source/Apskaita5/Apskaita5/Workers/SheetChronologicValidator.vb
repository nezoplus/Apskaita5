﻿Namespace Workers

    ''' <summary>
    ''' Represents an <see cref="IChronologicValidator">IChronologicValidator</see> instance that is used 
    ''' to validate <see cref="WageSheet">WageSheet</see> and <see cref="ImprestSheet">ImprestSheet</see>.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public NotInheritable Class SheetChronologicValidator
        Inherits ReadOnlyBase(Of SimpleChronologicValidator)
        Implements IChronologicValidator

#Region " Business Methods "

        Private Const DatePlaceHolder As String = "<#DATE#>"

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
        Private _ParentFinancialDataCanChange As Boolean = True
        Private _ParentFinancialDataCanChangeExplanation As String = ""


        ''' <summary>
        ''' Gets an ID of the validated object. 
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
        ''' Gets the current date of the validated object 
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
        ''' Gets the human readable name of the validated object. 
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
        ''' Wheather the financial data of the validated object is allowed to be changed.
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
        ''' Wheather there is a minimum allowed date for the validated object.
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
        ''' Wheather there is a maximum allowed date for the validated object.
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
        ''' Gets a minimum allowed date for the validated object.
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
        ''' Gets a maximum allowed date for the validated object.
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
        ''' Gets a human readable explanation of why the financial data of the validated object 
        ''' is NOT allowed to be changed.
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
        ''' for the validated object.
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
        ''' for the validated object.
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
        ''' A human readable explanation of all the applicable business rules restrains.
        ''' </summary>
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
        ''' Wheather the financial data of the validated object is allowed 
        ''' to be changed by it's parent document.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ParentFinancialDataCanChange() As Boolean _
        Implements IChronologicValidator.ParentFinancialDataCanChange
            Get
                Return _ParentFinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable explanation of why the financial data of the validated object 
        ''' is NOT allowed to be changed by its parent document.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ParentFinancialDataCanChangeExplanation() As String _
            Implements IChronologicValidator.ParentFinancialDataCanChangeExplanation
            Get
                Return _ParentFinancialDataCanChangeExplanation
            End Get
        End Property


        Public Function ValidateOperationDate(ByVal operationDate As Date, ByRef errorMessage As String, _
            ByRef errorSeverity As Csla.Validation.RuleSeverity) As Boolean _
            Implements IChronologicValidator.ValidateOperationDate

            If _MinDateApplicable AndAlso operationDate.Date < _MinDate.Date Then
                errorMessage = _MinDateExplanation
                errorSeverity = Validation.RuleSeverity.Error
                Return False
            ElseIf _MaxDateApplicable AndAlso operationDate.Date > _MaxDate.Date Then
                errorMessage = _MaxDateExplanation
                errorSeverity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _CurrentOperationID
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Workers_SheetChronologicValidator_ToString, _
                _CurrentOperationName)
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new SheetChronologicValidator instance for a new sheet.
        ''' </summary>
        ''' <param name="sheetType">a type of the sheet (wage sheet or imprest sheet)</param>
        ''' <param name="sheetYear">a year for which the sheet is created</param>
        ''' <param name="sheetMonth">a month for which the sheet is created</param>
        ''' <remarks></remarks>
        Friend Shared Function NewSheetChronologicValidator(ByVal sheetType As DocumentType, _
            ByVal sheetYear As Integer, ByVal sheetMonth As Integer) As SheetChronologicValidator
            Return New SheetChronologicValidator(sheetType, sheetYear, sheetMonth)
        End Function

        ''' <summary>
        ''' Gets a new SheetChronologicValidator instance for an existing sheet.
        ''' </summary>
        ''' <param name="sheetType">a type of the sheet (wage sheet or imprest sheet)</param>
        ''' <param name="sheetID">an ID of the sheet</param>
        ''' <param name="sheetDate">a date of the sheet</param>
        ''' <param name="sheetYear">a year of the sheet</param>
        ''' <param name="sheetMonth">a month of the sheet</param>
        ''' <param name="parentValidator">an IChronologicValidator instance of
        ''' the parent document (if any)</param>
        ''' <remarks></remarks>
        Friend Shared Function GetSheetChronologicValidator(ByVal sheetType As DocumentType, _
            ByVal sheetID As Integer, ByVal sheetDate As Date, ByVal sheetYear As Integer, _
            ByVal sheetMonth As Integer, ByVal parentValidator As IChronologicValidator) As SheetChronologicValidator
            Return New SheetChronologicValidator(sheetType, sheetID, sheetDate, _
                sheetYear, sheetMonth, parentValidator)
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal sheetType As DocumentType, ByVal sheetYear As Integer, _
            ByVal sheetMonth As Integer)
            Create(sheetType, sheetYear, sheetMonth)
        End Sub

        Private Sub New(ByVal sheetType As DocumentType, ByVal sheetID As Integer, _
            ByVal sheetDate As Date, ByVal sheetYear As Integer, _
            ByVal sheetMonth As Integer, ByVal parentValidator As IChronologicValidator)
            Fetch(sheetType, sheetID, sheetDate, sheetYear, sheetMonth, Nothing)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal sheetType As DocumentType, ByVal sheetYear As Integer, _
            ByVal sheetMonth As Integer)

            SetOperationName(sheetType)
            SetDefaultLimits(sheetYear, sheetMonth)

            Dim validator As SimpleChronologicValidator = _
                SimpleChronologicValidator.NewSimpleChronologicValidator( _
                _CurrentOperationName, Nothing)

            If validator.MinDateApplicable Then
                SetMinDateApplicable(validator.MinDate, validator.MinDateExplanation)
            End If

            SetLimitsExplanation()

        End Sub

        Private Sub Fetch(ByVal sheetType As DocumentType, ByVal sheetID As Integer, _
            ByVal sheetDate As Date, ByVal sheetYear As Integer, _
            ByVal sheetMonth As Integer, ByVal parentValidator As IChronologicValidator)

            SetOperationName(sheetType)

            _CurrentOperationID = sheetID
            _CurrentOperationDate = sheetDate

            SetDefaultLimits(sheetYear, sheetMonth)

            Dim validator As SimpleChronologicValidator = _
                SimpleChronologicValidator.GetSimpleChronologicValidator( _
                sheetID, _CurrentOperationDate, _CurrentOperationName, Nothing)

            If validator.MinDateApplicable Then
                SetMinDateApplicable(validator.MinDate, validator.MinDateExplanation)
            End If
            If validator.MaxDateApplicable Then
                SetMaxDateApplicable(validator.MaxDate, validator.MaxDateExplanation)
            End If
            If Not validator.FinancialDataCanChange Then
                _FinancialDataCanChange = False
                _FinancialDataCanChangeExplanation = validator.FinancialDataCanChangeExplanation
            End If

            If Not parentValidator Is Nothing AndAlso Not parentValidator.FinancialDataCanChange Then
                _ParentFinancialDataCanChange = parentValidator.FinancialDataCanChange
                _ParentFinancialDataCanChangeExplanation = parentValidator.FinancialDataCanChangeExplanation
            End If

            SetLimitsExplanation()

        End Sub


        Friend Shared Sub CheckIfCanDelete(ByVal sheetType As DocumentType, ByVal id As Integer)

            Dim myComm As SQLCommand
            If sheetType = DocumentType.ImprestSheet Then
                myComm = New SQLCommand("CheckIfCanDeleteImprestSheet")
            ElseIf sheetType = DocumentType.WageSheet Then
                myComm = New SQLCommand("CheckIfCanDeleteWageSheet")
            Else
                Throw New NotImplementedException(String.Format( _
                    My.Resources.Common_DocumentTypeNotImplemented, _
                    sheetType.ToString, GetType(SheetChronologicValidator).FullName, _
                    "CheckIfCanDelete"))
            End If

            myComm.AddParam("?SD", id)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then
                    If sheetType = DocumentType.ImprestSheet Then
                        Throw New Exception(String.Format(My.Resources.Common_ObjectNotFound, _
                            My.Resources.Workers_ImprestSheet_TypeName, id.ToString()))
                    ElseIf sheetType = DocumentType.WageSheet Then
                        Throw New Exception(String.Format(My.Resources.Common_ObjectNotFound, _
                            My.Resources.Workers_WageSheet_TypeName, id.ToString()))
                    Else
                        Throw New NotImplementedException(String.Format( _
                            My.Resources.Common_DocumentTypeNotImplemented, _
                            sheetType.ToString, GetType(SheetChronologicValidator).FullName, _
                            "CheckIfCanDelete"))
                    End If
                End If

                Dim dr As DataRow = myData.Rows(0)

                If CDateSafe(dr.Item(0), Date.MaxValue) < GetCurrentCompany.LastClosingDate Then _
                    Throw New Exception(My.Resources.Workers_SheetChronologicValidator_InvalidDeleteAfterClosing)

            End Using

        End Sub


        Private Sub SetMaxDateApplicable(ByVal nDate As Date, ByVal nExplanation As String)

            If nDate = Date.MaxValue OrElse nDate = Date.MinValue Then Exit Sub

            If Not nDate.Date < _MaxDate.Date Then Exit Sub

            _MaxDateApplicable = True
            _MaxDate = nDate.Date
            _MaxDateExplanation = nExplanation.Replace(DatePlaceHolder, nDate.ToString("yyyy-MM-dd"))

        End Sub

        Private Sub SetMinDateApplicable(ByVal nDate As Date, ByVal nExplanation As String)

            If nDate = Date.MaxValue OrElse nDate = Date.MinValue Then Exit Sub

            If Not nDate.Date > _MinDate.Date Then Exit Sub

            _MinDateApplicable = True
            _MinDate = nDate.Date
            _MinDateExplanation = nExplanation.Replace(DatePlaceHolder, nDate.ToString("yyyy-MM-dd"))

        End Sub

        Private Sub SetLimitsExplanation()

            _LimitsExplanation = ""
            If Not _FinancialDataCanChange Then
                _LimitsExplanation = _FinancialDataCanChangeExplanation
            End If
            If _MinDateApplicable Then
                _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MinDateExplanation, False)
            End If
            If _MaxDateApplicable Then
                _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MaxDateExplanation, False)
            End If

        End Sub

        Private Sub SetOperationName(ByVal sheetType As DocumentType)

            If sheetType = DocumentType.WageSheet Then
                _CurrentOperationName = My.Resources.Workers_WageSheet_TypeName
            ElseIf sheetType = DocumentType.ImprestSheet Then
                _CurrentOperationName = My.Resources.Workers_ImprestSheet_TypeName
            Else
                Throw New NotImplementedException(String.Format( _
                    My.Resources.Common_DocumentTypeNotImplemented, _
                    sheetType.ToString, Me.GetType().FullName, "SetOperationName"))
            End If

        End Sub

        Private Sub SetDefaultLimits(ByVal sheetYear As Integer, ByVal sheetMonth As Integer)

            Dim defaultMinDate As Date = New Date(sheetYear, sheetMonth, 1)
            SetMinDateApplicable(defaultMinDate, String.Format( _
                My.Resources.Workers_SheetChronologicValidator_MinDateDefaultExplanation, _
                defaultMinDate.ToString("yyyy-MM-dd")))

            Dim defaultMaxdate As Date = defaultMinDate.AddMonths(1)
            defaultMaxdate = New Date(defaultMaxdate.Year, defaultMaxdate.Month, Date.DaysInMonth(defaultMaxdate.Year, defaultMaxdate.Month))
            SetMaxDateApplicable(defaultMaxdate, String.Format( _
                My.Resources.Workers_SheetChronologicValidator_MinDateDefaultExplanation, _
                defaultMaxdate.ToString("yyyy-MM-dd")))

        End Sub

#End Region

    End Class

End Namespace