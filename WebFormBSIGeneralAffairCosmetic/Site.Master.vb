Imports BSIGeneralAffairBLL.DTO.User

Public Class SiteMaster
    Inherits MasterPage

    Sub RenderMenu(roleName As String)

        If roleName = "Manager HR" Then
            lbHeaderResource.Visible = True
            hpEmployee.Visible = True
            hpOffice.Visible = True
            hpDepartment.Visible = True

        End If

        If roleName = "Manager GA" Then
            lbHeaderGeneralAffair.Visible = True
            hpVendor.Visible = True
            hpProposal.Visible = True
            hpProcurement.Visible = True
            hpService.Visible = True
            hpBrand.Visible = True
            hpAsset.Visible = True
        End If

        If roleName = "Staff Asset" Then
            lbHeaderGeneralAffair.Visible = True
            hpProposal.Visible = True
            hpService.Visible = True
            hpBrand.Visible = True
            hpAsset.Visible = True
            hpCategory.Visible = True
        End If

        If roleName = "Staff Procurement" Then
            lbHeaderGeneralAffair.Visible = True
            hpProposal.Visible = True
            hpProcurement.Visible = True
            hpVendor.Visible = True
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim sb As New StringBuilder()

        If Not Page.IsPostBack Then
            If Session("User") IsNot Nothing Then
                Dim _userDto As UserDTO = CType(Session("User"), UserDTO)
                ltUsername.Text = _userDto.UserFirstName & " " & _userDto.UserLastName
                pnlAnonymous.Visible = False
                pnlLoggedIn.Visible = True

                hpEmployee.Visible = False

                RenderMenu(_userDto.UserRole)
            Else
                ltUsername.Text = "Guest"
                pnlAnonymous.Visible = True
                pnlLoggedIn.Visible = False
            End If
        End If
    End Sub
End Class