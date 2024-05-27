using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ST10317620_POE.Controllers
{
    public class userLogin : Controller
    {
        private static readonly string conString = "Server=tcp:st10317620.database.windows.net,1433;Initial Catalog=st10317620_database;Persist Security Info=False;User ID=st10317620;Password=8WNPW7SeUfVGelt;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        private static readonly SqlConnection con = new SqlConnection(conString);

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

        // Method to authenticate user login
        public bool AuthenticateUser(string userEmail, string password)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT UserID, UserName FROM Users WHERE UserEmail = @UserEmail AND Password = @Password", con);
                cmd.Parameters.AddWithValue("@UserEmail", userEmail);
                cmd.Parameters.AddWithValue("@Password", password);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    UserID = Convert.ToInt32(reader["UserID"]);
                    UserName = Convert.ToString(reader["UserName"]);
                    UserEmail = userEmail;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                con.Close();
            }
        }
    }
}

