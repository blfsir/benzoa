<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Data" %>

<%@ Page Language="c#" CodeBehind="SearchData.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.WorkAttendance.SearchData" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>SearchData</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">

    <script language="JavaScript" src="../../Css/meizzDate.js"></script>

    <script language="javascript">
		function fillstring(str)
		{
			if(str.length==1)
			{
				str = "0" + str; 
			}
			return(str);
		}
		function quickseldate(type)
		{
			var begintime,endtime;
			var oneminute = 60*1000;
			var onehour   = 60*oneminute;
			var oneday    = 24*onehour;
			var oneweek   = 7*oneday;
			
			var todayDate = new Date();
			var date = todayDate.getDate();
			var month= todayDate.getMonth() +1;
			var year= todayDate.getYear();
			var day = todayDate.getDay();
			if(navigator.appName == "Netscape")
			{
				year = 1900 + year;
			}

			//-->
						
			if(type=="day")
			{
				begintime = year.toString() + "-" + fillstring(month.toString()) + "-" + fillstring(date.toString());
				endtime = begintime;
			}
			else if(type=="week")
			{
				var daytoMon = day-1;
				if(day==0) 
					daytoMon = 6;
				
				todayDate.setTime(todayDate.getTime()-daytoMon*oneday);
				date = todayDate.getDate();
				month= todayDate.getMonth() +1;
				year= todayDate.getYear();
				day = todayDate.getDay();
				
				begintime = year.toString() + "-" + fillstring(month.toString()) + "-" + fillstring(date.toString());
				
				todayDate.setTime(todayDate.getTime()+6*oneday);
				
				date = todayDate.getDate();
				month= todayDate.getMonth() +1;
				year= todayDate.getYear();
				
				endtime = year.toString() + "-" + fillstring(month.toString()) + "-" + fillstring(date.toString());
			}
			else if(type=="month")
			{
				var dateto1 = date-1;
				
				todayDate.setTime(todayDate.getTime()-dateto1*oneday);
				date = todayDate.getDate();
				month= todayDate.getMonth() +1;
				year= todayDate.getYear();
				day = todayDate.getDay();
				
				begintime = year.toString() + "-" + fillstring(month.toString()) + "-" + fillstring(date.toString());
				
				todayDate.setMonth(month);
				todayDate.setTime(todayDate.getTime()-oneday);
				
				date = todayDate.getDate();
				month= todayDate.getMonth() +1;
				year= todayDate.getYear();
				
				endtime = year.toString() + "-" + fillstring(month.toString()) + "-" + fillstring(date.toString());

			}

			document.getElementById("txtbegintime").value = begintime;
			document.getElementById("txtendtime").value = endtime;
			//alert(document.getElementById("txtbegintime").value);
			 
		}
    </script>

    <script language="C#" runat="server">
        string GetGridData(string staffid, int type)
        {

            //type:0 正常 1：迟到 2：早退 3：未考勤 4：总考勤天数
            switch (type)
            {
                case 0:
                    dvw.RowFilter = "OnDuty_Status = false and OffDuty_Status = false and staff_id=" + staffid;
                    break;
                case 1:
                    dvw.RowFilter = "OnDuty_Status=true and staff_id=" + staffid;
                    break;
                case 2:
                    dvw.RowFilter = "OffDuty_Status = true and staff_id=" + staffid;
                    break;
                case 3:
                    dvw.RowFilter = "staff_id=" + staffid;
                    return ((dvw1.Count - dvw.Count).ToString());
                    break;
                case 4:
                    break;
            }
            return (dvw.Count.ToString());

        } 
    </script>

</head>
<body leftmargin="0" topmargin="0">
    <form id="SearchData" method="post" runat="server">
    <font face="宋体">
        <table id="Table1" bordercolor="#111111" height="1" cellspacing="0" cellpadding="0"
            width="100%" border="0">
            <tr height="30">
                <td class="GbText" width="3%" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">
                    <font color="#003366" size="3">
                        <img alt="" src="../../DataImages/kaoqin2.gif"></font>
                </td>
                <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">
                    <b><b>考勤查询</b></b>
                </td>
            </tr>
        </table>
        <table class="GBText" id="Table1" style="border-collapse: collapse; height: 242px"
            bordercolor="#93bee2" height="242" cellspacing="1" cellpadding="1" width="100%"
            border="1" designtimedragdrop="56">
            <tr>
                <td style="width: 84px">
                    输入时间段
                </td>
                <td>
                    开始时间：
                    <asp:TextBox ID="txtbegintime" onfocus="setday(this);" runat="server" CssClass="inputcss" Text="" AutoPostBack="true"
                        Columns="10" ReadOnly="True"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" Display="None" ControlToValidate="txtbegintime" ErrorMessage="开始时间不能为空"></asp:RequiredFieldValidator>--结束时间
                    <asp:TextBox ID="txtendtime" AutoPostBack="true" onfocus="setday(this);" runat="server" CssClass="inputcss"
                        Columns="10" ReadOnly="True"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            runat="server" Display="None" ControlToValidate="txtendtime" ErrorMessage="结束不能为空"></asp:RequiredFieldValidator>&nbsp;
                    <asp:CompareValidator ID="cvdate" runat="server" Display="None" ControlToValidate="txtendtime"
                        ErrorMessage="结束时间应该大于开始时间" Operator="GreaterThanEqual" ControlToCompare="txtbegintime"></asp:CompareValidator>&nbsp;
                    <asp:RadioButton ID="rbtnthisweek" onclick="quickseldate('week');" runat="server"
                        Text="本周" GroupName="quickdate"></asp:RadioButton><asp:RadioButton ID="rbtnthismonth"
                            onclick="quickseldate('month');" runat="server" Text="本月" GroupName="quickdate">
                        </asp:RadioButton>
                </td>
            </tr>
            <tr>
                <td style="width: 84px">
                    查找范围
                </td>
                <td>
                    <asp:DropDownList ID="ddlsearchbound" runat="server" Width="300px" AutoPostBack="True">
                        <asp:ListItem Value="0" Selected="True">公司</asp:ListItem>
                        <asp:ListItem Value="1">职位</asp:ListItem>
                        <asp:ListItem Value="2">个人</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 84px">
                    请选择
                </td>
                <td>
                    <asp:ListBox ID="lbstaffs" runat="server" CssClass="inputcss" Width="150px" SelectionMode="Multiple"
                        Height="141px" Visible="False"></asp:ListBox>
                    <asp:DropDownList ID="ddldepartments" runat="server" Width="150px" Visible="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 84px">
                </td>
                <td>
                    <asp:ValidationSummary ID="vs1" runat="server"></asp:ValidationSummary>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="30">
                    <asp:Button ID="btnsearch" runat="server" CssClass="buttoncss" Text=" 查  询 "></asp:Button>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                    <asp:DataGrid ID="AttendanceGrid" runat="server" Width="100%" CellPadding="3" BorderWidth="1px"
                        BorderColor="#93BEE2" DataKeyField="staff_id" EnableViewState="False" AutoGenerateColumns="False">
                        <HeaderStyle Font-Size="X-Small" BackColor="#E8F4FF"></HeaderStyle>
                        <Columns>
                            <asp:BoundColumn DataField="realname" HeaderText="姓名">
                                <ItemStyle Font-Size="X-Small"></ItemStyle>
                                <FooterStyle Font-Size="X-Small"></FooterStyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="正常天数">
                                <ItemTemplate>
                                    <asp:HyperLink Text='<%# GetGridData(((DataRowView)Container.DataItem)["Staff_ID"].ToString(),0)%>'
                                        NavigateUrl='<%# "tmpStaffData.aspx?staffid="+((DataRowView)Container.DataItem)["Staff_ID"].ToString()+"&begintime="+txtbegintime.Text+"&endtime="+txtendtime.Text+"&type=1"%>'
                                        Target="_blank" runat="server">
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="迟到天数">
                                <ItemTemplate>
                                    <asp:HyperLink Text='<%# GetGridData(((DataRowView)Container.DataItem)["Staff_ID"].ToString(),1)%>'
                                        NavigateUrl='<%# "tmpStaffData.aspx?staffid="+((DataRowView)Container.DataItem)["Staff_ID"].ToString()+"&begintime="+txtbegintime.Text+"&endtime="+txtendtime.Text+"&type=2"%>'
                                        Target="_blank" runat="server">
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="早退天数">
                                <ItemTemplate>
                                    <asp:HyperLink Text='<%# GetGridData(((DataRowView)Container.DataItem)["Staff_ID"].ToString(),2)%>'
                                        NavigateUrl='<%# "tmpStaffData.aspx?staffid="+((DataRowView)Container.DataItem)["Staff_ID"].ToString()+"&begintime="+txtbegintime.Text+"&endtime="+txtendtime.Text+"&type=3"%>'
                                        Target="_blank" runat="server">
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="未考勤天数">
                                <ItemTemplate>
                                    <asp:HyperLink Text='<%# GetGridData(((DataRowView)Container.DataItem)["Staff_ID"].ToString(),3)%>'
                                        NavigateUrl='<%# "tmpStaffData.aspx?staffid="+((DataRowView)Container.DataItem)["Staff_ID"].ToString()+"&begintime="+txtbegintime.Text+"&endtime="+txtendtime.Text+"&type=4"%>'
                                        Target="_blank" runat="server">
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="总考勤天数">
                                <ItemTemplate>
                                    <asp:HyperLink Text='<%# GetGridData(((DataRowView)Container.DataItem)["Staff_ID"].ToString(),4)%>'
                                        NavigateUrl='<%# "tmpStaffData.aspx?staffid="+((DataRowView)Container.DataItem)["Staff_ID"].ToString()+"&begintime="+txtbegintime.Text+"&endtime="+txtendtime.Text+"&type=5"%>'
                                        Target="_blank" runat="server" ID="Hyperlink1" NAME="Hyperlink1">
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </asp:DataGrid><input class="buttoncss" id="btn_Report" type="button" value="打印报表"
                        style="display: none" runat="server">
                </td>
            </tr>
        </table>
    </font>
    </form>
</body>
</html>
