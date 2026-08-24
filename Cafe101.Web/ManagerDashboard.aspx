<%@ Page Title="Manager Dashboard"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ManagerDashboard.aspx.cs"
    Inherits="Cafe101.Web.ManagerDashboard" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


    <%-- =================================================
          MANAGER DASHBOARD
         ================================================= --%>

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


            <%-- Temporary logged-in manager information --%>
            <a href="ManagerProfile.aspx"
               class="staff-header-user text-decoration-none">

                <div class="staff-header-avatar">
                    MA
                </div>

                <div>

                    <strong>
                        <asp:Label
                            ID="lblTopManagerName"
                            runat="server">
                        </asp:Label>
                    </strong>

                    <small>Administrator</small>

                </div>

            </a>
     </header>



        <%-- =================================================
             MANAGER BODY
             ================================================= --%>

        <div class="staff-body">


            <%-- =================================================
                 MANAGER SIDEBAR
                 ================================================= --%>

            <aside class="staff-sidebar">

                <div class="staff-sidebar-title">
                    MANAGER SYSTEM
                </div>


                <nav class="staff-nav">


                    <%-- Dashboard --%>
                    <a href="ManagerDashboard.aspx"
                        class="active">

                        <span class="staff-nav-icon">&#8962;
                        </span>

                        <span class="staff-nav-text">Dashboard
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

                        <span class="staff-nav-text">Orders
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

                        <span class="staff-nav-text">Menu
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

                        <span class="staff-nav-text">Staff
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

                        <span class="staff-nav-text">Reports
                        </span>

                    </a>



                    <%-- Profile --%>
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

                        <span class="staff-nav-text">Profile
                        </span>

                    </a>


                </nav>



                <%-- Logout --%>
                <div class="staff-sidebar-bottom">

                    <div class="staff-sidebar-bottom">

                        <asp:LinkButton
                            ID="lnkLogout"
                            runat="server"
                            CssClass="staff-logout"
                            OnClick="lnkLogout_Click">

                            <span class="staff-nav-icon">&#10140;</span>

                            <span class="staff-nav-text">
                                Logout
                            </span>

                        </asp:LinkButton>

                    </div>

                </div>


            </aside>



            <%-- =================================================
                 MAIN MANAGER CONTENT
                 ================================================= --%>

            <main class="staff-main">


                <%-- =================================================
                     PAGE HEADING
                     ================================================= --%>

                <div class="staff-page-heading">

                    <h3>Manager Dashboard
                    </h3>

                    <p>
                        Overview of Cafe101 operations and performance.
                    </p>

                </div>



                <%-- =================================================
                     MANAGER WELCOME CARD
                     ================================================= --%>

                <section class="staff-dashboard-panel manager-welcome-card">


                    <div class="manager-welcome-left">

                        <div class="staff-icon-box icon-beige">

                            <svg viewBox="0 0 24 24"
                                width="24"
                                height="24"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <path d="M5 8h11v7a5 5 0 0 1-5 5H10a5 5 0 0 1-5-5z" />
                                <path d="M16 10h2a3 3 0 0 1 0 6h-2" />
                                <path d="M8 3v2" />
                                <path d="M12 3v2" />

                            </svg>

                        </div>


                        <div>

                            <h4>Welcome back, <asp:Label ID="lblManagerName" runat="server"></asp:Label>!
                            </h4>

                            <p>
                                Here's an overview of today's performance and key metrics.
                            </p>

                        </div>

                    </div>



                    <%-- Mock date --%>
                    <div class="manager-date-box">

                        <svg viewBox="0 0 24 24"
                            width="17"
                            height="17"
                            fill="none"
                            stroke="currentColor"
                            stroke-width="2">

                            <rect x="3"
                                y="5"
                                width="18"
                                height="16"
                                rx="2" />

                            <path d="M8 3v4" />
                            <path d="M16 3v4" />
                            <path d="M3 10h18" />

                        </svg>


                        <div>

                            <strong>Sunday, 23 August 2026
                            </strong>

                            <small>University Time
                            </small>

                        </div>

                    </div>


                </section>



                <%-- =================================================
                     MANAGER METRIC CARDS
                     ================================================= --%>

                <div class="staff-metric-grid">


                    <%-- Total orders --%>
                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-green">

                            <svg viewBox="0 0 24 24"
                                width="24"
                                height="24"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <path d="M6 7h12l-1 13H7L6 7z" />
                                <path d="M9 7a3 3 0 0 1 6 0" />

                            </svg>

                        </div>


                        <div>

                            <span class="staff-metric-label">TOTAL ORDERS TODAY
                            </span>

                            <h3>86
                            </h3>

                            <p class="manager-positive-text">
                                ↑ 12% from yesterday
                            </p>

                        </div>

                    </div>



                    <%-- Revenue --%>
                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-blue">

                            <span class="manager-money-icon">R
                            </span>

                        </div>


                        <div>

                            <span class="staff-metric-label">REVENUE TODAY
                            </span>

                            <h3>R8,420.00
                            </h3>

                            <p class="manager-positive-text">
                                ↑ 8.4% from yesterday
                            </p>

                        </div>

                    </div>



                    <%-- Pending --%>
                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-orange">

                            <svg viewBox="0 0 24 24"
                                width="24"
                                height="24"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <circle cx="12"
                                    cy="12"
                                    r="9" />

                                <path d="M12 7v5l3 2" />

                            </svg>

                        </div>


                        <div>

                            <span class="staff-metric-label">PENDING ORDERS
                            </span>

                            <h3>12
                            </h3>

                            <p>
                                Orders waiting to be processed
                            </p>

                        </div>

                    </div>



                    <%-- Low stock --%>
                    <div class="staff-metric-card">

                        <div class="staff-icon-box manager-icon-red">

                            <svg viewBox="0 0 24 24"
                                width="24"
                                height="24"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <path d="M12 3L2 21h20L12 3z" />
                                <path d="M12 9v5" />
                                <path d="M12 18h.01" />

                            </svg>

                        </div>


                        <div>

                            <span class="staff-metric-label">LOW STOCK ITEMS
                            </span>

                            <h3>7
                            </h3>

                            <p class="manager-alert-text">
                                Requires immediate attention
                            </p>

                        </div>

                    </div>


                </div>



                <%-- =================================================
                     SALES OVERVIEW + RECENT ORDERS
                     ================================================= --%>

                <div class="manager-main-grid">


                    <%-- SALES OVERVIEW --%>
                    <section class="staff-dashboard-panel">


                        <div class="staff-panel-heading">

                            <div>

                                <h5>Sales Overview
                                </h5>

                                <small>Daily revenue over the last 7 days
                                </small>

                            </div>


                            <select class="form-control manager-period-filter">

                                <option>Last 7 Days
                                </option>

                                <option>Last 30 Days
                                </option>

                            </select>

                        </div>



                        <%-- Placeholder for Power BI / chart integration --%>
                        <div class="manager-sales-chart">


                            <div class="manager-chart-y-axis">

                                <span>R10K</span>
                                <span>R8K</span>
                                <span>R6K</span>
                                <span>R4K</span>
                                <span>R2K</span>

                            </div>


                            <div class="manager-chart-area">

                                <svg viewBox="0 0 700 220"
                                    preserveAspectRatio="none"
                                    class="manager-chart-svg">

                                    <polyline
                                        points="0,150 115,135 230,165 345,120 460,145 575,125 700,55"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="3" />

                                    <circle cx="0"
                                        cy="150"
                                        r="4" />

                                    <circle cx="115"
                                        cy="135"
                                        r="4" />

                                    <circle cx="230"
                                        cy="165"
                                        r="4" />

                                    <circle cx="345"
                                        cy="120"
                                        r="4" />

                                    <circle cx="460"
                                        cy="145"
                                        r="4" />

                                    <circle cx="575"
                                        cy="125"
                                        r="4" />

                                    <circle cx="700"
                                        cy="55"
                                        r="4" />

                                </svg>


                                <div class="manager-chart-days">

                                    <span>17 Aug</span>
                                    <span>18 Aug</span>
                                    <span>19 Aug</span>
                                    <span>20 Aug</span>
                                    <span>21 Aug</span>
                                    <span>22 Aug</span>
                                    <span>23 Aug</span>

                                </div>

                            </div>


                        </div>


                    </section>



                    <%-- RECENT ORDERS --%>
                    <section class="staff-dashboard-panel">


                        <div class="staff-panel-heading">

                            <div>

                                <h5>Recent Orders
                                </h5>

                                <small>Latest customer orders
                                </small>

                            </div>


                            <a href="#"
                                class="staff-text-link">View All Orders →

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


                                    <tr>

                                        <td>
                                            <strong>#1023</strong>
                                        </td>

                                        <td>Sarah M.
                                        </td>

                                        <td>3
                                        </td>

                                        <td>R145.00
                                        </td>

                                        <td>
                                            <span class="order-status status-pending">Pending
                                            </span>
                                        </td>

                                        <td>14:32
                                        </td>

                                    </tr>



                                    <tr>

                                        <td>
                                            <strong>#1022</strong>
                                        </td>

                                        <td>Sarah M.
                                        </td>

                                        <td>2
                                        </td>

                                        <td>R98.00
                                        </td>

                                        <td>
                                            <span class="order-status status-preparing">Preparing
                                            </span>
                                        </td>

                                        <td>14:21
                                        </td>

                                    </tr>



                                    <tr>

                                        <td>
                                            <strong>#1021</strong>
                                        </td>

                                        <td>Michael P.
                                        </td>

                                        <td>4
                                        </td>

                                        <td>R210.00
                                        </td>

                                        <td>
                                            <span class="order-status status-ready">Ready
                                            </span>
                                        </td>

                                        <td>14:05
                                        </td>

                                    </tr>



                                    <tr>

                                        <td>
                                            <strong>#1020</strong>
                                        </td>

                                        <td>Emma T.
                                        </td>

                                        <td>1
                                        </td>

                                        <td>R55.00
                                        </td>

                                        <td>
                                            <span class="order-status status-completed">Completed
                                            </span>
                                        </td>

                                        <td>13:48
                                        </td>

                                    </tr>


                                </tbody>

                            </table>

                        </div>


                    </section>


                </div>



                <%-- =================================================
                     LOWER MANAGER DASHBOARD
                     ================================================= --%>

                <div class="manager-bottom-grid">


                    <%-- =================================================
                         POPULAR ITEMS
                         ================================================= --%>

                    <section class="staff-dashboard-panel">


                        <div class="staff-panel-heading">

                            <div>

                                <h5>Popular Items
                                </h5>

                                <small>Top selling menu items today
                                </small>

                            </div>

                        </div>



                        <div class="manager-popular-table">


                            <div class="manager-popular-header">

                                <span>Item
                                </span>

                                <span>Quantity Sold
                                </span>

                            </div>


                            <div class="manager-popular-row">

                                <span>☕ Cappuccino
                                </span>

                                <strong>32
                                </strong>

                            </div>


                            <div class="manager-popular-row">

                                <span>🥙 Chicken Wrap
                                </span>

                                <strong>28
                                </strong>

                            </div>


                            <div class="manager-popular-row">

                                <span>🧁 Vanilla Muffin
                                </span>

                                <strong>24
                                </strong>

                            </div>


                            <div class="manager-popular-row">

                                <span>🥤 Iced Latte
                                </span>

                                <strong>20
                                </strong>

                            </div>


                            <div class="manager-popular-row">

                                <span>🥐 Classic Burger
                                </span>

                                <strong>18
                                </strong>

                            </div>


                        </div>


                        <a href="#"
                            class="staff-text-link manager-bottom-link">View Full Menu Report →

                        </a>


                    </section>



                    <%-- =================================================
                         STAFF ON SHIFT
                         ================================================= --%>

                    <section class="staff-dashboard-panel">


                        <div class="staff-panel-heading">

                            <div>

                                <h5>Staff on Shift
                                </h5>

                                <small>Current staff working
                                </small>

                            </div>

                        </div>



                        <div class="manager-shift-table">


                            <div class="manager-shift-header">

                                <span>Name</span>
                                <span>Role</span>
                                <span>Shift</span>

                            </div>


                            <div class="manager-shift-row">

                                <span>Sarah M.
                                </span>

                                <span>Shift Supervisor
                                </span>

                                <span class="manager-shift-time">08:00 - 16:00
                                </span>

                            </div>


                            <div class="manager-shift-row">

                                <span>James R.
                                </span>

                                <span>Barista
                                </span>

                                <span class="manager-shift-time">09:00 - 17:00
                                </span>

                            </div>


                            <div class="manager-shift-row">

                                <span>Chloe T.
                                </span>

                                <span>Cashier
                                </span>

                                <span class="manager-shift-time">08:00 - 16:00
                                </span>

                            </div>


                            <div class="manager-shift-row">

                                <span>Daniel K.
                                </span>

                                <span>Kitchen Staff
                                </span>

                                <span class="manager-shift-time">08:00 - 16:00
                                </span>

                            </div>


                        </div>


                        <a href="#"
                            class="staff-text-link manager-bottom-link">Manage Staff Schedule →

                        </a>


                    </section>



                    <%-- =================================================
                         LOW STOCK ALERTS
                         ================================================= --%>

                    <section class="staff-dashboard-panel">


                        <div class="staff-panel-heading">

                            <div>

                                <h5>Low Stock Alerts
                                </h5>

                                <small>Items that need restocking
                                </small>

                            </div>

                        </div>



                        <div class="manager-stock-list">


                            <div class="manager-stock-item">

                                <div>

                                    <strong>Milk (1L)
                                    </strong>

                                    <small>5 units left
                                    </small>

                                </div>

                                <span class="manager-stock-critical">Critical
                                </span>

                            </div>



                            <div class="manager-stock-item">

                                <div>

                                    <strong>Chicken Fillet
                                    </strong>

                                    <small>12 kg left
                                    </small>

                                </div>

                                <span class="manager-stock-high">High
                                </span>

                            </div>



                            <div class="manager-stock-item">

                                <div>

                                    <strong>Brown Sugar
                                    </strong>

                                    <small>1.2 kg left
                                    </small>

                                </div>

                                <span class="manager-stock-medium">Medium
                                </span>

                            </div>



                            <div class="manager-stock-item">

                                <div>

                                    <strong>Cappuccino Cups
                                    </strong>

                                    <small>8 units left
                                    </small>

                                </div>

                                <span class="manager-stock-low">Low
                                </span>

                            </div>


                        </div>


                        <a href="#"
                            class="staff-text-link manager-bottom-link">View All Inventory →

                        </a>


                    </section>



                    <%-- =================================================
                         QUICK ACTIONS
                         ================================================= --%>

                    <section class="staff-dashboard-panel">


                        <div class="staff-panel-heading">

                            <div>

                                <h5>Quick Actions
                                </h5>

                                <small>Common management tasks
                                </small>

                            </div>

                        </div>



                        <div class="manager-quick-grid">


                            <a href="#"
                                class="manager-quick-action">

                                <span class="staff-icon-box icon-green">

                                    <svg viewBox="0 0 24 24"
                                        width="18"
                                        height="18"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <path d="M4 4h16v16H4z" />
                                        <path d="M8 8h8" />

                                    </svg>

                                </span>

                                <div>

                                    <strong>Manage Menu
                                    </strong>

                                    <small>Add or edit menu items
                                    </small>

                                </div>

                            </a>



                            <a href="#"
                                class="manager-quick-action">

                                <span class="staff-icon-box icon-blue">

                                    <svg viewBox="0 0 24 24"
                                        width="18"
                                        height="18"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <circle cx="12"
                                            cy="8"
                                            r="4" />

                                        <path d="M4 21c0-4 3.5-7 8-7s8 3 8 7" />

                                    </svg>

                                </span>

                                <div>

                                    <strong>Add Staff
                                    </strong>

                                    <small>Create new staff account
                                    </small>

                                </div>

                            </a>



                            <a href="#"
                                class="manager-quick-action">

                                <span class="staff-icon-box icon-purple">

                                    <svg viewBox="0 0 24 24"
                                        width="18"
                                        height="18"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <path d="M4 20V10" />
                                        <path d="M10 20V4" />
                                        <path d="M16 20v-7" />

                                    </svg>

                                </span>

                                <div>

                                    <strong>View Reports
                                    </strong>

                                    <small>Sales and performance
                                    </small>

                                </div>

                            </a>



                            <a href="#"
                                class="manager-quick-action">

                                <span class="staff-icon-box icon-beige">

                                    <svg viewBox="0 0 24 24"
                                        width="18"
                                        height="18"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <path d="M6 3h12v18H6z" />
                                        <path d="M9 8h6" />
                                        <path d="M9 12h6" />

                                    </svg>

                                </span>

                                <div>

                                    <strong>View Orders
                                    </strong>

                                    <small>Browse all orders
                                    </small>

                                </div>

                            </a>


                        </div>


                    </section>


                </div>



                <%-- Manager footer --%>
                <div class="staff-footer">
                    © 2026 Cafe101 Manager System
                </div>


            </main>
            <%-- END OF staff-main --%>
        </div>
        <%-- END OF staff-body --%>
    </div>
    <%-- END OF manager-shell --%>



    <%-- =================================================
         MANAGER PAGE JAVASCRIPT
         ================================================= --%>

    <script>

        // Make this page use the private staff/manager layout
        document.body.classList.add("staff-page");


        // Remove Site.Master Bootstrap container
        const bodyContent =
            document.querySelector(".body-content");


        if (bodyContent) {

            bodyContent.classList.remove("container");

            bodyContent.style.width = "100%";
            bodyContent.style.maxWidth = "none";
            bodyContent.style.margin = "0";
            bodyContent.style.padding = "0";

        }



        // Sidebar collapse
        const sidebarToggle =
            document.getElementById("sidebarToggle");


        const staffBody =
            document.querySelector(".staff-body");


        if (sidebarToggle && staffBody) {

            sidebarToggle.addEventListener("click", function () {

                staffBody.classList.toggle("sidebar-collapsed");

            });

        }

    </script>


</asp:Content>
