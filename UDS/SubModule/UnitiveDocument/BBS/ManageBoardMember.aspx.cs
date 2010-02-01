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
	/// ManageBoardMember 的摘要说明。
	/// </summary>
	public class ManageBoardMember : System.Web.UI.Page
	{
		private  int boardid;
		protected int classid;
		protected System.Web.UI.WebControls.ListBox lbBoardMemberList;
		protected System.Web.UI.WebControls.ListBox lbRemainStaffsList;
		protected System.Web.UI.WebControls.Button btn_in;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
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
                    dr = bbs.GetBoardMember();
                    dt = Tools.ConvertDataReaderToDataTable(dr);
                    dt.DefaultView.RowFilter = "board_id=" + boardid;
                    lbBoardMemberList.DataSource = dt.DefaultView;
                    lbBoardMemberList.DataValueField = "staff_id";
                    lbBoardMemberList.DataTextField = "realname";
                    lbBoardMemberList.DataBind();
                    for (int i = 0; i < lbBoardMemberList.Items.Count; i++)
                    {
                        staffids += lbBoardMemberList.Items[i].Value + ",";
                    }
                    if (staffids.Length != 0)
                        staffids = staffids.Substring(0, staffids.Length - 1);
                    dr1 = staff.GetRemainStaff(staffids);
                    lbRemainStaffsList.DataSource = dr1;
                    lbRemainStaffsList.DataValueField = "staff_id";
                    lbRemainStaffsList.DataTextField = "realname";
                    lbRemainStaffsList.DataBind();
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
				classid = Int32.Parse(ViewState["classid"].ToString());
				boardid = Int32.Parse(ViewState["boardid"].ToString());
			}
			HyperLink1.DataBind();
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
				for(int i=0;i<lbRemainStaffsList.Items.Count;i++)
				{
					if(lbRemainStaffsList.Items[i].Selected)
					{
						bbs.SetupBoardMember(boardid,Int32.Parse(lbRemainStaffsList.Items[i].Value));
					}
				}
				Response.Redirect("ManageBoardMember.aspx?BoardID="+boardid+"&ClassID="+classid);

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
			BBSBoardmember member = new BBSBoardmember();
			try
			{
				//便历listbox得到选中的的人员id
				for(int i=0;i<lbBoardMemberList.Items.Count;i++)
				{
					if(lbBoardMemberList.Items[i].Selected)
					{
						member.BoardID = boardid;
						member.StaffID = Int32.Parse(lbBoardMemberList.Items[i].Value);
						bbs.DeleteBoardMember(member);
					}
				}
				Response.Redirect("ManageBoardMember.aspx?BoardID="+boardid+"&ClassID="+classid);

			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());
				Server.Transfer("../../Error.aspx");
			}
		}
	}
}
