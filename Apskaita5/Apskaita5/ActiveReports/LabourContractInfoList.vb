Namespace ActiveReports

    <Serializable()> _
    Public Class LabourContractInfoList
        Inherits ReadOnlyListBase(Of LabourContractInfoList, LabourContractInfo)

#Region " Business Methods "

        Private _ShowNonEmployed As Boolean = True
        Private _Date As Date

        Public ReadOnly Property [Date]() As Date
            Get
                Return _Date
            End Get
        End Property

        Public ReadOnly Property ShowNonEmployed() As Boolean
            Get
                Return _ShowNonEmployed
            End Get
        End Property

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.ContractInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of LabourContractInfo) = Nothing

        Public Shared Function GetLabourContractInfoList(ByVal AtDate As Date, _
            ByVal OnlyWithContracts As Boolean) As LabourContractInfoList
            Return DataPortal.Fetch(Of LabourContractInfoList)(New Criteria(AtDate, OnlyWithContracts))
        End Function

        Public Function GetFilteredList() As Csla.SortedBindingList(Of LabourContractInfo)

            If _SortedList Is Nothing Then _SortedList = _
                New Csla.SortedBindingList(Of LabourContractInfo)(Me)

            Return _SortedList

        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _Date As Date
            Private _OnlyWithContracts As Boolean
            Public ReadOnly Property [Date]() As Date
                Get
                    Return _Date
                End Get
            End Property
            Public ReadOnly Property OnlyWithContracts() As Boolean
                Get
                    Return _OnlyWithContracts
                End Get
            End Property
            Public Sub New(ByVal nDate As Date, ByVal nOnlyWithContracts As Boolean)
                _Date = nDate
                _OnlyWithContracts = nOnlyWithContracts
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            Dim myComm As New SQLCommand("FetchLabourContractInfoList")
            myComm.AddParam("?DT", criteria.Date.Date)
            myComm.AddParam("?WC", ConvertDbBoolean(criteria.OnlyWithContracts))

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                For Each dr As DataRow In myData.Rows
                    Add(LabourContractInfo.GetLabourContractInfo(dr))
                Next

                _Date = criteria.Date.Date
                _ShowNonEmployed = Not criteria.OnlyWithContracts

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace