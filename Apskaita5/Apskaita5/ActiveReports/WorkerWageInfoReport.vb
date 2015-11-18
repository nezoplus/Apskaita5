Namespace ActiveReports

    ''' <summary>
    ''' Represents a worker wage report. Contains information about worker's wage parameters, 
    ''' payments and unused annual holiday balance within the report period.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class WorkerWageInfoReport
        Inherits ReadOnlyBase(Of WorkerWageInfoReport)

#Region " Business Methods "

        Private _Items As WorkerWageInfoList
        Private _TotalSum As Double = 0
        Private _TotalSumAfterDeductions As Double = 0
        Private _DateFrom As Date = Today
        Private _DateTo As Date = Today
        Private _ContractNumber As Integer = 0
        Private _ContractSerial As String = ""
        Private _IsConsolidated As Boolean = False
        Private _PersonID As Integer = 0
        Private _PersonInfo As String = ""
        Private _DebtAtTheStart As Double = 0
        Private _DebtAtEnd As Double = 0
        Private _UnusedHolidaysAtStart As Double = 0
        Private _UnusedHolidaysAtEnd As Double = 0


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Items() As WorkerWageInfoList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Items
            End Get
        End Property

        Public ReadOnly Property TotalSum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalSum)
            End Get
        End Property

        Public ReadOnly Property TotalSumAfterDeductions() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalSumAfterDeductions)
            End Get
        End Property

        Public ReadOnly Property DateFrom() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DateFrom
            End Get
        End Property

        Public ReadOnly Property DateTo() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DateTo
            End Get
        End Property

        Public ReadOnly Property ContractNumber() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContractNumber
            End Get
        End Property

        Public ReadOnly Property ContractSerial() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContractSerial.Trim
            End Get
        End Property

        Public ReadOnly Property IsConsolidated() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsConsolidated
            End Get
        End Property

        Public ReadOnly Property PersonID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonID
            End Get
        End Property

        Public ReadOnly Property PersonInfo() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonInfo.Trim
            End Get
        End Property

        Public ReadOnly Property DebtAtTheStart() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DebtAtTheStart)
            End Get
        End Property

        Public ReadOnly Property DebtAtEnd() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DebtAtEnd)
            End Get
        End Property

        Public ReadOnly Property UnusedHolidaysAtStart() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnusedHolidaysAtStart)
            End Get
        End Property

        Public ReadOnly Property UnusedHolidaysAtEnd() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnusedHolidaysAtEnd)
            End Get
        End Property


        Public Function GetWorkerInfoCardDatatable() As DataTable

            Dim result As New DataTable

            Dim i, j As Integer

            For i = 1 To 11
                result.Columns.Add()
            Next

            Dim MonthCount As Integer = Convert.ToInt32(DateDiff(DateInterval.Month, _DateFrom, _DateTo) + 1)

            For i = 1 To MonthCount * 6 + 12
                result.Rows.Add()
            Next

            result.Rows(0).Item(0) = "Metai"
            result.Rows(0).Item(1) = "Mėnuo"
            result.Rows(0).Item(2) = "Krūvis"
            result.Rows(0).Item(3) = "Dirbta normalių d.v."
            result.Rows(0).Item(4) = "Dirbta poils.šv. d.v."
            result.Rows(0).Item(5) = "Dirbta nakt. viršval. d.v."
            result.Rows(0).Item(6) = "Dirbta yp. sąl. d.v."
            result.Rows(0).Item(7) = "Dirbta d.v. viso"
            result.Rows(0).Item(8) = "Pravaikštų val."
            result.Rows(0).Item(9) = "Dirbta d.d."
            result.Rows(0).Item(10) = "Nedarb. dienų"
            result.Rows(MonthCount + 2).Item(0) = "Metai"
            result.Rows(MonthCount + 2).Item(1) = "Mėnuo"
            result.Rows(MonthCount + 2).Item(2) = "Sut. atost. d.d."
            result.Rows(MonthCount + 2).Item(3) = "Sut. atost. n.d."
            result.Rows(MonthCount + 2).Item(4) = "Kompens. už atost. dien."
            result.Rows(MonthCount + 2).Item(5) = "Grafiko d.v."
            result.Rows(MonthCount + 2).Item(6) = "Grafiko d.d."
            result.Rows(MonthCount + 2).Item(7) = "Tar. poils. šv."
            result.Rows(MonthCount + 2).Item(8) = "Tar. nakt. viršval."
            result.Rows(MonthCount + 2).Item(9) = "Tar. yp. sąl."
            result.Rows(MonthCount + 2).Item(10) = "Tar. nedarb."
            result.Rows(2 * MonthCount + 4).Item(0) = "Metai"
            result.Rows(2 * MonthCount + 4).Item(1) = "Mėnuo"
            result.Rows(2 * MonthCount + 4).Item(2) = "Nustat. DU"
            result.Rows(2 * MonthCount + 4).Item(3) = "Nustat. DU tipas"
            result.Rows(2 * MonthCount + 4).Item(4) = "Nustat. priedas."
            result.Rows(2 * MonthCount + 4).Item(5) = "Priskaič. DU"
            result.Rows(2 * MonthCount + 4).Item(6) = "Priskaič. Priedas"
            result.Rows(2 * MonthCount + 4).Item(7) = "Priskaič. už poils. šv. d."
            result.Rows(2 * MonthCount + 4).Item(8) = "Priskaič. už nakt. viršval. d."
            result.Rows(2 * MonthCount + 4).Item(9) = "Priskaič. už yp. sąl. d."
            result.Rows(2 * MonthCount + 4).Item(10) = "Priskaič. Premijų"
            result.Rows(3 * MonthCount + 6).Item(0) = "Metai"
            result.Rows(3 * MonthCount + 6).Item(1) = "Mėnuo"
            result.Rows(3 * MonthCount + 6).Item(2) = "Priskaič. kitų susij. su atl. darbu"
            result.Rows(3 * MonthCount + 6).Item(3) = "Priskaič. kitų nesusij. su atl. darbu"
            result.Rows(3 * MonthCount + 6).Item(4) = "Priskaič. atost."
            result.Rows(3 * MonthCount + 6).Item(5) = "Priskaič. atost. komp."
            result.Rows(3 * MonthCount + 6).Item(6) = "Priskaič. išeit. išm."
            result.Rows(3 * MonthCount + 6).Item(7) = "Priskaič. nedarb."
            result.Rows(3 * MonthCount + 6).Item(8) = "Priskaič. iš viso"
            result.Rows(3 * MonthCount + 6).Item(9) = "Tar. SODRA darbuot."
            result.Rows(3 * MonthCount + 6).Item(10) = "Išskaič. SODRA"
            result.Rows(4 * MonthCount + 8).Item(0) = "Metai"
            result.Rows(4 * MonthCount + 8).Item(1) = "Mėnuo"
            result.Rows(4 * MonthCount + 8).Item(2) = "Tar. GPM"
            result.Rows(4 * MonthCount + 8).Item(3) = "Pritaikyta NPD"
            result.Rows(4 * MonthCount + 8).Item(4) = "Pritaikyta PNPD"
            result.Rows(4 * MonthCount + 8).Item(5) = "Išskaič. GPM"
            result.Rows(4 * MonthCount + 8).Item(6) = "Tar. PSD darbuot."
            result.Rows(4 * MonthCount + 8).Item(7) = "Išskaič. PSD"
            result.Rows(4 * MonthCount + 8).Item(8) = "Išskaič. PSD nedarb."
            result.Rows(4 * MonthCount + 8).Item(9) = "DU po mokesč."
            result.Rows(4 * MonthCount + 8).Item(10) = "Išsk. kitos"
            result.Rows(5 * MonthCount + 10).Item(0) = "Metai"
            result.Rows(5 * MonthCount + 10).Item(1) = "Mėnuo"
            result.Rows(5 * MonthCount + 10).Item(2) = "Tar. SODRA darbdav."
            result.Rows(5 * MonthCount + 10).Item(3) = "Priskaič. SODRA"
            result.Rows(5 * MonthCount + 10).Item(4) = "Tar. PSD darbdav."
            result.Rows(5 * MonthCount + 10).Item(5) = "Priskaič. PSD"
            result.Rows(5 * MonthCount + 10).Item(6) = "Tar. gar. fondo"
            result.Rows(5 * MonthCount + 10).Item(7) = "Priskaič. gar. fondo"
            result.Rows(5 * MonthCount + 10).Item(8) = "DU mokėtinas"
            result.Rows(5 * MonthCount + 10).Item(9) = "DU išmokėta"
            result.Rows(5 * MonthCount + 10).Item(10) = "DU skola"
            result.Rows(MonthCount + 1).Item(0) = "IŠ VISO:"
            result.Rows(2 * MonthCount + 3).Item(0) = "IŠ VISO:"
            result.Rows(3 * MonthCount + 5).Item(0) = "IŠ VISO:"
            result.Rows(4 * MonthCount + 7).Item(0) = "IŠ VISO:"
            result.Rows(5 * MonthCount + 9).Item(0) = "IŠ VISO:"
            result.Rows(6 * MonthCount + 11).Item(0) = "IŠ VISO:"

            Dim cYear, cMonth As Integer
            For i = 1 To MonthCount
                cYear = _DateFrom.Date.AddMonths(i - 1).Year
                cMonth = _DateFrom.Date.AddMonths(i - 1).Month
                result.Rows(i).Item(0) = cYear
                result.Rows(i).Item(1) = cMonth
                result.Rows(i + MonthCount + 2).Item(0) = cYear
                result.Rows(i + MonthCount + 2).Item(1) = cMonth
                result.Rows(i + 2 * MonthCount + 4).Item(0) = cYear
                result.Rows(i + 2 * MonthCount + 4).Item(1) = cMonth
                result.Rows(i + 3 * MonthCount + 6).Item(0) = cYear
                result.Rows(i + 3 * MonthCount + 6).Item(1) = cMonth
                result.Rows(i + 4 * MonthCount + 8).Item(0) = cYear
                result.Rows(i + 4 * MonthCount + 8).Item(1) = cMonth
                result.Rows(i + 5 * MonthCount + 10).Item(0) = cYear
                result.Rows(i + 5 * MonthCount + 10).Item(1) = cMonth
            Next

            For j = 1 To 9
                result.Rows(1 + MonthCount).Item(j + 1) = 0
                result.Rows(1 + 2 * MonthCount + 2).Item(j + 1) = 0
                result.Rows(1 + 3 * MonthCount + 4).Item(j + 1) = 0
                result.Rows(1 + 4 * MonthCount + 6).Item(j + 1) = 0
                result.Rows(1 + 5 * MonthCount + 8).Item(j + 1) = 0
                result.Rows(1 + 6 * MonthCount + 10).Item(j + 1) = 0
            Next



            Dim ci As WorkerWageInfo
            For i = 1 To MonthCount
                ci = GetWageInfoByYearMonth(CInt(result.Rows(i).Item(0)), CInt(result.Rows(i).Item(1)))

                If Not ci Is Nothing Then
                    result.Rows(i).Item(2) = DblParser(ci.WorkLoad, 4)
                    result.Rows(i).Item(3) = DblParser(ci.NormalHoursWorked, 4)
                    result.Rows(MonthCount + 1).Item(3) = CDbl(result.Rows(MonthCount + 1).Item(3)) + _
                        ci.NormalHoursWorked
                    result.Rows(i).Item(4) = DblParser(ci.HRHoursWorked, 4)
                    result.Rows(MonthCount + 1).Item(4) = CDbl(result.Rows(MonthCount + 1).Item(4)) + _
                        ci.HRHoursWorked
                    result.Rows(i).Item(5) = DblParser(ci.ONHoursWorked, 4)
                    result.Rows(MonthCount + 1).Item(5) = CDbl(result.Rows(MonthCount + 1).Item(5)) + _
                        ci.ONHoursWorked
                    result.Rows(i).Item(6) = DblParser(ci.SCHoursWorked, 4)
                    result.Rows(MonthCount + 1).Item(6) = CDbl(result.Rows(MonthCount + 1).Item(6)) + _
                        ci.SCHoursWorked
                    result.Rows(i).Item(7) = DblParser(ci.TotalHoursWorked, 4)
                    result.Rows(MonthCount + 1).Item(7) = CDbl(result.Rows(MonthCount + 1).Item(7)) + _
                        ci.TotalHoursWorked
                    result.Rows(i).Item(8) = DblParser(ci.TruancyHours, 4)
                    result.Rows(MonthCount + 1).Item(8) = CDbl(result.Rows(MonthCount + 1).Item(8)) + _
                        ci.TruancyHours
                    result.Rows(i).Item(9) = ci.TotalDaysWorked
                    result.Rows(MonthCount + 1).Item(9) = CDbl(result.Rows(MonthCount + 1).Item(9)) + _
                        ci.TotalDaysWorked
                    result.Rows(i).Item(10) = ci.SickDays
                    result.Rows(MonthCount + 1).Item(10) = CDbl(result.Rows(MonthCount + 1).Item(10)) + _
                        ci.SickDays
                    result.Rows(i + MonthCount + 2).Item(2) = ci.HolidayWD
                    result.Rows(2 * MonthCount + 3).Item(2) = _
                        CDbl(result.Rows(2 * MonthCount + 3).Item(2)) + ci.HolidayWD
                    result.Rows(i + MonthCount + 2).Item(3) = ci.HolidayRD
                    result.Rows(2 * MonthCount + 3).Item(3) = _
                        CDbl(result.Rows(2 * MonthCount + 3).Item(3)) + ci.HolidayRD
                    result.Rows(i + MonthCount + 2).Item(4) = DblParser(ci.UnusedHolidayDaysForCompensation)
                    result.Rows(2 * MonthCount + 3).Item(4) = _
                        CDbl(result.Rows(2 * MonthCount + 3).Item(4)) + ci.UnusedHolidayDaysForCompensation
                    result.Rows(i + MonthCount + 2).Item(5) = DblParser(ci.StandartHours)
                    result.Rows(2 * MonthCount + 3).Item(5) = _
                        CDbl(result.Rows(2 * MonthCount + 3).Item(5)) + ci.StandartHours
                    result.Rows(i + MonthCount + 2).Item(6) = ci.StandartDays
                    result.Rows(2 * MonthCount + 3).Item(6) = _
                        CDbl(result.Rows(2 * MonthCount + 3).Item(6)) + ci.StandartDays
                    result.Rows(i + MonthCount + 2).Item(7) = DblParser(ci.RateHR)
                    result.Rows(i + MonthCount + 2).Item(8) = DblParser(ci.RateON)
                    result.Rows(i + MonthCount + 2).Item(9) = DblParser(ci.RateSC)
                    result.Rows(i + MonthCount + 2).Item(10) = DblParser(ci.RateSickLeave)
                    result.Rows(i + 2 * MonthCount + 4).Item(2) = DblParser(ci.ConventionalWage)
                    result.Rows(i + 2 * MonthCount + 4).Item(3) = ci.WageTypeHumanReadable
                    result.Rows(i + 2 * MonthCount + 4).Item(4) = DblParser(ci.ConventionalExtraPay)
                    result.Rows(i + 2 * MonthCount + 4).Item(5) = DblParser(ci.PayOutWage)
                    result.Rows(3 * MonthCount + 5).Item(5) = _
                        CDbl(result.Rows(3 * MonthCount + 5).Item(5)) + ci.PayOutWage
                    result.Rows(i + 2 * MonthCount + 4).Item(6) = DblParser(ci.PayOutExtraPay)
                    result.Rows(3 * MonthCount + 5).Item(6) = _
                        CDbl(result.Rows(3 * MonthCount + 5).Item(6)) + ci.PayOutExtraPay
                    result.Rows(i + 2 * MonthCount + 4).Item(7) = DblParser(ci.PayOutHR)
                    result.Rows(3 * MonthCount + 5).Item(7) = _
                        CDbl(result.Rows(3 * MonthCount + 5).Item(7)) + ci.PayOutHR
                    result.Rows(i + 2 * MonthCount + 4).Item(8) = DblParser(ci.PayOutON)
                    result.Rows(3 * MonthCount + 5).Item(8) = _
                        CDbl(result.Rows(3 * MonthCount + 5).Item(8)) + ci.PayOutON
                    result.Rows(i + 2 * MonthCount + 4).Item(9) = DblParser(ci.PayOutSC)
                    result.Rows(3 * MonthCount + 5).Item(9) = _
                        CDbl(result.Rows(3 * MonthCount + 5).Item(9)) + ci.PayOutSC
                    result.Rows(i + 2 * MonthCount + 4).Item(10) = DblParser(ci.BonusPayQuarterly)
                    result.Rows(3 * MonthCount + 5).Item(10) = _
                        CDbl(result.Rows(3 * MonthCount + 5).Item(10)) + ci.BonusPayQuarterly
                    result.Rows(i + 3 * MonthCount + 6).Item(2) = DblParser(ci.OtherPayRelatedToWork)
                    result.Rows(4 * MonthCount + 7).Item(2) = _
                        CDbl(result.Rows(4 * MonthCount + 7).Item(2)) + ci.OtherPayRelatedToWork
                    result.Rows(i + 3 * MonthCount + 6).Item(3) = DblParser(ci.OtherPayNotRelatedToWork)
                    result.Rows(4 * MonthCount + 7).Item(3) = _
                        CDbl(result.Rows(4 * MonthCount + 7).Item(3)) + ci.OtherPayNotRelatedToWork
                    result.Rows(i + 3 * MonthCount + 6).Item(4) = DblParser(ci.PayOutHoliday)
                    result.Rows(4 * MonthCount + 7).Item(4) = _
                        CDbl(result.Rows(4 * MonthCount + 7).Item(4)) + ci.PayOutHoliday
                    result.Rows(i + 3 * MonthCount + 6).Item(5) = DblParser(ci.PayOutUnusedHolidayCompensation)
                    result.Rows(4 * MonthCount + 7).Item(5) = _
                        CDbl(result.Rows(4 * MonthCount + 7).Item(5)) + ci.PayOutUnusedHolidayCompensation
                    result.Rows(i + 3 * MonthCount + 6).Item(6) = DblParser(ci.PayOutRedundancyPay)
                    result.Rows(4 * MonthCount + 7).Item(6) = _
                        CDbl(result.Rows(4 * MonthCount + 7).Item(6)) + ci.PayOutRedundancyPay
                    result.Rows(i + 3 * MonthCount + 6).Item(7) = DblParser(ci.PayOutSickLeave)
                    result.Rows(4 * MonthCount + 7).Item(7) = _
                        CDbl(result.Rows(4 * MonthCount + 7).Item(7)) + ci.PayOutSickLeave
                    result.Rows(i + 3 * MonthCount + 6).Item(8) = DblParser(ci.PayOutTotal)
                    result.Rows(4 * MonthCount + 7).Item(8) = _
                        CDbl(result.Rows(4 * MonthCount + 7).Item(8)) + ci.PayOutTotal
                    result.Rows(i + 3 * MonthCount + 6).Item(9) = DblParser(ci.RateSODRAEmployee)
                    result.Rows(i + 3 * MonthCount + 6).Item(10) = DblParser(ci.DeductionSODRA)
                    result.Rows(4 * MonthCount + 7).Item(10) = _
                        CDbl(result.Rows(4 * MonthCount + 7).Item(10)) + ci.DeductionSODRA
                    result.Rows(i + 4 * MonthCount + 8).Item(2) = DblParser(ci.RateGPM)
                    result.Rows(i + 4 * MonthCount + 8).Item(3) = DblParser(ci.NPD)
                    result.Rows(5 * MonthCount + 9).Item(3) = _
                        CDbl(result.Rows(5 * MonthCount + 9).Item(3)) + ci.NPD
                    result.Rows(i + 4 * MonthCount + 8).Item(4) = DblParser(ci.PNPD)
                    result.Rows(5 * MonthCount + 9).Item(4) = _
                        CDbl(result.Rows(5 * MonthCount + 9).Item(4)) + ci.PNPD
                    result.Rows(i + 4 * MonthCount + 8).Item(5) = DblParser(ci.DeductionGPM)
                    result.Rows(5 * MonthCount + 9).Item(5) = _
                        CDbl(result.Rows(5 * MonthCount + 9).Item(5)) + ci.DeductionGPM
                    result.Rows(i + 4 * MonthCount + 8).Item(6) = DblParser(ci.RatePSDEmployee)
                    result.Rows(i + 4 * MonthCount + 8).Item(7) = DblParser(ci.DeductionPSD)
                    result.Rows(5 * MonthCount + 9).Item(7) = _
                        CDbl(result.Rows(5 * MonthCount + 9).Item(7)) + ci.DeductionPSD
                    result.Rows(i + 4 * MonthCount + 8).Item(8) = DblParser(ci.DeductionPSDSickLeave)
                    result.Rows(5 * MonthCount + 9).Item(8) = _
                        CDbl(result.Rows(5 * MonthCount + 9).Item(8)) + ci.DeductionPSDSickLeave
                    result.Rows(i + 4 * MonthCount + 8).Item(9) = DblParser(0)
                    result.Rows(5 * MonthCount + 9).Item(9) = _
                        CDbl(result.Rows(5 * MonthCount + 9).Item(9)) + 0
                    result.Rows(i + 4 * MonthCount + 8).Item(10) = DblParser(ci.DeductionOther)
                    result.Rows(5 * MonthCount + 9).Item(10) = _
                        CDbl(result.Rows(5 * MonthCount + 9).Item(10)) + ci.DeductionOther
                    result.Rows(i + 5 * MonthCount + 10).Item(2) = DblParser(ci.RateSODRAEmployer)
                    result.Rows(i + 5 * MonthCount + 10).Item(3) = DblParser(ci.ContributionSODRA)
                    result.Rows(6 * MonthCount + 11).Item(3) = _
                        CDbl(result.Rows(6 * MonthCount + 11).Item(3)) + ci.ContributionSODRA
                    result.Rows(i + 5 * MonthCount + 10).Item(4) = DblParser(ci.RatePSDEmployer)
                    result.Rows(i + 5 * MonthCount + 10).Item(5) = DblParser(ci.ContributionPSD)
                    result.Rows(6 * MonthCount + 11).Item(5) = _
                        CDbl(result.Rows(6 * MonthCount + 11).Item(5)) + ci.ContributionPSD
                    result.Rows(i + 5 * MonthCount + 10).Item(6) = DblParser(ci.RateGuaranteeFund)
                    result.Rows(i + 5 * MonthCount + 10).Item(7) = DblParser(ci.ContributionGuaranteeFund)
                    result.Rows(6 * MonthCount + 11).Item(7) = _
                        CDbl(result.Rows(6 * MonthCount + 11).Item(7)) + ci.ContributionGuaranteeFund
                    result.Rows(i + 5 * MonthCount + 10).Item(8) = DblParser(ci.PayableTotal)
                    result.Rows(6 * MonthCount + 11).Item(8) = _
                        CDbl(result.Rows(6 * MonthCount + 11).Item(8)) + ci.PayableTotal
                    result.Rows(i + 5 * MonthCount + 10).Item(9) = DblParser(ci.PayedOutTotalSum)
                    result.Rows(6 * MonthCount + 11).Item(9) = _
                        CDbl(result.Rows(6 * MonthCount + 11).Item(9)) + ci.PayedOutTotalSum
                    If i = 1 Then
                        result.Rows(i + 5 * MonthCount + 10).Item(10) = CRound(_DebtAtTheStart + _
                            ci.PayableTotal - ci.PayedOutTotalSum)
                    Else
                        result.Rows(i + 5 * MonthCount + 10).Item(10) = CRound( _
                            CDbl(result.Rows(i + 5 * MonthCount + 9).Item(10)) + _
                            ci.PayableTotal - ci.PayedOutTotalSum)
                        result.Rows(i + 5 * MonthCount + 9).Item(10) = _
                            DblParser(CDbl(result.Rows(i + 5 * MonthCount + 9).Item(10)))
                    End If
                    If i = MonthCount Then
                        result.Rows(i + 5 * MonthCount + 10).Item(10) = _
                            DblParser(CDbl(result.Rows(i + 5 * MonthCount + 10).Item(10)))
                    End If

                Else
                    result.Rows(i).Item(2) = DblParser(0, 4)
                    result.Rows(i).Item(3) = DblParser(0, 4)
                    result.Rows(i).Item(4) = DblParser(0, 4)
                    result.Rows(i).Item(5) = DblParser(0, 4)
                    result.Rows(i).Item(6) = DblParser(0, 4)
                    result.Rows(i).Item(7) = DblParser(0, 4)
                    result.Rows(i).Item(8) = DblParser(0, 4)
                    result.Rows(i).Item(9) = 0
                    result.Rows(i).Item(10) = 0
                    result.Rows(i + MonthCount + 2).Item(2) = 0
                    result.Rows(i + MonthCount + 2).Item(3) = 0
                    result.Rows(i + MonthCount + 2).Item(4) = DblParser(0)
                    result.Rows(i + MonthCount + 2).Item(5) = DblParser(0)
                    result.Rows(i + MonthCount + 2).Item(6) = 0
                    result.Rows(i + MonthCount + 2).Item(7) = DblParser(0)
                    result.Rows(i + MonthCount + 2).Item(8) = DblParser(0)
                    result.Rows(i + MonthCount + 2).Item(9) = DblParser(0)
                    result.Rows(i + MonthCount + 2).Item(10) = DblParser(0)
                    result.Rows(i + 2 * MonthCount + 4).Item(2) = DblParser(0)
                    result.Rows(i + 2 * MonthCount + 4).Item(3) = ""
                    result.Rows(i + 2 * MonthCount + 4).Item(4) = DblParser(0)
                    result.Rows(i + 2 * MonthCount + 4).Item(5) = DblParser(0)
                    result.Rows(i + 2 * MonthCount + 4).Item(6) = DblParser(0)
                    result.Rows(i + 2 * MonthCount + 4).Item(7) = DblParser(0)
                    result.Rows(i + 2 * MonthCount + 4).Item(8) = DblParser(0)
                    result.Rows(i + 2 * MonthCount + 4).Item(9) = DblParser(0)
                    result.Rows(i + 2 * MonthCount + 4).Item(10) = DblParser(0)
                    result.Rows(i + 3 * MonthCount + 6).Item(2) = DblParser(0)
                    result.Rows(i + 3 * MonthCount + 6).Item(3) = DblParser(0)
                    result.Rows(i + 3 * MonthCount + 6).Item(4) = DblParser(0)
                    result.Rows(i + 3 * MonthCount + 6).Item(5) = DblParser(0)
                    result.Rows(i + 3 * MonthCount + 6).Item(6) = DblParser(0)
                    result.Rows(i + 3 * MonthCount + 6).Item(7) = DblParser(0)
                    result.Rows(i + 3 * MonthCount + 6).Item(8) = DblParser(0)
                    result.Rows(i + 3 * MonthCount + 6).Item(9) = DblParser(0)
                    result.Rows(i + 3 * MonthCount + 6).Item(10) = DblParser(0)
                    result.Rows(i + 4 * MonthCount + 8).Item(2) = DblParser(0)
                    result.Rows(i + 4 * MonthCount + 8).Item(3) = DblParser(0)
                    result.Rows(i + 4 * MonthCount + 8).Item(4) = DblParser(0)
                    result.Rows(i + 4 * MonthCount + 8).Item(5) = DblParser(0)
                    result.Rows(i + 4 * MonthCount + 8).Item(6) = DblParser(0)
                    result.Rows(i + 4 * MonthCount + 8).Item(7) = DblParser(0)
                    result.Rows(i + 4 * MonthCount + 8).Item(8) = DblParser(0)
                    result.Rows(i + 4 * MonthCount + 8).Item(9) = DblParser(0)
                    result.Rows(i + 4 * MonthCount + 8).Item(10) = DblParser(0)
                    result.Rows(i + 5 * MonthCount + 10).Item(2) = DblParser(0)
                    result.Rows(i + 5 * MonthCount + 10).Item(3) = DblParser(0)
                    result.Rows(i + 5 * MonthCount + 10).Item(4) = DblParser(0)
                    result.Rows(i + 5 * MonthCount + 10).Item(5) = DblParser(0)
                    result.Rows(i + 5 * MonthCount + 10).Item(6) = DblParser(0)
                    result.Rows(i + 5 * MonthCount + 10).Item(7) = DblParser(0)
                    result.Rows(i + 5 * MonthCount + 10).Item(8) = DblParser(0)
                    result.Rows(i + 5 * MonthCount + 10).Item(9) = DblParser(0)
                    If i = 1 Then
                        result.Rows(i + 5 * MonthCount + 10).Item(10) = CRound(_DebtAtTheStart)
                    Else
                        result.Rows(i + 5 * MonthCount + 10).Item(10) = CRound( _
                            CDbl(result.Rows(i + 5 * MonthCount + 9).Item(10)))
                        result.Rows(i + 5 * MonthCount + 9).Item(10) = _
                            DblParser(CDbl(result.Rows(i + 5 * MonthCount + 9).Item(10)))
                    End If
                    If i = MonthCount Then
                        result.Rows(i + 5 * MonthCount + 10).Item(10) = _
                            DblParser(CDbl(result.Rows(i + 5 * MonthCount + 10).Item(10)))
                    End If

                End If

            Next


            For j = 1 To 9
                If CRound(CDbl(result.Rows(MonthCount + 1).Item(j + 1)), 4) > 0 Then
                    If j > 7 Then
                        result.Rows(MonthCount + 1).Item(j + 1) = _
                            CInt(result.Rows(MonthCount + 1).Item(j + 1))
                    Else
                        result.Rows(MonthCount + 1).Item(j + 1) = _
                            DblParser(CDbl(result.Rows(MonthCount + 1).Item(j + 1)), 4)
                    End If
                Else
                    result.Rows(MonthCount + 1).Item(j + 1) = ""
                End If
                If CRound(CDbl(result.Rows(2 * MonthCount + 3).Item(j + 1)), 4) > 0 Then
                    If j = 3 Then
                        result.Rows(2 * MonthCount + 3).Item(j + 1) = _
                            DblParser(CDbl(result.Rows(2 * MonthCount + 3).Item(j + 1)), 2)
                    ElseIf j = 4 Then
                        result.Rows(2 * MonthCount + 3).Item(j + 1) = _
                            DblParser(CDbl(result.Rows(2 * MonthCount + 3).Item(j + 1)), 4)
                    ElseIf j < 6 Then
                        result.Rows(2 * MonthCount + 3).Item(j + 1) = _
                            CInt(result.Rows(2 * MonthCount + 3).Item(j + 1))
                    Else
                        result.Rows(2 * MonthCount + 3).Item(j + 1) = ""
                    End If
                Else
                    result.Rows(2 * MonthCount + 3).Item(j + 1) = ""
                End If
                If CRound(CDbl(result.Rows(3 * MonthCount + 5).Item(j + 1)), 4) > 0 Then
                    result.Rows(3 * MonthCount + 5).Item(j + 1) = _
                        DblParser(CDbl(result.Rows(3 * MonthCount + 5).Item(j + 1)))
                Else
                    result.Rows(3 * MonthCount + 5).Item(j + 1) = ""
                End If
                If CRound(CDbl(result.Rows(4 * MonthCount + 7).Item(j + 1)), 4) > 0 Then
                    result.Rows(4 * MonthCount + 7).Item(j + 1) = _
                        DblParser(CDbl(result.Rows(4 * MonthCount + 7).Item(j + 1)))
                Else
                    result.Rows(4 * MonthCount + 7).Item(j + 1) = ""
                End If
                If CRound(CDbl(result.Rows(5 * MonthCount + 9).Item(j + 1)), 4) > 0 Then
                    result.Rows(5 * MonthCount + 9).Item(j + 1) = _
                        DblParser(CDbl(result.Rows(5 * MonthCount + 9).Item(j + 1)))
                Else
                    result.Rows(5 * MonthCount + 9).Item(j + 1) = ""
                End If
                If CRound(CDbl(result.Rows(6 * MonthCount + 11).Item(j + 1)), 4) > 0 Then
                    result.Rows(6 * MonthCount + 11).Item(j + 1) = _
                        DblParser(CDbl(result.Rows(6 * MonthCount + 11).Item(j + 1)))
                Else
                    result.Rows(6 * MonthCount + 11).Item(j + 1) = ""
                End If
            Next

            Return result

        End Function

        Private Function GetWageInfoByYearMonth(ByVal nYear As Integer, ByVal nMonth As Integer) As WorkerWageInfo
            For Each item As WorkerWageInfo In _Items
                If item.Year = nYear AndAlso item.Month = nMonth Then Return item
            Next
            Return Nothing
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _PersonID
        End Function

        Public Overrides Function ToString() As String
            If _IsConsolidated Then Return "Darbuotojo " & _PersonInfo _
                & " konsoliduota darbo užmokesčio kortelė"
            Return "Darbuotojo " & _PersonInfo & " darbo užmokesčio kortelė pgl. " _
                & "darbo sutartį Nr. " & _ContractSerial & _ContractNumber.ToString
        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.WageInfo1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetWorkerWageInfoReport(ByVal dateFrom As Date, _
            ByVal dateTo As Date, ByVal personID As Integer, ByVal contractSerial As String, _
            ByVal contractNumber As Integer, ByVal fetchConsolidatedInfo As Boolean, _
            ByVal personInfo As String) As WorkerWageInfoReport

            Return DataPortal.Fetch(Of WorkerWageInfoReport)(New Criteria(dateFrom, dateTo, personID, _
                contractSerial, contractNumber, fetchConsolidatedInfo, personInfo))

        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _DateFrom As Date
            Private _DateTo As Date
            Private _FetchConsolidatedInfo As Boolean
            Private _ContractNumber As Integer
            Private _ContractSerial As String
            Private _PersonID As Integer
            Private _PersonInfo As String
            Public ReadOnly Property ContractSerial() As String
                Get
                    Return _ContractSerial
                End Get
            End Property
            Public ReadOnly Property ContractNumber() As Integer
                Get
                    Return _ContractNumber
                End Get
            End Property
            Public ReadOnly Property PersonID() As Integer
                Get
                    Return _PersonID
                End Get
            End Property
            Public ReadOnly Property PersonInfo() As String
                Get
                    Return _PersonInfo
                End Get
            End Property
            Public ReadOnly Property DateFrom() As Date
                Get
                    Return _DateFrom
                End Get
            End Property
            Public ReadOnly Property DateTo() As Date
                Get
                    Return _DateTo
                End Get
            End Property
            Public ReadOnly Property FetchConsolidatedInfo() As Boolean
                Get
                    Return _FetchConsolidatedInfo
                End Get
            End Property
            Public Sub New(ByVal nDateFrom As Date, ByVal nDateTo As Date, ByVal nPersonID As Integer, _
                ByVal nContractSerial As String, ByVal nContractNumber As Integer, _
                ByVal nFetchConsolidatedInfo As Boolean, ByVal nPersonInfo As String)
                _DateFrom = nDateFrom
                _DateTo = nDateTo
                _PersonID = nPersonID
                _ContractSerial = nContractSerial
                _ContractNumber = nContractNumber
                _FetchConsolidatedInfo = nFetchConsolidatedInfo
                _PersonInfo = nPersonInfo
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As New SQLCommand("FetchWorkerWagePayable")
            myComm.AddParam("?MF", criteria.DateFrom.Month)
            myComm.AddParam("?YF", criteria.DateFrom.Year)
            myComm.AddParam("?MT", criteria.DateTo.Month)
            myComm.AddParam("?YT", criteria.DateTo.Year)
            If criteria.FetchConsolidatedInfo Then
                myComm.AddParam("?PD", criteria.PersonID)
            Else
                myComm.AddParam("?PD", 0)
            End If
            myComm.AddParam("?CS", criteria.ContractSerial.Trim)
            myComm.AddParam("?CN", criteria.ContractNumber)

            Using myData As DataTable = myComm.Fetch

                myComm = New SQLCommand("FetchWorkerWagePayments")
                myComm.AddParam("?MF", criteria.DateFrom.Month)
                myComm.AddParam("?YF", criteria.DateFrom.Year)
                myComm.AddParam("?PD", criteria.PersonID)
                myComm.AddParam("?CS", criteria.ContractSerial.Trim)
                myComm.AddParam("?CN", criteria.ContractNumber)
                myComm.AddParam("?DF", criteria.DateFrom)
                myComm.AddParam("?DT", criteria.DateTo)

                Using paymentsData As DataTable = myComm.Fetch()

                    _Items = WorkerWageInfoList.GetWorkerWageInfoList(myData, paymentsData)

                    Dim dr As DataRow = WorkerWageInfoList.GetRowByMonth(0, 0, paymentsData)
                    If Not dr Is Nothing Then
                        _DebtAtTheStart = CRound(CDblSafe(dr.Item(3), 2, 0) _
                            - CDblSafe(dr.Item(2), 2, 0), 2)
                    End If

                End Using

            End Using

            _DebtAtEnd = CRound(_DebtAtTheStart + _Items.GetTotalSumPayable - _Items.GetTotalSumPayed)

            If criteria.FetchConsolidatedInfo Then
                _UnusedHolidaysAtStart = 0
                _UnusedHolidaysAtEnd = 0
            Else
                Dim holidaysAtStart As WorkerHolidayInfo = WorkerHolidayInfo.GetWorkerHolidayInfoChild( _
                    criteria.DateFrom, criteria.ContractSerial, criteria.ContractNumber, False)
                _UnusedHolidaysAtStart = holidaysAtStart.TotalUnusedHolidayDays
                Dim holidaysAtEnd As WorkerHolidayInfo = WorkerHolidayInfo.GetWorkerHolidayInfoChild( _
                    criteria.DateTo, criteria.ContractSerial, criteria.ContractNumber, False)
                _UnusedHolidaysAtEnd = holidaysAtEnd.TotalUnusedHolidayDays
            End If

            _DateFrom = criteria.DateFrom
            _DateTo = criteria.DateTo
            _ContractNumber = criteria.ContractNumber
            _ContractSerial = criteria.ContractSerial
            _IsConsolidated = criteria.FetchConsolidatedInfo
            _PersonID = criteria.PersonID
            _PersonInfo = criteria.PersonInfo

        End Sub

#End Region

    End Class

End Namespace