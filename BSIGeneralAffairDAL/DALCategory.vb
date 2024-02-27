Imports System.Data
Imports System.Data.SqlClient
Imports BSIGeneralAffairBO
Imports GeneralAffairInterface

Public Class DALCategory
    Implements ICategory

    Public database As DatabaseConfiguration = New DatabaseConfiguration()
    Private dataRead As SqlDataReader
    Public cmd As SqlCommand

    Public Function create(obj As AssetCategory) As Integer Implements IBaseCRUD(Of AssetCategory).create
        Try
            Dim strSP = "[GeneralAffair].[USP_StoreCategoryAsset]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@AssetCategoryName", obj.AssetCategoryName)

            database.conn.Open()
            Dim result = cmd.ExecuteNonQuery()
            If result = 1 Then
                Throw New ArgumentException("Category not created")
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

    Public Function getAll() As List(Of AssetCategory) Implements IBaseCRUD(Of AssetCategory).getAll
        Dim Categories As New List(Of AssetCategory)
        Try
            Dim strSP = "[GeneralAffair].[USP_SelectAllCategoryAsset]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure
            database.conn.Open()
            dataRead = cmd.ExecuteReader()
            If dataRead.HasRows Then
                While dataRead.Read
                    Dim Category As New AssetCategory
                    Category.AssetCategoryID = CInt(dataRead("AssetCategoryID"))
                    Category.AssetCategoryName = dataRead("AssetCategoryName").ToString()
                    Category.UpdatedAt = dataRead("UpdatedAt").ToString()
                    Categories.Add(Category)
                End While
            End If
            dataRead.Close()

            Return Categories
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            database.conn.Close()
        End Try
    End Function

    Public Function update(obj As AssetCategory) As Integer Implements IBaseCRUD(Of AssetCategory).update
        Try
            Dim updateCategory = GetById(obj.AssetCategoryID)
            If updateCategory Is Nothing Then
                Throw New ArgumentException("Category not found")
            End If

            Dim strSP = "[GeneralAffair].[USP_UpdateCategoryAsset]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@AssetCategoryID", obj.AssetCategoryID)
            cmd.Parameters.AddWithValue("@AssetCategoryName", obj.AssetCategoryName)

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

    Private Function GetById(CategorytID As Integer) As Object
        Try
            cmd = New SqlCommand("SELECT * FROM [GeneralAffair].[AssetCategories] WHERE AssetCategoryID = @AssetCategoryID", database.conn)
            cmd.Parameters.AddWithValue("@AssetCategoryID", CategorytID)
            database.conn.Open()
            dataRead = cmd.ExecuteReader()
            If dataRead.HasRows Then
                dataRead.Read()
                Dim category As New AssetCategory
                category.AssetCategoryID = CInt(dataRead("AssetCategoryID"))
                category.AssetCategoryName = dataRead("AssetCategoryName").ToString
                category.UpdatedAt = dataRead("UpdatedAt").ToString()
                Return category
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

    Public Function delete(id As Integer) As Integer Implements IBaseCRUD(Of AssetCategory).delete
        Try
            Dim category = GetById(id)
            If category Is Nothing Then
                Throw New ArgumentException("category not found")
            End If

            Dim strSP = "[GeneralAffair].[USP_DeleteCategoryAsset]"
            cmd = New SqlCommand(strSP, database.conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@AssetCategoryID", id)

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
