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
    public partial class AddStudentForm : Form
    {
        #region 字段
        GradeManager gradeManager = new GradeManager();
        StudentManager studentManager = new StudentManager();
        #endregion

        #region 构造方法
        public AddStudentForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 事件处理
        /// <summary>
        /// 窗体加载事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddStudentForm_Load(object sender, EventArgs e)
        {
            if (UserHelper.state!=1)
            {
                this.Text = "修改学员信息";
                this.btnAdd.Visible = false;
                txtStudentNo.Enabled = false;
                txtStudentNo.ForeColor = Color.Red;
                btnAdd.Visible = false;
                cboGradeId.DataSource = gradeManager.GetAllGrade();
                cboGradeId.DisplayMember = "GradeName";
                cboGradeId.ValueMember = "GradeId";
                int studentNo = UserHelper.studentNo;
                Student stu = studentManager.GetStudentsByStudentNo(studentNo);
                txtStudentNo.Text = stu.StudentNo.ToString();
                txtLoginPwd.Text = stu.LoginPwd;
                txtStudentName.Text = stu.StudentName;
                if (stu.Gender)
                {
                    rbtnGender.Checked = true;
                }
                else
                {
                    rbtnGender2.Checked = true;
                }
                txtAddress.Text = stu.Address;
                txtEmail.Text = stu.Email;
                txtPhone.Text = stu.Phone;
                txtIdentityCard.Text = stu.IdentityCard;
                dtpBornDate.Text = stu.BornDate.ToShortDateString();
                cboGradeId.SelectedValue = stu.GradeId.GradeId;
            }
            this.btnUpdate.Visible = false;
            cboGradeId.DataSource = gradeManager.GetAllGrade();
            cboGradeId.DisplayMember = "GradeName";
            cboGradeId.ValueMember = "GradeId";
        }

        /// <summary>
        /// 添加事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student stu = new Student();
            stu.StudentNo =Convert.ToInt32( txtStudentNo.Text.Trim());
            stu.LoginPwd = txtLoginPwd.Text.Trim();
            stu.StudentName = txtStudentName.Text.Trim();
            stu.Gender = rbtnGender.Checked ?true:false;
            stu.GradeId = gradeManager.GetGradeByGradeId(Convert.ToInt32(cboGradeId.SelectedValue));
            stu.Phone = txtPhone.Text.Trim();
            stu.Address = txtAddress.Text.Trim();
            stu.BornDate =Convert.ToDateTime( dtpBornDate.Text);
            stu.Email = txtEmail.Text.Trim();
            stu.IdentityCard = txtIdentityCard.Text.Trim();
            if (ValidateInput())
            {
                if (studentManager.InsertStudent(stu))
                {
                    MessageBox.Show("添加成功!","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("添加失败!", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
               
               
            }
           
        }

        /// <summary>
        /// 修改事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student stu = new Student();
            stu.StudentNo = Convert.ToInt32(txtStudentNo.Text.Trim());
            stu.LoginPwd = txtLoginPwd.Text.Trim();
            stu.StudentName = txtStudentName.Text.Trim();
            stu.Gender = rbtnGender.Checked ? true : false;
            stu.GradeId = gradeManager.GetGradeByGradeId(Convert.ToInt32(cboGradeId.SelectedValue));
            stu.Phone = txtPhone.Text.Trim();
            stu.Address = txtAddress.Text.Trim();
            stu.BornDate = Convert.ToDateTime(dtpBornDate.Text);
            stu.Email = txtEmail.Text.Trim();
            stu.IdentityCard = txtIdentityCard.Text.Trim();
            if (ValidateInput())
            {
                studentManager.UpdateStudent(stu);
               
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 非空验证
        /// </summary>
        /// <returns></returns>
        public bool ValidateInput()
        {
            bool b = false;
            if (string.IsNullOrEmpty(txtStudentNo.Text))
            {
                MessageBox.Show("");
            }
            else
            {
                b = true;
            }
            return b;
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void ClearTextBox()
        {
            foreach (var item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tb = (TextBox)item;
                    tb.Text = "";
                }
            }
        }
        #endregion

        
    }
}
