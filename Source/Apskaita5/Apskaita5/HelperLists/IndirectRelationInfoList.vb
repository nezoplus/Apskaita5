﻿Namespace HelperLists

    ''' <summary>
    ''' Represents information about a <see cref="General.JournalEntry">JournalEntry</see>
    ''' and the documents that reference the JournalEntry. (when a journal entry is attached 
    ''' to some document, not created and managed by the document)
    ''' </summary>
    ''' <remarks>Used to check if a journal entry could be deleted, 
    ''' i.e. there is no documents that reference the JournalEntry.</remarks>
    <Serializable()> _
    Public NotInheritable Class IndirectRelationInfoList
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
        ''' <remarks>Value is stored in the database field bz.Op_ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the JournalEntry was inserted into the database.
        ''' </summary>
        ''' <remarks>Value is stored in the database field bz.InsertDate.</remarks>
        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the JournalEntry was last updated.
        ''' </summary>
        ''' <remarks>Value is stored in the database field bz.UpdateDate.</remarks>
        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets a date of the Journal Entry.
        ''' </summary>
        ''' <remarks>Value is stored in the database field bz.Op_data.</remarks>
        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        ''' <summary>
        ''' Gets a number of the document associated with the Journal Entry.
        ''' </summary>
        ''' <remarks>Value is stored in the database field bz.Op_Dok.</remarks>
        Public ReadOnly Property DocNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocNumber.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a content/description of the the Journal Entry.
        ''' </summary>
        ''' <remarks>Value is stored in the database field bz.Op_turinys.</remarks>
        Public ReadOnly Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a name of the person associated with the Journal Entry.
        ''' </summary>
        ''' <remarks>Use <see cref="HelperLists.PersonInfoList">PersonInfoList</see> for the datasource.
        ''' Value is stored in the database field bz.Op_analitika.</remarks>
        Public ReadOnly Property PersonName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonName
            End Get
        End Property

        ''' <summary>
        ''' Gets a company/personal code of the person associated with the Journal Entry.
        ''' </summary>
        ''' <remarks>Use <see cref="HelperLists.PersonInfoList">PersonInfoList</see> for the datasource.
        ''' Value is stored in the database field bz.Op_analitika.</remarks>
        Public ReadOnly Property PersonCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonCode
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="DocumentType">DocumentType</see> of the document associated with the Journal Entry (as enum).
        ''' </summary>
        ''' <remarks>Value is stored in the database field bz.Op_dok_rusis.</remarks>
        Public ReadOnly Property DocType() As DocumentType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocType
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="DocumentType">DocumentType</see> of the document associated 
        ''' with the Journal Entry as a localized human readable string.
        ''' </summary>
        ''' <remarks>Value is stored in the database field bz.Op_dok_rusis.</remarks>
        Public ReadOnly Property DocTypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocTypeHumanReadable.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a total sum of book entries in the JournalEntry. 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Sum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Sum)
            End Get
        End Property

        ''' <summary>
        ''' Gets a list of the book entries' accounts of the Journal Entry 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CorrespondingAccounts() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CorrespondingAccounts.Trim
            End Get
        End Property



        ''' <summary>
        ''' Checks if a journal entry could be deleted, 
        ''' i.e. there is no documents that reference the JournalEntry.
        ''' Throws an exception if the journal entry could not be deleted
        ''' or if the <see cref="DocType">document type</see> does not match the 
        ''' <paramref name="expectedTypes">expectedTypes</paramref>.
        ''' </summary>
        ''' <param name="journalEntryID">an ID of the journal entry to check</param>
        ''' <param name="expectedTypes">an expected <see cref="DocType">document type</see>.</param>
        ''' <remarks>Does not use dataportal, should only be invoked on server side.</remarks>
        Friend Shared Sub CheckIfJournalEntryCanBeDeleted(ByVal journalEntryID As Integer, _
            ByVal ParamArray expectedTypes As DocumentType())

            Dim list As IndirectRelationInfoList = IndirectRelationInfoList. _
                GetIndirectRelationInfoListChild(journalEntryID)
            list.CheckIfJournalEntryCanBeDeleted(expectedTypes)

        End Sub

        ''' <summary>
        ''' Checks if a journal entry could be deleted, 
        ''' i.e. there is no documents that reference the JournalEntry.
        ''' Throws an exception if the journal entry could not be deleted
        ''' or if the <see cref="DocType">document type</see> does not match the 
        ''' <paramref name="expectedTypes">expectedTypes</paramref>.
        ''' </summary>
        ''' <param name="expectedTypes">an expected <see cref="DocType">document type</see>.</param>
        ''' <remarks></remarks>
        Friend Sub CheckIfJournalEntryCanBeDeleted(ByVal expectedTypes As DocumentType())

            If Not expectedTypes Is Nothing AndAlso expectedTypes.Length > 0 AndAlso _
                Array.IndexOf(expectedTypes, _DocType) < 0 Then Throw New Exception( _
                String.Format(My.Resources.HelperLists_IndirectRelationInfoList_UnexpectedType, _
                _DocTypeHumanReadable, Utilities.ConvertLocalizedName(expectedTypes(0))))

            If Me.Count > 0 Then
                Throw New Exception(String.Format(My.Resources.HelperLists_IndirectRelationInfoList_JournalEntryHasReferences, _
                    vbCrLf, Me.ToString))
            End If

            Dim lastClosingDate As Date = GetCurrentCompany.LastClosingDate

            If lastClosingDate = Date.MinValue Then Exit Sub

            If _DocType = DocumentType.ClosingEntries AndAlso _
                _Date.Date = lastClosingDate.Date Then Exit Sub

            If _DocType = DocumentType.TransferOfBalance AndAlso _
                _Date.Date = lastClosingDate.Date Then Exit Sub

            If _DocType = DocumentType.TransferOfBalance AndAlso lastClosingDate <> Date.MinValue Then
                Throw New Exception(String.Format(My.Resources.HelperLists_IndirectRelationInfoList_ClosingExistsAfterTransferOfBalance, _
                    lastClosingDate.ToString("yyyy-MM-dd")))
            End If

            If _Date.Date <= lastClosingDate.Date Then
                Throw New Exception(String.Format(My.Resources.HelperLists_IndirectRelationInfoList_ClosingExistsAfterJournalEntry, _
                    _Date.ToString("yyyy-MM-dd"), lastClosingDate.ToString("yyyy-MM-dd")))
            End If

        End Sub


        Public Overrides Function ToString() As String
            Dim result As String = ""
            For Each i As IndirectRelationInfo In Me
                result = AddWithNewLine(result, i.ToString, False)
            Next
            Return String.Format(My.Resources.HelperLists_IndirectRelationInfoList_ToString, _
                _Date.ToString("yyyy-MM-dd"), _DocNumber, _ID.ToString(), _Content, vbCrLf, vbCrLf, result)
        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.IndirectRelationInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new IndirectRelationInfoList instance for the requested journal entry.
        ''' </summary>
        ''' <param name="journalEntryID">an ID of the journal entry to fetch information for.</param>
        ''' <remarks></remarks>
        Public Shared Function GetIndirectRelationInfoList(ByVal journalEntryID As Integer) As IndirectRelationInfoList
            Return DataPortal.Fetch(Of IndirectRelationInfoList)(New Criteria(journalEntryID))
        End Function

        ''' <summary>
        ''' Gets a new IndirectRelationInfoList instance for the requested journal entry bypassing dataportal.
        ''' </summary>
        ''' <param name="journalEntryID">an ID of the journal entry to fetch information for.</param>
        ''' <remarks>Should only be invoked on server side.</remarks>
        Friend Shared Function GetIndirectRelationInfoListChild(ByVal journalEntryID As Integer) As IndirectRelationInfoList
            Dim result As New IndirectRelationInfoList
            result.DoFetch(journalEntryID)
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
                My.Resources.Common_SecuritySelectDenied)

            DoFetch(criteria.ID)

        End Sub

        Private Sub DoFetch(ByVal journalEntryID As Integer)

            Dim myComm As New SQLCommand("FetchIndirectRelationInfoGeneral")
            myComm.AddParam("?JD", journalEntryID)

            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then
                    Throw New Exception(String.Format(My.Resources.Common_ObjectNotFound, _
                        My.Resources.General_JournalEntry_TypeName, journalEntryID.ToString))
                End If

                Dim dr As DataRow = myData.Rows(0)

                _ID = journalEntryID
                _Date = CDateSafe(dr.Item(0), Today)
                _DocNumber = CStrSafe(dr.Item(1)).Trim
                _Content = CStrSafe(dr.Item(2)).Trim
                _DocType = Utilities.ConvertDatabaseCharID(Of DocumentType)(CStrSafe(dr.Item(3)).Trim)
                _DocTypeHumanReadable = Utilities.ConvertLocalizedName(_DocType)
                _InsertDate = CTimeStampSafe(dr.Item(4))
                _UpdateDate = CTimeStampSafe(dr.Item(5))
                _PersonName = CStrSafe(dr.Item(6)).Trim
                _PersonCode = CStrSafe(dr.Item(7)).Trim
                _CorrespondingAccounts = CStrSafe(dr.Item(8)).Trim
                _Sum = CDblSafe(dr.Item(9), 2, 0)

            End Using

            myComm = New SQLCommand("FetchIndirectRelationInfoList")
            myComm.AddParam("?JD", journalEntryID)

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