using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchoolDAL;
using MySchoolModels;

namespace MySchoolBLL
{
    /// <summary>
    /// 对Student表的业务处理
    /// </summary>
    public class StudentManager
    {
        #region 字段
        StudentService studentService = new StudentService();
        #endregion

        #region 增删改查方法
        /// <summary>
        /// 增加新学员
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public bool InsertStudent(Student stu)
        {
            bool b = false;
            int num = studentService.InsertStudent(stu);
            if (num > 0)
            {
                b = true;
            }
            return b;
        }


        /// <summary>
        /// 得到全部学员信息
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAllStudent()
        {
            return studentService.GetAllStudent();
        }


        /// <summary>
        /// 根据studentName得到学员信息
        /// </summary>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public List<Student> GetStudentsByStudentName(string studentName)
        {
            return studentService.GetStudentsByStudentName(studentName);
        }


        /// <summary>
        /// 根据studentNo删除Student
        /// </summary>
        /// <param name="studentNo"></param>
        /// <returns></returns>
        public bool DelStudentByStudentNo(int studentNo)
        {
            bool b = false;
            int num = studentService.DelStudentByStudentNo(studentNo);
            if (num > 0)
            {
                b = true;
            }
            return b;
        }

        /// <summary>
        /// 根据学员修改学员信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool UpdateStudent(Student student)
        {
            bool b = false;
            int num = studentService.UpdateStudent(student);
            if (num > 0)
            {
                b = true;
            }
            return b;
        }


        /// <summary>
        /// 根据studentNo得到学员信息
        /// </summary>
        /// <param name="studentNo"></param>
        /// <returns></returns>
        public Student GetStudentsByStudentNo(int studentNo)
        {
            return studentService.GetStudentsByStudentNo(studentNo);
        }
        #endregion
    }
}
