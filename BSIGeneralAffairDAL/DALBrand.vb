Imports BSIGeneralAffairBO
Imports GeneralAffairInterface
Imports System.Data
Imports System.Data.SqlClient

Public Class DALBrand
    Implements IBrand

    Public database As DatabaseConfiguration = New DatabaseConfiguration()
    Private dataRead As SqlDataReader
    Public cmd As SqlCommand

    Public Function getAll() As List(Of Brand) Implements IBrand.getAll
        Dim Brands As New List(Of Brand)
        Try
            Dim strSP = "[GeneralAffair].[USP_SelectAllBrand]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure
            database.conn.Open()
            dataRead = cmd.ExecuteReader()
            If dataRead.HasRows Then
                While dataRead.Read
                    Dim Brand As New Brand
                    Brand.BrandID = CInt(dataRead("BrandID"))
                    Brand.BrandName = dataRead("BrandName").ToString()
                    Brand.UpdatedAt = dataRead("UpdatedAt").ToString()
                    Brands.Add(Brand)
                End While
            End If
            dataRead.Close()

            Return Brands
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            database.conn.Close()
        End Try
    End Function

    Public Function create(obj As Brand) As Integer Implements IBrand.create
        Try
            Dim strSP = "[GeneralAffair].[USP_StoreBrand]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@BrandName", obj.BrandName)

            database.conn.Open()
            Dim result = cmd.ExecuteNonQuery()
            If result = 1 Then
                Throw New ArgumentException("Brand not created")
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

    Public Function update(obj As Brand) As Integer Implements IBrand.update
        Try
            Dim updateBrand = GetById(obj.BrandID)
            If updateBrand Is Nothing Then
                Throw New ArgumentException("Brand not found")
            End If

            Dim strSP = "[GeneralAffair].[USP_UpdateBrand]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@BrandID", obj.BrandID)
            cmd.Parameters.AddWithValue("@BrandName", obj.BrandName)

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

    Private Function GetById(brandID As Integer) As Object
        Try
            cmd = New SqlCommand("SELECT * FROM [GeneralAffair].[Brands] WHERE BrandID = @BrandID", database.conn)
            cmd.Parameters.AddWithValue("@BrandID", brandID)
            database.conn.Open()
            dataRead = cmd.ExecuteReader()
            If dataRead.HasRows Then
                dataRead.Read()
                Dim brand As New Brand
                brand.BrandID = CInt(dataRead("BrandID"))
                brand.BrandName = dataRead("BrandName").ToString()
                brand.UpdatedAt = dataRead("UpdatedAt").ToString()
                Return brand
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

    Public Function delete(id As Integer) As Integer Implements IBrand.delete
        Try
            Dim updateBrand = GetById(id)
            If updateBrand Is Nothing Then
                Throw New ArgumentException("Brand not found")
            End If

            Dim strSP = "[GeneralAffair].[USP_DeleteBrand]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@BrandID", id)

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
