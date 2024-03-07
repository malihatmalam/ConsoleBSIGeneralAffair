Imports BSIGeneralAffairBLL
Imports BSIGeneralAffairBLL.DTO.Asset
Imports BSIGeneralAffairBLL.DTO.Brand
Imports System.Web.ModelBinding

Public Class AssetPages
    Inherits System.Web.UI.Page
    Dim _assetBLL As New AssetBLL()

#Region "Initiate"
    Sub InitiateButtonNavigation()
        Dim maxPage = 0
        Dim pagediv = CInt(ViewState("RecordCount")) Mod CInt(ViewState("PageSize"))

        If CInt(ViewState("RecordCount")) = 0 Then
            maxPage = 1
        ElseIf pagediv = 0 Then
            maxPage = CInt(ViewState("RecordCount")) / CInt(ViewState("PageSize"))
        Else
            maxPage = Math.Floor(CInt(ViewState("RecordCount")) / CInt(ViewState("PageSize")) + 1)
        End If

        If maxPage = 1 Then
            btnPrev.Enabled = False
            btnNext.Enabled = False
        ElseIf CInt(ViewState("PageNumber")) = 1 Then
            btnPrev.Enabled = False
            btnNext.Enabled = True
        ElseIf CInt(ViewState("PageNumber")) = maxPage Then
            btnPrev.Enabled = True
            btnNext.Enabled = False
        Else
            btnPrev.Enabled = True
            btnNext.Enabled = True
        End If

        ViewState("RecordCount") = _assetBLL.GetCountAssets(txtSearch.Text)
        ltPosition.Text = "Page " & ViewState("PageNumber") & " of " & maxPage
    End Sub
#End Region


#Region "Binding Data"

    Sub LoadDataCategory()
        Dim _categoryBLL As New CategoryBLL
        Dim results = _categoryBLL.GetAll()

        ddCategory.DataSource = results
        ddCategory.DataTextField = "AssetCategoryName"
        ddCategory.DataValueField = "AssetCategoryID"
        ddCategory.DataBind()
    End Sub

    Sub LoadDataBrand()
        Dim _brandBLL As New BrandBLL
        Dim results = _brandBLL.GetAll()

        ddBrand.DataSource = results
        ddBrand.DataTextField = "BrandName"
        ddBrand.DataValueField = "BrandID"
        ddBrand.DataBind()
    End Sub

    Sub DataBoundAll()
        LoadDataCategory()
        LoadDataBrand()
    End Sub
#End Region
    'Public Function GetAll(<Control("txtSearch")> categoryName As String) As List(Of CategoryDTO)
    '    Return _categoryBLL.GetByName(categoryName)
    'End Function

    Public Function GetAll(<Control("txtSearch")> name As String) As List(Of AssetDTO)
        'Return _categoryBLL.GetWithPaging(2, 5)
        Return _assetBLL.GetWithPaging(CInt(ViewState("PageNumber")), CInt(ViewState("PageSize")), name)
    End Function

    'Public Sub Update(BrandID As Integer, BrandName As String)
    '    Try
    '        'updateCategory.CategoryName =
    '        Dim _assetUpdateDTO As New AssetUpdateDTO
    '        _assetUpdateDTO..BrandId = BrandID
    '        _brandUpdateDTO.BrandName = BrandName

    '        _brandBLL.Update(_brandUpdateDTO)
    '        ltMessage.Text = "<span class='alert alert-success'>Brand updated successfully</span>"

    '        gvBrands.DataBind()
    '    Catch ex As Exception
    '        ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
    '    End Try
    'End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("User") Is Nothing Then
                Response.Redirect("~/Presentation/LoginPages.aspx")
            End If


            ViewState("PageNumber") = 1
            ViewState("PageSize") = 5
            DataBoundAll()
        End If

        ViewState("RecordCount") = _assetBLL.GetCountAssets(txtSearch.Text)
        InitiateButtonNavigation()

        'ltMessage.Text = pageNumber & " " & pageSize
    End Sub

    ' The id parameter name should match the DataKeyNames value set on the control
    Public Sub Delete(AssetID As Integer)
        Try
            _assetBLL.Delete(AssetID)
            ltMessage.Text = "<span class='alert alert-success'>Asset deleted successfully</span>"
            gvAssets.DataBind()
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
        End Try
    End Sub

    'Protected Sub btnAdd_Click(sender As Object, e As EventArgs)
    '    Try
    '        Dim newBrand As New BrandCreateDTO
    '        newBrand.BrandName = txtBrandName.Text
    '        _brandBLL.Insert(newBrand)

    '        gvBrands.DataBind()
    '        ltMessage.Text = "<span class='alert alert-success'>Brand added successfully</span>"
    '    Catch ex As Exception
    '        ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
    '    End Try
    'End Sub

    Protected Sub btnNext_Click(sender As Object, e As EventArgs)

        Dim maxPage = Math.Floor(CInt(ViewState("RecordCount")) / CInt(ViewState("PageSize")) + 1)
        If CInt(ViewState("PageNumber")) < maxPage Then
            ViewState("PageNumber") = CInt(ViewState("PageNumber")) + 1
            gvAssets.DataBind()
        Else
            ltMessage.Text = "<span class='alert alert-danger'>You are on the last page</span>"
        End If
        InitiateButtonNavigation()
    End Sub

    Protected Sub btnPrev_Click(sender As Object, e As EventArgs)
        If CInt(ViewState("PageNumber")) > 1 Then
            ViewState("PageNumber") = CInt(ViewState("PageNumber")) - 1
            gvAssets.DataBind()
        Else
            ltMessage.Text = "<span class='alert alert-danger'>You are on the first page</span>"
        End If
        InitiateButtonNavigation()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        ViewState("PageNumber") = 1
        InitiateButtonNavigation()
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)
        Try
            'rename upload file
            'Dim fileName As String = Guid.NewGuid.ToString() & fpPic.FileName
            'If fpPic.HasFile Then
            '    If CheckFileType(fileName) Then
            '        Dim _path As String = Server.MapPath("~/Pics/")
            '        fpPic.SaveAs(_path & fileName)
            '    Else
            '        ltMessage.Text = "<span class='alert alert-danger'>Error: Only images are allowed</span><br/><br/>"
            '        Return
            '    End If
            'End If

            Dim inputVal As String = txtCost.Text

            inputVal = New String(inputVal.Where(Function(c) Char.IsDigit(c)).ToArray())

            ' Convert the numeric value to an integer (or any other data type you need

            Dim _assetBLL As New AssetBLL
            Dim _asset As New AssetCreateDTO

            _asset.Brand = CInt(ddBrand.SelectedValue)
            _asset.AssetCategoryID = CInt(ddCategory.SelectedValue)
            _asset.AssetFactoryNumber = txtFactoryNumber.Text
            _asset.AssetNumber = txtAssetNumber.Text
            _asset.AsssetName = txtAssetName.Text
            _asset.AssetCost = inputVal
            _asset.AssetProcurementDate = txtProcurementDate.Text
            _assetBLL.Insert(_asset)

            ltMessage.Text = "<span class='alert alert-success'>Asset added successfully</span><br/><br/>"
            InitializeFormAddArticle()
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub
    Private Sub InitializeFormAddArticle()
        txtFactoryNumber.Text = String.Empty
        txtAssetNumber.Text = String.Empty
        txtAssetName.Text = String.Empty
        txtCost.Text = String.Empty
        txtProcurementDate.Text = String.Empty
    End Sub
End Class