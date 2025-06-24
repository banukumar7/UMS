using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsApp1.Controller;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.View
{
    public partial class AdminStudent : Form
    {
        public AdminStudent()
        {
            InitializeComponent();

            // Setup DataGridView
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Name";
            dataGridView1.Columns[1].Name = "Course Name";

            LoadCoursesToComboBox(); // Load course list into comboBox1
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ManageStudent_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student p = new Student
            {
                Name = textBox1.Text,
                CourseID = Convert.ToInt32(comboBox1.SelectedValue) // ✅ Correct
            };

            // Add to SQLite through controller
            StudentController controller = new StudentController();
            controller.AddPerson(p);

            // Get Course Name from ComboBox
            string selectedCourseName = ((Course)comboBox1.SelectedItem).CourseName;

            // Show in DataGridView (only once!)
            dataGridView1.Rows.Add(p.Name, selectedCourseName);

            // Clear textboxes
            textBox1.Clear();
            //textBox3.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadCoursesToComboBox()
        {
            var courseList = CourseController.GetAllCourses();
            comboBox1.DataSource = courseList;
            comboBox1.DisplayMember = "CourseName";  // what is shown
            comboBox1.ValueMember = "CourseID";      // hidden value
        }
        private void button2_Click(object sender, EventArgs e)
        {
         
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
