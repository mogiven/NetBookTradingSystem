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
    public partial class UserMgr : System.Web.UI.Page
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
                m_ManagerMenu += $"<li class=\"active\"><a href = \"UserMgr.aspx\" > 所有账号 </a></li>";
                m_ManagerMenu += $"<li><a href = \"SysReport.aspx\" > 处理举报 </a></li>";
                m_ManagerMenu += $"</ul>";
            }

            m_Action = Request.QueryString["action"] ?? "";
            string id = Request.QueryString["id"] ?? "0";
            try { m_DataId = int.Parse(id); } catch { m_DataId = 0; }
            if (m_Action == "del")
            {
                User u = DalUser.GetData(m_DataId);
                if (u.LoginAccount == "admin")
                { Response.Write("<script>alert('管理员账号不能删除！');window.location.href='UserMgr.aspx';</script>"); return; }
                DalUser.Delete(m_DataId);
                Response.Redirect("UserMgr.aspx");
            }

            var user_list = DalUser.GetDataList();

            string table_data = string.Empty;
            table_data += $"<table class=\"table table-bordered table-striped\">" +
                $"<thead><tr><th width=\"200px\">登录账号</th><th width=\"200px\">登录密码</th><th width=\"200px\">用户昵称</th><th>角色</th>" +
                $"<th>电话</th><th>电子邮件</th><th>注册时间</th><th width=\"100px\">操作</th></tr></thead>" +
                $"<tbody>";
            foreach (var dat in user_list)
            {
                string role = string.Empty;
                switch ((UserIdentityRole)dat.IdentityRole)
                {
                    case UserIdentityRole. Manager: { role = "管理员"; break; }
                    case UserIdentityRole.NormalUser: { role = "普通用户"; break; }
                }
                var u = user_list.Find(n => n.UserId == dat.UserId);
                string user_name = (u == null ? "未知用户" : u.UserName);

                table_data += $"<tr><td>{dat.LoginAccount}</td><td>{dat.LoginPassword}</td><td>{dat.UserName}</td><td>{role}</td>" +
                    $"<td>{dat.Phone}</td><td>{dat.Email}</td><td>{dat.RegDate }</td>" +
                    $"<td>" +
                    $"<a href=\"UserMgr.aspx?action=del&id={dat.UserId}\"><i class=\"icon-remove\"></i></a>" +
                    $"</td>";
            }
            table_data += $"</tbody></table>";
            m_TableData = table_data;
        }
    }
}