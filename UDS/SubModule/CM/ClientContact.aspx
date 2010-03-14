<%@ Page language="c#" Codebehind="ClientContact.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.CM.ClientContact" %>
<%@ Register TagPrefix="uc1" TagName="ControlClientContactHistory" Src="../../Inc/ControlClientContactHistory.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>客户接触</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="JavaScript" src="../../Css/meizzDate.js"></script>
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function changein()
		{
			var removeindexs = new Array();
			var j = 0;

			for(var i=0;i<document.getElementById("lbx_Staff").options.length;i++)
			{
				if(document.getElementById("lbx_Staff").options[i].selected)
				{
					document.getElementById("lbx_Cooperater").options.add(new Option(document.getElementById("lbx_Staff").options[i].text,document.getElementById("lbx_Staff").options[i].value));
					removeindexs[j++] = i;
				}
			
			}
			for(var i=0;i<j;i++)
			{
				//alert(removeindexs[i].valueOf());
				document.getElementById("lbx_Staff").options.remove(removeindexs[i].valueOf());
				for(var k=i;k<removeindexs.length;k++)
				{
					removeindexs[k] = removeindexs[k]-1;
				}			
			}
		
		}
		
		function changeout()
		{
			var removeindexs = new Array();
			var j = 0;

			for(var i=0;i<document.getElementById("lbx_Cooperater").options.length;i++)
			{
				if(document.getElementById("lbx_Cooperater").options[i].selected)
				{
					document.getElementById("lbx_Staff").options.add(new Option(document.getElementById("lbx_Cooperater").options[i].text,document.getElementById("lbx_Cooperater").options[i].value));
					removeindexs[j++] = i;
				}
			
			}
			for(var i=0;i<j;i++)
			{
				//alert(removeindexs[i].valueOf());
				document.getElementById("lbx_Cooperater").options.remove(removeindexs[i].valueOf());
				for(var k=i;k<removeindexs.length;k++)
				{
					removeindexs[k] = removeindexs[k]-1;
				}			
			}
		}
		function changelinkmanin()
		{
			var removeindexs = new Array();
			var j = 0;

			for(var i=0;i<document.getElementById("lbx_ClientLinkman").options.length;i++)
			{
				if(document.getElementById("lbx_ClientLinkman").options[i].selected)
				{
					document.getElementById("lbx_Linkman").options.add(new Option(document.getElementById("lbx_ClientLinkman").options[i].text,document.getElementById("lbx_ClientLinkman").options[i].value));
					removeindexs[j++] = i;
				}
			
			}
			for(var i=0;i<j;i++)
			{
				//alert(removeindexs[i].valueOf());
				document.getElementById("lbx_ClientLinkman").options.remove(removeindexs[i].valueOf());
				for(var k=i;k<removeindexs.length;k++)
				{
					removeindexs[k] = removeindexs[k]-1;
				}			
			}
		
		}
		function changelinkmanout()
		{
			var removeindexs = new Array();
			var j = 0;

			for(var i=0;i<document.getElementById("lbx_Linkman").options.length;i++)
			{
				if(document.getElementById("lbx_Linkman").options[i].selected)
				{
					document.getElementById("lbx_ClientLinkman").options.add(new Option(document.getElementById("lbx_Linkman").options[i].text,document.getElementById("lbx_Linkman").options[i].value));
					removeindexs[j++] = i;
				}
			
			}
			for(var i=0;i<j;i++)
			{
				//alert(removeindexs[i].valueOf());
				document.getElementById("lbx_Linkman").options.remove(removeindexs[i].valueOf());
				for(var k=i;k<removeindexs.length;k++)
				{
					removeindexs[k] = removeindexs[k]-1;
				}			
			}
		
		}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="ClientContact" method="post" encType="multipart/form-data" runat="server">
			<FONT face="宋体">
				<TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="20" height="30" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" class="GbText"><FONT color="#003366" size="3"><IMG height="16" src="../../DataImages/ClientManage.gif" width="16"></FONT></TD>
						<TD class="GbText" align="center" width="60" background="../../Images/treetopbg.jpg"
							bgColor="#c0d9e6"><font color="#006699">客户跟踪</font></TD>
						<TD class="GbText" align="right" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6"><FONT face="宋体">&nbsp;
							</FONT>&nbsp;</TD>
					</TR>
				</TABLE>
			</FONT>
		  <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
			  <tr>
			    <td height="10"></td>
		      </tr>
		  </table>
			<FONT face="宋体">
<TABLE class="gbtext" id="Table4" style="BORDER-COLLAPSE: collapse" borderColor="#93bee2"
					cellSpacing="0" cellPadding="0" width="98%" align="center" border="1">
				<TR>
					<TD width="120" bgColor="#e8f4ff" height="30"  vAlign="middle"
							align="center" colSpan="1" rowSpan="1">客户名称</TD>
					<TD colSpan="2" bgcolor="#FFFFFF" ><asp:literal id="ltl_ClientName" runat="server" Visible="False"></asp:literal><asp:panel id="pnl_clientselect" runat="server">
							<asp:DropDownList id="ddl_ClientName" runat="server" AutoPostBack="True"></asp:DropDownList>
							<asp:TextBox id="tbx_quicksearch" runat="server" CssClass="inputcss"></asp:TextBox>
							<asp:Button id="btn_search" runat="server" CssClass="redbuttoncss" Text="查询"></asp:Button>
						</asp:panel></TD>
					<td width="607" bgcolor="#FFFFFF" >客户简称&nbsp;&nbsp;<asp:literal id="ltl_ClientShortName" runat="server"></asp:literal></td>
			    </TR>
				<TR>
					<TD width="120" height="30" align="center" bgColor="#e8f4ff" >最后填写接触时间</TD>
			    <TD width="506" bgColor="#FFFFFF" >&nbsp;<asp:Literal id="ltl_UpdateTime" runat="server"></asp:Literal></TD>
					<TD  bgColor="#e8f4ff" align="center" colSpan="1" rowSpan="1">发现时间</TD>
					<TD  bgColor="#FFFFFF">&nbsp;
						<asp:Literal id="ltl_Birthday" runat="server"></asp:Literal></TD>
			    </TR>
				<TR>
					<TD width="120" height="30" align="center" bgColor="#e8f4ff" >接洽次数(合计)</TD>
			    <TD  bgColor="#FFFFFF">&nbsp;<asp:literal id="ltl_ContactTimes" runat="server"></asp:literal></TD>
					<TD bgColor="#e8f4ff" align="center" colSpan="1" rowSpan="1">销售阶段(最新)</TD>
					<TD bgColor="#FFFFFF">&nbsp;
						<asp:Literal id="ltl_sellphase" runat="server"></asp:Literal></TD>
			    </TR>
				<TR>
					<TD bgColor="#e8f4ff" height="30"  align="center" colSpan="1" rowSpan="1">成交预估(最新)</TD>
					<TD  bgColor="#FFFFFF">&nbsp;<asp:label id="lbl_BargainPrognosis" runat="server"></asp:label></TD>
					<TD width="120" align="center" bgColor="#e8f4ff">发生费用(合计)</TD>
					<TD bgColor="#FFFFFF">&nbsp;
						<asp:Literal id="ltl_fee" runat="server"></asp:Literal></TD>
			    </TR>
				<TR>
					<TD width="120" height="30" align="center" bgColor="#e8f4ff" >销售人员</TD>
					<TD  bgColor="#FFFFFF">
				    <asp:dropdownlist id="ddl_SellMan" runat="server" Visible="False"></asp:dropdownlist>
						<asp:literal id="ltl_AddMan" runat="server"></asp:literal></TD>
					<TD width="120" align="center" bgColor="#e8f4ff">&nbsp;</TD>
					<TD bgColor="#FFFFFF">&nbsp;</TD>
			    </TR>
				<TR>
					<TD width="120" height="30" align="center" bgColor="#E8F4FF" ><FONT style="BACKGROUND-COLOR: #e8f4ff"></FONT></TD>
				  <TD  align="center" bgColor="#FFFFFF">&nbsp;</TD>
					<TD  align="center" bgColor="#E8F4FF" colSpan="1" rowSpan="1">&nbsp;</TD>
					<TD  align="center" bgColor="#FFFFFF" colSpan="1" rowSpan="1">&nbsp;</TD>
			    </TR>
				<TR>
					<TD bgColor="#e8f4ff" height="30"  align="center" colSpan="1" rowSpan="1">本次接触时间</TD>
					<TD >&nbsp;<asp:textbox id="tbx_contacttime" runat="server" ReadOnly="True" Width="88px"></asp:textbox></TD>
					<TD align="center" bgColor="#e8f4ff" colSpan="1" rowSpan="1">预计下次接触时间</TD>
					<TD>&nbsp;
						<asp:textbox id="tbx_nextcontacttime" runat="server" Width="88px" ReadOnly="True"></asp:textbox></TD>
			    </TR>
				<TR>
					<TD bgColor="#e8f4ff" height="30"  align="center" colSpan="1" rowSpan="1">协同人员</TD>
					<TD colSpan="3" height="65">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="380" border="0">
							<TR>
								<TD align="center"><asp:listbox id="lbx_Cooperater" runat="server" Width="150px" SelectionMode="Multiple"></asp:listbox></TD>
								<TD align="center">
									<P align="center"><asp:button id="btn_in" runat="server" CssClass="redbuttoncss" Text="<<<"></asp:button><BR>
										<BR>
										<asp:button id="btn_out" runat="server" CssClass="redbuttoncss" Text=">>>"></asp:button></P>
							    </TD>
								<TD align="center"><asp:listbox id="lbx_Staff" runat="server" Width="150px" SelectionMode="Multiple"></asp:listbox></TD>
						    </TR>
					    </TABLE>
				    </TD>
			    </TR>
				<TR>
					<TD bgColor="#e8f4ff" height="30"  align="center" colSpan="1" rowSpan="1">接触对象<BR>
						<BR>
						<INPUT class=redbuttoncss id=btn_addlinkman style="WIDTH: 65px; HEIGHT: 20px" onClick="window.open('Linkman.aspx?ClientID=<%=clientid.ToString()%>')" type=button alt=添加联系人 value="添加联系人&#13;&#10;&#13;&#10;&#13;&#10;"></TD>
					<TD colSpan="3" height="67">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="380" border="0">
							<TR>
								<TD align="center"><asp:listbox id="lbx_Linkman" runat="server" Width="150px" SelectionMode="Multiple"></asp:listbox></TD>
								<TD align="center">
									<P align="center"><asp:button id="btn_inlinkman" runat="server" CssClass="redbuttoncss" Text="<<<"></asp:button><BR>
										<BR>
										<asp:button id="btn_outlinkman" runat="server" CssClass="redbuttoncss" Text=">>>"></asp:button></P>
							    </TD>
								<TD align="center"><asp:listbox id="lbx_ClientLinkman" runat="server" Width="150px" SelectionMode="Multiple"></asp:listbox></TD>
						    </TR>
					    </TABLE>
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="400" border="0">
							<TR>
								<TD align="center"></TD>
						    </TR>
					    </TABLE>
				    </TD>
			    </TR>
				<TR>
					<TD bgColor="#e8f4ff" height="30"  align="center" colSpan="1" rowSpan="1">接触目的</TD>
					<TD colSpan="3" height="33">&nbsp;
						<asp:textbox id="tbx_contactaim" runat="server" Width="400px" TextMode="MultiLine" Height="36px"></asp:textbox></TD>
			    </TR>
				<TR>
					<TD  align="center" bgColor="#e8f4ff" colSpan="1" height="30" rowSpan="1">近期标的</TD>
					<TD  vAlign="middle" colSpan="1" height="24" rowSpan="1">&nbsp;<asp:textbox id="tbx_sellmoney" runat="server" Width="112px">0</asp:textbox>元(RMB)<asp:rangevalidator id="RangeValidator3" runat="server" ControlToValidate="tbx_sellmoney" MaximumValue="9999999999"
								MinimumValue="0" ErrorMessage="请输入数字"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="tbx_sellmoney" ErrorMessage="请输入数字"></asp:requiredfieldvalidator></TD>
					<TD width="120" height="24" align="center" bgColor="#e8f4ff">成交预估</TD>
			  <TD height="24">&nbsp;<asp:dropdownlist id="ddl_bargainprognosis" runat="server">
							<asp:ListItem Value="*">*</asp:ListItem>
							<asp:ListItem Value="**">**</asp:ListItem>
							<asp:ListItem Value="***">***</asp:ListItem>
							<asp:ListItem Value="****">****</asp:ListItem>
							<asp:ListItem Value="*****">*****</asp:ListItem>
						</asp:dropdownlist>(星级越高,成功可能性越高)</TD>
			    </TR>
				<TR>
					<TD bgColor="#e8f4ff" height="30"  align="center" colSpan="1" rowSpan="1">接触方式</TD>
					<TD colSpan="3"><asp:checkbox id="cbx_telephone" runat="server" Text="电话"></asp:checkbox><asp:checkbox id="cbx_fax" runat="server" Text="传真"></asp:checkbox><asp:checkbox id="cbx_email" runat="server" Text="邮件"></asp:checkbox><asp:checkbox id="cbx_mail" runat="server" Text="信函"></asp:checkbox><asp:checkbox id="cbx_meeting" runat="server" Text="会议"></asp:checkbox><asp:checkbox id="cbx_interview" runat="server" Text="走访"></asp:checkbox><asp:checkbox id="cbx_callin" runat="server" Text="来访"></asp:checkbox><asp:checkbox id="cbx_sms" runat="server" Text="短消息"></asp:checkbox></TD>
			    </TR>
				<TR>
					<TD bgColor="#e8f4ff" height="30"  align="center" colSpan="1" rowSpan="1">接触状态</TD>
					<TD colSpan="3"><asp:checkbox id="cbx_trace" runat="server" Visible="False" Text="跟踪"></asp:checkbox><asp:checkbox id="cbx_boot" runat="server" Visible="False" Text="启动"></asp:checkbox><asp:checkbox id="cbx_commend" runat="server" Visible="False" Text="产品推荐"></asp:checkbox><asp:checkbox id="cbx_requirement" runat="server" Visible="False" Text="需求定义"></asp:checkbox><asp:checkbox id="cbx_submit" runat="server" Visible="False" Text="方案提交"></asp:checkbox><asp:checkbox id="cbx_negotiate" runat="server" Visible="False" Text="商务谈判"></asp:checkbox><asp:checkbox id="cbx_actualize" runat="server" Visible="False" Text="项目实施"></asp:checkbox><asp:checkbox id="cbx_traceservice" runat="server" Visible="False" Text="跟踪服务"></asp:checkbox><asp:checkbox id="cbx_last" runat="server" Visible="False" Text="收尾款"></asp:checkbox><asp:radiobutton id="rbtn_trace" runat="server" Text="跟踪" Checked="True" GroupName="contactstatus"></asp:radiobutton><asp:radiobutton id="rbtn_boot" runat="server" Text="启动" GroupName="contactstatus"></asp:radiobutton><asp:radiobutton id="rbtn_commend" runat="server" Text="产品推荐" GroupName="contactstatus"></asp:radiobutton><asp:radiobutton id="rbtn_requirement" runat="server" Text="需求定义" GroupName="contactstatus"></asp:radiobutton><asp:radiobutton id="rbtn_submit" runat="server" Text="方案提交" GroupName="contactstatus"></asp:radiobutton><asp:radiobutton id="rbtn_negotiate" runat="server" Text="商务谈判" GroupName="contactstatus"></asp:radiobutton><asp:radiobutton id="rbtn_actualize" runat="server" Text="项目实施" GroupName="contactstatus"></asp:radiobutton><asp:radiobutton id="rbtn_traceservice" runat="server" Text="跟踪服务" GroupName="contactstatus"></asp:radiobutton><asp:radiobutton id="rbtn_last" runat="server" Text="收尾款" GroupName="contactstatus"></asp:radiobutton></TD>
			    </TR>
				<TR>
					<TD bgColor="#e8f4ff" height="30"  align="center" colSpan="1" rowSpan="1">本次费用</TD>
					<TD  vAlign="middle">&nbsp;<asp:textbox id="tbx_thisfee" runat="server" Width="112px">0</asp:textbox>元(RMB)<asp:rangevalidator id="RangeValidator2" runat="server" ControlToValidate="tbx_thisfee" MaximumValue="999999"
								MinimumValue="0" ErrorMessage="请输入数字"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="tbx_thisfee" ErrorMessage="请输入数字"></asp:requiredfieldvalidator></TD>
					<TD width="120" align="center" bgColor="#e8f4ff">费用用途</TD>
				  <TD vAlign="middle"><asp:checkbox id="cbx_travel" runat="server" Text="差旅"></asp:checkbox><asp:checkbox id="cbx_food" runat="server" Text="餐饮"></asp:checkbox><asp:checkbox id="cbx_gift" runat="server" Text="礼品"></asp:checkbox><asp:checkbox id="cbx_out" runat="server" Text="公关"></asp:checkbox></TD>
			    </TR>
				<TR>
					<TD bgColor="#e8f4ff" height="30"  align="center" colSpan="1" rowSpan="1">接触内容</TD>
					<TD colSpan="3" height="61">&nbsp;<asp:textbox id="tbx_contactcontent" runat="server" Width="632px" TextMode="MultiLine" Height="57px"></asp:textbox></TD>
			    </TR>
				<TR>
					<TD width="120" height="30" align="center" bgColor="#e8f4ff" >下次接触目的</TD>
			    <TD >&nbsp;<asp:textbox id="tbx_nextcontactaim" runat="server" Width="272px"></asp:textbox></TD>
					<TD width="120" bgColor="#e8f4ff"></TD>
					<TD>&nbsp;</TD>
			    </TR>
				<TR>
					<TD vAlign="middle" bgColor="#e8f4ff" height="30"  align="center"
							colSpan="1" rowSpan="1">附件</TD>
					<TD colSpan="3"><INPUT class="inputCss" id="File1" style="WIDTH: 400px; HEIGHT: 19px" type="file" size="81"
								name="File1" runat="server">
						<BR>
						<INPUT class="inputCss" id="File2" style="WIDTH: 400px; HEIGHT: 19px" type="file" size="81"
								name="File2" runat="server">
						<BR>
						<INPUT class="inputCss" id="File3" style="WIDTH: 400px; HEIGHT: 19px" type="file" size="81"
								name="File3" runat="server"></TD>
			    </TR>
				<TR>
					<TD align="center" colSpan="4" height="36"><asp:button id="btn_OK" runat="server" CssClass="buttoncss" Text=" 确 定 " Width="60px"></asp:button><asp:label id="lbl_Message" runat="server" Width="70px"></asp:label></TD>
			    </TR>
				<TR>
					<TD colSpan="4"><uc1:controlclientcontacthistory id="ControlClientContactHistory1" runat="server"></uc1:controlclientcontacthistory></TD>
			    </TR>
				<TR>
					<TD align="right" colSpan="4"><A href="javascript:window.close();">关闭窗口</A></TD>
			    </TR>
			  </TABLE>
		  </FONT>
		</form>
	</body>
</HTML>
