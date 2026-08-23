
    <%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Cafe101.Web.SignUp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <div class="row g-0 min-vh-100 full-bleed">  

        <!-- Left: form -->
        <div class="col-lg-6 d-flex align-items-center">
            <div class="w-100 px-4 px-lg-5 py-5 mx-auto" style="max-width: 480px; margin: 0 auto;">

                <a href="~/Default.aspx" runat="server" class="text-decoration-none text-dark d-inline-flex align-items-center mb-4">
    &laquo; Back
</a>

                <h2 class="fw-bold mb-4 text-brand"> Sign-Up with Cafe101</h2>

               

                    <h6 class="fw-bold text-uppercase text-muted mb-3">Personal Info</h6>
        <div class="mb-3">
    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="First name" />
        </div>
    <div class="mb-3">
        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Last name" />
    </div>
    <div class="mb-3">
        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" placeholder="Phone number" TextMode="Phone" />
    </div>
    <div class="mb-3">
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Street address" />
    </div>
    <div class="row g-2 mb-4">
        <div class="col-6">
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Suburb" />
        </div>
        <div class="col-6">
            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="City" />
        </div>
    </div>

    <h6 class="fw-bold text-uppercase text-muted mb-3">Account Security</h6>
    <div class="mb-3">
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" TextMode="Email" />
        <small class="text-muted">This will be your username</small>
    </div>
    <div class="mb-4">
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" />

    </div>

    <div class="form-check mb-4">
       <asp:CheckBox ID="chkTerms" runat="server" CssClass="form-check-input" />
        <label class="form-check-label small" for="chkTerms">
            I agree to Cafe101's Terms of Use and Privacy Statement.
        </label>
    </div>

     <asp:Button ID="btnJoin" runat="server" Text="Join Cafe101" CssClass="btn btn-brand w-100 py-2" OnClick="btnJoin_Click" />

      <p class=" mt-4 mb-0 small">
          Already have an account?
         <a href="~/SignIn.aspx" runat="server" class="text-brand fw-bold">Sign in</a>
      </p>
            </div>
        </div>

        <!-- Right: image -->
        <div class="col-lg-6 d-none d-lg-block p-0">
            <img src="~/Content/images/Cafe101 Logo.jpeg" runat="server" alt="Cafe101" class="w-100 h-100" style="object-fit: cover;" />
        </div>

    </div>

</asp:Content>

