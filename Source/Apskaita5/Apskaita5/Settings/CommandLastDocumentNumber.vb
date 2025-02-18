﻿Namespace Settings

    ''' <summary>
    ''' Represents an encapsulated method to get the last used document running number. 
    ''' (to get the next available running number just add 1)
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
Public NotInheritable Class CommandLastDocumentNumber
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

        Private _Result As Integer
        Private _DocumentType As DocumentSerialType
        Private _Serial As String
        Private _Date As Date
        Private _AddDateToNumberEnabled As Boolean

        ''' <summary>
        ''' Gets the last used document running number.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Result() As Integer
            Get
                Return _Result
            End Get
        End Property

        ''' <summary>
        ''' Gets the type of the document for which the running number was fetched.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DocumentType() As DocumentSerialType
            Get
                Return _DocumentType
            End Get
        End Property

        ''' <summary>
        ''' Gets the serial of the document for which the running number was fetched.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Serial() As String
            Get
                Return _Serial
            End Get
        End Property

        ''' <summary>
        ''' Gets the date of the document for which the running number was fetched.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property [Date]() As Date
            Get
                Return _Date
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the running number was fetched with an option AddDateToNumber.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AddDateToNumberEnabled() As Boolean
            Get
                Return _AddDateToNumberEnabled
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
        ''' Gets the last used document running number. (to get the next available running number just add 1)
        ''' </summary>
        ''' <param name="cDocumentType">type of the document for which the running number is fetched</param>
        ''' <param name="cSerial">the serial of the document for which the running number is fetched</param>
        ''' <param name="nDate">the date of the document for which the running number is fetched
        ''' (only has effect if <paramref name="nAddDateToNumberEnabled">nAddDateToNumberEnabled</paramref> is set to true)</param>
        ''' <param name="nAddDateToNumberEnabled">whether the document date shall be a part of the document full number</param>
        ''' <remarks></remarks>
        Public Shared Function TheCommand(ByVal cDocumentType As DocumentSerialType, _
            ByVal cSerial As String, ByVal nDate As Date, _
            ByVal nAddDateToNumberEnabled As Boolean) As Integer

            Dim cmd As New CommandLastDocumentNumber
            cmd._DocumentType = cDocumentType
            cmd._Serial = cSerial
            cmd._Date = nDate
            cmd._AddDateToNumberEnabled = nAddDateToNumberEnabled

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

            If (_DocumentType = DocumentSerialType.Invoice AndAlso Not CanExecuteCommandInvoiceMade()) _
                OrElse (_DocumentType = DocumentSerialType.LabourContract AndAlso _
                Not CanExecuteCommandLabourContract()) _
                OrElse (_DocumentType = DocumentSerialType.TillIncomeOrder AndAlso _
                Not CanExecuteCommandTillIncomeOrder()) _
                OrElse (_DocumentType = DocumentSerialType.TillSpendingsOrder AndAlso _
                Not CanExecuteCommandTillSpendingsOrder()) Then _
                    Throw New System.Security.SecurityException( _
                    My.Resources.Common_SecuritySelectDenied)

            Select Case _DocumentType
                Case DocumentSerialType.Invoice
                    _Result = GetLastInvoiceNumber(_Serial, _Date, _AddDateToNumberEnabled)
                Case DocumentSerialType.LabourContract
                    _Result = GetLastLabourContractNumber(_Serial, _Date)
                Case DocumentSerialType.TillIncomeOrder
                    _Result = GetLastTillIncomeOrderNumber(_Serial, _Date, _AddDateToNumberEnabled)
                Case DocumentSerialType.TillSpendingsOrder
                    _Result = GetLastTillSpendingsOrderNumber(_Serial, _Date, _AddDateToNumberEnabled)
                Case DocumentSerialType.ProformaInvoice
                    _Result = GetLastProformaInvoiceNumber(_Serial, _Date, _AddDateToNumberEnabled)
                Case Else
                    Throw New NotImplementedException(String.Format(My.Resources.Common_DocumentTypeNotImplemented, _
                        _DocumentType.ToString, Me.GetType().FullName, "DataPortal_Execute"))
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

        Friend Shared Function GetLastProformaInvoiceNumber(ByVal cSerial As String, _
            ByVal nDate As Date, ByVal nAddDateToNumberEnabled As Boolean) As Integer

            Dim myComm As SQLCommand
            If nAddDateToNumberEnabled Then
                myComm = New SQLCommand("FetchLastProformaInvoiceNumberWithDate")
                myComm.AddParam("?DT", nDate)
            Else
                myComm = New SQLCommand("FetchLastProformaInvoiceNumber")
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