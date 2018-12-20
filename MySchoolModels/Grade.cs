using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolModels
{
    [Serializable]//序列化
   public class Grade
    {
        #region 属性
        /// <summary>
        /// 年级编号
        /// </summary>
        public int GradeId { get; set; }
        /// <summary>
        /// 年级名称
        /// </summary>
        public string GradeName { get; set; }
        #endregion
    }
}
