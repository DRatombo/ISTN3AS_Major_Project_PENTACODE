<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Cafe101.Web.Menu" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        #mainNavbar { display: none; }
    </style>

    <!-- Top bar -->
    <div class="d-flex align-items-center py-3 full-bleed px-3" style="background-color: var(--brand-navy);">
        <a href="~/CustomerDashboard.aspx" runat="server" class="btn p-0 border-0 me-3">
            <span style="font-size: 1.4rem; color: #fff;">&#8592;</span>
        </a>
        <span class="fw-bold text-white" style="font-size: 1.25rem;">Menu</span>
    </div>

    <!-- Swipeable category tabs -->
    <ul class="nav nav-pills flex-nowrap overflow-auto full-bleed px-3 py-3 gap-2" id="menuTabs" style="white-space: nowrap;">
        <li class="nav-item"><a class="nav-link active" data-bs-toggle="pill" href="#tab-full">Full Menu</a></li>
        <li class="nav-item"><a class="nav-link" data-bs-toggle="pill" href="#tab-food">Food</a></li>
        <li class="nav-item"><a class="nav-link" data-bs-toggle="pill" href="#tab-drinks">Beverages</a></li>
        <li class="nav-item"><a class="nav-link" data-bs-toggle="pill" href="#tab-combos">Combo Deals</a></li>
        <li class="nav-item"><a class="nav-link" data-bs-toggle="pill" href="#tab-snacks">Snacks</a></li>
    </ul>

    <div class="container pb-5">

        <div class="tab-content">

            <!-- FULL MENU -->
           <div class="tab-pane fade show active" id="tab-full">
    <div class="row row-cols-2 row-cols-md-3 g-3 mb-3">
        <div class="col"><div class="card h-100">
            <img src="~/Content/images/Coke330.png" runat="server" class="card-img-top" style="height:110px; object-fit:contain;" alt="Coca-Cola 330ml" />
            <div class="card-body p-2">
                <p class="mb-0 small fw-bold">Coca-Cola 330ml</p>
                <p class="mb-2 small text-brand fw-bold">R10.00</p>
                <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
            </div>
        </div></div>

        <div class="col"><div class="card h-100">
            <img src="~/Content/images/Coke440.png" runat="server" class="card-img-top" style="height:110px; object-fit:contain;" alt="Coca-Cola 440ml" />
            <div class="card-body p-2">
                <p class="mb-0 small fw-bold">Coca-Cola 440ml</p>
                <p class="mb-2 small text-brand fw-bold">R15.00</p>
                <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
            </div>
        </div></div>

        <div class="col"><div class="card h-100">
            <img src="~/Content/images/Coke2l.png" runat="server" class="card-img-top" style="height:110px; object-fit:contain;" alt="Coca-Cola 2L" />
            <div class="card-body p-2">
                <p class="mb-0 small fw-bold">Coca-Cola 2l</p>
                <p class="mb-2 small text-brand fw-bold">R30.00</p>
                <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
            </div>
        </div></div>

        <div class="col"><div class="card h-100">
            <img src="~/Content/images/Kingsley.png" runat="server" class="card-img-top" style="height:110px; object-fit:contain;" alt="Kingsley" />
            <div class="card-body p-2">
                <p class="mb-0 small fw-bold">Kingsley</p>
                <p class="mb-2 small text-brand fw-bold">R25.00</p>
                <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
            </div>
        </div></div>

        <div class="col"><div class="card h-100">
            <img src="~/Content/images/Reboost.png" runat="server" class="card-img-top" style="height:110px; object-fit:contain;" alt="Reboost" />
            <div class="card-body p-2">
                <p class="mb-0 small fw-bold">Reboost</p>
                <p class="mb-2 small text-brand fw-bold">R15.00</p>
                <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
            </div>
        </div></div>

        <div class="col"><div class="card h-100">
            <img src="~/Content/images/Monster.png" runat="server" class="card-img-top" style="height:110px; object-fit:contain;" alt="Monster" />
            <div class="card-body p-2">
                <p class="mb-0 small fw-bold">Monster</p>
                <p class="mb-2 small text-brand fw-bold">R20.00</p>
                <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
            </div>
        </div></div>

        <div class="col"><div class="card h-100">
            <img src="~/Content/images/Aquelle.png" runat="server" class="card-img-top" style="height:110px; object-fit:contain;" alt="Aquelle Flavoured Water" />
            <div class="card-body p-2">
                <p class="mb-0 small fw-bold">Aquelle Flavoured Water</p>
                <p class="mb-2 small text-brand fw-bold">R15.00</p>
                <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
            </div>
        </div></div>
                         <div class="col"><div class="card h-100">
                        <img src="~/Content/images/Lamb Sandwich.jpeg"  runat="server" class="card-img-top" style="height:110px; object-fit:contain;" />
                        <div class="card-body p-2">
                            <p class="mb-0 small fw-bold">Lamb Sandwich</p>
                            <p class="mb-2 small text-brand fw-bold">R32.00</p>
                            <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
                        </div>
                    </div></div>

                    <div class="col"><div class="card h-100">
                        <img src="~/Content/images/Fish and Chips Combo.jpeg"  runat="server" class="card-img-top" style="height:110px; object-fit:contain;" />
                        <div class="card-body p-2">
                            <p class="mb-0 small fw-bold">Fish and Chips Combo</p>
                            <p class="mb-2 small text-brand fw-bold">R65.00</p>
                            <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
                        </div>
                    </div></div>

                    <div class="col"><div class="card h-100">
                        <img src="~/Content/images/Wrap.jpeg" class="card-img-top"  runat="server" style="height:110px; object-fit:contain;" />
                        <div class="card-body p-2">
                            <p class="mb-0 small fw-bold">Chicken/Beef Wrap</p>
                            <p class="mb-2 small text-brand fw-bold">R25.00</p>
                            <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
                        </div>
                    </div></div>
    </div>
</div>
                  

            <!-- FOOD -->
            <div class="tab-pane fade" id="tab-food">
            <div class="row row-cols-2 row-cols-md-3 g-3 mb-3">
                <div class="col"><div class="card h-100">
    <img src="~/Content/images/Lamb Sandwich.jpeg"  runat="server" class="card-img-top" style="height:110px; object-fit:contain;" />
    <div class="card-body p-2">
        <p class="mb-0 small fw-bold">Lamb Sandwich</p>
        <p class="mb-2 small text-brand fw-bold">R32.00</p>
        <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
    </div>
</div></div>

<div class="col"><div class="card h-100">
    <img src="~/Content/images/Fish and Chips Combo.jpeg"  runat="server" class="card-img-top" style="height:110px; object-fit:contain;" />
    <div class="card-body p-2">
        <p class="mb-0 small fw-bold">Fish and Chips Combo</p>
        <p class="mb-2 small text-brand fw-bold">R65.00</p>
        <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
    </div>
</div></div>

<div class="col"><div class="card h-100">
    <img src="~/Content/images/Wrap.jpeg" class="card-img-top"  runat="server" style="height:110px; object-fit:contain;" />
    <div class="card-body p-2">
        <p class="mb-0 small fw-bold">Chicken/Beef Wrap</p>
        <p class="mb-2 small text-brand fw-bold">R25.00</p>
        <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
    </div>
</div></div>
                </div>
            </div>

            <!-- BEVERAGES -->
            <div class="tab-pane fade" id="tab-drinks">
                <div class="row row-cols-2 row-cols-md-3 g-3 mb-3">
                        <div class="col"><div class="card h-100">
        <img src="~/Content/images/Coke330.png" runat="server" class="card-img-top" style="height:110px; object-fit:contain;" alt="Coca-Cola 330ml" />
        <div class="card-body p-2">
            <p class="mb-0 small fw-bold">Coca-Cola 330ml</p>
            <p class="mb-2 small text-brand fw-bold">R10.00</p>
            <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
        </div>
    </div></div>

    <div class="col"><div class="card h-100">
        <img src="~/Content/images/Coke440.png" runat="server" class="card-img-top" style="height:110px; object-fit:contain;" alt="Coca-Cola 440ml" />
        <div class="card-body p-2">
            <p class="mb-0 small fw-bold">Coca-Cola 440ml</p>
            <p class="mb-2 small text-brand fw-bold">R15.00</p>
            <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
        </div>
    </div></div>

    <div class="col"><div class="card h-100">
        <img src="~/Content/images/Coke2l.png" runat="server" class="card-img-top" style="height:110px; object-fit:contain;" alt="Coca-Cola 2L" />
        <div class="card-body p-2">
            <p class="mb-0 small fw-bold">Coca-Cola 2l</p>
            <p class="mb-2 small text-brand fw-bold">R30.00</p>
            <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
        </div>
    </div></div>

    <div class="col"><div class="card h-100">
        <img src="~/Content/images/Kingsley.png" runat="server" class="card-img-top" style="height:110px; object-fit:contain;" alt="Kingsley" />
        <div class="card-body p-2">
            <p class="mb-0 small fw-bold">Kingsley</p>
            <p class="mb-2 small text-brand fw-bold">R25.00</p>
            <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
        </div>
    </div></div>

    <div class="col"><div class="card h-100">
        <img src="~/Content/images/Reboost.png" runat="server" class="card-img-top" style="height:110px; object-fit:contain;" alt="Reboost" />
        <div class="card-body p-2">
            <p class="mb-0 small fw-bold">Reboost</p>
            <p class="mb-2 small text-brand fw-bold">R15.00</p>
            <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
        </div>
    </div></div>

    <div class="col"><div class="card h-100">
        <img src="~/Content/images/Monster.png" runat="server" class="card-img-top" style="height:110px; object-fit:contain;" alt="Monster" />
        <div class="card-body p-2">
            <p class="mb-0 small fw-bold">Monster</p>
            <p class="mb-2 small text-brand fw-bold">R20.00</p>
            <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
        </div>
    </div></div>

    <div class="col"><div class="card h-100">
        <img src="~/Content/images/Aquelle.png" runat="server" class="card-img-top" style="height:110px; object-fit:contain;" alt="Aquelle Flavoured Water" />
        <div class="card-body p-2">
            <p class="mb-0 small fw-bold">Aquelle Flavoured Water</p>
            <p class="mb-2 small text-brand fw-bold">R15.00</p>
            <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
        </div>
    </div></div>
                </div>
            </div>

            <!-- COMBO DEALS -->
            <div class="tab-pane fade" id="tab-combos">
                <div class="row row-cols-2 row-cols-md-3 g-3 mb-3">
                    <div class="col"><div class="card h-100">
                       <img src="~/Content/images/Fish and Chips Combo.jpeg"  runat="server" class="card-img-top" style="height:110px; object-fit:contain;" />
                        <div class="card-body p-2">
                            <p class="mb-0 small fw-bold">Breakfast Combo</p>
                            <p class="mb-2 small text-brand fw-bold">R65.00</p>
                            <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
                        </div>
                    </div></div>
                </div>
            </div>

            <!-- SNACKS -->
            <div class="tab-pane fade" id="tab-snacks">
                <div class="row row-cols-2 row-cols-md-3 g-3 mb-3">
                    <div class="col"><div class="card h-100">
                          <img src="~/Content/images/Blueberry muffin .jpeg" runat="server" class="card-img-top" style="height:110px; object-fit:contain;" alt="Muffin" />
                        <div class="card-body p-2">
                            <p class="mb-0 small fw-bold">Blueberry Muffin</p>
                            <p class="mb-2 small text-brand fw-bold">R25.00</p>
                            <button class="btn btn-sm btn-brand w-100 add-to-cart-btn">Add</button>
                        </div>
                    </div></div>
                </div>
            </div>


    <!-- Sticky current cart bar -->
    <div class="position-sticky bottom-0 start-0 w-100 full-bleed px-3 py-3 d-flex justify-content-between align-items-center shadow"
         style="background-color: var(--brand-navy);">
        <span class="text-white fw-bold">
            <span id="cartCount">0</span> item(s) in cart
        </span>
        <a href="~/CartandPayment.aspx" runat="server" class="btn btn-light fw-bold">Proceed to Checkout</a>
    </div>

    <!-- Purely visual cart counter + tab-from-URL behavior — no data is saved -->
    <script>
        // Bump the visible cart counter when "Add" is clicked (visual only, resets on refresh)
        document.querySelectorAll('.add-to-cart-btn').forEach(function (btn) {
            btn.addEventListener('click', function () {
                var counter = document.getElementById('cartCount');
                counter.textContent = parseInt(counter.textContent) + 1;
            });
        });

        // Open the correct tab based on the URL's #hash, e.g. Menu.aspx#tab-drinks
        window.addEventListener('DOMContentLoaded', function () {
            var hash = window.location.hash;
            if (hash) {
                var trigger = document.querySelector('a[href="' + hash + '"]');
                if (trigger) {
                    new bootstrap.Tab(trigger).show();
                }
            }
        });
    </script>

</asp:Content>
