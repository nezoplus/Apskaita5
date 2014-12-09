Namespace ActiveReports

    <Serializable()> _
    Public Class GoodsOperationInfoListParent
        Inherits ReadOnlyBase(Of GoodsOperationInfoListParent)

#Region " Business Methods "

        Private _GoodsTurnoverInfo As GoodsTurnoverInfo = Nothing
        Private _DateFrom As Date = Today
        Private _DateTo As Date = Today
        Private _Warehouse As WarehouseInfo = Nothing
        Private _Items As GoodsOperationInfoList = Nothing

        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _ItemsSortedList As Csla.SortedBindingList(Of GoodsOperationInfo) = Nothing


        Public ReadOnly Property GoodsTurnoverInfo() As GoodsTurnoverInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsTurnoverInfo
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

        Public ReadOnly Property Warehouse() As WarehouseInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Warehouse
            End Get
        End Property

        Public ReadOnly Property Items() As GoodsOperationInfoList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Items
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            If _GoodsTurnoverInfo Is Nothing Then Return 0
            Return _GoodsTurnoverInfo.ID
        End Function

        Public Overrides Function ToString() As String
            If _GoodsTurnoverInfo Is Nothing Then Return ""
            Return _GoodsTurnoverInfo.Name
        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetGoodsTurnoverInfoListParent(ByVal nDateFrom As Date, _
            ByVal nDateTo As Date, ByVal nGoodsID As Integer, ByVal nWarehouse As WarehouseInfo) _
            As GoodsOperationInfoListParent

            If Not nGoodsID > 0 Then Throw New Exception("Klaida. Nenurodyta prekių rūšis.")

            Return DataPortal.Fetch(Of GoodsOperationInfoListParent) _
                (New Criteria(nDateFrom, nDateTo, nGoodsID, nWarehouse))

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
            Private _GoodsID As Integer = 0
            Private _Warehouse As WarehouseInfo = Nothing
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
            Public ReadOnly Property GoodsID() As Integer
                Get
                    Return _GoodsID
                End Get
            End Property
            Public ReadOnly Property Warehouse() As WarehouseInfo
                Get
                    Return _Warehouse
                End Get
            End Property
            Public Sub New(ByVal nDateFrom As Date, ByVal nDateTo As Date, _
                ByVal nGoodsID As Integer, ByVal nWarehouse As WarehouseInfo)
                _DateFrom = nDateFrom
                _DateTo = nDateTo
                _GoodsID = nGoodsID
                _Warehouse = nWarehouse
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            Dim myComm As New SQLCommand("FetchGoodsOperationInfoListParent")
            myComm.AddParam("?DF", criteria.DateFrom.Date)
            myComm.AddParam("?DT", criteria.DateTo.Date)
            myComm.AddParam("?GD", criteria.GoodsID)
            If Not criteria.Warehouse Is Nothing AndAlso criteria.Warehouse.ID > 0 Then
                myComm.AddParam("?WD", criteria.Warehouse.ID)
            Else
                myComm.AddParam("?WD", 0)
            End If

            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Throw New Exception("Klaida. Prekė, kurio ID='" _
                    & criteria.GoodsID.ToString & "', nerasta.)")

                _DateFrom = criteria.DateFrom
                _DateTo = criteria.DateTo
                _Warehouse = criteria.Warehouse

                _GoodsTurnoverInfo = ActiveReports.GoodsTurnoverInfo.GetGoodsTurnoverInfo(myData.Rows(0))

            End Using

            myComm = New SQLCommand("FetchGoodsOperationInfoList")
            myComm.AddParam("?DF", criteria.DateFrom.Date)
            myComm.AddParam("?DT", criteria.DateTo.Date)
            myComm.AddParam("?GD", criteria.GoodsID)
            If Not criteria.Warehouse Is Nothing AndAlso criteria.Warehouse.ID > 0 Then
                myComm.AddParam("?WD", criteria.Warehouse.ID)
            Else
                myComm.AddParam("?WD", 0)
            End If

            Using myData As DataTable = myComm.Fetch
                _Items = GoodsOperationInfoList.GetGoodsOperationInfoList(myData)
            End Using

        End Sub

#End Region

    End Class

End Namespace