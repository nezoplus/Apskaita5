Namespace Documents

    <Serializable()> _
    Public Class Service
        Inherits BusinessBase(Of Service)
        Implements IIsDirtyEnough, IRegionalDataObject

#Region " Business Methods "

        Private _GUID As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _Type As TradedItemType = TradedItemType.All
        Private _TypeHumanReadable As String = ConvertEnumHumanReadable(TradedItemType.All)
        Private _NameShort As String = ""
        Private _Amount As Double = 0
        Private _AccountSales As Long = 0
        Private _RateVatSales As Double = 0
        Private _AccountVatSales As Long = 0
        Private _AccountPurchase As Long = 0
        Private _RateVatPurchase As Double = 0
        Private _AccountVatPurchase As Long = 0
        Private _ServiceCode As String = ""
        Private WithEvents _RegionalContents As RegionalContentList
        Private WithEvents _RegionalPrices As RegionalPriceList
        Private _IsObsolete As Boolean = False
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private _IsInUse As Boolean = False

        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _RegionalContentsSortedList As Csla.SortedBindingList(Of RegionalContent) = Nothing
        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _RegionalPricesSortedList As Csla.SortedBindingList(Of RegionalPrice) = Nothing


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

        Public Property [Type]() As TradedItemType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As TradedItemType)
                CanWriteProperty(True)
                If _Type <> value Then
                    _Type = value
                    _TypeHumanReadable = ConvertEnumHumanReadable(value)
                    PropertyHasChanged()
                    PropertyHasChanged("TypeHumanReadable")
                End If
            End Set
        End Property

        Public Property TypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TypeHumanReadable.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If ConvertEnumHumanReadable(Of TradedItemType)(value.Trim) <> _Type Then
                    _Type = ConvertEnumHumanReadable(Of TradedItemType)(value.Trim)
                    _TypeHumanReadable = ConvertEnumHumanReadable(_Type)
                    PropertyHasChanged()
                    PropertyHasChanged("Type")
                End If
            End Set
        End Property

        Public Property NameShort() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NameShort.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _NameShort.Trim <> value.Trim Then
                    _NameShort = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Amount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Amount, 4)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Amount, 4) <> CRound(value, 4) Then
                    _Amount = CRound(value, 4)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property AccountSales() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountSales
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _AccountSales <> value Then
                    _AccountSales = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property RateVatSales() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateVatSales)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_RateVatSales) <> CRound(value) Then
                    _RateVatSales = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property AccountVatSales() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountVatSales
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _AccountVatSales <> value Then
                    _AccountVatSales = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property AccountPurchase() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountPurchase
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _AccountPurchase <> value Then
                    _AccountPurchase = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property RateVatPurchase() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateVatPurchase)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_RateVatPurchase) <> CRound(value) Then
                    _RateVatPurchase = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property AccountVatPurchase() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountVatPurchase
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _AccountVatPurchase <> value Then
                    _AccountVatPurchase = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property ServiceCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ServiceCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _ServiceCode.Trim <> value.Trim Then
                    _ServiceCode = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property RegionalContents() As RegionalContentList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _RegionalContents
            End Get
        End Property

        Public ReadOnly Property RegionalPrices() As RegionalPriceList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _RegionalPrices
            End Get
        End Property

        Public ReadOnly Property RegionalContentsSorted() As Csla.SortedBindingList(Of RegionalContent)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _RegionalContentsSortedList Is Nothing Then _RegionalContentsSortedList _
                    = New Csla.SortedBindingList(Of RegionalContent)(_RegionalContents)
                Return _RegionalContentsSortedList
            End Get
        End Property

        Public ReadOnly Property RegionalPricesSorted() As Csla.SortedBindingList(Of RegionalPrice)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _RegionalPricesSortedList Is Nothing Then _RegionalPricesSortedList _
                    = New Csla.SortedBindingList(Of RegionalPrice)(_RegionalPrices)
                Return _RegionalPricesSortedList
            End Get
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

        Public ReadOnly Property IsInUse() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsInUse
            End Get
        End Property

        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_NameShort.Trim) OrElse _
                    (Not _RegionalContents Is Nothing AndAlso _RegionalContents.Count > 0) OrElse _
                    (Not _RegionalPrices Is Nothing AndAlso _RegionalPrices.Count > 0))
            End Get
        End Property


        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _RegionalContents.IsDirty OrElse _RegionalPrices.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid AndAlso _RegionalContents.IsValid AndAlso _RegionalPrices.IsValid
            End Get
        End Property



        Public Overrides Function Save() As Service

            Me.ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " _
                & vbcrlf & Me.GetAllBrokenRules)

            Dim result As Service = MyBase.Save
            HelperLists.ServiceInfoList.InvalidateCache()
            Return result

        End Function

        Public Function GetAllBrokenRules() As String
            Dim result As String = ""
            If Not MyBase.IsValid Then result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
            If Not _RegionalContents.IsValid Then result = AddWithNewLine(result, _
                _RegionalContents.GetAllBrokenRules, False)
            If Not _RegionalPrices.IsValid Then result = AddWithNewLine(result, _
                _RegionalPrices.GetAllBrokenRules, False)
            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = ""
            If MyBase.BrokenRulesCollection.WarningCount > 0 Then _
                result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
            result = AddWithNewLine(result, _RegionalContents.GetAllWarnings, False)
            result = AddWithNewLine(result, _RegionalPrices.GetAllWarnings, False)
            If _RegionalContents.Count < 1 Then result = AddWithNewLine(result, _
                "Neįvesti paslaugos pavadinimai nė viena kalba.", False)
            If _RegionalPrices.Count < 1 Then result = AddWithNewLine(result, _
                "Neįvestos paslaugos kainos nė viena valiuta.", False)
            Return result
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            If Not _ID > 0 Then Return ""
            Return _NameShort
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("NameShort", "trumpas pavadinimas"))
            ValidationRules.AddRule(AddressOf AmountValidation, New Validation.RuleArgs("Amount"))
            ValidationRules.AddRule(AddressOf AccountSalesValidation, New Validation.RuleArgs("AccountSales"))
            ValidationRules.AddRule(AddressOf AccountVatSalesValidation, New Validation.RuleArgs("AccountVatSales"))
            ValidationRules.AddRule(AddressOf AccountPurchaseValidation, New Validation.RuleArgs("AccountPurchase"))
            ValidationRules.AddRule(AddressOf AccountVatPurchaseValidation, New Validation.RuleArgs("AccountVatPurchase"))

            ValidationRules.AddDependantProperty("TypeHumanReadable", "AccountSales", False)
            ValidationRules.AddDependantProperty("TypeHumanReadable", "AccountPurchase", False)
            ValidationRules.AddDependantProperty("TypeHumanReadable", "AccountVatSales", False)
            ValidationRules.AddDependantProperty("TypeHumanReadable", "AccountVatPurchase", False)
            ValidationRules.AddDependantProperty("RateVatSales", "AccountVatSales", False)
            ValidationRules.AddDependantProperty("RateVatPurchase", "AccountVatPurchase", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property Amount is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AmountValidation(ByVal target As Object, _
        ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As Service = DirectCast(target, Service)

            If CRound(ValObj._Amount, 4) > 0 Then
                e.Description = "Šablone nerekomenduojama nurodyti kiekio, " _
                    & "tai padidina klaidų išrašant sąskaitas tikimybę."
                e.Severity = Validation.RuleSeverity.Warning
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property AccountSales is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountSalesValidation(ByVal target As Object, _
        ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As Service = DirectCast(target, Service)

            If (ValObj._Type = TradedItemType.Sales OrElse ValObj._Type = TradedItemType.All) _
                AndAlso Not ValObj._AccountSales > 0 Then
                e.Description = "Nenurodyta pardavimų (pajamų) apskaitos sąskaita."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property AccountVatSales is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountVatSalesValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As Service = DirectCast(target, Service)

            If (ValObj._Type = TradedItemType.Sales OrElse ValObj._Type = TradedItemType.All) _
                AndAlso CRound(ValObj._RateVatSales) > 0 AndAlso Not ValObj._AccountVatSales > 0 Then
                e.Description = "Nenurodyta pardavimų PVM apskaitos sąskaita."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property AccountPurchase is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountPurchaseValidation(ByVal target As Object, _
        ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As Service = DirectCast(target, Service)

            If (ValObj._Type = TradedItemType.Purchases OrElse ValObj._Type = TradedItemType.All) _
                AndAlso Not ValObj._AccountPurchase > 0 Then
                e.Description = "Nenurodyta įsigijimų (sąnaudų) apskaitos sąskaita."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property AccountVatPurchase is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountVatPurchaseValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As Service = DirectCast(target, Service)

            If (ValObj._Type = TradedItemType.Purchases OrElse ValObj._Type = TradedItemType.All) _
                AndAlso CRound(ValObj._RateVatPurchase) > 0 AndAlso Not ValObj._AccountVatPurchase > 0 Then
                e.Description = "Nenurodyta įsigijimų PVM (sąnaudų/atskaitos) apskaitos sąskaita."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Documents.Service2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.Service1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.Service2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.Service3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.Service3")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function NewService() As Service

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")

            Dim result As New Service
            result._RegionalContents = RegionalContentList.NewRegionalContentList
            result._RegionalPrices = RegionalPriceList.NewRegionalPriceList
            result.ValidationRules.CheckRules()
            Return result

        End Function

        Public Shared Function GetService(ByVal nID As Integer) As Service

            Return DataPortal.Fetch(Of Service)(New Criteria(nID))

        End Function

        Public Shared Sub DeleteService(ByVal id As Integer)

            DataPortal.Delete(New Criteria(id))
            HelperLists.ServiceInfoList.InvalidateCache()

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

            Dim myComm As New SQLCommand("FetchService")
            myComm.AddParam("?CD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Throw New Exception("Klaida. Objektas, kurio ID='" _
                    & criteria.ID & "', nerastas.)")

                Dim dr As DataRow = myData.Rows(0)

                _ID = CIntSafe(dr.item(0), 0)
                _Type = ConvertEnumDatabaseCode(Of TradedItemType)(CIntSafe(dr.Item(1), 0))
                _TypeHumanReadable = convertenumhumanreadable(_Type)
                _NameShort = CStrSafe(dr.Item(2)).Trim
                _Amount = CDblSafe(dr.Item(3), 4, 0)
                _RateVatSales = CDblSafe(dr.Item(4), 2, 0)
                _RateVatPurchase = CDblSafe(dr.Item(5), 2, 0)
                _IsObsolete = ConvertDbBoolean(CIntSafe(dr.Item(6), 0))
                _AccountSales = CLongSafe(dr.Item(7), 0)
                _AccountVatSales = CLongSafe(dr.Item(8), 0)
                _AccountPurchase = CLongSafe(dr.Item(9), 0)
                _AccountVatPurchase = CLongSafe(dr.Item(10), 0)
                _ServiceCode = CStrSafe(dr.Item(11)).Trim
                _InsertDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(12), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime
                _UpdateDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(13), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime
                _IsInUse = ConvertDbBoolean(CIntSafe(dr.Item(14), 0))
                _RegionalContents = RegionalContentList.GetRegionalContentList(CStrSafe(dr.Item(15)))
                _RegionalPrices = RegionalPriceList.GetRegionalPriceList(CStrSafe(dr.Item(16)))

            End Using

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")

            Dim myComm As New SQLCommand("InsertService")
            AddWithParams(myComm)

            DatabaseAccess.TransactionBegin()

            myComm.Execute()

            _ID = myComm.LastInsertID

            RegionalContents.Update(Me)
            RegionalPrices.Update(Me)

            DatabaseAccess.TransactionCommit()

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims pakeisti.")

            CheckIfUpdateDateChanged()

            Dim myComm As New SQLCommand("UpdateService")
            AddWithParams(myComm)
            myComm.AddParam("?CD", _ID)

            DatabaseAccess.TransactionBegin()

            myComm.Execute()

            RegionalContents.Update(Me)
            RegionalPrices.Update(Me)

            DatabaseAccess.TransactionCommit()

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims pašalinti.")

            CheckIfWasUsed(criteria.id)

            Dim myComm As New SQLCommand("DeleteService")
            myComm.AddParam("?CD", criteria.Id)

            DatabaseAccess.TransactionBegin()

            myComm.Execute()

            RegionalContentList.Delete(criteria.id, 0)
            RegionalPriceList.Delete(criteria.id, 0)

            DatabaseAccess.TransactionCommit()

            MarkNew()

        End Sub


        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AA", ConvertEnumDatabaseCode(_Type))
            myComm.AddParam("?AB", _NameShort.Trim)
            myComm.AddParam("?AC", CRound(_Amount, 4))
            myComm.AddParam("?AD", CRound(_RateVatSales))
            myComm.AddParam("?AE", CRound(_RateVatPurchase))
            myComm.AddParam("?AF", ConvertDbBoolean(_IsObsolete))
            myComm.AddParam("?AG", _AccountSales)
            myComm.AddParam("?AH", _AccountVatSales)
            myComm.AddParam("?AI", _AccountPurchase)
            myComm.AddParam("?AJ", _AccountVatPurchase)
            myComm.AddParam("?AK", _ServiceCode)

            _UpdateDate = DateTime.Now
            _UpdateDate = New DateTime(Math.Floor(_UpdateDate.Ticks / TimeSpan.TicksPerSecond) _
                * TimeSpan.TicksPerSecond)
            If Me.IsNew Then _InsertDate = _UpdateDate
            myComm.AddParam("?AL", _UpdateDate.ToUniversalTime)

        End Sub

        Private Sub CheckIfUpdateDateChanged()

            Dim myComm As New SQLCommand("CheckIfServiceUpdateDateChanged")
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

        Private Shared Sub CheckIfWasUsed(ByVal sID As Integer)

            Dim myComm As New SQLCommand("CheckIfServiceWasUsed")
            myComm.AddParam("?SD", sID)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 AndAlso CIntSafe(myData.Rows(0).Item(0), 0) > 0 Then _
                    Throw New Exception("Klaida. Paslauga buvo panaudota išrašant ir (ar) " _
                    & "registruojant sąskaitas faktūras. Jos pašalinti neleidžiama.")
            End Using

        End Sub

#End Region

    End Class

End Namespace