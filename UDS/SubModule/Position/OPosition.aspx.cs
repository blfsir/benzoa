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


namespace UDS.SubModule.Position
{
	/// <summary>
	/// OPosition 的摘要说明。
	/// </summary>
	public class OPosition : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label title_add;
		protected System.Web.UI.WebControls.Label addPositionName;
		protected System.Web.UI.WebControls.Label title_del;
		protected System.Web.UI.WebControls.Label delPositionName;
		protected System.Web.UI.WebControls.TextBox txtPositionName;
		protected System.Web.UI.WebControls.TextBox txtAPositionName;
		protected System.Web.UI.WebControls.TextBox txtAPositionRemark;
		protected System.Web.UI.WebControls.TextBox txtMPositionRemark;
		protected System.Web.UI.WebControls.TextBox txtOnDutyTime;
		protected System.Web.UI.WebControls.TextBox txtOffDutyTime;
		protected System.Web.UI.HtmlControls.HtmlInputButton cmdAdd;
		protected System.Web.UI.HtmlControls.HtmlInputButton cmdDelete;
		protected System.Web.UI.HtmlControls.HtmlInputButton cmdModify;
		protected System.Web.UI.WebControls.RegularExpressionValidator rev_OnDutyTime;
		protected System.Web.UI.WebControls.RegularExpressionValidator rev_uOnDutyTime;
		protected System.Web.UI.WebControls.RegularExpressionValidator rev_OffDutyTime;
		protected System.Web.UI.WebControls.RegularExpressionValidator rev_uOffDutyTime;

		private static int PositionID;//职位id
		private static string PositionName;//职位名称
		private static string PositionDescription;
		private static string OnDutyTime = "";
		private static int DisplayType;
		protected System.Web.UI.WebControls.LinkButton lbAddPosition;
		protected System.Web.UI.WebControls.LinkButton lbDeletePosition;
		protected System.Web.UI.WebControls.LinkButton lbModifyPosition;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD1;
		protected System.Web.UI.HtmlControls.HtmlTable tabModify;
		protected System.Web.UI.HtmlControls.HtmlGenericControl FONT1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl FONT2;
		protected System.Web.UI.HtmlControls.HtmlTable tabAdd;
		protected System.Web.UI.HtmlControls.HtmlTable tabDelete;
		protected System.Web.UI.WebControls.TextBox txtuOnDutyTime;
		protected System.Web.UI.WebControls.TextBox txtuOffDutyTime;
		protected System.Web.UI.WebControls.Literal litAMessage;
		protected System.Web.UI.WebControls.Literal litMMessage;
		protected System.Web.UI.WebControls.LinkButton lbMovePosition;
		protected System.Web.UI.WebControls.Label lblPosition;
		protected System.Web.UI.WebControls.ListBox lstDeparment;
		protected System.Web.UI.WebControls.Button cmdMove;
		protected System.Web.UI.HtmlControls.HtmlTable tabMove;
		protected System.Web.UI.WebControls.Button cmdModifyReturn;
		protected System.Web.UI.WebControls.Button cmdDeleteReturn;
		protected System.Web.UI.WebControls.Button cmdAddReturn;
		protected System.Web.UI.WebControls.Button cmdMoveReturn;//上班时间
		private static string OffDutyTime = "";//下班时间
        	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				txtPositionName.Text = "";
				OnDutyTime = "";
				OffDutyTime = "";
				
				SqlDataReader dr=null;
                try
                {
                    //得到职位ID
                    PositionID = (Request.QueryString["PositionID"] == null ? 0 : Int32.Parse(Request.QueryString["PositionID"].ToString()));

                    UDS.Components.Position dp = new UDS.Components.Position();

                    dr = dp.GetPositionInfo(PositionID);

                    if (dr.Read())
                    {
                        PositionName = dr["Position_Name"].ToString();
                        PositionDescription = dr["Position_Description"].ToString();
                    }


                    dr.Close();

                    dr = dp.GetPositionDutyTime(PositionID);
                    if (dr.Read())
                    {
                        OnDutyTime = DateTime.Parse(dr["OnDutyTime"].ToString()).ToShortTimeString();
                        OffDutyTime = DateTime.Parse(dr["OffDutyTime"].ToString()).ToShortTimeString();
                    }
                }
                finally
                {
                    
                    if (dr != null)
                    {

                        dr.Close();
                    }
                }
				
				if(Request.QueryString["DisplayType"] !=null)
					DisplayType = Int32.Parse(Request.QueryString["DisplayType"].ToString());
				else
					DisplayType = 0;
				// 显示不同表格
				switch(DisplayType)
				{
					case 0:
						tabAdd.Visible = true;
						tabDelete.Visible = false;
						tabModify.Visible = false;
						tabMove.Visible =false;

						lbAddPosition.BackColor = Color.FromArgb(0xf0f0f0);
						lbDeletePosition.BackColor = Color.FromArgb(0xffffff);
						lbModifyPosition.BackColor = Color.FromArgb(0xffffff);
						lbMovePosition.BackColor  = Color.FromArgb(0xffffff);

						addPositionName.Text = PositionName;
						break;
					case 1:
						tabAdd.Visible = false;
						tabDelete.Visible = true;
						tabModify.Visible = false;
						tabMove.Visible =false;
						lbAddPosition.BackColor = Color.FromArgb(0xffffff);
						lbDeletePosition.BackColor = Color.FromArgb(0xf0f0f0);
						lbModifyPosition.BackColor = Color.FromArgb(0xffffff);
						lbMovePosition.BackColor  = Color.FromArgb(0xffffff);

						delPositionName.Text  = PositionName;
						break;
					case 2:
						tabAdd.Visible = false;
						tabDelete.Visible = false;
						tabModify.Visible = true;
						tabMove.Visible =false;

						txtPositionName.Text = PositionName;
						txtMPositionRemark.Text = PositionDescription;

						lbAddPosition.BackColor = Color.FromArgb(0xffffff);
						lbDeletePosition.BackColor = Color.FromArgb(0xffffff);
						lbModifyPosition.BackColor = Color.FromArgb(0xf0f0f0);
						lbMovePosition.BackColor  = Color.FromArgb(0xffffff);

						txtuOnDutyTime.Text  = OnDutyTime;
						txtuOffDutyTime.Text  = OffDutyTime;
						break;
					case 3:
						tabAdd.Visible = false;
						tabDelete.Visible = false;
						tabModify.Visible = false;
						tabMove.Visible =true;

						lbAddPosition.BackColor = Color.FromArgb(0xffffff);
						lbDeletePosition.BackColor = Color.FromArgb(0xffffff);
						lbModifyPosition.BackColor = Color.FromArgb(0xffffff);
						lbMovePosition.BackColor  = Color.FromArgb(0xf0f0f0);

						lblPosition.Text = PositionName;
						BindPosition();
						break;
					default:
						break;
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
			this.lbAddPosition.Click += new System.EventHandler(this.lbAddPosition_Click);
			this.lbDeletePosition.Click += new System.EventHandler(this.lbDeletePosition_Click);
			this.lbModifyPosition.Click += new System.EventHandler(this.lbModifyPosition_Click);
			this.lbMovePosition.Click += new System.EventHandler(this.lbMovePosition_Click);
			this.cmdAddReturn.Click += new System.EventHandler(this.cmdReturn_Click);
			this.cmdDeleteReturn.Click += new System.EventHandler(this.cmdReturn_Click);
			this.cmdModifyReturn.Click += new System.EventHandler(this.cmdReturn_Click);
			this.cmdMove.Click += new System.EventHandler(this.cmdMove_Click);
			this.cmdMoveReturn.Click += new System.EventHandler(this.cmdReturn_Click);
			this.cmdAdd.ServerClick += new System.EventHandler(this.cmdAdd_ServerClick);
			this.cmdDelete.ServerClick += new System.EventHandler(this.cmdDelete_ServerClick);
			this.cmdModify.ServerClick += new System.EventHandler(this.cmdModify_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindPosition()
		{
			UDS.Components.Database db = new UDS.Components.Database();
			SqlDataReader dr_department = null;
            try
            {
                db.RunProc("sp_GetAllPosition", out dr_department);
                lstDeparment.DataSource = dr_department;
                lstDeparment.DataTextField = "Position_Name";
                lstDeparment.DataValueField = "Position_ID";
                lstDeparment.DataBind();
            }
            finally
            {
                db.Close();
                dr_department.Close();
            }
		}

		private void cmdAdd_ServerClick(object sender,System.EventArgs e)
		{
			if(txtAPositionName.Text.Trim()!="")
			{
				long NewDeptID = UDS.Components.Position.Add(PositionID,txtAPositionName.Text,txtAPositionRemark.Text);
				if(PositionID>0)
				{
					if((txtOnDutyTime.Text.Trim()!="")&&(txtOffDutyTime.Text.Trim()!=""))
					{
						if(UDS.Components.Position.AddDutyTime(NewDeptID,DateTime.Parse(txtOnDutyTime.Text),DateTime.Parse(txtOffDutyTime.Text))!=0)
							Response.Write("<script laguage='javascript'>alert('添加职位出错！');</script>");
						else
							Response.Redirect("ListView.aspx?PositionID=" +PositionID + "&Refresh=1");
					}
					else
						Response.Redirect("ListView.aspx?PositionID=" +PositionID + "&Refresh=1");
				}
				else
					Response.Write("<script laguage='javascript'>alert('添加职位出错！');</script>");
			}
			else
			{
				litAMessage.Text ="请输入职位";
			}
		}	

		private void cmdDelete_ServerClick(object sender,System.EventArgs e)
		{
			switch(UDS.Components.Position.Delete(PositionID))
			{
				case 0:
					Response.Redirect("ListView.aspx?PositionID="+PositionID+"&Refresh=1");
					break;
				case -1:
					Response.Write("<script laguage='javascript'>alert('有下级职位，不能删除！');</script>");
					break;
				case -2:
					Response.Write("<script laguage='javascript'>alert('职位有成员，不能删除！');</script>");
					break;
				default:
					break;
			}

		}

		private void cmdModify_ServerClick(object sender,System.EventArgs e)
		{
			if(txtPositionName.Text.Trim()!="")
			{
				if((UDS.Components.Position.Modify(PositionID,txtPositionName.Text,txtMPositionRemark.Text)==0))
				{
					if((txtuOnDutyTime.Text.Trim()!="")&&(txtuOffDutyTime.Text.Trim()!=""))
					{
						if((UDS.Components.Position.UpdateDutyTime(PositionID,DateTime.Parse(txtuOnDutyTime.Text),DateTime.Parse(txtuOffDutyTime.Text))!=0))
						{
							Response.Write("<script laguage='javascript'>alert('修改职位出错！');</script>");
							return;
						}
					}
					else
					{
						UDS.Components.Position.DeleteDutyTime(PositionID);
					}
					Response.Redirect("ListView.aspx?PositionID="+PositionID+"&Refresh=1");
				}
				else
					Response.Write("<script laguage='javascript'>alert('修改职位出错！');</script>");
			}
			else
				litMMessage.Text ="请输入职位";
		}

		private void Operation_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void lbAddPosition_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("OPosition.aspx?PositionID=" + PositionID.ToString() + "&DisplayType=0");
		}

		private void lbDeletePosition_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("OPosition.aspx?PositionID=" + PositionID.ToString() + "&DisplayType=1");
		}

		private void lbModifyPosition_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("OPosition.aspx?PositionID=" + PositionID.ToString() + "&DisplayType=2");
		}

		private void lbMovePosition_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("OPosition.aspx?PositionID=" + PositionID.ToString() + "&DisplayType=3");
		}

		private void cmdMove_Click(object sender, System.EventArgs e)
		{
			UDS.Components.Position dept = new UDS.Components.Position();

			switch(dept.MoveDeparement(PositionID,Int32.Parse(lstDeparment.Items[lstDeparment.SelectedIndex].Value)))
			{
				case 0:
					Response.Write("<script laguage='javascript'>alert('移动到" + lstDeparment.Items[lstDeparment.SelectedIndex].Text +" 职位成功！');</script>");
					Response.Redirect("ListView.aspx?PositionID="+PositionID+"&Refresh=1");
					break;
				case -1:
					Response.Write("<script laguage='javascript'>alert('不能移动到下级职位！');</script>");
					break;
				default:
					break;
			}

		}

		private void cmdReturn_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("Listview.aspx?PositionID=" + PositionID.ToString());
		}

	
	}
}
