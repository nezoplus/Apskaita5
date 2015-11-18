Namespace Goods

    <Serializable()> _
    Public Class GoodsOperationAccountChange
        Inherits BusinessBase(Of GoodsOperationAccountChange)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _Type As GoodsOperationType = GoodsOperationType.AccountDiscountsChange
        Private _TypeHumanReadable As String = ConvertEnumHumanReadable(GoodsOperationType.AccountDiscountsChange)
        Private _GoodsInfo As GoodsSummary
        Private _OperationLimitations As OperationalLimitList
        Private _JournalEntryID As Integer = 0
        Private _DocumentNumber As String = ""
        Private _Date As Date = Today
        Private _OldDate As Date = Today
        Private _Description As String = ""
        Private _PreviousAccount As Long = 0
        Private _NewAccount As Long = 0
        Private _CorrespondationValue As Double = 0
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property [Type]() As GoodsOperationType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
        End Property

        Public ReadOnly Property TypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TypeHumanReadable
            End Get
        End Property

        Public ReadOnly Property GoodsInfo() As GoodsSummary
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo
            End Get
        End Property

        Public ReadOnly Property OperationLimitations() As OperationalLimitList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationLimitations
            End Get
        End Property

        Public ReadOnly Property JournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryID
            End Get
        End Property

        Public ReadOnly Property OldDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OldDate
            End Get
        End Property

        Public ReadOnly Property PreviousAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PreviousAccount
            End Get
        End Property

        Public ReadOnly Property CorrespondationValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CorrespondationValue)
            End Get
        End Property


        Public Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                CanWriteProperty(True)
                If _Date.Date <> value.Date Then
                    _Date = value.Date
                    PropertyHasChanged()
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

        Public Property Description() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Description.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Description.Trim <> value.Trim Then
                    _Description = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property NewAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NewAccount
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If Not _OperationLimitations.FinancialDataCanChange Then Exit Property
                If _NewAccount <> value Then
                    _NewAccount = value
                    PropertyHasChanged()
                End If
            End Set
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


        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_DocumentNumber.Trim) _
                    OrElse Not String.IsNullOrEmpty(_Description.Trim) OrElse _NewAccount > 0)
            End Get
        End Property



        Public Overrides Function Save() As GoodsOperationAccountChange
            If IsNew AndAlso Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")
            If Not IsNew AndAlso Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims pakeisti.")

            Me.ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " & vbCrLf _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))
            Return MyBase.Save

        End Function

        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return "Goods.GoodsOperationAccountChange"
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("DocumentNumber", "dokumento numeris"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Description", "operacijos aprašmas (pagrindimas)"))
            ValidationRules.AddRule(AddressOf CommonValidation.ChronologyValidation, _
                New CommonValidation.ChronologyRuleArgs("Date", "OperationLimitations"))

            ValidationRules.AddRule(AddressOf NewAccountValidation, New Validation.RuleArgs("NewAccount"))

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property NewAccount is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function NewAccountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As GoodsOperationAccountChange = DirectCast(target, GoodsOperationAccountChange)

            If Not ValObj._NewAccount > 0 Then
                e.Description = "Nenurodyta nauja sąskaita."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf ValObj._NewAccount = ValObj._PreviousAccount Then
                e.Description = "Nauja sąskaita negali sutapti su prieš tai buvusia."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Goods.GoodsOperationAccountChange2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationAccountChange1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationAccountChange2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationAccountChange3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationAccountChange3")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function NewGoodsOperationAccountChange(ByVal GoodsID As Integer, _
            ByVal nType As GoodsOperationType) As GoodsOperationAccountChange

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")

            Return DataPortal.Create(Of GoodsOperationAccountChange)(New Criteria(GoodsID, nType))

        End Function

        Public Shared Function GetGoodsOperationAccountChange(ByVal nID As Integer) As GoodsOperationAccountChange
            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")
            Return DataPortal.Fetch(Of GoodsOperationAccountChange)(New Criteria(nID))
        End Function

        Public Shared Sub DeleteGoodsOperationAccountChange(ByVal id As Integer)
            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka sąskaitos duomenų ištrynimui.")
            DataPortal.Delete(New Criteria(id))
        End Sub


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private mId As Integer
            Private mType As GoodsOperationType
            Public ReadOnly Property Id() As Integer
                Get
                    Return mId
                End Get
            End Property
            Public ReadOnly Property [Type]() As GoodsOperationType
                Get
                    Return mType
                End Get
            End Property
            Public Sub New(ByVal id As Integer, ByVal nType As GoodsOperationType)
                mId = id
                mType = nType
            End Sub
            Public Sub New(ByVal id As Integer)
                mId = id
                mType = GoodsOperationType.AccountDiscountsChange
            End Sub
        End Class


        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)

            If criteria.Type <> GoodsOperationType.AccountDiscountsChange AndAlso _
                criteria.Type <> GoodsOperationType.AccountPurchasesChange AndAlso _
                criteria.Type <> GoodsOperationType.AccountSalesNetCostsChange AndAlso _
                criteria.Type <> GoodsOperationType.AccountValueReductionChange Then _
                Throw New Exception("Klaida. Nurodytas tipas nėra prekių apskaitos " _
                & "sąskaitos pakeitimas (" & ConvertEnumHumanReadable(criteria.Type) & ").")

            _Type = criteria.Type
            _TypeHumanReadable = ConvertEnumHumanReadable(_Type)

            _GoodsInfo = GoodsSummary.GetGoodsSummary(criteria.Id)
            _OperationLimitations = OperationalLimitList.GetOperationalLimitList( _
                _GoodsInfo.ID, 0, criteria.Type, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, Today, 0, Nothing)

            If _GoodsInfo.AccountingMethod <> GoodsAccountingMethod.Periodic _
                AndAlso criteria.Type <> GoodsOperationType.AccountValueReductionChange Then _
                Throw New Exception("Klaida. Nuolat apskaitomoms prekėms gali būti keičiama " _
                & "tik nukainojimo sąskaita.")

            Select Case _Type
                Case GoodsOperationType.AccountDiscountsChange
                    _PreviousAccount = _GoodsInfo.AccountDiscounts
                Case GoodsOperationType.AccountPurchasesChange
                    _PreviousAccount = _GoodsInfo.AccountPurchases
                Case GoodsOperationType.AccountSalesNetCostsChange
                    _PreviousAccount = _GoodsInfo.AccountSalesNetCosts
                Case GoodsOperationType.AccountValueReductionChange
                    _PreviousAccount = _GoodsInfo.AccountValueReduction
                Case Else
                    Throw New Exception("Klaida. Nurodytas tipas nėra prekių apskaitos " _
                        & "sąskaitos pakeitimas (" & ConvertEnumHumanReadable(criteria.Type) & ").")
            End Select

            LoadCorrespondationValue()

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            Dim myComm As New SQLCommand("FetchGoodsOperationAccountChange")
            myComm.AddParam("?OD", criteria.Id)

            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Throw New Exception("Klaida. Operacija, kurios ID='" _
                    & criteria.Id & "', nerasta.)")

                Dim dr As DataRow = myData.Rows(0)

                _ID = CIntSafe(dr.Item(0), 0)
                _Type = ConvertEnumDatabaseCode(Of GoodsOperationType)(CIntSafe(dr.Item(1), 0))
                _TypeHumanReadable = ConvertEnumHumanReadable(_Type)
                _Date = CDateSafe(dr.Item(2), Today)
                _NewAccount = CLongSafe(dr.Item(3), 0)
                _DocumentNumber = CStrSafe(dr.Item(5)).Trim
                _Description = CStrSafe(dr.Item(6)).Trim
                _JournalEntryID = CIntSafe(dr.Item(7), 0)
                _CorrespondationValue = CDblSafe(dr.Item(8), 2, 0)
                _InsertDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(9), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime
                _UpdateDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(10), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime

                _GoodsInfo = GoodsSummary.GetGoodsSummary(dr, 11)

                If Not _PreviousAccount > 0 Then
                    Select Case _Type
                        Case GoodsOperationType.AccountDiscountsChange
                            _PreviousAccount = _GoodsInfo.AccountDiscounts
                        Case GoodsOperationType.AccountPurchasesChange
                            _PreviousAccount = _GoodsInfo.AccountPurchases
                        Case GoodsOperationType.AccountSalesNetCostsChange
                            _PreviousAccount = _GoodsInfo.AccountSalesNetCosts
                        Case GoodsOperationType.AccountValueReductionChange
                            _PreviousAccount = _GoodsInfo.AccountValueReduction
                    End Select
                End If

                _OperationLimitations = OperationalLimitList.GetOperationalLimitList( _
                    _GoodsInfo.ID, _ID, _Type, _GoodsInfo.ValuationMethod, _
                    _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _Date, 0, Nothing)

            End Using

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList( _
                _GoodsInfo.ID, _ID, _Type, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _Date, 0, Nothing)

            ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Prekių '" & _GoodsInfo.Name _
                & "' apskaitos sąskaitos pakeitimo operacijoje yra klaidų: " _
                & BrokenRulesCollection.ToString)

            LoadCorrespondationValue()

            Dim JE As General.JournalEntry = GetJournalEntryForDocument()

            Dim myComm As New SQLCommand("InsertGoodsOperationAccountChange")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(_Type))
            myComm.AddParam("?AB", _GoodsInfo.ID)
            AddWithParamsGeneral(myComm)
            AddWithParamsFinancial(myComm)

            Using transaction As New SqlTransaction

                Try

                    If Not JE Is Nothing Then
                        JE = JE.SaveChild
                        _JournalEntryID = JE.ID
                        myComm.AddParam("?AE", _JournalEntryID)
                    Else
                        myComm.AddParam("?AE", 0)
                    End If

                    myComm.Execute()

                    _ID = Convert.ToInt32(myComm.LastInsertID)

                    _OldDate = _Date

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                _ID, _Type, _GoodsInfo.ValuationMethod, _GoodsInfo.AccountingMethod, _
                _GoodsInfo.Name, _OldDate, 0, Nothing)

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList( _
                _GoodsInfo.ID, _ID, _Type, _GoodsInfo.ValuationMethod, _GoodsInfo.AccountingMethod, _
                _GoodsInfo.Name, _OldDate, 0, Nothing)

            ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Prekių '" & _GoodsInfo.Name _
                & "' apskaitos sąskaitos pakeitimo operacijoje yra klaidų: " _
                & BrokenRulesCollection.ToString)

            Dim JE As General.JournalEntry = GetJournalEntryForDocument()

            CheckIfUpdateDateChanged()

            Dim myComm As SQLCommand
            If _OperationLimitations.FinancialDataCanChange Then
                myComm = New SQLCommand("UpdateGoodsOperationAccountChangeFull")
                AddWithParamsFinancial(myComm)
            Else
                myComm = New SQLCommand("UpdateGoodsOperationAccountChangeLimited")
            End If
            AddWithParamsGeneral(myComm)

            myComm.AddParam("?CD", _ID)

            Using transaction As New SqlTransaction

                Try

                    If Not JE Is Nothing Then JE.SaveChild()

                    myComm.Execute()

                    _OldDate = _Date

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                _ID, _Type, _GoodsInfo.ValuationMethod, _GoodsInfo.AccountingMethod, _
                _GoodsInfo.Name, _OldDate, 0, Nothing)

            MarkOld()

        End Sub

        Private Function GetJournalEntryForDocument() As General.JournalEntry

            If CRound(_CorrespondationValue) = 0 Then Return Nothing

            Dim result As General.JournalEntry = Nothing

            If IsNew Then

                If _Date.Date <= GetCurrentCompany.LastClosingDate.Date Then Throw New Exception( _
                    "Klaida. Neleidžiama koreguoti operacijų po uždarymo (" _
                    & GetCurrentCompany.LastClosingDate & ").")

                result = General.JournalEntry.NewJournalEntryChild(DocumentType.GoodsAccountChange)

            Else

                result = General.JournalEntry.GetJournalEntryChild(_JournalEntryID, _
                    DocumentType.GoodsAccountChange)

            End If

            result.Date = _Date.Date
            result.Person = Nothing
            result.Content = _Description & " (" & _TypeHumanReadable & ")"
            result.DocNumber = _DocumentNumber

            If _OperationLimitations.FinancialDataCanChange Then

                Dim CommonBookEntryList As BookEntryInternalList = _
                BookEntryInternalList.NewBookEntryInternalList(BookEntryType.Debetas)

                If CRound(_CorrespondationValue) > 0 Then

                    Dim GoodsAccountBookEntry As BookEntryInternal = _
                    BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas)
                    GoodsAccountBookEntry.Account = _PreviousAccount
                    GoodsAccountBookEntry.Ammount = CRound(_CorrespondationValue)

                    CommonBookEntryList.Add(GoodsAccountBookEntry)

                    Dim CostsAccountBookEntry As BookEntryInternal = _
                        BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas)
                    CostsAccountBookEntry.Account = _NewAccount
                    CostsAccountBookEntry.Ammount = CRound(_CorrespondationValue)

                    CommonBookEntryList.Add(CostsAccountBookEntry)

                Else

                    Dim GoodsAccountBookEntry As BookEntryInternal = _
                    BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas)
                    GoodsAccountBookEntry.Account = _PreviousAccount
                    GoodsAccountBookEntry.Ammount = CRound(-_CorrespondationValue)

                    CommonBookEntryList.Add(GoodsAccountBookEntry)

                    Dim CostsAccountBookEntry As BookEntryInternal = _
                        BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas)
                    CostsAccountBookEntry.Account = _NewAccount
                    CostsAccountBookEntry.Ammount = CRound(-_CorrespondationValue)

                    CommonBookEntryList.Add(CostsAccountBookEntry)

                End If

                result.DebetList.LoadBookEntryListFromInternalList(CommonBookEntryList, False, False)
                result.CreditList.LoadBookEntryListFromInternalList(CommonBookEntryList, False, False)

            End If

            If Not result.IsValid Then Throw New Exception("Klaida. Nekorektiškai generuotas " _
                & "bendrojo žurnalo įrašas: " & result.GetAllBrokenRules)

            Return result

        End Function


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            Dim OperationToDelete As GoodsOperationAccountChange = New GoodsOperationAccountChange
            OperationToDelete.DataPortal_Fetch(DirectCast(criteria, Criteria))

            If Not OperationToDelete._OperationLimitations.FinancialDataCanChange Then _
                Throw New Exception("Klaida. " & OperationToDelete._OperationLimitations. _
                FinancialDataCanChangeExplanation)

            Dim JEID As Integer = OperationToDelete.JournalEntryID

            If JEID > 0 Then IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted(JEID, _
                DocumentType.GoodsAccountChange)

            Dim myComm As New SQLCommand("DeleteGoodsOperationAccountChange")
            myComm.AddParam("?CD", DirectCast(criteria, Criteria).Id)

            Using transaction As New SqlTransaction

                Try

                    If JEID > 0 Then General.JournalEntry.DeleteJournalEntryChild(JEID)

                    myComm.Execute()

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkNew()

        End Sub


        Private Sub AddWithParamsGeneral(ByRef myComm As SQLCommand)

            myComm.AddParam("?AD", _Date.Date)
            myComm.AddParam("?AF", _DocumentNumber.Trim)
            myComm.AddParam("?AG", _Description.Trim)

            _UpdateDate = DateTime.Now
            _UpdateDate = New DateTime(Convert.ToInt64(Math.Floor(_UpdateDate.Ticks / TimeSpan.TicksPerSecond) _
                * TimeSpan.TicksPerSecond))
            If Not _ID > 0 Then _InsertDate = _UpdateDate
            myComm.AddParam("?AH", _UpdateDate)

        End Sub

        Private Sub AddWithParamsFinancial(ByRef myComm As SQLCommand)
            myComm.AddParam("?AC", _NewAccount)
        End Sub


        Private Sub LoadCorrespondationValue()

            Dim myComm As SQLCommand

            Select Case _Type
                Case GoodsOperationType.AccountDiscountsChange
                    myComm = New SQLCommand("CreateGoodsOperationAccountChangeDiscounts")
                Case GoodsOperationType.AccountPurchasesChange
                    myComm = New SQLCommand("CreateGoodsOperationAccountChangePurchases")
                Case GoodsOperationType.AccountSalesNetCostsChange
                    myComm = New SQLCommand("CreateGoodsOperationAccountChangeSalesNetCosts")
                Case GoodsOperationType.AccountValueReductionChange
                    myComm = New SQLCommand("CreateGoodsOperationAccountChangePriceCut")
                Case Else
                    Throw New Exception("Klaida. Nurodytas tipas nėra prekių apskaitos " _
                        & "sąskaitos pakeitimas (" & ConvertEnumHumanReadable(_Type) & ").")
            End Select

            myComm.AddParam("?GD", _GoodsInfo.ID)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 AndAlso CDblSafe(myData.Rows(0).Item(0), 2, 0) <> 0 Then _
                    _CorrespondationValue = CDblSafe(myData.Rows(0).Item(0), 2, 0)
            End Using

        End Sub

        Private Sub CheckIfUpdateDateChanged()

            Dim myComm As New SQLCommand("CheckIfAccountChangeUpdateDateChanged")
            myComm.AddParam("?CD", _ID)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count < 1 OrElse CDateTimeSafe(myData.Rows(0).Item(0), _
                    Date.MinValue) = Date.MinValue Then Throw New Exception( _
                    "Klaida. Prekių operacija, kurios ID=" & _ID.ToString & ", nerasta.")
                If DateTime.SpecifyKind(CDateTimeSafe(myData.Rows(0).Item(0), DateTime.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime <> _UpdateDate Then Throw New Exception( _
                    "Klaida. Prekių operacijos atnaujinimo data pasikeitė. Teigtina, kad kitas " _
                    & "vartotojas redagavo šį objektą.")
            End Using

        End Sub

#End Region

    End Class

End Namespace