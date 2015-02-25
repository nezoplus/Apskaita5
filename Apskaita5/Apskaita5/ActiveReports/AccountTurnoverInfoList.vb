Imports ApskaitaObjects.General
Namespace ActiveReports

    <Serializable()> _
    Public Class AccountTurnoverInfoList
        Inherits ReadOnlyListBase(Of AccountTurnoverInfoList, AccountTurnoverInfo)

#Region " Business Methods "

        Friend Function GetClosingSummaryBalanceItem(ByVal ClosingSummaryAccount As Long, _
            ByVal ThrowOnNotFound As Boolean) As String

            For Each t As AccountTurnoverInfo In Me
                If t.ID = ClosingSummaryAccount Then Return t.FinancialStatementItem
            Next

            If ThrowOnNotFound Then Throw New Exception("Klaida. Nenustatyta einamojo " _
                & "periodo pelno (nuostolio) eilutė balanso ataskaitoje.")

            Return ""

        End Function

        Friend Function GetFormerPeriodClosingSum() As Double

            Dim result As Double = 0

            For Each t As AccountTurnoverInfo In Me
                If t.FinancialStatementItemType = FinancialStatementItemType.StatementOfComprehensiveIncome Then _
                    result = CRound(result + t.DebitBalanceFormerPeriodStart _
                        + t.DebitTurnoverFormerPeriod - t.CreditBalanceFormerPeriodStart _
                        - t.CreditTurnoverFormerPeriod)
            Next

            Return result

        End Function

        Friend Function GetCurrentPeriodClosingSum() As Double

            Dim result As Double = 0

            For Each t As AccountTurnoverInfo In Me
                If t.FinancialStatementItemType = FinancialStatementItemType.StatementOfComprehensiveIncome Then _
                    result = CRound(result + t.DebitBalanceFormerPeriodStart _
                        + t.DebitTurnoverFormerPeriod - t.CreditBalanceFormerPeriodStart _
                        - t.CreditTurnoverFormerPeriod + t.DebitTurnoverCurrentPeriod _
                        - t.CreditTurnoverCurrentPeriod)
            Next

            Return result

        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function GetAccountTurnoverInfoList(ByVal myData As DataTable, _
            ByVal nIncludeWithoutTurnover As Boolean, ByVal nClosingSummaryAccount As Long) As AccountTurnoverInfoList
            Return New AccountTurnoverInfoList(myData, nIncludeWithoutTurnover, nClosingSummaryAccount)
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal myData As DataTable, ByVal nIncludeWithoutTurnover As Boolean, _
            ByVal nClosingSummaryAccount As Long)
            ' require use of factory methods
            Fetch(myData, nIncludeWithoutTurnover, nClosingSummaryAccount)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal myData As DataTable, ByVal nIncludeWithoutTurnover As Boolean, _
            ByVal nClosingSummaryAccount As Long)

            RaiseListChangedEvents = False
            IsReadOnly = False

            For Each dr As DataRow In myData.Rows
                Dim newItem As AccountTurnoverInfo = AccountTurnoverInfo.GetAccountTurnoverInfo(dr)
                If nIncludeWithoutTurnover OrElse newItem.ID = nClosingSummaryAccount _
                    OrElse newItem.HasTurnover Then Add(newItem)
            Next

            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace
