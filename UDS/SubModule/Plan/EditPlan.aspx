<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPlan.aspx.cs" Inherits="UDS.SubModule.Plan.EditPlan" ValidateRequest="false" %>
 
 
 <%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

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

</head>
<body leftmargin="0" topmargin="0" ms_positioning="GridLayout" ForeColor="#006699" >
    <form id="EditField" method="post" enctype="multipart/form-data" runat="server"  >
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
                                        Width="53px"> 计划录入</asp:Label></font>
                            </td>
                            <td class="GbText" align="right" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff">
                                <font face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <font face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </font>&nbsp;</font>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
             <tr>
                           
                             <td   align="center">
                              
                            </td>
                      
                        </tr>
            <tr>
            <td><asp:DropDownList ID="ddlPlanObjectType" runat="server">
            <asp:ListItem Text="个人计划" Value="个人计划"></asp:ListItem>
            <asp:ListItem Text="部门计划" Value="部门计划"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlPlanPeriodType" runat="server" 
                    onselectedindexchanged="ddlPlanPeriodType_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="周计划" Value="周计划"></asp:ListItem>
                <asp:ListItem Text="月计划" Value="月计划"></asp:ListItem>
                <asp:ListItem Text="季计划" Value="季计划"></asp:ListItem>
               <%-- <asp:ListItem Text="半年计划" Value="半年计划"></asp:ListItem>--%>
                <asp:ListItem Text="年计划" Value="年计划"></asp:ListItem>
                </asp:DropDownList>
                
                   
                
                    <asp:TextBox ID="txtYear" runat="server" Width="65px"></asp:TextBox><asp:Label ID="lblYear" Text="年" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlWeek" runat="server" AutoPostBack="true" 
                    onselectedindexchanged="ddlWeek_SelectedIndexChanged">
                </asp:DropDownList>
                
                  <asp:DropDownList ID="ddlMonth" runat="server" 
                    onselectedindexchanged="ddlMonth_SelectedIndexChanged"  AutoPostBack="true">
                </asp:DropDownList>
                  <asp:DropDownList ID="ddlSeason" runat="server" 
                    onselectedindexchanged="ddlSeason_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
                
                  <asp:DropDownList ID="ddlHalfYear" runat="server"  AutoPostBack="true">
                </asp:DropDownList>
                
                  <asp:DropDownList ID="ddlYear" runat="server" 
                    onselectedindexchanged="ddlYear_SelectedIndexChanged"  AutoPostBack="true">
                </asp:DropDownList>
                 <asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                     <asp:Button ID="cmdOK" runat="server" Width="60px" CssClass="buttoncss" Text="保存"
                                    OnClick="cmdOK_Click"></asp:Button><font face="宋体">&nbsp; </font>
                                <%--<input class="buttoncss" style="width: 60px" onclick="javascript:location.replace('../UnitiveDocument/Index.aspx');"
                                    type="button" value="返回">--%>
                    
                    </td>
            </tr>
            <tr>
            <td><a href="#" onclick="hidePastPlan()"><%--过期计划查看其内容及附件，不可修改--%><asp:Label ID="lblPastPlanYear" runat="server" Text="Label"></asp:Label>年<asp:Label ID="lblPastPlanPeriod" runat="server" Text="Label"></asp:Label><asp:Label ID="lblPastPlanPeroidType" runat="server" Text="Label"></asp:Label>计划
                    </a></td>
            </tr>
            <tr>
            <td>
             <div id="past_plan_content" style="word-break: break-all; float: left; height: 100%; width: 100%; padding-top: 10px; padding-bottom:20px; display:none; border:1px;" runat="server"  >
                                </div>
            </td></tr>
            <tr><td></td></tr>
            <tr>
            <td>
            <%--本期总结，可录入修改删除--%>
            
                                <input id="Hidden1" type="hidden" name="SDCDoc" runat="server">
                                <asp:Label ID="lblConclusion" runat="server" Text="Label"></asp:Label>
                                <fckeditorv2:fckeditor id="FCKeditor2" runat="server" width="100%" height="200px">
                                                        </fckeditorv2:fckeditor> 
            </td></tr>
            <tr>
            <td>
           <%-- 总结附件,可上传录入修改删除--%></td></tr>
            <tr>
            <td><%--下期计划,可录入修改删除--%>
            
                                <input id="Hidden2" type="hidden" name="SDCDoc" runat="server">
                                <asp:Label ID="lblCurrentPlanYear" runat="server" Text="Label"></asp:Label>年<asp:Label ID="lblCurrentPlanPeroid" runat="server" Text="Label"></asp:Label><asp:Label ID="lblCurrentPlanPeroidType" runat="server" Text="Label"></asp:Label>计划
                                <fckeditorv2:fckeditor id="FCKeditor3" runat="server" width="100%" height="200px">
                                                        </fckeditorv2:fckeditor> 
            </td></tr>
            
            <tr>
            <td>
           <%-- 计划附件,可上传录入修改删除--%>
            </td></tr>
            <tr>
                <td>
                      <%-- <table border="1" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#cccccc"
							width="100%" id="AutoNumber2" height="1" class="GbText" align="left">
                        <tr >
                            <font face="宋体"></font>
                            <td align="left" width="10%">
                                &nbsp;</td>
                            <td   valign="bottom">
                              <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="(*)" ControlToValidate="txtBoardName"></asp:RequiredFieldValidator> 
                            </td>
                        </tr>
                         <tr>
                         <td valign="top" align="left">
                                &nbsp;</td>
                            <td  >
                              
                                <input id="SDCDoc" type="hidden" name="SDCDoc" runat="server">
                            </td>
                        </tr>
                       
                        <tr>
                           
                             <td colspan="2" align="center">
                                <asp:Button ID="cmdOK" runat="server" Width="60px" CssClass="buttoncss" Text="确定"
                                    OnClick="cmdOK_Click"></asp:Button><font face="宋体">&nbsp; </font>
                                <input class="buttoncss" style="width: 60px" onclick="javascript:location.href='BoardManagement.aspx'"
                                    type="button" value="返回">
                            </td>
                      
                        </tr> 
                    </table>--%>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <%--<script type="text/javascript">
    function Op()
        {
          var d=document.getElementById("ddlPlanPeriodType");
          
          d.selectedIndex=2;
          d.selectedIndex =1;
         
          
          alert(v);//输出值,这里可以改为根据值执行需要的代码
        }
        Op();
    </script> --%>
</body>
</html>
