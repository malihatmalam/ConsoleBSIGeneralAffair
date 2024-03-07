Imports BSIGeneralAffairBLL
Imports BSIGeneralAffairBLL.DTO.Brand
Imports BSIGeneralAffairBLL.DTO.Category
Imports System.Web.ModelBinding

Public Class CategoryPages
    Inherits System.Web.UI.Page
    Dim _categoryBLL As New CategoryBLL()

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

        ViewState("RecordCount") = _categoryBLL.GetCountCategory(txtSearch.Text)
        ltPosition.Text = "Page " & ViewState("PageNumber") & " of " & maxPage
    End Sub
#End Region

    'Public Function GetAll(<Control("txtSearch")> categoryName As String) As List(Of CategoryDTO)
    '    Return _categoryBLL.GetByName(categoryName)
    'End Function

    Public Function GetAll(<Control("txtSearch")> name As String) As List(Of CategoryDTO)
        'Return _categoryBLL.GetWithPaging(2, 5)
        Return _categoryBLL.GetWithPaging(CInt(ViewState("PageNumber")), CInt(ViewState("PageSize")), name)
    End Function

    Public Sub Update(AssetCategoryID As Integer, AssetCategoryName As String)
        Try
            'updateCategory.CategoryName =
            Dim _categoryUpdateDTO As New CategoryUpdateDTO
            _categoryUpdateDTO.AssetCategoryID = AssetCategoryID
            _categoryUpdateDTO.AssetCategoryName = AssetCategoryName

            _categoryBLL.Update(_categoryUpdateDTO)
            ltMessage.Text = "<span class='alert alert-success'>Category updated successfully</span>"

            gvCategories.DataBind()
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
        End Try
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("User") Is Nothing Then
                Response.Redirect("~/Presentation/LoginPages.aspx")
            End If

            ViewState("PageNumber") = 1
            ViewState("PageSize") = 5
        End If

        ViewState("RecordCount") = _categoryBLL.GetCountCategory(txtSearch.Text)
        InitiateButtonNavigation()

        'ltMessage.Text = pageNumber & " " & pageSize
    End Sub

    ' The id parameter name should match the DataKeyNames value set on the control
    Public Sub Delete(AssetCategoryID As Integer)
        Try
            _categoryBLL.Delete(AssetCategoryID)
            ltMessage.Text = "<span class='alert alert-success'>Category deleted successfully</span>"
            gvCategories.DataBind()
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
        End Try
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)
        Try
            Dim newCategory As New CategoryCreateDTO
            newCategory.AssetCategoryName = txtCategoryName.Text
            _categoryBLL.Insert(newCategory)

            gvCategories.DataBind()
            ltMessage.Text = "<span class='alert alert-success'>Category added successfully</span>"
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
        End Try
    End Sub

    Protected Sub btnNext_Click(sender As Object, e As EventArgs)

        Dim maxPage = Math.Floor(CInt(ViewState("RecordCount")) / CInt(ViewState("PageSize")) + 1)
        If CInt(ViewState("PageNumber")) < maxPage Then
            ViewState("PageNumber") = CInt(ViewState("PageNumber")) + 1
            gvCategories.DataBind()
        Else
            ltMessage.Text = "<span class='alert alert-danger'>You are on the last page</span>"
        End If
        InitiateButtonNavigation()
    End Sub

    Protected Sub btnPrev_Click(sender As Object, e As EventArgs)
        If CInt(ViewState("PageNumber")) > 1 Then
            ViewState("PageNumber") = CInt(ViewState("PageNumber")) - 1
            gvCategories.DataBind()
        Else
            ltMessage.Text = "<span class='alert alert-danger'>You are on the first page</span>"
        End If
        InitiateButtonNavigation()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        ViewState("PageNumber") = 1
        InitiateButtonNavigation()
    End Sub
End Class