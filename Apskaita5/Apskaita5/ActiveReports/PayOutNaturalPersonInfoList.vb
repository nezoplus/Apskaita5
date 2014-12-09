Namespace ActiveReports

    <Serializable()> _
    Public Class PayOutNaturalPersonInfoList
        Inherits ReadOnlyListBase(Of PayOutNaturalPersonInfoList, PayOutNaturalPersonInfo)

#Region " Business Methods "

        Private _DateFrom As Date
        Private _DateTo As Date

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

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.PayOutNaturalPersonInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of PayOutNaturalPersonInfo) = Nothing

        Public Shared Function GetPayOutNaturalPersonInfoList(ByVal nDateFrom As Date, _
            ByVal nDateTo As Date) As PayOutNaturalPersonInfoList
            Return DataPortal.Fetch(Of PayOutNaturalPersonInfoList)(New Criteria(nDateFrom, nDateTo))
        End Function

        Public Function GetSortedList() As Csla.SortedBindingList(Of PayOutNaturalPersonInfo)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of PayOutNaturalPersonInfo)(Me)
            Return _SortedList
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

            Dim myComm As New SQLCommand("FetchPayOutNaturalPersonList")
            myComm.AddParam("?DF", criteria.DateFrom.Date)
            myComm.AddParam("?DT", criteria.DateTo.Date)

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                For Each dr As DataRow In myData.Rows
                    Add(PayOutNaturalPersonInfo.GetPayOutNaturalPersonInfo(dr))
                Next

                _DateFrom = criteria.DateFrom.Date
                _DateTo = criteria.DateTo.Date

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace