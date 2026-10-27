using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cafe101.Logic
{
    // Allows the cart item to be stored by session providers
    // that require serializable objects.
    [Serializable]
    public class CartItem
    {
        // Links this cart item to its record in MenuItemsTable.
        public int MenuItemID { get; set; }

        public string MenuItemName { get; set; }

        // Price when the item was added.
        // Checkout must check the current database price again.
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        // Calculated from the price and quantity rather than stored separately.
        public decimal LineTotal
        {
            get { return UnitPrice * Quantity; }
        }
    }
}