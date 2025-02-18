﻿Namespace ActiveReports

    ''' <summary>
    ''' Represents a general ledger report.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public NotInheritable Class JournalEntryInfoList
        Inherits ReadOnlyListBase(Of JournalEntryInfoList, JournalEntryInfo)

#Region " Business Methods "

        Private _DateFrom As Date = Today
        Private _DateTo As Date = Today
        Private _ContentFilter As String = ""
        Private _PersonFilter As Integer = 0
        Private _PersonGroupFilter As Integer = 0
        Private _DocTypeFilter As DocumentType = DocumentType.None
        Private _ApplyDocTypeFilter As Boolean = False
        Private _PersonName As String = ""
        Private _PersonGroupName As String = ""

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _ItemsSortable As Csla.SortedBindingList(Of JournalEntryInfo) = Nothing


        ''' <summary>
        ''' Gets a begining date (inclusive) of the filtering interval.
        ''' </summary>
        Public ReadOnly Property DateFrom() As Date
            Get
                Return _DateFrom
            End Get
        End Property

        ''' <summary>
        ''' Gets an ending date (inclusive) of the filtering interval.
        ''' </summary>
        Public ReadOnly Property DateTo() As Date
            Get
                Return _DateTo
            End Get
        End Property

        ''' <summary>
        ''' Gets a content filter string.
        ''' </summary>
        Public ReadOnly Property ContentFilter() As String
            Get
                Return _ContentFilter
            End Get
        End Property

        ''' <summary>
        ''' Gets a person by which the fetch result is filtered.
        ''' Person has a filtering priority over person group.
        ''' </summary>
        Public ReadOnly Property PersonFilter() As Integer
            Get
                Return _PersonFilter
            End Get
        End Property

        ''' <summary>
        ''' Gets a person group by which the fetch result is filtered.
        ''' Person has a filtering priority over person group.
        ''' </summary>
        Public ReadOnly Property PersonGroupFilter() As Integer
            Get
                Return _PersonGroupFilter
            End Get
        End Property

        ''' <summary>
        ''' Gets a DocumentType by which the fetch result is filtered 
        ''' (if the ApplyDocTypeFilter is set to true).
        ''' </summary>
        Public ReadOnly Property DocTypeFilter() As DocumentType
            Get
                Return _DocTypeFilter
            End Get
        End Property

        ''' <summary>
        ''' Gets a boolean value indicating if the result should be filtered by DocType(Filter).
        ''' </summary>
        Public ReadOnly Property ApplyDocTypeFilter() As Boolean
            Get
                Return _ApplyDocTypeFilter
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable name of the person by which the result is filtered.
        ''' </summary>
        Public ReadOnly Property PersonName() As String
            Get
                Return _PersonName
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable name of the person group by which the result is filtered.
        ''' </summary>
        Public ReadOnly Property PersonGroupName() As String
            Get
                Return _PersonGroupName
            End Get
        End Property


        ''' <summary>
        ''' Gets a sortable view of the report to implement auto sort in grid controls.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetItemsSortable() As Csla.SortedBindingList(Of JournalEntryInfo)
            If _ItemsSortable Is Nothing Then _
                _ItemsSortable = New Csla.SortedBindingList(Of JournalEntryInfo)(Me)
            Return _ItemsSortable
        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.GeneralLedger1")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a general ledger report.
        ''' </summary>
        ''' <param name="nDateFrom">a begining date (inclusive) of the filtering interval</param>
        ''' <param name="nDateTo">an ending date (inclusive) of the filtering interval</param>
        ''' <param name="nContentFilter">a content filter string</param>
        ''' <param name="nPersonFilter">an ID of the person by which the result is filtered</param>
        ''' <param name="nPersonGroupFilter">an ID of the person group by which the result is filtered</param>
        ''' <param name="nDocTypeFilter">a DocumentType by which the fetch result is filtered</param>
        ''' <param name="nApplyDocTypeFilter">whether the result should be filtered by <paramref name="nDocTypeFilter">nDocTypeFilter</paramref>.</param>
        ''' <param name="nPersonName">a name of the person by which the result is filtered</param>
        ''' <param name="nPersonGroupName">a name of the person group by which the result is filtered</param>
        ''' <remarks></remarks>
        Public Shared Function GetList(ByVal nDateFrom As Date, ByVal nDateTo As Date, _
            ByVal nContentFilter As String, ByVal nPersonFilter As Integer, _
            ByVal nPersonGroupFilter As Integer, ByVal nDocTypeFilter As DocumentType, _
            ByVal nApplyDocTypeFilter As Boolean, ByVal nPersonName As String, _
            ByVal nPersonGroupName As String) As JournalEntryInfoList
            Return DataPortal.Fetch(Of JournalEntryInfoList)(New Criteria(nDateFrom, _
                nDateTo, nContentFilter, nPersonFilter, nPersonGroupFilter, _
                nDocTypeFilter, nApplyDocTypeFilter, nPersonName, nPersonGroupName))
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria

            Private _DateFrom As Date
            Private _DateTo As Date
            Private _ContentFilter As String
            Private _PersonFilter As Integer
            Private _PersonGroupFilter As Integer
            Private _DocTypeFilter As DocumentType
            Private _ApplyDocTypeFilter As Boolean
            Private _PersonName As String
            Private _PersonGroupName As String

            Public ReadOnly Property DateFrom() As Date
                Get
                    Return _DateFrom
                End Get
            End Property

            Public ReadOnly Property DateTo() As Date
                Get
                    Return _DateTo
                End Get
            End Property

            Public ReadOnly Property ContentFilter() As String
                Get
                    Return _ContentFilter
                End Get
            End Property

            Public ReadOnly Property PersonFilter() As Integer
                Get
                    Return _PersonFilter
                End Get
            End Property

            Public ReadOnly Property PersonGroupFilter() As Integer
                Get
                    Return _PersonGroupFilter
                End Get
            End Property

            Public ReadOnly Property DocTypeFilter() As DocumentType
                Get
                    Return _DocTypeFilter
                End Get
            End Property

            Public ReadOnly Property ApplyDocTypeFilter() As Boolean
                Get
                    Return _ApplyDocTypeFilter
                End Get
            End Property

            Public ReadOnly Property PersonName() As String
                Get
                    Return _PersonName
                End Get
            End Property

            Public ReadOnly Property PersonGroupName() As String
                Get
                    Return _PersonGroupName
                End Get
            End Property

            Public Sub New(ByVal nDateFrom As Date, ByVal nDateTo As Date, _
                ByVal nContentFilter As String, ByVal nPersonFilter As Integer, _
                ByVal nPersonGroupFilter As Integer, ByVal nDocTypeFilter As DocumentType, _
                ByVal nApplyDocTypeFilter As Boolean, ByVal nPersonName As String, _
                ByVal nPersonGroupName As String)

                _DateFrom = nDateFrom
                _DateTo = nDateTo
                _ContentFilter = nContentFilter
                _PersonFilter = nPersonFilter
                _PersonGroupFilter = nPersonGroupFilter
                _DocTypeFilter = nDocTypeFilter
                _ApplyDocTypeFilter = nApplyDocTypeFilter
                _PersonName = nPersonName
                _PersonGroupName = nPersonGroupName

            End Sub

        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As SQLCommand

            If Not criteria.ApplyDocTypeFilter AndAlso Not criteria.PersonFilter > 0 _
                AndAlso Not criteria.PersonGroupFilter > 0 Then

                myComm = New SQLCommand("JournalEntriesFetch1")

            ElseIf criteria.ApplyDocTypeFilter AndAlso Not criteria.PersonFilter > 0 _
                AndAlso Not criteria.PersonGroupFilter > 0 Then

                myComm = New SQLCommand("JournalEntriesFetch2")

            ElseIf criteria.ApplyDocTypeFilter AndAlso criteria.PersonGroupFilter > 0 Then

                myComm = New SQLCommand("JournalEntriesFetch4")

            ElseIf criteria.ApplyDocTypeFilter AndAlso criteria.PersonFilter > 0 Then

                myComm = New SQLCommand("JournalEntriesFetch3")

            ElseIf Not criteria.ApplyDocTypeFilter AndAlso criteria.PersonGroupFilter > 0 Then

                myComm = New SQLCommand("JournalEntriesFetch6")

            Else

                myComm = New SQLCommand("JournalEntriesFetch5")

            End If

            myComm.AddParam("?DF", criteria.DateFrom.Date)
            myComm.AddParam("?DT", criteria.DateTo.Date)
            If String.IsNullOrEmpty(criteria.ContentFilter.Trim) Then
                myComm.AddParam("?CF", GetWildcart())
            Else
                myComm.AddParam("?CF", criteria.ContentFilter)
            End If
            If criteria.ApplyDocTypeFilter Then _
                myComm.AddParam("?DP", Utilities.ConvertDatabaseCharID(criteria.DocTypeFilter))
            If criteria.PersonGroupFilter > 0 Then
                myComm.AddParam("?GD", criteria.PersonGroupFilter)
            ElseIf criteria.PersonFilter > 0 Then
                myComm.AddParam("?PR", criteria.PersonFilter)
            End If

            RaiseListChangedEvents = False
            IsReadOnly = False

            Using myData As DataTable = myComm.Fetch
                For Each dr As DataRow In myData.Rows
                    Add(JournalEntryInfo.GetJournalEntryInfo(dr))
                Next
            End Using

            _DateFrom = criteria.DateFrom
            _DateTo = criteria.DateTo
            If String.IsNullOrEmpty(criteria.ContentFilter.Trim) Then
                _ContentFilter = My.Resources.ActiveReports_JournalEntryInfoList_FilterNotApplied
            Else
                _ContentFilter = criteria.ContentFilter
            End If
            _PersonGroupFilter = criteria.PersonGroupFilter
            If _PersonGroupFilter > 0 Then
                _PersonFilter = -1
                _PersonGroupName = criteria.PersonGroupName
                _PersonName = My.Resources.ActiveReports_JournalEntryInfoList_FilterNotApplied
            Else
                _PersonFilter = criteria.PersonFilter
                _PersonName = criteria.PersonName
                _PersonGroupName = My.Resources.ActiveReports_JournalEntryInfoList_FilterNotApplied
            End If
            _ApplyDocTypeFilter = criteria.ApplyDocTypeFilter
            If _ApplyDocTypeFilter Then
                _DocTypeFilter = criteria.DocTypeFilter
            Else
                _DocTypeFilter = DocumentType.None
            End If

            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace