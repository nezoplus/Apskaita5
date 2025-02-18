﻿Imports ApskaitaObjects.Attributes
Imports ApskaitaObjects.Settings

Namespace Documents

    ''' <summary>
    ''' Represents a service that is beeing sold or purchased by the company.
    ''' </summary>
    ''' <remarks>Values are stored in the database table paslaugos.</remarks>
    <Serializable()> _
    Public NotInheritable Class Service
        Inherits BusinessBase(Of Service)
        Implements IIsDirtyEnough, IRegionalDataObject, IValidationMessageProvider

#Region " Business Methods "

        Private Const MYREGIONALIZEDOBJECTTYPE As RegionalizedObjectType = RegionalizedObjectType.Service

        Private _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _Type As TradedItemType = TradedItemType.All
        Private _TypeHumanReadable As String = Utilities.ConvertLocalizedName(TradedItemType.All)
        Private _NameShort As String = ""
        Private _Amount As Double = 0
        Private _AccountSales As Long = 0
        Private _RateVatSales As Double = 0
        Private _DeclarationSchemaSales As VatDeclarationSchemaInfo = Nothing
        Private _AccountVatSales As Long = 0
        Private _AccountPurchase As Long = 0
        Private _RateVatPurchase As Double = 0
        Private _DeclarationSchemaPurchase As VatDeclarationSchemaInfo = Nothing
        Private _AccountVatPurchase As Long = 0
        Private _ServiceCode As String = ""
        Private WithEvents _RegionalContents As RegionalContentList
        Private WithEvents _RegionalPrices As RegionalPriceList
        Private _IsObsolete As Boolean = False
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private _IsInUse As Boolean = False

        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _RegionalContentsSortedList As Csla.SortedBindingList(Of RegionalContent) = Nothing
        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _RegionalPricesSortedList As Csla.SortedBindingList(Of RegionalPrice) = Nothing


        ''' <summary>
        ''' Gets an ID of the service that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in the database field paslaugos.ID.</remarks>
        Public ReadOnly Property ID() As Integer _
            Implements IRegionalDataObject.RegionalObjectID
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets a type of the service as <see cref="RegionalizedObjectType.Service">regionalizable object type</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property RegionalObjectType() As RegionalizedObjectType _
            Implements IRegionalDataObject.RegionalObjectType
            Get
                Return MYREGIONALIZEDOBJECTTYPE
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the service was inserted into the database.
        ''' </summary>
        ''' <remarks>Value is stored in the database field paslaugos.InsertDate.</remarks>
        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the service was last updated.
        ''' </summary>
        ''' <remarks>Value is stored in the database field paslaugos.UpdateDate.</remarks>
        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets how the service is used in trade operations (sale, purchase, etc.).
        ''' </summary>
        ''' <remarks>Value is stored in the database field paslaugos.Tip.</remarks>
        Public Property [Type]() As TradedItemType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As TradedItemType)
                CanWriteProperty(True)
                If _Type <> value Then
                    _Type = value
                    _TypeHumanReadable = Utilities.ConvertLocalizedName(value)
                    PropertyHasChanged()
                    PropertyHasChanged("TypeHumanReadable")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets how the service is used in trade operations (sale, purchase, etc.) 
        ''' as localized human readable string.
        ''' </summary>
        ''' <remarks>Value is stored in the database field paslaugos.Tip.</remarks>
        <LocalizedEnumField(GetType(TradedItemType), False, "")> _
        Public Property TypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TypeHumanReadable.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                Dim enumValue As TradedItemType = Utilities.ConvertLocalizedName(Of TradedItemType)(value)
                If enumValue <> _Type Then
                    _Type = enumValue
                    _TypeHumanReadable = Utilities.ConvertLocalizedName(enumValue)
                    PropertyHasChanged()
                    PropertyHasChanged("Type")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a short name of the service (as used in dropboxes).
        ''' </summary>
        ''' <remarks>Value is stored in the database field paslaugos.TrPav.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
        Public Property NameShort() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NameShort.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _NameShort.Trim <> value.Trim Then
                    _NameShort = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a default amount of the service.
        ''' </summary>
        ''' <remarks>Value is stored in the database field paslaugos.Amount.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDAMOUNTINVOICEMADE)> _
        Public Property Amount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Amount, ROUNDAMOUNTINVOICEMADE)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Amount, ROUNDAMOUNTINVOICEMADE) <> CRound(value, ROUNDAMOUNTINVOICEMADE) Then
                    _Amount = CRound(value, ROUNDAMOUNTINVOICEMADE)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a default <see cref="General.Account.ID">sales account</see> for the service.
        ''' </summary>
        ''' <remarks>Value is stored in the database field paslaugos.S_Sask.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, True, 5)> _
        Public Property AccountSales() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountSales
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _AccountSales <> value Then
                    _AccountSales = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a default VAT rate for the service beeing sold.
        ''' </summary>
        ''' <remarks>Value is stored in the database field paslaugos.PVM.</remarks>
        <TaxRateField(ValueRequiredLevel.Optional, TaxRateType.Vat)> _
        Public Property RateVatSales() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateVatSales)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_RateVatSales) <> CRound(value) Then
                    _RateVatSales = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the applicable VAT declaration schema for the services sold.
        ''' </summary>
        ''' <remarks>Value is stored in the database table paslaugos.DeclarationSchemaIDSales.</remarks>
        <VatDeclarationSchemaField(ValueRequiredLevel.Recommended, TradedItemType.Sales)> _
        Public Property DeclarationSchemaSales() As VatDeclarationSchemaInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DeclarationSchemaSales
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As VatDeclarationSchemaInfo)
                CanWriteProperty(True)
                If Not (_DeclarationSchemaSales Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _DeclarationSchemaSales Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _DeclarationSchemaSales = value) Then
                    _DeclarationSchemaSales = value
                    If Not _DeclarationSchemaSales Is Nothing AndAlso Not _DeclarationSchemaSales.IsEmpty Then
                        RateVatSales = _DeclarationSchemaSales.VatRate
                    End If
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a default <see cref="General.Account.ID">sales VAT account</see> for the service.
        ''' </summary>
        ''' <remarks>Value is stored in the database field paslaugos.P_Sask.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, True, 2, 4, 6)> _
        Public Property AccountVatSales() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountVatSales
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _AccountVatSales <> value Then
                    _AccountVatSales = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a default <see cref="General.Account.ID">purchase (costs) account</see> for the service.
        ''' </summary>
        ''' <remarks>Value is stored in the database field paslaugos.AccountPurchase.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, True, 2, 6)> _
        Public Property AccountPurchase() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountPurchase
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _AccountPurchase <> value Then
                    _AccountPurchase = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a default VAT rate for the service beeing purchased.
        ''' </summary>
        ''' <remarks>Value is stored in the database field paslaugos.RateVatPurchase.</remarks>
        <TaxRateField(ValueRequiredLevel.Optional, TaxRateType.Vat)> _
        Public Property RateVatPurchase() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateVatPurchase)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_RateVatPurchase) <> CRound(value) Then
                    _RateVatPurchase = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the applicable VAT declaration schema for the services bought.
        ''' </summary>
        ''' <remarks>Value is stored in the database table paslaugos.DeclarationSchemaIDPurchase.</remarks>
        <VatDeclarationSchemaField(ValueRequiredLevel.Recommended, TradedItemType.Purchases)> _
        Public Property DeclarationSchemaPurchase() As VatDeclarationSchemaInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DeclarationSchemaPurchase
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As VatDeclarationSchemaInfo)
                CanWriteProperty(True)
                If Not (_DeclarationSchemaPurchase Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _DeclarationSchemaPurchase Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _DeclarationSchemaPurchase = value) Then
                    _DeclarationSchemaPurchase = value
                    If Not _DeclarationSchemaPurchase Is Nothing AndAlso Not _DeclarationSchemaPurchase.IsEmpty Then
                        RateVatPurchase = _DeclarationSchemaPurchase.VatRate
                    End If
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a default <see cref="General.Account.ID">purchase VAT account</see> for the service.
        ''' </summary>
        ''' <remarks>Value is stored in the database field paslaugos.AccountVatPurchase.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, True, 2, 4, 6)> _
        Public Property AccountVatPurchase() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountVatPurchase
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _AccountVatPurchase <> value Then
                    _AccountVatPurchase = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an internal code of the service (as used in the company).
        ''' </summary>
        ''' <remarks>Value is stored in the database field paslaugos.ServiceCode.</remarks>
        <StringField(ValueRequiredLevel.Optional, 15)> _
        Public Property ServiceCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ServiceCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _ServiceCode.Trim <> value.Trim Then
                    _ServiceCode = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a collection of localized names for the service.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property RegionalContents() As RegionalContentList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _RegionalContents
            End Get
        End Property

        ''' <summary>
        ''' Gets a collection of localized prices for the service.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property RegionalPrices() As RegionalPriceList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _RegionalPrices
            End Get
        End Property

        ''' <summary>
        ''' Gets a sortable collection of localized names for the service.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property RegionalContentsSorted() As Csla.SortedBindingList(Of RegionalContent)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _RegionalContentsSortedList Is Nothing Then _RegionalContentsSortedList _
                    = New Csla.SortedBindingList(Of RegionalContent)(_RegionalContents)
                Return _RegionalContentsSortedList
            End Get
        End Property

        ''' <summary>
        ''' Gets a sortable collection of localized prices for the service.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property RegionalPricesSorted() As Csla.SortedBindingList(Of RegionalPrice)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _RegionalPricesSortedList Is Nothing Then _RegionalPricesSortedList _
                    = New Csla.SortedBindingList(Of RegionalPrice)(_RegionalPrices)
                Return _RegionalPricesSortedList
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets whether the service is obsolete (no longer in use).
        ''' </summary>
        ''' <remarks>Value is stored in the database field paslaugos.Obsol.</remarks>
        Public Property IsObsolete() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsObsolete
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _IsObsolete <> value Then
                    _IsObsolete = value
                    PropertyHasChanged()
                End If
            End Set
        End Property


        ''' <summary>
        ''' Gets whether the service is in use by any other object.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IsInUse() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsInUse
            End Get
        End Property

        ''' <summary>
        ''' Returnes TRUE if the object is new and contains some user provided data 
        ''' OR
        ''' object is not new and was changed by the user.
        ''' </summary>
        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not StringIsNullOrEmpty(_NameShort) OrElse _
                    (Not _RegionalContents Is Nothing AndAlso _RegionalContents.Count > 0) OrElse _
                    (Not _RegionalPrices Is Nothing AndAlso _RegionalPrices.Count > 0))
            End Get
        End Property


        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _RegionalContents.IsDirty OrElse _RegionalPrices.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid AndAlso _RegionalContents.IsValid AndAlso _RegionalPrices.IsValid
            End Get
        End Property



        Public Overrides Function Save() As Service

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Dim result As Service = MyBase.Save
            HelperLists.ServiceInfoList.InvalidateCache()
            HelperLists.RegionalInfoDictionary.InvalidateCache()
            Return result

        End Function


        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = ""
            If Not MyBase.IsValid Then result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
            If Not _RegionalContents.IsValid Then result = AddWithNewLine(result, _
                _RegionalContents.GetAllBrokenRules, False)
            If Not _RegionalPrices.IsValid Then result = AddWithNewLine(result, _
                _RegionalPrices.GetAllBrokenRules, False)
            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = ""
            If MyBase.BrokenRulesCollection.WarningCount > 0 Then _
                result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
            If _RegionalContents.HasWarnings() Then _
                result = AddWithNewLine(result, _RegionalContents.GetAllWarnings, False)
            If _RegionalPrices.HasWarnings() Then _
                result = AddWithNewLine(result, _RegionalPrices.GetAllWarnings, False)
            If _RegionalContents.Count < 1 Then result = AddWithNewLine(result, _
                My.Resources.Documents_Service_RegionalContentListEmpty, False)
            If _RegionalPrices.Count < 1 Then result = AddWithNewLine(result, _
                My.Resources.Documents_Service_RegionalPriceListEmpty, False)
            Return result
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            Return (MyBase.BrokenRulesCollection.WarningCount > 0 OrElse _
                _RegionalContents.Count < 1 OrElse _RegionalPrices.Count < 1 OrElse _
                _RegionalContents.HasWarnings OrElse _RegionalPrices.HasWarnings())
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Documents_Service_ToString, _
                _TypeHumanReadable, _NameShort, _ID.ToString())
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("NameShort"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("ServiceCode"))

            ValidationRules.AddRule(AddressOf AmountValidation, New Validation.RuleArgs("Amount"))
            ValidationRules.AddRule(AddressOf AccountSalesValidation, New Validation.RuleArgs("AccountSales"))
            ValidationRules.AddRule(AddressOf AccountVatSalesValidation, New Validation.RuleArgs("AccountVatSales"))
            ValidationRules.AddRule(AddressOf AccountPurchaseValidation, New Validation.RuleArgs("AccountPurchase"))
            ValidationRules.AddRule(AddressOf AccountVatPurchaseValidation, New Validation.RuleArgs("AccountVatPurchase"))

            ValidationRules.AddRule(AddressOf DeclarationSchemaPurchaseValidation, _
                New VatDeclarationSchemaFieldRuleArgs("DeclarationSchemaPurchase", "RateVatPurchase"))
            ValidationRules.AddRule(AddressOf DeclarationSchemaSalesValidation, _
                New VatDeclarationSchemaFieldRuleArgs("DeclarationSchemaSales", "RateVatSales"))

            ValidationRules.AddDependantProperty("TypeHumanReadable", "AccountSales", False)
            ValidationRules.AddDependantProperty("TypeHumanReadable", "AccountPurchase", False)
            ValidationRules.AddDependantProperty("TypeHumanReadable", "AccountVatSales", False)
            ValidationRules.AddDependantProperty("TypeHumanReadable", "AccountVatPurchase", False)
            ValidationRules.AddDependantProperty("RateVatSales", "AccountVatSales", False)
            ValidationRules.AddDependantProperty("RateVatPurchase", "AccountVatPurchase", False)
            ValidationRules.AddDependantProperty("RateVatSales", "DeclarationSchemaSales", False)
            ValidationRules.AddDependantProperty("RateVatPurchase", "DeclarationSchemaPurchase", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property Amount is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AmountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As Service = DirectCast(target, Service)

            If Not DoubleFieldValidation(target, e) Then Return False

            If CRound(valObj._Amount, ROUNDAMOUNTINVOICEMADE) > 0 Then
                e.Description = My.Resources.Documents_Service_AmountInvalid
                e.Severity = Validation.RuleSeverity.Warning
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property AccountSales is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountSalesValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As Service = DirectCast(target, Service)

            If valObj._Type <> TradedItemType.Sales AndAlso valObj._Type <> TradedItemType.All Then Return True

            Return AccountFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property AccountVatSales is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountVatSalesValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As Service = DirectCast(target, Service)

            If valObj._Type <> TradedItemType.Sales AndAlso valObj._Type <> TradedItemType.All Then Return True

            If Not CRound(valObj._RateVatSales) > 0 Then Return True

            Return AccountFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property DeclarationSchemaPurchase is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DeclarationSchemaPurchaseValidation(ByVal target As Object, _
            ByVal e As VatDeclarationSchemaFieldRuleArgs) As Boolean

            Dim valObj As Service = DirectCast(target, Service)

            If valObj._Type <> TradedItemType.Purchases AndAlso valObj._Type <> TradedItemType.All Then Return True

            Return VatDeclarationSchemaFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property AccountPurchase is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountPurchaseValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As Service = DirectCast(target, Service)

            If valObj._Type <> TradedItemType.Purchases AndAlso valObj._Type <> TradedItemType.All Then Return True

            Return AccountFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property AccountVatPurchase is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountVatPurchaseValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As Service = DirectCast(target, Service)

            If valObj._Type <> TradedItemType.Purchases AndAlso valObj._Type <> TradedItemType.All Then Return True

            If Not CRound(valObj._RateVatPurchase) > 0 Then Return True

            Return AccountFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property DeclarationSchemaSales is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DeclarationSchemaSalesValidation(ByVal target As Object, _
            ByVal e As VatDeclarationSchemaFieldRuleArgs) As Boolean

            Dim valObj As Service = DirectCast(target, Service)

            If valObj._Type <> TradedItemType.Sales AndAlso valObj._Type <> TradedItemType.All Then Return True

            Return VatDeclarationSchemaFieldValidation(target, e)

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Documents.Service2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.Service1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.Service2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.Service3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.Service3")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new Service instance.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function NewService() As Service

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            Dim result As New Service
            result._RegionalContents = RegionalContentList.NewRegionalContentList
            result._RegionalPrices = RegionalPriceList.NewRegionalPriceList
            result.ValidationRules.CheckRules()
            Return result

        End Function

        ''' <summary>
        ''' Gets an existing Service instance from a database.
        ''' </summary>
        ''' <param name="nID">An ID of the Service to get.</param>
        ''' <remarks></remarks>
        Public Shared Function GetService(ByVal nID As Integer) As Service
            Return DataPortal.Fetch(Of Service)(New Criteria(nID))
        End Function

        ''' <summary>
        ''' Deletes an existing Service instance from a database.
        ''' </summary>
        ''' <param name="id">An ID of the Service to delete.</param>
        ''' <remarks></remarks>
        Public Shared Sub DeleteService(ByVal id As Integer)

            DataPortal.Delete(New Criteria(id))
            HelperLists.ServiceInfoList.InvalidateCache()

        End Sub


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _ID As Integer
            Public ReadOnly Property ID() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public Sub New(ByVal nID As Integer)
                _ID = nID
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As New SQLCommand("FetchService")
            myComm.AddParam("?CD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                    My.Resources.Common_ObjectNotFound, My.Resources.Documents_Service_TypeName, _
                    criteria.ID.ToString()))

                Dim dr As DataRow = myData.Rows(0)

                _ID = CIntSafe(dr.Item(0), 0)
                _Type = ConvertDatabaseID(Of TradedItemType)(CIntSafe(dr.Item(1), 0))
                _TypeHumanReadable = Utilities.ConvertLocalizedName(_Type)
                _NameShort = CStrSafe(dr.Item(2)).Trim
                _Amount = CDblSafe(dr.Item(3), ROUNDAMOUNTINVOICEMADE, 0)
                _RateVatSales = CDblSafe(dr.Item(4), 2, 0)
                _RateVatPurchase = CDblSafe(dr.Item(5), 2, 0)
                _IsObsolete = ConvertDbBoolean(CIntSafe(dr.Item(6), 0))
                _AccountSales = CLongSafe(dr.Item(7), 0)
                _AccountVatSales = CLongSafe(dr.Item(8), 0)
                _AccountPurchase = CLongSafe(dr.Item(9), 0)
                _AccountVatPurchase = CLongSafe(dr.Item(10), 0)
                _ServiceCode = CStrSafe(dr.Item(11)).Trim
                _InsertDate = CTimeStampSafe(dr.Item(12))
                _UpdateDate = CTimeStampSafe(dr.Item(13))
                _IsInUse = ConvertDbBoolean(CIntSafe(dr.Item(14), 0))
                _DeclarationSchemaSales = VatDeclarationSchemaInfo.GetVatDeclarationSchemaInfo(dr, 15)
                _DeclarationSchemaPurchase = VatDeclarationSchemaInfo.GetVatDeclarationSchemaInfo(dr, 24)

                _RegionalContents = RegionalContentList.GetRegionalContentList(Me)
                _RegionalPrices = RegionalPriceList.GetRegionalPriceList(Me)

            End Using

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Dim myComm As New SQLCommand("InsertService")
            AddWithParams(myComm)

            Using transaction As New SqlTransaction

                Try

                    myComm.Execute()

                    _ID = Convert.ToInt32(myComm.LastInsertID)

                    RegionalContents.Update(Me)
                    RegionalPrices.Update(Me)

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            CheckIfUpdateDateChanged()

            Dim myComm As New SQLCommand("UpdateService")
            AddWithParams(myComm)
            myComm.AddParam("?CD", _ID)

            Using transaction As New SqlTransaction

                Try

                    myComm.Execute()

                    RegionalContents.Update(Me)
                    RegionalPrices.Update(Me)

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            CheckIfWasUsed(DirectCast(criteria, Criteria).ID)

            Dim myComm As New SQLCommand("DeleteService")
            myComm.AddParam("?CD", DirectCast(criteria, Criteria).ID)

            Using transaction As New SqlTransaction

                Try

                    myComm.Execute()

                    RegionalContentList.Delete(DirectCast(criteria, Criteria).ID, MYREGIONALIZEDOBJECTTYPE)
                    RegionalPriceList.Delete(DirectCast(criteria, Criteria).ID, MYREGIONALIZEDOBJECTTYPE)

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkNew()

        End Sub


        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AA", Utilities.ConvertDatabaseID(_Type))
            myComm.AddParam("?AB", _NameShort.Trim)
            myComm.AddParam("?AC", CRound(_Amount, ROUNDAMOUNTINVOICEMADE))
            myComm.AddParam("?AD", CRound(_RateVatSales))
            myComm.AddParam("?AE", CRound(_RateVatPurchase))
            myComm.AddParam("?AF", ConvertDbBoolean(_IsObsolete))
            myComm.AddParam("?AG", _AccountSales)
            myComm.AddParam("?AH", _AccountVatSales)
            myComm.AddParam("?AI", _AccountPurchase)
            myComm.AddParam("?AJ", _AccountVatPurchase)
            myComm.AddParam("?AK", _ServiceCode.Trim)
            If _DeclarationSchemaSales = VatDeclarationSchemaInfo.Empty Then
                myComm.AddParam("?AL", 0)
            Else
                myComm.AddParam("?AL", _DeclarationSchemaSales.ID)
            End If
            If _DeclarationSchemaPurchase = VatDeclarationSchemaInfo.Empty Then
                myComm.AddParam("?AM", 0)
            Else
                myComm.AddParam("?AM", _DeclarationSchemaPurchase.ID)
            End If

            _UpdateDate = GetCurrentTimeStamp()
            If Me.IsNew Then _InsertDate = _UpdateDate
            myComm.AddParam("?AN", _UpdateDate.ToUniversalTime)

        End Sub

        Private Sub CheckIfUpdateDateChanged()

            Dim myComm As New SQLCommand("CheckIfServiceUpdateDateChanged")
            myComm.AddParam("?CD", _ID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 OrElse CDateTimeSafe(myData.Rows(0).Item(0), _
                    Date.MinValue) = Date.MinValue Then

                    Throw New Exception(String.Format(My.Resources.Common_ObjectNotFound, _
                        My.Resources.Documents_Service_TypeName, _ID.ToString))

                End If

                If CTimeStampSafe(myData.Rows(0).Item(0)) <> _UpdateDate Then

                    Throw New Exception(My.Resources.Common_UpdateDateHasChanged)

                End If

            End Using

        End Sub

        Private Shared Sub CheckIfWasUsed(ByVal serviceID As Integer)

            Dim myComm As New SQLCommand("CheckIfServiceWasUsed")
            myComm.AddParam("?SD", serviceID)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 AndAlso CIntSafe(myData.Rows(0).Item(0), 0) > 0 Then _
                    Throw New Exception(My.Resources.Documents_Service_CannotDelete)
            End Using

        End Sub

#End Region

    End Class

End Namespace