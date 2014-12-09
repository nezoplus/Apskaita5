Namespace Workers

    <Serializable()> _
    Public Class DayWorkTime
        Inherits BusinessBase(Of DayWorkTime)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _DayNumber As Integer = 0
        Private _Type As WorkTimeClassInfo = Nothing
        Private _Length As Double = 0
        Private _DayCount As Integer = 31


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property DayNumber() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DayNumber
            End Get
        End Property

        Public ReadOnly Property DayCount() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DayCount
            End Get
        End Property

        Public Property [Type]() As WorkTimeClassInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As WorkTimeClassInfo)
                CanWriteProperty(True)
                If Not (_Type Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Type Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _Type = value) AndAlso Not _DayNumber > _DayCount Then
                    _Type = value
                    PropertyHasChanged()
                    PropertyHasChanged("TypeCode")
                    If Not _Type Is Nothing AndAlso _Type.ID > 0 Then Length = 0
                End If
            End Set
        End Property

        Public ReadOnly Property TypeCode() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _Type Is Nothing OrElse Not _Type.ID > 0 Then Return ""
                Return _Type.Code
            End Get
        End Property

        Public Property Length() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Length, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Length, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) _
                    AndAlso Not _DayNumber > _DayCount Then
                    _Length = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                End If
            End Set
        End Property



        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return "Klaida (-os) eilutėje '" & _DayNumber.ToString & " diena': " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return "Eilutėje '" & _DayNumber.ToString & " diena' gali būti klaida: " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
        End Function


        Friend Function SetLength(ByVal value As Double) As Boolean
            If CRound(_Length, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) _
                AndAlso Not _DayNumber > _DayCount Then
                _Length = CRound(value, ROUNDWORKTIME)
                PropertyHasChanged("Length")
                Return True
            Else
                Return False
            End If
        End Function

        Friend Function SetType(ByVal value As WorkTimeClassInfo) As Boolean
            If Not (_Type Is Nothing AndAlso value Is Nothing) _
                AndAlso Not (Not _Type Is Nothing AndAlso Not value Is Nothing _
                AndAlso _Type = value) AndAlso Not _DayNumber > _DayCount Then
                _Type = value
                PropertyHasChanged()
                PropertyHasChanged("TypeCode")
                If Not _Type Is Nothing AndAlso _Type.ID > 0 Then Length = 0
                Return True
            Else
                Return False
            End If
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            If _Type Is Nothing OrElse Not _Type.ID > 0 Then Return _Length.ToString
            Return _Type.Code
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf LengthValidation, New Validation.RuleArgs("Length"))
            ValidationRules.AddDependantProperty("Type", "Length", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property Length is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function LengthValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As DayWorkTime = DirectCast(target, DayWorkTime)

            If ValObj._DayNumber > ValObj._DayCount Then Return True

            If (ValObj._Type Is Nothing OrElse Not ValObj._Type.ID > 0) _
                AndAlso Not CRound(ValObj._Length, ROUNDWORKTIME) > 0 Then
                e.Description = "Nenurodyta trukmė arba dienos tipo kodas."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf (ValObj._Type Is Nothing OrElse Not ValObj._Type.ID > 0) _
                AndAlso CRound(ValObj._Length, ROUNDWORKTIME) > 24 Then
                e.Description = "Paroje yra tik 24 valandos."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf Not ValObj._Type Is Nothing AndAlso ValObj._Type.ID > 0 _
                AndAlso Not ValObj._Type.WithoutWorkHours Then
                e.Description = "Pasirinktas (ne)darbo laiko tipas yra su valandomis."
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

        Friend Shared Function NewDayWorkTime(ByVal nDayNumber As Integer, _
            ByVal cYear As Integer, ByVal cMonth As Integer, ByVal cLoad As Double, _
            ByVal RestDayInfo As WorkTimeClassInfo, ByVal PublicHolydaysInfo As WorkTimeClassInfo) As DayWorkTime
            Return New DayWorkTime(nDayNumber, cYear, cMonth, cLoad, RestDayInfo, PublicHolydaysInfo)
        End Function

        Friend Shared Function GetDayWorkTime(ByVal dr As DataRow, ByVal cMaxDayCount As Integer) As DayWorkTime
            Return New DayWorkTime(dr, cMaxDayCount)
        End Function

        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal nDayNumber As Integer, ByVal cYear As Integer, _
            ByVal cMonth As Integer, ByVal cLoad As Double, _
            ByVal RestDayInfo As WorkTimeClassInfo, ByVal PublicHolydaysInfo As WorkTimeClassInfo)
            MarkAsChild()
            Create(nDayNumber, cYear, cMonth, cLoad, RestDayInfo, PublicHolydaysInfo)
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal cMaxDayCount As Integer)
            MarkAsChild()
            Fetch(dr, cMaxDayCount)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal nDayNumber As Integer, ByVal cYear As Integer, _
            ByVal cMonth As Integer, ByVal cLoad As Double, _
            ByVal RestDayInfo As WorkTimeClassInfo, ByVal PublicHolydaysInfo As WorkTimeClassInfo)

            _DayNumber = nDayNumber
            _DayCount = Date.DaysInMonth(cYear, cMonth)
            If _DayNumber <= _DayCount Then
                If WorkTime.IsPublicHolidays(cYear, cMonth, nDayNumber) Then
                    _Type = PublicHolydaysInfo
                ElseIf (New Date(cYear, cMonth, _DayNumber)).DayOfWeek = DayOfWeek.Sunday _
                    OrElse (New Date(cYear, cMonth, _DayNumber)).DayOfWeek = DayOfWeek.Saturday Then
                    _Type = RestDayInfo
                Else
                    _Length = CRound(8 * cLoad, ROUNDWORKTIME)
                End If
            End If

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal dr As DataRow, ByVal cMaxDayCount As Integer)

            _ID = CIntSafe(dr.Item(1), 0)
            _DayNumber = CIntSafe(dr.Item(2), 0)
            _Length = CRound(CDblSafe(dr.Item(3), 0), ROUNDWORKTIME)
            _Type = WorkTimeClassInfo.GetWorkTimeClassInfo(dr, 4)
            _DayCount = cMaxDayCount

            MarkOld()
            ValidationRules.CheckRules()

        End Sub

        Friend Sub Insert(ByVal parent As WorkTimeItem)

            Dim myComm As New SQLCommand("InsertDayWorkTime")
            AddWithParams(myComm)
            myComm.AddParam("?AA", _DayNumber)
            myComm.AddParam("?PD", parent.ID)

            myComm.Execute()

            _ID = myComm.LastInsertID

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As WorkTimeItem)

            Dim myComm As New SQLCommand("UpdateDayWorkTime")
            myComm.AddParam("?CD", _ID)
            AddWithParams(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Private Sub AddWithParams(ByRef myComm As SQLCommand)
            myComm.AddParam("?AB", CRound(_Length, ROUNDWORKTIME))
            If _Type Is Nothing OrElse Not _Type.ID > 0 Then
                myComm.AddParam("?AC", 0)
            Else
                myComm.AddParam("?AC", _Type.ID)
            End If
        End Sub

#End Region

    End Class

End Namespace