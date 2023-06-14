using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookTradingSystem.Model
{
    /// <summary>
    /// 图书交易信息类型
    /// </summary>
    public enum BookInfoTransactionType
    {
        /// <summary>
        /// 出售
        /// </summary>
        Sale = 0,
        /// <summary>
        /// 求购
        /// </summary>
        Purchase = 1,
    }
}