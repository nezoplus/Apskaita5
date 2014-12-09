Imports ApskaitaObjects.HelperLists
Namespace ActiveReports

    <Serializable()> _
    Public Class CashOperationInfoList
        Inherits ReadOnlyListBase(Of CashOperationInfoList, CashOperationInfo)

#Region " Business Methods "

        Private _Account As CashAccountInfo = Nothing
        Private _Person As PersonInfo = Nothing
        Private _DateFrom As Date = Today
        Private _DateTo As Date = Today
        Private _BalanceBookEntryStart As Double = 0
        Private _BalanceStart As Double = 0
        Private _BalanceLTLStart As Double = 0
        Private _TurnoverBookEntryDebit As Double = 0
        Private _TurnoverBookEntryCredit As Double = 0
        Private _TurnoverDebit As Double = 0
        Private _TurnoverCredit As Double = 0
        Private _TurnoverLTLDebit As Double = 0
        Private _TurnoverLTLCredit As Double = 0
        Private _TurnOverInListLTLDebit As Double = 0
        Private _TurnoverInListLTLCredit As Double = 0
        Private _BalanceBookEntryEnd As Double = 0
        Private _BalanceEnd As Double = 0
        Private _BalanceLTLEnd As Double = 0


        Public ReadOnly Property Account() As CashAccountInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Account
            End Get
        End Property

        Public ReadOnly Property Person() As PersonInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Person
            End Get
        End Property

        Public ReadOnly Property DateFrom() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DateFrom
            End Get
        End Property

        Public ReadOnly Property DateTo() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DateTo
            End Get
        End Property

        Public ReadOnly Property BalanceBookEntryStart() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BalanceBookEntryStart)
            End Get
        End Property

        Public ReadOnly Property BalanceStart() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BalanceStart)
            End Get
        End Property

        Public ReadOnly Property BalanceLTLStart() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BalanceLTLStart)
            End Get
        End Property

        Public ReadOnly Property TurnoverBookEntryDebit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TurnoverBookEntryDebit)
            End Get
        End Property

        Public ReadOnly Property TurnoverBookEntryCredit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TurnoverBookEntryCredit)
            End Get
        End Property

        Public ReadOnly Property TurnoverDebit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TurnoverDebit)
            End Get
        End Property

        Public ReadOnly Property TurnoverCredit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TurnoverCredit)
            End Get
        End Property

        Public ReadOnly Property TurnoverLTLDebit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TurnoverLTLDebit)
            End Get
        End Property

        Public ReadOnly Property TurnoverLTLCredit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TurnoverLTLCredit)
            End Get
        End Property

        Public ReadOnly Property TurnOverInListLTLDebit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TurnOverInListLTLDebit)
            End Get
        End Property

        Public ReadOnly Property TurnoverInListLTLCredit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TurnoverInListLTLCredit)
            End Get
        End Property

        Public ReadOnly Property BalanceBookEntryEnd() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BalanceBookEntryEnd)
            End Get
        End Property

        Public ReadOnly Property BalanceEnd() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BalanceEnd)
            End Get
        End Property

        Public ReadOnly Property BalanceLTLEnd() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BalanceLTLEnd)
            End Get
        End Property

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return CanGetObjectTill() OrElse CanGetObjectBankAccounts()
        End Function

        Public Shared Function CanGetObjectTill() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.TillInfoList1")
        End Function

        Public Shared Function CanGetObjectBankAccounts() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.BankAccountsInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of CashOperationInfo) = Nothing

        Public Shared Function GetCashOperationInfoList(ByVal nAccount As CashAccountInfo, _
            ByVal nDateFrom As Date, ByVal nDateTo As Date, ByVal nPerson As PersonInfo) As CashOperationInfoList

            If Not nAccount Is Nothing AndAlso Not nAccount.ID > 0 Then nAccount = Nothing
            If Not nPerson Is Nothing AndAlso Not nPerson.ID > 0 Then nPerson = Nothing

            Return DataPortal.Fetch(Of CashOperationInfoList) _
                (New Criteria(nAccount, nDateFrom, nDateTo, nPerson))

        End Function

        Public Function GetSortedList() As Csla.SortedBindingList(Of CashOperationInfo)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of CashOperationInfo)(Me)
            Return _SortedList
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _Account As CashAccountInfo
            Private _DateFrom As Date
            Private _DateTo As Date
            Private _Person As PersonInfo
            Public ReadOnly Property Account() As CashAccountInfo
                Get
                    Return _Account
                End Get
            End Property
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
            Public ReadOnly Property Person() As PersonInfo
                Get
                    Return _Person
                End Get
            End Property
            Public Sub New(ByVal nAccount As CashAccountInfo, ByVal nDateFrom As Date, _
                ByVal nDateTo As Date, ByVal nPerson As PersonInfo)
                _Account = nAccount
                _DateFrom = nDateFrom
                _DateTo = nDateTo
                _Person = nPerson
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            If (criteria.Account Is Nothing OrElse Not criteria.Account.ID > 0) AndAlso _
                (Not CanGetObjectTill() OrElse Not CanGetObjectBankAccounts()) Then _
                Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            If Not criteria.Account Is Nothing AndAlso criteria.Account.ID > 0 AndAlso _
                criteria.Account.Type = Documents.CashAccountType.Till AndAlso Not CanGetObjectTill() Then _
                Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            If Not criteria.Account Is Nothing AndAlso criteria.Account.ID > 0 AndAlso _
                criteria.Account.Type <> Documents.CashAccountType.Till AndAlso Not CanGetObjectBankAccounts() Then _
                Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            Dim myComm As New SQLCommand("FetchCashOperationInfoList")
            myComm.AddParam("?DF", criteria.DateFrom.Date)
            myComm.AddParam("?DT", criteria.DateTo.Date)
            If Not criteria.Account Is Nothing AndAlso criteria.Account.ID > 0 Then
                myComm.AddParam("?AD", criteria.Account.ID)
            Else
                myComm.AddParam("?AD", 0)
            End If
            If Not criteria.Person Is Nothing AndAlso criteria.Person.ID > 0 Then
                myComm.AddParam("?CD", criteria.Person.ID)
            Else
                myComm.AddParam("?CD", 0)
            End If

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                For Each dr As DataRow In myData.Rows
                    Dim NewInfo As CashOperationInfo = CashOperationInfo.GetCashOperationInfo(dr)
                    Add(NewInfo)
                    If NewInfo.SumBookEntry > 0 Then
                        _TurnOverInListLTLDebit = CRound(_TurnOverInListLTLDebit + NewInfo.SumBookEntry)
                    Else
                        _TurnoverInListLTLCredit = CRound(_TurnoverInListLTLCredit - NewInfo.SumBookEntry)
                    End If
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

            If Not criteria.Account Is Nothing AndAlso criteria.Account.ID > 0 Then

                myComm = New SQLCommand("FetchCashOperationInfoListBalance")
                myComm.AddParam("?DF", criteria.DateFrom.Date)
                myComm.AddParam("?DT", criteria.DateTo.Date)
                myComm.AddParam("?AD", criteria.Account.ID)

                Using myData As DataTable = myComm.Fetch

                    If myData.Rows.Count > 0 Then

                        RaiseListChangedEvents = False
                        IsReadOnly = False

                        Dim dr As DataRow = myData.Rows(0)

                        _BalanceBookEntryStart = CDblSafe(dr.Item(0), 2, 0)
                        _BalanceStart = CDblSafe(dr.Item(1), 2, 0)
                        _BalanceLTLStart = CDblSafe(dr.Item(2), 2, 0)

                        _TurnoverBookEntryDebit = CDblSafe(dr.Item(3), 2, 0)
                        _TurnoverBookEntryCredit = CDblSafe(dr.Item(4), 2, 0)
                        _TurnoverDebit = CDblSafe(dr.Item(5), 2, 0)
                        _TurnoverCredit = CDblSafe(dr.Item(6), 2, 0)
                        _TurnoverLTLDebit = CDblSafe(dr.Item(7), 2, 0)
                        _TurnoverLTLCredit = CDblSafe(dr.Item(8), 2, 0)

                        _BalanceBookEntryEnd = CRound(_BalanceBookEntryStart + _
                            _TurnoverBookEntryDebit - _TurnoverBookEntryCredit)
                        _BalanceEnd = CRound(_BalanceStart + _TurnoverDebit - _TurnoverCredit)
                        _BalanceLTLEnd = CRound(_BalanceLTLStart + _TurnoverLTLDebit - _TurnoverLTLCredit)

                        IsReadOnly = True
                        RaiseListChangedEvents = True

                    End If

                End Using

            End If

            _Account = criteria.Account
            _DateFrom = criteria.DateFrom
            _DateTo = criteria.DateTo
            _Person = criteria.Person

        End Sub

#End Region

    End Class

End Namespace