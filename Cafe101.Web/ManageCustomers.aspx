<%@ Page Title="Manage Customers"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ManageCustomers.aspx.cs"
    Inherits="Cafe101.Web.ManageCustomers" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div class="staff-shell manager-shell">

        <%-- TOP HEADER --%>
        <header class="staff-header">
            <div class="staff-header-left">
                <button type="button"
                    id="sidebarToggle"
                    class="staff-header-menu"
                    aria-label="Toggle manager navigation">
                    ☰
                </button>
                <div class="staff-header-brand">
                    Cafe101
                </div>
            </div>

            <div class="staff-header-user">
                <div class="staff-header-avatar">
                    <asp:Label
                        ID="lblTopManagerInitials"
                        runat="server">
                    </asp:Label>
                </div>
                <div>
                    <strong>
                        <asp:Label
                            ID="lblTopManagerName"
                            runat="server">
                        </asp:Label>
                    </strong>
                    <small>
                        <asp:Label
                            ID="lblTopManagerRole"
                            runat="server">
                        </asp:Label>
                    </small>
                </div>
            </div>
        </header>

        <%-- BODY --%>
        <div class="staff-body">

            <%-- SIDEBAR --%>
            <aside class="staff-sidebar">
                <div class="staff-sidebar-title">
                    MANAGER SYSTEM
                </div>

                <nav class="staff-nav" aria-label="Manager navigation">
                    <a href="ManagerDashboard.aspx" aria-label="Dashboard">
                        <span class="staff-nav-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" width="19" height="19"
                                fill="none" stroke="currentColor" stroke-width="2">
                                <path d="M3 10l9-7 9 7M5 9v12h14V9M9 21v-8h6v8" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Dashboard</span>
                    </a>

                    <a href="ManagerOrders.aspx" aria-label="Orders">
                        <span class="staff-nav-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" width="19" height="19"
                                fill="none" stroke="currentColor" stroke-width="2">
                                <path d="M6 3h12v18H6zM9 8h6M9 12h6M9 16h4" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Orders</span>
                    </a>

                    <a href="ManageCustomers.aspx" class="active" aria-current="page" aria-label="Customers">
                        <span class="staff-nav-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" width="19" height="19"
                                fill="none" stroke="currentColor" stroke-width="2">
                                <path d="M17 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2"></path>
                                <circle cx="9" cy="7" r="4"></circle>
                                <path d="M23 21v-2a4 4 0 0 0-3-3.87"></path>
                                <path d="M16 3.13a4 4 0 0 1 0 7.75"></path>
                            </svg>
                        </span>
                        <span class="staff-nav-text">Customers</span>
                    </a>

                    <a href="ManagerMenu.aspx" aria-label="Menu">
                        <span class="staff-nav-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" width="19" height="19"
                                fill="none" stroke="currentColor" stroke-width="2">
                                <path d="M4 4h16v16H4zM8 8h8M8 12h8M8 16h5" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Menu</span>
                    </a>

                    <a href="ManageIngredients.aspx" aria-label="Ingredients">
                        <span class="staff-nav-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" width="19" height="19"
                                fill="none" stroke="currentColor" stroke-width="2">
                                <path d="M4 7h16v14H4zM3 3h18v4H3zM9 11h6" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Ingredients</span>
                    </a>

                    <a href="ManageRecipes.aspx" aria-label="Recipes">
                        <span class="staff-nav-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" width="19" height="19"
                                fill="none" stroke="currentColor" stroke-width="2">
                                <path d="M5 3h14v18H5zM8 7h8M8 11h8M8 15h5" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Recipes</span>
                    </a>

                    <a href="ManagerStaff.aspx" aria-label="Staff">
                        <span class="staff-nav-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" width="19" height="19"
                                fill="none" stroke="currentColor" stroke-width="2">
                                <circle cx="9" cy="8" r="3" /><circle cx="17" cy="10" r="2" /><path d="M3 20c0-4 2.5-7 6-7s6 3 6 7M15 15c3 0 5 2 5 5" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Staff</span>
                    </a>

                    <a href="ManagerReports.aspx" aria-label="Reports">
                        <span class="staff-nav-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" width="19" height="19"
                                fill="none" stroke="currentColor" stroke-width="2">
                                <path d="M4 20V10M10 20V4M16 20v-7M22 20H2" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Reports</span>
                    </a>

                    <a href="ManagerProfile.aspx" aria-label="Profile">
                        <span class="staff-nav-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" width="19" height="19"
                                fill="none" stroke="currentColor" stroke-width="2">
                                <circle cx="12" cy="8" r="4" /><path d="M4 21c0-4 3.5-7 8-7s8 3 8 7" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Profile</span>
                    </a>
                </nav>

                <div class="staff-sidebar-bottom">
                    <asp:LinkButton
                        ID="lnkLogout"
                        runat="server"
                        CssClass="staff-logout"
                        OnClick="lnkLogout_Click">
                        <span class="staff-nav-icon">&#10140;</span>
                        <span class="staff-nav-text">Logout</span>
                    </asp:LinkButton>
                </div>
            </aside>

            <%-- MAIN CONTENT AREA --%>
            <main class="staff-main">

                <div class="staff-page-heading">
                    <h3>Manage Customers</h3>
                    <p>Maintain customer accounts, update details, reset passwords, and manage customer status.</p>
                </div>

                <asp:Label ID="lblCustomerMessage" runat="server" CssClass="d-block mb-3" EnableViewState="false"></asp:Label>

                <%-- SEARCH SECTION --%>
                <section class="staff-dashboard-panel mb-4" style="padding: 20px;">
                    <div style="font-weight: 600; margin-bottom: 8px;">Search Customers</div>
                    <div style="display: flex; gap: 10px; align-items: center; flex-wrap: wrap;">
                        <asp:TextBox
                            ID="txtSearch"
                            runat="server"
                            CssClass="form-control"
                            placeholder="Name, surname, or email..."
                            style="max-width: 350px; flex: 1;">
                        </asp:TextBox>
                        <asp:Button
                            ID="btnSearch"
                            runat="server"
                            Text="Search"
                            style="background-color: #1e293b; color: #ffffff; border: 1px solid #1e293b; padding: 6px 16px; border-radius: 4px; font-weight: 500;"
                            OnClick="btnSearch_Click" />
                        <asp:Button
                            ID="btnClearSearch"
                            runat="server"
                            Text="Clear"
                            style="background-color: transparent; color: #475569; border: 1px solid #cbd5e1; padding: 6px 16px; border-radius: 4px; font-weight: 500;"
                            OnClick="btnClearSearch_Click" />
                        <asp:Button
                            ID="btnRefreshCustomers"
                            runat="server"
                            Text="Refresh"
                            style="background-color: transparent; color: #475569; border: 1px solid #cbd5e1; padding: 6px 16px; border-radius: 4px; font-weight: 500;"
                            OnClick="btnRefreshCustomers_Click" />
                    </div>
                </section>

                <%-- DETAILS / EDIT SECTION --%>
                <section class="staff-dashboard-panel mb-4" style="padding: 20px;">
                    <div style="font-weight: 600; font-size: 1.1rem; margin-bottom: 2px;">Customer Details</div>
                    <asp:Label ID="lblCustomerSelection" runat="server" CssClass="text-muted small d-block mb-3" Text="New customer account"></asp:Label>

                    <div style="display: grid; grid-template-columns: repeat(auto-fit, minmax(250px, 1fr)); gap: 16px; margin-bottom: 16px;">
                        <div>
                            <label class="form-label font-weight-bold">First Name</label>
                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="First name"></asp:TextBox>
                            <asp:Label ID="lblFirstNameStatus" runat="server" CssClass="text-danger small mt-1 d-block"></asp:Label>
                        </div>
                        <div>
                            <label class="form-label font-weight-bold">Surname</label>
                            <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" placeholder="Surname"></asp:TextBox>
                            <asp:Label ID="lblSurnameStatus" runat="server" CssClass="text-danger small mt-1 d-block"></asp:Label>
                        </div>
                        <div>
                            <label class="form-label font-weight-bold">Email Address</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="email@domain.com" TextMode="Email"></asp:TextBox>
                            <asp:Label ID="lblEmailStatus" runat="server" CssClass="text-danger small mt-1 d-block"></asp:Label>
                        </div>
                        <div>
                            <label class="form-label font-weight-bold">Status</label>
                            <asp:DropDownList ID="cmbStatus" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Active" Value="Active" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Inactive" Value="Inactive"></asp:ListItem>
                                <asp:ListItem Text="Suspended" Value="Suspended"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="mb-3">
                        <label class="form-label font-weight-bold">Address</label>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="46 Lion Road, Amanzimtoti, Durban"></asp:TextBox>
                        <asp:Label ID="lblAddressStatus" runat="server" CssClass="text-danger small mt-1 d-block"></asp:Label>
                    </div>

                    <%-- BUTTONS --%>
                    <div style="display: flex; gap: 10px; flex-wrap: wrap;">
                        <asp:Button
                            ID="btnAddCustomer"
                            runat="server"
                            Text="Add customer"
                            style="background-color: #1e293b; color: #ffffff; border: 1px solid #1e293b; padding: 6px 16px; border-radius: 4px; font-weight: 500;"
                            OnClick="btnAddCustomer_Click" />

                        <asp:Button
                            ID="btnUpdateCustomer"
                            runat="server"
                            Text="Update customer"
                            style="background-color: transparent; color: #3b82f6; border: 1px solid #3b82f6; padding: 6px 16px; border-radius: 4px; font-weight: 500;"
                            Enabled="false"
                            OnClick="btnUpdateCustomer_Click" />

                        <asp:Button
                            ID="btnDeleteCustomer"
                            runat="server"
                            Text="Remove customer"
                            style="background-color: transparent; color: #ef4444; border: 1px solid #ef4444; padding: 6px 16px; border-radius: 4px; font-weight: 500;"
                            Enabled="false"
                            OnClientClick="return confirm('Are you sure you want to delete this customer?');"
                            OnClick="btnDeleteCustomer_Click" />

                        <asp:Button
                            ID="btnResetPassword"
                            runat="server"
                            Text="Reset Password"
                            style="background-color: transparent; color: #f59e0b; border: 1px solid #f59e0b; padding: 6px 16px; border-radius: 4px; font-weight: 500;"
                            Enabled="false"
                            OnClick="btnResetPassword_Click" />

                        <asp:Button
                            ID="btnNewCustomer"
                            runat="server"
                            Text="Clear form"
                            style="background-color: transparent; color: #64748b; border: 1px solid #cbd5e1; padding: 6px 16px; border-radius: 4px; font-weight: 500;"
                            OnClick="btnNewCustomer_Click" />
                    </div>
                </section>

                <%-- CUSTOMER LIST GRID --%>
                <section class="staff-dashboard-panel" style="padding: 20px;">
                    <div style="font-weight: 600; font-size: 1.1rem; margin-bottom: 12px;">Customer List</div>
                    <div class="table-responsive">
                        <asp:GridView
                            ID="gvCustomers"
                            runat="server"
                            CssClass="table table-striped table-hover align-middle"
                            AutoGenerateColumns="False"
                            DataKeyNames="CustomerID"
                            OnSelectedIndexChanged="gvCustomers_SelectedIndexChanged"
                            AllowPaging="true"
                            PageSize="10">
                            <Columns>
                                <asp:BoundField DataField="CustomerID" HeaderText="ID" Visible="false" />
                                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                <asp:BoundField DataField="Surname" HeaderText="Surname" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:BoundField DataField="Address" HeaderText="Address" />
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                <asp:CommandField ShowSelectButton="True" SelectText="Select" ControlStyle-CssClass="btn btn-sm btn-outline-primary" HeaderText="Action" />
                            </Columns>
                            <HeaderStyle CssClass="table-dark" />
                        </asp:GridView>
                    </div>
                </section>

                <div class="staff-footer" style="margin-top: 30px; text-align: center; color: #6c757d;">
                    © 2026 Cafe101 Manager System
                </div>

            </main>
        </div>

    </div>

    <script>
        document.body.classList.add("staff-page");

        const publicNavbar = document.querySelector(".navbar");
        if (publicNavbar) publicNavbar.style.display = "none";

        const bodyContent = document.querySelector(".body-content");
        if (bodyContent) {
            bodyContent.classList.remove("container");
            bodyContent.style.width = "100%";
            bodyContent.style.maxWidth = "none";
            bodyContent.style.margin = "0";
            bodyContent.style.padding = "0";
        }

        const masterFooter = document.querySelector(".body-content > footer");
        if (masterFooter) masterFooter.style.display = "none";

        const masterFooterLine = document.querySelector(".body-content > hr");
        if (masterFooterLine) masterFooterLine.style.display = "none";
    </script>

</asp:Content>