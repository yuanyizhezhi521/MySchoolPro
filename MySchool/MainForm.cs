using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySchool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnSelect_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            studentForm.MdiParent = this;
            studentForm.Show();
        }
        /// <summary>
        /// 退出操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiExit_Click(object sender, EventArgs e)
        {
          DialogResult dialogResult=  MessageBox.Show("确定退出?","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (dialogResult== DialogResult.OK)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// 正在关闭主窗体时提示操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确定退出?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult!= DialogResult.OK)
            {           
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        /// <summary>
        /// 主窗体关闭后执行退出操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            tiTime.Enabled = true;
          
        }

        /// <summary>
        /// 定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tiTime_Tick(object sender, EventArgs e)
        {
            tsslblDatetime.Text = DateTime.Now.ToString();
        }

        /// <summary>
        /// 新建菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiNewStudent_Click(object sender, EventArgs e)
        {
            UserHelper.state = 1;
            AddStudentForm addStudentForm = new AddStudentForm();
            addStudentForm.MdiParent = this;
            addStudentForm.Show();
        }

        /// <summary>
        /// 查询菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiSelect_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            studentForm.MdiParent = this;
            studentForm.Show();
        }

        /// <summary>
        /// 新建工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnNewStudent_Click(object sender, EventArgs e)
        {
            UserHelper.state = 1;
            AddStudentForm addStudentForm = new AddStudentForm();
            addStudentForm.MdiParent = this;
            addStudentForm.Show();
        }
    }
}
