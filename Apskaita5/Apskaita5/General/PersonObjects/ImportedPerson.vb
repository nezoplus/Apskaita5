Namespace General

    <Serializable()> _
    Public Class ImportedPerson
        Inherits BusinessBase(Of ImportedPerson)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Friend Const ColumnCount As Integer = 19
        Public Const ColumnSequence As String = "Kontrahento duomenys privalo būti išdėstyti " _
            & "19 stulpelių: pavadinimas, asmens ar įmonės kodas, adresas, " _
            & "banko pabadinimas, banko sąskaitos numeris, PVM mokėtojo kodas, SODROS kodas, " _
            & "e-paštas, kontaktinė info, vidinis kodas, kalbos kodas, valiutos kodas, " _
            & "fizinio asmens žymuo(0/1), pirkėjo žymuo(0/1), tiekėjo žymuo(0/1), " _
            & "darbuotojo žymuo(0/1), nebenaudojamas žymuo(0/1), kontuojama pirkėjo sąskaita, " _
            & "kontuojama tiekėjo sąskaita."

        Private _Guid As Guid = Guid.NewGuid
        Private _Name As String = ""
        Private _Code As String = ""
        Private _Address As String = ""
        Private _Bank As String = ""
        Private _BankAccount As String = ""
        Private _CodeVAT As String = ""
        Private _CodeSODRA As String = ""
        Private _Email As String = ""
        Private _ContactInfo As String = ""
        Private _InternalCode As String = ""
        Private _LanguageCode As String = ""
        Private _CurrencyCode As String = ""
        Private _AccountAgainstBankBuyer As Long = 0
        Private _AccountAgainstBankSupplyer As Long = 0
        Private _IsNaturalPerson As Boolean = False
        Private _IsClient As Boolean = False
        Private _IsSupplier As Boolean = False
        Private _IsWorker As Boolean = False
        Private _IsObsolete As Boolean = False
        Private _AlreadyPresent As Boolean = False
        Private _NotUniqueCode As Boolean = False


        Public ReadOnly Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
        End Property

        Public ReadOnly Property Code() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Code.Trim
            End Get
        End Property

        Public ReadOnly Property Address() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Address.Trim
            End Get
        End Property

        Public ReadOnly Property Bank() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Bank.Trim
            End Get
        End Property

        Public ReadOnly Property BankAccount() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BankAccount.Trim
            End Get
        End Property

        Public ReadOnly Property CodeVAT() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CodeVAT.Trim
            End Get
        End Property

        Public ReadOnly Property CodeSODRA() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CodeSODRA.Trim
            End Get
        End Property

        Public ReadOnly Property Email() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Email.Trim
            End Get
        End Property

        Public ReadOnly Property ContactInfo() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContactInfo.Trim
            End Get
        End Property

        Public ReadOnly Property InternalCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InternalCode.Trim
            End Get
        End Property

        Public ReadOnly Property LanguageCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LanguageCode.Trim
            End Get
        End Property

        Public ReadOnly Property CurrencyCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrencyCode.Trim
            End Get
        End Property

        Public ReadOnly Property AccountAgainstBankBuyer() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountAgainstBankBuyer
            End Get
        End Property

        Public ReadOnly Property AccountAgainstBankSupplyer() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountAgainstBankSupplyer
            End Get
        End Property

        Public ReadOnly Property IsNaturalPerson() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsNaturalPerson
            End Get
        End Property

        Public ReadOnly Property IsClient() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsClient
            End Get
        End Property

        Public ReadOnly Property IsSupplier() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsSupplier
            End Get
        End Property

        Public ReadOnly Property IsWorker() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsWorker
            End Get
        End Property

        Public ReadOnly Property IsObsolete() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsObsolete
            End Get
        End Property

        Public ReadOnly Property AlreadyPresent() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AlreadyPresent
            End Get
        End Property

        Public ReadOnly Property NotUniqueCode() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NotUniqueCode
            End Get
        End Property


        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return "Klaida (-os) eilutėje '" & _Name & "': " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return "Eilutėje '" & _Name & "' gali būti klaida: " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
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

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Name", "kontrahento pavadinimas"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Code", "kontrahento asmens ar įmonės kodas"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Address", "kontrahento adresas"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("LanguageCode", "kalbos kodas pgl. ISO 639-1"))
            ValidationRules.AddRule(AddressOf CommonValidation.CurrencyValid, _
                New CommonValidation.SimpleRuleArgs("CurrencyCode", ""))
            ValidationRules.AddRule(AddressOf AlreadyPresentValidation, _
                New Validation.RuleArgs("AlreadyPresent"))
            ValidationRules.AddRule(AddressOf NotUniqueCodeValidation, _
                New Validation.RuleArgs("NotUniqueCode"))

        End Sub

        Private Shared Function AlreadyPresentValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As ImportedPerson = DirectCast(target, ImportedPerson)

            If ValObj._AlreadyPresent Then
                e.Description = "Kontrahentas su tokiu asmens ar įmonės kodu jau yra įtrauktas į duomenų bazę."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        Private Shared Function NotUniqueCodeValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As ImportedPerson = DirectCast(target, ImportedPerson)

            If ValObj._NotUniqueCode Then
                e.Description = "Importuojamuose duomenyse toks kontrahento kodas neunikalus."
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

        Friend Shared Function GetImportedPerson(ByVal s As String(), _
            ByVal AccountList As List(Of Long), ByVal PersonCodeList As List(Of String), _
            ByRef PreviousCodes As List(Of String)) As ImportedPerson
            Return New ImportedPerson(s, AccountList, PersonCodeList, PreviousCodes)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal s As String(), ByVal AccountList As List(Of Long), _
            ByVal PersonCodeList As List(Of String), ByRef PreviousCodes As List(Of String))
            MarkAsChild()
            Fetch(s, AccountList, PersonCodeList, PreviousCodes)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal s As String(), ByVal AccountList As List(Of Long), _
            ByVal PersonCodeList As List(Of String), ByRef PreviousCodes As List(Of String))

            _Name = CStrSafe(GetItem(s, 0)).Trim
            _Code = CStrSafe(GetItem(s, 1)).Trim
            _Address = CStrSafe(GetItem(s, 2)).Trim
            _Bank = CStrSafe(GetItem(s, 3)).Trim
            _BankAccount = CStrSafe(GetItem(s, 4)).Trim
            _CodeVAT = CStrSafe(GetItem(s, 5)).Trim
            _CodeSODRA = CStrSafe(GetItem(s, 6)).Trim
            _Email = CStrSafe(GetItem(s, 7)).Trim
            _ContactInfo = CStrSafe(GetItem(s, 8)).Trim
            _InternalCode = CStrSafe(GetItem(s, 9)).Trim
            _LanguageCode = CStrSafe(GetItem(s, 10)).Trim
            _CurrencyCode = CStrSafe(GetItem(s, 11)).Trim
            _IsNaturalPerson = ConvertDbBoolean(CIntSafe(GetItem(s, 12), 0))
            _IsClient = ConvertDbBoolean(CIntSafe(GetItem(s, 13), 0))
            _IsSupplier = ConvertDbBoolean(CIntSafe(GetItem(s, 14), 0))
            _IsWorker = ConvertDbBoolean(CIntSafe(GetItem(s, 15), 15))
            _IsObsolete = ConvertDbBoolean(CIntSafe(GetItem(s, 16), 0))
            _AccountAgainstBankBuyer = CLongSafe(GetItem(s, 17), 0)
            _AccountAgainstBankSupplyer = CLongSafe(GetItem(s, 18), 0)

            If Not AccountList.Contains(_AccountAgainstBankBuyer) Then _AccountAgainstBankBuyer = 0
            If Not AccountList.Contains(_AccountAgainstBankSupplyer) Then _AccountAgainstBankSupplyer = 0

            If Not String.IsNullOrEmpty(_Code.Trim) Then

                If PersonCodeList.Contains(_Code.Trim.ToUpper) Then
                    _AlreadyPresent = True
                Else
                    _AlreadyPresent = False
                End If

                If PreviousCodes.Contains(_Code.Trim.ToUpper) Then
                    _NotUniqueCode = True
                Else
                    _NotUniqueCode = False
                    PreviousCodes.Add(_Code.Trim.ToUpper)
                End If

            End If

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Friend Sub Insert()

            Dim p As Person = Person.NewPersonServerSide

            p.Name = _Name
            p.Code = _Code
            p.Address = _Address
            p.Bank = _Bank
            p.BankAccount = _BankAccount
            p.CodeVAT = _CodeVAT
            p.CodeSODRA = _CodeSODRA
            p.Email = _Email
            p.ContactInfo = _ContactInfo
            p.InternalCode = _InternalCode
            p.LanguageCode = _LanguageCode
            p.CurrencyCode = _CurrencyCode
            p.IsNaturalPerson = _IsNaturalPerson
            p.IsClient = _IsClient
            p.IsSupplier = _IsSupplier
            p.IsWorker = _IsWorker
            p.IsObsolete = _IsObsolete
            p.AccountAgainstBankBuyer = _AccountAgainstBankBuyer
            p.AccountAgainstBankSupplyer = _AccountAgainstBankSupplyer

            p.DoInsert()

            _AlreadyPresent = True

            MarkOld()

        End Sub

        Private Function GetItem(ByVal s As String(), ByVal index As Integer) As String
            If s Is Nothing OrElse index + 1 > s.Length Then Return ""
            Return s(index)
        End Function

#End Region

    End Class

End Namespace