Namespace HelperLists

    <Serializable()> _
    Public Class WorkTimeClassInfoList
        Inherits ReadOnlyListBase(Of WorkTimeClassInfoList, WorkTimeClassInfo)

#Region " Business Methods "

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.WorkTimeClassInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetList() As WorkTimeClassInfoList

            Dim result As WorkTimeClassInfoList = CacheManager.GetItemFromCache( _
                GetType(WorkTimeClassInfoList), GetType(WorkTimeClassInfoList), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of WorkTimeClassInfoList)(New Criteria())
                CacheManager.AddCacheItem(GetType(WorkTimeClassInfoList), result, Nothing)
            End If

            Return result

        End Function

        Public Shared Function GetCachedFilteredList(ByVal ShowEmpty As Boolean, _
            ByVal ShowWithoutHours As Boolean, ByVal ShowWithHours As Boolean) _
            As Csla.FilteredBindingList(Of WorkTimeClassInfo)

            Dim FilterToApply(2) As Object
            FilterToApply(0) = ConvertDbBoolean(ShowEmpty)
            FilterToApply(1) = ConvertDbBoolean(ShowWithoutHours)
            FilterToApply(2) = ConvertDbBoolean(ShowWithHours)

            Dim result As Csla.FilteredBindingList(Of WorkTimeClassInfo) = _
                CacheManager.GetItemFromCache(GetType(WorkTimeClassInfoList), _
                GetType(Csla.FilteredBindingList(Of WorkTimeClassInfo)), FilterToApply)

            If result Is Nothing Then

                Dim BaseList As WorkTimeClassInfoList = WorkTimeClassInfoList.GetList
                result = New Csla.FilteredBindingList(Of WorkTimeClassInfo) _
                    (BaseList, AddressOf WorkTimeClassInfoFilter)
                result.ApplyFilter("", FilterToApply)
                CacheManager.AddCacheItem(GetType(WorkTimeClassInfoList), result, FilterToApply)

            End If

            Return result

        End Function

        Private Shared Function WorkTimeClassInfoFilter(ByVal item As Object, ByVal filterValue As Object) As Boolean

            If filterValue Is Nothing OrElse DirectCast(filterValue, Object()).Length < 1 Then Return True

            Dim ShowEmpty As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(0), Integer))
            Dim ShowWithoutHours As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(1), Integer))
            Dim ShowWithHours As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(2), Integer))

            If ShowEmpty AndAlso ShowWithoutHours AndAlso ShowWithHours Then Return True

            If Not ShowEmpty AndAlso Not DirectCast(item, WorkTimeClassInfo).ID > 0 Then Return False
            If Not ShowWithoutHours AndAlso DirectCast(item, WorkTimeClassInfo).WithoutWorkHours Then Return False
            If Not ShowWithHours AndAlso Not DirectCast(item, WorkTimeClassInfo).WithoutWorkHours Then Return False

            Return True

        End Function

        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(WorkTimeClassInfoList))
        End Sub

        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(WorkTimeClassInfoList))
        End Function

        Private Shared Function IsApplicationWideCache() As Boolean
            Return False
        End Function

        Private Shared Function GetListOnServer() As WorkTimeClassInfoList
            Dim result As New WorkTimeClassInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
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

            Dim myComm As New SQLCommand("FetchWorkTimeClassInfoList")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                Add(WorkTimeClassInfo.NewWorkTimeClassInfo)

                For Each dr As DataRow In myData.Rows
                    Add(WorkTimeClassInfo.GetWorkTimeClassInfo(dr, 0))
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace