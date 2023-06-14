using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookTradingSystem.Model
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        public string LoginAccount { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPassword { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 角色权限
        /// </summary>
        public int IdentityRole { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 注册日期
        /// </summary>
        public DateTime RegDate { get; set; }
    }
}