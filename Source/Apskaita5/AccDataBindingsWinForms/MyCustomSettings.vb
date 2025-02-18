﻿Imports AccControlsWinForms
Imports AccDataBindingsWinForms.Settings
Imports BrightIdeasSoftware
Imports System.Windows.Forms
Imports ApskaitaObjects
Imports System.IO

Namespace MyCustomSettings

    ''' <summary>
    ''' Represent a common access point to the program settings.
    ''' </summary>
    ''' <remarks>Acts as a proxy for <see cref="My.Settings">My.Settings</see>
    ''' (for installed version) or an xml serialized <see cref="SettingsPersistenceObject">SettingsPersistenceObject</see>
    ''' object (for a portable version).</remarks>
    Public Module MyCustomSettings

        ''' <summary>
        ''' Existance of this file (content is not important) in the application folder 
        ''' indicates that the current application is running as portable.
        ''' </summary>
        ''' <remarks></remarks>
        Public Const PORTABLE_INSTALATION_INDICATOR As String = "Portable.dat"
        ''' <summary>
        ''' A program settings file name for the portable version.
        ''' </summary>
        ''' <remarks></remarks>
        Public Const PORTABLE_INSTALATION_INI_FILE As String = "config.ini"
        ''' <summary>
        ''' A name of the file where the last update date is stored.
        ''' </summary>
        ''' <remarks></remarks>
        Public Const LAST_UPDATE_FILE_NAME As String = "LastUpdateA5.txt"
        ''' <summary>
        ''' A name of the program update install file for an installed version.
        ''' </summary>
        ''' <remarks></remarks>
        Public Const UPDATE_FILE_NAME As String = "Apskaita5_setup.exe"
        ''' <summary>
        ''' A name of the program update install file for a portable version.
        ''' </summary>
        ''' <remarks></remarks>
        Public Const UPDATE_FILE_NAME_PORTABLE As String = "Apskaita5Portable.exe"

        ''' <summary>
        ''' A method to get a <see cref="SettingsPersistenceObject">SettingsPersistenceObject</see>
        ''' from the <see cref="My.Settings">My.Settings</see> of the application.
        ''' </summary>
        ''' <remarks>See <see cref="InitializeMyCustomSettings">InitializeMyCustomSettings</see> method.</remarks>
        Public Delegate Function GetMySettings() As SettingsPersistenceObject
        ''' <summary>
        ''' A method to save a <see cref="Settings.SettingsPersistenceObject">SettingsPersistenceObject</see>
        ''' to the <see cref="My.Settings">My.Settings</see> of the application.
        ''' </summary>
        ''' <remarks>See <see cref="InitializeMyCustomSettings">InitializeMyCustomSettings</see> method.</remarks>
        Public Delegate Sub SaveMySettings(ByVal settings As SettingsPersistenceObject)

        Private _GetSettingsDelegate As GetMySettings = Nothing
        Private _SaveSettingsDelegate As SaveMySettings = Nothing
        Private _SettingsCache As SettingsPersistenceObject = Nothing
        Private _CloseApplicationForUpdate As WebControls.ApplicationUpdater.CloseApplicationForUpdate = Nothing
        Private _ApplicationUpdater As WebControls.ApplicationUpdater = Nothing


        ''' <summary>
        ''' Gets or sets whether data operations should be invoked on a separate thread.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property UseThreadingForDataTransfer() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.UseThreadingForDataTransfer
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.UseThreadingForDataTransfer = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether data in a report should be automaticaly reloaded 
        ''' when a related business object changes.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property AutoReloadData() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.AutoReloadData
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.AutoReloadData = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a name (first and last) of the program user (an accountant).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property UserName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.UserName.Trim
            End Get
            Set(ByVal value As String)
                InitCache()
                _SettingsCache.UserName = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a user email account.
        ''' </summary>
        ''' <remarks>Only applicable when <see cref="UseDefaultEmailClient">UseDefaultEmailClient</see> 
        ''' is set to FALSE.</remarks>
        Public Property UserEmailAccount() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.UserEmailAccount.Trim
            End Get
            Set(ByVal value As String)
                InitCache()
                _SettingsCache.UserEmailAccount = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a user email SMTP server address.
        ''' </summary>
        ''' <remarks>Only applicable when <see cref="UseDefaultEmailClient">UseDefaultEmailClient</see> 
        ''' is set to FALSE.</remarks>
        Public Property SmtpServer() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.SmtpServer.Trim
            End Get
            Set(ByVal value As String)
                InitCache()
                _SettingsCache.SmtpServer = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a user email address.
        ''' </summary>
        ''' <remarks>Only applicable when <see cref="UseDefaultEmailClient">UseDefaultEmailClient</see> 
        ''' is set to FALSE.</remarks>
        Public Property UserEmail() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.UserEmail.Trim
            End Get
            Set(ByVal value As String)
                InitCache()
                _SettingsCache.UserEmail = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a user email password.
        ''' </summary>
        ''' <remarks>Only applicable when <see cref="UseDefaultEmailClient">UseDefaultEmailClient</see> 
        ''' is set to FALSE.</remarks>
        Public Property UserEmailPassword() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.UserEmailPassword
            End Get
            Set(ByVal value As String)
                InitCache()
                _SettingsCache.UserEmailPassword = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the user email is accessed via SSL.
        ''' </summary>
        ''' <remarks>Only applicable when <see cref="UseDefaultEmailClient">UseDefaultEmailClient</see> 
        ''' is set to FALSE.</remarks>
        Public Property UseSslForEmail() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.UseSslForEmail
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.UseSslForEmail = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the user email is accessed using AUTH protocol.
        ''' </summary>
        ''' <remarks>Only applicable when <see cref="UseDefaultEmailClient">UseDefaultEmailClient</see> 
        ''' is set to FALSE.</remarks>
        Public Property UseAuthForEmail() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.UseAuthForEmail
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.UseAuthForEmail = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a user email SMTP server port.
        ''' </summary>
        ''' <remarks>Only applicable when <see cref="UseDefaultEmailClient">UseDefaultEmailClient</see> 
        ''' is set to FALSE.</remarks>
        Public Property SmtpPort() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.SmtpPort.Trim
            End Get
            Set(ByVal value As String)
                InitCache()
                _SettingsCache.SmtpPort = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the tools strip should be shown on the GUI.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ShowToolStrip() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.ShowToolStrip
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.ShowToolStrip = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the program should automaticaly check for updates
        ''' every time the program is started.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property AutoUpdate() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.AutoUpdate
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.AutoUpdate = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a default email text used when sending documents/emails 
        ''' from the program.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property EmailMessageText() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.EmailMessageText.Trim
            End Get
            Set(ByVal value As String)
                InitCache()
                _SettingsCache.EmailMessageText = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a timeout in seconds for the application cached data.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property CacheTimeout() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.CacheTimeout
            End Get
            Set(ByVal value As Integer)
                InitCache()
                _SettingsCache.CacheTimeout = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the invoices should be signed with the
        ''' <see cref="ApskaitaObjects.General.Company.HeadPersonSignature">
        ''' company's head signature</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property SignInvoicesWithCompanySignature() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.SignInvoicesWithCompanySignature
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.SignInvoicesWithCompanySignature = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the invoices should be signed with the
        ''' <see cref="UserSignature">program user signature</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property SignInvoicesWithLocalUserSignature() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.SignInvoicesWithLocalUserSignature
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.SignInvoicesWithLocalUserSignature = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the invoices should be signed with the
        ''' <see cref="AccDataAccessLayer.Security.UserProfile.Signature">
        ''' remote user signature</see> (current user data on server).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property SignInvoicesWithRemoteUserSignature() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.SignInvoicesWithRemoteUserSignature
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.SignInvoicesWithRemoteUserSignature = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether to display (remote) login dialog when the program starts.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property AllwaysLoginAsLocalUser() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.AllwaysLoginAsLocalUser
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.AllwaysLoginAsLocalUser = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether an email window of the default email program
        ''' should be displayed before sending an email message.
        ''' </summary>
        ''' <remarks>Only applicable when <see cref="UseDefaultEmailClient">UseDefaultEmailClient</see>
        ''' is set to TRUE.</remarks>
        Public Property ShowDefaultMailClientWindow() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.ShowDefaultMailClientWindow
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.ShowDefaultMailClientWindow = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether emails should be sent using a default email program
        ''' (that is installed on the user computer).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property UseDefaultEmailClient() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.UseDefaultEmailClient
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.UseDefaultEmailClient = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether forms should be autosized (as oposed to user sized).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property AutoSizeForm() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.AutoSizeForm
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.AutoSizeForm = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether table columns should be autosized (as oposed to user sized).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property AutoSizeDataGridViewColumns() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.AutoSizeDataGridViewColumns
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.AutoSizeDataGridViewColumns = value
            End Set
        End Property

        Private Property FormPropertiesList() As System.Collections.Specialized.StringCollection
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.FormPropertiesList
            End Get
            Set(ByVal value As System.Collections.Specialized.StringCollection)
                InitCache()
                _SettingsCache.FormPropertiesList = value
            End Set
        End Property

        Private Property ObjectListViewColumnPropertiesList() As System.Collections.Specialized.StringCollection
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.ObjectListViewColumnPropertiesList
            End Get
            Set(ByVal value As System.Collections.Specialized.StringCollection)
                InitCache()
                _SettingsCache.ObjectListViewColumnPropertiesList = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether company settings should be displayed every time
        ''' before creating a new <see cref="ApskaitaObjects.Workers.WageSheet">WageSheet</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property AllwaysShowWageSettings() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.AllwaysShowWageSettings
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.AllwaysShowWageSettings = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an SQL query time out in seconds. 
        ''' A value of 0 indicates a default timeout (depends on a server type).
        ''' </summary>
        ''' <remarks>Only used localy, not passed to a remote server.</remarks>
        Public Property SQLQueryTimeOut() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.SQLQueryTimeOut
            End Get
            Set(ByVal value As Integer)
                InitCache()
                _SettingsCache.SQLQueryTimeOut = value
            End Set
        End Property

        ''' <summary>
        ''' Gets a list of user data in the (remote) login form.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property LocalUsers() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.LocalUsers.Trim
            End Get
            Set(ByVal value As String)
                InitCache()
                _SettingsCache.LocalUsers = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a signature (facsimile) of the program user (an accountant).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property UserSignature() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.UserSignature.Trim
            End Get
            Set(ByVal value As String)
                InitCache()
                _SettingsCache.UserSignature = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a <see cref="ApskaitaObjects.Settings.CommonSettings">
        ''' localy stored common settings XML string</see>.
        ''' </summary>
        ''' <remarks>Used to persist common setttings when working without a remote server.
        ''' See <see cref="InitializeMyCustomSettings">InitializeMyCustomSettings</see>
        ''' method for details.</remarks>
        Friend Property CommonSettings() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.CommonSettings.Trim
            End Get
            Set(ByVal value As String)
                InitCache()
                _SettingsCache.CommonSettings = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a default <see cref="ApskaitaObjects.Documents.BankOperationItemList">
        ''' bank operation document number prefix</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BankDocumentPrefix() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.BankDocumentPrefix.Trim
            End Get
            Set(ByVal value As String)
                InitCache()
                _SettingsCache.BankDocumentPrefix = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether <see cref="ApskaitaObjects.Documents.BankOperationItemList">
        ''' to ignore IBAN number mismatch when importing bank operations data</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property IgnoreWrongIBAN() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.IgnoreWrongIBAN
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.IgnoreWrongIBAN = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an url where the program update files are located.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property UpdateUrl() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.UpdateUrl.Trim
            End Get
            Set(ByVal value As String)
                InitCache()
                _SettingsCache.UpdateUrl = value
                If Not StringIsNullOrEmpty(value) Then
                    If _ApplicationUpdater Is Nothing Then
                        InitApplicationUpdater()
                    Else
                        _ApplicationUpdater.UpdateFileUrl = value
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Indicates whether the current program is running as portable,
        ''' i.e. all resources including settings are stored in the application folder.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IsPortableInstalation() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.IsPortableInstalation
            End Get
        End Property

        ''' <summary>
        ''' Gets a date when the application was last updated.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property LastUpdateDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.GetLastUpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets whether to add <see cref="ApskaitaObjects.Documents.InvoiceMade.ExternalID">
        ''' an external ID of the invoice made</see> without the user confirmation
        ''' when copying an invoice from an external source.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property AlwaysUseExternalIdInvoicesMade() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.AlwaysUseExternalIdInvoicesMade
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.AlwaysUseExternalIdInvoicesMade = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether to add <see cref="ApskaitaObjects.Documents.InvoiceReceived.ExternalID">
        ''' an external ID of the invoice received</see> without the user confirmation
        ''' when copying an invoice from an external source.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property AlwaysUseExternalIdInvoicesReceived() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.AlwaysUseExternalIdInvoicesReceived
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.AlwaysUseExternalIdInvoicesReceived = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the default new item in an invoice received
        ''' should be goods purchase (as oposed to a service bought).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DefaultInvoiceReceivedItemIsGoods() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.DefaultInvoiceReceivedItemIsGoods
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.DefaultInvoiceReceivedItemIsGoods = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the default new item in an invoice made
        ''' should be goods sale (as oposed to a service sold).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DefaultInvoiceMadeItemIsGoods() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.DefaultInvoiceMadeItemIsGoods
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.DefaultInvoiceMadeItemIsGoods = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether to check if the invoice received number is unique.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property CheckInvoiceReceivedNumber() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.CheckInvoiceReceivedNumber
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.CheckInvoiceReceivedNumber = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether to check the invoice received number uniqueness
        ''' taking into account the invoice date.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property CheckInvoiceReceivedNumberWithDate() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.CheckInvoiceReceivedNumberWithDate
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.CheckInvoiceReceivedNumberWithDate = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether to check the invoice received number uniqueness
        ''' taking into account the supplier.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property CheckInvoiceReceivedNumberWithSupplier() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                InitCache()
                Return _SettingsCache.CheckInvoiceReceivedNumberWithSupplier
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.CheckInvoiceReceivedNumberWithSupplier = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether ObjectListView edit is initiated on double click (instead of single click).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property EditListViewWithDoubleClick() As Boolean
            Get
                InitCache()
                Return _SettingsCache.EditListViewWithDoubleClick
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.EditListViewWithDoubleClick = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether to use hot item traking in the ObjectListView's. (CPU intensive)
        ''' </summary>
        ''' <remarks></remarks>
        Public Property UseHotTracking() As Boolean
            Get
                InitCache()
                Return _SettingsCache.UseHotTracking
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.UseHotTracking = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether to show a default empty list message in the ObjectListView's.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ShowEmptyListMessage() As Boolean
            Get
                InitCache()
                Return _SettingsCache.ShowEmptyListMessage
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.ShowEmptyListMessage = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether to show gridlines in the ObjectListView's.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ShowGridLines() As Boolean
            Get
                InitCache()
                Return _SettingsCache.ShowGridLines
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.ShowGridLines = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether to perform a default action when 
        ''' an ObjectListView is double clicked (as oposed to showing 
        ''' a meniu of available actions).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DefaultActionByDoubleClick() As Boolean
            Get
                InitCache()
                Return _SettingsCache.DefaultActionByDoubleClick
            End Get
            Set(ByVal value As Boolean)
                InitCache()
                _SettingsCache.DefaultActionByDoubleClick = value
            End Set
        End Property


        ''' <summary>
        ''' Saves the current program settings values.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Save()

            InitCache()

            If _SettingsCache.IsPortableInstalation() Then

                IO.File.WriteAllText(IO.Path.Combine(AppPath, PORTABLE_INSTALATION_INI_FILE), _
                    _SettingsCache.ConvertToXmlString())

            Else

                If _SaveSettingsDelegate Is Nothing Then
                    Throw New InvalidOperationException("Neinicializuota programos nustatymų sistema.")
                End If
                _SaveSettingsDelegate.Invoke(_SettingsCache)

            End If

            _SettingsCache.MarkAsOld()

        End Sub

        ''' <summary>
        ''' Saves the current program settings values to the file specified.
        ''' </summary>
        ''' <param name="filePath">a path to the file</param>
        ''' <remarks></remarks>
        Public Sub SaveToFile(ByVal filePath As String)
            If String.IsNullOrEmpty(filePath) Then
                Throw New ArgumentNullException("filePath")
            End If
            InitCache()
            IO.File.WriteAllText(filePath, _SettingsCache.ConvertToXmlString())
        End Sub

        ''' <summary>
        ''' Loads the current program settings values from the file specified.
        ''' </summary>
        ''' <param name="filePath">a path to the file</param>
        ''' <remarks></remarks>
        Public Sub LoadFromFile(ByVal filePath As String)

            If String.IsNullOrEmpty(filePath) Then
                Throw New ArgumentNullException("filePath")
            End If

            If Not IO.File.Exists(filePath) Then
                Throw New FileNotFoundException(String.Format("Klaida. Nerastas duomenų failas {0}.", filePath), filePath)
            End If

            Dim result As SettingsPersistenceObject = SettingsPersistenceObject.GetFromXmlString( _
                IO.File.ReadAllText(filePath))
            result.Initialize(True, AppPath)

            _SettingsCache = result

        End Sub

        ''' <summary>
        ''' Initializes program settings on the program startup.
        ''' </summary>
        ''' <param name="getSettingsDelegate">a method that gets a 
        ''' <see cref="SettingsPersistenceObject">SettingsPersistenceObject</see>
        ''' from the <see cref="My.Settings">My.Settings</see> of the application</param>
        ''' <param name="saveSettingsDelegate">A method that saves a 
        ''' <see cref="SettingsPersistenceObject">SettingsPersistenceObject</see>
        ''' to the <see cref="My.Settings">My.Settings</see> of the application</param>
        ''' <param name="closeApplicationForUpdate">A method that closes the application in order to update it.</param>
        ''' <remarks></remarks>
        Public Sub InitializeMyCustomSettings(ByVal getSettingsDelegate As GetMySettings, _
            ByVal saveSettingsDelegate As SaveMySettings, ByVal closeApplicationForUpdate As WebControls.ApplicationUpdater.CloseApplicationForUpdate)

            _GetSettingsDelegate = getSettingsDelegate
            _SaveSettingsDelegate = saveSettingsDelegate
            _CloseApplicationForUpdate = closeApplicationForUpdate

            ApskaitaObjects.Utilities.AttachLocalSettingsMethods( _
                AddressOf SaveCommonSettingsLocal, _
                AddressOf GetCommonSettingsLocal)

            InitApplicationUpdater()

        End Sub

        Private Sub InitApplicationUpdater()

            InitCache()

            If StringIsNullOrEmpty(_SettingsCache.UpdateUrl) Then Exit Sub

            Dim installName As String = UPDATE_FILE_NAME
            If _SettingsCache.IsPortableInstalation() Then
                installName = UPDATE_FILE_NAME_PORTABLE
            End If

            _ApplicationUpdater = New WebControls.ApplicationUpdater("Apskaita5", _
                _SettingsCache.GetLastUpdateDate(), _SettingsCache.UpdateUrl, _
                LAST_UPDATE_FILE_NAME, _SettingsCache.IsPortableInstalation(), _
                New System.Text.UnicodeEncoding, installName, _CloseApplicationForUpdate)

        End Sub

        ''' <summary>
        ''' Checks for new application updates in background without visual feedback.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CheckForUpdatesInBackground()
            If _ApplicationUpdater Is Nothing Then Exit Sub
            _ApplicationUpdater.CheckForUpdateInBackground()
        End Sub

        ''' <summary>
        ''' Checks for new application updates with visual feedback.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CheckForUpdates()
            If _ApplicationUpdater Is Nothing Then
                MsgBox("Klaida. Nenurodytas atnaujinimų serverio adresas.", MsgBoxStyle.Exclamation, "Klaida")
                Exit Sub
            End If
            _ApplicationUpdater.CheckForUpdate()
        End Sub


        ''' <summary>
        ''' Restores form layout with the saved visual properties.
        ''' Also changes currency placeholder LTL to the current company's 
        ''' base currency in all the labels within the form.
        ''' </summary>
        ''' <param name="nForm">a form to restore the state for</param>
        ''' <remarks></remarks>
        Public Sub SetFormLayout(ByVal nForm As Form)

            SetFormProperties(nForm, AutoSizeForm, FormPropertiesList)

            If AccDataAccessLayer.DatabaseAccess.GetCurrentIdentity.IsAuthenticatedWithDB Then

                Dim baseCurrency As String = GetCurrentCompany.BaseCurrency.Trim.ToUpper

                If baseCurrency <> "LTL" Then
                    SetBaseCurrencyLabels(DirectCast(nForm, Control), baseCurrency)
                End If

            End If

        End Sub

        ''' <summary>
        ''' Restores DataListView layout with the saved visual properties.
        ''' </summary>
        ''' <param name="listView">a DataListView to restore the state for</param>
        ''' <remarks></remarks>
        Public Sub SetListViewLayOut(ByVal listView As ObjectListView)

            SetListViewProperties(listView, AutoSizeDataGridViewColumns, _
                ObjectListViewColumnPropertiesList)

            If AccDataAccessLayer.DatabaseAccess.GetCurrentIdentity.IsAuthenticatedWithDB Then
                For Each col As OLVColumn In listView.AllColumns
                    col.Text = col.Text.Replace("LTL", GetCurrentCompany.BaseCurrency.ToUpper())
                Next
            End If
            listView.UseHotControls = _SettingsCache.UseHotTracking
            listView.UseHotItem = _SettingsCache.UseHotTracking
            listView.GridLines = _SettingsCache.ShowGridLines
            listView.SelectColumnsMenuStaysOpen = True

        End Sub

        ''' <summary>
        ''' Saves form layout properties.
        ''' </summary>
        ''' <param name="nForm">a form to save the state for</param>
        ''' <remarks></remarks>
        Public Sub GetFormLayout(ByVal nForm As Form)
            GetFormProperties(nForm, AutoSizeForm, FormPropertiesList)
            Try
                FormPropertiesList = GetFormPropertiesStringCollection(FormPropertiesList)
            Catch ex As Exception
                ShowError(New Exception(String.Format("Klaida. Nepavyko išsaugoti programos nustatymų:{0}{1}",
                    vbCrLf, ex.Message), ex), Nothing)
            End Try
        End Sub

        ''' <summary>
        ''' Saves DataListView layout properties.
        ''' </summary>
        ''' <param name="listView">a DataListView to save the state for</param>
        ''' <remarks></remarks>
        Public Sub GetListViewLayOut(ByVal listView As ObjectListView)

            GetListViewProperties(listView, AutoSizeDataGridViewColumns, _
                ObjectListViewColumnPropertiesList)

            Try
                ObjectListViewColumnPropertiesList = GetListViewPropertiesStringCollection( _
                     ObjectListViewColumnPropertiesList)
            Catch ex As Exception
                ShowError(New Exception(String.Format("Klaida. Nepavyko išsaugoti programos nustatymų:{0}{1}",
                    vbCrLf, ex.Message), ex), Nothing)
            End Try

        End Sub

        Private Sub SetBaseCurrencyLabels(ByRef ctrl As Control, ByVal baseCurrency As String)

            If TypeOf ctrl Is Label Then
                DirectCast(ctrl, Label).Text = DirectCast(ctrl, Label).Text.Replace("LTL", baseCurrency)
            ElseIf TypeOf ctrl Is Button Then
                DirectCast(ctrl, Button).Text = DirectCast(ctrl, Button).Text.Replace("LTL", baseCurrency)
            ElseIf TypeOf ctrl Is DataGridView Then
                For Each col As DataGridViewColumn In DirectCast(ctrl, DataGridView).Columns
                    col.HeaderText = col.HeaderText.Replace("LTL", baseCurrency)
                Next
            ElseIf ctrl.Controls.Count > 0 Then
                For Each childControl As Control In ctrl.Controls
                    SetBaseCurrencyLabels(childControl, baseCurrency)
                Next
            End If

        End Sub


        Private Sub InitCache()

            If Not _SettingsCache Is Nothing Then Exit Sub

            Dim result As SettingsPersistenceObject

            If IO.File.Exists(IO.Path.Combine(AppPath, PORTABLE_INSTALATION_INDICATOR)) Then

                If IO.File.Exists(IO.Path.Combine(AppPath, PORTABLE_INSTALATION_INI_FILE)) Then

                    result = SettingsPersistenceObject.GetFromXmlString( _
                        IO.File.ReadAllText(IO.Path.Combine(AppPath, PORTABLE_INSTALATION_INI_FILE)))

                Else

                    result = New SettingsPersistenceObject

                End If

                result.Initialize(True, AppPath)

            Else

                If _GetSettingsDelegate Is Nothing Then
                    Throw New InvalidOperationException("Neinicializuota programos nustatymų sistema.")
                End If
                result = _GetSettingsDelegate.Invoke()

                result.Initialize(False, AppPath)

            End If

            _SettingsCache = result

        End Sub


        ''' <summary>
        ''' Returns path to the folder where the program (.exe) is executing.
        ''' </summary>
        Private Function AppPath() As String
            Return System.IO.Path.GetDirectoryName(Reflection.Assembly _
                .GetEntryAssembly().Location)
        End Function

        Private Sub SaveCommonSettingsLocal(ByVal settingsXmlString As String)
            Try
                CommonSettings = settingsXmlString
                Save()
            Catch ex As Exception
                ShowError(New Exception(String.Format("Klaida. Nepavyko išsaugoti programos nustatymų:{0}{1}",
                    vbCrLf, ex.Message), ex), Nothing)
            End Try
        End Sub

        Private Function GetCommonSettingsLocal() As String
            Return CommonSettings
        End Function

    End Module

End Namespace