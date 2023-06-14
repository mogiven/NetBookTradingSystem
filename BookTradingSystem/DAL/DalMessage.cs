using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BookTradingSystem.Model;

namespace BookTradingSystem.DAL
{
    public static class DalMessage
    {
        /// <summary>
        /// 插入一条新数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int Insert(Message data)
        {
            string sql = $"INSERT INTO [dbo].[Message] ([BookInfoId] ,[UserId] ,[MessageTitle] ,[MessageContent] ,[ServerDate]) VALUES " +
                $"('{data.BookInfoId}','{data.UserId}','{data.MessageTitle}','{data.MessageContent}','{data.ServerDate}')";
            return DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 按指定 id 更新一条数据
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Update(Message data)
        {
            string sql = $"UPDATE [dbo].[Message] " +
                $"SET [BookInfoId] = '{data.BookInfoId}'" +
                $",[UserId] = '{data.UserId}'" +
                $",[MessageTitle] = '{data.MessageTitle}'" +
                $",[MessageContent] = '{data.MessageContent}'" +
                $",[ServerDate] = '{data.ServerDate}'" +
                $" WHERE [MessageId]={data.MessageId}";
            return DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 删除指定 id 的特定数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Delete(int id)
        {
            string sql = $"DELETE FROM [dbo].[Message] WHERE [MessageId]={id}";
            return DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 获取指定 id 的特定数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Message GetData(int id)
        {
            string sql = $"SELECT * FROM [dbo].[Message] WHERE [MessageId]={id}";
            var data_reader = DBHelper.ExecuteReader(sql);
            if (data_reader.Read())
            {
                Message data = new Message();
                data.MessageId = data_reader.GetInt32(data_reader.GetOrdinal("MessageId"));
                data.BookInfoId = data_reader.GetInt32(data_reader.GetOrdinal("BookInfoId"));
                data.UserId = data_reader.GetInt32(data_reader.GetOrdinal("UserId"));
                data.MessageTitle = data_reader.GetString(data_reader.GetOrdinal("MessageTitle"));
                data.MessageContent = data_reader.GetString(data_reader.GetOrdinal("MessageContent"));
                data.ServerDate = data_reader.GetDateTime (data_reader.GetOrdinal("ServerDate"));
                return data;
            }
            else
                return null;
        }

        /// <summary>
        /// 获取表中所有数据
        /// </summary>
        /// <returns></returns>
        public static List<Message> GetDataList()
        {
            string sql = $"SELECT * FROM [dbo].[Message]";
            var data_reader = DBHelper.ExecuteReader(sql);
            List<Message> data_list = new List<Message>();
            while (data_reader.Read())
            {
                Message data = new Message();
                data.MessageId = data_reader.GetInt32(data_reader.GetOrdinal("MessageId"));
                data.BookInfoId = data_reader.GetInt32(data_reader.GetOrdinal("BookInfoId"));
                data.UserId = data_reader.GetInt32(data_reader.GetOrdinal("UserId"));
                data.MessageTitle = data_reader.GetString(data_reader.GetOrdinal("MessageTitle"));
                data.MessageContent = data_reader.GetString(data_reader.GetOrdinal("MessageContent"));
                data.ServerDate = data_reader.GetDateTime(data_reader.GetOrdinal("ServerDate"));
                data_list.Add(data);
            }
            return data_list;
        }

        /// <summary>
        /// 获取表中所有数据
        /// </summary>
        /// <returns></returns>
        public static List<Message> GetDataList(int book_info_id)
        {
            string sql = $"SELECT * FROM [dbo].[Message] WHERE [BookInfoId]={book_info_id}";
            var data_reader = DBHelper.ExecuteReader(sql);
            List<Message> data_list = new List<Message>();
            while (data_reader.Read())
            {
                Message data = new Message();
                data.MessageId = data_reader.GetInt32(data_reader.GetOrdinal("MessageId"));
                data.BookInfoId = data_reader.GetInt32(data_reader.GetOrdinal("BookInfoId"));
                data.UserId = data_reader.GetInt32(data_reader.GetOrdinal("UserId"));
                data.MessageTitle = data_reader.GetString(data_reader.GetOrdinal("MessageTitle"));
                data.MessageContent = data_reader.GetString(data_reader.GetOrdinal("MessageContent"));
                data.ServerDate = data_reader.GetDateTime(data_reader.GetOrdinal("ServerDate"));
                data_list.Add(data);
            }
            return data_list;
        }
    }
}