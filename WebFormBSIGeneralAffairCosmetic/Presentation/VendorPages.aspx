<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="VendorPages.aspx.vb" Inherits="WebFormBSIGeneralAffairCosmetic.VendorPages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">List Of Vendors</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">List Of Vendors</h6>
                </div>
                <div class="card-body">

                    <asp:Literal ID="ltMessage" runat="server" /><br />
                    <br />

                    <div class="row">
                        <br />
                        <div class="col-lg-6">
                            <div class="row">
                                <div class="col">
                                    <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server" />
                                </div>
                                <div class="col">
                                    <asp:Button ID="btnSearch" Text="Search" CssClass="btn btn-success" runat="server" OnClick="btnSearch_Click1"/>
                                </div>
                            </div>
                            <br />
                            <asp:GridView ID="gvVendors"
                                CssClass="table table-hover" DataKeyNames="VendorID" AutoGenerateColumns="false"
                                OnRowCommand="gvVendors_RowCommand"
                                runat="server">
                                <Columns>
                                    <asp:BoundField DataField="VendorID" HeaderText="ID" />
                                    <asp:BoundField DataField="vendorName" HeaderText="Name" />
                                    <asp:BoundField DataField="vendorAddress" HeaderText="Address" />
                                    <asp:CommandField ShowSelectButton="True" HeaderText="Action" />
                                </Columns>
                            </asp:GridView>
                            <hr />

                        </div>

                        <div class="col-lg-6">
                            <div class="mb-3 mt-3">
                                <label for="txtVendorID" class="form-label">Vendor ID :</label>
                                <asp:TextBox ID="txtVendorID" runat="server" ReadOnly="true" CssClass="form-control" />
                            </div>
                            <div class="mb-3">
                                <label for="txtVendorName" class="form-label">Vendor Name :</label>
                                <asp:TextBox ID="txtVendorName" runat="server" CssClass="form-control" />
                            </div>
                            <div class="mb-3">
                                <label for="txtVendorAddress" class="form-label">Vendor Address :</label>
                                <asp:TextBox ID="txtVendorAddress" runat="server" CssClass="form-control" />
                            </div>
                            <asp:Button ID="btnEdit" Text="Edit" CssClass="btn btn-primary" runat="server" OnClick="btnEdit_Click" />&nbsp;
                            <asp:Button ID="btnAdd" Text="Add" CssClass="btn btn-danger" runat="server" OnClick="btnAdd_Click" />&nbsp;
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" Enabled="false" runat="server" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
