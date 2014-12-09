Namespace Assets

    <Serializable()> _
Public Class LongTermAssetCustomGroup
        Inherits BusinessBase(Of LongTermAssetCustomGroup)

#Region " Business Methods "

        Private _GID As Guid = Guid.NewGuid
        Private _ID As Integer = -1
        Private _Name As String = ""


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Name.Trim <> value.Trim Then
                    _Name = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _GID
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Name", "turto grupės pavadinimas"))
        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function GetLongTermAssetCustomGroup(ByVal dr As DataRow) As LongTermAssetCustomGroup
            Return New LongTermAssetCustomGroup(dr)
        End Function

        Friend Shared Function NewLongTermAssetCustomGroup() As LongTermAssetCustomGroup
            Return New LongTermAssetCustomGroup()
        End Function

        Private Sub New()
            MarkAsChild()
            ValidationRules.CheckRules()
        End Sub

        Private Sub New(ByVal dr As DataRow)
            MarkAsChild()
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow)
            _ID = CIntSafe(dr.Item(0), 0)
            _Name = CStrSafe(dr.Item(1)).Trim
            MarkOld()
            ValidationRules.CheckRules()
        End Sub

        Friend Sub Insert(ByVal parent As LongTermAssetCustomGroupList)

            Dim myComm As New SQLCommand("InsertLongTermAssetCustomGroup")
            myComm.AddParam("?NM", _Name.Trim)
            myComm.Execute()

            MarkOld()
        End Sub

        Friend Sub Update(ByVal parent As LongTermAssetCustomGroupList)

            Dim myComm As New SQLCommand("UpdateLongTermAssetCustomGroup")
            myComm.AddParam("?CD", _ID)
            myComm.AddParam("?NM", _Name.Trim)
            myComm.Execute()

            MarkOld()
        End Sub

        Friend Sub DeleteSelf()

            If IsNew Then Exit Sub

            Dim myComm As New SQLCommand("DeleteLongTermAssetCustomGroup")
            myComm.AddParam("?CD", _ID)
            myComm.Execute()

            MarkNew()

        End Sub

        Friend Sub CheckIfItemCanBeDeleted()

            If IsNew Then Exit Sub

            Dim myComm As New SQLCommand("CheckIfLongTermAssetCustomGroupCanBeDeleted")
            myComm.AddParam("?CD", _ID)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 Then Throw New Exception( _
                    "Klaida. Turto grupei '" & _Name.Trim & _
                    "' yra priskirto turto. Jos ištrinti negalima.")
            End Using

        End Sub

#End Region

    End Class

End Namespace
