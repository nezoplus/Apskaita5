Namespace HelperLists

    <Serializable()> _
    Public Class IndirectRelationInfoList
        Inherits ReadOnlyListBase(Of IndirectRelationInfoList, IndirectRelationInfo)

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _Date As Date = Today
        Private _DocNumber As String = ""
        Private _Content As String = ""
        Private _PersonName As String = ""
        Private _PersonCode As String = ""
        Private _DocType As DocumentType = DocumentType.None
        Private _DocTypeHumanReadable As String = ""
        Private _Sum As Double = 0
        Private _CorrespondingAccounts As String = ""
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now

        ''' <summary>
        ''' Gets an ID of the JournalEntry object (assigned by DB AUTO_INCREMENT).
        ''' </summary>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets a date of the Journal Entry.
        ''' </summary>
        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        ''' <summary>
        ''' Gets a number of the document associated with the Journal Entry.
        ''' </summary>
        Public ReadOnly Property DocNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocNumber.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a content/description of the the Journal Entry.
        ''' </summary>
        Public ReadOnly Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a name of the person associated with the Journal Entry.
        ''' </summary>
        Public ReadOnly Property PersonName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonName
            End Get
        End Property

        ''' <summary>
        ''' Gets a code of the person associated with the Journal Entry.
        ''' </summary>
        Public ReadOnly Property PersonCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonCode
            End Get
        End Property

        ''' <summary>
        ''' Gets a DocumentType of the document associated with the Journal Entry (as enum).
        ''' </summary>
        Public ReadOnly Property DocType() As DocumentType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocType
            End Get
        End Property

        ''' <summary>
        ''' Gets a DocumentType of the document associated with the Journal Entry 
        ''' (as human readable string).
        ''' </summary>
        Public ReadOnly Property DocTypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocTypeHumanReadable.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a total sum of ammounts/values of all the BookEntryList in the JuornalEntry. 
        ''' </summary>
        Public ReadOnly Property Sum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Sum)
            End Get
        End Property

        ''' <summary>
        ''' Gets a list of the book entries' accounts of the Journal Entry 
        ''' </summary>
        Public ReadOnly Property CorrespondingAccounts() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CorrespondingAccounts.Trim
            End Get
        End Property


        Friend Shared Sub CheckIfJournalEntryCanBeDeleted(ByVal JournalEntryID As Integer, _
            ByVal ParamArray ExpectedTypes As DocumentType())

            Dim list As IndirectRelationInfoList = IndirectRelationInfoList. _
                GetIndirectRelationInfoListServerSide(JournalEntryID)
            list.CheckIfJournalEntryCanBeDeleted(ExpectedTypes)

        End Sub

        Friend Sub CheckIfJournalEntryCanBeDeleted(ByVal ExpectedTypes As DocumentType())

            If Not ExpectedTypes Is Nothing AndAlso ExpectedTypes.Length > 0 AndAlso _
                Array.IndexOf(ExpectedTypes, _DocType) < 0 Then Throw New Exception( _
                "Klaida. Bendrojo žurnalo įrašo dokumento tipas - " & _DocTypeHumanReadable _
                & " - neatitinka norimo trinti dokumento tipo - " & ConvertEnumHumanReadable( _
                ExpectedTypes(0)) & ".")

            If Me.Count > 0 Then Throw New Exception("Klaida. " _
                & "Bendrojo žurnalo įrašas turi netiesiogiai susietų operacijų: " _
                & vbCrLf & Me.ToString)

            If GetCurrentCompany.LastClosingDate = Date.MinValue Then Exit Sub

            If _DocType = DocumentType.ClosingEntries AndAlso _
                _Date.Date = GetCurrentCompany.LastClosingDate.Date Then Exit Sub

            If _DocType = DocumentType.TransferOfBalance Then Throw New Exception( _
                "Klaida. Apskaitoje " & GetCurrentCompany.LastClosingDate.ToShortDateString _
                & " yra registruota 5/6 klasių uždarymo operacija. Likučių perkėlimo " _
                & "negalima pašalinti, kai egzistuoja bent vienas uždarymas.")

            If _Date.Date <= GetCurrentCompany.LastClosingDate.Date Then _
                Throw New Exception("Klaida. Operacijos data yra ankstesnė " _
                & "nei paskutinio 5/6 klasių uždarymo arba likučių perkėlimo data.")

        End Sub

        Public Overrides Function ToString() As String
            Dim result As String = ""
            For Each i As IndirectRelationInfo In Me
                result = AddWithNewLine(result, i.ToString, False)
            Next
            Return result
        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.IndirectRelationInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetIndirectRelationInfoList(ByVal JournalEntryID As Integer) As IndirectRelationInfoList
            Return DataPortal.Fetch(Of IndirectRelationInfoList)(New Criteria(JournalEntryID))
        End Function

        Friend Shared Function GetIndirectRelationInfoListServerSide(ByVal JournalEntryID As Integer) As IndirectRelationInfoList
            Dim result As New IndirectRelationInfoList
            result.DataPortal_Fetch(New Criteria(JournalEntryID))
            Return result
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _ID As Integer
            Public ReadOnly Property ID() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public Sub New(ByVal nID As Integer)
                _ID = nID
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            Dim myComm As New SQLCommand("FetchIndirectRelationInfoGeneral")
            myComm.AddParam("?JD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception("Klaida. Bendrojo žurnalo " _
                    & "įrašo, kurio ID=" & criteria.ID.ToString & ", duomenys nerasti " _
                    & "duomenų bazėje.")

                Dim dr As DataRow = myData.Rows(0)

                _ID = criteria.ID
                _Date = CDateSafe(dr.Item(0), Today)
                _DocNumber = CStrSafe(dr.Item(1)).Trim
                _Content = CStrSafe(dr.Item(2)).Trim
                _DocType = ConvertEnumDatabaseStringCode(Of DocumentType)(CStrSafe(dr.Item(3)).Trim)
                _DocTypeHumanReadable = ConvertEnumHumanReadable(_DocType)
                _InsertDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(4), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime
                _UpdateDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(5), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime
                _PersonName = CStrSafe(dr.Item(6)).Trim
                _PersonCode = CStrSafe(dr.Item(7)).Trim
                _CorrespondingAccounts = CStrSafe(dr.Item(8)).Trim
                _Sum = CDblSafe(dr.Item(9), 2, 0)

            End Using

            myComm = New SQLCommand("FetchIndirectRelationInfoList")
            myComm.AddParam("?JD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                For Each dr As DataRow In myData.Rows
                    Add(IndirectRelationInfo.GetIndirectRelationInfo(dr))
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace