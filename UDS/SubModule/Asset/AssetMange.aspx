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
      <table bordercolor="#111111" height="1" cellspacing="0" cellpadding="0" width="100%"
                        border="0">
              <tr>
                <td width="20" height="30"
                                    align="center" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6" class="GbText"><img height="16" src="../../DataImages/staff.gif" width="16" /></td>
                <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width="60"
                                    align="center">设备管理</td>
                <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right"><asp:Button ID="cmdNewStaff" runat="server" Text="新增IT设备" CssClass="redbuttoncss"> </asp:Button>
                  <font face="宋体">&nbsp;</font>
                  <input type="button" value="规格型号设置" class="redbuttoncss" style="width: 80px;" onClick="javacript:location.href='AssetTypeManage.aspx'" />
                  <font face="宋体">&nbsp;</font>
                  <input type="button" value="使用状态设置" class="redbuttoncss" style="width: 80px;" onClick="javacript:location.href='AssetStateManage.aspx'" />
                  <font face="宋体">&nbsp;</font>
                  <input type="button" value="存放位置设置" class="redbuttoncss" style="width: 80px;" onClick="javacript:location.href='AssetLocationManage.aspx'" />
                  &nbsp;</td>
              </tr>
            </table>

        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" id="Table2">
          <tr>
            <td valign="top" height="10"></td>
          </tr>
          <tr>
            <td><asp:DataGrid ID="dbStaffList" runat="server"  
                    BorderColor="#93BEE2" BorderStyle="None" BorderWidth="1px" BackColor="White"
                    CellPadding="3" PageSize="15" AllowPaging="True" AutoGenerateColumns="False"
                    DataKeyField="Staff_ID" Width="100%" AllowSorting="True" >
              <selecteditemstyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></selecteditemstyle>
              <alternatingitemstyle Font-Size="X-Small" BackColor="#E8F4FF"></alternatingitemstyle>
              <itemstyle Font-Size="X-Small" Wrap="false"></itemstyle>
              <headerstyle Font-Size="X-Small" Wrap="false" Font-Bold="True" ForeColor="White"
                        BackColor="#337FB2"></headerstyle>
              <footerstyle Font-Size="X-Small" HorizontalAlign="Right" BackColor="#E8F4FF"></footerstyle>
              <columns>
                <asp:TemplateColumn HeaderText="ID">
                  <headerstyle Width="20px"></headerstyle>
                  <itemtemplate>
                    <asp:CheckBox ID="chkStaff_ID" runat="server"></asp:CheckBox>
                  </itemtemplate>
                </asp:TemplateColumn>
                <asp:HyperLinkColumn text="资产名称" DataNavigateUrlField="staff_id" DataNavigateUrlFormatString="NewAssetType.aspx?AssetID={0}"
                            DataTextField="RealName" headertext="资产名称" sortexpression="RealName">
                  <headerstyle Wrap="false"></headerstyle>
                  <itemstyle Wrap="false" />        
                </asp:HyperLinkColumn>
                <asp:BoundColumn DataField="Mobile" SortExpression="Mobile" HeaderText="规格及型号">
                  <headerstyle Wrap="false"></headerstyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Age" SortExpression="Age" HeaderText="数量">
                  <headerstyle HorizontalAlign="Center" Wrap="false"></headerstyle>
                  <itemstyle HorizontalAlign="Center" Wrap="false"></itemstyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="SexName" SortExpression="SexName" HeaderText="原使用人">
                  <headerstyle Wrap="false"></headerstyle>
                  <itemstyle Wrap="false" />        
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Email" SortExpression="Email" HeaderText="现使用人">
                  <headerstyle Width="100px"></headerstyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="position_Name" SortExpression="position_Name" HeaderText="现使用状况
">
                  <headerstyle Wrap="false"></headerstyle>
                  <itemstyle Wrap="false" />        
                </asp:BoundColumn>
                </columns>
              <pagerstyle Font-Size="X-Small" HorizontalAlign="left" BackColor="#E8F4FF" Mode="NumericPages"> </pagerstyle>
            </asp:DataGrid></td>
          </tr>
          <tr>
            <td></td>
          </tr>
          <tr>
            <td colspan="3"><div id="DisplayColumn" runat="server"></div></td>
          </tr>
        </table>
      </font></td>

    </form>
</body>
</html>
