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
	/// DeleteItem ��ժҪ˵����
	/// </summary>
	public class DeleteItem : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMessage;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			int itemid = (Request.QueryString["ItemID"]==null)?0:Int32.Parse(Request.QueryString["ItemID"].ToString());
			int boardid = (Request.QueryString["BoardID"]==null)?0:Int32.Parse(Request.QueryString["BoardID"].ToString());

			BBSClass bbs = new BBSClass();
			BBSForumItem item = new BBSForumItem();
			
			item.ItemID = itemid;
			try
			{
				item.DelAttachment(Server.MapPath(".")+"\\Attachment\\");
				bbs.DelItem(item);
				Response.Write("<script>alert('ɾ���ɹ�');opener.location.reload();close();</script>");
				
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
