Namespace Assets

    <Serializable()> _
Public Class LongTermAssetOperationInfo
        Inherits ReadOnlyBase(Of LongTermAssetOperationInfo)

#Region " Business Methods "

        Private _ID As Integer
        Private _IsComplexAct As Boolean
        Private _OperationType As String
        Private _AccountChangeType As String
        Private _Date As Date
        Private _Content As String
        Private _ActNumber As Integer
        Private _AttachedJournalEntryID As Integer
        Private _AttachedJournalEntry As String
        Private _CorrespondingAccount As Integer
        Private _BeforeOperationAcquisitionAccountValue As Double
        Private _BeforeOperationAcquisitionAccountValuePerUnit As Double
        Private _BeforeOperationAmortizationAccountValue As Double
        Private _BeforeOperationAmortizationAccountValuePerUnit As Double
        Private _BeforeOperationValueDecreaseAccountValue As Double
        Private _BeforeOperationValueDecreaseAccountValuePerUnit As Double
        Private _BeforeOperationValueIncreaseAccountValue As Double
        Private _BeforeOperationValueIncreaseAccountValuePerUnit As Double
        Private _BeforeOperationValueIncreaseAmmortizationAccountValue As Double
        Private _BeforeOperationValueIncreaseAmmortizationAccountValuePerUnit As Double
        Private _BeforeOperationValue As Double
        Private _BeforeOperationValuePerUnit As Double
        Private _BeforeOperationAmmount As Integer
        Private _OperationAcquisitionAccountValueChange As Double
        Private _OperationAcquisitionAccountValueChangePerUnit As Double
        Private _OperationAmortizationAccountValueChange As Double
        Private _OperationAmortizationAccountValueChangePerUnit As Double
        Private _OperationValueDecreaseAccountValueChange As Double
        Private _OperationValueDecreaseAccountValueChangePerUnit As Double
        Private _OperationValueIncreaseAccountValueChange As Double
        Private _OperationValueIncreaseAccountValueChangePerUnit As Double
        Private _OperationValueIncreaseAmmortizationAccountValueChange As Double
        Private _OperationValueIncreaseAmmortizationAccountValueChangePerUnit As Double
        Private _OperationValueChange As Double
        Private _OperationValueChangePerUnit As Double
        Private _OperationAmmountChange As Integer
        Private _AfterOperationAcquisitionAccountValue As Double
        Private _AfterOperationAcquisitionAccountValuePerUnit As Double
        Private _AfterOperationAmortizationAccountValue As Double
        Private _AfterOperationAmortizationAccountValuePerUnit As Double
        Private _AfterOperationValueDecreaseAccountValue As Double
        Private _AfterOperationValueDecreaseAccountValuePerUnit As Double
        Private _AfterOperationValueIncreaseAccountValue As Double
        Private _AfterOperationValueIncreaseAccountValuePerUnit As Double
        Private _AfterOperationValueIncreaseAmmortizationAccountValue As Double
        Private _AfterOperationValueIncreaseAmmortizationAccountValuePerUnit As Double
        Private _AfterOperationValue As Double
        Private _AfterOperationValuePerUnit As Double
        Private _AfterOperationAmmount As Integer
        Private _NewAmortizationPeriod As Integer


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property IsComplexAct() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsComplexAct
            End Get
        End Property

        Public ReadOnly Property OperationType() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationType
            End Get
        End Property

        Public ReadOnly Property AccountChangeType() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountChangeType
            End Get
        End Property

        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        Public ReadOnly Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content
            End Get
        End Property

        Public ReadOnly Property ActNumber() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ActNumber
            End Get
        End Property

        Public ReadOnly Property AttachedJournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AttachedJournalEntryID
            End Get
        End Property

        Public ReadOnly Property AttachedJournalEntry() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AttachedJournalEntry
            End Get
        End Property

        Public ReadOnly Property CorrespondingAccount() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CorrespondingAccount
            End Get
        End Property

        Public ReadOnly Property BeforeOperationAcquisitionAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationAcquisitionAccountValue)
            End Get
        End Property

        Public ReadOnly Property BeforeOperationAcquisitionAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationAcquisitionAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property BeforeOperationAmortizationAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationAmortizationAccountValue)
            End Get
        End Property

        Public ReadOnly Property BeforeOperationAmortizationAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationAmortizationAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property BeforeOperationValueDecreaseAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationValueDecreaseAccountValue)
            End Get
        End Property

        Public ReadOnly Property BeforeOperationValueDecreaseAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationValueDecreaseAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property BeforeOperationValueIncreaseAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationValueIncreaseAccountValue)
            End Get
        End Property

        Public ReadOnly Property BeforeOperationValueIncreaseAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationValueIncreaseAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property BeforeOperationValueIncreaseAmmortizationAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationValueIncreaseAmmortizationAccountValue)
            End Get
        End Property

        Public ReadOnly Property BeforeOperationValueIncreaseAmmortizationAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationValueIncreaseAmmortizationAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property BeforeOperationValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationValue)
            End Get
        End Property

        Public ReadOnly Property BeforeOperationValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property BeforeOperationAmmount() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BeforeOperationAmmount
            End Get
        End Property

        Public ReadOnly Property OperationAcquisitionAccountValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationAcquisitionAccountValueChange)
            End Get
        End Property

        Public ReadOnly Property OperationAcquisitionAccountValueChangePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationAcquisitionAccountValueChangePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property OperationAmortizationAccountValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationAmortizationAccountValueChange)
            End Get
        End Property

        Public ReadOnly Property OperationAmortizationAccountValueChangePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationAmortizationAccountValueChangePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property OperationValueDecreaseAccountValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationValueDecreaseAccountValueChange)
            End Get
        End Property

        Public ReadOnly Property OperationValueDecreaseAccountValueChangePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationValueDecreaseAccountValueChangePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property OperationValueIncreaseAccountValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationValueIncreaseAccountValueChange)
            End Get
        End Property

        Public ReadOnly Property OperationValueIncreaseAccountValueChangePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationValueIncreaseAccountValueChangePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property OperationValueIncreaseAmmortizationAccountValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationValueIncreaseAmmortizationAccountValueChange)
            End Get
        End Property

        Public ReadOnly Property OperationValueIncreaseAmmortizationAccountValueChangePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationValueIncreaseAmmortizationAccountValueChangePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property OperationValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationValueChange)
            End Get
        End Property

        Public ReadOnly Property OperationValueChangePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationValueChangePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property OperationAmmountChange() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationAmmountChange
            End Get
        End Property

        Public ReadOnly Property AfterOperationAcquisitionAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationAcquisitionAccountValue)
            End Get
        End Property

        Public ReadOnly Property AfterOperationAcquisitionAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationAcquisitionAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property AfterOperationAmortizationAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationAmortizationAccountValue)
            End Get
        End Property

        Public ReadOnly Property AfterOperationAmortizationAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationAmortizationAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property AfterOperationValueDecreaseAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationValueDecreaseAccountValue)
            End Get
        End Property

        Public ReadOnly Property AfterOperationValueDecreaseAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationValueDecreaseAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property AfterOperationValueIncreaseAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationValueIncreaseAccountValue)
            End Get
        End Property

        Public ReadOnly Property AfterOperationValueIncreaseAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationValueIncreaseAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property AfterOperationValueIncreaseAmmortizationAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationValueIncreaseAmmortizationAccountValue)
            End Get
        End Property

        Public ReadOnly Property AfterOperationValueIncreaseAmmortizationAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationValueIncreaseAmmortizationAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property AfterOperationValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationValue)
            End Get
        End Property

        Public ReadOnly Property AfterOperationValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property AfterOperationAmmount() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AfterOperationAmmount
            End Get
        End Property

        Public ReadOnly Property NewAmortizationPeriod() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NewAmortizationPeriod
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return _Date.ToShortDateString & " \ " & _OperationType & _
                GetLimitedLengthString(_Content, 100)
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function GetLongTermAssetOperationInfo(ByVal dr As DataRow, _
            ByRef nBeforeOperationAcquisitionAccountValue As Double, _
            ByRef nBeforeOperationAcquisitionAccountValuePerUnit As Double, _
            ByRef nBeforeOperationAmortizationAccountValue As Double, _
            ByRef nBeforeOperationAmortizationAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValueDecreaseAccountValue As Double, _
            ByRef nBeforeOperationValueDecreaseAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValueIncreaseAccountValue As Double, _
            ByRef nBeforeOperationValueIncreaseAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValueIncreaseAmmortizationAccountValue As Double, _
            ByRef nBeforeOperationValueIncreaseAmmortizationAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValue As Double, _
            ByRef nBeforeOperationValuePerUnit As Double, _
            ByRef nBeforeOperationAmmount As Integer) As LongTermAssetOperationInfo

            Return New LongTermAssetOperationInfo(dr, nBeforeOperationAcquisitionAccountValue, _
                nBeforeOperationAcquisitionAccountValuePerUnit, _
                nBeforeOperationAmortizationAccountValue, _
                nBeforeOperationAmortizationAccountValuePerUnit, _
                nBeforeOperationValueDecreaseAccountValue, _
                nBeforeOperationValueDecreaseAccountValuePerUnit, _
                nBeforeOperationValueIncreaseAccountValue, _
                nBeforeOperationValueIncreaseAccountValuePerUnit, _
                nBeforeOperationValueIncreaseAmmortizationAccountValue, _
                nBeforeOperationValueIncreaseAmmortizationAccountValuePerUnit, _
                nBeforeOperationValue, nBeforeOperationValuePerUnit, nBeforeOperationAmmount)
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal dr As DataRow, _
            ByRef nBeforeOperationAcquisitionAccountValue As Double, _
            ByRef nBeforeOperationAcquisitionAccountValuePerUnit As Double, _
            ByRef nBeforeOperationAmortizationAccountValue As Double, _
            ByRef nBeforeOperationAmortizationAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValueDecreaseAccountValue As Double, _
            ByRef nBeforeOperationValueDecreaseAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValueIncreaseAccountValue As Double, _
            ByRef nBeforeOperationValueIncreaseAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValueIncreaseAmmortizationAccountValue As Double, _
            ByRef nBeforeOperationValueIncreaseAmmortizationAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValue As Double, _
            ByRef nBeforeOperationValuePerUnit As Double, _
            ByRef nBeforeOperationAmmount As Integer)

            Fetch(dr, nBeforeOperationAcquisitionAccountValue, _
                nBeforeOperationAcquisitionAccountValuePerUnit, _
                nBeforeOperationAmortizationAccountValue, _
                nBeforeOperationAmortizationAccountValuePerUnit, _
                nBeforeOperationValueDecreaseAccountValue, _
                nBeforeOperationValueDecreaseAccountValuePerUnit, _
                nBeforeOperationValueIncreaseAccountValue, _
                nBeforeOperationValueIncreaseAccountValuePerUnit, _
                nBeforeOperationValueIncreaseAmmortizationAccountValue, _
                nBeforeOperationValueIncreaseAmmortizationAccountValuePerUnit, _
                nBeforeOperationValue, nBeforeOperationValuePerUnit, nBeforeOperationAmmount)

        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow, _
            ByRef nBeforeOperationAcquisitionAccountValue As Double, _
            ByRef nBeforeOperationAcquisitionAccountValuePerUnit As Double, _
            ByRef nBeforeOperationAmortizationAccountValue As Double, _
            ByRef nBeforeOperationAmortizationAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValueDecreaseAccountValue As Double, _
            ByRef nBeforeOperationValueDecreaseAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValueIncreaseAccountValue As Double, _
            ByRef nBeforeOperationValueIncreaseAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValueIncreaseAmmortizationAccountValue As Double, _
            ByRef nBeforeOperationValueIncreaseAmmortizationAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValue As Double, _
            ByRef nBeforeOperationValuePerUnit As Double, _
            ByRef nBeforeOperationAmmount As Integer)

            _BeforeOperationAcquisitionAccountValue = _
                CRound(nBeforeOperationAcquisitionAccountValue)
            _BeforeOperationAcquisitionAccountValuePerUnit = _
                CRound(nBeforeOperationAcquisitionAccountValuePerUnit, ROUNDUNITASSET)
            _BeforeOperationAmortizationAccountValue = _
                CRound(nBeforeOperationAmortizationAccountValue)
            _BeforeOperationAmortizationAccountValuePerUnit = _
                CRound(nBeforeOperationAmortizationAccountValuePerUnit, ROUNDUNITASSET)
            _BeforeOperationValueDecreaseAccountValue = _
                CRound(nBeforeOperationValueDecreaseAccountValue)
            _BeforeOperationValueDecreaseAccountValuePerUnit = _
                CRound(nBeforeOperationValueDecreaseAccountValuePerUnit, ROUNDUNITASSET)
            _BeforeOperationValueIncreaseAccountValue = _
                CRound(nBeforeOperationValueIncreaseAccountValue)
            _BeforeOperationValueIncreaseAccountValuePerUnit = _
                CRound(nBeforeOperationValueIncreaseAccountValuePerUnit, ROUNDUNITASSET)
            _BeforeOperationValueIncreaseAmmortizationAccountValue = _
                CRound(nBeforeOperationValueIncreaseAmmortizationAccountValue)
            _BeforeOperationValueIncreaseAmmortizationAccountValuePerUnit = _
                CRound(nBeforeOperationValueIncreaseAmmortizationAccountValuePerUnit, ROUNDUNITASSET)
            _BeforeOperationValue = CRound(nBeforeOperationValue)
            _BeforeOperationValuePerUnit = CRound(nBeforeOperationValuePerUnit, ROUNDUNITASSET)
            _BeforeOperationAmmount = nBeforeOperationAmmount

            _ID = CIntSafe(dr.Item(0), 0)
            _OperationType = ConvertEnumHumanReadable(ConvertEnumDatabaseStringCode(Of LtaOperationType) _
                (CStrSafe(dr.Item(1))))
            If Not String.IsNullOrEmpty(CStrSafe(dr.Item(2)).Trim) Then
                _AccountChangeType = ConvertEnumHumanReadable( _
                    ConvertEnumDatabaseStringCode(Of LtaAccountChangeType)(CStrSafe(dr.Item(2))))
            Else
                _AccountChangeType = ""
            End If
            _Date = CDateSafe(dr.Item(3), Today)
            If CIntSafe(dr.Item(4), 0) > 0 Then
                _AttachedJournalEntryID = CIntSafe(dr.Item(4), 0)
                _AttachedJournalEntry = "Nr. " & CStrSafe(dr.Item(5)) & " \ " & _
                    GetLimitedLengthString(CStrSafe(dr.Item(6)), 100)
            Else
                _AttachedJournalEntryID = -1
                _AttachedJournalEntry = "nėra"
            End If
            _IsComplexAct = ConvertDbBoolean(CIntSafe(dr.Item(8), 0))
            _Content = CStrSafe(dr.Item(9)).Trim
            _CorrespondingAccount = CIntSafe(dr.Item(10), 0)
            _ActNumber = CIntSafe(dr.Item(11), 0)
            _OperationValueChangePerUnit = CDblSafe(dr.Item(12), ROUNDUNITASSET, 0)
            _OperationAmmountChange = CIntSafe(dr.Item(13), 0)
            _OperationValueChange = CDblSafe(dr.Item(14), 2, 0)
            _NewAmortizationPeriod = CIntSafe(dr.Item(15), 0)
            _OperationAcquisitionAccountValueChange = CDblSafe(dr.Item(19), 2, 0)
            _OperationAcquisitionAccountValueChangePerUnit = CDblSafe(dr.Item(20), ROUNDUNITASSET, 0)
            _OperationAmortizationAccountValueChange = CDblSafe(dr.Item(21), 2, 0)
            _OperationAmortizationAccountValueChangePerUnit = CDblSafe(dr.Item(22), ROUNDUNITASSET, 0)
            _OperationValueDecreaseAccountValueChange = CDblSafe(dr.Item(23), 2, 0)
            _OperationValueDecreaseAccountValueChangePerUnit = CDblSafe(dr.Item(24), ROUNDUNITASSET, 0)
            _OperationValueIncreaseAccountValueChange = CDblSafe(dr.Item(25), 2, 0)
            _OperationValueIncreaseAccountValueChangePerUnit = CDblSafe(dr.Item(26), ROUNDUNITASSET, 0)
            _OperationValueIncreaseAmmortizationAccountValueChange = CDblSafe(dr.Item(27), 2, 0)
            _OperationValueIncreaseAmmortizationAccountValueChangePerUnit = CDblSafe(dr.Item(28), ROUNDUNITASSET, 0)

            _AfterOperationAcquisitionAccountValue = _
                CRound(nBeforeOperationAcquisitionAccountValue _
                + _OperationAcquisitionAccountValueChange)
            _AfterOperationAcquisitionAccountValuePerUnit = _
                CRound(nBeforeOperationAcquisitionAccountValuePerUnit _
                + _OperationAcquisitionAccountValueChangePerUnit, ROUNDUNITASSET)
            _AfterOperationAmortizationAccountValue = _
                CRound(nBeforeOperationAmortizationAccountValue _
                + _OperationAmortizationAccountValueChange)
            _AfterOperationAmortizationAccountValuePerUnit = _
                CRound(nBeforeOperationAmortizationAccountValuePerUnit _
                + _OperationAmortizationAccountValueChangePerUnit, ROUNDUNITASSET)
            _AfterOperationValueDecreaseAccountValue = _
                CRound(nBeforeOperationValueDecreaseAccountValue _
                + _OperationValueDecreaseAccountValueChange)
            _AfterOperationValueDecreaseAccountValuePerUnit = _
                CRound(nBeforeOperationValueDecreaseAccountValuePerUnit _
                + _OperationValueDecreaseAccountValueChangePerUnit, ROUNDUNITASSET)
            _AfterOperationValueIncreaseAccountValue = _
                CRound(nBeforeOperationValueIncreaseAccountValue _
                + _OperationValueIncreaseAccountValueChange)
            _AfterOperationValueIncreaseAccountValuePerUnit = _
                CRound(nBeforeOperationValueIncreaseAccountValuePerUnit _
                + _OperationValueIncreaseAccountValueChangePerUnit, ROUNDUNITASSET)
            _AfterOperationValueIncreaseAmmortizationAccountValue = _
                CRound(nBeforeOperationValueIncreaseAmmortizationAccountValue _
                + _OperationValueIncreaseAmmortizationAccountValueChange)
            _AfterOperationValueIncreaseAmmortizationAccountValuePerUnit = _
                CRound(nBeforeOperationValueIncreaseAmmortizationAccountValuePerUnit _
                + _OperationValueIncreaseAmmortizationAccountValueChangePerUnit, ROUNDUNITASSET)
            _AfterOperationValue = CRound(nBeforeOperationValue + _OperationValueChange)
            _AfterOperationValuePerUnit = CRound(nBeforeOperationValuePerUnit + _
                _OperationValueChangePerUnit, ROUNDUNITASSET)
            _AfterOperationAmmount = nBeforeOperationAmmount - OperationAmmountChange

            ' values "before" is to be updated to values "after" (making use of ByRef)
            nBeforeOperationAcquisitionAccountValue = _
                CRound(_AfterOperationAcquisitionAccountValue)
            nBeforeOperationAcquisitionAccountValuePerUnit = _
                CRound(_AfterOperationAcquisitionAccountValuePerUnit, ROUNDUNITASSET)
            nBeforeOperationAmortizationAccountValue = _
                CRound(_AfterOperationAmortizationAccountValue)
            nBeforeOperationAmortizationAccountValuePerUnit = _
                CRound(_AfterOperationAmortizationAccountValuePerUnit, ROUNDUNITASSET)
            nBeforeOperationValueDecreaseAccountValue = _
                CRound(_AfterOperationValueDecreaseAccountValue)
            nBeforeOperationValueDecreaseAccountValuePerUnit = _
                CRound(_AfterOperationValueDecreaseAccountValuePerUnit, ROUNDUNITASSET)
            nBeforeOperationValueIncreaseAccountValue = _
                CRound(_AfterOperationValueIncreaseAccountValue)
            nBeforeOperationValueIncreaseAccountValuePerUnit = _
                CRound(_AfterOperationValueIncreaseAccountValuePerUnit, ROUNDUNITASSET)
            nBeforeOperationValueIncreaseAmmortizationAccountValue = _
                CRound(_AfterOperationValueIncreaseAmmortizationAccountValue)
            nBeforeOperationValueIncreaseAmmortizationAccountValuePerUnit = _
                CRound(_AfterOperationValueIncreaseAmmortizationAccountValuePerUnit, ROUNDUNITASSET)
            nBeforeOperationValue = CRound(_AfterOperationValue)
            nBeforeOperationValuePerUnit = CRound(_AfterOperationValuePerUnit, ROUNDUNITASSET)
            nBeforeOperationAmmount = _AfterOperationAmmount

        End Sub

#End Region

    End Class

End Namespace
