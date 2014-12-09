Namespace Goods

    <Serializable()> _
    Public Class GoodsComplexOperationTransferOfBalance
        Inherits BusinessBase(Of GoodsComplexOperationTransferOfBalance)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _JournalEntryID As Integer = 0
        Private _JournalEntryDate As Date = Today
        Private _JournalEntryContent As String = ""
        Private _JournalEntryCorrespondence As String = ""
        Private _DocumentNumber As String = ""
        Private _Date As Date = Today
        Private _OperationalLimit As ComplexChronologicValidator = Nothing
        Private _Content As String = "Prekių likučių perkėlimas"
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private WithEvents _Items As GoodsTransferOfBalanceItemList

        <NotUndoable()> _
        <NonSerialized()> _
        Private _ItemsSortedList As Csla.SortedBindingList(Of GoodsTransferOfBalanceItem) = Nothing


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
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

        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        Public ReadOnly Property OperationalLimit() As ComplexChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationalLimit
            End Get
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

        Public ReadOnly Property Items() As GoodsTransferOfBalanceItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Items
            End Get
        End Property

        Public ReadOnly Property ItemsSortable() As Csla.SortedBindingList(Of GoodsTransferOfBalanceItem)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _ItemsSortedList Is Nothing Then _ItemsSortedList = _
                    New Csla.SortedBindingList(Of GoodsTransferOfBalanceItem)(_Items)
                Return _ItemsSortedList
            End Get
        End Property


        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_Content.Trim) _
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


        Public Sub AddNewGoodsItem(ByVal item As GoodsTransferOfBalanceItem)

            If _Items.ContainsGood(item.GoodsInfo.ID, item.Warehouse.ID) Then _
                Throw New Exception("Klaida. Eilutė prekei '" & item.GoodsInfo.Name _
                & "' sandėlyje '" & item.Warehouse.Name & "' jau yra.")

            item.SetDate(_JournalEntryDate)

            _Items.Add(item)

            _OperationalLimit.MergeNewValidationItem(item.OperationLimitations)

            ValidationRules.CheckRules()

        End Sub


        Public Overrides Function Save() As GoodsComplexOperationTransferOfBalance

            If IsNew AndAlso Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")
            If Not IsNew AndAlso Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims pakeisti.")

            If Not _Items.Count > 0 Then Throw New Exception("Klaida. Neįvesta nė viena eilutė.")

            Me.ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " & vbCrLf & Me.GetAllBrokenRules)
            Return MyBase.Save

        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return "Goods.GoodsComplexOperationTransferOfBalance"
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Content", "operacijos aprašymas", _
                Validation.RuleSeverity.Warning))
            ValidationRules.AddRule(AddressOf CommonValidation.ChronologyValidation, _
                New CommonValidation.ChronologyRuleArgs("JournalEntryDate", "OperationalLimit"))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("General.TransferOfBalance2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.TransferOfBalance1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.TransferOfBalance2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.TransferOfBalance3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.TransferOfBalance3")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetGoodsComplexOperationTransferOfBalance() As GoodsComplexOperationTransferOfBalance
            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")
            Dim result As GoodsComplexOperationTransferOfBalance = _
                DataPortal.Fetch(Of GoodsComplexOperationTransferOfBalance)(New Criteria())
            If Not result._ID > 0 Then result.MarkNew()
            Return result
        End Function

        Public Shared Sub DeleteGoodsComplexOperationTransferOfBalance()
            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenų ištrynimui.")
            DataPortal.Delete(New Criteria())
        End Sub


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public Sub New()
            End Sub
        End Class


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            Dim myComm As New SQLCommand("FetchGoodsComplexOperationTransferOfBalance")

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception( _
                    "Klaida. Apskaitoje nėra registruota likučių perkėlimo operacija.")

                Dim dr As DataRow = myData.Rows(0)

                _JournalEntryID = CIntSafe(dr.Item(0), 0)
                _JournalEntryDate = CDateSafe(dr.Item(1), Today)
                _DocumentNumber = CStrSafe(dr.Item(2))
                _JournalEntryContent = CStrSafe(dr.Item(3))
                _JournalEntryCorrespondence = CStrSafe(dr.Item(4))
                _ID = CIntSafe(dr.Item(5), 0)

                If Not _ID > 0 AndAlso Not _JournalEntryID > 0 Then Throw New Exception( _
                    "Klaida. Apskaitoje nėra registruota likučių perkėlimo operacija.")

                If Not _JournalEntryID > 0 Then Throw New Exception("Klaida. " _
                    & "Apskaitoje nėra registruota likučių perkėlimo operacija, bet yra " _
                    & "registruota prekių likučių perkėlimo operacija. Siūlytina ištrinti " _
                    & "prekių likučių perkėlimo operaciją.")

            End Using

            If _ID > 0 Then

                Dim obj As ComplexOperationPersistenceObject = ComplexOperationPersistenceObject. _
                    GetComplexOperationPersistenceObject(_ID, True)

                Fetch(obj)

            Else

                _OperationalLimit = ComplexChronologicValidator.NewComplexChronologicValidator( _
                    ConvertEnumHumanReadable(GoodsComplexOperationType.TransferOfBalance), Nothing, Nothing)
                _Items = GoodsTransferOfBalanceItemList.NewGoodsTransferOfBalanceItemList

                MarkNew()

            End If

            ValidationRules.CheckRules()
            
        End Sub

        Private Sub Fetch(ByVal obj As ComplexOperationPersistenceObject)

            If obj.OperationType <> GoodsComplexOperationType.TransferOfBalance Then _
                Throw New Exception("Klaida. Kompleksinė operacija, kurios ID=" _
                & obj.ID.ToString & ", yra ne prekių nurašymas, o " _
                & ConvertEnumHumanReadable(obj.OperationType))

            _Content = obj.Content
            _InsertDate = obj.InsertDate
            _Date = obj.OperationDate
            _UpdateDate = obj.UpdateDate

            Using myData As DataTable = OperationalLimitList.GetDataSourceForComplexOperation(_ID, _Date)
                Dim objList As List(Of OperationPersistenceObject) = _
                    OperationPersistenceObject.GetOperationPersistenceObjectList(_ID)
                _Items = GoodsTransferOfBalanceItemList.GetGoodsTransferOfBalanceItemList(objList, myData)
            End Using

            _OperationalLimit = ComplexChronologicValidator.GetComplexChronologicValidator( _
                _ID, _Date, ConvertEnumHumanReadable(GoodsComplexOperationType.TransferOfBalance), _
                Nothing, _Items.GetLimitations())

            If _ID > 0 Then
                MarkOld()
                If _Date.Date <> _JournalEntryDate.Date Then
                    _Items.SetDate(_JournalEntryDate)
                    MarkDirty()
                End If
            End If

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            PrepareOperationConsignments()

            CheckIfCanUpdate()

            DoSave()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not _ID > 0 Then
                MarkNew()
                DataPortal_Insert()
                Exit Sub
            End If

            ComplexOperationPersistenceObject.CheckIfUpdateDateChanged(_ID, _UpdateDate)

            PrepareOperationConsignments()

            CheckIfCanUpdate()

            DoSave()

        End Sub

        Private Sub DoSave()

            Dim obj As ComplexOperationPersistenceObject = GetPersistenceObj()

            Dim TransactionExisted As Boolean = DatabaseAccess.TransactionExists
            If Not TransactionExisted Then DatabaseAccess.TransactionBegin()

            If IsNew Then
                _ID = obj.Save(_OperationalLimit.FinancialDataCanChange, False, False)
            Else
                obj.Save(_OperationalLimit.FinancialDataCanChange, False, False)
            End If

            _Items.Update(Me)

            If Not TransactionExisted Then DatabaseAccess.TransactionCommit()

            If IsNew Then _InsertDate = obj.InsertDate
            _UpdateDate = obj.UpdateDate

            MarkOld()

            ReloadLimitations()

        End Sub

        Private Function GetPersistenceObj() As ComplexOperationPersistenceObject

            Dim obj As ComplexOperationPersistenceObject
            If IsNew Then
                obj = ComplexOperationPersistenceObject.NewComplexOperationPersistenceObject
            Else
                obj = ComplexOperationPersistenceObject.GetComplexOperationPersistenceObject(_ID, False)
            End If

            obj.AccountOperation = 0
            obj.GoodsID = 0
            obj.Warehouse = Nothing
            obj.SecondaryWarehouse = Nothing
            obj.OperationType = GoodsComplexOperationType.TransferOfBalance
            obj.Content = _Content
            obj.DocNo = _DocumentNumber
            obj.JournalEntryID = _JournalEntryID
            obj.OperationDate = _JournalEntryDate

            Return obj

        End Function


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria())
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            Dim OperationToDelete As GoodsComplexOperationTransferOfBalance = _
                New GoodsComplexOperationTransferOfBalance
            OperationToDelete.DataPortal_Fetch(DirectCast(criteria, Criteria))

            If Not OperationToDelete._OperationalLimit.FinancialDataCanChange Then _
                Throw New Exception("Klaida. Negalima ištrinti prekių " _
                    & "likučių perkėlimo operacijos:" & vbCrLf & OperationToDelete. _
                    _OperationalLimit.FinancialDataCanChangeExplanation)

            Dim TransactionExisted As Boolean = DatabaseAccess.TransactionExists
            If Not TransactionExisted Then DatabaseAccess.TransactionBegin()

            ComplexOperationPersistenceObject.DeleteConsignments(OperationToDelete.ID)

            ComplexOperationPersistenceObject.DeleteOperations(OperationToDelete.ID)

            ComplexOperationPersistenceObject.Delete(OperationToDelete.ID)

            If Not TransactionExisted Then DatabaseAccess.TransactionCommit()

        End Sub


        Private Sub CheckIfCanUpdate()

            ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Prekių nurašymo operacijoje " _
                & "yra klaidų: " & BrokenRulesCollection.ToString)

            Dim exceptionText As String = ""

            If IsNew Then
                exceptionText = AddWithNewLine(exceptionText, _Items.CheckIfCanUpdate(Nothing, False), False)

            Else
                Using myData As DataTable = OperationalLimitList.GetDataSourceForComplexOperation( _
                    _ID, _JournalEntryDate)
                    exceptionText = AddWithNewLine(exceptionText, _Items.CheckIfCanUpdate(myData, False), False)
                End Using
            End If

            If Not String.IsNullOrEmpty(exceptionText.Trim.Trim) Then _
                Throw New Exception(exceptionText.Trim)

        End Sub

        Private Sub ReloadLimitations()

            Using myData As DataTable = OperationalLimitList.GetDataSourceForComplexOperation(_ID, _JournalEntryDate)
                _Items.ReloadLimitations(myData)
            End Using

            _OperationalLimit.ReloadValidationItems(_ID, _JournalEntryDate, _Items.GetLimitations)

            ValidationRules.CheckRules()

        End Sub

        Private Sub PrepareOperationConsignments()
            _Items.PrepareOperationConsignments()
        End Sub

#End Region

    End Class

End Namespace