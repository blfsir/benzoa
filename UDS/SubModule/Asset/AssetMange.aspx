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
			function delete_confirm(e) {
				if (event.srcElement.outerText == "删除")
				event.returnValue =confirm("您确认要删除?");
			}
			document.onclick=delete_confirm;		
    </script>

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
<%--<body ms_positioning="GridLayout" leftmargin="0" topmargin="0">
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
                                    <input type="button" value="新增IT设备" class="redbuttoncss" style="width: 80px;" onclick="javacript:location.href='NewAsset.aspx'" />
                                    <input type="button" value="查询设备" class="redbuttoncss" style="width: 80px;" onclick="javacript:location.href='AssetSearch.aspx'" />
                                    <asp:button id="btnMove" runat="server" Text="设备转移" CssClass="redbuttoncss" 
                                        style="width: 80px;" onclick="btnMove_Click" ></asp:button>
                                    &nbsp;<input type="button" value="规格型号设置" class="redbuttoncss" style="width: 80px;"
                                        onclick="javacript:location.href='AssetTypeManage.aspx'" />
                                    <input type="button" value="使用状态设置" class="redbuttoncss" style="width: 80px;" onclick="javacript:location.href='AssetStateManage.aspx'" />
                                    <input type="button" value="存放位置设置" class="redbuttoncss" style="width: 80px;" onclick="javacript:location.href='AssetLocationManage.aspx'" />
                                    &nbsp;
                                </td>
                </td>
            </tr>
            </TBODY></table>
        </TD></TR>
        <tr>
            <td>
             
                <asp:DataGrid ID="dgAssetList" runat="server" BorderColor="#93BEE2" BorderStyle="None"
                    BorderWidth="1px" BackColor="White" CellPadding="3" PageSize="15" AllowPaging="True"
                    AutoGenerateColumns="False" DataKeyField="ID" Width="100%" AllowSorting="True"
                    OnDeleteCommand="dgAssetList_DeleteCommand" OnPageIndexChanged="dgAssetList_PageIndexChanged"
                    OnSelectedIndexChanged="dgAssetList_SelectedIndexChanged">
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
                        <asp:ButtonColumn Text="删除" HeaderText="删除" CommandName="Delete">
                            <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:ButtonColumn>
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
</body>--%>

<body leftmargin="0" topmargin="0">
    <form id="Listview" method="post" runat="server">
    <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0" style="table-layout:fixed"
        bordercolor="#111111">
        <tr height="30">
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/t5.jpg" width="16">
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width="60"
                align="left">
                <font color="#006699">设备管理</font>
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
                <font face="宋体">
                    <input type="button" value="新增IT设备" class="redbuttoncss" style="width: 80px;" onclick="javacript:location.href='NewAsset.aspx'" />
                                    <input type="button" value="查询设备" class="redbuttoncss" style="width: 80px;" onclick="javacript:location.href='AssetSearch.aspx'" />
                                    <asp:button id="btnMove" runat="server" Text="设备转移" CssClass="redbuttoncss" 
                                        style="width: 80px;" onclick="btnMove_Click" ></asp:button>
                                    <input type="button" value="规格型号设置" class="redbuttoncss" style="width: 80px;"
                                        onclick="javacript:location.href='AssetTypeManage.aspx'" />
                                    <input type="button" value="使用状态设置" class="redbuttoncss" style="width: 80px;" onclick="javacript:location.href='AssetStateManage.aspx'" />
                                    <input type="button" value="存放位置设置" class="redbuttoncss" style="width: 80px;" onclick="javacript:location.href='AssetLocationManage.aspx'" />&nbsp;</font>
            </td>
        </tr>
    </table>
    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" id="Table1">
        <tr>
            <td>
                <table class="gbtext" id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="10" colspan="3" align="center">
                        </td>
                    </tr>
                    
                </table>
            </td>
        </tr>
        <tr>
            <td style="line-height: 20px;">
                <asp:DataGrid ID="dgAssetList" runat="server" BorderColor="#93BEE2" BorderStyle="None"
                    BorderWidth="1px" BackColor="White" CellPadding="3" PageSize="15" AllowPaging="True"
                    AutoGenerateColumns="False" DataKeyField="ID" Width="100%" AllowSorting="True"
                    OnDeleteCommand="dgAssetList_DeleteCommand" OnPageIndexChanged="dgAssetList_PageIndexChanged"
                    OnSelectedIndexChanged="dgAssetList_SelectedIndexChanged">
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
                        <asp:ButtonColumn Text="删除" HeaderText="删除" CommandName="Delete">
                            <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:ButtonColumn>
                    </Columns>
                    <PagerStyle Font-Size="X-Small" HorizontalAlign="left" BackColor="#E8F4FF" Mode="NumericPages">
                    </PagerStyle>
                </asp:DataGrid>
            </td>
        </tr>
       </table>
    </form>
</body>

</html>
