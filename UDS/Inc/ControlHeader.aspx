<%@ Import Namespace="UDS.Components" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System" %>
<html>
<head>
    <title>Untitled Document</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">

    <script language="javascript">
<!--
function MM_openBrWindow(theURL,winName,features) { //v2.0
  window.open(theURL,winName,features);

}

//function getSubmodule(){
//	SubmoduleCon.innerHTML=Submodule.xml;
//}

function ShowModuleView(ModuleID){
	top.main.location="ModuleView.asp?ModuleID="+ ModuleID +"";
}

function ComfirmExit(action){
	if(action==1)
	{
		myconfirm = confirm("确实要关闭窗口,退出文档一体化系统吗？");
		if (myconfirm==true){
			top.location.href="../SubModule/Login/logout.aspx?Action=1";
		}
	}
	if(action==2)
	{
		myconfirm = confirm("确实要重新登陆吗？");
		if (myconfirm==true){
			top.location.href="../SubModule/Login/logout.aspx?Action=2";
		}
		
	}
}
function GetLink()
{
	var str = Head.txtKey.value;
	if(str!="")
	{
		if(Head.txtKey.value.length==1)
		{		
			if((str.toUpperCase()<="Z"&&str.toUpperCase()>="A")||(str.toUpperCase()<="9"&&str.toUpperCase()>="0"))
				alert("不能查询单个字符！");
			else
				top.main.MainFrame.location= "../SubModule/Query/Listview.aspx?Key=" + Head.txtKey.value + "&amp;Range=15&amp;SearchType=3";				
		}
		else
		{
			top.main.MainFrame.location= "../SubModule/Query/Listview.aspx?Key=" + Head.txtKey.value + "&amp;Range=15&amp;SearchType=3";
		}
	}
	else
		alert("请输入查询关键字！");
}


		//获取时间
function Timer(span)
{
	var tmp = new Date();
	var milsecs=Date.parse(tmp.getMonth()+"-"+tmp.getDay()+"-"+tmp.getFullYear()+" "+document.getElementById('lbl_Hour').innerText+":"+document.getElementById('lbl_Minute').innerText+":"+document.getElementById('lbl_Second').innerText);
	var timer = new Date(milsecs+span);
	var seconds,minutes,hours,date;
	if(timer.getSeconds()<10)
		seconds = "0"+timer.getSeconds();
	else
		seconds = timer.getSeconds();
	if(timer.getMinutes()<10)
		minutes = "0"+timer.getMinutes();
	else
		minutes = timer.getMinutes();
	if(timer.getHours()<10)
		hours = "0"+timer.getHours();
	else
		hours = timer.getHours();	
		date=timer.getDate();
	document.getElementById('lbl_Second').innerText = seconds;
	document.getElementById('lbl_Minute').innerText = minutes;
	document.getElementById('lbl_Hour').innerText = hours;
	}
//得到服务器时间每隔updatespan分钟校验一次，每秒更新一次本地时钟
function GetServerTime(updatespan)
{	
	var clientspan = 1*1000;
	//更新本地时钟
	setInterval("Timer("+clientspan+")",clientspan);
	//同步服务器时钟
	setInterval("window.location.href='ControlHeader.aspx'",updatespan);
	
}
//-->
    </script>

    <script language="C#" runat="server">
		
		private void Page_Load(){
		
		BBSClass bbsclass = new BBSClass();
			//显示系统公告
			
			SqlDataReader dr_sysbulletin = bbsclass.GetDeskTopBulletin();
			string innerstring = "";
			while(dr_sysbulletin.Read())
			{
				innerstring += "<a href='../SubModule/UnitiveDocument/BBS/Display.aspx?BoardID="+dr_sysbulletin["board_id"].ToString()+"&ItemID="+dr_sysbulletin["item_id"].ToString()+"' target='_blank' title='"+dr_sysbulletin["content"].ToString()+"'>" + dr_sysbulletin["title"].ToString() + "</a></font>";
			}
			sys_bulletin.InnerHtml = innerstring;
		
				lbl_Hour.Text = DateTime.Now.Hour.ToString();
				lbl_Minute.Text = DateTime.Now.Minute.ToString();
				lbl_Second.Text = DateTime.Now.Second.ToString();
				lbl_year.Text=DateTime.Now.Date.Year.ToString();
				lbl_month.Text=DateTime.Now.Date.Month.ToString();
				lbl_day.Text=DateTime.Now.Date.Day.ToString();}
													
				
		string GetTime(object day)
		{
			if(day.ToString()=="")
				return "";
			else
			{
				return(DateTime.Parse(day.ToString()).ToShortTimeString());			
			}
		
		}
				
    </script>

    <link href="../Css/mycss1.css" type="text/css" rel="stylesheet">
</head>
<body text="#ffffff" leftmargin="0" topmargin="0" onload="GetServerTime(15*60*1000)"
    marginheight="0" marginwidth="0">

    <script language="JavaScript">
function intPage(ParentNameStr){
	var myParentStr = "";
	myParentStr = parent.parent.location;
	myParentStr = myParentStr.toString();
	if (ParentNameStr.toLowerCase()==myParentStr.toLowerCase()){
	
	}else{
		ControlBar.style.visibility='hidden';
	}
}

function InfraUp(){
	parent.parent.UpFrame.rows="0,*"
}

function InfraDown(){
	parent.parent.UpFrame.rows="60,*"
}

function InfraLeft(c){
	var w,l;
	w = parent.parent.main.thisFrame.cols;
	l = w.substr(0,w.indexOf(","))	
	if(l==0)
	{
		Head.imgTreeStatus.src = "../Images/opentree.gif"		
		c.innerText = "关闭目录"
	}
	else
	{
		Head.imgTreeStatus.src = "../Images/closetree.gif"		
		c.innerText = "打开目录"
	}
	parent.parent.main.thisFrame.cols =  (180-l) +",*"
	
	
}

function InfraRight(){
	parent.parent.main.thisFrame.cols="180,*"
}

function InfraDefault(){
	parent.parent.UpFrame.rows="60,*"
	parent.parent.LeftFrame.cols="180,*";
}

function InfraMax(){
	parent.parent.UpFrame.rows="0,*"
	parent.parent.LeftFrame.cols="0,*";
}
function changeuser()
{
	var newdialoguewin = window.showModalDialog("../SubModule/Login/Index.aspx",window,"dialogWidth:600px;DialogHeight=490px;status:no");
	if(newdialoguewin!=null){}
}

    </script>

    <form name="Head">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td width="502" rowspan="2">
                <img height="89" src="../Images/head42.jpg" width="502" border="0">
            </td>
            <td bgcolor="#0051a5" height="41">
            </td>
        </tr>
        <tr>
            <td background="../Images/head7.jpg" height="48">
                <table id="Table4" height="22" cellspacing="0" cellpadding="0" width="98%" border="0">
                    <tr>
                        <td class="gbtext" align="center">
                            <div id="layer3" style="z-index: 3; position: absolute">
                                <div id="layer7" style="z-index: 4; left: -289px; width: 213px; position: absolute;
                                    top: -52px; height: 37px">
                                    <table height="30" width="100%" border="0">
                                        <tr>
                                            <td>
                                                <marquee id="sys_bulletin" onmouseover="this.stop()" onmouseout="this.start();" scrollamount="5"
                                                    direction="left" behavior="scroll" loop="0" runat="server"></marquee>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="layer5" style="z-index: 2; left: 146px; width: 371px; position: absolute;
                                    top: -68px; height: 31px">
                                    <table height="42" width="100%" border="0">
                                        <tr>
                                            <td bgcolor="#0051a5">
                                            </td>
                                            <td valign="top" width="316" background="../Images/head62.jpg">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="../SubModule/UnitiveDocument/Index.aspx"
                                                    target="main">我的桌面</a><font color="white">|</font><a href="../SubModule/WorkAttendance/Default.aspx"
                                                        target="MainFrame">考勤</a><font color="white">|</font><a href="../SubModule/UnitiveDocument/Setup/MySetup.aspx"
                                                            target="MainFrame">密码</a><font color="white">|</font><a href="../help/help.htm" target="_blank">帮助</a><font
                                                                color="white"><%--|</font><A href="../Help/About.aspx" target="MainFrame">关于</A><font color="white">--%>|</font><a
                                                                    onclick="ComfirmExit(2)" href="#" target="_self">重新登陆</a><font color="white">|</font><a
                                                                      href="../SubModule/Plan/EditPlan.aspx" target="MainFrame">计划总结</a><font color="white">|</font><a
                                                                        onclick="ComfirmExit(1)" href="#" target="_self">退出</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="layer4" style="z-index: 2; left: 256px; width: 250px; position: absolute;
                                    top: -33px; height: 24px">
                                    <%--<table width="100%" bgColor="#0051a5" border="0">
												<tr>
													<td></td>
													<td align="center" width="63"><A href="../SubModule/Query/Google.aspx" target="MainFrame">全文检索</A></td>
													<td align="center" width="98"><INPUT id="txtKey" onkeydown="if(event.keyCode == 13) { GetLink();}" style="BORDER-RIGHT: #ffffff 1px solid; BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid; BORDER-BOTTOM: #ffffff 1px solid"
															type="text" size="12" name="txtKey" height="12px"></td>
													<td align="center" width="43"><A style="CURSOR: hand" onclick="GetLink()" target="Main"><IMG id="IMG1" height="24" src="../images/Udssearchbutton.gif" width="26" border="0"></A></td>
												</tr>
											</table>--%>
                                </div>
                                <div id="layer6" style="z-index: 3; left: 348px; width: 160px; position: absolute;
                                    top: 8px; height: 15px">
                                    <asp:Label ID="lbl_year" runat="server" Font-Size="X-Small" ForeColor="white">Label</asp:Label><font
                                        color="white">年</font><asp:Label ID="lbl_month" runat="server" Font-Size="X-Small"
                                            ForeColor="white">Label</asp:Label><font color="white">月</font><asp:Label ID="lbl_day"
                                                runat="server" Font-Size="X-Small" ForeColor="white">Label</asp:Label><font color="white">日</font>
                                    <asp:Label ID="lbl_Hour" runat="server" Font-Size="X-Small" ForeColor="White"></asp:Label><font
                                        color="white">:</font><asp:Label ID="lbl_Minute" runat="server" Font-Size="X-Small"
                                            ForeColor="White"></asp:Label><font color="white">:</font><asp:Label ID="lbl_Second"
                                                runat="server" Font-Size="X-Small" ForeColor="White"></asp:Label>
                                </div>
                            </div>
                        </td>
                        <td valign="middle" align="center" width="100">
                        </td>
                        <td align="center">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
