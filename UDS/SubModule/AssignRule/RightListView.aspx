<%@ Page language="c#" Codebehind="RightListView.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.AssginRule.RightListView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RightListView</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" href="../../Css/BasicLayout.css" type="text/css">
		<script language="javascript">
		function SelectItem()
		{
			var i = 0;
			var e;
			for( i = 0 ; i < RightListView.elements.length ; i ++ )
			{
				e = RightListView.elements[ i ];
				if( e.type == "checkbox" )	e.checked = !e.checked;
			}
		}
		// 高亮背景
		function high( which )
		{ 
			which.style.background = "#C0D9E6";
			which.style.font.color = "red";
		} 

		// 取消背景高亮
		function low( which )
		{ 
			which.style.background = "#FFFFFF";
			which.style.font.color = "black";
		}	
		
		function ReturnBack(DisplayType)
		{
			var a=DisplayType;
			if(a==0)
				location.href = "../Position/ListView.aspx?PositionID=<%=strObjID%>";			
			if(a==1)
				location.href = "../UnitiveDocument/Switch.aspx?Action=1&ClassID=<%=strObjID%>";
			if(a==2)
				location.href = "../Role/ListView.aspx?Role_ID=<%=strObjID%>";			
		}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="RightListView" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<TABLE class="gbtext" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center" width="90" background="../../images/maillistbutton2.gif" height="24"><FONT face="宋体" class="Newbutton">权限列表</FONT></TD>
								<TD align="right">
									<INPUT class="redButtonCss" id="btn_DelRight" type="button" value="删除权限" runat="server">
									<input type="button" value="加入权限" class="redButtonCss" runat="server" id="btn_AddRight">
									<input type="button" value="返回" name="cmdReturn" class="redButtonCss" OnClick="ReturnBack(<%=DisplayType%>);"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:DataGrid id="RightsGrid" runat="server" AutoGenerateColumns="False" PageSize="15" AllowPaging="True"
							Font-Names="宋体" BorderWidth="1px" BorderColor="#93BEE2" BorderStyle="None" BackColor="White"
							CellPadding="3" DataKeyField="rule_id" Width="100%" OnPageIndexChanged="DataGrid_PageChanged">
							<SelectedItemStyle  ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="Smaller" Font-Names="宋体" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Names="宋体"  HorizontalAlign="Center" ForeColor="White" BackColor="#337FB2"></HeaderStyle>
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="◎">
									<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="2%"></HeaderStyle>
									<ItemTemplate>
										<asp:CheckBox id="cb_RightID" Runat="server" Checked="False"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="proc_name" HeaderText="权限名">
									<HeaderStyle Font-Size="X-Small" Font-Names="宋体"  HorizontalAlign="Left" Width="19%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="proc_desc" HeaderText="权限描述">
									<HeaderStyle Font-Size="Smaller" Font-Names="宋体"  HorizontalAlign="Left" Width="58%"></HeaderStyle>
									<ItemStyle Font-Size="X-Small" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="权限对象">
									<HeaderStyle Font-Size="X-Small" HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle Font-Size="X-Small" HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:Label id=Label1 runat="server" Text='<%# (DataBinder.Eval(Container, "DataItem.classname")=="")?"全局":DataBinder.Eval(Container, "DataItem.classname") %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Right" ForeColor="#003399" BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
