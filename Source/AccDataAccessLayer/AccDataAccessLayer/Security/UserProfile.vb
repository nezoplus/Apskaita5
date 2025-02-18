﻿Imports AccDataAccessLayer.DatabaseAccess
Imports System.Configuration
Namespace Security

    <Serializable()> _
Public Class UserProfile
        Inherits BusinessBase(Of UserProfile)

#Region " Business Methods "

        Private _RealName As String = ""
        Private _Position As String = ""
        Private _Details As String = ""
        Private _Signature As Byte() = Nothing
        Private _UpdateDeniedByServerPolitics As Boolean = True
        Private _UserLevel As Integer = 0


        Public Property RealName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _RealName.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _RealName.Trim <> value.Trim Then
                    _RealName = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Position() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Position.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Position.Trim <> value.Trim Then
                    _Position = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Details() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Details.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Details.Trim <> value.Trim Then
                    _Details = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Signature() As System.Drawing.Image
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return ByteArrayToImage(_Signature)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As System.Drawing.Image)
                CanWriteProperty(True)

                If value Is Nothing AndAlso (_Signature Is Nothing OrElse _
                    Not _Signature.Length > 10) Then Exit Property

                If value Is Nothing Then
                    _Signature = Nothing
                    PropertyHasChanged()
                    Exit Property
                End If

                Dim valueArray As Byte() = ImageToByteArray(value)

                If _Signature Is Nothing OrElse valueArray Is Nothing OrElse _
                    Not _Signature.Equals(valueArray) Then
                    _Signature = valueArray
                    PropertyHasChanged()
                End If

            End Set
        End Property

        Public Property UserLevel() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UserLevel
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If _UserLevel <> value Then
                    _UserLevel = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property UpdateDeniedByServerPolitics() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDeniedByServerPolitics
            End Get
        End Property


        Public Overrides Function Save() As UserProfile

            If _UpdateDeniedByServerPolitics Then Throw New Exception( _
                "Klaida. Serverio politika draudžia vartotojui pačiam keisti savo duomenis.")

            Dim result As UserProfile = MyBase.Save
            InvalidateCache()
            Return result
        End Function

        Protected Overrides Function GetIdValue() As Object
            Return _RealName
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()
            ' TODO: add validation rules
            'ValidationRules.AddRule(Nothing, "")
        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            ' TODO: add authorization rules
            'AuthorizationRules.AllowWrite("", "")
        End Sub

        Public Shared Function CanAddObject() As Boolean
            Return False
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return True
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return True
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return False
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetList() As UserProfile

            Dim result As UserProfile = CacheManager.GetItemFromCache(Of UserProfile)( _
                GetType(UserProfile), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of UserProfile)(New Criteria())
                CacheManager.AddCacheItem(GetType(UserProfile), result, Nothing)
            End If

            Return result

        End Function

        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(UserProfile))
        End Sub

        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(UserProfile))
        End Function

        Private Shared Function IsApplicationWideCache() As Boolean
            Return True
        End Function

        Private Shared Function GetListOnServer() As UserProfile
            Dim result As New UserProfile
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function

        Public Shared Function GetChildList() As UserProfile
            Dim result As New UserProfile
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

            If GetCurrentIdentity.IsLocalUser Then
                MarkOld()
                Exit Sub
            End If

            Dim SqlGenerator As SqlServerSpecificMethods.ISqlGenerator = GetSqlGenerator()

            Dim myComm As New SQLCommand("RawSQL", SqlGenerator.GetFetchUserProfileStatement)

            Using ChangedDb As New ChangedDatabase(GetCurrentIdentity.SecurityDatabase)
                Using myData As DataTable = myComm.Fetch
                    If myData.Rows.Count < 1 Then Throw New Exception( _
                        "Klaida. Sugadinta vartotojų lentelė. Kreipkitės " _
                        & "į sistemos administratorių.")
                    _RealName = myData.Rows(0).Item(0).ToString.Trim
                    _Position = myData.Rows(0).Item(1).ToString.Trim
                    _Details = myData.Rows(0).Item(2).ToString.Trim
                    Try
                        _Signature = CType(myData.Rows(0).Item(3), Byte())
                    Catch ex As Exception
                        _Signature = Nothing
                    End Try
                    _UserLevel = CInt(myData.Rows(0).Item(4))
                    _UpdateDeniedByServerPolitics = _
                        (GetCurrentIdentity.Name.Trim.ToLower <> _
                        SqlGenerator.RootName.Trim.ToLower AndAlso _
                        Not ConfigurationManager.AppSettings( _
                        AppSettingsKey_DenyUserProfileUpdate) Is Nothing)
                End Using
            End Using

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            Dim SqlGenerator As SqlServerSpecificMethods.ISqlGenerator = GetSqlGenerator()

            If GetCurrentIdentity.Name.Trim.ToLower <> SqlGenerator.RootName.Trim.ToLower _
                AndAlso Not ConfigurationManager.AppSettings(AppSettingsKey_DenyUserProfileUpdate) Is Nothing Then _
                Throw New Exception("Klaida. Serverio politika draudžia " _
                & "vartotojui pačiam keisti savo duomenis.")

            Dim myComm As New SQLCommand("RawSQL", SqlGenerator.GetUpdateUserProfileStatement)
            myComm.AddParam("?RN", _RealName)
            myComm.AddParam("?PS", _Position)
            myComm.AddParam("?DT", _Details)
            If _Signature Is Nothing OrElse _Signature.Length < 50 Then
                myComm.AddParam("?SG", Nothing, GetType(Byte()))
            Else
                myComm.AddParam("?SG", _Signature)
            End If
            myComm.AddParam("?LV", _UserLevel)

            If GetCurrentIdentity.IsSecuritySystemInternal Then
                myComm.AddParam("?NM", GetCurrentIdentity.Name)
                myComm.AddParam("?PV", HashPasswordSha256(GetCurrentIdentity.Password))
            End If

            Using ChangedDb As New ChangedDatabase(GetCurrentIdentity.SecurityDatabase)
                myComm.Execute()
            End Using

            MarkOld()

        End Sub

#End Region

    End Class

End Namespace
