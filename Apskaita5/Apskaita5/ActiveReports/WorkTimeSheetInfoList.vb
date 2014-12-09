Namespace ActiveReports

    <Serializable()> _
    Public Class WorkTimeSheetInfoList
        Inherits ReadOnlyListBase(Of WorkTimeSheetInfoList, WorkTimeSheetInfo)

#Region " Business Methods "

        Private _DateFrom As Date = Today
        Private _DateTo As Date = Today


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
            Return ApplicationContext.User.IsInRole("Workers.WorkTimeSheetInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of WorkTimeSheetInfo) = Nothing

        Public Shared Function GetWorkTimeSheetInfoList(ByVal DateFrom As Date, _
            ByVal DateTo As Date) As WorkTimeSheetInfoList
            Return DataPortal.Fetch(Of WorkTimeSheetInfoList)(New Criteria(DateFrom, DateTo))
        End Function

        Public Function GetSortedList() As Csla.SortedBindingList(Of WorkTimeSheetInfo)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of WorkTimeSheetInfo)(Me)
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

            Dim myComm As New SQLCommand("FetchWorkTimeSheetInfoList")
            myComm.AddParam("?DF", criteria.DateFrom)
            myComm.AddParam("?DT", criteria.DateTo)

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                For Each dr As DataRow In myData.Rows
                    Add(WorkTimeSheetInfo.GetWorkTimeSheetInfo(dr))
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