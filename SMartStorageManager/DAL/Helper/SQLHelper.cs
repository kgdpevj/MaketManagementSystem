using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace DAL.Helper
{
    /// <summary>
    /// 通用数据访问类
    /// </summary>
    class SQLHelper
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private static string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
        #region 执行格式化SQL语句
        /// <summary>
        /// 增删改操作
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
            catch(System.Exception ex)
            {
                //将错误信息写入日志文件
                LogHelper.WriteLog(ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 获取单一结果
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
            catch(System.Exception ex)
            {
                //将错误信息写入日志文件
                LogHelper.WriteLog(ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 获取结果集（只读）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch(System.Exception ex)
            {
                //将错误信息写入日志文件
                LogHelper.WriteLog(ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                da.Fill(ds);
                return ds;
            }
            catch(System.Exception ex)
            {
                //将错误信息写入日志文件
                LogHelper.WriteLog(ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 获取多个数据集，读取时可以根据表的名称访问DataTable
        /// </summary>
        /// <param name="sql">使用HashTable类型的泛型集合封装对应的SQL语句和数据表名称</param>
        /// <returns>返回包含若干个数据表的数据集</returns>
        public static DataSet GetDataSet(Dictionary<string, string> sqlDic)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                foreach(var item in sqlDic)
                {
                    cmd.CommandText = item.Value;
                    da.Fill(ds, item.Key);//tableName
                }
                return ds;
            }
            catch(System.Exception ex)
            {
                //将错误信息写入日志文件
                LogHelper.WriteLog(ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        #region 执行事务
        /// <summary>
        /// 基于ADO.NET事务提交多条sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>返回是否执行成功</returns>
        public static bool UpdateByTransaction(List<string> sqlList)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.Transaction = conn.BeginTransaction();//开启事务
                foreach(var item in sqlList)
                {
                    cmd.CommandText = item;
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();//提交事务（同时自动清除事务）
                return true;
            }
            catch(System.Exception ex)
            {
                if(cmd.Transaction != null)
                {
                    cmd.Transaction.Rollback();//回滚事务
                }
                //将错误信息写入日志文件
                LogHelper.WriteLog(ex.Message);
                throw ex;
            }
            finally
            {
                if(cmd.Transaction != null)
                {
                    cmd.Transaction = null;
                }
                conn.Close();
            }
        }
        #endregion

        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 增删改操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Update(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(param);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch(System.Exception ex)
            {
                //将错误信息写入日志文件
                LogHelper.WriteLog(ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 获取单一结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(param);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch(System.Exception ex)
            {
                //将错误信息写入日志文件
                LogHelper.WriteLog(ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 获取结果集（只读）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(param);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch(System.Exception ex)
            {
                //将错误信息写入日志文件
                LogHelper.WriteLog(ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddRange(param);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                da.Fill(ds);
                return ds;
            }
            catch(System.Exception ex)
            {
                //将错误信息写入日志文件
                LogHelper.WriteLog(ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        ///// <summary>
        ///// 获取多个数据集，读取时可以根据表的名称访问DataTable
        ///// </summary>
        ///// <param name="sql">使用HashTable类型的泛型集合封装对应的SQL语句和数据表名称</param>
        ///// <returns>返回包含若干个数据表的数据集</returns>
        //public static DataSet GetDataSet(List<ArrayList> sqlNameSqlParamDic)
        //{
        //    SqlConnection conn = new SqlConnection(connString);
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = conn;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        conn.Open();
        //        foreach(var item in sqlNameSqlParamDic)
        //        {
        //            cmd.CommandText = (string)item[1];
        //            cmd.Parameters.AddRange((SqlParameter[])item[2]);
        //            da.Fill(ds, (string)item[0]);//tableName
        //        }
        //        return ds;
        //    }
        //    catch(System.Exception ex)
        //    {
        //        //将错误信息写入日志文件
        //        LogHelper.WriteLog(ex.Message);
        //        throw ex;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

        #region 执行事务
        /// <summary>
        /// 基于ADO.NET事务提交多条sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>返回是否执行成功</returns>
        public static bool UpdateByTransaction(Dictionary<string, SqlParameter[]> sqlParamList)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.Transaction = conn.BeginTransaction();//开启事务
                foreach(var item in sqlParamList)
                {
                    cmd.CommandText = item.Key;
                    cmd.Parameters.AddRange(item.Value);
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();//提交事务（同时自动清除事务）
                return true;
            }
            catch(System.Exception ex)
            {
                if(cmd.Transaction != null)
                {
                    cmd.Transaction.Rollback();//回滚事务
                }
                //将错误信息写入日志文件
                LogHelper.WriteLog(ex.Message);
                throw ex;
            }
            finally
            {
                if(cmd.Transaction != null)
                {
                    cmd.Transaction = null;
                }
                conn.Close();
            }
        }
        #endregion
        #endregion

        #region 调用存储过程

        /// <summary>
        /// 增删改操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>返回受影响的行数</returns>
        public static int UpdateByProcedure(string storeProcedureName, SqlParameter[] param = null)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;//告诉Commmand对象，当前的操作时执行存储过程
            cmd.CommandText = storeProcedureName;
            if(param != null)
            {
                cmd.Parameters.AddRange(param);
            }
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch(System.Exception ex)
            {
                //将错误信息写入日志文件
                LogHelper.WriteLog(ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 获取单一结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResultByProcedure(string storeProcedureName, SqlParameter[] param = null)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;//告诉Commmand对象，当前的操作时执行存储过程
            cmd.CommandText = storeProcedureName;
            if(param != null)
            {
                cmd.Parameters.AddRange(param);
            }
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch(System.Exception ex)
            {
                //将错误信息写入日志文件
                LogHelper.WriteLog(ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 获取结果集（只读）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetReaderByProcedure(string storeProcedureName, SqlParameter[] param = null)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;//告诉Commmand对象，当前的操作时执行存储过程
            cmd.CommandText = storeProcedureName;
            if(param != null)
            {
                cmd.Parameters.AddRange(param);
            }
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch(System.Exception ex)
            {
                //将错误信息写入日志文件
                LogHelper.WriteLog(ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDataSetByProcedure(string storeProcedureName, SqlParameter[] param = null)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;//告诉Commmand对象，当前的操作时执行存储过程
            cmd.CommandText = storeProcedureName;
            if(param != null)
            {
                cmd.Parameters.AddRange(param);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                da.Fill(ds);
                return ds;
            }
            catch(System.Exception ex)
            {
                //将错误信息写入日志文件
                LogHelper.WriteLog(ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region 获取数据库服务器时间、将错误信息写入日志
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
