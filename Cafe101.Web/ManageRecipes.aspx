<%@ Page Title="Manage Recipes"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ManageRecipes.aspx.cs"
    Inherits="Cafe101.Web.ManageRecipes" %>

<asp:Content
    ID="BodyContent"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <style>
        .recipe-page {
            padding: 30px 0 50px;
        }

        .recipe-title {
            color: var(--brand-navy);
            font-weight: 700;
        }

        .recipe-card {
            background: #fff;
            border: 1px solid #e1e6ec;
            border-radius: 14px;
            padding: 22px;
            box-shadow: 0 4px 16px rgba(0, 0, 0, 0.05);
        }

        .recipe-table {
            min-width: 650px;
        }

        .recipe-table thead {
            background: var(--brand-navy);
            color: white;
        }

        .recipe-table th {
            white-space: nowrap;
        }

        .recipe-actions {
            display: flex;
            flex-wrap: wrap;
            gap: 10px;
        }

        .recipe-actions .btn {
            min-width: 110px;
        }
    </style>

    <div class="recipe-page">

        <div class="d-flex flex-wrap justify-content-between
                    align-items-center gap-3 mb-4">

            <div>
                <h1 class="h3 recipe-title mb-1">
                    Manage Recipes
                </h1>

                <p class="text-muted mb-0">
                    Link menu items to the ingredients needed to prepare them.
                </p>
            </div>

            <a href="ManagerDashboard.aspx"
                class="btn btn-outline-secondary">
                Back to dashboard
            </a>

        </div>

        <!-- Search by a menu item or ingredient name. -->
        <div class="recipe-card mb-4">

            <label for="recipeSearch" class="form-label fw-semibold">
                Search recipes
            </label>

            <div class="input-group">
                <input
                    id="recipeSearch"
                    type="search"
                    class="form-control"
                    placeholder="Search by menu item or ingredient" />

                <button type="button" class="btn btn-brand" disabled>
                    Search
                </button>

                <button type="button"
                    class="btn btn-outline-secondary"
                    disabled>
                    Clear
                </button>
            </div>

        </div>

        <!-- The lists will be filled from the menu and ingredient tables. -->
        <div class="recipe-card mb-4">

            <h2 class="h5 fw-bold mb-3">Recipe Details</h2>

            <div class="row g-3">

                <div class="col-md-5">
                    <label for="recipeMenuItem"
                        class="form-label fw-semibold">
                        Menu item
                    </label>

                    <select id="recipeMenuItem" class="form-select">
                        <option value="">Select a menu item</option>
                    </select>
                </div>

                <div class="col-md-5">
                    <label for="recipeIngredient"
                        class="form-label fw-semibold">
                        Ingredient
                    </label>

                    <select id="recipeIngredient" class="form-select">
                        <option value="">Select an ingredient</option>
                    </select>
                </div>

                <div class="col-md-2">
                    <label for="recipeQuantity"
                        class="form-label fw-semibold">
                        Quantity needed
                    </label>

                    <input
                        id="recipeQuantity"
                        type="number"
                        class="form-control"
                        min="0.01"
                        step="0.01"
                        placeholder="1.00" />
                </div>

            </div>

            <div class="recipe-actions mt-4">
                <button type="button" class="btn btn-brand" disabled>
                    Add ingredient
                </button>

                <button type="button" class="btn btn-outline-primary" disabled>
                    Update quantity
                </button>

                <button type="button" class="btn btn-outline-danger" disabled>
                    Remove
                </button>

                <button type="button" class="btn btn-outline-secondary" disabled>
                    Refresh
                </button>
            </div>

            <p class="small text-muted mt-3 mb-0">
                Select a recipe row to update its quantity or remove an ingredient.
            </p>

        </div>

        <!-- Recipe records will be loaded into this table later. -->
        <div class="recipe-card">

            <h2 class="h5 fw-bold mb-3">Recipe List</h2>

            <div class="table-responsive">

                <table class="table table-hover align-middle recipe-table">
                    <thead>
                        <tr>
                            <th scope="col">Menu item</th>
                            <th scope="col">Ingredient</th>
                            <th scope="col">Quantity needed</th>
                            <th scope="col">Select</th>
                        </tr>
                    </thead>

                    <tbody>
                        <tr>
                            <td colspan="4" class="text-center text-muted py-4">
                                Recipe data has not been connected yet.
                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>

        </div>

    </div>

</asp:Content>