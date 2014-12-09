Namespace Goods

    <Serializable()> _
    Public Class ProductionCalculation
        Inherits BusinessBase(Of ProductionCalculation)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _Goods As GoodsInfo = Nothing
        Private _Amount As Double = 1
        Private _Date As Date = Today
        Private _IsObsolete As Boolean = False
        Private _Description As String = ""
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private WithEvents _ComponentList As ProductionComponentItemList
        Private WithEvents _CostList As ProductionCostItemList


        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _ComponentListSortedList As Csla.SortedBindingList(Of ProductionComponentItem) = Nothing
        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _CostListSortedList As Csla.SortedBindingList(Of ProductionCostItem) = Nothing

        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public Property Goods() As GoodsInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Goods
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As GoodsInfo)
                CanWriteProperty(True)
                If Not (_Goods Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Goods Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _Goods.ID = value.ID) Then
                    _Goods = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Amount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Amount, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Amount, 6) <> CRound(value, 6) Then
                    _Amount = CRound(value, 6)
                    PropertyHasChanged()
                End If
            End Set
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

        Public ReadOnly Property ComponentList() As ProductionComponentItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComponentList
            End Get
        End Property

        Public ReadOnly Property CostList() As ProductionCostItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CostList
            End Get
        End Property


        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return _ComponentList.Count > 0 OrElse _CostList.Count > 0
            End Get
        End Property

        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _ComponentList.IsDirty OrElse _CostList.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid AndAlso _ComponentList.IsValid AndAlso _CostList.IsValid
            End Get
        End Property



        Public Function GetAllBrokenRules() As String
            Dim result As String = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error).Trim
            result = AddWithNewLine(result, _CostList.GetAllBrokenRules, False)
            result = AddWithNewLine(result, _ComponentList.GetAllBrokenRules, False)

            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning).Trim
            result = AddWithNewLine(result, _CostList.GetAllWarnings(), False)
            result = AddWithNewLine(result, _ComponentList.GetAllWarnings(), False)


            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function


        Public Overrides Function Save() As ProductionCalculation

            If IsNew AndAlso Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")
            If Not IsNew AndAlso Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims pakeisti.")

            If Not _CostList.Count > 0 AndAlso Not _ComponentList.Count > 0 Then _
                Throw New Exception("Klaida. Neįvesta nė viena kalkuliacijos eilutė.")

            Me.ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " _
                & vbCrLf & Me.GetAllBrokenRules)

            Dim result As ProductionCalculation = MyBase.Save
            HelperLists.ProductionCalculationInfoList.InvalidateCache()
            Return result

        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            If _Goods Is Nothing OrElse Not _Goods.ID > 0 Then Return ""
            Return _Goods.Name
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.InfoObjectRequired, _
                New CommonValidation.InfoObjectRequiredRuleArgs("Goods", "gaminama prekė", "ID"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("Amount", "standartinis kiekis"))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Goods.ProductionCalculation2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.ProductionCalculation1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.ProductionCalculation2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.ProductionCalculation3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.ProductionCalculation3")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function NewProductionCalculation() As ProductionCalculation
            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")
            Dim result As New ProductionCalculation
            result._ComponentList = ProductionComponentItemList.NewProductionComponentItemList
            result._CostList = ProductionCostItemList.NewProductionCostItemList
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Public Shared Function GetProductionCalculation(ByVal nID As Integer) As ProductionCalculation
            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")
            Return DataPortal.Fetch(Of ProductionCalculation)(New Criteria(nID))
        End Function

        Friend Shared Function GetProductionCalculationInternal(ByVal nID As Integer) As ProductionCalculation
            Return New ProductionCalculation(nID)
        End Function

        Public Shared Sub DeleteProductionCalculation(ByVal id As Integer)
            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka sąskaitos duomenų ištrynimui.")
            DataPortal.Delete(New Criteria(id))
            HelperLists.ProductionCalculationInfoList.InvalidateCache()
        End Sub


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal nID As Integer)
            DataPortal_Fetch(New Criteria(nID))
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

            Dim myComm As New SQLCommand("FetchProductionCalculation")
            myComm.AddParam("?CD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Throw New Exception("Klaida. Objektas, kurio ID='" _
                    & criteria.ID & "', nerastas.)")

                Dim dr As DataRow = myData.Rows(0)

                _ID = CIntSafe(dr.Item(0), 0)
                _Amount = CDblSafe(dr.Item(1), 6, 0)
                _Date = CDateSafe(dr.Item(2), Today)
                _IsObsolete = ConvertDbBoolean(CIntSafe(dr.Item(3), 0))
                _Description = CStrSafe(dr.Item(4))
                _InsertDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(5), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime
                _UpdateDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(6), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime
                _Goods = GoodsInfo.GetGoodsInfo(dr, 7)

            End Using

            myComm = New SQLCommand("FetchProductionItemList")
            myComm.AddParam("?CD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                _ComponentList = ProductionComponentItemList.GetProductionComponentItemList(myData)
                _CostList = ProductionCostItemList.GetProductionCostItemList(myData)

            End Using

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_Insert()

            Dim myComm As New SQLCommand("InsertProductionCalculation")
            AddWithParams(myComm)

            DatabaseAccess.TransactionBegin()

            myComm.Execute()

            _ID = myComm.LastInsertID

            ComponentList.Update(Me)
            CostList.Update(Me)

            DatabaseAccess.TransactionCommit()

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            Dim myComm As New SQLCommand("UpdateProductionCalculation")
            AddWithParams(myComm)
            myComm.AddParam("?CD", _ID)

            DatabaseAccess.TransactionBegin()

            myComm.Execute()

            ComponentList.Update(Me)
            CostList.Update(Me)

            DatabaseAccess.TransactionCommit()

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            Dim myComm As New SQLCommand("DeleteProductionCalculationItems")
            myComm.AddParam("?CD", criteria.Id)

            DatabaseAccess.TransactionBegin()

            myComm.Execute()

            myComm = New SQLCommand("DeleteProductionCalculation")
            myComm.AddParam("?CD", criteria.Id)

            myComm.Execute()

            DatabaseAccess.TransactionCommit()

            MarkNew()

        End Sub

        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AA", CRound(_Amount, 6))
            myComm.AddParam("?AB", _Date.Date)
            myComm.AddParam("?AC", ConvertDbBoolean(_IsObsolete))
            myComm.AddParam("?AD", _Goods.ID)
            myComm.AddParam("?AE", _Description.Trim)

            _UpdateDate = DateTime.Now
            _UpdateDate = New DateTime(Math.Floor(_UpdateDate.Ticks / TimeSpan.TicksPerSecond) _
                * TimeSpan.TicksPerSecond)
            If Not _ID > 0 Then _InsertDate = _UpdateDate

            myComm.AddParam("?AF", _UpdateDate.ToUniversalTime)
            
        End Sub

#End Region

    End Class

End Namespace