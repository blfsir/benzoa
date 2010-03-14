<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetStateManage.aspx.cs" Inherits="UDS.SubModule.Asset.AssetStateManage" %>




<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>ManageAssetState</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

   <script language="javascript">
			function delete_confirm(e) {
				if (event.srcElement.outerText == "删除")
				event.returnValue =confirm("您确认要删除?");
			}
			document.onclick=delete_confirm;		
    </script>

    <link href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
</head>
<%--<body ms_positioning="GridLayout" leftmargin="0" topmargin="0">
    <form id="ManageStaff" method="post" runat="server">
    <font face="宋体">
        <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td valign="top">
                    <table bordercolor="#111111" height="1" cellspacing="0" cellpadding="0" width="100%"
                        border="0">
                        <tr height="30">
                            <td class="GbText" width="160" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                                align="right">
                                <img height="16" src="../../DataImages/staff.gif" width="16" /><font color="#006699">设备使用状态管理</font>
                            </td>
                            <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width="60"
                                align="right">
                                &nbsp;
                            </td>
                            <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right"
                                width="85%">
                              
                                <input type="button" value="新增使用状态" class="redbuttoncss" style="width: 80px;" onclick="javacript:location.href='NewAssetState.aspx'" />
                                 <input type="button" value="返回" class="redbuttoncss" style="width: 80px;" onclick="javacript:location.href='AssetMange.aspx'" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DataGrid ID="dgAssetType" runat="server" BorderColor="#93BEE2" BorderStyle="None"
                        BorderWidth="1px" BackColor="White" CellPadding="3" PageSize="15" AllowPaging="True"
                        AutoGenerateColumns="False" DataKeyField="ID" Width="100%" 
                        AllowSorting="True" ondeletecommand="dbStaffList_DeleteCommand" 
                        onpageindexchanged="dbStaffList_PageIndexChanged">
                        <SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
                        <AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
                        <ItemStyle Font-Size="X-Small" Wrap="false"></ItemStyle>
                        <HeaderStyle Font-Size="X-Small" Wrap="false" Font-Bold="True" ForeColor="White"
                            BackColor="#337FB2"></HeaderStyle>
                        <FooterStyle Font-Size="X-Small" HorizontalAlign="Right" BackColor="#E8F4FF"></FooterStyle>
                        <Columns>
                            <asp:TemplateColumn HeaderText="ID">
                                <HeaderStyle Width="20px"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkStaff_ID" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:HyperLinkColumn Text="使用状态" DataNavigateUrlField="ID" DataNavigateUrlFormatString="NewAssetState.aspx?StateID={0}"
                                DataTextField="Name" HeaderText="使用状态" SortExpression="Name">
                                <HeaderStyle Wrap="false"></HeaderStyle>
                                <ItemStyle Wrap="false" />
                            </asp:HyperLinkColumn>
                            <asp:BoundColumn DataField="Remark" SortExpression="Remark" HeaderText="备注">
                                <HeaderStyle Wrap="false"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:ButtonColumn Text="删除" HeaderText="删除" CommandName="Delete">
                                <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:ButtonColumn>
                        </Columns>
                        <PagerStyle Font-Size="X-Small" HorizontalAlign="left" BackColor="#E8F4FF" Mode="NumericPages">
                        </PagerStyle>
                    </asp:DataGrid>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>
        </table>
    </font>
    </form>
</body>--%>
<body leftmargin="0" topmargin="0">
    <form id="Listview" method="post" runat="server">
    <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0"
        bordercolor="#111111">
        <tr height="30">
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/t5.jpg" width="16">
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width="120"
                align="left">
                <font color="#006699">设备使用状态管理</font>
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
                <font face="宋体">
                                     
                                <input type="button" value="新增使用状态" class="redbuttoncss" style="width: 80px;" onclick="javacript:location.href='NewAssetState.aspx'" />
                                 <input type="button" value="返回" class="redbuttoncss" style="width: 80px;" onclick="javacript:location.href='AssetMange.aspx'" />
                                    &nbsp;</font>
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
                  <asp:DataGrid ID="dgAssetType" runat="server" BorderColor="#93BEE2" BorderStyle="None"
                        BorderWidth="1px" BackColor="White" CellPadding="3" PageSize="15" AllowPaging="True"
                        AutoGenerateColumns="False" DataKeyField="ID" Width="100%" 
                        AllowSorting="True" ondeletecommand="dbStaffList_DeleteCommand" 
                        onpageindexchanged="dbStaffList_PageIndexChanged">
                        <SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
                        <AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
                        <ItemStyle Font-Size="X-Small" Wrap="false"></ItemStyle>
                        <HeaderStyle Font-Size="X-Small" Wrap="false" Font-Bold="True" ForeColor="White"
                            BackColor="#337FB2"></HeaderStyle>
                        <FooterStyle Font-Size="X-Small" HorizontalAlign="Right" BackColor="#E8F4FF"></FooterStyle>
                        <Columns>
                            <asp:TemplateColumn HeaderText="ID">
                                <HeaderStyle Width="20px"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkStaff_ID" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:HyperLinkColumn Text="使用状态" DataNavigateUrlField="ID" DataNavigateUrlFormatString="NewAssetState.aspx?StateID={0}"
                                DataTextField="Name" HeaderText="使用状态" SortExpression="Name">
                                <HeaderStyle Wrap="false"></HeaderStyle>
                                <ItemStyle Wrap="false" />
                            </asp:HyperLinkColumn>
                            <asp:BoundColumn DataField="Remark" SortExpression="Remark" HeaderText="备注">
                                <HeaderStyle Wrap="false"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:ButtonColumn Text="删除" HeaderText="删除" CommandName="Delete">
                                <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:ButtonColumn>
                        </Columns>
                        <PagerStyle Font-Size="X-Small" HorizontalAlign="left" BackColor="#E8F4FF" Mode="NumericPages">
                        </PagerStyle>
                    </asp:DataGrid>
            </td>
        </tr>
       </table>
    </form>
</body>

</html>
