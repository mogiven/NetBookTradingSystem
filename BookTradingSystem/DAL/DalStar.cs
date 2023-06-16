using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BookTradingSystem.Model;

namespace BookTradingSystem.DAL
{
    public static class DalStar
    {
        /// <summary>
        /// 插入一条新数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int Insert(Star data)
        {
            string sql = $"INSERT INTO [dbo].[Star] ([UserId] ,[BookInfoId]) VALUES " +
                $"('{data.UserId}','{data.BookInfoId}')";
            return DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 删除指定 id 的特定数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Delete(int id)
        {
            string sql = $"DELETE FROM [dbo].[Star] WHERE [StarId]={id}";
            return DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 获取指定 用户id 的收藏列表
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public static List<BookInfo> GetStarList(int user_id)
        {
            string sql = $"SELECT * FROM [dbo].[Star] WHERE [UserId]={user_id}";
            var star_reader = DBHelper.ExecuteReader(sql);
            List<int> star_list = new List<int>();
            while (star_reader.Read())
            {
                int book_info_id = star_reader.GetInt32(star_reader.GetOrdinal("BookInfoId"));
                star_list.Add(book_info_id);
            }

            List<BookInfo> data_list = new List<BookInfo>();
            foreach(var book_info_id in star_list)
            {
                BookInfo data = new BookInfo();

                string book_sql = $"SELECT * FROM [dbo].[BookInfo] WHERE [BookInfoId]={book_info_id}";
                var data_reader = DBHelper.ExecuteReader(book_sql);
                if (data_reader.Read()) 
                {
                    data.BookInfoId = data_reader.GetInt32(data_reader.GetOrdinal("BookInfoId"));
                    data.UserId = data_reader.GetInt32(data_reader.GetOrdinal("UserId"));
                    data.Summary = data_reader.GetString(data_reader.GetOrdinal("Summary"));
                    data.Contents = data_reader.GetString(data_reader.GetOrdinal("Contents"));
                    data.TransactionType = data_reader.GetInt32(data_reader.GetOrdinal("TransactionType"));
                    data.ServerDate = data_reader.GetDateTime(data_reader.GetOrdinal("ServerDate"));
                    data_list.Add(data);
                }
            }
            return data_list;
        }

        /// <summary>
        /// 获取用户是否收藏了该交易信息,收藏了则返回StarId，否则返回-1
        /// </summary>
        /// <param name="star"></param>
        /// <returns></returns>
        public static int GetIsStar(Star star)
        {
            string sql = $"SELECT * FROM [dbo].[Star] WHERE [UserId]={star.UserId} AND [BookInfoId]={star.BookInfoId}";
            var data_reader = DBHelper.ExecuteReader(sql);
            if (data_reader.Read())
            {
                return data_reader.GetInt32(data_reader.GetOrdinal("StarId"));
            }
            else
                return -1;
        }


    }
}