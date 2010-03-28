<%@ Page Language="c#" CodeBehind="Listview.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.NewDoc.Listview" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Listview</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

    <script language="javascript">
		
		function selectAll(){
			var len=document.Listview.elements.length;
			var i;
		    for (i=0;i<len;i++){
			if (document.Listview.elements[i].type=="checkbox"){
		        document.Listview.elements[i].checked=true;								
						 }
					}
				}

		function unSelectAll(){
	          var len=document.Listview.elements.length;
	          var i;
	          for (i=0;i<len;i++){
	               if (document.Listview.elements[i].type=="checkbox"){
	                  document.Listview.elements[i].checked=false; 
	               }   
	        	 } 
		    }		

    </script>

    <link href="../../../Css/basiclayout.css" type="text/css" rel="stylesheet">
</head>
<body leftmargin="0" topmargin="0">
    <form id="Listview" method="post" runat="server">
    <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0"
        bordercolor="#111111">
        <tr>
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/myDoc2.gif" width="16">
            </td>
            <td width="60" height="30" align="center" background="../../../Images/treetopbg.jpg"
                bgcolor="#e8f4ff" class="GbText">
                <font color="#006699">我的文档</font>
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
                <font face="宋体">
                    <input class="redButtonCss" onclick="selectAll()" type="button" value="全部选择">
                    <input type="button" onclick="unSelectAll()" value="全部取消" class="redButtonCss">
                    <asp:Button ID="btnThowAwayDocument" runat="server" Text="丢弃文档" CssClass="redButtonCss">
                    </asp:Button>&nbsp;</font>
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
                    <tr>
                        <td align="center" width="90" background="../../../images/maillistbutton2.gif" height="24"
                            class="Newbutton">
                            &nbsp;已归档
                        </td>
                        <td align="center" width="90" background="../../../images/maillistbutton1.gif" height="24">
                            &nbsp;<a href="../Approve/Listview.aspx" class="Newbutton">待审批</a>
                        </td>
                        <td align="right">
                            <font face="宋体">&nbsp; </font>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="line-height: 20px;">
                <asp:DataGrid ID="dgDocList" runat="server" DataKeyField="DocID" ShowFooter="True"
                    OnSortCommand="DataGrid_SortCommand" CellPadding="5" BorderWidth="1px" BorderColor="#93BEE2"
                    OnPageIndexChanged="DataGrid_PageChanged" PageSize="15" Width="100%" PagerStyle-HorizontalAlign="Right"
                    PagerStyle-Mode="NumericPages" AllowPaging="True" AutoGenerateColumns="False"
                    AllowSorting="True" Font-Names="Arial">
                    <AlternatingItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E8F4FF">
                    </AlternatingItemStyle>
                    <ItemStyle Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    <HeaderStyle Font-Size="12px" HorizontalAlign="Center" Height="10px" ForeColor="White"
                        VerticalAlign="Top" BackColor="#337FB2"></HeaderStyle>
                    <FooterStyle Font-Size="12px" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom">
                    </FooterStyle>
                    <Columns>
                        <asp:TemplateColumn HeaderText="◎">
                            <HeaderStyle Width="5%"></HeaderStyle>
                            <ItemTemplate>
                                <font face="宋体">
                                    <asp:CheckBox ID="DocID" runat="server"></asp:CheckBox></font>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn SortExpression="DocTitle" HeaderText="文档标题">
                            <HeaderStyle HorizontalAlign="Center" Width="25%" Height="25px"></HeaderStyle>
                            <ItemStyle Font-Size="12px" HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <a href='../Document/BrowseDocument.aspx?DocId=<%# DataBinder.Eval(Container.DataItem,"DocID") %>'>
                                    <%# (DataBinder.Eval(Container.DataItem,"DocTitle").ToString().Length>30)?DataBinder.Eval(Container.DataItem,"DocTitle").ToString().Substring(0,30)+"...":DataBinder.Eval(Container.DataItem,"DocTitle").ToString() %>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="DocViewedTimes" SortExpression="DocViewedTimes" HeaderText="浏览次数">
                            <HeaderStyle Width="10%"></HeaderStyle>
                            <ItemStyle Font-Size="12px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:TemplateColumn SortExpression="DocApprover" HeaderText="审批人">
                            <HeaderStyle Width="10%"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# GetRealName(DataBinder.Eval(Container, "DataItem.DocApprover").ToString()) %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn SortExpression="DocAddedBy" HeaderText="上传人">
                            <HeaderStyle Width="10%"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# GetRealName(DataBinder.Eval(Container, "DataItem.DocAddedBy").ToString()) %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:HyperLinkColumn DataNavigateUrlField="ClassID" DataNavigateUrlFormatString="../Project.aspx?ClassID={0}"
                            DataTextField="ClassName" SortExpression="ClassName" HeaderText="所属项目">
                            <HeaderStyle Width="20%"></HeaderStyle>
                            <ItemStyle Font-Size="Smaller" HorizontalAlign="Center"></ItemStyle>
                        </asp:HyperLinkColumn>
                        <asp:TemplateColumn SortExpression="DocAddedDate" HeaderText="上传日期">
                            <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                            <ItemStyle Font-Size="12px" HorizontalAlign="Center"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DocAddedDate") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle Font-Size="12px" BorderColor="#E0E0E0" BorderStyle="Dotted" HorizontalAlign="Right"
                        ForeColor="White" BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
                </asp:DataGrid>
            </td>
        </tr>
        </td></tr></table>
    </form>
</body>
</html>
