<%@ Page Title="Manager Menu"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ManagerMenu.aspx.cs"
    Inherits="Cafe101.Web.ManagerMenu" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


    <div class="staff-shell manager-shell">


        <%-- ============================================
             TOP HEADER
             ============================================ --%>

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


            <%-- ============================================
                 SIDEBAR
                 ============================================ --%>

            <aside class="staff-sidebar">


                <div class="staff-sidebar-title">
                    MANAGER SYSTEM
                </div>


                <nav class="staff-nav">


                    <a href="ManagerDashboard.aspx">

                        <span class="staff-nav-icon">
                            &#8962;
                        </span>

                        <span class="staff-nav-text">
                            Dashboard
                        </span>

                    </a>



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



                    <a href="ManagerMenu.aspx"
                        class="active">

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
                            Logout
                        </span>

                    </asp:LinkButton>


                </div>


            </aside>



            <%-- ============================================
                 MAIN CONTENT
                 ============================================ --%>

            <main class="staff-main">


                <div class="staff-page-heading">

                    <h3>
                        Menu Management
                    </h3>

                    <p>
                        View Cafe101 menu items and monitor
                        their current inventory availability.
                    </p>

                </div>



                <asp:Label
                    ID="lblMessage"
                    runat="server"
                    CssClass="d-none">
                </asp:Label>



                <%-- ============================================
                     TOOLBAR
                     ============================================ --%>

                <div class="manager-menu-toolbar">


                    <div class="manager-menu-toolbar-left">


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


                            <asp:TextBox
                                ID="txtSearch"
                                runat="server"
                                CssClass="form-control"
                                placeholder="Search by item name or category...">
                            </asp:TextBox>


                        </div>



                        <asp:DropDownList
                            ID="ddlCategory"
                            runat="server"
                            CssClass="form-control manager-menu-filter"
                            AutoPostBack="true"
                            OnSelectedIndexChanged="DdlCategory_SelectedIndexChanged">
                        </asp:DropDownList>



                        <asp:DropDownList
                            ID="ddlStatus"
                            runat="server"
                            CssClass="form-control manager-menu-filter"
                            AutoPostBack="true"
                            OnSelectedIndexChanged="DdlStatus_SelectedIndexChanged">

                            <asp:ListItem
                                Text="All Statuses"
                                Value="">
                            </asp:ListItem>

                            <asp:ListItem
                                Text="Available"
                                Value="Available">
                            </asp:ListItem>

                            <asp:ListItem
                                Text="Low Stock"
                                Value="Low Stock">
                            </asp:ListItem>

                            <asp:ListItem
                                Text="Unavailable"
                                Value="Unavailable">
                            </asp:ListItem>

                        </asp:DropDownList>


                    </div>



                    <div class="manager-menu-toolbar-right">


                        <asp:Button
                            ID="btnSearch"
                            runat="server"
                            Text="Search"
                            CssClass="btn btn-brand"
                            OnClick="BtnSearch_Click" />


                        <asp:Button
                            ID="btnRefresh"
                            runat="server"
                            Text="↻ Refresh"
                            CssClass="btn btn-outline-brand"
                            OnClick="BtnRefresh_Click" />


                    </div>


                </div>



                <%-- ============================================
                     SUMMARY
                     ============================================ --%>

                <div class="staff-metric-grid">


                    <div class="staff-metric-card">


                        <div class="staff-icon-box icon-green">

                            <span>
                                ▤
                            </span>

                        </div>


                        <div>

                            <span class="staff-metric-label">
                                TOTAL ITEMS
                            </span>

                            <h3>

                                <asp:Label
                                    ID="lblTotalItems"
                                    runat="server">
                                </asp:Label>

                            </h3>

                            <p>
                                Menu items in database
                            </p>

                        </div>


                    </div>



                    <div class="staff-metric-card">


                        <div class="staff-icon-box icon-blue">

                            ✓

                        </div>


                        <div>

                            <span class="staff-metric-label">
                                AVAILABLE
                            </span>

                            <h3>

                                <asp:Label
                                    ID="lblAvailable"
                                    runat="server">
                                </asp:Label>

                            </h3>

                            <p>
                                Sufficient ingredient stock
                            </p>

                        </div>


                    </div>



                    <div class="staff-metric-card">


                        <div class="staff-icon-box icon-orange">

                            !

                        </div>


                        <div>

                            <span class="staff-metric-label">
                                UNAVAILABLE
                            </span>

                            <h3>

                                <asp:Label
                                    ID="lblUnavailable"
                                    runat="server">
                                </asp:Label>

                            </h3>

                            <p>
                                Cannot currently be prepared
                            </p>

                        </div>


                    </div>



                    <div class="staff-metric-card">


                        <div class="staff-icon-box icon-purple">

                            #

                        </div>


                        <div>

                            <span class="staff-metric-label">
                                CATEGORIES
                            </span>

                            <h3>

                                <asp:Label
                                    ID="lblCategoryCount"
                                    runat="server">
                                </asp:Label>

                            </h3>

                            <p>
                                Distinct menu categories
                            </p>

                        </div>


                    </div>


                </div>



                <%-- ============================================
                     MENU WORKSPACE
                     ============================================ --%>

                <div class="manager-menu-workspace">


                    <section class="staff-dashboard-panel manager-menu-table-card">


                        <div class="staff-panel-heading">


                            <div>

                                <h5>
                                    All Menu Items
                                </h5>

                                <small>
                                    Live data from MenuItemsTable
                                </small>

                            </div>


                        </div>



                        <div class="table-responsive">


                            <table class="table staff-orders-table manager-menu-table">


                                <thead>

                                    <tr>

                                        <th>Item</th>
                                        <th>Category</th>
                                        <th>Price</th>
                                        <th>Can Make</th>
                                        <th>Prep Time</th>
                                        <th>Status</th>
                                        <th>Action</th>

                                    </tr>

                                </thead>



                                <tbody>


                                    <asp:Repeater
                                        ID="rptMenuItems"
                                        runat="server">


                                        <ItemTemplate>


                                            <tr>


                                                <td>

                                                    <div class="manager-menu-item-name">


                                                        <div class="manager-menu-item-thumb">

                                                            <%#
                                                                GetCategoryEmoji(
                                                                    Eval("Category")
                                                                    .ToString())
                                                            %>

                                                        </div>


                                                        <strong>

                                                            <%#
                                                                Eval(
                                                                    "MenuItemName")
                                                            %>

                                                        </strong>


                                                    </div>

                                                </td>



                                                <td>

                                                    <%#
                                                        Eval(
                                                            "Category")
                                                    %>

                                                </td>



                                                <td>

                                                    R<%#
                                                        Convert.ToDecimal(
                                                            Eval(
                                                                "SellingPrice"))
                                                        .ToString("N2")
                                                    %>

                                                </td>



                                                <td>

                                                    <%#
                                                        Eval(
                                                            "AvailableQuantity")
                                                    %>

                                                </td>



                                                <td>

                                                    <%#
                                                        Eval(
                                                            "PreparationTime")
                                                    %>
                                                    min

                                                </td>



                                                <td>


                                                    <span class='<%#
                                                        GetStatusCssClass(
                                                            Eval(
                                                                "StockStatus")
                                                            .ToString())
                                                    %>'>

                                                        <%#
                                                            Eval(
                                                                "StockStatus")
                                                        %>

                                                    </span>


                                                </td>



                                                <td>


                                                    <asp:LinkButton
                                                        ID="btnSelectItem"
                                                        runat="server"
                                                        CssClass="btn btn-sm btn-outline-brand"
                                                        CommandArgument='<%#
                                                            Eval("MenuItemID")
                                                        %>'
                                                        OnCommand="SelectMenuItem_Command">

                                                        View

                                                    </asp:LinkButton>


                                                </td>


                                            </tr>


                                        </ItemTemplate>


                                    </asp:Repeater>


                                </tbody>


                            </table>


                        </div>



                        <div class="manager-orders-pagination">


                            <small>

                                <asp:Label
                                    ID="lblShowingItems"
                                    runat="server">
                                </asp:Label>

                            </small>


                        </div>


                    </section>



                    <%-- ============================================
                         SELECTED ITEM
                         ============================================ --%>

                    <asp:Panel
                        ID="pnlSelectedItem"
                        runat="server"
                        CssClass="staff-dashboard-panel manager-selected-item">


                        <div class="manager-selected-item-heading">

                            <h5>
                                Selected Item
                            </h5>

                        </div>



                        <div class="manager-selected-product">


                            <div class="manager-selected-product-image">

                                <asp:Label
                                    ID="lblSelectedEmoji"
                                    runat="server">
                                </asp:Label>

                            </div>


                            <div>


                                <h4>

                                    <asp:Label
                                        ID="lblSelectedName"
                                        runat="server">
                                    </asp:Label>

                                </h4>


                                <asp:Label
                                    ID="lblSelectedStatus"
                                    runat="server">
                                </asp:Label>


                            </div>


                        </div>



                        <div class="manager-selected-info">


                            <div class="manager-selected-info-row">

                                <span>
                                    Category
                                </span>

                                <strong>

                                    <asp:Label
                                        ID="lblSelectedCategory"
                                        runat="server">
                                    </asp:Label>

                                </strong>

                            </div>



                            <div class="manager-selected-info-row">

                                <span>
                                    Selling Price
                                </span>

                                <strong>

                                    <asp:Label
                                        ID="lblSelectedPrice"
                                        runat="server">
                                    </asp:Label>

                                </strong>

                            </div>



                            <div class="manager-selected-info-row">

                                <span>
                                    Cost To Make
                                </span>

                                <strong>

                                    <asp:Label
                                        ID="lblSelectedCost"
                                        runat="server">
                                    </asp:Label>

                                </strong>

                            </div>



                            <div class="manager-selected-info-row">

                                <span>
                                    Preparation Time
                                </span>

                                <strong>

                                    <asp:Label
                                        ID="lblSelectedPreparation"
                                        runat="server">
                                    </asp:Label>

                                </strong>

                            </div>



                            <div class="manager-selected-info-row">

                                <span>
                                    Quantity Available
                                </span>

                                <strong>

                                    <asp:Label
                                        ID="lblSelectedQuantity"
                                        runat="server">
                                    </asp:Label>

                                </strong>

                            </div>



                            <div class="manager-selected-info-row">

                                <span>
                                    Total Quantity Sold
                                </span>

                                <strong>

                                    <asp:Label
                                        ID="lblSelectedSold"
                                        runat="server">
                                    </asp:Label>

                                </strong>

                            </div>


                        </div>



                        <div class="manager-selected-actions">


                            <asp:Button
                                ID="btnDeleteSelected"
                                runat="server"
                                Text="Delete Item"
                                CssClass="manager-selected-action manager-selected-action-red"
                                OnClick="BtnDeleteSelected_Click"
                                OnClientClick="return confirm('Are you sure you want to delete this menu item?');" />


                        </div>


                    </asp:Panel>


                </div>



                <%-- ============================================
                     LOW STOCK + CATEGORY SUMMARY
                     ============================================ --%>

                <div class="manager-menu-bottom-grid">


                    <section class="staff-dashboard-panel">


                        <div class="staff-panel-heading">

                            <div>

                                <h5>
                                    Low Stock Items
                                </h5>

                                <small>
                                    Menu items affected by ingredients
                                    at or below their restock level.
                                </small>

                            </div>

                        </div>



                        <div class="manager-low-stock-grid">


                            <asp:Repeater
                                ID="rptLowStock"
                                runat="server">


                                <ItemTemplate>


                                    <div class="manager-low-stock-card">


                                        <span class="manager-low-stock-icon">

                                            <%#
                                                GetCategoryEmoji(
                                                    Eval(
                                                        "Category")
                                                    .ToString())
                                            %>

                                        </span>


                                        <div>

                                            <strong>

                                                <%#
                                                    Eval(
                                                        "MenuItemName")
                                                %>

                                            </strong>


                                            <small>

                                                <%#
                                                    Eval(
                                                        "AvailableQuantity")
                                                %>
                                                can currently be made

                                            </small>

                                        </div>


                                        <span class="manager-menu-status status-low-stock">
                                            Low Stock
                                        </span>


                                    </div>


                                </ItemTemplate>


                            </asp:Repeater>


                        </div>


                    </section>



                    <section class="staff-dashboard-panel">


                        <div class="staff-panel-heading">

                            <div>

                                <h5>
                                    Category Summary
                                </h5>

                                <small>
                                    Live item totals by category
                                </small>

                            </div>

                        </div>



                        <div class="manager-category-summary">


                            <asp:Repeater
                                ID="rptCategories"
                                runat="server">


                                <ItemTemplate>


                                    <div class="manager-category-row">


                                        <span>

                                            ●

                                            <%#
                                                Eval(
                                                    "Category")
                                            %>

                                        </span>


                                        <strong>

                                            <%#
                                                Eval(
                                                    "ItemCount")
                                            %>
                                            items

                                        </strong>


                                    </div>


                                </ItemTemplate>


                            </asp:Repeater>


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

        document.body.classList.add(
            "staff-page");


        const publicNavbar =
            document.querySelector(
                ".navbar");


        if (publicNavbar) {
            publicNavbar.style.display =
                "none";
        }



        const bodyContent =
            document.querySelector(
                ".body-content");


        if (bodyContent) {

            bodyContent.classList.remove(
                "container");

            bodyContent.style.width =
                "100%";

            bodyContent.style.maxWidth =
                "none";

            bodyContent.style.margin =
                "0";

            bodyContent.style.padding =
                "0";

        }



        const masterFooter =
            document.querySelector(
                ".body-content > footer");


        if (masterFooter) {
            masterFooter.style.display =
                "none";
        }



        const masterFooterLine =
            document.querySelector(
                ".body-content > hr");


        if (masterFooterLine) {
            masterFooterLine.style.display =
                "none";
        }



        const sidebarToggle =
            document.getElementById(
                "sidebarToggle");


        const staffBody =
            document.querySelector(
                ".staff-body");


        if (sidebarToggle &&
            staffBody) {

            sidebarToggle
                .addEventListener(
                    "click",
                    function () {

                        staffBody
                            .classList
                            .toggle(
                                "sidebar-collapsed");

                    });

        }

    </script>


</asp:Content>