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
			<FONT face="宋体">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
							<td vAlign="top" ><TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TBODY>
										<TR height="30">
											<TD class="GbText" width="80" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" align="right"> <IMG height="16" src="../../DataImages/staff.gif" width="16"/><font color="#006699">人员管理</font></TD>
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
							            <asp:ListItem Value="0" Text="真实姓名" Selected="True"></asp:ListItem>
							            <asp:ListItem Value="1" Text="手机" Selected="True"></asp:ListItem>
							            <asp:ListItem Value="2" Text="年龄" Selected="True"></asp:ListItem>
<asp:ListItem Value="3" Text="性别" Selected="True"></asp:ListItem>
<asp:ListItem Value="4" Text="EMAIL" Selected="True"></asp:ListItem>
<asp:ListItem Value="5" Text="职位" Selected="True"></asp:ListItem>

<asp:ListItem Value="6" Text="部门" Selected="True"></asp:ListItem>
<asp:ListItem Value="7" Text="现住址" Selected="True"></asp:ListItem>


<asp:ListItem Value="8" Text="注册日期" Selected="True"></asp:ListItem>
<asp:ListItem Value="9" Text="公司电话" Selected="True"></asp:ListItem>
<asp:ListItem Value="10" Text="移动电话" Selected="True"></asp:ListItem>
<asp:ListItem Value="11" Text="出生日期" Selected="True"></asp:ListItem>
<asp:ListItem Value="12" Text="合同首签日期" Selected="True"></asp:ListItem>
<asp:ListItem Value="13" Text="保险状况" Selected="True"></asp:ListItem>
<asp:ListItem Value="14" Text="公积金状况" Selected="True"></asp:ListItem>
<asp:ListItem Value="15" Text="身份证号码" Selected="True"></asp:ListItem>
<asp:ListItem Value="16" Text="婚姻状况" Selected="True"></asp:ListItem>
<asp:ListItem Value="17" Text="户口所在地" Selected="True"></asp:ListItem>
<asp:ListItem Value="18" Text="学历" Selected="True"></asp:ListItem>
<asp:ListItem Value="19" Text="特长" Selected="True"></asp:ListItem>
<asp:ListItem Value="20" Text="备注" Selected="True"></asp:ListItem>
<asp:ListItem Value="21" Text="社保基数" Selected="True"></asp:ListItem>
<asp:ListItem Value="22" Text="养老保险公司(20%) " Selected="True"></asp:ListItem>
<asp:ListItem Value="23" Text="养老保险个人(8%)" Selected="True"></asp:ListItem>
<asp:ListItem Value="24" Text="失业保险公司(1%)" Selected="True"></asp:ListItem>
<asp:ListItem Value="25" Text="失业保险个人(0.2% " Selected="True"></asp:ListItem>
<asp:ListItem Value="26" Text="工伤保险公司(0.8%)" Selected="True"></asp:ListItem>
<asp:ListItem Value="27" Text="生育保险公司(0.8%)" Selected="True"></asp:ListItem>
<asp:ListItem Value="28" Text="医疗保险公司(10%) " Selected="True"></asp:ListItem>
<asp:ListItem Value="29" Text="医疗保险个人(2%+3)" Selected="True"></asp:ListItem>
<asp:ListItem Value="30" Text="社保公司合计" Selected="True"></asp:ListItem>
<asp:ListItem Value="31" Text="社保个人合计" Selected="True"></asp:ListItem>
<asp:ListItem Value="32" Text="公积金缴费基数" Selected="True"></asp:ListItem>
<asp:ListItem Value="33" Text="公积金公司(12%) " Selected="True"></asp:ListItem>
<asp:ListItem Value="34" Text="公积金个人(12%) " Selected="True"></asp:ListItem>


                                        </asp:CheckBoxList>
							        </div>
								</td>
								</tr>--%>
								<TR>
									<TD align="center" width="90" background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>.gif' height="24"><asp:linkbutton id="lbOnline" runat="server" CssClass="Newbutton">在职员工</asp:linkbutton></TD>
									<TD align="center" width="90" background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>.gif' height="24"><asp:linkbutton id="lbOffLine" runat="server" CssClass="Newbutton">离职员工</asp:linkbutton></TD>
									<TD align="left">&nbsp;&nbsp;
									<asp:linkbutton id="lbtn_SelectField" runat="server" 
                                            onclick="lbtn_SelectField_Click">选择显示字段>>></asp:linkbutton>
										<asp:button id="cmdNewStaff" runat="server" Text="新员工" CssClass="redbuttoncss"></asp:button>
										<asp:button id="cmdDimission" runat="server" Text="离职" CssClass="redbuttoncss"></asp:button><asp:button id="cmdRehab" runat="server" Text="复职" CssClass="redbuttoncss"></asp:button>
										<asp:button id="cmdChangePosition" runat="server" Text="调职" CssClass="redbuttoncss"></asp:button>
										<asp:Button id="btn_Search" runat="server" CssClass="redbuttoncss" Text="查询"></asp:Button><asp:CheckBox id="cbRemind" runat="server" Text="提醒公司全体员工" Width="240px" Font-Size="X-Small" Height="16px"></asp:CheckBox>&nbsp;</TD>
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
									<asp:HyperLinkColumn Text="真实姓名" DataNavigateUrlField="staff_id" DataNavigateUrlFormatString="../position/NewStaff.aspx?StaffID={0}&amp;ReturnPage=1"
										DataTextField="RealName" HeaderText="真实姓名" SortExpression="RealName"  >
										<HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" />
									</asp:HyperLinkColumn>
									
								 
									
									<asp:BoundColumn DataField="Mobile" SortExpression="Mobile" HeaderText="手机">
										<HeaderStyle  Wrap="false"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Age" SortExpression="Age" HeaderText="年龄">
										<HeaderStyle HorizontalAlign="Center"  Wrap="false"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"  Wrap="false"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SexName" SortExpression="SexName" HeaderText="性别">
										<HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" />
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Email"  SortExpression="Email" HeaderText="EMAIL">
										<HeaderStyle Width="100px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="position_Name" SortExpression="position_Name" HeaderText="职位">
								<HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" />
									</asp:BoundColumn> 
<asp:BoundColumn Visible="True" DataField="staff_dept" SortExpression="staff_dept" HeaderText="部门"></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Address" SortExpression="Address" HeaderText="现住址">
<HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
								<%--	<asp:BoundColumn DataField="RQ" HeaderText="注册日期">
										<HeaderStyle HorizontalAlign="Right" Width="80px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									--%>

<asp:BoundColumn Visible="True" DataField="RegistedDate" SortExpression="RegistedDate" HeaderText="注册日期" >
<HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" />
</asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Phone" SortExpression="Phone" HeaderText="公司电话"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Mobile" SortExpression="Mobile" HeaderText="移动电话"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Birthday" SortExpression="Birthday" HeaderText="出生日期"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="ContractDate" SortExpression="ContractDate" HeaderText="合同首签日期"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="InsuranceStatus" SortExpression="InsuranceStatus" HeaderText="保险状况"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="AccumulationStatus" SortExpression="AccumulationStatus" HeaderText="公积金状况 "><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="IDNumber" SortExpression="IDNumber" HeaderText="身份证号码 "><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Marriage" SortExpression="Marriage" HeaderText="婚姻状况"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn> 
<asp:BoundColumn Visible="True" DataField="BirthPlace" SortExpression="BirthPlace" HeaderText="户口所在地 "><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Education" SortExpression="Education" HeaderText="学历"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Features" SortExpression="Features" HeaderText="特长"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Remark" SortExpression="Remark" HeaderText="备注"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="InsuranceBase" SortExpression="InsuranceBase" HeaderText="社保基数"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="EndowmentCompany" SortExpression="EndowmentCompany" HeaderText="养老保险公司(20%) "><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="EndowmentPersonal" SortExpression="EndowmentPersonal" HeaderText="养老保险个人(8%)  "><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="UnemploymentCompany" SortExpression="UnemploymentCompany" HeaderText="失业保险公司(1%)  "><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="UnemploymentPersonal" SortExpression="UnemploymentPersonal" HeaderText="失业保险个人(0.2%)"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Injury" SortExpression="Injury" HeaderText="工伤保险公司(0.8%)"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="Maternity" SortExpression="Maternity" HeaderText="生育保险公司(0.8%)"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="MedicalCompany" SortExpression="MedicalCompany" HeaderText="医疗保险公司(10%) "><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="MedicalPersonal" SortExpression="MedicalPersonal" HeaderText="医疗保险个人(2%+3)"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="InsuranceCompanyTotal" SortExpression="InsuranceCompanyTotal" HeaderText="社保公司合计"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="InsurancePersonalTotal" SortExpression="InsurancePersonalTotal" HeaderText="社保个人合计"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="AccumulationBase" SortExpression="AccumulationBase" HeaderText="公积金缴费基数"><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="AccumulationCompany" SortExpression="AccumulationCompany" HeaderText="公积金公司(12%)   "><HeaderStyle  Wrap="false"></HeaderStyle>
										<ItemStyle  Wrap="false" /></asp:BoundColumn>
<asp:BoundColumn Visible="True" DataField="AccumulationPersonal" SortExpression="AccumulationPersonal" HeaderText="公积金个人(12%)   "><HeaderStyle  Wrap="false"></HeaderStyle>
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
							            <asp:ListItem Value="0" Text="真实姓名" Selected="True"></asp:ListItem>
							            <asp:ListItem Value="1" Text="手机" Selected="True"></asp:ListItem>
							            <asp:ListItem Value="2" Text="年龄" Selected="True"></asp:ListItem>
<asp:ListItem Value="3" Text="性别" Selected="True"></asp:ListItem>
<asp:ListItem Value="4" Text="EMAIL" Selected="True"></asp:ListItem>
<asp:ListItem Value="5" Text="职位" Selected="True"></asp:ListItem>

<asp:ListItem Value="6" Text="部门" Selected="True"></asp:ListItem>
<asp:ListItem Value="7" Text="现住址" Selected="True"></asp:ListItem>


<asp:ListItem Value="8" Text="注册日期" Selected="True"></asp:ListItem>
<asp:ListItem Value="9" Text="公司电话" Selected="True"></asp:ListItem>
<asp:ListItem Value="10" Text="移动电话" Selected="True"></asp:ListItem>
<asp:ListItem Value="11" Text="出生日期" Selected="True"></asp:ListItem>
<asp:ListItem Value="12" Text="合同首签日期" Selected="True"></asp:ListItem>
<asp:ListItem Value="13" Text="保险状况" Selected="True"></asp:ListItem>
<asp:ListItem Value="14" Text="公积金状况" Selected="True"></asp:ListItem>
<asp:ListItem Value="15" Text="身份证号码" Selected="True"></asp:ListItem>
<asp:ListItem Value="16" Text="婚姻状况" Selected="True"></asp:ListItem>
<asp:ListItem Value="17" Text="户口所在地" Selected="True"></asp:ListItem>
<asp:ListItem Value="18" Text="学历" Selected="True"></asp:ListItem>
<asp:ListItem Value="19" Text="特长" Selected="True"></asp:ListItem>
<asp:ListItem Value="20" Text="备注" Selected="True"></asp:ListItem>
<asp:ListItem Value="21" Text="社保基数" Selected="True"></asp:ListItem>
<asp:ListItem Value="22" Text="养老保险公司(20%) " Selected="True"></asp:ListItem>
<asp:ListItem Value="23" Text="养老保险个人(8%)" Selected="True"></asp:ListItem>
<asp:ListItem Value="24" Text="失业保险公司(1%)" Selected="True"></asp:ListItem>
<asp:ListItem Value="25" Text="失业保险个人(0.2% " Selected="True"></asp:ListItem>
<asp:ListItem Value="26" Text="工伤保险公司(0.8%)" Selected="True"></asp:ListItem>
<asp:ListItem Value="27" Text="生育保险公司(0.8%)" Selected="True"></asp:ListItem>
<asp:ListItem Value="28" Text="医疗保险公司(10%) " Selected="True"></asp:ListItem>
<asp:ListItem Value="29" Text="医疗保险个人(2%+3)" Selected="True"></asp:ListItem>
<asp:ListItem Value="30" Text="社保公司合计" Selected="True"></asp:ListItem>
<asp:ListItem Value="31" Text="社保个人合计" Selected="True"></asp:ListItem>
<asp:ListItem Value="32" Text="公积金缴费基数" Selected="True"></asp:ListItem>
<asp:ListItem Value="33" Text="公积金公司(12%) " Selected="True"></asp:ListItem>
<asp:ListItem Value="34" Text="公积金个人(12%) " Selected="True"></asp:ListItem>


                                        </asp:CheckBoxList>
							        </div>
								</td>
								</tr>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
