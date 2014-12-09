Namespace Workers

    <Serializable()> _
Public Class ShortLabourContractList
        Inherits ReadOnlyListBase(Of ShortLabourContractList, ShortLabourContract)

        Public Function GetShortLabourContract(ByVal nSerial As String, _
            ByVal nNumber As Integer) As ShortLabourContract

            For Each s As ShortLabourContract In Me
                If nSerial.Trim.ToLower = s.Serial.Trim.ToLower _
                    AndAlso nNumber = s.Number Then Return s
            Next

            Return Nothing
        End Function

        Public Function Exists(ByVal nSerial As String, ByVal nNumber As Integer) As Boolean
            For Each s As ShortLabourContract In Me
                If nSerial.Trim.ToLower = s.Serial.Trim.ToLower _
                    AndAlso nNumber = s.Number Then Return True
            Next
            Return False
        End Function

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.ShortLabourContractList1") 
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetList() As ShortLabourContractList
            Return DataPortal.Fetch(Of ShortLabourContractList)(New Criteria())
        End Function

        Public Shared Function GetListForPerson(ByVal nPersonID As Integer) As ShortLabourContractList
            Return DataPortal.Fetch(Of ShortLabourContractList)(New Criteria(nPersonID))
        End Function

        Friend Shared Function GetListServerSide() As ShortLabourContractList
            Return New ShortLabourContractList(New Criteria())
        End Function

        Friend Shared Function GetListForPersonServerSide(ByVal nPersonID As Integer, _
            ByVal nDate As Date) As ShortLabourContractList
            Return New ShortLabourContractList(New Criteria(nPersonID, nDate))
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal nCriteria As Criteria)
            DataPortal_Fetch(nCriteria)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria

            Private _PersonID As Integer
            Private _IsForPerson As Boolean
            Private _Date As Date
            Public ReadOnly Property PersonID() As Integer
                Get
                    Return _PersonID
                End Get
            End Property
            Public ReadOnly Property IsForPerson() As Boolean
                Get
                    Return _IsForPerson
                End Get
            End Property
            Public ReadOnly Property [Date]() As Date
                Get
                    Return _Date
                End Get
            End Property

            Public Sub New(ByVal nPersonID As Integer)
                _PersonID = nPersonID
                _IsForPerson = True
                _Date = Today.Add(New TimeSpan(3650, 0, 0, 0))
            End Sub
            Public Sub New(ByVal nPersonID As Integer, ByVal nDate As Date)
                _PersonID = nPersonID
                _IsForPerson = True
                _Date = nDate.Date
            End Sub
            Public Sub New()
                _PersonID = -1
                _IsForPerson = False
                _Date = Today.Add(New TimeSpan(3650, 0, 0, 0))
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai operacijai.")

            Dim myComm As SQLCommand
            If criteria.IsForPerson Then
                myComm = New SQLCommand("FetchShortLabourContractListForPerson")
                myComm.AddParam("?PD", criteria.PersonID)
            Else
                myComm = New SQLCommand("FetchShortLabourContractList")
            End If
            myComm.AddParam("?DT", criteria.Date.Date)

            Using myData As DataTable = myComm.Fetch
                RaiseListChangedEvents = False
                IsReadOnly = False
                For Each dr As DataRow In myData.Rows
                    Add(New ShortLabourContract(CIntSafe(dr.Item(0), 0), _
                        CStrSafe(dr.Item(1)), CDateSafe(dr.Item(2), Date.MinValue)))
                Next
                IsReadOnly = True
                RaiseListChangedEvents = True
            End Using

        End Sub

#End Region

    End Class

End Namespace