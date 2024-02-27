Imports System.Data
Imports System.Data.SqlClient
Imports BSIGeneralAffairBO
Imports GeneralAffairInterface

Public Class DALOffice
    Implements IOffice

    Public database As DatabaseConfiguration = New DatabaseConfiguration()
    Private dataRead As SqlDataReader
    Public cmd As SqlCommand

    Public Function create(obj As Office) As Integer Implements IBaseCRUD(Of Office).create
        Try
            Dim strSP = "[Office].[USP_StoreOffice]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure


            cmd.Parameters.AddWithValue("@OfficeName", obj.OfficeName)
            cmd.Parameters.AddWithValue("@OfficeAddress", obj.OfficeAddress)
            cmd.Parameters.AddWithValue("@OfficeFlagActive", obj.OfficeFlagActive)

            database.conn.Open()
            Dim result = cmd.ExecuteNonQuery()
            If result = 1 Then
                Throw New ArgumentException("Office not created")
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

    Public Function getAll() As List(Of Office) Implements IBaseCRUD(Of Office).getAll
        Dim Offices As New List(Of Office)
        Try
            Dim strSP = "[Office].[USP_SelectAllOffice]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure
            database.conn.Open()
            dataRead = cmd.ExecuteReader()
            If dataRead.HasRows Then
                While dataRead.Read
                    Dim office As New Office
                    office.OfficeID = CInt(dataRead("OfficeID"))
                    office.OfficeName = dataRead("OfficeName").ToString()
                    office.OfficeAddress = dataRead("OfficeAddress").ToString()
                    office.OfficeFlagActive = CInt(dataRead("OfficeFlagActive"))
                    Offices.Add(office)
                End While
            End If
            dataRead.Close()

            Return Offices
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            database.conn.Close()
        End Try
    End Function

    Public Function update(obj As Office) As Integer Implements IBaseCRUD(Of Office).update
        Try
            Dim updateOffice = GetById(obj.OfficeID)
            If updateOffice Is Nothing Then
                Throw New ArgumentException("Office not found")
            End If

            Dim strSP = "[Office].[USP_UpdateOffice]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@OfficeID", obj.OfficeID)
            cmd.Parameters.AddWithValue("@OfficeName", obj.OfficeName)
            cmd.Parameters.AddWithValue("@OfficeAddress", obj.OfficeAddress)
            cmd.Parameters.AddWithValue("@OfficeFlagActive", obj.OfficeFlagActive)

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

    Private Function GetById(officeID As Integer) As Object
        Try
            cmd = New SqlCommand("SELECT * FROM [Office].[OfficeLocation] WHERE OfficeName = @OfficeName", database.conn)
            cmd.Parameters.AddWithValue("@OfficeName", officeID)
            database.conn.Open()
            dataRead = cmd.ExecuteReader()
            If dataRead.HasRows Then
                dataRead.Read()
                Dim office As New Office
                office.OfficeID = CInt(dataRead("OfficeID"))
                office.OfficeName = dataRead("OfficeName ").ToString()
                office.OfficeName = dataRead("OfficeName ").ToString()
                office.UpdateAt = dataRead("UpdatedAt").ToString()
                Return office
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

    Public Function delete(id As Integer) As Integer Implements IBaseCRUD(Of Office).delete
        Try
            Dim office = GetById(id)
            If office Is Nothing Then
                Throw New ArgumentException("Office not found")
            End If

            Dim strSP = "[Office].[USP_DeleteOffice]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@OfficeID", id)

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
End Class
