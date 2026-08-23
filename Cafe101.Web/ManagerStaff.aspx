<%@ Page Title="Staff Management"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ManagerStaff.aspx.cs"
    Inherits="Cafe101.Web.ManagerStaff" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div class="staff-shell manager-shell">

        <%-- =================================================
             TOP HEADER
             ================================================= --%>

        <header class="staff-header">

            <div class="staff-header-left">

                <button type="button"
                    id="sidebarToggle"
                    class="staff-header-menu"
                    aria-label="Toggle manager navigation">
                    ☰
                </button>

                <div class="staff-header-brand">
                    Cafe101
                </div>

            </div>


            <div class="staff-header-user">

                <div class="staff-header-avatar">
                    MA
                </div>

                <div>
                    <strong>Manager</strong>
                    <small>Administrator</small>
                </div>

            </div>

        </header>


        <div class="staff-body">

            <%-- =================================================
                 MANAGER SIDEBAR
                 ================================================= --%>

            <aside class="staff-sidebar">

                <div class="staff-sidebar-title">
                    MANAGER SYSTEM
                </div>


                <nav class="staff-nav">

                    <%-- Dashboard --%>
                    <a href="ManagerDashboard.aspx">

                        <span class="staff-nav-icon">&#8962;
                        </span>

                        <span class="staff-nav-text">Dashboard
                        </span>

                    </a>


                    <%-- Orders --%>
                    <a href="ManagerOrders.aspx">

                        <span class="staff-nav-icon">

                            <svg viewBox="0 0 24 24"
                                width="19"
                                height="19"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <path d="M6 3h12v18H6z" />
                                <path d="M9 8h6" />
                                <path d="M9 12h6" />
                                <path d="M9 16h4" />

                            </svg>

                        </span>

                        <span class="staff-nav-text">Orders
                        </span>

                    </a>


                    <%-- Menu --%>
                    <a href="ManagerMenu.aspx">

                        <span class="staff-nav-icon">

                            <svg viewBox="0 0 24 24"
                                width="19"
                                height="19"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <path d="M4 4h16v16H4z" />
                                <path d="M8 8h8" />
                                <path d="M8 12h8" />
                                <path d="M8 16h5" />

                            </svg>

                        </span>

                        <span class="staff-nav-text">Menu
                        </span>

                    </a>


                    <%-- Staff --%>
                    <a href="ManagerStaff.aspx"
                        class="active">

                        <span class="staff-nav-icon">

                            <svg viewBox="0 0 24 24"
                                width="19"
                                height="19"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <circle cx="9" cy="8" r="3" />
                                <circle cx="17" cy="10" r="2" />

                                <path d="M3 20c0-4 2.5-7 6-7s6 3 6 7" />
                                <path d="M15 15c3 0 5 2 5 5" />

                            </svg>

                        </span>

                        <span class="staff-nav-text">Staff
                        </span>

                    </a>


                    <%-- Reports --%>
                    <a href="ManagerReports.aspx">

                        <span class="staff-nav-icon">

                            <svg viewBox="0 0 24 24"
                                width="19"
                                height="19"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <path d="M4 20V10" />
                                <path d="M10 20V4" />
                                <path d="M16 20v-7" />
                                <path d="M22 20H2" />

                            </svg>

                        </span>

                        <span class="staff-nav-text">Reports
                        </span>

                    </a>


                    <%-- Profile --%>
                    <a href="ManagerProfile.aspx">

                        <span class="staff-nav-icon">

                            <svg viewBox="0 0 24 24"
                                width="19"
                                height="19"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <circle cx="12" cy="8" r="4" />

                                <path d="M4 21c0-4 3.5-7 8-7s8 3 8 7" />

                            </svg>

                        </span>

                        <span class="staff-nav-text">Profile
                        </span>

                    </a>

                </nav>


                <%-- Logout --%>
                <div class="staff-sidebar-bottom">

                    <a href="#"
                        class="staff-logout">

                        <span class="staff-nav-icon">&#10140;
                        </span>

                        <span class="staff-nav-text">Logout
                        </span>

                    </a>

                </div>

            </aside>


            <%-- =================================================
                 MAIN STAFF MANAGEMENT AREA
                 ================================================= --%>

            <main class="staff-main">

                <%-- =================================================
                     PAGE HEADING
                     ================================================= --%>

                <div class="staff-page-heading">

                    <h3>Staff Management
                    </h3>

                    <p>
                        Manage employee accounts, roles and shift assignments.
                    </p>

                </div>


                <%-- =================================================
                     STAFF TOOLBAR
                     ================================================= --%>

                <div class="manager-staff-toolbar">

                    <div class="manager-staff-toolbar-left">

                        <%-- Search --%>
                        <div class="staff-search-box">

                            <span class="staff-search-icon">

                                <svg viewBox="0 0 24 24"
                                    width="18"
                                    height="18"
                                    fill="none"
                                    stroke="currentColor"
                                    stroke-width="2">

                                    <circle cx="10"
                                        cy="10"
                                        r="6" />

                                    <path d="M15 15l5 5" />

                                </svg>

                            </span>

                            <input type="text"
                                class="form-control"
                                placeholder="Search by name, ID or email..." />

                        </div>


                        <%-- Role filter --%>
                        <select class="form-control manager-staff-filter">

                            <option>All Roles</option>
                            <option>Shift Supervisor</option>
                            <option>Barista</option>
                            <option>Cashier</option>
                            <option>Kitchen Staff</option>
                            <option>Cleaner</option>

                        </select>


                        <%-- Status filter --%>
                        <select class="form-control manager-staff-filter">

                            <option>All Statuses</option>
                            <option>Active</option>
                            <option>On Leave</option>
                            <option>Off Duty</option>
                            <option>Inactive</option>

                        </select>

                    </div>


                    <div class="manager-staff-toolbar-right">

                        <button type="button"
                            class="btn btn-brand">
                            + Add New Staff

                        </button>

                        <button type="button"
                            class="btn btn-outline-brand">
                            ↻ Refresh

                        </button>

                    </div>

                </div>


                <%-- =================================================
                     STAFF SUMMARY CARDS
                     ================================================= --%>

                <div class="staff-metric-grid">

                    <%-- Total Staff --%>
                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-green">

                            <svg viewBox="0 0 24 24"
                                width="23"
                                height="23"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <circle cx="9" cy="8" r="3" />
                                <circle cx="17" cy="10" r="2" />
                                <path d="M3 20c0-4 2.5-7 6-7s6 3 6 7" />
                                <path d="M15 15c3 0 5 2 5 5" />

                            </svg>

                        </div>

                        <div>

                            <span class="staff-metric-label">TOTAL STAFF
                            </span>

                            <h3>18
                            </h3>

                            <p>
                                All employees
                            </p>

                        </div>

                    </div>


                    <%-- Active Staff --%>
                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-blue">

                            <svg viewBox="0 0 24 24"
                                width="23"
                                height="23"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <circle cx="12"
                                    cy="8"
                                    r="4" />

                                <path d="M4 21c0-4 3.5-7 8-7s8 3 8 7" />

                            </svg>

                        </div>

                        <div>

                            <span class="staff-metric-label">ACTIVE STAFF
                            </span>

                            <h3>14
                            </h3>

                            <p>
                                Currently active
                            </p>

                        </div>

                    </div>


                    <%-- On Shift --%>
                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-orange">

                            <svg viewBox="0 0 24 24"
                                width="23"
                                height="23"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <circle cx="12"
                                    cy="12"
                                    r="9" />

                                <path d="M12 7v5l3 2" />

                            </svg>

                        </div>

                        <div>

                            <span class="staff-metric-label">ON SHIFT
                            </span>

                            <h3>9
                            </h3>

                            <p>
                                Working now
                            </p>

                        </div>

                    </div>


                    <%-- Managers / Supervisors --%>
                    <div class="staff-metric-card">

                        <div class="staff-icon-box icon-purple">

                            <svg viewBox="0 0 24 24"
                                width="23"
                                height="23"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <path d="M12 3l8 4v5c0 5-3 8-8 9-5-1-8-4-8-9V7l8-4z" />

                                <path d="M9 12l2 2 4-4" />

                            </svg>

                        </div>

                        <div>

                            <span class="staff-metric-label">MANAGERS / SUPERVISORS
                            </span>

                            <h3>3
                            </h3>

                            <p>
                                Leadership roles
                            </p>

                        </div>

                    </div>

                </div>


                <%-- =================================================
                     ALL STAFF MEMBERS
                     ================================================= --%>

                <section class="staff-dashboard-panel manager-staff-table-card">

                    <div class="staff-panel-heading">

                        <div>

                            <h5>All Staff Members
                            </h5>

                            <small>View and manage all employees
                            </small>

                        </div>

                    </div>


                    <div class="table-responsive">

                        <table class="table staff-orders-table manager-staff-table">

                            <thead>

                                <tr>

                                    <th>Employee ID</th>
                                    <th>Name</th>
                                    <th>Role</th>
                                    <th>Department</th>
                                    <th>Shift</th>
                                    <th>Status</th>
                                    <th>Action</th>

                                </tr>

                            </thead>


                            <tbody>

                                <%-- Sarah --%>
                                <tr>

                                    <td>
                                        <strong>#EMP1001</strong>
                                    </td>

                                    <td>Sarah M.
                                    </td>

                                    <td>Shift Supervisor
                                    </td>

                                    <td>Front of House
                                    </td>

                                    <td>

                                        <span class="manager-shift-badge">08:00 - 16:00
                                        </span>

                                    </td>

                                    <td>

                                        <span class="manager-staff-status status-active-staff">Active
                                        </span>

                                    </td>

                                    <td>

                                        <button type="button"
                                            class="manager-staff-view-btn">
                                            ›

                                        </button>

                                    </td>

                                </tr>


                                <%-- James --%>
                                <tr>

                                    <td>
                                        <strong>#EMP1002</strong>
                                    </td>

                                    <td>James R.
                                    </td>

                                    <td>Barista
                                    </td>

                                    <td>Front of House
                                    </td>

                                    <td>

                                        <span class="manager-shift-badge">09:00 - 17:00
                                        </span>

                                    </td>

                                    <td>

                                        <span class="manager-staff-status status-active-staff">Active
                                        </span>

                                    </td>

                                    <td>

                                        <button type="button"
                                            class="manager-staff-view-btn">
                                            ›

                                        </button>

                                    </td>

                                </tr>


                                <%-- Chloe --%>
                                <tr>

                                    <td>
                                        <strong>#EMP1003</strong>
                                    </td>

                                    <td>Chloe T.
                                    </td>

                                    <td>Cashier
                                    </td>

                                    <td>Front of House
                                    </td>

                                    <td>

                                        <span class="manager-shift-badge">10:00 - 18:00
                                        </span>

                                    </td>

                                    <td>

                                        <span class="manager-staff-status status-active-staff">Active
                                        </span>

                                    </td>

                                    <td>

                                        <button type="button"
                                            class="manager-staff-view-btn">
                                            ›

                                        </button>

                                    </td>

                                </tr>


                                <%-- Daniel --%>
                                <tr>

                                    <td>
                                        <strong>#EMP1004</strong>
                                    </td>

                                    <td>Daniel L.
                                    </td>

                                    <td>Kitchen Staff
                                    </td>

                                    <td>Kitchen
                                    </td>

                                    <td>

                                        <span class="manager-shift-badge">06:00 - 14:00
                                        </span>

                                    </td>

                                    <td>

                                        <span class="manager-staff-status status-active-staff">Active
                                        </span>

                                    </td>

                                    <td>

                                        <button type="button"
                                            class="manager-staff-view-btn">
                                            ›

                                        </button>

                                    </td>

                                </tr>


                                <%-- Aisha --%>
                                <tr>

                                    <td>
                                        <strong>#EMP1005</strong>
                                    </td>

                                    <td>Aisha M.
                                    </td>

                                    <td>Kitchen Staff
                                    </td>

                                    <td>Kitchen
                                    </td>

                                    <td>

                                        <span class="manager-shift-badge">06:00 - 14:00
                                        </span>

                                    </td>

                                    <td>

                                        <span class="manager-staff-status status-on-leave">On Leave
                                        </span>

                                    </td>

                                    <td>

                                        <button type="button"
                                            class="manager-staff-view-btn">
                                            ›

                                        </button>

                                    </td>

                                </tr>


                                <%-- Ethan --%>
                                <tr>

                                    <td>
                                        <strong>#EMP1006</strong>
                                    </td>

                                    <td>Ethan P.
                                    </td>

                                    <td>Barista
                                    </td>

                                    <td>Front of House
                                    </td>

                                    <td>

                                        <span class="manager-shift-badge">12:00 - 20:00
                                        </span>

                                    </td>

                                    <td>

                                        <span class="manager-staff-status status-active-staff">Active
                                        </span>

                                    </td>

                                    <td>

                                        <button type="button"
                                            class="manager-staff-view-btn">
                                            ›

                                        </button>

                                    </td>

                                </tr>


                                <%-- Mia --%>
                                <tr>

                                    <td>
                                        <strong>#EMP1007</strong>
                                    </td>

                                    <td>Mia L.
                                    </td>

                                    <td>Cashier
                                    </td>

                                    <td>Front of House
                                    </td>

                                    <td>

                                        <span class="manager-shift-badge">13:00 - 21:00
                                        </span>

                                    </td>

                                    <td>

                                        <span class="manager-staff-status status-off-duty">Off Duty
                                        </span>

                                    </td>

                                    <td>

                                        <button type="button"
                                            class="manager-staff-view-btn">
                                            ›

                                        </button>

                                    </td>

                                </tr>


                                <%-- Lucas --%>
                                <tr>

                                    <td>
                                        <strong>#EMP1008</strong>
                                    </td>

                                    <td>Lucas D.
                                    </td>

                                    <td>Cleaner
                                    </td>

                                    <td>Maintenance
                                    </td>

                                    <td>

                                        <span class="manager-shift-badge">22:00 - 06:00
                                        </span>

                                    </td>

                                    <td>

                                        <span class="manager-staff-status status-active-staff">Active
                                        </span>

                                    </td>

                                    <td>

                                        <button type="button"
                                            class="manager-staff-view-btn">
                                            ›

                                        </button>

                                    </td>

                                </tr>


                                <%-- Sophia --%>
                                <tr>

                                    <td>
                                        <strong>#EMP1009</strong>
                                    </td>

                                    <td>Sophia L.
                                    </td>

                                    <td>Barista
                                    </td>

                                    <td>Front of House
                                    </td>

                                    <td>

                                        <span class="manager-shift-badge">14:00 - 22:00
                                        </span>

                                    </td>

                                    <td>

                                        <span class="manager-staff-status status-active-staff">Active
                                        </span>

                                    </td>

                                    <td>

                                        <button type="button"
                                            class="manager-staff-view-btn">
                                            ›

                                        </button>

                                    </td>

                                </tr>


                                <%-- Ryan --%>
                                <tr>

                                    <td>
                                        <strong>#EMP1010</strong>
                                    </td>

                                    <td>Ryan H.
                                    </td>

                                    <td>Kitchen Staff
                                    </td>

                                    <td>Kitchen
                                    </td>

                                    <td>

                                        <span class="manager-shift-badge">14:00 - 22:00
                                        </span>

                                    </td>

                                    <td>

                                        <span class="manager-staff-status status-off-duty">Off Duty
                                        </span>

                                    </td>

                                    <td>

                                        <button type="button"
                                            class="manager-staff-view-btn">
                                            ›

                                        </button>

                                    </td>

                                </tr>

                            </tbody>

                        </table>

                    </div>


                    <%-- =================================================
                         PAGINATION
                         ================================================= --%>

                    <div class="manager-orders-pagination">

                        <div>

                            <button type="button">
                                ‹
                            </button>

                            <button type="button"
                                class="active">
                                1
                            </button>

                            <button type="button">
                                2
                            </button>

                            <button type="button">
                                3
                            </button>

                            <button type="button">
                                ›
                            </button>

                        </div>

                        <small>Showing 1-10 of 18 staff members
                        </small>

                    </div>

                </section>


                <%-- =================================================
                     FOOTER
                     ================================================= --%>

                <div class="staff-footer">
                    © 2026 Cafe101 Manager System
                </div>

            </main>

        </div>

    </div>


    <%-- =================================================
         PAGE JAVASCRIPT
         ================================================= --%>

    <script>

        document.body.classList.add("staff-page");


        const bodyContent =
            document.querySelector(".body-content");


        if (bodyContent) {

            bodyContent.classList.remove("container");

            bodyContent.style.width = "100%";
            bodyContent.style.maxWidth = "none";
            bodyContent.style.margin = "0";
            bodyContent.style.padding = "0";

        }


        const sidebarToggle =
            document.getElementById("sidebarToggle");


        const staffBody =
            document.querySelector(".staff-body");


        if (sidebarToggle && staffBody) {

            sidebarToggle.addEventListener("click", function () {

                staffBody.classList.toggle("sidebar-collapsed");

            });

        }

    </script>

</asp:Content>
