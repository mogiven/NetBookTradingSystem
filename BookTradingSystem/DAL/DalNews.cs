using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BookTradingSystem.Model;

namespace BookTradingSystem.DAL
{
    public static class DalNews
    {
        /// <summary>
        /// 插入一条新数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int Insert(News data)
        {
            string sql = $"INSERT INTO [dbo].[News] ([NewsTitle] ,[NewsContent] ,[ServerDate]) VALUES " +
                $"('{data.NewsTitle}','{data.NewsContent}','{data.ServerDate}')";
            return DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 按指定 id 更新一条数据
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Update(News data)
        {
            string sql = $"UPDATE [dbo].[News] " +
                $"SET [UserId] = '{data.NewsTitle}'" +
                $",[Summary] = '{data.NewsContent}'" +
                $",[ServerDate] = '{data.ServerDate}'" +
                $" WHERE [NewsId]={data.NewsId}";
            return DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 删除指定 id 的特定数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Delete(int id)
        {
            string sql = $"DELETE FROM [dbo].[News] WHERE [NewsId]={id}";
            return DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 获取表中所有数据
        /// </summary>
        /// <returns></returns>
        public static List<News> GetDataList()
        {
            string sql = $"SELECT * FROM [dbo].[News]";
            var data_reader = DBHelper.ExecuteReader(sql);
            List<News> data_list = new List<News>();
            while (data_reader.Read())
            {
                News data = new News();
                data.NewsId = data_reader.GetInt32(data_reader.GetOrdinal("NewsId"));
                data.NewsTitle = data_reader.GetString(data_reader.GetOrdinal("NewsTitle"));
                data.NewsContent = data_reader.GetString(data_reader.GetOrdinal("NewsContent"));
                data.ServerDate = data_reader.GetDateTime(data_reader.GetOrdinal("ServerDate"));

                data_list.Add(data);
            }
            return data_list;
        }
    }
}