Namespace Goods

    <Serializable()> _
    Public Class ProductionComponentItem
        Inherits BusinessBase(Of ProductionComponentItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _Goods As GoodsInfo = Nothing
        Private _Amount As Double = 0
        Private _NormativeUnitCost As Double = 0


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public Property Goods() As GoodsInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Goods
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As GoodsInfo)
                CanWriteProperty(True)
                If Not (_Goods Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Goods Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _Goods.ID = value.ID) Then
                    _Goods = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Amount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Amount, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Amount, 6) <> CRound(value, 6) Then
                    _Amount = CRound(value, 6)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property NormativeUnitCost() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_NormativeUnitCost, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_NormativeUnitCost, 6) <> CRound(value, 6) Then
                    _NormativeUnitCost = CRound(value, 6)
                    PropertyHasChanged()
                End If
            End Set
        End Property



        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            If _Goods Is Nothing OrElse Not _Goods.ID > 0 Then
                Return "Klaida (-os) eilutėje: " & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
            Else
                Return "Klaida (-os) eilutėje '" & _Goods.Name & "': " _
                    & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
            End If
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            If _Goods Is Nothing OrElse Not _Goods.ID > 0 Then
                Return "Eilutėje gali būti klaidų: " & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
            Else
                Return "Eilutėje '" & _Goods.Name & "' gali būti klaidų: " _
                    & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
            End If
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            If _Goods Is Nothing OrElse Not _Goods.ID > 0 Then Return ""
            Return _Goods.Name
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.InfoObjectRequired, _
                New CommonValidation.InfoObjectRequiredRuleArgs("Goods", "komponentas (prekė)", "ID"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("Amount", "kiekis"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("NormativeUnitCost", _
                "normatyvinė vnt. kaina", Validation.RuleSeverity.Warning))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewProductionComponentItem() As ProductionComponentItem
            Dim result As New ProductionComponentItem
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Friend Shared Function GetProductionComponentItem(ByVal dr As DataRow) As ProductionComponentItem
            Return New ProductionComponentItem(dr)
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
            _Amount = CDblSafe(dr.Item(3), 6, 0)
            _NormativeUnitCost = CDblSafe(dr.Item(4), 6, 0)
            _Goods = GoodsInfo.GetGoodsInfo(dr, 5)

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Friend Sub Insert(ByVal parent As ProductionCalculation)

            Dim myComm As New SQLCommand("InsertProductionItem")
            AddWithParams(myComm)
            myComm.AddParam("?AA", parent.ID)
            myComm.AddParam("?AB", ConvertEnumDatabaseStringCode(ProductionComponentType.Component))

            myComm.Execute()

            _ID = myComm.LastInsertID

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As ProductionCalculation)

            Dim myComm As New SQLCommand("UpdateProductionItem")
            myComm.AddParam("?CD", _ID)
            AddWithParams(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteProductionItem")
            myComm.AddParam("?CD", _ID)

            myComm.Execute()

            MarkNew()

        End Sub

        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AC", _Goods.ID)
            myComm.AddParam("?AD", 0)
            myComm.AddParam("?AE", CRound(_Amount, 6))
            myComm.AddParam("?AF", CRound(_NormativeUnitCost, 6))

        End Sub

#End Region

    End Class

End Namespace
