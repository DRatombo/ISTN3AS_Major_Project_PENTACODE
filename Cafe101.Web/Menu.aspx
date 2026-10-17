<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Menu.aspx.cs"
    Inherits="Cafe101.Web.Menu" %>

<asp:Content ID="BodyContent"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <style>
        /* Use the customer header instead of the public navigation. */
        #mainNavbar {
            display: none !important;
        }

        body {
            padding-top: 0;
        }

        /* Let the header span the screen outside the menu's container. */
        .body-content {
            width: 100%;
            max-width: none;
            padding-left: 0;
            padding-right: 0;
        }

        .ordering-topbar {
            position: sticky;
            top: 0;
            z-index: 1030;
            width: 100%;
            margin: 0;
            background: #fff;
        }

        .ordering-header {
            display: flex;
            align-items: center;
            justify-content: space-between;
            flex-wrap: wrap;
            gap: 16px;
            padding: 18px 24px;
            background: var(--brand-navy);
            color: #fff;
        }

        .ordering-brand {
            color: #fff;
            font-size: 1.5rem;
            font-weight: 700;
            text-decoration: none;
        }

        .ordering-brand:hover,
        .ordering-customer:hover {
            color: #fff;
        }

        .ordering-header-right {
            display: flex;
            align-items: center;
            gap: 24px;
        }

        .ordering-customer {
            display: flex;
            align-items: center;
            gap: 10px;
            color: #fff;
            text-decoration: none;
        }

        .ordering-avatar {
            display: flex;
            align-items: center;
            justify-content: center;
            width: 42px;
            height: 42px;
            flex-shrink: 0;
            border-radius: 50%;
            background: #fff;
            color: var(--brand-navy);
            font-weight: 700;
        }

        .ordering-customer-details strong,
        .ordering-customer-details small {
            display: block;
        }

        .ordering-customer-details small {
            opacity: 0.8;
        }

        .ordering-cart-link {
            position: relative;
            display: inline-flex;
            align-items: center;
            justify-content: center;
            width: 44px;
            height: 44px;
            color: #fff;
            text-decoration: none;
        }

        .ordering-cart-icon {
            font-size: 1.6rem;
            line-height: 1;
        }

        /* The red badge shows the total selected quantity. */
        .ordering-cart-badge {
            position: absolute;
            top: 0;
            right: -4px;
            display: flex;
            align-items: center;
            justify-content: center;
            min-width: 22px;
            height: 22px;
            padding: 0 5px;
            border-radius: 999px;
            background: #dc3545;
            color: #fff;
            border: 2px solid var(--brand-navy);
            font-size: 0.7rem;
            font-weight: 700;
        }

        .ordering-nav {
            display: flex;
            gap: 8px;
            padding: 12px 24px;
            overflow-x: auto;
            background: #fff;
            border-bottom: 1px solid #e2e6ea;
        }

        .ordering-nav a {
            padding: 9px 15px;
            border-radius: 8px;
            color: var(--brand-navy);
            text-decoration: none;
            white-space: nowrap;
            font-weight: 600;
        }

        .ordering-nav a:hover {
            background: #eef1f5;
        }

        .ordering-nav a.active {
            background: var(--brand-navy);
            color: #fff;
        }

        .ordering-header a:focus-visible,
        .ordering-nav a:focus-visible,
        .cart-remove:focus-visible {
            outline: 3px solid #d4a53a;
            outline-offset: 3px;
        }

        .menu-card {
            border: 1px solid #e2e6ea;
            border-radius: 14px;
            background: #fff;
            box-shadow: 0 3px 12px rgba(0, 0, 0, 0.04);
        }

        .menu-card .card-title {
            color: var(--brand-navy);
            font-weight: 700;
        }

        /* Disabled products stay visible with a clear unavailable button. */
        .menu-card .aspNetDisabled,
        .menu-card a[disabled] {
            background: #e9ecef !important;
            border-color: #e9ecef !important;
            color: #595f65 !important;
            cursor: not-allowed;
            text-decoration: none;
        }

        /* Keep the cart below the two navigation rows while scrolling. */
        .order-cart {
            position: sticky;
            top: 155px;
            border: 1px solid #e2e6ea;
            border-radius: 16px;
            background: #fff;
            box-shadow: 0 6px 20px rgba(0, 0, 0, 0.06);
            overflow: hidden;
        }

        .order-cart-header {
            padding: 18px;
            background: var(--brand-navy);
            color: #fff;
        }

        .order-cart-header span {
            font-size: 0.875rem;
        }

        /* Long carts can scroll without extending beyond the screen. */
        .order-cart-body {
            max-height: calc(100vh - 250px);
            overflow-y: auto;
            padding: 16px;
        }

        .cart-line {
            padding: 14px 0;
            border-bottom: 1px solid #e2e6ea;
        }

        .cart-product-name {
            overflow-wrap: anywhere;
        }

        .cart-remove {
            display: inline-block;
            margin-top: 8px;
            color: #a52834;
            font-size: 0.875rem;
            text-decoration: underline;
        }

        @media (max-width: 991.98px) {
            .order-cart {
                position: static;
            }

            .order-cart-body {
                max-height: none;
            }
        }

        @media (max-width: 575.98px) {
            .ordering-header {
                padding: 14px 16px;
            }

            .ordering-header-right {
                gap: 14px;
            }

            .ordering-nav {
                padding: 10px 16px;
            }
        }
    </style>

    <!-- Name, initials and cart quantity are filled by the code-behind. -->
    <div class="ordering-topbar">

        <header class="ordering-header">
            <a href="CustomerDashboard.aspx" class="ordering-brand">
                Cafe101
            </a>

            <div class="ordering-header-right">

                <a href="MyAccount.aspx" class="ordering-customer">
                    <span class="ordering-avatar">
                        <asp:Literal
                            ID="litCustomerInitials"
                            runat="server"
                            Mode="Encode" />
                    </span>

                    <span class="ordering-customer-details">
                        <strong>
                            <asp:Literal
                                ID="litCustomerName"
                                runat="server"
                                Mode="Encode" />
                        </strong>

                        <small>Customer</small>
                    </span>
                </a>

                <a href="CartandPayment.aspx"
                    class="ordering-cart-link"
                    aria-label="View your cart">

                    <span class="ordering-cart-icon"
                        aria-hidden="true">&#128722;</span>

                    <span class="ordering-cart-badge">
                        <asp:Literal
                            ID="litHeaderCartCount"
                            runat="server" />
                    </span>
                </a>

            </div>
        </header>

        <nav class="ordering-nav" aria-label="Customer navigation">
            <a href="CustomerDashboard.aspx">Dashboard</a>
            <a href="Menu.aspx" class="active" aria-current="page">Menu</a>
            <a href="CartandPayment.aspx">Cart</a>
            <a href="OrderHistory.aspx">Order history</a>
            <a href="MyAccount.aspx">My account</a>
        </nav>

    </div>

    <main class="container py-4 pb-5">

        <h1 class="h3 fw-bold mb-2">Menu</h1>
        <p class="text-muted mb-4">
            Choose your items. Your selections will appear in the cart.
        </p>

        <!-- Show loading errors and stock messages here. -->
        <asp:Label
            ID="lblMessage"
            runat="server"
            CssClass="d-block mb-3"
            role="status" />

        <div class="row g-4">

            <section class="col-lg-8" aria-label="Menu items">

                <div class="mb-4">
                    <label for="<%= ddlCategory.ClientID %>"
                        class="form-label fw-semibold">
                        Category
                    </label>

                    <asp:DropDownList
                        ID="ddlCategory"
                        runat="server"
                        CssClass="form-select"
                        AutoPostBack="true"
                        OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" />
                </div>

                <div class="row row-cols-2 row-cols-md-3 g-3">

                    <!-- Search the menu within the selected category. -->
<div class="mb-4">
    <label for="<%= txtMenuSearch.ClientID %>"
        class="form-label fw-semibold">
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

                    <!-- Every product card comes from the database menu. -->
                    <asp:Repeater
                        ID="rptMenu"
                        runat="server"
                        OnItemCommand="rptMenu_ItemCommand">

                        <ItemTemplate>
                            <div class="col">
                                <div class="card menu-card h-100">
                                    <div class="card-body d-flex flex-column">

                                        <h2 class="h6 card-title">
                                            <%#: Eval("MenuItemName") %>
                                        </h2>

                                        <p class="text-muted small mb-2">
                                            <%#: Eval("Category") %>
                                        </p>

                                        <p class="fw-bold mb-2">
                                            R <%# Eval("SellingPrice", "{0:0.00}") %>
                                        </p>

                                        <p class="small mb-3">
                                            <%#: Eval("StockStatus") %>
                                        </p>

                                        <!-- Check status and quantity before enabling Add. -->
                                        <asp:LinkButton
                                            ID="btnAdd"
                                            runat="server"
                                            CssClass="btn btn-sm btn-brand w-100 mt-auto"
                                            Text='<%# CanOrder(Eval("StockStatus"), Eval("AvailableQuantity")) ? "Add to cart" : "Unavailable" %>'
                                            CommandName="AddToCart"
                                            CommandArgument='<%# Eval("MenuItemID") %>'
                                            CausesValidation="false"
                                            Enabled='<%# CanOrder(Eval("StockStatus"), Eval("AvailableQuantity")) %>' />

                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>

                    </asp:Repeater>

                </div>

                <asp:Label
                    ID="lblNoItems"
                    runat="server"
                    Text="No menu items found in this category."
                    CssClass="d-block mt-3 text-muted"
                    Visible="false" />

            </section>

            <aside class="col-lg-4" aria-label="Your cart">

                <div class="order-cart">

                    <div class="order-cart-header">
                        <h2 class="h5 mb-1">Your cart</h2>

                        <asp:Label
                            ID="lblCartCount"
                            runat="server" />
                    </div>

                    <div class="order-cart-body">

                        <asp:Panel
                            ID="pnlEmptyCart"
                            runat="server">

                            <p class="fw-semibold mb-1">
                                Your cart is empty
                            </p>

                            <p class="text-muted small mb-0">
                                Choose an available item from the menu
                                to get started.
                            </p>

                        </asp:Panel>

                        <!-- Display the actual products saved in Session["Cart"]. -->
                        <asp:Repeater
                            ID="rptCart"
                            runat="server"
                            OnItemCommand="rptCart_ItemCommand">

                            <ItemTemplate>
                                <div class="cart-line">

                                    <div class="d-flex justify-content-between gap-3">
                                        <span class="fw-semibold cart-product-name">
                                            <%#: Eval("MenuItemName") %>
                                        </span>

                                        <span class="text-nowrap fw-semibold">
                                            R <%# Eval("LineTotal", "{0:0.00}") %>
                                        </span>
                                    </div>

                                    <div class="small text-muted mt-1">
                                        Quantity: <%# Eval("Quantity") %>
                                        &times; R <%# Eval("UnitPrice", "{0:0.00}") %> each
                                    </div>

                                    <!-- Removes all selected quantities of this product. -->
                                    <asp:LinkButton
                                        ID="btnRemove"
                                        runat="server"
                                        CssClass="cart-remove"
                                        Text="Remove item"
                                        CommandName="RemoveItem"
                                        CommandArgument='<%# Eval("MenuItemID") %>'
                                        CausesValidation="false" />

                                </div>
                            </ItemTemplate>

                        </asp:Repeater>

                        <asp:Panel
                            ID="pnlCartSummary"
                            runat="server">

                            <div class="d-flex justify-content-between mt-3 fw-bold">
                                <span>Subtotal</span>

                                <asp:Label
                                    ID="lblCartSubtotal"
                                    runat="server" />
                            </div>

                            <p class="small text-muted mt-2 mb-0">
                                Items are not reserved until your order is
                                confirmed. Open Cart in the navigation to
                                review your selection.
                            </p>

                            <!-- Open the cart to review items before completing checkout. -->
                                <a href="CartandPayment.aspx"
                                   class="btn btn-brand w-100 mt-3">
                                    Review cart &amp; checkout
                                </a>

                        </asp:Panel>

                    </div>
                </div>

            </aside>

        </div>
    </main>

</asp:Content>