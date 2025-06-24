using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Controller
{
    internal class CourseController
    {
        public static bool AddCourse(Course course)
        {
            try
            {
                using (var conn = DataConn.GetConnection())
                {
                    string query = "INSERT INTO Courses (CourseName) VALUES (@CourseName)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddCourse error: " + ex.Message);
                return false;
            }
        }

        // READ ALL
        public static List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();
            try
            {
                using (var conn = DataConn.GetConnection())
                {
                    string query = "SELECT * FROM Courses";
                    using (var cmd = new SQLiteCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Course course = new Course
                            {
                                CourseID = Convert.ToInt32(reader["CourseID"]),
                                CourseName = reader["CourseName"].ToString()
                            };
                            courses.Add(course);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetAllCourses error: " + ex.Message);
            }
            return courses;
        }

        // UPDATE
        public static bool UpdateCourse(Course course)
        {
            try
            {
                using (var conn = DataConn.GetConnection())
                {
                    string query = "UPDATE Courses SET CourseName = @CourseName WHERE CourseID = @CourseID";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                        cmd.Parameters.AddWithValue("@CourseID", course.CourseID);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateCourse error: " + ex.Message);
                return false;
            }
        }

        // DELETE
        public static bool DeleteCourse(int courseId)
        {
            try
            {
                using (var conn = DataConn.GetConnection())
                {
                    string query = "DELETE FROM Courses WHERE CourseID = @CourseID";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CourseID", courseId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DeleteCourse error: " + ex.Message);
                return false;
            }
        }

        // GET SINGLE BY ID
        public static Course GetCourseById(int courseId)
        {
            Course course = null;
            try
            {
                using (var conn = DataConn.GetConnection())
                {
                    string query = "SELECT * FROM Courses WHERE CourseID = @CourseID";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CourseID", courseId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                course = new Course
                                {
                                    CourseID = Convert.ToInt32(reader["CourseID"]),
                                    CourseName = reader["CourseName"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetCourseById error: " + ex.Message);
            }
            return course;
        }
    }
}
