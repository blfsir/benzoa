using System;
using System.Text.RegularExpressions;

namespace UDS.Components
{
	/// <summary>
	/// UBB 的摘要说明。
	/// </summary>
	public class UBB
	{
		private static string dvHTMLEncode(string fString)
		{
			if(fString!=string.Empty)
			{
				fString.Replace("<","&lt;");
				fString.Replace(">","&rt;");
				fString.Replace(((char)34).ToString(), "&quot;");
				fString.Replace(((char)39).ToString(), "&#39;");
				fString.Replace(((char)13).ToString(), "");
				fString.Replace(((char)10).ToString(), "<BR> ");

			}
			return(fString);
		}

		public static string txtMessage(string str)
		{
			str = dvHTMLEncode(str);
			if(str!="")
			{
				Regex my=new Regex(@"(\[IMG\])(.[^\[]*)(\[\/IMG\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<a href=""$2"" target=_blank><IMG SRC=""$2"" border=0 alt=按此在新窗口浏览图片 onload=""javascript:if(this.width>screen.width-333)this.width=screen.width-333""></a>");

				my=new Regex(@"\[DIR=*([0-9]*),*([0-9]*)\](.[^\[]*)\[\/DIR]",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<object classid=clsid:166B1BCA-3F9C-11CF-8075-444553540000 codebase=http://download.macromedia.com/pub/shockwave/cabs/director/sw.cab#version=7,0,2,0 width=$1 height=$2><param name=src value=$3><embed src=$3 pluginspage=http://www.macromedia.com/shockwave/download/ width=$1 height=$2></embed></object>");

				my=new Regex(@"\[QT=*([0-9]*),*([0-9]*)\](.[^\[]*)\[\/QT]",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<embed src=$3 width=$1 height=$2 autoplay=true loop=false controller=true playeveryframe=false cache=false scale=TOFIT bgcolor=#000000 kioskmode=false targetcache=false pluginspage=http://www.apple.com/quicktime/>");

				my=new Regex(@"\[MP=*([0-9]*),*([0-9]*)\](.[^\[]*)\[\/MP]",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<object align=middle classid=CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95 class=OBJECT id=MediaPlayer width=$1 height=$2 ><param name=ShowStatusBar value=-1><param name=Filename value=$3><embed type=application/x-oleobject codebase=http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701 flename=mp src=$3  width=$1 height=$2></embed></object>");

				my=new Regex(@"\[RM=*([0-9]*),*([0-9]*)\](.[^\[]*)\[\/RM]",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<OBJECT classid=clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA class=OBJECT id=RAOCX width=$1 height=$2><PARAM NAME=SRC VALUE=$3><PARAM NAME=CONSOLE VALUE=Clip1><PARAM NAME=CONTROLS VALUE=imagewindow><PARAM NAME=AUTOSTART VALUE=true></OBJECT><br/><OBJECT classid=CLSID:CFCDAA03-8BE4-11CF-B84B-0020AFBBCCFA height=32 id=video2 width=$1><PARAM NAME=SRC VALUE=$3><PARAM NAME=AUTOSTART VALUE=-1><PARAM NAME=CONTROLS VALUE=controlpanel><PARAM NAME=CONSOLE VALUE=Clip1></OBJECT>");

				my=new Regex(@"(\[FLASH\])(.[^\[]*)(\[\/FLASH\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<OBJECT codeBase=http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=4,0,2,0 classid=clsid:D27CDB6E-AE6D-11cf-96B8-444553540000 width=500 height=400><PARAM NAME=movie VALUE=""$2""><PARAM NAME=quality VALUE=high><embed src=""$2"" quality=high pluginspage='http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash' type='application/x-shockwave-flash' width=500 height=400>$2</embed></OBJECT>");

				my=new Regex(@"(\[ZIP\])(.[^\[]*)(\[\/ZIP\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<br/><IMG SRC=pic/zip.gif border=0> <a href=""$2"">点击下载该文件</a>");

				my=new Regex(@"(\[RAR\])(.[^\[]*)(\[\/RAR\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<br/><IMG SRC=pic/rar.gif border=0> <a href=""$2"">点击下载该文件</a>");

				my=new Regex(@"(\[UPLOAD=(.[^\[]*)\])(.[^\[]*)(\[\/UPLOAD\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<br/><IMG SRC=""pic/$2.gif"" border=0>此主题相关图片如下：<br/><A HREF=""$3"" TARGET=_blank><IMG SRC=""$3"" border=0 alt=按此在新窗口浏览图片 onload=""javascript:if(this.width>screen.width-333)this.width=screen.width-333""></A>");

				my= new Regex(@"(\[URL\])(http:\/\/.[^\[]*)(\[\/URL\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<A HREF=""$2"" TARGET=_blank>$2</A>");

				my= new Regex(@"(\[ATT\])(http:\/\/.[^\[]*)(\[\/ATT\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"上传文件:<A HREF=""$2"" TARGET=_blank>$2</A>");

				my=new Regex(@"(\[URL\])(.[^\[]*)(\[\/URL\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<A HREF=""http://$2"" TARGET=_blank>$2</A>");

				my=new Regex(@"(\[URL=(http:\/\/.[^\[]*)\])(.[^\[]*)(\[\/URL\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<A HREF=""$2"" TARGET=_blank>$3</A>");

				my=new Regex(@"(\[URL=(.[^\[]*)\])(.[^\[]*)(\[\/URL\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<A HREF=""http://$2"" TARGET=_blank>$3</A>");

				my=new Regex(@"(\[EMAIL\])(\S+\@.[^\[]*)(\[\/EMAIL\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<A HREF=""mailto:$2"">$2</A>");

				my=new Regex(@"^(HTTP://[A-Za-z0-9\./=\?%\-&_~`@':+!]+)",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<a target=_blank href=$1>$1</a>");

				my=new Regex(@"(HTTP://[A-Za-z0-9\./=\?%\-&_~`@':+!]+)$",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<a target=_blank href=$1>$1</a>");

				my=new Regex(@"[^>=""](HTTP://[A-Za-z0-9\./=\?%\-&_~`@':+!]+)",RegexOptions.IgnoreCase);
				str = my.Replace(str,@"<a target=_blank href=$1>$1</a>");

				my=new Regex(@"^(FTP://[A-Za-z0-9\./=\?%\-&_~`@':+!]+)",RegexOptions.IgnoreCase);	
				str = my.Replace(str,@"<a target=_blank href=$1>$1</a>");

				my= new Regex(@"(FTP://[A-Za-z0-9\./=\?%\-&_~`@':+!]+)$",RegexOptions.IgnoreCase);
				str = my.Replace(str,@"<a target=_blank href=$1>$1</a>");

				my=new Regex(@"[^>=""](FTP://[A-Za-z0-9\.\/=\?%\-&_~`@':+!]+)",RegexOptions.IgnoreCase);
				str = my.Replace(str,@"<a target=_blank href=$1>$1</a>");

				my= new Regex(@"^(RTSP://[A-Za-z0-9\./=\?%\-&_~`@':+!]+)",RegexOptions.IgnoreCase);
				str = my.Replace(str,@"<a target=_blank href=$1>$1</a>");

				my= new Regex(@"(RTSP://[A-Za-z0-9\./=\?%\-&_~`@':+!]+)$",RegexOptions.IgnoreCase);
				str = my.Replace(str,@"<a target=_blank href=$1>$1</a>");

				my=new Regex(@"[^>=""](RTSP://[A-Za-z0-9\.\/=\?%\-&_~`@':+!]+)",RegexOptions.IgnoreCase);
				str = my.Replace(str,@"<a target=_blank href=$1>$1</a>");

				my=new Regex(@"^(MMS://[A-Za-z0-9\./=\?%\-&_~`@':+!]+)",RegexOptions.IgnoreCase);
				str = my.Replace(str,@"<a target=_blank href=$1>$1</a>");

				my= new Regex(@"(MMS://[A-Za-z0-9\./=\?%\-&_~`@':+!]+)$",RegexOptions.IgnoreCase);
				str = my.Replace(str,@"<a target=_blank href=$1>$1</a>");

				my=new Regex(@"[^>=""](MMS://[A-Za-z0-9\.\/=\?%\-&_~`@':+!]+)",RegexOptions.IgnoreCase);
				str = my.Replace(str,@"<a target=_blank href=$1>$1</a>");

				my=new Regex(@"(\[HTML\])(.[^\[]*)(\[\/HTML\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<table width='100%' border='0' cellspacing='0' cellpadding='6' bgcolor=''><td><b>以下内容为程序代码:</b><br/>$2</td></table>");

				my=new Regex(@"(\[CODE\])(.[^\[]*)(\[\/CODE\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<table width='100%' border='0' cellspacing='0' cellpadding='6' bgcolor=''><td><b>以下内容为程序代码:</b><br/>$2</td></table>");

				my=new Regex(@"(\[COLOR=(.[^\[]*)\])(.[^\[]*)(\[\/COLOR\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<font COLOR=$2>$3</font>");

				my=new Regex(@"(\[FACE=(.[^\[]*)\])(.[^\[]*)(\[\/FACE\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<font FACE=$2>$3</font>");

				my=new Regex(@"(\[ALIGN=(.[^\[]*)\])(.*)(\[\/ALIGN\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<div ALIGN=$2>$3</div>");

				my=new Regex(@"(\[QUOTE\])(.*)(\[\/QUOTE\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<table cellpadding=0 cellspacing=0 border=0 WIDTH=94% bgcolor=#66CCCC align=center><tr><td><table width=100% cellpadding=5 cellspacing=1 border=1><TR><TD BGCOLOR=''>$2</table></table><br/>");

				my=new Regex(@"(\[MOVE\])(.*)(\[\/MOVE\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<MARQUEE scrollamount=3>$2</marquee>");

				my=new Regex(@"\[GLOW=*([0-9]*),*(#*[a-z0-9]*),*([0-9]*)\](.[^\[]*)\[\/GLOW]",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<table width=$1 style=""filter:glow(color=$2, strength=$3)"">$4</table>");

				my=new Regex(@"\[SHADOW=*([0-9]*),*(#*[a-z0-9]*),*([0-9]*)\](.[^\[]*)\[\/SHADOW]",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<table width=$1 style=""filter:shadow(color=$2, strength=$3)"">$4</table>");

				my=new Regex(@"(\[I\])(.[^\[]*)(\[\/I\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<i>$2</i>");

				my=new Regex(@"(\[U\])(.[^\[]*)(\[\/U\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<u>$2</u>");

				my=new Regex(@"(\[B\])(.[^\[]*)(\[\/B\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<b>$2</b>");

				my=new Regex(@"(\[FLY\])(.[^\[]*)(\[\/FLY\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<marquee>$2</marquee>");

				my=new Regex(@"(\[SIZE=1\])(.[^\[]*)(\[\/SIZE\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<font size=1>$2</font>");

				my=new Regex(@"(\[SIZE=2\])(.[^\[]*)(\[\/SIZE\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<font size=2>$2</font>");

				my=new Regex(@"(\[SIZE=3\])(.[^\[]*)(\[\/SIZE\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<font size=3>$2</font>");

				my=new Regex(@"(\[SIZE=4\])(.[^\[]*)(\[\/SIZE\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<font size=4>$2</font>");

				my=new Regex(@"(\[CENTER\])(.[^\[]*)(\[\/CENTER\])",RegexOptions.IgnoreCase);
				str=my.Replace(str,@"<center>$2</center>");

			}
			return(str);
			
		}
	}
}
