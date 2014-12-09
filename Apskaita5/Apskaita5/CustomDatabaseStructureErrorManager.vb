Imports AccDataAccessLayer.DatabaseAccess.DatabaseStructure
Imports ApskaitaObjects.Assets
<Serializable()> _
Public Class CustomDatabaseStructureErrorManager
    Implements IDatabaseStructureErrorManager

    Public Sub FetchCustomErrors(ByRef StructureErrorList As DatabaseStructureErrorList, _
        ByVal DeFactoDatabaseStructure As DatabaseStructure, ByVal DatabaseName As String) _
        Implements IDatabaseStructureErrorManager.FetchCustomErrors

        Dim IsFound As Boolean

        For Each tbl As DatabaseTable In DeFactoDatabaseStructure.TableList
            If tbl.Name.Trim.ToLower = "asmenys" Then
                For Each col As DatabaseField In tbl.FieldList
                    If col.Name.Trim.ToLower = "grupe" Then
                        StructureErrorList.Add(DatabaseStructureError.GetDatabaseStructureError( _
                            "Senos versijos asmenų lentelė.", "asmenys", "", "", True, "SV_ASMN"))
                        Exit For
                    End If
                Next
                Exit For
            End If
        Next

        For Each tbl As DatabaseTable In DeFactoDatabaseStructure.TableList
            If tbl.Name.Trim.ToLower = "bz" Then
                For Each col As DatabaseField In tbl.FieldList
                    If col.Name.Trim.ToLower = "op_analitika" Then
                        If col.Type = DatabaseFieldType.Char Then
                            StructureErrorList.Add(DatabaseStructureError.GetDatabaseStructureError( _
                                "Senos versijos bendrojo žurnalo lentelės.", "bz", "", "", True, "SV_BZUR"))
                        End If
                        Exit For
                    End If
                Next
                Exit For
            End If
        Next

        For Each tbl As DatabaseTable In DeFactoDatabaseStructure.TableList
            If tbl.Name.Trim.ToLower = "turtas_op" Then
                For Each col As DatabaseField In tbl.FieldList
                    If col.Name.Trim.ToLower = "tipas" Then
                        StructureErrorList.Add(DatabaseStructureError.GetDatabaseStructureError( _
                            "Senos versijos ilgalaikio turto lentelės.", "turtas_op", "", "", True, "SV_ITUR"))
                        Exit For
                    End If
                Next
                Exit For
            End If
        Next

        For Each err As DatabaseStructureError In StructureErrorList
            If err.Table.Trim.ToLower = "regionalcontents" AndAlso String.IsNullOrEmpty(err.Field.Trim) Then
                StructureErrorList.Add(DatabaseStructureError.GetDatabaseStructureError( _
                    "Senos versijos prekių ir paslaugų regionalizavimo lentelė 'RegionalContents'.", _
                        "regionalcontents", "", "", True, "SV_REGCO"))
                Exit For
            End If
        Next

        For Each err As DatabaseStructureError In StructureErrorList
            If err.Table.Trim.ToLower = "regionalprices" AndAlso String.IsNullOrEmpty(err.Field.Trim) Then
                StructureErrorList.Add(DatabaseStructureError.GetDatabaseStructureError( _
                    "Senos versijos prekių ir paslaugų regionalizavimo lentelė 'RegionalPrices'.", _
                        "regionalprices", "", "", True, "SV_REGPR"))
                Exit For
            End If
        Next

        IsFound = False
        For Each tbl As DatabaseTable In DeFactoDatabaseStructure.TableList
            If tbl.Name.Trim.ToLower = "apyskaitos" Then
                For Each col As DatabaseField In tbl.FieldList

                    If col.Name.Trim.ToLower = "pvmkor" Then

                        For Each err As DatabaseStructureError In StructureErrorList
                            If err.Table.Trim.ToLower = "advancereports" AndAlso String.IsNullOrEmpty(err.Field.Trim) Then
                                StructureErrorList.Add(DatabaseStructureError.GetDatabaseStructureError( _
                                    "Senos versijos avanso apyskaitų lentelės.", "apyskaitos", _
                                    "", "", True, "SV_APYS1"))
                                IsFound = True
                                Exit For
                            End If
                        Next

                        If Not IsFound Then
                            StructureErrorList.Add(DatabaseStructureError.GetDatabaseStructureError( _
                                "Senos versijos avanso apyskaitos lentelė.", "apyskaitos", "", "", True, "SV_APYS2"))
                            IsFound = True
                        End If

                        Exit For

                    End If

                Next
                Exit For
            End If
        Next
        If Not IsFound Then
            For Each err As DatabaseStructureError In StructureErrorList
                If err.Table.Trim.ToLower = "advancereports" AndAlso String.IsNullOrEmpty(err.Field.Trim) Then
                    StructureErrorList.Add(DatabaseStructureError.GetDatabaseStructureError( _
                        "Senos versijos avanso apyskaitos detalių eilučių lentelė.", _
                            "advancereports", "", "", True, "SV_APYS3"))
                    Exit For
                End If
            Next
        End If

        For Each err As DatabaseStructureError In StructureErrorList
            If err.Table.Trim.ToLower = "cashaccounts" AndAlso String.IsNullOrEmpty(err.Field.Trim) Then
                StructureErrorList.Add(DatabaseStructureError.GetDatabaseStructureError( _
                    "Senos versijos lėšų sąskaitų lentelė.", "CashAccounts", "", "", True, "SV_CASH"))
                Exit For
            End If
        Next

        For Each err As DatabaseStructureError In StructureErrorList
            If err.Table.Trim.ToLower = "offsetitems" AndAlso String.IsNullOrEmpty(err.Field.Trim) Then
                StructureErrorList.Add(DatabaseStructureError.GetDatabaseStructureError( _
                    "Senos versijos užskaitų lentelė.", "OffsetItems", "", "", True, "SV_OFFSET"))
                Exit For
            End If
        Next

        For Each err As DatabaseStructureError In StructureErrorList
            If err.Table.Trim.ToLower = "financialstatementsstructure" AndAlso String.IsNullOrEmpty(err.Field.Trim) Then
                StructureErrorList.Add(DatabaseStructureError.GetDatabaseStructureError( _
                    "Senos versijos finansinės atskaitomybės struktūros lentelė.", _
                    "FinancialStatementsStructure", "", "", True, "SV_FINSTR"))
                Exit For
            End If
        Next

        For Each err As DatabaseStructureError In StructureErrorList
            If err.Table.Trim.ToLower = "sfd" AndAlso err.Field.Trim.ToLower = "sumoriginal" Then
                StructureErrorList.Add(DatabaseStructureError.GetDatabaseStructureError( _
                    "Senos versijos išrašytų sąskaitų faktūrų lentelė.", _
                    "sfd", "", "", True, "SV_SFD"))
                Exit For
            End If
        Next

        For Each err As DatabaseStructureError In StructureErrorList
            If err.Table.Trim.ToLower = "sfg" AndAlso err.Field.Trim.ToLower = "sumoriginal" Then
                StructureErrorList.Add(DatabaseStructureError.GetDatabaseStructureError( _
                    "Senos versijos gautų sąskaitų faktūrų lentelė.", _
                    "sfg", "", "", True, "SV_SFG"))
                Exit For
            End If
        Next

        For Each err As DatabaseStructureError In StructureErrorList
            If err.Table.Trim.ToLower = "nustatymai" Then
                StructureErrorList.Add(DatabaseStructureError.GetDatabaseStructureError( _
                    "Senos versijos nustatymų lentelė.", "nustatymai", "", "", True, "SV_NUS"))
                Exit For
            End If
        Next

        For Each err As DatabaseStructureError In StructureErrorList
            If err.Table.Trim.ToLower = "prekes" Then
                StructureErrorList.Add(DatabaseStructureError.GetDatabaseStructureError( _
                    "Senos versijos prekių lentelė.", "prekes", "", "", True, "SV_GOODS"))
                Exit For
            End If
        Next

    End Sub

    Public Sub RepairCustomError(ByRef StructureErrorList As DatabaseStructureErrorList, _
        ByVal CustomError As DatabaseStructureError) _
        Implements IDatabaseStructureErrorManager.RepairCustomError

        For Each item As DatabaseStructureError In StructureErrorList
            If item.Description.Contains("stored procedure") AndAlso item.IsChecked _
                AndAlso item.CanBeFixedAutomatically AndAlso Not item.IsComplexError Then
                item.Update(StructureErrorList)
                item.IsChecked = False
            End If
        Next

        Select Case CustomError.ComplexErrorCode.Trim.ToUpper
            Case "SV_ASMN"
                UpgradeOldVersionPersons(StructureErrorList)
            Case "SV_BZUR"
                UpgradeOldVersionLedger(StructureErrorList)
            Case "SV_ITUR"
                UpgradeOldVersionAssets(StructureErrorList)
            Case "SV_REGCO"
                UpgradeOldVersionRegionalContents(StructureErrorList)
            Case "SV_REGPR"
                UpgradeOldVersionRegionalPrices(StructureErrorList)
            Case "SV_APYS1", "SV_APYS2", "SV_APYS3"
                If CustomError.ComplexErrorCode.Trim.Substring(7, 1) = "1" Then
                    UpgradeOldVersionAdvanceReports(StructureErrorList, True, True)
                ElseIf CustomError.ComplexErrorCode.Trim.Substring(7, 1) = "2" Then
                    UpgradeOldVersionAdvanceReports(StructureErrorList, True, False)
                ElseIf CustomError.ComplexErrorCode.Trim.Substring(7, 1) = "3" Then
                    UpgradeOldVersionAdvanceReports(StructureErrorList, False, True)
                End If
            Case "SV_CASH"
                UpgradeOldVersionCashAccounts(StructureErrorList)
            Case "SV_OFFSET"
                UpgradeOldVersionOffsets(StructureErrorList)
            Case "SV_FINSTR"
                UpgradeOldVersionBalanceStructure(StructureErrorList)
            Case "SV_SFD"
                UpgradeOldVersionInvoicesMade(StructureErrorList)
            Case "SV_SFG"
                UpgradeOldVersionInvoicesReceived(StructureErrorList)
            Case "SV_NUS"
                UpgradeOldVersionSettings(StructureErrorList)
            Case "SV_GOODS"
                UpgradeOldVersionGoods(StructureErrorList)
        End Select

        For Each item As DatabaseStructureError In StructureErrorList
            If item.IsComplexError AndAlso item.ComplexErrorCode <> CustomError.ComplexErrorCode _
                AndAlso item.CanBeFixedAutomatically AndAlso Not item.IsFixed Then Exit Sub
        Next

        Dim myComm As New SQLCommand("CheckIfUpgradeSucceded")
        Using myData As DataTable = myComm.Fetch
            If myData.Rows.Count > 0 Then
                Dim result As New List(Of String)
                For i As Integer = 1 To myData.Columns.Count
                    If CIntSafe(myData.Rows(0).Item(i - 1), 0) > 0 Then _
                        result.Add(myData.Columns(i - 1).ColumnName)
                Next
                If result.Count > 0 Then Throw New Exception("Klaida. Nepavyko konvertuoti " _
                    & "duomenų į naują versiją: " & String.Join(", ", result.ToArray))
            End If
        End Using

    End Sub


    Private Sub UpgradeOldVersionBalanceStructure(ByRef StructureErrorList As DatabaseStructureErrorList)

        Dim OldBalanceStructure As New OldBalanceItem
        OldBalanceStructure.FetchStructure()

        For i As Integer = StructureErrorList.Count To 1 Step -1
            If Not StructureErrorList.Item(i - 1).IsComplexError AndAlso _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "financialstatementsstructure" Then

                StructureErrorList.Item(i - 1).Update(StructureErrorList)
                StructureErrorList.Item(i - 1).IsChecked = False

            End If
        Next

        DatabaseAccess.TransactionBegin()

        OldBalanceStructure.UpdateStructure()

        DatabaseAccess.TransactionCommit()

    End Sub

    Public Class OldBalanceItem
        Inherits List(Of OldBalanceItem)

        Private _Name As String
        Private _IsCredit As Boolean
        Private _Type As General.FinancialStatementItemType


        Public ReadOnly Property Name() As String
            Get
                Return _Name.Trim
            End Get
        End Property

        Public ReadOnly Property IsCredit() As Boolean
            Get
                Return _IsCredit
            End Get
        End Property

        Public ReadOnly Property [Type]() As General.FinancialStatementItemType
            Get
                Return _Type
            End Get
        End Property


        Public Sub FetchStructure()

            _Name = FinancialStatementsRootName
            _IsCredit = False
            _Type = General.FinancialStatementItemType.HeaderGeneral

            Dim myComm As New SQLCommand("GetConsolidatedReportForm")
            myComm.AddParam("?FC", "b")

            Using myData As DataTable = myComm.Fetch

                ' the first item and its subitems are allways assets
                ' the second item and its subitems are allways capital
                ' the first item and its subitems are allways assets
                ' the second item and its subitems are allways capital
                Dim FirstChildStarted As Boolean = False
                For i As Integer = 1 To myData.Rows.Count
                    If CIntSafe(myData.Rows(i - 1).Item(2)) = 1 AndAlso Not FirstChildStarted Then
                        FirstChildStarted = True
                    ElseIf CIntSafe(myData.Rows(i - 1).Item(2)) = 1 AndAlso FirstChildStarted Then
                        FirstChildStarted = False
                    End If
                    If FirstChildStarted Then
                        myData.Rows(i - 1).Item(3) = 0
                    Else
                        myData.Rows(i - 1).Item(3) = 1
                    End If
                Next

                Dim BalanceItem As New OldBalanceItem
                BalanceItem._Name = BalanceStatementRootName
                BalanceItem._IsCredit = False
                BalanceItem._Type = General.FinancialStatementItemType.HeaderStatementOfFinancialPosition

                Dim index As Integer = 0
                BalanceItem.Add(New OldBalanceItem(myData, index, _
                    General.FinancialStatementItemType.StatementOfFinancialPosition))
                BalanceItem.Add(New OldBalanceItem(myData, index, _
                    General.FinancialStatementItemType.StatementOfFinancialPosition))

                Me.Add(BalanceItem)

            End Using

            myComm = New SQLCommand("GetConsolidatedReportForm")
            myComm.AddParam("?FC", "p")

            Using myData As DataTable = myComm.Fetch

                ' all defaults to profits
                For i As Integer = 1 To myData.Rows.Count
                    myData.Rows(i - 1).Item(3) = 1
                Next

                Dim IncomeSheetItem As New OldBalanceItem
                IncomeSheetItem._Name = IncomeStatementRootName
                IncomeSheetItem._IsCredit = True
                IncomeSheetItem._Type = General.FinancialStatementItemType.HeaderStatementOfComprehensiveIncome

                IncomeSheetItem.Add(New OldBalanceItem(myData, 0, _
                    General.FinancialStatementItemType.StatementOfComprehensiveIncome))

                Me.Add(IncomeSheetItem)

            End Using

        End Sub

        Public Sub UpdateStructure()
            UpdateItem(1)
        End Sub

        Private Sub UpdateItem(ByRef index As Integer)

            Dim Left As Integer = index

            For Each i As OldBalanceItem In Me
                index += 1
                i.UpdateItem(index)
            Next

            index += 1

            Dim myComm As New SQLCommand("UpgradeOldVersionFinancialStructure")
            myComm.AddParam("?AA", _Name)
            myComm.AddParam("?AB", ConvertDbBoolean(_IsCredit))
            myComm.AddParam("?AC", ConvertEnumDatabaseCode(_Type))
            myComm.AddParam("?AD", Left)
            myComm.AddParam("?AE", index)

            myComm.Execute()

        End Sub


        Private Sub New(ByVal myData As DataTable, ByRef index As Integer, _
            ByVal nType As General.FinancialStatementItemType)

            ' get a level of this list (1 - parent, 2 - child of parent etc.)
            Dim DefaultLevel As Integer = CIntSafe(myData.Rows(index).Item(2))
            Me.Clear()

            _Name = CStrSafe(myData.Rows(index).Item(1))
            _IsCredit = ConvertDbBoolean(CIntSafe(myData.Rows(index).Item(3)))
            _Type = nType

            Dim i As Integer
            ' start from the index provided
            For i = index + 2 To myData.Rows.Count

                ' if next item is child
                If CIntSafe(myData.Rows(i - 1).Item(2)) > DefaultLevel Then

                    Dim tmpindex As Integer = i - 1
                    Add(New OldBalanceItem(myData, tmpindex, nType))
                    i = tmpindex
                    If i > myData.Rows.Count Then Exit For

                    ' next item is not child
                Else

                    index = i - 1
                    Exit For

                End If

            Next

            If i > myData.Rows.Count Then index += 10000

        End Sub

        Public Sub New()

        End Sub

        Public Overrides Function ToString() As String
            Return _Name & " (ChildrenCount=" & Me.Count.ToString & ")"
        End Function

    End Class


    Private Sub UpgradeOldVersionPersons(ByRef StructureErrorList As DatabaseStructureErrorList)

        ' do basic person tables' updates
        For i As Integer = StructureErrorList.Count To 1 Step -1

            If Not StructureErrorList.Item(i - 1).IsComplexError AndAlso _
                ((StructureErrorList.Item(i - 1).Table.Trim.ToLower = "asmenys" AndAlso _
                Not StructureErrorList.Item(i - 1).Description.ToLower.Contains("perteklinis")) OrElse _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "persons_group" OrElse _
                StructureErrorList.Item(i - 1).Table.ToLower = "persons_group_assignments") Then

                StructureErrorList.Item(i - 1).Update(StructureErrorList)
                StructureErrorList.Item(i - 1).IsChecked = False
            End If

        Next

        DatabaseAccess.TransactionBegin()

        ' set default language code, currency code, insert and update timestamps
        Dim myComm As New SQLCommand("UpgradePersonsTable1")
        myComm.Execute()

        ' Transfer SODRA code to specialized field
        myComm = New SQLCommand("UpgradePersonsTable2")
        myComm.Execute()

        ' Clear SODRA code from Vat field
        myComm = New SQLCommand("UpgradePersonsTable3")
        myComm.Execute()

        ' Transfer supplier code to specialized field
        myComm = New SQLCommand("UpgradePersonsTable4")
        myComm.Execute()

        ' Transfer person type from char field to TinyInt specialized fields
        myComm = New SQLCommand("UpgradePersonsTable5")
        myComm.Execute()

        ' Transfer client status within the persons with the same code
        myComm = New SQLCommand("UpgradePersonsTable6")
        myComm.Execute()

        ' Transfer supplier status within the persons with the same code
        myComm = New SQLCommand("UpgradePersonsTable7")
        myComm.Execute()

        ' Transfer worker status within the persons with the same code
        myComm = New SQLCommand("UpgradePersonsTable8")
        myComm.Execute()

        ' Transfer Vat code within the persons with the same code
        myComm = New SQLCommand("UpgradePersonsTable9")
        myComm.Execute()

        ' Duplicate persons id's are removed in favour to min ID

        ' Remove duplicate persons id's from apyskaitos
        myComm = New SQLCommand("UpgradePersonsTable10")
        myComm.Execute()

        ' just in case take care that no null's and empty values are in bz table analitic field
        myComm = New SQLCommand("UpgradeBZTable2")
        myComm.Execute()

        ' Remove duplicate persons id's from bz
        myComm = New SQLCommand("UpgradePersonsTable11")
        myComm.Execute()

        ' Change null persons id's to 0 in bzdata
        myComm = New SQLCommand("UpgradePersonsTable12")
        myComm.Execute()

        ' Remove duplicate persons id's from bzdata
        myComm = New SQLCommand("UpgradePersonsTable13")
        myComm.Execute()

        ' Remove duplicate persons id's from d_avansai_d
        myComm = New SQLCommand("UpgradePersonsTable14")
        myComm.Execute()

        ' Remove duplicate persons id's from darbuotojai_d
        myComm = New SQLCommand("UpgradePersonsTable15")
        myComm.Execute()

        ' Remove duplicate persons id's from du_ziniarastis_d
        myComm = New SQLCommand("UpgradePersonsTable16")
        myComm.Execute()

        ' Remove duplicate persons id's from asmenys
        myComm = New SQLCommand("UpgradePersonsTable17")
        myComm.Execute()

        DatabaseAccess.TransactionCommit()

    End Sub

    Private Sub UpgradeOldVersionLedger(ByRef StructureErrorList As DatabaseStructureErrorList)

        DatabaseAccess.TransactionBegin()

        Dim myComm As New SQLCommand("UpgradeBZTable1")
        myComm.Execute()

        myComm = New SQLCommand("UpgradeBZTable2")
        myComm.Execute()

        For i As Integer = StructureErrorList.Count To 1 Step -1
            If Not StructureErrorList.Item(i - 1).IsComplexError AndAlso _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "bz" Then
                StructureErrorList.Item(i - 1).Update(StructureErrorList)
                StructureErrorList.Item(i - 1).IsChecked = False
            End If
        Next

        myComm = New SQLCommand("UpgradeBZTable3")
        myComm.Execute()

        myComm = New SQLCommand("UpgradeBZTable4")
        myComm.Execute()

        DatabaseAccess.TransactionCommit()

    End Sub

    Private Sub UpgradeOldVersionRegionalContents(ByRef StructureErrorList As DatabaseStructureErrorList)

        For i As Integer = StructureErrorList.Count To 1 Step -1
            If Not StructureErrorList.Item(i - 1).IsComplexError AndAlso _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "regionalcontents" Then

                StructureErrorList.Item(i - 1).Update(StructureErrorList)
                StructureErrorList.Item(i - 1).IsChecked = False

            End If
        Next

        Dim myComm As New SQLCommand("UpgradeOldVersionRegionalContents1")
        myComm.Execute()

    End Sub

    Private Sub UpgradeOldVersionRegionalPrices(ByRef StructureErrorList As DatabaseStructureErrorList)

        For i As Integer = StructureErrorList.Count To 1 Step -1
            If Not StructureErrorList.Item(i - 1).IsComplexError AndAlso _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "regionalprices" Then

                StructureErrorList.Item(i - 1).Update(StructureErrorList)
                StructureErrorList.Item(i - 1).IsChecked = False

            End If
        Next

        Dim myComm As New SQLCommand("UpgradeOldVersionRegionalPrices1")
        myComm.Execute()

    End Sub

    Private Sub UpgradeOldVersionAdvanceReports(ByRef StructureErrorList As DatabaseStructureErrorList, _
        ByVal UpgradeAdvanceReportTable As Boolean, ByVal UpgradeAdvanceReportTableDetails As Boolean)

        For i As Integer = StructureErrorList.Count To 1 Step -1
            If Not StructureErrorList.Item(i - 1).IsComplexError AndAlso _
                ((StructureErrorList.Item(i - 1).Table.Trim.ToLower = "apyskaitos" _
                AndAlso StructureErrorList.Item(i - 1).Field.Trim.ToLower <> "pvmkor") _
                OrElse StructureErrorList.Item(i - 1).Table.Trim.ToLower = "advancereports") Then

                StructureErrorList.Item(i - 1).Update(StructureErrorList)
                StructureErrorList.Item(i - 1).IsChecked = False

            End If
        Next

        DatabaseAccess.TransactionBegin()

        If UpgradeAdvanceReportTable Then
            Dim myComm As New SQLCommand("UpgradeOldVersionAdvanceReports")
            myComm.Execute()
        End If
        If UpgradeAdvanceReportTableDetails Then
            Dim myComm As New SQLCommand("UpgradeOldVersionAdvanceReports2")
            myComm.Execute()
        End If

        DatabaseAccess.TransactionCommit()

    End Sub

    Private Sub UpgradeOldVersionCashAccounts(ByRef StructureErrorList As DatabaseStructureErrorList)

        For i As Integer = StructureErrorList.Count To 1 Step -1
            If Not StructureErrorList.Item(i - 1).IsComplexError AndAlso _
                (StructureErrorList.Item(i - 1).Table.Trim.ToLower = "cashaccounts" OrElse _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "bankoperations" OrElse _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "kio" OrElse _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "kpo") Then

                StructureErrorList.Item(i - 1).Update(StructureErrorList)
                StructureErrorList.Item(i - 1).IsChecked = False

            End If
        Next

        DatabaseAccess.TransactionBegin()

        Dim myComm As New SQLCommand("UpgradeCashAccounts")
        myComm.Execute()

        myComm = New SQLCommand("UpgradeBankOperations")
        myComm.Execute()

        myComm = New SQLCommand("UpgradeTillSpendingsOrders")
        myComm.Execute()

        myComm = New SQLCommand("UpgradeTillIncomeOrders")
        myComm.Execute()

        DatabaseAccess.TransactionCommit()

    End Sub

    Private Sub UpgradeOldVersionOffsets(ByRef StructureErrorList As DatabaseStructureErrorList)

        For i As Integer = StructureErrorList.Count To 1 Step -1
            If Not StructureErrorList.Item(i - 1).IsComplexError AndAlso _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "offsetitems" Then

                StructureErrorList.Item(i - 1).Update(StructureErrorList)
                StructureErrorList.Item(i - 1).IsChecked = False

            End If
        Next

        Dim myComm As New SQLCommand("UpgradeOldVersionOffsets")
        myComm.Execute()

    End Sub

    Private Sub UpgradeOldVersionInvoicesMade(ByRef StructureErrorList As DatabaseStructureErrorList)

        For i As Integer = StructureErrorList.Count To 1 Step -1
            If Not StructureErrorList.Item(i - 1).IsComplexError AndAlso _
                (StructureErrorList.Item(i - 1).Table.Trim.ToLower = "sfd" OrElse _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "invoicesmade") _
                AndAlso StructureErrorList.Item(i - 1).Field.Trim.ToLower <> "s_sas" Then
                StructureErrorList.Item(i - 1).Update(StructureErrorList)
                StructureErrorList.Item(i - 1).IsChecked = False
            End If
        Next

        DatabaseAccess.TransactionBegin()

        Dim myComm As New SQLCommand("UpgradeInvoiceMade1")
        myComm.Execute()

        myComm = New SQLCommand("UpgradeInvoiceMade2")
        myComm.Execute()

        myComm = New SQLCommand("UpgradeInvoiceMade3")
        myComm.Execute()

        DatabaseAccess.TransactionCommit()

    End Sub

    Private Sub UpgradeOldVersionInvoicesReceived(ByRef StructureErrorList As DatabaseStructureErrorList)

        For i As Integer = StructureErrorList.Count To 1 Step -1
            If Not StructureErrorList.Item(i - 1).IsComplexError AndAlso _
                (StructureErrorList.Item(i - 1).Table.Trim.ToLower = "sfg" OrElse _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "invoicesreceived") _
                AndAlso Not StructureErrorList.Item(i - 1).SqlStatementsToCorrect.Trim.ToLower.Contains("drop ") Then
                StructureErrorList.Item(i - 1).Update(StructureErrorList)
                StructureErrorList.Item(i - 1).IsChecked = False
            End If
        Next

        DatabaseAccess.TransactionBegin()

        Dim myComm As New SQLCommand("UpgradeInvoiceReceived1")
        myComm.Execute()

        myComm = New SQLCommand("UpgradeInvoiceReceived2")
        myComm.Execute()

        myComm = New SQLCommand("UpgradeInvoiceReceived3")
        myComm.Execute()

        myComm = New SQLCommand("UpgradeInvoiceReceived4")
        myComm.Execute()

        myComm = New SQLCommand("UpgradeInvoiceReceived5")
        myComm.Execute()

        DatabaseAccess.TransactionCommit()

    End Sub

    Private Sub UpgradeOldVersionSettings(ByRef StructureErrorList As DatabaseStructureErrorList)

        For i As Integer = StructureErrorList.Count To 1 Step -1
            If Not StructureErrorList.Item(i - 1).IsComplexError AndAlso _
                (StructureErrorList.Item(i - 1).Table.Trim.ToLower = "companyaccounts" OrElse _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "companyrates")  Then
                StructureErrorList.Item(i - 1).Update(StructureErrorList)
                StructureErrorList.Item(i - 1).IsChecked = False
            End If
        Next

        Dim myComm As New SQLCommand("FetchOldVersionSettings")

        Using myData As DataTable = myComm.Fetch

            If Not myData.Rows.Count > 0 Then Exit Sub

            DatabaseAccess.TransactionBegin()

            myComm = New SQLCommand("InsertCompanyAccount")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(General.DefaultAccountType.Till))
            myComm.AddParam("?AB", CLongSafe(myData.Rows(0).Item(0), 0))

            myComm.Execute()

            myComm = New SQLCommand("InsertCompanyAccount")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(General.DefaultAccountType.Buyers))
            myComm.AddParam("?AB", CLongSafe(myData.Rows(0).Item(1), 0))

            myComm.Execute()

            myComm = New SQLCommand("InsertCompanyAccount")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(General.DefaultAccountType.Suppliers))
            myComm.AddParam("?AB", CLongSafe(myData.Rows(0).Item(2), 0))

            myComm.Execute()

            myComm = New SQLCommand("InsertCompanyAccount")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(General.DefaultAccountType.VatReceivable))
            myComm.AddParam("?AB", CLongSafe(myData.Rows(0).Item(3), 0))

            myComm.Execute()

            myComm = New SQLCommand("InsertCompanyAccount")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(General.DefaultAccountType.WageGpmPayable))
            myComm.AddParam("?AB", CLongSafe(myData.Rows(0).Item(4), 0))

            myComm.Execute()

            myComm = New SQLCommand("InsertCompanyAccount")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(General.DefaultAccountType.WageSodraPayable))
            myComm.AddParam("?AB", CLongSafe(myData.Rows(0).Item(5), 0))

            myComm.Execute()

            myComm = New SQLCommand("InsertCompanyAccount")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(General.DefaultAccountType.WageGuaranteeFundPayable))
            myComm.AddParam("?AB", CLongSafe(myData.Rows(0).Item(6), 0))

            myComm.Execute()

            myComm = New SQLCommand("InsertCompanyAccount")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(General.DefaultAccountType.WagePayable))
            myComm.AddParam("?AB", CLongSafe(myData.Rows(0).Item(7), 0))

            myComm.Execute()

            myComm = New SQLCommand("InsertCompanyAccount")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(General.DefaultAccountType.WageImprestPayable))
            myComm.AddParam("?AB", CLongSafe(myData.Rows(0).Item(8), 0))

            myComm.Execute()

            myComm = New SQLCommand("InsertCompanyAccount")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(General.DefaultAccountType.WageWithdraw))
            myComm.AddParam("?AB", CLongSafe(myData.Rows(0).Item(9), 0))

            myComm.Execute()

            myComm = New SQLCommand("InsertCompanyAccount")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(General.DefaultAccountType.Bank))
            myComm.AddParam("?AB", CLongSafe(myData.Rows(0).Item(10), 0))

            myComm.Execute()

            myComm = New SQLCommand("InsertCompanyAccount")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(General.DefaultAccountType.WagePsdPayable))
            myComm.AddParam("?AB", CLongSafe(myData.Rows(0).Item(11), 0))

            myComm.Execute()

            myComm = New SQLCommand("InsertCompanyAccount")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(General.DefaultAccountType.WagePsdPayableToVMI))
            myComm.AddParam("?AB", CLongSafe(myData.Rows(0).Item(12), 0))

            myComm.Execute()


            myComm = New SQLCommand("InsertCompanyRate")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(RateType.WageRateNight))
            myComm.AddParam("?AB", CDblSafe(myData.Rows(0).Item(13), 2, 0))

            myComm.Execute()

            myComm = New SQLCommand("InsertCompanyRate")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(RateType.WageRateOvertime))
            myComm.AddParam("?AB", CDblSafe(myData.Rows(0).Item(13), 2, 0))

            myComm.Execute()

            myComm = New SQLCommand("InsertCompanyRate")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(RateType.WageRateRestTime))
            myComm.AddParam("?AB", CDblSafe(myData.Rows(0).Item(14), 2, 0))

            myComm.Execute()

            myComm = New SQLCommand("InsertCompanyRate")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(RateType.WageRatePublicHolidays))
            myComm.AddParam("?AB", CDblSafe(myData.Rows(0).Item(14), 2, 0))

            myComm.Execute()

            myComm = New SQLCommand("InsertCompanyRate")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(RateType.WageRateDeviations))
            myComm.AddParam("?AB", CDblSafe(myData.Rows(0).Item(15), 2, 0))

            myComm.Execute()

            myComm = New SQLCommand("InsertCompanyRate")
            myComm.AddParam("?AA", ConvertEnumDatabaseCode(RateType.WageRateSickLeave))
            myComm.AddParam("?AB", CDblSafe(myData.Rows(0).Item(16), 2, 0))

            myComm.Execute()

            DatabaseAccess.TransactionCommit()

        End Using

    End Sub

    Private Sub UpgradeOldVersionGoods(ByRef StructureErrorList As DatabaseStructureErrorList)

        For i As Integer = StructureErrorList.Count To 1 Step -1
            If Not StructureErrorList.Item(i - 1).IsComplexError AndAlso _
                (StructureErrorList.Item(i - 1).Table.Trim.ToLower = "consignmentdiscards" OrElse _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "consignments" OrElse _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "goods" OrElse _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "goodsaccounts" OrElse _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "goodscomplexoperations" OrElse _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "goodsoperations" OrElse _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "goodsvaluationmethods" OrElse _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "kalkuliac" OrElse _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "kalkuliac_d" OrElse _
                StructureErrorList.Item(i - 1).Table.Trim.ToLower = "warehouses") Then
                StructureErrorList.Item(i - 1).Update(StructureErrorList)
                StructureErrorList.Item(i - 1).IsChecked = False
            End If
        Next

        'DatabaseAccess.TransactionBegin()

        'Dim myComm As New SQLCommand("UpgradeGoods1")
        'myComm.Execute()

        'myComm = New SQLCommand("UpgradeGoods2")
        'myComm.Execute()

        'myComm = New SQLCommand("UpgradeGoods3")
        'myComm.Execute()

        'DatabaseAccess.TransactionCommit()

    End Sub

    Private Sub UpgradeOldVersionAssets(ByRef StructureErrorList As DatabaseStructureErrorList)

        Dim LongTermAssetOperationList As New List(Of OldLongTermOperationAssetInfoList)
        Dim myComm As New SQLCommand("FetchOldFormatLongTermAssetList")
        Using myData As DataTable = myComm.Fetch
            For Each dr As DataRow In myData.Rows
                LongTermAssetOperationList.Add(New OldLongTermOperationAssetInfoList(dr))
            Next
        End Using

        DatabaseAccess.TransactionBegin()

        myComm = New SQLCommand("UpgradeAssetsTable1")
        myComm.Execute()
        myComm = New SQLCommand("UpgradeAssetsTable2")
        myComm.Execute()

        For i As Integer = StructureErrorList.Count To 1 Step -1
            If Not StructureErrorList.Item(i - 1).IsComplexError AndAlso _
                (StructureErrorList.Item(i - 1).Table.Trim.ToLower = "turtas" _
                OrElse StructureErrorList.Item(i - 1).Table.Trim.ToLower = "turtas_op") Then

                StructureErrorList.Item(i - 1).Update(StructureErrorList)
                StructureErrorList.Item(i - 1).IsChecked = False

            End If
        Next

        myComm = New SQLCommand("UpgradeAssetsTable3")
        myComm.Execute()

        For Each AssetItem As OldLongTermOperationAssetInfoList In LongTermAssetOperationList
            For Each OperationItem As OldLongTermOperationAssetInfo In AssetItem
                OperationItem.Update()
            Next
        Next

        DatabaseAccess.TransactionCommit()

    End Sub

    Private Class OldLongTermOperationAssetInfo

        Public Structure DateInterval
            Public DateFrom As Date
            Public DateTo As Date
            Public Sub New(ByVal nDateFrom As Date, ByVal nDateTo As Date)
                DateFrom = nDateFrom
                DateTo = nDateTo
            End Sub
        End Structure

        Public _ID As Integer
        Public _Type As LtaOperationType
        Public _Date As Date
        Public _Content As String
        Public _AccountCorresponding As Integer = 0
        Public _ActNumber As Integer = 0
        Public _JournalEntryID As Integer = 0

        Public _NewAmortizationPeriod As Integer = 0

        Public _UnitValueChange As Double = 0
        Public _TotalValueChange As Double = 0
        Public _AmmountChange As Integer = 0
        Public _RevaluedPortionUnitValueChange As Integer = 0
        Public _RevaluedPortionTotalValueChange As Integer = 0
        Public _AmortizationCalculatedForMonths As Integer = 0
        Public _AcquisitionAccountValueChange As Double = 0
        Public _AcquisitionAccountValueChangePerUnit As Double = 0
        Public _AmortizationAccountValueChange As Double = 0
        Public _AmortizationAccountValueChangePerUnit As Double = 0
        Public _ValueDecreaseAccountValueChange As Double = 0
        Public _ValueDecreaseAccountValueChangePerUnit As Double = 0

        Public Sub New(ByVal dr As DataRow, _
            ByRef nBeforeOperationAcquisitionAccountValue As Double, _
            ByRef nBeforeOperationAcquisitionAccountValuePerUnit As Double, _
            ByRef nBeforeOperationAmortizationAccountValue As Double, _
            ByRef nBeforeOperationAmortizationAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValueDecreaseAccountValue As Double, _
            ByRef nBeforeOperationValueDecreaseAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValue As Double, _
            ByRef nBeforeOperationValuePerUnit As Double, _
            ByRef nBeforeOperationAmmount As Integer, _
            ByRef nBeforeOperationUsagePeriods As List(Of DateInterval), _
            ByRef nBeforeOperationUsage As Boolean)

            _ID = CInt(dr.Item(0))
            Try
                _JournalEntryID = CInt(dr.Item(1))
            Catch ex As Exception
            End Try
            Try
                _ActNumber = CInt(dr.Item(2))
            Catch ex As Exception
            End Try
            _Content = dr.Item(3).ToString
            _Date = CDate(dr.Item(4))
            If dr.Item(7).ToString.Trim.ToLower = "amo" OrElse _
                dr.Item(7).ToString.Trim.ToLower = "nur" Then _
                _AccountCorresponding = CInt(dr.Item(5))

            Dim OpValue As Double = 0
            Try
                OpValue = CDbl(dr.Item(6))
            Catch ex As Exception
            End Try

            If dr.Item(7).ToString.Trim.ToLower = "nau" AndAlso nBeforeOperationUsage Then
                _Type = LtaOperationType.UsingEnd
                nBeforeOperationUsagePeriods(nBeforeOperationUsagePeriods.Count - 1) = _
                    New DateInterval(nBeforeOperationUsagePeriods( _
                    nBeforeOperationUsagePeriods.Count - 1).DateFrom, _
                    New Date(_Date.Year, _Date.Month, Date.DaysInMonth(_Date.Year, _Date.Month)))
                nBeforeOperationUsage = Not nBeforeOperationUsage

            ElseIf dr.Item(7).ToString.Trim.ToLower = "nau" AndAlso Not nBeforeOperationUsage Then
                _Type = LtaOperationType.UsingStart
                If _Date.Month = 12 Then
                    nBeforeOperationUsagePeriods.Add(New DateInterval( _
                        New Date(_Date.Year + 1, 1, 1), Date.MaxValue))
                Else
                    nBeforeOperationUsagePeriods.Add(New DateInterval( _
                        New Date(_Date.Year, _Date.Month + 1, 1), Date.MaxValue))
                End If
                nBeforeOperationUsage = Not nBeforeOperationUsage

            ElseIf dr.Item(7).ToString.Trim.ToLower = "alk" Then
                _Type = LtaOperationType.AmortizationPeriod
                _NewAmortizationPeriod = CInt(OpValue)

            ElseIf dr.Item(7).ToString.Trim.ToLower = "amo" Then
                _Type = LtaOperationType.Amortization
                _TotalValueChange = -CRound(OpValue * nBeforeOperationAmmount)
                _UnitValueChange = -CRound(OpValue, 4)
                _AmortizationAccountValueChange = -_TotalValueChange
                _AmortizationAccountValueChangePerUnit = -_UnitValueChange

                If nBeforeOperationUsagePeriods.Count > 0 AndAlso _
                    nBeforeOperationUsagePeriods(nBeforeOperationUsagePeriods.Count - 1). _
                    DateTo = Date.MaxValue Then
                    nBeforeOperationUsagePeriods(nBeforeOperationUsagePeriods.Count - 1) = _
                        New DateInterval(nBeforeOperationUsagePeriods( _
                        nBeforeOperationUsagePeriods.Count - 1).DateFrom, _
                        New Date(_Date.Year, _Date.Month, Date.DaysInMonth(_Date.Year, _Date.Month)))
                End If
                For i As Integer = 1 To nBeforeOperationUsagePeriods.Count
                    _AmortizationCalculatedForMonths = _AmortizationCalculatedForMonths + _
                        Assets.LongTermAssetAmortizationCalculation.DateDifferenceInMonths( _
                        nBeforeOperationUsagePeriods(i - 1).DateFrom, _
                        nBeforeOperationUsagePeriods(i - 1).DateTo, True, True)
                Next
                nBeforeOperationUsagePeriods.Clear()
                If nBeforeOperationUsage Then
                    If _Date.Month = 12 Then
                        nBeforeOperationUsagePeriods.Add(New DateInterval( _
                            New Date(_Date.Year + 1, 1, 1), Date.MaxValue))
                    Else
                        nBeforeOperationUsagePeriods.Add(New DateInterval( _
                            New Date(_Date.Year, _Date.Month + 1, 1), Date.MaxValue))
                    End If
                End If


            ElseIf dr.Item(7).ToString.Trim.ToLower = "per" OrElse _
                dr.Item(7).ToString.Trim.ToLower = "nur" Then

                If dr.Item(7).ToString.Trim.ToLower = "per" Then
                    _Type = LtaOperationType.Transfer
                Else
                    _Type = LtaOperationType.Discard
                End If

                _AmmountChange = CInt(OpValue)
                If _AmmountChange = nBeforeOperationAmmount Then
                    _TotalValueChange = -nBeforeOperationValue
                    _AcquisitionAccountValueChange = -nBeforeOperationAcquisitionAccountValue
                    _AmortizationAccountValueChange = -nBeforeOperationAmortizationAccountValue
                    _ValueDecreaseAccountValueChange = -nBeforeOperationValueDecreaseAccountValue
                    _RevaluedPortionTotalValueChange = -nBeforeOperationValueDecreaseAccountValue
                Else
                    _TotalValueChange = -CRound(nBeforeOperationValuePerUnit * _AmmountChange)
                    _AcquisitionAccountValueChange = _
                        -CRound(nBeforeOperationAcquisitionAccountValuePerUnit * _AmmountChange)
                    _AmortizationAccountValueChange = _
                        -CRound(nBeforeOperationAmortizationAccountValuePerUnit * _AmmountChange)
                    _ValueDecreaseAccountValueChange = _
                        -CRound(nBeforeOperationValueDecreaseAccountValuePerUnit * _AmmountChange)
                    _RevaluedPortionTotalValueChange = _
                        -CRound(nBeforeOperationValueDecreaseAccountValuePerUnit * _AmmountChange)
                End If


            ElseIf dr.Item(7).ToString.Trim.ToLower = "ver" Then

                If CRound(nBeforeOperationValuePerUnit) > CRound(OpValue) Then
                    _Type = LtaOperationType.ValueChange
                    _TotalValueChange = -CRound(nBeforeOperationValue - (OpValue * nBeforeOperationAmmount))
                    _UnitValueChange = -CRound(nBeforeOperationValuePerUnit - OpValue, 4)
                    _ValueDecreaseAccountValueChange = -_TotalValueChange
                    _ValueDecreaseAccountValueChangePerUnit = -_UnitValueChange
                    _RevaluedPortionTotalValueChange = _TotalValueChange
                    _RevaluedPortionUnitValueChange = _UnitValueChange
                Else
                    _Type = LtaOperationType.AcquisitionValueIncrease
                    _TotalValueChange = CRound((OpValue * nBeforeOperationAmmount) - nBeforeOperationValue)
                    _UnitValueChange = CRound(OpValue - nBeforeOperationValuePerUnit, 4)
                    _AcquisitionAccountValueChange = _TotalValueChange
                    _AcquisitionAccountValueChangePerUnit = _UnitValueChange
                End If

            End If

            nBeforeOperationAcquisitionAccountValue = _
                nBeforeOperationAcquisitionAccountValue + _AcquisitionAccountValueChange
            nBeforeOperationAcquisitionAccountValuePerUnit = _
                nBeforeOperationAcquisitionAccountValuePerUnit + _AcquisitionAccountValueChangePerUnit
            nBeforeOperationAmortizationAccountValue = _
                nBeforeOperationAmortizationAccountValue + _AmortizationAccountValueChange
            nBeforeOperationAmortizationAccountValuePerUnit = _
                nBeforeOperationAmortizationAccountValuePerUnit + _AmortizationAccountValueChangePerUnit
            nBeforeOperationValueDecreaseAccountValue = _
                nBeforeOperationValueDecreaseAccountValue + _ValueDecreaseAccountValueChange
            nBeforeOperationValueDecreaseAccountValuePerUnit = _
                nBeforeOperationValueDecreaseAccountValuePerUnit + _ValueDecreaseAccountValueChangePerUnit
            nBeforeOperationValue = nBeforeOperationValue + _TotalValueChange
            nBeforeOperationValuePerUnit = nBeforeOperationValuePerUnit + _UnitValueChange
            nBeforeOperationAmmount = nBeforeOperationAmmount - _AmmountChange

        End Sub

        Public Sub Update()

            Dim myComm As New SQLCommand("UpgradeAssetsOperationsTable")
            myComm.AddParam("?OD", _ID)
            myComm.AddParam("?DK", ConvertEnumDatabaseStringCode(_Type))
            myComm.AddParam("?DT", _Date.Date)
            If _Type <> LtaOperationType.AmortizationPeriod AndAlso _
                _Type <> LtaOperationType.UsingEnd AndAlso _Type <> LtaOperationType.UsingStart Then
                myComm.AddParam("?JD", _JournalEntryID)
            Else
                myComm.AddParam("?JD", 0)
            End If
            myComm.AddParam("?CN", _Content.Trim)
            If _Type = LtaOperationType.AccountChange OrElse _Type = LtaOperationType.Amortization _
                OrElse _Type = LtaOperationType.Discard Then
                myComm.AddParam("?AC", _AccountCorresponding)
            Else
                myComm.AddParam("?AC", 0)
            End If
            If _Type = LtaOperationType.Discard OrElse _Type = LtaOperationType.UsingEnd _
                OrElse _Type = LtaOperationType.UsingStart Then
                myComm.AddParam("?NM", _ActNumber)
            Else
                myComm.AddParam("?NM", 0)
            End If
            If _Type = LtaOperationType.AcquisitionValueIncrease OrElse _Type = LtaOperationType.Amortization _
                OrElse _Type = LtaOperationType.ValueChange Then
                myComm.AddParam("?UV", CRound(_UnitValueChange, 4))
            Else
                myComm.AddParam("?UV", 0)
            End If
            If _Type = LtaOperationType.Discard OrElse _Type = LtaOperationType.Transfer Then
                myComm.AddParam("?AM", _AmmountChange)
            Else
                myComm.AddParam("?AM", 0)
            End If
            If _Type <> LtaOperationType.AccountChange AndAlso _Type <> LtaOperationType.AmortizationPeriod _
                AndAlso _Type <> LtaOperationType.UsingEnd AndAlso _Type <> LtaOperationType.UsingStart Then
                myComm.AddParam("?TV", CRound(_TotalValueChange))
            Else
                myComm.AddParam("?TV", 0)
            End If
            If _Type = LtaOperationType.AmortizationPeriod Then
                myComm.AddParam("?AP", _NewAmortizationPeriod)
            Else
                myComm.AddParam("?AP", 0)
            End If
            If _Type = LtaOperationType.Amortization Then
                myComm.AddParam("?UT", _AmortizationCalculatedForMonths)
            Else
                myComm.AddParam("?UT", 0)
            End If
            If _Type = LtaOperationType.Amortization OrElse _Type = LtaOperationType.ValueChange Then
                myComm.AddParam("?RU", CRound(_RevaluedPortionUnitValueChange, 4))
            Else
                myComm.AddParam("?RU", 0)
            End If
            If _Type = LtaOperationType.Amortization OrElse _Type = LtaOperationType.ValueChange _
                OrElse _Type = LtaOperationType.Discard OrElse _Type = LtaOperationType.Transfer Then
                myComm.AddParam("?RT", CRound(_RevaluedPortionTotalValueChange))
            Else
                myComm.AddParam("?RT", 0)
            End If
            myComm.AddParam("?DA", CRound(_AcquisitionAccountValueChange))
            myComm.AddParam("?DB", CRound(_AcquisitionAccountValueChangePerUnit, 4))
            myComm.AddParam("?DC", CRound(_AmortizationAccountValueChange))
            myComm.AddParam("?DE", CRound(_AmortizationAccountValueChangePerUnit, 4))
            myComm.AddParam("?DF", CRound(_ValueDecreaseAccountValueChange))
            myComm.AddParam("?DG", CRound(_ValueDecreaseAccountValueChangePerUnit, 4))

            myComm.Execute()

        End Sub

    End Class

    Private Class OldLongTermOperationAssetInfoList
        Inherits List(Of OldLongTermOperationAssetInfo)

        Public Sub New(ByVal dr As DataRow)

            Dim nBeforeOperationAcquisitionAccountValue As Double = _
                CRound(CDbl(dr.Item(1)) * CDbl(dr.Item(2)))
            Dim nBeforeOperationAcquisitionAccountValuePerUnit As Double = _
                CRound(CDbl(dr.Item(1)), 4)
            Dim nBeforeOperationAmortizationAccountValue As Double = _
                CRound(CDbl(dr.Item(3)))
            Dim nBeforeOperationAmortizationAccountValuePerUnit As Double = _
                CRound(CDbl(dr.Item(3)) / CDbl(dr.Item(2)), 4)
            Dim nBeforeOperationValueDecreaseAccountValue As Double = 0
            Dim nBeforeOperationValueDecreaseAccountValuePerUnit As Double = 0
            Dim nBeforeOperationValue As Double = CRound(nBeforeOperationAcquisitionAccountValue _
                - nBeforeOperationAmortizationAccountValue)
            Dim nBeforeOperationValuePerUnit As Double = _
                CRound(nBeforeOperationAcquisitionAccountValuePerUnit _
                - nBeforeOperationAmortizationAccountValuePerUnit)
            Dim nBeforeOperationAmmount As Integer = CInt(dr.Item(2))
            Dim nBeforeOperationUsagePeriods As New List(Of OldLongTermOperationAssetInfo.DateInterval)
            Dim nBeforeOperationUsage As Boolean = False

            Dim myComm As New SQLCommand("FetchOldFormatLongTermOperationList")
            myComm.AddParam("?AD", CInt(dr.Item(0)))

            Using myData As DataTable = myComm.Fetch
                For Each dg As DataRow In myData.Rows
                    Add(New OldLongTermOperationAssetInfo(dg, nBeforeOperationAcquisitionAccountValue, _
                        nBeforeOperationAcquisitionAccountValuePerUnit, _
                        nBeforeOperationAmortizationAccountValue, _
                        nBeforeOperationAmortizationAccountValuePerUnit, _
                        nBeforeOperationValueDecreaseAccountValue, _
                        nBeforeOperationValueDecreaseAccountValuePerUnit, _
                        nBeforeOperationValue, nBeforeOperationValuePerUnit, nBeforeOperationAmmount, _
                        nBeforeOperationUsagePeriods, nBeforeOperationUsage))
                Next
            End Using

        End Sub

    End Class

End Class
