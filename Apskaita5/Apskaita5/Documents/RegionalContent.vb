Namespace Documents

    <Serializable()> _
    Public Class RegionalContent
        Inherits BusinessBase(Of RegionalContent)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _GUID As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _LanguageCode As String = LanguageCodeLith
        Private _LanguageName As String = GetLanguageName(LanguageCodeLith)
        Private _ContentInvoice As String = ""
        Private _MeasureUnit As String = ""
        Private _VatExempt As String = ""


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public Property LanguageCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LanguageCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _LanguageCode.Trim <> value.Trim Then
                    _LanguageName = GetLanguageName(value.Trim, False)
                    If String.IsNullOrEmpty(_LanguageName.Trim) Then
                        _LanguageCode = ""
                    Else
                        _LanguageCode = value.Trim
                    End If
                    PropertyHasChanged()
                    PropertyHasChanged("LanguageName")
                End If
            End Set
        End Property

        Public Property LanguageName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LanguageName.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _LanguageCode.Trim.ToUpper <> GetLanguageCode(value.Trim, False).Trim.ToUpper Then
                    _LanguageCode = GetLanguageCode(value.Trim, False)
                    _LanguageName = value.Trim
                    PropertyHasChanged()
                    PropertyHasChanged("LanguageCode")
                End If
            End Set
        End Property

        Public Property ContentInvoice() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContentInvoice.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _ContentInvoice.Trim <> value.Trim Then
                    _ContentInvoice = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property MeasureUnit() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MeasureUnit.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _MeasureUnit.Trim <> value.Trim Then
                    _MeasureUnit = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property VatExempt() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _VatExempt.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _VatExempt.Trim <> value.Trim Then
                    _VatExempt = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property



        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return "Klaida (-os) eilutėje '" & _LanguageName & "': " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return "Eilutėje '" & _LanguageName & "' gali būti klaida: " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
        End Function

        Protected Overrides Function GetIdValue() As Object
            Return _GUID
        End Function

        Public Overrides Function ToString() As String
            If Not _ID > 0 Then Return ""
            Return _LanguageName & " -> " & _ContentInvoice
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
               New CommonValidation.SimpleRuleArgs("LanguageName", "regiono kalba"))
            ValidationRules.AddRule(AddressOf CommonValidation.ValueUniqueInCollection, _
                New CommonValidation.SimpleRuleArgs("LanguageName", "regiono kalba"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("ContentInvoice", "pavadinimas sąskaitoje"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("MeasureUnit", "mato vienetas"))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewRegionalContent() As RegionalContent
            Dim result As New RegionalContent
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Friend Shared Function GetRegionalContent(ByVal dr As String) As RegionalContent
            Return New RegionalContent(dr)
        End Function

        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As String)
            MarkAsChild()
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As String)

            Dim DataArray As String() = dr.Split(New String() {"*-*-"}, StringSplitOptions.None)

            _ID = CIntSafe(DataArray(0).Trim, 0)
            _LanguageCode = DataArray(1).Trim
            _LanguageName = GetLanguageName(_LanguageCode, False)
            _ContentInvoice = DataArray(2).Trim
            _MeasureUnit = DataArray(3).Trim
            _VatExempt = DataArray(4).Trim

            MarkOld()

        End Sub

        Friend Sub Insert(ByVal parent As IRegionalDataObject)

            Dim myComm As New SQLCommand("InsertRegionalContent")
            AddWithParams(myComm)
            If TypeOf parent Is Service Then
                myComm.AddParam("?AA", DirectCast(parent, Service).ID)
                myComm.AddParam("?AB", 0)
            ElseIf TypeOf parent Is Goods.GoodsItem Then
                myComm.AddParam("?AA", DirectCast(parent, Goods.GoodsItem).ID)
                myComm.AddParam("?AB", 1)
            Else
                Dim o As Object = parent
                Throw New NotImplementedException("Klaida. Objekto tipo '" _
                    & o.GetType.FullName & "' regionalizavimas neimplementuotas.")
            End If

            myComm.Execute()

            _ID = myComm.LastInsertID

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As IRegionalDataObject)

            Dim myComm As New SQLCommand("UpdateRegionalContent")
            myComm.AddParam("?CD", _ID)
            AddWithParams(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteRegionalContent")
            myComm.AddParam("?CD", _ID)

            myComm.Execute()

            MarkNew()

        End Sub

        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AC", _LanguageCode.Trim)
            myComm.AddParam("?AD", _ContentInvoice.Trim)
            myComm.AddParam("?AE", _MeasureUnit.Trim)
            myComm.AddParam("?AF", _VatExempt.Trim)

        End Sub

#End Region

    End Class

End Namespace