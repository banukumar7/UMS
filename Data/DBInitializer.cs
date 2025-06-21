using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Data
{
    internal class DBInitializer
    {
        public static void SeedUsers(SQLiteConnection con)
        {
            string query = "INSERT INTO Users (Username, Password, Role) VALUES (@u, @p, @r)";
            var users = new List<(string u, string p, string r)>
            {
              ("admin7", "admin123", "Admin"),
              ("student7", "stud123", "Student"),
              ("staff7", "staff123", "Staff"),
              ("lecturer7", "lect123", "Lecturer")
            };
  
            foreach (var user in users)
            {
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@u", user.u);
                    cmd.Parameters.AddWithValue("@p", user.p);
                    cmd.Parameters.AddWithValue("@r", user.r);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
