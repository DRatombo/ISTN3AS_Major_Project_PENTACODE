<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerDashboard.aspx.cs" Inherits="Cafe101.Web.CustomerDashboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        #mainNavbar { display: none; }
    </style>

    <!-- Top bar -->
   <div class="d-flex align-items-center justify-content-between py-3 full-bleed px-3" 
     style="background-color: var(--brand-navy);">
    <div class="d-flex align-items-center">
        <button class="btn p-0 border-0" type="button" 
                data-bs-toggle="offcanvas" 
                data-bs-target="#sideMenu">
            <span style="font-size: 1.5rem; color: #fff;">&#9776;</span>
        </button>
        <span class="fw-bold text-white ms-3" 
              style="font-size: 1.25rem;">
            Cafe101
        </span>
    </div>
   <!-- Customer profile and cart -->
<div class="d-flex align-items-center gap-4">

   <!-- Customer Profile -->
<a href="~/MyAccount.aspx"
   runat="server"
   class="text-decoration-none">

    <div class="d-flex align-items-center text-white">

        <!-- Profile Initial -->
        <div class="rounded-circle bg-white text-dark
                    d-flex align-items-center justify-content-center me-2"
             style="width: 38px;
                    height: 38px;
                    font-weight: bold;
                    cursor: pointer;">

            <asp:Label
                ID="lblCustomerInitials"
                runat="server">
            </asp:Label>

        </div>

        <!-- Customer Name -->
        <div class="d-flex flex-column"
             style="cursor: pointer;">

            <strong>
                <asp:Label
                    ID="lblTopCustomerName"
                    runat="server">
                </asp:Label>
            </strong>

            <small>Customer</small>

        </div>

    </div>

</a>


    <!-- Cart -->
    <div>

        <a href="~/CartandPayment.aspx"
           runat="server"
           class="btn p-0 border-0 position-relative">

            <span style="font-size: 1.4rem; color: #fff;">
                &#128722;
            </span>

            <span class="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-danger"
                  style="font-size: 0.6rem;">
                2
            </span>

        </a>

    </div>

</div>

</div>
       
    <!-- Welcome message -->
    <div class="container pt-4">
        <h4 class="fw-bold mb-4">Welcome back, <asp:Literal ID="litFirstName" runat="server" Text="Guest" /> 👋</h4>
    </div>

    <!-- Side menu -->
    <div class="offcanvas offcanvas-start" tabindex="-1" id="sideMenu">
        <div class="offcanvas-header" style="background-color: var(--brand-navy);">
            <h5 class="offcanvas-title text-white">Cafe101</h5>
            <button type="button" class="btn-close btn-close-white" data-bs-dismiss="offcanvas"></button>
        </div>
        <div class="offcanvas-body p-0">
            <a href="~/MyAccount.aspx" runat="server" class="d-block px-4 py-3 text-dark text-decoration-none border-bottom">My Account</a>
            <a href="~/OrderHistory.aspx" runat="server" class="d-block px-4 py-3 text-dark text-decoration-none border-bottom">Order History</a>
            <asp:LinkButton ID="lnkLogOut" runat="server" CssClass="d-block px-4 py-3 text-danger text-decoration-none w-100 text-start border-0 bg-transparent" OnClick="lnkLogOut_Click">Log Out</asp:LinkButton>
        </div>
    </div>

    <div class="container">

        <!-- Search bar -->
        <div class="mb-4">
            <div class="input-group">
                <span class="input-group-text bg-white border-end-0">&#128269;</span>
                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control border-start-0" placeholder="Search for menu items..." />
            </div>
        </div>

        <!-- Hero promo banner -->
        <div class="position-relative rounded overflow-hidden mb-4" style="min-height: 200px;">
            <img src="~/Content/images/Fish and Chips Combo.jpeg" runat="server" alt="Promo banner" class="w-100 h-100" style="object-fit: cover;" />
            <div class="position-absolute top-50 start-0 translate-middle-y ps-4">
                <p class="text-white small mb-1">Today's Special</p>
                <h3 class="text-white fw-bold">20% Off Combos</h3>
                <a href="~/Menu.aspx?cat=combos" runat="server" class="btn btn-light btn-sm fw-bold mt-2">Order Now</a>
            </div>
        </div>

        <!-- Category buttons -->
       <div class="d-flex justify-content-between mb-4 flex-wrap gap-3">
    <a href="~/Menu.aspx#tab-drinks" runat="server" class="text-decoration-none text-center">
        <div class="rounded-circle d-flex align-items-center justify-content-center mx-auto mb-1" style="width:60px; height:60px; background-color:#fde4e4; font-size:1.5rem;">&#129380;</div>
        <small class="text-dark">Cool Drinks</small>
    </a>
    <a href="~/Menu.aspx#tab-food" runat="server" class="text-decoration-none text-center">
        <div class="rounded-circle d-flex align-items-center justify-content-center mx-auto mb-1" style="width:60px; height:60px; background-color:#e4f0fd; font-size:1.5rem;">&#127831;</div>
        <small class="text-dark">Food</small>
    </a>
    <a href="~/Menu.aspx#tab-combos" runat="server" class="text-decoration-none text-center">
        <div class="rounded-circle d-flex align-items-center justify-content-center mx-auto mb-1" style="width:60px; height:60px; background-color:#fdf3e4; font-size:1.5rem;">&#127828;</div>
        <small class="text-dark">Combo Deals</small>
    </a>
    <a href="~/Menu.aspx#tab-snacks" runat="server" class="text-decoration-none text-center">
        <div class="rounded-circle d-flex align-items-center justify-content-center mx-auto mb-1" style="width:60px; height:60px; background-color:#e4fdea; font-size:1.5rem;">&#127853;</div>
        <small class="text-dark">Snacks</small>
    </a>
</div>

        <!-- Popular Items — real carousel -->
        <h5 class="fw-bold text-brand mb-2">Popular Items</h5>
        <div id="popularCarousel" class="carousel slide mb-5" data-bs-ride="carousel" data-bs-interval="3000">
            <div class="carousel-inner rounded">
                <div class="carousel-item active">
                    <img src="~/Content/images/Chicken fillet.jpeg" runat="server" class="d-block w-100" alt="Chicken Fillet">
                    <div class="carousel-caption bg-dark bg-opacity-50 rounded py-1">
                        <p class="mb-0 fw-bold">Chicken Fillet — R35.00</p>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="~/Content/images/Lamb Sandwich.jpeg" runat="server" class="d-block w-100" alt="Lamb Sandwich">
                    <div class="carousel-caption bg-dark bg-opacity-50 rounded py-1">
                        <p class="mb-0 fw-bold">Lamb Sandwich — R28.00</p>
                    </div>
                </div>
                <div class="carousel-item">
                   <img src="~/Content/images/Wings and Chips.jpeg" runat="server" class="d-block w-100" alt="Wings and Chips">
                    <div class="carousel-caption bg-dark bg-opacity-50 rounded py-1">
                        <p class="mb-0 fw-bold">Wings and Chips — R42.00</p>
                    </div>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#popularCarousel" data-bs-slide="prev">
                <span class="carousel-control-prev-icon"></span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#popularCarousel" data-bs-slide="next">
                <span class="carousel-control-next-icon"></span>
            </button>
        </div>

        <!-- Menu — the only "View All" link, items show in the order they are coded -->
        <div class="d-flex justify-content-between align-items-center mb-2">
            <h5 class="fw-bold text-brand mb-0">Menu</h5>
            <a href="~/Menu.aspx" runat="server" class="small text-brand">View All &rarr;</a>
        </div>
        <div class="d-flex overflow-auto gap-3 mb-5 pb-2" style="scroll-snap-type: x mandatory;">
            <div class="card flex-shrink-0" style="width: 160px; scroll-snap-align: start;">
               <img src="~/Content/images/Lamb Sandwich.jpeg"  runat="server" class="card-img-top" style="height:110px; object-fit:contain;" />
                <div class="card-body p-2">
                    <p class="mb-0 small fw-bold">Lamb Sandwich</p>
                    <p class="mb-0 small text-brand fw-bold">R32.00</p>
                </div>
            </div>
             <div class="card flex-shrink-0" style="width: 160px; scroll-snap-align: start;">
       <img src="~/Content/images/Blueberry muffin .jpeg" runat="server" class="card-img-top" style="height:110px; object-fit:contain;" />
     <div class="card-body p-2">
         <p class="mb-0 small fw-bold"> Blueberry Muffin</p>
         <p class="mb-0 small text-brand fw-bold">R25.00</p>
     </div>
 </div>
            <div class="card flex-shrink-0" style="width: 160px; scroll-snap-align: start;">
                  <img src="~/Content/images/Fish and Chips Combo.jpeg"  runat="server" class="card-img-top" style="height:110px; object-fit:contain;" />
                <div class="card-body p-2">
                    <p class="mb-0 small fw-bold">Fish and Chips Combo</p>
                    <p class="mb-0 small text-brand fw-bold">R65.00</p>
                </div>
            </div>
             <div class="card flex-shrink-0" style="width: 160px; scroll-snap-align: start;">
  <img src="~/Content/images/Reboost.png" runat="server" class="card-img-top" style="height:110px; object-fit:contain;" alt="Reboost" />
     <div class="card-body p-2">
         <p class="mb-0 small fw-bold">Energy Drink</p>
         <p class="mb-0 small text-brand fw-bold">R15.00</p>
     </div>
 </div>
 <div class="card flex-shrink-0" style="width: 160px; scroll-snap-align: start;">
       <img src="~/Content/images/Kingsley.png" runat="server" class="card-img-top" style="height:110px; object-fit:contain;" alt="Kingsley" />
     <div class="card-body p-2">
         <p class="mb-0 small fw-bold">Soft Drink</p>
         <p class="mb-0 small text-brand fw-bold">R25.00</p>
     </div>
 </div>
             <div class="card flex-shrink-0" style="width: 160px; scroll-snap-align: start;">
       <img src="~/Content/images/Coke330.png" runat="server" class="card-img-top" style="height:110px; object-fit:contain;" alt="Coca-Cola 330ml" />
     <div class="card-body p-2">
         <p class="mb-0 small fw-bold">Cooldrink</p>
         <p class="mb-0 small text-brand fw-bold">R10.00</p>
     </div>
 </div>

        </div>

    </div>

</asp:Content>