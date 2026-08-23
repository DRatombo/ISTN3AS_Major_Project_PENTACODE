<%@ Page Title="Manager Orders"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ManagerOrders.aspx.cs"
    Inherits="Cafe101.Web.ManagerOrders" %>

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

            <div class="staff-header-user">

                <div class="staff-header-avatar">
                    MA
                </div>

                <div>
                    <strong>Manager</strong>
                    <small>Administrator</small>
                </div>

            </div>

        </header>


        <div class="staff-body">

            <%-- =================================================
                 MANAGER SIDEBAR
                 ================================================= --%>

            <aside class="staff-sidebar">

                <div class="staff-sidebar-title">
                    MANAGER SYSTEM
                </div>

                <nav class="staff-nav">

                    <a href="ManagerDashboard.aspx">
                        <span class="staff-nav-icon">&#8962;</span>
                        <span class="staff-nav-text">Dashboard</span>
                    </a>


                    <a href="ManagerOrders.aspx"
                        class="active">

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


                    <a href="ManagerStaff.aspx" >
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

                                <circle cx="12" cy="8" r="4" />
                                <path d="M4 21c0-4 3.5-7 8-7s8 3 8 7" />

                            </svg>

                        </span>

                        <span class="staff-nav-text">
                            Profile
                        </span>
                    </a>

                </nav>


                <div class="staff-sidebar-bottom">

                    <a href="#"
                        class="staff-logout">

                        <span class="staff-nav-icon">
                            &#10140;
                        </span>

                        <span class="staff-nav-text">
                            Logout
                        </span>

                    </a>

                </div>

            </aside>


            <%-- =================================================
                 MAIN MANAGER ORDERS AREA
                 ================================================= --%>

            <main class="staff-main">

                <div class="staff-page-heading">

                    <h3>
                        Orders
                    </h3>

                    <p>
                        Monitor, manage and review all customer orders.
                    </p>

                </div>


                <%-- =================================================
                     ORDER TOOLBAR
                     ================================================= --%>

                <div class="manager-orders-toolbar">

                    <div class="manager-orders-toolbar-left">

                        <%-- Search --%>
                        <div class="staff-search-box">

                            <span class="staff-search-icon">

                                <svg viewBox="0 0 24 24"
                                    width="18"
                                    height="18"
                                    fill="none"
                                    stroke="currentColor"
                                    stroke-width="2">

                                    <circle cx="10" cy="10" r="6" />
                                    <path d="M15 15l5 5" />

                                </svg>

                            </span>

                            <input type="text"
                                class="form-control"
                                placeholder="Search by order # or customer name..." />

                        </div>


                        <%-- Status filter --%>
                        <div class="staff-filter-box">

                            <span class="staff-filter-icon">

                                <svg viewBox="0 0 24 24"
                                    width="17"
                                    height="17"
                                    fill="none"
                                    stroke="currentColor"
                                    stroke-width="2">

                                    <path d="M4 5h16l-6 7v5l-4 2v-7L4 5z" />

                                </svg>

                            </span>

                            <select class="form-control staff-status-filter">

                                <option>
                                    Filter by status
                                </option>

                                <option>
                                    Pending
                                </option>

                                <option>
                                    Preparing
                                </option>

                                <option>
                                    Ready
                                </option>

                                <option>
                                    Completed
                                </option>

                                <option>
                                    Cancelled
                                </option>

                            </select>

                        </div>


                        <%-- Date filter --%>
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

                                <option>
                                    Select date range
                                </option>

                                <option>
                                    Today
                                </option>

                                <option>
                                    Last 7 Days
                                </option>

                                <option>
                                    Last 30 Days
                                </option>

                            </select>

                        </div>

                    </div>


                    <div class="manager-orders-toolbar-right">

                        <button type="button"
                            class="btn btn-outline-brand">

                            ⇩ Export Orders

                        </button>

                        <button type="button"
                            class="btn btn-brand">

                            ↻ Refresh

                        </button>

                    </div>

                </div>


                <%-- =================================================
                     SUMMARY CARDS
                     ================================================= --%>

                <div class="staff-metric-grid">

                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-blue">

                            <svg viewBox="0 0 24 24"
                                width="23"
                                height="23"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <path d="M6 7h12l-1 13H7L6 7z" />
                                <path d="M9 7a3 3 0 0 1 6 0" />

                            </svg>

                        </div>

                        <div>

                            <span class="staff-metric-label">
                                TOTAL ORDERS
                            </span>

                            <h3>86</h3>

                            <p class="manager-positive-text">
                                ↑ 14% vs yesterday
                            </p>

                        </div>

                    </div>


                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-orange">

                            <svg viewBox="0 0 24 24"
                                width="23"
                                height="23"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <circle cx="12" cy="12" r="9" />
                                <path d="M12 7v5l3 2" />

                            </svg>

                        </div>

                        <div>

                            <span class="staff-metric-label">
                                PENDING ORDERS
                            </span>

                            <h3>12</h3>

                            <p>
                                Awaiting attention
                            </p>

                        </div>

                    </div>


                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-beige">

                            <svg viewBox="0 0 24 24"
                                width="23"
                                height="23"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <path d="M4 6h16v12H4z" />
                                <path d="M8 10h8" />

                            </svg>

                        </div>

                        <div>

                            <span class="staff-metric-label">
                                PREPARING ORDERS
                            </span>

                            <h3>19</h3>

                            <p>
                                Being prepared
                            </p>

                        </div>

                    </div>


                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-green">

                            <svg viewBox="0 0 24 24"
                                width="23"
                                height="23"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <circle cx="12" cy="12" r="9" />
                                <path d="M8 12l3 3 5-6" />

                            </svg>

                        </div>

                        <div>

                            <span class="staff-metric-label">
                                COMPLETED TODAY
                            </span>

                            <h3>48</h3>

                            <p>
                                Completed orders
                            </p>

                        </div>

                    </div>

                </div>


                <%-- =================================================
                     ORDERS + DETAILS WORKSPACE
                     ================================================= --%>

                <div class="manager-orders-workspace">


                    <%-- =================================================
                         ALL ORDERS
                         ================================================= --%>

                    <section class="staff-dashboard-panel manager-orders-table-card">

                        <div class="staff-panel-heading">

                            <div>

                                <h5>
                                    All Orders
                                </h5>

                                <small>
                                    All customer orders
                                </small>

                            </div>

                        </div>


                        <div class="table-responsive">

                            <table class="table staff-orders-table manager-orders-table">

                                <thead>

                                    <tr>

                                        <th>Order #</th>
                                        <th>Customer</th>
                                        <th>Items</th>
                                        <th>Total</th>
                                        <th>Payment</th>
                                        <th>Status</th>
                                        <th>Time</th>
                                        <th>Action</th>

                                    </tr>

                                </thead>


                                <tbody>

                                    <tr>

                                        <td>
                                            <strong>#1028</strong>
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
                                            ▣ Card
                                        </td>

                                        <td>
                                            <span class="order-status status-pending">
                                                Pending
                                            </span>
                                        </td>

                                        <td>
                                            14:32
                                        </td>

                                        <td>
                                            ›
                                        </td>

                                    </tr>


                                    <tr>

                                        <td>
                                            <strong>#1027</strong>
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
                                            ▣ Cash
                                        </td>

                                        <td>
                                            <span class="order-status status-preparing">
                                                Preparing
                                            </span>
                                        </td>

                                        <td>
                                            14:21
                                        </td>

                                        <td>
                                            ›
                                        </td>

                                    </tr>


                                    <tr>

                                        <td>
                                            <strong>#1026</strong>
                                        </td>

                                        <td>
                                            Michelle F.
                                        </td>

                                        <td>
                                            4
                                        </td>

                                        <td>
                                            R210.00
                                        </td>

                                        <td>
                                            ▣ Card
                                        </td>

                                        <td>
                                            <span class="order-status status-ready">
                                                Ready
                                            </span>
                                        </td>

                                        <td>
                                            14:05
                                        </td>

                                        <td>
                                            ›
                                        </td>

                                    </tr>


                                    <tr>

                                        <td>
                                            <strong>#1025</strong>
                                        </td>

                                        <td>
                                            Tom R.
                                        </td>

                                        <td>
                                            1
                                        </td>

                                        <td>
                                            R55.00
                                        </td>

                                        <td>
                                            ▣ Cash
                                        </td>

                                        <td>
                                            <span class="order-status status-completed">
                                                Completed
                                            </span>
                                        </td>

                                        <td>
                                            13:48
                                        </td>

                                        <td>
                                            ›
                                        </td>

                                    </tr>


                                    <tr>

                                        <td>
                                            <strong>#1024</strong>
                                        </td>

                                        <td>
                                            Daniel K.
                                        </td>

                                        <td>
                                            2
                                        </td>

                                        <td>
                                            R78.00
                                        </td>

                                        <td>
                                            ▣ Card
                                        </td>

                                        <td>
                                            <span class="order-status status-completed">
                                                Completed
                                            </span>
                                        </td>

                                        <td>
                                            13:35
                                        </td>

                                        <td>
                                            ›
                                        </td>

                                    </tr>


                                    <tr>

                                        <td>
                                            <strong>#1023</strong>
                                        </td>

                                        <td>
                                            Laura S.
                                        </td>

                                        <td>
                                            5
                                        </td>

                                        <td>
                                            R235.00
                                        </td>

                                        <td>
                                            ▣ Card
                                        </td>

                                        <td>
                                            <span class="order-status status-preparing">
                                                Preparing
                                            </span>
                                        </td>

                                        <td>
                                            13:28
                                        </td>

                                        <td>
                                            ›
                                        </td>

                                    </tr>


                                    <tr>

                                        <td>
                                            <strong>#1022</strong>
                                        </td>

                                        <td>
                                            Alex P.
                                        </td>

                                        <td>
                                            1
                                        </td>

                                        <td>
                                            R42.00
                                        </td>

                                        <td>
                                            ▣ Cash
                                        </td>

                                        <td>
                                            <span class="order-status manager-status-cancelled">
                                                Cancelled
                                            </span>
                                        </td>

                                        <td>
                                            13:12
                                        </td>

                                        <td>
                                            ›
                                        </td>

                                    </tr>

                                </tbody>

                            </table>

                        </div>


                        <%-- Pagination mock --%>
                        <div class="manager-orders-pagination">

                            <div>

                                <button type="button">‹</button>
                                <button type="button" class="active">1</button>
                                <button type="button">2</button>
                                <button type="button">3</button>
                                <button type="button">4</button>
                                <button type="button">5</button>
                                <button type="button">›</button>

                            </div>

                            <small>
                                Showing 1-8 of 86 orders
                            </small>

                        </div>

                    </section>


                    <%-- =================================================
                         SELECTED ORDER DETAILS
                         ================================================= --%>

                    <aside class="staff-dashboard-panel manager-order-details">

                        <div class="manager-order-details-header">

                            <div>

                                <h4>
                                    Order #1028
                                </h4>

                                <small>
                                    Placed on 14 Aug 2026 at 14:32
                                </small>

                            </div>

                            <span class="order-status status-pending">
                                Pending
                            </span>

                        </div>


                        <div class="manager-order-detail-section">

                            <small class="staff-detail-label">
                                CUSTOMER
                            </small>

                            <strong>
                                Sarah M.
                            </strong>

                            <span>
                                082 555 0187
                            </span>

                            <span>
                                sarah.m@email.com
                            </span>

                        </div>


                        <div class="manager-order-detail-section">

                            <small class="staff-detail-label">
                                ORDER ITEMS (3)
                            </small>

                            <div class="manager-detail-item">
                                <span>1 × Cappuccino</span>
                                <strong>R42.00</strong>
                            </div>

                            <div class="manager-detail-item">
                                <span>1 × Classic Wrap</span>
                                <strong>R68.00</strong>
                            </div>

                            <div class="manager-detail-item">
                                <span>1 × Vanilla Muffin</span>
                                <strong>R35.00</strong>
                            </div>

                        </div>


                        <div class="manager-order-total">

                            <span>
                                Subtotal
                            </span>

                            <strong>
                                R145.00
                            </strong>

                        </div>


                        <div class="manager-order-total">

                            <span>
                                Total
                            </span>

                            <strong>
                                R145.00
                            </strong>

                        </div>


                        <div class="manager-payment-row">

                            <span>
                                Payment Method
                            </span>

                            <strong>
                                Card
                            </strong>

                        </div>


                        <%-- Action buttons --%>
                        <div class="manager-order-actions">

                            <button type="button"
                                class="manager-order-action manager-action-beige">
                                ↻ Update Status
                            </button>

                            <button type="button"
                                class="manager-order-action manager-action-blue">
                                Assign Staff
                            </button>

                            <button type="button"
                                class="manager-order-action">
                                🖨 Print Receipt
                            </button>

                            <button type="button"
                                class="manager-order-action">
                                ▣ View Receipt
                            </button>

                        </div>

                    </aside>

                </div>


                <%-- =================================================
                     FLAGGED ORDERS + RECENT ACTIVITY
                     ================================================= --%>

                <div class="manager-orders-bottom-grid">


                    <%-- Flagged orders --%>
                    <section class="staff-dashboard-panel">

                        <div class="staff-panel-heading">

                            <div>

                                <h5>
                                    Flagged Orders
                                </h5>

                                <small>
                                    Orders requiring manager attention
                                </small>

                            </div>

                        </div>


                        <div class="manager-flagged-order">

                            <strong>#1018</strong>

                            <span>
                                Michael L.
                            </span>

                            <span>
                                Payment failed
                            </span>

                            <span>
                                Retry payment required
                            </span>

                            <span>
                                12:45
                            </span>

                            <button type="button">
                                View
                            </button>

                        </div>


                        <div class="manager-flagged-order">

                            <strong>#1015</strong>

                            <span>
                                Emma L.
                            </span>

                            <span>
                                Special request
                            </span>

                            <span>
                                Requires manager approval
                            </span>

                            <span>
                                11:30
                            </span>

                            <button type="button">
                                View
                            </button>

                        </div>

                    </section>


                    <%-- Recent activity --%>
                    <section class="staff-dashboard-panel">

                        <div class="staff-panel-heading">

                            <div>
                                <h5>
                                    Recent Activity
                                </h5>
                            </div>

                            <a href="#"
                                class="staff-text-link">
                                View All
                            </a>

                        </div>


                        <div class="manager-activity-item">

                            <span class="manager-activity-dot"></span>

                            <div>

                                <strong>
                                    Order #1028 placed by Sarah M.
                                </strong>

                                <small>
                                    14:32
                                </small>

                            </div>

                        </div>


                        <div class="manager-activity-item">

                            <span class="manager-activity-dot"></span>

                            <div>

                                <strong>
                                    Order #1026 marked as Ready
                                </strong>

                                <small>
                                    14:05
                                </small>

                            </div>

                        </div>

                    </section>

                </div>


                <div class="staff-footer">
                    © 2026 Cafe101 Manager System
                </div>

            </main>

        </div>

    </div>


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

            sidebarToggle.addEventListener("click", function () {

                staffBody.classList.toggle("sidebar-collapsed");

            });

        }

    </script>

</asp:Content>