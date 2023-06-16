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
    public partial class Index : System.Web.UI.Page
    {
        protected string m_UserName = string.Empty;
        protected string m_TableData_Sale = string.Empty;
        protected string m_TableData_Purchase = string.Empty;
        protected string m_TableData_Recommend = string.Empty;

        protected string m_UserCount = "0";
        protected string m_SaleCount = "0";
        protected string m_PurchaseCount = "0";
        protected string m_MessageCount = "0";

        protected string m_ManagerMenu = string.Empty;

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
            m_UserCount = user_list.Count.ToString();
            var bookinfo_list = DalBookInfo.GetDataList();
            m_SaleCount = bookinfo_list.Where(n => n.TransactionType == (int)BookInfoTransactionType.Sale).Count().ToString();
            m_PurchaseCount = bookinfo_list.Where(n => n.TransactionType == (int)BookInfoTransactionType.Purchase).Count().ToString();
            var message_list = DalMessage.GetDataList();
            m_MessageCount = message_list.Count.ToString();

            var data_list = DalBookInfo.GetDataList();
            //string table_data = string.Empty;
            m_TableData_Sale += $"<table class=\"table table-bordered table-striped\">" +
                $"<thead><tr><th width=\"180px\">发布日期</th><th width=\"60px\">供/求</th><th width=\"100px\">发布人</th><th>摘要</th></tr></thead>" +
                $"<tbody>";
            m_TableData_Purchase += $"<table class=\"table table-bordered table-striped\">" +
                $"<thead><tr><th width=\"180px\">发布日期</th><th width=\"60px\">供/求</th><th width=\"100px\">发布人</th><th>摘要</th></tr></thead>" +
                $"<tbody>";
            foreach (var dat in data_list.OrderByDescending(n => n.BookInfoId))
            {
                var u = user_list.Find(n => n.UserId == dat.UserId);
                string user_name = (u == null ? "未知用户" : u.UserName);
                string sale_or_purchase = string.Empty;
                switch ((BookInfoTransactionType)dat.TransactionType)
                {
                    case BookInfoTransactionType.Sale:
                        {
                            sale_or_purchase = "出售";
                            m_TableData_Sale += $"<tr><td>{dat.ServerDate}</td><td>{sale_or_purchase}</td><td>{user_name}</td><td>" +
                                $"<a href=\"BookInfoDetails.aspx?id={dat.BookInfoId}\">{dat.Summary }</a></td>";
                            break;
                        }
                    case BookInfoTransactionType.Purchase:
                        {
                            sale_or_purchase = "求购";
                            m_TableData_Purchase += $"<tr><td>{dat.ServerDate}</td><td>{sale_or_purchase}</td><td>{user_name}</td><td>" +
                                $"<a href=\"BookInfoDetails.aspx?id={dat.BookInfoId}\">{dat.Summary }</a></td>";
                            break;
                        }
                }
            }
            m_TableData_Sale += $"</tbody></table>";
            m_TableData_Purchase += $"</tbody></table>";

            // Get the recommended books for the user
            List<BookInfo> recommendedBooks = DalRecommendation.GetRecommendations(user.UserId);

            // Build the HTML table for recommended books
            m_TableData_Recommend += "<table class=\"table table-bordered table-striped\">" +
                "<thead><tr><th width=\"180px\">发布日期</th><th width=\"60px\">供/求</th><th width=\"100px\">发布人</th><th>摘要</th></tr></thead>" +
                "<tbody>";

            foreach (var book in recommendedBooks)
            {
                var u = user_list.Find(n => n.UserId == book.UserId);
                string userName = (user == null ? "未知用户" : user.UserName);
                string saleOrPurchase = string.Empty;
                switch ((BookInfoTransactionType)book.TransactionType)
                {
                    case BookInfoTransactionType.Sale:
                        saleOrPurchase = "出售";
                        break;
                    case BookInfoTransactionType.Purchase:
                        saleOrPurchase = "求购";
                        break;
                }

                m_TableData_Recommend += $"<tr><td>{book.ServerDate}</td><td>{saleOrPurchase}</td><td>{userName}</td><td>" +
                    $"<a href=\"BookInfoDetails.aspx?id={book.BookInfoId}\">{book.Summary}</a></td></tr>";
            }

            m_TableData_Recommend += "</tbody></table>";
        }
    }
}