﻿Imports AccDataAccessLayer.DatabaseAccess
Namespace Security

    <Serializable()> _
Public Class CommandGetNewDatabaseName
        Inherits CommandBase

#Region " Authorization Rules "

        Public Shared Function CanExecuteCommand() As Boolean
            If GetCurrentIdentity.IsLocalUser Then Return True
            If GetCurrentIdentity.ConnectionType <> AccDataAccessLayer.ConnectionType.Local Then Return False
            If GetCurrentIdentity.SqlServerType = SqlServerType.MySQL Then
                If GetCurrentIdentity.SQLServer.Trim.ToLower <> "localhost" AndAlso _
                    GetCurrentIdentity.SQLServer.Trim.ToLower <> "127.0.0.1" Then Return False
                If GetCurrentIdentity.Name.Trim.ToLower <> GetRootName().Trim.ToLower Then Return False
            End If
            Return True
        End Function

#End Region

#Region " Client-side Code "

        Private mResult As String
        Private mCompanyName As String

        Public ReadOnly Property Result() As String
            Get
                Return mResult
            End Get
        End Property

        Public ReadOnly Property CompanyName() As String
            Get
                Return mCompanyName
            End Get
        End Property

        Private Sub BeforeServer()
            ' implement code to run on client
            ' before server is called
        End Sub

        Private Sub AfterServer()
            ' implement code to run on client
            ' after server is called
        End Sub

#End Region

#Region " Factory Methods "

        Public Shared Function TheCommand(ByVal nCompanyName As String) As String

            If Not CanExecuteCommand() Then Throw New Exception( _
                "Klaida. Naujos duomenų bazės pavadinimą galima " _
                & "gauti, tik jei serveris veikia tame pačiame kompiuteryje, " _
                & "o prisijungiama yra serverio root vardu.")

            Dim cmd As New CommandGetNewDatabaseName
            cmd.mCompanyName = nCompanyName
            cmd.BeforeServer()
            cmd = DataPortal.Execute(Of CommandGetNewDatabaseName)(cmd)
            cmd.AfterServer()
            Return cmd.Result

        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Server-side Code "

        Protected Overrides Sub DataPortal_Execute()

            Dim DBList As DatabaseInfoList = DatabaseInfoList.GetDatabaseListServerSide
            If GetCurrentIdentity.IsLocalUser AndAlso Not IsWebServer(GetCurrentIdentity.IsWebServerImpersonation) Then
                mResult = DBList.GetNewLocalDatabaseName(mCompanyName)
            Else
                mResult = DBList.GetNewDatabaseNameByNamingConvention
            End If

        End Sub

#End Region

    End Class

End Namespace
