namespace Cafe101.Logic
{
    public class MenuItemDetails
    {
        public int MenuItemID { get; set; }

        public string MenuItemName { get; set; }

        public decimal SellingPrice { get; set; }

        public decimal CostToMake { get; set; }

        public string Category { get; set; }

        public int PreparationTime { get; set; }

        public int AvailableQuantity { get; set; }

        public string StockStatus { get; set; }

        public int QuantitySold { get; set; }
    }
}