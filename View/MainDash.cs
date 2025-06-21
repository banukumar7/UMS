using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.View
{
    public partial class MainDash : Form
    {
        public MainDash()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        { 
            public partial class MainForm : Form
        { 
            public MainForm(string role)
            {
                LoginForm();
                LoadRoleBasedForm(role); // LoginForm-இல் இருந்து வரும் role
            }

            private void LoadRoleBasedForm(string role)
            {
                Form dashboard = null;

                switch (role.ToLower())
                {
                    case "admin":
                        dashboard = new AdminDash();
                        break;
                    case "staff":
                        dashboard = new StaffDash();
                        break;
                    case "student":
                        dashboard = new StudentDash();
                        break;
                    case "lecturer":
                        dashboard = new LecturerDash();
                        break;
                    default:
                        MessageBox.Show("Unknown role");
                        return;
                }

                // Panelஐத் தூய்மையாக்கு
                panel2.Controls.Clear();

                // Form settings
                dashboard.TopLevel = false;
                dashboard.FormBorderStyle = FormBorderStyle.None;
                dashboard.Dock = DockStyle.Fill;

                panel2.Controls.Add(dashboard);
                dashboard.Show();
            }
        }

    }
}

