Namespace HelperLists

    ''' <summary>
    ''' Represents a <see cref="General.TemplateJournalEntry">journal entry template</see> value object.
    ''' </summary>
    ''' <remarks>Values are stored in the database tables tipines_op (general data) and tipines_data (details).</remarks>
    <Serializable()> _
    Public Class TemplateJournalEntryInfo
        Inherits ReadOnlyBase(Of TemplateJournalEntryInfo)
        Implements IValueObjectIsEmpty

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _Name As String = ""
        Private _Content As String = ""
        Private _DebetList As Long() = Nothing
        Private _CreditList As Long() = Nothing
        Private _DebetListString As String = ""
        Private _CreditListString As String = ""
        Private _CorespondationListString As String = ""


        ''' <summary>
        ''' Whether an object is a place holder (does not represent a real template).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IsEmpty() As Boolean _
            Implements IValueObjectIsEmpty.IsEmpty
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ID > 0
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID of the TemplateJournalEntry object (assigned by DB AUTO_INCREMENT).
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.TemplateJournalEntry.ID">TemplateJournalEntry.ID</see> property.
        ''' Value is stored in the database field tipines_op.T_ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets the name of the template. Usualy it is shown in drop down controls.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.TemplateJournalEntry.Name">TemplateJournalEntry.Name</see> property.
        ''' Value is stored in the database field tipines_op.Turinys.</remarks>
        Public ReadOnly Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets the template (default text) for the JournalEntry property <see cref="General.JournalEntry.Content">Content</see>.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.TemplateJournalEntry.Content">TemplateJournalEntry.Content</see> property.
        ''' Value is stored in the database field tipines_op.Pavadinimas.</remarks>
        Public ReadOnly Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a list of debited accounts <see cref="General.Account.ID">ID</see>.
        ''' </summary>
        ''' <remarks>Values are stored in the database table tipines_data.</remarks>
        Public ReadOnly Property DebetList() As Long()
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DebetList
            End Get
        End Property

        ''' <summary>
        ''' Gets a list of credited accounts <see cref="General.Account.ID">ID</see>.
        ''' </summary>
        ''' <remarks>Values are stored in the database table tipines_data.</remarks>
        Public ReadOnly Property CreditList() As Long()
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CreditList
            End Get
        End Property

        ''' <summary>
        ''' Gets a comma delimited list of debited accounts <see cref="General.Account.ID">ID</see>.
        ''' </summary>
        ''' <remarks>Values are stored in the database table tipines_data.</remarks>
        Public ReadOnly Property DebetListString() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DebetListString.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a comma delimited list of credited accounts <see cref="General.Account.ID">ID</see>.
        ''' </summary>
        ''' <remarks>Values are stored in the database table tipines_data.</remarks>
        Public ReadOnly Property CreditListString() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CreditListString.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a desciption of template book entries within the template.
        ''' </summary>
        ''' <remarks>Values are stored in the database table tipines_data.</remarks>
        Public ReadOnly Property CorespondationListString() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CorespondationListString.Trim
            End Get
        End Property


        Public ReadOnly Property GetMe() As TemplateJournalEntryInfo
            Get
                Return Me
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            If Not _ID > 0 Then Return ""
            Return _Name.Trim
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets an existing template info by a database query.
        ''' </summary>
        ''' <param name="dr">DataRow containing account data.</param>
        Friend Shared Function GetTemplateJournalEntryInfo(ByVal dr As DataRow) As TemplateJournalEntryInfo
            Return New TemplateJournalEntryInfo(dr)
        End Function

        ''' <summary>
        ''' Gets an empty template info (placeholder).
        ''' </summary>
        Friend Shared Function GetEmptyTemplateJournalEntryInfo() As TemplateJournalEntryInfo
            Return New TemplateJournalEntryInfo()
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal dr As DataRow)
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow)

            _ID = CIntSafe(dr.item(0), 0)
            _Name = CStrSafe(dr.Item(1)).Trim
            _Content = CStrSafe(dr.Item(2)).Trim

            Dim Corespondations As String() = CStrSafe(dr.Item(3)).Trim.Split( _
                New Char() {","c}, StringSplitOptions.RemoveEmptyEntries)

            Dim DebetList As New List(Of String)
            Dim CreditList As New List(Of String)

            For Each s As String In Corespondations
                If s.Trim.ToLower.StartsWith(EnumValueAttribute.ConvertDatabaseCharID(BookEntryType.Debetas).ToLower) Then
                    DebetList.Add(s.Trim.ToLower.Replace(EnumValueAttribute.ConvertDatabaseCharID( _
                        BookEntryType.Debetas).ToLower, ""))
                ElseIf s.Trim.ToLower.StartsWith(EnumValueAttribute.ConvertDatabaseCharID(BookEntryType.Kreditas).ToLower) Then
                    CreditList.Add(s.Trim.ToLower.Replace(EnumValueAttribute.ConvertDatabaseCharID( _
                        BookEntryType.Kreditas).ToLower, ""))
                End If
            Next

            Dim DebetListLng As New List(Of Long)
            Dim CreditListLng As New List(Of Long)
            Dim currentAccountID As Long

            For i As Integer = DebetList.Count To 1 Step -1
                If Long.TryParse(DebetList(i - 1), currentAccountID) Then
                    DebetListLng.Add(currentAccountID)
                Else
                    DebetList.RemoveAt(i - 1)
                End If
            Next
            For i As Integer = CreditList.Count To 1 Step -1
                If Not Long.TryParse(CreditList(i - 1), New Long) Then CreditList.RemoveAt(i - 1)
                If Long.TryParse(CreditList(i - 1), currentAccountID) Then
                    CreditListLng.Add(currentAccountID)
                Else
                    CreditList.RemoveAt(i - 1)
                End If
            Next

            _DebetList = DebetListLng.ToArray
            _CreditList = CreditListLng.ToArray
            _DebetListString = String.Join(",", DebetList.ToArray)
            _CreditListString = String.Join(",", CreditList.ToArray)

            For i As Integer = DebetList.Count To 1 Step -1
                DebetList(i - 1) = My.Resources.General_BookEntryList_CharForDebit & DebetList(i - 1)
            Next
            For i As Integer = CreditList.Count To 1 Step -1
                CreditList(i - 1) = My.Resources.General_BookEntryList_CharForCredit & CreditList(i - 1)
            Next

            DebetList.AddRange(CreditList)

            _CorespondationListString = String.Join(", ", DebetList.ToArray)

        End Sub

#End Region

    End Class

End Namespace