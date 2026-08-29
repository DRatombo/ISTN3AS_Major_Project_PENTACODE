<%@ Page Title="Staff Management"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ManagerStaff.aspx.cs"
    Inherits="Cafe101.Web.ManagerStaff" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


    <div class="staff-shell manager-shell">


        <%-- =================================================
             TOP HEADER
             ================================================= --%>

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



            <a href="ManagerProfile.aspx"
                class="staff-header-user text-decoration-none">


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


            </a>


        </header>



        <div class="staff-body">


            <%-- =================================================
                 SIDEBAR
                 ================================================= --%>

            <aside class="staff-sidebar">


                <div class="staff-sidebar-title">
                    MANAGER SYSTEM
                </div>



                <nav class="staff-nav">


                    <a href="ManagerDashboard.aspx">

                        <span class="staff-nav-icon">
                            &#8962;
                        </span>

                        <span class="staff-nav-text">
                            Dashboard
                        </span>

                    </a>



                    <a href="ManagerOrders.aspx">

                        <span class="staff-nav-icon">

                            <svg viewBox="0 0 24 24"
                                width="19"
                                height="19"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <path d="M6 3h12v18H6z" />
                                <path d="M9 8h6" />
                                <path d="M9 12h6" />
                                <path d="M9 16h4" />

                            </svg>

                        </span>

                        <span class="staff-nav-text">
                            Orders
                        </span>

                    </a>



                    <a href="ManagerMenu.aspx">

                        <span class="staff-nav-icon">

                            <svg viewBox="0 0 24 24"
                                width="19"
                                height="19"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <path d="M4 4h16v16H4z" />
                                <path d="M8 8h8" />
                                <path d="M8 12h8" />
                                <path d="M8 16h5" />

                            </svg>

                        </span>

                        <span class="staff-nav-text">
                            Menu
                        </span>

                    </a>



                    <a href="ManagerStaff.aspx"
                        class="active">

                        <span class="staff-nav-icon">

                            <svg viewBox="0 0 24 24"
                                width="19"
                                height="19"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <circle cx="9"
                                    cy="8"
                                    r="3" />

                                <circle cx="17"
                                    cy="10"
                                    r="2" />

                                <path d="M3 20c0-4 2.5-7 6-7s6 3 6 7" />

                                <path d="M15 15c3 0 5 2 5 5" />

                            </svg>

                        </span>

                        <span class="staff-nav-text">
                            Staff
                        </span>

                    </a>



                    <a href="ManagerReports.aspx">

                        <span class="staff-nav-icon">

                            <svg viewBox="0 0 24 24"
                                width="19"
                                height="19"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <path d="M4 20V10" />
                                <path d="M10 20V4" />
                                <path d="M16 20v-7" />
                                <path d="M22 20H2" />

                            </svg>

                        </span>

                        <span class="staff-nav-text">
                            Reports
                        </span>

                    </a>



                    <a href="ManagerProfile.aspx">

                        <span class="staff-nav-icon">

                            <svg viewBox="0 0 24 24"
                                width="19"
                                height="19"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <circle cx="12"
                                    cy="8"
                                    r="4" />

                                <path d="M4 21c0-4 3.5-7 8-7s8 3 8 7" />

                            </svg>

                        </span>

                        <span class="staff-nav-text">
                            Profile
                        </span>

                    </a>


                </nav>



                <div class="staff-sidebar-bottom">


                    <asp:LinkButton
                        ID="lnkLogout"
                        runat="server"
                        CssClass="staff-logout"
                        OnClick="LnkLogout_Click">

                        <span class="staff-nav-icon">
                            &#10140;
                        </span>

                        <span class="staff-nav-text">
                            Logout
                        </span>

                    </asp:LinkButton>


                </div>


            </aside>



            <%-- =================================================
                 MAIN AREA
                 ================================================= --%>

            <main class="staff-main">


                <div class="staff-page-heading">

                    <h3>
                        Staff Management
                    </h3>

                    <p>
                        View and manage Cafe101 employee accounts,
                        roles and account status.
                    </p>

                </div>



                <asp:Label
                    ID="lblMessage"
                    runat="server"
                    CssClass="d-none">
                </asp:Label>



                <%-- =================================================
                     TOOLBAR
                     ================================================= --%>

                <div class="manager-staff-toolbar">


                    <div class="manager-staff-toolbar-left">


                        <div class="staff-search-box">


                            <span class="staff-search-icon">

                                <svg viewBox="0 0 24 24"
                                    width="18"
                                    height="18"
                                    fill="none"
                                    stroke="currentColor"
                                    stroke-width="2">

                                    <circle cx="10"
                                        cy="10"
                                        r="6" />

                                    <path d="M15 15l5 5" />

                                </svg>

                            </span>


                            <asp:TextBox
                                ID="txtSearch"
                                runat="server"
                                CssClass="form-control"
                                placeholder="Search by name, employee ID or email...">
                            </asp:TextBox>


                        </div>



                        <asp:DropDownList
                            ID="ddlRole"
                            runat="server"
                            CssClass="form-control manager-staff-filter"
                            AutoPostBack="true"
                            OnSelectedIndexChanged="DdlRole_SelectedIndexChanged">
                        </asp:DropDownList>



                        <asp:DropDownList
                            ID="ddlStatus"
                            runat="server"
                            CssClass="form-control manager-staff-filter"
                            AutoPostBack="true"
                            OnSelectedIndexChanged="DdlStatus_SelectedIndexChanged">


                            <asp:ListItem
                                Text="All Statuses"
                                Value="">
                            </asp:ListItem>


                            <asp:ListItem
                                Text="Active"
                                Value="Active">
                            </asp:ListItem>


                            <asp:ListItem
                                Text="Inactive"
                                Value="Inactive">
                            </asp:ListItem>


                        </asp:DropDownList>


                    </div>



                    <div class="manager-staff-toolbar-right">


                        <asp:Button
                            ID="btnSearch"
                            runat="server"
                            Text="Search"
                            CssClass="btn btn-brand"
                            OnClick="BtnSearch_Click" />


                        <asp:Button
                            ID="btnRefresh"
                            runat="server"
                            Text="↻ Refresh"
                            CssClass="btn btn-outline-brand"
                            OnClick="BtnRefresh_Click" />


                    </div>


                </div>



                <%-- =================================================
                     SUMMARY CARDS
                     ================================================= --%>

                <div class="staff-metric-grid">


                    <div class="staff-metric-card">


                        <div class="staff-icon-box icon-green">
                            ♙
                        </div>


                        <div>

                            <span class="staff-metric-label">
                                TOTAL STAFF
                            </span>


                            <h3>

                                <asp:Label
                                    ID="lblTotalStaff"
                                    runat="server">
                                </asp:Label>

                            </h3>


                            <p>
                                All employee accounts
                            </p>

                        </div>


                    </div>



                    <div class="staff-metric-card">


                        <div class="staff-icon-box icon-blue">
                            ✓
                        </div>


                        <div>

                            <span class="staff-metric-label">
                                ACTIVE STAFF
                            </span>


                            <h3>

                                <asp:Label
                                    ID="lblActiveStaff"
                                    runat="server">
                                </asp:Label>

                            </h3>


                            <p>
                                Can currently access system
                            </p>

                        </div>


                    </div>



                    <div class="staff-metric-card">


                        <div class="staff-icon-box icon-orange">
                            ♛
                        </div>


                        <div>

                            <span class="staff-metric-label">
                                ACTIVE MANAGERS
                            </span>


                            <h3>

                                <asp:Label
                                    ID="lblManagers"
                                    runat="server">
                                </asp:Label>

                            </h3>


                            <p>
                                Manager accounts
                            </p>

                        </div>


                    </div>



                    <div class="staff-metric-card">


                        <div class="staff-icon-box icon-purple">
                            ♨
                        </div>


                        <div>

                            <span class="staff-metric-label">
                                ACTIVE KITCHEN STAFF
                            </span>


                            <h3>

                                <asp:Label
                                    ID="lblKitchenStaff"
                                    runat="server">
                                </asp:Label>

                            </h3>


                            <p>
                                Kitchen employee accounts
                            </p>

                        </div>


                    </div>


                </div>



                <%-- =================================================
                     WORKSPACE
                     ================================================= --%>

                <div class="manager-menu-workspace">


                    <%-- =================================================
                         EMPLOYEE TABLE
                         ================================================= --%>

                    <section class="staff-dashboard-panel manager-staff-table-card">


                        <div class="staff-panel-heading">


                            <div>

                                <h5>
                                    All Staff Members
                                </h5>

                                <small>
                                    Live data from EmployeeTable
                                </small>

                            </div>


                        </div>



                        <div class="table-responsive">


                            <table class="table staff-orders-table manager-staff-table">


                                <thead>

                                    <tr>

                                        <th>ID</th>
                                        <th>Name</th>
                                        <th>Email</th>
                                        <th>Role</th>
                                        <th>Status</th>
                                        <th>Hire Date</th>
                                        <th>Action</th>

                                    </tr>

                                </thead>



                                <tbody>


                                    <asp:Repeater
                                        ID="rptEmployees"
                                        runat="server">


                                        <ItemTemplate>


                                            <tr>


                                                <td>

                                                    <strong>

                                                        #<%#
                                                            Eval(
                                                                "EmployeeID")
                                                        %>

                                                    </strong>

                                                </td>



                                                <td>

                                                    <%#
                                                        Eval(
                                                            "FirstName")
                                                    %>

                                                    <%#
                                                        Eval(
                                                            "Surname")
                                                    %>

                                                </td>



                                                <td>

                                                    <%#
                                                        Eval(
                                                            "Email")
                                                    %>

                                                </td>



                                                <td>

                                                    <%#
                                                        Eval(
                                                            "Role")
                                                    %>

                                                </td>



                                                <td>


                                                    <span class='<%#
                                                        GetEmployeeStatusClass(
                                                            Eval(
                                                                "EmployeeStatus")
                                                            .ToString())
                                                    %>'>

                                                        <%#
                                                            Eval(
                                                                "EmployeeStatus")
                                                        %>

                                                    </span>


                                                </td>



                                                <td>

                                                    <%#
                                                        GetHireDateText(
                                                            Eval(
                                                                "HireDate"))
                                                    %>

                                                </td>



                                                <td>


                                                    <asp:LinkButton
                                                        ID="btnViewEmployee"
                                                        runat="server"
                                                        CssClass="manager-staff-view-btn"
                                                        CommandArgument='<%#
                                                            Eval("EmployeeID")
                                                        %>'
                                                        OnCommand="SelectEmployee_Command">

                                                        ›

                                                    </asp:LinkButton>


                                                </td>


                                            </tr>


                                        </ItemTemplate>


                                    </asp:Repeater>


                                </tbody>


                            </table>


                        </div>



                        <div class="manager-orders-pagination">


                            <small>

                                <asp:Label
                                    ID="lblShowingStaff"
                                    runat="server">
                                </asp:Label>

                            </small>


                        </div>


                    </section>



                    <%-- =================================================
                         SELECTED EMPLOYEE
                         ================================================= --%>

                    <asp:Panel
                        ID="pnlSelectedEmployee"
                        runat="server"
                        CssClass="staff-dashboard-panel manager-selected-item">


                        <div class="manager-selected-item-heading">

                            <h5>
                                Selected Employee
                            </h5>

                        </div>



                        <div class="manager-selected-product">


                            <div class="manager-selected-product-image">

                                <asp:Label
                                    ID="lblSelectedInitials"
                                    runat="server">
                                </asp:Label>

                            </div>



                            <div>


                                <h4>

                                    <asp:Label
                                        ID="lblSelectedName"
                                        runat="server">
                                    </asp:Label>

                                </h4>


                                <span class="manager-menu-status status-available">

                                    <asp:Label
                                        ID="lblSelectedRole"
                                        runat="server">
                                    </asp:Label>

                                </span>


                            </div>


                        </div>



                        <div class="manager-selected-info">


                            <div class="manager-selected-info-row">

                                <span>
                                    Employee ID
                                </span>


                                <strong>

                                    <asp:Label
                                        ID="lblSelectedEmployeeID"
                                        runat="server">
                                    </asp:Label>

                                </strong>

                            </div>



                            <div class="manager-selected-info-row">

                                <span>
                                    Email
                                </span>


                                <strong>

                                    <asp:Label
                                        ID="lblSelectedEmail"
                                        runat="server">
                                    </asp:Label>

                                </strong>

                            </div>



                            <div class="manager-selected-info-row">

                                <span>
                                    Role
                                </span>


                                <strong>

                                    <asp:Label
                                        ID="lblSelectedRoleDetail"
                                        runat="server">
                                    </asp:Label>

                                </strong>

                            </div>



                            <div class="manager-selected-info-row">

                                <span>
                                    Status
                                </span>


                                <strong>

                                    <asp:Label
                                        ID="lblSelectedStatus"
                                        runat="server">
                                    </asp:Label>

                                </strong>

                            </div>



                            <div class="manager-selected-info-row">

                                <span>
                                    Hire Date
                                </span>


                                <strong>

                                    <asp:Label
                                        ID="lblSelectedHireDate"
                                        runat="server">
                                    </asp:Label>

                                </strong>

                            </div>



                            <div class="manager-selected-description">

                                <small class="staff-detail-label">
                                    ADDRESS
                                </small>


                                <p>

                                    <asp:Label
                                        ID="lblSelectedAddress"
                                        runat="server">
                                    </asp:Label>

                                </p>

                            </div>


                        </div>



                        <div class="manager-selected-actions">


                            <asp:Button
                                ID="btnToggleStatus"
                                runat="server"
                                Text="Deactivate Employee"
                                CssClass="manager-selected-action manager-selected-action-red"
                                OnClick="BtnToggleStatus_Click"
                                OnClientClick="return confirm('Are you sure you want to change this employee account status?');" />


                        </div>


                    </asp:Panel>


                </div>



                <div class="staff-footer">
                    © 2026 Cafe101 Manager System
                </div>


            </main>


        </div>


    </div>



    <script>

        document.body.classList.add(
            "staff-page");


        const publicNavbar =
            document.querySelector(
                ".navbar");


        if (publicNavbar) {

            publicNavbar.style.display =
                "none";

        }



        const bodyContent =
            document.querySelector(
                ".body-content");


        if (bodyContent) {

            bodyContent.classList.remove(
                "container");

            bodyContent.style.width =
                "100%";

            bodyContent.style.maxWidth =
                "none";

            bodyContent.style.margin =
                "0";

            bodyContent.style.padding =
                "0";

        }



        const masterFooter =
            document.querySelector(
                ".body-content > footer");


        if (masterFooter) {

            masterFooter.style.display =
                "none";

        }



        const masterFooterLine =
            document.querySelector(
                ".body-content > hr");


        if (masterFooterLine) {

            masterFooterLine.style.display =
                "none";

        }



        const sidebarToggle =
            document.getElementById(
                "sidebarToggle");


        const staffBody =
            document.querySelector(
                ".staff-body");


        if (sidebarToggle &&
            staffBody) {

            sidebarToggle
                .addEventListener(
                    "click",
                    function () {

                        staffBody
                            .classList
                            .toggle(
                                "sidebar-collapsed");

                    });

        }

    </script>


</asp:Content>