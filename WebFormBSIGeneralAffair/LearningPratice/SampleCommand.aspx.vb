Public Class SampleCommand
    Inherits System.Web.UI.Page

    Private objBarang As New List(Of String)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objBarang.Add("Coklat")
        objBarang.Add("Bunga")
        objBarang.Add("Boneka")
    End Sub

    Protected Sub Cek_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles tAsc.Command
        If e.CommandName = "Sort" Then
            Select Case e.CommandArgument
                Case "Asc"
                    objBarang.Sort(AddressOf SortAsc)
                Case "Desc"
                    objBarang.Sort(AddressOf SortDesc)
            End Select
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        bltBarang.DataSource = objBarang
        bltBarang.DataBind()
    End Sub
    Protected Function SortAsc(ByVal x As String, ByVal y As String) As Integer
        Return String.Compare(x, y)
    End Function
    Protected Function SortDesc(ByVal x As String, ByVal y As String) As Integer
        Return String.Compare(x, y) * -1
    End Function

End Class