﻿Public Module Constants

    ''' <summary>
    ''' A key of the <see cref="Csla.ApplicationContext.GlobalContext">ApplicationContext</see>
    ''' where the <see cref="ApskaitaObjects.Settings.CompanyInfo">CompanyInfo</see>
    ''' is stored for the current company.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Const KEY_COMPANY_INFO As String = "CompanyInfo"

    ''' <summary>
    ''' An ISO 639-1 language code for the base language.
    ''' </summary>
    ''' <remarks>Probably will be moved to the <see cref="General.Company">Company</see>
    ''' object in future.</remarks>
    Public Const LanguageCodeLith As String = "LT"

    ''' <summary>
    ''' An ISO 3166–1 alpha 2 state code for the base country.
    ''' </summary>
    ''' <remarks>Probably will be moved to the <see cref="General.Company">Company</see>
    ''' object in future.</remarks>
    Public Const StateCodeLith As String = "LT"

    ''' <summary>
    ''' A name of the file where the default <see cref="ApskaitaObjects.Settings.CommonSettings">
    ''' common settings</see> are stored.
    ''' </summary>
    ''' <remarks>In server environment the same file is used for settings persistence.</remarks>
    Friend Const SETTINGSFILENAME As String = "CommonSettings.xmls"

    ''' <summary>
    ''' A name of the folder where the user reports (*.rdl files) are stored.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Const USERREPORTSFOLDER As String = "UserReports"

    ''' <summary>
    ''' A gauge name of a user report file (*.rdl) name.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Const USERREPORTFILENAME As String = "UserReport{0}.rdl"

    ' TODO: Remove and implement open/save file in F_WorkTimeClasses instead
    Friend Const WORKTIMECLASSES_FILE As String = "WTClasses.dat"

    ''' <summary>
    ''' Average days in year, used in various calculations.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const AVERAGEDAYSINYEAR As Integer = 365

    ''' <summary>
    ''' A number of decimal places for currency rates.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ROUNDCURRENCYRATE As Integer = 6

    ''' <summary>
    ''' A number of decimal places for unit values in invoices made,
    ''' e.g. <see cref="Documents.InvoiceMadeItem.UnitValue">InvoiceMadeItem.UnitValue</see>.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ROUNDUNITINVOICEMADE As Integer = 4

    ''' <summary>
    ''' A number of decimal places for amount values in invoices made,
    ''' e.g. <see cref="Documents.InvoiceMadeItem.Ammount">InvoiceMadeItem.Ammount</see>.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ROUNDAMOUNTINVOICEMADE As Integer = 4

    ''' <summary>
    ''' A number of decimal places for unit values in invoices received,
    ''' e.g. <see cref="Documents.InvoiceReceivedItem.UnitValue">InvoiceReceivedItem.UnitValue</see>.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ROUNDUNITINVOICERECEIVED As Integer = 4

    ''' <summary>
    ''' A number of decimal places for amount values in invoices received,
    ''' e.g. <see cref="Documents.InvoiceReceivedItem.Ammount">InvoiceReceivedItem.Ammount</see>.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ROUNDAMOUNTINVOICERECEIVED As Integer = 4

    ''' <summary>
    ''' A number of decimal places for long term asset unit values,
    ''' e.g. <see cref="Assets.OperationAmortization.UnitValueChange">OperationAmortization.UnitValueChange</see>.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ROUNDUNITASSET As Integer = 4

    ''' <summary>
    ''' A number of decimal places for goods amount values,
    ''' e.g. <see cref="Goods.GoodsOperationDiscard.Ammount">GoodsOperationDiscard.Ammount</see>.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ROUNDAMOUNTGOODS As Integer = 6

    ''' <summary>
    ''' A number of decimal places for goods unit values,
    ''' e.g. <see cref="Goods.GoodsOperationDiscard.UnitCost">GoodsOperationDiscard.UnitCost</see>.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ROUNDUNITGOODS As Integer = 6

    ''' <summary>
    ''' A number of decimal places for work hours values,
    ''' e.g. <see cref="Workers.WageItem.TotalHoursWorked">Workers.WageItem.TotalHoursWorked</see>.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ROUNDWORKHOURS As Integer = 4

    ''' <summary>
    ''' A number of decimal places for workload values,
    ''' e.g. <see cref="Workers.Contract.WorkLoad">Workers.Contract.WorkLoad</see>.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ROUNDWORKLOAD As Integer = 4

    ''' <summary>
    ''' A number of decimal places for unused annual holiday amounts,
    ''' e.g. <see cref="Workers.WageItem.UnusedHolidayDaysForCompensation">Workers.WageItem.UnusedHolidayDaysForCompensation</see>.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ROUNDACCUMULATEDHOLIDAY As Integer = 4

    ''' <summary>
    ''' A number of decimal places for annual work days ratio,
    ''' e.g. <see cref="Workers.WageItem.AnnualWorkingDaysRatio">Workers.WageItem.AnnualWorkingDaysRatio</see>.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ROUNDWORKDAYSRATIO As Integer = 4

    ''' <summary>
    ''' A number of decimal places for work years,
    ''' e.g. <see cref="ActiveReports.HolidayCalculationPeriod.LengthYears">HolidayCalculationPeriod.LengthYears</see>.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ROUNDWORKYEARS As Integer = 4

    ''' <summary>
    ''' A format string for <see cref="Documents.TillIncomeOrder.FullDocumentNumber">TillIncomeOrder.FullDocumentNumber</see>,
    ''' where the first argument is an order date and the second argument is a running number.
    ''' </summary>
    ''' <remarks>Only used when <see cref="General.Company.AddDateToTillIncomeOrderNumber">Company.AddDateToTillIncomeOrderNumber</see>
    ''' is set to TRUE.</remarks>
    Public Const TILLINCOMEORDERFULLNUMBERFORMATWITHDATE As String = "{0}-{1}"

    ''' <summary>
    ''' A format string for a till income order date as it should be displayed in
    ''' <see cref="Documents.TillIncomeOrder.FullDocumentNumber">TillIncomeOrder.FullDocumentNumber</see>.
    ''' </summary>
    ''' <remarks>Only used when <see cref="General.Company.AddDateToTillIncomeOrderNumber">Company.AddDateToTillIncomeOrderNumber</see>
    ''' is set to TRUE.</remarks>
    Public Const TILLINCOMEORDERDATEFORMATINNUMBER As String = "yyyyMMdd"

    ''' <summary>
    ''' A format string for <see cref="Documents.TillSpendingsOrder.FullDocumentNumber">TillSpendingsOrder.FullDocumentNumber</see>,
    ''' where the first argument is an order date and the second argument is a running number.
    ''' </summary>
    ''' <remarks>Only used when <see cref="General.Company.AddDateToTillSpendingsOrderNumber">Company.AddDateToTillSpendingsOrderNumber</see>
    ''' is set to TRUE.</remarks>
    Public Const TILLSPENDINGSORDERFULLNUMBERFORMATWITHDATE As String = "{0}-{1}"

    ''' <summary>
    ''' A format string for a till spendings order date as it should be displayed in
    ''' <see cref="Documents.TillSpendingsOrder.FullDocumentNumber">TillSpendingsOrder.FullDocumentNumber</see>.
    ''' </summary>
    ''' <remarks>Only used when <see cref="General.Company.AddDateToTillSpendingsOrderNumber">Company.AddDateToTillSpendingsOrderNumber</see>
    ''' is set to TRUE.</remarks>
    Public Const TILLSPENDINGSORDERDATEFORMATINNUMBER As String = "yyyyMMdd"

End Module
