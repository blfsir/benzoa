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
<%--<body leftmargin="0" topmargin="0" ms_positioning="GridLayout" forecolor="#006699">
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
                            <td class="GbText" align="right" width="60" background="../../../Images/treetopbg.jpg"
                                bgcolor="#e8f4ff">
                                <font color="#006699">
                                    <asp:Label ID="lblTitle" runat="server" ForeColor="#006699" Font-Names="宋体" Font-Size="X-Small"
                                        Width="53px"> 计划管理</asp:Label></font>
                            </td>
                            <td class="GbText" align="right" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff">
                                <input type="button" value="计划录入" class="buttoncss" style="width: 80px;" onclick="javacript:location.href='EditPlan.aspx'" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
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
                    <tr>
                        <td>
                            <table id="Table2" bordercolor="#93bee2" cellspacing="0" cellpadding="0" width="100%"
                                border="1" style="border-collapse: collapse" class="GbText">
                                <tr>
                                    <td style="width: 104px" height="24">
                                        <font color="#006699">
                                            <asp:Label ID="Label2" runat="server" ForeColor="#006699" Font-Names="宋体" Font-Size="X-Small"
                                                Width="53px">内 容：</asp:Label></font>
                                    </td>
                                    <td height="24" class="style1">
                                        <asp:TextBox runat="server" MaxLength="200" ID="txtContent" Width="600px"></asp:TextBox>
                                    </td>
                                    <td height="24">
                                        <font color="#006699">
                                            <asp:Label ID="Label1" runat="server" ForeColor="#006699" Font-Names="宋体" Font-Size="X-Small"
                                                Width="80">  搜索范围：</asp:Label></font>
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
                                    <td height="24" style="width: 91px">
                                        <asp:Button ID="btnSearch" runat="server" Text="查询" class="buttoncss" OnClick="btnSearch_Click" />
                                    </td>
                                    <td height="24">
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" height="35" border="0" align="center" cellpadding="0" cellspacing="4"
                                bgcolor="" class="tableStyle">
                                <tr>
                                    <td align="left" nowrap>
                                    </td>
                                    <td colspan="5">
                                    </td>
                                    <td nowrap align="right">
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
    </div>
    <table width="100%" border="0" align="center" cellpadding="2" cellspacing="1" bgcolor="#dddddd">
        <tr bgcolor="#F3F3F3">
            <td align="right" valign="top">
                <table width="100%" border="0" align="center" cellpadding="2" cellspacing="1" bgcolor="#dddddd">
                    <tr>
                        <td>
                            上期总结
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="past_plan_content" style="word-break: break-all; float: left; height: 200px;
                                width: 100%; padding-top: 10px; border: 1px; padding-bottom: 20px; border: 1px;
                                background-color: White;" runat="server">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            本期计划
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="current_plan_content" style="word-break: break-all; float: left; height: 200px;
                                width: 100%; padding-top: 10px; border: 1px; padding-bottom: 20px; border: 1px;
                                background-color: White;" runat="server">
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" width="200px">
                <asp:ListBox runat="server" ID="lbxPlan" OnSelectedIndexChanged="lbxPlan_SelectedIndexChanged"
                    Width="100%" AutoPostBack="true" Height="460px"></asp:ListBox>
            </td>
        </tr>
    </table>
    </form>
</body>--%>
<body leftmargin="0" topmargin="0">
    <form id="Listview" method="post" runat="server">
    <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0" style="table-layout:fixed"
        bordercolor="#111111">
        <tr height="30">
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/myDoc2.gif" width="16">
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width="120"
                align="center">
                <font color="#006699">计划总结</font>
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
                <font face="宋体">
                    <input type="button" value="计划录入" class="redbuttoncss" style="width: 80px;" onclick="javacript:location.href='EditPlan.aspx'" />&nbsp;</font>
            </td>
        </tr>
    </table>
    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" id="Table1">
        <tr>
            <td>
                <table class="gbtext" id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="10" colspan="3" align="center">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table id="Table3" bordercolor="#93bee2" cellspacing="0" cellpadding="0" width="100%"
                    border="1" style="border-collapse: collapse" class="GbText">
                    <tr>
                        <td style="width: 104px" height="24">
                            <font color="#006699">
                                <asp:Label ID="Label2" runat="server" ForeColor="#006699" Font-Names="宋体" Font-Size="X-Small"
                                    Width="53px">内 容：</asp:Label></font>
                        </td>
                        <td height="24" class="style1">
                            <asp:TextBox runat="server" MaxLength="200" ID="txtContent" Width="600px"></asp:TextBox>
                        </td>
                        <td height="24">
                            <font color="#006699">
                                <asp:Label ID="Label1" runat="server" ForeColor="#006699" Font-Names="宋体" Font-Size="X-Small"
                                    Width="80">  搜索范围：</asp:Label></font>
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
                        <td height="24" style="width: 91px" align="right">
                            <asp:Button ID="btnSearch" runat="server" Text="查询"   style="width: 80px;" class="redbuttoncss" OnClick="btnSearch_Click" />&nbsp;
                        </td>
                         
                    </tr>
                    <tr>
                    <td colspan="5">
                    
                    </td>
                    </tr>
                </table>
                
            </td>
        </tr>
        <tr>
            <td style="line-height: 20px;">
                <table width="100%" border="0" align="center" cellpadding="2" cellspacing="1" >
                    <tr bgcolor="#F3F3F3">
                        <td align="right" valign="top">
                            <table width="100%" border="0" align="center" cellpadding="2" cellspacing="1" >
                                <tr>
                                    <td>
                                        上期总结
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="past_plan_content" style="word-break: break-all; float: left; height: 200px;
                                            width: 100%; padding-top: 10px; border: 1px; padding-bottom: 20px; border: 1px;
                                            background-color: White;OVERFLOW:scroll" runat="server">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        本期计划
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="current_plan_content" style="word-break: break-all; float: left; height: 200px;
                                            width: 100%; padding-top: 10px; border: 1px; padding-bottom: 20px; border: 1px;
                                            background-color: White;OVERFLOW:scroll" runat="server">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" width="200px">
                            <asp:ListBox runat="server" ID="lbxPlan" OnSelectedIndexChanged="lbxPlan_SelectedIndexChanged"
                                Width="100%" AutoPostBack="true" Height="460px"></asp:ListBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
