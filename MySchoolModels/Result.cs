using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolModels
{
    [Serializable]//序列化特性
  public  class Result
    {
        #region  属性
        /// <summary>
        /// 序号(标识主键列)
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        public Student StudentNo { get; set; }
        /// <summary>
        /// 课程编号
        /// </summary>
        public Subject SubjectNo { get; set; }
        /// <summary>
        /// 成绩
        /// </summary>
        public int StudentResult { get; set; }
        /// <summary>
        /// 考试日期
        /// </summary>
        public DateTime ExamDate { get; set; }

        #endregion

        #region 构造方法
        public Result()
        {
            StudentNo = new Student();
            SubjectNo = new Subject();
        }
        #endregion
    }
}
