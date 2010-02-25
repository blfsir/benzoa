
//var myDate = "<%=date()%>";     
//year = "<%=year(date)%>";
//month = "<%=month(date)%>";
//date = "<%=day(date)%>";
//time
var curDate; //当前系统日期。
var week = new Array('S','M','T','W','T','F','S');
//获得击中的日历日期所在的单元
function getValue(obj)
{
	var isHaveCal = obj.getAttribute("have");
	//alert(isHaveCal);
	if(isHaveCal==1) openWin("日程查询","calendar/cal_month.asp")
	else openWin("日程安排","calendar/CalendarNew.asp")
  
}  
//重新画日历单元格日期
function showDate0(year,month,haveCalDays)
{ //alert(haveCalDays)
	var myDate = new Date(year,month-1,1);
	//var today = new Date();	

	var day = myDate.getDay();
	var length = new Array(31,30,31,30,31,30,31,31,30,31,30,31);
	length[1] = ((year%4==0)&&(year%100!=0)||(year%400==0))?29:28;
	//清空日历内容
	for(i=0;i<Cal_Day.cells.length;i++)
	{Cal_Day.cells[i].innerHTML = ""; Cal_Day.cells[i].style.backgroundColor="";}
	//日历重新设置年月及日程
	haveCalDays = ","+haveCalDays+",";
	var isHave = 0;
	for(i=0;i<length[month-1];i++)
	{
		var curday = ","+(i+1).toString(10)+",";
		if(haveCalDays.indexOf(curday)>-1) //有日程
		{curday = i+1; isHave=1; Cal_Day.cells[i+day].style.backgroundColor="#FEE1FF";}
		else 
		{curday = i+1; isHave=0; }
		
		Cal_Day.cells[i+day].innerHTML = curday; 
		Cal_Day.cells[i+day].setAttribute("have",isHave);
		if ((curDate.getYear()==year)&&(curDate.getMonth()==month-1)&&(curDate.getDate()==i+1))
			{Cal_Day.cells[i+day].style.backgroundColor="#C5FF48";Cal_Day.cells[i+day].style.fontWeight ="bolder";Cal_Day.cells[i+day].style.color="#FF8E15";}
		else
			Cal_Day.cells[i+day].style.color="#7F8F8F";	
		/*if(new Date(year,month-1,i+1).getDay()==6||new Date(year,month-1,i+1).getDay()==0)
		{
		  Cal_Day.cells[i+day].style.color='#7F8F8F';
		}*/
	}      
	Cal_Title.cells[1].innerText=year+","+month;
}
//异步读取某个月哪天有日程，在这个异步中会调用绘画日程表格的函数
function showDate(year,month)
{
	XsendDate("calendar/cal_IndexMonth.asp","year="+year+"&month="+month);
}
//主页调用
function IndexShowDate(IndexYear,IndexMonth,IndexDay)
{
	curDate = new Date(IndexYear,IndexMonth-1,IndexDay);
	showDate(IndexYear,IndexMonth);
}
//一些附加函数--------------------
  //---------Begin-------------------
  function mOver(obj){obj.className = 'calmover';}
  function mOut(obj){obj.className='calmovel';}     
  function addYear()
  {
	  var date=Cal_Title.cells[1].innerText; date=date.split(",");
	  var year = parseInt(date[0]);var month = parseInt(date[1]); 
  	  year++;showDate(year,month);
  }
  function addMonth()
  {
	  var date=Cal_Title.cells[1].innerText; date=date.split(",");
	  var year = parseInt(date[0]);var month = parseInt(date[1]);
	  month++;if(month>12){month=1;year++;}
	  showDate(year,month);
  }
  function cutYear()
  {
	  var date=Cal_Title.cells[1].innerText; date=date.split(",");
	  var year = parseInt(date[0]);var month = parseInt(date[1]);	  
	  year--;
	  showDate(year,month);
  }
  function cutMonth()
  {
	  var date=Cal_Title.cells[1].innerText; date=date.split(",");
	  var year = parseInt(date[0]);var month = parseInt(date[1]);
	  month--;
	  if(month<1){month=12;year--;}
	  showDate(year,month);
  }
  
  function divS(obj)
    {
    if(obj!=divObj)
      {
      obj.style.backgroundColor="#909eff";
      obj.style.color='black';
      }   
      if(divObj!=null)
      { 
      divObj.style.backgroundColor='';
      divObj.style.color='';
      }   
      divObj = obj;     
    }
    
function divShow(obj)
{ 
	if (Cal_Day_timeset!=null) clearTimeout(Cal_Day_timeset);
    obj.style.display='block';
}
function divHidden(obj){Cal_Day_timeset=window.setTimeout(function(){obj.style.display='none'},500);}
function createyear(year,obj)//创建年份选择
    {
    var ystr;
    var oDiv;
      ystr="<table class='calmove1' cellspacing=1 border=1 cellpadding=2 width="+(obj.offsetWidth)+">";
      ystr+="<tr><td style='cursor:hand' onclick='createyear("+(year-20)+",Cal_Top.cells[2])' align=center>上翻</td></tr>";
      for(i=year-10;i<year+10;i++)
        if(year==i)
        ystr+="<tr style='background-color:#909eff'><td style='color:black;height:11px;cursor:hand' align=center onclick='Cal_Top.cells[2].innerText=this.innerText;showDate("+i+",parseInt(Cal_Top.cells[3].innerText));Cal_Day.parentElement.nextSibling.innerHTML=\"\"'>"+i+"年</td></tr>";
        else
        ystr+="<tr><td align=center style='cursor:hand' onclick='Cal_Top.cells[2].innerText=this.innerText;showDate("+i+",parseInt(Cal_Top.cells[3].innerText));Cal_Day.parentElement.nextSibling.innerHTML=\"\"'>"+i+"年</td></tr>";
      ystr+="<tr><td style='cursor:hand' onclick='createyear("+(year+20)+",Cal_Top.cells[2])' align=center>下翻</td></tr>";
      ystr+="</table>";
      
      oDiv = Cal_Day.parentElement.nextSibling;
          oDiv.innerHTML='';
          oDiv.innerHTML = ystr;
      
      showDiv(oDiv,obj.offsetTop+obj.offsetHeight,obj.offsetLeft);
}
	
function createmonth(month,obj)//创建月份选择
{
    var mstr;
    var oDiv;
      mstr="<table class='calmove1' cellspacing=0 cellpadding=2 width="+obj.offsetWidth+">";
      for(i=1;i<13;i++)
        if (month==i)
        mstr+="<tr style='background-color:#909eff '><td style='color:black;height:11px;cursor:hand' align=center onclick='Cal_Top.cells[3].innerText=this.innerText;showDate(parseInt(Cal_Top.cells[2].innerText),"+i+");Cal_Day.parentElement.nextSibling.innerHTML=\"\"'>"+i+"月</td></tr>";
        else
        mstr+="<tr><td align=center style='cursor:hand' onclick='Cal_Top.cells[3].innerText=this.innerText;showDate(parseInt(Cal_Top.cells[2].innerText),"+i+");Cal_Day.parentElement.nextSibling.innerHTML=\"\"'>"+i+"月</td></tr>";
      mstr+="</table>";

      oDiv = Cal_Day.parentElement.nextSibling;
            oDiv.innerHTML='';
            oDiv.innerHTML = mstr;
      showDiv(oDiv,obj.offsetTop+obj.offsetHeight,obj.offsetLeft); 
}
      
function showDiv(obj,top,left)
{
	obj.style.pixelTop=top;
	obj.style.pixelLeft=left;
}

// --------------End ---------------------    
//画日程表格
function getCalendar()
{
	var str="";  
	str=str+"<div class='calcs'>"
	str=str+"<div class='shadow'></div>";
	str=str+"<table class='caltitle' id='Cal_Title'><tr>";
	str=str+"<td align=left style='font-size:11px;font-weight:bold; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif'></td>";
	str=str+"<td align=left style='font-size:11px;font-weight:bold; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif'></td>";
	str=str+"<td align=right><span id='spanTime' style='font-size:11px; font-weight:bold; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif;color:#FF8D16;'></span></td>";//显示时钟
	str=str+"</tr></table>";
	//创建星期条目
  str=str+"<table cellpadding=1 cellspacing=1 bgcolor=#79A7E2 ><tr>";
  for(i=0;i<7;i++)
	str=str+"<td align=center style='FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif;font-weight:bold; background-color:#B5D1EA;font-size:9px; color:#7F8E91; width:28px;height:8px;'>"+week[i]+"</td>";
	str=str+"</tr></table>";
	//创建日期条目
	str=str+"<table id='Cal_Day' cellpadding=1 cellspacing=1  bgcolor=#79A7E2  style='width:203px;font-size:11px;cursor:hand;height:8px;'>";
	for(i=0;i<6;i++)
	{
		str=str+"<tr>";
		for(j=0;j<7;j++)
			str=str+"<td class='calDay' align=center onclick='if(this.innerText!=\"\")getValue(this);'></td>";
		str=str+"</tr>";
	}
	str=str+"</table>";
	//创建头部
	str=str+"<table class='caltit'  border=0 cellpadding=0 cellspacing=0 id='Cal_Top' onmousedown='Cal_Day_x=event.x-parentNode.parentNode.style.pixelLeft;Cal_Day_y=event.y-parentNode.parentNode.style.pixelTop;setCapture()' onmouseup='releaseCapture();'>";
	str=str+"<tr>";
	str=str+"<td align='center'  height=3px>";
	str=str+"<span title='减少月份' onmouseover='this.style.color=\"black\"' onclick='cutMonth()' onmouseout='this.style.color=\"\"' width=10 style='font-family: Webdings;cursor:hand;color:#7F8E91;'>3</span>";
	str=str+"<span style='font-size:11px;font-weight:bold; color:#7F8E91;FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif' >MONTH</span>";
	str=str+"<span width=10 onmouseover='this.style.color=\"black\"' onmouseout='this.style.color=\"\"' onclick='addMonth()' style='font-family: Webdings;cursor:hand;color:#7F8E91;' title='增加月份'>4</span>";
	str=str+"<br>";
	str=str+"<span width=10 onmouseover='this.style.color=\"black\"' onmouseout='this.style.color=\"\"' onclick='cutYear()' style='font-family: Webdings;cursor:hand;color:#7F8E91;' title='减少年份'>7</span>";
	str=str+"<span style='font-size:11px;font-weight:bold; color:#7F8E91;FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif'>YEAR</span>";
	str=str+"<span width=10 style='font-family: Webdings;cursor:hand; color:#7F8E91;' onmouseover='this.style.color=\"black\"' onmouseout='this.style.color=\"\"' onclick='addYear()' title='增加年份'>8</span>";
	str=str+"</td>";
	str=str+"</tr></table>";  
	return str;
}