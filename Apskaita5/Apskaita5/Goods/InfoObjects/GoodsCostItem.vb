Namespace Goods

    <Serializable()> _
    Public Class GoodsCostItem
        Inherits ReadOnlyBase(Of GoodsCostItem)

#Region " Business Methods "

        Private _GoodsID As Integer = 0
        Private _WarehouseID As Integer = 0
        Private _Amount As Double = 0
        Private _UnitCosts As Double = 0
        Private _TotalCosts As Double = 0
        Private _ValuationMethod As GoodsValuationMethod = GoodsValuationMethod.FIFO
        Private _NotEnoughInStock As Boolean = False
        Private _CalculationDate As Date = Date.MaxValue


        Public ReadOnly Property GoodsID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsID
            End Get
        End Property

        Public ReadOnly Property WarehouseID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WarehouseID
            End Get
        End Property

        Public ReadOnly Property Amount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Amount, 6)
            End Get
        End Property

        Public ReadOnly Property UnitCosts() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnitCosts, 6)
            End Get
        End Property

        Public ReadOnly Property TotalCosts() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalCosts)
            End Get
        End Property

        Public ReadOnly Property ValuationMethod() As GoodsValuationMethod
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ValuationMethod
            End Get
        End Property

        Public ReadOnly Property NotEnoughInStock() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NotEnoughInStock
            End Get
        End Property

        Public ReadOnly Property CalculationDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CalculationDate
            End Get
        End Property


        Protected Overrides Function GetIdValue() As Object
            Return _GoodsID.ToString & "-" & _WarehouseID.ToString
        End Function

        Public Overrides Function ToString() As String
            Return _GoodsID.ToString & "-" & _WarehouseID.ToString
        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.GoodsCostItem1")
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function GetGoodsCostItemChild(ByVal param As GoodsCostParam) As GoodsCostItem
            Return New GoodsCostItem(param)
        End Function

        Public Shared Function GetGoodsCostItem(ByVal nGoodsID As Integer, _
            ByVal nWarehouseID As Integer, ByVal nAmount As Double, _
            ByVal nDiscardParentID As Integer, ByVal nConsignmentParentID As Integer, _
            ByVal nValuationMethod As GoodsValuationMethod, ByVal nCalculationDate As Date) As GoodsCostItem

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            If Not nGoodsID > 0 Then Throw New ArgumentException("Klaida. Nenurodytas prekių ID.")
            If Not nWarehouseID > 0 Then Throw New ArgumentException("Klaida. Nenurodytas sandėlio ID.")

            Dim result As GoodsCostItem = DataPortal.Fetch(Of GoodsCostItem) _
                (New Criteria(nGoodsID, nWarehouseID, nAmount, nDiscardParentID, _
                    nConsignmentParentID, nValuationMethod, nCalculationDate))

            If result.NotEnoughInStock Then Throw New Exception("Klaida. Nepakanka prekių likučio sandėlyje.")

            Return result

        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal param As GoodsCostParam)
            Fetch(param.GoodsID, param.WarehouseID, param.Amount, param.DiscardParentID, _
                param.ConsignmentParentID, param.ValuationMethod, param.CalculationDate)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _GoodsID As Integer
            Private _WarehouseID As Integer
            Private _Amount As Double
            Private _ConsignmentParentID As Integer
            Private _DiscardParentID As Integer
            Private _ValuationMethod As GoodsValuationMethod
            Private _CalculationDate As Date
            Public ReadOnly Property GoodsID() As Integer
                Get
                    Return _GoodsID
                End Get
            End Property
            Public ReadOnly Property WarehouseID() As Integer
                Get
                    Return _WarehouseID
                End Get
            End Property
            Public ReadOnly Property Amount() As Double
                Get
                    Return CRound(_Amount, 6)
                End Get
            End Property
            Public ReadOnly Property ConsignmentParentID() As Integer
                Get
                    Return _ConsignmentParentID
                End Get
            End Property
            Public ReadOnly Property DiscardParentID() As Integer
                Get
                    Return _DiscardParentID
                End Get
            End Property
            Public ReadOnly Property ValuationMethod() As GoodsValuationMethod
                Get
                    Return _ValuationMethod
                End Get
            End Property
            Public ReadOnly Property CalculationDate() As Date
                Get
                    Return _CalculationDate
                End Get
            End Property
            Public Sub New(ByVal nGoodsID As Integer, ByVal nWarehouseID As Integer, _
                ByVal nAmount As Double, ByVal nDiscardParentID As Integer, _
                ByVal nConsignmentParentID As Integer, ByVal nValuationMethod As GoodsValuationMethod, _
                ByVal nCalculationDate As Date)
                _GoodsID = nGoodsID
                _WarehouseID = nWarehouseID
                _Amount = nAmount
                _DiscardParentID = nDiscardParentID
                _ConsignmentParentID = nConsignmentParentID
                _ValuationMethod = nValuationMethod
                _CalculationDate = nCalculationDate
            End Sub
        End Class


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)
            Fetch(criteria.GoodsID, criteria.WarehouseID, criteria.Amount, _
                criteria.DiscardParentID, criteria.ConsignmentParentID, _
                criteria.ValuationMethod, criteria.CalculationDate)
        End Sub

        Private Sub Fetch(ByVal nGoodsID As Integer, ByVal nWarehouseID As Integer, _
            ByVal nAmount As Double, ByVal nDiscardParentID As Integer, _
            ByVal nConsignmentParentID As Integer, ByVal nValuationMethod As GoodsValuationMethod, _
            ByVal nCalculationDate As Date)

            _GoodsID = nGoodsID
            _WarehouseID = nWarehouseID
            _Amount = nAmount
            _ValuationMethod = nValuationMethod
            _CalculationDate = nCalculationDate

            If Not CRound(_Amount, 6) > 0 Then Exit Sub

            If nValuationMethod = GoodsValuationMethod.Average Then

                If Not nConsignmentParentID > 0 Then nConsignmentParentID = -1
                If Not nDiscardParentID > 0 Then nDiscardParentID = -1

                Dim myComm As New SQLCommand("FetchGoodsCostItemAverage")
                myComm.AddParam("?DT", nCalculationDate.Date)
                myComm.AddParam("?GD", nGoodsID)
                myComm.AddParam("?WD", nWarehouseID)
                myComm.AddParam("?CD", nConsignmentParentID)
                myComm.AddParam("?OD", nDiscardParentID)

                Using myData As DataTable = myComm.Fetch

                    If myData.Rows.Count < 1 Then
                        _NotEnoughInStock = True
                        Exit Sub
                    End If

                    Dim dr As DataRow = myData.Rows(0)

                    If CDblSafe(dr.Item(0), 6, 0) < CRound(nAmount, 6) Then
                        _NotEnoughInStock = True
                        Exit Sub
                    End If

                    _UnitCosts = CRound(CDblSafe(dr.Item(1), 2, 0) / CDblSafe(dr.Item(0), 6, 0), 6)
                    _TotalCosts = CRound(_UnitCosts * nAmount, 2)

                End Using

            Else

                Dim consignments As ConsignmentPersistenceObjectList = _
                    ConsignmentPersistenceObjectList.GetConsignmentPersistenceObjectList( _
                    nGoodsID, nWarehouseID, nDiscardParentID, nConsignmentParentID, _
                    (nValuationMethod = GoodsValuationMethod.LIFO))

                consignments.RemoveLateEntries(nCalculationDate)

                Try

                    Dim discards As ConsignmentDiscardPersistenceObjectList = _
                        ConsignmentDiscardPersistenceObjectList.NewConsignmentDiscardPersistenceObjectList( _
                        consignments, _Amount, "")

                    _TotalCosts = discards.GetTotalValue
                    _UnitCosts = CRound(_TotalCosts / _Amount, 6)

                Catch ex As Exception
                    If ex.Message.Contains("likučio sandėlyje") Then
                        _NotEnoughInStock = True
                    Else
                        Throw
                    End If
                End Try

            End If

        End Sub

#End Region

    End Class

End Namespace