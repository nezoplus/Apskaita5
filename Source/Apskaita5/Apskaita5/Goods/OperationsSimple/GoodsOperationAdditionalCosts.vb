﻿Imports Csla.Validation
Imports ApskaitaObjects.My.Resources
Namespace Goods

    ''' <summary>
    ''' Represents a simple goods acquisition value increase (added costs) operation, 
    ''' registers modified <see cref="ConsignmentPersistenceObject">consignments</see>,
    ''' i.e. discards consignments which value is increased and adds new modified consignments.
    ''' </summary>
    ''' <remarks>See methodology for BAS No 9 ""Stores"" para. 6 for details.
    ''' Have an associated <see cref="General.JournalEntry">JournalEntry</see>, e.g. an invoice.
    ''' Values are stored using <see cref="OperationPersistenceObject">OperationPersistenceObject</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsOperationAdditionalCosts
        Inherits BusinessBase(Of GoodsOperationAdditionalCosts)
        Implements IIsDirtyEnough, IGetErrorForListItem, IValidationMessageProvider

#Region " Business Methods "

        ''' <summary>
        ''' Types of the (journal entry) documents that could be attached 
        ''' to the operation, i.e. could be an acquisition value increase base.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared ReadOnly AllowedJournalEntryTypes As DocumentType() _
            = New DocumentType() {DocumentType.BankOperation, _
            DocumentType.None, DocumentType.TillSpendingOrder, _
            DocumentType.WageSheet, DocumentType.AdvanceReport}

        ''' <summary>
        ''' Types of the (journal entry) documents that act as a parent
        ''' of the operation, i.e. the operation could only be changed
        ''' within the approprate document context.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared ReadOnly ParentJournalEntryTypes As DocumentType() _
            = New DocumentType() {DocumentType.InvoiceMade, DocumentType.InvoiceReceived}

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private _ComplexOperationID As Integer = 0
        Private _ComplexOperationType As GoodsComplexOperationType = GoodsComplexOperationType.InternalTransfer
        Private _ComplexOperationHumanReadable As String = ""
        Private _GoodsInfo As GoodsSummary = Nothing
        Private _OperationLimitations As OperationalLimitList = Nothing
        Private _Date As Date = Today
        Private _Description As String = ""
        Private _Warehouse As WarehouseInfo = Nothing
        Private _JournalEntryID As Integer = 0
        Private _JournalEntryDate As Date = Today
        Private _JournalEntryContent As String = ""
        Private _JournalEntryCorrespondence As String = ""
        Private _JournalEntryRelatedPerson As String = ""
        Private _JournalEntryType As DocumentType = DocumentType.None
        Private _JournalEntryTypeHumanReadable As String = ""
        Private _JournalEntryDocNo As String = ""
        Private _AccountGoodsNetCosts As Long = 0
        Private _AccountPurchasesIsClosed As Boolean = False
        Private _TotalValueChange As Double = 0
        Private _TotalGoodsValueChange As Double = 0
        Private _TotalNetValueChange As Double = 0
        Private WithEvents _Consignments As ConsignmentItemList = Nothing

        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _ConsignmentsSortedList As Csla.SortedBindingList(Of ConsignmentItem) = Nothing


        ''' <summary>
        ''' Gets an ID of the operation that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.ID">OperationPersistenceObject.ID</see>.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="ComplexOperationPersistenceObject.ID">ID of the complex 
        ''' goods operation</see> that the operation is a part of (if any).
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.ComplexOperationID">OperationPersistenceObject.ComplexOperationID</see>.</remarks>
        Public ReadOnly Property ComplexOperationID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexOperationID
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="ComplexOperationPersistenceObject.OperationType">type 
        ''' of the complex goods operation</see> that the operation is a part of.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.ComplexOperationType">OperationPersistenceObject.ComplexOperationType</see>.</remarks>
        Public ReadOnly Property ComplexOperationType() As GoodsComplexOperationType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexOperationType
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="ComplexOperationPersistenceObject.OperationType">localized
        ''' human readable type of the complex goods operation</see> that the operation 
        ''' is a part of (if any).
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.ComplexOperationHumanReadable">OperationPersistenceObject.ComplexOperationHumanReadable</see>.</remarks>
        Public ReadOnly Property ComplexOperationHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexOperationHumanReadable.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the operation was inserted into the database.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.InsertDate">OperationPersistenceObject.InsertDate</see>.</remarks>
        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the operation was last updated.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.UpdateDate">OperationPersistenceObject.UpdateDate</see>.</remarks>
        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="GoodsSummary">general information about the goods</see> 
        ''' which acquisition value is increased by the operation.
        ''' </summary>
        ''' <remarks>Is set when creating a new operation and cannot be changed afterwards.
        ''' Corresponds to <see cref="OperationPersistenceObject.GoodsInfo">OperationPersistenceObject.GoodsInfo</see>.</remarks>
        Public ReadOnly Property GoodsInfo() As GoodsSummary
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="IChronologicValidator">IChronologicValidator</see> object 
        ''' that contains business restraints on updating the operation data.
        ''' </summary>
        ''' <remarks>A <see cref="OperationalLimitList">OperationalLimitList</see> 
        ''' is used to validate a goods operation chronological business rules.</remarks>
        Public ReadOnly Property OperationLimitations() As OperationalLimitList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationLimitations
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="Goods.Warehouse">warehouse</see> that the goods 
        ''' acquisition value is increased in.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.Warehouse">OperationPersistenceObject.Warehouse</see>
        ''' and <see cref="ConsignmentPersistenceObject.WarehouseID">ConsignmentPersistenceObject.WarehouseID</see>.</remarks>
        Public ReadOnly Property Warehouse() As WarehouseInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Warehouse
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="General.JournalEntry.ID">ID of the journal entry</see>
        ''' that is associated with the operation.
        ''' </summary>
        ''' <remarks>Invoke method <see cref="LoadAssociatedJournalEntry">LoadAssociatedJournalEntry</see>
        ''' to associate a journal entry with the operation.
        ''' Corresponds to <see cref="OperationPersistenceObject.JournalEntryID">OperationPersistenceObject.JournalEntryID</see>.</remarks>
        Public ReadOnly Property JournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryID
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.JournalEntry.[Date]">date of the journal entry</see>
        ''' that is associated with the operation.
        ''' </summary>
        ''' <remarks>Invoke method <see cref="LoadAssociatedJournalEntry">LoadAssociatedJournalEntry</see>
        ''' to associate a journal entry with the operation.
        ''' Corresponds to <see cref="OperationPersistenceObject.JournalEntryDate">OperationPersistenceObject.JournalEntryDate</see>.</remarks>
        Public ReadOnly Property JournalEntryDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryDate
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.JournalEntry.Content">content of the journal entry</see>
        ''' that is associated with the operation.
        ''' </summary>
        ''' <remarks>Invoke method <see cref="LoadAssociatedJournalEntry">LoadAssociatedJournalEntry</see>
        ''' to associate a journal entry with the operation.
        ''' Corresponds to <see cref="OperationPersistenceObject.JournalEntryContent">OperationPersistenceObject.JournalEntryContent</see>.</remarks>
        Public ReadOnly Property JournalEntryContent() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryContent.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="ActiveReports.JournalEntryInfo.BookEntries">
        ''' description of the book entries of the journal entry</see>
        ''' that is associated with the operation.
        ''' </summary>
        ''' <remarks>Invoke method <see cref="LoadAssociatedJournalEntry">LoadAssociatedJournalEntry</see>
        ''' to associate a journal entry with the operation.
        ''' Corresponds to <see cref="OperationPersistenceObject.JournalEntryCorrespondence">OperationPersistenceObject.JournalEntryCorrespondence</see>.</remarks>
        Public ReadOnly Property JournalEntryCorrespondence() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryCorrespondence.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.JournalEntry.Person">person of the journal entry</see>
        ''' that is associated with the operation.
        ''' </summary>
        ''' <remarks>Invoke method <see cref="LoadAssociatedJournalEntry">LoadAssociatedJournalEntry</see>
        ''' to associate a journal entry with the operation.
        ''' Corresponds to <see cref="OperationPersistenceObject.JournalEntryRelatedPerson">OperationPersistenceObject.JournalEntryRelatedPerson</see>.</remarks>
        Public ReadOnly Property JournalEntryRelatedPerson() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryRelatedPerson.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.JournalEntry.DocType">type of the journal entry</see>
        ''' that is associated with the operation.
        ''' </summary>
        ''' <remarks>Invoke method <see cref="LoadAssociatedJournalEntry">LoadAssociatedJournalEntry</see>
        ''' to associate a journal entry with the operation.
        ''' Corresponds to <see cref="OperationPersistenceObject.JournalEntryType">OperationPersistenceObject.JournalEntryType</see>.</remarks>
        Public ReadOnly Property JournalEntryType() As DocumentType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryType
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.JournalEntry.DocType">type of the journal entry</see>,
        ''' that is associated with the operation, as a localized human readable string.
        ''' </summary>
        ''' <remarks>Invoke method <see cref="LoadAssociatedJournalEntry">LoadAssociatedJournalEntry</see>
        ''' to associate a journal entry with the operation.
        ''' Corresponds to <see cref="OperationPersistenceObject.JournalEntryTypeHumanReadable">OperationPersistenceObject.JournalEntryTypeHumanReadable</see>.</remarks>
        Public ReadOnly Property JournalEntryTypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryTypeHumanReadable.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.JournalEntry.DocNumber">document number 
        ''' of the journal entry</see> that is associated with the operation.
        ''' </summary>
        ''' <remarks>Invoke method <see cref="LoadAssociatedJournalEntry">LoadAssociatedJournalEntry</see>
        ''' to associate a journal entry with the operation.
        ''' Corresponds to <see cref="OperationPersistenceObject.JournalEntryDocNo">OperationPersistenceObject.JournalEntryDocNo</see>.</remarks>
        Public ReadOnly Property JournalEntryDocNo() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryDocNo.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a date of the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.OperationDate">OperationPersistenceObject.OperationDate</see>.</remarks>
        Public Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                CanWriteProperty(True)
                If DateIsReadOnly Then Exit Property
                If _Date.Date <> value.Date Then
                    _Date = value.Date
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a content (description) of the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.Content">OperationPersistenceObject.Content</see>.</remarks>
        <StringField(ValueRequiredLevel.Recommended, 255)> _
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

        ''' <summary>
        ''' A <see cref="General.Account.ID">goods sales net costs account</see> 
        ''' that is used for value increase (added costs) portion that falls to the 
        ''' already discarded goods consignments.
        ''' </summary>
        ''' <remarks>Can only be set for the goods that are accounted using 
        ''' <see cref="GoodsAccountingMethod.Persistent">Persistent</see>
        ''' method (because in this case <see cref="GoodsItem.AccountSalesNetCosts">
        ''' goods sales net costs account</see> is only default).
        ''' In case of <see cref="GoodsAccountingMethod.Periodic">Periodic</see>
        ''' accounting method returns either <see cref="GoodsItem.AccountSalesNetCosts">
        ''' GoodsItem.AccountSalesNetCosts</see> or <see cref="GoodsItem.AccountPurchases">
        ''' GoodsItem.AccountPurchases</see> subject to <see cref="AccountPurchasesIsClosed">AccountPurchasesIsClosed</see>.
        ''' Corresponds to <see cref="OperationPersistenceObject.AccountOperation">OperationPersistenceObject.AccountOperation</see>.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False, 6)> _
        Public Property AccountGoodsNetCosts() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic _
                    AndAlso Not _AccountPurchasesIsClosed Then
                    Return _GoodsInfo.AccountPurchases
                ElseIf _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic Then
                    Return _GoodsInfo.AccountSalesNetCosts
                Else
                    Return _AccountGoodsNetCosts
                End If
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountGoodsNetCostsIsReadOnly Then Exit Property
                If _AccountGoodsNetCosts <> value Then
                    _AccountGoodsNetCosts = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets an <see cref="General.Account.ID">account</see> that the goods 
        ''' acquisition value is accounted in (either <see cref="Goods.Warehouse.WarehouseAccount">
        ''' warehouse account</see> or <see cref="GoodsItem.AccountPurchases">purchases account</see>).
        ''' </summary>
        ''' <remarks>See methodology for BAS No 9 ""Stores"" para. 6 for details.
        ''' Value depends on the accounting method and the <see cref="Warehouse">warehouse</see>.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False, 2, 6)> _
        Public ReadOnly Property AccountGoodsGeneral() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic _
                    AndAlso Not _AccountPurchasesIsClosed Then
                    Return _GoodsInfo.AccountPurchases
                Else
                    If _Warehouse Is Nothing OrElse _Warehouse.IsEmpty Then Return 0
                    Return _Warehouse.WarehouseAccount
                End If
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets whether the <see cref="GoodsItem.AccountPurchases">
        ''' GoodsItem.AccountPurchases</see> is closed.
        ''' </summary>
        ''' <remarks>Only applicable for the goods that are accounted using
        ''' <see cref="GoodsAccountingMethod.Periodic">Periodic</see> method.
        ''' On fetch the value is calculated subject to the <see cref="AccountGoodsNetCosts">
        ''' AccountGoodsNetCosts</see> value.</remarks>
        Public Property AccountPurchasesIsClosed() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountPurchasesIsClosed
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If AccountPurchasesIsClosedIsReadOnly Then Exit Property
                If _AccountPurchasesIsClosed <> value Then
                    _AccountPurchasesIsClosed = value
                    PropertyHasChanged()
                    PropertyHasChanged("AccountGoodsGeneral")
                    PropertyHasChanged("AccountGoodsNetCosts")
                    If Not _AccountPurchasesIsClosed Then Recalculate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a total goods acquisition value increase (added costs). 
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.TotalValue">OperationPersistenceObject.TotalValue</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public Property TotalValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueChange)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If TotalValueChangeIsReadOnly Then Exit Property
                If CRound(_TotalValueChange) <> CRound(value) Then
                    _TotalValueChange = CRound(value)
                    PropertyHasChanged()
                    Recalculate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a goods acquisition value increase (added costs) portion
        ''' that falls to the available (not discarded) goods consignments. 
        ''' </summary>
        ''' <remarks>Can only be set for the goods that are accounted using
        ''' <see cref="GoodsAccountingMethod.Periodic">Periodic</see> method
        ''' when the <see cref="AccountPurchasesIsClosed">AccountPurchasesIsClosed</see>
        ''' is set to TRUE.
        ''' In case of <see cref="GoodsAccountingMethod.Persistent">Persistent</see> 
        ''' accounting method returns a sum of <see cref="Consignments">consignments</see>
        ''' value increase.
        ''' Corresponds to <see cref="OperationPersistenceObject.AccountGeneral">OperationPersistenceObject.AccountGeneral</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property TotalGoodsValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalGoodsValueChange)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If TotalGoodsValueChangeIsReadOnly Then Exit Property
                If CRound(_TotalGoodsValueChange) <> CRound(value) Then
                    _TotalGoodsValueChange = CRound(value)
                    PropertyHasChanged()
                    Recalculate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a goods acquisition value increase (added costs) portion
        ''' that falls to the discarded goods consignments. 
        ''' </summary>
        ''' <remarks>Is calculated as <see cref="TotalValueChange">TotalValueChange</see>
        ''' minus <see cref="TotalGoodsValueChange">TotalGoodsValueChange</see>.
        ''' Corresponds to <see cref="OperationPersistenceObject.AccountSalesNetCosts">OperationPersistenceObject.AccountSalesNetCosts</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property TotalNetValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalNetValueChange)
            End Get
        End Property

        ''' <summary>
        ''' Gets a collection of consignments which values are (could be) increased.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Consignments() As ConsignmentItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Consignments
            End Get
        End Property

        ''' <summary>
        ''' Gets a sortable collection of consignments which values are (could be) increased.
        ''' </summary>
        ''' <remarks>Used to implement autosort in a datagridview</remarks>
        Public ReadOnly Property ConsignmentsSorted() As Csla.SortedBindingList(Of ConsignmentItem)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _ConsignmentsSortedList Is Nothing Then
                    _ConsignmentsSortedList = New Csla.SortedBindingList(Of ConsignmentItem)(_Consignments)
                End If
                Return _ConsignmentsSortedList
            End Get
        End Property


        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_Description.Trim) _
                    OrElse CRound(_TotalValueChange) > 0 _
                    OrElse CRound(_TotalGoodsValueChange) > 0)
            End Get
        End Property


        ''' <summary>
        ''' Whether the <see cref="Date">Date</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DateIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return IsChild OrElse IsChildOperation
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="Description">Description</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DescriptionIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not Me.IsChild AndAlso IsChildOperation
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="AccountGoodsNetCosts">AccountGoodsNetCosts</see> 
        ''' property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountGoodsNetCostsIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic _
                    OrElse Not _OperationLimitations.FinancialDataCanChange OrElse _
                    (Not Me.IsChild AndAlso IsChildOperation)
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="AccountPurchasesIsClosed">AccountPurchasesIsClosed</see> 
        ''' property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountPurchasesIsClosedIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.AccountingMethod <> GoodsAccountingMethod.Periodic _
                    OrElse Not _OperationLimitations.FinancialDataCanChange OrElse _
                    (Not Me.IsChild AndAlso IsChildOperation)
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="TotalValueChange">TotalValueChange</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property TotalValueChangeIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange OrElse _
                    (Not Me.IsChild AndAlso IsChildOperation)
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="TotalGoodsValueChange">TotalGoodsValueChange</see> 
        ''' property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property TotalGoodsValueChangeIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (_GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic AndAlso _
                    Not _AccountPurchasesIsClosed) OrElse _
                    Not _OperationLimitations.FinancialDataCanChange OrElse _
                    (Not Me.IsChild AndAlso IsChildOperation)
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="LoadAssociatedJournalEntry">LoadAssociatedJournalEntry</see> 
        ''' method could be invoked (a new journal entry associated with the operation).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AssociatedJournalEntryIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Me.IsChild OrElse IsChildOperation
            End Get
        End Property

        ''' <summary>
        ''' Whether the operation is actualy a child of a complex goods operation or
        ''' other document.
        ''' </summary>
        ''' <remarks>The <see cref="GoodsOperationAdditionalCosts.IsChild">IsChild</see>
        ''' property defines the current state of the object, i.e. whether the object was
        ''' fetched/created as a child). The IsChildOperation property defines a 
        ''' persistence state of the object, i.e. whether the object was originaly
        ''' saved as a child object.</remarks>
        Public ReadOnly Property IsChildOperation() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexOperationID > 0 OrElse (_JournalEntryID > 0 AndAlso _
                    Not Array.IndexOf(ParentJournalEntryTypes, _JournalEntryType) < 0) OrElse IsChild
            End Get
        End Property


        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _Consignments.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid AndAlso _Consignments.IsValid
            End Get
        End Property



        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = ""
            If Not MyBase.IsValid Then
                result = AddWithNewLine(result, Me.BrokenRulesCollection.ToString(RuleSeverity.Error), False)
            End If
            If Not _Consignments.IsValid Then
                result = AddWithNewLine(result, _Consignments.GetAllBrokenRules, False)
            End If
            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = ""
            If MyBase.BrokenRulesCollection.WarningCount > 0 Then
                result = AddWithNewLine(result, _
                    Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning), False)
            End If
            If _Consignments.HasWarnings Then
                result = AddWithNewLine(result, _Consignments.GetAllWarnings(), False)
            End If
            Return result
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            Return MyBase.BrokenRulesCollection.WarningCount > 0 _
                OrElse _Consignments.HasWarnings
        End Function

        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return String.Format(My.Resources.Common_ErrorInItem, Me.ToString, _
                vbCrLf, Me.GetAllBrokenRules())
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If Not HasWarnings() Then Return ""
            Return String.Format(My.Resources.Common_WarningInItem, Me.ToString, _
                vbCrLf, Me.GetAllWarnings())
        End Function


        Public Overrides Function Save() As GoodsOperationAdditionalCosts
            Return MyBase.Save
        End Function


        ''' <summary>
        ''' Associates a journal entry with the operation, i.e. considers the journal entry 
        ''' as a base for the acquisition value increase (added costs) in the general ledger.
        ''' </summary>
        ''' <param name="entry">a journal entry to associate the operation with</param>
        ''' <remarks></remarks>
        Public Sub LoadAssociatedJournalEntry(ByVal entry As ActiveReports.JournalEntryInfo)

            If AssociatedJournalEntryIsReadOnly Then Exit Sub

            If entry Is Nothing OrElse Not entry.Id > 0 Then Exit Sub

            If Not Array.IndexOf(ParentJournalEntryTypes, entry.DocType) < 0 Then
                Throw New Exception(String.Format(Goods_GoodsOperationAdditionalCosts_CannotAttachParentType, _
                    entry.DocTypeHumanReadable))
            ElseIf Array.IndexOf(AllowedJournalEntryTypes, entry.DocType) < 0 Then
                Throw New Exception(String.Format(Goods_GoodsOperationAdditionalCosts_InvalidJournalEntryType, _
                    entry.DocTypeHumanReadable))
            End If

            _JournalEntryID = entry.Id
            _JournalEntryDate = entry.Date
            _JournalEntryContent = entry.Content
            _JournalEntryCorrespondence = entry.BookEntries
            _JournalEntryRelatedPerson = entry.Person
            _JournalEntryType = entry.DocType
            _JournalEntryTypeHumanReadable = entry.DocTypeHumanReadable
            _JournalEntryDocNo = entry.DocNumber

            PropertyHasChanged("JournalEntryID")
            PropertyHasChanged("JournalEntryDate")
            PropertyHasChanged("JournalEntryContent")
            PropertyHasChanged("JournalEntryCorrespondence")
            PropertyHasChanged("JournalEntryRelatedPerson")
            PropertyHasChanged("JournalEntryType")
            PropertyHasChanged("JournalEntryTypeHumanReadable")
            PropertyHasChanged("JournalEntryDocNo")

        End Sub

        ''' <summary>
        ''' Sets a new operation date as provided by the parent document.
        ''' </summary>
        ''' <param name="parentDate"></param>
        ''' <remarks></remarks>
        Friend Sub SetParentDate(ByVal parentDate As Date)
            If _Date.Date <> parentDate.Date Then
                _Date = parentDate.Date
                PropertyHasChanged("Date")
            End If
        End Sub

        ''' <summary>
        ''' Sets properties that are handled by a parent document 
        ''' and do not require realtime validation but do require validation before update.
        ''' </summary>
        ''' <param name="parentDocumentNumber">A parent document number.</param>
        ''' <param name="parentContent">A parent content.</param>
        ''' <remarks>Should be invoked before a parent document updates the operation.</remarks>
        Friend Sub SetParentProperties(ByVal parentDocumentNumber As String, _
            ByVal parentContent As String)

            If _Description.Trim <> parentContent.Trim Then
                _Description = parentContent.Trim
                PropertyHasChanged("Description")
            End If

        End Sub


        Private Sub Recalculate()

            If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic _
                AndAlso Not _AccountPurchasesIsClosed Then
                _TotalGoodsValueChange = CRound(_TotalValueChange)
                PropertyHasChanged("TotalGoodsValueChange")
            End If

            _TotalNetValueChange = CRound(_TotalValueChange - _TotalGoodsValueChange)
            PropertyHasChanged("TotalNetValueChange")

        End Sub


        Private Sub Consignments_Changed(ByVal sender As Object, _
            ByVal e As System.ComponentModel.ListChangedEventArgs) Handles _Consignments.ListChanged

            If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic Then Exit Sub

            _TotalGoodsValueChange = _Consignments.GetTotalValueChange
            PropertyHasChanged("TotalGoodsValueChange")
            Recalculate()
            ' because DateValidation is dependent on consignment state
            PropertyHasChanged("Date")

        End Sub

        ''' <summary>
        ''' Helper method. Takes care of child lists loosing their handlers.
        ''' </summary>
        Protected Overrides Function GetClone() As Object
            Dim result As GoodsOperationAdditionalCosts = DirectCast(MyBase.GetClone(), GoodsOperationAdditionalCosts)
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
                RemoveHandler _Consignments.ListChanged, AddressOf Consignments_Changed
            Catch ex As Exception
            End Try
            AddHandler _Consignments.ListChanged, AddressOf Consignments_Changed
        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Goods_GoodsOperationAdditionalCosts_ToString, _
                _GoodsInfo.Name, _ID.ToString)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.AccountFieldValidation, _
                New RuleArgs("AccountGoodsGeneral"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New RuleArgs("TotalValueChange"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New RuleArgs("TotalGoodsValueChange"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New RuleArgs("TotalNetValueChange"))

            ValidationRules.AddRule(AddressOf DateValidation, New Validation.RuleArgs("Date"))
            ValidationRules.AddRule(AddressOf DescriptionValidation, New RuleArgs("Description"))
            ValidationRules.AddRule(AddressOf JournalEntryValidation, New RuleArgs("JournalEntryID"))
            ValidationRules.AddRule(AddressOf AccountGoodsNetCostsValidation, _
                New RuleArgs("AccountGoodsNetCosts"))

            ValidationRules.AddDependantProperty("OperationLimitations", "Date", False)
            ValidationRules.AddDependantProperty("Date", "JournalEntryID", False)
            ValidationRules.AddDependantProperty("TotalNetValueChange", "AccountGoodsNetCosts", False)

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

            Dim valObj As GoodsOperationAdditionalCosts = DirectCast(target, GoodsOperationAdditionalCosts)

            If Not valObj._OperationLimitations Is Nothing AndAlso _
                Not valObj._OperationLimitations.ValidateOperationDate(valObj._Date, _
                e.Description, e.Severity) Then Return False

            If valObj._Date.Date < valObj._Consignments.GetMaxDate.Date Then
                e.Description = Goods_GoodsOperationAdditionalCosts_DateInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property Description is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DescriptionValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean
            If DirectCast(target, GoodsOperationAdditionalCosts).IsChild Then Return True
            Return CommonValidation.StringFieldValidation(target, e)
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

            Dim valObj As GoodsOperationAdditionalCosts = DirectCast(target, GoodsOperationAdditionalCosts)

            If valObj.IsChild Then Return True

            If Not valObj._JournalEntryID > 0 Then
                e.Description = Goods_GoodsOperationAdditionalCosts_JournalEntryNull
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf valObj._JournalEntryDate.Date <> valObj._Date.Date Then
                e.Description = Goods_GoodsOperationAdditionalCosts_JournalEntryDateInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property AccountGoodsNetCosts is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountGoodsNetCostsValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As GoodsOperationAdditionalCosts = DirectCast(target, GoodsOperationAdditionalCosts)

            If valObj._TotalNetValueChange > 0 Then
                Return CommonValidation.AccountFieldValidation(target, e)
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Goods.GoodsOperationAdditionalCosts2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationAdditionalCosts1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationAdditionalCosts2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationAdditionalCosts3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationAdditionalCosts3")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new GoodsOperationAdditionalCosts instance.
        ''' </summary>
        ''' <param name="goodsID">an <see cref="GoodsItem.ID">ID of the goods</see>
        ''' to increase acquisition value</param>
        ''' <param name="warehouseID">an <see cref="Goods.Warehouse.ID">ID of the warehouse</see>
        ''' where the goods are located (if null (zero or negative) a <see cref="GoodsItem.DefaultWarehouse">
        ''' default warehouse for the goods</see> is used)</param>
        ''' <remarks></remarks>
        Public Shared Function NewGoodsOperationAdditionalCosts(ByVal goodsID As Integer, _
            ByVal warehouseID As Integer) As GoodsOperationAdditionalCosts
            Return DataPortal.Create(Of GoodsOperationAdditionalCosts) _
                (New Criteria(goodsID, warehouseID))
        End Function

        ''' <summary>
        ''' Gets a new GoodsOperationAdditionalCosts instance as a child of a
        ''' parent document (complex goods operation, invoice, etc.).
        ''' </summary>
        ''' <param name="goodsID">an <see cref="GoodsItem.ID">ID of the goods</see>
        ''' to increase acquisition value</param>
        ''' <param name="warehouseID">an <see cref="Goods.Warehouse.ID">ID of the warehouse</see>
        ''' where the goods are located (if null (zero or negative) a <see cref="GoodsItem.DefaultWarehouse">
        ''' default warehouse for the goods</see> is used)</param>
        ''' <param name="parentValidator">a chronologic validator of the parent document (if any)</param>
        ''' <remarks></remarks>
        Friend Shared Function NewGoodsOperationAdditionalCostsChild(ByVal goodsID As Integer, _
            ByVal warehouseID As Integer, ByVal parentValidator As IChronologicValidator) As GoodsOperationAdditionalCosts
            Return New GoodsOperationAdditionalCosts(goodsID, warehouseID, parentValidator)
        End Function

        ''' <summary>
        ''' Gets an existing GoodsOperationAdditionalCosts instance from a database.
        ''' </summary>
        ''' <param name="id">an <see cref="ID">ID of the operation</see> to fetch</param>
        ''' <remarks></remarks>
        Public Shared Function GetGoodsOperationAdditionalCosts(ByVal id As Integer) As GoodsOperationAdditionalCosts
            Return DataPortal.Fetch(Of GoodsOperationAdditionalCosts)(New Criteria(id))
        End Function

        ''' <summary>
        ''' Gets an existing GoodsOperationAdditionalCosts instance as a child of a 
        ''' parent document from a database.
        ''' </summary>
        ''' <param name="id">an <see cref="ID">ID of the operation</see> to fetch</param>
        ''' <param name="parentValidator">a chronologic validator of the parent document (if any)</param>
        ''' <remarks></remarks>
        Friend Shared Function GetGoodsOperationAdditionalCostsChild(ByVal id As Integer, _
            ByVal parentValidator As IChronologicValidator) As GoodsOperationAdditionalCosts
            Return New GoodsOperationAdditionalCosts(id, parentValidator)
        End Function

        ''' <summary>
        ''' Deletes an existing GoodsOperationAdditionalCosts instance from a database.
        ''' </summary>
        ''' <param name="id">an <see cref="ID">ID of the operation</see> to delete</param>
        ''' <remarks></remarks>
        Public Shared Sub DeleteGoodsOperationAdditionalCosts(ByVal id As Integer)
            DataPortal.Delete(New Criteria(id))
        End Sub

        ''' <summary>
        ''' Deletes an existing GoodsOperationAcquisition instance as a child
        ''' of a parent document from a database.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Sub DeleteGoodsOperationAdditionalCostsChild()
            DoDelete()
        End Sub


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal nGoodsID As Integer, ByVal nWarehouseID As Integer, _
            ByVal parentValidator As IChronologicValidator)
            MarkAsChild()
            Create(nGoodsID, nWarehouseID, parentValidator)
        End Sub

        Private Sub New(ByVal operationID As Integer, ByVal parentValidator As IChronologicValidator)
            MarkAsChild()
            Fetch(operationID, parentValidator)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private mId As Integer
            Private mWarehouseId As Integer
            Public ReadOnly Property Id() As Integer
                Get
                    Return mId
                End Get
            End Property
            Public ReadOnly Property WarehouseId() As Integer
                Get
                    Return mWarehouseId
                End Get
            End Property
            Public Sub New(ByVal id As Integer)
                mId = id
                mWarehouseId = 0
            End Sub
            Public Sub New(ByVal nGoodsID As Integer, ByVal nWarehouseID As Integer)
                mId = nGoodsID
                mWarehouseId = nWarehouseID
            End Sub
        End Class


        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            Create(criteria.Id, criteria.WarehouseId, Nothing)

        End Sub

        Private Sub Create(ByVal nGoodsID As Integer, ByVal nWarehouseID As Integer, _
            ByVal parentValidator As IChronologicValidator)

            _GoodsInfo = GoodsSummary.NewGoodsSummary(nGoodsID)

            _Warehouse = WarehouseInfoList.GetListChild.GetItem(nWarehouseID, _
                _GoodsInfo.DefaultWarehouseID, True)

            _AccountGoodsNetCosts = _GoodsInfo.AccountSalesNetCosts

            _OperationLimitations = OperationalLimitList.NewOperationalLimitList( _
                _GoodsInfo, GoodsOperationType.ConsignmentAdditionalCosts, _
                _Warehouse.ID, parentValidator)

            _Consignments = ConsignmentItemList.NewConsignmentItemList(nGoodsID, _Warehouse.ID, _
                False, _GoodsInfo.AccountingMethod)

            MarkNew()

            ValidationRules.CheckRules()

        End Sub


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Fetch(criteria.Id, Nothing)

        End Sub

        Private Sub Fetch(ByVal operationID As Integer, ByVal parentValidator As IChronologicValidator)

            Dim obj As OperationPersistenceObject = OperationPersistenceObject. _
                GetOperationPersistenceObject(operationID, _
                GoodsOperationType.ConsignmentAdditionalCosts, True)

            _ID = obj.ID
            _ComplexOperationID = obj.ComplexOperationID
            _ComplexOperationType = obj.ComplexOperationType
            _ComplexOperationHumanReadable = obj.ComplexOperationHumanReadable
            _Date = obj.OperationDate
            _Description = obj.Content
            _TotalValueChange = obj.TotalValue
            _Warehouse = obj.Warehouse
            _JournalEntryID = obj.JournalEntryID
            _JournalEntryDate = obj.JournalEntryDate
            _JournalEntryContent = obj.JournalEntryContent
            _JournalEntryCorrespondence = obj.JournalEntryCorrespondence
            _JournalEntryRelatedPerson = obj.JournalEntryRelatedPerson
            _JournalEntryType = obj.JournalEntryType
            _JournalEntryTypeHumanReadable = obj.JournalEntryTypeHumanReadable
            _JournalEntryDocNo = obj.DocNo
            _InsertDate = obj.InsertDate
            _UpdateDate = obj.UpdateDate
            _GoodsInfo = obj.GoodsInfo

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList( _
                _GoodsInfo, GoodsOperationType.ConsignmentAdditionalCosts, _
                _ID, _Date, obj.WarehouseID, parentValidator, Nothing)

            _Consignments = ConsignmentItemList.GetConsignmentItemList(_ID, _GoodsInfo.ID, _
                _Warehouse.ID, False, _OperationLimitations.FinancialDataCanChange, _
                _GoodsInfo.AccountingMethod)

            If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Persistent Then
                _TotalNetValueChange = obj.AccountOperationValue
                _TotalGoodsValueChange = CRound(_TotalValueChange - _TotalNetValueChange)
                _AccountGoodsNetCosts = obj.AccountOperation
            Else
                If obj.AccountPurchases > 0 Then
                    _AccountPurchasesIsClosed = False
                    _TotalGoodsValueChange = _TotalValueChange
                    _TotalNetValueChange = 0
                Else
                    _AccountPurchasesIsClosed = True
                    _TotalGoodsValueChange = obj.AccountGeneral
                    _TotalNetValueChange = CRound(_TotalValueChange - _TotalGoodsValueChange)
                End If
            End If

            MarkOld()

            ValidationRules.CheckRules()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            CheckIfCanSaveRoot()

            CheckIfCanUpdate(Nothing)

            DoSave(False)

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList( _
                _GoodsInfo, GoodsOperationType.ConsignmentAdditionalCosts, _
                _ID, _Date, _Warehouse.ID, Nothing, Nothing)

            ValidationRules.CheckRules()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            CheckIfCanSaveRoot()

            CheckIfCanUpdate(Nothing)

            DoSave(False)

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList( _
                _GoodsInfo, GoodsOperationType.ConsignmentAdditionalCosts, _
                _ID, _Date, _Warehouse.ID, Nothing, Nothing)

            ValidationRules.CheckRules()

        End Sub

        Friend Sub SaveChild(ByVal parentJournalEntryID As Integer, _
            ByVal parentComplexOperationID As Integer, ByVal financialDataReadOnly As Boolean)
            _JournalEntryID = parentJournalEntryID
            _ComplexOperationID = parentComplexOperationID
            DoSave(financialDataReadOnly)
        End Sub

        Private Sub DoSave(ByVal financialDataReadOnly As Boolean)

            Dim obj As OperationPersistenceObject = GetPersistenceObj()

            Using transaction As New SqlTransaction

                Try

                    obj = obj.Save(_OperationLimitations.FinancialDataCanChange _
                        AndAlso Not financialDataReadOnly, False)

                    If IsNew Then
                        _ID = obj.ID
                        _InsertDate = obj.InsertDate
                    End If
                    _UpdateDate = obj.UpdateDate

                    If _OperationLimitations.FinancialDataCanChange AndAlso _
                        Not financialDataReadOnly Then

                        _Consignments.Update(_ID)

                    End If

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkOld()

        End Sub

        Private Function GetPersistenceObj() As OperationPersistenceObject

            Dim obj As OperationPersistenceObject
            If IsNew Then
                obj = OperationPersistenceObject.NewOperationPersistenceObject( _
                    GoodsOperationType.ConsignmentAdditionalCosts, _GoodsInfo.ID)
            Else
                obj = OperationPersistenceObject.GetOperationPersistenceObjectForSave( _
                    _ID, GoodsOperationType.ConsignmentAdditionalCosts, _UpdateDate, IsChild)
            End If

            obj.JournalEntryID = _JournalEntryID
            obj.ComplexOperationID = _ComplexOperationID
            obj.OperationDate = _Date
            obj.Content = _Description
            obj.DocNo = ""
            obj.WarehouseID = _Warehouse.ID
            obj.Warehouse = _Warehouse
            obj.TotalValue = _TotalValueChange
            obj.Amount = 0
            obj.AmountInWarehouse = 0
            obj.UnitValue = 0
            obj.AmountInPurchases = 0

            If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic Then
                If _AccountPurchasesIsClosed Then
                    obj.AccountGeneral = _TotalGoodsValueChange
                    obj.AccountSalesNetCosts = _TotalNetValueChange
                Else
                    obj.AccountPurchases = _TotalValueChange
                End If
            Else
                obj.AccountGeneral = _TotalGoodsValueChange
                obj.AccountOperation = _AccountGoodsNetCosts
                obj.AccountOperationValue = _TotalNetValueChange
                If obj.AccountOperation = _GoodsInfo.AccountSalesNetCosts Then _
                    obj.AccountSalesNetCosts = _TotalNetValueChange
            End If

            Return obj

        End Function


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID, 0))
        End Sub

        Private Overloads Sub DataPortal_Delete(ByVal criteria As Criteria)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            Dim operationToDelete As GoodsOperationAdditionalCosts = New GoodsOperationAdditionalCosts
            operationToDelete.Fetch(criteria.Id, Nothing)

            If operationToDelete.ComplexOperationID > 0 Then
                Throw New Exception(String.Format(Goods_GoodsOperationAdditionalCosts_InvalidDeleteChild, _
                    operationToDelete._ComplexOperationHumanReadable))
            ElseIf Not Array.IndexOf(ParentJournalEntryTypes, operationToDelete._JournalEntryType) < 0 Then
                Throw New Exception(String.Format(Goods_GoodsOperationAdditionalCosts_InvalidDeleteChild, _
                    operationToDelete._JournalEntryTypeHumanReadable))
            End If

            If Not operationToDelete._OperationLimitations.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsOperationAdditionalCosts_InvalidDelete, _
                    operationToDelete._GoodsInfo.Name, vbCrLf, operationToDelete. _
                    _OperationLimitations.FinancialDataCanChangeExplanation))
            End If

            operationToDelete.DoDelete()

        End Sub

        Private Sub DoDelete()

            Using transaction As New SqlTransaction

                Try

                    OperationPersistenceObject.Delete(_ID, True, True)

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkNew()

        End Sub


        Friend Sub CheckIfCanDelete(ByVal parentValidator As IChronologicValidator)

            If IsNew Then Exit Sub

            _OperationLimitations = OperationalLimitList.GetUpdatedOperationalLimitList( _
                _OperationLimitations, parentValidator, Nothing)

            If Not _OperationLimitations.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsOperationAdditionalCosts_InvalidDelete, _
                    _GoodsInfo.Name, vbCrLf, _OperationLimitations.FinancialDataCanChangeExplanation))
            End If

        End Sub

        Friend Sub CheckIfCanUpdate(ByVal parentValidator As IChronologicValidator)

            _OperationLimitations = OperationalLimitList.GetUpdatedOperationalLimitList( _
                _OperationLimitations, parentValidator, Nothing)

            ValidationRules.CheckRules()
            If Not IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetErrorString()))
            End If

        End Sub

        Friend Function GetTotalBookEntryList() As BookEntryInternalList

            Dim result As BookEntryInternalList = _
               BookEntryInternalList.NewBookEntryInternalList(BookEntryType.Debetas)

            If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic Then

                If _AccountPurchasesIsClosed Then

                    If CRound(_TotalGoodsValueChange) > 0 Then
                        result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                            _Warehouse.WarehouseAccount, CRound(_TotalGoodsValueChange), Nothing))
                    End If
                    If CRound(_TotalNetValueChange) > 0 Then
                        result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                            _GoodsInfo.AccountSalesNetCosts, CRound(_TotalNetValueChange), Nothing))
                    End If

                Else

                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                        _GoodsInfo.AccountPurchases, CRound(_TotalValueChange), Nothing))

                End If

            Else

                If CRound(_TotalGoodsValueChange) > 0 Then
                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                        _Warehouse.WarehouseAccount, CRound(_TotalGoodsValueChange), Nothing))
                End If
                If CRound(_TotalNetValueChange) > 0 Then
                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                        _AccountGoodsNetCosts, CRound(_TotalNetValueChange), Nothing))
                End If

            End If

            Return result

        End Function

        Private Sub CheckIfCanSaveRoot()

            If _ComplexOperationID > 0 Then
                Throw New Exception(String.Format(Goods_GoodsOperationAdditionalCosts_InvalidSaveChild, _
                    _ComplexOperationHumanReadable))
            ElseIf Not Array.IndexOf(ParentJournalEntryTypes, _JournalEntryType) < 0 Then
                Throw New Exception(String.Format(Goods_GoodsOperationAdditionalCosts_InvalidSaveChild, _
                    _JournalEntryTypeHumanReadable))
            End If

        End Sub

#End Region

    End Class

End Namespace