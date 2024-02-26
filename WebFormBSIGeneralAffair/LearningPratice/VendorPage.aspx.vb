Imports BSIGeneralAffairBO

Public Class VendorPage
    Inherits System.Web.UI.Page

    Private objVendor As New List(Of String)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getVendorData()
    End Sub

    Protected Sub btnStore_Click(sender As Object, e As EventArgs)
        Dim vendorDAL As New BSIGeneralAffairDAL.DALVendor
        Dim newVendor As New Vendor
        newVendor.VendorName = nameVendor.Text
        newVendor.VendorAddress = addressVendor.Text

        Try
            Dim result = vendorDAL.create(newVendor)
            If result = 1 Then
                message.Text = "Insert failed"
            Else
                message.Text = "Insert success"
            End If
        Catch ex As Exception
            message.Text = ex.Message
        End Try
        nameVendor.Text = ""
        addressVendor.Text = ""
        objVendor.Clear()
        getVendorData()
    End Sub

    Protected Sub getVendorData()
        Dim vendorDAL As New BSIGeneralAffairDAL.DALVendor

        Dim vendors = vendorDAL.getAll()
        For Each vendor As Vendor In vendors
            Dim stringValue As String = vendor.VendorName + ", di :" + vendor.VendorAddress
            objVendor.Add(stringValue)
        Next
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        bullteListVendor.DataSource = objVendor
        bullteListVendor.DataBind()
    End Sub
End Class