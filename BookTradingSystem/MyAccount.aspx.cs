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
    public partial class MyAccount : System.Web.UI.Page
    {
        protected string m_UserName = string.Empty;
        protected string m_MenuLeft = string.Empty;
        protected string m_TableData = string.Empty;

        protected string m_ManagerMenu = string.Empty;

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
                m_ManagerMenu += $"</ul>";
            }

            m_DataId = user.UserId;

            this.LoginAccount.Value = user.LoginAccount;
            this.LoginPassword.Value = user.LoginPassword;
            this.UserName.Value = user.UserName;
            this.Phone.Value = user.Phone;
            this.Email.Value = user.Email;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string login_account = Request.Form["LoginAccount"].ToString();
            string login_password = Request.Form["LoginPassword"].ToString();
            string username = Request.Form["UserName"].ToString();
            string phone = Request.Form["Phone"].ToString();
            string email = Request.Form["Email"].ToString();

            if (string.IsNullOrWhiteSpace(login_account) || string.IsNullOrWhiteSpace(login_password) || string.IsNullOrWhiteSpace(username)
                 || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(email))
            { Response.Write("<script>alert('信息不能为空,所有项必须填写！');window.location.href=document.URL;</script>"); return; }

            User u = DalUser.GetData(m_DataId);
            if (u.LoginAccount == "admin")
                if (u.LoginAccount != login_account)
                { Response.Write("<script>alert('管理员账号不能修改登录账号！');window.location.href='UserMgr.aspx';</script>"); return; }

            DalUser.Update(new Model.User()
            {
                UserId = m_DataId,
                LoginAccount = login_account,
                LoginPassword = login_password,
                Phone = phone,
                Email = email,
                UserName = username,
                IdentityRole = (int)UserIdentityRole.NormalUser,
                RegDate = DateTime.Now
            });
            Response.Write("<script>alert('账号信息更新成功！');window.location.href='Login.aspx';</script>");
            //Response.Redirect("Login.aspx");
        }
    }
}