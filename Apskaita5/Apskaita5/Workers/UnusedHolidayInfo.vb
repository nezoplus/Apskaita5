Namespace Workers

    <Serializable()> _
Public Class UnusedHolidayInfo
        Inherits ReadOnlyBase(Of UnusedHolidayInfo)

#Region " Business Methods "

        Private _PersonID As Integer
        Private _ContractNumber As Integer
        Private _ContractSerial As String
        Private _UnusedHolidayAmmount As Double
        Private _Date As Date
        Private _IsConsolidated As Boolean

        Public ReadOnly Property PersonID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonID
            End Get
        End Property

        Public ReadOnly Property ContractNumber() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContractNumber
            End Get
        End Property

        Public ReadOnly Property ContractSerial() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContractSerial
            End Get
        End Property

        Public ReadOnly Property UnusedHolidayAmmount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UnusedHolidayAmmount
            End Get
        End Property

        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        Public ReadOnly Property IsConsolidated() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsConsolidated
            End Get
        End Property

        Protected Overrides Function GetIdValue() As Object
            Return _PersonID.ToString & " (" & _ContractSerial.Trim & _ContractNumber.ToString & ")"
        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

            ' TODO: add authorization rules
            'AuthorizationRules.AllowRead("", "")

        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.UnusedHolidayInfo1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetUnusedHolidayInfo(ByVal nDate As Date, _
            ByVal nPersonID As Integer, ByVal nContractSerial As String, _
            ByVal nContractNumber As Integer, ByVal nIsConsolidatedFetch As Boolean) As UnusedHolidayInfo

            Return DataPortal.Fetch(Of UnusedHolidayInfo)(New Criteria(nDate, _
                nPersonID, nContractSerial, nContractNumber, nIsConsolidatedFetch))

        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _PersonID As Integer
            Private _ContractNumber As Integer
            Private _ContractSerial As String
            Private _Date As Date
            Private _IsConsolidatedFetch As Boolean
            Public ReadOnly Property PersonID() As Integer
                Get
                    Return _PersonID
                End Get
            End Property
            Public ReadOnly Property ContractNumber() As Integer
                Get
                    Return _ContractNumber
                End Get
            End Property
            Public ReadOnly Property ContractSerial() As String
                Get
                    Return _ContractSerial
                End Get
            End Property
            Public ReadOnly Property IsConsolidatedFetch() As Boolean
                Get
                    Return _IsConsolidatedFetch
                End Get
            End Property
            Public ReadOnly Property [Date]() As Date
                Get
                    Return _Date
                End Get
            End Property

            Public Sub New(ByVal nDate As Date, ByVal nPersonID As Integer, _
                ByVal nContractSerial As String, ByVal nContractNumber As Integer, _
                ByVal nIsConsolidatedFetch As Boolean)
                _Date = nDate
                _PersonID = nPersonID
                _ContractNumber = nContractNumber
                _ContractSerial = nContractSerial
                _IsConsolidatedFetch = nIsConsolidatedFetch
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai operacijai.")

            If criteria.IsConsolidatedFetch Then
                _UnusedHolidayAmmount = GetConsolidatedAmmount(criteria.PersonID, criteria.Date)
            Else
                _UnusedHolidayAmmount = GetAmmount(criteria.ContractSerial, _
                    criteria.ContractNumber, criteria.Date)
            End If

            _Date = criteria.Date.Date
            _ContractNumber = criteria.ContractNumber
            _ContractSerial = criteria.ContractSerial
            _PersonID = criteria.PersonID
            _IsConsolidated = criteria.IsConsolidatedFetch

        End Sub

        Friend Shared Function GetConsolidatedAmmount(ByVal nPersonID As Integer, _
            ByVal nDate As Date) As Double

            Dim contractList As ShortLabourContractList = _
                ShortLabourContractList.GetListForPersonServerSide(nPersonID, nDate)

            If Not contractList.Count > 0 Then Return 0

            Dim resultArray(contractList.Count - 1) As Double
            For i As Integer = 1 To contractList.Count
                resultArray(i - 1) = GetAmmount(contractList(i - 1).Serial, _
                    contractList(i - 1).Number, nDate)
            Next

            Array.Sort(resultArray)

            Return resultArray(resultArray.Length - 1)

        End Function

        Friend Shared Function GetAmmount(ByVal nContractSerial As String, _
            ByVal nContractNumber As Integer, ByVal nDate As Date) As Double

            Dim result As Double = 0

            Dim myComm As New SQLCommand("FetchHolidayStatusInfo")
            myComm.AddParam("?CS", nContractSerial.Trim)
            myComm.AddParam("?CN", nContractNumber)
            myComm.AddParam("?DT", nDate.Date)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count > 0 AndAlso CStrSafe(myData.Rows(myData.Rows.Count - 1). _
                    Item(2)).Trim.ToLower = "n" Then
                    Date.TryParse(CStrSafe(myData.Rows(myData.Rows.Count - 1).Item(0)), nDate)
                    nDate = nDate.Date
                    myData.Rows.RemoveAt(myData.Rows.Count - 1)
                End If

                If myData.Rows.Count > 0 Then
                    For i As Integer = 1 To myData.Rows.Count - 1
                        result = result + CRound(DateDiff(DateInterval.Day, _
                            CDate(myData.Rows(i - 1).Item(0)), CDate(myData.Rows(i).Item(0))) _
                            * CInt(myData.Rows(i - 1).Item(1)) / AVERAGEDAYSINYEAR)
                    Next
                    result = result + CRound(DateDiff(DateInterval.Day, _
                        CDate(myData.Rows(myData.Rows.Count - 1).Item(0)), nDate) _
                        * CInt(myData.Rows(myData.Rows.Count - 1).Item(1)) / AVERAGEDAYSINYEAR)
                End If

            End Using

            myComm = New SQLCommand("FetchHolidayUsageInfo")
            myComm.AddParam("?CS", nContractSerial.Trim)
            myComm.AddParam("?CN", nContractNumber)
            myComm.AddParam("?DT", nDate.Date)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count > 0 Then
                    result = CRound(result - CIntSafe(myData.Rows(0).Item(0)) + CDblSafe(myData.Rows(0).Item(1)))
                End If

            End Using

            Return result

        End Function

#End Region

    End Class

End Namespace