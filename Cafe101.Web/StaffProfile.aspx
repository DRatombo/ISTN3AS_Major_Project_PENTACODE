<%@ Page Title="Staff Profile"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="StaffProfile.aspx.cs"
    Inherits="Cafe101.Web.WebForm1" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


    <%-- =================================================
         STAFF PROFILE PAGE
         ================================================= --%>

    <div class="staff-shell">


        <%-- =================================================
             TOP STAFF HEADER
             ================================================= --%>

        <header class="staff-header">

            <div class="staff-header-left">

                <button type="button"
                    id="sidebarToggle"
                    class="staff-header-menu"
                    aria-label="Toggle staff navigation">
                    ☰
                </button>


                <div class="staff-header-brand">
                    Cafe101
                </div>

            </div>


            <div class="staff-header-user">

                <div class="staff-header-avatar">
                    SM
                </div>

                <div>
                    <strong>Staff Member</strong>
                    <small>Employee</small>
                </div>

            </div>

        </header>



        <%-- =================================================
             STAFF BODY
             ================================================= --%>

        <div class="staff-body">


            <%-- =================================================
                 LEFT SIDEBAR
                 ================================================= --%>

            <aside class="staff-sidebar">


                <div class="staff-sidebar-title">
                    STAFF SYSTEM
                </div>


                <nav class="staff-nav">


                    <%-- Dashboard --%>
                    <a href="StaffDashboard.aspx">

                        <span class="staff-nav-icon">
                            &#8962;
                        </span>

                        <span class="staff-nav-text">
                            Dashboard
                        </span>

                    </a>


                    <%-- Orders --%>
                    <a href="StaffOrders.aspx">

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

                        <span class="staff-nav-text">
                            Orders
                        </span>

                    </a>


                    <%-- Profile - active --%>
                    <a href="StaffProfile.aspx"
                        class="active">

                        <span class="staff-nav-icon">

                            <svg viewBox="0 0 24 24"
                                width="19"
                                height="19"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <circle cx="12"
                                    cy="8"
                                    r="4" />

                                <path d="M4 21c0-4 3.5-7 8-7s8 3 8 7" />

                            </svg>

                        </span>

                        <span class="staff-nav-text">
                            Profile
                        </span>

                    </a>


                </nav>


                <%-- Logout --%>
                <div class="staff-sidebar-bottom">

                    <a href="#"
                        class="staff-logout">

                        <span class="staff-nav-icon">
                            &#10140;
                        </span>

                        <span class="staff-nav-text">
                            Logout
                        </span>

                    </a>

                </div>


            </aside>



            <%-- =================================================
                 MAIN PROFILE CONTENT
                 ================================================= --%>

            <main class="staff-main">


                <%-- =================================================
                     PAGE HEADING
                     ================================================= --%>

                <div class="staff-page-heading">

                    <h3>
                        My Profile
                    </h3>

                    <p>
                        View and manage your account information.
                    </p>

                </div>



                <%-- =================================================
                     PROFILE SUMMARY CARD
                     ================================================= --%>

                <section class="staff-dashboard-panel staff-profile-summary">


                    <div class="staff-profile-summary-left">


                        <%-- Profile avatar --%>
                        <div class="staff-profile-avatar">
                            SM
                        </div>


                        <div class="staff-profile-main-info">


                            <%-- Name and role --%>
                            <div class="staff-profile-name-row">

                                <h4>
                                    Staff Member
                                </h4>

                                <span class="staff-profile-role-badge">
                                    Employee
                                </span>

                            </div>



                            <%-- Email, phone and member since --%>
                            <div class="staff-profile-contact-grid">


                                <%-- Email --%>
                                <div class="staff-profile-contact-item">

                                    <div class="staff-profile-contact-icon">

                                        <svg viewBox="0 0 24 24"
                                            width="17"
                                            height="17"
                                            fill="none"
                                            stroke="currentColor"
                                            stroke-width="2">

                                            <rect x="3"
                                                y="5"
                                                width="18"
                                                height="14"
                                                rx="2" />

                                            <path d="M3 7l9 6 9-6" />

                                        </svg>

                                    </div>

                                    <div>

                                        <small>Email</small>

                                        <strong>
                                            staff.member@cafe101.com
                                        </strong>

                                    </div>

                                </div>



                                <%-- Phone --%>
                                <div class="staff-profile-contact-item">

                                    <div class="staff-profile-contact-icon">

                                        <svg viewBox="0 0 24 24"
                                            width="17"
                                            height="17"
                                            fill="none"
                                            stroke="currentColor"
                                            stroke-width="2">

                                            <path d="M5 4h4l2 5-3 2a16 16 0 0 0 5 5l2-3 5 2v4c0 1-1 2-2 2C10 21 3 14 3 6c0-1 1-2 2-2z" />

                                        </svg>

                                    </div>

                                    <div>

                                        <small>Phone</small>

                                        <strong>
                                            +27 61 234 5678
                                        </strong>

                                    </div>

                                </div>



                                <%-- Member since --%>
                                <div class="staff-profile-contact-item">

                                    <div class="staff-profile-contact-icon">

                                        <svg viewBox="0 0 24 24"
                                            width="17"
                                            height="17"
                                            fill="none"
                                            stroke="currentColor"
                                            stroke-width="2">

                                            <rect x="3"
                                                y="5"
                                                width="18"
                                                height="16"
                                                rx="2" />

                                            <path d="M8 3v4" />
                                            <path d="M16 3v4" />
                                            <path d="M3 10h18" />

                                        </svg>

                                    </div>

                                    <div>

                                        <small>
                                            Member Since
                                        </small>

                                        <strong>
                                            15 March 2024
                                        </strong>

                                    </div>

                                </div>


                            </div>

                        </div>

                    </div>



                    <%-- Edit Profile --%>
                    <div class="staff-profile-summary-right">

                        <button type="button"
                            class="btn btn-outline-brand staff-edit-profile-btn">

                            <svg viewBox="0 0 24 24"
                                width="15"
                                height="15"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <path d="M12 20h9" />

                                <path d="M16.5 3.5a2.1 2.1 0 0 1 3 3L8 18l-4 1 1-4z" />

                            </svg>

                            <span>
                                Edit Profile
                            </span>

                        </button>

                    </div>


                </section>



                <%-- =================================================
                     PROFILE INFORMATION GRID
                     ================================================= --%>

                <div class="staff-profile-content-grid">


                    <%-- =================================================
                         PERSONAL INFORMATION
                         ================================================= --%>

                    <section class="staff-dashboard-panel staff-profile-info-card">


                        <div class="staff-profile-section-heading">

                            <h5>
                                Personal Information
                            </h5>

                        </div>



                        <%-- Full Name --%>
                        <div class="staff-profile-info-row">

                            <div class="staff-profile-info-label">

                                <span class="staff-profile-small-icon">

                                    <svg viewBox="0 0 24 24"
                                        width="15"
                                        height="15"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <circle cx="12"
                                            cy="8"
                                            r="4" />

                                        <path d="M5 21c0-4 3-7 7-7s7 3 7 7" />

                                    </svg>

                                </span>

                                <span>
                                    Full Name
                                </span>

                            </div>

                            <strong>
                                Staff Member
                            </strong>

                        </div>



                        <%-- Email --%>
                        <div class="staff-profile-info-row">

                            <div class="staff-profile-info-label">

                                <span class="staff-profile-small-icon">

                                    <svg viewBox="0 0 24 24"
                                        width="15"
                                        height="15"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <rect x="3"
                                            y="5"
                                            width="18"
                                            height="14"
                                            rx="2" />

                                        <path d="M3 7l9 6 9-6" />

                                    </svg>

                                </span>

                                <span>
                                    Email Address
                                </span>

                            </div>

                            <strong>
                                staff.member@cafe101.com
                            </strong>

                        </div>



                        <%-- Phone --%>
                        <div class="staff-profile-info-row">

                            <div class="staff-profile-info-label">

                                <span class="staff-profile-small-icon">

                                    <svg viewBox="0 0 24 24"
                                        width="15"
                                        height="15"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <path d="M5 4h4l2 5-3 2a16 16 0 0 0 5 5l2-3 5 2v4c0 1-1 2-2 2C10 21 3 14 3 6c0-1 1-2 2-2z" />

                                    </svg>

                                </span>

                                <span>
                                    Phone Number
                                </span>

                            </div>

                            <strong>
                                +27 61 234 5678
                            </strong>

                        </div>



                        <%-- Date of Birth --%>
                        <div class="staff-profile-info-row">

                            <div class="staff-profile-info-label">

                                <span class="staff-profile-small-icon">

                                    <svg viewBox="0 0 24 24"
                                        width="15"
                                        height="15"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <rect x="3"
                                            y="5"
                                            width="18"
                                            height="16"
                                            rx="2" />

                                        <path d="M8 3v4" />
                                        <path d="M16 3v4" />
                                        <path d="M3 10h18" />

                                    </svg>

                                </span>

                                <span>
                                    Date of Birth
                                </span>

                            </div>

                            <strong>
                                12 June 1999
                            </strong>

                        </div>



                        <%-- Address --%>
                        <div class="staff-profile-info-row">

                            <div class="staff-profile-info-label">

                                <span class="staff-profile-small-icon">

                                    <svg viewBox="0 0 24 24"
                                        width="15"
                                        height="15"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <path d="M12 21s6-5.2 6-11a6 6 0 1 0-12 0c0 5.8 6 11 6 11z" />
                                        <circle cx="12" cy="10" r="2" />

                                    </svg>

                                </span>

                                <span>
                                    Address
                                </span>

                            </div>

                            <strong>
                                123 Main Street, Durban, 4001
                            </strong>

                        </div>



                        <%-- Role --%>
                        <div class="staff-profile-info-row">

                            <div class="staff-profile-info-label">

                                <span class="staff-profile-small-icon">

                                    <svg viewBox="0 0 24 24"
                                        width="15"
                                        height="15"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <rect x="4"
                                            y="4"
                                            width="16"
                                            height="16"
                                            rx="2" />

                                        <path d="M8 9h8" />
                                        <path d="M8 13h5" />

                                    </svg>

                                </span>

                                <span>
                                    Role
                                </span>

                            </div>

                            <strong>
                                Employee
                            </strong>

                        </div>



                        <%-- Department --%>
                        <div class="staff-profile-info-row">

                            <div class="staff-profile-info-label">

                                <span class="staff-profile-small-icon">

                                    <svg viewBox="0 0 24 24"
                                        width="15"
                                        height="15"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <rect x="3"
                                            y="4"
                                            width="18"
                                            height="16"
                                            rx="2" />

                                        <path d="M8 8h8" />
                                        <path d="M8 12h8" />
                                        <path d="M8 16h5" />

                                    </svg>

                                </span>

                                <span>
                                    Department
                                </span>

                            </div>

                            <strong>
                                Service
                            </strong>

                        </div>


                    </section>



                    <%-- =================================================
                         RIGHT PROFILE COLUMN
                         ================================================= --%>

                    <div class="staff-profile-right-column">


                        <%-- =================================================
                             ACCOUNT SECURITY
                             ================================================= --%>

                        <section class="staff-dashboard-panel staff-profile-small-card">


                            <div class="staff-profile-small-card-content">


                                <div class="staff-profile-security-icon">

                                    <svg viewBox="0 0 24 24"
                                        width="18"
                                        height="18"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <rect x="5"
                                            y="10"
                                            width="14"
                                            height="10"
                                            rx="2" />

                                        <path d="M8 10V7a4 4 0 0 1 8 0v3" />

                                    </svg>

                                </div>


                                <div>

                                    <strong>
                                        Account Security
                                    </strong>

                                    <small>
                                        Keep your account secure
                                    </small>

                                    <p>
                                        Last password change: 2 months ago
                                    </p>

                                </div>


                            </div>



                            <button type="button"
                                class="btn staff-security-btn">

                                Change Password

                            </button>


                        </section>



                        <%-- =================================================
                             WORK INFORMATION
                             ================================================= --%>

                        <section class="staff-dashboard-panel staff-profile-work-card">


                            <div class="staff-profile-section-heading">

                                <h5>
                                    Work Information
                                </h5>

                            </div>



                            <div class="staff-profile-info-row">

                                <div class="staff-profile-info-label">
                                    <span>Employee ID</span>
                                </div>

                                <strong>
                                    EMP10123
                                </strong>

                            </div>


                            <div class="staff-profile-info-row">

                                <div class="staff-profile-info-label">
                                    <span>Hire Date</span>
                                </div>

                                <strong>
                                    15 March 2024
                                </strong>

                            </div>


                            <div class="staff-profile-info-row">

                                <div class="staff-profile-info-label">
                                    <span>Shift</span>
                                </div>

                                <strong>
                                    Morning Shift (08:00 - 16:00)
                                </strong>

                            </div>


                            <div class="staff-profile-info-row">

                                <div class="staff-profile-info-label">
                                    <span>Status</span>
                                </div>

                                <span class="staff-profile-status-active">
                                    Active
                                </span>

                            </div>


                        </section>



                        <%-- =================================================
                             QUICK ACTIONS
                             ================================================= --%>

                        <section class="staff-dashboard-panel staff-profile-quick-card">


                            <div class="staff-profile-section-heading">

                                <h5>
                                    Quick Actions
                                </h5>

                            </div>



                            <div class="staff-profile-quick-grid">


                                <button type="button"
                                    class="staff-profile-quick-action">

                                    <span class="staff-profile-quick-icon icon-blue">

                                        <svg viewBox="0 0 24 24"
                                            width="17"
                                            height="17"
                                            fill="none"
                                            stroke="currentColor"
                                            stroke-width="2">

                                            <circle cx="12"
                                                cy="8"
                                                r="4" />

                                            <path d="M5 21c0-4 3-7 7-7s7 3 7 7" />

                                        </svg>

                                    </span>

                                    <span>

                                        <strong>
                                            Update Profile
                                        </strong>

                                        <small>
                                            Edit your information
                                        </small>

                                    </span>

                                </button>



                                <button type="button"
                                    class="staff-profile-quick-action">

                                    <span class="staff-profile-quick-icon icon-purple">

                                        <svg viewBox="0 0 24 24"
                                            width="17"
                                            height="17"
                                            fill="none"
                                            stroke="currentColor"
                                            stroke-width="2">

                                            <rect x="5"
                                                y="10"
                                                width="14"
                                                height="10"
                                                rx="2" />

                                            <path d="M8 10V7a4 4 0 0 1 8 0v3" />

                                        </svg>

                                    </span>

                                    <span>

                                        <strong>
                                            Change Password
                                        </strong>

                                        <small>
                                            Update your password
                                        </small>

                                    </span>

                                </button>



                                <button type="button"
                                    class="staff-profile-quick-action">

                                    <span class="staff-profile-quick-icon icon-beige">

                                        <svg viewBox="0 0 24 24"
                                            width="17"
                                            height="17"
                                            fill="none"
                                            stroke="currentColor"
                                            stroke-width="2">

                                            <path d="M18 8a6 6 0 1 0-12 0c0 7-3 7-3 9h18c0-2-3-2-3-9" />
                                            <path d="M10 21h4" />

                                        </svg>

                                    </span>

                                    <span>

                                        <strong>
                                            Notification Settings
                                        </strong>

                                        <small>
                                            Manage notifications
                                        </small>

                                    </span>

                                </button>


                            </div>


                        </section>


                    </div>


                </div>


                <%-- Staff footer --%>
                <div class="staff-footer">
                    © 2026 Cafe101. All rights reserved.
                </div>


            </main>
            <%-- END OF staff-main --%>


        </div>
        <%-- END OF staff-body --%>


    </div>
    <%-- END OF staff-shell --%>



    <%-- =================================================
         STAFF PAGE JAVASCRIPT
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