Namespace General

    <Serializable()> _
    Public Class Account
        Inherits BusinessBase(Of Account)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _ID As Long = 0
        Private _OldID As Long = 0
        Private _Name As String = ""
        Private _AssociatedReportItem As String = ""
        Private _Class As Byte = 0


        Public Property ID() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _ID <> value Then
                    _ID = value
                    PropertyHasChanged()
                    _Class = GetAccountClass(_ID)
                    PropertyHasChanged("Class")
                End If
            End Set
        End Property

        Public Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Name.Trim <> value.Trim Then
                    _Name = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property AssociatedReportItem() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AssociatedReportItem.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _AssociatedReportItem.Trim <> value.Trim Then
                    _AssociatedReportItem = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property [Class]() As Byte
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Class
            End Get
        End Property



        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return "Klaida (-os) eilutėje '" & _Name & "': " & _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return "Eilutėje '" & _Name & "' gali būti klaida: " & _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
        End Function

        Public Shared Function GetAccountClass(ByVal AccountID As Long) As Byte

            Dim CurrCompany As ApskaitaObjects.Settings.CompanyInfo = GetCurrentCompany()

            If (CIntSafe(AccountID.ToString.Substring(0, 1), 0) = CurrCompany.AccountClassPrefix11 _
                OrElse (CurrCompany.AccountClassPrefix12 > 0 AndAlso _
                CurrCompany.AccountClassPrefix12 = CIntSafe(AccountID.ToString.Substring(0, 1), 0))) Then
                Return 1
            ElseIf (CIntSafe(AccountID.ToString.Substring(0, 1), 0) = CurrCompany.AccountClassPrefix21 _
                OrElse (CurrCompany.AccountClassPrefix22 > 0 AndAlso _
                CurrCompany.AccountClassPrefix22 = CIntSafe(AccountID.ToString.Substring(0, 1), 0))) Then
                Return 2
            ElseIf (CIntSafe(AccountID.ToString.Substring(0, 1), 0) = CurrCompany.AccountClassPrefix31 _
                OrElse (CurrCompany.AccountClassPrefix32 > 0 AndAlso _
                CurrCompany.AccountClassPrefix32 = CIntSafe(AccountID.ToString.Substring(0, 1), 0))) Then
                Return 3
            ElseIf (CIntSafe(AccountID.ToString.Substring(0, 1), 0) = CurrCompany.AccountClassPrefix41 _
                OrElse (CurrCompany.AccountClassPrefix42 > 0 AndAlso _
                CurrCompany.AccountClassPrefix42 = CIntSafe(AccountID.ToString.Substring(0, 1), 0))) Then
                Return 4
            ElseIf (CIntSafe(AccountID.ToString.Substring(0, 1), 0) = CurrCompany.AccountClassPrefix51 _
                OrElse (CurrCompany.AccountClassPrefix52 > 0 AndAlso _
                CurrCompany.AccountClassPrefix52 = CIntSafe(AccountID.ToString.Substring(0, 1), 0))) Then
                Return 5
            ElseIf (CIntSafe(AccountID.ToString.Substring(0, 1), 0) = CurrCompany.AccountClassPrefix61 _
                OrElse (CurrCompany.AccountClassPrefix62 > 0 AndAlso _
                CurrCompany.AccountClassPrefix62 = CIntSafe(AccountID.ToString.Substring(0, 1), 0))) Then
                Return 6
            Else
                Return 0
            End If

        End Function

        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            If Not _ID > 0 Then Return ""
            Return _Name
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.ValueUniqueInCollection, _
                New CommonValidation.SimpleRuleArgs("ID", "sąskaitos numeris"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("ID", "sąskaitos numeris"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Name", "sąskaitos pavadinimas"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("AssociatedReportItem", _
                "susieta finansinės atskaitomybės eilutė"))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewAccount() As Account
            Dim result As New Account
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Friend Shared Function NewAccount(ByVal s As String) As Account
            Return New Account(s)
        End Function

        Friend Shared Function GetAccount(ByVal dr As DataRow) As Account
            Return New Account(dr)
        End Function

        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As DataRow)
            MarkAsChild()
            Fetch(dr)
        End Sub

        Private Sub New(ByVal s As String)
            MarkAsChild()
            FetchFromFile(s)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow)

            _ID = CLongSafe(dr.Item(0), 0)
            _OldID = CLongSafe(dr.Item(0), 0)
            _Name = dr.Item(1).ToString
            _AssociatedReportItem = dr.Item(2).ToString
            _Class = GetAccountClass(_ID)
            Me.MarkOld()

        End Sub

        Private Sub FetchFromFile(ByVal s As String)

            _ID = CLongSafe(GetElement(s, 0), 0)
            _OldID = _ID
            _Name = GetElement(s, 1)
            _AssociatedReportItem = GetElement(s, 2)
            _Class = GetAccountClass(_ID)

        End Sub

        Friend Sub Insert(ByVal parent As AccountList)

            Dim myComm As New SQLCommand("InsertAccount")
            myComm.AddParam("?SN", _ID)
            myComm.AddParam("?SP", _Name)
            myComm.AddParam("?RS", _AssociatedReportItem)

            myComm.Execute()

            Me.MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As AccountList)

            Dim myComm As New SQLCommand("UpdateAccount")
            myComm.AddParam("?SN", _ID)
            myComm.AddParam("?SP", _Name)
            myComm.AddParam("?RS", _AssociatedReportItem)
            myComm.AddParam("?TN", _OldID)

            myComm.Execute()

            ' UPDATE account numbers in other tables if it has changed
            If _ID <> _OldID AndAlso Not IsNew Then

                For i As Integer = 1 To 49

                    myComm = New SQLCommand("UpdateAccountsInDocuments" & i.ToString)
                    myComm.AddParam("?AA", _ID)
                    myComm.AddParam("?AB", _OldID)

                    myComm.Execute()

                Next

            End If

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteAccount")
            myComm.AddParam("?NR", _OldID)

            myComm.Execute()

            MarkNew()

        End Sub

        Friend Sub CheckIfCanDelete()

            Dim myComm As New SQLCommand("AccountWasUsed")
            myComm.AddParam("?CD", _OldID)
            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Exit Sub

                Dim typeDictionary As New Dictionary(Of String, String)
                typeDictionary.Add("AccumulativeCosts".Trim.ToLower, "sukauptų sąnaudų operacijoje")
                typeDictionary.Add("AdvanceReports".Trim.ToLower, "avanso apyskaitoje")
                typeDictionary.Add("Asmenys".Trim.ToLower, "kontrahento duomenyse")
                typeDictionary.Add("BankOperations".Trim.ToLower, "banko operacijoje")
                typeDictionary.Add("bzdata".Trim.ToLower, "bendrojo žurnalo operacijoje")
                typeDictionary.Add("CashAccounts".Trim.ToLower, "lėšų apskaitos sąskaitos duomenyse")
                typeDictionary.Add("CompanyAccounts".Trim.ToLower, "standartinėse įmonės sąskaitose")
                typeDictionary.Add("du_ziniarastis".Trim.ToLower, "darbo užmokesčio žiniaraštyje")
                typeDictionary.Add("goods".Trim.ToLower, "prekės duomenyse")
                typeDictionary.Add("goodscomplexoperations".Trim.ToLower, "kompleksinėje prekių operacijoje")
                typeDictionary.Add("goodsoperations".Trim.ToLower, "prekių operacijoje")
                typeDictionary.Add("goodsaccounts".Trim.ToLower, "prekių apskaitos sąskaitų pakeitimo operacijoje")
                typeDictionary.Add("InvoicesMade".Trim.ToLower, "išrašytoje sąskaitoje faktūroje")
                typeDictionary.Add("InvoicesReceived".Trim.ToLower, "gautoje sąskaitoje faktūroje")
                typeDictionary.Add("kalkuliac_d".Trim.ToLower, "gamybos kalkuliacijos kortelės duomenyse")
                typeDictionary.Add("kio".Trim.ToLower, "kasos išlaidų orderyje")
                typeDictionary.Add("kpo".Trim.ToLower, "kasos pajamų orderyje")
                typeDictionary.Add("OffsetItems".Trim.ToLower, "užskaitos operacijoje")
                typeDictionary.Add("Paslaugos".Trim.ToLower, "paslaugos duomenyse")
                typeDictionary.Add("Tipines_data".Trim.ToLower, "bednrojo žurnalo operacijos šablono duomenyse")
                typeDictionary.Add("Turtas".Trim.ToLower, "ilgalaikio turto duomenyse")
                typeDictionary.Add("Turtas_op".Trim.ToLower, "ilgalaikio turto operacijoje")
                typeDictionary.Add("warehouses".Trim.ToLower, "prekių sandėlio duomenyse")

                Dim result As String = "Klaida. Sąskaita " & _OldID.ToString _
                    & " yra naudojama apskaitos duomenyse:" & vbCrLf

                Dim typeString As String
                For Each dr As DataRow In myData.Rows
                    typeString = typeDictionary.Item(CStrSafe(dr.Item(0)).Trim.ToLower)
                    If typeString Is Nothing OrElse String.IsNullOrEmpty(typeString.Trim) Then _
                        typeString = "nenustatytoje programos vietoje"
                    result = AddWithNewLine(result, "* " & typeString & " - objekto ID=" _
                        & CIntSafe(dr.Item(1), 0).ToString & ", operacijos ID=" _
                        & CIntSafe(dr.Item(2), 0).ToString & ", operacijos data - " _
                        & CDateSafe(dr.Item(3), Date.MinValue).ToString("yyyy-MM-dd") & ".", False)
                Next

                Throw New Exception(result)

            End Using

        End Sub

#End Region

    End Class

End Namespace