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
		myconfirm = confirm("ȷʵҪ�رմ���,�˳��ĵ�һ�廯ϵͳ��");
		if (myconfirm==true){
			top.location.href="../SubModule/Login/logout.aspx?Action=1";
		}
	}
	if(action==2)
	{
		myconfirm = confirm("ȷʵҪ���µ�½��");
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
				alert("���ܲ�ѯ�����ַ���");
			else
				top.main.MainFrame.location= "../SubModule/Query/Listview.aspx?Key=" + Head.txtKey.value + "&amp;Range=15&amp;SearchType=3";				
		}
		else
		{
			top.main.MainFrame.location= "../SubModule/Query/Listview.aspx?Key=" + Head.txtKey.value + "&amp;Range=15&amp;SearchType=3";
		}
	}
	else
		alert("�������ѯ�ؼ��֣�");
}


		//��ȡʱ��
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
//�õ�������ʱ��ÿ��updatespan����У��һ�Σ�ÿ�����һ�α���ʱ��
function GetServerTime(updatespan)
{	
	var clientspan = 1*1000;
	//���±���ʱ��
	setInterval("Timer("+clientspan+")",clientspan);
	//ͬ��������ʱ��
	setInterval("window.location.href='ControlHeader.aspx'",updatespan);
	
}
//-->
    </script>

    
    <link href="../Css/mycss1.css" type="text/css" rel="stylesheet">
     <link href="../Css/oa.css" type="text/css" rel="stylesheet">
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
		c.innerText = "�ر�Ŀ¼"
	}
	else
	{
		Head.imgTreeStatus.src = "../Images/closetree.gif"		
		c.innerText = "��Ŀ¼"
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
     <div class="header"> 
    <table width="400" border="0" align="right" cellpadding="0" cellspacing="0" class="nav" > 
  <tr> 
    <td height="65">&nbsp;</td> 
  </tr> 
  <tr> 
    <td valign="top"><table width="446" border="0" cellspacing="0" cellpadding="0" class="navtxt"> 
      <tr> 
        <td width="25">&nbsp;</td> 
        <td width="30" align="center"><a href="../SubModule/UnitiveDocument/NewIndex.aspx" target="main">����</a></td> 
        <td width="44" align="center"><a href="#">����</a></td> 
        <td width="35" align="center"><a href="#">��ǩ</a></td> 
        <td width="44" align="center"><a href="#">�ռ�</a></td> 
        <td width="47" align="center"><a href="#">ͨѶ¼</a></td> 
        <td width="35" align="center"><a href="#">����</a></td> 
        <td width="46" align="center"><a href="../help/help.htm" target="_blank">����</a></td> 
        <td width="47" align="center"><a   onclick="ComfirmExit(2)" href="#" target="_self">�ص�¼</a></td> 
        <td width="40" align="center"><a  onclick="ComfirmExit(1)" href="#" target="_self">�˳�</a></td> 
        <td width="53">&nbsp;</td> 
      </tr> 
    </table></td> 
  </tr> 
</table> </div>
    </form>
</body>
</html>
