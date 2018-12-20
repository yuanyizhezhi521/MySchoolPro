using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchoolDAL;
using MySchoolModels;

namespace MySchoolBLL
{
    public class AdminManager
    {
        AdminService adminService = new AdminService();

        /// <summary>
        /// 通过帐号和密码查询输入是否正确
        /// </summary>
        /// <param name="loginId">帐号</param>
        /// <param name="loginPwd">密码</param>
        /// <returns></returns>
        public bool SelectExistByLoginIdAndLoginPwd(string loginId, string loginPwd)
        {
            bool result = false;
            int num = adminService.SelectExistByLoginIdAndLoginPwd(loginId, loginPwd);
            if (num > 0)
            {
                result = true;
            }
            return result;
            //return adminService.SelectExistByLoginIdAndLoginPwd(loginId, loginPwd);
        }

        /// <summary>
        /// 增加管理员帐号
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool InsertAdmin(Admin admin)
        {
            bool result = false;
            int num= adminService.InsertAdmin(admin);
            if (num > 0)
            {
                result = true;
            }
            return result;
        }

    }
}
