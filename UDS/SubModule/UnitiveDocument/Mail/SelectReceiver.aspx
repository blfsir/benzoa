<%@ Page language="c#" Codebehind="SelectReceiver.aspx.cs" AutoEventWireup="false" Inherits="MaiSystem.SelectReceiver" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>选择收件人 </title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../css/BasicLayout.css" type="text/css" rel="stylesheet">
		<base target="_self">
		<script language="javascript">
		function RemoveItem(ControlName)
	    { 
		Control = null;
		switch (ControlName){
		 case "btnReceSendToLeft" : 
		   Control=eval("document.SelectReceiver.listSendTo");  
		   break;
		 case "btnCcSendToLeft" : 
		   Control=eval("document.SelectReceiver.listCcTo");  
		   break;
		 case "btnBccSendToLeft" : 
		   Control=eval("document.SelectReceiver.listBccTo");  
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

	function AddItem(ControlName)
	{
		Control = null;
		switch (ControlName){
		 case "btnReceSendToRight" : 
		   Control=eval("document.SelectReceiver.listSendTo");  
		   break;
		 case "btnCcSendToRight" : 
		   Control=eval("document.SelectReceiver.listCcTo");  
		   break;
		 case "btnBccSendToRight" : 
		   Control=eval("document.SelectReceiver.listBccTo");  
		   break;
		} 
		
		var i=0;
		listAccount=eval("document.SelectReceiver.listAccount");
		var j=listAccount.length;
		for(i=0;i<j;i++)
		{
			if(listAccount.options[i].selected==true)
			{ 
				     
				Control.add(new Option(listAccount[i].text,listAccount.options[i].value));				         
			}
		}
	
	}

	function setStatusright()
	{
		document.SelectReceiver.btnReceSendToRight.disabled = false;
		document.SelectReceiver.btnCcSendToRight.disabled=false;
		document.SelectReceiver.btnBccSendToRight.disabled=false;
	}

	function setStatusleft()
	{
		document.SelectReceiver.btnReceSendToLeft .disabled =false;
		document.SelectReceiver.btnCcSendToLeft.disabled=false;
		document.SelectReceiver.btnBccSendToLeft.disabled=false;
	}
	
	function PopulateData()
	{
	   if (window.dialogArguments != null) 
		{
			var parwin = window.dialogArguments;	
					
			if(parwin.document.all.hdnTxtSendTo.value!="")
			{
			    Control=eval("document.SelectReceiver.listSendTo");  
				var SendToValueArray = parwin.document.all.hdnTxtSendTo.value.split(",");
				var SendToTxtArray = parwin.document.all.txtSendTo.value.split(",");
				for(i=0;i<SendToValueArray.length-1;i++)
				{
					Control.add(new Option(SendToTxtArray[i],SendToValueArray[i]));
				}
			}
			
			if(parwin.document.all.hdnTxtCcTo.value!="")
			{
			    Control=eval("document.SelectReceiver.listCcTo");  
				var CcToValueArray = parwin.document.all.hdnTxtCcTo.value.split(",");
				var CcToTxtArray = parwin.document.all.txtCcTo.value.split(",");
				for(i=0;i<CcToValueArray.length-1;i++)
				{
					Control.add(new Option(CcToTxtArray[i],CcToValueArray[i]));
				}
			}
			
			if(parwin.document.all.hdnTxtSendTo.value!="")
			{
			    Control=eval("document.SelectReceiver.listBccTo");  
				var BccToValueArray = parwin.document.all.hdnTxtBccTo.value.split(",");
				var BccToTxtArray = parwin.document.all.txtBccTo.value.split(",");
				for(i=0;i<BccToValueArray.length-1;i++)
				{
					Control.add(new Option(BccToTxtArray[i],BccToValueArray[i]));
				}
			}
			
			
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
		 var listCcToTxtStr = "";
		 var listCcToValueStr = "";
		 var listBccToTxtStr = "";
		 var listBccToValueStr = "";
		 var listSendToCompleteStr = "";
		 
		 listSendTo = eval("document.SelectReceiver.listSendTo"); 
		 listCcTo = eval("document.SelectReceiver.listCcTo"); 
		 listBccTo = eval("document.SelectReceiver.listBccTo"); 
		 
		 
		 for(i=0;i<listSendTo.length;i++)
		 {
			  listSendToTxtStr+=listSendTo.options[i].text+",";
			  listSendToValueStr+=listSendTo.options[i].value+","; 
		 }
	     parwin.document.all.Compose.txtSendTo.value = listSendToTxtStr;
	     parwin.document.all.Compose.hdnTxtSendTo.value = listSendToValueStr;
	     
		
		 for(i=0;i<listCcTo.length;i++)
		 {
			  listCcToTxtStr+=listCcTo.options[i].text+",";
			  listCcToValueStr+=listCcTo.options[i].value+","; 
		 }
		 parwin.document.all.Compose.txtCcTo.value = listCcToTxtStr;
	     parwin.document.all.Compose.hdnTxtCcTo.value = listCcToValueStr;
	     
		
		 for(i=0;i<listBccTo.length;i++)
		 {
			  listBccToTxtStr+=listBccTo.options[i].text+",";
			  listBccToValueStr+=listBccTo.options[i].value+","; 
		 }
		 parwin.document.all.Compose.txtBccTo.value = listBccToTxtStr;
	     parwin.document.all.Compose.hdnTxtBccTo.value = listBccToValueStr;
	     
		window.close();
	}

function SaveValue()
	{
		if (window.dialogArguments != null) 
		{
			var parwin = window.dialogArguments;	
		}
		
		 var listSendToTxtStr = "";
		 var listSendToValueStr = "";	
		 var listCcToTxtStr = "";
		 var listCcToValueStr = "";
		 var listBccToTxtStr = "";
		 var listBccToValueStr = "";
		 var listSendToCompleteStr = "";
		 
		 listSendTo = eval("document.SelectReceiver.listSendTo"); 
		 listCcTo = eval("document.SelectReceiver.listCcTo"); 
		 listBccTo = eval("document.SelectReceiver.listBccTo"); 
		 
		 
		 for(i=0;i<listSendTo.length;i++)
		 {
			  listSendToTxtStr+=listSendTo.options[i].text+",";
			  listSendToValueStr+=listSendTo.options[i].value+","; 
		 }
	     parwin.document.all.Compose.txtSendTo.value = listSendToTxtStr;
	     parwin.document.all.Compose.hdnTxtSendTo.value = listSendToValueStr;
	     
		
		 for(i=0;i<listCcTo.length;i++)
		 {
			  listCcToTxtStr+=listCcTo.options[i].text+",";
			  listCcToValueStr+=listCcTo.options[i].value+","; 
		 }
		 parwin.document.all.Compose.txtCcTo.value = listCcToTxtStr;
	     parwin.document.all.Compose.hdnTxtCcTo.value = listCcToValueStr;
	     
		
		 for(i=0;i<listBccTo.length;i++)
		 {
			  listBccToTxtStr+=listBccTo.options[i].text+",";
			  listBccToValueStr+=listBccTo.options[i].value+","; 
		 }
		 parwin.document.all.Compose.txtBccTo.value = listBccToTxtStr;
	     parwin.document.all.Compose.hdnTxtBccTo.value = listBccToValueStr;
	     
	
	}
			
		</script>
	</HEAD>
	<body onload="PopulateData()" MS_POSITIONING="GridLayout" background="../../../Images/mailuserbg.gif">
		<form id="SelectReceiver" method="post" runat="server">
			<SELECT id="listBccTo" style="Z-INDEX: 110; LEFT: 376px; WIDTH: 181px; POSITION: absolute; TOP: 293px; HEIGHT: 105px" multiple size="6" name="listBccTo">
			</SELECT><INPUT class="buttoncss" style="Z-INDEX: 109; LEFT: 258px; WIDTH: 81px; POSITION: absolute; TOP: 300px; HEIGHT: 24px" onclick="AddItem(this.name)" type="button" value=">>>>" name="btnBccSendToRight"><INPUT class="buttoncss" style="Z-INDEX: 108; LEFT: 257px; WIDTH: 81px; POSITION: absolute; TOP: 324px; HEIGHT: 24px" onclick="RemoveItem(this.name)" type="button" value="<<<<" name="btnBccSendToLeft"><SELECT id="listCcTo" style="Z-INDEX: 107; LEFT: 375px; WIDTH: 181px; POSITION: absolute; TOP: 168px; HEIGHT: 92px" multiple size="5" name="listCcTo"></SELECT><INPUT class="buttoncss" style="Z-INDEX: 106; LEFT: 256px; WIDTH: 81px; POSITION: absolute; TOP: 185px; HEIGHT: 24px" onclick="AddItem(this.name)" type="button" value=">>>>" name="btnCcSendToRight"><INPUT class="buttoncss" style="Z-INDEX: 105; LEFT: 256px; WIDTH: 81px; POSITION: absolute; TOP: 209px; HEIGHT: 24px" onclick="RemoveItem(this.name)" type="button" value="<<<<" name="btnCcSendToLeft"><SELECT id="listSendTo" style="Z-INDEX: 104; LEFT: 374px; WIDTH: 182px; POSITION: absolute; TOP: 43px; HEIGHT: 90px;" multiple size="5" name="listSendTo"></SELECT><INPUT class="buttoncss" style="Z-INDEX: 103; LEFT: 256px; WIDTH: 81px; POSITION: absolute; TOP: 59px; HEIGHT: 24px" onclick="AddItem(this.name)" type="button" value=">>>>" name="btnReceSendToRight"><INPUT class="buttoncss" style="Z-INDEX: 102; LEFT: 256px; WIDTH: 81px; POSITION: absolute; TOP: 83px; HEIGHT: 24px" onclick="RemoveItem(this.name)" type="button" value="<<<<" name="btnReceSendToLeft"><asp:dropdownlist id="listAccount" ondblclick="AddItem('btnReceSendToRight')" style="Z-INDEX: 101; LEFT: 73px; POSITION: absolute; TOP: 43px" runat="server" Width="148px" Height="356px" multiple onchange="setStatusright()"></asp:dropdownlist>
			<asp:label id="lblReceiver" style="Z-INDEX: 111; LEFT: 375px; POSITION: absolute; TOP: 18px" runat="server" Font-Size="X-Small">收件人</asp:label><asp:label id="lblCc" style="Z-INDEX: 112; LEFT: 376px; POSITION: absolute; TOP: 143px" runat="server" Font-Size="X-Small">抄送人</asp:label><asp:label id="lblBcc" style="Z-INDEX: 113; LEFT: 380px; POSITION: absolute; TOP: 272px" runat="server" Font-Size="X-Small">秘抄人</asp:label><asp:dropdownlist id="listAddressBook" style="Z-INDEX: 114; LEFT: 93px; POSITION: absolute; TOP: 430px" runat="server" Visible="False"></asp:dropdownlist><asp:label id="lblAddressBook" style="Z-INDEX: 115; LEFT: 41px; POSITION: absolute; TOP: 434px" runat="server" Font-Size="X-Small" Visible="False">地址薄</asp:label><input class="buttoncss" style="Z-INDEX: 116; LEFT: 221px; WIDTH: 61px; POSITION: absolute; TOP: 421px; HEIGHT: 24px" onclick="ReturnValue()" type="button" value="确定">
			<input class="buttoncss" style="Z-INDEX: 117; LEFT: 356px; WIDTH: 61px; POSITION: absolute; TOP: 421px; HEIGHT: 24px" onclick="window.close()" type="button" value="取消">
			<asp:DropDownList id="listDept" style="Z-INDEX: 118; LEFT: 76px; POSITION: absolute; TOP: 16px" runat="server" OnSelectedIndexChanged="DeptListChange" AutoPostBack="True"></asp:DropDownList></form>
	</body>
</HTML>
