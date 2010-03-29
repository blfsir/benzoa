<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanManage.aspx.cs" Inherits="UDS.SubModule.Plan.PlanManage" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>ManagePlan</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

    <script language="javascript">
			
	 
		var active = new Image();
		var nonactive = new Image();
		active.src = '../../images/maillistbutton2.gif';
		nonactive.src = '../../images/maillistbutton1.gif';

function changebkg(tdnumber)
{
alert('here');
alert(tdnumber);

   document.getElementById("td1").background="../../images/maillistbutton1.gif";
document.getElementById("td2").background="../../images/maillistbutton1.gif";
document.getElementById("td3").background="../../images/maillistbutton1.gif";
document.getElementById("td4").background="../../images/maillistbutton1.gif";
document.getElementById(tdnumber).background="../../images/maillistbutton2.gif";
 
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
		 
    </script>

    <link href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
</head>
<body leftmargin="0" topmargin="0">
    <form id="Listview" method="post" runat="server">
    <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0"
        bordercolor="#111111">
        <tr>
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/common.gif" width="16">
            </td>
            <td width="60" height="30" align="left" background="../../../Images/treetopbg.jpg"
                bgcolor="#e8f4ff" class="GbText">
                &nbsp;<font color="#006699">计划总结</font>
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
                <font face="宋体">
                    <input type="button" value="计划录入" class="redButtonCss" style="width: 80px;" onclick="javacript:location.href='EditPlan.aspx'" />
                    <input type="button" value="查询" class="redButtonCss" style="width: 80px;" onclick="javacript:location.href='PlanSearch.aspx'" />
                    &nbsp;</font>
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
                    <tr>
                        <td id="td1" align="center" width="90" background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>.gif' height="24">
                            <asp:LinkButton ID="lbtnWeek" runat="server" CssClass="Newbutton" OnClick="lbtnWeek_Click" >周计划</asp:LinkButton>
                        </td>
                        <td id="td2"  align="center" width="90" background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,2));%>.gif' height="24">
                            <asp:LinkButton ID="lbtnMonth" runat="server" CssClass="Newbutton" OnClick="lbtnMonth_Click">月计划</asp:LinkButton>
                        </td>
                        <td  id="td3" align="center" width="90" background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,3));%>.gif' height="24">
                            <asp:LinkButton ID="lbtnSeason" runat="server" CssClass="Newbutton" OnClick="lbtnSeason_Click">季计划</asp:LinkButton>
                        </td>
                        <td id="td4"  align="center" width="90" background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,4));%>.gif' height="24">
                            <asp:LinkButton ID="lbtnYear" runat="server" CssClass="Newbutton" OnClick="lbtnYear_Click">年计划</asp:LinkButton>
                        </td>
                        <td align="left">
                            &nbsp;&nbsp;
                            <asp:DropDownList ID="ddlPlanObjectType" runat="server">
                                <asp:ListItem Text="个人计划" Value="个人计划"></asp:ListItem>
                                <asp:ListItem Text="部门计划" Value="部门计划"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="line-height: 20px;">
                <asp:DataGrid ID="dbStaffList" runat="server" BorderColor="#93BEE2" BorderStyle="None"
                    BorderWidth="1px" BackColor="White" CellPadding="3" PageSize="15" AllowPaging="True"
                    AutoGenerateColumns="False" Width="100%" ShowHeader="true">
                    <SelectedItemStyle  ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
                    <AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
                    <ItemStyle Font-Size="X-Small" Wrap="false"></ItemStyle>
                    <HeaderStyle Font-Size="X-Small" Wrap="false"  ForeColor="White"
                        BackColor="#337FB2"></HeaderStyle>
                    <FooterStyle Font-Size="X-Small" HorizontalAlign="Right" BackColor="#E8F4FF"></FooterStyle>
                    <Columns>
                        <asp:BoundColumn DataField="id" HeaderText="编号" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Wrap="false"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" Wrap="false"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="标题">
                            <ItemTemplate>
                                <a href="PlanView.aspx?planID=<%# DataBinder.Eval(Container.DataItem,"id")%>">
                                    <%#  DataBinder.Eval(Container.DataItem,"planname")%></a>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="plancreatedate" HeaderText="创建时间">
                            <HeaderStyle Wrap="false"></HeaderStyle>
                        </asp:BoundColumn>
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
