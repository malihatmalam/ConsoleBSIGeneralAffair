<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="WebFormBSIGeneralAffairCosmetic._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Dashboard</h1>
        </div>

        <!-- Content Row -->
        <div class="row">

            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-success shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                    Assets Count
                                </div>
                                <asp:Label ID="lAssetCount" CssClass="h5 mb-0 font-weight-bold text-gray-800" runat="server" />
                            </div>
                            <div class="col-auto">
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-success shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                    Brands Count
                                </div>
                                <asp:Label ID="lBrandCount" CssClass="h5 mb-0 font-weight-bold text-gray-800" runat="server" />
                            </div>
                            <div class="col-auto">
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-success shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                    Total Cost Asset
                                </div>
                                <asp:Label ID="lTotalCostAsset" CssClass="h5 mb-0 font-weight-bold text-gray-800" runat="server" />
                            </div>
                            <div class="col-auto">
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-success shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                    Employee Count
                                </div>
                                <asp:Label ID="lEmployeeCount" CssClass="h5 mb-0 font-weight-bold text-gray-800" runat="server" />
                            </div>
                            <div class="col-auto">
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-success shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                    Procurement Proposal Count
                                </div>
                                <asp:Label ID="lProcurementCount" CssClass="h5 mb-0 font-weight-bold text-gray-800" runat="server" />
                            </div>
                            <div class="col-auto">
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-success shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                    Service Proposal Count
                                </div>
                                <asp:Label ID="lServiceCount" CssClass="h5 mb-0 font-weight-bold text-gray-800" runat="server" />
                            </div>
                            <div class="col-auto">
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-success shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                    Proposal Completed Count
                                </div>
                                <asp:Label ID="lCompletedProposalCount" CssClass="h5 mb-0 font-weight-bold text-gray-800" runat="server" />
                            </div>
                            <div class="col-auto">
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-success shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                    Proposal Reject Count
                                </div>
                                <asp:Label ID="lRejectProposalCount" CssClass="h5 mb-0 font-weight-bold text-gray-800" runat="server" />
                            </div>
                            <div class="col-auto">
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-success shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                    Vendor Count
                                </div>
                                <asp:Label ID="lVendorCount" CssClass="h5 mb-0 font-weight-bold text-gray-800" runat="server" />
                            </div>
                            <div class="col-auto">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    <!-- Content Row -->

    <!-- Content Row -->
    <div class="row">

        <!-- Content Column -->
        <div class="col-lg-12 mb-4">

            <!-- Project Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Waiting Approval Proposal</h6>
                </div>
                <div class="card-body">
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
                                    <asp:HyperLink Text="Approval"
                                        NavigateUrl='<%# eval("ProposalToken", "~/presentation/detailapprovalpages?proposaltoken={0}") %>' CssClass="btn btn-warning btn-sm" runat="server" />
                                    &nbsp;
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                </div>
            </div>

        </div>

    </div>

    </div>
    <!-- /.container-fluid -->

</asp:Content>
