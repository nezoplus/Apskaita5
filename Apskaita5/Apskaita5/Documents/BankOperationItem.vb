Imports ApskaitaObjects.HelperLists
Namespace Documents

    <Serializable()> _
    Public Class BankOperationItem
        Inherits BusinessBase(Of BankOperationItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _Date As Date = Today
        Private _DocumentNumber As String = ""
        Private _PersonCode As String = ""
        Private _PersonName As String = ""
        Private _PersonBankAccount As String = ""
        Private _PersonBankName As String = ""
        Private _Content As String = ""
        Private _Inflow As Boolean = True
        Private _Currency As String = GetCurrentCompany.BaseCurrency
        Private _CurrencyRate As Double = 1
        Private _CurrencyRateInAccount As Double = 1
        Private _OriginalSum As Double = 0
        Private _SumLTLBank As Double = 0
        Private _SumLTL As Double = 0
        Private _SumInAccountBank As Double = 0
        Private _SumInAccount As Double = 0
        Private _UniqueCode As String = ""
        Private _IsBankCosts As Boolean = False
        Private _Person As PersonInfo = Nothing
        Private _AccountCorresponding As Long = 0
        Private _ExistsInDatabase As Boolean = False
        Private _ProbablyExistsInDatabase As Boolean = False
        Private _OperationDatabaseID As Integer = 0
        Private _AccountBankCurrencyConversionCosts As Long = 0
        Private _BankCurrencyConversionCosts As Double = 0


        Public Property IsBankCosts() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsBankCosts
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _Inflow AndAlso value Then
                    PropertyHasChanged()
                    Exit Property
                End If
                CanWriteProperty(True)
                If _IsBankCosts <> value Then
                    _IsBankCosts = value
                    PropertyHasChanged()
                    SetAccountCorresponding(Nothing, True)
                End If
            End Set
        End Property

        Public Property Person() As PersonInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Person
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As PersonInfo)
                CanWriteProperty(True)
                If Not (_Person Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Person Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _Person = value) Then
                    _Person = value
                    PropertyHasChanged()
                    If Not _IsBankCosts Then SetAccountCorresponding(Nothing, True)
                End If
            End Set
        End Property

        Public Property CurrencyRate() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRate, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)

                CanWriteProperty(True)

                If _Currency Is Nothing OrElse String.IsNullOrEmpty(_Currency.Trim) OrElse _
                    _Currency.Trim.ToUpper = GetCurrentCompany.BaseCurrency Then value = 1

                If CRound(_CurrencyRate, 6) <> CRound(value, 6) Then

                    _CurrencyRate = CRound(value, 6)
                    PropertyHasChanged()

                    RecalculateSumLTL("", True)

                End If

            End Set
        End Property

        Public Property CurrencyRateInAccount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRateInAccount, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)

                CanWriteProperty(True)

                If Not Parent Is Nothing AndAlso TypeOf Parent Is BankOperationItemList AndAlso _
                    Not DirectCast(Parent, BankOperationItemList).Account Is Nothing AndAlso _
                    DirectCast(Parent, BankOperationItemList).Account.ID > 0 AndAlso _
                    (DirectCast(Parent, BankOperationItemList).Account.CurrencyCode Is Nothing _
                    OrElse String.IsNullOrEmpty(DirectCast(Parent, BankOperationItemList). _
                    Account.CurrencyCode.Trim) OrElse _
                    DirectCast(Parent, BankOperationItemList).Account.CurrencyCode.Trim.ToUpper _
                    = GetCurrentCompany.BaseCurrency) Then value = 1

                If CRound(_CurrencyRateInAccount, 6) <> CRound(value, 6) Then

                    _CurrencyRateInAccount = CRound(value, 6)
                    PropertyHasChanged()

                    RecalculateSumInAccount("", True)

                End If

            End Set
        End Property

        Public Property AccountCorresponding() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountCorresponding
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _AccountCorresponding <> value Then
                    _AccountCorresponding = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property AccountBankCurrencyConversionCosts() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountBankCurrencyConversionCosts
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _AccountBankCurrencyConversionCosts <> value Then
                    If GetCurrency() <> GetCurrencyInAccount("") Then _
                        _AccountBankCurrencyConversionCosts = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property BankCurrencyConversionCosts() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BankCurrencyConversionCosts)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_BankCurrencyConversionCosts) <> CRound(value) Then
                    _BankCurrencyConversionCosts = CRound(value)
                    PropertyHasChanged()
                    RecalculateSumInAccount("", True)
                End If
            End Set
        End Property

        Public Property DocumentNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentNumber.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _DocumentNumber.Trim <> value.Trim Then
                    _DocumentNumber = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property


        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        Public ReadOnly Property PersonCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonCode.Trim
            End Get
        End Property

        Public ReadOnly Property PersonName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonName.Trim
            End Get
        End Property

        Public ReadOnly Property PersonBankAccount() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonBankAccount.Trim
            End Get
        End Property

        Public ReadOnly Property PersonBankName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonBankName.Trim
            End Get
        End Property

        Public ReadOnly Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
        End Property

        Public ReadOnly Property Inflow() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Inflow
            End Get
        End Property

        Public ReadOnly Property Payout() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _Inflow
            End Get
        End Property

        Public ReadOnly Property Currency() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Currency.Trim
            End Get
        End Property

        Public ReadOnly Property OriginalSum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OriginalSum)
            End Get
        End Property

        Public ReadOnly Property SumLTLBank() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumLTLBank)
            End Get
        End Property

        Public ReadOnly Property SumLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumLTL)
            End Get
        End Property

        Public ReadOnly Property SumInAccountBank() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumInAccountBank)
            End Get
        End Property

        Public ReadOnly Property SumInAccount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumInAccount)
            End Get
        End Property

        Public Property UniqueCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UniqueCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Friend Set(ByVal value As String)
                _UniqueCode = value.Trim
            End Set
        End Property

        Public Property ExistsInDatabase() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ExistsInDatabase
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Friend Set(ByVal value As Boolean)
                _ExistsInDatabase = value
            End Set
        End Property

        Public Property ProbablyExistsInDatabase() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ProbablyExistsInDatabase
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Friend Set(ByVal value As Boolean)
                _ProbablyExistsInDatabase = value
            End Set
        End Property

        Public ReadOnly Property OperationDatabaseID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationDatabaseID
            End Get
        End Property


        Private Sub SetAccountCorresponding(ByVal nAccount As CashAccountInfo, _
            ByVal RaisePropertyHasChanged As Boolean)
            If _IsBankCosts Then
                If Not nAccount Is Nothing Then
                    _AccountCorresponding = nAccount.BankFeeCostsAccount
                ElseIf Not Parent Is Nothing AndAlso TypeOf Parent Is BankOperationItemList Then
                    _AccountCorresponding = DirectCast(Parent, BankOperationItemList).Account.BankFeeCostsAccount
                Else
                    _AccountCorresponding = 0
                End If
            Else
                If Not _Person Is Nothing AndAlso _Person.ID > 0 Then
                    If _Inflow Then
                        _AccountCorresponding = _Person.AccountAgainstBankBuyer
                    Else
                        _AccountCorresponding = _Person.AccountAgainstBankSupplyer
                    End If
                Else
                    _AccountCorresponding = 0
                End If
            End If

            If RaisePropertyHasChanged Then PropertyHasChanged("AccountCorresponding")

        End Sub

        Private Sub RecalculateSumLTL(ByVal nCurrencyCodeInAccount As String, _
            ByVal RaisePropertyChangedEvents As Boolean)

            Dim nCurrencyInAccount As String = GetCurrencyInAccount(nCurrencyCodeInAccount)
            Dim nCurrency As String = GetCurrency()

            If nCurrency = GetCurrentCompany.BaseCurrency Then
                _SumLTL = _OriginalSum
            Else
                _SumLTL = CRound(_OriginalSum * _CurrencyRate)
            End If

            If nCurrencyInAccount = GetCurrentCompany.BaseCurrency Then _SumInAccount = _SumLTL

            If RaisePropertyChangedEvents Then
                PropertyHasChanged("SumLTL")
                If nCurrencyInAccount = GetCurrentCompany.BaseCurrency Then _
                    PropertyHasChanged("SumInAccount")
            End If

        End Sub

        Private Sub RecalculateSumInAccount(ByVal nCurrencyCodeInAccount As String, _
            ByVal RaisePropertyChangedEvents As Boolean)

            Dim nCurrencyInAccount As String = GetCurrencyInAccount(nCurrencyCodeInAccount)
            Dim nCurrency As String = GetCurrency()

            If nCurrency = nCurrencyInAccount Then
                _SumInAccount = _OriginalSum
            ElseIf nCurrencyInAccount = GetCurrentCompany.BaseCurrency Then
                _SumInAccount = CRound(_OriginalSum * _CurrencyRate)
            Else
                If CRound(_CurrencyRateInAccount, 6) > 0 Then
                    _SumInAccount = CRound(CRound(_OriginalSum * _CurrencyRate) _
                        / _CurrencyRateInAccount)
                Else
                    _SumInAccount = 0
                End If
            End If

            If _SumInAccount > 0 Then
                If CRound(_CurrencyRateInAccount, 6) > 0 Then
                    If _Inflow Then
                        _SumInAccount = CRound(_SumInAccount - CRound(_BankCurrencyConversionCosts / _CurrencyRateInAccount))
                    Else
                        _SumInAccount = CRound(_SumInAccount + CRound(_BankCurrencyConversionCosts / _CurrencyRateInAccount))
                    End If
                Else
                    If _Inflow Then
                        _SumInAccount = CRound(_SumInAccount - _BankCurrencyConversionCosts)
                    Else
                        _SumInAccount = CRound(_SumInAccount + _BankCurrencyConversionCosts)
                    End If
                End If
            End If

            If RaisePropertyChangedEvents Then PropertyHasChanged("SumInAccount")

        End Sub

        Private Function GetCurrencyInAccount(ByVal nCurrencyInAccount As String) As String

            If nCurrencyInAccount Is Nothing OrElse String.IsNullOrEmpty(nCurrencyInAccount.Trim) Then

                If Parent Is Nothing OrElse Not TypeOf Parent Is BankOperationItemList OrElse _
                    DirectCast(Parent, BankOperationItemList).Account Is Nothing OrElse _
                    Not DirectCast(Parent, BankOperationItemList).Account.ID > 0 OrElse _
                    DirectCast(Parent, BankOperationItemList).Account.CurrencyCode Is Nothing _
                    OrElse String.IsNullOrEmpty(DirectCast(Parent, BankOperationItemList). _
                    Account.CurrencyCode.Trim) Then

                    Return GetCurrentCompany.BaseCurrency

                Else

                    Return DirectCast(Parent, BankOperationItemList).Account.CurrencyCode.Trim.ToUpper

                End If

            Else

                Return nCurrencyInAccount.Trim.ToUpper

            End If

        End Function

        Private Function GetCurrency() As String

            If _Currency Is Nothing OrElse String.IsNullOrEmpty(_Currency.Trim) Then

                Return GetCurrentCompany.BaseCurrency

            Else

                Return _Currency.Trim.ToUpper

            End If

        End Function

        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            Dim result As String = ""
            If Not MyBase.IsValid Then result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
            Return result
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString

            Dim result As String = ""
            If MyBase.BrokenRulesCollection.WarningCount > 0 Then _
                result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
            Return result

        End Function

        Friend Sub MarkAsExistingInDatabase(ByVal nBankOperationItem As BankOperationItem, _
            ByVal NewDatabaseID As Integer)
            If nBankOperationItem.Equals(Me) Then
                _ExistsInDatabase = True
                _ProbablyExistsInDatabase = True
                _OperationDatabaseID = NewDatabaseID
            End If
        End Sub

        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            If TypeOf obj Is BankOperation AndAlso DirectCast(obj, BankOperation).ID _
                = _OperationDatabaseID Then
                Return True
            ElseIf TypeOf obj Is BankOperationItem AndAlso DirectCast(obj, BankOperationItem)._Guid _
                = _Guid Then
                Return True
            ElseIf TypeOf obj Is BankOperationItem AndAlso _
                DirectCast(obj, BankOperationItem)._OperationDatabaseID > 0 _
                AndAlso _OperationDatabaseID > 0 AndAlso _
                DirectCast(obj, BankOperationItem)._OperationDatabaseID = _OperationDatabaseID Then
                Return True
            End If
            Return False
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("DocumentNumber", "dokumento (pavedimo) numeris"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("OriginalSum", "operacijos suma"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("AccountCorresponding", "koresponduojanti sąskaita"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("CurrencyRate", "operacijos valiutos kursas"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("CurrencyRateInAccount", "sąskaitos valiutos kursas"))

            ValidationRules.AddRule(AddressOf ProbabilityOfBankCostsValidation, New Validation.RuleArgs("Sum"))
            ValidationRules.AddRule(AddressOf ClientValidation, New Validation.RuleArgs("Person"))
            ValidationRules.AddRule(AddressOf DateValidation, New Validation.RuleArgs("Date"))
            ValidationRules.AddRule(AddressOf SumInAccountValidation, New Validation.RuleArgs("SumInAccount"))
            ValidationRules.AddRule(AddressOf BankCurrencyConversionCostsValidation, _
                New Validation.RuleArgs("BankCurrencyConversionCosts"))
            ValidationRules.AddRule(AddressOf AccountBankCurrencyConversionCostsValidation, _
                New Validation.RuleArgs("AccountBankCurrencyConversionCosts"))

            ValidationRules.AddDependantProperty("BankCurrencyConversionCosts", _
                "AccountBankCurrencyConversionCosts", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property Sum is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function ProbabilityOfBankCostsValidation(ByVal target As Object, _
        ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As BankOperationItem = DirectCast(target, BankOperationItem)
            If ValObj.Parent Is Nothing OrElse Not TypeOf ValObj.Parent Is BankOperationItemList _
                OrElse Not DirectCast(ValObj.Parent, BankOperationItemList).Account.BankFeeLimit > 0 Then _
                Return True

            If CRound(ValObj._SumInAccountBank) <= DirectCast(ValObj.Parent, _
                BankOperationItemList).Account.BankFeeLimit AndAlso Not ValObj.IsBankCosts Then
                e.Description = "Eilutė '" & ValObj._Date.ToShortDateString & " Nr. " _
                    & ValObj._DocumentNumber & ", unikalus Nr. " & ValObj._UniqueCode _
                    & "' nėra priskirta prie banko sąnaudų, nors sprendžiant pagal mažą sumą " _
                    & "tai banko mokesčiai."
                e.Severity = Validation.RuleSeverity.Warning
                Return False
            End If

            If CRound(ValObj._SumInAccountBank) > DirectCast(ValObj.Parent, _
                BankOperationItemList).Account.BankFeeLimit AndAlso ValObj.IsBankCosts Then
                e.Description = "Eilutė '" & ValObj._Date.ToShortDateString & " Nr. " _
                    & ValObj._DocumentNumber & ", unikalus Nr. " & ValObj._UniqueCode _
                    & "' yra priskirta prie banko sąnaudų, nors sprendžiant pagal sąlyginai " _
                    & "didelę sumą tai ne banko mokesčiai."
                e.Severity = Validation.RuleSeverity.Warning
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the client is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function ClientValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As BankOperationItem = DirectCast(target, BankOperationItem)

            If Not ValObj._Person Is Nothing AndAlso ValObj._Person.ID > 0 Then
                If ValObj._Inflow AndAlso Not ValObj._Person.IsClient Then
                    e.Description = "Pasirinktas asmuo " & ValObj._Person.Name _
                        & " nėra klientas, o pajamos gaunamos iš klientų (" _
                        & ValObj._Date.ToShortDateString & " Nr. " & ValObj._DocumentNumber _
                        & ", unikalus Nr. " & ValObj._UniqueCode & ")."
                    e.Severity = Validation.RuleSeverity.Warning
                    Return False
                ElseIf Not ValObj._Inflow AndAlso Not ValObj._Person.IsSupplier Then
                    e.Description = "Pasirinktas asmuo " & ValObj._Person.Name _
                        & " nėra tiekėjas, o mokėjimai atliekami tiekėjams (" _
                        & ValObj._Date.ToShortDateString & " Nr. " & ValObj._DocumentNumber _
                        & ", unikalus Nr. " & ValObj._UniqueCode & ")."
                    e.Severity = Validation.RuleSeverity.Warning
                    Return False
                End If
            End If

            Return True
        End Function

        ''' <summary>
        ''' Rule ensuring that the date if later then last closing date.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DateValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As BankOperationItem = DirectCast(target, BankOperationItem)

            If ValObj._Date.Date <= GetCurrentCompany.LastClosingDate.Date.Date Then
                e.Description = "Nurodyta dokumento data yra ankstesnė (ar lygi) už paskutinio 5/6 klasių " & _
                    "uždarymo datą arba likučių perkėlimo datą (" & ValObj._Date.ToShortDateString _
                    & " Nr. " & ValObj._DocumentNumber & ", unikalus Nr. " & ValObj._UniqueCode & ")."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True
        End Function

        ''' <summary>
        ''' Rule ensuring that SumInAccount (calculated) is equal SumInAccountBank.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumInAccountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As BankOperationItem = DirectCast(target, BankOperationItem)

            If CRound(ValObj._SumInAccount) <> CRound(ValObj._SumInAccountBank) Then
                e.Description = "Nesutampa banko nurodyta ir pagal oficialų kursą " _
                    & "apskaičiuota operacijos suma sąskaitoje. Tikėtina, kad nesutapimas " _
                    & "nulemtas valiutos konvertavimo banko kursu, nesutampančiu su oficialiu kursu (" _
                    & ValObj._Date.ToShortDateString & " Nr. " & ValObj._DocumentNumber _
                    & ", unikalus Nr. " & ValObj._UniqueCode & ")."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that BankCurrencyConversionCosts is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function BankCurrencyConversionCostsValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As BankOperationItem = DirectCast(target, BankOperationItem)

            If CRound(ValObj._BankCurrencyConversionCosts) > 0 AndAlso _
                ValObj.GetCurrency = ValObj.GetCurrencyInAccount("") Then
                e.Description = "Valiutos konvertavimo banko kursu, nesutampančiu " _
                    & "su oficialiu kursu, nuostoliai gali atsirasti tik kai skiriasi " _
                    & "operacijos valiuta ir sąskaitos valiuta (" _
                    & ValObj._Date.ToShortDateString & " Nr. " & ValObj._DocumentNumber _
                    & ", unikalus Nr. " & ValObj._UniqueCode & ")."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that AccountBankCurrencyConversionCosts is set when needed.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountBankCurrencyConversionCostsValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As BankOperationItem = DirectCast(target, BankOperationItem)

            If CRound(ValObj._BankCurrencyConversionCosts) > 0 AndAlso _
                Not ValObj._AccountBankCurrencyConversionCosts > 0 Then
                e.Description = "Nenurodyta apskaitos sąskaita nuostoliams dėl " _
                    & "valiutos konvertavimo banko kursu, nesutampančiu su oficialiu kursu (" _
                    & ValObj._Date.ToShortDateString & " Nr. " & ValObj._DocumentNumber _
                    & ", unikalus Nr. " & ValObj._UniqueCode & ")."
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

        Friend Shared Function GetBankOperationItem(ByVal OperationString As String, _
            ByVal nAccount As CashAccountInfo, ByVal ImportSource As BankOperationImportSourceType, _
            ByVal BankDocumentPrefix As String) As BankOperationItem
            Return New BankOperationItem(OperationString, nAccount, ImportSource, BankDocumentPrefix)
        End Function

        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal OperationString As String, ByVal nAccount As CashAccountInfo, _
            ByVal ImportSource As BankOperationImportSourceType, ByVal BankDocumentPrefix As String)
            MarkAsChild()
            Select Case ImportSource
                Case BankOperationImportSourceType.LITAS_ESIS
                    FetchFromLitasEsis(OperationString, nAccount, BankDocumentPrefix)
                Case BankOperationImportSourceType.PasteString
                    FetchFromPasteString(OperationString, nAccount, BankDocumentPrefix)
                Case Else
                    Throw New NotImplementedException("Klaida. Importo šaltinio tipas '" _
                        & ImportSource.ToString & "' neimplementuotas.")
            End Select
        End Sub

#End Region

#Region " Data Access "

        Private Sub FetchFromPasteString(ByVal s As String, ByVal nAccount As CashAccountInfo, _
            ByVal BankDocumentPrefix As String)

            Dim ValueArray As String() = s.Split(New Char() {ControlChars.Tab}, StringSplitOptions.None)

            Try
                _Date = Convert.ToDateTime(ValueArray(0).Trim)
                _DocumentNumber = ((BankDocumentPrefix & " " & ValueArray(1)).Trim).Trim
                _PersonCode = ValueArray(2).Trim
                _PersonName = ValueArray(3).Trim
                _Content = ValueArray(4).Trim
                _Inflow = (String.IsNullOrEmpty(ValueArray(5).Trim))
                _Currency = ValueArray(6).Trim.ToUpper
                If String.IsNullOrEmpty(_Currency.Trim) OrElse _
                    Array.IndexOf(CurrencyCodes, _Currency.Trim) < 0 Then _
                    _Currency = GetCurrentCompany.BaseCurrency
                _OriginalSum = CDblSafe(ValueArray(7).Trim, 2, 0)
                _SumLTLBank = CDblSafe(ValueArray(8).Trim, 2, 0)
                _SumInAccountBank = CDblSafe(ValueArray(9).Trim, 2, 0)
                If Not CRound(_OriginalSum) > 0 Then _OriginalSum = _SumInAccountBank
                _UniqueCode = ValueArray(10).Trim
                _PersonBankAccount = ValueArray(11).Trim
                _PersonBankName = ValueArray(12).Trim

            Catch ex As Exception
                Throw New Exception("Klaida atpažįstant banko operacijos duomenis. Eilutė: '" _
                    & s & "'." & vbCrLf & " Stulpeliai turi būti išdėstyti tokia seka: " _
                    & "[data], [dokumento numeris], [asmens kodas], [asmens pavadinimas], " _
                    & "[turinys/aprašas], [pajamos("""")/išlaidos(""x"")], [valiuta], " _
                    & "[originali suma], [suma LTL], [unikalus kodas], " _
                    & "[asmens (banko) sąskaitos numeris], [asmens banko pavadinimas].", ex)
            End Try

            If String.IsNullOrEmpty(_Content.Trim) Then _Content = "Nenurodyta"

            If _Currency.Trim.ToUpper = GetCurrentCompany.BaseCurrency Then
                _CurrencyRate = 1
            Else
                _CurrencyRate = 0
            End If
            If nAccount.CurrencyCode.Trim.ToUpper = GetCurrentCompany.BaseCurrency Then
                _CurrencyRateInAccount = 1
            Else
                _CurrencyRateInAccount = 0
            End If

            RecalculateSumLTL(nAccount.CurrencyCode, True)
            RecalculateSumInAccount(nAccount.CurrencyCode, True)

        End Sub

        Private Sub FetchFromLitasEsis(ByVal s As String, ByVal nAccount As CashAccountInfo, _
            ByVal BankDocumentPrefix As String)

            Dim tm As String = GetElement(s, 2).Trim
            _Date = New Date(CIntSafe(tm.Substring(0, 4)), CIntSafe(tm.Substring(4, 2)), _
                CIntSafe(tm.Substring(6, 2)))
            _DocumentNumber = (BankDocumentPrefix & " " & GetElement(s, 9)).Trim
            _PersonCode = GetElement(s, 18).Trim
            _PersonName = GetElement(s, 17).Trim
            _PersonBankAccount = GetElement(s, 16).Trim
            _PersonBankName = GetElement(s, 15).Trim
            Dim TrCd As String = GetElement(s, 12).Trim
            If String.IsNullOrEmpty(TrCd.Trim) Then
                _Content = GetElement(s, 13)
            Else
                _Content = GetElement(s, 13) & "; įmokos kodas " & TrCd
            End If
            _Inflow = (GetElement(s, 6).Trim.ToUpper = "C")
            _Currency = GetElement(s, 8).Trim.ToUpper
            If String.IsNullOrEmpty(_Currency.Trim) OrElse _
                Array.IndexOf(CurrencyCodes, _Currency.Trim) < 0 Then _
                _Currency = GetCurrentCompany.BaseCurrency
            _OriginalSum = CDblSafe(GetElement(s, 7).Trim, 2, 0) / 100
            _SumLTLBank = CDblSafe(GetElement(s, 5).Trim, 2, 0) / 100
            _SumInAccountBank = CDblSafe(GetElement(s, 4).Trim, 2, 0) / 100
            If Not CRound(_OriginalSum) > 0 Then _OriginalSum = _SumInAccountBank
            _UniqueCode = GetElement(s, 10).Trim

            If String.IsNullOrEmpty(_Content.Trim) Then _Content = "Nenurodyta"

            If _Currency.Trim.ToUpper = GetCurrentCompany.BaseCurrency Then
                _CurrencyRate = 1
            Else
                _CurrencyRate = 0
            End If
            If nAccount.CurrencyCode.Trim.ToUpper = GetCurrentCompany.BaseCurrency Then
                _CurrencyRateInAccount = 1
            Else
                _CurrencyRateInAccount = 0
            End If

            RecalculateSumLTL(nAccount.CurrencyCode, True)
            RecalculateSumInAccount(nAccount.CurrencyCode, True)

        End Sub

        Friend Sub CheckIfUniqueCodeIsEnforcable(ByVal nAccount As CashAccountInfo)

            If Not nAccount.EnforceUniqueOperationID Then Exit Sub

            If Parent Is Nothing OrElse Not TypeOf Parent Is BankOperationItemList Then _
                Throw New Exception("Klaida. Metodas RecognizeItem gali būti invoke'inamas " _
                    & "tik po to, kai visi duomenys jau yra map'inti sąraše.")

            If String.IsNullOrEmpty(Me._UniqueCode.Trim) Then Throw New Exception( _
                "Klaida. Duomenyse ne visur nurodyti unikalūs operacijų kodai, " _
                & "o pasirinktoje sąskaitoje reikalaujama garantuoti kodų unikalumą.")

            ' some banks use the same unique code for the operation and the related bank fee
            ' these duplicate entries could be fixed, thus exception is thrown 
            ' only if more than two entries have the same unique code
            Dim SameUniqueCodeCount As Integer = 0
            For Each i As BankOperationItem In DirectCast(Parent, BankOperationItemList)
                If i._Guid <> Me._Guid AndAlso i._UniqueCode.Trim.ToUpper = Me._UniqueCode.Trim.ToUpper Then _
                    SameUniqueCodeCount += 1
            Next
            If SameUniqueCodeCount > 1 Then Throw New Exception("Klaida. Importuojamuose " _
                & "duomenyse nurodomi unikalūs operacijos kodai nėra unikalūs " _
                & "(pasikartoja), o sąskaitai yra nustatytas reikalavimas garantuoti " _
                & "unikalaus kodo unikalumą.")

        End Sub

        Friend Sub CheckIfUniqueCodeIsUnique(ByVal nAccount As CashAccountInfo)

            If Not nAccount.EnforceUniqueOperationID Then Exit Sub

            Dim myComm As New SQLCommand("CheckIfBankOperationUniqueCodeIsUnique")
            myComm.AddParam("?OD", 0)
            myComm.AddParam("?UC", _UniqueCode.Trim)
            myComm.AddParam("?AD", nAccount.ID)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 AndAlso CIntSafe(myData.Rows(0).Item(0), 0) > 0 Then _
                    Throw New Exception("Klaida. Operacija su unikaliu kodu '" _
                        & _UniqueCode.Trim & "' jau yra.")
            End Using

        End Sub

        Friend Sub RecognizeItem(ByVal nAccount As CashAccountInfo, ByVal BankPersonInfo As PersonInfo)

            If Parent Is Nothing OrElse Not TypeOf Parent Is BankOperationItemList Then _
                Throw New Exception("Klaida. Metodas RecognizeItem gali būti invoke'inamas " _
                    & "tik po to, kai visi duomenys jau yra map'inti sąraše.")

            If nAccount.EnforceUniqueOperationID Then
                ' some banks use the same unique code for the operation and the related bank fee
                ' these duplicate entries could be fixed
                For Each i As BankOperationItem In DirectCast(Parent, BankOperationItemList)
                    If i._Guid <> Me._Guid AndAlso i._UniqueCode.Trim.ToUpper = Me._UniqueCode.Trim.ToUpper Then
                        If CRound(i._SumInAccountBank) > CRound(Me._SumInAccountBank) Then
                            Me._UniqueCode = Me._UniqueCode.Trim & "1"
                        Else
                            i._UniqueCode = i._UniqueCode.Trim & "1"
                        End If
                    End If
                Next
            End If

            Dim myComm As SQLCommand
            If nAccount.EnforceUniqueOperationID Then
                myComm = New SQLCommand("RecognizeBankOperationItemByUniqueCode")
                myComm.AddParam("?UC", Me._UniqueCode.Trim)
            Else
                myComm = New SQLCommand("RecognizeBankOperationItemByBestGuess")
                myComm.AddParam("?DT", Me._Date.Date)
                myComm.AddParam("?BF", nAccount.BankFeeLimit)
                myComm.AddParam("?SM", CRound(Me._SumInAccountBank))
                myComm.AddParam("?OC", Me.PersonName.Trim & " (" & Me._PersonCode.Trim & ")")
            End If
            myComm.AddParam("?DC", Me._PersonBankAccount.Trim)
            myComm.AddParam("?CD", Me._PersonCode.Trim)
            myComm.AddParam("?AD", nAccount.ID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count > 0 Then

                    Dim dr As DataRow = myData.Rows(0)
                    If myData.Rows.Count > 1 AndAlso CIntSafe(myData.Rows(1).Item(0), 0) > 0 Then _
                        dr = myData.Rows(1)

                    _ProbablyExistsInDatabase = ConvertDbBoolean(CIntSafe(dr.Item(0), 0))
                    _AccountCorresponding = CLongSafe(dr.Item(1), 0)
                    _Person = PersonInfo.GetPersonInfo(dr, 2)

                    If nAccount.EnforceUniqueOperationID Then
                        _ExistsInDatabase = _ProbablyExistsInDatabase
                        _OperationDatabaseID = CIntSafe(myData.Rows(0).Item(0), 0)
                    End If

                End If

            End Using

            If Not _Inflow AndAlso CRound(_SumLTLBank) > 0 Then
                _IsBankCosts = (CRound(_SumLTLBank) <= nAccount.BankFeeLimit)
            ElseIf Not _Inflow AndAlso CRound(_SumInAccountBank) > 0 Then
                _IsBankCosts = (CRound(_SumInAccountBank) <= nAccount.BankFeeLimit)
            ElseIf Not _Inflow AndAlso CRound(_OriginalSum) > 0 Then
                _IsBankCosts = (CRound(_OriginalSum) <= nAccount.BankFeeLimit)
            End If
            If _IsBankCosts AndAlso Not BankPersonInfo Is Nothing _
                AndAlso BankPersonInfo.ID > 0 Then _Person = BankPersonInfo

            If Not _AccountCorresponding > 0 Then SetAccountCorresponding(nAccount, False)

            ValidationRules.CheckRules()

        End Sub

#End Region

    End Class

End Namespace