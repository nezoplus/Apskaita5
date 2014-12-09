Imports ApskaitaObjects.Settings
Public Class F_GeneralSettings

    Private Obj As CommonSettings
    Private OkButtonPressed As Boolean = False

    Private Sub F_GeneralSettings_Closing(ByVal sender As System.Object, _
        ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        If Not Obj Is Nothing AndAlso TypeOf Obj Is IIsDirtyEnough AndAlso _
            DirectCast(Obj, IIsDirtyEnough).IsDirtyEnough Then
            Dim answ As String = Ask("Išsaugoti duomenis?", New ButtonStructure("Taip"), _
                New ButtonStructure("Ne"), New ButtonStructure("Atšaukti"))
            If answ <> "Taip" AndAlso answ <> "Ne" Then
                e.Cancel = True
                Exit Sub
            End If
            If answ = "Taip" Then
                If Not SaveObj(False) Then
                    e.Cancel = True
                    Exit Sub
                End If
            Else
                CancelObj(False)
            End If
        End If

    End Sub

    Private Sub F_GeneralSettings_Activated(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Activated
        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub F_GeneralSettings_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        TaxTokenDataGridViewComboBoxColumn.DataSource = TaxRateList.GetAllTaxTokens

        Using busy As New StatusBusy
            Try
                Obj = ApskaitaObjects.Settings.CommonSettings.GetList
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try
        End Using

        CommonSettingsBindingSource.DataSource = Obj

        OkButton.Enabled = ApskaitaObjects.Settings.CommonSettings.CanEditObject
        ApplyButton.Enabled = ApskaitaObjects.Settings.CommonSettings.CanEditObject
        ReadWriteAuthorization1.ResetControlAuthorization()

    End Sub

    Private Sub OkButton_Click(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles OkButton.Click
        If Not SaveObj(False) Then Exit Sub
        OkButtonPressed = True
        Me.Hide()
        Me.Close()
    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ApplyButton.Click
        SaveObj(True)
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles CancelButton.Click
        CancelObj(True)
    End Sub

    Private Sub TaxRatesDataGridView_RowLeave(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TaxRatesDataGridView.RowLeave
        If TaxRatesDataGridView.Rows(e.RowIndex).IsNewRow AndAlso _
            e.RowIndex = TaxRatesDataGridView.Rows.Count - 1 Then TaxRatesDataGridView.CancelEdit()
    End Sub


    Private Function SaveObj(ByVal RebindObject As Boolean) As Boolean

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.BrokenRulesCollection.ToString & _
                Obj.GetAllBrokenRules, MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        If Not Obj.IsDirty Then Return True

        If Not YesOrNo("Ar tikrai norite pakeisti serverio pusės nustatymus?") Then Return False

        Using busy As New StatusBusy

            CommonSettingsBindingSource.RaiseListChangedEvents = False
            TaxRatesBindingSource.RaiseListChangedEvents = False

            TaxRatesBindingSource.EndEdit()
            CommonSettingsBindingSource.EndEdit()

            Try
                Obj = Obj.Clone.Save
            Catch ex As Exception
                ShowError(ex)
                CommonSettingsBindingSource.RaiseListChangedEvents = True
                TaxRatesBindingSource.RaiseListChangedEvents = True
                Return False
            End Try

            If RebindObject Then
                RebindObj()
            Else
                CommonSettingsBindingSource.RaiseListChangedEvents = True
                TaxRatesBindingSource.RaiseListChangedEvents = True
            End If

        End Using

        MsgBox("Serverio pusės nustatymai sėkmingai pakeisti.", MsgBoxStyle.Information, "Info")

        Return True

    End Function

    Private Sub CancelObj(ByVal RebindObject As Boolean)
        CommonSettingsBindingSource.RaiseListChangedEvents = False
        TaxRatesBindingSource.RaiseListChangedEvents = False

        TaxRatesBindingSource.CancelEdit()
        CommonSettingsBindingSource.CancelEdit()

        If RebindObject Then
            RebindObj()
        Else
            CommonSettingsBindingSource.RaiseListChangedEvents = True
            TaxRatesBindingSource.RaiseListChangedEvents = True
        End If

    End Sub

    Private Sub RebindObj()
        CommonSettingsBindingSource.RaiseListChangedEvents = False
        TaxRatesBindingSource.RaiseListChangedEvents = False

        CommonSettingsBindingSource.DataSource = Nothing
        TaxRatesBindingSource.DataSource = CommonSettingsBindingSource

        CommonSettingsBindingSource.DataSource = Obj

        CommonSettingsBindingSource.RaiseListChangedEvents = True
        TaxRatesBindingSource.RaiseListChangedEvents = True

        CommonSettingsBindingSource.ResetBindings(False)
        TaxRatesBindingSource.ResetBindings(False)
    End Sub

End Class