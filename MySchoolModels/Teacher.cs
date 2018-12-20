using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolModels
{
    [Serializable]//序列化特性
   public class Teacher
    {
        #region 属性
        /// <summary>
        /// 序号(标识主键列)
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 教龄
        /// </summary>
        public int TeachYear { get; set; }
        /// <summary>
        /// 所带年级
        /// </summary>
        public Grade GradeId { get; set; }
        #endregion

        #region 构造方法
        public Teacher()
        {
            GradeId = new Grade();
        }
        #endregion
    }
}
