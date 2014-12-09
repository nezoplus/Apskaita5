Namespace Workers

    <Serializable()> _
    Public Class SheetChronologicValidator
        Inherits ReadOnlyBase(Of SimpleChronologicValidator)
        Implements IChronologicValidator

#Region " Business Methods "

        Private Const DatePlaceHolder As String = "<#DATE#>"

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
        Private _FirstPayedDate As Date = Date.MaxValue
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

        Public ReadOnly Property FirstPayedDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FirstPayedDate
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

        Friend Shared Function NewSheetChronologicValidator(ByVal SheetType As DocumentType, _
            ByVal SheetYear As Integer, ByVal SheetMonth As Integer) As SheetChronologicValidator
            Return New SheetChronologicValidator(SheetType, SheetYear, SheetMonth)
        End Function

        Friend Shared Function GetSheetChronologicValidator(ByVal SheetType As DocumentType, _
            ByVal nID As Integer) As SheetChronologicValidator
            Return New SheetChronologicValidator(SheetType, nID)
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal SheetType As DocumentType, ByVal SheetYear As Integer, ByVal SheetMonth As Integer)
            Create(SheetType, SheetYear, SheetMonth)
        End Sub

        Private Sub New(ByVal SheetType As DocumentType, ByVal nID As Integer)
            Fetch(SheetType, nID)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal SheetType As DocumentType, ByVal SheetYear As Integer, _
            ByVal SheetMonth As Integer)

            SetOperationName(SheetType)
            SetDefaultLimits(SheetYear, SheetMonth)

            SetSimpleLimits(SimpleChronologicValidator.NewSimpleChronologicValidator(_CurrentOperationName))

            SetLimitsExplanation()

        End Sub

        Private Sub Fetch(ByVal SheetType As DocumentType, ByVal nID As Integer)

            _CurrentOperationID = nID

            SetOperationName(SheetType)

            Dim myComm As SQLCommand
            If SheetType = DocumentType.ImprestSheet Then
                myComm = New SQLCommand("FetchSheetChronologicValidatorImprest")
            ElseIf SheetType = DocumentType.WageSheet Then
                myComm = New SQLCommand("SheetChronologicValidatorWage")
            Else
                Throw New NotImplementedException("Sheet type " & SheetType.ToString _
                    & " is not implemented in method SheetChronologicValidator.Fetch .")
            End If

            myComm.AddParam("?SD", nID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception("Žiniaraštis, kurio ID=" _
                    & nID.ToString & ", nerastas.")

                Dim dr As DataRow = myData.Rows(0)

                _CurrentOperationDate = CDateSafe(dr.Item(0), Date.MinValue)

                If _CurrentOperationDate = Date.MinValue Then Throw New Exception( _
                    "Nepavyko gauti žiniaraščio datos. (ID=" & nID.ToString & ")")

                SetDefaultLimits(CIntSafe(dr.Item(1)), CIntSafe(dr.Item(2), 1))

                _FirstPayedDate = CDateSafe(dr.Item(3), Date.MaxValue)

                SetMaxDateApplicable(_FirstPayedDate, "Žiniaraščio data negali būti vėlesnė " _
                    & "už pirmą išmokėjimą pagal žiniaraštį - " & DatePlaceHolder & ".")

                If _FirstPayedDate <> Date.MaxValue Then
                    _FinancialDataCanChange = False
                    _FinancialDataCanChangeExplanation = "Finansiniai parametrai " _
                        & "negali būti keičiami, nes pagal žiniaraštį buvo daromi išmokėjimai."
                End If

                SetSimpleLimits(SimpleChronologicValidator.GetSimpleChronologicValidator( _
                    nID, _CurrentOperationDate, _CurrentOperationName))

            End Using

            SetLimitsExplanation()

        End Sub


        Friend Shared Sub CheckIfCanDelete(ByVal SheetType As DocumentType, ByVal id As Integer)

            Dim myComm As SQLCommand
            If SheetType = DocumentType.ImprestSheet Then
                myComm = New SQLCommand("CheckIfCanDeleteImprestSheet")
            ElseIf SheetType = DocumentType.WageSheet Then
                myComm = New SQLCommand("CheckIfCanDeleteWageSheet")
            Else
                Throw New NotImplementedException("Sheet type " & SheetType.ToString _
                    & " is not implemented in method SheetChronologicValidator.CheckIfCanDelete .")
            End If

            myComm.AddParam("?SD", id)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception("Žiniaraštis, kurio ID=" _
                    & id.ToString & ", nerastas.")

                Dim dr As DataRow = myData.Rows(0)

                If CDateSafe(dr.Item(0), Date.MaxValue) < GetCurrentCompany.LastClosingDate Then _
                    Throw New Exception("Klaida. Po šio žiniaraščio yra registruotas sąskaitų uždarymas.")

                If CIntSafe(dr.Item(1), 0) > 0 Then Throw New Exception( _
                    "Klaida. Žiniaraščiui yra registruota išmokėjimų.")

            End Using

        End Sub


        Private Sub SetMaxDateApplicable(ByVal nDate As Date, ByVal nExplanation As String)

            If nDate = Date.MaxValue OrElse nDate = Date.MinValue Then Exit Sub

            If Not nDate.Date < _MaxDate.Date Then Exit Sub

            _MaxDateApplicable = True
            _MaxDate = nDate.Date
            _MaxDateExplanation = nExplanation.Replace(DatePlaceHolder, nDate.ToString("yyyy-MM-dd"))

        End Sub

        Private Sub SetMinDateApplicable(ByVal nDate As Date, ByVal nExplanation As String)

            If nDate = Date.MaxValue OrElse nDate = Date.MinValue Then Exit Sub

            If Not nDate.Date > _MinDate.Date Then Exit Sub

            _MinDateApplicable = True
            _MinDate = nDate.Date
            _MinDateExplanation = nExplanation.Replace(DatePlaceHolder, nDate.ToString("yyyy-MM-dd"))

        End Sub

        Private Sub SetLimitsExplanation()

            _LimitsExplanation = ""
            If Not _FinancialDataCanChange Then _LimitsExplanation = _FinancialDataCanChangeExplanation
            If _MinDateApplicable Then _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _
                _MinDateExplanation, False)
            If _MaxDateApplicable Then _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _
                 _MaxDateExplanation, False)

        End Sub

        Private Sub SetOperationName(ByVal SheetType As DocumentType)

            If SheetType = DocumentType.WageSheet Then
                _CurrentOperationName = "darbo užmokesčio žiniaraštis"
            ElseIf SheetType = DocumentType.ImprestSheet Then
                _CurrentOperationName = "avanso žiniaraštis"
            Else
                Throw New ArgumentException("Sheet type " & SheetType.ToString & " is invalid.")
            End If

        End Sub

        Private Sub SetDefaultLimits(ByVal SheetYear As Integer, ByVal SheetMonth As Integer)

            Dim minDate As Date = New Date(SheetYear, SheetMonth, 1)
            SetMinDateApplicable(minDate, "Žiniaraščio data negali būti ankstesnė nei mėnesio, " _
                & "už kurį daromi priskaičiavimai, pirma diena, t.y. " & minDate.ToString("yyyy-MM-dd") & ".")

            Dim maxdate As Date = minDate.AddMonths(1)
            maxdate = New Date(maxdate.Year, maxdate.Month, Date.DaysInMonth(maxdate.Year, maxdate.Month))
            SetMaxDateApplicable(maxdate, "Žiniaraščio data negali būti ankstesnė nei sekančio mėnesio " _
                & "po priskaičiavimo paskutinė diena, t.y. " & maxdate.ToString("yyyy-MM-dd") & ".")

        End Sub

        Private Sub SetSimpleLimits(ByVal simpleValidator As SimpleChronologicValidator)

            If simpleValidator.MinDateApplicable Then SetMinDateApplicable( _
                    simpleValidator.MinDate, simpleValidator.MinDateExplanation)
            If simpleValidator.MaxDateApplicable Then SetMaxDateApplicable( _
                simpleValidator.MaxDate, simpleValidator.MaxDateExplanation)
            If Not simpleValidator.FinancialDataCanChange Then
                _FinancialDataCanChange = False
                _FinancialDataCanChangeExplanation = AddWithNewLine(_FinancialDataCanChangeExplanation, _
                    simpleValidator.FinancialDataCanChangeExplanation, False)
                _ParentFinancialDataCanChange = False
                _ParentFinancialDataCanChangeExplanation = _FinancialDataCanChangeExplanation
            End If

        End Sub

#End Region

    End Class

End Namespace