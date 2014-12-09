Imports ApskaitaObjects.General
Namespace Settings

    <Serializable()> _
    Public Class CompanyInfo
        Inherits Csla.ReadOnlyBase(Of CompanyInfo)

#Region " Business Methods "

        Private _BaseCurrency As String = "LTL"
        Private _Code As String = ""
        Private _Name As String = ""
        Private _CodeVat As String = ""
        Private _Email As String = ""
        Private _HeadPerson As String = ""
        Private _Accountant As String = ""
        Private _Cashier As String = ""
        Private _CodeSODRA As String = ""
        Private _Address As String = ""
        Private _BankAccount As String = ""
        Private _Bank As String = ""

        Private _NumbersInInvoice As Integer = 0
        Private _AddDateToInvoiceNumber As Boolean = False
        Private _AddDateToTillIncomeOrderNumber As Boolean = False
        Private _AddDateToTillSpendingsOrderNumber As Boolean = False
        Private _DefaultInvoiceMadeContent As String = ""
        Private _DefaultInvoiceReceivedContent As String = ""
        Private _MeasureUnitInvoiceMade As String = ""
        Private _MeasureUnitInvoiceReceived As String = ""
        Private _DiscountName As String = ""

        Private _AccountClassPrefix11 As Integer = 1
        Private _AccountClassPrefix12 As Integer = 0
        Private _AccountClassPrefix21 As Integer = 2
        Private _AccountClassPrefix22 As Integer = 0
        Private _AccountClassPrefix31 As Integer = 3
        Private _AccountClassPrefix32 As Integer = 0
        Private _AccountClassPrefix41 As Integer = 4
        Private _AccountClassPrefix42 As Integer = 0
        Private _AccountClassPrefix51 As Integer = 5
        Private _AccountClassPrefix52 As Integer = 0
        Private _AccountClassPrefix61 As Integer = 6
        Private _AccountClassPrefix62 As Integer = 0

        Private _DefaultTaxNpdFormula As String = ""

        Private _Accounts As CompanyAccountInfoList
        Private _Rates As CompanyRateInfoList

        Private _LastClosingDate As Date = Date.MinValue


        Public ReadOnly Property BaseCurrency() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BaseCurrency.Trim.ToUpper
            End Get
        End Property

        Public ReadOnly Property Code() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Code.Trim
            End Get
        End Property

        Public ReadOnly Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
        End Property

        Public ReadOnly Property CodeVat() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CodeVat.Trim
            End Get
        End Property

        Public ReadOnly Property Address() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Address.Trim
            End Get
        End Property

        Public ReadOnly Property BankAccount() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BankAccount.Trim
            End Get
        End Property

        Public ReadOnly Property Bank() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Bank.Trim
            End Get
        End Property

        Public ReadOnly Property Email() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Email.Trim
            End Get
        End Property

        Public ReadOnly Property HeadPerson() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _HeadPerson.Trim
            End Get
        End Property

        Public ReadOnly Property Accountant() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Accountant.Trim
            End Get
        End Property

        Public ReadOnly Property Cashier() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Cashier.Trim
            End Get
        End Property

        Public ReadOnly Property CodeSODRA() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CodeSODRA.Trim
            End Get
        End Property

        Public ReadOnly Property NumbersInInvoice() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NumbersInInvoice
            End Get
        End Property

        Public ReadOnly Property AddDateToInvoiceNumber() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AddDateToInvoiceNumber
            End Get
        End Property

        Public ReadOnly Property AddDateToTillIncomeOrderNumber() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AddDateToTillIncomeOrderNumber
            End Get
        End Property

        Public ReadOnly Property AddDateToTillSpendingsOrderNumber() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AddDateToTillSpendingsOrderNumber
            End Get
        End Property

        Public ReadOnly Property DefaultInvoiceMadeContent() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DefaultInvoiceMadeContent.Trim
            End Get
        End Property

        Public ReadOnly Property DefaultInvoiceReceivedContent() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DefaultInvoiceReceivedContent.Trim
            End Get
        End Property

        Public ReadOnly Property MeasureUnitInvoiceReceived() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MeasureUnitInvoiceReceived.Trim
            End Get
        End Property

        Public ReadOnly Property MeasureUnitInvoiceMade() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MeasureUnitInvoiceMade.Trim
            End Get
        End Property



        Public ReadOnly Property AccountClassPrefix11() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix11
            End Get
        End Property

        Public ReadOnly Property AccountClassPrefix12() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix12
            End Get
        End Property

        Public ReadOnly Property AccountClassPrefix21() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix21
            End Get
        End Property

        Public ReadOnly Property AccountClassPrefix22() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix22
            End Get
        End Property

        Public ReadOnly Property AccountClassPrefix31() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix31
            End Get
        End Property

        Public ReadOnly Property AccountClassPrefix32() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix32
            End Get
        End Property

        Public ReadOnly Property AccountClassPrefix41() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix41
            End Get
        End Property

        Public ReadOnly Property AccountClassPrefix42() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix42
            End Get
        End Property

        Public ReadOnly Property AccountClassPrefix51() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix51
            End Get
        End Property

        Public ReadOnly Property AccountClassPrefix52() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix52
            End Get
        End Property

        Public ReadOnly Property AccountClassPrefix61() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix61
            End Get
        End Property

        Public ReadOnly Property AccountClassPrefix62() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix62
            End Get
        End Property


        Public ReadOnly Property Accounts() As CompanyAccountInfoList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Accounts
            End Get
        End Property

        Public ReadOnly Property Rates() As CompanyRateInfoList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Rates
            End Get
        End Property


        Public ReadOnly Property DefaultTaxNpdFormula() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DefaultTaxNpdFormula.Trim
            End Get
        End Property


        ''' <summary>
        ''' Gets a date when accounting info was transfered to the program or 5/6 classes were last closed.
        ''' </summary>
        Public ReadOnly Property LastClosingDate() As Date
            Get
                Return _LastClosingDate
            End Get
        End Property


        Public Function GetDefaultAccount(ByVal AccountType As DefaultAccountType) As Long
            For Each c As CompanyAccountInfo In _Accounts
                If c.Type = AccountType Then Return c.Value
            Next
            Return 0
        End Function

        Public Function GetDefaultRate(ByVal RequiredRateType As RateType) As Long
            For Each c As CompanyRateInfo In _Rates
                If c.Type = RequiredRateType Then Return c.Value
            Next
            Return 0
        End Function

        Protected Overrides Function GetIdValue() As Object
            Return _Code
        End Function

        ''' <summary>
        ''' Returns short info about the company in format "Company name, [code]".
        ''' </summary>
        Public Overrides Function ToString() As String
            Return _Name & ", " & _Code
        End Function

        ''' <summary>
        ''' Returns TRUE if current settings contain enough info to create WageSheet.
        ''' </summary>
        Public Function IsSettingsReadyForWageSheet() As Boolean

            Return Not (_Rates.GetRate(RateType.WageRateDeviations) < 100 OrElse _
                _Rates.GetRate(RateType.WageRateNight) < 150 OrElse _
                _Rates.GetRate(RateType.WageRateOvertime) < 150 OrElse _
                _Rates.GetRate(RateType.WageRatePublicHolidays) < 200 OrElse _
                _Rates.GetRate(RateType.WageRateRestTime) < 200 OrElse _
                Not _Rates.GetRate(RateType.WageRateSickLeave) > 0 OrElse _
                Not _Rates.GetRate(RateType.GpmWage) > 0 OrElse _
                Not _Rates.GetRate(RateType.PsdEmployee) > 0 OrElse _
                Not _Rates.GetRate(RateType.PsdEmployer) > 0 OrElse _
                Not _Rates.GetRate(RateType.SodraEmployee) > 0 OrElse _
                Not _Rates.GetRate(RateType.SodraEmployer) > 0 OrElse _
                Not _Accounts.GetAccount(DefaultAccountType.WageGpmPayable) > 0 OrElse _
                Not _Accounts.GetAccount(DefaultAccountType.WageGuaranteeFundPayable) > 0 OrElse _
                Not _Accounts.GetAccount(DefaultAccountType.WageImprestPayable) > 0 OrElse _
                Not _Accounts.GetAccount(DefaultAccountType.WagePayable) > 0 OrElse _
                Not _Accounts.GetAccount(DefaultAccountType.WagePsdPayable) > 0 OrElse _
                Not _Accounts.GetAccount(DefaultAccountType.WageSodraPayable) > 0 OrElse _
                Not _Accounts.GetAccount(DefaultAccountType.WageWithdraw) > 0 OrElse _
                String.IsNullOrEmpty(Me._DefaultTaxNpdFormula.Trim))

        End Function

        ''' <summary>
        ''' Returns TRUE if current settings contain enough info to create ImprestSheet.
        ''' </summary>
        Public Function IsSettingsReadyForImprestSheet() As Boolean
            Return (_Accounts.GetAccount(DefaultAccountType.WagePayable) > 0 _
                AndAlso _Accounts.GetAccount(DefaultAccountType.WageImprestPayable) > 0)
        End Function

#End Region

#Region " Factory Methods "

        Private Sub New(ByVal Database As String, ByVal Password As String)
            Fetch(Database, Password)
        End Sub

        Friend Shared Sub LoadCompanyInfoToGlobalContext(ByVal Database As String, _
            ByVal Password As String)

            If ApplicationContext.GlobalContext.Contains(KeyCompanyInfo) Then _
                ApplicationContext.GlobalContext.Remove(KeyCompanyInfo)
            Dim NewCompanyInfo As New CompanyInfo(Database, Password)
            ApplicationContext.GlobalContext.Add(KeyCompanyInfo, NewCompanyInfo)

        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal Database As String, ByVal Password As String)
            FetchCompanyInfo(Database, Password, AddressOf CustomFetchMethod)
        End Sub

        Private Sub CustomFetchMethod()

            Dim myComm As New SQLCommand("FetchCompanyInfo")

            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Throw New Exception( _
                    "Klaida. Nerasti bendri įmonės duomenys.)")

                Dim dr As DataRow = myData.Rows(0)

                _Code = CStrSafe(dr.Item(0)).Trim
                _Name = CStrSafe(dr.Item(1)).Trim
                _CodeVat = CStrSafe(dr.Item(2)).Trim
                _Email = CStrSafe(dr.Item(3)).Trim
                _HeadPerson = CStrSafe(dr.Item(4)).Trim
                _CodeSODRA = CStrSafe(dr.Item(5)).Trim
                _NumbersInInvoice = CIntSafe(dr.Item(6), 0)
                _AddDateToInvoiceNumber = ConvertDbBoolean(CIntSafe(dr.Item(7), 0))
                _DefaultInvoiceMadeContent = CStrSafe(dr.Item(8)).Trim
                _DefaultInvoiceReceivedContent = CStrSafe(dr.Item(9)).Trim
                _AccountClassPrefix11 = CIntSafe(dr.Item(10), 0)
                _AccountClassPrefix12 = CIntSafe(dr.Item(11), 0)
                _AccountClassPrefix21 = CIntSafe(dr.Item(12), 0)
                _AccountClassPrefix22 = CIntSafe(dr.Item(13), 0)
                _AccountClassPrefix31 = CIntSafe(dr.Item(14), 0)
                _AccountClassPrefix32 = CIntSafe(dr.Item(15), 0)
                _AccountClassPrefix41 = CIntSafe(dr.Item(16), 0)
                _AccountClassPrefix42 = CIntSafe(dr.Item(17), 0)
                _AccountClassPrefix51 = CIntSafe(dr.Item(18), 0)
                _AccountClassPrefix52 = CIntSafe(dr.Item(19), 0)
                _AccountClassPrefix61 = CIntSafe(dr.Item(20), 0)
                _AccountClassPrefix62 = CIntSafe(dr.Item(21), 0)
                _DefaultTaxNpdFormula = CStrSafe(dr.Item(22)).Trim
                _MeasureUnitInvoiceReceived = CStrSafe(dr.Item(23)).Trim
                _MeasureUnitInvoiceMade = CStrSafe(dr.Item(24)).Trim
                _Address = CStrSafe(dr.Item(25)).Trim
                _Bank = CStrSafe(dr.Item(26)).Trim
                _BankAccount = CStrSafe(dr.Item(27)).Trim
                _AddDateToTillIncomeOrderNumber = ConvertDbBoolean(CIntSafe(dr.Item(28), 0))
                _AddDateToTillSpendingsOrderNumber = ConvertDbBoolean(CIntSafe(dr.Item(29), 0))
                _BaseCurrency = CStrSafe(dr.Item(30)).Trim
                If String.IsNullOrEmpty(_BaseCurrency.Trim) Then _BaseCurrency = "LTL"
                _Accountant = CStrSafe(dr.Item(31)).Trim
                _Cashier = CStrSafe(dr.Item(32)).Trim
                _LastClosingDate = CDateSafe(dr.Item(33), Date.MinValue)

            End Using

            _Accounts = CompanyAccountInfoList.GetCompanyAccountInfoList
            _Rates = CompanyRateInfoList.GetCompanyRateInfoList

        End Sub

#End Region

    End Class

End Namespace
