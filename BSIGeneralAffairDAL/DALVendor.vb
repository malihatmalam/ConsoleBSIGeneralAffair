Imports System.Data
Imports System.Data.SqlClient
Imports BSIGeneralAffairBO
Imports GeneralAffairInterface

Public Class DALVendor
    Implements IVendor

    Public database As DatabaseConfiguration = New DatabaseConfiguration()
    Private dataRead As SqlDataReader
    Public cmd As SqlCommand

    Public Function getAll() As List(Of Vendor) Implements IVendor.getAll
        Dim Vendors As New List(Of Vendor)
        Try
            Dim strSP = "[GeneralAffair].[USP_SelectAllVendor]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure
            database.conn.Open()
            dataRead = cmd.ExecuteReader()
            If dataRead.HasRows Then
                While dataRead.Read
                    Dim Vendor As New Vendor
                    Vendor.VendorID = CInt(dataRead("VendorID"))
                    Vendor.VendorName = dataRead("VendorName").ToString()
                    Vendor.VendorAddress = dataRead("VendorAddress").ToString()
                    Vendor.CreatedAt = dataRead("CreatedAt").ToString()
                    Vendor.UpdatedAt = dataRead("UpdatedAt").ToString()
                    Vendors.Add(Vendor)
                End While
            End If
            dataRead.Close()

            Return Vendors
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            database.conn.Close()
        End Try
    End Function

    Public Function create(obj As Vendor) As Integer Implements IVendor.create
        Try
            Dim strSP = "[GeneralAffair].[USP_StoreVendor]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@VendorName", obj.VendorName)
            cmd.Parameters.AddWithValue("@VendorAddress", obj.VendorAddress)

            database.conn.Open()
            Dim result = cmd.ExecuteNonQuery()
            If result = 1 Then
                Throw New ArgumentException("Vendor not created")
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

    Public Function update(obj As Vendor) As Integer Implements IVendor.update
        Try
            Dim updateVendor = GetById(obj.VendorID)
            If updateVendor Is Nothing Then
                Throw New ArgumentException("Vendor not found")
            End If

            Dim strSP = "[GeneralAffair].[USP_UpdateVendor]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@VendorID", obj.VendorID)
            cmd.Parameters.AddWithValue("@VendorName", obj.VendorName)
            cmd.Parameters.AddWithValue("@VendorAddress", obj.VendorAddress)

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

    Private Function GetById(vendorID As Integer) As Object
        Try
            cmd = New SqlCommand("SELECT * FROM [GeneralAffair].[Vendors] WHERE VendorID = @VendorID", database.conn)
            cmd.Parameters.AddWithValue("@VendorID", vendorID)
            database.conn.Open()
            dataRead = cmd.ExecuteReader()
            If dataRead.HasRows Then
                dataRead.Read()
                Dim vendor As New Vendor
                vendor.VendorID = CInt(dataRead("VendorID"))
                vendor.VendorName = dataRead("VendorName").ToString
                vendor.VendorAddress = dataRead("VendorAddress").ToString
                vendor.CreatedAt = dataRead("CreatedAt").ToString
                vendor.UpdatedAt = dataRead("UpdatedAt").ToString
                Return vendor
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

    Public Function delete(id As Integer) As Integer Implements IVendor.delete
        Try
            Dim updateVendor = GetById(id)
            If updateVendor Is Nothing Then
                Throw New ArgumentException("Vendor not found")
            End If

            Dim strSP = "[GeneralAffair].[USP_DeleteVendor]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@VendorID", id)

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
