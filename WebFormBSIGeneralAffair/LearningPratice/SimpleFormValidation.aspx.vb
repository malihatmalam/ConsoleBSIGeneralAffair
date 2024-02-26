Public Class SimpleFormValidation
    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        lblResult.Text += "Username anda : " + txtUsername.Text + "<br/>"
        lblResult.Text += "Password anda : " + txtPassword.Text + "<br/>"
    End Sub

End Class