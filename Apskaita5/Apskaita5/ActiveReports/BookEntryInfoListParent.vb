Imports ApskaitaObjects.HelperLists
Imports ApskaitaObjects.General
Namespace ActiveReports

    <Serializable()> _
    Public Class BookEntryInfoListParent
        Inherits ReadOnlyBase(Of BookEntryInfoListParent)

#Region " Business Methods "

        Private _ID As Guid = Guid.NewGuid
        Private _DateFrom As Date
        Private _DateTo As Date
        Private _Account As Integer
        Private _Person As HelperLists.PersonInfo
        Private _Group As HelperLists.PersonGroupInfo
        Private _IncludeSubAccounts As Boolean
        Private _DebetBalanceStart As Double
        Private _CreditBalanceStart As Double
        Private _DebetTurnover As Double
        Private _CreditTurnover As Double
        Private _DebetBalanceEnd As Double
        Private _CreditBalanceEnd As Double
        Private _Items As BookEntryInfoList
        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _ItemsSortable As Csla.SortedBindingList(Of BookEntryInfo) = Nothing

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
        ''' Gets an account by which the result is filtered.
        ''' </summary>
        Public ReadOnly Property Account() As Integer
            Get
                Return _Account
            End Get
        End Property

        ''' <summary>
        ''' Gets a person by which the fetch result is filtered.
        ''' Person has a filtering priority over person group.
        ''' </summary>
        Public ReadOnly Property Person() As HelperLists.PersonInfo
            Get
                Return _Person
            End Get
        End Property

        ''' <summary>
        ''' Gets a person group by which the fetch result is filtered.
        ''' Person has a filtering priority over person group.
        ''' </summary>
        Public ReadOnly Property Group() As HelperLists.PersonGroupInfo
            Get
                Return _Group
            End Get
        End Property

        ''' <summary>
        ''' Gets a boolean value indicating if the subaccounts results are included in the filtering result.
        ''' </summary>
        Public ReadOnly Property IncludeSubAccounts() As Boolean
            Get
                Return _IncludeSubAccounts
            End Get
        End Property

        ''' <summary>
        ''' Gets a Debet side balance before the filter period (if any).
        ''' </summary>
        Public ReadOnly Property DebetBalanceStart() As Double
            Get
                Return _DebetBalanceStart
            End Get
        End Property

        ''' <summary>
        ''' Gets a Credit side balance before the filter period (if any).
        ''' </summary>
        Public ReadOnly Property CreditBalanceStart() As Double
            Get
                Return _CreditBalanceStart
            End Get
        End Property

        ''' <summary>
        ''' Gets a Debet side turnover during the filter period (if any).
        ''' </summary>
        Public ReadOnly Property DebetTurnover() As Double
            Get
                Return _DebetTurnover
            End Get
        End Property

        ''' <summary>
        ''' Gets a Credit side turnover during the filter period (if any).
        ''' </summary>
        Public ReadOnly Property CreditTurnover() As Double
            Get
                Return _CreditTurnover
            End Get
        End Property

        ''' <summary>
        ''' Gets a Debet side balance at the end of the filter period (if any).
        ''' </summary>
        Public ReadOnly Property DebetBalanceEnd() As Double
            Get
                Return _DebetBalanceEnd
            End Get
        End Property

        ''' <summary>
        ''' Gets a Credit side balance at the end of the filter period (if any).
        ''' </summary>
        Public ReadOnly Property CreditBalanceEnd() As Double
            Get
                Return _CreditBalanceEnd
            End Get
        End Property

        ''' <summary>
        ''' Gets a book entries info objects that passes the filter params.
        ''' </summary>
        Public ReadOnly Property Items() As BookEntryInfoList
            Get
                Return _Items
            End Get
        End Property

        ''' <summary>
        ''' Gets a book entries info objects in an object that supports datagridview auto sort.
        ''' </summary>
        Public ReadOnly Property ItemsSortable() As Csla.SortedBindingList(Of BookEntryInfo)
            Get
                If _ItemsSortable Is Nothing AndAlso _Items IsNot Nothing Then _
                    _ItemsSortable = New Csla.SortedBindingList(Of BookEntryInfo)(_Items)
                Return _ItemsSortable
            End Get
        End Property

        ''' <summary>
        ''' Gets a GUID of the entry. Only used for technical purposes (datagridview needs to recognize rows)
        ''' </summary>
        Public ReadOnly Property ID() As Guid
            Get
                Return _ID
            End Get
        End Property

        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.GeneralLedger1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetBookEntryInfoListParent(ByVal nDateFrom As Date, _
            ByVal nDateTo As Date, ByVal nAccount As Integer, ByVal nPerson As HelperLists.PersonInfo, _
            ByVal nGroup As HelperLists.PersonGroupInfo, ByVal nIncludeSubAccounts As Boolean) _
            As BookEntryInfoListParent

            If Not nAccount > 0 Then Throw New Exception("Klaida. Nepasirinkta sąskaita.")

            Return DataPortal.Fetch(Of BookEntryInfoListParent)(New Criteria( _
                nDateFrom, nDateTo, nAccount, nPerson, nGroup, nIncludeSubAccounts))

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
            Private _Person As HelperLists.PersonInfo
            Private _Group As HelperLists.PersonGroupInfo
            Private _IncludeSubAccounts As Boolean
            Private _Account As Integer
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
            Public ReadOnly Property Account() As Integer
                Get
                    Return _Account
                End Get
            End Property
            Public ReadOnly Property Person() As HelperLists.PersonInfo
                Get
                    Return _Person
                End Get
            End Property
            Public ReadOnly Property Group() As HelperLists.PersonGroupInfo
                Get
                    Return _Group
                End Get
            End Property
            Public ReadOnly Property IncludeSubAccounts() As Boolean
                Get
                    Return _IncludeSubAccounts
                End Get
            End Property
            Public Sub New(ByVal nDateFrom As Date, ByVal nDateTo As Date, ByVal nAccount As Integer, _
                ByVal nPerson As HelperLists.PersonInfo, ByVal nGroup As HelperLists.PersonGroupInfo, _
                ByVal nIncludeSubAccounts As Boolean)

                _DateFrom = nDateFrom
                _DateTo = nDateTo
                _Account = nAccount
                _IncludeSubAccounts = nIncludeSubAccounts
                If nPerson Is Nothing OrElse Not nPerson.ID > 0 Then
                    _Person = Nothing
                Else
                    _Person = nPerson
                End If
                If nGroup Is Nothing OrElse Not nGroup.ID > 0 Then
                    _Group = Nothing
                Else
                    _Group = nGroup
                End If

            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai operacijai.")

            Dim myComm As SQLCommand

            ' Get info about all BookEntries that corresponds the search criterias
            ' choose SELECT command according to the criteria provided
            ' Person has a higher search priority then PersonGroup
            If Not criteria.IncludeSubAccounts AndAlso criteria.Person Is Nothing _
                AndAlso criteria.Group Is Nothing Then

                myComm = New SQLCommand("BookEntryInfoListSelect1")

            ElseIf criteria.IncludeSubAccounts AndAlso criteria.Person Is Nothing _
                AndAlso criteria.Group Is Nothing Then

                myComm = New SQLCommand("BookEntryInfoListSelect2")

            ElseIf Not criteria.IncludeSubAccounts AndAlso criteria.Person IsNot Nothing Then

                myComm = New SQLCommand("BookEntryInfoListSelect3")

            ElseIf criteria.IncludeSubAccounts AndAlso criteria.Person IsNot Nothing Then

                myComm = New SQLCommand("BookEntryInfoListSelect4")

            ElseIf Not criteria.IncludeSubAccounts AndAlso criteria.Group IsNot Nothing Then

                myComm = New SQLCommand("BookEntryInfoListSelect5")

            ElseIf criteria.IncludeSubAccounts AndAlso criteria.Group IsNot Nothing Then

                myComm = New SQLCommand("BookEntryInfoListSelect6")

            Else

                Throw New Exception("Klaida. Nenumatyta filtro kriterijų kombinacija.")

            End If

            myComm.AddParam("?DF", criteria.DateFrom.Date)
            myComm.AddParam("?DT", criteria.DateTo.Date)
            myComm.AddParam("?SS", criteria.Account)
            If criteria.Person IsNot Nothing Then
                myComm.AddParam("?PR", criteria.Person.ID)
            ElseIf criteria.Group IsNot Nothing Then
                myComm.AddParam("?PG", criteria.Group.ID)
            End If

            ' Loading the list of BookEntryInfo
            Using myData As DataTable = myComm.Fetch
                _Items = BookEntryInfoList.GetList(myData)
            End Using

            ' get the turnover values calculated by child list
            _DebetTurnover = CRound(_Items.DebetTurnover)
            _CreditTurnover = CRound(_Items.CreditTurnover)

            Dim myComm2 As SQLCommand

            ' Get info about account turnover before the given period 
            ' Only include turnover creating BookEntries that corresponds the search criterias
            ' I.e. turnover fetched may be different from the turnover of the account in total
            ' choose SELECT command according to the criteria provided
            ' Person has a higher search priority then PersonGroup
            If Not criteria.IncludeSubAccounts AndAlso criteria.Person Is Nothing _
                AndAlso criteria.Group Is Nothing Then

                myComm2 = New SQLCommand("BookEntryInfoTurnoverBefore1")

            ElseIf criteria.IncludeSubAccounts AndAlso criteria.Person Is Nothing _
                AndAlso criteria.Group Is Nothing Then

                myComm2 = New SQLCommand("BookEntryInfoTurnoverBefore2")

            ElseIf Not criteria.IncludeSubAccounts AndAlso criteria.Person IsNot Nothing Then

                myComm2 = New SQLCommand("BookEntryInfoTurnoverBefore3")

            ElseIf criteria.IncludeSubAccounts AndAlso criteria.Person IsNot Nothing Then

                myComm2 = New SQLCommand("BookEntryInfoTurnoverBefore4")

            ElseIf Not criteria.IncludeSubAccounts AndAlso criteria.Group IsNot Nothing Then

                myComm2 = New SQLCommand("BookEntryInfoTurnoverBefore5")

            ElseIf criteria.IncludeSubAccounts AndAlso criteria.Group IsNot Nothing Then

                myComm2 = New SQLCommand("BookEntryInfoTurnoverBefore6")

            Else

                Throw New Exception("Klaida. Nenumatyta filtro kriterijų kombinacija.")

            End If

            myComm2.AddParam("?DF", criteria.DateFrom.Date)
            myComm2.AddParam("?SS", criteria.Account)
            If criteria.Person IsNot Nothing Then
                myComm2.AddParam("?PR", criteria.Person.ID)
            ElseIf criteria.Group IsNot Nothing Then
                myComm2.AddParam("?PG", criteria.Group.ID)
            End If

            Using myData2 As DataTable = myComm2.Fetch
                If IsDBNull(myData2.Rows(0).Item(0)) Then myData2.Rows(0).Item(0) = 0
                If IsDBNull(myData2.Rows(0).Item(1)) Then myData2.Rows(0).Item(1) = 0
                If CRound(CDbl(myData2.Rows(0).Item(0))) > CRound(CDbl(myData2.Rows(0).Item(1))) Then
                    _DebetBalanceStart = CRound(CRound(CDbl(myData2.Rows(0).Item(0))) _
                        - CRound(CDbl(myData2.Rows(0).Item(1))))
                    _CreditBalanceStart = 0
                ElseIf CRound(CDbl(myData2.Rows(0).Item(0))) < CRound(CDbl(myData2.Rows(0).Item(1))) Then
                    _CreditBalanceStart = CRound(CRound(CDbl(myData2.Rows(0).Item(1))) _
                        - CRound(CDbl(myData2.Rows(0).Item(0))))
                    _DebetBalanceStart = 0
                Else
                    _CreditBalanceStart = 0
                    _DebetBalanceStart = 0
                End If
            End Using

            If CRound(_DebetTurnover + _DebetBalanceStart) > CRound(_CreditTurnover + _CreditBalanceStart) Then
                _DebetBalanceEnd = CRound(CRound(_DebetTurnover + _DebetBalanceStart) _
                    - CRound(_CreditTurnover + _CreditBalanceStart))
                _CreditBalanceEnd = 0
            ElseIf CRound(_DebetTurnover + _DebetBalanceStart) < (_CreditTurnover + _CreditBalanceStart) Then
                _CreditBalanceEnd = CRound(CRound(_CreditTurnover + _CreditBalanceStart) - _
                    CRound(_DebetTurnover + _DebetBalanceStart))
                _DebetBalanceEnd = 0
            Else
                _DebetBalanceEnd = 0
                _CreditBalanceEnd = 0
            End If

            _DateFrom = criteria.DateFrom
            _DateTo = criteria.DateTo
            _Account = criteria.Account
            If criteria.Group Is Nothing Then
                _Group = Nothing
            Else
                _Group = criteria.Group
            End If
            _IncludeSubAccounts = criteria.IncludeSubAccounts
            If criteria.Person Is Nothing Then
                _Person = HelperLists.PersonInfo.GetEmptyPersonInfo
            Else
                _Person = criteria.Person
            End If

        End Sub

#End Region

    End Class

End Namespace