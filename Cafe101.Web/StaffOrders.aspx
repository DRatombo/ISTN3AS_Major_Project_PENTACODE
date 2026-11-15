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


                            <asp:TextBox ID="txtOrderSearch" runat="server" CssClass="form-control"
                                placeholder="Search by order # or customer name..."
                                AutoPostBack="true" OnTextChanged="FilterOrders_Changed" />

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


                            <asp:DropDownList ID="ddlStatusFilter" runat="server"
                                CssClass="form-control staff-status-filter"
                                AutoPostBack="true" OnSelectedIndexChanged="FilterOrders_Changed">
                                <asp:ListItem Text="Filter by status" Value="" />
                                <asp:ListItem Text="Pending" Value="Pending" />
                                <asp:ListItem Text="Preparing" Value="Preparing" />
                                <asp:ListItem Text="Ready" Value="Ready" />
                                <asp:ListItem Text="Completed" Value="Completed" />
                            </asp:DropDownList>

                        </div>


                    </div>



                    <div class="staff-orders-toolbar-right">

                        <button type="button"
                            class="btn btn-outline-brand">

                            ↻ Refresh Orders

                        </button>


                        <asp:Button ID="btnNewOrder" runat="server"
                                 Text="+ New Order"
                                 CssClass="btn btn-brand"
                                 OnClick="btnNewOrder_Click"
                                 CausesValidation="false" />

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

                            <h3><asp:Label ID="lblNewOrdersCount" runat="server" Text="0" /></h3>

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

                            <h3><asp:Label ID="lblPreparingCount" runat="server" Text="0" /></h3>

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

                            <h3><asp:Label ID="lblReadyCount" runat="server" Text="0" /></h3>

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

                            <h3><asp:Label ID="lblCompletedTodayCount" runat="server" Text="0" /></h3>

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
                                    <asp:Repeater ID="rptAllOrders" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><strong>#<%#: Eval("OrderID") %></strong></td>
                                                <td><%#: Eval("CustomerName") %></td>
                                                <td><%# Convert.ToInt32(Eval("ItemCount")) == 1 ? "1 item" : Eval("ItemCount") + " items" %></td>
                                                <td>R<%# Eval("TotalAmountDue", "{0:N2}") %></td>
                                                <td><%# Eval("OrderDateTime", "{0:HH:mm}") %></td>
                                                <td><span class='order-status <%# GetStatusCss(Eval("OrderStatus")) %>'><%#: Eval("OrderStatus") %></span></td>
                                                <td>
                                                    <button type="button" class="btn btn-sm btn-outline-brand view-order-details"
                                                        data-order="#<%#: Eval("OrderID") %>"
                                                        data-customer="<%#: Eval("CustomerName") %>"
                                                        data-items="<%#: Eval("ItemsSummary") %>"
                                                        data-total="R<%# Eval("TotalAmountDue", "{0:N2}") %>"
                                                        data-time="<%# Eval("OrderDateTime", "{0:HH:mm}") %>"
                                                        data-status="<%#: Eval("OrderStatus") %>">
                                                        View Details
                                                    </button>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
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
                                    Order Details
                                </h4>

                                <p class="staff-order-placed">

                                    Placed at

                                    <span id="detailHeaderTime">
                                        --:--
                                    </span>

                                </p>

                            </div>



                            <div class="staff-order-heading-right">


                                <span id="detailStatus" class="order-status">
                                    Select an order
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
                                        Select an order
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

                                <small id="detailItemCount" class="staff-order-item-count">(0)</small>

                            </div>


                            <div id="detailItems"
                                class="staff-detail-items">
                            </div>



                            <div class="staff-order-total-row">

                                <strong>
                                    Total
                                </strong>

                                <strong id="detailItemsTotal">R0.00</strong>

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


                    const items = button.dataset.items
                        ? button.dataset.items.split("|")
                        : [];



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



                    if (items.length === 0) {
                        itemsContainer.textContent = "No items found.";
                    }

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
                                itemDetails.split(/×|x/i);


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