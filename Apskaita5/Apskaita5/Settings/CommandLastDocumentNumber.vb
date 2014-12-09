Namespace Settings

    <Serializable()> _
Public Class CommandLastDocumentNumber
        Inherits CommandBase

#Region " Authorization Rules "

        Public Shared Function CanExecuteCommand() As Boolean
            Return CanExecuteCommandTillIncomeOrder() OrElse CanExecuteCommandInvoiceMade() _
                OrElse CanExecuteCommandLabourContract() OrElse CanExecuteCommandTillSpendingsOrder()
        End Function

        Public Shared Function CanExecuteCommandTillIncomeOrder() As Boolean
            Return Documents.TillIncomeOrder.CanAddObject
        End Function

        Public Shared Function CanExecuteCommandTillSpendingsOrder() As Boolean
            Return Documents.TillSpendingsOrder.CanAddObject
        End Function

        Public Shared Function CanExecuteCommandInvoiceMade() As Boolean
            Return Documents.InvoiceMade.CanAddObject
        End Function

        Public Shared Function CanExecuteCommandLabourContract() As Boolean
            Return Workers.Contract.CanAddObject
        End Function

#End Region

#Region " Client-side Code "

        Private mResult As Integer
        Private mDocumentType As DocumentSerialType
        Private mSerial As String
        Private mDate As Date
        Private mAddDateToNumberEnabled As Boolean

        Public ReadOnly Property Result() As Integer
            Get
                Return mResult
            End Get
        End Property

        Public ReadOnly Property DocumentType() As DocumentSerialType
            Get
                Return mDocumentType
            End Get
        End Property

        Public ReadOnly Property Serial() As String
            Get
                Return mSerial
            End Get
        End Property

        Public ReadOnly Property [Date]() As Date
            Get
                Return mDate
            End Get
        End Property

        Public ReadOnly Property AddDateToNumberEnabled() As Boolean
            Get
                Return mAddDateToNumberEnabled
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

        Public Shared Function TheCommand(ByVal cDocumentType As DocumentSerialType, _
            ByVal cSerial As String, ByVal nDate As Date, _
            ByVal nAddDateToNumberEnabled As Boolean) As Integer

            Dim cmd As New CommandLastDocumentNumber
            cmd.mDocumentType = cDocumentType
            cmd.mSerial = cSerial
            cmd.mDate = nDate
            cmd.mAddDateToNumberEnabled = nAddDateToNumberEnabled
            cmd.BeforeServer()
            cmd = DataPortal.Execute(Of CommandLastDocumentNumber)(cmd)
            cmd.AfterServer()
            Return cmd.Result

        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Server-side Code "

        Protected Overrides Sub DataPortal_Execute()

            If (mDocumentType = DocumentSerialType.Invoice AndAlso Not CanExecuteCommandInvoiceMade()) _
                OrElse (mDocumentType = DocumentSerialType.LabourContract AndAlso _
                Not CanExecuteCommandLabourContract()) _
                OrElse (mDocumentType = DocumentSerialType.TillIncomeOrder AndAlso _
                Not CanExecuteCommandTillIncomeOrder()) _
                OrElse (mDocumentType = DocumentSerialType.TillSpendingsOrder AndAlso _
                Not CanExecuteCommandTillSpendingsOrder()) Then _
                    Throw New System.Security.SecurityException( _
                    "Klaida. Jūsų teisių nepakanka šiai informacijai gauti.")

            Select Case mDocumentType
                Case DocumentSerialType.Invoice
                    mResult = GetLastInvoiceNumber(mSerial, mDate, mAddDateToNumberEnabled)
                Case DocumentSerialType.LabourContract
                    mResult = GetLastLabourContractNumber(mSerial, mDate)
                Case DocumentSerialType.TillIncomeOrder
                    mResult = GetLastTillIncomeOrderNumber(mSerial, mDate, mAddDateToNumberEnabled)
                Case DocumentSerialType.TillSpendingsOrder
                    mResult = GetLastTillSpendingsOrderNumber(mSerial, mDate, mAddDateToNumberEnabled)
                Case Else
                    Throw New NotImplementedException("Klaida. Numeruojamo dokumento tipas '" _
                        & mDocumentType.ToString & "' neimplementuotas objekte CommandLastDocumentNumber.")
            End Select

        End Sub

        Friend Shared Function GetLastInvoiceNumber(ByVal cSerial As String, _
            ByVal nDate As Date, ByVal nAddDateToNumberEnabled As Boolean) As Integer

            Dim myComm As SQLCommand
            If nAddDateToNumberEnabled Then
                myComm = New SQLCommand("FetchLastInvoiceNumberWithDate")
                myComm.AddParam("?DT", nDate)
            Else
                myComm = New SQLCommand("FetchLastInvoiceNumber")
            End If
            myComm.AddParam("?SR", cSerial.Trim.ToUpper)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count < 1 Then
                    Return 0
                Else
                    Return CIntSafe(myData.Rows(0).Item(0))
                End If
            End Using

        End Function

        Friend Shared Function GetLastLabourContractNumber(ByVal cSerial As String, _
            ByVal nDate As Date) As Integer

            Dim myComm As New SQLCommand("FetchLastLabourContractNumber")
            myComm.AddParam("?SR", cSerial.Trim.ToUpper)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count < 1 Then
                    Return 0
                Else
                    Return CIntSafe(myData.Rows(0).Item(0))
                End If
            End Using

        End Function

        Friend Shared Function GetLastTillIncomeOrderNumber(ByVal cSerial As String, _
            ByVal nDate As Date, ByVal nAddDateToNumberEnabled As Boolean) As Integer

            Dim myComm As SQLCommand
            If nAddDateToNumberEnabled Then
                myComm = New SQLCommand("FetchLastTillIncomeOrderNumberWithDate")
                myComm.AddParam("?DT", nDate)
            Else
                myComm = New SQLCommand("FetchLastTillIncomeOrderNumber")
            End If
            myComm.AddParam("?SR", cSerial.Trim.ToUpper)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count < 1 Then
                    Return 0
                Else
                    Return CIntSafe(myData.Rows(0).Item(0))
                End If
            End Using

        End Function

        Friend Shared Function GetLastTillSpendingsOrderNumber(ByVal cSerial As String, _
            ByVal nDate As Date, ByVal nAddDateToNumberEnabled As Boolean) As Integer

            Dim myComm As SQLCommand
            If nAddDateToNumberEnabled Then
                myComm = New SQLCommand("FetchLastTillSpendingsOrderNumberWithDate")
                myComm.AddParam("?DT", nDate)
            Else
                myComm = New SQLCommand("FetchLastTillSpendingsOrderNumber")
            End If
            myComm.AddParam("?SR", cSerial.Trim.ToUpper)

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