Imports BSIGeneralAffairBLL
Imports BSIGeneralAffairBLL.DTO.Asset

Public Class DetailAssetPages
    Inherits System.Web.UI.Page

    Dim _assetBLL As New AssetBLL()

    Private Class Condition
        Public Property ConditionName As String
        Public Property ConditionValue As String
    End Class

    Sub LoadDataCondition()
        Dim results = New List(Of Condition) From {
            New Condition With {.ConditionName = "Good", .ConditionValue = "Good"},
            New Condition With {.ConditionName = "Needs Repair", .ConditionValue = "Needs Repair"},
            New Condition With {.ConditionName = "Damaged", .ConditionValue = "Damaged"}
        }
        ddCondition.DataSource = results
        ddCondition.DataTextField = "ConditionName"
        ddCondition.DataValueField = "ConditionValue"
        ddCondition.DataBind()
    End Sub

    Sub LoadDataUser()
        Dim _userBLL As New UserBLL
        Dim results = _userBLL.GetAll()

        ddUserHandsover.DataSource = results
        ddUserHandsover.DataTextField = "UserFullName"
        ddUserHandsover.DataValueField = "UserID"
        ddUserHandsover.DataBind()
    End Sub

    Sub LoadDataUserHandsover()
        Dim _assetBLL As New AssetBLL
        Dim results = _assetBLL.GetHandsoverHistoryAsset(ViewState("AssetID"))
        lvUserHandsover1.DataSource = results
        lvUserHandsover1.DataBind()
    End Sub

    Sub GetEditAssetDataBound()
        Dim _assetNumber = Request.QueryString("assetnumber")

        Dim _categoryBLL As New CategoryBLL
        Dim _categories = _categoryBLL.GetAll()

        Dim _brandBLL As New BrandBLL
        Dim _brands = _brandBLL.GetAll()

        LoadDataCondition()
        LoadDataUser()

        Try
            ddCategory.DataSource = _categories
            ddCategory.DataTextField = "AssetCategoryName"
            ddCategory.DataValueField = "AssetCategoryID"
            ddCategory.DataBind()

            ddBrand.DataSource = _brands
            ddBrand.DataTextField = "BrandName"
            ddBrand.DataValueField = "BrandID"
            ddBrand.DataBind()

            LoadDataCondition()

            Dim _asset = _assetBLL.GetByNumberAsset(_assetNumber)

            If _assetNumber IsNot Nothing Then
                txtAssetNumber.Text = _asset.AssetNumber
                txtAssetName.Text = _asset.Name
                txtFactoryNumber.Text = _asset.FactoryNumber
                ddCategory.SelectedValue = _asset.CategoryID
                ddBrand.SelectedValue = _asset.BrandID
                txtCost.Text = CInt(_asset.Cost)
                txtProcurement.Text = _asset.ProcurementDate.ToString("yyyy-MM-dd")
                ddCondition.SelectedValue = _asset.Condition
                ViewState("AssetID") = _asset.AssetID
            Else
                ltMessage.Text = "<span class='alert alert-danger'>Error: Article not found</span><br/><br/>"
            End If
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If Session("User") Is Nothing Then
                Response.Redirect("~/Presentation/LoginPages.aspx")
            End If
            GetEditAssetDataBound()
            LoadDataUserHandsover()
        End If
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)
        Try
            Dim inputVal As String = txtCost.Text

            inputVal = New String(inputVal.Where(Function(c) Char.IsDigit(c)).ToArray())

            ' Convert the numeric value to an integer (or any other data type you need

            Dim _assetBLL As New AssetBLL
            Dim _asset As New AssetUpdateDTO

            _asset.AssetNumber = txtAssetNumber.Text
            _asset.Brand = CInt(ddBrand.SelectedValue)
            _asset.AssetCategoryID = CInt(ddCategory.SelectedValue)
            _asset.AssetFactoryNumber = txtFactoryNumber.Text
            _asset.AsssetName = txtAssetName.Text
            _asset.AssetCost = inputVal
            _asset.AssetCondition = ddCondition.SelectedValue
            _asset.AssetProcurementDate = txtProcurement.Text
            _assetBLL.Update(_asset)

            Response.Redirect("~/Presentation/AssetPages.aspx")
            ltMessage.Text = "<span class='alert alert-success'>Asset added successfully</span><br/><br/>"
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub

    Protected Sub btnAddHandsover_Click(sender As Object, e As EventArgs)
        Try

            Dim _userID = CInt(ddUserHandsover.SelectedValue)
            Dim _assetID = CInt(ViewState("AssetID"))
            Dim _handsoverDate = txtHandsoverDate.Text

            _assetBLL.HandsoverAsset(_userID, _assetID, _handsoverDate)

            ltMessage.Text = "<span class='alert alert-success'>Handsover asset successfully</span><br/><br/>"
            InitializeFormAddArticle()
            LoadDataUserHandsover()
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub
    Private Sub InitializeFormAddArticle()
        txtHandsoverDate.Text = String.Empty
    End Sub
End Class