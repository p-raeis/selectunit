using Selection.Business_Logic_Layer;
using Selection.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Selection.User_Interface
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (TextBoxsofForm.IsNullOrEmpty(this))
            {
                lblError.Text = "تمامی فیلد ها باید پر شوند";
                return;
            }
            Students studentModel = new Students();
            studentModel.Address = txtAddress.Text;
            studentModel.Family = txtFamily.Text;
            studentModel.FieldId = int.Parse(txtField.Text);
            if (Female.Checked)
                studentModel.Gender = false;
            else
                studentModel.Gender = true;
            studentModel.ID = int.Parse(txtStudentID.Text);
            studentModel.Name = txtName.Text;
            studentModel.Phone = txtPhone.Text;


            BLL BusinessLayer = new BLL();
            Result result = BusinessLayer.Register(studentModel);
            if (!result.Error)
            {
                MessageBox.Show("ثبت اطلاعات با موفقیت انجام  شد");
            }
            else
            {
                MessageBox.Show("ثبت انجام نشد" + result.Message);
            }

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFamily_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
