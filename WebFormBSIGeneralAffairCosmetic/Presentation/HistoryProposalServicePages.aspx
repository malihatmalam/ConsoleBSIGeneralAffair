<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="HistoryProposalServicePages.aspx.vb" Inherits="WebFormBSIGeneralAffairCosmetic.HistoryProposalServicePages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">List Of History Proposal Service</h1>
    </div>

    <div class="col-lg-12">
        <!-- Basic Card Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">List of Proposal Service</h6>
            </div>

            <div class="card-body">
                <div class="row">
                    <asp:Literal ID="ltMessage" runat="server" />
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="row">
                            <div class="col">
                                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col">
                                <asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="btn btn-success btn-sm" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                        <hr />
                    </div>
                    <div class="row">
                        <div class="col-lg-12 ml-2">
                            <asp:GridView ID="gvProposals" CssClass="table table-hover" PageSize="1" runat="server" AutoGenerateColumns="False"
                                SelectMethod="GetAll"
                                ItemType="BSIGeneralAffairBLL.DTO.Proposal.ProposalDTO" DataKeyNames="ProposalToken">
                                <Columns>
                                    <asp:TemplateField HeaderText="Token">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProposalToken" runat="server" Text='<%# Item.ProposalToken %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Departement">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDepartementName" runat="server" Text='<%# Item.DepartementName %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUserFullName" runat="server" Text='<%# Item.UserFullName %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Budget">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProposalBudget" runat="server" Text='<%# Item.ProposalBudget %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Require Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProposalRequireDate" runat="server" Text='<%# Item.ProposalRequireDate %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProposalType" runat="server" Text='<%# Item.ProposalType %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProposalStatus" runat="server" Text='<%# Item.ProposalStatus %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:HyperLink Text="details"
                                                NavigateUrl='<%# eval("ProposalToken", "~/presentation/detailproposalpages?proposaltoken={0}") %>' CssClass="btn btn-success btn-sm" runat="server" />
                                            &nbsp;
                                            <%--<asp:LinkButton ID="LinkButton2" CssClass="btn btn-outline-danger btn-sm" runat="server" CausesValidation="False" CommandName="Delete"
                                                OnClientClick="return confirm('Apakah anda yakin untuk delete data ?')" Text="Delete"></asp:LinkButton>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <br />
                            <asp:Button ID="btnPrev" Text="Prev" CssClass="btn btn-primary" runat="server" OnClick="btnPrev_Click" />&nbsp;
                            <asp:Button ID="btnNext" Text="Next" CssClass="btn btn-primary" OnClick="btnNext_Click" runat="server" />&nbsp;
                            <asp:Literal ID="ltPosition" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>