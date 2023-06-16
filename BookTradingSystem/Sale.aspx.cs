using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BookTradingSystem.DAL;
using BookTradingSystem.Model;

namespace BookTradingSystem
{
    public partial class Sale : System.Web.UI.Page
    {
        protected string m_UserName = string.Empty;
        protected string m_MenuLeft = string.Empty;
        protected string m_TableData = string.Empty;

        protected string m_ManagerMenu = string.Empty;

        private string m_Action = string.Empty;
        private int m_DataId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            object obj = Session["user"];
            if (obj == null || (!(obj is User)))
            {
                Response.Redirect("~/login.aspx");
                return;
            }
            User user = (User)obj;
            m_UserName = user.UserName;

            if (user.IdentityRole == (int)UserIdentityRole.Manager)
            {
                m_ManagerMenu += $"<a href = \"#accounts-mgr-menu\" class=\"nav-header\" data-toggle=\"collapse\"><i class=\"icon-briefcase\"></i>管理员功能</a>";
                m_ManagerMenu += $"<ul id = \"accounts-mgr-menu\" class=\"nav nav-list collapse in\">";
                m_ManagerMenu += $"<li><a href = \"UserMgr.aspx\" > 所有账号 </a></li>";
                m_ManagerMenu += $"<li><a href = \"SysReport.aspx\" > 处理举报 </a></li>";
                m_ManagerMenu += $"</ul>";
            }

            var user_list = DalUser.GetDataList();

            var data_list = DalBookInfo.GetDataList();
            string table_data = string.Empty;
            table_data += $"<table class=\"table table-bordered table-striped\">" +
                $"<thead><tr><th width=\"200px\">发布日期</th><th width=\"200px\">供/求</th><th width=\"200px\">发布人</th><th>摘要</th></tr></thead>" +
                $"<tbody>";
            foreach (var dat in data_list.Where(n => n.TransactionType == (int)BookInfoTransactionType.Sale).OrderByDescending(n => n.BookInfoId))
            {
                string sale_or_purchase = string.Empty;
                switch ((BookInfoTransactionType)dat.TransactionType)
                {
                    case BookInfoTransactionType.Sale: { sale_or_purchase = "出售"; break; }
                    case BookInfoTransactionType.Purchase: { sale_or_purchase = "求购"; break; }
                }
                var u = user_list.Find(n => n.UserId == dat.UserId);
                string user_name = (u == null ? "未知用户" : u.UserName);

                table_data += $"<tr><td>{dat.ServerDate}</td><td>{sale_or_purchase}</td><td>{user_name}</td><td><a href=\"BookInfoDetails.aspx?id={dat.BookInfoId}\">{dat.Summary }</a></td>" +
                    $"";
            }
            table_data += $"</tbody></table>";
            m_TableData = table_data;
        }
    }
}