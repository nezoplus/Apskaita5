Imports Csla.Validation
Imports System.Reflection
Public Module CommonValidation

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class ExtendedRuleArgs
        Inherits RuleArgs

        Private _ApplySeverity As RuleSeverity = RuleSeverity.Error
        ''' <summary>
        ''' Severity to apply to the rule.
        ''' </summary>
        Public ReadOnly Property ApplySeverity() As RuleSeverity
            Get
                Return _ApplySeverity
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="propertyName">Name of the property to validate.</param>
        ''' <param name="SeverityToApply">Severity of the error to apply.</param>
        Public Sub New(ByVal propertyName As String, ByVal SeverityToApply As RuleSeverity)
            MyBase.New(propertyName)
            _ApplySeverity = SeverityToApply
        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?ApplySeverity=" & _ApplySeverity.ToString
        End Function

    End Class

#Region " StringFieldValidation "

    ''' <summary>
    ''' Rule ensuring a <see cref="String">String</see> field value matches requirements 
    ''' set by <see cref="StringFieldAttribute">StringFieldAttribute</see> of the property.
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function StringFieldValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim attrib As StringFieldAttribute = GetAttribute(Of StringFieldAttribute)(target.GetType, e.PropertyName)

        If attrib Is Nothing Then Return True

        Dim propName As String = GetResourcesPropertyName(target.GetType, e.PropertyName)
        Dim value As String = CallByName(target, e.PropertyName, CallType.Get).ToString

        If attrib.ValueRequired <> ValueRequiredLevel.Optional AndAlso StringIsNullOrEmpty(value) Then

            e.Description = String.Format(My.Resources.Common_FieldValueNull, propName)
            If attrib.ValueRequired = ValueRequiredLevel.Mandatory Then
                e.Severity = RuleSeverity.Error
            Else
                e.Severity = RuleSeverity.Warning
            End If
            Return False

        End If

        If Not StringIsNullOrEmpty(value) AndAlso value.Trim.Length > attrib.MaxLength Then
            e.Description = String.Format(My.Resources.Common_StringExceedsMaxLength, _
                propName, attrib.MaxLength.ToString)
            If attrib.ErrorIfExceedsMaxLength Then
                e.Severity = RuleSeverity.Error
            Else
                e.Severity = RuleSeverity.Warning
            End If
            Return False
        End If

        Return True

    End Function

#End Region

#Region " IntegerFieldValidation "

    ''' <summary>
    ''' Rule ensuring a <see cref="Integer">Integer</see> field value matches requirements 
    ''' set by <see cref="IntegerFieldAttribute">IntegerFieldAttribute</see> of the property.
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function IntegerFieldValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim attrib As IntegerFieldAttribute = GetAttribute(Of IntegerFieldAttribute)(target.GetType, e.PropertyName)

        If attrib Is Nothing Then Return True

        Dim propName As String = GetResourcesPropertyName(target.GetType, e.PropertyName)

        Dim value As Integer = DirectCast(CallByName(target, e.PropertyName, CallType.Get), Integer)

        If attrib.ValueRequired <> ValueRequiredLevel.Optional AndAlso value = 0 Then

            e.Description = String.Format(My.Resources.Common_FieldValueNull, propName)
            If attrib.ValueRequired = ValueRequiredLevel.Mandatory Then
                e.Severity = RuleSeverity.Error
            Else
                e.Severity = RuleSeverity.Warning
            End If
            Return False

        End If

        If Not attrib.AllowNegative AndAlso value < 0 Then

            e.Description = String.Format(My.Resources.Common_IntegerCannotBeNegative, propName)
            e.Severity = RuleSeverity.Error
            Return False

        End If

        If attrib.WithinRange AndAlso (value < attrib.MinValue OrElse value > attrib.MaxValue) Then

            If value < attrib.MinValue Then
                e.Description = String.Format(My.Resources.Common_IntegerExceedsMinLimit, _
                    propName, attrib.MinValue.ToString)

            ElseIf value > attrib.MaxValue Then
                e.Description = String.Format(My.Resources.Common_IntegerExceedsMaxLimit, _
                    propName, attrib.MaxValue.ToString)

            End If

            If attrib.ErrorIfExceedsRange Then
                e.Severity = RuleSeverity.Error
            Else
                e.Severity = RuleSeverity.Warning
            End If

            Return False

        End If

        Return True

    End Function

#End Region

#Region " DoubleFieldValidation "

    ''' <summary>
    ''' Rule ensuring a <see cref="Double">Double</see> field value matches requirements 
    ''' set by <see cref="DoubleFieldAttribute">DoubleFieldAttribute</see> of the property.
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function DoubleFieldValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim attrib As DoubleFieldAttribute = GetAttribute(Of DoubleFieldAttribute)(target.GetType, e.PropertyName)

        If attrib Is Nothing Then Return True

        Dim propName As String = GetResourcesPropertyName(target.GetType, e.PropertyName)

        Dim value As Double = DirectCast(CallByName(target, e.PropertyName, CallType.Get), Double)

        If attrib.ValueRequired <> ValueRequiredLevel.Optional AndAlso CRound(value, attrib.Round) = 0 Then

            e.Description = String.Format(My.Resources.Common_FieldValueNull, propName)
            If attrib.ValueRequired = ValueRequiredLevel.Mandatory Then
                e.Severity = RuleSeverity.Error
            Else
                e.Severity = RuleSeverity.Warning
            End If
            Return False

        End If

        If Not attrib.AllowNegative AndAlso CRound(value, attrib.Round) < 0 Then

            e.Description = String.Format(My.Resources.Common_IntegerCannotBeNegative, propName)
            e.Severity = RuleSeverity.Error
            Return False

        End If

        If attrib.WithinRange AndAlso (CRound(value, attrib.Round) < attrib.MinValue _
            OrElse CRound(value, attrib.Round) > attrib.MaxValue) Then

            If CRound(value, attrib.Round) < attrib.MinValue Then
                e.Description = String.Format(My.Resources.Common_IntegerExceedsMinLimit, _
                    propName, attrib.MinValue.ToString)

            ElseIf CRound(value, attrib.Round) > attrib.MaxValue Then
                e.Description = String.Format(My.Resources.Common_IntegerExceedsMaxLimit, _
                    propName, attrib.MaxValue.ToString)

            End If

            If attrib.ErrorIfExceedsRange Then
                e.Severity = RuleSeverity.Error
            Else
                e.Severity = RuleSeverity.Warning
            End If

            Return False

        End If

        Return True

    End Function

#End Region

#Region " AccountFieldValidation "

    ''' <summary>
    ''' Rule ensuring a <see cref="General.Account.ID">Account ID</see> field value matches requirements 
    ''' set by <see cref="AccountFieldAttribute">AccountFieldAttribute</see> of the property.
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function AccountFieldValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim attrib As AccountFieldAttribute = GetAttribute(Of AccountFieldAttribute)(target.GetType, e.PropertyName)

        If attrib Is Nothing Then Return True

        Dim propName As String = GetResourcesPropertyName(target.GetType, e.PropertyName)

        Dim value As Long = DirectCast(CallByName(target, e.PropertyName, CallType.Get), Long)

        If value < 0 Then

            e.Description = String.Format(My.Resources.Common_AccountCannotBeNegative, propName)
            e.Severity = RuleSeverity.Error
            Return False

        End If

        If attrib.ValueRequired <> ValueRequiredLevel.Optional AndAlso Not value > 0 Then

            e.Description = String.Format(My.Resources.Common_FieldValueNull, propName)
            If attrib.ValueRequired = ValueRequiredLevel.Mandatory Then
                e.Severity = RuleSeverity.Error
            Else
                e.Severity = RuleSeverity.Warning
            End If
            Return False

        End If

        Dim accountPrefix As Integer = Convert.ToInt32(General.Account.GetAccountClass(value))

        If value > 0 AndAlso Array.IndexOf(attrib.AcceptedClasses, accountPrefix) < 0 Then

            e.Description = String.Format(My.Resources.Common_AccountClassInvalid, _
                accountPrefix.ToString, attrib.GetAcceptedClassesString, propName)

            If attrib.ErrorOnClassMismatch Then
                e.Severity = RuleSeverity.Error
            Else
                e.Severity = RuleSeverity.Warning
            End If

            Return False

        End If

        Return True

    End Function

#End Region

#Region " FutureDateValidation "

    ''' <summary>
    ''' Rule ensuring a date is not a future date (accepts SimpleRuleArgs).
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function FutureDateValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim value As Date = Convert.ToDateTime(CallByName(target, e.PropertyName, CallType.Get))
        Dim propName As String = GetResourcesPropertyName(target.GetType, e.PropertyName)

        If value <> Date.MinValue AndAlso value <> Date.MaxValue AndAlso value.Date > Today.Date Then
            e.Description = String.Format(My.Resources.ValidationRules_FutureDate, propName)
            e.Severity = RuleSeverity.Warning
            Return False
        End If

        Return True

    End Function

#End Region

#Region " ValueObjectFieldValidation "

    ''' <summary>
    ''' Rule ensuring that a <see cref="HelperLists">value object</see> field value is not null or empty.
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate (ExtendedRuleArgs)</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function ValueObjectFieldValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim propName As String = GetResourcesPropertyName(target.GetType, e.PropertyName)

        Dim value As Object = CallByName(target, e.PropertyName, CallType.Get)

        If value Is Nothing Then

            e.Description = String.Format(My.Resources.Common_FieldValueNull, propName)
            e.Severity = DirectCast(e, ExtendedRuleArgs).ApplySeverity
            Return False

        End If

        Try
            If CType(value, IValueObjectIsEmpty).IsEmpty Then

                e.Description = String.Format(My.Resources.Common_FieldValueNull, propName)
                e.Severity = DirectCast(e, ExtendedRuleArgs).ApplySeverity
                Return False

            End If
        Catch ex As Exception
        End Try

        Return True

    End Function

#End Region

#Region " LanguageCodeFieldValidation "

    ''' <summary>
    ''' Rule ensuring a valid language code is entered (accepts ExtendedRuleArgs).
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate (ExtendedRuleArgs OR RuleArgs)</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function LanguageCodeValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim value As String = Convert.ToString(CallByName(target, e.PropertyName, CallType.Get))

        Dim severity As RuleSeverity = RuleSeverity.Error
        Try
            severity = DirectCast(e, ExtendedRuleArgs).ApplySeverity
        Catch ex As Exception
        End Try

        If StringIsNullOrEmpty(value) AndAlso severity <> RuleSeverity.Information Then
            e.Description = My.Resources.Common_LanguageCodeNull
            e.Severity = severity
            Return False
        End If

        If Not IsLanguageCodeValid(value) Then
            e.Description = String.Format(My.Resources.Common_LanguageCodeInvalid, value.Trim)
            e.Severity = RuleSeverity.Error
            Return False
        Else

        End If

        Return True

    End Function

#End Region

#Region " LanguageNameFieldValidation "

    ''' <summary>
    ''' Rule ensuring a valid language name is entered (accepts ExtendedRuleArgs).
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate (ExtendedRuleArgs OR RuleArgs)</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function LanguageNameValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim value As String = Convert.ToString(CallByName(target, e.PropertyName, CallType.Get))

        Dim severity As RuleSeverity = RuleSeverity.Error
        Try
            severity = DirectCast(e, ExtendedRuleArgs).ApplySeverity
        Catch ex As Exception
        End Try

        If StringIsNullOrEmpty(value) AndAlso severity <> RuleSeverity.Information Then
            e.Description = My.Resources.Common_LanguageNameNull
            e.Severity = severity
            Return False
        End If

        Try
            If Not StringIsNullOrEmpty(value) Then GetLanguageCode(value, True)
        Catch ex As Exception
            e.Description = String.Format(My.Resources.Common_LanguageNameInvalid, value.Trim)
            e.Severity = RuleSeverity.Error
            Return False
        End Try

        Return True

    End Function

#End Region

#Region " CurrencyFieldValidation "

    ''' <summary>
    ''' Rule ensuring a valid currency code is entered (accepts ExtendedRuleArgs).
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate (RuleArgs OR ExtendedRuleArgs)</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function CurrencyFieldValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim value As String = Convert.ToString(CallByName(target, e.PropertyName, CallType.Get))

        If StringIsNullOrEmpty(value) Then
            e.Description = My.Resources.Common_CurrencyCodeNull
            Try
                e.Severity = DirectCast(e, ExtendedRuleArgs).ApplySeverity
            Catch ex As Exception
                e.Severity = RuleSeverity.Error
            End Try
            Return False
        End If

        If Array.IndexOf(CurrencyCodes, value.Trim.ToUpper) < 0 Then
            e.Description = String.Format(My.Resources.Common_CurrencyCodeInvalid, value.Trim)
            e.Severity = RuleSeverity.Error
            Return False
        Else

        End If

        Return True

    End Function

#End Region

#Region " ChronologyValidation "

    ''' <summary>
    ''' Rule ensuring that the chronology requirements are kept (requires ChronologyRuleArgs).
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate (ChronologyRuleArgs)</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function ChronologyValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim objectDate As Date = DirectCast((CallByName(target, DirectCast(e, ChronologyRuleArgs). _
            DatePropertyName, CallType.Get)), Date)

        Dim validationObject As IChronologicValidator = DirectCast((CallByName(target, _
            DirectCast(e, ChronologyRuleArgs).ValidatorPropertyName, CallType.Get)), IChronologicValidator)

        If validationObject Is Nothing Then Return True

        Return validationObject.ValidateOperationDate(objectDate, e.Description, e.Severity)

    End Function

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class ChronologyRuleArgs
        Inherits RuleArgs

        Private _DatePropertyName As String = ""
        ''' <summary>
        ''' Get the property name that is holding object date.
        ''' </summary>
        Public ReadOnly Property DatePropertyName() As String
            Get
                Return _DatePropertyName
            End Get
        End Property

        Private _ValidatorPropertyName As String = ""
        ''' <summary>
        ''' Get the property name that is holding IChronologicValidator.
        ''' </summary>
        Public ReadOnly Property ValidatorPropertyName() As String
            Get
                Return _ValidatorPropertyName
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="nDatePropertyName">The property name that is holding object date.</param>
        ''' <param name="nValidatorPropertyName">The property name that is holding IChronologicValidator.</param>
        Public Sub New(ByVal nDatePropertyName As String, ByVal nValidatorPropertyName As String)

            MyBase.New(nDatePropertyName)
            _DatePropertyName = nDatePropertyName
            _ValidatorPropertyName = nValidatorPropertyName

        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?DatePropertyName=" & _DatePropertyName _
                & "&ValidatorPropertyName=" & _ValidatorPropertyName
        End Function

    End Class

#End Region

#Region " StringValueUniqueInCollectionValidation "

    ''' <summary>
    ''' Rule ensuring a property's value is unique in collection.
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function StringValueUniqueInCollectionValidation(ByVal target As Object, _
        ByVal e As RuleArgs) As Boolean

        If Not TypeOf target Is Csla.Core.BusinessBase Then Return True

        Dim parent As ICollection
        Try
            Dim FI As PropertyInfo = target.GetType.GetProperty("Parent", _
                BindingFlags.NonPublic Or BindingFlags.Instance)
            parent = DirectCast(FI.GetValue(target, Nothing), ICollection)
        Catch ex As Exception
            Return True
        End Try

        If parent Is Nothing Then Return True

        Dim value As String = Convert.ToString(CallByName(target, e.PropertyName, CallType.Get))

        If StringIsNullOrEmpty(value) Then Return True

        Dim propName As String = GetResourcesPropertyName(target.GetType, e.PropertyName)

        For Each obj As Object In parent
            If Not Object.ReferenceEquals(obj, target) Then
                Dim secondValue As String = ""
                Try
                    secondValue = Convert.ToString(CallByName(obj, e.PropertyName, CallType.Get))
                Catch ex As Exception
                End Try
                If Not StringIsNullOrEmpty(secondValue) AndAlso secondValue.Trim.ToLower = value.Trim.ToLower Then
                    e.Description = String.Format(My.Resources.Common_StringValueNotUniqueInCollection, propName)
                    e.Severity = RuleSeverity.Error
                    Return False
                End If
            End If
        Next

        Return True

    End Function

#End Region


#Region " Obsolete methods "

#Region " LimitingFactor "

    ''' <summary>
    ''' Rule ensuring that the limiting factor property (boolean) is false.
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function LimitingFactor(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim LimitingFactorPresent As Boolean = _
          CBool(CallByName(target, DirectCast(e, LimitingFactorRuleArgs).FactorPropertyName, CallType.Get))

        If LimitingFactorPresent Then
            e.Description = DirectCast(e, LimitingFactorRuleArgs).FactorDescription
            e.Severity = DirectCast(e, LimitingFactorRuleArgs).ApplySeverity
            Return False
        Else
            Return True
        End If

    End Function

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class LimitingFactorRuleArgs
        Inherits RuleArgs

        Private _FactorDescription As String = ""
        ''' <summary>
        ''' Get the description of the limiting factor.
        ''' </summary>
        Public ReadOnly Property FactorDescription() As String
            Get
                Return _FactorDescription
            End Get
        End Property

        Private _FactorPropertyName As String = ""
        ''' <summary>
        ''' Get the name of the property of the limiting factor (boolean property only).
        ''' </summary>
        Public ReadOnly Property FactorPropertyName() As String
            Get
                Return _FactorPropertyName
            End Get
        End Property

        Private _ApplySeverity As RuleSeverity = RuleSeverity.Error
        ''' <summary>
        ''' Severity to apply to the rule.
        ''' </summary>
        Public ReadOnly Property ApplySeverity() As RuleSeverity
            Get
                Return _ApplySeverity
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="propertyName">Name of the property to validate.</param>
        ''' <param name="nFactorDescription">Human readable description of the limiting factor.</param>
        ''' <param name="nFactorPropertyName">Name of the boolean property that indicates limiting factor.</param>
        ''' <param name="SeverityToApply">Severity of the error to apply.</param>
        Public Sub New(ByVal propertyName As String, ByVal nFactorDescription As String, _
            ByVal nFactorPropertyName As String, Optional ByVal SeverityToApply As RuleSeverity = RuleSeverity.Error)
            MyBase.New(propertyName)
            _FactorDescription = nFactorDescription
            _FactorPropertyName = nFactorPropertyName
            _ApplySeverity = SeverityToApply
        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?FactorDescription=" & _FactorDescription & _
                "&FactorPropertyName=" & _FactorPropertyName & _
                "&ApplySeverity=" & _ApplySeverity.ToString
        End Function

    End Class

#End Region

    ''' <summary>
    ''' Rule ensuring a non empty string is present (accepts SimpleRuleArgs).
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function StringRequired(ByVal target As Object, _
      ByVal e As RuleArgs) As Boolean

        Dim Args As SimpleRuleArgs = DirectCast(e, SimpleRuleArgs)

        Dim value As String = Convert.ToString(CallByName(target, e.PropertyName, CallType.Get))

        If value Is Nothing OrElse String.IsNullOrEmpty(value.Trim) Then
            e.Description = "Nenurodyta " & Args.HumanReadableName & "."
            e.Severity = Args.ApplySeverity
            Return False
        Else
            Return True
        End If

    End Function

    ''' <summary>
    ''' Rule ensuring a string lenght does not exceed <see cref="StringMaxLengthRuleArgs.MaxLength" />.
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter of type <see cref="StringMaxLengthRuleArgs" />.</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function StringMaxLength(ByVal target As Object, _
        ByVal e As RuleArgs) As Boolean

        Dim Args As StringMaxLengthRuleArgs = DirectCast(e, StringMaxLengthRuleArgs)

        Dim value As String = Convert.ToString(CallByName(target, e.PropertyName, CallType.Get))

        If Not value Is Nothing AndAlso Not String.IsNullOrEmpty(value.Trim) _
            AndAlso value.Trim.Length > Args.MaxLength Then
            e.Description = String.Format("Maksimalus leistinas teksto ilgis laukelyje '{0}' yra {1} simboliai. Šį ilgį viršijanti teksto dalis nebus išsaugota.", Args.HumanReadableName, Args.MaxLength.ToString)
            e.Severity = Args.ApplySeverity
            Return False
        Else
            Return True
        End If

    End Function

    ''' <summary>
    ''' Rule ensuring a number is bigger then zero (accepts SimpleRuleArgs).
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function PositiveNumberRequired(ByVal target As Object, _
      ByVal e As Validation.RuleArgs) As Boolean

        Dim Args As SimpleRuleArgs = DirectCast(e, SimpleRuleArgs)

        Dim value As Double = Convert.ToDouble(CallByName(target, e.PropertyName, CallType.Get))

        If Not CRound(value, 4) > 0 Then
            e.Description = "Nenurodyta " & Args.HumanReadableName & "."
            e.Severity = Args.ApplySeverity
            Return False
        Else
            Return True
        End If

    End Function

    ''' <summary>
    ''' Rule ensuring a number is within given limits (accepts NumberBetweenRequiredRuleArgs).
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function NumberBetweenRequired(ByVal target As Object, _
      ByVal e As Validation.RuleArgs) As Boolean

        Dim Args As NumberBetweenRequiredRuleArgs = DirectCast(e, NumberBetweenRequiredRuleArgs)

        Dim value As Double = Convert.ToDouble(CallByName(target, e.PropertyName, CallType.Get))

        If CRound(value, Args.Approximation) < CRound(Args.MinValue, Args.Approximation) Then
            e.Description = Args.HumanReadableName & " negali būti mažesnė kaip " & _
                CRound(Args.MinValue, Args.Approximation).ToString & "."
            e.Severity = Args.ApplySeverity
            Return False
        ElseIf CRound(value, Args.Approximation) > CRound(Args.MaxValue, Args.Approximation) Then
            e.Description = Args.HumanReadableName & " negali būti didesnė kaip " & _
                CRound(Args.MaxValue, Args.Approximation).ToString & "."
            e.Severity = Args.ApplySeverity
            Return False
        End If

        Return True

    End Function

    ''' <summary>
    ''' Rule ensuring an info object (e.g. ClientInfo) is provided (accepts InfoObjectRequiredRuleArgs).
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function InfoObjectRequired(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim Args As InfoObjectRequiredRuleArgs = DirectCast(e, InfoObjectRequiredRuleArgs)

        Dim value As Object = CallByName(target, e.PropertyName, CallType.Get)

        If value Is Nothing OrElse (Not Args.IdPropertyName Is Nothing _
            AndAlso Not String.IsNullOrEmpty(Args.IdPropertyName.Trim) AndAlso _
            DirectCast(CallByName(value, Args.IdPropertyName, CallType.Get), Integer) < 1) Then
            e.Description = "Nenurodyta " & Args.HumanReadableName & "."
            e.Severity = Args.ApplySeverity
            Return False
        Else
            Return True
        End If

    End Function

    ''' <summary>
    ''' Rule ensuring the value in alt language is provided when reference 
    ''' property's value contains foreign language code (or reference property
    ''' holds object that has LanguageCode property) (accepts ReferencePropertyRuleArgs).
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function AltLanguageValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

        Dim value As String = DirectCast(CallByName(target, e.PropertyName, CallType.Get), String)
        If Not value Is Nothing AndAlso Not String.IsNullOrEmpty(value.Trim) Then Return True

        Dim Args As ReferencePropertyRuleArgs = DirectCast(e, ReferencePropertyRuleArgs)
        Dim ReferenceObject As Object = CallByName(target, Args.ReferencePropertyName, CallType.Get)

        If ReferenceObject Is Nothing Then Return True

        Dim ForeignLanguageSet As Boolean = False
        Dim LC As String = ""

        If TypeOf ReferenceObject Is String Then

            LC = DirectCast(ReferenceObject, String).Trim
            ForeignLanguageSet = (Not String.IsNullOrEmpty(LC) _
                AndAlso LC.Trim.ToUpper <> LanguageCodeLith.Trim.ToUpper)

        Else

            Try
                LC = DirectCast(CallByName(ReferenceObject, "LanguageCode", CallType.Get), String)
                ForeignLanguageSet = (Not LC Is Nothing AndAlso Not String.IsNullOrEmpty(LC.Trim) _
                    AndAlso LC.Trim.ToUpper <> LanguageCodeLith.Trim.ToUpper)
            Catch ex As Exception
            End Try

        End If

        If ForeignLanguageSet AndAlso (value Is Nothing OrElse String.IsNullOrEmpty(value.Trim)) Then

            e.Description = "Nenurodyta " & Args.HumanReadableName & _
                " kliento kalba (" & GetLanguageName(LC, False) & ")."
            e.Severity = RuleSeverity.Error
            Return False

        End If

        Return True

    End Function

#Region " RuleArgs "

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class SimpleRuleArgs
        Inherits RuleArgs

        Private _HumanReadableName As String = ""
        ''' <summary>
        ''' Get the human readable property name.
        ''' </summary>
        Public ReadOnly Property HumanReadableName() As String
            Get
                Return _HumanReadableName
            End Get
        End Property

        Private _ApplySeverity As RuleSeverity = RuleSeverity.Error
        ''' <summary>
        ''' Severity to apply to the rule.
        ''' </summary>
        Public ReadOnly Property ApplySeverity() As RuleSeverity
            Get
                Return _ApplySeverity
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="propertyName">Name of the property to validate.</param>
        ''' <param name="HumanReadable">Human readable name of the property.</param>
        ''' <param name="SeverityToApply">Severity of the error to apply.</param>
        Public Sub New(ByVal propertyName As String, ByVal HumanReadable As String, _
            Optional ByVal SeverityToApply As RuleSeverity = RuleSeverity.Error)
            MyBase.New(propertyName)
            _HumanReadableName = HumanReadable
            _ApplySeverity = SeverityToApply
        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?HumanReadableName=" & _HumanReadableName & _
                "&ApplySeverity=" & _ApplySeverity.ToString
        End Function

    End Class

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class StringMaxLengthRuleArgs
        Inherits RuleArgs

        Private _MaxLength As Integer = 255
        ''' <summary>
        ''' Get the max allowed string length.
        ''' </summary>
        Public ReadOnly Property MaxLength() As Integer
            Get
                Return _MaxLength
            End Get
        End Property

        Private _HumanReadableName As String = ""
        ''' <summary>
        ''' Get the human readable property name.
        ''' </summary>
        Public ReadOnly Property HumanReadableName() As String
            Get
                Return _HumanReadableName
            End Get
        End Property

        Private _ApplySeverity As RuleSeverity = RuleSeverity.Error
        ''' <summary>
        ''' Severity to apply to the rule.
        ''' </summary>
        Public ReadOnly Property ApplySeverity() As RuleSeverity
            Get
                Return _ApplySeverity
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="propertyName">Name of the property to validate.</param>
        ''' <param name="maxAllowedLength">Max allowed string value length.</param>
        ''' <param name="HumanReadable">Human readable name of the property.</param>
        ''' <param name="SeverityToApply">Severity of the error to apply.</param>
        Public Sub New(ByVal propertyName As String, ByVal maxAllowedLength As Integer, _
            ByVal HumanReadable As String, Optional ByVal SeverityToApply As RuleSeverity = RuleSeverity.Error)
            MyBase.New(propertyName)
            _MaxLength = maxAllowedLength
            _HumanReadableName = HumanReadable
            _ApplySeverity = SeverityToApply
        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?MaxLength" & _MaxLength.ToString & "&HumanReadableName=" _
                & _HumanReadableName & "&ApplySeverity=" & _ApplySeverity.ToString
        End Function

    End Class

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class NumberBetweenRequiredRuleArgs
        Inherits RuleArgs

        Private _HumanReadableName As String = ""
        ''' <summary>
        ''' Get the human readable property name.
        ''' </summary>
        Public ReadOnly Property HumanReadableName() As String
            Get
                Return _HumanReadableName
            End Get
        End Property

        Private _ApplySeverity As RuleSeverity = RuleSeverity.Error
        ''' <summary>
        ''' Severity to apply to the rule.
        ''' </summary>
        Public ReadOnly Property ApplySeverity() As RuleSeverity
            Get
                Return _ApplySeverity
            End Get
        End Property

        Private _MinValue As Double = 0
        ''' <summary>
        ''' Get the minimal allowed value of the property.
        ''' </summary>
        Public ReadOnly Property MinValue() As Double
            Get
                Return _MinValue
            End Get
        End Property

        Private _MaxValue As Double = 0
        ''' <summary>
        ''' Get the maximal allowed value of the property.
        ''' </summary>
        Public ReadOnly Property MaxValue() As Double
            Get
                Return _MaxValue
            End Get
        End Property

        Private _Approximation As Integer = 2
        Public ReadOnly Property Approximation() As Integer
            Get
                Return _Approximation
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="propertyName">Name of the property to validate.</param>
        ''' <param name="HumanReadable">Human readable name of the property.</param>
        ''' <param name="SeverityToApply">Severity of the error to apply.</param>
        Public Sub New(ByVal propertyName As String, ByVal HumanReadable As String, _
            ByVal cMinValue As Double, ByVal cMaxValue As Double, _
            Optional ByVal nApproximation As Integer = 2, _
            Optional ByVal SeverityToApply As RuleSeverity = RuleSeverity.Error)
            MyBase.New(propertyName)
            _HumanReadableName = HumanReadable
            _ApplySeverity = SeverityToApply
            _MinValue = cMinValue
            _MaxValue = cMaxValue
            _Approximation = nApproximation
        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?HumanReadableName=" & _HumanReadableName & _
                "&ApplySeverity=" & _ApplySeverity.ToString & _
                "&MinValue=" & _MinValue.ToString & _
                "&MaxValue=" & _MaxValue.ToString & _
                "&Approximation=" & _Approximation.ToString
        End Function

    End Class

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class InfoObjectRequiredRuleArgs
        Inherits RuleArgs

        Private _HumanReadableName As String = ""
        ''' <summary>
        ''' Get the human readable property name.
        ''' </summary>
        Public ReadOnly Property HumanReadableName() As String
            Get
                Return _HumanReadableName
            End Get
        End Property

        Private _IdPropertyName As String = ""
        ''' <summary>
        ''' Get the property name that is used to check if non null info object 
        ''' is not empty object, i.e. ID=0.
        ''' </summary>
        Public ReadOnly Property IdPropertyName() As String
            Get
                Return _IdPropertyName
            End Get
        End Property

        Private _ApplySeverity As RuleSeverity = RuleSeverity.Error
        ''' <summary>
        ''' Severity to apply to the rule.
        ''' </summary>
        Public ReadOnly Property ApplySeverity() As RuleSeverity
            Get
                Return _ApplySeverity
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="propertyName">Name of the property to validate.</param>
        ''' <param name="SeverityToApply">Severity of the error to apply.</param>
        Public Sub New(ByVal propertyName As String, ByVal nHumanReadableName As String, _
            ByVal nIdPropertyName As String, Optional ByVal SeverityToApply As RuleSeverity = RuleSeverity.Error)

            MyBase.New(propertyName)
            _HumanReadableName = nHumanReadableName
            _ApplySeverity = SeverityToApply
            _IdPropertyName = nIdPropertyName

        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?HumanReadableName=" & _HumanReadableName _
                & "&ApplySeverity=" & _ApplySeverity.ToString _
                & "&IdPropertyName=" & _IdPropertyName
        End Function

    End Class

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class ReferencePropertyRuleArgs
        Inherits RuleArgs

        Private _HumanReadableName As String = ""
        ''' <summary>
        ''' Get the human readable property name.
        ''' </summary>
        Public ReadOnly Property HumanReadableName() As String
            Get
                Return _HumanReadableName
            End Get
        End Property

        Private _IdPropertyName As String = ""
        ''' <summary>
        ''' Get the property name that is used to check if non null info object 
        ''' is not empty object, i.e. ID=0.
        ''' </summary>
        Public ReadOnly Property IdPropertyName() As String
            Get
                Return _IdPropertyName
            End Get
        End Property

        Private _ApplySeverity As RuleSeverity = RuleSeverity.Error
        ''' <summary>
        ''' Severity to apply to the rule.
        ''' </summary>
        Public ReadOnly Property ApplySeverity() As RuleSeverity
            Get
                Return _ApplySeverity
            End Get
        End Property

        Private _ReferencePropertyName As String = ""
        Public ReadOnly Property ReferencePropertyName() As String
            Get
                Return _ReferencePropertyName
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="propertyName">Name of the property to validate.</param>
        ''' <param name="SeverityToApply">Severity of the error to apply.</param>
        Public Sub New(ByVal propertyName As String, ByVal nHumanReadableName As String, _
            ByVal nReferencePropertyName As String, ByVal nIdPropertyName As String, _
            Optional ByVal SeverityToApply As RuleSeverity = RuleSeverity.Error)

            MyBase.New(propertyName)
            _HumanReadableName = nHumanReadableName
            _ApplySeverity = SeverityToApply
            _IdPropertyName = nIdPropertyName
            _ReferencePropertyName = nReferencePropertyName

        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?HumanReadableName=" & _HumanReadableName _
                & "&ApplySeverity=" & _ApplySeverity.ToString _
                & "&IdPropertyName=" & _IdPropertyName _
                & "&ReferencePropertyName=" & _ReferencePropertyName
        End Function

    End Class

#End Region

#End Region


    Private Function GetAttribute(Of T As Attribute)(ByVal targetType As Type, ByVal propertyName As String) As T

        Dim propInfo As PropertyInfo = targetType.GetProperty(propertyName)

        If propInfo Is Nothing Then Return Nothing

        For Each attr As Attribute In Attribute.GetCustomAttributes(propInfo)
            If TypeOf attr Is T Then
                Return CType(attr, T)
            End If
        Next

        Return Nothing

    End Function

    Private Function GetResourcesPropertyName(ByVal targetType As Type, ByVal propertyName As String) As String

        Dim resourceName As String = targetType.FullName.Substring(targetType.FullName.IndexOf(".") + 1) _
            .Replace(".", "_") & "_" & propertyName

        Dim result As String = My.Resources.ResourceManager.GetString(resourceName)

        If String.IsNullOrEmpty(result) Then
            result = propertyName
        End If

        Return result

    End Function

End Module
