Imports ApskaitaObjects.Documents
Public Class F_CashAccountList
    Implements ISupportsPrinting

    Private Obj As CashAccountList
    Private Loading As Boolean = True

    Private Sub F_CashAccountList_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.PersonInfoList), _
            GetType(HelperLists.AccountInfoList)) Then Exit Sub

    End Sub

    Private Sub F_CashAccountList_FormClosing(ByVal sender As Object, _
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
        GetDataGridViewLayOut(CashAccountListDataGridView)

    End Sub

    Private Sub F_CashAccountList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Documents.CashAccountList.CanGetObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        Try
            Obj = LoadObject(Of CashAccountList)(Nothing, "GetCashAccountList", _
                True)
        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Exit Sub
        End Try

        CashAccountListBindingSource.DataSource = Obj.GetSortedList

        AddDGVColumnSelector(CashAccountListDataGridView)
        SetFormLayout(Me)
        SetDataGridViewLayOut(CashAccountListDataGridView)

        If Not Documents.CashAccountList.CanEditObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka duomenims redaguoti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

    End Sub


    Private Sub OkButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IOkButton.Click

        If Not SaveObj() Then Exit Sub
        Me.Hide()
        Me.Close()

    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IApplyButton.Click
        If Not SaveObj() Then Exit Sub
        If Not CashAccountList.CanEditObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka duomenims redaguoti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ICancelButton.Click
        CancelObj()
    End Sub

    Private Sub CashAccountListDataGridView_CellBeginEdit(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) _
        Handles CashAccountListDataGridView.CellBeginEdit

        Dim SelectedItem As CashAccount
        Try
            SelectedItem = DirectCast(CashAccountListDataGridView.Rows(e.RowIndex).DataBoundItem, CashAccount)
        Catch ex As Exception
        End Try

        If SelectedItem Is Nothing OrElse SelectedItem.IsNew OrElse Not SelectedItem.IsInUse Then Exit Sub

        ' naudojamos saskaitos tipo, valiutos ir apskaitos saskaitos keisti negalima
        If CashAccountListDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn3 _
            OrElse CashAccountListDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn4 _
            OrElse CashAccountListDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn11 Then
            e.Cancel = True
        End If

    End Sub

    Private Sub CashAccountListDataGridView_UserDeletingRow(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) _
        Handles CashAccountListDataGridView.UserDeletingRow

        Dim SelectedItem As CashAccount
        Try
            SelectedItem = DirectCast(e.Row.DataBoundItem, CashAccount)
        Catch ex As Exception
        End Try

        If SelectedItem Is Nothing OrElse SelectedItem.IsNew OrElse Not SelectedItem.IsInUse Then Exit Sub

        MsgBox("Klaida. Ši lėšų sąskaita buvo naudojama registruojant operacijas. " _
            & "Jos pašalinti neleidžiama.", MsgBoxStyle.Exclamation, "Klaida")

        e.Cancel = True

    End Sub


    Public Function GetMailDropDownItems() As System.Windows.Forms.ToolStripDropDown _
       Implements ISupportsPrinting.GetMailDropDownItems
        Return Nothing
    End Function

    Public Function GetPrintDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintDropDownItems
        Return Nothing
    End Function

    Public Function GetPrintPreviewDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintPreviewDropDownItems
        Return Nothing
    End Function

    Public Sub OnMailClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnMailClick
        If Obj Is Nothing Then Exit Sub

        Using frm As New F_SendObjToEmail(Obj, 0)
            frm.ShowDialog()
        End Using

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick
        If Obj Is Nothing Then Exit Sub
        Try
            PrintObject(Obj, False, 0)
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If Obj Is Nothing Then Exit Sub
        Try
            PrintObject(Obj, True, 0)
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function


    Private Function SaveObj() As Boolean

        If Not Obj.IsDirty Then Return True

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
        Question = Question & "Ar tikrai norite pakeisti duomenis?"
        Answer = "Duomenys sėkmingai pakeisti."

        If Not YesOrNo(Question) Then Return False

        Using bm As New BindingsManager(CashAccountListBindingSource, _
            Nothing, Nothing, True, False)

            Try
                Obj = LoadObject(Of CashAccountList)(Obj, "Save", False)
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
        Using bm As New BindingsManager(CashAccountListBindingSource, _
            Nothing, Nothing, True, True)
        End Using
    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.PersonInfoList), _
            GetType(HelperLists.AccountInfoList)) Then Exit Function

        Try

            LoadEnumHumanReadableListToComboBox(DataGridViewTextBoxColumn3, GetType(CashAccountType), True)
            LoadCurrencyCodeListToComboBox(DataGridViewTextBoxColumn11, True)

            LoadAccountInfoListToGridCombo(DataGridViewTextBoxColumn4, True, 2)
            LoadPersonInfoListToGridCombo(DataGridViewTextBoxColumn6, True, False, True, False)
            LoadAccountInfoListToGridCombo(DataGridViewTextBoxColumn5, True, 3, 6)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function
    
End Class