using Selection.Business_Logic_Layer;
using Selection.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Selection.User_Interface
{
    public partial class Selection : Form
    {
        Students _student;
        public Selection(Students student)
        {
            _student = student;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Selection_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
        void BindGrid()
        {
            BLL businessLayer = new BLL();
            dgvCourse.AutoGenerateColumns = false;
            dgvCourse.DataSource = businessLayer.GetCourses();
        }

        private void dgvCourse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCourseId.Text = dgvCourse.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
          
            lblerror.Text = "";
            if (string.IsNullOrEmpty(txtCourseId.Text))
                lblerror.Text = "لطفا درس مورد نظر خود را انتخاب نمایید";
            else
            {
                BLL businessLayer = new BLL();
                if (!businessLayer.BindeCourse(_student.ID, int.Parse(txtCourseId.Text)))
                    lblerror.Text =  "درس انتخاب شده تکراری میباشد";
                else
                    MessageBox.Show("عملیات با موفقیت انجام شد");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
