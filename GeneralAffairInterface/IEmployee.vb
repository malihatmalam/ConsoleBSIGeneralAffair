Imports BSIGeneralAffairBO

Public Interface IEmployee
    Function getAll() As List(Of Employee)

    Function create(employee As Employee) As Integer

End Interface
