Namespace Goods

    <Serializable()> _
    Friend Class ConsignmentPersistenceObject
        Inherits BusinessBase(Of ConsignmentPersistenceObject)

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _ParentID As Integer = 0
        Private _AcquisitionID As Integer = 0
        Private _WarehouseID As Integer = 0
        Private _Amount As Double = 0
        Private _UnitValue As Double = 0
        Private _TotalValue As Double = 0
        Private _AmountWithdrawn As Double = 0
        Private _TotalValueWithdrawn As Double = 0
        Private _AcquisitionDate As Date = Today


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

        Public ReadOnly Property AcquisitionID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AcquisitionID
            End Get
        End Property

        Public ReadOnly Property WarehouseID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WarehouseID
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

        Public Property UnitValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnitValue, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_UnitValue, 6) <> CRound(value, 6) Then
                    _UnitValue = CRound(value, 6)
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

        Public ReadOnly Property AmountWithdrawn() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountWithdrawn, 6)
            End Get
        End Property

        Public ReadOnly Property AmountLeft() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Amount - _AmountWithdrawn, 6)
            End Get
        End Property

        Public ReadOnly Property TotalValueWithdrawn() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueWithdrawn)
            End Get
        End Property

        Public ReadOnly Property TotalValueLeft() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValue - _TotalValueWithdrawn)
            End Get
        End Property

        Public ReadOnly Property AcquisitionDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AcquisitionDate
            End Get
        End Property


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return "Goods.ConsignmentPersistenceObject"
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function NewConsignmentPersistenceObject() As ConsignmentPersistenceObject
            Return New ConsignmentPersistenceObject
        End Function

        Friend Shared Function NewConsignmentPersistenceObject( _
            ByVal AcquisitionConsignement As ConsignmentPersistenceObject, _
            ByRef AmountToWithdraw As Double) As ConsignmentPersistenceObject

            If Not CRound(AmountToWithdraw, 6) >= 0 Then Throw New ArgumentException( _
                "Klaida. Metodui NewConsignmentPersistenceObject turi būti paduodamas didesnis už 0 kiekis.")
            If AcquisitionConsignement Is Nothing OrElse Not AcquisitionConsignement._ID > 0 _
                OrElse Not AcquisitionConsignement._ParentID > 0 Then Throw New ArgumentNullException( _
                "Klaida. Metodui NewConsignmentPersistenceObject turi būti paduodamas Old partijos objektas.")

            Dim result As New ConsignmentPersistenceObject

            If AcquisitionConsignement._AcquisitionID > 0 Then
                result._AcquisitionID = AcquisitionConsignement._AcquisitionID
            Else
                result._AcquisitionID = AcquisitionConsignement._ID
            End If
            result._UnitValue = AcquisitionConsignement.UnitValue
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

        Friend Shared Function NewConsignmentPersistenceObject( _
            ByVal AcquisitionConsignement As ConsignmentItem) As ConsignmentPersistenceObject

            If AcquisitionConsignement Is Nothing OrElse Not AcquisitionConsignement.ID > 0 _
                OrElse Not AcquisitionConsignement.ParentID > 0 Then Throw New ArgumentNullException( _
                "Klaida. Metodui NewConsignmentPersistenceObject turi būti paduodamas Old partijos objektas.")

            Dim result As New ConsignmentPersistenceObject

            If AcquisitionConsignement.AcquisitionID > 0 Then
                result._AcquisitionID = AcquisitionConsignement.AcquisitionID
            Else
                result._AcquisitionID = AcquisitionConsignement.ID
            End If
            result._Amount = AcquisitionConsignement.AmountLeft
            result._WarehouseID = AcquisitionConsignement.WarehouseID

            Return result

        End Function

        Friend Shared Function GetConsignmentPersistenceObject(ByVal dr As DataRow, _
            ByVal IsForUpdate As Boolean) As ConsignmentPersistenceObject
            Return New ConsignmentPersistenceObject(dr, IsForUpdate)
        End Function

        Friend Shared Function GetConsignmentPersistenceObject( _
            ByVal AcquisitionConsignement As ConsignmentItem, ByVal parentID As Integer) As ConsignmentPersistenceObject

            Dim result As New ConsignmentPersistenceObject

            If AcquisitionConsignement.AcquisitionID > 0 Then
                result._AcquisitionID = AcquisitionConsignement.AcquisitionID
            Else
                result._AcquisitionID = AcquisitionConsignement.ID
            End If
            result._Amount = AcquisitionConsignement.AmountLeft
            result._ID = AcquisitionConsignement.UpdatedConsignmentID
            result._ParentID = parentID
            result._WarehouseID = AcquisitionConsignement.WarehouseID

            Return result

        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal IsForUpdate As Boolean)
            MarkAsChild()
            Fetch(dr, IsForUpdate)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow, ByVal IsForUpdate As Boolean)

            _ID = CIntSafe(dr.Item(0), 0)
            _ParentID = CIntSafe(dr.Item(1), 0)
            _AcquisitionID = CIntSafe(dr.Item(2), 0)
            _WarehouseID = CIntSafe(dr.Item(3), 0)
            _Amount = CDblSafe(dr.Item(4), 6, 0)
            _UnitValue = CDblSafe(dr.Item(5), 6, 0)
            _TotalValue = CDblSafe(dr.Item(6), 2, 0)
            _AmountWithdrawn = CDblSafe(dr.Item(7), 6, 0)
            _TotalValueWithdrawn = CDblSafe(dr.Item(8), 2, 0)
            _AcquisitionDate = CDateSafe(dr.Item(9), Today)

            If IsForUpdate Then MarkOld()

        End Sub

        Friend Sub Insert(ByVal nparentID As Integer, ByVal parentWarehouseID As Integer)

            _ParentID = nparentID
            _WarehouseID = parentWarehouseID
            If Not _AcquisitionID > 0 Then _AcquisitionID = nparentID

            Dim myComm As New SQLCommand("InsertConsignmentPersistenceObject")
            AddWithParams(myComm)
            myComm.AddParam("?AA", _ParentID)
            myComm.AddParam("?AB", _AcquisitionID)

            myComm.Execute()

            _ID = myComm.LastInsertID

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parentWarehouseID As Integer)

            If Not IsNew AndAlso Not IsDirty Then Exit Sub

            _WarehouseID = parentWarehouseID

            Dim myComm As New SQLCommand("UpdateConsignmentPersistenceObject")
            myComm.AddParam("?CD", _ID)
            AddWithParams(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()
            DeleteSelf(_ID)
            MarkNew()
        End Sub

        Friend Shared Sub DeleteSelf(ByVal ConsignemntID As Integer)

            Dim myComm As New SQLCommand("DeleteConsignmentPersistenceObject")
            myComm.AddParam("?CD", ConsignemntID)

            myComm.Execute()

        End Sub

        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AC", _WarehouseID)
            myComm.AddParam("?AD", CRound(_Amount, 6))
            myComm.AddParam("?AE", CRound(_UnitValue, 6))
            myComm.AddParam("?AF", CRound(_TotalValue))

        End Sub

#End Region

    End Class

End Namespace