Imports Csla.Validation
Imports System.Reflection
Public Module CommonValidation

#Region " DateAfterLastClosing "

    ''' <summary>
    ''' Rule ensuring a date is not earlyer then last closing date.
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function DateAfterLastClosing(ByVal target As Object, _
      ByVal e As RuleArgs) As Boolean

        Dim value As Date = _
          CDate(CallByName(target, e.PropertyName, CallType.Get))
        Dim OldValue As Date = CDate(CallByName(target, _
            DirectCast(e, DateAfterLastClosingRuleArgs).OldDatePropertyName, CallType.Get))
        Dim ObjIsNew As Boolean = CBool(CallByName(target, "IsNew", CallType.Get))

        If Not ObjIsNew AndAlso OldValue.Date <= GetCurrentCompany.LastClosingDate.Date Then
            e.Description = "Įmonės duomenų bazėje jau esančio dokumento data yra ankstesnė " & _
                "(ar lygi) už paskutinio 5/6 klasių uždarymo datą. Dokumento redaguoti neleidžiama."
            e.Severity = RuleSeverity.Error
            Return False
        End If

        If value.Date <= GetCurrentCompany.LastClosingDate.Date Then
            e.Description = "Nurodyta dokumento data yra ankstesnė (ar lygi) už paskutinio 5/6 klasių " & _
                "uždarymo datą arba likučių perkėlimo datą."
            e.Severity = RuleSeverity.Error
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class DateAfterLastClosingRuleArgs
        Inherits RuleArgs

        Private _OldDatePropertyName As String
        Public ReadOnly Property OldDatePropertyName() As String
            Get
                Return _OldDatePropertyName
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="propertyName">Name of the property to validate.</param>
        ''' <param name="nOldDatePropertyName">Name of the property where old date is stored (for old objects).</param>
        Public Sub New(ByVal propertyName As String, ByVal nOldDatePropertyName As String)
            MyBase.New(propertyName)
            _OldDatePropertyName = nOldDatePropertyName
        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?OldDatePropertyName=" & _OldDatePropertyName
        End Function

    End Class

#End Region

#Region " DateBetween "

    ''' <summary>
    ''' Rule ensuring a date is between allowed limits.
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function DateBetween(ByVal target As Object, _
      ByVal e As RuleArgs) As Boolean

        Dim value As Date = _
          CDate(CallByName(target, e.PropertyName, CallType.Get))
        Dim MinValue As Date = CDate(CallByName(target, _
            DirectCast(e, DateBetweenRuleArgs).MinDatePropertyName, CallType.Get))
        Dim MaxValue As Date = CDate(CallByName(target, _
            DirectCast(e, DateBetweenRuleArgs).MaxDatePropertyName, CallType.Get))
        Dim MinValueEqualAllowed As Boolean = DirectCast(e, DateBetweenRuleArgs).MinDateEqualAllowed
        Dim MaxValueEqualAllowed As Boolean = DirectCast(e, DateBetweenRuleArgs).MaxDateEqualAllowed

        If value.Date < MinValue.Date OrElse (Not MinValueEqualAllowed AndAlso _
            value.Date = MinValue.Date) Then
            e.Description = "Dokumento data negali būti ankstesnė kaip " & _
                MinValue.ToShortDateString & "." & DirectCast(e, DateBetweenRuleArgs).HumanReadableDescription
            e.Severity = RuleSeverity.Error
            Return False
        End If

        If value.Date > MaxValue.Date OrElse (Not MaxValueEqualAllowed AndAlso _
            value.Date = MaxValue.Date) Then
            e.Description = "Dokumento data negali būti vėlesnė kaip " & _
                MaxValue.ToShortDateString & "." & DirectCast(e, DateBetweenRuleArgs).HumanReadableDescription
            e.Severity = RuleSeverity.Error
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class DateBetweenRuleArgs
        Inherits RuleArgs

        Private _MinDatePropertyName As String
        Public ReadOnly Property MinDatePropertyName() As String
            Get
                Return _MinDatePropertyName
            End Get
        End Property

        Private _MaxDatePropertyName As String
        Public ReadOnly Property MaxDatePropertyName() As String
            Get
                Return _MaxDatePropertyName
            End Get
        End Property

        Private _MinDateEqualAllowed As Boolean
        Public ReadOnly Property MinDateEqualAllowed() As Boolean
            Get
                Return _MinDateEqualAllowed
            End Get
        End Property

        Private _MaxDateEqualAllowed As Boolean
        Public ReadOnly Property MaxDateEqualAllowed() As Boolean
            Get
                Return _MaxDateEqualAllowed
            End Get
        End Property

        Private _HumanReadableDescription As String
        Public ReadOnly Property HumanReadableDescription() As String
            Get
                Return _HumanReadableDescription
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="propertyName">Name of the property to validate.</param>
        ''' <param name="nMinDatePropertyName">Name of the property where earlyest allowed date is stored.</param>
        ''' <param name="nMaxDatePropertyName">Name of the property where latest allowed date is stored.</param>
        Public Sub New(ByVal propertyName As String, ByVal nMinDatePropertyName As String, _
            ByVal nMaxDatePropertyName As String, _
            Optional ByVal nMinDateEqualAllowed As Boolean = True, _
            Optional ByVal nMaxDateEqualAllowed As Boolean = True, _
            Optional ByVal nDescription As String = "")
            MyBase.New(propertyName)
            _MinDatePropertyName = nMinDatePropertyName
            _MaxDatePropertyName = nMaxDatePropertyName
            _MinDateEqualAllowed = nMinDateEqualAllowed
            _MaxDateEqualAllowed = nMaxDateEqualAllowed
            _HumanReadableDescription = nDescription
        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?MinDatePropertyName=" & _MinDatePropertyName & _
                "&MaxDatePropertyName=" & _MaxDatePropertyName & _
                "&MinDateEqualAllowed=" & _MinDateEqualAllowed & _
                "&MaxDateEqualAllowed=" & _MaxDateEqualAllowed & _
                "&HumanReadableDescription=" & _HumanReadableDescription
        End Function

    End Class

#End Region

#Region " DateAfter "

    ''' <summary>
    ''' Rule ensuring a date is after the min date.
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function DateAfter(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim value As Date = CDate(CallByName(target, e.PropertyName, CallType.Get))
        Dim MinValue As Date = CDate(CallByName(target, _
            DirectCast(e, DateBetweenRuleArgs).MinDatePropertyName, CallType.Get))
        Dim MinValueEqualAllowed As Boolean = DirectCast(e, DateBetweenRuleArgs).MinDateEqualAllowed

        If value.Date < MinValue.Date OrElse (Not MinValueEqualAllowed AndAlso _
            value.Date = MinValue.Date) Then
            e.Description = "Dokumento data negali būti ankstesnė kaip " & _
                MinValue.ToShortDateString & "." & DirectCast(e, DateBetweenRuleArgs).Description
            e.Severity = RuleSeverity.Error
            Return False
        End If

        Return True
    End Function

#End Region

#Region " StringNotLonger "

    ''' <summary>
    ''' Rule ensuring a string is not longer then required.
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function StringNotLonger(ByVal target As Object, _
      ByVal e As RuleArgs) As Boolean

        Dim ForHuman As String = DirectCast(e, StringNotLongerRuleArgs).HumanReadableName
        Dim value As String = _
          CStr(CallByName(target, e.PropertyName, CallType.Get))
        If value.Length > DirectCast(e, StringNotLongerRuleArgs).MaxLength Then
            e.Description = ForHuman & " negali būti daugiau " & _
                DirectCast(e, StringNotLongerRuleArgs).MaxLength.ToString & " simbolių."
            e.Severity = DirectCast(e, StringNotLongerRuleArgs).ApplySeverity
            Return False
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class StringNotLongerRuleArgs
        Inherits RuleArgs

        Private _HumanReadableName As String = ""
        ''' <summary>
        ''' Get the human readable property name.
        ''' </summary>
        Public ReadOnly Property HumanReadableName() As String
            Get
                Return _HumanReadableName
            End Get
        End Property

        Private _ApplySeverity As RuleSeverity = RuleSeverity.Error
        ''' <summary>
        ''' Severity to apply to the rule.
        ''' </summary>
        Public ReadOnly Property ApplySeverity() As RuleSeverity
            Get
                Return _ApplySeverity
            End Get
        End Property

        Private _MaxLength As Integer
        ''' <summary>
        ''' Maximum allowed string length.
        ''' </summary>
        Public ReadOnly Property MaxLength() As Integer
            Get
                Return _MaxLength
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="propertyName">Name of the property to validate.</param>
        ''' <param name="HumanReadable">Human readable name of the property.</param>
        ''' <param name="SeverityToApply">Severity of the error to apply.</param>
        Public Sub New(ByVal propertyName As String, ByVal HumanReadable As String, _
            ByVal nMaxLength As Integer, Optional ByVal SeverityToApply As RuleSeverity = RuleSeverity.Error)
            MyBase.New(propertyName)
            _HumanReadableName = HumanReadable
            _ApplySeverity = SeverityToApply
            _MaxLength = nMaxLength
        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?HumanReadableName=" & _HumanReadableName & _
                "&SeverityToApply=" & _ApplySeverity.ToString & _
                "&MaxLength=" & _MaxLength.ToString
        End Function

    End Class

#End Region

#Region " LimitingFactor "

    ''' <summary>
    ''' Rule ensuring that the limiting factor property (boolean) is false.
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function LimitingFactor(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim LimitingFactorPresent As Boolean = _
          CBool(CallByName(target, DirectCast(e, LimitingFactorRuleArgs).FactorPropertyName, CallType.Get))

        If LimitingFactorPresent Then
            e.Description = DirectCast(e, LimitingFactorRuleArgs).FactorDescription
            e.Severity = DirectCast(e, LimitingFactorRuleArgs).ApplySeverity
            Return False
        Else
            Return True
        End If

    End Function

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class LimitingFactorRuleArgs
        Inherits RuleArgs

        Private _FactorDescription As String = ""
        ''' <summary>
        ''' Get the description of the limiting factor.
        ''' </summary>
        Public ReadOnly Property FactorDescription() As String
            Get
                Return _FactorDescription
            End Get
        End Property

        Private _FactorPropertyName As String = ""
        ''' <summary>
        ''' Get the name of the property of the limiting factor (boolean property only).
        ''' </summary>
        Public ReadOnly Property FactorPropertyName() As String
            Get
                Return _FactorPropertyName
            End Get
        End Property

        Private _ApplySeverity As RuleSeverity = RuleSeverity.Error
        ''' <summary>
        ''' Severity to apply to the rule.
        ''' </summary>
        Public ReadOnly Property ApplySeverity() As RuleSeverity
            Get
                Return _ApplySeverity
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="propertyName">Name of the property to validate.</param>
        ''' <param name="nFactorDescription">Human readable description of the limiting factor.</param>
        ''' <param name="nFactorPropertyName">Name of the boolean property that indicates limiting factor.</param>
        ''' <param name="SeverityToApply">Severity of the error to apply.</param>
        Public Sub New(ByVal propertyName As String, ByVal nFactorDescription As String, _
            ByVal nFactorPropertyName As String, Optional ByVal SeverityToApply As RuleSeverity = RuleSeverity.Error)
            MyBase.New(propertyName)
            _FactorDescription = nFactorDescription
            _FactorPropertyName = nFactorPropertyName
            _ApplySeverity = SeverityToApply
        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?FactorDescription=" & _FactorDescription & _
                "&FactorPropertyName=" & _FactorPropertyName & _
                "&ApplySeverity=" & _ApplySeverity.ToString
        End Function

    End Class

#End Region

#Region " LimitingDate "

    ''' <summary>
    ''' Rule ensuring that the date is later then the limiting date.
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function LimitingDate(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim LimitingDateValue As Date = _
        CDate(CallByName(target, DirectCast(e, LimitingDateRuleArgs).FactorPropertyName, CallType.Get))

        Dim TestDate As Date = CDate(CallByName(target, e.PropertyName, CallType.Get))
        Dim TestDateOld As Date = CDate(CallByName(target, _
            DirectCast(e, LimitingDateRuleArgs).OldDatePropertyName, CallType.Get))

        If TestDate.Date < LimitingDateValue.Date OrElse (TestDate.Date = LimitingDateValue.Date _
            AndAlso Not DirectCast(e, LimitingDateRuleArgs).EqualDateAllowed) Then
            e.Description = DirectCast(e, LimitingDateRuleArgs).FactorDescription
            e.Severity = DirectCast(e, LimitingDateRuleArgs).ApplySeverity
            Return False
        End If

        If Not DirectCast(target, Csla.Core.BusinessBase).IsNew AndAlso _
            (TestDateOld.Date < LimitingDateValue.Date OrElse (TestDateOld.Date = LimitingDateValue.Date _
            AndAlso Not DirectCast(e, LimitingDateRuleArgs).EqualDateAllowed)) Then
            e.Description = DirectCast(e, LimitingDateRuleArgs).FactorDescription
            e.Severity = DirectCast(e, LimitingDateRuleArgs).ApplySeverity
            Return False
        End If

        Return True

    End Function

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class LimitingDateRuleArgs
        Inherits RuleArgs

        Private _OldDatePropertyName As String = ""
        ''' <summary>
        ''' Get the name of the property of the old date (date property only) for old objects.
        ''' </summary>
        Public ReadOnly Property OldDatePropertyName() As String
            Get
                Return _OldDatePropertyName
            End Get
        End Property

        Private _FactorDescription As String = ""
        ''' <summary>
        ''' Get the description of the limiting factor.
        ''' </summary>
        Public ReadOnly Property FactorDescription() As String
            Get
                Return _FactorDescription
            End Get
        End Property

        Private _FactorPropertyName As String = ""
        ''' <summary>
        ''' Get the name of the property of the limiting date (date property only).
        ''' </summary>
        Public ReadOnly Property FactorPropertyName() As String
            Get
                Return _FactorPropertyName
            End Get
        End Property

        Private _EqualDateAllowed As Boolean = False
        ''' <summary>
        ''' Get the description of the limiting factor.
        ''' </summary>
        Public ReadOnly Property EqualDateAllowed() As Boolean
            Get
                Return _EqualDateAllowed
            End Get
        End Property

        Private _ApplySeverity As RuleSeverity = RuleSeverity.Error
        ''' <summary>
        ''' Severity to apply to the rule.
        ''' </summary>
        Public ReadOnly Property ApplySeverity() As RuleSeverity
            Get
                Return _ApplySeverity
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="propertyName">Name of the property to validate.</param>
        ''' <param name="nFactorDescription">Human readable description of the limiting factor.</param>
        ''' <param name="nFactorPropertyName">Name of the boolean property that indicates limiting factor.</param>
        ''' <param name="SeverityToApply">Severity of the error to apply.</param>
        Public Sub New(ByVal propertyName As String, ByVal nFactorDescription As String, _
            ByVal nFactorPropertyName As String, ByVal nEqualDateAllowed As Boolean, _
            ByVal nOldDatePropertyName As String, _
            Optional ByVal SeverityToApply As RuleSeverity = RuleSeverity.Error)
            MyBase.New(propertyName)
            _FactorDescription = nFactorDescription
            _FactorPropertyName = nFactorPropertyName
            _EqualDateAllowed = nEqualDateAllowed
            _ApplySeverity = SeverityToApply
            _OldDatePropertyName = nOldDatePropertyName
        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?FactorDescription=" & _FactorDescription & _
                "&FactorPropertyName=" & _FactorPropertyName & _
                "&ApplySeverity=" & _ApplySeverity.ToString & _
                "&OldDatePropertyName=" & _OldDatePropertyName & _
                "&EqualDateAllowed=" & _EqualDateAllowed.ToString
        End Function

    End Class

#End Region

    Public CurrencyCodes As String() = {"LTL", "USD", "EUR", "RUB", "AFN", "ALL", _
        "DZD", "AED", "AMD", "ANG", "AOA", "ARS", "AUD", "AWG", "AZN", "BAM", "BBD", "BDT", _
        "BGN", "BHD", "BIF", "BMD", "BND", "BOB", "BRL", "BSD", "BTN", "BWP", "BYR", "BZD", _
        "CAD", "CDF", "CHF", "CLP", "CNY", "COP", "CRC", "CUP", "CVE", "CYP", "CZK", "DJF", _
        "DKK", "DOP", "DZD", "EEK", "EGP", "ERN", "ETB", "FJD", "FKP", "GBP", "GEL", "GGP", _
        "GHS", "GIP", "GMD", "GNF", "GTQ", "GYD", "HKD", "HNL", "HRK", "HTG", "HUF", "IDR", _
        "ILS", "IMP", "INR", "IQD", "IRR", "ISK", "JEP", "JMD", "JOD", "JPY", "KES", "KGS", _
        "KHR", "KMF", "KPW", "KRW", "KWD", "KYD", "KZT", "LAK", "LBP", "LKR", "LRD", "LSL", _
        "LVL", "LYD", "MAD", "MDL", "MGA", "MKD", "MMK", "MNT", "MOP", "MRO", "MTL", "MUR", _
        "MVR", "MWK", "MXN", "MYR", "MZN", "NAD", "NGN", "NIO", "NOK", "NPR", "NZD", "OMR", _
        "PAB", "PEN", "PGK", "PHP", "PKR", "PLN", "PYG", "QAR", "RON", "RSD", "RWF", "SAR", _
        "SBD", "SCR", "SDG", "SEK", "SGD", "SHP", "SLL", "SOS", "SPL", "SRD", "STD", "SVC", _
        "SYP", "SZL", "THB", "TJS", "TMM", "TND", "TOP", "TRY", "TTD", "TVD", "TWD", "TZS", _
        "UAH", "UGX", "UYU", "UZS", "VEF", "VND", "VUV", "WST", "XAF", "XAG", "XAU", "XCD", _
        "XDR", "XOF", "XPD", "XPF", "XPT", "YER", "ZAR", "ZMK", "ZWD"}

    ''' <summary>
    ''' Rule ensuring a non empty string is present (accepts SimpleRuleArgs).
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function StringRequired(ByVal target As Object, _
      ByVal e As RuleArgs) As Boolean

        Dim Args As SimpleRuleArgs = DirectCast(e, SimpleRuleArgs)

        Dim value As String = Convert.ToString(CallByName(target, e.PropertyName, CallType.Get))

        If value Is Nothing OrElse String.IsNullOrEmpty(value.Trim) Then
            e.Description = "Nenurodyta " & Args.HumanReadableName & "."
            e.Severity = Args.ApplySeverity
            Return False
        Else
            Return True
        End If

    End Function

    ''' <summary>
    ''' Rule ensuring a number is bigger then zero (accepts SimpleRuleArgs).
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function PositiveNumberRequired(ByVal target As Object, _
      ByVal e As Validation.RuleArgs) As Boolean

        Dim Args As SimpleRuleArgs = DirectCast(e, SimpleRuleArgs)

        Dim value As Double = Convert.ToDouble(CallByName(target, e.PropertyName, CallType.Get))

        If Not CRound(value, 4) > 0 Then
            e.Description = "Nenurodyta " & Args.HumanReadableName & "."
            e.Severity = Args.ApplySeverity
            Return False
        Else
            Return True
        End If

    End Function

    ''' <summary>
    ''' Rule ensuring a number is within given limits (accepts NumberBetweenRequiredRuleArgs).
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function NumberBetweenRequired(ByVal target As Object, _
      ByVal e As Validation.RuleArgs) As Boolean

        Dim Args As NumberBetweenRequiredRuleArgs = DirectCast(e, NumberBetweenRequiredRuleArgs)

        Dim value As Double = Convert.ToDouble(CallByName(target, e.PropertyName, CallType.Get))

        If CRound(value, Args.Approximation) < CRound(Args.MinValue, Args.Approximation) Then
            e.Description = Args.HumanReadableName & " negali būti mažesnė kaip " & _
                CRound(Args.MinValue, Args.Approximation).ToString & "."
            e.Severity = Args.ApplySeverity
            Return False
        ElseIf CRound(value, Args.Approximation) > CRound(Args.MaxValue, Args.Approximation) Then
            e.Description = Args.HumanReadableName & " negali būti didesnė kaip " & _
                CRound(Args.MaxValue, Args.Approximation).ToString & "."
            e.Severity = Args.ApplySeverity
            Return False
        End If

        Return True

    End Function

    ''' <summary>
    ''' Rule ensuring a valid currency code is entered (accepts SimpleRuleArgs).
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function CurrencyValid(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim Args As SimpleRuleArgs = DirectCast(e, SimpleRuleArgs)

        Dim value As String = Convert.ToString(CallByName(target, e.PropertyName, CallType.Get))

        If value Is Nothing OrElse String.IsNullOrEmpty(value.Trim) Then
            e.Description = "Nenurodytas valiutos kodas."
            e.Severity = Args.ApplySeverity
            Return False
        End If
        If Array.IndexOf(CurrencyCodes, value.Trim.ToUpper) < 0 Then
            e.Description = "Valiutos kodas '" & value.Trim & "' neegzistuoja."
            e.Severity = Args.ApplySeverity
            Return False
        Else
            Return True
        End If

    End Function

    ''' <summary>
    ''' Rule ensuring an info object (e.g. ClientInfo) is provided (accepts InfoObjectRequiredRuleArgs).
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function InfoObjectRequired(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim Args As InfoObjectRequiredRuleArgs = DirectCast(e, InfoObjectRequiredRuleArgs)

        Dim value As Object = CallByName(target, e.PropertyName, CallType.Get)

        If value Is Nothing OrElse (Not Args.IdPropertyName Is Nothing _
            AndAlso Not String.IsNullOrEmpty(Args.IdPropertyName.Trim) AndAlso _
            DirectCast(CallByName(value, Args.IdPropertyName, CallType.Get), Integer) < 1) Then
            e.Description = "Nenurodyta " & Args.HumanReadableName & "."
            e.Severity = Args.ApplySeverity
            Return False
        Else
            Return True
        End If

    End Function

    ''' <summary>
    ''' Rule ensuring the value in alt language is provided when reference 
    ''' property's value contains foreign language code (or reference property
    ''' holds object that has LanguageCode property) (accepts ReferencePropertyRuleArgs).
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function AltLanguageValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim value As String = DirectCast(CallByName(target, e.PropertyName, CallType.Get), String)
        If Not value Is Nothing AndAlso Not String.IsNullOrEmpty(value.Trim) Then Return True

        Dim Args As ReferencePropertyRuleArgs = DirectCast(e, ReferencePropertyRuleArgs)
        Dim ReferenceObject As Object = CallByName(target, Args.ReferencePropertyName, CallType.Get)

        If ReferenceObject Is Nothing Then Return True

        Dim ForeignLanguageSet As Boolean = False
        Dim LC As String = ""

        If TypeOf ReferenceObject Is String Then

            LC = DirectCast(ReferenceObject, String).Trim
            ForeignLanguageSet = (Not String.IsNullOrEmpty(LC) _
                AndAlso LC.Trim.ToUpper <> LanguageCodeLith.Trim.ToUpper)

        Else

            Try
                LC = CallByName(ReferenceObject, "LanguageCode", CallType.Get)
                ForeignLanguageSet = (Not LC Is Nothing AndAlso Not String.IsNullOrEmpty(LC.Trim) _
                    AndAlso LC.Trim.ToUpper <> LanguageCodeLith.Trim.ToUpper)
            Catch ex As Exception
            End Try

        End If

        If ForeignLanguageSet AndAlso (value Is Nothing OrElse String.IsNullOrEmpty(value.Trim)) Then

            e.Description = "Nenurodyta " & Args.HumanReadableName & _
                " kliento kalba (" & GetLanguageName(LC, False) & ")."
            e.Severity = RuleSeverity.Error
            Return False

        End If

        Return True

    End Function

    ''' <summary>
    ''' Rule ensuring the value of the target property is more/less/equals the value
    ''' of the source property (depending on ComparePropertiesRuleArgs).
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against Date property values or property values that can be converted to Double.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function ComparePropertiesValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim Args As ComparePropertiesRuleArgs = DirectCast(e, ComparePropertiesRuleArgs)

        Dim TargetValue As Object = CallByName(target, Args.PropertyName, CallType.Get)

        If TypeOf TargetValue Is Date Then

            Dim TargetDate As Date = DirectCast(TargetValue, Date)
            Dim SourceDate As Date = DirectCast(CallByName(target, _
                Args.PropertyNameToCompare, CallType.Get), Date)

            If Args.LessThanSourceProperty Then

                If Args.CouldBeEqual Then

                    If Not TargetDate.Date <= SourceDate.Date Then
                        e.Description = Args.ErrorMessage
                        e.Severity = RuleSeverity.Error
                        Return False
                    End If

                Else

                    If Not TargetDate.Date < SourceDate.Date Then
                        e.Description = Args.ErrorMessage
                        e.Severity = RuleSeverity.Error
                        Return False
                    End If

                End If

            Else

                If Args.CouldBeEqual Then

                    If Not TargetDate.Date >= SourceDate.Date Then
                        e.Description = Args.ErrorMessage
                        e.Severity = RuleSeverity.Error
                        Return False
                    End If

                Else

                    If Not TargetDate.Date > SourceDate.Date Then
                        e.Description = Args.ErrorMessage
                        e.Severity = RuleSeverity.Error
                        Return False
                    End If

                End If

            End If

            Return True

        End If

        Dim TargetDblValue As Double = CRound(Convert.ToDouble(TargetValue), Args.Approximation)
        Dim SourceDblValue As Double = CRound(Convert.ToDouble(CallByName(target, _
            Args.PropertyNameToCompare, CallType.Get)), Args.Approximation)

        If Args.LessThanSourceProperty Then

            If Args.CouldBeEqual Then

                If Not TargetDblValue <= SourceDblValue Then
                    e.Description = Args.ErrorMessage
                    e.Severity = RuleSeverity.Error
                    Return False
                End If

            Else

                If Not TargetDblValue < SourceDblValue Then
                    e.Description = Args.ErrorMessage
                    e.Severity = RuleSeverity.Error
                    Return False
                End If

            End If

        Else

            If Args.CouldBeEqual Then

                If Not TargetDblValue >= SourceDblValue Then
                    e.Description = Args.ErrorMessage
                    e.Severity = RuleSeverity.Error
                    Return False
                End If

            Else

                If Not TargetDblValue > SourceDblValue Then
                    e.Description = Args.ErrorMessage
                    e.Severity = RuleSeverity.Error
                    Return False
                End If

            End If

        End If

        Return True

    End Function

    ''' <summary>
    ''' Rule ensuring a property's value is unique in collection (accepts SimpleRuleArgs).
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function ValueUniqueInCollection(ByVal target As Object, _
      ByVal e As RuleArgs) As Boolean

        If Not TypeOf target Is Csla.Core.BusinessBase Then Return True

        Dim parent As ICollection
        Try
            Dim FI As PropertyInfo = target.GetType.GetProperty("Parent", _
                BindingFlags.NonPublic Or BindingFlags.Instance)
            parent = DirectCast(FI.GetValue(target, Nothing), ICollection)
        Catch ex As Exception
            Return True
        End Try

        If parent Is Nothing Then Return True

        Dim Args As SimpleRuleArgs = DirectCast(e, SimpleRuleArgs)

        Dim value As String = Convert.ToString(CallByName(target, e.PropertyName, CallType.Get))
        If value Is Nothing OrElse String.IsNullOrEmpty(value.Trim) Then Return True

        For Each obj As Object In parent
            If Not Object.ReferenceEquals(obj, target) Then
                Dim secondValue As String = ""
                Try
                    secondValue = Convert.ToString(CallByName(obj, e.PropertyName, CallType.Get))
                Catch ex As Exception
                End Try
                If Not secondValue Is Nothing AndAlso Not String.IsNullOrEmpty(secondValue.Trim) _
                    AndAlso secondValue.Trim.ToLower = value.Trim.ToLower Then
                    e.Description = "Ne unikalus " & Args.HumanReadableName & "."
                    e.Severity = Args.ApplySeverity
                    Return False
                End If
            End If
        Next

        Return True

    End Function

    ''' <summary>
    ''' Rule ensuring that the chronology requirements are kept.
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function ChronologyValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim objectDate As Date = DirectCast((CallByName(target, DirectCast(e, ChronologyRuleArgs). _
            DatePropertyName, CallType.Get)), Date)

        Dim validationObject As IChronologicValidator = DirectCast((CallByName(target, _
            DirectCast(e, ChronologyRuleArgs).ValidatorPropertyName, CallType.Get)), IChronologicValidator)

        If validationObject Is Nothing Then Return True

        Return validationObject.ValidateOperationDate(objectDate, e.Description, e.Severity)

    End Function

#Region " RuleArgs "

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class SimpleRuleArgs
        Inherits RuleArgs

        Private _HumanReadableName As String = ""
        ''' <summary>
        ''' Get the human readable property name.
        ''' </summary>
        Public ReadOnly Property HumanReadableName() As String
            Get
                Return _HumanReadableName
            End Get
        End Property

        Private _ApplySeverity As RuleSeverity = RuleSeverity.Error
        ''' <summary>
        ''' Severity to apply to the rule.
        ''' </summary>
        Public ReadOnly Property ApplySeverity() As RuleSeverity
            Get
                Return _ApplySeverity
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="propertyName">Name of the property to validate.</param>
        ''' <param name="HumanReadable">Human readable name of the property.</param>
        ''' <param name="SeverityToApply">Severity of the error to apply.</param>
        Public Sub New(ByVal propertyName As String, ByVal HumanReadable As String, _
            Optional ByVal SeverityToApply As RuleSeverity = RuleSeverity.Error)
            MyBase.New(propertyName)
            _HumanReadableName = HumanReadable
            _ApplySeverity = SeverityToApply
        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?HumanReadableName=" & _HumanReadableName & _
                "&ApplySeverity=" & _ApplySeverity.ToString
        End Function

    End Class

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class NumberBetweenRequiredRuleArgs
        Inherits RuleArgs

        Private _HumanReadableName As String = ""
        ''' <summary>
        ''' Get the human readable property name.
        ''' </summary>
        Public ReadOnly Property HumanReadableName() As String
            Get
                Return _HumanReadableName
            End Get
        End Property

        Private _ApplySeverity As RuleSeverity = RuleSeverity.Error
        ''' <summary>
        ''' Severity to apply to the rule.
        ''' </summary>
        Public ReadOnly Property ApplySeverity() As RuleSeverity
            Get
                Return _ApplySeverity
            End Get
        End Property

        Private _MinValue As Double = 0
        ''' <summary>
        ''' Get the minimal allowed value of the property.
        ''' </summary>
        Public ReadOnly Property MinValue() As Double
            Get
                Return _MinValue
            End Get
        End Property

        Private _MaxValue As Double = 0
        ''' <summary>
        ''' Get the maximal allowed value of the property.
        ''' </summary>
        Public ReadOnly Property MaxValue() As Double
            Get
                Return _MaxValue
            End Get
        End Property

        Private _Approximation As Integer = 2
        Public ReadOnly Property Approximation() As Integer
            Get
                Return _Approximation
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="propertyName">Name of the property to validate.</param>
        ''' <param name="HumanReadable">Human readable name of the property.</param>
        ''' <param name="SeverityToApply">Severity of the error to apply.</param>
        Public Sub New(ByVal propertyName As String, ByVal HumanReadable As String, _
            ByVal cMinValue As Double, ByVal cMaxValue As Double, _
            Optional ByVal nApproximation As Integer = 2, _
            Optional ByVal SeverityToApply As RuleSeverity = RuleSeverity.Error)
            MyBase.New(propertyName)
            _HumanReadableName = HumanReadable
            _ApplySeverity = SeverityToApply
            _MinValue = cMinValue
            _MaxValue = cMaxValue
            _Approximation = nApproximation
        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?HumanReadableName=" & _HumanReadableName & _
                "&ApplySeverity=" & _ApplySeverity.ToString & _
                "&MinValue=" & _MinValue.ToString & _
                "&MaxValue=" & _MaxValue.ToString & _
                "&Approximation=" & _Approximation.ToString
        End Function

    End Class

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class InfoObjectRequiredRuleArgs
        Inherits RuleArgs

        Private _HumanReadableName As String = ""
        ''' <summary>
        ''' Get the human readable property name.
        ''' </summary>
        Public ReadOnly Property HumanReadableName() As String
            Get
                Return _HumanReadableName
            End Get
        End Property

        Private _IdPropertyName As String = ""
        ''' <summary>
        ''' Get the property name that is used to check if non null info object 
        ''' is not empty object, i.e. ID=0.
        ''' </summary>
        Public ReadOnly Property IdPropertyName() As String
            Get
                Return _IdPropertyName
            End Get
        End Property

        Private _ApplySeverity As RuleSeverity = RuleSeverity.Error
        ''' <summary>
        ''' Severity to apply to the rule.
        ''' </summary>
        Public ReadOnly Property ApplySeverity() As RuleSeverity
            Get
                Return _ApplySeverity
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="propertyName">Name of the property to validate.</param>
        ''' <param name="SeverityToApply">Severity of the error to apply.</param>
        Public Sub New(ByVal propertyName As String, ByVal nHumanReadableName As String, _
            ByVal nIdPropertyName As String, Optional ByVal SeverityToApply As RuleSeverity = RuleSeverity.Error)

            MyBase.New(propertyName)
            _HumanReadableName = nHumanReadableName
            _ApplySeverity = SeverityToApply
            _IdPropertyName = nIdPropertyName

        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?HumanReadableName=" & _HumanReadableName _
                & "&ApplySeverity=" & _ApplySeverity.ToString _
                & "&IdPropertyName=" & _IdPropertyName
        End Function

    End Class

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class ReferencePropertyRuleArgs
        Inherits RuleArgs

        Private _HumanReadableName As String = ""
        ''' <summary>
        ''' Get the human readable property name.
        ''' </summary>
        Public ReadOnly Property HumanReadableName() As String
            Get
                Return _HumanReadableName
            End Get
        End Property

        Private _IdPropertyName As String = ""
        ''' <summary>
        ''' Get the property name that is used to check if non null info object 
        ''' is not empty object, i.e. ID=0.
        ''' </summary>
        Public ReadOnly Property IdPropertyName() As String
            Get
                Return _IdPropertyName
            End Get
        End Property

        Private _ApplySeverity As RuleSeverity = RuleSeverity.Error
        ''' <summary>
        ''' Severity to apply to the rule.
        ''' </summary>
        Public ReadOnly Property ApplySeverity() As RuleSeverity
            Get
                Return _ApplySeverity
            End Get
        End Property

        Private _ReferencePropertyName As String = False
        Public ReadOnly Property ReferencePropertyName() As String
            Get
                Return _ReferencePropertyName
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="propertyName">Name of the property to validate.</param>
        ''' <param name="SeverityToApply">Severity of the error to apply.</param>
        Public Sub New(ByVal propertyName As String, ByVal nHumanReadableName As String, _
            ByVal nReferencePropertyName As String, ByVal nIdPropertyName As String, _
            Optional ByVal SeverityToApply As RuleSeverity = RuleSeverity.Error)

            MyBase.New(propertyName)
            _HumanReadableName = nHumanReadableName
            _ApplySeverity = SeverityToApply
            _IdPropertyName = nIdPropertyName
            _ReferencePropertyName = nReferencePropertyName

        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?HumanReadableName=" & _HumanReadableName _
                & "&ApplySeverity=" & _ApplySeverity.ToString _
                & "&IdPropertyName=" & _IdPropertyName _
                & "&ReferencePropertyName=" & _ReferencePropertyName
        End Function

    End Class

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class ComparePropertiesRuleArgs
        Inherits RuleArgs

        Private _ErrorMessage As String = ""
        ''' <summary>
        ''' Get the human readable error message.
        ''' </summary>
        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _ErrorMessage
            End Get
        End Property

        Private _PropertyNameToCompare As String = ""
        ''' <summary>
        ''' Get the property name that is used as compare source.
        ''' </summary>
        Public ReadOnly Property PropertyNameToCompare() As String
            Get
                Return _PropertyNameToCompare
            End Get
        End Property

        Private _MoreThanSourceProperty As Boolean = False
        Public ReadOnly Property MoreThanSourceProperty() As Boolean
            Get
                Return _MoreThanSourceProperty
            End Get
        End Property

        Private _LessThanSourceProperty As Boolean = False
        Public ReadOnly Property LessThanSourceProperty() As Boolean
            Get
                Return _LessThanSourceProperty
            End Get
        End Property

        Private _CouldBeEqual As Boolean = False
        Public ReadOnly Property CouldBeEqual() As Boolean
            Get
                Return _CouldBeEqual
            End Get
        End Property

        Private _Approximation As Integer = 2
        Public ReadOnly Property Approximation() As Integer
            Get
                Return _Approximation
            End Get
        End Property

        Private _ApplySeverity As RuleSeverity = RuleSeverity.Error
        ''' <summary>
        ''' Severity to apply to the rule.
        ''' </summary>
        Public ReadOnly Property ApplySeverity() As RuleSeverity
            Get
                Return _ApplySeverity
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="propertyName">Name of the property to validate.</param>
        ''' <param name="SeverityToApply">Severity of the error to apply.</param>
        Public Sub New(ByVal propertyName As String, ByVal nErrorMessage As String, _
            ByVal nPropertyNameToCompare As String, ByVal nMoreThanSourceProperty As Boolean, _
            ByVal nLessThanSourceProperty As Boolean, ByVal nCouldBeEqual As Boolean, _
            Optional ByVal nApproximation As Integer = 2, _
            Optional ByVal SeverityToApply As RuleSeverity = RuleSeverity.Error)

            MyBase.New(propertyName)
            _ErrorMessage = nErrorMessage
            _ApplySeverity = SeverityToApply
            _PropertyNameToCompare = nPropertyNameToCompare
            _MoreThanSourceProperty = nMoreThanSourceProperty
            _LessThanSourceProperty = nLessThanSourceProperty
            _CouldBeEqual = nCouldBeEqual
            _Approximation = nApproximation

        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?ErrorMessage=" & _ErrorMessage _
                & "&ApplySeverity=" & _ApplySeverity.ToString _
                & "&PropertyNameToCompare=" & _PropertyNameToCompare _
                & "&MoreThanSourceProperty=" & _MoreThanSourceProperty.ToString _
                & "&LessThanSourceProperty=" & _LessThanSourceProperty.ToString _
                & "&CouldBeEqual=" & _CouldBeEqual.ToString _
                & "&Approximation=" & _Approximation.ToString
        End Function

    End Class

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class ChronologyRuleArgs
        Inherits RuleArgs

        Private _DatePropertyName As String = ""
        ''' <summary>
        ''' Get the property name that is holding object date.
        ''' </summary>
        Public ReadOnly Property DatePropertyName() As String
            Get
                Return _DatePropertyName
            End Get
        End Property

        Private _ValidatorPropertyName As String = ""
        ''' <summary>
        ''' Get the property name that is holding IChronologicValidator.
        ''' </summary>
        Public ReadOnly Property ValidatorPropertyName() As String
            Get
                Return _ValidatorPropertyName
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="nDatePropertyName">The property name that is holding object date.</param>
        ''' <param name="nValidatorPropertyName">The property name that is holding IChronologicValidator.</param>
        Public Sub New(ByVal nDatePropertyName As String, ByVal nValidatorPropertyName As String)

            MyBase.New(nDatePropertyName)
            _DatePropertyName = nDatePropertyName
            _ValidatorPropertyName = nValidatorPropertyName

        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?DatePropertyName=" & _DatePropertyName _
                & "&ValidatorPropertyName=" & _ValidatorPropertyName
        End Function

    End Class


#End Region


End Module
