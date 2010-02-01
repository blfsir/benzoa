<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetupField.aspx.cs" Inherits="UDS.SubModule.UnitiveDocument.DocumentFlow.SetupField" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Setup Field</title>
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
    <form id="form1" runat="server">
    <div>
        <table id="Table1" style="z-index: 105; left: 0px; position: absolute; top: 0px"
            cellspacing="0" cellpadding="1" width="100%" border="0">
            <tr>
                <td align="left" style="height: 30px" background="../../../Images/treetopbg.jpg">
                    <span style="font-size: 10pt">表单字段设置</span>
                </td>
                <td align="right" style="height: 30px" background="../../../Images/treetopbg.jpg">
                    <asp:Button ID="cmdNewStyle" runat="server" CssClass="redbuttoncss" Text="新增表单字段" Visible ="false">
                    </asp:Button>
                    <input class="redbuttoncss" style="width: 81px" onclick="location.href='EditField.aspx';"
                        type="button" value="新增表单字段">
                    <input class="redbuttoncss" style="width: 71px" onclick="location.href='ManageStyle.aspx';"
                        type="button" value="返回">
                </td>
            </tr>
            <tr>
                <td valign="top" colspan="2">
                    <font face="宋体"></font><font face="宋体">
                        <asp:DataGrid ID="dgStyleList" runat="server" Width="100%" 
                        Font-Size="X-Small" PageSize="15"
                            OnPageIndexChanged="DataGrid_PageChanged" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataKeyField="Field_ID" 
                        BorderColor="#93BEE2" BorderStyle="None"
                            BorderWidth="1px" BackColor="White" CellPadding="3" 
                        OnDeleteCommand="MyDataGrid_Delete" onitemdatabound="dgStyleList_ItemDataBound">
                            <SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
                            <AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
                            <ItemStyle Font-Size="X-Small" ForeColor="#003399" BackColor="White"></ItemStyle>
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Middle"
                                BackColor="#337FB2"></HeaderStyle>
                            <FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
                            <Columns>
                                <asp:BoundColumn DataField="Field_ID" HeaderText="Field_ID" Visible="false">
                                    <HeaderStyle Width="20%"></HeaderStyle>
                                </asp:BoundColumn>
                               
                                <asp:BoundColumn DataField="Field_Name" HeaderText="Field_Name" Visible="false">
                                    <HeaderStyle Width="20%"></HeaderStyle>
                                </asp:BoundColumn>
                               
                               
                                <asp:TemplateColumn HeaderText="ID">
                                    <HeaderStyle Width="2%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cboStyleID" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:HyperLinkColumn DataNavigateUrlField="Field_ID" DataNavigateUrlFormatString="EditField.aspx?FieldID={0}"
                                    DataTextField="Field_Name" HeaderText="字段名">
                                    <HeaderStyle Font-Size="X-Small" Width="20%"></HeaderStyle>
                                    <ItemStyle Font-Size="X-Small"></ItemStyle>
                                </asp:HyperLinkColumn>
                                <asp:BoundColumn DataField="is_ddl" HeaderText="是否显示为下拉列表">
                                    <HeaderStyle Width="20%"></HeaderStyle>
                                </asp:BoundColumn>
                                 
                               
                                
                                 
                                 <asp:TemplateColumn>
                                    <HeaderStyle Width="20%"></HeaderStyle>
                                    
                                 </asp:TemplateColumn>
                                
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
    </div>
    </form>
</body>
</html>
