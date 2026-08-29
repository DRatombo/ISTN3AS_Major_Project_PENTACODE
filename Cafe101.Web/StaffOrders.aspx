<%@ Page Title="Staff Orders"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="StaffOrders.aspx.cs"
    Inherits="Cafe101.Web.StaffOrders" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


    <div class="staff-shell">


        <%-- =================================================
             TOP NAVY HEADER
             ================================================= --%>

        <header class="staff-header">

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
                 LOGGED-IN STAFF MEMBER
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
                    STAFF SYSTEM
                </div>


                <nav class="staff-nav">


                    <%-- Dashboard --%>

                    <a href="StaffDashboard.aspx">

                        <span class="staff-nav-icon">
                            &#8962;
                        </span>

                        <span class="staff-nav-text">
                            Dashboard
                        </span>

                    </a>



                    <%-- Orders --%>

                    <a href="StaffOrders.aspx"
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
                 MAIN ORDERS AREA
                 ================================================= --%>

            <main class="staff-main">


                <div class="staff-page-heading">

                    <h3>
                        Orders
                    </h3>

                    <p>
                        Manage and track customer orders.
                    </p>

                </div>



                <%-- =================================================
                     SEARCH / FILTER TOOLBAR
                     ================================================= --%>

                <div class="staff-orders-toolbar">


                    <div class="staff-orders-toolbar-left">


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


                            <input type="text"
                                class="form-control"
                                placeholder="Search by order # or customer name..." />

                        </div>



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

                                <option value="">
                                    Filter by status
                                </option>

                                <option value="Pending">
                                    Pending
                                </option>

                                <option value="Preparing">
                                    Preparing
                                </option>

                                <option value="Ready">
                                    Ready
                                </option>

                                <option value="Completed">
                                    Completed
                                </option>

                            </select>

                        </div>


                    </div>



                    <div class="staff-orders-toolbar-right">

                        <button type="button"
                            class="btn btn-outline-brand">

                            ↻ Refresh Orders

                        </button>


                        <button type="button"
                            class="btn btn-brand">

                            + New Order

                        </button>

                    </div>


                </div>



                <%-- =================================================
                     ORDER STATUS SUMMARY
                     ================================================= --%>

                <div class="staff-metric-grid">


                    <%-- NEW ORDERS --%>

                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-green">

                            <svg viewBox="0 0 24 24"
                                width="25"
                                height="25"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <path d="M6 7h12l-1 13H7L6 7z" />
                                <path d="M9 7a3 3 0 0 1 6 0" />

                            </svg>

                        </div>


                        <div>

                            <span class="staff-metric-label">
                                NEW ORDERS
                            </span>

                            <h3>
                                8
                            </h3>

                            <p>
                                Waiting to be processed
                            </p>

                        </div>

                    </div>



                    <%-- PREPARING --%>

                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-orange">

                            <svg viewBox="0 0 24 24"
                                width="25"
                                height="25"
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

                            <span class="staff-metric-label">
                                PREPARING
                            </span>

                            <h3>
                                4
                            </h3>

                            <p>
                                Currently being prepared
                            </p>

                        </div>

                    </div>



                    <%-- READY --%>

                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-blue">

                            <svg viewBox="0 0 24 24"
                                width="25"
                                height="25"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <path d="M4 12l5 5L20 6" />

                            </svg>

                        </div>


                        <div>

                            <span class="staff-metric-label">
                                READY
                            </span>

                            <h3>
                                3
                            </h3>

                            <p>
                                Ready for collection
                            </p>

                        </div>

                    </div>



                    <%-- COMPLETED --%>

                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-purple">

                            <svg viewBox="0 0 24 24"
                                width="25"
                                height="25"
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

                            <span class="staff-metric-label">
                                COMPLETED TODAY
                            </span>

                            <h3>
                                12
                            </h3>

                            <p>
                                Orders completed today
                            </p>

                        </div>

                    </div>


                </div>



                <%-- =================================================
                     ORDERS WORKSPACE
                     ================================================= --%>

                <div class="staff-orders-workspace"
                    id="ordersWorkspace">


                    <section class="staff-dashboard-panel staff-orders-full">


                        <div class="staff-panel-heading">

                            <div>

                                <h5>
                                    All Orders
                                </h5>

                                <small>
                                    View and manage customer orders
                                </small>

                            </div>

                        </div>



                        <div class="table-responsive">


                            <table class="table staff-orders-table">


                                <thead>

                                    <tr>

                                        <th>Order #</th>

                                        <th>Customer</th>

                                        <th>Items</th>

                                        <th>Total</th>

                                        <th>Time</th>

                                        <th>Status</th>

                                        <th>Action</th>

                                    </tr>

                                </thead>



                                <tbody>


                                    <%-- 1008 --%>

                                    <tr>

                                        <td>
                                            <strong>#1008</strong>
                                        </td>

                                        <td>
                                            Sarah M.
                                        </td>

                                        <td>
                                            3 items
                                        </td>

                                        <td>
                                            R145.00
                                        </td>

                                        <td>
                                            14:25
                                        </td>

                                        <td>

                                            <span class="order-status status-pending">
                                                Pending
                                            </span>

                                        </td>


                                        <td>

                                            <button type="button"
                                                class="btn btn-sm btn-outline-brand view-order-details"
                                                data-order="#1008"
                                                data-customer="Sarah M."
                                                data-items="1 × Cappuccino~R45.00|1 × Chicken Wrap~R65.00|1 × Chocolate Muffin~R35.00"
                                                data-total="R145.00"
                                                data-time="14:25"
                                                data-status="Pending">

                                                View Details

                                            </button>

                                        </td>

                                    </tr>



                                    <%-- 1007 --%>

                                    <tr>

                                        <td>
                                            <strong>#1007</strong>
                                        </td>

                                        <td>
                                            John D.
                                        </td>

                                        <td>
                                            2 items
                                        </td>

                                        <td>
                                            R98.00
                                        </td>

                                        <td>
                                            14:18
                                        </td>

                                        <td>

                                            <span class="order-status status-preparing">
                                                Preparing
                                            </span>

                                        </td>


                                        <td>

                                            <button type="button"
                                                class="btn btn-sm btn-outline-brand view-order-details"
                                                data-order="#1007"
                                                data-customer="John D."
                                                data-items="1 × Iced Latte~R53.00|1 × Butter Croissant~R45.00"
                                                data-total="R98.00"
                                                data-time="14:18"
                                                data-status="Preparing">

                                                View Details

                                            </button>

                                        </td>

                                    </tr>



                                    <%-- 1006 --%>

                                    <tr>

                                        <td>
                                            <strong>#1006</strong>
                                        </td>

                                        <td>
                                            Amanda K.
                                        </td>

                                        <td>
                                            4 items
                                        </td>

                                        <td>
                                            R210.00
                                        </td>

                                        <td>
                                            14:05
                                        </td>

                                        <td>

                                            <span class="order-status status-ready">
                                                Ready
                                            </span>

                                        </td>


                                        <td>

                                            <button type="button"
                                                class="btn btn-sm btn-outline-brand view-order-details"
                                                data-order="#1006"
                                                data-customer="Amanda K."
                                                data-items="1 × Cappuccino~R45.00|1 × Cheese Toastie~R65.00|1 × Muffin~R35.00|1 × Cold Drink~R65.00"
                                                data-total="R210.00"
                                                data-time="14:05"
                                                data-status="Ready">

                                                View Details

                                            </button>

                                        </td>

                                    </tr>



                                    <%-- 1005 --%>

                                    <tr>

                                        <td>
                                            <strong>#1005</strong>
                                        </td>

                                        <td>
                                            Michael P.
                                        </td>

                                        <td>
                                            1 item
                                        </td>

                                        <td>
                                            R55.00
                                        </td>

                                        <td>
                                            13:52
                                        </td>

                                        <td>

                                            <span class="order-status status-completed">
                                                Completed
                                            </span>

                                        </td>


                                        <td>

                                            <button type="button"
                                                class="btn btn-sm btn-outline-brand view-order-details"
                                                data-order="#1005"
                                                data-customer="Michael P."
                                                data-items="1 × Breakfast Combo~R55.00"
                                                data-total="R55.00"
                                                data-time="13:52"
                                                data-status="Completed">

                                                View Details

                                            </button>

                                        </td>

                                    </tr>



                                    <%-- 1004 --%>

                                    <tr>

                                        <td>
                                            <strong>#1004</strong>
                                        </td>

                                        <td>
                                            Lerato N.
                                        </td>

                                        <td>
                                            5 items
                                        </td>

                                        <td>
                                            R275.00
                                        </td>

                                        <td>
                                            13:41
                                        </td>

                                        <td>

                                            <span class="order-status status-preparing">
                                                Preparing
                                            </span>

                                        </td>


                                        <td>

                                            <button type="button"
                                                class="btn btn-sm btn-outline-brand view-order-details"
                                                data-order="#1004"
                                                data-customer="Lerato N."
                                                data-items="1 × Cappuccino~R45.00|1 × Toastie~R65.00|1 × Muffin~R35.00|1 × Cold Drink~R55.00|1 × Croissant~R75.00"
                                                data-total="R275.00"
                                                data-time="13:41"
                                                data-status="Preparing">

                                                View Details

                                            </button>

                                        </td>

                                    </tr>


                                </tbody>


                            </table>


                        </div>


                    </section>



                    <%-- =================================================
                         ORDER DETAILS PANEL
                         ================================================= --%>

                    <aside class="staff-order-details"
                        id="orderDetailsPanel">


                        <div class="staff-order-details-header">


                            <div class="staff-order-heading-left">

                                <h4 id="detailOrderNumber">
                                    Order #1008
                                </h4>

                                <p class="staff-order-placed">

                                    Placed at

                                    <span id="detailHeaderTime">
                                        14:25
                                    </span>

                                </p>

                            </div>



                            <div class="staff-order-heading-right">


                                <span id="detailStatus"
                                    class="order-status status-pending">

                                    Pending

                                </span>


                                <button type="button"
                                    id="closeOrderDetails"
                                    class="staff-details-close"
                                    aria-label="Close order details">

                                    ×

                                </button>


                            </div>


                        </div>



                        <%-- CUSTOMER --%>

                        <div class="staff-details-section">


                            <small class="staff-detail-label">
                                CUSTOMER
                            </small>


                            <div class="staff-customer-row">


                                <div class="staff-customer-icon">

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

                                </div>


                                <div>

                                    <strong id="detailCustomer">
                                        Sarah M.
                                    </strong>

                                    <small class="staff-customer-number">
                                        Customer
                                    </small>

                                </div>


                            </div>


                        </div>



                        <%-- ITEMS --%>

                        <div class="staff-details-section">


                            <div class="staff-order-items-heading">

                                <small class="staff-detail-label">
                                    ORDER ITEMS
                                </small>

                                <small id="detailItemCount"
                                    class="staff-order-item-count">
                                    (3)
                                </small>

                            </div>


                            <div id="detailItems"
                                class="staff-detail-items">
                            </div>



                            <div class="staff-order-total-row">

                                <strong>
                                    Total
                                </strong>

                                <strong id="detailItemsTotal">
                                    R145.00
                                </strong>

                            </div>


                        </div>



                        <%-- UPDATE STATUS --%>

                        <div class="staff-details-actions">


                            <div class="staff-status-dropdown">


                                <button type="button"
                                    id="updateStatusToggle"
                                    class="staff-update-status-menu">


                                    <span class="staff-update-status-left">


                                        <svg viewBox="0 0 24 24"
                                            width="18"
                                            height="18"
                                            fill="none"
                                            stroke="currentColor"
                                            stroke-width="2">

                                            <path d="M20 11a8 8 0 1 0-2.3 5.7" />
                                            <path d="M20 4v7h-7" />

                                        </svg>


                                        <span>
                                            Update Status
                                        </span>


                                    </span>



                                    <span class="staff-update-status-arrow">


                                        <svg viewBox="0 0 24 24"
                                            width="16"
                                            height="16"
                                            fill="none"
                                            stroke="currentColor"
                                            stroke-width="2"
                                            stroke-linecap="round"
                                            stroke-linejoin="round">

                                            <path d="M6 9l6 6 6-6" />

                                        </svg>


                                    </span>


                                </button>



                                <div id="statusDropdownMenu"
                                    class="staff-status-dropdown-menu">


                                    <button type="button"
                                        data-status="Pending">

                                        Pending

                                    </button>


                                    <button type="button"
                                        data-status="Preparing">

                                        Preparing

                                    </button>


                                    <button type="button"
                                        data-status="Ready">

                                        Ready

                                    </button>


                                    <button type="button"
                                        data-status="Completed">

                                        Completed

                                    </button>


                                </div>


                            </div>


                        </div>


                    </aside>


                </div>


            </main>


        </div>


    </div>



    <%-- =================================================
         JAVASCRIPT
         ================================================= --%>

    <script>


        // =====================================================
        // STAFF PAGE SETUP
        // =====================================================

        document.body.classList.add("staff-page");


        const publicNavbar =
            document.querySelector(".navbar");


        if (publicNavbar) {

            publicNavbar.style.display = "none";

        }



        const bodyContent =
            document.querySelector(".body-content");


        if (bodyContent) {

            bodyContent.classList.remove("container");

            bodyContent.style.width = "100%";

            bodyContent.style.maxWidth = "none";

            bodyContent.style.margin = "0";

            bodyContent.style.padding = "0";

        }



        const masterFooter =
            document.querySelector(".body-content > footer");


        if (masterFooter) {

            masterFooter.style.display = "none";

        }



        const masterFooterLine =
            document.querySelector(".body-content > hr");


        if (masterFooterLine) {

            masterFooterLine.style.display = "none";

        }



        // =====================================================
        // SIDEBAR
        // =====================================================

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



        // =====================================================
        // ORDER DETAILS
        // =====================================================

        const ordersWorkspace =
            document.getElementById("ordersWorkspace");


        const closeOrderDetails =
            document.getElementById("closeOrderDetails");


        const detailButtons =
            document.querySelectorAll(
                ".view-order-details"
            );



        detailButtons.forEach(function (button) {


            button.addEventListener(
                "click",
                function () {


                    const order =
                        button.dataset.order;


                    const customer =
                        button.dataset.customer;


                    const total =
                        button.dataset.total;


                    const time =
                        button.dataset.time;


                    const status =
                        button.dataset.status;


                    const items =
                        button.dataset.items.split("|");



                    document.getElementById(
                        "detailOrderNumber"
                    ).textContent =
                        "Order " + order;



                    document.getElementById(
                        "detailHeaderTime"
                    ).textContent =
                        time;



                    document.getElementById(
                        "detailCustomer"
                    ).textContent =
                        customer;



                    // =================================================
                    // STATUS
                    // =================================================

                    const detailStatus =
                        document.getElementById(
                            "detailStatus"
                        );


                    detailStatus.textContent =
                        status;


                    detailStatus.className =
                        "order-status";


                    if (status === "Pending") {

                        detailStatus.classList.add(
                            "status-pending"
                        );

                    }

                    else if (status === "Preparing") {

                        detailStatus.classList.add(
                            "status-preparing"
                        );

                    }

                    else if (status === "Ready") {

                        detailStatus.classList.add(
                            "status-ready"
                        );

                    }

                    else if (status === "Completed") {

                        detailStatus.classList.add(
                            "status-completed"
                        );

                    }



                    // =================================================
                    // ITEMS
                    // =================================================

                    const itemsContainer =
                        document.getElementById(
                            "detailItems"
                        );


                    itemsContainer.innerHTML =
                        "";


                    let totalItemCount =
                        0;



                    items.forEach(
                        function (item) {


                            const parts =
                                item.split("~");


                            const itemDetails =
                                parts[0].trim();


                            const itemPrice =
                                parts.length > 1
                                    ? parts[1].trim()
                                    : "";



                            const quantityParts =
                                itemDetails.split("×");


                            const quantity =
                                parseInt(
                                    quantityParts[0].trim()
                                );


                            totalItemCount +=
                                isNaN(quantity)
                                    ? 1
                                    : quantity;



                            const row =
                                document.createElement(
                                    "div"
                                );


                            row.className =
                                "staff-detail-item";



                            const nameSpan =
                                document.createElement(
                                    "span"
                                );


                            nameSpan.className =
                                "staff-detail-item-name";


                            nameSpan.textContent =
                                itemDetails;



                            const priceSpan =
                                document.createElement(
                                    "span"
                                );


                            priceSpan.className =
                                "staff-detail-item-price";


                            priceSpan.textContent =
                                itemPrice;



                            row.appendChild(
                                nameSpan
                            );


                            row.appendChild(
                                priceSpan
                            );


                            itemsContainer.appendChild(
                                row
                            );


                        });



                    document.getElementById(
                        "detailItemCount"
                    ).textContent =
                        "(" + totalItemCount + ")";



                    document.getElementById(
                        "detailItemsTotal"
                    ).textContent =
                        total;



                    if (ordersWorkspace) {

                        ordersWorkspace.classList.add(
                            "details-open"
                        );

                    }


                });

        });



        // =====================================================
        // CLOSE DETAILS
        // =====================================================

        if (closeOrderDetails &&
            ordersWorkspace) {


            closeOrderDetails.addEventListener(
                "click",
                function () {


                    ordersWorkspace.classList.remove(
                        "details-open"
                    );


                });

        }



        // =====================================================
        // STATUS DROPDOWN
        // =====================================================

        const updateStatusToggle =
            document.getElementById(
                "updateStatusToggle"
            );


        const statusDropdown =
            document.querySelector(
                ".staff-status-dropdown"
            );


        if (updateStatusToggle &&
            statusDropdown) {


            updateStatusToggle.addEventListener(
                "click",
                function () {


                    statusDropdown.classList.toggle(
                        "open"
                    );


                });

        }


    </script>


</asp:Content>