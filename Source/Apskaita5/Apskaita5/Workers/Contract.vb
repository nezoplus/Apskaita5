﻿Imports ApskaitaObjects.Attributes

Namespace Workers

    ''' <summary>
    ''' Represents a labour contract.
    ''' </summary>
    ''' <remarks>Values are stored in in the database table darbuotojai_d as a collection of status items
    ''' with the same serial, number and date. The collection should contain status row of type
    ''' <see cref="WorkerStatusType.Employed">WorkerStatusType.Employed</see> as otherwise the collection 
    ''' represents a <see cref="ContractUpdate">ContractUpdate</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class Contract
        Inherits BusinessBase(Of Contract)
        Implements IIsDirtyEnough, IValidationMessageProvider

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _ChronologicValidator As ContractChronologicValidator
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private _ExtraPayID As Integer = 0
        Private _TerminationID As Integer = 0
        Private _AnnualHolidayID As Integer = 0
        Private _HolidayCorrectionID As Integer = 0
        Private _NpdID As Integer = 0
        Private _PnpdID As Integer = 0
        Private _WageID As Integer = 0
        Private _WorkLoadID As Integer = 0
        Private _PositionID As Integer = 0

        Private _PersonID As Integer = 0
        Private _PersonName As String = ""
        Private _PersonCode As String = ""
        Private _PersonSodraCode As String = ""
        Private _PersonAddress As String = ""

        Private _Date As Date = Today
        Private _Serial As String = ""
        Private _Number As Integer = 0
        Private _Content As String = ""
        Private _Position As String = ""
        Private _Wage As Double = 0
        Private _WageType As WageType = Workers.WageType.Position
        Private _HumanReadableWageType As String = Utilities.ConvertLocalizedName(Workers.WageType.Position)
        Private _IsTerminated As Boolean = False
        Private _TerminationDate As Date = Today
        Private _ExtraPay As Double = 0
        Private _AnnualHoliday As Integer = 28
        Private _HolidayCorrection As Double = 0
        Private _NPD As Double = 0
        Private _PNPD As Double = 0
        Private _WorkLoad As Double = 1


        ''' <summary>
        ''' Gets an ID of the contract that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.ID
        ''' for status row of type <see cref="WorkerStatusType.Employed">WorkerStatusType.Employed</see>.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="IChronologicValidator">IChronologicValidator</see> object that contains business restraints on updating the contract.
        ''' </summary>
        ''' <remarks>Underlying type is <see cref="ContractChronologicValidator">ContractChronologicValidator</see>.</remarks>
        Public ReadOnly Property ChronologicValidator() As IChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ChronologicValidator
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the contract was inserted into the database.
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.InsertDate
        ''' (for each status row).</remarks>
        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the contract was last updated.
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.UpdateDate
        ''' (for each status row).</remarks>
        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID for the status row of type <see cref="WorkerStatusType.ExtraPay">WorkerStatusType.ExtraPay</see>
        ''' that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.ID.</remarks>
        Public ReadOnly Property ExtraPayID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ExtraPayID
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID for the status row of type <see cref="WorkerStatusType.Fired">WorkerStatusType.Fired</see>
        ''' that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.ID.</remarks>
        Public ReadOnly Property TerminationID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TerminationID
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID for the status row of type <see cref="WorkerStatusType.Holiday">WorkerStatusType.Holiday</see>
        ''' that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.ID.</remarks>
        Public ReadOnly Property AnnualHolidayID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AnnualHolidayID
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID for the status row of type <see cref="WorkerStatusType.HolidayCorrection">WorkerStatusType.HolidayCorrection</see>
        ''' that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.ID.</remarks>
        Public ReadOnly Property HolidayCorrectionID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _HolidayCorrectionID
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID for the status row of type <see cref="WorkerStatusType.NPD">WorkerStatusType.NPD</see>
        ''' that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.ID.</remarks>
        Public ReadOnly Property NpdID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NpdID
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID for the status row of type <see cref="WorkerStatusType.PNPD">WorkerStatusType.PNPD</see>
        ''' that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.ID.</remarks>
        Public ReadOnly Property PnpdID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PnpdID
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID for the status row of type <see cref="WorkerStatusType.Wage">WorkerStatusType.Wage</see>
        ''' that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.ID.</remarks>
        Public ReadOnly Property WageID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WageID
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID for the status row of type <see cref="WorkerStatusType.WorkLoad">WorkerStatusType.WorkLoad</see>
        ''' that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.ID.</remarks>
        Public ReadOnly Property WorkLoadID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WorkLoadID
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID for the status row of type <see cref="WorkerStatusType.Position">WorkerStatusType.Position</see>
        ''' that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.ID.</remarks>
        Public ReadOnly Property PositionID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PositionID
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="General.Person.ID">ID of the person</see> (worker) that is assigned to the current labour contract.
        ''' </summary>
        ''' <remarks>Value is stored in the database table darbuotojai_d.AK. (for each status row)</remarks>
        Public ReadOnly Property PersonID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonID
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.Person.Name">name of the person</see> (worker) that is assigned to the current labour contract.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.Person.Name">General.Person.Name</see>.</remarks>
        Public ReadOnly Property PersonName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonName.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.Person.Code">personal code of the person</see> (worker) that is assigned to the current labour contract.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.Person.Code">General.Person.Code</see>.</remarks>
        Public ReadOnly Property PersonCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonCode.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.Person.CodeSODRA">social security code of the person</see> (worker) that is assigned to the current labour contract.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.Person.CodeSODRA">General.Person.CodeSODRA</see>.</remarks>
        Public ReadOnly Property PersonSodraCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonSodraCode.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.Person.Address">address of the person</see> (worker) that is assigned to the current labour contract.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.Person.Address">General.Person.Address</see>.</remarks>
        Public ReadOnly Property PersonAddress() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonAddress.Trim
            End Get
        End Property


        ''' <summary>
        ''' Gets or sets the date of the contract.
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.Nuo
        ''' (for each status row).</remarks>
        Public Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                CanWriteProperty(True)
                If _Date.Date <> value.Date Then
                    _Date = value.Date
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the serial of the contract.
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.DS_Serija
        ''' (for each status row).</remarks>
        <DocumentSerialField(ValueRequiredLevel.Optional, ApskaitaObjects.Settings.DocumentSerialType.LabourContract)> _
        Public Property Serial() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Serial.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If Not IsNew Then
                    PropertyHasChanged()
                Else
                    CanWriteProperty(True)
                    If value Is Nothing Then value = ""
                    If _Serial.Trim <> value.Trim Then
                        _Serial = value.Trim
                        PropertyHasChanged()
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the number of the contract.
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.DS_NR
        ''' (for each status row).</remarks>
        <IntegerField(ValueRequiredLevel.Mandatory, False)> _
        Public Property Number() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Number
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                If Not IsNew Then
                    PropertyHasChanged()
                Else
                    CanWriteProperty(True)
                    If _Number <> value Then
                        _Number = value
                        PropertyHasChanged()
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the description of the contract.
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.Pagrindas
        ''' for the status row of type <see cref="WorkerStatusType.Employed">WorkerStatusType.Employed</see>.</remarks>
        <StringField(ValueRequiredLevel.Recommended, 255, False)> _
        Public Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Content.Trim <> value.Trim Then
                    _Content = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the position of the worker.
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.DU_tipas
        ''' for the status row of type <see cref="WorkerStatusType.Position">WorkerStatusType.Position</see>.</remarks>
        <StringField(ValueRequiredLevel.Recommended, 100, False)> _
        Public Property Position() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Position.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Position.Trim <> value.Trim Then
                    _Position = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the wage.
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.Dydis
        ''' for the status row of type <see cref="WorkerStatusType.Wage">WorkerStatusType.Wage</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public Property Wage() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Wage)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If Not _ChronologicValidator.FinancialDataCanChange Then
                    PropertyHasChanged()
                Else
                    CanWriteProperty(True)
                    If CRound(_Wage) <> CRound(value) Then
                        _Wage = CRound(value)
                        PropertyHasChanged()
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the <see cref="Workers.WageType">wage type</see>.
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.DU_tipas
        ''' for the status row of type <see cref="WorkerStatusType.Wage">WorkerStatusType.Wage</see>.</remarks>
        Public Property WageType() As WageType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WageType
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As WageType)
                If Not _ChronologicValidator.FinancialDataCanChange Then
                    PropertyHasChanged()
                Else
                    CanWriteProperty(True)
                    If _WageType <> value Then
                        _WageType = value
                        _HumanReadableWageType = Utilities.ConvertLocalizedName(_WageType)
                        PropertyHasChanged()
                        PropertyHasChanged("HumanReadableWageType")
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the <see cref="Workers.WageType">wage type</see> as a human readable string.
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.DU_tipas
        ''' for the status row of type <see cref="WorkerStatusType.Wage">WorkerStatusType.Wage</see>.</remarks>
        <LocalizedEnumField(GetType(WageType), False, "")> _
        Public Property HumanReadableWageType() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _HumanReadableWageType.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If Not _ChronologicValidator.FinancialDataCanChange Then
                    PropertyHasChanged()
                Else
                    CanWriteProperty(True)
                    If value Is Nothing Then value = ""
                    Dim enumValue As WageType = Utilities.ConvertLocalizedName(Of WageType)(value)
                    If enumValue <> _WageType Then
                        _WageType = enumValue
                        _HumanReadableWageType = Utilities.ConvertLocalizedName(_WageType)
                        PropertyHasChanged()
                        PropertyHasChanged("WageType")
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets of sets whether the contract is terminated.
        ''' </summary>
        ''' <remarks>Whether a status row of type <see cref="WorkerStatusType.Fired">WorkerStatusType.Fired</see> exists.</remarks>
        Public Property IsTerminated() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsTerminated
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _IsTerminated <> value Then
                    _IsTerminated = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets of sets the contract termination date.
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.Nuo
        ''' for the status row of type <see cref="WorkerStatusType.Fired">WorkerStatusType.Fired</see>.</remarks>
        Public Property TerminationDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TerminationDate
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                If Not _IsTerminated OrElse Not _ChronologicValidator.TerminationCanBeCanceled Then
                    PropertyHasChanged()
                Else
                    CanWriteProperty(True)
                    If _TerminationDate.Date <> value.Date Then
                        _TerminationDate = value.Date
                        PropertyHasChanged()
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the extra pay.
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.Dydis
        ''' for the status row of type <see cref="WorkerStatusType.ExtraPay">WorkerStatusType.ExtraPay</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property ExtraPay() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ExtraPay)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If Not _ChronologicValidator.FinancialDataCanChange Then
                    PropertyHasChanged()
                Else
                    CanWriteProperty(True)
                    If CRound(_ExtraPay) <> CRound(value) Then
                        _ExtraPay = CRound(value)
                        PropertyHasChanged()
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the annual holiday rate (holiday days per work year).
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.Dydis
        ''' for the status row of type <see cref="WorkerStatusType.Holiday">WorkerStatusType.Holiday</see>.</remarks>
        <IntegerField(ValueRequiredLevel.Mandatory, False)> _
        Public Property AnnualHoliday() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AnnualHoliday
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If _AnnualHoliday <> value Then
                    _AnnualHoliday = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the annual holiday technical correction, 
        ''' e.g. when transfering the data for an old labour contract.
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.Dydis
        ''' for the status row of type <see cref="WorkerStatusType.HolidayCorrection">WorkerStatusType.HolidayCorrection</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDACCUMULATEDHOLIDAY)> _
        Public Property HolidayCorrection() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_HolidayCorrection, ROUNDACCUMULATEDHOLIDAY)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_HolidayCorrection, ROUNDACCUMULATEDHOLIDAY) <> CRound(value, ROUNDACCUMULATEDHOLIDAY) Then
                    _HolidayCorrection = CRound(value, ROUNDACCUMULATEDHOLIDAY)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the applicable NPD (non-taxable personal income size).
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.Dydis
        ''' for the status row of type <see cref="WorkerStatusType.NPD">WorkerStatusType.NPD</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property NPD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_NPD)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If Not _ChronologicValidator.FinancialDataCanChange Then
                    PropertyHasChanged()
                Else
                    CanWriteProperty(True)
                    If CRound(_NPD) <> CRound(value) Then
                        _NPD = CRound(value)
                        PropertyHasChanged()
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the applicable PNPD (supplementary non-taxable personal income size).
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.Dydis
        ''' for the status row of type <see cref="WorkerStatusType.PNPD">WorkerStatusType.PNPD</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property PNPD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PNPD)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If Not _ChronologicValidator.FinancialDataCanChange Then
                    PropertyHasChanged()
                Else
                    CanWriteProperty(True)
                    If CRound(_PNPD) <> CRound(value) Then
                        _PNPD = CRound(value)
                        PropertyHasChanged()
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the work load (ratio between contractual work hours and gauge work hours (40H/Week)).
        ''' </summary>
        ''' <remarks>Value is stored in in the database field darbuotojai_d.Dydis
        ''' for the status row of type <see cref="WorkerStatusType.WorkLoad">WorkerStatusType.WorkLoad</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDWORKLOAD, True, 0.025, 1.0, False)> _
        Public Property WorkLoad() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_WorkLoad, ROUNDWORKLOAD)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_WorkLoad, ROUNDWORKLOAD) <> CRound(value, ROUNDWORKLOAD) Then
                    _WorkLoad = CRound(value, ROUNDWORKLOAD)
                    PropertyHasChanged()
                End If
            End Set
        End Property


        ''' <summary>
        ''' Returnes TRUE if the object is new and contains some user provided data 
        ''' OR
        ''' object is not new and was changed by the user.
        ''' </summary>
        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_Serial.Trim) _
                    OrElse Not String.IsNullOrEmpty(_Content.Trim) _
                    OrElse Not String.IsNullOrEmpty(_Position.Trim))
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid
            End Get
        End Property



        Public Overrides Function Save() As Contract

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Dim result As Contract = MyBase.Save
            HelperLists.ShortLabourContractList.InvalidateCache()
            Return result

        End Function


        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = ""
            If Not MyBase.IsValid Then result = AddWithNewLine(result, _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error), False)
            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = ""
            If Not MyBase.BrokenRulesCollection.WarningCount > 0 Then result = AddWithNewLine(result, _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning), False)
            Return result
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            Return Me.BrokenRulesCollection.WarningCount > 0
        End Function



        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Workers_Contract_ToString, _
                _Date.ToString("yyyy-MM-dd"), _Serial, _Number.ToString)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.IntegerFieldValidation, _
                New Csla.Validation.RuleArgs("Number"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.IntegerFieldValidation, _
                New Csla.Validation.RuleArgs("AnnualHoliday"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Serial"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Content"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Position"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Wage"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("ExtraPay"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("HolidayCorrection"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("NPD"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("PNPD"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("WorkLoad"))

            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.ChronologyValidation, _
                New CommonValidation.CommonValidation.ChronologyRuleArgs("Date", "ChronologicValidator"))

            ValidationRules.AddRule(AddressOf TerminationDateValidation, _
                New Validation.RuleArgs("TerminationDate"))

            ValidationRules.AddDependantProperty("IsTerminated", "TerminationDate", False)
            ValidationRules.AddDependantProperty("Date", "TerminationDate", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property TerminationDate is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function TerminationDateValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As Contract = DirectCast(target, Contract)

            If Not valObj.IsNew AndAlso Not valObj._IsTerminated AndAlso _
                Not valObj._ChronologicValidator.TerminationCanBeCanceled Then
                e.Description = valObj._ChronologicValidator.TerminationCanBeCanceledExplanation
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf valObj._IsTerminated AndAlso valObj._Date.Date > valObj._TerminationDate.Date Then
                e.Description = My.Resources.Workers_Contract_TerminationDateInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Workers.Contract2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.Contract1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.Contract2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.Contract3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.Contract3")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Get a new contract instance.
        ''' </summary>
        ''' <param name="PersonID">An <see cref="General.Person.ID">ID of the person</see> 
        ''' (worker) that is assigned to the new contract.</param>
        ''' <remarks></remarks>
        Public Shared Function NewContract(ByVal PersonID As Integer) As Contract
            Dim result As Contract = DataPortal.Create(Of Contract)(New Criteria(PersonID))
            result.MarkNew()
            Return result
        End Function

        ''' <summary>
        ''' Get an existing contract from a database.
        ''' </summary>
        ''' <param name="nID">An ID of the contract to get.</param>
        ''' <remarks></remarks>
        Public Shared Function GetContract(ByVal nID As Integer) As Contract
            Return DataPortal.Fetch(Of Contract)(New Criteria(nID))
        End Function

        ''' <summary>
        ''' Get an existing contract from a database.
        ''' </summary>
        ''' <param name="contractSerial">A serial of the contract to get.</param>
        ''' <param name="contractNumber">A number of the contract to get.</param>
        ''' <remarks></remarks>
        Public Shared Function GetContract(ByVal contractSerial As String, _
            ByVal contractNumber As Integer) As Contract
            Return DataPortal.Fetch(Of Contract)(New Criteria(contractSerial, contractNumber))
        End Function

        ''' <summary>
        ''' Delete an existing contract from a database.
        ''' </summary>
        ''' <param name="id">An ID of the contract to delete.</param>
        ''' <remarks></remarks>
        Public Shared Sub DeleteContract(ByVal id As Integer)
            DataPortal.Delete(New Criteria(id))
            HelperLists.ShortLabourContractList.InvalidateCache()
        End Sub

        ''' <summary>
        ''' Delete an existing contract from a database.
        ''' </summary>
        ''' <param name="contractSerial">A serial of the contract to delete.</param>
        ''' <param name="contractNumber">A number of the contract to delete.</param>
        ''' <remarks></remarks>
        Public Shared Sub DeleteContract(ByVal contractSerial As String, ByVal contractNumber As Integer)
            DataPortal.Delete(New Criteria(contractSerial, contractNumber))
            HelperLists.ShortLabourContractList.InvalidateCache()
        End Sub


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private ReadOnly _ID As Integer = 0
            Private ReadOnly _ContractSerial As String = ""
            Private ReadOnly _ContractNumber As Integer = 0
            Public ReadOnly Property ID() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public ReadOnly Property ContractSerial() As String
                Get
                    If _ContractSerial Is Nothing Then Return ""
                    Return _ContractSerial
                End Get
            End Property
            Public ReadOnly Property ContractNumber() As Integer
                Get
                    Return _ContractNumber
                End Get
            End Property
            Public Sub New(ByVal nID As Integer)
                _ID = nID
            End Sub
            Public Sub New(ByVal nContractSerial As String, ByVal nContractNumber As Integer)
                _ContractSerial = nContractSerial
                _ContractNumber = nContractNumber
            End Sub
        End Class


        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            If Not criteria.ID > 0 Then Throw New Exception(My.Resources.Workers_Contract_PersonNull)

            Dim person As HelperLists.PersonInfo = HelperLists.PersonInfo.GetPersonInfoChild(criteria.ID, True)

            If Not person.IsWorker Then Throw New Exception(String.Format( _
                My.Resources.Workers_Contract_PersonInvalid, person.Name, person.ID.ToString()))

            _PersonID = criteria.ID
            _PersonName = person.Name
            _PersonCode = person.Code
            _PersonAddress = person.Address
            _PersonSodraCode = person.CodeSODRA

            _ChronologicValidator = ContractChronologicValidator.NewContractChronologicValidator()

            ValidationRules.CheckRules()

            MarkNew()

        End Sub


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As SQLCommand
            If criteria.ID > 0 Then
                myComm = New SQLCommand("FetchContract")
                myComm.AddParam("?CD", criteria.ID)
            ElseIf criteria.ContractNumber > 0 Then
                myComm = New SQLCommand("FetchContractBySerialNumber")
                myComm.AddParam("?DS", criteria.ContractSerial.Trim)
                myComm.AddParam("?DN", criteria.ContractNumber)
            Else
                Throw New Exception(My.Resources.Workers_Contract_IDNull)
            End If

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then
                    If criteria.ID > 0 Then
                        Throw New Exception(String.Format(My.Resources.Common_ObjectNotFound, _
                            My.Resources.Workers_Contract_TypeName, criteria.ID.ToString()))
                    Else
                        Throw New Exception(String.Format(My.Resources.Common_ObjectNotFound, _
                            My.Resources.Workers_Contract_TypeName, criteria.ContractSerial _
                            & criteria.ContractNumber.ToString()))
                    End If
                End If

                For Each dr As DataRow In myData.Rows

                    Select Case Utilities.ConvertDatabaseCharID(Of WorkerStatusType)(CStrSafe(dr.Item(1)))

                        Case WorkerStatusType.Employed

                            _ID = CIntSafe(dr.Item(0), 0)
                            _Date = CDateSafe(dr.Item(2), Date.MinValue)
                            _Content = CStrSafe(dr.Item(5)).Trim
                            _InsertDate = CTimeStampSafe(dr.Item(6))
                            _UpdateDate = CTimeStampSafe(dr.Item(7))
                            _Serial = CStrSafe(dr.Item(8)).Trim
                            _Number = CIntSafe(dr.Item(9), 0)
                            _PersonID = CIntSafe(dr.Item(10), 0)
                            _PersonName = CStrSafe(dr.Item(11)).Trim
                            _PersonCode = CStrSafe(dr.Item(12)).Trim
                            _PersonAddress = CStrSafe(dr.Item(13)).Trim
                            _PersonSodraCode = CStrSafe(dr.Item(14)).Trim

                        Case WorkerStatusType.ExtraPay

                            _ExtraPayID = CIntSafe(dr.Item(0), 0)
                            _ExtraPay = CDblSafe(dr.Item(3), 0)

                        Case WorkerStatusType.Fired

                            _TerminationID = CIntSafe(dr.Item(0), 0)
                            _IsTerminated = True
                            _TerminationDate = CDateSafe(dr.Item(2), Date.MinValue)

                        Case WorkerStatusType.Holiday

                            _AnnualHolidayID = CIntSafe(dr.Item(0), 0)
                            _AnnualHoliday = CIntSafe(dr.Item(3), 0)

                        Case WorkerStatusType.HolidayCorrection

                            _HolidayCorrectionID = CIntSafe(dr.Item(0), 0)
                            _HolidayCorrection = CDblSafe(dr.Item(3), ROUNDACCUMULATEDHOLIDAY, 0)

                        Case WorkerStatusType.NPD

                            _NpdID = CIntSafe(dr.Item(0), 0)
                            _NPD = CDblSafe(dr.Item(3), 2, 0)

                        Case WorkerStatusType.PNPD

                            _PnpdID = CIntSafe(dr.Item(0), 0)
                            _PNPD = CDblSafe(dr.Item(3), 2, 0)

                        Case WorkerStatusType.Wage

                            _WageID = CIntSafe(dr.Item(0), 0)
                            _Wage = CDblSafe(dr.Item(3), 2, 0)
                            _WageType = Utilities.ConvertDatabaseCharID(Of WageType)(CStrSafe(dr.Item(4)))
                            _HumanReadableWageType = Utilities.ConvertLocalizedName(_WageType)

                        Case WorkerStatusType.WorkLoad

                            _WorkLoadID = CIntSafe(dr.Item(0), 0)
                            _WorkLoad = CDblSafe(dr.Item(3), ROUNDWORKLOAD, 0)

                        Case WorkerStatusType.Position

                            _PositionID = CIntSafe(dr.Item(0), 0)
                            _Position = CStrSafe(dr.Item(4))

                    End Select

                Next

            End Using

            _ChronologicValidator = ContractChronologicValidator.GetContractChronologicValidator(_ID)

            MarkOld()

            ValidationRules.CheckRules()

        End Sub


        Protected Overrides Sub DataPortal_Insert()
            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)
            DoSave()
        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            _ChronologicValidator = ContractChronologicValidator.GetContractChronologicValidator(_ID)

            DoSave()

        End Sub

        Private Sub DoSave()

            CheckIfContractSerialNumberUnique()

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            If Not IsNew Then
                CheckIfUpdateDateChanged()
            End If

            _UpdateDate = GetCurrentTimeStamp()
            If Me.IsNew Then _InsertDate = _UpdateDate

            Using transaction As New SqlTransaction

                Try

                    UpdateParam(WorkerStatusType.Employed)
                    UpdateParam(WorkerStatusType.ExtraPay)
                    UpdateParam(WorkerStatusType.Holiday)
                    UpdateParam(WorkerStatusType.HolidayCorrection)
                    UpdateParam(WorkerStatusType.NPD)
                    UpdateParam(WorkerStatusType.PNPD)
                    UpdateParam(WorkerStatusType.Position)
                    UpdateParam(WorkerStatusType.Wage)
                    UpdateParam(WorkerStatusType.WorkLoad)
                    UpdateParam(WorkerStatusType.Fired)

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            _Serial = DirectCast(criteria, Criteria).ContractSerial
            _Number = DirectCast(criteria, Criteria).ContractNumber

            Dim myComm As SQLCommand

            If DirectCast(criteria, Criteria).ID > 0 Then

                myComm = New SQLCommand("FetchContractSerialNumber")
                myComm.AddParam("?CD", DirectCast(criteria, Criteria).ID)

                Using myData As DataTable = myComm.Fetch

                    If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                        My.Resources.Common_ObjectNotFound, My.Resources.Workers_Contract_TypeName, _
                        DirectCast(criteria, Criteria).ID.ToString()))

                    _Serial = CStrSafe(myData.Rows(0).Item(0))
                    _Number = CIntSafe(myData.Rows(0).Item(1), 0)
                    _ID = DirectCast(criteria, Criteria).ID

                End Using

            Else

                myComm = New SQLCommand("FetchContractBySerialNumber")
                myComm.AddParam("?DN", DirectCast(criteria, Criteria).ContractNumber)
                myComm.AddParam("?DS", DirectCast(criteria, Criteria).ContractSerial)

                Using myData As DataTable = myComm.Fetch

                    If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                        My.Resources.Common_ObjectNotFound, My.Resources.Workers_Contract_TypeName, _
                        DirectCast(criteria, Criteria).ContractSerial _
                        & DirectCast(criteria, Criteria).ContractNumber.ToString()))

                    _Serial = DirectCast(criteria, Criteria).ContractSerial
                    _Number = DirectCast(criteria, Criteria).ContractNumber
                    _ID = 0

                    For Each dr As DataRow In myData.Rows
                        If Utilities.ConvertDatabaseCharID(Of WorkerStatusType)(CStrSafe(dr.Item(1))) _
                            = WorkerStatusType.Employed Then
                            _ID = CIntSafe(dr.Item(0), 0)
                            Exit For
                        End If
                    Next

                    If Not _ID > 0 Then Throw New Exception(String.Format( _
                        My.Resources.Common_ObjectNotFound, My.Resources.Workers_Contract_TypeName, _
                        DirectCast(criteria, Criteria).ContractSerial _
                        & DirectCast(criteria, Criteria).ContractNumber.ToString()))

                End Using

            End If

            myComm = New SQLCommand("CheckIfWorkerStatusCanBeDeleted")
            myComm.AddParam("?CD", _ID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                    My.Resources.Common_ObjectNotFound, My.Resources.Workers_Contract_TypeName, _
                    _ID.ToString()))

                Dim dr As DataRow = myData.Rows(0)

                Dim exceptionString As String = ""

                If CDateSafe(dr.Item(1), Date.MaxValue) <> Date.MaxValue Then _
                    exceptionString = AddWithNewLine(exceptionString, _
                    String.Format(My.Resources.Workers_Contract_LastWageSheet, _
                    CDateSafe(dr.Item(1), Date.MaxValue).ToString("yyyy-MM-dd")), False)
                If CDateSafe(dr.Item(2), Date.MaxValue) <> Date.MaxValue Then _
                    exceptionString = AddWithNewLine(exceptionString, _
                    String.Format(My.Resources.Workers_Contract_LastImprestSheet, _
                    CDateSafe(dr.Item(2), Date.MaxValue).ToString("yyyy-MM-dd")), False)
                If CDateSafe(dr.Item(3), Date.MaxValue) <> Date.MaxValue Then _
                    exceptionString = AddWithNewLine(exceptionString, _
                    String.Format(My.Resources.Workers_Contract_LastWorkTimeSheet, _
                    CDateSafe(dr.Item(3), Date.MaxValue).ToString("yyyy-MM-dd")), False)

                If Not StringIsNullOrEmpty(exceptionString) Then Throw New Exception( _
                    String.Format(My.Resources.Workers_Contract_BlockingSheets, vbCrLf, exceptionString))

            End Using

            myComm = New SQLCommand("DeleteContract")
            myComm.AddParam("?DS", _Serial.Trim)
            myComm.AddParam("?DN", _Number)

            myComm.Execute()

            MarkNew()

        End Sub


        Private Sub UpdateParam(ByVal paramType As WorkerStatusType)

            Dim paramID As Integer = GetParamIDByType(paramType)

            If IsNew OrElse Not paramID > 0 Then

                ' do not insert empty values and fields, that are limited by business logic
                If Not ParamValueHasStatusItem(paramType) OrElse IsParamValueReadonly(paramType) Then Exit Sub

                Dim myComm As New SQLCommand("InsertWorkerStatus")
                AddWithParams(myComm, paramType)
                myComm.AddParam("?PD", _PersonID)
                myComm.AddParam("?NM", _Number)
                myComm.AddParam("?SR", _Serial.Trim)
                myComm.AddParam("?TP", Utilities.ConvertDatabaseCharID(paramType))

                myComm.Execute()

                paramID = Convert.ToInt32(myComm.LastInsertID)
                SetParamIDByType(paramType, paramID)

            Else

                If paramType = WorkerStatusType.Fired AndAlso _
                    Not _ChronologicValidator.TerminationCanBeCanceled Then Exit Sub

                ' remove empty values
                If Not IsParamValueReadonly(paramType) AndAlso Not ParamValueHasStatusItem(paramType) Then

                    Dim myComm As New SQLCommand("DeleteWorkerStatus")
                    myComm.AddParam("?SD", paramID)

                    myComm.Execute()

                    SetParamIDByType(paramType, 0)

                Else

                    If IsParamValueReadonly(paramType) Then

                        Dim myComm As New SQLCommand("UpdateWorkerStatusWithoutValue")
                        AddWithParams(myComm, paramType)
                        myComm.AddParam("?SD", paramID)

                        myComm.Execute()

                    Else

                        Dim myComm As New SQLCommand("UpdateWorkerStatus")
                        AddWithParams(myComm, paramType)
                        myComm.AddParam("?SD", paramID)

                        myComm.Execute()

                    End If

                End If

            End If

        End Sub

        Private Sub AddWithParams(ByRef myComm As SQLCommand, ByVal paramType As WorkerStatusType)

            If paramType = WorkerStatusType.Fired Then
                myComm.AddParam("?DT", _TerminationDate.Date)
            Else
                myComm.AddParam("?DT", _Date.Date)
            End If
            myComm.AddParam("?UD", _UpdateDate.ToUniversalTime)

            Select Case paramType
                Case WorkerStatusType.ExtraPay
                    myComm.AddParam("?VL", CRound(_ExtraPay, 2))
                    myComm.AddParam("?OP", "")
                Case WorkerStatusType.Holiday
                    myComm.AddParam("?VL", CRound(_AnnualHoliday, 2))
                    myComm.AddParam("?OP", "")
                Case WorkerStatusType.HolidayCorrection
                    myComm.AddParam("?VL", CRound(_HolidayCorrection, ROUNDACCUMULATEDHOLIDAY))
                    myComm.AddParam("?OP", "")
                Case WorkerStatusType.NPD
                    myComm.AddParam("?VL", CRound(_NPD, 2))
                    myComm.AddParam("?OP", "")
                Case WorkerStatusType.PNPD
                    myComm.AddParam("?VL", CRound(_PNPD, 2))
                    myComm.AddParam("?OP", "")
                Case WorkerStatusType.Wage
                    myComm.AddParam("?VL", CRound(_Wage, 2))
                    myComm.AddParam("?OP", Utilities.ConvertDatabaseCharID(_WageType))
                Case WorkerStatusType.WorkLoad
                    myComm.AddParam("?VL", CRound(_WorkLoad, ROUNDWORKLOAD))
                    myComm.AddParam("?OP", "")
                Case WorkerStatusType.Position
                    myComm.AddParam("?VL", 0, GetType(Double))
                    myComm.AddParam("?OP", _Position.Trim)
                Case Else
                    myComm.AddParam("?VL", 0, GetType(Double))
                    myComm.AddParam("?OP", "")
            End Select

            If paramType = WorkerStatusType.Employed Then
                myComm.AddParam("?CN", _Content.Trim)
            Else
                myComm.AddParam("?CN", "")
            End If

        End Sub

        Private Function GetParamIDByType(ByVal paramType As WorkerStatusType) As Integer
            Select Case paramType
                Case WorkerStatusType.Employed
                    Return _ID
                Case WorkerStatusType.ExtraPay
                    Return _ExtraPayID
                Case WorkerStatusType.Fired
                    Return _TerminationID
                Case WorkerStatusType.Holiday
                    Return _AnnualHolidayID
                Case WorkerStatusType.HolidayCorrection
                    Return _HolidayCorrectionID
                Case WorkerStatusType.NPD
                    Return _NpdID
                Case WorkerStatusType.PNPD
                    Return _PnpdID
                Case WorkerStatusType.Position
                    Return _PositionID
                Case WorkerStatusType.Wage
                    Return _WageID
                Case WorkerStatusType.WorkLoad
                    Return _WorkLoadID
                Case Else
                    Return 0
            End Select
        End Function

        Private Sub SetParamIDByType(ByVal paramType As WorkerStatusType, ByVal paramID As Integer)
            Select Case paramType
                Case WorkerStatusType.Employed
                    _ID = paramID
                Case WorkerStatusType.ExtraPay
                    _ExtraPayID = paramID
                Case WorkerStatusType.Fired
                    _TerminationID = paramID
                Case WorkerStatusType.Holiday
                    _AnnualHolidayID = paramID
                Case WorkerStatusType.HolidayCorrection
                    _HolidayCorrectionID = paramID
                Case WorkerStatusType.NPD
                    _NpdID = paramID
                Case WorkerStatusType.PNPD
                    _PnpdID = paramID
                Case WorkerStatusType.Position
                    _PositionID = paramID
                Case WorkerStatusType.Wage
                    _WageID = paramID
                Case WorkerStatusType.WorkLoad
                    _WorkLoadID = paramID
            End Select
        End Sub

        Private Function IsParamValueReadonly(ByVal paramType As WorkerStatusType) As Boolean
            Return Not IsNew AndAlso Not _ChronologicValidator.FinancialDataCanChange AndAlso _
                (paramType = WorkerStatusType.ExtraPay OrElse paramType = WorkerStatusType.NPD _
                OrElse paramType = WorkerStatusType.PNPD OrElse paramType = WorkerStatusType.Wage)
        End Function

        Private Function ParamValueHasStatusItem(ByVal paramType As WorkerStatusType) As Boolean

            If (paramType = WorkerStatusType.ExtraPay AndAlso Not CRound(_ExtraPay, 2) > 0) _
                OrElse (paramType = WorkerStatusType.Fired AndAlso Not _IsTerminated) _
                OrElse (paramType = WorkerStatusType.HolidayCorrection AndAlso _
                    CRound(_HolidayCorrection, ROUNDACCUMULATEDHOLIDAY) = 0) _
                OrElse (paramType = WorkerStatusType.NPD AndAlso Not CRound(_NPD, 2) > 0) _
                OrElse (paramType = WorkerStatusType.PNPD AndAlso Not CRound(_PNPD, 2) > 0) _
                OrElse (paramType = WorkerStatusType.Position AndAlso String.IsNullOrEmpty(_Position.Trim)) Then _
                Return False

            Return True

        End Function

        Private Sub CheckIfContractSerialNumberUnique()

            Dim myComm As New SQLCommand("CheckIfContractSerialNumberUnique")
            myComm.AddParam("?DS", _Serial.Trim)
            myComm.AddParam("?DN", _Number)
            myComm.AddParam("?CD", _ID)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 AndAlso CIntSafe(myData.Rows(0).Item(0), 0) > 0 Then _
                    Throw New Exception(My.Resources.Workers_Contract_SerialNumberAlreadyExists)
            End Using

        End Sub

        Private Sub CheckIfUpdateDateChanged()

            Dim myComm As New SQLCommand("CheckIfContractUpdateDateChanged")
            myComm.AddParam("?CD", _ID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 OrElse CDateTimeSafe(myData.Rows(0).Item(0), _
                    Date.MinValue) = Date.MinValue Then

                    Throw New Exception(String.Format(My.Resources.Common_ObjectNotFound, _
                        My.Resources.Workers_Contract_TypeName, _ID.ToString))

                End If

                If CTimeStampSafe(myData.Rows(0).Item(0)) <> _UpdateDate Then

                    Throw New Exception(My.Resources.Common_UpdateDateHasChanged)

                End If

            End Using

        End Sub

#End Region

    End Class

End Namespace