using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace DAL.Helper
{
    class SqlHelper
    {
        private static string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

        #region 执行格式化sql语句
        /// <summary>
        /// 执行增删改操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Update(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                // 将错误信息写入日志
                LogHelper.WriteLog(ex.Message);
                throw new Exception("执行方法【" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "】时，出错：" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 执行获取单一结果操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch(Exception ex)
            {
                // 将错误信息写入日志
                LogHelper.WriteLog(ex.Message);
                throw new Exception("执行方法【" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "】时，出错：" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>Reader</returns>
        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch(Exception ex)
            {
                conn.Close();
                // 将错误信息写入日志
                LogHelper.WriteLog(ex.Message);
                throw new Exception("执行方法【" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "】时，出错：" + ex.Message);
            }
        }
        #endregion

        #region 执行带参数的sql语句
        /// <summary>
        /// 执行增删改操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Update(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);//添加参数
                return cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                // 将错误信息写入日志
                LogHelper.WriteLog(ex.Message);
                throw new Exception("执行方法【" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "】时，出错：" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 执行获取单一结果操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);//添加参数
                return cmd.ExecuteScalar();
            }
            catch(Exception ex)
            {
                // 将错误信息写入日志
                LogHelper.WriteLog(ex.Message);
                throw new Exception("执行方法【" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "】时，出错：" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>Reader</returns>
        public static SqlDataReader GetReader(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);//添加参数
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch(Exception ex)
            {
                conn.Close();
                // 将错误信息写入日志
                LogHelper.WriteLog(ex.Message);
                throw new Exception("执行方法【" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "】时，出错：" + ex.Message);
            }
        }
        #endregion

        #region 使用事务执行多条SQL语句
        /// <summary>
        /// 使用事务执行多条SQL语句
        /// </summary>
        /// <param name="sqlList">SQL语句列表</param>
        /// <returns>成功与否</returns>
        public static bool UpdateByTran(List<string> sqlList)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.Transaction = conn.BeginTransaction();//开启事务
                foreach(var itemsql in sqlList)
                {
                    cmd.CommandText = itemsql;
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();//提交事务
                return true;
            }
            catch(Exception ex)
            {
                if(cmd.Transaction != null)
                {
                    cmd.Transaction.Rollback();
                }
                // 将错误信息写入日志
                LogHelper.WriteLog(ex.Message);
                throw new Exception("执行方法【" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "】时，出错：" + ex.Message);
            }
            finally
            {
                if(cmd.Transaction != null)
                {
                    cmd.Transaction = null;//清空事务
                }
                conn.Close();
            }
        }
        /// <summary>
        /// 使用事务执行带参数的多条SQL语句
        /// </summary>
        /// <param name="sqlList"></param>
        /// <param name="paramList"></param>
        /// <returns></returns>
        public static bool UpdateByTran(List<string> sqlList, List<SqlParameter[]> paramList)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.Transaction = conn.BeginTransaction();//开启事务
                for(int i = 0;i < sqlList.Count;i++)
                {
                    cmd.CommandText = sqlList[i];
                    cmd.Parameters.AddRange(paramList[i]);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = string.Empty;
                    cmd.Parameters.Clear();
                }
                cmd.Transaction.Commit();//提交事务
                return true;
            }
            catch(Exception ex)
            {
                if(cmd.Transaction != null)
                {
                    cmd.Transaction.Rollback();
                }
                // 将错误信息写入日志
                LogHelper.WriteLog(ex.Message);
                throw new Exception("执行方法【" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "】时，出错：" + ex.Message);
            }
            finally
            {
                if(cmd.Transaction != null)
                {
                    cmd.Transaction = null;//清空事务
                }
                conn.Close();
            }
        }
        #endregion

        #region 获取服务器时间
        /// <summary>
        /// 获取数据库服务器时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetServerTime()
        {
            string sql = "select getdate()";
            return Convert.ToDateTime(GetSingleResult(sql));
        }
        #endregion
    }
}
