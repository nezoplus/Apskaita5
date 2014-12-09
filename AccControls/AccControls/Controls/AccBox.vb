Imports System
Imports System.Globalization

<System.ComponentModel.DefaultBindingProperty("DecimalValue")> _
Public Class AccBox
    Inherits System.Windows.Forms.TextBox

#Region "*** ENUMS AND VARIABLES ***"

    Public Enum Tip ' type of input
        A_Skaicius ' round number
        Skaicius ' floating point number
        Email
        B_Saskaita ' bank account number  
        SODRA ' social security number
        Tekstas ' any text
        AK ' personal identification code
        PVMkodas ' VAT code
    End Enum

    ' moment, on which to apply separator ("." or ",") to the grouping of digits
    Public Enum Separator
        OnEdit
        OnValidate
        Never
    End Enum

    Private Tipas As Tip = Tip.Skaicius
    Private _NegativeValue As Boolean = False ' whether to allow negative numbers
    Private _Apvalinimas As Byte = 2 ' roundint to the digit
    Private kabl As Char = CChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
    Private tsk As Char ' digits grouping simbol (usualy ".")
    Private NegativeSign As Char = CChar(CultureInfo.CurrentCulture.NumberFormat.NegativeSign)
    Private _Err_color As System.Drawing.Color = Color.LightPink
    Private _Ok_color As System.Drawing.Color = Color.White
    Private _Warn_color As System.Drawing.Color = Color.Yellow
    Private _EmptyAsError As Boolean = False ' empty field means the box background is set to the _Err_color
    Private _EmptyAsWarn As Boolean = False ' empty field means the box background is set to the _Warn_color
    Private _MaxNumber As Double = 999999999999 ' maximum allowed number
    Private _UseSeparator As Separator = Separator.OnValidate ' whether to use digits grouping
    Private _AllowLith As Boolean = False ' allow input of lithuanian letters
    Private _ZeroAsEmpty As Boolean = True ' show zero when empty
    Private _AddZeros As Boolean = True ' add zeros to match the rounded form

    Private ChangeInternal As Boolean = False ' internal me.Text change flag (disables OnTextChange event)
    Private PasteComing As Boolean = False
    Public Event OnDecimalValueChanged As eventhandler

#End Region

#Region "*** PROPERTIES ***"

    <System.ComponentModel.Category("Custom")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.Description("Maximum allowed number.")> _
        Public Property MaxNumber() As Double
        Get
            Return _MaxNumber
        End Get
        Set(ByVal Value As Double)
            _MaxNumber = Value
        End Set
    End Property

    <System.ComponentModel.Category("Custom")> _
    <System.ComponentModel.Browsable(True)> _
    <System.ComponentModel.Description("Mark empty field as an error.")> _
    Public Property EmptyAsError() As Boolean
        Get
            Return _EmptyAsError
        End Get
        Set(ByVal Value As Boolean)
            _EmptyAsError = Value
            ColorToGUI()
        End Set
    End Property

    <System.ComponentModel.Category("Custom")> _
            <System.ComponentModel.Browsable(True)> _
            <System.ComponentModel.Description("Mark empty field as a warning.")> _
            Public Property EmptyAsWarn() As Boolean
        Get
            Return _EmptyAsWarn
        End Get
        Set(ByVal Value As Boolean)
            _EmptyAsWarn = Value
            ColorToGUI()
        End Set
    End Property

    <System.ComponentModel.Category("Custom")> _
    <System.ComponentModel.Browsable(True)> _
    <System.ComponentModel.Description("Backcolor on error.")> _
    Public Property ColorOnError() As System.Drawing.Color
        Get
            Return _Err_color
        End Get
        Set(ByVal Value As System.Drawing.Color)
            _Err_color = Value
            ColorToGUI()
        End Set
    End Property

    <System.ComponentModel.Category("Custom")> _
    <System.ComponentModel.Browsable(True)> _
    <System.ComponentModel.Description("Backcolor on warning.")> _
    Public Property ColorOnWarning() As System.Drawing.Color
        Get
            Return _Warn_color
        End Get
        Set(ByVal Value As System.Drawing.Color)
            _Warn_color = Value
            ColorToGUI()
        End Set
    End Property

    <System.ComponentModel.Category("Custom")> _
    <System.ComponentModel.Browsable(True)> _
    <System.ComponentModel.Description("Backcolor if the field is ok.")> _
    Public Property ColorOnOk() As System.Drawing.Color
        Get
            Return _Ok_color
        End Get
        Set(ByVal Value As System.Drawing.Color)
            _Ok_color = Value
            ColorToGUI()
        End Set
    End Property

    <System.ComponentModel.Category("Custom")> _
    <System.ComponentModel.Browsable(True)> _
    <System.ComponentModel.Description("Input type.")> _
    Public Property InputType() As Tip
        Get
            Return Tipas
        End Get
        Set(ByVal Value As Tip)
            Tipas = Value
            ChangeInternal = True
            If Tipas = Tip.A_Skaicius Or Tipas = Tip.Skaicius Then
                Me.Text = D_Parser(Me.Text, _AddZeros)
            ElseIf Tipas = Tip.B_Saskaita Then
                Me.Text = "LT"
            Else
                Me.Text = ""
            End If
            ChangeInternal = False
            ColorToGUI()
        End Set
    End Property

    <System.ComponentModel.Category("Custom")> _
    <System.ComponentModel.Browsable(True)> _
    <System.ComponentModel.Description("Allow negative numbers.")> _
    Public Property NegativeValue() As Boolean
        Get
            Return _NegativeValue
        End Get
        Set(ByVal Value As Boolean)
            _NegativeValue = Value
        End Set
    End Property

    <System.ComponentModel.Category("Custom")> _
    <System.ComponentModel.Browsable(True)> _
    <System.ComponentModel.Description("Round numeric input to the digit.")> _
    Public Property Apvalinimas() As Byte
        Get
            Return _Apvalinimas
        End Get
        Set(ByVal Value As Byte)
            _Apvalinimas = Value
            If Tipas <> Tip.Skaicius Then Exit Property
            ChangeInternal = True
            Me.Text = D_Parser(Me.DecimalValue, _AddZeros)
            ChangeInternal = False
        End Set
    End Property

    <System.ComponentModel.Category("Custom")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.Description("Use digit grouping.")> _
        Public Property UseSeparator() As Separator
        Get
            Return _UseSeparator
        End Get
        Set(ByVal Value As Separator)
            _UseSeparator = Value
            If Tipas <> Tip.Skaicius And Tipas <> Tip.A_Skaicius Then Exit Property
            ChangeInternal = True
            Me.Text = D_Parser(Me.DecimalValue, _AddZeros)
            ChangeInternal = False
        End Set
    End Property

    <System.ComponentModel.Category("Custom")> _
    <System.ComponentModel.Browsable(True)> _
    <System.ComponentModel.Description("Allow lithuanian letters input.")> _
    Public Property AllowLith() As Boolean
        Get
            Return _AllowLith
        End Get
        Set(ByVal Value As Boolean)
            _AllowLith = Value
        End Set
    End Property

    <System.ComponentModel.Category("Custom")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.Description("Empty numeric input type field is always set to 0.")> _
        Public Property ZeroAsEmpty() As Boolean
        Get
            Return _ZeroAsEmpty
        End Get
        Set(ByVal Value As Boolean)
            _ZeroAsEmpty = Value
            If Tipas <> Tip.A_Skaicius And Tipas <> Tip.Skaicius Then Exit Property
            ChangeInternal = True
            If Not Me.Text.Trim.Length > 0 And Value Then Me.Text = D_Parser(0, _AddZeros)
            If Me.Text.Trim.Trim("0").Trim(kabl).Length = 0 And Not Value Then Me.Text = ""
            ChangeInternal = False
        End Set
    End Property

    <System.ComponentModel.Category("Custom")> _
            <System.ComponentModel.Browsable(True)> _
            <System.ComponentModel.Description("Add zero simbols to correspond to the rounded form.")> _
            Public Property AddZeros() As Boolean
        Get
            Return _AddZeros
        End Get
        Set(ByVal Value As Boolean)
            _AddZeros = Value
            If Tipas <> Tip.Skaicius Then Exit Property
            ChangeInternal = True
            Me.Text = D_Parser(Me.DecimalValue, _AddZeros)
            ChangeInternal = False
        End Set
    End Property

    <System.ComponentModel.Category("Custom")> _
            <System.ComponentModel.Browsable(True)> _
            <System.ComponentModel.Description("Decimal value of the field")> _
    Public Property DecimalValue() As Double
        Get
            If Double.TryParse(Me.Text.Replace(System.Threading.Thread.CurrentThread. _
                CurrentCulture.NumberFormat.NumberGroupSeparator, "").Trim, New Double) Then
                Return CRound(CDbl(Me.Text.Replace(System.Threading.Thread.CurrentThread. _
                    CurrentCulture.NumberFormat.NumberGroupSeparator, "").Trim), _Apvalinimas)
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Double)
            ChangeInternal = True
            Me.Text = D_Parser(value.ToString, _AddZeros)
            ChangeInternal = False
            RaiseEvent OnDecimalValueChanged(Me, New EventArgs)
        End Set
    End Property

#End Region

#Region "*** OVERRIDES ***"

    Protected Overrides Sub OnKeyPress(ByVal e As _
               System.Windows.Forms.KeyPressEventArgs)
        ' filters the input according to the set input type rules

        ' If the input type set is a number and input char is a negative sign, check whether it is allowed
        If (Tipas = Tip.A_Skaicius Or Tipas = Tip.Skaicius) And e.KeyChar.ToString = NegativeSign Then
            e.Handled = Not AllowMinus(e.KeyChar)
            Exit Sub
        End If

        ' if input type is a rounded number, only digits and control characters are allowed
        If Tipas = Tip.A_Skaicius Then
            If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            Else
                e.Handled = False
            End If
            Exit Sub
        End If

        If Tipas = Tip.Skaicius Then ' if input type is a number
            ' no input after the rounding order
            If Me.Text.IndexOf(kabl) + _Apvalinimas < Me.TextLength _
                    And Not Char.IsControl(e.KeyChar) And Not Me.Text.IndexOf(kabl) < 0 _
                    And Me.SelectionStart > Me.Text.IndexOf(kabl) Then
                e.Handled = True
                Exit Sub
            End If

            ' if its not a digit or control key
            If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
                ' "." and "," symbols are converted to decimal separator symbol
                If e.KeyChar = tsk Then e.KeyChar = kabl

                ' if its a decimal separator
                If e.KeyChar.ToString = kabl Then
                    If Me.Text.Trim.Length = 0 Then ' auto "0"
                        ChangeInternal = True
                        Me.Text = "0" & kabl
                        ChangeInternal = False
                        Me.SelectionStart = 2
                        Me.SelectionLength = 0
                        e.Handled = True
                    ElseIf Me.Text.Trim = NegativeSign.ToString Then ' auto "-0"
                        ChangeInternal = True
                        Me.Text = NegativeSign & "0" & kabl
                        ChangeInternal = False
                        Me.SelectionStart = 3
                        Me.SelectionLength = 0
                        e.Handled = True
                    ElseIf Me.Text.Contains(kabl) Then ' only one decimal separator is allowed
                        e.Handled = True
                    Else ' else its ok
                        e.Handled = False
                    End If
                Else ' no other symbols, when input type is set to number
                    e.Handled = True
                End If
            End If
            Exit Sub
        End If

        ' if lithuanian letters are not allowed
        If Not _AllowLith Then
            If e.KeyChar.ToString = "ą" Or e.KeyChar.ToString = "č" _
                Or e.KeyChar.ToString = "ę" Or e.KeyChar.ToString = "ė" _
                Or e.KeyChar.ToString = "į" Or e.KeyChar.ToString = "š" _
                Or e.KeyChar.ToString = "ų" Or e.KeyChar.ToString = "ū" _
                Or e.KeyChar.ToString = "ž" Or e.KeyChar.ToString = "Ą" _
                Or e.KeyChar.ToString = "Č" Or e.KeyChar.ToString = "Ę" _
                Or e.KeyChar.ToString = "Ė" Or e.KeyChar.ToString = "Į" _
                Or e.KeyChar.ToString = "Š" Or e.KeyChar.ToString = "Ų" _
                Or e.KeyChar.ToString = "Ū" Or e.KeyChar.ToString = "Ž" Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        End If
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)

        RaiseEvent OnDecimalValueChanged(Me, New EventArgs)
        If ChangeInternal Then Exit Sub ' if its an internal change, don't do a thing

        If (Tipas = Tip.A_Skaicius Or Tipas = Tip.Skaicius) And PasteComing Then ' check paste results for numbers
            If Not Double.TryParse(Me.Text.Replace(tsk, ""), New Double) Then
                ChangeInternal = True
                Me.Text = D_Parser(0, _AddZeros)
                ChangeInternal = False

            ElseIf Math.Floor(CDbl(Me.Text.Replace(tsk, ""))) <> CDbl(Me.Text.Replace(tsk, "")) _
                    And Tipas = Tip.A_Skaicius Then
                ChangeInternal = True
                Me.Text = D_Parser(Math.Round(CDbl(Me.Text.Replace(tsk, "")), 0), False)
                ChangeInternal = False
            End If
            PasteComing = False
        End If

        If (_UseSeparator = Separator.OnEdit Or Not Me.Focused) And (Tipas = Tip.A_Skaicius Or _
                Tipas = Tip.Skaicius) And (Me.TextLength > 3 Or Not Me.Focused) Then

            ChangeInternal = True
            Dim savedSel As Integer = Me.SelectionStart ' saving cursor location
            Dim savedPnts As Integer = TskCount(Me.Text) ' and number of digit grouping points
            If Me.Focused Then
                Me.Text = D_Parser(Me.Text, False)
            Else
                Me.Text = D_Parser(Me.Text, _AddZeros)
            End If

            Try ' calculating cursor's adjusted position
                Me.SelectionStart = savedSel + TskCount(Me.Text) - savedPnts
            Catch ex As Exception
                Me.SelectionStart = Me.Text.Length - 1
            End Try

            Me.SelectionLength = 0
            ChangeInternal = False
        End If

    End Sub

    Protected Overrides Sub OnValidated(ByVal e As System.EventArgs)
        MyBase.OnValidated(e)

        If ChangeInternal Then Exit Sub

        ' if input type is a number, validate the input
        If (Tipas = Tip.A_Skaicius Or Tipas = Tip.Skaicius) Then
            ' if its not a number, then replace with zero
            ' if digit grouping is applied on validation, apply it
            ChangeInternal = True
            If Not Double.TryParse(Me.Text.Replace(tsk, ""), New Double) Then
                Me.Text = D_Parser("0", _AddZeros)
            ElseIf _UseSeparator = Separator.OnValidate Then
                Me.Text = D_Parser(CDbl(Me.Text.Replace(tsk, "")), _AddZeros)
            End If
            ChangeInternal = False

            RaiseEvent OnDecimalValueChanged(Me, New EventArgs) ' indicate, that the value has changed
        End If
    End Sub

    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        MyBase.OnEnter(e)
        ' if digit grouping is applied on validation, remove it before the user starts edit
        If _UseSeparator = Separator.OnValidate And (Tipas = Tip.A_Skaicius _
            Or Tipas = Tip.Skaicius) Then
            ChangeInternal = True
            If Double.TryParse(Me.Text.Replace(tsk, ""), New Double) Then Me.Text = CDbl(Me.Text.Replace(tsk, "")).ToString
            ChangeInternal = False
        End If
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_PASTE = &H302

        If Not (Tipas <> Tip.A_Skaicius And Tipas <> Tip.Skaicius) Then
            If m.Msg = WM_PASTE Then
                Dim ctxt As String = Clipboard.GetText(TextDataFormat.Text)
                If Not Double.TryParse(ctxt.Replace(tsk, ""), New Double) OrElse _
                    (Math.Floor(CDbl(ctxt.Replace(tsk, ""))) <> CDbl(ctxt.Replace(tsk, "")) _
                    And Tipas = Tip.A_Skaicius) Then
                    PasteComing = True
                End If
            End If

        End If
        MyBase.WndProc(m)
    End Sub

#End Region

    Public Sub New()
        MyBase.New()
        ' defining digit grouping symbol on the user system
        If kabl.ToString = "," Then
            tsk = CChar(".")
        Else
            tsk = CChar(",")
        End If
    End Sub

#Region "*** PRIVATE FUNCTIONS ***"

    Private Function Skaiciai(ByVal s As String) As Boolean
        ' returns whether the string provided is a rounded number
        If Not Double.TryParse(s.Replace(tsk, ""), New Double) Then Return False
        If Math.Floor(CDbl(s.Replace(tsk, ""))) <> CDbl(s.Replace(tsk, "")) Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function TskCount(ByVal s As String) As Integer
        ' returns the number of digit grouping symbols in the string
        Dim counter As Integer = 0
        For i As Integer = 1 To s.Length
            If s.Substring(i - 1, 1) = tsk Then counter = counter + 1
        Next
        Return counter
    End Function

    Private Function AllowMinus(ByVal c As Char) As Boolean
        ' returns whether the negative sign input is allowed

        If (Tipas = Tip.A_Skaicius Or Tipas = Tip.Skaicius) Then

            ' not allowed by user settings
            If c.ToString = NegativeSign And Not NegativeValue Then
                Return False

                ' negative sign is only allowed as the first symbol in a number
            ElseIf c.ToString = NegativeSign And Me.SelectionStart > 0 Then
                Return False

                ' else it is allowed
            Else
                Return True
            End If
        End If
        Return True
    End Function

    Protected Function D_Parser(ByVal sk As String, Optional ByVal Zeros As Boolean = True) As String
        ' parses the number string into formated by user set properties string

        Dim formatString As String = ""
        If _UseSeparator Then
            formatString = "##,0"
        Else
            formatString = "#" '"##0"
        End If
        If Tipas = Tip.Skaicius AndAlso _Apvalinimas > 0 Then
            formatString = formatString & "."
            If _AddZeros Then
                formatString = formatString & Zero_Str(_Apvalinimas)
            Else
                formatString = formatString & Zero_Str(_Apvalinimas, "#")
            End If
        End If

        If Not Double.TryParse(sk.Replace(System.Threading.Thread.CurrentThread. _
            CurrentCulture.NumberFormat.NumberGroupSeparator, ""), New Double) Then

            If Not Zeros OrElse Tipas = Tip.A_Skaicius Then Return "0"

            Dim ZeroDbl As Double = 0
            Return ZeroDbl.ToString(formatString)

        End If

        Return CDbl(sk.Replace(System.Threading.Thread.CurrentThread. _
            CurrentCulture.NumberFormat.NumberGroupSeparator, "")).ToString(formatString)

    End Function

    Private Function Zero_Str(ByVal j As Integer, Optional ByVal FillChar As Char = "0") As String
        ' returns a string formed from j ammount of zero symbols
        Dim sd As String = ""
        For i As Integer = 1 To j
            sd = sd & FillChar
        Next
        Return sd
    End Function

    Private Sub ColorToGUI()
        ' check the field for errors and marks if any is found
        ' (changes the backcolor according to the me.Text and properties set by user)
        If Me.Text.Trim().Length < 1 Or ((Tipas = Tip.A_Skaicius Or Tipas = Tip.Skaicius) _
            And (Me.Text.Trim = "0" Or Me.Text.Trim = NegativeSign Or Me.Text.Trim = NegativeSign & "0" _
            Or Me.Text.Trim = NegativeSign & "0" & kabl Or Me.Text.Trim = "0" & kabl)) Then

            If _EmptyAsError Then Me.BackColor = _Err_color
            If _EmptyAsWarn Then Me.BackColor = _Warn_color
            If Not _EmptyAsError And Not _EmptyAsWarn Then Me.BackColor = _Ok_color

        ElseIf Tipas = Tip.Email AndAlso Not (Me.Text.IndexOf("@") <> -1 And Me.Text.IndexOf(".") <> -1 _
            And Me.Text.IndexOf("@") = Me.Text.LastIndexOf("@") _
            And Me.Text.LastIndexOf(".") > Me.Text.IndexOf("@") _
            And Me.Text.ToCharArray()(Me.Text.Length - 1) <> CChar(".")) Then

            Me.BackColor = _Err_color

        ElseIf Tipas = Tip.B_Saskaita AndAlso ((Me.TextLength < 10 Or Me.TextLength > 20) _
            Or (Not Char.IsLetter(Me.Text.ToCharArray()(0)) _
                Or Not Char.IsLetter(Me.Text.ToCharArray()(1)) _
                Or Not Skaiciai(Me.Text.Substring(2)))) Then

            Me.BackColor = _Warn_color

        ElseIf Tipas = Tip.SODRA AndAlso ((Me.Text.Length <> 9) _
            Or (Not Char.IsLetter(Me.Text.ToCharArray()(0)) _
                Or Not Char.IsLetter(Me.Text.ToCharArray()(1)) _
                Or Not Skaiciai(Me.Text.Substring(2)))) Then

            Me.BackColor = _Warn_color

        ElseIf Tipas = Tip.PVMkodas AndAlso ((Me.Text.Length < 11 Or Me.Text.Length > 14) _
            Or (Not Char.IsLetter(Me.Text.ToCharArray()(0)) _
            Or Not Char.IsLetter(Me.Text.ToCharArray()(1)) _
            Or Not Skaiciai(Me.Text.Substring(2)))) Then

            Me.BackColor = _Warn_color

        ElseIf Tipas = Tip.AK AndAlso (Not Skaiciai(Me.Text) Or Me.TextLength <> 11) Then

            Me.BackColor = _Warn_color

        ElseIf (Tipas = Tip.Skaicius Or Tipas = Tip.A_Skaicius) AndAlso (Me.DecimalValue > _MaxNumber) Then
            Me.BackColor = _Err_color

        Else
            Me.BackColor = _Ok_color
        End If
    End Sub

#End Region

End Class


