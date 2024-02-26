Public Class _default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs)
        Label1.Text = "Hello ASP " + TextBox1.Text
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If rdlMajalah.Checked Then
            lblHasil.Text = rdlMajalah.Text
        ElseIf rdlTv.Checked Then
            lblHasil.Text = rdlTv.Text
        Else
            lblHasil.Text = rdlLain.Text
        End If
    End Sub

End Class