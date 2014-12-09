Namespace Assets

    <Serializable()> _
Public Class LongTermAssetOperationInfoListParent
        Inherits ReadOnlyBase(Of LongTermAssetOperationInfoListParent)

#Region " Business Methods "

        Private _ID As Integer
        Private _Name As String
        Private _MeasureUnit As String
        Private _LegalGroup As String
        Private _CustomGroupID As Integer
        Private _CustomGroup As String
        Private _AcquisitionDate As Date
        Private _AcquisitionJournalEntryID As Integer
        Private _AcquisitionJournalEntryDocNumber As String
        Private _AcquisitionJournalEntryDocContent As String
        Private _AcquisitionJournalEntryDocType As String
        Private _InventoryNumber As String
        Private _AccountAcquisition As Integer
        Private _AccountAccumulatedAmortization As Integer
        Private _AccountValueIncrease As Integer
        Private _AccountValueDecrease As Integer
        Private _AccountRevaluedPortionAmmortization As Integer

        Private _AcquisitionAccountValue As Double
        Private _AcquisitionAccountValuePerUnit As Double
        Private _AmortizationAccountValue As Double
        Private _AmortizationAccountValuePerUnit As Double
        Private _ValueDecreaseAccountValue As Double
        Private _ValueDecreaseAccountValuePerUnit As Double
        Private _ValueIncreaseAccountValue As Double
        Private _ValueIncreaseAccountValuePerUnit As Double
        Private _ValueIncreaseAmmortizationAccountValue As Double
        Private _ValueIncreaseAmmortizationAccountValuePerUnit As Double
        Private _Value As Double
        Private _ValuePerUnit As Double
        Private _Ammount As Integer
        Private _ValueRevaluedPortion As Double
        Private _ValueRevaluedPortionPerUnit As Double

        Private _LiquidationUnitValue As Double
        Private _ContinuedUsage As Boolean
        Private _DefaultAmortizationPeriod As Integer
        Private _OperationList As LongTermAssetOperationInfoList


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name
            End Get
        End Property

        Public ReadOnly Property MeasureUnit() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MeasureUnit
            End Get
        End Property

        Public ReadOnly Property LegalGroup() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LegalGroup
            End Get
        End Property

        Public ReadOnly Property CustomGroupID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CustomGroupID
            End Get
        End Property

        Public ReadOnly Property CustomGroup() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CustomGroup
            End Get
        End Property

        Public ReadOnly Property AcquisitionDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AcquisitionDate
            End Get
        End Property

        Public ReadOnly Property AcquisitionJournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AcquisitionJournalEntryID
            End Get
        End Property

        Public ReadOnly Property AcquisitionJournalEntryDocNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AcquisitionJournalEntryDocNumber
            End Get
        End Property

        Public ReadOnly Property AcquisitionJournalEntryDocContent() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AcquisitionJournalEntryDocContent
            End Get
        End Property

        Public ReadOnly Property InventoryNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InventoryNumber
            End Get
        End Property

        Public ReadOnly Property AccountAcquisition() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountAcquisition
            End Get
        End Property

        Public ReadOnly Property AccountAccumulatedAmortization() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountAccumulatedAmortization
            End Get
        End Property

        Public ReadOnly Property AccountValueIncrease() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountValueIncrease
            End Get
        End Property

        Public ReadOnly Property AccountValueDecrease() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountValueDecrease
            End Get
        End Property

        Public ReadOnly Property AccountRevaluedPortionAmmortization() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountRevaluedPortionAmmortization
            End Get
        End Property



        Public ReadOnly Property AcquisitionAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AcquisitionAccountValue)
            End Get
        End Property

        Public ReadOnly Property AcquisitionAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AcquisitionAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property AmortizationAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmortizationAccountValue)
            End Get
        End Property

        Public ReadOnly Property AmortizationAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmortizationAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property ValueDecreaseAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ValueDecreaseAccountValue)
            End Get
        End Property

        Public ReadOnly Property ValueDecreaseAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ValueDecreaseAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property ValueIncreaseAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ValueIncreaseAccountValue)
            End Get
        End Property

        Public ReadOnly Property ValueIncreaseAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ValueIncreaseAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property ValueIncreaseAmmortizationAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ValueIncreaseAmmortizationAccountValue)
            End Get
        End Property

        Public ReadOnly Property ValueIncreaseAmmortizationAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ValueIncreaseAmmortizationAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property Value() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Value)
            End Get
        End Property

        Public ReadOnly Property ValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property Ammount() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Ammount
            End Get
        End Property

        Public ReadOnly Property ValueRevaluedPortion() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ValueRevaluedPortion)
            End Get
        End Property

        Public ReadOnly Property ValueRevaluedPortionPerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ValueRevaluedPortionPerUnit, ROUNDUNITASSET)
            End Get
        End Property



        Public ReadOnly Property LiquidationUnitValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_LiquidationUnitValue, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property ContinuedUsage() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContinuedUsage
            End Get
        End Property

        Public ReadOnly Property DefaultAmortizationPeriod() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DefaultAmortizationPeriod
            End Get
        End Property

        Public ReadOnly Property OperationList() As LongTermAssetOperationInfoList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationList
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Assets.LongTermAssetOperationInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetLongTermAssetOperationInfoListParent(ByVal AssetId As Integer) _
            As LongTermAssetOperationInfoListParent
            Return DataPortal.Fetch(Of LongTermAssetOperationInfoListParent)(New Criteria(AssetId))
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private mId As Integer
            Public ReadOnly Property Id() As Integer
                Get
                    Return mId
                End Get
            End Property
            Public Sub New(ByVal id As Integer)
                mId = id
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai informacijai gauti.")

            Dim myComm As New SQLCommand("FetchLongTermAssetOperationInfoListParent")
            myComm.AddParam("?AD", criteria.Id)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception("Klaida. Nerasti turto duomenys.")
                Dim dr As DataRow = myData.Rows(0)

                _Name = CStrSafe(dr.Item(0)).Trim
                _MeasureUnit = CStrSafe(dr.Item(1)).Trim
                _LegalGroup = CStrSafe(dr.Item(2)).Trim
                _CustomGroupID = CIntSafe(dr.Item(3), 0)
                _CustomGroup = CStrSafe(dr.Item(4)).Trim
                _InventoryNumber = CStrSafe(dr.Item(5)).Trim
                _AcquisitionJournalEntryID = CIntSafe(dr.Item(6), 0)
                _AcquisitionDate = CDateSafe(dr.Item(7), Today)
                _AcquisitionJournalEntryDocNumber = CStrSafe(dr.Item(8)).Trim
                _AcquisitionJournalEntryDocContent = CStrSafe(dr.Item(9)).Trim
                _AcquisitionJournalEntryDocType = ConvertEnumDatabaseStringCode(Of DocumentType) _
                    (CStrSafe(dr.Item(10)))
                _AccountAcquisition = CIntSafe(dr.Item(11), 0)
                _AccountAccumulatedAmortization = CIntSafe(dr.Item(12), 0)
                _AccountValueDecrease = CIntSafe(dr.Item(13), 0)
                _AccountValueIncrease = CIntSafe(dr.Item(14), 0)
                _AccountRevaluedPortionAmmortization = CIntSafe(dr.Item(15), 0)
                _LiquidationUnitValue = CDblSafe(dr.Item(16), ROUNDUNITASSET, 0)
                _DefaultAmortizationPeriod = CIntSafe(dr.Item(17), 0)
                _AcquisitionAccountValuePerUnit = CDblSafe(dr.Item(18), ROUNDUNITASSET, 0)
                _Ammount = CIntSafe(dr.Item(19), 0)
                _AcquisitionAccountValue = CDblSafe(dr.Item(20), 2, 0)
                _AmortizationAccountValue = CDblSafe(dr.Item(23))
                _AmortizationAccountValuePerUnit = CDblSafe(dr.Item(24), ROUNDUNITASSET, 0)
                _ValueIncreaseAmmortizationAccountValue = CDblSafe(dr.Item(25), 2, 0)
                _ValueIncreaseAmmortizationAccountValuePerUnit = CDblSafe(dr.Item(26), ROUNDUNITASSET, 0)
                _ContinuedUsage = ConvertDbBoolean(CIntSafe(dr.Item(27), 0))

                If CDbl(dr.Item(21)) < 0 Then
                    _ValueDecreaseAccountValuePerUnit = -CDblSafe(dr.Item(21), ROUNDUNITASSET, 0)
                    _ValueIncreaseAccountValuePerUnit = 0
                ElseIf CDbl(dr.Item(21)) > 0 Then
                    _ValueIncreaseAccountValuePerUnit = CDblSafe(dr.Item(21), ROUNDUNITASSET, 0)
                    _ValueDecreaseAccountValuePerUnit = 0
                Else
                    _ValueIncreaseAccountValuePerUnit = 0
                    _ValueDecreaseAccountValuePerUnit = 0
                End If
                If CDbl(dr.Item(22)) < 0 Then
                    _ValueDecreaseAccountValue = -CDblSafe(dr.Item(22), 2, 0)
                    _ValueIncreaseAccountValue = 0
                ElseIf CDbl(dr.Item(22)) > 0 Then
                    _ValueIncreaseAccountValue = CDblSafe(dr.Item(22), 2, 0)
                    _ValueDecreaseAccountValue = 0
                Else
                    _ValueIncreaseAccountValue = 0
                    _ValueDecreaseAccountValue = 0
                End If

                _ValueIncreaseAccountValue = CRound(_ValueIncreaseAccountValue + _
                    _ValueIncreaseAmmortizationAccountValue)
                _ValueIncreaseAccountValuePerUnit = CRound(_ValueIncreaseAccountValuePerUnit + _
                    _ValueIncreaseAmmortizationAccountValuePerUnit, ROUNDUNITASSET)

                _Value = CRound(_AcquisitionAccountValue - _
                    _AmortizationAccountValue - _ValueDecreaseAccountValue + _
                    _ValueIncreaseAccountValue - _ValueIncreaseAmmortizationAccountValue)
                _ValuePerUnit = CRound(_AcquisitionAccountValuePerUnit - _
                    _AmortizationAccountValuePerUnit - _ValueDecreaseAccountValuePerUnit + _
                    _ValueIncreaseAccountValuePerUnit - _
                    _ValueIncreaseAmmortizationAccountValuePerUnit, ROUNDUNITASSET)
                If _ValueDecreaseAccountValue > 0 Then
                    _ValueRevaluedPortion = -CRound(_ValueDecreaseAccountValue)
                    _ValueRevaluedPortionPerUnit = -CRound(_ValueDecreaseAccountValuePerUnit, ROUNDUNITASSET)
                ElseIf _ValueIncreaseAccountValue > 0 Then
                    _ValueRevaluedPortion = CRound(_ValueIncreaseAccountValue _
                        - _ValueIncreaseAmmortizationAccountValue)
                    _ValueRevaluedPortionPerUnit = CRound(_ValueIncreaseAccountValuePerUnit _
                        - _ValueIncreaseAmmortizationAccountValuePerUnit, ROUNDUNITASSET)
                Else
                    _ValueRevaluedPortion = 0
                    _ValueRevaluedPortionPerUnit = 0
                End If

            End Using

            _ID = criteria.Id

            myComm = New SQLCommand("FetchLongTermOperationInfoList")
            myComm.AddParam("?AD", criteria.Id)

            Using myData As DataTable = myComm.Fetch
                _OperationList = LongTermAssetOperationInfoList.GetList(Me, myData)
            End Using

        End Sub

#End Region

    End Class

End Namespace