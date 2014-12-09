Namespace Assets

    <Serializable()> _
    Public Class AcquisitionChronologicValidator
        Inherits ReadOnlyBase(Of AcquisitionChronologicValidator)
        Implements IChronologicValidator

#Region " Business Methods "

        Private _CurrentOperationID As Integer = 0
        Private _CurrentOperationDate As Date = Today
        Private _CurrentOperationName As String = ""
        Private _FinancialDataCanChange As Boolean = True
        Private _MinDateApplicable As Boolean = False
        Private _MaxDateApplicable As Boolean = False
        Private _MinDate As Date = Date.MinValue
        Private _MaxDate As Date = Date.MaxValue
        Private _FinancialDataCanChangeExplanation As String = ""
        Private _MinDateExplanation As String = ""
        Private _MaxDateExplanation As String = ""
        Private _LimitsExplanation As String = ""
        Private _BackgroundExplanation As String = ""
        Private _AmortizationIsCalculated As Boolean = False
        Private _ParentFinancialDataCanChange As Boolean = True
        Private _ParentFinancialDataCanChangeExplanation As String = ""


        Public ReadOnly Property CurrentOperationID() As Integer _
            Implements IChronologicValidator.CurrentOperationID
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationID
            End Get
        End Property

        Public ReadOnly Property CurrentOperationDate() As Date _
            Implements IChronologicValidator.CurrentOperationDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationDate
            End Get
        End Property

        Public ReadOnly Property CurrentOperationName() As String _
            Implements IChronologicValidator.CurrentOperationName
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationName.Trim
            End Get
        End Property

        Public ReadOnly Property FinancialDataCanChange() As Boolean _
            Implements IChronologicValidator.FinancialDataCanChange
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property MinDateApplicable() As Boolean _
            Implements IChronologicValidator.MinDateApplicable
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDateApplicable
            End Get
        End Property

        Public ReadOnly Property MaxDateApplicable() As Boolean _
            Implements IChronologicValidator.MaxDateApplicable
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDateApplicable
            End Get
        End Property

        Public ReadOnly Property MinDate() As Date _
            Implements IChronologicValidator.MinDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDate
            End Get
        End Property

        Public ReadOnly Property MaxDate() As Date _
            Implements IChronologicValidator.MaxDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDate
            End Get
        End Property

        Public ReadOnly Property FinancialDataCanChangeExplanation() As String _
            Implements IChronologicValidator.FinancialDataCanChangeExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChangeExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property MinDateExplanation() As String _
            Implements IChronologicValidator.MinDateExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDateExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property MaxDateExplanation() As String _
            Implements IChronologicValidator.MaxDateExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDateExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property LimitsExplanation() As String _
            Implements IChronologicValidator.LimitsExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LimitsExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property BackgroundExplanation() As String _
            Implements IChronologicValidator.BackgroundExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BackgroundExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property AmortizationIsCalculated() As Boolean 
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AmortizationIsCalculated
            End Get
        End Property

        Public ReadOnly Property ParentFinancialDataCanChange() As Boolean _
        Implements IChronologicValidator.ParentFinancialDataCanChange
            Get
                Return _ParentFinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property ParentFinancialDataCanChangeExplanation() As String _
            Implements IChronologicValidator.ParentFinancialDataCanChangeExplanation
            Get
                Return _ParentFinancialDataCanChangeExplanation
            End Get
        End Property


        Public Function ValidateOperationDate(ByVal OperationDate As Date, ByRef ErrorMessage As String, _
            ByRef ErrorSeverity As Csla.Validation.RuleSeverity) As Boolean _
            Implements IChronologicValidator.ValidateOperationDate

            If _MinDateApplicable AndAlso OperationDate.Date < _MinDate.Date Then
                ErrorMessage = _MinDateExplanation
                ErrorSeverity = Validation.RuleSeverity.Error
                Return False
            ElseIf _MaxDateApplicable AndAlso OperationDate.Date > _MaxDate.Date Then
                ErrorMessage = _MaxDateExplanation
                ErrorSeverity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _CurrentOperationID
        End Function

        Public Overrides Function ToString() As String
            Return _CurrentOperationName
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function NewAcquisitionChronologicValidator( _
            ByVal parentChronologyValidator As SimpleChronologicValidator) As AcquisitionChronologicValidator
            Return New AcquisitionChronologicValidator(parentChronologyValidator)
        End Function

        Friend Shared Function GetAcquisitionChronologicValidator(ByVal AssetID As Integer, _
            ByVal AcquisitionDate As Date, ByVal AssetName As String, ByVal IsContinuedUsage As Boolean, _
            ByVal parentChronologyValidator As SimpleChronologicValidator) As AcquisitionChronologicValidator
            Return New AcquisitionChronologicValidator(AssetID, AcquisitionDate, AssetName, _
                IsContinuedUsage, parentChronologyValidator)
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal parentChronologyValidator As SimpleChronologicValidator)
            Create(parentChronologyValidator)
        End Sub

        Private Sub New(ByVal AssetID As Integer, ByVal AcquisitionDate As Date, _
            ByVal AssetName As String, ByVal IsContinuedUsage As Boolean, _
            ByVal parentChronologyValidator As SimpleChronologicValidator)
            Fetch(AssetID, AcquisitionDate, AssetName, IsContinuedUsage, parentChronologyValidator)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal parentChronologyValidator As SimpleChronologicValidator)
            _CurrentOperationName = "Naujo ilgalaikio turto įsigijimas"
            IncludeParentChronologyValidator(parentChronologyValidator)
        End Sub

        Private Sub Fetch(ByVal AssetID As Integer, ByVal AcquisitionDate As Date, _
            ByVal AssetName As String, ByVal IsContinuedUsage As Boolean, _
            ByVal parentChronologyValidator As SimpleChronologicValidator)

            Dim myComm As New SQLCommand("FetchLongTermAssetUpdateLimitingFactors")
            myComm.AddParam("?AD", AssetID)

            Dim cOpType As LtaOperationType
            Using myData As DataTable = myComm.Fetch

                _CurrentOperationID = AssetID
                _CurrentOperationDate = AcquisitionDate
                _CurrentOperationName = "Ilgalaikio turto įsigijimas - """ & AssetName & """"

                For Each dr As DataRow In myData.Rows

                    cOpType = ConvertEnumDatabaseStringCode(Of LtaOperationType)(CStrSafe(dr.Item(0)))

                    If IsContinuedUsage AndAlso cOpType = LtaOperationType.Amortization Then

                        _AmortizationIsCalculated = True
                        _FinancialDataCanChange = False
                        _FinancialDataCanChangeExplanation = "Finansiniai IT įsigijimo duomenys negali " _
                            & "būti keičiami, nes turtas buvo amortizuotas."

                        _MinDateApplicable = True
                        _MaxDateApplicable = True
                        _MinDate = AcquisitionDate
                        _MaxDate = AcquisitionDate
                        _MinDateExplanation = "Įsigijimo data negali būti keičiama, nes IT buvo skaičiuota amortizacija."
                        _MaxDateExplanation = "Įsigijimo data negali būti keičiama, nes IT buvo skaičiuota amortizacija."

                        Exit For

                    ElseIf cOpType = LtaOperationType.Amortization Then

                        _AmortizationIsCalculated = True

                    End If

                    If _FinancialDataCanChange AndAlso cOpType <> LtaOperationType.AmortizationPeriod _
                        AndAlso cOpType <> LtaOperationType.UsingEnd _
                        AndAlso cOpType <> LtaOperationType.UsingStart Then

                        _FinancialDataCanChange = False
                        _FinancialDataCanChangeExplanation = "Finansiniai IT įsigijimo duomenys negali " _
                            & "būti keičiami, nes su turtu yra registruota kitų finansinių operacijų (" _
                            & CDateSafe(dr.Item(1), Date.MinValue).ToString("yyyy-MM-dd") & ")."

                    End If

                    If CDateSafe(dr.Item(1), Date.MinValue).Date > _MinDate.Date Then

                        _MaxDateApplicable = True
                        _MaxDate = CDateSafe(dr.Item(1), Date.MinValue).Date
                        _MaxDateExplanation = "Operacijos data negali būti vėlesnė nei " _
                            & _MaxDate.ToString("yyyy-MM-dd") & ", nes šia data yra registruota operacija - " _
                            & ConvertEnumHumanReadable(cOpType) & "."

                    End If

                Next

            End Using

            _LimitsExplanation = ""
            _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _FinancialDataCanChangeExplanation, False)
            _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MinDateExplanation, False)
            _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MaxDateExplanation, False)

            IncludeParentChronologyValidator(parentChronologyValidator)

        End Sub

        Private Sub IncludeParentChronologyValidator(ByVal parentChronologyValidator As SimpleChronologicValidator)

            If parentChronologyValidator Is Nothing Then Exit Sub

            If (_MinDateApplicable AndAlso _MinDate.Date < parentChronologyValidator.MinDate.Date) _
                OrElse (Not _MinDateApplicable AndAlso parentChronologyValidator.MinDateApplicable) Then
                _MinDateApplicable = True
                _MinDate = parentChronologyValidator.MinDate
                _MinDateExplanation = parentChronologyValidator.MinDateExplanation
            End If

            If (_MaxDateApplicable AndAlso _MaxDate.Date > parentChronologyValidator.MaxDate.Date) _
                OrElse (Not _MaxDateApplicable AndAlso parentChronologyValidator.MaxDateApplicable) Then
                _MaxDateApplicable = True
                _MaxDate = parentChronologyValidator.MaxDate
                _MaxDateExplanation = parentChronologyValidator.MaxDateExplanation
            End If

            If _FinancialDataCanChange AndAlso Not parentChronologyValidator.FinancialDataCanChange Then
                _FinancialDataCanChange = False
                _FinancialDataCanChangeExplanation = parentChronologyValidator.FinancialDataCanChangeExplanation
            ElseIf Not _FinancialDataCanChange AndAlso Not parentChronologyValidator.FinancialDataCanChange Then
                _FinancialDataCanChangeExplanation = AddWithNewLine(_FinancialDataCanChangeExplanation, _
                    parentChronologyValidator.FinancialDataCanChangeExplanation, False)
            End If

            _ParentFinancialDataCanChange = parentChronologyValidator.ParentFinancialDataCanChange
            _ParentFinancialDataCanChangeExplanation = parentChronologyValidator.ParentFinancialDataCanChangeExplanation

            _LimitsExplanation = AddWithNewLine(_LimitsExplanation, parentChronologyValidator.LimitsExplanation, False)

        End Sub

#End Region

    End Class

End Namespace