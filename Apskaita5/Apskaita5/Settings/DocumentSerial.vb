Namespace Settings

    <Serializable()> _
    Public Class DocumentSerial
        Inherits BusinessBase(Of DocumentSerial)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _Serial As String = ""
        Private _SerialOld As String = ""
        Private _DocumentType As DocumentSerialType
        Private _DocumentTypeOld As DocumentSerialType
        Private _WasUsed As Boolean = False


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public Property Serial() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Serial.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If _WasUsed Then
                    PropertyHasChanged()
                    Exit Property
                End If
                If value Is Nothing Then value = ""
                If value.Trim.Length > 5 Then value = value.Trim.Substring(0, 5)
                If _Serial.Trim <> value.Trim Then
                    _Serial = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property SerialOld() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SerialOld.Trim
            End Get
        End Property

        Public Property DocumentType() As DocumentSerialType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentType
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As DocumentSerialType)
                CanWriteProperty(True)
                If _WasUsed Then
                    PropertyHasChanged()
                    Exit Property
                End If
                If _DocumentType <> value Then
                    _DocumentType = value
                    PropertyHasChanged()
                    PropertyHasChanged("DocumentTypeHumanReadable")
                End If
            End Set
        End Property

        Public ReadOnly Property DocumentTypeOld() As DocumentSerialType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentTypeOld
            End Get
        End Property

        Public Property DocumentTypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return ConvertEnumHumanReadable(_DocumentType)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If _WasUsed Then
                    PropertyHasChanged()
                    Exit Property
                End If
                If ConvertEnumHumanReadable(Of DocumentSerialType)(value.Trim) <> _DocumentType Then
                    _DocumentType = ConvertEnumHumanReadable(Of DocumentSerialType)(value.Trim)
                    PropertyHasChanged()
                    PropertyHasChanged("DocumentType")
                End If
            End Set
        End Property

        Public ReadOnly Property WasUsed() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WasUsed
            End Get
        End Property



        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return "Klaida (-os) eilutėje '" & _Serial & " " & DocumentTypeHumanReadable & "': " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return "Eilutėje '" & _Serial & " " & DocumentTypeHumanReadable & "' gali būti klaida: " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
        End Function

        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return _Serial
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Serial", "serija"))
            ValidationRules.AddRule(AddressOf SerialUniqueValidation, New Validation.RuleArgs("Serial"))
        End Sub

        ''' <summary>
        ''' Rule ensuring the serial of a document is unique.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SerialUniqueValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As DocumentSerial = DirectCast(target, DocumentSerial)

            If ValObj.Parent Is Nothing OrElse String.IsNullOrEmpty(ValObj._Serial.Trim) Then Return True

            Dim ParObj As DocumentSerialList = DirectCast(ValObj.Parent, DocumentSerialList)

            For Each i As DocumentSerial In ParObj
                If Not Object.ReferenceEquals(i, ValObj) AndAlso i._DocumentType = _
                    ValObj._DocumentType AndAlso i._Serial.Trim.ToLower = ValObj._Serial.Trim.ToLower Then
                    e.Description = "Dokumento serija privalo būti unikali."
                    e.Severity = Validation.RuleSeverity.Error
                    Return False
                End If
            Next
            
            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewDocumentSerial() As DocumentSerial
            Dim result As New DocumentSerial
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Friend Shared Function GetDocumentSerial(ByVal dr As DataRow) As DocumentSerial
            Return New DocumentSerial(dr)
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
            _DocumentType = ConvertEnumDatabaseStringCode(Of DocumentSerialType)(CStrSafe(dr.Item(1)))
            _DocumentTypeOld = _DocumentType
            _Serial = CStrSafe(dr.Item(2)).Trim
            _SerialOld = _Serial
            _WasUsed = ConvertDbBoolean(CIntSafe(dr.Item(3), 0))

            MarkOld()

        End Sub

        Friend Sub Insert(ByVal parent As DocumentSerialList)

            Dim myComm As New SQLCommand("InsertDocumentSerial")
            myComm.AddParam("?SD", ConvertEnumDatabaseStringCode(_DocumentType))
            myComm.AddParam("?SR", _Serial.Trim)

            myComm.Execute()
            _ID = myComm.LastInsertID

            MarkOld()
        End Sub

        Friend Sub Update(ByVal parent As DocumentSerialList)

            Dim myComm As New SQLCommand("UpdateDocumentSerial")
            myComm.AddParam("?SD", ConvertEnumDatabaseStringCode(_DocumentType))
            myComm.AddParam("?SR", _Serial.Trim)
            myComm.AddParam("?SN", _ID)

            myComm.Execute()

            MarkOld()
        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteDocumentSerial")
            myComm.AddParam("?SN", _ID)

            myComm.Execute()

            MarkNew()

        End Sub

        Friend Sub CheckIfSerialWasUsed(ByVal ThrowOnUsedChenged As Boolean)

            If IsNew Then Exit Sub

            Dim myComm As SQLCommand
            If _DocumentType = DocumentSerialType.TillIncomeOrder Then
                myComm = New SQLCommand("DocumentSerialExists1")
            ElseIf _DocumentType = DocumentSerialType.Invoice Then
                myComm = New SQLCommand("DocumentSerialExists2")
            ElseIf _DocumentType = DocumentSerialType.TillSpendingsOrder Then
                myComm = New SQLCommand("DocumentSerialExists3")
            ElseIf _DocumentType = DocumentSerialType.LabourContract Then
                myComm = New SQLCommand("DocumentSerialExists4")
            Else
                Throw New NotImplementedException("Klaida. Serijos dokumento tipas '" _
                    & _DocumentType.ToString & "' neimplementuojas metode CheckIfSerialWasUsed.")
            End If

            myComm.AddParam("?SR", _SerialOld)
            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 Then _WasUsed = ConvertDbBoolean(CIntSafe(myData.Rows(0).Item(0), 0))
            End Using

            If ThrowOnUsedChenged AndAlso _WasUsed AndAlso (_Serial.Trim <> _SerialOld.Trim _
                OrElse _DocumentType <> _DocumentTypeOld OrElse Me.IsDeleted) Then Throw New Exception( _
                "Klaida. Dokumento '" & ConvertEnumHumanReadable(_DocumentTypeOld) & "' serija '" _
                & _SerialOld & "' buvo naudota registruojant atitinkamus dokumentus. " _
                & "Jos keisti ar pašalinti neleidžiama.")

        End Sub

#End Region

    End Class

End Namespace
