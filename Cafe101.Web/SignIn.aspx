<%@ Page Title="Sign In"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="SignIn.aspx.cs"
    Inherits="Cafe101.Web.SignIn" %>

<asp:Content
    ID="BodyContent"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div class="row g-0 min-vh-100 full-bleed">

        <!-- ====================================================== -->
        <!-- LEFT: SIGN IN FORM -->
        <!-- ====================================================== -->

        <div class="col-lg-6 d-flex align-items-start justify-content-center pt-5 pt-lg-5">

            <div
                class="w-100 px-4 px-lg-5 py-5"
                style="max-width: 480px;">

                <!-- Back -->
                <a
                    href="~/Default.aspx"
                    runat="server"
                    class="text-decoration-none text-dark d-inline-flex align-items-center mb-4">

                    &laquo; Back

                </a>


                <!-- Heading -->
                <h2 class="fw-bold mb-2 text-brand">
                    Sign in
                </h2>


                <p class="text-muted small mb-4">
                    Required fields are marked with an asterisk*
                </p>


                <!-- ================================================== -->
                <!-- EMAIL -->
                <!-- ================================================== -->

                <div class="mb-3">

                    <asp:TextBox
                        ID="txtEmail"
                        runat="server"
                        CssClass="form-control"
                        Placeholder="*Enter your email"
                        TextMode="Email">
                    </asp:TextBox>

                </div>


                <!-- ================================================== -->
                <!-- PASSWORD -->
                <!-- ================================================== -->

                <div class="mb-2">

                    <div class="password-wrapper">

                        <asp:TextBox
                            ID="txtPassword"
                            runat="server"
                            TextMode="Password"
                            CssClass="form-control password-input"
                            Placeholder="*Enter password">
                        </asp:TextBox>


                        <button
                            type="button"
                            id="btnTogglePassword"
                            class="password-toggle"
                            onclick="togglePassword()"
                            aria-label="Show password">

                            Show

                        </button>

                    </div>

                </div>


                <!-- ================================================== -->
                <!-- FORGOT PASSWORD -->
                <!-- ================================================== -->

                <p class="mb-4">

                    <a
                        href="~/ForgotPassword.aspx"
                        runat="server"
                        class="text-brand small">

                        Forgot your password?

                    </a>

                </p>


                <!-- ================================================== -->
                <!-- ERROR / VALIDATION MESSAGE -->
                <!-- ================================================== -->

                <asp:Label
                    ID="lblMessage"
                    runat="server"
                    CssClass="d-block text-danger small mb-3">
                </asp:Label>


                <!-- ================================================== -->
                <!-- SIGN IN BUTTON -->
                <!-- ================================================== -->

                <asp:Button
                    ID="btnSignIn"
                    runat="server"
                    Text="Sign in"
                    CssClass="btn btn-brand w-100 py-2 mb-4"
                    OnClick="BtnSignIn_Click" />


                <!-- ================================================== -->
                <!-- CREATE ACCOUNT -->
                <!-- ================================================== -->

                <p class="mt-4 mb-0 small">

                    New to Cafe101?

                    <a
                        href="~/SignUp.aspx"
                        runat="server"
                        class="text-brand fw-bold">

                        Create an account

                    </a>

                </p>

            </div>

        </div>


        <!-- ====================================================== -->
        <!-- RIGHT: CAFE101 IMAGE -->
        <!-- ====================================================== -->

        <div
            class="col-lg-6 d-none d-lg-block p-0"
            style="height: 100vh;">

            <img
                src="~/Content/images/Cafe101 Logo.jpeg"
                runat="server"
                alt="Cafe101"
                class="w-100 h-100"
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
        }


        .password-input {
            width: 100% !important;
            padding-right: 65px !important;
        }


        .password-toggle {
            position: absolute;
            right: 10px;
            top: 50%;
            transform: translateY(-50%);

            border: none;
            background: transparent;

            color: #1d3557;

            font-size: 12px;
            font-weight: 600;

            cursor: pointer;

            padding: 4px 5px;

            z-index: 10;
        }


        .password-toggle:hover {
            text-decoration: underline;
        }


        .password-toggle:focus {
            outline: none;
        }


        .password-toggle:focus-visible {
            outline: 2px solid #1d3557;
            outline-offset: 2px;
            border-radius: 3px;
        }

    </style>


    <!-- ========================================================= -->
    <!-- PASSWORD SHOW / HIDE SCRIPT -->
    <!-- ========================================================= -->

    <script type="text/javascript">

        function togglePassword() {

            var passwordBox =
                document.getElementById(
                    '<%= txtPassword.ClientID %>'
                );


            var toggleButton =
                document.getElementById(
                    'btnTogglePassword'
                );


            if (passwordBox.type === "password") {

                passwordBox.type = "text";

                toggleButton.innerText =
                    "Hide";

                toggleButton.setAttribute(
                    "aria-label",
                    "Hide password"
                );

            }
            else {

                passwordBox.type =
                    "password";

                toggleButton.innerText =
                    "Show";

                toggleButton.setAttribute(
                    "aria-label",
                    "Show password"
                );

            }
        }

    </script>

</asp:Content>