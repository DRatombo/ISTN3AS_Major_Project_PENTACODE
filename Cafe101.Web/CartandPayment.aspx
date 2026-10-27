<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CartandPayment.aspx.cs" Inherits="Cafe101.Web.CartandPayment" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        #mainNavbar { display: none; }
    </style>

    <div class="d-flex align-items-center py-3 full-bleed px-3" style="background-color: var(--brand-navy);">
        <a href="~/CustomerDashboard.aspx" runat="server" class="btn p-0 border-0 me-3">
            <span style="font-size: 1.4rem; color: #fff;">&#8592;</span>
        </a>
        <span class="fw-bold text-white" style="font-size: 1.25rem;">Your Cart</span>
    </div>

    <div class="container py-4">
        <div class="row g-4">

            <!-- LEFT: Cart items + delivery + payment -->
            <div class="col-lg-7">

                <h6 class="fw-bold text-uppercase text-muted mb-3">Items in Your Cart</h6>
                
                    <!-- Display the items selected on the menu page. -->
                        <asp:Repeater ID="rptCartItems" runat="server">
                            <ItemTemplate>
                                <div class="d-flex justify-content-between gap-3 border-bottom py-3">

                                    <div>
                                        <h6 class="fw-bold mb-1">
                                            <%#: Eval("MenuItemName") %>
                                        </h6>

                                        <p class="text-muted small mb-0">
                                            Quantity: <%# Eval("Quantity") %>
                                            &times; R <%# Eval("UnitPrice", "{0:0.00}") %> each
                                        </p>
                                    </div>

                                    <span class="fw-bold text-nowrap">
                                        R <%# Eval("LineTotal", "{0:0.00}") %>
                                    </span>

                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <asp:Panel ID="pnlEmptyCart" runat="server" Visible="false">
                            <p class="text-muted">Your cart is empty.</p>

                            <a href="Menu.aspx" class="btn btn-brand">
                                Browse menu
                            </a>
                        </asp:Panel>

                <h6 class="fw-bold text-uppercase text-muted mb-3 mt-4">Delivery Options</h6>
                <div class="d-flex gap-3 mb-3">
                    <input type="radio" id="rbPickup" name="delivery" class="d-none" checked />
                    <label for="rbPickup" class="btn btn-outline-brand flex-fill py-2">Pickup</label>

                    <input type="radio" id="rbDelivery" name="delivery" class="d-none" />
                    <label for="rbDelivery" class="btn btn-outline-brand flex-fill py-2">Delivery</label>
                </div>
                <div class="mb-3">
                    <input type="text" class="form-control" placeholder="Delivery address (if applicable)" />
                </div>

                <h6 class="fw-bold text-uppercase text-muted mb-3 mt-4">Payment</h6>
                <div class="mb-3">
                    <input type="text" class="form-control" placeholder="Name on card" />
                </div>
                <div class="mb-3">
                    <input type="text" class="form-control" placeholder="Card number" />
                </div>
                <div class="row g-2 mb-4">
                    <div class="col-6">
                        <input type="text" class="form-control" placeholder="MM/YY" />
                    </div>
                    <div class="col-6">
                        <input type="password" class="form-control" placeholder="CVV" />
                    </div>
                </div>

            </div>

            <!-- RIGHT: Order summary -->
            <div class="d-flex justify-content-between mb-3">
                <span class="fw-bold">Items subtotal</span>

                <asp:Label
                    ID="lblItemsSubtotal"
                    runat="server"
                    CssClass="fw-bold" />
            </div>

            <p class="small text-muted">
                Delivery charges and the final total will be confirmed at checkout.
            </p>

        </div>
    </div>

</asp:Content>