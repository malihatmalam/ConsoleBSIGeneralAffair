Public Class ImageControl
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objRnd As New Random
        Select Case objRnd.Next(3)
            Case 0
                imgRandom.ImageUrl = "~/Picture1.gif"
                imgRandom.AlternateText = "Picture1"
            Case 1
                imgRandom.ImageUrl = "~/Picture2.gif"
                imgRandom.AlternateText = "Picture2"
            Case 2
                imgRandom.ImageUrl = "~/Picture3.gif"
                imgRandom.AlternateText = "Picture3"
        End Select
    End Sub

End Class