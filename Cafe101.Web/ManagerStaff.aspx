<%@ page title="Staff Management"
    language="C#"
    masterpagefile="~/Site.Master"
    autoeventwireup="true"
    codebehind="ManagerStaff.aspx.cs"
    inherits="Cafe101.Web.ManagerStaff" %>


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
                        runat="server"></asp:Label>

                </div>


                <div>


                    <strong>

                        <asp:Label
                            ID="lblTopManagerName"
                            runat="server"></asp:Label>

                    </strong>


                    <small>

                        <asp:Label
                            ID="lblTopManagerRole"
                            runat="server"></asp:Label>

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



                <nav class="staff-nav" aria-label="Manager navigation">
                    <%-- Keep all management links available on every manager page. --%>
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

                    <a href="ManagerStaff.aspx" class="active" aria-current="page" aria-label="Staff">
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
                        OnClick="LnkLogout_Click">

                        <span class="staff-nav-icon">&#10140;
                        </span>

                        <span class="staff-nav-text">Logout
                        </span>

                    </asp:LinkButton>


                </div>


            </aside>



            <%-- =================================================
                 MAIN AREA
                 ================================================= --%>

            <main class="staff-main">


                <div class="staff-page-heading">

                    <h3>Staff Management
                    </h3>

                    <p>
                        View and manage Cafe101 employee accounts,
                        roles and account status.
                    </p>

                </div>



                <asp:Label
                    ID="lblMessage"
                    runat="server"
                    CssClass="d-none"></asp:Label>



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

                        <asp:Button
                            ID="btnSearch"
                            runat="server"
                            Text="Search"
                            CssClass="btn btn-brand"
                            OnClick="BtnSearch_Click" />


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

                            <span class="staff-metric-label">TOTAL STAFF
                            </span>


                            <h3>

                                <asp:Label
                                    ID="lblTotalStaff"
                                    runat="server"></asp:Label>

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

                            <span class="staff-metric-label">ACTIVE STAFF
                            </span>


                            <h3>

                                <asp:Label
                                    ID="lblActiveStaff"
                                    runat="server"></asp:Label>

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

                            <span class="staff-metric-label">ACTIVE MANAGERS
                            </span>


                            <h3>

                                <asp:Label
                                    ID="lblManagers"
                                    runat="server"></asp:Label>

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

                            <span class="staff-metric-label">ACTIVE KITCHEN STAFF
                            </span>


                            <h3>

                                <asp:Label
                                    ID="lblKitchenStaff"
                                    runat="server"></asp:Label>

                            </h3>


                            <p>
                                Kitchen employee accounts
                            </p>

                        </div>


                    </div>


                </div>

                <asp:HiddenField ID="hdnStaffPanelOpen"
                    runat="server"
                    ClientIDMode="Static"
                    Value="0" />

                <%-- =================================================
                     WORKSPACE
                     ================================================= --%>

                <div id="staffWorkspace" class="manager-menu-workspace">


                    <%-- =================================================
                         EMPLOYEE TABLE
                         ================================================= --%>

                    <section class="staff-dashboard-panel manager-staff-table-card">


                        <div class="staff-panel-heading">


                            <div>

                                <h5>All Staff Members
                                </h5>

                                <small>Live data from EmployeeTable
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


                                        <itemtemplate>


                                            <tr>


                                                <td>

                                                    <strong>#<%#
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
                                                        OnClientClick="document.getElementById('hdnStaffPanelOpen').value='1';"
                                                        runat="server"
                                                        CssClass="btn btn-sm btn-outline-brand"
                                                        CommandArgument='<%#
                                                            Eval("EmployeeID")
                                                        %>'
                                                        OnCommand="SelectEmployee_Command">
                                                        View

                                                    </asp:LinkButton>


                                                </td>


                                            </tr>


                                        </itemtemplate>


                                    </asp:Repeater>


                                </tbody>


                            </table>


                        </div>



                       
<div class="manager-orders-pagination">

    <div class="d-flex align-items-center gap-2">

        <asp:Button
            ID="btnPreviousStaff"
            runat="server"
            Text="Previous"
            CssClass="btn btn-outline-brand btn-sm"
            OnClick="BtnPreviousStaff_Click" />

        <asp:Label
            ID="lblStaffPage"
            runat="server"
            CssClass="small" />

        <asp:Button
            ID="btnNextStaff"
            runat="server"
            Text="Next"
            CssClass="btn btn-outline-brand btn-sm"
            OnClick="BtnNextStaff_Click" />

    </div>

    <small>
        <asp:Label
            ID="lblShowingStaff"
            runat="server" />
    </small>

</div>



                    </section>



                    <%-- =================================================
                         SELECTED EMPLOYEE
                         ================================================= --%>

                    <asp:Panel
                        ID="pnlSelectedEmployee"
                        runat="server"
                        ClientIDMode="Static"
                        CssClass="staff-dashboard-panel manager-selected-item staff-details-panel">

                        <button type="button"
                            id="btnCloseStaffDetails"
                            class="manager-details-close"
                            aria-label="Close employee details"
                            title="Close details">
                            &times;
                        </button>
                        <div class="manager-selected-item-heading">

                            <h5>Selected Employee
                            </h5>

                        </div>



                        <div class="manager-selected-product">


                            <div class="manager-selected-product-image">

                                <asp:Label
                                    ID="lblSelectedInitials"
                                    runat="server"></asp:Label>

                            </div>



                            <div>


                                <h4>

                                    <asp:Label
                                        ID="lblSelectedName"
                                        runat="server"></asp:Label>

                                </h4>


                                <span class="manager-menu-status status-available">

                                    <asp:Label
                                        ID="lblSelectedRole"
                                        runat="server"></asp:Label>

                                </span>


                            </div>


                        </div>



                        <div class="manager-selected-info">


                            <div class="manager-selected-info-row">

                                <span>Employee ID
                                </span>


                                <strong>

                                    <asp:Label
                                        ID="lblSelectedEmployeeID"
                                        runat="server"></asp:Label>

                                </strong>

                            </div>



                            <div class="manager-selected-info-row">

                                <span>Email
                                </span>


                                <strong>

                                    <asp:Label
                                        ID="lblSelectedEmail"
                                        runat="server"></asp:Label>

                                </strong>

                            </div>



                            <div class="manager-selected-info-row">

                                <span>Role
                                </span>


                                <strong>

                                    <asp:Label
                                        ID="lblSelectedRoleDetail"
                                        runat="server"></asp:Label>

                                </strong>

                            </div>



                            <div class="manager-selected-info-row">

                                <span>Status
                                </span>


                                <strong>

                                    <asp:Label
                                        ID="lblSelectedStatus"
                                        runat="server"></asp:Label>

                                </strong>

                            </div>



                            <div class="manager-selected-info-row">

                                <span>Hire Date
                                </span>


                                <strong>

                                    <asp:Label
                                        ID="lblSelectedHireDate"
                                        runat="server"></asp:Label>

                                </strong>

                            </div>



                            <div class="manager-selected-description">

                                <small class="staff-detail-label">ADDRESS
                                </small>


                                <p>

                                    <asp:Label
                                        ID="lblSelectedAddress"
                                        runat="server"></asp:Label>

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


    <style>
        /* STAFF WORKSPACE - SAME SLIDE STYLE AS ORDERS */
        #staffWorkspace {
            display: grid;
            grid-template-columns: minmax(0, 1fr) minmax(0, 0px);
            align-items: start;
            gap: 0;
            transition: grid-template-columns .35s ease, gap .35s ease;
        }

            #staffWorkspace.details-open {
                grid-template-columns: minmax(0, 1fr) minmax(0, 420px);
                gap: 14px;
            }

            #staffWorkspace .manager-staff-table-card {
                min-width: 0;
                width: 100%;
            }

            #staffWorkspace .table-responsive {
                overflow-x: auto;
            }

            #staffWorkspace .manager-staff-table {
                width: 100%;
                min-width: 760px;
                font-size: 13px;
            }

                #staffWorkspace .manager-staff-table th,
                #staffWorkspace .manager-staff-table td {
                    font-size: 13px;
                    padding: 11px 10px;
                    vertical-align: middle;
                }

            /* SELECTED EMPLOYEE SLIDE */
            #staffWorkspace .staff-details-panel {
                box-sizing: border-box;
                position: sticky;
                top: 90px;
                width: 100%;
                min-width: 0;
                padding: 0 !important;
                border-width: 0 !important;
                opacity: 0;
                visibility: hidden;
                pointer-events: none;
                transform: translateX(45px);
                overflow: hidden;
                transition: opacity .35s ease, transform .35s ease;
            }

            #staffWorkspace.details-open .staff-details-panel {
                padding: 20px !important;
                border-width: 1px !important;
                opacity: 1;
                visibility: visible;
                pointer-events: auto;
                transform: translateX(0);
                max-height: calc(100vh - 110px);
                overflow-y: auto;
            }

            /* CLOSE BUTTON */
            #staffWorkspace .manager-details-close {
                position: absolute;
                top: 12px;
                right: 12px;
                width: 35px;
                height: 35px;
                border: 0;
                border-radius: 8px;
                background: #ecf0f6;
                color: #1a2d4c;
                font-size: 24px;
                cursor: pointer;
                z-index: 10;
            }

            /* FONT SIZES - MATCH ORDERS */
            #staffWorkspace .manager-selected-item-heading h5 {
                font-size: 18px;
            }

            #staffWorkspace .manager-selected-product h4 {
                font-size: 20px;
            }

            #staffWorkspace .manager-selected-info-row {
                font-size: 14px;
                padding: 10px 0;
            }

                #staffWorkspace .manager-selected-info-row strong {
                    font-size: 14px;
                    overflow-wrap: anywhere;
                }

            #staffWorkspace .staff-detail-label {
                font-size: 12px;
            }

            #staffWorkspace .manager-selected-description p {
                font-size: 14px;
            }

            /* STATUS BADGES */
            #staffWorkspace .manager-staff-status,
            #staffWorkspace .manager-menu-status {
                font-size: 12px !important;
                font-weight: 600;
            }

            /* ACTION BUTTONS */
            #staffWorkspace .manager-selected-actions {
                display: flex;
                justify-content: center;
                width: 100%;
                gap: 10px;
            }

                #staffWorkspace .manager-selected-actions input {
                    width: 100% !important;
                    font-size: 13px;
                    padding: 10px 12px;
                    text-align: center;
                }

        /* SEARCH AND FILTERS */
        .manager-staff-toolbar .form-control,
        .manager-staff-toolbar .btn {
            font-family: inherit !important;
            font-size: 14px !important;
        }

        /* RESPONSIVE SLIDE */
        @media (max-width: 960px) {
            #staffWorkspace.details-open {
                grid-template-columns: minmax(0, 1fr);
            }

            #staffWorkspace .staff-details-panel {
                position: fixed;
                top: 0;
                right: 0;
                bottom: 0;
                width: min(420px, 100vw) !important;
                max-height: 100vh !important;
                z-index: 3000;
                background: white;
            }

            #staffWorkspace.details-open .staff-details-panel {
                padding: 20px !important;
                overflow-y: auto;
            }
        }

        @media (prefers-reduced-motion: reduce) {
            #staffWorkspace,
            #staffWorkspace .staff-details-panel {
                transition: none;
            }
        }
        /* Prevent horizontal scrolling */
        #staffWorkspace .manager-staff-table {
            width: 100% !important;
            min-width: 0 !important;
            table-layout: fixed;
        }

        #staffWorkspace .table-responsive {
            overflow-x: hidden !important;
        }

        #staffWorkspace .manager-staff-table th,
        #staffWorkspace .manager-staff-table td {
            overflow: hidden;
            text-overflow: ellipsis;
            white-space: nowrap;
        }

        /* Hide less important columns while details are open */
        #staffWorkspace.details-open .manager-staff-table th:nth-child(3),
        #staffWorkspace.details-open .manager-staff-table td:nth-child(3),
        #staffWorkspace.details-open .manager-staff-table th:nth-child(6),
        #staffWorkspace.details-open .manager-staff-table td:nth-child(6) {
            display: none;
        }

        #staffWorkspace .manager-staff-table-card {
            min-width: 0 !important;
        }
        /* Staff toolbar alignment */
        .manager-staff-toolbar-left {
            display: flex;
            align-items: center;
            gap: 8px;
            flex-wrap: wrap;
            min-width: 0;
        }

            .manager-staff-toolbar-left .staff-search-box {
                flex: 1 1 260px;
                min-width: 200px;
            }

            .manager-staff-toolbar-left #btnSearch,
            .manager-staff-toolbar-left .btn {
                flex-shrink: 0;
                margin: 0;
                font-size: 13px;
                padding: 10px 16px;
            }

            .manager-staff-toolbar-left .manager-staff-filter {
                flex: 0 1 145px;
                min-width: 130px;
                font-size: 13px;
            }
            
/* STAFF TABLE - CONSISTENT WITH ORDERS */
#staffWorkspace .manager-staff-table {
    width: 100% !important;
    min-width: 0 !important;
    table-layout: fixed;
}

/* Table headings */
#staffWorkspace .manager-staff-table th {
    font-size: 12px !important;
    font-weight: 600;
    color: #667085;
    padding: 12px 8px;
}

/* Table information */
#staffWorkspace .manager-staff-table td {
    font-size: 13px !important;
    padding: 12px 8px;
    vertical-align: middle;
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
}

/* Column widths - full table */
#staffWorkspace .manager-staff-table th:nth-child(1) { width: 7%; }
#staffWorkspace .manager-staff-table th:nth-child(2) { width: 18%; }
#staffWorkspace .manager-staff-table th:nth-child(3) { width: 28%; }
#staffWorkspace .manager-staff-table th:nth-child(4) { width: 14%; }
#staffWorkspace .manager-staff-table th:nth-child(5) { width: 12%; }
#staffWorkspace .manager-staff-table th:nth-child(6) { width: 13%; }
#staffWorkspace .manager-staff-table th:nth-child(7) { width: 8%; }

/* Column widths when details slide is open */
#staffWorkspace.details-open .manager-staff-table th:nth-child(1) { width: 12%; }
#staffWorkspace.details-open .manager-staff-table th:nth-child(2) { width: 32%; }
#staffWorkspace.details-open .manager-staff-table th:nth-child(4) { width: 22%; }
#staffWorkspace.details-open .manager-staff-table th:nth-child(5) { width: 20%; }
#staffWorkspace.details-open .manager-staff-table th:nth-child(7) { width: 14%; }

/* View buttons */
#staffWorkspace .manager-staff-table .btn {
    font-size: 12px !important;
    padding: 5px 12px;
    border: 1px solid #1a2d4c;
    color: #1a2d4c;
    background: white;
    font-weight: 500;
}

#staffWorkspace .manager-staff-table .btn:hover {
    background: #1a2d4c;
    color: white;
}

/* Remove horizontal scrolling */
#staffWorkspace .table-responsive {
    overflow-x: hidden !important;
}
/* FIX STAFF PAGE HORIZONTAL OVERFLOW */
.staff-shell {
    width: 100%;
    max-width: 100%;
    box-sizing: border-box;
    overflow-x: clip;
}

.staff-shell .staff-body {
    width: 100%;
    min-width: 0;
}

.staff-shell .staff-main {
    flex: 1;
    min-width: 0;
    max-width: 100%;
    box-sizing: border-box;
}

#staffWorkspace {
    width: 100%;
    max-width: 100%;
    min-width: 0;
}

#staffWorkspace .manager-staff-table-card {
    min-width: 0;
    max-width: 100%;
}

#staffWorkspace .manager-staff-table {
    width: 100%;
    min-width: 0 !important;
}

    </style>
    
<script>
    document.addEventListener("DOMContentLoaded", function () {

        const workspace = document.getElementById("staffWorkspace");
        const slideState = document.getElementById("hdnStaffPanelOpen");
        const closeButton = document.getElementById("btnCloseStaffDetails");

        if (!workspace || !slideState) {
            return;
        }

        // Open employee details after clicking View
        if (slideState.value === "1") {
            workspace.classList.add("details-open");
        }

        // Close employee details
        if (closeButton) {
            closeButton.addEventListener("click", function () {
                workspace.classList.remove("details-open");
                slideState.value = "0";
            });
        }

    });
</script>

</asp:Content>
