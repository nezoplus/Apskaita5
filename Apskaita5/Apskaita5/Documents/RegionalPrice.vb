Namespace Documents

    <Serializable()> _
    Public Class RegionalPrice
        Inherits BusinessBase(Of RegionalPrice)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _GUID As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _CurrencyCode As String = ""
        Private _ValuePerUnitSales As Double = 0
        Private _ValuePerUnitPurchases As Double = 0


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

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
            Return "Klaida (-os) eilutėje '" & _CurrencyCode & "': " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return "Eilutėje '" & _CurrencyCode & "' gali būti klaida: " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _GUID
        End Function

        Public Overrides Function ToString() As String
            If String.IsNullOrEmpty(_CurrencyCode.Trim) Then Return ""
            Return _CurrencyCode & " = " & _ValuePerUnitSales.ToString _
                & "/" & _ValuePerUnitPurchases.ToString
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.CurrencyFieldValidation, _
                New CommonValidation.SimpleRuleArgs("CurrencyCode", ""))
            ValidationRules.AddRule(AddressOf CommonValidation.StringValueUniqueInCollectionValidation, _
                New CommonValidation.SimpleRuleArgs("CurrencyCode", "valiuta"))
            ValidationRules.AddRule(AddressOf PriceValidation, New Validation.RuleArgs("ValuePerUnitSales"))

            ValidationRules.AddDependantProperty("ValuePerUnitPurchases", "ValuePerUnitSales", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that either sales of purchases price is entered.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function PriceValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As RegionalPrice = DirectCast(target, RegionalPrice)

            If Not CRound(ValObj._ValuePerUnitPurchases, ROUNDUNITINVOICERECEIVED) > 0 AndAlso _
                Not CRound(ValObj._ValuePerUnitSales, ROUNDUNITINVOICEMADE) > 0 Then
                e.Description = "Nenurodyta nei pirkimo, nei pardavimo kaina pasirinkta valiuta."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

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

        Friend Shared Function GetRegionalPrice(ByVal dr As String) As RegionalPrice
            Return New RegionalPrice(dr)
        End Function

        Friend Shared Function GetRegionalPrice(ByVal dr As DataRow) As RegionalPrice
            Return New RegionalPrice(dr)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As String)
            MarkAsChild()
            Fetch(dr)
        End Sub

        Private Sub New(ByVal dr As DataRow)
            MarkAsChild()
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As String)

            Dim DataArray As String() = dr.Split(New String() {"*-*-"}, StringSplitOptions.RemoveEmptyEntries)

            _ID = CIntSafe(DataArray(0).Trim, 0)
            _CurrencyCode = DataArray(1).Trim
            _ValuePerUnitSales = CRound(CLongSafe(DataArray(2).Trim, 0) / _
                Math.Pow(10, ROUNDUNITINVOICEMADE), ROUNDUNITINVOICEMADE)
            _ValuePerUnitPurchases = CRound(CLongSafe(DataArray(3).Trim, 0) / _
                Math.Pow(10, ROUNDUNITINVOICERECEIVED), ROUNDUNITINVOICERECEIVED)

            MarkOld()

        End Sub

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
            If TypeOf parent Is Service Then
                myComm.AddParam("?AA", DirectCast(parent, Service).ID)
                myComm.AddParam("?AB", 0)
            ElseIf TypeOf parent Is Goods.GoodsItem Then
                myComm.AddParam("?AA", DirectCast(parent, Goods.GoodsItem).ID)
                myComm.AddParam("?AB", 1)
            Else
                Dim o As Object = parent
                Throw New NotImplementedException("Klaida. Objekto tipo '" _
                    & o.GetType.FullName & "' regionalizavimas neimplementuotas.")
            End If

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