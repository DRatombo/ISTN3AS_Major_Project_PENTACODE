<%@ Page Title="Reports"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ManagerReports.aspx.cs"
    Inherits="Cafe101.Web.ManagerReports" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


    <div class="staff-shell">

        <%-- =====================================================
             TOP HEADER
             ===================================================== --%>

        <header class="staff-header">

            <div class="staff-header-left">

                <button type="button"
                    id="sidebarToggle"
                    class="staff-header-menu">
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


            <%-- =====================================================
                 MANAGER SIDEBAR
                 ===================================================== --%>

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

                                <rect x="3" y="3" width="7" height="7" />
                                <rect x="14" y="3" width="7" height="7" />
                                <rect x="3" y="14" width="7" height="7" />
                                <rect x="14" y="14" width="7" height="7" />

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

                                <circle cx="9" cy="8" r="3" />
                                <circle cx="17" cy="10" r="2" />
                                <path d="M3 20c0-4 2.5-7 6-7s6 3 6 7" />
                                <path d="M15 15c3 0 5 2 5 5" />

                            </svg>

                        </span>

                        <span class="staff-nav-text">
                            Staff
                        </span>

                    </a>


                    <%-- Reports --%>

                    <a href="ManagerReports.aspx"
                        class="active">

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

                    <a href="ManagerProfile.aspx">

                        <span class="staff-nav-icon">

                            <svg viewBox="0 0 24 24"
                                width="19"
                                height="19"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <circle cx="12" cy="8" r="4" />
                                <path d="M4 21c0-4 3.5-7 8-7s8 3 8 7" />

                            </svg>

                        </span>

                        <span class="staff-nav-text">
                            Profile
                        </span>

                    </a>

                </nav>


                <%-- Logout --%>

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
                            Log Out
                        </span>

                    </asp:LinkButton>

                </div>

            </aside>



            <%-- =====================================================
                 MAIN PAGE
                 ===================================================== --%>

            <main class="staff-main">


                <%-- =================================================
                     PAGE HEADING
                     ================================================= --%>

                <div class="staff-page-heading">

                    <h3>
                        Reports
                    </h3>

                    <p>
                        View business performance, sales insights and operational summaries.
                    </p>

                </div>



                <%-- =================================================
                     REPORT TOOLBAR
                     ================================================= --%>

                <div class="manager-orders-toolbar">

                    <div class="manager-orders-toolbar-left">


                        <%-- Date Range --%>

                        <div class="manager-date-filter">

                            <svg viewBox="0 0 24 24"
                                width="16"
                                height="16"
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


                            <select class="form-control">

                                <option>Last 7 Days</option>
                                <option>Today</option>
                                <option>Yesterday</option>
                                <option>Last 30 Days</option>
                                <option>This Month</option>
                                <option>Previous Month</option>

                            </select>

                        </div>



                        <%-- Report Type --%>

                        <div class="staff-filter-box">

                            <span class="staff-filter-icon">

                                <svg viewBox="0 0 24 24"
                                    width="16"
                                    height="16"
                                    fill="none"
                                    stroke="currentColor"
                                    stroke-width="2">

                                    <path d="M4 5h16l-6 7v5l-4 2v-7L4 5z" />

                                </svg>

                            </span>


                            <select class="form-control staff-status-filter">

                                <option>All Report Types</option>
                                <option>Sales Report</option>
                                <option>Orders Report</option>
                                <option>Inventory Report</option>
                                <option>Staff Performance</option>
                                <option>Product Performance</option>

                            </select>

                        </div>

                    </div>



                    <div class="manager-orders-toolbar-right">

                        <button type="button"
                            class="btn btn-outline-brand">
                            ⇩ Export Report
                        </button>


                        <button type="button"
                            class="btn btn-brand">
                            ↻ Refresh
                        </button>

                    </div>

                </div>



                <%-- =================================================
                     FOUR REPORT METRIC CARDS
                     ================================================= --%>

                <div class="staff-metric-grid">


                    <%-- Total Revenue --%>

                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-green">

                            <span class="manager-money-icon">
                                R
                            </span>

                        </div>


                        <div>

                            <span class="staff-metric-label">
                                TOTAL REVENUE
                            </span>

                            <h3>
                                R84,200.00
                            </h3>

                            <p class="manager-positive-text">
                                ↑ 18% vs previous 7 days
                            </p>

                        </div>

                    </div>



                    <%-- Orders Completed --%>

                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-blue">

                            <svg viewBox="0 0 24 24"
                                width="21"
                                height="21"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <rect x="5"
                                    y="4"
                                    width="14"
                                    height="17"
                                    rx="2" />

                                <path d="M9 9h6" />
                                <path d="M9 13h6" />
                                <path d="m9 17 2 2 4-4" />

                            </svg>

                        </div>


                        <div>

                            <span class="staff-metric-label">
                                ORDERS COMPLETED
                            </span>

                            <h3>
                                386
                            </h3>

                            <p class="manager-positive-text">
                                ↑ 16% vs previous 7 days
                            </p>

                        </div>

                    </div>



                    <%-- Average Order Value --%>

                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-orange">

                            <svg viewBox="0 0 24 24"
                                width="21"
                                height="21"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <rect x="5"
                                    y="3"
                                    width="14"
                                    height="18"
                                    rx="2" />

                                <path d="M8 7h8" />
                                <path d="M8 11h8" />
                                <path d="M8 15h5" />

                            </svg>

                        </div>


                        <div>

                            <span class="staff-metric-label">
                                AVERAGE ORDER VALUE
                            </span>

                            <h3>
                                R218.13
                            </h3>

                            <p class="manager-positive-text">
                                ↑ 8% vs previous 7 days
                            </p>

                        </div>

                    </div>



                    <%-- Monthly Growth --%>

                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-purple">

                            <svg viewBox="0 0 24 24"
                                width="21"
                                height="21"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <path d="M4 18V12" />
                                <path d="M9 18V8" />
                                <path d="M14 18V5" />
                                <path d="M19 18V2" />

                            </svg>

                        </div>


                        <div>

                            <span class="staff-metric-label">
                                MONTHLY GROWTH
                            </span>

                            <h3>
                                +12.4%
                            </h3>

                            <p class="manager-positive-text">
                                ↑ 12.4% vs last month
                            </p>

                        </div>

                    </div>

                </div>



                <%-- =================================================
                     REPORT VISUALS
                     ================================================= --%>

                <div class="manager-reports-top-grid">


                    <%-- Revenue Overview --%>

                    <section class="staff-dashboard-panel">

                        <div class="staff-panel-heading">

                            <div>

                                <h5>
                                    Revenue Overview
                                </h5>

                                <small>
                                    Sales trend over the selected period
                                </small>

                            </div>


                            <select class="form-control manager-period-filter">

                                <option>Last 7 Days</option>
                                <option>Last 30 Days</option>
                                <option>This Month</option>

                            </select>

                        </div>


                        <div class="staff-chart-placeholder">

                            <svg viewBox="0 0 24 24"
                                width="42"
                                height="42"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="1.7">

                                <path d="M5 19V11" />
                                <path d="M10 19V7" />
                                <path d="M15 19V4" />
                                <path d="M20 19V9" />

                            </svg>

                            <h5>
                                Power BI Revenue Report
                            </h5>

                            <p>
                                Revenue analytics will be displayed here.
                            </p>

                        </div>

                    </section>



                    <%-- Sales by Category --%>

                    <section class="staff-dashboard-panel">

                        <div class="staff-panel-heading">

                            <div>

                                <h5>
                                    Sales by Category
                                </h5>

                                <small>
                                    Sales distribution across menu categories
                                </small>

                            </div>

                        </div>


                        <div class="staff-chart-placeholder">

                            <svg viewBox="0 0 24 24"
                                width="42"
                                height="42"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="1.7">

                                <circle cx="12" cy="12" r="8" />
                                <path d="M12 4v8h8" />

                            </svg>

                            <h5>
                                Power BI Category Report
                            </h5>

                            <p>
                                Category sales analytics will be displayed here.
                            </p>

                        </div>

                    </section>

                </div>



                <%-- =================================================
                     BOTTOM REPORT ROW
                     ================================================= --%>

                <div class="manager-reports-bottom-grid">


                    <%-- Top Selling Items --%>

                    <section class="staff-dashboard-panel manager-reports-selling">

                        <div class="staff-panel-heading">

                            <div>

                                <h5>
                                    Top Selling Items
                                </h5>

                                <small>
                                    Best performing items in the selected period
                                </small>

                            </div>

                        </div>



                        <div class="table-responsive">

                            <table class="table staff-orders-table">

                                <thead>

                                    <tr>

                                        <th>Item</th>
                                        <th>Category</th>
                                        <th>Quantity Sold</th>
                                        <th>Revenue</th>
                                        <th>Trend</th>

                                    </tr>

                                </thead>


                                <tbody>

                                    <tr>

                                        <td>
                                            <strong>
                                                Cappuccino
                                            </strong>
                                        </td>

                                        <td>
                                            Beverages
                                        </td>

                                        <td>
                                            132
                                        </td>

                                        <td>
                                            R6,600.00
                                        </td>

                                        <td class="manager-positive-text">
                                            ↑ 15%
                                        </td>

                                    </tr>


                                    <tr>

                                        <td>
                                            <strong>
                                                Chicken Wrap
                                            </strong>
                                        </td>

                                        <td>
                                            Food
                                        </td>

                                        <td>
                                            98
                                        </td>

                                        <td>
                                            R6,664.00
                                        </td>

                                        <td class="manager-positive-text">
                                            ↑ 11%
                                        </td>

                                    </tr>


                                    <tr>

                                        <td>
                                            <strong>
                                                Vanilla Muffin
                                            </strong>
                                        </td>

                                        <td>
                                            Bakery
                                        </td>

                                        <td>
                                            86
                                        </td>

                                        <td>
                                            R2,150.00
                                        </td>

                                        <td class="manager-positive-text">
                                            ↑ 8%
                                        </td>

                                    </tr>


                                    <tr>

                                        <td>
                                            <strong>
                                                Classic Burger
                                            </strong>
                                        </td>

                                        <td>
                                            Food
                                        </td>

                                        <td>
                                            72
                                        </td>

                                        <td>
                                            R5,760.00
                                        </td>

                                        <td class="manager-positive-text">
                                            ↑ 12%
                                        </td>

                                    </tr>


                                    <tr>

                                        <td>
                                            <strong>
                                                Brownie
                                            </strong>
                                        </td>

                                        <td>
                                            Bakery
                                        </td>

                                        <td>
                                            65
                                        </td>

                                        <td>
                                            R1,625.00
                                        </td>

                                        <td class="manager-positive-text">
                                            ↑ 9%
                                        </td>

                                    </tr>

                                </tbody>

                            </table>

                        </div>


                        <div class="manager-reports-table-footer">

                            <a href="#"
                                class="staff-text-link">

                                View Full Items Report →

                            </a>

                            <small>
                                Showing 1-5 of 5 items
                            </small>

                        </div>

                    </section>



                    <div class="manager-reports-right-lower">

                        <div class="manager-reports-summary-column">


                            <%-- Payment Summary --%>

                            <section class="staff-dashboard-panel">

                                <div class="staff-panel-heading">

                                    <div>

                                        <h5>
                                            Payment Summary
                                        </h5>

                                        <small>
                                            Breakdown of payments received
                                        </small>

                                    </div>

                                </div>


                                <div class="manager-reports-payment-list">


                                    <div class="manager-reports-payment-row">

                                        <span>
                                            Card
                                        </span>

                                        <strong>
                                            R46,120
                                        </strong>

                                        <span class="order-status status-ready">
                                            54.7%
                                        </span>

                                    </div>


                                    <div class="manager-reports-payment-row">

                                        <span>
                                            Cash
                                        </span>

                                        <strong>
                                            R26,340
                                        </strong>

                                        <span class="order-status status-completed">
                                            31.3%
                                        </span>

                                    </div>


                                    <div class="manager-reports-payment-row">

                                        <span>
                                            Online
                                        </span>

                                        <strong>
                                            R11,740
                                        </strong>

                                        <span class="order-status status-preparing">
                                            14.0%
                                        </span>

                                    </div>


                                    <div class="manager-reports-payment-total">

                                        <span>
                                            Total Payments
                                        </span>

                                        <strong>
                                            R84,200.00
                                        </strong>

                                    </div>

                                </div>

                            </section>



                            <%-- Quick Insights --%>

                            <section class="staff-dashboard-panel">

                                <div class="staff-panel-heading">

                                    <div>

                                        <h5>
                                            Quick Insights
                                        </h5>

                                        <small>
                                            Performance highlights
                                        </small>

                                    </div>

                                </div>


                                <div class="staff-alert-item">

                                    <div class="staff-alert-icon alert-green">
                                        ↑
                                    </div>

                                    <div class="staff-alert-text">

                                        <strong>
                                            Best Selling Product
                                        </strong>

                                        <small>
                                            Cappuccino generated the highest revenue.
                                        </small>

                                    </div>

                                </div>


                                <div class="staff-alert-item">

                                    <div class="staff-alert-icon alert-blue">
                                        ◷
                                    </div>

                                    <div class="staff-alert-text">

                                        <strong>
                                            Busiest Day
                                        </strong>

                                        <small>
                                            Saturday recorded the highest sales.
                                        </small>

                                    </div>

                                </div>


                                <div class="staff-alert-item">

                                    <div class="staff-alert-icon alert-orange">
                                        !
                                    </div>

                                    <div class="staff-alert-text">

                                        <strong>
                                            Lowest Performing Category
                                        </strong>

                                        <small>
                                            Sides accounted for 10.8% of sales.
                                        </small>

                                    </div>

                                </div>

                            </section>

                        </div>



                        <%-- Quick Actions --%>

                        <section class="staff-dashboard-panel manager-reports-quick-card">

                            <div class="staff-panel-heading">

                                <div>

                                    <h5>
                                        Quick Actions
                                    </h5>

                                    <small>
                                        Download reports and insights
                                    </small>

                                </div>

                            </div>


                            <div class="staff-action-grid">


                                <a href="#"
                                    class="staff-action-tile">

                                    <div class="staff-icon-box icon-green">

                                        <svg viewBox="0 0 24 24"
                                            width="18"
                                            height="18"
                                            fill="none"
                                            stroke="currentColor"
                                            stroke-width="2">

                                            <path d="M12 3v12" />
                                            <path d="m8 11 4 4 4-4" />
                                            <path d="M5 20h14" />

                                        </svg>

                                    </div>


                                    <div>

                                        <strong>
                                            Download Sales Report
                                        </strong>

                                        <small>
                                            Detailed sales performance
                                        </small>

                                    </div>

                                </a>



                                <a href="#"
                                    class="staff-action-tile">

                                    <div class="staff-icon-box icon-blue">

                                        <svg viewBox="0 0 24 24"
                                            width="18"
                                            height="18"
                                            fill="none"
                                            stroke="currentColor"
                                            stroke-width="2">

                                            <path d="M5 4h14v16H5z" />
                                            <path d="M8 8h8" />
                                            <path d="M8 12h8" />
                                            <path d="M8 16h5" />

                                        </svg>

                                    </div>


                                    <div>

                                        <strong>
                                            Inventory Report
                                        </strong>

                                        <small>
                                            Stock levels and usage
                                        </small>

                                    </div>

                                </a>



                                <a href="#"
                                    class="staff-action-tile">

                                    <div class="staff-icon-box icon-purple">

                                        <svg viewBox="0 0 24 24"
                                            width="18"
                                            height="18"
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

                                        </svg>

                                    </div>


                                    <div>

                                        <strong>
                                            Staff Performance
                                        </strong>

                                        <small>
                                            Team performance summary
                                        </small>

                                    </div>

                                </a>

                            </div>

                        </section>

                    </div>

                </div>



                <%-- =================================================
                     FOOTER
                     ================================================= --%>

                <div class="staff-footer">
                    © 2026 Cafe101 Manager System
                </div>

            </main>

        </div>

    </div>



    <%-- =====================================================
         PAGE SCRIPT
         ===================================================== --%>

    <script>

        document.body.classList.add("staff-page");


        const bodyContent =
            document.querySelector(".body-content");


        if (bodyContent) {

            bodyContent.classList.remove("container");

            bodyContent.style.width = "100%";
            bodyContent.style.maxWidth = "none";
            bodyContent.style.margin = "0";
            bodyContent.style.padding = "0";

        }


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