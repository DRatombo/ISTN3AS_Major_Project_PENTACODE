<%@ Page Title="Forgot Password"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ForgotPassword.aspx.cs"
    Inherits="Cafe101.Web.ForgotPassword" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row g-0 min-vh-100 full-bleed">
        <div class="col-lg-6 d-flex align-items-start justify-content-center pt-5 pt-lg-5">
            <div class="w-100 px-4 px-lg-5 py-5" style="max-width: 480px;">

                <a href="~/SignIn.aspx" runat="server"
                   class="text-decoration-none text-dark d-inline-flex align-items-center mb-4">
                    &laquo; Back to Sign In
                </a>

                <h2 class="fw-bold mb-2 text-brand">Forgot Password</h2>

                <!-- ================================================== -->
                <!-- STEP 1: ENTER EMAIL -->
                <!-- ================================================== -->
                <asp:Panel ID="pnlStep1" runat="server" Visible="true">
                    <p class="text-muted small mb-4">
                        Enter the email address linked to your Cafe101 account.
                        We will send you a temporary password.
                    </p>

                    <div class="mb-3">
                        <asp:TextBox ID="txtEmail" runat="server"
                            CssClass="form-control"
                            Placeholder="Enter your email"
                            TextMode="Email" />
                    </div>

                    <asp:Label ID="lblMessage1" runat="server"
                        CssClass="d-block small mb-3" />

                    <asp:Button ID="btnSendTempPassword" runat="server"
                        Text="Reset Password"
                        CssClass="btn btn-brand w-100 py-2 mb-3"
                        OnClick="BtnSendTempPassword_Click" />
                </asp:Panel>

                <!-- ================================================== -->
                <!-- STEP 2: ENTER TEMP PASSWORD + NEW PASSWORD -->
                <!-- ================================================== -->
                <asp:Panel ID="pnlStep2" runat="server" Visible="false">
                    <p class="text-muted small mb-4">
                        We have sent a temporary password to your email.
                        Enter it below and choose a new permanent password.
                    </p>

                    <!-- Temporary Password -->
                    <div class="mb-3">
                        <div class="password-wrapper">
                            <asp:TextBox ID="txtTempPassword" runat="server"
                                CssClass="form-control password-input"
                                Placeholder="Enter temporary password"
                                TextMode="Password" />
                            <button type="button" class="password-toggle"
                                onclick="togglePassword('<%= txtTempPassword.ClientID %>', this)">
                                Show
                            </button>
                        </div>
                    </div>

                    <!-- New Password -->
                    <div class="mb-3">
                        <div class="password-wrapper">
                            <asp:TextBox ID="txtNewPassword" runat="server"
                                CssClass="form-control password-input"
                                Placeholder="Enter new password"
                                TextMode="Password" />
                            <button type="button" class="password-toggle"
                                onclick="togglePassword('<%= txtNewPassword.ClientID %>', this)">
                                Show
                            </button>
                        </div>
                    </div>

                    <!-- Confirm New Password -->
                    <div class="mb-3">
                        <div class="password-wrapper">
                            <asp:TextBox ID="txtConfirmPassword" runat="server"
                                CssClass="form-control password-input"
                                Placeholder="Confirm new password"
                                TextMode="Password" />
                            <button type="button" class="password-toggle"
                                onclick="togglePassword('<%= txtConfirmPassword.ClientID %>', this)">
                                Show
                            </button>
                        </div>
                    </div>

                    <asp:Label ID="lblMessage2" runat="server"
                        CssClass="d-block small mb-3" />

                    <asp:Button ID="btnChangePassword" runat="server"
                        Text="Change Password & Sign In"
                        CssClass="btn btn-brand w-100 py-2 mb-3"
                        OnClick="BtnChangePassword_Click" />

                    <div class="alert alert-warning small mt-3" role="alert">
                        <strong>Important:</strong> You must set a new permanent password now.
                        The temporary password will no longer work after this.
                    </div>
                </asp:Panel>

            </div>
        </div>

        <!-- RIGHT SIDE IMAGE -->
        <div class="col-lg-6 d-none d-lg-block p-0" style="height: 100vh;">
            <img src="~/Content/images/Cafe101 Logo.jpeg" runat="server"
                 alt="Cafe101" class="w-100 h-100"
                 style="object-fit: cover; display: block;" />
        </div>
    </div>

    <!-- ========================================================= -->
    <!-- PASSWORD SHOW / HIDE STYLING -->
    <!-- ========================================================= -->
   <style>
    .password-wrapper {
        position: relative;
        width: 100%;
        display: block;
    }

    .password-input {
        width: 100% !important;
        padding-right: 70px !important;   /* makes space for the Show button */
    }

    .password-toggle {
        position: absolute;
        right: 12px;
        top: 50%;
        transform: translateY(-50%);
        border: none;
        background: transparent;
        color: #1d3557;
        font-size: 13px;
        font-weight: 600;
        cursor: pointer;
        padding: 0;
        z-index: 10;
        height: auto;
        line-height: 1;
    }

    .password-toggle:hover {
        text-decoration: underline;
        color: #0d1b2a;
    }

    .password-toggle:focus {
        outline: none;
    }
</style>

    <!-- ========================================================= -->
    <!-- PASSWORD SHOW / HIDE SCRIPT -->
    <!-- ========================================================= -->
    <script type="text/javascript">
        function togglePassword(textboxId, button) {
            var passwordBox = document.getElementById(textboxId);

            if (passwordBox.type === "password") {
                passwordBox.type = "text";
                button.innerText = "Hide";
            }
            else {
                passwordBox.type = "password";
                button.innerText = "Show";
            }
        }
    </script>
</asp:Content>