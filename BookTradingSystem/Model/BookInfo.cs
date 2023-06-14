using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookTradingSystem.Model
{
    /// <summary>
    /// 图书信息
    /// </summary>
    public class BookInfo
    {
        public int BookInfoId { get; set; }
        /// <summary>
        /// 发布信息的用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 交易信息摘要-标题
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// 交易信息内容
        /// </summary>
        public string Contents { get; set; }
        /// <summary>
        /// 交易类型 0-出售 1-求购
        /// </summary>
        public int TransactionType { get; set; }
        /// <summary>
        /// 数据生成时间
        /// </summary>
        public DateTime ServerDate { get; set; }

    }
}