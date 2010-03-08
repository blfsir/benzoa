<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="UDS.SubModule.UnitiveDocument.News.NewsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 

<html xmlns="http://www.w3.org/1999/xhtml" >
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
<body ms_positioning="GridLayout" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>
        <table id="Table1" style="z-index: 105; left: 0px; position: absolute; top: 0px"
            cellspacing="0" cellpadding="1" width="100%" border="0">
            <tr>
                <td align="left" style="height: 30px" background="../../../Images/treetopbg.jpg">
                    <span style="font-size: 10pt">新闻中心管理</span>
                </td>
                <td align="right" style="height: 30px" background="../../../Images/treetopbg.jpg">
                  
                    <input class="redbuttoncss" style="width: 71px" onclick="location.href='../NewDesktop.aspx';"
                        type="button" value="返回">
                </td>
            </tr>
            <tr>
                <td valign="top" colspan="2">
                  
               
							 <asp:DataGrid ID="dgStyleListAdmin" runat="server" Width="100%" Font-Size="X-Small" PageSize="15"
                            OnPageIndexChanged="DataGrid_PageChanged" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataKeyField="News_ID" BorderColor="#93BEE2" BorderStyle="None"
                            BorderWidth="1px" BackColor="White" CellPadding="3">
                            <SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
                            <AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
                            <ItemStyle Font-Size="X-Small" ForeColor="#003399" BackColor="White"></ItemStyle>
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Middle"
                                BackColor="#337FB2"></HeaderStyle>
                            <FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
                            <Columns>
                               
                                <asp:TemplateColumn HeaderText="ID" Visible="false">
                                    <HeaderStyle Width="0"></HeaderStyle>
                                    <ItemTemplate>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="新闻标题" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <a href="ViewNews.aspx?NewsID=<%# Eval("News_ID") %> " target="_blank">
                                                            <%# Eval("News_Name")%></a>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="tit2" />
                                                    <HeaderStyle Font-Size="14px" />
                                                    <HeaderStyle Font-Size="14px" />
                                                </asp:TemplateColumn>
                                                <%--
                                <asp:HyperLinkColumn DataNavigateUrlField="News_ID" DataNavigateUrlFormatString="ViewNews.aspx?NewsID={0}"
                                    DataTextField="News_Name" HeaderText="新闻标题">
                                    <HeaderStyle Font-Size="X-Small" Width="70%"></HeaderStyle>
                                    <ItemStyle Font-Size="X-Small"></ItemStyle>
                                </asp:HyperLinkColumn>--%>
                                
                               	<asp:TemplateColumn HeaderText="发布日期">
													<HeaderStyle HorizontalAlign="Center" Width="20%" Font-Size="14px"></HeaderStyle>
													<ItemStyle Font-Size="X-Small" HorizontalAlign="Center"  CssClass="tit2"></ItemStyle>
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
