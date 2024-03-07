Imports System.Web.ModelBinding
Imports BSIGeneralAffairBLL
Imports BSIGeneralAffairBLL.DTO.Brand
Imports BSIGeneralAffairBLL.DTO.Employee
Imports BSIGeneralAffairBLL.Interfaces

Public Class EmployeePages
    Inherits System.Web.UI.Page
    Dim _employeeBLL As New EmployeeBLL

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

        ViewState("RecordCount") = _employeeBLL.GetCountEmployee(txtSearch.Text)
        ltPosition.Text = "Page " & ViewState("PageNumber") & " of " & maxPage
    End Sub
#End Region

#Region "Binding Data"

    Private Class Level
        Public Property LevelName As String
        Public Property LevelValue As String

    End Class

    Private Class Gender
        Public Property GenderName As String
        Public Property GenderValue As String
    End Class

    Private Class Marital
        Public Property MaritalName As String
        Public Property MaritalValue As String
    End Class

    Private Class TypeStaff
        Public Property TypeStaffName As String
        Public Property TypeStaffValue As String
    End Class

    Sub LoadDataDepartment()
        Dim _departmentBLL As New DepartementBLL
        Dim results = _departmentBLL.GetAll()

        ddDepartment.DataSource = results
        ddDepartment.DataTextField = "DepartementName"
        ddDepartment.DataValueField = "DepartementID"
        ddDepartment.DataBind()
    End Sub

    Sub LoadDataLevel()
        Dim results = New List(Of Level) From {
            New Level With {.LevelName = "Staff", .LevelValue = "Staff"},
            New Level With {.LevelName = "Director", .LevelValue = "Director"},
            New Level With {.LevelName = "Manager", .LevelValue = "Manager"}
        }
        ddPositionLevel.DataSource = results
        ddPositionLevel.DataTextField = "LevelName"
        ddPositionLevel.DataValueField = "LevelValue"
        ddPositionLevel.DataBind()
    End Sub

    Sub LoadDataGender()
        Dim results = New List(Of Gender) From {
            New Gender With {.GenderName = "Male", .GenderValue = "M"},
            New Gender With {.GenderName = "Female", .GenderValue = "F"}
        }

        ddGender.DataSource = results
        ddGender.DataTextField = "GenderName"
        ddGender.DataValueField = "GenderValue"
        ddGender.DataBind()
    End Sub

    Sub LoadDataMarital()
        Dim results = New List(Of Marital) From {
            New Marital With {.MaritalName = "Married", .MaritalValue = "M"},
            New Marital With {.MaritalName = "Single", .MaritalValue = "S"}
        }

        ddMarital.DataSource = results
        ddMarital.DataTextField = "MaritalName"
        ddMarital.DataValueField = "MaritalValue"
        ddMarital.DataBind()
    End Sub

    Sub LoadDataOffice()
        Dim _officeBLL As New OfficeBLL
        Dim results = _officeBLL.GetAll()

        ddOffice.DataSource = results
        ddOffice.DataTextField = "OfficeName"
        ddOffice.DataValueField = "OfficeID"
        ddOffice.DataBind()
    End Sub

    Sub LoadDataTypeStaff()
        Dim results = New List(Of TypeStaff) From {
            New TypeStaff With {.TypeStaffName = "Other", .TypeStaffValue = "O"},
            New TypeStaff With {.TypeStaffName = "Procurement", .TypeStaffValue = "P"},
            New TypeStaff With {.TypeStaffName = "Asset", .TypeStaffValue = "A"}
        }

        ddTypeStaff.DataSource = results
        ddTypeStaff.DataTextField = "TypeStaffName"
        ddTypeStaff.DataValueField = "TypeStaffValue"
        ddTypeStaff.DataBind()
    End Sub


    Sub DataBoundAll()
        LoadDataDepartment()
        LoadDataGender()
        LoadDataLevel()
        LoadDataMarital()
        LoadDataOffice()
        LoadDataTypeStaff()
    End Sub
#End Region

    Public Function GetAll(<Control("txtSearch")> name As String) As List(Of EmployeeListDTO)
        'Return _categoryBLL.GetWithPaging(2, 5)
        Return _employeeBLL.GetWithPaging(CInt(ViewState("PageNumber")), CInt(ViewState("PageSize")), name)
    End Function

    'Public Sub Update(BrandID As Integer, BrandName As String)
    '    Try
    '        'updateCategory.CategoryName =
    '        Dim _employeeUpdateDTO As New BrandUpdateDTO
    '        _brandUpdateDTO.BrandId = BrandID
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

        ViewState("RecordCount") = _employeeBLL.GetCountEmployee(txtSearch.Text)
        InitiateButtonNavigation()

        'ltMessage.Text = pageNumber & " " & pageSize
    End Sub

    ' The id parameter name should match the DataKeyNames value set on the control
    'Public Sub Delete(BrandID As Integer)
    '    Try
    '        _employeeBLL.Delete(BrandID)
    '        ltMessage.Text = "<span class='alert alert-success'>Brand deleted successfully</span>"
    '        gvBrands.DataBind()
    '    Catch ex As Exception
    '        ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
    '    End Try
    'End Sub

    'Protected Sub btnAdd_Click(sender As Object, e As EventArgs)
    '    Try
    '        Dim newEmployee As New BrandCreateDTO
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
            gvEmployees.DataBind()
        Else
            ltMessage.Text = "<span class='alert alert-danger'>You are on the last page</span>"
        End If
        InitiateButtonNavigation()
    End Sub

    Protected Sub btnPrev_Click(sender As Object, e As EventArgs)
        If CInt(ViewState("PageNumber")) > 1 Then
            ViewState("PageNumber") = CInt(ViewState("PageNumber")) - 1
            gvEmployees.DataBind()
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

            Dim inputVal As String = txtSalary.Text

            inputVal = New String(inputVal.Where(Function(c) Char.IsDigit(c)).ToArray())

            ' Convert the numeric value to an integer (or any other data type you need

            Dim _employeeBLL As New EmployeeBLL
            Dim _employee As New EmployeeCreateDTO

            _employee.Firstname = txtFirstname.Text
            _employee.LastName = txtLastname.Text
            _employee.EmployeeNumber = txtEmployeeNumber.Text
            _employee.DepartementID = CInt(ddDepartment.SelectedValue)
            _employee.OfficeID = CInt(ddOffice.SelectedValue)
            _employee.EmployeePositionLevel = ddPositionLevel.SelectedValue
            _employee.EmployeeJobTitle = txtJobTitle.Text
            _employee.EmployeeGender = ddGender.SelectedValue
            _employee.EmployeeMaritalStatus = ddMarital.SelectedValue
            _employee.EmployeeBirthDate = txtBirtDate.Text
            _employee.EmployeeHireDate = txtHireDate.Text
            _employee.EmployeeType = ddTypeStaff.Text
            _employee.EmployeeSalary = inputVal
            _employeeBLL.Insert(_employee)

            ltMessage.Text = "<span class='alert alert-success'>Employee added successfully</span><br/><br/>"
            InitializeFormAddArticle()
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub

    Private Sub InitializeFormAddArticle()
        txtFirstname.Text = String.Empty
        txtLastname.Text = String.Empty
        txtEmployeeNumber.Text = String.Empty
        txtJobTitle.Text = String.Empty
        txtBirtDate.Text = String.Empty
        txtHireDate.Text = String.Empty
    End Sub
End Class