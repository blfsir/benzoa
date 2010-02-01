using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using UDS.Components;


namespace UDS.SubModule.UnitiveDocument.Mail.External
{
	/// <summary>
	/// PopSetup 的摘要说明。
	/// </summary>
	public class PopSetup : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtTimeOut1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator6;
		protected System.Web.UI.WebControls.TextBox txtPort1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator9;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator4;
		protected System.Web.UI.WebControls.TextBox txtPort2;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator8;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator5;
		protected System.Web.UI.WebControls.TextBox txtPort3;
		protected System.Web.UI.WebControls.TextBox txtTimeOut2;
		protected System.Web.UI.WebControls.TextBox txtTimeOut3;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnTest1;
		protected System.Web.UI.WebControls.Button btnTest2;
		protected System.Web.UI.WebControls.Button btnTest3;
		protected System.Web.UI.WebControls.TextBox txtTitle1;
		protected System.Web.UI.WebControls.TextBox txtPopSvrName1;
		protected System.Web.UI.WebControls.TextBox txtPopUserName1;
		protected System.Web.UI.WebControls.TextBox txtPopPwd1;
		protected System.Web.UI.WebControls.TextBox txtTitle2;
		protected System.Web.UI.WebControls.TextBox txtEmail2;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		protected System.Web.UI.WebControls.TextBox txtEmail1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.TextBox txtPopSvrName2;
		protected System.Web.UI.WebControls.TextBox txtPopUserName2;
		protected System.Web.UI.WebControls.TextBox txtPopPwd2;
		protected System.Web.UI.WebControls.TextBox txtTitle3;
		protected System.Web.UI.WebControls.TextBox txtEmail3;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator3;
		protected System.Web.UI.WebControls.TextBox txtPopSvrName3;
		protected System.Web.UI.WebControls.TextBox txtPopUserName3;
		protected System.Web.UI.WebControls.TextBox txtPopPwd3;
		protected System.Web.UI.WebControls.CheckBox chkDelSvrMsg1;
		protected System.Web.UI.WebControls.CheckBox chkDownNew1;
		protected System.Web.UI.WebControls.CheckBox chkDelSvrMsg2;
		protected System.Web.UI.WebControls.CheckBox chkDownNew2;
		protected System.Web.UI.WebControls.CheckBox chkDelSvrMsg3;
		protected System.Web.UI.WebControls.CheckBox chkDownNew3;
		protected System.Web.UI.WebControls.Label lblResultRep1;
		protected System.Web.UI.WebControls.Label lblResultRep2;
		protected System.Web.UI.WebControls.Label lblResultRep3;
		protected System.Web.UI.WebControls.Label lblPwdShow1;
		protected System.Web.UI.WebControls.Label lblPwdShow2;
		protected System.Web.UI.WebControls.Label lblPwdShow3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden lblPwd1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden lblPwd2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden lblPwd3;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator7;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				BindData();
			}
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
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
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
			this.btnTest2.Click += new System.EventHandler(this.btnTest2_Click);
			this.btnTest3.Click += new System.EventHandler(this.btnTest3_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindData()
		{
			MailClass mail = new MailClass();
			string Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
			SqlDataReader dataReader = null;
            try
            {
                dataReader = mail.ExtGetSetting(Username, 1);
                if (dataReader.Read())
                {
                    this.txtTitle1.Text = dataReader["Title"].ToString();
                    this.txtEmail1.Text = dataReader["Email"].ToString();
                    this.txtPopSvrName1.Text = dataReader["PopServer"].ToString();
                    this.txtPopUserName1.Text = dataReader["PopUsername"].ToString();
                    this.lblPwdShow1.Visible = true;
                    this.lblPwd1.Value = dataReader["PopPassword"].ToString();
                    this.txtTimeOut1.Text = dataReader["TimeOut"].ToString();
                    this.txtPort1.Text = dataReader["PopPort"].ToString();
                    this.chkDelSvrMsg1.Checked = dataReader["IsDelAfterRead"].ToString() == "True" ? true : false;
                    this.chkDownNew1.Checked = dataReader["IsReceiveNew"].ToString() == "True" ? true : false;
                }
                dataReader.Close();
                dataReader = mail.ExtGetSetting(Username, 2);
                if (dataReader.Read())
                {
                    this.txtTitle2.Text = dataReader["Title"].ToString();
                    this.txtEmail2.Text = dataReader["Email"].ToString();
                    this.txtPopSvrName2.Text = dataReader["PopServer"].ToString();
                    this.txtPopUserName2.Text = dataReader["PopUsername"].ToString();
                    this.lblPwdShow2.Visible = true;
                    this.lblPwd2.Value = dataReader["PopPassword"].ToString();
                    this.txtTimeOut2.Text = dataReader["TimeOut"].ToString();
                    this.txtPort2.Text = dataReader["PopPort"].ToString();
                    this.chkDelSvrMsg2.Checked = dataReader["IsDelAfterRead"].ToString() == "True" ? true : false;
                    this.chkDownNew2.Checked = dataReader["IsReceiveNew"].ToString() == "True" ? true : false;
                }
                dataReader = null;
                dataReader = mail.ExtGetSetting(Username, 3);
                if (dataReader.Read())
                {
                    this.txtTitle3.Text = dataReader["Title"].ToString();
                    this.txtEmail3.Text = dataReader["Email"].ToString();
                    this.txtPopSvrName3.Text = dataReader["PopServer"].ToString();
                    this.txtPopUserName3.Text = dataReader["PopUsername"].ToString();
                    this.lblPwdShow3.Visible = true;
                    this.lblPwd3.Value = dataReader["PopPassword"].ToString();
                    this.txtTimeOut3.Text = dataReader["TimeOut"].ToString();
                    this.txtPort3.Text = dataReader["PopPort"].ToString();
                    this.chkDelSvrMsg3.Checked = dataReader["IsDelAfterRead"].ToString() == "True" ? true : false;
                    this.chkDownNew3.Checked = dataReader["IsReceiveNew"].ToString() == "True" ? true : false;
                }
                dataReader = null;
            }
            catch (Exception ex)
            {
                dataReader.Close();
                UDS.Components.Error.Log(ex.ToString());
                Server.Transfer("../../../Error.aspx");
            }
            //finally
            //{
            //    dataReader.Close();
            //}
		}
		
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.SaveSetting();
			Response.Redirect("PopSetup.aspx");
		}

		private void SaveSetting()
		{
			MailClass mail		  = new MailClass();
			string Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
			try
			{
			
				if(mail.ExtClearSettings(Username))
				{
					mail.ExtSaveSetting(Username,this.txtTitle1.Text,this.txtEmail1 .Text,true,"","","","21",this.txtPopSvrName1.Text,this.txtPopUserName1.Text,(this.txtPopPwd1.Text!="")?this.txtPopPwd1.Text:this.lblPwd1.Value,Int32.Parse(this.txtPort1.Text),this.chkDelSvrMsg1.Checked,this.chkDownNew1.Checked,Int32.Parse(this.txtTimeOut1.Text),1);		
					mail.ExtSaveSetting(Username,this.txtTitle2.Text,this.txtEmail2 .Text,true,"","","","21",this.txtPopSvrName2.Text,this.txtPopUserName2.Text,(this.txtPopPwd2.Text!="")?this.txtPopPwd2.Text:this.lblPwd2.Value,Int32.Parse(this.txtPort2.Text),this.chkDelSvrMsg2.Checked,this.chkDownNew2.Checked,Int32.Parse(this.txtTimeOut2.Text),2);
					mail.ExtSaveSetting(Username,this.txtTitle3.Text,this.txtEmail3. Text,true,"","","","21",this.txtPopSvrName3.Text,this.txtPopUserName3.Text,(this.txtPopPwd3.Text!="")?this.txtPopPwd3.Text:this.lblPwd3.Value,Int32.Parse(this.txtPort3.Text),this.chkDelSvrMsg3.Checked,this.chkDownNew3.Checked,Int32.Parse(this.txtTimeOut3.Text),3);			
				}	
				else
				{
					Server.Transfer("../../../Error.aspx");
				}
			}
			catch(Exception ex)
			{
				UDS.Components.Error .Log(ex.ToString());
				Server.Transfer("../../../Error.aspx");
			}
			mail=null;
		}

		private void TestPopConn(string PopServer,string Uname,string Pwd,string Port,int OrderID)
		{
			int Count;
			jmail.Message Msg=new jmail.Message();
			jmail.POP3 jpop = new jmail.POP3();
			try
			{
			
				jpop.Connect(Uname,Pwd,PopServer,Int32.Parse(Port));
				
				Count = jpop.Count;
				switch (OrderID) 
				{
					case 1:
						this.lblResultRep1.Visible = true;
						this.lblResultRep1.Text = "测试成功,共有 "+Count.ToString()+" 封邮件";
						break;
					case 2:
						this.lblResultRep2 .Visible = true;
						this.lblResultRep2.Text = "测试成功,共有 "+Count.ToString()+" 封邮件";
						break;
					case 3:
						this.lblResultRep3 .Visible = true;
						this.lblResultRep3.Text = "测试成功,共有 "+Count.ToString()+" 封邮件";
						break;
					default:
						break;
				}
				
				jpop.Disconnect();
			
			}
			catch(Exception e)
			{
				switch (OrderID) 
				{
					case 1:
						this.lblResultRep1.Visible = true;
						this.lblResultRep1.Text = "未能连接到所指定的[接收邮件服务器],或输入了错误的[用户名]或[密码]！";
						break;
					case 2:
						this.lblResultRep2 .Visible = true;
						this.lblResultRep2.Text = "未能连接到所指定的[接收邮件服务器],或输入了错误的[用户名]或[密码]！";
						break;
					case 3:
						this.lblResultRep3 .Visible = true;
						this.lblResultRep3.Text = "未能连接到所指定的[接收邮件服务器],或输入了错误的[用户名]或[密码]！";
						break;
					default:
						break;
				}
				
			}
		}

		private void btnTest1_Click(object sender, System.EventArgs e)
		{
			this.SaveSetting();
			this.TestPopConn(this.txtPopSvrName1.Text,this.txtPopUserName1.Text,(this.txtPopPwd1.Text!="")?this.txtPopPwd1.Text:this.lblPwd1.Value,this.txtPort1.Text,1);	
		}

		private void btnTest2_Click(object sender, System.EventArgs e)
		{
			this.SaveSetting();
			this.TestPopConn(this.txtPopSvrName2.Text,this.txtPopUserName2.Text,(this.txtPopPwd2.Text!="")?this.txtPopPwd2.Text:this.lblPwd2.Value,this.txtPort2.Text,2);	
		}

		private void btnTest3_Click(object sender, System.EventArgs e)
		{
			this.SaveSetting();
			this.TestPopConn(this.txtPopSvrName3.Text,this.txtPopUserName3.Text,(this.txtPopPwd3.Text!="")?this.txtPopPwd3.Text:this.lblPwd3.Value,this.txtPort3.Text,3);			
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("SetupNavi.aspx");
		}
	}
}
