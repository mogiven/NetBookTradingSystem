using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BookTradingSystem.Model;
using PasswordAssembly;

namespace BookTradingSystem.DAL
{
    public static class DalUser
    {
        private static readonly Password password = new Password();
        /// <summary>
        /// 插入一条新数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int Insert(User data)
        {
            if (password.examine(data.LoginPassword)) {
                string sql = $"INSERT INTO [dbo].[User] ([LoginAccount] ,[LoginPassword] ,[UserName] ,[IdentityRole] ,[Email] ,[Phone] ,[RegDate]) VALUES " +
                $"('{data.LoginAccount}','{data.LoginPassword}','{data.UserName}',{data.IdentityRole},'{data.Email}','{data.Phone}','{data.RegDate}')";
                return DBHelper.ExecuteNonQuery(sql);
            }

            return 0;
        }

        /// <summary>
        /// 按指定 id 更新一条数据
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Update(User data)
        {
            string sql = $"UPDATE [dbo].[User] " +
                $"SET [LoginAccount] = '{data.LoginAccount}'" +
                $",[LoginPassword] = '{data.LoginPassword}'" +
                $",[UserName] = '{data.UserName}'" +
                $",[IdentityRole] = {data.IdentityRole}" +
                $",[Email] = '{data.Email}'" +
                $",[Phone] = '{data.Phone}'" +
                $",[RegDate] = '{data.RegDate}'" +
                $" WHERE [UserId]={data.UserId}";
            return DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 删除指定 id 的特定数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Delete(int id)
        {
            string sql = $"DELETE FROM [dbo].[User] WHERE [UserId]={id}";
            return DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 获取指定 id 的特定数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static User GetData(int id)
        {
            string sql = $"SELECT * FROM [dbo].[User] WHERE [UserId]={id}";
            var data_reader = DBHelper.ExecuteReader(sql);
            if (data_reader.Read())
            {
                User data = new User();
                data.UserId = data_reader.GetInt32(data_reader.GetOrdinal("UserId"));
                data.LoginAccount = data_reader.GetString(data_reader.GetOrdinal("LoginAccount"));
                data.LoginPassword = data_reader.GetString(data_reader.GetOrdinal("LoginPassword"));
                data.UserName = data_reader.GetString(data_reader.GetOrdinal("UserName"));
                data.IdentityRole = data_reader.GetInt32(data_reader.GetOrdinal("IdentityRole"));
                data.Email = data_reader.GetString(data_reader.GetOrdinal("Email"));
                data.Phone = data_reader.GetString(data_reader.GetOrdinal("Phone"));
                data.RegDate  = data_reader.GetDateTime(data_reader.GetOrdinal("RegDate"));
                return data;
            }
            else
                return null;
        }

        /// <summary>
        /// 获取表中所有数据
        /// </summary>
        /// <returns></returns>
        public static List<User> GetDataList()
        {
            string sql = $"SELECT * FROM [dbo].[User]";
            var data_reader = DBHelper.ExecuteReader(sql);
            List<User> data_list = new List<User>();
            while (data_reader.Read())
            {
                User data = new User();
                data.UserId = data_reader.GetInt32(data_reader.GetOrdinal("UserId"));
                data.LoginAccount = data_reader.GetString(data_reader.GetOrdinal("LoginAccount"));
                data.LoginPassword = data_reader.GetString(data_reader.GetOrdinal("LoginPassword"));
                data.UserName = data_reader.GetString(data_reader.GetOrdinal("UserName"));
                data.IdentityRole = data_reader.GetInt32(data_reader.GetOrdinal("IdentityRole"));
                data.Email = data_reader.GetString(data_reader.GetOrdinal("Email"));
                data.Phone = data_reader.GetString(data_reader.GetOrdinal("Phone"));
                data.RegDate = data_reader.GetDateTime(data_reader.GetOrdinal("RegDate"));
                data_list.Add(data);
            }
            return data_list;
        }
    }
}