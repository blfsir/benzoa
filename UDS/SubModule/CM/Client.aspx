<%@ Page language="c#" Codebehind="Client.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.CM.Client" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�ͻ���</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../../Css/meizzDate.js"></script>
		<script>
		function displaypenal()
		{
			if(document.Client.cbx_customer.checked)
				penal.style.display="";
			else
				penal.style.display="none";
		
		}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Client" method="post" encType="multipart/form-data" runat="server">
			<FONT face="����">
				<TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR height="30">
						<TD class="GbText" width="24" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6"><FONT color="#003366" size="3"><IMG height="16" src="../../DataImages/ClientManage.gif" width="16"></FONT></TD>
						<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" width="60"
							align="right"><font color="#006699">�ͻ���</font></TD>
						<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" align="right"><FONT face="����">&nbsp;
							</FONT>&nbsp;</TD>
					</TR>
				</TABLE>
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
					<TR>
						<TD align="right">
							<TABLE class="gbtext" id="Table2" style="BORDER-COLLAPSE: collapse" borderColor="#93bee2"
								cellSpacing="0" cellPadding="0" width="100%" align="center" border="1">
								<TR>
									<TD width="90" bgColor="#e8f4ff" height="28">&nbsp;�ͻ����</TD>
									<TD height="28">&nbsp;<asp:literal id="ltl_ID" runat="server"></asp:literal></TD>
									<TD width="90" bgColor="#e8f4ff" height="28">&nbsp;�������</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_Birthday" runat="server" CssClass="inputcss" Width="250px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;�ͻ�����</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_Name" runat="server" CssClass="inputcss" Width="250px"></asp:textbox><asp:customvalidator id="CustomValidator1" runat="server" ControlToValidate="tbx_Name" ErrorMessage="�ͻ������ظ�"
											EnableClientScript="False"></asp:customvalidator>
										<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ControlToValidate="tbx_Name" ErrorMessage="�ͻ����Ʋ���Ϊ��"
											Display="Dynamic"></asp:requiredfieldvalidator></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;�ͻ����</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_ShortName" runat="server" CssClass="inputcss" Width="250px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;�ͻ�����</TD>
									<TD height="28"><asp:checkbox id="cbx_zhongduan" runat="server" Text="�ն˿ͻ�"></asp:checkbox><asp:checkbox id="cbx_qudao" runat="server" Text="������"></asp:checkbox><asp:checkbox id="cbx_shehui" runat="server" Text="����ϵ"></asp:checkbox><asp:checkbox id="cbx_meiti" runat="server" Text="ý�幫��"></asp:checkbox></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;����ʱ��</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_UpdateTime" runat="server" CssClass="inputcss" Width="250px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;��Ҫ��ϵ��</TD>
									<TD height="28" style="WIDTH: 400px">&nbsp;
										<asp:HyperLink id="hlk_Chiefman" runat="server"></asp:HyperLink>&nbsp; <INPUT class=redbuttoncss onclick='<%="window.open("+"\"ClientLinkmanList.aspx?ClientID="+clientid.ToString()+"\");"%>' type=button value=�鿴ȫ��></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;ְ��</TD>
									<TD height="28">&nbsp;<asp:label id="lbl_position" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;��ϵ�绰</TD>
									<TD height="28">&nbsp;<asp:label id="lbl_chieftel" runat="server"></asp:label></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;��������</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_affiliatedarea" runat="server" CssClass="inputcss" Width="250px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;�����Ա</TD>
									<TD height="28">&nbsp;<asp:literal id="ltl_AddManName" runat="server"></asp:literal>
										<asp:panel id="pnl_Leader" runat="server" Width="273px">
											<asp:DropDownList id="ddl_AddMan" runat="server"></asp:DropDownList>
											<asp:Button id="btn_LookTel" runat="server" CssClass="redbuttoncss" Text="�鿴��ϵ�绰"></asp:Button>
											<asp:Button id="btn_ChangeAddMan" runat="server" CssClass="redbuttoncss" Text="�޸�"></asp:Button>
										</asp:panel></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;��ϵ�绰</TD>
									<TD height="28">&nbsp;<asp:literal id="ltl_addmantel" runat="server"></asp:literal></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;��ҵ��ַ</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_URL" runat="server" CssClass="inputcss" Width="250px"></asp:textbox></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;��������</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_zip" runat="server" CssClass="inputcss" Width="250px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;��ҵ��ַ</TD>
									<TD colSpan="3" height="28">&nbsp;<asp:textbox id="tbx_address" runat="server" CssClass="inputcss" Width="645px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;��ҵ����</TD>
									<TD height="28"><asp:checkbox id="cbx_government" runat="server" Text="����"></asp:checkbox><asp:checkbox id="cbx_stateowned" runat="server" Text="��Ӫ"></asp:checkbox><asp:checkbox id="cbx_private" runat="server" Text="��Ӫ"></asp:checkbox><asp:checkbox id="cbx_foreign" runat="server" Text="����"></asp:checkbox><asp:checkbox id="cbx_market" runat="server" Text="����"></asp:checkbox></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;ע���ʱ�</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_money" runat="server" CssClass="inputcss" Width="250px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="46">&nbsp;������ҵ</TD>
									<TD colSpan="3" height="46"><asp:checkbox id="cbx_realestate" runat="server" Text="���ز�"></asp:checkbox><asp:checkbox id="cbx_IT" runat="server" Text="IT"></asp:checkbox><asp:checkbox id="cbx_business" runat="server" Text="��ҵó��"></asp:checkbox><asp:checkbox id="cbx_telecom" runat="server" Text="����"></asp:checkbox><asp:checkbox id="cbx_post" runat="server" Text="����ͨѶ"></asp:checkbox><asp:checkbox id="cbx_consultation" runat="server" Text="��ѯ����"></asp:checkbox><asp:checkbox id="cbx_travel" runat="server" Text="����ҵ"></asp:checkbox><asp:checkbox id="cbx_bus" runat="server" Text="��ͨ����"></asp:checkbox><br>
										<asp:checkbox id="cbx_stock" runat="server" Text="����֤ȯ"></asp:checkbox><asp:checkbox id="cbx_insurance" runat="server" Text="����ҵ"></asp:checkbox><asp:checkbox id="cbx_tax" runat="server" Text="˰��"></asp:checkbox><asp:checkbox id="cbx_make" runat="server" Text="����ҵ"></asp:checkbox><asp:checkbox id="cbx_electric" runat="server" Text="�ҵ�"></asp:checkbox><asp:checkbox id="cbx_clothe" runat="server" Text="��װ"></asp:checkbox><asp:checkbox id="cbx_food" runat="server" Text="ʳƷ"></asp:checkbox><asp:checkbox id="cbx_medicine" runat="server" Text="ҽҩ"></asp:checkbox><asp:checkbox id="cbx_mechanism" runat="server" Text="��е"></asp:checkbox><asp:checkbox id="cbx_auto" runat="server" Text="��������"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;��˾��ģ</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_staffnumber" runat="server" CssClass="inputcss" Width="250px"></asp:textbox></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;��Ӫҵ��</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_operation" runat="server" CssClass="inputcss" Width="250px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD vAlign="top" bgColor="#e8f4ff">&nbsp;��ҵ���</TD>
									<TD colSpan="3">&nbsp;<asp:textbox id="tbx_introduce" runat="server" Width="645px" TextMode="MultiLine"></asp:textbox><BR>
										&nbsp;������ <INPUT class="inputcss" id="File1" style="WIDTH: 600px; HEIGHT: 19px" type="file" size="58"
											name="File1" runat="server"><BR>
										<asp:repeater id="rpt_Attachment" runat="server">
											<ItemTemplate>
												<a href='<%# Request.Path.Substring(0,Request.Path.LastIndexOf("/"))+"\\Attachment\\"+DataBinder.Eval(Container.DataItem,"ID")+DataBinder.Eval(Container.DataItem,"Extension") %>' target=_blank>
													<%# DataBinder.Eval(Container.DataItem,"Path")+"," %>
												</a>
											</ItemTemplate>
										</asp:repeater></TD>
								</TR>
								<TR>
									<TD vAlign="top" bgColor="#e8f4ff" height="40">&nbsp;��Ϣ���̶�</TD>
									<TD colSpan="3" height="40">&nbsp;<asp:textbox id="tbx_IT" runat="server" Width="645px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;��������</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_pcnumber" runat="server" CssClass="inputcss" Width="250px"></asp:textbox>̨<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="tbx_pcnumber" ErrorMessage="����������"
											Display="Dynamic"></asp:requiredfieldvalidator>
										<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="tbx_pcnumber"
											ValidationExpression="\d*">����������</asp:regularexpressionvalidator></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;����״��</TD>
									<TD height="28"><asp:checkbox id="cbx_internet" runat="server" Text="������"></asp:checkbox><asp:checkbox id="cbx_WAN" runat="server" Text="WAN"></asp:checkbox><asp:checkbox id="cbx_LAN" runat="server" Text="LAN"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;רҵIT��Ա</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_ITStaffs" runat="server" CssClass="inputcss" Width="250px"></asp:textbox>��<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="tbx_ITStaffs" ErrorMessage="����������"
											Display="Dynamic"></asp:requiredfieldvalidator>
										<asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ControlToValidate="tbx_ITStaffs"
											ValidationExpression="\d*">����������</asp:regularexpressionvalidator></TD>
									<TD height="28"></TD>
									<TD height="28"></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;IT��������</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_ITdepartment" runat="server" CssClass="inputcss" Width="250px"></asp:textbox></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;������</TD>
									<TD height="28"><asp:textbox id="tbx_principal" runat="server" CssClass="inputcss" Width="250px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD vAlign="top" bgColor="#e8f4ff" height="28">&nbsp;Ŀǰϵͳ</TD>
									<TD colSpan="3" height="28">&nbsp;<asp:textbox id="tbx_system" runat="server" Width="645px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;�ͻ���Դ</TD>
									<TD colSpan="3" height="28"><asp:checkbox id="cbx_sellman" runat="server" Text="����������ϵ"></asp:checkbox><asp:checkbox id="cbx_just" runat="server" Text="��ǰ��ʶ"></asp:checkbox><asp:checkbox id="cbx_introduce" runat="server" Text="���˽���"></asp:checkbox><asp:checkbox id="cbx_customer" runat="server" Text="�ͻ�������ϵ" AutoPostBack="True"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;�ͻ�����</TD>
									<TD colSpan="3" height="28"><asp:panel id="penal" runat="server" CssClass="inputcss" Width="563px" Visible="False">
											<asp:checkbox id="cbx_Email" runat="server" Text="�����ʼ�"></asp:checkbox>
											<asp:checkbox id="cbx_media" runat="server" Text="ý������"></asp:checkbox>
											<asp:checkbox id="cbx_Web" runat="server" Text="��ѯ��վ"></asp:checkbox>
											<asp:checkbox id="cbx_proseminar" runat="server" Text="���ֻ�"></asp:checkbox>
											<asp:checkbox id="cbx_exhibition" runat="server" Text="չ����"></asp:checkbox>
											<asp:checkbox id="cbx_EMS" runat="server" Text="ֱ��"></asp:checkbox>
										</asp:panel></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="4" height="28">&nbsp;
										<asp:panel id="pnl_MyCustom" runat="server" Width="260px">
<asp:button id="btn_OK" runat="server" Width="70px" CssClass="buttoncss" Text=" ȷ �� "></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
<asp:Button id="btn_AddContact" runat="server" CssClass="buttoncss" Text="��ӽӴ�"></asp:Button></asp:panel><asp:panel id="pnl_Leader1" runat="server" Width="175px" Visible="False">
											<asp:Button id="btn_LookContact" runat="server" CssClass="buttoncss" Text="�鿴�Ӵ�"></asp:Button>
										</asp:panel></TD>
								</TR>
							</TABLE>
							<asp:label id="lbl_Message" runat="server" Width="92px" Visible="False"></asp:label><A href="javascript:window.close();">�رմ���</A></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
