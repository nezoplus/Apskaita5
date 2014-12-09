Namespace Documents

    <Serializable()> _
    Public Class AccumulativeCostsChronologicValidator
        Inherits ReadOnlyBase(Of SimpleChronologicValidator)
        Implements IChronologicValidator

#Region " Business Methods "

        Private _CurrentOperationID As Integer = 0
        Private _CurrentOperationDate As Date = Today
        Private _CurrentOperationName As String = "sukauptos sąnaudos"
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

        Friend Shared Function NewAccumulativeCostsChronologicValidator() As AccumulativeCostsChronologicValidator
            Return New AccumulativeCostsChronologicValidator(True)
        End Function

        Friend Shared Function GetAccumulativeCostsChronologicValidator(ByVal nOperationID As Integer) As AccumulativeCostsChronologicValidator
            Return New AccumulativeCostsChronologicValidator(nOperationID)
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub


        Private Sub New(ByVal CreateObject As Boolean)
            Create()
        End Sub

        Private Sub New(ByVal nOperationID As Integer)
            Fetch(nOperationID)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create()

            Dim closingDate As Date = GetCurrentCompany.LastClosingDate

            If closingDate <> Date.MinValue AndAlso closingDate <> Date.MaxValue Then
                _MinDateApplicable = True
                _MinDate = closingDate.AddDays(1)
                _MinDateExplanation = "Operacijos data negali būti ankstesnė nei " _
                    & _MinDate.ToString("yyyy-MM-dd") & ", nes prieš tai yra registruota " _
                    & "likučių perkėlimo ir (ar) 5/6 klasių uždarymo operacija."
                _LimitsExplanation = _MinDateExplanation
            End If

        End Sub

        Private Sub Fetch(ByVal nOperationID As Integer)

            Dim myComm As New SQLCommand("FetchAccumulativeCostsChronologicValidator")
            myComm.AddParam("?PD", nOperationID)

            Using myData As DataTable = myComm.Fetch

                _CurrentOperationID = nOperationID

                If myData.Rows.Count < 1 Then Throw New Exception("Sukauptų sąnaudų objektas, kurio ID=" _
                    & nOperationID.ToString & ", nerastas.")

                Dim dr As DataRow = myData.Rows(0)

                _CurrentOperationDate = CDateSafe(dr.Item(0), Date.MinValue)

                If _CurrentOperationDate.Date = Date.MinValue.Date Then Throw New Exception( _
                    "Nepavyko gauti sukauptų sąnaudų operacijos datos. (ID=" & nOperationID.ToString & ")")

                Dim lastClosing As Date = CDateSafe(dr.Item(1), Date.MinValue)
                Dim transferDate As Date = CDateSafe(dr.Item(3), Date.MinValue)

                If lastClosing <> Date.MinValue OrElse transferDate <> Date.MinValue Then

                    _MinDateApplicable = True

                    If lastClosing > transferDate Then
                        _MinDate = lastClosing.AddDays(1)
                    Else
                        _MinDate = transferDate
                    End If

                    _MinDateExplanation = "Data negali būti ankstesnė nei " & _MinDate.ToString("yyyy-MM-dd") _
                        & " nes ankstesne data yra registruota 5/6 klasių uždarymo ir (ar) likučių perkėlimo operacija."

                End If

                _MaxDate = CDateSafe(dr.Item(2), Date.MaxValue)

                If _MaxDate <> Date.MaxValue Then

                    _MaxDateApplicable = True
                    _MaxDateExplanation = "Data negali būti vėlesnė nei " & _MaxDate.ToString("yyyy-MM-dd") _
                        & " nes vėlesne data yra registruota 5/6 klasių uždarymo ir (ar) likučių perkėlimo operacija."

                    _ParentFinancialDataCanChange = False
                    _ParentFinancialDataCanChangeExplanation = "Finansiniai operacijos duomenys " _
                        & "negali būti keičiami, nes vėlesne data yra registruota 5/6 klasių " _
                        & "uždarymo ir (ar) likučių perkėlimo operacija."

                End If

                If CDateSafe(dr.Item(4), Date.MinValue) <> Date.MinValue Then

                    _FinancialDataCanChange = False
                    _FinancialDataCanChangeExplanation = "Sąnaudų paskirstymo sąskaita " _
                        & "negali būti keičiama, nes vėlesne data yra registruota 5/6 klasių uždarymo " _
                        & "ir (ar) likučių perkėlimo operacija."

                End If

            End Using

        End Sub

#End Region

    End Class

End Namespace
