Namespace Workers

    <Serializable()> _
    Public Class WorkersVDUInfoList
        Inherits ReadOnlyListBase(Of WorkersVDUInfoList, WorkersVDUInfo)

        Public Function GetWorkersVDUInfo(ByVal nSerial As String, _
            ByVal nNumber As Integer) As WorkersVDUInfo
            For Each s As WorkersVDUInfo In Me
                If s.ContractSerial.Trim.ToLower = nSerial.Trim.ToLower AndAlso _
                    s.ContractNumber = nNumber Then Return s
            Next
            Return Nothing
        End Function

        Public Function Exists(ByVal nSerial As String, ByVal nNumber As Integer) As Boolean
            For Each s As WorkersVDUInfo In Me
                If s.ContractSerial.Trim.ToLower = nSerial.Trim.ToLower AndAlso _
                    s.ContractNumber = nNumber Then Return True
            Next
            Return False
        End Function

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.WorkersVDUInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetList(ByVal nWorkersToFetch As WorkersVDUInfo(), _
            ByVal nYear As Integer, ByVal nMonth As Integer) As WorkersVDUInfoList
            If Not CanGetObject() Then Throw New Exception("Klaida. Jūsų teisių nepakanka šiai operacijai.")
            Return DataPortal.Fetch(Of WorkersVDUInfoList)(New Criteria( _
                nWorkersToFetch, nYear, nMonth))
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria

            Private _WorkersToFetch As WorkersVDUInfo()
            Private _Year As Integer
            Private _Month As Integer
            Public ReadOnly Property WorkersToFetch() As WorkersVDUInfo()
                Get
                    Return _WorkersToFetch
                End Get
            End Property
            Public ReadOnly Property Year() As Integer
                Get
                    Return _Year
                End Get
            End Property
            Public ReadOnly Property Month() As Integer
                Get
                    Return _Month
                End Get
            End Property

            Public Sub New(ByVal nWorkersToFetch As WorkersVDUInfo(), _
                ByVal nYear As Integer, ByVal nMonth As Integer)
                _WorkersToFetch = nWorkersToFetch
                _Year = nYear
                _Month = nMonth
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            For Each item As WorkersVDUInfo In criteria.WorkersToFetch
                item.Fetch(criteria.Year, criteria.Month)
            Next

            RaiseListChangedEvents = False
            IsReadOnly = False
            For Each item As WorkersVDUInfo In criteria.WorkersToFetch
                Add(item)
            Next
            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace