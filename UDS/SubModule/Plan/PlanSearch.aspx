<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanSearch.aspx.cs" Inherits="UDS.SubModule.Plan.PlanSearch" %>

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
    function FCKeditor_OnComplete(FCKeditor3)
    {
         
        FCKeditor3.ToolbarSet.Collapse();  //隐藏工具栏
    }
    
    function hidePastPlan()
    {
       var display=document.getElementById("past_plan_content").style.display;
       if(display =="none")
       {
       document.getElementById("past_plan_content").style.display=""
       }
       else
       {
        document.getElementById("past_plan_content").style.display="none"
       }
    }

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
    <input type="hidden" name="hid_content">
    <div>
        <table class="gbtext" id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td valign="top" height="38">
                    <table bordercolor="#111111" height="1" cellspacing="0" cellpadding="0" width="100%"
                        border="0">
                        <tr height="30">
                            <td class="GbText" style="width: 23px" align="right" width="23" background="../../../Images/treetopbg.jpg"
                                bgcolor="#c0d9e6">
                                <font color="#003366" size="3">
                                    <img height="16" src="../../../DataImages/DocFlow.gif" width="16"></font>
                            </td>
                            <td class="GbText" align="left" width="60" background="../../../Images/treetopbg.jpg"
                                bgcolor="#e8f4ff">
                                <font color="#006699">
                                    <asp:Label ID="lblTitle" runat="server" ForeColor="#006699" Width="53px"> 计划查询</asp:Label></font>
                            </td>
                            <td class="GbText" align="right" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff">
                                <asp:Button ID="btnSearch" runat="server" Width="80px" Text="查询" class="redButtonCss"
                                    OnClick="btnSearch_Click" />
                                <input type="button" value="返回" class="redButtonCss" style="width: 80px;" onclick="javacript:location.href='PlanManage.aspx'" />&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                </td>
            </tr>
            <tr>
                <td>
                    <table id="Table2" bordercolor="#93bee2" cellspacing="0" cellpadding="0" width="98%"
                        border="1" style="border-collapse: collapse" align="center" class="GbText" style="background-color: #e8f4ff">
                        <tr>
                            <td colspan="2">
                                <table id="Table3" bordercolor="#93bee2" cellspacing="0" cellpadding="0" width="98%"
                                    border="0" style="border-collapse: collapse" align="center" class="GbText" style="background-color: #e8f4ff">
                                    <tr>
                                        <td style="width: 104px;" height="24">
                                            <asp:Label ID="Label2" runat="server" Font-Names="宋体">&nbsp;搜索内容：</asp:Label>
                                        </td>
                                        <td height="24" class="style1" style="padding: 5">
                                            <asp:TextBox runat="server" MaxLength="200" ID="txtContent" Width="300px"></asp:TextBox>
                                        </td>
                                        <td style="width: 104px;" height="24">
                                            <asp:Label ID="Label1" runat="server" Font-Names="宋体">&nbsp;搜索范围：</asp:Label>
                                        </td>
                                        <td height="24">
                                            <asp:DropDownList ID="ddlPlanObjectType" runat="server">
                                                <asp:ListItem Text="全部" Value=""></asp:ListItem>
                                                <asp:ListItem Text="个人计划" Value="个人计划"></asp:ListItem>
                                                <asp:ListItem Text="部门计划" Value="部门计划"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlPlanPeriodType" runat="server">
                                                <asp:ListItem Text="全部" Value=""></asp:ListItem>
                                                <asp:ListItem Text="周计划" Value="周计划"></asp:ListItem>
                                                <asp:ListItem Text="月计划" Value="月计划"></asp:ListItem>
                                                <asp:ListItem Text="季计划" Value="季计划"></asp:ListItem>
                                                <asp:ListItem Text="年计划" Value="年计划">
                                                </asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
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
                                        <td>
                                            <div id="current_plan_content" style="word-break: break-all; float: left; height: 200px;
                                                width: 100%; padding: 15px; border: 1px; background-color: White;" runat="server">
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top" width="15%">
                                <asp:ListBox runat="server" ID="lbxPlan" OnSelectedIndexChanged="lbxPlan_SelectedIndexChanged"
                                    Width="100%" AutoPostBack="true" Height="460px" BackColor="#ffffff"></asp:ListBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
