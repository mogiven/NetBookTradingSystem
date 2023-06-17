using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace BookTradingSystem.DAL
{
    public static class DBHelper
    {
        /// <summary>
        /// 数据库位置. 本机为句点或是localhost. 远程服务器为IP地址或域名. 如果不是默认端口,则使用逗号分隔加在地址后面.
        /// </summary>
        public static string DataSource { get; set; } = "100.78.134.88";
        /// <summary>
        /// 要连接的目标数据库
        /// </summary>
        public static string DatabaseName { get; set; } = "BookTradingSystem";
        /// <summary>
        /// 连接数据库时使用的账号
        /// </summary>
        public static string DbUser { get; set; } = "sa";
        /// <summary>
        /// 连接数据库时使用的密码
        /// </summary>
        public static string DbPassword { get; set; } = "Abcd1234";

        /// <summary>
        /// 连接串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return $"Provider=sqloledb;Data Source={DataSource};Initial Catalog={DatabaseName};Persist Security Info=True;User ID={DbUser};Password={DbPassword}";
            }
        }

        private static OleDbConnection m_OleDbConnection = null;

        /// <summary>
        /// 打开数据库.
        /// </summary>
        public static void Open()
        {
            if (m_OleDbConnection == null) m_OleDbConnection = new OleDbConnection(ConnectionString);
            if (m_OleDbConnection.State == System.Data.ConnectionState.Closed) m_OleDbConnection.Open();
        }

        /// <summary>
        /// 关闭数据库.
        /// </summary>
        public static void Close()
        {
            if (m_OleDbConnection == null) return;
            if (m_OleDbConnection.State != System.Data.ConnectionState.Closed) m_OleDbConnection.Close();
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            Open();
            OleDbCommand oleDbCommand = new OleDbCommand(sql, m_OleDbConnection);
            return oleDbCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// 执行查询并返回结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static OleDbDataReader ExecuteReader(string sql)
        {
            Open();
            OleDbCommand oleDbCommand = new OleDbCommand(sql, m_OleDbConnection);
            return oleDbCommand.ExecuteReader();
        }
    }
}