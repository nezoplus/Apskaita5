Imports ApskaitaObjects.General
Namespace ActiveReports

    <Serializable()> _
    Public Class BookEntryInfoList
        Inherits ReadOnlyListBase(Of BookEntryInfoList, BookEntryInfo)

#Region " Business Methods "

        Private _DebetTurnover As Double
        Private _CreditTurnover As Double

        ''' <summary>
        ''' Helper method. Gets a Debet side turnover (if any) based on search criteria 
        ''' provided by filter/search criteria.
        ''' </summary>
        Friend ReadOnly Property DebetTurnover() As Double
            Get
                Return _DebetTurnover
            End Get
        End Property

        ''' <summary>
        ''' Helper method. Gets a Credit side turnover (if any) based on search criteria 
        ''' provided by filter/search criteria.
        ''' </summary>
        Friend ReadOnly Property CreditTurnover() As Double
            Get
                Return _CreditTurnover
            End Get
        End Property

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.GeneralLedger1")
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function GetList(ByVal myData As DataTable) As BookEntryInfoList

            Return New BookEntryInfoList(myData)

        End Function

        Private Sub New(ByVal myData As DataTable)
            Fetch(myData)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal myData As DataTable)
            RaiseListChangedEvents = False
            IsReadOnly = False

            _DebetTurnover = 0
            _CreditTurnover = 0

            For Each dr As DataRow In myData.Rows
                Add(BookEntryInfo.GetBookEntryInfo(dr))
                _DebetTurnover = CRound(_DebetTurnover + Me.Item(Me.Count - 1).DebetTurnover)
                _CreditTurnover = CRound(_CreditTurnover + Me.Item(Me.Count - 1).CreditTurnover)
            Next

            IsReadOnly = True
            RaiseListChangedEvents = True
        End Sub

#End Region

    End Class

End Namespace