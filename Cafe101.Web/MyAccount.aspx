<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="Cafe101.Web.MyAccount" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        #mainNavbar { display: none; }
    </style>

    <!-- Top bar -->
    <div class="d-flex align-items-center py-3 full-bleed px-3" style="background-color: var(--brand-navy);">
        <a href="~/CustomerDashboard.aspx" runat="server" class="btn p-0 border-0 me-3">
            <span style="font-size: 1.4rem; color: #fff;">&#8592;</span>
        </a>
        <span class="fw-bold text-white" style="font-size: 1.25rem;">My Account</span>
    </div>

    <div class="container py-4" style="max-width: 560px;">

        <div class="text-center mb-4">
            <div class="rounded-circle d-flex align-items-center justify-content-center mx-auto mb-2"
                 style="width:80px; height:80px; background-color: var(--brand-navy); color:#fff; font-size:1.75rem; font-weight:bold;">
                <asp:Literal ID="litInitials" runat="server" Text="C" />
            </div>
            <h5 class="fw-bold mb-0"><asp:Literal ID="litFullName" runat="server" /></h5>
            <p class="text-muted small"><asp:Literal ID="litEmailDisplay" runat="server" /></p>
        </div>

        <h6 class="fw-bold text-uppercase text-muted mb-3">Personal Info</h6>
        <div class="mb-3">
            <label class="form-label small text-muted">First name</label>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" Enabled="false" />
        </div>
        <div class="mb-3">
            <label class="form-label small text-muted">Last name</label>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" Enabled="false" />
        </div>
        <div class="mb-3">
            <label class="form-label small text-muted">Phone number</label>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" Enabled="false" TextMode="Phone" />
        </div>

        <h6 class="fw-bold text-uppercase text-muted mb-3 mt-4">Address</h6>
        <div class="mb-3">
            <label class="form-label small text-muted">Street address</label>
            <asp:TextBox ID="txtStreetAddress" runat="server" CssClass="form-control" Enabled="false" />
        </div>
        <div class="row g-2 mb-3">
            <div class="col-6">
                <label class="form-label small text-muted">Suburb</label>
                <asp:TextBox ID="txtSuburb" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <div class="col-6">
                <label class="form-label small text-muted">City</label>
                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" Enabled="false" />
            </div>
        </div>

        <h6 class="fw-bold text-uppercase text-muted mb-3 mt-4">Account Security</h6>
        <div class="mb-3">
            <label class="form-label small text-muted">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Enabled="false" TextMode="Email" />
        </div>
        <div class="mb-4">
            <label class="form-label small text-muted">Password</label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" Enabled="false" TextMode="Password" />
        </div>

        <!-- Edit mode toggle -->
        <asp:Button ID="btnEdit" runat="server" Text="Edit Details" CssClass="btn btn-outline-brand w-100 py-2 mb-2" OnClick="btnEdit_Click" />
        <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-brand w-100 py-2 mb-2" OnClick="btnSave_Click" Visible="false" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-outline-secondary w-100 py-2" OnClick="btnCancel_Click" Visible="false" CausesValidation="false" />

        <asp:Label ID="lblStatus" runat="server" CssClass="d-block text-center mt-3 small" />

    </div>

</asp:Content>
