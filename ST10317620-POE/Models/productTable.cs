using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ST10317620_POE.Models
{
    public class productTable : Controller
    {
        public static string con_string = "Server=tcp:st10317620.database.windows.net,1433;Initial Catalog=st10317620_database;Persist Security Info=False;User ID=st10317620;Password= 8WNPW7SeUfVGelt;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCategory { get; set; }
        public bool ProductAvailability { get; set; }

        // Constructor
        public productTable(int productId, string productName, decimal productPrice, string productCategory, bool productAvailability)
        {
            ProductID = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductCategory = productCategory;
            ProductAvailability = productAvailability;
        }

        // Default constructor
        public productTable() { }

        // Override ToString() method for easier display of product information
        public override string ToString()
        {
            return $"ProductID: {ProductID}, ProductName: {ProductName}, ProductPrice: {ProductPrice:C}, ProductCategory: {ProductCategory}, ProductAvailability: {ProductAvailability}";
        }
    }
}
