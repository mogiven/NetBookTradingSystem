using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookTradingSystem.View
{
    /// <summary>
    /// 新闻信息
    /// </summary>
    public class ReportInfoView
    {
        public int ReportId { get; set; }
        /// <summary>
        /// 被举报交易信息的Summary
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// 举报用户的用户名
        /// </summary>
        public string ReporterName { get; set; }
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