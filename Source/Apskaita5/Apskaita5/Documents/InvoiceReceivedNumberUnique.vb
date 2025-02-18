﻿Namespace Documents

    <Serializable()> _
    Public NotInheritable Class InvoiceReceivedNumberUnique
        Inherits ReadOnlyBase(Of InvoiceReceivedNumberUnique)

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _InvoiceID As Integer = 0
        Private _InvoiceDate As Date = Today
        Private _InvoiceNumber As String = ""
        Private _InvoicePersonID As Integer = 0
        Private _CheckedByDate As Boolean = False
        Private _CheckedByPerson As Boolean = False
        Private _IsUnique As Boolean = True
        Private _ExistingInvoices As String = ""


        Public ReadOnly Property InvoiceID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InvoiceID
            End Get
        End Property

        Public ReadOnly Property InvoiceDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InvoiceDate
            End Get
        End Property

        Public ReadOnly Property InvoiceNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InvoiceNumber.Trim
            End Get
        End Property

        Public ReadOnly Property InvoicePersonID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InvoicePersonID
            End Get
        End Property

        Public ReadOnly Property CheckedByDate() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CheckedByDate
            End Get
        End Property

        Public ReadOnly Property CheckedByPerson() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CheckedByPerson
            End Get
        End Property

        Public ReadOnly Property IsUnique() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsUnique
            End Get
        End Property

        Public ReadOnly Property ExistingInvoices() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ExistingInvoices.Trim
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            If _IsUnique Then Return ""
            If _CheckedByDate AndAlso _CheckedByPerson Then
                Return "Apskaitoje jau registruota gauta sąskaita faktūra tokiu pačiu numeriu, " _
                    & "ta pačia data ir tam pačiam kontrahentui."
            ElseIf _CheckedByDate Then
                Return "Apskaitoje jau registruota gauta sąskaita faktūra tokiu pačiu numeriu " _
                    & "ir ta pačia data."
            ElseIf _CheckedByPerson Then
                Return "Apskaitoje jau registruota gauta sąskaita faktūra tokiu pačiu numeriu " _
                    & "ir tam pačiam kontrahentui. Esamos (-ų) faktūros (-ų) data (-os): " _
                    & _ExistingInvoices & "."
            Else
                Return "Apskaitoje jau registruota gauta sąskaita faktūra tokiu pačiu numeriu. " _
                    & "Esamos (-ų) faktūros (-ų) data (-os): " & _ExistingInvoices & "."
            End If
        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.InvoiceReceived2")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetInvoiceReceivedNumberUnique(ByVal nInvoice As InvoiceReceived, _
            ByVal nCheckedByDate As Boolean, ByVal nCheckedByPerson As Boolean) As InvoiceReceivedNumberUnique

            If nInvoice Is Nothing Then Throw New ArgumentNullException( _
                "Klaida. Metodui GetInvoiceReceivedNumberUnique nenurodyta gauta sąskaita faktūra")

            Dim SupplierID As Integer = 0
            If Not nInvoice.Supplier Is Nothing Then SupplierID = nInvoice.Supplier.ID

            Return GetInvoiceReceivedNumberUnique(nInvoice.ID, nInvoice.Number, _
                nCheckedByDate, nInvoice.Date, nCheckedByPerson, SupplierID)

        End Function

        Public Shared Function GetInvoiceReceivedNumberUnique(ByVal nInvoiceID As Integer, _
            ByVal nInvoiceNumber As String, ByVal nCheckedByDate As Boolean, _
            ByVal nInvoiceDate As Date, ByVal nCheckedByPerson As Boolean, _
            ByVal nInvoicePersonID As Integer) As InvoiceReceivedNumberUnique
            Return DataPortal.Fetch(Of InvoiceReceivedNumberUnique) _
                (New Criteria(nInvoiceID, nInvoiceNumber, nCheckedByDate, _
                nInvoiceDate, nCheckedByPerson, nInvoicePersonID))
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _InvoiceID As Integer = 0
            Private _InvoiceDate As Date = Today
            Private _InvoiceNumber As String = ""
            Private _InvoicePersonID As Integer = 0
            Private _CheckedByDate As Boolean = False
            Private _CheckedByPerson As Boolean = False
            Public ReadOnly Property InvoiceID() As Integer
                Get
                    Return _InvoiceID
                End Get
            End Property
            Public ReadOnly Property InvoiceDate() As Date
                Get
                    Return _InvoiceDate
                End Get
            End Property
            Public ReadOnly Property InvoiceNumber() As String
                Get
                    Return _InvoiceNumber.Trim
                End Get
            End Property
            Public ReadOnly Property InvoicePersonID() As Integer
                Get
                    Return _InvoicePersonID
                End Get
            End Property
            Public ReadOnly Property CheckedByDate() As Boolean
                Get
                    Return _CheckedByDate
                End Get
            End Property
            Public ReadOnly Property CheckedByPerson() As Boolean
                Get
                    Return _CheckedByPerson
                End Get
            End Property
            Public Sub New(ByVal nInvoiceID As Integer, ByVal nInvoiceNumber As String, _
                ByVal nCheckedByDate As Boolean, ByVal nInvoiceDate As Date, _
                ByVal nCheckedByPerson As Boolean, ByVal nInvoicePersonID As Integer)
                _InvoiceID = nInvoiceID
                _InvoiceNumber = nInvoiceNumber
                _CheckedByDate = nCheckedByDate
                _InvoiceDate = nInvoiceDate
                _CheckedByPerson = nCheckedByPerson
                _InvoicePersonID = nInvoicePersonID
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")
            If criteria.InvoiceNumber Is Nothing OrElse String.IsNullOrEmpty(criteria.InvoiceNumber.Trim) Then _
                Throw New ArgumentNullException("Klaida. Gautos sąskaitos faktūros numeris negali būti tuščias.")

            _InvoiceID = criteria.InvoiceID
            _InvoiceDate = criteria.InvoiceDate
            _InvoiceNumber = criteria.InvoiceNumber
            _InvoicePersonID = criteria.InvoicePersonID
            _CheckedByDate = criteria.CheckedByDate
            _CheckedByPerson = criteria.CheckedByPerson

            Dim myComm As New SQLCommand("FetchInvoiceReceivedNumberUnique")
            myComm.AddParam("?DN", criteria.InvoiceNumber.Trim)
            myComm.AddParam("?CD", criteria.InvoiceID)
            myComm.AddParam("?BD", ConvertDbBoolean(criteria.CheckedByDate))
            myComm.AddParam("?DT", criteria.InvoiceDate)
            myComm.AddParam("?BP", ConvertDbBoolean(criteria.CheckedByPerson))
            myComm.AddParam("?PD", criteria.InvoicePersonID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count > 0 Then

                    _IsUnique = False

                    Dim list As New List(Of String)

                    For Each dr As DataRow In myData.Rows
                        list.Add(CDateSafe(dr.Item(0), Date.MinValue).ToString("yyyy-MM-dd"))
                    Next

                    _ExistingInvoices = String.Join(", ", list.ToArray)

                End If

            End Using

        End Sub

#End Region

    End Class

End Namespace