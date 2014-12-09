Namespace ActiveReports

    <Serializable()> _
    Public Class AdvanceReportInfoList
        Inherits ReadOnlyListBase(Of AdvanceReportInfoList, AdvanceReportInfo)

#Region " Business Methods "

        Private _DateFrom As Date = Today
        Private _DateTo As Date = Today
        Private _Person As PersonInfo = Nothing


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

        Public ReadOnly Property Person() As PersonInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Person
            End Get
        End Property

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.AdvanceReportInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of AdvanceReportInfo) = Nothing

        Public Shared Function GetAdvanceReportInfoList(ByVal nDateFrom As Date, _
            ByVal nDateTo As Date, ByVal nPerson As PersonInfo) As AdvanceReportInfoList
            Return DataPortal.Fetch(Of AdvanceReportInfoList) _
                (New Criteria(nDateFrom, nDateTo, nPerson))
        End Function

        Public Function GetSortedList() As Csla.SortedBindingList(Of AdvanceReportInfo)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of AdvanceReportInfo)(Me)
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
            Private _Person As PersonInfo
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
            Public ReadOnly Property Person() As PersonInfo
                <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
                Get
                    Return _Person
                End Get
            End Property
            Public Sub New(ByVal nDateFrom As Date, ByVal nDateTo As Date, ByVal nPerson As PersonInfo)
                _DateFrom = nDateFrom
                _DateTo = nDateTo
                _Person = nPerson
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            Dim myComm As New SQLCommand("FetchAdvanceReportInfoList")
            myComm.AddParam("?DF", criteria.DateFrom)
            myComm.AddParam("?DT", criteria.DateTo)
            If criteria.Person Is Nothing OrElse Not criteria.Person.ID > 0 Then
                myComm.AddParam("?CD", 0)
            Else
                myComm.AddParam("?CD", criteria.Person.ID)
            End If

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                For Each dr As DataRow In myData.Rows
                    Add(AdvanceReportInfo.GetAdvanceReportInfo(dr))
                Next

                _DateFrom = criteria.DateFrom
                _DateTo = criteria.DateTo
                _Person = criteria.Person

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace