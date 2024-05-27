using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace ST10317620_POE.Controllers
{
    public class product : Controller
    {
        private static readonly string conString = "Server=tcp:st10317620.database.windows.net,1433;Initial Catalog=st10317620_database;Persist Security Info=False;User ID=st10317620;Password=8WNPW7SeUfVGelt;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        private static readonly SqlConnection con = new SqlConnection(conString);

        // Method to get all products
        public List<productTable> GetAllProducts()
        {
            List<productTable> productList = new List<productTable>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productTable product = new productTable
                    {
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        ProductName = Convert.ToString(reader["ProductName"]),
                        ProductPrice = Convert.ToDecimal(reader["ProductPrice"]),
                        ProductCategory = Convert.ToString(reader["ProductCategory"]),
                        ProductAvailability = Convert.ToBoolean(reader["ProductAvailability"])
                    };
                    productList.Add(product);
                }
            }
            finally
            {
                con.Close();
            }
            return productList;
        }
    }
}
