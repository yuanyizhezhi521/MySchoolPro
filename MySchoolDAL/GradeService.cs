using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchoolModels;
using System.Data;

namespace MySchoolDAL
{
  public  class GradeService
    {
        DBHelper db = new DBHelper();

        /// <summary>
        /// 根据gradeId得到Grade对象
        /// </summary>
        /// <param name="gradeId"></param>
        /// <returns></returns>
        public Grade GetGradeByGradeId(int gradeId)
        {
            Grade grade=null;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select * from Grade where GradeId={0}", gradeId);
           DataTable dt= db.ExecuteDataTable(sb.ToString());
            foreach (DataRow item in dt.Rows)
            {
                grade = new Grade();
                grade.GradeId = Convert.ToInt32(item[0]);
                grade.GradeName = item[1].ToString();
            }
            return grade;
        }


        /// <summary>
        /// 得到全部年级信息
        /// </summary>
        /// <returns></returns>
        public List<Grade> GetAllGrade()
        {
            List<Grade> grades = new List<Grade>();
            Grade grade;
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Grade");
            DataTable dt = db.ExecuteDataTable(sb.ToString());
            foreach (DataRow item in dt.Rows)
            {
                grade = new Grade();
                grade.GradeId = Convert.ToInt32(item[0]);
                grade.GradeName = item[1].ToString();
                grades.Add(grade);
            }
            return grades;
        }
    }
}
