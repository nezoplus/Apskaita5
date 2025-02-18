﻿Imports System.Security.Principal
Imports System.Configuration
Imports MySql.Data.MySqlClient

Namespace Security

    <Serializable()> _
    Public Class AccIdentity
        Inherits Csla.ReadOnlyBase(Of AccIdentity)
        Implements IIdentity

#Region " Business Methods "

        Protected Overrides Function GetIdValue() As Object
            Return mName
        End Function

#Region " IsInRole "

        Private mRoles As New List(Of String)
        Friend Function IsInRole(ByVal role As String) As Boolean
            ' admin has all the rights
            If mRoles.Contains(Name_AdminRole) Then Return True
            If role.ToLower.Trim = Name_AdminRole.Trim.ToLower Then Return False
            If role.ToLower.Trim = "suspended" Then Return (mRoles.Count < 1)

            ' check for priviledge type and level
            For i As Integer = 1 To mRoles.Count
                If mRoles(i - 1).Substring(0, mRoles(i - 1).Length - 1).ToLower = _
                    role.Substring(0, role.Length - 1).ToLower AndAlso _
                    CInt(mRoles(i - 1).Substring(mRoles(i - 1).Length - 1)) >= _
                    CInt(role.Substring(role.Length - 1)) Then
                    Return True
                End If
            Next
            Return False
        End Function

#End Region

#Region " IIdentity "

        Private mIsAuthenticated As Boolean = False
        Private mName As String = ""

        Public ReadOnly Property AuthenticationType() As String _
          Implements System.Security.Principal.IIdentity.AuthenticationType
            Get
                Return "Csla"
            End Get
        End Property

        Public ReadOnly Property IsAuthenticated() As Boolean _
          Implements System.Security.Principal.IIdentity.IsAuthenticated
            Get
                Return mIsAuthenticated
            End Get
        End Property

        Public ReadOnly Property Name() As String _
          Implements System.Security.Principal.IIdentity.Name
            Get
                Return mName
            End Get
        End Property

#End Region

#Region " Custom "

        Public ReadOnly Property IsAuthenticatedWithDB() As Boolean
            Get
                Return mIsAuthenticated AndAlso Not String.IsNullOrEmpty(_Database.Trim)
            End Get
        End Property

        Private _UserRealName As String = ""
        ''' <summary>
        ''' Gets the real name of the current user (from security database).
        ''' </summary>
        Public ReadOnly Property UserRealName() As String
            Get
                Return _UserRealName
            End Get
        End Property

        Private _Password As String = ""
        ''' <summary>
        ''' Gets the password of the user. Friend set is only for internal use
        ''' (only used by CommandChangePassword object)
        ''' </summary>
        Public Property Password() As String
            Get
                Return _Password
            End Get
            Friend Set(ByVal value As String)
                _Password = value
            End Set
        End Property

        Private _Ticket As String = ""
        ''' <summary>
        ''' Gets the application server ticket for the user. 
        ''' </summary>
        Public ReadOnly Property Ticket() As String
            Get
                Return _Ticket
            End Get
        End Property

        Private _ConnType As ConnectionType = ConnectionType.Local
        ''' <summary>
        ''' Gets the connection technology to be used (local, remoting, enterprise services or web services).
        ''' </summary>
        Public ReadOnly Property ConnectionType() As ConnectionType
            Get
                Return _ConnType
            End Get
        End Property

        Private _SqlServerType As SqlServerType = DataAccessTypes.SqlServerType.SQLite
        ''' <summary>
        ''' Gets the SQL server type to be used (MySQL, SQLite).
        ''' </summary>
        Public ReadOnly Property SqlServerType() As SqlServerType
            Get
                If ApplicationContext.ExecutionLocation = ExecutionLocations.Server _
                    OrElse IsWebServer(_IsWebServerImpersonation) Then
                    Return ConvertSqlServerTypeHumanReadable( _
                        ConfigurationManager.AppSettings(AppSettingsKey_SqlServerType))
                Else
                    Return _SqlServerType
                End If
            End Get
        End Property

        Private _Server As String = ""
        ''' <summary>
        ''' Gets the SQL server IP address.
        ''' </summary>
        Public ReadOnly Property SQLServer() As String
            Get
                If ApplicationContext.ExecutionLocation = ExecutionLocations.Server _
                    OrElse IsWebServer(_IsWebServerImpersonation) Then
                    Return ConfigurationManager.AppSettings(AppSettingsKey_SqlServerName)
                Else
                    Return _Server
                End If
            End Get
        End Property

        Private _Port As String = ""
        ''' <summary>
        ''' Gets the SQL server port.
        ''' </summary>
        Public ReadOnly Property SQLPort() As String
            Get
                If ApplicationContext.ExecutionLocation = ExecutionLocations.Server _
                    OrElse IsWebServer(_IsWebServerImpersonation) Then
                    Return ConfigurationManager.AppSettings(AppSettingsKey_SqlPort)
                Else
                    Return _Port
                End If
            End Get
        End Property

        ''' <summary>
        ''' Returns TRUE if SQL server is file based.
        ''' </summary>
        Public ReadOnly Property IsSqlServerFileBased() As Boolean
            Get
                Return DatabaseAccess.GetSqlGenerator(SqlServerType).SqlServerFileBased
            End Get
        End Property

        Private _IsLocalUser As Boolean = False
        ''' <summary>
        ''' Returns TRUE if user only operates local file databases without SQL server.
        ''' </summary>
        Public ReadOnly Property IsLocalUser() As Boolean
            Get
                Return _IsLocalUser
            End Get
        End Property

        Private _Database As String = ""
        ''' <summary>
        ''' Gets the currently used DB name.
        ''' Set method should only be used when creating new company or setting users rights.
        ''' </summary>
        Public Property Database() As String
            Get
                Return _Database
            End Get
            Friend Set(ByVal value As String)
                _Database = value
            End Set
        End Property

        Private _DatabaseNamingConvention As String = ""
        ''' <summary>
        ''' Gets the DB naming convention that is applied on SQL server.
        ''' </summary>
        Public ReadOnly Property DatabaseNamingConvention() As String
            Get
                If ApplicationContext.ExecutionLocation = ExecutionLocations.Server _
                    OrElse IsWebServer(_IsWebServerImpersonation) Then
                    Return ConfigurationManager.AppSettings(AppSettingsKey_DatabaseNamingConvention)
                Else
                    Return _DatabaseNamingConvention
                End If
            End Get
        End Property

        ''' <summary>
        ''' Gets the security DB name on SQL server.
        ''' </summary>
        Friend ReadOnly Property SecurityDatabase() As String
            Get
                Dim result As String = DatabaseNamingConvention.Trim
                result = result.Substring(0, result.Length - Name_SecurityDatabaseCode.Length) _
                    & Name_SecurityDatabaseCode
                Return result
            End Get
        End Property

        ''' <summary>
        ''' Gets the connection string to the current SQL server and database.
        ''' </summary>
        Public ReadOnly Property ConnString() As String
            Get
                Return DatabaseAccess.GetSqlCommandManager(Me.SqlServerType).GetConnectionString(Me)
            End Get
        End Property

        Private _UseSSL As Boolean = False
        ''' <summary>
        ''' Indicates whether SSL is used for connection.
        ''' </summary>
        Public ReadOnly Property UseSSL() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UseSSL
            End Get
        End Property

        ''' <summary>
        ''' Indicates whether SSL is used for SQL connection.
        ''' </summary>
        Public ReadOnly Property SqlUseSSL() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If ApplicationContext.ExecutionLocation = ExecutionLocations.Server _
                    OrElse IsWebServer(_IsWebServerImpersonation) Then
                    Return Boolean.Parse(ConfigurationManager.AppSettings(AppSettingsKey_UseSSL))
                Else
                    Return _UseSSL
                End If
            End Get
        End Property

        Private _SslCertificateFile As String = ""
        Public ReadOnly Property SslCertificateFile() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If ApplicationContext.ExecutionLocation = ExecutionLocations.Server _
                    OrElse IsWebServer(_IsWebServerImpersonation) Then
                    Return ConfigurationManager.AppSettings(AppSettingsKey_SSLCertificateFile)
                Else
                    Return _SslCertificateFile.Trim
                End If
            End Get
        End Property

        Private _SslCertificateInstalled As Boolean = False
        Public ReadOnly Property SslCertificateInstalled() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If ApplicationContext.ExecutionLocation = ExecutionLocations.Server _
                    OrElse IsWebServer(_IsWebServerImpersonation) Then
                    Return Boolean.Parse(ConfigurationManager.AppSettings(AppSettingsKey_SSLCertificateInstalled))
                Else
                    Return _SslCertificateInstalled
                End If
            End Get
        End Property

        Private _SslCertificatePassword As String = ""
        Public ReadOnly Property SslCertificatePassword() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If ApplicationContext.ExecutionLocation = ExecutionLocations.Server _
                    OrElse IsWebServer(_IsWebServerImpersonation) Then
                    Return ConfigurationManager.AppSettings(AppSettingsKey_SSLCertificatePassword)
                Else
                    Return _SslCertificatePassword.Trim
                End If
            End Get
        End Property

        Private _CannotSetGrants As Boolean = True
        Public ReadOnly Property CannotSetGrants() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If ApplicationContext.ExecutionLocation = ExecutionLocations.Server _
                    OrElse IsWebServer(_IsWebServerImpersonation) Then
                    Return Boolean.Parse(ConfigurationManager.AppSettings(AppSettingsKey_SecuritySystemInternal)) _
                        OrElse Boolean.Parse(ConfigurationManager.AppSettings(AppSettingsKey_CannotSetSqlGrants))
                Else
                    Return _CannotSetGrants
                End If
            End Get
        End Property

        Private _IsWebServerImpersonation As Boolean = False
        Public ReadOnly Property IsWebServerImpersonation() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsWebServerImpersonation
            End Get
        End Property

        Private _SqlConnectionCharSet As String = ""
        Public ReadOnly Property SqlConnectionCharSet() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SqlConnectionCharSet.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets the DB naming convention that is applied on SQL server.
        ''' </summary>
        Public ReadOnly Property IsSecuritySystemInternal() As Boolean
            Get
                If ApplicationContext.ExecutionLocation = ExecutionLocations.Server _
                    OrElse IsWebServer(_IsWebServerImpersonation) Then
                    Return Boolean.Parse(ConfigurationManager.AppSettings(AppSettingsKey_SecuritySystemInternal))
                Else
                    Return False
                End If
            End Get
        End Property


        Public Function GetApplicationServerUrl() As String

            If _ConnType = DataAccessTypes.ConnectionType.Local Then
                Return _Server & ":" & Me._Port
            ElseIf _ConnType = DataAccessTypes.ConnectionType.EnerpriseServices Then
                Return ConfigurationManager.AppSettings(AppSettingsKey_Proxy)
            Else
                Return ConfigurationManager.AppSettings(AppSettingsKey_URL)
            End If

        End Function

        ''' <summary>
        ''' Gets the SQL host in use on application server (usually localhost).
        ''' </summary>
        Friend Function GetSqlHostOnRemoteServer() As String
            If ApplicationContext.ExecutionLocation = ExecutionLocations.Server _
                OrElse IsWebServer(_IsWebServerImpersonation) Then
                Return ConfigurationManager.AppSettings(AppSettingsKey_SqlDefaultUserHost)
            Else
                Return ""
            End If
        End Function

        ''' <summary>
        ''' Set the connection technology to be used (local, remoting, enterprise services or web services).
        ''' </summary>
        ''' <param name="ConnType"> Connection technology to be used.</param>
        ''' <param name="ServerURL"> If remoting or web service connection technology 
        ''' is chosen, sets the server URL path. If enterprise services technology
        ''' is chosen, sets the name of COM+ registered assembly. </param>
        Private Shared Sub SetConnectionType(ByVal ConnType As ConnectionType, _
            Optional ByVal ServerURL As String = "")

            Try

                SetConnectionTypeUsingReadOnlyOverride(ConnType, ServerURL)

            Catch ex As Exception

                Try
                    SetConnectionTypeUsingXML(ConnType, ServerURL)
                Catch e As Exception

                    Dim InnerEx As New Exception(e.Message, ex)
                    InnerEx.Source = e.Source

                    Throw New Exception("Klaida. Neveikia nė vienas ryšio technologijos " _
                        & "nustatymo metodas. Bandykite iš naujo paleisti programą " _
                        & "administratoriaus teisėmis.", InnerEx)

                End Try

            End Try

        End Sub

        ''' <summary>
        ''' Tries to change appSettings directly with ConfigurationManager.AppSettings.Add, 
        ''' ConfigurationManager.AppSettings.Remove methods. AppSettings are readonly 
        ''' by default, so this method only works when ConfigProxy is used in the program.
        ''' </summary>
        ''' <param name="ConnType"> Connection technology to be used.</param>
        ''' <param name="ServerURL"> If remoting or web service connection technology 
        ''' is chosen, sets the server URL path. If enterprise services technology
        ''' is chosen, sets the name of COM+ registered assembly. </param>
        Private Shared Sub SetConnectionTypeUsingReadOnlyOverride(ByVal ConnType As ConnectionType, _
            ByVal ServerURL As String)

            Try
                System.Configuration.ConfigurationManager.AppSettings.Remove(AppSettingsKey_Proxy)
            Catch ex As Exception
            End Try
            Try
                System.Configuration.ConfigurationManager.AppSettings.Remove(AppSettingsKey_URL)
            Catch ex As Exception
            End Try

            If ConnType = ConnectionType.Local Then Exit Sub

            If ConnType = ConnectionType.EnerpriseServices Then
                System.Configuration.ConfigurationManager.AppSettings.Add( _
                    AppSettingsKey_Proxy, AppSettingsKey_Enterprise & ServerURL)
            ElseIf ConnType = ConnectionType.Remoting Then
                System.Configuration.ConfigurationManager.AppSettings.Add( _
                    AppSettingsKey_Proxy, AppSettingsKey_Remoting)
            ElseIf ConnType = ConnectionType.WebService Then
                System.Configuration.ConfigurationManager.AppSettings.Add( _
                    AppSettingsKey_Proxy, AppSettingsKey_WebService)
            End If

            If ConnType = ConnectionType.Remoting OrElse ConnType = ConnectionType.WebService Then
                System.Configuration.ConfigurationManager.AppSettings.Add( _
                    AppSettingsKey_URL, ServerURL)
            End If

        End Sub

        ''' <summary>
        ''' Tries to change appSettings by loading settings file as a xml file,
        ''' modifying it and saving back directly. "Manual" saving of app.config file
        ''' as well as saving any other file in Program Files folder requires 
        ''' admin user or power user. Thus this method only works for such users.
        ''' </summary>
        ''' <param name="ConnType"> Connection technology to be used.</param>
        ''' <param name="ServerURL"> If remoting or web service connection technology 
        ''' is chosen, sets the server URL path. If enterprise services technology
        ''' is chosen, sets the name of COM+ registered assembly. </param>
        ''' <remarks>Secondary method after SetConnectionTypeUsingReadOnlyOverride.</remarks>
        Private Shared Sub SetConnectionTypeUsingXML(ByVal ConnType As ConnectionType, _
            ByVal ServerURL As String)


            Dim xmlSett As New Xml.XmlDocument()
            xmlSett.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)

            Dim appSettingsNode As Xml.XmlNode = xmlSett.SelectSingleNode("configuration/appSettings")

            For i As Integer = appSettingsNode.ChildNodes.Count To 1 Step -1
                If appSettingsNode.ChildNodes(i - 1).Attributes("key").Value.Trim.ToLower _
                    = AppSettingsKey_Proxy.Trim.ToLower OrElse _
                    appSettingsNode.ChildNodes(i - 1).Attributes("key").Value.Trim.ToLower _
                    = AppSettingsKey_URL.Trim.ToLower Then appSettingsNode.RemoveChild( _
                        appSettingsNode.ChildNodes(i - 1))
            Next

            If ConnType = ConnectionType.Local Then
                xmlSett.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)
                System.Configuration.ConfigurationManager.RefreshSection("appSettings")
                Exit Sub
            End If

            Dim newChild As Xml.XmlNode = appSettingsNode.FirstChild.Clone()
            newChild.Attributes("key").Value = AppSettingsKey_Proxy
            If ConnType = ConnectionType.EnerpriseServices Then
                newChild.Attributes("value").Value = AppSettingsKey_Enterprise & ServerURL
            ElseIf ConnType = ConnectionType.Remoting Then
                newChild.Attributes("value").Value = AppSettingsKey_Remoting
            ElseIf ConnType = ConnectionType.WebService Then
                newChild.Attributes("value").Value = AppSettingsKey_WebService
            End If
            appSettingsNode.AppendChild(newChild)

            If ConnType = ConnectionType.Remoting OrElse ConnType = ConnectionType.WebService Then
                Dim newChild2 As Xml.XmlNode = appSettingsNode.FirstChild.Clone()
                newChild2.Attributes("key").Value = AppSettingsKey_URL
                newChild2.Attributes("value").Value = ServerURL
                appSettingsNode.AppendChild(newChild2)
            End If

            xmlSett.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)
            System.Configuration.ConfigurationManager.RefreshSection("appSettings")

        End Sub

        Private Shared Function GetConnectionType() As ConnectionType

            If System.Configuration.ConfigurationManager.AppSettings( _
                AppSettingsKey_Proxy) Is Nothing OrElse String.IsNullOrEmpty( _
                System.Configuration.ConfigurationManager.AppSettings(AppSettingsKey_Proxy).Trim) Then _
                Return DataAccessTypes.ConnectionType.Local

            If System.Configuration.ConfigurationManager.AppSettings( _
                AppSettingsKey_Proxy).Trim.ToLower.StartsWith(AppSettingsKey_Enterprise.Trim.ToLower) Then
                Return DataAccessTypes.ConnectionType.EnerpriseServices
            ElseIf System.Configuration.ConfigurationManager.AppSettings( _
                AppSettingsKey_Proxy).Trim.ToLower.StartsWith(AppSettingsKey_Remoting.Trim.ToLower) Then
                Return DataAccessTypes.ConnectionType.Remoting
            ElseIf System.Configuration.ConfigurationManager.AppSettings( _
                AppSettingsKey_Proxy).Trim.ToLower.StartsWith(AppSettingsKey_WebService.Trim.ToLower) Then
                Return DataAccessTypes.ConnectionType.WebService
            Else
                Throw New NotImplementedException("Klaida. Proxy tipas '" _
                    & System.Configuration.ConfigurationManager.AppSettings(AppSettingsKey_Proxy) _
                    & "' neimplementuotas funkcijoje GetConnectionType.")
            End If

        End Function

        Public Function GetSqlServerWildCart() As String
            ' default for local user is SQLite
            If _IsLocalUser Then Return (New SqlServerSpecificMethods.SQLiteGenerator).Wildcart
            Return DatabaseAccess.GetSqlGenerator(Me.SqlServerType).Wildcart
        End Function

        Friend Sub SetUserRealName(ByVal uName As String)
            _UserRealName = uName
        End Sub

        Friend Sub SetPasswordForLocalUser(ByVal nPassword As String)

            If Not _IsLocalUser Then Throw New InvalidOperationException("User is not a local user.")

            _Password = nPassword

        End Sub

        Public Function IsAdmin() As Boolean
            Return mRoles.Contains(Name_AdminRole)
        End Function

#End Region

#End Region

#Region " Factory Methods "

        Friend Shared Function UnauthenticatedIdentity() As AccIdentity
            Return New AccIdentity
        End Function

        ''' <summary>
        ''' Gets the AccIdentity object for primary login in local mode, 
        ''' i.e. direct connection to SQL server.
        ''' </summary>
        ''' <param name="cUsername"> Username to be used.</param>
        ''' <param name="cPassword"> Password to be used. </param>
        ''' <param name="cSQLServer"> SQL server address (only if no remoting technology is used). </param>
        ''' <param name="cSQLPort"> SQL server port (only if no remoting technology is used). </param>
        ''' <param name="cSqlServerType">SQL server type (MySQL, SQLite, etc.).</param>
        ''' <param name="cCacheManager">Object implementing the ICacheManager interface 
        ''' (it's instance methods calls shared methods that manage cache objects)</param>
        Friend Shared Function GetIdentity(ByVal cUsername As String, ByVal cPassword As String, _
            ByVal cSQLServer As String, ByVal cSQLPort As String, ByVal cSqlServerType As SqlServerType, _
            ByVal cDatabaseNamingConvention As String, ByVal cUseSSL As Boolean, _
            ByVal cSslCertificateFileName As String, ByVal cSslCertificatePassword As String, _
            ByVal cSslCertificateInstalled As Boolean, ByVal cCannotSetGrants As Boolean, _
            ByVal cCacheManager As ICacheManager, ByVal cSqlConnectionCharSet As String) As AccIdentity

            If String.IsNullOrEmpty(cUsername.Trim) Then Throw New Exception( _
                "Klaida. Nenurodytas vartotojo vardas.")
            If String.IsNullOrEmpty(cPassword.Trim) Then Throw New Exception( _
                "Klaida. Nenurodytas vartotojo slaptažodis.")
            If String.IsNullOrEmpty(cSQLServer.Trim) Then Throw New Exception( _
                "Klaida. Nenurodytas SQL serverio adresas.")
            If String.IsNullOrEmpty(cSQLPort.Trim) OrElse _
                Not Integer.TryParse(cSQLPort.Trim, New Integer) Then Throw New Exception( _
                "Klaida. Nenurodytas SQL serverio adresas.")
            If String.IsNullOrEmpty(cDatabaseNamingConvention.Trim) Then Throw New Exception( _
                "Klaida. Nenurodyta duomenų bazių vadinimo pagrindas SQL serveryje.")
            If cCacheManager Is Nothing Then Throw New Exception( _
                "Klaida. Nenurodytas CacheManager objektas.")

            SetConnectionType(DataAccessTypes.ConnectionType.Local)

            Return DataPortal.Fetch(Of AccIdentity)(New Criteria(cUsername, cPassword, _
                cSQLServer, cSQLPort, cSqlServerType, cDatabaseNamingConvention, _
                cUseSSL, cSslCertificateFileName, cSslCertificatePassword, _
                cSslCertificateInstalled, cCannotSetGrants, cCacheManager, cSqlConnectionCharSet))
        End Function

        ''' <summary>
        ''' Gets the AccIdentity object for primary login through application server, i.e. not Local mode.
        ''' </summary>
        ''' <param name="cUsername"> Username to be used.</param>
        ''' <param name="cPassword"> Password to be used. </param>
        ''' <param name="cConnType"> Remote access technology to be used. </param>
        ''' <param name="cURL"> Address of the application server.</param>
        ''' <param name="cCacheManager">Object implementing the ICacheManager interface 
        ''' (it's instance methods calls shared methods that manage cache objects)</param>
        Friend Shared Function GetIdentity(ByVal cUsername As String, ByVal cPassword As String, _
            ByVal cConnType As ConnectionType, ByVal cURL As String, _
            ByVal cUseSSL As Boolean, ByVal cSslCertificateFileName As String, _
            ByVal cSslCertificatePassword As String, ByVal cSslCertificateInstalled As Boolean, _
            ByVal cCacheManager As ICacheManager) As AccIdentity

            If String.IsNullOrEmpty(cUsername.Trim) Then Throw New Exception( _
                "Klaida. Nenurodytas vartotojo vardas.")
            If String.IsNullOrEmpty(cPassword.Trim) Then Throw New Exception( _
                "Klaida. Nenurodytas vartotojo slaptažodis.")
            If String.IsNullOrEmpty(cURL.Trim) Then Throw New Exception( _
                "Klaida. Nenurodytas programos serverio (application server) adresas (URL).")
            If cCacheManager Is Nothing Then Throw New Exception( _
                "Klaida. Nenurodytas CacheManager objektas.")
            If cConnType = DataAccessTypes.ConnectionType.Local Then Throw New Exception( _
                "Klaida. Nenurodyta ryšio su programos serveriu technologija.")

            SetConnectionType(cConnType, cURL)

            Return DataPortal.Fetch(Of AccIdentity)(New Criteria(cUsername, cPassword, _
                cConnType, cUseSSL, cSslCertificateFileName, cSslCertificatePassword, _
                cSslCertificateInstalled, cCacheManager))

        End Function

        ''' <summary>
        ''' Gets the AccIdentity object for local user.
        ''' </summary>
        Friend Shared Function GetLocalUserIdentity(ByVal cSqlServerType As SqlServerType) As AccIdentity

            If Not DatabaseAccess.GetSqlGenerator(cSqlServerType).SqlServerFileBased _
                Then Throw New Exception("Klaida. Pasirinktas SQL serverio tipas nėra failinis.")

            SetConnectionType(ConnectionType.Local)

            Return New AccIdentity(cSqlServerType, Nothing)

        End Function

        ''' <summary>
        ''' Gets the AccIdentity object with database by the AccIdentity object provided (secondary login).
        ''' </summary>
        ''' <param name="cDatabase"> Name of the database on SQL server to connect to (if any). </param>
        Friend Shared Function GetIdentity(ByVal cDatabase As String, ByVal cCacheManager As ICacheManager, _
            Optional ByVal cPassword As String = "") As AccIdentity

            If cCacheManager Is Nothing Then Throw New Exception( _
                "Klaida. Nenurodytas CacheManager objektas.")

            Dim CurrIdentity As AccIdentity = CType(CType(ApplicationContext.User, AccPrincipal).Identity, _
                AccIdentity)

            If CurrIdentity.IsLocalUser Then

                If String.IsNullOrEmpty(cDatabase.Trim) Then
                    CurrIdentity._Database = ""
                    If Not CurrIdentity.IsInRole(Name_AdminRole) Then CurrIdentity.mRoles.Clear()
                    cCacheManager.ClearCache()
                    Return CurrIdentity
                End If

                Return New AccIdentity(CurrIdentity.SqlServerType, cCacheManager, cDatabase, cPassword)

            End If

            Return DataPortal.Fetch(Of AccIdentity)(New Criteria(CurrIdentity, cDatabase, _
                cPassword, cCacheManager))

        End Function

        ''' <summary>
        ''' Gets the AccIdentity object for web server.
        ''' </summary>
        ''' <param name="cUserName"> Name of the user. </param>
        ''' <param name="cPassword"> Password of the user. </param>
        ''' <param name="cCacheManager"> Cache manager that is supposed to manage cache. </param>
        Friend Shared Function GetIdentity(ByVal cUserName As String, ByVal cPassword As String, _
            ByVal cCacheManager As ICacheManager) As AccIdentity

            If String.IsNullOrEmpty(cUserName.Trim) Then Throw New Exception( _
                "Klaida. Nenurodytas vartotojo vardas.")
            If String.IsNullOrEmpty(cPassword.Trim) Then Throw New Exception( _
                "Klaida. Nenurodytas vartotojo slaptažodis.")
            If cCacheManager Is Nothing Then Throw New Exception( _
                "Klaida. Nenurodytas CacheManager objektas.")

            Return DataPortal.Fetch(Of AccIdentity)(New Criteria(cUserName, cPassword, _
                GetConnectionType, cCacheManager))

        End Function

        ''' <summary>
        ''' Gets the AccIdentity object for web server impersonation.
        ''' </summary>
        ''' <param name="cUserName"> Name of the server user. </param>
        ''' <param name="cDatabase"> Password of the user. </param>
        ''' <param name="cCacheManager"> Cache manager that is supposed to manage cache. </param>
        Friend Shared Function GetServerIdentity(ByVal cUserName As String, ByVal cDatabase As String) As AccIdentity

            If String.IsNullOrEmpty(cDatabase.Trim) Then Throw New ArgumentNullException( _
                "Klaida. Nenurodyta duomenų bazė.")
            If cUserName Is Nothing OrElse String.IsNullOrEmpty(cUserName.Trim) Then cUserName = "WebServer"

            Return New AccIdentity(cUserName, cDatabase)

        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

        ''' <summary>
        ''' New overload for local user.
        ''' </summary>
        ''' <param name="cSqlServerType"></param>
        ''' <remarks></remarks>
        Private Sub New(ByVal cSqlServerType As SqlServerType, ByVal cCacheManager As ICacheManager, _
            Optional ByVal cDatabaseName As String = "", Optional ByVal cPassword As String = "")

            _ConnType = ConnectionType.Local
            mIsAuthenticated = True
            mName = "Local User"
            mRoles = New List(Of String)
            mRoles.Add(Name_AdminRole)
            _Database = ""
            _IsLocalUser = True
            _Password = ""
            _Port = ""
            _Server = ""
            _SqlServerType = cSqlServerType

            If Not String.IsNullOrEmpty(cDatabaseName) Then

                _Database = cDatabaseName
                _Password = cPassword

                Dim result As New List(Of String)

                DatabaseAccess.TryLogin(Me, result)

                mRoles = result
                mIsAuthenticated = True

                If Not cCacheManager Is Nothing Then _
                    cCacheManager.AddCompanyInfoToLocalContext(_Database, _Password)

            End If

        End Sub

        ''' <summary>
        ''' New overload for server impersonation.
        ''' </summary>
        ''' <param name="cSqlServerType"></param>
        ''' <remarks></remarks>
        Private Sub New(ByVal cUserName As String, ByVal cDatabase As String)

            _ConnType = ConnectionType.Local
            mIsAuthenticated = True
            mName = cUserName
            mRoles = New List(Of String)
            mRoles.Add(Name_AdminRole)

            _Database = cDatabase
            _IsLocalUser = False
            _IsWebServerImpersonation = True

            _Password = ""

        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria

            Private mUsername As String = ""
            Private mUserRealName As String = ""
            Private mPassword As String = ""
            Private mServer As String = ""
            Private mPort As String = "3068"
            Private mConnType As ConnectionType = DataAccessTypes.ConnectionType.Local
            Private mDatabase As String = ""
            Private mSqlServerType As SqlServerType = DataAccessTypes.SqlServerType.MySQL
            Private mIsLocalUser As Boolean = False
            Private mCacheManager As ICacheManager = Nothing
            Private mDatabaseNamingConvention As String = ""
            Private _UseSSL As Boolean = False
            Private _SslCertificateFile As String = ""
            Private _SslCertificateInstalled As Boolean = False
            Private _SslCertificatePassword As String = ""
            Private _CannotSetGrants As Boolean = False
            Private _SqlConnectionCharSet As String = ""

            Public ReadOnly Property Username() As String
                Get
                    Return mUsername
                End Get
            End Property
            Public ReadOnly Property UserRealName() As String
                Get
                    Return mUserRealName
                End Get
            End Property
            Public ReadOnly Property Password() As String
                Get
                    Return mPassword
                End Get
            End Property
            Public ReadOnly Property Server() As String
                Get
                    Return mServer
                End Get
            End Property
            Public ReadOnly Property Port() As String
                Get
                    Return mPort
                End Get
            End Property
            Public ReadOnly Property ConnectionType() As ConnectionType
                Get
                    Return mConnType
                End Get
            End Property
            Public ReadOnly Property Database() As String
                Get
                    Return mDatabase
                End Get
            End Property
            Public ReadOnly Property SqlServerType() As SqlServerType
                Get
                    Return mSqlServerType
                End Get
            End Property
            Public ReadOnly Property IsLocalUser() As Boolean
                Get
                    Return mIsLocalUser
                End Get
            End Property
            Public ReadOnly Property CacheManager() As ICacheManager
                Get
                    Return mCacheManager
                End Get
            End Property
            Public ReadOnly Property DatabaseNamingConvention() As String
                Get
                    Return mDatabaseNamingConvention
                End Get
            End Property
            Public ReadOnly Property UseSSL() As Boolean
                Get
                    Return _UseSSL
                End Get
            End Property
            Public ReadOnly Property SslCertificateFile() As String
                Get
                    Return _SslCertificateFile.Trim
                End Get
            End Property
            Public ReadOnly Property SslCertificateInstalled() As Boolean
                Get
                    Return _SslCertificateInstalled
                End Get
            End Property
            Public ReadOnly Property SslCertificatePassword() As String
                Get
                    Return _SslCertificatePassword.Trim
                End Get
            End Property
            Public ReadOnly Property CannotSetGrants() As Boolean
                Get
                    Return _CannotSetGrants
                End Get
            End Property
            Public ReadOnly Property SqlConnectionCharSet() As String
                Get
                    Return _SqlConnectionCharSet
                End Get
            End Property
            Public Sub New(ByVal cUsername As String, ByVal cPassword As String, _
                ByVal cSQLServer As String, ByVal cSQLPort As String, _
                ByVal cSqlServerType As SqlServerType, ByVal cDatabaseNamingConvention As String, _
                ByVal cUseSSL As Boolean, ByVal cSslCertificateFileName As String, _
                ByVal cSslCertificatePassword As String, ByVal cSslCertificateInstalled As Boolean, _
                ByVal cCannotSetGrants As Boolean, ByVal cCacheManager As ICacheManager, _
                ByVal cSqlConnectionCharSet As String)
                mUsername = cUsername
                mPassword = cPassword
                mServer = cSQLServer
                mPort = cSQLPort
                mConnType = DataAccessTypes.ConnectionType.Local
                mDatabase = ""
                mSqlServerType = cSqlServerType
                mIsLocalUser = False
                mCacheManager = cCacheManager
                mDatabaseNamingConvention = cDatabaseNamingConvention
                _UseSSL = _UseSSL
                _SslCertificateFile = cSslCertificateFileName
                _SslCertificateInstalled = cSslCertificateInstalled
                _SslCertificatePassword = cSslCertificatePassword
                _CannotSetGrants = cCannotSetGrants
                _SqlConnectionCharSet = cSqlConnectionCharSet
            End Sub
            Public Sub New(ByVal cUsername As String, ByVal cPassword As String, _
                ByVal cConnType As ConnectionType, ByVal cUseSSL As Boolean, _
                ByVal cSslCertificateFileName As String, ByVal cSslCertificatePassword As String, _
                ByVal cSslCertificateInstalled As Boolean, ByVal cCacheManager As ICacheManager)
                mUsername = cUsername
                mPassword = cPassword
                mServer = ""
                mPort = "3306"
                mConnType = cConnType
                mDatabase = ""
                mSqlServerType = DataAccessTypes.SqlServerType.MySQL
                mIsLocalUser = False
                mCacheManager = cCacheManager
                mDatabaseNamingConvention = "apskaita"
                _UseSSL = _UseSSL
                _SslCertificateFile = cSslCertificateFileName
                _SslCertificateInstalled = cSslCertificateInstalled
                _SslCertificatePassword = cSslCertificatePassword
            End Sub
            Public Sub New(ByVal cIdentity As AccIdentity, ByVal cDatabase As String, _
                ByVal cPassword As String, ByVal cCacheManager As ICacheManager)
                mUsername = cIdentity.Name
                mPassword = cIdentity.Password
                mConnType = cIdentity.ConnectionType
                mDatabase = cDatabase
                mServer = cIdentity.SQLServer
                mPort = cIdentity.SQLPort
                mSqlServerType = cIdentity.SqlServerType
                mIsLocalUser = cIdentity.IsLocalUser
                If Not String.IsNullOrEmpty(cPassword.Trim) Then mPassword = cPassword
                mCacheManager = cCacheManager
                mDatabaseNamingConvention = cIdentity.DatabaseNamingConvention
                mUserRealName = cIdentity._UserRealName
                _UseSSL = cIdentity.UseSSL
                _SslCertificateFile = cIdentity.SslCertificateFile
                _SslCertificateInstalled = cIdentity.SslCertificateInstalled
                _SslCertificatePassword = cIdentity.SslCertificatePassword
                _CannotSetGrants = cIdentity.CannotSetGrants
                _SqlConnectionCharSet = cIdentity.SqlConnectionCharSet
            End Sub
            Public Sub New(ByVal cUsername As String, ByVal cPassword As String, _
                ByVal cConnType As DataAccessTypes.ConnectionType, ByVal cCacheManager As ICacheManager)
                mUsername = cUsername
                mPassword = cPassword
                mConnType = cConnType
                mDatabase = ""
                mCacheManager = cCacheManager
            End Sub

        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If criteria.IsLocalUser Then Throw New Exception( _
                "Metodas DataPortal_Fetch neaptarnauja vietinių vartotojų.")

            mName = criteria.Username
            _Password = criteria.Password
            _ConnType = criteria.ConnectionType
            _IsLocalUser = False
            _UseSSL = criteria.UseSSL

            If _ConnType = DataAccessTypes.ConnectionType.Local OrElse _
                Not IsSecuritySystemInternal Then
                _Server = criteria.Server
                _Port = criteria.Port
                _SqlServerType = criteria.SqlServerType
                _DatabaseNamingConvention = criteria.DatabaseNamingConvention
                _SslCertificateFile = criteria.SslCertificateFile
                _SslCertificateInstalled = criteria.SslCertificateInstalled
                _SslCertificatePassword = criteria.SslCertificatePassword
                _CannotSetGrants = criteria.CannotSetGrants
                _SqlConnectionCharSet = criteria.SqlConnectionCharSet
            End If

            If Not String.IsNullOrEmpty(criteria.Database.Trim) Then
                _Database = criteria.Database
                _UserRealName = criteria.UserRealName
            Else
                _Database = ""
            End If

            TryAuthenticateWithIdentity(Me)

            If mIsAuthenticated Then mRoles.AddRange(DatabaseTableAccess. _
                DatabaseTableAccessRoleList.GetHelperListRoles(mRoles))

            If _ConnType <> DataAccessTypes.ConnectionType.Local AndAlso _
                IsSecuritySystemInternal AndAlso mIsAuthenticated Then _Ticket = GetIdentityHash()

            If Not String.IsNullOrEmpty(criteria.Database.Trim) Then _
                criteria.CacheManager.AddCompanyInfoToLocalContext(_Database, _Password)

        End Sub

        Protected Overrides Sub OnDeserialized(ByVal context As System.Runtime.Serialization.StreamingContext)
            If ApplicationContext.ExecutionLocation = ExecutionLocations.Server AndAlso _
                _ConnType <> DataAccessTypes.ConnectionType.Local AndAlso _
                IsSecuritySystemInternal AndAlso mIsAuthenticated AndAlso _
                _Ticket <> GetIdentityHash() Then Throw New System.Security.SecurityException( _
                "Session has expired. Please login again.")
            MyBase.OnDeserialized(context)
        End Sub
        
        Private Shared Sub TryAuthenticateWithIdentity(ByRef nIdentity As AccIdentity)

            If nIdentity._Database Is Nothing Then nIdentity._Database = ""

            If Not String.IsNullOrEmpty(nIdentity._Database.Trim) AndAlso _
                (Not nIdentity._Database.Trim.ToLower.StartsWith( _
                nIdentity.DatabaseNamingConvention.Trim.ToLower) OrElse _
                Not Integer.TryParse(nIdentity._Database.Trim.Substring( _
                nIdentity.DatabaseNamingConvention.Trim.Length).Trim, New Integer)) Then _
                Throw New System.Security.SecurityException( _
                "Klaida. Vartotojas neturi teisės prisijungti prie kitų serverio duomenų bazių.")

            Dim result As New List(Of String)

            DatabaseAccess.TryLogin(nIdentity, result)

            nIdentity.mRoles = result

            nIdentity.mIsAuthenticated = (Not nIdentity.mName Is Nothing AndAlso _
                Not String.IsNullOrEmpty(nIdentity.mName.Trim))

        End Sub

        Friend Sub AuthenticateOnServer()
            TryAuthenticateWithIdentity(Me)
        End Sub

        Private Function GetIdentityHash() As String

            Dim result As String = mName.Trim & ConfigurationManager.AppSettings( _
                AppSettingsKey_ApplicationServerSecret).Trim & Today.ToString("yyyy-MM-dd")

            If _Database Is Nothing OrElse String.IsNullOrEmpty(_Database.Trim) Then
                result = result & "NullDatabase"
            Else
                result = result & _Database.Trim
            End If

            If mRoles Is Nothing OrElse mRoles.Count < 1 Then
                result = result & "NullRoles"
            Else
                For Each r As String In mRoles
                    result = result & r.Trim
                Next
            End If

            Dim h As New System.Security.Cryptography.SHA512Managed 

            Return Convert.ToBase64String(h.ComputeHash((New System.Text.UnicodeEncoding).GetBytes(result)))

        End Function

#End Region

    End Class

End Namespace