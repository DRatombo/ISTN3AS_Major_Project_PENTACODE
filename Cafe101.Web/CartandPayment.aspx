<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CartandPayment.aspx.cs" Inherits="Cafe101.Web.CartandPayment" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        #mainNavbar { display: none; }
    </style>

    <div class="d-flex align-items-center py-3 full-bleed px-3" style="background-color: var(--brand-navy);">
        <a href="~/CustomerDashboard.aspx" runat="server" class="btn p-0 border-0 me-3">
            <span style="font-size: 1.4rem; color: #fff;">&#8592;</span>
        </a>
        <span class="fw-bold text-white" style="font-size: 1.25rem;">Checkout Your Order</span>
    </div>

    <div class="container py-4">

        <asp:Label ID="lblMessage" runat="server" Visible="false" CssClass="alert alert-danger d-block" />

        <div class="row g-4">

            <!-- LEFT: items in the cart -->
            <div class="col-lg-7">

                <h6 class="fw-bold text-uppercase text-muted mb-3">Items in Your Cart</h6>

                <asp:Repeater ID="rptCartItems" runat="server">
                    <ItemTemplate>
                        <div class="d-flex justify-content-between gap-3 border-bottom py-3">
                            <div>
                                <h6 class="fw-bold mb-1"><%#: Eval("MenuItemName") %></h6>
                                <p class="text-muted small mb-0">
                                    Quantity: <%# Eval("Quantity") %>
                                    &times; R <%# Eval("UnitPrice", "{0:0.00}") %> each
                                </p>
                            </div>
                            <span class="fw-bold text-nowrap">R <%# Eval("LineTotal", "{0:0.00}") %></span>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:Panel ID="pnlEmptyCart" runat="server" Visible="false">
                    <p class="text-muted">Your cart is empty.</p>
                    <a href="Menu.aspx" class="btn btn-brand">Browse menu</a>
                </asp:Panel>
            </div>

            <!-- RIGHT: checkout form -->
            <div class="col-lg-5">
                <asp:Panel ID="pnlCheckout" runat="server">
                    <div class="border rounded p-3">

                        <div class="mb-3">
                            <label class="fw-bold">Order ID</label>
                            <asp:TextBox ID="txtOrderID" runat="server" ReadOnly="true" CssClass="form-control" />
                        </div>

                        <div class="mb-3">
                            <label class="fw-bold">Order Total</label>
                            <asp:TextBox ID="txtOrderTotal" runat="server" ReadOnly="true" CssClass="form-control fw-bold" />
                        </div>

                        <fieldset class="border rounded p-3 mb-3">
                            <legend class="fs-6 fw-bold w-auto px-2">Payment Method</legend>
                            <asp:RadioButtonList ID="rblPayment" runat="server" RepeatDirection="Horizontal" CssClass="w-100">
                                <asp:ListItem Value="Cash">&nbsp;Cash&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                <asp:ListItem Value="Card">&nbsp;Card</asp:ListItem>
                            </asp:RadioButtonList>
                        </fieldset>

                        <!-- Cash only -->
                        <div id="divCash" style="display:none;">
                            <div class="mb-2">
                                <label class="fw-bold">Amount Tendered</label>
                                <asp:TextBox ID="txtAmountTendered" runat="server" CssClass="form-control"
                                    MaxLength="10" autocomplete="off" />
                                <span id="lblAmountMes" class="small fw-bold"></span>
                            </div>

                            <div class="d-flex flex-wrap gap-2 mb-3" id="divQuick">
                                <button type="button" class="btn btn-outline-secondary btn-sm" data-amt="exact" onclick="setAmount('exact')">Exact</button>
                                <button type="button" class="btn btn-outline-secondary btn-sm" data-amt="50"  onclick="setAmount(50)">R50</button>
                                <button type="button" class="btn btn-outline-secondary btn-sm" data-amt="100" onclick="setAmount(100)">R100</button>
                                <button type="button" class="btn btn-outline-secondary btn-sm" data-amt="200" onclick="setAmount(200)">R200</button>
                            </div>

                            <div class="mb-3">
                                <label class="fw-bold">Change</label>
                                <asp:TextBox ID="txtChange" runat="server" ReadOnly="true" CssClass="form-control" Text="R 0.00" />
                            </div>
                        </div>

                        <!-- Card only -->
                        <div id="divCard" class="small text-muted mb-3" style="display:none;">
                            Card payment: no change is due.
                        </div>

                        <div class="d-flex gap-2 mt-3">
                            <asp:Button ID="btnConfirm" runat="server" Text="Confirm Payment"
                                CssClass="btn btn-brand flex-fill" UseSubmitBehavior="false"
                                OnClientClick="if (!validateCheckout()) return false; this.disabled = true; this.value = 'Processing...';"
                                OnClick="btnConfirm_Click" />

                            <a href="Menu.aspx" class="btn btn-outline-secondary flex-fill"
                               onclick="return confirm('Are you sure you want to cancel this payment?');">Cancel Payment</a>
                        </div>

                    </div>
                </asp:Panel>
            </div>

        </div>
    </div>

    <script>
        (function () {
            var total = parseFloat('<%= TotalForJs %>');
            var payName = '<%= rblPayment.UniqueID %>';
            var amt = document.getElementById('<%= txtAmountTendered.ClientID %>');
            var chg = document.getElementById('<%= txtChange.ClientID %>');
            var mes = document.getElementById('lblAmountMes');

            if (!amt) return;   // checkout panel is hidden (empty cart)

            function method() {
                var s = document.querySelector('input[name="' + payName + '"]:checked');
                return s ? s.value : '';
            }

            // Returns an error text, or '' when valid
            function check() {
                var m = method();
                if (m === '') return 'Please select a payment method.';
                if (m === 'Card') return '';

                var t = amt.value.trim().replace(',', '.');
                if (t === '') return 'Required';
                if (!/^\d+(\.\d{1,2})?$/.test(t)) return 'Numbers only';
                var v = parseFloat(t);
                if (v <= 0) return 'Must be greater than 0';
                if (v < total) return 'Amount too low';
                return '';
            }

            function refresh() {
                var m = method();
                document.getElementById('divCash').style.display = m === 'Cash' ? 'block' : 'none';
                document.getElementById('divCard').style.display = m === 'Card' ? 'block' : 'none';
                if (m !== 'Cash') return;

                var t = amt.value.trim().replace(',', '.');
                var v = parseFloat(t);
                chg.value = (!isNaN(v) && v >= total) ? 'R ' + (v - total).toFixed(2)
                    : (!isNaN(v) && v > 0 ? 'Insufficient' : 'R 0.00');

                if (t === '') {
                    amt.style.backgroundColor = '';
                    mes.textContent = '';
                } else {
                    var e = check();
                    amt.style.backgroundColor = e ? '#ffdcdc' : '#dcf5dc';
                    mes.textContent = e ? '⚠ ' + e : '✓';
                    mes.style.color = e ? '#d63c3c' : '#32b464';
                }

                // Hide quick-cash buttons smaller than the total
                document.querySelectorAll('#divQuick button').forEach(function (b) {
                    var a = b.getAttribute('data-amt');
                    b.style.display = (a === 'exact' || parseFloat(a) >= total) ? '' : 'none';
                });
            }

            window.setAmount = function (v) {
                amt.value = (v === 'exact') ? total.toFixed(2) : v.toFixed(2);
                refresh();
            };

            // Runs before the Confirm button posts back
            window.validateCheckout = function () {
                refresh();
                var e = check();
                if (e) {
                    if (method() === 'Cash') {
                        mes.textContent = '⚠ ' + e;
                        mes.style.color = '#d63c3c';
                        amt.focus();
                    } else {
                        alert(e);
                    }
                    return false;
                }
                return true;
            };

            document.querySelectorAll('input[name="' + payName + '"]').forEach(function (r) {
                r.addEventListener('change', refresh);
            });
            amt.addEventListener('input', refresh);
            refresh();
        })();
    </script>

</asp:Content>