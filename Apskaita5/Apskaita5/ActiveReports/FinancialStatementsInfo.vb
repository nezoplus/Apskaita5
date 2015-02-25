Namespace ActiveReports

    <Serializable()> _
    Public Class FinancialStatementsInfo
        Inherits ReadOnlyBase(Of FinancialStatementsInfo)

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _FirstPeriodDateStart As Date = Today
        Private _SecondPeriodDateStart As Date = Today
        Private _SecondPeriodDateEnd As Date = Today
        Private _ClosingSummaryAccount As Long = 0
        Private _ClosingSummaryBalanceItem As String = ""
        Private _IncludeWithoutTurnover As Boolean = False
        Private _AccountTurnoverList As AccountTurnoverInfoList = Nothing
        Private _BalanceSheet As BalanceSheetInfoList = Nothing
        Private _IncomeStatement As IncomeStatementInfoList = Nothing


        Public ReadOnly Property FirstPeriodDateStart() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FirstPeriodDateStart
            End Get
        End Property

        Public ReadOnly Property SecondPeriodDateStart() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SecondPeriodDateStart
            End Get
        End Property

        Public ReadOnly Property SecondPeriodDateEnd() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SecondPeriodDateEnd
            End Get
        End Property

        Public ReadOnly Property ClosingSummaryAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ClosingSummaryAccount
            End Get
        End Property

        Public ReadOnly Property ClosingSummaryBalanceItem() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ClosingSummaryBalanceItem.Trim
            End Get
        End Property

        Public ReadOnly Property AccountTurnoverList() As AccountTurnoverInfoList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountTurnoverList
            End Get
        End Property

        Public ReadOnly Property BalanceSheet() As BalanceSheetInfoList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BalanceSheet
            End Get
        End Property

        Public ReadOnly Property IncomeStatement() As IncomeStatementInfoList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IncomeStatement
            End Get
        End Property

        Public ReadOnly Property IncludeWithoutTurnover() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IncludeWithoutTurnover
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return "Current period from " & Me._SecondPeriodDateStart.ToShortDateString _
                & " to " & Me._SecondPeriodDateEnd.ToShortDateString & ", former period from " _
                & Me._FirstPeriodDateStart.ToShortDateString & " to " _
                & Me._SecondPeriodDateStart.Subtract(New TimeSpan(1, 0, 0, 0)).ToShortDateString & "."
        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.FinancialStatement1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetFinancialStatementsInfo(ByVal nFirstPeriodDateStart As Date, _
            ByVal nSecondPeriodDateStart As Date, ByVal nSecondPeriodDateEnd As Date, _
            ByVal nClosingSummaryAccount As Long, ByVal nIncludeWithoutTurnover As Boolean) As FinancialStatementsInfo
            Return DataPortal.Fetch(Of FinancialStatementsInfo)(New Criteria( _
                nFirstPeriodDateStart, nSecondPeriodDateStart, nSecondPeriodDateEnd, _
                nClosingSummaryAccount, nIncludeWithoutTurnover))
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _FirstPeriodDateStart As Date = Today
            Private _SecondPeriodDateStart As Date = Today
            Private _SecondPeriodDateEnd As Date = Today
            Private _ClosingSummaryAccount As Long = 0
            Private _IncludeWithoutTurnover As Boolean = False
            Public ReadOnly Property FirstPeriodDateStart() As Date
                Get
                    Return _FirstPeriodDateStart
                End Get
            End Property
            Public ReadOnly Property SecondPeriodDateStart() As Date
                Get
                    Return _SecondPeriodDateStart
                End Get
            End Property
            Public ReadOnly Property SecondPeriodDateEnd() As Date
                Get
                    Return _SecondPeriodDateEnd
                End Get
            End Property
            Public ReadOnly Property ClosingSummaryAccount() As Long
                Get
                    Return _ClosingSummaryAccount
                End Get
            End Property
            Public ReadOnly Property IncludeWithoutTurnover() As Boolean
                Get
                    Return _IncludeWithoutTurnover
                End Get
            End Property
            Public Sub New(ByVal nFirstPeriodDateStart As Date, ByVal nSecondPeriodDateStart As Date, _
                ByVal nSecondPeriodDateEnd As Date, ByVal nClosingSummaryAccount As Long, _
                ByVal nIncludeWithoutTurnover As Boolean)
                _FirstPeriodDateStart = nFirstPeriodDateStart
                _SecondPeriodDateStart = nSecondPeriodDateStart
                _SecondPeriodDateEnd = nSecondPeriodDateEnd
                _ClosingSummaryAccount = nClosingSummaryAccount
                _IncludeWithoutTurnover = nIncludeWithoutTurnover
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            If Not criteria.FirstPeriodDateStart.Date < criteria.SecondPeriodDateStart.Date Then _
                Throw New Exception("Klaida. Pirmo periodo pradžia negali būti vėlesnė už antro periodo pradžią.")
            If Not criteria.SecondPeriodDateStart.Date < criteria.SecondPeriodDateEnd.Date Then _
                Throw New Exception("Klaida. Antro periodo pradžia negali būti vėlesnė už pabaigą.")
            If Not criteria.ClosingSummaryAccount > 0 Then _
                Throw New Exception("Klaida. Nenurodyta uždaymo suvestinė sąskaita.")


            Dim myComm As New SQLCommand("FetchAccountTurnoverInfoList")
            myComm.AddParam("?DF", criteria.FirstPeriodDateStart)
            myComm.AddParam("?DT", criteria.SecondPeriodDateStart)
            myComm.AddParam("?DE", criteria.SecondPeriodDateEnd)

            Using myData As DataTable = myComm.Fetch

                _AccountTurnoverList = AccountTurnoverInfoList.GetAccountTurnoverInfoList( _
                    myData, criteria.IncludeWithoutTurnover, criteria.ClosingSummaryAccount)

                _ClosingSummaryBalanceItem = _AccountTurnoverList. _
                    GetClosingSummaryBalanceItem(criteria.ClosingSummaryAccount, True)
                If _ClosingSummaryBalanceItem Is Nothing OrElse _
                    String.IsNullOrEmpty(_ClosingSummaryBalanceItem.Trim) Then _
                    Throw New Exception("Klaida. Nenustatyta einamojo " _
                    & "periodo pelno (nuostolio) eilutė balanso ataskaitoje.")

            End Using

            myComm = New SQLCommand("FetchFinancialStatementsBalance")
            myComm.AddParam("?DF", criteria.SecondPeriodDateStart)
            myComm.AddParam("?DT", criteria.SecondPeriodDateEnd)

            Using myData As DataTable = myComm.Fetch

                _BalanceSheet = BalanceSheetInfoList.GetBalanceSheetInfoList(myData)
                _BalanceSheet.UpdateOptimizedCurrentPeriodBalance( _
                    _AccountTurnoverList.GetCurrentPeriodClosingSum, _ClosingSummaryBalanceItem)
                _BalanceSheet.UpdateOptimizedFormerPeriodBalance( _
                    _AccountTurnoverList.GetFormerPeriodClosingSum, _ClosingSummaryBalanceItem)

                _IncomeStatement = IncomeStatementInfoList.GetIncomeStatementInfoList(myData)
                _IncomeStatement.UpdateOptimizedValues(_AccountTurnoverList)

            End Using

            _FirstPeriodDateStart = criteria.FirstPeriodDateStart
            _SecondPeriodDateStart = criteria.SecondPeriodDateStart
            _SecondPeriodDateEnd = criteria.SecondPeriodDateEnd
            _ClosingSummaryAccount = criteria.ClosingSummaryAccount
            _IncludeWithoutTurnover = criteria.IncludeWithoutTurnover

        End Sub

#End Region

    End Class

End Namespace