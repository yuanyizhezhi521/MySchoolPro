using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySchoolModels;

namespace MySchoolDAL
{
    public class AdminService
    {
        DBHelper db = new DBHelper();
        /// <summary>
        /// 通过帐号和密码查询输入是否正确
        /// </summary>
        /// <param name="loginId">帐号</param>
        /// <param name="loginPwd">密码</param>
        /// <returns></returns>
        public int SelectExistByLoginIdAndLoginPwd(string loginId,string loginPwd)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"select count(*) from [dbo].[Admin]
where[LoginId] = '{0}'
and[LoginPwd] = '{1}'", loginId, loginPwd);
            db.ConnOpen();
          int num=Convert.ToInt32(  db.NewExecuteScalar(sb.ToString()));
            db.CloseDataBase();
            return num;
        }

        /// <summary>
        /// 增加管理员帐号
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public int InsertAdmin(Admin  admin)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("insert into admin values ('{0}','{1}') ", admin.LoginId,admin.LoginPwd);
            db.ConnOpen();
            int num=  db.ExecuteNonQuery(sb.ToString());
            db.CloseDataBase();
            return num;


        }
    }
}
