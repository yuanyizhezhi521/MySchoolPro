using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchoolModels;
using System.Data.SqlClient;
using System.Data;

namespace MySchoolDAL
{
    /// <summary>
    /// 对Student表数据操作
    /// </summary>
    public class StudentService
    {
        #region 定义字段
        DBHelper db = new DBHelper();
        GradeService gradeService = new GradeService();
        #endregion

        #region 增删改查方法
        /// <summary>
        /// 增加新学员
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public int InsertStudent(Student stu)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"insert into Student values 
({0},'{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}')",stu.StudentNo,stu.LoginPwd,stu.StudentName,stu.Gender,stu.GradeId.GradeId,stu.Phone,stu.Address,stu.BornDate,stu.Email,stu.IdentityCard);
            db.ConnOpen();
            int num= db.ExecuteNonQuery(sb.ToString());
            db.CloseDataBase();
            return num;
        }


        /// <summary>
        /// 得到全部学员信息
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAllStudent()
        {
            List<Student> students = new List<Student>();
            Student student;
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Student");
            DataTable dt = db.ExecuteDataTable(sb.ToString());
            foreach (DataRow item in dt.Rows)
            {
                student = new Student();
                student.StudentNo = Convert.ToInt32(item[0]);
                student.LoginPwd = item[1].ToString();
                student.StudentName = item[2].ToString();
                student.Gender =Convert.ToBoolean(item[3]);
                student.GradeId = gradeService.GetGradeByGradeId(Convert.ToInt32( item[4]));
                student.Phone = item[5].ToString();
                student.Address = item[6].ToString();
                student.BornDate = Convert.ToDateTime(item[7]);
                student.Email = item[8].ToString();
                student.IdentityCard = item[9].ToString();
                students.Add(student);
            }
            return students;
        }


        /// <summary>
        /// 根据studentName得到学员信息
        /// </summary>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public List<Student> GetStudentsByStudentName(string studentName)
        {
            List<Student> students = new List<Student>();
            Student student;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select * from Student where StudentName like '%{0}%'", studentName);
            DataTable dt = db.ExecuteDataTable(sb.ToString());
            foreach (DataRow item in dt.Rows)
            {
                student = new Student();
                student.StudentNo = Convert.ToInt32(item[0]);
                student.LoginPwd = item[1].ToString();
                student.StudentName = item[2].ToString();
                student.Gender = Convert.ToBoolean(item[3]);
                student.GradeId = gradeService.GetGradeByGradeId(Convert.ToInt32(item[4]));
                student.Phone = item[5].ToString();
                student.Address = item[6].ToString();
                student.BornDate = Convert.ToDateTime(item[7]);
                student.Email = item[8].ToString();
                student.IdentityCard = item[9].ToString();
                students.Add(student);
            }
            return students;
        }

        /// <summary>
        /// 根据studentNo删除Student
        /// </summary>
        /// <param name="studentNo"></param>
        /// <returns></returns>
        public int DelStudentByStudentNo(int studentNo)
        {
            int num = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("delete from student where StudentNo ={0}", studentNo);
            db.ConnOpen();
            num=db.ExecuteNonQuery(sb.ToString());
            db.CloseDataBase();
            return num;
        }

        /// <summary>
        /// 根据学员修改学员信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int UpdateStudent(Student student)
        {
            int num = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"update Student set [LoginPwd]='{0}',[StudentName]='{1}',
[Gender]='{2}',[GradeId]={3},[Phone]='{4}',[Address]='{5}',
[BornDate]='{6}',[Email]='{7}',[IdentityCard]='{8}'
where [StudentNo]={9}", student.LoginPwd, student.StudentName, student.Gender, student.GradeId.GradeId, student.Phone, student.Address, student.BornDate, student.Email, student.IdentityCard, student.StudentNo);
            db.ConnOpen();
            num=db.ExecuteNonQuery(sb.ToString());
            return num;
        }


        /// <summary>
        /// 根据studentNo得到学员信息
        /// </summary>
        /// <param name="studentNo"></param>
        /// <returns></returns>
        public Student GetStudentsByStudentNo(int studentNo)
        {
           
            Student student=null;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select * from Student where StudentNo = {0}", studentNo);
            DataTable dt = db.ExecuteDataTable(sb.ToString());
            foreach (DataRow item in dt.Rows)
            {
                student = new Student();
                student.StudentNo = Convert.ToInt32(item[0]);
                student.LoginPwd = item[1].ToString();
                student.StudentName = item[2].ToString();
                student.Gender = Convert.ToBoolean(item[3]);
                student.GradeId = gradeService.GetGradeByGradeId(Convert.ToInt32(item[4]));
                student.Phone = item[5].ToString();
                student.Address = item[6].ToString();
                student.BornDate = Convert.ToDateTime(item[7]);
                student.Email = item[8].ToString();
                student.IdentityCard = item[9].ToString();
                
            }
            return student;
        }
        #endregion

    }
}
