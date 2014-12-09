Imports ApskaitaObjects.Documents
Imports ApskaitaObjects.HelperLists
Public Class F_BankOperationItemList

    Private Obj As BankOperationItemList
    Private Loading As Boolean = True

    Private Sub F_BankOperationItemList_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.PersonInfoList), _
            GetType(HelperLists.CashAccountInfoList), _
            GetType(HelperLists.AccountInfoList)) Then Exit Sub

    End Sub

    Private Sub F_BankOperationItemList_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not Obj Is Nothing AndAlso TypeOf Obj Is IIsDirtyEnough AndAlso _
            DirectCast(Obj, IIsDirtyEnough).IsDirtyEnough Then
            Dim answ As String = Ask("Išsaugoti duomenis?", New ButtonStructure("Taip"), _
                New ButtonStructure("Ne"), New ButtonStructure("Atšaukti"))
            If answ <> "Taip" AndAlso answ <> "Ne" Then
                e.Cancel = True
                Exit Sub
            End If
            If answ = "Taip" Then
                If Not SaveObj() Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If

        GetFormLayout(Me)
        GetDataGridViewLayOut(BankOperationItemListDataGridView)

        Try
            MyCustomSettings.BankDocumentPrefix = DocumentNumberPrefixTextBox.Text.Trim
            MyCustomSettings.IgnoreWrongIBAN = IgnoreIBANCheckBox.Checked
            MyCustomSettings.Save()
        Catch ex As Exception
            ShowError(New Exception("Nepavyko išsaugoti programos nustatymų: " & ex.Message, ex))
        End Try

    End Sub

    Private Sub F_BankOperationItemList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        DocumentNumberPrefixTextBox.Text = MyCustomSettings.BankDocumentPrefix.Trim
        IgnoreIBANCheckBox.Checked = MyCustomSettings.IgnoreWrongIBAN

        If Not Documents.BankOperationItemList.CanAddObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka banko duomenų importui.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        AddDGVColumnSelector(BankOperationItemListDataGridView)
        SetFormLayout(Me)
        SetDataGridViewLayOut(BankOperationItemListDataGridView)

    End Sub


    Private Sub OkButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IOkButton.Click

        If Not SaveObj() Then Exit Sub
        Me.Hide()
        Me.Close()

    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IApplyButton.Click
        SaveObj()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ICancelButton.Click
        CancelObj()
    End Sub

    Private Sub BankOperationItemListDataGridView_CellBeginEdit(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) _
        Handles BankOperationItemListDataGridView.CellBeginEdit

        If Obj Is Nothing Then Exit Sub

        Dim SelectedItem As BankOperationItem
        Try
            SelectedItem = DirectCast(BankOperationItemListDataGridView.Rows(e.RowIndex).DataBoundItem, BankOperationItem)
        Catch ex As Exception
        End Try

        If SelectedItem Is Nothing OrElse Not SelectedItem.ExistsInDatabase Then Exit Sub

        ' jau egzistuojanciu operaciju duomenu keisti negalima
        e.Cancel = True

    End Sub

    Private Sub BankOperationItemListDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles BankOperationItemListDataGridView.CellDoubleClick

        If Obj Is Nothing OrElse e.RowIndex < 0 Then Exit Sub

        ' get the selected book entry
        Dim tmp As BankOperationItem = Nothing
        Try
            tmp = CType(BankOperationItemListDataGridView.Rows(e.RowIndex).DataBoundItem, BankOperationItem)
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try
        If tmp Is Nothing Then
            MsgBox("Klaida. Nepavyko nustatyti pasirinktos operacijos.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        ' don't show dialog in editable cells
        If Not tmp.ExistsInDatabase AndAlso Not BankOperationItemListDataGridView. _
            Columns(e.ColumnIndex).ReadOnly Then Exit Sub

        ' ask what to do
        Dim ats As String
        If tmp.ExistsInDatabase Then

            ats = Ask("", New ButtonStructure("Taisyti", "Keisti mokėjimo dokumento duomenis."), _
                    New ButtonStructure("Ištrinti", "Pašalinti mokėjimo dokumento duomenis iš duomenų bazės."), _
                    New ButtonStructure("Atšaukti", "Nieko nedaryti."))

        Else

            If (tmp.Person Is Nothing OrElse Not tmp.Person.ID > 0) AndAlso _
                (Not String.IsNullOrEmpty(tmp.PersonName.Trim) OrElse _
                Not String.IsNullOrEmpty(tmp.PersonCode.Trim)) Then

                ats = Ask("", New ButtonStructure("Taisyti", "Keisti mokėjimo dokumento duomenis."), _
                    New ButtonStructure("Kontrahentas", "Įtraukti naujo kontrahento duomenis į duomenų bazę."), _
                    New ButtonStructure("Atšaukti", "Nieko nedaryti."))

            Else

                ats = Ask("", New ButtonStructure("Taisyti", "Keisti mokėjimo dokumento duomenis."), _
                    New ButtonStructure("Atšaukti", "Nieko nedaryti."))

            End If

        End If

        If ats <> "Taisyti" AndAlso ats <> "Ištrinti" AndAlso ats <> "Kontrahentas" Then Exit Sub

        If ats = "Ištrinti" Then

            If tmp.ExistsInDatabase Then
                For Each frm As Form In MDIParent1.MdiChildren
                    If TypeOf frm Is F_BankOperation AndAlso _
                        DirectCast(frm, IObjectEditForm).ObjectID = tmp.OperationDatabaseID Then
                        MsgBox("Klaida. Šios operacijos duomenys yra redaguojami.", _
                            MsgBoxStyle.Exclamation, "Klaida.")
                        frm.Activate()
                        Exit Sub
                    End If
                Next
            End If

            If Not YesOrNo("Ar tikrai norite pašalinti dokumento duomenis iš duomenų bazės?") Then Exit Sub

            Using busy As New StatusBusy
                Try
                    Documents.BankOperation.DeleteBankOperation(tmp.OperationDatabaseID)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try
            End Using

            Obj.Remove(tmp)

            BankOperationItemListDataGridView.Select()

        ElseIf ats = "Kontrahentas" Then

            MDIParent1.LaunchForm(GetType(F_Person), False, False, 0, _
                tmp.PersonCode, tmp.PersonName, tmp.PersonBankAccount, tmp.PersonBankName)

        Else ' edit object

            If tmp.ExistsInDatabase Then

                For Each frm As Form In MDIParent1.MdiChildren
                    If TypeOf frm Is F_BankOperation AndAlso _
                        DirectCast(frm, IObjectEditForm).ObjectID = tmp.OperationDatabaseID Then
                        frm.Activate()
                        Exit Sub
                    End If
                Next

            Else

                For Each frm As Form In MDIParent1.MdiChildren
                    If TypeOf frm Is F_BankOperation AndAlso _
                        DirectCast(frm, F_BankOperation).ImportedObject.Equals(tmp) Then
                        frm.Activate()
                        Exit Sub
                    End If
                Next

            End If

            MDIParent1.LaunchForm(GetType(F_BankOperation), False, False, tmp.OperationDatabaseID, _
                tmp, Obj.Account)

        End If

    End Sub

    Private Sub LoadDataButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles PasteButton.Click, OpenFileButton.Click

        If sender Is Nothing Then Exit Sub

        Dim CurrentAccount As CashAccountInfo = LoadObjectFromCombo(Of CashAccountInfo) _
            (AccountAccGridComboBox, "ID")
        If CurrentAccount Is Nothing OrElse Not CurrentAccount.ID > 0 Then
            MsgBox("Klaida. Nepasirinkta sąskaita, į kurią importuojami duomenys.", _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Dim FileName As String = ""
        If sender Is OpenFileButton Then

            Using OFD As New OpenFileDialog
                OFD.Multiselect = False
                OFD.Filter = "LITAS-ESIS (*.acc)|*.acc|All Files (*.*)|*.*"
                If OFD.ShowDialog(Me) <> System.Windows.Forms.DialogResult.OK Then Exit Sub
                FileName = OFD.FileName
            End Using
            If FileName Is Nothing OrElse String.IsNullOrEmpty(FileName.Trim) _
                OrElse Not IO.File.Exists(FileName) Then Exit Sub

        End If

        If Not Obj Is Nothing AndAlso TypeOf Obj Is IIsDirtyEnough AndAlso _
            DirectCast(Obj, IIsDirtyEnough).IsDirtyEnough Then

            Dim answ As String = Ask("Išsaugoti duomenis?", New ButtonStructure("Taip"), _
                New ButtonStructure("Ne"), New ButtonStructure("Atšaukti"))

            If answ <> "Taip" AndAlso answ <> "Ne" Then Exit Sub

            If answ = "Taip" Then
                If Not SaveObj() Then Exit Sub
            End If

        End If

        Using bm As New BindingsManager(BankOperationItemListBindingSource, _
            Nothing, Nothing, False, False)

            Try

                If sender Is OpenFileButton Then
                    Obj = LoadObject(Of BankOperationItemList)(Nothing, "GetListFromLitasEsisFile", _
                        True, FileName, CurrentAccount, DocumentNumberPrefixTextBox.Text.Trim, _
                        IgnoreIBANCheckBox.Checked)
                Else
                    Obj = LoadObject(Of BankOperationItemList)(Nothing, "GetListFromPasteString", _
                        True, Clipboard.GetText(), CurrentAccount, DocumentNumberPrefixTextBox.Text.Trim)
                End If

            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            bm.SetNewDataSource(Obj.GetSortedList)

        End Using

        AccountTextBox.Text = Obj.Account.Account.ToString & " (" & Obj.Account.CurrencyCode _
            & ") - " & Obj.Account.Name
        ReportDescriptionTextBox.Text = Obj.GetDescription

        BankOperationItemListDataGridView.Select()

    End Sub

    Private Sub GetCurrencyRatesButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles GetCurrencyRatesButton.Click

        If Obj Is Nothing Then Exit Sub

        Dim paramList As New AccWebCrawler.CurrencyRateList

        For Each b As BankOperationItem In Obj
            paramList.Add(b.Date, b.Currency)
            paramList.Add(b.Date, Obj.Account.CurrencyCode)
        Next

        If paramList.Count < 1 Then Exit Sub

        If Not YesOrNo("Gauti valiutų kursus?") Then Exit Sub

        Using frm As New AccWebCrawler.F_LaunchWebCrawler(paramList, GetCurrentCompany.BaseCurrency)

            If frm.ShowDialog <> Windows.Forms.DialogResult.OK OrElse frm.result Is Nothing _
                OrElse Not TypeOf frm.result Is AccWebCrawler.CurrencyRateList _
                OrElse DirectCast(frm.result, AccWebCrawler.CurrencyRateList).Count < 1 Then Exit Sub

            For Each b As BankOperationItem In Obj
                b.CurrencyRate = DirectCast(frm.result, AccWebCrawler.CurrencyRateList). _
                    GetCurrencyRate(b.Date, b.Currency)
                b.CurrencyRateInAccount = DirectCast(frm.result, AccWebCrawler.CurrencyRateList). _
                    GetCurrencyRate(b.Date, Obj.Account.CurrencyCode)
            Next

        End Using

    End Sub


    Private Function SaveObj() As Boolean

        If Obj Is Nothing OrElse Obj.Count < 1 Then
            MsgBox("Klaida. Nėra duomenų, kuriuos būtų galima importuoti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        Dim ContainsAnyNewRecords As Boolean = False
        For Each i As BankOperationItem In Obj
            If Not i.ExistsInDatabase Then
                ContainsAnyNewRecords = True
                Exit For
            End If
        Next
        If Not ContainsAnyNewRecords Then
            MsgBox("Klaida. Nėra duomenų, kuriuos būtų galima importuoti. " _
                & "Visi įkrauti duomenys jau yra įtraukti į duomenų bazę.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.GetAllBrokenRules(), _
                MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        Dim Question, Answer As String
        If Not String.IsNullOrEmpty(Obj.GetAllWarnings.Trim) Then
            Question = "DĖMESIO. Duomenyse gali būti klaidų: " & vbCrLf _
                & Obj.GetAllWarnings & vbCrLf
        Else
            Question = ""
        End If
        Question = Question & "Ar tikrai norite importuoti duomenis?"
        Answer = "Duomenys sėkmingai pakeisti."

        If Not YesOrNo(Question) Then Return False

        Using bm As New BindingsManager(BankOperationItemListBindingSource, _
            Nothing, Nothing, True, False)

            Try
                Obj = LoadObject(Of BankOperationItemList)(Obj, "Save", False)
            Catch ex As Exception
                ShowError(ex)
                Return False
            End Try

            bm.SetNewDataSource(Obj.GetSortedList)

        End Using

        MsgBox(Answer, MsgBoxStyle.Information, "Info")

        Return True

    End Function

    Private Sub CancelObj()
        If Obj Is Nothing OrElse Not Obj.IsDirty Then Exit Sub
        Using bm As New BindingsManager(BankOperationItemListBindingSource, _
            Nothing, Nothing, True, True)
        End Using
    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.PersonInfoList), _
            GetType(HelperLists.AccountInfoList), _
            GetType(HelperLists.CashAccountInfoList)) Then Exit Function

        Try

            LoadPersonInfoListToGridCombo(DataGridViewTextBoxColumn1, True, True, True, True)
            LoadAccountInfoListToGridCombo(DataGridViewTextBoxColumn4, True, 1, 2, 3, 4, 5, 6)
            LoadAccountInfoListToGridCombo(AccountBankCurrencyConversionCosts, True, 6)
            LoadCashAccountInfoListToGridCombo(AccountAccGridComboBox, True)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

    Public Sub MarkAsExistingInDatabase(ByVal nBankOperationItem As BankOperationItem, _
        ByVal NewDatabaseID As Integer)
        If Obj Is Nothing Then Exit Sub
        Obj.MarkAsExistingInDatabase(nBankOperationItem, NewDatabaseID)
    End Sub

End Class