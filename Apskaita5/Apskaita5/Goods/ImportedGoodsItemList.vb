Namespace Goods

    <Serializable()> _
    Public Class ImportedGoodsItemList
        Inherits BusinessListBase(Of ImportedGoodsItemList, ImportedGoodsItem)

#Region " Business Methods "

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

        Public Overrides Function Save() As ImportedGoodsItemList

            If Not Me.Count > 0 Then Throw New Exception("Klaida. Neįkrauta nė viena eilutė.")

            If Not Me.IsValid Then Throw New Exception("Importuojamuose duomenyse yra klaidų: " _
                & GetAllBrokenRules())

            Dim result As ImportedGoodsItemList = MyBase.Save()
            HelperLists.GoodsInfoList.InvalidateCache()
            Return result

        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.Goods2")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of ImportedGoodsItem) = Nothing

        Public Shared Function GetImportedGoodsItemList(ByVal Source As String) As ImportedGoodsItemList
            Return DataPortal.Fetch(Of ImportedGoodsItemList)(New Criteria( _
                Source, vbCrLf, vbTab, "", ""))
        End Function

        Public Function GetSortedList() As Csla.SortedBindingList(Of ImportedGoodsItem)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of ImportedGoodsItem)(Me)
            Return _SortedList
        End Function


        Private Sub New()
            ' require use of factory methods
            Me.AllowEdit = False
            Me.AllowNew = False
            Me.AllowRemove = True
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _Source As String
            Private _LineDelimiter As String
            Private _ColumnDelimiter As String
            Private _ColumnWrapper As String
            Private _EscapeString As String
            Public ReadOnly Property Source() As String
                Get
                    Return _Source
                End Get
            End Property
            Public ReadOnly Property LineDelimiter() As String
                Get
                    Return _LineDelimiter
                End Get
            End Property
            Public ReadOnly Property ColumnDelimiter() As String
                Get
                    Return _ColumnDelimiter
                End Get
            End Property
            Public ReadOnly Property ColumnWrapper() As String
                Get
                    Return _ColumnWrapper
                End Get
            End Property
            Public ReadOnly Property EscapeString() As String
                Get
                    Return _EscapeString
                End Get
            End Property
            Public Sub New(ByVal nSource As String, ByVal nLineDelimiter As String, _
                ByVal nColumnDelimiter As String, ByVal nColumnWrapper As String, _
                ByVal nEscapeString As String)
                _Source = nSource
                _LineDelimiter = nLineDelimiter
                _ColumnDelimiter = nColumnDelimiter
                _ColumnWrapper = nColumnWrapper
                _EscapeString = nEscapeString
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai operacijai.")

            If criteria.Source Is Nothing OrElse String.IsNullOrEmpty(criteria.Source.Trim) Then _
                Throw New Exception("Klaida. Nenurodytas importos šaltinis (gautas tuščias tekstas).")
            If criteria.LineDelimiter Is Nothing OrElse String.IsNullOrEmpty(criteria.LineDelimiter) Then _
                Throw New Exception("Klaida. Nenurodytas eilučių skirtukas.")
            If criteria.ColumnDelimiter Is Nothing OrElse String.IsNullOrEmpty(criteria.ColumnDelimiter) Then _
                Throw New Exception("Klaida. Nenurodytas stulpelių skirtukas.")

            Dim lineDelimiter As String = criteria.LineDelimiter
            If lineDelimiter <> vbCrLf AndAlso lineDelimiter <> vbCr AndAlso lineDelimiter <> vbLf Then
                lineDelimiter = lineDelimiter.Trim.ToUpper
                lineDelimiter = lineDelimiter.Replace("\R\N", vbCrLf)
                lineDelimiter = lineDelimiter.Replace("\R", vbCr)
                lineDelimiter = lineDelimiter.Replace("\N", vbLf)
            End If

            Dim columnDelimiter As String = criteria.ColumnDelimiter
            If columnDelimiter <> vbTab Then
                columnDelimiter = columnDelimiter.Trim.ToUpper
                columnDelimiter = columnDelimiter.Replace("\T", vbTab)
            End If

            Dim goodsInDatabase As List(Of String)
            Dim myComm As New SQLCommand("FetchGoodsNameGroupList")
            Using myData As DataTable = myComm.Fetch
                goodsInDatabase = New List(Of String)
                For Each dr As DataRow In myData.Rows
                    goodsInDatabase.Add(CStrSafe(dr.Item(0)).Trim.ToUpper & CStrSafe(dr.Item(1)).Trim.ToUpper)
                Next
            End Using

            Dim groups As GoodsGroupInfoList = GoodsGroupInfoList.GetGoodsGroupInfoListOnServer

            Dim ail As AccountInfoList = AccountInfoList.GetListChild
            Dim accountList As New List(Of Long)
            For Each pi As AccountInfo In ail
                accountList.Add(pi.ID)
            Next

            Dim previousGoods As New List(Of String)

            RaiseListChangedEvents = True

            For Each s As String In criteria.Source.Split(New String() {lineDelimiter}, _
                StringSplitOptions.RemoveEmptyEntries)
                Add(ImportedGoodsItem.GetImportedGoodsItem(s.Split(New String() {columnDelimiter}, _
                    StringSplitOptions.None), groups, accountList, goodsInDatabase, previousGoods))
            Next

            RaiseListChangedEvents = False

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai operacijai.")

            Using transaction As New SqlTransaction

                Try

                    RaiseListChangedEvents = False

                    DeletedList.Clear()

                    For Each item As ImportedGoodsItem In Me
                        If item.IsValid Then item.Insert()
                    Next

                    Me.Clear()
                    DeletedList.Clear()

                    RaiseListChangedEvents = True

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

        End Sub

#End Region

    End Class

End Namespace