using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySchoolBLL;
using MySchoolModels;

namespace MySchool
{
    public partial class LoginForm : Form
    {
        AdminManager adminManager = new AdminManager();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            if (true)
            {
                bool b = adminManager.SelectExistByLoginIdAndLoginPwd(txtLoginId.Text.Trim(), txtLoginPwd.Text.Trim());
                //admin.LoginId = txtLoginId.Text;
                //admin.LoginPwd = txtLoginPwd.Text;
                //bool b = adminManager.InsertAdmin(admin);
                if (b)
                {
                    //MessageBox.Show("OK", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("NO!", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            else
            {

            }
         
        }
    }
}
