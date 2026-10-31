<%@ Page Title="Receipt" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Receipt.aspx.cs" 
    Inherits="Cafe101.Web.Receipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<style>
    .receipt-card {
        max-width: 520px;
        margin: 0 auto;
        border: none;
        border-radius: 16px;
        box-shadow: 0 10px 40px rgba(0,0,0,0.08);
        overflow: hidden;
    }
    .receipt-header {
        background: linear-gradient(135deg, #0f172a, #1e293b);
        color: white;
        padding: 28px 32px 24px;
        text-align: center;
    }
    .receipt-body {
        padding: 28px 32px 32px;
        background: #ffffff;
    }
    .receipt-row {
        display: flex;
        justify-content: space-between;
        padding: 6px 0;
        font-size: 0.95rem;
    }
    .receipt-total {
        font-size: 1.35rem;
        font-weight: 700;
        border-top: 2px dashed #e2e8f0;
        margin-top: 16px;
        padding-top: 16px;
    }
    .status-badge {
        background: #10b981;
        color: white;
        font-size: 0.75rem;
        font-weight: 600;
        padding: 4px 12px;
        border-radius: 50px;
        letter-spacing: 0.3px;
    }
    .action-buttons {
        display: flex;
        gap: 12px;
        justify-content: center;
        margin-top: 28px;
        flex-wrap: wrap;
    }
    .email-status {
        text-align: center;
        font-size: 0.9rem;
        margin-top: 20px;
        padding: 10px 16px;
        border-radius: 8px;
        background: #ecfdf5;
        color: #065f46;
        display: inline-block;
    }
</style>

<div class="container py-5">

    <!-- Success message -->
    <div class="text-center mb-4">
        <div style="width:64px;height:64px;background:#ecfdf5;border-radius:50%;display:inline-flex;align-items:center;justify-content:center;margin-bottom:16px;">
            <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" fill="#10b981" viewBox="0 0 16 16">
                <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zm-3.97-3.03a.75.75 0 0 0-1.08.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-.01-1.05z"/>
            </svg>
        </div>
        <h2 class="fw-bold mb-1">Payment Successful</h2>
        <p class="text-muted mb-0">Thank you for your order at Cafe101</p>
    </div>

    <!-- Receipt Card -->
    <div class="receipt-card">
        <div class="receipt-header">
            <div class="d-flex justify-content-between align-items-center">
                <h4 class="mb-0 fw-bold">Cafe101</h4>
                <span class="status-badge">PAID</span>
            </div>
            <div class="mt-3" style="opacity:0.85;font-size:0.9rem;">
                Order #<asp:Literal ID="litOrderId" runat="server" />
            </div>
        </div>

        <div class="receipt-body">
            <div class="receipt-row">
                <span class="text-muted">Date</span>
                <span><asp:Literal ID="litOrderDate" runat="server" /></span>
            </div>
            <div class="receipt-row">
                <span class="text-muted">Payment Method</span>
                <span><asp:Literal ID="litPaymentMethod" runat="server" /></span>
            </div>

            <hr class="my-3" style="border-color:#f1f5f9;" />

            <!-- Items -->
            <asp:Repeater ID="rptItems" runat="server">
                <ItemTemplate>
                    <div class="receipt-row">
                        <div>
                            <div class="fw-medium"><%# Eval("MenuItemName") %></div>
                            <small class="text-muted">Qty: <%# Eval("Quantity") %></small>
                        </div>
                        <div class="text-end fw-medium">
                            R <%# Eval("Subtotal", "{0:0.00}") %>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <!-- Total -->
            <div class="receipt-row receipt-total">
                <span>Total</span>
                <span>R <asp:Literal ID="litTotal" runat="server" /></span>
            </div>

            <asp:Panel ID="pnlChange" runat="server" Visible="false">
                <div class="receipt-row text-muted">
                    <span>Change Due</span>
                    <span>R <asp:Literal ID="litChange" runat="server" /></span>
                </div>
            </asp:Panel>
        </div>
    </div>

    <!-- Email status -->
    <div class="text-center">
        <asp:Label ID="lblEmailStatus" runat="server" CssClass="email-status" />
    </div>

    <!-- Action buttons -->
    <div class="action-buttons">
        <a href="~/CustomerDashboard.aspx" runat="server" class="btn btn-brand px-4">
            Back to Dashboard
        </a>
        <a href="~/Menu.aspx" runat="server" class="btn btn-outline-secondary px-4">
            Order Again
        </a>
    </div>

</div>
</asp:Content>