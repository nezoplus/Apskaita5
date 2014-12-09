Namespace Goods

    <Serializable()> _
    Public Class OperationalLimitList
        Inherits ReadOnlyListBase(Of OperationalLimitList, OperationalLimit)
        Implements IChronologicValidator

#Region " Business Methods "

        Private Const DatePlaceHolder As String = "<$Date>"

        Private _CurrentOperationType As GoodsOperationType = GoodsOperationType.Acquisition
        Private _CurrentValuationMethod As GoodsValuationMethod = GoodsValuationMethod.FIFO
        Private _CurrentAccountingMethod As GoodsAccountingMethod = GoodsAccountingMethod.Persistent
        Private _CurrentOperationName As String = ""
        Private _CurrentGoodsName As String = ""
        Private _CurrentOperationID As Integer = 0
        Private _CurrentOperationDate As Date = Today
        Private _CurrentGoodsID As Integer = 0
        Private _CurrentWarehouseID As Integer = 0

        Private _ConsignmentWasUsed As Boolean = False
        Private _ConsignmentWasUsedDate As Date = Date.MaxValue
        Private _FinancialDataCanChange As Boolean = True
        Private _MinDateApplicable As Boolean = False
        Private _MaxDateApplicable As Boolean = False
        Private _MinDate As Date = Date.MinValue
        Private _MaxDate As Date = Date.MaxValue
        Private _FinancialDataCanChangeExplanation As String = ""
        Private _MinDateExplanation As String = ""
        Private _MaxDateExplanation As String = ""
        Private _LimitsExplanation As String = ""
        Private _BackgroundExplanation As String = ""
        Private _ParentFinancialDataCanChange As Boolean = True
        Private _ParentFinancialDataCanChangeExplanation As String = ""
        Private _BaseValidator As IChronologicValidator


        Public ReadOnly Property CurrentOperationName() As String _
            Implements IChronologicValidator.CurrentOperationName
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationName
            End Get
        End Property

        Public ReadOnly Property CurrentOperationType() As GoodsOperationType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationType
            End Get
        End Property

        Public ReadOnly Property CurrentValuationMethod() As GoodsValuationMethod
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentValuationMethod
            End Get
        End Property

        Public ReadOnly Property CurrentAccountingMethod() As GoodsAccountingMethod
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentAccountingMethod
            End Get
        End Property

        Public ReadOnly Property CurrentGoodsName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentGoodsName
            End Get
        End Property

        Public ReadOnly Property CurrentOperationID() As Integer _
            Implements IChronologicValidator.CurrentOperationID
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationID
            End Get
        End Property

        Public ReadOnly Property CurrentGoodsID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentGoodsID
            End Get
        End Property

        Public ReadOnly Property CurrentWarehouseID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentWarehouseID
            End Get
        End Property

        Public ReadOnly Property CurrentOperationDate() As Date _
            Implements IChronologicValidator.CurrentOperationDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationDate
            End Get
        End Property


        Public ReadOnly Property ConsignmentWasUsed() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ConsignmentWasUsed
            End Get
        End Property

        Public ReadOnly Property ConsignmentWasUsedDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ConsignmentWasUsedDate
            End Get
        End Property

        Public ReadOnly Property FinancialDataCanChange() As Boolean _
            Implements IChronologicValidator.FinancialDataCanChange
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property MinDateApplicable() As Boolean _
            Implements IChronologicValidator.MinDateApplicable
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDateApplicable
            End Get
        End Property

        Public ReadOnly Property MaxDateApplicable() As Boolean _
            Implements IChronologicValidator.MaxDateApplicable
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDateApplicable
            End Get
        End Property

        Public ReadOnly Property MinDate() As Date _
            Implements IChronologicValidator.MinDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDate
            End Get
        End Property

        Public ReadOnly Property MaxDate() As Date _
            Implements IChronologicValidator.MaxDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDate
            End Get
        End Property

        Public ReadOnly Property FinancialDataCanChangeExplanation() As String _
            Implements IChronologicValidator.FinancialDataCanChangeExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChangeExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property MinDateExplanation() As String _
            Implements IChronologicValidator.MinDateExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDateExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property MaxDateExplanation() As String _
            Implements IChronologicValidator.MaxDateExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDateExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property LimitsExplanation() As String _
            Implements IChronologicValidator.LimitsExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LimitsExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property BackgroundExplanation() As String _
            Implements IChronologicValidator.BackgroundExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BackgroundExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property ParentFinancialDataCanChange() As Boolean _
        Implements IChronologicValidator.ParentFinancialDataCanChange
            Get
                Return _ParentFinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property ParentFinancialDataCanChangeExplanation() As String _
            Implements IChronologicValidator.ParentFinancialDataCanChangeExplanation
            Get
                Return _ParentFinancialDataCanChangeExplanation
            End Get
        End Property

        Public ReadOnly Property BaseValidator As IChronologicValidator
            Get
                Return _BaseValidator
            End Get
        End Property



        Public Function GetDate(ByVal WarehouseID As Integer, _
            ByVal ChronologyType As OperationChronologyType, _
            ByVal OperationType As GoodsOperationType) As Date

            For Each i As OperationalLimit In Me
                If i.OperationType = OperationType AndAlso (Not WarehouseID > 0 _
                    OrElse i.WarehouseID = WarehouseID OrElse _
                    Not OperationTypeIsWarehouseDependent(i.OperationType)) AndAlso _
                    i.ChronologyType = ChronologyType Then Return i.MaxOperationDate
            Next
            Return Date.MinValue

        End Function

        Public Function GetMaxDate(ByVal WarehouseID As Integer, _
            ByVal ChronologyType As OperationChronologyType, _
            ByVal ParamArray OperationTypes As GoodsOperationType()) As Date

            Dim result As Date = Date.MinValue

            If OperationTypes Is Nothing Then

                For Each i As OperationalLimit In Me
                    If (Not WarehouseID > 0 OrElse i.WarehouseID = WarehouseID OrElse _
                        Not OperationTypeIsWarehouseDependent(i.OperationType)) AndAlso _
                        i.ChronologyType = ChronologyType AndAlso i.MaxOperationDate.Date > result.Date Then _
                        result = i.MaxOperationDate
                Next

            Else

                For Each i As OperationalLimit In Me
                    If (Not WarehouseID > 0 OrElse i.WarehouseID = WarehouseID OrElse _
                        Not OperationTypeIsWarehouseDependent(i.OperationType)) AndAlso _
                        i.ChronologyType = ChronologyType AndAlso Not Array.IndexOf( _
                        OperationTypes, i.OperationType) < 0 AndAlso i.MaxOperationDate.Date > result.Date Then _
                        result = i.MaxOperationDate
                Next

            End If

            Return result

        End Function

        Public Function GetMinDate(ByVal WarehouseID As Integer, _
            ByVal ChronologyType As OperationChronologyType, _
            ByVal ParamArray OperationTypes As GoodsOperationType()) As Date

            Dim result As Date = Date.MaxValue

            If OperationTypes Is Nothing Then

                For Each i As OperationalLimit In Me
                    If (Not WarehouseID > 0 OrElse i.WarehouseID = WarehouseID OrElse _
                        Not OperationTypeIsWarehouseDependent(i.OperationType)) AndAlso _
                        i.ChronologyType = ChronologyType AndAlso i.MaxOperationDate.Date < result.Date Then _
                        result = i.MaxOperationDate
                Next

            Else

                For Each i As OperationalLimit In Me
                    If (Not WarehouseID > 0 OrElse i.WarehouseID = WarehouseID OrElse _
                        Not OperationTypeIsWarehouseDependent(i.OperationType)) AndAlso _
                        i.ChronologyType = ChronologyType AndAlso Not Array.IndexOf( _
                        OperationTypes, i.OperationType) < 0 AndAlso i.MaxOperationDate.Date < result.Date Then _
                        result = i.MaxOperationDate
                Next

            End If

            Return result

        End Function


        Public Function ValidateOperationDate(ByVal OperationDate As Date, _
            ByRef ErrorMessage As String, ByRef ErrorSeverity As Csla.Validation.RuleSeverity) As Boolean _
            Implements IChronologicValidator.ValidateOperationDate

            If _MinDateApplicable AndAlso OperationDate.Date < _MinDate.Date Then
                ErrorMessage = _MinDateExplanation
                ErrorSeverity = Validation.RuleSeverity.Error
                Return False
            ElseIf _MaxDateApplicable AndAlso OperationDate.Date > _MaxDate.Date Then
                ErrorMessage = _MaxDateExplanation
                ErrorSeverity = Validation.RuleSeverity.Error
                Return False
            End If

            Dim LastPriceCut As Date = GetDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.PriceCut)
            If LastPriceCut <> Date.MinValue AndAlso (OperationDate.Date < LastPriceCut.Date _
                OrElse (_CurrentOperationID > 0 AndAlso _CurrentOperationDate.Date < LastPriceCut.Date)) Then
                ErrorMessage = "Operacijos duomenų pakeitimas gali turėti įtakos vėliau " _
                    & "registruotai nukainojimo operacijai."
                ErrorSeverity = Validation.RuleSeverity.Warning
                Return False
            End If

            Return True

        End Function

        Public Function GetBackgroundDescription() As String

            Dim result As String = ""

            Dim tmpResult As String = ""

            For Each i As OperationalLimit In Me
                If i.ChronologyType = OperationChronologyType.Overall AndAlso _
                    (Not CurrentWarehouseID > 0 OrElse i.WarehouseID = CurrentWarehouseID OrElse _
                    Not OperationTypeIsWarehouseDependent(i.OperationType)) Then tmpResult = _
                    AddWithNewLine(tmpResult, ConvertEnumHumanReadable(i.OperationType) _
                    & " - " & i.MaxOperationDate.ToString("yyyy-MM-dd"), False)
            Next

            If Not String.IsNullOrEmpty(tmpResult.Trim) Then result = _
                "Paskutinės operacijos su preke sandėlyje:" & vbCrLf & tmpResult

            If Not CurrentOperationID > 0 Then Return result

            tmpResult = ""

            For Each i As OperationalLimit In Me
                If i.ChronologyType = OperationChronologyType.LastBefore AndAlso _
                    (Not CurrentWarehouseID > 0 OrElse i.WarehouseID = CurrentWarehouseID OrElse _
                    Not OperationTypeIsWarehouseDependent(i.OperationType)) Then tmpResult = _
                    AddWithNewLine(tmpResult, ConvertEnumHumanReadable(i.OperationType) _
                    & " - " & i.MaxOperationDate.ToString("yyyy-MM-dd"), False)
            Next

            If Not String.IsNullOrEmpty(tmpResult.Trim) Then

                If Not String.IsNullOrEmpty(result.Trim) Then
                    result = result & vbCrLf & vbCrLf & "Paskutinės operacijos su preke " _
                        & "sandėlyje iki keičiamos operacijos:" & vbCrLf & tmpResult
                Else
                    result = "Paskutinės operacijos su preke " _
                       & "sandėlyje iki keičiamos operacijos:" & vbCrLf & tmpResult
                End If

            End If

            tmpResult = ""

            For Each i As OperationalLimit In Me
                If i.ChronologyType = OperationChronologyType.FirstAfter AndAlso _
                    (Not CurrentWarehouseID > 0 OrElse i.WarehouseID = CurrentWarehouseID OrElse _
                    Not OperationTypeIsWarehouseDependent(i.OperationType)) Then tmpResult = _
                    AddWithNewLine(tmpResult, ConvertEnumHumanReadable(i.OperationType) _
                    & " - " & i.MaxOperationDate.ToString("yyyy-MM-dd"), False)
            Next

            If Not String.IsNullOrEmpty(tmpResult.Trim) Then

                If Not String.IsNullOrEmpty(result.Trim) Then
                    result = result & vbCrLf & vbCrLf & "Pirmos operacijos su preke " _
                        & "sandėlyje po keičiamos operacijos:" & vbCrLf & tmpResult
                Else
                    result = "Pirmos operacijos su preke " _
                       & "sandėlyje po keičiamos operacijos:" & vbCrLf & tmpResult
                End If

            End If

            Return result

        End Function


        Public Shared Function OperationTypeIsWarehouseDependent(ByVal value As GoodsOperationType) As Boolean
            Return (value <> GoodsOperationType.AccountDiscountsChange AndAlso _
                value <> GoodsOperationType.AccountPurchasesChange AndAlso _
                value <> GoodsOperationType.AccountSalesNetCostsChange AndAlso _
                value <> GoodsOperationType.AccountValueReductionChange AndAlso _
                value <> GoodsOperationType.PriceCut AndAlso _
                value <> GoodsOperationType.ValuationMethodChange AndAlso _
                value <> GoodsOperationType.TransferOfBalance)
        End Function


        Friend Sub SetWarehouse(ByVal warehouse As WarehouseInfo)

            If _CurrentOperationID > 0 OrElse warehouse Is Nothing OrElse Not warehouse.ID > 0 Then Exit Sub

            _CurrentWarehouseID = warehouse.ID
            FetchLimitations()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function GetOperationalLimitList(ByVal GoodsID As Integer, _
            ByVal OperationID As Integer, ByVal OperationType As GoodsOperationType, _
            ByVal ValuationMethod As GoodsValuationMethod, _
            ByVal AccountingMethod As GoodsAccountingMethod, _
            ByVal GoodsName As String, ByVal OperationDate As Date, _
            ByVal WarehouseID As Integer, ByVal parentValidator As IChronologicValidator) _
            As OperationalLimitList
            Return New OperationalLimitList(GoodsID, OperationID, OperationType, ValuationMethod, _
                AccountingMethod, GoodsName, OperationDate, WarehouseID, parentValidator)
        End Function

        Friend Shared Function GetOperationalLimitList(ByVal GoodsID As Integer, _
            ByVal OperationID As Integer, ByVal OperationType As GoodsOperationType, _
            ByVal ValuationMethod As GoodsValuationMethod, _
            ByVal AccountingMethod As GoodsAccountingMethod, _
            ByVal GoodsName As String, ByVal OperationDate As Date, ByVal WarehouseID As Integer, _
            ByVal parentValidator As IChronologicValidator, ByVal myData As DataTable) As OperationalLimitList
            Return New OperationalLimitList(GoodsID, OperationID, OperationType, ValuationMethod, _
                AccountingMethod, GoodsName, OperationDate, WarehouseID, parentValidator, myData)
        End Function

        Friend Shared Function GetDataSourceForComplexOperation( _
            ByVal ComplexOperationID As Integer, ByVal ComplexOperationDate As Date) As DataTable

            Dim myComm As New SQLCommand("FetchOperationalLimitListOldComplex")
            myComm.AddParam("?CD", ComplexOperationID)
            myComm.AddParam("?DT", ComplexOperationDate.Date)

            Return myComm.Fetch

        End Function

        Friend Shared Function GetDataSourceForNewInventorization( _
            ByVal WarehouseID As Integer) As DataTable

            Dim myComm As New SQLCommand("FetchOperationalLimitListNewInventorization")
            myComm.AddParam("?WD", WarehouseID)

            Return myComm.Fetch

        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal GoodsID As Integer, ByVal OperationID As Integer, _
            ByVal OperationType As GoodsOperationType, _
            ByVal ValuationMethod As GoodsValuationMethod, _
            ByVal AccountingMethod As GoodsAccountingMethod, _
            ByVal GoodsName As String, ByVal OperationDate As Date, _
            ByVal WarehouseID As Integer, ByVal parentValidator As IChronologicValidator)
            ' require use of factory methods
            Fetch(GoodsID, OperationID, OperationType, ValuationMethod, _
                AccountingMethod, GoodsName, OperationDate, WarehouseID, parentValidator)
        End Sub

        Private Sub New(ByVal GoodsID As Integer, ByVal OperationID As Integer, _
            ByVal OperationType As GoodsOperationType, ByVal ValuationMethod As GoodsValuationMethod, _
            ByVal AccountingMethod As GoodsAccountingMethod, ByVal GoodsName As String, _
            ByVal OperationDate As Date, ByVal WarehouseID As Integer, _
            ByVal parentValidator As IChronologicValidator, ByVal myData As DataTable)
            ' require use of factory methods
            Fetch(GoodsID, OperationID, OperationType, ValuationMethod, _
                AccountingMethod, GoodsName, OperationDate, WarehouseID, parentValidator, myData)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal GoodsID As Integer, ByVal OperationID As Integer, _
            ByVal OperationType As GoodsOperationType, ByVal ValuationMethod As GoodsValuationMethod, _
            ByVal AccountingMethod As GoodsAccountingMethod, ByVal GoodsName As String, _
            ByVal OperationDate As Date, ByVal WarehouseID As Integer, _
            ByVal parentValidator As IChronologicValidator)

            Dim myComm As SQLCommand

            If OperationID > 0 Then

                myComm = New SQLCommand("FetchOperationalLimitListOld")
                myComm.AddParam("?DT", OperationDate.Date)

                If OperationType = GoodsOperationType.AccountDiscountsChange _
                    OrElse OperationType = GoodsOperationType.AccountPurchasesChange _
                    OrElse OperationType = GoodsOperationType.AccountSalesNetCostsChange _
                    OrElse OperationType = GoodsOperationType.AccountValueReductionChange Then
                    myComm.AddParam("?OD", 0)
                    myComm.AddParam("?VD", 0)
                    myComm.AddParam("?AD", OperationID)
                ElseIf OperationType = GoodsOperationType.ValuationMethodChange Then
                    myComm.AddParam("?OD", 0)
                    myComm.AddParam("?VD", OperationID)
                    myComm.AddParam("?AD", 0)
                Else
                    myComm.AddParam("?OD", OperationID)
                    myComm.AddParam("?VD", 0)
                    myComm.AddParam("?AD", 0)
                End If

            Else

                myComm = New SQLCommand("FetchOperationalLimitListNew")

            End If

            myComm.AddParam("?GD", GoodsID)

            Using myData As DataTable = myComm.Fetch

                Fetch(GoodsID, OperationID, OperationType, ValuationMethod, AccountingMethod, _
                    GoodsName, OperationDate, WarehouseID, parentValidator, myData)

            End Using

        End Sub

        Private Sub Fetch(ByVal GoodsID As Integer, ByVal OperationID As Integer, _
            ByVal OperationType As GoodsOperationType, ByVal ValuationMethod As GoodsValuationMethod, _
            ByVal AccountingMethod As GoodsAccountingMethod, ByVal GoodsName As String, _
            ByVal OperationDate As Date, ByVal WarehouseID As Integer, _
            ByVal parentValidator As IChronologicValidator, ByVal myData As DataTable)

            RaiseListChangedEvents = False
            IsReadOnly = False

            _ConsignmentWasUsed = False
            _ConsignmentWasUsedDate = Date.MaxValue

            For Each dr As DataRow In myData.Rows
                If CIntSafe(dr.Item(0), 0) = GoodsID Then
                    If CIntSafe(dr.Item(1), 0) = 999 Then
                        _ConsignmentWasUsed = ConvertDbBoolean(CIntSafe(dr.Item(2), 0))
                        _ConsignmentWasUsedDate = CDateSafe(dr.Item(3), Date.MaxValue)
                    ElseIf Not ExcludeItem(dr, OperationID, OperationDate) Then
                        Add(OperationalLimit.GetOperationalLimit(dr))
                    End If
                End If
            Next

            _CurrentOperationType = OperationType
            _CurrentValuationMethod = ValuationMethod
            _CurrentAccountingMethod = AccountingMethod
            _CurrentGoodsName = GoodsName
            _CurrentOperationID = OperationID
            _CurrentGoodsID = GoodsID
            _CurrentOperationDate = OperationDate
            _CurrentWarehouseID = WarehouseID
            _CurrentOperationName = GoodsName & " " & ConvertEnumHumanReadable(OperationType)

            _BaseValidator = parentValidator
            If _BaseValidator Is Nothing AndAlso _CurrentOperationType <> GoodsOperationType.Acquisition _
                AndAlso _CurrentOperationType <> GoodsOperationType.ConsignmentAdditionalCosts _
                AndAlso _CurrentOperationType <> GoodsOperationType.ConsignmentDiscount _
                AndAlso _CurrentOperationType <> GoodsOperationType.Inventorization _
                AndAlso _CurrentOperationType <> GoodsOperationType.Transfer _
                AndAlso _CurrentOperationType <> GoodsOperationType.ValuationMethodChange _
                AndAlso (_CurrentOperationType <> GoodsOperationType.Discard OrElse _
                _CurrentAccountingMethod = GoodsAccountingMethod.Persistent) Then _
                _BaseValidator = SimpleChronologicValidator.GetSimpleChronologicValidator( _
                OperationID, OperationDate, _CurrentOperationName)

            _BackgroundExplanation = GetBackgroundDescription()

            FetchLimitations()

            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub


        Private Function ExcludeItem(ByVal dr As DataRow, ByVal OperationID As Integer, _
            ByVal OperationDate As Date) As Boolean

            If Not OperationID > 0 Then Return False

            Dim t As GoodsOperationType = ConvertEnumDatabaseCode(Of GoodsOperationType) _
                (CIntSafe(dr.Item(1), 0))
            Dim d As Date = CDateSafe(dr.Item(3), Date.MinValue)

            If d = Date.MinValue Then Return True

            If d.Date = OperationDate.Date AndAlso t <> GoodsOperationType.AccountDiscountsChange _
                AndAlso t <> GoodsOperationType.AccountPurchasesChange _
                AndAlso t <> GoodsOperationType.AccountSalesNetCostsChange _
                AndAlso t <> GoodsOperationType.Inventorization _
                AndAlso t <> GoodsOperationType.ValuationMethodChange Then Return True

            Return False

        End Function


        Private Sub FetchLimitations()

            SetDefaults()

            If _CurrentOperationID > 0 Then

                Select Case _CurrentOperationType
                    Case GoodsOperationType.Acquisition
                        FetchLimitationsForOldAcquisition()
                    Case GoodsOperationType.Transfer, GoodsOperationType.Discard
                        FetchLimitationsForOldTransferDiscard()
                    Case GoodsOperationType.ConsignmentAdditionalCosts
                        FetchLimitationsForOldAdditionalCosts()
                    Case GoodsOperationType.ConsignmentDiscount
                        FetchLimitationsForOldDiscount()
                    Case GoodsOperationType.Inventorization
                        FetchLimitationsForOldInventorization()
                    Case GoodsOperationType.ValuationMethodChange
                        FetchLimitationsForOldValuationMethod()
                    Case GoodsOperationType.PriceCut
                        FetchLimitationsForOldPriceCut()
                    Case GoodsOperationType.AccountValueReductionChange
                        FetchLimitationsForOldAccountValueReduction()
                    Case GoodsOperationType.AccountDiscountsChange
                        FetchLimitationsForOldAccountDiscounts()
                    Case GoodsOperationType.AccountPurchasesChange
                        FetchLimitationsForOldAccountPurchases()
                    Case GoodsOperationType.AccountSalesNetCostsChange
                        FetchLimitationsForOldAccountSalesNetCosts()
                    Case GoodsOperationType.TransferOfBalance
                        FetchLimitationsForOldTransferOfBalance()
                    Case Else
                        Throw New NotImplementedException("Prekių operacijos tipas '" _
                            & _CurrentOperationType.ToString & "' neimplementuotas metode " _
                            & "OperationalLimitList.FetchLimitations .")
                End Select

            Else

                Select Case _CurrentOperationType
                    Case GoodsOperationType.Acquisition
                        FetchLimitationsForNewAcquisition()
                    Case GoodsOperationType.Transfer, GoodsOperationType.Discard
                        FetchLimitationsForNewTransferDiscard()
                    Case GoodsOperationType.ConsignmentAdditionalCosts
                        FetchLimitationsForNewAdditionalCosts()
                    Case GoodsOperationType.ConsignmentDiscount
                        FetchLimitationsForNewDiscount()
                    Case GoodsOperationType.Inventorization
                        FetchLimitationsForNewInventorization()
                    Case GoodsOperationType.ValuationMethodChange
                        FetchLimitationsForNewValuationMethod()
                    Case GoodsOperationType.PriceCut
                        FetchLimitationsForNewPriceCut()
                    Case GoodsOperationType.AccountValueReductionChange
                        FetchLimitationsForNewAccountValueReduction()
                    Case GoodsOperationType.AccountDiscountsChange
                        FetchLimitationsForNewAccountDiscounts()
                    Case GoodsOperationType.AccountPurchasesChange
                        FetchLimitationsForNewAccountPurchases()
                    Case GoodsOperationType.AccountSalesNetCostsChange
                        FetchLimitationsForNewAccountSalesNetCosts()
                    Case GoodsOperationType.TransferOfBalance
                        FetchLimitationsForNewTransferOfBalance()
                    Case Else
                        Throw New NotImplementedException("Prekių operacijos tipas '" _
                            & _CurrentOperationType.ToString & "' neimplementuotas metode " _
                            & "OperationalLimitList.FetchLimitations .")
                End Select

            End If

            If _CurrentOperationType <> GoodsOperationType.TransferOfBalance Then

                SetMinDateApplicable(GetMinDate(_CurrentWarehouseID, OperationChronologyType.Overall, _
                    GoodsOperationType.TransferOfBalance), "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota prekių likučių perkėlimo " _
                    & "operacija.", True)

            End If

            If Not _BaseValidator Is Nothing AndAlso _
                (_CurrentOperationType = GoodsOperationType.AccountDiscountsChange _
                OrElse _CurrentOperationType = GoodsOperationType.AccountPurchasesChange _
                OrElse _CurrentOperationType = GoodsOperationType.AccountSalesNetCostsChange _
                OrElse _CurrentOperationType = GoodsOperationType.AccountValueReductionChange _
                OrElse _CurrentOperationType = GoodsOperationType.PriceCut _
                OrElse (_CurrentOperationType = GoodsOperationType.Discard AndAlso _
                _CurrentAccountingMethod = GoodsAccountingMethod.Persistent)) Then

                If Not _BaseValidator.FinancialDataCanChange Then

                    _FinancialDataCanChange = False
                    _FinancialDataCanChangeExplanation = AddWithNewLine(_FinancialDataCanChangeExplanation, _
                        _BaseValidator.FinancialDataCanChangeExplanation, False)
                    _ParentFinancialDataCanChange = False
                    _ParentFinancialDataCanChangeExplanation = AddWithNewLine(_FinancialDataCanChangeExplanation, _
                        _BaseValidator.FinancialDataCanChangeExplanation, False)

                End If

                If _BaseValidator.MaxDateApplicable Then SetMaxDateApplicable( _
                    _BaseValidator.MaxDate, _BaseValidator.MaxDateExplanation, False)

                If _BaseValidator.MinDateApplicable Then SetMinDateApplicable( _
                    _BaseValidator.MinDate, _BaseValidator.MinDateExplanation, False)

            End If

            SetLimitsExplanation()

        End Sub

        Private Sub SetDefaults()

            _FinancialDataCanChange = True
            _FinancialDataCanChangeExplanation = ""
            _ParentFinancialDataCanChange = True
            _ParentFinancialDataCanChangeExplanation = ""

            _MaxDateApplicable = False
            _MaxDate = Date.MaxValue
            _MaxDateExplanation = ""

            _MinDateApplicable = False
            _MinDate = Date.MinValue
            _MinDateExplanation = ""

            _LimitsExplanation = ""

        End Sub

        Private Sub SetMaxDateApplicable(ByVal nDate As Date, ByVal nExplanation As String, _
            ByVal AddOneDay As Boolean)

            If nDate = Date.MaxValue OrElse nDate = Date.MinValue Then Exit Sub

            If AddOneDay Then nDate.AddDays(-1)

            If Not nDate.Date < _MaxDate.Date Then Exit Sub

            _MaxDateApplicable = True
            _MaxDate = nDate.Date
            _MaxDateExplanation = nExplanation.Replace(DatePlaceHolder, nDate.ToString("yyyy-MM-dd"))

        End Sub

        Private Sub SetMinDateApplicable(ByVal nDate As Date, ByVal nExplanation As String, _
            ByVal AddOneDay As Boolean)

            If nDate = Date.MaxValue OrElse nDate = Date.MinValue Then Exit Sub

            If AddOneDay Then nDate.AddDays(1)

            If Not nDate.Date > _MinDate.Date Then Exit Sub

            _MinDateApplicable = True
            _MinDate = nDate.Date
            _MinDateExplanation = nExplanation.Replace(DatePlaceHolder, nDate.ToString("yyyy-MM-dd"))

        End Sub

        Private Sub SetFinancialDataCanChange(ByVal nDate As Date, ByVal nExplanation As String, _
            ByVal nDateExplanation As String, ByVal AddOneDay As Boolean)

            If nDate = Date.MaxValue OrElse nDate = Date.MinValue OrElse nExplanation Is Nothing _
                OrElse String.IsNullOrEmpty(nExplanation.Trim) Then Exit Sub

            _FinancialDataCanChange = False
            _FinancialDataCanChangeExplanation = AddWithNewLine(_FinancialDataCanChangeExplanation, _
                nExplanation, False)

            SetMaxDateApplicable(nDate, nDateExplanation, AddOneDay)

        End Sub

        Private Sub SetLimitsExplanation()

            _LimitsExplanation = ""
            If Not _FinancialDataCanChange Then _LimitsExplanation = _FinancialDataCanChangeExplanation
            If _MinDateApplicable Then _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _
                _MinDateExplanation, False)
            If _MaxDateApplicable Then _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _
                 _MaxDateExplanation, False)

        End Sub


        Private Sub FetchLimitationsForNewAcquisition()

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.AccountPurchasesChange, _
                    GoodsOperationType.Inventorization)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

                If _CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.Overall, GoodsOperationType.Acquisition, _
                        GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                        GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                        & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                Else

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.Overall, GoodsOperationType.Discard, _
                        GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                        GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes prieš ją yra registruota nurašymo ir/arba perleidimo " _
                        & " ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                End If

            End If

        End Sub

        Private Sub FetchLimitationsForOldAcquisition()

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            If _ConsignmentWasUsed Then SetFinancialDataCanChange(_ConsignmentWasUsedDate, _
                "Finansinių operacijos duomenų keisti negalima, nes kita operacija panaudojo " _
                & "šią prekių partiją.", "Maksimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes kita operacija panaudojo šią prekių partiją.", False)

            Dim InventorizationDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Inventorization)

            SetFinancialDataCanChange(InventorizationDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota inventorizacijos operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota inventorizacijos operacija.", False)

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim AccountChangeDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.AccountPurchasesChange)

                SetFinancialDataCanChange(AccountChangeDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota apskaitos sąskaitų pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota apskaitos sąskaitų pakeitimo operacija.", False)

            Else

                Dim ValuationMethodDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.ValuationMethodChange)

                SetFinancialDataCanChange(ValuationMethodDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota vertinimo metodo pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota vertinimo metodo pakeitimo operacija.", False)

            End If

            ' Check for subsequent operations that create max date limit without preventing financial changes

            If InventorizationDate <> Date.MinValue AndAlso InventorizationDate <> Date.MaxValue Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių operacija (-os), " _
                    & "o vėlesne data yra registruota inventorizacijos operacija.", False)

            ElseIf _CurrentAccountingMethod = GoodsAccountingMethod.Persistent AndAlso _
                Me._CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių įsigijimo ir/ar " _
                    & "perleidimo ir/ar nurašymo operacija (-os)." , False)

            ElseIf _CurrentAccountingMethod = GoodsAccountingMethod.Persistent Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Discard, _
                    GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                    GoodsOperationType.ConsignmentDiscount)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių " _
                    & "perleidimo ir/ar nurašymo operacija (-os).", False)

            End If

            ' Check for preceding operations that create min date limit 

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.AccountPurchasesChange, _
                    GoodsOperationType.Inventorization)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

                If _CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.LastBefore, GoodsOperationType.Acquisition, _
                        GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                        GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                        & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                Else

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.LastBefore, GoodsOperationType.Discard, _
                        GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                        GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes prieš ją yra registruota nurašymo ir/arba perleidimo " _
                        & " ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                End If

            End If

        End Sub

        Private Sub FetchLimitationsForNewTransferDiscard()

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.Inventorization)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota inventorizacijos operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

                If _CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.Overall, GoodsOperationType.Acquisition, _
                        GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                        GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                        & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                Else

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.Overall, GoodsOperationType.Discard, _
                        GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                        GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes prieš ją yra registruota nurašymo ir/arba perleidimo " _
                        & " ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                End If

            End If

        End Sub

        Private Sub FetchLimitationsForOldTransferDiscard()

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            Dim InventorizationDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Inventorization)

            SetFinancialDataCanChange(InventorizationDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota inventorizacijos operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota inventorizacijos operacija.", False)

            If _CurrentAccountingMethod = GoodsAccountingMethod.Persistent Then

                Dim ValuationMethodDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.ValuationMethodChange)

                SetFinancialDataCanChange(ValuationMethodDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota vertinimo metodo pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota vertinimo metodo pakeitimo operacija.", False)

            End If

            ' Check for subsequent operations that create max date limit without preventing financial changes

            If InventorizationDate <> Date.MinValue AndAlso InventorizationDate <> Date.MaxValue Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių operacija (-os), " _
                    & "o vėlesne data yra registruota inventorizacijos operacija.", False)

            ElseIf _CurrentAccountingMethod = GoodsAccountingMethod.Persistent AndAlso _
                Me._CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių įsigijimo ir/ar " _
                    & "perleidimo ir/ar nurašymo ir/arba savikainos padidinimo ir/arba nuolaidos operacija (-os).", False)

            ElseIf _CurrentAccountingMethod = GoodsAccountingMethod.Persistent Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Discard, _
                    GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                    GoodsOperationType.ConsignmentDiscount)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių " _
                    & "perleidimo ir/ar nurašymo ir/arba savikainos padidinimo ir/arba nuolaidos operacija (-os).", False)

            End If

            ' Check for preceding operations that create min date limit 

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.Inventorization)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota inventorizacijos operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

                If _CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.LastBefore, GoodsOperationType.Acquisition, _
                        GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                        GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                        & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                Else

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.LastBefore, GoodsOperationType.Discard, _
                        GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                        GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes prieš ją yra registruota nurašymo ir/arba perleidimo " _
                        & " ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                End If

            End If

        End Sub

        Private Sub FetchLimitationsForNewAdditionalCosts()

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                    GoodsOperationType.AccountPurchasesChange, GoodsOperationType.AccountSalesNetCostsChange)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota inventorizacijos " _
                    & "ir/ar apskaitos sąskaitų pakeitimo operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

                If _CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.Overall, GoodsOperationType.Acquisition, _
                        GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                        GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                        & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                Else

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.Overall, GoodsOperationType.Discard, _
                        GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                        GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes prieš ją yra registruota nurašymo ir/arba perleidimo " _
                        & " ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                End If

            End If

        End Sub

        Private Sub FetchLimitationsForOldAdditionalCosts()

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            If _ConsignmentWasUsed Then SetFinancialDataCanChange(_ConsignmentWasUsedDate, _
                "Finansinių operacijos duomenų keisti negalima, nes kita operacija panaudojo " _
                & "šią prekių partiją.", "Maksimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes kita operacija panaudojo šią prekių partiją.", False)

            Dim InventorizationDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Inventorization)

            SetFinancialDataCanChange(InventorizationDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota inventorizacijos operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota inventorizacijos operacija.", False)

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim AccountChangeDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.AccountPurchasesChange, _
                    GoodsOperationType.AccountSalesNetCostsChange)

                SetFinancialDataCanChange(AccountChangeDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota apskaitos sąskaitų pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota apskaitos sąskaitų pakeitimo operacija.", False)

            Else

                Dim ValuationMethodDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.ValuationMethodChange)

                SetFinancialDataCanChange(ValuationMethodDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota vertinimo metodo pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota vertinimo metodo pakeitimo operacija.", False)

            End If

            ' Check for subsequent operations that create max date limit without preventing financial changes

            If InventorizationDate <> Date.MinValue AndAlso InventorizationDate <> Date.MaxValue Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių operacija (-os), " _
                    & "o vėlesne data yra registruota inventorizacijos operacija.", False)

            ElseIf _CurrentAccountingMethod = GoodsAccountingMethod.Persistent AndAlso _
                Me._CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių įsigijimo ir/ar " _
                    & "perleidimo ir/ar nurašymo operacija (-os).", False)

            ElseIf _CurrentAccountingMethod = GoodsAccountingMethod.Persistent Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Discard, _
                    GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                    GoodsOperationType.ConsignmentDiscount)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių " _
                    & "perleidimo ir/ar nurašymo operacija (-os).", False)

            End If

            ' Check for preceding operations that create min date limit 

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.AccountPurchasesChange, _
                    GoodsOperationType.Inventorization, GoodsOperationType.AccountSalesNetCostsChange)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

                If _CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.LastBefore, GoodsOperationType.Acquisition, _
                        GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                        GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                        & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                Else

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.LastBefore, GoodsOperationType.Discard, _
                        GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                        GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes prieš ją yra registruota nurašymo ir/arba perleidimo " _
                        & " ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                End If

            End If

        End Sub

        Private Sub FetchLimitationsForNewDiscount()

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                    GoodsOperationType.AccountDiscountsChange, GoodsOperationType.AccountSalesNetCostsChange)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota inventorizacijos " _
                    & "ir/ar apskaitos sąskaitų pakeitimo operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

                If _CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.Overall, GoodsOperationType.Acquisition, _
                        GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                        GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                        & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                Else

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.Overall, GoodsOperationType.Discard, _
                        GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                        GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes prieš ją yra registruota nurašymo ir/arba perleidimo " _
                        & " ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                End If

            End If

        End Sub

        Private Sub FetchLimitationsForOldDiscount()

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            If _ConsignmentWasUsed Then SetFinancialDataCanChange(_ConsignmentWasUsedDate, _
                "Finansinių operacijos duomenų keisti negalima, nes kita operacija panaudojo " _
                & "šią prekių partiją.", "Maksimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes kita operacija panaudojo šią prekių partiją.", False)

            Dim InventorizationDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Inventorization)

            SetFinancialDataCanChange(InventorizationDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota inventorizacijos operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota inventorizacijos operacija.", False)

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim AccountChangeDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.AccountDiscountsChange, _
                    GoodsOperationType.AccountSalesNetCostsChange)

                SetFinancialDataCanChange(AccountChangeDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota apskaitos sąskaitų pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota apskaitos sąskaitų pakeitimo operacija.", False)

            Else

                Dim ValuationMethodDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.ValuationMethodChange)

                SetFinancialDataCanChange(ValuationMethodDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota vertinimo metodo pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota vertinimo metodo pakeitimo operacija.", False)

            End If

            ' Check for subsequent operations that create max date limit without preventing financial changes

            If InventorizationDate <> Date.MinValue AndAlso InventorizationDate <> Date.MaxValue Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių operacija (-os), " _
                    & "o vėlesne data yra registruota inventorizacijos operacija.", False)

            ElseIf _CurrentAccountingMethod = GoodsAccountingMethod.Persistent AndAlso _
                Me._CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių įsigijimo ir/ar " _
                    & "perleidimo ir/ar nurašymo operacija (-os).", False)

            ElseIf _CurrentAccountingMethod = GoodsAccountingMethod.Persistent Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Discard, _
                    GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                    GoodsOperationType.ConsignmentDiscount)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių " _
                    & "perleidimo ir/ar nurašymo operacija (-os).", False)

            End If

            ' Check for preceding operations that create min date limit 

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.AccountDiscountsChange, _
                    GoodsOperationType.Inventorization, GoodsOperationType.AccountSalesNetCostsChange)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

                If _CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.LastBefore, GoodsOperationType.Acquisition, _
                        GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                        GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                        & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                Else

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.LastBefore, GoodsOperationType.Discard, _
                        GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                        GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes prieš ją yra registruota nurašymo ir/arba perleidimo " _
                        & " ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                End If

            End If

        End Sub

        Private Sub FetchLimitationsForNewInventorization()

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.AccountPurchasesChange, _
                    GoodsOperationType.AccountDiscountsChange, _
                    GoodsOperationType.AccountSalesNetCostsChange, _
                    GoodsOperationType.Inventorization, GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                    & "ir/arba apskaitos sąskaitos pakeitimo ir/arba inventorizacijos ir/arba " _
                    & "vertinimo metodo pakeitimo operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

            End If

            Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.Acquisition, _
                GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

            SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes šia data yra registruota prekių operacijų.", False)

        End Sub

        Private Sub FetchLimitationsForOldInventorization()

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            If _ConsignmentWasUsed Then SetFinancialDataCanChange(_ConsignmentWasUsedDate, _
                "Finansinių operacijos duomenų keisti negalima, nes kita operacija panaudojo " _
                & "šią prekių partiją.", "Maksimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes kita operacija panaudojo šią prekių partiją.", False)

            Dim InventorizationDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Inventorization)

            SetFinancialDataCanChange(InventorizationDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota inventorizacijos operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota inventorizacijos operacija.", False)

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim AccountChangeDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.AccountPurchasesChange, _
                    GoodsOperationType.AccountSalesNetCostsChange, GoodsOperationType.AccountDiscountsChange, _
                    GoodsOperationType.ValuationMethodChange)

                SetFinancialDataCanChange(AccountChangeDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota apskaitos sąskaitų pakeitimo " _
                    & "ir/ar vertinimo metodo pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota apskaitos sąskaitų pakeitimo ir/ar vertinimo metodo pakeitimo operacija.", False)

            Else

                Dim ValuationMethodDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.ValuationMethodChange)

                SetFinancialDataCanChange(ValuationMethodDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota vertinimo metodo pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota vertinimo metodo pakeitimo operacija.", False)

            End If

            ' Check for subsequent operations that create max date limit without preventing financial changes

            Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

            SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes po jos yra registruota prekių įsigijimo ir/ar " _
                & "perleidimo ir/ar nurašymo operacija (-os).", True)

            ' Check for preceding operations that create min date limit 

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.AccountPurchasesChange, _
                    GoodsOperationType.Inventorization, GoodsOperationType.AccountDiscountsChange, _
                    GoodsOperationType.AccountSalesNetCostsChange)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

            End If

            Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.LastBefore, GoodsOperationType.Acquisition, _
                GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

            SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

        End Sub

        Private Sub FetchLimitationsForNewValuationMethod()

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                GoodsOperationType.ValuationMethodChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota inventorizacijos " _
                & "ir/ar vertinimo metodo pakeitimo operacija.", True)

            If _CurrentAccountingMethod = GoodsAccountingMethod.Persistent Then

                Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.Acquisition, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                    & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", True)

            End If

        End Sub

        Private Sub FetchLimitationsForOldValuationMethod()

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            Dim InventorizationDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Inventorization)

            SetFinancialDataCanChange(InventorizationDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota inventorizacijos operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota inventorizacijos operacija.", False)

            Dim ValuationMethodDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.ValuationMethodChange)

            SetFinancialDataCanChange(ValuationMethodDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota vertinimo metodo pakeitimo operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes po jos " _
                & "yra registruota vertinimo metodo pakeitimo operacija.", True)

            ' Check for subsequent operations that create max date limit without preventing financial changes

            Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

            SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes po jos yra registruota prekių įsigijimo ir/ar " _
                & "perleidimo ir/ar nurašymo operacija (-os).", True)

            ' Check for preceding operations that create min date limit 

            Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.LastBefore, GoodsOperationType.Inventorization, _
                GoodsOperationType.ValuationMethodChange)

            SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes šia data yra registruota vertinimo metodo pakeitimo " _
                & "ir/arba inventorizacijos operacija.", True)

            Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.LastBefore, GoodsOperationType.Acquisition, _
                GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

            SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes po jos yra registruota įsigijimo ir/arba nurašymo " _
                & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", True)

        End Sub

        Private Sub FetchLimitationsForNewPriceCut()

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.AccountValueReductionChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

        End Sub

        Private Sub FetchLimitationsForOldPriceCut()

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            Dim AccountChangeDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.AccountValueReductionChange)

            SetFinancialDataCanChange(AccountChangeDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota apskaitos sąskaitų pakeitimo operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes po to " _
                & "yra registruota apskaitos sąskaitų pakeitimo operacija.", True)
            
            ' Check for subsequent operations that create max date limit without preventing financial changes

            ' NONE

            ' Check for preceding operations that create min date limit 

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.LastBefore, GoodsOperationType.AccountValueReductionChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

        End Sub

        Private Sub FetchLimitationsForNewAccountValueReduction()

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.AccountValueReductionChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

            LastSignificantDate = GetMaxDate(_CurrentWarehouseID, OperationChronologyType.Overall, _
                GoodsOperationType.PriceCut)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota nukainojimo operacija.", False)

        End Sub

        Private Sub FetchLimitationsForOldAccountValueReduction()

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            Dim AccountChangeDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.AccountValueReductionChange, _
                GoodsOperationType.PriceCut)

            SetFinancialDataCanChange(AccountChangeDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota apskaitos sąskaitų pakeitimo ir/ar nukainojimo operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes po to " _
                & "yra registruota apskaitos sąskaitų pakeitimo ir/ar nukainojimo operacija.", True)

            ' Check for subsequent operations that create max date limit without preventing financial changes

            ' NONE

            ' Check for preceding operations that create min date limit 

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.LastBefore, GoodsOperationType.AccountValueReductionChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

            LastSignificantDate = GetMaxDate(_CurrentWarehouseID, OperationChronologyType.LastBefore, _
                GoodsOperationType.PriceCut)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota nukainojimo operacija.", False)

        End Sub

        Private Sub FetchLimitationsForNewAccountDiscounts()

            If _CurrentAccountingMethod <> GoodsAccountingMethod.Periodic Then Exit Sub

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.AccountDiscountsChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

            LastSignificantDate = GetMaxDate(_CurrentWarehouseID, OperationChronologyType.Overall, _
                GoodsOperationType.Inventorization, GoodsOperationType.ConsignmentDiscount)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota nuolaidos ir/arba " _
                & "inventorizacijos operacija.", False)

        End Sub

        Private Sub FetchLimitationsForOldAccountDiscounts()

            If _CurrentAccountingMethod <> GoodsAccountingMethod.Periodic Then Exit Sub

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            Dim InventorizationDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Inventorization, _
                GoodsOperationType.ConsignmentDiscount)

            SetFinancialDataCanChange(InventorizationDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes šia data yra registruota inventorizacijos ir/ar nuolaidos operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota inventorizacijos ir/ar nuolaidos operacija.", False)

            Dim AccountChangeDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.AccountDiscountsChange)

            SetFinancialDataCanChange(AccountChangeDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota apskaitos sąskaitų pakeitimo operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes po to " _
                & "yra registruota apskaitos sąskaitų pakeitimo operacija.", True)

            ' Check for subsequent operations that create max date limit without preventing financial changes

            ' NONE

            ' Check for preceding operations that create min date limit 

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.LastBefore, GoodsOperationType.AccountDiscountsChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

            LastSignificantDate = GetMaxDate(_CurrentWarehouseID, OperationChronologyType.LastBefore, _
                GoodsOperationType.Inventorization, GoodsOperationType.ConsignmentDiscount)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota nuolaidos ir/arba " _
                & "inventorizacijos operacija.", False)

        End Sub

        Private Sub FetchLimitationsForNewAccountPurchases()

            If _CurrentAccountingMethod <> GoodsAccountingMethod.Periodic Then Exit Sub

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.AccountPurchasesChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

            LastSignificantDate = GetMaxDate(_CurrentWarehouseID, OperationChronologyType.Overall, _
                GoodsOperationType.Inventorization, GoodsOperationType.Acquisition, _
                GoodsOperationType.ConsignmentAdditionalCosts)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota įsigijimo ir/arba savikainos " _
                & "padidinimo ir/arba inventorizacijos operacija.", False)

        End Sub

        Private Sub FetchLimitationsForOldAccountPurchases()

            If _CurrentAccountingMethod <> GoodsAccountingMethod.Periodic Then Exit Sub

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            Dim InventorizationDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Inventorization, _
                GoodsOperationType.Acquisition, GoodsOperationType.ConsignmentAdditionalCosts)

            SetFinancialDataCanChange(InventorizationDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes šia data yra registruota inventorizacijos ir/ar įsigijimo ir/ar " _
                & "savikainos padidinimo operacija.", "Maksimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes šia data yra registruota inventorizacijos ir/ar " _
                & "įsigijimo ir/ar savikainos padidinimo operacija.", False)

            Dim AccountChangeDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.AccountPurchasesChange)

            SetFinancialDataCanChange(AccountChangeDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota apskaitos sąskaitų pakeitimo operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes po to " _
                & "yra registruota apskaitos sąskaitų pakeitimo operacija.", True)

            ' Check for subsequent operations that create max date limit without preventing financial changes

            ' NONE

            ' Check for preceding operations that create min date limit 

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.LastBefore, GoodsOperationType.AccountPurchasesChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

            LastSignificantDate = GetMaxDate(_CurrentWarehouseID, OperationChronologyType.LastBefore, _
                GoodsOperationType.Inventorization, GoodsOperationType.Acquisition, _
                GoodsOperationType.ConsignmentAdditionalCosts)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota įsigijimo ir/arba savikainos " _
                & "padidinimo ir/arba inventorizacijos operacija.", False)

        End Sub

        Private Sub FetchLimitationsForNewAccountSalesNetCosts()

            If _CurrentAccountingMethod <> GoodsAccountingMethod.Periodic Then Exit Sub

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.AccountSalesNetCostsChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

            LastSignificantDate = GetMaxDate(_CurrentWarehouseID, OperationChronologyType.Overall, _
                GoodsOperationType.Inventorization, GoodsOperationType.ConsignmentDiscount, _
                GoodsOperationType.ConsignmentAdditionalCosts)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota nuolaidos ir/arba savikainos " _
                & "padidinimo ir/arba inventorizacijos operacija.", False)

        End Sub

        Private Sub FetchLimitationsForOldAccountSalesNetCosts()

            If _CurrentAccountingMethod <> GoodsAccountingMethod.Periodic Then Exit Sub

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            Dim InventorizationDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Inventorization, _
                GoodsOperationType.ConsignmentDiscount, GoodsOperationType.ConsignmentAdditionalCosts)

            SetFinancialDataCanChange(InventorizationDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes šia data yra registruota inventorizacijos ir/ar nuolaidos ir/ar " _
                & "savikainos padidinimo operacija.", "Maksimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes šia data yra registruota inventorizacijos ir/ar " _
                & "nuolaidos ir/ar savikainos padidinimo operacija.", False)

            Dim AccountChangeDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.AccountSalesNetCostsChange)

            SetFinancialDataCanChange(AccountChangeDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota apskaitos sąskaitų pakeitimo operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes po to " _
                & "yra registruota apskaitos sąskaitų pakeitimo operacija.", True)

            ' Check for subsequent operations that create max date limit without preventing financial changes

            ' NONE

            ' Check for preceding operations that create min date limit 

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.LastBefore, GoodsOperationType.AccountSalesNetCostsChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

            LastSignificantDate = GetMaxDate(_CurrentWarehouseID, OperationChronologyType.LastBefore, _
                GoodsOperationType.Inventorization, GoodsOperationType.ConsignmentDiscount, _
                GoodsOperationType.ConsignmentAdditionalCosts)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota nuolaidos ir/arba savikainos " _
                & "padidinimo ir/arba inventorizacijos operacija.", False)

        End Sub

        Private Sub FetchLimitationsForNewTransferOfBalance()

            Dim FirstDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                GoodsOperationType.ConsignmentDiscount, GoodsOperationType.ConsignmentAdditionalCosts, _
                GoodsOperationType.AccountDiscountsChange, GoodsOperationType.AccountPurchasesChange, _
                GoodsOperationType.AccountSalesNetCostsChange, GoodsOperationType.AccountValueReductionChange, _
                GoodsOperationType.Acquisition, GoodsOperationType.Discard, GoodsOperationType.PriceCut, _
                GoodsOperationType.Transfer, GoodsOperationType.ValuationMethodChange)

            SetMaxDateApplicable(FirstDate, "Maksimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes po to yra registruota kitų prekių operacijų.", False)

        End Sub

        Private Sub FetchLimitationsForOldTransferOfBalance()

            Dim FirstDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                GoodsOperationType.ConsignmentDiscount, GoodsOperationType.ConsignmentAdditionalCosts, _
                GoodsOperationType.AccountDiscountsChange, GoodsOperationType.AccountPurchasesChange, _
                GoodsOperationType.AccountSalesNetCostsChange, GoodsOperationType.AccountValueReductionChange, _
                GoodsOperationType.Acquisition, GoodsOperationType.Discard, GoodsOperationType.PriceCut, _
                GoodsOperationType.Transfer, GoodsOperationType.ValuationMethodChange)

            SetFinancialDataCanChange(FirstDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota kitų operacijų su prekėmis.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes po to " _
                & "yra registruota kitų operacijų su prekėmis.", True)

        End Sub

#End Region

    End Class

End Namespace