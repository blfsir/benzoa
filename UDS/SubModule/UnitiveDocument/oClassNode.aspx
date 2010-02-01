<%@ Page language="c#" Codebehind="oClassNode.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.oClassNode" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>oClassNode</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0">
		<form id="oClassNode" method="post" runat="server">
			<table border="0" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#111111" width="100%" id="AutoNumber4" height="1">
				<tr height="30">
					<td width="3%" bgcolor="#c0d9e6" class="GbText" background="../../Images/treetopbg.jpg"><IMG height="16" src="../../Images/icon/034.GIF" width="16"></td>
					<td bgcolor="#c0d9e6" class="GbText" background="../../Images/treetopbg.jpg" width="80"><b>目录管理</b></td>
					<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" align="right"><A 
      href="oClassNode.aspx?Action=1&amp;ClassID=<%=ClassID%>">
							<asp:Label id="lblCreate" runat="server">新增</asp:Label></A>&nbsp; <A href="oClassNode.aspx?Action=3&amp;ClassID=<%=ClassID%>">
							<asp:Label id="lblRevise" runat="server">修改</asp:Label></A><FONT face="宋体">&nbsp;
						</FONT><A 
      href="oClassNode.aspx?Action=2&amp;ClassID=<%=ClassID%>">
							<asp:Label id="lblDelete" runat="server">删除</asp:Label></A></TD>
				</tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" bordercolor="#111111" width="100%" id="AutoNumber1" height="73">
				<tr>
					<td width="63" align="right" height="1" class="Gbtext" style="WIDTH: 63px"><FONT face="宋体"></FONT>
					</td>
					<td width="82%" align="left" height="1" class="Gbtext">&nbsp;
					</td>
				</tr>
				<tr>
					<td width="63" align="right" height="1" class="Gbtext" style="WIDTH: 63px">父接点名：
					</td>
					<td width="82%" align="left" height="1" class="Gbtext">
						<asp:Label id="lblParentNodeName" runat="server"></asp:Label>
					</td>
				</tr>
				<tr>
					<td width="63" align="right" height="18" class="Gbtext" style="WIDTH: 63px">
						接点名称：</td>
					<td width="82%" align="left" height="18" class="Gbtext">
						<asp:TextBox id="txtAClassName" runat="server" Width="358px" CssClass="inputcss"></asp:TextBox></td>
				</tr>
				<tr>
					<td width="63" align="right" height="18" class="Gbtext" style="WIDTH: 63px">
						接点类型：</td>
					<td width="82%" align="left" height="18" class="Gbtext">
						<asp:DropDownList id="listNodeType" runat="server" Width="360px">
							<asp:ListItem Value="1" Selected="True">目录</asp:ListItem>
						</asp:DropDownList></td>
				</tr>
				<tr>
					<td width="63" align="right" height="72" class="Gbtext" valign="top" style="WIDTH: 63px">
						<p>
							类型简介：</p>
					</td>
					<td width="82%" align="left" height="72" class="Gbtext">
						<asp:TextBox id="txtAClassRemark" runat="server" Width="358px" TextMode="MultiLine" Height="142px"></asp:TextBox></td>
				</tr>
				<tr>
					<td width="100%" align="middle" colspan="2" height="30">
						<asp:Button id="btnAdd" runat="server" Text="添加" CssClass="ButtonCss"></asp:Button>&nbsp;&nbsp;
						<asp:Button id="btnRevise" runat="server" Text="修改" CssClass="ButtonCss"></asp:Button>&nbsp;&nbsp;
						<asp:Button id="btnDelete" runat="server" CssClass="ButtonCss" Text="删除" Visible="False"></asp:Button>&nbsp;
						<input type="button" value="返 回" name="cmdAddBack" class="ButtonCss" OnClick="javascript:self.location='Document/ListView.aspx?classID=<%=ClassID%>'">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
				</tr>
				<tr>
					<td width="100%" align="middle" colspan="2" height="19">
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
