Namespace ActiveReports

    <Serializable()> _
    Public Class DebtInfo
        Inherits ReadOnlyBase(Of DebtInfo)

#Region " Business Methods "

        Private _PersonID As Integer = 0
        Private _PersonName As String = ""
        Private _PersonCode As String = ""
        Private _PersonVatCode As String = ""
        Private _PersonGroup As String = ""
        Private _PersonAddress As String = ""
        Private _DebtBegin As Double = 0
        Private _TurnoverDebet As Double = 0
        Private _TurnoverCredit As Double = 0
        Private _DebtEnd As Double = 0


        Public ReadOnly Property PersonID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonID
            End Get
        End Property

        Public ReadOnly Property PersonName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonName.Trim
            End Get
        End Property

        Public ReadOnly Property PersonCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonCode.Trim
            End Get
        End Property

        Public ReadOnly Property PersonVatCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonVatCode.Trim
            End Get
        End Property

        Public ReadOnly Property PersonGroup() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonGroup.Trim
            End Get
        End Property

        Public ReadOnly Property PersonAddress() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonAddress.Trim
            End Get
        End Property

        Public ReadOnly Property DebtBegin() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DebtBegin)
            End Get
        End Property

        Public ReadOnly Property TurnoverDebet() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TurnoverDebet)
            End Get
        End Property

        Public ReadOnly Property TurnoverCredit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TurnoverCredit)
            End Get
        End Property

        Public ReadOnly Property DebtEnd() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DebtEnd)
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _PersonID
        End Function

        Public Overrides Function ToString() As String
            If Not _PersonID > 0 Then Return ""
            Return _PersonName & " (" & _PersonCode & ") " & CRound(_DebtEnd).ToString
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function GetDebtInfo(ByVal dr As DataRow, _
            ByVal nIsBuyer As Boolean) As DebtInfo
            Return New DebtInfo(dr, nIsBuyer)
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal nIsBuyer As Boolean)
            Fetch(dr, nIsBuyer)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow, ByVal nIsBuyer As Boolean)

            _PersonID = CIntSafe(dr.Item(0), 0)
            _PersonName = CStrSafe(dr.Item(1)).Trim
            _PersonCode = CStrSafe(dr.Item(2)).Trim
            _PersonVatCode = CStrSafe(dr.Item(3)).Trim
            _PersonAddress = CStrSafe(dr.Item(4)).Trim
            _PersonGroup = CStrSafe(dr.Item(5)).Trim

            If nIsBuyer Then
                _DebtBegin = CRound(CDblSafe(dr.Item(6), 2, 0) - CDblSafe(dr.Item(7), 2, 0))
            Else
                _DebtBegin = CRound(CDblSafe(dr.Item(7), 2, 0) - CDblSafe(dr.Item(6), 2, 0))
            End If

            _TurnoverDebet = CDblSafe(dr.Item(8), 2, 0)
            _TurnoverCredit = CDblSafe(dr.Item(9), 2, 0)

            If nIsBuyer Then
                _DebtEnd = CRound(_DebtBegin + _TurnoverDebet - _TurnoverCredit)
            Else
                _DebtEnd = CRound(_DebtBegin - _TurnoverDebet + _TurnoverCredit)
            End If

        End Sub

#End Region

    End Class

End Namespace
