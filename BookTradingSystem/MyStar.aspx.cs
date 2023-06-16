using System;
using System.Collections.Generic;
using System.Web.UI;

using BookTradingSystem.DAL;
using BookTradingSystem.Model;

namespace BookTradingSystem
{
    public partial class MyStar : Page
    {
        protected string m_UserName = string.Empty;
        protected string m_TableData = string.Empty;

        protected string m_ManagerMenu = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            object obj = Session["user"];
            if (obj == null || !(obj is User))
            {
                Response.Redirect("~/login.aspx");
                return;
            }

            var user_list = DalUser.GetDataList();

            User user = (User)obj;
            m_UserName = user.UserName;

            if (user.IdentityRole == (int)UserIdentityRole.Manager)
            {
                m_ManagerMenu += $"<a href = \"#accounts-mgr-menu\" class=\"nav-header\" data-toggle=\"collapse\"><i class=\"icon-briefcase\"></i>管理员功能</a>";
                m_ManagerMenu += $"<ul id = \"accounts-mgr-menu\" class=\"nav nav-list collapse in\">";
                m_ManagerMenu += $"<li><a href = \"UserMgr.aspx\" > 所有账号 </a></li>";
                m_ManagerMenu += $"</ul>";
            }

            var starList = DalStar.GetStarList(user.UserId);
            var bookInfoList = DalBookInfo.GetDataList(); // Retrieve all book info data

            string tableData = "<table class=\"table table-bordered table-striped\">" +
                "<thead><tr><th width=\"200px\">发布日期</th><th width=\"200px\">供/求</th><th width=\"200px\">发布人</th><th>摘要</th></tr></thead>" +
                "<tbody>";

            foreach (var star in starList)
            {
                var bookInfo = bookInfoList.Find(b => b.BookInfoId == star.BookInfoId);
                if (bookInfo != null)
                {
                    string saleOrPurchase = star.TransactionType == (int)BookInfoTransactionType.Sale ? "出售" : "求购";
                    var u = user_list.Find(n => n.UserId == star.UserId);
                    string userName = (u == null ? "未知用户" : u.UserName);

                    tableData += $"<tr><td>{bookInfo.ServerDate}</td><td>{saleOrPurchase}</td><td>{userName}</td><td><a href=\"BookInfoDetails.aspx?id={bookInfo.BookInfoId}\">{bookInfo.Summary}</a></td></tr>";
                }
            }

            tableData += "</tbody></table>";
            m_TableData = tableData;
        }
    }
}
