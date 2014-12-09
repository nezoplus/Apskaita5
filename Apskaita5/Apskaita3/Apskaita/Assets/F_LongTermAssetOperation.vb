Imports ApskaitaObjects.Assets
Public Class F_LongTermAssetOperation
    Implements ISupportsPrinting, IObjectEditForm

    Private Obj As LongTermAssetOperation = Nothing
    Private Loading As Boolean = True
    Private LongTermAssetID As Integer = -1
    Private OperationID As Integer = -1
    Private FetchByJournalEntryID As Boolean = False
    Private ChildObject As Documents.InvoiceAttachedObject = Nothing


    Public Sub New(ByVal nID As Integer, ByVal CreateNewOperation As Boolean, _
        ByVal nFetchByJournalEntryID As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If CreateNewOperation Then
            LongTermAssetID = nID
            OperationID = -1
        Else
            LongTermAssetID = -1
            OperationID = nID
            FetchByJournalEntryID = nFetchByJournalEntryID
        End If

    End Sub

    Public Sub New(ByRef nChildObject As Documents.InvoiceAttachedObject)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        If nChildObject.Type <> Documents.InvoiceAttachedObjectType.LongTermAssetSale _
            AndAlso nChildObject.Type <> Documents.InvoiceAttachedObjectType.LongTermAssetAcquisitionValueChange Then _
            Throw New Exception("Klaida. Objekto tipas nėra ilgalaikio turto pardavimas arba savikainos pokytis.")

        ' Add any initialization after the InitializeComponent() call.
        ChildObject = nChildObject

        LongTermAssetID = 0
        OperationID = 0
        FetchByJournalEntryID = False

    End Sub


    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If Not ChildObject Is Nothing Then Return DirectCast(ChildObject.ValueObject, _
                LongTermAssetOperation).ID
            If Not Obj Is Nothing Then Return Obj.ID
            Return 0
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(LongTermAssetOperation)
        End Get
    End Property


    Private Sub F_LongTermAssetOperation_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList)) Then Exit Sub

    End Sub

    Private Sub F_LongTermAssetOperation_FormClosing(ByVal sender As Object, _
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

        If Not Obj Is Nothing AndAlso Obj.IsDirty Then CancelObj()

        GetFormLayout(Me)

    End Sub

    Private Sub F_LongTermAssetOperation_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If ChildObject Is Nothing Then

            If Not LongTermAssetOperation.CanGetObject AndAlso OperationID > 0 Then
                MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                    MsgBoxStyle.Exclamation, "Klaida.")
                DisableAllControls(Me)
                Exit Sub
            ElseIf Not LongTermAsset.CanAddObject AndAlso Not OperationID > 0 Then
                MsgBox("Klaida. Jūsų teisių nepakanka ilgalaikio turto duomenims tvarkyti.", _
                    MsgBoxStyle.Exclamation, "Klaida.")
                DisableAllControls(Me)
                Exit Sub
            End If

        End If

        If Not SetDataSources() Then Exit Sub

        If ChildObject Is Nothing Then

            If OperationID > 0 Then

                Try
                    Obj = LoadObject(Of LongTermAssetOperation)(Nothing, "GetLongTermAssetOperation", _
                        False, OperationID, FetchByJournalEntryID)
                Catch ex As Exception
                    ShowError(ex)
                    DisableAllControls(Me)
                    Exit Sub
                End Try

            Else

                Try
                    Obj = LoadObject(Of LongTermAssetOperation)(Nothing, "NewLongTermAssetOperation", _
                        False, LongTermAssetID)
                Catch ex As Exception
                    ShowError(ex)
                    DisableAllControls(Me)
                    Exit Sub
                End Try

            End If

            LongTermAssetOperationBindingSource.DataSource = Obj

            ConfigureLimitationButton(Obj)

        Else

            DirectCast(ChildObject.ValueObject, LongTermAssetOperation).BeginEdit()
            LongTermAssetOperationBindingSource.DataSource = DirectCast(ChildObject.ValueObject, _
                LongTermAssetOperation)

            ConfigureLimitationButton(DirectCast(ChildObject.ValueObject, LongTermAssetOperation))

        End If

        ConfigureButtons()

        SetFormLayout(Me)

    End Sub


    Private Sub TypeHumanReadableComboBox_SelectedIndexChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles TypeHumanReadableComboBox.SelectedIndexChanged

        If Obj Is Nothing OrElse Loading OrElse TypeHumanReadableComboBox.SelectedIndex < 0 Then Exit Sub

        Using busy As New StatusBusy

            Try
                Obj.Type = ConvertEnumHumanReadable(Of LtaOperationType) _
                    (TypeHumanReadableComboBox.SelectedItem.ToString)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            ConfigureButtons()
            JournalEntryInfoComboBox.SelectedIndex = -1

        End Using

    End Sub


    Private Sub RefreshJournalEntryInfoButton_Click(ByVal sender As System.Object, _
       ByVal e As System.EventArgs) Handles RefreshJournalEntryInfoButton.Click

        If Obj Is Nothing Then Exit Sub

        Dim JEList As ActiveReports.JournalEntryInfoList

        Try
            JEList = LoadObject(Of ActiveReports.JournalEntryInfoList)(Nothing, "GetList", _
                True, Obj.Date, Obj.Date, "", -1, -1, DocumentType.None, False, "", "")
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        JournalEntryInfoComboBox.DataSource = JEList

    End Sub

    Private Sub AttachJournalEntryInfoButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles AttachJournalEntryInfoButton.Click

        If Obj Is Nothing OrElse JournalEntryInfoComboBox.SelectedItem Is Nothing Then Exit Sub

        Try
            Obj.SetAttachedJournalEntry(CType(JournalEntryInfoComboBox.SelectedItem, _
                ActiveReports.JournalEntryInfo))
        Catch ex As Exception
            ShowError(ex)
        End Try

    End Sub

    Private Sub CalculateAmortizationButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles CalculateAmortizationButton.Click

        If Obj Is Nothing OrElse Obj.Type <> LtaOperationType.Amortization Then Exit Sub

        If Not YesOrNo("Gauti amotizacijos apskaičiavimą operacijos datai?") Then Exit Sub

        Dim AmortizationCalculation As LongTermAssetAmortizationCalculation

        Try
            AmortizationCalculation = LoadObject(Of LongTermAssetAmortizationCalculation)(Nothing, _
                "GetLongTermAssetAmortizationCalculation", True, Obj.AssetID, Obj.ID, Obj.Date)
            Obj.SetAmortizationCalculation(AmortizationCalculation)
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

    End Sub

    Private Sub AmortizationCalculationsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles AmortizationCalculationsButton.Click

        If Obj Is Nothing OrElse Obj.Type <> LtaOperationType.Amortization Then Exit Sub

        Using frm As New F_TextFieldEditor("Amortizacijos apskaičiavimas", _
            Obj.AmortizationCalculations, False)
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then _
                Obj.AmortizationCalculations = frm.TextField
        End Using

    End Sub

    Private Sub LimitationsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LimitationsButton.Click

        If Not ChildObject Is Nothing Then
            MsgBox(ChildObject.ChronologyValidator.LimitsExplanation, MsgBoxStyle.Information, "")
        ElseIf Not Obj Is Nothing Then
            MsgBox(Obj.ChronologyValidator.LimitsExplanation, MsgBoxStyle.Information, "")
        End If

    End Sub


    Private Sub OkButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles OkButton.Click

        If Not ChildObject Is Nothing Then

            If Not DirectCast(ChildObject.ValueObject, LongTermAssetOperation).IsValid Then
                If Not YesOrNo("Redaguojamos operacijos duomenyse yra klaidų:" & vbCrLf _
                    & DirectCast(ChildObject.ValueObject, LongTermAssetOperation). _
                    BrokenRulesCollection.ToString(Csla.Validation.RuleSeverity.Error) _
                    & vbCrLf & vbCrLf & "Ar tikrai norite uždaryti formą?") Then Exit Sub
            End If

            BindingsManager.UnBind(True, False, New BindingSource() {LongTermAssetOperationBindingSource})
            DirectCast(ChildObject.ValueObject, LongTermAssetOperation).ApplyEdit()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        ElseIf Not Obj Is Nothing Then

            If SaveObj() Then Me.Close()

        End If

    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ApplyButton.Click
        If Not ChildObject Is Nothing OrElse Obj Is Nothing Then Exit Sub
        If SaveObj() Then ConfigureButtons()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles CancelButton.Click

        If Not ChildObject Is Nothing Then

            BindingsManager.UnBind(True, True, New BindingSource() {LongTermAssetOperationBindingSource})
            DirectCast(ChildObject.ValueObject, LongTermAssetOperation).CancelEdit()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        ElseIf Not Obj Is Nothing AndAlso Not Obj.IsNew Then

            CancelObj()
            ConfigureButtons()

        End If

    End Sub


    Private Sub NewItemButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewItemButton.Click

        If Not ChildObject Is Nothing Then Exit Sub

        If Not Obj Is Nothing AndAlso TypeOf Obj Is IIsDirtyEnough AndAlso _
            DirectCast(Obj, IIsDirtyEnough).IsDirtyEnough Then
            Dim answ As String = Ask("Išsaugoti duomenis?", New ButtonStructure("Taip"), _
                New ButtonStructure("Ne"), New ButtonStructure("Atšaukti"))
            If answ <> "Taip" AndAlso answ <> "Ne" Then Exit Sub
            If answ = "Taip" Then
                If Not SaveObj() Then Exit Sub
            End If
        End If

        Using bm As New BindingsManager(LongTermAssetOperationBindingSource, _
            Nothing, Nothing, True, True)

            Try
                Obj = LoadObject(Of LongTermAssetOperation)(Nothing, _
                    "NewLongTermAssetOperation", True, Obj.AssetID)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            bm.SetNewDataSource(Obj)

        End Using

        ConfigureButtons()

    End Sub

    Private Sub ViewJournalEntryButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ViewJournalEntryButton.Click

        If Obj Is Nothing OrElse Not Obj.JournalEntryID > 0 Then Exit Sub

        MDIParent1.LaunchForm(GetType(F_GeneralLedgerEntry), False, False, _
            Obj.JournalEntryID, Obj.JournalEntryID)

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

        If Obj Is Nothing OrElse Not Obj.IsDirty Then Return True

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

        Using bm As New BindingsManager(LongTermAssetOperationBindingSource, Nothing, Nothing, True, False)

            Try
                Obj = LoadObject(Of LongTermAssetOperation)(Obj, "Save", False)
            Catch ex As Exception
                ShowError(ex)
                Return False
            End Try

            bm.SetNewDataSource(Obj)

        End Using

        MsgBox(Answer, MsgBoxStyle.Information, "Info")

        NotifyLongTermAssetOperationListParent()

        ConfigureButtons()

        Return True

    End Function

    Private Sub CancelObj()
        If Obj Is Nothing OrElse Obj.IsNew Then Exit Sub
        Using bm As New BindingsManager(LongTermAssetOperationBindingSource, Nothing, Nothing, True, True)
        End Using
    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList)) Then Return False

        Try

            LoadAccountInfoListToGridCombo(AccountCorrespondingAccGridComboBox, True, 1, 2, 6)
            TypeHumanReadableComboBox.DataSource = GetEnumValuesHumanReadableList( _
                GetType(LtaOperationType), False)
            AccountChangeTypeHumanReadableComboBox.DataSource = GetEnumValuesHumanReadableList( _
                GetType(LtaAccountChangeType), False)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

    Private Sub NotifyLongTermAssetOperationListParent()
        For Each frm As Form In MDIParent1.MdiChildren
            If TypeOf frm Is F_LongTermAssetOperationInfoListParent Then _
                CType(frm, F_LongTermAssetOperationInfoListParent). _
                NotifyAboutOperationListChanges(Obj.AssetID)
        Next
    End Sub

    Private Sub ConfigureButtons()

        Dim curObject As LongTermAssetOperation

        If Not ChildObject Is Nothing Then
            curObject = DirectCast(ChildObject.ValueObject, LongTermAssetOperation)
        ElseIf Not Obj Is Nothing Then
            curObject = Obj
        Else
            Exit Sub
        End If

        SetControlReadOnly(DateDateTimePicker, curObject.DateIsReadOnly)
        SetControlReadOnly(ContentTextBox, curObject.ContentIsReadOnly)
        SetControlReadOnly(TypeHumanReadableComboBox, curObject.TypeHumanReadableIsReadOnly)
        SetControlReadOnly(AccountChangeTypeHumanReadableComboBox, curObject.AccountChangeTypeHumanReadableIsReadOnly)
        SetControlReadOnly(AccountCorrespondingAccGridComboBox, curObject.AccountCorrespondingIsReadOnly)
        SetControlReadOnly(ActNumberAccBox, curObject.ActNumberIsReadOnly)

        SetControlReadOnly(NewAmortizationPeriodAccBox, curObject.NewAmortizationPeriodIsReadOnly)

        SetControlReadOnly(UnitValueChangeAccBox, curObject.UnitValueChangeIsReadOnly)
        SetControlReadOnly(AmmountChangeAccBox, curObject.AmmountChangeIsReadOnly)
        SetControlReadOnly(TotalValueChangeAccBox, curObject.TotalValueChangeIsReadOnly)
        SetControlReadOnly(RevaluedPortionUnitValueChangeAccBox, curObject.RevaluedPortionUnitValueChangeIsReadOnly)
        SetControlReadOnly(RevaluedPortionTotalValueChangeAccBox, curObject.RevaluedPortionTotalValueChangeIsReadOnly)

        SetControlReadOnly(AfterOperationAssetValuePerUnitAccBox, curObject.AfterOperationAssetValuePerUnitIsReadOnly)
        SetControlReadOnly(AfterOperationAssetValueAccBox, curObject.AfterOperationAssetValueIsReadOnly)
        SetControlReadOnly(AfterOperationAssetValueRevaluedPortionPerUnitAccBox, curObject.AfterOperationAssetValueRevaluedPortionPerUnitIsReadOnly)
        SetControlReadOnly(AfterOperationAssetValueRevaluedPortionAccBox, curObject.AfterOperationAssetValueRevaluedPortionIsReadOnly)

        AmortizationCalculationsButton.Enabled = (curObject.Type = LtaOperationType.Amortization _
            AndAlso curObject.ChronologyValidator.FinancialDataCanChange)
        AttachJournalEntryInfoButton.Enabled = (curObject.Type = LtaOperationType.AcquisitionValueIncrease _
            OrElse curObject.Type = LtaOperationType.Transfer _
            OrElse curObject.Type = LtaOperationType.ValueChange) AndAlso ChildObject Is Nothing
        RefreshJournalEntryInfoButton.Enabled = (curObject.Type = LtaOperationType.AcquisitionValueIncrease _
            OrElse curObject.Type = LtaOperationType.Transfer _
            OrElse curObject.Type = LtaOperationType.ValueChange) AndAlso ChildObject Is Nothing
        JournalEntryInfoComboBox.Enabled = (curObject.Type = LtaOperationType.AcquisitionValueIncrease _
            OrElse curObject.Type = LtaOperationType.Transfer _
            OrElse curObject.Type = LtaOperationType.ValueChange) AndAlso ChildObject Is Nothing

        EditedBaner.Visible = Not curObject.IsNew
        CancelButton.Enabled = Not curObject.IsNew OrElse Not ChildObject Is Nothing

        ViewJournalEntryButton.Visible = Not Obj Is Nothing

    End Sub

    Private Sub SetControlReadOnly(ByRef cntr As Control, ByVal isReadOnly As Boolean)

        Try
            CType(cntr, Object).ReadOnly = isReadOnly
        Catch ex As Exception
            cntr.Enabled = Not isReadOnly
        End Try

        If isReadOnly Then
            cntr.BackColor = System.Drawing.SystemColors.Control
        Else
            cntr.BackColor = System.Drawing.SystemColors.Window
        End If

    End Sub

    Private Sub ConfigureLimitationButton(ByVal operation As LongTermAssetOperation)

        If operation Is Nothing OrElse operation.ChronologyValidator Is Nothing Then
            LimitationsButton.Visible = False
        ElseIf Not operation.ChronologyValidator.FinancialDataCanChange Then
            LimitationsButton.Visible = True
            LimitationsButton.Image = My.Resources.Action_lock_icon_32p
        Else
            LimitationsButton.Visible = False
        End If

    End Sub

End Class