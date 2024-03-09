<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AssetPages.aspx.vb" Inherits="WebFormBSIGeneralAffairCosmetic.AssetPages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">List Of Assets</h1>
    </div>

    <div class="col-lg-12">
        <!-- Basic Card Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">List Of Assets</h6>
            </div>

            <div class="card-body">
                <div class="row">
                    <asp:Literal ID="ltMessage" runat="server" />
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="col">
                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="col-lg-auto">
                                        <asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="btn btn-success btn-sm" OnClick="btnSearch_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-auto">
                                <button type="button" class="btn btn-primary btn-sm" data-toggle="modal" data-target="#myModal">
                                    Add Asset
                                </button>
                            </div>
                        </div>

                        <hr />
                        <asp:GridView ID="gvAssets" CssClass="table table-hover" ItemType="BSIGeneralAffairBLL.DTO.Asset.AssetDTO"
                            SelectMethod="GetAll" UpdateMethod="Update" DeleteMethod="Delete"
                            DataKeyNames="AssetNumber" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Asset Number">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAssetNumber" runat="server" Text='<%# Item.AssetNumber %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAssetName" runat="server" Text='<%# Item.Name %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Brand">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBrandName" runat="server" Text='<%# Item.AssetBrand %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategoryName" runat="server" Text='<%# Item.AssetCategory %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Factory Number">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFactoryNumber" runat="server" Text='<%# Item.FactoryNumber %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cost">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAssetCost" runat="server" Text='<%# Item.Cost %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Procurement Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProcurementDate" runat="server" Text='<%# Item.ProcurementDate %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Condition">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAssetCondition" runat="server" Text='<%# Item.Condition %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:HyperLink Text="details"
                                            NavigateUrl='<%# eval("AssetNumber", "~/presentation/detailassetpages?assetnumber={0}") %>' CssClass="btn btn-success btn-sm" runat="server" />
                                        &nbsp;<asp:LinkButton ID="LinkButton2" CssClass="btn btn-outline-danger btn-sm" runat="server" CausesValidation="False" CommandName="Delete"
                                            OnClientClick="return confirm('Apakah anda yakin untuk delete data ?')" Text="Delete"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <asp:Button ID="btnPrev" Text="Prev" CssClass="btn btn-primary" runat="server" OnClick="btnPrev_Click" />&nbsp;
                    <asp:Button ID="btnNext" Text="Next" CssClass="btn btn-primary" OnClick="btnNext_Click" runat="server" />&nbsp;
                    <asp:Literal ID="ltPosition" runat="server" />
                </div>
            </div>

            <div class="modal" id="myModal">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <!-- Modal Header -->
                        <div class="modal-header">
                            <h4 class="modal-title">Add Asset</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label for="txtAssetNumber">Asset number :<span class="text-danger">*</span> </label>
                                        <asp:TextBox ID="txtAssetNumber" runat="server" CssClass="form-control" placeholder="Enter Asset Number" />
                                    </div>
                                </div>
                                <div class="col-lg-8">
                                    <div class="form-group">
                                        <label for="txtAssetName">Asset name :<span class="text-danger">*</span> </label>
                                        <asp:TextBox ID="txtAssetName" runat="server" CssClass="form-control" placeholder="Enter Asset Name" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <label for="ddBrand">Brand  :<span class="text-danger">*</span></label>
                                        <asp:DropDownList ID="ddBrand" CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group">
                                        <label for="ddCategory">Category  :<span class="text-danger">*</span></label>
                                        <asp:DropDownList ID="ddCategory" CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="txtFactoryNumber">Factory number :<span class="text-danger">*</span> </label>
                                        <asp:TextBox ID="txtFactoryNumber" runat="server" CssClass="form-control" placeholder="Asset Cost Number" />
                                    </div>
                                </div>

                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="txtProcurementDate">Procurement date :</label>
                                        <asp:TextBox ID="txtProcurementDate" runat="server" CssClass="form-control" placeholder="Procurement date.... " TextMode="Date" />
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="txtCost">Cost :<span class="text-danger">*</span> </label>
                                <asp:TextBox ID="txtCost" runat="server" CssClass="form-control" placeholder="Asset Cost Number" />
                            </div>

                        </div>

                        <!-- Modal footer -->
                        <div class="modal-footer">
                            <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-primary btn-sm"
                                OnClick="btnSubmit_Click" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
