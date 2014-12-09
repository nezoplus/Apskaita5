Namespace Assets

    <Serializable()> _
Public Class LongTermAssetAmortizationCalculation
        Inherits ReadOnlyBase(Of LongTermAssetAmortizationCalculation)

#Region " Business Methods "

        Private _AssetID As Integer
        Private _DateTo As Date
        Private _AmmortizationValue As Double = 0
        Private _AmmortizationValuePerUnit As Double = 0
        Private _AmmortizationValueRevaluedPortion As Double = 0
        Private _AmmortizationValuePerUnitRevaluedPortion As Double = 0
        Private _CalculationDescription As String = ""
        Private _AmortizationCalculatedForMonths As Integer


        Public ReadOnly Property AssetID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AssetID
            End Get
        End Property

        Public ReadOnly Property DateTo() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DateTo.Date
            End Get
        End Property

        Public ReadOnly Property AmmortizationValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmmortizationValue)
            End Get
        End Property

        Public ReadOnly Property AmmortizationValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmmortizationValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property AmmortizationValueRevaluedPortion() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmmortizationValueRevaluedPortion)
            End Get
        End Property

        Public ReadOnly Property AmmortizationValuePerUnitRevaluedPortion() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmmortizationValuePerUnitRevaluedPortion, ROUNDUNITASSET)
            End Get
        End Property

        Public ReadOnly Property AmortizationCalculatedForMonths() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AmortizationCalculatedForMonths
            End Get
        End Property

        Public ReadOnly Property CalculationDescription() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CalculationDescription.Trim
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _AssetID
        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Assets.LongTermAssetOperation2")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetLongTermAssetAmortizationCalculation( _
            ByVal nAssetID As Integer, ByVal nEditedAmortizationOperationID As Integer, _
            ByVal nDateTo As Date) As LongTermAssetAmortizationCalculation
            Return DataPortal.Fetch(Of LongTermAssetAmortizationCalculation)(New Criteria( _
                nAssetID, nEditedAmortizationOperationID, nDateTo))
        End Function

        Friend Shared Function GetLongTermAssetAmortizationCalculationServerSide( _
            ByVal nAssetID As Integer, ByVal nEditedAmortizationOperationID As Integer, _
            ByVal nDateTo As Date) As LongTermAssetAmortizationCalculation
            Return New LongTermAssetAmortizationCalculation(nAssetID, nDateTo, nEditedAmortizationOperationID)
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal nAssetID As Integer, ByVal nDateTo As Date, _
            ByVal nEditedAmortizationOperationID As Integer)
            Fetch(nAssetID, nDateTo, nEditedAmortizationOperationID)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _AssetID As Integer
            Private _EditedAmortizationOperationID As Integer
            Private _DateTo As Date
            Public ReadOnly Property AssetID() As Integer
                Get
                    Return _AssetID
                End Get
            End Property
            Public ReadOnly Property EditedAmortizationOperationID() As Integer
                Get
                    Return _EditedAmortizationOperationID
                End Get
            End Property
            Public ReadOnly Property DateTo() As Date
                Get
                    Return _DateTo
                End Get
            End Property
            Public Sub New(ByVal nAssetID As Integer, ByVal nEditedAmortizationOperationID As Integer, _
                ByVal nDateTo As Date)
                _AssetID = nAssetID
                _EditedAmortizationOperationID = nEditedAmortizationOperationID
                _DateTo = nDateTo.Date
            End Sub
        End Class


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)
            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai informacijai gauti.")
            Fetch(criteria.AssetID, criteria.DateTo, criteria.EditedAmortizationOperationID)
        End Sub

        Private Sub Fetch(ByVal nAssetID As Integer, ByVal nDateTo As Date, _
            ByVal nEditedAmortizationOperationID As Integer)

            If Not nAssetID > 0 Then Throw New Exception("Klaida. Nenurodytas turto ID.")

            _AssetID = nAssetID
            _DateTo = nDateTo

            Dim AssetName As String
            Dim AcquisitionValue As Double
            Dim AcquisitionValuePerUnit As Double
            Dim RevaluedPortionValue As Double
            Dim RevaluedPortionValuePerUnit As Double
            Dim Ammount As Integer
            Dim LiquidationValue As Double
            Dim IsUsed As Boolean
            Dim AmortizationPeriod As Integer
            Dim LastAmortizationDate As Date
            Dim AmortizationStartDate As Date
            Dim CurrentPeriodStartDate As Date
            Dim CurrentAmortizationCalculatedForMonths As Integer
            Dim AccumulatedAmortization As Double
            Dim AccumulatedAmortizationPerUnit As Double
            Dim AccumulatedAmortizationRevaluedPortion As Double
            Dim AccumulatedAmortizationRevaluedPortionPerUnit As Double
            Dim i, j As Integer


            ' fetch asset acquisition data
            Dim myComm As New SQLCommand("FetchLongTermAssetAmortization1")
            myComm.AddParam("?AD", nAssetID)
            myComm.AddParam("?MD", nEditedAmortizationOperationID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception( _
                    "Klaida. Nerasti turto duomenys, ID=" & nAssetID.ToString & ".")
                Dim dr As DataRow = myData.Rows(0)

                AcquisitionValue = CDblSafe(dr.Item(0), 2, 0)
                AcquisitionValuePerUnit = CDblSafe(dr.Item(1), ROUNDUNITASSET, 0)
                RevaluedPortionValue = CDblSafe(dr.Item(2), 2, 0)
                RevaluedPortionValuePerUnit = CDblSafe(dr.Item(3), ROUNDUNITASSET, 0)
                AccumulatedAmortization = CDblSafe(dr.Item(4), 2, 0)
                AccumulatedAmortizationPerUnit = CDblSafe(dr.Item(5), ROUNDUNITASSET, 0)
                AccumulatedAmortizationRevaluedPortion = CDblSafe(dr.Item(6), 2, 0)
                AccumulatedAmortizationRevaluedPortionPerUnit = CDblSafe(dr.Item(7), ROUNDUNITASSET, 0)
                Ammount = CIntSafe(dr.Item(8), 0)
                CurrentAmortizationCalculatedForMonths = CIntSafe(dr.Item(9), 0)
                IsUsed = ConvertDbBoolean(CIntSafe(dr.Item(10), 0))
                AmortizationPeriod = CIntSafe(dr.Item(11), 0)
                LiquidationValue = CDblSafe(dr.Item(12), 2, 0)

                LastAmortizationDate = Date.MinValue
                LastAmortizationDate = CDateSafe(dr.Item(13), Date.MinValue)

                AmortizationStartDate = CDate(dr.Item(14))

                AssetName = CStrSafe(dr.Item(16))

                If nDateTo.Date < AmortizationStartDate Then Throw New Exception( _
                    "Klaida. Neįmanoma apskaičiuoti amortizacijos ankstesne nei turto įsigijimo data (" _
                    & AssetName & ").")

                If Not IsDBNull(dr.Item(13)) AndAlso Not IsDBNull(dr.Item(15)) _
                    AndAlso CDate(dr.Item(13)).Date > CDate(dr.Item(15)).Date Then _
                    Throw New Exception("Klaida. Yra vėlesnė amortizacijos operacija už taisomą. " _
                    & "Amortizacijos perskaičiuoti neįmanoma (" & AssetName & ").")

            End Using

            ' if an amortization operation exists (except for the edited one 
            ' that is pointed by criteria.EditedAmortizationOperationID)
            ' then fetch asset status for the begining of the month after that amortization operation
            If LastAmortizationDate <> Date.MinValue Then

                If LastAmortizationDate.Month = 12 Then
                    AmortizationStartDate = New Date(LastAmortizationDate.Year + 1, 1, 1)
                Else
                    AmortizationStartDate = New Date(LastAmortizationDate.Year, _
                        LastAmortizationDate.Month + 1, 1)
                End If

                If nDateTo.Date < AmortizationStartDate.Date Then _
                    Throw New Exception("Klaida. Amortizacija nurodytai datai jau apskaičiuota. " _
                    & "Paskutinis amortizacijos apskaičiavimas buvo " & _
                    LastAmortizationDate.ToShortDateString & ", o jūs bandote skaičiuoti " _
                    & nDateTo.ToShortDateString & " (" & AssetName & ").")


                myComm = New SQLCommand("FetchLongTermAssetAmortization2")
                myComm.AddParam("?AD", nAssetID)
                myComm.AddParam("?DT", AmortizationStartDate.Date)

                Using myData As DataTable = myComm.Fetch

                    If myData.Rows.Count > 0 Then

                        Dim dr As DataRow = myData.Rows(0)

                        AcquisitionValue = CRound(AcquisitionValue + CDblSafe(dr.Item(0), 2, 0))
                        AcquisitionValuePerUnit = CRound(AcquisitionValuePerUnit _
                            + CDblSafe(dr.Item(1), ROUNDUNITASSET, 0), ROUNDUNITASSET)
                        RevaluedPortionValue = CRound(RevaluedPortionValue + CDblSafe(dr.Item(2), 2, 0))
                        RevaluedPortionValuePerUnit = CRound(RevaluedPortionValuePerUnit + _
                            CDblSafe(dr.Item(3), ROUNDUNITASSET, 0), ROUNDUNITASSET)
                        AccumulatedAmortization = CRound(AccumulatedAmortization + CDblSafe(dr.Item(4), 2, 0))
                        AccumulatedAmortizationPerUnit = CRound(AccumulatedAmortizationPerUnit + _
                            CDblSafe(dr.Item(5), ROUNDUNITASSET, 0), ROUNDUNITASSET)
                        AccumulatedAmortizationRevaluedPortion = _
                            CRound(AccumulatedAmortizationRevaluedPortion + CDblSafe(dr.Item(6), 2, 0))
                        AccumulatedAmortizationRevaluedPortionPerUnit = _
                            CRound(AccumulatedAmortizationRevaluedPortionPerUnit _
                            + CDblSafe(dr.Item(7), ROUNDUNITASSET, 0), ROUNDUNITASSET)
                        Ammount = Ammount - CIntSafe(dr.Item(8), 0)
                        CurrentAmortizationCalculatedForMonths = _
                            CurrentAmortizationCalculatedForMonths + CIntSafe(dr.Item(9), 0)

                        If Not IsDBNull(dr.Item(10)) AndAlso Math.Ceiling(CIntSafe(dr.Item(10), 0) / 2) _
                            <> Math.Floor(CIntSafe(dr.Item(10), 0) / 2) Then IsUsed = Not IsUsed

                        If Not IsDBNull(dr.Item(11)) Then AmortizationPeriod = CIntSafe(dr.Item(11), 0)

                    End If

                End Using

            Else

                ' if no amortization operation exists then start at the first day of the acquisition month
                AmortizationStartDate = New Date(AmortizationStartDate.Year, _
                    AmortizationStartDate.Month, 1)

            End If

            If CurrentAmortizationCalculatedForMonths >= AmortizationPeriod * 12 Then _
                Throw New Exception("Klaida. Turtas naudotas visą jam nustatytą " _
                    & "amortizacijos periodą, t.y. nudėvėtas (" & AssetName & ").")


            ' fetch all operations between amortization start date and calculation date
            myComm = New SQLCommand("FetchLongTermAssetAmortization3")
            myComm.AddParam("?AD", nAssetID)
            myComm.AddParam("?DT", AmortizationStartDate.Date)
            myComm.AddParam("?DE", New Date(nDateTo.Year, nDateTo.Month, 1))
            myComm.AddParam("?MD", nEditedAmortizationOperationID)

            Using myData As DataTable = myComm.Fetch

                _CalculationDescription = AssetName & " amortizacija pradedama skaičiuoti nuo "

                If IsUsed Then

                    If LastAmortizationDate <> Date.MinValue Then
                        _CalculationDescription = _CalculationDescription & _
                            "paskutinio amortizacijos apskaičiavimo datos "
                    Else
                        _CalculationDescription = _CalculationDescription & _
                            "turto įsigijimo datos "
                    End If

                Else

                    ' find the first usage operation
                    Dim UsageStartIsFound As Boolean = False
                    For i = 1 To myData.Rows.Count

                        If ConvertEnumDatabaseStringCode(Of LtaOperationType) _
                            (CStrSafe(myData.Rows(i - 1).Item(10)).Trim) = LtaOperationType.UsingStart Then

                            ' start calculation at that day
                            If CDate(myData.Rows(i - 1).Item(12)).Month = 12 Then
                                AmortizationStartDate = New Date(CDate(myData.Rows(i - 1).Item(12)).Year + 1, 1, 1)
                            Else
                                AmortizationStartDate = New Date(CDate(myData.Rows(i - 1).Item(12)).Year, _
                                    CDate(myData.Rows(i - 1).Item(12)).Month + 1, 1)
                            End If

                            ' update amortization variables to the usage period start day
                            For j = 1 To myData.Rows.Count
                                If CDate(myData.Rows(j - 1).Item(12)).Date < AmortizationStartDate.Date Then
                                    UpdateCurrentParamsWithOperation(myData.Rows(j - 1), _
                                        AcquisitionValue, AcquisitionValuePerUnit, RevaluedPortionValue, _
                                        RevaluedPortionValuePerUnit, AccumulatedAmortization, _
                                        AccumulatedAmortizationPerUnit, AccumulatedAmortizationRevaluedPortion, _
                                        AccumulatedAmortizationRevaluedPortionPerUnit, IsUsed, _
                                        AmortizationPeriod, Ammount, False, AssetName)
                                Else
                                    Exit For
                                End If
                            Next

                            UsageStartIsFound = True

                            Exit For

                        End If

                    Next

                    If Not UsageStartIsFound Then Throw New Exception( _
                        "Klaida. Amortizacijos skaičiavimo intervale turtas nebuvo naudojamas (" _
                        & AssetName & ").")

                    _CalculationDescription = _CalculationDescription & "perdavimo naudoti datos "

                End If

                ' first period day is either acquisition date, last amortization date or first usage operation date
                CurrentPeriodStartDate = AmortizationStartDate

                ' provide info of the begining of the first period
                _CalculationDescription = _CalculationDescription & _
                    AmortizationStartDate.ToShortDateString & _
                    ". Amortizuojamas kiekis - " & Ammount.ToString & ", vieneto likvidacinė vertė - " _
                    & DblParser(LiquidationValue) & ". Pradiniai skaičiavimo parametrai yra: " & _
                    GetCurrentParamsString(AcquisitionValue, AcquisitionValuePerUnit, _
                    RevaluedPortionValue, RevaluedPortionValuePerUnit, AccumulatedAmortization, _
                    AccumulatedAmortizationPerUnit, AccumulatedAmortizationRevaluedPortion, _
                    AccumulatedAmortizationRevaluedPortionPerUnit, IsUsed, AmortizationPeriod, _
                    CurrentAmortizationCalculatedForMonths) & " Vieno mėnesio amortizacijos suma - " _
                    & GetCurrentMonthAmortizationFormula(AcquisitionValue, RevaluedPortionValue, _
                    AccumulatedAmortization, AccumulatedAmortizationRevaluedPortion, AmortizationPeriod, _
                    CurrentAmortizationCalculatedForMonths, LiquidationValue, Ammount) _
                    & "; Vieno mėnesio amortizacijos suma turto vienetui - " _
                    & GetCurrentMonthAmortizationFormulaPerUnit(AcquisitionValuePerUnit, _
                    RevaluedPortionValuePerUnit, AccumulatedAmortizationPerUnit, _
                    AccumulatedAmortizationRevaluedPortionPerUnit, AmortizationPeriod, _
                    CurrentAmortizationCalculatedForMonths, LiquidationValue) & "."

                ' single period variables
                Dim PeriodLength As Integer
                Dim PeriodEndDate As Date
                Dim AmortizationPeriodEnded As Boolean
                Dim PeriodAmortization As Double
                Dim PeriodAmortizationPerUnit As Double
                Dim PeriodAmortizationRevaluedPortion As Double
                Dim PeriodAmortizationRevaluedPortionPerUnit As Double
                Dim OperationsInMonth As String

                Dim AmortizationPeriodIsOpen As Boolean = True

                For i = 1 To myData.Rows.Count
                    If CDate(myData.Rows(i - 1).Item(12)).Date >= CurrentPeriodStartDate.Date Then

                        If IsUsed Then

                            ' Evaluate current period length
                            PeriodLength = DateDifferenceInMonths(CurrentPeriodStartDate, _
                                CDate(myData.Rows(i - 1).Item(12)), True, True)
                            ' It can't be longer than total amortization period
                            If CurrentAmortizationCalculatedForMonths + PeriodLength >= AmortizationPeriod * 12 Then
                                AmortizationPeriodEnded = True
                                PeriodLength = (AmortizationPeriod * 12) - CurrentAmortizationCalculatedForMonths
                                PeriodEndDate = AddMonths(CurrentPeriodStartDate, PeriodLength - 1)
                            Else
                                AmortizationPeriodEnded = False
                                PeriodEndDate = New Date(CDate(myData.Rows(i - 1).Item(12)).Year, _
                                    CDate(myData.Rows(i - 1).Item(12)).Month, _
                                    Date.DaysInMonth(CDate(myData.Rows(i - 1).Item(12)).Year, _
                                    CDate(myData.Rows(i - 1).Item(12)).Month))
                            End If

                            ' Calculate current amortization values per month
                            PeriodAmortization = CRound(CRound(AcquisitionValue - _
                                CRound(LiquidationValue * Ammount) - _
                                AccumulatedAmortization) / ((AmortizationPeriod * 12) - _
                                CurrentAmortizationCalculatedForMonths))
                            PeriodAmortizationPerUnit = CRound(CRound(AcquisitionValuePerUnit - _
                                LiquidationValue - AccumulatedAmortizationPerUnit, ROUNDUNITASSET) / _
                                ((AmortizationPeriod * 12) - CurrentAmortizationCalculatedForMonths), ROUNDUNITASSET)
                            If CRound(RevaluedPortionValue) > 0 Then
                                PeriodAmortizationRevaluedPortion = CRound(CRound(RevaluedPortionValue - _
                                    AccumulatedAmortizationRevaluedPortion) / ((AmortizationPeriod * 12) - _
                                    CurrentAmortizationCalculatedForMonths))
                            Else
                                PeriodAmortizationRevaluedPortion = 0
                            End If
                            If CRound(RevaluedPortionValuePerUnit, ROUNDUNITASSET) > 0 Then
                                PeriodAmortizationRevaluedPortionPerUnit = CRound(CRound(RevaluedPortionValuePerUnit - _
                                    AccumulatedAmortizationRevaluedPortionPerUnit, ROUNDUNITASSET) / ((AmortizationPeriod * 12) - _
                                    CurrentAmortizationCalculatedForMonths), ROUNDUNITASSET)
                            Else
                                PeriodAmortizationRevaluedPortionPerUnit = 0
                            End If

                            ' Update total values in this calculation
                            _AmmortizationValue = CRound(_AmmortizationValue + (PeriodLength * PeriodAmortization))
                            _AmmortizationValuePerUnit = CRound(_AmmortizationValuePerUnit _
                                + (PeriodLength * PeriodAmortizationPerUnit), ROUNDUNITASSET)
                            If PeriodAmortizationRevaluedPortion > 0 Then
                                _AmmortizationValueRevaluedPortion = CRound(_AmmortizationValueRevaluedPortion + _
                                    (PeriodLength * PeriodAmortizationRevaluedPortion))
                            End If
                            If PeriodAmortizationRevaluedPortionPerUnit > 0 Then
                                _AmmortizationValuePerUnitRevaluedPortion = CRound(_AmmortizationValuePerUnitRevaluedPortion + _
                                    (PeriodLength * PeriodAmortizationRevaluedPortionPerUnit), ROUNDUNITASSET)
                            End If
                            _AmortizationCalculatedForMonths = _AmortizationCalculatedForMonths + PeriodLength

                            ' Add description of amortization calculation for current period
                            _CalculationDescription = _CalculationDescription & vbCrLf & _
                                "Apskaičiuota amortizacija už laikotarpį nuo " & _
                                CurrentPeriodStartDate.ToShortDateString & " iki " & _
                                PeriodEndDate.ToShortDateString & _
                                " įskaitytinai, iš viso už " & PeriodLength.ToString & _
                                " mėnesių. Apskaičiuota amortizacija - " & _
                                DblParser(PeriodLength * PeriodAmortization) & _
                                "; apskaičiuota amortizacija vienetui - " & _
                                DblParser(PeriodLength * PeriodAmortizationPerUnit, ROUNDUNITASSET)

                            If PeriodAmortizationRevaluedPortion > 0 Then
                                _CalculationDescription = _CalculationDescription & _
                                    "; apskaičiuota amortizacija vertės padidėjimui - " & _
                                    DblParser(PeriodLength * PeriodAmortizationRevaluedPortion) & _
                                    "; apskaičiuota amortizacija vertės padidėjimui turto vienetui - " & _
                                    DblParser(PeriodLength * PeriodAmortizationRevaluedPortionPerUnit, ROUNDUNITASSET)
                            End If

                            _CalculationDescription = _CalculationDescription & "."

                            ' if current amortization period length exceeded total amortization period,
                            ' then it was the last calculation needed
                            If AmortizationPeriodEnded Then
                                AmortizationPeriodIsOpen = False
                                Exit For
                            End If

                            ' update current amortization variables with the efect of this period calculations
                            CurrentPeriodStartDate = PeriodEndDate.AddDays(1) ' i.e. next month 1
                            CurrentAmortizationCalculatedForMonths = _
                               CurrentAmortizationCalculatedForMonths + PeriodLength
                            AccumulatedAmortization = CRound(AccumulatedAmortization + _
                                (PeriodLength * PeriodAmortization))
                            AccumulatedAmortizationPerUnit = CRound(AccumulatedAmortizationPerUnit _
                                + (PeriodLength * PeriodAmortizationPerUnit), ROUNDUNITASSET)
                            AccumulatedAmortizationRevaluedPortion = CRound( _
                               AccumulatedAmortizationRevaluedPortion + _
                               (PeriodLength * PeriodAmortizationRevaluedPortion))
                            AccumulatedAmortizationRevaluedPortionPerUnit = CRound( _
                                AccumulatedAmortizationRevaluedPortionPerUnit _
                                + (PeriodLength * PeriodAmortizationRevaluedPortionPerUnit), ROUNDUNITASSET)

                            ' update current amortization variables with all the operations within 
                            ' current month ('cause they all take effect the next month)
                            OperationsInMonth = UpdateCurrentParamsForMonth(myData, PeriodEndDate.Year, _
                                PeriodEndDate.Month, AcquisitionValue, AcquisitionValuePerUnit, _
                                RevaluedPortionValue, RevaluedPortionValuePerUnit, _
                                AccumulatedAmortization, AccumulatedAmortizationPerUnit, _
                                AccumulatedAmortizationRevaluedPortion, AccumulatedAmortizationRevaluedPortionPerUnit, _
                                IsUsed, AmortizationPeriod, AssetName)

                            ' Describe changes
                            _CalculationDescription = _CalculationDescription & vbCrLf & _
                                PeriodEndDate.Year.ToString & " m. " & PeriodEndDate.Month.ToString & _
                                "mėn. su turtu yra registruota (-os) operacija (-os) " & _
                                OperationsInMonth & ". Po šių operacijų skaičiavimo parametrai yra: " & _
                                GetCurrentParamsString(AcquisitionValue, AcquisitionValuePerUnit, _
                                RevaluedPortionValue, RevaluedPortionValuePerUnit, AccumulatedAmortization, _
                                AccumulatedAmortizationPerUnit, AccumulatedAmortizationRevaluedPortion, _
                                AccumulatedAmortizationRevaluedPortionPerUnit, IsUsed, AmortizationPeriod, _
                                CurrentAmortizationCalculatedForMonths) & " Vieno mėnesio amortizacijos suma - " _
                                & GetCurrentMonthAmortizationFormula(AcquisitionValue, RevaluedPortionValue, _
                                AccumulatedAmortization, AccumulatedAmortizationRevaluedPortion, AmortizationPeriod, _
                                CurrentAmortizationCalculatedForMonths, LiquidationValue, Ammount) _
                                & "; Vieno mėnesio amortizacijos suma turto vienetui - " _
                                & GetCurrentMonthAmortizationFormulaPerUnit(AcquisitionValuePerUnit, _
                                RevaluedPortionValuePerUnit, AccumulatedAmortizationPerUnit, _
                                AccumulatedAmortizationRevaluedPortionPerUnit, AmortizationPeriod, _
                                CurrentAmortizationCalculatedForMonths, LiquidationValue) & "."

                            ' if the asset is not used anymore after the current month operations
                            ' then find the next usage period
                            If Not IsUsed Then

                                ' find the new period
                                Dim NewUseBegin As Date
                                Dim UsageStartIsFound As Boolean = False
                                For j = i To myData.Rows.Count
                                    If CDate(myData.Rows(j - 1).Item(12)).Date >= CurrentPeriodStartDate.Date _
                                        AndAlso ConvertEnumDatabaseStringCode(Of LtaOperationType) _
                                        (CStrSafe(myData.Rows(j - 1).Item(10)).Trim) = LtaOperationType.UsingStart Then

                                        UsageStartIsFound = True
                                        NewUseBegin = New Date(CDate(myData.Rows(j - 1).Item(12)).Year, _
                                            CDate(myData.Rows(j - 1).Item(12)).Month, _
                                            Date.DaysInMonth(CDate(myData.Rows(j - 1).Item(12)).Year, _
                                            CDate(myData.Rows(j - 1).Item(12)).Month))
                                        NewUseBegin = NewUseBegin.AddDays(1)

                                        Exit For

                                    End If
                                Next

                                ' if no more usage periods are found, 
                                ' then the previous calculation was the last one
                                If Not UsageStartIsFound Then
                                    _CalculationDescription = _CalculationDescription & vbCrLf & _
                                        "Turtas nebebuvo naudojamas nuo " & _
                                        CurrentPeriodStartDate.ToShortDateString & "."
                                    AmortizationPeriodIsOpen = False
                                    Exit For
                                End If

                                ' update current amortization variables with all the operations 
                                ' that took place during non usage period
                                Dim OperationsDuringNonUsePeriod As String = ""
                                For j = i To myData.Rows.Count
                                    If CDate(myData.Rows(j - 1).Item(12)).Date >= CurrentPeriodStartDate.Date _
                                        AndAlso CDate(myData.Rows(j - 1).Item(12)).Date < NewUseBegin.Date Then
                                        UpdateCurrentParamsWithOperation(myData.Rows(j - 1), _
                                            AcquisitionValue, AcquisitionValuePerUnit, RevaluedPortionValue, _
                                            RevaluedPortionValuePerUnit, AccumulatedAmortization, _
                                            AccumulatedAmortizationPerUnit, AccumulatedAmortizationRevaluedPortion, _
                                            AccumulatedAmortizationRevaluedPortionPerUnit, IsUsed, _
                                            AmortizationPeriod, Ammount, True, AssetName)
                                        If String.IsNullOrEmpty(OperationsDuringNonUsePeriod.Trim) Then
                                            OperationsDuringNonUsePeriod = ConvertEnumHumanReadable( _
                                                ConvertEnumDatabaseStringCode(Of LtaOperationType) _
                                                (CStrSafe(myData.Rows(j - 1).Item(10))))
                                        Else
                                            OperationsDuringNonUsePeriod = OperationsDuringNonUsePeriod _
                                                & ", " & ConvertEnumHumanReadable( _
                                                ConvertEnumDatabaseStringCode(Of LtaOperationType) _
                                                (CStrSafe(myData.Rows(j - 1).Item(10))))
                                        End If
                                    End If
                                Next

                                ' describe what's done
                                _CalculationDescription = _CalculationDescription & vbCrLf & _
                                    "Turtas nebuvo naudojamas nuo " & CurrentPeriodStartDate.ToShortDateString & _
                                    " iki " & NewUseBegin.ToShortDateString & ". "

                                If String.IsNullOrEmpty(OperationsDuringNonUsePeriod.Trim) Then
                                    _CalculationDescription = _CalculationDescription & _
                                        " Per šį laikotarpį operacijų su turtu registruota nebuvo."
                                Else
                                    _CalculationDescription = _CalculationDescription & _
                                        "Per šį laikotarpį su turtu buvo registruota operacija (-os) " & _
                                        OperationsDuringNonUsePeriod & ". Pradėjus vėl naudoti turtą " & _
                                        "amortizacijos skaičiavimo parametrai yra: " & _
                                        GetCurrentParamsString(AcquisitionValue, AcquisitionValuePerUnit, _
                                        RevaluedPortionValue, RevaluedPortionValuePerUnit, AccumulatedAmortization, _
                                        AccumulatedAmortizationPerUnit, AccumulatedAmortizationRevaluedPortion, _
                                        AccumulatedAmortizationRevaluedPortionPerUnit, IsUsed, AmortizationPeriod, _
                                        CurrentAmortizationCalculatedForMonths) & " Vieno mėnesio amortizacijos suma - " _
                                        & GetCurrentMonthAmortizationFormula(AcquisitionValue, RevaluedPortionValue, _
                                        AccumulatedAmortization, AccumulatedAmortizationRevaluedPortion, _
                                        AmortizationPeriod, CurrentAmortizationCalculatedForMonths, _
                                        LiquidationValue, Ammount) & "; Vieno mėnesio amortizacijos suma turto vienetui - " _
                                        & GetCurrentMonthAmortizationFormulaPerUnit(AcquisitionValuePerUnit, _
                                        RevaluedPortionValuePerUnit, AccumulatedAmortizationPerUnit, _
                                        AccumulatedAmortizationRevaluedPortionPerUnit, AmortizationPeriod, _
                                        CurrentAmortizationCalculatedForMonths, LiquidationValue) & "."

                                End If

                                ' update new period start as next month after usage operation
                                CurrentPeriodStartDate = NewUseBegin

                            End If

                        End If

                    End If
                Next

                If AmortizationPeriodIsOpen Then

                    ' Evaluate the last period length
                    PeriodLength = DateDifferenceInMonths(CurrentPeriodStartDate, _
                        nDateTo, True, True)
                    ' It can't be longer than total amortization period
                    If CurrentAmortizationCalculatedForMonths + PeriodLength >= AmortizationPeriod * 12 Then
                        PeriodLength = (AmortizationPeriod * 12) - CurrentAmortizationCalculatedForMonths
                        PeriodEndDate = AddMonths(CurrentPeriodStartDate, PeriodLength - 1)
                    Else
                        PeriodEndDate = New Date(nDateTo.Year, nDateTo.Month, _
                            Date.DaysInMonth(nDateTo.Year, nDateTo.Month))
                    End If

                    ' Calculate current amortization values per month
                    PeriodAmortization = CRound(CRound(AcquisitionValue - _
                        CRound(LiquidationValue * Ammount) - _
                        AccumulatedAmortization) / ((AmortizationPeriod * 12) - _
                        CurrentAmortizationCalculatedForMonths))
                    PeriodAmortizationPerUnit = CRound(CRound(AcquisitionValuePerUnit - _
                        LiquidationValue - AccumulatedAmortizationPerUnit, ROUNDUNITASSET) / _
                        ((AmortizationPeriod * 12) - CurrentAmortizationCalculatedForMonths), ROUNDUNITASSET)
                    If CRound(RevaluedPortionValue) > 0 Then
                        PeriodAmortizationRevaluedPortion = CRound(CRound(RevaluedPortionValue - _
                            AccumulatedAmortizationRevaluedPortion) / ((AmortizationPeriod * 12) - _
                            CurrentAmortizationCalculatedForMonths))
                    Else
                        PeriodAmortizationRevaluedPortion = 0
                    End If
                    If CRound(RevaluedPortionValuePerUnit, ROUNDUNITASSET) > 0 Then
                        PeriodAmortizationRevaluedPortionPerUnit = CRound(CRound(RevaluedPortionValuePerUnit - _
                            AccumulatedAmortizationRevaluedPortionPerUnit, ROUNDUNITASSET) / ((AmortizationPeriod * 12) - _
                            CurrentAmortizationCalculatedForMonths), ROUNDUNITASSET)
                    Else
                        PeriodAmortizationRevaluedPortionPerUnit = 0
                    End If

                    ' Update total values in this calculation
                    _AmmortizationValue = CRound(_AmmortizationValue + (PeriodLength * PeriodAmortization))
                    _AmmortizationValuePerUnit = CRound(_AmmortizationValuePerUnit _
                        + (PeriodLength * PeriodAmortizationPerUnit), ROUNDUNITASSET)
                    If PeriodAmortizationRevaluedPortion > 0 Then
                        _AmmortizationValueRevaluedPortion = CRound(_AmmortizationValueRevaluedPortion + _
                            (PeriodLength * PeriodAmortizationRevaluedPortion))
                    End If
                    If PeriodAmortizationRevaluedPortionPerUnit > 0 Then
                        _AmmortizationValuePerUnitRevaluedPortion = CRound(_AmmortizationValuePerUnitRevaluedPortion + _
                            (PeriodLength * PeriodAmortizationRevaluedPortionPerUnit), ROUNDUNITASSET)
                    End If
                    _AmortizationCalculatedForMonths = _AmortizationCalculatedForMonths + PeriodLength

                    ' Add description of amortization calculation for current period
                    _CalculationDescription = _CalculationDescription & vbCrLf & _
                        "Apskaičiuota amortizacija už laikotarpį nuo " & _
                        CurrentPeriodStartDate.ToShortDateString & " iki " & _
                        PeriodEndDate.ToShortDateString & _
                        " įskaitytinai, iš viso už " & PeriodLength.ToString & _
                        " mėnesių. Apskaičiuota amortizacija - " & _
                        DblParser(PeriodLength * PeriodAmortization) & _
                        "; apskaičiuota amortizacija vienetui - " & _
                        DblParser(PeriodLength * PeriodAmortizationPerUnit, ROUNDUNITASSET)

                    If PeriodAmortizationRevaluedPortion > 0 Then
                        _CalculationDescription = _CalculationDescription & _
                            "; apskaičiuota amortizacija vertės padidėjimui - " & _
                            DblParser(PeriodLength * PeriodAmortizationRevaluedPortion) & _
                            "; apskaičiuota amortizacija vertės padidėjimui turto vienetui - " & _
                            DblParser(PeriodLength * PeriodAmortizationRevaluedPortionPerUnit, ROUNDUNITASSET)
                    End If

                    _CalculationDescription = _CalculationDescription & "."

                End If


                _CalculationDescription = _CalculationDescription & vbCrLf & _
                    "Turto amortizacijos skaičiavimas užbaigtas. Iš viso apskaičiuota: " & _
                    "amortizacijos - " & DblParser(_AmmortizationValue) & _
                    "amortizacijos turto vienetui - " & DblParser(_AmmortizationValuePerUnit, ROUNDUNITASSET) & _
                    "amortizacijos perkainotai daliai - " & DblParser(_AmmortizationValueRevaluedPortion) & _
                    "amortizacijos perkainotai daliai turto vienetui- " & _
                    DblParser(_AmmortizationValuePerUnitRevaluedPortion, ROUNDUNITASSET) & _
                    ". Amortizacija priskaičiuota už " & _AmortizationCalculatedForMonths & " mėnesių."

            End Using

        End Sub


        Private Function UpdateCurrentParamsForMonth(ByVal dt As DataTable, _
            ByVal YearToUpdate As Integer, ByVal MonthToUpdate As Integer, _
            ByRef AcquisitionValue As Double, _
            ByRef AcquisitionValuePerUnit As Double, _
            ByRef RevaluedPortionValue As Double, _
            ByRef RevaluedPortionValuePerUnit As Double, _
            ByRef AccumulatedAmortization As Double, _
            ByRef AccumulatedAmortizationPerUnit As Double, _
            ByRef AccumulatedAmortizationRevaluedPortion As Double, _
            ByRef AccumulatedAmortizationRevaluedPortionPerUnit As Double, _
            ByRef isUsed As Boolean, _
            ByRef AmortizationPeriod As Integer, _
            ByVal AssetName As String) As String

            Dim result As String = ""

            For i As Integer = 1 To dt.Rows.Count
                If CDate(dt.Rows(i - 1).Item(12)).Year = YearToUpdate AndAlso _
                    CDate(dt.Rows(i - 1).Item(12)).Month = MonthToUpdate Then

                    If String.IsNullOrEmpty(result) Then
                        result = ConvertEnumHumanReadable( _
                            ConvertEnumDatabaseStringCode(Of LtaOperationType) _
                            (CStrSafe(dt.Rows(i - 1).Item(10))))
                    Else
                        result = result & ", " & ConvertEnumHumanReadable( _
                            ConvertEnumDatabaseStringCode(Of LtaOperationType) _
                            (CStrSafe(dt.Rows(i - 1).Item(10))))
                    End If

                    UpdateCurrentParamsWithOperation(dt.Rows(i - 1), AcquisitionValue, _
                        AcquisitionValuePerUnit, RevaluedPortionValue, RevaluedPortionValuePerUnit, _
                        AccumulatedAmortization, AccumulatedAmortizationPerUnit, _
                        AccumulatedAmortizationRevaluedPortion, AccumulatedAmortizationRevaluedPortionPerUnit, _
                        isUsed, AmortizationPeriod, New Integer, True, AssetName)

                End If
            Next

            Return result

        End Function

        Private Sub UpdateCurrentParamsWithOperation(ByVal dr As DataRow, _
            ByRef AcquisitionValue As Double, _
            ByRef AcquisitionValuePerUnit As Double, _
            ByRef RevaluedPortionValue As Double, _
            ByRef RevaluedPortionValuePerUnit As Double, _
            ByRef AccumulatedAmortization As Double, _
            ByRef AccumulatedAmortizationPerUnit As Double, _
            ByRef AccumulatedAmortizationRevaluedPortion As Double, _
            ByRef AccumulatedAmortizationRevaluedPortionPerUnit As Double, _
            ByRef isUsed As Boolean, _
            ByRef AmortizationPeriod As Integer, _
            ByRef Ammount As Integer, _
            ByVal ThrowOnAmmountChange As Boolean, _
            ByVal AssetName As String)

            AcquisitionValue = CRound(AcquisitionValue + CDblSafe(dr.Item(0), 2, 0))
            AcquisitionValuePerUnit = CRound(AcquisitionValuePerUnit + CDblSafe(dr.Item(1), _
                ROUNDUNITASSET, 0), ROUNDUNITASSET)
            RevaluedPortionValue = CRound(RevaluedPortionValue + CDblSafe(dr.Item(2), 2, 0))
            RevaluedPortionValuePerUnit = CRound(RevaluedPortionValuePerUnit _
                + CDblSafe(dr.Item(3), ROUNDUNITASSET, 0), ROUNDUNITASSET)
            AccumulatedAmortization = CRound(AccumulatedAmortization + CDblSafe(dr.Item(4), 2, 0))
            AccumulatedAmortizationPerUnit = CRound(AccumulatedAmortizationPerUnit _
                + CDblSafe(dr.Item(5), ROUNDUNITASSET, 0), ROUNDUNITASSET)
            AccumulatedAmortizationRevaluedPortion = CRound( _
                AccumulatedAmortizationRevaluedPortion + CDblSafe(dr.Item(6), 2, 0))
            AccumulatedAmortizationRevaluedPortionPerUnit = CRound( _
                AccumulatedAmortizationRevaluedPortionPerUnit _
                + CDblSafe(dr.Item(7), ROUNDUNITASSET, 0), ROUNDUNITASSET)

            If CInt(dr.Item(8)) <> 0 AndAlso ThrowOnAmmountChange Then Throw New Exception( _
                "Klaida. Į turto """ & AssetName & """ amortizacijos laikotarpį įsiterpė " & _
                ConvertEnumDatabaseStringCode(Of LtaOperationType)(CStrSafe(dr.Item(10))) _
                & " operacija (" & CDateSafe(dr.Item(12), Today).ToShortDateString & "). " _
                & "Pasikeitus kiekiui neįmanoma apskaičiuoti amortizacijos " _
                & "(amortizacijos apskaičiavimas padarytų klaidingas perleidimo/nurašymo " _
                & "operacijos turto nurašymo vertes, kurios buvo suformuotos be amortizacijos).")

            Ammount = Ammount - CIntSafe(dr.Item(8), 0)

            If CIntSafe(dr.Item(11), 0) > 0 Then AmortizationPeriod = CIntSafe(dr.Item(11), 0)

            If ConvertEnumDatabaseStringCode(Of LtaOperationType)(CStrSafe(dr.Item(10))) _
                = LtaOperationType.UsingStart Then isUsed = Not isUsed

        End Sub

        Private Function GetCurrentParamsString(ByVal AcquisitionValue As Double, _
            ByVal AcquisitionValuePerUnit As Double, _
            ByVal RevaluedPortionValue As Double, _
            ByVal RevaluedPortionValuePerUnit As Double, _
            ByVal AccumulatedAmortization As Double, _
            ByVal AccumulatedAmortizationPerUnit As Double, _
            ByVal AccumulatedAmortizationRevaluedPortion As Double, _
            ByVal AccumulatedAmortizationRevaluedPortionPerUnit As Double, _
            ByVal isUsed As Boolean, _
            ByVal AmortizationPeriod As Integer, _
            ByVal CurrentAmortizationCalculatedForMonths As Integer) As String

            Dim result As String = "Įsigijimo savikaina - " & DblParser(AcquisitionValue) & "; " & _
                "Įsigijimo savikaina vienetui - " & DblParser(AcquisitionValuePerUnit, ROUNDUNITASSET) & "; " & _
                "Vertės padidėjimas - " & DblParser(RevaluedPortionValue) & "; " & _
                "Vertės padidėjimas vienetui - " & DblParser(RevaluedPortionValuePerUnit, ROUNDUNITASSET) & "; " & _
                "Sukaupta amortizacija - " & DblParser(AccumulatedAmortization) & "; " & _
                "Sukaupta amortizacija vienetui - " & DblParser(AccumulatedAmortizationPerUnit, ROUNDUNITASSET) & "; " & _
                "Vertės padidėjimo sukaupta amortizacija - " & DblParser(AccumulatedAmortizationRevaluedPortion) & "; " & _
                "Vertės padidėjimo sukaupta amortizacija vienetui - " & DblParser(AccumulatedAmortizationRevaluedPortionPerUnit, ROUNDUNITASSET) & "; " & _
                "Amortizacijos periodas (m.) - " & AmortizationPeriod.ToString & "; " & _
                "Amortizacija apskaičiuota už mėn. - " & CurrentAmortizationCalculatedForMonths.ToString & "; " & _
                "Naudojama - " & isUsed.ToString & ". "

            Return result
        End Function

        Private Function GetCurrentMonthAmortizationFormula(ByVal AcquisitionValue As Double, _
            ByVal RevaluedPortionValue As Double, _
            ByVal AccumulatedAmortization As Double, _
            ByVal AccumulatedAmortizationRevaluedPortion As Double, _
            ByVal AmortizationPeriod As Integer, _
            ByVal CurrentAmortizationCalculatedForMonths As Integer, _
            ByVal LiquidationValue As Double, ByVal Ammount As Integer) As String

            Dim AmortizationPerMonth As Double = CRound(CRound(AcquisitionValue - _
                CRound(LiquidationValue * Ammount) - AccumulatedAmortization) _
                / ((AmortizationPeriod * 12) - CurrentAmortizationCalculatedForMonths))
            Dim AmortizationPerMonthRevaluedPortion As Double = CRound( _
                CRound(RevaluedPortionValue - AccumulatedAmortizationRevaluedPortion) _
                / ((AmortizationPeriod * 12) - CurrentAmortizationCalculatedForMonths))


            Dim result As String = "( (" & DblParser(AcquisitionValue) & " - " _
                & DblParser(LiquidationValue * Ammount) & " - " & DblParser(AccumulatedAmortization) _
                & ") / (" & AmortizationPeriod.ToString & " * 12 - " & _
                CurrentAmortizationCalculatedForMonths.ToString & ") )"

            If RevaluedPortionValue > 0 Then
                result = result & " + ( (" & DblParser(RevaluedPortionValue) & " - " _
                & DblParser(AccumulatedAmortizationRevaluedPortion) _
                & ") / (" & AmortizationPeriod.ToString & " * 12 - " & _
                CurrentAmortizationCalculatedForMonths.ToString & ") ) = " _
                & DblParser(AmortizationPerMonth) & " + " _
                & DblParser(AmortizationPerMonthRevaluedPortion) & " = " _
                & DblParser(AmortizationPerMonth + AmortizationPerMonthRevaluedPortion)
            Else
                result = result & " = " & DblParser(AmortizationPerMonth)
            End If

            Return result
        End Function

        Private Function GetCurrentMonthAmortizationFormulaPerUnit( _
            ByVal AcquisitionValuePerUnit As Double, _
            ByVal RevaluedPortionValuePerUnit As Double, _
            ByVal AccumulatedAmortizationPerUnit As Double, _
            ByVal AccumulatedAmortizationRevaluedPortionPerUnit As Double, _
            ByVal AmortizationPeriod As Integer, _
            ByVal CurrentAmortizationCalculatedForMonths As Integer, _
            ByVal LiquidationValue As Double) As String

            Dim AmortizationPerMonth As Double = CRound(CRound(AcquisitionValuePerUnit - _
                LiquidationValue - AccumulatedAmortizationPerUnit) _
                / ((AmortizationPeriod * 12) - CurrentAmortizationCalculatedForMonths), ROUNDUNITASSET)
            Dim AmortizationPerMonthRevaluedPortion As Double = CRound( _
                CRound(RevaluedPortionValuePerUnit - AccumulatedAmortizationRevaluedPortionPerUnit) _
                / ((AmortizationPeriod * 12) - CurrentAmortizationCalculatedForMonths), ROUNDUNITASSET)


            Dim result As String = "( (" & DblParser(AcquisitionValuePerUnit, ROUNDUNITASSET) & " - " _
                & DblParser(LiquidationValue) & " - " & DblParser(AccumulatedAmortizationPerUnit, ROUNDUNITASSET) _
                & ") / (" & AmortizationPeriod.ToString & " * 12 - " & _
                CurrentAmortizationCalculatedForMonths.ToString & ") )"

            If CRound(RevaluedPortionValuePerUnit, ROUNDUNITASSET) > 0 Then
                result = result & " + ( (" & DblParser(RevaluedPortionValuePerUnit, ROUNDUNITASSET) & " - " _
                & DblParser(AccumulatedAmortizationRevaluedPortionPerUnit, ROUNDUNITASSET) _
                & ") / (" & AmortizationPeriod.ToString & " * 12 - " & _
                CurrentAmortizationCalculatedForMonths.ToString & ") ) = " _
                & DblParser(AmortizationPerMonth, 4) & " + " _
                & DblParser(AmortizationPerMonthRevaluedPortion, 4) & " = " _
                & DblParser(AmortizationPerMonth + AmortizationPerMonthRevaluedPortion, ROUNDUNITASSET)
            Else
                result = result & " = " & DblParser(AmortizationPerMonth, ROUNDUNITASSET)
            End If

            Return result
        End Function



        Private Sub AddTextLine(ByRef TargetString As String, ByVal TextLineToAdd As String)
            If String.IsNullOrEmpty(TargetString.Trim) Then
                TargetString = TextLineToAdd.Trim
            Else
                TargetString = TargetString & vbCrLf & TextLineToAdd.Trim
            End If
        End Sub

        Public Shared Function DateDifferenceInMonths(ByVal DateBegin As Date, _
            ByVal DateEnd As Date, Optional ByVal DateBeginFirstMonthInclusive As Boolean = False, _
            Optional ByVal DateEndLastMonthInclusive As Boolean = True) As Integer

            If DateBegin.Date > DateEnd.Date Then Return 0

            If DateBegin.Year = DateEnd.Year AndAlso DateBegin.Month = DateEnd.Month Then
                If DateBeginFirstMonthInclusive Then Return 1
                Return 0

            ElseIf DateBegin.Year = DateEnd.Year AndAlso DateBegin.Month <> DateEnd.Month Then
                If DateBeginFirstMonthInclusive AndAlso DateEndLastMonthInclusive Then _
                    Return DateEnd.Month - DateBegin.Month + 1
                If DateBeginFirstMonthInclusive OrElse DateEndLastMonthInclusive Then _
                    Return DateEnd.Month - DateBegin.Month
                Return DateEnd.Month - DateBegin.Month - 1

            Else
                If DateBeginFirstMonthInclusive AndAlso DateEndLastMonthInclusive Then _
                    Return (12 - DateBegin.Month + 1) + ((DateEnd.Year - DateBegin.Year - 1) * 12) _
                    + DateEnd.Month
                If DateBeginFirstMonthInclusive OrElse DateEndLastMonthInclusive Then _
                    Return (12 - DateBegin.Month + 1) + ((DateEnd.Year - DateBegin.Year - 1) * 12) _
                    + DateEnd.Month - 1
                Return (12 - DateBegin.Month + 1) + ((DateEnd.Year - DateBegin.Year - 1) * 12) _
                    + DateEnd.Month - 2

            End If

        End Function

        Public Shared Function AddMonths(ByVal TargetDate As Date, ByVal MonthsToAdd As Integer) As Date

            Dim YearsToAdd As Integer = Math.Floor(MonthsToAdd / 12)
            MonthsToAdd = MonthsToAdd - (12 * YearsToAdd)

            If TargetDate.Month + MonthsToAdd < 13 Then
                Return New Date(TargetDate.Year + YearsToAdd, TargetDate.Month + MonthsToAdd, _
                    Date.DaysInMonth(TargetDate.Year + YearsToAdd, TargetDate.Month + MonthsToAdd))
            Else
                Return New Date(TargetDate.Year + YearsToAdd + 1, TargetDate.Month + MonthsToAdd - 12, _
                    Date.DaysInMonth(TargetDate.Year + YearsToAdd + 1, TargetDate.Month + MonthsToAdd - 12))
            End If

        End Function

#End Region

    End Class

End Namespace