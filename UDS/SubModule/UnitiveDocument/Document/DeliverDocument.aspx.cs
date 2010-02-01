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
using System.IO;

using UDS.Components;

namespace UDS.SubModule.UnitiveDocument.Document
{
	/// <summary>
	/// DeliverDocument ��ժҪ˵����
	/// </summary>
	public class DeliverDocument : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnUpload;
		protected System.Web.UI.WebControls.Button btnRemove;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.HtmlControls.HtmlTextArea txtContent;
		protected System.Web.UI.HtmlControls.HtmlInputText txtAuthor;
		protected System.Web.UI.HtmlControls.HtmlInputText txtFrom;
		protected System.Web.UI.HtmlControls.HtmlInputText txtTitle;
		protected static string Username;
		public string ClassID;
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected System.Web.UI.WebControls.ListBox listUpDoc;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		public  ArrayList listattfile= new ArrayList();
			
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if(!Page.IsPostBack)
			{
				Session["listattfile"]=listattfile;
			}

			ClassID	 = (Request.QueryString["ClassID"]!=null)?Request.QueryString["ClassID"].ToString():"";
			HttpCookie UserCookie = Request.Cookies["Username"];
			Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
			
		}

		#region �����post����
		/// <summary>
		/// �����post����
		/// </summary>
		private DocBody ProcessFormPost()
		{	
			ProjectClass pjt  = new ProjectClass ();
			int cstRightToApproveDocument = 2;
			//����֤
			if(Request.IsAuthenticated)
			{				
			
				
				// ��������ݲ���
				DocBody  docbody			= new DocBody();
				docbody.DocTitle			= this.txtTitle.Value;
				docbody.DocContent			= this.txtContent.Value;
				docbody.DocAddedBy			= Username;
				docbody.DocClassID			= Int32.Parse(ClassID);
				docbody.DocAddedDate        = DateTime.Now.ToString();
				docbody.DocApprover			= (pjt.GetAccessPermission(Int32.Parse(ClassID),Username,cstRightToApproveDocument))?Username:"";
				docbody.DocApproveDate		= (pjt.GetAccessPermission(Int32.Parse(ClassID),Username,cstRightToApproveDocument))?DateTime.Now.ToString():"";
				docbody.DocApproved         = (docbody.DocApprover =="")?0:1;
				docbody.DocAttribute        = 0;
				docbody.DocType				= 0;
				return docbody;
			}
			else
			{
				return null;
			}
		}
		#endregion

		#region �������ϴ����������ظ�������
		/// <summary>
		/// �����ϴ�����,������������ʽ���
		/// </summary>
		private ArrayList AttUpload()
		{	
			HtmlForm FrmCompose   = (HtmlForm)this.Page.FindControl("DeliverDocument");
			Random TempNameInt    = new Random(); 
			string NewDocDirName  = TempNameInt.Next(100000000).ToString();
			ArrayList listattfile = (ArrayList)Session["listattfile"];
						
			// ��Ÿ������ύ��Ŀ¼�У��������Ŀ¼��
			
			string FileName       = "";
			try
			{ 
				if(Directory.Exists(Server.MapPath(".")+"\\AttachFiles\\tmp"))
				{
					Directory.CreateDirectory(Server.MapPath(".")+"\\AttachFiles\\tmp\\"+NewDocDirName+Username);
					for (int i=0;i<FrmCompose.Controls.Count;i++)
					{	
						if(FrmCompose.Controls [i].GetType().ToString()=="System.Web.UI.HtmlControls.HtmlInputFile")
						{
							
							HtmlInputFile hif = ((HtmlInputFile)(FrmCompose.Controls[i]));
							if(hif.PostedFile.FileName.Trim()!="")
							{	
								FileName = System.IO .Path.GetFileName(hif.PostedFile.FileName);	
								UDS.Components.DocAttachFile att = new UDS.Components.DocAttachFile();
								// ��ʼ��
								att.FileAttribute  = 0;
								att.FileSize       = hif.PostedFile.ContentLength;
								att.FileName	   = FileName;
								att.FileAuthor     = Username;
								att.FileCatlog     = "�ĵ�";
								att.FileVisualPath = "AttachFiles\\tmp\\"+NewDocDirName+Username+"\\"+FileName;
								hif.PostedFile.SaveAs(Server.MapPath(".")+"\\AttachFiles\\tmp\\"+NewDocDirName+Username+"\\"+FileName);
								listattfile.Add(att);	
								
							}
							hif=null;
						}
					}
						
				}
				else
				{   
					Directory.CreateDirectory(Server.MapPath(".")+"\\AttachFiles\\tmp");
					AttUpload();
				}
			
				
			}
			catch(Exception ioex)
			{	
				UDS.Components.Error.Log(ioex.ToString());
				Server.Transfer("../../Error.aspx");
			}

			Session["listattfile"] = listattfile;
			return listattfile;
            			
		}
		#endregion

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN���õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		private void btnUpload_Click(object sender, System.EventArgs e)
		{
			AttUpload();
			this.listUpDoc.Items.Clear();
			int count = 0;
			ArrayList listattfile = (ArrayList)Session["listattfile"];
			foreach(UDS.Components.DocAttachFile att in listattfile)
			{
				count++;
				this.listUpDoc.Items.Add(new ListItem(att.FileName.ToString(),count.ToString()));
			}
		} 

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			ArrayList listattfile = (ArrayList)Session["listattfile"];
			for(int i=listUpDoc.Items.Count-1;i>=0;i--)
			{
				if(this.listUpDoc.Items[i].Selected)
				{
					this.listUpDoc.Items.RemoveAt(i);
					listattfile.RemoveAt (i);
				}
			}

			Session["listattfile"] = listattfile;
		}

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			string DocID = "";
			DocBody docbody = ProcessFormPost();
			DocumentClass doc = new DocumentClass();
			// ����ĵ�,������ID
			DocID = doc.AddDocBody(docbody);
			ArrayList listattfile = (ArrayList)Session["listattfile"];
			foreach(UDS.Components.DocAttachFile att in listattfile)
			{
				try
				{
					if(!Directory.Exists(Server.MapPath(".")+"\\AttachFiles\\"+Username))
						Directory.CreateDirectory(Server.MapPath(".")+"\\AttachFiles\\"+Username);
				
				//Directory.Move(att.FileVisualPath.ToString().Replace(att.FileName,""),Server.MapPath(".")+"\\AttachFiles\\"+Username+"\\");
					Random TempNameInt    = new Random(); 
					string NewDocDirName  = TempNameInt.Next(100000000).ToString();
					Directory.CreateDirectory(Server.MapPath(".")+"\\AttachFiles\\"+Username+"\\"+NewDocDirName);	
					File.Move(Server.MapPath(".")+"\\"+att.FileVisualPath ,Server.MapPath(".")+"\\AttachFiles\\"+Username+"\\"+NewDocDirName+"\\"+att.FileName);
					Directory.Delete(Server.MapPath(".")+"\\"+att.FileVisualPath.ToString().Replace(att.FileName,""),true);
					att.FileVisualPath    = "\\AttachFiles\\"+Username+"\\"+NewDocDirName+"\\"+att.FileName;
					att.FileAddedDate     = DateTime.Now.ToString();
					// �������ݿ⴦��
					doc.AddAttach(att,Int32.Parse(DocID));
					
					
				
				}
				catch(Exception ioex)
				{
					UDS.Components.Error.Log(ioex.ToString());
					Server.Transfer("../../Error.aspx");
				}
			}
			Response.Write("<script language=javascript>alert('�ĵ��ύ�ɹ�!');self.location='../Switch.aspx?Action=1&ClassID="+ClassID+"';</script>");
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../Switch.aspx?Action=1&ClassID="+ClassID);
		}

		
	}
}
