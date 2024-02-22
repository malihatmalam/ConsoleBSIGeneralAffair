Imports System.Data
Imports System.Data.SqlClient
Imports BSIGeneralAffairBO
Imports GeneralAffairInterface

Public Class DALVendor
    Implements IBaseCRUD(Of Vendor)

    'Private database As DatabaseConfiguration = New DatabaseConfiguration()

    Public Property conn As SqlConnection
    Public Property strConn As String
    Private cmd As SqlCommand
    Private dataRead As SqlDataReader

    Public Sub New()
        strConn = "Server=.\SQLEXPRESS02;Database=BSIGeneralAffair2024;Trusted_Connection=True;"
        conn = New SqlConnection(strConn)
    End Sub

    Public Function create(obj As Vendor) As Integer Implements IBaseCRUD(Of Vendor).create
        Throw New NotImplementedException()
    End Function

    Public Function update(obj As Vendor) As Integer Implements IBaseCRUD(Of Vendor).update
        Throw New NotImplementedException()
    End Function

    Public Function delete(id As Integer) As Integer Implements IBaseCRUD(Of Vendor).delete
        Throw New NotImplementedException()
    End Function

    Public Function getAll() As List(Of Vendor) Implements IBaseCRUD(Of Vendor).getAll
        Dim Vendors As New List(Of Vendor)
        Try
            Dim strSP = "[GeneralAffair].[USP_SelectAllVendor]"
            cmd = New SqlCommand(strSP, conn)
            cmd.CommandType = CommandType.StoredProcedure
            conn.Open()
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
            conn.Close()
        End Try
    End Function
End Class