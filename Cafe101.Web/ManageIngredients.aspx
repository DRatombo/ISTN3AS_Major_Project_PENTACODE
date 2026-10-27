<%@ Page Title="Manage Ingredients"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ManageIngredients.aspx.cs"
    Inherits="Cafe101.Web.ManageIngredients" %>

<asp:Content
    ID="BodyContent"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <style>
        .management-page {
            padding: 30px 0 50px;
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

        .management-table thead {
            background: var(--brand-navy);
            color: white;
        }

        .management-table th {
            font-weight: 600;
            white-space: nowrap;
        }

        .management-actions {
            display: flex;
            flex-wrap: wrap;
            gap: 10px;
        }

        .management-actions .btn {
            min-width: 110px;
        }
    </style>

    <div class="management-page">

        <div class="d-flex flex-wrap justify-content-between
                    align-items-center gap-3 mb-4">

            <div>
                <h1 class="h3 management-title mb-1">
                    Manage Ingredients
                </h1>

                <p class="text-muted mb-0">
                    View and maintain ingredient stock and prices.
                </p>
            </div>

            <a href="ManagerDashboard.aspx"
                class="btn btn-outline-secondary">
                Back to dashboard
            </a>

        </div>

        <!-- Search area -->
        <div class="management-card mb-4">

            <label for="ingredientSearch" class="form-label fw-semibold">
                Search ingredients
            </label>

            <div class="input-group">
                <input
                    id="ingredientSearch"
                    type="search"
                    class="form-control"
                    placeholder="Search by ingredient name" />

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

        <!-- Ingredient table: rows will be loaded from the database later. -->
        <div class="management-card mb-4">

            <h2 class="h5 fw-bold mb-3">Ingredient List</h2>

            <div class="table-responsive">

                <table class="table table-hover align-middle management-table">
                    <thead>
                        <tr>
                            <th scope="col">Description</th>
                            <th scope="col">Quantity in stock</th>
                            <th scope="col">Restock level</th>
                            <th scope="col">Cost price</th>
                            <th scope="col">Select</th>
                        </tr>
                    </thead>

                    <tbody>
                        <tr>
                            <td colspan="5" class="text-center text-muted py-4">
                                Ingredient data has not been connected yet.
                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>

        </div>

        <!-- Details for the ingredient being added or edited. -->
        <div class="management-card">

            <h2 class="h5 fw-bold mb-3">Ingredient Details</h2>

            <div class="row g-3">

                <div class="col-md-6">
                    <label for="ingredientDescription"
                        class="form-label fw-semibold">
                        Description
                    </label>

                    <input
                        id="ingredientDescription"
                        type="text"
                        class="form-control"
                        placeholder="e.g. Burger buns" />
                </div>

                <div class="col-md-6">
                    <label for="ingredientQuantity"
                        class="form-label fw-semibold">
                        Quantity in stock
                    </label>

                    <input
                        id="ingredientQuantity"
                        type="number"
                        class="form-control"
                        min="0"
                        step="0.01"
                        placeholder="0.00" />
                </div>

                <div class="col-md-6">
                    <label for="ingredientRestock"
                        class="form-label fw-semibold">
                        Restock level
                    </label>

                    <input
                        id="ingredientRestock"
                        type="number"
                        class="form-control"
                        min="0"
                        step="0.01"
                        placeholder="0.00" />
                </div>

                <div class="col-md-6">
                    <label for="ingredientCost"
                        class="form-label fw-semibold">
                        Cost price (R)
                    </label>

                    <input
                        id="ingredientCost"
                        type="number"
                        class="form-control"
                        min="0"
                        step="0.01"
                        placeholder="0.00" />
                </div>

            </div>

            <!-- Buttons are enabled once their operations are implemented. -->
            <div class="management-actions mt-4">
                <button type="button" class="btn btn-brand" disabled>
                    Add new
                </button>

                <button type="button" class="btn btn-outline-primary" disabled>
                    Update
                </button>

                <button type="button" class="btn btn-outline-danger" disabled>
                    Remove
                </button>

                <button type="button" class="btn btn-outline-secondary" disabled>
                    Refresh
                </button>
            </div>

            <p class="small text-muted mt-3 mb-0">
                Select an ingredient from the list before updating or removing it.
            </p>

        </div>

    </div>

</asp:Content>
