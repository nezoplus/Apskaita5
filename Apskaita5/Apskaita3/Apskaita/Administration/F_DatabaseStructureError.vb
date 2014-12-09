Imports AccDataAccessLayer.DatabaseAccess.DatabaseStructure
Imports System.ComponentModel
Imports System.Windows.Forms
Public Class F_DatabaseStructureError
    Private Obj As DatabaseStructureErrorList


    Private Sub F_DatabaseStructureError_Activated(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Activated
        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub F_DatabaseStructureError_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        Using busy As New StatusBusy
            Try
                Dim DbList As AccDataAccessLayer.Security.DatabaseInfoList = _
                    AccDataAccessLayer.Security.DatabaseInfoList.GetDatabaseList()
                DatabaseListComboBox.DataSource = DbList
                LocalFilePasswordTextBox.ReadOnly = Not GetCurrentIdentity.IsLocalUser
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Using

    End Sub

    Private Sub DatabaseListComboBox_SelectedIndexChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles DatabaseListComboBox.SelectedIndexChanged

        FetchErrorsButton.Enabled = Not (DatabaseListComboBox.SelectedItem Is Nothing _
            OrElse Not TypeOf DatabaseListComboBox.SelectedItem Is AccDataAccessLayer.Security.DatabaseInfo)

    End Sub

    Private Sub FetchErrorsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles FetchErrorsButton.Click

        If Not DatabaseStructureErrorList.CanEditObject Then
            MsgBox("Jūs neturite teisės atlikti šį veiksmą.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        If DatabaseListComboBox.SelectedItem Is Nothing OrElse _
            Not TypeOf DatabaseListComboBox.SelectedItem Is _
            AccDataAccessLayer.Security.DatabaseInfo Then Exit Sub

        Using bm As New BindingsManager(DatabaseStructureErrorListBindingSource, _
            Nothing, Nothing, True, False)

            Try
                Using busy As New StatusBusy

                    Obj = LoadObject(Of DatabaseStructureErrorList)(Nothing, _
                        "GetDatabaseStructureErrorList", True, _
                        DirectCast(DatabaseListComboBox.SelectedItem, _
                        AccDataAccessLayer.Security.DatabaseInfo).DatabaseName, _
                        DirectCast(New CustomDatabaseStructureErrorManager, IDatabaseStructureErrorManager), _
                        LocalFilePasswordTextBox.Text)

                End Using
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            bm.SetNewDataSource(Obj)

        End Using

        RepairErrorsButton.Enabled = (Obj.Count > 0)

    End Sub

    Private Sub RepairErrorsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RepairErrorsButton.Click

        If Obj Is Nothing OrElse Obj.Count < 1 Then Exit Sub

        If Not Obj.FixableErrorsExist Then
            MsgBox("Klaida. Nėra pasirinktų duomenų bazės struktūros klaidų, " _
                & "kurias būtų galima automatiškai ištaisyti.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Dim IsUpgrade As Boolean = False
        For Each i As DatabaseStructureError In Obj
            If i.IsComplexError AndAlso i.ComplexErrorCode.Trim.ToUpper.StartsWith("SV_") Then
                IsUpgrade = True
                Exit For
            End If
        Next

        If IsUpgrade Then

            Dim Answ As String = Ask("DĖMESIO. Prieš atnaujinant duomenų bazės versiją " _
                & "PRIMYGTINAI rekomenduotina pasidaryti atsarginę duomenų bazės kopiją." _
                & vbCrLf & "Daryti kopiją?", New ButtonStructure("Taip", "Daryti duomenų bazės kopiją."), _
                New ButtonStructure("Ne", "Tęsti duomenų bazės versijos atnaujinimą."), _
                New ButtonStructure("Atšaukti", "Atšaukti duomenų bazės atnaujinimą."))

            If Answ.Trim.ToLower <> "taip" AndAlso Answ.Trim.ToLower <> "ne" Then Exit Sub

            If Answ.Trim.ToLower = "taip" Then
                MDIParent1.LaunchForm(GetType(F_BackUp), True, False, 0)
                Exit Sub
            End If

        End If

        If Not YesOrNo("Ištaisyti pasirinktas klaidas?") Then Exit Sub

        Using bm As New BindingsManager(DatabaseStructureErrorListBindingSource, _
            Nothing, Nothing, True, False)
            Try
                Using busy As New StatusBusy
                    Obj = Obj.Clone.Save
                End Using
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try
            bm.SetNewDataSource(Obj)
        End Using

        MsgBox("Duomenų bazės struktūra sėkmingai atnaujinta.", MsgBoxStyle.Information, "Info")

    End Sub

End Class