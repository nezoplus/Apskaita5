Namespace Goods

    <Serializable()> _
    Public Class GoodsCostItemList
        Inherits ReadOnlyListBase(Of GoodsCostItemList, GoodsCostItem)

#Region " Business Methods "

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.GoodsCostItemList1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetGoodsCostItemList(ByVal GoodsCostParams As GoodsCostParam()) As GoodsCostItemList
            If Not CanGetObject() Then Throw New Exception( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")
            Dim result As GoodsCostItemList = DataPortal.Fetch(Of GoodsCostItemList) _
                (New Criteria(GoodsCostParams))
            Return result
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _GoodsCostParams As GoodsCostParam()
            Public ReadOnly Property GoodsCostParams() As GoodsCostParam()
                Get
                    Return _GoodsCostParams
                End Get
            End Property
            Public Sub New(ByVal nGoodsCostParams As GoodsCostParam())
                _GoodsCostParams = nGoodsCostParams
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If criteria.GoodsCostParams Is Nothing Then Exit Sub

            RaiseListChangedEvents = False
            IsReadOnly = False

            For Each param As GoodsCostParam In criteria.GoodsCostParams
                Add(GoodsCostItem.GetGoodsCostItemChild(param))
            Next

            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace