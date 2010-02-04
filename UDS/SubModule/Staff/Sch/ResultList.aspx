<%@ Page language="c#" Codebehind="ResultList.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Staff.Sch.ResultList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ResultList</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin=0 topmargin=0>
		<form id="Form1" method="post" runat="server">
					<TABLE borderColor="#111111" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR height="30">
					<TD class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"
						align="right"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/myLinkman.gif" width="16"></FONT></TD>
					<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="75"
						align="right" style="WIDTH: 75px">员工查询</TD>
					<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="left">&nbsp;<FONT face="宋体">查询结果</FONT></TD>
				</TR>
			</TABLE>
			<TABLE id="Table1" borderColor="#93bee2" cellSpacing="0" cellPadding="0" width="100%" border="1"
					style="BORDER-COLLAPSE: collapse" class="GbText">
				<TR>
					<TD><asp:datagrid id="dgrd_StaffList" runat="server" Width="100%" AutoGenerateColumns="False" AllowSorting="True"
							PageSize="20" AllowPaging="True" BorderColor="#93BEE2" BorderWidth="1px">
<AlternatingItemStyle BackColor="#E8F4FF">
</AlternatingItemStyle>

<ItemStyle Font-Size="X-Small">
</ItemStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="Staff_Name" SortExpression="Staff_Name" HeaderText="登陆名"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="RealName" SortExpression="RealName" HeaderText="姓名"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Mobile" SortExpression="Mobile" HeaderText="手机号码"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="SexName" SortExpression="SexName" HeaderText="性别"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Email" SortExpression="Email" HeaderText="Email"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Position_Name" SortExpression="Position_Name" HeaderText="职位"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="staff_dept" SortExpression="staff_dept" HeaderText="部门"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Address" SortExpression="Address" HeaderText="现住址"></asp:BoundColumn>



<asp:BoundColumn Visible="False" DataField="RegistedDate" SortExpression="RegistedDate" HeaderText="注册日期"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Phone" SortExpression="Phone" HeaderText="公司电话"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Mobile" SortExpression="Mobile" HeaderText="移动电话"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Birthday" SortExpression="Birthday" HeaderText="出生日期"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="ContractDate" SortExpression="ContractDate" HeaderText="合同首签日期"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="InsuranceStatus" SortExpression="InsuranceStatus" HeaderText="保险状况"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="AccumulationStatus" SortExpression="AccumulationStatus" HeaderText="公积金状况 "></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="IDNumber" SortExpression="IDNumber" HeaderText="身份证号码 "></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Marriage" SortExpression="Marriage" HeaderText="婚姻状况"></asp:BoundColumn> 
<asp:BoundColumn Visible="False" DataField="BirthPlace" SortExpression="BirthPlace" HeaderText="户口所在地 "></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Education" SortExpression="Education" HeaderText="学历"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Features" SortExpression="Features" HeaderText="特长"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Remark" SortExpression="Remark" HeaderText="备注"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="InsuranceBase" SortExpression="InsuranceBase" HeaderText="社保基数"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="EndowmentCompany" SortExpression="EndowmentCompany" HeaderText="养老保险公司(20%) "></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="EndowmentPersonal" SortExpression="EndowmentPersonal" HeaderText="养老保险个人(8%)  "></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="UnemploymentCompany" SortExpression="UnemploymentCompany" HeaderText="失业保险公司(1%)  "></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="UnemploymentPersonal" SortExpression="UnemploymentPersonal" HeaderText="失业保险个人(0.2%)"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Injury" SortExpression="Injury" HeaderText="工伤保险公司(0.8%)"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Maternity" SortExpression="Maternity" HeaderText="生育保险公司(0.8%)"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="MedicalCompany" SortExpression="MedicalCompany" HeaderText="医疗保险公司(10%) "></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="MedicalPersonal" SortExpression="MedicalPersonal" HeaderText="医疗保险个人(2%+3)"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="InsuranceCompanyTotal" SortExpression="InsuranceCompanyTotal" HeaderText="社保公司合计"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="InsurancePersonalTotal" SortExpression="InsurancePersonalTotal" HeaderText="社保个人合计"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="AccumulationBase" SortExpression="AccumulationBase" HeaderText="公积金缴费基数"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="AccumulationCompany" SortExpression="AccumulationCompany" HeaderText="公积金公司(12%)   "></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="AccumulationPersonal" SortExpression="AccumulationPersonal" HeaderText="公积金个人(12%)   "></asp:BoundColumn> 


</Columns>

<PagerStyle HorizontalAlign="Right" Mode="NumericPages">
</PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD align="right"><FONT face="宋体">
							<asp:Button id="btn_Print" runat="server" Text="打印" CssClass="buttoncss"></asp:Button><INPUT class="buttoncss" type="button" onclick="javascript:location.href='Search.aspx'" value="返回"></FONT></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
