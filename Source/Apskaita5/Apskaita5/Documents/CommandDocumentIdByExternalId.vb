﻿Namespace Documents

    ''' <summary>
    ''' Represents a command that returns a document ID by it's external code.
    ''' </summary>
    ''' <remarks>Currently implemented for InvoiceMade and InvoiceReceived.</remarks>
    <Serializable()> _
Public NotInheritable Class CommandDocumentIdByExternalId
        Inherits CommandBase

#Region " Authorization Rules "

        Public Shared Function CanExecuteCommand() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.CommandDocumentIdByExternalId1")
        End Function

#End Region

#Region " Client-side Code "

        Private _Result As Integer
        Private _DocumentType As Type
        Private _ExternalID As String

        ''' <summary>
        ''' ID of the document that is returned by the command.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Result() As Integer
            Get
                Return _Result
            End Get
        End Property

        ''' <summary>
        ''' Type of the requested document.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DocumentType() As Type
            Get
                Return _DocumentType
            End Get
        End Property

        ''' <summary>
        ''' External ID of the requested document.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ExternalID() As String
            Get
                Return _ExternalID
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

        ''' <summary>
        ''' Gets a document ID by it's external code.
        ''' </summary>
        ''' <typeparam name="T">Type of the requested document.</typeparam>
        ''' <param name="cExternalID">External ID of the requested document.</param>
        ''' <remarks>Returns 0 if not found.</remarks>
        Public Shared Function TheCommand(Of T As ISyncable)(ByVal cExternalID As String) As Integer

            Dim cmd As New CommandDocumentIdByExternalId
            cmd._DocumentType = GetType(T)
            cmd._ExternalID = cExternalID

            cmd.BeforeServer()
            cmd = DataPortal.Execute(Of CommandDocumentIdByExternalId)(cmd)
            cmd.AfterServer()

            Return cmd.Result

        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Server-side Code "

        Protected Overrides Sub DataPortal_Execute()

            If Not CanExecuteCommand() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            If _DocumentType Is GetType(InvoiceMade) Then
                _Result = GetInvoiceMadeNumber(_ExternalID)
            ElseIf _DocumentType Is GetType(InvoiceReceived) Then
                _Result = GetInvoiceReceivedNumber(_ExternalID)
            ElseIf _DocumentType Is GetType(ProformaInvoiceMade) Then
                _Result = GetProformaInvoiceMadeNumber(_ExternalID)
            Else
                Throw New NotImplementedException(String.Format(My.Resources.Common_DocumentTypeNotImplemented, _
                    _DocumentType.ToString, "CommandDocumentIdByExternalId", "DataPortal_Execute."))
            End If

        End Sub

        Friend Shared Function GetInvoiceMadeNumber(ByVal mExternalID As String) As Integer

            Dim myComm As New SQLCommand("FetchInvoiceMadeIdByExternalID")
            myComm.AddParam("?MN", mExternalID.Trim)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count < 1 Then
                    Return 0
                Else
                    Return CIntSafe(myData.Rows(0).Item(0))
                End If
            End Using

        End Function

        Friend Shared Function GetInvoiceReceivedNumber(ByVal mExternalID As String) As Integer

            Dim myComm As New SQLCommand("FetchInvoiceReceivedIdByExternalID")
            myComm.AddParam("?ND", 0)
            myComm.AddParam("?ED", mExternalID.Trim)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count < 1 Then
                    Return 0
                Else
                    Return CIntSafe(myData.Rows(0).Item(0))
                End If
            End Using

        End Function

        Friend Shared Function GetProformaInvoiceMadeNumber(ByVal mExternalID As String) As Integer

            Dim myComm As New SQLCommand("FetchProformaInvoiceMadeIDByExternalID")
            myComm.AddParam("?MN", mExternalID.Trim)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count < 1 Then
                    Return 0
                Else
                    Return CIntSafe(myData.Rows(0).Item(0))
                End If
            End Using

        End Function

#End Region

    End Class

End Namespace