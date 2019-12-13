using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.IO;
using Oracle.ManagedDataAccess.Client;
//using System.Data.OracleClient;    System.Data.OracleClient类已经不推荐使用

namespace Rxsoft.Util.DataBase
{
    /// <summary>
    /// Oracle数据库操作类
    /// </summary>
    public static class OracleHelper
    {
        /// <summary>  
        /// 执行数据库非查询操作,返回受影响的行数  
        /// </summary>  
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">命令的类型</param>
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="cmdParms">命令参数集合</param>  
        /// <returns>当前操作影响的数据行数</returns>  
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params OracleParameter[] cmdParms)
        {
            OracleCommand cmd = new OracleCommand();
            
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>  
        /// 执行数据库事务非查询操作,返回受影响的行数  
        /// </summary>  
        /// <param name="transaction">数据库事务对象</param>  
        /// <param name="cmdType">Command类型</param>  
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="cmdParms">命令参数集合</param>  
        /// <returns>当前事务操作影响的数据行数</returns>  
        public static int ExecuteNonQuery(OracleTransaction trans, CommandType cmdType, string cmdText, params OracleParameter[] cmdParms)
        {
            OracleCommand cmd = new OracleCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>  
        /// 执行数据库非查询操作,返回受影响的行数  
        /// </summary>  
        /// <param name="connection">Oracle数据库连接对象</param>  
        /// <param name="cmdType">Command类型</param>  
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="cmdParms">命令参数集合</param>  
        /// <returns>当前操作影响的数据行数</returns>  
        public static int ExecuteNonQuery(OracleConnection connection, CommandType cmdType, string cmdText, params OracleParameter[] cmdParms)
        {
            if (connection == null)
                throw new ArgumentNullException("当前数据库连接不存在");
            OracleCommand cmd = new OracleCommand();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, cmdParms);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>  
        /// 执行数据库查询操作,返回OracleDataReader类型的内存结果集  
        /// </summary>  
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">命令的类型</param>
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="cmdParms">命令参数集合</param>  
        /// <returns>当前查询操作返回的OracleDataReader类型的内存结果集</returns>  
        public static OracleDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params OracleParameter[] cmdParms)
        {
            OracleCommand cmd = new OracleCommand();
            OracleConnection conn = new OracleConnection(connectionString);
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                OracleDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return reader;
            }
            catch
            {
                cmd.Dispose();
                conn.Close();
                throw;
            }
        }

        /// <summary>  
        /// 执行数据库查询操作,返回DataSet类型的结果集  
        /// </summary>  
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">命令的类型</param>
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="cmdParms">命令参数集合</param>  
        /// <returns>当前查询操作返回的DataSet类型的结果集</returns>  
        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, params OracleParameter[] cmdParms)
        {
            OracleCommand cmd = new OracleCommand();
            OracleConnection conn = new OracleConnection(connectionString);
            DataSet ds = null;
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = cmd;
                ds = new DataSet();
                adapter.Fill(ds);
                cmd.Parameters.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }

            return ds;
        }

        /// <summary>  
        /// 执行数据库查询操作,返回DataTable类型的结果集  
        /// </summary>  
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">命令的类型</param>
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="cmdParms">命令参数集合</param>  
        /// <returns>当前查询操作返回的DataTable类型的结果集</returns>  
        public static DataTable ExecuteDataTable(string connectionString, CommandType cmdType, string cmdText, params OracleParameter[] cmdParms)
        {
            OracleCommand cmd = new OracleCommand();
            OracleConnection conn = new OracleConnection(connectionString);
            DataTable dt = null;

            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = cmd;
                dt = new DataTable();
                adapter.Fill(dt);
                cmd.Parameters.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }

            return dt;
        }

        /// <summary>  
        /// 执行数据库查询操作,返回结果集中位于第一行第一列的Object类型的值  
        /// </summary>  
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">命令的类型</param>
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="cmdParms">命令参数集合</param>  
        /// <returns>当前查询操作返回的结果集中位于第一行第一列的Object类型的值</returns>  
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params OracleParameter[] cmdParms)
        {
            OracleCommand cmd = new OracleCommand();
            OracleConnection conn = new OracleConnection(connectionString);
            object result = null;
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                result = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }

            return result;
        }

        /// <summary>  
        /// 执行数据库事务查询操作,返回结果集中位于第一行第一列的Object类型的值  
        /// </summary>  
        /// <param name="trans">一个已存在的数据库事务对象</param>  
        /// <param name="commandType">命令类型</param>  
        /// <param name="commandText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="cmdParms">命令参数集合</param>  
        /// <returns>当前事务查询操作返回的结果集中位于第一行第一列的Object类型的值</returns>  
        public static object ExecuteScalar(OracleTransaction trans, CommandType cmdType, string cmdText, params OracleParameter[] cmdParms)
        {
            if (trans == null)
                throw new ArgumentNullException("当前数据库事务不存在");
            OracleConnection conn = trans.Connection;
            if (conn == null)
                throw new ArgumentException("当前事务所在的数据库连接不存在");

            OracleCommand cmd = new OracleCommand();
            object result = null;

            try
            {
                PrepareCommand(cmd, conn, trans, cmdType, cmdText, cmdParms);
                result = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {
                trans.Dispose();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }

            return result;
        }

        /// <summary>  
        /// 执行数据库查询操作,返回结果集中位于第一行第一列的Object类型的值  
        /// </summary>  
        /// <param name="conn">数据库连接对象</param>  
        /// <param name="cmdType">Command类型</param>  
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="cmdParms">命令参数集合</param>  
        /// <returns>当前查询操作返回的结果集中位于第一行第一列的Object类型的值</returns>  
        public static object ExecuteScalar(OracleConnection conn, CommandType cmdType, string cmdText, params OracleParameter[] cmdParms)
        {
            if (conn == null) throw new ArgumentException("当前数据库连接不存在");
            OracleCommand cmd = new OracleCommand();
            object result = null;

            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                result = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }

            return result;
        }
        /**
          * 批量插入数据
          * @tableName 表名称
          * @columnRowData 键-值存储的批量数据：键是列名称，值是对应的数据集合
          * @conStr 连接字符串
          * @len 每次批处理数据的大小
          */
          public static int BatchInsert(string tableName, Dictionary<string, object> columnRowData, string conStr, int len)
          {
              if (string.IsNullOrEmpty(tableName))
             {
                 throw new ArgumentException("必须指定批量插入的表名称", "tableName");
             }
 
             if (columnRowData == null || columnRowData.Count < 1)
             {
                 throw new ArgumentException("必须指定批量插入的字段名称", "columnRowData");
             }
 
             int iResult = 0;
             int count = columnRowData.Count;
             string[] dbColumns = new string[count];
             columnRowData.Keys.CopyTo(dbColumns,0);
             StringBuilder sbCmdText = new StringBuilder();
             if (columnRowData.Count > 0)
             {
                 //准备插入的SQL
                 sbCmdText.AppendFormat("INSERT INTO {0}(", tableName);
                 sbCmdText.Append(string.Join(",", dbColumns));
                 sbCmdText.Append(") VALUES (");
                 sbCmdText.Append(":" + string.Join(",:", dbColumns));
                 sbCmdText.Append(")");
 
                 using (OracleConnection conn = new OracleConnection(conStr))
                 {
                     using (OracleCommand cmd = conn.CreateCommand())
                     {
                         //绑定批处理的行数
                         cmd.ArrayBindCount = len;
                         cmd.BindByName = true;
                         cmd.CommandType = CommandType.Text;
                         cmd.CommandText = sbCmdText.ToString();
                         cmd.CommandTimeout = 600;//10分钟
 
                         //创建参数
                         OracleParameter oraParam;
                         List<IDbDataParameter> cacher = new List<IDbDataParameter>();
                         OracleDbType dbType = OracleDbType.Varchar2;
                         foreach (string colName in dbColumns)
                         {
                             dbType = GetOracleDbType(columnRowData[colName]);
                             oraParam = new OracleParameter(colName, dbType);
                             oraParam.Direction = ParameterDirection.Input;
                             oraParam.OracleDbTypeEx = dbType;
 
                             oraParam.Value = columnRowData[colName];
                             cmd.Parameters.Add(oraParam);
                         }
                         //打开连接
                         conn.Open();
 
                         /*执行批处理*/
                         var trans = conn.BeginTransaction();
                         try
                         {
                             cmd.Transaction = trans;
                             iResult = cmd.ExecuteNonQuery();
                             trans.Commit();
                         }
                         catch (Exception ex)
                         {
                             trans.Rollback();
                             throw ex;
                         }
                         finally
                         {
                             if (conn != null) conn.Close();
                         }
                    }
                 }
             }
             return iResult;
         }
 
         /**
          * 根据数据类型获取OracleDbType
          */
         private static OracleDbType GetOracleDbType(object value)
         {
             OracleDbType dataType = OracleDbType.Varchar2;
             if (value is string[])
             {
                 dataType = OracleDbType.Varchar2;
             }
             else if (value is DateTime[])
             {
                 dataType = OracleDbType.TimeStamp;
             }
             else if (value is int[] || value is short[])
             {
                 dataType = OracleDbType.Int32;
             }
             else if (value is long[])
             {
                 dataType = OracleDbType.Int64;
             }
             else if (value is decimal[] || value is double[] || value is float[])
             {
                 dataType = OracleDbType.Decimal;
             }
             else if (value is Guid[])
             {
                 dataType = OracleDbType.Varchar2;
             }
             else if (value is bool[] || value is Boolean[])
             {
                 dataType = OracleDbType.Byte;
             }
             else if (value is byte[])
             {
                 dataType = OracleDbType.Blob;
             }
             else if (value is char[])
             {
                 dataType = OracleDbType.Char;
             }
             return dataType;
         }



        /// <summary>  
        /// 执行数据库命令前的准备工作  
        /// </summary>  
        /// <param name="cmd">Command对象</param>  
        /// <param name="conn">数据库连接对象</param>  
        /// <param name="trans">事务对象</param>  
        /// <param name="cmdType">Command类型</param>  
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="cmdParms">命令参数集合</param>  
        private static void PrepareCommand(OracleCommand cmd, OracleConnection conn, OracleTransaction trans, CommandType cmdType, string cmdText, OracleParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (OracleParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        /// <summary>  
        /// 将.NET日期时间类型转化为Oracle兼容的日期时间格式字符串  
        /// </summary>  
        /// <param name="date">.NET日期时间类型对象</param>  
        /// <returns>Oracle兼容的日期时间格式字符串（如该字符串：TO_DATE('2007-12-1','YYYY-MM-DD')）</returns>  
        public static string GetOracleDateFormat(DateTime date)
        {
            return "TO_DATE('" + date.ToString("yyyy-M-dd") + "','YYYY-MM-DD')";
        }

        /// <summary>  
        /// 将.NET日期时间类型转化为Oracle兼容的日期格式字符串  
        /// </summary>  
        /// <param name="date">.NET日期时间类型对象</param>  
        /// <param name="format">Oracle日期时间类型格式化限定符</param>  
        /// <returns>Oracle兼容的日期时间格式字符串（如该字符串：TO_DATE('2007-12-1','YYYY-MM-DD')）</returns>  
        public static string GetOracleDateFormat(DateTime date, string format)
        {
            if (format == null || format.Trim() == "") format = "YYYY-MM-DD";
            return "TO_DATE('" + date.ToString("yyyy-M-dd") + "','" + format + "')";
        }

        /// <summary>  
        /// 将指定的关键字处理为模糊查询时的合法参数值  
        /// </summary>  
        /// <param name="source">待处理的查询关键字</param>  
        /// <returns>过滤后的查询关键字</returns>  
        public static string HandleLikeKey(string source)
        {
            if (source == null || source.Trim() == "") return null;

            source = source.Replace("[", "[]]");
            source = source.Replace("_", "[_]");
            source = source.Replace("%", "[%]");

            return ("%" + source + "%");
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="connection">SqlServer数据库连接对象</param>  
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader对象</returns>
        public static OracleDataReader RunStoredProcedure(OracleConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            OracleDataReader returnReader = null;
            connection.Open();
            OracleCommand command = BuildSqlCommand(connection, storedProcName, parameters);
            returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return returnReader;
        }

        /// <summary>
        /// 构建SqlCommand对象
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private static OracleCommand BuildSqlCommand(OracleConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            OracleCommand command = new OracleCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (OracleParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }
    }
}