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
	/// Display 的摘要说明。
	/// </summary>
	public class Display : System.Web.UI.Page
	{
		private  int itemid;//贴子ID
		private  int boardid;//板块id
		protected  bool isboardmaster;//是本版斑竹
		protected  string username;//用户名
		protected System.Web.UI.WebControls.Literal sendtime;
		protected System.Web.UI.WebControls.Literal browsetime;
		protected System.Web.UI.WebControls.Literal sendman;
		protected System.Web.UI.WebControls.Literal replaytimes;
		protected System.Web.UI.WebControls.Literal replaytime;
		protected System.Web.UI.WebControls.Literal replayer;
		protected System.Web.UI.WebControls.Repeater replaylist;
		protected System.Web.UI.HtmlControls.HtmlInputButton cmdOK;
		protected System.Web.UI.HtmlControls.HtmlTextArea Content;
		protected System.Web.UI.HtmlControls.HtmlTableCell itemcontent;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Panel pnlReplayOp;
		protected System.Web.UI.HtmlControls.HtmlInputFile hif;
		protected System.Web.UI.WebControls.DropDownList ddl_FileType;
		protected System.Web.UI.WebControls.Button btn_UpAtt;
		protected System.Web.UI.WebControls.CheckBox cbx_DeskTop;
		protected System.Web.UI.WebControls.CheckBox cbx_sysBulletin;
		protected System.Web.UI.WebControls.CheckBox cbx_boardBulletin;

        protected System.Web.UI.WebControls.Button btn_DelAtt;
        protected System.Web.UI.WebControls.ListBox lbx_AttList;
	
		protected string title = "";
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
                username = Server.UrlDecode(Request.Cookies["UserName"].Value);
				itemid = (Request.QueryString["ItemID"]==null)?0:Int32.Parse(Request.QueryString["ItemID"].ToString());
				boardid = (Request.QueryString["BoardID"]==null)?0:Int32.Parse(Request.QueryString["BoardID"].ToString());
				
				ViewState["username"] = username;
				ViewState["itemid"] = itemid;
				ViewState["boardid"] = boardid;
				ViewState["isboardmaster"] = isboardmaster;

				BBSClass bbsclass = new BBSClass();
				BBSForumItem bbsforumitem = new BBSForumItem();
				bbsforumitem.ItemID = itemid;
				SqlDataReader dr = null;
				dr = bbsclass.ReadBBSForumItem(bbsforumitem);

				//判断是否是斑竹
				isboardmaster = bbsclass.IsBoardMaster(boardid,username);
				if(isboardmaster)
					cbx_boardBulletin.Visible = true;
				else
					cbx_boardBulletin.Visible = false;
				
				if(Request.Cookies["UDSBBSAdmin"]!=null)
				{
				
					if(Request.Cookies["UDSBBSAdmin"].Value=="1")
						cbx_sysBulletin.Visible = true;
					else
						cbx_sysBulletin.Visible = false;
				}
				else
				{
					cbx_sysBulletin.Visible = false;
					cbx_sysBulletin.Visible = false;
				}

                try
                {
                    while (dr.Read())
                    {
                        this.title = lblTitle.Text = dr["title"].ToString();
                        sendtime.Text = dr["send_time"].ToString();
                        browsetime.Text = dr["hit_times"].ToString();
                        replaytimes.Text = dr["replay_times"].ToString();
                        sendman.Text = dr["sender"].ToString();
                        //判断是否是系统公告，如果是只有管理员能够操作
                        if (Boolean.Parse(dr["sysbulletin"].ToString()))
                        {
                            if (Request.Cookies["UDSBBSAdmin"] != null)
                            {
                                if (Request.Cookies["UDSBBSAdmin"].Value == "1")
                                {
                                    itemcontent.InnerHtml += "<b>操作：</b><a href=javascript:window.open('DeleteItem.aspx?ItemID=" + itemid + "&BoardID=" + boardid + "','_self','');>删除此贴</a>|<a href='MoveItem.aspx?ItemID=" + itemid + "'>移动帖子</a><br><hr color='#C0C0C0' size='1'>";
                                    cbx_DeskTop.Visible = true;
                                    cbx_sysBulletin.Checked = true;
                                    if (Boolean.Parse(dr["DeskTop"].ToString()))
                                    {
                                        cbx_DeskTop.Checked = true;
                                    }
                                    else
                                        cbx_DeskTop.Checked = false;
                                }
                                else
                                {
                                    cbx_sysBulletin.Checked = false;
                                }
                            }

                        }
                        else
                        {
                            if ((Request.Cookies["UDSBBSAdmin"].Value == "1") || (isboardmaster))
                            {
                                itemcontent.InnerHtml += "<b>操作：</b><a href=javascript:window.open('DeleteItem.aspx?ItemID=" + itemid + "&BoardID=" + boardid + "','_self','');>删除此贴</a>|<a href='MoveItem.aspx?ItemID=" + itemid + "'>移动帖子</a><br><hr color='#C0C0C0' size='1'>";
                                cbx_DeskTop.Visible = false;

                                if (Boolean.Parse(dr["bulletin"].ToString()))
                                {
                                    cbx_boardBulletin.Checked = true;
                                }
                                else
                                {
                                    cbx_boardBulletin.Checked = false;
                                }

                            }

                        }

                        itemcontent.InnerHtml += FormatTxt(UBB.txtMessage(dr["content"].ToString()));
                    }
                }
                finally
                {
                     if (dr != null){dr.Close();}
                }
				BindData();	

			}
			else
			{
				username = ViewState["username"].ToString();
				itemid = Int32.Parse(ViewState["itemid"].ToString());
				boardid = Int32.Parse(ViewState["boardid"].ToString());
				isboardmaster = Boolean.Parse(ViewState["isboardmaster"].ToString());
			}

			

		}

		private void BindData()
		{
			BBSClass bbs = new BBSClass();
			BBSForumItem item = new BBSForumItem();
			Database db = new Database();
			SqlDataReader dr = null;
            try
            {
                item.ItemID = itemid;
                dr = bbs.ReadBBSForumItemReplay(item);
                replaylist.DataSource = dr;
                replaylist.DataBind();

                lbx_AttList.Items.Clear();

            }
            finally
            {
               
                if (dr != null)
                {

                    dr.Close();
                }
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
			this.cbx_DeskTop.CheckedChanged += new System.EventHandler(this.cbx_DeskTop_CheckedChanged);
			this.cbx_boardBulletin.CheckedChanged += new System.EventHandler(this.cbx_boardBulletin_CheckedChanged);
			this.cbx_sysBulletin.CheckedChanged += new System.EventHandler(this.cbx_sysBulletin_CheckedChanged);
			this.Load += new System.EventHandler(this.Page_Load);
            this.btn_UpAtt.Click +=new EventHandler(btn_UpAtt_Click);
            this.btn_DelAtt.Click += new System.EventHandler(this.btn_DelAtt_Click);

		}
		#endregion


		protected void cmdOK_ServerClick(object sender, System.EventArgs e)
		{
			BBSClass bbsclass = new BBSClass();
			BBSReplay replay = new BBSReplay();
			string replaycontent = ViewState["Content"] + Content.Value;
			replay.ItemID = itemid;
			replay.Replayer = username;
			replay.ReplayIP = Request.ServerVariables["remote_addr"].ToString();
			replay.Content = replaycontent.Replace("<","&lt");
			replay.Content = replay.Content.Replace(">","&gt");
			try
			{
				replay.ReplayId = bbsclass.ReplayItem(replay);
				if(ViewState["filename"]!=null && ViewState["filename"].ToString().Trim()!="")
					replay.Attach(ViewState["filename"].ToString());
				BindData();
				Content.Value = "";
				ViewState["Content"] = "";
				ViewState["filename"] = "";
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());
				Server.Transfer("../../Error.aspx");
			}
			
		}

		protected void DelReplay(object sender,System.EventArgs e)
		{
			BBSClass bbsclass = new BBSClass();
			BBSReplay replay = new BBSReplay();
			replay.ReplayId = Int32.Parse(((LinkButton)sender).CommandArgument.ToString());
			replay.ItemID = itemid;
			try
			{
				replay.DelAttachment(Server.MapPath(".")+"\\Attachment\\");
				bbsclass.DelReplay(replay);
				BindData();
				Content.Value = "";
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());
				Server.Transfer("../../Error.aspx");
			}
		}

		/// <summary>
		/// 上载文件
		/// </summary>
		private string UploadAtt()
		{
			HtmlForm FrmCompose   = (HtmlForm)this.Page.FindControl("Display");
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


		protected string FormatTxt(string content)
		{
			return(content.Replace(((char)13).ToString(),"<br>"));

		}

		protected void btn_UpAtt_Click(object sender, System.EventArgs e)
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
                            lbx_AttList.Items.Add(new ListItem(System.IO.Path.GetFileName(hif.PostedFile.FileName), arrfilename[i]));
						}
					}
					break;
					
				case "rm":
					for(int i =0;i<arrfilename.Length;i++)
					{
						if(arrfilename[i].Trim()!="")
						{	
							uploadcontent += " [RM=320,240]" + savedpath + arrfilename[i] + "[/RM]";
                            lbx_AttList.Items.Add(new ListItem(System.IO.Path.GetFileName(hif.PostedFile.FileName), arrfilename[i]));
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
                            lbx_AttList.Items.Add(new ListItem(System.IO.Path.GetFileName(hif.PostedFile.FileName), arrfilename[i]));
						}
					}
					break;
				case "swf":
					for(int i =0;i<arrfilename.Length;i++)
					{
						if(arrfilename[i].Trim()!="")
						{	
							uploadcontent += " [FLASH]" + savedpath + arrfilename[i] + "[/FLASH]";
                            lbx_AttList.Items.Add(new ListItem(System.IO.Path.GetFileName(hif.PostedFile.FileName), arrfilename[i]));
						}
					}
					break;
				case "other":
					for(int i =0;i<arrfilename.Length;i++)
					{
						if(arrfilename[i].Trim()!="")
						{	
							uploadcontent += " [ATT]" + savedpath + arrfilename[i] + "[/ATT]";
                            lbx_AttList.Items.Add(new ListItem(System.IO.Path.GetFileName(hif.PostedFile.FileName), arrfilename[i]));
						}
					}
					break;
			}
			ViewState["Content"] = uploadcontent; 
		}

		private void cbx_sysBulletin_CheckedChanged(object sender, System.EventArgs e)
		{
			UDS.Components.BBSClass bbs = new UDS.Components.BBSClass();
			BBSForumItem item = new BBSForumItem();
			item.ItemID = itemid;
			bbs.ReadBBSForumItemStruct(item);

			if(((CheckBox)sender).Checked)
			{
				item.SysBulletin = true;
			}
			else
			{
				item.SysBulletin = false;
				item.DeskTop = false;
				cbx_DeskTop.Enabled = false;

			}

			bbs.ModBBSForumItem(item);
		}

		private void cbx_boardBulletin_CheckedChanged(object sender, System.EventArgs e)
		{
			UDS.Components.BBSClass bbs = new UDS.Components.BBSClass();
			BBSForumItem item = new BBSForumItem();
			item.ItemID = itemid;
			bbs.ReadBBSForumItemStruct(item);

			if(((CheckBox)sender).Checked)
			{
				item.Bulletin = true;
			}
			else
			{
				item.Bulletin = false;
			}

			bbs.ModBBSForumItem(item);
		}

		private void cbx_DeskTop_CheckedChanged(object sender, System.EventArgs e)
		{
			UDS.Components.BBSClass bbs = new UDS.Components.BBSClass();
			BBSForumItem item = new BBSForumItem();
			item.ItemID = itemid;
			bbs.ReadBBSForumItemStruct(item);

			if(((CheckBox)sender).Checked)
			{
				item.DeskTop = true;
			}
			else
				item.DeskTop = false;

			bbs.ModBBSForumItem(item);
		}

        private void btn_DelAtt_Click(object sender, System.EventArgs e)
        {
            //得到所选的文件,以数组方式存放
            int i = 0;
            string[] selectedfiles = new string[lbx_AttList.Items.Count];
            foreach (ListItem li in lbx_AttList.Items)
            {
                if (li.Selected)
                {
                    selectedfiles[i] = li.Value;

                }
                else
                    selectedfiles[i] = "null";

                i++;
            }

            //删除附件
            for (int j = 0; j < selectedfiles.Length; j++)
            {
                if (selectedfiles[j] != "null")
                    System.IO.File.Delete(Server.MapPath(".") + "\\Attachment\\" + selectedfiles[j]);
            }
            //删除附件列表中的item
            for (int j = 0; j < selectedfiles.Length; j++)
            {
                if (selectedfiles[j] != "null")
                {
                    foreach (ListItem li in lbx_AttList.Items)
                    {
                        if (li.Value == selectedfiles[j])
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

