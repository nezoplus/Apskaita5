Namespace Goods

    <Serializable()> _
    Public Class GoodsOperationValuationMethod
        Inherits BusinessBase(Of GoodsOperationValuationMethod)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _GoodsInfo As GoodsSummary = Nothing
        Private _OperationLimitations As OperationalLimitList = Nothing
        Private _Date As Date = Today
        Private _OldDate As Date = Today
        Private _Description As String = ""
        Private _PreviousMethod As GoodsValuationMethod = GoodsValuationMethod.FIFO
        Private _NewMethod As GoodsValuationMethod = GoodsValuationMethod.FIFO
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

        Public ReadOnly Property PreviousMethod() As GoodsValuationMethod
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PreviousMethod
            End Get
        End Property

        Public ReadOnly Property PreviousMethodHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return ConvertEnumHumanReadable(_PreviousMethod)
            End Get
        End Property

        Public Property NewMethod() As GoodsValuationMethod
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NewMethod
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As GoodsValuationMethod)
                CanWriteProperty(True)
                If Not _OperationLimitations.FinancialDataCanChange Then
                    PropertyHasChanged()
                    Exit Property
                End If
                If _NewMethod <> value Then
                    _NewMethod = value
                    PropertyHasChanged()
                    PropertyHasChanged("NewMethodHumanReadable")
                End If
            End Set
        End Property

        Public Property NewMethodHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return ConvertEnumHumanReadable(_NewMethod)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If Not _OperationLimitations.FinancialDataCanChange Then
                    PropertyHasChanged()
                    Exit Property
                End If
                If String.IsNullOrEmpty(value) Then value = ""
                If ConvertEnumHumanReadable(Of GoodsValuationMethod)(value.Trim) <> _NewMethod Then
                    _NewMethod = ConvertEnumHumanReadable(Of GoodsValuationMethod)(value.Trim)
                    PropertyHasChanged()
                    PropertyHasChanged("NewMethod")
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
                Return (Not String.IsNullOrEmpty(_Description.Trim))
            End Get
        End Property



        Public Overrides Function Save() As GoodsOperationValuationMethod

            If (Me.IsNew AndAlso Not CanAddObject()) OrElse (Not Me.IsNew AndAlso Not CanEditObject()) Then _
                Throw New System.Security.SecurityException("Klaida. Jūsų teisių nepakanka šiai operacijai.")

            Me.ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " & vbCrLf _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))
            Return MyBase.Save

        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return "Goods.GoodsOperationValuationMethod"
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Description", "operacijos aprašymas"))

            ValidationRules.AddRule(AddressOf NewMethodValidation, New Validation.RuleArgs("NewMethod"))
            ValidationRules.AddRule(AddressOf DateValidation, New Validation.RuleArgs("Date"))

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

            Dim ValObj As GoodsOperationValuationMethod = DirectCast(target, GoodsOperationValuationMethod)

            If Not ValObj._OperationLimitations Is Nothing AndAlso _
                Not ValObj._OperationLimitations.ValidateOperationDate(ValObj._Date, _
                e.Description, e.Severity) Then Return False

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property NewMethod is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function NewMethodValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As GoodsOperationValuationMethod = DirectCast(target, GoodsOperationValuationMethod)

            If ValObj._NewMethod = ValObj._PreviousMethod Then
                e.Description = "Naujas vertinimo metodas negali būti toks pat, kaip ir senas."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Goods.GoodsOperationValuationMethod2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationValuationMethod1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationValuationMethod2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationValuationMethod3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationValuationMethod3")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function NewGoodsOperationValuationMethod(ByVal GoodsID As Integer) As GoodsOperationValuationMethod
            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")
            Return DataPortal.Create(Of GoodsOperationValuationMethod)(New Criteria(GoodsID))
        End Function

        Public Shared Function GetGoodsOperationValuationMethod(ByVal nID As Integer) As GoodsOperationValuationMethod
            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")
            Return DataPortal.Fetch(Of GoodsOperationValuationMethod)(New Criteria(nID))
        End Function

        Public Shared Sub DeleteGoodsOperationValuationMethod(ByVal id As Integer)
            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenų ištrynimui.")
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


        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)

            _GoodsInfo = GoodsSummary.GetGoodsSummary(criteria.ID)

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList( _
                _GoodsInfo.ID, 0, GoodsOperationType.ValuationMethodChange, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, Today, 0, Nothing)

            _PreviousMethod = _GoodsInfo.ValuationMethod

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            Dim myComm As New SQLCommand("FetchGoodsOperationValuationMethod")
            myComm.AddParam("?MD", criteria.ID)

            Dim GoodsID As Integer = 0

            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Throw New Exception("Klaida. Operacija, kurio ID='" _
                    & criteria.ID & "', nerasta.)")

                Dim dr As DataRow = myData.Rows(0)

                _ID = CIntSafe(dr.Item(0), 0)
                GoodsID = CIntSafe(dr.Item(1), 0)
                _Date = CDateSafe(dr.Item(2), Today)
                _Description = CStrSafe(dr.Item(3)).Trim
                _NewMethod = ConvertEnumDatabaseCode(Of GoodsValuationMethod)(CIntSafe(dr.Item(4), 0))
                _InsertDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(5), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime
                _UpdateDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(6), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime
                _PreviousMethod = ConvertEnumDatabaseCode(Of GoodsValuationMethod)(CIntSafe(dr.Item(7), 0))

            End Using

            _GoodsInfo = GoodsSummary.GetGoodsSummary(GoodsID)

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList( _
                _GoodsInfo.ID, _ID, GoodsOperationType.ValuationMethodChange, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _Date, 0, Nothing)

            MarkOld()

            ValidationRules.CheckRules()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList( _
                _GoodsInfo.ID, _ID, GoodsOperationType.ValuationMethodChange, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _OldDate, 0, Nothing)

            ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " & vbCrLf _
                & BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))

            Dim myComm As New SQLCommand("InsertGoodsOperationValuationMethod")
            myComm.AddParam("?GD", _GoodsInfo.ID)
            AddWithParams(myComm)

            myComm.Execute()

            _ID = myComm.LastInsertID

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList( _
                _GoodsInfo.ID, _ID, GoodsOperationType.ValuationMethodChange, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _OldDate, 0, Nothing)

            ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " & vbCrLf _
                & BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))

            CheckIfUpdateDateChanged()

            Dim myComm As SQLCommand
            If _OperationLimitations.FinancialDataCanChange Then
                myComm = New SQLCommand("UpdateGoodsOperationValuationMethodFull")
            Else
                myComm = New SQLCommand("UpdateGoodsOperationValuationMethodGeneral")
            End If
            AddWithParams(myComm)

            myComm.AddParam("?CD", _ID)

            myComm.Execute()

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            Dim ObjectToDelete As New GoodsOperationValuationMethod
            ObjectToDelete.DataPortal_Fetch(DirectCast(criteria, Criteria))
            If Not ObjectToDelete.OperationLimitations.FinancialDataCanChange Then _
                Throw New Exception("Klaida. Operacijos pašalinti neleidžiama:" & vbCrLf _
                    & ObjectToDelete.OperationLimitations.FinancialDataCanChangeExplanation)

            Dim myComm As New SQLCommand("DeleteGoodsOperationValuationMethod")
            myComm.AddParam("?CD", criteria.Id)

            myComm.Execute()

            MarkNew()

        End Sub

        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AA", _Date.Date)
            myComm.AddParam("?AB", _Description.Trim)
            myComm.AddParam("?AC", ConvertEnumDatabaseCode(_NewMethod))

            _UpdateDate = DateTime.Now
            _UpdateDate = New DateTime(Math.Floor(_UpdateDate.Ticks / TimeSpan.TicksPerSecond) _
                * TimeSpan.TicksPerSecond)
            If Not _ID > 0 Then _InsertDate = _UpdateDate
            myComm.AddParam("?TS", _UpdateDate)

        End Sub


        Private Sub CheckIfUpdateDateChanged()

            Dim myComm As New SQLCommand("CheckIfValuationMethodUpdateDateChanged")
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