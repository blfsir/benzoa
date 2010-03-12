<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetSearch.aspx.cs" Inherits="UDS.SubModule.Asset.AssetSearch" %>




<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Search</title>
		<meta name="vs_snapToGrid" content="True">
		<meta name="vs_showGrid" content="True">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE borderColor="#111111" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR height="30">
				 <td class="GbText" width="80" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                                    align="right">
                                    <img height="16" src="../../DataImages/staff.gif" width="16" /><font color="#006699">设备查询</font>
                                </td>
					 
				</TR>
			</TABLE>
			<FONT face="宋体">
				 
				<TABLE id="Table1" borderColor="#93bee2" cellSpacing="0" cellPadding="0" width="100%" border="1"
					style="BORDER-COLLAPSE: collapse" class="GbText">
					<TR>
						<TD style="WIDTH: 104px" height="24">设备名称</TD>
						<TD height="24"><asp:textbox id="txtName" runat="server" CssClass="inputcss"></asp:textbox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" ErrorMessage="请输入设备名称" ControlToValidate="txtName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="message" runat="server" EnableViewState="False"></asp:Literal></TD>
						 
					</TR>
					 
					<TR>
						<TD style="WIDTH: 104px" height="24"><INPUT class="redbuttoncss" type="button" value="返  回" onclick="javascript:location.href='AssetMange.aspx'"></TD>
						<TD height="24"><asp:button id="btn_Search" runat="server" Text="查  询" 
                                CssClass="redbuttoncss" onclick="btn_Search_Click"></asp:button></TD>
						 
					</TR>
					<tr>
            <td colspan="2">
             
                <%--<asp:DataGrid ID="dgAssetList" runat="server" BorderColor="#93BEE2" BorderStyle="None"
                    BorderWidth="1px" BackColor="White" CellPadding="3" PageSize="15" AllowPaging="True"
                    AutoGenerateColumns="False" DataKeyField="ID" Width="100%" AllowSorting="True"
                     OnPageIndexChanged="dgAssetList_PageIndexChanged" >
                    <SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
                    <AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
                    <ItemStyle Font-Size="X-Small" Wrap="false"></ItemStyle>
                    <HeaderStyle Font-Size="X-Small" Wrap="false" Font-Bold="True" ForeColor="White"
                        BackColor="#337FB2"></HeaderStyle>
                    <FooterStyle Font-Size="X-Small" HorizontalAlign="Right" BackColor="#E8F4FF"></FooterStyle>
                    <Columns>
                        <asp:TemplateColumn HeaderText="ID">
                            <HeaderStyle Width="20px"></HeaderStyle>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkStaff_ID" runat="server"></asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:HyperLinkColumn Text="资产名称" DataNavigateUrlField="ID" DataNavigateUrlFormatString="NewAsset.aspx?AssetID={0}"
                            DataTextField="AssetName" HeaderText="资产名称" SortExpression="AssetName">
                            <HeaderStyle Wrap="false"></HeaderStyle>
                            <ItemStyle Wrap="false" />
                        </asp:HyperLinkColumn>
                        <asp:BoundColumn DataField="AssetTypeID" SortExpression="AssetTypeID" HeaderText="规格及型号">
                            <HeaderStyle Wrap="false"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AssetNumber" SortExpression="AssetNumber" HeaderText="数量">
                            <HeaderStyle HorizontalAlign="Center" Wrap="false"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" Wrap="false"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AssetPreviousUserID" SortExpression="AssetPreviousUserID"
                            HeaderText="原使用人">
                            <HeaderStyle Wrap="false"></HeaderStyle>
                            <ItemStyle Wrap="false" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AssetCurrentUserID" SortExpression="AssetCurrentUserID"
                            HeaderText="现使用人">
                            <HeaderStyle Width="100px"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AssetCurrentUseState" SortExpression="AssetCurrentUseState"
                            HeaderText="现使用状况">
                            <HeaderStyle Wrap="false"></HeaderStyle>
                            <ItemStyle Wrap="false" />
                        </asp:BoundColumn>
                        
                    </Columns>
                    <PagerStyle Font-Size="X-Small" HorizontalAlign="left" BackColor="#E8F4FF" Mode="NumericPages">
                    </PagerStyle>
                </asp:DataGrid>--%>
            </td>
        </tr>
					 
				</TABLE>
				 
				<TABLE id="Table2" borderColor="#93bee2" cellSpacing="0" cellPadding="0" width="100%" border="1"
					style="BORDER-COLLAPSE: collapse" class="GbText">
					<tr>
            <td  >
             
                <asp:DataGrid ID="dgAssetList" runat="server" BorderColor="#93BEE2" BorderStyle="None"
                    BorderWidth="1px" BackColor="White" CellPadding="3" PageSize="15" AllowPaging="True"
                    AutoGenerateColumns="False" DataKeyField="ID" Width="100%" AllowSorting="True"
                     OnPageIndexChanged="dgAssetList_PageIndexChanged" >
                    <SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
                    <AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
                    <ItemStyle Font-Size="X-Small" Wrap="false"></ItemStyle>
                    <HeaderStyle Font-Size="X-Small" Wrap="false" Font-Bold="True" ForeColor="White"
                        BackColor="#337FB2"></HeaderStyle>
                    <FooterStyle Font-Size="X-Small" HorizontalAlign="Right" BackColor="#E8F4FF"></FooterStyle>
                    <Columns>
                        <asp:TemplateColumn HeaderText="ID">
                            <HeaderStyle Width="20px"></HeaderStyle>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkStaff_ID" runat="server"></asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:HyperLinkColumn Text="资产名称" DataNavigateUrlField="ID" DataNavigateUrlFormatString="NewAsset.aspx?AssetID={0}"
                            DataTextField="AssetName" HeaderText="资产名称" SortExpression="AssetName">
                            <HeaderStyle Wrap="false"></HeaderStyle>
                            <ItemStyle Wrap="false" />
                        </asp:HyperLinkColumn>
                        <asp:BoundColumn DataField="AssetTypeID" SortExpression="AssetTypeID" HeaderText="规格及型号">
                            <HeaderStyle Wrap="false"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AssetNumber" SortExpression="AssetNumber" HeaderText="数量">
                            <HeaderStyle HorizontalAlign="Center" Wrap="false"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" Wrap="false"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AssetPreviousUserID" SortExpression="AssetPreviousUserID"
                            HeaderText="原使用人">
                            <HeaderStyle Wrap="false"></HeaderStyle>
                            <ItemStyle Wrap="false" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AssetCurrentUserID" SortExpression="AssetCurrentUserID"
                            HeaderText="现使用人">
                            <HeaderStyle Width="100px"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AssetCurrentUseState" SortExpression="AssetCurrentUseState"
                            HeaderText="现使用状况">
                            <HeaderStyle Wrap="false"></HeaderStyle>
                            <ItemStyle Wrap="false" />
                        </asp:BoundColumn>
                        
                    </Columns>
                    <PagerStyle Font-Size="X-Small" HorizontalAlign="left" BackColor="#E8F4FF" Mode="NumericPages">
                    </PagerStyle>
                </asp:DataGrid>
            </td>
        </tr>
					 
				</TABLE>
				
			</FONT>
		</form>
	</body>
</HTML>