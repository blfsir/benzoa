<%@ Page Language="c#" CodeBehind="ListView.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.Document.ListView" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>ListView</title>
    <meta content="True" name="vs_showGrid">
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">

    <script language="javascript">

		function MoveToTeam(a)
{
	var ret;
	ret = window.showModalDialog("../MoveTeam/TreeView.aspx?FromID=<%=ClassID%>",window,"dialogHeight:400px;dialogWidth:300px;center:Yes;Help:No;Resizable:No;Status:Yes;Scroll:auto;Status:no;");

	
	if(ret>0)
//	frmAddRight.ObjID.value = ret;
	return false;
}

		function CopyToTeam(a)
{
	var ret;
	ret = ret = window.showModalDialog("../CopyTeam/TreeView.aspx?FromID=<%=ClassID%>",window,"dialogHeight:400px;dialogWidth:300px;center:Yes;Help:No;Resizable:No;Status:Yes;Scroll:auto;Status:no;");

	
	if(ret>0)
//	frmAddRight.ObjID.value = ret;
	return false;
}
		function selectAll(){
			var len=document.Form1.elements.length;
			var i;
		    for (i=0;i<len;i++){
			if (document.Form1.elements[i].type=="checkbox"){
		        document.Form1.elements[i].checked=true;								
						 }
					}
				}

		function unSelectAll(){
	          var len=document.Form1.elements.length;
	          var i;
	          for (i=0;i<len;i++){
	               if (document.Form1.elements[i].type=="checkbox"){
	                  document.Form1.elements[i].checked=false; 
	               }   
	        	 } 
		    }		

		var ball1 = new Image();
		var ball2 = new Image();
		ball1.src = 'images/ball1.gif';
		ball2.src = 'images/ball2.gif';

		var active = new Image();
		var nonactive = new Image();
		active.src = '../../../images/maillistbutton2.gif';
		nonactive.src = '../../../images/maillistbutton1.gif';

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
    </script>

    <script language="JavaScript" src="../../../Css/tr.js"></script>

</head>
<%--<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <table bordercolor="#111111" height="1" cellspacing="0" cellpadding="0" width="100%"
        border="0">
        <tr>
            <td width="23" height="30" align="right" background="../../../Images/treetopbg.jpg"
                bgcolor="#c0d9e6" class="GbText" style="width: 23px">
                <font color="#003366" size="3">
                    <img height="16" src="../../../DataImages/page.gif" width="16"></font>
            </td>
            <td class="GbText" align="center" width="60" background="../../../Images/treetopbg.jpg"
                bgcolor="#e8f4ff">
                <asp:Label ID="lblTitle" runat="server" ForeColor="#006699" Font-Names="宋体" Font-Size="X-Small"
                    Width="53px">  公司论坛</asp:Label>
            </td>
            <td class="GbText" align="right" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff">
                &nbsp;
            </td>
        </tr>
    </table>
    <font face="宋体">
        <table width="98%" border="0" align="center" cellpadding="5" cellspacing="0">
            <tr>
                <td colspan="2">
                    <table cellspacing="0" cellpadding="0" width="500" border="0">
                        <tr height="25">
                            <td id="bar1" align="center" width="90" background='<% Response.Write(DisplayType=="0"?"../../../images/maillistbutton2.gif":"../../../images/maillistbutton1.gif"); %>'>
                                &nbsp;<a href="ListView.aspx?ClassID=<%=ClassID%>&amp;DisplayType=0" class="Newbutton">已归档</a>
                            </td>
                            <td id="bar2" align="center" width="90" background='<% Response.Write(DisplayType=="1"?"../../../images/maillistbutton2.gif":"../../../images/maillistbutton1.gif"); %>'>
                                &nbsp;<a href="ListView.aspx?ClassID=<%=ClassID%>&amp;DisplayType=1" class="Newbutton">未归档</a>
                            </td>
                            <td id="bar3" align="center" width="90" background='<% Response.Write(DisplayType=="2"?"../../../images/maillistbutton2.gif":"../../../images/maillistbutton1.gif"); %>'>
                                &nbsp;<a href="ListView.aspx?ClassID=<%=ClassID%>&amp;DisplayType=2" class="Newbutton">我的上传</a>
                            </td>
                            <td id="bar4" align="center" width="90" background='<% Response.Write(DisplayType=="3"?"../../../images/maillistbutton2.gif":"../../../images/maillistbutton1.gif"); %>'>
                                &nbsp;<a href="ListView.aspx?ClassID=<%=ClassID%>&amp;DisplayType=3" class="Newbutton">回收站</a>
                            </td>
                            <td width="136">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:DataGrid ID="dgDocList" runat="server" DataKeyField="DocID" OnSortCommand="DataGrid_Sort"
                        CellPadding="3" BorderWidth="1px" BorderColor="#93BEE2" PageSize="15" OnPageIndexChanged="DataGrid_PageChanged"
                        PagerStyle-HorizontalAlign="Right" PagerStyle-Mode="NumericPages" AllowPaging="True"
                        AutoGenerateColumns="False" AllowSorting="True" Width="100%">
                        <AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
                        <HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Height="10px" ForeColor="White"
                            VerticalAlign="Top" BackColor="#337FB2"></HeaderStyle>
                        <FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom">
                        </FooterStyle>
                        <Columns>
                            <asp:TemplateColumn HeaderText="选择">
                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" Height="20px" Width="60px">
                                </ItemStyle>
                                <ItemTemplate>
                                    <asp:CheckBox ID="Checkbox1" Checked="False" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn SortExpression="DocTitle" HeaderText="文档主题">
                                <HeaderStyle Font-Underline="True"></HeaderStyle>
                                <ItemStyle Font-Size="X-Small"></ItemStyle>
                                <ItemTemplate>
                                    <a href="#" onclick='window.showModalDialog("BrowseDocument.aspx?DocId=<%# DataBinder.Eval(Container.DataItem,"DocID") %>",window,"dialogWidth:700px;DialogHeight=590px;status:no")'>
                                        <%# (DataBinder.Eval(Container.DataItem,"DocTitle").ToString().Length>30)?DataBinder.Eval(Container.DataItem,"DocTitle").ToString().Substring(0,30)+"...":DataBinder.Eval(Container.DataItem,"DocTitle").ToString() %>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="DocApprover" SortExpression="DocApprover" HeaderText="审批人">
                                <ItemStyle Font-Size="X-Small"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DocAddedBy" SortExpression="DocAddedBy" HeaderText="上传人">
                                <ItemStyle Font-Size="X-Small"></ItemStyle>
                                <FooterStyle Font-Size="X-Small"></FooterStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DocAddedDate" SortExpression="DocAddedDate" HeaderText="上传日期">
                                <ItemStyle Font-Size="X-Small"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DocViewedTimes" SortExpression="DocViewedTimes" HeaderText="浏览次数">
                                <HeaderStyle Font-Size="X-Small"></HeaderStyle>
                                <ItemStyle Font-Size="X-Small"></ItemStyle>
                                <FooterStyle Font-Size="XX-Small"></FooterStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DocLastViewer" SortExpression="DocLastViewer" HeaderText="最后浏览者">
                                <ItemStyle Font-Size="X-Small"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="DocLastViewDate" SortExpression="DocLastViewDate"
                                HeaderText="浏览日期">
                                <HeaderStyle Font-Underline="True"></HeaderStyle>
                                <ItemStyle Font-Size="X-Small"></ItemStyle>
                                <FooterStyle Font-Size="XX-Small"></FooterStyle>
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle Font-Size="12px" BorderColor="#E0E0E0" BorderStyle="Dotted" HorizontalAlign="Right"
                            BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    &nbsp;<font size="X-Small"><a onclick="selectAll()" href="#"><font size="2">全部选择</font></a>
                        &nbsp; <a onclick="unSelectAll()" href="#"><font size="2">全部取消</font></a>&nbsp;</font>&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkbtnDelete" runat="server" Font-Size="X-Small" CausesValidation="False"
                        OnClick="lnkbtnDelete_Click">丢弃</asp:LinkButton>&nbsp;&nbsp;&nbsp; <font size="2"><a
                            onclick="MoveToTeam()" href="#">
                            <asp:Label ID="lblRemove" runat="server" Font-Size="X-Small"> 目录移动</asp:Label></a><font
                                size="3">&nbsp; <a onclick="CopyToTeam()" href="#">
                                    <asp:Label ID="lblCopy" runat="server">目录复制</asp:Label></a>&nbsp;&nbsp;&nbsp;
                            </font><a href="../Switch.aspx?ClassID=<%=ClassID%>&amp;Action=0">
                                <asp:Label ID="lblDeliveryDoc" runat="server" Font-Size="X-Small">投递文档</asp:Label></a><font
                                    size="3">&nbsp; </font><a href="../oClassNode.aspx?Action=3&amp;ClassID=<%=ClassID%>">
                                        <asp:Label ID="lblManageDirectory" runat="server" Font-Size="X-Small"> 目录管理</asp:Label></a><font
                                            size="3">&nbsp; </font><a href="../MemberListView.aspx?TeamID=<%=ClassID%>">
                                                <asp:Label ID="lblShowMember" runat="server" Font-Size="X-Small">显示组员</asp:Label></a><font
                                                    size="3">&nbsp; </font><a href="../../AssignRule/RightListView.aspx?ObjID=<%=ClassID%>&amp;displayType=1">
                                                        <asp:Label ID="lblManagePermission" runat="server" Font-Size="X-Small"> 权限管理</asp:Label></a></font>
                </td>
            </tr>
        </table>
        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <input type="button" value="返回" onclick="javascript:history.go(-1)" class="redButtonCss">
                </td>
            </tr>
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="3" rules="all" bordercolor="#93BEE2" border="1"
                        id="Table1" style="border-color: #93BEE2; border-width: 1px; border-style: solid;
                        width: 100%; border-collapse: collapse;">
                        <tr align="center" valign="top" style="color: White; background-color: #337FB2; font-size: X-Small;
                            height: 10px;">
                            <td colspan="7">
                                文档管理
                            </td>
                        </tr>
                        <asp:Repeater ID="rptChildDocList" runat="server">
                            <ItemTemplate>
                                <tr align="left" valign="top" style="font-size: X-Small; height: 10px;">
                                    <td colspan="7">
                                        <a href="../Switch.aspx?Action=1&ClassID=<%# DataBinder.Eval(Container.DataItem, "ClassID")%>">
                                            <%# DataBinder.Eval(Container.DataItem, "ClassName")%></a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
        </table>
    </font>
    </form>
</body>--%>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
    <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0"
        bordercolor="#111111">
        <tr>
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/myDoc2.gif" width="16">
            </td>
            <td width="60" height="30" align="center" background="../../../Images/treetopbg.jpg"
                bgcolor="#e8f4ff" class="GbText">
                文档管理
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
                <font face="宋体">
               
                    <asp:Button ID="btnThowAwayDocument" runat="server" Text="丢弃文档" CssClass="redButtonCss" Visible="false">
                    </asp:Button>&nbsp;</font>
            </td>
        </tr>
    </table>
    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" id="Table1">
        <tr>
            <td>
                <table cellspacing="0" cellpadding="0" width="500" border="0">
                 <tr>
                        <td height="10" colspan="5" align="center">
                        </td>
                    </tr>
                        <tr height="25">
                            <td id="bar1" align="center" width="90" background='<% Response.Write(DisplayType=="0"?"../../../images/maillistbutton2.gif":"../../../images/maillistbutton1.gif"); %>'>
                                &nbsp;<a href="ListView.aspx?ClassID=<%=ClassID%>&amp;DisplayType=0" class="Newbutton">已归档</a>
                            </td>
                            <td id="bar2" align="center" width="90" background='<% Response.Write(DisplayType=="1"?"../../../images/maillistbutton2.gif":"../../../images/maillistbutton1.gif"); %>'>
                                &nbsp;<a href="ListView.aspx?ClassID=<%=ClassID%>&amp;DisplayType=1" class="Newbutton">未归档</a>
                            </td>
                            <td id="bar3" align="center" width="90" background='<% Response.Write(DisplayType=="2"?"../../../images/maillistbutton2.gif":"../../../images/maillistbutton1.gif"); %>'>
                                &nbsp;<a href="ListView.aspx?ClassID=<%=ClassID%>&amp;DisplayType=2" class="Newbutton">我的上传</a>
                            </td>
                            <td id="bar4" align="center" width="90" background='<% Response.Write(DisplayType=="3"?"../../../images/maillistbutton2.gif":"../../../images/maillistbutton1.gif"); %>'>
                                &nbsp;<a href="ListView.aspx?ClassID=<%=ClassID%>&amp;DisplayType=3" class="Newbutton">回收站</a>
                            </td>
                            <td width="136">
                            </td>
                        </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td style="line-height: 20px;">
                 <asp:DataGrid ID="dgDocList" runat="server" DataKeyField="DocID" OnSortCommand="DataGrid_Sort"
                        CellPadding="3" BorderWidth="1px" BorderColor="#93BEE2" PageSize="15" OnPageIndexChanged="DataGrid_PageChanged"
                        PagerStyle-HorizontalAlign="Right" PagerStyle-Mode="NumericPages" AllowPaging="True"
                        AutoGenerateColumns="False" AllowSorting="True" Width="100%">
                        <AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
                        <HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Height="10px" ForeColor="White"
                            VerticalAlign="Top" BackColor="#337FB2"></HeaderStyle>
                        <FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom">
                        </FooterStyle>
                        <Columns>
                            <asp:TemplateColumn HeaderText="选择">
                                <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" Height="20px" Width="60px">
                                </ItemStyle>
                                <ItemTemplate>
                                    <asp:CheckBox ID="Checkbox1" Checked="False" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn SortExpression="DocTitle" HeaderText="文档主题">
                                <HeaderStyle Font-Underline="True"></HeaderStyle>
                                <ItemStyle Font-Size="X-Small"></ItemStyle>
                                <ItemTemplate>
                                    <a href="#" onclick='window.showModalDialog("BrowseDocument.aspx?DocId=<%# DataBinder.Eval(Container.DataItem,"DocID") %>",window,"dialogWidth:700px;DialogHeight=590px;status:no")'>
                                        <%# (DataBinder.Eval(Container.DataItem,"DocTitle").ToString().Length>30)?DataBinder.Eval(Container.DataItem,"DocTitle").ToString().Substring(0,30)+"...":DataBinder.Eval(Container.DataItem,"DocTitle").ToString() %>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="DocApprover" SortExpression="DocApprover" HeaderText="审批人">
                                <ItemStyle Font-Size="X-Small"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DocAddedBy" SortExpression="DocAddedBy" HeaderText="上传人">
                                <ItemStyle Font-Size="X-Small"></ItemStyle>
                                <FooterStyle Font-Size="X-Small"></FooterStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DocAddedDate" SortExpression="DocAddedDate" HeaderText="上传日期">
                                <ItemStyle Font-Size="X-Small"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DocViewedTimes" SortExpression="DocViewedTimes" HeaderText="浏览次数">
                                <HeaderStyle Font-Size="X-Small"></HeaderStyle>
                                <ItemStyle Font-Size="X-Small"></ItemStyle>
                                <FooterStyle Font-Size="XX-Small"></FooterStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DocLastViewer" SortExpression="DocLastViewer" HeaderText="最后浏览者">
                                <ItemStyle Font-Size="X-Small"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="DocLastViewDate" SortExpression="DocLastViewDate"
                                HeaderText="浏览日期">
                                <HeaderStyle Font-Underline="True"></HeaderStyle>
                                <ItemStyle Font-Size="X-Small"></ItemStyle>
                                <FooterStyle Font-Size="XX-Small"></FooterStyle>
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle Font-Size="12px" BorderColor="#E0E0E0" BorderStyle="Dotted" HorizontalAlign="Right"
                            BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>
            </td>
        </tr>
         <tr>
                <td valign="top">
                    &nbsp;<font size="X-Small"><a onclick="selectAll()" href="#"><font size="2">全部选择</font></a>
                        &nbsp; <a onclick="unSelectAll()" href="#"><font size="2">全部取消</font></a>&nbsp;</font>&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkbtnDelete" runat="server" Font-Size="X-Small" CausesValidation="False"
                        OnClick="lnkbtnDelete_Click">丢弃</asp:LinkButton>&nbsp;&nbsp;&nbsp; <font size="2"><a
                            onclick="MoveToTeam()" href="#">
                            <asp:Label ID="lblRemove" runat="server" Font-Size="X-Small"> 目录移动</asp:Label></a><font
                                size="3">&nbsp; <a onclick="CopyToTeam()" href="#">
                                    <asp:Label ID="lblCopy" runat="server">目录复制</asp:Label></a>&nbsp;&nbsp;&nbsp;
                            </font><a href="../Switch.aspx?ClassID=<%=ClassID%>&amp;Action=0">
                                <asp:Label ID="lblDeliveryDoc" runat="server" Font-Size="X-Small">投递文档</asp:Label></a><font
                                    size="3">&nbsp; </font><a href="../oClassNode.aspx?Action=3&amp;ClassID=<%=ClassID%>">
                                        <asp:Label ID="lblManageDirectory" runat="server" Font-Size="X-Small"> 目录管理</asp:Label></a><font
                                            size="3">&nbsp; </font><a href="../MemberListView.aspx?TeamID=<%=ClassID%>">
                                                <asp:Label ID="lblShowMember" runat="server" Font-Size="X-Small">显示组员</asp:Label></a><font
                                                    size="3">&nbsp; </font><a href="../../AssignRule/RightListView.aspx?ObjID=<%=ClassID%>&amp;displayType=1">
                                                        <asp:Label ID="lblManagePermission" runat="server" Font-Size="X-Small"> 权限管理</asp:Label></a></font>
                </td>
            </tr>
            
         </table>
     <br /><br />
     
     <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0"
        bordercolor="#111111">
        
        <tr>
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/myDoc2.gif" width="16">
            </td>
            <td width="60" height="30" align="center" background="../../../Images/treetopbg.jpg"
                bgcolor="#e8f4ff" class="GbText">
                子文档管理
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
               
                          <input class="redButtonCss" onclick="javascript:history.go(-1)"  type="button" value="返回" visible="false">
            </td>
        </tr>
    </table>
    
      <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
     
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="3" rules="all" bordercolor="#93BEE2" border="1"
                        id="Table3" style="border-color: #93BEE2; border-width: 1px; border-style: solid;
                        width: 100%; border-collapse: collapse;">
                        <tr align="center" valign="top" style="color: White; background-color: #337FB2; font-size: X-Small;
                            height: 10px;">
                            <td colspan="7">
                                子文档列表
                            </td>
                        </tr>
                        <asp:Repeater ID="rptChildDocList" runat="server">
                            <ItemTemplate>
                                <tr align="left" valign="top" style="font-size: X-Small; height: 10px;">
                                    <td colspan="7">
                                        <a href="../Switch.aspx?Action=1&ClassID=<%# DataBinder.Eval(Container.DataItem, "ClassID")%>">
                                            <%# DataBinder.Eval(Container.DataItem, "ClassName")%></a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
