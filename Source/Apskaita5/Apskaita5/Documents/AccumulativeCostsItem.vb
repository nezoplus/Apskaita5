﻿Imports ApskaitaObjects.Attributes

Namespace Documents

    ''' <summary>
    ''' Represents an accumulated costs or revenue distribution item.
    ''' </summary>
    ''' <remarks>Encapsulates a <see cref="General.JournalEntry">JournalEntry</see> of type <see cref="DocumentType.AccumulatedCosts">DocumentType.AccumulatedCosts</see>.
    ''' Should only be used as a child of a <see cref="AccumulativeCostsItemList">AccumulativeCostsItemList</see>.
    ''' Values are stored in the database table accumulativecostsitems.</remarks>
    <Serializable()> _
    Public NotInheritable Class AccumulativeCostsItem
        Inherits BusinessBase(Of AccumulativeCostsItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _Date As Date = Today
        Private _Sum As Double = 0
        Private _ChronologyValidator As SimpleChronologicValidator


        ''' <summary>
        ''' Gets <see cref="General.JournalEntry.ID">an ID of the journal entry</see> that is created by the item.
        ''' </summary>
        ''' <remarks>Value is stored in the database table accumulativecostsitems.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="IChronologicValidator">IChronologicValidator</see> object that contains business restraints on updating the item.
        ''' </summary>
        Public ReadOnly Property ChronologyValidator() As SimpleChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ChronologyValidator
            End Get
        End Property

        ''' <summary>
        ''' Whether the property <see cref="Sum">Sum</see> is readonly due to the business rules defined by the <see cref="ChronologyValidator">ChronologyValidator</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SumIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologyValidator Is Nothing AndAlso _
                    Not _ChronologyValidator.FinancialDataCanChange
            End Get
        End Property


        ''' <summary>
        ''' Gets a date of the item, i.e. the date when the (partial) accumulated costs or revenue 
        ''' redistribution is done.
        ''' </summary>
        ''' <remarks>Value is stored in the database table accumulativecostsitems.ItemDate.</remarks>
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

        ''' <summary>
        ''' Gets a sum of the item, i.e. the (partial) sum of the accumulated costs or revenue 
        ''' that is redistributed back to a costs or revenue account.
        ''' </summary>
        ''' <remarks>Value is stored in the database table accumulativecostsitems.ItemSum.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public Property Sum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Sum)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If SumIsReadOnly Then Exit Property
                If CRound(_Sum) <> CRound(value) Then
                    _Sum = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property



        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return String.Format(My.Resources.Common_ErrorInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return String.Format(My.Resources.Common_WarningInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning))
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Documents_AccumulativeCostsItem_ToString, _
                _Date.ToString("yyyy-MM-dd"), DblParser(_Sum), GetCurrentCompany.BaseCurrency)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.ChronologyValidation, _
                New CommonValidation.CommonValidation.ChronologyRuleArgs("Date", "ChronologyValidator"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Sum"))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewAccumulativeCostsItem(ByVal parentValidator As IChronologicValidator) As AccumulativeCostsItem
            Return New AccumulativeCostsItem(parentValidator)
        End Function

        Friend Shared Function GetAccumulativeCostsItem(ByVal dr As DataRow, _
            ByVal closingsDataSource As DataTable, ByVal parentValidator As IChronologicValidator) As AccumulativeCostsItem
            Return New AccumulativeCostsItem(dr, closingsDataSource, parentValidator)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal parentValidator As IChronologicValidator)
            MarkAsChild()
            Create(parentValidator)
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal closingsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator)
            MarkAsChild()
            Fetch(dr, closingsDataSource, parentValidator)
        End Sub

#End Region

#Region " Data Access "

        <NotUndoable()> _
        <NonSerialized()> _
        Private _ChildJournalEntry As General.JournalEntry = Nothing

        Private Sub Create(ByVal parentValidator As IChronologicValidator)
            _ChronologyValidator = SimpleChronologicValidator.NewSimpleChronologicValidator( _
                My.Resources.Documents_AccumulativeCostsItem_TypeName, parentValidator)
        End Sub


        Private Sub Fetch(ByVal dr As DataRow, ByVal closingsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator)

            _ID = CIntSafe(dr.Item(0), 0)
            _Date = CDateSafe(dr.Item(1), Today)
            _Sum = CDblSafe(dr.Item(2), 2, 0)

            _ChronologyValidator = SimpleChronologicValidator.GetSimpleChronologicValidator( _
                closingsDataSource, _ID, _Date, My.Resources.Documents_AccumulativeCostsItem_TypeName, _
                parentValidator)

            MarkOld()

        End Sub


        Friend Sub Insert(ByVal parent As AccumulativeCosts)

            If _ChildJournalEntry Is Nothing Then
                Throw New Exception(My.Resources.Documents_AccumulativeCostsItem_SaveInvalid)
            End If

            _ChildJournalEntry = _ChildJournalEntry.SaveChild

            _ID = _ChildJournalEntry.ID

            Dim myComm As New SQLCommand("InsertAccumulativeCostsItem")
            AddWithParams(myComm)
            myComm.AddParam("?PD", parent.ID)
            myComm.AddParam("?BD", _ID)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As AccumulativeCosts)

            If _ChildJournalEntry Is Nothing Then
                Throw New Exception(My.Resources.Documents_AccumulativeCostsItem_SaveInvalid)
            End If

            _ChildJournalEntry = _ChildJournalEntry.SaveChild

            Dim myComm As New SQLCommand("UpdateAccumulativeCostsItem")
            myComm.AddParam("?CD", _ID)
            AddWithParams(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            If IsNew OrElse Not _ID > 0 Then Exit Sub

            General.JournalEntry.DeleteJournalEntryChild(_ID)

            Dim myComm As New SQLCommand("DeleteAccumulativeCostsItem")
            myComm.AddParam("?CD", _ID)

            myComm.Execute()

            MarkNew()

        End Sub


        Friend Sub PrepareChildJournalEntry(ByVal parent As AccumulativeCosts)

            Dim result As General.JournalEntry
            If IsNew Then
                result = General.JournalEntry.NewJournalEntryChild(DocumentType.AccumulatedCosts)
            Else
                result = General.JournalEntry.GetJournalEntryChild(_ID, DocumentType.AccumulatedCosts)
            End If

            result.Content = parent.Content
            result.Date = _Date
            result.DocNumber = parent.DocumentNumber

            If _ChronologyValidator.FinancialDataCanChange Then

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

                If parent.IsAccumulatedIncome Then
                    result.DebetList(0).Account = parent.AccountAccumulatedCosts
                    result.CreditList(0).Account = parent.AccountDistributedCosts
                Else
                    result.DebetList(0).Account = parent.AccountDistributedCosts
                    result.CreditList(0).Account = parent.AccountAccumulatedCosts
                End If

            End If

            _ChildJournalEntry = result

        End Sub

        Private Sub AddWithParams(ByRef myComm As SQLCommand)
            myComm.AddParam("?AA", _Date.Date)
            myComm.AddParam("?AB", CRound(_Sum))
        End Sub

#End Region

    End Class

End Namespace