<%@ Page Title="Manage Recipes"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ManageRecipes.aspx.cs"
    Inherits="Cafe101.Web.ManageRecipes" %>

<asp:Content ID="BodyContent"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <style>
        /* Replace the public header with the manager layout. */
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

        .body-content > footer,
        .body-content > hr {
            display: none;
        }

        .recipe-shell .staff-header-user,
        .recipe-shell .staff-header-user:hover {
            color: #fff;
            text-decoration: none;
        }

        .recipe-shell .staff-main {
            min-width: 0;
        }

        .recipe-card {
            padding: 22px;
            margin-bottom: 22px;
            background: #fff;
            border: 1px solid #e1e6ec;
            border-radius: 14px;
            box-shadow: 0 4px 16px rgba(0, 0, 0, .04);
        }

        .recipe-card h2 {
            color: var(--brand-navy);
        }

        .recipe-card .form-control,
        .recipe-card .form-select {
            width: 100%;
            max-width: none;
        }

        .recipe-search {
            max-width: 650px;
        }

        .recipe-table {
            min-width: 640px;
        }

        .recipe-table th {
            background: var(--brand-navy);
            color: #fff;
            white-space: nowrap;
        }

        .recipe-table td {
            vertical-align: middle;
        }

        .recipe-table td a {
            display: inline-block;
            padding: 6px 12px;
            border: 1px solid var(--brand-navy);
            border-radius: 6px;
            color: var(--brand-navy);
            text-decoration: none;
        }

        .recipe-actions {
            display: flex;
            flex-wrap: wrap;
            gap: 10px;
            margin-top: 20px;
        }

        .recipe-actions .btn {
            min-width: 110px;
        }

        /* Collapse the sidebar while keeping accessible link names. */
        .recipe-shell .staff-body.recipe-sidebar-collapsed .staff-sidebar {
            width: 78px;
        }

        .recipe-shell .recipe-sidebar-collapsed .staff-nav-text,
        .recipe-shell .recipe-sidebar-collapsed .staff-sidebar-title {
            display: none;
        }

        @media (max-width: 575.98px) {
            .recipe-card {
                padding: 16px;
            }

            .recipe-actions .btn {
                flex: 1 1 140px;
            }
        }

        /* Keep the search field and its buttons together on one row. */
        .recipe-search {
            display: flex;
            flex-wrap: nowrap;
            align-items: stretch;
            width: 100%;
            max-width: 650px;
        }

        .recipe-card .recipe-search .form-control {
            flex: 1 1 0;
            width: 1%;
            min-width: 0;
            max-width: none;
        }

        .recipe-search .btn {
            flex: 0 0 auto;
            white-space: nowrap;
        }

        .recipe-shell .staff-nav-icon {
            display: inline-flex;
            align-items: center;
            justify-content: center;
            width: 22px;
            flex: 0 0 22px;
        }

        .recipe-shell .staff-nav-icon svg {
            display: block;
            flex-shrink: 0;
        }
    </style>

    <div class="staff-shell manager-shell recipe-shell">

        <header class="staff-header">
            <div class="staff-header-left">

                <button type="button"
                    id="recipeSidebarToggle"
                    class="staff-header-menu"
                    aria-label="Toggle manager navigation"
                    aria-controls="recipeSidebar"
                    aria-expanded="true">
                    &#9776;
                </button>

                <div class="staff-header-brand">Cafe101</div>
            </div>

            <!-- The current manager's identity comes from the login session. -->
            <a href="ManagerProfile.aspx" class="staff-header-user">
                <div class="staff-header-avatar">
                    <%: ManagerInitials %>
                </div>
                <div>
                    <strong><%: ManagerDisplayName %></strong>
                    <small>Manager</small>
                </div>
            </a>
        </header>

        <div class="staff-body" id="recipeBody">

            <aside class="staff-sidebar" id="recipeSidebar">

                <div class="staff-sidebar-title">MANAGER SYSTEM</div>

               <!-- The same navigation links are available on both management pages. -->
                <nav id="managerPageNav" class="staff-nav"
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

                    <a href="ManageIngredients.aspx" aria-label="Ingredients" class="active" aria-current="page">
                        <span class="staff-nav-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" width="19" height="19"
                                fill="none" stroke="currentColor" stroke-width="2">
                                <path d="M4 7h16v14H4zM3 3h18v4H3zM9 11h6" />
                            </svg>
                        </span>
                        <span class="staff-nav-text">Ingredients</span>
                    </a>

                    <a href="ManageRecipes.aspx" aria-label="Recipes" class="active" aria-current="page">
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
                <div class="staff-sidebar-bottom">
                    <asp:LinkButton ID="lnkLogout" runat="server"
                        CssClass="staff-logout"
                        CausesValidation="false"
                        OnClick="lnkLogout_Click">
                        <span class="staff-nav-icon" aria-hidden="true">&#10140;</span>
                        <span class="staff-nav-text">Logout</span>
                    </asp:LinkButton>
                </div>

            </aside>

            <main class="staff-main">

                <div class="staff-page-heading">
                    <h3>Manage Recipes</h3>
                    <p>Maintain the ingredients needed for each menu item.</p>
                </div>

                <asp:Label ID="lblRecipeMessage" runat="server"
                    CssClass="d-block mb-3"
                    role="status" aria-live="polite" />

                <!-- Search the joined menu item and ingredient names. -->
                <section class="recipe-card">

                    <asp:Label runat="server"
                        AssociatedControlID="txtRecipeSearch"
                        Text="Search recipes"
                        CssClass="form-label fw-semibold" />

                    <asp:Panel ID="pnlRecipeSearch" runat="server"
                        DefaultButton="btnRecipeSearch">

                        <div class="input-group recipe-search">
                            <asp:TextBox ID="txtRecipeSearch" runat="server"
                                CssClass="form-control" MaxLength="100"
                                placeholder="Menu item or ingredient name" />

                            <asp:Button ID="btnRecipeSearch" runat="server"
                                Text="Search" CssClass="btn btn-brand"
                                CausesValidation="false"
                                OnClick="btnRecipeSearch_Click" />

                            <asp:Button ID="btnClearSearch" runat="server"
                                Text="Clear" CssClass="btn btn-outline-secondary"
                                CausesValidation="false"
                                OnClick="btnClearSearch_Click" />
                        </div>

                    </asp:Panel>

                </section>

                <section class="recipe-card">

                    <h2 class="h5 fw-bold mb-2">Recipe Details</h2>

                    <asp:Label ID="lblRecipeSelection" runat="server"
                        Text="New recipe ingredient"
                        CssClass="d-block text-muted mb-3" />

                    <div class="row g-3">

                        <div class="col-md-5">
                            <asp:Label runat="server"
                                AssociatedControlID="ddlRecipeMenuItem"
                                Text="Menu item"
                                CssClass="form-label fw-semibold" />

                            <asp:DropDownList ID="ddlRecipeMenuItem"
                                runat="server" CssClass="form-select" />
                        </div>

                        <div class="col-md-5">
                            <asp:Label runat="server"
                                AssociatedControlID="ddlRecipeIngredient"
                                Text="Ingredient"
                                CssClass="form-label fw-semibold" />

                            <asp:DropDownList ID="ddlRecipeIngredient"
                                runat="server" CssClass="form-select" />
                        </div>

                        <div class="col-md-2">
                            <asp:Label runat="server"
                                AssociatedControlID="txtRecipeQuantity"
                                Text="Quantity needed"
                                CssClass="form-label fw-semibold" />

                            <asp:TextBox ID="txtRecipeQuantity"
                                runat="server" CssClass="form-control"
                                TextMode="Number" min="1"
                                max="2147483647" step="1" Text="1" />
                        </div>

                    </div>

                    <div class="recipe-actions">

                        <asp:Button ID="btnAddRecipe" runat="server"
                            Text="Add ingredient" CssClass="btn btn-brand"
                            CausesValidation="false"
                            OnClick="btnAddRecipe_Click" />

                        <asp:Button ID="btnUpdateRecipe" runat="server"
                            Text="Update quantity"
                            CssClass="btn btn-outline-primary"
                            Enabled="false" CausesValidation="false"
                            OnClick="btnUpdateRecipe_Click" />

                        <asp:Button ID="btnRemoveRecipe" runat="server"
                            Text="Remove ingredient"
                            CssClass="btn btn-outline-danger"
                            Enabled="false" CausesValidation="false"
                            OnClick="btnRemoveRecipe_Click"
                            OnClientClick="return confirm('Remove this ingredient from the selected recipe? This does not delete the ingredient from stock.');" />

                        <asp:Button ID="btnNewRecipe" runat="server"
                            Text="Clear form"
                            CssClass="btn btn-outline-secondary"
                            CausesValidation="false"
                            OnClick="btnNewRecipe_Click" />

                        <asp:Button ID="btnRefreshRecipes" runat="server"
                            Text="Refresh"
                            CssClass="btn btn-outline-secondary"
                            CausesValidation="false"
                            OnClick="btnRefreshRecipes_Click" />
                    </div>

                    <p class="small text-muted mt-3 mb-0">
                        Quantity needed is the number of ingredient units used
                        to prepare one menu item. Select a row to change its
                        quantity or remove it from that recipe.
                    </p>

                </section>

                <section class="recipe-card">

                    <h2 class="h5 fw-bold mb-3">Recipe List</h2>

                    <div class="table-responsive">

                        <asp:GridView ID="gvRecipes" runat="server"
                            AutoGenerateColumns="false"
                            DataKeyNames="MenuItemID,IngredientID"
                            CssClass="table table-hover recipe-table"
                            GridLines="None"
                            EmptyDataText="No matching recipes found."
                            OnSelectedIndexChanged="gvRecipes_SelectedIndexChanged">

                            <Columns>
                                <asp:BoundField DataField="MenuItemName"
                                    HeaderText="Menu item" />

                                <asp:BoundField DataField="IngredientName"
                                    HeaderText="Ingredient" />

                                <asp:BoundField DataField="QuantityNeeded"
                                    HeaderText="Quantity needed" />

                                <asp:CommandField HeaderText="Action"
                                    ShowSelectButton="true"
                                    SelectText="Select"
                                    CausesValidation="false" />
                            </Columns>

                            <SelectedRowStyle BackColor="#e9eff7" />

                        </asp:GridView>

                    </div>

                </section>

            </main>
        </div>
    </div>

    <script>
        // Toggle this page's sidebar without submitting the form.
        (function () {
            var button = document.getElementById("recipeSidebarToggle");
            var body = document.getElementById("recipeBody");

            button.addEventListener("click", function () {
                var collapsed =
                    body.classList.toggle("recipe-sidebar-collapsed");

                button.setAttribute(
                    "aria-expanded", collapsed ? "false" : "true");
            });
        })();
    </script>

</asp:Content>