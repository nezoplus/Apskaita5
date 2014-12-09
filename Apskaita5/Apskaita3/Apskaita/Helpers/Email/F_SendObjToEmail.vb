Public Class F_SendObjToEmail

    Private Obj As Object
    Private _Version As Integer

    Public Sub New(ByVal ObjToSend As Object, ByVal Version As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Obj = ObjToSend
        _Version = Version

    End Sub

    Private Sub F_SendObjToEmail_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        'If TypeOf Obj Is Documents.InvoiceMade Then
        '    SubjectTextBox.Text = "Saskaita faktura (invoice)"
        'ElseIf TypeOf Obj Is Documents.Order Then
        '    SubjectTextBox.Text = "Uzsakymas (order)"

        'End If

        'If TypeOf Obj Is Documents.InvoiceMade Then

        '    If Not CType(Obj, Documents.InvoiceMade).Payer Is Nothing AndAlso _
        '        CType(Obj, Documents.InvoiceMade).Payer.ID > 0 AndAlso _
        '        Not String.IsNullOrEmpty(CType(Obj, Documents.InvoiceMade).Payer.Email.Trim) Then

        '        EmailTextBox.Text = CType(Obj, Documents.InvoiceMade).Payer.Email.Trim

        '    ElseIf Not CType(Obj, Documents.InvoiceMade).Participant Is Nothing AndAlso _
        '        CType(Obj, Documents.InvoiceMade).Participant.ID > 0 AndAlso _
        '        Not String.IsNullOrEmpty(CType(Obj, Documents.InvoiceMade).Participant.Email.Trim) Then

        '        EmailTextBox.Text = CType(Obj, Documents.InvoiceMade).Participant.Email.Trim

        '    End If

        'End If

        'If TypeOf Obj Is Documents.InvoiceMade OrElse TypeOf Obj Is Documents.Order Then _
        '    MessageTextBox.Text = My.Settings.EmailMessageText

    End Sub

    Private Sub SendButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles SendButton.Click

        If String.IsNullOrEmpty(EmailTextBox.Text.Trim) Then
            MsgBox("Klaida. Nenurodytas gavėjo e-paštas.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        ElseIf String.IsNullOrEmpty(SubjectTextBox.Text.Trim) Then
            MsgBox("Klaida. Nenurodytas pranešimo dalykas.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Dim FileName As String = ""
        'If TypeOf Obj Is Documents.InvoiceMade Then FileName = _
        '    CType(Obj, Documents.InvoiceMade).GetFileName
        'If TypeOf Obj Is Documents.Order Then FileName = _
        '    CType(Obj, Documents.Order).GetFileName

        Using busy As New StatusBusy
            Try
                SendObjectToEmail(Obj, EmailTextBox.Text.Trim, SubjectTextBox.Text.Trim, _
                    MessageTextBox.Text.Trim, _Version, FileName)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try
        End Using

    End Sub

End Class