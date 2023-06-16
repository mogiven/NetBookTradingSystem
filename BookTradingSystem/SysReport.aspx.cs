using BookTradingSystem.DAL;
using BookTradingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookTradingSystem
{
    public partial class SysReport : System.Web.UI.Page
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
                m_ManagerMenu += "<a href=\"#accounts-mgr-menu\" class=\"nav-header\" data-toggle=\"collapse\"><i class=\"icon-briefcase\"></i>管理员功能</a>";
                m_ManagerMenu += "<ul id=\"accounts-mgr-menu\" class=\"nav nav-list collapse in\">";
                m_ManagerMenu += "<li><a href=\"UserMgr.aspx\">所有账号</a></li>";
                m_ManagerMenu += "<li><a href=\"SysReport.aspx\">处理举报</a></li>";
                m_ManagerMenu += "</ul>";
            }

            string action = Request.QueryString["action"] ?? "";
            string id = Request.QueryString["id"] ?? "0";
            int reportId;
            if (int.TryParse(id, out reportId))
            {
                if (action == "success")
                {
                    DalReport.SuccessDelete(reportId);
                    Response.Redirect("SysReport.aspx");
                }
                else if (action == "failure")
                {
                    DalReport.FailureDelete(reportId);
                    Response.Redirect("SysReport.aspx");
                }     
            }

            var user_list = DalUser.GetDataList();

            var data_list = DalReport.GetDataList();
            string table_data = "<table class=\"table table-bordered table-striped\">";
            table_data += "<thead><tr><th width=\"200px\">发布日期</th><th width=\"200px\">发布人</th><th>摘要</th><th>举报内容</th><th width=\"100px\">操作</th></tr></thead>";
            table_data += "<tbody>";
            foreach (var dat in data_list.OrderByDescending(n => n.ReportId))
            {
                string user_name = (dat == null ? "未知用户" : dat.ReporterName);

                table_data += "<tr>";
                table_data += $"<td>{dat.ServerDate}</td>";
                table_data += $"<td>{user_name}</td>";
                table_data += $"<td>{dat.BookInfoSummary}</td>";
                table_data += $"<td>{dat.ReportContent}</td>";
                table_data += $"<td>";
                table_data += $"<a href=\"javascript:;\" onclick=\"confirmDelete('SysReport.aspx?action=success&id={dat.ReportId}')\" style=\"margin-right: 5px;\"><i class=\"icon-check\"></i></a>";
                table_data += $"<a href=\"javascript:;\" onclick=\"confirmDelete('SysReport.aspx?action=failure&id={dat.ReportId}')\" style=\"margin-right: 5px;\"><i class=\"icon-remove\"></i></a>";
                table_data += $"</td>";
                table_data += "</tr>";
            }
            table_data += "</tbody></table>";
            m_TableData = table_data;
        }
    }
}
