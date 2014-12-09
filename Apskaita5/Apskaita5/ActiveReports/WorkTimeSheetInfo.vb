Namespace ActiveReports

    <Serializable()> _
    Public Class WorkTimeSheetInfo
        Inherits ReadOnlyBase(Of WorkTimeSheetInfo)

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _Date As Date = Today
        Private _Year As Integer = 0
        Private _Month As Integer = 0
        Private _SubDivision As String = ""
        Private _WorkersCount As Integer = 0
        Private _TotalWorkDays As Integer = 0
        Private _TotalWorkTime As Double = 0
        Private _NightWork As Double = 0
        Private _OvertimeWork As Double = 0
        Private _PublicHolidaysAndRestDayWork As Double = 0
        Private _UnusualWork As Double = 0
        Private _Truancy As Double = 0
        Private _DownTime As Double = 0
        Private _SickDays As Integer = 0
        Private _AnnualHolidays As Integer = 0
        Private _OtherHolidays As Integer = 0
        Private _OtherIncluded As Double = 0
        Private _OtherExcluded As Double = 0


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        Public ReadOnly Property Year() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Year
            End Get
        End Property

        Public ReadOnly Property Month() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Month
            End Get
        End Property

        Public ReadOnly Property SubDivision() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SubDivision.Trim
            End Get
        End Property

        Public ReadOnly Property WorkersCount() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WorkersCount
            End Get
        End Property

        Public ReadOnly Property TotalWorkDays() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TotalWorkDays
            End Get
        End Property

        Public ReadOnly Property TotalWorkTime() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalWorkTime, ROUNDWORKTIME)
            End Get
        End Property

        Public ReadOnly Property NightWork() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_NightWork, ROUNDWORKTIME)
            End Get
        End Property

        Public ReadOnly Property OvertimeWork() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OvertimeWork, ROUNDWORKTIME)
            End Get
        End Property

        Public ReadOnly Property PublicHolidaysAndRestDayWork() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PublicHolidaysAndRestDayWork, ROUNDWORKTIME)
            End Get
        End Property

        Public ReadOnly Property UnusualWork() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnusualWork, ROUNDWORKTIME)
            End Get
        End Property

        Public ReadOnly Property Truancy() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Truancy, ROUNDWORKTIME)
            End Get
        End Property

        Public ReadOnly Property DownTime() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DownTime, ROUNDWORKTIME)
            End Get
        End Property

        Public ReadOnly Property SickDays() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SickDays
            End Get
        End Property

        Public ReadOnly Property AnnualHolidays() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AnnualHolidays
            End Get
        End Property

        Public ReadOnly Property OtherHolidays() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OtherHolidays
            End Get
        End Property

        Public ReadOnly Property OtherIncluded() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OtherIncluded, ROUNDWORKTIME)
            End Get
        End Property

        Public ReadOnly Property OtherExcluded() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OtherExcluded, ROUNDWORKTIME)
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return "Darbo laiko apskaitos žiniaraštis už " & _Year.ToString _
                & " metų " & _Month.ToString & " mėnesį"
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function GetWorkTimeSheetInfo(ByVal dr As DataRow) As WorkTimeSheetInfo
            Return New WorkTimeSheetInfo(dr)
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal dr As DataRow)
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow)

            _ID = CIntSafe(dr.item(0), 0)
            _Date = CDateSafe(dr.Item(1), Today)
            _Year = CIntSafe(dr.Item(2), 0)
            _Month = CIntSafe(dr.Item(3), 0)
            _SubDivision = CStrSafe(dr.Item(4)).Trim
            _WorkersCount = CIntSafe(dr.Item(5), 0)
            _TotalWorkDays = CIntSafe(dr.Item(6), 0)
            _TotalWorkTime = CDblSafe(dr.Item(7), ROUNDWORKTIME, 0)
            _NightWork = CDblSafe(dr.Item(8), ROUNDWORKTIME, 0)
            _OvertimeWork = CDblSafe(dr.Item(9), ROUNDWORKTIME, 0)
            _PublicHolidaysAndRestDayWork = CDblSafe(dr.Item(10), ROUNDWORKTIME, 0)
            _UnusualWork = CDblSafe(dr.Item(11), ROUNDWORKTIME, 0)
            _Truancy = CDblSafe(dr.Item(12), ROUNDWORKTIME, 0)
            _DownTime = CDblSafe(dr.Item(13), ROUNDWORKTIME, 0)
            _OtherExcluded = CDblSafe(dr.Item(14), ROUNDWORKTIME, 0)
            _OtherIncluded = CDblSafe(dr.Item(15), ROUNDWORKTIME, 0)
            _SickDays = CIntSafe(dr.Item(16), 0)
            _AnnualHolidays = CIntSafe(dr.Item(17), 0)
            _OtherHolidays = CIntSafe(dr.Item(18), 0)

        End Sub

#End Region

    End Class

End Namespace