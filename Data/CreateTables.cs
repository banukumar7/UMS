using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Data
{
    internal class CreateTables
    {
        public static void CreateTable()
        {
            using (var conn = DataConn.GetConnection())
            {
                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                
                    CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL,
                    Password TEXT NOT NULL,
                    Role TEXT NOT NULL CHECK (Role IN ('Admin', 'Staff', 'Student', 'Lecturer'))
                     );

                ";
               
                
                  cmd.ExecuteNonQuery(); 
            }
        }

    }
}
