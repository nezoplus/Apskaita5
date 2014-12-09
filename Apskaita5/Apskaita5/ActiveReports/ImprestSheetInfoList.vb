Namespace ActiveReports

    <Serializable()> _
    Public Class ImprestSheetInfoList
        Inherits ReadOnlyListBase(Of ImprestSheetInfoList, ImprestSheetInfo)

#Region " Business Methods "

        Private _DateFrom As Date = Today
        Private _DateTo As Date = Today
        Private _ShowPayedOut As Boolean = True
        Private _TotalSum As Double = 0
        Private _TotalSumPayedOut As Double = 0
        Private _TotalWorkersCount As Integer = 0


        Public ReadOnly Property DateFrom() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DateFrom
            End Get
        End Property

        Public ReadOnly Property DateTo() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DateTo
            End Get
        End Property

        Public ReadOnly Property ShowPayedOut() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ShowPayedOut
            End Get
        End Property

        Public ReadOnly Property TotalSum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TotalSum
            End Get
        End Property

        Public ReadOnly Property TotalSumPayedOut() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TotalSumPayedOut
            End Get
        End Property

        Public ReadOnly Property TotalWorkersCount() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TotalWorkersCount
            End Get
        End Property


        Private Sub RecalculateSubTotals()

            _TotalSum = 0
            _TotalSumPayedOut = 0
            _TotalWorkersCount = 0

            For Each i As ImprestSheetInfo In Me
                If _ShowPayedOut OrElse Not i.IsPayedOut Then
                    _TotalSum = CRound(_TotalSum + i.TotalSum)
                    _TotalSumPayedOut = CRound(_TotalSumPayedOut + i.TotalSumPayedOut)
                    _TotalWorkersCount = _TotalWorkersCount + i.WorkersCount
                End If
            Next

        End Sub

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.ImprestSheetInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _FilteredList As Csla.FilteredBindingList(Of ImprestSheetInfo) = Nothing
        <NonSerialized()> _
        Private _Filter() As Object = Nothing

        Public Shared Function GetImprestSheetInfoList(ByVal nDatefrom As Date, _
            ByVal nDateTo As Date) As ImprestSheetInfoList
            Return DataPortal.Fetch(Of ImprestSheetInfoList)(New Criteria(nDatefrom, nDateTo))
        End Function

        Public Function GetFilteredList() As Csla.FilteredBindingList(Of ImprestSheetInfo)

            If _FilteredList Is Nothing Then

                _FilteredList = New Csla.FilteredBindingList(Of ImprestSheetInfo) _
                    (New Csla.SortedBindingList(Of ImprestSheetInfo)(Me), AddressOf ImprestSheetInfoFilter)
                _Filter = New Object() {ConvertDbBoolean(True)}
                _FilteredList.ApplyFilter("", _Filter)
                _ShowPayedOut = True

            End If

            Return _FilteredList

        End Function

        Public Function ApplyFilter(ByVal nShowPayedOutItems As Boolean) As Boolean

            If _FilteredList Is Nothing Then

                _FilteredList = New Csla.FilteredBindingList(Of ImprestSheetInfo) _
                    (New Csla.SortedBindingList(Of ImprestSheetInfo)(Me), AddressOf ImprestSheetInfoFilter)

            Else

                If ((_Filter Is Nothing OrElse _Filter.Length < 1) AndAlso nShowPayedOutItems) OrElse _
                    ConvertDbBoolean(CIntSafe(_Filter(0))) = nShowPayedOutItems Then Return False

            End If

            _Filter = New Object() {ConvertDbBoolean(nShowPayedOutItems)}
            _FilteredList.ApplyFilter("", _Filter)
            _ShowPayedOut = nShowPayedOutItems
            RecalculateSubTotals()

            Return True

        End Function

        Private Shared Function ImprestSheetInfoFilter(ByVal item As Object, ByVal filterValue As Object) As Boolean

            If filterValue Is Nothing OrElse DirectCast(filterValue, Object()).Length < 1 Then Return True

            Dim nShowPayedOut As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(0), Integer))

            If nShowPayedOut Then Return True

            Dim CI As ImprestSheetInfo = DirectCast(item, ImprestSheetInfo)

            If Not nShowPayedOut AndAlso CI.IsPayedOut Then Return False

            Return True

        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _DateFrom As Date
            Private _DateTo As Date
            Public ReadOnly Property DateFrom() As Date
                Get
                    Return _DateFrom
                End Get
            End Property
            Public ReadOnly Property DateTo() As Date
                Get
                    Return _DateTo
                End Get
            End Property
            Public Sub New(ByVal nDateFrom As Date, ByVal nDateTo As Date)
                _DateFrom = nDateFrom
                _DateTo = nDateTo
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            Dim myComm As New SQLCommand("FetchImprestSheetInfoList")
            myComm.AddParam("?DF", criteria.DateFrom)
            myComm.AddParam("?DT", criteria.DateTo)

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                _TotalSum = 0
                _TotalSumPayedOut = 0
                _TotalWorkersCount = 0

                For Each dr As DataRow In myData.Rows

                    Dim itemToAdd As ImprestSheetInfo = ImprestSheetInfo.GetImprestSheetInfo(dr)
                    Add(itemToAdd)

                    _TotalSum = CRound(_TotalSum + itemToAdd.TotalSum)
                    _TotalSumPayedOut = CRound(_TotalSumPayedOut + itemToAdd.TotalSumPayedOut)
                    _TotalWorkersCount = _TotalWorkersCount + itemToAdd.WorkersCount

                Next

                _DateFrom = criteria.DateFrom
                _DateTo = criteria.DateTo

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace