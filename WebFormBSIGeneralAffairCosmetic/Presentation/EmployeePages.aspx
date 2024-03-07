<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="EmployeePages.aspx.vb" Inherits="WebFormBSIGeneralAffairCosmetic.EmployeePages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">List Of Employees</h1>
    </div>

    <div class="col-lg-12">
        <!-- Basic Card Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">List of Employees</h6>
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
                                    Add Employee
                                </button>
                            </div>
                        </div>
                        <hr />
                        <asp:GridView ID="gvEmployees" CssClass="table table-hover" ItemType="BSIGeneralAffairBLL.DTO.Employee.EmployeeListDTO"
                            SelectMethod="GetAll" UpdateMethod="Update" DeleteMethod="Delete"
                            DataKeyNames="EmployeeID,Fullname" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Number ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeNumber" runat="server" Text='<%# item.EmployeeID %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFullName" runat="server" Text='<%# Item.Fullname %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Position">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPosition" runat="server" Text='<%# Item.Position %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gender">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGender" runat="server" Text='<%#  If(Eval("Gender") = "M", "Male", "Female") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Department">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDepartment" runat="server" Text='<%# Item.Department %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Office">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOffice" runat="server" Text='<%# Item.Office %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date Hire">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHireDate" runat="server" Text='<%# Item.HireDate %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Action">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-outline-success btn-sm" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="LinkButton2" CssClass="btn btn-outline-default btn-sm" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-outline-warning btn-sm" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="LinkButton2" CssClass="btn btn-outline-danger btn-sm" runat="server" CausesValidation="False" CommandName="Delete"
                                            OnClientClick="return confirm('Apakah anda yakin untuk delete data ?')" Text="Delete"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <asp:Button ID="btnPrev" Text="Prev" CssClass="btn btn-primary" runat="server" OnClick="btnPrev_Click" />&nbsp;
                    <asp:Button ID="btnNext" Text="Next" CssClass="btn btn-primary" OnClick="btnNext_Click" runat="server" />&nbsp;
                    <asp:Literal ID="ltPosition" runat="server" />
                    </div>

                </div>
            </div>

            <div class="modal" id="myModal">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <!-- Modal Header -->
                        <div class="modal-header">
                            <h4 class="modal-title">Add Employee</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <label for="txtFirstName">First name :<span class="text-danger">*</span> </label>
                                        <asp:TextBox ID="txtFirstname" runat="server" CssClass="form-control" placeholder="Enter First Name" />
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group">
                                        <label for="txtLastName">Last name :</label>
                                        <asp:TextBox ID="txtLastname" runat="server" CssClass="form-control" placeholder="Enter Last Name" />
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="txtEmployeeNumber">Employee Number :<span class="text-danger">*</span> </label>
                                <asp:TextBox ID="txtEmployeeNumber" runat="server" CssClass="form-control" placeholder="Enter Employee Number" />
                            </div>

                            <div class="form-group">
                                <label for="ddDepartement">Department  :<span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddDepartment" CssClass="form-control" runat="server" />
                            </div>

                            <div class="form-group">
                                <label for="ddOffice">Office  :<span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddOffice" CssClass="form-control" runat="server" />
                            </div>

                            <div class="form-group">
                                <label for="ddPositionLevel">level  :<span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddPositionLevel" CssClass="form-control" runat="server" />
                            </div>

                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <label for="txtJobTitle">Position :<span class="text-danger">*</span> </label>
                                        <asp:TextBox ID="txtJobTitle" runat="server" CssClass="form-control" placeholder="Enter Job Title Number" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="ddTypeStaff">Type Staff :<span class="text-danger">*</span> </label>
                                    <asp:DropDownList ID="ddTypeStaff" CssClass="form-control" runat="server" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="txtSalary">Salary :<span class="text-danger">*</span> </label>
                                <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" placeholder="Enter Salary Number" />
                            </div>

                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <label for="ddGender">Gender  :<span class="text-danger">*</span></label>
                                        <asp:DropDownList ID="ddGender" CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group">
                                        <label for="ddMarital">Marital Status  :<span class="text-danger">*</span></label>
                                        <asp:DropDownList ID="ddMarital" CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <label for="txtBirtDate">Birt Date  :</label>
                                        <asp:TextBox ID="txtBirtDate" runat="server" CssClass="form-control" placeholder="Birth date.... " TextMode="Date" />
                                        <%--<asp:CalendarExtender ID="calBirtDate" runat="server" TargetControlID="txtBirtDate" Format="yyyy-MM-dd" />--%>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group">
                                        <label for="txtBirtDate">Hire Date  :<span class="text-danger">*</span></label>
                                        <asp:TextBox ID="txtHireDate" runat="server" CssClass="form-control" placeholder="Hire date.... " TextMode="Date" />
                                        <%--<asp:CalendarExtender ID="calHireDate" runat="server" TargetControlID="txtHireDate" Format="yyyy-MM-dd" />--%>
                                    </div>
                                </div>
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
