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
    public partial class MyBookInfo : System.Web.UI.Page
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

            TransType.Items.Clear();
            TransType.Items.Add("出售");
            TransType.Items.Add("求购");

            m_Action = Request.QueryString["action"] ?? "";
            string id = Request.QueryString["id"] ?? "0";
            try { m_DataId = int.Parse(id); } catch { m_DataId = 0; }
            if (m_Action == "s")
            {
                TransType.Text = "出售";
            }
          else  if (m_Action == "p")
            {
                TransType.Text = "求购";
            }
            else if (m_Action == "update")
            {
                var data = DalBookInfo.GetData(m_DataId);
               this. Summary.Text = data.Summary;
                this.Contents.Value = data.Contents;
                switch (( BookInfoTransactionType) data.TransactionType )
                {
                    case BookInfoTransactionType.Sale: { TransType.SelectedValue = "出售"; break; ; }
                    case BookInfoTransactionType.Purchase: { TransType.SelectedValue = "求购"; break; ; }
                }
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            string trans_type = Request.Form["TransType"].ToString();
            string summary = Request.Form["Summary"].ToString();
            string contents = Request.Form["Contents"].ToString();

            if (string.IsNullOrWhiteSpace(trans_type) || string.IsNullOrWhiteSpace(summary) || string.IsNullOrWhiteSpace(contents))
            { Response.Write("<script>alert('信息不能为空,所有项必须填写！');window.location.href=document.URL;</script>"); return; }

            object obj = Session["user"];
            if (obj == null || (!(obj is User)))
            {
                Response.Redirect("~/login.aspx");
                return;
            }
            User user = (User)obj;

            BookInfoTransactionType transactionType = BookInfoTransactionType.Sale;
            switch(trans_type)
            {
                case "出售": { transactionType = BookInfoTransactionType.Sale; break; }
                case "求购": { transactionType = BookInfoTransactionType.Purchase; break; }
            }

            if (m_Action == "update" && m_DataId > 0)
            {
                DalBookInfo.Update(new BookInfo()
                {
                    BookInfoId = m_DataId,
                    UserId = user.UserId,
                    Summary = summary,
                    Contents = contents,
                    TransactionType = (int)transactionType,
                    ServerDate = DateTime.Now,
                }); 
            }
            else
            {
                DalBookInfo.Insert(new BookInfo()
                {
                    BookInfoId = m_DataId,
                    UserId = user.UserId,
                    Summary = summary,
                    Contents = contents,
                    TransactionType = (int)transactionType,
                    ServerDate = DateTime.Now,
                }); ;
            }
            switch (transactionType)
            {
                case BookInfoTransactionType.Sale: { Response.Write("<script>alert('发布成功！');window.location.href='mysale.aspx';</script>"); break; }
                case BookInfoTransactionType.Purchase: { Response.Write("<script>alert('发布成功！');window.location.href='mypurchase.aspx';</script>"); break; }
            }

        }
    }
}