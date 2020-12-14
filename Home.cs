using Selection.Business_Logic_Layer;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentID.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                lblError.Text = "لطفا فیلد مورد نظر را پر نمایید";
                return;
            }
            BLL BusinessLayer = new BLL();
            Result result = BusinessLayer.CheckPassword(int.Parse(txtStudentID.Text), txtPassword.Text);
            if (result.Error)
            {
                lblError.Text = result.Message;
            }
            else
            {
                Selection selection = new Selection(BusinessLayer.GetStudentByID(int.Parse(txtStudentID.Text)));
                selection.Show();
            }

        }
        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Registration registration = new Registration();
            registration.Show();
        }
    }
}
