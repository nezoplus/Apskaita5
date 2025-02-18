﻿Namespace General

    ''' <summary>
    ''' Represents a list of <see cref="General.TransferOfBalanceAnalytics">balance transfer records by person</see>.
    ''' </summary>
    ''' <remarks>Can only be used as a child object for <see cref="General.TransferOfBalance">TransferOfBalance</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class TransferOfBalanceAnalyticsList
        Inherits BusinessListBase(Of TransferOfBalanceAnalyticsList, TransferOfBalanceAnalytics)

#Region " Business Methods "

        Protected Overrides Function AddNewCore() As Object
            Dim NewItem As TransferOfBalanceAnalytics = TransferOfBalanceAnalytics.NewTransferOfBalanceAnalytics
            Me.Add(NewItem)
            Return NewItem
        End Function


        Public Function GetAllBrokenRules() As String
            If Me.IsValid Then Return ""
            Return GetAllBrokenRulesForList(Me)
        End Function

        Public Function GetAllWarnings() As String
            If Not HasWarnings() Then Return ""
            Return GetAllWarningsForList(Me)
        End Function

        Public Function HasWarnings() As Boolean
            For Each i As TransferOfBalanceAnalytics In Me
                If i.BrokenRulesCollection.WarningCount > 0 Then Return True
            Next
            Return False
        End Function


        ''' <summary>
        ''' Adds TransferOfBalanceAnalytics's from paste string.
        ''' </summary>
        ''' <param name="pasteString">String containing transaction data. 
        ''' Lines should be delimited by CrLf, fields should be delimited by Tab.</param>
        ''' <param name="overwrite">Wheather to clear the current items.</param>
        Friend Sub Paste(ByVal pasteString As String, ByVal overwrite As Boolean)

            If StringIsNullOrEmpty(pasteString.Trim) Then
                Throw New Exception(My.Resources.General_TransferOfBalanceAnalyticsList_ClipBoardIsEmpty)
            End If

            Dim accountsInfo As AccountInfoList = Nothing
            Try
                accountsInfo = AccountInfoList.GetList
            Catch ex As Exception
                Throw New Exception(String.Format(My.Resources.General_TransferOfBalanceAnalyticsList_FailedToFetchAccountInfoList,
                    ex.Message), ex)
            End Try

            Dim personsInfo As PersonInfoList = Nothing
            Try
                personsInfo = PersonInfoList.GetList
            Catch ex As Exception
                Throw New Exception(String.Format(My.Resources.General_TransferOfBalanceAnalyticsList_FailedToFetchPersonInfoList,
                    ex.Message), ex)
            End Try

            If accountsInfo.Count < 1 Then
                Throw New Exception(My.Resources.General_TransferOfBalanceAnalyticsList_AccountListEmpty)
            End If

            RaiseListChangedEvents = False

            If overwrite Then Me.Clear()

            For Each dr As String In pasteString.Split(New String() {vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
                Add(TransferOfBalanceAnalytics.NewTransferOfBalanceAnalytics(dr, personsInfo, accountsInfo))
            Next

            RaiseListChangedEvents = True

            Me.ResetBindings()

        End Sub

        ''' <summary>
        ''' Adds TransferOfBalanceAnalytics's from a template datatable,
        ''' see <see cref="TransferOfBalanceAnalytics.GetDataTableSpecification()">TransferOfBalanceAnalytics.GetDataTableSpecification</see> method.
        ''' </summary>
        ''' <param name="table">a template datatable containing transaction data</param>
        ''' <param name="overwrite">wheather to clear the current items</param>
        Friend Sub LoadFromTemplateDataTable(ByVal table As DataTable, ByVal overwrite As Boolean)

            If table Is Nothing Then Throw New ArgumentNullException("table")

            Dim accountsInfo As AccountInfoList = Nothing
            Try
                accountsInfo = AccountInfoList.GetList
            Catch ex As Exception
                Throw New Exception(String.Format(My.Resources.General_TransferOfBalanceAnalyticsList_FailedToFetchAccountInfoList,
                    ex.Message), ex)
            End Try

            Dim personsInfo As PersonInfoList = Nothing
            Try
                personsInfo = PersonInfoList.GetList
            Catch ex As Exception
                Throw New Exception(String.Format(My.Resources.General_TransferOfBalanceAnalyticsList_FailedToFetchPersonInfoList,
                    ex.Message), ex)
            End Try

            If accountsInfo.Count < 1 Then
                Throw New Exception(My.Resources.General_TransferOfBalanceAnalyticsList_AccountListEmpty)
            End If

            RaiseListChangedEvents = False

            If overwrite Then Me.Clear()

            For Each dr As DataRow In table.Rows
                Add(TransferOfBalanceAnalytics.NewTransferOfBalanceAnalytics(dr, personsInfo, accountsInfo))
            Next

            RaiseListChangedEvents = True

            Me.ResetBindings()

        End Sub


        Public Overrides Function ToString() As String

            Dim result As New List(Of String)

            For Each c As TransferOfBalanceAnalytics In Me
                result.Add(c.ToString())
            Next

            Return String.Join("; ", result.ToArray)

        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets as new TransferOfBalanceAnalyticsList.
        ''' </summary>
        Friend Shared Function NewTransferOfBalanceAnalyticsList() As TransferOfBalanceAnalyticsList
            Return New TransferOfBalanceAnalyticsList()
        End Function

        ''' <summary>
        ''' Gets a TransferOfBalanceAnalyticsList from database.
        ''' </summary>
        ''' <param name="totalBookEntryList">Internal BookEntry representation derived from database query.</param>
        ''' <param name="nFinancialDataCanChange">Whether the parent denies financial changes of the list.</param>
        ''' <remarks></remarks>
        Friend Shared Function GetTransferOfBalanceAnalyticsList _
            (ByRef totalBookEntryList As BookEntryInternalList, _
            ByVal nFinancialDataCanChange As Boolean) As TransferOfBalanceAnalyticsList
            Return New TransferOfBalanceAnalyticsList(totalBookEntryList, nFinancialDataCanChange)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByRef totalBookEntryList As BookEntryInternalList, _
            ByVal nFinancialDataCanChange As Boolean)
            ' require use of factory methods
            MarkAsChild()
            Fetch(totalBookEntryList, nFinancialDataCanChange)
            Me.AllowEdit = nFinancialDataCanChange
            Me.AllowNew = nFinancialDataCanChange
            Me.AllowRemove = nFinancialDataCanChange
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByRef totalBookEntryList As BookEntryInternalList, _
            ByVal nFinancialDataCanChange As Boolean)

            RaiseListChangedEvents = False

            Dim CompensatingBookEntryList As BookEntryInternalList = _
                BookEntryInternalList.NewBookEntryInternalList(BookEntryType.Debetas)

            For i As Integer = totalBookEntryList.Count To 1 Step -1

                If Not totalBookEntryList(i - 1).Person Is Nothing _
                    AndAlso totalBookEntryList(i - 1).Person.ID > 0 Then
                    Add(TransferOfBalanceAnalytics.GetTransferOfBalanceAnalytics( _
                        totalBookEntryList(i - 1), nFinancialDataCanChange))
                End If

                totalBookEntryList(i - 1).Person = Nothing

            Next

            For Each i As BookEntryInternal In CompensatingBookEntryList
                totalBookEntryList.Add(i)
            Next

            RaiseListChangedEvents = True

        End Sub

        Friend Sub Update(ByRef CommonBookEntryList As BookEntryInternalList)

            RaiseListChangedEvents = False

            For Each i As TransferOfBalanceAnalytics In Me
                CommonBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                    i.EntryType, i.Account, i.Ammount, i.Person))
                ' compensatory entries that will be dealt by call to Aggregate
                If i.EntryType = BookEntryType.Debetas Then
                    CommonBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, i.Account, i.Ammount, Nothing))
                Else
                    CommonBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Debetas, i.Account, i.Ammount, Nothing))
                End If
            Next

            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace