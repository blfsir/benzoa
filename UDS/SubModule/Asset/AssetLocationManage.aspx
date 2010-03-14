<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetLocationManage.aspx.cs" Inherits="UDS.SubModule.Asset.AssetLocationManage" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>ManageAssetLocation</title>
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
<body ms_positioning="GridLayout" leftmargin="0" topmargin="0">
    <form id="ManageStaff" method="post" runat="server">
    <font face="宋体">
    <table bordercolor="#111111" height="1" cellspacing="0" cellpadding="0" width="100%"
                        border="0">
                        <tr>
                            <td width="20" height="30"
                                align="right" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6" class="GbText">
                            <img height="16" src="../../DataImages/staff.gif" width="16" /></td>
                            <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width="110"
                                align="center">设备存放位置管理
                                
                      </td>
                            <td align="right" background="../../Images/treetopbg.jpg" bgcolor="#e8f4ff" class="GbText">
                                <%--   <asp:Button ID="cmdDimission" runat="server" Text="新增规格型号" CssClass="redbuttoncss">
                                    </asp:Button>--%>
                          <input type="button" value="新增存放位置" class="redbuttoncss" style="width: 80px;" onClick="javacript:location.href='NewAssetLocation.aspx'" /><font face="宋体">&nbsp; </font><input type="button" value="返回" class="redbuttoncss" style="width: 80px;" onClick="javacript:location.href='AssetMange.aspx'" />&nbsp;</td>
                        </tr>
                    </table>
        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" id="Table1">
            <tr>
                <td height="10" valign="top">
                    
                </td>
          </tr>
            <tr>
                <td>
                    <asp:DataGrid ID="dgAssetLocation" runat="server" BorderColor="#93BEE2" BorderStyle="None"
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
                            <asp:HyperLinkColumn Text="存放位置" DataNavigateUrlField="ID" DataNavigateUrlFormatString="NewAssetLocation.aspx?LocationID={0}"
                                DataTextField="Name" HeaderText="存放位置" SortExpression="Name">
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
</body>
</html>
