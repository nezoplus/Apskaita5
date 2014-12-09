Namespace Goods

    <Serializable()> _
    Public Class GoodsPriceInWarehouseItemList
        Inherits ReadOnlyListBase(Of GoodsPriceInWarehouseItemList, GoodsPriceInWarehouseItem)

#Region " Business Methods "

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.GoodsPriceInWarehouseItemList1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetGoodsPriceInWarehouseItemList(ByVal nDate As Date, _
            ByVal nParams As GoodsPriceInWarehouseParam()) As GoodsPriceInWarehouseItemList
            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")
            Return DataPortal.Fetch(Of GoodsPriceInWarehouseItemList) _
                (New Criteria(nDate, nParams))
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _Params As GoodsPriceInWarehouseParam()
            Private _Date As Date
            Public ReadOnly Property Params() As GoodsPriceInWarehouseParam()
                Get
                    Return _Params
                End Get
            End Property
            Public ReadOnly Property [Date]() As Date
                Get
                    Return _Date
                End Get
            End Property
            Public Sub New(ByVal nDate As Date, ByVal nParams As GoodsPriceInWarehouseParam())
                _Date = nDate
                _Params = nParams
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If criteria.Params Is Nothing Then Exit Sub

            RaiseListChangedEvents = False
            IsReadOnly = False

            For Each param As GoodsPriceInWarehouseParam In criteria.Params
                Add(GoodsPriceInWarehouseItem.GetGoodsPriceInWarehouseItem( _
                    param.GoodsID, criteria.Date, param.OperationID))
            Next

            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace