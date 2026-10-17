using global::Cafe101.Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cafe101.Web
{
    public partial class CartandPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check the customer session before displaying cart information.
            if (Session["UserID"] == null ||
                !string.Equals(
                    Convert.ToString(Session["UserType"]),
                    "Customer",
                    StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/SignIn.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            // This page currently displays the cart without changing it.
            LoadCart();
        }

        private void LoadCart()
        {
            // Read the same session key used when adding products on Menu.aspx.
            List<CartItem> cart =
                Session["Cart"] as List<CartItem>
                ?? new List<CartItem>();

            rptCartItems.DataSource = cart;
            rptCartItems.DataBind();

            pnlEmptyCart.Visible = cart.Count == 0;

            lblItemsSubtotal.Text =
                "R " + cart.Sum(item => item.LineTotal).ToString("0.00");
        }
    }
}