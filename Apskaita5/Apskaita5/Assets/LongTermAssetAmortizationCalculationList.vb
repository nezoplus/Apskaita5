Namespace Assets

    <Serializable()> _
Public Class LongTermAssetAmortizationCalculationList
        Inherits ReadOnlyListBase(Of LongTermAssetAmortizationCalculationList, _
            LongTermAssetAmortizationCalculation)

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Assets.LongTermAssetOperation2")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetList(ByVal nAssetID As Integer(), _
            ByVal nEditedAmortizationOperationID As Integer(), _
            ByVal nDateTo As Date) As LongTermAssetAmortizationCalculationList
            Return DataPortal.Fetch(Of LongTermAssetAmortizationCalculationList)( _
                New Criteria(nAssetID, nEditedAmortizationOperationID, nDateTo))
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _AssetID As Integer()
            Private _EditedAmortizationOperationID As Integer()
            Private _DateTo As Date
            Public ReadOnly Property AssetID() As Integer()
                Get
                    Return _AssetID
                End Get
            End Property
            Public ReadOnly Property EditedAmortizationOperationID() As Integer()
                Get
                    Return _EditedAmortizationOperationID
                End Get
            End Property
            Public ReadOnly Property DateTo() As Date
                Get
                    Return _DateTo
                End Get
            End Property
            Public Sub New(ByVal nAssetID As Integer(), ByVal nEditedAmortizationOperationID As Integer(), _
                ByVal nDateTo As Date)
                _AssetID = nAssetID
                _EditedAmortizationOperationID = nEditedAmortizationOperationID
                _DateTo = nDateTo.Date
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai informacijai gauti.")

            RaiseListChangedEvents = False
            IsReadOnly = False

            For i As Integer = 1 To criteria.AssetID.Length
                Add(LongTermAssetAmortizationCalculation. _
                    GetLongTermAssetAmortizationCalculationServerSide( _
                    criteria.AssetID(i - 1), criteria.EditedAmortizationOperationID(i - 1), _
                    criteria.DateTo))
            Next

            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace