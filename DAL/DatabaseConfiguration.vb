Imports System.Data.SqlClient

Public Class DatabaseConfiguration

    Public Property conn As SqlConnection
    Public Property strConn As String

    Public Sub New()
        strConn = "Server=.\SQLEXPRESS02;Database=BobsShoes;Trusted_Connection=True;"
        conn = New SqlConnection(strConn)
    End Sub



End Class
