using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookTradingSystem.Model
{
    /// <summary>
    /// 用户
    /// </summary>
    public class Star
    {
        public int StarId { get; set; }
        /// <summary>
        /// 收藏者的ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 被收藏的交易信息的ID
        /// </summary>
        public int BookInfoId { get; set; }
    }
}