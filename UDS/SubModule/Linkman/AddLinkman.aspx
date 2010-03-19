<%@ Page Language="c#" CodeBehind="AddLinkman.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Linkman.AddLinkman" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>添加联系人</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
</head>
<body ms_positioning="GridLayout" topmargin="0" leftmargin="0">
    <form id="AddLinkman" method="post" runat="server">
    <table bordercolor="#111111" height="1" cellspacing="0" cellpadding="0" width="100%"
        border="0">
        <tr>
            <td width="24" height="30" align="center" background="../../Images/treetopbg.jpg"
                bgcolor="#c0d9e6" class="GbText">
                <font color="#003366" size="3">
                    <img height="16" src="../../Images/icon/057.GIF" width="16"></font>
            </td>
            <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6" width="70"
                align="center">
                我的联系人
            </td>
            <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6" align="right">
                选择联系人类别
                <asp:DropDownList ID="ddl_LinkmanType" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="staff">公司员工</asp:ListItem>
                    <asp:ListItem Value="client">客户联系人</asp:ListItem>
                    <asp:ListItem Value="custom">自定义</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btn_Back" runat="server" Text="返 回" CssClass="redbuttoncss" CausesValidation="False">
                </asp:Button>
                <asp:Button ID="btn_AddList" runat="server" Text="添 加" CssClass="redbuttoncss"></asp:Button>&nbsp;
            </td>
        </tr>
        <tr>
            <td height="10" colspan="3">
            </td>
            <tr>
            </tr>
    </table>
    <font face="宋体">
        <table style="border-collapse: collapse" bordercolor="#93bee2" cellspacing="0" cellpadding="0"
            width="100%" align="center" border="0" class="gbtext">
           <%-- <tr>
                <td width="100%" colspan="3">
                    <table class="gbtext" id="Table6" cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td align="center" width="90" background="../../images/maillistbutton2.gif" height="24"
                                class="Newbutton">
                                &nbsp;添加联系人
                            </td>
                            <td align="right" style="width: 211px">
                                &nbsp;&nbsp;&nbsp;
                            </td>
                            <td align="right">
                                &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>--%>
            <tr>
                <td align="right" width="100%" colspan="3">
                    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" id="tbl_Select"
                        runat="server">
                        <tr>
                            <td width="100%" colspan="2">
                                <asp:DataGrid ID="dgrd_List" runat="server" Width="100%" AutoGenerateColumns="False"
                                    AllowPaging="True" Visible="False" BorderColor="#93BEE2" BorderWidth="1px" CellPadding="3"
                                    PageSize="15">
                                    <AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
                                    <ItemStyle Font-Size="X-Small"></ItemStyle>
                                    <HeaderStyle Font-Size="X-Small" ForeColor="#FFFFFF" BackColor="#337FB2"></HeaderStyle>
                                    <Columns>
                                        <asp:TemplateColumn>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="真实姓名">
                                            <ItemTemplate>
                                                <%#  DataBinder.Eval(Container.DataItem,"Realname")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="手机">
                                            <ItemTemplate>
                                                <%#  DataBinder.Eval(Container.DataItem,"Mobile")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="年龄">
                                            <ItemTemplate>
                                                <%#  DataBinder.Eval(Container.DataItem,"Age")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="性别">
                                            <ItemTemplate>
                                                <%#  DataBinder.Eval(Container.DataItem,"SexName")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Email">
                                            <ItemTemplate>
                                                <%#  DataBinder.Eval(Container.DataItem,"Email")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="所在职位">
                                            <ItemTemplate>
                                                <%#  DataBinder.Eval(Container.DataItem,"Position_Name")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="注册日期">
                                            <ItemTemplate>
                                                <%#  DataBinder.Eval(Container.DataItem,"RQ")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Right" BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
                                </asp:DataGrid><asp:DataGrid ID="dgrd_Linkman" runat="server" Width="100%" AutoGenerateColumns="False"
                                    AllowPaging="True" Visible="False" BorderColor="#93BEE2" BorderWidth="1px" CellPadding="3">
                                    <AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
                                    <ItemStyle Font-Size="X-Small"></ItemStyle>
                                    <HeaderStyle Font-Size="X-Small" ForeColor="#FFFFFF" BackColor="#337FB2"></HeaderStyle>
                                    <Columns>
                                        <asp:TemplateColumn>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="Checkbox1"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="姓名">
                                            <ItemTemplate>
                                                <%#  DataBinder.Eval(Container.DataItem,"Name")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="手机">
                                            <ItemTemplate>
                                                <%#  DataBinder.Eval(Container.DataItem,"Mobile")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="电话">
                                            <ItemTemplate>
                                                <%#  DataBinder.Eval(Container.DataItem,"Telephone")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Email">
                                            <ItemTemplate>
                                                <%#  DataBinder.Eval(Container.DataItem,"Email")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="单位">
                                            <ItemTemplate>
                                                <%#  DataBinder.Eval(Container.DataItem,"UnitName")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="职务">
                                            <ItemTemplate>
                                                <%#  DataBinder.Eval(Container.DataItem,"Position")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="家庭住址">
                                            <ItemTemplate>
                                                <%#  DataBinder.Eval(Container.DataItem,"Address")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Right" BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
                                </asp:DataGrid>
                            </td>
                        </tr>
                        <tr>
                        </tr>
                    </table>
                    <table id="tbl_Custom" style="border-collapse: collapse" bordercolor="#93bee2" cellspacing="0"
                        cellpadding="0" width="98%" align="center" border="1" class="gbtext" runat="server">
                        <tr>
                            <td style="width: 73px" height="24" bgcolor="#e8f4ff">
                                &nbsp;姓名
                            </td>
                            <td height="24" style="width: 82px">
                                &nbsp;<asp:TextBox ID="tbx_Name" runat="server" CssClass="inputcss"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="不能为空"
                                    ControlToValidate="tbx_Name" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td height="24" bgcolor="#e8f4ff">
                                &nbsp;性别
                            </td>
                            <td height="24" style="width: 128px">
                                &nbsp;<select id="ddl_Gender" name="Select1" runat="server">
                                    <option value="1" selected>男</option>
                                    <option value="0">女</option>
                                </select>
                            </td>
                            <td height="24" bgcolor="#e8f4ff">
                                &nbsp;年&nbsp;&nbsp;&nbsp; 龄
                            </td>
                            <td height="24">
                                &nbsp;<asp:TextBox ID="tbx_Age" runat="server" CssClass="inputcss" Width="56px"></asp:TextBox>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" Display="Dynamic" ControlToValidate="tbx_Age"
                                    ErrorMessage="年龄错误" MinimumValue="1" MaximumValue="200" Type="Integer"></asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 73px" height="24" bgcolor="#e8f4ff">
                                &nbsp;单位地址
                            </td>
                            <td height="24" style="width: 82px">
                                &nbsp;<asp:TextBox ID="tbx_UnitAddress" runat="server" CssClass="inputcss"></asp:TextBox>
                            </td>
                            <td height="24" bgcolor="#e8f4ff">
                                &nbsp;单位电话
                            </td>
                            <td height="24" style="width: 128px">
                                &nbsp;<asp:TextBox ID="tbx_UnitTelephone" runat="server" CssClass="inputcss"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="输入数字"
                                    ControlToValidate="tbx_UnitTelephone" Display="Dynamic" ValidationExpression="\d*"></asp:RegularExpressionValidator>
                            </td>
                            <td align="left" height="24" bgcolor="#e8f4ff">
                                &nbsp;单位邮编
                            </td>
                            <td height="24">
                                &nbsp;<asp:TextBox ID="tbx_UnitZip" runat="server" CssClass="inputcss" Width="57px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="邮编错误"
                                    ControlToValidate="tbx_UnitZip" Display="Dynamic" ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 73px" height="24" bgcolor="#e8f4ff">
                                &nbsp;家庭地址
                            </td>
                            <td height="24" style="width: 82px">
                                &nbsp;<asp:TextBox ID="tbx_FamilyAddress" runat="server" CssClass="inputcss"></asp:TextBox>
                            </td>
                            <td height="24" bgcolor="#e8f4ff">
                                &nbsp;家庭电话
                            </td>
                            <td height="24" style="width: 128px">
                                &nbsp;<asp:TextBox ID="tbx_FamilyTelephone" runat="server" CssClass="inputcss"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="输入数字"
                                    ControlToValidate="tbx_FamilyTelephone" Display="Dynamic" ValidationExpression="\d*"></asp:RegularExpressionValidator>
                            </td>
                            <td height="24" bgcolor="#e8f4ff">
                                &nbsp;家庭邮编
                            </td>
                            <td height="24">
                                &nbsp;<asp:TextBox ID="tbx_FamilyZip" runat="server" CssClass="inputcss" Width="59px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="邮编错误"
                                    ControlToValidate="tbx_FamilyZip" Display="Dynamic" ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 73px" height="24" bgcolor="#e8f4ff">
                                &nbsp;手机
                            </td>
                            <td height="24" style="width: 82px">
                                &nbsp;<asp:TextBox ID="tbx_Mobile" runat="server" CssClass="inputcss"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="输入数字"
                                    ControlToValidate="tbx_Mobile" ValidationExpression="\d*" Display="Dynamic"></asp:RegularExpressionValidator>
                            </td>
                            <td height="24" bgcolor="#e8f4ff">
                                &nbsp;E-Mail
                            </td>
                            <td height="24" style="width: 128px">
                                &nbsp;<asp:TextBox ID="tbx_Email" runat="server" CssClass="inputcss"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="格式错误"
                                    Display="Dynamic" ControlToValidate="tbx_Email" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </td>
                            <td height="24">
                            </td>
                            <td height="24">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 73px" height="24" bgcolor="#e8f4ff">
                                &nbsp;类别
                            </td>
                            <td colspan="5" height="24">
                                <asp:DataList ID="dlt_Type" runat="server" RepeatDirection="Horizontal" RepeatColumns="10"
                                    HorizontalAlign="Left" Font-Size="X-Small">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Type") %>'
                                            EnableViewState="True"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 73px; height: 99px" valign="top" align="left" bgcolor="#e8f4ff">
                                &nbsp;备注
                            </td>
                            <td style="height: 99px" valign="top" colspan="5">
                                <asp:TextBox ID="tbx_Memo" runat="server" Width="581px" Height="95px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="6" height="40">
                                <asp:Button ID="btn_OK" runat="server" Text=" 确 认 " CssClass="buttoncss"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </font>
    </form>
</body>
</html>
