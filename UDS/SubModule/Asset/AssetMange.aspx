<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetMange.aspx.cs" Inherits="UDS.SubModule.Asset.AssetMange" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
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

    <link href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
</head>
<body ms_positioning="GridLayout" leftmargin="0" topmargin="0">
    <form id="ManageStaff" method="post" runat="server">
    <font face="宋体">
        <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td valign="top">
                    <table bordercolor="#111111" height="1" cellspacing="0" cellpadding="0" width="100%"
                        border="0">
                        <tbody>
                            <tr height="30">
                                <td class="GbText" width="80" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                                    align="right">
                                    <img height="16" src="../../DataImages/staff.gif" width="16" /><font color="#006699">设备管理</font>
                                </td>
                                <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width="60"
                                    align="right">
                                    &nbsp;
                                </td>
                                <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right"
                                    width="85%">
                                    <asp:Button ID="cmdNewStaff" runat="server" Text="新增IT设备" CssClass="redbuttoncss">
                                    </asp:Button>
                               
                                    <input type="button" value="规格型号设置" class="redbuttoncss" style="width: 80px;" onclick="javacript:location.href='AssetTypeManage.aspx'" />
                                    <input type="button" value="使用状态设置" class="redbuttoncss" style="width: 80px;" onclick="javacript:location.href='AssetStateManage.aspx'" />
                                    <input type="button" value="存放位置设置" class="redbuttoncss" style="width: 80px;" onclick="javacript:location.href='AssetLocationManage.aspx'" />
                                    
                                </td>
                </td>
            </tr>
            </TBODY></table>
        </TD></TR>
        <tr>
            <td>
                <asp:DataGrid ID="dbStaffList" runat="server"  
                    BorderColor="#93BEE2" BorderStyle="None" BorderWidth="1px" BackColor="White"
                    CellPadding="3" PageSize="15" AllowPaging="True" AutoGenerateColumns="False"
                    DataKeyField="Staff_ID" Width="100%" AllowSorting="True" >
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
                        <asp:HyperLinkColumn Text="资产名称" DataNavigateUrlField="staff_id" DataNavigateUrlFormatString="NewAssetType.aspx?AssetID={0}"
                            DataTextField="RealName" HeaderText="资产名称" SortExpression="RealName">
                            <HeaderStyle Wrap="false"></HeaderStyle>
                            <ItemStyle Wrap="false" />
                        </asp:HyperLinkColumn>
                        <asp:BoundColumn DataField="Mobile" SortExpression="Mobile" HeaderText="规格及型号">
                            <HeaderStyle Wrap="false"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Age" SortExpression="Age" HeaderText="数量">
                            <HeaderStyle HorizontalAlign="Center" Wrap="false"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" Wrap="false"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SexName" SortExpression="SexName" HeaderText="原使用人">
                            <HeaderStyle Wrap="false"></HeaderStyle>
                            <ItemStyle Wrap="false" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Email" SortExpression="Email" HeaderText="现使用人">
                            <HeaderStyle Width="100px"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="position_Name" SortExpression="position_Name" HeaderText="现使用状况
">
                            <HeaderStyle Wrap="false"></HeaderStyle>
                            <ItemStyle Wrap="false" />
                        </asp:BoundColumn>
                    </Columns>
                    <PagerStyle Font-Size="X-Small" HorizontalAlign="left" BackColor="#E8F4FF" Mode="NumericPages">
                    </PagerStyle>
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <div id="DisplayColumn" runat="server">
                </div>
            </td>
        </tr>
        </TABLE> </font>
    </form>
</body>
</html>
