Namespace Documents

    <Serializable()> _
    Public Class AdvanceReport
        Inherits BusinessBase(Of AdvanceReport)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _ChronologicValidator As SimpleChronologicValidator
        Private _Date As Date = Today
        Private _OldDate As Date = Today
        Private _DocumentNumber As String = ""
        Private _Content As String = ""
        Private _Person As PersonInfo = Nothing
        Private _Account As Long = 0
        Private _CurrencyCode As String = GetCurrentCompany.BaseCurrency
        Private _CurrencyRate As Double = 1
        Private _Comments As String = ""
        Private _CommentsInternal As String = ""
        Private _Sum As Double = 0
        Private _SumVat As Double = 0
        Private _SumTotal As Double = 0
        Private _SumLTL As Double = 0
        Private _SumVatLTL As Double = 0
        Private _SumTotalLTL As Double = 0
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private WithEvents _ReportItems As AdvanceReportItemList


        Private SuspendChildListChangedEvents As Boolean = False
        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _ReportItemsSortedList As Csla.SortedBindingList(Of AdvanceReportItem) = Nothing

        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property ChronologicValidator() As SimpleChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ChronologicValidator
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

        Public ReadOnly Property OldDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OldDate
            End Get
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

        Public Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Content.Trim <> value.Trim Then
                    _Content = value.Trim
                    PropertyHasChanged()
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
                If Not _ChronologicValidator.FinancialDataCanChange Then Exit Property
                If _Account <> value Then
                    _Account = value
                    PropertyHasChanged()
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
                If value Is Nothing Then value = ""
                If Not _ChronologicValidator.FinancialDataCanChange Then Exit Property
                If _CurrencyCode.Trim <> value.Trim Then
                    _CurrencyCode = value.Trim
                    PropertyHasChanged()
                    If Not String.IsNullOrEmpty(_CurrencyCode.Trim) AndAlso _
                        _CurrencyCode.Trim.ToUpper <> GetCurrentCompany.BaseCurrency Then
                        CurrencyRate = 0
                    ElseIf Not String.IsNullOrEmpty(_CurrencyCode.Trim) AndAlso _
                        _CurrencyCode.Trim.ToUpper = GetCurrentCompany.BaseCurrency Then
                        CurrencyRate = 1
                    End If
                    If Not String.IsNullOrEmpty(_CurrencyCode.Trim) Then _
                        _ReportItems.UpdateCurrencyCode(_CurrencyCode)
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
                If Not _ChronologicValidator.FinancialDataCanChange Then Exit Property
                If CRound(_CurrencyRate, 6) <> CRound(value, 6) Then
                    _CurrencyRate = CRound(value, 6)
                    PropertyHasChanged()
                    If CRound(_CurrencyRate, 6) > 0 Then _ReportItems.UpdateCurrencyRate(_CurrencyRate)
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
                If _Comments.Trim <> value.Trim Then
                    _Comments = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property CommentsInternal() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CommentsInternal.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _CommentsInternal.Trim <> value.Trim Then
                    _CommentsInternal = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property Sum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Sum)
            End Get
        End Property

        Public ReadOnly Property SumVat() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumVat)
            End Get
        End Property

        Public ReadOnly Property SumTotal() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumTotal)
            End Get
        End Property

        Public ReadOnly Property SumLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumLTL)
            End Get
        End Property

        Public ReadOnly Property SumVatLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumVatLTL)
            End Get
        End Property

        Public ReadOnly Property SumTotalLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumTotalLTL)
            End Get
        End Property

        Public ReadOnly Property ReportItems() As AdvanceReportItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ReportItems
            End Get
        End Property

        Public ReadOnly Property ReportItemsSorted() As Csla.SortedBindingList(Of AdvanceReportItem)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _ReportItemsSortedList Is Nothing Then _ReportItemsSortedList = _
                    New Csla.SortedBindingList(Of AdvanceReportItem)(_ReportItems)
                Return _ReportItemsSortedList
            End Get
        End Property


        Public ReadOnly Property IsDirtyEnough() As Boolean _
        Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_DocumentNumber.Trim) _
                    OrElse Not String.IsNullOrEmpty(_Content.Trim) _
                    OrElse _ReportItems.Count > 0)
            End Get
        End Property

        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _ReportItems.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid AndAlso _ReportItems.IsValid
            End Get
        End Property


        Public Function GetAllBrokenRules() As String
            Dim result As String = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error).Trim
            result = AddWithNewLine(result, _ReportItems.GetAllBrokenRules, False)

            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning).Trim
            result = AddWithNewLine(result, _ReportItems.GetAllWarnings(), False)


            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function


        Public Overrides Function Save() As AdvanceReport

            Me.ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " & vbCrLf & Me.GetAllBrokenRules)

            Return MyBase.Save

        End Function


        Public Function GetBookEntryList(ByVal BookEntryListType As BookEntryType) As General.BookEntryList
            Dim result As General.BookEntryList = General.BookEntryList.NewBookEntryList(BookEntryListType)
            Dim FullBookEntryList As BookEntryInternalList = GetFullBookEntryList()
            result.LoadBookEntryListFromInternalList(FullBookEntryList, False)
            Return result
        End Function

        Public Sub AddAdvanceReportItemWithInvoice(ByVal InvoiceToAdd As ActiveReports.InvoiceInfoItem, _
            ByVal InvoicePersonInfo As PersonInfo)

            If Not _ChronologicValidator.FinancialDataCanChange Then Throw New Exception( _
                "Klaida. Koreguoti finansinių duomenų neleidžiama:" & vbCrLf _
                & _ChronologicValidator.FinancialDataCanChangeExplanation)

            Dim NewItem As AdvanceReportItem = AdvanceReportItem.NewAdvanceReportItem( _
                InvoiceToAdd, InvoicePersonInfo, _CurrencyCode, _CurrencyRate)
            _ReportItems.Add(NewItem)

        End Sub

        Private Sub CalculateSubTotals(ByVal RaisePropertChangedEvents As Boolean)

            _SumLTL = 0
            _SumVatLTL = 0
            _Sum = 0
            _SumVat = 0

            For Each i As AdvanceReportItem In _ReportItems
                If i.Expenses Then
                    _SumLTL = CRound(_SumLTL + i.SumLTL)
                    _SumVatLTL = CRound(_SumVatLTL + i.SumVatLTL)
                    _Sum = CRound(_Sum + i.Sum)
                    _SumVat = CRound(_SumVat + i.SumVat)
                Else
                    _SumLTL = CRound(_SumLTL - i.SumLTL)
                    _SumVatLTL = CRound(_SumVatLTL - i.SumVatLTL)
                    _Sum = CRound(_Sum - i.Sum)
                    _SumVat = CRound(_SumVat - i.SumVat)
                End If
            Next

            _SumTotalLTL = CRound(_SumLTL + _SumVatLTL)
            _SumTotal = CRound(_Sum + _SumVat)

            If RaisePropertChangedEvents Then
                PropertyHasChanged("SumLTL")
                PropertyHasChanged("SumVatLTL")
                PropertyHasChanged("Sum")
                PropertyHasChanged("SumVat")
                PropertyHasChanged("SumTotalLTL")
                PropertyHasChanged("SumTotal")
            End If

        End Sub


        Private Sub ReportItems_Changed(ByVal sender As Object, _
            ByVal e As System.ComponentModel.ListChangedEventArgs) Handles _ReportItems.ListChanged

            If SuspendChildListChangedEvents Then Exit Sub

            CalculateSubTotals(True)

        End Sub

        ''' <summary>
        ''' Helper method. Takes care of child lists loosing their handlers.
        ''' </summary>
        Protected Overrides Function GetClone() As Object
            Dim result As AdvanceReport = DirectCast(MyBase.GetClone(), AdvanceReport)
            result.RestoreChildListsHandles()
            Return result
        End Function

        Protected Overrides Sub OnDeserialized(ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.OnDeserialized(context)
            RestoreChildListsHandles()
        End Sub

        Protected Overrides Sub UndoChangesComplete()
            MyBase.UndoChangesComplete()
            RestoreChildListsHandles()
        End Sub

        ''' <summary>
        ''' Helper method. Takes care of ReportItems loosing its handler. See GetClone method.
        ''' </summary>
        Friend Sub RestoreChildListsHandles()
            Try
                RemoveHandler _ReportItems.ListChanged, AddressOf ReportItems_Changed
            Catch ex As Exception
            End Try
            AddHandler _ReportItems.ListChanged, AddressOf ReportItems_Changed
        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            If Not _ID > 0 Then Return ""
            Return _Content
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("DocumentNumber", "apyskaitos numeris"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Content", "apyskaitos turinys (trumpas aprašas)"))
            ValidationRules.AddRule(AddressOf CommonValidation.InfoObjectRequired, _
                New CommonValidation.InfoObjectRequiredRuleArgs("Person", "atskaitingas asmuo", ""))
            ValidationRules.AddRule(AddressOf CommonValidation.CurrencyValid, _
                New CommonValidation.SimpleRuleArgs("CurrencyCode", "valiuta"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("CurrencyRate", "valiutos kursas"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("Sum", "apyskaitos suma"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("Account", "atskaitingo asmens koresponduojanti sąskaita"))

            ValidationRules.AddRule(AddressOf DateValidation, New Validation.RuleArgs("Date"))

            ValidationRules.AddDependantProperty("Sum", "Date", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property Date is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DateValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As AdvanceReport = DirectCast(target, AdvanceReport)

            If Not ValObj.ChronologicValidator.ValidateOperationDate(ValObj._Date, e.Description, e.Severity) Then
                Return False
            ElseIf ValObj._Date.Date < ValObj._ReportItems.GetMaxDate.Date Then
                e.Description = "Data negali būti ankstesnė nei vėliausia visų eilučių data."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Documents.AdvanceReport2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.AdvanceReport1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.AdvanceReport2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.AdvanceReport3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.AdvanceReport3")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function NewAdvanceReport() As AdvanceReport

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")

            Dim result As New AdvanceReport
            result._ReportItems = AdvanceReportItemList.NewAdvanceReportItemList
            result._ChronologicValidator = SimpleChronologicValidator.NewSimpleChronologicValidator("avanso apyskaita")
            result.ValidationRules.CheckRules()
            Return result

        End Function

        Public Shared Function GetAdvanceReport(ByVal nID As Integer) As AdvanceReport
            Return DataPortal.Fetch(Of AdvanceReport)(New Criteria(nID))
        End Function

        Public Shared Sub DeleteAdvanceReport(ByVal id As Integer)
            DataPortal.Delete(New Criteria(id))
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
                "Klaida. Jūsų teisių nepakanka duomenims gauti.")

            Dim myComm As New SQLCommand("FetchAdvanceReport")
            myComm.AddParam("?CD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Throw New Exception( _
                    "Klaida. Objektas, kurio ID='" & criteria.ID & "', nerastas.)")

                Dim dr As DataRow = myData.Rows(0)

                _ID = criteria.ID
                _Date = CDateSafe(dr.Item(0), Today)
                _OldDate = _Date
                _DocumentNumber = CStrSafe(dr.Item(1)).Trim
                _Content = CStrSafe(dr.Item(2)).Trim
                _CurrencyCode = CStrSafe(dr.Item(3)).Trim
                _CurrencyRate = CDblSafe(dr.Item(4), 6, 0)
                _Account = CLongSafe(dr.Item(5), 0)
                _Comments = CStrSafe(dr.Item(6)).Trim
                _CommentsInternal = CStrSafe(dr.Item(7)).Trim
                ' DocumentState = CStrSafe(dr.Item(8))
                _InsertDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(9), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime
                _UpdateDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(10), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime
                _Person = PersonInfo.GetPersonInfo(dr, 11)

            End Using

            _ChronologicValidator = SimpleChronologicValidator.GetSimpleChronologicValidator( _
                _ID, _Date, "avanso apyskaita")

            myComm = New SQLCommand("FetchAdvanceReportItemList")
            myComm.AddParam("?CD", criteria.ID)

            Using myData As DataTable = myComm.Fetch
                _ReportItems = AdvanceReportItemList.GetAdvanceReportItemList(myData, _
                    _CurrencyRate, _CurrencyCode, _ChronologicValidator.FinancialDataCanChange)
            End Using

            CalculateSubTotals(False)

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")

            Dim JE As General.JournalEntry = GetJournalEntry()

            DatabaseAccess.TransactionBegin()

            JE = JE.SaveServerSide()

            _ID = JE.ID
            _InsertDate = JE.InsertDate
            _UpdateDate = JE.UpdateDate

            Dim myComm As New SQLCommand("InsertAdvanceReport")
            AddWithParamsGeneral(myComm)
            AddWithParamsFinancial(myComm)

            myComm.Execute()

            ReportItems.Update(Me)

            DatabaseAccess.TransactionCommit()

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims pakeisti.")

            _ChronologicValidator = SimpleChronologicValidator.GetSimpleChronologicValidator( _
                _ID, _ChronologicValidator.CurrentOperationDate, "avanso apyskaita")
            ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Dokumente yra klaidų:" & vbCrLf _
                & GetAllBrokenRules())

            Dim JE As General.JournalEntry = GetJournalEntry()

            Dim myComm As SQLCommand
            If _ChronologicValidator.FinancialDataCanChange Then
                myComm = New SQLCommand("UpdateAdvanceReport")
                AddWithParamsFinancial(myComm)
            Else
                myComm = New SQLCommand("UpdateAdvanceReportNonFinancial")
            End If
            AddWithParamsGeneral(myComm)

            DatabaseAccess.TransactionBegin()

            JE = JE.SaveServerSide()

            _UpdateDate = JE.UpdateDate

            myComm.Execute()

            ReportItems.Update(Me)

            DatabaseAccess.TransactionCommit()

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims pašalinti.")

            IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted(DirectCast(criteria, Criteria).ID, _
                DocumentType.AdvanceReport)

            Dim myComm As New SQLCommand("DeleteAdvanceReport")
            myComm.AddParam("?CD", DirectCast(criteria, Criteria).ID)

            DatabaseAccess.TransactionBegin()

            General.JournalEntry.DoDelete(DirectCast(criteria, Criteria).ID)

            myComm.Execute()

            myComm = New SQLCommand("DeleteAllAdvanceReportItems")
            myComm.AddParam("?CD", DirectCast(criteria, Criteria).ID)
            myComm.Execute()

            DatabaseAccess.TransactionCommit()

            MarkNew()

        End Sub


        Private Sub AddWithParamsGeneral(ByRef myComm As SQLCommand)
            myComm.AddParam("?AA", _ID)
            myComm.AddParam("?AE", _Comments.Trim)
            myComm.AddParam("?AF", _CommentsInternal.Trim)
            myComm.AddParam("?AG", "") ' DocumentState
        End Sub

        Private Sub AddWithParamsFinancial(ByRef myComm As SQLCommand)
            myComm.AddParam("?AB", _CurrencyCode.Trim)
            myComm.AddParam("?AC", CRound(_CurrencyRate, 6))
            myComm.AddParam("?AD", _Account)
        End Sub

        Private Function GetJournalEntry() As General.JournalEntry

            Dim result As General.JournalEntry
            If IsNew Then
                result = General.JournalEntry.NewJournalEntryChild(DocumentType.AdvanceReport)
            Else
                result = General.JournalEntry.GetJournalEntryChild(_ID, DocumentType.AdvanceReport)
                If result.UpdateDate <> _UpdateDate Then Throw New Exception( _
                    "Klaida. Dokumento atnaujinimo data pasikeitė. Teigtina, kad kitas " _
                    & "vartotojas redagavo šį objektą.")
            End If

            result.Content = _Content
            result.Date = _Date
            result.DocNumber = _DocumentNumber
            result.Person = _Person

            If _ChronologicValidator.FinancialDataCanChange Then

                Dim FullBookEntryList As BookEntryInternalList = GetFullBookEntryList()

                result.DebetList.Clear()
                result.CreditList.Clear()

                result.DebetList.LoadBookEntryListFromInternalList(FullBookEntryList, False)
                result.CreditList.LoadBookEntryListFromInternalList(FullBookEntryList, False)

            End If

            If Not result.IsValid Then Throw New Exception("Klaida. Nepavyko generuoti " _
                & "bendrojo žurnalo įrašo:" & result.ToString & vbCrLf & result.GetAllBrokenRules)

            Return result

        End Function

        Private Function GetFullBookEntryList() As BookEntryInternalList

            Dim FullBookEntryList As BookEntryInternalList = BookEntryInternalList. _
                NewBookEntryInternalList(BookEntryType.Debetas)

            For Each i As AdvanceReportItem In _ReportItems

                If i.Income AndAlso i.InvoiceID > 0 Then

                    FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, i.Account, i.SumLTL, i.Person))
                    FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Debetas, _Account, i.SumLTL, Nothing))

                ElseIf i.Income Then

                    FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, i.Account, i.SumLTL, i.Person))
                    If i.VatRate > 0 Then
                        FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Kreditas, i.AccountVat, i.SumVatLTL, i.Person))
                    End If
                    FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Debetas, _Account, i.SumTotalLTL, Nothing))

                ElseIf i.Expenses AndAlso i.InvoiceID > 0 Then

                    FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Debetas, i.Account, i.SumLTL, i.Person))
                    FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, _Account, i.SumLTL, Nothing))

                Else

                    FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Debetas, i.Account, i.SumLTL, i.Person))
                    If i.VatRate > 0 Then
                        FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Debetas, i.AccountVat, i.SumVatLTL, i.Person))
                    End If
                    FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, _Account, i.SumTotalLTL, Nothing))

                End If

                If i.CurrencyRateChangeEffect > 0 Then
                    FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Debetas, i.Account, i.CurrencyRateChangeEffect, i.Person))
                    FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, i.AccountCurrencyRateChangeEffect, _
                        i.CurrencyRateChangeEffect, Nothing))

                ElseIf i.CurrencyRateChangeEffect < 0 Then
                    FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, i.Account, -i.CurrencyRateChangeEffect, i.Person))
                    FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Debetas, i.AccountCurrencyRateChangeEffect, _
                        -i.CurrencyRateChangeEffect, Nothing))

                End If

            Next

            FullBookEntryList.Aggregate()

            Return FullBookEntryList

        End Function

#End Region

    End Class

End Namespace