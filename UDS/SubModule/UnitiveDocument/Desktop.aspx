<%@ Page Language="c#" CodeBehind="Desktop.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.Desktop" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Desktop</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">

    <script language="javascript">
		function dialwinprocess(CurrDate,CurrTime,whichPg,TaskID)
			{
			   if(whichPg==1)
				var newdialoguewin = window.showModalDialog("../Schedule/Manage.aspx?CurrDate="+CurrDate+"&CurrTime="+CurrTime,window,"dialogWidth:1000px;DialogHeight=700px;status:no");
			   else if(whichPg==2)
			   var newdialoguewin = window.showModalDialog("../Schedule/TaskDetail.aspx?TaskID="+TaskID+"&Date="+CurrDate,window,"dialogWidth:700px;DialogHeight=600px;status:no");
			   else if(whichPg==3)
			   var newdialoguewin = window.showModalDialog("../Schedule/TaskStatus.aspx?TaskID="+TaskID+"&Date="+CurrDate,window,"dialogWidth:700px;DialogHeight=600px;status:no");
			}
    </script>

</head>
<body leftmargin="0" topmargin="0" rightmargin="5">
    <form id="Desktop" method="post" runat="server">
    <table cellspacing="10" cellpadding="0" align="center" border="0" width="100%" style="table-layout: fixed;
        height: 100%">
        <tr>
            <td valign="top">
                <table id="Table5" cellspacing="0" cellpadding="0" align="left" border="0" width="100%">
                    <tr>
                        <td>
                            <img id="IMG5" src="../../Images/desktop5.gif" border="0" runat="server">
                        </td>
                        <td valign="bottom" align="right" width="40">
                            <a href="Board/BoardManagement.aspx" target="_self">
                                <img alt="" src="../../Images/more.gif" border="0"></a>
                        </td>
                        <td valign="bottom" align="right" width="40">
                            <%if (isAdmin == true)
                              {%>
                            <a href="Board/EditBoard.aspx" target="_self">
                                <img alt="" src="../../Images/new.gif" border="0"></a>
                            <%}
                              else
                              {%>
                            &nbsp;&nbsp; &nbsp;
                            <%}%>
                        </td>
                        <%--<td vAlign="bottom" align="right" width="40"><A href="Board/EditBoard.aspx" target="_self"><IMG alt="" src="../../Images/new.gif" border="0"></A></td>--%>
                    </tr>
                    <tr>
                        <td colspan="3" height="40">
                            <asp:DataGrid ID="dgBoard" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                GridLines="Horizontal" PageSize="5" DataKeyField="Board_ID" Width="100%" PagerStyle-HorizontalAlign="center"
                                PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                CellPadding="2" OnPageIndexChanged="DataGrid_PageChanged" CssClass="top" BorderWidth="1px"
                                OnDataBinding="dgBoard_DataBinding" OnItemCreated="dgBoard_ItemCreated" OnItemDataBound="dgBoard_ItemDataBound">
                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                <HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="20px"
                                    ForeColor="#006699" VerticalAlign="Middle" BackColor="#E8F4FF"></HeaderStyle>
                                <FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom">
                                </FooterStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderText="公告标题" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <a href="Board/ViewBoard.aspx?BoardID=<%# Eval("Board_ID") %> "  target="_blank">
                                                <%# Eval("Board_Name")%></a>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Size="14px" />
                                        <HeaderStyle Font-Size="14px" />
                                    </asp:TemplateColumn>
                                    
                                   <%-- <asp:HyperLinkColumn DataNavigateUrlField="Board_ID" DataNavigateUrlFormatString="Board/ViewBoard.aspx?BoardID={0}"
                                        DataTextField="Board_Name" HeaderText="公告标题">
                                        <HeaderStyle Font-Size="X-Small" HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle Font-Size="X-Small" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                    </asp:HyperLinkColumn>--%>
                                    <asp:TemplateColumn HeaderText="发布日期">
                                        <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                                        <ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"add_date") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle Font-Size="X-Small"></FooterStyle>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle Visible="False" HorizontalAlign="Right" ForeColor="White" BackColor="#93BEE2"
                                    Mode="NumericPages"></PagerStyle>
                            </asp:DataGrid>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table id="Table6" cellspacing="0" cellpadding="0" align="left" border="0" width="100%">
                    <tr>
                        <td>
                            <img id="Img6" src="../../Images/desktop6.gif" border="0" runat="server">
                        </td>
                        <td valign="bottom" align="right" width="40">
                            <a href="DocumentFlow/FlowTemplate.aspx" target="_self">
                                <img alt="" src="../../Images/more.gif" border="0"></a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="40">
                            <asp:DataGrid ID="dgFlowList" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                GridLines="Horizontal" PageSize="5" DataKeyField="Flow_ID" Width="100%" PagerStyle-HorizontalAlign="center"
                                PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                CellPadding="2" OnPageIndexChanged="DataGrid_PageChanged" CssClass="top" BorderWidth="1px"
                                OnDataBinding="dgBoard_DataBinding" OnItemCreated="dgBoard_ItemCreated" OnItemDataBound="dgBoard_ItemDataBound">
                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                <HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="20px"
                                    ForeColor="#006699" VerticalAlign="Middle" BackColor="#E8F4FF"></HeaderStyle>
                                <FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom">
                                </FooterStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderText="流程名">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle Font-Size="X-Small" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                        <ItemTemplate>
                                            <a href='DocumentFlow/NewDocument.aspx?FlowID=<%# DataBinder.Eval(Container.DataItem,"Flow_ID") %>'>
                                                <%# (DataBinder.Eval(Container.DataItem, "Flow_Name").ToString().Length > 30) ? DataBinder.Eval(Container.DataItem, "Flow_Name").ToString().Substring(0, 30) + "..." : DataBinder.Eval(Container.DataItem, "Flow_Name").ToString()%>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="流程类别">
                                        <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                                        <ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Flow_Class") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle Font-Size="X-Small"></FooterStyle>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle Visible="False" Font-Size="12px" BorderColor="#E0E0E0" BorderStyle="Dotted"
                                    HorizontalAlign="Right" PageButtonCount="5" Mode="NumericPages"></PagerStyle>
                            </asp:DataGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%--<tr>
            <td height="2">
            </td>
            <td>
            </td>
        </tr>--%>
        <tr>
            <td valign="top">
                <table id="Table1" cellspacing="0" cellpadding="0" align="left" border="0" width="100%">
                    <tr>
                        <td>
                            <img id="IMG1" src="../../Images/desktop1.jpg" border="0" runat="server">
                        </td>
                        <td valign="bottom" align="right">
                            <%--
                            <a href="../Schedule/TaskList.aspx" target="_self">
                                <img alt="" src="../../Images/more.gif" border="0"></a>--%>
                        </td>
                        <td valign="bottom" align="right">
                            <a href="../Schedule/TaskList.aspx" target="_self">
                                <img alt="" src="../../Images/more.gif" border="0"></a> <a onclick="var newwin=window.open('../Schedule/Manage.aspx','newtask','toolbar=yes,scrollbars=yes,width=800,height=600,resizable=yes');newwin.moveTo(0,0);newwin.focus();"
                                    href="#" target="_self">
                                    <img alt="" src="../../Images/new.gif" border="0"></a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" height="40">
                            <asp:DataGrid ID="dgList" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                GridLines="Horizontal" PageSize="5" DataKeyField="ID" Width="100%" PagerStyle-HorizontalAlign="center"
                                PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                CellPadding="2" OnPageIndexChanged="DataGrid_PageChanged" CssClass="top" BorderWidth="1px"
                                OnDataBinding="dgBoard_DataBinding" OnItemCreated="dgBoard_ItemCreated" OnItemDataBound="dgBoard_ItemDataBound">
                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                <HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="20px"
                                    ForeColor="#006699" VerticalAlign="Middle" BackColor="#E8F4FF"></HeaderStyle>
                                <FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom">
                                </FooterStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderText="时段">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle Font-Size="X-Small" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# GetDateString(DataBinder.Eval(Container, "DataItem.Date").ToString())+"  "+GetPeriodByPeriodID(DataBinder.Eval(Container, "DataItem.EndTime").ToString(),DataBinder.Eval(Container, "DataItem.beginPeriodID").ToString(),(DataBinder.Eval(Container, "DataItem.endPeriodID").ToString())) %>'
                                                ID="Label2" NAME="Label2">
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="内容">
                                        <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                                        <ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <a href="#" onclick='javascript:return dialwinprocess("","","2","<%# DataBinder.Eval(Container, "DataItem.TaskID") %>")'>
                                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Subject") %>'
                                                    ID="Label3" NAME="Label3"> </asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle Font-Size="X-Small"></FooterStyle>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle Visible="False" Font-Size="12px" BorderColor="#E0E0E0" BorderStyle="Dotted"
                                    HorizontalAlign="Right" PageButtonCount="5" Mode="NumericPages"></PagerStyle>
                            </asp:DataGrid>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table id="Table2" cellspacing="0" cellpadding="0" align="left" border="0" width="100%">
                    <tr>
                        <td>
                            <img id="Img4" src="../../Images/desktop2.jpg" border="0" runat="server">
                        </td>
                        <td valign="bottom" align="right" width="40">
                            <a href="NewDoc/Listview.aspx" target="_self">
                                <img alt="" src="../../Images/more.gif" border="0"></a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="40">
                            <asp:DataGrid ID="dgDocList" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                GridLines="Horizontal" PageSize="5" DataKeyField="DocID" Width="100%" PagerStyle-HorizontalAlign="center"
                                PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                CellPadding="2" OnPageIndexChanged="DataGrid_PageChanged" CssClass="top" BorderWidth="1px"
                                OnDataBinding="dgBoard_DataBinding" OnItemCreated="dgBoard_ItemCreated" OnItemDataBound="dgBoard_ItemDataBound">
                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                <HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="20px"
                                    ForeColor="#006699" VerticalAlign="Middle" BackColor="#E8F4FF"></HeaderStyle>
                                <FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom">
                                </FooterStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderText="文档标题">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle Font-Size="X-Small" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                        <ItemTemplate>
                                            <a href='Document/BrowseDocument.aspx?DocId=<%# DataBinder.Eval(Container.DataItem,"DocID") %>'>
                                                <%# (DataBinder.Eval(Container.DataItem,"DocTitle").ToString().Length>30)?DataBinder.Eval(Container.DataItem,"DocTitle").ToString().Substring(0,30)+"...":DataBinder.Eval(Container.DataItem,"DocTitle").ToString() %>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="审批人">
                                        <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                                        <ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# GetRealName(DataBinder.Eval(Container, "DataItem.DocApprover").ToString()) %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle Font-Size="X-Small"></FooterStyle>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle Visible="False" Font-Size="12px" BorderColor="#E0E0E0" BorderStyle="Dotted"
                                    HorizontalAlign="Right" PageButtonCount="5" Mode="NumericPages"></PagerStyle>
                            </asp:DataGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%-- <tr>
            <td height="2">
            </td>
            <td>
            </td>
        </tr>--%>
        <tr>
            <td valign="top">
                <table id="Table3" cellspacing="0" cellpadding="0" align="left" border="0" width="100%">
                    <%-- <tr style="color:#006699;background-color:#024289;font-size:X-Big;font-weight:bold;height:20px;">--%>
                    <tr>
                        <td valign="top">
                            <img id="IMG2" src="../../Images/desktop3.jpg" border="0" runat="server">
                        </td>
                        <td valign="bottom" align="right" width="40">
                            <a href="Mail/Index.aspx" target="_self">
                                <img alt="" src="../../Images/more.gif" border="0"></a>
                        </td>
                        <td valign="bottom" align="right" width="40">
                            <a href="Mail/Compose.aspx?ClassID=0" target="_self">
                                <img alt="" src="../../Images/new.gif" border="0"></a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" height="40">
                            <asp:DataGrid ID="dgMailList" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                GridLines="Horizontal" PageSize="5" DataKeyField="MailID" Width="100%" PagerStyle-HorizontalAlign="center"
                                PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                CellPadding="2" OnPageIndexChanged="DataGrid_PageChanged" CssClass="top" BorderWidth="1px"
                                OnDataBinding="dgBoard_DataBinding" OnItemCreated="dgBoard_ItemCreated" OnItemDataBound="dgBoard_ItemDataBound">
                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" Height="20px">
                                </ItemStyle>
                                <HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="20px"
                                    ForeColor="#006699" VerticalAlign="Middle" BackColor="#E8F4FF"></HeaderStyle>
                                <FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom">
                                </FooterStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderText="邮件主题">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle Font-Size="X-Small" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                        <ItemTemplate>
                                            <a href='Mail/ReadMail.aspx?FolderType=1&MailId=<%# DataBinder.Eval(Container.DataItem,"MailID") %>'>
                                                <%# (DataBinder.Eval(Container.DataItem,"MailSubject").ToString().Length>30)?DataBinder.Eval(Container.DataItem,"MailSubject").ToString().Substring(0,30)+"...":DataBinder.Eval(Container.DataItem,"MailSubject").ToString() %>
                                            </a>
                                            <%# DataBinder.Eval(Container.DataItem,"attnumber").ToString()==""?"":(DataBinder.Eval(Container.DataItem,"attnumber").ToString()=="0"?"":"<img src='../../DataImages/attach.gif' border='0'>") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="MailSender" HeaderText="发送者">
                                        <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                                        <ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundColumn>
                                </Columns>
                                <PagerStyle Visible="False" Font-Size="12px" BorderColor="#E0E0E0" BorderStyle="Dotted"
                                    HorizontalAlign="Right" PageButtonCount="5" Mode="NumericPages"></PagerStyle>
                            </asp:DataGrid>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table id="Table4" cellspacing="0" cellpadding="0" align="left" border="0" width="100%">
                    <tr>
                        <td valign="top">
                            <img id="IMG3" src="../../Images/desktop4.jpg" border="0" runat="server">
                        </td>
                        <td valign="bottom" align="right" width="40">
                            <a href="Approve/Listview.aspx" target="_self">
                                <img alt="" src="../../Images/more.gif" border="0"></a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="40">
                            <asp:DataGrid ID="dgAppDocList" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                GridLines="Horizontal" PageSize="5" DataKeyField="DocID" Width="100%" PagerStyle-HorizontalAlign="center"
                                PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                CellPadding="2" OnPageIndexChanged="DataGrid_PageChanged" CssClass="top" BorderWidth="1px"
                                OnDataBinding="dgBoard_DataBinding" OnItemCreated="dgBoard_ItemCreated" OnItemDataBound="dgBoard_ItemDataBound">
                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" Height="20px">
                                </ItemStyle>
                                <HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="20px"
                                    ForeColor="#006699" VerticalAlign="Middle" BackColor="#E8F4FF"></HeaderStyle>
                                <FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom">
                                </FooterStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderText="文档标题">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle Font-Size="X-Small" HorizontalAlign="Left" VerticalAlign="Middle" Height="20px">
                                        </ItemStyle>
                                        <ItemTemplate>
                                            <a href='Document/ApproveDocument.aspx?DocId=<%# DataBinder.Eval(Container.DataItem,"DocID") %>'>
                                                <%# (DataBinder.Eval(Container.DataItem,"DocTitle").ToString().Length>30)?DataBinder.Eval(Container.DataItem,"DocTitle").ToString().Substring(0,30)+"...":DataBinder.Eval(Container.DataItem,"DocTitle").ToString() %>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="上传人">
                                        <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                                        <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" Height="20px"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# GetRealName(DataBinder.Eval(Container, "DataItem.DocAddedBy").ToString()) %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle Visible="False" Font-Size="12px" BorderColor="#E0E0E0" BorderStyle="Dotted"
                                    HorizontalAlign="Right" PageButtonCount="5" Mode="NumericPages"></PagerStyle>
                            </asp:DataGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
