<%@ Page language="c#" Codebehind="MsgSend.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.SM.MsgSend" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MsgSend</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
			function dialwinprocess()
			{
				var newdialoguewin = window.showModalDialog("SelectReceiver.aspx",window,"dialogWidth:600px;DialogHeight=490px;status:no");
				if(newdialoguewin!=null){
					if(newdialoguewin.length>5)
					{
						ReceiverTypeArray = newdialoguewin.split("|");
						SendToArray = ReceiverTypeArray[0].split("-");
						MobileSendToArray = ReceiverTypeArray[1].split("-");
						try{
							this.document.MsgSend.txtSendTo.value = SendToArray[0];
							this.document.MsgSend.txtMobileSendTo.value = MobileSendToArray[0];
						}
						catch(e){}
						
						
					}
				}
			}
			
			function SendMsg()
			{
				if(event.keyCode==10)
				{
					document.MsgSend.btnSend.click();
				}
			}
		</script>
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0" onload="javascript:document.all.MsgSend.txtContent.focus()">
		<form id="MsgSend" method="post" runat="server">
			<TABLE borderColor="#111111" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR height="30">
					<TD class="GbText" width="20" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6"
						align="right"><FONT color="#003366" size="3"><IMG height="16" src="../../dataImages/message2.GIF" width="16"></FONT></TD>
					<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="60"
						align="right">��Ѷ����</TD>
					<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="left"><FONT face="����">-���Ͷ���</FONT>&nbsp;</TD>
				</TR>
			</TABLE>
			<TABLE borderColor="#93bee2" cellSpacing="0" cellPadding="0" width="100%" border="1" style="BORDER-COLLAPSE: collapse"
				class="GbText">
				<TR height="30">
					<TD align="right" width="150"><asp:label id="lblLReceiver" runat="server" Width="93px">վ�ڶ�Ѷ������</asp:label><FONT face="����">:</FONT></TD>
					<TD><FONT face="����">&nbsp;&nbsp;</FONT><INPUT 
class=InputCss 
readOnly type=text size=50 value="<%=SendToRealName%>" name=txtSendTo><A onclick="dialwinprocess()" href="#"> <FONT face="����">ѡ����Ա</FONT></A></TD>
				</TR>
				<TR height="30">
					<TD align="right"><asp:label id="lblMReceiver" runat="server">վ���û��ֻ���Ѷ</asp:label><FONT face="����">:</FONT></TD>
					<TD><FONT face="����">&nbsp;&nbsp;</FONT><INPUT class=InputCss 
readOnly type=text size=50 value="<%=MobileSendToRN%>" name=txtMobileSendTo style="HEIGHT: 19px"><A onclick="dialwinprocess()" href="#"> <FONT face="����">ѡ����Ա</FONT></A></TD>
				</TR>
				<TR height="30">
					<TD align="right">
						<asp:label id="lblAdditionalNo" runat="server">�����ֻ�����</asp:label><FONT face="����">:</FONT></TD>
					<TD><FONT face="����">&nbsp; </FONT><INPUT class=InputCss 
onkeypress="var  k=event.keyCode;  if ((k==44) || (k<=57 &amp;&amp; k>=48) )  return true; else return false" 
onpaste="return false" 
type=text size=62 value="<%=AdditionalNo%>" name=txtAdditionalNo style="HEIGHT: 19px"><asp:label id="lblRemind" runat="server" Font-Size="X-Small">(����ֻ��������ö��Ÿ���)</asp:label></TD>
				</TR>
				<TR height="30">
					<TD align="right" vAlign="top">
						<asp:label id="lblContent" runat="server">��������</asp:label><FONT face="����">:</FONT></TD>
					<TD><FONT face="����">&nbsp;</FONT>
						<asp:textbox onkeypress="SendMsg()" id="txtContent" runat="server" Width="400px" Height="200px"
							TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR height="30">
					<TD align="right">&nbsp;</TD>
					<TD><FONT face="����">&nbsp;</FONT><asp:button id="btnSend" runat="server" Width="100px" Text="��      ��" CssClass="buttoncss"></asp:button><FONT face="����">&nbsp;&nbsp;&nbsp;
						</FONT>
						<asp:button id="btnReturn" runat="server" Width="100px" Text="��      ��" CssClass="buttoncss"></asp:button>
						<asp:label id="lblShortCut" runat="server" Font-Size="Small">��Ctrl+�س��� ������Ϣ </asp:label></TD>
				</TR>
			</TABLE>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <input type=hidden value="<%=SendTo%>" name=hdnTxtSendTo><input type=hidden value="<%=MobileSendTo%>" 
name=hdnTxtMobileSendTo>&nbsp;&nbsp;&nbsp;</form>
	</body>
</HTML>
