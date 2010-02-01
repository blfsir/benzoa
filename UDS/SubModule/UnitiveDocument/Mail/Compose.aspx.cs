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
using System.Configuration;
using System.Data.SqlClient;
using UDS.Components;


namespace UDS.SubModule.UnitiveDocument.Mail
{
	/// <summary>
	/// Compose ��ժҪ˵����
	/// </summary>
	public class Compose : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblSendTo;
		protected System.Web.UI.WebControls.Label lblSubject;
		protected System.Web.UI.WebControls.TextBox txtSubject;
		protected System.Web.UI.WebControls.Label lblBody;
		protected System.Web.UI.WebControls.TextBox txtBody;
		protected System.Web.UI.WebControls.Label lblImportance;
		protected System.Web.UI.WebControls.DropDownList listImportance;
		protected System.Web.UI.WebControls.Button btnSendMail;
		protected System.Web.UI.WebControls.Label lblAttachFile;
		protected System.Web.UI.WebControls.Label lblCcTo;
		protected System.Web.UI.WebControls.Label lblBccTo;
		protected System.Web.UI.HtmlControls.HtmlInputFile filecontrol1;
		protected static string Username;
		public string ClassID;
		public static string MailID;
		public string Action;
		public string SendTo="",CcTo="",BccTo="",SendToRealName="",CcToRealName="",BccToRealName="";
		protected System.Web.UI.WebControls.CheckBoxList cblistAttribute;
		protected System.Web.UI.WebControls.Button btnUpload;
		protected System.Web.UI.WebControls.ListBox listUp;
		protected System.Web.UI.WebControls.Button btnRemove;
		protected System.Web.UI.HtmlControls.HtmlInputFile filecontrol2;
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected System.Web.UI.HtmlControls.HtmlInputFile File2;
		protected System.Web.UI.WebControls.CheckBox cbRemind;
		protected  ArrayList upattlist = new ArrayList();

		private void Page_Load(object sender, System.EventArgs e)
		{
			ClassID	 = (Request.QueryString["ClassID"]!=null)?Request.QueryString["ClassID"].ToString():"";
			MailID	 = (Request.QueryString["MailID"]!=null)?Request.QueryString["MailID"].ToString():"";
			HttpCookie UserCookie = Request.Cookies["Username"];
			Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
			if(!IsPostBack)
			{
				Session["upattlist"]=upattlist;
				//upattlist.Clear();
				
				// Action=1 �ظ� Action=2 ת�� Action=3 ָ���ռ��˵ļ���
				if (Request.QueryString["Action"]!=null)
				{	
					MailID  = (Request.QueryString["MailID"]==null)?"":Request.QueryString["MailID"].ToString();
					if(Request.QueryString["Action"]=="1")
					ReplySet();  // ���лظ��ʼ�����
					if(Request.QueryString["Action"]=="2")
					ForwardSet();  // ����ת���ʼ�����
					if(Request.QueryString["Action"]=="3")
					ReceiverSet();  // ���з��������� 

				}
				PopulateListView();
								
			}
		
		}


		#region �ظ��ʼ�����
		/// <summary>
		/// �ظ��ʼ�����
		/// </summary>
		private void ReplySet()
		{		
			// ��ȡԭ�ʼ�����
			MailClass mailclass = new MailClass();
			SqlDataReader dataReader = null; 
			try
			{
				dataReader = mailclass.GetMailCompleteInfoDbreader(MailID);
			}
			catch
			{
				Server.Transfer("../../Error.aspx");
			}
            try
            {
                if (dataReader.Read())
                {
                    string tmpStr = "<br/>" + dataReader[7].ToString();
                    tmpStr = tmpStr.Replace("<br/>", "\r\n>");
                    this.txtSubject.Text = "Re:" + dataReader[4].ToString();
                    SendToRealName = dataReader[1].ToString() + ",";
                    SendTo = dataReader[10].ToString() + ",";
                    this.txtBody.Text = SendToRealName + "���!\n\n\n\n\n\n\n";
                    this.txtBody.Text += "=======" + dataReader[3].ToString() + "����������д��:" + "=======\n\n";
                    this.txtBody.Text += tmpStr;

                }
            }
            finally
            {
                dataReader.Close();
                mailclass = null;
            }		
		}
		#endregion

		#region ת���ʼ�����
		/// <summary>
		/// ת���ʼ�����
		/// </summary>
		private void ForwardSet()
		{		
			// ��ȡԭ�ʼ�����
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
                    string tmpStr = "<br/>" + dataReader[7].ToString();
                    tmpStr = tmpStr.Replace("<br/>", "\r\n>");
                    this.txtSubject.Text = "Fw::" + dataReader[4].ToString();
                    this.txtBody.Text = ",���!\n\n\n\n\n\n\n";
                    this.txtBody.Text += "=======������ת���ʼ�=======\n";
                    this.txtBody.Text += "ԭ�ʼ�����������:" + dataReader[1].ToString() + "\n";
                    this.txtBody.Text += "ԭ�ʼ������˴���:" + dataReader[10].ToString() + "\n";
                    this.txtBody.Text += tmpStr;

                }
                dataReader.Close();



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
                    UDS.Components.MailAttachFile att = new MailAttachFile();
                    att.FileAttribute = 0;
                    att.FileSize = Int32.Parse(dataReader[1].ToString());
                    att.FileName = dataReader[0].ToString();
                    att.FileAuthor = Username;
                    att.FileCatlog = "�ʼ�";
                    att.FileVisualPath = dataReader[2].ToString();
                    upattlist.Add(att);
                }
                BindAttList();

            }
            finally
            {
                dataReader.Close();

            }
			mailclass = null;			
		}
		#endregion

		#region ����������
		/// <summary>
		/// ����������
		/// </summary>
		private void ReceiverSet()
		{	
			SendToRealName       = (Request.QueryString["Name"]==null)?"":Request.QueryString["Name"].ToString()+",";
			SendTo				 = (Request.QueryString["Username"]==null)?"":Request.QueryString["Username"].ToString()+",";
		}
		#endregion

		public string GetClassName()
		{
			if(ClassID=="0")
				return "��ѡ����Ŀ";
			else
				return UDS.Components .ProjectClass .GetProjectName(Int32.Parse(ClassID));

		}
		
		#region ��ʼ�������б��
		/// <summary>
		/// �������б���г�ʼ��
		/// </summary>
		private void PopulateListView() 
		{
			Class cls = new Class();			
			listImportance.Items.Clear();
			listImportance.Items.Add(new ListItem("һ��","1"));
			listImportance.Items.Add(new ListItem("��Ҫ","2"));
			listImportance.Items.Add(new ListItem("�ر���Ҫ","3"));
			
			cblistAttribute.Items.Add(new ListItem("��ͨ�ʼ�","1"));
			cblistAttribute.Items.Add(new ListItem("�ʼ��鵵","2"));
			//cblistAttribute.Items.Add(new ListItem("�᰸����","3"));
			cblistAttribute.Items[0].Selected=true;
			
			cls = null;
		}
		#endregion

		#region �����ʼ������ϴ����������ظ�������
		/// <summary>
		/// �����ϴ�����,������������ʽ���
		/// </summary>
		/// <param name="MailReceiverStr"> �û���½���ַ������ö��Ÿ��� </param>
		private ArrayList AttUpload(string MailReceiverStr)
		{	
			HtmlForm FrmCompose   = (HtmlForm)this.Page.FindControl("Compose");
			string[] RecvIdAr     = System.Text.RegularExpressions.Regex.Split(MailReceiverStr ,",");
			ArrayList listattfile = new ArrayList();
			// ��Ÿ�����������Ŀ¼�У��������Ŀ¼��
			Random TempNameInt    = new Random(); 
			string NewMailDirName = TempNameInt.Next(100000000).ToString();
			string FileName       = "";
			try
			{
				if(!Directory.Exists(Server.MapPath(".")+"\\AttachFiles\\"+Username))
					Directory.CreateDirectory(Server.MapPath(".")+"\\AttachFiles\\"+Username);
			
					Directory.CreateDirectory(Server.MapPath(".")+"\\AttachFiles\\"+Username+"\\"+NewMailDirName);
					for (int i=0;i<FrmCompose.Controls.Count;i++)
					{
						if(FrmCompose.Controls [i].GetType().ToString()=="System.Web.UI.HtmlControls.HtmlInputFile")
						{
							HtmlInputFile hif = ((HtmlInputFile)(FrmCompose.Controls[i]));
							if(hif.PostedFile.FileName.Trim()!="")
							{	
								FileName = System.IO .Path.GetFileName(hif.PostedFile.FileName);	
								UDS.Components.MailAttachFile att = new MailAttachFile();
								// ��ʼ��
								att.FileAttribute  = 0;
								att.FileSize       = hif.PostedFile.ContentLength;
								att.FileName	   = FileName;
								att.FileAuthor     = Username;
								att.FileCatlog     = "�ʼ�";
								att.FileVisualPath = "\\AttachFiles\\"+Username+"\\"+NewMailDirName+"\\"+FileName;
								hif.PostedFile.SaveAs(Server.MapPath(".")+"\\AttachFiles\\"+Username+"\\"+NewMailDirName+"\\"+FileName);
								listattfile.Add(att);	
							}
							hif=null;
						}
					}
				
			}
			catch(Exception ioex)
			{	
				UDS.Components.Error.Log(ioex.ToString());
				Server.Transfer("../../Error.aspx");
			}

			
			return listattfile;
            			
		}
		#endregion
	
		#region ������ռ�����ı����ݲ��� ����MailMainBody��
		/// <summary>
		/// ���Ͳ������������ʼ�����
		/// </summary>
		private MailMainBody ProcessFormPost()
		{	
			
			if(this.cblistAttribute.SelectedIndex.ToString()=="-1")
			{
				Response.Write("<script language=javascript>alert('��ѡ���ʼ�����!');history.go(-1);</script>");
				Response.End();
			}

			if(cblistAttribute.Items[1].Selected)
			{
				if(Request.Form["hdnProjectID"].ToString()=="0")
				{
					Response.Write("<script language=javascript>alert('��ѡ��鵵��Ŀ!');history.go(-1);</script>");
					Response.End();
				}
				
			}
			if(cblistAttribute.Items[0].Selected)
			{
			
				//���ǿ���֤
				if(Request.Form["hdnTxtSendTo"].ToString()=="")
				{
					Response.Write("<script language=javascript>alert('��ѡ���ռ���!');history.go(-1);</script>");
					Response.End();
				}
				
			}


			// ��������ݲ���
			MailMainBody mailbody		= new MailMainBody();
		//	string cID = "0";
			
			mailbody.MailFolderType		= 1; //�����ռ���
			mailbody.MailReceiverStr	= Request.Form["hdnTxtSendTo"].ToString();
			mailbody.MailSendDate		= DateTime.Now.ToString();
			mailbody.MailSendLevel		= 1;//default 1 Ԥ��
			mailbody.MailSender			= Username;
			mailbody.MailReceiver		= ""; 
			mailbody.MailSubject		= (txtSubject.Text=="")?"������":txtSubject.Text;
			mailbody.MailBody			= txtBody.Text.Replace("\r\n","<br/>");
			mailbody.MailCcToAddr		= Request.Form["hdnTxtCcTo"].ToString();
			mailbody.MailBccToAddr		= Request.Form["hdnTxtBccTo"].ToString();
			mailbody.MailReadFlag		= 0;
			mailbody.MailTypeFlag		= 1;
			mailbody.MailClassID        = Request.Form["hdnProjectID"].ToString()!=""?Int32.Parse(Request.Form["hdnProjectID"].ToString()):0;
			mailbody.MailImportance		= Int32.Parse(listImportance.SelectedItem.Value);
			
			//�����������
			if(this.cbRemind.Checked ==true)
			{
				SMS sm = new SMS();
				sm.SendMsg(Username,mailbody.MailReceiverStr+mailbody.MailCcToAddr+mailbody.MailBccToAddr,"����"+Username+"���յ���һ���µ��ʼ�",1,DateTime.Now,"",0,0);
				sm = null;
			}
			
			return mailbody;
		}
		#endregion

		#region �ĵ�����
		/// <summary>
		/// �ĵ������������ĵ�������������
		/// </summary>
		private void DocProcess(MailMainBody mailbody,ArrayList upattlist)
		{
			
			string DocID = "";
			int cstRightToApproveDocument = 2;
			ProjectClass pjt = new ProjectClass();
			DocBody docbody = new DocBody();
			docbody.DocTitle			= mailbody.MailSubject;
			docbody.DocContent			= mailbody.MailBody;
			docbody.DocAddedBy			= mailbody.MailSender;
			docbody.DocClassID			= mailbody.MailClassID;
			docbody.DocAddedDate        = DateTime.Now.ToString();
			docbody.DocApprover			= (pjt.GetAccessPermission(Int32.Parse(ClassID),Username,cstRightToApproveDocument))?Username:"";
			docbody.DocApproveDate		= (pjt.GetAccessPermission(Int32.Parse(ClassID),Username,cstRightToApproveDocument))?DateTime.Now.ToString():"";
			docbody.DocApproved         = (docbody.DocApprover =="")?0:1;
			docbody.DocAttribute        = 0;
			docbody.DocType				= 0;
			
			DocumentClass doc = new DocumentClass();
			// ����ĵ�,������ID
				
			DocID = doc.AddDocBody(docbody);
			foreach(UDS.Components.MailAttachFile  att in upattlist)
			{
				try
				{
					DocAttachFile docatt = new DocAttachFile();
					//  Mail Attach File ��ת��ΪDoc Attach File
					docatt.FileAttribute  = 0;
					docatt.FileSize       = att.FileSize;
					docatt.FileName	      = att.FileName;
					docatt.FileAuthor     = Username;
					docatt.FileCatlog     = "�ĵ�";
					docatt.FileVisualPath = "Mail"+att.FileVisualPath;
					docatt.FileAddedDate  = DateTime.Now.ToString();
					docatt.DocID          = Int32.Parse(DocID);
					// ת������
					
					
					// �������ݿ⴦��
					doc.AddAttach(docatt,Int32.Parse(DocID));
					
					
				
				}
				catch(Exception ioex)
				{
					UDS.Components.Error.Log(ioex.ToString());
					Server.Transfer("../../Error.aspx");
				}
			}
			
		}
		#endregion

		/// <summary>
		/// ���Ŵ��������ʼ�������������
		/// </summary>
		private void btnSendMail_Click(object sender, System.EventArgs e)
		{
			
				HttpCookie UserCookie = Request.Cookies["Username"];
				Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
				MailClass mailclass   = new UDS.Components.MailClass();
				MailMainBody mailbody = new UDS.Components.MailMainBody(); 
				ArrayList listmail    = new ArrayList();
				ArrayList upattlist = (ArrayList)Session["upattlist"];
			//	ArrayList listattfile = new ArrayList();
				// �õ�mailbody��
				mailbody = ProcessFormPost();
				//�ʼ�����
			
				
				try
				{	
					listmail     = mailclass.MailSend(mailbody); // �����Ѿ����͵��ʼ�ID�б�(�������ͺ��ܳ�)
				//	listattfile	 = AttUpload(mailbody.MailReceiverStr.ToString());   // �����ʼ���������
					foreach(string mailID in listmail)
					{   // ѭ�������ʼ�����
						foreach(UDS.Components.MailAttachFile att in upattlist)
						{   //�������ʼ����������ݿ�������� 
							
							Random TempNameInt    = new Random(); 
							string NewDocDirName  = TempNameInt.Next(100000000).ToString();
							Directory.CreateDirectory(Server.MapPath(".")+"\\AttachFiles\\"+Username+"\\"+NewDocDirName);	
							//File.Move(Server.MapPath(".")+"\\"+att.FileVisualPath ,Server.MapPath(".")+"\\AttachFiles\\"+Username+"\\"+NewDocDirName+"\\"+att.FileName);
							File.Copy(Server.MapPath(".")+"\\"+att.FileVisualPath ,Server.MapPath(".")+"\\AttachFiles\\"+Username+"\\"+NewDocDirName+"\\"+att.FileName,true);
							
							//		Directory.Delete(Server.MapPath(".")+"\\"+att.FileVisualPath.ToString().Replace(att.FileName,""),true);
							att.FileVisualPath    = "\\AttachFiles\\"+Username+"\\"+NewDocDirName+"\\"+att.FileName;
							mailclass.AttSend(att,Int32.Parse(mailID));
						}
					}
				
					if(cblistAttribute.Items[1].Selected&&Request.Form["hdnProjectID"].ToString()!="0")
					{
						DocProcess(mailbody,upattlist);
					}

					Response.Write("<script language=javascript>alert('�ʼ����ͳɹ�!');if(parent.frames.length==0) window.close();else self.location=('Index.aspx');</script>");	
				}
				catch (Exception sendex)
				{
					UDS.Components.Error.Log(sendex.ToString());
					Server.Transfer("../../Error.aspx");
				}
			
			
		}
		
		
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
			this.txtSubject.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
			this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		

		private void txtSubject_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void BindAttList()
		{
		
			this.listUp.Items.Clear();
			int count = 0;
			ArrayList upattlist = (ArrayList)Session["upattlist"];
			foreach(UDS.Components.MailAttachFile  att in upattlist)
			{
				count++;
				this.listUp.Items.Add(new ListItem(att.FileName.ToString(),count.ToString()));
			
			}

		}

		private void btnUpload_Click(object sender, System.EventArgs e)
		{
			HtmlForm FrmCompose   = (HtmlForm)this.Page.FindControl("Compose");
			Random TempNameInt    = new Random(); 
			string NewMailDirName  = TempNameInt.Next(100000000).ToString();
			// ��Ÿ������ύ��Ŀ¼�У��������Ŀ¼��
			ArrayList upattlist = (ArrayList)Session["upattlist"];
			string FileName       = "";
			try
			{ 
				if(!Directory.Exists(Server.MapPath(".")+"\\AttachFiles\\tmp"))
					Directory.CreateDirectory(Server.MapPath(".")+"\\AttachFiles\\tmp");
				
					Directory.CreateDirectory(Server.MapPath(".")+"\\AttachFiles\\tmp\\"+NewMailDirName+Username);
					for (int i=0;i<FrmCompose.Controls.Count;i++)
					{	
						if(FrmCompose.Controls [i].GetType().ToString()=="System.Web.UI.HtmlControls.HtmlInputFile")
						{
							
							HtmlInputFile hif = ((HtmlInputFile)(FrmCompose.Controls[i]));
							if(hif.PostedFile.FileName.Trim()!="")
							{	
								FileName = System.IO .Path.GetFileName(hif.PostedFile.FileName);	
								UDS.Components.MailAttachFile att = new MailAttachFile();
								// ��ʼ��
								att.FileAttribute  = 0;
								att.FileSize       = hif.PostedFile.ContentLength;
								att.FileName	   = FileName;
								att.FileAuthor     = Username;
								att.FileCatlog     = "�ʼ�";
								att.FileVisualPath = "\\AttachFiles\\tmp\\"+NewMailDirName+Username+"\\"+FileName;
								hif.PostedFile.SaveAs(Server.MapPath(".")+"\\AttachFiles\\tmp\\"+NewMailDirName+Username+"\\"+FileName);
								upattlist.Add(att);	
														
							}
							hif=null;
						}
					}
				Session["upattlist"] = upattlist;
				BindAttList();
				this.SendToRealName       = Request.Form["txtSendTo"].ToString();
				this.SendTo				  = Request.Form["hdnTxtSendTo"].ToString();
				this.CcTo				  = Request.Form["hdnTxtCcTo"].ToString();
				this.BccTo				  = Request.Form["hdnTxtBccTo"].ToString();
				this.CcToRealName         = Request.Form["txtCcTo"].ToString();
				this.BccToRealName        = Request.Form["txtBccTo"].ToString();  
			} 
			catch(Exception ioex)
			{	
				UDS.Components.Error.Log(ioex.ToString());
				Server.Transfer("../../Error.aspx");
			}

			
			
            			
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			ArrayList upattlist = (ArrayList)Session["upattlist"];
			for(int i=listUp.Items.Count-1;i>=0;i--)
			{
				if(this.listUp.Items[i].Selected)
				{
					this.listUp.Items.RemoveAt(i);
					upattlist.RemoveAt (i);
				}
			}
			
			Session["upattlist"] = upattlist;
			this.SendToRealName       = Request.Form["txtSendTo"].ToString();
			this.SendTo				  = Request.Form["hdnTxtSendTo"].ToString();
			this.CcTo				  = Request.Form["hdnTxtCcTo"].ToString();
			this.BccTo				  = Request.Form["hdnTxtBccTo"].ToString();
			this.CcToRealName         = Request.Form["txtCcTo"].ToString();
			this.BccToRealName        = Request.Form["txtBccTo"].ToString();  
		}
			
		
	}
}
