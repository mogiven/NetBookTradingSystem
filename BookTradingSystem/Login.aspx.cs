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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["user"] = null;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string login_account = Request.Form["LoginAccount"].ToString();
            string login_password = Request.Form["LoginPassword"].ToString();

            var user_list = DalUser.GetDataList();
            User user = user_list.Find(n => n.LoginAccount == login_account && n.LoginPassword == login_password);
            if (user == null)
            { Response.Write("<script>alert('用户名或密码错误！');window.location.href=document.URL;</script>"); return; }
            Session["user"] = user;
            Response.Redirect("~/index.aspx");
        }
    }
}