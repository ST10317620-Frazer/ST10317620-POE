using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ST10317620_POE.Controllers
{
    public class transactions : Controller
    {
        private static readonly string conString = "Server=tcp:st10317620.database.windows.net,1433;Initial Catalog=st10317620_database;Persist Security Info=False;User ID=st10317620;Password=8WNPW7SeUfVGelt;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        private static readonly SqlConnection con = new SqlConnection(conString);

        // Method to place an order
        public void PlaceOrder(int userID, int productID, int quantity)
        {
            try
            {
                con.Open();
                // Check if the product is available
                SqlCommand availabilityCmd = new SqlCommand("SELECT ProductAvailability FROM Products WHERE ProductID = @ProductID", con);
                availabilityCmd.Parameters.AddWithValue("@ProductID", productID);
                bool productAvailable = Convert.ToBoolean(availabilityCmd.ExecuteScalar());
                if (!productAvailable)
                {
                    throw new Exception("Product is not available.");
                }

                // Insert order into Orders table
                SqlCommand insertCmd = new SqlCommand("INSERT INTO Orders (UserID, ProductID, Quantity, OrderDate) VALUES (@UserID, @ProductID, @Quantity, GETDATE())", con);
                insertCmd.Parameters.AddWithValue("@UserID", userID);
                insertCmd.Parameters.AddWithValue("@ProductID", productID);
                insertCmd.Parameters.AddWithValue("@Quantity", quantity);
                insertCmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        // Method to retrieve user orders
        public DataTable GetUserOrders(int userID)
        {
            DataTable orders = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Orders WHERE UserID = @UserID", con);
                cmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(orders);
            }
            finally
            {
                con.Close();
            }
            return orders;
        }

        // Method to process an order (for KhumaloCraft users)
        public void ProcessOrder(int orderID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Orders SET Processed = 1 WHERE OrderID = @OrderID", con);
                cmd.Parameters.AddWithValue("@OrderID", orderID);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
    }
}