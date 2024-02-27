Imports System.Data
Imports System.Data.SqlClient
Imports BSIGeneralAffairBO
Imports GeneralAffairInterface

Public Class DALDepartment
    Implements IDepartment

    Public database As DatabaseConfiguration = New DatabaseConfiguration()
    Private dataRead As SqlDataReader
    Public cmd As SqlCommand

    Public Function create(obj As Departement) As Integer Implements IBaseCRUD(Of Departement).create
        Try
            Dim strSP = "[HumanResource].[USP_StoreDepartement]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@DepartementName", obj.DepartementName)

            database.conn.Open()
            Dim result = cmd.ExecuteNonQuery()
            If result = 1 Then
                Throw New ArgumentException("Department not created")
            End If
            Return result
        Catch sqlex As SqlException
            Throw New ArgumentException(sqlex.Message & " " & sqlex.Number)
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            database.conn.Close()
        End Try
    End Function

    Public Function getAll() As List(Of Departement) Implements IBaseCRUD(Of Departement).getAll
        Dim Departments As New List(Of Departement)
        Try
            Dim strSP = "[HumanResource].[USP_SelectAllDepartement]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure
            database.conn.Open()
            dataRead = cmd.ExecuteReader()
            If dataRead.HasRows Then
                While dataRead.Read
                    Dim Department As New Departement
                    Department.DepartementID = CInt(dataRead("DepartementID"))
                    Department.DepartementName = dataRead("DepartementName").ToString()
                    Department.UpdatedAt = dataRead("UpdatedAt").ToString()
                    Departments.Add(Department)
                End While
            End If
            dataRead.Close()

            Return Departments
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            database.conn.Close()
        End Try
    End Function

    Public Function update(obj As Departement) As Integer Implements IBaseCRUD(Of Departement).update
        Try
            Dim updateDepartment = GetById(obj.DepartementID)
            If updateDepartment Is Nothing Then
                Throw New ArgumentException("Department not found")
            End If

            Dim strSP = "[HumanResource].[USP_UpdateDepartement]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@DepartementID", obj.DepartementID)
            cmd.Parameters.AddWithValue("@DepartementName", obj.DepartementName)

            database.conn.Open()
            Dim result = cmd.ExecuteNonQuery()
            Return result
        Catch sqlex As SqlException
            Throw New ArgumentException(sqlex.Message & " " & sqlex.Number)
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            database.conn.Close()
        End Try
    End Function

    Public Function delete(id As Integer) As Integer Implements IBaseCRUD(Of Departement).delete
        Try
            Dim updateDepartment = GetById(id)
            If updateDepartment Is Nothing Then
                Throw New ArgumentException("Department not found")
            End If

            Dim strSP = "[HumanResource].[USP_DeleteDepartement]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@DepartementID", id)

            database.conn.Open()
            Dim result = cmd.ExecuteNonQuery()
        Catch sqlex As SqlException
            Throw New ArgumentException(sqlex.Message & " " & sqlex.Number)
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            database.conn.Close()
        End Try
    End Function

    Private Function GetById(departmentID As Integer) As Object
        Try
            cmd = New SqlCommand("SELECT * FROM [HumanResource].[Departements] WHERE DepartementName = @DepartementName", database.conn)
            cmd.Parameters.AddWithValue("@DepartementName", departmentID)
            database.conn.Open()
            dataRead = cmd.ExecuteReader()
            If dataRead.HasRows Then
                dataRead.Read()
                Dim department As New Departement
                department.DepartementID = CInt(dataRead("DepartementID"))
                department.DepartementName = dataRead("DepartementName").ToString()
                department.UpdatedAt = dataRead("UpdatedAt").ToString()
                Return department
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            database.conn.Close()
        End Try
    End Function
End Class
