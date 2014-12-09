Namespace General

    <Serializable()> _
    Public Class Person
        Inherits BusinessBase(Of Person)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Private _ID As Integer = 0
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
        Private _LanguageCode As String = LanguageCodeLith
        Private _LanguageName As String = GetLanguageName(LanguageCodeLith, False)
        Private _CurrencyCode As String = GetCurrentCompany.BaseCurrency
        Private _IsNaturalPerson As Boolean = False
        Private _IsObsolete As Boolean = False
        Private _AccountAgainstBankBuyer As Long = 0
        Private _AccountAgainstBankSupplyer As Long = 0
        Private _MustBeAssignedToWorkers As Boolean = False
        Private _AssignedToGroups As PersonGroupAssignmentList
        Private _IsClient As Boolean = False
        Private _IsSupplier As Boolean = False
        Private _IsWorker As Boolean = False
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now


        ''' <summary>
        ''' Gets an ID of the person (assigned automaticaly by DB AUTOINCREMENT).
        ''' Returns 0 for a new person.
        ''' </summary>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets an official name of the person.
        ''' </summary>
        Public Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Name.Trim <> value.Trim Then
                    _Name = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an official registration/personal code of the person.
        ''' </summary>
        Public Property Code() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Code.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Code.Trim <> value.Trim Then
                    _Code = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an address of the person.
        ''' </summary>
        Public Property Address() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Address.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Address.Trim <> value.Trim Then
                    _Address = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a name of the bank used by the person.
        ''' </summary>
        Public Property Bank() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Bank.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Bank.Trim <> value.Trim Then
                    _Bank = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a bank account number used by the person.
        ''' </summary>
        Public Property BankAccount() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BankAccount.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _BankAccount.Trim <> value.Trim Then
                    _BankAccount = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a VAT payer code of the person.
        ''' </summary>
        Public Property CodeVAT() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CodeVAT.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _CodeVAT.Trim <> value.Trim Then
                    _CodeVAT = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a SODRA (social security) code of the person.
        ''' Only applicable to natural persons.
        ''' </summary>
        Public Property CodeSODRA() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CodeSODRA.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _CodeSODRA.Trim <> value.Trim Then
                    _CodeSODRA = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an email address of the person.
        ''' </summary>
        Public Property Email() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Email.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Email.Trim <> value.Trim Then
                    _Email = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets any other person info, e.g. phone number, etc.
        ''' </summary>
        Public Property ContactInfo() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContactInfo.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _ContactInfo.Trim <> value.Trim Then
                    _ContactInfo = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an internal code of the person for company's uses.
        ''' </summary>
        Public Property InternalCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InternalCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _InternalCode.Trim <> value.Trim Then
                    _InternalCode = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets default language code used by the person.
        ''' </summary>
        Public Property LanguageCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LanguageCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _LanguageCode.Trim <> value.Trim Then
                    _LanguageCode = value.Trim
                    _LanguageName = GetLanguageName(_LanguageCode, False)
                    PropertyHasChanged()
                    PropertyHasChanged("LanguageName")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets default language used by the person.
        ''' </summary>
        Public Property LanguageName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LanguageName.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If GetLanguageCode(value.Trim, False) <> _LanguageCode Then
                    _LanguageName = value.Trim
                    _LanguageCode = GetLanguageCode(value.Trim, False)
                    PropertyHasChanged()
                    PropertyHasChanged("LanguageCode")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets default currency code used by the person.
        ''' </summary>
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
        ''' Gets or sets an account to use when recognizing a bank operation 'money transfered'.
        ''' Automaticaly sets an operation Debet this account, Credit bank account.
        ''' </summary>
        Public Property AccountAgainstBankBuyer() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountAgainstBankBuyer
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _AccountAgainstBankBuyer <> value Then
                    _AccountAgainstBankBuyer = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an account to use when recognizing a bank operation 'money received'.
        ''' Automaticaly sets an operation Debet bank account, Credit this account.
        ''' </summary>
        Public Property AccountAgainstBankSupplyer() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountAgainstBankSupplyer
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _AccountAgainstBankSupplyer <> value Then
                    _AccountAgainstBankSupplyer = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets if the person is a natural person, i.e. not a company.
        ''' </summary>
        Public Property IsNaturalPerson() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsNaturalPerson
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _IsNaturalPerson <> value Then
                    _IsNaturalPerson = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property IsClient() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsClient
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _IsClient <> value Then
                    _IsClient = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property IsSupplier() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsSupplier
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _IsSupplier <> value Then
                    _IsSupplier = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property IsWorker() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsWorker
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                ' If _MustBeAssignedToWorkers AndAlso _IsWorker Then Exit Property
                If _IsWorker <> value Then
                    _IsWorker = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets if the person is no longer in use, i.e. not supposed to be displayed in combos.
        ''' </summary>
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
        ''' Gets a PersonGroupInfoList object associated with the person.
        ''' I.e. info about the groups to which the person is assigned.
        ''' </summary>
        Public ReadOnly Property AssignedToGroups() As PersonGroupAssignmentList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AssignedToGroups
            End Get
        End Property

        ''' <summary>
        ''' Indicates if the person must be assigned to employees, i.e. its data was used in employee module.
        ''' </summary>
        Public ReadOnly Property MustBeAssignedToWorkers() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MustBeAssignedToWorkers
            End Get
        End Property


        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_Name.Trim) _
                OrElse Not String.IsNullOrEmpty(_Code.Trim) _
                OrElse Not String.IsNullOrEmpty(_Address.Trim) _
                OrElse Not String.IsNullOrEmpty(_Bank.Trim) _
                OrElse Not String.IsNullOrEmpty(_BankAccount.Trim) _
                OrElse Not String.IsNullOrEmpty(_CodeVAT.Trim) _
                OrElse Not String.IsNullOrEmpty(_CodeSODRA.Trim) _
                OrElse Not String.IsNullOrEmpty(_Email.Trim) _
                OrElse Not String.IsNullOrEmpty(_ContactInfo.Trim) _
                OrElse Not String.IsNullOrEmpty(_InternalCode.Trim))
            End Get
        End Property

        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _AssignedToGroups.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid AndAlso _AssignedToGroups.IsValid
            End Get
        End Property



        Public Overrides Function Save() As Person

            Me.ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " & vbCrLf & Me.GetAllBrokenRules)

            Dim result As Person = MyBase.Save
            PersonInfoList.InvalidateCache()
            Return result

        End Function

        Public Function GetAllBrokenRules() As String
            Dim result As String = ""
            If Not MyBase.IsValid Then result = AddWithNewLine(result, _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error), False)
            If Not _AssignedToGroups.IsValid Then result = AddWithNewLine(result, _
                _AssignedToGroups.GetAllBrokenRules, False)
            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = ""
            If MyBase.BrokenRulesCollection.WarningCount > 0 Then result = AddWithNewLine(result, _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning), False)
            result = AddWithNewLine(result, _AssignedToGroups.GetAllWarnings, False)
            Return result
        End Function


        Public Sub AddWithPersonInfoData(ByVal info As InvoiceInfo.ClientInfo)

            _Address = info.Address
            _Code = info.Code
            _CodeVAT = info.CodeVAT
            _ContactInfo = info.Contacts
            _CurrencyCode = info.CurrencyCode
            _Email = info.Email
            _InternalCode = info.BreedCode
            _IsClient = info.IsClient
            _IsNaturalPerson = info.IsNaturalPerson
            _IsObsolete = info.IsObsolete
            _IsSupplier = info.IsSupplier
            _IsWorker = info.IsWorker
            _LanguageCode = info.LanguageCode
            _Name = info.Name

            PropertyHasChanged()

            ValidationRules.CheckRules()

        End Sub

        Public Function GetPersonInfo() As InvoiceInfo.ClientInfo

            Dim result As New InvoiceInfo.ClientInfo

            result.Address = Me._Address
            result.Code = Me._Code
            result.CodeVAT = Me._CodeVAT
            result.Contacts = Me._ContactInfo
            result.CurrencyCode = Me._CurrencyCode
            result.Email = Me._Email
            result.BreedCode = Me._InternalCode
            result.IsClient = Me._IsClient
            result.IsNaturalPerson = Me._IsNaturalPerson
            result.IsObsolete = Me._IsObsolete
            result.IsSupplier = Me._IsSupplier
            result.IsWorker = Me._IsWorker
            result.LanguageCode = Me._LanguageCode
            result.Name = Me._Name

            Return result

        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            If Not _ID > 0 Then Return ""
            Return _Name
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Name", "asmens pavadinimas (vardas, pavardė)"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Code", "asmens (įmonės) kodas"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Address", "asmens adresas"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("AccountAgainstBankBuyer", _
                "gaunamų banko įplaukų koresponduojanti kreditinė sąskaita", _
                Validation.RuleSeverity.Warning))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("AccountAgainstBankSupplyer", _
                "banko pervedimų koresponduojanti debetinė sąskaita", Validation.RuleSeverity.Warning))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("LanguageName", "asmens kalba"))
            ValidationRules.AddRule(AddressOf CommonValidation.CurrencyValid, _
                New CommonValidation.SimpleRuleArgs("CurrencyCode", ""))

            ValidationRules.AddRule(AddressOf CodeSODRAValidation, New Validation.RuleArgs("CodeSODRA"))
            ValidationRules.AddRule(AddressOf BaseGroupAssignmentValidation, _
                New Validation.RuleArgs("IsClient"))

            ValidationRules.AddDependantProperty("IsWorker", "CodeSODRA", False)
            ValidationRules.AddDependantProperty("IsWorker", "IsClient", False)
            ValidationRules.AddDependantProperty("IsSupplier", "IsClient", False)

        End Sub

        Private Shared Function CodeSODRAValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As Person = DirectCast(target, Person)

            If String.IsNullOrEmpty(ValObj._CodeSODRA.Trim) AndAlso ValObj._IsWorker Then
                e.Description = "Asmeniui, priskirtam bazinei grupei Darbuotojai, turi būti nurodytas SODROS kodas."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf ValObj._MustBeAssignedToWorkers AndAlso Not ValObj._IsWorker Then
                e.Description = "Šiam asmeniui yra registruota darbo sutarčių. " & _
                    "Jis privalo būti priskirtas grupei Darbuotojai."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        Private Shared Function BaseGroupAssignmentValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As Person = DirectCast(target, Person)

            If Not ValObj._IsWorker AndAlso Not ValObj._IsClient AndAlso Not ValObj._IsSupplier Then
                e.Description = "Asmeniuo nepriskirtas nė vienai bazinei grupei."
                e.Severity = Validation.RuleSeverity.Warning
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("General.Person2")
        End Sub

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.Person2")
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.Person1")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.Person3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.Person3")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function NewPerson() As Person

            Return DataPortal.Create(Of Person)()

        End Function

        Public Shared Function GetPerson(ByVal nID As Integer) As Person

            Return DataPortal.Fetch(Of Person)(New Criteria(nID))

        End Function

        Public Shared Sub DeletePerson(ByVal id As Integer)
            DataPortal.Delete(New Criteria(id))
            PersonInfoList.InvalidateCache()
        End Sub

        Friend Shared Function NewPersonServerSide() As Person
            Dim result As Person
            result._AssignedToGroups = PersonGroupAssignmentList.NewPersonGroupAssignmentList
            result.ValidationRules.CheckRules()
            Return result
        End Function


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

        Protected Overrides Sub DataPortal_Create()
            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims įvesti.")
            _AssignedToGroups = PersonGroupAssignmentList.GetPersonGroupAssignmentList(Me)
            ValidationRules.CheckRules()
        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims gauti.")

            Dim myComm As New SQLCommand("FetchPerson")
            myComm.AddParam("?PD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                If myData Is Nothing OrElse myData.Rows.Count < 1 Then Throw New Exception( _
                    "Klaida. Nerasti duomenys asmens, kurio ID=" & criteria.ID.ToString & ".")

                Dim dr As DataRow = myData.Rows(0)

                _ID = CIntSafe(dr.Item(0), 0)
                _Name = CStrSafe(dr.Item(1)).Trim
                _Code = CStrSafe(dr.Item(2)).Trim
                _Address = CStrSafe(dr.Item(3)).Trim
                _CodeVAT = CStrSafe(dr.Item(4)).Trim
                _BankAccount = CStrSafe(dr.Item(5)).Trim
                _Bank = CStrSafe(dr.Item(6)).Trim
                _AccountAgainstBankBuyer = CLongSafe(dr.Item(7), 0)
                _AccountAgainstBankSupplyer = CLongSafe(dr.Item(8), 0)
                _Email = CStrSafe(dr.Item(9)).Trim
                _CodeSODRA = CStrSafe(dr.Item(10)).Trim
                _MustBeAssignedToWorkers = ConvertDbBoolean(CIntSafe(dr.Item(11), 0))
                _ContactInfo = CStrSafe(dr.Item(12)).Trim
                _InternalCode = CStrSafe(dr.Item(13)).Trim
                _IsObsolete = ConvertDbBoolean(CIntSafe(dr.Item(14), 0))
                _IsNaturalPerson = ConvertDbBoolean(CIntSafe(dr.Item(15), 0))
                _LanguageCode = CStrSafe(dr.Item(16)).Trim
                _LanguageName = GetLanguageName(_LanguageCode, False)
                _CurrencyCode = CStrSafe(dr.Item(17)).Trim
                _IsClient = ConvertDbBoolean(CIntSafe(dr.Item(18), 0))
                _IsSupplier = ConvertDbBoolean(CIntSafe(dr.Item(19), 0))
                _IsWorker = ConvertDbBoolean(CIntSafe(dr.Item(20), 0))
                _InsertDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(21), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime
                _UpdateDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(22), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime

            End Using

            _AssignedToGroups = PersonGroupAssignmentList.GetPersonGroupAssignmentList(Me)

            ValidationRules.CheckRules()

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")

            CheckIfPersonCodeUnique()

            DoInsert()

        End Sub

        Friend Sub DoInsert()

            Dim myComm As New SQLCommand("AddPerson")
            AddWithParams(myComm)

            Dim TransactionExisted As Boolean = DatabaseAccess.TransactionExists
            If Not TransactionExisted Then DatabaseAccess.TransactionBegin()

            myComm.Execute()

            _ID = myComm.LastInsertID

            AssignedToGroups.Update(Me)

            If Not TransactionExisted Then DatabaseAccess.TransactionCommit()

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims pakeisti.")

            CheckIfPersonCodeUnique()
            CheckIfPersonMustBeEmployee()
            CheckIfUpdateDateChanged()

            DoUpdate()

        End Sub

        Friend Sub DoUpdate()

            Dim myComm As New SQLCommand("UpdatePerson")
            AddWithParams(myComm)
            myComm.AddParam("?PD", _ID)

            Dim TransactionExisted As Boolean = DatabaseAccess.TransactionExists
            If Not TransactionExisted Then DatabaseAccess.TransactionBegin()

            myComm.Execute()

            _AssignedToGroups.Update(Me)

            If Not TransactionExisted Then DatabaseAccess.TransactionCommit()

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims pašalinti.")

            CheckIfPersonCouldBeDeleted(DirectCast(criteria, Criteria).ID)

            DatabaseAccess.TransactionBegin()

            Dim myComm2 As New SQLCommand("DeletePerson")
            myComm2.AddParam("?PD", DirectCast(criteria, Criteria).ID)
            myComm2.Execute()

            Dim myComm3 As New SQLCommand("DeleteAllPersonAssignments")
            myComm3.AddParam("?PD", DirectCast(criteria, Criteria).ID)
            myComm3.Execute()

            DatabaseAccess.TransactionCommit()

            MarkNew()

        End Sub


        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?PN", _Name.Trim)
            myComm.AddParam("?PC", _Code.Trim)
            myComm.AddParam("?PA", _Address.Trim)
            myComm.AddParam("?PB", _Bank.Trim)
            myComm.AddParam("?PT", _BankAccount.Trim)
            myComm.AddParam("?PV", _CodeVAT.Trim)
            myComm.AddParam("?PS", _CodeSODRA.Trim)
            myComm.AddParam("?PE", _Email.Trim)
            myComm.AddParam("?PQ", _AccountAgainstBankBuyer)
            myComm.AddParam("?PW", _AccountAgainstBankSupplyer)
            myComm.AddParam("?AI", _ContactInfo.Trim)
            myComm.AddParam("?AJ", ConvertDbBoolean(_IsObsolete))
            myComm.AddParam("?AK", _InternalCode.Trim)
            myComm.AddParam("?AL", ConvertDbBoolean(_IsNaturalPerson))
            myComm.AddParam("?AM", _LanguageCode.Trim)
            myComm.AddParam("?AN", _CurrencyCode.Trim)
            myComm.AddParam("?IC", ConvertDbBoolean(_IsClient))
            myComm.AddParam("?IP", ConvertDbBoolean(_IsSupplier))
            myComm.AddParam("?IW", ConvertDbBoolean(_IsWorker))

            _UpdateDate = DateTime.Now
            _UpdateDate = New DateTime(Math.Floor(_UpdateDate.Ticks / TimeSpan.TicksPerSecond) _
                * TimeSpan.TicksPerSecond)
            If Me.IsNew Then _InsertDate = _UpdateDate
            myComm.AddParam("?UD", _UpdateDate.ToUniversalTime)

        End Sub


        Private Sub CheckIfPersonCodeUnique()

            Dim myComm As New SQLCommand("GetPersonExists")
            myComm.AddParam("?PC", _Code)
            myComm.AddParam("?PD", _ID)
            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 AndAlso ConvertDbBoolean(CIntSafe(myData.Rows(0).Item(0), 0)) Then _
                    Throw New Exception("Klaida. Asmuo su tokiu asmens/įmonės kodu jau egzistuoja.")
            End Using

        End Sub

        Private Sub CheckIfPersonMustBeEmployee()

            If IsNew Then Exit Sub

            Dim myComm As New SQLCommand("CheckIfPersonMustBeEmployee")
            myComm.AddParam("?PD", _ID)
            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 AndAlso ConvertDbBoolean(CIntSafe(myData.Rows(0).Item(0), 0)) _
                    AndAlso Not _IsWorker Then _IsWorker = True
            End Using

        End Sub

        Private Shared Sub CheckIfPersonCouldBeDeleted(ByVal PersonID)

            Dim myComm As New SQLCommand("PersonCanBeDeleted")
            myComm.AddParam("?PD", PersonID)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 AndAlso CIntSafe(myData.Rows(0).Item(0), 0) > 0 Then
                    Throw New Exception("Klaida. Šio asmens duomenys buvo panaudoti bendrajame žurnale.")
                ElseIf myData.Rows.Count > 0 AndAlso CIntSafe(myData.Rows(0).Item(1), 0) > 0 Then
                    Throw New Exception("Klaida. Šiam asmeniui yra priskirta darbo sutartis.")
                End If
            End Using

        End Sub

        Private Sub CheckIfUpdateDateChanged()

            Dim myComm As New SQLCommand("CheckIfPersonUpdateDateChanged")
            myComm.AddParam("?CD", _ID)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count < 1 OrElse CDateTimeSafe(myData.Rows(0).Item(0), _
                    Date.MinValue) = Date.MinValue Then Throw New Exception( _
                    "Klaida. Objektas, kurio ID=" & _ID.ToString & ", nerastas.")
                If DateTime.SpecifyKind(CDateTimeSafe(myData.Rows(0).Item(0), DateTime.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime <> _UpdateDate Then Throw New Exception( _
                    "Klaida. Dokumento atnaujinimo data pasikeitė. Teigtina, kad kitas " _
                    & "vartotojas redagavo šį objektą.")
            End Using

        End Sub

#End Region

    End Class

End Namespace