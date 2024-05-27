using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ST10317620_POE.Models
{
    public class userLogin : Controller
    {
        public static string con_string = "Server=tcp:st10317620.database.windows.net,1433;Initial Catalog=st10317620_database;Persist Security Info=False;User ID=st10317620;Password= 8WNPW7SeUfVGelt;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public int UserID { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }

        // Constructor
        public userLogin(int userId, string userEmail, string userName)
        {
            UserID = userId;
            UserEmail = userEmail;
            UserName = userName;
        }

        // Default constructor
        public userLogin() { }

        // Override ToString() method for easier display of user information
        public override string ToString()
        {
            return $"UserID: {UserID}, UserEmail: {UserEmail}, UserName: {UserName}";
        }
    }
}
