<%@ Page language="c#" Codebehind="DisplayStaffInfo.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.DisplayStaffInfo" %>
<HTML>
	<HEAD>
		<title>人员信息</title>
		<meta http-equiv="Content-Language" content="zh-cn">
		<meta name="GENERATOR" content="Microsoft FrontPage 5.0">
		<meta name="ProgId" content="FrontPage.Editor.Document">
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<link rel="stylesheet" href="../../Css/BasicLayout.css" type="text/css">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">

			<form id="DisplayStaffInfo" method="post" runat="server">
            <table border="0" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#111111" width="100%" id="AutoNumber4" height="1" background="../../Images/treetopbg.jpg">
						<tr>
							<td width="20" height="30" class="GbText"><font color="#003366" size="3"><img src="../../images/283.GIF" width="16" height="16"></font></td>
							<td width="60" height="1" align="center" class="GbText">人员信息</td>
							<td height="1" >&nbsp;
					    </td>
							<td height="1">&nbsp;
							</td>
			  </tr>
					</table>
							<table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
							  <tr>
							    <td height="10"></td>
						      </tr>
			  </table>
							<table width="98%" height="96" border="1" align="center" cellpadding="3" cellspacing="0" bordercolor="#93bee2" id="AutoNumber1" style="BORDER-COLLAPSE: collapse">
						<tr>
							<td height="30" class="Gbtext" align="middle" colspan="2">
								<asp:Label id="lblStaff_Name" runat="server"></asp:Label>
							</td>
						</tr>
						<tr>
							<td width='120' height='30' align="center" bgcolor="#e8f4ff" class='Gbtext'><b> 真实姓名：</b></td>
							<td height='30' class='Gbtext'>
								<asp:Label id="lblRealName" runat="server"></asp:Label>
							</td>
						</tr>
						<tr>
							<td width='120' height='30' align="center" bgcolor="#e8f4ff" class='Gbtext'><b>性&nbsp;&nbsp;别：</b></td>
							<td height='30' class='Gbtext'>
								<asp:Label id="lblSex" runat="server"></asp:Label>
							</td>
						</tr>
						<tr>
							<td width='120' height='30' align="center" bgcolor="#e8f4ff" class='Gbtext'><b>邮&nbsp;&nbsp;件：</b></td>
							<td height='30' class='Gbtext'>
								<asp:Label id="lblEmail" runat="server"></asp:Label>
							</td>
						</tr>
						<tr>
							<td width='120' height='30' align="center" bgcolor="#e8f4ff" class='Gbtext'><b> 注册日期：</b></td>
							<td height='30' class='Gbtext'>
								<asp:Label id="lblRegistedDate" runat="server"></asp:Label>
							</td>
						</tr>
						<tr>
							<td height="30" align="right" colspan="2">
								<input type="button" value="返回" onClick="javascript:history.go(-1)" class="redButtonCss">
							</td>
						</tr>
					</table>
					<table width="100%" border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td><img src="../../Images/temp.gif" width="250" height="25"></td>
							<td align="right"><img src="../../images/endbott.gif" width="279" height="25"></td>
					  </tr>
			  </table>

	</FORM>
	</body>
</HTML>
