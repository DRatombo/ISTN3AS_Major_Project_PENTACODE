<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="Cafe101.Web.OrderHistory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        #mainNavbar { display: none; }
    </style>

    <!-- Top bar -->
    <div class="d-flex align-items-center py-3 full-bleed px-3" style="background-color: var(--brand-navy);">
        <a href="~/CustomerDashboard.aspx" runat="server" class="btn p-0 border-0 me-3">
            <span style="font-size: 1.4rem; color: #fff;">&#8592;</span>
        </a>
        <span class="fw-bold text-white" style="font-size: 1.25rem;">Order History</span>
    </div>

    <div class="container py-4" style="max-width: 700px;">

        <!-- Filter dropdown -->
        <div class="mb-4">
            <label class="form-label small text-muted fw-bold">Filter by</label>
            <asp:DropDownList ID="ddlFilter" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlFilter_SelectedIndexChanged">
                <asp:ListItem Text="Last Month" Value="1" />
                <asp:ListItem Text="Last 3 Months" Value="3" />
                <asp:ListItem Text="Last 6 Months" Value="6" />
                <asp:ListItem Text="Last Year" Value="12" />
            </asp:DropDownList>
        </div>

        <!-- Orders list -->
        <asp:Repeater ID="rptOrders" runat="server">
            <ItemTemplate>
                <div class="card mb-3 shadow-sm">
                    <div class="card-body d-flex justify-content-between align-items-center">
                        <div>
                            <p class="fw-bold mb-1"><%# Eval("OrderDate", "{0:dd MMM yyyy}") %></p>
                            <p class="text-muted small mb-0"><%# Eval("ItemSummary") %></p>
                        </div>
                        <div class="text-end">
                            <p class="fw-bold text-brand mb-1">R<%# Eval("Total") %></p>
                            <span class="badge bg-light text-dark border"><%# Eval("Status") %></span>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <asp:Label ID="lblNoOrders" runat="server" CssClass="text-muted d-block text-center py-5" Text="No orders found for this period." Visible="false" />

    </div>

</asp:Content>