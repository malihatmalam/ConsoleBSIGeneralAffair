Imports BSIGeneralAffairBO

Public Class DepartmentModule
    Sub DepartmentDB()
        Dim DepartmentDAL As New BSIGeneralAffairDAL.DALDepartment

        Dim Departments = DepartmentDAL.getAll()
        For Each department As Departement In Departments
            Console.WriteLine(
                "{0} {1} {2} ",
                department.DepartementID,
                department.DepartementName,
                department.UpdatedAt
                )
        Next
    End Sub

    Sub DepartmentCreateDB()
        Dim departmentDAL As New BSIGeneralAffairDAL.DALDepartment
        Dim newDepartment As New Departement
        newDepartment.DepartementName = "Nokia"

        Try
            Dim result = departmentDAL.create(newDepartment)
            If result = 1 Then
                Console.WriteLine("Insert failed")
            Else
                Console.WriteLine("Insert success")
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Sub DepartmentUpdateDB()
        Dim departmentDAL As New BSIGeneralAffairDAL.DALDepartment
        Dim updateDepartment As New Departement
        updateDepartment.DepartementID = 15
        updateDepartment.DepartementName = "PT Bintang 11"

        Try
            Dim result = departmentDAL.update(updateDepartment)
            If result = 1 Then
                Console.WriteLine("Update failed")
            Else
                Console.WriteLine("Update success")
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Sub DepartmentDeleteDB()
        Dim departmentDAL As New BSIGeneralAffairDAL.DALDepartment
        Dim departmentID As Integer = 17
        Try
            Dim result = departmentDAL.delete(departmentID)
            If result = 1 Then
                Console.WriteLine("Delete failed")
            Else
                Console.WriteLine("Delete success")
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
End Class
