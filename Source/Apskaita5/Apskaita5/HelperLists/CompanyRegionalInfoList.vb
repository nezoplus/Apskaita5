﻿Namespace HelperLists

    ''' <summary>
    ''' Represents a list of value objects for <see cref="General.CompanyRegionalData">general company data for different languages</see>.
    ''' </summary>
    ''' <remarks>Values for the base language are stored in the database table imone. 
    ''' Values for other languages are stored in the database table companyregionaldata.</remarks>
    <Serializable()> _
    Public NotInheritable Class CompanyRegionalInfoList
        Inherits ReadOnlyListBase(Of CompanyRegionalInfoList, CompanyRegionalInfo)

#Region " Business Methods "

        ''' <summary>
        ''' Gets general company data for a certain language.
        ''' Returnes null if data if not available in required language.
        ''' </summary>
        ''' <param name="languageCode">A code for required language.</param>
        ''' <remarks>Use null or empty string for base language.</remarks>
        Public Function GetItemByLanguageCode(ByVal languageCode As String) As CompanyRegionalInfo

            If String.IsNullOrEmpty(languageCode) Then
                languageCode = LanguageCodeLith.Trim.ToUpper
            End If

            For Each i As CompanyRegionalInfo In Me
                If i.LanguageCode.Trim.ToUpper = languageCode.Trim.ToUpper Then Return i
            Next

            Return Nothing

        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.CompanyRegionalInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of CompanyRegionalInfo) = Nothing

        ''' <summary>
        ''' Gets a current regional company data value object list from database.
        ''' </summary>
        ''' <remarks>Result is cached.
        ''' Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Function GetList() As CompanyRegionalInfoList

            Dim result As CompanyRegionalInfoList = CacheManager.GetItemFromCache(Of CompanyRegionalInfoList)( _
                GetType(CompanyRegionalInfoList), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of CompanyRegionalInfoList)(New Criteria())
                CacheManager.AddCacheItem(GetType(CompanyRegionalInfoList), result, Nothing)
            End If

            Return result

        End Function

        ''' <summary>
        ''' Gets a filtered view of the current regional data value object list.
        ''' </summary>
        ''' <param name="showEmpty">Wheather to include a placeholder object.</param>
        ''' <remarks>Result is cached.
        ''' Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Function GetCachedFilteredList(ByVal showEmpty As Boolean, _
            ByVal getCodes As Boolean) As System.ComponentModel.BindingList(Of String)

            Dim filterToApply(1) As Object
            filterToApply(0) = showEmpty
            filterToApply(1) = getCodes

            Dim result As System.ComponentModel.BindingList(Of String) = _
                CacheManager.GetItemFromCache(Of System.ComponentModel.BindingList(Of String)) _
                (GetType(CompanyRegionalInfoList), filterToApply)

            If result Is Nothing Then

                Dim baseList As CompanyRegionalInfoList = _
                    CompanyRegionalInfoList.GetList
                result = New System.ComponentModel.BindingList(Of String)
                If showEmpty Then result.Add("")
                For Each i As CompanyRegionalInfo In baseList
                    If getCodes Then
                        result.Add(i.LanguageCode)
                    Else
                        result.Add(i.LanguageName)
                    End If
                Next
                CacheManager.AddCacheItem(GetType(CompanyRegionalInfoList), _
                    result, filterToApply)

            End If

            Return result

        End Function

        ''' <summary>
        ''' Invalidates the current value object list cache 
        ''' so that the next <see cref="GetList">GetList</see> call would hit the database.
        ''' </summary>
        ''' <remarks>Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(CompanyRegionalInfoList))
        End Sub

        ''' <summary>
        ''' Returnes true if the cache does not contain a current regional company data value object list.
        ''' </summary>
        ''' <remarks>Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(CompanyRegionalInfoList))
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
        ''' Gets a current regional data value object list from database bypassing dataportal.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>Should only be called server side.
        ''' Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Private Shared Function GetListOnServer() As CompanyRegionalInfoList
            Dim result As New CompanyRegionalInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function


        ''' <summary>
        ''' Gets a sortable view of the list.
        ''' </summary>
        ''' <remarks>Used to implement automatic sort in datagridview.</remarks>
        Public Function GetSortedList() As Csla.SortedBindingList(Of CompanyRegionalInfo)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of CompanyRegionalInfo)(Me)
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
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As New SQLCommand("FetchCompanyRegionalInfoList")
            myComm.AddParam("?LC", LanguageCodeLith.Trim.ToUpper)
            myComm.AddParam("?IT", Utilities.ConvertDatabaseCharID(General.CompanyBinaryDataType.InvoiceForm))
            myComm.AddParam("?LT", Utilities.ConvertDatabaseCharID(General.CompanyBinaryDataType.Logo))
            myComm.AddParam("?AT", Utilities.ConvertDatabaseCharID(General.CompanyBinaryDataType.ProformaInvoiceForm))

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                For Each dr As DataRow In myData.Rows
                    Add(CompanyRegionalInfo.GetCompanyRegionalInfo(dr))
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace