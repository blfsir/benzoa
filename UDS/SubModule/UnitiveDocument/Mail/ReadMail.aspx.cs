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
using System.Data.SqlClient;
using UDS.Components;

namespace UDS.SubModule.UnitiveDocument.Mail
{
	/// <summary>
	/// ReadMail 的摘要说明。
	/// </summary>
	public class ReadMail : System.Web.UI.Page
	{
		public static string MailID;
		protected HttpCookie UserCookie;
		protected static string CurrentPageIndex="",FolderType="";
		protected System.Web.UI.WebControls.Label lblSenderName;
		protected System.Web.UI.WebControls.Label lblReceiverStr;
		protected System.Web.UI.WebControls.Label lblCcToAddr;
		protected System.Web.UI.WebControls.Label lblBccToAddr;
		protected System.Web.UI.WebControls.Label lblProjectName;
		protected System.Web.UI.WebControls.Label lblSubject;
		protected System.Web.UI.WebControls.Label lblSendDate;
		protected System.Web.UI.WebControls.Label lblBody;
		protected System.Web.UI.WebControls.Label lblAttachFile;
		protected System.Web.UI.WebControls.Button btnDelete;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			UserCookie = Request.Cookies["Username"];
			CurrentPageIndex = Request.QueryString["CurrentPageIndex"]!=null?Request.QueryString["CurrentPageIndex"]:"";
			string Action = Request.QueryString["Action"]!=null?Request.QueryString["Action"]:"";
			string RMailID = Request.QueryString["MailID"]!=null?Request.QueryString["MailID"]:"";
			string ClassID =  Request.QueryString["ClassID"]!=null?Request.QueryString["ClassID"]:"";
			if (Request.QueryString["FolderType"] !=null)
			{
				FolderType = Request.QueryString["FolderType"].ToString();
			}
					
			if(Action=="3")
			{
				MailIncoming(RMailID,ClassID);
			}
			
			
			
			if(!Page.IsPostBack)
			{
				MailID = Request.QueryString["MailID"];
				ShowBodyDetail();
				this.btnDelete .Attributes["onclick"]= "javascript:return confirm('您确认要删除此邮件吗?');";
			}
		}

		#region 邮件归档
		public void MailIncoming(string MailID,string ClassID)
		{
		
			if(MailID!=""&&ClassID!="")
            {
                SqlDataReader dataReader = null;
                try
                {
                    String Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
                    MailClass mailclass = new MailClass();

                    ProjectClass pjt = new ProjectClass();
                    DocBody docbody = new DocBody();
                    DocumentClass doc = new DocumentClass();

                    dataReader = mailclass.GetMailCompleteInfoDbreader(MailID);
                    if (dataReader.Read())
                    {
                        int cstRightToApproveDocument = 2;

                        docbody.DocTitle = dataReader["MailSubject"].ToString();
                        docbody.DocContent = dataReader["MailBody"].ToString(); ;
                        docbody.DocAddedBy = dataReader["MailSender"].ToString(); ;
                        docbody.DocClassID = Int32.Parse(ClassID);
                        docbody.DocAddedDate = DateTime.Now.ToString();
                        docbody.DocApprover = (pjt.GetAccessPermission(Int32.Parse(ClassID), Username, cstRightToApproveDocument)) ? Username : "";
                        docbody.DocApproveDate = (pjt.GetAccessPermission(Int32.Parse(ClassID), Username, cstRightToApproveDocument)) ? DateTime.Now.ToString() : "";
                        docbody.DocApproved = (docbody.DocApprover == "") ? 0 : 1;
                        docbody.DocAttribute = 0;
                        docbody.DocType = 0;

                    }
                    dataReader.Close();
                    string DocID = doc.AddDocBody(docbody);

                    dataReader = mailclass.GetMailAttInfoDbreader(MailID);
                    while (dataReader.Read())
                    {
                        DocAttachFile docatt = new DocAttachFile();
                        docatt.FileAttribute = 0;
                        docatt.FileSize = Int32.Parse(dataReader["FileSize"].ToString());
                        docatt.FileName = dataReader["FileName"].ToString();
                        docatt.FileAuthor = Username;
                        docatt.FileCatlog = "文档";
                        docatt.FileVisualPath = "Mail" + dataReader["FileVisualPath"].ToString();
                        docatt.FileAddedDate = DateTime.Now.ToString();
                        docatt.DocID = Int32.Parse(DocID);
                        doc.AddAttach(docatt, Int32.Parse(DocID));
                    }


                   // dataReader = null;
                    if (dataReader != null)
                    {
                        dataReader.Close();
                    }
                    pjt = null;
                    docbody = null;

                    Response.Write("<script language=javascript>alert('归档成功!');</script>");
                }
                catch (Exception oe)
                {
                    UDS.Components.Error.Log(oe.ToString());
                    Server.Transfer("../Error.aspx");
                }
                finally
                {
                    if (dataReader != null)
                    {
                        dataReader.Close();
                    }
                }
			}

		}
		#endregion

		#region 使用DataReader显示邮件内容
		protected void ShowBodyDetail()
		{
			MailClass mailclass = new MailClass();
			SqlDataReader dataReader = null;
            try
            {
                try
                {
                    dataReader = mailclass.GetMailCompleteInfoDbreader(MailID);
                }
                catch
                {
                    Server.Transfer("../../Error.aspx");
                }

                if (dataReader.Read())
                {
                    this.lblSenderName.Text = dataReader["MailSender"].ToString();
                    this.lblCcToAddr.Text = UDS.Components.Staff.GetRealNameStrByUsernameStr(dataReader["MailCcToAddr"].ToString(), 0);
                    // 判断是否显示密抄人信息给本用户
                    string[] RecvAr = System.Text.RegularExpressions.Regex.Split(dataReader["MailBccToAddr"].ToString(), ",");
                    for (int i = 0; i < RecvAr.Length - 1; i++)
                    {	//判断密抄人中是否包含自己
                        if (RecvAr[i].ToString() == Server.UrlDecode(Request.Cookies["UserName"].Value))
                        {
                            //this.lblBccToAddr.Text = UserCookie.Value.ToString();
                            this.lblBccToAddr.Text = UDS.Components.Staff.GetRealNameByUsername(Server.UrlDecode(Request.Cookies["UserName"].Value));
                        }
                    }

                    this.lblSubject.Text = dataReader["MailSubject"].ToString();
                    this.lblBody.Text = dataReader["MailBody"].ToString();
                    this.lblSendDate.Text = dataReader["MailSendDate"].ToString();
                    this.lblReceiverStr.Text = UDS.Components.Staff.GetRealNameStrByUsernameStr(dataReader["MailReceiverStr"].ToString(), 0);
                    this.lblProjectName.Text = dataReader["classname"].ToString();
                }
                dataReader.Close();

                // 开始读取附件信息

                try
                {
                    dataReader = mailclass.GetMailAttInfoDbreader(MailID);
                }
                catch
                {
                    Server.Transfer("../../Error.aspx");
                }

                while (dataReader.Read())
                {
                    lblAttachFile.Text += "&nbsp;<a href='Download.aspx?destFileName=" + Server.UrlEncode(dataReader[2].ToString()) + "'>" + dataReader[0].ToString() + "(" + dataReader[1].ToString() + " Byte)</a><br>";
                }
                dataReader.Close();
            }
            finally
            {
                dataReader.Close();
            }
			mailclass = null;
		}	

		#endregion

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
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			MailClass mail		  = new MailClass();
			string sql			  = " MailID="+MailID.ToString();
					
			if(FolderType!="3"?mail.MailDelete(sql,0):mail.MailDelete(sql,1))
			{
				Response.Write("<script language=javascript>alert('邮件删除成功!');window.location='Index.aspx?FolderType="+FolderType+"';</script>");
			}
			else
			{
				Server.Transfer("../../Error.aspx");
			}
		
			mail=null;
		}
	}
}
