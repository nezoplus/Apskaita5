Namespace General

    <Serializable()> _
    Public Class CompanyRate
        Inherits BusinessBase(Of CompanyRate)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _Type As RateType = RateType.Vat
        Private _TypeHumanReadable As String = ""
        Private _Value As Double = 0


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property [Type]() As RateType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
        End Property

        Public ReadOnly Property TypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TypeHumanReadable.Trim
            End Get
        End Property

        Public Property Value() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Value)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If value < 0 Then value = 0
                If CRound(_Value) <> CRound(value) Then
                    _Value = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property



        Public Function GetErrorString() As String _
        Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return "Klaida (-os) eilutėje '" & _TypeHumanReadable & "': " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
        End Function

        Public Function GetWarningString() As String _
        Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return "Eilutėje '" & _TypeHumanReadable & "' gali būti klaida: " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
        End Function

        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return _TypeHumanReadable & " = " & _Value.ToString("##,0.00")
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("Value", "tarifas", Validation.RuleSeverity.Warning))
        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewCompanyRate(ByVal NewType As RateType) As CompanyRate
            Dim result As New CompanyRate
            result._Type = NewType
            result._TypeHumanReadable = ConvertEnumHumanReadable(NewType)
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Friend Shared Function GetCompanyRate(ByVal dr As DataRow) As CompanyRate
            Return New CompanyRate(dr)
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

            _ID = CIntSafe(dr.Item(0), 0)
            _Type = ConvertEnumDatabaseCode(Of RateType)(CIntSafe(dr.Item(1), 0))
            _TypeHumanReadable = ConvertEnumHumanReadable(_Type)
            _Value = CDblSafe(dr.Item(2), 2, 0)

            ValidationRules.CheckRules()
            MarkOld()

        End Sub

        Friend Sub Insert(ByVal parent As CompanyRateList)

            Dim myComm As New SQLCommand("InsertCompanyRate")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(_Type))
            myComm.AddParam("?AB", CRound(_Value))

            myComm.Execute()

            _ID = myComm.LastInsertID

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As CompanyRateList)

            Dim myComm As New SQLCommand("UpdateCompanyRate")
            myComm.AddParam("?RD", _ID)
            myComm.AddParam("?AB", CRound(_Value))

            myComm.Execute()

            MarkOld()

        End Sub

#End Region

    End Class

End Namespace