﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookInfoDetails.aspx.cs" Inherits="BookTradingSystem.BookInfoDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8">
    <title></title>
    <meta content="IE=edge,chrome=1" http-equiv="X-UA-Compatible">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    <link rel="stylesheet" type="text/css" href="lib/bootstrap/css/bootstrap.css">
    
    <link rel="stylesheet" type="text/css" href="stylesheets/theme.css">
    <link rel="stylesheet" href="lib/font-awesome/css/font-awesome.css">

    <script src="lib/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-pzjw8DE/3G82XYB1s3fg5+995vzlZy0qIdk8qB49KX9B1SdXg1d6t/j2O5JvW9+" crossorigin="anonymous">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-pzjw8DE/3G82XYB1s3fg5+995vzlZy0qIdk8qB49KX9B1SdXg1d6t/j2O5JvW9+" crossorigin="anonymous"></script>

    <!-- Demo page code -->

    <style type="text/css">
        #line-chart {
            height:300px;
            width:800px;
            margin: 0px auto;
            margin-top: 1em;
        }
        .brand { font-family: georgia, serif; }
        .brand .first {
            color: #ccc;
            font-style: italic;
        }
        .brand .second {
            color: #fff;
            font-weight: bold;
        }
    </style>

    <!-- Le HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->

    <!-- Le fav and touch icons -->
    <link rel="shortcut icon" href="../assets/ico/favicon.ico">
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="../assets/ico/apple-touch-icon-144-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="../assets/ico/apple-touch-icon-114-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="../assets/ico/apple-touch-icon-72-precomposed.png">
    <link rel="apple-touch-icon-precomposed" href="../assets/ico/apple-touch-icon-57-precomposed.png">
  </head>

  <!--[if lt IE 7 ]> <body class="ie ie6"> <![endif]-->
  <!--[if IE 7 ]> <body class="ie ie7 "> <![endif]-->
  <!--[if IE 8 ]> <body class="ie ie8 "> <![endif]-->
  <!--[if IE 9 ]> <body class="ie ie9 "> <![endif]-->
  <!--[if (gt IE 9)|!(IE)]><!--> 
  <body class=""> 
  <!--<![endif]-->
    
    <div class="navbar">
        <div class="navbar-inner">
                <ul class="nav pull-right">
                    
                    <li id="fat-menu" class="dropdown">
                        <a href="#" role="button" class="dropdown-toggle" data-toggle="dropdown">
                            <i class="icon-user"></i> <%=m_UserName %>
                            <i class="icon-caret-down"></i>
                        </a>

                        <ul class="dropdown-menu">
                            <li><a tabindex="-1" href="MyAccount.aspx">我的账号</a></li>
                            <li class="divider"></li>
                            <li><a tabindex="-1" class="visible-phone" href="#">设置</a></li>
                            <li class="divider visible-phone"></li>
                            <li><a tabindex="-1" href="Login.aspx">退出</a></li>
                        </ul>
                    </li>
                    
                </ul>
                <a class="brand" href="Index.aspx"><span class="first"></span> <span class="second">校园二手图书交易系统</span></a>
        </div>
    </div>
        
    <div class="sidebar-nav">
        <a href="#dashboard-menu" class="nav-header" data-toggle="collapse"><i class="icon-dashboard"></i>交易市场</a>
        <ul id="dashboard-menu" class="nav nav-list collapse in">
            <li><a href="Index.aspx">平台主页</a></li>
            <li><a href="Sale.aspx">出售信息</a></li>
            <li><a href="Purchase.aspx">求购信息</a></li>
        </ul>
        <a href="#bookinfo-menu" class="nav-header" data-toggle="collapse"><i class="icon-briefcase"></i>我的发布</a>
        <ul id="bookinfo-menu" class="nav nav-list collapse in">
            <li><a href="MySale.aspx">我的出售</a></li>
            <li><a href="MyPurchase.aspx">我的求购</a></li>
            <li><a href="MyBookInfo.aspx">发布信息</a></li>
            <li><a href="MyStar.aspx">我的收藏</a></li>
        </ul>
        <a href="#accounts-menu" class="nav-header" data-toggle="collapse"><i class="icon-briefcase"></i>账号管理</a>
        <ul id="accounts-menu" class="nav nav-list collapse in">
            <li><a href="MyAccount.aspx">我的账号</a></li>
        </ul>
        <%=m_ManagerMenu %>
    </div>


    <div class="content">
        <div class="header">
            <div class="stats">
            </div>
            <h1 class="page-title">信息详情</h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="index.aspx">交易平台</a> <span class="divider">/</span></li>
            <li class="active">信息详情</li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                    
    <%=m_PageData %>
                    <form runat="server">
                    <label>留言标题</label>
                    <input id="MessageTitle" type="text" class="span12" runat="server">
                    <label>留言内容</label>
                    <input id="MessageContent" type="text" class="span12" runat="server">

                        <!-- 在页面上添加一个隐藏的模态框 -->
                        <div id="reportModal" class="modal fade" tabindex="-1" role="dialog">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <div class="modal-title">填写举报内容</div>
                                        <button type="button" class="close m-0" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <textarea id="reportContent" class="form-control" rows="4" runat="server" style="width:80%"></textarea>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">取消</button>
                                        <asp:Button ID="SubmitReportButton" runat="server" Text="提交" class="btn btn-primary" OnClick="ReportButton_Click" />
                                    </div>
                                </div>
                            </div>
</div>
                    <asp:Button ID="ReportButton" runat="server" Text="举报" class="btn btn-danger" OnClientClick="openReportModal(); return false;" />
                    <asp:Button ID="FollowButton" runat="server" class="btn btn-primary pull-right" OnClick="FollowButton_Click" OnClientClick="return confirm('确定吗？');" />
                    <asp:Button ID="btnSave" runat="server" Text="我要留言" class="btn btn-primary pull-right" OnClick="btnSave_Click"/>
                    <div class="clearfix"></div>
                </form>
                <footer>
                    <hr>
                    <p>&copy; 2022 <a href="#" target="_blank">校园二手图书交易系统</a></p>
                </footer>                
            </div>
        </div>
    </div>
    
    <script src="lib/bootstrap/js/bootstrap.js"></script>
    <script type="text/javascript">
        $("[rel=tooltip]").tooltip();
        $(function() {
            $('.demo-cancel-click').click(function(){return false;});
        });
    </script>

      <!-- JavaScript 代码 -->
<script>
    // 打开模态框
    function openReportModal() {
        $('#reportModal').modal('show');
    }

    // 提交举报
    function submitReport() {
        var reportContent = $('#reportContent').val();
        // 进行其他验证，如不能为空验证等
        // 将报告内容设置到隐藏字段中
        $('#<%= reportContent.ClientID %>').val(reportContent);
    // 执行举报按钮的点击事件
    <%= Page.ClientScript.GetPostBackEventReference(ReportButton, "") %>
    }
</script>
    
  </body>
</html>

