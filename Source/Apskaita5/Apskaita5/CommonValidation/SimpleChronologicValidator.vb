﻿''' <summary>
''' Represents an <see cref="IChronologicValidator">IChronologicValidator</see> instance that is used 
''' to validate simple <see cref="General.JournalEntry">JournalEntry</see> based objects 
''' chronologic restrains with regard to <see cref="DocumentType.ClosingEntries">ClosingEntries</see>
''' and <see cref="DocumentType.TransferOfBalance">TransferOfBalance</see> operations.
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Public NotInheritable Class SimpleChronologicValidator
    Inherits ReadOnlyBase(Of SimpleChronologicValidator)
    Implements IChronologicValidator

#Region " Business Methods "

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
    ''' Gets an ID of the validated (parent) object. 
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
    ''' Gets the current date of the validated (parent) object (<see cref="Today">Today</see> for a new object). 
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
    ''' Gets the human readable name of the validated (parent) object. 
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
    ''' Wheather the financial data of the validated (parent) object is allowed to be changed.
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
    ''' Wheather there is a minimum allowed date for the validated (parent) object.
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
    ''' Wheather there is a maximum allowed date for the validated (parent) object.
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
    ''' Gets a minimum allowed date for the validated (parent) object.
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
    ''' Gets a maximum allowed date for the validated (parent) object.
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
    ''' Gets a human readable explanation of why the financial data of the validated (parent) object 
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
    ''' for the validated (parent) object.
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
    ''' for the validated (parent) object.
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
        Return _CurrentOperationName
    End Function

#End Region

#Region " Factory Methods "

    ''' <summary>
    ''' Gets a new SimpleChronologicValidator instance for a new operation (object).
    ''' </summary>
    ''' <param name="operationName">A name of the validated operation (object).</param>
    ''' <param name="parentValidator">A parent document (if any) IChronologicValidator.</param>
    ''' <remarks></remarks>
    Friend Shared Function NewSimpleChronologicValidator(ByVal operationName As String, _
        ByVal parentValidator As IChronologicValidator) As SimpleChronologicValidator
        Return New SimpleChronologicValidator(operationName, parentValidator)
    End Function


    ''' <summary>
    ''' Gets a new SimpleChronologicValidator instance for a new operation (object)
    ''' by it's (encapsulated) journal entry ID.
    ''' </summary>
    ''' <param name="journalEntryID">An ID of the journal entry that is encapsulated
    ''' by the validated operation (object).</param>
    ''' <param name="parentValidator">A parent document (if any) IChronologicValidator.</param>
    ''' <remarks></remarks>
    Friend Shared Function GetSimpleChronologicValidator(ByVal journalEntryID As Integer, _
        ByVal parentValidator As IChronologicValidator) As SimpleChronologicValidator
        Return New SimpleChronologicValidator(journalEntryID, parentValidator)
    End Function

    ''' <summary>
    ''' Gets a new SimpleChronologicValidator instance for an existing operation (object).
    ''' </summary>
    ''' <param name="operationID">An ID of the validated operation (object).</param>
    ''' <param name="operationDate">A date of the validated operation (object).</param>
    ''' <param name="operationName">A name of the validated operation (object).</param>
    ''' <param name="parentValidator">A parent document (if any) IChronologicValidator.</param>
    ''' <remarks></remarks>
    Friend Shared Function GetSimpleChronologicValidator(ByVal operationID As Integer, _
        ByVal operationDate As Date, ByVal operationName As String, _
        ByVal parentValidator As IChronologicValidator) As SimpleChronologicValidator
        Return New SimpleChronologicValidator(operationID, operationDate, operationName, parentValidator)
    End Function

    ''' <summary>
    ''' Gets a new SimpleChronologicValidator instance for an existing operation (object)
    ''' using a closing datasource.
    ''' </summary>
    ''' <param name="closingsDataSource">A datasource of closing entries data
    ''' fetched by the <see cref="GetClosingsDataSource">GetClosingsDataSource</see> method.</param>
    ''' <param name="operationID">An ID of the validated operation (object).</param>
    ''' <param name="operationDate">A date of the validated operation (object).</param>
    ''' <param name="operationName">A name of the validated operation (object).</param>
    ''' <param name="parentValidator">A parent document (if any) IChronologicValidator.</param>
    ''' <remarks></remarks>
    Friend Shared Function GetSimpleChronologicValidator(ByVal closingsDataSource As DataTable, _
        ByVal operationID As Integer, ByVal operationDate As Date, _
        ByVal operationName As String, ByVal parentValidator As IChronologicValidator) As SimpleChronologicValidator
        Return New SimpleChronologicValidator(closingsDataSource, operationID, operationDate, _
            operationName, parentValidator)
    End Function

    ''' <summary>
    ''' Gets a datasource for <see cref="GetSimpleChronologicValidator">GetSimpleChronologicValidator</see>
    ''' method.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Function GetClosingsDataSource() As DataTable
        Dim myComm As New SQLCommand("FetchAllClosings")
        Return myComm.Fetch
    End Function


    Private Sub New()
        ' require use of factory methods
    End Sub


    Private Sub New(ByVal nOperationName As String, ByVal parentValidator As IChronologicValidator)
        Create(nOperationName, parentValidator)
    End Sub

    Private Sub New(ByVal journalEntryID As Integer, ByVal parentValidator As IChronologicValidator)
        Fetch(journalEntryID, parentValidator)
    End Sub

    Private Sub New(ByVal nOperationID As Integer, ByVal nOperationDate As Date, _
        ByVal nOperationName As String, ByVal parentValidator As IChronologicValidator)
        Fetch(nOperationID, nOperationDate, nOperationName, parentValidator)
    End Sub

    Private Sub New(ByVal myData As DataTable, ByVal nOperationID As Integer, _
        ByVal nOperationDate As Date, ByVal nOperationName As String, _
        ByVal parentValidator As IChronologicValidator)
        Fetch(myData, nOperationID, nOperationDate, nOperationName, parentValidator)
    End Sub

#End Region

#Region " Data Access "

    Private Sub Create(ByVal nOperationName As String, ByVal parentValidator As IChronologicValidator)

        _CurrentOperationName = nOperationName

        Dim closingDate As Date = GetCurrentCompany.LastClosingDate

        If closingDate <> Date.MinValue AndAlso closingDate <> Date.MaxValue Then
            _MinDateApplicable = True
            _MinDate = closingDate.AddDays(1)
            _MinDateExplanation = String.Format(My.Resources.SimpleChronologicValidator_MinDateDescription, _
                _MinDate.ToString("yyyy-MM-dd"))
            _LimitsExplanation = _MinDateExplanation
        End If

        If Not parentValidator Is Nothing AndAlso Not parentValidator.FinancialDataCanChange Then

            _ParentFinancialDataCanChange = False
            _ParentFinancialDataCanChangeExplanation = parentValidator.FinancialDataCanChangeExplanation

        End If

    End Sub

    Private Sub Fetch(ByVal journalEntryID As Integer, ByVal parentValidator As IChronologicValidator)

        Dim myComm As New SQLCommand("FetchSimpleChronologicValidator")
        myComm.AddParam("?JD", journalEntryID)

        Using myData As DataTable = myComm.Fetch

            If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                My.Resources.Common_ObjectNotFound, My.Resources.General_JournalEntry_TypeName, _
                journalEntryID))

            Fetch(myData.Rows(0), True, parentValidator)

        End Using

    End Sub

    Private Sub Fetch(ByVal nOperationID As Integer, ByVal nOperationDate As Date, _
        ByVal nOperationName As String, ByVal parentValidator As IChronologicValidator)

        Dim myComm As New SQLCommand("FetchSimpleChronologicValidatorByDate")
        myComm.AddParam("?DT", nOperationDate)

        Using myData As DataTable = myComm.Fetch

            _CurrentOperationID = nOperationID
            _CurrentOperationDate = nOperationDate
            _CurrentOperationName = nOperationName

            If myData.Rows.Count < 1 Then Exit Sub

            Fetch(myData.Rows(0), False, parentValidator)

        End Using

    End Sub

    Private Sub Fetch(ByVal dr As DataRow, ByVal fetchGeneralData As Boolean, _
        ByVal parentValidator As IChronologicValidator)

        Dim curType As DocumentType = DocumentType.None

        If fetchGeneralData Then

            _CurrentOperationID = CIntSafe(dr.Item(0), 0)
            _CurrentOperationDate = CDateSafe(dr.Item(1), Today)
            curType = Utilities.ConvertDatabaseCharID(Of DocumentType)(CStrSafe(dr.Item(3)))
            _CurrentOperationName = Utilities.ConvertLocalizedName( _
                Utilities.ConvertDatabaseCharID(Of DocumentType)(CStrSafe(dr.Item(3))))

        End If

        Dim lastClosing As Date = CDateSafe(dr.Item(4), Date.MinValue)
        Dim transferDate As Date = CDateSafe(dr.Item(6), Date.MinValue)

        If lastClosing <> Date.MinValue Then

            _MinDateApplicable = True
            _MinDate = lastClosing.AddDays(1)
            _MinDateExplanation = String.Format(My.Resources.SimpleChronologicValidator_MinDateDescription, _
                _MinDate.ToString("yyyy-MM-dd"))

        End If

        If curType <> DocumentType.TransferOfBalance AndAlso transferDate <> Date.MinValue _
            AndAlso transferDate > _MinDate Then

            _MinDateApplicable = True
            _MinDate = transferDate
            _MinDateExplanation = String.Format(My.Resources.SimpleChronologicValidator_MinDateDescriptionForClosing, _
                _MinDate.ToString("yyyy-MM-dd"))

        End If

        _MaxDate = CDateSafe(dr.Item(5), Date.MaxValue)

        If _MaxDate <> Date.MaxValue Then

            _MaxDateApplicable = True
            _MaxDateExplanation = String.Format(My.Resources.SimpleChronologicValidator_MaxDateDescription, _
                _MaxDate.ToString("yyyy-MM-dd"))

            _FinancialDataCanChange = False
            _FinancialDataCanChangeExplanation = My.Resources.SimpleChronologicValidator_FinancialDataCanChangeDescription

        End If

        _LimitsExplanation = ""
        _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _FinancialDataCanChangeExplanation, False)
        _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MinDateExplanation, False)
        _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MaxDateExplanation, False)

        If Not parentValidator Is Nothing AndAlso Not parentValidator.FinancialDataCanChange Then

            _ParentFinancialDataCanChange = False
            _ParentFinancialDataCanChangeExplanation = parentValidator.FinancialDataCanChangeExplanation

        End If

    End Sub

    Private Sub Fetch(ByVal myData As DataTable, ByVal nOperationID As Integer, _
        ByVal nOperationDate As Date, ByVal nOperationName As String, _
        ByVal parentValidator As IChronologicValidator)

        _CurrentOperationID = nOperationID
        _CurrentOperationDate = nOperationDate
        _CurrentOperationName = nOperationName

        Dim firstBefore As Date = Date.MinValue
        Dim firstBeforeType As DocumentType = DocumentType.ClosingEntries
        Dim firstAfter As Date = Date.MinValue
        Dim firstAfterType As DocumentType = DocumentType.ClosingEntries

        For i As Integer = 1 To myData.Rows.Count

            If CDateSafe(myData.Rows(i - 1).Item(1), Date.MinValue).Date > nOperationDate.Date Then

                firstAfter = CDateSafe(myData.Rows(i - 1).Item(1), Date.MinValue).Date
                firstAfterType = Utilities.ConvertDatabaseCharID(Of DocumentType) _
                    (CStrSafe(myData.Rows(i - 1).Item(0)))

                If i > 1 Then
                    firstBefore = CDateSafe(myData.Rows(i - 2).Item(1), Date.MinValue).Date
                    firstBeforeType = Utilities.ConvertDatabaseCharID(Of DocumentType) _
                        (CStrSafe(myData.Rows(i - 2).Item(0)))
                End If

                Exit For

            End If

        Next

        If firstAfter = Date.MinValue AndAlso myData.Rows.Count > 0 Then

            firstBefore = CDateSafe(myData.Rows(myData.Rows.Count - 1).Item(1), Date.MinValue).Date
            firstBeforeType = Utilities.ConvertDatabaseCharID(Of DocumentType) _
                (CStrSafe(myData.Rows(myData.Rows.Count - 1).Item(0)))

        End If

        If firstBefore > Date.MinValue Then

            _MinDateApplicable = True
            If firstBeforeType = DocumentType.ClosingEntries Then
                _MinDate = firstBefore.Date.AddDays(1)
            Else
                _MinDate = firstBefore.Date
            End If
            _MinDateExplanation = String.Format(My.Resources.SimpleChronologicValidator_MinDateDescription, _
                _MinDate.ToString("yyyy-MM-dd"))

        End If

        If firstAfter > Date.MinValue AndAlso firstAfterType = DocumentType.ClosingEntries Then

            _MaxDateApplicable = True
            _MaxDate = firstAfter.Date
            _MaxDateExplanation = String.Format(My.Resources.SimpleChronologicValidator_MaxDateDescription, _
                _MaxDate.ToString("yyyy-MM-dd"))

            _FinancialDataCanChange = False
            _FinancialDataCanChangeExplanation = My.Resources.SimpleChronologicValidator_FinancialDataCanChangeDescription

        End If

        _LimitsExplanation = ""
        _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _FinancialDataCanChangeExplanation, False)
        _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MinDateExplanation, False)
        _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MaxDateExplanation, False)

        If Not parentValidator Is Nothing AndAlso Not parentValidator.FinancialDataCanChange Then

            _ParentFinancialDataCanChange = False
            _ParentFinancialDataCanChangeExplanation = parentValidator.FinancialDataCanChangeExplanation

        End If

    End Sub

#End Region

End Class