Namespace Goods

    <Serializable()> _
    Public Class GoodsPriceInWarehouseItem
        Inherits ReadOnlyBase(Of GoodsPriceInWarehouseItem)

#Region " Business Methods "

        Private _GoodsID As Integer = 0
        Private _Date As Date = Today
        Private _AmountInWarehouseAccounts As Double = 0
        Private _TotalValueInWarehouseAccounts As Double = 0
        Private _TotalValueCurrentPriceCut As Double = 0


        Public ReadOnly Property GoodsID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsID
            End Get
        End Property

        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        Public ReadOnly Property AmountInWarehouseAccounts() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountInWarehouseAccounts, 6)
            End Get
        End Property

        Public ReadOnly Property TotalValueInWarehouseAccounts() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueInWarehouseAccounts)
            End Get
        End Property

        Public ReadOnly Property TotalValueCurrentPriceCut() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueCurrentPriceCut)
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _GoodsID
        End Function

        Public Overrides Function ToString() As String
            Return _GoodsID.ToString
        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.GoodsPriceInWarehouseItem1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetGoodsPriceInWarehouseItem(ByVal nGoodsID As Integer, _
            ByVal nDate As Date, ByVal nOperationID As Integer) As GoodsPriceInWarehouseItem
            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")
            Return DataPortal.Fetch(Of GoodsPriceInWarehouseItem) _
                (New Criteria(nGoodsID, nDate, nOperationID))
        End Function

        Friend Shared Function GetGoodsPriceInWarehouseItemChild(ByVal nGoodsID As Integer, _
            ByVal nDate As Date, ByVal nOperationID As Integer) As GoodsPriceInWarehouseItem
            Return New GoodsPriceInWarehouseItem(nGoodsID, nDate, nOperationID)
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal nGoodsID As Integer, ByVal nDate As Date, ByVal nOperationID As Integer)
            ' require use of factory methods
            DoFetch(nGoodsID, nDate, nOperationID)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _ID As Integer
            Private _Date As Date
            Private _OperationID As Integer
            Public ReadOnly Property ID() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public ReadOnly Property [Date]() As Date
                Get
                    Return _Date
                End Get
            End Property
            Public ReadOnly Property OperationID() As Integer
                Get
                    Return _OperationID
                End Get
            End Property
            Public Sub New(ByVal nID As Integer, ByVal nDate As Date, ByVal nOperationID As Integer)
                _ID = nID
                _Date = nDate
                _OperationID = nOperationID
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)
            DoFetch(criteria.ID, criteria.Date, criteria.OperationID)
        End Sub

        Private Sub DoFetch(ByVal nGoodsID As Integer, ByVal nDate As Date, ByVal nOperationID As Integer)

            Dim myComm As New SQLCommand("FetchGoodsPriceInWarehouseItem")
            myComm.AddParam("?GD", nGoodsID)
            myComm.AddParam("?DT", nDate.Date)
            myComm.AddParam("?OD", nOperationID)

            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Throw New Exception("Klaida. Prekė, kurio ID='" _
                    & nGoodsID.ToString & "', nerasta.)")

                Dim dr As DataRow = myData.Rows(0)

                _GoodsID = nGoodsID
                _Date = nDate

                _AmountInWarehouseAccounts = CDblSafe(dr.Item(0), 6, 0)
                _TotalValueInWarehouseAccounts = CDblSafe(dr.Item(1), 2, 0)
                _TotalValueCurrentPriceCut = CDblSafe(dr.Item(2), 2, 0)

            End Using

        End Sub

#End Region

    End Class

End Namespace