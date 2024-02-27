Imports System.Data
Imports System.Data.SqlClient
Imports BSIGeneralAffairBO
Imports GeneralAffairInterface

Public Class DALEmployee
    Implements IEmployee

    Public database As DatabaseConfiguration = New DatabaseConfiguration()
    Private dataRead As SqlDataReader
    Public cmd As SqlCommand

    Public Function getAll() As List(Of Employee) Implements IEmployee.getAll
        Dim Employeis As New List(Of Employee)
        Try
            Dim strSP = "[HumanResource].[USP_ListEmployee]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure
            database.conn.Open()
            dataRead = cmd.ExecuteReader()
            If dataRead.HasRows Then
                While dataRead.Read
                    Dim employee As New Employee
                    Dim user As New User
                    employee.EmployeeIDNumber = dataRead("EmployeeID").ToString()
                    employee.User = New User()
                    employee.User.UserFullName = dataRead("Fullname").ToString()
                    employee.EmployeePosition = dataRead("Position").ToString()
                    employee.EmployeeGender = dataRead("Gender").ToString()
                    employee.Department = New Departement()
                    employee.Department.DepartementName = dataRead("Department").ToString()
                    employee.Office = New Office()
                    employee.Office.OfficeName = dataRead("Office").ToString()
                    employee.EmployeeHireDate = dataRead("HireDate").ToString()
                    Employeis.Add(employee)
                End While
            End If
            dataRead.Close()

            Return Employeis
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            database.conn.Close()
        End Try
    End Function

    Public Function create(obj As Employee) As Integer Implements IEmployee.create
        Try
            Dim strSP = "[HumanResource].[USP_CreateEmployee]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Firstname", obj.User.UserFirstName)
            cmd.Parameters.AddWithValue("@LastName", obj.User.UserLastName)
            cmd.Parameters.AddWithValue("@EmployeeNumber", obj.EmployeeIDNumber)
            cmd.Parameters.AddWithValue("@DepartementID", obj.Department.DepartementID)
            cmd.Parameters.AddWithValue("@OfficeID", obj.Office.OfficeID)
            cmd.Parameters.AddWithValue("@EmployeePositionLevel", obj.EmployeePositionLevel)
            cmd.Parameters.AddWithValue("@EmployeeJobTitle", obj.EmployeeJobTitle)
            cmd.Parameters.AddWithValue("@EmployeeGender", obj.EmployeeGender)
            cmd.Parameters.AddWithValue("@EmployeeMaritalStatus", obj.EmployeeMaritalStatus)
            cmd.Parameters.AddWithValue("@EmployeeBirthDate", obj.EmployeeBirthDate)
            cmd.Parameters.AddWithValue("@EmployeeHireDate", obj.EmployeeHireDate)
            cmd.Parameters.AddWithValue("@EmployeeSalary", obj.EmployeeSalary)
            cmd.Parameters.AddWithValue("@EmployeeType", obj.EmployeeType)
            database.conn.Open()
            Dim result = cmd.ExecuteNonQuery()
            If result = 1 Then
                Throw New ArgumentException("Employee not created")
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
End Class
