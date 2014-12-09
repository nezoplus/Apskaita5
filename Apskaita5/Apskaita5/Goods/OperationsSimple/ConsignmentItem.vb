Namespace Goods

    <Serializable()> _
    Public Class ConsignmentItem
        Inherits BusinessBase(Of ConsignmentItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _ParentID As Integer = 0
        Private _AcquisitionID As Integer = 0
        Private _WarehouseID As Integer = 0
        Private _UpdatedConsignmentID As Integer = 0
        Private _ConsignmentDiscardID As Integer = 0
        Private _Amount As Double = 0
        Private _UnitValue As Double = 0
        Private _TotalValue As Double = 0
        Private _AmountWithdrawn As Double = 0
        Private _TotalValueWithdrawn As Double = 0
        Private _AmountLeft As Double = 0
        Private _TotalValueLeft As Double = 0
        Private _WarehouseName As String = ""
        Private _AcquisitionDate As Date = Today
        Private _AcquisitionDocNo As String = ""
        Private _AcquisitionDocType As DocumentType = DocumentType.None
        Private _AcquisitionDocTypeHumanReadable As String = ""
        Private _UnitValueChange As Double = 0
        Private _TotalValueChange As Double = 0
        Private _ChangeIsNegative As Boolean = False
        Private _FinancialDataCanChange As Boolean = True


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property FinancialDataCanChange() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
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

        Public ReadOnly Property UpdatedConsignmentID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdatedConsignmentID
            End Get
        End Property

        Public ReadOnly Property ConsignmentDiscardID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ConsignmentDiscardID
            End Get
        End Property

        Public ReadOnly Property Amount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Amount, 6)
            End Get
        End Property

        Public ReadOnly Property UnitValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnitValue, 6)
            End Get
        End Property

        Public ReadOnly Property TotalValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValue, 6)
            End Get
        End Property

        Public ReadOnly Property AmountWithdrawn() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountWithdrawn, 6)
            End Get
        End Property

        Public ReadOnly Property TotalValueWithdrawn() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueWithdrawn)
            End Get
        End Property

        Public ReadOnly Property AmountLeft() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountLeft, 6)
            End Get
        End Property

        Public ReadOnly Property TotalValueLeft() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueLeft)
            End Get
        End Property

        Public ReadOnly Property WarehouseName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WarehouseName.Trim
            End Get
        End Property

        Public ReadOnly Property AcquisitionDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AcquisitionDate
            End Get
        End Property

        Public ReadOnly Property AcquisitionDocNo() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AcquisitionDocNo.Trim
            End Get
        End Property

        Public ReadOnly Property AcquisitionDocType() As DocumentType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AcquisitionDocType
            End Get
        End Property

        Public ReadOnly Property AcquisitionDocTypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AcquisitionDocTypeHumanReadable.Trim
            End Get
        End Property

        Public ReadOnly Property UnitValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnitValueChange, 6)
            End Get
        End Property

        Public Property TotalValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueChange)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_TotalValueChange) <> CRound(value) AndAlso _AmountLeft > 0 Then
                    _TotalValueChange = CRound(value)
                    PropertyHasChanged()
                    _UnitValueChange = CRound(_TotalValueChange / _AmountLeft, 6)
                    PropertyHasChanged("UnitValueChange")
                End If
            End Set
        End Property

        Public ReadOnly Property ChangeIsNegative() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ChangeIsNegative
            End Get
        End Property



        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return "Klaida (-os) eilutėje '" & Me.ToString & "': " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return "Eilutėje '" & Me.ToString & "' gali būti klaida: " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
        End Function

        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            If Not _ID > 0 Then Return ""
            Return _AcquisitionDate.ToString("yyyy-MM-dd") & " įsigijimas sandėlyje " _
                & _WarehouseName & " pagal " & _AcquisitionDocTypeHumanReadable & " Nr. " & _AcquisitionDocNo
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf TotalValueChangeValidation, _
                New Validation.RuleArgs("TotalValueChange"))

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property TotalValueChange is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function TotalValueChangeValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As ConsignmentItem = DirectCast(target, ConsignmentItem)

            If ValObj._ChangeIsNegative AndAlso CRound(ValObj._TotalValueChange) _
                > CRound(ValObj._TotalValueLeft) Then
                e.Description = "Prekių partijos vertė negali būti sumažinti iki nulio (ar iki minuso)."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewConsignmentItem(ByVal dr As DataRow, _
            ByVal nChangeIsNegative As Boolean, ByVal nFinancialDataCanChange As Boolean) As ConsignmentItem
            Return New ConsignmentItem(dr, nChangeIsNegative, nFinancialDataCanChange)
        End Function

        Friend Shared Function GetConsignmentItem(ByVal dr As DataRow, _
            ByVal nChangeIsNegative As Boolean, ByVal nFinancialDataCanChange As Boolean) As ConsignmentItem
            Return New ConsignmentItem(dr, nChangeIsNegative, nFinancialDataCanChange)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal nChangeIsNegative As Boolean, _
            ByVal nFinancialDataCanChange As Boolean)
            MarkAsChild()
            Fetch(dr, nChangeIsNegative, nFinancialDataCanChange)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow, ByVal nChangeIsNegative As Boolean, _
            ByVal nFinancialDataCanChange As Boolean)

            _ID = CIntSafe(dr.Item(0), 0)
            _ParentID = CIntSafe(dr.Item(1), 0)
            _AcquisitionID = CIntSafe(dr.Item(2), 0)
            _WarehouseID = CIntSafe(dr.Item(3), 0)
            _Amount = CDblSafe(dr.Item(4), 6, 0)
            _UnitValue = CDblSafe(dr.Item(5), 6, 0)
            _TotalValue = CDblSafe(dr.Item(6), 2, 0)
            _AmountWithdrawn = CDblSafe(dr.Item(7), 6, 0)
            _TotalValueWithdrawn = CDblSafe(dr.Item(8), 2, 0)
            _WarehouseName = CStrSafe(dr.Item(9)).Trim
            _AcquisitionDate = CDateSafe(dr.Item(10), Today)
            _AcquisitionDocNo = CStrSafe(dr.Item(11)).Trim
            _AcquisitionDocType = ConvertEnumDatabaseStringCode(Of DocumentType)(CStrSafe(dr.Item(12)))

            _AcquisitionDocTypeHumanReadable = ConvertEnumHumanReadable(_AcquisitionDocType)
            _AmountLeft = CRound(_Amount - _AmountWithdrawn, 6)
            _TotalValueLeft = CRound(_TotalValue - _TotalValueWithdrawn, 6)

            _ChangeIsNegative = nChangeIsNegative

            If CIntSafe(dr.Item(15), 0) > 0 Then

                If CDblSafe(dr.Item(13), 2, 0) > CDblSafe(dr.Item(14), 2, 0) Then
                    _TotalValueChange = CRound(CDblSafe(dr.Item(13), 2, 0) - CDblSafe(dr.Item(14), 2, 0))
                Else
                    _TotalValueChange = CRound(CDblSafe(dr.Item(14), 2, 0) - CDblSafe(dr.Item(13), 2, 0))
                End If
                If CRound(_AmountLeft, 6) <> 0 Then
                    _UnitValueChange = CRound(_TotalValueChange / _AmountLeft, 6)
                Else
                    _UnitValueChange = 0
                End If
                _ConsignmentDiscardID = CIntSafe(dr.Item(15), 0)
                _UpdatedConsignmentID = CIntSafe(dr.Item(16), 0)

                MarkOld()

            End If

            _FinancialDataCanChange = nFinancialDataCanChange

            ValidationRules.CheckRules()

        End Sub

        Friend Sub Insert(ByVal parentID As Integer)

            Dim ConsignmentDiscard As ConsignmentDiscardPersistenceObject = _
                ConsignmentDiscardPersistenceObject.NewConsignmentDiscardPersistenceObject(Me)

            Dim UpdatedConsignment As ConsignmentPersistenceObject = _
                ConsignmentPersistenceObject.NewConsignmentPersistenceObject(Me)

            If _ChangeIsNegative Then
                UpdatedConsignment.TotalValue = CRound(_TotalValueLeft - _TotalValueChange)
                UpdatedConsignment.UnitValue = CRound(_UnitValue - _UnitValueChange, 6)
            Else
                UpdatedConsignment.TotalValue = CRound(_TotalValueLeft + _TotalValueChange)
                UpdatedConsignment.UnitValue = CRound(_UnitValue + _UnitValueChange, 6)
            End If

            UpdatedConsignment.Insert(parentID, _WarehouseID)
            _UpdatedConsignmentID = UpdatedConsignment.ID
            ConsignmentDiscard.Insert(parentID)
            _ConsignmentDiscardID = ConsignmentDiscard.ID

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parentID As Integer)

            Dim UpdatedConsignment As ConsignmentPersistenceObject = _
                ConsignmentPersistenceObject.GetConsignmentPersistenceObject(Me, parentID)

            If _ChangeIsNegative Then
                UpdatedConsignment.TotalValue = CRound(_TotalValueLeft - _TotalValueChange)
                UpdatedConsignment.UnitValue = CRound(_UnitValue - _UnitValueChange, 6)
            Else
                UpdatedConsignment.TotalValue = CRound(_TotalValueLeft + _TotalValueChange)
                UpdatedConsignment.UnitValue = CRound(_UnitValue + _UnitValueChange, 6)
            End If

            UpdatedConsignment.Update(_WarehouseID)

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            ConsignmentPersistenceObject.DeleteSelf(_UpdatedConsignmentID)
            ConsignmentDiscardPersistenceObject.DeleteSelf(_ConsignmentDiscardID)
            _UpdatedConsignmentID = 0
            _ConsignmentDiscardID = 0

            MarkNew()

        End Sub

#End Region

    End Class

End Namespace