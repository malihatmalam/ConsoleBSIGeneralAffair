<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetailAssetPages.aspx.vb" Inherits="WebFormBSIGeneralAffairCosmetic.DetailAssetPages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Detail Asset</h1>
    </div>

    <div class="col-lg-12">
        <!-- Basic Card Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Detail Asset</h6>
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
                                    <label for="txtAssetNumber" class="form-label">Asset Number :</label>
                                    <asp:TextBox ID="txtAssetNumber" CssClass="form-control" runat="server" />
                                </div>
                                <div class="mb-3 mt-3">
                                    <label for="txtAssetName" class="form-label">Name :</label>
                                    <asp:TextBox ID="txtAssetName" CssClass="form-control" runat="server" />
                                </div>
                                <div class="mb-3 mt-3">
                                    <label for="txtFactoryNumber" class="form-label">Factory Number :</label>
                                    <asp:TextBox ID="txtFactoryNumber" CssClass="form-control" runat="server" />
                                </div>
                                <div class="mb-3 mt-3">
                                    <label for="txtFactoryNumber" class="form-label">Brand :</label>
                                    <asp:DropDownList ID="ddBrand" CssClass="form-control" runat="server" />
                                </div>
                                <div class="mb-3 mt-3">
                                    <label for="txtFactoryNumber" class="form-label">Category :</label>
                                    <asp:DropDownList ID="ddCategory" CssClass="form-control" runat="server" />
                                </div>
                                <div class="mb-3 mt-3">
                                    <label for="txtFactoryNumber" class="form-label">Cost :</label>
                                    <asp:TextBox ID="txtCost" CssClass="form-control" runat="server" />
                                </div>
                                <div class="mb-3 mt-3">
                                    <label for="txtProcurement" class="form-label">Procurement Date :</label>
                                    <asp:TextBox ID="txtProcurement" CssClass="form-control" runat="server" TextMode="Date" />
                                </div>
                                <div class="mb-3 mt-3">
                                    <label for="txtCondition" class="form-label">Condition :</label>
                                    <asp:DropDownList ID="ddCondition" CssClass="form-control" runat="server" />
                                </div>
                                <asp:Button Text="Update Asset" ID="btnAdd" class="btn btn-primary btn-sm" OnClick="btnAdd_Click" runat="server" />
                            </div>
                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="col">
                                        <h3>Handsover Asset : </h3>
                                        <div class="mb-3 mt-3">
                                            <%--<asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" />--%>
                                            <label for="ddUserHandsover" class="form-label">User :</label>
                                            <asp:DropDownList ID="ddUserHandsover" CssClass="form-control" runat="server" />
                                        </div>
                                        <div class="mb-3 mt-3">
                                            <label for="txtHandsoverDate" class="form-label">Handsover Date :</label>
                                            <asp:TextBox ID="txtHandsoverDate" CssClass="form-control" runat="server" TextMode="Date" />
                                        </div>
                                        <asp:Button Text="Handsover Asset" ID="btnAddHandsover" class="btn btn-primary btn-sm" OnClick="btnAddHandsover_Click" runat="server" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12">
                                        <br />
                                        <table class="table table-hover">
                                            <asp:ListView ID="lvUserHandsover1"
                                                runat="server">
                                                <LayoutTemplate>
                                                    <thead>
                                                        <tr>
                                                            <th>Name</th>
                                                            <th>Handsover Date</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr id="itemPlaceholder" runat="server"></tr>
                                                    </tbody>
                                                </LayoutTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%# Eval("Users.UserFullName") %></td>
                                                        <td><%# Eval("HandoverDateTime") %></td>
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
