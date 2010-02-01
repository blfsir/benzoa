<%@ Page Language="c#" CodeBehind="ManageStyle.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.DocumentFlow.ManageStyle" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>ManageStyle</title>
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
<body ms_positioning="GridLayout" leftmargin="0" rightmargin="0">
    <form id="ManageStyle" method="post" runat="server">
    &nbsp;
    <table id="Table1" style="z-index: 105; left: 0px; position: absolute; top: 0px"
        cellspacing="0" cellpadding="1" width="100%" border="0">
        <tr>
            <td align="left" style="height: 30px" background="../../../Images/treetopbg.jpg">
                <span style="font-size: 10pt">表单管理</span>
            </td>
            <td align="right" style="height: 30px" background="../../../Images/treetopbg.jpg">
                
                <input class="redbuttoncss" style="width: 81px" onclick="location.href='SetupField.aspx';"
                    type="button" value="表单字段设置">
                <asp:Button ID="cmdNewStyle" runat="server" CssClass="redbuttoncss" Text="新增表单">
                </asp:Button><input class="redbuttoncss" style="width: 71px" onclick="location.href='Listview.aspx';"
                    type="button" value="返回">
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="2">
                <font face="宋体"></font><font face="宋体">
                    <asp:DataGrid ID="dgStyleList" runat="server" Width="100%" Font-Size="X-Small" PageSize="15"
                        OnPageIndexChanged="DataGrid_PageChanged" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" DataKeyField="Style_ID" BorderColor="#93BEE2" BorderStyle="None"
                        BorderWidth="1px" BackColor="White" CellPadding="3" OnDeleteCommand="MyDataGrid_Delete">
                        <SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
                        <AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
                        <ItemStyle Font-Size="X-Small" ForeColor="#003399" BackColor="White"></ItemStyle>
                        <HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Middle"
                            BackColor="#337FB2"></HeaderStyle>
                        <FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
                        <Columns>
                            <asp:TemplateColumn HeaderText="ID">
                                <HeaderStyle Width="2%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cboStyleID" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:HyperLinkColumn DataNavigateUrlField="Style_ID" DataNavigateUrlFormatString="EditStyle.aspx?StyleID={0}"
                                DataTextField="Style_Name" HeaderText="表单名">
                                <HeaderStyle Font-Size="X-Small" Width="20%"></HeaderStyle>
                                <ItemStyle Font-Size="X-Small"></ItemStyle>
                            </asp:HyperLinkColumn>
                            <asp:BoundColumn DataField="Style_Remark" HeaderText="表单介绍">
                                <HeaderStyle Width="40%"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Template" HeaderText="模板">
                                <HeaderStyle HorizontalAlign="Left" Width="25%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                <FooterStyle HorizontalAlign="Left"></FooterStyle>
                            </asp:BoundColumn>
                            <asp:HyperLinkColumn Text="管理" DataNavigateUrlField="Style_ID" DataNavigateUrlFormatString="DefineStyle.aspx?StyleID={0}"
                                HeaderText="管理">
                                <HeaderStyle HorizontalAlign="Center" Width="6%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:HyperLinkColumn>
                            <asp:ButtonColumn Text="删除" HeaderText="删除" CommandName="Delete">
                                <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:ButtonColumn>
                        </Columns>
                        <PagerStyle NextPageText="" HorizontalAlign="Right" BackColor="#E8F4FF" Mode="NumericPages">
                        </PagerStyle>
                    </asp:DataGrid></font>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
