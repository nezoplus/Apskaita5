Namespace Settings

    <Serializable()> _
    Public Class TaxRate
        Inherits BusinessBase(Of TaxRate)
        Implements ICustomXmlSerialized

#Region " Business Methods "

        Private _GID As Guid = Guid.NewGuid
        Private _TaxType As TaxTarifType = TaxTarifType.Vat
        Private _TaxTypeHumanReadable As String = ConvertEnumHumanReadable(TaxTarifType.Vat)
        Private _TaxToken As String = ""
        Private _TaxRate As Double = 0
        Private _IsObsolete As Boolean = False

        Public Property TaxType() As TaxTarifType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TaxType
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As TaxTarifType)
                If _TaxType <> value Then
                    _TaxType = value
                    _TaxTypeHumanReadable = ConvertEnumHumanReadable(value)
                    PropertyHasChanged()
                    PropertyHasChanged("TaxTypeHumanReadable")
                End If
            End Set
        End Property

        Public Property TaxTypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TaxTypeHumanReadable
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing OrElse String.IsNullOrEmpty(value.Trim) Then _
                    value = ConvertEnumHumanReadable(TaxTarifType.Vat)
                If ConvertEnumHumanReadable(Of TaxTarifType)(value.Trim) <> _TaxType Then
                    _TaxType = ConvertEnumHumanReadable(Of TaxTarifType)(value.Trim)
                    _TaxTypeHumanReadable = ConvertEnumHumanReadable(_TaxType)
                    PropertyHasChanged()
                    PropertyHasChanged("TaxType")
                End If
            End Set
        End Property

        Public Property TaxRate() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TaxRate
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If CRound(_TaxRate) <> CRound(value) Then
                    _TaxRate = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property IsObsolete() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsObsolete
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _IsObsolete <> value Then
                    _IsObsolete = value
                    PropertyHasChanged()
                End If
            End Set
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _GID
        End Function

        Friend Sub ForceCheckRules()
            Me.ValidationRules.CheckRules()
        End Sub

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()
            ValidationRules.AddRule(AddressOf CommonValidation.NumberBetweenRequired, _
                New CommonValidation.NumberBetweenRequiredRuleArgs("TaxRate", "Tarifo vertė", 0, 100))
        End Sub

        ''' <summary>
        ''' Rule ensuring that the Tax Token (describing tax type) provided is known (valid).
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function TaxTokenValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As TaxRate = DirectCast(target, TaxRate)

            If ValObj._TaxToken Is Nothing OrElse String.IsNullOrEmpty(ValObj._TaxToken.Trim) Then
                e.Description = "Nenurodytas mokesčio tipas."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Try
                ConvertEnumHumanReadable(Of TaxTarifType)(ValObj._TaxToken.Trim)
            Catch ex As Exception
                e.Description = ex.Message
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End Try

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewTaxRate(ByVal CheckValidationRules As Boolean) As TaxRate
            Dim result As New TaxRate
            If CheckValidationRules Then result.ValidationRules.CheckRules()
            Return result
        End Function

        Friend Shared Function NewTaxRate(ByVal nTaxToken As String, ByVal nTaxRate As Double) As TaxRate
            Return New TaxRate(nTaxToken, nTaxRate)
        End Function

        Friend Shared Function NewTaxRate(ByVal dr As DataRow) As TaxRate
            Return New TaxRate(dr)
        End Function

        Private Sub New()
            MarkAsChild()
        End Sub

        Private Sub New(ByVal nTaxToken As String, ByVal nTaxRate As Double)
            _TaxToken = nTaxToken
            _TaxRate = nTaxRate
            MarkAsChild()
            ValidationRules.CheckRules()
        End Sub

        Private Sub New(ByVal dr As DataRow)
            MarkAsChild()
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow)

            _TaxToken = CStrSafe(dr.Item(0))
            _TaxType = ConvertEnumDatabaseStringCode(Of TaxTarifType)(_TaxToken)
            _TaxTypeHumanReadable = ConvertEnumHumanReadable(_TaxType)
            _TaxRate = CDblSafe(dr.Item(1), 2, 0)
            _IsObsolete = True

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Friend Function EqualsDataRow(ByVal dr As DataRow) As Boolean

            Return (_TaxType = ConvertEnumDatabaseStringCode(Of TaxTarifType) _
                (CStrSafe(dr.Item(0))) AndAlso CRound(_TaxRate) = CDblSafe(dr.Item(1), 2, 0))

        End Function


        Private Sub DeSerialize(ByVal node As System.Xml.XmlNode) _
            Implements ICustomXmlSerialized.DeSerialize
            _TaxType = ConvertEnumDatabaseStringCode(Of TaxTarifType)(_TaxToken)
            _TaxTypeHumanReadable = ConvertEnumHumanReadable(_TaxType)
            MarkOld()
            ValidationRules.CheckRules()
        End Sub

        Public Function IsSerializedCollection() As Boolean _
            Implements ICustomXmlSerialized.IsSerializedCollection
            Return False
        End Function

        Private Sub Serialize(ByRef node As System.Xml.XmlNode) _
            Implements ICustomXmlSerialized.Serialize
            _TaxToken = ConvertEnumDatabaseStringCode(_TaxType)
            CustomXmlSerialization.AddChildNode(node, "_TaxRate", _TaxRate)
            CustomXmlSerialization.AddChildNode(node, "_TaxToken", _TaxToken)
            CustomXmlSerialization.AddChildNode(node, "_IsObsolete", _IsObsolete)
            MarkOld()
        End Sub

#End Region

    End Class

End Namespace