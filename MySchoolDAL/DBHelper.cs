using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;//引入数据库命名空间
using System.Configuration;//引入configuration命名空间

namespace MySchoolDAL
{
    /// <summary>
    /// 数据库连接类和Connection对象
    /// </summary>
    class DBHelper
    {
        //数据库连接字符串
        private readonly string connString = ConfigurationManager.ConnectionStrings["MySchool"].ToString();

        //定义数据库连接对象
        private SqlConnection con;
        //定义数据命令对象
        public SqlCommand cmd;

        /// <summary>
        /// 初始化连接对象和命令对象
        /// </summary>
        public DBHelper()
        {
            con = new SqlConnection(connString);
            cmd = con.CreateCommand();
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void ConnOpen()
        {
            con.Open();
        }

        /// <summary>
        /// 执行增,删,改SQL语句的方法
        /// </summary>
        /// <param name="sql">参数为SQL语句</param>
        public int ExecuteNonQuery(string sql)
        {
            cmd = new SqlCommand(sql, con);
            int result = cmd.ExecuteNonQuery();
            return result;
        }


        /// <summary>
        /// 执行查询单个值SQL语句的方法返回int型的数据
        /// </summary>
        /// <param name="sql">参数为SQL语句</param>
        public int NewExecute(string sql)
        {
            cmd = new SqlCommand(sql, con);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }

        /// <summary>
        /// 执行查询单个值SQL语句的方法返回string型的数据
        /// </summary>
        /// <param name="sql">参数为SQL语句</param>
        public string NewExecuteScalar(string sql)
        {
            cmd = new SqlCommand(sql, con);
            string result = cmd.ExecuteScalar().ToString();
            return result;
        }


        /// <summary>
        /// 执行返回DataSet  SQL语句的方法
        /// </summary>
        /// <param name="sql">参数为SQL语句</param>
        /// <returns>DataSet</returns>
        public DataSet ExecuteQuery(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        /// <summary>
        /// 执行返回DataTable  SQL语句的方法
        /// </summary>
        /// <param name="sql">参数为SQL语句</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteDataTable(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        /// <summary>
        /// 执行返回DataView  SQL语句的方法
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="filter">筛选表达式</param>
        /// <param name="sort">排序表达式</param>
        /// <returns>DataView</returns>
        public DataView GetDataView(string sql,string filter,string sort)
        {
            DataView dv = new DataView(ExecuteDataTable(sql));
            if (filter!="")
            {
                dv.RowFilter = filter;
            } 
			 if (sort!="")
            {
                dv.Sort = sort;
            } 
            return dv;
        }

        /// <summary>
        /// 返回值为SqlDataReader对象的方法
        /// </summary>
        /// <param name="sql">参数为SQL语句</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader GetDataReaderbySql(string sql)
        {
            try
            {
                cmd = new SqlCommand(sql, con);
                return cmd.ExecuteReader();
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// 关闭数据库的方法
        /// </summary>
        /// <returns>判断是否关闭</returns>
        public bool CloseDataBase()
        {
            con.Close();
            Dispose();
            return true;
        }


        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }


        protected virtual void Dispose(bool bDispose)
        {
            if (!bDispose)
                return;
            if (con.State != ConnectionState.Closed)
            {
		con.Close();
                con.Dispose();  
                cmd = null;
                con = null;
            }
        }
    }
}