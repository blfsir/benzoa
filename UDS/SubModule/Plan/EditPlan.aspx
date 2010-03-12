<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPlan.aspx.cs" Inherits="UDS.SubModule.Plan.EditPlan"
    ValidateRequest="false" %>

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
    var fEitor2, fEditor3;
    function FCKeditor_OnComplete(FCKeditor3)
    {
         
        FCKeditor3.ToolbarSet.Collapse();  //隐藏工具栏
        
         
          fEitor2 = FCKeditorAPI.GetInstance('FCKeditor2') ;
          
          fEitor3 = FCKeditorAPI.GetInstance('FCKeditor3') ;
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
    
     function check(){
     
        var content = editor.GetXHTML(true); //content就是编辑器的内容的html源码了
     
        if( content==""){
            alert("请输入内容!");
            return false;
        }
    }
    
    function setFckEditor2ReadOnly()
    {
    e2 = FCKeditorAPI.GetInstance('FCKeditor2') ;
      alert(e2.Name);
     setFCKeditorReadOnly(e2);
    }
    
     function setFckEditor3ReadOnly()
    {
      e3 = FCKeditorAPI.GetInstance('FCKeditor3') ;
      alert(e3.Name);
     setFCKeditorReadOnly(e3);
    }
    
//    function FCKeditor_OnComplete( editorInstance ){ 
//        editor = editorInstance;
////        var oEditor = FCKeditorAPI.GetInstance('FCKeditor2') ;

////        alert(oEditor.Name);
//    }
		/*设置FCKEDITOR为只读 */
        function setFCKeditorReadOnly(editor){
            try{
                editor.EditorDocument.body.contentEditable = false;
                editor.EditMode=FCK_EDITMODE_SOURCE;
                editor.ToolbarSet.RefreshModeState();
                editor.EditMode=FCK_EDITMODE_WYSIWYG;
                editor.ToolbarSet.RefreshModeState();
                editor.EditorWindow.parent.document.getElementById('xExpanded').style.display = 'none';
                editor.EditorWindow.parent.document.getElementById('xCollapsed').style.display = 'none';
                editor.EditorWindow.blur();
            }
            catch(e){
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
<%--<body leftmargin="0" topmargin="0" ms_positioning="GridLayout" forecolor="#006699">
    <form id="EditField" method="post" enctype="multipart/form-data" runat="server">
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
                <td align="center">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlPlanObjectType" runat="server" OnSelectedIndexChanged="ddlPlanObjectType_SelectedIndexChanged"
                        AutoPostBack="true">
                        <asp:ListItem Text="个人计划" Value="个人计划"></asp:ListItem>
                        <asp:ListItem Text="部门计划" Value="部门计划"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlPlanPeriodType" runat="server" OnSelectedIndexChanged="ddlPlanPeriodType_SelectedIndexChanged"
                        AutoPostBack="true">
                        <asp:ListItem Text="周计划" Value="周计划"></asp:ListItem>
                        <asp:ListItem Text="月计划" Value="月计划"></asp:ListItem>
                        <asp:ListItem Text="季计划" Value="季计划"></asp:ListItem>
                 
                        <asp:ListItem Text="年计划" Value="年计划"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtYear" runat="server" Width="65px"></asp:TextBox><asp:Label ID="lblYear"
                        Text="年" runat="server"></asp:Label>
                    <asp:DropDownList ID="ddlWeek" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlWeek_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlMonth" runat="server" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlSeason" runat="server" OnSelectedIndexChanged="ddlSeason_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlHalfYear" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlYear" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label>
                    <asp:TextBox ID="txtBeginDate" runat="server" Width="0px"></asp:TextBox><asp:TextBox
                        ID="txtEndDate" runat="server" Width="0px"></asp:TextBox><asp:TextBox ID="txtPastBeginDate"
                            runat="server" Width="0px"></asp:TextBox><asp:TextBox ID="txtPastEndDate" runat="server"
                                Width="0px"></asp:TextBox>
                    <asp:Button ID="cmdOK" runat="server" Width="60px" CssClass="buttoncss" Style="z-index: 118;
                        position: absolute; right: 10px; top: 36px" Text="保存" OnClick="cmdOK_Click">
                    </asp:Button>
                    <font face="宋体">&nbsp; </font>
                    
                </td>
            </tr>
            <tr>
                <td>
                    <a href="#" onclick="hidePastPlan()">
                        <asp:Label ID="lblPastPlanYear" runat="server" Text="Label"></asp:Label>年<asp:Label
                            ID="lblPastPlanPeriod" runat="server" Text="Label"></asp:Label><asp:Label ID="lblPastPlanPeroidType"
                                runat="server" Text="Label"></asp:Label>计划 </a>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="past_plan_content" style="word-break: break-all; float: left; height: 100%;
                        width: 100%; padding-top: 10px; padding-bottom: 20px; display: none; border: 1px;"
                        runat="server">
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                   
                    <input id="Hidden1" type="hidden" name="SDCDoc" runat="server">
                    <asp:Label ID="lblConclusion" runat="server" Text="Label"></asp:Label>
                    <FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server" Width="100%" Height="200px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td>
                     
                </td>
            </tr>
            <tr>
                <td>
                   
                    <input id="Hidden2" type="hidden" name="SDCDoc" runat="server">
                    <asp:Label ID="lblCurrentPlanYear" runat="server" Text="Label"></asp:Label>年<asp:Label
                        ID="lblCurrentPlanPeroid" runat="server" Text="Label"></asp:Label><asp:Label ID="lblCurrentPlanPeroidType"
                            runat="server" Text="Label"></asp:Label>计划
                    <FCKeditorV2:FCKeditor ID="FCKeditor3" runat="server" Width="100%" Height="200px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td>
                  
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
    </form>
     
</body>--%>
<body leftmargin="0" topmargin="0">
    <form id="Listview" method="post" runat="server">
    <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0"
        style="table-layout: fixed" bordercolor="#111111">
        <tr height="30">
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/myDoc2.gif" width="16">
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width="60"
                align="center">
                <font color="#006699">计划录入</font>
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
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
                <asp:DropDownList ID="ddlPlanObjectType" runat="server" OnSelectedIndexChanged="ddlPlanObjectType_SelectedIndexChanged"
                    AutoPostBack="true">
                    <asp:ListItem Text="个人计划" Value="个人计划"></asp:ListItem>
                    <asp:ListItem Text="部门计划" Value="部门计划"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlPlanPeriodType" runat="server" OnSelectedIndexChanged="ddlPlanPeriodType_SelectedIndexChanged"
                    AutoPostBack="true">
                    <asp:ListItem Text="周计划" Value="周计划"></asp:ListItem>
                    <asp:ListItem Text="月计划" Value="月计划"></asp:ListItem>
                    <asp:ListItem Text="季计划" Value="季计划"></asp:ListItem>
                    <asp:ListItem Text="年计划" Value="年计划"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtYear" runat="server" Width="65px"></asp:TextBox><asp:Label ID="lblYear"
                    Text="年" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlWeek" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlWeek_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlMonth" runat="server" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlSeason" runat="server" OnSelectedIndexChanged="ddlSeason_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlHalfYear" runat="server" AutoPostBack="true">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlYear" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
                <asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="txtBeginDate" runat="server" Width="0px"></asp:TextBox><asp:TextBox
                    ID="txtEndDate" runat="server" Width="0px"></asp:TextBox><asp:TextBox ID="txtPastBeginDate"
                        runat="server" Width="0px"></asp:TextBox><asp:TextBox ID="txtPastEndDate" runat="server"
                            Width="0px"></asp:TextBox>
                <asp:Button ID="cmdOK" runat="server" Width="80px" CssClass="redbuttoncss" Style="z-index: 118;
                    position: absolute; right: 10px; top: 36px" Text="保存" OnClick="cmdOK_Click">
                </asp:Button>
                <font face="宋体">&nbsp; </font>
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td>
                <a href="#" onclick="hidePastPlan()">
                    <asp:Label ID="lblPastPlanYear" runat="server" Text="Label"></asp:Label>年<asp:Label
                        ID="lblPastPlanPeriod" runat="server" Text="Label"></asp:Label><asp:Label ID="lblPastPlanPeroidType"
                            runat="server" Text="Label"></asp:Label>计划 </a>
            </td>
        </tr>
        <tr>
            <td>
                <div id="past_plan_content" style="word-break: break-all; float: left; height: 100%;
                    width: 100%; padding-top: 10px; padding-bottom: 20px; display: none; border: 1px;"
                    runat="server">
                </div>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <input id="Hidden1" type="hidden" name="SDCDoc" runat="server">
                <asp:Label ID="lblConclusion" runat="server" Text="Label"></asp:Label>
                <FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server" Width="100%" Height="200px">
                </FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <input id="Hidden2" type="hidden" name="SDCDoc" runat="server">
                <asp:Label ID="lblCurrentPlanYear" runat="server" Text="Label"></asp:Label>年<asp:Label
                    ID="lblCurrentPlanPeroid" runat="server" Text="Label"></asp:Label><asp:Label ID="lblCurrentPlanPeroidType"
                        runat="server" Text="Label"></asp:Label>计划
                <FCKeditorV2:FCKeditor ID="FCKeditor3" runat="server" Width="100%" Height="200px">
                </FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
