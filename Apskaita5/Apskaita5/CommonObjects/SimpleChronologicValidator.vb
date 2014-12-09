<Serializable()> _
Public Class SimpleChronologicValidator
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
            Return _FinancialDataCanChange
        End Get
    End Property

    Public ReadOnly Property ParentFinancialDataCanChangeExplanation() As String _
        Implements IChronologicValidator.ParentFinancialDataCanChangeExplanation
        Get
            Return _FinancialDataCanChangeExplanation
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


    Protected Overrides Function GetIdValue() As Object
        Return _CurrentOperationID
    End Function

    Public Overrides Function ToString() As String
        Return _CurrentOperationName
    End Function

#End Region

#Region " Factory Methods "

    Friend Shared Function NewSimpleChronologicValidator(ByVal nOperationName As String) As SimpleChronologicValidator
        Return New SimpleChronologicValidator(nOperationName)
    End Function

    Friend Shared Function GetSimpleChronologicValidator(ByVal dr As DataRow, _
        ByVal offset As Integer) As SimpleChronologicValidator
        Return New SimpleChronologicValidator(dr, offset)
    End Function

    Friend Shared Function GetSimpleChronologicValidator(ByVal JournalEntryID As Integer) As SimpleChronologicValidator
        Return New SimpleChronologicValidator(JournalEntryID)
    End Function

    Friend Shared Function GetSimpleChronologicValidator(ByVal nOperationID As Integer, _
        ByVal nOperationDate As Date, ByVal nOperationName As String) As SimpleChronologicValidator
        Return New SimpleChronologicValidator(nOperationID, nOperationDate, nOperationName)
    End Function

    Friend Shared Function GetSimpleChronologicValidator(ByVal closingsDataSource As DataTable, _
        ByVal nOperationID As Integer, ByVal nOperationDate As Date, _
        ByVal nOperationName As String) As SimpleChronologicValidator
        Return New SimpleChronologicValidator(closingsDataSource, nOperationID, nOperationDate, nOperationName)
    End Function

    Friend Shared Function GetClosingsDataSource() As DataTable
        Dim myComm As New SQLCommand("FetchAllClosings")
        Return myComm.Fetch
    End Function


    Private Sub New()
        ' require use of factory methods
    End Sub


    Private Sub New(ByVal nOperationName As String)
        Create(nOperationName)
    End Sub

    Private Sub New(ByVal dr As DataRow, ByVal offset As Integer)
        Fetch(dr, offset, True)
    End Sub

    Private Sub New(ByVal JournalEntryID As Integer)
        Fetch(JournalEntryID)
    End Sub

    Private Sub New(ByVal nOperationID As Integer, ByVal nOperationDate As Date, ByVal nOperationName As String)
        Fetch(nOperationID, nOperationDate, nOperationName)
    End Sub

    Private Sub New(ByVal myData As DataTable, ByVal nOperationID As Integer, _
        ByVal nOperationDate As Date, ByVal nOperationName As String)
        Fetch(myData, nOperationID, nOperationDate, nOperationName)
    End Sub

#End Region

#Region " Data Access "

    Private Sub Create(ByVal nOperationName As String)

        _CurrentOperationName = nOperationName

        Dim closingDate As Date = GetCurrentCompany.LastClosingDate

        If closingDate <> Date.MinValue AndAlso closingDate <> Date.MaxValue Then
            _MinDateApplicable = True
            _MinDate = closingDate.AddDays(1)
            _MinDateExplanation = "Operacijos data negali būti ankstesnė nei " _
                & _MinDate.ToString("yyyy-MM-dd") & ", nes prieš tai yra registruota " _
                & "likučių perkėlimo ir (ar) 5/6 klasių uždarymo operacija."
            _LimitsExplanation = _MinDateExplanation
        End If

    End Sub

    Private Sub Fetch(ByVal JournalEntryID As Integer)

        Dim myComm As New SQLCommand("FetchSimpleChronologicValidator")
        myComm.AddParam("?JD", JournalEntryID)

        Using myData As DataTable = myComm.Fetch

            If myData.Rows.Count < 1 Then Throw New Exception("Klaida. Operacija, kurios BŽ ID=" _
                & JournalEntryID & ", nerasta.")

            Fetch(myData.Rows(0), 0, True)

        End Using

    End Sub

    Private Sub Fetch(ByVal nOperationID As Integer, ByVal nOperationDate As Date, ByVal nOperationName As String)

        Dim myComm As New SQLCommand("FetchSimpleChronologicValidatorByDate")
        myComm.AddParam("?DT", nOperationDate)

        Using myData As DataTable = myComm.Fetch

            _CurrentOperationID = nOperationID
            _CurrentOperationDate = nOperationDate
            _CurrentOperationName = nOperationName

            If myData.Rows.Count < 1 Then Exit Sub

            Fetch(myData.Rows(0), 0, False)

        End Using

    End Sub

    Private Sub Fetch(ByVal dr As DataRow, ByVal offset As Integer, ByVal fetchGeneralData As Boolean)

        If fetchGeneralData Then

            _CurrentOperationID = CIntSafe(dr.Item(0), 0)
            _CurrentOperationDate = CDateSafe(dr.Item(1), Today)
            _CurrentOperationName = _CurrentOperationDate.ToString("yyyy-MM-dd") _
                & " Tipas - " & ConvertEnumHumanReadable(ConvertEnumDatabaseStringCode(Of DocumentType) _
                (CStrSafe(dr.Item(3)))) & ", Dok. Nr. " & CStrSafe(dr.Item(2))

        End If

        Dim lastClosing As Date = CDateSafe(dr.Item(4), Date.MinValue)
        Dim transferDate As Date = CDateSafe(dr.Item(6), Date.MinValue)

        If lastClosing <> Date.MinValue OrElse transferDate <> Date.MinValue Then

            _MinDateApplicable = True

            If lastClosing > transferDate Then
                _MinDate = lastClosing.AddDays(1)
            Else
                _MinDate = transferDate
            End If

            _MinDateExplanation = "Data negali būti ankstesnė nei " & _MinDate.ToString("yyyy-MM-dd") _
                & " nes ankstesne data yra registruota 5/6 klasių uždarymo ir (ar) likučių perkėlimo operacija."

        End If

        _MaxDate = CDateSafe(dr.Item(5), Date.MaxValue)

        If _MaxDate <> Date.MaxValue Then

            _MaxDateApplicable = True
            _MaxDateExplanation = "Data negali būti vėlesnė nei " & _MaxDate.ToString("yyyy-MM-dd") _
                & " nes vėlesne data yra registruota 5/6 klasių uždarymo ir (ar) likučių perkėlimo operacija."

            _FinancialDataCanChange = False
            _FinancialDataCanChangeExplanation = "Finansiniai operacijos duomenys negali būti keičiami, " _
                & "nes vėlesne data yra registruota 5/6 klasių uždarymo ir (ar) likučių perkėlimo operacija."

        End If

        _LimitsExplanation = ""
        _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _FinancialDataCanChangeExplanation, False)
        _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MinDateExplanation, False)
        _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MaxDateExplanation, False)

    End Sub

    Private Sub Fetch(ByVal myData As DataTable, ByVal nOperationID As Integer, _
        ByVal nOperationDate As Date, ByVal nOperationName As String)

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
                firstAfterType = ConvertEnumDatabaseStringCode(Of DocumentType) _
                    (CStrSafe(myData.Rows(i - 1).Item(0)))

                If i > 1 Then
                    firstBefore = CDateSafe(myData.Rows(i - 2).Item(1), Date.MinValue).Date
                    firstBeforeType = ConvertEnumDatabaseStringCode(Of DocumentType) _
                        (CStrSafe(myData.Rows(i - 2).Item(0)))
                End If

                Exit For

            End If

        Next

        If firstAfter = Date.MinValue AndAlso myData.Rows.Count > 0 Then

            firstBefore = CDateSafe(myData.Rows(myData.Rows.Count - 1).Item(1), Date.MinValue).Date
            firstBeforeType = ConvertEnumDatabaseStringCode(Of DocumentType) _
                (CStrSafe(myData.Rows(myData.Rows.Count - 1).Item(0)))

        End If

        If firstBefore > Date.MinValue Then

            _MinDateApplicable = True
            If firstBeforeType = DocumentType.ClosingEntries Then
                _MinDate = firstBefore.Date.AddDays(1)
            Else
                _MinDate = firstBefore.Date
            End If
            _MinDateExplanation = "Data negali būti ankstesnė nei " & _MinDate.ToString("yyyy-MM-dd") _
                & ", nes ankstesne data yra registruota 5/6 klasių uždarymo ir (ar) likučių perkėlimo operacija."

        End If

        If firstAfter > Date.MinValue AndAlso firstAfterType = DocumentType.ClosingEntries Then

            _MaxDateApplicable = True
            _MaxDate = firstAfter.Date
            _MaxDateExplanation = "Data negali būti vėlesnė nei " & _MaxDate.ToString("yyyy-MM-dd") _
                & " nes vėlesne data yra registruota 5/6 klasių uždarymo ir (ar) likučių perkėlimo operacija."

            _FinancialDataCanChange = False
            _FinancialDataCanChangeExplanation = "Finansiniai operacijos duomenys negali būti keičiami, " _
                & "nes vėlesne data yra registruota 5/6 klasių uždarymo ir (ar) likučių perkėlimo operacija."

        End If

        _LimitsExplanation = ""
        _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _FinancialDataCanChangeExplanation, False)
        _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MinDateExplanation, False)
        _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MaxDateExplanation, False)

    End Sub

#End Region

End Class