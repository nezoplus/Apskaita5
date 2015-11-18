Namespace Documents

    <Serializable()> _
    Public Class InvoiceMadeList
        Inherits ReadOnlyListBase(Of InvoiceMadeList, InvoiceMade)

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return InvoiceMade.CanGetObject
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetList(ByVal SelectedInvoiceIDs As Integer()) As InvoiceMadeList
            Return DataPortal.Fetch(Of InvoiceMadeList)(New Criteria(SelectedInvoiceIDs))
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _SelectedInvoiceIDs As Integer()
            Public ReadOnly Property SelectedInvoiceIDs() As Integer()
                Get
                    Return _SelectedInvoiceIDs
                End Get
            End Property
            Public Sub New(ByVal nSelectedInvoiceIDs As Integer())
                _SelectedInvoiceIDs = nSelectedInvoiceIDs
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepaanka šiems duomenims gauti.")

            RaiseListChangedEvents = False
            IsReadOnly = False

            For Each id As Integer In criteria.SelectedInvoiceIDs
                Add(InvoiceMade.GetInvoiceMadeChild(id))
            Next

            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace