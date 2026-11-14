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
        Select a help category or browse the questions below
        to learn how to use Cafe101.
    </p>
</div>

<!-- CLICKABLE HELP CATEGORY CARDS -->
<div class="row g-3 mb-5">

    <div class="col-md-4 col-lg-3">
        <a href="#loginHelp" class="text-decoration-none text-dark">
            <div class="card h-100 shadow-sm">
                <div class="card-body text-center">
                    <h5>Login &amp; Account</h5>
                    <p class="text-muted mb-0">
                        Signing in, signing out and managing your account.
                    </p>
                </div>
            </div>
        </a>
    </div>

    <div class="col-md-4 col-lg-3">
        <a href="#ordersHelp" class="text-decoration-none text-dark">
            <div class="card h-100 shadow-sm">
                <div class="card-body text-center">
                    <h5>Order Management</h5>
                    <p class="text-muted mb-0">
                        Viewing orders and understanding order statuses.
                    </p>
                </div>
            </div>
        </a>
    </div>

    <div class="col-md-4 col-lg-3">
        <a href="#navigationHelp" class="text-decoration-none text-dark">
            <div class="card h-100 shadow-sm">
                <div class="card-body text-center">
                    <h5>System Navigation</h5>
                    <p class="text-muted mb-0">
                        Finding your dashboard, profile and system features.
                    </p>
                </div>
            </div>
        </a>
    </div>

    <!-- MANAGER-ONLY ADMINISTRATION CARD -->
    <asp:Panel ID="pnlAdministrationCard"
               runat="server"
               Visible="false"
               CssClass="col-md-4 col-lg-3">
    
        <a href="#administrationHelp"
           class="text-decoration-none text-dark">
            <div class="card h-100 shadow-sm">
                <div class="card-body text-center">
                    <h5>Management &amp; Administration</h5>
                    <p class="text-muted mb-0">
                        Employees, ingredients, menu items and recipes.
                    </p>
                </div>
            </div>
        </a>
    </asp:Panel>

    <!-- MANAGER-ONLY REPORTS CARD -->
    <asp:Panel ID="pnlReportsCard" runat="server"
               Visible="false"
               CssClass="col-md-4 col-lg-3">
        <a href="#reportsHelp" class="text-decoration-none text-dark">
            <div class="card h-100 shadow-sm">
                <div class="card-body text-center">
                    <h5>Reports</h5>
                    <p class="text-muted mb-0">
                        Accessing and understanding management reports.
                    </p>
                </div>
            </div>
        </a>
    </asp:Panel>

</div>

<!-- LOGIN AND ACCOUNT -->
<section id="loginHelp" class="mb-5">
    <h4 class="fw-bold mb-2">Login &amp; Account</h4>
    <p class="text-muted">
        Help with accessing and protecting your Cafe101 account.
    </p>

    <div class="accordion" id="loginAccordion">

        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed"
                        type="button" data-bs-toggle="collapse"
                        data-bs-target="#loginAnswer1">
                    How do I log in to Cafe101?
                </button>
            </h2>
            <div id="loginAnswer1" class="accordion-collapse collapse"
                 data-bs-parent="#loginAccordion">
                <div class="accordion-body">
                    Open the Sign In page and enter your registered
                    login credentials. Once authenticated, you will
                    be directed to the dashboard for your role.
                </div>
            </div>
        </div>

        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed"
                        type="button" data-bs-toggle="collapse"
                        data-bs-target="#loginAnswer2">
                    What should I do if I cannot sign in?
                </button>
            </h2>
            <div id="loginAnswer2" class="accordion-collapse collapse"
                 data-bs-parent="#loginAccordion">
                <div class="accordion-body">
                    Check that your login details are correct.
                    If you still cannot access your account,
                    contact your manager or system administrator.
                </div>
            </div>
        </div>

        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed"
                        type="button" data-bs-toggle="collapse"
                        data-bs-target="#loginAnswer3">
                    How do I log out safely?
                </button>
            </h2>
            <div id="loginAnswer3" class="accordion-collapse collapse"
                 data-bs-parent="#loginAccordion">
                <div class="accordion-body">
                    Select Logout at the bottom of the sidebar
                    when you have finished using Cafe101.
                    This ends your current session.
                </div>
            </div>
        </div>

        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed"
                        type="button" data-bs-toggle="collapse"
                        data-bs-target="#loginAnswer4">
                    Where can I view my account information?
                </button>
            </h2>
            <div id="loginAnswer4" class="accordion-collapse collapse"
                 data-bs-parent="#loginAccordion">
                <div class="accordion-body">
                    Select Profile from the sidebar to access
                    your employee account information.
                </div>
            </div>
        </div>

    
        <!-- FORGOTTEN PASSWORD -->
        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed" type="button"
                        data-bs-toggle="collapse" data-bs-target="#loginAnswer5"
                        aria-expanded="false" aria-controls="loginAnswer5">
                    What should I do if I have forgotten my password?
                </button>
            </h2>
            <div id="loginAnswer5" class="accordion-collapse collapse"
                 data-bs-parent="#loginAccordion">
                <div class="accordion-body">
                    <ol class="mb-0">
                        <li class="mb-2">On the Sign In page, select the forgotten password option.</li>
                        <li class="mb-2">Enter the email address linked to your active Cafe101 account.</li>
                        <li class="mb-2">Check your email for a temporary password.</li>
                        <li class="mb-2">Enter the temporary password and choose a new permanent password.</li>
                        <li>Once your password has been updated, Cafe101 will sign you in and take you to the dashboard for your role.</li>
                    </ol>
                    <p class="text-muted mt-3 mb-0">Tip: Keep your temporary password private and check your spam or junk folder if the email does not appear.</p>
                </div>
            </div>
        </div>

    </div>
</section>

<!-- ORDER MANAGEMENT -->
<section id="ordersHelp" class="mb-5">
    <h4 class="fw-bold mb-2">Order Management</h4>
    <p class="text-muted">
        Help with viewing and managing customer orders.
    </p>

    <div class="accordion" id="ordersAccordion">
        <!-- CUSTOMER ORDERING PROCESS -->
<div class="accordion-item">
    <h2 class="accordion-header">
        <button class="accordion-button collapsed"
                type="button"
                data-bs-toggle="collapse"
                data-bs-target="#orderProcessAnswer"
                aria-expanded="false"
                aria-controls="orderProcessAnswer">
            How does a customer place an order on Cafe101?
        </button>
    </h2>

    <div id="orderProcessAnswer"
         class="accordion-collapse collapse"
         data-bs-parent="#ordersAccordion">

        <div class="accordion-body">
            <p>
                Customers can place an order by following
                these simple steps:
            </p>

            <ol>
                <li class="mb-2">
                    <strong>Browse the Menu:</strong>
                    Open the Menu page to explore available
                    food and drinks, including descriptions
                    and prices.
                </li>

                <li class="mb-2">
                    <strong>Add Items to Your Cart:</strong>
                    Select the products you want, choose
                    the quantities, and add them to your cart.
                </li>

                <li class="mb-2">
                    <strong>Review Your Cart:</strong>
                    Check your selected items, quantities,
                    and prices before continuing.
                </li>

                <li class="mb-2">
                    <strong>Proceed to Checkout:</strong>
                    Once you are happy with your selection,
                    continue to checkout.
                </li>

                <li class="mb-2">
                    <strong>Complete Payment:</strong>
                    Follow the payment instructions to
                    complete your purchase.
                </li>

                <li class="mb-2">
                    <strong>Receive Your Receipt:</strong>
                    After successful payment and order
                    processing, you will be directed to
                    a receipt confirming your purchase.
                </li>
            </ol>

            <p class="mb-0 text-muted">
                <strong>Tip:</strong>
                Always double-check your order before
                completing payment.
            </p>
        </div>
    </div>
</div>

        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed"
                        type="button" data-bs-toggle="collapse"
                        data-bs-target="#orderAnswer1">
                    How do I view customer orders?
                </button>
            </h2>
            <div id="orderAnswer1" class="accordion-collapse collapse"
                 data-bs-parent="#ordersAccordion">
                <div class="accordion-body">
                    Select Orders from the sidebar.
                    This opens the order management page
                    where you can view customer orders.
                </div>
            </div>
        </div>

        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed"
                        type="button" data-bs-toggle="collapse"
                        data-bs-target="#orderAnswer2">
                    Where can I check an order's status?
                </button>
            </h2>
            <div id="orderAnswer2" class="accordion-collapse collapse"
                 data-bs-parent="#ordersAccordion">
                <div class="accordion-body">
                    Open Orders and locate the relevant order.
                    Check its displayed status to see its
                    current stage in the order process.
                </div>
            </div>
        </div>

        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed"
                        type="button" data-bs-toggle="collapse"
                        data-bs-target="#orderAnswer3">
                    What should I do if an order has a problem?
                </button>
            </h2>
            <div id="orderAnswer3" class="accordion-collapse collapse"
                 data-bs-parent="#ordersAccordion">
                <div class="accordion-body">
                    Check the order details to identify the issue.
                    If you cannot resolve it using the available
                    order management features, contact your manager.
                </div>
            </div>
        </div>

    </div>
</section>

<!-- SYSTEM NAVIGATION -->
<section id="navigationHelp" class="mb-5">
    <h4 class="fw-bold mb-2">System Navigation</h4>
    <p class="text-muted">
        Learn how to move around the Cafe101 system.
    </p>

    <div class="accordion" id="navigationAccordion">

        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed"
                        type="button" data-bs-toggle="collapse"
                        data-bs-target="#navAnswer1">
                    How do I access my dashboard?
                </button>
            </h2>
            <div id="navAnswer1" class="accordion-collapse collapse"
                 data-bs-parent="#navigationAccordion">
                <div class="accordion-body">
                    Select Dashboard from the sidebar.
                    Cafe101 displays the dashboard associated
                    with your assigned employee role.
                </div>
            </div>
        </div>

        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed"
                        type="button" data-bs-toggle="collapse"
                        data-bs-target="#navAnswer2">
                    Why does my sidebar look different from a Manager's?
                </button>
            </h2>
            <div id="navAnswer2" class="accordion-collapse collapse"
                 data-bs-parent="#navigationAccordion">
                <div class="accordion-body">
                    Cafe101 uses role-based navigation.
                    Managers can access additional management
                    features, while Cashiers and Staff see
                    the features available to their roles.
                </div>
            </div>
        </div>

        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed"
                        type="button" data-bs-toggle="collapse"
                        data-bs-target="#navAnswer3">
                    How do I return to the Help Centre?
                </button>
            </h2>
            <div id="navAnswer3" class="accordion-collapse collapse"
                 data-bs-parent="#navigationAccordion">
                <div class="accordion-body">
                    Select Help Centre from the sidebar.
                    You can return here whenever you need
                    guidance on using Cafe101.
                </div>
            </div>
        </div>

    </div>
</section>

<!-- MANAGER-ONLY ADMINISTRATION HELP -->
<asp:Panel ID="pnlAdministrationHelp"
           runat="server"
           Visible="false">

    <section id="administrationHelp" class="mb-5">
        <h4 class="fw-bold mb-2">Management &amp; Administration</h4>
        <p class="text-muted">
            Learn how to manage employees, ingredients,
            menu items and recipes in Cafe101.
        </p>

        <div class="accordion" id="administrationAccordion">

            <!-- EMPLOYEES -->
            <h5 class="fw-bold mt-4 mb-3">Employee Management</h5>

            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button"
                            data-bs-toggle="collapse"
                            data-bs-target="#adminEmployee1">
                        How do I add a new employee?
                    </button>
                </h2>
                <div id="adminEmployee1" class="accordion-collapse collapse"
                     data-bs-parent="#administrationAccordion">
                    <div class="accordion-body">
                        Open Staff from the Manager sidebar.
                        Enter the employee's first name, surname,
                        email address, physical address, role and password.
                        Make sure all fields are valid and show green,
                        then click <strong>Add</strong>.
                    </div>
                </div>
            </div>

            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button"
                            data-bs-toggle="collapse"
                            data-bs-target="#adminEmployee2">
                        How do I update or delete an employee?
                    </button>
                </h2>
                <div id="adminEmployee2" class="accordion-collapse collapse"
                     data-bs-parent="#administrationAccordion">
                    <div class="accordion-body">
                        To update an employee, select their row,
                        change the relevant details and click
                        <strong>Update</strong>.
                        To delete an employee, select their record,
                        click <strong>Delete</strong> and confirm.
                    </div>
                </div>
            </div>

            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button"
                            data-bs-toggle="collapse"
                            data-bs-target="#adminEmployee3">
                        How do I reset an employee's password?
                    </button>
                </h2>
                <div id="adminEmployee3" class="accordion-collapse collapse"
                     data-bs-parent="#administrationAccordion">
                    <div class="accordion-body">
                        Open Staff, select the employee and click
                        <strong>Reset PW</strong>.
                        The system resets the password to its
                        configured temporary value.
                        Share temporary credentials securely and
                        arrange for the employee to change their password.
                    </div>
                </div>
            </div>

            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button"
                            data-bs-toggle="collapse"
                            data-bs-target="#adminEmployee4">
                        What information is required when adding an employee?
                    </button>
                </h2>
                <div id="adminEmployee4" class="accordion-collapse collapse"
                     data-bs-parent="#administrationAccordion">
                    <div class="accordion-body">
                        First name and surname must contain letters only.
                        Enter a valid email address and a password of
                        at least six characters. The address should follow
                        the format: street number and name, suburb, city.
                        Correct any invalid fields before saving.
                    </div>
                </div>
            </div>

            <!-- INGREDIENTS -->
            <h5 class="fw-bold mt-4 mb-3">Ingredient Management</h5>

            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button"
                            data-bs-toggle="collapse"
                            data-bs-target="#adminIngredient1">
                        How do I add or update an ingredient?
                    </button>
                </h2>
                <div id="adminIngredient1" class="accordion-collapse collapse"
                     data-bs-parent="#administrationAccordion">
                    <div class="accordion-body">
                        Open Ingredients from the Manager sidebar.
                        To add an ingredient, enter its description,
                        quantity on hand, restock level and cost price,
                        then click <strong>Add New</strong>.
                        To update an existing ingredient, select its row,
                        edit the details and click <strong>Update</strong>.
                    </div>
                </div>
            </div>

            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button"
                            data-bs-toggle="collapse"
                            data-bs-target="#adminIngredient2">
                        How do I remove an ingredient?
                    </button>
                </h2>
                <div id="adminIngredient2" class="accordion-collapse collapse"
                     data-bs-parent="#administrationAccordion">
                    <div class="accordion-body">
                        Select the ingredient you want to remove,
                        click <strong>Remove</strong> and confirm
                        your selection.
                    </div>
                </div>
            </div>

            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button"
                            data-bs-toggle="collapse"
                            data-bs-target="#adminIngredient3">
                        What does a yellow ingredient highlight mean?
                    </button>
                </h2>
                <div id="adminIngredient3" class="accordion-collapse collapse"
                     data-bs-parent="#administrationAccordion">
                    <div class="accordion-body">
                        A yellow highlight indicates that the ingredient's
                        available quantity has reached or fallen below its
                        restock level. This means the ingredient needs
                        to be reordered.
                    </div>
                </div>
            </div>

            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button"
                            data-bs-toggle="collapse"
                            data-bs-target="#adminIngredient4">
                        What can I enter as an ingredient description?
                    </button>
                </h2>
                <div id="adminIngredient4" class="accordion-collapse collapse"
                     data-bs-parent="#administrationAccordion">
                    <div class="accordion-body">
                        Ingredient descriptions should contain letters
                        and spaces only. Numbers and special characters
                        are not accepted.
                    </div>
                </div>
            </div>

            <!-- MENU ITEMS -->
            <h5 class="fw-bold mt-4 mb-3">Menu Management</h5>

            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button"
                            data-bs-toggle="collapse"
                            data-bs-target="#adminMenu1">
                        How do I add a new menu item?
                    </button>
                </h2>
                <div id="adminMenu1" class="accordion-collapse collapse"
                     data-bs-parent="#administrationAccordion">
                    <div class="accordion-body">
                        Open Menu from the Manager sidebar.
                        Enter the item name, selling price, cost price,
                        category and preparation time.
                        Click <strong>Add New</strong>, then add at
                        least one ingredient to its recipe.
                    </div>
                </div>
            </div>

            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button"
                            data-bs-toggle="collapse"
                            data-bs-target="#adminMenu2">
                        How do I update or deactivate a menu item?
                    </button>
                </h2>
                <div id="adminMenu2" class="accordion-collapse collapse"
                     data-bs-parent="#administrationAccordion">
                    <div class="accordion-body">
                        Select the menu item from the list.
                        To change its details, edit the fields and
                        click <strong>Update</strong>.
                        To remove it from the available menu,
                        click <strong>Deactivate</strong> and confirm.
                    </div>
                </div>
            </div>

            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button"
                            data-bs-toggle="collapse"
                            data-bs-target="#adminMenu3">
                        What are the menu item requirements?
                    </button>
                </h2>
                <div id="adminMenu3" class="accordion-collapse collapse"
                     data-bs-parent="#administrationAccordion">
                    <div class="accordion-body">
                        Menu item names must contain letters and spaces only.
                        Preparation time must be a whole number between
                        1 and 999 minutes. Available categories are
                        Burger, Wings, Sides, Drinks and Combo.
                        Each menu item must have at least one
                        recipe ingredient.
                    </div>
                </div>
            </div>

            <!-- RECIPES -->
            <h5 class="fw-bold mt-4 mb-3">Recipe Management</h5>

            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button"
                            data-bs-toggle="collapse"
                            data-bs-target="#adminRecipe1">
                        What are recipes used for?
                    </button>
                </h2>
                <div id="adminRecipe1" class="accordion-collapse collapse"
                     data-bs-parent="#administrationAccordion">
                    <div class="accordion-body">
                        Recipes show which ingredients are needed
                        to prepare each menu item and the quantity
                        of each ingredient required.
                    </div>
                </div>
            </div>

            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button"
                            data-bs-toggle="collapse"
                            data-bs-target="#adminRecipe2">
                        How do I add an ingredient to a recipe?
                    </button>
                </h2>
                <div id="adminRecipe2" class="accordion-collapse collapse"
                     data-bs-parent="#administrationAccordion">
                    <div class="accordion-body">
                        Open Recipes from the Manager sidebar.
                        Select the menu item, choose the ingredient,
                        enter the required quantity and click
                        <strong>Add</strong>.
                    </div>
                </div>
            </div>

            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button"
                            data-bs-toggle="collapse"
                            data-bs-target="#adminRecipe3">
                        How do I remove or change a recipe ingredient?
                    </button>
                </h2>
                <div id="adminRecipe3" class="accordion-collapse collapse"
                     data-bs-parent="#administrationAccordion">
                    <div class="accordion-body">
                        To remove an ingredient, select the menu item
                        and ingredient, then click <strong>Remove</strong>.
                        To change a quantity, remove the existing
                        recipe entry and add it again with the
                        corrected quantity.
                    </div>
                </div>
            </div>

        </div>
    </section>
</asp:Panel>

<!-- MANAGER-ONLY REPORTS -->
<asp:Panel ID="pnlReportsHelp" runat="server"
           Visible="false">

    <section id="reportsHelp" class="mb-5">
        <h4 class="fw-bold mb-2">Reports</h4>
        <p class="text-muted">
            Guidance on accessing and reviewing management reports.
        </p>

        <div class="accordion" id="reportsAccordion">

            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed"
                            type="button" data-bs-toggle="collapse"
                            data-bs-target="#reportAnswer1">
                        How do I access reports?
                    </button>
                </h2>
                <div id="reportAnswer1" class="accordion-collapse collapse"
                     data-bs-parent="#reportsAccordion">
                    <div class="accordion-body">
                        Sign in with a Manager account and
                        select Reports from the sidebar.
                        This opens the Manager Reports page.
                    </div>
                </div>
            </div>

            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed"
                            type="button" data-bs-toggle="collapse"
                            data-bs-target="#reportAnswer2">
                        Why can't Cashiers access reports?
                    </button>
                </h2>
                <div id="reportAnswer2" class="accordion-collapse collapse"
                     data-bs-parent="#reportsAccordion">
                    <div class="accordion-body">
                        Reports contain management information.
                        Access is restricted to authorised Managers
                        according to the user's assigned role.
                    </div>
                </div>
            </div>

        
        <!-- REPORT DATE RANGE AND METRICS -->
        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed" type="button"
                        data-bs-toggle="collapse" data-bs-target="#reportAnswer3"
                        aria-expanded="false" aria-controls="reportAnswer3">
                    How do I view performance for a specific date range?
                </button>
            </h2>
            <div id="reportAnswer3" class="accordion-collapse collapse"
                 data-bs-parent="#reportsAccordion">
                <div class="accordion-body">
                    Open Reports from the Manager sidebar and select the date range you want to review. The page displays Total Revenue, Orders Completed and Average Order Value for the selected period.
                </div>
            </div>
        </div>

        <!-- REPORT CHARTS -->
        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed" type="button"
                        data-bs-toggle="collapse" data-bs-target="#reportAnswer4"
                        aria-expanded="false" aria-controls="reportAnswer4">
                    What do the report charts show?
                </button>
            </h2>
            <div id="reportAnswer4" class="accordion-collapse collapse"
                 data-bs-parent="#reportsAccordion">
                <div class="accordion-body">
                    <strong>Revenue Overview</strong> helps you see how sales revenue changes over time. <strong>Sales by Category</strong> shows how sales are distributed across the different menu categories. Use these charts to spot trends and compare performance.
                </div>
            </div>
        </div>

        <!-- PDF REPORT -->
        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed" type="button"
                        data-bs-toggle="collapse" data-bs-target="#reportAnswer5"
                        aria-expanded="false" aria-controls="reportAnswer5">
                    How do I generate a PDF report?
                </button>
            </h2>
            <div id="reportAnswer5" class="accordion-collapse collapse"
                 data-bs-parent="#reportsAccordion">
                <div class="accordion-body">
                    Open Reports, choose the date range you need and use the page's PDF report option to generate a report for that period.
                </div>
            </div>
        </div>

        <!-- EMAIL REPORT -->
        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed" type="button"
                        data-bs-toggle="collapse" data-bs-target="#reportAnswer6"
                        aria-expanded="false" aria-controls="reportAnswer6">
                    Can I send a report to my email?
                </button>
            </h2>
            <div id="reportAnswer6" class="accordion-collapse collapse"
                 data-bs-parent="#reportsAccordion">
                <div class="accordion-body">
                    Yes. On the Reports page, select your date range and use the email report option to send the generated PDF to your email address.
                </div>
            </div>
        </div>

    </div>
    </section>

</asp:Panel>

</div> <!-- End Help Centre container -->
</main>
    </div>
</div>
</asp:Content>
