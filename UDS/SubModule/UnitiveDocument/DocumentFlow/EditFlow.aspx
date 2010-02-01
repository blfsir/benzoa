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
	    <style type="text/css">
            .style1
            {
                width: 206px;
                height: 33px;
            }
            .style2
            {
                height: 33px;
            }
        </style>
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0" rightmargin="0">
		<form id="Flow" method="post" runat="server">
			<FONT face="����">
				<TABLE class="gbtext" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td vAlign="top" height="38" colspan="2"><TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR height="30">
									<TD class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"
										align="right"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/DocFlow.gif" width="16"></FONT></TD>
									<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="60"
										align="right"><font color="#006699">�ĵ���ת</font></TD>
									<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="right"><FONT face="����">&nbsp;&nbsp;&nbsp;</FONT></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD align="right" width="206" class="style1">
							<asp:Label id="Label1" runat="server" Width="67px" Height="8px">�� �� ��</asp:Label>&nbsp;</TD>
						<TD class="style2">
							<asp:TextBox id="txtFlowName" runat="server" Width="475px" MaxLength="300" CssClass="inputcss"></asp:TextBox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="������������" ControlToValidate="txtFlowName"></asp:RequiredFieldValidator></TD>
					</TR>
					    
					    <TR>
					<TD class="Gbtext" align="right" height="30"><FONT face="����">�ϴ�����ͼ��</FONT></TD>
					<TD class="Gbtext" align="left" height="21"><FONT face="����"><INPUT class="INPUTCSS" id="hif" style="WIDTH: 185px; HEIGHT: 19px" type="file" size="11" runat="server">&nbsp;
							<asp:dropdownlist id="ddl_FileType" runat="server">
								<asp:ListItem Value="picture">ͼƬ</asp:ListItem>
								 
							</asp:dropdownlist>&nbsp;
						 </TD>
					 
				</TR>
					    
					    
					<TR>
						<TD align="right" height="12" style="WIDTH: 206px; HEIGHT: 12px">
							<asp:Label id="Label4" runat="server" Width="66px" Height="13px">�������</asp:Label>&nbsp;</TD>
						<TD height="12" style="HEIGHT: 12px">
							<asp:TextBox id="txtFlowClass" runat="server" Width="475px" MaxLength="300" CssClass="inputcss"></asp:TextBox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="�������������" ControlToValidate="txtFlowClass"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD align="right" height="12" style="WIDTH: 206px; HEIGHT: 12px">
							<asp:Label id="Label3" runat="server" Width="66px" Height="13px">����ʽ</asp:Label>&nbsp;</TD>
						<TD height="12" style="HEIGHT: 12px">
							<asp:DropDownList id="dpStyle" runat="server" Width="475px" Height="22px"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD align="right" valign="top" style="WIDTH: 206px">
							<asp:Label id="Label2" runat="server" Width="65px" Height="16px">���̼��</asp:Label>&nbsp;</TD>
						<TD>
							<asp:TextBox id="txtFlowRemark" runat="server" Width="475px" Height="148px" TextMode="MultiLine"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD colspan="2" align="right" height="40">
							<hr>
							<asp:Button id="cmdPrevious" accessKey="P" runat="server" Width="70px" CssClass="buttoncss"
								Text="��һ��" Enabled="False"></asp:Button>&nbsp;
							<asp:Button id="cmdNext" runat="server" Width="70px" Text="��һ��" CssClass="buttoncss" accessKey="N"></asp:Button>&nbsp;
							<asp:Button id="cmdFinish" accessKey="F" runat="server" Width="82px" CssClass="buttoncss" Text="������"></asp:Button>&nbsp;
							<asp:Button id="cmdCancel" accessKey="C" runat="server" Width="86px" CssClass="buttoncss" Text="ȡ�����"
								CausesValidation="False"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
