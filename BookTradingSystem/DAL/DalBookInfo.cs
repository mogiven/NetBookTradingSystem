using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BookTradingSystem.Model;

namespace BookTradingSystem.DAL
{
    public static class DalBookInfo
    {
        /// <summary>
        /// 插入一条新数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int Insert(BookInfo data)
        {
            string sql = $"INSERT INTO [dbo].[BookInfo] ([UserId] ,[Summary] ,[Contents] ,[TransactionType] ,[ServerDate]) VALUES " +
                $"('{data.UserId}','{data.Summary}','{data.Contents}','{data.TransactionType}','{data.ServerDate}')";
            return DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 按指定 id 更新一条数据
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Update(BookInfo data)
        {
            string sql = $"UPDATE [dbo].[BookInfo] " +
                $"SET [UserId] = '{data.UserId}'" +
                $",[Summary] = '{data.Summary}'" +
                $",[Contents] = '{data.Contents}'" +
                $",[TransactionType] = '{data.TransactionType}'" +
                $",[ServerDate] = '{data.ServerDate}'" +
                $" WHERE [BookInfoId]={data.BookInfoId}";
            return DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 删除指定 id 的特定数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Delete(int id)
        {
            string sql = $"DELETE FROM [dbo].[BookInfo] WHERE [BookInfoId]={id}";
            return DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 获取指定 id 的特定数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BookInfo GetData(int id)
        {
            string sql = $"SELECT * FROM [dbo].[BookInfo] WHERE [BookInfoId]={id}";
            var data_reader = DBHelper.ExecuteReader(sql);
            if (data_reader.Read())
            {
                BookInfo data = new BookInfo();
                data.BookInfoId = data_reader.GetInt32(data_reader.GetOrdinal("BookInfoId"));
                data.UserId = data_reader.GetInt32(data_reader.GetOrdinal("UserId"));
                data.Summary = data_reader.GetString(data_reader.GetOrdinal("Summary"));
                data.Contents = data_reader.GetString(data_reader.GetOrdinal("Contents"));
                data.TransactionType = data_reader.GetInt32(data_reader.GetOrdinal("TransactionType"));
                data.ServerDate = data_reader.GetDateTime(data_reader.GetOrdinal("ServerDate"));
                return data;
            }
            else
                return null;
        }

        /// <summary>
        /// 获取表中所有数据
        /// </summary>
        /// <returns></returns>
        public static List<BookInfo> GetDataList()
        {
            string sql = $"SELECT * FROM [dbo].[BookInfo]";
            var data_reader = DBHelper.ExecuteReader(sql);
            List<BookInfo> data_list = new List<BookInfo>();
            while (data_reader.Read())
            {
                BookInfo data = new BookInfo();
                data.BookInfoId = data_reader.GetInt32(data_reader.GetOrdinal("BookInfoId"));
                data.UserId = data_reader.GetInt32(data_reader.GetOrdinal("UserId"));
                data.Summary = data_reader.GetString(data_reader.GetOrdinal("Summary"));
                data.Contents = data_reader.GetString(data_reader.GetOrdinal("Contents"));
                data.TransactionType = data_reader.GetInt32(data_reader.GetOrdinal("TransactionType"));
                data.ServerDate = data_reader.GetDateTime(data_reader.GetOrdinal("ServerDate"));
                data_list.Add(data);
            }
            return data_list;
        }
        /// <summary>
        /// 获取表中所有数据
        /// </summary>
        /// <returns></returns>
        public static List<BookInfo> GetDataList(int user_id)
        {
            string sql = $"SELECT * FROM [dbo].[BookInfo] WHERE [UserId]={user_id}";
            var data_reader = DBHelper.ExecuteReader(sql);
            List<BookInfo> data_list = new List<BookInfo>();
            while (data_reader.Read())
            {
                BookInfo data = new BookInfo();
                data.BookInfoId = data_reader.GetInt32(data_reader.GetOrdinal("BookInfoId"));
                data.UserId = data_reader.GetInt32(data_reader.GetOrdinal("UserId"));
                data.Summary = data_reader.GetString(data_reader.GetOrdinal("Summary"));
                data.Contents = data_reader.GetString(data_reader.GetOrdinal("Contents"));
                data.TransactionType = data_reader.GetInt32(data_reader.GetOrdinal("TransactionType"));
                data.ServerDate = data_reader.GetDateTime(data_reader.GetOrdinal("ServerDate"));
                data_list.Add(data);
            }
            return data_list;
        }

    }
}