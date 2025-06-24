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
                //conn.Open(); // Ensure the connection is open before executing

                var tableCommands = new string[]
                {
            @"CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Username TEXT NOT NULL,
                Password TEXT NOT NULL,
                Role TEXT NOT NULL CHECK (Role IN ('Admin', 'Staff', 'Student', 'Lecturer'))
            );",

            @"CREATE TABLE IF NOT EXISTS Courses (
                CourseID INTEGER PRIMARY KEY AUTOINCREMENT,
                CourseName TEXT NOT NULL
            );",

            @"CREATE TABLE IF NOT EXISTS Subjects (
                SubjectID INTEGER PRIMARY KEY AUTOINCREMENT,
                SubjectName TEXT NOT NULL,
                CourseID INTEGER NOT NULL,
                FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
            );",

            @"CREATE TABLE IF NOT EXISTS Students (
                StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                CourseID INTEGER NOT NULL,
                FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
            );",

            @"CREATE TABLE IF NOT EXISTS Exams (
                ExamID INTEGER PRIMARY KEY AUTOINCREMENT,
                ExamName TEXT NOT NULL,
                SubjectID INTEGER NOT NULL,
                FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
            );",

            @"CREATE TABLE IF NOT EXISTS Marks (
                MarkID INTEGER PRIMARY KEY AUTOINCREMENT,
                StudentID INTEGER NOT NULL,
                ExamID INTEGER NOT NULL,
                Score INTEGER CHECK (Score >= 0 AND Score <= 100),
                FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
                FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
            );",

            @"CREATE TABLE IF NOT EXISTS Rooms (
                RoomID INTEGER PRIMARY KEY AUTOINCREMENT,
                RoomName TEXT NOT NULL,
                RoomType TEXT CHECK (RoomType IN ('Lab', 'Hall')) NOT NULL
            );",

            @"CREATE TABLE IF NOT EXISTS Timetables (
                TimetableID INTEGER PRIMARY KEY AUTOINCREMENT,
                SubjectID INTEGER NOT NULL,
                TimeSlot TEXT NOT NULL,
                RoomID INTEGER NOT NULL,
                FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID),
                FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID)
            );"
                };

                foreach (var sql in tableCommands)
                {
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }


    }
}
