﻿Imports ApskaitaObjects.Attributes

Namespace Documents

    ''' <summary>
    ''' Represents a price info for a particular regionalized object for a particular currency.
    ''' </summary>
    ''' <remarks>Should be only used as a child of <see cref="RegionalPriceList">RegionalPriceList</see>
    ''' Values are stored in the database table regionalprices.</remarks>
    <Serializable()> _
    Public NotInheritable Class RegionalPrice
        Inherits BusinessBase(Of RegionalPrice)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _CurrencyCode As String = ""
        Private _ValuePerUnitSales As Double = 0
        Private _ValuePerUnitPurchases As Double = 0


        ''' <summary>
        ''' Gets an ID of the item that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in the database field regionalprices.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the currency of the prices.
        ''' </summary>
        ''' <remarks>Value is stored in the database field regionalprices.CurrencyCode.</remarks>
        <CurrencyFieldAttribute(ValueRequiredLevel.Mandatory)> _
        Public Property CurrencyCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrencyCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _CurrencyCode.Trim <> value.Trim Then
                    _CurrencyCode = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets price for sale per unit.
        ''' </summary>
        ''' <remarks>Value is stored in the database field regionalprices.ValuePerUnitSales.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, ROUNDUNITINVOICEMADE)> _
        Public Property ValuePerUnitSales() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ValuePerUnitSales, ROUNDUNITINVOICEMADE)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_ValuePerUnitSales, ROUNDUNITINVOICEMADE) <> CRound(value, ROUNDUNITINVOICEMADE) Then
                    _ValuePerUnitSales = CRound(value, ROUNDUNITINVOICEMADE)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets price for purchase per unit.
        ''' </summary>
        ''' <remarks>Value is stored in the database field regionalprices.ValuePerUnitPurchases.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, ROUNDUNITINVOICERECEIVED)> _
        Public Property ValuePerUnitPurchases() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ValuePerUnitPurchases, ROUNDUNITINVOICERECEIVED)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_ValuePerUnitPurchases, ROUNDUNITINVOICERECEIVED) <> CRound(value, ROUNDUNITINVOICERECEIVED) Then
                    _ValuePerUnitPurchases = CRound(value, ROUNDUNITINVOICERECEIVED)
                    PropertyHasChanged()
                End If
            End Set
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


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Documents_RegionalPrice_ToString, _
                _CurrencyCode, DblParser(_ValuePerUnitSales), DblParser(_ValuePerUnitPurchases))
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.CurrencyFieldValidation, _
                New Validation.RuleArgs("CurrencyCode"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringValueUniqueInCollectionValidation, _
                New Validation.RuleArgs("CurrencyCode"))

            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Validation.RuleArgs("ValuePerUnitSales"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Validation.RuleArgs("ValuePerUnitPurchases"))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewRegionalPrice() As RegionalPrice
            Dim result As New RegionalPrice
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Friend Shared Function GetRegionalPrice(ByVal dr As DataRow) As RegionalPrice
            Return New RegionalPrice(dr)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As DataRow)
            MarkAsChild()
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow)

            _ID = CIntSafe(dr.Item(1), 0)
            _CurrencyCode = CStrSafe(dr.Item(2))
            _ValuePerUnitSales = CDblSafe(dr.Item(3), ROUNDUNITINVOICEMADE, 0)
            _ValuePerUnitPurchases = CDblSafe(dr.Item(4), ROUNDUNITINVOICERECEIVED, 0)

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Friend Sub Insert(ByVal parent As IRegionalDataObject)

            Dim myComm As New SQLCommand("InsertRegionalPrice")
            AddWithParams(myComm)
            myComm.AddParam("?AA", parent.RegionalObjectID)
            myComm.AddParam("?AB", Utilities.ConvertDatabaseID(parent.RegionalObjectType))

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As IRegionalDataObject)

            Dim myComm As New SQLCommand("UpdateRegionalPrice")
            myComm.AddParam("?CD", _ID)
            AddWithParams(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteRegionalPrice")
            myComm.AddParam("?CD", _ID)

            myComm.Execute()

            MarkNew()

        End Sub


        Private Sub AddWithParams(ByRef myComm As SQLCommand)
            myComm.AddParam("?AC", _CurrencyCode.Trim)
            myComm.AddParam("?AD", CRound(_ValuePerUnitSales, ROUNDUNITINVOICEMADE))
            myComm.AddParam("?AE", CRound(_ValuePerUnitPurchases, ROUNDUNITINVOICERECEIVED))
        End Sub

#End Region

    End Class

End Namespace