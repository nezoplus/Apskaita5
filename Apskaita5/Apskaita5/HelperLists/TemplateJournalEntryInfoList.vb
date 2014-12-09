Namespace HelperLists

    <Serializable()> _
    Public Class TemplateJournalEntryInfoList
        Inherits ReadOnlyListBase(Of TemplateJournalEntryInfoList, TemplateJournalEntryInfo)

#Region " Business Methods "

        Public Shadows Sub Remove(ByVal ItemToRemove As TemplateJournalEntryInfo)

            RaiseListChangedEvents = False
            IsReadOnly = False

            MyBase.Remove(ItemToRemove)

            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.TemplateJournalEntryInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement filter and sorting in gridview
        <NonSerialized()> _
        Private _FilteredList As Csla.FilteredBindingList(Of TemplateJournalEntryInfo) = Nothing
        <NonSerialized()> _
        Private _Filter() As Object = Nothing


        Public Shared Function GetList() As TemplateJournalEntryInfoList

            Dim result As TemplateJournalEntryInfoList = CacheManager.GetItemFromCache( _
                GetType(TemplateJournalEntryInfoList), GetType(TemplateJournalEntryInfoList), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of TemplateJournalEntryInfoList)(New Criteria())
                CacheManager.AddCacheItem(GetType(TemplateJournalEntryInfoList), result, Nothing)
            End If

            Return result

        End Function

        Public Shared Function GetCachedFilteredList(ByVal ShowEmpty As Boolean) _
            As Csla.FilteredBindingList(Of TemplateJournalEntryInfo)

            Dim FilterToApply(0) As Object
            FilterToApply(0) = ConvertDbBoolean(ShowEmpty)

            Dim result As Csla.FilteredBindingList(Of TemplateJournalEntryInfo) = _
                CacheManager.GetItemFromCache(GetType(TemplateJournalEntryInfoList), _
                GetType(Csla.FilteredBindingList(Of TemplateJournalEntryInfo)), FilterToApply)

            If result Is Nothing Then

                Dim BaseList As TemplateJournalEntryInfoList = TemplateJournalEntryInfoList.GetList
                result = New Csla.FilteredBindingList(Of TemplateJournalEntryInfo) _
                    (BaseList, AddressOf TemplateJournalEntryInfoFilter)
                result.ApplyFilter("", FilterToApply)
                CacheManager.AddCacheItem(GetType(TemplateJournalEntryInfoList), result, FilterToApply)

            End If

            Return result

        End Function

        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(TemplateJournalEntryInfoList))
        End Sub

        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(TemplateJournalEntryInfoList))
        End Function

        Private Shared Function TemplateJournalEntryInfoFilter(ByVal item As Object, ByVal filterValue As Object) As Boolean

            If filterValue Is Nothing OrElse DirectCast(filterValue, Object()).Length < 1 Then Return True

            Dim ShowEmpty As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(0), Integer))

            ' no criteria to apply
            If ShowEmpty Then Return True

            Dim CI As TemplateJournalEntryInfo = DirectCast(item, TemplateJournalEntryInfo)

            If Not ShowEmpty AndAlso Not CI.ID > 0 Then Return False

            Return True

        End Function

        Private Shared Function IsApplicationWideCache() As Boolean
            Return False
        End Function

        Private Shared Function GetListOnServer() As TemplateJournalEntryInfoList
            Dim result As New TemplateJournalEntryInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function


        Public Function GetFilteredList() As Csla.FilteredBindingList(Of TemplateJournalEntryInfo)

            If _FilteredList Is Nothing Then

                _FilteredList = New Csla.FilteredBindingList(Of TemplateJournalEntryInfo) _
                    (New Csla.SortedBindingList(Of TemplateJournalEntryInfo)(Me), _
                    AddressOf TemplateJournalEntryInfoFilter)
                _Filter = New Object() {ConvertDbBoolean(False)}
                _FilteredList.ApplyFilter("", _Filter)

            End If

            Return _FilteredList

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

            Dim myComm As New SQLCommand("FetchTemplateJournalEntryInfoList")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                For Each dr As DataRow In myData.Rows
                    Add(TemplateJournalEntryInfo.GetTemplateJournalEntryInfo(dr))
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace