<%@ page title="Manager Menu" language="C#" masterpagefile="~/Site.Master"
    autoeventwireup="true" codebehind="ManagerMenu.aspx.cs"
    inherits="Cafe101.Web.ManagerMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="staff-shell manager-shell">
        <%-- Manager header --%>
        <header class="staff-header">
            <div class="staff-header-left">
                <button type="button" id="sidebarToggle" class="staff-header-menu"
                    aria-label="Toggle manager navigation">
                    &#9776;</button>
                <div class="staff-header-brand">Cafe101</div>
            </div>
            <a href="ManagerProfile.aspx" class="staff-header-user text-decoration-none">
                <div class="staff-header-avatar">
                    <asp:Label ID="lblTopManagerInitials" runat="server" />
                </div>
                <div>
                    <strong>
                        <asp:Label ID="lblTopManagerName" runat="server" />
                    </strong>
                    <small>
                        <asp:Label ID="lblTopManagerRole" runat="server" />
                    </small>
                </div>
            </a>
        </header>

        <div class="staff-body">
            <%-- Manager navigation --%>
            <aside class="staff-sidebar">
                <div class="staff-sidebar-title">MANAGER SYSTEM</div>
                <nav class="staff-nav">


                    <a href="ManagerDashboard.aspx">

                        <span class="staff-nav-icon">&#8962;
                        </span>

                        <span class="staff-nav-text">Dashboard
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

                        <span class="staff-nav-text">Orders
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

                        <span class="staff-nav-text">Menu
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

                        <span class="staff-nav-text">Staff
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

                        <span class="staff-nav-text">Reports
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

                        <span class="staff-nav-text">Profile
                        </span>

                    </a>


                </nav>
                <div class="staff-sidebar-bottom">
                    <asp:LinkButton ID="lnkLogout" runat="server" CssClass="staff-logout"
                        OnClick="LnkLogout_Click" CausesValidation="false">
                        <span class="staff-nav-icon">&#10140;</span>
                        <span class="staff-nav-text">Logout</span>
                    </asp:LinkButton>
                </div>
            </aside>

            <main class="staff-main">
                <div class="staff-page-heading">
                    <h3>Menu Management</h3>
                    <p>View and manage Cafe101 menu items and monitor ingredient availability.</p>
                </div>

                <%-- The Site.Master already contains a ScriptManager. --%>
                <asp:UpdatePanel ID="updManagerMenu" runat="server"
                    UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <contenttemplate>
                        <asp:Label ID="lblMessage" runat="server" CssClass="d-none" />
                        <%-- Client-side open/close state, preserved by the UpdatePanel. --%>
                        <asp:HiddenField ID="hfSelectedMenuItemID" runat="server" />

                        <%-- Search and filters --%>
                        <div class="manager-menu-toolbar">
                            <div class="manager-menu-toolbar-left">
                                <div class="staff-search-box">
                                    <span class="staff-search-icon" aria-hidden="true">
                                        <svg viewBox="0 0 24 24" width="18" height="18" fill="none" stroke="currentColor" stroke-width="2">
                                            <circle cx="10" cy="10" r="6" />
                                            <path d="M15 15l5 5" />
                                        </svg></span>
                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"
                                        placeholder="Item ID, name or category..." />
                                </div>
                                <asp:Button ID="btnSearch" runat="server" Text="Search"
                                    CssClass="btn btn-brand" OnClick="BtnSearch_Click"
                                    CausesValidation="false" />
                                <asp:DropDownList ID="ddlCategory" runat="server"
                                    CssClass="form-control manager-menu-filter"
                                    AutoPostBack="true"
                                    OnSelectedIndexChanged="DdlCategory_SelectedIndexChanged" />
                                <asp:DropDownList ID="ddlStatus" runat="server"
                                    CssClass="form-control manager-menu-filter"
                                    AutoPostBack="true"
                                    OnSelectedIndexChanged="DdlStatus_SelectedIndexChanged">
                                    <asp:ListItem Text="All Statuses" Value="" />
                                    <asp:ListItem Text="Available" Value="Available" />
                                    <asp:ListItem Text="Low Stock" Value="Low Stock" />
                                    <asp:ListItem Text="Unavailable" Value="Unavailable" />
                                </asp:DropDownList>
                            </div>
                            <div class="manager-menu-toolbar-right">
                                <asp:Button ID="btnRefresh" runat="server" Text="Refresh"
                                    CssClass="btn btn-brand" OnClick="BtnRefresh_Click"
                                    CausesValidation="false" />
                                <asp:Button ID="btnAddNewItem" runat="server"
                                    Text="+ Add Item"
                                    CssClass="btn btn-brand"
                                    OnClick="BtnAddNewItem_Click"
                                    CausesValidation="false" />
                            </div>
                        </div>

                        <%-- Summary from the actual menu data --%>
                        <div class="staff-metric-grid">
                            <div class="staff-metric-card">
                                <div class="staff-icon-box icon-blue">&#9636;</div>
                                <div>
                                    <span class="staff-metric-label">TOTAL ITEMS</span>
                                    <h3>
                                        <asp:Label ID="lblTotalItems" runat="server" />
                                    </h3>
                                    <p>Menu items in database</p>
                                </div>
                            </div>
                            <div class="staff-metric-card">
                                <div class="staff-icon-box icon-beige">&#10003;</div>
                                <div>
                                    <span class="staff-metric-label">AVAILABLE</span>
                                    <h3>
                                        <asp:Label ID="lblAvailable" runat="server" />
                                    </h3>
                                    <p>Sufficient ingredient stock</p>
                                </div>
                            </div>
                            <div class="staff-metric-card">
                                <div class="staff-icon-box icon-orange">!</div>
                                <div>
                                    <span class="staff-metric-label">UNAVAILABLE</span>
                                    <h3>
                                        <asp:Label ID="lblUnavailable" runat="server" />
                                    </h3>
                                    <p>Cannot currently be prepared</p>
                                </div>
                            </div>
                            <div class="staff-metric-card">
                                <div class="staff-icon-box icon-purple">#</div>
                                <div>
                                    <span class="staff-metric-label">CATEGORIES</span>
                                    <h3>
                                        <asp:Label ID="lblCategoryCount" runat="server" />
                                    </h3>
                                    <p>Distinct menu categories</p>
                                </div>
                            </div>
                        </div>

                        <%-- Menu list and selected-item card --%>
                        <div id="menuWorkspace" class="manager-menu-workspace">
                            <section class="staff-dashboard-panel manager-menu-table-card">
                                <div class="staff-panel-heading">
                                    <div>
                                        <h5>All Menu Items</h5>
                                        <small>Live menu and ingredient stock data</small>
                                    </div>
                                </div>
                                <div class="table-responsive">
                                    <table class="table staff-orders-table manager-menu-table">
                                        <thead>
                                            <tr>
                                                <th>Item ID</th>
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
                                            <asp:Repeater ID="rptMenuItems" runat="server">
                                                <itemtemplate>
                                                    <tr>
                                                        <td><strong>#<%#: Eval("MenuItemID") %></strong></td>
                                                        <td><strong><%#: Eval("MenuItemName") %></strong></td>
                                                        <td><%#: Eval("Category") %></td>
                                                        <td>R<%#: Eval("SellingPrice", "{0:N2}") %></td>
                                                        <td><%#: Eval("AvailableQuantity") %></td>
                                                        <td><%#: Eval("PreparationTime") %> min</td>
                                                        <td><span class='<%# GetStatusCssClass(Convert.ToString(Eval("StockStatus"))) %>'>
                                                            <%#: Eval("StockStatus") %></span></td>
                                                        <td>
                                                            <asp:LinkButton ID="btnSelectItem" runat="server"
                                                                Text="View" CssClass="btn btn-sm btn-outline-brand"
                                                                CommandArgument='<%# Eval("MenuItemID") %>'
                                                                OnCommand="SelectMenuItem_Command"
                                                                CausesValidation="false" />
                                                        </td>
                                                    </tr>
                                                </itemtemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                                <asp:Panel ID="pnlNoMenuItems" runat="server" Visible="false"
                                    CssClass="manager-menu-empty">
                                    No menu items match your current search or filters.
                                </asp:Panel>
                                <div class="manager-orders-pagination manager-menu-pagination">
                                    <div class="manager-pagination-controls">
                                        <asp:LinkButton ID="lnkPreviousMenu" runat="server"
                                            Text="Previous" OnClick="PreviousMenu_Click"
                                            CausesValidation="false" />
                                        <asp:Label ID="lblMenuPage" runat="server" />
                                        <asp:LinkButton ID="lnkNextMenu" runat="server"
                                            Text="Next" OnClick="NextMenu_Click"
                                            CausesValidation="false" />
                                    </div>
                                    <small>
                                        <asp:Label ID="lblShowingItems" runat="server" />
                                    </small>
                                </div>
                            </section>

                            <aside id="menuDetailsPanel"
                                class="staff-dashboard-panel manager-selected-item"
                                aria-label="Selected menu item details">
                                <button type="button" id="btnCloseMenuDetails"
                                    class="manager-details-close" aria-label="Close item details"
                                    title="Close details">
                                    &times;</button>

                                <asp:Panel ID="pnlSelectedItem" runat="server" Visible="false">
                                    <asp:Panel ID="pnlViewItem" runat="server">
                                        <div class="manager-selected-item-heading">
                                            <h5>Selected Item</h5>
                                        </div>
                                        <div class="manager-selected-product">
                                            <div class="manager-selected-product-image">
                                                <asp:Label ID="lblSelectedEmoji" runat="server" />
                                            </div>
                                            <div class="manager-menu-selected-title">
                                                <h4>
                                                    <asp:Label ID="lblSelectedName" runat="server" />
                                                </h4>
                                                <small>Item ID: #<asp:Label ID="lblSelectedItemID" runat="server" /></small>
                                                <div class="manager-menu-selected-status">
                                                    <asp:Label ID="lblSelectedStatus" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="manager-selected-info">
                                            <div class="manager-selected-info-row">
                                                <span>Category</span>
                                                <strong>
                                                    <asp:Label ID="lblSelectedCategory" runat="server" />
                                                </strong>
                                            </div>
                                            <div class="manager-selected-info-row">
                                                <span>Selling Price</span>
                                                <strong>
                                                    <asp:Label ID="lblSelectedPrice" runat="server" />
                                                </strong>
                                            </div>
                                            <div class="manager-selected-info-row">
                                                <span>Cost To Make</span>
                                                <strong>
                                                    <asp:Label ID="lblSelectedCost" runat="server" />
                                                </strong>
                                            </div>
                                            <div class="manager-selected-info-row">
                                                <span>Preparation Time</span>
                                                <strong>
                                                    <asp:Label ID="lblSelectedPreparation" runat="server" />
                                                </strong>
                                            </div>
                                            <div class="manager-selected-info-row">
                                                <span>Can Make</span>
                                                <strong>
                                                    <asp:Label ID="lblSelectedQuantity" runat="server" />
                                                </strong>
                                            </div>
                                        </div>

                                        <%-- RECIPE INGREDIENTS --%>
                                        <div class="manager-menu-recipe-section">

                                            <h5>Recipe Ingredients</h5>

                                            <asp:Repeater ID="rptSelectedRecipe" runat="server">
                                                <itemtemplate>

                                                    <div class="manager-selected-info-row">
                                                        <span>
                                                            <%#: Eval("IngredientName") %>
                                                        </span>

                                                        <strong>
                                                            <%#: Eval("QuantityNeeded") %> needed
                    <small style="display: block; font-weight: 400;">
                        <%#: Eval("QuantityOnHand") %> in stock
                    </small>
                                                        </strong>
                                                    </div>

                                                </itemtemplate>
                                            </asp:Repeater>

                                            <asp:Label ID="lblRecipeEmpty"
                                                runat="server"
                                                Visible="false"
                                                Text="No ingredients assigned to this item."
                                                CssClass="text-muted" />

                                        </div>


                                        <%-- Editing an existing SQL menu record --%>
                                        <div class="manager-selected-actions">

                                            <asp:Button ID="btnEditSelected" runat="server"
                                                Text="Edit Item"
                                                CssClass="manager-selected-action btn btn-brand"
                                                OnClick="BtnEditSelected_Click"
                                                CausesValidation="false" />

                                            <asp:Button ID="btnDeleteSelected" runat="server"
                                                Text="Delete Item"
                                                CssClass="manager-selected-action manager-selected-action-red"
                                                OnClick="BtnDeleteSelected_Click"
                                                CausesValidation="false"
                                                OnClientClick="return confirm('Delete this menu item? This cannot be undone.');" />

                                            <asp:Button ID="Button1" runat="server"
                                                Text="Manage Recipe"
                                                CssClass="manager-selected-action btn btn-outline-brand manager-recipe-button"
                                                OnClick="BtnManageRecipe_Click"
                                                CausesValidation="false" />

                                        </div>

                                    </asp:Panel>

                                    <asp:Panel ID="pnlEditItem" runat="server" Visible="false"
                                        CssClass="manager-menu-edit-form">
                                        <h5>Edit Menu Item</h5>
                                        <div class="row g-3">
                                            <div class="col-12">
                                                <label class="form-label">Item Name</label>
                                                <asp:TextBox ID="txtEditName" runat="server"
                                                    CssClass="form-control" MaxLength="100" />
                                            </div>
                                            <div class="col-md-6">
                                                <label class="form-label">Selling Price (R)</label>
                                                <asp:TextBox ID="txtEditPrice" runat="server" CssClass="form-control" />
                                            </div>
                                            <div class="col-md-6">
                                                <label class="form-label">Cost To Make (R)</label>
                                                <asp:TextBox ID="txtEditCost" runat="server" CssClass="form-control" />
                                            </div>
                                            <div class="col-12">
                                                <label class="form-label">Category</label>
                                                <asp:TextBox ID="txtEditCategory" runat="server"
                                                    CssClass="form-control" MaxLength="100" />
                                            </div>
                                            <div class="col-12">
                                                <label class="form-label">Preparation Time (minutes)</label>
                                                <asp:TextBox ID="txtEditPreparation" runat="server" CssClass="form-control" />
                                            </div>
                                        </div>
                                        <div class="d-flex gap-2 mt-3">
                                            <asp:Button ID="btnSaveEdit" runat="server" Text="Save Changes"
                                                CssClass="btn btn-brand" OnClick="BtnSaveEdit_Click"
                                                CausesValidation="false" />
                                            <asp:Button ID="btnCancelEdit" runat="server" Text="Cancel"
                                                CssClass="btn btn-outline-brand" OnClick="BtnCancelEdit_Click"
                                                CausesValidation="false" />
                                        </div>
                                    </asp:Panel>

                                    <%-- MANAGE RECIPE --%>
                                    <asp:Panel ID="pnlManageRecipe" runat="server"
                                        Visible="false"
                                        CssClass="manager-menu-edit-form">

                                        <h5>Manage Recipe</h5>

                                        <p class="text-muted" style="font-size: 13px;">
                                            Select an ingredient and enter the quantity required
                                             to prepare one menu item.
                                        </p>

                                        <div class="mb-3">
                                            <label class="form-label">Ingredient</label>

                                            <asp:DropDownList ID="ddlRecipeIngredient"
                                                runat="server"
                                                CssClass="form-control" />
                                        </div>

                                        <div class="mb-3">
                                            <label class="form-label">Quantity Needed</label>

                                            <asp:TextBox ID="txtRecipeQuantity"
                                                runat="server"
                                                TextMode="Number"
                                                CssClass="form-control"
                                                min="1" />
                                        </div>

                                        <div class="d-flex gap-2 mt-3">
                                            <asp:Button ID="btnCancelRecipe"
                                                runat="server"
                                                Text="Back to Item"
                                                CssClass="btn btn-outline-brand w-100"
                                                OnClick="BtnCancelRecipe_Click"
                                                CausesValidation="false" />
                                        </div>

                                    </asp:Panel>

                                </asp:Panel>
                                <%-- ADD NEW MENU ITEM --%>
                                <asp:Panel ID="pnlAddItem" runat="server"
                                    Visible="false"
                                    CssClass="manager-menu-edit-form">

                                    <h5>Add New Menu Item</h5>

                                    <div class="row g-3">

                                        <div class="col-12">
                                            <label class="form-label">Item Name</label>
                                            <asp:TextBox ID="txtNewName" runat="server"
                                                CssClass="form-control" MaxLength="100" />
                                        </div>

                                        <div class="col-md-6">
                                            <label class="form-label">Selling Price (R)</label>
                                            <asp:TextBox ID="txtNewPrice" runat="server"
                                                CssClass="form-control" />
                                        </div>

                                        <div class="col-md-6">
                                            <label class="form-label">Cost To Make (R)</label>
                                            <asp:TextBox ID="txtNewCost" runat="server"
                                                CssClass="form-control" />
                                        </div>

                                        <div class="col-12">
                                            <label class="form-label">Category</label>
                                            <asp:TextBox ID="txtNewCategory" runat="server"
                                                CssClass="form-control" MaxLength="100" />
                                        </div>

                                        <div class="col-12">
                                            <label class="form-label">Preparation Time (minutes)</label>
                                            <asp:TextBox ID="txtNewPreparation" runat="server"
                                                CssClass="form-control" />
                                        </div>

                                    </div>

                                    <div class="d-flex gap-2 mt-3">
                                        <asp:Button ID="btnSaveNew" runat="server"
                                            Text="Add Menu Item"
                                            CssClass="btn btn-brand"
                                            OnClick="BtnSaveNew_Click"
                                            CausesValidation="false" />

                                        <asp:Button ID="btnCancelNew" runat="server"
                                            Text="Cancel"
                                            CssClass="btn btn-outline-brand"
                                            OnClick="BtnCancelNew_Click"
                                            CausesValidation="false" />
                                    </div>

                                </asp:Panel>
                            </aside>
                        </div>

                        <%-- Other live-data summaries --%>
                        <div class="manager-menu-bottom-grid">
                            <section class="staff-dashboard-panel">
                                <div class="staff-panel-heading">
                                    <div>
                                        <h5>Low Stock Items</h5>
                                        <small>Items affected by ingredients at or below restock level</small>
                                    </div>
                                </div>
                                <div class="manager-low-stock-grid">
                                    <asp:Repeater ID="rptLowStock" runat="server">
                                        <itemtemplate>
                                            <div class="manager-low-stock-card">
                                                <div>
                                                    <strong><%#: Eval("MenuItemName") %></strong>
                                                    <small><%#: Eval("AvailableQuantity") %> can currently be made</small>
                                                </div>
                                                <span class="manager-menu-status status-low-stock">Low Stock</span>
                                            </div>
                                        </itemtemplate>
                                    </asp:Repeater>
                                    <asp:Label ID="lblNoLowStock" runat="server" Visible="false"
                                        Text="No menu items are currently classified as low stock."
                                        CssClass="manager-menu-muted" />
                                </div>
                            </section>
                            <section class="staff-dashboard-panel">
                                <div class="staff-panel-heading">
                                    <div>
                                        <h5>Category Summary</h5>
                                        <small>Live menu item totals by category</small>
                                    </div>
                                </div>
                                <div class="manager-category-summary">
                                    <asp:Repeater ID="rptCategories" runat="server">
                                        <itemtemplate>
                                            <div class="manager-category-row">
                                                <span><%#: Eval("Category") %></span>
                                                <strong><%#: Eval("ItemCount") %> items</strong>
                                            </div>
                                        </itemtemplate>
                                    </asp:Repeater>
                                </div>
                            </section>
                        </div>
                    </contenttemplate>
                </asp:UpdatePanel>

                <div class="staff-footer">© 2026 Cafe101 Manager System</div>
            </main>
        </div>
    </div>

    <%-- Page-specific styles: keep site.css unchanged. --%>
    <%-- Menu-specific styling, matched to Manager Orders. --%>
    <style>
        #menuWorkspace {
            display: grid;
            grid-template-columns: minmax(0, 1fr) minmax(0, 0px);
            gap: 0;
            align-items: start;
            transition: grid-template-columns .35s ease, gap .35s ease;
        }

            #menuWorkspace.details-open {
                grid-template-columns: minmax(0, 1fr) minmax(0, 560px);
                gap: 18px;
            }

            #menuWorkspace .manager-menu-table-card {
                min-width: 0;
                width: 100%;
            }

            #menuWorkspace .table-responsive {
                min-width: 0;
                overflow-x: auto;
            }

            #menuWorkspace .manager-menu-table {
                width: 100%;
                min-width: 760px;
            }

                #menuWorkspace .manager-menu-table th,
                #menuWorkspace .manager-menu-table td {
                    font-family: inherit;
                    font-size: 14px;
                    vertical-align: middle;
                }

                    #menuWorkspace .manager-menu-table td:nth-child(2) {
                        min-width: 130px;
                    }

                #menuWorkspace .manager-menu-table .btn {
                    font-size: 13px;
                }

            #menuWorkspace #menuDetailsPanel {
                box-sizing: border-box;
                position: sticky;
                top: 90px;
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

            #menuWorkspace.details-open #menuDetailsPanel {
                padding: 28px !important;
                border-width: 1px !important;
                opacity: 1;
                visibility: visible;
                pointer-events: auto;
                transform: translateX(0);
                max-height: calc(100vh - 110px);
                overflow-y: auto;
            }

        #menuDetailsPanel .manager-details-close {
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

            #menuDetailsPanel .manager-details-close:hover {
                background: #dce6f3;
            }

        #menuDetailsPanel {
            font-size: 15px;
            line-height: 1.55;
        }

            #menuDetailsPanel .manager-selected-item-heading {
                padding-right: 45px;
            }

                #menuDetailsPanel .manager-selected-item-heading h5 {
                    font-size: 20px;
                    margin-bottom: 16px;
                }

            #menuDetailsPanel .manager-selected-product h4 {
                font-size: 23px;
                margin-bottom: 4px;
            }

            #menuDetailsPanel .manager-menu-selected-title small {
                font-size: 13px;
                color: #65738a;
            }

            #menuDetailsPanel .manager-menu-selected-status {
                margin-top: 8px;
            }

            #menuDetailsPanel .manager-menu-status {
                font-family: inherit;
                font-size: 13px !important;
                font-weight: 600;
            }

            #menuDetailsPanel .manager-selected-info {
                margin-top: 18px;
            }

            #menuDetailsPanel .manager-selected-info-row {
                font-size: 15px;
                padding: 11px 0;
                gap: 12px;
            }

                #menuDetailsPanel .manager-selected-info-row > span {
                    color: #65738a;
                }

                #menuDetailsPanel .manager-selected-info-row > strong {
                    font-size: 15px;
                    text-align: right;
                    overflow-wrap: anywhere;
                }

            #menuDetailsPanel .manager-selected-actions {
                display: flex;
                gap: 10px;
                flex-wrap: wrap;
                margin-top: 18px;
            }

                #menuDetailsPanel .manager-selected-actions input {
                    font-size: 15px;
                    padding: 10px 14px;
                }

            #menuDetailsPanel .manager-menu-edit-form {
                padding: 2px 0;
                margin-top: 10px;
            }

                #menuDetailsPanel .manager-menu-edit-form h5 {
                    font-size: 23px;
                    margin-bottom: 20px;
                    padding-right: 45px;
                }

                #menuDetailsPanel .manager-menu-edit-form .form-label {
                    font-size: 14px;
                    font-weight: 600;
                }

                #menuDetailsPanel .manager-menu-edit-form .form-control {
                    font-size: 15px;
                }

                #menuDetailsPanel .manager-menu-edit-form .btn {
                    font-size: 15px;
                    padding: 10px 14px;
                }

        .manager-menu-table .manager-menu-status {
            font-family: inherit;
            font-size: 13px !important;
            font-weight: 600;
        }

        /* Exact Orders-style toolbar, with Search immediately after input. */
        .manager-menu-toolbar-left {
            display: flex;
            align-items: center;
            gap: 9px;
            flex-wrap: wrap;
        }

        .manager-menu-toolbar-right {
            display: flex;
            align-items: center;
            gap: 8px;
        }

        .manager-menu-toolbar .staff-search-box {
            min-width: 250px;
        }

            .manager-menu-toolbar .staff-search-box .form-control,
            .manager-menu-toolbar .manager-menu-filter {
                font-family: inherit !important;
                font-size: 14px !important;
                font-weight: 400 !important;
                line-height: 1.45 !important;
            }

        .manager-menu-toolbar .btn {
            font-family: inherit;
            font-size: 14px;
        }

        /* Same dark navy pagination as Orders; no default blue links. */
        .manager-menu-pagination .manager-pagination-controls {
            display: flex;
            align-items: center;
            gap: 12px;
        }

            .manager-menu-pagination .manager-pagination-controls a,
            .manager-menu-pagination .manager-pagination-controls span {
                font-family: inherit;
                font-size: 13px;
            }

            .manager-menu-pagination .manager-pagination-controls a {
                display: inline-block;
                padding: 7px 10px;
                border: 1px solid #dbe1e8;
                border-radius: 6px;
                text-decoration: none;
                color: #1a2d4c !important;
            }

                .manager-menu-pagination .manager-pagination-controls a:hover {
                    background: #eef2f7;
                }

                .manager-menu-pagination .manager-pagination-controls a.aspNetDisabled {
                    opacity: .4;
                    pointer-events: none;
                }

        .manager-menu-pagination small {
            font-size: 13px;
        }

        .manager-menu-empty {
            padding: 18px;
            color: #65738a;
        }

        /* Make the category totals easier to read. */
        .manager-category-summary .manager-category-row {
            padding: 15px 18px;
            font-size: 15px;
        }

            .manager-category-summary .manager-category-row span {
                font-size: 15px;
            }

            .manager-category-summary .manager-category-row strong {
                font-size: 16px;
                font-weight: 700;
            }

        .manager-menu-bottom-grid .staff-panel-heading h5 {
            font-size: 17px;
        }

        .manager-low-stock-card {
            font-size: 14px;
        }

        @media (max-width: 1250px) {
            #menuWorkspace.details-open {
                grid-template-columns: minmax(0, 1fr) minmax(0, 460px);
                gap: 12px;
            }
        }

        @media (max-width: 960px) {
            #menuWorkspace.details-open {
                grid-template-columns: minmax(0, 1fr);
            }

            #menuWorkspace #menuDetailsPanel {
                position: fixed;
                top: 0;
                right: 0;
                bottom: 0;
                z-index: 3000;
                width: min(500px, 100vw) !important;
                max-height: 100vh !important;
                background: #fff;
            }

            #menuWorkspace.details-open #menuDetailsPanel {
                padding: 26px !important;
                overflow-y: auto;
            }
        }

        @media (prefers-reduced-motion: reduce) {
            #menuWorkspace, #menuWorkspace #menuDetailsPanel {
                transition: none;
            }
        }
        /* Smaller selected item slide */
        #menuWorkspace.details-open {
            grid-template-columns: minmax(0, 1fr) minmax(0, 420px);
            gap: 14px;
        }

            #menuWorkspace.details-open #menuDetailsPanel {
                padding: 20px !important;
            }

        /* Smaller screens */
        @media (max-width: 1250px) and (min-width: 961px) {
            #menuWorkspace.details-open {
                grid-template-columns: minmax(0, 1fr) minmax(0, 380px);
            }
        }

        /* Mobile */
        @media (max-width: 960px) {
            #menuWorkspace.details-open {
                grid-template-columns: minmax(0, 1fr);
            }

            #menuWorkspace #menuDetailsPanel {
                width: min(420px, 100vw) !important;
            }

            #menuWorkspace.details-open #menuDetailsPanel {
                padding: 20px !important;
            }
        }
        /* Selected Item card - slightly smaller fonts */
        #menuDetailsPanel {
            font-size: 14px;
        }

            #menuDetailsPanel .manager-selected-item-heading h5 {
                font-size: 18px;
            }

            #menuDetailsPanel .manager-selected-product h4 {
                font-size: 20px;
            }

            #menuDetailsPanel .manager-selected-info-row,
            #menuDetailsPanel .manager-selected-info-row > strong {
                font-size: 14px;
            }

            #menuDetailsPanel .manager-menu-status {
                font-size: 12px !important;
            }

            /* Center Edit and Delete buttons */
            #menuDetailsPanel .manager-selected-actions {
                display: flex;
                justify-content: center;
                align-items: center;
                gap: 10px;
            }

                #menuDetailsPanel .manager-selected-actions input {
                    width: auto !important;
                    flex: 0 0 auto;
                    font-size: 13px;
                    padding: 9px 16px;
                }

            /* Center Save Changes and Cancel buttons */
            #menuDetailsPanel .manager-menu-edit-form .d-flex {
                justify-content: center;
            }

            #menuDetailsPanel .manager-menu-edit-form .btn {
                font-size: 13px;
                padding: 9px 16px;
            }
            /* Edit and Delete buttons - equal width */
            #menuDetailsPanel .manager-selected-actions {
                display: flex;
                justify-content: center;
                gap: 10px;
                width: 100%;
            }

                #menuDetailsPanel .manager-selected-actions input {
                    flex: 1 1 0;
                    width: 50% !important;
                    min-width: 0;
                    padding: 10px 8px;
                    font-size: 13px;
                    text-align: center;
                }

            /* Save and Cancel - equal full widths */
            #menuDetailsPanel .manager-menu-edit-form .d-flex {
                display: flex;
                width: 100%;
                gap: 10px;
                justify-content: stretch;
            }

            #menuDetailsPanel .manager-menu-edit-form .btn {
                flex: 1 1 0;
                width: 0 !important;
                min-width: 0;
                font-size: 13px;
                padding: 10px 8px;
                text-align: center;
            }
            /* Smaller Edit Menu Item heading */
            #menuDetailsPanel .manager-menu-edit-form h5 {
                font-size: 15px !important;
                font-weight: 600;
                margin-bottom: 14px;
            }
            /* Recipe ingredients */
            #menuDetailsPanel .manager-menu-recipe-section {
                margin-top: 18px;
                padding-top: 14px;
                border-top: 1px solid #e7ebf1;
            }

                #menuDetailsPanel .manager-menu-recipe-section h5 {
                    font-size: 15px;
                    font-weight: 600;
                    margin-bottom: 12px;
                }

                #menuDetailsPanel .manager-menu-recipe-section .manager-selected-info-row {
                    font-size: 13px;
                    padding: 9px 0;
                }
            /* Consistent selected item buttons */
            #menuDetailsPanel .manager-selected-actions {
                display: grid !important;
                grid-template-columns: repeat(2, minmax(0, 1fr));
                gap: 10px;
                width: 100%;
                margin-top: 18px;
            }

                #menuDetailsPanel .manager-selected-actions input {
                    width: 100% !important;
                    min-width: 0;
                    margin: 0 !important;
                    padding: 10px 12px;
                    font-size: 13px;
                    text-align: center;
                }

            /* Manage Recipe uses the full second row */
            #menuDetailsPanel .manager-recipe-button {
                grid-column: 1 / -1;
            }

        /* Keep bottom summary panels from jumping */
        @media (min-width: 961px) {
            #menuWorkspace {
                min-height: 550px;
            }

                #menuWorkspace.details-open #menuDetailsPanel {
                    max-height: 520px !important;
                    overflow-y: auto !important;
                }
        }
        /* Selected Item action buttons */
        #menuDetailsPanel .manager-selected-actions {
            display: grid !important;
            grid-template-columns: repeat(2, minmax(0, 1fr));
            gap: 10px;
            width: 100%;
        }

            #menuDetailsPanel .manager-selected-actions input {
                width: 100% !important;
                min-width: 0;
                margin: 0 !important;
                font-size: 13px;
                padding: 10px;
                opacity: 1;
            }

        #menuDetailsPanel .manager-recipe-button {
            grid-column: 1 / -1;
        }
    </style>

    <script>
        // Re-run after partial UpdatePanel postbacks; onclick assignments avoid duplicates.
        function initializeManagerMenu() {
            document.body.classList.add("staff-page");
            var publicNavbar = document.querySelector(".navbar");
            if (publicNavbar) publicNavbar.style.display = "none";
            var bodyContent = document.querySelector(".body-content");
            if (bodyContent) {
                bodyContent.classList.remove("container");
                bodyContent.style.width = "100%";
                bodyContent.style.maxWidth = "none";
                bodyContent.style.margin = "0";
                bodyContent.style.padding = "0";
            }
            var footer = document.querySelector(".body-content > footer");
            if (footer) footer.style.display = "none";
            var footerLine = document.querySelector(".body-content > hr");
            if (footerLine) footerLine.style.display = "none";
            var toggle = document.getElementById("sidebarToggle");
            var body = document.querySelector(".staff-body");
            if (toggle && body) {
                toggle.onclick = function () {
                    body.classList.toggle("sidebar-collapsed");
                };
            }
            var workspace = document.getElementById("menuWorkspace");
            var close = document.getElementById("btnCloseMenuDetails");
            var selected = document.querySelector('input[id$="hfSelectedMenuItemID"]');
            if (!workspace || !close || !selected) return;
            if (selected.value) workspace.classList.add("details-open");
            else workspace.classList.remove("details-open");
            close.onclick = function () {
                selected.value = "";
                workspace.classList.remove("details-open");
            };
        }
        if (window.Sys && Sys.Application) {
            Sys.Application.add_load(initializeManagerMenu);
        } else {
            document.addEventListener("DOMContentLoaded", initializeManagerMenu);
        }
    </script>
</asp:Content>
