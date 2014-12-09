Namespace Documents

    <Serializable()> _
    Public Class InvoiceReceivedItemList
        Inherits BusinessListBase(Of InvoiceReceivedItemList, InvoiceReceivedItem)

#Region " Business Methods "

        Private _IsLoading As Boolean = False
        Private _CurrencyRate As Double = 1
        Private _CurrencyCode As String = GetCurrentCompany.BaseCurrency
        Private _DefaultVatRate As Double = 21
        Private _DefaultMeasureUnit As String = ""


        Friend ReadOnly Property CurrencyRate() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRate, 6)
            End Get
        End Property

        Friend ReadOnly Property CurrencyCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrencyCode.Trim
            End Get
        End Property

        Friend ReadOnly Property DefaultVatRate() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DefaultVatRate)
            End Get
        End Property

        Friend ReadOnly Property DefaultMeasureUnit() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DefaultMeasureUnit.Trim
            End Get
        End Property


        Friend Sub UpdateCurrencyRate(ByVal nCurrencyRate As Double, ByVal nCurrencyCode As String)

            RaiseListChangedEvents = False

            _CurrencyRate = nCurrencyRate
            _CurrencyCode = nCurrencyCode
            For Each o As InvoiceReceivedItem In Me
                o.UpdateCurrencyRate(nCurrencyRate)
            Next

            RaiseListChangedEvents = True

            Me.ResetBindings()

        End Sub

        Friend Sub UpdateDate(ByVal nDate As Date)

            RaiseListChangedEvents = False

            For Each o As InvoiceReceivedItem In Me
                o.SetAttachedObjectInvoiceDate(nDate)
            Next

            RaiseListChangedEvents = True

            Me.ResetBindings()

        End Sub


        Friend Function GetInvoiceItemInfoList() As List(Of InvoiceInfo.InvoiceItemInfo)

            Dim result As New List(Of InvoiceInfo.InvoiceItemInfo)

            For Each i As InvoiceReceivedItem In Me
                result.Add(i.GetInvoiceItemInfo())
            Next

            Return result

        End Function

        Friend Function GetChronologyValidators() As IChronologicValidator()

            Dim result As New List(Of IChronologicValidator)
            For Each i As InvoiceReceivedItem In Me
                If Not i.AttachedObjectValue Is Nothing Then _
                    result.Add(i.AttachedObjectValue.ChronologyValidator)
            Next
            Return result.ToArray

        End Function


        Friend Sub MarkAsCopy()

            RaiseListChangedEvents = False
            _IsLoading = True

            Me.AllowNew = True
            Me.AllowRemove = True

            For i As Integer = Me.Count To 1 Step -1
                If Not Me.Item(i - 1).CanBeCopied Then
                    Me.RemoveAt(i - 1)
                Else
                    Me.Item(i - 1).MarkAsCopy()
                End If
            Next
            Me.DeletedList.Clear()

            _IsLoading = False
            RaiseListChangedEvents = True

            Me.ResetBindings()

        End Sub


        Protected Overrides Function AddNewCore() As Object
            Dim NewItem As InvoiceReceivedItem = InvoiceReceivedItem.NewInvoiceReceivedItem( _
                _DefaultVatRate, _DefaultMeasureUnit)
            Me.Add(NewItem)
            Return NewItem
        End Function

        Protected Overrides Sub RemoveItem(ByVal index As Integer)
            If Not _IsLoading Then
                If index < 0 OrElse index >= Me.Count Then Throw New IndexOutOfRangeException( _
                    "Index out of range in InvoiceReceivedItemList.RemoveItem. Index=" & index.ToString _
                    & "; Count=" & Me.Count.ToString & ".")
                If Not Me.Item(index).AttachedObjectValue Is Nothing AndAlso _
                    Not Me.Item(index).AttachedObjectValue.ChronologyValidator.FinancialDataCanChange Then _
                    Throw New Exception("Klaida. Pašalinti sąskaitos faktūros eilutę neleidžiama:" _
                    & vbCrLf & Me.Item(index).AttachedObjectValue.ChronologyValidator.FinancialDataCanChangeExplanation)
            End If
            MyBase.RemoveItem(index)
        End Sub


        Public Function GetAllBrokenRules() As String
            Dim result As String = GetAllBrokenRulesForList(Me)

            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function GetAllWarnings() As String

            Dim result As String = GetAllWarningsForList(Me)

            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of InvoiceReceivedItem) = Nothing

        Friend Shared Function NewInvoiceReceivedItemList(ByVal nDefaultVatRate As Double, _
            ByVal nDefaultMeasureUnit As String) As InvoiceReceivedItemList
            Return New InvoiceReceivedItemList(nDefaultVatRate, nDefaultMeasureUnit)
        End Function

        Friend Shared Function NewInvoiceReceivedItemList(ByVal info As InvoiceInfo.InvoiceInfo, _
            ByVal pCurrencyRate As Double, ByVal pCurrencyCode As String, _
            ByVal nDefaultMeasureUnit As String) As InvoiceReceivedItemList
            Return New InvoiceReceivedItemList(info, pCurrencyRate, pCurrencyCode, nDefaultMeasureUnit)
        End Function


        Friend Shared Function GetInvoiceReceivedItemList(ByVal InvoiceID As Integer, _
            ByVal pCurrencyRate As Double, ByVal pDefaultVatRate As Double, ByVal pDefaultMeasureUnit As String, _
            ByVal baseChronologyValidator As SimpleChronologicValidator) As InvoiceReceivedItemList
            Return New InvoiceReceivedItemList(InvoiceID, pCurrencyRate, _
                pDefaultVatRate, pDefaultMeasureUnit, baseChronologyValidator)
        End Function


        Public Function GetSortedList() As Csla.SortedBindingList(Of InvoiceReceivedItem)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of InvoiceReceivedItem)(Me)
            Return _SortedList
        End Function



        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
        End Sub


        Private Sub New(ByVal nDefaultVatRate As Double, ByVal nDefaultMeasureUnit As String)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            _DefaultVatRate = nDefaultVatRate
            _DefaultMeasureUnit = nDefaultMeasureUnit
        End Sub

        Private Sub New(ByVal info As InvoiceInfo.InvoiceInfo, ByVal pCurrencyRate As Double, _
            ByVal pCurrencyCode As String, ByVal nDefaultMeasureUnit As String)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            FetchInvoiceInfo(info, pCurrencyRate, pCurrencyCode, nDefaultMeasureUnit)
        End Sub

        Private Sub New(ByVal InvoiceID As Integer, ByVal pCurrencyRate As Double, _
            ByVal pDefaultVatRate As Double, ByVal pDefaultMeasureUnit As String, _
            ByVal baseChronologyValidator As SimpleChronologicValidator)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = baseChronologyValidator.FinancialDataCanChange
            Me.AllowRemove = baseChronologyValidator.FinancialDataCanChange
            Fetch(InvoiceID, pCurrencyRate, pDefaultVatRate, pDefaultMeasureUnit, baseChronologyValidator)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal InvoiceID As Integer, ByVal pCurrencyRate As Double, _
            ByVal pDefaultVatRate As Double, ByVal pDefaultMeasureUnit As String, _
            ByVal baseChronologyValidator As SimpleChronologicValidator)

            Dim myComm As New SQLCommand("FetchInvoiceReceivedItemList")
            myComm.AddParam("?MD", InvoiceID)

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                _IsLoading = True

                _CurrencyRate = pCurrencyRate
                _DefaultVatRate = pDefaultVatRate
                _DefaultMeasureUnit = pDefaultMeasureUnit

                For Each dr As DataRow In myData.Rows
                    Add(InvoiceReceivedItem.GetInvoiceReceivedItem(dr, pCurrencyRate, baseChronologyValidator))
                Next

                _IsLoading = False
                RaiseListChangedEvents = True

            End Using

        End Sub

        Private Sub FetchInvoiceInfo(ByVal info As InvoiceInfo.InvoiceInfo, _
            ByVal pCurrencyRate As Double, ByVal pCurrencyCode As String, _
            ByVal nDefaultMeasureUnit As String)

            RaiseListChangedEvents = False
            _IsLoading = True

            _CurrencyCode = pCurrencyCode
            _CurrencyRate = pCurrencyRate
            _DefaultVatRate = GetCurrentCompany.Rates.GetRate(RateType.Vat)
            _DefaultMeasureUnit = nDefaultMeasureUnit

            For Each i As InvoiceInfo.InvoiceItemInfo In info.InvoiceItems
                Add(InvoiceReceivedItem.NewInvoiceReceivedItem(i, pCurrencyRate))
            Next

            _IsLoading = False
            RaiseListChangedEvents = True

        End Sub

        Friend Sub CheckRules(ByVal parentChronologyValidator As IChronologicValidator)
            For Each item As InvoiceReceivedItem In DeletedList
                If Not item.IsNew Then item.CheckIfCanDelete(parentChronologyValidator)
            Next
            For Each item As InvoiceReceivedItem In Me
                If item.IsDirty Then item.CheckIfCanUpdate(Not parentChronologyValidator. _
                    FinancialDataCanChange, parentChronologyValidator)
            Next
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " & GetAllBrokenRules())
        End Sub

        Friend Sub Update(ByVal parent As Object)

            RaiseListChangedEvents = False
            _IsLoading = True

            For Each item As InvoiceReceivedItem In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As InvoiceReceivedItem In Me
                If item.IsNew Then
                    item.Insert(parent)
                ElseIf item.IsDirty Then
                    item.Update(parent)
                End If
            Next

            _IsLoading = False
            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace