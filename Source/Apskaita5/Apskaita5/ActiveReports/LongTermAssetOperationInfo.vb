﻿Imports ApskaitaObjects.Assets
Imports ApskaitaObjects.Attributes

Namespace ActiveReports

    ''' <summary>
    ''' Represents an item of <see cref="LongTermAssetOperationInfoListParent">LongTermAssetOperationInfoListParent</see> report.
    ''' Contains information about a long term asset operation.
    ''' </summary>
    ''' <remarks>Should only be used as a child of <see cref="LongTermAssetOperationInfoList">LongTermAssetOperationInfoList</see>.
    ''' Values are stored in the database table turtas_op.</remarks>
    <Serializable()> _
Public NotInheritable Class LongTermAssetOperationInfo
        Inherits ReadOnlyBase(Of LongTermAssetOperationInfo)

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _IsComplexAct As Boolean = False
        Private _ComplexActID As Integer = 0
        Private _Type As LtaOperationType = LtaOperationType.Discard
        Private _OperationType As String = ""
        Private _AccountType As LtaAccountChangeType = LtaAccountChangeType.AcquisitionAccount
        Private _AccountChangeType As String = ""
        Private _Date As Date = Today
        Private _Content As String = ""
        Private _DocumentNumber As String = ""
        Private _AttachedJournalEntryID As Integer = 0
        Private _AttachedJournalEntry As String = ""
        Private _CorrespondingAccount As Integer = 0
        Private _BeforeOperationAcquisitionAccountValue As Double = 0
        Private _BeforeOperationAcquisitionAccountValuePerUnit As Double = 0
        Private _BeforeOperationAmortizationAccountValue As Double = 0
        Private _BeforeOperationAmortizationAccountValuePerUnit As Double = 0
        Private _BeforeOperationValueDecreaseAccountValue As Double = 0
        Private _BeforeOperationValueDecreaseAccountValuePerUnit As Double = 0
        Private _BeforeOperationValueIncreaseAccountValue As Double = 0
        Private _BeforeOperationValueIncreaseAccountValuePerUnit As Double = 0
        Private _BeforeOperationValueIncreaseAmmortizationAccountValue As Double = 0
        Private _BeforeOperationValueIncreaseAmmortizationAccountValuePerUnit As Double = 0
        Private _BeforeOperationValue As Double = 0
        Private _BeforeOperationValuePerUnit As Double = 0
        Private _BeforeOperationAmmount As Integer = 0
        Private _OperationAcquisitionAccountValueChange As Double = 0
        Private _OperationAcquisitionAccountValueChangePerUnit As Double = 0
        Private _OperationAmortizationAccountValueChange As Double = 0
        Private _OperationAmortizationAccountValueChangePerUnit As Double = 0
        Private _OperationValueDecreaseAccountValueChange As Double = 0
        Private _OperationValueDecreaseAccountValueChangePerUnit As Double = 0
        Private _OperationValueIncreaseAccountValueChange As Double = 0
        Private _OperationValueIncreaseAccountValueChangePerUnit As Double = 0
        Private _OperationValueIncreaseAmmortizationAccountValueChange As Double = 0
        Private _OperationValueIncreaseAmmortizationAccountValueChangePerUnit As Double = 0
        Private _OperationValueChange As Double = 0
        Private _OperationValueChangePerUnit As Double = 0
        Private _OperationAmmountChange As Integer = 0
        Private _AfterOperationAcquisitionAccountValue As Double = 0
        Private _AfterOperationAcquisitionAccountValuePerUnit As Double = 0
        Private _AfterOperationAmortizationAccountValue As Double = 0
        Private _AfterOperationAmortizationAccountValuePerUnit As Double = 0
        Private _AfterOperationValueDecreaseAccountValue As Double = 0
        Private _AfterOperationValueDecreaseAccountValuePerUnit As Double = 0
        Private _AfterOperationValueIncreaseAccountValue As Double = 0
        Private _AfterOperationValueIncreaseAccountValuePerUnit As Double = 0
        Private _AfterOperationValueIncreaseAmmortizationAccountValue As Double = 0
        Private _AfterOperationValueIncreaseAmmortizationAccountValuePerUnit As Double = 0
        Private _AfterOperationValue As Double = 0
        Private _AfterOperationValuePerUnit As Double = 0
        Private _AfterOperationAmmount As Integer = 0
        Private _NewAmortizationPeriod As Integer = 0


        ''' <summary>
        ''' Gets an ID of the operation that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in the database field turtas_op.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the long term asset operation is a part of a complex long term asset operation (mass discard etc.).
        ''' </summary>
        ''' <remarks>Value is stored in the database field turtas_op.IsComplexAct.</remarks>
        Public ReadOnly Property IsComplexAct() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsComplexAct
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID of the complex long term asset operation (mass discard etc.).
        ''' </summary>
        ''' <remarks>Value is stored in the database field turtas_op.IsComplexAct.</remarks>
        Public ReadOnly Property ComplexActID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexActID
            End Get
        End Property

        ''' <summary>
        ''' Gets a type of the long term asset operation.
        ''' </summary>
        ''' <remarks>Value is stored in the database field turtas_op.OperationType.</remarks>
        Public ReadOnly Property [Type]() As LtaOperationType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
        End Property

        ''' <summary>
        ''' Gets a type of the long term asset operation as a human readable (localized) string.
        ''' </summary>
        ''' <remarks>Value is stored in the database field turtas_op.OperationType.</remarks>
        Public ReadOnly Property OperationType() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationType
            End Get
        End Property

        ''' <summary>
        ''' Gets a type of the long term asset account change operation.
        ''' </summary>
        ''' <remarks>Only relevant when the <see cref="OperationType">OperationType</see>
        ''' is set to <see cref="LtaOperationType.AccountChange">LtaOperationType.AccountChange</see>.
        ''' Value is stored in the database field turtas_op.AccountOperationType.</remarks>
        Public ReadOnly Property AccountType() As LtaAccountChangeType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountType
            End Get
        End Property

        ''' <summary>
        ''' Gets a type of the long term asset account change operation 
        ''' as a human readable (localized) string.
        ''' </summary>
        ''' <remarks>Only relevant when the <see cref="OperationType">OperationType</see>
        ''' is set to <see cref="LtaOperationType.AccountChange">LtaOperationType.AccountChange</see>.
        ''' Value is stored in the database field turtas_op.AccountOperationType.</remarks>
        Public ReadOnly Property AccountChangeType() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountChangeType
            End Get
        End Property

        ''' <summary>
        ''' Gets a date of the long term asset operation.
        ''' </summary>
        ''' <remarks>Value is stored in the database field turtas_op.OperationDate.</remarks>
        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        ''' <summary>
        ''' Gets a content (description) of the long term asset operation.
        ''' </summary>
        ''' <remarks>Value is stored in the database field turtas_op.Content.</remarks>
        Public ReadOnly Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content
            End Get
        End Property

        ''' <summary>
        ''' Gets a number of act that is drawn by the long term asset operation.
        ''' </summary>
        ''' <remarks>Value is stored in the database field turtas_op.ActNumber.</remarks>
        Public ReadOnly Property ActNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentNumber
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="General.JournalEntry.ID">ID of the journal entry</see> 
        ''' that is attached to or encapsulated by the long term asset operation.
        ''' </summary>
        ''' <remarks>Value is stored in the database field turtas_op.JE_ID.</remarks>
        Public ReadOnly Property AttachedJournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AttachedJournalEntryID
            End Get
        End Property

        ''' <summary>
        ''' Gets a description of the <see cref="General.JournalEntry">journal entry</see> 
        ''' that is attached to or encapsulated by the long term asset operation.
        ''' </summary>
        ''' <remarks>Value is stored in the database field turtas_op.JE_ID.</remarks>
        Public ReadOnly Property AttachedJournalEntry() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AttachedJournalEntry
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.Account.ID">corresponding account</see> of the long term asset operation
        ''' (e.g. discard costs account, amortization costs account etc.).
        ''' </summary>
        ''' <remarks>Value is stored in the database field turtas_op.AccountCorresponding.</remarks>
        Public ReadOnly Property CorrespondingAccount() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CorrespondingAccount
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountAcquisition">AccountAcquisition</see> before the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        Public ReadOnly Property BeforeOperationAcquisitionAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationAcquisitionAccountValue)
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountAcquisition">AccountAcquisition</see> per unit before the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDUNITASSET)> _
        Public ReadOnly Property BeforeOperationAcquisitionAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationAcquisitionAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountAccumulatedAmortization">AccountAccumulatedAmortization</see> before the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property BeforeOperationAmortizationAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationAmortizationAccountValue)
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountAccumulatedAmortization">AccountAccumulatedAmortization</see> per unit before the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDUNITASSET)> _
        Public ReadOnly Property BeforeOperationAmortizationAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationAmortizationAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountValueDecrease">AccountValueDecrease</see> before the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property BeforeOperationValueDecreaseAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationValueDecreaseAccountValue)
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountValueDecrease">AccountValueDecrease</see> per unit before the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDUNITASSET)> _
        Public ReadOnly Property BeforeOperationValueDecreaseAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationValueDecreaseAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountValueIncrease">AccountValueIncrease</see> before the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property BeforeOperationValueIncreaseAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationValueIncreaseAccountValue)
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountValueIncrease">AccountValueIncrease</see> per unit before the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDUNITASSET)> _
        Public ReadOnly Property BeforeOperationValueIncreaseAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationValueIncreaseAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountRevaluedPortionAmmortization">AccountRevaluedPortionAmmortization</see> before the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property BeforeOperationValueIncreaseAmmortizationAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationValueIncreaseAmmortizationAccountValue)
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountRevaluedPortionAmmortization">AccountRevaluedPortionAmmortization</see> per unit before the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDUNITASSET)> _
        Public ReadOnly Property BeforeOperationValueIncreaseAmmortizationAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationValueIncreaseAmmortizationAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' A total value of the long term asset before the operation.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property BeforeOperationValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationValue)
            End Get
        End Property

        ''' <summary>
        ''' A unit value of the long term asset before the operation.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDUNITASSET)> _
        Public ReadOnly Property BeforeOperationValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BeforeOperationValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' An amount of the long term asset before the operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property BeforeOperationAmmount() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BeforeOperationAmmount
            End Get
        End Property

        ''' <summary>
        ''' A change of the balance for the <see cref="LongTermAsset.AccountAcquisition">AccountAcquisition</see> made by the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property OperationAcquisitionAccountValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationAcquisitionAccountValueChange)
            End Get
        End Property

        ''' <summary>
        ''' A change of the balance for the <see cref="LongTermAsset.AccountAcquisition">AccountAcquisition</see> per unit made by the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDUNITASSET)> _
        Public ReadOnly Property OperationAcquisitionAccountValueChangePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationAcquisitionAccountValueChangePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' A change of the balance for the <see cref="LongTermAsset.AccountAccumulatedAmortization">AccountAccumulatedAmortization</see> made by the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property OperationAmortizationAccountValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationAmortizationAccountValueChange)
            End Get
        End Property

        ''' <summary>
        ''' A change of the balance for the <see cref="LongTermAsset.AccountAccumulatedAmortization">AccountAccumulatedAmortization</see> per unit made by the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDUNITASSET)> _
        Public ReadOnly Property OperationAmortizationAccountValueChangePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationAmortizationAccountValueChangePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' A change of the balance for the <see cref="LongTermAsset.AccountValueDecrease">AccountValueDecrease</see> made by the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property OperationValueDecreaseAccountValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationValueDecreaseAccountValueChange)
            End Get
        End Property

        ''' <summary>
        ''' A change of the balance for the <see cref="LongTermAsset.AccountValueDecrease">AccountValueDecrease</see> per unit made by the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDUNITASSET)> _
        Public ReadOnly Property OperationValueDecreaseAccountValueChangePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationValueDecreaseAccountValueChangePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' A change of the balance for the <see cref="LongTermAsset.AccountValueIncrease">AccountValueIncrease</see> made by the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property OperationValueIncreaseAccountValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationValueIncreaseAccountValueChange)
            End Get
        End Property

        ''' <summary>
        ''' A change of the balance for the <see cref="LongTermAsset.AccountValueIncrease">AccountValueIncrease</see> per unit made by the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDUNITASSET)> _
        Public ReadOnly Property OperationValueIncreaseAccountValueChangePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationValueIncreaseAccountValueChangePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' A change of the balance for the <see cref="LongTermAsset.AccountRevaluedPortionAmmortization">AccountRevaluedPortionAmmortization</see> made by the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property OperationValueIncreaseAmmortizationAccountValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationValueIncreaseAmmortizationAccountValueChange)
            End Get
        End Property

        ''' <summary>
        ''' A change of the balance for the <see cref="LongTermAsset.AccountRevaluedPortionAmmortization">AccountRevaluedPortionAmmortization</see> per unit made by the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDUNITASSET)> _
        Public ReadOnly Property OperationValueIncreaseAmmortizationAccountValueChangePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationValueIncreaseAmmortizationAccountValueChangePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' A change of the total value of the long term asset made by the operation.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property OperationValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationValueChange)
            End Get
        End Property

        ''' <summary>
        ''' A change of the unit value of the long term asset made by the operation.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDUNITASSET)> _
        Public ReadOnly Property OperationValueChangePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OperationValueChangePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' A change of the amount of the long term asset made by the operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property OperationAmmountChange() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationAmmountChange
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountAcquisition">AccountAcquisition</see> after the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property AfterOperationAcquisitionAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationAcquisitionAccountValue)
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountAcquisition">AccountAcquisition</see> per unit after the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDUNITASSET)> _
        Public ReadOnly Property AfterOperationAcquisitionAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationAcquisitionAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountAccumulatedAmortization">AccountAccumulatedAmortization</see> after the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property AfterOperationAmortizationAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationAmortizationAccountValue)
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountAccumulatedAmortization">AccountAccumulatedAmortization</see> per unit after the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDUNITASSET)> _
        Public ReadOnly Property AfterOperationAmortizationAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationAmortizationAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountValueDecrease">AccountValueDecrease</see> after the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property AfterOperationValueDecreaseAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationValueDecreaseAccountValue)
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountValueDecrease">AccountValueDecrease</see> per unit after the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDUNITASSET)> _
        Public ReadOnly Property AfterOperationValueDecreaseAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationValueDecreaseAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountValueIncrease">AccountValueIncrease</see> after the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property AfterOperationValueIncreaseAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationValueIncreaseAccountValue)
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountValueIncrease">AccountValueIncrease</see> per unit after the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDUNITASSET)> _
        Public ReadOnly Property AfterOperationValueIncreaseAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationValueIncreaseAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountRevaluedPortionAmmortization">AccountRevaluedPortionAmmortization</see> after the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property AfterOperationValueIncreaseAmmortizationAccountValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationValueIncreaseAmmortizationAccountValue)
            End Get
        End Property

        ''' <summary>
        ''' A balance for the <see cref="LongTermAsset.AccountRevaluedPortionAmmortization">AccountRevaluedPortionAmmortization</see> per unit after the operation.
        ''' </summary>
        ''' <remarks>A positive number represents debit balance, a negative number represents credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDUNITASSET)> _
        Public ReadOnly Property AfterOperationValueIncreaseAmmortizationAccountValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationValueIncreaseAmmortizationAccountValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' A total value of the long term asset after the operation.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property AfterOperationValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationValue)
            End Get
        End Property

        ''' <summary>
        ''' A unit value of the long term asset after the operation.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDUNITASSET)> _
        Public ReadOnly Property AfterOperationValuePerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AfterOperationValuePerUnit, ROUNDUNITASSET)
            End Get
        End Property

        ''' <summary>
        ''' An amount of the long term asset after the operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AfterOperationAmmount() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AfterOperationAmmount
            End Get
        End Property

        ''' <summary>
        ''' Gets a new amortization period for the asset set by the long term asset operation.
        ''' </summary>
        ''' <remarks>Only relevant when the <see cref="OperationType">OperationType</see>
        ''' is set to <see cref="LtaOperationType.AmortizationPeriod">LtaOperationType.AmortizationPeriod</see>.
        ''' Value is stored in the database field turtas_op.NewAmortizationPeriod.</remarks>
        Public ReadOnly Property NewAmortizationPeriod() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NewAmortizationPeriod
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return _Date.ToShortDateString & " \ " & _OperationType & _
                GetLimitedLengthString(_Content, 100)
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function GetLongTermAssetOperationInfo(ByVal dr As DataRow, _
            ByRef nBeforeOperationAcquisitionAccountValue As Double, _
            ByRef nBeforeOperationAcquisitionAccountValuePerUnit As Double, _
            ByRef nBeforeOperationAmortizationAccountValue As Double, _
            ByRef nBeforeOperationAmortizationAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValueDecreaseAccountValue As Double, _
            ByRef nBeforeOperationValueDecreaseAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValueIncreaseAccountValue As Double, _
            ByRef nBeforeOperationValueIncreaseAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValueIncreaseAmmortizationAccountValue As Double, _
            ByRef nBeforeOperationValueIncreaseAmmortizationAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValue As Double, _
            ByRef nBeforeOperationValuePerUnit As Double, _
            ByRef nBeforeOperationAmmount As Integer) As LongTermAssetOperationInfo

            Return New LongTermAssetOperationInfo(dr, nBeforeOperationAcquisitionAccountValue, _
                nBeforeOperationAcquisitionAccountValuePerUnit, _
                nBeforeOperationAmortizationAccountValue, _
                nBeforeOperationAmortizationAccountValuePerUnit, _
                nBeforeOperationValueDecreaseAccountValue, _
                nBeforeOperationValueDecreaseAccountValuePerUnit, _
                nBeforeOperationValueIncreaseAccountValue, _
                nBeforeOperationValueIncreaseAccountValuePerUnit, _
                nBeforeOperationValueIncreaseAmmortizationAccountValue, _
                nBeforeOperationValueIncreaseAmmortizationAccountValuePerUnit, _
                nBeforeOperationValue, nBeforeOperationValuePerUnit, nBeforeOperationAmmount)

        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal dr As DataRow, _
            ByRef nBeforeOperationAcquisitionAccountValue As Double, _
            ByRef nBeforeOperationAcquisitionAccountValuePerUnit As Double, _
            ByRef nBeforeOperationAmortizationAccountValue As Double, _
            ByRef nBeforeOperationAmortizationAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValueDecreaseAccountValue As Double, _
            ByRef nBeforeOperationValueDecreaseAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValueIncreaseAccountValue As Double, _
            ByRef nBeforeOperationValueIncreaseAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValueIncreaseAmmortizationAccountValue As Double, _
            ByRef nBeforeOperationValueIncreaseAmmortizationAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValue As Double, _
            ByRef nBeforeOperationValuePerUnit As Double, _
            ByRef nBeforeOperationAmmount As Integer)

            Fetch(dr, nBeforeOperationAcquisitionAccountValue, _
                nBeforeOperationAcquisitionAccountValuePerUnit, _
                nBeforeOperationAmortizationAccountValue, _
                nBeforeOperationAmortizationAccountValuePerUnit, _
                nBeforeOperationValueDecreaseAccountValue, _
                nBeforeOperationValueDecreaseAccountValuePerUnit, _
                nBeforeOperationValueIncreaseAccountValue, _
                nBeforeOperationValueIncreaseAccountValuePerUnit, _
                nBeforeOperationValueIncreaseAmmortizationAccountValue, _
                nBeforeOperationValueIncreaseAmmortizationAccountValuePerUnit, _
                nBeforeOperationValue, nBeforeOperationValuePerUnit, nBeforeOperationAmmount)

        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow, _
            ByRef nBeforeOperationAcquisitionAccountValue As Double, _
            ByRef nBeforeOperationAcquisitionAccountValuePerUnit As Double, _
            ByRef nBeforeOperationAmortizationAccountValue As Double, _
            ByRef nBeforeOperationAmortizationAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValueDecreaseAccountValue As Double, _
            ByRef nBeforeOperationValueDecreaseAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValueIncreaseAccountValue As Double, _
            ByRef nBeforeOperationValueIncreaseAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValueIncreaseAmmortizationAccountValue As Double, _
            ByRef nBeforeOperationValueIncreaseAmmortizationAccountValuePerUnit As Double, _
            ByRef nBeforeOperationValue As Double, _
            ByRef nBeforeOperationValuePerUnit As Double, _
            ByRef nBeforeOperationAmmount As Integer)

            _BeforeOperationAcquisitionAccountValue = _
                CRound(nBeforeOperationAcquisitionAccountValue)
            _BeforeOperationAcquisitionAccountValuePerUnit = _
                CRound(nBeforeOperationAcquisitionAccountValuePerUnit, ROUNDUNITASSET)
            _BeforeOperationAmortizationAccountValue = _
                CRound(nBeforeOperationAmortizationAccountValue)
            _BeforeOperationAmortizationAccountValuePerUnit = _
                CRound(nBeforeOperationAmortizationAccountValuePerUnit, ROUNDUNITASSET)
            _BeforeOperationValueDecreaseAccountValue = _
                CRound(nBeforeOperationValueDecreaseAccountValue)
            _BeforeOperationValueDecreaseAccountValuePerUnit = _
                CRound(nBeforeOperationValueDecreaseAccountValuePerUnit, ROUNDUNITASSET)
            _BeforeOperationValueIncreaseAccountValue = _
                CRound(nBeforeOperationValueIncreaseAccountValue)
            _BeforeOperationValueIncreaseAccountValuePerUnit = _
                CRound(nBeforeOperationValueIncreaseAccountValuePerUnit, ROUNDUNITASSET)
            _BeforeOperationValueIncreaseAmmortizationAccountValue = _
                CRound(nBeforeOperationValueIncreaseAmmortizationAccountValue)
            _BeforeOperationValueIncreaseAmmortizationAccountValuePerUnit = _
                CRound(nBeforeOperationValueIncreaseAmmortizationAccountValuePerUnit, ROUNDUNITASSET)
            _BeforeOperationValue = CRound(nBeforeOperationValue)
            _BeforeOperationValuePerUnit = CRound(nBeforeOperationValuePerUnit, ROUNDUNITASSET)
            _BeforeOperationAmmount = nBeforeOperationAmmount

            _ID = CIntSafe(dr.Item(0), 0)
            _Type = Utilities.ConvertDatabaseCharID(Of LtaOperationType) _
                (CStrSafe(dr.Item(1)))
            _OperationType = Utilities.ConvertLocalizedName(_Type)
            If _Type = LtaOperationType.AccountChange _
                AndAlso Not String.IsNullOrEmpty(CStrSafe(dr.Item(2)).Trim) Then
                _AccountType = Utilities.ConvertDatabaseCharID(Of LtaAccountChangeType) _
                    (CStrSafe(dr.Item(2)))
                _AccountChangeType = Utilities.ConvertLocalizedName(_AccountType)
            Else
                _AccountChangeType = ""
            End If
            _Date = CDateSafe(dr.Item(3), Today)
            If CIntSafe(dr.Item(4), 0) > 0 Then
                _AttachedJournalEntryID = CIntSafe(dr.Item(4), 0)
                _AttachedJournalEntry = String.Format(My.Resources.ActiveReports_LongTermAssetOperationInfo_JournalEntryDescription, _
                    _Date.ToString("yyyy-MM-dd"), CStrSafe(dr.Item(5)), GetLimitedLengthString(CStrSafe(dr.Item(6)), 100))
            Else
                _AttachedJournalEntryID = -1
                _AttachedJournalEntry = My.Resources.Assets_LongTermAsset_AcquisitionJournalEntryDocContentNull
            End If
            _ComplexActID = CIntSafe(dr.Item(8), 0)
            _IsComplexAct = (_ComplexActID > 0)
            _Content = CStrSafe(dr.Item(9)).Trim
            _CorrespondingAccount = CIntSafe(dr.Item(10), 0)
            _DocumentNumber = CStrSafe(dr.Item(11))
            _OperationValueChangePerUnit = CDblSafe(dr.Item(12), ROUNDUNITASSET, 0)
            _OperationAmmountChange = CIntSafe(dr.Item(13), 0)
            _OperationValueChange = CDblSafe(dr.Item(14), 2, 0)
            _NewAmortizationPeriod = CIntSafe(dr.Item(15), 0)
            _OperationAcquisitionAccountValueChange = CDblSafe(dr.Item(19), 2, 0)
            _OperationAcquisitionAccountValueChangePerUnit = CDblSafe(dr.Item(20), ROUNDUNITASSET, 0)
            _OperationAmortizationAccountValueChange = CDblSafe(dr.Item(21), 2, 0)
            _OperationAmortizationAccountValueChangePerUnit = CDblSafe(dr.Item(22), ROUNDUNITASSET, 0)
            _OperationValueDecreaseAccountValueChange = CDblSafe(dr.Item(23), 2, 0)
            _OperationValueDecreaseAccountValueChangePerUnit = CDblSafe(dr.Item(24), ROUNDUNITASSET, 0)
            _OperationValueIncreaseAccountValueChange = CDblSafe(dr.Item(25), 2, 0)
            _OperationValueIncreaseAccountValueChangePerUnit = CDblSafe(dr.Item(26), ROUNDUNITASSET, 0)
            _OperationValueIncreaseAmmortizationAccountValueChange = CDblSafe(dr.Item(27), 2, 0)
            _OperationValueIncreaseAmmortizationAccountValueChangePerUnit = CDblSafe(dr.Item(28), ROUNDUNITASSET, 0)

            _AfterOperationAcquisitionAccountValue = _
                CRound(nBeforeOperationAcquisitionAccountValue _
                + _OperationAcquisitionAccountValueChange)
            _AfterOperationAcquisitionAccountValuePerUnit = _
                CRound(nBeforeOperationAcquisitionAccountValuePerUnit _
                + _OperationAcquisitionAccountValueChangePerUnit, ROUNDUNITASSET)
            _AfterOperationAmortizationAccountValue = _
                CRound(nBeforeOperationAmortizationAccountValue _
                + _OperationAmortizationAccountValueChange)
            _AfterOperationAmortizationAccountValuePerUnit = _
                CRound(nBeforeOperationAmortizationAccountValuePerUnit _
                + _OperationAmortizationAccountValueChangePerUnit, ROUNDUNITASSET)
            _AfterOperationValueDecreaseAccountValue = _
                CRound(nBeforeOperationValueDecreaseAccountValue _
                + _OperationValueDecreaseAccountValueChange)
            _AfterOperationValueDecreaseAccountValuePerUnit = _
                CRound(nBeforeOperationValueDecreaseAccountValuePerUnit _
                + _OperationValueDecreaseAccountValueChangePerUnit, ROUNDUNITASSET)
            _AfterOperationValueIncreaseAccountValue = _
                CRound(nBeforeOperationValueIncreaseAccountValue _
                + _OperationValueIncreaseAccountValueChange)
            _AfterOperationValueIncreaseAccountValuePerUnit = _
                CRound(nBeforeOperationValueIncreaseAccountValuePerUnit _
                + _OperationValueIncreaseAccountValueChangePerUnit, ROUNDUNITASSET)
            _AfterOperationValueIncreaseAmmortizationAccountValue = _
                CRound(nBeforeOperationValueIncreaseAmmortizationAccountValue _
                + _OperationValueIncreaseAmmortizationAccountValueChange)
            _AfterOperationValueIncreaseAmmortizationAccountValuePerUnit = _
                CRound(nBeforeOperationValueIncreaseAmmortizationAccountValuePerUnit _
                + _OperationValueIncreaseAmmortizationAccountValueChangePerUnit, ROUNDUNITASSET)
            _AfterOperationValue = CRound(nBeforeOperationValue + _OperationValueChange)
            _AfterOperationValuePerUnit = CRound(nBeforeOperationValuePerUnit + _
                _OperationValueChangePerUnit, ROUNDUNITASSET)
            _AfterOperationAmmount = nBeforeOperationAmmount - OperationAmmountChange

            ' values "before" is to be updated to values "after" (making use of ByRef)
            nBeforeOperationAcquisitionAccountValue = _
                CRound(_AfterOperationAcquisitionAccountValue)
            nBeforeOperationAcquisitionAccountValuePerUnit = _
                CRound(_AfterOperationAcquisitionAccountValuePerUnit, ROUNDUNITASSET)
            nBeforeOperationAmortizationAccountValue = _
                CRound(_AfterOperationAmortizationAccountValue)
            nBeforeOperationAmortizationAccountValuePerUnit = _
                CRound(_AfterOperationAmortizationAccountValuePerUnit, ROUNDUNITASSET)
            nBeforeOperationValueDecreaseAccountValue = _
                CRound(_AfterOperationValueDecreaseAccountValue)
            nBeforeOperationValueDecreaseAccountValuePerUnit = _
                CRound(_AfterOperationValueDecreaseAccountValuePerUnit, ROUNDUNITASSET)
            nBeforeOperationValueIncreaseAccountValue = _
                CRound(_AfterOperationValueIncreaseAccountValue)
            nBeforeOperationValueIncreaseAccountValuePerUnit = _
                CRound(_AfterOperationValueIncreaseAccountValuePerUnit, ROUNDUNITASSET)
            nBeforeOperationValueIncreaseAmmortizationAccountValue = _
                CRound(_AfterOperationValueIncreaseAmmortizationAccountValue)
            nBeforeOperationValueIncreaseAmmortizationAccountValuePerUnit = _
                CRound(_AfterOperationValueIncreaseAmmortizationAccountValuePerUnit, ROUNDUNITASSET)
            nBeforeOperationValue = CRound(_AfterOperationValue)
            nBeforeOperationValuePerUnit = CRound(_AfterOperationValuePerUnit, ROUNDUNITASSET)
            nBeforeOperationAmmount = _AfterOperationAmmount

        End Sub

#End Region

    End Class

End Namespace
