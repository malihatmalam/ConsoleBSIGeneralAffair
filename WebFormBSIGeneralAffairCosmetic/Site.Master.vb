Imports BSIGeneralAffairBLL.DTO.User

Public Class SiteMaster
    Inherits MasterPage

    Function RenderMenu(roleName As String) As String
        Dim _renderManagerHR As String = "<div class='sidebar-heading'>Admin</div>
                <li Class='nav-item'>
                    <a Class='nav-link collapsed' href='Admin/AddUserToRolePage' runat='server'>
                        <i Class='fas fa-fw fa-cog'></i>
                        <span>Add Role</span>
                    </a>
                </li> <hr class='sidebar-divider my-0'>"

        Dim _renderManagerGA As String = "<div class='sidebar-heading'>Admin</div>
                <li Class='nav-item'>
                    <a Class='nav-link collapsed' href='Admin/AddUserToRolePage' runat='server'>
                        <i Class='fas fa-fw fa-cog'></i>
                        <span>Add Role</span>
                    </a>
                </li> <hr class='sidebar-divider my-0'>"

        Dim _renderStaffAsset As String = "<div class='sidebar-heading'>Contributor</div>
                <li Class='nav-item'>
                    <a Class='nav-link collapsed' href='#'>
                        <i Class='fas fa-fw fa-cog'></i>
                        <span>Add Article</span>
                    </a>
                </li> <hr class='sidebar-divider my-0'>"

        Dim _renderStaffProcurement As String = "<div class='sidebar-heading'>Reader</div>
                <li Class='nav-item'>
                    <a Class='nav-link collapsed' href='#'>
                        <i Class='fas fa-fw fa-cog'></i>
                        <span>Read Article</span>
                    </a>
                </li> <hr class='sidebar-divider my-0'>"


        If roleName = "Manager HR" Then
            Return _renderManagerHR
        End If

        If roleName = "Manager GA" Then
            Return _renderManagerGA
        End If

        If roleName = "Staff Asset" Then
            Return _renderStaffAsset
        End If

        If roleName = "Staff Procurement" Then
            Return _renderStaffProcurement
        End If

        Return ""
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim sb As New StringBuilder()

        If Not Page.IsPostBack Then
            If Session("User") IsNot Nothing Then
                Dim _userDto As UserDTO = CType(Session("User"), UserDTO)
                ltUsername.Text = _userDto.UserFirstName & " " & _userDto.UserLastName
                pnlAnonymous.Visible = False
                pnlLoggedIn.Visible = True

                ltMenu.Text = sb.ToString()
            Else
                ltUsername.Text = "Guest"
                pnlAnonymous.Visible = True
                pnlLoggedIn.Visible = False
            End If
        End If
    End Sub
End Class