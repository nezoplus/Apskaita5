Namespace Documents

    <Serializable()> _
    Public Class OffsetItem
        Inherits BusinessBase(Of OffsetItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _FinancialDataCanChange As Boolean = True
        Private _Type As BookEntryType = BookEntryType.Debetas
        Private _TypeHumanReadable As String = ConvertEnumHumanReadable(BookEntryType.Debetas)
        Private _Person As PersonInfo = Nothing
        Private _Account As Long = 0
        Private _Sum As Double = 0
        Private _CurrencyCode As String = GetCurrentCompany.BaseCurrency
        Private _CurrencyRate As Double = 1
        Private _SumLTL As Double = 0
        Private _CurrencyRateChangeImpact As Double = 0
        Private _AccountCurrencyRateChangeImpact As Long = 0
        Private _Comments As String = ""
        Private _Debit As Double = 0
        Private _Credit As Double = 0


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property FinancialDataCanChange() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        Public Property [Type]() As BookEntryType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As BookEntryType)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If _Type <> value Then
                    _Type = value
                    _TypeHumanReadable = ConvertEnumHumanReadable(_Type)
                    PropertyHasChanged()
                    PropertyHasChanged("TypeHumanReadable")
                    Recalculate(True)
                End If
            End Set
        End Property

        Public Property TypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TypeHumanReadable.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If value Is Nothing Then value = ""
                If _Type <> ConvertEnumHumanReadable(Of BookEntryType)(value.Trim) Then
                    _Type = ConvertEnumHumanReadable(Of BookEntryType)(value.Trim)
                    _TypeHumanReadable = ConvertEnumHumanReadable(_Type)
                    PropertyHasChanged()
                    PropertyHasChanged("Type")
                    Recalculate(True)
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
                If Not _FinancialDataCanChange Then Exit Property
                If Not (_Person Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Person Is Nothing AndAlso Not value Is Nothing AndAlso _Person = value) Then
                    _Person = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Account() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Account
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If _Account <> value Then
                    _Account = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Sum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Sum)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_Sum) <> CRound(value) Then
                    _Sum = CRound(value)
                    PropertyHasChanged()
                    Recalculate(True)
                End If
            End Set
        End Property

        Public Property CurrencyCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrencyCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)

                CanWriteProperty(True)

                If Not _FinancialDataCanChange Then Exit Property

                If value Is Nothing Then value = ""

                If Not CurrenciesEquals(_CurrencyCode, value, GetCurrentCompany.BaseCurrency) Then

                    _CurrencyCode = GetCurrencySafe(value, GetCurrentCompany.BaseCurrency)
                    PropertyHasChanged()

                    If CurrenciesEquals(_CurrencyCode, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) Then

                        _CurrencyRate = 1
                        _CurrencyRateChangeImpact = 0
                        _AccountCurrencyRateChangeImpact = 0

                        PropertyHasChanged("CurrencyRateChangeImpact")
                        PropertyHasChanged("AccountCurrencyRateChangeImpact")

                    Else
                        _CurrencyRate = 0
                    End If

                    PropertyHasChanged("CurrencyRate")

                    Recalculate(True)

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
                If Not _FinancialDataCanChange Then Exit Property
                If CurrenciesEquals(_CurrencyCode, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) Then value = 1
                If CRound(_CurrencyRate, 6) <> CRound(value, 6) Then
                    _CurrencyRate = CRound(value, 6)
                    PropertyHasChanged()
                    Recalculate(True)
                End If
            End Set
        End Property

        Public ReadOnly Property SumLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumLTL)
            End Get
        End Property

        Public Property CurrencyRateChangeImpact() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRateChangeImpact)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CurrenciesEquals(_CurrencyCode, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) Then value = 0
                If CRound(_CurrencyRateChangeImpact) <> CRound(value) Then
                    _CurrencyRateChangeImpact = CRound(value)
                    PropertyHasChanged()
                    Recalculate(True)
                End If
            End Set
        End Property

        Public Property AccountCurrencyRateChangeImpact() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountCurrencyRateChangeImpact
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CurrenciesEquals(_CurrencyCode, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) Then value = 0
                If _AccountCurrencyRateChangeImpact <> value Then
                    _AccountCurrencyRateChangeImpact = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Comments() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Comments.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Comments <> value.Trim Then
                    _Comments = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property Debit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Debit)
            End Get
        End Property

        Public ReadOnly Property Credit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Credit)
            End Get
        End Property



        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return "Klaida (-os) eilutėje '" & Me.ToString & "': " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return "Eilutėje '" & Me.ToString & "' gali būti klaida: " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
        End Function


        Private Sub Recalculate(ByVal RaisePropertyChangedEvents As Boolean)

            _SumLTL = CRound(CRound(_Sum) * CRound(_CurrencyRate, 6))

            If _Type = BookEntryType.Debetas Then

                _Debit = CRound(_SumLTL + Math.Abs(_CurrencyRateChangeImpact))
                _Credit = Math.Abs(_CurrencyRateChangeImpact)

            Else

                _Credit = CRound(_SumLTL + Math.Abs(_CurrencyRateChangeImpact))
                _Debit = Math.Abs(_CurrencyRateChangeImpact)

            End If

            If RaisePropertyChangedEvents Then
                PropertyHasChanged("SumLTL")
                PropertyHasChanged("Debit")
                PropertyHasChanged("Credit")
            End If
            

        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return DirectCast(IIf(Not _Person Is Nothing AndAlso _Person.ID > 0, _
                _Person.ToString, "asmuo nenurodytas"), String) & ",sąsk. " _
                & _Account.ToString & ", suma " & DblParser(_Sum) & _CurrencyCode
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.InfoObjectRequired, _
                New CommonValidation.InfoObjectRequiredRuleArgs("Person", "kontrahentas", "ID"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("Account", "koresponduojanti sąskaita"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("Sum", "užskaitoma suma"))
            ValidationRules.AddRule(AddressOf CommonValidation.CurrencyFieldValidation, _
                New CommonValidation.SimpleRuleArgs("CurrencyCode", "valiuta"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("CurrencyRate", "valiutos kursas"))

            ValidationRules.AddRule(AddressOf AccountCurrencyRateChangeImpactValidation, _
                New Validation.RuleArgs("AccountCurrencyRateChangeImpact"))

            ValidationRules.AddDependantProperty("CurrencyRateChangeImpact", _
                "AccountCurrencyRateChangeImpact", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property AccountCurrencyRateChangeImpact is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountCurrencyRateChangeImpactValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As OffsetItem = DirectCast(target, OffsetItem)

            If CRound(ValObj._CurrencyRateChangeImpact) <> 0 AndAlso _
                Not ValObj._AccountCurrencyRateChangeImpact > 0 Then
                e.Description = "Nenurodyta valiutos kurso pasikeitimo įtakos sąskaita."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf (ValObj._CurrencyCode Is Nothing OrElse _
                String.IsNullOrEmpty(ValObj._CurrencyCode.Trim) _
                OrElse ValObj._CurrencyCode.Trim.ToUpper = GetCurrentCompany.BaseCurrency) _
                AndAlso ValObj._AccountCurrencyRateChangeImpact > 0 Then
                e.Description = "Valiutos kurso pasikeitimo įtaka gali atsirasti tik jei naudojama valiuta."
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

        Friend Shared Function NewOffsetItem() As OffsetItem
            Dim result As New OffsetItem
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Friend Shared Function GetBalanceOffsetItem(ByVal ItemID As Integer, _
            ByVal BalanceSum As Double, ByVal BalanceAccount As Long) As OffsetItem

            If (CRound(BalanceSum) = 0 OrElse Not BalanceAccount > 0) _
                AndAlso Not ItemID > 0 Then Return Nothing

            Dim result As New OffsetItem

            result._ID = ItemID
            If CRound(BalanceSum) > 0 Then
                result._Type = BookEntryType.Kreditas
                result._Sum = CRound(BalanceSum)
            Else
                result._Type = BookEntryType.Debetas
                result._Sum = CRound(-BalanceSum)
            End If
            result._Account = BalanceAccount
            result._Comments = "Užskaitą balansuojantis įrašas"
            result._CurrencyCode = GetCurrentCompany.BaseCurrency
            result._CurrencyRate = 1
            result.Recalculate(False)

            Return result

        End Function

        Friend Shared Function GetOffsetItem(ByVal dr As DataRow, _
            ByVal nFinancialDataCanChange As Boolean) As OffsetItem
            Return New OffsetItem(dr, nFinancialDataCanChange)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal nFinancialDataCanChange As Boolean)
            MarkAsChild()
            Fetch(dr, nFinancialDataCanChange)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow, ByVal nFinancialDataCanChange As Boolean)

            _ID = CIntSafe(dr.Item(0), 0)
            _Sum = CDblSafe(dr.Item(1), 2, 0)
            _CurrencyCode = CStrSafe(dr.Item(2)).Trim
            _CurrencyRate = CDblSafe(dr.Item(3), 6, 0)
            _CurrencyRateChangeImpact = CDblSafe(dr.Item(4), 2, 0)
            _Type = ConvertEnumDatabaseStringCode(Of BookEntryType)(CStrSafe(dr.Item(5)))
            _TypeHumanReadable = ConvertEnumHumanReadable(_Type)
            _Account = CLongSafe(dr.Item(6), 0)
            _AccountCurrencyRateChangeImpact = CLongSafe(dr.Item(7), 0)
            _Comments = CStrSafe(dr.Item(8)).Trim
            _Person = PersonInfo.GetPersonInfo(dr, 9)

            Recalculate(False)

            _FinancialDataCanChange = nFinancialDataCanChange

            MarkOld()
            ValidationRules.CheckRules()

        End Sub

        Friend Sub Insert(ByVal parent As Offset)

            Dim myComm As New SQLCommand("InsertOffsetItem")
            myComm.AddParam("?AA", parent.ID)
            AddWithParams(myComm)
            myComm.AddParam("?AJ", _Comments.Trim)

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As Offset)

            Dim myComm As SQLCommand
            If parent.ChronologicValidator.FinancialDataCanChange Then
                myComm = New SQLCommand("UpdateOffsetItem")
                AddWithParams(myComm)
            Else
                myComm = New SQLCommand("UpdateOffsetItemNonFinancial")
            End If
            myComm.AddParam("?CD", _ID)
            myComm.AddParam("?AJ", _Comments.Trim)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteOffsetItem")
            myComm.AddParam("?CD", _ID)

            myComm.Execute()

            MarkNew()

        End Sub


        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AB", CRound(_Sum))
            myComm.AddParam("?AC", _CurrencyCode.Trim)
            myComm.AddParam("?AD", CRound(_CurrencyRate, 6))
            myComm.AddParam("?AE", CRound(_CurrencyRateChangeImpact))
            myComm.AddParam("?AF", ConvertEnumDatabaseStringCode(_Type))
            If Not _Person Is Nothing AndAlso _Person.ID > 0 Then
                myComm.AddParam("?AG", _Person.ID)
            Else
                myComm.AddParam("?AG", 0)
            End If
            myComm.AddParam("?AH", _Account)
            myComm.AddParam("?AI", _AccountCurrencyRateChangeImpact)

        End Sub

#End Region

    End Class

End Namespace