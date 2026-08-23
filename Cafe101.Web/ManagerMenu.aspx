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


                    <%-- Menu active --%>
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


                    <a href="#">

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
                 MAIN MENU AREA
                 ================================================= --%>

            <main class="staff-main">


                <%-- =================================================
                     PAGE HEADING
                     ================================================= --%>

                <div class="staff-page-heading">

                    <h3>
                        Menu Management
                    </h3>

                    <p>
                        Manage menu items, categories and availability.
                    </p>

                </div>


                <%-- =================================================
                     MENU TOOLBAR
                     ================================================= --%>

                <div class="manager-menu-toolbar">


                    <div class="manager-menu-toolbar-left">


                        <%-- Search --%>
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
                                placeholder="Search by item name or category..." />

                        </div>


                        <%-- Category filter --%>
                        <select class="form-control manager-menu-filter">

                            <option>
                                All Categories
                            </option>

                            <option>
                                Beverages
                            </option>

                            <option>
                                Food
                            </option>

                            <option>
                                Bakery
                            </option>

                            <option>
                                Sides
                            </option>

                            <option>
                                Combos
                            </option>

                        </select>


                        <%-- Status filter --%>
                        <select class="form-control manager-menu-filter">

                            <option>
                                All Statuses
                            </option>

                            <option>
                                Available
                            </option>

                            <option>
                                Low Stock
                            </option>

                            <option>
                                Unavailable
                            </option>

                        </select>

                    </div>


                    <div class="manager-menu-toolbar-right">

                        <button type="button"
                            class="btn btn-brand">

                            + Add New Item

                        </button>


                        <button type="button"
                            class="btn btn-outline-brand">

                            ↻ Refresh

                        </button>

                    </div>


                </div>


                <%-- =================================================
                     MENU SUMMARY CARDS
                     ================================================= --%>

                <div class="staff-metric-grid">


                    <%-- Total items --%>
                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-green">

                            <svg viewBox="0 0 24 24"
                                width="23"
                                height="23"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <path d="M5 7h14v12H5z" />
                                <path d="M8 4h8v3H8z" />

                            </svg>

                        </div>


                        <div>

                            <span class="staff-metric-label">
                                TOTAL ITEMS
                            </span>

                            <h3>
                                32
                            </h3>

                            <p>
                                All menu items
                            </p>

                        </div>

                    </div>


                    <%-- Available --%>
                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-blue">

                            <svg viewBox="0 0 24 24"
                                width="23"
                                height="23"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <circle cx="12"
                                    cy="12"
                                    r="9" />

                                <path d="M8 12l3 3 5-6" />

                            </svg>

                        </div>


                        <div>

                            <span class="staff-metric-label">
                                AVAILABLE
                            </span>

                            <h3>
                                24
                            </h3>

                            <p>
                                Items available
                            </p>

                        </div>

                    </div>


                    <%-- Out of stock --%>
                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-orange">

                            <svg viewBox="0 0 24 24"
                                width="23"
                                height="23"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <path d="M12 3L2 21h20L12 3z" />
                                <path d="M12 9v5" />
                                <path d="M12 18h.01" />

                            </svg>

                        </div>


                        <div>

                            <span class="staff-metric-label">
                                OUT OF STOCK
                            </span>

                            <h3>
                                3
                            </h3>

                            <p>
                                Currently unavailable
                            </p>

                        </div>

                    </div>


                    <%-- Categories --%>
                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-purple">

                            <svg viewBox="0 0 24 24"
                                width="23"
                                height="23"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <path d="M4 5h7l9 9-6 6-9-9V5z" />
                                <circle cx="8"
                                    cy="8"
                                    r="1" />

                            </svg>

                        </div>


                        <div>

                            <span class="staff-metric-label">
                                CATEGORIES
                            </span>

                            <h3>
                                8
                            </h3>

                            <p>
                                Menu categories
                            </p>

                        </div>

                    </div>


                </div>


                <%-- =================================================
                     MENU TABLE + SELECTED ITEM
                     ================================================= --%>

                <div class="manager-menu-workspace">


                    <%-- =================================================
                         ALL MENU ITEMS
                         ================================================= --%>

                    <section class="staff-dashboard-panel manager-menu-table-card">


                        <div class="staff-panel-heading">

                            <div>

                                <h5>
                                    All Menu Items
                                </h5>

                                <small>
                                    Manage and monitor all menu items
                                </small>

                            </div>

                        </div>


                        <div class="table-responsive">


                            <table class="table staff-orders-table manager-menu-table">

                                <thead>

                                    <tr>

                                        <th>
                                            Item
                                        </th>

                                        <th>
                                            Category
                                        </th>

                                        <th>
                                            Price
                                        </th>

                                        <th>
                                            Stock
                                        </th>

                                        <th>
                                            Status
                                        </th>

                                        <th>
                                            Action
                                        </th>

                                    </tr>

                                </thead>


                                <tbody>


                                    <tr>

                                        <td>

                                            <div class="manager-menu-item-name">

                                                <div class="manager-menu-item-thumb">
                                                    ☕
                                                </div>

                                                <strong>
                                                    Cappuccino
                                                </strong>

                                            </div>

                                        </td>

                                        <td>
                                            Beverages
                                        </td>

                                        <td>
                                            R42.00
                                        </td>

                                        <td>
                                            32
                                        </td>

                                        <td>

                                            <span class="manager-menu-status status-available">
                                                Available
                                            </span>

                                        </td>

                                        <td>

                                            <div class="manager-menu-actions">

                                                <button type="button">
                                                    ✎
                                                </button>

                                                <button type="button">
                                                    ›
                                                </button>

                                            </div>

                                        </td>

                                    </tr>



                                    <tr>

                                        <td>

                                            <div class="manager-menu-item-name">

                                                <div class="manager-menu-item-thumb">
                                                    🌯
                                                </div>

                                                <strong>
                                                    Chicken Wrap
                                                </strong>

                                            </div>

                                        </td>

                                        <td>
                                            Food
                                        </td>

                                        <td>
                                            R68.00
                                        </td>

                                        <td>
                                            21
                                        </td>

                                        <td>

                                            <span class="manager-menu-status status-available">
                                                Available
                                            </span>

                                        </td>

                                        <td>

                                            <div class="manager-menu-actions">

                                                <button type="button">
                                                    ✎
                                                </button>

                                                <button type="button">
                                                    ›
                                                </button>

                                            </div>

                                        </td>

                                    </tr>



                                    <tr>

                                        <td>

                                            <div class="manager-menu-item-name">

                                                <div class="manager-menu-item-thumb">
                                                    🧁
                                                </div>

                                                <strong>
                                                    Vanilla Muffin
                                                </strong>

                                            </div>

                                        </td>

                                        <td>
                                            Bakery
                                        </td>

                                        <td>
                                            R35.00
                                        </td>

                                        <td>
                                            14
                                        </td>

                                        <td>

                                            <span class="manager-menu-status status-low-stock">
                                                Low Stock
                                            </span>

                                        </td>

                                        <td>

                                            <div class="manager-menu-actions">

                                                <button type="button">
                                                    ✎
                                                </button>

                                                <button type="button">
                                                    ›
                                                </button>

                                            </div>

                                        </td>

                                    </tr>



                                    <tr>

                                        <td>

                                            <div class="manager-menu-item-name">

                                                <div class="manager-menu-item-thumb">
                                                    🥤
                                                </div>

                                                <strong>
                                                    Iced Latte
                                                </strong>

                                            </div>

                                        </td>

                                        <td>
                                            Beverages
                                        </td>

                                        <td>
                                            R48.00
                                        </td>

                                        <td>
                                            6
                                        </td>

                                        <td>

                                            <span class="manager-menu-status status-low-stock">
                                                Low Stock
                                            </span>

                                        </td>

                                        <td>

                                            <div class="manager-menu-actions">

                                                <button type="button">
                                                    ✎
                                                </button>

                                                <button type="button">
                                                    ›
                                                </button>

                                            </div>

                                        </td>

                                    </tr>



                                    <tr>

                                        <td>

                                            <div class="manager-menu-item-name">

                                                <div class="manager-menu-item-thumb">
                                                    🍔
                                                </div>

                                                <strong>
                                                    Classic Burger
                                                </strong>

                                            </div>

                                        </td>

                                        <td>
                                            Food
                                        </td>

                                        <td>
                                            R72.00
                                        </td>

                                        <td>
                                            15
                                        </td>

                                        <td>

                                            <span class="manager-menu-status status-available">
                                                Available
                                            </span>

                                        </td>

                                        <td>

                                            <div class="manager-menu-actions">

                                                <button type="button">
                                                    ✎
                                                </button>

                                                <button type="button">
                                                    ›
                                                </button>

                                            </div>

                                        </td>

                                    </tr>



                                    <tr>

                                        <td>

                                            <div class="manager-menu-item-name">

                                                <div class="manager-menu-item-thumb">
                                                    🍞
                                                </div>

                                                <strong>
                                                    Brownie
                                                </strong>

                                            </div>

                                        </td>

                                        <td>
                                            Bakery
                                        </td>

                                        <td>
                                            R28.00
                                        </td>

                                        <td>
                                            0
                                        </td>

                                        <td>

                                            <span class="manager-menu-status status-unavailable">
                                                Unavailable
                                            </span>

                                        </td>

                                        <td>

                                            <div class="manager-menu-actions">

                                                <button type="button">
                                                    ✎
                                                </button>

                                                <button type="button">
                                                    ›
                                                </button>

                                            </div>

                                        </td>

                                    </tr>



                                    <tr>

                                        <td>

                                            <div class="manager-menu-item-name">

                                                <div class="manager-menu-item-thumb">
                                                    🍟
                                                </div>

                                                <strong>
                                                    Fries
                                                </strong>

                                            </div>

                                        </td>

                                        <td>
                                            Sides
                                        </td>

                                        <td>
                                            R32.00
                                        </td>

                                        <td>
                                            6
                                        </td>

                                        <td>

                                            <span class="manager-menu-status status-low-stock">
                                                Low Stock
                                            </span>

                                        </td>

                                        <td>

                                            <div class="manager-menu-actions">

                                                <button type="button">
                                                    ✎
                                                </button>

                                                <button type="button">
                                                    ›
                                                </button>

                                            </div>

                                        </td>

                                    </tr>



                                    <tr>

                                        <td>

                                            <div class="manager-menu-item-name">

                                                <div class="manager-menu-item-thumb">
                                                    🥪
                                                </div>

                                                <strong>
                                                    Breakfast Toastie
                                                </strong>

                                            </div>

                                        </td>

                                        <td>
                                            Food
                                        </td>

                                        <td>
                                            R45.00
                                        </td>

                                        <td>
                                            9
                                        </td>

                                        <td>

                                            <span class="manager-menu-status status-available">
                                                Available
                                            </span>

                                        </td>

                                        <td>

                                            <div class="manager-menu-actions">

                                                <button type="button">
                                                    ✎
                                                </button>

                                                <button type="button">
                                                    ›
                                                </button>

                                            </div>

                                        </td>

                                    </tr>


                                </tbody>

                            </table>


                        </div>


                        <%-- Pagination --%>
                        <div class="manager-orders-pagination">

                            <div>

                                <button type="button">
                                    ‹
                                </button>

                                <button type="button"
                                    class="active">
                                    1
                                </button>

                                <button type="button">
                                    2
                                </button>

                                <button type="button">
                                    3
                                </button>

                                <button type="button">
                                    4
                                </button>

                                <button type="button">
                                    ›
                                </button>

                            </div>


                            <small>
                                Showing 1-8 of 32 items
                            </small>

                        </div>


                    </section>


                    <%-- =================================================
                         SELECTED ITEM
                         ================================================= --%>

                    <aside class="staff-dashboard-panel manager-selected-item">


                        <div class="manager-selected-item-heading">

                            <h5>
                                Selected Item
                            </h5>

                        </div>


                        <%-- Product image placeholder --%>
                        <div class="manager-selected-product">

                            <div class="manager-selected-product-image">
                                ☕
                            </div>


                            <div>

                                <h4>
                                    Cappuccino
                                </h4>

                                <span class="manager-menu-status status-available">
                                    Available
                                </span>

                            </div>

                        </div>


                        <%-- Item information --%>
                        <div class="manager-selected-info">


                            <div class="manager-selected-info-row">

                                <span>
                                    Category
                                </span>

                                <strong>
                                    Beverages
                                </strong>

                            </div>


                            <div class="manager-selected-info-row">

                                <span>
                                    Price
                                </span>

                                <strong>
                                    R42.00
                                </strong>

                            </div>


                            <div class="manager-selected-info-row">

                                <span>
                                    Stock Quantity
                                </span>

                                <strong>
                                    32
                                </strong>

                            </div>


                            <div class="manager-selected-info-row">

                                <span>
                                    Status
                                </span>

                                <span class="manager-menu-status status-available">
                                    Available
                                </span>

                            </div>


                        </div>


                        <%-- Description --%>
                        <div class="manager-selected-description">

                            <small class="staff-detail-label">
                                DESCRIPTION
                            </small>

                            <p>
                                A rich espresso with steamed milk and a smooth layer of foam.
                            </p>

                        </div>


                        <%-- Item actions --%>
                        <div class="manager-selected-actions">


                            <button type="button"
                                class="btn btn-brand">

                                ✎ Edit Item

                            </button>


                            <button type="button"
                                class="manager-selected-action manager-selected-action-beige">

                                Mark Unavailable

                            </button>


                            <button type="button"
                                class="manager-selected-action manager-selected-action-red">

                                Delete Item

                            </button>


                            <button type="button"
                                class="manager-selected-action">

                                View Category

                            </button>


                        </div>


                    </aside>


                </div>


                <%-- =================================================
                     LOW STOCK + CATEGORY SUMMARY
                     ================================================= --%>

                <div class="manager-menu-bottom-grid">


                    <%-- LOW STOCK --%>
                    <section class="staff-dashboard-panel">


                        <div class="staff-panel-heading">

                            <div>

                                <h5>
                                    Low Stock Items
                                </h5>

                                <small>
                                    Items that need restocking soon
                                </small>

                            </div>


                            <a href="#"
                                class="staff-text-link">

                                View All →

                            </a>

                        </div>


                        <div class="manager-low-stock-grid">


                            <div class="manager-low-stock-card">

                                <span class="manager-low-stock-icon">
                                    🥤
                                </span>

                                <div>

                                    <strong>
                                        Iced Latte
                                    </strong>

                                    <small>
                                        6 in stock
                                    </small>

                                </div>

                                <span class="manager-menu-status status-low-stock">
                                    Low Stock
                                </span>

                            </div>


                            <div class="manager-low-stock-card">

                                <span class="manager-low-stock-icon">
                                    🍟
                                </span>

                                <div>

                                    <strong>
                                        Fries
                                    </strong>

                                    <small>
                                        6 in stock
                                    </small>

                                </div>

                                <span class="manager-menu-status status-low-stock">
                                    Low Stock
                                </span>

                            </div>


                            <div class="manager-low-stock-card">

                                <span class="manager-low-stock-icon">
                                    🧁
                                </span>

                                <div>

                                    <strong>
                                        Vanilla Muffin
                                    </strong>

                                    <small>
                                        14 in stock
                                    </small>

                                </div>

                                <span class="manager-menu-status status-low-stock">
                                    Low Stock
                                </span>

                            </div>


                            <div class="manager-low-stock-card">

                                <span class="manager-low-stock-icon">
                                    🥪
                                </span>

                                <div>

                                    <strong>
                                        Breakfast Toastie
                                    </strong>

                                    <small>
                                        9 in stock
                                    </small>

                                </div>

                                <span class="manager-menu-status status-low-stock">
                                    Low Stock
                                </span>

                            </div>


                        </div>


                    </section>


                    <%-- CATEGORY SUMMARY --%>
                    <section class="staff-dashboard-panel">


                        <div class="staff-panel-heading">

                            <div>

                                <h5>
                                    Category Summary
                                </h5>

                                <small>
                                    Overview of items by category
                                </small>

                            </div>

                        </div>


                        <div class="manager-category-summary">


                            <div class="manager-category-row">

                                <span>
                                    <i class="manager-category-dot dot-blue"></i>
                                    Beverages
                                </span>

                                <strong>
                                    10 items
                                </strong>

                            </div>


                            <div class="manager-category-row">

                                <span>
                                    <i class="manager-category-dot dot-orange"></i>
                                    Food
                                </span>

                                <strong>
                                    9 items
                                </strong>

                            </div>


                            <div class="manager-category-row">

                                <span>
                                    <i class="manager-category-dot dot-purple"></i>
                                    Bakery
                                </span>

                                <strong>
                                    6 items
                                </strong>

                            </div>


                            <div class="manager-category-row">

                                <span>
                                    <i class="manager-category-dot dot-green"></i>
                                    Sides
                                </span>

                                <strong>
                                    4 items
                                </strong>

                            </div>


                            <div class="manager-category-row">

                                <span>
                                    <i class="manager-category-dot dot-beige"></i>
                                    Combos
                                </span>

                                <strong>
                                    3 items
                                </strong>

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


    <%-- =================================================
         MANAGER PAGE JAVASCRIPT
         ================================================= --%>

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