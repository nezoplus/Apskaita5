Namespace ActiveReports

    <Serializable()> _
    Public Class GoodsOperationInfoList
        Inherits ReadOnlyListBase(Of GoodsOperationInfoList, GoodsOperationInfo)

#Region " Business Methods "

#End Region

#Region " Factory Methods "

        Friend Shared Function GetGoodsOperationInfoList(ByVal myData As DataTable) As GoodsOperationInfoList
            Return New GoodsOperationInfoList(myData)
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal myData As DataTable)
            ' require use of factory methods
            Fetch(myData)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal myData As DataTable)

            RaiseListChangedEvents = False
            IsReadOnly = False

            For Each dr As DataRow In myData.Rows
                Add(GoodsOperationInfo.GetGoodsOperationInfo(dr))
            Next

            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace