using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Controller
{
    internal class StudentController
    {
        //ADD----------------------------------------------------------------------------------------------------


        private string connectionString = "Data Source=UNICOM.db;Version=3;";

        public StudentController()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string createTableQuery = @"CREATE TABLE IF NOT EXISTS People (
                                            Name TEXT,
                                            Address TEXT,
                                            Phone TEXT)";
                new SQLiteCommand(createTableQuery, conn).ExecuteNonQuery();
            }
        }

        public void AddPerson(Student p)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string insertQuery = "INSERT INTO Students (Name,CourseID) VALUES (@Name,@CourseID)";
                var cmd = new SQLiteCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("CourseID", p.CourseID);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Student> GetAllPeople()
        {
            var list = new List<Student>();
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM People";
                var cmd = new SQLiteCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Student
                        {
                            Name = reader["Name"].ToString(),
                            CourseID = (int)reader["CourseID"]
                        });
                    }
                }
            }
            return list;
        }

    }
}






