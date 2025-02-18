﻿Imports ApskaitaObjects.My.Resources
Imports ApskaitaObjects.Attributes

Namespace Assets

    ''' <summary>
    ''' Represents an info object that provides a calculation of long term asset amortization/depreciation
    ''' for a long term asset item for given parameters.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
Public NotInheritable Class LongTermAssetAmortizationCalculation
        Inherits ReadOnlyBase(Of LongTermAssetAmortizationCalculation)

#Region " Business Methods "

        Private _AssetID As Integer
        Private _DateTo As Date
        Private _AmortizationValue As Double = 0
        Private _AmortizationValuePerUnit As Double = 0
        Private _AmortizationValueRevaluedPortion As Double = 0
        Private _AmortizationValuePerUnitRevaluedPortion As Double = 0
        Private _CalculationDescription As String = ""
        Private _AmortizationCalculatedForMonths As Integer


        ''' <summary>
        ''' An <see cref="LongTermAsset.ID">ID of the asset</see> which the calculation is done for.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AssetID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AssetID
            End Get
        End Property

        ''' <summary>
        ''' A date which the calculation is done at.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DateTo() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DateTo.Date
            End Get
        End Property

        ''' <summary>
        ''' A total amount of amortization calculated.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property AmortizationValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmortizationValue)
            End Get
        End Property

        ''' <summary>
        ''' An amount of amortization calculated per asset unit.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDUNITASSET)> _
        Public ReadOnly Property AmortizationValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmortizationValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' A total amount of amortization calculated for the revalued portion of the asset.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property AmortizationValueRevaluedPortion() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmortizationValueRevaluedPortion)
            End Get
        End Property

        ''' <summary>
        ''' An amount of amortization calculated for the revalued portion of the asset per asset unit.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDUNITASSET)> _
        Public ReadOnly Property AmortizationValuePerUnitRevaluedPortion() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmortizationValuePerUnitRevaluedPortion, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' A period length in months that the amortization is calculated for.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AmortizationCalculatedForMonths() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AmortizationCalculatedForMonths
            End Get
        End Property

        ''' <summary>
        ''' A localized (human readable) description of the calculation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CalculationDescription() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CalculationDescription.Trim
            End Get
        End Property


        Protected Overrides Function GetIdValue() As Object
            Return String.Format("{0}:{1}", _AssetID.ToString(), _DateTo.ToString("yyyyMMdd"))
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_ToString, _
                _AssetID.ToString(), _DateTo.ToString("yyyy-MM-dd"))
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

        ''' <summary>
        ''' Gets a new instance of LongTermAssetAmortizationCalculation for the specified asset for the specified date.
        ''' </summary>
        ''' <param name="assetID">An <see cref="LongTermAsset.ID">ID of the asset</see> 
        ''' that the calculation is done for.</param>
        ''' <param name="editedAmortizationOperationID">An ID of the long term asset amortization operation 
        ''' that should be ignored when calculating. (when recalculating for an existing operation)</param>
        ''' <param name="dateTo">A date which the calculation is done at.</param>
        ''' <remarks></remarks>
        Public Shared Function GetLongTermAssetAmortizationCalculation( _
            ByVal assetID As Integer, ByVal editedAmortizationOperationID As Integer, _
            ByVal dateTo As Date) As LongTermAssetAmortizationCalculation
            Return DataPortal.Fetch(Of LongTermAssetAmortizationCalculation)(New Criteria( _
                assetID, editedAmortizationOperationID, dateTo))
        End Function

        ''' <summary>
        ''' Gets a new instance of LongTermAssetAmortizationCalculation bypassing dataportal for the specified asset for the specified date.
        ''' </summary>
        ''' <param name="assetID">An <see cref="LongTermAsset.ID">ID of the asset</see> which the calculation is done for.</param>
        ''' <param name="editedAmortizationOperationID">An ID of the long term asset amortization operation 
        ''' that should be ignored when calculating. (when recalculating for an existing operation)</param>
        ''' <param name="dateTo">A date which the calculation is done at.</param>
        ''' <remarks>Should only be invoked server side.</remarks>
        Friend Shared Function GetLongTermAssetAmortizationCalculationChild( _
            ByVal assetID As Integer, ByVal editedAmortizationOperationID As Integer, _
            ByVal dateTo As Date) As LongTermAssetAmortizationCalculation
            Return New LongTermAssetAmortizationCalculation(assetID, dateTo, editedAmortizationOperationID)
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
            Public Sub New(ByVal nAssetID As Integer, ByVal nEditedAmortizationOperationID As Integer, ByVal nDateTo As Date)
                _AssetID = nAssetID
                _EditedAmortizationOperationID = nEditedAmortizationOperationID
                _DateTo = nDateTo.Date
            End Sub
        End Class


        Private Structure OperationData

            Public ReadOnly ID As Integer
            Public ReadOnly [Date] As Date
            Public ReadOnly [Type] As LtaOperationType
            Public ReadOnly NewAmortizationPeriod As Integer
            Public ReadOnly AmountChange As Integer
            Public ReadOnly AcquisitionValueChange As Double
            Public ReadOnly AcquisitionValueChangePerUnit As Double
            Public ReadOnly RevaluedPortionValue As Double
            Public ReadOnly RevaluedPortionValuePerUnit As Double
            Public ReadOnly AccumulatedAmortization As Double
            Public ReadOnly AccumulatedAmortizationPerUnit As Double
            Public ReadOnly AccumulatedAmortizationRevaluedPortion As Double
            Public ReadOnly AccumulatedAmortizationRevaluedPortionPerUnit As Double
            Public ReadOnly AmortizationCalculatedForMonths As Integer

            Private Sub New(ByVal dr As DataRow)

                AcquisitionValueChange = CDblSafe(dr.Item(0), 2, 0)
                AcquisitionValueChangePerUnit = CDblSafe(dr.Item(1), ROUNDUNITASSET, 0)
                RevaluedPortionValue = CDblSafe(dr.Item(2), 2, 0)
                RevaluedPortionValuePerUnit = CDblSafe(dr.Item(3), ROUNDUNITASSET, 0)
                AccumulatedAmortization = CDblSafe(dr.Item(4), 2, 0)
                AccumulatedAmortizationPerUnit = CDblSafe(dr.Item(5), ROUNDUNITASSET, 0)
                AccumulatedAmortizationRevaluedPortion = CDblSafe(dr.Item(6), 2, 0)
                AccumulatedAmortizationRevaluedPortionPerUnit = CDblSafe(dr.Item(7), ROUNDUNITASSET, 0)
                AmountChange = CIntSafe(dr.Item(8), 0)
                AmortizationCalculatedForMonths = CIntSafe(dr.Item(9), 0)
                [Type] = Utilities.ConvertDatabaseCharID(Of LtaOperationType)(CStrSafe(dr.Item(10)))
                NewAmortizationPeriod = CIntSafe(dr.Item(11), 0)
                [Date] = CDateSafe(dr.Item(12), Today)
                ID = CIntSafe(dr.Item(13), 0)

            End Sub


            Public Shared Function GetSignificantOperationList(ByVal nAssetID As Integer, _
                ByVal nDateTo As Date, ByVal nEditedAmortizationOperationID As Integer) As List(Of OperationData)

                Dim result As List(Of OperationData)

                Dim myComm As New SQLCommand("FetchSignificantOperationList")
                myComm.AddParam("?AD", nAssetID)
                myComm.AddParam("?MD", nEditedAmortizationOperationID)
                myComm.AddParam("?DT", nDateTo)

                Using myData As DataTable = myComm.Fetch()

                    result = New List(Of OperationData)

                    For Each dr As DataRow In myData.Rows
                        result.Add(New OperationData(dr))
                    Next

                End Using

                Return result

            End Function

            Public Shared Function GetTotalAmortizationMonths(ByVal operations As List(Of OperationData)) As Integer

                Dim result As Integer = 0
                For Each o As OperationData In operations
                    result = result + o.AmortizationCalculatedForMonths
                Next
                Return result

            End Function

            Public Shared Function GetOperationalPeriods(ByVal operations As List(Of OperationData), _
                ByVal initialState As AssetState, ByVal calculationDate As Date) As List(Of KeyValuePair(Of Date, Date))

                Dim isUsed As Boolean = initialState.IsUsed

                Dim dateList As New List(Of Date)

                If initialState.IsUsed Then
                    dateList.Add(New Date(initialState.AssetAcquisitionDate.Year, _
                        initialState.AssetAcquisitionDate.Month, 1))
                End If

                Dim effectiveCalculationDate As Date = New Date(calculationDate.Year, calculationDate.Month, 1)

                Dim currentDate As Date
                For Each o As OperationData In operations

                    ' operations within the calculation month and after does not have an effect
                    If o.Date.Date >= effectiveCalculationDate.Date Then

                        currentDate = New Date(calculationDate.Year, calculationDate.Month, _
                            Date.DaysInMonth(calculationDate.Year, calculationDate.Month))

                        ' if the asset is operational, a period shall end with the calculation date
                        If isUsed AndAlso Not dateList.Contains(currentDate.Date) Then
                            dateList.Add(currentDate.Date)
                        End If

                        ' operations are fetched chronologicaly, so further operations will be even later
                        Exit For

                    End If

                    currentDate = o.GetEffectiveDate(isUsed).Date

                    If (isUsed OrElse o.Type = LtaOperationType.UsingStart OrElse o.Type = LtaOperationType.UsingEnd) _
                        AndAlso Not dateList.Contains(currentDate) Then
                        dateList.Add(currentDate)
                    End If

                    If o.Type = LtaOperationType.UsingStart OrElse o.Type = LtaOperationType.UsingEnd Then
                        isUsed = Not isUsed
                    End If

                Next

                If dateList.Count < 2 Then
                    Throw New Exception(String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_AssetNotOperational, _
                        initialState.AssetName, initialState.AssetID.ToString()))
                End If

                Dim result As New List(Of KeyValuePair(Of Date, Date))

                Dim effectiveLastAmortizationDate As Date = initialState.LastAmortizationDate
                If effectiveLastAmortizationDate <> Date.MinValue Then
                    If initialState.LastAmortizationDate.Month = 12 Then
                        effectiveLastAmortizationDate = New Date(initialState.LastAmortizationDate.Year + 1, 1, 1)
                    Else
                        effectiveLastAmortizationDate = New Date(initialState.LastAmortizationDate.Year, _
                            initialState.LastAmortizationDate.Month + 1, 1)
                    End If
                End If

                For i As Integer = 1 To dateList.Count - 1
                    If dateList(i - 1) >= effectiveLastAmortizationDate.Date Then
                        result.Add(New KeyValuePair(Of Date, Date)(dateList(i - 1), dateList(i)))
                    ElseIf dateList(i) >= effectiveLastAmortizationDate.Date Then
                        result.Add(New KeyValuePair(Of Date, Date)(effectiveLastAmortizationDate.Date, dateList(i)))
                    End If
                Next

                If result.Count < 1 Then
                    Throw New Exception(String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_AssetNotOperational, _
                        initialState.AssetName, initialState.AssetID.ToString()))
                End If

                Return result

            End Function

            Private Function GetEffectiveDate(ByVal currentlyOperational As Boolean) As Date

                If ([Type] = LtaOperationType.UsingStart OrElse [Type] = LtaOperationType.UsingEnd) _
                    AndAlso currentlyOperational Then
                    ' if the operation is making the asset non-operational
                    Return New Date([Date].Year, [Date].Month, Date.DaysInMonth([Date].Year, [Date].Month))
                Else
                    If [Date].Month = 12 Then
                        Return New Date([Date].Year + 1, 1, 1)
                    Else
                        Return New Date([Date].Year, [Date].Month + 1, 1)
                    End If
                End If

            End Function

        End Structure

        Private Structure AssetState

            Public AssetID As Integer
            Public AssetName As String
            Public AssetAcquisitionDate As Date
            Public SalvageValue As Double
            Public IsUsed As Boolean
            Public LastAmortizationDate As Date
            Public AcquisitionValue As Double
            Public AcquisitionValuePerUnit As Double
            Public RevaluedPortionValue As Double
            Public RevaluedPortionValuePerUnit As Double
            Public Amount As Integer
            Public AmortizationPeriod As Integer
            Public AmortizationCalculatedForMonths As Integer
            Public AccumulatedAmortization As Double
            Public AccumulatedAmortizationPerUnit As Double
            Public AccumulatedAmortizationRevaluedPortion As Double
            Public AccumulatedAmortizationRevaluedPortionPerUnit As Double

            Private Sub New(ByVal dr As DataRow)

                AcquisitionValue = CDblSafe(dr.Item(0), 2, 0)
                AcquisitionValuePerUnit = CDblSafe(dr.Item(1), ROUNDUNITASSET, 0)
                RevaluedPortionValue = CDblSafe(dr.Item(2), 2, 0)
                RevaluedPortionValuePerUnit = CDblSafe(dr.Item(3), ROUNDUNITASSET, 0)
                AccumulatedAmortization = CDblSafe(dr.Item(4), 2, 0)
                AccumulatedAmortizationPerUnit = CDblSafe(dr.Item(5), ROUNDUNITASSET, 0)
                AccumulatedAmortizationRevaluedPortion = CDblSafe(dr.Item(6), 2, 0)
                AccumulatedAmortizationRevaluedPortionPerUnit = CDblSafe(dr.Item(7), ROUNDUNITASSET, 0)
                Amount = CIntSafe(dr.Item(8), 0)
                AmortizationCalculatedForMonths = CIntSafe(dr.Item(9), 0)
                IsUsed = ConvertDbBoolean(CIntSafe(dr.Item(10), 0))
                AmortizationPeriod = CIntSafe(dr.Item(11), 0)
                SalvageValue = CDblSafe(dr.Item(12), 2, 0)
                LastAmortizationDate = CDateSafe(dr.Item(13), Date.MinValue)
                AssetAcquisitionDate = CDateSafe(dr.Item(14), Date.MinValue)
                AssetName = CStrSafe(dr.Item(16))

            End Sub


            Public Shared Function GetInitialState(ByVal nAssetID As Integer, _
                ByVal nEditedAmortizationOperationID As Integer, _
                ByRef editedOperationDate As Date) As AssetState

                Dim myComm As New SQLCommand("FetchLongTermAssetAmortization1")
                myComm.AddParam("?AD", nAssetID)
                myComm.AddParam("?MD", nEditedAmortizationOperationID)

                Using myData As DataTable = myComm.Fetch

                    If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                        My.Resources.Common_ObjectNotFound, My.Resources.Assets_LongTermAsset_TypeName, _
                        nAssetID.ToString()))

                    Dim dr As DataRow = myData.Rows(0)

                    editedOperationDate = CDateSafe(dr.Item(15), Date.MinValue)

                    Return New AssetState(dr)

                End Using

            End Function

        End Structure


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)
            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)
            Fetch(criteria.AssetID, criteria.DateTo, criteria.EditedAmortizationOperationID)
        End Sub

        Private Sub Fetch(ByVal nAssetID As Integer, ByVal nDateTo As Date, _
            ByVal nEditedAmortizationOperationID As Integer)

            If Not nAssetID > 0 Then
                Throw New Exception(My.Resources.Assets_LongTermAssetAmortizationCalculation_AssetIdNull)
            End If

            _AssetID = nAssetID
            _DateTo = nDateTo

            Dim assetName As String
            Dim acquisitionDate As Date
            Dim acquisitionValue As Double
            Dim acquisitionValuePerUnit As Double
            Dim revaluedPortionValue As Double
            Dim revaluedPortionValuePerUnit As Double
            Dim amount As Integer
            Dim liquidationValue As Double
            Dim isUsed As Boolean
            Dim amortizationPeriod As Integer
            Dim lastAmortizationDate As Date
            Dim amortizationStartDate As Date
            Dim currentPeriodStartDate As Date
            Dim currentAmortizationCalculatedForMonths As Integer
            Dim accumulatedAmortization As Double
            Dim accumulatedAmortizationPerUnit As Double
            Dim accumulatedAmortizationRevaluedPortion As Double
            Dim accumulatedAmortizationRevaluedPortionPerUnit As Double
            Dim i, j As Integer


            ' fetch asset acquisition data
            Dim myComm As New SQLCommand("FetchLongTermAssetAmortization1")
            myComm.AddParam("?AD", nAssetID)
            myComm.AddParam("?MD", nEditedAmortizationOperationID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                    My.Resources.Common_ObjectNotFound, My.Resources.Assets_LongTermAsset_TypeName, _
                    nAssetID.ToString()))

                Dim dr As DataRow = myData.Rows(0)

                acquisitionValue = CDblSafe(dr.Item(0), 2, 0)
                acquisitionValuePerUnit = CDblSafe(dr.Item(1), ROUNDUNITASSET, 0)
                revaluedPortionValue = CDblSafe(dr.Item(2), 2, 0)
                revaluedPortionValuePerUnit = CDblSafe(dr.Item(3), ROUNDUNITASSET, 0)
                accumulatedAmortization = CDblSafe(dr.Item(4), 2, 0)
                accumulatedAmortizationPerUnit = CDblSafe(dr.Item(5), ROUNDUNITASSET, 0)
                accumulatedAmortizationRevaluedPortion = CDblSafe(dr.Item(6), 2, 0)
                accumulatedAmortizationRevaluedPortionPerUnit = CDblSafe(dr.Item(7), ROUNDUNITASSET, 0)
                amount = CIntSafe(dr.Item(8), 0)
                currentAmortizationCalculatedForMonths = CIntSafe(dr.Item(9), 0)
                isUsed = ConvertDbBoolean(CIntSafe(dr.Item(10), 0))
                amortizationPeriod = CIntSafe(dr.Item(11), 0)
                liquidationValue = CDblSafe(dr.Item(12), 2, 0)

                lastAmortizationDate = CDateSafe(dr.Item(13), Date.MinValue)

                acquisitionDate = CDateSafe(dr.Item(14), Date.MinValue)
                amortizationStartDate = acquisitionDate ' acquisition date is minimum possible operation date

                Dim editedOperationDate As Date = CDateSafe(dr.Item(15), Date.MinValue)

                assetName = CStrSafe(dr.Item(16))

                If nDateTo.Date < acquisitionDate Then
                    Throw New Exception(String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_DateToInvalid, _
                        assetName, nAssetID.ToString(), acquisitionDate.ToString("yyyy-MM-dd")))
                End If

                If editedOperationDate <> Date.MinValue AndAlso lastAmortizationDate <> Date.MinValue _
                    AndAlso lastAmortizationDate.Date > editedOperationDate.Date Then
                    Throw New Exception(String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_EditedAmortizationOperationInvalid, _
                        assetName, nAssetID.ToString(), lastAmortizationDate.ToString("yyyy-MM-dd"), _
                        editedOperationDate.ToString("yyyy-MM-dd")))
                End If

            End Using

            ' if an amortization operation exists (except for the edited one 
            ' that is pointed by criteria.EditedAmortizationOperationID)
            ' then fetch asset status for the begining of the month after that amortization operation
            If lastAmortizationDate <> Date.MinValue Then

                If lastAmortizationDate.Month = 12 Then
                    amortizationStartDate = New Date(lastAmortizationDate.Year + 1, 1, 1)
                Else
                    amortizationStartDate = New Date(lastAmortizationDate.Year, _
                        lastAmortizationDate.Month + 1, 1)
                End If

                If nDateTo.Date < amortizationStartDate.Date Then
                    Throw New Exception(String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_AlreadyCalculated, _
                        assetName, nAssetID.ToString(), amortizationStartDate.ToString("yyyy-MM-dd"), nDateTo.ToString("yyyy-MM-dd")))
                End If

                myComm = New SQLCommand("FetchLongTermAssetAmortization2")
                myComm.AddParam("?AD", nAssetID)
                myComm.AddParam("?DT", amortizationStartDate.Date)

                Using myData As DataTable = myComm.Fetch

                    If myData.Rows.Count > 0 Then

                        Dim dr As DataRow = myData.Rows(0)

                        acquisitionValue = CRound(acquisitionValue + CDblSafe(dr.Item(0), 2, 0))
                        acquisitionValuePerUnit = CRound(acquisitionValuePerUnit _
                            + CDblSafe(dr.Item(1), ROUNDUNITASSET, 0), ROUNDUNITASSET)
                        revaluedPortionValue = CRound(revaluedPortionValue + CDblSafe(dr.Item(2), 2, 0))
                        revaluedPortionValuePerUnit = CRound(revaluedPortionValuePerUnit + _
                            CDblSafe(dr.Item(3), ROUNDUNITASSET, 0), ROUNDUNITASSET)
                        accumulatedAmortization = CRound(accumulatedAmortization + CDblSafe(dr.Item(4), 2, 0))
                        accumulatedAmortizationPerUnit = CRound(accumulatedAmortizationPerUnit + _
                            CDblSafe(dr.Item(5), ROUNDUNITASSET, 0), ROUNDUNITASSET)
                        accumulatedAmortizationRevaluedPortion = _
                            CRound(accumulatedAmortizationRevaluedPortion + CDblSafe(dr.Item(6), 2, 0))
                        accumulatedAmortizationRevaluedPortionPerUnit = _
                            CRound(accumulatedAmortizationRevaluedPortionPerUnit _
                            + CDblSafe(dr.Item(7), ROUNDUNITASSET, 0), ROUNDUNITASSET)
                        amount = amount - CIntSafe(dr.Item(8), 0)
                        currentAmortizationCalculatedForMonths = _
                            currentAmortizationCalculatedForMonths + CIntSafe(dr.Item(9), 0)

                        If Math.Ceiling(CIntSafe(dr.Item(10), 0) / 2) <> Math.Floor(CIntSafe(dr.Item(10), 0) / 2) Then
                            isUsed = Not isUsed
                        End If

                        If CIntSafe(dr.Item(11), 0) > 0 Then
                            amortizationPeriod = CIntSafe(dr.Item(11), 0)
                        End If

                    End If

                End Using

            Else

                ' if no amortization operation exists then start at the first day of the acquisition month
                amortizationStartDate = New Date(amortizationStartDate.Year, _
                    amortizationStartDate.Month, 1)

            End If

            If currentAmortizationCalculatedForMonths >= amortizationPeriod * 12 Then
                Throw New Exception(String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_AmortizationComplete, _
                    assetName, nAssetID.ToString()))
            End If


            ' fetch all operations between amortization start date and calculation date
            myComm = New SQLCommand("FetchLongTermAssetAmortization3")
            myComm.AddParam("?AD", nAssetID)
            myComm.AddParam("?DT", amortizationStartDate.Date)
            myComm.AddParam("?DE", New Date(nDateTo.Year, nDateTo.Month, 1))
            myComm.AddParam("?MD", nEditedAmortizationOperationID)

            Using myData As DataTable = myComm.Fetch

                If isUsed Then

                    If lastAmortizationDate <> Date.MinValue Then
                        _CalculationDescription = String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_CalculationStartingWithLastCalculation, _
                            assetName, nAssetID.ToString(), amortizationStartDate.ToString("yyyy-MM-dd"), DblParser(liquidationValue))
                    Else
                        _CalculationDescription = String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_CalculationStartingWithAcquisition, _
                            assetName, nAssetID.ToString(), amortizationStartDate.ToString("yyyy-MM-dd"), DblParser(liquidationValue))
                    End If

                Else

                    ' find the first usage operation
                    Dim usageStartIsFound As Boolean = False
                    Dim currentDate As Date
                    For i = 1 To myData.Rows.Count

                        currentDate = CDateSafe(myData.Rows(i - 1).Item(12), Date.MinValue)

                        If Utilities.ConvertDatabaseCharID(Of LtaOperationType) _
                            (CStrSafe(myData.Rows(i - 1).Item(10)).Trim) = LtaOperationType.UsingStart _
                                AndAlso currentDate <> Date.MinValue Then

                            ' start calculation at that day
                            If currentDate.Month = 12 Then
                                amortizationStartDate = New Date(currentDate.Year + 1, 1, 1)
                            Else
                                amortizationStartDate = New Date(currentDate.Year, currentDate.Month + 1, 1)
                            End If

                            ' update amortization variables to the usage period start day
                            For j = 1 To myData.Rows.Count
                                If currentDate.Date < amortizationStartDate.Date Then
                                    UpdateCurrentParamsWithOperation(myData.Rows(j - 1), _
                                        acquisitionValue, acquisitionValuePerUnit, revaluedPortionValue, _
                                        revaluedPortionValuePerUnit, accumulatedAmortization, _
                                        accumulatedAmortizationPerUnit, accumulatedAmortizationRevaluedPortion, _
                                        accumulatedAmortizationRevaluedPortionPerUnit, isUsed, _
                                        amortizationPeriod, amount, False, assetName)
                                Else
                                    Exit For
                                End If
                            Next

                            usageStartIsFound = True

                            Exit For

                        End If

                    Next

                    If Not usageStartIsFound Then
                        Throw New Exception(String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_AssetNotOperational, _
                            assetName, nAssetID.ToString()))
                    End If

                    _CalculationDescription = String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_CalculationStartingWithOperationalInit, _
                        assetName, nAssetID.ToString(), amortizationStartDate.ToString("yyyy-MM-dd"), DblParser(liquidationValue))

                End If

                ' first period day is either acquisition date, last amortization date or first usage operation date
                currentPeriodStartDate = amortizationStartDate

                ' provide info of the begining of the first period
                _CalculationDescription = AddWithNewLine(_CalculationDescription, String.Format( _
                    My.Resources.Assets_LongTermAssetAmortizationCalculation_InitialParameters, _
                    GetCurrentParamsString(acquisitionValue, acquisitionValuePerUnit, _
                    revaluedPortionValue, revaluedPortionValuePerUnit, accumulatedAmortization, _
                    accumulatedAmortizationPerUnit, accumulatedAmortizationRevaluedPortion, _
                    accumulatedAmortizationRevaluedPortionPerUnit, isUsed, amortizationPeriod, _
                    currentAmortizationCalculatedForMonths, amount), _
                    GetCurrentMonthAmortizationFormula(acquisitionValue, revaluedPortionValue, _
                    accumulatedAmortization, accumulatedAmortizationRevaluedPortion, amortizationPeriod, _
                    currentAmortizationCalculatedForMonths, liquidationValue, amount), _
                    GetCurrentMonthAmortizationFormulaPerUnit(acquisitionValuePerUnit, _
                    revaluedPortionValuePerUnit, accumulatedAmortizationPerUnit, _
                    accumulatedAmortizationRevaluedPortionPerUnit, amortizationPeriod, _
                    currentAmortizationCalculatedForMonths, liquidationValue)), False)

                Dim accumulatedAmortizationAtStart As Double = accumulatedAmortization
                Dim accumulatedAmortizationPerUnitAtStart As Double = accumulatedAmortizationPerUnit
                Dim accumulatedAmortizationRevaluedPortionAtStart As Double = accumulatedAmortizationRevaluedPortion
                Dim accumulatedAmortizationRevaluedPortionPerUnitAtStart As Double = accumulatedAmortizationRevaluedPortionPerUnit

                ' single period variables
                Dim periodLength As Integer
                Dim periodEndDate As Date
                Dim amortizationPeriodEnded As Boolean
                Dim periodAmortization As Double
                Dim periodAmortizationPerUnit As Double
                Dim periodAmortizationRevaluedPortion As Double
                Dim periodAmortizationRevaluedPortionPerUnit As Double
                Dim operationsInMonth As String

                Dim amortizationPeriodIsOpen As Boolean = True

                For i = 1 To myData.Rows.Count
                    If CDate(myData.Rows(i - 1).Item(12)).Date >= currentPeriodStartDate.Date Then

                        If isUsed Then

                            ' Evaluate current period length
                            periodLength = DateDifferenceInMonths(currentPeriodStartDate, _
                                CDate(myData.Rows(i - 1).Item(12)), True, True)
                            ' It can't be longer than total amortization period
                            If currentAmortizationCalculatedForMonths + periodLength >= amortizationPeriod * 12 Then
                                amortizationPeriodEnded = True
                                periodLength = (amortizationPeriod * 12) - currentAmortizationCalculatedForMonths
                                periodEndDate = AddMonths(currentPeriodStartDate, periodLength - 1)
                            Else
                                amortizationPeriodEnded = False
                                periodEndDate = New Date(CDate(myData.Rows(i - 1).Item(12)).Year, _
                                    CDate(myData.Rows(i - 1).Item(12)).Month, _
                                    Date.DaysInMonth(CDate(myData.Rows(i - 1).Item(12)).Year, _
                                    CDate(myData.Rows(i - 1).Item(12)).Month))
                            End If

                            ' Calculate current amortization values per month
                            periodAmortization = CRound(CRound(acquisitionValue - _
                                CRound(liquidationValue * amount) - _
                                accumulatedAmortization) / ((amortizationPeriod * 12) - _
                                currentAmortizationCalculatedForMonths))
                            periodAmortizationPerUnit = CRound(CRound(acquisitionValuePerUnit - _
                                liquidationValue - accumulatedAmortizationPerUnit, ROUNDUNITASSET) / _
                                ((amortizationPeriod * 12) - currentAmortizationCalculatedForMonths), ROUNDUNITASSET)
                            If CRound(revaluedPortionValue) > 0 Then
                                periodAmortizationRevaluedPortion = CRound(CRound(revaluedPortionValue - _
                                    accumulatedAmortizationRevaluedPortion) / ((amortizationPeriod * 12) - _
                                    currentAmortizationCalculatedForMonths))
                            Else
                                periodAmortizationRevaluedPortion = 0
                            End If
                            If CRound(revaluedPortionValuePerUnit, ROUNDUNITASSET) > 0 Then
                                periodAmortizationRevaluedPortionPerUnit = CRound(CRound(revaluedPortionValuePerUnit - _
                                    accumulatedAmortizationRevaluedPortionPerUnit, ROUNDUNITASSET) / ((amortizationPeriod * 12) - _
                                    currentAmortizationCalculatedForMonths), ROUNDUNITASSET)
                            Else
                                periodAmortizationRevaluedPortionPerUnit = 0
                            End If

                            ' Update total values in this calculation
                            _AmortizationValue = CRound(_AmortizationValue + (periodLength * periodAmortization))
                            _AmortizationValuePerUnit = CRound(_AmortizationValuePerUnit _
                                + (periodLength * periodAmortizationPerUnit), ROUNDUNITASSET)
                            If periodAmortizationRevaluedPortion > 0 Then
                                _AmortizationValueRevaluedPortion = CRound(_AmortizationValueRevaluedPortion + _
                                    (periodLength * periodAmortizationRevaluedPortion))
                            End If
                            If periodAmortizationRevaluedPortionPerUnit > 0 Then
                                _AmortizationValuePerUnitRevaluedPortion = CRound(_AmortizationValuePerUnitRevaluedPortion + _
                                    (periodLength * periodAmortizationRevaluedPortionPerUnit), ROUNDUNITASSET)
                            End If
                            _AmortizationCalculatedForMonths = _AmortizationCalculatedForMonths + periodLength

                            ' Add description of amortization calculation for current period
                            _CalculationDescription = AddWithNewLine(_CalculationDescription, _
                                String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_CalculationString, _
                                currentPeriodStartDate.ToString("yyyy-MM-dd"), periodEndDate.ToString("yyyy-MM-dd"), _
                                periodLength.ToString, DblParser(periodLength * periodAmortization), _
                                DblParser(periodLength * periodAmortizationPerUnit, ROUNDUNITASSET), _
                                DblParser(periodLength * periodAmortizationRevaluedPortion), _
                                DblParser(periodLength * periodAmortizationRevaluedPortionPerUnit, ROUNDUNITASSET)), False)

                            ' if current amortization period length exceeded total amortization period,
                            ' then it was the last calculation needed
                            If amortizationPeriodEnded Then
                                amortizationPeriodIsOpen = False
                                Exit For
                            End If

                            ' update current amortization variables with the efect of this period calculations
                            currentPeriodStartDate = periodEndDate.AddDays(1) ' i.e. next month 1
                            currentAmortizationCalculatedForMonths = _
                               currentAmortizationCalculatedForMonths + periodLength
                            accumulatedAmortization = CRound(accumulatedAmortization + _
                                (periodLength * periodAmortization))
                            accumulatedAmortizationPerUnit = CRound(accumulatedAmortizationPerUnit _
                                + (periodLength * periodAmortizationPerUnit), ROUNDUNITASSET)
                            accumulatedAmortizationRevaluedPortion = CRound( _
                               accumulatedAmortizationRevaluedPortion + _
                               (periodLength * periodAmortizationRevaluedPortion))
                            accumulatedAmortizationRevaluedPortionPerUnit = CRound( _
                                accumulatedAmortizationRevaluedPortionPerUnit _
                                + (periodLength * periodAmortizationRevaluedPortionPerUnit), ROUNDUNITASSET)

                            ' update current amortization variables with all the operations within 
                            ' current month ('cause they all take effect the next month)
                            operationsInMonth = UpdateCurrentParamsForMonth(myData, periodEndDate.Year, _
                                periodEndDate.Month, acquisitionValue, acquisitionValuePerUnit, _
                                revaluedPortionValue, revaluedPortionValuePerUnit, _
                                accumulatedAmortization, accumulatedAmortizationPerUnit, _
                                accumulatedAmortizationRevaluedPortion, accumulatedAmortizationRevaluedPortionPerUnit, _
                                isUsed, amortizationPeriod, assetName)

                            ' Describe changes
                            _CalculationDescription = AddWithNewLine(_CalculationDescription, _
                                String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_NewParamsString, _
                                periodEndDate.Year.ToString, periodEndDate.Month.ToString, _
                                operationsInMonth, GetCurrentParamsString(acquisitionValue, _
                                acquisitionValuePerUnit, revaluedPortionValue, revaluedPortionValuePerUnit, _
                                accumulatedAmortization, accumulatedAmortizationPerUnit, _
                                accumulatedAmortizationRevaluedPortion, _
                                accumulatedAmortizationRevaluedPortionPerUnit, isUsed, amortizationPeriod, _
                                currentAmortizationCalculatedForMonths, amount), _
                                GetCurrentMonthAmortizationFormula(acquisitionValue, revaluedPortionValue, _
                                accumulatedAmortization, accumulatedAmortizationRevaluedPortion, amortizationPeriod, _
                                currentAmortizationCalculatedForMonths, liquidationValue, amount), _
                                GetCurrentMonthAmortizationFormulaPerUnit(acquisitionValuePerUnit, _
                                revaluedPortionValuePerUnit, accumulatedAmortizationPerUnit, _
                                accumulatedAmortizationRevaluedPortionPerUnit, amortizationPeriod, _
                                currentAmortizationCalculatedForMonths, liquidationValue)), False)

                            ' if the asset is not used anymore after the current month operations
                            ' then find the next usage period
                            If Not isUsed Then

                                ' find the new period
                                Dim newUseBegin As Date
                                Dim usageStartIsFound As Boolean = False
                                Dim currentType As LtaOperationType
                                For j = i To myData.Rows.Count
                                    currentType = Utilities.ConvertDatabaseCharID(Of LtaOperationType) _
                                        (CStrSafe(myData.Rows(j - 1).Item(10)).Trim)
                                    If CDate(myData.Rows(j - 1).Item(12)).Date >= currentPeriodStartDate.Date _
                                        AndAlso (currentType = LtaOperationType.UsingStart OrElse _
                                        currentType = LtaOperationType.UsingEnd) Then

                                        usageStartIsFound = True
                                        newUseBegin = New Date(CDate(myData.Rows(j - 1).Item(12)).Year, _
                                            CDate(myData.Rows(j - 1).Item(12)).Month, _
                                            Date.DaysInMonth(CDate(myData.Rows(j - 1).Item(12)).Year, _
                                            CDate(myData.Rows(j - 1).Item(12)).Month))
                                        newUseBegin = newUseBegin.AddDays(1)

                                        Exit For

                                    End If
                                Next

                                ' if no more usage periods are found, 
                                ' then the previous calculation was the last one
                                If Not usageStartIsFound Then
                                    _CalculationDescription = AddWithNewLine(_CalculationDescription, _
                                        String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_NonOperationalPeriodOpen, _
                                        currentPeriodStartDate.ToString("yyyy-MM-dd")), False)
                                    amortizationPeriodIsOpen = False
                                    Exit For
                                End If

                                ' update current amortization variables with all the operations 
                                ' that took place during non usage period
                                Dim operationsDuringNonUsePeriod As String = ""
                                For j = i To myData.Rows.Count
                                    If CDate(myData.Rows(j - 1).Item(12)).Date >= currentPeriodStartDate.Date _
                                        AndAlso CDate(myData.Rows(j - 1).Item(12)).Date < newUseBegin.Date Then
                                        UpdateCurrentParamsWithOperation(myData.Rows(j - 1), _
                                            acquisitionValue, acquisitionValuePerUnit, revaluedPortionValue, _
                                            revaluedPortionValuePerUnit, accumulatedAmortization, _
                                            accumulatedAmortizationPerUnit, accumulatedAmortizationRevaluedPortion, _
                                            accumulatedAmortizationRevaluedPortionPerUnit, isUsed, _
                                            amortizationPeriod, amount, True, assetName)
                                        If String.IsNullOrEmpty(operationsDuringNonUsePeriod.Trim) Then
                                            operationsDuringNonUsePeriod = Utilities.ConvertLocalizedName( _
                                                Utilities.ConvertDatabaseCharID(Of LtaOperationType) _
                                                (CStrSafe(myData.Rows(j - 1).Item(10))))
                                        Else
                                            operationsDuringNonUsePeriod = operationsDuringNonUsePeriod _
                                                & ", " & Utilities.ConvertLocalizedName( _
                                                Utilities.ConvertDatabaseCharID(Of LtaOperationType) _
                                                (CStrSafe(myData.Rows(j - 1).Item(10))))
                                        End If
                                    End If
                                Next

                                Dim operationsDescription As String

                                If String.IsNullOrEmpty(operationsDuringNonUsePeriod.Trim) Then
                                    operationsDescription = My.Resources.Assets_LongTermAssetAmortizationCalculation_NoOperationWithinPeriodString
                                Else
                                    operationsDescription = String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_OperationWithinPeriodString, _
                                        operationsDuringNonUsePeriod, _
                                        GetCurrentParamsString(acquisitionValue, acquisitionValuePerUnit, _
                                        revaluedPortionValue, revaluedPortionValuePerUnit, accumulatedAmortization, _
                                        accumulatedAmortizationPerUnit, accumulatedAmortizationRevaluedPortion, _
                                        accumulatedAmortizationRevaluedPortionPerUnit, isUsed, amortizationPeriod, _
                                        currentAmortizationCalculatedForMonths, amount), _
                                        GetCurrentMonthAmortizationFormula(acquisitionValue, revaluedPortionValue, _
                                        accumulatedAmortization, accumulatedAmortizationRevaluedPortion, _
                                        amortizationPeriod, currentAmortizationCalculatedForMonths, _
                                        liquidationValue, amount), _
                                        GetCurrentMonthAmortizationFormulaPerUnit(acquisitionValuePerUnit, _
                                        revaluedPortionValuePerUnit, accumulatedAmortizationPerUnit, _
                                        accumulatedAmortizationRevaluedPortionPerUnit, amortizationPeriod, _
                                        currentAmortizationCalculatedForMonths, liquidationValue))

                                End If

                                ' describe what's done
                                _CalculationDescription = AddWithNewLine(_CalculationDescription, _
                                    String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_NonOperationalPeriodClosed, _
                                    currentPeriodStartDate.ToString("yyyy-MM-dd"), newUseBegin.ToString("yyyy-MM-dd"), operationsDescription), False)

                                ' update new period start as next month after usage operation
                                currentPeriodStartDate = newUseBegin

                            End If

                        End If

                    End If
                Next

                If amortizationPeriodIsOpen Then

                    ' Evaluate the last period length
                    periodLength = DateDifferenceInMonths(currentPeriodStartDate, _
                        nDateTo, True, True)
                    ' It can't be longer than total amortization period
                    If currentAmortizationCalculatedForMonths + periodLength >= amortizationPeriod * 12 Then
                        periodLength = (amortizationPeriod * 12) - currentAmortizationCalculatedForMonths
                        periodEndDate = AddMonths(currentPeriodStartDate, periodLength - 1)
                    Else
                        periodEndDate = New Date(nDateTo.Year, nDateTo.Month, _
                            Date.DaysInMonth(nDateTo.Year, nDateTo.Month))
                    End If

                    ' Calculate current amortization values per month
                    periodAmortization = CRound(CRound(acquisitionValue - _
                        CRound(liquidationValue * amount) - _
                        accumulatedAmortization) / ((amortizationPeriod * 12) - _
                        currentAmortizationCalculatedForMonths))
                    periodAmortizationPerUnit = CRound(CRound(acquisitionValuePerUnit - _
                        liquidationValue - accumulatedAmortizationPerUnit, ROUNDUNITASSET) / _
                        ((amortizationPeriod * 12) - currentAmortizationCalculatedForMonths), ROUNDUNITASSET)
                    If CRound(revaluedPortionValue) > 0 Then
                        periodAmortizationRevaluedPortion = CRound(CRound(revaluedPortionValue - _
                            accumulatedAmortizationRevaluedPortion) / ((amortizationPeriod * 12) - _
                            currentAmortizationCalculatedForMonths))
                    Else
                        periodAmortizationRevaluedPortion = 0
                    End If
                    If CRound(revaluedPortionValuePerUnit, ROUNDUNITASSET) > 0 Then
                        periodAmortizationRevaluedPortionPerUnit = CRound(CRound(revaluedPortionValuePerUnit - _
                            accumulatedAmortizationRevaluedPortionPerUnit, ROUNDUNITASSET) / ((amortizationPeriod * 12) - _
                            currentAmortizationCalculatedForMonths), ROUNDUNITASSET)
                    Else
                        periodAmortizationRevaluedPortionPerUnit = 0
                    End If

                    ' Update total values in this calculation
                    _AmortizationValue = CRound(_AmortizationValue + (periodLength * periodAmortization))
                    _AmortizationValuePerUnit = CRound(_AmortizationValuePerUnit _
                        + (periodLength * periodAmortizationPerUnit), ROUNDUNITASSET)
                    If periodAmortizationRevaluedPortion > 0 Then
                        _AmortizationValueRevaluedPortion = CRound(_AmortizationValueRevaluedPortion + _
                            (periodLength * periodAmortizationRevaluedPortion))
                    End If
                    If periodAmortizationRevaluedPortionPerUnit > 0 Then
                        _AmortizationValuePerUnitRevaluedPortion = CRound(_AmortizationValuePerUnitRevaluedPortion + _
                            (periodLength * periodAmortizationRevaluedPortionPerUnit), ROUNDUNITASSET)
                    End If
                    _AmortizationCalculatedForMonths = _AmortizationCalculatedForMonths + periodLength

                    ' Add description of amortization calculation for current period
                    _CalculationDescription = AddWithNewLine(_CalculationDescription, _
                        String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_CalculationString, _
                        currentPeriodStartDate.ToString("yyyy-MM-dd"), periodEndDate.ToString("yyyy-MM-dd"), _
                        periodLength.ToString, DblParser(periodLength * periodAmortization), _
                        DblParser(periodLength * periodAmortizationPerUnit, ROUNDUNITASSET), _
                        DblParser(periodLength * periodAmortizationRevaluedPortion), _
                        DblParser(periodLength * periodAmortizationRevaluedPortionPerUnit, ROUNDUNITASSET)), False)

                End If

                _CalculationDescription = AddWithNewLine(_CalculationDescription, _
                    String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_SummaryString, _
                    DblParser(_AmortizationValue), DblParser(_AmortizationValuePerUnit, ROUNDUNITASSET), _
                    DblParser(_AmortizationValueRevaluedPortion), _
                    DblParser(_AmortizationValuePerUnitRevaluedPortion, ROUNDUNITASSET), _
                    _AmortizationCalculatedForMonths.ToString()), False)

                If amount = 1 Then
                    Dim targetAmortizationPerUnit As Double = _
                        CRound(accumulatedAmortizationAtStart + _AmortizationValue)
                    _AmortizationValuePerUnit = CRound(targetAmortizationPerUnit _
                        - accumulatedAmortizationPerUnitAtStart)
                    Dim targetAmortizationRevaluedPortionPerUnit As Double = _
                        CRound(accumulatedAmortizationRevaluedPortionAtStart _
                        + _AmortizationValueRevaluedPortion)
                    _AmortizationValuePerUnitRevaluedPortion = _
                        CRound(targetAmortizationRevaluedPortionPerUnit _
                        - accumulatedAmortizationRevaluedPortionPerUnitAtStart)
                    _CalculationDescription = AddWithNewLine(_CalculationDescription, _
                        String.Format(Assets_LongTermAssetAmortizationCalculation_CorrectionForSingleUnit, _
                        vbCrLf, DblParser(_AmortizationValuePerUnit, ROUNDUNITASSET), _
                        DblParser(_AmortizationValuePerUnitRevaluedPortion, ROUNDUNITASSET)), False)
                End If

            End Using

        End Sub


        Private Function UpdateCurrentParamsForMonth(ByVal dt As DataTable, _
            ByVal yearToUpdate As Integer, ByVal monthToUpdate As Integer, _
            ByRef acquisitionValue As Double, _
            ByRef acquisitionValuePerUnit As Double, _
            ByRef revaluedPortionValue As Double, _
            ByRef revaluedPortionValuePerUnit As Double, _
            ByRef accumulatedAmortization As Double, _
            ByRef accumulatedAmortizationPerUnit As Double, _
            ByRef accumulatedAmortizationRevaluedPortion As Double, _
            ByRef accumulatedAmortizationRevaluedPortionPerUnit As Double, _
            ByRef isUsed As Boolean, _
            ByRef amortizationPeriod As Integer, _
            ByVal assetName As String) As String

            Dim result As String = ""

            For i As Integer = 1 To dt.Rows.Count
                If CDate(dt.Rows(i - 1).Item(12)).Year = yearToUpdate AndAlso _
                    CDate(dt.Rows(i - 1).Item(12)).Month = monthToUpdate Then

                    If String.IsNullOrEmpty(result) Then
                        result = Utilities.ConvertLocalizedName( _
                            Utilities.ConvertDatabaseCharID(Of LtaOperationType) _
                            (CStrSafe(dt.Rows(i - 1).Item(10))))
                    Else
                        result = result & ", " & Utilities.ConvertLocalizedName( _
                            Utilities.ConvertDatabaseCharID(Of LtaOperationType) _
                            (CStrSafe(dt.Rows(i - 1).Item(10))))
                    End If

                    UpdateCurrentParamsWithOperation(dt.Rows(i - 1), acquisitionValue, _
                        acquisitionValuePerUnit, revaluedPortionValue, revaluedPortionValuePerUnit, _
                        accumulatedAmortization, accumulatedAmortizationPerUnit, _
                        accumulatedAmortizationRevaluedPortion, accumulatedAmortizationRevaluedPortionPerUnit, _
                        isUsed, amortizationPeriod, New Integer, True, assetName)

                End If
            Next

            Return result

        End Function

        Private Sub UpdateCurrentParamsWithOperation(ByVal dr As DataRow, _
            ByRef acquisitionValue As Double, _
            ByRef acquisitionValuePerUnit As Double, _
            ByRef revaluedPortionValue As Double, _
            ByRef revaluedPortionValuePerUnit As Double, _
            ByRef accumulatedAmortization As Double, _
            ByRef accumulatedAmortizationPerUnit As Double, _
            ByRef accumulatedAmortizationRevaluedPortion As Double, _
            ByRef accumulatedAmortizationRevaluedPortionPerUnit As Double, _
            ByRef isUsed As Boolean, _
            ByRef amortizationPeriod As Integer, _
            ByRef amount As Integer, _
            ByVal throwOnAmountChange As Boolean, _
            ByVal assetName As String)

            acquisitionValue = CRound(acquisitionValue + CDblSafe(dr.Item(0), 2, 0))
            acquisitionValuePerUnit = CRound(acquisitionValuePerUnit + CDblSafe(dr.Item(1), _
                ROUNDUNITASSET, 0), ROUNDUNITASSET)
            revaluedPortionValue = CRound(revaluedPortionValue + CDblSafe(dr.Item(2), 2, 0))
            revaluedPortionValuePerUnit = CRound(revaluedPortionValuePerUnit _
                + CDblSafe(dr.Item(3), ROUNDUNITASSET, 0), ROUNDUNITASSET)
            accumulatedAmortization = CRound(accumulatedAmortization + CDblSafe(dr.Item(4), 2, 0))
            accumulatedAmortizationPerUnit = CRound(accumulatedAmortizationPerUnit _
                + CDblSafe(dr.Item(5), ROUNDUNITASSET, 0), ROUNDUNITASSET)
            accumulatedAmortizationRevaluedPortion = CRound( _
                accumulatedAmortizationRevaluedPortion + CDblSafe(dr.Item(6), 2, 0))
            accumulatedAmortizationRevaluedPortionPerUnit = CRound( _
                accumulatedAmortizationRevaluedPortionPerUnit _
                + CDblSafe(dr.Item(7), ROUNDUNITASSET, 0), ROUNDUNITASSET)

            Dim currentType As LtaOperationType = Utilities. _
                ConvertDatabaseCharID(Of LtaOperationType)(CStrSafe(dr.Item(10)))

            If CInt(dr.Item(8)) <> 0 AndAlso throwOnAmountChange Then Throw New Exception( _
                String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_AmountChanged, _
                assetName, currentType, CDateSafe(dr.Item(12), Today).ToString("yyyy-MM-dd")))

            amount = amount - CIntSafe(dr.Item(8), 0)

            If CIntSafe(dr.Item(11), 0) > 0 Then amortizationPeriod = CIntSafe(dr.Item(11), 0)

            If currentType = LtaOperationType.UsingStart OrElse _
                currentType = LtaOperationType.UsingEnd Then isUsed = Not isUsed

        End Sub

        Private Function GetCurrentParamsString(ByVal acquisitionValue As Double, _
            ByVal acquisitionValuePerUnit As Double, _
            ByVal revaluedPortionValue As Double, _
            ByVal revaluedPortionValuePerUnit As Double, _
            ByVal accumulatedAmortization As Double, _
            ByVal accumulatedAmortizationPerUnit As Double, _
            ByVal accumulatedAmortizationRevaluedPortion As Double, _
            ByVal accumulatedAmortizationRevaluedPortionPerUnit As Double, _
            ByVal isUsed As Boolean, _
            ByVal amortizationPeriod As Integer, _
            ByVal currentAmortizationCalculatedForMonths As Integer, ByVal amount As Integer) As String

            Return String.Format(My.Resources.Assets_LongTermAssetAmortizationCalculation_ParameterString, _
                amount.ToString(), DblParser(acquisitionValue), DblParser(acquisitionValuePerUnit, ROUNDUNITASSET), _
                DblParser(revaluedPortionValue), DblParser(revaluedPortionValuePerUnit, ROUNDUNITASSET), _
                DblParser(accumulatedAmortization), DblParser(accumulatedAmortizationPerUnit, ROUNDUNITASSET), _
                DblParser(accumulatedAmortizationRevaluedPortion), DblParser(accumulatedAmortizationRevaluedPortionPerUnit, ROUNDUNITASSET), _
                amortizationPeriod.ToString, currentAmortizationCalculatedForMonths.ToString, isUsed.ToString)

        End Function

        Private Function GetCurrentMonthAmortizationFormula(ByVal acquisitionValue As Double, _
            ByVal revaluedPortionValue As Double, _
            ByVal accumulatedAmortization As Double, _
            ByVal accumulatedAmortizationRevaluedPortion As Double, _
            ByVal amortizationPeriod As Integer, _
            ByVal currentAmortizationCalculatedForMonths As Integer, _
            ByVal liquidationValue As Double, ByVal amount As Integer) As String

            Dim amortizationPerMonth As Double = CRound(CRound(acquisitionValue - _
                CRound(liquidationValue * amount) - accumulatedAmortization) _
                / ((amortizationPeriod * 12) - currentAmortizationCalculatedForMonths))
            Dim amortizationPerMonthRevaluedPortion As Double = CRound( _
                CRound(revaluedPortionValue - accumulatedAmortizationRevaluedPortion) _
                / ((amortizationPeriod * 12) - currentAmortizationCalculatedForMonths))


            If revaluedPortionValue > 0 Then

                Return String.Format("( ({0} - {1} - {2}) / ({3} * 12 - {4}) ) + ( ( {5} - {6} ) / ( {7} * 12 - {8} ) ) = {9} + {10} = {11}", _
                    DblParser(acquisitionValue), DblParser(liquidationValue * amount), _
                    DblParser(accumulatedAmortization), amortizationPeriod.ToString, _
                    currentAmortizationCalculatedForMonths.ToString, DblParser(revaluedPortionValue), _
                    DblParser(accumulatedAmortizationRevaluedPortion), _
                    amortizationPeriod.ToString, currentAmortizationCalculatedForMonths.ToString, _
                    DblParser(amortizationPerMonth), DblParser(amortizationPerMonthRevaluedPortion), _
                    DblParser(amortizationPerMonth + amortizationPerMonthRevaluedPortion))

            Else

                Return String.Format("( ({0} - {1} - {2}) / ({3} * 12 - {4}) ) = {5}", _
                    DblParser(acquisitionValue), DblParser(liquidationValue * amount), _
                    DblParser(accumulatedAmortization), amortizationPeriod.ToString, _
                    currentAmortizationCalculatedForMonths.ToString, DblParser(amortizationPerMonth))

            End If

        End Function

        Private Function GetCurrentMonthAmortizationFormulaPerUnit( _
            ByVal acquisitionValuePerUnit As Double, _
            ByVal revaluedPortionValuePerUnit As Double, _
            ByVal accumulatedAmortizationPerUnit As Double, _
            ByVal accumulatedAmortizationRevaluedPortionPerUnit As Double, _
            ByVal amortizationPeriod As Integer, _
            ByVal currentAmortizationCalculatedForMonths As Integer, _
            ByVal liquidationValue As Double) As String

            Dim amortizationPerMonth As Double = CRound(CRound(acquisitionValuePerUnit - _
                liquidationValue - accumulatedAmortizationPerUnit) _
                / ((amortizationPeriod * 12) - currentAmortizationCalculatedForMonths), ROUNDUNITASSET)
            Dim amortizationPerMonthRevaluedPortion As Double = CRound( _
                CRound(revaluedPortionValuePerUnit - accumulatedAmortizationRevaluedPortionPerUnit) _
                / ((amortizationPeriod * 12) - currentAmortizationCalculatedForMonths), ROUNDUNITASSET)


            Dim result As String = "( (" & DblParser(acquisitionValuePerUnit, ROUNDUNITASSET) & " - " _
                & DblParser(liquidationValue) & " - " & DblParser(accumulatedAmortizationPerUnit, ROUNDUNITASSET) _
                & ") / (" & amortizationPeriod.ToString & " * 12 - " & _
                currentAmortizationCalculatedForMonths.ToString & ") )"

            If CRound(revaluedPortionValuePerUnit, ROUNDUNITASSET) > 0 Then
                result = result & " + ( (" & DblParser(revaluedPortionValuePerUnit, ROUNDUNITASSET) & " - " _
                & DblParser(accumulatedAmortizationRevaluedPortionPerUnit, ROUNDUNITASSET) _
                & ") / (" & amortizationPeriod.ToString & " * 12 - " & _
                currentAmortizationCalculatedForMonths.ToString & ") ) = " _
                & DblParser(amortizationPerMonth, 4) & " + " _
                & DblParser(amortizationPerMonthRevaluedPortion, 4) & " = " _
                & DblParser(amortizationPerMonth + amortizationPerMonthRevaluedPortion, ROUNDUNITASSET)
            Else
                result = result & " = " & DblParser(amortizationPerMonth, ROUNDUNITASSET)
            End If

            Return result

        End Function


        Public Shared Function DateDifferenceInMonths(ByVal dateBegin As Date, ByVal dateEnd As Date, _
            Optional ByVal firstMonthInclusive As Boolean = False, _
            Optional ByVal lastMonthInclusive As Boolean = True) As Integer

            If dateBegin.Date > dateEnd.Date Then Return 0

            If dateBegin.Year = dateEnd.Year AndAlso dateBegin.Month = dateEnd.Month Then

                If firstMonthInclusive Then
                    Return 1
                Else
                    Return 0
                End If

            ElseIf dateBegin.Year = dateEnd.Year Then

                If firstMonthInclusive AndAlso lastMonthInclusive Then
                    Return dateEnd.Month - dateBegin.Month + 1
                ElseIf firstMonthInclusive OrElse lastMonthInclusive Then
                    Return dateEnd.Month - dateBegin.Month
                Else
                    Return dateEnd.Month - dateBegin.Month - 1
                End If

            Else

                If firstMonthInclusive AndAlso lastMonthInclusive Then
                    Return (12 - dateBegin.Month + 1) + ((dateEnd.Year - dateBegin.Year - 1) * 12) + dateEnd.Month
                ElseIf firstMonthInclusive OrElse lastMonthInclusive Then
                    Return (12 - dateBegin.Month + 1) + ((dateEnd.Year - dateBegin.Year - 1) * 12) + dateEnd.Month - 1
                Else
                    Return (12 - dateBegin.Month + 1) + ((dateEnd.Year - dateBegin.Year - 1) * 12) + dateEnd.Month - 2
                End If

            End If

        End Function

        Private Shared Function AddMonths(ByVal sourceDate As Date, ByVal monthsToAdd As Integer) As Date

            Dim result As Date = sourceDate.AddMonths(monthsToAdd)

            Return New Date(result.Year, result.Month, Date.DaysInMonth(result.Year, result.Month))

        End Function

#End Region

    End Class

End Namespace