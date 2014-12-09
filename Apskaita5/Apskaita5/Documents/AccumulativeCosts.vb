Namespace Documents

    <Serializable()> _
    Public Class AccumulativeCosts
        Inherits BusinessBase(Of AccumulativeCosts)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _Date As Date = Today
        Private _DocumentNumber As String = "Buh. Paž."
        Private _Content As String = "Sukauptos sąnaudos"
        Private _AccountCosts As Long = 0
        Private _AccountAccumulatedCosts As Long = 0
        Private _AccountDistributedCosts As Long = 0
        Private _Comments As String = ""
        Private _ChronologyValidator As AccumulativeCostsChronologicValidator
        Private _Sum As Double = 0
        Private _IsAccumulatedIncome As Boolean = False
        Private _IsAccumulatedIncomeOld As Boolean = False
        Private WithEvents _Items As AccumulativeCostsItemList
        Private _SumDistributed As Double = 0
        Private _InsertDate As DateTime
        Private _UpdateDate As DateTime

        Private SuspendChildListChangedEvents As Boolean = False
        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _ItemsSortedList As Csla.SortedBindingList(Of AccumulativeCostsItem) = Nothing

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

        Public ReadOnly Property ChronologyValidator() As IChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ChronologyValidator
            End Get
        End Property

        Public ReadOnly Property AccountCostsIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologyValidator Is Nothing AndAlso _
                    Not _ChronologyValidator.ParentFinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property AccountAccumulatedCostsIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologyValidator Is Nothing AndAlso _
                    (Not _ChronologyValidator.FinancialDataCanChange OrElse _
                    Not _ChronologyValidator.ParentFinancialDataCanChange)
            End Get
        End Property

        Public ReadOnly Property AccountDistributedCostsIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologyValidator Is Nothing AndAlso _
                    Not _ChronologyValidator.FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property SumIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologyValidator Is Nothing AndAlso _
                    Not _ChronologyValidator.ParentFinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property IsAccumulatedIncomeIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologyValidator Is Nothing AndAlso _
                    (Not _ChronologyValidator.FinancialDataCanChange OrElse _
                    Not _ChronologyValidator.ParentFinancialDataCanChange)
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

        Public Property AccountCosts() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountCosts
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _AccountCosts <> value Then
                    _AccountCosts = value
                    PropertyHasChanged()
                    If Not _AccountDistributedCosts > 0 Then
                        _AccountDistributedCosts = value
                        PropertyHasChanged("AccountDistributedCosts")
                    End If
                End If
            End Set
        End Property

        Public Property AccountAccumulatedCosts() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountAccumulatedCosts
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _AccountAccumulatedCosts <> value Then
                    _AccountAccumulatedCosts = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property AccountDistributedCosts() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountDistributedCosts
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _AccountDistributedCosts <> value Then
                    _AccountDistributedCosts = value
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
                If _Comments.Trim <> value.Trim Then
                    _Comments = value.Trim
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
                If CRound(_Sum) <> CRound(value) Then
                    _Sum = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property IsAccumulatedIncome() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsAccumulatedIncome
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If IsAccumulatedIncomeIsReadOnly Then Exit Property
                If _IsAccumulatedIncome <> value Then
                    _IsAccumulatedIncome = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property IsAccumulatedIncomeOld() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsAccumulatedIncomeOld
            End Get
        End Property

        Public ReadOnly Property Items() As AccumulativeCostsItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Items
            End Get
        End Property

        Public ReadOnly Property ItemsSorted() As Csla.SortedBindingList(Of AccumulativeCostsItem)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _Items Is Nothing Then Return Nothing
                If _ItemsSortedList Is Nothing Then _ItemsSortedList = _
                    New Csla.SortedBindingList(Of AccumulativeCostsItem)(_Items)
                Return _ItemsSortedList
            End Get
        End Property

        Public ReadOnly Property SumDistributed() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumDistributed)
            End Get
        End Property

        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_DocumentNumber.Trim) _
                    OrElse Not String.IsNullOrEmpty(_Content.Trim) _
                    OrElse Not String.IsNullOrEmpty(_Comments.Trim) _
                    OrElse _Items.Count > 0)
            End Get
        End Property



        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _Items.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid AndAlso _Items.IsValid
            End Get
        End Property



        Public Overrides Function Save() As AccumulativeCosts

            Me.ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " & vbCrLf & Me.GetAllBrokenRules)

            Return MyBase.Save

        End Function



        Private Sub Items_Changed(ByVal sender As Object, _
            ByVal e As System.ComponentModel.ListChangedEventArgs) Handles _Items.ListChanged
            If SuspendChildListChangedEvents Then Exit Sub
            CalculateTotal(True)
        End Sub

        ''' <summary>
        ''' Helper method. Takes care of child lists loosing their handlers.
        ''' </summary>
        Protected Overrides Function GetClone() As Object
            Dim result As AccumulativeCosts = DirectCast(MyBase.GetClone(), AccumulativeCosts)
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
        ''' Helper method. Takes care of TaskTimeSpans loosing its handler. See GetClone method.
        ''' </summary>
        Friend Sub RestoreChildListsHandles()
            Try
                RemoveHandler _Items.ListChanged, AddressOf Items_Changed
            Catch ex As Exception
            End Try
            AddHandler _Items.ListChanged, AddressOf Items_Changed
        End Sub


        Public Function GetAllBrokenRules() As String
            Dim result As String = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error).Trim
            result = AddWithNewLine(result, _Items.GetAllBrokenRules, False)

            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning).Trim
            result = AddWithNewLine(result, _Items.GetAllWarnings(), False)


            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function


        Public Sub Distribute()
            If _Items Is Nothing Then Exit Sub
            _Items.Distribute(_Sum)
        End Sub

        Public Sub Distribute(ByVal StartingDate As Date, ByVal PeriodLength As Integer, _
            ByVal PeriodCount As Integer)
            If _Items Is Nothing Then Exit Sub
            _Items.Distribute(_Sum, StartingDate, PeriodLength, PeriodCount)
        End Sub


        Private Sub CalculateTotal(ByVal RaisePropertyHasChanged As Boolean)

            If _Items Is Nothing Then Exit Sub

            _SumDistributed = 0

            For Each a As AccumulativeCostsItem In _Items
                _SumDistributed = CRound(_SumDistributed + a.Sum)
            Next

            If RaisePropertyHasChanged Then PropertyHasChanged("SumDistributed")

        End Sub

        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return _Content
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("DocumentNumber", "dokumento numeris"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Content", "operacijos turinys"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("AccountCosts", "sąnaudų sąskaita"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("AccountAccumulatedCosts", "sukauptų sąnaudų sąskaita"))

            ValidationRules.AddRule(AddressOf DateValidation, New Validation.RuleArgs("Date"))
            ValidationRules.AddRule(AddressOf SumValidation, New Validation.RuleArgs("Sum"))
            ValidationRules.AddRule(AddressOf AccountDistributedCostsValidation, _
                New Validation.RuleArgs("AccountDistributedCosts"))

            ValidationRules.AddDependantProperty("SumDistributed", "Sum", False)
            ValidationRules.AddDependantProperty("SumDistributed", "Date", False)
            ValidationRules.AddDependantProperty("AccountCosts", "AccountDistributedCosts", False)

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

            Dim ValObj As AccumulativeCosts = DirectCast(target, AccumulativeCosts)

            If Not ValObj._ChronologyValidator.ValidateOperationDate(ValObj._Date, e.Description, e.Severity) Then
                Return False
            ElseIf ValObj._Items.Count > 0 AndAlso ValObj._Items.GetMinDate.Date < ValObj._Date.Date Then
                e.Description = "Sąnaudos skirstomos anksčiau nei buvo sukauptos (" _
                    & ValObj._Items.GetMinDate.ToString("yyyy-MM-dd") & ")."
                e.Severity = Validation.RuleSeverity.Warning
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property Sum is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As AccumulativeCosts = DirectCast(target, AccumulativeCosts)

            If Not ValObj.Sum > 0 Then
                e.Description = "Nenurodyta sukauptų nuostolių suma."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf ValObj.Sum <> ValObj.SumDistributed Then
                e.Description = "Nesutampa sukauptų ir paskirstytų nuostolių suma."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property AccountDistributedCosts is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountDistributedCostsValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As AccumulativeCosts = DirectCast(target, AccumulativeCosts)

            If Not ValObj._AccountDistributedCosts > 0 Then
                e.Description = "Nenurodyta nuostolių skirstymo sąskaita."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf ValObj._AccountDistributedCosts <> ValObj._AccountCosts Then
                e.Description = "Nesutampa nuostolių ir jų skirstymo sąskaitos."
                e.Severity = Validation.RuleSeverity.Warning
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("General.AccumulativeCosts2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.AccumulativeCosts1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.AccumulativeCosts2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.AccumulativeCosts3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.AccumulativeCosts3")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function NewAccumulativeCosts() As AccumulativeCosts
            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")
            Dim result As New AccumulativeCosts
            result._Items = AccumulativeCostsItemList.NewAccumulativeCostsItemList
            result._ChronologyValidator = AccumulativeCostsChronologicValidator. _
                NewAccumulativeCostsChronologicValidator()
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Public Shared Function GetAccumulativeCosts(ByVal nID As Integer) As AccumulativeCosts
            Return DataPortal.Fetch(Of AccumulativeCosts)(New Criteria(nID))
        End Function

        Public Shared Sub DeleteAccumulativeCosts(ByVal id As Integer)
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
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            Dim myComm As New SQLCommand("FetchAccumulativeCosts")
            myComm.AddParam("?PD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Throw New Exception("Klaida. Objektas, kurio ID='" _
                    & criteria.ID & "', nerastas.)")

                Dim dr As DataRow = myData.Rows(0)

                _ID = CIntSafe(dr.Item(0), 0)
                _Date = CDateSafe(dr.Item(1), Today)
                _DocumentNumber = CStrSafe(dr.Item(2)).Trim
                _Content = CStrSafe(dr.Item(3)).Trim
                _Comments = CStrSafe(dr.Item(4)).Trim
                _Sum = CDblSafe(dr.Item(5), 2, 0)
                If CRound(_Sum) < 0 Then
                    _IsAccumulatedIncome = True
                    _Sum = CRound(-_Sum)
                Else
                    _IsAccumulatedIncome = False
                End If
                _IsAccumulatedIncomeOld = _IsAccumulatedIncome
                _AccountCosts = CLongSafe(dr.Item(6), 0)
                _AccountAccumulatedCosts = CLongSafe(dr.Item(7), 0)
                _AccountDistributedCosts = CLongSafe(dr.Item(8), 0)
                _InsertDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(9), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime
                _UpdateDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(10), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime

            End Using

            _Items = AccumulativeCostsItemList.GetAccumulativeCostsItemList(_ID)

            CalculateTotal(False)

            _ChronologyValidator = AccumulativeCostsChronologicValidator. _
                GetAccumulativeCostsChronologicValidator(_ID)

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")

            _Items.CheckIfCanUpdate(Me)

            Dim entry As General.JournalEntry = GetJournalEntry()

            DatabaseAccess.TransactionBegin()

            entry = entry.SaveServerSide

            _InsertDate = entry.InsertDate
            _UpdateDate = entry.UpdateDate

            _ID = entry.ID

            Dim myComm As New SQLCommand("InsertAccumulativeCosts")
            AddWithParams(myComm)
            myComm.AddParam("?BD", _ID)

            myComm.Execute()

            Items.Update(Me)

            DatabaseAccess.TransactionCommit()

            _IsAccumulatedIncomeOld = _IsAccumulatedIncome

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims pakeisti.")

            _Items.CheckIfCanUpdate(Me)

            Dim entry As General.JournalEntry = GetJournalEntry()

            Dim myComm As SQLCommand

            If _ChronologyValidator.FinancialDataCanChange AndAlso _
                _ChronologyValidator.ParentFinancialDataCanChange Then
                myComm = New SQLCommand("UpdateAccumulativeCosts1")
            ElseIf Not _ChronologyValidator.ParentFinancialDataCanChange AndAlso _
                _ChronologyValidator.FinancialDataCanChange Then
                myComm = New SQLCommand("UpdateAccumulativeCosts2")
            ElseIf _ChronologyValidator.ParentFinancialDataCanChange AndAlso _
                Not _ChronologyValidator.FinancialDataCanChange Then
                myComm = New SQLCommand("UpdateAccumulativeCosts3")
            Else
                myComm = New SQLCommand("UpdateAccumulativeCosts4")
            End If

            AddWithParams(myComm)
            myComm.AddParam("?CD", _ID)

            DatabaseAccess.TransactionBegin()

            entry = entry.SaveServerSide

            _UpdateDate = entry.UpdateDate

            myComm.Execute()

            Items.Update(Me)

            DatabaseAccess.TransactionCommit()

            If _ChronologyValidator.FinancialDataCanChange AndAlso _
                _ChronologyValidator.ParentFinancialDataCanChange Then _
                _IsAccumulatedIncomeOld = _IsAccumulatedIncome

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims pašalinti.")

            Dim itemToDelete As AccumulativeCosts = New AccumulativeCosts
            itemToDelete.DataPortal_Fetch(New Criteria(DirectCast(criteria, Criteria).ID))

            itemToDelete.CheckIfCanDelete()

            Dim myComm As New SQLCommand("DeleteAccumulativeCosts")
            myComm.AddParam("?CD", itemToDelete.ID)

            DatabaseAccess.TransactionBegin()

            General.JournalEntry.DoDelete(itemToDelete.ID)

            myComm.Execute()

            itemToDelete._Items.Delete(itemToDelete)

            DatabaseAccess.TransactionCommit()

            MarkNew()

        End Sub


        Private Sub CheckIfCanDelete()

            If Not _ChronologyValidator.FinancialDataCanChange Then Throw New Exception( _
                "Klaida. Operacijos pašalinti neleidžiama:" & vbCrLf _
                & _ChronologyValidator.FinancialDataCanChangeExplanation)
            If Not _ChronologyValidator.ParentFinancialDataCanChange Then Throw New Exception( _
                "Klaida. Operacijos pašalinti neleidžiama:" & vbCrLf _
                & _ChronologyValidator.ParentFinancialDataCanChangeExplanation)
            IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted(_ID, DocumentType.AccumulatedCosts)
            _Items.CheckIfCanDelete()

        End Sub

        Private Function GetJournalEntry() As General.JournalEntry

            Dim result As General.JournalEntry
            If IsNew Then
                result = General.JournalEntry.NewJournalEntryChild(DocumentType.AccumulatedCosts)
            Else
                result = General.JournalEntry.GetJournalEntryChild(_ID, DocumentType.AccumulatedCosts)
                If result.UpdateDate <> _UpdateDate Then Throw New Exception( _
                    "Klaida. Dokumento atnaujinimo data pasikeitė. Teigtina, kad kitas " _
                    & "vartotojas redagavo šį objektą.")
            End If

            result.Content = _Content
            result.Date = _Date
            result.DocNumber = _DocumentNumber

            If _ChronologyValidator.ParentFinancialDataCanChange Then

                If result.DebetList.Count <> 1 Then
                    result.DebetList.Clear()
                    result.DebetList.Add(General.BookEntry.NewBookEntry())
                End If

                result.DebetList(0).Amount = CRound(_Sum)

                If result.CreditList.Count <> 1 Then
                    result.CreditList.Clear()
                    result.CreditList.Add(General.BookEntry.NewBookEntry())
                End If

                result.CreditList(0).Amount = CRound(_Sum)

                If ApplicableIsAccumulatedIncome() Then
                    result.CreditList(0).Account = _AccountAccumulatedCosts
                    result.DebetList(0).Account = _AccountCosts
                Else
                    result.CreditList(0).Account = _AccountCosts
                    result.DebetList(0).Account = _AccountAccumulatedCosts
                End If

            End If

            Return result

        End Function

        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AA", _Comments.Trim)
            If _ChronologyValidator.ParentFinancialDataCanChange Then
                If _IsAccumulatedIncome Then
                    myComm.AddParam("?AB", -CRound(_Sum))
                Else
                    myComm.AddParam("?AB", CRound(_Sum))
                End If
                myComm.AddParam("?AC", _AccountCosts)
                If _ChronologyValidator.FinancialDataCanChange Then _
                    myComm.AddParam("?AD", _AccountAccumulatedCosts)
            End If
            If _ChronologyValidator.FinancialDataCanChange Then _
                myComm.AddParam("?AE", _AccountDistributedCosts)

        End Sub

        Friend Function IsAccumulatedIncomeHasChanged() As Boolean
            If IsNew Then Return True
            Return _ChronologyValidator.FinancialDataCanChange AndAlso _
                _ChronologyValidator.ParentFinancialDataCanChange AndAlso _
                _IsAccumulatedIncomeOld <> _IsAccumulatedIncome
        End Function

        Friend Function ApplicableIsAccumulatedIncome() As Boolean
            If IsNew OrElse (_ChronologyValidator.FinancialDataCanChange AndAlso _
                _ChronologyValidator.ParentFinancialDataCanChange) Then Return _IsAccumulatedIncome
            Return _IsAccumulatedIncomeOld
        End Function

#End Region

    End Class

End Namespace