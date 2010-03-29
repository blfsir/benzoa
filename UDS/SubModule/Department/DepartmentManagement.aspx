<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentManagement.aspx.cs" Inherits="UDS.SubModule.Department.DepartmentManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Department Management</title>
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
                    <span style="font-size: 10pt">部门设置</span>
                </td>
                <td align="right" style="height: 30px" background="../../../Images/treetopbg.jpg">
                  
                    <input class="redbuttoncss" style="width: 81px" onclick="location.href='EditDepartment.aspx';"
                        type="button" value="新建部门">
                   
                    <input class="redbuttoncss" style="width: 71px" onclick="location.href='../UnitiveDocument/Setup/Setup.aspx?ClassID=77';"
                        type="button" value="返回">
                </td>
            </tr>
            <tr>
                <td valign="top" colspan="2">
                    <font face="宋体"></font><font face="宋体">
           
									   <asp:DataGrid ID="dgStyleListAdmin" runat="server" Width="100%" Font-Size="Medium" PageSize="15"
                            OnPageIndexChanged="DataGrid_PageChanged" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataKeyField="Dept_ID" BorderColor="#93BEE2" BorderStyle="None"
                            BorderWidth="1px" BackColor="White" CellPadding="3" OnDeleteCommand="MyDataGrid_Delete"
                            >
                            <SelectedItemStyle  ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
                            <AlternatingItemStyle Font-Size="Medium" BackColor="#E8F4FF"></AlternatingItemStyle>
                            <ItemStyle Font-Size="Medium" ForeColor="#003399" BackColor="White"></ItemStyle>
                            <HeaderStyle  HorizontalAlign="Left" ForeColor="White" VerticalAlign="Middle"
                                BackColor="#337FB2"></HeaderStyle>
                            <FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
                            <Columns>
                               
                                <asp:TemplateColumn HeaderText="Dept_ID" Visible="false">
                                    <HeaderStyle Width="0"></HeaderStyle>
                                    <ItemTemplate>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:HyperLinkColumn DataNavigateUrlField="Dept_ID" DataNavigateUrlFormatString="EditDepartment.aspx?DeptID={0}"
                                    DataTextField="Dept_Name" HeaderText="部门名称">
                                    <HeaderStyle Font-Size="Medium" Width="70%"></HeaderStyle>
                                    <ItemStyle Font-Size="Medium"></ItemStyle>
                                </asp:HyperLinkColumn>
                                
                               	<asp:TemplateColumn HeaderText="备注">
													<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
													<ItemStyle Font-Size="Medium" HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Dept_Remark") %>'>
														</asp:Label>
													</ItemTemplate>
													<FooterStyle Font-Size="Medium"></FooterStyle>
												</asp:TemplateColumn>
												
                                <asp:ButtonColumn Text="删除" HeaderText="删除" CommandName="Delete">
                                    <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:ButtonColumn>
                            </Columns>
                            <PagerStyle NextPageText="" HorizontalAlign="Right" BackColor="#E8F4FF" Mode="NumericPages">
                            </PagerStyle>
                        </asp:DataGrid>
									
									 </font>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
