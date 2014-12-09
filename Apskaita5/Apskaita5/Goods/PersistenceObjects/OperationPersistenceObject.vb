Namespace Goods

    <Serializable()> _
    Friend Class OperationPersistenceObject

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _OperationDate As Date = Today
        Private _OperationType As GoodsOperationType = GoodsOperationType.Acquisition
        Private _JournalEntryID As Integer = 0
        Private _DocNo As String = ""
        Private _Content As String = ""
        Private _GoodsID As Integer = 0
        Private _GoodsInfo As GoodsSummary = Nothing
        Private _WarehouseID As Integer = 0
        Private _Warehouse As WarehouseInfo = Nothing
        Private _Amount As Double = 0
        Private _AmountInWarehouse As Double = 0
        Private _AmountInPurchases As Double = 0
        Private _UnitValue As Double = 0
        Private _TotalValue As Double = 0
        Private _AccountGeneral As Double = 0
        Private _AccountSalesNetCosts As Double = 0
        Private _AccountPurchases As Double = 0
        Private _AccountDiscounts As Double = 0
        Private _AccountPriceCut As Double = 0
        Private _ComplexOperationID As Integer = 0
        Private _ComplexOperationType As GoodsComplexOperationType = GoodsComplexOperationType.InternalTransfer
        Private _ComplexOperationHumanReadable As String = ""
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private _AccountOperation As Long = 0
        Private _AccountOperationValue As Double = 0
        Private _JournalEntryContent As String = ""
        Private _JournalEntryCorrespondence As String = ""
        Private _JournalEntryRelatedPerson As String = ""
        Private _JournalEntryType As DocumentType = DocumentType.None
        Private _JournalEntryTypeHumanReadable As String = ""
        Private _JournalEntryDate As Date = Today
        Private _JournalEntryDocNo As String = ""


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public Property OperationDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationDate
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                If _OperationDate.Date <> value.Date Then
                    _OperationDate = value.Date
                End If
            End Set
        End Property

        Public Property OperationType() As GoodsOperationType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationType
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As GoodsOperationType)
                If _OperationType <> value Then
                    _OperationType = value
                End If
            End Set
        End Property

        Public Property JournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryID
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                If _JournalEntryID <> value Then
                    _JournalEntryID = value
                End If
            End Set
        End Property

        Public Property DocNo() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocNo.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _DocNo.Trim <> value.Trim Then
                    _DocNo = value.Trim
                End If
            End Set
        End Property

        Public Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _Content.Trim <> value.Trim Then
                    _Content = value.Trim
                End If
            End Set
        End Property

        Public Property GoodsID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsID
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                If _GoodsID <> value Then
                    _GoodsID = value
                End If
            End Set
        End Property

        Public ReadOnly Property GoodsInfo() As GoodsSummary
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo
            End Get
        End Property

        Public Property WarehouseID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WarehouseID
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                If _WarehouseID <> value Then
                    _WarehouseID = value
                End If
            End Set
        End Property

        Public Property Warehouse() As WarehouseInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Warehouse
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As WarehouseInfo)
                If Not (_Warehouse Is Nothing AndAlso value Is Nothing) AndAlso _
                    (value Is Nothing OrElse _Warehouse Is Nothing OrElse _Warehouse.ID <> value.ID) Then
                    _Warehouse = value
                    If _Warehouse Is Nothing OrElse Not _Warehouse.ID > 0 Then
                        _WarehouseID = 0
                    Else
                        _WarehouseID = _Warehouse.ID
                    End If
                End If
            End Set
        End Property

        Public Property Amount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Amount, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If CRound(_Amount, 6) <> CRound(value, 6) Then
                    _Amount = CRound(value, 6)
                End If
            End Set
        End Property

        Public Property AmountInWarehouse() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountInWarehouse, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If CRound(_AmountInWarehouse, 6) <> CRound(value, 6) Then
                    _AmountInWarehouse = CRound(value, 6)
                End If
            End Set
        End Property

        Public Property AmountInPurchases() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountInPurchases, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If CRound(_AmountInPurchases, 6) <> CRound(value, 6) Then
                    _AmountInPurchases = CRound(value, 6)
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
                If CRound(_UnitValue, 6) <> CRound(value, 6) Then
                    _UnitValue = CRound(value, 6)
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
                If CRound(_TotalValue) <> CRound(value) Then
                    _TotalValue = CRound(value)
                End If
            End Set
        End Property

        Public Property AccountGeneral() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AccountGeneral)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If CRound(_AccountGeneral) <> CRound(value) Then
                    _AccountGeneral = CRound(value)
                End If
            End Set
        End Property

        Public Property AccountSalesNetCosts() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AccountSalesNetCosts)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If CRound(_AccountSalesNetCosts) <> CRound(value) Then
                    _AccountSalesNetCosts = CRound(value)
                End If
            End Set
        End Property

        Public Property AccountPurchases() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AccountPurchases)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If CRound(_AccountPurchases) <> CRound(value) Then
                    _AccountPurchases = CRound(value)
                End If
            End Set
        End Property

        Public Property AccountDiscounts() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AccountDiscounts)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If CRound(_AccountDiscounts) <> CRound(value) Then
                    _AccountDiscounts = CRound(value)
                End If
            End Set
        End Property

        Public Property AccountPriceCut() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AccountPriceCut)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If CRound(_AccountPriceCut) <> CRound(value) Then
                    _AccountPriceCut = CRound(value)
                End If
            End Set
        End Property

        Public Property ComplexOperationID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexOperationID
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                If _ComplexOperationID <> value Then
                    _ComplexOperationID = value
                End If
            End Set
        End Property

        Public ReadOnly Property ComplexOperationType() As GoodsComplexOperationType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexOperationType
            End Get
        End Property

        Public ReadOnly Property ComplexOperationHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexOperationHumanReadable.Trim
            End Get
        End Property

        Public Property AccountOperation() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountOperation
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                If _AccountOperation <> value Then
                    _AccountOperation = value
                End If
            End Set
        End Property

        Public Property AccountOperationValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AccountOperationValue)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If CRound(_AccountOperationValue) <> CRound(value) Then
                    _AccountOperationValue = CRound(value)
                End If
            End Set
        End Property


        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property


        Public ReadOnly Property JournalEntryContent() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryContent.Trim
            End Get
        End Property

        Public ReadOnly Property JournalEntryCorrespondence() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryCorrespondence.Trim
            End Get
        End Property

        Public ReadOnly Property JournalEntryRelatedPerson() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryRelatedPerson.Trim
            End Get
        End Property

        Public ReadOnly Property JournalEntryType() As DocumentType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryType
            End Get
        End Property

        Public ReadOnly Property JournalEntryTypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryTypeHumanReadable.Trim
            End Get
        End Property

        Public ReadOnly Property JournalEntryDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryDate
            End Get
        End Property

        Public ReadOnly Property JournalEntryDocNo() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryDocNo.Trim
            End Get
        End Property


#End Region

#Region " Factory Methods "

        Public Shared Function NewOperationPersistenceObject() As OperationPersistenceObject
            Return New OperationPersistenceObject
        End Function

        Public Shared Function GetOperationPersistenceObject(ByVal OperationID As Integer, _
            ByVal DoFetch As Boolean) As OperationPersistenceObject
            If Not OperationID > 0 Then Throw New Exception("Klaida. Nenurodytas operacijos ID.")
            Return New OperationPersistenceObject(OperationID, DoFetch)
        End Function

        Private Shared Function GetOperationPersistenceObject(ByVal dr As DataRow) As OperationPersistenceObject
            Return New OperationPersistenceObject(dr)
        End Function

        Public Shared Function GetOperationPersistenceObjectList( _
            ByVal ComplexOperationID As Integer) As List(Of OperationPersistenceObject)

            Dim result As List(Of OperationPersistenceObject)

            Dim myComm As New SQLCommand("FetchOperationPersistenceObjectList")
            myComm.AddParam("?OD", ComplexOperationID)

            Using myData As DataTable = myComm.Fetch

                result = New List(Of OperationPersistenceObject)

                For Each dr As DataRow In myData.Rows

                    result.Add(GetOperationPersistenceObject(dr))

                Next

            End Using

            Return result

        End Function


        Private Sub New()

        End Sub

        Private Sub New(ByVal OperationID As Integer, ByVal DoFetch As Boolean)
            _ID = OperationID
            If DoFetch Then Fetch(OperationID)
        End Sub

        Private Sub New(ByVal dr As DataRow)
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal OperationID As Integer)

            Dim myComm As New SQLCommand("FetchOperationPersistenceObject")
            myComm.AddParam("?OD", OperationID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception("Klaida. Prekių operacija, kurios ID=" _
                    & OperationID.ToString & ", nerasta.")

                Dim dr As DataRow = myData.Rows(0)

                Fetch(dr)

            End Using

        End Sub

        Private Sub Fetch(ByVal dr As DataRow)

            _ID = CIntSafe(dr.Item(0), 0)
            _OperationDate = CDateSafe(dr.Item(1), Today)
            _OperationType = ConvertEnumDatabaseCode(Of GoodsOperationType)(CIntSafe(dr.Item(2), 1))
            _JournalEntryID = CIntSafe(dr.Item(3), 0)
            _DocNo = CStrSafe(dr.Item(4)).Trim
            _Content = CStrSafe(dr.Item(5)).Trim
            _GoodsID = CIntSafe(dr.Item(6), 0)
            _Amount = CDblSafe(dr.Item(7), 6, 0)
            _AmountInWarehouse = CDblSafe(dr.Item(8), 6, 0)
            _UnitValue = CDblSafe(dr.Item(9), 6, 0)
            _TotalValue = CDblSafe(dr.Item(10), 2, 0)
            _AccountGeneral = CDblSafe(dr.Item(11), 2, 0)
            _AccountSalesNetCosts = CDblSafe(dr.Item(12), 2, 0)
            _AccountPurchases = CDblSafe(dr.Item(13), 2, 0)
            _AccountDiscounts = CDblSafe(dr.Item(14), 2, 0)
            _AccountPriceCut = CDblSafe(dr.Item(15), 2, 0)
            _ComplexOperationID = CIntSafe(dr.Item(16), 0)
            If _ComplexOperationID > 0 Then
                _ComplexOperationType = ConvertEnumDatabaseCode(Of GoodsComplexOperationType) _
                    (CIntSafe(dr.Item(17), 1))
                _ComplexOperationHumanReadable = ConvertEnumHumanReadable(_ComplexOperationType)
            End If
            _InsertDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(18), Date.UtcNow), _
                DateTimeKind.Utc).ToLocalTime
            _UpdateDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(19), Date.UtcNow), _
                DateTimeKind.Utc).ToLocalTime
            _AccountOperation = CLongSafe(dr.Item(20), 0)
            _AccountOperationValue = CDblSafe(dr.Item(21), 2, 0)
            _JournalEntryDate = CDateSafe(dr.Item(22), Today)
            _JournalEntryContent = CStrSafe(dr.Item(23)).Trim
            _JournalEntryType = ConvertEnumDatabaseStringCode(Of DocumentType) _
                (CStrSafe(dr.Item(24)).Trim)
            _JournalEntryTypeHumanReadable = ConvertEnumHumanReadable(_JournalEntryType)
            _JournalEntryDocNo = CStrSafe(dr.Item(25)).Trim
            _JournalEntryCorrespondence = CStrSafe(dr.Item(26)).Trim
            _JournalEntryRelatedPerson = CStrSafe(dr.Item(27)).Trim
            _AmountInPurchases = CDblSafe(dr.Item(28), 6, 0)
            _WarehouseID = CIntSafe(dr.Item(29), 0)
            _Warehouse = WarehouseInfo.GetWarehouseInfo(dr, 29)
            _GoodsInfo = GoodsSummary.GetGoodsSummary(dr, 34)

            If Not String.IsNullOrEmpty(_JournalEntryDocNo.Trim) Then _DocNo = _JournalEntryDocNo.Trim

        End Sub


        Public Function Save(ByVal UpdateFinancialData As Boolean) As Integer

            Dim myComm As SQLCommand

            If _ID > 0 Then

                If UpdateFinancialData Then
                    myComm = New SQLCommand("UpdateOperationPersistenceObjectFull")
                    AddWithParamsFinancial(myComm)
                Else
                    myComm = New SQLCommand("UpdateOperationPersistenceObjectGeneral")
                End If
                AddWithParamsGeneral(myComm)
                myComm.AddParam("?CD", _ID)

            Else

                myComm = New SQLCommand("InsertOperationPersistenceObject")
                AddWithParamsGeneral(myComm)
                AddWithParamsFinancial(myComm)
                myComm.AddParam("?AE", _GoodsID)
                myComm.AddParam("?AO", _ComplexOperationID)
                myComm.AddParam("?AP", ConvertEnumDatabaseCode(_OperationType))

            End If

            myComm.Execute()

            If Not _ID > 0 Then _ID = myComm.LastInsertID

            Return _ID

        End Function

        Private Sub AddWithParamsGeneral(ByRef myComm As SQLCommand)

            myComm.AddParam("?AA", _OperationDate.Date)
            myComm.AddParam("?AB", _JournalEntryID)
            myComm.AddParam("?AC", _DocNo.Trim)
            myComm.AddParam("?AD", _Content.Trim)

            _UpdateDate = DateTime.Now
            _UpdateDate = New DateTime(Math.Floor(_UpdateDate.Ticks / TimeSpan.TicksPerSecond) _
                * TimeSpan.TicksPerSecond)
            If Not _ID > 0 Then _InsertDate = _UpdateDate

            myComm.AddParam("?AR", _UpdateDate)
            myComm.AddParam("?AT", _AccountOperation)

        End Sub

        Private Sub AddWithParamsFinancial(ByRef myComm As SQLCommand)

            myComm.AddParam("?AF", _WareHouseID)
            myComm.AddParam("?AG", CRound(_Amount, 6))
            myComm.AddParam("?AH", CRound(_UnitValue, 6))
            myComm.AddParam("?AI", CRound(_TotalValue))
            myComm.AddParam("?AJ", CRound(_AccountGeneral))
            myComm.AddParam("?AK", CRound(_AccountSalesNetCosts))
            myComm.AddParam("?AL", CRound(_AccountPurchases))
            myComm.AddParam("?AM", CRound(_AccountDiscounts))
            myComm.AddParam("?AN", CRound(_AccountPriceCut))
            myComm.AddParam("?AQ", CRound(_AccountOperationValue))
            myComm.AddParam("?AU", CRound(_AmountInWarehouse, 6))
            myComm.AddParam("?AV", CRound(_AmountInPurchases, 6))

        End Sub


        Public Shared Sub Delete(ByVal OperationID As Integer)

            Dim myComm As New SQLCommand("DeleteGoodsOperation")
            myComm.AddParam("?OD", OperationID)

            myComm.Execute()

        End Sub

        Public Shared Sub DeleteConsignments(ByVal OperationID As Integer)

            Dim myComm As New SQLCommand("DeleteConsignmentsByParent")
            myComm.AddParam("?OD", OperationID)

            myComm.Execute()

        End Sub

        Public Shared Sub DeleteConsignmentDiscards(ByVal OperationID As Integer)

            Dim myComm As New SQLCommand("DeleteConsignmentDiscardsByParent")
            myComm.AddParam("?OD", OperationID)

            myComm.Execute()

        End Sub


        Public Shared Sub CheckIfUpdateDateChanged(ByVal OperationID As Integer, _
            ByVal CurrentUpdateDate As DateTime)

            Dim myComm As New SQLCommand("CheckIfGoodsOperationUpdateDateChanged")
            myComm.AddParam("?CD", OperationID)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count < 1 OrElse CDateTimeSafe(myData.Rows(0).Item(0), _
                    Date.MinValue) = Date.MinValue Then Throw New Exception( _
                    "Klaida. Prekių operacija, kurios ID=" & OperationID.ToString & ", nerasta.")
                If DateTime.SpecifyKind(CDateTimeSafe(myData.Rows(0).Item(0), DateTime.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime <> CurrentUpdateDate Then Throw New Exception( _
                    "Klaida. Prekių operacijos atnaujinimo data pasikeitė. Teigtina, kad kitas " _
                    & "vartotojas redagavo šį objektą.")
            End Using

        End Sub

#End Region

    End Class

End Namespace

