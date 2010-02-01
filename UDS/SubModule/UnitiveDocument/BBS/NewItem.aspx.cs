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

namespace UDS.SubModule.UnitiveDocument.BBS
{
	/// <summary>
	/// NewItem 的摘要说明。
	/// </summary>
	public class NewItem : System.Web.UI.Page
	{
		private  string username;
		private  string boardid;
		private  bool isboardmaster;
		private  bool isadmin;
		private	 bool isbulletinadmin;

		protected System.Web.UI.HtmlControls.HtmlInputText Title;
		protected System.Web.UI.HtmlControls.HtmlTextArea Content;
		protected System.Web.UI.WebControls.Button btn_UpAtt;
		protected System.Web.UI.WebControls.DropDownList ddl_FileType;
		protected System.Web.UI.HtmlControls.HtmlInputFile hif;
		protected System.Web.UI.WebControls.CheckBox cbx_bulletin;
		protected System.Web.UI.WebControls.CheckBox cbx_sysbulletin;
		protected System.Web.UI.WebControls.Label lbl_DeskTop;
		protected System.Web.UI.WebControls.Button btn_DelAtt;
		protected System.Web.UI.WebControls.ListBox lbx_AttList;
		protected System.Web.UI.WebControls.CheckBox cbx_DeskTop;
		protected System.Web.UI.HtmlControls.HtmlInputButton cmdOK;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				cbx_sysbulletin.Attributes["onclick"] = "sysbulletin_click();";
				username =  Server.UrlDecode(Request.Cookies["UserName"].Value);
				boardid  = (Request.QueryString["BoardID"]==null)?"0":Request.QueryString["BoardID"];
				UDS.Components.BBSClass bbs = new UDS.Components.BBSClass();

				isboardmaster = bbs.IsBoardMaster(Int32.Parse(boardid),username);
				cbx_bulletin.Visible = isboardmaster;

				//如果是私有板块则不允许发布系统公告
				bool privateboard = false;
				SqlDataReader dr_board = bbs.GetModifyBBSBoard(Int32.Parse(boardid));
                try
                {
                    while (dr_board.Read())
                    {
                        if (Boolean.Parse(dr_board["board_type"].ToString()) == false)
                            privateboard = true;
                    }
                }
                finally
                {
                    dr_board.Close();
                }
				if(Request.Cookies["UDSBBSAdmin"].Value=="0")
				{
					isadmin = false;
				}
				else if(Request.Cookies["UDSBBSAdmin"].Value=="1")
				{
					isadmin = true;
				}
					
				if(Request.Cookies["UDSBBSBulletinAdmin"].Value=="0")
				{
					isbulletinadmin = false;
				}
				else if(Request.Cookies["UDSBBSBulletinAdmin"].Value=="1")
				{
					isbulletinadmin = true;
				}

				if(isadmin && !privateboard)
				{
					cbx_sysbulletin.Visible = cbx_DeskTop.Visible = lbl_DeskTop.Visible = true;
				}
				else if(isbulletinadmin && !privateboard)
				{
					cbx_sysbulletin.Visible = cbx_DeskTop.Visible = lbl_DeskTop.Visible = true;
				}
				else
				{
					cbx_sysbulletin.Visible = cbx_DeskTop.Visible = lbl_DeskTop.Visible = false;

				}

				ViewState["username"] = username;
				ViewState["boardid"] = boardid;
				ViewState["isboardmaster"] = isboardmaster;
				ViewState["isadmin"] = isadmin;
				ViewState["isbulletinadmin"] = isbulletinadmin;
			}
			else
			{
				username = ViewState["username"].ToString();
				boardid = ViewState["boardid"].ToString();
				isboardmaster = Boolean.Parse(ViewState["isboardmaster"].ToString());
				isadmin = Boolean.Parse(ViewState["isadmin"].ToString());
				isbulletinadmin = Boolean.Parse(ViewState["isbulletinadmin"].ToString());
			}
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
			this.btn_UpAtt.Click += new System.EventHandler(this.btn_UpAtt_Click);
			this.btn_DelAtt.Click += new System.EventHandler(this.btn_DelAtt_Click);
			this.cmdOK.ServerClick += new System.EventHandler(this.cmdOK_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdOK_ServerClick(object sender, System.EventArgs e)
		{
			BBSClass bbs = new BBSClass();
			BBSForumItem item = new BBSForumItem();
			string itemcontent = ViewState["Content"] + Content.Value;
			item.BoardID = Int32.Parse(boardid);
			item.Title   = Title.Value.Replace("<","&lt");
			item.Title   = item.Title.Replace(">","&gt");
			if(item.Title.Trim()=="") item.Title = "无标题";
			item.Content = itemcontent.Replace("<","&lt");
			item.Content = item.Content.Replace(">","&gt");
			item.Sender  = username;
			item.IP      = Request.ServerVariables["remote_addr"].ToString();
			item.Bulletin = (cbx_bulletin==null)?false:cbx_bulletin.Checked;
			item.SysBulletin = (cbx_bulletin==null)?false:cbx_sysbulletin.Checked;
			item.DeskTop = (cbx_DeskTop==null)?false:cbx_DeskTop.Checked;

			item.ItemID = bbs.SendItem(item);
			if(ViewState["filename"]!=null && ViewState["filename"].ToString().Trim()!="")
				item.Attach(ViewState["filename"].ToString());
			try
			{
				Response.Write("<script>if(opener!=null) {opener.location.reload();opener.parent.parent.header.location.reload();location.href='Display.aspx?ItemID="+item.ItemID.ToString()+"&BoardID="+item.BoardID.ToString()+"'}</script>");
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.Message);
				Server.Transfer("../../Error.aspx");
			}
		}

		/// <summary>
		/// 上载文件
		/// </summary>
		private string UploadAtt()
		{
			HtmlForm FrmCompose   = (HtmlForm)this.Page.FindControl("NewItem");
			UDS.Components.BBSClass bbs = new UDS.Components.BBSClass();
			
			string FileName = "";
			string Extension = "";
			string SavedName = "";
			string TotalSavedName = "";
			try
			{
				if(System.IO.Directory.Exists(Server.MapPath(".")+"\\Attachment"))
				{
					for (int i=0;i<FrmCompose.Controls.Count;i++)
					{
						if(FrmCompose.Controls [i].GetType().ToString()=="System.Web.UI.HtmlControls.HtmlInputFile")
						{
							HtmlInputFile hif = ((HtmlInputFile)(FrmCompose.Controls[i]));
							if(hif.PostedFile.FileName.Trim()!="")
							{	
								FileName = System.IO .Path.GetFileName(hif.PostedFile.FileName);
								Extension = System.IO.Path.GetExtension(hif.PostedFile.FileName);

								SavedName = bbs.InsertFile(FileName,Extension).ToString();
								TotalSavedName += SavedName + Extension + ",";
								hif.PostedFile.SaveAs(Server.MapPath(".")+"\\Attachment\\"+SavedName+Extension );
							}
							hif=null;
						}
					}
					return(TotalSavedName);
				}
				else
				{   
					System.IO.Directory.CreateDirectory(Server.MapPath(".")+"\\Attachment");
					UploadAtt();
					return(TotalSavedName);
				}
			}
			catch(Exception ioex)
			{	
				UDS.Components.Error.Log(ioex.ToString());
				Server.Transfer("../../../Error.aspx");
				return(TotalSavedName);
			}

		}
		

		private void btn_UpAtt_Click(object sender, System.EventArgs e)
		{
			string filename = UploadAtt();
			ViewState["filename"] += filename; 
			string savedpath = Request.Url.AbsoluteUri.Substring(0,Request.Url.AbsoluteUri.LastIndexOf("/")) + "/Attachment/";
			string[] arrfilename = filename.Split(',');
			string uploadcontent = ViewState["Content"] + Content.Value;
			switch(ddl_FileType.SelectedItem.Value)
			{
				case "picture":
					for(int i =0;i<arrfilename.Length;i++)
					{
						if(arrfilename[i].Trim()!="")
						{	
							uploadcontent += " [IMG]" + savedpath + arrfilename[i] + "[/IMG]";
							//添加到附件列表中
							lbx_AttList.Items.Add(new ListItem(System.IO.Path.GetFileName(hif.PostedFile.FileName),arrfilename[i]));
						}
					}
					break;
					
				case "rm":
					for(int i =0;i<arrfilename.Length;i++)
					{
						if(arrfilename[i].Trim()!="")
						{	
							uploadcontent += " [RM=320,240]" + savedpath + arrfilename[i] + "[/RM]";
							lbx_AttList.Items.Add(new ListItem(System.IO.Path.GetFileName(hif.PostedFile.FileName),arrfilename[i]));
						}
					}
					break;

				case "mp3":
					
				case "avi":
					for(int i =0;i<arrfilename.Length;i++)
					{
						if(arrfilename[i].Trim()!="")
						{	
							uploadcontent += " [MP=320,240]" + savedpath + arrfilename[i] + "[/MP]";
							lbx_AttList.Items.Add(new ListItem(System.IO.Path.GetFileName(hif.PostedFile.FileName),arrfilename[i]));
						}
					}
					break;
				case "swf":
					for(int i =0;i<arrfilename.Length;i++)
					{
						if(arrfilename[i].Trim()!="")
						{	
							uploadcontent += " [FLASH]" + savedpath + arrfilename[i] + "[/FLASH]";
							lbx_AttList.Items.Add(new ListItem(System.IO.Path.GetFileName(hif.PostedFile.FileName),arrfilename[i]));
						}
					}
					break;
				case "other":
					for(int i =0;i<arrfilename.Length;i++)
					{
						if(arrfilename[i].Trim()!="")
						{	
							uploadcontent += " [ATT]" + savedpath + arrfilename[i] + "[/ATT]";
							lbx_AttList.Items.Add(new ListItem(System.IO.Path.GetFileName(hif.PostedFile.FileName),arrfilename[i]));
						}
					}
					break;
			}
			ViewState["Content"] = uploadcontent; 
			
		}

		private void btn_DelAtt_Click(object sender, System.EventArgs e)
		{
			//得到所选的文件,以数组方式存放
			int i = 0;
			string[] selectedfiles = new string[lbx_AttList.Items.Count];
			foreach(ListItem li in lbx_AttList.Items)
			{
				if(li.Selected)
				{
					selectedfiles[i] = li.Value;
					
				}
				else
					selectedfiles[i] = "null";

				i++;
			}
			
			//删除附件
			for(int j = 0;j<selectedfiles.Length;j++)
			{
				if(selectedfiles[j]!="null")
					System.IO.File.Delete(Server.MapPath(".")+"\\Attachment\\"+selectedfiles[j]);
			}
			//删除附件列表中的item
			for(int j = 0;j<selectedfiles.Length;j++)
			{
				if(selectedfiles[j]!="null")
				{
					foreach(ListItem li in lbx_AttList.Items)
					{
						if(li.Value==selectedfiles[j])
						{
							lbx_AttList.Items.Remove(li);
							break;
						}
					}
				}
				
			}
			
			
		}
	}
}
