<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoardList.aspx.cs" Inherits="UDS.SubModule.UnitiveDocument.Board.BoardList" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>News Management</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">

    <script language="javascript">
			function delete_confirm(e) {
				if (event.srcElement.outerText == "删除")
				event.returnValue =confirm("您确认要删除?");
			}
			document.onclick=delete_confirm;		
    </script>

</head>
<body leftmargin="0" topmargin="0">
    <form id="Listview" method="post" runat="server">
    <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0"
        bordercolor="#111111">
        <tr>
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../../DataImages/MyTask.gif" width="16">
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width="60"
                height="30" align="left">
                &nbsp;<font color="#006699">公司公告</font>
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
                <font face="宋体">
                    <input class="redbuttoncss" style="width: 80px" onclick="location.href='../NewDesktop.aspx';"
                        type="button" value="返回">&nbsp;</font>
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
            <td style="line-height: 20px;">
                <asp:DataGrid ID="dgStyleListAdmin" runat="server" Width="100%" Font-Size="X-Small"
                    PageSize="15" OnPageIndexChanged="DataGrid_PageChanged" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataKeyField="Board_ID" BorderColor="#93BEE2" BorderStyle="None"
                    BorderWidth="1px" BackColor="White" CellPadding="3">
                    <SelectedItemStyle  ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
                    <AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
                    <ItemStyle Font-Size="X-Small" ForeColor="#003399" BackColor="White"></ItemStyle>
                    <HeaderStyle  HorizontalAlign="Left" ForeColor="White" VerticalAlign="Middle"
                        BackColor="#337FB2"></HeaderStyle>
                    <FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
                    <Columns>
                        <asp:TemplateColumn HeaderText="ID" Visible="false">
                            <HeaderStyle Width="0"></HeaderStyle>
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="公告标题" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <a href="ViewBoard.aspx?BoardID=<%# Eval("Board_ID") %> " target="_blank">
                                    <%# Eval("Board_Name")%></a>
                            </ItemTemplate>
                            <ItemStyle CssClass="tit2" />
                            <HeaderStyle Font-Size="14px" />
                            <HeaderStyle Font-Size="14px" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="发布日期">
                            <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                            <ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"add_date") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <FooterStyle Font-Size="X-Small"></FooterStyle>
                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle NextPageText="" HorizontalAlign="Right" BackColor="#E8F4FF" Mode="NumericPages">
                    </PagerStyle>
                </asp:DataGrid>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
<%--
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Board Management</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
</head>
<body ms_positioning="GridLayout" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>
        <table id="Table1" style="z-index: 105; left: 0px; position: absolute; top: 0px"
            cellspacing="0" cellpadding="1" width="100%" border="0">
            <tr>
                <td align="left" background="../../../Images/treetopbg.jpg">
                    <span style="font-size: 10pt">公司公告管理</span>
                </td>
                <td align="right" background="../../../Images/treetopbg.jpg">
                    <input class="redbuttoncss" style="width: 71px" onclick="location.href='../NewDesktop.aspx';"
                        type="button" value="返回">
                </td>
            </tr>
            <tr>
                <td valign="top" colspan="2">
                    <font face="宋体"></font><font face="宋体">
                        <asp:DataGrid ID="dgStyleListAdmin" runat="server" Width="100%" Font-Size="X-Small"
                            PageSize="15" OnPageIndexChanged="DataGrid_PageChanged" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataKeyField="Board_ID" BorderColor="#93BEE2" BorderStyle="None"
                            BorderWidth="1px" BackColor="White" CellPadding="3">
                            <SelectedItemStyle  ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
                            <AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
                            <ItemStyle Font-Size="X-Small" ForeColor="#003399" BackColor="White"></ItemStyle>
                            <HeaderStyle  HorizontalAlign="Left" ForeColor="White" VerticalAlign="Middle"
                                BackColor="#337FB2"></HeaderStyle>
                            <FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
                            <Columns>
                                <asp:TemplateColumn HeaderText="ID" Visible="false">
                                    <HeaderStyle Width="0"></HeaderStyle>
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="公告标题" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <a href="ViewBoard.aspx?BoardID=<%# Eval("Board_ID") %> " target="_blank">
                                            <%# Eval("Board_Name")%></a>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tit2" />
                                    <HeaderStyle Font-Size="14px" />
                                    <HeaderStyle Font-Size="14px" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="发布日期">
                                    <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                    <ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"add_date") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle Font-Size="X-Small"></FooterStyle>
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle NextPageText="" HorizontalAlign="Right" BackColor="#E8F4FF" Mode="NumericPages">
                            </PagerStyle>
                        </asp:DataGrid>
                    
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
--%>