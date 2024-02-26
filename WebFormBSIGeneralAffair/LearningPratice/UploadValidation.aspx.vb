Imports System.IO

Public Class UploadValidation
    Inherits System.Web.UI.Page

    Private Function CekTipeFile(ByVal strFileName As String) As Boolean
        Dim strExt = Path.GetExtension(strFileName)
        Select Case strExt.ToLower()
            Case ".jpg"
                Return True
            Case ".jpeg"
                Return True
            Case ".gif"
                Return True
            Case ".png"
                Return True
            Case Else
                Return False
        End Select
    End Function
    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        If fpImage.HasFile Then
            If CekTipeFile(fpImage.FileName) Then
                Dim strPath = "~/UploadImage/" + fpImage.FileName
                fpImage.SaveAs(MapPath(strPath))
            Else
                lblError.Text = "Tipe file yang diinputkan tidak sesuai"
            End If
        End If
    End Sub
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim strUpfolder = MapPath("~/UploadImage/")
        Dim dir As New DirectoryInfo(strUpfolder)
        dlImage.DataSource = dir.GetFiles()
        dlImage.DataBind()
    End Sub

End Class