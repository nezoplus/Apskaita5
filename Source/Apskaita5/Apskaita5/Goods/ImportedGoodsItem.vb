﻿Namespace Goods

    ''' <summary>
    ''' Represents a helper object to bulk import <see cref="GoodsItem">general goods data</see>, 
    ''' contains data of a single <see cref="GoodsItem">GoodsItem</see>.
    ''' </summary>
    ''' <remarks><see cref="GoodsItem">GoodsItem</see> cannot be used directly because it contains
    ''' non flat hierarchy (multiple price and regional content entries per single goods item).</remarks>
    <Serializable()> _
    Public NotInheritable Class ImportedGoodsItem
        Inherits BusinessBase(Of ImportedGoodsItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private Const PASTE_COLUMN_COUNT As Integer = 18

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _Name As String = ""
        Private _TradedType As Documents.TradedItemType = Documents.TradedItemType.All
        Private _DefaultAccountingMethod As GoodsAccountingMethod = GoodsAccountingMethod.Persistent
        Private _DefaultValuationMethod As GoodsValuationMethod = GoodsValuationMethod.FIFO
        Private _AccountSalesNetCosts As Long = 0
        Private _AccountPurchases As Long = 0
        Private _AccountDiscounts As Long = 0
        Private _AccountValueReduction As Long = 0
        Private _DefaultVatRateSales As Double = 0
        Private _DefaultVatRatePurchase As Double = 0
        Private _GroupInfo As GoodsGroupInfo = Nothing
        Private _IsObsolete As Boolean = False
        Private _ContentInvoice As String = ""
        Private _MeasureUnit As String = ""
        Private _ValuePerUnitSales As Double = 0
        Private _ValuePerUnitPurchases As Double = 0
        Private _InternalCode As String = ""
        Private _Barcode As String = ""


        ''' <summary>
        ''' Gets or sets a name of the goods for internal use and 
        ''' for use in invoices received. 
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="GoodsItem.Name">GoodsItem.Name</see>.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
        Public ReadOnly Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets how the goods is used in trade operations (sale, purchase, etc.) 
        ''' as a localized human readable string.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="GoodsItem.TradedTypeHumanReadable">GoodsItem.TradedTypeHumanReadable.</see>.</remarks>
        <LocalizedEnumField(GetType(Documents.TradedItemType), False, "")> _
        Public ReadOnly Property TypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Utilities.ConvertLocalizedName(_TradedType)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets an <see cref="General.Account.ID">account</see> that is used for
        ''' the value of goods discarded (sold etc.). 
        ''' If the accounting method is set to<see cref="GoodsAccountingMethod.Periodic">
        ''' Periodic</see>, this account is fixed and mainly used by an <see cref="GoodsComplexOperationInventorization">
        ''' inventorization</see> operation (also in some cases by discount and additional costs). 
        ''' If the accounting method is set to<see cref="GoodsAccountingMethod.Persistent">
        ''' Persistent</see>, this account is used as a default goods discard costs
        ''' account by almost every operation, i.e. an operation can override it.
        ''' </summary>
        ''' <remarks>See methodology for BAS No 9 ""Stores"" para. 5.2 and 40.
        ''' Corresponds to <see cref="GoodsItem.AccountSalesNetCosts">GoodsItem.AccountSalesNetCosts</see>.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False, 6)> _
        Public ReadOnly Property AccountSalesNetCosts() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountSalesNetCosts
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets an <see cref="General.Account.ID">account</see> that is used for
        ''' the value of goods received (bought) by the <see cref="GoodsAccountingMethod.Periodic">
        ''' periodic accounting method</see>, not applicable for persistent accounting method,
        ''' that uses <see cref="Warehouse.WarehouseAccount">warehouse account</see>
        ''' for the same purpose.
        ''' </summary>
        ''' <remarks>See methodology for BAS No 9 ""Stores"" para. 8.
        ''' Corresponds to <see cref="GoodsItem.AccountPurchases">GoodsItem.AccountPurchases</see>.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False, 6)> _
        Public ReadOnly Property AccountPurchases() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountPurchases
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets an <see cref="General.Account.ID">account</see> that is used for
        ''' discounts received by the <see cref="GoodsAccountingMethod.Periodic">
        ''' periodic accounting method</see>, not applicable for persistent accounting method.
        ''' </summary>
        ''' <remarks>See methodology for BAS No 9 ""Stores"" para. 5.2.
        ''' Corresponds to <see cref="GoodsItem.AccountDiscounts">GoodsItem.AccountDiscounts</see>.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False, 6)> _
        Public ReadOnly Property AccountDiscounts() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountDiscounts
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets an <see cref="General.Account.ID">account</see> that is used for
        ''' goods value reduction (when goods are revalued to match market prices). 
        ''' Handling of this account does not depend on the accounting method.
        ''' </summary>
        ''' <remarks>See methodology for BAS No 9 ""Stores"" para. 24 - 33.
        ''' Corresponds to <see cref="GoodsItem.AccountValueReduction">GoodsItem.AccountValueReduction</see>.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public ReadOnly Property AccountValueReduction() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountValueReduction
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a default VAT rate for the goods beeing sold.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="GoodsItem.DefaultVatRateSales">GoodsItem.DefaultVatRateSales</see>.</remarks>
        <TaxRateField(ValueRequiredLevel.Optional, ApskaitaObjects.Settings.TaxRateType.Vat)> _
        Public ReadOnly Property DefaultVatRateSales() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DefaultVatRateSales)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a default VAT rate for the goods beeing purchased.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="GoodsItem.DefaultVatRatePurchase">GoodsItem.DefaultVatRatePurchase</see>.</remarks>
        <TaxRateField(ValueRequiredLevel.Optional, ApskaitaObjects.Settings.TaxRateType.Vat)> _
        Public ReadOnly Property DefaultVatRatePurchase() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DefaultVatRatePurchase)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a goods accounting method (periodic/persistent) 
        ''' as a localized human readable string.
        ''' </summary>
        ''' <remarks>Cannot be changed after the first operation with the goods.
        ''' Corresponds to <see cref="GoodsItem.AccountingMethodHumanReadable">GoodsItem.AccountingMethodHumanReadable</see>.</remarks>
        <LocalizedEnumField(GetType(GoodsAccountingMethod), False, "")> _
        Public ReadOnly Property DefaultAccountingMethodHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Utilities.ConvertLocalizedName(_DefaultAccountingMethod)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a goods valuation method (FIFO, LIFO, average, etc.) 
        ''' as a localized human readable string.
        ''' </summary>
        ''' <remarks>Cannot be changed after the first operation with the goods, 
        ''' but could be prospectively overriden by a <see cref="GoodsOperationValuationMethod">
        ''' valuation method change operation</see>.
        ''' Corresponds to <see cref="GoodsItem.DefaultValuationMethodHumanReadable">GoodsItem.DefaultValuationMethodHumanReadable</see>.</remarks>
        <LocalizedEnumField(GetType(GoodsValuationMethod), False, "")> _
        Public ReadOnly Property DefaultValuationMethodHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Utilities.ConvertLocalizedName(_DefaultValuationMethod)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a custom goods group that the goods are assigned to.
        ''' </summary>
        ''' <remarks>Use <see cref="HelperLists.GoodsGroupInfoList">GoodsGroupInfoList</see> for a datasource.
        ''' Corresponds to <see cref="GoodsItem.Group">GoodsItem.Group</see>.</remarks>
        <GoodsGroupField(ValueRequiredLevel.Optional)> _
        Public ReadOnly Property GroupInfo() As GoodsGroupInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GroupInfo
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets whether the goods are obsolete (no longer in use).
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="GoodsItem.IsObsolete">GoodsItem.IsObsolete</see>.</remarks>
        Public ReadOnly Property IsObsolete() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsObsolete
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a description of the object within an invoice in the base language.
        ''' </summary>
        ''' <remarks>Corresponds to an entry in the <see cref="GoodsItem.RegionalContents">GoodsItem.RegionalContents</see>.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
        Public ReadOnly Property ContentInvoice() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContentInvoice.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets an object's measure unit within an invoice in the base language.
        ''' </summary>
        ''' <remarks>Corresponds to an entry in the <see cref="GoodsItem.RegionalContents">GoodsItem.RegionalContents</see>.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 50)> _
        Public ReadOnly Property MeasureUnit() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MeasureUnit.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets price for sale per unit in the base currency.
        ''' </summary>
        ''' <remarks>Corresponds to an entry in the <see cref="GoodsItem.RegionalPrices">GoodsItem.RegionalPrices</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDUNITINVOICEMADE)> _
        Public ReadOnly Property ValuePerUnitSales() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ValuePerUnitSales, ROUNDUNITINVOICEMADE)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets price for purchase per unit in the base currency.
        ''' </summary>
        ''' <remarks>Corresponds to an entry in the <see cref="GoodsItem.RegionalPrices">GoodsItem.RegionalPrices</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDUNITINVOICERECEIVED)> _
        Public ReadOnly Property ValuePerUnitPurchases() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ValuePerUnitPurchases, ROUNDUNITINVOICERECEIVED)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a custom goods code. (for internal company use 
        ''' or for integration with external CRM systems)
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="GoodsItem.InternalCode">GoodsItem.InternalCode</see>.</remarks>
        <StringField(ValueRequiredLevel.Optional, 50)> _
        Public ReadOnly Property InternalCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InternalCode.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a goods barcode.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="GoodsItem.Barcode">GoodsItem.Barcode</see>.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public ReadOnly Property Barcode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Barcode.Trim
            End Get
        End Property


        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return String.Format(My.Resources.Common_ErrorInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))
        End Function

        Public Function GetWarningString() As String _
        Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return String.Format(My.Resources.Common_WarningInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning))
        End Function

        Public Function HasWarnings() As Boolean
            Return BrokenRulesCollection.WarningCount > 0
        End Function


        ''' <summary>
        ''' Gets expected fields count in (tab delimited) paste string.
        ''' </summary>
        Public Shared Function GetPasteStringColumnCount() As Integer
            Return PASTE_COLUMN_COUNT
        End Function

        ''' <summary>
        ''' Gets an array of expected fields sequence in (tab delimited) paste string.
        ''' </summary>
        Public Shared Function GetPasteStringColumns() As String()
            Return My.Resources.Goods_ImportedGoodsItem_PasteColumns.Split(New String() {"<BR>"}, _
                StringSplitOptions.RemoveEmptyEntries)
        End Function

        ''' <summary>
        ''' Gets a human readable description of expected fields sequence in (tab delimited) paste string.
        ''' </summary>
        Public Shared Function GetPasteStringColumnsDescription() As String
            Return String.Format(My.Resources.Goods_ImportedGoodsItem_PasteColumnsDescription, PASTE_COLUMN_COUNT, _
                String.Join(", ", My.Resources.Goods_ImportedGoodsItem_PasteColumns.Split(New String() {"<BR>"}, _
                StringSplitOptions.RemoveEmptyEntries)))
        End Function

        ''' <summary>
        ''' Gets a datatable which columns corresponds to the required imported data 
        ''' (propert name, data type and regionalized caption).
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function GetDataTableSpecification() As DataTable

            Dim result As DataTable = Utilities.GetDataTableSpecification(GetType(ImportedGoodsItem), New String() _
                {"TypeHumanReadable", "DefaultAccountingMethodHumanReadable",
                "DefaultValuationMethodHumanReadable", "GroupInfo"})

            Dim typeHumanReadableTypeColumn As New DataColumn("TypeHumanReadable", GetType(Integer))
            typeHumanReadableTypeColumn.Caption = GetResourcesPropertyName(GetType(ImportedGoodsItem), "TypeHumanReadable")
            result.Columns.Add(typeHumanReadableTypeColumn)

            Dim defaultAccountingMethodHumanReadableColumn As New DataColumn("DefaultAccountingMethodHumanReadable", GetType(Integer))
            defaultAccountingMethodHumanReadableColumn.Caption = GetResourcesPropertyName(GetType(ImportedGoodsItem), "DefaultAccountingMethodHumanReadable")
            result.Columns.Add(defaultAccountingMethodHumanReadableColumn)

            Dim defaultValuationMethodHumanReadableColumn As New DataColumn("DefaultValuationMethodHumanReadable", GetType(Integer))
            defaultValuationMethodHumanReadableColumn.Caption = GetResourcesPropertyName(GetType(ImportedGoodsItem), "DefaultValuationMethodHumanReadable")
            result.Columns.Add(defaultValuationMethodHumanReadableColumn)

            Dim groupInfoColumn As New DataColumn("GroupInfo", GetType(String))
            groupInfoColumn.Caption = GetResourcesPropertyName(GetType(ImportedGoodsItem), "GroupInfo")
            result.Columns.Add(groupInfoColumn)

            Return result

        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return _Name
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Name"))
            ValidationRules.AddRule(AddressOf CommonValidation.AccountFieldValidation, _
                New Csla.Validation.RuleArgs("AccountValueReduction"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("MeasureUnit"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("ContentInvoice"))

            ValidationRules.AddRule(AddressOf PeriodicAccountsValidation, _
                New Validation.RuleArgs("AccountSalesNetCosts"))
            ValidationRules.AddRule(AddressOf PeriodicAccountsValidation, _
                New Validation.RuleArgs("AccountPurchases"))
            ValidationRules.AddRule(AddressOf PeriodicAccountsValidation, _
                New Validation.RuleArgs("AccountDiscounts"))

            ValidationRules.AddDependantProperty("AccountingMethod", "AccountSalesNetCosts", False)
            ValidationRules.AddDependantProperty("AccountingMethod", "AccountPurchases", False)
            ValidationRules.AddDependantProperty("AccountingMethod", "AccountDiscounts", False)

        End Sub

        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function PeriodicAccountsValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            If DirectCast(target, ImportedGoodsItem)._DefaultAccountingMethod _
                <> GoodsAccountingMethod.Periodic Then Return True

            Return CommonValidation.AccountFieldValidation(target, e)

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function GetImportedGoodsItem(ByVal s As String(), _
            ByVal groups As GoodsGroupInfoList, ByVal accountList As List(Of Long)) As ImportedGoodsItem
            Return New ImportedGoodsItem(s, groups, accountList)
        End Function

        Friend Shared Function GetImportedGoodsItem(ByVal dr As DataRow,
            ByVal groups As GoodsGroupInfoList, ByVal accountList As List(Of Long)) As ImportedGoodsItem
            Return New ImportedGoodsItem(dr, groups, accountList)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal s As String(), ByVal groups As GoodsGroupInfoList, _
            ByVal accountList As List(Of Long))
            MarkAsChild()
            Fetch(s, groups, accountList)
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal groups As GoodsGroupInfoList,
            ByVal accountList As List(Of Long))
            MarkAsChild()
            Fetch(dr, groups, accountList)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal s As String(), ByVal groups As GoodsGroupInfoList, _
            ByVal accountList As List(Of Long))

            _Name = CStrSafe(GetItem(s, 0)).Trim
            _MeasureUnit = CStrSafe(GetItem(s, 1)).Trim
            _InternalCode = CStrSafe(GetItem(s, 2)).Trim
            _Barcode = CStrSafe(GetItem(s, 3)).Trim
            _GroupInfo = groups.GetItem(CStrSafe(GetItem(s, 4)).Trim)
            _ContentInvoice = CStrSafe(GetItem(s, 5)).Trim
            _TradedType = Utilities.ConvertDatabaseID(Of Documents.TradedItemType) _
                (CIntSafe(GetItem(s, 6), 2))
            _DefaultAccountingMethod = Utilities.ConvertDatabaseID(Of GoodsAccountingMethod) _
                (CIntSafe(GetItem(s, 7), 0))
            _DefaultValuationMethod = Utilities.ConvertDatabaseID(Of GoodsValuationMethod) _
                (CIntSafe(GetItem(s, 8)))
            _AccountSalesNetCosts = CLongSafe(GetItem(s, 9), 0)
            _AccountPurchases = CLongSafe(GetItem(s, 10), 0)
            _AccountDiscounts = CLongSafe(GetItem(s, 11), 0)
            _AccountValueReduction = CLongSafe(GetItem(s, 12), 0)
            Double.TryParse(CStrSafe(GetItem(s, 13)), _DefaultVatRateSales)
            _DefaultVatRateSales = CRound(_DefaultVatRateSales)
            Double.TryParse(CStrSafe(GetItem(s, 14)), _DefaultVatRatePurchase)
            _DefaultVatRatePurchase = CRound(_DefaultVatRatePurchase)
            Double.TryParse(CStrSafe(GetItem(s, 15)), _ValuePerUnitSales)
            _ValuePerUnitSales = CRound(_ValuePerUnitSales, ROUNDUNITINVOICEMADE)
            Double.TryParse(CStrSafe(GetItem(s, 16)), _ValuePerUnitPurchases)
            _ValuePerUnitPurchases = CRound(_ValuePerUnitPurchases, ROUNDUNITINVOICERECEIVED)
            _IsObsolete = ConvertDbBoolean(CIntSafe(GetItem(s, 17), 0))

            If Not accountList.Contains(_AccountSalesNetCosts) Then _AccountSalesNetCosts = 0
            If Not accountList.Contains(_AccountPurchases) Then _AccountPurchases = 0
            If Not accountList.Contains(_AccountDiscounts) Then _AccountDiscounts = 0
            If Not accountList.Contains(_AccountValueReduction) Then _AccountValueReduction = 0

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal dr As DataRow, ByVal groups As GoodsGroupInfoList,
            ByVal accountList As List(Of Long))

            _Name = DirectCast(dr.Item("Name"), String)
            _MeasureUnit = DirectCast(dr.Item("MeasureUnit"), String)
            _InternalCode = DirectCast(dr.Item("InternalCode"), String)
            _Barcode = DirectCast(dr.Item("Barcode"), String)
            _GroupInfo = groups.GetItem(DirectCast(dr.Item("GroupInfo"), String))
            _ContentInvoice = DirectCast(dr.Item("ContentInvoice"), String)
            _TradedType = Utilities.ConvertDatabaseID(Of Documents.TradedItemType) _
                (DirectCast(dr.Item("TypeHumanReadable"), Integer))
            _DefaultAccountingMethod = Utilities.ConvertDatabaseID(Of GoodsAccountingMethod) _
                (DirectCast(dr.Item("DefaultAccountingMethodHumanReadable"), Integer))
            _DefaultValuationMethod = Utilities.ConvertDatabaseID(Of GoodsValuationMethod) _
                (DirectCast(dr.Item("DefaultValuationMethodHumanReadable"), Integer))
            _AccountSalesNetCosts = DirectCast(dr.Item("AccountSalesNetCosts"), Long)
            _AccountPurchases = DirectCast(dr.Item("AccountPurchases"), Long)
            _AccountDiscounts = DirectCast(dr.Item("AccountDiscounts"), Long)
            _AccountValueReduction = DirectCast(dr.Item("AccountValueReduction"), Long)
            _DefaultVatRateSales = CRound(DirectCast(dr.Item("DefaultVatRateSales"), Double))
            _DefaultVatRatePurchase = CRound(DirectCast(dr.Item("DefaultVatRatePurchase"), Double))
            _ValuePerUnitSales = CRound(DirectCast(dr.Item("ValuePerUnitSales"), Double), ROUNDUNITINVOICEMADE)
            _ValuePerUnitPurchases = CRound(DirectCast(dr.Item("ValuePerUnitPurchases"), Double), ROUNDUNITINVOICERECEIVED)
            _IsObsolete = DirectCast(dr.Item("IsObsolete"), Boolean)

            If Not accountList.Contains(_AccountSalesNetCosts) Then _AccountSalesNetCosts = 0
            If Not accountList.Contains(_AccountPurchases) Then _AccountPurchases = 0
            If Not accountList.Contains(_AccountDiscounts) Then _AccountDiscounts = 0
            If Not accountList.Contains(_AccountValueReduction) Then _AccountValueReduction = 0

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Friend Sub Insert()

            Dim item As GoodsItem = GoodsItem.NewGoodsItem

            item.AccountDiscounts = _AccountDiscounts
            item.AccountingMethod = _DefaultAccountingMethod
            item.AccountPurchases = _AccountPurchases
            item.AccountSalesNetCosts = _AccountSalesNetCosts
            item.AccountValueReduction = _AccountValueReduction
            item.Barcode = _Barcode
            item.DefaultValuationMethod = _DefaultValuationMethod
            item.DefaultVatRatePurchase = _DefaultVatRatePurchase
            item.DefaultVatRateSales = _DefaultVatRateSales
            item.Group = _GroupInfo
            item.InternalCode = _InternalCode
            item.IsObsolete = _IsObsolete
            item.MeasureUnit = _MeasureUnit
            item.Name = _Name
            item.TradedType = _TradedType

            item.RegionalContents.AddNew()
            item.RegionalContents(0).ContentInvoice = _ContentInvoice
            item.RegionalContents(0).MeasureUnit = _MeasureUnit
            item.RegionalContents(0).LanguageCode = LanguageCodeLith

            If Not CRound(_ValuePerUnitPurchases, ROUNDUNITINVOICERECEIVED) > 0 AndAlso _
                Not CRound(_ValuePerUnitSales, ROUNDUNITINVOICEMADE) > 0 Then
                item.RegionalPrices.AddNew()
                item.RegionalPrices(0).CurrencyCode = GetCurrentCompany.BaseCurrency
                item.RegionalPrices(0).ValuePerUnitPurchases = _ValuePerUnitPurchases
                item.RegionalPrices(0).ValuePerUnitSales = _ValuePerUnitSales
            End If

            item.DoInsert()

            MarkOld()

        End Sub

        Friend Shared Function GetItem(ByVal s As String(), ByVal index As Integer) As String
            If s Is Nothing OrElse index + 1 > s.Length Then Return ""
            Return s(index)
        End Function

#End Region

    End Class

End Namespace