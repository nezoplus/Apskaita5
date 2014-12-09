Namespace Goods

    <Serializable()> _
    Public Class ProductionComponentItemList
        Inherits BusinessListBase(Of ProductionComponentItemList, ProductionComponentItem)

#Region " Business Methods "

        Protected Overrides Function AddNewCore() As Object
            Dim NewItem As ProductionComponentItem = ProductionComponentItem.NewProductionComponentItem
            Me.Add(NewItem)
            Return NewItem
        End Function

        Public Function GetAllBrokenRules() As String
            Dim result As String = GetAllBrokenRulesForList(Me)

            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = GetAllWarningsForList(Me)
            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function NewProductionComponentItemList() As ProductionComponentItemList
            Dim result As ProductionComponentItemList = New ProductionComponentItemList
            Return result
        End Function

        Friend Shared Function GetProductionComponentItemList(ByVal myData As DataTable) As ProductionComponentItemList
            Dim result As ProductionComponentItemList = New ProductionComponentItemList(myData)
            Return result
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByVal myData As DataTable)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Fetch(myData)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal myData As DataTable)

            RaiseListChangedEvents = False

            For Each dr As DataRow In myData.Rows
                If ConvertEnumDatabaseStringCode(Of ProductionComponentType) _
                    (CStrSafe(dr.Item(0))) = ProductionComponentType.Component Then _
                    Add(ProductionComponentItem.GetProductionComponentItem(dr))
            Next

            RaiseListChangedEvents = True

        End Sub

        Friend Sub Update(ByVal parent As ProductionCalculation)

            RaiseListChangedEvents = False

            For Each item As ProductionComponentItem In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As ProductionComponentItem In Me
                If item.IsNew Then
                    item.Insert(parent)
                ElseIf item.IsDirty Then
                    item.Update(parent)
                End If
            Next

            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace