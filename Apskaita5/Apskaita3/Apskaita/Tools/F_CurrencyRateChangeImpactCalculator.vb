Imports Csla
Imports ApskaitaObjects
Public Class F_CurrencyRateChangeImpactCalculator

    <Serializable()> _
Public Class CurrencyRateCalculationItem
        Inherits BusinessBase(Of CurrencyRateCalculationItem)

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _Date As Date = Today
        Private _Sum As Double = 0
        Private _CurrencyCode As String = GetCurrentCompany.BaseCurrency
        Private _CurrencyRateStart As Double = 0
        Private _SumLTLStart As Double = 0
        Private _CurrencyRateEnd As Double = 0
        Private _SumLTLEnd As Double = 0
        Private _CurrencyRateChangeImpact As Double = 0


        Public Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                If _Date.Date <> value.Date Then
                    _Date = value.Date
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Sum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Sum)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If CRound(_Sum) <> CRound(value) Then
                    _Sum = CRound(value)
                    PropertyHasChanged()
                    Recalculate()
                End If
            End Set
        End Property

        Public Property CurrencyCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrencyCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _CurrencyCode.Trim <> value.Trim Then
                    _CurrencyCode = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property CurrencyRateStart() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRateStart, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If CRound(_CurrencyRateStart, 6) <> CRound(value, 6) Then
                    _CurrencyRateStart = CRound(value, 6)
                    PropertyHasChanged()
                    Recalculate()
                End If
            End Set
        End Property

        Public ReadOnly Property SumLTLStart() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumLTLStart)
            End Get
        End Property

        Public Property CurrencyRateEnd() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRateEnd, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If CRound(_CurrencyRateEnd, 6) <> CRound(value, 6) Then
                    _CurrencyRateEnd = CRound(value, 6)
                    PropertyHasChanged()
                    Recalculate()
                End If
            End Set
        End Property

        Public ReadOnly Property SumLTLEnd() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumLTLEnd)
            End Get
        End Property

        Public ReadOnly Property CurrencyRateChangeImpact() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRateChangeImpact)
            End Get
        End Property


        Private Sub Recalculate()
            _SumLTLStart = CRound(CRound(_Sum) * CRound(_CurrencyRateStart, 6))
            _SumLTLEnd = CRound(CRound(_Sum) * CRound(_CurrencyRateEnd, 6))
            _CurrencyRateChangeImpact = CRound(_SumLTLEnd - _SumLTLStart)
            PropertyHasChanged("SumLTLStart")
            PropertyHasChanged("SumLTLEnd")
            PropertyHasChanged("CurrencyRateChangeImpact")
        End Sub

        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return ""
        End Function

#End Region

#Region " Factory Methods "

        Public Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

#End Region

    End Class

    Private WithEvents Obj As New System.ComponentModel.BindingList(Of CurrencyRateCalculationItem)
    Private SuspendCalculations As Boolean = False


    Private Sub F_CurrencyRateChangeImpactCalculator_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GetFormLayout(Me)
        GetDataGridViewLayOut(F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView)
    End Sub

    Private Sub F_CurrencyRateChangeImpactCalculator_Load(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Load

        LoadCurrencyCodeListToComboBox(DataGridViewTextBoxColumn3, False)

        Obj.AllowEdit = True
        Obj.AllowNew = True
        Obj.AllowRemove = True
        F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemBindingSource.DataSource = Obj

        SetDataGridViewLayOut(F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView)
        SetFormLayout(Me)

    End Sub

    Private Sub Obj_ListChanged(ByVal sender As Object, _
        ByVal e As System.ComponentModel.ListChangedEventArgs) Handles Obj.ListChanged

        If SuspendCalculations Then Exit Sub

        Dim SumStart As Double = 0
        Dim SumEnd As Double = 0
        Dim SumDifference As Double = 0

        For Each i As CurrencyRateCalculationItem In Obj
            SumStart = CRound(SumStart + i.SumLTLStart)
            SumEnd = CRound(SumEnd + i.SumLTLEnd)
            SumDifference = CRound(SumDifference + i.CurrencyRateChangeImpact)
        Next

        SumStartAccTextBox.DecimalValue = SumStart
        SumEndAccTextBox.DecimalValue = SumEnd
        CurrencyRateChangeImpactAccTextBox.DecimalValue = SumDifference

    End Sub

    Private Sub GetCurrencyRatesButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles GetCurrencyRatesButton.Click

        If Obj Is Nothing Then Exit Sub

        Dim paramList As New AccWebCrawler.CurrencyRateList

        For Each b As CurrencyRateCalculationItem In Obj
            paramList.Add(b.Date, b.CurrencyCode)
            paramList.Add(Me.CalculationDateDateTimePicker.Value.Date, b.CurrencyCode)
        Next

        If paramList.Count < 1 Then Exit Sub

        If Not YesOrNo("Gauti valiutų kursus?") Then Exit Sub

        Using frm As New AccWebCrawler.F_LaunchWebCrawler(paramList, GetCurrentCompany.BaseCurrency)

            If frm.ShowDialog <> System.Windows.Forms.DialogResult.OK OrElse frm.result Is Nothing _
                OrElse Not TypeOf frm.result Is AccWebCrawler.CurrencyRateList _
                OrElse DirectCast(frm.result, AccWebCrawler.CurrencyRateList).Count < 1 Then Exit Sub

            SuspendCalculations = True

            For Each b As CurrencyRateCalculationItem In Obj
                b.CurrencyRateStart = DirectCast(frm.result, AccWebCrawler.CurrencyRateList). _
                    GetCurrencyRate(b.Date, b.CurrencyCode)
                b.CurrencyRateEnd = DirectCast(frm.result, AccWebCrawler.CurrencyRateList). _
                    GetCurrencyRate(Me.CalculationDateDateTimePicker.Value.Date, b.CurrencyCode)
            Next

            SuspendCalculations = False

            Obj_ListChanged(Obj, New System.ComponentModel.ListChangedEventArgs( _
                System.ComponentModel.ListChangedType.Reset, 0))

        End Using

    End Sub

End Class