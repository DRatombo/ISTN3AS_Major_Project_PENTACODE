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
                <div class="d-flex align-items-center border-bottom py-3">
                    <img src="https://placehold.co/100x100/e4f0fd/1a2d4c?text=%E2%98%95" alt="Cappuccino" class="rounded me-3" style="width:64px; height:64px; object-fit:cover;" />
                    <div class="flex-grow-1">
                        <p class="fw-bold mb-0">Cappuccino</p>
                        <p class="text-muted small mb-0">R35.00 each</p>
                    </div>
                    <div class="d-flex align-items-center me-3">
                        <button class="btn btn-sm btn-outline-secondary" type="button">-</button>
                        <span class="mx-2">2</span>
                        <button class="btn btn-sm btn-outline-secondary" type="button">+</button>
                    </div>
                    <p class="fw-bold text-brand mb-0" style="min-width: 60px; text-align:right;">R70.00</p>
                </div>

                <div class="d-flex align-items-center border-bottom py-3">
                    <img src="https://placehold.co/100x100/fdf3e4/1a2d4c?text=%F0%9F%A5%90" alt="Butter Croissant" class="rounded me-3" style="width:64px; height:64px; object-fit:cover;" />
                    <div class="flex-grow-1">
                        <p class="fw-bold mb-0">Butter Croissant</p>
                        <p class="text-muted small mb-0">R28.00 each</p>
                    </div>
                    <div class="d-flex align-items-center me-3">
                        <button class="btn btn-sm btn-outline-secondary" type="button">-</button>
                        <span class="mx-2">1</span>
                        <button class="btn btn-sm btn-outline-secondary" type="button">+</button>
                    </div>
                    <p class="fw-bold text-brand mb-0" style="min-width: 60px; text-align:right;">R28.00</p>
                </div>

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
            <div class="col-lg-5">
                <div class="p-4 rounded shadow-sm" style="background-color: #f8f9fa;">
                    <h6 class="fw-bold text-uppercase text-muted mb-3">Order Summary</h6>

                    <div class="d-flex justify-content-between mb-2">
                        <span>Subtotal</span>
                        <span>R98.00</span>
                    </div>
                    <div class="d-flex justify-content-between mb-2">
                        <span>Delivery Fee</span>
                        <span>R25.00</span>
                    </div>
                    <hr />
                    <div class="d-flex justify-content-between mb-4">
                        <span class="fw-bold">Total</span>
                        <span class="fw-bold text-brand">R123.00</span>
                    </div>

                    <a href="~/OrderHistory.aspx" runat="server" class="btn btn-brand w-100 py-2">Place Order</a>
                </div>
            </div>

        </div>
    </div>

</asp:Content>