using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookTradingSystem.Model
{
    /// <summary>
    /// 用户权限和身份标识
    /// </summary>
    public enum UserIdentityRole
    {
        /// <summary>
        /// 管理员
        /// </summary>
        Manager = 0,
        /// <summary>
        /// 普通用户
        /// </summary>
        NormalUser = 1,
    }
}