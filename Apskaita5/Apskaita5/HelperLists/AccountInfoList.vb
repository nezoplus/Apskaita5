Namespace HelperLists

    <Serializable()> _
    Public Class AccountInfoList
        Inherits ReadOnlyListBase(Of AccountInfoList, AccountInfo)

#Region " Business Methods "

        Public Function GetAccountByID(ByVal AccountID As Long) As AccountInfo
            For Each i As AccountInfo In Me
                If i.ID = AccountID Then Return i
            Next
            Return Nothing
        End Function

        Public Function GetAccountNameByID(ByVal AccountID As Long) As String
            For Each i As AccountInfo In Me
                If i.ID = AccountID Then Return i.Name
            Next
            Return ""
        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.AccountInfoList1")
        End Function

#End Region

#Region " Factory Methods "


        Public Shared Function GetList() As AccountInfoList

            Dim result As AccountInfoList = CacheManager.GetItemFromCache( _
                GetType(AccountInfoList), GetType(AccountInfoList), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of AccountInfoList)(New Criteria())
                CacheManager.AddCacheItem(GetType(AccountInfoList), result, Nothing)
            End If

            Return result

        End Function

        Public Shared Function GetCachedFilteredList(ByVal ShowEmpty As Boolean, _
            ByVal ParamArray ClassFilter As Integer()) As Csla.FilteredBindingList(Of AccountInfo)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai informacijai gauti.")

            Dim FilterToApply As Object()

            If ClassFilter Is Nothing OrElse ClassFilter.Length < 1 Then

                FilterToApply = GetNewFilter(ShowEmpty)

            Else

                Dim FilterList As New List(Of Integer)(ClassFilter)

                Dim i, j As Integer

                For i = FilterList.Count To 1 Step -1
                    If FilterList(i - 1) < 1 OrElse FilterList(i - 1) > 6 Then FilterList.RemoveAt(i - 1)
                Next

                For i = FilterList.Count To 1 Step -1
                    For j = i - 1 To 1 Step -1
                        If FilterList(i - 1) = FilterList(j - 1) Then
                            FilterList.RemoveAt(i - 1)
                            Exit For
                        End If
                    Next
                Next

                FilterList.Sort()

                If FilterList.Count < 1 Then
                    FilterToApply = GetNewFilter(ShowEmpty)
                Else
                    Dim NewFilterToApply(FilterList.Count) As Object
                    FilterToApply = NewFilterToApply
                    FilterToApply(0) = ConvertDbBoolean(ShowEmpty)
                    For i = 1 To FilterList.Count
                        FilterToApply(i) = FilterList(i - 1)
                    Next
                End If

            End If

            Dim result As Csla.FilteredBindingList(Of AccountInfo) = _
                CacheManager.GetItemFromCache(GetType(AccountInfoList), _
                GetType(Csla.FilteredBindingList(Of AccountInfo)), FilterToApply)

            If result Is Nothing Then

                Dim BaseList As AccountInfoList = AccountInfoList.GetList
                result = New Csla.FilteredBindingList(Of AccountInfo)(BaseList, AddressOf AccountInfoListFilter)
                result.ApplyFilter("", FilterToApply)
                CacheManager.AddCacheItem(GetType(AccountInfoList), result, FilterToApply)

            End If

            Return result

        End Function

        Private Shared Function GetNewFilter(ByVal ShowEmpty As Boolean) As Object()
            Dim NewFilter(6) As Object
            NewFilter(0) = ConvertDbBoolean(ShowEmpty)
            NewFilter(1) = 1
            NewFilter(2) = 2
            NewFilter(3) = 3
            NewFilter(4) = 4
            NewFilter(5) = 5
            NewFilter(6) = 6
            Return NewFilter
        End Function

        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(AccountInfoList))
        End Sub

        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(AccountInfoList))
        End Function

        Private Shared Function AccountInfoListFilter(ByVal item As Object, ByVal filterValue As Object) As Boolean

            If filterValue Is Nothing OrElse Not TypeOf filterValue Is Object() _
                OrElse Not DirectCast(filterValue, Object()).Length > 0 Then Return True

            Dim ShowEmpty As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(0), Integer))

            Dim ClassFilter As Integer() = Nothing
            If DirectCast(filterValue, Object()).Length > 1 Then
                Dim NewClassFilter(DirectCast(filterValue, Object()).Length - 2) As Integer
                ClassFilter = NewClassFilter
                For i As Integer = 2 To DirectCast(filterValue, Object()).Length
                    ClassFilter(i - 2) = CIntSafe(DirectCast(filterValue, Object())(i - 1), 0)
                Next
            End If

            ' no criteria to apply
            If ShowEmpty AndAlso (ClassFilter Is Nothing OrElse ClassFilter.Length = 6) Then Return True

            Dim CI As AccountInfo = DirectCast(item, AccountInfo)

            If Not ShowEmpty AndAlso Not CI.ID > 0 Then Return False
            If Not ClassFilter Is Nothing AndAlso CI.ID > 0 AndAlso Array.IndexOf(ClassFilter, _
                Convert.ToInt32(CI.Class)) < 0 Then Return False

            Return True

        End Function

        Private Shared Function IsApplicationWideCache() As Boolean
            Return False
        End Function

        Private Shared Function GetListOnServer() As AccountInfoList
            Dim result As New AccountInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function

        Friend Shared Function GetListServerSide() As AccountInfoList
            Dim result As New AccountInfoList
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

            Dim myComm As New SQLCommand("GetAccountList")
            
            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                Add(AccountInfo.GetEmptyAccountInfo)
                For Each dr As DataRow In myData.Rows
                    Add(AccountInfo.GetAccountInfo(dr))
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace