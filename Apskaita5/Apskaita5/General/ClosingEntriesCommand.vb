Namespace General

    ''' <summary>
    ''' Represents a command to close revenue and costs <see cref="General.Account">accounts</see> 
    ''' at the end of the accounting period (usualy calendar year).
    ''' </summary>
    ''' <remarks>Creates spefific type - <see cref="DocumentType.ClosingEntries">ClosingEntries</see> - 
    ''' of <see cref="General.JournalEntry">JournalEntry</see>. Does not write any data outside normal 
    ''' <see cref="General.JournalEntry">JournalEntry</see> scope.</remarks>
    <Serializable()> _
    Public Class ClosingEntriesCommand
        Inherits CommandBase

#Region " Authorization Rules "

        Public Shared Function CanExecuteCommand() As Boolean
            Return Csla.ApplicationContext.User.IsInRole("General.ClosingEntriesCommand3")
        End Function

#End Region

#Region " Client-side Code "

        Private mResult As Integer
        Private _Date As Date
        Private _ConsolidatedAccount As Long
        Private _CurrentProfitAccount As Long
        Private _FormerProfitAccount As Long

        ''' <summary>
        ''' Date of the closing operation (last day of the period).
        ''' </summary>
        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        ''' <summary>
        ''' Technical account used for closure. Credited by the total amount of costs nominal accounts 
        ''' and debited by the total amount of revenue nominal accounts.
        ''' </summary>
        ''' <remarks>Use <see cref="General.CompanyAccount">default company account</see>
        ''' of type <see cref="General.DefaultAccountType.ClosingSummary">ClosingSummary</see> 
        ''' as provided by <see cref="Settings.CompanyInfo.GetDefaultAccount">Settings.CompanyInfo.GetDefaultAccount</see> method.</remarks>
        Public ReadOnly Property ConsolidatedAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ConsolidatedAccount
            End Get
        End Property

        ''' <summary>
        ''' Account where the result (income/loss) for the current period is stored.
        ''' </summary>
        ''' <remarks>Use <see cref="General.CompanyAccount">default company account</see>
        ''' of type <see cref="General.DefaultAccountType.CurrentProfit">CurrentProfit</see> 
        ''' as provided by <see cref="Settings.CompanyInfo.GetDefaultAccount">Settings.CompanyInfo.GetDefaultAccount</see> method.</remarks>
        Public ReadOnly Property CurrentProfitAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentProfitAccount
            End Get
        End Property

        ''' <summary>
        ''' Account where the result (income/loss) for the previous periods is stored.
        ''' </summary>
        ''' <remarks>Use <see cref="General.CompanyAccount">default company account</see>
        ''' of type <see cref="General.DefaultAccountType.FormerProfit">FormerProfit</see> 
        ''' as provided by <see cref="Settings.CompanyInfo.GetDefaultAccount">Settings.CompanyInfo.GetDefaultAccount</see> method.</remarks>
        Public ReadOnly Property FormerProfitAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FormerProfitAccount
            End Get
        End Property

        ''' <summary>
        ''' Database ID of the closing operation in the general ledger.
        ''' </summary>
        Public ReadOnly Property Result() As Integer
            Get
                Return mResult
            End Get
        End Property


        Private Sub BeforeServer()
            ' implement code to run on client
            ' before server is called
        End Sub

        Private Sub AfterServer()
            ' implement code to run on client
            ' after server is called
        End Sub

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Closes revenue and costs nominal <see cref="General.Account">accounts</see> at the end of the period
        ''' and creates a <see cref="General.JournalEntry">JournalEntry</see> of type
        ''' <see cref="DocumentType.ClosingEntries">ClosingEntries</see> in the general ledger.
        ''' </summary>
        ''' <param name="nDate">Date of the closing operation (last day of the period).</param>
        ''' <param name="nConsolidatedAccount">Technical account used for closure. 
        ''' Credited by the total amount of costs nominal accounts 
        ''' and debited by the total amount of revenue nominal accounts. 
        ''' A <see cref="CompanyAccount">CompanyAccount</see> of type 
        ''' <see cref="DefaultAccountType.ClosingSummary">DefaultAccountType.ClosingSummary</see>
        ''' should be used as default.</param>
        ''' <param name="nCurrentProfitAccount">Account where the result (income/loss) for the current period is stored.
        ''' A <see cref="CompanyAccount">CompanyAccount</see> of type 
        ''' <see cref="DefaultAccountType.CurrentProfit">DefaultAccountType.CurrentProfit</see>
        ''' should be used as default.</param>
        ''' <param name="nFormerProfitAccount">Account where the result (income/loss) for the previous periods is stored.
        ''' A <see cref="CompanyAccount">CompanyAccount</see> of type 
        ''' <see cref="DefaultAccountType.FormerProfit">DefaultAccountType.FormerProfit</see>
        ''' should be used as default.</param>
        ''' <returns>Database ID of the closing operation in the general ledger.</returns>
        ''' <remarks></remarks>
        Public Shared Function TheCommand(ByVal nDate As Date, ByVal nConsolidatedAccount As Long, _
            ByVal nCurrentProfitAccount As Long, ByVal nFormerProfitAccount As Long) As Integer

            If nDate.Date <= GetCurrentCompany.LastClosingDate.Date Then
                Throw New Exception(String.Format(My.Resources.General_ClosingEntriesCommand_InvalidDate, _
                    nDate.ToString("yyyy-MM-dd"), GetCurrentCompany.LastClosingDate.ToString("yyyy-MM-dd")))
            End If

            If Not nConsolidatedAccount > 0 Then
                Throw New Exception(My.Resources.General_ClosingEntriesCommand_ConsolidatedAccountNull)
            End If

            Dim cmd As New ClosingEntriesCommand(nDate, nConsolidatedAccount, _
                nCurrentProfitAccount, nFormerProfitAccount)

            cmd.BeforeServer()
            cmd = DataPortal.Execute(Of ClosingEntriesCommand)(cmd)
            cmd.AfterServer()

            Return cmd.Result

        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal nDate As Date, ByVal nConsolidatedAccount As Long, _
            ByVal nCurrentProfitAccount As Long, ByVal nFormerProfitAccount As Long)
            _Date = nDate.Date
            _ConsolidatedAccount = nConsolidatedAccount
            _CurrentProfitAccount = nCurrentProfitAccount
            _FormerProfitAccount = nFormerProfitAccount
        End Sub

#End Region

#Region " Server-side Code "

        Protected Overrides Sub DataPortal_Execute()

            If Not CanExecuteCommand() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            If (Not GetCurrentCompany.AccountClassPrefix51 > 0 AndAlso _
                Not GetCurrentCompany.AccountClassPrefix52 > 0) OrElse _
                (Not GetCurrentCompany.AccountClassPrefix61 > 0 AndAlso _
                Not GetCurrentCompany.AccountClassPrefix62 > 0) Then
                Throw New Exception(My.Resources.General_ClosingEntriesCommand_AccountClassPrefixNull)
            End If

            Dim myComm As New SQLCommand("ClosingResultsSelect")
            myComm.AddParam("?DT", _Date)
            myComm.AddParam("?AA", GetCurrentCompany.AccountClassPrefix51.ToString & GetWildcart())
            myComm.AddParam("?AB", GetCurrentCompany.AccountClassPrefix52.ToString & GetWildcart())
            myComm.AddParam("?AC", GetCurrentCompany.AccountClassPrefix61.ToString & GetWildcart())
            myComm.AddParam("?AD", GetCurrentCompany.AccountClassPrefix62.ToString & GetWildcart())

            Dim CreditSum As Double = 0
            Dim DebetSum As Double = 0
            Dim NewEntry As JournalEntry

            Using myData As DataTable = myComm.Fetch

                ' calculate balance plus totals
                For i As Integer = myData.Rows.Count To 1 Step -1

                    If Not CLongSafe(myData.Rows(i - 1).Item(0), 0) > 0 Then Throw New Exception( _
                        My.Resources.General_ClosingEntriesCommand_InvalidFetchResult)

                    If CDblSafe(myData.Rows(i - 1).Item(1), 2, 0) = CDblSafe(myData.Rows(i - 1).Item(2), 2, 0) Then
                        myData.Rows.RemoveAt(i - 1)
                    ElseIf CDblSafe(myData.Rows(i - 1).Item(1), 2, 0) > CDblSafe(myData.Rows(i - 1).Item(2), 2, 0) Then
                        myData.Rows(i - 1).Item(1) = CRound(CDblSafe(myData.Rows(i - 1).Item(1), 2, 0) _
                            - CDblSafe(myData.Rows(i - 1).Item(2), 2, 0))
                        myData.Rows(i - 1).Item(2) = 0
                        DebetSum = CRound(CDblSafe(myData.Rows(i - 1).Item(1), 2, 0) + DebetSum)
                    Else
                        myData.Rows(i - 1).Item(1) = 0
                        myData.Rows(i - 1).Item(2) = CRound(CDblSafe(myData.Rows(i - 1).Item(2), 2, 0) _
                            - CDblSafe(myData.Rows(i - 1).Item(1), 2, 0))
                        CreditSum = CRound(CDblSafe(myData.Rows(i - 1).Item(2), 2, 0) + CreditSum)
                    End If

                Next

                If Not myData.Rows.Count > 0 Then Throw New Exception( _
                    My.Resources.General_ClosingEntriesCommand_NoResidualAmount)

                NewEntry = JournalEntry.NewJournalEntryChild(DocumentType.ClosingEntries)

                NewEntry.Date = _Date.Date
                NewEntry.Content = My.Resources.General_ClosingEntriesCommand_DefaultContent
                NewEntry.DocNumber = My.Resources.General_ClosingEntriesCommand_DefaultNumber

                For Each dr As DataRow In myData.Rows
                    If CDblSafe(dr.Item(1), 2, 0) > 0 Then

                        NewEntry.CreditList.Add(General.BookEntry.NewBookEntry())
                        NewEntry.CreditList(NewEntry.CreditList.Count - 1).Account = _
                            CLongSafe(dr.Item(0), 0)
                        NewEntry.CreditList(NewEntry.CreditList.Count - 1).Amount = _
                            CDblSafe(dr.Item(1), 2, 0)

                    Else

                        NewEntry.DebetList.Add(General.BookEntry.NewBookEntry())
                        NewEntry.DebetList(NewEntry.DebetList.Count - 1).Account = _
                            CLongSafe(dr.Item(0), 0)
                        NewEntry.DebetList(NewEntry.DebetList.Count - 1).Amount = _
                            CDblSafe(dr.Item(2), 2, 0)

                    End If
                Next

            End Using

            ' add balance totals
            NewEntry.CreditList.Add(General.BookEntry.NewBookEntry())
            NewEntry.CreditList(NewEntry.CreditList.Count - 1).Account = _ConsolidatedAccount
            NewEntry.CreditList(NewEntry.CreditList.Count - 1).Amount = CRound(CreditSum)

            NewEntry.DebetList.Add(General.BookEntry.NewBookEntry())
            NewEntry.DebetList(NewEntry.DebetList.Count - 1).Account = _ConsolidatedAccount
            NewEntry.DebetList(NewEntry.DebetList.Count - 1).Amount = CRound(DebetSum)

            If _CurrentProfitAccount > 0 AndAlso _FormerProfitAccount > 0 Then

                myComm = New SQLCommand("FetchCurrentProfit")
                myComm.AddParam("?DT", _Date)
                myComm.AddParam("?AC", _CurrentProfitAccount)

                Using myData As DataTable = myComm.Fetch

                    If myData.Rows.Count > 0 Then

                        Dim dr As DataRow = myData.Rows(0)

                        ' move Current Profit to Former Profit Account
                        If CDblSafe(dr.Item(0), 2, 0) > CDblSafe(dr.Item(1), 2, 0) Then

                            ' Debit balance in Current Profit Account
                            NewEntry.CreditList.Add(General.BookEntry.NewBookEntry())
                            NewEntry.CreditList(NewEntry.CreditList.Count - 1).Account = _CurrentProfitAccount
                            NewEntry.CreditList(NewEntry.CreditList.Count - 1).Amount = _
                                CRound(CDblSafe(dr.Item(0), 2, 0) - CDblSafe(dr.Item(1), 2, 0))

                            NewEntry.DebetList.Add(General.BookEntry.NewBookEntry())
                            NewEntry.DebetList(NewEntry.DebetList.Count - 1).Account = _FormerProfitAccount
                            NewEntry.DebetList(NewEntry.DebetList.Count - 1).Amount = _
                                CRound(CDblSafe(dr.Item(0), 2, 0) - CDblSafe(dr.Item(1), 2, 0))

                        ElseIf CDblSafe(dr.Item(0), 2, 0) < CDblSafe(dr.Item(1), 2, 0) Then

                            ' Credit balance in Current Profit Account
                            NewEntry.CreditList.Add(General.BookEntry.NewBookEntry())
                            NewEntry.CreditList(NewEntry.CreditList.Count - 1).Account = _FormerProfitAccount
                            NewEntry.CreditList(NewEntry.CreditList.Count - 1).Amount = _
                                CRound(CDblSafe(dr.Item(1), 2, 0) - CDblSafe(dr.Item(0), 2, 0))

                            NewEntry.DebetList.Add(General.BookEntry.NewBookEntry())
                            NewEntry.DebetList(NewEntry.DebetList.Count - 1).Account = _CurrentProfitAccount
                            NewEntry.DebetList(NewEntry.DebetList.Count - 1).Amount = _
                                CRound(CDblSafe(dr.Item(1), 2, 0) - CDblSafe(dr.Item(0), 2, 0))

                        End If

                    End If

                End Using

            End If

            If _CurrentProfitAccount > 0 Then

                If CRound(DebetSum) > CRound(CreditSum) Then

                    ' Debit balance in Consolidated Account
                    NewEntry.CreditList.Add(General.BookEntry.NewBookEntry())
                    NewEntry.CreditList(NewEntry.CreditList.Count - 1).Account = _ConsolidatedAccount
                    NewEntry.CreditList(NewEntry.CreditList.Count - 1).Amount = _
                        CRound(DebetSum - CreditSum)

                    NewEntry.DebetList.Add(General.BookEntry.NewBookEntry())
                    NewEntry.DebetList(NewEntry.DebetList.Count - 1).Account = _CurrentProfitAccount
                    NewEntry.DebetList(NewEntry.DebetList.Count - 1).Amount = _
                        CRound(DebetSum - CreditSum)

                ElseIf CRound(DebetSum) < CRound(CreditSum) Then

                    ' Debit balance in Consolidated Account
                    NewEntry.CreditList.Add(General.BookEntry.NewBookEntry())
                    NewEntry.CreditList(NewEntry.CreditList.Count - 1).Account = _CurrentProfitAccount
                    NewEntry.CreditList(NewEntry.CreditList.Count - 1).Amount = _
                        CRound(CreditSum - DebetSum)

                    NewEntry.DebetList.Add(General.BookEntry.NewBookEntry())
                    NewEntry.DebetList(NewEntry.DebetList.Count - 1).Account = _ConsolidatedAccount
                    NewEntry.DebetList(NewEntry.DebetList.Count - 1).Amount = _
                        CRound(CreditSum - DebetSum)

                End If

            End If

            NewEntry = NewEntry.SaveChild()

            ' Last closing day is part of CompanyInfo object in GlobalContext
            ApskaitaObjects.Settings.CompanyInfo.LoadCompanyInfoToGlobalContext("", "")

            mResult = NewEntry.ID

        End Sub

#End Region

    End Class

End Namespace
