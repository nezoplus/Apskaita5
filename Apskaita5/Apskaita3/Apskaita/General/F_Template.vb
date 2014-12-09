
Public Class F_Template

    Private Obj As General.TemplateJournalEntry = Nothing
    Private ObjID As Integer = 0
    Private Loading As Boolean = True

    Public Sub New(ByVal ObjToEdit As HelperLists.TemplateJournalEntryInfo)
        InitializeComponent()
        ObjID = ObjToEdit.ID
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub F_Template_Activated(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList)) Then Exit Sub

    End Sub

    Private Sub F_Template_FormClosing(ByVal sender As Object, _
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
                If Not SaveObj(False) Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If

        GetDataGridViewLayOut(DebetListDataGridView)
        GetDataGridViewLayOut(CreditListDataGridView)
        GetFormLayout(Me)

    End Sub

    Private Sub F_Template_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

        If ObjID > 0 Then
            Try
                Obj = LoadObject(Of General.TemplateJournalEntry) _
                    (Nothing, "GetTemplateJournalEntry", False, ObjID)
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try
        Else
            Obj = General.TemplateJournalEntry.NewTemplateJournalEntry
        End If

        TemplateJournalEntryBindingSource.DataSource = Obj

        ReadWriteAuthorization1.ResetControlAuthorization()
        ConfigureButtons()

        SetDataGridViewLayOut(DebetListDataGridView)
        SetDataGridViewLayOut(CreditListDataGridView)
        SetFormLayout(Me)

        If Not Obj.IsNew AndAlso Not General.TemplateJournalEntry.CanEditObject Then _
            DisableAllControls(Me)

    End Sub

    Private Sub OkButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles OkButton.Click

        If Obj.IsNew Then
            If Not SaveObj(True) Then Exit Sub
            ConfigureButtons()
        Else
            If Not SaveObj(False) Then Exit Sub
            Me.Hide()
            Me.Close()
        End If

    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ApplyButton.Click
        If SaveObj(False) Then ConfigureButtons()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles CancelButton.Click
        If Obj.IsNew OrElse Not Obj.IsDirty Then Exit Sub
        CancelObj()
    End Sub

    Private Sub NewItemButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewItemButton.Click
        Using bm As New BindingsManager(TemplateJournalEntryBindingSource, _
            DebetListBindingSource, CreditListBindingSource, True, True)
            bm.SetNewDataSource(General.TemplateJournalEntry.NewTemplateJournalEntry)
        End Using
        ConfigureButtons()
    End Sub



    Private Function SaveObj(ByVal ReplaceWithNewPerson As Boolean) As Boolean

        If Not Obj.IsDirty Then Return True

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.BrokenRulesCollection.ToString( _
                Csla.Validation.RuleSeverity.Error), MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        Dim Question, Answer As String
        If Obj.BrokenRulesCollection.WarningCount > 0 Then
            Question = "DĖMESIO. Duomenyse gali būti klaidų: " & vbCrLf _
                & Obj.BrokenRulesCollection.ToString(Csla.Validation.RuleSeverity.Warning) & vbCrLf
        Else
            Question = ""
        End If
        If Obj.IsNew Then
            Question = Question & "Ar tikrai norite įtraukti naujus duomenis?"
            Answer = "Nauji duomenys sėkmingai įtraukti."
        Else
            Question = Question & "Ar tikrai norite pakeisti duomenis?"
            Answer = "Duomenys sėkmingai pakeisti."
        End If

        If Not YesOrNo(Question) Then Return False

        Using bm As New BindingsManager(TemplateJournalEntryBindingSource, _
            DebetListBindingSource, CreditListBindingSource, True, False)

            Try
                Obj = LoadObject(Of General.TemplateJournalEntry)(Obj, "Save", False)
                If ReplaceWithNewPerson Then Obj = General.TemplateJournalEntry.NewTemplateJournalEntry
            Catch ex As Exception
                ShowError(ex)
                Return False
            End Try

            bm.SetNewDataSource(Obj)

        End Using

        MsgBox(Answer, MsgBoxStyle.Information, "Info")

        Return True

    End Function

    Private Sub CancelObj()

        If Obj Is Nothing OrElse Obj.IsNew Then Exit Sub

        Using bm As New BindingsManager(TemplateJournalEntryBindingSource, _
            DebetListBindingSource, CreditListBindingSource, True, True)
        End Using

    End Sub

    Private Sub ConfigureButtons()
        If Obj Is Nothing Then Exit Sub
        EditedBaner.Visible = Not (Obj.IsNew)
        OkButton.Enabled = ((Obj.IsNew AndAlso General.TemplateJournalEntry.CanAddObject) OrElse _
            (Not Obj.IsNew AndAlso General.JournalEntry.CanEditObject))
        ApplyButton.Enabled = ((Obj.IsNew AndAlso General.TemplateJournalEntry.CanAddObject) OrElse _
            (Not Obj.IsNew AndAlso General.JournalEntry.CanEditObject))
        CancelButton.Enabled = Not Obj.IsNew
    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList)) Then Return False

        Try

            LoadAccountInfoListToGridCombo(DebetListDataGridView.Columns(0), True)
            LoadAccountInfoListToGridCombo(CreditListDataGridView.Columns(0), True)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

End Class