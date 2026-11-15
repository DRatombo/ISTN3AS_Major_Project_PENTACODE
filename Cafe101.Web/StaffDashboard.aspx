<%@ Page Title="Staff Dashboard"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="StaffDashboard.aspx.cs"
    Inherits="Cafe101.Web.StaffDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="staff-shell">

        <!-- TOP HEADER -->
        <header class="staff-header">
            <div class="staff-header-left">
                <button type="button" id="sidebarToggle" class="staff-header-menu" aria-label="Toggle staff navigation">
                    ☰
                </button>
                <div class="staff-header-brand">Cafe101</div>
            </div>

            <a href="StaffProfile.aspx" class="staff-header-user text-decoration-none">
                <div class="staff-header-avatar">
                    <asp:Label ID="lblTopInitials" runat="server"></asp:Label>
                </div>
                <div>
                    <strong><asp:Label ID="lblTopStaffName" runat="server"></asp:Label></strong>
                    <small><asp:Label ID="lblTopStaffRole" runat="server"></asp:Label></small>
                </div>
            </a>
        </header>

        <div class="staff-body">

            <!-- SIDEBAR -->
            <aside class="staff-sidebar">
                <div class="staff-sidebar-title">
                    <span class="sidebar-full-text">STAFF SYSTEM</span>
                </div>

                <nav class="staff-nav">
                    <a href="StaffDashboard.aspx" class="active">
                        <span class="staff-nav-icon">&#8962;</span>
                        <span class="staff-nav-text">Dashboard</span>
                    </a>

                    <a href="StaffOrders.aspx">
                        <span class="staff-nav-icon">
                            <svg viewBox="0 0 24 24" width="19" height="19" fill="none" stroke="currentColor" stroke-width="2">
                                <path d="M6 3h12v18H6z" />
                                <path d="M9 8h6" />
                                <path d="M9 12h6" />
                                <path d="M9 16h4" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Orders</span>
                    </a>

                    <a href="StaffProfile.aspx">
                        <span class="staff-nav-icon">
                            <svg viewBox="0 0 24 24" width="19" height="19" fill="none" stroke="currentColor" stroke-width="2">
                                <circle cx="12" cy="8" r="4" />
                                <path d="M4 21c0-4 3.5-7 8-7s8 3 8 7" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Profile</span>
                    </a>

                    <a href="StaffHelp.aspx">
                        <span class="staff-nav-icon">
                            <svg viewBox="0 0 24 24" width="19" height="19" fill="none" stroke="currentColor" stroke-width="2">
                                <circle cx="12" cy="12" r="9" />
                                <path d="M9.5 9a2.5 2.5 0 0 1 5 0c0 2-2.5 2-2.5 4" />
                                <path d="M12 17h.01" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Help Centre</span>
                    </a>
                </nav>

                <div class="staff-sidebar-bottom">
                    <asp:LinkButton ID="lnkLogout" runat="server" CssClass="staff-logout" OnClick="lnkLogout_Click">
                        <span class="staff-nav-icon">&#10140;</span>
                        <span class="staff-nav-text">Logout</span>
                    </asp:LinkButton>
                </div>
            </aside>

            <!-- MAIN CONTENT -->
            <main class="staff-main">

                <div class="staff-page-heading">
                    <h3>Staff Dashboard</h3>
                    <p>Overview of today's Cafe101 operations.</p>
                </div>

                <!-- WELCOME CARD -->
                <section class="staff-welcome-card">
                    <div class="staff-icon-box icon-beige">
                        <svg viewBox="0 0 24 24" width="28" height="28" fill="none" stroke="currentColor" stroke-width="2">
                            <path d="M5 8h11v6a5 5 0 0 1-5 5H10a5 5 0 0 1-5-5V8z" />
                            <path d="M16 10h2a3 3 0 0 1 0 6h-2" />
                            <path d="M8 3c1 1 1 2 0 3" />
                            <path d="M12 3c1 1 1 2 0 3" />
                        </svg>
                    </div>
                    <div class="staff-welcome-text">
                        <h4>
                            Welcome back,
                            <asp:Label ID="lblStaffName" runat="server"></asp:Label>!
                        </h4>
                        <p>Here's what's happening at Cafe101 today.</p>
                    </div>
                </section>

                <!-- RECENT ORDERS + QUICK ACTIONS -->
                <div class="staff-dashboard-grid">

                    <!-- RECENT ORDERS -->
                    <section class="staff-dashboard-panel">
                        <div class="staff-panel-heading">
                            <div>
                                <h5>Recent Orders</h5>
                                <small>Latest customer orders</small>
                            </div>
                            <a href="StaffOrders.aspx" class="staff-text-link">View All Orders →</a>
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
                                <tbody>
                                    <asp:Repeater ID="rptRecentOrders" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><strong>#<%# Eval("OrderID") %></strong></td>
                                                <td><%# Eval("CustomerName") %></td>
                                                <td><%# Eval("ItemCount") %> items</td>
                                                <td>R<%# Eval("TotalAmountDue", "{0:N2}") %></td>
                                                <td>
                                                    <span class='order-status <%# GetStatusCss(Convert.ToString(Eval("OrderStatus"))) %>'>
                                                        <%# Eval("OrderStatus") %>
                                                    </span>
                                                </td>
                                                <td><%# Eval("OrderDateTime", "{0:HH:mm}") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </section>

                    <!-- QUICK ACTIONS -->
                    <section class="staff-dashboard-panel">
                        <div class="staff-panel-heading">
                            <div>
                                <h5>Quick Actions</h5>
                                <small>Common staff tasks</small>
                            </div>
                        </div>

                        <div class="staff-action-grid">
                            <a href="StaffOrders.aspx" class="staff-action-tile">
                                <div class="staff-icon-box icon-beige">
                                    <svg viewBox="0 0 24 24" width="24" height="24" fill="none" stroke="currentColor" stroke-width="2">
                                        <path d="M6 3h12v18H6z" />
                                        <path d="M9 8h6" />
                                        <path d="M9 12h6" />
                                        <path d="M9 16h4" />
                                    </svg>
                                </div>
                                <div>
                                    <strong>View Orders</strong>
                                    <small>Browse all orders</small>
                                </div>
                            </a>

                            <a href="StaffOrders.aspx" class="staff-action-tile">
                                <div class="staff-icon-box icon-blue">
                                    <svg viewBox="0 0 24 24" width="24" height="24" fill="none" stroke="currentColor" stroke-width="2">
                                        <circle cx="10" cy="10" r="6" />
                                        <path d="M15 15l5 5" />
                                    </svg>
                                </div>
                                <div>
                                    <strong>Search Orders</strong>
                                    <small>Find a specific order</small>
                                </div>
                            </a>

                            <a href="Menu.aspx?source=staff" class="staff-action-tile">
                                <div class="staff-icon-box icon-green">
                                    <span style="font-size:24px;">＋</span>
                                </div>
                                <div>
                                    <strong>Make New Order</strong>
                                    <small>Take and process a customer order</small>
                                </div>
                            </a>
                        </div>
                    </section>
                </div>

                <!-- NOTICES & ALERTS (Full Width) -->
                <div class="staff-dashboard-grid staff-dashboard-bottom">
                    <section class="staff-dashboard-panel" style="grid-column: 1 / -1;">
                        <div class="staff-panel-heading">
                            <div>
                                <h5>Notices & Alerts</h5>
                                <small>Important staff updates</small>
                            </div>
                        </div>

                        <asp:Repeater ID="rptRecentAlerts" runat="server">
                            <ItemTemplate>
                                <div class="staff-alert-item">
                                    <div class="staff-alert-icon alert-blue">
                                        <svg viewBox="0 0 24 24" width="19" height="19" fill="none" stroke="currentColor" stroke-width="2">
                                            <circle cx="12" cy="12" r="9" />
                                            <path d="M12 11v5" />
                                            <path d="M12 8h.01" />
                                        </svg>
                                    </div>
                                    <div class="staff-alert-text">
                                        <strong>
                                            <%# GetAlertHeading(Convert.ToString(Eval("OrderStatus"))) %>
                                        </strong>
                                        <small>
                                            Order #<%# Eval("OrderID") %> is
                                            <%# Convert.ToString(Eval("OrderStatus")).ToLower() %>.
                                        </small>
                                    </div>
                                    <span class="staff-alert-time">
                                        <%# Eval("OrderDateTime", "{0:HH:mm}") %>
                                    </span>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </section>
                </div>

                <div class="staff-footer">
                    © 2026 Cafe101 Staff System
                </div>

            </main>
        </div>
    </div>

    <script>
        document.body.classList.add("staff-page");

        const publicNavbar = document.querySelector(".navbar");
        if (publicNavbar) {
            publicNavbar.style.display = "none";
        }

        const bodyContent = document.querySelector(".body-content");
        if (bodyContent) {
            bodyContent.classList.remove("container");
            bodyContent.style.width = "100%";
            bodyContent.style.maxWidth = "none";
            bodyContent.style.margin = "0";
            bodyContent.style.padding = "0";
        }

        const masterFooter = document.querySelector(".body-content > footer");
        if (masterFooter) {
            masterFooter.style.display = "none";
        }

        const masterFooterLine = document.querySelector(".body-content > hr");
        if (masterFooterLine) {
            masterFooterLine.style.display = "none";
        }

        const sidebarToggle = document.getElementById("sidebarToggle");
        const staffBody = document.querySelector(".staff-body");
        if (sidebarToggle && staffBody) {
            sidebarToggle.addEventListener("click", function () {
                staffBody.classList.toggle("sidebar-collapsed");
            });
        }
    </script>

</asp:Content>