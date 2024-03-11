Imports System.Web.ModelBinding
Imports BSIGeneralAffairBLL
Imports BSIGeneralAffairBLL.DTO.Departement
Imports BSIGeneralAffairBLL.DTO.Proposal
Imports BSIGeneralAffairBLL.Interfaces

Public Class HistoryProposalPages
    Inherits System.Web.UI.Page

    Dim _proposalBLL As New ProposalBLL()

#Region "Initiate"
    Sub InitiateButtonNavigation()
        Dim maxPage = 0
        Dim pagediv = CInt(ViewState("RecordCountl")) Mod CInt(ViewState("PageSize"))

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

        ViewState("RecordCount") = _proposalBLL.GetCount("Procurement", txtSearch.Text)
        ltPosition.Text = "Page " & ViewState("PageNumber") & " of " & maxPage
    End Sub
#End Region

    Public Function GetAll(<Control("txtSearch")> name As String) As List(Of ProposalDTO)
        'Return _categoryBLL.GetWithPaging(2, 5)
        Return _proposalBLL.GetHistoryProposal("Procurement", CInt(ViewState("PageNumber")), CInt(ViewState("PageSize")), name)
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("User") Is Nothing Then
                Response.Redirect("~/Presentation/LoginPages.aspx")
            End If

            ViewState("PageNumber") = 1
            ViewState("PageSize") = 5
        End If

        ViewState("RecordCount") = _proposalBLL.GetCount("Procurement", txtSearch.Text)
        InitiateButtonNavigation()

    End Sub
    Protected Sub btnNext_Click(sender As Object, e As EventArgs)

        Dim maxPage = Math.Floor(CInt(ViewState("RecordCount")) / CInt(ViewState("PageSize")) + 1)
        If CInt(ViewState("PageNumber")) < maxPage Then
            ViewState("PageNumber") = CInt(ViewState("PageNumber")) + 1
            gvProposals.DataBind()
        Else
            ltMessage.Text = "<span class='alert alert-danger'>You are on the last page</span>"
        End If
        InitiateButtonNavigation()
    End Sub

    Protected Sub btnPrev_Click(sender As Object, e As EventArgs)
        If CInt(ViewState("PageNumber")) > 1 Then
            ViewState("PageNumber") = CInt(ViewState("PageNumber")) - 1
            gvProposals.DataBind()
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