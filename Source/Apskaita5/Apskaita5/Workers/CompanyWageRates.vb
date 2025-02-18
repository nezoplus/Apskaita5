﻿Imports ApskaitaObjects.Attributes

Namespace Workers

    ''' <summary>
    ''' Represents a collection of tax and wage rates applicable to a <see cref="WageSheet">WageSheet</see>.
    ''' </summary>
    ''' <remarks>Should only be used as a child of a <see cref="WageSheet">WageSheet</see>.
    ''' Values are stored in the database table du_ziniarastis.</remarks>
    <Serializable()> _
    Public NotInheritable Class CompanyWageRates
        Inherits BusinessBase(Of CompanyWageRates)

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _RateSODRAEmployee As Double = 0
        Private _RateSODRAEmployer As Double = 0
        Private _RatePSDEmployee As Double = 0
        Private _RatePSDEmployer As Double = 0
        Private _RateGuaranteeFund As Double = 0
        Private _RateGPM As Double = 0
        Private _RateGPMSickLeave As Double = 0
        Private _RateHR As Double = 0
        Private _RateSC As Double = 0
        Private _RateON As Double = 0
        Private _RateSickLeave As Double = 0
        Private _NPDFormula As String = ""
        Private _ApplyNpdToSickLeave As Boolean = False
        Private _FinancialDataCanChange As Boolean = True


        ''' <summary>
        ''' Returnes TRUE if the parent wage sheet allows financial changes due to business restrains.
        ''' </summary>
        ''' <remarks>Chronologic business restrains are provided by a <see cref="SheetChronologicValidator">SheetChronologicValidator</see>.</remarks>
        Public ReadOnly Property FinancialDataCanChange() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Rate of social security contributions deducted from wage.
        ''' </summary>
        ''' <remarks>Default value is stored in <see cref="General.CompanyAccount">CompanyAccount</see>
        ''' of type <see cref="General.DefaultRateType.SodraEmployee">DefaultRateType.SodraEmployee</see>.
        ''' Value is stored in the database table du_ziniarastis.SD_d.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, 2, True, 0.0, 99.0, True)> _
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

        ''' <summary>
        ''' Rate of social security contributions payed by an employer.
        ''' </summary>
        ''' <remarks>Default value is stored in <see cref="General.CompanyAccount">CompanyAccount</see>
        ''' of type <see cref="General.DefaultRateType.SodraEmployer">DefaultRateType.SodraEmployer</see>.
        ''' Value is stored in the database table du_ziniarastis.SD_v.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, 2, True, 0.0, 100.0, True)> _
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

        ''' <summary>
        ''' Rate of health insurance contributions deducted from wage.
        ''' </summary>
        ''' <remarks>Default value is stored in <see cref="General.CompanyAccount">CompanyAccount</see>
        ''' of type <see cref="General.DefaultRateType.PsdEmployee">DefaultRateType.PsdEmployee</see>.
        ''' Value is stored in the database table du_ziniarastis.PSDW.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, 2, True, 0.0, 99.0, True)> _
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

        ''' <summary>
        ''' Rate of health insurance contributions payed by an employer.
        ''' </summary>
        ''' <remarks>Default value is stored in <see cref="General.CompanyAccount">CompanyAccount</see>
        ''' of type <see cref="General.DefaultRateType.PsdEmployer">DefaultRateType.PsdEmployer</see>.
        ''' Value is stored in the database table du_ziniarastis.PSDE.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, 2, True, 0.0, 100.0, True)> _
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

        ''' <summary>
        ''' Rate of guarantee fund contributions (insolvency insurance for workers).
        ''' </summary>
        ''' <remarks>Default value is stored in <see cref="General.CompanyAccount">CompanyAccount</see>
        ''' of type <see cref="General.DefaultRateType.GuaranteeFund">DefaultRateType.GuaranteeFund</see>.
        ''' Value is stored in the database table du_ziniarastis.Garant.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, 2, True, 0.0, 100.0, True)> _
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

        ''' <summary>
        ''' Personal income tax (GPM) rate.
        ''' </summary>
        ''' <remarks>Default value is stored in <see cref="General.CompanyAccount">CompanyAccount</see>
        ''' of type <see cref="General.DefaultRateType.GpmWage">DefaultRateType.GpmWage</see>.
        ''' Value is stored in the database table du_ziniarastis.GPM.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, 2, True, 0.0, 99.0, True)>
        Public Property RateGPM() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Get
                Return CRound(_RateGPM)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
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

        ''' <summary>
        ''' Personal income tax (GPM) rate for sick leave (for year 2019 and later).
        ''' </summary>
        ''' <remarks>Default value is stored in <see cref="General.CompanyAccount">CompanyAccount</see>
        ''' of type <see cref="General.DefaultRateType.GpmSickLeave">DefaultRateType.GpmSickLeave</see>.
        ''' Value is stored in the database table du_ziniarastis.GpmSickLeave.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, 2, True, 0.0, 99.0, True)>
        Public Property RateGPMSickLeave() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Get
                Return CRound(_RateGPMSickLeave)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If value < 0 Then value = 0
                If CRound(_RateGPMSickLeave) <> CRound(value) Then
                    _RateGPMSickLeave = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Wage for work during public holidays and rest days rate (against normal wage).
        ''' </summary>
        ''' <remarks>Default value is stored in <see cref="General.CompanyAccount">CompanyAccount</see>
        ''' of type <see cref="General.DefaultRateType.WageRatePublicHolidays">DefaultRateType.WageRatePublicHolidays</see>.
        ''' Value is stored in the database table du_ziniarastis.P_S.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, 2, True, 200.0, 500.0, False)> _
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

        ''' <summary>
        ''' Wage for dangerous/unsafe work rate (against normal wage).
        ''' </summary>
        ''' <remarks>Default value is stored in <see cref="General.CompanyAccount">CompanyAccount</see>
        ''' of type <see cref="General.DefaultRateType.WageRateDeviations">DefaultRateType.WageRateDeviations</see>.
        ''' Value is stored in the database table du_ziniarastis.Y_S.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, 2, True, 101.0, 500.0, False)> _
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

        ''' <summary>
        ''' Wage for overtime and night work rate (against normal wage).
        ''' </summary>
        ''' <remarks>Default value is stored in <see cref="General.CompanyAccount">CompanyAccount</see>
        ''' of type <see cref="General.DefaultRateType.WageRateOvertime">DefaultRateType.WageRateOvertime</see>.
        ''' Value is stored in the database table du_ziniarastis.N_V.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, 2, True, 150.0, 500.0, False)> _
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

        ''' <summary>
        ''' Sickness benefit rate as payed by an employer.
        ''' </summary>
        ''' <remarks>Default value is stored in <see cref="General.CompanyAccount">CompanyAccount</see>
        ''' of type <see cref="General.DefaultRateType.WageRateSickLeave">DefaultRateType.WageRateSickLeave</see>.
        ''' Value is stored in the database table du_ziniarastis.Nedarb.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, 2, True, 80.0, 100.0, False)> _
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

        ''' <summary>
        ''' A formula used to calculate a (minimum) not-taxable personal income (NPD).
        ''' </summary>
        ''' <remarks>Default value is stored in <see cref="General.Company.DefaultTaxNpdFormula">Company.DefaultTaxNpdFormula</see>.
        ''' Value is stored in the database table du_ziniarastis.NPDF.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255, False)>
        Public Property NPDFormula() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Get
                Return _NPDFormula.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
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
        ''' Whether the not-taxable personal income (NPD) is applied to the sick leave (only used for the year 2019 and later).
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis.ApplyNpdToSickLeave.</remarks>
        Public Property ApplyNpdToSickLeave() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Get
                Return _ApplyNpdToSickLeave
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If _ApplyNpdToSickLeave <> value Then
                    _ApplyNpdToSickLeave = value
                    PropertyHasChanged()
                End If
            End Set
        End Property


        ''' <summary>
        ''' Updates tax rates (GPM, SODRA, etc.) with default values as specified by
        ''' <see cref="ApskaitaObjects.Settings.CompanyInfo.GetDefaultRate">CompanyInfo.GetDefaultRate</see> method.
        ''' </summary>
        Friend Sub UpdateTaxRates()
            UpdateTaxRates(True)
        End Sub

        Private Sub UpdateTaxRates(ByVal raisePropertyHasChanged As Boolean)

            Dim cc As Settings.CompanyInfo = GetCurrentCompany()

            _RateSODRAEmployee = cc.Rates.GetRate(General.DefaultRateType.SodraEmployee)
            _RateSODRAEmployer = cc.Rates.GetRate(General.DefaultRateType.SodraEmployer)
            _RatePSDEmployee = cc.Rates.GetRate(General.DefaultRateType.PsdEmployee)
            _RatePSDEmployer = cc.Rates.GetRate(General.DefaultRateType.PsdEmployer)
            _RateGuaranteeFund = cc.Rates.GetRate(General.DefaultRateType.GuaranteeFund)
            _RateGPM = cc.Rates.GetRate(General.DefaultRateType.GpmWage)
            _RateGPMSickLeave = cc.Rates.GetRate(General.DefaultRateType.GpmSickLeave)
            _NPDFormula = cc.DefaultTaxNpdFormula

            If raisePropertyHasChanged Then
                PropertyHasChanged("RateSODRAEmployee")
                PropertyHasChanged("RateSODRAEmployer")
                PropertyHasChanged("RatePSDEmployee")
                PropertyHasChanged("RatePSDEmployer")
                PropertyHasChanged("RateGuaranteeFund")
                PropertyHasChanged("RateGPM")
                PropertyHasChanged("RateGPMSickLeave")
                PropertyHasChanged("NPDFormula")
            End If

        End Sub

        ''' <summary>
        ''' Updates wage rates (overtime, night work, etc.) with default values as specified by
        ''' <see cref="ApskaitaObjects.Settings.CompanyInfo.GetDefaultRate">CompanyInfo.GetDefaultRate</see> method.
        ''' </summary>
        Friend Sub UpdateWageRates()
            UpdateWageRates(True)
        End Sub

        Private Sub UpdateWageRates(ByVal raisePropertyHasChanged As Boolean)

            Dim cc As Settings.CompanyInfo = GetCurrentCompany()
            _RateHR = cc.Rates.GetRate(General.DefaultRateType.WageRatePublicHolidays)
            _RateSC = cc.Rates.GetRate(General.DefaultRateType.WageRateDeviations)
            _RateON = cc.Rates.GetRate(General.DefaultRateType.WageRateNight)
            _RateSickLeave = cc.Rates.GetRate(General.DefaultRateType.WageRateSickLeave)

            If raisePropertyHasChanged Then
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

            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("RateSODRAEmployee"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("RateSODRAEmployer"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("RatePSDEmployee"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("RatePSDEmployer"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("RateGuaranteeFund"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation,
                New Csla.Validation.RuleArgs("RateGPM"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation,
                New Csla.Validation.RuleArgs("RateGPMSickLeave"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("RateHR"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("RateSC"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("RateON"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("RateSickLeave"))

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

            Dim valObj As CompanyWageRates = DirectCast(target, CompanyWageRates)

            If StringIsNullOrEmpty(valObj._NPDFormula) Then
                e.Description = My.Resources.General_Company_NpdFormulaNull
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Dim solver As New FormulaSolver
            solver.Param("NPD") = 470
            solver.Param("PAJ") = 800
            If Not solver.Solved(valObj._NPDFormula.Trim, New Double) Then
                e.Description = My.Resources.General_Company_NpdFormulaInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            If valObj._NPDFormula.Trim.Length > 255 Then
                e.Description = My.Resources.General_Company_NpdFormulaTooLong
                e.Severity = Validation.RuleSeverity.Warning
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

        ''' <summary>
        ''' Gets a new instance of CompanyWageRates with default values as specified by
        ''' <see cref="ApskaitaObjects.Settings.CompanyInfo.GetDefaultRate">CompanyInfo.GetDefaultRate</see> method.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Shared Function NewCompanyWageRates() As CompanyWageRates
            Return New CompanyWageRates(True)
        End Function

        ''' <summary>
        ''' Gets an existing instance of CompanyWageRates for a <see cref="WageSheet">WageSheet</see>
        ''' by a database query.
        ''' </summary>
        ''' <param name="dr">Database query result.</param>
        ''' <param name="nFinancialDataCanChange">the parent wage sheet allows financial changes 
        ''' due to business restrains as provided by a <see cref="SheetChronologicValidator">SheetChronologicValidator</see>.</param>
        ''' <remarks></remarks>
        Friend Shared Function GetCompanyWageRates(ByVal dr As DataRow, _
            ByVal nFinancialDataCanChange As Boolean) As CompanyWageRates
            Return New CompanyWageRates(dr, nFinancialDataCanChange)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub


        Private Sub New(ByVal docreate As Boolean)
            MarkAsChild()
            Create()
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal nFinancialDataCanChange As Boolean)
            MarkAsChild()
            Fetch(dr, nFinancialDataCanChange)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create()

            UpdateTaxRates(False)
            UpdateWageRates(False)

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal dr As DataRow, ByVal nFinancialDataCanChange As Boolean)

            _RateSODRAEmployee = CDblSafe(dr.Item(14))
            _RateSODRAEmployer = CDblSafe(dr.Item(15))
            _RatePSDEmployee = CDblSafe(dr.Item(16))
            _RatePSDEmployer = CDblSafe(dr.Item(17))
            _RateGuaranteeFund = CDblSafe(dr.Item(13))
            _RateGPM = CDblSafe(dr.Item(12))
            _NPDFormula = CStrSafe(dr.Item(18))
            _RateHR = CDblSafe(dr.Item(8))
            _RateSC = CDblSafe(dr.Item(10))
            _RateON = CDblSafe(dr.Item(9))
            _RateSickLeave = CDblSafe(dr.Item(11))
            _RateGPMSickLeave = CDblSafe(dr.Item(21))
            _ApplyNpdToSickLeave = (CIntSafe(dr.Item(22)) > 0)

            _FinancialDataCanChange = nFinancialDataCanChange

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

#End Region

    End Class

End Namespace
