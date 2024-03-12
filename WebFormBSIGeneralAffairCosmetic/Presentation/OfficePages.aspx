﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="OfficePages.aspx.vb" Inherits="WebFormBSIGeneralAffairCosmetic.OfficePages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">List Of Offices</h1>
    </div>

    <div class="col-lg-12">
        <!-- Basic Card Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">List of Offices</h6>
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
                        <asp:GridView ID="gvOffices" CssClass="table table-hover" ItemType="BSIGeneralAffairBLL.DTO.Office.OfficeDTO"
                            SelectMethod="GetAll" UpdateMethod="Update" DeleteMethod="Delete"
                            DataKeyNames="OfficeID,OfficeName" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Office">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOfficeName" runat="server" Text='<%# Item.OfficeName %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtOfficeName" runat="server" Text='<%# BindItem.OfficeName %>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOfficeAddress" runat="server" Text='<%# Item.OfficeAddress %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtOfficeAddress" runat="server" Text='<%# BindItem.OfficeAddress %>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-outline-success btn-sm" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="LinkButton2" CssClass="btn btn-outline-default btn-sm" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-outline-warning btn-sm" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
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
                    <div class="col-lg-6">
                        <div class="mb-3 mt-3">
                            <label for="txtOfficeName" class="form-label">Office Name :</label>
                            <asp:TextBox ID="txtOfficeName" CssClass="form-control" runat="server" />
                        </div>
                        <div class="mb-3 mt-3">
                            <label for="txtOfficeAddress" class="form-label">Office Address :</label>
                            <asp:TextBox ID="txtOfficeAddress" CssClass="form-control" runat="server" />
                        </div>
                        <asp:Button Text="Add" ID="btnAdd" class="btn btn-primary btn-sm" OnClick="btnAdd_Click" runat="server" />
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
