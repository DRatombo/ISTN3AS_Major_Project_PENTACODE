<%@ page title="Manager Orders"
    language="C#"
    masterpagefile="~/Site.Master"
    autoeventwireup="true"
    codebehind="ManagerOrders.aspx.cs"
    inherits="Cafe101.Web.ManagerOrders" %>


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



            <%-- =================================================
                 LOGGED-IN MANAGER
                 ================================================= --%>

            <a href="ManagerProfile.aspx"
                class="staff-header-user text-decoration-none">


                <div class="staff-header-avatar">

                    <asp:Label
                        ID="lblTopManagerInitials"
                        runat="server"></asp:Label>

                </div>


                <div>


                    <strong>

                        <asp:Label
                            ID="lblTopManagerName"
                            runat="server"></asp:Label>

                    </strong>


                    <small>

                        <asp:Label
                            ID="lblTopManagerRole"
                            runat="server"></asp:Label>

                    </small>


                </div>


            </a>


        </header>



        <%-- =================================================
             BODY
             ================================================= --%>

        <div class="staff-body">


            <%-- =================================================
                 SIDEBAR
                 ================================================= --%>

            <aside class="staff-sidebar">


                <div class="staff-sidebar-title">
                    MANAGER SYSTEM
                </div>



                <nav class="staff-nav" aria-label="Manager navigation">
                    <%-- Keep all management links available on every manager page. --%>
                    <a href="ManagerDashboard.aspx" aria-label="Dashboard">
                        <span class="staff-nav-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" width="19" height="19"
                                fill="none" stroke="currentColor" stroke-width="2">
                                <path d="M3 10l9-7 9 7M5 9v12h14V9M9 21v-8h6v8" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Dashboard</span>
                    </a>

                    <a href="ManagerOrders.aspx" class="active" aria-current="page" aria-label="Orders">
                        <span class="staff-nav-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" width="19" height="19"
                                fill="none" stroke="currentColor" stroke-width="2">
                                <path d="M6 3h12v18H6zM9 8h6M9 12h6M9 16h4" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Orders</span>
                    </a>

                    <a href="ManagerMenu.aspx" aria-label="Menu">
                        <span class="staff-nav-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" width="19" height="19"
                                fill="none" stroke="currentColor" stroke-width="2">
                                <path d="M4 4h16v16H4zM8 8h8M8 12h8M8 16h5" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Menu</span>
                    </a>

                    <a href="ManageIngredients.aspx" aria-label="Ingredients">
                        <span class="staff-nav-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" width="19" height="19"
                                fill="none" stroke="currentColor" stroke-width="2">
                                <path d="M4 7h16v14H4zM3 3h18v4H3zM9 11h6" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Ingredients</span>
                    </a>

                    <a href="ManageRecipes.aspx" aria-label="Recipes">
                        <span class="staff-nav-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" width="19" height="19"
                                fill="none" stroke="currentColor" stroke-width="2">
                                <path d="M5 3h14v18H5zM8 7h8M8 11h8M8 15h5" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Recipes</span>
                    </a>

                    <a href="ManagerStaff.aspx" aria-label="Staff">
                        <span class="staff-nav-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" width="19" height="19"
                                fill="none" stroke="currentColor" stroke-width="2">
                                <circle cx="9" cy="8" r="3" /><circle cx="17" cy="10" r="2" /><path d="M3 20c0-4 2.5-7 6-7s6 3 6 7M15 15c3 0 5 2 5 5" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Staff</span>
                    </a>

                    <a href="ManagerReports.aspx" aria-label="Reports">
                        <span class="staff-nav-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" width="19" height="19"
                                fill="none" stroke="currentColor" stroke-width="2">
                                <path d="M4 20V10M10 20V4M16 20v-7M22 20H2" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Reports</span>
                    </a>

                    <a href="ManagerProfile.aspx" aria-label="Profile">
                        <span class="staff-nav-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" width="19" height="19"
                                fill="none" stroke="currentColor" stroke-width="2">
                                <circle cx="12" cy="8" r="4" /><path d="M4 21c0-4 3.5-7 8-7s8 3 8 7" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Profile</span>
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
                        OnClick="LnkLogout_Click">


                        <span class="staff-nav-icon">&#10140;
                        </span>


                        <span class="staff-nav-text">Logout
                        </span>


                    </asp:LinkButton>


                </div>


            </aside>



            <%-- =================================================
                 MAIN ORDERS AREA
                 ================================================= --%>

            <main class="staff-main">


                <%-- =================================================
                     PAGE HEADING
                     ================================================= --%>

                <div class="staff-page-heading">


                    <h3>Orders
                    </h3>


                    <p>
                        Monitor, manage and review all customer orders.
                    </p>


                </div>

                <%-- =================================================
     AJAX UPDATE PANEL - NO FULL PAGE REFRESH
     ================================================= --%>

                <asp:UpdatePanel
                    ID="updManagerOrders"
                    runat="server"
                    UpdateMode="Conditional"
                    ChildrenAsTriggers="true">

                    <contenttemplate>


                        <%-- =================================================
                     ORDER TOOLBAR (REAL SEARCH + FILTERS)
                     ================================================= --%>
                        <div class="manager-orders-toolbar">
                            <div class="manager-orders-toolbar-left">
                                <div class="staff-search-box">
                                    <span class="staff-search-icon" aria-hidden="true">⌕</span>
                                    <asp:TextBox ID="txtOrderSearch" runat="server"
                                        CssClass="form-control" placeholder="Order #, Customer ID or customer name..." />
                                </div>
                                <asp:Button ID="btnSearch" runat="server" Text="Search"
                                    CssClass="btn btn-brand" OnClick="ApplyFilters_Click" CausesValidation="false" />
                                <div class="staff-filter-box">
                                    <asp:DropDownList ID="ddlOrderStatus" runat="server"
                                        CssClass="form-control staff-status-filter" AutoPostBack="true"
                                        OnSelectedIndexChanged="ApplyFilters_Changed">
                                        <asp:ListItem Text="All statuses" Value="" />
                                        <asp:ListItem Text="Pending" Value="Pending" />
                                        <asp:ListItem Text="Completed" Value="Completed" />
                                        <asp:ListItem Text="Declined" Value="Declined" />
                                    </asp:DropDownList>
                                </div>
                                <div class="manager-date-filter">
                                    <asp:DropDownList ID="ddlDateRange" runat="server"
                                        CssClass="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="ApplyFilters_Changed">
                                        <asp:ListItem Text="All dates" Value="" />
                                        <asp:ListItem Text="Today" Value="Today" />
                                        <asp:ListItem Text="Last 7 days" Value="7" />
                                        <asp:ListItem Text="Last 30 days" Value="30" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="manager-orders-toolbar-right">
                                <asp:Button ID="btnExport" runat="server" Text="Export CSV"
                                    CssClass="btn btn-outline-brand" OnClick="ExportOrders_Click" CausesValidation="false" />
                                <asp:Button ID="btnRefresh" runat="server" Text="Refresh"
                                    CssClass="btn btn-brand" OnClick="RefreshOrders_Click" CausesValidation="false" />
                            </div>
                        </div>

                        <%-- =================================================
                     SUMMARY CARDS - COUNTS FROM ORDERTABLE
                     ================================================= --%>
                        <div class="staff-metric-grid">
                            <div class="staff-metric-card">
                                <div class="staff-icon-box icon-blue">▤</div>
                                <div>
                                    <span class="staff-metric-label">TOTAL ORDERS</span>
                                    <h3>
                                        <asp:Label ID="lblTotalOrders" runat="server" Text="0" />
                                    </h3>
                                    <p>All recorded orders</p>
                                </div>
                            </div>
                            <div class="staff-metric-card">
                                <div class="staff-icon-box icon-orange">◷</div>
                                <div>
                                    <span class="staff-metric-label">PENDING ORDERS</span>
                                    <h3>
                                        <asp:Label ID="lblPendingOrders" runat="server" Text="0" />
                                    </h3>
                                    <p>Awaiting attention</p>
                                </div>
                            </div>
                            <div class="staff-metric-card">
                                <div class="staff-icon-box icon-beige">✓</div>
                                <div>
                                    <span class="staff-metric-label">COMPLETED ORDERS</span>
                                    <h3>
                                        <asp:Label ID="lblCompletedOrders" runat="server" Text="0" />
                                    </h3>
                                    <p>Successfully completed</p>
                                </div>
                            </div>
                            <div class="staff-metric-card">
                                <div class="staff-icon-box icon-red">×</div>
                                <div>
                                    <span class="staff-metric-label">DECLINED ORDERS</span>
                                    <h3>
                                        <asp:Label ID="lblDeclinedOrders" runat="server" Text="0" />
                                    </h3>
                                    <p>Orders declined</p>
                                </div>
                            </div>
                        </div>

                        <%-- Selection is preserved only until you close or change the list. --%>
                        <asp:HiddenField ID="hfSelectedOrderID" runat="server" />

                        <%-- =================================================
                     ALL ORDERS + SLIDING DETAILS PANEL
                     ================================================= --%>
                        <div class="manager-orders-workspace" id="ordersWorkspace">
                            <section class="staff-dashboard-panel manager-orders-table-card">
                                <div class="staff-panel-heading">
                                    <div>
                                        <h5>All Orders</h5>
                                        <small>Orders from the central Cafe101 database</small>
                                    </div>
                                </div>
                                <div class="table-responsive">
                                    <table class="table staff-orders-table manager-orders-table">
                                        <thead>
                                            <tr>
                                                <th>Order #</th>
                                                <th>Customer</th>
                                                <th>Type</th>
                                                <th>Total Items</th>
                                                <th>Total</th>
                                                <th>Payment</th>
                                                <th>Status</th>
                                                <th>Order Date</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptOrders" runat="server">
                                                <itemtemplate>
                                                    <tr>
                                                        <td><strong>#<%#: Eval("OrderID") %></strong></td>
                                                        <td>
                                                            <strong><%#: Eval("CustomerName") %></strong>
                                                            <div class="text-muted small">Customer ID: <%#: Eval("CustomerID") %></div>
                                                        </td>
                                                        <td><%#: Eval("OrderType") %></td>
                                                        <td><%#: Eval("ItemCount", "{0:0.##}") %></td>
                                                        <td>R<%#: Eval("TotalAmountDue", "{0:N2}") %></td>
                                                        <td><%#: Eval("PaymentMethod") %></td>
                                                        <td>
                                                            <span class='order-status <%# GetStatusCssClass(Eval("OrderStatus")) %>'>
                                                                <%#: Eval("OrderStatus") %>
                                                            </span>
                                                        </td>
                                                        <td><%#: Eval("OrderDateTime", "{0:dd MMM yyyy HH:mm}") %></td>
                                                        <td>
                                                            <asp:LinkButton ID="lnkViewOrder" runat="server"
                                                                Text="View" CssClass="btn btn-outline-brand btn-sm"
                                                                CommandArgument='<%# Eval("OrderID") %>'
                                                                OnCommand="ViewOrder_Command" CausesValidation="false" />
                                                        </td>
                                                    </tr>
                                                </itemtemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                                <asp:Panel ID="pnlNoOrders" runat="server" Visible="false" CssClass="manager-empty-orders">
                                    No orders match your search or filters.
                                </asp:Panel>
                                <%-- Genuine server-side pagination --%>
                                <div class="manager-orders-pagination">
                                    <div class="manager-pagination-controls">
                                        <asp:LinkButton ID="lnkPrevious" runat="server" Text="Previous"
                                            OnClick="PreviousPage_Click" CausesValidation="false" />
                                        <asp:Label ID="lblCurrentPage" runat="server" />
                                        <asp:LinkButton ID="lnkNext" runat="server" Text="Next"
                                            OnClick="NextPage_Click" CausesValidation="false" />
                                    </div>
                                    <small>
                                        <asp:Label ID="lblShowing" runat="server" />
                                    </small>
                                </div>
                            </section>

                            <%-- Only shows database records after clicking View --%>
                            <aside class="staff-dashboard-panel manager-order-details" id="orderDetailsPanel"
                                aria-label="Selected order details">
                                <button type="button" id="btnCloseOrderDetails" class="manager-details-close"
                                    aria-label="Close order details" title="Close details">
                                    &times;</button>

                                <asp:Panel ID="pnlSelectPrompt" runat="server">
                                    <h4>Order Details</h4>
                                    <p class="text-muted">Select an order to view its details.</p>
                                </asp:Panel>

                                <asp:Panel ID="pnlSelectedOrder" runat="server" Visible="false">
                                    <div class="manager-order-details-header">
                                        <div>
                                            <h4>Order #<asp:Label ID="lblDetailOrderID" runat="server" /></h4>
                                            <small>
                                                <asp:Label ID="lblDetailDate" runat="server" />
                                            </small>
                                        </div>
                                        <asp:Label ID="lblDetailStatus" runat="server" CssClass="order-status" />
                                    </div>
                                    <div class="manager-order-detail-section">
                                        <small class="staff-detail-label">CUSTOMER</small>
                                        <strong>
                                            <asp:Label ID="lblDetailCustomer" runat="server" />
                                        </strong>
                                        <span>Customer ID:
                                    <asp:Label ID="lblDetailCustomerID" runat="server" />
                                        </span>
                                        <span>
                                            <asp:Label ID="lblDetailEmail" runat="server" />
                                        </span>
                                    </div>
                                    <div class="manager-order-detail-section">
                                        <small class="staff-detail-label">ORDER INFORMATION</small>
                                        <span>Type:
                                    <asp:Label ID="lblDetailType" runat="server" />
                                        </span>
                                        <span>Payment:
                                    <asp:Label ID="lblDetailPayment" runat="server" />
                                        </span>
                                        <span>Recorded employee ID:
                                    <asp:Label ID="lblDetailEmployeeID" runat="server" />
                                        </span>
                                    </div>
                                    <asp:Panel ID="pnlEventDetails" runat="server" Visible="false"
                                        CssClass="manager-order-detail-section">
                                        <small class="staff-detail-label">EVENT BOOKING</small>
                                        <span>Date:
                                    <asp:Label ID="lblDetailEventDate" runat="server" />
                                        </span>
                                        <span>Time:
                                    <asp:Label ID="lblDetailEventTime" runat="server" />
                                        </span>
                                    </asp:Panel>
                                    <div class="manager-order-detail-section">
                                        <small class="staff-detail-label">ORDER ITEMS</small>
                                        <asp:Repeater ID="rptOrderItems" runat="server">
                                            <itemtemplate>
                                                <div class="manager-detail-item">
                                                    <span><%#: Eval("QuantityOrdered", "{0:0.##}") %> × <%#: Eval("MenuItemName") %></span>
                                                    <strong>R<%#: Eval("SubTotal", "{0:N2}") %></strong>
                                                </div>
                                            </itemtemplate>
                                        </asp:Repeater>
                                        <asp:Label ID="lblNoOrderItems" runat="server" Visible="false"
                                            Text="No items recorded for this order." CssClass="text-muted small" />
                                    </div>
                                    <div class="manager-order-total">
                                        <span>Items subtotal</span>
                                        <strong>R<asp:Label ID="lblDetailSubtotal" runat="server" /></strong>
                                    </div>
                                    <div class="manager-order-total manager-order-grand-total">
                                        <span>Recorded order total</span>
                                        <strong>R<asp:Label ID="lblDetailTotal" runat="server" /></strong>
                                    </div>
                                    <asp:Label ID="lblAmountDifference" runat="server" Visible="false"
                                        CssClass="manager-total-note" />
                                    <%-- Printable order summary, not a tax invoice/paid receipt. --%>
                                    <button type="button" class="btn btn-outline-brand manager-print-btn"
                                        onclick="printOrderSummary()">
                                        Print Order Summary</button>
                                    <p class="manager-order-note">Status changes and payments remain in the existing checkout workflow.</p>

                                </asp:Panel>
                            </aside>
                        </div>

                        <%-- Close the AJAX UpdatePanel --%>
                    </contenttemplate>

                    <triggers>
                        <%-- Export CSV requires a full postback --%>
                        <asp:PostBackTrigger ControlID="btnExport" />
                    </triggers>

                </asp:UpdatePanel>

                <%-- No fictional Flagged Orders or Recent Activity content. --%>
                <div class="staff-footer">© 2026 Cafe101 Manager System</div>

            </main>
        </div>
    </div>

    <%-- =================================================
         PAGE-SPECIFIC CSS - NO CHANGES TO SITE.CSS
         ================================================= --%>
    <style>
        #ordersWorkspace {
            display: grid;
            grid-template-columns: minmax(0, 1fr) minmax(0, 0px);
            align-items: start;
            gap: 0;
            transition: grid-template-columns .35s ease, gap .35s ease;
        }

            #ordersWorkspace.details-open {
                grid-template-columns: minmax(0,1fr) 440px;
                gap: 18px;
            }

            #ordersWorkspace .manager-orders-table-card {
                min-width: 0;
                width: 100%;
            }

                #ordersWorkspace .manager-orders-table-card .table-responsive {
                    min-width: 0;
                    overflow-x: auto;
                }

            #ordersWorkspace .manager-orders-table {
                width: 100%;
                min-width: 760px;
            }

            #ordersWorkspace #orderDetailsPanel {
                box-sizing: border-box;
                position: sticky;
                top: 90px;
                font-size: 15px;
                line-height: 1.55;
                min-width: 0;
                width: 100% !important;
                padding: 0 !important;
                border-width: 0 !important;
                opacity: 0;
                visibility: hidden;
                pointer-events: none;
                transform: translateX(45px);
                overflow: hidden;
                transition: opacity .35s ease, transform .35s ease;
            }

            #ordersWorkspace.details-open #orderDetailsPanel {
                padding: 28px !important;
                border-width: 1px !important;
                opacity: 1;
                visibility: visible;
                pointer-events: auto;
                transform: translateX(0);
                max-height: calc(100vh - 110px);
                overflow-y: auto;
            }

        .manager-details-close {
            position: absolute;
            top: 12px;
            right: 12px;
            z-index: 10;
            width: 35px;
            height: 35px;
            border: 0;
            border-radius: 8px;
            background: #ecf0f6;
            color: #1a2d4c;
            font-size: 24px;
            line-height: 1;
            cursor: pointer;
        }

            .manager-details-close:hover {
                background: #dce6f3;
            }

        #orderDetailsPanel .manager-order-details-header {
            padding-right: 45px;
            display: flex;
            gap: 10px;
            justify-content: space-between;
            align-items: flex-start;
        }

            #orderDetailsPanel .manager-order-details-header h4 {
                font-size: 23px;
                margin: 0 0 4px;
            }

        #orderDetailsPanel .manager-order-detail-section {
            padding: 16px 0;
            border-top: 1px solid #e7ebf1;
            display: flex;
            flex-direction: column;
            gap: 10px;
        }

        #orderDetailsPanel .staff-detail-label {
            font-size: 12px;
            font-weight: 700;
            color: #738199;
            letter-spacing: .05em;
        }

        #orderDetailsPanel .manager-detail-item {
            display: flex;
            justify-content: space-between;
            align-items: start;
            gap: 12px;
            padding: 7px 0;
            font-size: 15px;
        }

            #orderDetailsPanel .manager-detail-item strong {
                white-space: nowrap;
            }

        #orderDetailsPanel .manager-order-total {
            display: flex;
            justify-content: space-between;
            padding: 12px 0;
            border-top: 1px solid #e7ebf1;
        }

        #orderDetailsPanel .manager-order-grand-total {
            font-size: 19px;
            color: #1a2d4c;
        }

        #orderDetailsPanel .manager-print-btn {
            width: 100%;
            margin-top: 16px;
        }

        #orderDetailsPanel .manager-order-note {
            font-size: 13px;
            line-height: 1.45;
            margin: 12px 0 0;
            color: #65738a;
        }

        #orderDetailsPanel .manager-total-note {
            display: block;
            margin-top: 10px;
            padding: 9px;
            background: #fff4dc;
            color: #745100;
            border-radius: 6px;
            font-size: 13px;
        }

        .manager-empty-orders {
            padding: 18px;
            color: #65738a;
        }

        .manager-pagination-controls {
            display: flex;
            align-items: center;
            gap: 12px;
        }

            .manager-pagination-controls a, .manager-pagination-controls span {
                font-size: 13px;
            }

            .manager-pagination-controls a {
                display: inline-block;
                padding: 7px 10px;
                border: 1px solid #dbe1e8;
                border-radius: 6px;
                text-decoration: none;
                color: #1a2d4c;
            }

                .manager-pagination-controls a.aspNetDisabled {
                    opacity: .4;
                    pointer-events: none;
                }

        .staff-search-box {
            min-width: 250px;
        }

        .manager-orders-toolbar-left {
            display: flex;
            align-items: center;
            gap: 9px;
            flex-wrap: wrap;
        }

        .manager-orders-toolbar-right {
            display: flex;
            align-items: center;
            gap: 8px;
        }

        .staff-icon-box.icon-red {
            background: #fbe6e8;
            color: #b4232b;
        }

        .order-status.status-declined {
            background: #fbe4e5;
            color: #a6262e;
        }
        /* Make toolbar input fonts consistent */
        .manager-date-filter .form-control,
        .staff-filter-box .form-control,
        .staff-search-box .form-control {
            font-family: inherit !important;
            font-size: 14px !important;
            font-weight: 400 !important;
            line-height: 1.45 !important;
        }

        @media (max-width:1250px) {
            #ordersWorkspace.details-open {
                grid-template-columns: minmax(0,1fr) minmax(0,400px);
                gap: 12px;
            }
        }

        @media (max-width:960px) {
            #ordersWorkspace.details-open {
                grid-template-columns: minmax(0,1fr);
            }

            #ordersWorkspace #orderDetailsPanel {
                position: fixed;
                top: 0;
                right: 0;
                bottom: 0;
                z-index: 3000;
                width: min(500px, 100vw) !important;
                max-height: 100vh !important;
                background: white;
            }

            #ordersWorkspace.details-open #orderDetailsPanel {
                padding: 26px !important;
                overflow-y: auto;
            }
        }

        @media (prefers-reduced-motion:reduce) {
            #ordersWorkspace, #ordersWorkspace #orderDetailsPanel {
                transition: none;
            }
        }
        /* ==========================================
   COMPACT ORDER DETAILS
   ========================================== */

        #ordersWorkspace #orderDetailsPanel {
            font-size: 14px !important;
            line-height: 1.5 !important;
        }

        #orderDetailsPanel .manager-order-details-header h4 {
            font-size: 21px !important;
            font-weight: 700 !important;
        }

        #orderDetailsPanel .manager-order-details-header small {
            font-size: 12px !important;
        }

        #orderDetailsPanel .manager-order-detail-section {
            padding: 14px 0 !important;
            gap: 7px !important;
        }

        #orderDetailsPanel .staff-detail-label {
            font-size: 12px !important;
            font-weight: 700 !important;
        }

        #orderDetailsPanel .manager-order-detail-section strong {
            font-size: 15px !important;
        }

        #orderDetailsPanel .manager-order-detail-section span,
        #orderDetailsPanel .manager-detail-item,
        #orderDetailsPanel .manager-detail-item span,
        #orderDetailsPanel .manager-detail-item strong {
            font-size: 13px !important;
            line-height: 1.5 !important;
        }

        #orderDetailsPanel .manager-order-total,
        #orderDetailsPanel .manager-order-total span,
        #orderDetailsPanel .manager-order-total strong {
            font-size: 14px !important;
        }

        #orderDetailsPanel .manager-order-grand-total {
            font-size: 18px !important;
        }

        #orderDetailsPanel .manager-print-btn {
            font-size: 14px !important;
            padding: 10px 14px !important;
        }

        #orderDetailsPanel .manager-order-note,
        #orderDetailsPanel .manager-total-note {
            font-size: 12px !important;
        }
        /* ==========================================
   PREVENT PAGE HORIZONTAL OVERFLOW
   ========================================== */

        .staff-main {
            min-width: 0;
            max-width: 100%;
            overflow-x: clip;
        }

        #ordersWorkspace {
            min-width: 0;
            width: 100%;
            max-width: 100%;
        }

            #ordersWorkspace .manager-orders-table-card {
                min-width: 0;
                max-width: 100%;
            }

            #ordersWorkspace .table-responsive {
                max-width: 100%;
                overflow-x: auto;
            }
    </style>


    <%-- =================================================
         MASTER LAYOUT + SLIDING PANEL
         ================================================= --%>
    <script>

        // =====================================================
        // PRINT ORDER SUMMARY
        // =====================================================
        function printOrderSummary() {

            // Get the selected order information
            const selectedOrder = document.querySelector(
                '[id$="pnlSelectedOrder"]'
            );

            if (!selectedOrder ||
                !selectedOrder.querySelector(".manager-order-details-header")) {
                alert("Please select an order first.");
                return;
            }

            // Copy the order details
            const orderCopy = selectedOrder.cloneNode(true);

            // Remove buttons and screen-only notes
            orderCopy.querySelectorAll(
                "button, .manager-print-btn, .manager-order-note, .manager-total-note"
            ).forEach(function (element) {
                element.remove();
            });

            // Remove any previous print frame
            const existingFrame = document.getElementById("orderPrintFrame");

            if (existingFrame) {
                existingFrame.remove();
            }

            // Create a separate document for printing
            const frame = document.createElement("iframe");

            frame.id = "orderPrintFrame";
            frame.style.cssText =
                "position:fixed;left:-10000px;top:0;" +
                "width:1px;height:1px;border:0;";

            const printHTML = `
            <!DOCTYPE html>
            <html>
            <head>
                <title>Cafe101 Order Summary</title>

                <style>
                    @page {
                        size: A4;
                        margin: 15mm;
                    }

                    * {
                        box-sizing: border-box;
                    }

                    body {
                        font-family: Arial, sans-serif;
                        font-size: 15px;
                        line-height: 1.6;
                        color: #1a2d4c;
                        margin: 0;
                    }

                    h1 {
                        font-size: 28px;
                        margin: 0;
                    }

                    h4 {
                        font-size: 22px;
                        margin: 0 0 6px;
                    }

                    .print-heading {
                        border-bottom: 2px solid #1a2d4c;
                        padding-bottom: 15px;
                        margin-bottom: 20px;
                    }

                    .print-heading p {
                        color: #65738a;
                        margin: 5px 0;
                    }

                    .manager-order-details-header {
                        display: flex;
                        justify-content: space-between;
                        align-items: flex-start;
                        gap: 15px;
                        margin-bottom: 20px;
                    }

                    .manager-order-detail-section {
                        display: flex;
                        flex-direction: column;
                        gap: 8px;
                        padding: 15px 0;
                        border-top: 1px solid #ddd;
                    }

                    .staff-detail-label {
                        font-size: 12px;
                        font-weight: bold;
                        color: #65738a;
                    }

                    .manager-detail-item,
                    .manager-order-total {
                        display: flex;
                        justify-content: space-between;
                        gap: 15px;
                        padding: 8px 0;
                    }

                    .manager-detail-item {
                        break-inside: avoid;
                    }

                    .manager-order-total {
                        border-top: 1px solid #ddd;
                    }

                    .manager-order-grand-total {
                        font-size: 19px;
                        font-weight: bold;
                    }

                    button {
                        display: none !important;
                    }

                    .print-footer {
                        margin-top: 25px;
                        padding-top: 10px;
                        border-top: 1px solid #ddd;
                        font-size: 12px;
                        color: #65738a;
                    }
                </style>
            </head>

            <body>

                <div class="print-heading">
                    <h1>Cafe101</h1>
                    <p>Order Summary</p>
                </div>

                ${orderCopy.innerHTML}

                <div class="print-footer">
                    Cafe101 Manager System
                    <div>Order summary only — not proof of payment.</div>
                </div>

            </body>
            </html>
        `;

            // Print after the document finishes loading
            frame.onload = function () {

                const printWindow = frame.contentWindow;

                printWindow.onafterprint = function () {
                    frame.remove();
                };

                printWindow.focus();
                printWindow.print();
            };

            frame.srcdoc = printHTML;
            document.body.appendChild(frame);
        }



        // =====================================================
        // INITIALIZE MANAGER ORDERS
        // =====================================================
        function initializeManagerOrders() {

            document.body.classList.add("staff-page");

            // Hide public navbar
            const publicNavbar = document.querySelector(".navbar");
            if (publicNavbar) publicNavbar.style.display = "none";

            // Remove default Site.Master spacing
            const bodyContent = document.querySelector(".body-content");

            if (bodyContent) {
                bodyContent.classList.remove("container");
                bodyContent.style.width = "100%";
                bodyContent.style.maxWidth = "none";
                bodyContent.style.margin = "0";
                bodyContent.style.padding = "0";
            }

            // Hide public footer
            const masterFooter = document.querySelector(".body-content > footer");
            if (masterFooter) masterFooter.style.display = "none";

            const masterFooterLine = document.querySelector(".body-content > hr");
            if (masterFooterLine) masterFooterLine.style.display = "none";

            // Sidebar toggle
            const toggle = document.getElementById("sidebarToggle");
            const staffBody = document.querySelector(".staff-body");

            if (toggle && staffBody) {
                toggle.onclick = function () {
                    staffBody.classList.toggle("sidebar-collapsed");
                };
            }

            // Sliding order details panel
            const workspace = document.getElementById("ordersWorkspace");
            const closeButton = document.getElementById("btnCloseOrderDetails");
            const selectedField = document.querySelector(
                'input[id$="hfSelectedOrderID"]'
            );

            if (!workspace || !closeButton || !selectedField) return;

            // Open or close details depending on selected order
            if (selectedField.value) {
                workspace.classList.add("details-open");
            } else {
                workspace.classList.remove("details-open");
            }

            // Close button without a postback
            closeButton.onclick = function () {
                selectedField.value = "";
                workspace.classList.remove("details-open");
            };
        }

        // Run on first load AND after AJAX updates
        Sys.Application.add_load(initializeManagerOrders);

    </script>
</asp:Content>
