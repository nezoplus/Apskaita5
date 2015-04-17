Namespace HelperLists

    <Serializable()> _
    Public Class LongTermAssetCustomGroupInfo
        Inherits ReadOnlyBase(Of LongTermAssetCustomGroupInfo)
        Implements IComparable, IValueObjectIsEmpty

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _Name As String = ""


        Public ReadOnly Property IsEmpty() As Boolean _
            Implements IValueObjectIsEmpty.IsEmpty
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ID > 0
            End Get
        End Property

        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
        End Property

        Public ReadOnly Property GetMe() As LongTermAssetCustomGroupInfo
            Get
                Return Me
            End Get
        End Property



        Public Shared Operator =(ByVal a As LongTermAssetCustomGroupInfo, ByVal b As LongTermAssetCustomGroupInfo) As Boolean
            If a Is Nothing AndAlso b Is Nothing Then Return True
            If a Is Nothing OrElse b Is Nothing Then Return False
            Return a.ID = b.ID
        End Operator

        Public Shared Operator <>(ByVal a As LongTermAssetCustomGroupInfo, ByVal b As LongTermAssetCustomGroupInfo) As Boolean
            Return Not a = b
        End Operator

        Public Shared Operator >(ByVal a As LongTermAssetCustomGroupInfo, ByVal b As LongTermAssetCustomGroupInfo) As Boolean
            If a Is Nothing Then Return False
            If a IsNot Nothing And b Is Nothing Then Return True
            Return a.ToString > b.ToString
        End Operator

        Public Shared Operator <(ByVal a As LongTermAssetCustomGroupInfo, ByVal b As LongTermAssetCustomGroupInfo) As Boolean
            If a Is Nothing And b Is Nothing Then Return False
            If a Is Nothing Then Return True
            If b Is Nothing Then Return False
            Return a.ToString < b.ToString
        End Operator

        Public Function CompareTo(ByVal obj As Object) As Integer _
        Implements System.IComparable.CompareTo
            Dim tmp As LongTermAssetCustomGroupInfo = TryCast(obj, LongTermAssetCustomGroupInfo)
            If Me = tmp Then Return 0
            If Me > tmp Then Return 1
            Return -1
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return _Name
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function NewLongTermAssetCustomGroupInfo() As LongTermAssetCustomGroupInfo
            Return New LongTermAssetCustomGroupInfo()
        End Function

        Friend Shared Function GetLongTermAssetCustomGroupInfo(ByVal dr As DataRow, _
            ByVal Offset As Integer) As LongTermAssetCustomGroupInfo
            Return New LongTermAssetCustomGroupInfo(dr, Offset)
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal Offset As Integer)
            Fetch(dr, Offset)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow, ByVal Offset As Integer)

            _ID = CIntSafe(dr.Item(0 + Offset), 0)
            _Name = CStrSafe(dr.Item(1 + Offset)).Trim

        End Sub

#End Region

    End Class

End Namespace