﻿Namespace General

    ''' <summary>
    ''' Represents a <see cref="Person">person's</see> assignment to a <see cref="PersonGroup">PersonGroup</see>. (many to many relation)
    ''' </summary>
    ''' <remarks>Only used as a child of a <see cref="PersonGroupAssignmentList">PersonGroupAssignmentList</see>.
    ''' Values are stored in the database table persons_group_assignments.</remarks>
    <Serializable()> _
    Public NotInheritable Class PersonGroupAssignment
        Inherits BusinessBase(Of PersonGroupAssignment)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _Name As String = ""
        Private _IsAssigned As Boolean = False
        Private _GroupID As Integer = 0

        ''' <summary>
        ''' Gets ID of the Assignment in the database (assigned automatically by DB autoincrement).
        ''' </summary>
        ''' <remarks>Value is stored in the database field persons_group_assignments.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets ID of the PersonGroup.
        ''' </summary>
        ''' <remarks>Value is stored in the database field persons_group_assignments.GroupID.</remarks>
        Public ReadOnly Property GroupID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GroupID
            End Get
        End Property

        ''' <summary>
        ''' Gets a name of the PersonGroup.
        ''' </summary>
        Public ReadOnly Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a boolean value indicating whether the person is assigned to the group.
        ''' </summary>
        Public Property IsAssigned() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsAssigned
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _IsAssigned <> value Then
                    _IsAssigned = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Indicates if the Assignment currently exists in the database. Returns false if not.
        ''' </summary>
        Public ReadOnly Property IsNewAssignement() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ID > 0
            End Get
        End Property

        ''' <summary>
        ''' Indicates if the Assignment currently exists in the database and is not checked,
        ''' i.e. supposed to be deleted.
        ''' </summary>
        Public ReadOnly Property IsDeletedAssignement() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID > 0 AndAlso Not _IsAssigned
            End Get
        End Property

        ''' <summary>
        ''' Indicates if the Assignment needs to be saved to the database,
        ''' i.e. IsDeletedAssignment or IsNewAssignment and alos IsAssigned.
        ''' </summary>
        Public ReadOnly Property IsDirtyAssignement() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (_ID > 0 AndAlso Not _IsAssigned) OrElse (Not _ID > 0 AndAlso _IsAssigned)
            End Get
        End Property


        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return String.Format(My.Resources.Common_ErrorInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return String.Format(My.Resources.Common_WarningInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning))
        End Function


        ''' <summary>
        ''' Refreshes PersonGroup data when <see cref="PersonGroupList">PersonGroupList</see> changes.
        ''' </summary>
        ''' <param name="UpdatedPersonGroupInfo"></param>
        Friend Function RefreshPersonGroupInfo(ByVal UpdatedPersonGroupInfo As PersonGroupInfo) As Boolean
            If _GroupID = UpdatedPersonGroupInfo.ID AndAlso _
                UpdatedPersonGroupInfo.Name.Trim <> _Name.Trim Then
                _Name = UpdatedPersonGroupInfo.Name.Trim
                Return True
            End If
            Return False
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _GroupID
        End Function

        Public Overrides Function ToString() As String
            Return String.Format("{0}={1}", _Name, _IsAssigned.ToString)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets an existing PersonGroupAssignment instance from database.
        ''' </summary>
        ''' <param name="dr">Data returned by SQL query.</param>
        Friend Shared Function GetPersonGroupAssignment(ByVal dr As DataRow) As PersonGroupAssignment
            Return New PersonGroupAssignment(dr)
        End Function

        ''' <summary>
        ''' Refreshes PersonGroupAssignmentList data when <see cref="PersonGroupList">PersonGroupList</see> changes (a new group is added).
        ''' </summary>
        ''' <param name="NewPersonGroupInfo"></param>
        Friend Shared Function GetPersonGroupAssignment(ByVal NewPersonGroupInfo As PersonGroupInfo) As PersonGroupAssignment
            Return New PersonGroupAssignment(NewPersonGroupInfo)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As DataRow)
            MarkAsChild()
            Fetch(dr)
        End Sub

        Private Sub New(ByVal NewPersonGroupInfo As PersonGroupInfo)
            MarkAsChild()
            Fetch(NewPersonGroupInfo)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow)

            _ID = CIntSafe(dr.Item(0), 0)
            _GroupID = CIntSafe(dr.Item(1), 0)
            _Name = CStrSafe(dr.Item(2)).Trim
            _IsAssigned = (_ID > 0)

            MarkOld()

        End Sub

        Private Sub Fetch(ByVal NewPersonGroupInfo As PersonGroupInfo)

            _ID = 0
            _GroupID = NewPersonGroupInfo.ID
            _Name = NewPersonGroupInfo.Name
            _IsAssigned = False

            MarkOld()

        End Sub

        Friend Sub Insert(ByVal parent As Person)

            If IsNewAssignement AndAlso _IsAssigned Then

                Dim myComm As New SQLCommand("InsertPersonAssigment")
                myComm.AddParam("?PD", parent.ID)
                myComm.AddParam("?GD", _GroupID)

                myComm.Execute()

                _ID = Convert.ToInt32(myComm.LastInsertID)

            End If

            MarkOld()

        End Sub

        Friend Sub DeleteSelf(ByVal parent As Person)

            If IsDeletedAssignement Then

                Dim myComm As New SQLCommand("DeletePersonAssigment")
                myComm.AddParam("?GD", _ID)

                myComm.Execute()

            End If

            MarkOld()

        End Sub

#End Region

    End Class

End Namespace