﻿Imports ApskaitaObjects.Workers
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.CachedInfoLists
Imports AccDataBindingsWinForms.Printing

Friend Class F_WageSheet
    Implements ISupportsPrinting, IObjectEditForm, ISupportsChronologicValidator

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(HelperLists.AccountInfoList)}

    Private WithEvents _FormManager As CslaActionExtenderEditForm(Of WageSheet)
    Private _ListViewManager As DataListViewEditControlManager(Of WageItem)
    Private _QueryManager As CslaActionExtenderQueryObject

    Private _DocumentToEdit As WageSheet = Nothing

    Private _PrintDropDown As Windows.Forms.ToolStripDropDown = Nothing
    Private _PrintPreviewDropDown As Windows.Forms.ToolStripDropDown = Nothing
    Private _EmailDropDown As Windows.Forms.ToolStripDropDown = Nothing


    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If _FormManager Is Nothing OrElse _FormManager.DataSource Is Nothing Then
                If _DocumentToEdit Is Nothing OrElse _DocumentToEdit.IsNew Then
                    Return Integer.MinValue
                Else
                    Return _DocumentToEdit.ID
                End If
            End If
            Return _FormManager.DataSource.ID
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(WageSheet)
        End Get
    End Property


    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal documentToEdit As WageSheet)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _DocumentToEdit = documentToEdit

    End Sub


    Private Sub F_WageSheet_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If _DocumentToEdit Is Nothing Then
            Using frm As New F_NewSheet(Of WageSheet)
                frm.ShowDialog()
                _DocumentToEdit = frm.Result
            End Using
        End If

        If _DocumentToEdit Is Nothing Then
            Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        Try

            _FormManager = New CslaActionExtenderEditForm(Of WageSheet) _
                (Me, WageSheetBindingSource, _DocumentToEdit, _
                 _RequiredCachedLists, nOkButton, ApplyButton, nCancelButton, _
                 Nothing, ProgressFiller1)

            _FormManager.ManageDataListViewStates(ItemsDataListView)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        ConfigureButtons()

    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, _RequiredCachedLists) Then Return False

        Try

            _ListViewManager = New DataListViewEditControlManager(Of WageItem) _
                (ItemsDataListView, Nothing, Nothing, Nothing, Nothing, _DocumentToEdit)

            _ListViewManager.AddCancelButton = False
            _ListViewManager.AddButtonHandler("Nepanaudotos Atost.", "Gauti nepanaudotas atostogas.", _
                AddressOf FetchUnusedHoliday)

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            SetupDefaultControls(Of WageSheet)(Me, WageSheetBindingSource, _DocumentToEdit)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function


    Private Sub NewWageSheetButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewWageSheetButton.Click

        Dim result As WageSheet = Nothing
        Using frm As New F_NewSheet(Of WageSheet)
            frm.ShowDialog()
            result = frm.Result
        End Using
        If Not result Is Nothing Then
            _FormManager.AddNewDataSource(result)
        End If

    End Sub

    Private Sub RefreshTaxesButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshTaxesButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        If Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange Then
            MsgBox("Klaida. Finansinių žiniaraščio duomenų keisti neleidžiama:" & vbCrLf _
                & _FormManager.DataSource.ChronologicValidator.FinancialDataCanChangeExplanation, _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Try
            Using busy As New StatusBusy
                _FormManager.DataSource.UpdateTaxRates()
            End Using
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try

    End Sub

    Private Sub RefreshWageTarifButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshWageTarifButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        If Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange Then
            MsgBox("Klaida. Finansinių žiniaraščio duomenų keisti neleidžiama:" & vbCrLf _
                & _FormManager.DataSource.ChronologicValidator.FinancialDataCanChangeExplanation, _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Try
            Using busy As New StatusBusy
                _FormManager.DataSource.UpdateWageRates()
            End Using
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try

    End Sub

    Private Sub GetVDUButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles GetVDUButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        If Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange Then
            MsgBox("Klaida. Finansinių žiniaraščio duomenų keisti neleidžiama:" & vbCrLf _
                & _FormManager.DataSource.ChronologicValidator.FinancialDataCanChangeExplanation, _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Dim selItems() As ActiveReports.WorkersVDUInfo = _FormManager.DataSource.GetWorkersVDUInfoArray

        If selItems Is Nothing OrElse selItems.Length < 1 Then
            MsgBox("Klaida. Nepasirinktas nė vienas darbuotojas.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        ' ActiveReports.WorkersVDUInfoList.GetList(selItems)
        _QueryManager.InvokeQuery(Of ActiveReports.WorkersVDUInfoList)(Nothing, "GetList", True, _
            AddressOf OnVduInfoListFetched, New Object() {selItems})

    End Sub

    Private Sub OnVduInfoListFetched(ByVal result As Object, ByVal exceptionHandled As Boolean)

        If result Is Nothing OrElse _FormManager.DataSource Is Nothing Then Exit Sub

        Try
            Using busy As New StatusBusy
                _FormManager.DataSource.UpdateWorkersVDUInfo(DirectCast(result, ActiveReports.WorkersVDUInfoList))
            End Using
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
            Exit Sub
        End Try

        MsgBox("VDU duomenys sėkmingai gauti.", MsgBoxStyle.Information, "Info")

    End Sub

    Private Sub CalculateNPDButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles CalculateNPDButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        If Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange Then
            MsgBox("Klaida. Finansinių žiniaraščio duomenų keisti neleidžiama:" & vbCrLf _
                & _FormManager.DataSource.ChronologicValidator.FinancialDataCanChangeExplanation, _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Try
            Using busy As New StatusBusy
                _FormManager.DataSource.CalculateNPD()
            End Using
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try

    End Sub

    Private Sub SetPaymentDateButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles SetPaymentDateButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        If Not YesOrNo("Ar tikrai norite nustatyti vienodą išmokėjimo datą visoms pasirinktoms eilutėms?") Then Exit Sub

        For Each i As WageItem In _FormManager.DataSource.Items
            If i.IsChecked Then i.PayedOutDate = PaymentDateAccDatePicker.Value.Date.ToString()
        Next

    End Sub

    Private Sub ViewJournalEntryButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ViewJournalEntryButton.Click
        If _FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.ID > 0 Then Exit Sub
        OpenJournalEntryEditForm(_QueryManager, _FormManager.DataSource.ID)
    End Sub

    Private Sub FetchUnusedHoliday(ByVal item As WageItem)

        If item Is Nothing OrElse _FormManager.DataSource Is Nothing Then Exit Sub

        If Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange Then
            MsgBox("Klaida. Finansinių žiniaraščio duomenų keisti neleidžiama:" & vbCrLf _
                & _FormManager.DataSource.ChronologicValidator.FinancialDataCanChangeExplanation, _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        If Not YesOrNo("Gauti šio darbuotojo nepanaudotų atostogų kiekį?") Then Exit Sub

        'ActiveReports.WorkerHolidayInfo.GetWorkerHolidayInfo(_FormManager.DataSource.Date, _
        '    item.ContractSerial, item.ContractNumber, True)
        _QueryManager.InvokeQuery(Of ActiveReports.WorkerHolidayInfo)(Nothing, _
            "GetWorkerHolidayInfo", True, AddressOf OnUnusedHolidayFetched, _
            _FormManager.DataSource.Date, item.ContractSerial, item.ContractNumber, True)

    End Sub

    Private Sub OnUnusedHolidayFetched(ByVal result As Object, ByVal exceptionHandled As Boolean)

        If result Is Nothing Then Exit Sub

        Dim unusedHolidayInfo As ActiveReports.WorkerHolidayInfo = DirectCast(result, ActiveReports.WorkerHolidayInfo)

        For Each item As WageItem In _FormManager.DataSource.Items
            If item.ContractNumber = unusedHolidayInfo.ContractNumber _
                AndAlso item.ContractSerial.Trim.ToLower = unusedHolidayInfo.ContractSerial.Trim.ToLower Then

                item.UnusedHolidayDaysForCompensation = unusedHolidayInfo.TotalUnusedHolidayDays
                MsgBox("Darbuotojo nepanaudotų atostogų kiekis sėkmingai gautas.", _
                    MsgBoxStyle.Information, "Info")
                Exit For

            End If
        Next

    End Sub

    Private Sub ExportPaymentsButton_Click(sender As Object, e As EventArgs) Handles ExportPaymentsButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Try
            ExportBankPayments(_FormManager.DataSource.ExportBankPayments(), Me)
        Catch ex As Exception
            ShowError(ex)
        End Try

    End Sub



    Public Function GetMailDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetMailDropDownItems

        If _EmailDropDown Is Nothing Then
            _EmailDropDown = New ToolStripDropDown
            _EmailDropDown.Items.Add("DU apskaičiavimo žin.", Nothing, AddressOf OnMailClick)
            _EmailDropDown.Items.Add("Mokėjimo lapelių suvestinė", Nothing, AddressOf OnMailClick)
            _EmailDropDown.Items.Add("Mokėjimo lapeliai darbuotojams", Nothing, AddressOf OnMailClick)
        End If

        Return _EmailDropDown

    End Function

    Public Function GetPrintDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintDropDownItems

        If _PrintDropDown Is Nothing Then
            _PrintDropDown = New ToolStripDropDown
            _PrintDropDown.Items.Add("DU apskaičiavimo žin.", Nothing, AddressOf OnPrintClick)
            _PrintDropDown.Items.Add("Mokėjimo lapeliai", Nothing, AddressOf OnPrintClick)
        End If

        Return _PrintDropDown

    End Function

    Public Function GetPrintPreviewDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintPreviewDropDownItems

        If _PrintPreviewDropDown Is Nothing Then
            _PrintPreviewDropDown = New ToolStripDropDown
            _PrintPreviewDropDown.Items.Add("DU apskaičiavimo žin.", Nothing, AddressOf OnPrintPreviewClick)
            _PrintPreviewDropDown.Items.Add("Mokėjimo lapeliai", Nothing, AddressOf OnPrintPreviewClick)
        End If

        Return _PrintPreviewDropDown

    End Function

    Public Sub OnMailClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnMailClick

        If _FormManager.DataSource Is Nothing Then Exit Sub

        If Not GetSenderText(sender).Trim.ToLower.Contains("mokėjimo lapeliai darbuotojams") Then

            Dim version As Integer = 0
            If GetSenderText(sender).Trim.ToLower.Contains("du apskaičiavimo žin.") Then
                version = 1
            ElseIf GetSenderText(sender).Trim.ToLower.Contains("mokėjimo lapelių suvestinė") Then
                version = 2
            End If

            Using frm As New F_SendObjToEmail(_FormManager.DataSource, version)
                frm.ShowDialog()
            End Using

            Exit Sub

        End If

        Dim totalCount As Integer = 0
        Dim successCount As Integer = 0

        For Each item As Workers.WageItem In _FormManager.DataSource.Items
            If item.IsChecked Then totalCount += 1
        Next

        If totalCount < 1 Then
            MsgBox("Klaida. Žiniaraštyje nepasirinktas nė vienas darbuotojas.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        If Not YesOrNo("Ar tikrai norite išsiųsti mokėjimo lapelius visiems žiniaraštyje pasirinktiems darbuotojams?") Then Exit Sub

        Dim warnings As String = ""

        Try

            Dim persons As HelperLists.PersonInfoList = HelperLists.PersonInfoList.GetList()


            Using busy As New StatusBusy

                For Each item As Workers.WageItem In _FormManager.DataSource.Items

                    If item.IsChecked Then

                        Dim person As HelperLists.PersonInfo = persons.GetPersonInfo(item.PersonID)

                        If person Is Nothing OrElse person.IsEmpty Then
                            warnings = AddWithNewLine(warnings, String.Format( _
                                "Nerasti darbuotojo {0} (DS NR. {1}{2}) bendri duomenys.", _
                                item.PersonName, item.ContractSerial, item.ContractNumber.ToString()), False)
                        ElseIf StringIsNullOrEmpty(person.Email) Then
                            warnings = AddWithNewLine(warnings, String.Format( _
                                "Nenustatytas darbuotojo {0} (DS NR. {1}{2}) e-pašto adresas.", _
                                item.PersonName, item.ContractSerial, item.ContractNumber.ToString()), False)
                        Else

                            Dim mailSubject As String = String.Format("Darbo uzmokescio mokejimo lapelis {0} Nr. {1} uz {2} m. {3} mėn.", _
                                _FormManager.DataSource.Date.ToShortDateString, _FormManager.DataSource.Number.ToString(), _
                                _FormManager.DataSource.Year.ToString(), _FormManager.DataSource.Month.ToString())

                            Try

                                SendObjectToEmail(New WageSheetItem(_FormManager.DataSource, item), person.Email, mailSubject, _
                                    mailSubject, 0, "PayCheck_" & _FormManager.DataSource.Date.ToString("yyyyMMdd") & "_" _
                                    & _FormManager.DataSource.Number.ToString(), "", Nothing)

                                successCount += 1

                            Catch ex As Exception

                                warnings = AddWithNewLine(warnings, String.Format( _
                                    "Nepavyko išsiųsti mokėjimo lapelio darbuotojui {0} (DS NR. {1}{2}): {3}.", _
                                    item.PersonName, item.ContractSerial, item.ContractNumber.ToString(), ex.Message), False)

                            End Try

                        End If

                    End If

                Next

            End Using
        Catch ex As Exception
            ShowError(ex, Nothing)
            Exit Sub
        End Try

        If successCount = totalCount Then
            MsgBox("Mokėjimo lapeliai sėkmingai išsiųsti visiems darbuotojams.", MsgBoxStyle.Information, "Info")
        ElseIf successCount > 0 Then
            MsgBox(String.Format("Siunčiant mokėjimo lapelius įvyko klaidų. Mokėjimo lapeliai buvo sėkmingai išsiųsti {0} darbuotojams iš {1}. Mokėjimo lapeliai nebuvo išsiųsti šiems darbuotojams:{2}{3}", _
                successCount.ToString(), totalCount.ToString(), vbCrLf, warnings), MsgBoxStyle.Exclamation, "Klaida.")
        Else
            MsgBox(String.Format("Siunčiant mokėjimo lapelius įvyko klaidų. Nė vienas mokėjimo lapelis nebuvo išsiųstas: {0}{1}", _
                vbCrLf, warnings), MsgBoxStyle.Exclamation, "Klaida.")
        End If

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Dim version As Integer = 0
        If GetSenderText(sender).Trim.ToLower.Contains("du apskaičiavimo žin.") Then
            version = 1
        ElseIf GetSenderText(sender).Trim.ToLower.Contains("mokėjimo lapeliai") Then
            version = 2
        End If

        Try
            PrintObject(_FormManager.DataSource, False, version, "", Me, _
                _ListViewManager.GetCurrentFilterDescription(), _
                _ListViewManager.GetDisplayOrderIndexes())
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try

    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Dim version As Integer = 0
        If GetSenderText(sender).Trim.ToLower.Contains("du apskaičiavimo žin.") Then
            version = 1
        ElseIf GetSenderText(sender).Trim.ToLower.Contains("mokėjimo lapeliai") Then
            version = 2
        End If

        Try
            PrintObject(_FormManager.DataSource, True, version, "", Me, _
                _ListViewManager.GetCurrentFilterDescription(), _
                _ListViewManager.GetDisplayOrderIndexes())
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try

    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function


    Public Function ChronologicContent() As String _
            Implements ISupportsChronologicValidator.ChronologicContent
        If _FormManager.DataSource Is Nothing Then Return ""
        Return _FormManager.DataSource.ChronologicValidator.LimitsExplanation
    End Function

    Public Function HasChronologicContent() As Boolean _
        Implements ISupportsChronologicValidator.HasChronologicContent

        Return Not _FormManager.DataSource Is Nothing AndAlso _
            Not StringIsNullOrEmpty(_FormManager.DataSource.ChronologicValidator.LimitsExplanation)

    End Function


    Private Sub _FormManager_DataSourceStateHasChanged(ByVal sender As Object, _
         ByVal e As System.EventArgs) Handles _FormManager.DataSourceStateHasChanged
        ConfigureButtons()
    End Sub

    Private Sub ConfigureButtons()

        RateGPMAccTextBox.ReadOnly = (_FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange)
        RateGuaranteeFundAccTextBox.ReadOnly = (_FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange)
        RateHRAccTextBox1.ReadOnly = (_FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange)
        RateONAccTextBox1.ReadOnly = (_FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange)
        RatePSDEmployeeAccTextBox.ReadOnly = (_FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange)
        RatePSDEmployerAccTextBox.ReadOnly = (_FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange)
        RateSCAccTextBox1.ReadOnly = (_FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange)
        RateSickLeaveAccTextBox1.ReadOnly = (_FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange)
        RateSODRAEmployeeAccTextBox.ReadOnly = (_FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange)
        RateSODRAEmployerAccTextBox.ReadOnly = (_FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange)
        NPDFormulaTextBox.ReadOnly = (_FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange)
        RefreshTaxesButton.Enabled = (Not _FormManager.DataSource Is Nothing AndAlso _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange)
        RefreshWageTarifButton.Enabled = (Not _FormManager.DataSource Is Nothing AndAlso _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange)

        _ListViewManager.IsReadOnly = (_FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange)

        CostAccountAccListComboBox.Enabled = (Not _FormManager.DataSource Is Nothing AndAlso _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange)
        GetVDUButton.Enabled = (Not _FormManager.DataSource Is Nothing AndAlso _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange)
        CalculateNPDButton.Enabled = (Not _FormManager.DataSource Is Nothing AndAlso _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange)

        DateAccDatePicker.ReadOnly = (_FormManager.DataSource Is Nothing)
        NumberAccTextBox.Enabled = (Not _FormManager.DataSource Is Nothing)
        IsNonClosingCheckBox.Enabled = (Not _FormManager.DataSource Is Nothing)
        RemarksTextBox.ReadOnly = (_FormManager.DataSource Is Nothing)

        nOkButton.Enabled = (Not _FormManager.DataSource Is Nothing)
        ApplyButton.Enabled = (Not _FormManager.DataSource Is Nothing)
        nCancelButton.Enabled = (Not _FormManager.DataSource Is Nothing AndAlso Not _FormManager.DataSource.IsNew)

        NewWageSheetButton.Enabled = WageSheet.CanAddObject AndAlso (_FormManager.DataSource Is Nothing OrElse _FormManager.DataSource.IsNew)

    End Sub

End Class