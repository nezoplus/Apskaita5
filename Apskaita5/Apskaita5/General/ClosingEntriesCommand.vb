Namespace General

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


        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        Public ReadOnly Property ConsolidatedAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ConsolidatedAccount
            End Get
        End Property

        Public ReadOnly Property CurrentProfitAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentProfitAccount
            End Get
        End Property

        Public ReadOnly Property FormerProfitAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FormerProfitAccount
            End Get
        End Property

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

        Public Shared Function TheCommand(ByVal nDate As Date, ByVal nConsolidatedAccount As Long, _
            ByVal nCurrentProfitAccount As Long, ByVal nFormerProfitAccount As Long) As Integer

            If nDate.Date <= GetCurrentCompany.LastClosingDate.Date Then _
                Throw New Exception("Klaida. Nurodyta operacijos data yra ankstesnė " & _
                    "nei paskutinio 5/6 klasių uždarymo data.")

            If Not nConsolidatedAccount > 0 Then Throw New Exception( _
                "Klaida. Nenurodyta suvestinės sąskaita.")

            Dim cmd As New ClosingEntriesCommand(nDate, nConsolidatedAccount, _
                nCurrentProfitAccount, nFormerProfitAccount)

            cmd.BeforeServer()
            cmd = DataPortal.Execute(Of ClosingEntriesCommand)(cmd)
            cmd.AfterServer()

            Return cmd.Result

        End Function

        Private Sub New(ByVal nDate As Date, ByVal nConsolidatedAccount As Integer, _
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
                "Klaida. Jūsų teisių nepakanka šiai operacijai.")

            Dim myComm As New SQLCommand("ClosingResultsSelect")
            myComm.AddParam("?DT", _Date)
            myComm.AddParam("?AA", GetCurrentCompany.AccountClassPrefix51)
            myComm.AddParam("?AB", GetCurrentCompany.AccountClassPrefix52)
            myComm.AddParam("?AC", GetCurrentCompany.AccountClassPrefix61)
            myComm.AddParam("?AD", GetCurrentCompany.AccountClassPrefix62)

            Dim CreditSum As Double = 0
            Dim DebetSum As Double = 0
            Dim NewEntry As JournalEntry

            Using myData As DataTable = myComm.Fetch

                ' calculate balance plus totals
                For i As Integer = myData.Rows.Count To 1 Step -1

                    If Not CLongSafe(myData.Rows(i - 1).Item(0), 0) > 0 Then Throw New Exception( _
                        "Klaida. Nekorektiškai gauti duomenys, lentelėje nenurodytas sąskaitos numeris.")

                    If CDblSafe(myData.Rows(i - 1).Item(1), 2, 0) = CDblSafe(myData.Rows(i - 1).Item(2), 2, 0) Then
                        myData.Rows.RemoveAt(i - 1)
                    ElseIf CDblSafe(myData.Rows(i - 1).Item(1), 2, 0) > CDblSafe(myData.Rows(i - 1).Item(2), 2, 0) Then
                        myData.Rows(i - 1).Item(1) = CRound(CDblSafe(myData.Rows(i - 1).Item(1), 2, 0) _
                            - CDblSafe(myData.Rows(i - 1).Item(2), 2, 0))
                        myData.Rows(i - 1).Item(2) = 0
                        DebetSum = CRound(CDblSafe(myData.Rows(i - 1).Item(1), 2, 0) + DebetSum)
                    Else
                        myData.Rows(i - 1).Item(2) = CRound(CDblSafe(myData.Rows(i - 1).Item(2), 2, 0) _
                            - CDblSafe(myData.Rows(i - 1).Item(1), 2, 0))
                        myData.Rows(i - 1).Item(1) = 0
                        CreditSum = CRound(CDblSafe(myData.Rows(i - 1).Item(2), 2, 0) + CreditSum)
                    End If

                Next

                If Not myData.Rows.Count > 0 Then Throw New Exception( _
                    "Klaida. Nėra 5/6 klasės likučių, kuriuos būtų galima uždaryti.")

                NewEntry = JournalEntry.NewJournalEntryChild(DocumentType.ClosingEntries)

                NewEntry.Date = _Date.Date
                NewEntry.Content = "5/6 klasių uždarymo įrašas"
                NewEntry.DocNumber = "UZD"

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

                        ' move Current Profit to Former Profit Account
                        If CDblSafe(myData.Rows(0).Item(0), 2, 0) > CDblSafe(myData.Rows(0).Item(1), 2, 0) Then

                            ' Debit balance in Current Profit Account
                            NewEntry.CreditList.Add(General.BookEntry.NewBookEntry())
                            NewEntry.CreditList(NewEntry.CreditList.Count - 1).Account = _CurrentProfitAccount
                            NewEntry.CreditList(NewEntry.CreditList.Count - 1).Amount = _
                                CRound(CDblSafe(myData.Rows(0).Item(0), 2, 0) _
                                - CDblSafe(myData.Rows(0).Item(1), 2, 0))

                            NewEntry.DebetList.Add(General.BookEntry.NewBookEntry())
                            NewEntry.DebetList(NewEntry.DebetList.Count - 1).Account = _FormerProfitAccount
                            NewEntry.DebetList(NewEntry.DebetList.Count - 1).Amount = _
                                CRound(CDblSafe(myData.Rows(0).Item(0), 2, 0) _
                                - CDblSafe(myData.Rows(0).Item(1), 2, 0))

                        ElseIf CDblSafe(myData.Rows(0).Item(0), 2, 0) < CDblSafe(myData.Rows(1).Item(0), 2, 0) Then

                            ' Credit balance in Current Profit Account
                            NewEntry.CreditList.Add(General.BookEntry.NewBookEntry())
                            NewEntry.CreditList(NewEntry.CreditList.Count - 1).Account = _FormerProfitAccount
                            NewEntry.CreditList(NewEntry.CreditList.Count - 1).Amount = _
                                CRound(CDblSafe(myData.Rows(0).Item(1), 2, 0) _
                                - CDblSafe(myData.Rows(0).Item(0), 2, 0))

                            NewEntry.DebetList.Add(General.BookEntry.NewBookEntry())
                            NewEntry.DebetList(NewEntry.DebetList.Count - 1).Account = _CurrentProfitAccount
                            NewEntry.DebetList(NewEntry.DebetList.Count - 1).Amount = _
                                CRound(CDblSafe(myData.Rows(0).Item(1), 2, 0) _
                                - CDblSafe(myData.Rows(0).Item(0), 2, 0))

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

            NewEntry = NewEntry.SaveServerSide()

            ' Last closing day is part of CompanyInfo object in GlobalContext
            ApskaitaObjects.Settings.CompanyInfo.LoadCompanyInfoToGlobalContext("", "")

            mResult = NewEntry.ID

        End Sub

#End Region

    End Class

End Namespace
