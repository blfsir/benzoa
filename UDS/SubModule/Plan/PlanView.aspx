<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanView.aspx.cs" Inherits="UDS.SubModule.Plan.PlanView" %>

        

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Edit Plan</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">

    <script type="text/javascript">
     
    function TextValidate() 
{ 
    var code; 
    var character; 
    var err_msg = "Text can not contain SPACES or any of these special characters  other than underscore (_) and hyphen (-)."; 
    if (document.all) //判断是否是IE浏览器 
    { 
        code = window.event.keyCode; 
    } 
    else 
    { 
        code = arguments.callee.caller.arguments[0].which; 
    } 
    var character = String.fromCharCode(code); 
     
    var txt=new RegExp("[ ,\\`,\\~,\\!,\\@,\#,\\$,\\%,\\^,\\+,\\*,\\&,\\\\,\\/,\\?,\\|,\\:,\\.,\\<,\\>,\\{,\\},\\(,\\),\\',\\;,\\=,\"]"); 
    //特殊字符正则表达式 
    if (txt.test(character)) 
    { 
        alert("User Name can not contain SPACES or any of these special characters:\n  , ` ~ ! @ # $ % ^ + & * \\ / ? | : . < > {} () [] \" "); 
        if (document.all) 
        { 
            window.event.returnValue = false; 
        } 
        else 
        { 
            arguments.callee.caller.arguments[0].preventDefault(); 
        } 
    } 
}
    </script>

    <style type="text/css">
        .style1
        {
            width: 590px;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0" ms_positioning="GridLayout" forecolor="#006699">
    <form id="EditField" method="post" enctype="multipart/form-data" runat="server">
     <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0"
        bordercolor="#111111">
        <tr>
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/MyTask.gif" width="16">
            </td>
            <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width="80"
                height="30" align="left">
                &nbsp;<font color="#006699">计划查看</font>
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
                <font face="宋体">
                   <input type="button" value="返回" class="redButtonCss" style="width: 80px;" onclick="javacript:location.href='PlanManage.aspx'" />
                    &nbsp;</font>
            </td>
        </tr>
    </table>
    
    <table width="98%" border="0" align="center" cellpadding="2" cellspacing="1" bgcolor="#E8F4FF">
        <tr bgcolor="#E8F4FF">
            <td align="right" valign="top">
                <table width="100%" border="0" align="center" cellpadding="2" cellspacing="1" bgcolor="#E8F4FF">
                    <tr>
                        <td style="background-color: #E8F4FF">
                            上期总结
                        </td>
                    </tr>
                    <tr>
                        <td>
                           <div id="past_plan_content" style="word-break: break-all; float: left; height: 200px;
                                width: 100%; border: 1px; border: 1px; padding: 15px; background-color: White;"
                                runat="server">
                            </div> 
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #E8F4FF">
                            本期计划
                        </td>
                    </tr>
                    <tr>
                        <td>   <div id="current_plan_content" style="word-break: break-all; float: left; height: 200px;
                                width: 100%; padding: 15px; border: 1px; background-color: White;" runat="server">
                            </div> 
                        </td>
                    </tr>
                </table>
            </td>
             
        </tr>
    </table>
    </form>
</body>
</html>
