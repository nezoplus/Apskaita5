Namespace Goods

    <Serializable()> _
Public Class GoodsOperationAcquisition
        Inherits BusinessBase(Of GoodsOperationAcquisition)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _GoodsInfo As GoodsSummary = Nothing
        Private _OperationLimitations As OperationalLimitList = Nothing
        Private _ComplexOperationID As Integer = 0
        Private _ComplexOperationType As GoodsComplexOperationType = GoodsComplexOperationType.InternalTransfer
        Private _ComplexOperationHumanReadable As String = ""
        Private _OldDate As Date = Today
        Private _Date As Date = Today
        Private _Description As String = ""
        Private _Ammount As Double = 0
        Private _UnitCost As Double = 0
        Private _TotalCost As Double = 0
        Private _Warehouse As WarehouseInfo = Nothing
        Private _OldWarehouseID As Integer = 0
        Private _JournalEntryID As Integer = 0
        Private _JournalEntryDate As Date = Today
        Private _JournalEntryContent As String = ""
        Private _JournalEntryCorrespondence As String = ""
        Private _JournalEntryRelatedPerson As String = ""
        Private _JournalEntryType As DocumentType = DocumentType.None
        Private _JournalEntryTypeHumanReadable As String = ""
        Private _DocumentNumber As String = ""
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
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

        Public ReadOnly Property ComplexOperationID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexOperationID
            End Get
        End Property

        Public ReadOnly Property ComplexOperationType() As GoodsComplexOperationType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexOperationType
            End Get
        End Property

        Public ReadOnly Property ComplexOperationHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexOperationHumanReadable.Trim
            End Get
        End Property

        Public Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                If DateIsReadOnly Then Exit Property
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

        Public Property Description() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Description.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If DescriptionIsReadOnly Then Exit Property
                If value Is Nothing Then value = ""
                If _Description.Trim <> value.Trim Then
                    _Description = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Ammount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Ammount, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If AmmountIsReadOnly Then Exit Property
                If CRound(_Ammount, 6) <> CRound(value, 6) Then
                    _Ammount = CRound(value, 6)
                    PropertyHasChanged()
                    SetTotalCostByUnitCostAndAmmount()
                End If
            End Set
        End Property

        Public Property UnitCost() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnitCost, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If UnitCostIsReadOnly Then Exit Property
                If CRound(_UnitCost, 6) <> CRound(value, 6) Then
                    _UnitCost = CRound(value, 6)
                    PropertyHasChanged()
                    SetTotalCostByUnitCostAndAmmount()
                End If
            End Set
        End Property

        Public Property TotalCost() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalCost)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If TotalCostIsReadOnly Then Exit Property
                If CRound(_TotalCost) <> CRound(value) Then
                    _TotalCost = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Warehouse() As WarehouseInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Warehouse
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As WarehouseInfo)
                CanWriteProperty(True)
                If WarehouseIsReadOnly Then Exit Property
                If Not (_Warehouse Is Nothing AndAlso value Is Nothing) AndAlso _
                    (value Is Nothing OrElse _Warehouse Is Nothing OrElse _Warehouse.ID <> value.ID) Then
                    _Warehouse = value
                    _OperationLimitations.SetWarehouse(_Warehouse)
                    PropertyHasChanged()
                    PropertyHasChanged("AcquisitionAccount")
                End If
            End Set
        End Property

        Public ReadOnly Property OldWarehouseID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OldWarehouseID
            End Get
        End Property

        Public ReadOnly Property AcquisitionAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic Then
                    Return _GoodsInfo.AccountPurchases
                Else
                    If Not _Warehouse Is Nothing AndAlso _Warehouse.ID > 0 Then
                        Return _Warehouse.WarehouseAccount
                    Else
                        Return 0
                    End If
                End If
            End Get
        End Property


        Public ReadOnly Property JournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryID
            End Get
        End Property

        Public ReadOnly Property JournalEntryContent() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryContent.Trim
            End Get
        End Property

        Public ReadOnly Property JournalEntryCorrespondence() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryCorrespondence.Trim
            End Get
        End Property

        Public ReadOnly Property JournalEntryRelatedPerson() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryRelatedPerson.Trim
            End Get
        End Property

        Public ReadOnly Property JournalEntryType() As DocumentType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryType
            End Get
        End Property

        Public ReadOnly Property JournalEntryTypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryTypeHumanReadable.Trim
            End Get
        End Property

        Public ReadOnly Property JournalEntryDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryDate
            End Get
        End Property

        Public ReadOnly Property DocumentNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentNumber.Trim
            End Get
        End Property


        Public ReadOnly Property DateIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return IsChild OrElse (Not Me.IsNew AndAlso (_ComplexOperationID > 0 _
                    OrElse (_JournalEntryID > 0 AndAlso ( _
                    _JournalEntryType = DocumentType.InvoiceMade OrElse _
                    _JournalEntryType = DocumentType.InvoiceReceived))))
            End Get
        End Property

        Public ReadOnly Property DescriptionIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not Me.IsChild AndAlso Not Me.IsNew AndAlso (_ComplexOperationID > 0 _
                    OrElse (_JournalEntryID > 0 AndAlso ( _
                    _JournalEntryType = DocumentType.InvoiceMade OrElse _
                    _JournalEntryType = DocumentType.InvoiceReceived)))
            End Get
        End Property

        Public ReadOnly Property AmmountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange OrElse _
                    (Not Me.IsChild AndAlso Not Me.IsNew AndAlso (_ComplexOperationID > 0 _
                    OrElse (_JournalEntryID > 0 AndAlso ( _
                    _JournalEntryType = DocumentType.InvoiceMade OrElse _
                    _JournalEntryType = DocumentType.InvoiceReceived))))
            End Get
        End Property

        Public ReadOnly Property UnitCostIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange OrElse _
                    (Not Me.IsChild AndAlso Not Me.IsNew AndAlso (_ComplexOperationID > 0 _
                    OrElse (_JournalEntryID > 0 AndAlso ( _
                    _JournalEntryType = DocumentType.InvoiceMade OrElse _
                    _JournalEntryType = DocumentType.InvoiceReceived))))
            End Get
        End Property

        Public ReadOnly Property TotalCostIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange OrElse _
                    (Not Me.IsChild AndAlso Not Me.IsNew AndAlso _JournalEntryID > 0 AndAlso ( _
                    _JournalEntryType = DocumentType.InvoiceMade OrElse _
                    _JournalEntryType = DocumentType.InvoiceReceived))
            End Get
        End Property

        Public ReadOnly Property WarehouseIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange OrElse _
                    (Not Me.IsChild AndAlso Not Me.IsNew AndAlso (_ComplexOperationID > 0 _
                    OrElse (_JournalEntryID > 0 AndAlso ( _
                    _JournalEntryType = DocumentType.InvoiceMade OrElse _
                    _JournalEntryType = DocumentType.InvoiceReceived))))
            End Get
        End Property

        Public ReadOnly Property AssociatedJournalEntryIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Me.IsChild OrElse (Not Me.IsChild AndAlso Not Me.IsNew _
                    AndAlso (_ComplexOperationID > 0 OrElse (_JournalEntryID > 0 _
                    AndAlso (_JournalEntryType = DocumentType.InvoiceMade OrElse _
                    _JournalEntryType = DocumentType.InvoiceReceived))))
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


        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_Description.Trim) _
                OrElse CRound(_Ammount, 6) > 0 OrElse CRound(_UnitCost, 6) > 0 _
                OrElse CRound(_TotalCost, 2) > 0 OrElse _JournalEntryID > 0 _
                OrElse (Not _Warehouse Is Nothing AndAlso _Warehouse.ID > 0))
            End Get
        End Property



        Public Overrides Function Save() As GoodsOperationAcquisition

            If (Me.IsNew AndAlso Not CanAddObject()) OrElse (Not Me.IsNew AndAlso Not CanEditObject()) Then _
                Throw New System.Security.SecurityException("Klaida. Jūsų teisių nepakanka šiai operacijai.")

            If IsChild OrElse _ComplexOperationID > 0 Then Throw New InvalidOperationException( _
                "Klaida. Ši operacija yra sudedamoji kito dokumento dalis ir negali būti keičiama atskirai.")
            If _JournalEntryType = DocumentType.InvoiceMade Then Throw New Exception( _
                "Klaida. Ši operacija yra sudedamoji išrašytos sąskaitos faktūros dalis, " _
                & "ją keisti galima tik kartu su atitinkama sąskaita faktūra.")
            If _JournalEntryType = DocumentType.InvoiceReceived Then Throw New Exception( _
                "Klaida. Ši operacija yra sudedamoji gautos sąskaitos faktūros dalis, " _
                & "ją keisti galima tik kartu su atitinkama sąskaita faktūra.")

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then Throw New Exception("Prekių operacijos duomenyse yra klaidų: " & _
                Me.BrokenRulesCollection.ToString)

            Return MyBase.Save()

        End Function


        Public Sub SetTotalCostByUnitCostAndAmmount()
            TotalCost = CRound(_UnitCost * _Ammount)
        End Sub

        Public Sub LoadAssociatedJournalEntry(ByVal Entry As ActiveReports.JournalEntryInfo)

            If AssociatedJournalEntryIsReadOnly Then Exit Sub

            If Entry Is Nothing OrElse Not Entry.Id > 0 Then Exit Sub

            If Entry.DocType = DocumentType.InvoiceMade OrElse Entry.DocType = DocumentType.InvoiceReceived Then
                Throw New Exception("Prekių įsigijimas pagal sąskaitą faktūrą " _
                    & "gali būti registruojamas tik per atitinkamą sąskaitą faktūrą.")
            ElseIf Entry.DocType = DocumentType.Amortization Then
                Throw New Exception("Prekės negali būti įsigyjamos pagal ilgalaikio turto amortizacijos dokumentą.")
            ElseIf Entry.DocType = DocumentType.GoodsProduction Then
                Throw New Exception("Prekės negali būti įsigyjamos pagal prekių gamybos dokumentą.")
            ElseIf Entry.DocType = DocumentType.GoodsRevalue Then
                Throw New Exception("Prekės negali būti įsigyjamos pagal prekių nukainojimo dokumentą.")
            ElseIf Entry.DocType = DocumentType.GoodsWriteOff Then
                Throw New Exception("Prekės negali būti įsigyjamos pagal prekių nurašymo dokumentą.")
            ElseIf Entry.DocType = DocumentType.ImprestSheet Then
                Throw New Exception("Prekės negali būti įsigyjamos pagal darbo užmokesčio avanso žiniaraštį.")
            ElseIf Entry.DocType = DocumentType.LongTermAssetAccountChange Then
                Throw New Exception("Prekės negali būti įsigyjamos pagal ilgalaikio turto apskaitos sąskaitos pakeitimo dokumentą.")
            ElseIf Entry.DocType = DocumentType.Offset Then
                Throw New Exception("Prekės negali būti įsigyjamos pagal užskaitos dokumentą.")
            ElseIf Entry.DocType = DocumentType.WageSheet Then
                Throw New Exception("Prekės negali būti įsigyjamos pagal darbo užmokesčio žiniaraštį.")
            ElseIf Entry.Date.Date <> _Date.Date Then
                Throw New Exception("Klaida. Susietas bendrojo žurnalo įrašas privalo būti tos pačios datos kaip ir operacija.")
            End If

            _JournalEntryID = Entry.Id
            _JournalEntryDate = Entry.Date
            _JournalEntryContent = Entry.Content
            _JournalEntryCorrespondence = Entry.BookEntries
            _JournalEntryRelatedPerson = Entry.Person
            _JournalEntryType = Entry.DocType
            _JournalEntryTypeHumanReadable = Entry.DocTypeHumanReadable

            _DocumentNumber = Entry.DocNumber

            PropertyHasChanged("JournalEntryID")
            PropertyHasChanged("JournalEntryDate")
            PropertyHasChanged("JournalEntryContent")
            PropertyHasChanged("JournalEntryCorrespondence")
            PropertyHasChanged("JournalEntryRelatedPerson")
            PropertyHasChanged("JournalEntryType")
            PropertyHasChanged("JournalEntryTypeHumanReadable")
            PropertyHasChanged("DocumentNumber")

        End Sub


        Friend Sub SetDate(ByVal value As Date)
            If Not IsChild Then Throw New InvalidOperationException( _
                "Klaida. Metodas SetDate gali būti naudojamas tik child objektui.")
            If _Date.Date <> value.Date Then
                _Date = value.Date
                PropertyHasChanged("Date")
            End If
        End Sub

        Friend Sub SetAssociatedJournalEntryID(ByVal EntryID As Integer)
            If Not IsChild Then Throw New InvalidOperationException( _
                "Klaida. Metodas SetAssociatedJournalEntryID gali būti naudojamas tik child objektui.")
            If _JournalEntryID <> EntryID Then _JournalEntryID = EntryID
        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Description", "operacijos apibūdinimas", _
                Validation.RuleSeverity.Warning))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("UnitCost", "vieneto vertė"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("TotalCost", "bendra partijos vertė"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("Ammount", "įsigyjamas kiekis"))
            ValidationRules.AddRule(AddressOf CommonValidation.InfoObjectRequired, _
                New CommonValidation.InfoObjectRequiredRuleArgs("Warehouse", "sandėlis", "ID"))

            ValidationRules.AddRule(AddressOf DateValidation, New Validation.RuleArgs("Date"))
            ValidationRules.AddRule(AddressOf JournalEntryValidation, _
                New Validation.RuleArgs("JournalEntryID"))

            ValidationRules.AddDependantProperty("Date", "JournalEntryID", False)
            ValidationRules.AddDependantProperty("Warehouse", "Date", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that operation date is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DateValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As GoodsOperationAcquisition = DirectCast(target, GoodsOperationAcquisition)

            If Not ValObj._OperationLimitations Is Nothing AndAlso _
                Not ValObj._OperationLimitations.ValidateOperationDate(ValObj._Date, _
                e.Description, e.Severity) Then Return False

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that associated journal entry is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function JournalEntryValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As GoodsOperationAcquisition = DirectCast(target, GoodsOperationAcquisition)

            If Not ValObj.IsChild AndAlso Not ValObj._JournalEntryID > 0 Then
                e.Description = "Nenurodytas susietas bendrojo žurnalo įrašas " & _
                    "(dokumentas, pagrindžiantis įsigijimą)."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf Not ValObj.IsChild AndAlso ValObj._JournalEntryDate.Date <> ValObj._Date.Date Then
                e.Description = "Susieto bendrojo žurnalo įrašo (dokumento, " & _
                    "pagrindžiančio įsigijimą) data nesutampa su operacijos data."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

            AuthorizationRules.AllowWrite("Goods.GoodsOperationAcquisition2")

        End Sub

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationAcquisition2")
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationAcquisition1")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationAcquisition3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationAcquisition3")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function NewGoodsOperationAcquisition(ByVal GoodsID As Integer) As GoodsOperationAcquisition
            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")
            Return DataPortal.Create(Of GoodsOperationAcquisition)(New Criteria(GoodsID))
        End Function

        Friend Shared Function NewGoodsOperationAcquisitionChild(ByVal summary As GoodsSummary) As GoodsOperationAcquisition
            Return New GoodsOperationAcquisition(summary)
        End Function

        Friend Shared Function NewGoodsOperationAcquisitionChild(ByVal goodsID As Integer) As GoodsOperationAcquisition
            Return New GoodsOperationAcquisition(goodsID, True)
        End Function

        Public Shared Function GetGoodsOperationAcquisition(ByVal id As Integer) As GoodsOperationAcquisition
            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")
            Return DataPortal.Fetch(Of GoodsOperationAcquisition)(New Criteria(id))
        End Function

        Friend Shared Function GetGoodsOperationAcquisitionChild( _
            ByVal obj As OperationPersistenceObject, ByVal LimitationsDataSource As DataTable) _
            As GoodsOperationAcquisition
            Return New GoodsOperationAcquisition(obj, LimitationsDataSource)
        End Function

        Friend Shared Function GetGoodsOperationAcquisitionChild(ByVal nOperationID As Integer) _
            As GoodsOperationAcquisition
            Return New GoodsOperationAcquisition(nOperationID, False)
        End Function

        Public Shared Sub DeleteGoodsOperationAcquisition(ByVal id As Integer)
            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenų ištrynimui.")
            DataPortal.Delete(New Criteria(id))
        End Sub

        Friend Sub DeleteGoodsOperationAcquisitionChild()
            If Not IsChild Then Throw New InvalidOperationException( _
                "Method DeleteGoodsOperationAcquisitionChild is only applicable to child object.")
            DoDelete()
        End Sub


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal summary As GoodsSummary)
            ' require use of factory methods
            MarkAsChild()
            Create(summary)
        End Sub

        Private Sub New(ByVal nID As Integer, ByVal createNew As Boolean)
            ' require use of factory methods
            MarkAsChild()
            If createNew Then
                Create(nID)
            Else
                Fetch(nID)
            End If
        End Sub

        Private Sub New(ByVal obj As OperationPersistenceObject, ByVal LimitationsDataSource As DataTable)
            ' require use of factory methods
            MarkAsChild()
            Fetch(obj, LimitationsDataSource)
        End Sub

#End Region

#Region " Data Access "

        <NonSerialized(), NotUndoable()> _
        Private _Consignment As ConsignmentPersistenceObject = Nothing


        <Serializable()> _
        Private Class Criteria
            Private mId As Integer
            Public ReadOnly Property Id() As Integer
                Get
                    Return mId
                End Get
            End Property
            Public Sub New(ByVal id As Integer)
                mId = id
            End Sub
        End Class


        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)
            Create(criteria.Id)
        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)
            Fetch(criteria.Id)
        End Sub

        Private Sub Create(ByVal nGoodsID As Integer)
            Create(GoodsSummary.GetGoodsSummary(nGoodsID))
        End Sub

        Private Sub Create(ByVal summary As GoodsSummary)

            _GoodsInfo = summary
            _Warehouse = _GoodsInfo.DefaultWarehouse
            Dim wid As Integer = 0
            If Not _Warehouse Is Nothing AndAlso _Warehouse.ID > 0 Then wid = _Warehouse.ID
            _OperationLimitations = OperationalLimitList.GetOperationalLimitList( _
                _GoodsInfo.ID, 0, GoodsOperationType.Acquisition, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, Today, wid, Nothing)

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal nID As Integer)

            Dim obj As OperationPersistenceObject = OperationPersistenceObject. _
                GetOperationPersistenceObject(nID, True)

            Fetch(obj, Nothing)

        End Sub

        Private Sub Fetch(ByVal obj As OperationPersistenceObject, ByVal LimitationsDataSource As DataTable)

            If obj.OperationType <> GoodsOperationType.Acquisition Then Throw New Exception( _
                "Operacijos, kurios ID=" & obj.ID.ToString & " tipas yra ne " & _
                "įsigijimas, o " & ConvertEnumHumanReadable(obj.OperationType) & ".")

            _ID = obj.ID
            _ComplexOperationID = obj.ComplexOperationID
            _ComplexOperationType = obj.ComplexOperationType
            _ComplexOperationHumanReadable = obj.ComplexOperationHumanReadable
            _Date = obj.OperationDate
            _OldDate = _Date
            _Description = obj.Content
            _Ammount = obj.Amount
            _UnitCost = obj.UnitValue
            _TotalCost = obj.TotalValue
            _Warehouse = obj.Warehouse
            _OldWarehouseID = Warehouse.ID
            _JournalEntryID = obj.JournalEntryID
            _JournalEntryDate = obj.JournalEntryDate
            _JournalEntryContent = obj.JournalEntryContent
            _JournalEntryCorrespondence = obj.JournalEntryCorrespondence
            _JournalEntryRelatedPerson = obj.JournalEntryRelatedPerson
            _JournalEntryType = obj.JournalEntryType
            _JournalEntryTypeHumanReadable = obj.JournalEntryTypeHumanReadable
            _DocumentNumber = obj.DocNo
            _InsertDate = obj.InsertDate
            _UpdateDate = obj.UpdateDate
            _GoodsInfo = obj.GoodsInfo

            If LimitationsDataSource Is Nothing Then
                _OperationLimitations = OperationalLimitList.GetOperationalLimitList(obj.GoodsID, _
                    obj.ID, GoodsOperationType.Acquisition, _GoodsInfo.ValuationMethod, _
                    _GoodsInfo.AccountingMethod, _GoodsInfo.Name, obj.OperationDate, obj.WarehouseID, Nothing)
            Else
                _OperationLimitations = OperationalLimitList.GetOperationalLimitList(obj.GoodsID, _
                    obj.ID, GoodsOperationType.Acquisition, _GoodsInfo.ValuationMethod, _
                    _GoodsInfo.AccountingMethod, _GoodsInfo.Name, obj.OperationDate, _
                    obj.WarehouseID, Nothing, LimitationsDataSource)
            End If

            MarkOld()

            ValidationRules.CheckRules()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            CheckIfCanUpdate(Nothing, True)

            GetConsignment()

            DoSave(True, False)

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                _ID, GoodsOperationType.Acquisition, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _OldDate, _OldWarehouseID, Nothing)

            ValidationRules.CheckRules()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            CheckIfCanUpdate(Nothing, True)

            OperationPersistenceObject.CheckIfUpdateDateChanged(_ID, _UpdateDate)

            GetConsignment()

            DoSave(True, False)

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                _ID, GoodsOperationType.Acquisition, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _OldDate, _OldWarehouseID, Nothing)

            ValidationRules.CheckRules()

        End Sub

        Friend Sub SaveChild(ByVal ParentJournalEntryID As Integer, _
            ByVal ParentComplexOperationID As Integer, ByVal ParentDocNo As String, _
            ByVal ParentDescription As String, ByVal ManageConsignments As Boolean, _
            ByVal FinancialDataReadOnly As Boolean)
            _JournalEntryID = ParentJournalEntryID
            _DocumentNumber = ParentDocNo
            _Description = ParentDescription
            If ParentComplexOperationID > 0 Then _ComplexOperationID = ParentComplexOperationID
            DoSave(ManageConsignments, FinancialDataReadOnly)
        End Sub

        Private Sub DoSave(ByVal ManageConsignments As Boolean, ByVal FinancialDataReadOnly As Boolean)

            If ManageConsignments AndAlso _OperationLimitations.FinancialDataCanChange AndAlso _
                Not FinancialDataReadOnly AndAlso _Consignment Is Nothing Then Throw New InvalidOperationException( _
                "Klaida. Prieš išsaugant GoodsOperationAcquisition būtina iškviesti GetConsignment metodą.")

            Dim obj As OperationPersistenceObject = GetPersistenceObj()

            Dim TransactionExisted As Boolean = DatabaseAccess.TransactionExists
            If Not TransactionExisted Then DatabaseAccess.TransactionBegin()

            If IsNew Then
                _ID = obj.Save(_OperationLimitations.FinancialDataCanChange AndAlso Not FinancialDataReadOnly)
            Else
                obj.Save(_OperationLimitations.FinancialDataCanChange AndAlso Not FinancialDataReadOnly)
            End If

            If ManageConsignments AndAlso _OperationLimitations.FinancialDataCanChange _
                AndAlso Not FinancialDataReadOnly Then
                _Consignment.Amount = _Ammount
                _Consignment.TotalValue = _TotalCost
                _Consignment.UnitValue = _UnitCost
                If IsNew Then
                    _Consignment.Insert(_ID, _Warehouse.ID)
                Else
                    _Consignment.Update(_Warehouse.ID)
                End If
            End If

            If Not TransactionExisted Then DatabaseAccess.TransactionCommit()

            If IsNew Then _InsertDate = obj.InsertDate
            _UpdateDate = obj.UpdateDate
            _OldDate = _Date
            _OldWarehouseID = _Warehouse.ID

            MarkOld()

        End Sub

        Private Function GetPersistenceObj() As OperationPersistenceObject

            Dim obj As OperationPersistenceObject
            If IsNew Then
                obj = OperationPersistenceObject.NewOperationPersistenceObject
            Else
                obj = OperationPersistenceObject.GetOperationPersistenceObject(_ID, False)
            End If

            If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic Then
                obj.AccountPurchases = _TotalCost
                obj.AmountInWarehouse = 0
                obj.AmountInPurchases = _Ammount
            Else
                obj.AccountGeneral = _TotalCost
                obj.AmountInWarehouse = _Ammount
                obj.AmountInPurchases = 0
            End If
            obj.Amount = _Ammount
            obj.Content = _Description
            obj.DocNo = _DocumentNumber
            obj.GoodsID = _GoodsInfo.ID
            obj.JournalEntryID = _JournalEntryID
            obj.OperationDate = _Date
            obj.OperationType = GoodsOperationType.Acquisition
            obj.TotalValue = _TotalCost
            obj.UnitValue = _UnitCost
            obj.WarehouseID = _Warehouse.ID
            obj.ComplexOperationID = _ComplexOperationID

            Return obj

        End Function


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Private Overloads Sub DataPortal_Delete(ByVal criteria As Criteria)

            Dim OperationToDelete As GoodsOperationAcquisition = New GoodsOperationAcquisition
            OperationToDelete.DataPortal_Fetch(criteria)

            If OperationToDelete.ComplexOperationID > 0 Then Throw New Exception( _
                "Klaida. Ši operacija yra sudedamoji dalis kompleksinės operacijos - " _
                & ConvertEnumHumanReadable(OperationToDelete.ComplexOperationType) _
                & ". Ją pašalinti galima tik kartu su komplesine operacija.")

            If OperationToDelete.JournalEntryType = DocumentType.InvoiceMade Then _
                Throw New Exception("Klaida. Ši operacija yra sudedamoji dalis išrašytos " _
                & "sąskaitos faktūros. Ją pašalinti galima tik kartu su sąskaita faktūra.")

            If OperationToDelete.JournalEntryType = DocumentType.InvoiceReceived Then _
                Throw New Exception("Klaida. Ši operacija yra sudedamoji dalis gautos " _
                & "sąskaitos faktūros. Ją pašalinti galima tik kartu su sąskaita faktūra.")

            If Not OperationToDelete._OperationLimitations.FinancialDataCanChange Then _
                Throw New Exception("Klaida. Prekių '" & OperationToDelete. _
                    _OperationLimitations.CurrentGoodsName _
                    & "' įsigijimo operacijos pašalinti negalima:" & vbCrLf _
                    & OperationToDelete._OperationLimitations.FinancialDataCanChangeExplanation)

            OperationToDelete.DoDelete()

        End Sub

        Private Sub DoDelete()

            Dim TransactionExisted As Boolean = DatabaseAccess.TransactionExists
            If Not TransactionExisted Then DatabaseAccess.TransactionBegin()

            OperationPersistenceObject.DeleteConsignments(_ID)

            OperationPersistenceObject.Delete(_ID)

            If Not TransactionExisted Then DatabaseAccess.TransactionCommit()

            MarkNew()

        End Sub


        Friend Function CheckIfCanDelete(ByVal LimitationsDataSource As DataTable, _
            ByVal ThrowOnInvalid As Boolean) As String

            If IsNew Then Return ""

            If LimitationsDataSource Is Nothing Then
                _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                    _ID, GoodsOperationType.Acquisition, _GoodsInfo.ValuationMethod, _
                    _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _OldDate, _OldWarehouseID, Nothing)
            Else
                _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                    _ID, GoodsOperationType.Acquisition, _GoodsInfo.ValuationMethod, _
                    _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _OldDate, _OldWarehouseID, _
                    Nothing, LimitationsDataSource)
            End If

            If Not _OperationLimitations.FinancialDataCanChange Then
                If ThrowOnInvalid Then
                    Throw New Exception("Klaida. Prekių '" & _OperationLimitations.CurrentGoodsName _
                        & "' įsigijimo operacijos pašalinti negalima:" & vbCrLf & _OperationLimitations. _
                        FinancialDataCanChangeExplanation)
                Else
                    Return "Klaida. Prekių '" & _OperationLimitations.CurrentGoodsName _
                        & "' įsigijimo operacijos pašalinti negalima:" & vbCrLf & _OperationLimitations. _
                        FinancialDataCanChangeExplanation
                End If
            End If

            Return ""

        End Function

        Friend Function CheckIfCanUpdate(ByVal LimitationsDataSource As DataTable, _
            ByVal ThrowOnInvalid As Boolean) As String

            If IsNew Then

                _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                    _ID, GoodsOperationType.Acquisition, _GoodsInfo.ValuationMethod, _
                    _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _Date, _Warehouse.ID, Nothing)

            Else

                If LimitationsDataSource Is Nothing Then

                    _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                        _ID, GoodsOperationType.Acquisition, _GoodsInfo.ValuationMethod, _
                        _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _OldDate, _OldWarehouseID, Nothing)

                Else

                    _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                        _ID, GoodsOperationType.Acquisition, _GoodsInfo.ValuationMethod, _
                        _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _OldDate, _OldWarehouseID, _
                        Nothing, LimitationsDataSource)

                End If

            End If

            ValidationRules.CheckRules()
            If Not IsValid Then
                If ThrowOnInvalid Then
                    Throw New Exception("Prekių '" & _GoodsInfo.Name & "' įsigijimo operacijoje yra klaidų: " _
                        & BrokenRulesCollection.ToString)
                Else
                    Return "Prekių '" & _GoodsInfo.Name & "' įsigijimo operacijoje yra klaidų: " _
                        & BrokenRulesCollection.ToString
                End If
            End If

            Return ""

        End Function

        Friend Sub ReloadLimitations(ByVal LimitationsDataSource As DataTable)

            If LimitationsDataSource Is Nothing Then Throw New ArgumentNullException( _
                "Klaida. Metodui GoodsOperationAcquisition.ReloadLimitations " _
                & "nenurodytas LimitationsDataSource parametras.")
            If IsNew Then Throw New InvalidOperationException("Klaida. " _
                & "Metodas GoodsOperationAcquisition.ReloadLimitations gali " _
                & "būti taikomas tik Old objektams.")

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                _ID, GoodsOperationType.Acquisition, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _OldDate, _OldWarehouseID, _
                Nothing, LimitationsDataSource)

            ValidationRules.CheckRules()

        End Sub

        Friend Function GetTotalBookEntryList() As BookEntryInternalList

            Dim result As BookEntryInternalList = _
               BookEntryInternalList.NewBookEntryInternalList(BookEntryType.Debetas)

            Dim AcquisitionAccountBookEntry As BookEntryInternal = _
                BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas)
            If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic Then
                AcquisitionAccountBookEntry.Account = _GoodsInfo.AccountPurchases
            Else
                AcquisitionAccountBookEntry.Account = _Warehouse.WarehouseAccount
            End If
            AcquisitionAccountBookEntry.Ammount = CRound(_TotalCost)
            result.Add(AcquisitionAccountBookEntry)

            Return result

        End Function

        Friend Sub GetConsignment()

            If IsNew Then
                _Consignment = ConsignmentPersistenceObject.NewConsignmentPersistenceObject()
            Else
                Dim list As ConsignmentPersistenceObjectList = ConsignmentPersistenceObjectList. _
                    GetConsignmentPersistenceObjectList(_ID)
                If list.Count < 1 Then Throw New Exception("Klaida. Nerastas partijos įrašas " _
                    & "prekės '" & _GoodsInfo.Name & "' įsigijimo operacijai.")
                If list.Count > 1 Then Throw New Exception("Klaida. Yra daugiau ne vienas partijos įrašas " _
                    & "prekės '" & _GoodsInfo.Name & "' įsigijimo operacijai. Tikėtina, sugadinta duombazė.")

                _Consignment = list(0)

            End If

        End Sub

        Friend Function GetConsignmentPersistenceObject() As ConsignmentPersistenceObject

            Dim result As ConsignmentPersistenceObject

            If IsNew Then
                result = ConsignmentPersistenceObject.NewConsignmentPersistenceObject
                result.Amount = _Ammount
                result.TotalValue = _TotalCost
                result.UnitValue = _UnitCost
            Else
                Dim list As ConsignmentPersistenceObjectList = ConsignmentPersistenceObjectList. _
                    GetConsignmentPersistenceObjectList(_ID)
                If list.Count < 1 Then Throw New Exception("Klaida. Nerastas partijos įrašas " _
                    & "prekės '" & _GoodsInfo.Name & "' įsigijimo operacijai.")
                If list.Count > 1 Then Throw New Exception("Klaida. Yra daugiau ne vienas partijos įrašas " _
                    & "prekės '" & _GoodsInfo.Name & "' įsigijimo operacijai. Tikėtina, sugadinta duombazė.")

                result = list(0)

            End If

            result.Amount = _Ammount
            result.TotalValue = _TotalCost
            result.UnitValue = _UnitCost

            Return result

        End Function

#End Region

    End Class

End Namespace