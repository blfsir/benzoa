<%@ Page Language="c#" CodeBehind="SelectReceiver.aspx.cs" AutoEventWireup="false"
    Inherits="MaiSystem.SelectReceiver" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>选择收件人 </title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../../css/BasicLayout.css" type="text/css" rel="stylesheet">
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

</head>
<body onload="PopulateData()" ms_positioning="GridLayout" background="../../../Images/mailuserbg.gif">
    <form id="SelectReceiver" method="post" runat="server">
    <select id="listBccTo" style="z-index: 110; left: 376px; width: 181px; position: absolute;
        top: 293px; height: 105px" multiple size="6" name="listBccTo">
    </select>
    <input class="buttoncss" style="z-index: 109; left: 258px; width: 81px; position: absolute;
        top: 300px; height: 24px" onclick="AddItem(this.name)" type="button" value=">>>>"
        name="btnBccSendToRight">
    <input class="buttoncss" style="z-index: 108; left: 257px; width: 81px; position: absolute;
        top: 324px; height: 24px" onclick="RemoveItem(this.name)" type="button" value="<<<<"
        name="btnBccSendToLeft">
    <select id="listCcTo" style="z-index: 107; left: 375px; width: 181px; position: absolute;
        top: 168px; height: 92px" multiple size="5" name="listCcTo">
    </select>
    <input class="buttoncss" style="z-index: 106; left: 256px; width: 81px; position: absolute;
        top: 185px; height: 24px" onclick="AddItem(this.name)" type="button" value=">>>>"
        name="btnCcSendToRight">
    <input class="buttoncss" style="z-index: 105; left: 256px; width: 81px; position: absolute;
        top: 209px; height: 24px" onclick="RemoveItem(this.name)" type="button" value="<<<<"
        name="btnCcSendToLeft">
    <select id="listSendTo" style="z-index: 104; left: 374px; width: 182px; position: absolute;
        top: 43px; height: 90px;" multiple size="5" name="listSendTo">
    </select>
    <input class="buttoncss" style="z-index: 103; left: 256px; width: 81px; position: absolute;
        top: 59px; height: 24px" onclick="AddItem(this.name)" type="button" value=">>>>"
        name="btnReceSendToRight">
    <input class="buttoncss" style="z-index: 102; left: 256px; width: 81px; position: absolute;
        top: 83px; height: 24px" onclick="RemoveItem(this.name)" type="button" value="<<<<"
        name="btnReceSendToLeft">
    <asp:DropDownList ID="listAccount" ondblclick="AddItem('btnReceSendToRight')" Style="z-index: 101;
        left: 73px; position: absolute; top: 43px" runat="server" Width="148px" Height="356px"
        multiple onchange="setStatusright()">
    </asp:DropDownList>
    <asp:Label ID="lblReceiver" Style="z-index: 111; left: 375px; position: absolute;
        top: 18px" runat="server" Font-Size="X-Small">收件人</asp:Label>
    <asp:Label ID="lblCc" Style="z-index: 112; left: 376px; position: absolute; top: 143px"
        runat="server" Font-Size="X-Small">抄送人</asp:Label>
    <asp:Label ID="lblBcc" Style="z-index: 113; left: 380px; position: absolute; top: 272px"
        runat="server" Font-Size="X-Small">秘抄人</asp:Label>
    <asp:DropDownList ID="listAddressBook" Style="z-index: 114; left: 93px; position: absolute;
        top: 430px" runat="server" Visible="False">
    </asp:DropDownList>
    <asp:Label ID="lblAddressBook" Style="z-index: 115; left: 41px; position: absolute;
        top: 434px" runat="server" Font-Size="X-Small" Visible="False">地址薄</asp:Label>
    <input class="buttoncss" style="z-index: 116; left: 221px; width: 61px; position: absolute;
        top: 421px; height: 24px" onclick="ReturnValue()" type="button" value="确定">
    <input class="buttoncss" style="z-index: 117; left: 356px; width: 61px; position: absolute;
        top: 421px; height: 24px" onclick="window.close()" type="button" value="取消">
    <asp:DropDownList ID="listDept" Style="z-index: 118; left: 76px; position: absolute;
        top: 16px" runat="server" OnSelectedIndexChanged="DeptListChange" AutoPostBack="True">
    </asp:DropDownList>
    <p>
    <asp:Label ID="Label1" runat="server" Text="姓名:" Style="z-index: 118; left: 226px; position: absolute;
        top: 16px"  ></asp:Label>
    </p>
    <asp:TextBox ID="txtSearchName" runat="server" Style="z-index: 118; left: 266px; position: absolute;
        top: 16px; width: 66px; right: 916px;" ></asp:TextBox>
    <%--
    <input class="buttoncss" style="z-index: 118; position: absolute;left: 336px;
        top: 16px"  type="button" value="查询" runat="server" >--%>
        <asp:Button ID="btnSearch" style="z-index: 118; position: absolute;left: 336px;
        top: 16px" runat="server" class="buttoncss" Text="查询" 
        onclick="btnSearch_Click"/>
    
    </form>
</body>
</html>
