Namespace General

    <Serializable()> _
    Public Class BookEntryList
        Inherits BusinessListBase(Of BookEntryList, BookEntry)

#Region " Business Methods "

        Private _Type As BookEntryType = BookEntryType.Debetas
        Private _FinancialDataCanChange As Boolean = True
        Private _FinancialDataCanChangeExplanation As String = ""


        Public ReadOnly Property [Type]() As BookEntryType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
        End Property

        Friend ReadOnly Property FinancialDataCanChange() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        Friend ReadOnly Property FinancialDataCanChangeExplanation() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChangeExplanation
            End Get
        End Property


        Protected Overrides Function AddNewCore() As Object
            If Not _FinancialDataCanChange Then Throw New Exception("Klaida. Finansinių bendrojo " _
                & "žurnalo operacijos duomenų keisti neleidžiama (įskaitant eilučių pridėjimą ar pašalinimą): " _
                & _FinancialDataCanChangeExplanation)
            Dim NewItem As BookEntry = BookEntry.NewBookEntry
            Me.Add(NewItem)
            Return NewItem
        End Function


        Public Function GetAllBrokenRules() As String
            Dim result As String = GetAllBrokenRulesForList(Me)

            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = GetAllWarningsForList(Me)
            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        ''' <summary>
        ''' Gets a sum of all the BookEntry items' ammounts in the list.
        ''' </summary>
        Public Function GetSum() As Double
            Dim result As Double = 0
            For Each b As BookEntry In Me
                result = result + CRound(b.Amount)
            Next
            Return CRound(result)
        End Function

        ''' <summary>
        ''' Gets a sum of the BookEntry items' ammounts within certain account.
        ''' </summary>
        Public Function GetSumInAccount(ByVal nAccount As Long) As Double
            Dim result As Double = 0
            For Each b As BookEntry In Me
                If b.Account = nAccount Then result = result + CRound(b.Amount)
            Next
            Return CRound(result)
        End Function

        ''' <summary>
        ''' Aggregates book entries by Account and PersonInfo, 
        ''' i.e. entries with the same Account and PersonInfo are replaced by one entry with total ammount
        ''' </summary>
        Public Sub OptimizeEntries(ByVal RaiseResetBindings As Boolean)

            If Not _FinancialDataCanChange Then Throw New Exception("Klaida. Finansinių bendrojo " _
                & "žurnalo operacijos duomenų keisti neleidžiama (įskaitant eilučių pridėjimą ar pašalinimą): " _
                & _FinancialDataCanChangeExplanation)

            Me.RaiseListChangedEvents = False

            For i As Integer = Me.Count To 2 Step -1
                For j As Integer = 1 To i - 1
                    If Me.Item(i - 1).Account = Me.Item(j - 1).Account AndAlso _
                        Me.Item(i - 1).Person = Me.Item(j - 1).Person Then
                        Me.Item(j - 1).Amount = CRound(Me.Item(j - 1).Amount + Me.Item(i - 1).Amount)
                        Me.RemoveAt(i - 1)
                        Exit For
                    End If
                Next
            Next

            Me.RaiseListChangedEvents = True

            If RaiseResetBindings Then Me.ResetBindings()

        End Sub

        Friend Sub LoadBookEntryListFromTemplate(ByVal AccountList As String, _
            ByVal RaiseResetBindings As Boolean)

            If Not _FinancialDataCanChange Then Throw New Exception("Klaida. Finansinių bendrojo " _
                & "žurnalo operacijos duomenų keisti neleidžiama (įskaitant eilučių pridėjimą ar pašalinimą): " _
                & _FinancialDataCanChangeExplanation)

            RaiseListChangedEvents = False

            For i As Integer = Me.Count To 1 Step -1
                Me.RemoveAt(i - 1)
            Next

            For Each s As String In AccountList.Split(New Char() {","}, StringSplitOptions.RemoveEmptyEntries)
                Dim NewItem As BookEntry = BookEntry.NewBookEntry()
                NewItem.Account = CLongSafe(s)
                Add(NewItem)
            Next

            RaiseListChangedEvents = True

            If RaiseResetBindings Then Me.ResetBindings()

        End Sub

        Friend Sub LoadBookEntryListFromInternalList(ByRef InternalEntryList As BookEntryInternalList, _
            ByVal nOptimizeEntries As Boolean)

            If Not _FinancialDataCanChange Then Throw New Exception("Klaida. Finansinių bendrojo " _
                & "žurnalo operacijos duomenų keisti neleidžiama (įskaitant eilučių pridėjimą ar pašalinimą): " _
                & _FinancialDataCanChangeExplanation)

            RaiseListChangedEvents = False

            For i As Integer = Me.Count To 1 Step -1
                Me.RemoveAt(i - 1)
            Next

            For Each i As BookEntryInternal In InternalEntryList
                If i.EntryType = _Type Then Add(BookEntry.NewBookEntry(i))
            Next

            If nOptimizeEntries Then
                OptimizeEntries(True)
            Else
                RaiseListChangedEvents = True
                Me.ResetBindings()
            End If

        End Sub

        Friend Function GetEntryListString() As String
            If Me.Count < 1 Then Return ""
            Dim result As String = IIf(_Type = BookEntryType.Debetas, "D", "K") _
                & Me.Item(0).Account.ToString
            For i As Integer = 2 To Me.Count
                result = result & ", " & IIf(_Type = BookEntryType.Debetas, "D", "K") _
                    & Me.Item(i - 1).Account.ToString
            Next
            Return result
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function NewBookEntryList(ByVal EntryType As BookEntryType) As BookEntryList
            Dim result As BookEntryList = New BookEntryList
            result._Type = EntryType
            Return result
        End Function

        Friend Shared Function GetBookEntryList(ByVal myData As DataTable, _
            ByVal EntryType As BookEntryType, ByVal nFinancialDataCanChange As Boolean, _
            ByVal nFinancialDataCanChangeExplanation As String, _
            ByVal ParamArray AccountsToSkip As Long()) As BookEntryList
            Return New BookEntryList(myData, EntryType, nFinancialDataCanChange, _
                nFinancialDataCanChangeExplanation, AccountsToSkip)
        End Function

        ''' <summary>
        ''' Only for object TransferOfBalance.
        ''' </summary>
        ''' <remarks>Only for object TransferOfBalance.</remarks>
        Friend Shared Function GetBookEntryList(ByVal nBookEntryInternalList As BookEntryInternalList, _
            ByVal EntryType As BookEntryType, ByVal MarkItemsAsOld As Boolean, _
            ByVal nFinancialDataCanChange As Boolean, ByVal nFinancialDataCanChangeExplanation As String, _
            ByVal ParamArray AccountsToSkip As Long()) As BookEntryList
            Return New BookEntryList(nBookEntryInternalList, EntryType, MarkItemsAsOld, _
                nFinancialDataCanChange, nFinancialDataCanChangeExplanation, AccountsToSkip)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
        End Sub


        Private Sub New(ByVal myData As DataTable, ByVal EntryType As BookEntryType, _
            ByVal nFinancialDataCanChange As Boolean, ByVal nFinancialDataCanChangeExplanation As String, _
            ByVal AccountsToSkip As Long())
            ' require use of factory methods
            MarkAsChild()
            Fetch(myData, EntryType, nFinancialDataCanChange, nFinancialDataCanChangeExplanation, AccountsToSkip)
            Me.AllowEdit = nFinancialDataCanChange
            Me.AllowNew = nFinancialDataCanChange
            Me.AllowRemove = nFinancialDataCanChange
        End Sub

        Private Sub New(ByVal nBookEntryInternalList As BookEntryInternalList, _
            ByVal EntryType As BookEntryType, ByVal MarkItemsAsOld As Boolean, _
            ByVal nFinancialDataCanChange As Boolean, ByVal nFinancialDataCanChangeExplanation As String, _
            ByVal AccountsToSkip As Long())
            ' require use of factory methods
            MarkAsChild()
            Fetch(nBookEntryInternalList, EntryType, MarkItemsAsOld, nFinancialDataCanChange, _
                nFinancialDataCanChangeExplanation, AccountsToSkip)
            Me.AllowEdit = nFinancialDataCanChange
            Me.AllowNew = nFinancialDataCanChange
            Me.AllowRemove = nFinancialDataCanChange
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal myData As DataTable, ByVal EntryType As BookEntryType, _
            ByVal nFinancialDataCanChange As Boolean, ByVal nFinancialDataCanChangeExplanation As String, _
            ByVal AccountsToSkip As Long())

            RaiseListChangedEvents = False

            _FinancialDataCanChange = nFinancialDataCanChange
            _FinancialDataCanChangeExplanation = nFinancialDataCanChangeExplanation

            _Type = EntryType

            For Each dr As DataRow In myData.Rows
                If ConvertEnumDatabaseStringCode(Of BookEntryType)(CStrSafe(dr.Item(1))) = EntryType _
                    AndAlso (AccountsToSkip Is Nothing OrElse AccountsToSkip.Length < 1 OrElse _
                    Array.IndexOf(AccountsToSkip, CLongSafe(dr.Item(2), 0)) < 0) Then _
                    Add(BookEntry.GetBookEntry(dr, nFinancialDataCanChange))
            Next

            RaiseListChangedEvents = True

        End Sub

        Private Sub Fetch(ByVal nBookEntryInternalList As BookEntryInternalList, _
            ByVal EntryType As BookEntryType, ByVal MarkItemsAsOld As Boolean, _
            ByVal nFinancialDataCanChange As Boolean, ByVal nFinancialDataCanChangeExplanation As String, _
            ByVal AccountsToSkip As Long())

            RaiseListChangedEvents = False

            _FinancialDataCanChange = nFinancialDataCanChange
            _FinancialDataCanChangeExplanation = nFinancialDataCanChangeExplanation

            _Type = EntryType

            For Each i As BookEntryInternal In nBookEntryInternalList
                If i.EntryType = EntryType AndAlso (AccountsToSkip Is Nothing OrElse _
                    AccountsToSkip.Length < 1 OrElse Array.IndexOf(AccountsToSkip, i.Account) < 0) Then _
                        Add(BookEntry.GetBookEntry(i, MarkItemsAsOld))
            Next

            RaiseListChangedEvents = True

        End Sub

        Friend Sub Update(ByVal parent As JournalEntry)

            RaiseListChangedEvents = False

            If parent.ChronologyValidator.FinancialDataCanChange Then
                For Each item As BookEntry In DeletedList
                    If Not item.IsNew Then item.DeleteSelf()
                Next
            End If
            DeletedList.Clear()

            For Each item As BookEntry In Me
                If item.IsNew AndAlso parent.ChronologyValidator.FinancialDataCanChange Then
                    item.Insert(Me, parent)
                ElseIf Not item.IsNew AndAlso item.IsDirty Then
                    item.Update(Me, parent)
                End If
            Next

            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace