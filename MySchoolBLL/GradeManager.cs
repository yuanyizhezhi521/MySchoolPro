using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchoolDAL;
using MySchoolModels;

namespace MySchoolBLL
{
   public class GradeManager
    {
        GradeService gradeService = new GradeService();

        /// <summary>
        /// 得到全部年级信息
        /// </summary>
        /// <returns></returns>
        public List<Grade> GetAllGrade()
        {
            return gradeService.GetAllGrade();
        }

        /// <summary>
        /// 根据gradeId得到Grade对象
        /// </summary>
        /// <param name="gradeId"></param>
        /// <returns></returns>
        public Grade GetGradeByGradeId(int gradeId)
        {
            return gradeService.GetGradeByGradeId(gradeId);
        }
    }
}
