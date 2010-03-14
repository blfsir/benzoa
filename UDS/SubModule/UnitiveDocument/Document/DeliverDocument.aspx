<%@ Page language="c#" Codebehind="DeliverDocument.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.Document.DeliverDocument" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DeliverDocument</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body class="InputSta" MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0">
		<form id="DeliverDocument" method="post" encType="multipart/form-data" runat="server">
			<table border="0" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#111111" width="100%" id="AutoNumber4" height="1">
				<tr>
					<td width="20" height="30" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6" class="GbText"><img src="../../../Images/icon/057.GIF" width="8" height="16"></font></td>
					<td width="60" align="center" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6" class="GbText">上传文件</td>
					<td bgcolor="#c0d9e6" class="GbText" background="../../../Images/treetopbg.jpg">&nbsp;</td>
				</tr>
			</table>
			<table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
			  <tr>
			    <td height="10"></td>
		      </tr>
		  </table>
			<table width="98%" height="209" border="1" align="center" cellPadding="3" cellSpacing="0"bordercolor="#93bee2" id="AutoNumber1" style="BORDER-COLLAPSE: collapse" b>
				<tr>
					<td width="120" height="30"  align="middle" bgcolor="#e8f4ff" class="gbtext">文件主题：</td>
				  <td class="gbtext" height="19"><input id="txtTitle" type="text" size="68" name="DocTitle" runat="server" class="inputcss">
						<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtTitle"></asp:RequiredFieldValidator></td>
				</tr>
				<tr>
					<td width="120" height="30" align="middle" bgcolor="#e8f4ff" class="gbtext">文件注释：</td>
				  <td class="gbtext" height="82"><textarea id="txtContent" name="DocContent" rows="6" cols="79" runat="server" class="inputcss"></textarea></td>
				</tr>
				<tr>
					<td width="120" height="30"  align="middle" bgcolor="#e8f4ff" class="gbtext">文件作者：</td>
				  <td class="gbtext" height="19"><input id="txtAuthor" type="text" size="68" name="DocAuthor" runat="server" class="inputcss"></td>
				</tr>
				<tr>
					<td width="120" height="30"  align="middle" bgcolor="#e8f4ff" class="gbtext">文件来源：</td>
				  <td class="gbtext" height="19"><input id="txtFrom" type="text" size="68" name="DocCatalog" runat="server" class="inputcss"></td>
				</tr>
				<tr>
					<td width="120" height="30"  align="middle" bgcolor="#e8f4ff" class="gbtext">文件路径：</td>
				  <td class="gbtext" id="upid" height="19">&nbsp;&nbsp; <INPUT id="File1" type="file" name="File1" runat="server" class="inputcss">
						<asp:button id="btnUpload" runat="server" Text=">>" CssClass="buttoncss"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:listbox id="listUpDoc" runat="server" DataTextField="FileName" DataValueField="FileID" Width="115px" Height="73px" SelectionMode="Multiple" CssClass="inputcss"></asp:listbox><asp:button id="btnRemove" runat="server" Text=" 删 除 " CssClass="buttoncss"></asp:button></td>
				</tr>
				<tr>
					<td class="gbtext" colSpan="2" height="40" align="center"><asp:button id="btnSubmit" runat="server" Text=" 提 交 " CssClass="buttoncss"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnReturn" runat="server" Text=" 返 回 " CssClass="buttoncss" CausesValidation="False"></asp:button></td>
				</tr>
			</table>
			&nbsp;
<br>
			<br>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td style="WIDTH: 312px"><IMG height="25" src="../../../Images/temp.gif" width="250"></td>
					<td align="right"><IMG height="25" src="../../../Images/endbott.gif" width="279"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
