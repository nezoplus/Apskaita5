Imports ApskaitaObjects.Workers
Public Class F_LabourContract
    Implements ISupportsPrinting, IObjectEditForm

    Private Obj As Contract
    Private ContractID As Integer = 0
    Private PersonID As Integer = 0
    Private Loading As Boolean = True


    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If Not Obj Is Nothing Then Return Obj.ID
            Return 0
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(Contract)
        End Get
    End Property


    Public Sub New(ByVal nObjectID As Integer, ByVal CreateNewContract As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        If CreateNewContract Then
            PersonID = nObjectID
        Else
            ContractID = nObjectID
        End If

    End Sub


    Private Sub F_LabourContract_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.DocumentSerialInfoList)) Then Exit Sub

    End Sub

    Private Sub F_LabourContract_FormClosing(ByVal sender As Object, _
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

    End Sub

    Private Sub F_LabourContract_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Workers.Contract.CanGetObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        Try
            If ContractID > 0 Then
                Obj = LoadObject(Of Contract)(Nothing, "GetContract", False, ContractID)
            Else
                Obj = LoadObject(Of Contract)(Nothing, "NewContract", False, PersonID)
            End If
        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Exit Sub
        End Try

        ContractBindingSource.DataSource = Obj

        ConfigureButtons()

        SetFormLayout(Me)

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


    Private Sub RefreshNumberButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshNumberButton.Click

        If Obj Is Nothing OrElse Not Obj.IsNew Then Exit Sub

        'If Not Obj.IsNew Then
        '    If Not YesOrNo("DĖMESIO. Jūs redaguojate jau įtrauktą į duomenų bazę sutartį. " _
        '        & "Ar tikrai norite suteikti jai naują numerį?") Then Exit Sub
        'End If

        Using busy As New StatusBusy
            Try
                Obj.Number = Settings.CommandLastDocumentNumber.TheCommand( _
                    Settings.DocumentSerialType.LabourContract, Obj.Serial.Trim, Obj.Date, False) + 1
            Catch ex As Exception
                ShowError(ex)
            End Try
        End Using

    End Sub

    Private Sub LimitationsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LimitationsButton.Click

        If Obj Is Nothing OrElse String.IsNullOrEmpty(Obj.ChronologicValidator.LimitsExplanation.Trim) Then Exit Sub

        MsgBox(Obj.ChronologicValidator.LimitsExplanation, MsgBoxStyle.MsgBoxHelp, "Taikomi Ribojimai")

    End Sub

    Private Sub IsTerminatedCheckBox_CheckedChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IsTerminatedCheckBox.CheckedChanged
        TerminationDateDateTimePicker.Enabled = (Not Obj Is Nothing _
            AndAlso DirectCast(Obj.ChronologicValidator, ContractChronologicValidator). _
            TerminationCanBeCanceled AndAlso IsTerminatedCheckBox.Checked)
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

        Using bm As New BindingsManager(ContractBindingSource, Nothing, Nothing, True, False)

            Try
                Obj = LoadObject(Of Contract)(Obj, "Save", False)
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
        If Obj Is Nothing OrElse Obj.IsNew OrElse Not Obj.IsDirty Then Exit Sub
        Using bm As New BindingsManager(ContractBindingSource, Nothing, Nothing, True, True)
        End Using
    End Sub

    Private Sub ConfigureButtons()

        If Obj Is Nothing Then Exit Sub

        SerialComboBox.Enabled = Obj.IsNew
        NumberAccTextBox.ReadOnly = Not Obj.IsNew
        RefreshNumberButton.Enabled = Obj.IsNew
        WageAccTextBox.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        HumanReadableWageTypeComboBox.Enabled = Obj.ChronologicValidator.FinancialDataCanChange
        ExtraPayAccTextBox.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        NPDAccTextBox.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        PNPDAccTextBox.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        IsTerminatedCheckBox.Enabled = DirectCast(Obj.ChronologicValidator, ContractChronologicValidator).TerminationCanBeCanceled
        TerminationDateDateTimePicker.Enabled = DirectCast(Obj.ChronologicValidator, ContractChronologicValidator).TerminationCanBeCanceled AndAlso IsTerminatedCheckBox.Checked
        LimitationsButton.Visible = Not String.IsNullOrEmpty(Obj.ChronologicValidator.LimitsExplanation.Trim)

    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.DocumentSerialInfoList)) Then Return False

        LoadEnumHumanReadableListToComboBox(HumanReadableWageTypeComboBox, GetType(WageType), False)

        Try

            LoadDocumentSerialInfoListToCombo(SerialComboBox, Settings.DocumentSerialType.LabourContract, _
                True, False)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

End Class