<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Cafe101.Web.ForgotPassword" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row g-0 min-vh-100 full-bleed">

        <!-- Left: form -->
        <div class="col-lg-6 d-flex align-items-start justify-content-center pt-5 pt-lg-5">
            <div class="w-100 px-4 px-lg-5 py-5" style="max-width: 480px;">

                <a href="~/SignIn.aspx" runat="server" class="text-decoration-none text-dark d-inline-flex align-items-center mb-4">
                    &laquo; Back
                </a>

                <h2 class="fw-bold mb-2 text-brand">Forgot password</h2>
                <p class="text-muted small mb-1">Enter the email address used to register your Cafe101 account.</p>
                <p class="text-muted small mb-4">Required fields are marked with an asterisk*</p>

                <div class="mb-3">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="*Email" TextMode="Email" />
                </div>

                <asp:Button ID="btnReset" runat="server" Text="Reset password" CssClass="btn btn-brand py-2 px-4 mb-4" OnClick="btnReset_Click" />

            </div>
        </div>

        <!-- Right: image -->
        <div class="col-lg-6 d-none d-lg-block p-0" style="height: 100vh;">
            <img src="~/Content/images/Cafe101 Logo.jpeg" runat="server" alt="Cafe101" class="w-100 h-100" style="object-fit: cover; display: block;" />
        </div>

    </div>

</asp:Content>
