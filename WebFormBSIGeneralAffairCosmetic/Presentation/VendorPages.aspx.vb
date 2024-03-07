Imports BSIGeneralAffairBO
Imports BSIGeneralAffairDAL

Public Class VendorPages
    Inherits System.Web.UI.Page

    Dim vendorDAL As New DALVendor()

    Sub LoadData()
        gvVendors.DataSource = vendorDAL.getAll()
        gvVendors.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("User") Is Nothing Then
                Response.Redirect("~/Presentation/LoginPages.aspx")
            End If

            btnSave.Enabled = False
            LoadData()
        End If
    End Sub

    Protected Sub gvVendors_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Select" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim vendorID As Integer = Convert.ToInt32(gvVendors.DataKeys(index).Value)
            'Dim categoryName = gvCategories.DataKeys(index)("CategoryName").ToString()
            'txtVendorID.Text = vendorID.ToString()
            Dim objVendor As Vendor = vendorDAL.GetById(vendorID)
            txtVendorName.Text = objVendor.VendorName
            txtVendorAddress.Text = objVendor.VendorAddress
        End If
    End Sub


    Protected Sub btnEdit_Click(sender As Object, e As EventArgs)
        Try
            If String.IsNullOrEmpty(txtVendorID.Text) OrElse String.IsNullOrEmpty(txtVendorName.Text) Then
                ltMessage.Text = "<span class='alert alert-danger'>Vendor ID and Name are required</span>"
                Return
            End If

            Dim updateVendor As New Vendor
            updateVendor.VendorID = Convert.ToInt32(txtVendorID.Text)
            updateVendor.VendorName = txtVendorName.Text
            updateVendor.VendorAddress = txtVendorAddress.Text
            vendorDAL.update(updateVendor)
            LoadData()
            ltMessage.Text = "<span class='alert alert-success'>Vendor updated successfully</span>"
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
        End Try
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)
        txtVendorID.Text = String.Empty
        txtVendorName.Text = String.Empty
        txtVendorAddress.Text = String.Empty
        btnSave.Enabled = True
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        Try
            Dim insertVendor As New Vendor
            insertVendor.VendorName = txtVendorName.Text
            vendorDAL.create(insertVendor)

            LoadData()
            btnSave.Enabled = False
            ltMessage.Text = "<span class='alert alert-success'>Vendor added successfully</span>"
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
        End Try
    End Sub

End Class