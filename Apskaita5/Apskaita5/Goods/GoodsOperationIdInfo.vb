Namespace Goods

    <Serializable()> _
    Public Class GoodsOperationIdInfo
        Inherits ReadOnlyBase(Of GoodsOperationIdInfo)

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _Type As GoodsOperationType = GoodsOperationType.Discard
        Private _ComplexType As GoodsComplexOperationType = GoodsComplexOperationType.BulkDiscard
        Private _IsComplex As Boolean = False
        Private _JournalEntryID As Integer = 0
        Private _DocumentType As DocumentType = DocumentType.GoodsWriteOff


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property [Type]() As GoodsOperationType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
        End Property

        Public ReadOnly Property ComplexType() As GoodsComplexOperationType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexType
            End Get
        End Property

        Public ReadOnly Property IsComplex() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsComplex
            End Get
        End Property

        Public ReadOnly Property JournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryID
            End Get
        End Property

        Public ReadOnly Property DocumentType() As DocumentType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentType
            End Get
        End Property


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return "Goods.GoodsOperationIdInfo"
        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.GoodsOperationIdInfo1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetGoodsOperationIdInfo(ByVal nJournalEntryID As Integer, _
            ByVal nDocumentType As DocumentType) As GoodsOperationIdInfo
            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")
            Return DataPortal.Fetch(Of GoodsOperationIdInfo)(New Criteria(nJournalEntryID, nDocumentType))
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _ID As Integer
            Private _DocumentType As DocumentType
            Public ReadOnly Property ID() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public ReadOnly Property DocumentType() As DocumentType
                Get
                    Return _DocumentType
                End Get
            End Property
            Public Sub New(ByVal nID As Integer, ByVal nDocumentType As DocumentType)
                _ID = nID
                _DocumentType = nDocumentType
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            Dim myComm As New SQLCommand("FetchGoodsOperationIdInfo")
            myComm.AddParam("?JD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Throw New Exception("Klaida. Prekių operacija, kurios BŽ ID='" _
                    & criteria.ID & "', nerasta.)")

                _JournalEntryID = criteria.ID
                _DocumentType = criteria.DocumentType

                For Each dr As DataRow In myData.Rows

                    If criteria.DocumentType = ApskaitaObjects.DocumentType.GoodsAccountChange _
                        AndAlso Not ConvertDbBoolean(CIntSafe(dr.Item(0), 0)) Then

                        Dim t As GoodsOperationType = ConvertEnumDatabaseCode(Of GoodsOperationType) _
                            (CIntSafe(dr.Item(2), 0))

                        If t = GoodsOperationType.AccountDiscountsChange OrElse _
                            t = GoodsOperationType.AccountPurchasesChange OrElse _
                            t = GoodsOperationType.AccountSalesNetCostsChange OrElse _
                            t = GoodsOperationType.AccountValueReductionChange Then

                            _ID = CIntSafe(dr.Item(1), 0)
                            _Type = t
                            _IsComplex = False

                            Exit Sub

                        End If

                    ElseIf criteria.DocumentType = ApskaitaObjects.DocumentType.GoodsInternalTransfer _
                        AndAlso ConvertDbBoolean(CIntSafe(dr.Item(0), 0)) AndAlso _
                        ConvertEnumDatabaseCode(Of GoodsComplexOperationType)(CIntSafe(dr.Item(2), 0)) _
                            = GoodsComplexOperationType.InternalTransfer Then

                        _ID = CIntSafe(dr.Item(1), 0)
                        _ComplexType = GoodsComplexOperationType.InternalTransfer
                        _IsComplex = True

                        Exit Sub

                    ElseIf criteria.DocumentType = ApskaitaObjects.DocumentType.GoodsInventorization _
                        AndAlso ConvertDbBoolean(CIntSafe(dr.Item(0), 0)) AndAlso _
                        ConvertEnumDatabaseCode(Of GoodsComplexOperationType)(CIntSafe(dr.Item(2), 0)) _
                        = GoodsComplexOperationType.Inventorization Then

                        _ID = CIntSafe(dr.Item(1), 0)
                        _ComplexType = GoodsComplexOperationType.Inventorization
                        _IsComplex = True

                        Exit Sub

                    ElseIf criteria.DocumentType = ApskaitaObjects.DocumentType.GoodsProduction _
                        AndAlso ConvertDbBoolean(CIntSafe(dr.Item(0), 0)) AndAlso _
                        ConvertEnumDatabaseCode(Of GoodsComplexOperationType)(CIntSafe(dr.Item(2), 0)) _
                        = GoodsComplexOperationType.Production Then

                        _ID = CIntSafe(dr.Item(1), 0)
                        _ComplexType = GoodsComplexOperationType.Production
                        _IsComplex = True

                        Exit Sub

                    ElseIf criteria.DocumentType = ApskaitaObjects.DocumentType.GoodsRevalue _
                        AndAlso ConvertDbBoolean(CIntSafe(dr.Item(0), 0)) AndAlso _
                        ConvertEnumDatabaseCode(Of GoodsComplexOperationType)(CIntSafe(dr.Item(2), 0)) _
                        = GoodsComplexOperationType.BulkPriceCut Then

                        _ID = CIntSafe(dr.Item(1), 0)
                        _ComplexType = GoodsComplexOperationType.BulkPriceCut
                        _IsComplex = True

                        Exit Sub

                    ElseIf criteria.DocumentType = ApskaitaObjects.DocumentType.GoodsRevalue _
                        AndAlso Not ConvertDbBoolean(CIntSafe(dr.Item(0), 0)) AndAlso _
                        ConvertEnumDatabaseCode(Of GoodsOperationType)(CIntSafe(dr.Item(2), 0)) _
                        = GoodsOperationType.PriceCut Then

                        _ID = CIntSafe(dr.Item(1), 0)
                        _Type = GoodsOperationType.PriceCut
                        _IsComplex = False

                        Exit Sub

                    ElseIf criteria.DocumentType = ApskaitaObjects.DocumentType.GoodsWriteOff _
                        AndAlso ConvertDbBoolean(CIntSafe(dr.Item(0), 0)) AndAlso _
                        ConvertEnumDatabaseCode(Of GoodsComplexOperationType)(CIntSafe(dr.Item(2), 0)) _
                        = GoodsComplexOperationType.BulkDiscard Then

                        _ID = CIntSafe(dr.Item(1), 0)
                        _ComplexType = GoodsComplexOperationType.BulkDiscard
                        _IsComplex = True

                        Exit Sub

                    ElseIf criteria.DocumentType = ApskaitaObjects.DocumentType.GoodsWriteOff _
                        AndAlso Not ConvertDbBoolean(CIntSafe(dr.Item(0), 0)) AndAlso _
                        ConvertEnumDatabaseCode(Of GoodsOperationType)(CIntSafe(dr.Item(2), 0)) _
                        = GoodsOperationType.Discard Then

                        _ID = CIntSafe(dr.Item(1), 0)
                        _Type = GoodsOperationType.Discard
                        _IsComplex = False

                        Exit Sub

                    End If

                Next

                Dim foundTypes As String = ""
                For Each dr As DataRow In myData.Rows

                    If ConvertDbBoolean(CIntSafe(dr.Item(0), 0)) Then
                        foundTypes = AddWithNewLine(foundTypes, ConvertEnumHumanReadable( _
                            ConvertEnumDatabaseCode(Of GoodsComplexOperationType)(CIntSafe(dr.Item(2), 0))), False)
                    Else
                        foundTypes = AddWithNewLine(foundTypes, ConvertEnumHumanReadable( _
                            ConvertEnumDatabaseCode(Of GoodsOperationType)(CIntSafe(dr.Item(2), 0))), False)
                    End If

                Next

                Throw New Exception("Klaida. Nerasta prekių operacija, atitinkanti dokumento tipą (" _
                    & ConvertEnumHumanReadable(criteria.DocumentType) & "). Rastos operacijos " _
                    & "neatitinkančios dokumento tipo:" & vbCrLf & foundTypes)

            End Using

        End Sub

#End Region

    End Class

End Namespace