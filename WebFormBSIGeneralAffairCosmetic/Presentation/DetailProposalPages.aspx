<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetailProposalPages.aspx.vb" Inherits="WebFormBSIGeneralAffairCosmetic.DetailProposalPages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Detail Proposal</h1>
    </div>

    <div class="col-lg-12">
        <!-- Basic Card Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Detail Proposal</h6>
            </div>

            <div class="card-body">
                <div class="row">
                    <asp:Literal ID="ltMessage" runat="server" />
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="mb-3 mt-3">
                                    <label for="ddProposalType" class="form-label">Type :</label>
                                    <asp:DropDownList ID="ddProposalType" CssClass="form-control" Enabled="false" runat="server" />
                                </div>
                                <div class="mb-3 mt-3">
                                    <label for="txtProposalToken" class="form-label">Proposal Token :</label>
                                    <asp:TextBox ID="txtProposalToken" CssClass="form-control" runat="server" ReadOnly="true" />
                                </div>
                                <div class="mb-3 mt-3">
                                    <label for="txtProposalObjective" class="form-label">Proposal Objective :</label>
                                    <asp:TextBox ID="txtProposalObjective" CssClass="form-control" runat="server" />
                                </div>
                                <div class="mb-3 mt-3">
                                    <label for="txtProposalDescription" class="form-label">Description :</label>
                                    <asp:TextBox ID="txtProposalDescription" CssClass="form-control" runat="server" TextMode="MultiLine" />
                                </div>
                                <div class="mb-3 mt-3">
                                    <label for="txtProposalRequireDate" class="form-label">Require Date :</label>
                                    <asp:TextBox ID="txtProposalRequireDate" CssClass="form-control" runat="server" />
                                </div>
                                <div class="mb-3 mt-3">
                                    <label for="txtProposalBudget" class="form-label">Budget :</label>
                                    <asp:TextBox ID="txtProposalBudget" CssClass="form-control" runat="server" />
                                </div>
                                <div class="mb-3 mt-3">
                                    <label for="txtProposalNote" class="form-label">Note :</label>
                                    <asp:TextBox ID="txtProposalNote" CssClass="form-control" runat="server" TextMode="MultiLine"/>
                                </div>
                                <div class="mb-3 mt-3">
                                    <label for="txtProposalStatus" class="form-label">Status :</label>
                                    <asp:TextBox ID="txtProposalStatus" CssClass="form-control" runat="server" ReadOnly />
                                </div>
                                <br />
                                <div class="mb-3 mt-3">
                                    <label for="txtEmployeeName" class="form-label">Employee Name :</label>
                                    <asp:TextBox ID="txtEmployeeName" CssClass="form-control" runat="server" ReadOnly />
                                </div>
                                <div class="mb-3 mt-3">
                                    <label for="txtEmployeePosition" class="form-label">Position :</label>
                                    <asp:TextBox ID="txtEmployeePosition" CssClass="form-control" runat="server" ReadOnly />
                                </div>
                                <div class="mb-3 mt-3">
                                    <label for="txtDepartment" class="form-label">Departement :</label>
                                    <asp:TextBox ID="txtDepartment" CssClass="form-control" runat="server" ReadOnly />
                                </div>
                                <hr />
                                <div class="mb-3 mt-3">
                                    <label for="ddVendor" class="form-label">Vendor :</label>
                                    <asp:DropDownList ID="ddVendor" CssClass="form-control" runat="server" AppendDataBoundItems="true" >
                                        <asp:ListItem Selected="True">-- Select Vendor --</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="mb-3 mt-3">
                                    <label for="txtNegotiationNote" class="form-label">Negotiation Note :</label>
                                    <asp:TextBox ID="txtNegotiationNote" CssClass="form-control" runat="server" TextMode="MultiLine"/>
                                </div>
                                <asp:Button Text="Update Proposal" ID="btnAdd" class="btn btn-primary btn-sm" OnClick="btnAdd_Click" runat="server" />
                            </div>
                            <div class="col-lg-6">
                                <%--<div class="row">
                                    <div class="col">
                                        <h3>Approval Proposal : </h3>
                                        <div class="mb-3 mt-3">
                                            <label for="ddApprovalType" class="form-label">Approval Type :</label>
                                            <asp:DropDownList ID="ddApprovalType" CssClass="form-control" runat="server" />
                                        </div>
                                        <div class="mb-3 mt-3">
                                            <label for="txtApprovalReason" class="form-label">Reason :</label>
                                            <asp:TextBox ID="txtApprovalReason" CssClass="form-control" runat="server" TextMode="MultiLine" />
                                        </div>
                                        <asp:Button Text="Approval proposal" ID="btnAddApproval" class="btn btn-primary btn-sm" OnClick="btnAddApproval_Click" runat="server" />
                                    </div>
                                </div>--%>
                                <div class="row">
                                    <div class="col-12">
                                        <br />
                                        <table class="table table-hover">
                                            <asp:ListView ID="lvApprovalHistory"
                                                runat="server">
                                                <LayoutTemplate>
                                                    <thead>
                                                        <tr>
                                                            <th>Approver</th>
                                                            <th>Status</th>
                                                            <th>Reason</th>
                                                            <th>Date</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr id="itemPlaceholder" runat="server"></tr>
                                                    </tbody>
                                                </LayoutTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%# Eval("ApproverName") %> ( <%# Eval("ApproverPosition") %> )</td>
                                                        <td><%# Eval("ApprovalStatus") %> </td>
                                                        <td><%# Eval("ApprovalReason") %></td>
                                                        <td><%# Eval("ApprovalAt") %></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <EmptyItemTemplate>
                                                    <tr>
                                                        <td colspan="7">No records found</td>
                                                    </tr>
                                                </EmptyItemTemplate>
                                            </asp:ListView>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
