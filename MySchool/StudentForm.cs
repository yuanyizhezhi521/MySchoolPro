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
    public partial class StudentForm : Form
    {
        StudentManager studentManager = new StudentManager();
        public StudentForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentForm_Load(object sender, EventArgs e)
        {
           dgvStudents.DataSource= studentManager.GetAllStudent();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                dgvStudents.DataSource = studentManager.GetAllStudent();
            }
            else
            {
                dgvStudents.DataSource = studentManager.GetStudentsByStudentName(txtName.Text.Trim());
            }
         
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(dgvStudents.CurrentRow.Cells[0].Value);
           bool b= studentManager.DelStudentByStudentNo(num);
            if (b)
            {
                MessageBox.Show("OK");
                dgvStudents.DataSource = studentManager.GetAllStudent();
            }
            else
            {
                MessageBox.Show("no");
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UserHelper.studentNo = Convert.ToInt32(dgvStudents.CurrentRow.Cells[0].Value);
            UserHelper.state = 2;
            AddStudentForm addStudentForm = new AddStudentForm();
            addStudentForm.Show();
        }
    }
}
