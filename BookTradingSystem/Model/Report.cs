using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookTradingSystem.Model
{
    /// <summary>
    /// 新闻信息
    /// </summary>
    public class Report
    {
        public int ReportId { get; set; }
        /// <summary>
        /// 被举报交易信息的ID
        /// </summary>
        public int BookInfoId { get; set; }
        /// <summary>
        /// 举报用户的ID
        /// </summary>
        public int ReporterId { get; set; }
        /// <summary>
        /// 举报理由
        /// </summary>
        public string ReportContent { get; set; }
        /// <summary>
        /// 数据生成时间
        /// </summary>
        public DateTime ServerDate { get; set; }
    }
}