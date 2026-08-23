<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Cafe101.Web.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container py-5">

        <h1 class="fw-bold text-brand mb-2">Contact Us</h1>
        <p class="text-muted mb-5">We'd love to hear from you — reach out or visit us in person.</p>

        <div class="row g-4 mb-5">

            <div class="col-md-3 col-6">
                <div class="p-4 rounded shadow-sm h-100">
                    <h6 class="fw-bold text-uppercase text-muted mb-2">Phone</h6>
                    <p class="mb-0">081 332 2130</p>
                </div>
            </div>

            <div class="col-md-3 col-6">
                <div class="p-4 rounded shadow-sm h-100">
                    <h6 class="fw-bold text-uppercase text-muted mb-2">Email</h6>
                    <p class="mb-0">info@cafe101.co.za</p>
                </div>
            </div>

            <div class="col-md-3 col-6">
                <div class="p-4 rounded shadow-sm h-100">
                    <h6 class="fw-bold text-uppercase text-muted mb-2">Address</h6>
                    <p class="mb-0">Varsity Drive, Westville, Durban, KwaZulu-Natal</p>
                </div>
            </div>

            <div class="col-md-3 col-6">
                <div class="p-4 rounded shadow-sm h-100">
                    <h6 class="fw-bold text-uppercase text-muted mb-2">Operating Hours</h6>
                    <p class="mb-1 small">Mon–Fri: 10:00 AM – 6:00 PM</p>
                    <p class="mb-1 small">Sat: 10:00 AM – 2:00 PM</p>
                    <p class="mb-0 small">Sun: Closed</p>
                </div>
            </div>

        </div>

        <h3 class="fw-bold text-brand mb-3">Find Us</h3>
        <div class="ratio ratio-16x9 rounded overflow-hidden">
            <iframe
                src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3461.6088663152!2d30.94043241187093!3d-29.817842320702564!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x1ef701007e4825bd%3A0xd3ae54c5da019d4a!2zQ2Fmw6kxMDE!5e0!3m2!1sen!2sza!4v1787357419105!5m2!1sen!2sza"
                style="border:0;"
                allowfullscreen
                loading="lazy"
                referrerpolicy="no-referrer-when-downgrade">
            </iframe>
        </div>

    </div>

</asp:Content>