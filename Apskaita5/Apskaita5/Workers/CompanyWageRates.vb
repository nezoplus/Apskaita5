Namespace Workers

    <Serializable()> _
    Public Class CompanyWageRates
        Inherits BusinessBase(Of CompanyWageRates)

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _RateSODRAEmployee As Double = 0
        Private _RateSODRAEmployer As Double = 0
        Private _RatePSDEmployee As Double = 0
        Private _RatePSDEmployer As Double = 0
        Private _RateGuaranteeFund As Double = 0
        Private _RateGPM As Double = 0
        Private _RateHR As Double = 0
        Private _RateSC As Double = 0
        Private _RateON As Double = 0
        Private _RateSickLeave As Double = 0
        Private _NPDFormula As String = ""
        Private _FinancialDataCanChange As Boolean = True


        Public ReadOnly Property FinancialDataCanChange() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        Public Property RateSODRAEmployee() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateSODRAEmployee)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If value < 0 Then value = 0
                If CRound(_RateSODRAEmployee) <> CRound(value) Then
                    _RateSODRAEmployee = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property RateSODRAEmployer() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateSODRAEmployer)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If value < 0 Then value = 0
                If CRound(_RateSODRAEmployer) <> CRound(value) Then
                    _RateSODRAEmployer = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property RatePSDEmployee() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RatePSDEmployee)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If value < 0 Then value = 0
                If CRound(_RatePSDEmployee) <> CRound(value) Then
                    _RatePSDEmployee = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property RatePSDEmployer() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RatePSDEmployer)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If value < 0 Then value = 0
                If CRound(_RatePSDEmployer) <> CRound(value) Then
                    _RatePSDEmployer = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property RateGuaranteeFund() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateGuaranteeFund)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If value < 0 Then value = 0
                If CRound(_RateGuaranteeFund) <> CRound(value) Then
                    _RateGuaranteeFund = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property RateGPM() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateGPM)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If value < 0 Then value = 0
                If CRound(_RateGPM) <> CRound(value) Then
                    _RateGPM = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property RateHR() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateHR)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If value < 0 Then value = 0
                If CRound(_RateHR) <> CRound(value) Then
                    _RateHR = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property RateSC() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateSC)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If value < 0 Then value = 0
                If CRound(_RateSC) <> CRound(value) Then
                    _RateSC = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property RateON() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateON)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If value < 0 Then value = 0
                If CRound(_RateON) <> CRound(value) Then
                    _RateON = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property RateSickLeave() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateSickLeave)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If value < 0 Then value = 0
                If CRound(_RateSickLeave) <> CRound(value) Then
                    _RateSickLeave = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property NPDFormula() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NPDFormula.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If value Is Nothing Then value = ""
                If _NPDFormula.Trim <> value.Trim Then
                    _NPDFormula = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property


        ''' <summary>
        ''' Updates tax rates (GPM, SODRA, etc.) from CommonSettings (server side common settings).
        ''' </summary>
        Friend Sub UpdateTaxRates()
            UpdateTaxRates(True)
        End Sub

        Private Sub UpdateTaxRates(ByVal RaisePropertyHasChanged As Boolean)

            Dim cc As Settings.CompanyInfo = GetCurrentCompany()

            _RateSODRAEmployee = cc.Rates.GetRate(RateType.SodraEmployee)
            _RateSODRAEmployer = cc.Rates.GetRate(RateType.SodraEmployer)
            _RatePSDEmployee = cc.Rates.GetRate(RateType.PsdEmployee)
            _RatePSDEmployer = cc.Rates.GetRate(RateType.PsdEmployer)
            _RateGuaranteeFund = cc.Rates.GetRate(RateType.GuaranteeFund)
            _RateGPM = cc.Rates.GetRate(RateType.GpmWage)
            _NPDFormula = cc.DefaultTaxNpdFormula

            If RaisePropertyHasChanged Then
                PropertyHasChanged("RateSODRAEmployee")
                PropertyHasChanged("RateSODRAEmployer")
                PropertyHasChanged("RatePSDEmployee")
                PropertyHasChanged("RatePSDEmployer")
                PropertyHasChanged("RateGuaranteeFund")
                PropertyHasChanged("RateGPM")
                PropertyHasChanged("NPDFormula")
            End If

        End Sub

        ''' <summary>
        ''' Updates wage rates (overtime, night work, etc.) from StatusInfo.
        ''' </summary>
        Friend Sub UpdateWageRates()
            UpdateWageRates(True)
        End Sub

        Private Sub UpdateWageRates(ByVal RaisePropertyHasChanged As Boolean)

            Dim cc As Settings.CompanyInfo = GetCurrentCompany()
            _RateHR = cc.Rates.GetRate(RateType.WageRatePublicHolidays)
            _RateSC = cc.Rates.GetRate(RateType.WageRateDeviations)
            _RateON = cc.Rates.GetRate(RateType.WageRateNight)
            _RateSickLeave = cc.Rates.GetRate(RateType.WageRateSickLeave)

            If RaisePropertyHasChanged Then
                PropertyHasChanged("RateHR")
                PropertyHasChanged("RateSC")
                PropertyHasChanged("RateON")
                PropertyHasChanged("RateSickLeave")
            End If

        End Sub



        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return Me.GetType.FullName
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("RateSODRAEmployee", "SODROS tarifas darbuotojui", Validation.RuleSeverity.Warning))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("RateSODRAEmployer", "SODROS tarifas darbdaviui", Validation.RuleSeverity.Warning))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("RatePSDEmployee", "PSD tarifas darbuotojui", Validation.RuleSeverity.Warning))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("RatePSDEmployer", "PSD tarifas darbdaviui", Validation.RuleSeverity.Warning))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("RateGuaranteeFund", "garantinio fondo tarifas", Validation.RuleSeverity.Warning))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("RateGPM", "GPM tarifas", Validation.RuleSeverity.Warning))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("RateHR", "tarifas už darbą poilsio ir švenčių dienomis", Validation.RuleSeverity.Warning))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("RateSC", "tarifas už ypatingas darbo sąlygas", Validation.RuleSeverity.Warning))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("RateON", "tarifas už naktinį ir viršvalandinį darbą", Validation.RuleSeverity.Warning))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("RateSickLeave", "nedarbingumo tarifas", Validation.RuleSeverity.Warning))

            ValidationRules.AddRule(AddressOf NPDFormulaValidation, New Validation.RuleArgs("NPDFormula"))

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property NPDFormula is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function NPDFormulaValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As CompanyWageRates = DirectCast(target, CompanyWageRates)

            If String.IsNullOrEmpty(ValObj._NPDFormula.Trim) Then
                e.Description = "Nenurodyta NPD apskaičiavimo formulė."
                e.Severity = Validation.RuleSeverity.Warning
                Return False
            End If

            Dim FS As New FormulaSolver
            FS.Param("NPD") = 470
            FS.Param("PAJ") = 800
            If Not FS.Solved(ValObj._NPDFormula.Trim, New Double) Then
                e.Description = "Klaidingai įvesta NPD formulė. Matematinės išraiškos klaida."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewCompanyWageRates() As CompanyWageRates
            Return New CompanyWageRates(True)
        End Function

        Friend Shared Function GetCompanyWageRates(ByVal nRateSODRAEmployee As Double, _
            ByVal nRateSODRAEmployer As Double, ByVal nRatePSDEmployee As Double, _
            ByVal nRatePSDEmployer As Double, ByVal nRateGuaranteeFund As Double, _
            ByVal nRateGPM As Double, ByVal nNPDFormula As String, ByVal nRateHR As Double, _
            ByVal nRateSC As Double, ByVal nRateON As Double, ByVal nRateSickLeave As Double, _
            ByVal nFinancialDataCanChange As Boolean) As CompanyWageRates
            Return New CompanyWageRates(nRateSODRAEmployee, nRateSODRAEmployer, nRatePSDEmployee, _
                nRatePSDEmployer, nRateGuaranteeFund, nRateGPM, nNPDFormula, nRateHR, _
                nRateSC, nRateON, nRateSickLeave, nFinancialDataCanChange)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub


        Public Sub New(ByVal docreate As Boolean)
            MarkAsChild()
            Create()
        End Sub

        Public Sub New(ByVal nRateSODRAEmployee As Double, ByVal nRateSODRAEmployer As Double, _
            ByVal nRatePSDEmployee As Double, ByVal nRatePSDEmployer As Double, _
            ByVal nRateGuaranteeFund As Double, ByVal nRateGPM As Double, _
            ByVal nNPDFormula As String, ByVal nRateHR As Double, ByVal nRateSC As Double, _
            ByVal nRateON As Double, ByVal nRateSickLeave As Double, _
            ByVal nFinancialDataCanChange As Boolean)
            MarkAsChild()
            Fetch(nRateSODRAEmployee, nRateSODRAEmployer, nRatePSDEmployee, nRatePSDEmployer, _
                nRateGuaranteeFund, nRateGPM, nNPDFormula, nRateHR, nRateSC, nRateON, _
                nRateSickLeave, nFinancialDataCanChange)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create()

            UpdateTaxRates(False)
            UpdateWageRates(False)

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal nRateSODRAEmployee As Double, ByVal nRateSODRAEmployer As Double, _
            ByVal nRatePSDEmployee As Double, ByVal nRatePSDEmployer As Double, _
            ByVal nRateGuaranteeFund As Double, ByVal nRateGPM As Double, _
            ByVal nNPDFormula As String, ByVal nRateHR As Double, ByVal nRateSC As Double, _
            ByVal nRateON As Double, ByVal nRateSickLeave As Double, ByVal nFinancialDataCanChange As Boolean)

            _RateSODRAEmployee = nRateSODRAEmployee
            _RateSODRAEmployer = nRateSODRAEmployer
            _RatePSDEmployee = nRatePSDEmployee
            _RatePSDEmployer = nRatePSDEmployer
            _RateGuaranteeFund = nRateGuaranteeFund
            _RateGPM = nRateGPM
            _RateHR = nRateHR
            _RateSC = nRateSC
            _RateON = nRateON
            _RateSickLeave = nRateSickLeave
            _NPDFormula = nNPDFormula

            _FinancialDataCanChange = nFinancialDataCanChange

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

#End Region

    End Class

End Namespace
