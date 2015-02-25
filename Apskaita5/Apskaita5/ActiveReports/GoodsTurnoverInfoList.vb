Namespace ActiveReports

    <Serializable()> _
    Public Class GoodsTurnoverInfoList
        Inherits ReadOnlyListBase(Of GoodsTurnoverInfoList, GoodsTurnoverInfo)

#Region " Business Methods "

        Private _DateFrom As Date = Today
        Private _DateTo As Date = Today
        Private _Group As GoodsGroupInfo = Nothing
        Private _Warehouse As WarehouseInfo = Nothing
        Private _TextInNameOrCode As String = ""
        Private _IncludeWithoutTurnover As Boolean = False

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

        Public ReadOnly Property Group() As GoodsGroupInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Group
            End Get
        End Property

        Public ReadOnly Property Warehouse() As WarehouseInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Warehouse
            End Get
        End Property

        Public ReadOnly Property TextInNameOrCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TextInNameOrCode
            End Get
        End Property

        Public ReadOnly Property IncludeWithoutTurnover() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IncludeWithoutTurnover
            End Get
        End Property

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsTurnoverInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of GoodsTurnoverInfo) = Nothing

        Public Shared Function GetGoodsTurnoverInfoList(ByVal nDateFrom As Date, _
            ByVal nDateTo As Date, ByVal nGroup As GoodsGroupInfo, _
            ByVal nWarehouse As WarehouseInfo, ByVal nTextInNameOrCode As String, _
            ByVal nIncludeWithoutTurnover As Boolean) As GoodsTurnoverInfoList
            Dim result As GoodsTurnoverInfoList = DataPortal.Fetch(Of GoodsTurnoverInfoList) _
                (New Criteria(nDateFrom, nDateTo, nGroup, nWarehouse, nTextInNameOrCode, nIncludeWithoutTurnover))
            Return result
        End Function

        Public Function GetSortedList() As Csla.SortedBindingList(Of GoodsTurnoverInfo)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of GoodsTurnoverInfo)(Me)
            Return _SortedList
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _DateFrom As Date = Today
            Private _DateTo As Date = Today
            Private _Group As GoodsGroupInfo = Nothing
            Private _Warehouse As WarehouseInfo = Nothing
            Private _TextInNameOrCode As String = ""
            Private _IncludeWithoutTurnover As Boolean = False
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
            Public ReadOnly Property Group() As GoodsGroupInfo
                Get
                    Return _Group
                End Get
            End Property
            Public ReadOnly Property Warehouse() As WarehouseInfo
                Get
                    Return _Warehouse
                End Get
            End Property
            Public ReadOnly Property TextInNameOrCode() As String
                Get
                    Return _TextInNameOrCode
                End Get
            End Property
            Public ReadOnly Property IncludeWithoutTurnover() As Boolean
                <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
                Get
                    Return _IncludeWithoutTurnover
                End Get
            End Property
            Public Sub New(ByVal nDateFrom As Date, ByVal nDateTo As Date, ByVal nGroup As GoodsGroupInfo, _
                ByVal nWarehouse As WarehouseInfo, ByVal nTextInNameOrCode As String, _
                ByVal nIncludeWithoutTurnover As Boolean)
                _DateFrom = nDateFrom
                _DateTo = nDateTo
                _Group = nGroup
                _Warehouse = nWarehouse
                _Group = nGroup
                _TextInNameOrCode = nTextInNameOrCode
                _IncludeWithoutTurnover = nIncludeWithoutTurnover
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            Dim myComm As New SQLCommand("FetchGoodsTurnoverInfoList")
            myComm.AddParam("?DF", criteria.DateFrom.Date)
            myComm.AddParam("?DT", criteria.DateTo.Date)
            If Not criteria.Group Is Nothing AndAlso criteria.Group.ID > 0 Then
                myComm.AddParam("?GD", criteria.Group.ID)
            Else
                myComm.AddParam("?GD", 0)
            End If
            If Not criteria.Warehouse Is Nothing AndAlso criteria.Warehouse.ID > 0 Then
                myComm.AddParam("?WD", criteria.Warehouse.ID)
            Else
                myComm.AddParam("?WD", 0)
            End If
            Dim curWildCard As String = GetWildcart()
            If criteria.TextInNameOrCode Is Nothing OrElse String.IsNullOrEmpty(criteria.TextInNameOrCode.Trim) Then
                myComm.AddParam("?TX", curWildCard)
            Else
                myComm.AddParam("?TX", curWildCard & criteria.TextInNameOrCode.Trim & curWildCard)
            End If

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                For Each dr As DataRow In myData.Rows
                    Dim newItem As GoodsTurnoverInfo = GoodsTurnoverInfo.GetGoodsTurnoverInfo(dr)
                    If criteria.IncludeWithoutTurnover OrElse newItem.HasTurnover Then Add(newItem)
                Next

                _DateFrom = criteria.DateFrom
                _DateTo = criteria.DateTo
                _Group = criteria.Group
                _Warehouse = criteria.Warehouse
                _TextInNameOrCode = criteria.TextInNameOrCode
                _IncludeWithoutTurnover = criteria.IncludeWithoutTurnover

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace