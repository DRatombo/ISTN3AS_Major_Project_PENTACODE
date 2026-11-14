<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagerReports.aspx.cs" Inherits="Cafe101.Web.ManagerReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="staff-shell">

        <!-- TOP HEADER -->
        <header class="staff-header">
            <div class="staff-header-left">
                <button type="button" id="sidebarToggle" class="staff-header-menu">☰</button>
                <div class="staff-header-brand">Cafe101</div>
            </div>

            <a href="ManagerProfile.aspx" class="staff-header-user text-decoration-none">
                <div class="staff-header-avatar">
                    <asp:Label ID="lblTopManagerInitials" runat="server"></asp:Label>
                </div>
                <div>
                    <strong><asp:Label ID="lblTopManagerName" runat="server"></asp:Label></strong>
                    <small><asp:Label ID="lblTopManagerRole" runat="server"></asp:Label></small>
                </div>
            </a>
        </header>

        <div class="staff-body">

            <!-- SIDEBAR -->
            <aside class="staff-sidebar">
                <div class="staff-sidebar-title">MANAGER SYSTEM</div>

<nav class="staff-nav" aria-label="Manager navigation">
    <a href="ManagerDashboard.aspx" aria-label="Dashboard">
        <span class="staff-nav-icon" aria-hidden="true"><svg viewBox="0 0 24 24" width="19" height="19" fill="none" stroke="currentColor" stroke-width="2"><path d="M3 10l9-7 9 7M5 9v12h14V9M9 21v-8h6v8" /></svg></span>
        <span class="staff-nav-text">Dashboard</span>
    </a>
    <a href="ManagerOrders.aspx" aria-label="Orders">
        <span class="staff-nav-icon" aria-hidden="true"><svg viewBox="0 0 24 24" width="19" height="19" fill="none" stroke="currentColor" stroke-width="2"><path d="M6 3h12v18H6zM9 8h6M9 12h6M9 16h4" /></svg></span>
        <span class="staff-nav-text">Orders</span>
    </a>
    <a href="ManageCustomers.aspx" aria-label="Customers">
        <span class="staff-nav-icon" aria-hidden="true"><svg viewBox="0 0 24 24" width="19" height="19" fill="none" stroke="currentColor" stroke-width="2"><path d="M17 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2"></path><circle cx="9" cy="7" r="4"></circle><path d="M23 21v-2a4 4 0 0 0-3-3.87"></path><path d="M16 3.13a4 4 0 0 1 0 7.75"></path></svg></span>
        <span class="staff-nav-text">Customers</span>
    </a>
    <a href="ManagerMenu.aspx" aria-label="Menu">
        <span class="staff-nav-icon" aria-hidden="true"><svg viewBox="0 0 24 24" width="19" height="19" fill="none" stroke="currentColor" stroke-width="2"><path d="M4 4h16v16H4zM8 8h8M8 12h8M8 16h5" /></svg></span>
        <span class="staff-nav-text">Menu</span>
    </a>
    <a href="ManageIngredients.aspx" aria-label="Ingredients">
        <span class="staff-nav-icon" aria-hidden="true"><svg viewBox="0 0 24 24" width="19" height="19" fill="none" stroke="currentColor" stroke-width="2"><path d="M4 7h16v14H4zM3 3h18v4H3zM9 11h6" /></svg></span>
        <span class="staff-nav-text">Ingredients</span>
    </a>
    <a href="ManageRecipes.aspx" aria-label="Recipes">
        <span class="staff-nav-icon" aria-hidden="true"><svg viewBox="0 0 24 24" width="19" height="19" fill="none" stroke="currentColor" stroke-width="2"><path d="M5 3h14v18H5zM8 7h8M8 11h8M8 15h5" /></svg></span>
        <span class="staff-nav-text">Recipes</span>
    </a>
    <a href="ManagerStaff.aspx" aria-label="Staff">
        <span class="staff-nav-icon" aria-hidden="true"><svg viewBox="0 0 24 24" width="19" height="19" fill="none" stroke="currentColor" stroke-width="2"><circle cx="9" cy="8" r="3" /><circle cx="17" cy="10" r="2" /><path d="M3 20c0-4 2.5-7 6-7s6 3 6 7M15 15c3 0 5 2 5 5" /></svg></span>
        <span class="staff-nav-text">Staff</span>
    </a>
    <a href="ManagerReports.aspx" class="active" aria-current="page" aria-label="Reports">
        <span class="staff-nav-icon" aria-hidden="true"><svg viewBox="0 0 24 24" width="19" height="19" fill="none" stroke="currentColor" stroke-width="2"><path d="M4 20V10M10 20V4M16 20v-7M22 20H2" /></svg></span>
        <span class="staff-nav-text">Reports</span>
    </a>
    <a href="ManagerProfile.aspx" aria-label="Profile">
        <span class="staff-nav-icon" aria-hidden="true"><svg viewBox="0 0 24 24" width="19" height="19" fill="none" stroke="currentColor" stroke-width="2"><circle cx="12" cy="8" r="4" /><path d="M4 21c0-4 3.5-7 8-7s8 3 8 7" /></svg></span>
        <span class="staff-nav-text">Profile</span>
    </a>
    <a href="StaffHelp.aspx" aria-label="Help Centre">
        <span class="staff-nav-icon" aria-hidden="true"><svg viewBox="0 0 24 24" width="19" height="19" fill="none" stroke="currentColor" stroke-width="2"><circle cx="12" cy="12" r="9" /><path d="M9.5 9a2.5 2.5 0 0 1 5 0c0 2-2.5 2-2.5 4" /><path d="M12 17h.01" /></svg></span>
        <span class="staff-nav-text">Help Centre</span>
    </a>
</nav>

                <div class="staff-sidebar-bottom">
                    <asp:LinkButton ID="lnkLogout" runat="server" CssClass="staff-logout" OnClick="LnkLogout_Click">
                        <span class="staff-nav-icon">→</span>
                        <span class="staff-nav-text">Log Out</span>
                    </asp:LinkButton>
                </div>
            </aside>

            <!-- MAIN CONTENT -->
            <main class="staff-main">

                <div class="staff-page-heading">
                    <h3>Reports</h3>
                    <p>View business performance, sales insights and operational summaries.</p>
                </div>

                <!-- TOOLBAR -->
                <div class="manager-orders-toolbar">
                    <div class="manager-orders-toolbar-left">
                        <div class="manager-date-filter">
                            <asp:DropDownList ID="ddlReportDateRange" runat="server"
                                CssClass="form-control"
                                AutoPostBack="true"
                                OnSelectedIndexChanged="DdlReportDateRange_SelectedIndexChanged">
                                <asp:ListItem Text="All Time" Value="AllTime" Selected="True" />
                                <asp:ListItem Text="Today" Value="Today" />
                                <asp:ListItem Text="Yesterday" Value="Yesterday" />
                                <asp:ListItem Text="Last 7 Days" Value="Last7Days" />
                                <asp:ListItem Text="Last 30 Days" Value="Last30Days" />
                                <asp:ListItem Text="This Month" Value="ThisMonth" />
                                <asp:ListItem Text="Previous Month" Value="PreviousMonth" />
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="manager-orders-toolbar-right">
                        <%-- NEW: server button that builds the PDF and emails it --%>
                        <asp:Button ID="btnExport" runat="server" Text="⇩ Export Report"
                            CssClass="btn btn-outline-brand" OnClick="BtnExport_Click"
                            OnClientClick="this.value = 'Sending report...';" />
                        <button type="button" class="btn btn-brand" onclick="loadCharts()">↻ Refresh</button>
                    </div>
                </div>

                <%-- NEW: shows "Report sent" or the error --%>
                <asp:Label ID="lblExportMessage" runat="server" Visible="false"></asp:Label>

                <!-- METRIC CARDS -->
                <div class="staff-metric-grid">
                    <div class="staff-metric-card">
                        <div class="staff-icon-box icon-green"><span class="manager-money-icon">R</span></div>
                        <div>
                            <span class="staff-metric-label">TOTAL REVENUE</span>
                            <h3><asp:Label ID="lblTotalRevenue" runat="server" /></h3>
                            <p>Completed orders</p>
                        </div>
                    </div>

                    <div class="staff-metric-card">
                        <div class="staff-icon-box icon-blue">📦</div>
                        <div>
                            <span class="staff-metric-label">ORDERS COMPLETED</span>
                            <h3><asp:Label ID="lblCompletedOrders" runat="server" /></h3>
                            <p>Completed orders</p>
                        </div>
                    </div>

                    <div class="staff-metric-card">
                        <div class="staff-icon-box icon-orange">🧾</div>
                        <div>
                            <span class="staff-metric-label">AVERAGE ORDER VALUE</span>
                            <h3><asp:Label ID="lblAverageOrderValue" runat="server" /></h3>
                            <p>Average across completed orders</p>
                        </div>
                    </div>

                    <div class="staff-metric-card">
                        <div class="staff-icon-box icon-purple">📈</div>
                        <div>
                            <span class="staff-metric-label">MONTHLY GROWTH</span>
                            <h3>—</h3>
                            <p>Not yet calculated</p>
                        </div>
                    </div>
                </div>

               <!-- CHARTS -->
<style>
    .panel-head-flex { display: flex; justify-content: space-between; align-items: flex-start; gap: 12px; }
    .panel-head-flex .report-range { width: auto; min-width: 140px; font-size: 0.85rem; }
    .live-tag { font-size: 0.75rem; color: #10b981; font-weight: 600; }
    .list-head { display: flex; justify-content: space-between; font-size: 0.75rem; color: #8a94a6; padding: 12px 0 8px; border-bottom: 1px solid #eef0f3; }
    .pop-row, .stock-row { display: flex; justify-content: space-between; align-items: center; padding: 12px 0; border-bottom: 1px solid #eef0f3; }
    .pop-qty { font-weight: 700; }
    .stock-name { font-weight: 600; }
    .stock-sub { font-size: 0.8rem; color: #8a94a6; }
    .level-badge { padding: 4px 12px; border-radius: 8px; font-size: 0.75rem; }
    .lvl-Critical { background: #fde2e2; color: #9b1c1c; }
    .lvl-High { background: #ffe4d6; color: #9a3412; }
    .lvl-Medium { background: #fdecc8; color: #92400e; }
    .lvl-Low { background: #dbe8fb; color: #1e40af; }
    .report-empty { padding: 20px; color: #666; }

    /* NEW: export message */
    .export-message { display: block; margin: 0 0 16px; padding: 12px 16px; border-radius: 10px; font-size: 0.9rem; }
    .export-ok { background: #ecfdf5; color: #065f46; }
    .export-err { background: #fde2e2; color: #9b1c1c; }
</style>

<div class="manager-reports-top-grid">
    <section class="staff-dashboard-panel">
        <div class="staff-panel-heading panel-head-flex">
            <div>
                <h5>Revenue Overview</h5>
                <small>Sales trend over the selected period</small>
            </div>
            <select class="form-control report-range" data-report="revenue"></select>
        </div>
        <div id="revenueChart" style="min-height: 340px;"></div>
    </section>

    <section class="staff-dashboard-panel">
        <div class="staff-panel-heading panel-head-flex">
            <div>
                <h5>Sales by Category</h5>
                <small>Sales distribution across menu categories</small>
            </div>
            <select class="form-control report-range" data-report="category"></select>
        </div>
        <div id="categoryChart" style="min-height: 340px;"></div>
    </section>
</div>

<div class="manager-reports-top-grid" style="margin-top: 20px;">
    <section class="staff-dashboard-panel">
        <div class="staff-panel-heading panel-head-flex">
            <div>
                <h5>Popular Items</h5>
                <small>Top selling menu items</small>
            </div>
            <select class="form-control report-range" data-report="popular"></select>
        </div>
        <div class="list-head"><span>Item</span><span>Quantity Sold</span></div>
        <div id="popularList"></div>
    </section>

    <section class="staff-dashboard-panel">
        <div class="staff-panel-heading panel-head-flex">
            <div>
                <h5>Low Stock Alerts</h5>
                <small>Items that need restocking</small>
            </div>
            <span class="live-tag">● Live</span>
        </div>
        <div id="lowStockList"></div>
    </section>
</div>

<section class="staff-dashboard-panel" style="margin-top: 20px;">
    <div class="staff-panel-heading panel-head-flex">
        <div>
            <h5>Staff Performance</h5>
            <small>Completed orders handled per staff member</small>
        </div>
        <select class="form-control report-range" data-report="staff"></select>
    </div>
    <div id="staffChart" style="min-height: 340px;"></div>
</section>

                <!-- You can keep your original Top Selling Items + Payment Summary section here -->

                <div class="staff-footer">© 2026 Cafe101 Manager System</div>
            </main>
        </div>
    </div>

<script src="https://cdn.jsdelivr.net/npm/apexcharts"></script>
<script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>

<script>
    let revenueChart = null;
    let categoryChart = null;
    let staffChart = null;

    const RANGES = [
        ["AllTime", "All Time"], ["Today", "Today"], ["Yesterday", "Yesterday"],
        ["Last7Days", "Last 7 Days"], ["Last30Days", "Last 30 Days"],
        ["ThisMonth", "This Month"], ["PreviousMonth", "Previous Month"]
    ];

    const EMOJI = {
        "Burger": "🍔", "Wings": "🍗", "Combo": "🍱", "Drinks": "🥤", "Sides": "🍟"
    };

    function esc(text) {
        return $("<div>").text(text).html();
    }

    function rangeOf(report) {
        return $("select[data-report='" + report + "']").val() || "AllTime";
    }

    function getData(type) {
        return $.getJSON("ReportData.ashx", { type: type, dateRange: rangeOf(type) });
    }

    function showError(selector, xhr) {
        $(selector).html(
            "<pre style='color:red;padding:20px;white-space:pre-wrap;'>Error " +
            xhr.status + "\n" + esc((xhr.responseText || "").substring(0, 600)) + "</pre>");
    }

    $(document).ready(function () {
        // Fill every time dropdown
        $(".report-range").each(function () {
            const select = $(this);
            RANGES.forEach(function (r) {
                select.append($("<option>").val(r[0]).text(r[1]));
            });
        });

        // Each dropdown reloads ONLY its own report
        $(".report-range").on("change", function () {
            const report = $(this).data("report");
            if (report === "revenue") loadRevenue();
            if (report === "category") loadCategory();
            if (report === "popular") loadPopular();
            if (report === "staff") loadStaff();
        });

        loadCharts();
    });

    // The Refresh button calls this
    function loadCharts() {
        loadRevenue();
        loadCategory();
        loadPopular();
        loadLowStock();
        loadStaff();
    }

    function loadRevenue() {
        getData("revenue").done(renderRevenueChart).fail(function (xhr) { showError("#revenueChart", xhr); });
    }
    function loadCategory() {
        getData("category").done(renderCategoryChart).fail(function (xhr) { showError("#categoryChart", xhr); });
    }
    function loadPopular() {
        getData("popular").done(renderPopular).fail(function (xhr) { showError("#popularList", xhr); });
    }
    function loadStaff() {
        getData("staff").done(renderStaffChart).fail(function (xhr) { showError("#staffChart", xhr); });
    }
    function loadLowStock() {
        $.getJSON("ReportData.ashx", { type: "lowstock" })
            .done(renderLowStock)
            .fail(function (xhr) { showError("#lowStockList", xhr); });
    }

    // ---------- Revenue ----------
    function renderRevenueChart(data) {
        if (revenueChart) { revenueChart.destroy(); revenueChart = null; }
        $("#revenueChart").empty();

        if (!data || !data.labels || data.labels.length === 0) {
            $("#revenueChart").html("<p class='report-empty'>No revenue data for this period</p>");
            return;
        }

        const options = {
            series: [{ name: "Revenue", data: data.values }],
            chart: { type: "area", height: 340, toolbar: { show: false } },
            colors: ["#10b981"],
            dataLabels: { enabled: false },
            stroke: { curve: "smooth", width: 3 },
            fill: { type: "gradient", gradient: { opacityFrom: 0.4, opacityTo: 0.05 } },
            xaxis: { categories: data.labels },
            yaxis: { labels: { formatter: val => "R" + Number(val).toLocaleString() } }
        };

        revenueChart = new ApexCharts(document.querySelector("#revenueChart"), options);
        revenueChart.render();
    }

    // ---------- Category ----------
    function renderCategoryChart(data) {
        if (categoryChart) { categoryChart.destroy(); categoryChart = null; }
        $("#categoryChart").empty();

        if (!data || !data.labels || data.labels.length === 0) {
            $("#categoryChart").html("<p class='report-empty'>No category data for this period</p>");
            return;
        }

        const options = {
            series: data.values,
            chart: { type: "donut", height: 340 },
            labels: data.labels,
            colors: ["#3b82f6", "#10b981", "#f59e0b", "#8b5cf6", "#ef4444", "#06b6d4"],
            legend: { position: "bottom" }
        };

        categoryChart = new ApexCharts(document.querySelector("#categoryChart"), options);
        categoryChart.render();
    }

    // ---------- Staff Performance (bar graph) ----------
    function renderStaffChart(data) {
        if (staffChart) { staffChart.destroy(); staffChart = null; }
        $("#staffChart").empty();

        if (!data || !data.labels || data.labels.length === 0) {
            $("#staffChart").html("<p class='report-empty'>No staff orders for this period</p>");
            return;
        }

        const options = {
            series: [{ name: "Orders handled", data: data.values }],
            chart: { type: "bar", height: 340, toolbar: { show: false } },
            colors: ["#3b82f6"],
            plotOptions: { bar: { borderRadius: 6, columnWidth: "45%" } },
            dataLabels: { enabled: true },
            xaxis: { categories: data.labels },
            yaxis: { title: { text: "Orders handled" }, labels: { formatter: val => Math.round(val) } }
        };

        staffChart = new ApexCharts(document.querySelector("#staffChart"), options);
        staffChart.render();
    }

    // ---------- Popular Items ----------
    function renderPopular(items) {
        if (!items || items.length === 0) {
            $("#popularList").html("<p class='report-empty'>No items sold in this period</p>");
            return;
        }

        let html = "";
        items.forEach(function (item) {
            const icon = EMOJI[item.Category] || "🍽️";
            html += "<div class='pop-row'>" +
                "<span>" + icon + " " + esc(item.Name) + "</span>" +
                "<span class='pop-qty'>" + item.Quantity + "</span>" +
                "</div>";
        });
        $("#popularList").html(html);
    }

    // ---------- Low Stock ----------
    function renderLowStock(items) {
        if (!items || items.length === 0) {
            $("#lowStockList").html("<p class='report-empty'>All stock levels are healthy 👍</p>");
            return;
        }

        let html = "";
        items.forEach(function (item) {
            html += "<div class='stock-row'>" +
                "<div><div class='stock-name'>" + esc(item.Name) + "</div>" +
                "<div class='stock-sub'>" + item.Quantity + " " + esc(item.Unit) + " left</div></div>" +
                "<span class='level-badge lvl-" + esc(item.Level) + "'>" + esc(item.Level) + "</span>" +
                "</div>";
        });
        $("#lowStockList").html(html);
    }
</script>

</asp:Content>