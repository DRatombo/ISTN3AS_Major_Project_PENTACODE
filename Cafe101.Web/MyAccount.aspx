<%@ Page Title="My Account"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="MyAccount.aspx.cs"
    Inherits="Cafe101.Web.MyAccount" %>

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

        /* =========================
           TOP HEADER
           ========================= */

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

        /* =========================
           BODY
           ========================= */

        .customer-body {
            display: flex;
            min-height: calc(100vh - 72px);
        }

        /* =========================
           SIDEBAR
           ========================= */

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
            color: white;
            background: rgba(255,255,255,.16);
        }

        .customer-nav-icon {
            width: 22px;
            text-align: center;
            flex-shrink: 0;
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
            background: rgba(255,255,255,.10);
            border-radius: 8px;
        }

        /* =========================
           MAIN CONTENT
           ========================= */

        .customer-main {
            flex: 1;
            min-width: 0;
            padding: 30px;
        }

        .account-content {
            max-width: 1100px;
            margin: 0 auto;
        }

        .account-heading {
            margin-bottom: 24px;
        }

        /* =========================
           PROFILE SUMMARY
           ========================= */

        .account-summary {
            background: white;
            border: 1px solid #e1e5ea;
            border-radius: 12px;
            padding: 24px;
            margin-bottom: 20px;

            display: flex;
            align-items: center;
            justify-content: space-between;
            gap: 20px;
        }

        .account-summary-left {
            display: flex;
            align-items: center;
            gap: 18px;
        }

        .account-avatar {
            width: 72px;
            height: 72px;
            border-radius: 50%;
            background: #eee6f8;
            color: #704b8c;

            display: flex;
            align-items: center;
            justify-content: center;

            font-size: 1.35rem;
            font-weight: 700;
            flex-shrink: 0;
        }

        .account-summary h4 {
            margin-bottom: 3px;
            color: var(--brand-navy);
        }

        .account-summary p {
            margin: 0;
            color: #6c757d;
        }

        /* =========================
           ACCOUNT GRID
           ========================= */

        .account-grid {
            display: grid;
            grid-template-columns: 2fr 1fr;
            gap: 18px;
            align-items: start;
        }

        .account-card {
            background: white;
            border: 1px solid #e1e5ea;
            border-radius: 12px;
            padding: 22px;
        }

        .account-card-title {
            font-weight: 700;
            color: var(--brand-navy);
            padding-bottom: 14px;
            margin-bottom: 18px;
            border-bottom: 1px solid #e7e9ec;
        }

        .account-label {
            font-size: .82rem;
            color: #6c757d;
            margin-bottom: 5px;
        }

        .account-readonly-row {
            display: flex;
            justify-content: space-between;
            align-items: center;
            gap: 20px;
            padding: 13px 0;
            border-bottom: 1px solid #edf0f2;
        }

        .account-readonly-row:last-child {
            border-bottom: none;
        }

        .account-status {
            background: #e5f4e7;
            color: #247036;
            border-radius: 7px;
            padding: 4px 10px;
            font-size: .8rem;
            font-weight: 600;
        }

        /* Disabled fields still need to be readable */

        .form-control:disabled {
            background-color: #f8f9fa;
            opacity: 1;
            color: #212529;
        }

        /* =========================
           RESPONSIVE
           ========================= */

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

            .account-grid {
                grid-template-columns: 1fr;
            }

            .account-summary {
                align-items: flex-start;
                flex-direction: column;
            }
        }

    </style>


    <div class="customer-shell">

        <!-- =====================================
             TOP HEADER
             ===================================== -->

        <header class="customer-header">

            <div class="customer-header-left">

                <button type="button"
                    id="customerSidebarToggle"
                    class="customer-menu-button"
                    aria-label="Toggle navigation">

                    ☰

                </button>

                <div class="customer-header-brand">
                    Cafe101
                </div>

            </div>


            <div class="customer-header-right">

                <!-- Logged-in customer -->

                <a href="MyAccount.aspx"
                    class="customer-header-user">

                    <div class="customer-header-avatar">

                        <asp:Label
                            ID="lblTopCustomerInitials"
                            runat="server"
                            Text="C">
                        </asp:Label>

                    </div>

                    <div>

                        <strong>

                            <asp:Label
                                ID="lblTopCustomerName"
                                runat="server"
                                Text="Customer">
                            </asp:Label>

                        </strong>

                        <small>
                            Customer
                        </small>

                    </div>

                </a>


                <!-- Cart -->

                <a href="CartandPayment.aspx"
                    class="customer-cart"
                    title="Cart">

                    &#128722;

                    <span class="position-absolute
                                 top-0
                                 start-100
                                 translate-middle
                                 badge
                                 rounded-pill
                                 bg-danger"
                          style="font-size:.6rem;">

                        2

                    </span>

                </a>

            </div>

        </header>


        <div class="customer-body">

            <!-- =====================================
                 SIDEBAR
                 ===================================== -->

            <aside class="customer-sidebar">

                <div class="customer-sidebar-title">
                    CUSTOMER SYSTEM
                </div>


                <nav class="customer-nav">

                    <a href="CustomerDashboard.aspx">

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


                    <a href="MyAccount.aspx"
                        class="active">

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
                        OnClick="LnkLogOut_Click">

                        <span class="customer-nav-icon">
                            &#10140;
                        </span>

                        <span class="customer-nav-text">
                            Logout
                        </span>

                    </asp:LinkButton>

                </div>

            </aside>


            <!-- =====================================
                 MAIN CONTENT
                 ===================================== -->

            <main class="customer-main">

                <div class="account-content">

                    <div class="account-heading">

                        <h3 class="fw-bold mb-1">
                            My Account
                        </h3>

                        <p class="text-muted mb-0">
                            View and manage your Cafe101 account information.
                        </p>

                    </div>


                    <!-- =====================================
                         PROFILE SUMMARY
                         ===================================== -->

                    <section class="account-summary">

                        <div class="account-summary-left">

                            <div class="account-avatar">

                                <asp:Literal
                                    ID="litInitials"
                                    runat="server"
                                    Text="C" />

                            </div>


                            <div>

                                <h4>

                                    <asp:Literal
                                        ID="litFullName"
                                        runat="server" />

                                </h4>

                                <p>

                                    <asp:Literal
                                        ID="litEmailDisplay"
                                        runat="server" />

                                </p>

                            </div>

                        </div>


                        <asp:Button
                            ID="btnEdit"
                            runat="server"
                            Text="Edit Profile"
                            CssClass="btn btn-outline-brand"
                            OnClick="BtnEdit_Click" />

                    </section>


                    <!-- =====================================
                         GRID
                         ===================================== -->

                    <div class="account-grid">

                        <!-- =================================
                             PERSONAL INFORMATION
                             ================================= -->

                        <section class="account-card">

                            <h5 class="account-card-title">
                                Personal Information
                            </h5>


                            <div class="row g-3">

                                <div class="col-md-6">

                                    <label class="account-label">
                                        First Name
                                    </label>

                                    <asp:TextBox
                                        ID="txtFirstName"
                                        runat="server"
                                        CssClass="form-control" />

                                </div>


                                <div class="col-md-6">

                                    <label class="account-label">
                                        Last Name
                                    </label>

                                    <asp:TextBox
                                        ID="txtLastName"
                                        runat="server"
                                        CssClass="form-control" />

                                </div>


                                <div class="col-md-6">

                                    <label class="account-label">
                                        Phone Number
                                    </label>

                                    <asp:TextBox
                                        ID="txtPhone"
                                        runat="server"
                                        CssClass="form-control"
                                        TextMode="Phone" />

                                </div>


                                <div class="col-md-6">

                                    <label class="account-label">
                                        Email Address
                                    </label>

                                    <asp:TextBox
                                        ID="txtEmail"
                                        runat="server"
                                        CssClass="form-control"
                                        TextMode="Email" />

                                </div>

                            </div>


                            <h5 class="account-card-title mt-4">
                                Address
                            </h5>


                            <div class="row g-3">

                                <div class="col-12">

                                    <label class="account-label">
                                        Street Address
                                    </label>

                                    <asp:TextBox
                                        ID="txtStreetAddress"
                                        runat="server"
                                        CssClass="form-control" />

                                </div>


                                <div class="col-md-6">

                                    <label class="account-label">
                                        Suburb
                                    </label>

                                    <asp:TextBox
                                        ID="txtSuburb"
                                        runat="server"
                                        CssClass="form-control" />

                                </div>


                                <div class="col-md-6">

                                    <label class="account-label">
                                        City
                                    </label>

                                    <asp:TextBox
                                        ID="txtCity"
                                        runat="server"
                                        CssClass="form-control" />

                                </div>

                            </div>


                            <!-- Save / Cancel -->

                            <div class="d-flex gap-2 mt-4">

                                <asp:Button
                                    ID="btnSave"
                                    runat="server"
                                    Text="Save Changes"
                                    CssClass="btn btn-brand"
                                    OnClick="BtnSave_Click"
                                    Visible="false" />


                                <asp:Button
                                    ID="btnCancel"
                                    runat="server"
                                    Text="Cancel"
                                    CssClass="btn btn-outline-secondary"
                                    OnClick="BtnCancel_Click"
                                    Visible="false"
                                    CausesValidation="false" />

                            </div>


                            <asp:Label
                                ID="lblStatus"
                                runat="server"
                                CssClass="d-block mt-3 small" />

                        </section>


                        <!-- =================================
                             RIGHT COLUMN
                             ================================= -->

                        <div>

                            <!-- ACCOUNT INFORMATION -->

                            <section class="account-card mb-3">

                                <h5 class="account-card-title">
                                    Account Information
                                </h5>


                                <div class="account-readonly-row">

                                    <span class="text-muted">
                                        Customer ID
                                    </span>

                                    <strong>

                                        <asp:Literal
                                            ID="litCustomerID"
                                            runat="server" />

                                    </strong>

                                </div>


                                <div class="account-readonly-row">

                                    <span class="text-muted">
                                        Account Type
                                    </span>

                                    <strong>
                                        Customer
                                    </strong>

                                </div>


                                <div class="account-readonly-row">

                                    <span class="text-muted">
                                        Status
                                    </span>

                                    <span class="account-status">

                                        <asp:Literal
                                            ID="litAccountStatus"
                                            runat="server" />

                                    </span>

                                </div>

                            </section>


                            <!-- ACCOUNT SECURITY -->

                            <section class="account-card">

                                <h5 class="account-card-title">
                                    Account Security
                                </h5>

                                <p class="text-muted small mb-3">
                                    Your password is securely stored and is
                                    never displayed on this page.
                                </p>

                                <button
                                    type="button"
                                    class="btn btn-outline-brand w-100">

                                    Change Password

                                </button>

                            </section>

                        </div>

                    </div>

                </div>

            </main>

        </div>

    </div>


    <script>

        document.body.classList.add("customer-page");


        // ==========================================
        // REMOVE NORMAL MASTER PAGE SPACING
        // ==========================================

        const bodyContent =
            document.querySelector(".body-content");

        if (bodyContent) {

            bodyContent.classList.remove("container");

            bodyContent.style.width = "100%";
            bodyContent.style.maxWidth = "none";
            bodyContent.style.margin = "0";
            bodyContent.style.padding = "0";

        }


        // ==========================================
        // HIDE PUBLIC NAVBAR
        // ==========================================

        const publicNavbar =
            document.querySelector(".navbar");

        if (publicNavbar) {
            publicNavbar.style.display = "none";
        }


        // ==========================================
        // HIDE MASTER PAGE FOOTER
        // ==========================================

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


        // ==========================================
        // SIDEBAR COLLAPSE
        // ==========================================

        const toggle =
            document.getElementById(
                "customerSidebarToggle"
            );


        const sidebar =
            document.querySelector(
                ".customer-sidebar"
            );


        if (toggle && sidebar) {

            toggle.addEventListener(
                "click",
                function () {

                    const isCollapsed =
                        sidebar.classList.contains(
                            "collapsed"
                        );


                    if (isCollapsed) {

                        sidebar.classList.remove(
                            "collapsed"
                        );

                        sidebar.style.width =
                            "230px";


                        document
                            .querySelectorAll(
                                ".customer-nav-text"
                            )
                            .forEach(
                                function (item) {

                                    item.style.display =
                                        "";

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

                        sidebar.classList.add(
                            "collapsed"
                        );

                        sidebar.style.width =
                            "78px";


                        document
                            .querySelectorAll(
                                ".customer-nav-text"
                            )
                            .forEach(
                                function (item) {

                                    item.style.display =
                                        "none";

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