Namespace Goods

    <Serializable()> _
    Friend Class ConsignmentDiscardPersistenceObject
        Inherits BusinessBase(Of ConsignmentDiscardPersistenceObject)

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _ParentID As Integer = 0
        Private _ConsignmentID As Integer = 0
        Private _Amount As Double = 0
        Private _TotalValue As Double = 0


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property ParentID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ParentID
            End Get
        End Property

        Public ReadOnly Property ConsignmentID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ConsignmentID
            End Get
        End Property

        Public Property Amount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Amount, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Amount, 6) <> CRound(value, 6) Then
                    _Amount = CRound(value, 6)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property TotalValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValue)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_TotalValue) <> CRound(value) Then
                    _TotalValue = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return "Goods.ConsignmentDiscardPersistenceObject"
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function NewConsignmentDiscardPersistenceObject( _
            ByVal AcquisitionConsignement As ConsignmentPersistenceObject, _
            ByRef AmountToWithdraw As Double) As ConsignmentDiscardPersistenceObject

            Dim result As New ConsignmentDiscardPersistenceObject

            If Not CRound(AmountToWithdraw, 6) >= 0 Then Throw New ArgumentException( _
                "Klaida. Metodui NewConsignmentDiscardPersistenceObject turi būti paduodamas didesnis už 0 kiekis.")
            If AcquisitionConsignement Is Nothing OrElse Not AcquisitionConsignement.ID > 0 _
                OrElse Not AcquisitionConsignement.ParentID > 0 Then Throw New ArgumentNullException( _
                "Klaida. Metodui NewConsignmentDiscardPersistenceObject turi būti paduodamas Old partijos objektas.")

            result._ConsignmentID = AcquisitionConsignement.ID
            If CRound(AmountToWithdraw, 6) >= AcquisitionConsignement.AmountLeft Then
                result._Amount = AcquisitionConsignement.AmountLeft
                result._TotalValue = AcquisitionConsignement.TotalValueLeft
                AmountToWithdraw = CRound(AmountToWithdraw - AcquisitionConsignement.AmountLeft, 6)
            Else
                result._Amount = CRound(AmountToWithdraw, 6)
                result._TotalValue = CRound(CRound(AmountToWithdraw, 6) _
                    * AcquisitionConsignement.UnitValue, 2)
                AmountToWithdraw = 0
            End If

            Return result

        End Function

        Friend Shared Function NewConsignmentDiscardPersistenceObject( _
            ByVal AcquisitionConsignement As ConsignmentItem) As ConsignmentDiscardPersistenceObject

            Dim result As New ConsignmentDiscardPersistenceObject

            If AcquisitionConsignement Is Nothing OrElse Not AcquisitionConsignement.ID > 0 _
                OrElse Not AcquisitionConsignement.ParentID > 0 Then Throw New ArgumentNullException( _
                "Klaida. Metodui NewConsignmentDiscardPersistenceObject turi būti paduodamas Old partijos objektas.")

            result._ConsignmentID = AcquisitionConsignement.ID
            result._Amount = AcquisitionConsignement.AmountLeft
            result._TotalValue = AcquisitionConsignement.TotalValueLeft

            Return result

        End Function

        Friend Shared Function GetConsignmentDiscardPersistenceObject(ByVal dr As DataRow) _
            As ConsignmentDiscardPersistenceObject
            Return New ConsignmentDiscardPersistenceObject(dr)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As DataRow)
            MarkAsChild()
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow)

            _ID = CIntSafe(dr.Item(0), 0)
            _ParentID = CIntSafe(dr.Item(1), 0)
            _ConsignmentID = CIntSafe(dr.Item(2), 0)
            _Amount = CDblSafe(dr.Item(3), 6, 0)
            _TotalValue = CDblSafe(dr.Item(4), 2, 0)

            MarkOld()

        End Sub

        Friend Sub Insert(ByVal nparentID As Integer)

            _ParentID = nparentID

            Dim myComm As New SQLCommand("InsertConsignmentDiscardPersistenceObject")
            AddWithParams(myComm)
            myComm.AddParam("?AA", _ParentID)
            myComm.AddParam("?AB", _ConsignmentID)

            myComm.Execute()

            _ID = myComm.LastInsertID

            MarkOld()

        End Sub

        Friend Sub Update()

            Dim myComm As New SQLCommand("UpdateConsignmentDiscardPersistenceObject")
            myComm.AddParam("?CD", _ID)
            AddWithParams(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()
            DeleteSelf(_ID)
            MarkNew()
        End Sub

        Friend Shared Sub DeleteSelf(ByVal ConsignmentDiscardID As Integer)

            Dim myComm As New SQLCommand("DeleteConsignmentDiscardPersistenceObject")
            myComm.AddParam("?CD", ConsignmentDiscardID)

            myComm.Execute()

        End Sub

        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AC", CRound(_Amount, 6))
            myComm.AddParam("?AD", CRound(_TotalValue))

        End Sub


#End Region

    End Class

End Namespace