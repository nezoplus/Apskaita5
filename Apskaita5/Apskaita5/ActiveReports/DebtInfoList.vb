Namespace ActiveReports

    <Serializable()> _
    Public Class DebtInfoList
        Inherits ReadOnlyListBase(Of DebtInfoList, DebtInfo)

#Region " Business Methods "

        Private _DateFrom As Date = Today
        Private _DateTo As Date = Today
        Private _Account As Long = 0
        Private _IsBuyer As Boolean = True
        Private _IsSupplier As Boolean = False
        Private _GroupInfo As HelperLists.PersonGroupInfo = Nothing


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

        Public ReadOnly Property Account() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Account
            End Get
        End Property

        Public ReadOnly Property IsBuyer() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsBuyer
            End Get
        End Property

        Public ReadOnly Property IsSupplier() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsSupplier
            End Get
        End Property

        Public ReadOnly Property GroupInfo() As HelperLists.PersonGroupInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GroupInfo
            End Get
        End Property

        Public ReadOnly Property ShowZeroDebtsFilterState() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Filter Is Nothing OrElse ConvertDbBoolean(_Filter(0))
            End Get
        End Property


#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Reports.DebtInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of DebtInfo) = Nothing

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _FilteredList As Csla.FilteredBindingList(Of DebtInfo) = Nothing
        <NonSerialized()> _
        Private _Filter() As Integer = Nothing

        Public Shared Function GetDebtInfoList(ByVal nDateFrom As Date, _
            ByVal nDateTo As Date, ByVal nAccount As Long, ByVal nIsBuyer As Boolean, _
            ByVal nGroupInfo As HelperLists.PersonGroupInfo) As DebtInfoList

            If Not nAccount > 0 Then Throw New Exception("Klaida. Nenurodyta skolų apskaitos sąskaita.")

            Return DataPortal.Fetch(Of DebtInfoList) _
                (New Criteria(nDateFrom, nDateTo, nAccount, nIsBuyer, nGroupInfo))

        End Function

        Public Function GetSortedList() As Csla.FilteredBindingList(Of DebtInfo)

            If _FilteredList Is Nothing Then
                _SortedList = New Csla.SortedBindingList(Of DebtInfo)(Me)
                _FilteredList = New Csla.FilteredBindingList(Of DebtInfo) _
                    (_SortedList, AddressOf DebtInfoFilter)
            End If

            Return _FilteredList

        End Function

        Public Function ApplyFilter(ByVal nShowZeroDebts As Boolean) As Boolean

            If _FilteredList Is Nothing Then
                _SortedList = New Csla.SortedBindingList(Of DebtInfo)(Me)
                _FilteredList = New Csla.FilteredBindingList(Of DebtInfo) _
                    (_SortedList, AddressOf DebtInfoFilter)
                _Filter = New Integer() {ConvertDbBoolean(nShowZeroDebts)}
                _FilteredList.ApplyFilter("", _Filter)
                Return True
            End If

            If (_Filter Is Nothing AndAlso nShowZeroDebts) OrElse _
                (Not _Filter Is Nothing AndAlso ConvertDbBoolean(_Filter(0)) _
                = nShowZeroDebts) Then Return False

            _Filter = New Integer() {ConvertDbBoolean(nShowZeroDebts)}
            _FilteredList.ApplyFilter("", _Filter)

            Return True

        End Function

        Private Shared Function DebtInfoFilter(ByVal item As Object, ByVal filterValue As Object) As Boolean

            If filterValue Is Nothing Then Return True

            Dim nShowZeroDebts As Boolean = ConvertDbBoolean(DirectCast(filterValue, Integer())(0))

            Dim p As DebtInfo = DirectCast(item, DebtInfo)
            If Not nShowZeroDebts AndAlso p.DebtEnd = 0 Then Return False

            Return True

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
            Private _Account As Long
            Private _IsBuyer As Boolean
            Private _GroupInfo As HelperLists.PersonGroupInfo = Nothing
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
            Public ReadOnly Property Account() As Long
                Get
                    Return _Account
                End Get
            End Property
            Public ReadOnly Property IsBuyer() As Boolean
                Get
                    Return _IsBuyer
                End Get
            End Property
            Public ReadOnly Property GroupInfo() As HelperLists.PersonGroupInfo
                Get
                    Return _GroupInfo
                End Get
            End Property
            Public Sub New(ByVal nDateFrom As Date, ByVal nDateTo As Date, _
                ByVal nAccount As Long, ByVal nIsBuyer As Boolean, _
                ByVal nGroupInfo As HelperLists.PersonGroupInfo)
                _DateFrom = nDateFrom
                _DateTo = nDateTo
                _Account = nAccount
                _IsBuyer = nIsBuyer
                _GroupInfo = nGroupInfo
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            Dim myComm As New SQLCommand("FetchDebtInfoList")
            myComm.AddParam("?DF", criteria.DateFrom)
            myComm.AddParam("?DT", criteria.DateTo)
            myComm.AddParam("?AC", criteria.Account)
            If criteria.IsBuyer Then
                myComm.AddParam("?FC", 1)
                myComm.AddParam("?FS", 0)
            Else
                myComm.AddParam("?FC", 0)
                myComm.AddParam("?FS", 1)
            End If
            If Not criteria.GroupInfo Is Nothing AndAlso criteria.GroupInfo.ID > 0 Then
                myComm.AddParam("?CG", criteria.GroupInfo.ID)
            Else
                myComm.AddParam("?CG", 0)
            End If

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                For Each dr As DataRow In myData.Rows
                    Add(DebtInfo.GetDebtInfo(dr, criteria.IsBuyer))
                Next

                _DateFrom = criteria.DateFrom
                _DateTo = criteria.DateTo
                _Account = criteria.Account
                _IsBuyer = criteria.IsBuyer
                _IsSupplier = Not _IsBuyer
                _GroupInfo = criteria.GroupInfo

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace