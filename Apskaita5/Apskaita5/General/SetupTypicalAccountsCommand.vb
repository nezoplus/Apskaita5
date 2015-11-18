Namespace General

    ''' <summary>
    ''' Represents a command that creates a <see cref="FINANCIALSTATEMENTS_FILE">typical</see> <see cref="General.ConsolidatedReport">ConsolidatedReport</see> structure (short) 
    ''' and a <see cref="C_ACCOUNTS_FILE">typical</see> <see cref="General.AccountList">AccountList</see>.
    ''' </summary>
    ''' <remarks>Can only be invoked if the company does not have any ConsolidatedReport structure and AccauntList.</remarks>
    <Serializable()> _
    Public Class SetupTypicalAccountsCommand
        Inherits CommandBase

#Region " Authorization Rules "

        Public Shared Function CanExecuteCommand() As Boolean
            Return Csla.ApplicationContext.User.IsInRole("General.AccountList3")
        End Function

#End Region

#Region " Client-side Code "

        Private mResult As Boolean = False

        ''' <summary>
        ''' Returns TRUE if the command is executed successfuly.
        ''' </summary>
        Public ReadOnly Property Result() As Boolean
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
            HelperLists.AssignableCRItemList.InvalidateCache()
            HelperLists.AccountInfoList.InvalidateCache()
        End Sub

#End Region

#Region " Factory Methods "

        Public Shared Function TheCommand() As Boolean

            Dim cmd As New SetupTypicalAccountsCommand
            cmd.BeforeServer()
            cmd = DataPortal.Execute(Of SetupTypicalAccountsCommand)(cmd)
            cmd.AfterServer()
            Return cmd.Result

        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Server-side Code "

        Protected Overrides Sub DataPortal_Execute()

            If Not CanExecuteCommand() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityExecuteDenied)

            CheckIfCanSetupAccountListFromFile()

            Dim financialStatementsStructure As ConsolidatedReport = _
                ConsolidatedReport.GetConsolidatedReportFromFile(AppPath() & "\" & FINANCIALSTATEMENTS_FILE)
            Dim accountsStructure As AccountList = _
                AccountList.GetAccountListFromFile(IO.Path.Combine(AppPath(), C_ACCOUNTS_FILE))

            If Not AccountsStructure.IsSettingsDictionaryAvailable Then _
                Throw New Exception("Klaida. Neįkrauti sąskaitų plano arba nustatymų duomenys.")

            Using transaction As New SqlTransaction

                Try

                    financialStatementsStructure.SaveToDatabase()
                    accountsStructure.SaveToDatabase()

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            ApskaitaObjects.Settings.CompanyInfo.LoadCompanyInfoToGlobalContext("", "")

            mResult = True

        End Sub

        Private Sub CheckIfCanSetupAccountListFromFile()

            Dim myComm As New SQLCommand("CheckIfCanSetupAccountListFromFile")

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count > 0 Then

                    If CIntSafe(myData.Rows(0).Item(0), 0) > 0 Then
                        Throw New Exception(My.Resources.General_SetupTypicalAccountsCommand_AccountsAlreadyExists)
                    ElseIf CIntSafe(myData.Rows(0).Item(1), 0) > 0 Then
                        Throw New Exception(My.Resources.General_SetupTypicalAccountsCommand_FinancialStatementsStructureAlreadyExists)
                    End If

                End If

            End Using


        End Sub

#End Region

    End Class

End Namespace