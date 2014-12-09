Namespace Workers

    <Serializable()> _
    Public Class WagePayOutItem
        Inherits BusinessBase(Of WagePayOutItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _GUID As Guid = Guid.NewGuid
        Private _IsChecked As Boolean = False
        Private _ID As Integer = 0
        Private _PersonID As Integer = 0
        Private _PersonName As String = ""
        Private _PersonCode As String = ""
        Private _ContractSerial As String = ""
        Private _ContractNumber As Integer = 0
        Private _PayOffSum As Double = 0
        Private _PayOffDate As Csla.SmartDate = New Csla.SmartDate(False)


        Public Property IsChecked() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsChecked
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _IsChecked <> value Then
                    _IsChecked = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property PersonID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonID
            End Get
        End Property

        Public ReadOnly Property PersonName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonName.Trim
            End Get
        End Property

        Public ReadOnly Property PersonCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonCode.Trim
            End Get
        End Property

        Public ReadOnly Property ContractSerial() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContractSerial.Trim
            End Get
        End Property

        Public ReadOnly Property ContractNumber() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContractNumber
            End Get
        End Property

        Public ReadOnly Property PayOffSum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOffSum)
            End Get
        End Property

        Public Property PayOffDate() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PayOffDate.ToString()
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If _PayOffDate.Date <> New Csla.SmartDate(value.Trim, False).Date Then
                    _PayOffDate = New Csla.SmartDate(value.Trim, False)
                    PropertyHasChanged()
                End If
            End Set
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
            Return _PersonName & " darbo sutartis Nr. " & _ContractSerial & _ContractNumber.ToString
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()
            ValidationRules.AddRule(AddressOf PayOutDateValidation, "PayOffDate")
            ValidationRules.AddDependantProperty("IsChecked", "PayOffDate", False)
        End Sub

        ''' <summary>
        ''' Rule ensuring valid date for checked item is entered.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function PayOutDateValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As WagePayOutItem = DirectCast(target, WagePayOutItem)

            If Not ValObj._IsChecked Then Return True

            If ValObj._PayOffDate.IsEmpty Then
                e.Description = "Pasirinktam darbuotojui " & ValObj._PersonName & " pagal darbo sutartį " & _
                    ValObj._ContractSerial & ValObj._ContractNumber & " nenurodyta išmokėjimo data."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            If Not ValObj.Parent Is Nothing AndAlso ValObj._PayOffDate.Date.Date < _
                CType(ValObj.Parent, WagePayOutItemList).Date.Date Then
                e.Description = "Pasirinktam darbuotojui " & ValObj._PersonName & _
                    " pagal darbo sutartį " & ValObj._ContractSerial & ValObj._ContractNumber & _
                    " nurodyta išmokėjimo data yra ankstesnė už žiniaraščio datą."
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

        Friend Shared Function GetWagePayOutItem(ByVal dr As DataRow) As WagePayOutItem
            Return New WagePayOutItem(dr)
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
            _PersonID = CIntSafe(dr.Item(1), 0)
            _PersonName = CStrSafe(dr.Item(2)).Trim
            _PersonCode = CStrSafe(dr.Item(3)).Trim
            _ContractNumber = CIntSafe(dr.Item(4), 0)
            _ContractSerial = CStrSafe(dr.Item(5)).Trim
            _PayOffSum = CDblSafe(dr.Item(6), 2, 0)

            If CDateSafe(dr.Item(7), Date.MinValue) <> Date.MinValue Then
                _IsChecked = True
                _PayOffDate = New Csla.SmartDate(CDateSafe(dr.Item(7), Date.MinValue), False)
                MarkOld()
            Else
                MarkNew()
            End If

        End Sub

        Friend Sub Update(ByVal parent As WagePayOutDocument)

            Dim myComm As SQLCommand

            If parent.Type = DocumentType.ImprestSheet Then
                myComm = New SQLCommand("UpdateWagePayOutItem1")
            Else
                myComm = New SQLCommand("UpdateWagePayOutItem2")
            End If

            myComm.AddParam("?LD", _ID)
            If _PayOffDate.IsEmpty OrElse Not _IsChecked Then
                myComm.AddParam("?DT", Nothing, GetType(Date))
            Else
                myComm.AddParam("?DT", _PayOffDate.Date.Date)
            End If

            myComm.Execute()

            If _PayOffDate.IsEmpty Then
                MarkNew()
            Else
                MarkOld()
            End If

        End Sub

#End Region

    End Class

End Namespace