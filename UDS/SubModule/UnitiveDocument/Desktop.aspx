<%@ Page Language="c#" CodeBehind="Desktop.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.Desktop" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Desktop</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
   <%-- <link href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">--%>
      <link href="../../Css/oa.css" type="text/css" rel="stylesheet">

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
    
    <%--<div class="header"> 
<table width="400" border="0" align="right" cellpadding="0" cellspacing="0" class="nav"> 
  <tr> 
    <td height="65">&nbsp;</td> 
  </tr> 
  <tr> 
    <td valign="top"><table width="446" border="0" cellspacing="0" cellpadding="0" class="navtxt"> 
      <tr> 
        <td width="25">&nbsp;</td> 
        <td width="30" align="center"><a href="#">桌面</a></td> 
        <td width="44" align="center"><a href="#">考勤</a></td> 
        <td width="35" align="center"><a href="#">便签</a></td> 
        <td width="44" align="center"><a href="#">日记</a></td> 
        <td width="47" align="center"><a href="#">通讯录</a></td> 
        <td width="35" align="center"><a href="#">设置</a></td> 
        <td width="46" align="center"><a href="#">帮助</a></td> 
        <td width="47" align="center"><a href="#">重登录</a></td> 
        <td width="40" align="center"><a href="#">退出</a></td> 
        <td width="53">&nbsp;</td> 
      </tr> 
    </table></td> 
  </tr> 
</table> 
</div> 
<div class="blank1"></div> 
<table width="100%" border="0" cellspacing="0" cellpadding="0"> 
  <tr> 
    <td width="200" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" class="left1"> 
      <tr> 
        <td class="tit4">我的日历</td> 
        <td align="right" class="tit4"><img src="images/tag01.gif" width="22" height="16" /></td> 
      </tr> 
      <tr> 
        <td colspan="2" class="rili">&nbsp;</td> 
      </tr> 
      </table> 
      <div class="blank1"></div> 
      <table width="100%" border="0" cellspacing="0" cellpadding="0" class="left1"> 
        <tr> 
          <td class="tit4">快捷流程</td> 
          <td align="right" class="tit4"><img src="images/tag01.gif" width="22" height="16" /></td> 
        </tr> 
        <tr> 
          <td colspan="2" class="tit2"><a href="#">快捷流程标题1</a></td> 
        </tr> 
        <tr> 
          <td colspan="2" class="tit2"><a href="#">快捷流程标题2</a></td> 
        </tr> 
                <tr> 
          <td colspan="2" class="tit2"><a href="#">快捷流程标题3</a></td> 
        </tr> 
        <tr> 
          <td colspan="2" class="tit2"><a href="#">快捷流程标题4</a></td> 
        </tr> 
                <tr> 
          <td colspan="2" class="tit2"><a href="#">快捷流程标题5</a></td> 
        </tr> 
        <tr> 
          <td colspan="2" class="tit2">&nbsp;</td> 
        </tr> 
        <tr> 
          <td colspan="2" class="tit2">&nbsp;</td> 
        </tr> 
        <tr> 
          <td colspan="2" class="tit2">&nbsp;</td> 
        </tr> 
        <tr> 
          <td colspan="2" class="tit2">&nbsp;</td> 
        </tr> 
        <tr> 
          <td colspan="2" class="tit2">&nbsp;</td> 
        </tr> 
        <tr> 
          <td colspan="2" class="tit3">&nbsp;</td> 
        </tr> 
    </table></td> 
    <td><table width="95%" border="0" align="center" cellpadding="0" cellspacing="0"> 
      <tr> 
        <td width="49%" valign="top"> 
        <table width="100%" border="0" cellspacing="0" cellpadding="0"> 
          <tr> 
            <td class="tit1">新闻中心</td> 
            <td align="right" class="tit1"><img src="images/tag01.gif" width="22" height="16" /></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题1</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题2</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题3</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题4</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题5</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" align="right" class="tit3"><a href="#"><img src="images/tag02.gif" width="40" height="17" class="maor1" /></a></td> 
          </tr> 
        </table></td> 
        <td></td> 
        <td width="49%" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0"> 
          <tr> 
            <td class="tit1">我的任务</td> 
            <td align="right" class="tit1"><img src="images/tag01.gif" width="22" height="16" /></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题1</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题2</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题3</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题4</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题5</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" align="right" class="tit3"><a href="#"><img src="images/tag02.gif" width="40" height="17" class="maor1" /></a></td> 
          </tr> 
        </table></td> 
      </tr> 
      <tr> 
        <td valign="top">&nbsp;</td> 
        <td></td> 
        <td valign="top">&nbsp;</td> 
      </tr> 
      <tr> 
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0"> 
          <tr> 
            <td class="tit1">通知公告</td> 
            <td align="right" class="tit1"><img src="images/tag01.gif" width="22" height="16" /></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><asp:DataGrid ID="dgBoard" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                GridLines="Horizontal" PageSize="5" DataKeyField="Board_ID" Width="100%" PagerStyle-HorizontalAlign="center"
                                PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                CellPadding="2" OnPageIndexChanged="DataGrid_PageChanged" CssClass="top" BorderWidth="1px"
                                OnDataBinding="dgBoard_DataBinding" OnItemCreated="dgBoard_ItemCreated" OnItemDataBound="dgBoard_ItemDataBound">
                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                <HeaderStyle Font-Size="X-Small"  HorizontalAlign="Center" Height="20px"
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
                            </asp:DataGrid></td> 
          </tr> 
           
          <tr> 
            <td colspan="2" align="right" class="tit3"><a href="#"><img src="images/tag02.gif" width="40" height="17" class="maor1" /></a></td> 
          </tr> 
        </table></td> 
        <td></td> 
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0"> 
          <tr> 
            <td class="tit1">我的待签</td> 
            <td align="right" class="tit1"><img src="images/tag01.gif" width="22" height="16" /></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题1</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题2</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题3</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题4</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题5</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" align="right" class="tit3"><a href="#"><img src="images/tag02.gif" width="40" height="17" class="maor1" /></a></td> 
          </tr> 
        </table></td> 
      </tr> 
      <tr> 
        <td valign="top">&nbsp;</td> 
        <td></td> 
        <td valign="top">&nbsp;</td> 
      </tr> 
      <tr> 
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0"> 
          <tr> 
            <td class="tit1">公司论坛</td> 
            <td align="right" class="tit1"><img src="images/tag01.gif" width="22" height="16" /></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题1</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题2</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题3</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题4</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"><a href="#">项目信息标题5</a></td> 
          </tr> 
          <tr> 
            <td colspan="2" align="right" class="tit3"><a href="#"><img src="images/tag02.gif" width="40" height="17" class="maor1" /></a></td> 
          </tr> 
        </table></td> 
        <td></td> 
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0"> 
          <tr> 
            <td class="tit1">我的邮箱</td> 
            <td align="right" class="tit1"><img src="images/tag01.gif" width="22" height="16" /></td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tit2"> <asp:DataGrid ID="dgMailList" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                GridLines="Horizontal" PageSize="5" DataKeyField="MailID" Width="100%" PagerStyle-HorizontalAlign="center"
                                PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                CellPadding="2" OnPageIndexChanged="DataGrid_PageChanged" CssClass="top" BorderWidth="1px"
                                OnDataBinding="dgBoard_DataBinding" OnItemCreated="dgBoard_ItemCreated" OnItemDataBound="dgBoard_ItemDataBound">
                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" Height="20px">
                                </ItemStyle>
                                <HeaderStyle Font-Size="X-Small"  HorizontalAlign="Center" Height="20px"
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
                            </asp:DataGrid></td> 
          </tr> 
          
          <tr> 
            <td colspan="2" align="right" class="tit3"><a href="#"><img src="images/tag02.gif" width="40" height="17" class="maor1" /></a></td> 
          </tr> 
        </table></td> 
      </tr> 
    </table></td> 
  </tr> 
</table> 
 
<div class="footer"></div> --%>
 
    <table cellspacing="10" cellpadding="0" align="center" border="0" width="98%" style="table-layout: fixed;
        height: 100%">
        <tr>
            <td valign="top">
                <table id="Table5" cellspacing="0" cellpadding="0" align="left" border="0" width="100%">
                    <tr>
                        <td width="50" bgcolor="#2C72AE">
                            <img id="IMG5" src="../../Images/desktop5_1.jpg" border="0" runat="server">
                        </td>
                        <td bgcolor="#2C72AE" class="tit5">公司公告</td>
                        <td width="40" align="center" bgcolor="#2C72AE">
                            <a href="Board/BoardManagement.aspx" target="_self">
                                <img alt="" src="../../Images/more.gif" border="0"></a>
                        </td>
                        <td width="40" align="center" bgcolor="#2C72AE">
                            <%if (isAdmin == true)
                              {%>
                            <a href="Board/EditBoard.aspx" target="_self">
                                <img alt="" src="../../Images/new.gif" border="0"></a>
                            <%}
                              else
                              {%>
                            <%}%>
                        </td>
                        
                    </tr>
                    <tr>
                        <td colspan="4" height="40">
                            <asp:DataGrid ID="dgBoard" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                GridLines="Horizontal" PageSize="5" DataKeyField="Board_ID" Width="100%" PagerStyle-HorizontalAlign="center"
                                PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                CellPadding="2" OnPageIndexChanged="DataGrid_PageChanged" CssClass="top" BorderWidth="1px"
                                OnDataBinding="dgBoard_DataBinding" OnItemCreated="dgBoard_ItemCreated" OnItemDataBound="dgBoard_ItemDataBound">
                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                <HeaderStyle Font-Size="X-Small"  HorizontalAlign="Center" Height="20px"
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
                        <td width="50" bgcolor="#337FB3">
                            <img id="Img6" src="../../Images/desktop6_1.jpg" border="0" runat="server"></td>
                        <td bgcolor="#337FB3" class="tit5">公文流转</td>
                        <td width="40" bgcolor="#337FB3">&nbsp;</td>
                        <td width="40" align="center" bgcolor="#337FB3">
                            <a href="DocumentFlow/FlowTemplate.aspx" target="_self">
                                <img alt="" src="../../Images/more.gif" border="0"></a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" height="40">
                            <asp:DataGrid ID="dgFlowList" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                GridLines="Horizontal" PageSize="5" DataKeyField="Flow_ID" Width="100%" PagerStyle-HorizontalAlign="center"
                                PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                CellPadding="2" OnPageIndexChanged="DataGrid_PageChanged" CssClass="top" BorderWidth="1px"
                                OnDataBinding="dgBoard_DataBinding" OnItemCreated="dgBoard_ItemCreated" OnItemDataBound="dgBoard_ItemDataBound">
                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                <HeaderStyle Font-Size="X-Small"  HorizontalAlign="Center" Height="20px"
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
       
        <tr>
            <td valign="top">
                <table id="Table1" cellspacing="0" cellpadding="0" align="left" border="0" width="100%">
                    <tr>
                        <td width="50" bgcolor="#337FB3">
                            <img id="IMG1" src="../../Images/desktop1_1.jpg" border="0" runat="server">
                        </td>
                        <td bgcolor="#337FB3" class="tit5">今日任务</td>
                        <td width="40" align="center" bgcolor="#337FB3"><a href="../Schedule/TaskList.aspx" target="_self">
                                <img alt="" src="../../Images/more.gif" border="0"></a>
                           
                        </td>
                        <td width="40" align="center" bgcolor="#337FB3">
                             <a onClick="var newwin=window.open('../Schedule/Manage.aspx','newtask','toolbar=yes,scrollbars=yes,width=800,height=600,resizable=yes');newwin.moveTo(0,0);newwin.focus();"
                                    href="#" target="_self">
                                    <img alt="" src="../../Images/new.gif" border="0"></a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" height="40">
                            <asp:DataGrid ID="dgList" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                GridLines="Horizontal" PageSize="5" DataKeyField="ID" Width="100%" PagerStyle-HorizontalAlign="center"
                                PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                CellPadding="2" OnPageIndexChanged="DataGrid_PageChanged" CssClass="top" BorderWidth="1px"
                                OnDataBinding="dgBoard_DataBinding" OnItemCreated="dgBoard_ItemCreated" OnItemDataBound="dgBoard_ItemDataBound">
                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                <HeaderStyle Font-Size="X-Small"  HorizontalAlign="Center" Height="20px"
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
                        <td width="50" bgcolor="#337FB3">
                            <img src="../../Images/desktop2_1.jpg" width="45" height="30" border="0" id="Img4" runat="server">
                        </td>
                        <td bgcolor="#337FB3" class="tit5">我的文档</td>
                        <td width="40" bgcolor="#337FB3">&nbsp;</td>
                        <td width="40" align="center" bgcolor="#337FB3">
                            <a href="NewDoc/Listview.aspx" target="_self">
                                <img alt="" src="../../Images/more.gif" border="0"></a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" height="40">
                            <asp:DataGrid ID="dgDocList" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                GridLines="Horizontal" PageSize="5" DataKeyField="DocID" Width="100%" PagerStyle-HorizontalAlign="center"
                                PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                CellPadding="2" OnPageIndexChanged="DataGrid_PageChanged" CssClass="top" BorderWidth="1px"
                                OnDataBinding="dgBoard_DataBinding" OnItemCreated="dgBoard_ItemCreated" OnItemDataBound="dgBoard_ItemDataBound">
                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                <HeaderStyle Font-Size="X-Small"  HorizontalAlign="Center" Height="20px"
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
        
        <tr>
            <td valign="top">
                <table id="Table3" cellspacing="0" cellpadding="0" align="left" border="0" width="100%">
                  
                    <tr>
                        <td width="50" bgcolor="#337FB3">
                            <img id="IMG2" src="../../Images/desktop3_1.jpg" border="0" runat="server">
                        </td>
                        <td bgcolor="#337FB3" class="tit5">我的邮箱</td>
                        <td width="40" align="center" bgcolor="#337FB3">
                            <a href="Mail/Index.aspx" target="_self">
                                <img alt="" src="../../Images/more.gif" border="0"></a>
                        </td>
                        <td width="40" align="center" bgcolor="#337FB3">
                            <a href="Mail/Compose.aspx?ClassID=0" target="_self">
                                <img alt="" src="../../Images/new.gif" border="0"></a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" height="40">
                            <asp:DataGrid ID="dgMailList" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                GridLines="Horizontal" PageSize="5" DataKeyField="MailID" Width="100%" PagerStyle-HorizontalAlign="center"
                                PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                CellPadding="2" OnPageIndexChanged="DataGrid_PageChanged" CssClass="top" BorderWidth="1px"
                                OnDataBinding="dgBoard_DataBinding" OnItemCreated="dgBoard_ItemCreated" OnItemDataBound="dgBoard_ItemDataBound">
                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" Height="20px">
                                </ItemStyle>
                                <HeaderStyle Font-Size="X-Small"  HorizontalAlign="Center" Height="20px"
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
                        <td width="50" bgcolor="#337FB3">
                            <img id="IMG3" src="../../Images/desktop4_1.jpg" border="0" runat="server">
                        </td>
                        <td bgcolor="#337FB3" class="tit5">我的审批</td>
                        <td width="40" valign="top" bgcolor="#337FB3">&nbsp;</td>
                        <td width="40" align="center" bgcolor="#337FB3">
                            <a href="Approve/Listview.aspx" target="_self">
                                <img alt="" src="../../Images/more.gif" border="0"></a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" height="40">
                            <asp:DataGrid ID="dgAppDocList" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                GridLines="Horizontal" PageSize="5" DataKeyField="DocID" Width="100%" PagerStyle-HorizontalAlign="center"
                                PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                CellPadding="2" OnPageIndexChanged="DataGrid_PageChanged" CssClass="top" BorderWidth="1px"
                                OnDataBinding="dgBoard_DataBinding" OnItemCreated="dgBoard_ItemCreated" OnItemDataBound="dgBoard_ItemDataBound">
                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" Height="20px">
                                </ItemStyle>
                                <HeaderStyle Font-Size="X-Small"  HorizontalAlign="Center" Height="20px"
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
