using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookTradingSystem.Model
{
    /// <summary>
    /// 留言信息
    /// </summary>
    public class Message
    {
        public int MessageId { get; set; }
        /// <summary>
        /// 关联的图书交易信息
        /// </summary>
        public int BookInfoId { get; set; }
        /// <summary>
        /// 留言用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 留言消息标题
        /// </summary>
        public string MessageTitle { get; set; }
        /// <summary>
        /// 留言消息内容
        /// </summary>
        public string MessageContent { get; set; }
        /// <summary>
        /// 数据生成时间
        /// </summary>
        public DateTime ServerDate { get; set; }
    }
}