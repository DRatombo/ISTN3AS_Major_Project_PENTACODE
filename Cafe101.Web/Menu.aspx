
<%@ Page Title="Menu"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Menu.aspx.cs"
    Inherits="Cafe101.Web.Menu" %>

<asp:Content ID="BodyContent"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <style>
        #mainNavbar {
            display: none !important;
        }

        body {
            padding-top: 0;
        }

        .body-content {
            width: 100%;
            max-width: none;
            margin: 0;
            padding: 0;
        }

        .customer-shell {
            min-height: 100vh;
            background: #f6f7f9;
        }

        .customer-header {
            min-height: 72px;
            background: var(--brand-navy);
            display: flex;
            align-items: center;
            justify-content: space-between;
            padding: 0 24px;
            color: white;
        }

        .customer-header-left {
            display: flex;
            align-items: center;
            gap: 16px;
        }

        .customer-menu-button {
            width: 42px;
            height: 42px;
            border: 0;
            border-radius: 8px;
            background: rgba(255,255,255,.08);
            color: white;
            font-size: 1.3rem;
            cursor: pointer;
        }

        .customer-header-brand {
            font-size: 1.25rem;
            font-weight: 700;
            color: white;
            text-decoration: none;
        }

        .customer-header-right {
            display: flex;
            align-items: center;
            gap: 24px;
        }

        .customer-header-user {
            display: flex;
            align-items: center;
            gap: 10px;
            color: white;
            text-decoration: none;
        }

        .customer-header-user:hover {
            color: white;
        }

        .customer-header-avatar {
            width: 42px;
            height: 42px;
            border-radius: 50%;
            background: white;
            color: var(--brand-navy);
            display: flex;
            align-items: center;
            justify-content: center;
            font-weight: 700;
            flex-shrink: 0;
        }

        .customer-header-user small {
            display: block;
            opacity: .85;
        }

        .customer-cart {
            position: relative;
            color: white;
            text-decoration: none;
            font-size: 1.4rem;
        }

        .customer-cart-badge {
            position: absolute;
            top: -9px;
            right: -12px;
            min-width: 20px;
            padding: 2px 5px;
            border-radius: 999px;
            background: #dc3545;
            color: white;
            font-size: .65rem;
            text-align: center;
            font-weight: 700;
        }

        .customer-body {
            display: flex;
            min-height: calc(100vh - 72px);
        }

        .customer-sidebar {
            width: 230px;
            background: var(--brand-navy);
            color: white;
            padding: 28px 14px 20px;
            display: flex;
            flex-direction: column;
            flex-shrink: 0;
            transition: width .2s ease;
        }

        .customer-sidebar-title {
            color: rgba(255,255,255,.58);
            font-size: .75rem;
            letter-spacing: 1.5px;
            padding: 0 14px 18px;
        }

        .customer-nav {
            display: flex;
            flex-direction: column;
            gap: 6px;
        }

        .customer-nav a {
            color: white;
            text-decoration: none;
            padding: 13px 15px;
            border-radius: 8px;
            display: flex;
            align-items: center;
            gap: 12px;
        }

        .customer-nav a:hover,
        .customer-nav a.active {
            background: rgba(255,255,255,.16);
            color: white;
        }

        .customer-nav-icon {
            width: 22px;
            min-width: 22px;
            text-align: center;
        }

        .customer-sidebar-bottom {
            margin-top: auto;
            padding-top: 20px;
            border-top: 1px solid rgba(255,255,255,.14);
        }

        .customer-logout {
            color: white;
            text-decoration: none;
            padding: 13px 15px;
            display: flex;
            align-items: center;
            gap: 12px;
        }

        .customer-logout:hover {
            color: white;
            background: rgba(255,255,255,.12);
        }

        .customer-main {
            flex: 1;
            min-width: 0;
            padding: 30px;
        }

        .customer-main-inner {
            max-width: 1320px;
            margin: 0 auto;
        }

        .customer-page-heading {
            margin-bottom: 24px;
        }

        .menu-filters {
            display: flex;
            flex-wrap: wrap;
            gap: 16px;
            margin-bottom: 28px;
            align-items: flex-end;
        }

        .menu-filters .form-group {
            margin-bottom: 0;
            min-width: 200px;
        }

        .menu-layout {
            display: grid;
            grid-template-columns: minmax(0, 1fr) 320px;
            gap: 28px;
            align-items: start;
        }

        .menu-grid {
            display: grid;
            grid-template-columns: repeat(auto-fill, minmax(240px, 1fr));
            gap: 20px;
        }

        .menu-card {
            background: white;
            border-radius: 12px;
            overflow: hidden;
            box-shadow: 0 1px 4px rgba(0,0,0,.06);
            display: flex;
            flex-direction: column;
            height: 100%;
        }

        .menu-card img {
            width: 100%;
            height: 170px;
            object-fit: cover;
            background: #f0f0f0;
        }

        .menu-card-body {
            padding: 16px;
            display: flex;
            flex-direction: column;
            flex: 1;
        }

        .menu-card-body h6 {
            font-weight: 700;
            margin-bottom: 4px;
        }

        .menu-card-body .category {
            font-size: .85rem;
            color: #6b7280;
            margin-bottom: 8px;
        }

        .menu-card-body .price {
            font-weight: 700;
            color: var(--brand-navy);
            margin-bottom: 6px;
        }

        .menu-card-body .stock {
            font-size: .85rem;
            margin-bottom: 14px;
        }

        .menu-card-body .btn {
            margin-top: auto;
        }

        .menu-card .aspNetDisabled {
            background: #e9ecef !important;
            border-color: #e9ecef !important;
            color: #595f65 !important;
            cursor: not-allowed;
        }

        .cart-panel {
            background: white;
            border-radius: 12px;
            box-shadow: 0 1px 4px rgba(0,0,0,.06);
            padding: 20px;
            position: sticky;
            top: 24px;
        }

        .cart-panel h5 {
            font-weight: 700;
            margin-bottom: 16px;
        }

        .cart-item {
            display: flex;
            justify-content: space-between;
            align-items: flex-start;
            gap: 10px;
            padding: 10px 0;
            border-bottom: 1px solid #eee;
        }

        .cart-item:last-child {
            border-bottom: 0;
        }

        .cart-summary-row {
            display: flex;
            justify-content: space-between;
            gap: 10px;
            margin-top: 14px;
            font-weight: 700;
        }

        .cart-remove {
            display: inline-block;
            margin-top: 6px;
            color: #a52834;
            font-size: .85rem;
            text-decoration: underline;
        }

        .cart-remove:focus-visible,
        .customer-nav a:focus-visible {
            outline: 3px solid #d4a53a;
            outline-offset: 3px;
        }

        @media (max-width: 1100px) {
            .menu-layout {
                grid-template-columns: 1fr;
            }

            .cart-panel {
                position: static;
            }
        }

        @media (max-width: 900px) {
            .customer-sidebar {
                width: 78px;
            }

            .customer-nav-text,
            .customer-sidebar-title {
                display: none;
            }

            .customer-main {
                padding: 20px;
            }
        }

        @media (max-width: 575px) {
            .customer-header {
                padding: 0 14px;
            }

            .customer-header-right {
                gap: 12px;
            }

            .customer-main {
                padding: 16px;
            }

            .menu-filters .form-group {
                width: 100%;
            }
        }
    </style>

    <div class="customer-shell">

        <!-- TOP HEADER -->
        <header class="customer-header">

            <div class="customer-header-left">

                <button type="button"
                    id="customerSidebarToggle"
                    class="customer-menu-button"
                    aria-label="Toggle navigation">
                    ☰
                </button>

                <a id="lnkOrderingHome"
                    runat="server"
                    class="customer-header-brand"
                    href="CustomerDashboard.aspx">
                    Cafe101
                </a>

            </div>

            <div class="customer-header-right">

                <a id="lnkOrderingAccount"
                    runat="server"
                    href="MyAccount.aspx"
                    class="customer-header-user">

                    <div class="customer-header-avatar">

                        <asp:Literal
                            ID="litCustomerInitials"
                            runat="server"
                            Mode="Encode" />

                    </div>

                    <div>

                        <strong>
                            <asp:Literal
                                ID="litCustomerName"
                                runat="server"
                                Mode="Encode" />
                        </strong>

                        <small>
                            <asp:Literal
                                ID="litUserRole"
                                runat="server"
                                Mode="Encode" />
                        </small>

                    </div>

                </a>

                <a href="CartandPayment.aspx"
                    class="customer-cart"
                    aria-label="View your cart">

                    &#128722;

                    <span class="customer-cart-badge">
                        <asp:Literal
                            ID="litHeaderCartCount"
                            runat="server" />
                    </span>

                </a>

            </div>

        </header>

        <div class="customer-body">

            <!-- SIDEBAR -->
            <aside class="customer-sidebar">

                <div class="customer-sidebar-title">
                    CAFE101 SYSTEM
                </div>

                <nav class="customer-nav" aria-label="Customer navigation">

                    <!-- CUSTOMER NAVIGATION -->
                    <asp:Panel ID="pnlCustomerNav" runat="server">

                        <a id="lnkDashboard"
                            runat="server"
                            href="CustomerDashboard.aspx">

                            <span class="customer-nav-icon">&#8962;</span>
                            <span class="customer-nav-text">Dashboard</span>

                        </a>

                        <a href="Menu.aspx" class="active"
                            aria-current="page">

                            <span class="customer-nav-icon">☕</span>
                            <span class="customer-nav-text">Menu</span>

                        </a>

                        <a href="CartandPayment.aspx">

                            <span class="customer-nav-icon">🛒</span>
                            <span class="customer-nav-text">Cart</span>

                        </a>

                        <a href="OrderHistory.aspx">

                            <span class="customer-nav-icon">▤</span>
                            <span class="customer-nav-text">Order History</span>

                        </a>

                        <a href="MyAccount.aspx">

                            <span class="customer-nav-icon">♙</span>
                            <span class="customer-nav-text">My Account</span>

                        </a>

                    </asp:Panel>

                    <!-- STAFF / CASHIER NAVIGATION -->
                    <asp:Panel ID="pnlStaffNav"
                        runat="server"
                        Visible="false">

                        <a id="lnkStaffDashboard"
                            runat="server"
                            href="StaffDashboard.aspx">

                            <span class="customer-nav-icon">&#8962;</span>
                            <span class="customer-nav-text">Dashboard</span>

                        </a>

                        <a href="Menu.aspx?source=staff"
                            class="active"
                            aria-current="page">

                            <span class="customer-nav-icon">☕</span>
                            <span class="customer-nav-text">Menu</span>

                        </a>

                        <a href="CartandPayment.aspx">

                            <span class="customer-nav-icon">🛒</span>
                            <span class="customer-nav-text">Cart</span>

                        </a>

                        <a href="StaffOrders.aspx">

                            <span class="customer-nav-icon">▤</span>
                            <span class="customer-nav-text">Orders</span>

                        </a>

                    </asp:Panel>

                    <!-- MANAGER NAVIGATION -->
                    <asp:Panel ID="pnlManagerNav"
                        runat="server"
                        Visible="false">

                        <a id="lnkManagerDashboard"
                            runat="server"
                            href="ManagerDashboard.aspx">

                            <span class="customer-nav-icon">&#8962;</span>
                            <span class="customer-nav-text">Dashboard</span>

                        </a>

                        <a href="Menu.aspx?source=staff"
                            class="active"
                            aria-current="page">

                            <span class="customer-nav-icon">☕</span>
                            <span class="customer-nav-text">Menu</span>

                        </a>

                        <a href="CartandPayment.aspx">

                            <span class="customer-nav-icon">🛒</span>
                            <span class="customer-nav-text">Cart</span>

                        </a>

                    </asp:Panel>

                </nav>

                <!-- LOGOUT -->
                <div class="customer-sidebar-bottom">

                    <asp:LinkButton
                        ID="lnkLogOut"
                        runat="server"
                        CssClass="customer-logout"
                        OnClick="lnkLogOut_Click"
                        CausesValidation="false">

                        <span class="customer-nav-icon">&#10140;</span>
                        <span class="customer-nav-text">Logout</span>

                    </asp:LinkButton>

                </div>

            </aside>

            <!-- MAIN CONTENT -->
            <main class="customer-main">

                <div class="customer-main-inner">

                    <div class="customer-page-heading">

                        <h3 class="fw-bold mb-1">
                            Menu
                        </h3>

                        <p class="text-muted mb-0">
                            Choose your items. Your selections will appear in the cart.
                        </p>

                    </div>

                    <!-- CATEGORY AND SEARCH -->
                    <div class="menu-filters">

                        <div class="form-group">

                            <label
                                for="<%= ddlCategory.ClientID %>"
                                class="form-label">
                                Category
                            </label>

                            <asp:DropDownList
                                ID="ddlCategory"
                                runat="server"
                                CssClass="form-select"
                                AutoPostBack="true"
                                OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" />

                        </div>

                        <div class="form-group" style="min-width:280px;">

                            <label
                                for="<%= txtMenuSearch.ClientID %>"
                                class="form-label">
                                Search menu
                            </label>

                            <asp:Panel
                                ID="pnlMenuSearch"
                                runat="server"
                                DefaultButton="btnMenuSearch">

                                <div class="input-group">

                                    <asp:TextBox
                                        ID="txtMenuSearch"
                                        runat="server"
                                        CssClass="form-control"
                                        MaxLength="100"
                                        placeholder="Enter an item name..." />

                                    <asp:Button
                                        ID="btnMenuSearch"
                                        runat="server"
                                        Text="Search"
                                        CssClass="btn btn-brand"
                                        CausesValidation="false"
                                        OnClick="btnMenuSearch_Click" />

                                    <asp:Button
                                        ID="btnClearSearch"
                                        runat="server"
                                        Text="Clear"
                                        CssClass="btn btn-outline-secondary"
                                        CausesValidation="false"
                                        OnClick="btnClearSearch_Click" />

                                </div>

                            </asp:Panel>

                        </div>

                    </div>

                    <!-- STATUS MESSAGE -->
                    <asp:Label
                        ID="lblMessage"
                        runat="server"
                        CssClass="d-block mb-3"
                        role="status" />

                    <div class="menu-layout">

                        <!-- MENU ITEMS -->
                        <div>

                            <div class="menu-grid">

                                <asp:Repeater
                                    ID="rptMenu"
                                    runat="server"
                                    OnItemCommand="rptMenu_ItemCommand">

                                    <ItemTemplate>

                                        <div class="menu-card">

                                            <asp:Image
                                                ID="imgItem"
                                                runat="server"
                                                ImageUrl='<%# GetMenuItemImage(Convert.ToString(Eval("MenuItemName"))) %>'
                                                Visible='<%# !string.IsNullOrEmpty(GetMenuItemImage(Convert.ToString(Eval("MenuItemName")))) %>'
                                                AlternateText="Menu item image" />

                                            <div class="menu-card-body">

                                                <h6>
                                                    <%#: Eval("MenuItemName") %>
                                                </h6>

                                                <div class="category">
                                                    <%#: Eval("Category") %>
                                                </div>

                                                <div class="price">
                                                    R <%# Eval("SellingPrice", "{0:0.00}") %>
                                                </div>

                                                <div class="stock">
                                                    <%#: Eval("StockStatus") %>
                                                </div>

                                                <asp:LinkButton
                                                    ID="btnAddToCart"
                                                    runat="server"
                                                    CssClass="btn btn-brand w-100"
                                                    CommandName="AddToCart"
                                                    CommandArgument='<%# Eval("MenuItemID") %>'
                                                    CausesValidation="false"
                                                    Enabled='<%# CanOrder(Eval("StockStatus"), Eval("AvailableQuantity")) %>'
                                                    Text='<%# CanOrder(Eval("StockStatus"), Eval("AvailableQuantity")) ? "Add to cart" : "Unavailable" %>' />

                                            </div>

                                        </div>

                                    </ItemTemplate>

                                </asp:Repeater>

                            </div>

                            <asp:Label
                                ID="lblNoItems"
                                runat="server"
                                Text="No items match your search and selected category."
                                CssClass="d-block text-muted mt-4"
                                Visible="false" />

                        </div>

                        <!-- CART SUMMARY -->
                        <aside class="cart-panel"
                            aria-label="Your cart">

                            <h5>
                                Your Cart
                            </h5>

                            <asp:Panel
                                ID="pnlEmptyCart"
                                runat="server">

                                <p class="text-muted mb-0">
                                    Your cart is empty.
                                </p>

                            </asp:Panel>

                            <asp:Panel
                                ID="pnlCartSummary"
                                runat="server">

                                <asp:Repeater
                                    ID="rptCart"
                                    runat="server"
                                    OnItemCommand="rptCart_ItemCommand">

                                    <ItemTemplate>

                                        <div class="cart-item">

                                            <div>

                                                <strong>
                                                    <%#: Eval("MenuItemName") %>
                                                </strong>

                                                <div class="small text-muted">
                                                    <%# Eval("Quantity") %>
                                                    × R <%# Eval("UnitPrice", "{0:0.00}") %>
                                                </div>

                                            </div>

                                            <div class="text-end">

                                                <div class="fw-bold">
                                                    R <%# Eval("LineTotal", "{0:0.00}") %>
                                                </div>

                                                <asp:LinkButton
                                                    ID="btnRemove"
                                                    runat="server"
                                                    CommandName="RemoveItem"
                                                    CommandArgument='<%# Eval("MenuItemID") %>'
                                                    CssClass="cart-remove"
                                                    CausesValidation="false">
                                                    Remove
                                                </asp:LinkButton>

                                            </div>

                                        </div>

                                    </ItemTemplate>

                                </asp:Repeater>

                                <div class="cart-summary-row">

                                    <span>
                                        <asp:Label
                                            ID="lblCartCount"
                                            runat="server" />
                                    </span>

                                    <span>
                                        <asp:Label
                                            ID="lblCartSubtotal"
                                            runat="server" />
                                    </span>

                                </div>

                                <a href="CartandPayment.aspx"
                                    class="btn btn-brand w-100 mt-3">
                                    Review cart &amp; checkout
                                </a>

                            </asp:Panel>

                        </aside>

                    </div>

                </div>

            </main>

        </div>

    </div>

    <script>

        document.body.classList.add("customer-page");

        // Hide the public navigation from Site.Master.
        const publicNavbar = document.querySelector(".navbar");

        if (publicNavbar) {
            publicNavbar.style.display = "none";
        }

        // Remove the default container spacing.
        const bodyContent = document.querySelector(".body-content");

        if (bodyContent) {
            bodyContent.classList.remove("container");
            bodyContent.style.width = "100%";
            bodyContent.style.maxWidth = "none";
            bodyContent.style.margin = "0";
            bodyContent.style.padding = "0";
        }

        // Hide the Site.Master footer.
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

        // Toggle the sidebar on smaller screens.
        const toggle =
            document.getElementById("customerSidebarToggle");

        const sidebar =
            document.querySelector(".customer-sidebar");

        if (toggle && sidebar) {

            toggle.addEventListener("click", function () {

                const collapsed =
                    sidebar.style.width === "78px";

                if (collapsed) {

                    sidebar.style.width = "230px";

                    document.querySelectorAll(".customer-nav-text")
                        .forEach(function (item) {
                            item.style.display = "";
                        });

                    const title =
                        document.querySelector(".customer-sidebar-title");

                    if (title) {
                        title.style.display = "";
                    }

                } else {

                    sidebar.style.width = "78px";

                    document.querySelectorAll(".customer-nav-text")
                        .forEach(function (item) {
                            item.style.display = "none";
                        });

                    const title =
                        document.querySelector(".customer-sidebar-title");

                    if (title) {
                        title.style.display = "none";
                    }

                }

            });

        }

    </script>

</asp:Content>
