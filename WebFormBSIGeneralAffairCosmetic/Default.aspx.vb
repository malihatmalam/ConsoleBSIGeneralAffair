Imports System.Web.ModelBinding
Imports BSIGeneralAffairBLL
Imports BSIGeneralAffairBLL.DTO.Proposal

Public Class _Default
    Inherits Page

    Dim _dashboardBLL As New DashboardBLL()
    Dim _proposalBLL As New ProposalBLL()

    Public Function GetAll(<Control("txtSearch")> name As String) As List(Of ProposalDTO)
        'Return _categoryBLL.GetWithPaging(2, 5)
        Dim user = Session("User")
        Return _proposalBLL.GetWaitingProposal(user.Employee.EmployeeIDNumber)
    End Function

    Sub GetDashboardData()
        Dim dashboardData = _dashboardBLL.GetDashboard()
        lAssetCount.Text = CInt(dashboardData.CountAssets)
        lBrandCount.Text = CInt(dashboardData.CountBrands)
        lTotalCostAsset.Text = CInt(dashboardData.TotalCostAssets)
        lEmployeeCount.Text = CInt(dashboardData.CountEmployees)
        lProcurementCount.Text = CInt(dashboardData.CountProcurement)
        lServiceCount.Text = CInt(dashboardData.CountService)
        lCompletedProposalCount.Text = CInt(dashboardData.CountProposalCompleted)
        lRejectProposalCount.Text = CInt(dashboardData.CountProposalReject)
        lVendorCount.Text = CInt(dashboardData.CountVendors)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("User") Is Nothing Then
                Response.Redirect("~/Presentation/LoginPages.aspx")

            End If
            GetDashboardData()
        End If
    End Sub
End Class