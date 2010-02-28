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
         
        FCKeditor3.ToolbarSet.Collapse();  //���ع�����
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
    if (document.all) //�ж��Ƿ���IE����� 
    { 
        code = window.event.keyCode; 
    } 
    else 
    { 
        code = arguments.callee.caller.arguments[0].which; 
    } 
    var character = String.fromCharCode(code); 
     
    var txt=new RegExp("[ ,\\`,\\~,\\!,\\@,\#,\\$,\\%,\\^,\\+,\\*,\\&,\\\\,\\/,\\?,\\|,\\:,\\.,\\<,\\>,\\{,\\},\\(,\\),\\',\\;,\\=,\"]"); 
    //�����ַ��������ʽ 
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
                            <td class="GbText" align="right" width="60" background="../../../Images/treetopbg.jpg"
                                bgcolor="#e8f4ff">
                                <font color="#006699">
                                    <asp:Label ID="lblTitle" runat="server" ForeColor="#006699" Font-Names="����" Font-Size="X-Small"
                                        Width="53px"> �ƻ�����</asp:Label></font>
                            </td>
                            <td class="GbText" align="right" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff">
                                <font face="����">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <font face="����">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                    <%--<asp:DropDownList ID="ddlPlanObjectType" runat="server" 
                    onselectedindexchanged="ddlPlanObjectType_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Text="���˼ƻ�" Value="���˼ƻ�"></asp:ListItem>
            <asp:ListItem Text="���żƻ�" Value="���żƻ�"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlPlanPeriodType" runat="server" 
                    onselectedindexchanged="ddlPlanPeriodType_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="�ܼƻ�" Value="�ܼƻ�"></asp:ListItem>
                <asp:ListItem Text="�¼ƻ�" Value="�¼ƻ�"></asp:ListItem>
                <asp:ListItem Text="���ƻ�" Value="���ƻ�"></asp:ListItem>
                <asp:ListItem Text="����ƻ�" Value="����ƻ�"></asp:ListItem> 
                    <asp:ListItem Text="��ƻ�" Value="��ƻ�">
                    </asp:ListItem>
                    </asp:DropDownList>--%>
                    <tr>
                        <td>
                            <table width="100%" height="35" border="0" align="center" cellpadding="0" cellspacing="4"
                                bgcolor="" class="tableStyle">
                                <tr>
                                    <td align="left" nowrap>
                                        ������Χ��
                                    </td>
                                    <td nowrap>
                                        <%-- <select name="sel_Type">
                                            <option>ȫ��</option>
                                            <option value='1'>���˼ƻ�</option>
                                            <option value='2'>���żƻ�</option>
                                        </select>--%><asp:DropDownList ID="ddlPlanObjectType" runat="server">
                                            <asp:ListItem Text="ȫ��" Value=""></asp:ListItem>
                                            <asp:ListItem Text="���˼ƻ�" Value="���˼ƻ�"></asp:ListItem>
                                            <asp:ListItem Text="���żƻ�" Value="���żƻ�"></asp:ListItem>
                                        </asp:DropDownList>
                                        <%-- <select name="selectarea">
                                            <option selected>ȫ��</option>
                                            <option value="1">�ܼƻ�</option>
                                            <option value="0">�¼ƻ�</option>
                                            <option value="2">���ƻ�</option>
                                            <option value="4">����ƻ�</option>
                                            <option value="3">��ƻ�</option>
                                        </select>--%>
                                        <asp:DropDownList ID="ddlPlanPeriodType" runat="server">
                                            <asp:ListItem Text="ȫ��" Value=""></asp:ListItem>
                                            <asp:ListItem Text="�ܼƻ�" Value="�ܼƻ�"></asp:ListItem>
                                            <asp:ListItem Text="�¼ƻ�" Value="�¼ƻ�"></asp:ListItem>
                                            <asp:ListItem Text="���ƻ�" Value="���ƻ�"></asp:ListItem>
                                            <asp:ListItem Text="��ƻ�" Value="��ƻ�">
                                            </asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="70" height="30" align="right" nowrap>
                                        <%--  ��ʼ���ڣ�--%>
                                    </td>
                                    <td height="30">
                                        <%-- <input type="text" name="txtBeginDate" class="dateTimePicker" style="width: 108px"
                                            size="10">--%>
                                    </td>
                                    <td width="70" height="30" align="right" nowrap>
                                        <%--  ��ֹ���ڣ�--%>
                                    </td>
                                    <td height="30" align="center">
                                        <%--<input type="text" name="txtEndDate" class="dateTimePicker" style="width: 108px"
                                            size="10">--%>
                                    </td>
                                    <td>
                                        &nbsp; <a href="EditPlan.aspx">�ƻ�¼��</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" nowrap>
                                        �� �ݣ�
                                    </td>
                                    <td colspan="5">
                                        <%-- <input name="txt_content" style="width: 100%" maxlength="200">--%>
                                        <asp:TextBox runat="server" MaxLength="200" ID="txtContent" Width="819px"></asp:TextBox>
                                    </td>
                                    <td nowrap align="right">
                                        <asp:Button ID="btnSearch" runat="server" Text="��ѯ" OnClick="btnSearch_Click" />
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
            <tr><td>�����ܽ�</td></tr>
             <tr><td><div id="past_plan_content" style="word-break: break-all; float: left; height: 200px; width: 100%; padding-top: 10px; border:1px; padding-bottom:20px;   border:1px; background-color:White;" runat="server"  >
                                </div></td></tr>
              <tr><td>���ڼƻ�</td></tr>
              <tr><td>  <div id="current_plan_content" style="word-break: break-all; float: left; height: 200px; width: 100%; padding-top: 10px; border:1px; padding-bottom:20px;   border:1px; background-color:White;" runat="server"  >
                                </div></td></tr>
            </table>
         
    </td>
    <td valign="top" width="200px">
    <asp:ListBox runat="server" ID="lbxPlan" 
            onselectedindexchanged="lbxPlan_SelectedIndexChanged" Width="100%" 
            AutoPostBack="true" Height="460px">
   
    </asp:ListBox>
            <%--<asp:DataGrid ID="dgPlanList" runat="server" Width="100%" AutoGenerateColumns="False"
                AllowSorting="True" PageSize="20" AllowPaging="True" BorderColor="#93BEE2" BorderWidth="1px">
                <AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
                <ItemStyle Font-Size="X-Small"></ItemStyle>
                <Columns>
                    <asp:TemplateColumn HeaderText="�ƻ�">
                        <ItemTemplate>
                            <%#  DataBinder.Eval(Container.DataItem,"planname")%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                     <asp:TemplateColumn HeaderText="�ύʱ��">
                                            <ItemTemplate>
                                                <%#  DataBinder.Eval(Container.DataItem,"Realname")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn> 
                </Columns>
                <PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
            </asp:DataGrid>--%>
    </td>
     </tr></table>
    </form>
</body>
</html>