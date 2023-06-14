<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BookTradingSystem.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8">
    <title>校园二手图书交易系统</title>
    <meta content="IE=edge,chrome=1" http-equiv="X-UA-Compatible">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    <link rel="stylesheet" type="text/css" href="lib/bootstrap/css/bootstrap.css">
    
    <link rel="stylesheet" type="text/css" href="stylesheets/theme.css">
    <link rel="stylesheet" href="lib/font-awesome/css/font-awesome.css">

    <script src="lib/jquery-1.7.2.min.js" type="text/javascript"></script>

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
            <li class="active"><a href="Index.aspx">平台主页</a></li>
            <li><a href="Sale.aspx">出售信息</a></li>
            <li><a href="Purchase.aspx">求购信息</a></li>
        </ul>
        <a href="#bookinfo-menu" class="nav-header" data-toggle="collapse"><i class="icon-briefcase"></i>我的发布</a>
        <ul id="bookinfo-menu" class="nav nav-list collapse in">
            <li ><a href="MySale.aspx">我的出售</a></li>
            <li ><a href="MyPurchase.aspx">我的求购</a></li>
            <li><a href="MyBookInfo.aspx">发布信息</a></li>
        </ul>
        <a href="#accounts-menu" class="nav-header" data-toggle="collapse"><i class="icon-briefcase"></i>账号管理</a>
        <ul id="accounts-menu" class="nav nav-list collapse in">
            <li ><a href="MyAccount.aspx">我的账号</a></li>
        </ul>
        <%=m_ManagerMenu %>
    </div>

    <div class="content">
        <div class="header">
            <div class="stats">
            </div>
            <h1 class="page-title">校园二手图书交易系统</h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="index.aspx">交易平台</a> <span class="divider">/</span></li>
            <li class="active">主页</li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">

<div class="row-fluid">
    <div class="block">
        <a href="#page-stats" class="block-heading" data-toggle="collapse">交易统计</a>
        <div id="page-stats" class="block-body collapse in">

            <div class="stat-widget-container">
                <div class="stat-widget">
                    <div class="stat-button">
                        <p class="title"><%=m_UserCount %></p>
                        <p class="detail">用户数量</p>
                    </div>
                </div>

                <div class="stat-widget">
                    <div class="stat-button">
                        <p class="title"><%=m_SaleCount %></p>
                        <p class="detail">出售信息</p>
                    </div>
                </div>

                <div class="stat-widget">
                    <div class="stat-button">
                        <p class="title"><%=m_PurchaseCount %></p>
                        <p class="detail">求购信息</p>
                    </div>
                </div>

                <div class="stat-widget">
                    <div class="stat-button">
                        <p class="title"><%=m_MessageCount %></p>
                        <p class="detail">留言数量</p>
                    </div>
                </div>

            </div>
        </div>
    </div>
</div>

<div class="row-fluid">
    <div class="block span6">
        <a href="#tablewidget" class="block-heading" data-toggle="collapse">出售信息<span class="label label-warning"></span></a>
        <div id="tablewidget" class="block-body collapse in">
            <%=m_TableData_Sale %>
            <p><a href="sale.aspx">更多...</a></p>
        </div>
    </div>
    <div class="block span6">
        <a href="#tablewidget2" class="block-heading" data-toggle="collapse">求购信息<span class="label label-warning"></span></a>
        <div id="tablewidget2" class="block-body collapse in">
            <%=m_TableData_Purchase %>
            <p><a href="purchase.aspx">更多...</a></p>
        </div>
    </div>

</div>
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
  </body>
</html>