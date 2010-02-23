<%@ Page language="c#" Codebehind="ManageStaff.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Staff.ManageStaff" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ManageStaff</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
			
		var ball1 = new Image();
		var ball2 = new Image();
		ball1.src = 'images/ball1.gif';
		ball2.src = 'images/ball2.gif';

		var active = new Image();
		var nonactive = new Image();
		active.src = '../../images/maillistbutton2.gif';
		nonactive.src = '../../images/maillistbutton1.gif';

		function onMouseOver(img)
		{
			document.images[img].src = ball2.src;
		}

		function onMouseOut(img)
		{
			document.images[img].src = ball1.src;
		}

		function onOverBar(bar)
		{
			if (bar != null) {
				bar.style.backgroundImage = "url("+active.src+")";
				
			}
		}

		function onOutBar(bar)
		{
			if (bar != null) {
				bar.style.backgroundImage = "url("+nonactive.src+")";
			}
		}
		
		function selectAll(){
			var len=document.MailList.elements.length;
			var i;
		    for (i=0;i<len;i++){
			if (document.MailList.elements[i].type=="checkbox"){
		        document.MailList.elements[i].checked=true;								
						 }
					}
				}

		function unSelectAll(){
	          var len=document.MailList.elements.length;
	          var i;
	          for (i=0;i<len;i++){
	               if (document.MailList.elements[i].type=="checkbox"){
	                  document.MailList.elements[i].checked=false; 
	               }   
	        	 } 
		    }		

		</script>
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0">
		<form id="ManageStaff" method="post" runat="server">
			<FONT face="����">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
							<td vAlign="top" ><TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TBODY>
										<TR height="30">
											<TD class="GbText" width="80" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" align="right"> <IMG height="16" src="../../DataImages/staff.gif" width="16"/><font color="#006699">��Ա����</font></TD>
											<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="60"
												align="right">&nbsp;</TD>
											<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="right" width=85%></TD>
			</TD></TR></TBODY></TABLE></TD></TR>
						<tr><TD>
							<TABLE class="gbtext" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<%--<tr>
								<td colspan="3">
							        <div id="DisplayColumn" runat="server"> 
							            <asp:CheckBoxList ID="cblDisplayColumn" runat="server" 
                                            onselectedindexchanged="cblDisplayColumn_SelectedIndexChanged" Visible="False">
							            <asp:ListItem Value="0" Text="��ʵ����" Selected="True"></asp:ListItem>
							            <asp:ListItem Value="1" Text="�ֻ�" Selected="True"></asp:ListItem>
							            <asp:ListItem Value="2" Text="����" Selected="True"></asp:ListItem>
<asp:ListItem Value="3" Text="�Ա�" Selected="True"></asp:ListItem>
<asp:ListItem Value="4" Text="EMAIL" Selected="True"></asp:ListItem>
<asp:ListItem Value="5" Text="ְλ" Selected="True"></asp:ListItem>

<asp:ListItem Value="6" Text="����" Selected="True"></asp:ListItem>
<asp:ListItem Value="7" Text="��סַ" Selected="True"></asp:ListItem>


<asp:ListItem Value="8" Text="ע������" Selected="True"></asp:ListItem>
<asp:ListItem Value="9" Text="��˾�绰" Selected="True"></asp:ListItem>
<asp:ListItem Value="10" Text="�ƶ��绰" Selected="True"></asp:ListItem>
<asp:ListItem Value="11" Text="��������" Selected="True"></asp:ListItem>
<asp:ListItem Value="12" Text="��ͬ��ǩ����" Selected="True"></asp:ListItem>
<asp:ListItem Value="13" Text="����״��" Selected="True"></asp:ListItem>
<asp:ListItem Value="14" Text="������״��" Selected="True"></asp:ListItem>
<asp:ListItem Value="15" Text="���֤����" Selected="True"></asp:ListItem>
<asp:ListItem Value="16" Text="����״��" Selected="True"></asp:ListItem>
<asp:ListItem Value="17" Text="�������ڵ�" Selected="True"></asp:ListItem>
<asp:ListItem Value="18" Text="ѧ��" Selected="True"></asp:ListItem>
<asp:ListItem Value="19" Text="�س�" Selected="True"></asp:ListItem>
<asp:ListItem Value="20" Text="��ע" Selected="True"></asp:ListItem>
<asp:ListItem Value="21" Text="�籣����" Selected="True"></asp:ListItem>
<asp:ListItem Value="22" Text="���ϱ��չ�˾(20%) " Selected="True"></asp:ListItem>
<asp:ListItem Value="23" Text="���ϱ��ո���(8%)" Selected="True"></asp:ListItem>
<asp:ListItem Value="24" Text="ʧҵ���չ�˾(1%)" Selected="True"></asp:ListItem>
<asp:ListItem Value="25" Text="ʧҵ���ո���(0.2% " Selected="True"></asp:ListItem>
<asp:ListItem Value="26" Text="���˱��չ�˾(0.8%)" Selected="True"></asp:ListItem>
<asp:ListItem Value="27" Text="�������չ�˾(0.8%)" Selected="True"></asp:ListItem>
<asp:ListItem Value="28" Text="ҽ�Ʊ��չ�˾(10%) " Selected="True"></asp:ListItem>
<asp:ListItem Value="29" Text="ҽ�Ʊ��ո���(2%+3)" Selected="True"></asp:ListItem>
<asp:ListItem Value="30" Text="�籣��˾�ϼ�" Selected="True"></asp:ListItem>
<asp:ListItem Value="31" Text="�籣���˺ϼ�" Selected="True"></asp:ListItem>
<asp:ListItem Value="32" Text="������ɷѻ���" Selected="True"></asp:ListItem>
<asp:ListItem Value="33" Text="������˾(12%) " Selected="True"></asp:ListItem>
<asp:ListItem Value="34" Text="���������(12%) " Selected="True"></asp:ListItem>


                                        </asp:CheckBoxList>
							        </div>
								</td>
								</tr>--%>
								<TR>
									<TD align="center" width="90" background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>.gif' height="24"><asp:linkbutton id="lbOnline" runat="server" CssClass="Newbutton">��ְԱ��</asp:linkbutton></TD>
									<TD align="center" width="90" background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>.gif' height="24"><asp:linkbutton id="lbOffLine" runat="server" CssClass="Newbutton">��ְԱ��</asp:linkbutton></TD>
									<TD align="left">&nbsp;&nbsp;
									<asp:linkbutton id="lbtn_SelectField" runat="server" 
                                            onclick="lbtn_SelectField_Click">ѡ����ʾ�ֶ�>>></asp:linkbutton>
										<asp:button id="cmdNewStaff" runat="server" Text="��Ա��" CssClass="redbuttoncss"></asp:button>
										<asp:button id="cmdDimission" runat="server" Text="��ְ" CssClass="redbuttoncss"></asp:button><asp:button id="cmdRehab" runat="server" Text="��ְ" CssClass="redbuttoncss"></asp:button>
										<asp:button id="cmdChangePosition" runat="server" Text="��ְ" CssClass="redbuttoncss"></asp:button>
										<asp:Button id="btn_Search" runat="server" CssClass="redbuttoncss" Text="��ѯ"></asp:Button><asp:CheckBox id="cbRemind" runat="server" Text="���ѹ�˾ȫ��Ա��" Width="240px" Font-Size="X-Small" Height="16px"></asp:CheckBox>&nbsp;</TD>
								</TR>
								
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD><asp:datagrid id="dbStaffList" runat="server" 
                                OnPageIndexChanged="DataGrid_PageChanged" BorderColor="#93BEE2"
								BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" PageSize="15" AllowPaging="True"
								AutoGenerateColumns="False" DataKeyField="Staff_ID" Width="100%"  AllowSorting="True" 
                                onsortcommand="dbStaffList_SortCommand">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" Wrap="false"></ItemStyle>
								<HeaderStyle Font-Size="X-Small"  Wrap="false" Font-Bold="True" ForeColor="White" BackColor="#337FB2"></HeaderStyle>
								<FooterStyle Font-Size="X-Small" HorizontalAlign="Right" BackColor="#E8F4FF"></FooterStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="ID">
										<HeaderStyle Width="20px"></HeaderStyle>
										<ItemTemplate>
											<asp:CheckBox id="chkStaff_ID" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:HyperLinkColumn Text="��ʵ����" DataNavigateUrlField="staff_id" DataNavigateUrlFormatString="../position/NewStaff.aspx?StaffID={0}&amp;ReturnPage=1"
										DataTextField="RealName" HeaderText="��ʵ����" SortExpression="RealName"  >
										<HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" />
									</asp:HyperLinkColumn>
									
								 
									
									<asp:BoundColumn DataField="Mobile" SortExpression="Mobile" HeaderText="�ֻ�">
										<HeaderStyle  Wrap="false"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Age" SortExpression="Age" HeaderText="����">
										<HeaderStyle HorizontalAlign="Center"  Wrap="false"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"  Wrap="false"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SexName" SortExpression="SexName" HeaderText="�Ա�">
										<HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" />
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Email"  SortExpression="Email" HeaderText="EMAIL">
										<HeaderStyle Width="100px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="position_Name" SortExpression="position_Name" HeaderText="ְλ">
								<HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" />
									</asp:BoundColumn> 
<asp:BoundColumn Visible="True" DataField="staff_dept" SortExpression="staff_dept" HeaderText="����"></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Address" SortExpression="Address" HeaderText="��סַ">
<HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
								<%--	<asp:BoundColumn DataField="RQ" HeaderText="ע������">
										<HeaderStyle HorizontalAlign="Right" Width="80px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									--%>

<asp:BoundColumn Visible="True" DataField="RegistedDate" SortExpression="RegistedDate" HeaderText="ע������" >
<HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" />
</asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Phone" SortExpression="Phone" HeaderText="��˾�绰"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Mobile" SortExpression="Mobile" HeaderText="�ƶ��绰"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Birthday" SortExpression="Birthday" HeaderText="��������"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="ContractDate" SortExpression="ContractDate" HeaderText="��ͬ��ǩ����"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="InsuranceStatus" SortExpression="InsuranceStatus" HeaderText="����״��"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="AccumulationStatus" SortExpression="AccumulationStatus" HeaderText="������״�� "><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="IDNumber" SortExpression="IDNumber" HeaderText="���֤���� "><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Marriage" SortExpression="Marriage" HeaderText="����״��"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn> 
<asp:BoundColumn Visible="True" DataField="BirthPlace" SortExpression="BirthPlace" HeaderText="�������ڵ� "><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Education" SortExpression="Education" HeaderText="ѧ��"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Features" SortExpression="Features" HeaderText="�س�"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Remark" SortExpression="Remark" HeaderText="��ע"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="InsuranceBase" SortExpression="InsuranceBase" HeaderText="�籣����"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="EndowmentCompany" SortExpression="EndowmentCompany" HeaderText="���ϱ��չ�˾(20%) "><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="EndowmentPersonal" SortExpression="EndowmentPersonal" HeaderText="���ϱ��ո���(8%)  "><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="UnemploymentCompany" SortExpression="UnemploymentCompany" HeaderText="ʧҵ���չ�˾(1%)  "><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="UnemploymentPersonal" SortExpression="UnemploymentPersonal" HeaderText="ʧҵ���ո���(0.2%)"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Injury" SortExpression="Injury" HeaderText="���˱��չ�˾(0.8%)"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Maternity" SortExpression="Maternity" HeaderText="�������չ�˾(0.8%)"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="MedicalCompany" SortExpression="MedicalCompany" HeaderText="ҽ�Ʊ��չ�˾(10%) "><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="MedicalPersonal" SortExpression="MedicalPersonal" HeaderText="ҽ�Ʊ��ո���(2%+3)"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="InsuranceCompanyTotal" SortExpression="InsuranceCompanyTotal" HeaderText="�籣��˾�ϼ�"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="InsurancePersonalTotal" SortExpression="InsurancePersonalTotal" HeaderText="�籣���˺ϼ�"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="AccumulationBase" SortExpression="AccumulationBase" HeaderText="������ɷѻ���"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="AccumulationCompany" SortExpression="AccumulationCompany" HeaderText="������˾(12%)   "><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="AccumulationPersonal" SortExpression="AccumulationPersonal" HeaderText="���������(12%)   "><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn> 



									
								</Columns>
								<PagerStyle Font-Size="X-Small" HorizontalAlign="left" BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					
					<tr>
								<td colspan="3">
							        <div id="DisplayColumn" runat="server"> 
							            <asp:CheckBoxList ID="cblDisplayColumn" runat="server" 
                                            onselectedindexchanged="cblDisplayColumn_SelectedIndexChanged" Visible="False">
							            <asp:ListItem Value="0" Text="��ʵ����" Selected="True"></asp:ListItem>
							            <asp:ListItem Value="1" Text="�ֻ�" Selected="True"></asp:ListItem>
							            <asp:ListItem Value="2" Text="����" Selected="True"></asp:ListItem>
<asp:ListItem Value="3" Text="�Ա�" Selected="True"></asp:ListItem>
<asp:ListItem Value="4" Text="EMAIL" Selected="True"></asp:ListItem>
<asp:ListItem Value="5" Text="ְλ" Selected="True"></asp:ListItem>

<asp:ListItem Value="6" Text="����" Selected="True"></asp:ListItem>
<asp:ListItem Value="7" Text="��סַ" Selected="True"></asp:ListItem>


<asp:ListItem Value="8" Text="ע������" Selected="True"></asp:ListItem>
<asp:ListItem Value="9" Text="��˾�绰" Selected="True"></asp:ListItem>
<asp:ListItem Value="10" Text="�ƶ��绰" Selected="True"></asp:ListItem>
<asp:ListItem Value="11" Text="��������" Selected="True"></asp:ListItem>
<asp:ListItem Value="12" Text="��ͬ��ǩ����" Selected="True"></asp:ListItem>
<asp:ListItem Value="13" Text="����״��" Selected="True"></asp:ListItem>
<asp:ListItem Value="14" Text="������״��" Selected="True"></asp:ListItem>
<asp:ListItem Value="15" Text="���֤����" Selected="True"></asp:ListItem>
<asp:ListItem Value="16" Text="����״��" Selected="True"></asp:ListItem>
<asp:ListItem Value="17" Text="�������ڵ�" Selected="True"></asp:ListItem>
<asp:ListItem Value="18" Text="ѧ��" Selected="True"></asp:ListItem>
<asp:ListItem Value="19" Text="�س�" Selected="True"></asp:ListItem>
<asp:ListItem Value="20" Text="��ע" Selected="True"></asp:ListItem>
<asp:ListItem Value="21" Text="�籣����" Selected="True"></asp:ListItem>
<asp:ListItem Value="22" Text="���ϱ��չ�˾(20%) " Selected="True"></asp:ListItem>
<asp:ListItem Value="23" Text="���ϱ��ո���(8%)" Selected="True"></asp:ListItem>
<asp:ListItem Value="24" Text="ʧҵ���չ�˾(1%)" Selected="True"></asp:ListItem>
<asp:ListItem Value="25" Text="ʧҵ���ո���(0.2% " Selected="True"></asp:ListItem>
<asp:ListItem Value="26" Text="���˱��չ�˾(0.8%)" Selected="True"></asp:ListItem>
<asp:ListItem Value="27" Text="�������չ�˾(0.8%)" Selected="True"></asp:ListItem>
<asp:ListItem Value="28" Text="ҽ�Ʊ��չ�˾(10%) " Selected="True"></asp:ListItem>
<asp:ListItem Value="29" Text="ҽ�Ʊ��ո���(2%+3)" Selected="True"></asp:ListItem>
<asp:ListItem Value="30" Text="�籣��˾�ϼ�" Selected="True"></asp:ListItem>
<asp:ListItem Value="31" Text="�籣���˺ϼ�" Selected="True"></asp:ListItem>
<asp:ListItem Value="32" Text="������ɷѻ���" Selected="True"></asp:ListItem>
<asp:ListItem Value="33" Text="������˾(12%) " Selected="True"></asp:ListItem>
<asp:ListItem Value="34" Text="���������(12%) " Selected="True"></asp:ListItem>


                                        </asp:CheckBoxList>
							        </div>
								</td>
								</tr>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
