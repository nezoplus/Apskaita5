Namespace Goods

    <Serializable()> _
    Public Class WarehouseList
        Inherits BusinessListBase(Of WarehouseList, Warehouse)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Me.IsDirty
            End Get
        End Property


        Protected Overrides Function AddNewCore() As Object
            Dim NewItem As Warehouse = Warehouse.NewWarehouse
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


        Public Overrides Function Save() As WarehouseList

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai operacijai.")

            If Not Me.Count > 0 AndAlso Not Me.DeletedList.Count > 0 Then _
                Throw New Exception("Klaida. Neįkrauta nė viena eilutė.")

            If Not Me.IsValid Then Throw New Exception("Įvestuose duomenyse yra klaidų: " _
                & GetAllBrokenRules())

            Dim result As WarehouseList = MyBase.Save
            HelperLists.WarehouseInfoList.InvalidateCache()
            Return result

        End Function


        Protected Overrides Sub ClearItems()
            Throw New NotImplementedException("WarehouseList cannot be cleared.")
            MyBase.ClearItems()
        End Sub

        Protected Overrides Sub RemoveItem(ByVal index As Integer)
            If Item(index).ContainsGoods Then Throw New Exception( _
                "Klaida. Šiame sandėlyje buvo apskaitomos prekės. Jo pašalinti neleidžiama.")
            MyBase.RemoveItem(index)
        End Sub

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.WarehouseList1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return False
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.WarehouseList3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return False
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of Warehouse) = Nothing

        Public Shared Function GetWarehouseList() As WarehouseList
            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")
            Dim result As WarehouseList = DataPortal.Fetch(Of WarehouseList)(New Criteria())
            Return result
        End Function

        Public Function GetSortedList() As Csla.SortedBindingList(Of Warehouse)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of Warehouse)(Me)
            Return _SortedList
        End Function

        Private Sub New()
            ' require use of factory methods
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public Sub New()
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            Dim myComm As New SQLCommand("FetchWarehouseList")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False

                For Each dr As DataRow In myData.Rows
                    Add(Warehouse.GetWarehouse(dr))
                Next

                RaiseListChangedEvents = True

            End Using

        End Sub

        Protected Overrides Sub DataPortal_Update()

            Dim WarehousesWithGoods As New List(Of Integer)

            Dim myComm As New SQLCommand("FetchUsedWarehouses")
            Using myData As DataTable = myComm.Fetch
                Dim c As Integer = 0
                For Each dr As DataRow In myData.Rows
                    c = CIntSafe(dr.Item(0), )
                    If c > 0 Then WarehousesWithGoods.Add(c)
                Next
            End Using

            For Each c As Warehouse In DeletedList
                If WarehousesWithGoods.Contains(c.ID) Then Throw New Exception( _
                    "Sandėlio " & c.Name & " pašalinti negalima. Jame buvo apskaitomos prekės.")
            Next

            For Each c As Warehouse In Me
                If WarehousesWithGoods.Contains(c.ID) Then c.RestoreIsProduction()
            Next

            DatabaseAccess.TransactionBegin()

            RaiseListChangedEvents = False

            For Each item As Warehouse In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As Warehouse In Me
                If item.IsNew Then
                    item.Insert(Me)
                ElseIf item.IsDirty Then
                    item.Update(Me)
                End If
            Next

            RaiseListChangedEvents = True

            DatabaseAccess.TransactionCommit()

        End Sub

#End Region

    End Class

End Namespace