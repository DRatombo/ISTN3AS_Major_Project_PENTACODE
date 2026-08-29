<%@ Page Title="Staff Profile"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="StaffProfile.aspx.cs"
    Inherits="Cafe101.Web.WebForm1" %>


<asp:Content
    ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">


    <div class="staff-shell">


        <%-- =================================================
             TOP STAFF HEADER
             ================================================= --%>

        <header class="staff-header">

            <div class="staff-header-left">

                <button
                    type="button"
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

                    <asp:Label
                        ID="lblTopInitials"
                        runat="server">
                    </asp:Label>

                </div>


                <div>

                    <strong>

                        <asp:Label
                            ID="lblTopStaffName"
                            runat="server">
                        </asp:Label>

                    </strong>


                    <small>

                        <asp:Label
                            ID="lblTopStaffRole"
                            runat="server">
                        </asp:Label>

                    </small>

                </div>

            </div>

        </header>



        <div class="staff-body">


            <%-- =================================================
                 LEFT SIDEBAR
                 ================================================= --%>

            <aside class="staff-sidebar">


                <div class="staff-sidebar-title">
                    STAFF SYSTEM
                </div>


                <nav class="staff-nav">


                    <a href="StaffDashboard.aspx">

                        <span class="staff-nav-icon">
                            &#8962;
                        </span>

                        <span class="staff-nav-text">
                            Dashboard
                        </span>

                    </a>



                    <a href="StaffOrders.aspx">

                        <span class="staff-nav-icon">

                            <svg
                                viewBox="0 0 24 24"
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



                    <a
                        href="StaffProfile.aspx"
                        class="active">

                        <span class="staff-nav-icon">

                            <svg
                                viewBox="0 0 24 24"
                                width="19"
                                height="19"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2">

                                <circle
                                    cx="12"
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



                <%-- =================================================
                     LOGOUT
                     ================================================= --%>

                <div class="staff-sidebar-bottom">

                    <asp:LinkButton
                        ID="lnkLogout"
                        runat="server"
                        CssClass="staff-logout"
                        OnClick="LnkLogout_Click">

                        <span class="staff-nav-icon">
                            &#10140;
                        </span>

                        <span class="staff-nav-text">
                            Logout
                        </span>

                    </asp:LinkButton>

                </div>

            </aside>



            <%-- =================================================
                 MAIN PROFILE
                 ================================================= --%>

            <main class="staff-main">


                <div class="staff-page-heading">

                    <h3>
                        My Profile
                    </h3>

                    <p>
                        View your Cafe101 employee account information.
                    </p>

                </div>



                <asp:Label
                    ID="lblProfileMessage"
                    runat="server"
                    CssClass="d-none">
                </asp:Label>



                <%-- =================================================
                     PROFILE SUMMARY
                     ================================================= --%>

                <section class="staff-dashboard-panel staff-profile-summary">


                    <div class="staff-profile-summary-left">


                        <div class="staff-profile-avatar">

                            <asp:Label
                                ID="lblProfileInitials"
                                runat="server">
                            </asp:Label>

                        </div>



                        <div class="staff-profile-main-info">


                            <div class="staff-profile-name-row">

                                <h4>

                                    <asp:Label
                                        ID="lblProfileName"
                                        runat="server">
                                    </asp:Label>

                                </h4>


                                <span class="staff-profile-role-badge">

                                    <asp:Label
                                        ID="lblProfileRole"
                                        runat="server">
                                    </asp:Label>

                                </span>

                            </div>



                            <div class="staff-profile-contact-grid">


                                <%-- Email --%>

                                <div class="staff-profile-contact-item">

                                    <div class="staff-profile-contact-icon">

                                        <svg
                                            viewBox="0 0 24 24"
                                            width="17"
                                            height="17"
                                            fill="none"
                                            stroke="currentColor"
                                            stroke-width="2">

                                            <rect
                                                x="3"
                                                y="5"
                                                width="18"
                                                height="14"
                                                rx="2" />

                                            <path d="M3 7l9 6 9-6" />

                                        </svg>

                                    </div>


                                    <div>

                                        <small>
                                            Email
                                        </small>

                                        <strong>

                                            <asp:Label
                                                ID="lblProfileEmail"
                                                runat="server">
                                            </asp:Label>

                                        </strong>

                                    </div>

                                </div>



                                <%-- Hire Date --%>

                                <div class="staff-profile-contact-item">

                                    <div class="staff-profile-contact-icon">

                                        <svg
                                            viewBox="0 0 24 24"
                                            width="17"
                                            height="17"
                                            fill="none"
                                            stroke="currentColor"
                                            stroke-width="2">

                                            <rect
                                                x="3"
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
                                            Hire Date
                                        </small>

                                        <strong>

                                            <asp:Label
                                                ID="lblProfileHireDate"
                                                runat="server">
                                            </asp:Label>

                                        </strong>

                                    </div>

                                </div>

                            </div>

                        </div>

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

                                    <svg
                                        viewBox="0 0 24 24"
                                        width="15"
                                        height="15"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <circle
                                            cx="12"
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

                                <asp:Label
                                    ID="lblFullName"
                                    runat="server">
                                </asp:Label>

                            </strong>

                        </div>



                        <%-- Email --%>

                        <div class="staff-profile-info-row">

                            <div class="staff-profile-info-label">

                                <span class="staff-profile-small-icon">

                                    <svg
                                        viewBox="0 0 24 24"
                                        width="15"
                                        height="15"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <rect
                                            x="3"
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

                                <asp:Label
                                    ID="lblPersonalEmail"
                                    runat="server">
                                </asp:Label>

                            </strong>

                        </div>



                        <%-- Address --%>

                        <div class="staff-profile-info-row">

                            <div class="staff-profile-info-label">

                                <span class="staff-profile-small-icon">

                                    <svg
                                        viewBox="0 0 24 24"
                                        width="15"
                                        height="15"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <path d="M12 21s6-5.2 6-11a6 6 0 1 0-12 0c0 5.8 6 11 6 11z" />

                                        <circle
                                            cx="12"
                                            cy="10"
                                            r="2" />

                                    </svg>

                                </span>


                                <span>
                                    Address
                                </span>

                            </div>


                            <strong>

                                <asp:Label
                                    ID="lblAddress"
                                    runat="server">
                                </asp:Label>

                            </strong>

                        </div>



                        <%-- Role --%>

                        <div class="staff-profile-info-row">

                            <div class="staff-profile-info-label">

                                <span class="staff-profile-small-icon">

                                    <svg
                                        viewBox="0 0 24 24"
                                        width="15"
                                        height="15"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <rect
                                            x="4"
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

                                <asp:Label
                                    ID="lblRole"
                                    runat="server">
                                </asp:Label>

                            </strong>

                        </div>

                    </section>



                    <%-- =================================================
                         RIGHT COLUMN
                         ================================================= --%>

                    <div class="staff-profile-right-column">


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

                                    <span>
                                        Employee ID
                                    </span>

                                </div>


                                <strong>

                                    <asp:Label
                                        ID="lblEmployeeID"
                                        runat="server">
                                    </asp:Label>

                                </strong>

                            </div>



                            <div class="staff-profile-info-row">

                                <div class="staff-profile-info-label">

                                    <span>
                                        Hire Date
                                    </span>

                                </div>


                                <strong>

                                    <asp:Label
                                        ID="lblHireDate"
                                        runat="server">
                                    </asp:Label>

                                </strong>

                            </div>



                            <div class="staff-profile-info-row">

                                <div class="staff-profile-info-label">

                                    <span>
                                        Status
                                    </span>

                                </div>


                                <asp:Label
                                    ID="lblEmployeeStatus"
                                    runat="server"
                                    CssClass="staff-profile-status-active">
                                </asp:Label>

                            </div>

                        </section>



                        <%-- =================================================
                             ACCOUNT INFORMATION
                             ================================================= --%>

                        <section class="staff-dashboard-panel staff-profile-small-card">


                            <div class="staff-profile-small-card-content">


                                <div class="staff-profile-security-icon">

                                    <svg
                                        viewBox="0 0 24 24"
                                        width="18"
                                        height="18"
                                        fill="none"
                                        stroke="currentColor"
                                        stroke-width="2">

                                        <rect
                                            x="5"
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
                                        Keep your Cafe101 account details secure.
                                    </small>

                                </div>

                            </div>

                        </section>

                    </div>

                </div>



                <div class="staff-footer">
                    © 2026 Cafe101. All rights reserved.
                </div>

            </main>

        </div>

    </div>



    <%-- =================================================
         PAGE SCRIPT
         ================================================= --%>

    <script>

        document.body.classList.add(
            "staff-page"
        );


        const bodyContent =
            document.querySelector(
                ".body-content"
            );


        if (bodyContent) {

            bodyContent.classList.remove(
                "container"
            );

            bodyContent.style.width =
                "100%";

            bodyContent.style.maxWidth =
                "none";

            bodyContent.style.margin =
                "0";

            bodyContent.style.padding =
                "0";

        }


        const sidebarToggle =
            document.getElementById(
                "sidebarToggle"
            );


        const staffBody =
            document.querySelector(
                ".staff-body"
            );


        if (sidebarToggle &&
            staffBody) {

            sidebarToggle.addEventListener(
                "click",
                function () {

                    staffBody.classList.toggle(
                        "sidebar-collapsed"
                    );

                });

        }

    </script>


</asp:Content>