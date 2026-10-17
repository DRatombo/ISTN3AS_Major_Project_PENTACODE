<%@ Page Title="Customer Dashboard"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="CustomerDashboard.aspx.cs"
    Inherits="Cafe101.Web.CustomerDashboard" %>


<asp:Content ID="BodyContent"
    ContentPlaceHolderID="MainContent"
    runat="server">


    <style>

        #mainNavbar {
            display: none;
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
        }


        .customer-header-brand {
            font-size: 1.25rem;
            font-weight: 700;
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


        .customer-search {
            max-width: 420px;
        }


        .customer-hero {
            min-height: 260px;
            border-radius: 14px;
            overflow: hidden;
            position: relative;
            margin-bottom: 28px;
        }


        .customer-hero img {
            width: 100%;
            height: 100%;
            min-height: 260px;
            object-fit: cover;
        }


        .customer-hero-content {
            position: absolute;
            left: 28px;
            top: 50%;
            transform: translateY(-50%);
        }


        .customer-section-title {
            font-weight: 700;
            color: var(--brand-navy);
        }


        .customer-category-row {
            display: flex;
            justify-content: space-between;
            gap: 18px;
            flex-wrap: wrap;
            margin-bottom: 30px;
        }


        .customer-category {
            color: #222;
            text-decoration: none;
            text-align: center;
        }


        .customer-category-circle {
            width: 60px;
            height: 60px;
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
            margin: 0 auto 6px;
            font-size: 1.5rem;
        }


        .customer-menu-scroll {
            display: flex;
            overflow-x: auto;
            gap: 16px;
            padding-bottom: 8px;
            scroll-snap-type: x mandatory;
        }


        .customer-menu-card {
            width: 170px;
            flex-shrink: 0;
            scroll-snap-align: start;
        }


        .customer-menu-card img {
            height: 115px;
            object-fit: contain;
        }


        @media(max-width: 900px) {

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

    </style>



    <div class="customer-shell">


        <%-- =========================================
             TOP HEADER
             ========================================= --%>

        <header class="customer-header">


            <div class="customer-header-left">


                <button type="button"
                    id="customerSidebarToggle"
                    class="customer-menu-button"
                    aria-label="Toggle customer navigation">

                    ☰

                </button>


                <div class="customer-header-brand">
                    Cafe101
                </div>


            </div>



            <div class="customer-header-right">


                <%-- Customer identity --%>

                <a href="MyAccount.aspx"
                    class="customer-header-user">


                    <div class="customer-header-avatar">

                        <asp:Label
                            ID="lblCustomerInitials"
                            runat="server">
                        </asp:Label>

                    </div>


                    <div>

                        <strong>

                            <asp:Label
                                ID="lblTopCustomerName"
                                runat="server">
                            </asp:Label>

                        </strong>

                        <small>
                            Customer
                        </small>

                    </div>


                </a>



                <%-- Cart --%>

               <!-- Keep the cart icon and load the badge count from the session cart. -->
                    <a href="CartandPayment.aspx"
                       class="customer-cart"
                       aria-label="View your cart"
                       style="position: relative;">

                        &#128722;

                        <span class="position-absolute top-0 start-100 translate-middle
                                     badge rounded-pill bg-danger"
                              style="font-size: .6rem;">

                            <asp:Literal
                                ID="litDashboardCartCount"
                                runat="server" />

                        </span>
                    </a>

            </div>


        </header>



        <%-- =========================================
             BODY
             ========================================= --%>

        <div class="customer-body">


            <%-- =========================================
                 LEFT SIDEBAR
                 ========================================= --%>

            <aside class="customer-sidebar">


                <div class="customer-sidebar-title">
                    CUSTOMER SYSTEM
                </div>


                <nav class="customer-nav">


                    <a href="CustomerDashboard.aspx"
                        class="active">

                        <span class="customer-nav-icon">
                            &#8962;
                        </span>

                        <span class="customer-nav-text">
                            Dashboard
                        </span>

                    </a>


                    <a href="Menu.aspx">

                        <span class="customer-nav-icon">
                            ☕
                        </span>

                        <span class="customer-nav-text">
                            Menu
                        </span>

                    </a>


                    <a href="CartandPayment.aspx">

                        <span class="customer-nav-icon">
                            🛒
                        </span>

                        <span class="customer-nav-text">
                            Cart
                        </span>

                    </a>


                    <a href="OrderHistory.aspx">

                        <span class="customer-nav-icon">
                            ▤
                        </span>

                        <span class="customer-nav-text">
                            Order History
                        </span>

                    </a>


                    <a href="MyAccount.aspx">

                        <span class="customer-nav-icon">
                            ♙
                        </span>

                        <span class="customer-nav-text">
                            My Account
                        </span>

                    </a>


                </nav>



                <div class="customer-sidebar-bottom">


                    <asp:LinkButton
                        ID="lnkLogOut"
                        runat="server"
                        CssClass="customer-logout"
                        OnClick="lnkLogOut_Click">

                        <span class="customer-nav-icon">
                            &#10140;
                        </span>

                        <span class="customer-nav-text">
                            Logout
                        </span>

                    </asp:LinkButton>


                </div>


            </aside>



            <%-- =========================================
                 MAIN CUSTOMER CONTENT
                 ========================================= --%>

            <main class="customer-main">


                <div class="customer-main-inner">


                    <div class="customer-page-heading">

                        <h3 class="fw-bold mb-1">

                            Welcome back,

                            <asp:Literal
                                ID="litFirstName"
                                runat="server"
                                Text="Customer" /> 👋

                        </h3>

                        <p class="text-muted mb-0">
                            Browse the Cafe101 menu and place your order.
                        </p>

                    </div>

                    <!-- Search the database menu loaded by the logic layer. -->
<div class="customer-search mb-4">
    <label for="<%= txtSearch.ClientID %>"
        class="form-label">
        Search menu
    </label>

    <div class="input-group">
        <asp:TextBox
            ID="txtSearch"
            runat="server"
            CssClass="form-control"
            MaxLength="100"
            placeholder="Enter a product name..." />

        <asp:Button
            ID="btnSearch"
            runat="server"
            Text="Search"
            CssClass="btn btn-brand"
            CausesValidation="false"
            OnClick="btnSearch_Click" />
    </div>
</div>

<asp:Label
    ID="lblDashboardMessage"
    runat="server"
    CssClass="d-block text-danger mb-3"
    role="status" />

<!-- Category names come from MenuItemsTable. -->
<h5 class="customer-section-title mb-3">Categories</h5>

<div class="customer-category-row">
    <asp:Repeater ID="rptCategories" runat="server">
        <ItemTemplate>
            <a href='<%# GetCategoryUrl((string)Container.DataItem) %>'
                class="customer-category">

                <div class="customer-category-circle"
                    style="background: #e4f0fd;"
                    aria-hidden="true">
                    &#9776;
                </div>

                <small><%#: Container.DataItem %></small>
            </a>
        </ItemTemplate>
    </asp:Repeater>
</div>

<!-- Rank products using quantities recorded in OrderItemTable. -->
<asp:Panel ID="pnlPopularItems" runat="server">
    <h5 class="customer-section-title mb-3">
        Popular items
    </h5>

    <div class="customer-menu-scroll mb-5">
        <asp:Repeater ID="rptPopularItems" runat="server">
            <ItemTemplate>
                <div class="card customer-menu-card">
                    <div class="card-body">
                        <h6 class="fw-bold">
                            <%#: Eval("MenuItemName") %>
                        </h6>

                        <p class="small text-muted mb-2">
                            <%#: Eval("Category") %>
                        </p>

                        <p class="fw-bold text-brand mb-2">
                            R <%# Eval("SellingPrice", "{0:0.00}") %>
                        </p>

                        <p class="small mb-3">
                            <%#: Eval("StockStatus") %>
                        </p>

                        <a href="Menu.aspx"
                            class="btn btn-sm btn-brand w-100">
                            View menu
                        </a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Panel>

<div class="d-flex justify-content-between align-items-center mb-3">
    <h5 class="customer-section-title mb-0">Menu</h5>

    <a href="Menu.aspx" class="small text-brand">
        View all &rarr;
    </a>
</div>

<!-- Show database products matching the search, or a menu preview. -->
<div class="customer-menu-scroll mb-4">
    <asp:Repeater ID="rptMenuPreview" runat="server">
        <ItemTemplate>
            <div class="card customer-menu-card">
                <div class="card-body">
                    <h6 class="fw-bold">
                        <%#: Eval("MenuItemName") %>
                    </h6>

                    <p class="small text-muted mb-2">
                        <%#: Eval("Category") %>
                    </p>

                    <p class="fw-bold text-brand mb-2">
                        R <%# Eval("SellingPrice", "{0:0.00}") %>
                    </p>

                    <p class="small mb-3">
                        <%#: Eval("StockStatus") %>
                    </p>

                    <a href="Menu.aspx"
                        class="btn btn-sm btn-brand w-100">
                        View menu
                    </a>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>

<asp:Label
    ID="lblNoMenuItems"
    runat="server"
    Text="No menu items found."
    CssClass="d-block text-muted mb-4"
    Visible="false" />



                    </div>


                </div>


            </main>


        </div>


    </div>



    <script>

        document.body.classList.add("customer-page");


        // Hide public navbar
        const publicNavbar =
            document.querySelector(".navbar");

        if (publicNavbar) {
            publicNavbar.style.display = "none";
        }


        // Remove normal Bootstrap page spacing
        const bodyContent =
            document.querySelector(".body-content");

        if (bodyContent) {

            bodyContent.classList.remove("container");

            bodyContent.style.width = "100%";
            bodyContent.style.maxWidth = "none";
            bodyContent.style.margin = "0";
            bodyContent.style.padding = "0";

        }


        // Hide master footer
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


        // Sidebar collapse
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

                    document
                        .querySelectorAll(".customer-nav-text")
                        .forEach(function (item) {

                            item.style.display = "";

                        });


                    const title =
                        document.querySelector(
                            ".customer-sidebar-title"
                        );

                    if (title) {
                        title.style.display = "";
                    }

                }
                else {

                    sidebar.style.width = "78px";

                    document
                        .querySelectorAll(".customer-nav-text")
                        .forEach(function (item) {

                            item.style.display = "none";

                        });


                    const title =
                        document.querySelector(
                            ".customer-sidebar-title"
                        );

                    if (title) {
                        title.style.display = "none";
                    }

                }

            });

        }

    </script>


</asp:Content>