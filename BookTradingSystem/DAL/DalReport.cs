using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BookTradingSystem.Model;

namespace BookTradingSystem.DAL
{
    public static class DalReport
    {
        /// <summary>
        /// 插入一条新数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int Insert(Report data)
        {
            string sql = $"INSERT INTO [dbo].[Report] ([BookInfoId] ,[ReporterId] ,[ReportContent] ,[ServerDate]) VALUES " +
                $"('{data.BookInfoId}','{data.ReporterId}','{data.ReportContent}','{data.ServerDate}')";
            return DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 举报成功处理——删除举报信息，同时将被举报的图书交易删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int SuccessDelete(int id)
        {
            string sql = $"SELECT * FROM [dbo].[Report] WHERE [ReportId]={id}";
            var data_reader = DBHelper.ExecuteReader(sql);
            string book_sql = $"DELETE FROM [dbo].[BookInfo] WHERE [BookInfoId]={data_reader.GetInt32(data_reader.GetOrdinal("BookInfoId"))}";
            DBHelper.ExecuteNonQuery(book_sql);

            string report_sql = $"DELETE FROM [dbo].[Report] WHERE [ReportId]={id}";
            return DBHelper.ExecuteNonQuery(report_sql);
        }

        /// <summary>
        /// 举报失败处理——仅删除举报信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int FailureDelete(int id)
        {
            string sql = $"DELETE FROM [dbo].[Report] WHERE [ReportId]={id}";
            return DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 获取表中所有可展示的举报数据
        /// </summary>
        /// <returns></returns>
        public static List<ReportView> GetDataList()
        {
            string sql = $"SELECT * FROM [dbo].[Report]";
            var data_reader = DBHelper.ExecuteReader(sql);
            List<ReportView> data_list = new List<ReportView>();
            while (data_reader.Read())
            {
                ReportView data = new ReportView();

                string book_sql = $"SELECT * FROM [dbo].[BookInfo] WHERE [BookInfoId]={data_reader.GetInt32(data_reader.GetOrdinal("BookInfoId"))}";
                var book_reader = DBHelper.ExecuteReader(book_sql);

                string user_sql = $"SELECT * FROM [dbo].[User] WHERE [UserId]={data_reader.GetInt32(data_reader.GetOrdinal("ReporterId"))}";
                var user_reader = DBHelper.ExecuteReader(user_sql);

                data.ReportId = data_reader.GetInt32(data_reader.GetOrdinal("ReportId"));
                data.BookInfoSummary = book_reader.GetString(book_reader.GetOrdinal("Summary"));
                data.ReporterName = user_reader.GetString(user_reader.GetOrdinal("UserName"));
                data.ReportContent = data_reader.GetString(data_reader.GetOrdinal("ReportContent"));
                data.ServerDate = data_reader.GetDateTime(data_reader.GetOrdinal("ServerDate"));

                data_list.Add(data);
            }
            return data_list;
        }
    }
}