﻿Imports System.Runtime.CompilerServices
Imports ApskaitaObjects.Documents

Namespace HelperLists

    ''' <summary>
    ''' Represents a list of <see cref="Documents.Service">service data</see> value objects.
    ''' </summary>
    ''' <remarks>Exists a single instance per company.</remarks>
    <Serializable()> _
    Public NotInheritable Class ServiceInfoList
        Inherits ReadOnlyListBase(Of ServiceInfoList, ServiceInfo)

#Region " Business Methods "

        public Function GetServiceInfo(serviceCode As String) As ServiceInfo

            If (StringIsNullOrEmpty(serviceCode)) Then Return Nothing

            serviceCode = serviceCode.Trim()

            For Each service As ServiceInfo In Me
                 If serviceCode.Equals(service.Code.Trim, StringComparison.OrdinalIgnoreCase) Then Return service
            Next

            Return Nothing
        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.ServiceInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement filter and sorting in gridview
        <NonSerialized()> _
        Private _FilteredList As Csla.FilteredBindingList(Of ServiceInfo) = Nothing
        <NonSerialized()> _
        Private _Filter() As Object = Nothing


        ''' <summary>
        ''' Gets a current service info value object list from database.
        ''' </summary>
        ''' <remarks>Result is cached.
        ''' Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Function GetList() As ServiceInfoList

            Dim result As ServiceInfoList = CacheManager.GetItemFromCache(Of ServiceInfoList)( _
                GetType(ServiceInfoList), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of ServiceInfoList)(New Criteria())
                CacheManager.AddCacheItem(GetType(ServiceInfoList), result, Nothing)
            End If

            Return result

        End Function

        Friend Shared Function GetListChild() As ServiceInfoList
            Dim result As New ServiceInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function

        ''' <summary>
        ''' Gets a filtered view of the current service info value object list.
        ''' </summary>
        ''' <param name="showEmpty">Wheather to include a placeholder object.</param>
        ''' <param name="tradedType">type of services to include</param>
        ''' <param name="usedObjectsIds"><see cref="ServiceInfo.ID">id's of the services</see> that are
        ''' used in the business object, i.e. should be included even if obsolete</param>
        ''' <param name="showObsolete">Wheather to include services that are obsolete (no loger in use).</param>
        ''' <remarks>Result is cached.
        ''' Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Function GetCachedFilteredList(ByVal showEmpty As Boolean, _
            ByVal showObsolete As Boolean, ByVal tradedType As TradedItemType, _
            ByVal usedObjectsIds As List(Of String)) As Csla.FilteredBindingList(Of ServiceInfo)

            Dim filterToApply(3) As Object
            filterToApply(0) = showObsolete
            filterToApply(1) = showEmpty
            filterToApply(2) = tradedType
            filterToApply(3) = usedObjectsIds

            Dim result As Csla.FilteredBindingList(Of ServiceInfo) = _
                CacheManager.GetItemFromCache(Of Csla.FilteredBindingList(Of ServiceInfo)) _
                (GetType(ServiceInfoList), filterToApply)

            If result Is Nothing Then

                Dim baseList As ServiceInfoList = ServiceInfoList.GetList
                result = New Csla.FilteredBindingList(Of ServiceInfo) _
                    (baseList, AddressOf ServiceInfoFilter)
                result.ApplyFilter("", filterToApply)
                CacheManager.AddCacheItem(GetType(ServiceInfoList), result, filterToApply)

            End If

            Return result

        End Function

        ''' <summary>
        ''' Invalidates the current service info value object list cache 
        ''' so that the next <see cref="GetList">GetList</see> call would hit the database.
        ''' </summary>
        ''' <remarks>Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(ServiceInfoList))
        End Sub

        ''' <summary>
        ''' Returnes true if the cache does not contain a current service info value object list.
        ''' </summary>
        ''' <remarks>Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(ServiceInfoList))
        End Function

        ''' <summary>
        ''' Returns true if the collection is common across all the databases.
        ''' I.e. cache is not to be cleared on changing databases.
        ''' </summary>
        ''' <remarks>Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Private Shared Function IsApplicationWideCache() As Boolean
            Return False
        End Function

        ''' <summary>
        ''' Gets a current service info value object list from database bypassing dataportal.
        ''' </summary>
        ''' <remarks>Should only be called server side.
        ''' Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Private Shared Function GetListOnServer() As ServiceInfoList
            Dim result As New ServiceInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function


        ''' <summary>
        ''' Gets a filtered sortable list. Invoke <see cref="ApplyFilter">ApplyFilter</see> 
        ''' to set the filter for the resulting list.
        ''' </summary>
        ''' <remarks>Used because there is no active report to show a simple service list.</remarks>
        Public Function GetFilteredList() As Csla.FilteredBindingList(Of ServiceInfo)

            If _FilteredList Is Nothing Then

                Dim filterToApply(3) As Object
                filterToApply(0) = True
                filterToApply(1) = False
                filterToApply(2) = TradedItemType.All
                filterToApply(3) = Nothing

                _FilteredList = New Csla.FilteredBindingList(Of ServiceInfo) _
                    (New Csla.SortedBindingList(Of ServiceInfo)(Me), AddressOf ServiceInfoFilter)
                _Filter = filterToApply
                _FilteredList.ApplyFilter("", _Filter)

            End If

            Return _FilteredList

        End Function

        ''' <summary>
        ''' Applies filter to the filtered list returned by the method <see cref="GetFilteredList">GetFilteredList</see>.
        ''' </summary>
        ''' <param name="showSales">Wheather to include services that are sold.</param>
        ''' <param name="showPurchases">Wheather to include services that are purchased.</param>
        ''' <param name="showObsolete">Wheather to include services that are obsolete (no loger in use).</param>
        ''' <remarks>Used because there is no active report to show a simple service list.</remarks>
        Public Function ApplyFilter(ByVal showSales As Boolean, ByVal showPurchases As Boolean, _
            ByVal showObsolete As Boolean) As Boolean

            If _FilteredList Is Nothing Then _FilteredList = _
                New Csla.FilteredBindingList(Of ServiceInfo) _
                (New Csla.SortedBindingList(Of ServiceInfo)(Me), AddressOf ServiceInfoFilter)

            Dim tradedType As TradedItemType
            If showSales AndAlso showPurchases Then
                tradedType = TradedItemType.All
            ElseIf showSales Then
                tradedType = TradedItemType.Sales
            ElseIf showSales AndAlso showPurchases Then
                tradedType = TradedItemType.Purchases
            Else
                tradedType = TradedItemType.All
            End If

            Dim filterToApply(3) As Object
            filterToApply(0) = True
            filterToApply(1) = False
            filterToApply(2) = tradedType
            filterToApply(3) = Nothing

            _Filter = filterToApply

            _FilteredList.ApplyFilter("", _Filter)

            Return True

        End Function


        Private Shared Function ServiceInfoFilter(ByVal item As Object, ByVal filterValue As Object) As Boolean

            If filterValue Is Nothing OrElse DirectCast(filterValue, Object()).Length < 4 Then Return True

            Dim filterArray As Object() = DirectCast(filterValue, Object())

            Dim showObsolete As Boolean = DirectCast(filterArray(0), Boolean)
            Dim showEmpty As Boolean = DirectCast(filterArray(1), Boolean)
            Dim tradedType As Documents.TradedItemType = _
                DirectCast(filterArray(2), Documents.TradedItemType)
            Dim usedObjectsIds As List(Of String) = DirectCast(filterArray(3), List(Of String))

            ' no criteria to apply
            If showEmpty AndAlso showObsolete AndAlso tradedType = TradedItemType.All Then Return True

            Dim current As ServiceInfo = DirectCast(item, ServiceInfo)

            If current.IsEmpty Then

                Return showEmpty

            Else

                If Not usedObjectsIds Is Nothing AndAlso usedObjectsIds.Contains( _
                    current.GetValueObjectIdString()) Then
                    Return True
                End If

                If Not showObsolete AndAlso current.IsObsolete Then Return False

                If tradedType <> TradedItemType.All AndAlso _
                    current.Type <> TradedItemType.All AndAlso _
                    current.Type <> tradedType Then Return False

            End If

            Return True

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
               My.Resources.Common_SecuritySelectDenied)

            Dim myComm As New SQLCommand("FetchServiceInfoList")
            myComm.AddParam("?LN", LanguageCodeLith)

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                Add(ServiceInfo.Empty)

                For Each dr As DataRow In myData.Rows
                    Add(ServiceInfo.GetServiceInfo(dr))
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace