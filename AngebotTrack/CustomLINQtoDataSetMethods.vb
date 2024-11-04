﻿Imports System.Runtime.CompilerServices


Public Module CustomLINQtoDataSetMethods
  <Extension()>
  Public Function CopyToDataTable(Of T)(ByVal source As IEnumerable(Of T)) As DataTable
    Return New ObjectShredder(Of T)().Shred(source, Nothing, Nothing)
  End Function

  <Extension()>
  Public Function CopyToDataTable(Of T)(ByVal source As IEnumerable(Of T), ByVal table As DataTable, ByVal options As LoadOption?) As DataTable
    Return New ObjectShredder(Of T)().Shred(source, table, options)
  End Function

End Module
