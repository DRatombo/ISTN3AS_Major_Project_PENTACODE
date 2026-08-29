<%@ Page Title="Staff Dashboard"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="StaffDashboard.aspx.cs"
    Inherits="Cafe101.Web.StaffDashboard" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


    <%-- =====================================================
         COMPLETE STAFF SYSTEM
         ===================================================== --%>

    <div class="staff-shell">


        <%-- =================================================
             TOP NAVY HEADER
             ================================================= --%>

        <header class="staff-header">


            <%-- Left side --%>
            <div class="staff-header-left">

                <button type="button"
                    id="sidebarToggle"
                    class="staff-header-menu"
                    aria-label="Toggle staff navigation">
                    ☰
                </button>


                <div class="staff-header-brand">
                    Cafe101
                </div>

            </div>


            <%-- =================================================
                 LOGGED-IN USER

                 Displays:
                 Initials
                 Full Name
                 Actual Role
                 ================================================= --%>

            <a href="StaffProfile.aspx"
                class="staff-header-user text-decoration-none">


                <div class="staff-header-avatar">

                    <asp:Label
                        ID="lblTopInitials"
                        runat="server">
                    </asp:Label>

                </div>


                <div>

                    <strong>

                        <asp:Label
                            ID="lblTopStaffName"
                            runat="server">
                        </asp:Label>

                    </strong>


                    <small>

                        <asp:Label
                            ID="lblTopStaffRole"
                            runat="server">
                        </asp:Label>

                    </small>

                </div>


            </a>


        </header>



        <%-- =================================================
             STAFF BODY
             ================================================= --%>

        <div class="staff-body">


            <%-- =================================================
                 LEFT SIDEBAR
                 ================================================= --%>

            <aside class="staff-sidebar">


                <div class="staff-sidebar-title">

                    <span class="sidebar-full-text">
                        STAFF SYSTEM
                    </span>

                </div>



                <%-- =================================================
                     STAFF NAVIGATION
                     ================================================= --%>

                <nav class="staff-nav">


                    <%-- Dashboard --%>
                    <a href="StaffDashboard.aspx"
                        class="active">

                        <span class="staff-nav-icon">
                            &#8962;
                        </span>

                        <span class="staff-nav-text">
                            Dashboard
                        </span>

                    </a>



                    <%-- Orders --%>
                    <a href="StaffOrders.aspx">

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



                    <%-- Profile --%>
                    <a href="StaffProfile.aspx">

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



                <%-- =================================================
                     LOGOUT
                     ================================================= --%>

                <div class="staff-sidebar-bottom">


                    <asp:LinkButton
                        ID="lnkLogout"
                        runat="server"
                        CssClass="staff-logout"
                        OnClick="lnkLogout_Click">


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
                 MAIN DASHBOARD
                 ================================================= --%>

            <main class="staff-main">


                <%-- =================================================
                     PAGE HEADING
                     ================================================= --%>

                <div class="staff-page-heading">

                    <h3>
                        Staff Dashboard
                    </h3>

                    <p>
                        Overview of today's Cafe101 operations.
                    </p>

                </div>



                <%-- =================================================
                     WELCOME CARD
                     ================================================= --%>

                <section class="staff-welcome-card">


                    <div class="staff-icon-box icon-beige">

                        <svg viewBox="0 0 24 24"
                            width="28"
                            height="28"
                            fill="none"
                            stroke="currentColor"
                            stroke-width="2">

                            <path d="M5 8h11v6a5 5 0 0 1-5 5H10a5 5 0 0 1-5-5V8z" />

                            <path d="M16 10h2a3 3 0 0 1 0 6h-2" />

                            <path d="M8 3c1 1 1 2 0 3" />

                            <path d="M12 3c1 1 1 2 0 3" />

                        </svg>

                    </div>



                    <div class="staff-welcome-text">


                        <h4>

                            Welcome back,

                            <asp:Label
                                ID="lblStaffName"
                                runat="server">
                            </asp:Label>!

                        </h4>


                        <p>
                            Here's what's happening at Cafe101 today.
                        </p>


                    </div>


                </section>



                <%-- =================================================
                     RECENT ORDERS + QUICK ACTIONS
                     ================================================= --%>

                <div class="staff-dashboard-grid">


                    <%-- =================================================
                         RECENT ORDERS
                         ================================================= --%>

                    <section class="staff-dashboard-panel">


                        <div class="staff-panel-heading">

                            <div>

                                <h5>
                                    Recent Orders
                                </h5>

                                <small>
                                    Latest customer orders
                                </small>

                            </div>


                            <a href="StaffOrders.aspx"
                                class="staff-text-link">

                                View All Orders →

                            </a>

                        </div>



                        <div class="table-responsive">


                            <table class="table staff-orders-table">


                                <thead>

                                    <tr>

                                        <th>Order #</th>

                                        <th>Customer</th>

                                        <th>Items</th>

                                        <th>Total</th>

                                        <th>Status</th>

                                        <th>Time</th>

                                    </tr>

                                </thead>



                                <tbody>


                                    <%-- Order 1008 --%>
                                    <tr>

                                        <td>
                                            <strong>#1008</strong>
                                        </td>

                                        <td>
                                            Sarah M.
                                        </td>

                                        <td>
                                            3
                                        </td>

                                        <td>
                                            R145.00
                                        </td>

                                        <td>

                                            <span class="order-status status-pending">
                                                Pending
                                            </span>

                                        </td>

                                        <td>
                                            14:25
                                        </td>

                                    </tr>



                                    <%-- Order 1007 --%>
                                    <tr>

                                        <td>
                                            <strong>#1007</strong>
                                        </td>

                                        <td>
                                            John D.
                                        </td>

                                        <td>
                                            2
                                        </td>

                                        <td>
                                            R98.00
                                        </td>

                                        <td>

                                            <span class="order-status status-preparing">
                                                Preparing
                                            </span>

                                        </td>

                                        <td>
                                            14:18
                                        </td>

                                    </tr>



                                    <%-- Order 1006 --%>
                                    <tr>

                                        <td>
                                            <strong>#1006</strong>
                                        </td>

                                        <td>
                                            Amanda K.
                                        </td>

                                        <td>
                                            4
                                        </td>

                                        <td>
                                            R210.00
                                        </td>

                                        <td>

                                            <span class="order-status status-ready">
                                                Ready
                                            </span>

                                        </td>

                                        <td>
                                            14:05
                                        </td>

                                    </tr>



                                    <%-- Order 1005 --%>
                                    <tr>

                                        <td>
                                            <strong>#1005</strong>
                                        </td>

                                        <td>
                                            Michael P.
                                        </td>

                                        <td>
                                            1
                                        </td>

                                        <td>
                                            R55.00
                                        </td>

                                        <td>

                                            <span class="order-status status-completed">
                                                Completed
                                            </span>

                                        </td>

                                        <td>
                                            13:52
                                        </td>

                                    </tr>


                                </tbody>


                            </table>


                        </div>


                    </section>



                    <%-- =================================================
                         QUICK ACTIONS
                         ================================================= --%>

                    <section class="staff-dashboard-panel">


                        <div class="staff-panel-heading">

                            <div>

                                <h5>
                                    Quick Actions
                                </h5>

                                <small>
                                    Common staff tasks
                                </small>

                            </div>

                        </div>



                        <div class="staff-action-grid">


                            <%-- View Orders --%>
                            <a href="StaffOrders.aspx"
                                class="staff-action-tile">


                                <div class="staff-icon-box icon-beige">

                                    <svg viewBox="0 0 24 24"
                                        width="24"
                                        height="24"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <path d="M6 3h12v18H6z" />

                                        <path d="M9 8h6" />

                                        <path d="M9 12h6" />

                                        <path d="M9 16h4" />

                                    </svg>

                                </div>


                                <div>

                                    <strong>
                                        View Orders
                                    </strong>

                                    <small>
                                        Browse all orders
                                    </small>

                                </div>


                            </a>



                            <%-- Search Orders --%>
                            <a href="StaffOrders.aspx"
                                class="staff-action-tile">


                                <div class="staff-icon-box icon-blue">

                                    <svg viewBox="0 0 24 24"
                                        width="24"
                                        height="24"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <circle cx="10"
                                            cy="10"
                                            r="6" />

                                        <path d="M15 15l5 5" />

                                    </svg>

                                </div>


                                <div>

                                    <strong>
                                        Search Orders
                                    </strong>

                                    <small>
                                        Find a specific order
                                    </small>

                                </div>


                            </a>


                        </div>


                    </section>


                </div>



                <%-- =================================================
                     SALES OVERVIEW + NOTICES
                     ================================================= --%>

                <div class="staff-dashboard-grid staff-dashboard-bottom">


                    <%-- =================================================
                         SALES OVERVIEW
                         ================================================= --%>

                    <section class="staff-dashboard-panel">


                        <div class="staff-panel-heading">

                            <div>

                                <h5>
                                    Sales Overview
                                </h5>

                                <small>
                                    Business intelligence and sales reporting
                                </small>

                            </div>

                        </div>



                        <div class="staff-chart-placeholder">


                            <div class="staff-icon-box icon-beige">

                                <svg viewBox="0 0 24 24"
                                    width="30"
                                    height="30"
                                    fill="none"
                                    stroke="currentColor"
                                    stroke-width="2">

                                    <path d="M4 20V10" />

                                    <path d="M10 20V4" />

                                    <path d="M16 20v-7" />

                                    <path d="M22 20V8" />

                                </svg>

                            </div>


                            <h5>
                                Sales Overview
                            </h5>


                            <p>
                                Power BI report or sales chart will be displayed here.
                            </p>


                        </div>


                    </section>



                    <%-- =================================================
                         NOTICES & ALERTS
                         ================================================= --%>

                    <section class="staff-dashboard-panel">


                        <div class="staff-panel-heading">

                            <div>

                                <h5>
                                    Notices & Alerts
                                </h5>

                                <small>
                                    Important staff updates
                                </small>

                            </div>

                        </div>



                        <%-- New Order --%>
                        <div class="staff-alert-item">


                            <div class="staff-alert-icon alert-blue">

                                <svg viewBox="0 0 24 24"
                                    width="19"
                                    height="19"
                                    fill="none"
                                    stroke="currentColor"
                                    stroke-width="2">

                                    <circle cx="12"
                                        cy="12"
                                        r="9" />

                                    <path d="M12 11v5" />

                                    <path d="M12 8h.01" />

                                </svg>

                            </div>


                            <div class="staff-alert-text">

                                <strong>
                                    New Order Received
                                </strong>

                                <small>
                                    Order #1008 is waiting to be processed.
                                </small>

                            </div>


                            <span class="staff-alert-time">
                                14:25
                            </span>


                        </div>



                        <%-- Preparing --%>
                        <div class="staff-alert-item">


                            <div class="staff-alert-icon alert-orange">

                                <svg viewBox="0 0 24 24"
                                    width="19"
                                    height="19"
                                    fill="none"
                                    stroke="currentColor"
                                    stroke-width="2">

                                    <circle cx="12"
                                        cy="12"
                                        r="9" />

                                    <path d="M12 7v5l3 2" />

                                </svg>

                            </div>


                            <div class="staff-alert-text">

                                <strong>
                                    Order Preparing
                                </strong>

                                <small>
                                    Order #1007 is currently being prepared.
                                </small>

                            </div>


                            <span class="staff-alert-time">
                                14:18
                            </span>


                        </div>



                        <%-- Ready --%>
                        <div class="staff-alert-item">


                            <div class="staff-alert-icon alert-green">

                                <svg viewBox="0 0 24 24"
                                    width="19"
                                    height="19"
                                    fill="none"
                                    stroke="currentColor"
                                    stroke-width="2">

                                    <circle cx="12"
                                        cy="12"
                                        r="9" />

                                    <path d="M8 12l3 3 5-6" />

                                </svg>

                            </div>


                            <div class="staff-alert-text">

                                <strong>
                                    Order Ready
                                </strong>

                                <small>
                                    Order #1006 is ready for collection.
                                </small>

                            </div>


                            <span class="staff-alert-time">
                                14:05
                            </span>


                        </div>


                    </section>


                </div>



                <%-- =================================================
                     STAFF FOOTER
                     ================================================= --%>

                <div class="staff-footer">

                    © 2026 Cafe101 Staff System

                </div>


            </main>


        </div>


    </div>



    <%-- =====================================================
         JAVASCRIPT
         ===================================================== --%>

    <script>

        document.body.classList.add("staff-page");


        // Hide public Site.Master navbar
        const publicNavbar =
            document.querySelector(".navbar");

        if (publicNavbar) {

            publicNavbar.style.display = "none";

        }



        // Remove default Bootstrap container spacing
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
            document.querySelector(".body-content > footer");

        if (masterFooter) {

            masterFooter.style.display = "none";

        }



        // Hide line above master footer
        const masterFooterLine =
            document.querySelector(".body-content > hr");

        if (masterFooterLine) {

            masterFooterLine.style.display = "none";

        }



        // Sidebar
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