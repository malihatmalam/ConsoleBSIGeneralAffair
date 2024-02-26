Public Class PanelControl
    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If rdlOther.Checked Then
            pnlOther.Visible = True
        Else
            pnlOther.Visible = False
        End If
    End Sub

End Class