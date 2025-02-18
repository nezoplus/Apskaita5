﻿Imports System.Globalization
Imports System.Text

Public Module FormatingMethods

    ''' <summary>
    ''' Converts number to its' letter representation, e.g. 1 to A, 2 to B etc..
    ''' </summary>
    ''' <param name="Number">Number to convert.</param>
    Public Function GetNumberInLetter(ByVal Number As Integer) As String
        Dim letters As String() = New String() {"A", "B", "C", "D", "E", "F", "G", "H", _
            "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "Z", "W"}
        If Number > letters.Length Then Return "X"
        Return letters(Number - 1)
    End Function

    ''' <summary>
    ''' Converts number to its' roman representation, e.g. 1 to I, 2 to II etc..
    ''' </summary>
    ''' <param name="Number">Number to convert.</param>
    Public Function GetRomanNumber(ByVal Number As Integer) As String

        If Number < 0 Then Number = -Number

        Dim sb As New System.Text.StringBuilder()

        While Number > 0
            If Number >= 1000 Then
                sb.Append("M")
                Number -= 1000
            ElseIf Number >= 900 Then
                sb.Append("CM")
                Number -= 900
            ElseIf Number >= 500 Then
                sb.Append("D")
                Number -= 500
            ElseIf Number >= 400 Then
                sb.Append("CD")
                Number -= 400
            ElseIf Number >= 100 Then
                sb.Append("C")
                Number -= 100
            ElseIf Number >= 90 Then
                sb.Append("XC")
                Number -= 90
            ElseIf Number >= 50 Then
                sb.Append("L")
                Number -= 50
            ElseIf Number >= 40 Then
                sb.Append("XL")
                Number -= 40
            ElseIf Number >= 10 Then
                sb.Append("X")
                Number -= 10
            ElseIf Number >= 9 Then
                sb.Append("IX")
                Number -= 9
            ElseIf Number >= 5 Then
                sb.Append("V")
                Number -= 5
            ElseIf Number >= 4 Then
                sb.Append("IV")
                Number -= 4
            ElseIf Number >= 1 Then
                sb.Append("I")
                Number -= 1
            Else
                Throw New Exception("Unexpected error.")
                ' <<-- shouldn't be possble to get here, but it ensures that we will never have an infinite loop (in case the computer is on crack that day).
            End If
        End While

        Return sb.ToString()

    End Function

    ''' <summary>
    ''' Gets a formated and rounded representation of the number.
    ''' </summary>
    ''' <param name="d">Number (double) to be formated.</param>
    ''' <param name="RoundOrder">Round order to be applied (default is 2).</param>
    Public Function DblParser(ByVal d As Double, Optional ByVal roundOrder As Integer = 2) As String

        Dim formatString As String = "##,0"
        If roundOrder > 0 Then formatString = formatString & "." _
            & String.Empty.PadRight(roundOrder, "0"c)

        Return d.ToString(formatString)

    End Function

    ''' <summary>
    ''' Gets a string that represents date formated by ffdata standarts.
    ''' </summary>
    ''' <param name="d">Date to format.</param>
    Public Function GetDateInFFDataFormat(ByVal d As Date) As String
        Return d.ToString("yyyy-MM-dd")
    End Function

    ''' <summary>
    ''' Gets a string that represents number formated by ffdata standarts.
    ''' </summary>
    ''' <param name="n">Number to format.</param>
    Public Function GetNumberInFFDataFormat(ByVal n As Double, Optional zeroAsEmpty As Boolean = False) As String

        If CRound(n) = 0.0 Then
            If zeroAsEmpty Then
                Return String.Empty
            Else
                Return "0,00"
            End If
        End If

        Dim result As String = CRound(n).ToString.
            Replace(CChar(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator), "").
            Replace(CChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator), ",").Trim

        If result.IndexOf(",") < 0 Then result = result & ",00"

        If result.Substring(result.IndexOf(",")).Length < 2 Then result = result & "0"

        Return result

    End Function

    ''' <summary>
    ''' Gets a string that represents month name in lithuanian.
    ''' </summary>
    ''' <param name="MonthNumber">Number of the month.</param>
    ''' <remarks>Default is December (Gruodis).</remarks>
    Public Function GetLithuanianMonth(ByVal MonthNumber As Integer) As String
        Select Case MonthNumber
            Case 1
                Return "Sausio"
            Case 2
                Return "Vasario"
            Case 3
                Return "Kovo"
            Case 4
                Return "Balandžio"
            Case 5
                Return "Gegužės"
            Case 6
                Return "Birželio"
            Case 7
                Return "Liepos"
            Case 8
                Return "Rugpjūčio"
            Case 9
                Return "Rugsėjo"
            Case 10
                Return "Spalio"
            Case 11
                Return "Lapkričio"
            Case Else
                Return "Gruodžio"
        End Select
    End Function

    Public Function GetLithuanianDate(ByVal value As Date) As String
        Return value.Year.ToString & " m. " & GetLithuanianMonth(value.Month) & " mėn. " _
            & value.Day.ToString.PadLeft(2, "0"c) & " d."
    End Function

    ''' <summary>
    ''' Gets a string that represents number wording in lithuanian.
    ''' </summary>
    ''' <param name="NumberArg">Number to convert.</param>
    ''' <param name="intCase">Casing of the string to be returned (0-TitleCase; 1-UpperCase; 2-LowerCase)</param>
    ''' <param name="AddZero">Indicates whether zeros should be added.</param>
    Public Function SumLT(ByVal NumberArg As Double, Optional ByVal intCase As Integer = 0, _
        Optional ByVal AddZero As Boolean = True, Optional ByVal CurrencyCode As String = "") As String
        '*----------------------------
        ' Funkcijos pirmasis argumentas – suma, užrašyta skaičiais
        ' Funkcijos antrasis (nebūtinas) argumentas – požymis, 
        ' nusakantis, kokiomis raidėmis bus gauta funkcijos reikšmė:
        ' 0 (arba praleistas) – pirmoji sakinio raidė didžioji, o kitos mažosios;
        ' 1 visas sakinys – didžiosios raidės;
        ' 2 visas sakinys – mažosios raidės.
        ' Funkcijos reikšmė – suma žodžiais.
        '*----------------------------

        Dim result As String = ""
        Dim strSuma As String = ""
        Dim strMillions As String = ""
        Dim strThousands As String = ""
        Dim strHundreds As String = ""
        Dim m1 As String = ""
        Dim m2 As String = ""
        Dim t1 As String = ""
        Dim t2 As String = ""
        Dim r1 As String = ""
        Dim r2 As String = ""
        Dim v As String = ""
        Dim d As String = ""
        Dim strRez As String = ""
        Dim isNegative As Boolean = False

        If NumberArg < 0 Then
            NumberArg = -NumberArg
            isNegative = True
        End If

        strSuma = Format(NumberArg, "000,000,000.00")
        strMillions = Mid(strSuma, 1, 3)
        strThousands = Mid(strSuma, 5, 3)
        strHundreds = Mid(strSuma, 9, 3)
        If NumberArg < 1 Then
            strRez = "NULIS LITŲ "
            GoTo pabaiga
        End If

        If strMillions <> "000" Then
            m1 = TrysSkaitmenys(strMillions)
            d = Mid(strMillions, 2, 1)
            v = Right(strMillions, 1)
            Select Case d
                Case "1"
                    m2 = "MILIJONŲ "
                Case Else
                    Select Case v
                        Case "0"
                            m2 = "MILIJONŲ "
                        Case "1"
                            m2 = "MILIJONAS "
                        Case Else
                            m2 = "MILIJONAI "
                    End Select
            End Select
        End If
        If strThousands <> "000" Then
            t1 = TrysSkaitmenys(strThousands)
            d = Mid(strThousands, 2, 1)
            v = Right(strThousands, 1)
            Select Case d
                Case "1"
                    t2 = "TŪKSTANČIŲ "
                Case Else
                    Select Case v
                        Case "0"
                            t2 = "TŪKSTANČIŲ "
                        Case "1"
                            t2 = "TŪKSTANTIS "
                        Case Else
                            t2 = "TŪKSTANČIAI "
                    End Select

            End Select
        End If

        r1 = TrysSkaitmenys(strHundreds)
        d = Mid(strHundreds, 2, 1)
        v = Right(strHundreds, 1)

        Select Case d
            Case "1"
                r2 = "LITŲ "
            Case Else
                Select Case v
                    Case "0"
                        r2 = "LITŲ "
                    Case "1"
                        r2 = "LITAS "
                    Case Else
                        r2 = "LITAI "
                End Select
        End Select

        strRez = m1 + m2 + t1 + t2 + r1 + r2 + " "

Pabaiga:

        If Not CurrencyCode Is Nothing AndAlso Not String.IsNullOrEmpty(CurrencyCode.Trim) _
            AndAlso CurrencyCode.Trim.ToUpper = "EUR" Then
            strRez = strRez.Replace("LITŲ", "EURŲ"). _
                Replace("LITAS", "EURAS"). _
                Replace("LITAI", "EURAI")
        ElseIf Not CurrencyCode Is Nothing AndAlso Not String.IsNullOrEmpty(CurrencyCode.Trim) _
            AndAlso CurrencyCode.Trim.ToUpper <> "LTL" Then
            strRez = strRez.Replace("LITŲ", CurrencyCode.Trim.ToUpper). _
                Replace("LITAS", CurrencyCode.Trim.ToUpper). _
                Replace("LITAI", CurrencyCode.Trim.ToUpper)
        End If

        If isNegative Then strRez = "minus " & strRez

        Select Case intCase
            Case 0
                result = UCase(Left(strRez, 1)) + LCase(Mid(strRez, 2))
            Case 1
                result = UCase(strRez)
            Case 2
                result = LCase(strRez)
        End Select

        If AddZero Then result = result + Right(strSuma, 2) + " ct"

        Return result

    End Function

    Private Function TrysSkaitmenys(ByVal strNum3 As String) As String

        Dim s1 As String = "" '* 1 'šimtai
        Dim d1 As String = "" '* 1 'dešimtys
        Dim d2 As String = "" '* 2 'dešimtys ir vienetai
        Dim v1 As String = "" '* 1 'vienetai
        Dim s3 As String = ""
        Dim d3 As String = ""
        Dim v3 As String = ""

        s1 = Left(strNum3, 1)
        d1 = Mid(strNum3, 2, 1)
        d2 = Mid(strNum3, 2, 2)
        v1 = Right(strNum3, 1)

        Select Case s1
            Case "1"
                s3 = "VIENAS ŠIMTAS "
            Case "2"
                s3 = "DU ŠIMTAI "
            Case "3"
                s3 = "TRYS ŠIMTAI "
            Case "4"
                s3 = "KETURI ŠIMTAI "
            Case "5"
                s3 = "PENKI ŠIMTAI "
            Case "6"
                s3 = "ŠEŠI ŠIMTAI "
            Case "7"
                s3 = "SEPTYNI ŠIMTAI "
            Case "8"
                s3 = "AŠTUONI ŠIMTAI "
            Case "9"
                s3 = "DEVYNI ŠIMTAI "
        End Select
        Select Case d1
            Case "1"
                Select Case d2
                    Case "10"
                        d3 = "DEšIMT "
                    Case "11"
                        d3 = "VIENUOLIKA "
                    Case "12"
                        d3 = "DVYLIKA "
                    Case "13"
                        d3 = "TRYLIKA "
                    Case "14"
                        d3 = "KETURIOLIKA "
                    Case "15"
                        d3 = "PENKIOLIKA "
                    Case "16"
                        d3 = "ŠEŠIOLIKA "
                    Case "17"
                        d3 = "SEPTYNIOLIKA "
                    Case "18"
                        d3 = "AŠTUONIOLIKA "
                    Case "19"
                        d3 = "DEVYNIOLIKA "
                End Select
            Case "2"
                d3 = "DVIDEŠIMT "
            Case "3"
                d3 = "TRISDEŠIMT "
            Case "4"
                d3 = "KETURIASDEŠIMT "
            Case "5"
                d3 = "PENKIASDEŠIMT "
            Case "6"
                d3 = "ŠEŠIASDEŠIMT "
            Case "7"
                d3 = "SEPTYNIASDEŠIMT "
            Case "8"
                d3 = "AŠTUONIASDEŠIMT "
            Case "9"
                d3 = "DEVYNIASDEŠIMT "
        End Select
        If d1 <> "1" Then
            Select Case v1
                Case "1"
                    v3 = "VIENAS "
                Case "2"
                    v3 = "DU "
                Case "3"
                    v3 = "TRYS "
                Case "4"
                    v3 = "KETURI "
                Case "5"
                    v3 = "PENKI "
                Case "6"
                    v3 = "ŠEŠI "
                Case "7"
                    v3 = "SEPTYNI "
                Case "8"
                    v3 = "AŠTUONI "
                Case "9"
                    v3 = "DEVYNI "
            End Select
        End If
        TrysSkaitmenys = s3 + d3 + v3
    End Function

    Dim nums() As String = {"", "One", "Two", "Three", "Four", "Five", "Six", _
        "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", _
        "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Ninteen"}
    Dim tens() As String = {"", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", _
        "Seventy", "Eighty", "Ninty"}

    ''' <summary>
    ''' Returns number in english.
    ''' </summary>
    ''' <param name="Number">Number to express in words</param>
    ''' <param name="Level">If level > 0 - zero is returned as empty string, else - as "Zero"</param>
    ''' <param name="CurrencyName">Currency name to use.</param>
    Public Function WriteNumberEN(ByVal Number As Double, Optional ByVal Level As Long = 0, _
        Optional ByVal CurrencyName As String = "") As String

        Dim floatingPointPart As Integer = Convert.ToInt32(CRound(Number - Math.Floor(Number), 2) * 100)
        Dim floatingPointPartString As String = floatingPointPart.ToString

        Dim longNumber As Long = Convert.ToInt64(Math.Floor(Number))

        If (Level = 0) And (longNumber = 0) Then Return "Zero " & CurrencyName & " " _
            & floatingPointPartString & " ct."
        If (Level > 0) And (longNumber = 0) Then
            If floatingPointPart > 0 Then
                Return "Zero " & CurrencyName & " " & floatingPointPartString & " ct."
            Else
                Return ""
            End If
        End If

        Return WriteNumberENT(longNumber) & " " & CurrencyName & " " & floatingPointPart & " ct."

    End Function

    Private Function WriteNumberENT(ByVal Number As Long, Optional ByVal Level As Long = 0) As String

        If Number < 0 Then Return "Minus " & WriteNumberENT(-Number)

        Dim result As String = ""

        Select Case Number
            Case Is < 20
                Return nums(Convert.ToInt32(Number)) & " "
            Case 20 To 99
                Return tens(Convert.ToInt32(Number \ 10)) & " " & WriteNumberENT(Number Mod 10, Level + 1)
            Case 100 To 999
                Return nums(Convert.ToInt32(Number \ 100)) & " Hundred " _
                    & DirectCast(IIf(((Number Mod 1000) = 0), "and ", ""), String) _
                    & WriteNumberENT(Number Mod 100, Level + 1)
            Case 1000 To 999999
                Return WriteNumberENT(Number \ 1000, Level + 1) & "Thousand " _
                    & DirectCast(IIf(Number Mod 1000 = 0, "", " "), String) _
                    & WriteNumberENT(Number Mod 1000, Level + 1)
            Case Convert.ToInt64(10 ^ 6) To Convert.ToInt64(10 ^ 12) - 1
                Return WriteNumberENT(Number \ Convert.ToInt64(10 ^ 6), Level + 1) & "Million " _
                    & DirectCast(IIf(Number Mod Convert.ToInt64(10 ^ 6) = 0, "", " "), String) _
                    & WriteNumberENT(Number Mod Convert.ToInt64(10 ^ 6), Level + 1)
            Case Else
                Return WriteNumberENT(Number \ Convert.ToInt64(10 ^ 12), Level + 1) & "Billion " _
                    & DirectCast(IIf(Number Mod Convert.ToInt64(10 ^ 12) = 0, "", " "), String) _
                    & WriteNumberENT(Number Mod Convert.ToInt64(10 ^ 12), Level + 1)
        End Select

    End Function


    ''' <summary>
    ''' Gets a full description of the exception provided.
    ''' </summary>
    ''' <param name="ex">The exception to get the description for.</param>
    ''' <remarks></remarks>
    Public Function FormatExceptionString(ByVal ex As Exception) As String
        Dim result As New StringBuilder()
        FormatExceptionString(ex, result, False)
        Return result.ToString().Trim()
    End Function

    Private Sub FormatExceptionString(ByVal ex As Exception, ByVal builder As StringBuilder, ByVal internal As Boolean)

        If internal Then
            builder.AppendLine("Vidinės klaidos (internal exception) duomenys:")
        Else
            builder.AppendLine("Klaidos duomenys:")
        End If

        builder.AppendLine("Klaidos tekstas:")
        builder.AppendLine(ex.Message)

        If ex.Source IsNot Nothing Then
            builder.AppendLine("Klaidos šaltinis(Ex.Source):")
            builder.AppendLine(ex.Source)
        End If

        If ex.TargetSite IsNot Nothing Then
            builder.AppendLine("Klaidos metodas (Ex.TargetSite):")
            builder.AppendLine(ex.TargetSite.Name)
        End If

        If Not StringIsNullOrEmpty(ex.StackTrace) Then
            builder.AppendLine("Klaidos stekas:")
            builder.AppendLine(ex.StackTrace)
        End If

        If ex.InnerException IsNot Nothing Then
            builder.AppendLine()
            builder.AppendLine("----------------------------")
            builder.AppendLine()
            FormatExceptionString(ex.InnerException, builder, True)
        End If

    End Sub

End Module
