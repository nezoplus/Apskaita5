Namespace Assets

    <Serializable()> _
    Public Class LongTermAssetInfoList
        Inherits ReadOnlyListBase(Of LongTermAssetInfoList, LongTermAssetInfo)

#Region " Business Methods "

        Private _DateFrom As Date
        Private _DateTo As Date
        Private _CustomAssetGroup As LongTermAssetCustomGroupInfo


        Public ReadOnly Property DateFrom() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DateFrom.Date
            End Get
        End Property

        Public ReadOnly Property DateTo() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DateTo.Date
            End Get
        End Property

        Public ReadOnly Property CustomAssetGroup() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _CustomAssetGroup Is Nothing Then Return "Visos grupės"
                Return _CustomAssetGroup.ToString
            End Get
        End Property


#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Assets.LongTermAssetInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of LongTermAssetInfo) = Nothing

        Public Shared Function GetLongTermAssetInfoList(ByVal nDateFrom As Date, _
            ByVal nDateTo As Date, ByVal nCustomAssetGroup As LongTermAssetCustomGroupInfo) As LongTermAssetInfoList
            Return DataPortal.Fetch(Of LongTermAssetInfoList) _
                (New Criteria(nDateFrom, nDateTo, nCustomAssetGroup))
        End Function

        Public Function GetSortedList() As Csla.SortedBindingList(Of LongTermAssetInfo)
            If _SortedList Is Nothing Then _SortedList = _
                New Csla.SortedBindingList(Of LongTermAssetInfo)(Me)
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
            Private _CustomAssetGroup As LongTermAssetCustomGroupInfo
            Public ReadOnly Property DateFrom() As Date
                Get
                    Return _DateFrom.Date
                End Get
            End Property
            Public ReadOnly Property DateTo() As Date
                Get
                    Return _DateTo.Date
                End Get
            End Property
            Public ReadOnly Property CustomAssetGroup() As LongTermAssetCustomGroupInfo
                <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
                Get
                    Return _CustomAssetGroup
                End Get
            End Property
            Public Sub New(ByVal nDateFrom As Date, ByVal nDateTo As Date, _
                ByVal nCustomAssetGroup As LongTermAssetCustomGroupInfo)
                _DateFrom = nDateFrom.Date
                _DateTo = nDateTo.Date
                _CustomAssetGroup = nCustomAssetGroup
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            Dim myComm As SQLCommand
            If criteria.CustomAssetGroup Is Nothing Then
                myComm = New SQLCommand("FetchLongTermAssetInfoAcquisitionData1")
            Else
                myComm = New SQLCommand("FetchLongTermAssetInfoAcquisitionData2")
                myComm.AddParam("?GR", criteria.CustomAssetGroup.ID)
            End If

            Using AcquisitionDataTable As DataTable = myComm.Fetch

                If criteria.CustomAssetGroup Is Nothing Then
                    myComm = New SQLCommand("FetchLongTermAssetInfoStatusData1")
                Else
                    myComm = New SQLCommand("FetchLongTermAssetInfoStatusData2")
                    myComm.AddParam("?GR", criteria.CustomAssetGroup.ID)
                End If
                myComm.AddParam("?DF", criteria.DateFrom)

                Using StatusBeforeDataTable As DataTable = myComm.Fetch

                    If criteria.CustomAssetGroup Is Nothing Then
                        myComm = New SQLCommand("FetchLongTermAssetInfoChangesData1")
                    Else
                        myComm = New SQLCommand("FetchLongTermAssetInfoChangesData2")
                        myComm.AddParam("?GR", criteria.CustomAssetGroup.ID)
                    End If
                    myComm.AddParam("?DF", criteria.DateFrom)
                    myComm.AddParam("?DT", criteria.DateTo)

                    Using ChangesDataTable As DataTable = myComm.Fetch

                        RaiseListChangedEvents = False
                        IsReadOnly = False

                        For Each dr As DataRow In AcquisitionDataTable.Rows
                            Add(LongTermAssetInfo.GetLongTermAssetInfo(dr, _
                                GetDataRow(StatusBeforeDataTable, CInt(dr.Item(0))), _
                                GetDataRow(ChangesDataTable, CInt(dr.Item(0))), _
                                criteria.DateFrom, criteria.DateTo))
                        Next

                        _CustomAssetGroup = criteria.CustomAssetGroup
                        _DateFrom = criteria.DateFrom
                        _DateTo = criteria.DateTo

                        IsReadOnly = True
                        RaiseListChangedEvents = True

                    End Using

                End Using

            End Using

        End Sub


        Private Function GetDataRow(ByVal AssetInfoDataTable As DataTable, _
            ByVal nAssetID As Integer) As DataRow

            For i As Integer = 1 To AssetInfoDataTable.Rows.Count
                If CInt(AssetInfoDataTable.Rows(i - 1).Item(0)) = nAssetID Then _
                    Return AssetInfoDataTable.Rows(i - 1)
            Next

            Return Nothing

        End Function

#End Region

    End Class

End Namespace