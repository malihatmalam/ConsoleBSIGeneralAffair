Public Interface IBaseCRUD(Of T)
    Function create(ByVal obj As T) As Integer
    Function getAll() As List(Of T)
    Function update(ByVal obj As T) As Integer
    Function delete(ByVal id As Integer) As Integer
End Interface
