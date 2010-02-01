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
	/// ManageBoardMaster 的摘要说明。
	/// </summary>
	public class ManageBoardMaster : System.Web.UI.Page
	{
		private  int boardid;
		protected int classid;

		protected System.Web.UI.WebControls.ListBox lbBoardMasterList;
		protected System.Web.UI.WebControls.ListBox lbRemainStaff;
		protected System.Web.UI.WebControls.Button btn_in;
		protected System.Web.UI.WebControls.HyperLink hlk_Back;
		protected System.Web.UI.WebControls.Button btn_out;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				string staffids = "";

				boardid = (Request.QueryString["BoardID"]==null)?0:Convert.ToInt32(Request.QueryString["BoardID"]);
				classid = (Request.QueryString["classID"]==null)?0:Int32.Parse(Request.QueryString["classID"]);

				ViewState["boardid"] = boardid;
				ViewState["classid"] = classid;

				UDS.Components.Staff staff = new UDS.Components.Staff();
				BBSClass bbs = new BBSClass();
				SqlDataReader dr = null;
				SqlDataReader dr1 = null;
				DataTable dt = new DataTable();
                try
                {
                    dr = bbs.GetBoardMaster();
                    dt = Tools.ConvertDataReaderToDataTable(dr);
                    dt.DefaultView.RowFilter = "board_id=" + boardid;
                    lbBoardMasterList.DataSource = dt.DefaultView;
                    lbBoardMasterList.DataValueField = "staff_id";
                    lbBoardMasterList.DataTextField = "realname";
                    lbBoardMasterList.DataBind();
                    for (int i = 0; i < lbBoardMasterList.Items.Count; i++)
                    {
                        staffids += lbBoardMasterList.Items[i].Value + ",";
                    }
                    if (staffids.Length != 0)
                        staffids = staffids.Substring(0, staffids.Length - 1);
                    dr1 = staff.GetRemainStaff(staffids);
                    lbRemainStaff.DataSource = dr1;
                    lbRemainStaff.DataValueField = "staff_id";
                    lbRemainStaff.DataTextField = "realname";
                    lbRemainStaff.DataBind();
                    dr1.Close();
                }
                catch (Exception ex)
                {
                    UDS.Components.Error.Log(ex.ToString());
                    Server.Transfer("../../Error.aspx");
                }
                finally
                {
                    if (dr1 != null)
                    { dr1.Close(); }
                    if (dr != null)
                    {

                        dr.Close();
                    }
                    
                }

			}
			else
			{
				boardid = Int32.Parse(ViewState["boardid"].ToString());
				classid = Int32.Parse(ViewState["classid"].ToString());
			}

			hlk_Back.DataBind();

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
			this.btn_in.Click += new System.EventHandler(this.btn_in_Click);
			this.btn_out.Click += new System.EventHandler(this.btn_out_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void btn_in_Click(object sender, System.EventArgs e)
		{
			BBSClass bbs = new BBSClass();
			try
			{
				//便历listbox得到选中的带成为板主的人员id
				for(int i=0;i<lbRemainStaff.Items.Count;i++)
				{
					if(lbRemainStaff.Items[i].Selected)
					{
						bbs.AddBoardMaster(boardid,Int32.Parse(lbRemainStaff.Items[i].Value));
					}
				}
				Response.Redirect("ManageBoardMaster.aspx?BoardID="+boardid+"&ClassID="+classid);

			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());
				Server.Transfer("../../Error.aspx");
			}
		}

		private void btn_out_Click(object sender, System.EventArgs e)
		{
			BBSClass bbs = new BBSClass();
			try
			{
				//便历listbox得到选中的的人员id
				for(int i=0;i<lbBoardMasterList.Items.Count;i++)
				{
					if(lbBoardMasterList.Items[i].Selected)
					{
						bbs.DelBoardMaster(boardid,Int32.Parse(lbBoardMasterList.Items[i].Value));
					}
				}
				Response.Redirect("ManageBoardMaster.aspx?BoardID="+boardid+"&ClassID="+classid);

			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());
				Server.Transfer("../../Error.aspx");
			}
		}
	}
}
