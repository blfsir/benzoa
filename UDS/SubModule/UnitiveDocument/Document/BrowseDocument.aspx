<%@ Page language="c#" Codebehind="BrowseDocument.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.Document.BrowseDocument" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�ĵ����</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0">
		<form id="BrowseDocument" method="post" runat="server">
        <TABLE id="Table2" borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TR>
								<TD width="20" height="30" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6" class="GbText"><FONT color="#003366" size="3"><IMG height="16" src="../../../images/283.GIF" width="16"></FONT></TD>
								<TD width="60" align="center" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6" class="GbText">�ĵ�����</TD>
								<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6">&nbsp;</TD>
							</TR>
						</TABLE>
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
				<TR>
					<TD height="10">
						
					</TD>
				</TR>
				<TR>
					<TD>
						<table border="1" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#93bee2"
							width="98%" id="AutoNumber2" height="1" class="GbText" align="center">
							<TR>
								<TD width="200" height="30" align="center" bgcolor="#e8f4ff">&nbsp;<FONT face="����">�ĵ�����:</FONT></TD>
								<TD bgcolor="#e8f4ff">&nbsp;
									<asp:Label id="lblDocTitle" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD width="200" height="30" align="center">&nbsp;<FONT face="����">�� �� ��:</FONT></TD>
								<TD>&nbsp;
									<asp:Label id="lblDocApprover" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD width="200" height="30" align="center" bgcolor="#e8f4ff">&nbsp;<FONT face="����">�鵵����:</FONT></TD>
								<TD bgcolor="#e8f4ff">&nbsp;
									<asp:Label id="lblDocApproveDate" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD width="200" height="30" align="center">&nbsp;<FONT face="����">�� �� ��:</FONT></TD>
								<TD>&nbsp;
									<asp:Label id="lblAddedBy" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD width="200" height="30" align="center" bgcolor="#e8f4ff">&nbsp;<FONT face="����">�ϴ�����:</FONT></TD>
								<TD bgcolor="#e8f4ff">&nbsp;
									<asp:Label id="lblAddedDate" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD width="200" height="30" align="center">&nbsp;<FONT face="����">���ش���:</FONT></TD>
								<TD>&nbsp;
									<asp:Label id="lblDocViewedTimes" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD width="200" height="30" align="center" bgcolor="#e8f4ff">&nbsp;<FONT face="����">������Ŀ:</FONT></TD>
								<TD bgcolor="#e8f4ff">&nbsp;
									<asp:Label id="lblClassName" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD width="200" height="30" align="center">&nbsp;<FONT face="����">�ļ����:</FONT></TD>
								<TD><FONT face="����"></FONT>&nbsp;
									<asp:Label id="lblDocContent" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD width="200" height="30" align="center" bgcolor="#e8f4ff">&nbsp;<FONT face="����">�ļ�����:</FONT></TD>
								<TD bgcolor="#e8f4ff"><FONT face="����"></FONT>&nbsp;
									<asp:Label id="lblFileVisualPath" runat="server"></asp:Label></TD>
							</TR>
						</table>
				  </TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 8pt" vAlign="middle" align="center">
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<TR>
								<TD style="HEIGHT: 28px" align="right"><FONT face="����">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT><input type="button" value=" ��  �� " onClick="javascript:try {if(parent.frames.length==0) window.close();else history.go(-1);} catch(e){}"
										class="buttoncss"></TD>
								<TD style="HEIGHT: 28px" align="right"><IMG height="25" src="../../../images/endbott.gif" width="279"></TD>
							</TR>
						</table>
						<asp:DataList id="DataListDocument" runat="server"></asp:DataList>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
