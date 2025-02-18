﻿Imports AccDataAccessLayer.Security
Imports AccDataBindingsWinForms.CachedInfoLists
Imports ApskaitaObjects.Attributes

Public Class F_NewCompany

    Private WithEvents Obj As General.Company

    Private Sub F_NewCompany_Activated(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Activated
        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub F_NewCompany_HelpButtonClicked(ByVal sender As Object, _
        ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        Dim topicID As String = Me.GetType.Name
        If topicID.Length > 32 Then topicID = topicID.Substring(0, 32)
        topicID = topicID & ".htm"
        Help.ShowHelp(Me, "Apskaita5Help.chm", HelpNavigator.Topic, topicID)
    End Sub

    Private Sub F_NewCompany_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        PrepareControl(BaseCurrencyComboBox, New CurrencyFieldAttribute( _
            ValueRequiredLevel.Optional))
        Try
            Obj = General.Company.NewCompany
        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        CompanyBindingSource.DataSource = Obj
        SaveCompanyButton.Enabled = General.Company.CanAddObject

    End Sub

    Private Sub SaveCompanyButton_Click(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles SaveCompanyButton.Click

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų: " & Environment.NewLine & _
                Obj.BrokenRulesCollection.ToString, MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        If Not YesOrNo("Ar tikrai norite sukurti naujos įmonės duomenų bazę?") Then Exit Sub



        Me.CompanyBindingSource.RaiseListChangedEvents = False
        Me.CompanyBindingSource.EndEdit()

        Try
            Using busy As New StatusBusy
                Obj = Obj.Clone.Save()
                DatabaseInfoList.InvalidateCache()
                DirectCast(CurrentMdiParent, MDIParent1).DatabasesToMenu()
            End Using
        Catch ex As Exception
            ShowError(ex, Obj)
            Me.CompanyBindingSource.RaiseListChangedEvents = True
            Me.CompanyBindingSource.ResetBindings(False)
            Exit Sub
        End Try

        Me.CompanyBindingSource.RaiseListChangedEvents = True
        Me.CompanyBindingSource.ResetBindings(False)

        If YesOrNo("Įmonė sėkmingai įregistruota. Ar norite prisijungti prie sukurtos įmonės?") Then

            Dim dBlist As DatabaseInfoList = Nothing

            Try
                Using busy As New StatusBusy
                    dBlist = DatabaseInfoList.GetDatabaseList
                End Using
            Catch ex As Exception
                ShowError(ex, Nothing)
                Exit Sub
            End Try

            For Each db As DatabaseInfo In dBlist
                If db.DatabaseName.Trim.ToLower = Obj.CompanyDatabaseName.Trim.ToLower Then

                    Try
                        Using busy As New StatusBusy
                            AccPrincipal.Login(db.DatabaseName, New CustomCacheManager)
                            Dim tmpcomp As General.Company = General.Company.GetCompany
                            DirectCast(CurrentMdiParent, MDIParent1).LogInToGUI()
                        End Using
                    Catch ex As Exception
                        ShowError(ex, Nothing)
                    End Try

                    Exit For

                End If
            Next

        End If

        Me.Close()

    End Sub

End Class