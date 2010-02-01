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
using UDS.Components;
using System.Data.SqlClient;

namespace UDS.SubModule.UnitiveDocument.DocumentFlow
{
	/// <summary>
	/// SignDocument 的摘要说明。
	/// </summary>
	public class SignDocument : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button cmdSignIn;
		protected System.Web.UI.WebControls.Table tabDispDocument;
		protected System.Web.UI.HtmlControls.HtmlForm PostilDocument;
		protected System.Web.UI.WebControls.Button cmdCancelSignIn;
		protected System.Web.UI.WebControls.Button cmdPostilFinish;
		protected System.Web.UI.WebControls.Button cmdPostilFaile;
		protected System.Web.UI.WebControls.Button cmdPostilNext;
		private int DisplayStatus;
		private string UserName;
		protected System.Web.UI.HtmlControls.HtmlTable tabReturn;

		private int ReturnPage;
		protected System.Web.UI.WebControls.Button cmdBack;
		protected System.Web.UI.WebControls.Button cmdReturn;
		
		private		long	DocID;
		private		long	ProjectID=-1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden PID;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlProject;
		private		bool	FlowState;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面

			DocID = Int32.Parse(Request.QueryString["DocID"].ToString());		
			UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);
			ReturnPage = Request.QueryString["ReturnPage"]!=null?Int32.Parse(Request.QueryString["ReturnPage"].ToString()):1;
			InitControl();
			Bind();
		}

		private void InitControl()
		{
			UDS.Components.DocumentFlow df	= new UDS.Components.DocumentFlow();
 
			DisplayStatus = df.GetDocumentStatus(DocID,UserName);
			
			//移动表单的位置
			tabDispDocument.Style["Left"]	= "0px";
			tabDispDocument.Style["Top"]	= "0px";

			if(DisplayStatus==0)		//签收状态
			{
				cmdSignIn.Visible		= true;
				cmdCancelSignIn.Visible = false;
				cmdPostilNext.Visible	= false;
				cmdPostilFaile.Visible	= false;
				cmdPostilFinish.Visible	= false;
				cmdBack.Visible			= false;

				FlowState				= false;

			}
			else if(DisplayStatus==1)	//一般批阅状态
			{
				cmdSignIn.Visible		= false;
				cmdCancelSignIn.Visible = true;
				cmdPostilNext.Visible	= true;
				cmdPostilFaile.Visible	= true;
				cmdPostilFinish.Visible = true;
				cmdBack.Visible			= true;

				FlowState				= true;

			}
			else if(DisplayStatus==2)	//撤消状态，现在已经没有撤消状态了，只有文档是草稿才能删除
			{
				cmdSignIn.Visible		= true;
				cmdCancelSignIn.Visible = false;
				cmdPostilNext.Visible	= false;
				cmdPostilFaile.Visible	= false;
				cmdPostilFinish.Visible	= false;
				cmdBack.Visible			= false;

				FlowState				= false;
			}
			else if(DisplayStatus==4)	//会签状态批阅
			{
				cmdSignIn.Visible		= false;
				cmdCancelSignIn.Visible = true;
				cmdPostilNext.Visible	= true;
				cmdPostilFaile.Visible	= true;
				cmdPostilFinish.Visible = false;
				cmdBack.Visible			= true;

				FlowState				= true;

			}
			else						//查看状态
			{
				cmdSignIn.Visible		= false;
				cmdCancelSignIn.Visible = false;
				cmdPostilNext.Visible	= false;
				cmdPostilFaile.Visible	= false;
				cmdPostilFinish.Visible = false;
				cmdBack.Visible			= false;

				FlowState				= false;
			}
			df = null;

			tabDispDocument.Style.Add("BORDER-COLLAPSE","collapse");
		}


		private void Bind()
		{	
			UDS.Components.DocumentFlow df	= new UDS.Components.DocumentFlow();				
			Database	mySQL				= new Database();

			long			FlowID;
			long			StepID;

			DataTable	dt;

			FlowID	= df.GetDocumentFlowID(DocID);
			StepID	= df.GetDocumentStepID(DocID);
			
			cmdPostilFinish.Visible  =cmdPostilFinish.Visible&&df.GetStepRightToFinish(FlowID,StepID) == 1?true:false;
			ProjectID = Int32.Parse(PID.Value);

			//流程批阅状态并且按照项目流转
			if(FlowState==true&&df.IsProject(UserName,DocID))
			{				
				if(!Page.IsPostBack)
				{
					ddlProject.Visible = true;
					ddlProject.Items.Clear();

					df.GetProject(UserName,out dt);

					ddlProject.DataSource		= dt.DefaultView;
					ddlProject.DataTextField	= "ClassName";
					ddlProject.DataValueField	= "ClassID";
					ddlProject.DataBind();
					
					if(ddlProject.Items.Count>0)
					{
						PID.Value = ddlProject.Items[0].Value; 
					}
					else
						PID.Value = "-1";
				}

			}
			else
			{
				ddlProject.Visible = false;
			}

			df.GetDocumentInfo(DocID,out dt);
			
			AddRow(tabDispDocument,"基本信息");

			AddRow(tabDispDocument,"流程:",dt.Rows[0]["flow_name"].ToString());
			AddRow(tabDispDocument,"发送者:",dt.Rows[0]["realname"].ToString());
			AddRow(tabDispDocument,"发送日期:",dt.Rows[0]["doc_added_date"].ToString());
			AddRow(tabDispDocument,"当前步骤:","<a href='DisplayTacheMember.aspx?DocID=" + DocID.ToString() + "&ReturnPage=" + ReturnPage.ToString() + "'>" + dt.Rows[0]["Step_name"].ToString() + "</a>");

			AddRow(tabDispDocument,"详细表单");

			if(dt.Rows.Count >0)
			{

				FlowID = Int32.Parse(dt.Rows[0]["flow_id"].ToString());
				
				HtmlForm PostilDocument   = (HtmlForm)this.Page.FindControl("PostilDocument");

				//=============================//
				//			添加正文
				//=============================//				
				DataTable dtSheet;
				df.GetStyleDescription(FlowID,0,out dtSheet);

				for(int i =0;i<dtSheet.Rows.Count;i++)				
				{			
					AddRow(tabDispDocument,dtSheet.Rows[i]["Field_Description"].ToString() + ":",dt.Rows[0][dtSheet.Rows[i]["Field_Name"].ToString()].ToString());
				}
				
				dtSheet = null;

				//=============================//
				//			添加附件
				//=============================//				
				AddAttach(DocID);
			
				//=============================//
				//			添加批注
				//=============================//
				DataTable dtPostil;
				df.GetDocumentPostil(DocID,out dtPostil); 
				
				if(dtPostil.Rows.Count>0)
				{
					AddRow(tabDispDocument,"审批意见");
					AddPostitleHead(tabDispDocument);

					for(int i=0;i<dtPostil.Rows.Count;i++)					
					{
						AddRow(tabDispDocument,dtPostil.Rows[i]["RealName"].ToString(),dtPostil.Rows[i]["Postil_Date"].ToString(),dtPostil.Rows[i]["Postil_Content"].ToString(),Int32.Parse(dtPostil.Rows[i]["Postil_Type"].ToString() ),dtPostil.Rows[i]["FileName"].ToString(),dtPostil.Rows[i]["FileVisualPath"].ToString(),dtPostil.Rows[i]["usedtime"].ToString());
					}
				}
							
				dtPostil = null;

				AddProjectControl();
				AddControl(tabDispDocument);
				
			}	
						
		}
		private void AddAttachControl()
		{
			string Template;
			long FlowID;
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
			FlowID = df.GetDocumentFlowID(DocID);
			Template = df.GetStyleTemplate(FlowID);
            if (Template != "")
            {
                TableRow tr = new TableRow();
                TableCell td = new TableCell();
                TableCell tc = new TableCell();
                Literal lt = new Literal();


                lt.Text = "<a href='" + Template + "' style='text-decoration: underline' titile='模板下载' target='_blank'>模板</a>:";
                tc.HorizontalAlign = HorizontalAlign.Right;
                tc.Width = Unit.Percentage(20);
                tc.Controls.Add(lt);


                td.HorizontalAlign = HorizontalAlign.Left;
                td.ColumnSpan = 5;


                System.Web.UI.HtmlControls.HtmlInputFile hif = new System.Web.UI.HtmlControls.HtmlInputFile();
                hif.ID = "fileTemplate";
                hif.Name = "fileTemplate";
                hif.Style["width"] = Unit.Percentage(70).ToString();
                hif.Style["Class"] = "Input3";

                td.Controls.Add(hif);

                tr.Cells.Add(tc);
                tr.Cells.Add(td);


                tabDispDocument.Rows.Add(tr);

                td = null;
                tr = null;

            }
            else
            {
                TableRow tr = new TableRow();
                TableCell td = new TableCell();
                TableCell tc = new TableCell();
                Literal lt = new Literal();


                lt.Text = "上传附件:";
                tc.HorizontalAlign = HorizontalAlign.Right;
                tc.Width = Unit.Percentage(20);
                tc.Controls.Add(lt);


                td.HorizontalAlign = HorizontalAlign.Left;
                td.ColumnSpan = 5;


                System.Web.UI.HtmlControls.HtmlInputFile hif = new System.Web.UI.HtmlControls.HtmlInputFile();
                hif.ID = "fileTemplate";
                hif.Name = "fileTemplate";
                hif.Style["width"] = Unit.Percentage(70).ToString();
                hif.Style["Class"] = "Input3";

                td.Controls.Add(hif);

                tr.Cells.Add(tc);
                tr.Cells.Add(td);


                tabDispDocument.Rows.Add(tr);

                td = null;
                tr = null;

            }

			df = null;

		}
		private void AddAttach(long DocID)
		{

			UDS.Components.DocumentFlow df	= new UDS.Components.DocumentFlow();
			DataTable dt					= new DataTable();

			df.GetDocumentAttach(DocID,out dt);
			for(int i=0;i<dt.Rows.Count;i++)
			{
				TableRow  tr		= new TableRow();
				TableCell td		= new TableCell();
				TableCell tc		= new TableCell();

				td.Text ="附件:";
				td.HorizontalAlign	= HorizontalAlign.Right;

				string FilePath		= dt.Rows[i]["FileVisualPath"].ToString() + dt.Rows[i]["FileName"].ToString();

				tc.Text				= "<a href='" +"." + FilePath.Replace("\\","/") +"' target='_blank'>" + dt.Rows[i]["FileName"].ToString() + "</a>";
				tc.HorizontalAlign	= HorizontalAlign.Left;
				tc.ColumnSpan		= 5;

				tr.Cells.Add(td);			
				tr.Cells.Add(tc);
				
				tr.Height			= 22;
				tr.HorizontalAlign	= HorizontalAlign.Center;

				tabDispDocument.Rows.Add(tr);
			}

			dt = null;
			df = null;


		}
		private void AddProjectControl()
		{
			
			if(ddlProject.Visible == true)
			{
				TableRow  tr	= new TableRow();
				TableCell td	= new TableCell();
				TableCell tl	= new TableCell();

				td.Text				= "请选择所属项目:";
				td.HorizontalAlign	= HorizontalAlign.Right;
				td.ColumnSpan		= 5;
				td.Width			= Unit.Percentage(20);
				td.BackColor		= Color.FromArgb(0xe8,0xf4,0xff);	
				tr.Cells.Add(td);
				
				ddlProject.Style["Width"]	= "100%";
				ddlProject.Style["Class"]	= "Input3";
				tr.EnableViewState = true;
				
				tl.Width					= Unit.Percentage(80);
				tl.Controls.Add(ddlProject);	
			
				tr.Cells.Add(tl);
				
				tabDispDocument.Rows.Add(tr);

				td = null;
				tr = null;

			}
			

		}		
		private void AddRow(Table tab,string Caption,string Content)
		{
			TableRow tr		= new TableRow();
			TableCell tl	= new TableCell();
			TableCell tc	= new TableCell();

			//标题栏目
			tl.Text				= Caption; 
			tl.Width			= Unit.Percentage(20);
			tl.HorizontalAlign	= HorizontalAlign.Right;			
			tl.BackColor		= Color.FromArgb(0xe8,0xf4,0xff);			

			//内容正文
			tc.Text			= Content;
			tc.Width		= Unit.Percentage(80);
			tc.ColumnSpan	= 5;			

			tr.Height		= 22;

			tr.Cells.Add(tl);
			tr.Cells.Add(tc);

			tab.Rows.Add(tr);

			tc = null;
			tl = null;
			tr = null;			
		}

		private void AddRow(Table tab,string Caption)
		{
			TableRow tr		= new TableRow();
			TableCell tl	= new TableCell();
			
			tl.Text			= Caption;	
			tl.ColumnSpan	= 6 ;
			tl.Width		= Unit.Percentage(100);
			tl.HorizontalAlign  = HorizontalAlign.Center;
			tl.Attributes["background"]="../../../Images/treetopbg.jpg";			
			//tl.BackColor = Color.FromArgb(0xff,0xff,0xef);

			tr.Height		= 28;
			tr.Cells.Add(tl);

			tab.Rows.Add(tr);

			tl = null;
			tr = null;			
		}
		private void AddRow(Table tab,string Postiler,string PostilTime,string PostilContent,int PostilType,string FileName,string FileVisualPath,string UsedTime)
		{
			TableRow tr						=	new TableRow();
			TableCell tdPotiler				=	new TableCell();
			TableCell tdPostilTime			=	new TableCell();
			TableCell tdPotilType			=	new TableCell();
			TableCell tdPotilContent		=	new TableCell();
			TableCell tdAttachFiles			=	new TableCell();
			TableCell tdTime				=	new TableCell();
			
			
			tdPotiler.Text					= Postiler;
			tdPotiler.HorizontalAlign		= HorizontalAlign.Center;
			tdPotiler.Width					= Unit.Percentage(20);
			

			tdPostilTime.Text				= PostilTime;
			tdPostilTime.HorizontalAlign	= HorizontalAlign.Center;
			tdPostilTime.Width				= Unit.Percentage(20);
			switch(PostilType)
			{
				case 1:
					tdPotilType.Text				= "同意";
					break;
				case 2:
					tdPotilType.Text				= "拒绝";
					break;
				case 3:
					tdPotilType.Text				= "完成";
					break;
				case 4:
					tdPotilType.Text				= "回退";
					break;
				default:
					break;
			}			
			tdPotilType.HorizontalAlign		= HorizontalAlign.Center;
			tdPotilType.Width				= Unit.Percentage(10);


			tdPotilContent.Text				= PostilContent;
			tdPotilContent.HorizontalAlign	= HorizontalAlign.Left;
			tdPotilContent.Width			= Unit.Percentage(30);
	
			tr.Height  =22;
			//tr.BackColor = Color.FromArgb(0xe8,0xf4,0xff);
			

			string FilePath		= FileVisualPath + FileName;
			tdAttachFiles.Text				= "<a href='" +"." + FilePath.Replace("\\","/") +"' target='_blank'>" + FileName + "</a>";
			
			tdAttachFiles.HorizontalAlign	= HorizontalAlign.Center  ;
			tdAttachFiles.Width				= Unit.Percentage(10);

			tdTime.Text						= UsedTime;
			tdTime.HorizontalAlign			= HorizontalAlign.Center  ;
			tdTime.Width					= Unit.Percentage(10);

			tr.Cells.Add(tdPotiler);
			tr.Cells.Add(tdPostilTime);
			tr.Cells.Add(tdPotilType);
			tr.Cells.Add(tdPotilContent);
			tr.Cells.Add(tdAttachFiles);
			tr.Cells.Add(tdTime);


			tab.Rows.Add(tr);


			tdPotiler		= null;
			tdPostilTime	= null;
			tdPotilType		= null;
			tdPotilContent	= null;
			tdAttachFiles	= null;
			tdTime			= null;

			tr				= null;					
		}

		private void AddPostitleHead(Table tab)
		{

			TableRow tr						=	new TableRow();
			TableCell tdPotiler				=	new TableCell();
			TableCell tdPostilTime			=	new TableCell();
			TableCell tdPotilType			=	new TableCell();
			TableCell tdPotilContent		=	new TableCell();
			TableCell tdAttachFiles			=	new TableCell();
			TableCell tdTime				=	new TableCell();
			
			
			tdPotiler.Text					="批阅人";
			tdPotiler.HorizontalAlign		= HorizontalAlign.Center;
			tdPotiler.Width					= Unit.Percentage(20);
			

			tdPostilTime.Text				="批阅时间";
			tdPostilTime.HorizontalAlign	= HorizontalAlign.Center;
			tdPostilTime.Width				= Unit.Percentage(20);

			tdPotilType.Text				="批阅类型";
			tdPotilType.HorizontalAlign		= HorizontalAlign.Center;
			tdPotilType.Width				= Unit.Percentage(10);


			tdPotilContent.Text				="批阅内容";
			tdPotilContent.HorizontalAlign	= HorizontalAlign.Left ;
			tdPotilContent.Width			= Unit.Percentage(30);

			tdAttachFiles.Text				="附件";

			tdAttachFiles.HorizontalAlign	= HorizontalAlign.Center  ;
			tdAttachFiles.Width				= Unit.Percentage(10);

			tdTime.Text						="用时(分)";
			tdTime.HorizontalAlign			= HorizontalAlign.Center  ;
			tdTime.Width					= Unit.Percentage(10);

	
			tr.Height  =22;
			tr.BackColor = Color.FromArgb(0xe8,0xf4,0xff);

			tr.Cells.Add(tdPotiler);
			tr.Cells.Add(tdPostilTime);
			tr.Cells.Add(tdPotilType);
			tr.Cells.Add(tdPotilContent);
			tr.Cells.Add(tdAttachFiles);
			tr.Cells.Add(tdTime);


			tab.Rows.Add(tr);


			tdPotiler		= null;
			tdPostilTime	= null;
			tdPotilType		= null;
			tdPotilContent	= null;

			tr				= null;			

		}

		private void UploadFile(long PostilID)
		{
			string FileName = "";
			HtmlForm FrmCompose   = (HtmlForm)this.Page.FindControl("PostilDocument");

			//生成附件目录
			if(!System.IO.Directory.Exists(Server.MapPath(".")+"\\AttachFiles"))
			{
				System.IO.Directory.CreateDirectory(Server.MapPath(".")+"\\AttachFiles");
			}
			
			try
			{
				HtmlInputFile hif = ((HtmlInputFile)(FrmCompose.FindControl("fileTemplate")));
				if(hif.PostedFile!=null)
				{
					if(hif.PostedFile.FileName.Trim()!="")
					{	
						FileName = System.IO.Path.GetFileName(hif.PostedFile.FileName);											
						
						//生成用户目录
						if(!System.IO.Directory.Exists(Server.MapPath(".")+"\\AttachFiles\\" + UserName))
						{
							System.IO.Directory.CreateDirectory(Server.MapPath(".")+"\\AttachFiles\\"+ UserName);						
						}
						
						Random TempNameInt    = new Random(); 
						string NewDocDirName  = TempNameInt.Next(100000000).ToString();		
						//生成随机目录
						if(!System.IO.Directory.Exists(Server.MapPath(".")+"\\AttachFiles\\" + UserName + "\\" + NewDocDirName))
						{
							System.IO.Directory.CreateDirectory(Server.MapPath(".")+"\\AttachFiles\\" + UserName  + "\\" + NewDocDirName);						
						}			

						TempNameInt = null;
						
						//保存文件
						hif.PostedFile.SaveAs(Server.MapPath(".")+"\\AttachFiles\\" + UserName  + "\\" + NewDocDirName + "\\" + FileName);

						UDS.Components.DocAttachFile att = new UDS.Components.DocAttachFile();
						UDS.Components.DocumentFlow  df  = new UDS.Components.DocumentFlow();

						// 初始化
						att.FileAttribute	= 0;
						att.FileSize		= hif.PostedFile.ContentLength;
						att.FileName		= FileName;
						att.FileAuthor		= UserName;
						att.FileCatlog		= "公文";
						att.FileVisualPath	= "\\AttachFiles\\" + UserName  + "\\" + NewDocDirName + "\\";
						att.FileAddedDate	= DateTime.Now.ToString();;
						
						
						df.AddPostilAttach(att,PostilID);

						df = null;
						att = null;

					}
					hif=null;
				}
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());
			}
			finally
			{
				
			}			
			
		}

		private void AddControl(Table tab)
		{
			TableRow tr = new TableRow();
			TableCell td = new TableCell();
			
			
			td.Controls.Add(cmdSignIn);
			td.Controls.Add(cmdPostilNext);
			td.Controls.Add(cmdBack);
			td.Controls.Add(cmdPostilFaile);
			td.Controls.Add(cmdPostilFinish);
			td.Controls.Add(cmdCancelSignIn);			
			td.Controls.Add(cmdReturn);			

			//cmdReturn.Text ="<INPUT class='redButtonCss' style='WIDTH: 74px; HEIGHT: 20px' type='button' value='返回' onclick=\"location.href='listDocument.aspx?DisplayType=" + ReturnPage.ToString() + "'\">";
			
			if(cmdPostilNext.Visible||cmdPostilFaile.Visible||cmdPostilFinish.Visible)
			{

				AddRow(tab,"审批意见");

				TableRow trc		= new TableRow();
				TableCell tdc		= new TableCell();
				TableCell tc		= new TableCell();

				TextBox txtPostil	= new TextBox();
				
				txtPostil.ID = "txtPostil";				
				txtPostil.TextMode	= TextBoxMode.MultiLine;
				txtPostil.Width		= Unit.Percentage(70);
				txtPostil.Height	= 100;
				
				tc.Text = "审批内容:";
				tc.HorizontalAlign	= HorizontalAlign.Right;
				tc.VerticalAlign	= VerticalAlign.Top;
				tc.Width = Unit.Percentage(20);

				tdc.ColumnSpan		= 5;
				tdc.HorizontalAlign = HorizontalAlign.Left ;
				tdc.Controls.Add(txtPostil);

				trc.Cells.Add(tc);
				trc.Cells.Add(tdc);
				
				tab.Rows.Add(trc);

				trc			= null;
				tdc			= null;
				txtPostil	= null;

				AddAttachControl();

			}

			td.ColumnSpan	=6;

			tr.Height		=22;
			tr.Cells.Add(td);			
			tr.HorizontalAlign = HorizontalAlign.Center;
			tab.Rows.Add(tr);

			td	= null;
			tr	= null;
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
			this.cmdSignIn.Click += new System.EventHandler(this.cmdSignIn_Click);
			this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
			this.cmdPostilNext.Click += new System.EventHandler(this.cmdPostilNext_Click);
			this.cmdPostilFaile.Click += new System.EventHandler(this.cmdPostilFaile_Click);
			this.cmdPostilFinish.Click += new System.EventHandler(this.cmdPostilFinish_Click);
			this.cmdCancelSignIn.Click += new System.EventHandler(this.cmdCancelSignIn_Click);
			this.cmdReturn.Click += new System.EventHandler(this.cmdReturn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdSignIn_Click(object sender, System.EventArgs e)
		{			
			string UserName					= Server.UrlDecode(Request.Cookies["UserName"].Value);
			UDS.Components.DocumentFlow df	= new UDS.Components.DocumentFlow();

			df.SignInDocument(UserName,DocID);
			df = null;

			cmdSignIn.Visible				= false;
			
			Response.AddHeader("Refresh","1");

		}

		private void cmdCancelSignIn_Click(object sender, System.EventArgs e)
		{
			string UserName					= Server.UrlDecode(Request.Cookies["UserName"].Value);
			UDS.Components.DocumentFlow df	= new UDS.Components.DocumentFlow();						
			df.CancelSignInDocument(UserName,DocID); 				
			df = null;
						
			Response.AddHeader("Refresh","1");

		}

		private void cmdPostilNext_Click(object sender, System.EventArgs e)
		{
			UDS.Components.DocumentFlow df	= new UDS.Components.DocumentFlow();
			HtmlForm FrmNewDocument			= (HtmlForm)this.Page.FindControl("PostilDocument");
			TextBox tmpText;
			tmpText							= (TextBox)FrmNewDocument.FindControl("txtPostil");
			long PostilID;
			try
			{			
				if(ProjectID>=0)
				{
					PostilID = df.AddPostil(UserName,DocID,tmpText.Text,1,ProjectID,2);	

					int iResult;
					iResult = df.PostDocument(UserName,DocID,ProjectID);

                    UploadFile(PostilID);		
					if(iResult==0)
					{
											
					}
					else
					{
						Response.Write("<script lanuage='javascript'>alert('" + df.DoMessage(iResult,DocID,false) + "');</script>");
					}
				}
				else
				{
					Response.Write("<script lanuage='javascript'>alert('没有上级项目！');</script>");
				}
				
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());			
			}
			finally
			{
				df = null;
			}
			Response.AddHeader("Refresh","1");			
		
		}

		private void cmdPostilFaile_Click(object sender, System.EventArgs e)
		{
			UDS.Components.DocumentFlow df	= new UDS.Components.DocumentFlow();
			HtmlForm FrmNewDocument			= (HtmlForm)this.Page.FindControl("PostilDocument");
			TextBox tmpText;
			tmpText							= (TextBox)(FrmNewDocument.FindControl("txtPostil"));
			long PostilID;
			try
			{
				PostilID= df.AddPostil(UserName,DocID,tmpText.Text,2,ProjectID,2);				
				df.FaileDocument(DocID);
				UploadFile(PostilID);
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());			
			}
			finally
			{
				df = null;
			}
			Response.AddHeader("Refresh","1");			
		}

		private void cmdPostilFinish_Click(object sender, System.EventArgs e)
		{
			UDS.Components.DocumentFlow df	= new UDS.Components.DocumentFlow();
			HtmlForm FrmNewDocument			= (HtmlForm)this.Page.FindControl("PostilDocument");
			TextBox tmpText;
			tmpText							= (TextBox)(FrmNewDocument.FindControl("txtPostil"));
			long PostilID;
			try
			{
				PostilID = df.AddPostil(UserName,DocID,tmpText.Text,3,ProjectID,0);				
				df.FinishDocument(DocID);
				UploadFile(PostilID);
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());			
			}
			finally
			{
				df = null;
			}
			Response.AddHeader("Refresh","1");			

		}


		private void cmdReturn_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("listDocument.aspx?DisplayType=" + ReturnPage.ToString());		
		}

		private void cmdBack_Click(object sender, System.EventArgs e)
		{
			UDS.Components.DocumentFlow df	= new UDS.Components.DocumentFlow();
			HtmlForm FrmNewDocument			= (HtmlForm)this.Page.FindControl("PostilDocument");
			TextBox tmpText;
			tmpText							= (TextBox)FrmNewDocument.FindControl("txtPostil");
			long PostilID;
			try
			{
				PostilID = df.AddPostil(UserName,DocID,tmpText.Text,4,ProjectID,2);	
				df.BackDocument(DocID);
				UploadFile(PostilID);
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());			
			}
			finally
			{
				df = null;
			}
			Response.AddHeader("Refresh","1");					
		}


	}
}
