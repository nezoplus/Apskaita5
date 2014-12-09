<Serializable()> _
Public Class ComplexChronologicValidator
    Inherits ReadOnlyBase(Of ComplexChronologicValidator)
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
    Private _BaseValidator As IChronologicValidator = Nothing


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

    Public ReadOnly Property BaseValidator() As IChronologicValidator 
        Get
            Return _BaseValidator
        End Get
    End Property


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


    Public Sub MergeNewValidationItem(ByVal newValidationItem As IChronologicValidator)
        AddValidationItem(newValidationItem)
        FetchLimitsExplanation()
    End Sub

    Public Sub ReloadValidationItems(ByVal newOperationID As Integer, ByVal newOperationDate As Date, _
        ByVal newValidationItems As IChronologicValidator())

        _CurrentOperationID = newOperationID
        _CurrentOperationDate = newOperationDate

        ReloadValidationItems(newValidationItems)

    End Sub

    Public Sub ReloadValidationItems(ByVal newValidationItems As IChronologicValidator())

        _FinancialDataCanChange = True
        _MinDateApplicable = False
        _MaxDateApplicable = False
        _MinDate = Date.MinValue
        _MaxDate = Date.MaxValue
        _FinancialDataCanChangeExplanation = ""
        _MinDateExplanation = ""
        _MaxDateExplanation = ""
        _LimitsExplanation = ""
        _BackgroundExplanation = ""
        _ParentFinancialDataCanChange = True
        _ParentFinancialDataCanChangeExplanation = ""

        AddBaseValidator()

        AggregateValidations(newValidationItems)

        FetchLimitsExplanation()

    End Sub


    Protected Overrides Function GetIdValue() As Object
        Return _CurrentOperationID
    End Function

    Public Overrides Function ToString() As String
        Return _CurrentOperationName
    End Function

#End Region

#Region " Factory Methods "


    Friend Shared Function NewComplexChronologicValidator(ByVal nOperationName As String, _
        ByVal parentValidator As IChronologicValidator, ByVal ItemValidators As IChronologicValidator()) _
        As ComplexChronologicValidator
        Return New ComplexChronologicValidator(nOperationName, parentValidator, ItemValidators)
    End Function

    Friend Shared Function GetComplexChronologicValidator(ByVal nOperationID As Integer, _
        ByVal nOperationDate As Date, ByVal nOperationName As String, _
        ByVal parentValidator As IChronologicValidator, ByVal ItemValidators As IChronologicValidator()) _
        As ComplexChronologicValidator
        Return New ComplexChronologicValidator(nOperationID, nOperationDate, nOperationName, _
            parentValidator, ItemValidators)
    End Function

    Friend Shared Function GetComplexChronologicValidator(ByVal journalEntryID As Integer, _
        ByVal ItemValidators As IChronologicValidator()) As ComplexChronologicValidator
        Return New ComplexChronologicValidator(journalEntryID, ItemValidators)
    End Function

    Friend Shared Function GetComplexChronologicValidator(ByVal dr As DataRow, _
        ByVal offset As Integer, ByVal ItemValidators As IChronologicValidator()) As ComplexChronologicValidator
        Return New ComplexChronologicValidator(dr, offset, ItemValidators)
    End Function


    Private Sub New()
        ' require use of factory methods
    End Sub

    Private Sub New(ByVal nOperationName As String, ByVal parentValidator As IChronologicValidator, _
        ByVal ItemValidators As IChronologicValidator())
        Create(nOperationName, parentValidator, ItemValidators)
    End Sub

    Private Sub New(ByVal nOperationID As Integer, ByVal nOperationDate As Date, _
        ByVal nOperationName As String, ByVal parentValidator As IChronologicValidator, _
        ByVal ItemValidators As IChronologicValidator())
        Fetch(nOperationID, nOperationDate, nOperationName, parentValidator, ItemValidators)
    End Sub

    Private Sub New(ByVal journalEntryID As Integer, ByVal ItemValidators As IChronologicValidator())
        Fetch(journalEntryID, ItemValidators)
    End Sub

    Private Sub New(ByVal dr As DataRow, ByVal offset As Integer, ByVal ItemValidators As IChronologicValidator())
        Fetch(dr, offset, ItemValidators)
    End Sub

#End Region

#Region " Data Access "

    Private Sub Create(ByVal nOperationName As String, ByVal parentValidator As IChronologicValidator, _
        ByVal ItemValidators As IChronologicValidator())

        _CurrentOperationID = 0
        _CurrentOperationDate = Today
        _CurrentOperationName = nOperationName

        _BackgroundExplanation = ""
        _FinancialDataCanChangeExplanation = ""

        Dim ValidatorList As List(Of IChronologicValidator)
        If ItemValidators Is Nothing OrElse ItemValidators.Length < 1 Then
            ValidatorList = New List(Of IChronologicValidator)
        Else
            ValidatorList = New List(Of IChronologicValidator)(ItemValidators)
        End If

        _BaseValidator = parentValidator
        AddBaseValidator()

        If ValidatorList.Count > 0 Then AggregateValidations(ValidatorList.ToArray)

        FetchLimitsExplanation()

    End Sub

    Private Sub Fetch(ByVal nOperationID As Integer, ByVal nOperationDate As Date, _
        ByVal nOperationName As String, ByVal parentValidator As IChronologicValidator, _
        ByVal ItemValidators As IChronologicValidator())

        _CurrentOperationID = nOperationID
        _CurrentOperationDate = nOperationDate
        _CurrentOperationName = nOperationName

        Dim ValidatorList As List(Of IChronologicValidator)
        If ItemValidators Is Nothing OrElse ItemValidators.Length < 1 Then
            ValidatorList = New List(Of IChronologicValidator)
        Else
            ValidatorList = New List(Of IChronologicValidator)(ItemValidators)
        End If

        _BaseValidator = parentValidator
        AddBaseValidator()

        If ValidatorList.Count > 0 Then AggregateValidations(ValidatorList.ToArray)

        FetchLimitsExplanation()

    End Sub

    Private Sub Fetch(ByVal journalEntryID As Integer, ByVal ItemValidators As IChronologicValidator())
        Dim parentValidator As SimpleChronologicValidator = _
            SimpleChronologicValidator.GetSimpleChronologicValidator(journalEntryID)
        Fetch(parentValidator.CurrentOperationID, parentValidator.CurrentOperationDate, _
            parentValidator.CurrentOperationName, parentValidator, ItemValidators)
    End Sub

    Private Sub Fetch(ByVal dr As DataRow, ByVal offset As Integer, ByVal ItemValidators As IChronologicValidator())
        Dim parentValidator As SimpleChronologicValidator = _
            SimpleChronologicValidator.GetSimpleChronologicValidator(dr, offset)
        Fetch(parentValidator.CurrentOperationID, parentValidator.CurrentOperationDate, _
            parentValidator.CurrentOperationName, parentValidator, ItemValidators)
    End Sub


    Private Sub AggregateValidations(ByVal ItemValidators As IChronologicValidator())

        If ItemValidators Is Nothing OrElse ItemValidators.Length < 1 Then Exit Sub

        For Each i As IChronologicValidator In ItemValidators
            AddValidationItem(i)
            If _BaseValidator Is Nothing AndAlso TypeOf i Is SimpleChronologicValidator Then _
                _BaseValidator = i
        Next

    End Sub

    Private Sub AddValidationItem(ByVal validation As IChronologicValidator)

        If validation.MinDateApplicable AndAlso validation.MinDate.Date > _MinDate.Date Then
            _MinDateApplicable = True
            _MinDate = validation.MinDate
            _MinDateExplanation = "Ribojanti operacija """ & validation.CurrentOperationName _
                & """: " & validation.MinDateExplanation
        End If

        If validation.MaxDateApplicable AndAlso validation.MaxDate.Date < _MaxDate.Date Then
            _MaxDateApplicable = True
            _MaxDate = validation.MaxDate
            _MaxDateExplanation = "Ribojanti operacija """ & validation.CurrentOperationName _
                & """: " & validation.MaxDateExplanation
        End If

        If Not validation.FinancialDataCanChange Then
            _FinancialDataCanChange = False
            _FinancialDataCanChangeExplanation = AddWithNewLine(_FinancialDataCanChangeExplanation, _
                "Ribojanti operacija """ & validation.CurrentOperationName _
                & """: " & validation.FinancialDataCanChangeExplanation, False)
        End If

        If Not validation.ParentFinancialDataCanChange Then
            _ParentFinancialDataCanChange = False
            _ParentFinancialDataCanChangeExplanation = AddWithNewLine( _
                _ParentFinancialDataCanChangeExplanation, _
                validation.ParentFinancialDataCanChangeExplanation, False)
        End If

        If validation.MinDateApplicable OrElse validation.MaxDateApplicable _
            OrElse Not validation.FinancialDataCanChange Then
            _BackgroundExplanation = AddWithNewLine(_BackgroundExplanation, _
                "Ribojanti operacija """ & validation.CurrentOperationName & """: ", False)
            _BackgroundExplanation = AddWithNewLine(_BackgroundExplanation, _
                validation.FinancialDataCanChangeExplanation, False)
            _BackgroundExplanation = AddWithNewLine(_BackgroundExplanation, _
                validation.MinDateExplanation, False)
            _BackgroundExplanation = AddWithNewLine(_BackgroundExplanation, _
                validation.MaxDateExplanation, False)
            _BackgroundExplanation = _BackgroundExplanation & vbCrLf & vbCrLf
        End If

    End Sub

    Private Sub AddBaseValidator()

        If _BaseValidator Is Nothing Then Exit Sub

        If _BaseValidator.MinDateApplicable AndAlso _BaseValidator.MinDate.Date > _MinDate.Date Then
            _MinDateApplicable = True
            _MinDate = _BaseValidator.MinDate
            _MinDateExplanation = "Visam dokumentui taikomas ribojimas: " & _BaseValidator.MinDateExplanation
        End If

        If _BaseValidator.MaxDateApplicable AndAlso _BaseValidator.MaxDate.Date < _MaxDate.Date Then
            _MaxDateApplicable = True
            _MaxDate = _BaseValidator.MaxDate
            _MaxDateExplanation = "Visam dokumentui taikomas ribojimas: " & _BaseValidator.MaxDateExplanation
        End If

        If Not _BaseValidator.FinancialDataCanChange Then
            _ParentFinancialDataCanChange = False
            _ParentFinancialDataCanChangeExplanation = AddWithNewLine(_FinancialDataCanChangeExplanation, _
                _BaseValidator.FinancialDataCanChangeExplanation, False)
        End If

        If _BaseValidator.MinDateApplicable OrElse _BaseValidator.MaxDateApplicable _
            OrElse Not _BaseValidator.FinancialDataCanChange Then
            _BackgroundExplanation = AddWithNewLine(_BackgroundExplanation, _
                "Visam dokumentui taikomi ribojimai: ", False)
            _BackgroundExplanation = AddWithNewLine(_BackgroundExplanation, _
                _BaseValidator.FinancialDataCanChangeExplanation, False)
            _BackgroundExplanation = AddWithNewLine(_BackgroundExplanation, _
                _BaseValidator.MinDateExplanation, False)
            _BackgroundExplanation = AddWithNewLine(_BackgroundExplanation, _
                _BaseValidator.MaxDateExplanation, False)
            _BackgroundExplanation = _BackgroundExplanation & vbCrLf & vbCrLf
        End If

    End Sub

    Private Sub FetchLimitsExplanation()

        _LimitsExplanation = ""
        If Not _ParentFinancialDataCanChange Then _LimitsExplanation = AddWithNewLine( _
            _LimitsExplanation, "Visam dokumentui taikomas ribojimas: " & vbCrLf & _
            _ParentFinancialDataCanChangeExplanation, False)
        If Not _FinancialDataCanChange Then _LimitsExplanation = AddWithNewLine( _
            _LimitsExplanation, _FinancialDataCanChangeExplanation, False)
        If _MinDateApplicable Then _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _
            _MinDateExplanation, False)
        If _MaxDateApplicable Then _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _
            _MaxDateExplanation, False)

    End Sub

#End Region

End Class