﻿Imports AccDataAccessLayer.Security
Imports BrightIdeasSoftware
Imports System.Reflection

Public Class MDIParent1

    Private WithEvents searchTextBox As New ToolStripTextBox
    Private WithEvents searchButton As New ToolStripButton

    Private ReadOnly administrativeForms As Type() = New Type() _
        {GetType(F_BackUp), GetType(F_ChangePassword), GetType(F_DatabaseStructureEditor),
         GetType(F_DatabaseStructureError), GetType(F_DatabaseTableAccessRoleList),
         GetType(F_DeleteDatabase), GetType(F_NewCompany), GetType(F_User), GetType(F_UserProfile)}


    Private Sub MDIParent1_FormClosing(ByVal sender As Object,
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not My.Application.IsInternalShutdown Then
            If Not YesOrNo("Ar tikrai norite baigti darbą su programa?") Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        MyCustomSettings.Save()
    End Sub

    Private Sub MDIParent1_Load(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles MyBase.Load

        If My.Application.IsInternalShutdown Then Exit Sub

        AccControlsWinForms.ApplicationVersion = String.Format("Apskaita5 v. {0}, IsPortable = {1}, UseServer = {2}, Connection = {3}",
            MyCustomSettings.LastUpdateDate.ToString("yyyy-MM-dd"), MyCustomSettings.IsPortableInstalation.ToString,
            (Not GetCurrentIdentity.IsLocalUser).ToString, GetCurrentIdentity.ConnectionType.ToString)

        searchTextBox.Anchor = AnchorStyles.Right
        searchTextBox.BorderStyle = BorderStyle.None
        searchButton.Anchor = AnchorStyles.Right
        searchButton.Image = My.Resources.searchIcon_16x16
        StatusStrip.Items.Add(New ToolStripSeparator)
        StatusStrip.Items.Add(searchTextBox)
        StatusStrip.Items.Add(searchButton)

        AccDataBindingsWinForms.CurrentMdiParent = Me

        NewComplexOperation_MenuItem.DropDownItems.Clear()
        For Each t As TypeItem In AssetOperationManager.GetComplexOperationTypes()
            Dim menuItem As New ToolStripMenuItem(t.Name)
            menuItem.Tag = t.Type
            AddHandler menuItem.Click, AddressOf NewComplexAssetOperation_MenuItem_Click
            NewComplexOperation_MenuItem.DropDownItems.Add(menuItem)
        Next

        NewGoodsOperation_MenuItem.DropDownItems.Clear()
        For Each t As TypeItem In GoodsOperationManager.GetComplexOperationTypes()
            Dim menuItem As New ToolStripMenuItem(t.Name)
            menuItem.Tag = t.Type
            AddHandler menuItem.Click, AddressOf NewComplexGoodsOperation_MenuItem_Click
            NewGoodsOperation_MenuItem.DropDownItems.Add(menuItem)
        Next

        Dim dbList As DatabaseInfoList = Nothing
        Try
            Using busy As New StatusBusy
                dbList = DatabaseInfoList.GetDatabaseList
                DatabasesToMenu()
            End Using
        Catch ex As Exception
            ShowError(ex, Nothing)
        End Try

        Me.ToolStrip1.Visible = MyCustomSettings.ShowToolStrip

        LogInPrimaryToGui()

        If Not dbList Is Nothing AndAlso Not StringIsNullOrEmpty(dbList.ErrorsString) Then
            MsgBox("ĮSPĖJIMAS. Nepavyko gauti duomenų apie įmones kai kuriose duomenų bazėse. " _
                & "Gali būti kad duomenys jose yra sugadinti." & vbCrLf & vbCrLf & dbList.ErrorsString.Trim,
                MsgBoxStyle.Exclamation, "Įspėjimas")
        End If

        If MyCustomSettings.AutoUpdate AndAlso My.Computer.Network.IsAvailable Then
            MyCustomSettings.CheckForUpdatesInBackground()
        End If

        If OpenCompanyMenuItem.DropDownItems.Count = 1 Then _
            OpenCompanyMenuItem.DropDownItems(0).PerformClick()

    End Sub


    Private Sub LogInPrimaryToGui()

        Me.NewCompanyMenuItem.Enabled = (GetCurrentIdentity.IsLocalUser OrElse GetCurrentIdentity.IsAdmin)
        Me.UserAdministrationMenuItem.Enabled = Not GetCurrentIdentity.IsLocalUser
        Me.LogOffMenuItem.Enabled = False
        Me.DropCompanyMenuItem.Enabled = (GetCurrentIdentity.IsLocalUser OrElse GetCurrentIdentity.IsAdmin)
        Me.BackupMenuItem.Enabled = (GetCurrentIdentity.IsLocalUser OrElse
            (GetCurrentIdentity.ConnectionType = AccDataAccessLayer.ConnectionType.Local AndAlso
            (GetCurrentIdentity.SQLServer.Trim = "127.0.0.1" OrElse
            GetCurrentIdentity.SQLServer.Trim.ToLower = "localhost")))
        Me.ChangePasswordMenuItem.Enabled = Not GetCurrentIdentity.IsLocalUser
        Me.UpgradeDBMenuItem.Enabled = (GetCurrentIdentity.IsLocalUser OrElse GetCurrentIdentity.IsAdmin)
        Me.QueryBrowserMenuItem.Enabled = (GetCurrentIdentity.IsLocalUser OrElse GetCurrentIdentity.IsAdmin)
        Me.SystemEditors_MenuItem.Enabled = (GetCurrentIdentity.IsLocalUser OrElse GetCurrentIdentity.IsAdmin)

        Me.UserReportInfoList_MenuItem.Enabled = HelperLists.UserReportInfoList.CanGetObject()

        ' Turning of database related menus till user logs in a database
        Me.GeneralDataMenu.Enabled = False
        Me.DocumentsMenu.Enabled = False
        Me.AssetsMenu.Enabled = False
        Me.WorkersMenu.Enabled = False
        Me.ReportsMenu.Enabled = False
        Me.CurrencyRateChangeImpactCalculator_MenuItem.Enabled = False
        Me.ToolStrip1.Items("GeneralLedgerButton").Enabled = False
        Me.ToolStrip1.Items("BookEntriesTurnoverButton").Enabled = False
        Me.ToolStrip1.Items("InvoiceListButton").Enabled = False
        Me.ToolStrip1.Items("TillButton").Enabled = False
        Me.ToolStrip1.Items("PersonsButton").Enabled = False
        Me.ToolStrip1.Items("NewJournalEntryToolStripButton").Enabled = False
        Me.ToolStrip1.Items("MakeInvoiceButton").Enabled = False
        Me.ToolStrip1.Items("RegisterInvoiceButton").Enabled = False
        Me.ToolStrip1.Items("TillIncomeOrderButton").Enabled = False
        Me.ToolStrip1.Items("TillSpendingsOrderButton").Enabled = False
        Me.ToolStrip1.Items("ServiceInfoListButton").Enabled = False
        Me.ToolStrip1.Items("NewServiceButton").Enabled = False
        Me.ToolStrip1.Items("GoodsTurnoverInfoButton").Enabled = False
        Me.ToolStrip1.Items("NewGoodsItemButton").Enabled = False
        Me.ToolStrip1.Items("NewPersonButton").Enabled = False

    End Sub

    Friend Sub LogOffToGUI()
        If IsLoggedInDB() Then Exit Sub

        Me.GeneralDataMenu.Enabled = False
        Me.DocumentsMenu.Enabled = False
        Me.AssetsMenu.Enabled = False
        Me.WorkersMenu.Enabled = False
        Me.ReportsMenu.Enabled = False
        Me.CurrencyRateChangeImpactCalculator_MenuItem.Enabled = False
        Me.ToolStrip1.Items("GeneralLedgerButton").Enabled = False
        Me.ToolStrip1.Items("BookEntriesTurnoverButton").Enabled = False
        Me.ToolStrip1.Items("InvoiceListButton").Enabled = False
        Me.ToolStrip1.Items("TillButton").Enabled = False
        Me.ToolStrip1.Items("PersonsButton").Enabled = False
        Me.ToolStrip1.Items("NewJournalEntryToolStripButton").Enabled = False
        Me.ToolStrip1.Items("MakeInvoiceButton").Enabled = False
        Me.ToolStrip1.Items("RegisterInvoiceButton").Enabled = False
        Me.ToolStrip1.Items("TillIncomeOrderButton").Enabled = False
        Me.ToolStrip1.Items("TillSpendingsOrderButton").Enabled = False
        Me.ToolStrip1.Items("ServiceInfoListButton").Enabled = False
        Me.ToolStrip1.Items("NewServiceButton").Enabled = False
        Me.ToolStrip1.Items("GoodsTurnoverInfoButton").Enabled = False
        Me.ToolStrip1.Items("NewGoodsItemButton").Enabled = False
        Me.ToolStrip1.Items("NewPersonButton").Enabled = False

        Me.ChangePasswordMenuItem.Enabled = Not GetCurrentIdentity.IsLocalUser

        'deaktyvuojam atsijungimo meniu punkta ir parodom fakta statuse
        Me.LogOffMenuItem.Enabled = False
        If Me.AdministrationMenu.DropDownItems(Me.AdministrationMenu.DropDownItems.Count - 1).Text <> "" Then
            Me.AdministrationMenu.DropDownItems.RemoveAt(Me.AdministrationMenu.DropDownItems.Count - 1)
        End If
        Me.StatusStrip.Items.Item(0).Text = "Neprisijungta prie jokios įmonės"

        For Each child As Form In Me.MdiChildren
            If Array.IndexOf(administrativeForms, child.GetType()) < 0 Then
                child.Close()
            End If
        Next

    End Sub

    Friend Sub DatabasesToMenu()

        Me.OpenCompanyMenuItem.DropDownItems.Clear()

        Dim dbList As DatabaseInfoList
        Try
            Using busy As New StatusBusy
                dbList = DatabaseInfoList.GetDatabaseList
            End Using
        Catch ex As Exception
            ShowError(ex, Nothing)
            Exit Sub
        End Try

        For i As Integer = 1 To dbList.Count
            Me.OpenCompanyMenuItem.DropDownItems.Add(dbList.Item(i - 1).CompanyName, Nothing,
                New EventHandler(AddressOf LoginToCompany))
            Me.OpenCompanyMenuItem.DropDownItems(i - 1).Tag = dbList.Item(i - 1)
        Next

    End Sub

    Friend Sub LogInToGUI()

        If Not IsLoggedInDB() Then Exit Sub

        Me.AdministrationMenu.DropDownItems.Add(String.Format("Prisijungta: {0}", GetCurrentCompany.Name))
        Me.LogOffMenuItem.Enabled = True
        ToolStripStatusLabel.Text = String.Format("Prisijungė vartotojas ""{0}"", įmonė: {1}",
            GetCurrentIdentity.Name, GetCurrentCompany.Name)
        Me.CurrencyRateChangeImpactCalculator_MenuItem.Enabled = True

        Me.ChangePasswordMenuItem.Enabled = True

        Me.NewJournalEntryMenuItem.Enabled = General.JournalEntry.CanAddObject
        Me.AccumulativeCosts_MenuItem.Enabled = Documents.AccumulativeCosts.CanAddObject
        Me.GeneralLedgerMenuItem.Enabled = ActiveReports.JournalEntryInfoList.CanGetObject
        Me.BookEntriesTurnoverMenuItem.Enabled = ActiveReports.BookEntryInfoListParent.CanGetObject
        Me.JournalEntryTemplatesMenuItem.Enabled = HelperLists.TemplateJournalEntryInfoList.CanGetObject
        Me.TransferOfBalanceMenuItem.Enabled = General.TransferOfBalance.CanGetObject

        SetParentMenuItemAuthorization(Me.GeneralMenuItem)

        Me.PersonsMenuItem.Enabled = ActiveReports.PersonInfoItemList.CanGetObject
        Me.PersonGroupsMenuItem.Enabled = General.PersonGroupList.CanGetObject
        Me.NewPerson_MenuItem.Enabled = General.Person.CanAddObject
        Me.ImportedPersonList_MenuItem.Enabled = General.ImportedPersonList.CanAddObject

        SetParentMenuItemAuthorization(Me.PersonsGeneralMenuItem)

        Me.ShareHolderInfoList_MenuItem.Enabled = ActiveReports.ShareHolderInfoList.CanGetObject
        Me.SharesAccountEntryList_MenuItem.Enabled = ActiveReports.SharesAccountEntryList.CanGetObject
        Me.SharesClassList_MenuItem.Enabled = General.SharesClassList.CanGetObject
        Me.SharesOperationInfoList_MenuItem.Enabled = ActiveReports.SharesOperationInfoList.CanGetObject
        Me.SharesOperation_MenuItem.Enabled = General.SharesOperation.CanAddObject

        SetParentMenuItemAuthorization(Me.Shares_MenuItem)

        Me.AccountsListMenuItem.Enabled = General.AccountList.CanGetObject
        Me.CompanyInfoMenuItem.Enabled = General.Company.CanGetObject
        Me.DocumentSerialList_MenuItem.Enabled = ApskaitaObjects.Settings.DocumentSerialList.CanGetObject

        SetParentMenuItemAuthorization(Me.GeneralDataMenu)

        Me.CashAccountList_MenuItem.Enabled = Documents.CashAccountList.CanGetObject
        Me.TillIncomeOrderMenuItem.Enabled = Documents.TillIncomeOrder.CanAddObject
        Me.TillSpendingsOrderMenuItem.Enabled = Documents.TillSpendingsOrder.CanAddObject
        Me.BankTransferMenuItem.Enabled = Documents.BankOperation.CanAddObject
        Me.BankImportMenuItem.Enabled = Documents.BankOperationItemList.CanAddObject
        Me.AdvanceReport_MenuItem.Enabled = Documents.AdvanceReport.CanAddObject
        Me.AdvanceReportListMenuItem.Enabled = ActiveReports.AdvanceReportInfoList.CanGetObject
        Me.CashOperationInfoListMenuItem.Enabled = ActiveReports.CashOperationInfoList.CanGetObject

        SetParentMenuItemAuthorization(Me.TillGeneralMenuItem)

        Me.InvoiceMadeMenuItem.Enabled = Documents.InvoiceMade.CanAddObject
        Me.ProformaInvoiceMadeMenuItem.Enabled = Documents.ProformaInvoiceMade.CanAddObject()
        Me.InvoiceReceivedMenuItem.Enabled = Documents.InvoiceReceived.CanAddObject
        Me.InvoiceListMenuItem.Enabled = ActiveReports.InvoiceInfoItemList.CanGetObject

        SetParentMenuItemAuthorization(Me.InvoicesGeneralMenuItem)

        Me.ServiceListMenuItem.Enabled = Documents.Service.CanGetObject
        Me.NewService_MenuItem.Enabled = Documents.Service.CanAddObject
        Me.NewOffset_MenuItem.Enabled = Documents.Offset.CanAddObject
        Me.DebtStatementItemListMenuItem.Enabled = ActiveReports.DebtStatementItemList.CanGetObject()
        Me.VatDeclarationSchemaInfoItemList_MenuItem.Enabled = ActiveReports.VatDeclarationSchemaInfoItemList.CanGetObject()
        Me.VatDeclaration_MenuItem.Enabled = ActiveReports.VatDeclaration.CanGetObject()
        Me.CustomVatOperationList_MenuItem.Enabled = Documents.CustomVatOperationList.CanGetObject()
        Me.ImportInvoicesMenuItem.Enabled = Extensibility.InvoiceImportOptions.CanUse()

        SetParentMenuItemAuthorization(Me.DocumentsMenu)

        Me.GoodsGroupListMenuItem.Enabled = Goods.GoodsGroupList.CanGetObject
        Me.WarehouseList_MenuItem.Enabled = Goods.WarehouseList.CanGetObject
        Me.NewGoodsItem_MenuItem.Enabled = Goods.GoodsItem.CanAddObject
        Me.GoodsTurnoverInfoList_MenuItem.Enabled = ActiveReports.GoodsTurnoverInfoList.CanGetObject
        Me.GoodsOperationInfoList_MenuItem.Enabled = ActiveReports.GoodsOperationInfoListParent.CanGetObject
        Me.ProductionCalculationSheetList_MenuItem.Enabled =
            ActiveReports.ProductionCalculationItemList.CanGetObject
        Me.NewProductionCalculation_MenuItem.Enabled = Goods.ProductionCalculation.CanAddObject
        Me.GoodsComplexOperationTransferOfBalance_MenuItem.Enabled =
            Goods.GoodsComplexOperationTransferOfBalance.CanGetObject
        Me.ImportedGoodsItemList_MenuItem.Enabled = Goods.ImportedGoodsItemList.CanAddObject

        For Each menuItem As ToolStripItem In NewGoodsOperation_MenuItem.DropDownItems
            Try
                menuItem.Enabled = DirectCast(DirectCast(menuItem.Tag, Type).GetMethod(
                    "CanAddObject", BindingFlags.Public Or BindingFlags.Static).Invoke(Nothing, Nothing), Boolean)
            Catch ex As Exception
                menuItem.Enabled = False
            End Try
        Next

        SetParentMenuItemAuthorization(Me.NewGoodsOperation_MenuItem)

        Me.LTAPurchaseMenuItem.Enabled = Assets.LongTermAsset.CanAddObject
        Me.LTAListMenuItem.Enabled = ActiveReports.LongTermAssetInfoList.CanGetObject
        Me.LTAMassOperationMenuItem.Enabled = ActiveReports.LongTermAssetComplexDocumentInfoList.CanGetObject()
        Me.LongTermAssetCustomGroupList_MenuItem.Enabled = Assets.LongTermAssetCustomGroupList.CanGetObject
        Me.LongTermAssetsTransferOfBalance_MenuItem.Enabled = Assets.LongTermAssetsTransferOfBalance.CanGetObject

        For Each menuItem As ToolStripItem In NewComplexOperation_MenuItem.DropDownItems
            Try
                menuItem.Enabled = DirectCast(DirectCast(menuItem.Tag, Type).GetMethod(
                    "CanAddObject", BindingFlags.Public Or BindingFlags.Static).Invoke(Nothing, Nothing), Boolean)
            Catch ex As Exception
                menuItem.Enabled = False
            End Try
        Next

        SetParentMenuItemAuthorization(Me.NewComplexOperation_MenuItem)

        SetParentMenuItemAuthorization(Me.AssetsMenu)

        Me.WorkerStatusMenuItem.Enabled = ActiveReports.ContractInfoList.CanGetObject
        Me.WorkersVDUInfo_MenuItem.Enabled = ActiveReports.WorkersVDUInfo.CanGetObject
        Me.WorkerHolidayInfo_MenuItem.Enabled = ActiveReports.WorkerHolidayInfo.CanGetObject
        Me.HolidayPayReserve_MenuItem.Enabled = Workers.HolidayPayReserve.CanAddObject()
        Me.NewImprestSheetMenuItem.Enabled = Workers.ImprestSheet.CanAddObject
        Me.ImprestSheetInfoListMenuItem.Enabled = ActiveReports.ImprestSheetInfoList.CanGetObject
        Me.NewWageSheetMenuItem.Enabled = Workers.WageSheet.CanAddObject
        Me.WageSheetInfoListMenuItem.Enabled = ActiveReports.WageSheetInfoList.CanGetObject
        Me.WorkerInfoCardMenuItem.Enabled = ActiveReports.WorkerWageInfoReport.CanGetObject
        Me.PayOutNaturalPersonListMenuItem.Enabled = Workers.PayOutNaturalPersonWithTaxesList.CanGetObject
        Me.PayOutNaturalPersonWithoutTaxesList_MenuItem.Enabled = Workers.PayOutNaturalPersonWithoutTaxesList.CanGetObject
        Me.DeclarationMenuItem.Enabled = ActiveReports.Declaration.CanGetObject
        Me.WorkTimeClassList_MenuItem.Enabled = Workers.WorkTimeClassList.CanGetObject
        Me.WorkTimeSheet_MenuItem.Enabled = Workers.WorkTimeSheet.CanAddObject
        Me.WorkTimeSheetInfoList_MenuItem.Enabled = ActiveReports.WorkTimeSheetInfoList.CanGetObject

        SetParentMenuItemAuthorization(Me.WorkersMenu)

        Me.ConsolidatedReportMenuItem.Enabled = ActiveReports.FinancialStatementsInfo.CanGetObject
        Me.ConsolidatedReportStructureMenuItem.Enabled = General.ConsolidatedReport.CanGetObject
        Me.CommandFetchAuditDataFileSAFT_MenuItem.Enabled = ActiveReports.CommandFetchAuditDataFileSAFT.CanExecuteCommand
        Me.DebtsTableMenuItem.Enabled = ActiveReports.DebtInfoList.CanGetObject
        Me.UnsettledPersonInfoList_MenuItem.Enabled = ActiveReports.UnsettledPersonInfoList.CanGetObject
        Me.ServiceTurnoverInfoList_MenuItem.Enabled = ActiveReports.ServiceTurnoverInfoList.CanGetObject
        Me.UserReport_MenuItem.Enabled = ActiveReports.UserReport.CanGetObject()

        SetParentMenuItemAuthorization(Me.ReportsMenu)

        Me.PersonsButton.Enabled = ActiveReports.PersonInfoItemList.CanGetObject
        Me.NewPersonButton.Enabled = General.Person.CanAddObject
        Me.GeneralLedgerButton.Enabled = ActiveReports.JournalEntryInfoList.CanGetObject
        Me.BookEntriesTurnoverButton.Enabled = ActiveReports.BookEntryInfoListParent.CanGetObject
        Me.NewJournalEntryToolStripButton.Enabled = General.JournalEntry.CanAddObject
        Me.InvoiceListButton.Enabled = ActiveReports.InvoiceInfoItemList.CanGetObject
        Me.TillButton.Enabled = ActiveReports.CashOperationInfoList.CanGetObject
        Me.MakeInvoiceButton.Enabled = Documents.InvoiceMade.CanAddObject
        Me.RegisterInvoiceButton.Enabled = Documents.InvoiceReceived.CanAddObject
        Me.TillIncomeOrderButton.Enabled = Documents.TillIncomeOrder.CanAddObject
        Me.TillSpendingsOrderButton.Enabled = Documents.TillSpendingsOrder.CanAddObject
        Me.NewServiceButton.Enabled = Documents.Service.CanAddObject
        Me.ServiceInfoListButton.Enabled = HelperLists.ServiceInfoList.CanGetObject
        Me.GoodsTurnoverInfoButton.Enabled = ActiveReports.GoodsTurnoverInfoList.CanGetObject
        Me.NewGoodsItemButton.Enabled = Goods.GoodsItem.CanAddObject

    End Sub

    Private Sub SetParentMenuItemAuthorization(ByRef parentMenuItem As ToolStripMenuItem)

        For Each t As ToolStripItem In parentMenuItem.DropDownItems
            If Not TypeOf t Is ToolStripSeparator AndAlso t.Enabled Then
                parentMenuItem.Enabled = True
                Exit Sub
            End If
        Next

        parentMenuItem.Enabled = False

    End Sub

#Region "***ADMINISTRAVIMAS***"

    Private Sub NewCompanyMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles NewCompanyMenuItem.Click

        If IsLoggedInDB() Then
            If Not YesOrNo(String.Format("Ar tikrai norite baigti darbą su {0}?", GetCurrentCompany.Name)) Then
                Exit Sub
            End If
            Try
                Using busy As New StatusBusy
                    AccPrincipal.Login("", New CustomCacheManager)
                    LogOffToGUI()
                End Using
            Catch ex As Exception
                ShowError(ex, Nothing)
                Exit Sub
            End Try
        End If

        LaunchForm(GetType(F_NewCompany), True, True, 0)

    End Sub

    Private Sub DropCompanyMenuItem_Click(ByVal sender As System.Object,
            ByVal e As System.EventArgs) Handles DropCompanyMenuItem.Click

        If IsLoggedInDB() Then
            If Not YesOrNo(String.Format("Ar tikrai norite baigti darbą su {0}?", GetCurrentCompany.Name)) Then Exit Sub
            Try
                Using busy As New StatusBusy
                    AccPrincipal.Login("", New CustomCacheManager)
                    LogOffToGUI()
                End Using
            Catch ex As Exception
                ShowError(ex, Nothing)
                Exit Sub
            End Try
        End If

        LaunchForm(GetType(F_DeleteDatabase), True, True, 0)

    End Sub

    Private Sub ExitMenuItem_Click(ByVal sender As Object,
        ByVal e As EventArgs) Handles ExitMenuItem.Click
        My.Application.IsInternalShutdown = True
        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub ProgramSetupMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles ProgramSetupMenuItem.Click
        OpenNewForm(Of AccDataBindingsWinForms.Settings.LocalSettings)()
    End Sub

    ''' <summary>
    ''' Handles clicks on company selection menu items and performs login to a database.
    ''' </summary>
    Public Sub LoginToCompany(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim menuItem As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        If menuItem Is Nothing Then Exit Sub
        Dim selectedCompany As DatabaseInfo = TryCast(menuItem.Tag, DatabaseInfo)
        If selectedCompany Is Nothing Then Exit Sub

        If IsLoggedInDB() Then

            If Not YesOrNo(String.Format("Ar tikrai norite baigti darbą su {0}?", GetCurrentCompany.Name)) Then Exit Sub

            Try
                Using busy As New StatusBusy
                    AccPrincipal.Login("", New CustomCacheManager)
                    LogOffToGUI()
                End Using
            Catch ex As Exception
                ShowError(ex, Nothing)
                Exit Sub
            End Try

        End If

        If GetCurrentIdentity.IsLocalUser Then

            Try
                If AccPrincipal.Login(selectedCompany.DatabaseName, New CustomCacheManager, "") Then
                    LogInToGUI()
                    Exit Sub
                End If
            Catch ex As Exception
                if Not ex.Message.Contains("neturite teisės") Then
                    If ex.Message.Contains("vykdant SELECT") Then
                        ShowError(New Exception("Duomenų bazės struktūros klaida, ištaisykite klaidas (arba atnaujinkite duomenų struktūrą po programos atnaujinimo) nuėję į Bendras\DB Struktūra.", ex))
                    Else 
                        ShowError(ex)
                    End If
                    Exit Sub
                End If
            End Try

            Using frm As New F_LoginSecondary(selectedCompany)
                frm.ShowDialog()
                If frm.IsLogonSuccesfull Then LogInToGUI()
            End Using

        Else


            Try
                Using busy As New StatusBusy
                    AccPrincipal.Login(selectedCompany.DatabaseName, New CustomCacheManager)
                    LogInToGUI()
                End Using
            Catch ex As Exception
                ShowError(ex, Nothing)
            End Try

        End If

    End Sub

    Private Sub UserAdministrationMenuItem_Click(ByVal sender As System.Object,
            ByVal e As System.EventArgs) Handles UserAdministrationMenuItem.Click

        If IsLoggedInDB() Then
            If Not YesOrNo(String.Format("Ar tikrai norite baigti darbą su {0}?", GetCurrentCompany.Name)) Then Exit Sub
            Try
                Using busy As New StatusBusy
                    AccPrincipal.Login("", New CustomCacheManager)
                    LogOffToGUI()
                End Using
            Catch ex As Exception
                ShowError(ex, Nothing)
                Exit Sub
            End Try

        End If

        LaunchForm(GetType(F_User), True, True, 0)

    End Sub

    Private Sub LogOffMenuItem_Click(ByVal sender As System.Object,
            ByVal e As System.EventArgs) Handles LogOffMenuItem.Click

        If Not IsLoggedInDB() Then Exit Sub

        If Not YesOrNo(String.Format("Ar tikrai norite baigti darbą su {0}?", GetCurrentCompany.Name)) Then Exit Sub

        Try
            Using busy As New StatusBusy
                AccPrincipal.Login("", New CustomCacheManager)
                LogOffToGUI()
            End Using
        Catch ex As Exception
            ShowError(ex, Nothing)
            Exit Sub
        End Try

    End Sub

    Private Sub BackupMenuItem_Click_1(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles BackupMenuItem.Click
        LaunchForm(GetType(F_BackUp), True, False, 0)
    End Sub

    Private Sub ChangePasswordMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles ChangePasswordMenuItem.Click
        LaunchForm(GetType(F_ChangePassword), True, False, 0)
    End Sub

    Private Sub UpgradeDBMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles UpgradeDBMenuItem.Click
        LaunchForm(GetType(F_DatabaseStructureError), True, False, 0)
    End Sub

    Private Sub QueryBrowserMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles QueryBrowserMenuItem.Click
        LaunchForm(GetType(F_RawSqlFetch), False, False, 0)
    End Sub

    Private Sub DatabaseStructureEditor_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles DatabaseStructureEditor_MenuItem.Click
        LaunchForm(GetType(F_DatabaseStructureEditor), False, False, 0)
    End Sub

    Private Sub RoleStructureEditor_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles RoleStructureEditor_MenuItem.Click
        LaunchForm(GetType(F_DatabaseTableAccessRoleList), False, False, 0)
    End Sub

    Private Sub RdlDesigner_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles RdlDesigner_MenuItem.Click

        Dim frm As New fyiReporting.RdlDesign.RdlDesigner("", False)
        frm.Show()

    End Sub

    Private Sub UserReportInfoList_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles UserReportInfoList_MenuItem.Click
        OpenNewForm(Of HelperLists.UserReportInfoList)()
    End Sub

#End Region

#Region "***DUOMENYS***"

    Private Sub AccountsListMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles AccountsListMenuItem.Click
        OpenNewForm(Of General.AccountList)()
    End Sub

    Private Sub CompanyInfoMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles CompanyInfoMenuItem.Click
        OpenNewForm(Of General.Company)()
    End Sub

    Private Sub PersonsMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles PersonsMenuItem.Click, PersonsButton.Click
        OpenNewForm(Of ActiveReports.PersonInfoItemList)()
    End Sub

    Private Sub NewPerson_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles NewPerson_MenuItem.Click, NewPersonButton.Click
        OpenNewForm(Of General.Person)()
    End Sub

    Private Sub PersonGroupsMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles PersonGroupsMenuItem.Click
        OpenNewForm(Of General.PersonGroupList)()
    End Sub

    Private Sub ImportedPersonList_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles ImportedPersonList_MenuItem.Click
        OpenNewForm(Of General.ImportedPersonList)()
    End Sub

    Private Sub GeneralLedgerMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles GeneralLedgerMenuItem.Click, GeneralLedgerButton.Click
        OpenNewForm(Of ActiveReports.JournalEntryInfoList)()
    End Sub

    Private Sub BookEntriesTurnoverMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles BookEntriesTurnoverMenuItem.Click, BookEntriesTurnoverButton.Click
        OpenNewForm(Of ActiveReports.BookEntryInfoListParent)()
    End Sub

    Private Sub NewJournalEntryMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles NewJournalEntryMenuItem.Click,
        NewJournalEntryToolStripButton.Click
        OpenNewForm(Of General.JournalEntry)()
    End Sub

    Private Sub AccumulativeCosts_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles AccumulativeCosts_MenuItem.Click
        OpenNewForm(Of Documents.AccumulativeCosts)()
    End Sub

    Private Sub JournalEntryTemplatesMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles JournalEntryTemplatesMenuItem.Click
        OpenNewForm(Of HelperLists.TemplateJournalEntryInfoList)()
    End Sub

    Private Sub TransferOfBalanceMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles TransferOfBalanceMenuItem.Click
        OpenNewForm(Of General.TransferOfBalance)()
    End Sub

    Private Sub ServerSideSettingsMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles ServerSideSettingsMenuItem.Click
        OpenNewForm(Of ApskaitaObjects.Settings.CommonSettings)()
    End Sub

    Private Sub DocumentSerialList_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles DocumentSerialList_MenuItem.Click
        OpenNewForm(Of ApskaitaObjects.Settings.DocumentSerialList)()
    End Sub

    Private Sub ShareHolderInfoList_MenuItem_Click(sender As Object, e As EventArgs) Handles ShareHolderInfoList_MenuItem.Click
        OpenNewForm(Of ActiveReports.ShareHolderInfoList)()
    End Sub

    Private Sub SharesAccountEntryList_MenuItem_Click(sender As Object, e As EventArgs) Handles SharesAccountEntryList_MenuItem.Click
        OpenNewForm(Of ActiveReports.SharesAccountEntryList)()
    End Sub

    Private Sub SharesOperationInfoList_MenuItem_Click(sender As Object, e As EventArgs) Handles SharesOperationInfoList_MenuItem.Click
        OpenNewForm(Of ActiveReports.SharesOperationInfoList)()
    End Sub

    Private Sub SharesOperation_MenuItem_Click(sender As Object, e As EventArgs) Handles SharesOperation_MenuItem.Click
        OpenNewForm(Of General.SharesOperation)()
    End Sub

    Private Sub SharesClassList_MenuItem_Click(sender As Object, e As EventArgs) Handles SharesClassList_MenuItem.Click
        OpenNewForm(Of General.SharesClassList)()
    End Sub

#End Region

#Region "***DOKUMENTAI***"

    Private Sub CashAccountList_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles CashAccountList_MenuItem.Click
        OpenNewForm(Of Documents.CashAccountList)()
    End Sub

    Private Sub BankTransferMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles BankTransferMenuItem.Click
        OpenNewForm(Of Documents.BankOperation)()
    End Sub

    Private Sub InvoiceMadeMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles InvoiceMadeMenuItem.Click, MakeInvoiceButton.Click
        OpenNewForm(Of Documents.InvoiceMade)()
    End Sub

    Private Sub ProformaInvoiceMadeMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles ProformaInvoiceMadeMenuItem.Click
        OpenNewForm(Of Documents.ProformaInvoiceMade)()
    End Sub

    Private Sub InvoiceListMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles InvoiceListMenuItem.Click, InvoiceListButton.Click
        OpenNewForm(Of ActiveReports.InvoiceInfoItemList)()
    End Sub

    Private Sub InvoiceReceivedMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles InvoiceReceivedMenuItem.Click, RegisterInvoiceButton.Click
        OpenNewForm(Of Documents.InvoiceReceived)()
    End Sub

    Private Sub TillIncomeOrderMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles TillIncomeOrderMenuItem.Click, TillIncomeOrderButton.Click
        OpenNewForm(Of Documents.TillIncomeOrder)()
    End Sub

    Private Sub TillSpendingsOrderMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles TillSpendingsOrderMenuItem.Click, TillSpendingsOrderButton.Click
        OpenNewForm(Of Documents.TillSpendingsOrder)()
    End Sub

    Private Sub CashOperationInfoListMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles CashOperationInfoListMenuItem.Click, TillButton.Click
        OpenNewForm(Of ActiveReports.CashOperationInfoList)()
    End Sub

    Private Sub BankImportMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles BankImportMenuItem.Click
        OpenNewForm(Of Documents.BankOperationItemList)()
    End Sub

    Private Sub ServiceListMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles ServiceListMenuItem.Click, ServiceInfoListButton.Click
        OpenNewForm(Of ActiveReports.ServiceInfoItemList)()
    End Sub

    Private Sub NewService_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles NewService_MenuItem.Click, NewServiceButton.Click
        OpenNewForm(Of Documents.Service)()
    End Sub

    Private Sub AdvanceReportListMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles AdvanceReportListMenuItem.Click
        OpenNewForm(Of ActiveReports.AdvanceReportInfoList)()
    End Sub

    Private Sub AdvanceReport_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles AdvanceReport_MenuItem.Click
        OpenNewForm(Of Documents.AdvanceReport)()
    End Sub

    Private Sub NewOffset_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles NewOffset_MenuItem.Click
        OpenNewForm(Of Documents.Offset)()
    End Sub

    Private Sub DebtStatementItemListMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles DebtStatementItemListMenuItem.Click
        OpenNewForm(Of ActiveReports.DebtStatementItemList)()
    End Sub

    Private Sub VatDeclarationSchemaInfoItemList_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles VatDeclarationSchemaInfoItemList_MenuItem.Click
        OpenNewForm(Of ActiveReports.VatDeclarationSchemaInfoItemList)()
    End Sub

    Private Sub CustomVatOperationList_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles CustomVatOperationList_MenuItem.Click
        OpenNewForm(Of Documents.CustomVatOperationList)()
    End Sub

    Private Sub VatDeclaration_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles VatDeclaration_MenuItem.Click
        OpenNewForm(Of ActiveReports.VatDeclaration)()
    End Sub

    Private Sub ImportInvoicesMenuItem_Click(sender As Object, e As EventArgs) Handles ImportInvoicesMenuItem.Click
        LaunchForm(GetType(F_ImportInvoices), True, False, 0)
    End Sub

#End Region

#Region "***IRANKIAI***"

    Private Sub ConsolidatedReportMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles ConsolidatedReportMenuItem.Click
        OpenNewForm(Of ActiveReports.FinancialStatementsInfo)()
    End Sub

    Private Sub ConsolidatedReportStructureMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles ConsolidatedReportStructureMenuItem.Click
        OpenNewForm(Of General.ConsolidatedReport)()
        ' LaunchForm(GetType(F_ConsolidatedReportsStructure), False, False, 0)
    End Sub

    Private Sub CommandFetchAuditDataFileSAFT_MenuItem_Click(sender As Object, e As EventArgs) Handles CommandFetchAuditDataFileSAFT_MenuItem.Click
        OpenNewForm(Of ActiveReports.CommandFetchAuditDataFileSAFT)()
    End Sub

    Private Sub CurrencyRateChangeImpactCalculator_MenuItem_Click_1(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles CurrencyRateChangeImpactCalculator_MenuItem.Click
        ShowCurrencyRateChangeImpactCalculator()
    End Sub

    Private Sub DebtsTableMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles DebtsTableMenuItem.Click
        OpenNewForm(Of ActiveReports.DebtInfoList)()
    End Sub

    Private Sub UnsettledPersonInfoList_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles UnsettledPersonInfoList_MenuItem.Click
        OpenNewForm(Of ActiveReports.UnsettledPersonInfoList)()
    End Sub

    Private Sub ServiceTurnoverInfoList_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles ServiceTurnoverInfoList_MenuItem.Click
        OpenNewForm(Of ActiveReports.ServiceTurnoverInfoList)()
    End Sub

    Private Sub UserReport_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles UserReport_MenuItem.Click
        OpenNewForm(Of ActiveReports.UserReport)()
    End Sub

#End Region

#Region "***HELPAI***"

    Private Sub AboutMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles AboutMenuItem.Click
        'jei useris nori suzinoti apie programa
        LaunchForm(GetType(Apie), False, True, 0)
    End Sub

    Private Sub CheckIfUpdateAvailable_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles CheckIfUpdateAvailable_MenuItem.Click
        MyCustomSettings.CheckForUpdates()
    End Sub

    Private Sub HelpToolStripButton_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles HelpToolStripButton.Click, HelpMenuItem.Click

        If Me.ActiveMdiChild Is Nothing Then
            Help.ShowHelp(Me, "Apskaita5Help.chm")
        Else
            Dim topicID As String = Me.ActiveMdiChild.GetType.Name
            If topicID.Length > 32 Then topicID = topicID.Substring(0, 32)
            topicID = topicID & ".htm"
            Help.ShowHelp(Me, "Apskaita5Help.chm", HelpNavigator.Topic, topicID)
        End If

    End Sub

#End Region

#Region "***TURTO MODULIS***"

    Private Sub LTAPurchaseMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles LTAPurchaseMenuItem.Click
        OpenNewForm(Of Assets.LongTermAsset)()
    End Sub

    Private Sub LongTermAssetsTransferOfBalance_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles LongTermAssetsTransferOfBalance_MenuItem.Click
        OpenNewForm(Of Assets.LongTermAssetsTransferOfBalance)()
    End Sub

    Private Sub LTAListMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles LTAListMenuItem.Click
        OpenNewForm(Of ActiveReports.LongTermAssetInfoList)()
    End Sub

    Private Sub LongTermAssetCustomGroupList_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles LongTermAssetCustomGroupList_MenuItem.Click
        OpenNewForm(Of Assets.LongTermAssetCustomGroupList)()
    End Sub

    Private Sub LTAMassOperationMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles LTAMassOperationMenuItem.Click
        OpenNewForm(Of ActiveReports.LongTermAssetComplexDocumentInfoList)()
    End Sub

    Private Sub NewComplexAssetOperation_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs)

        Dim operationType As Type = Nothing
        Try
            operationType = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Type)
        Catch ex As Exception
        End Try
        If operationType Is Nothing Then Exit Sub

        OpenNewForm(operationType)

    End Sub


    Private Sub NewGoodsItem_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles NewGoodsItem_MenuItem.Click, NewGoodsItemButton.Click
        OpenNewForm(Of Goods.GoodsItem)()
    End Sub

    Private Sub ImportedGoodsItemList_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles ImportedGoodsItemList_MenuItem.Click
        OpenNewForm(Of Goods.ImportedGoodsItemList)()
    End Sub

    Private Sub GoodsTurnoverInfoList_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles GoodsTurnoverInfoList_MenuItem.Click, GoodsTurnoverInfoButton.Click
        OpenNewForm(Of ActiveReports.GoodsTurnoverInfoList)()
    End Sub

    Private Sub ProductionCalculationSheetList_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles ProductionCalculationSheetList_MenuItem.Click
        OpenNewForm(Of ActiveReports.ProductionCalculationItemList)()
    End Sub

    Private Sub GoodsGroupListMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles GoodsGroupListMenuItem.Click
        OpenNewForm(Of Goods.GoodsGroupList)()
    End Sub

    Private Sub WarehouseList_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles WarehouseList_MenuItem.Click
        OpenNewForm(Of Goods.WarehouseList)()
    End Sub

    Private Sub GoodsOperationInfoList_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles GoodsOperationInfoList_MenuItem.Click
        OpenNewForm(Of ActiveReports.GoodsOperationInfoListParent)()
    End Sub

    Private Sub NewComplexGoodsOperation_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs)

        Dim operationType As Type = Nothing
        Try
            operationType = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Type)
        Catch ex As Exception
        End Try
        If operationType Is Nothing Then Exit Sub

        GoodsOperationManager.StartNewGoodsOperation(operationType)

    End Sub

    Private Sub GoodsComplexOperationTransferOfBalance_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles GoodsComplexOperationTransferOfBalance_MenuItem.Click
        OpenNewForm(Of Goods.GoodsComplexOperationTransferOfBalance)()
    End Sub

    Private Sub NewProductionCalculation_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles NewProductionCalculation_MenuItem.Click
        OpenNewForm(Of Goods.ProductionCalculation)()
    End Sub

#End Region

#Region "***DARBUOTOJŲ MODULIS***"

    Private Sub WorkerStatusMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles WorkerStatusMenuItem.Click
        OpenNewForm(Of ActiveReports.ContractInfoList)()
    End Sub

    Private Sub WorkersVDUInfo_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles WorkersVDUInfo_MenuItem.Click
        OpenNewForm(Of ActiveReports.WorkersVDUInfo)()
    End Sub

    Private Sub WorkerHolidayInfo_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles WorkerHolidayInfo_MenuItem.Click
        OpenNewForm(Of ActiveReports.WorkerHolidayInfo)()
    End Sub

    Private Sub HolidayPayReserve_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles HolidayPayReserve_MenuItem.Click
        OpenNewForm(Of Workers.HolidayPayReserve)()
    End Sub

    Friend Sub NewWageSheetMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles NewWageSheetMenuItem.Click
        OpenNewForm(Of Workers.WageSheet)()
    End Sub

    Private Sub WageSheetInfoListMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles WageSheetInfoListMenuItem.Click
        OpenNewForm(Of ActiveReports.WageSheetInfoList)()
    End Sub

    Friend Sub NewImprestSheetMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles NewImprestSheetMenuItem.Click
        OpenNewForm(Of Workers.ImprestSheet)()
    End Sub

    Private Sub ImprestSheetInfoListMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles ImprestSheetInfoListMenuItem.Click
        OpenNewForm(Of ActiveReports.ImprestSheetInfoList)()
    End Sub

    Private Sub PayOutNaturalPersonListMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles PayOutNaturalPersonListMenuItem.Click
        OpenNewForm(Of Workers.PayOutNaturalPersonWithTaxesList)()
    End Sub

    Private Sub PayOutNaturalPersonWithoutTaxesList_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles PayOutNaturalPersonWithoutTaxesList_MenuItem.Click
        OpenNewForm(Of Workers.PayOutNaturalPersonWithoutTaxesList)()
    End Sub

    Private Sub DeclarationMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles DeclarationMenuItem.Click
        OpenNewForm(Of ActiveReports.Declaration)()
    End Sub

    Private Sub WorkerInfoCardMenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles WorkerInfoCardMenuItem.Click
        OpenNewForm(Of ActiveReports.WorkerWageInfoReport)()
    End Sub

    Private Sub WorkTimeClassList_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles WorkTimeClassList_MenuItem.Click
        OpenNewForm(Of Workers.WorkTimeClassList)()
    End Sub

    Private Sub WorkTimeSheet_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles WorkTimeSheet_MenuItem.Click
        OpenNewForm(Of Workers.WorkTimeSheet)()
    End Sub

    Private Sub WorkTimeSheetInfoList_MenuItem_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles WorkTimeSheetInfoList_MenuItem.Click
        OpenNewForm(Of ActiveReports.WorkTimeSheetInfoList)()
    End Sub

#End Region

#Region "***TECHNINIAI***"

    ' CHILD FORMS ADMINISTRATION METHODS

    Friend Sub LaunchForm(ByVal formType As Type, ByVal singleForm As Boolean,
        ByVal showAsDialog As Boolean, ByVal objectId As Long, ByVal ParamArray paramObjects As Object())

        Dim formIndex As Integer = 0

        If singleForm Then
            For Each frm As Form In Me.MdiChildren
                If frm.GetType Is formType Then
                    frm.BringToFront()
                    frm.Activate()
                    Exit Sub
                End If
            Next
        ElseIf objectId > 0 Then
            For Each frm As Form In Me.MdiChildren
                If frm.GetType Is formType AndAlso TypeOf frm Is IObjectEditForm _
                    AndAlso DirectCast(frm, IObjectEditForm).ObjectID = objectId Then
                    frm.BringToFront()
                    frm.Activate()
                    Exit Sub
                End If
            Next
        Else
            For Each frm As Form In Me.MdiChildren
                If frm.GetType Is formType Then
                    formIndex += 1
                End If
            Next
        End If

        Dim newForm As Form
        If paramObjects Is Nothing OrElse paramObjects.Length < 1 Then
            newForm = DirectCast(Activator.CreateInstance(formType), Form)
        Else
            newForm = DirectCast(Activator.CreateInstance(formType, paramObjects), Form)
        End If

        If showAsDialog Then
            newForm.ShowDialog(Me)
        Else
            newForm.MdiParent = Me
            If formIndex > 0 Then newForm.Text = String.Format("{0} ({1})", newForm.Text, formIndex.ToString)
            'AddHandler newForm.FormClosed, AddressOf BringMdiChildrenToMenu
            'BringMdiChildrenToMenu(newForm, Nothing)
            newForm.Show()
        End If

    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object,
        ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object,
            ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object,
            ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object,
            ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object,
            ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each childForm As Form In Me.MdiChildren
            childForm.Close()
        Next
    End Sub

    ' PRINTING INFRASTRUCTURE METHODS

    Private Sub PrintToolStripSplitButton_ButtonClick(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles PrintToolStripSplitButton.ButtonClick
        If Me.ActiveMdiChild Is Nothing OrElse Not TypeOf Me.ActiveMdiChild Is ISupportsPrinting Then Exit Sub
        Dim activeChild As ISupportsPrinting = DirectCast(Me.ActiveMdiChild, ISupportsPrinting)
        activeChild.OnPrintClick(sender, e)
    End Sub

    Private Sub PreviewToolStripSplitButton_ButtonClick(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles PreviewToolStripSplitButton.ButtonClick
        If Me.ActiveMdiChild Is Nothing OrElse Not TypeOf Me.ActiveMdiChild Is ISupportsPrinting Then Exit Sub
        Dim activeChild As ISupportsPrinting = DirectCast(Me.ActiveMdiChild, ISupportsPrinting)
        activeChild.OnPrintPreviewClick(sender, e)
    End Sub

    Private Sub EmailToolStripSplitButton_ButtonClick(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles EmailToolStripSplitButton.ButtonClick
        If Me.ActiveMdiChild Is Nothing OrElse Not TypeOf Me.ActiveMdiChild Is ISupportsPrinting Then Exit Sub
        Dim activeChild As ISupportsPrinting = DirectCast(Me.ActiveMdiChild, ISupportsPrinting)
        activeChild.OnMailClick(sender, e)
    End Sub

    Private Sub MainForm_MdiChildActivate(ByVal sender As Object,
        ByVal e As System.EventArgs) Handles Me.MdiChildActivate

        If Me.ActiveMdiChild Is Nothing OrElse Not TypeOf Me.ActiveMdiChild Is ISupportsPrinting Then

            PrintToolStripSplitButton.Enabled = False
            PreviewToolStripSplitButton.Enabled = False
            EmailToolStripSplitButton.Enabled = False
            PrintToolStripSplitButton.DropDown = Nothing
            PreviewToolStripSplitButton.DropDown = Nothing
            EmailToolStripSplitButton.DropDown = Nothing

        Else

            Dim activeChild As ISupportsPrinting = DirectCast(Me.ActiveMdiChild, ISupportsPrinting)
            PrintToolStripSplitButton.Enabled = True
            PreviewToolStripSplitButton.Enabled = True
            EmailToolStripSplitButton.Enabled = activeChild.SupportsEmailing
            PrintToolStripSplitButton.DropDown = activeChild.GetPrintDropDownItems
            PreviewToolStripSplitButton.DropDown = activeChild.GetPrintPreviewDropDownItems
            EmailToolStripSplitButton.DropDown = activeChild.GetMailDropDownItems

        End If

        If Me.ActiveMdiChild Is Nothing OrElse Not TypeOf Me.ActiveMdiChild Is ISupportsChronologicValidator Then

            ChronologicValidatorToolStripButton.Visible = False
            ToolStripSeparator24.Visible = False

        Else

            ChronologicValidatorToolStripButton.Visible = True
            ToolStripSeparator24.Visible = True

        End If

    End Sub


    Private Sub ChronologicValidatorToolStripButton_Click(ByVal sender As Object,
        ByVal e As System.EventArgs) Handles ChronologicValidatorToolStripButton.Click

        If Me.ActiveMdiChild Is Nothing OrElse Not TypeOf Me.ActiveMdiChild Is ISupportsChronologicValidator Then
            Exit Sub
        End If

        Dim message As String = DirectCast(Me.ActiveMdiChild,
            ISupportsChronologicValidator).ChronologicContent

        If String.IsNullOrEmpty(message) Then
            MsgBox("Dokumentui nėra chronologinių apribojimų.", MsgBoxStyle.Information, "Info")
        Else
            MsgBox("Dokumentui taikomi chronologiniai apribojimai:" _
                & vbCrLf & message, MsgBoxStyle.Information, "Info")
        End If

    End Sub

    Private Sub MakeGlassToolStripButton_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles MakeGlassToolStripButton.Click
        If MakeGlassToolStripButton.Checked Then
            Me.Opacity = 0.5
        Else
            Me.Opacity = 1
        End If
    End Sub

    Private Sub ShowToolStripMenuItem_Click(ByVal sender As System.Object,
            ByVal e As System.EventArgs) Handles ShowToolStripMenuItem.Click
        Try
            MyCustomSettings.ShowToolStrip = ShowToolStripMenuItem.Checked
            MyCustomSettings.Save()
        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko išsaugoti programos nustatymų: " & ex.Message, ex), Nothing)
        End Try
        Me.ToolStrip1.Visible = ShowToolStripMenuItem.Checked
    End Sub

    Private Sub searchTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles searchTextBox.KeyDown
        If Me.ActiveMdiChild Is Nothing OrElse e.KeyData <> Keys.Enter Then Exit Sub
        SetDataListViewFilter(Me.ActiveMdiChild)
    End Sub

    Private Sub searchButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles searchButton.Click
        If Me.ActiveMdiChild Is Nothing Then Exit Sub
        SetDataListViewFilter(Me.ActiveMdiChild)
    End Sub

    Private Sub SetDataListViewFilter(ByVal frm As Control)
        If TypeOf frm Is DataListView Then
            DirectCast(frm, DataListView).AdditionalFilter =
                TextMatchFilter.Contains(DirectCast(frm, DataListView), searchTextBox.Text)
            Exit Sub
        End If
        For Each c As Control In frm.Controls
            SetDataListViewFilter(c)
        Next
    End Sub

#End Region

    Private Function GetWorkDays(ByVal dateFrom As Date, ByVal dateTo As Date) As Integer

        Dim hd As HelperLists.DefaultWorkTimeInfoList = HelperLists.DefaultWorkTimeInfoList.GetList()

        Dim result As Integer = 0
        Dim current As Date = dateFrom.Date
        While Not current > dateTo.Date

            If current.DayOfWeek <> DayOfWeek.Saturday AndAlso
                current.DayOfWeek <> DayOfWeek.Sunday AndAlso
                Not hd.IsPublicHolidays(current) Then
                result += 1
            End If

            current = current.AddDays(1)

        End While

        Return result

    End Function

    Private Sub KalkuliatoriusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KalkuliatoriusToolStripMenuItem.Click
        LaunchForm(GetType(F_Calculator), False, False, 0)
    End Sub

    
End Class
