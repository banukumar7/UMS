using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controller;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.View
{
    public partial class Cours : Form
    {
        public Cours()
        {
            InitializeComponent();
            LoadCourseData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Course newCourse = new Course()
            {
                CourseName = textBox1.Text
            };

            bool added = CourseController.AddCourse(newCourse);
            MessageBox.Show(added ? "Course added" : "Failed to add");
        }
        private void LoadCourseData()
        {
            var courseList = CourseController.GetAllCourses();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = courseList;

            if (dataGridView1.Columns["CourseID"] != null)
                dataGridView1.Columns["CourseID"].HeaderText = "Course ID";
            if (dataGridView1.Columns["CourseName"] != null)
                dataGridView1.Columns["CourseName"].HeaderText = "Course Name";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["CourseName"].Value.ToString();
                // You can also save the selected CourseID if needed
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
