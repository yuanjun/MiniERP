using System;
using System.Configuration;
using System.Data;
//using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Lib.DAL
{
    public class DBHelper
    {
        #region 外部调用函数

        private static readonly string connectionString = Lib.Common.Config.MBDBConnStr;
        private static readonly int CommandTimeout = 0;

        /// <summary>
        /// 获得连接
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection getConn()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }

        /// <summary>
        /// 执行查询命令,返回DataReader对象
        /// </summary>      
        /// <param name="SqlText">sql命令</param>
        /// <param name="SqlParms">sql命令参数</param>
        /// <returns></returns>
        public static MySqlDataReader ExecuteReader(string SqlText)
        {
            return ExecuteReader(connectionString, CommandType.Text, CommandTimeout, SqlText, null);
        }

        /// <summary>
        /// 执行查询命令,返回DataReader对象
        /// </summary>
        /// <param name="SqlText">sql命令</param>
        /// <param name="SqlParms">sql命令参数</param>
        /// <returns></returns>
        public static MySqlDataReader ExecuteReader(string SqlText, params MySqlParameter[] SqlParms)
        {
            return ExecuteReader(connectionString, CommandType.Text, CommandTimeout, SqlText, SqlParms);
        }

        /// <summary>
        /// 执行查询命令,返回DataTable
        /// </summary>      
        /// <param name="SqlText">sql命令</param>
        /// <returns></returns>
        public static DataTable ExecuteQueryDT(string SqlText)
        {
            return ExecuteQueryDT(connectionString, CommandType.Text, CommandTimeout, SqlText, null);
        }

        /// <summary>
        /// 执行查询命令,返回DataTable
        /// </summary>      
        /// <param name="SqlText">sql命令</param>
        /// <param name="SqlParms">sql命令参数</param>
        /// <returns></returns>
        public static DataTable ExecuteQueryDT(string SqlText, params MySqlParameter[] SqlParms)
        {
            return ExecuteQueryDT(connectionString, CommandType.Text, CommandTimeout, SqlText, SqlParms);
        }

        /// <summary>
        /// 执行查询命令,返回DataSet
        /// </summary>      
        /// <param name="SqlText">sql命令</param>
        /// <returns></returns>
        public static DataSet ExecuteQueryDS(string SqlText)
        {
            return ExecuteQueryDS(connectionString, CommandType.Text, CommandTimeout, SqlText, null);
        }

        /// <summary>
        /// 执行查询命令,返回DataSet
        /// </summary>
        /// <param name="SqlText">sql命令</param>
        /// <param name="SqlParms">sql命令参数</param>
        /// <returns></returns>
        public static DataSet ExecuteQueryDS(string SqlText, params MySqlParameter[] SqlParms)
        {
            return ExecuteQueryDS(connectionString, CommandType.Text, CommandTimeout, SqlText, SqlParms);
        }

        /// <summary>
        /// 执行非查询命令
        /// </summary>      
        /// <param name="SqlText">sql命令</param>
        /// <returns>返回影响的行数</returns>
        public static int ExecuteNonQuery(string SqlText)
        {
            return ExecuteNonQuery(connectionString, CommandType.Text, CommandTimeout, SqlText, null);
        }

        /// <summary>
        /// 执行非查询命令
        /// </summary>      
        /// <param name="SqlText">sql命令</param>
        /// <param name="SqlParms">sql命令参数</param>
        /// <returns>返回影响的行数</returns>
        public static int ExecuteNonQuery(string SqlText, params MySqlParameter[] SqlParms)
        {
            return ExecuteNonQuery(connectionString, CommandType.Text, CommandTimeout, SqlText, SqlParms);
        }

        /// <summary>
        /// 通过事务执行非查询命令
        /// </summary>
        /// <param name="Trans">事务对象</param>  
        /// <param name="SqlText">sql命令</param>
        /// <returns>返回影响的行数</returns>
        public static int ExecuteNonQuery(MySqlTransaction Trans, string SqlText)
        {
            return ExecuteNonQuery(Trans, CommandType.Text, CommandTimeout, SqlText, null);
        }

        /// <summary>
        /// 通过事务执行非查询命令
        /// </summary>
        /// <param name="Trans">事务对象</param>
        /// <param name="SqlText">sql命令</param>
        /// <param name="SqlParms">sql命令参数</param>
        /// <returns>返回影响的行数</returns>
        public static int ExecuteNonQuery(MySqlTransaction Trans, string SqlText, params MySqlParameter[] SqlParms)
        {
            return ExecuteNonQuery(Trans, CommandType.Text, CommandTimeout, SqlText, SqlParms);
        }

        /// <summary>
        /// 通过事务执行多条非查询语句
        /// </summary>
        /// <param name="sqlList">sql语句链表</param>
        /// <returns>受影响行</returns>
        public static int ExecuteNonQuery(LinkedList<string> sqlList) {
            MySqlTransaction sqlTrans = null;

            using (MySqlConnection sqlConn = new MySqlConnection(connectionString))
            {
                sqlConn.Open();
                sqlTrans = sqlConn.BeginTransaction();
                MySqlCommand sqlComm = new MySqlCommand("", sqlConn, sqlTrans);
                sqlComm.CommandTimeout = 120;
                sqlComm.CommandType = CommandType.Text;

                try
                {
                    int num = 0;
                    foreach (string sqlText in sqlList)
                    {
                        sqlComm.CommandText = sqlText;
                        num += sqlComm.ExecuteNonQuery();
                    }

                    //提交事务
                    sqlTrans.Commit();

                    return num;
                }
                catch (Exception ex)
                {
                    sqlTrans.Rollback();
                    throw ex;
                }
                finally
                {
                    if (sqlConn.State != System.Data.ConnectionState.Closed)
                    {
                        sqlConn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 事务执行多条SQL语句
        /// </summary>
        /// <param name="sqlList"></param>
        /// <param name="sqlParasList"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(List<string> sqlList, List<MySqlParameter[]> sqlParasList) {
            MySqlTransaction sqlTrans = null;

            using (MySqlConnection sqlConn = new MySqlConnection(connectionString))
            {
                sqlConn.Open();
                sqlTrans = sqlConn.BeginTransaction();
                MySqlCommand sqlComm = new MySqlCommand("", sqlConn, sqlTrans);
                sqlComm.CommandTimeout = 120;
                sqlComm.CommandType = CommandType.Text;

                try
                {
                    int num = 0;
                    for (int i = 0; i < sqlList.Count; i++) {
                        string sqlText = sqlList[i];
                        MySqlParameter[] sqlParams = sqlParasList[i];

                        PrepareCommand(sqlComm, sqlConn, CommandType.Text, 120, sqlTrans, sqlText, sqlParams);
                        num += sqlComm.ExecuteNonQuery();
                    }

                    //提交事务
                    sqlTrans.Commit();

                    return num;
                }
                catch (Exception ex)
                {
                    sqlTrans.Rollback();
                    throw ex;
                }
                finally
                {
                    if (sqlConn.State != System.Data.ConnectionState.Closed)
                    {
                        sqlConn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询命令
        /// </summary>
        /// <param name="SqlText">sql命令</param>
        /// <returns>返回结果集第一行第一列的数据对象</returns>
        public static object ExecuteScalar(string SqlText)
        {
            return ExecuteScalar(connectionString, CommandType.Text, CommandTimeout, SqlText, null);
        }

        /// <summary>
        /// 执行查询命令
        /// </summary>
        /// <param name="SqlText">sql命令</param>
        /// <param name="SqlParms">sql命令参数</param>
        /// <returns>返回结果集第一行第一列的数据对象</returns>
        public static object ExecuteScalar(string SqlText, params MySqlParameter[] SqlParms)
        {
            return ExecuteScalar(connectionString, CommandType.Text, CommandTimeout, SqlText, SqlParms);
        }

        #endregion

        #region 私有方法

        #region PrepareCommand

        /// <summary>
        /// 为Command进行处理
        /// </summary>
        /// <param name="Cmd">Command对象</param>
        /// <param name="Conn">数据库连接对象</param>
        /// <param name="Database">默认数据库名</param>
        /// <param name="CmdTimeout">命令执行超时时间</param>
        /// <param name="Trans">事务对象</param>
        /// <param name="CmdType">命令类型</param>
        /// <param name="SqlText">数据库命令</param>
        /// <param name="SqlParms">数据库命令参数</param>
        private static void PrepareCommand(MySqlCommand Cmd, MySqlConnection Conn, CommandType CmdType, int CmdTimeout, MySqlTransaction Trans, string SqlText, MySqlParameter[] SqlParms)
        {
            if (Conn.State != ConnectionState.Open)
            {
                Conn.Open();
            }
            Cmd.Connection = Conn;
            Cmd.Parameters.Clear();
            Cmd.CommandType = CmdType;
            if (CmdTimeout > 0)
            {
                Cmd.CommandTimeout = CmdTimeout;
            }
            if (Trans != null)
            {
                Cmd.Transaction = Trans;
            }
            Cmd.CommandText = SqlText;
            if (SqlParms != null)
            {
                foreach (MySqlParameter param in SqlParms)
                {
                    if (param.Value == null)
                    {
                        param.Value = DBNull.Value;
                    }
                    Cmd.Parameters.Add(param);
                }
            }
        }

        #endregion

        #region ExecuteReader

        /// <summary>
        /// 执行查询命令,返回DataReader对象
        /// </summary>
        /// <param name="ConnectionString">连接字符串</param>
        /// <param name="Database">默认数据库名</param>
        /// <param name="CommandType">命令类型</param>
        /// <param name="CommandTimeout">命令超时时间</param>
        /// <param name="SqlText">sql命令</param>
        /// <param name="SqlParms">sql命令参数</param>
        /// <returns></returns>
        private static MySqlDataReader ExecuteReader(string ConnectionString, CommandType CommandType, int CommandTimeout, string SqlText, params MySqlParameter[] SqlParms)
        {
            MySqlCommand dc = new MySqlCommand();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                PrepareCommand(dc, conn, CommandType, CommandTimeout, null, SqlText, SqlParms);
                //执行命令
                MySqlDataReader dr = dc.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch (Exception ex)
            {
                conn.Close();
                StringBuilder sb = new StringBuilder();
                sb.Append(ex.ToString());
                //sb.Append("\r\n");
                //sb.Append("ConnectionString: ");
                //sb.Append(ConnectionString);
                sb.Append("\r\n");
                sb.Append("Database: ");
                sb.Append(conn.Database);
                sb.Append("\r\n");
                sb.Append("CommandType: ");
                sb.Append(CommandType.ToString());
                sb.Append("\r\n");
                sb.Append("CommandTimeout: ");
                sb.Append(dc.CommandTimeout.ToString());
                sb.Append("\r\n");
                sb.Append("CommandText: ");
                sb.Append(dc.CommandText);
                sb.Append("\r\n");
                if (SqlParms != null && SqlParms.Length > 0)
                {
                    sb.Append("MySqlParameters: ");
                    sb.Append("\r\n");
                    foreach (MySqlParameter parm in SqlParms)
                    {
                        sb.Append(parm.ParameterName);
                        sb.Append("=");
                        sb.Append(Convert.ToString(parm.Value));
                        sb.Append("\r\n");
                    }
                    sb.Append("\r\n");
                }
                //throw new DBException("系统提示错误："+ex.Message+sb.ToString());
                throw new Exception("系统提示错误：" + ex.Message);
            }
        }

        #endregion

        #region ExecuteQuery

        /// <summary>
        /// 执行查询命令,返回DataSet
        /// </summary>
        /// <param name="ConnectionString">连接字符串</param>
        /// <param name="Database">默认数据库名</param>
        /// <param name="CommandType">命令类型</param>
        /// <param name="CommandTimeout">命令超时时间</param>
        /// <param name="SqlText">sql命令</param>
        /// <param name="SqlParms">sql命令参数</param>
        /// <returns></returns>
        private static DataSet ExecuteQueryDS(string ConnectionString, CommandType CommandType, int CommandTimeout, string SqlText, params MySqlParameter[] SqlParms)
        {
            MySqlCommand dc = new MySqlCommand();
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                try
                {
                    PrepareCommand(dc, conn, CommandType, CommandTimeout, null, SqlText, SqlParms);
                    //执行命令
                    MySqlDataAdapter da = new MySqlDataAdapter(dc);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(ex.ToString());
                    //sb.Append("\r\n");
                    //sb.Append("ConnectionString: ");
                    //sb.Append(ConnectionString);
                    sb.Append("\r\n");
                    sb.Append("Database: ");
                    sb.Append(conn.Database);
                    sb.Append("\r\n");
                    sb.Append("CommandType: ");
                    sb.Append(CommandType.ToString());
                    sb.Append("\r\n");
                    sb.Append("CommandTimeout: ");
                    sb.Append(dc.CommandTimeout.ToString());
                    sb.Append("\r\n");
                    sb.Append("CommandText: ");
                    sb.Append(dc.CommandText);
                    sb.Append("\r\n");
                    if (SqlParms != null && SqlParms.Length > 0)
                    {
                        sb.Append("MySqlParameters: ");
                        sb.Append("\r\n");
                        foreach (MySqlParameter parm in SqlParms)
                        {
                            sb.Append(parm.ParameterName);
                            sb.Append("=");
                            sb.Append(Convert.ToString(parm.Value));
                            sb.Append("\r\n");
                        }
                        sb.Append("\r\n");
                    }
                    throw new Exception(sb.ToString());
                }
            }
        }

        /// <summary>
        /// 执行查询命令,返回DataTable
        /// </summary>
        /// <param name="ConnectionString">连接字符串</param>
        /// <param name="Database">默认数据库名</param>
        /// <param name="CommandType">命令类型</param>
        /// <param name="CommandTimeout">命令超时时间</param>
        /// <param name="SqlText">sql命令</param>
        /// <param name="SqlParms">sql命令参数</param>
        /// <returns></returns>
        private static DataTable ExecuteQueryDT(string ConnectionString, CommandType CommandType, int CommandTimeout, string SqlText, params MySqlParameter[] SqlParms)
        {
            MySqlCommand dc = new MySqlCommand();
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                try
                {
                    PrepareCommand(dc, conn, CommandType, CommandTimeout, null, SqlText, SqlParms);
                    //执行命令
                    MySqlDataAdapter da = new MySqlDataAdapter(dc);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(ex.ToString());
                    //sb.Append("\r\n");
                    //sb.Append("ConnectionString: ");
                    //sb.Append(ConnectionString);
                    sb.Append("\r\n");
                    sb.Append("Database: ");
                    sb.Append(conn.Database);
                    sb.Append("\r\n");
                    sb.Append("CommandType: ");
                    sb.Append(CommandType.ToString());
                    sb.Append("\r\n");
                    sb.Append("CommandTimeout: ");
                    sb.Append(dc.CommandTimeout.ToString());
                    sb.Append("\r\n");
                    sb.Append("CommandText: ");
                    sb.Append(dc.CommandText);
                    sb.Append("\r\n");
                    if (SqlParms != null && SqlParms.Length > 0)
                    {
                        sb.Append("MySqlParameters: ");
                        sb.Append("\r\n");
                        foreach (MySqlParameter parm in SqlParms)
                        {
                            sb.Append(parm.ParameterName);
                            sb.Append("=");
                            sb.Append(Convert.ToString(parm.Value));
                            sb.Append("\r\n");
                        }
                        sb.Append("\r\n");
                    }
                    throw new Exception(sb.ToString());
                }
            }
        }

        #endregion

        #region ExecuteNonQuery

        /// <summary>
        /// 执行非查询命令
        /// </summary>
        /// <param name="ConnectionString">连接字符串</param>
        /// <param name="Database">默认数据库名</param>
        /// <param name="CommandType">命令类型</param>
        /// <param name="CommandTimeout">命令超时时间</param>
        /// <param name="SqlText">sql命令</param>
        /// <param name="SqlParms">sql命令参数</param>
        /// <returns>返回影响的行数</returns>
        private static int ExecuteNonQuery(string ConnectionString, CommandType CommandType, int CommandTimeout, string SqlText, params MySqlParameter[] SqlParms)
        {
            MySqlCommand dc = new MySqlCommand();
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                try
                {
                    PrepareCommand(dc, conn, CommandType, CommandTimeout, null, SqlText, SqlParms);
                    //执行命令
                    int result = dc.ExecuteNonQuery();
                    return result;
                }
                catch (Exception ex)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.Append(ex.ToString());
                    //sb.Append("\r\n");
                    //sb.Append("ConnectionString: ");
                    //sb.Append(ConnectionString);
                    sb.Append("\r\n");
                    sb.Append("Database: ");
                    sb.Append(conn.Database);
                    sb.Append("\r\n");
                    sb.Append("CommandType: ");
                    sb.Append(CommandType.ToString());
                    sb.Append("\r\n");
                    sb.Append("CommandTimeout: ");
                    sb.Append(dc.CommandTimeout.ToString());
                    sb.Append("\r\n");
                    sb.Append("CommandText: ");
                    sb.Append(dc.CommandText);
                    sb.Append("\r\n");
                    if (SqlParms != null && SqlParms.Length > 0)
                    {
                        sb.Append("MyMySqlParameters: ");
                        sb.Append("\r\n");
                        foreach (MySqlParameter parm in SqlParms)
                        {
                            sb.Append(parm.ParameterName);
                            sb.Append("=");
                            sb.Append(Convert.ToString(parm.Value));
                            sb.Append("\r\n");
                        }
                        sb.Append("\r\n");
                    }
                    //throw new DBException(sb.ToString());
                    throw new Exception("系统提示错误：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 通过事务执行非查询命令
        /// </summary>
        /// <param name="Trans">事务对象</param>
        /// <param name="CommandType">命令类型</param>
        /// <param name="CommandTimeout">命令超时时间</param>
        /// <param name="SqlText">sql命令</param>
        /// <param name="SqlParms">sql命令参数</param>
        /// <returns>返回影响的行数</returns>
        private static int ExecuteNonQuery(MySqlTransaction Trans, CommandType CommandType, int CommandTimeout, string SqlText, params MySqlParameter[] SqlParms)
        {
            MySqlCommand dc = new MySqlCommand();
            try
            {
                PrepareCommand(dc, Trans.Connection, CommandType, CommandTimeout, Trans, SqlText, SqlParms);
                //执行命令
                int result = dc.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ex.ToString());
                //sb.Append("\r\n");
                //sb.Append("ConnectionString: ");
                //sb.Append(Trans.Connection.ConnectionString);
                sb.Append("\r\n");
                sb.Append("CommandType: ");
                sb.Append(CommandType.ToString());
                sb.Append("\r\n");
                sb.Append("CommandTimeout: ");
                sb.Append(dc.CommandTimeout.ToString());
                sb.Append("\r\n");
                sb.Append("CommandText: ");
                sb.Append(dc.CommandText);
                sb.Append("\r\n");
                if (SqlParms != null && SqlParms.Length > 0)
                {
                    sb.Append("MySqlParameters: ");
                    sb.Append("\r\n");
                    foreach (MySqlParameter parm in SqlParms)
                    {
                        sb.Append(parm.ParameterName);
                        sb.Append("=");
                        sb.Append(Convert.ToString(parm.Value));
                        sb.Append("\r\n");
                    }
                    sb.Append("\r\n");
                }
                //throw new DBException(sb.ToString());
                throw new Exception("系统提示错误：" + ex.Message);
            }
        }
        #endregion

        #region ExecuteScalar

        /// <summary>
        /// 执行查询命令
        /// </summary>
        /// <param name="ConnectionString">连接字符串</param>
        /// <param name="Database">默认数据库名</param>
        /// <param name="CommandType">命令类型</param>
        /// <param name="CommandTimeout">命令超时时间</param>
        /// <param name="SqlText">sql命令</param>
        /// <param name="SqlParms">sql命令参数</param>
        /// <returns>返回结果集第一行第一列的数据对象</returns>
        private static object ExecuteScalar(string ConnectionString, CommandType CommandType, int CommandTimeout, string SqlText, params MySqlParameter[] SqlParms)
        {
            MySqlCommand dc = new MySqlCommand();
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                try
                {
                    PrepareCommand(dc, conn, CommandType, CommandTimeout, null, SqlText, SqlParms);
                    //执行命令
                    object result = dc.ExecuteScalar();
                    return result;
                }
                catch (Exception ex)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(ex.ToString());
                    //sb.Append("\r\n");
                    //sb.Append("ConnectionString: ");
                    //sb.Append(ConnectionString);
                    sb.Append("\r\n");
                    sb.Append("Database: ");
                    sb.Append(conn.Database);
                    sb.Append("\r\n");
                    sb.Append("CommandType: ");
                    sb.Append(CommandType.ToString());
                    sb.Append("\r\n");
                    sb.Append("CommandTimeout: ");
                    sb.Append(dc.CommandTimeout.ToString());
                    sb.Append("\r\n");
                    sb.Append("CommandText: ");
                    sb.Append(dc.CommandText);
                    sb.Append("\r\n");
                    if (SqlParms != null && SqlParms.Length > 0)
                    {
                        sb.Append("MySqlParameters: ");
                        sb.Append("\r\n");
                        foreach (MySqlParameter parm in SqlParms)
                        {
                            sb.Append(parm.ParameterName);
                            sb.Append("=");
                            sb.Append(Convert.ToString(parm.Value));
                            sb.Append("\r\n");
                        }
                        sb.Append("\r\n");
                    }
                    throw new Exception(sb.ToString());
                }
            }
        }

        #endregion

        #endregion

    }
}
