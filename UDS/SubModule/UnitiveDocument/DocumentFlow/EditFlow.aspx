<%@ Page language="c#" Codebehind="EditFlow.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.DocumentFlow.Flow" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Flow</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">

	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0" rightmargin="0">
		<form id="Flow" method="post" runat="server">
			<FONT face="����">
            <TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"
										align="right"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/DocFlow.gif" width="16"></FONT></TD>
									<TD width="60" height="30"
										align="center" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" class="GbText">�ĵ���ת</TD>
									<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="right"><FONT face="����">&nbsp;&nbsp;&nbsp;</FONT></TD>
								</TR>
							</TABLE></FONT>
			<table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
			  <tr>
			    <td height="10"></td>
			    </tr>
			  </table>
			<table width="98%" border="1" align="center" cellpadding="3" cellspacing="0" class="gbtext" id="Table2" bordercolor="#93bee2">
			  <tr>
			    <td width="120" height="30" align="center" bgcolor="#e8f4ff" ><asp:Label ID="Label1" runat="server" Width="67px" Height="8px"><font face="����">�� �� ��</font></asp:Label></td>
			    <td><font face="����">
			      <asp:TextBox ID="txtFlowName" runat="server" Width="475px" MaxLength="300" CssClass="inputcss"></asp:TextBox>
			      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="������������" ControlToValidate="txtFlowName"></asp:RequiredFieldValidator>
			      </font></td>
		      </tr>
			  <tr>
			    <td width="120" height="30" align="center" bgcolor="#e8f4ff" class="Gbtext"><font face="����">�ϴ�����ͼ��</font></td>
			    <td align="left" class="Gbtext"><font face="����">
			      <input class="INPUTCSS" id="hif" style="WIDTH: 185px; HEIGHT: 19px" type="file" size="11" runat="server">
			      &nbsp;
			      <asp:DropDownList ID="ddl_FileType" runat="server">
			        <asp:ListItem Value="picture">ͼƬ</asp:ListItem>
		        </asp:DropDownList>
		        &nbsp; </font></td>
		      </tr>
			  <tr>
			    <td width="120" height="30" align="center" bgcolor="#e8f4ff" ><asp:Label ID="Label4" runat="server" Width="66px" Height="13px"><font face="����">�������</font></asp:Label></td>
			    <td><font face="����">
		        <asp:TextBox ID="txtFlowClass" runat="server" Width="475px" MaxLength="300" CssClass="inputcss"></asp:TextBox>
			      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="�������������" ControlToValidate="txtFlowClass"></asp:RequiredFieldValidator>
		        </font></td>
		      </tr>
			  <tr>
			    <td width="120" height="30" align="center" bgcolor="#e8f4ff" ><asp:Label ID="Label3" runat="server" Width="66px" Height="13px"><font face="����">����ʽ</font></asp:Label></td>
			    <td><font face="����">
		        <asp:DropDownList ID="dpStyle" runat="server" Width="475px" Height="22px"></asp:DropDownList>
		        </font></td>
		      </tr>
			  <tr>
			    <td width="120" height="30" align="center" bgcolor="#e8f4ff" ><asp:Label ID="Label2" runat="server" Width="65px" Height="16px"><font face="����">���̼��</font></asp:Label></td>
			    <td><font face="����">
			      <asp:TextBox ID="txtFlowRemark" runat="server" Width="475px" Height="148px" TextMode="MultiLine"></asp:TextBox>
			    </font></td>
		      </tr>
			  <tr>
			    <td colspan="2" align="right" height="40"><font face="����">
			      <asp:Button ID="cmdPrevious" AccessKey="P" runat="server" Width="70px" CssClass="buttoncss"
								Text="��һ��" Enabled="False"></asp:Button>
			      &nbsp;
			      <asp:Button ID="cmdNext" runat="server" Width="70px" Text="��һ��" CssClass="buttoncss" AccessKey="N"></asp:Button>
			      &nbsp;
			      <asp:Button ID="cmdFinish" AccessKey="F" runat="server" Width="82px" CssClass="buttoncss" Text="������"></asp:Button>
			      &nbsp;
			      <asp:Button ID="cmdCancel" AccessKey="C" runat="server" Width="86px" CssClass="buttoncss" Text="ȡ�����"
								CausesValidation="False"></asp:Button>
			      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></td>
		      </tr>
		  </table>
        </form>
	</body>
</HTML>
