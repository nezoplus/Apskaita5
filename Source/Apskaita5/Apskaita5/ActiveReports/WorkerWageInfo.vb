﻿Imports ApskaitaObjects.Workers
Imports ApskaitaObjects.Attributes

Namespace ActiveReports

    ''' <summary>
    ''' Represents an item in a <see cref="WorkerWageInfoReport">worker wage report</see>.
    ''' Contains information about worker's wage parameters payments for a certain month.
    ''' </summary>
    ''' <remarks>Should only be used as a child of <see cref="WorkerWageInfoList">WorkerWageInfoList</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class WorkerWageInfo
        Inherits ReadOnlyBase(Of WorkerWageInfo)

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _Year As Integer = 0
        Private _Month As Integer = 0
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
        Private _WorkLoad As Double = 0
        Private _ApplicableVDUHourly As Double = 0
        Private _ApplicableVDUDaily As Double = 0
        Private _NormalHoursWorked As Double = 0
        Private _HRHoursWorked As Double = 0
        Private _ONHoursWorked As Double = 0
        Private _SCHoursWorked As Double = 0
        Private _TotalHoursWorked As Double = 0
        Private _TruancyHours As Double = 0
        Private _TotalDaysWorked As Integer = 0
        Private _HolidayWD As Integer = 0
        Private _HolidayRD As Integer = 0
        Private _SickDays As Integer = 0
        Private _StandartHours As Double = 0
        Private _StandartDays As Integer = 0
        Private _ConventionalWage As Double = 0
        Private _WageTypeHumanReadable As String = ""
        Private _ConventionalExtraPay As Double = 0
        Private _BonusPayQuarterly As Double = 0
        Private _BonusPayAnnual As Double = 0
        Private _OtherPayRelatedToWork As Double = 0
        Private _OtherPayNotRelatedToWork As Double = 0
        Private _PayOutWage As Double = 0
        Private _PayOutExtraPay As Double = 0
        Private _PayOutHR As Double = 0
        Private _PayOutON As Double = 0
        Private _PayOutSC As Double = 0
        Private _PayOutSickLeave As Double = 0
        Private _UnusedHolidayDaysForCompensation As Double = 0
        Private _PayOutHoliday As Double = 0
        Private _PayOutUnusedHolidayCompensation As Double = 0
        Private _PayOutRedundancyPay As Double = 0
        Private _PayOutTotal As Double = 0
        Private _DeductionGPM As Double = 0
        Private _DeductionPSD As Double = 0
        Private _DeductionPSDSickLeave As Double = 0
        Private _DeductionSODRA As Double = 0
        Private _DeductionOther As Double = 0
        Private _ContributionSODRA As Double = 0
        Private _ContributionPSD As Double = 0
        Private _ContributionGuaranteeFund As Double = 0
        Private _PayableTotal As Double = 0
        Private _NPD As Double = 0
        Private _PNPD As Double = 0
        Private _HoursForVDU As Double = 0
        Private _DaysForVDU As Integer = 0
        Private _WageForVDU As Double = 0
        Private _PayedOutTotalSum As Double = 0


        ''' <summary>
        ''' A year for which the information about wage payable and wage payments is provided.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Year() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Year
            End Get
        End Property

        ''' <summary>
        ''' A month for which the information about wage payable and wage payments is provided.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Month() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Month
            End Get
        End Property

        ''' <summary>
        ''' Rate of social security contributions deducted from wage.
        ''' </summary>
        ''' <remarks>In case several different rates were applied for the report month 
        ''' a largest is returned.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property RateSODRAEmployee() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateSODRAEmployee)
            End Get
        End Property

        ''' <summary>
        ''' Rate of social security contributions payed by an employer.
        ''' </summary>
        ''' <remarks>In case several different rates were applied for the report month 
        ''' a largest is returned.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property RateSODRAEmployer() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateSODRAEmployer)
            End Get
        End Property

        ''' <summary>
        ''' Rate of health insurance contributions deducted from wage.
        ''' </summary>
        ''' <remarks>In case several different rates were applied for the report month 
        ''' a largest is returned.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property RatePSDEmployee() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RatePSDEmployee)
            End Get
        End Property

        ''' <summary>
        ''' Rate of health insurance contributions payed by an employer.
        ''' </summary>
        ''' <remarks>In case several different rates were applied for the report month 
        ''' a largest is returned.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property RatePSDEmployer() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RatePSDEmployer)
            End Get
        End Property

        ''' <summary>
        ''' Rate of guarantee fund contributions (insolvency insurance for workers).
        ''' </summary>
        ''' <remarks>In case several different rates were applied for the report month 
        ''' a largest is returned.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property RateGuaranteeFund() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateGuaranteeFund)
            End Get
        End Property

        ''' <summary>
        ''' Personal income tax (GPM) rate.
        ''' </summary>
        ''' <remarks>In case several different rates were applied for the report month 
        ''' a largest is returned.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property RateGPM() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateGPM)
            End Get
        End Property

        ''' <summary>
        ''' Wage for work during public holidays and rest days rate (against normal wage).
        ''' </summary>
        ''' <remarks>In case several different rates were applied for the report month 
        ''' a largest is returned.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property RateHR() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateHR)
            End Get
        End Property

        ''' <summary>
        ''' Wage for dangerous/unsafe work rate (against normal wage).
        ''' </summary>
        ''' <remarks>In case several different rates were applied for the report month 
        ''' a largest is returned.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property RateSC() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateSC)
            End Get
        End Property

        ''' <summary>
        ''' Wage for overtime and night work rate (against normal wage).
        ''' </summary>
        ''' <remarks>In case several different rates were applied for the report month 
        ''' a largest is returned.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property RateON() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateON)
            End Get
        End Property

        ''' <summary>
        ''' Sickness benefit rate as payed by an employer.
        ''' </summary>
        ''' <remarks>In case several different rates were applied for the report month 
        ''' a largest is returned.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property RateSickLeave() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateSickLeave)
            End Get
        End Property

        ''' <summary>
        ''' A formula used to calculate a (minimum) not-taxable personal income (NPD).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property NPDFormula() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NPDFormula.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets the current workload (ratio between contractual work hours 
        ''' and gauge work hours (40H/Week)) for the current labour contract.
        ''' </summary>
        ''' <remarks>In case workload changed in the report month 
        ''' the largest workload is returned.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDWORKLOAD)> _
        Public ReadOnly Property WorkLoad() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_WorkLoad, ROUNDWORKLOAD)
            End Get
        End Property

        ''' <summary>
        ''' Gets the currently applicable average wage per hour for the current labour contract.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property ApplicableVDUHourly() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ApplicableVDUHourly)
            End Get
        End Property

        ''' <summary>
        ''' Gets the currently applicable average wage per day for the current labour contract.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property ApplicableVDUDaily() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ApplicableVDUDaily)
            End Get
        End Property

        ''' <summary>
        ''' Gets the actual work hours for the current labour contract for the current month, 
        ''' that are paid normaly, without applying special rates, e.g. overtime rate, etc.
        ''' (excluding hours that are accounted separately, 
        ''' e.g. <see cref="HRHoursWorked">work hours during public holidays and rest days</see>, etc.)
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Recommended, True, ROUNDWORKHOURS)> _
        Public ReadOnly Property NormalHoursWorked() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_NormalHoursWorked, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets the actual work hours during public holidays and rest days 
        ''' for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDWORKHOURS)> _
        Public ReadOnly Property HRHoursWorked() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_HRHoursWorked, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets the actual overtime and night work hours for the current labour contract 
        ''' for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDWORKHOURS)> _
        Public ReadOnly Property ONHoursWorked() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ONHoursWorked, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets the actual non-safe work hours for the current labour contract 
        ''' for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDWORKHOURS)> _
        Public ReadOnly Property SCHoursWorked() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SCHoursWorked, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total actual work hours for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value equals <see cref="NormalHoursWorked">NormalHoursWorked</see> +
        ''' <see cref="HRHoursWorked">HRHoursWorked</see> +
        ''' <see cref="ONHoursWorked">ONHoursWorked</see> +
        ''' <see cref="SCHoursWorked">SCHoursWorked</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDWORKHOURS)> _
        Public ReadOnly Property TotalHoursWorked() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalHoursWorked, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total actual truancy hours for the current labour contract 
        ''' for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDWORKHOURS)> _
        Public ReadOnly Property TruancyHours() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TruancyHours, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total actual work days for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property TotalDaysWorked() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TotalDaysWorked
            End Get
        End Property

        ''' <summary>
        ''' Gets the number of granted annual holiday days, 
        ''' that would normaly be considered as work days, 
        ''' for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property HolidayWD() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _HolidayWD
            End Get
        End Property

        ''' <summary>
        ''' Gets the number of granted annual holiday days, 
        ''' that would normaly be considered as rest days, 
        ''' for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property HolidayRD() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _HolidayRD
            End Get
        End Property

        ''' <summary>
        ''' Gets the number of sick leave days, that are payed by the employer, 
        ''' for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SickDays() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SickDays
            End Get
        End Property

        ''' <summary>
        ''' Gets the total scheduled work hours for the current labour contract 
        ''' for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDWORKHOURS)> _
        Public ReadOnly Property StandartHours() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_StandartHours, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets the number of scheduled work days for the current labour contract 
        ''' for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property StandartDays() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _StandartDays
            End Get
        End Property

        ''' <summary>
        ''' Gets the current applicable wage for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>In case contractual wage changed during the report month 
        ''' the largest value is returned.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property ConventionalWage() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ConventionalWage)
            End Get
        End Property

        ''' <summary>
        ''' Gets the human readable (regionalized) description of the <see cref="Workers.WageType">type</see> 
        ''' of the current applicable wage for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property WageTypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WageTypeHumanReadable.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets the current applicable extra pay for the current labour contract 
        ''' for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property ConventionalExtraPay() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ConventionalExtraPay)
            End Get
        End Property

        ''' <summary>
        ''' Gets the <see cref="BonusType.k">quarterly bonus</see> for the current labour contract 
        ''' for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property BonusPayQuarterly() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BonusPayQuarterly)
            End Get
        End Property

        ''' <summary>
        ''' Gets the <see cref="BonusType.m">annual bonus</see> for the current labour contract 
        ''' for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property BonusPayAnnual() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BonusPayAnnual
            End Get
        End Property

        ''' <summary>
        ''' Gets the amount of other types of pay, that are related to the work done 
        ''' (included in average salary, e.g. variable extra pay), 
        ''' for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property OtherPayRelatedToWork() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OtherPayRelatedToWork)
            End Get
        End Property

        ''' <summary>
        ''' Gets the amount of other types of pay, that are NOT related to the work done 
        ''' (NOT included in average salary, e.g. various compensations), 
        ''' for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property OtherPayNotRelatedToWork() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OtherPayNotRelatedToWork)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total calculated amount of <see cref="ConventionalWage">wage</see> 
        ''' for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property PayOutWage() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutWage)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total calculated amount of <see cref="ConventionalExtraPay">extra pay</see> 
        ''' for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property PayOutExtraPay() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutExtraPay)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated pay for work during public holidays and rest days.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property PayOutHR() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutHR)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated pay for overtime and night work.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property PayOutON() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutON)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated pay for dangerous/unsafe work.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property PayOutSC() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutSC)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated benefit (pay) for sick leave (payed by the employer).
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property PayOutSickLeave() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutSickLeave)
            End Get
        End Property

        ''' <summary>
        ''' Gets the amount of accumulated (unused) annual holiday days 
        ''' that are compensated (when terminating the contract).
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDACCUMULATEDHOLIDAY)> _
        Public ReadOnly Property UnusedHolidayDaysForCompensation() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnusedHolidayDaysForCompensation, ROUNDACCUMULATEDHOLIDAY)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated pay for the annual holidays.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property PayOutHoliday() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutHoliday)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated compensation for the accumulated (unused) annual holidays.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property PayOutUnusedHolidayCompensation() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutUnusedHolidayCompensation)
            End Get
        End Property

        ''' <summary>
        ''' Gets the amount of redundancy pay (compensation, benefits).
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property PayOutRedundancyPay() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutRedundancyPay)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total calculated payments before deductions (tax, imprest, other).
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property PayOutTotal() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutTotal)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated personal income tax (GPM), that is deducted from wage.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property DeductionGPM() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionGPM)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated health insurance contribution (PSD), 
        ''' that is deducted from wage and payed to SODRA.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property DeductionPSD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionPSD)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated health insurance contribution (PSD), 
        ''' that is deducted from wage and payed to VMI.
        ''' </summary>
        ''' <remarks>Only applicable for year 2009.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property DeductionPSDSickLeave() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionPSDSickLeave)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated social security insurance contribution (SODRA), 
        ''' that is deducted from wage.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property DeductionSODRA() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionSODRA)
            End Get
        End Property

        ''' <summary>
        ''' Gets the amount of other deductions (e.g. to lay damages).
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property DeductionOther() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionOther)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated social security insurance contribution (SODRA), 
        ''' that is payed by the employer.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property ContributionSODRA() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ContributionSODRA)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated health insurance contribution (PSD), 
        ''' that is payed by the employer.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property ContributionPSD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ContributionPSD)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated guarantee fund (insolvency insurance) contribution.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property ContributionGuaranteeFund() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ContributionGuaranteeFund)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total netto wage plus imprest (part of wage already payed in advance).
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property PayableTotal() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayableTotal)
            End Get
        End Property

        ''' <summary>
        ''' Gets the actual (applied) non-taxable personal income size (NPD).
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property NPD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_NPD)
            End Get
        End Property

        ''' <summary>
        ''' Gets the actual (applied) supplementary non-taxable personal income size (PNPD).
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property PNPD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PNPD)
            End Get
        End Property

        ''' <summary>
        ''' Gets the amount of work hours within the current month 
        ''' that should be used when calculating average salary.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDWORKHOURS)> _
        Public ReadOnly Property HoursForVDU() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_HoursForVDU, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets the amount of work days within the current month 
        ''' that should be used when calculating average salary.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DaysForVDU() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DaysForVDU
            End Get
        End Property

        ''' <summary>
        ''' Gets the amount of wage within the current month 
        ''' that should be used when calculating average salary.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property WageForVDU() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_WageForVDU)
            End Get
        End Property

        ''' <summary>
        ''' Gets the amount of wage that was payed to the worker in the current month.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property PayedOutTotalSum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayedOutTotalSum)
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.ActiveReports_WorkerWageInfo_ToString, _
                _Year.ToString, _Month.ToString)
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function GetWorkerWageInfo(ByVal dr As DataRow, _
            ByVal paymentRow As DataRow) As WorkerWageInfo
            Return New WorkerWageInfo(dr, paymentRow)
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal paymentRow As DataRow)
            Fetch(dr, paymentRow)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow, ByVal paymentRow As DataRow)

            If Not dr Is Nothing Then

                _Year = CIntSafe(dr.Item(0), 0)
                _Month = CIntSafe(dr.Item(1), 0)
                _RateSODRAEmployee = CDblSafe(dr.Item(2), 2, 0)
                _RateSODRAEmployer = CDblSafe(dr.Item(3), 2, 0)
                _RatePSDEmployee = CDblSafe(dr.Item(4), 2, 0)
                _RatePSDEmployer = CDblSafe(dr.Item(5), 2, 0)
                _RateGuaranteeFund = CDblSafe(dr.Item(6), 2, 0)
                _RateGPM = CDblSafe(dr.Item(7), 2, 0)
                _RateHR = CDblSafe(dr.Item(8), 2, 0)
                _RateSC = CDblSafe(dr.Item(9), 2, 0)
                _RateON = CDblSafe(dr.Item(10), 2, 0)
                _RateSickLeave = CDblSafe(dr.Item(11), 2, 0)
                _NPDFormula = CStrSafe(dr.Item(12)).Trim
                _WorkLoad = CDblSafe(dr.Item(13), ROUNDWORKLOAD, 0)
                _ApplicableVDUHourly = CDblSafe(dr.Item(14), 2, 0)
                _ApplicableVDUDaily = CDblSafe(dr.Item(15), 2, 0)
                _NormalHoursWorked = CDblSafe(dr.Item(16), ROUNDWORKHOURS, 0)
                _HRHoursWorked = CDblSafe(dr.Item(17), ROUNDWORKHOURS, 0)
                _ONHoursWorked = CDblSafe(dr.Item(18), ROUNDWORKHOURS, 0)
                _SCHoursWorked = CDblSafe(dr.Item(19), ROUNDWORKHOURS, 0)
                _TotalHoursWorked = CRound(_HRHoursWorked + _ONHoursWorked + _SCHoursWorked _
                    + _NormalHoursWorked, ROUNDWORKHOURS)
                _TruancyHours = CDblSafe(dr.Item(20), ROUNDWORKHOURS, 0)
                _TotalDaysWorked = CIntSafe(dr.Item(21), 0)
                _HolidayWD = CIntSafe(dr.Item(22), 0)
                _HolidayRD = CIntSafe(dr.Item(23), 0)
                _SickDays = CIntSafe(dr.Item(24), 0)
                _StandartHours = CDblSafe(dr.Item(25), ROUNDWORKHOURS, 0)
                _StandartDays = CIntSafe(dr.Item(26), 0)
                _ConventionalWage = CDblSafe(dr.Item(27), 2, 0)
                _WageTypeHumanReadable = Utilities.ConvertLocalizedName( _
                    Utilities.ConvertDatabaseCharID(Of WageType)(CStrSafe(dr.Item(28))))
                _ConventionalExtraPay = CDblSafe(dr.Item(29), 2, 0)
                _BonusPayQuarterly = CDblSafe(dr.Item(30), 2, 0)
                _BonusPayAnnual = CDblSafe(dr.Item(31), 2, 0)
                _OtherPayRelatedToWork = CDblSafe(dr.Item(32), 2, 0)
                _OtherPayNotRelatedToWork = CDblSafe(dr.Item(33), 2, 0)
                _PayOutWage = CDblSafe(dr.Item(34), 2, 0)
                _PayOutExtraPay = CDblSafe(dr.Item(35), 2, 0)
                _PayOutHR = CDblSafe(dr.Item(36), 2, 0)
                _PayOutON = CDblSafe(dr.Item(37), 2, 0)
                _PayOutSC = CDblSafe(dr.Item(38), 2, 0)
                _PayOutSickLeave = CDblSafe(dr.Item(39), 2, 0)
                _UnusedHolidayDaysForCompensation = CDblSafe(dr.Item(40), ROUNDACCUMULATEDHOLIDAY, 0)
                _PayOutHoliday = CDblSafe(dr.Item(41), 2, 0)
                _PayOutUnusedHolidayCompensation = CDblSafe(dr.Item(42), 2, 0)
                _PayOutRedundancyPay = CDblSafe(dr.Item(43), 2, 0)
                _PayOutTotal = CDblSafe(dr.Item(44), 2, 0)
                _DeductionGPM = CDblSafe(dr.Item(45), 2, 0)
                _DeductionPSD = CDblSafe(dr.Item(46), 2, 0)
                _DeductionPSDSickLeave = CDblSafe(dr.Item(47), 2, 0)
                _DeductionSODRA = CDblSafe(dr.Item(48), 2, 0)
                _DeductionOther = CDblSafe(dr.Item(49), 2, 0)
                _ContributionSODRA = CDblSafe(dr.Item(50), 2, 0)
                _ContributionPSD = CDblSafe(dr.Item(51), 2, 0)
                _ContributionGuaranteeFund = CDblSafe(dr.Item(52), 2, 0)
                _PayableTotal = CDblSafe(dr.Item(53), 2, 0)
                _NPD = CDblSafe(dr.Item(54), 2, 0)
                _PNPD = CDblSafe(dr.Item(55), 2, 0)
                _HoursForVDU = CDblSafe(dr.Item(56), ROUNDWORKHOURS, 0)
                _DaysForVDU = CIntSafe(dr.Item(57), 0)
                _WageForVDU = CDblSafe(dr.Item(58), 2, 0)

            End If

            If Not paymentRow Is Nothing Then
                _PayedOutTotalSum = CDblSafe(paymentRow.Item(2), 2, 0)
                If dr Is Nothing Then
                    _Year = CIntSafe(paymentRow.Item(0), 0)
                    _Month = CIntSafe(paymentRow.Item(1), 0)
                End If
            End If

        End Sub

#End Region

    End Class

End Namespace