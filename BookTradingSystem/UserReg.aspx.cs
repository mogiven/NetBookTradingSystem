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
    public partial class UserReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            string login_account = Request.Form["LoginAccount"].ToString();
            string login_password = Request.Form["LoginPassword"].ToString();
            string username = Request.Form["UserName"].ToString();
            string phone = Request.Form["Phone"].ToString();
            string email = Request.Form["Email"].ToString();

            if (string.IsNullOrWhiteSpace(login_account) || string.IsNullOrWhiteSpace(login_password) || string.IsNullOrWhiteSpace(username)
                 || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(email))
            { Response.Write("<script>alert('注册信息不能为空,所有项必须填写！');window.location.href=document.URL;</script>"); return; }

            var user_list = DalUser.GetDataList();
            if (user_list.Find(n => n.LoginAccount == login_account) != null) { Response.Write("<script>alert('登录账号已经存在,请换一个重新注册！');window.location.href=document.URL;</script>"); return; }
            if (user_list.Find(n => n.UserName == username) != null) { Response.Write("<script>alert('用户昵称已经存在,请换一个重新注册！');window.location.href=document.URL;</script>"); return; }
            if (user_list.Find(n => n.Phone == phone) != null) { Response.Write("<script>alert(电话已经存在,请换一个重新注册！');window.location.href=document.URL;</script>"); return; }
            if (user_list.Find(n => n.Email == email) != null) { Response.Write("<script>alert('邮箱已经存在,请换一个重新注册！');window.location.href=document.URL;</script>"); return; }

            DalUser.Insert(new Model.User()
            {
                UserId = 0,
                LoginAccount = login_account,
                LoginPassword = login_password,
                Phone = phone,
                Email = email,
                UserName = username,
                IdentityRole = (int)UserIdentityRole.NormalUser,
                RegDate = DateTime.Now
            });
            Response.Write("<script>alert('注册成功, 请用注册的账号登录！');window.location.href='Login.aspx';</script>");
            //Response.Redirect("Login.aspx");
        }
    }
}