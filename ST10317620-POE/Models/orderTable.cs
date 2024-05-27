using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ST10317620_POE.Models
{
    public class orderTable : Controller
    {
        public static string con_string = "Server=tcp:st10317620.database.windows.net,1433;Initial Catalog=st10317620_database;Persist Security Info=False;User ID=st10317620;Password= 8WNPW7SeUfVGelt;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public string OrderStatus { get; set; }

        // Constructor
        public orderTable(int orderId, int userId, int quantity, int productId, string orderStatus)
        {
            OrderID = orderId;
            UserID = userId;
            Quantity = quantity;
            ProductID = productId;
            OrderStatus = orderStatus;
        }

        // Default constructor
        public orderTable() { }

        // Override ToString() method for easier display of order information
        public override string ToString()
        {
            return $"OrderID: {OrderID}, UserID: {UserID}, Quantity: {Quantity}, ProductID: {ProductID}, OrderStatus: {OrderStatus}";
        }
    }
}
