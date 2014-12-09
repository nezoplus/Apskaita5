Namespace ActiveReports

    <Serializable()> _
    Public Class ProductionCalculationItemList
        Inherits ReadOnlyListBase(Of ProductionCalculationItemList, ProductionCalculationItem)

#Region " Business Methods "

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.ProductionCalculationItemInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of ProductionCalculationItem) = Nothing

        Public Shared Function GetProductionCalculationItemList() As ProductionCalculationItemList
            Return DataPortal.Fetch(Of ProductionCalculationItemList)(New Criteria())
        End Function

        Public Function GetSortedList() As Csla.SortedBindingList(Of ProductionCalculationItem)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of ProductionCalculationItem)(Me)
            Return _SortedList
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public Sub New()
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            Dim myComm As New SQLCommand("FetchProductionCalculationItemList")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                For Each dr As DataRow In myData.Rows
                    Add(ProductionCalculationItem.GetProductionCalculationItem(dr))
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace