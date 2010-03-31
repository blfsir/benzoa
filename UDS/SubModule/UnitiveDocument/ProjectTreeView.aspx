<%@ Register TagPrefix="uc1" TagName="ControlProjectTreeView" Src="../../Inc/ControlProjectTreeView.ascx" %>

<%@ Page Language="c#" CodeBehind="ProjectTreeView.aspx.cs" AutoEventWireup="false"
    Inherits="UDS.TreeView" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>文档一体化系统</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR" />
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <link href="../../css/basiclayout.css" rel="Stylesheet" />
    <style>
        A.linkFooter:link
        {
            font-weight: normal;
            font-size: 9px;
            color: #006699;
            font-family: Arial, Helvetica, sans-serif;
            text-decoration: none;
        }
        A.linkMenu:link
        {
            font-weight: normal;
            font-size: 9pt;
            color: #006699;
            font-family: Arial, Helvetica, sans-serif;
            text-decoration: none;
        }
        A.linkMenu:visited
        {
            font-weight: normal;
            font-size: 9pt;
            color: #006699;
            font-family: Arial, Helvetica, sans-serif;
            text-decoration: none;
        }
        A.linkMenu:active
        {
            font-weight: normal;
            font-size: 9pt;
            color: #ff3300;
            text-decoration: underline;
        }
        A.linkMenu:hover
        {
            font-weight: normal;
            font-size: 9pt;
            color: #ff3300;
            text-decoration: none;
        }
        BODY
        {
            scrollbar-face-color: #024289;
            scrollbar-highlight-color: #024289;
            scrollbar-shadow-color: #024289;
            scrollbar-3dlight-color: #e8f4ff;
            scrollbar-arrow-color: #949494;
            scrollbar-track-color: #0051a5;
            scrollbar-darkshadow-color: black;
            scrollbar-base-color: #e8f4ff;
        }
        .borderMenuLayer
        {
            border-left-color: #c9c9c9;
            border-bottom-color: #c9c9c9;
            border-top-color: #c9c9c9;
            border-right-color: #c9c9c9;
        }
        .borderMenuLayerOver
        {
            font-size: 9pt;
            border-left-color: #949494;
            border-bottom-color: #949494;
            border-top-color: #949494;
            border-right-color: #949494;
        }
        .textWhite
        {
            font-weight: normal;
            font-size: 9pt;
            color: #999999;
            line-height: 22px;
            font-family: "宋体";
        }
        .top
        {
            font-weight: normal;
            font-size: 9pt;
            color: #000000;
            font-family: "Arial" , "Helvetica" , "sans-serif";
            text-decoration: none;
        }
        
        .Menu img  
        {  
            height:20px;  
            width:20px;  
        }          
    </style>

    <script language="javascript"> 
		window.onerror=function(){return true;} 
    </script>

</head>
<body style="background-position: right 50%; background-attachment: fixed; background-repeat: no-repeat"
    leftmargin="0" background="../../Images/lefttreebg.gif" topmargin="0" bgcolor="#e8f4ff"
    onload="SetStatus()">
    <form id="Projecttreeview" method="post" runat="server">
    <table height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td valign="center" height="30" bgcolor="#e8f4ff">
                <font face="宋体">
                    <table id="Table1" height="30" cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td >
                                &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="../../DataImages/tag13.png"  width="20" height="20" >
                                </asp:Image> &nbsp;<a style="text-decoration: none" href="NewDesktop.aspx"
                                    target="MainFrame">桌面(<%=UserName%>)</a> 
                            </td>
                            <td width="1">
                            </td>
                        </tr>
                    </table>
                </font>
            </td>
        </tr>
        <tr valign="top" bgcolor="#e8f4ff">
            <td  bgcolor="#e8f4ff">
                <uc1:ControlProjectTreeView ID="ControlProjectTreeView1" runat="server"></uc1:ControlProjectTreeView>
            </td>
        </tr>
    </table>
    </form>

    <script language="javascript">
		function SetStatus()
		{
			try{				
				myTreeView = document.all.ControlProjectTreeView1_TreeView1;
				myTreeView.setAttribute("Width","100%");
				myTreeView.setAttribute("Height","100%");
				
				var urlstr=location.href.split("?")[1];
				if (urlstr!=null)
					{
						urlstr=urlstr.split("classID=")[1];
						var classID=urlstr.split("&")[0];//取得classID值
						var mNodeArray=new Array();
						mNodeArray=myTreeView.getChildren();
						CheckAll(mNodeArray,classID);
						mNodeArray=null;
					}
				}
			catch(e){alert('error occur!'+e);}
		}
		
		function ExpandAllParentNode(node)
		{
						
				if(node!=null){
					node.setAttribute("Expanded","True");
					ExpandAllParentNode(node.getParent());
				}
		}
		
		
		function CheckAll(arr,classID)
		{
			var i;
			for(i=0;i<arr.length;i++)
			{
					var mNode=arr[i];
					var currNodeID	= mNode.getAttribute("ID");
					if(currNodeID==classID)
					{
						ExpandAllParentNode(mNode);
						break;
					}
					if((mNode.getChildren().lengh)!=0)
					CheckAll(mNode.getChildren(),classID);//递归遍历节点
			}
	    }

    </script>

</body>
</html>
