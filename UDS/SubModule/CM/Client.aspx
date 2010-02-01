<%@ Page language="c#" Codebehind="Client.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.CM.Client" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>客户表单</title>
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
			<FONT face="宋体">
				<TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR height="30">
						<TD class="GbText" width="24" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6"><FONT color="#003366" size="3"><IMG height="16" src="../../DataImages/ClientManage.gif" width="16"></FONT></TD>
						<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" width="60"
							align="right"><font color="#006699">客户表单</font></TD>
						<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" align="right"><FONT face="宋体">&nbsp;
							</FONT>&nbsp;</TD>
					</TR>
				</TABLE>
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
					<TR>
						<TD align="right">
							<TABLE class="gbtext" id="Table2" style="BORDER-COLLAPSE: collapse" borderColor="#93bee2"
								cellSpacing="0" cellPadding="0" width="100%" align="center" border="1">
								<TR>
									<TD width="90" bgColor="#e8f4ff" height="28">&nbsp;客户编号</TD>
									<TD height="28">&nbsp;<asp:literal id="ltl_ID" runat="server"></asp:literal></TD>
									<TD width="90" bgColor="#e8f4ff" height="28">&nbsp;添加日期</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_Birthday" runat="server" CssClass="inputcss" Width="250px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;客户名称</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_Name" runat="server" CssClass="inputcss" Width="250px"></asp:textbox><asp:customvalidator id="CustomValidator1" runat="server" ControlToValidate="tbx_Name" ErrorMessage="客户名称重复"
											EnableClientScript="False"></asp:customvalidator>
										<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ControlToValidate="tbx_Name" ErrorMessage="客户名称不能为空"
											Display="Dynamic"></asp:requiredfieldvalidator></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;客户简称</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_ShortName" runat="server" CssClass="inputcss" Width="250px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;客户分类</TD>
									<TD height="28"><asp:checkbox id="cbx_zhongduan" runat="server" Text="终端客户"></asp:checkbox><asp:checkbox id="cbx_qudao" runat="server" Text="渠道商"></asp:checkbox><asp:checkbox id="cbx_shehui" runat="server" Text="社会关系"></asp:checkbox><asp:checkbox id="cbx_meiti" runat="server" Text="媒体公关"></asp:checkbox></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;更新时间</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_UpdateTime" runat="server" CssClass="inputcss" Width="250px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;主要联系人</TD>
									<TD height="28" style="WIDTH: 400px">&nbsp;
										<asp:HyperLink id="hlk_Chiefman" runat="server"></asp:HyperLink>&nbsp; <INPUT class=redbuttoncss onclick='<%="window.open("+"\"ClientLinkmanList.aspx?ClientID="+clientid.ToString()+"\");"%>' type=button value=查看全部></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;职务</TD>
									<TD height="28">&nbsp;<asp:label id="lbl_position" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;联系电话</TD>
									<TD height="28">&nbsp;<asp:label id="lbl_chieftel" runat="server"></asp:label></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;隶属区域</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_affiliatedarea" runat="server" CssClass="inputcss" Width="250px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;添加人员</TD>
									<TD height="28">&nbsp;<asp:literal id="ltl_AddManName" runat="server"></asp:literal>
										<asp:panel id="pnl_Leader" runat="server" Width="273px">
											<asp:DropDownList id="ddl_AddMan" runat="server"></asp:DropDownList>
											<asp:Button id="btn_LookTel" runat="server" CssClass="redbuttoncss" Text="查看联系电话"></asp:Button>
											<asp:Button id="btn_ChangeAddMan" runat="server" CssClass="redbuttoncss" Text="修改"></asp:Button>
										</asp:panel></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;联系电话</TD>
									<TD height="28">&nbsp;<asp:literal id="ltl_addmantel" runat="server"></asp:literal></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;企业网址</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_URL" runat="server" CssClass="inputcss" Width="250px"></asp:textbox></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;邮政编码</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_zip" runat="server" CssClass="inputcss" Width="250px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;企业地址</TD>
									<TD colSpan="3" height="28">&nbsp;<asp:textbox id="tbx_address" runat="server" CssClass="inputcss" Width="645px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;企业性质</TD>
									<TD height="28"><asp:checkbox id="cbx_government" runat="server" Text="政府"></asp:checkbox><asp:checkbox id="cbx_stateowned" runat="server" Text="国营"></asp:checkbox><asp:checkbox id="cbx_private" runat="server" Text="民营"></asp:checkbox><asp:checkbox id="cbx_foreign" runat="server" Text="外资"></asp:checkbox><asp:checkbox id="cbx_market" runat="server" Text="上市"></asp:checkbox></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;注册资本</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_money" runat="server" CssClass="inputcss" Width="250px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="46">&nbsp;所处行业</TD>
									<TD colSpan="3" height="46"><asp:checkbox id="cbx_realestate" runat="server" Text="房地产"></asp:checkbox><asp:checkbox id="cbx_IT" runat="server" Text="IT"></asp:checkbox><asp:checkbox id="cbx_business" runat="server" Text="商业贸易"></asp:checkbox><asp:checkbox id="cbx_telecom" runat="server" Text="电信"></asp:checkbox><asp:checkbox id="cbx_post" runat="server" Text="邮政通讯"></asp:checkbox><asp:checkbox id="cbx_consultation" runat="server" Text="咨询服务"></asp:checkbox><asp:checkbox id="cbx_travel" runat="server" Text="旅游业"></asp:checkbox><asp:checkbox id="cbx_bus" runat="server" Text="交通运输"></asp:checkbox><br>
										<asp:checkbox id="cbx_stock" runat="server" Text="金融证券"></asp:checkbox><asp:checkbox id="cbx_insurance" runat="server" Text="保险业"></asp:checkbox><asp:checkbox id="cbx_tax" runat="server" Text="税务"></asp:checkbox><asp:checkbox id="cbx_make" runat="server" Text="制造业"></asp:checkbox><asp:checkbox id="cbx_electric" runat="server" Text="家电"></asp:checkbox><asp:checkbox id="cbx_clothe" runat="server" Text="服装"></asp:checkbox><asp:checkbox id="cbx_food" runat="server" Text="食品"></asp:checkbox><asp:checkbox id="cbx_medicine" runat="server" Text="医药"></asp:checkbox><asp:checkbox id="cbx_mechanism" runat="server" Text="机械"></asp:checkbox><asp:checkbox id="cbx_auto" runat="server" Text="汽车制造"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;公司规模</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_staffnumber" runat="server" CssClass="inputcss" Width="250px"></asp:textbox></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;主营业务</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_operation" runat="server" CssClass="inputcss" Width="250px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD vAlign="top" bgColor="#e8f4ff">&nbsp;企业简介</TD>
									<TD colSpan="3">&nbsp;<asp:textbox id="tbx_introduce" runat="server" Width="645px" TextMode="MultiLine"></asp:textbox><BR>
										&nbsp;附件： <INPUT class="inputcss" id="File1" style="WIDTH: 600px; HEIGHT: 19px" type="file" size="58"
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
									<TD vAlign="top" bgColor="#e8f4ff" height="40">&nbsp;信息化程度</TD>
									<TD colSpan="3" height="40">&nbsp;<asp:textbox id="tbx_IT" runat="server" Width="645px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;电脑数量</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_pcnumber" runat="server" CssClass="inputcss" Width="250px"></asp:textbox>台<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="tbx_pcnumber" ErrorMessage="请输入数字"
											Display="Dynamic"></asp:requiredfieldvalidator>
										<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="tbx_pcnumber"
											ValidationExpression="\d*">请输入数字</asp:regularexpressionvalidator></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;网络状况</TD>
									<TD height="28"><asp:checkbox id="cbx_internet" runat="server" Text="互联网"></asp:checkbox><asp:checkbox id="cbx_WAN" runat="server" Text="WAN"></asp:checkbox><asp:checkbox id="cbx_LAN" runat="server" Text="LAN"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;专业IT人员</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_ITStaffs" runat="server" CssClass="inputcss" Width="250px"></asp:textbox>人<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="tbx_ITStaffs" ErrorMessage="请输入数字"
											Display="Dynamic"></asp:requiredfieldvalidator>
										<asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ControlToValidate="tbx_ITStaffs"
											ValidationExpression="\d*">请输入数字</asp:regularexpressionvalidator></TD>
									<TD height="28"></TD>
									<TD height="28"></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;IT部门名称</TD>
									<TD height="28">&nbsp;<asp:textbox id="tbx_ITdepartment" runat="server" CssClass="inputcss" Width="250px"></asp:textbox></TD>
									<TD bgColor="#e8f4ff" height="28">&nbsp;负责人</TD>
									<TD height="28"><asp:textbox id="tbx_principal" runat="server" CssClass="inputcss" Width="250px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD vAlign="top" bgColor="#e8f4ff" height="28">&nbsp;目前系统</TD>
									<TD colSpan="3" height="28">&nbsp;<asp:textbox id="tbx_system" runat="server" Width="645px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;客户来源</TD>
									<TD colSpan="3" height="28"><asp:checkbox id="cbx_sellman" runat="server" Text="销售主动联系"></asp:checkbox><asp:checkbox id="cbx_just" runat="server" Text="以前认识"></asp:checkbox><asp:checkbox id="cbx_introduce" runat="server" Text="熟人介绍"></asp:checkbox><asp:checkbox id="cbx_customer" runat="server" Text="客户主动联系" AutoPostBack="True"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD bgColor="#e8f4ff" height="28">&nbsp;客户主动</TD>
									<TD colSpan="3" height="28"><asp:panel id="penal" runat="server" CssClass="inputcss" Width="563px" Visible="False">
											<asp:checkbox id="cbx_Email" runat="server" Text="电子邮件"></asp:checkbox>
											<asp:checkbox id="cbx_media" runat="server" Text="媒体宣传"></asp:checkbox>
											<asp:checkbox id="cbx_Web" runat="server" Text="查询网站"></asp:checkbox>
											<asp:checkbox id="cbx_proseminar" runat="server" Text="研讨会"></asp:checkbox>
											<asp:checkbox id="cbx_exhibition" runat="server" Text="展览会"></asp:checkbox>
											<asp:checkbox id="cbx_EMS" runat="server" Text="直邮"></asp:checkbox>
										</asp:panel></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="4" height="28">&nbsp;
										<asp:panel id="pnl_MyCustom" runat="server" Width="260px">
<asp:button id="btn_OK" runat="server" Width="70px" CssClass="buttoncss" Text=" 确 定 "></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
<asp:Button id="btn_AddContact" runat="server" CssClass="buttoncss" Text="添加接触"></asp:Button></asp:panel><asp:panel id="pnl_Leader1" runat="server" Width="175px" Visible="False">
											<asp:Button id="btn_LookContact" runat="server" CssClass="buttoncss" Text="查看接触"></asp:Button>
										</asp:panel></TD>
								</TR>
							</TABLE>
							<asp:label id="lbl_Message" runat="server" Width="92px" Visible="False"></asp:label><A href="javascript:window.close();">关闭窗口</A></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
