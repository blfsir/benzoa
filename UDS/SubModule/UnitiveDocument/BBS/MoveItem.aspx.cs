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

namespace UDS.SubModule.UnitiveDocument.BBS
{
	/// <summary>
	/// MoveItem ��ժҪ˵����
	/// </summary>
	public class MoveItem : System.Web.UI.Page
	{
		private  int itemid;

		protected System.Web.UI.HtmlControls.HtmlInputButton cmdOK;
		protected System.Web.UI.WebControls.Literal ltMessage;
		protected System.Web.UI.WebControls.DropDownList ddlBoardList;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				itemid = (Request.QueryString["ItemID"]==null)?0:Int32.Parse(Request.QueryString["ItemID"].ToString());
				ViewState["itemid"] = itemid;

				BBSClass bbsclass = new BBSClass();
				try
				{
					ddlBoardList.DataSource = bbsclass.GetAllBoard();
					ddlBoardList.DataTextField = "board_name";
					ddlBoardList.DataValueField = "board_id";
					ddlBoardList.DataBind();
				}
				catch(Exception ex)
				{
					UDS.Components.Error.Log(ex.ToString());
					Server.Transfer("../../Error.aspx");
				}
			}
			else
			{
				itemid = Int32.Parse(ViewState["itemid"].ToString());
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
			this.cmdOK.ServerClick += new System.EventHandler(this.cmdOK_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdOK_ServerClick(object sender, System.EventArgs e)
		{
			BBSClass bbs = new BBSClass();
			BBSForumItem olditem = new BBSForumItem();
			BBSForumItem newitem = new BBSForumItem();
			olditem.ItemID = itemid;
			newitem.BoardID = Int32.Parse(ddlBoardList.SelectedItem.Value);
			try
			{
				bbs.MoveBoardItem(olditem,newitem);
				ddlBoardList.Visible = false;
				cmdOK.Visible = false;
				ltMessage.Visible = true;
				ltMessage.Text = "�ƶ��ɹ���";

			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());
				Server.Transfer("../../Error.aspx");
			}
			
		}
	}
}
