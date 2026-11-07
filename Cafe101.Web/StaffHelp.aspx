<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffHelp.aspx.cs" Inherits="Cafe101.Web.StaffHelp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<div class="staff-shell">

    <header class="staff-header">
        <div class="staff-header-left">
            <div class="staff-header-brand">
                Cafe101
            </div>
        </div>

       

<div class="staff-header-user"
     style="display:flex; align-items:center; gap:10px;">

    <%-- Employee initials circle --%>
    <div style="width:40px; height:40px;
                border-radius:50%;
                background:white;
                color:#142b4d;
                display:flex;
                align-items:center;
                justify-content:center;
                font-weight:700;">

        <asp:Label
            ID="lblTopInitials"
            runat="server" />

    </div>

    <%-- Employee name and role --%>
    <div style="display:flex; flex-direction:column;">

        <asp:Label
            ID="lblLoggedInUser"
            runat="server"
            ForeColor="#0D6EFD"
            Font-Bold="true" />

        <asp:Label
            ID="lblTopRole"
            runat="server"
            ForeColor="#FFFFFF"
            Font-Size="Small" />

    </div>

</div>


    </header>

    <div class="staff-body">

        <aside class="staff-sidebar">

            <asp:Panel ID="pnlStaffNavigation"
                       runat="server">

                <div class="staff-sidebar-title">
                    STAFF SYSTEM
                </div>

              
<nav class="staff-nav" aria-label="Staff navigation">

    <%-- Dashboard --%>
    <a href="StaffDashboard.aspx" aria-label="Dashboard">
        <span class="staff-nav-icon" aria-hidden="true">
            <svg viewBox="0 0 24 24" width="19" height="19"
                 fill="none" stroke="currentColor" stroke-width="2">
                <path d="M3 10l9-7 9 7M5 9v12h14V9M9 21v-8h6v8" />
            </svg>
        </span>
        <span class="staff-nav-text">Dashboard</span>
    </a>

    <%-- Orders --%>
    <a href="StaffOrders.aspx" aria-label="Orders">
        <span class="staff-nav-icon" aria-hidden="true">
            <svg viewBox="0 0 24 24" width="19" height="19"
                 fill="none" stroke="currentColor" stroke-width="2">
                <path d="M6 3h12v18H6zM9 8h6M9 12h6M9 16h4" />
            </svg>
        </span>
        <span class="staff-nav-text">Orders</span>
    </a>

    <%-- Profile --%>
    <a href="StaffProfile.aspx" aria-label="Profile">
        <span class="staff-nav-icon" aria-hidden="true">
            <svg viewBox="0 0 24 24" width="19" height="19"
                 fill="none" stroke="currentColor" stroke-width="2">
                <circle cx="12" cy="8" r="4" />
                <path d="M4 21c0-4 3.5-7 8-7s8 3 8 7" />
            </svg>
        </span>
        <span class="staff-nav-text">Profile</span>
    </a>

    <%-- Help Centre --%>
    <a href="StaffHelp.aspx" class="active"
       aria-current="page" aria-label="Help Centre">
        <span class="staff-nav-icon" aria-hidden="true">
            <svg viewBox="0 0 24 24" width="19" height="19"
                 fill="none" stroke="currentColor" stroke-width="2">
                <circle cx="12" cy="12" r="9" />
                <path d="M9.5 9a2.5 2.5 0 0 1 5 0c0 2-2.5 2-2.5 4" />
                <path d="M12 17h.01" />
            </svg>
        </span>
        <span class="staff-nav-text">Help Centre</span>
    </a>

</nav>


            </asp:Panel>

            <asp:Panel ID="pnlManagerNavigation"
                       runat="server"
                       Visible="false">

                <div class="staff-sidebar-title">
                    MANAGER SYSTEM
                </div>

   
<nav class="staff-nav" aria-label="Manager navigation">

    <%-- Dashboard --%>
    <a href="ManagerDashboard.aspx" aria-label="Dashboard">
        <span class="staff-nav-icon" aria-hidden="true">
            <svg viewBox="0 0 24 24" width="19" height="19"
                 fill="none" stroke="currentColor" stroke-width="2">
                <path d="M3 10l9-7 9 7M5 9v12h14V9M9 21v-8h6v8" />
            </svg>
        </span>
        <span class="staff-nav-text">Dashboard</span>
    </a>

    <%-- Orders --%>
    <a href="ManagerOrders.aspx" aria-label="Orders">
        <span class="staff-nav-icon" aria-hidden="true">
            <svg viewBox="0 0 24 24" width="19" height="19"
                 fill="none" stroke="currentColor" stroke-width="2">
                <path d="M6 3h12v18H6zM9 8h6M9 12h6M9 16h4" />
            </svg>
        </span>
        <span class="staff-nav-text">Orders</span>
    </a>

    <%-- Customers --%>
    <a href="ManageCustomers.aspx" aria-label="Customers">
        <span class="staff-nav-icon" aria-hidden="true">
            <svg viewBox="0 0 24 24" width="19" height="19"
                 fill="none" stroke="currentColor" stroke-width="2">
                <circle cx="9" cy="8" r="3" />
                <path d="M3 20v-2a6 6 0 0 1 12 0v2" />
                <path d="M17 5a3 3 0 0 1 0 6M18 14a5 5 0 0 1 3 5" />
            </svg>
        </span>
        <span class="staff-nav-text">Customers</span>
    </a>

    <%-- Menu --%>
    <a href="ManagerMenu.aspx" aria-label="Menu">
        <span class="staff-nav-icon" aria-hidden="true">
            <svg viewBox="0 0 24 24" width="19" height="19"
                 fill="none" stroke="currentColor" stroke-width="2">
                <path d="M5 4h14v16H5zM9 8h6M9 12h6M9 16h6" />
            </svg>
        </span>
        <span class="staff-nav-text">Menu</span>
    </a>

    <%-- Ingredients --%>
    <a href="ManageIngredients.aspx" aria-label="Ingredients">
        <span class="staff-nav-icon" aria-hidden="true">
            <svg viewBox="0 0 24 24" width="19" height="19"
                 fill="none" stroke="currentColor" stroke-width="2">
                <path d="M3 6h18v3H3zM5 9v11h14V9M9 13h6" />
            </svg>
        </span>
        <span class="staff-nav-text">Ingredients</span>
    </a>

    <%-- Recipes --%>
    <a href="ManageRecipes.aspx" aria-label="Recipes">
        <span class="staff-nav-icon" aria-hidden="true">
            <svg viewBox="0 0 24 24" width="19" height="19"
                 fill="none" stroke="currentColor" stroke-width="2">
                <path d="M6 3h12v18H6zM9 8h6M9 12h6M9 16h4" />
            </svg>
        </span>
        <span class="staff-nav-text">Recipes</span>
    </a>

    <%-- Staff --%>
    <a href="ManagerStaff.aspx" aria-label="Staff">
        <span class="staff-nav-icon" aria-hidden="true">
            <svg viewBox="0 0 24 24" width="19" height="19"
                 fill="none" stroke="currentColor" stroke-width="2">
                <circle cx="9" cy="8" r="3" />
                <circle cx="17" cy="9" r="2" />
                <path d="M3 20v-2a6 6 0 0 1 12 0v2M16 15a4 4 0 0 1 5 4" />
            </svg>
        </span>
        <span class="staff-nav-text">Staff</span>
    </a>

    <%-- Reports --%>
    <a href="ManagerReports.aspx" aria-label="Reports">
        <span class="staff-nav-icon" aria-hidden="true">
            <svg viewBox="0 0 24 24" width="19" height="19"
                 fill="none" stroke="currentColor" stroke-width="2">
                <path d="M4 20h16M7 17v-5M12 17V5M17 17V9" />
            </svg>
        </span>
        <span class="staff-nav-text">Reports</span>
    </a>

    <%-- Profile --%>
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

    <%-- Help Centre --%>
    <a href="StaffHelp.aspx" class="active"
       aria-current="page" aria-label="Help Centre">
        <span class="staff-nav-icon" aria-hidden="true">
            <svg viewBox="0 0 24 24" width="19" height="19"
                 fill="none" stroke="currentColor" stroke-width="2">
                <circle cx="12" cy="12" r="9" />
                <path d="M9.5 9a2.5 2.5 0 0 1 5 0c0 2-2.5 2-2.5 4" />
                <path d="M12 17h.01" />
            </svg>
        </span>
        <span class="staff-nav-text">Help Centre</span>
    </a>

</nav>


            </asp:Panel>

       
                </nav>

            </asp:Panel>

            <%-- Shared Logout for Manager, Staff and Cashier --%>
            <div class="staff-sidebar-bottom">
                <asp:LinkButton
                    ID="lnkLogout"
                    runat="server"
                    CssClass="staff-logout"
                    OnClick="LnkLogout_Click"
                    CausesValidation="false">

                    <span class="staff-nav-icon" aria-hidden="true">
                        &#10140;
                    </span>

                    <span class="staff-nav-text">
                        Logout
                    </span>

                </asp:LinkButton>
            </div>

        </aside>

        <main class="staff-main">


  
<div class="container py-4 pb-5">

    <!-- PAGE HEADING -->
    <div class="mb-4">
        <h2 class="fw-bold">Staff Help Centre</h2>
        <p class="text-muted">
            Find answers to common questions and learn
            how to use the Cafe101 staff system.
        </p>
    </div>

    <!-- HELP CATEGORIES -->
    <div class="row g-3 mb-4">

        <div class="col-md-4">
            <div class="card h-100 shadow-sm">
                <div class="card-body">
                    <h5>Staff Dashboard</h5>
                    <p class="text-muted mb-0">
                        Learn how to navigate your dashboard
                        and access staff features.
                    </p>
                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="card h-100 shadow-sm">
                <div class="card-body">
                    <h5>Order Management</h5>
                    <p class="text-muted mb-0">
                        Learn how to view orders and manage
                        customer requests.
                    </p>
                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="card h-100 shadow-sm">
                <div class="card-body">
                    <h5>Account &amp; Security</h5>
                    <p class="text-muted mb-0">
                        Get help with signing in, signing
                        out, and protecting your account.
                    </p>
                </div>
            </div>
        </div>

    </div>

    <!-- FREQUENTLY ASKED QUESTIONS -->
    <h4 class="fw-bold mb-3">
        Frequently Asked Questions
    </h4>

    <div class="accordion mb-4" id="staffHelpAccordion">

        <!-- QUESTION 1 -->
        <div class="accordion-item">
            <h2 class="accordion-header" id="helpHeading1">
                <button class="accordion-button"
                        type="button"
                        data-bs-toggle="collapse"
                        data-bs-target="#helpAnswer1"
                        aria-expanded="true"
                        aria-controls="helpAnswer1">
                    How do I access the staff dashboard?
                </button>
            </h2>

            <div id="helpAnswer1"
                 class="accordion-collapse collapse show"
                 data-bs-parent="#staffHelpAccordion">
                <div class="accordion-body">
                    Sign in using your staff credentials.
                    Once authenticated, navigate to the
                    Staff Dashboard to access the features
                    available to your role.
                </div>
            </div>
        </div>

        <!-- QUESTION 2 -->
        <div class="accordion-item">
            <h2 class="accordion-header" id="helpHeading2">
                <button class="accordion-button collapsed"
                        type="button"
                        data-bs-toggle="collapse"
                        data-bs-target="#helpAnswer2"
                        aria-expanded="false"
                        aria-controls="helpAnswer2">
                    How do I view customer orders?
                </button>
            </h2>

            <div id="helpAnswer2"
                 class="accordion-collapse collapse"
                 data-bs-parent="#staffHelpAccordion">
                <div class="accordion-body">
                    Open the Orders section from the staff
                    navigation menu. This section is used
                    to view customer order information.
                </div>
            </div>
        </div>

        <!-- QUESTION 3 -->
        <div class="accordion-item">
            <h2 class="accordion-header" id="helpHeading3">
                <button class="accordion-button collapsed"
                        type="button"
                        data-bs-toggle="collapse"
                        data-bs-target="#helpAnswer3"
                        aria-expanded="false"
                        aria-controls="helpAnswer3">
                    What should I do if I cannot sign in?
                </button>
            </h2>

            <div id="helpAnswer3"
                 class="accordion-collapse collapse"
                 data-bs-parent="#staffHelpAccordion">
                <div class="accordion-body">
                    Check that your login details are correct.
                    If you still cannot access your account,
                    contact the system administrator or manager
                    for assistance.
                </div>
            </div>
        </div>

        <!-- QUESTION 4 -->
        <div class="accordion-item">
            <h2 class="accordion-header" id="helpHeading4">
                <button class="accordion-button collapsed"
                        type="button"
                        data-bs-toggle="collapse"
                        data-bs-target="#helpAnswer4"
                        aria-expanded="false"
                        aria-controls="helpAnswer4">
                    How do I sign out safely?
                </button>
            </h2>

            <div id="helpAnswer4"
                 class="accordion-collapse collapse"
                 data-bs-parent="#staffHelpAccordion">
                <div class="accordion-body">
                    Select the Logout option when you finish
                    using the system, especially when working
                    on a shared computer.
                </div>
            </div>
        </div>

    </div>

</div>
        </main>
    </div>
</div>
</asp:Content>
