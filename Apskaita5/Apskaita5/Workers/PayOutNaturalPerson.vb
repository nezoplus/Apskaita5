Namespace Workers

    <Serializable()> _
    Public Class PayOutNaturalPerson
        Inherits BusinessBase(Of PayOutNaturalPerson)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _JournalEntryID As Integer = 0
        Private _Date As Date = Today
        Private _Content As String = ""
        Private _DocNumber As String = ""
        Private _PersonInfo As String = ""
        Private _PersonCodeSODRA As String = ""
        Private _SumNeto As Double = 0
        Private _SumBruto As Double = 0
        Private _RateGPM As Double = 0
        Private _RatePSDForPerson As Double = 0
        Private _RatePSDForCompany As Double = 0
        Private _SODRABase As Integer = 100
        Private _RateSODRAForPerson As Double = 0
        Private _RateSODRAForCompany As Double = 0
        Private _CodeVMI As Integer = 0
        Private _CodeSODRA As Integer = 0
        Private _DeductionGPM As Double = 0
        Private _DeductionPSD As Double = 0
        Private _DeductionSODRA As Double = 0
        Private _ContributionPSD As Double = 0
        Private _ContributionSODRA As Double = 0
        Private _TotalPSD As Double = 0
        Private _TotalSODRA As Double = 0
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now


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

        Public ReadOnly Property JournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryID
            End Get
        End Property

        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        Public ReadOnly Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
        End Property

        Public ReadOnly Property DocNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocNumber.Trim
            End Get
        End Property

        Public ReadOnly Property PersonInfo() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonInfo.Trim
            End Get
        End Property

        Public Property PersonCodeSODRA() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonCodeSODRA.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _PersonCodeSODRA.Trim <> value.Trim Then
                    _PersonCodeSODRA = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property SumNeto() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumNeto)
            End Get
        End Property

        Public Property SumBruto() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumBruto)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_SumBruto) <> CRound(value) Then
                    _SumBruto = CRound(value)
                    PropertyHasChanged()
                    RecalculateAllTaxes(True)
                End If
            End Set
        End Property

        Public Property RateGPM() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateGPM)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_RateGPM) <> CRound(value) Then
                    _RateGPM = CRound(value)
                    PropertyHasChanged()
                    RecalculateSumBruto(True)
                End If
            End Set
        End Property

        Public Property RatePSDForPerson() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RatePSDForPerson)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_RatePSDForPerson) <> CRound(value) Then
                    _RatePSDForPerson = CRound(value)
                    PropertyHasChanged()
                    RecalculateSumBruto(True)
                End If
            End Set
        End Property

        Public Property RatePSDForCompany() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RatePSDForCompany)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_RatePSDForCompany) <> CRound(value) Then
                    _RatePSDForCompany = CRound(value)
                    PropertyHasChanged()
                    _ContributionPSD = CRound(_SumBruto * _SODRABase * _RatePSDForCompany / 100 / 100)
                    _TotalPSD = CRound(_DeductionPSD + _ContributionPSD)
                    PropertyHasChanged("ContributionPSD")
                    PropertyHasChanged("TotalPSD")
                End If
            End Set
        End Property

        Public Property SODRABase() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SODRABase
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If _SODRABase <> value Then
                    _SODRABase = value
                    PropertyHasChanged()
                    RecalculateSumBruto(True)
                End If
            End Set
        End Property

        Public Property RateSODRAForPerson() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateSODRAForPerson)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_RateSODRAForPerson) <> CRound(value) Then
                    _RateSODRAForPerson = CRound(value)
                    PropertyHasChanged()
                    RecalculateSumBruto(True)
                End If
            End Set
        End Property

        Public Property RateSODRAForCompany() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateSODRAForCompany)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_RateSODRAForCompany) <> CRound(value) Then
                    _RateSODRAForCompany = CRound(value)
                    PropertyHasChanged()
                    _ContributionSODRA = CRound(_SumBruto * _SODRABase * _RateSODRAForCompany / 100 / 100)
                    _TotalSODRA = CRound(_DeductionSODRA + _ContributionSODRA)
                    PropertyHasChanged("ContributionSODRA")
                    PropertyHasChanged("TotalSODRA")
                End If
            End Set
        End Property

        Public Property CodeVMI() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CodeVMI
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If _CodeVMI <> value Then
                    _CodeVMI = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property CodeSODRA() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CodeSODRA
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If _CodeSODRA <> value Then
                    _CodeSODRA = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property DeductionGPM() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionGPM)
            End Get
        End Property

        Public ReadOnly Property DeductionPSD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionPSD)
            End Get
        End Property

        Public ReadOnly Property DeductionSODRA() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionSODRA)
            End Get
        End Property

        Public ReadOnly Property ContributionPSD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ContributionPSD)
            End Get
        End Property

        Public ReadOnly Property ContributionSODRA() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ContributionSODRA)
            End Get
        End Property

        Public ReadOnly Property TotalPSD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalPSD)
            End Get
        End Property

        Public ReadOnly Property TotalSODRA() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalSODRA)
            End Get
        End Property

        Public ReadOnly Property IsDirtyEnough() As Boolean _
        Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_PersonCodeSODRA.Trim))
            End Get
        End Property



        Public Overrides Function Save() As PayOutNaturalPerson

            Me.ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " & vbCrLf & Me.GetAllBrokenRules)

            Return MyBase.Save

        End Function

        Public Function GetAllBrokenRules() As String
            Dim result As String = ""
            If Not MyBase.IsValid Then result = AddWithNewLine(result, _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error), False)
            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = ""
            If Not MyBase.BrokenRulesCollection.WarningCount > 0 Then result = AddWithNewLine(result, _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning), False)
            Return result
        End Function

        Private Sub RecalculateAllTaxes(ByVal RaisePropertyHasChanged As Boolean)

            _DeductionGPM = CRound(_SumBruto * _RateGPM / 100)
            _DeductionPSD = CRound(_SumBruto * _SODRABase * _RatePSDForPerson / 100 / 100)
            _DeductionSODRA = CRound(_SumBruto * _SODRABase * _RateSODRAForPerson / 100 / 100)
            _ContributionPSD = CRound(_SumBruto * _SODRABase * _RatePSDForCompany / 100 / 100)
            _ContributionSODRA = CRound(_SumBruto * _SODRABase * _RateSODRAForCompany / 100 / 100)
            _TotalPSD = CRound(_DeductionPSD + _ContributionPSD)
            _TotalSODRA = CRound(_DeductionSODRA + _ContributionSODRA)

            If RaisePropertyHasChanged Then
                PropertyHasChanged("DeductionGPM")
                PropertyHasChanged("DeductionPSD")
                PropertyHasChanged("DeductionSODRA")
                PropertyHasChanged("ContributionPSD")
                PropertyHasChanged("ContributionSODRA")
                PropertyHasChanged("TotalPSD")
                PropertyHasChanged("TotalSODRA")
            End If

        End Sub

        Private Sub RecalculateSumBruto(ByVal RaisePropertyHasChanged As Boolean)
            _SumBruto = CRound(_SumNeto * 100 / CRound(100 - _RateGPM - _
                CRound(_RatePSDForPerson * _SODRABase / 100) - _
                CRound(_RateSODRAForPerson * _SODRABase / 100)))
            RecalculateAllTaxes(RaisePropertyHasChanged)
            If RaisePropertyHasChanged Then PropertyHasChanged("SumBruto")
        End Sub

        Public Sub LoadAssociatedJournalEntry(ByVal Entry As ActiveReports.JournalEntryInfo)

            If Entry Is Nothing OrElse Not Entry.ID > 0 Then Exit Sub

            If Not IsNew Then Throw New Exception("Klaida. Susieta bendrojo žurnalo operacija " & _
                "gali būti nustatoma tik naujai išmokai.")

            _JournalEntryID = Entry.ID
            _Date = Entry.Date.Date
            _Content = Entry.Content
            _DocNumber = Entry.DocNumber
            _PersonInfo = Entry.Person
            _PersonCodeSODRA = Entry.PersonCodeSODRA.Trim
            _SumNeto = Entry.Ammount

            PropertyHasChanged("JournalEntryID")
            PropertyHasChanged("Date")
            PropertyHasChanged("Content")
            PropertyHasChanged("DocNumber")
            PropertyHasChanged("PersonInfo")
            PropertyHasChanged("PersonCodeSODRA")
            PropertyHasChanged("SumNeto")

            RecalculateSumBruto(True)

        End Sub

        Public Function GetNewJournalEntry() As General.JournalEntry

            Dim result As General.JournalEntry = General.JournalEntry.NewJournalEntry

            result.Content = "Išmoka fiziniam asmeniui"
            result.Date = Today
            result.DocNumber = "P-P Aktas"
            result.Person = Nothing

            Dim CostsEntry As General.BookEntry = General.BookEntry.NewBookEntry
            CostsEntry.Amount = CRound(_SumBruto + _ContributionPSD + _ContributionSODRA)

            result.DebetList.Add(CostsEntry)

            Dim cc As Settings.CompanyInfo = GetCurrentCompany()

            Dim NetoEntry As General.BookEntry = General.BookEntry.NewBookEntry
            NetoEntry.Account = cc.GetDefaultAccount(General.DefaultAccountType.Suppliers)
            NetoEntry.Amount = CRound(_SumBruto - _DeductionPSD - _DeductionSODRA - _DeductionGPM)

            result.CreditList.Add(NetoEntry)

            Dim GpmEntry As General.BookEntry = General.BookEntry.NewBookEntry
            GpmEntry.Account = cc.GetDefaultAccount(General.DefaultAccountType.OtherGpmPayable)
            GpmEntry.Amount = CRound(_DeductionGPM)

            result.CreditList.Add(GpmEntry)

            Dim SodraEntry As General.BookEntry = General.BookEntry.NewBookEntry
            SodraEntry.Account = cc.GetDefaultAccount(General.DefaultAccountType.OtherSodraPayable)
            SodraEntry.Amount = CRound(_TotalSODRA)

            result.CreditList.Add(SodraEntry)

            Dim PsdEntry As General.BookEntry = General.BookEntry.NewBookEntry
            PsdEntry.Account = cc.GetDefaultAccount(General.DefaultAccountType.OtherPsdPayable)
            PsdEntry.Amount = CRound(_TotalPSD)

            result.CreditList.Add(PsdEntry)

            Return result

        End Function


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

            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("SumNeto", _
                "išmokos suma neto (neįkrauta susieta bendrojo žurnalo operacija)"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("SumBruto", "išmokos suma bruto"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("CodeVMI", "išmokos kodas VMI deklaracijoms"))

            ValidationRules.AddRule(AddressOf PersonSODRACodeValidation, "PersonCodeSODRA")

            ValidationRules.AddDependantProperty("CodeSODRA", "PersonCodeSODRA", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring persons SODRA code is entered if payout code for SODRA is set.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function PersonSODRACodeValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As PayOutNaturalPerson = DirectCast(target, PayOutNaturalPerson)

            If ValObj._CodeSODRA > 0 AndAlso String.IsNullOrEmpty(ValObj._PersonCodeSODRA.Trim) Then
                e.Description = "Nenurodytas asmens socialinio draudimo kodas."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Workers.PayOutNaturalPerson2")
        End Sub

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.PayOutNaturalPerson2")
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.PayOutNaturalPerson1")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.PayOutNaturalPerson3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.PayOutNaturalPerson3")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function NewPayOutNaturalPerson() As PayOutNaturalPerson

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")

            Dim result As New PayOutNaturalPerson
            result.ValidationRules.CheckRules()
            Return result

        End Function

        Public Shared Function GetPayOutNaturalPerson(ByVal nID As Integer) As PayOutNaturalPerson

            Return DataPortal.Fetch(Of PayOutNaturalPerson)(New Criteria(nID))

        End Function

        Public Shared Sub DeletePayOutNaturalPerson(ByVal id As Integer)

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

            Dim myComm As New SQLCommand("FetchPayOutNaturalPerson")
            myComm.AddParam("?ND", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Throw New Exception("Klaida. Objektas, kurio ID='" & criteria.ID & "', nerastas.)")

                Dim dr As DataRow = myData.Rows(0)

                _ID = CIntSafe(dr.item(0), 0)
                _JournalEntryID = CIntSafe(dr.Item(1), 0)
                _Date = CDateSafe(dr.Item(2), Today)
                _DocNumber = CStrSafe(dr.Item(3)).Trim
                _Content = CStrSafe(dr.Item(4)).Trim
                _PersonInfo = CStrSafe(dr.Item(5)).Trim & " (" & CStrSafe(dr.Item(6)).Trim & ")"
                _PersonCodeSODRA = CStrSafe(dr.Item(7)).Trim
                _SumNeto = CDblSafe(dr.Item(8), 2, 0)
                _RateGPM = CDblSafe(dr.Item(9), 2, 0)
                _RatePSDForPerson = CDblSafe(dr.Item(10), 2, 0)
                _RatePSDForCompany = CDblSafe(dr.Item(11), 2, 0)
                _RateSODRAForPerson = CDblSafe(dr.Item(12), 2, 0)
                _RateSODRAForCompany = CDblSafe(dr.Item(13), 2, 0)
                _SumBruto = CDblSafe(dr.Item(14), 2, 0)
                _CodeVMI = CIntSafe(dr.Item(15), 0)
                _CodeSODRA = CIntSafe(dr.Item(16), 0)
                _SODRABase = 100 - CIntSafe(dr.Item(17), 0)
                _InsertDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(18), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime
                _UpdateDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(19), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime

                ' To support old version
                If Not CRound(_SumBruto) > 0 Then _SumBruto = CRound(100 * _SumNeto / (100 - _RateGPM))

                RecalculateAllTaxes(False)

            End Using

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")

            Dim myComm As New SQLCommand("InsertPayOutNaturalPerson")
            myComm.AddParam("?BD", _JournalEntryID)
            myComm.AddParam("?SN", CRound(_SumNeto))
            AddWithParams(myComm)

            myComm.Execute()

            _ID = myComm.LastInsertID

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims pakeisti.")

            CheckIfUpdateDateChanged()

            Dim myComm As New SQLCommand("UpdatePayOutNaturalPerson")
            myComm.AddParam("?PD", _ID)
            AddWithParams(myComm)

            myComm.Execute()

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims pašalinti.")

            Dim myComm As New SQLCommand("DeletePayOutNaturalPerson")
            myComm.AddParam("?PD", criteria.Id)

            myComm.Execute()

            MarkNew()

        End Sub


        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?TG", CRound(_RateGPM))
            myComm.AddParam("?CV", _CodeVMI)
            myComm.AddParam("?SB", CRound(_SumBruto))
            myComm.AddParam("?TPW", CRound(_RatePSDForPerson))
            myComm.AddParam("?TPE", CRound(_RatePSDForCompany))
            myComm.AddParam("?TSW", CRound(_RateSODRAForPerson))
            myComm.AddParam("?TSE", CRound(_RateSODRAForCompany))
            myComm.AddParam("?CS", _CodeSODRA)
            myComm.AddParam("?PS", _PersonCodeSODRA.Trim)
            myComm.AddParam("?BS", 100 - _SODRABase)

            _UpdateDate = DateTime.Now
            _UpdateDate = New DateTime(Math.Floor(_UpdateDate.Ticks / TimeSpan.TicksPerSecond) _
                * TimeSpan.TicksPerSecond)
            If Me.IsNew Then _InsertDate = _UpdateDate
            myComm.AddParam("?UD", _UpdateDate.ToUniversalTime)

        End Sub


        Private Sub CheckIfUpdateDateChanged()

            Dim myComm As New SQLCommand("CheckIfPayOutNaturalPersonUpdateDateChanged")
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