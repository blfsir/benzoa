<%@ Page Language="c#" CodeBehind="MeetingManage.aspx.cs" AutoEventWireup="false"
    Inherits="UDS.SubModule.Meeting.MeetingManage" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>MeetingManage</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

    <script language="JavaScript" src="../../Css/meizzDate.js"></script>

    <script language="javascript">
			
		var ball1 = new Image();
		var ball2 = new Image();
		ball1.src = 'images/ball1.gif';
		ball2.src = 'images/ball2.gif';

		var active = new Image();
		var nonactive = new Image();
		active.src = '../../images/maillistbutton2.gif';
		nonactive.src = '../../images/maillistbutton1.gif';

		function onMouseOver(img)
		{
			document.images[img].src = ball2.src;
		}

		function onMouseOut(img)
		{
			document.images[img].src = ball1.src;
		}

		function onOverBar(bar)
		{
			if (bar != null) {
				bar.style.backgroundImage = "url("+active.src+")";
				
			}
		}

		function onOutBar(bar)
		{
			if (bar != null) {
				bar.style.backgroundImage = "url("+nonactive.src+")";
			}
		}
		
		function selectAll(){
			var len=document.MailList.elements.length;
			var i;
		    for (i=0;i<len;i++){
			if (document.MailList.elements[i].type=="checkbox"){
		        document.MailList.elements[i].checked=true;								
						 }
					}
				}

		function unSelectAll(){
	          var len=document.MailList.elements.length;
	          var i;
	          for (i=0;i<len;i++){
	               if (document.MailList.elements[i].type=="checkbox"){
	                  document.MailList.elements[i].checked=false; 
	               }   
	        	 } 
		    }		

function ock_Search(){  
	var strAlert="";
	strBeginTime = document.all.txtBeginDate.value;
	strEndTime = document.all.txtEndDate.value;
	if (strBeginTime!="" & strEndTime!=""){		
		if (!CompareDate(strBeginTime,strEndTime)){
			strAlert = strAlert + "终止日期应大于等于起始日期。\n"
		}		
	}
    if (strAlert!=""){
		alert(strAlert);
		return false;
    }
}

    </script>

    <link href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
</head>
<%--<body ms_positioning="GridLayout" leftmargin="0" topmargin="0">
    <form id="MeetingManage" method="post" runat="server">
    <font face="宋体">
        <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td valign="top">
                    <table bordercolor="#111111" height="1" cellspacing="0" cellpadding="0" width="100%"
                        border="0">
                        <tbody>
                            <tr height="30">
                                <td class="GbText" width="20" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                                    align="right">
                                    <font color="#003366" size="3">
                                        <img height="16" src="../../DataImages/staff.gif" width="16"></font>
                                </td>
                                <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width="60"
                                    align="right" id="td_title" runat="server">
                                    <font color="#006699">会议查询</font>
                                </td>
                                <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right"
                                    width="85%">
                                </td>
                </td>
            </tr>
            </TBODY></table>
        </TD></TR>
        <tr>
            <td>
                <table class="gbtext" id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td align="center" width="90" background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>.gif'
                            height="24">
                            会议查询
                        </td>
                        <td align="right">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="tr_Tj" runat="server" bgcolor="#e8f4ff">
            <td align="left">
                <table class="gbtext" id="Table3" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td align="right">
                            会议类型：
                        </td>
                        <td>
                           
                            <asp:DropDownList ID="ddlMeetingType" runat="server" Width="120">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            会 议 室：
                        </td>
                        <td>
                             
                            <asp:DropDownList ID="ddlMeetingRoom" runat="server" Width="120">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            会议主题：
                        </td>
                        <td height="30">
                            <asp:TextBox ID="txtMeetingSubject" CssClass="InputCss" runat="server" Columns="70"
                                Width="200"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            起始日期：
                        </td>
                        <td>
                            <asp:TextBox ID="txtBeginDate" onfocus="setday(this)" CssClass="InputCss" runat="server"
                                Columns="70" Width="120" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td align="right">
                            终止日期：
                        </td>
                        <td>
                            <asp:TextBox ID="txtEndDate" onfocus="setday(this)" CssClass="InputCss" runat="server"
                                Columns="70" Width="120" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td align="right">
                        </td>
                        <td height="30">
                     
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" CssClass="redbuttoncss" Text="查询" OnClientClick="return ock_Search();">
                            </asp:Button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataGrid ID="dbMeetingList" runat="server" OnPageIndexChanged="DataGrid_PageChanged"
                    BorderColor="#93BEE2" BorderStyle="None" BorderWidth="1px" BackColor="White"
                    CellPadding="3" PageSize="15" AllowPaging="True" AutoGenerateColumns="False"
                    DataKeyField="ID" Width="100%">
                    <SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
                    <AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
                    <ItemStyle Font-Size="X-Small"></ItemStyle>
                    <HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="White" BackColor="#337FB2">
                    </HeaderStyle>
                    <FooterStyle Font-Size="X-Small" HorizontalAlign="Right" BackColor="#E8F4FF"></FooterStyle>
                    <Columns>
                        <asp:BoundColumn DataField="MeetingType" HeaderText="会议类型" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle Width="15%"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="MeetingSubject" HeaderText="会议标题" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle Width="30%"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="MeetingRoom" HeaderText="会议室" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle Width="15%"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="BeginTime" HeaderText="开始时间" DataFormatString="{0:yyyy-MM-dd HH:mm}">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EndTime" HeaderText="结束时间" DataFormatString="{0:yyyy-MM-dd HH:mm}">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        
                    </Columns>
                    <PagerStyle Font-Size="X-Small" HorizontalAlign="left" BackColor="#E8F4FF" Mode="NumericPages">
                    </PagerStyle>
                </asp:DataGrid>
                <asp:Label runat="server" ID="LabelPageInfo" Font-Size="X-Small"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        </TABLE> </font>
    </form>
</body>
--%>
<body leftmargin="0" topmargin="0">
    <form id="Listview" method="post" runat="server">
   <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0"
        bordercolor="#111111" style="table-layout:fixed">
        <tr height="30">
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/myDoc2.gif" width="16">
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width="60"
                align="center">
                <font color="#006699">会议查询</font>
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right"> <asp:Button ID="btnSearch" runat="server" Width="80px" CssClass="redbuttoncss" Text="查询" OnClientClick="return ock_Search();">
                            </asp:Button>&nbsp;
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
                <table class="gbtext" id="Table3" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td align="right">
                            会议类型：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMeetingType" runat="server" Width="120">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            会 议 室：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMeetingRoom" runat="server" Width="120">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            会议主题：
                        </td>
                        <td height="30">
                            <asp:TextBox ID="txtMeetingSubject" CssClass="InputCss" runat="server" Columns="70"
                                Width="200"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            起始日期：
                        </td>
                        <td>
                            <asp:TextBox ID="txtBeginDate" onfocus="setday(this)" CssClass="InputCss" runat="server"
                                Columns="70" Width="120" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td align="right">
                            终止日期：
                        </td>
                        <td>
                            <asp:TextBox ID="txtEndDate" onfocus="setday(this)" CssClass="InputCss" runat="server"
                                Columns="70" Width="120" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td align="right">
                        </td>
                        <td height="30">
                        </td>
                        <td align="right">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="line-height: 20px;">
                <asp:DataGrid ID="dbMeetingList" runat="server" OnPageIndexChanged="DataGrid_PageChanged"
                    BorderColor="#93BEE2" BorderStyle="None" BorderWidth="1px" BackColor="White"
                    CellPadding="3" PageSize="15" AllowPaging="True" AutoGenerateColumns="False"
                    DataKeyField="ID" Width="100%">
                    <SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
                    <AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
                    <ItemStyle Font-Size="X-Small"></ItemStyle>
                    <HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="White" BackColor="#337FB2">
                    </HeaderStyle>
                    <FooterStyle Font-Size="X-Small" HorizontalAlign="Right" BackColor="#E8F4FF"></FooterStyle>
                    <Columns>
                        <asp:BoundColumn DataField="MeetingType" HeaderText="会议类型" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle Width="15%"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="MeetingSubject" HeaderText="会议标题" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle Width="30%"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="MeetingRoom" HeaderText="会议室" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle Width="15%"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="BeginTime" HeaderText="开始时间" DataFormatString="{0:yyyy-MM-dd HH:mm}">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EndTime" HeaderText="结束时间" DataFormatString="{0:yyyy-MM-dd HH:mm}">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                    </Columns>
                    <PagerStyle Font-Size="X-Small" HorizontalAlign="left" BackColor="#E8F4FF" Mode="NumericPages">
                    </PagerStyle>
                </asp:DataGrid>
                  <asp:Label runat="server" ID="LabelPageInfo" Font-Size="X-Small"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
