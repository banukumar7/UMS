using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.View
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password");
                return;
            }

            string connectionString = "Data Source=UNICOM.db;Version=3;";
            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();

                string query = "SELECT Role FROM Users WHERE Username = @uname AND Password = @pass";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@uname", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    var roleObj = cmd.ExecuteScalar();

                    if (roleObj == null)
                    {
                        MessageBox.Show("Invalid username or password");
                        return;
                    }

                    string role = roleObj.ToString();

                    this.Hide(); // Hide login form

                    switch (role)
                    {
                        case "Admin":
                            new AdminDash().ShowDialog();
                            break;

                        case "Student":
                            new StudentDash().ShowDialog();
                            break;

                        case "Lecturer":
                            new LecturerDash().ShowDialog();
                            break;

                        case "Staff":
                            new StaffDash().ShowDialog();
                            break;

                        default:
                            MessageBox.Show("Unknown role");
                            break;
                    }

                    this.Show(); // After dashboard closes, show login form again
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
