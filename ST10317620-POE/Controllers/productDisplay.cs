using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ST10317620_POE.Controllers
{
    public class productDisplay : Controller
    {
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

        // constructor
        public productTable() { }

        public override string ToString()
        {
            return $"ProductID: {ProductID}, ProductName: {ProductName}, ProductPrice: {ProductPrice:C}, ProductCategory: {ProductCategory}, ProductAvailability: {ProductAvailability}";
        }
    }
}
