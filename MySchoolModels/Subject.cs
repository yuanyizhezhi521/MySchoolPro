using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolModels
{
    [Serializable]//序列化特性
   public class Subject
    {
        #region 属性
        /// <summary>
        /// 课程编号
        /// </summary>
        public int SubjectNo { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string SubjectName { get; set; }
        /// <summary>
        /// 课时
        /// </summary>
        public int ClassHour { get; set; }
        /// <summary>
        /// 所属年级
        /// </summary>
        public Grade GradeId { get; set; }

        #endregion

        #region 构造方法
        public Subject()
        {
            SubjectNo = 0;
            GradeId = new Grade();
            SubjectName = string.Empty;

        }
        #endregion
    }
}
