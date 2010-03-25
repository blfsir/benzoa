<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewDesktop.aspx.cs" Inherits="UDS.SubModule.UnitiveDocument.NewDesktop"
    ValidateRequest="false" %>

<%@ Register Assembly="DataCalendar" Namespace="DataControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html>
<head>
    <title>Desktop</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <%--<link href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">--%>
    <link href="../../Css/oa.css" type="text/css" rel="stylesheet">
   

    <script type="text/javascript" for="BianQianText" event="onclick">
	if(innerText.replace(/\s/g,"")=="点击添加我的便签")
	{	
		style.color="";
		innerText=""
	}
    </script>

    <script language="javascript">
  
function hideDiv()
{
	var text=BianQianText.innerText;
	if(text=="点击添加我的便签") return false;
	if(text.length>4000)
	{
		alert("便签一次最多只能录入4000个字。");
		return false;
	}
  	document.getElementById("txtContents").value=text;
 	BianQianText.innerText="";
}
function divChangbgColor(obj)
{
	BianQianLayer.style.background=obj.style.background;
}
   
		function dialwinprocess(CurrDate,CurrTime,whichPg,TaskID)
			{
			   if(whichPg==1)
				var newdialoguewin = window.showModalDialog("../Schedule/Manage.aspx?CurrDate="+CurrDate+"&CurrTime="+CurrTime,window,"dialogWidth:1000px;DialogHeight=700px;status:no");
			   else if(whichPg==2)
			   var newdialoguewin = window.showModalDialog("../Schedule/TaskDetail.aspx?TaskID="+TaskID+"&Date="+CurrDate,window,"dialogWidth:700px;DialogHeight=600px;status:no");
			   else if(whichPg==3)
			   var newdialoguewin = window.showModalDialog("../Schedule/TaskStatus.aspx?TaskID="+TaskID+"&Date="+CurrDate,window,"dialogWidth:700px;DialogHeight=600px;status:no");
			}
			 var LEFT_MENU_VIEW=0; 
 
			 
    </script>

</head>
<body leftmargin="0" topmargin="0" rightmargin="5">
    <form id="Desktop" method="post" runat="server">
  
    <div style="padding:10px;"> 
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0"> 
  <tr> 
    <td width="205" valign="top" bgcolor="#dbecf3"><div class="left2"><table width="190" border="0" align="center" cellpadding="0" cellspacing="0"> 
      <tr> 
        <td class="tit1">我的日历</td> 
        <td align="right" class="tit4">&nbsp;</td> 
        </tr> 
      <tr> 
        <td colspan="2" class="rili"><asp:Calendar ID="myCalendar" runat="server" 
                BackColor="#ffffff" Width="100%" Font-Names="Arial"
                                BorderWidth="0" BorderColor="#000000" 
                OnDayRender="myCalendar_DayRender" CellSpacing="0" Height="100%" 
                PrevMonthText="&lt;" SelectMonthText="&lt;&lt;">
                                <TodayDayStyle ForeColor="White" BackColor="Green" Font-Size="10px"></TodayDayStyle>
                                <NextPrevStyle Font-Size="6px" Font-Bold="True" ForeColor="#333333"></NextPrevStyle>
                                <DayHeaderStyle Font-Size="10px" Font-Bold="True"></DayHeaderStyle>
                                <TitleStyle Font-Size="10px" Font-Bold="True" BorderWidth="0px" ForeColor="#ffffff">
                                </TitleStyle>
                                <OtherMonthDayStyle BackColor="LightGray"></OtherMonthDayStyle>
                            </asp:Calendar></td> 
        </tr> 
      </table> 
        <table width="190" border="0" align="center" cellpadding="0" cellspacing="0"> 
          <tr> 
            <td class="tit1">快捷流程</td> 
            <td align="right" class="tit4">&nbsp;</td> 
          </tr> 
           <asp:Repeater ID="rptQuickFlow" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td colspan="2" class="tit2">
                                    <a href="DocumentFlow/NewDocument.aspx?FlowID=<%# DataBinder.Eval(Container.DataItem,"Flow_ID") %>">
                                        <%# DataBinder.Eval(Container.DataItem,"Flow_Name") %></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
        </table> 
        <div class="blank1"></div> 
        <table width="190" border="0" align="center" cellpadding="0" cellspacing="0"> 
          <tr> 
          <td><table width="190" border="0" cellspacing="0" cellpadding="0"> 
            <tr> 
              <td>  <asp:TextBox ID="txtContents"   runat="server"  Width="0px" style="display:none"></asp:TextBox><div id="BianQianLayer" style="background-color:#ffffcc">
                                <div style="border-top: solid 1 #dddddd; padding-top: 2px; border-left: solid 1 #dddddd;
                                    border-right: solid 1 #dddddd; height: 20px;" align="right">
                                    <span onclick="divChangbgColor(this)" style="cursor: hand; background: fff8f8; width: ;
                                        border: solid 1 #dddddd; width: 13; font-size: 10px; margin-right: 2px"></span>
                                    <span onclick="divChangbgColor(this)" style="cursor: hand; background: f2f2ff; width: ;
                                        border: solid 1 #dddddd; width: 13; font-size: 10px; margin-right: 2px"></span>
                                    <span onclick="divChangbgColor(this)" style="cursor: hand; background: f7fff0; width: ;
                                        border: solid 1 #dddddd; width: 13; font-size: 10px; margin-right: 2px"></span>
                                    <span onclick="divChangbgColor(this)" style="cursor: hand; background: ffffcc; width: ;
                                        border: solid 1 #dddddd; width: 13; font-size: 10px; margin-right: 2px"></span>
                                    &nbsp; <asp:ImageButton ID="imgSaveNote" runat="server" ImageUrl="../../images/ico_24.gif"
                                            OnClick="imgSaveNote_Click" OnClientClick="hideDiv()" />&nbsp; 
                                     
                                </div>
                                <div id="BianQianText" contenteditable style="word-break: break-all; border-bottom: solid 1 #dddddd;
                                    border-left: solid 1 #dddddd; border-right: solid 1 #dddddd; height: 130px; color: #999999;
                                    font-size: 14px; font-size: 12px">
                                    点击添加我的便签</div>
                            </div></td> 
              </tr> 
            </table></td> 
          </tr> 
      </table></div></td> 
    <td width="10" bgcolor="#e8f4ff"  ></td> 
    <td bgcolor="#e8f4ff"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0"> 
      <tr> 
        <td width="49%" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" class="manitable"> 
          <tr> 
            <td class="tit1"> 新闻中心</td> 
            <td align="right" class="tit1"><a href="#"> <a href="News/NewsList.aspx" target="_self"><img src="../../images/tag02.gif" width="40" height="17" class="maor1" /></a></td> 
          </tr> 
         <tr>
                                                <td colspan="2" class="tit2">
                                                    <asp:DataGrid ID="dgNews" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                                        GridLines="Horizontal" PageSize="6" DataKeyField="News_ID" Width="100%" PagerStyle-HorizontalAlign="center"
                                                        PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                                        CellPadding="0" CssClass="top" BorderWidth="1px" ShowHeader="false" Height="100%">
                                                       
                                                        <HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="20px"
                                                            ForeColor="#006699" VerticalAlign="Middle" BackColor="#E8F4FF"></HeaderStyle>
                                                        <FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom">
                                                        </FooterStyle>
                                                        <Columns>
                                                            <asp:TemplateColumn HeaderText="新闻标题" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <a href="News/ViewNews.aspx?NewsID=<%# Eval("News_ID") %> " target="_blank">
                                                                        <%# Eval("News_Name")%></a>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="tit2" />
                                                                <HeaderStyle Font-Size="14px" />
                                                                <HeaderStyle Font-Size="14px" />
                                                            </asp:TemplateColumn>
                                                         </Columns>
                                                        <PagerStyle Visible="False" HorizontalAlign="Right" ForeColor="White" BackColor="#93BEE2"
                                                            Mode="NumericPages"></PagerStyle>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr 
        </table> 
          <table width="100%" border="0" cellspacing="0" cellpadding="0" class="manitable"> 
            <tr> 
              <td class="tit1"> 通知公告</td> 
              <td align="right" class="tit1"><a href="#">  <a href="Board/BoardList.aspx" target="_self"><img src="../../images/tag02.gif" width="40" height="17" class="maor1" /></a></td> 
            </tr> 
            <tr>
                                                <td colspan="2" class="tit2">
                                                    <asp:DataGrid ID="dgBoard" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                                        GridLines="Horizontal" PageSize="6" DataKeyField="Board_ID" Width="100%" PagerStyle-HorizontalAlign="center"
                                                        PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                                        CellPadding="0" CssClass="top" BorderWidth="1px" ShowHeader="false">
                                                     
                                                        <HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="20px"
                                                            ForeColor="#006699" VerticalAlign="Middle" BackColor="#E8F4FF"></HeaderStyle>
                                                        <FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom">
                                                        </FooterStyle>
                                                        <Columns>
                                                            <asp:TemplateColumn HeaderText="公告标题" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <a href="Board/ViewBoard.aspx?BoardID=<%# Eval("Board_ID") %> " target="_blank">
                                                                        <%# Eval("Board_Name")%></a>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="tit2" />
                                                                <HeaderStyle Font-Size="14px" />
                                                            </asp:TemplateColumn>
                                                         </Columns>
                                                        <PagerStyle Visible="False" HorizontalAlign="Right" ForeColor="White" BackColor="#93BEE2"
                                                            Mode="NumericPages"></PagerStyle>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
              
          </table> 
          <table width="100%" border="0" cellspacing="0" cellpadding="0" class="manitable"> 
            <tr> 
              <td class="tit1">公司论坛</td> 
              <td align="right" class="tit1"> <a href="BBS/Catalog.aspx"><img src="../../images/tag02.gif" width="40" height="17" class="maor1" /></a></td> 
            </tr> 
              <tr>
                                                <td colspan="2" class="tit2">
                                                    <asp:DataGrid ID="ItemList" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                                        GridLines="Horizontal" PageSize="6" DataKeyField="item_id" Width="100%" PagerStyle-HorizontalAlign="center"
                                                        PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                                        CellPadding="0" CssClass="top" BorderWidth="1px" ShowHeader="false">
                                                        <HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="20px"
                                                            ForeColor="#006699" VerticalAlign="Middle" BackColor="#E8F4FF"></HeaderStyle>
                                                        <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" Height="20px">
                                                        </ItemStyle>
                                                        <Columns>
                                                            <asp:TemplateColumn HeaderText="贴子主题">
                                                                <ItemStyle HorizontalAlign="Left" CssClass="tit2"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <a onclick="javascript:window.open('bbs/display.aspx?ItemID=<%# DataBinder.Eval(Container, "DataItem.item_id") %>&BoardID=<%# DataBinder.Eval(Container, "DataItem.board_id")%>','_blank','')"
                                                                        href="#">
                                                                        <%# DataBinder.Eval(Container, "DataItem.title") %>
                                                                    </a>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.title") %>'>
                                                                    </asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateColumn>
                                                         </Columns>
                                                        <PagerStyle Visible="False" Font-Size="12px" BorderColor="#E0E0E0" BorderStyle="Dotted"
                                                            HorizontalAlign="Right" PageButtonCount="5" Mode="NumericPages"></PagerStyle>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
            
          </table></td> 
        <td width="10"></td> 
        <td width="49%" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" class="manitable"> 
          <tr> 
            <td class="tit1">我的任务</td> 
            <td align="right" class="tit1"><a href="#"> <a href="../Schedule/TaskList.aspx" target="_self"><img src="../../images/tag02.gif" width="40" height="17" class="maor1" /></a></td> 
          </tr> 
          <tr>
                                                <td colspan="2" class="tit2" height="80px">
                                                    <asp:DataGrid ID="dgList" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                                        GridLines="Horizontal" PageSize="6" DataKeyField="ID" Width="100%" PagerStyle-HorizontalAlign="center"
                                                        PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                                        CellPadding="0" OnPageIndexChanged="DataGrid_PageChanged" CssClass="top" BorderWidth="1px"
                                                        ShowHeader="false" Height="100%">
                                                   
                                                        <HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="20px"
                                                            ForeColor="#006699" VerticalAlign="Middle" BackColor="#E8F4FF"></HeaderStyle>
                                                        <FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom">
                                                        </FooterStyle>
                                                        <Columns>
                                                            <asp:TemplateColumn HeaderText="时段" Visible="false">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" Text='<%# GetDateString(DataBinder.Eval(Container, "DataItem.Date").ToString())+"  "+GetPeriodByPeriodID(DataBinder.Eval(Container, "DataItem.EndTime").ToString(),DataBinder.Eval(Container, "DataItem.beginPeriodID").ToString(),(DataBinder.Eval(Container, "DataItem.endPeriodID").ToString()))+"  "+DataBinder.Eval(Container, "DataItem.Subject")  %>'
                                                                        ID="Label2" NAME="Label2">
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="内容">
                                                                <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                                                                <ItemStyle Font-Size="X-Small" HorizontalAlign="left" CssClass="tit2"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <a href="#" onclick='javascript:return dialwinprocess("","","2","<%# DataBinder.Eval(Container, "DataItem.TaskID") %>")'>
                                                                        <asp:Label runat="server" Text='<%# GetDateString(DataBinder.Eval(Container, "DataItem.Date").ToString())+"  "+GetPeriodByPeriodID(DataBinder.Eval(Container, "DataItem.EndTime").ToString(),DataBinder.Eval(Container, "DataItem.beginPeriodID").ToString(),(DataBinder.Eval(Container, "DataItem.endPeriodID").ToString()))+"  "+DataBinder.Eval(Container, "DataItem.Subject")  %>'
                                                                            ID="Label3" NAME="Label3"> </asp:Label>
                                                                </ItemTemplate>
                                                                <FooterStyle Font-Size="X-Small"></FooterStyle>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                        <PagerStyle Visible="False" Font-Size="14px" BorderColor="#E0E0E0" BorderStyle="Dotted"
                                                            HorizontalAlign="Right" PageButtonCount="5" Mode="NumericPages"></PagerStyle>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
        </table> 
          <table width="100%" border="0" cellspacing="0" cellpadding="0" class="manitable"> 
            <tr> 
              <td class="tit1">我的待签</td> 
              <td align="right" class="tit1"> <a href="Board/BoardList.aspx" target="_self"><img src="../../images/tag02.gif" width="40" height="17" class="maor1" /></a></td> 
            </tr> 
               <tr>
                                                <td colspan="2" class="tit2">
                                                    <asp:DataGrid ID="dgAppDocList" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                                        GridLines="Horizontal" PageSize="6" Width="100%" PagerStyle-HorizontalAlign="center"
                                                        PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                                        CellPadding="0" CssClass="top" BorderWidth="1px" ShowHeader="false">
                                                   
                                                        <HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="20px"
                                                            ForeColor="#006699" VerticalAlign="Middle" BackColor="#E8F4FF"></HeaderStyle>
                                                        <FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom">
                                                        </FooterStyle>
                                                        <Columns>
                                                            <asp:TemplateColumn HeaderText="文档标题" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <a href='DocumentFlow/DisplayDocument.aspx?DocID=<%# DataBinder.Eval(Container.DataItem,"Doc_ID") %>'>
                                                                        <%# (DataBinder.Eval(Container.DataItem, "Title").ToString().Length > 30) ? DataBinder.Eval(Container.DataItem, "Title").ToString().Substring(0, 30) + "..." : DataBinder.Eval(Container.DataItem, "Title").ToString()%>
                                                                    </a>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="tit2" />
                                                                <HeaderStyle Font-Size="14px" />
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                        <PagerStyle Visible="False" HorizontalAlign="Right" ForeColor="White" BackColor="#93BEE2"
                                                            Mode="NumericPages"></PagerStyle>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
          </table> 
          <table width="100%" border="0" cellspacing="0" cellpadding="0" class="manitable"> 
            <tr> 
              <td class="tit1">我的邮箱</td> 
              <td align="right" class="tit1"> <a href="Mail/Index.aspx" target="_self"><img src="../../images/tag02.gif" width="40" height="17" class="maor1" /></a></td> 
            </tr> 
            <tr>
                                                <td colspan="2" class="tit2">
                                                    <asp:DataGrid ID="dgMailList" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                                        GridLines="Horizontal" PageSize="6" DataKeyField="MailID" Width="100%" PagerStyle-HorizontalAlign="center"
                                                        PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                                        CellPadding="0" OnPageIndexChanged="DataGrid_PageChanged" CssClass="top" BorderWidth="1px"
                                                        ShowHeader="false">
                                                        <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" Height="20px">
                                                        </ItemStyle>
                                                        <HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="20px"
                                                            ForeColor="#006699" VerticalAlign="Middle" BackColor="#E8F4FF"></HeaderStyle>
                                                        <FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom">
                                                        </FooterStyle>
                                                        <Columns>
                                                            <asp:TemplateColumn HeaderText="邮件主题">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Left" VerticalAlign="Middle" CssClass="tit2">
                                                                </ItemStyle>
                                                                <ItemTemplate>
                                                                    <a href='Mail/ReadMail.aspx?FolderType=1&MailId=<%# DataBinder.Eval(Container.DataItem,"MailID") %>'>
                                                                        <%# (DataBinder.Eval(Container.DataItem,"MailSubject").ToString().Length>30)?DataBinder.Eval(Container.DataItem,"MailSubject").ToString().Substring(0,30)+"...":DataBinder.Eval(Container.DataItem,"MailSubject").ToString() %>
                                                                    </a>
                                                                    <%# DataBinder.Eval(Container.DataItem,"attnumber").ToString()==""?"":(DataBinder.Eval(Container.DataItem,"attnumber").ToString()=="0"?"":"<img src='../../DataImages/attach.gif' border='0'>") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                         </Columns>
                                                        <PagerStyle Visible="False" Font-Size="14px" BorderColor="#E0E0E0" BorderStyle="Dotted"
                                                            HorizontalAlign="Right" PageButtonCount="5" Mode="NumericPages"></PagerStyle>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
          </table>          <div class="blank1"></div></td> 
        <td width="10" valign="top">&nbsp;</td> 
      </tr> 
    </table></td> 
  </tr> 
</table> 
</div> 
    <%--<table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="200" valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="left1" style="table-layout: fixed;">
                    <tr>
                        <td class="tit4">
                            我的日历
                        </td>
                        <td align="right" class="tit4">
                            <img src="../../images/tag01.gif" width="22" height="16" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="rili">
                            <asp:Calendar ID="myCalendar" runat="server" BackColor="#ffffff" Width="100%" Font-Names="Arial"
                                BorderWidth="0" BorderColor="#000000" OnDayRender="myCalendar_DayRender" CellSpacing="0">
                                <TodayDayStyle ForeColor="White" BackColor="Green" Font-Size="10px"></TodayDayStyle>
                                <NextPrevStyle Font-Size="6px" Font-Bold="True" ForeColor="#333333"></NextPrevStyle>
                                <DayHeaderStyle Font-Size="10px" Font-Bold="True"></DayHeaderStyle>
                                <TitleStyle Font-Size="10px" Font-Bold="True" BorderWidth="0px" ForeColor="#ffffff">
                                </TitleStyle>
                                <OtherMonthDayStyle BackColor="LightGray"></OtherMonthDayStyle>
                            </asp:Calendar>
                        </td>
                    </tr>
                </table>
                <div class="blank1">
                </div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="left1" style="table-layout: fixed;">
                    <tr>
                        <td class="tit4">
                            快捷流程
                        </td>
                        <td align="right" class="tit4">
                            <img src="../../images/tag01.gif" width="22" height="16" />
                        </td>
                    </tr>
                    <asp:Repeater ID="rptQuickFlow" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td colspan="2" class="tit2">
                                    <a href="DocumentFlow/NewDocument.aspx?FlowID=<%# DataBinder.Eval(Container.DataItem,"Flow_ID") %>">
                                        <%# DataBinder.Eval(Container.DataItem,"Flow_Name") %></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td colspan="2" class="tit3">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="left1" style="table-layout: fixed;">
                    <tr>
                        <td class="tit4">
                            我的便签 <asp:TextBox ID="txtContents"   runat="server"  Width="0px" style="display:none"></asp:TextBox>
                        </td>
                        <td align="right" class="tit4">
                            <img src="../../images/tag01.gif" width="22" height="16" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="tit3">
                           
                            <div id="BianQianLayer" style="background-color:#ffffcc">
                                <div style="border-top: solid 1 #dddddd; padding-top: 2px; border-left: solid 1 #dddddd;
                                    border-right: solid 1 #dddddd; height: 20px;" align="right">
                                    <span onclick="divChangbgColor(this)" style="cursor: hand; background: fff8f8; width: ;
                                        border: solid 1 #dddddd; width: 13; font-size: 10px; margin-right: 2px"></span>
                                    <span onclick="divChangbgColor(this)" style="cursor: hand; background: f2f2ff; width: ;
                                        border: solid 1 #dddddd; width: 13; font-size: 10px; margin-right: 2px"></span>
                                    <span onclick="divChangbgColor(this)" style="cursor: hand; background: f7fff0; width: ;
                                        border: solid 1 #dddddd; width: 13; font-size: 10px; margin-right: 2px"></span>
                                    <span onclick="divChangbgColor(this)" style="cursor: hand; background: ffffcc; width: ;
                                        border: solid 1 #dddddd; width: 13; font-size: 10px; margin-right: 2px"></span>
                                    &nbsp; <asp:ImageButton ID="imgSaveNote" runat="server" ImageUrl="../../images/ico_24.gif"
                                            OnClick="imgSaveNote_Click" OnClientClick="hideDiv()" />&nbsp; 
                                     
                                </div>
                                <div id="BianQianText" contenteditable style="word-break: break-all; border-bottom: solid 1 #dddddd;
                                    border-left: solid 1 #dddddd; border-right: solid 1 #dddddd; height: 130px; color: #999999;
                                    font-size: 14px; font-size: 12px">
                                    点击添加我的便签</div>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="25">
                
            </td>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="table-layout: fixed;">
                    <tr>
                        <td>
                            <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0" style="table-layout: fixed;">
                                <tr style="height: 100px">
                                    <td width="49%" valign="top" height="100%">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="tit1">
                                                    新闻中心
                                                </td>
                                                <td align="right" class="tit1">
                                                    <a href="News/NewsList.aspx" target="_self">
                                                        <img src="../../images/tag02.gif" width="40" height="17" class="maor1" /></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="tit2">
                                                    <asp:DataGrid ID="dgNews" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                                        GridLines="Horizontal" PageSize="6" DataKeyField="News_ID" Width="100%" PagerStyle-HorizontalAlign="center"
                                                        PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                                        CellPadding="0" CssClass="top" BorderWidth="1px" ShowHeader="false" Height="100%">
                                                       
                                                        <HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="20px"
                                                            ForeColor="#006699" VerticalAlign="Middle" BackColor="#E8F4FF"></HeaderStyle>
                                                        <FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom">
                                                        </FooterStyle>
                                                        <Columns>
                                                            <asp:TemplateColumn HeaderText="新闻标题" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <a href="News/ViewNews.aspx?NewsID=<%# Eval("News_ID") %> " target="_blank">
                                                                        <%# Eval("News_Name")%></a>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="tit2" />
                                                                <HeaderStyle Font-Size="14px" />
                                                                <HeaderStyle Font-Size="14px" />
                                                            </asp:TemplateColumn>
                                                         </Columns>
                                                        <PagerStyle Visible="False" HorizontalAlign="Right" ForeColor="White" BackColor="#93BEE2"
                                                            Mode="NumericPages"></PagerStyle>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="right" class="tit3">
                                                   
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                    </td>
                                    <td width="49%" valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 80px">
                                            <tr>
                                                <td class="tit1">
                                                    我的任务
                                                </td>
                                                <td align="right" class="tit1">
                                                      <a href="../Schedule/TaskList.aspx" target="_self">
                                                        <img src="../../images/tag02.gif" width="40" height="17" class="maor1" /></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="tit2" height="80px">
                                                    <asp:DataGrid ID="dgList" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                                        GridLines="Horizontal" PageSize="5" DataKeyField="ID" Width="100%" PagerStyle-HorizontalAlign="center"
                                                        PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                                        CellPadding="0" OnPageIndexChanged="DataGrid_PageChanged" CssClass="top" BorderWidth="1px"
                                                        ShowHeader="false" Height="100%">
                                                   
                                                        <HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="20px"
                                                            ForeColor="#006699" VerticalAlign="Middle" BackColor="#E8F4FF"></HeaderStyle>
                                                        <FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom">
                                                        </FooterStyle>
                                                        <Columns>
                                                            <asp:TemplateColumn HeaderText="时段" Visible="false">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" Text='<%# GetDateString(DataBinder.Eval(Container, "DataItem.Date").ToString())+"  "+GetPeriodByPeriodID(DataBinder.Eval(Container, "DataItem.EndTime").ToString(),DataBinder.Eval(Container, "DataItem.beginPeriodID").ToString(),(DataBinder.Eval(Container, "DataItem.endPeriodID").ToString()))+"  "+DataBinder.Eval(Container, "DataItem.Subject")  %>'
                                                                        ID="Label2" NAME="Label2">
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="内容">
                                                                <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                                                                <ItemStyle Font-Size="X-Small" HorizontalAlign="left" CssClass="tit2"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <a href="#" onclick='javascript:return dialwinprocess("","","2","<%# DataBinder.Eval(Container, "DataItem.TaskID") %>")'>
                                                                        <asp:Label runat="server" Text='<%# GetDateString(DataBinder.Eval(Container, "DataItem.Date").ToString())+"  "+GetPeriodByPeriodID(DataBinder.Eval(Container, "DataItem.EndTime").ToString(),DataBinder.Eval(Container, "DataItem.beginPeriodID").ToString(),(DataBinder.Eval(Container, "DataItem.endPeriodID").ToString()))+"  "+DataBinder.Eval(Container, "DataItem.Subject")  %>'
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
                                            <tr>
                                                <td colspan="2" align="right" class="tit3">
                                                  
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        &nbsp;
                                    </td>
                                    <td width="25px">
                                    </td>
                                    <td valign="top">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="tit1">
                                                    通知公告
                                                </td>
                                                <td align="right" class="tit1">
                                                   <a href="Board/BoardList.aspx" target="_self">
                                                        <img src="../../images/tag02.gif" width="40" height="17" class="maor1" /></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="tit2">
                                                    <asp:DataGrid ID="dgBoard" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                                        GridLines="Horizontal" PageSize="5" DataKeyField="Board_ID" Width="100%" PagerStyle-HorizontalAlign="center"
                                                        PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                                        CellPadding="0" CssClass="top" BorderWidth="1px" ShowHeader="false">
                                                     
                                                        <HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="20px"
                                                            ForeColor="#006699" VerticalAlign="Middle" BackColor="#E8F4FF"></HeaderStyle>
                                                        <FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom">
                                                        </FooterStyle>
                                                        <Columns>
                                                            <asp:TemplateColumn HeaderText="公告标题" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <a href="Board/ViewBoard.aspx?BoardID=<%# Eval("Board_ID") %> " target="_blank">
                                                                        <%# Eval("Board_Name")%></a>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="tit2" />
                                                                <HeaderStyle Font-Size="14px" />
                                                            </asp:TemplateColumn>
                                                         </Columns>
                                                        <PagerStyle Visible="False" HorizontalAlign="Right" ForeColor="White" BackColor="#93BEE2"
                                                            Mode="NumericPages"></PagerStyle>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="right" class="tit3">
                                                    
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                    </td>
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="tit1">
                                                    我的待签
                                                </td>
                                                <td align="right" class="tit1">
                                                   <a href="Board/BoardList.aspx" target="_self">
                                                        <img src="../../images/tag02.gif" width="40" height="17" class="maor1" /></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="tit2">
                                                    <asp:DataGrid ID="dgAppDocList" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                                        GridLines="Horizontal" PageSize="5" Width="100%" PagerStyle-HorizontalAlign="center"
                                                        PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                                        CellPadding="0" CssClass="top" BorderWidth="1px" ShowHeader="false">
                                                   
                                                        <HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="20px"
                                                            ForeColor="#006699" VerticalAlign="Middle" BackColor="#E8F4FF"></HeaderStyle>
                                                        <FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom">
                                                        </FooterStyle>
                                                        <Columns>
                                                            <asp:TemplateColumn HeaderText="文档标题" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <a href='DocumentFlow/DisplayDocument.aspx?DocID=<%# DataBinder.Eval(Container.DataItem,"Doc_ID") %>'>
                                                                        <%# (DataBinder.Eval(Container.DataItem, "Title").ToString().Length > 30) ? DataBinder.Eval(Container.DataItem, "Title").ToString().Substring(0, 30) + "..." : DataBinder.Eval(Container.DataItem, "Title").ToString()%>
                                                                    </a>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="tit2" />
                                                                <HeaderStyle Font-Size="14px" />
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                        <PagerStyle Visible="False" HorizontalAlign="Right" ForeColor="White" BackColor="#93BEE2"
                                                            Mode="NumericPages"></PagerStyle>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="right" class="tit3">
                                                   
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                     
                                </tr>
                                <tr>
                                    <td valign="top">
                                        &nbsp;
                                    </td>
                                    <td>
                                    </td>
                                    <td valign="top">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="tit1">
                                                    公司论坛
                                                </td>
                                                <td align="right" class="tit1">
                                                     <a href="BBS/Catalog.aspx">
                                                        <img src="../../images/tag02.gif" width="40" height="17" class="maor1" /></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="tit2">
                                                    <asp:DataGrid ID="ItemList" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                                        GridLines="Horizontal" PageSize="5" DataKeyField="item_id" Width="100%" PagerStyle-HorizontalAlign="center"
                                                        PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                                        CellPadding="0" CssClass="top" BorderWidth="1px" ShowHeader="false">
                                                        <HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="20px"
                                                            ForeColor="#006699" VerticalAlign="Middle" BackColor="#E8F4FF"></HeaderStyle>
                                                        <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" Height="20px">
                                                        </ItemStyle>
                                                        <Columns>
                                                            <asp:TemplateColumn HeaderText="贴子主题">
                                                                <ItemStyle HorizontalAlign="Left" CssClass="tit2"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <a onclick="javascript:window.open('bbs/display.aspx?ItemID=<%# DataBinder.Eval(Container, "DataItem.item_id") %>&BoardID=<%# DataBinder.Eval(Container, "DataItem.board_id")%>','_blank','')"
                                                                        href="#">
                                                                        <%# DataBinder.Eval(Container, "DataItem.title") %>
                                                                    </a>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.title") %>'>
                                                                    </asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateColumn>
                                                         </Columns>
                                                        <PagerStyle Visible="False" Font-Size="12px" BorderColor="#E0E0E0" BorderStyle="Dotted"
                                                            HorizontalAlign="Right" PageButtonCount="5" Mode="NumericPages"></PagerStyle>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="right" class="tit3">
                                                   
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                    </td>
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="tit1">
                                                    我的邮箱
                                                </td>
                                                <td align="right" class="tit1">
                                                    <a href="Mail/Index.aspx" target="_self">
                                                        <img src="../../images/tag02.gif" width="40" height="17" class="maor1" /></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="tit2">
                                                    <asp:DataGrid ID="dgMailList" runat="server" AllowPaging="True" BorderColor="#E8F4FF"
                                                        GridLines="Horizontal" PageSize="5" DataKeyField="MailID" Width="100%" PagerStyle-HorizontalAlign="center"
                                                        PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" BackColor="White"
                                                        CellPadding="0" OnPageIndexChanged="DataGrid_PageChanged" CssClass="top" BorderWidth="1px"
                                                        ShowHeader="false">
                                                        <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" Height="20px">
                                                        </ItemStyle>
                                                        <HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="20px"
                                                            ForeColor="#006699" VerticalAlign="Middle" BackColor="#E8F4FF"></HeaderStyle>
                                                        <FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom">
                                                        </FooterStyle>
                                                        <Columns>
                                                            <asp:TemplateColumn HeaderText="邮件主题">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Left" VerticalAlign="Middle" CssClass="tit2">
                                                                </ItemStyle>
                                                                <ItemTemplate>
                                                                    <a href='Mail/ReadMail.aspx?FolderType=1&MailId=<%# DataBinder.Eval(Container.DataItem,"MailID") %>'>
                                                                        <%# (DataBinder.Eval(Container.DataItem,"MailSubject").ToString().Length>30)?DataBinder.Eval(Container.DataItem,"MailSubject").ToString().Substring(0,30)+"...":DataBinder.Eval(Container.DataItem,"MailSubject").ToString() %>
                                                                    </a>
                                                                    <%# DataBinder.Eval(Container.DataItem,"attnumber").ToString()==""?"":(DataBinder.Eval(Container.DataItem,"attnumber").ToString()=="0"?"":"<img src='../../DataImages/attach.gif' border='0'>") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                         </Columns>
                                                        <PagerStyle Visible="False" Font-Size="14px" BorderColor="#E0E0E0" BorderStyle="Dotted"
                                                            HorizontalAlign="Right" PageButtonCount="5" Mode="NumericPages"></PagerStyle>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="right" class="tit3">
                                                   
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>--%>
    <div class="footer">
    </div>
   
    </form>
</body>
</html>
