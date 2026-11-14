<%@ Page Title="Manager Dashboard"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ManagerDashboard.aspx.cs"
    Inherits="Cafe101.Web.ManagerDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="staff-shell manager-shell">

        <%-- TOP HEADER --%>
        <header class="staff-header">
            <div class="staff-header-left">
                <button type="button" id="sidebarToggle" class="staff-header-menu" aria-label="Toggle manager navigation">☰</button>
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

            <%-- SIDEBAR --%>
            <aside class="staff-sidebar">
                <div class="staff-sidebar-title">MANAGER SYSTEM</div>

                <nav class="staff-nav" aria-label="Manager navigation">
                    <a href="ManagerDashboard.aspx" class="active" aria-current="page" aria-label="Dashboard">
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
                    <a href="ManagerReports.aspx" aria-label="Reports">
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
                        <span class="staff-nav-icon">&#10140;</span>
                        <span class="staff-nav-text">Logout</span>
                    </asp:LinkButton>
                </div>
            </aside>

            <%-- MAIN CONTENT --%>
            <main class="staff-main">

                <div class="staff-page-heading">
                    <h3>Manager Dashboard</h3>
                    <p>Overview of Cafe101 operations and performance.</p>
                </div>

                <%-- WELCOME CARD --%>
                <section class="staff-dashboard-panel manager-welcome-card">
                    <div class="manager-welcome-left">
                        <div class="staff-icon-box icon-beige">
                            <svg viewBox="0 0 24 24" width="24" height="24" fill="none" stroke="currentColor" stroke-width="2"><path d="M5 8h11v7a5 5 0 0 1-5 5H10a5 5 0 0 1-5-5z" /><path d="M16 10h2a3 3 0 0 1 0 6h-2" /><path d="M8 3v2" /><path d="M12 3v2" /></svg>
                        </div>
                        <div>
                            <h4>Welcome back, <asp:Label ID="lblManagerName" runat="server"></asp:Label>!</h4>
                            <p>Here's an overview of today's performance and key metrics.</p>
                        </div>
                    </div>

                    <div class="manager-date-box">
                        <svg viewBox="0 0 24 24" width="17" height="17" fill="none" stroke="currentColor" stroke-width="2"><rect x="3" y="5" width="18" height="16" rx="2" /><path d="M8 3v4" /><path d="M16 3v4" /><path d="M3 10h18" /></svg>
                        <div>
                            <strong><asp:Label ID="lblCurrentDate" runat="server"></asp:Label></strong>
                            <small>Cafe101</small>
                        </div>
                    </div>
                </section>

                <%-- METRIC CARDS (filled by script) --%>
                <div class="staff-metric-grid">

                    <div class="staff-metric-card">
                        <div class="staff-icon-box icon-green">
                            <svg viewBox="0 0 24 24" width="24" height="24" fill="none" stroke="currentColor" stroke-width="2"><path d="M6 7h12l-1 13H7L6 7z" /><path d="M9 7a3 3 0 0 1 6 0" /></svg>
                        </div>
                        <div>
                            <span class="staff-metric-label">TOTAL ORDERS TODAY</span>
                            <h3 id="kpiOrders">…</h3>
                            <p id="kpiOrdersChange"></p>
                        </div>
                    </div>

                    <div class="staff-metric-card">
                        <div class="staff-icon-box icon-blue"><span class="manager-money-icon">R</span></div>
                        <div>
                            <span class="staff-metric-label">REVENUE TODAY</span>
                            <h3 id="kpiRevenue">…</h3>
                            <p id="kpiRevenueChange"></p>
                        </div>
                    </div>

                    <div class="staff-metric-card">
                        <div class="staff-icon-box icon-orange">
                            <svg viewBox="0 0 24 24" width="24" height="24" fill="none" stroke="currentColor" stroke-width="2"><circle cx="12" cy="12" r="9" /><path d="M12 7v5l3 2" /></svg>
                        </div>
                        <div>
                            <span class="staff-metric-label">PENDING ORDERS</span>
                            <h3 id="kpiPending">…</h3>
                            <p>Orders waiting to be processed</p>
                        </div>
                    </div>

                    <div class="staff-metric-card">
                        <div class="staff-icon-box manager-icon-red">
                            <svg viewBox="0 0 24 24" width="24" height="24" fill="none" stroke="currentColor" stroke-width="2"><path d="M12 3L2 21h20L12 3z" /><path d="M12 9v5" /><path d="M12 18h.01" /></svg>
                        </div>
                        <div>
                            <span class="staff-metric-label">LOW STOCK ITEMS</span>
                            <h3 id="kpiLowStock">…</h3>
                            <p id="kpiLowStockText"></p>
                        </div>
                    </div>

                </div>

                <%-- SALES + RECENT ORDERS --%>
                <div class="manager-main-grid">

                    <section class="staff-dashboard-panel">
                        <div class="staff-panel-heading">
                            <div>
                                <h5>Sales Overview</h5>
                                <small id="salesSubtitle">Daily revenue over the last 7 days</small>
                            </div>
                            <select id="salesRange" class="form-control manager-period-filter">
                                <option value="Last7Days">Last 7 Days</option>
                                <option value="Last30Days">Last 30 Days</option>
                                <option value="ThisMonth">This Month</option>
                            </select>
                        </div>
                        <div id="salesChart" style="min-height: 300px;"></div>
                    </section>

                    <section class="staff-dashboard-panel">
                        <div class="staff-panel-heading">
                            <div>
                                <h5>Recent Orders</h5>
                                <small>Latest customer orders</small>
                            </div>
                            <a href="ManagerOrders.aspx" class="staff-text-link">View All Orders →</a>
                        </div>

                        <div class="table-responsive">
                            <table class="table staff-orders-table">
                                <thead>
                                    <tr>
                                        <th>Order #</th>
                                        <th>Customer</th>
                                        <th>Items</th>
                                        <th>Total</th>
                                        <th>Status</th>
                                        <th>Time</th>
                                    </tr>
                                </thead>
                                <tbody id="recentOrdersBody"></tbody>
                            </table>
                        </div>
                    </section>

                </div>

                <%-- LOWER DASHBOARD --%>
                <div class="manager-bottom-grid">

                    <section class="staff-dashboard-panel">
                        <div class="staff-panel-heading">
                            <div>
                                <h5>Popular Items</h5>
                                <small>Top selling menu items today</small>
                            </div>
                        </div>

                        <div class="manager-popular-table">
                            <div class="manager-popular-header">
                                <span>Item</span>
                                <span>Quantity Sold</span>
                            </div>
                            <div id="popularList"></div>
                        </div>

                        <a href="ManagerReports.aspx" class="staff-text-link manager-bottom-link">View Full Menu Report →</a>
                    </section>

                    <section class="staff-dashboard-panel">
                        <div class="staff-panel-heading">
                            <div>
                                <h5>Staff</h5>
                                <small>Cafe101 employees</small>
                            </div>
                        </div>

                        <div class="manager-shift-table">
                            <div class="manager-shift-header">
                                <span>Name</span>
                                <span>Role</span>
                                <span>Status</span>
                            </div>
                            <div id="staffList"></div>
                        </div>

                        <a href="ManagerStaff.aspx" class="staff-text-link manager-bottom-link">Manage Staff →</a>
                    </section>

                    <section class="staff-dashboard-panel">
                        <div class="staff-panel-heading">
                            <div>
                                <h5>Low Stock Alerts</h5>
                                <small>Items that need restocking</small>
                            </div>
                        </div>

                        <div class="manager-stock-list" id="lowStockList"></div>
                    </section>

                    <section class="staff-dashboard-panel">
                        <div class="staff-panel-heading">
                            <div>
                                <h5>Quick Actions</h5>
                                <small>Common management tasks</small>
                            </div>
                        </div>

                        <div class="manager-quick-grid">
                            <a href="ManagerMenu.aspx" class="manager-quick-action">
                                <span class="staff-icon-box icon-green"><svg viewBox="0 0 24 24" width="18" height="18" fill="none" stroke="currentColor" stroke-width="2"><path d="M4 4h16v16H4z" /><path d="M8 8h8" /></svg></span>
                                <div><strong>Manage Menu</strong><small>Add or edit menu items</small></div>
                            </a>

                            <a href="ManagerStaff.aspx" class="manager-quick-action">
                                <span class="staff-icon-box icon-blue"><svg viewBox="0 0 24 24" width="18" height="18" fill="none" stroke="currentColor" stroke-width="2"><circle cx="12" cy="8" r="4" /><path d="M4 21c0-4 3.5-7 8-7s8 3 8 7" /></svg></span>
                                <div><strong>Manage Staff</strong><small>View staff accounts</small></div>
                            </a>

                            <a href="ManagerReports.aspx" class="manager-quick-action">
                                <span class="staff-icon-box icon-purple"><svg viewBox="0 0 24 24" width="18" height="18" fill="none" stroke="currentColor" stroke-width="2"><path d="M4 20V10" /><path d="M10 20V4" /><path d="M16 20v-7" /></svg></span>
                                <div><strong>View Reports</strong><small>Sales and performance</small></div>
                            </a>

                            <a href="ManagerOrders.aspx" class="manager-quick-action">
                                <span class="staff-icon-box icon-beige"><svg viewBox="0 0 24 24" width="18" height="18" fill="none" stroke="currentColor" stroke-width="2"><path d="M6 3h12v18H6z" /><path d="M9 8h6" /><path d="M9 12h6" /></svg></span>
                                <div><strong>View Orders</strong><small>Browse all orders</small></div>
                            </a>
                        </div>
                    </section>

                </div>

                <div class="staff-footer">© 2026 Cafe101 Manager System</div>

            </main>
        </div>
    </div>

    <script>
        document.body.classList.add("staff-page");

        const publicNavbar = document.querySelector(".navbar");
        if (publicNavbar) publicNavbar.style.display = "none";

        const bodyContent = document.querySelector(".body-content");
        if (bodyContent) {
            bodyContent.classList.remove("container");
            bodyContent.style.width = "100%";
            bodyContent.style.maxWidth = "none";
            bodyContent.style.margin = "0";
            bodyContent.style.padding = "0";
        }

        const masterFooter = document.querySelector(".body-content > footer");
        if (masterFooter) masterFooter.style.display = "none";

        const masterFooterLine = document.querySelector(".body-content > hr");
        if (masterFooterLine) masterFooterLine.style.display = "none";

        const sidebarToggle = document.getElementById("sidebarToggle");
        const staffBody = document.querySelector(".staff-body");
        if (sidebarToggle && staffBody) {
            sidebarToggle.addEventListener("click", function () {
                staffBody.classList.toggle("sidebar-collapsed");
            });
        }
    </script>

    <script src="https://cdn.jsdelivr.net/npm/apexcharts"></script>
    <script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>

    <script>
        let salesChart = null;

        const EMOJI = { "Burger": "🍔", "Wings": "🍗", "Combo": "🍱", "Drinks": "🥤", "Sides": "🍟" };

        const SUBTITLES = {
            "Last7Days": "Daily revenue over the last 7 days",
            "Last30Days": "Daily revenue over the last 30 days",
            "ThisMonth": "Daily revenue this month"
        };

        function esc(text) {
            return $("<div>").text(text == null ? "" : text).html();
        }

        function money(n) {
            return "R" + Number(n).toLocaleString("en-ZA", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
        }

        function showError(selector, xhr) {
            $(selector).html("<div style='color:red;padding:10px;white-space:pre-wrap;'>Error " +
                xhr.status + "\n" + esc((xhr.responseText || "").substring(0, 300)) + "</div>");
        }

        $(document).ready(function () {
            $("#salesRange").on("change", loadSales);

            loadCards();
            loadSales();
            loadRecent();
            loadPopular();
            loadStaff();
            loadLowStock();
        });

        // ---------- Top 4 cards ----------
        function setChange(selector, pct) {
            const el = $(selector);
            if (pct === null || pct === undefined) {
                el.text("No data for yesterday").attr("class", "");
                return;
            }
            const up = pct >= 0;
            el.text((up ? "↑ " : "↓ ") + Math.abs(pct) + "% from yesterday")
                .attr("class", up ? "manager-positive-text" : "manager-alert-text");
        }

        function loadCards() {
            $.getJSON("ReportData.ashx", { type: "dashcards" })
                .done(function (d) {
                    $("#kpiOrders").text(d.OrdersToday);
                    setChange("#kpiOrdersChange", d.OrdersChange);

                    $("#kpiRevenue").text(money(d.RevenueToday));
                    setChange("#kpiRevenueChange", d.RevenueChange);

                    $("#kpiPending").text(d.PendingOrders);

                    $("#kpiLowStock").text(d.LowStockCount);
                    if (d.LowStockCount > 0) {
                        $("#kpiLowStockText").text("Requires immediate attention").attr("class", "manager-alert-text");
                    } else {
                        $("#kpiLowStockText").text("All stock levels are healthy").attr("class", "manager-positive-text");
                    }
                })
                .fail(function (xhr) { showError("#kpiOrdersChange", xhr); });
        }

        // ---------- Sales chart ----------
        function loadSales() {
            const range = $("#salesRange").val();
            $("#salesSubtitle").text(SUBTITLES[range] || "");

            $.getJSON("ReportData.ashx", { type: "revenue", dateRange: range })
                .done(renderSales)
                .fail(function (xhr) { showError("#salesChart", xhr); });
        }

        function renderSales(data) {
            if (salesChart) { salesChart.destroy(); salesChart = null; }
            $("#salesChart").empty();

            if (!data || !data.labels || data.labels.length === 0) {
                $("#salesChart").html("<p style='padding:20px;color:#666;'>No sales in this period</p>");
                return;
            }

            salesChart = new ApexCharts(document.querySelector("#salesChart"), {
                series: [{ name: "Revenue", data: data.values }],
                chart: { type: "area", height: 300, toolbar: { show: false } },
                colors: ["#3b82f6"],
                dataLabels: { enabled: false },
                stroke: { curve: "smooth", width: 3 },
                fill: { type: "gradient", gradient: { opacityFrom: 0.35, opacityTo: 0.05 } },
                xaxis: { categories: data.labels },
                yaxis: { labels: { formatter: function (v) { return "R" + Number(v).toLocaleString(); } } }
            });
            salesChart.render();
        }

        // ---------- Recent orders ----------
        function statusClass(status) {
            const s = (status || "").toLowerCase();
            if (s === "completed") return "status-completed";
            if (s === "ready") return "status-ready";
            if (s === "preparing") return "status-preparing";
            return "status-pending";
        }

        function loadRecent() {
            $.getJSON("ReportData.ashx", { type: "recent" })
                .done(function (orders) {
                    if (!orders || orders.length === 0) {
                        $("#recentOrdersBody").html("<tr><td colspan='6' style='padding:20px;color:#666;'>No orders yet</td></tr>");
                        return;
                    }
                    let html = "";
                    orders.forEach(function (o) {
                        html += "<tr>" +
                            "<td><strong>#" + esc(o.OrderID) + "</strong></td>" +
                            "<td>" + esc(o.Customer) + "</td>" +
                            "<td>" + o.Items + "</td>" +
                            "<td>" + esc(o.Total) + "</td>" +
                            "<td><span class='order-status " + statusClass(o.Status) + "'>" + esc(o.Status) + "</span></td>" +
                            "<td>" + esc(o.Time) + "</td>" +
                            "</tr>";
                    });
                    $("#recentOrdersBody").html(html);
                })
                .fail(function (xhr) { showError("#recentOrdersBody", xhr); });
        }

        // ---------- Popular items (today) ----------
        function loadPopular() {
            $.getJSON("ReportData.ashx", { type: "popular", dateRange: "Today" })
                .done(function (items) {
                    if (!items || items.length === 0) {
                        $("#popularList").html("<p style='padding:14px 0;color:#666;'>No items sold today yet</p>");
                        return;
                    }
                    let html = "";
                    items.forEach(function (i) {
                        html += "<div class='manager-popular-row'>" +
                            "<span>" + (EMOJI[i.Category] || "🍽️") + " " + esc(i.Name) + "</span>" +
                            "<strong>" + i.Quantity + "</strong></div>";
                    });
                    $("#popularList").html(html);
                })
                .fail(function (xhr) { showError("#popularList", xhr); });
        }

        // ---------- Staff ----------
        function loadStaff() {
            $.getJSON("ReportData.ashx", { type: "dashstaff" })
                .done(function (people) {
                    if (!people || people.length === 0) {
                        $("#staffList").html("<p style='padding:14px 0;color:#666;'>No staff found</p>");
                        return;
                    }
                    let html = "";
                    people.forEach(function (p) {
                        const active = (p.Status || "").toLowerCase() === "active";
                        const style = active ? "" : " style='background:#f3f4f6;color:#6b7280;'";
                        html += "<div class='manager-shift-row'>" +
                            "<span>" + esc(p.Name) + "</span>" +
                            "<span>" + esc(p.Role) + "</span>" +
                            "<span class='manager-shift-time'" + style + ">" + esc(p.Status) + "</span></div>";
                    });
                    $("#staffList").html(html);
                })
                .fail(function (xhr) { showError("#staffList", xhr); });
        }

        // ---------- Low stock ----------
        function loadLowStock() {
            $.getJSON("ReportData.ashx", { type: "lowstock" })
                .done(function (items) {
                    if (!items || items.length === 0) {
                        $("#lowStockList").html("<p style='padding:14px 0;color:#666;'>All stock levels are healthy 👍</p>");
                        return;
                    }
                    let html = "";
                    items.forEach(function (i) {
                        const level = (i.Level || "Low").toLowerCase();
                        html += "<div class='manager-stock-item'><div>" +
                            "<strong>" + esc(i.Name) + "</strong>" +
                            "<small>" + i.Quantity + " " + esc(i.Unit) + " left</small></div>" +
                            "<span class='manager-stock-" + level + "'>" + esc(i.Level) + "</span></div>";
                    });
                    $("#lowStockList").html(html);
                })
                .fail(function (xhr) { showError("#lowStockList", xhr); });
        }
    </script>

</asp:Content>