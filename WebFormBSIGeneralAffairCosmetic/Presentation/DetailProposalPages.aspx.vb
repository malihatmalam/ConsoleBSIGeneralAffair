Imports BSIGeneralAffairBLL
Imports BSIGeneralAffairBLL.DTO
Imports BSIGeneralAffairBLL.DTO.Approval
Imports BSIGeneralAffairBLL.DTO.Proposal
Imports BSIGeneralAffairBO
Imports Microsoft.Ajax.Utilities

Public Class DetailProposalPages
    Inherits System.Web.UI.Page

    Dim _proposalBLL As New ProposalBLL()

    Private Class ProposalType
        Public Property TypeName As String
        Public Property TypeValue As String
    End Class

    Private Class ApprovalType
        Public Property TypeName As String
        Public Property TypeValue As String
    End Class

    Sub LoadDataProposalType()
        Dim results = New List(Of ProposalType) From {
            New ProposalType With {.TypeName = "Procurement", .TypeValue = "Procurement"},
            New ProposalType With {.TypeName = "Service", .TypeValue = "Service"}
        }
        ddProposalType.DataSource = results
        ddProposalType.DataTextField = "TypeName"
        ddProposalType.DataValueField = "TypeValue"
        ddProposalType.DataBind()
    End Sub

    Sub LoadDataApproval()
        Dim _approvalBLL As New ApprovalBLL
        Dim results = _approvalBLL.GetHistoryApproval(ViewState("ProposalToken"))
        lvApprovalHistory.DataSource = results
        lvApprovalHistory.DataBind()
    End Sub

    Sub LoadDataVendor()

        Dim _vendorBLL = New VendorBLL
        Dim results = _vendorBLL.GetAll()

        ddVendor.DataSource = results
        ddVendor.DataTextField = "VendorName"
        ddVendor.DataValueField = "VendorID"
        ddVendor.DataBind()
    End Sub

    Sub GetEditProposalDataBound()
        Dim _proposalToken = Request.QueryString("proposaltoken")

        Try
            LoadDataProposalType()
            LoadDataVendor()

            Dim _proposal = _proposalBLL.GetByProposalToken(_proposalToken)

            If _proposalToken IsNot Nothing Then
                ddProposalType.SelectedValue = _proposal.ProposalType
                txtProposalToken.Text = _proposal.ProposalToken
                txtProposalObjective.Text = _proposal.ProposalObjective
                txtProposalDescription.Text = _proposal.ProposalDescription
                txtProposalRequireDate.Text = _proposal.ProposalRequireDate
                txtProposalBudget.Text = CInt(_proposal.ProposalBudget)
                txtProposalNote.Text = _proposal.ProposalNote
                txtProposalStatus.Text = _proposal.ProposalStatus
                txtEmployeeName.Text = _proposal.UserFullName
                txtEmployeePosition.Text = _proposal.EmployeePosition
                txtDepartment.Text = _proposal.DepartementName
                ddVendor.SelectedValue = CInt(_proposal.VendorID)
                txtNegotiationNote.Text = _proposal.ProposalNegotiationNote
                ViewState("ProposalToken") = _proposal.ProposalToken
            Else
                ltMessage.Text = "<span class='alert alert-danger'>Error: Proposal not found</span><br/><br/>"
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
            GetEditProposalDataBound()
            LoadDataApproval()
        End If
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)
        Try
            Dim inputVal As String = txtProposalBudget.Text

            inputVal = New String(inputVal.Where(Function(c) Char.IsDigit(c)).ToArray())

            ' Convert the numeric value to an integer (or any other data type you need

            Dim _proposalBLL As New ProposalBLL
            Dim _proposal As New ProposalUpdateDTO

            _proposal.ProposalToken = txtProposalToken.Text
            _proposal.VendorID = CInt(ddVendor.SelectedValue)
            _proposal.ProposalObjective = txtProposalObjective.Text
            _proposal.ProposalDescription = txtProposalDescription.Text
            _proposal.ProposalRequireDate = txtProposalRequireDate.Text
            _proposal.ProposalBudget = inputVal
            _proposal.ProposalNote = txtProposalNote.Text
            _proposal.ProposalNegotiationNote = txtNegotiationNote.Text
            _proposalBLL.Update(_proposal)

            ltMessage.Text = "<span class='alert alert-success'>Proposal updated successfully</span><br/><br/>"
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub
End Class