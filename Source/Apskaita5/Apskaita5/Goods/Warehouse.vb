﻿Imports ApskaitaObjects.Attributes

Namespace Goods

    ''' <summary>
    ''' Represents a goods warehouse, i.e. extends a warehouse <see cref="General.Account">account</see>
    ''' with goods specific data.
    ''' </summary>
    ''' <remarks>Related helper object (value object list) is <see cref="HelperLists.WarehouseInfoList">WarehouseInfoList</see>.
    ''' Values are stored in the database table warehouses.</remarks>
    <Serializable()> _
    Public NotInheritable Class Warehouse
        Inherits BusinessBase(Of Warehouse)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _Name As String = ""
        Private _Location As String = ""
        Private _Description As String = ""
        Private _IsProduction As Boolean = False
        Private _IsObsolete As Boolean = False
        Private _LastOperationDate As Date = Date.MinValue
        Private _ContainsGoods As Boolean = False
        Private _WarehouseAccount As Long = 0


        ''' <summary>
        ''' Gets an ID of the warehouse that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Data is stored in database field warehouses.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a name of the warehouse.
        ''' </summary>
        ''' <remarks>Data is stored in database field warehouses.Name.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
        Public Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Name.Trim <> value.Trim Then
                    _Name = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an address of the warehouse (physical or logical 
        ''' location of the goods in the warehouse).
        ''' </summary>
        ''' <remarks>Data is stored in database field warehouses.Location.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public Property Location() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Location.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Location.Trim <> value.Trim Then
                    _Location = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a description of the warehouse.
        ''' </summary>
        ''' <remarks>Data is stored in database field warehouses.Description.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public Property Description() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Description.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Description.Trim <> value.Trim Then
                    _Description = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an inventory <see cref="General.Account.ID">account</see> of the warehouse.
        ''' </summary>
        ''' <remarks>Data is stored in database field warehouses.WarehouseAccount.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False, 1, 2)> _
        Public Property WarehouseAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WarehouseAccount
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If WarehouseAccountIsReadOnly Then Exit Property
                If _WarehouseAccount <> value Then
                    _WarehouseAccount = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the warehouse is used in production for production components.
        ''' </summary>
        ''' <remarks>Data is stored in database field warehouses.IsProduction.</remarks>
        Public Property IsProduction() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsProduction
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If IsProductionIsReadOnly Then Exit Property
                If _IsProduction <> value Then
                    _IsProduction = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the warehouse data is only ment for historical purposes, 
        ''' not for use by the current operations.
        ''' </summary>
        ''' <remarks>Data is stored in database field warehouses.IsObsolete.</remarks>
        Public Property IsObsolete() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsObsolete
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _IsObsolete <> value Then
                    _IsObsolete = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a last goods operation date in the warehouse. 
        ''' Returns an empty string if there were no goods operations in the warehouse.
        ''' </summary>
        ''' <remarks>Data retrieved by a subquery.</remarks>
        Public ReadOnly Property LastOperationDate() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _LastOperationDate = Date.MinValue Then Return ""
                Return _LastOperationDate.ToString("yyyy-MM-dd")
            End Get
        End Property

        ''' <summary>
        ''' Whether there were any goods operations in the warehouse.
        ''' </summary>
        ''' <remarks>Data retrieved by a subquery.</remarks>
        Public ReadOnly Property ContainsGoods() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContainsGoods
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="WarehouseAccount">WarehouseAccount</see> 
        ''' property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property WarehouseAccountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContainsGoods
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="WarehouseAccount">IsProduction</see> 
        ''' property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IsProductionIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContainsGoods
            End Get
        End Property



        ''' <summary>
        ''' Gets a human readable description of all the validation errors.
        ''' Returns <see cref="String.Empty" /> if no errors.
        ''' </summary>
        ''' <returns>A human readable description of all the validation errors.
        ''' Returns <see cref="String.Empty" /> if no errors.</returns>
        ''' <remarks></remarks>
        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return String.Format(My.Resources.Common_ErrorInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))
        End Function

        ''' <summary>
        ''' Gets a human readable description of all the validation warnings.
        ''' Returns <see cref="String.Empty" /> if no warnings.
        ''' </summary>
        ''' <returns>A human readable description of all the validation warnings.
        ''' Returns <see cref="String.Empty" /> if no warnings.</returns>
        ''' <remarks></remarks>
        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return String.Format(My.Resources.Common_WarningInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning))
        End Function

        ''' <summary>
        ''' Whether there are any validation warnings.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function HasWarnings() As Boolean
            Return Me.BrokenRulesCollection.WarningCount > 0
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Goods_Warehouse_ToString, _
                _WarehouseAccount.ToString, _Name)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Name"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringValueUniqueInCollectionValidation, _
                New Csla.Validation.RuleArgs("Name"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.AccountFieldValidation, _
                New Csla.Validation.RuleArgs("WarehouseAccount"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringValueUniqueInCollectionValidation, _
                New Csla.Validation.RuleArgs("WarehouseAccount"))
        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewWarehouse() As Warehouse
            Dim result As New Warehouse
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Friend Shared Function GetWarehouse(ByVal dr As DataRow) As Warehouse
            Return New Warehouse(dr)
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
            _Name = CStrSafe(dr.Item(1)).Trim
            _Location = CStrSafe(dr.Item(2)).Trim
            _Description = CStrSafe(dr.Item(3)).Trim
            _IsProduction = ConvertDbBoolean(CIntSafe(dr.Item(4), 0))
            _IsObsolete = ConvertDbBoolean(CIntSafe(dr.Item(5), 0))
            _WarehouseAccount = CLongSafe(dr.Item(6), 0)
            _LastOperationDate = CDateSafe(dr.Item(7), Date.MinValue)
            _ContainsGoods = (_LastOperationDate <> Date.MinValue)

            MarkOld()

        End Sub

        Friend Sub Insert(ByVal parent As WarehouseList)

            Dim myComm As New SQLCommand("InsertWarehouse")
            AddWithParams(myComm)
            myComm.AddParam("?AD", ConvertDbBoolean(_IsProduction))
            myComm.AddParam("?AF", _WarehouseAccount)

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As WarehouseList)

            Dim myComm As SQLCommand
            If _ContainsGoods Then
                myComm = New SQLCommand("UpdateWarehouseGeneral")
            Else
                myComm = New SQLCommand("UpdateWarehouse")
                myComm.AddParam("?AD", ConvertDbBoolean(_IsProduction))
                myComm.AddParam("?AF", _WarehouseAccount)
            End If
            myComm.AddParam("?WD", _ID)
            AddWithParams(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteWarehouse")
            myComm.AddParam("?WD", _ID)

            myComm.Execute()

            MarkNew()

        End Sub


        Private Sub AddWithParams(ByRef myComm As SQLCommand)
            myComm.AddParam("?AA", _Name.Trim)
            myComm.AddParam("?AB", _Location.Trim)
            myComm.AddParam("?AC", _Description.Trim)
            myComm.AddParam("?AE", ConvertDbBoolean(_IsObsolete))
        End Sub

        Friend Sub ReloadUsageData(ByVal warehouseID As Integer, ByVal lastDate As Date)
            If warehouseID = _ID Then
                _LastOperationDate = lastDate
                _ContainsGoods = (lastDate <> Date.MinValue)
            End If
        End Sub

#End Region

    End Class

End Namespace