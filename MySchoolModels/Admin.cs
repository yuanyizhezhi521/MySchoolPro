using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolModels
{
    [Serializable]//序列化特性
    public class Admin
    {
        #region 属性
        /// <summary>
        /// 登陆帐号
        /// </summary>
        public string  LoginId { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string LoginPwd { get; set; }
        #endregion
    }
}
