<%@ Page Title="Sign In" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="Cafe101.Web.SignIn" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row g-0 min-vh-100 full-bleed">

        <!-- Left: form -->
    <div class="col-lg-6 d-flex align-items-start justify-content-center pt-5 pt-lg-5">
            <div class="w-100 px-4 px-lg-5 py-5" style="max-width: 480px;">

               <a href="~/Default.aspx" runat="server" class="text-decoration-none text-dark d-inline-flex align-items-center mb-4">
                &laquo; Back 
               </a>
                <h2 class="fw-bold mb-2 text-brand">Sign in</h2>
                <p class="text-muted small mb-4">Required fields are marked with an asterisk*</p>

                <div class="mb-3">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="*Enter your email" TextMode="Email" />
                </div>

                <div class="mb-2">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="*Enter password" TextMode="Password" />
                </div>

                <p class="mb-4">
                    <a href="~/ForgotPassword.aspx" runat="server" class="text-brand small">Forgot your password?</a>
                </p>

              <asp:Button ID="btnSignIn" runat="server" Text="Sign in" CssClass="btn btn-brand w-100 py-2 mb-4" OnClick="btnSignIn_Click" />

                <p class="mt-4 mb-0 small">
                    New to Cafe101?
                    <a href="~/SignUp.aspx" runat="server" class="text-brand fw-bold">Create an account</a>
                </p>

            </div>
        </div>

        <!-- Right: image -->
        <div class="col-lg-6 d-none d-lg-block p-0" style="height: 100vh;">
    <img src="~/Content/images/Cafe101 Logo.jpeg" runat="server" alt="Cafe101" class="w-100 h-100" style="object-fit: cover; display: block;" />
</div>

    </div>

</asp:Content>