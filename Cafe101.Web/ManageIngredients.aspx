<%@ Page Title="Manage Ingredients"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ManageIngredients.aspx.cs"
    Inherits="Cafe101.Web.ManageIngredients" %>

<asp:Content ID="BodyContent"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <style>
        /* This manager page uses its own signed-in navigation. */
        #mainNavbar {
            display: none !important;
        }

        body {
            padding-top: 0;
        }

        .body-content {
            width: 100%;
            max-width: none;
            margin: 0;
            padding: 0;
        }

        .ingredient-manager-header {
            display: flex;
            align-items: center;
            justify-content: space-between;
            flex-wrap: wrap;
            gap: 16px;
            min-height: 72px;
            padding: 14px 24px;
            background: var(--brand-navy);
            color: #fff;
        }

        .ingredient-manager-brand {
            color: #fff;
            font-size: 1.25rem;
            font-weight: 700;
            text-decoration: none;
        }

        .ingredient-manager-user {
            display: flex;
            align-items: center;
            gap: 10px;
            color: #fff;
            text-decoration: none;
        }

        .ingredient-manager-brand:hover,
        .ingredient-manager-user:hover {
            color: #fff;
        }

        .ingredient-manager-avatar {
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

        .ingredient-manager-user strong,
        .ingredient-manager-user small {
            display: block;
        }

        .ingredient-manager-user small {
            opacity: 0.85;
        }

        .ingredient-manager-nav {
            display: flex;
            gap: 6px;
            padding: 10px 24px;
            overflow-x: auto;
            background: #fff;
            border-bottom: 1px solid #e1e6ec;
        }

        .ingredient-manager-nav a {
            padding: 9px 13px;
            border-radius: 7px;
            color: var(--brand-navy);
            font-weight: 600;
            white-space: nowrap;
            text-decoration: none;
        }

        .ingredient-manager-nav a:hover {
            background: #eef2f7;
        }

        .ingredient-manager-nav a.active {
            background: var(--brand-navy);
            color: #fff;
        }

        .management-page {
            max-width: 1320px;
            margin: 0 auto;
            padding: 30px 20px 50px;
        }

        .management-title {
            color: var(--brand-navy);
            font-weight: 700;
        }

        .management-card {
            background: #fff;
            border: 1px solid #e1e6ec;
            border-radius: 14px;
            padding: 22px;
            box-shadow: 0 4px 16px rgba(0, 0, 0, 0.05);
        }

        .management-table {
            min-width: 680px;
        }

        .management-table th {
            background: var(--brand-navy);
            color: white;
            font-weight: 600;
            white-space: nowrap;
        }

        .management-table td {
            vertical-align: middle;
        }

        .management-table td a {
            display: inline-block;
            padding: 6px 12px;
            border: 1px solid var(--brand-navy);
            border-radius: 6px;
            color: var(--brand-navy);
            text-decoration: none;
        }

        .management-table td a:hover {
            background: var(--brand-navy);
            color: #fff;
        }

        /* Remove the site template's default textbox width limit. */
        .management-page .form-control {
            max-width: none;
        }

        .management-search {
            max-width: 600px;
        }

        .management-actions {
            display: flex;
            flex-wrap: wrap;
            gap: 10px;
        }

        .management-actions .btn {
            min-width: 110px;
        }

        .ingredient-manager-header a:focus-visible,
        .ingredient-manager-nav a:focus-visible {
            outline: 3px solid #d4a53a;
            outline-offset: 3px;
        }

        @media (max-width: 575.98px) {
            .management-card {
                padding: 16px;
            }

            .management-actions .btn {
                flex: 1 1 140px;
            }
        }

        /* Keep the signed-in manager header visible above the sidebar. */
            .ingredient-manager-header {
                position: sticky;
                top: 0;
                z-index: 1030;
                height: 72px;
                min-height: 72px;
                flex-wrap: nowrap;
            }

            /* The ingredient navigation now occupies the left side. */
            #managerPageNav {
                position: fixed;
                top: 72px;
                bottom: 0;
                left: 0;
                z-index: 1020;
                display: flex;
                flex-direction: column;
                gap: 6px;
                width: 225px;
                padding: 24px 14px;
                overflow-y: auto;
                background: var(--brand-navy);
            }

            #managerPageNav a {
                display: flex;
                align-items: center;
                gap: 12px;
                padding: 13px 15px;
                border-radius: 8px;
                color: #fff;
                text-decoration: none;
            }

            #managerPageNav a:hover,
            #managerPageNav a.active {
                background: rgba(255, 255, 255, 0.16);
                color: #fff;
            }

            #managerPageNav .staff-nav-icon {
                display: inline-flex;
                align-items: center;
                justify-content: center;
                width: 22px;
                flex: 0 0 22px;
            }

            #managerPageNav svg {
                display: block;
                flex-shrink: 0;
            }

            /* Leave room for the sidebar instead of centring across the full screen. */
            .management-page {
                width: auto;
                max-width: none;
                min-height: calc(100vh - 72px);
                margin: 0 0 0 225px;
                padding: 30px;
                background: #f6f7f9;
            }

            .body-content > footer,
            .body-content > hr {
                display: none;
            }

            /* Keep navigation available as icons on smaller screens. */
            @media (max-width: 900px) {
                #managerPageNav {
                    width: 78px;
                    padding: 24px 8px;
                }

                #managerPageNav .staff-nav-text {
                    display: none;
                }

                #managerPageNav a {
                    justify-content: center;
                    padding: 13px 8px;
                }

                .management-page {
                    margin-left: 78px;
                    padding: 20px 14px;
                }
            }

    </style>

    <!-- Name and initials come from the signed-in manager's session. -->
    <header class="ingredient-manager-header">

        <a href="ManagerDashboard.aspx" class="ingredient-manager-brand">
            Cafe101
        </a>

        <a href="ManagerProfile.aspx" class="ingredient-manager-user">
            <span class="ingredient-manager-avatar">
                <%: ManagerInitials %>
            </span>

            <span>
                <strong><%: ManagerDisplayName %></strong>
                <small>Manager</small>
            </span>
        </a>

    </header>

 <!-- Manager navigation stays available while moving between pages. -->
<nav id="managerPageNav"
    class="staff-nav"
    aria-label="Manager navigation">

    <a href="ManagerDashboard.aspx" aria-label="Dashboard">
        <span class="staff-nav-icon" aria-hidden="true">
            <svg viewBox="0 0 24 24" width="19" height="19"
                fill="none" stroke="currentColor" stroke-width="2">
                <path d="M3 10l9-7 9 7M5 9v12h14V9M9 21v-8h6v8" />
            </svg>
        </span>
        <span class="staff-nav-text">Dashboard</span>
    </a>

    <a href="ManagerOrders.aspx" aria-label="Orders">
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

    <!-- Highlight Ingredients because this is the current page. -->
    <a href="ManageIngredients.aspx"
        class="active"
        aria-current="page"
        aria-label="Ingredients">
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
                <circle cx="9" cy="8" r="3" />
                <circle cx="17" cy="10" r="2" />
                <path d="M3 20c0-4 2.5-7 6-7s6 3 6 7M15 15c3 0 5 2 5 5" />
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
                <circle cx="12" cy="8" r="4" />
                <path d="M4 21c0-4 3.5-7 8-7s8 3 8 7" />
            </svg>
        </span>
        <span class="staff-nav-text">Profile</span>
    </a>

</nav>
    <div class="management-page">

        <div class="d-flex flex-wrap justify-content-between
                    align-items-center gap-3 mb-4">
            <div>
                <h1 class="h3 management-title mb-1">Manage Ingredients</h1>
                <p class="text-muted mb-0">
                    View and maintain ingredient stock and prices.
                </p>
            </div>

            <a href="ManagerDashboard.aspx" class="btn btn-outline-secondary">
                Back to dashboard
            </a>
        </div>

        <!-- Search filters the ingredient list. -->
        <div class="management-card mb-4">

            <asp:Label ID="lblSearch" runat="server"
                AssociatedControlID="txtIngredientSearch"
                CssClass="form-label fw-semibold"
                Text="Search ingredients" />

            <asp:Panel ID="pnlIngredientSearch" runat="server"
                DefaultButton="btnIngredientSearch">

                <div class="input-group management-search">

                    <asp:TextBox ID="txtIngredientSearch" runat="server"
                        CssClass="form-control" MaxLength="200"
                        placeholder="Search by ingredient name" />

                    <asp:Button ID="btnIngredientSearch" runat="server"
                        Text="Search" CssClass="btn btn-brand"
                        CausesValidation="false"
                        OnClick="btnIngredientSearch_Click" />

                    <asp:Button ID="btnClearSearch" runat="server"
                        Text="Clear" CssClass="btn btn-outline-secondary"
                        CausesValidation="false"
                        OnClick="btnClearSearch_Click" />

                </div>
            </asp:Panel>

        </div>

        <!-- Selecting a record fills the details form below. -->
        <div class="management-card mb-4">

            <h2 class="h5 fw-bold mb-3">Ingredient List</h2>

            <asp:Label ID="lblIngredientMessage" runat="server"
                CssClass="d-block mb-3"
                role="status" aria-live="polite" />

            <div class="table-responsive">

                <asp:GridView ID="gvIngredients" runat="server"
                    AutoGenerateColumns="false"
                    DataKeyNames="IngredientID"
                    CssClass="table table-hover align-middle management-table"
                    GridLines="None"
                    EmptyDataText="No ingredients match your search."
                    OnSelectedIndexChanged="gvIngredients_SelectedIndexChanged">

                    <Columns>
                        <asp:BoundField DataField="IngredientID"
                            HeaderText="ID" />

                        <asp:BoundField DataField="Description"
                            HeaderText="Description" />

                        <asp:BoundField DataField="QuantityOnHand"
                            HeaderText="Quantity in stock" />

                        <asp:BoundField DataField="RestockLevel"
                            HeaderText="Restock level" />

                        <asp:BoundField DataField="CostPrice"
                            HeaderText="Cost price (R)"
                            DataFormatString="{0:N2}" />

                        <asp:CommandField HeaderText="Action"
                            ShowSelectButton="true"
                            SelectText="Select"
                            CausesValidation="false" />
                    </Columns>

                    <SelectedRowStyle BackColor="#e9eff7" />
                </asp:GridView>

            </div>
        </div>

        <!-- These server controls match the fields used in ClearForm(). -->
        <div class="management-card">

            <h2 class="h5 fw-bold mb-2">Ingredient Details</h2>

            <asp:Label ID="lblSelectedIngredient" runat="server"
                Text="New ingredient"
                CssClass="d-block text-muted mb-3" />

            <div class="row g-3">

                <div class="col-md-6">
                    <asp:Label ID="lblDescription" runat="server"
                        AssociatedControlID="txtDescription"
                        Text="Description"
                        CssClass="form-label fw-semibold" />

                    <asp:TextBox ID="txtDescription" runat="server"
                        CssClass="form-control" MaxLength="50"
                        placeholder="Ingredient name" />
                </div>

                <div class="col-md-6">
                    <asp:Label ID="lblQuantity" runat="server"
                        AssociatedControlID="txtQuantity"
                        Text="Quantity in stock"
                        CssClass="form-label fw-semibold" />

                    <!-- QuantityOnHand is an integer in the database. -->
                    <asp:TextBox ID="txtQuantity" runat="server"
                        CssClass="form-control" TextMode="Number"
                        min="0" max="2147483647" step="1" Text="0" />
                </div>

                <div class="col-md-6">
                    <asp:Label ID="lblRestockLevel" runat="server"
                        AssociatedControlID="txtRestockLevel"
                        Text="Restock level"
                        CssClass="form-label fw-semibold" />

                    <asp:TextBox ID="txtRestockLevel" runat="server"
                        CssClass="form-control" TextMode="Number"
                        min="0" max="2147483647" step="1" Text="0" />
                </div>

                <div class="col-md-6">
                    <asp:Label ID="lblCostPrice" runat="server"
                        AssociatedControlID="txtCostPrice"
                        Text="Cost price (R)"
                        CssClass="form-label fw-semibold" />

                    <asp:TextBox ID="txtCostPrice" runat="server"
                        CssClass="form-control" TextMode="Number"
                        min="0" max="99999999.99" step="0.01" Text="0.00" />
                </div>

            </div>

            <div class="management-actions mt-4">

                <asp:Button ID="btnAddIngredient" runat="server"
                    Text="Add ingredient" CssClass="btn btn-brand"
                    CausesValidation="false"
                    OnClick="btnAddIngredient_Click" />

                <asp:Button ID="btnUpdateIngredient" runat="server"
                    Text="Update selected" CssClass="btn btn-outline-primary"
                    Enabled="false" CausesValidation="false"
                    OnClick="btnUpdateIngredient_Click" />

                <asp:Button ID="btnRemoveIngredient" runat="server"
                    Text="Remove selected" CssClass="btn btn-outline-danger"
                    Enabled="false" CausesValidation="false"
                    OnClick="btnRemoveIngredient_Click"
                    OnClientClick="return confirm('Remove the selected ingredient? Ingredients used in recipes cannot be removed.');" />

                <asp:Button ID="btnNewIngredient" runat="server"
                    Text="Clear form" CssClass="btn btn-outline-secondary"
                    CausesValidation="false"
                    OnClick="btnNewIngredient_Click" />

                <asp:Button ID="btnRefreshIngredients" runat="server"
                    Text="Refresh list" CssClass="btn btn-outline-secondary"
                    CausesValidation="false"
                    OnClick="btnRefreshIngredients_Click" />

            </div>

            <p class="small text-muted mt-3 mb-0">
                Select a row to edit it. Clear the form to add a new ingredient.
                Stock quantities and restock levels must be whole numbers.
            </p>

        </div>

    </div>

</asp:Content>