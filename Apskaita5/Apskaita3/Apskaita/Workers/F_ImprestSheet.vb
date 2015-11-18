Imports ApskaitaObjects.Workers
Public Class F_ImprestSheet
    Implements ISupportsPrinting, IObjectEditForm

    Private Obj As ImprestSheet
    Private ImprestSheetID As Integer = -1
    Private Loading As Boolean = True

    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If Not Obj Is Nothing Then Return Obj.ID
            Return 0
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(ImprestSheet)
        End Get
    End Property


    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal nImprestSheetID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ImprestSheetID = nImprestSheetID

    End Sub


    Private Sub F_ImprestSheet_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

    End Sub

    Private Sub F_ImprestSheet_FormClosing(ByVal sender As Object, _
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

        GetDataGridViewLayOut(ItemsDataGridView)
        GetFormLayout(Me)

    End Sub

    Private Sub F_ImprestSheet_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If ImprestSheetID > 0 AndAlso Not Workers.ImprestSheet.CanGetObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        ElseIf Not ImprestSheetID > 0 AndAlso Not Workers.ImprestSheet.CanAddObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka naujai informacijai įvesti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        YearComboBox.SelectedIndex = 0
        MonthComboBox.SelectedIndex = Today.Month - 1

        If ImprestSheetID > 0 Then

            Try
                Obj = LoadObject(Of ImprestSheet)(Nothing, "GetImprestSheet", False, ImprestSheetID)
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try

            ImprestSheetBindingSource.DataSource = Obj

        End If

        ConfigureButtons()
        ConfigureLimitationButton()
        ReadWriteAuthorization1.ResetControlAuthorization()

        AddDGVColumnSelector(ItemsDataGridView)

        SetDataGridViewLayOut(ItemsDataGridView)
        SetFormLayout(Me)

        If Not Obj Is Nothing AndAlso Not Obj.IsNew AndAlso Not Workers.ImprestSheet.CanEditObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai redaguoti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            ItemsDataGridView.Enabled = True
            ItemsDataGridView.ReadOnly = True
        End If

        Dim h As New EditableDataGridViewHelper(ItemsDataGridView)

    End Sub


    Private Sub OkButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IOkButton.Click

        If Not SaveObj() Then Exit Sub
        Me.Hide()
        Me.Close()

    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IApplyButton.Click
        If SaveObj() Then ConfigureButtons()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ICancelButton.Click
        CancelObj()
    End Sub


    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click

        Dim msg As String = ""

        If Not GetCurrentCompany.IsSettingsReadyForImprestSheet(msg) Then

            MsgBox("Klaida. Nenustatyti visi reikiami nustatymai." & vbCrLf & msg, _
                MsgBoxStyle.Exclamation, "Klaida.")

            MDIParent1.LaunchForm(GetType(F_Company), True, True, 0)

            If Not GetCurrentCompany.IsSettingsReadyForImprestSheet(msg) Then
                MsgBox("Klaida. Nenustatyti visi reikiami nustatymai." & vbCrLf & msg, _
                    MsgBoxStyle.Exclamation, "Klaida.")
                Exit Sub
            End If

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

        Dim cYear As Integer = 0
        Try
            cYear = Integer.Parse(YearComboBox.SelectedItem.ToString)
        Catch ex As Exception
        End Try
        Dim cMonth As Integer = MonthComboBox.SelectedIndex + 1
        If Not cYear > 0 OrElse Not cMonth > 0 Then
            MsgBox("Klaida. Nepasirinkti metai arba mėnuo.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        Using bm As New BindingsManager(ImprestSheetBindingSource, ItemsBindingSource, Nothing, False, False)
            Try
                Obj = LoadObject(Of ImprestSheet)(Nothing, "NewImprestSheet", True, cYear, cMonth)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try
            bm.SetNewDataSource(Obj)
        End Using

        ConfigureButtons()
        ConfigureLimitationButton()

    End Sub

    Private Sub LimitationsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LimitationsButton.Click
        If Obj Is Nothing OrElse String.IsNullOrEmpty(Obj.ChronologicValidator.LimitsExplanation.Trim) Then Exit Sub
        MsgBox(Obj.ChronologicValidator.LimitsExplanation, MsgBoxStyle.MsgBoxHelp, "Taikomi Ribojimai")
    End Sub

    Private Sub ItemsDataGridView_CellContentClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) _
        Handles ItemsDataGridView.CellBeginEdit

        If e.RowIndex < 0 OrElse ItemsDataGridView.Columns(e.ColumnIndex).ReadOnly Then Exit Sub

        Dim currentItem As ImprestItem = Nothing
        Try
            currentItem = DirectCast(ItemsDataGridView.Rows(e.RowIndex).DataBoundItem, ImprestItem)
        Catch ex As Exception
        End Try
        If currentItem Is Nothing Then
            e.Cancel = True
            Exit Sub
        End If



    End Sub

    Private Sub ViewJournalEntryButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ViewJournalEntryButton.Click
        If Obj Is Nothing OrElse Not Obj.ID > 0 Then Exit Sub
        MDIParent1.LaunchForm(GetType(F_GeneralLedgerEntry), False, False, Obj.ID, Obj.ID)
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

        Using bm As New BindingsManager(ImprestSheetBindingSource, ItemsBindingSource, Nothing, True, False)

            Try
                Obj = LoadObject(Of ImprestSheet)(Obj, "Save", False)
            Catch ex As Exception
                ShowError(ex)
                Return False
            End Try

            bm.SetNewDataSource(Obj)

        End Using

        ConfigureButtons()
        ConfigureLimitationButton()

        MsgBox(Answer, MsgBoxStyle.Information, "Info")

        Return True

    End Function

    Private Sub CancelObj()
        If Obj Is Nothing OrElse Obj.IsNew OrElse Not Obj.IsDirty Then Exit Sub
        Using bm As New BindingsManager(ImprestSheetBindingSource, ItemsBindingSource, Nothing, True, True)
        End Using
    End Sub

    Private Sub ConfigureButtons()

        If Obj Is Nothing Then Exit Sub

        ICancelButton.Enabled = Not Obj.IsNew

        RefreshButton.Enabled = ImprestSheet.CanAddObject
        YearComboBox.Enabled = ImprestSheet.CanAddObject
        MonthComboBox.Enabled = ImprestSheet.CanAddObject

        ItemsDataGridView.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange

    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList)) Then Return False

        Try

            YearComboBox.Items.Clear()
            For i As Integer = 1 To 10
                YearComboBox.Items.Add((Today.Year - i + 1).ToString)
            Next

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

    Private Sub ConfigureLimitationButton()

        If Obj Is Nothing Then Exit Sub

        If Not Obj.ChronologicValidator.LimitsExplanation Is Nothing AndAlso _
            Not String.IsNullOrEmpty(Obj.ChronologicValidator.LimitsExplanation.Trim) Then
            LimitationsButton.Visible = True
        Else
            LimitationsButton.Visible = False
        End If

    End Sub

End Class