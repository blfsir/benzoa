<%@ Page language="c#" Codebehind="checkout.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Login.checkout" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>checkout</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="checkout" method="post" runat="server">
			<FONT face="����">
				<TABLE id="Table1" style="WIDTH: 746px; HEIGHT: 87px" cellSpacing="1" cellPadding="1" width="746" border="1">
					<TR>
						<TD></TD>
					</TR>
				</TABLE>
			</FONT>
			<script language="javascript">
		//һ����ʱ����ʱˢ�±�ҳ
		var leftsecond;
		leftsecond=1;
		setInterval("if(leftsecond==0) window.parent.parent.location.href='logout.aspx';else {document.checkout.btnexit.value='����˳�ϵͳϵͳ��ȴ�'+leftsecond+'���Զ��˳�';leftsecond -=1;}",1*1000);
			</script>
		</form>
	</body>
</HTML>
