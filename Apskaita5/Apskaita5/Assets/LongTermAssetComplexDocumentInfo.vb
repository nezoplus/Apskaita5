Namespace Assets

    <Serializable()> _
    Public Class LongTermAssetComplexDocumentInfo
        Inherits ReadOnlyBase(Of LongTermAssetComplexDocumentInfo)

#Region " Business Methods "

        Private _ID As Integer
        Private _OperationType As String
        Private _Date As Date
        Private _Content As String
        Private _ActNumber As Integer
        Private _AttachedJournalEntryID As Integer
        Private _AttachedJournalEntry As String
        Private _CorrespondingAccount As Integer


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property OperationType() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationType.Trim
            End Get
        End Property

        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        Public ReadOnly Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
        End Property

        Public ReadOnly Property ActNumber() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ActNumber
            End Get
        End Property

        Public ReadOnly Property AttachedJournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AttachedJournalEntryID
            End Get
        End Property

        Public ReadOnly Property AttachedJournalEntry() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AttachedJournalEntry.Trim
            End Get
        End Property

        Public ReadOnly Property CorrespondingAccount() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CorrespondingAccount
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return _Content
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function GetLongTermAssetComplexDocumentInfo(ByVal dr As DataRow) As LongTermAssetComplexDocumentInfo
            Return New LongTermAssetComplexDocumentInfo(dr)
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal dr As DataRow)
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow)

            _ID = CIntSafe(dr.Item(0), 0)
            _OperationType = ConvertEnumHumanReadable(ConvertEnumDatabaseStringCode(Of LtaOperationType) _
                (CStrSafe(dr.Item(1)).Trim))
            _Date = CDateSafe(dr.Item(2), Today)
            If CIntSafe(dr.Item(3), 0) > 0 Then
                _AttachedJournalEntryID = CIntSafe(dr.Item(3), 0)
                _AttachedJournalEntry = "Nr. " & CStrSafe(dr.Item(4)) & " \ " & _
                    GetLimitedLengthString(CStrSafe(dr.Item(5)), 100)
            Else
                _AttachedJournalEntryID = -1
                _AttachedJournalEntry = "nėra"
            End If
            _Content = CStrSafe(dr.Item(6)).Trim
            _CorrespondingAccount = CIntSafe(dr.Item(7), 0)
            _ActNumber = CIntSafe(dr.Item(8), 0)

        End Sub

#End Region

    End Class

End Namespace