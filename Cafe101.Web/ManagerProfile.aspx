<%@ Page Title="Manager Profile"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ManagerProfile.aspx.cs"
    Inherits="Cafe101.Web.ManagerProfile" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


    <div class="staff-shell manager-shell">


        <%-- ================================================
             TOP HEADER
             ================================================ --%>

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



            <%-- LOGGED-IN MANAGER --%>

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



        <%-- ================================================
             BODY
             ================================================ --%>

        <div class="staff-body">


            <%-- ================================================
                 SIDEBAR
                 ================================================ --%>

            <aside class="staff-sidebar">


                <div class="staff-sidebar-title">
                    MANAGER SYSTEM
                </div>



                <nav class="staff-nav">


                    <%-- Dashboard --%>

                    <a href="ManagerDashboard.aspx">

                        <span class="staff-nav-icon">

                            <svg viewBox="0 0 24 24"
                                width="19"
                                height="19"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <rect x="3" y="3"
                                    width="7" height="7" />

                                <rect x="14" y="3"
                                    width="7" height="7" />

                                <rect x="3" y="14"
                                    width="7" height="7" />

                                <rect x="14" y="14"
                                    width="7" height="7" />

                            </svg>

                        </span>

                        <span class="staff-nav-text">
                            Dashboard
                        </span>

                    </a>



                    <%-- Orders --%>

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



                    <%-- Menu --%>

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



                    <%-- Staff --%>

                    <a href="ManagerStaff.aspx">

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



                    <%-- Reports --%>

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



                    <%-- Profile --%>

                    <a href="ManagerProfile.aspx"
                        class="active">

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



                <%-- ================================================
                     LOGOUT
                     ================================================ --%>

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



            <%-- ================================================
                 MAIN PROFILE AREA
                 ================================================ --%>

            <main class="staff-main">


                <%-- PAGE HEADING --%>

                <div class="staff-page-heading">


                    <h3>
                        My Profile
                    </h3>


                    <p>
                        View your manager account information.
                    </p>


                </div>



                <%-- ================================================
                     PROFILE SUMMARY
                     ================================================ --%>

                <section class="staff-dashboard-panel staff-profile-summary">


                    <div class="staff-profile-summary-left">


                        <%-- INITIALS --%>

                        <div class="staff-profile-avatar">

                            <asp:Label
                                ID="lblProfileInitials"
                                runat="server">
                            </asp:Label>

                        </div>



                        <div class="staff-profile-main-info">


                            <div class="staff-profile-name-row">


                                <h4>

                                    <asp:Label
                                        ID="lblProfileName"
                                        runat="server">
                                    </asp:Label>

                                </h4>


                                <span class="staff-profile-role-badge">

                                    <asp:Label
                                        ID="lblProfileRole"
                                        runat="server">
                                    </asp:Label>

                                </span>


                            </div>



                            <div class="staff-profile-contact-grid">


                                <%-- EMAIL --%>

                                <div class="staff-profile-contact-item">


                                    <span class="staff-profile-contact-icon">

                                        <svg viewBox="0 0 24 24"
                                            width="17"
                                            height="17"
                                            fill="none"
                                            stroke="currentColor"
                                            stroke-width="2">

                                            <rect x="3"
                                                y="5"
                                                width="18"
                                                height="14"
                                                rx="2" />

                                            <path d="m3 7 9 6 9-6" />

                                        </svg>

                                    </span>


                                    <div>


                                        <small>
                                            Email
                                        </small>


                                        <strong>

                                            <asp:Label
                                                ID="lblProfileEmail"
                                                runat="server">
                                            </asp:Label>

                                        </strong>


                                    </div>


                                </div>



                                <%-- EMPLOYEE ID --%>

                                <div class="staff-profile-contact-item">


                                    <span class="staff-profile-contact-icon">

                                        <svg viewBox="0 0 24 24"
                                            width="17"
                                            height="17"
                                            fill="none"
                                            stroke="currentColor"
                                            stroke-width="2">

                                            <rect x="4"
                                                y="4"
                                                width="16"
                                                height="16"
                                                rx="2" />

                                            <path d="M8 9h8" />
                                            <path d="M8 13h5" />

                                        </svg>

                                    </span>


                                    <div>


                                        <small>
                                            Employee ID
                                        </small>


                                        <strong>

                                            <asp:Label
                                                ID="lblSummaryEmployeeID"
                                                runat="server">
                                            </asp:Label>

                                        </strong>


                                    </div>


                                </div>



                                <%-- STATUS --%>

                                <div class="staff-profile-contact-item">


                                    <span class="staff-profile-contact-icon">

                                        <svg viewBox="0 0 24 24"
                                            width="17"
                                            height="17"
                                            fill="none"
                                            stroke="currentColor"
                                            stroke-width="2">

                                            <circle cx="12"
                                                cy="12"
                                                r="9" />

                                            <path d="M8 12l3 3 5-6" />

                                        </svg>

                                    </span>


                                    <div>


                                        <small>
                                            Account Status
                                        </small>


                                        <strong>
                                            Active
                                        </strong>


                                    </div>


                                </div>


                            </div>


                        </div>


                    </div>


                </section>



                <%-- STATUS / ERROR MESSAGE --%>

                <asp:Label
                    ID="lblProfileMessage"
                    runat="server"
                    CssClass="d-block small mt-3">
                </asp:Label>



                <%-- ================================================
                     PROFILE CONTENT
                     ================================================ --%>

                <div class="staff-profile-content-grid">


                    <%-- ================================================
                         LEFT COLUMN
                         ================================================ --%>

                    <div>


                        <%-- ============================================
                             PERSONAL INFORMATION
                             ============================================ --%>

                        <section class="staff-dashboard-panel staff-profile-info-card">


                            <div class="staff-profile-section-heading">

                                <h5>
                                    Personal Information
                                </h5>

                                <small>
                                    Information stored on your Cafe101 employee account.
                                </small>

                            </div>



                            <%-- FULL NAME --%>

                            <div class="staff-profile-info-row">


                                <span class="staff-profile-info-label">

                                    <span class="staff-profile-small-icon">
                                        ♙
                                    </span>

                                    Full Name

                                </span>


                                <strong>

                                    <asp:Label
                                        ID="lblFullName"
                                        runat="server">
                                    </asp:Label>

                                </strong>


                            </div>



                            <%-- EMAIL --%>

                            <div class="staff-profile-info-row">


                                <span class="staff-profile-info-label">

                                    <span class="staff-profile-small-icon">
                                        ✉
                                    </span>

                                    Email Address

                                </span>


                                <strong>

                                    <asp:Label
                                        ID="lblEmail"
                                        runat="server">
                                    </asp:Label>

                                </strong>


                            </div>



                            <%-- ADDRESS --%>

                            <div class="staff-profile-info-row">


                                <span class="staff-profile-info-label">

                                    <span class="staff-profile-small-icon">
                                        ⌖
                                    </span>

                                    Address

                                </span>


                                <strong>

                                    <asp:Label
                                        ID="lblAddress"
                                        runat="server">
                                    </asp:Label>

                                </strong>


                            </div>



                            <%-- ROLE --%>

                            <div class="staff-profile-info-row">


                                <span class="staff-profile-info-label">

                                    <span class="staff-profile-small-icon">
                                        ♙
                                    </span>

                                    Role

                                </span>


                                <strong>

                                    <asp:Label
                                        ID="lblRole"
                                        runat="server">
                                    </asp:Label>

                                </strong>


                            </div>


                        </section>



                        <%-- ============================================
                             PERMISSIONS
                             ============================================ --%>

                        <section class="staff-dashboard-panel manager-profile-permissions">


                            <div class="staff-profile-section-heading">


                                <h5>
                                    Permissions / Access
                                </h5>


                                <small>
                                    Manager access within the Cafe101 system.
                                </small>


                            </div>



                            <div class="manager-profile-permission-list">


                                <span class="manager-profile-permission">
                                    ✓ Dashboard
                                </span>


                                <span class="manager-profile-permission">
                                    ✓ Orders
                                </span>


                                <span class="manager-profile-permission">
                                    ✓ Menu Management
                                </span>


                                <span class="manager-profile-permission">
                                    ✓ Staff Management
                                </span>


                                <span class="manager-profile-permission">
                                    ✓ Reports
                                </span>


                            </div>


                        </section>


                    </div>



                    <%-- ================================================
                         RIGHT COLUMN
                         ================================================ --%>

                    <div class="staff-profile-right-column">


                        <%-- ============================================
                             WORK INFORMATION
                             ============================================ --%>

                        <section class="staff-dashboard-panel staff-profile-work-card">


                            <div class="staff-profile-section-heading">

                                <h5>
                                    Work Information
                                </h5>

                            </div>



                            <%-- EMPLOYEE ID --%>

                            <div class="staff-profile-info-row">


                                <span class="staff-profile-info-label">

                                    <span class="staff-profile-small-icon">
                                        ▣
                                    </span>

                                    Employee ID

                                </span>


                                <strong>

                                    <asp:Label
                                        ID="lblEmployeeID"
                                        runat="server">
                                    </asp:Label>

                                </strong>


                            </div>



                            <%-- ROLE --%>

                            <div class="staff-profile-info-row">


                                <span class="staff-profile-info-label">

                                    <span class="staff-profile-small-icon">
                                        ♙
                                    </span>

                                    System Role

                                </span>


                                <strong>

                                    <asp:Label
                                        ID="lblWorkRole"
                                        runat="server">
                                    </asp:Label>

                                </strong>


                            </div>



                            <%-- STATUS --%>

                            <div class="staff-profile-info-row">


                                <span class="staff-profile-info-label">

                                    <span class="staff-profile-small-icon">
                                        ✓
                                    </span>

                                    Status

                                </span>


                                <span class="staff-profile-status-active">

                                    <asp:Label
                                        ID="lblAccountStatus"
                                        runat="server">
                                    </asp:Label>

                                </span>


                            </div>


                        </section>



                        <%-- ============================================
                             ACCOUNT SECURITY
                             ============================================ --%>

                        <section class="staff-dashboard-panel staff-profile-small-card">


                            <div class="staff-profile-small-card-content">


                                <div class="staff-profile-security-icon">

                                    <svg viewBox="0 0 24 24"
                                        width="18"
                                        height="18"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <rect x="5"
                                            y="10"
                                            width="14"
                                            height="11"
                                            rx="2" />

                                        <path d="M8 10V7a4 4 0 0 1 8 0v3" />

                                    </svg>

                                </div>



                                <div>


                                    <strong>
                                        Account Security
                                    </strong>


                                    <small>
                                        Your Cafe101 manager account is password protected.
                                    </small>


                                </div>


                            </div>


                        </section>



                        <%-- ============================================
                             QUICK ACTIONS
                             ============================================ --%>

                        <section class="staff-dashboard-panel staff-profile-quick-card">


                            <div class="staff-profile-section-heading">

                                <h5>
                                    Quick Actions
                                </h5>

                            </div>



                            <div class="manager-profile-quick-grid">


                                <%-- ORDERS --%>

                                <button type="button"
                                    class="staff-profile-quick-action"
                                    onclick="window.location.href='ManagerOrders.aspx';">


                                    <span class="staff-profile-quick-icon icon-beige">
                                        ▣
                                    </span>


                                    <span>


                                        <strong>
                                            Manage Orders
                                        </strong>


                                        <small>
                                            View customer orders
                                        </small>


                                    </span>


                                </button>



                                <%-- MENU --%>

                                <button type="button"
                                    class="staff-profile-quick-action"
                                    onclick="window.location.href='ManagerMenu.aspx';">


                                    <span class="staff-profile-quick-icon icon-purple">
                                        ▤
                                    </span>


                                    <span>


                                        <strong>
                                            Manage Menu
                                        </strong>


                                        <small>
                                            View and update menu
                                        </small>


                                    </span>


                                </button>



                                <%-- REPORTS --%>

                                <button type="button"
                                    class="staff-profile-quick-action"
                                    onclick="window.location.href='ManagerReports.aspx';">


                                    <span class="staff-profile-quick-icon icon-blue">
                                        ▥
                                    </span>


                                    <span>


                                        <strong>
                                            View Reports
                                        </strong>


                                        <small>
                                            Sales and performance
                                        </small>


                                    </span>


                                </button>



                                <%-- STAFF --%>

                                <button type="button"
                                    class="staff-profile-quick-action"
                                    onclick="window.location.href='ManagerStaff.aspx';">


                                    <span class="staff-profile-quick-icon icon-green">
                                        ♙
                                    </span>


                                    <span>


                                        <strong>
                                            Manage Staff
                                        </strong>


                                        <small>
                                            View employee accounts
                                        </small>


                                    </span>


                                </button>


                            </div>


                        </section>


                    </div>


                </div>



                <%-- ================================================
                     FOOTER
                     ================================================ --%>

                <div class="staff-footer">
                    © 2026 Cafe101 Manager System
                </div>


            </main>


        </div>


    </div>



    <%-- ================================================
         PAGE SCRIPT
         ================================================ --%>

    <script>

        document.body.classList.add("staff-page");


        // Hide public navbar from Site.Master
        const publicNavbar =
            document.querySelector(".navbar");

        if (publicNavbar) {
            publicNavbar.style.display = "none";
        }


        // Remove normal Site.Master spacing
        const bodyContent =
            document.querySelector(".body-content");

        if (bodyContent) {

            bodyContent.classList.remove("container");

            bodyContent.style.width = "100%";
            bodyContent.style.maxWidth = "none";
            bodyContent.style.margin = "0";
            bodyContent.style.padding = "0";

        }


        // Hide Site.Master footer
        const masterFooter =
            document.querySelector(
                ".body-content > footer"
            );

        if (masterFooter) {
            masterFooter.style.display = "none";
        }


        const masterFooterLine =
            document.querySelector(
                ".body-content > hr"
            );

        if (masterFooterLine) {
            masterFooterLine.style.display = "none";
        }


        // Sidebar collapse
        const sidebarToggle =
            document.getElementById("sidebarToggle");

        const staffBody =
            document.querySelector(".staff-body");


        if (sidebarToggle && staffBody) {

            sidebarToggle.addEventListener(
                "click",
                function () {

                    staffBody.classList.toggle(
                        "sidebar-collapsed"
                    );

                });

        }

    </script>


</asp:Content>