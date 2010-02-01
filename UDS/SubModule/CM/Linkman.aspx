<%@ Page language="c#" Codebehind="Linkman.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.CM.Linkman" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Linkman</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body topmargin="5">
		<form id="Linkman" method="post" runat="server">
			<FONT face="����">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="1" style="BORDER-COLLAPSE: collapse"
					borderColor="#93bee2" align="center" class="gbtext">
					<TR>
						<TD bgcolor="#e8f4ff">&nbsp;�ͻ�����</TD>
						<TD colSpan="2">
							<asp:DropDownList id="ddl_ClientName" runat="server"></asp:DropDownList></TD>
						<TD colSpan="3">
							<asp:CheckBox id="cb_chief" runat="server" Text="��Ϊ��������"></asp:CheckBox></TD>
					</TR>
					<TR>
						<TD bgcolor="#e8f4ff">&nbsp;����</TD>
						<TD style="WIDTH: 212px">
							<asp:TextBox id="tb_Name" runat="server" CssClass="inputcss"></asp:TextBox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="tb_Name" ErrorMessage="RequiredFieldValidator"
								Display="Dynamic">��������Ϊ��</asp:RequiredFieldValidator></TD>
						<TD bgcolor="#e8f4ff">�ƶ��绰</TD>
						<TD>
							<asp:TextBox id="tb_Mobile" runat="server" CssClass="inputcss"></asp:TextBox>
							<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="��������" ControlToValidate="tb_Mobile"
								ValidationExpression="\d*" Display="Dynamic"></asp:RegularExpressionValidator></TD>
						<TD bgcolor="#e8f4ff" style="WIDTH: 31px">�绰</TD>
						<TD>
							<asp:TextBox id="tb_Telephone" runat="server" CssClass="inputcss"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD bgcolor="#e8f4ff">&nbsp;ְ��</TD>
						<TD style="WIDTH: 212px">
							<asp:TextBox id="tb_Position" runat="server" CssClass="inputcss"></asp:TextBox></TD>
						<TD bgcolor="#e8f4ff">EMAIL</TD>
						<TD>
							<asp:TextBox id="tb_Email" runat="server" CssClass="inputcss"></asp:TextBox>
							<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="tb_Email" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
								Display="Dynamic">Email��ʽ����</asp:RegularExpressionValidator></TD>
						<TD bgcolor="#e8f4ff" style="WIDTH: 31px">�Ա�</TD>
						<TD>
							<asp:DropDownList id="ddl_Gender" runat="server">
								<asp:ListItem Value="1" Selected="True">��</asp:ListItem>
								<asp:ListItem Value="0">Ů</asp:ListItem>
							</asp:DropDownList></TD>
					</TR>
					<TR>
						<TD bgcolor="#e8f4ff">&nbsp;����˵��</TD>
						<TD colSpan="5">
							<asp:TextBox id="tb_Description" runat="server" Width="500px" TextMode="MultiLine"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD bgcolor="#e8f4ff">&nbsp;��ͥסַ</TD>
						<TD colSpan="5">
							<asp:TextBox id="tb_Address" runat="server" Width="500px" TextMode="MultiLine"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD bgcolor="#e8f4ff">&nbsp;��Ů���</TD>
						<TD colSpan="5">
							<asp:TextBox id="tb_Family" runat="server" Width="500px" TextMode="MultiLine"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD colSpan="6" align="center">
							<asp:Button id="btn_OK" runat="server" Text=" ȷ �� " Width="60px" CssClass="buttoncss"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Button id="btn_Del" runat="server" Text=" ɾ �� " CssClass="buttoncss" CausesValidation="False"></asp:Button></TD>
					</TR>
				</TABLE>
			</FONT>
			<DIV style="DISPLAY: inline; WIDTH: 763px; HEIGHT: 15px" align="center" ms_positioning="FlowLayout"><FONT face="����"><a href="javascript:close();">�رմ���</a></FONT></DIV>
		</form>
	</body>
</HTML>
