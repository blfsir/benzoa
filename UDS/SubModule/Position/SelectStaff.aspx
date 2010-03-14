<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectStaff.aspx.cs" Inherits="UDS.SubModule.Position.SelectStaff" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>选择收信人 </title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/BasicLayout.css" type="text/css" rel="stylesheet">
		<base target="_self">
		<script language="javascript">
		
		function getQueryStringRegExp(name) 
        { 
            var reg = new RegExp("(^|\\?|&)"+ name +"=([^&]*)(\\s|&|$)", "i");   
            if (reg.test(location.href)) return unescape(RegExp.$2.replace(/\+/g, " ")); return ""; 
        }
        
        function GetUrlParms()    
        {
             var args=new Object();   
             var query=location.search.substring(1);//获取查询串   
             var pairs=query.split("&");//在逗号处断开   
             for(var    i=0;i<pairs.length;i++)   
             {   
                 var pos=pairs[i].indexOf('=');//查找name=value   
                    if(pos==-1)   continue;//如果没有找到就跳过   
                     var argname=pairs[i].substring(0,pos);//提取name   
                    var value=pairs[i].substring(pos+1);//提取value   
                    args[argname]=unescape(value);//存为属性   
            }
             return args;
        }
        
        var args = new Object();
        args = GetUrlParms();
       // 如果要查找参数key:
//       alert(location.href);
//       alert(args['txtName']); 
       var txtName=args['txtName'];
//        value = args[key] 
//        alert(
        
//        function $G(){ 
//                         var Url=top.window.location.href; 
//                         var u,g,StrBack=''; 
//                         if(arguments[arguments.length-1]=="#") 
//                         u=Url.split("#"); 
//                         else 
//                         u=Url.split("?"); 
//                         if (u.length==1) g=''; 
//                        else g=u[1]; 
//                        if(g!=''){ 
//                        gg=g.split("&"); 
//                        var MaxI=gg.length; 
//                        str = arguments[0]+"="; 
//                        for(i=0;i<MaxI;i++){ 
//                        if(gg[i].indexOf(str)==0) { 
//                        StrBack=gg[i].replace(str,""); 
//                        break; 
//                        } 
//                        } 
//                        } 
//                        return StrBack; 
//                    }

//alert(getQueryStringRegExp('txtName')); 
////var ip =$G('txtName');
//alert(location.href);
//alert(ip);
		function RemoveItem(ControlName)
	    { 
		Control = null;
		switch (ControlName){
		 case "btnReceSendToLeft" : 
		   Control=eval("document.SelectReceiver.listSendTo");  
		   break;
		 
		  } 
				
				var j=Control.length;
				if(j==0) return;
				for(j;j>0;j--)
				{
					if(Control.options[j-1].selected==true)
					{ 
 						Control.remove(j-1);
					}
				}
		   	
	}
	
    function RemoveItem()
	    { 
		    Control = null;
	 
		   Control=eval("document.SelectReceiver.listSendTo");  
		   
				
				var j=Control.length;
				if(j==0) return;
				for(j;j>0;j--)
				{
					 
 						Control.remove(j-1);
					 
				}
		   	
	}
	function AddItem(ControlName)
	{
		Control = null;
		switch (ControlName){
		 case "btnReceSendToRight" : 
		   Control=eval("document.SelectReceiver.listSendTo");  
		   break;
		 
		} 
		
		var i=0;
		listAccount=eval("document.SelectReceiver.listAccount");
		var j=listAccount.length;
		for(i=0;i<j;i++)
		{
			if(listAccount.options[i].selected==true)
			{ 
				   
				     RemoveItem()
				Control.add(new Option(listAccount[i].text,listAccount.options[i].value));				         
			}
		}
	
	}

	function setStatusright()
	{
		document.SelectReceiver.btnReceSendToRight.disabled = false; 
	}

	function setStatusleft()
	{
		document.SelectReceiver.btnReceSendToLeft .disabled =false;
	 
	}
	
	function PopulateData()
	{
	   if (window.dialogArguments != null) 
		{
			var parwin = window.dialogArguments;	
//			if(parwin.document.all.hdnTxtSendTo.value!="")
//			{
//			    Control=eval("document.SelectReceiver.listSendTo"); 
//			  	var SendToValueArray = parwin.document.all.hdnTxtSendTo.value.split(",");
//				var SendToTxtArray = parwin.document.all.txtSendTo.value.split(",");
//				for(i=0;i<SendToValueArray.length-1;i++)
//				{
//					Control.add(new Option(SendToTxtArray[i],SendToValueArray[i]));
//				}
			//}
//			
//			if(parwin.document.all.hdnTxtMobileSendTo.value!="")
//			{
//			    Control=eval("document.SelectReceiver.listMobileSendTo");  
//				var MobileSendToValueArray = parwin.document.all.hdnTxtMobileSendTo.value.split(",");
//				var MobileSendToTxtArray = parwin.document.all.txtMobileSendTo.value.split(",");
//				for(i=0;i<MobileSendToValueArray.length-1;i++)
//				{
//					Control.add(new Option(MobileSendToTxtArray[i],MobileSendToValueArray[i]));
//				}
//			}
			
			
			
		}
	}
	function ReturnValue()
	{
		if (window.dialogArguments != null) 
		{
			var parwin = window.dialogArguments;	
		}
		
		 var listSendToTxtStr = "";
		 var listSendToValueStr = "";	
	  var listSendToCompleteStr = "";
		 
		 listSendTo = eval("document.SelectReceiver.listSendTo"); 
		 		 
		 
		 for(i=0;i<listSendTo.length;i++)
		 {
			  listSendToTxtStr+=listSendTo.options[i].text ;
			  listSendToValueStr+=listSendTo.options[i].value ; 
		 }
		 if(txtName =="txtCurrentUser")
		 {
		     parwin.document.all.MsgSend.txtCurrentUser.value = listSendToTxtStr; 
	        setDdlValue('ddlCurrentUser',listSendToTxtStr);
		 }
		 if(txtName =="txtSendTo")
		 {
	         parwin.document.all.MsgSend.txtSendTo.value = listSendToTxtStr;
//	     parwin.document.all.MsgSend.ddlBuyUser.value = listSendToTxtStr;
	         setDdlValue('ddlBuyUser',listSendToTxtStr);
	    }
	    
	     if(txtName =="txtOriginalUser")
		 {
	         parwin.document.all.MsgSend.txtOriginalUser.value = listSendToTxtStr; 
	         setDdlValue('ddlOriginalUser',listSendToTxtStr);
	    }
	    if(txtName=="txtMoveAsset")
	    {
	         parwin.document.all.AssetMove.txtMoveAsset.value = listSendToTxtStr; 
	         setDdlValue('ddlMoveTo',listSendToTxtStr);
	    }
	    
		window.close();
	}
	
	function setDdlValue(dd,sel)
	{
	var parwin;
	if (window.dialogArguments != null) 
		{
			 parwin = window.dialogArguments;	
		}
		
		
	 var ddl =  parwin.document.getElementById(dd);
                for(i=0;i<ddl.length;i++)
                {
                    if(ddl.options[i].text == sel)
                    {
                        ddl.options[i].selected = true;
                        break;
                    }
                }
	}

	function SaveValue()
	{
		if (window.dialogArguments != null) 
		{
			var parwin = window.dialogArguments;	
		}
		
		 var listSendToTxtStr = "";
		 var listSendToValueStr = "";	
		  var listSendToCompleteStr = "";
		 
		 listSendTo = eval("document.SelectReceiver.listSendTo"); 
		 
		 
		 
		 for(i=0;i<listSendTo.length;i++)
		 {
			  listSendToTxtStr+=listSendTo.options[i].text ;
			  listSendToValueStr+=listSendTo.options[i].value ; 
		 }
	     parwin.document.all.MsgSend.txtSendTo.value = listSendToTxtStr;
	      
		
 
	}
			
		</script>
	</HEAD>
	<body onload="PopulateData()" MS_POSITIONING="GridLayout" background="../../../Images/mailuserbg.gif">
		<form id="SelectReceiver" method="post" runat="server">
			<SELECT id="listSendTo" style="Z-INDEX: 104; LEFT: 374px; WIDTH: 182px; POSITION: absolute; TOP: 43px; HEIGHT: 356px" multiple size="10" name="listSendTo"></SELECT><INPUT class="buttoncss" style="Z-INDEX: 103; LEFT: 256px; WIDTH: 81px; POSITION: absolute; TOP: 49px; HEIGHT: 24px" onclick="AddItem(this.name)" type="button" value=">>>>" name="btnReceSendToRight"><INPUT class="buttoncss" style="Z-INDEX: 102; LEFT: 256px; WIDTH: 81px; POSITION: absolute; TOP: 73px; HEIGHT: 24px" onclick="RemoveItem(this.name)" type="button" value="<<<<" name="btnReceSendToLeft"><asp:dropdownlist id="listAccount" ondblclick="AddItem('btnReceSendToRight')" style="Z-INDEX: 101; LEFT: 73px; POSITION: absolute; TOP: 43px" runat="server" Width="148px" Height="356px" multiple onchange="setStatusright()"></asp:dropdownlist>
			<asp:label id="lblReceiver" style="Z-INDEX: 111; LEFT: 375px; POSITION: absolute; TOP: 18px" runat="server" Font-Size="X-Small">选定人员</asp:label><input class="buttoncss" style="Z-INDEX: 116; LEFT: 221px; WIDTH: 61px; POSITION: absolute; TOP: 421px; HEIGHT: 24px" onclick="ReturnValue()" type="button" value="确定">
			<input class="buttoncss" style="Z-INDEX: 117; LEFT: 356px; WIDTH: 61px; POSITION: absolute; TOP: 421px; HEIGHT: 24px" onclick="window.close()" type="button" value="取消">
			<asp:DropDownList id="listDept" style="Z-INDEX: 118; LEFT: 76px; POSITION: absolute; TOP: 16px" runat="server" OnSelectedIndexChanged="DeptListChange" AutoPostBack="True"></asp:DropDownList>
			
			<asp:Label ID="Label1" runat="server" Text="姓名:" Style="z-index: 118; left: 226px; position: absolute;
        top: 16px"  ></asp:Label>
        <asp:TextBox ID="txtSearchName" runat="server" Style="z-index: 118; left: 266px; position: absolute;
        top: 16px; width: 66px; right: 916px;" ></asp:TextBox>
         <asp:Button ID="btnSearch" style="z-index: 118; position: absolute;left: 336px;
        top: 16px" runat="server" class="buttoncss" Text="查询" 
        onclick="btnSearch_Click"/>
			
			</form>
	</body>
</HTML>
