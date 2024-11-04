Imports DevExpress.XtraGrid.Views.Base
Imports System.ComponentModel

Module FilteredDataSourceHelper
  Public Function GetFilteredDataSource(ByVal view As ColumnView) As Object
    If view Is Nothing Then
      Return Nothing
    End If
    If TypeOf view.DataSource Is DataView Then
      Return GetFilteredDataView(view)
    End If
    If TypeOf view.DataSource Is IBindingList Then
      Return GetFilteredBindingList(view)
    End If
    Return Nothing
  End Function

  Public Function GetFilteredDataView(ByVal view As ColumnView) As DataView
    If view Is Nothing Then
      Return Nothing
    End If
    If view.ActiveFilter Is Nothing OrElse (Not view.ActiveFilterEnabled) OrElse view.ActiveFilter.Expression = "" Then
      Return TryCast(view.DataSource, DataView)
    End If

    Dim table As DataTable = (CType(view.DataSource, DataView)).Table
    Dim filteredDataView As New DataView(table)
    filteredDataView.RowFilter = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(view.ActiveFilterCriteria)
    Return filteredDataView
  End Function

  Private Function GetFilteredBindingList(ByVal view As ColumnView) As IList
    If view Is Nothing Then
      Return Nothing
    End If
    Dim list As IList = TryCast(view.DataSource, IList)
    If view.ActiveFilter Is Nothing OrElse (Not view.ActiveFilterEnabled) OrElse view.ActiveFilter.Expression = "" OrElse list.Count = 0 Then
      Return list
    End If
    Dim result As New BindingList(Of Object)()
    For i As Integer = 0 To view.RowCount - 1
      result.Add(view.GetRow(i))
    Next i
    Return result
  End Function
End Module
