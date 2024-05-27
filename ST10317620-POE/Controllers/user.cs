using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ST10317620_POE.Controllers
{
    public class user : Controller
    {
        private static readonly string conString = "Server=tcp:st10317620.database.windows.net,1433;Initial Catalog=st10317620_database;Persist Security Info=False;User ID=st10317620;Password=8WNPW7SeUfVGelt;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        private static readonly SqlConnection con = new SqlConnection(conString);

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }

        // Constructor
        public user(int userId, string userName, string userEmail)
        {
            UserID = userId;
            UserName = userName;
            UserEmail = userEmail;
        }

        // Default constructor
        public user() { }

        // Override ToString() method for easier display of user information
        public override string ToString()
        {
            return $"UserID: {UserID}, UserName: {UserName}, UserEmail: {UserEmail}";
        }

        // Method to get user by ID
        public user GetUserByID(int userID)
        {
            user user = null;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserID = @UserID", con);
                cmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new user
                    {
                        UserID = Convert.ToInt32(reader["UserID"]),
                        UserName = Convert.ToString(reader["UserName"]),
                        UserEmail = Convert.ToString(reader["UserEmail"])
                    };
                }
            }
            finally
            {
                con.Close();
            }
            return user;
        }

        // Method to get user by email
        public user GetUserByEmail(string userEmail)
        {
            user user = null;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserEmail = @UserEmail", con);
                cmd.Parameters.AddWithValue("@UserEmail", userEmail);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new user;
                    {
                        UserID = Convert.ToInt32(reader["UserID"]);
                        UserName = Convert.ToString(reader["UserName"]);
                        UserEmail = Convert.ToString(reader["UserEmail"]);
                    };
                }
            }
            finally
            {
                con.Close();
            }
            return user;
        }
    }
}
