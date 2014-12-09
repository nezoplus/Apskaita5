Namespace Documents

    <Serializable()> _
Public Class CommandDocumentIdByExternalId
        Inherits CommandBase

#Region " Authorization Rules "

        Public Shared Function CanExecuteCommand() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.CommandDocumentIdByExternalId1")
        End Function

#End Region

#Region " Client-side Code "

        Private mResult As Integer
        Private mDocumentType As DocumentType
        Private mExternalID As String

        Public ReadOnly Property Result() As Integer
            Get
                Return mResult
            End Get
        End Property

        Public ReadOnly Property DocumentType() As DocumentType
            Get
                Return mDocumentType
            End Get
        End Property

        Public ReadOnly Property ExternalID() As String
            Get
                Return mExternalID
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

        Public Shared Function TheCommand(ByVal cDocumentType As DocumentType, _
            ByVal cExternalID As String) As Integer

            Dim cmd As New CommandDocumentIdByExternalId
            cmd.mDocumentType = cDocumentType
            cmd.mExternalID = cExternalID

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
                "Klaida. Jūsų teisių nepakanka šiai informacijai gauti.")

            Select Case mDocumentType
                Case DocumentType.InvoiceMade
                    mResult = GetInvoiceMadeNumber(mExternalID)
                Case DocumentType.InvoiceReceived
                    mResult = GetInvoiceReceivedNumber(mExternalID)
                Case Else
                    Throw New NotImplementedException("Klaida. Dokumento tipas '" _
                        & mDocumentType.ToString & "' neimplementuotas objekte CommandDocumentIdByExternalId.")
            End Select

        End Sub

        Friend Shared Function GetInvoiceMadeNumber(ByVal mExternalID As String) As Integer

            Dim myComm As New SQLCommand("FetchInvoiceMadeIdByExternalID")
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

#End Region

    End Class

End Namespace