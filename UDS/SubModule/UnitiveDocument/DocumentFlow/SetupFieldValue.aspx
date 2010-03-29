<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetupFieldValue.aspx.cs" Inherits="UDS.SubModule.UnitiveDocument.DocumentFlow.SetupFieldValue" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Setup Field Value</title>
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
                    <span style="font-size: 10pt">表单字段下拉列表内容设置</span> <asp:Label ID="Label1" 
                        runat="server" Text="字段名："></asp:Label>
                    
                    [<asp:Label ID="lblFieldName" runat="server"></asp:Label>]<asp:Label 
                        ID="lblFieldID" runat="server" Text="" Width="0"></asp:Label>
                </td>
                <td align="right" style="height: 30px" background="../../../Images/treetopbg.jpg">
                     
                    <input class="redbuttoncss" style="width: 81px" onclick="location.href='EditFieldValue.aspx?FieldID=<%=this.lblFieldID.Text%> ';"
                        type="button" value="新增">
                    <input class="redbuttoncss" style="width: 71px" onclick="location.href='Listview.aspx';"
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
                            <SelectedItemStyle  ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
                            <AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
                            <ItemStyle Font-Size="X-Small" ForeColor="#003399" BackColor="White"></ItemStyle>
                            <HeaderStyle  HorizontalAlign="Left" ForeColor="White" VerticalAlign="Middle"
                                BackColor="#337FB2"></HeaderStyle>
                            <FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
                            <Columns>
                                <asp:BoundColumn DataField="FieldValue_ID" HeaderText="FieldValue_ID" Visible="false">
                                    <HeaderStyle Width="20%"></HeaderStyle>
                                </asp:BoundColumn>
                               
                                <asp:TemplateColumn HeaderText="ID">
                                    <HeaderStyle Width="2%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cboStyleID" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:HyperLinkColumn DataNavigateUrlField="FieldValue_ID"   DataNavigateUrlFormatString="EditFieldValue.aspx?FieldValueID={0}"
                                    DataTextField="FieldValue_Name" HeaderText="选项内容">
                                    <HeaderStyle Font-Size="X-Small" Width="20%"></HeaderStyle>
                                    <ItemStyle Font-Size="X-Small"></ItemStyle>
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
    </div>
    </form>
</body>
</html>
