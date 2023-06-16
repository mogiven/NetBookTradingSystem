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
    public partial class BookInfoDetails : System.Web.UI.Page
    {
        protected string m_UserName = string.Empty;
        protected string m_MenuLeft = string.Empty;
        protected string m_PageData = string.Empty;

        private string m_Action = string.Empty;
        private int m_DataId = 0;

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
                m_ManagerMenu += $"</ul>";
            }

            m_Action = Request.QueryString["action"] ?? "";
            string id = Request.QueryString["id"] ?? "0";
            try { m_DataId = int.Parse(id); } catch { m_DataId = 0; }
            string msgid = Request.QueryString["msgid"] ?? "0";
            int msg_id = 0;
            try { msg_id = int.Parse(msgid); } catch { msg_id = 0; }
            if (m_Action == "del")
            {
                DalBookInfo.Delete(m_DataId);
                Response.Redirect($"BookInfoDetails.aspx?id={m_DataId}");
            }
            else if (m_Action == "delmsg")
            {
                DalMessage.Delete(msg_id);
                Response.Redirect($"BookInfoDetails.aspx?id={m_DataId}");
            }

            var user_list = DalUser.GetDataList();
            var book_info_data = DalBookInfo.GetData(m_DataId);
            if (book_info_data == null) return;
            var book_info_user = DalUser.GetData(book_info_data.UserId);
            if (book_info_user == null) return;
            var message_list = DalMessage.GetDataList(book_info_data.BookInfoId);

            string sale_or_purchase = string.Empty;
            switch ((BookInfoTransactionType)book_info_data.TransactionType)
            {
                case BookInfoTransactionType.Sale: { sale_or_purchase = "出售"; break; }
                case BookInfoTransactionType.Purchase: { sale_or_purchase = "求购"; break; }
            }

            m_PageData += $"<div class=\"faq-content\">";
            if (user.IdentityRole == (int)UserIdentityRole.Manager || user.UserId == book_info_data.UserId)
                m_PageData += $"<h2><a href=\"BookInfoDetails.aspx?action=del&id={m_DataId}\"><i class=\"icon-remove\"></i></a> " +
                $"{book_info_data.Summary}</h2>";
            else
                m_PageData += $"<h2><i class=\"icon-remove\" disabled></i> {book_info_data.Summary}</h2> ";
            m_PageData += $"<ul>";
            m_PageData += $"<li>交易类型:{sale_or_purchase}</li>";
            m_PageData += $"<li>发布时间:{book_info_data.ServerDate}</li>";
            m_PageData += $"<li>发布用户:{book_info_user.UserName}</li>";
            m_PageData += $"<li>联系电话:{book_info_user.Phone}</li>";
            m_PageData += $"<li>电子邮件:{book_info_user.Email}</li>";
            m_PageData += $"</ul>";
            m_PageData += $"<p>{book_info_data.Contents}</p>";
            m_PageData += $"<hr>";

            foreach( var data in message_list.OrderByDescending(n=>n.ServerDate))
            {
                var u = user_list.Find(n => n.UserId == data.UserId);
                m_PageData += $"<p>";
                if ( user.IdentityRole == (int )UserIdentityRole.Manager || user.UserId == data.UserId)
                    m_PageData += $"<a href=\"BookInfoDetails.aspx?action=delmsg&id={m_DataId}&msgid={data.MessageId}\"><i class=\"icon-remove\"></i></a> ";
                else
                    m_PageData += $"<i class=\"icon-remove\" disabled></i> ";
                m_PageData += $"[ {data.ServerDate} / {u.UserName } ] {data.MessageTitle}</p>";
                m_PageData += $"<p>{data.MessageContent}</p>";
                m_PageData += $"<hr>";
            }

            if (!IsPostBack)
            {
                // Check if the user has already starred the book
                int isStar = DalStar.GetIsStar(new Star()
                {
                    UserId = user.UserId,
                    BookInfoId = m_DataId
                });

                if (isStar != -1)
                {
                    // User has already starred the book
                    FollowButton.Text = "🤩已收藏";
                    FollowButton.CssClass = "btn btn-primary pull-right";
                    FollowButton.Enabled = true;
                }
                else
                {
                    // User has not starred the book
                    FollowButton.Text = "😶收藏";
                    FollowButton.CssClass = "btn btn-primary pull-right";
                    FollowButton.Enabled = true;
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string message_title = Request.Form["MessageTitle"].ToString();
            string message_content = Request.Form["MessageContent"].ToString();

            if (string.IsNullOrWhiteSpace(message_title) || string.IsNullOrWhiteSpace(message_content))
            { Response.Write("<script>alert('信息不能为空,所有项必须填写！');window.location.href=document.URL;</script>"); return; }

            object obj = Session["user"];
            if (obj == null || (!(obj is User)))
            {
                Response.Redirect("~/login.aspx");
                return;
            }
            User user = (User)obj;


            DalMessage.Insert(new Message()
            {
                MessageId = 0,
                BookInfoId = m_DataId,
                UserId = user.UserId,
                MessageTitle = message_title,
                MessageContent = message_content,
                ServerDate = DateTime.Now,
            });
            Response.Redirect($"BookInfoDetails.aspx?id={m_DataId}");
            //Response.Write("<script>alert('账号信息更新成功！');window.location.href='Login.aspx';</script>");
        }
        protected void FollowButton_Click(object sender, EventArgs e)
        {
            object obj = Session["user"];
            if (obj == null || (!(obj is User)))
            {
                Response.Redirect("~/login.aspx");
                return;
            }
            User user = (User)obj;

            // Check if the user has already starred the book
            int isStar = DalStar.GetIsStar(new Star()
            {
                UserId = user.UserId,
                BookInfoId = m_DataId
            });

            if (isStar != -1)
            {
                Console.WriteLine("删除");
                int cancel_result = DalStar.Delete(isStar);
                if(cancel_result != 0)
                {
                    // Star added successfully
                    // Update the button appearance
                    FollowButton.Text = "😶收藏";
                    FollowButton.CssClass = "btn btn-primary pull-right";
                    FollowButton.Enabled = true;
                }
                return;
            }

            // Add the star to the database
            int result = DalStar.Insert(new Star()
            {
                UserId = user.UserId,
                BookInfoId = m_DataId
            });

            if (result > 0)
            {
                // Star added successfully
                // Update the button appearance
                FollowButton.Text = "🤩已收藏";
                FollowButton.CssClass = "btn btn-primary pull-right";
                FollowButton.Enabled = true;
            }
            else
            {
                // Error occurred while adding the star
                // Handle the error or show an error message
            }
        }


    }
}