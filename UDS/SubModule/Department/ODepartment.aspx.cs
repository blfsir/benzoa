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


namespace UDS.SubModule.Department
{
	/// <summary>
	/// ODepartment 的摘要说明。
	/// </summary>
	public class ODepartment : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label title_add;
		protected System.Web.UI.WebControls.Label addDepartmentName;
		protected System.Web.UI.WebControls.Label title_del;
		protected System.Web.UI.WebControls.Label delDepartmentName;
		protected System.Web.UI.WebControls.TextBox txtDepartmentName;
		protected System.Web.UI.WebControls.TextBox txtADepartmentName;
		protected System.Web.UI.WebControls.TextBox txtADepartmentRemark;
		protected System.Web.UI.WebControls.TextBox txtMDepartmentRemark;
		protected System.Web.UI.WebControls.TextBox txtOnDutyTime;
		protected System.Web.UI.WebControls.TextBox txtOffDutyTime;
		protected System.Web.UI.HtmlControls.HtmlInputButton cmdAdd;
		protected System.Web.UI.HtmlControls.HtmlInputButton cmdDelete;
		protected System.Web.UI.HtmlControls.HtmlInputButton cmdModify;
		protected System.Web.UI.WebControls.RegularExpressionValidator rev_OnDutyTime;
		protected System.Web.UI.WebControls.RegularExpressionValidator rev_uOnDutyTime;
		protected System.Web.UI.WebControls.RegularExpressionValidator rev_OffDutyTime;
		protected System.Web.UI.WebControls.RegularExpressionValidator rev_uOffDutyTime;

		private static int DeptID;//部门id
		private static string DepartmentName;//部门名称
		private static string DepartmentDescription;
		private static string OnDutyTime = "";
		private static int DisplayType;
		protected System.Web.UI.WebControls.LinkButton lbAddDepartment;
		protected System.Web.UI.WebControls.LinkButton lbDeleteDepartment;
		protected System.Web.UI.WebControls.LinkButton lbModifyDepartment;
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
		protected System.Web.UI.WebControls.LinkButton lbMoveDepartment;
		protected System.Web.UI.WebControls.Label lblDepartment;
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
				txtDepartmentName.Text = "";
				OnDutyTime = "";
				OffDutyTime = "";
				
				SqlDataReader dr;

				//得到部门ID
				DeptID=(Request.QueryString["DeptID"]==null?0:Int32.Parse(Request.QueryString["DeptID"].ToString()));
				
				UDS.Components.Department dp = new UDS.Components.Department();

				dr = dp.GetDepartmentInfo(DeptID);

				if(dr.Read())
				{
					DepartmentName = dr["Department_Name"].ToString();
					DepartmentDescription = dr["Department_Description"].ToString();
				}

				dr.Close();
				
				dr = dp.GetDepartmentDutyTime(DeptID);
				if(dr.Read())
				{
					OnDutyTime = DateTime.Parse(dr["OnDutyTime"].ToString()).ToShortTimeString();
					OffDutyTime = DateTime.Parse(dr["OffDutyTime"].ToString()).ToShortTimeString();
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

						lbAddDepartment.BackColor = Color.FromArgb(0xf0f0f0);
						lbDeleteDepartment.BackColor = Color.FromArgb(0xffffff);
						lbModifyDepartment.BackColor = Color.FromArgb(0xffffff);
						lbMoveDepartment.BackColor  = Color.FromArgb(0xffffff);

						addDepartmentName.Text = DepartmentName;
						break;
					case 1:
						tabAdd.Visible = false;
						tabDelete.Visible = true;
						tabModify.Visible = false;
						tabMove.Visible =false;
						lbAddDepartment.BackColor = Color.FromArgb(0xffffff);
						lbDeleteDepartment.BackColor = Color.FromArgb(0xf0f0f0);
						lbModifyDepartment.BackColor = Color.FromArgb(0xffffff);
						lbMoveDepartment.BackColor  = Color.FromArgb(0xffffff);

						delDepartmentName.Text  = DepartmentName;
						break;
					case 2:
						tabAdd.Visible = false;
						tabDelete.Visible = false;
						tabModify.Visible = true;
						tabMove.Visible =false;

						txtDepartmentName.Text = DepartmentName;
						txtMDepartmentRemark.Text = DepartmentDescription;

						lbAddDepartment.BackColor = Color.FromArgb(0xffffff);
						lbDeleteDepartment.BackColor = Color.FromArgb(0xffffff);
						lbModifyDepartment.BackColor = Color.FromArgb(0xf0f0f0);
						lbMoveDepartment.BackColor  = Color.FromArgb(0xffffff);

						txtuOnDutyTime.Text  = OnDutyTime;
						txtuOffDutyTime.Text  = OffDutyTime;
						break;
					case 3:
						tabAdd.Visible = false;
						tabDelete.Visible = false;
						tabModify.Visible = false;
						tabMove.Visible =true;

						lbAddDepartment.BackColor = Color.FromArgb(0xffffff);
						lbDeleteDepartment.BackColor = Color.FromArgb(0xffffff);
						lbModifyDepartment.BackColor = Color.FromArgb(0xffffff);
						lbMoveDepartment.BackColor  = Color.FromArgb(0xf0f0f0);

						lblDepartment.Text = DepartmentName;
						BindDepartment();
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
			this.lbAddDepartment.Click += new System.EventHandler(this.lbAddDepartment_Click);
			this.lbDeleteDepartment.Click += new System.EventHandler(this.lbDeleteDepartment_Click);
			this.lbModifyDepartment.Click += new System.EventHandler(this.lbModifyDepartment_Click);
			this.lbMoveDepartment.Click += new System.EventHandler(this.lbMoveDepartment_Click);
			this.cmdAdd.ServerClick += new System.EventHandler(this.cmdAdd_ServerClick);
			this.cmdAddReturn.Click += new System.EventHandler(this.cmdReturn_Click);
			this.cmdDeleteReturn.Click += new System.EventHandler(this.cmdReturn_Click);
			this.cmdModifyReturn.Click += new System.EventHandler(this.cmdReturn_Click);
			this.cmdMove.Click += new System.EventHandler(this.cmdMove_Click);
			this.cmdMoveReturn.Click += new System.EventHandler(this.cmdReturn_Click);
			this.cmdDelete.ServerClick += new System.EventHandler(this.cmdDelete_ServerClick);
			this.cmdModify.ServerClick += new System.EventHandler(this.cmdModify_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindDepartment()
		{
			UDS.Components.Database db = new UDS.Components.Database();
			SqlDataReader dr_department = null;
			db.RunProc("sp_GetAllDepartment",out dr_department);
			lstDeparment.DataSource = dr_department;
			lstDeparment.DataTextField = "Department_Name";
			lstDeparment.DataValueField = "Department_ID";			
			lstDeparment.DataBind();
		}

		private void cmdAdd_ServerClick(object sender,System.EventArgs e)
		{
			if(txtADepartmentName.Text.Trim()!="")
			{
				long NewDeptID = UDS.Components.Department.Add(DeptID,txtADepartmentName.Text,txtADepartmentRemark.Text);
				if(DeptID>0)
				{
					if((txtOnDutyTime.Text.Trim()!="")&&(txtOffDutyTime.Text.Trim()!=""))
					{
						if(UDS.Components.Department.AddDutyTime(NewDeptID,DateTime.Parse(txtOnDutyTime.Text),DateTime.Parse(txtOffDutyTime.Text))!=0)
							Response.Write("<script laguage='javascript'>alert('添加部门出错！');</script>");
						else
							Response.Redirect("ListView.aspx?DeptID=" +DeptID + "&Refresh=1");
					}
					else
						Response.Redirect("ListView.aspx?DeptID=" +DeptID + "&Refresh=1");
				}
				else
					Response.Write("<script laguage='javascript'>alert('添加部门出错！');</script>");
			}
			else
			{
				litAMessage.Text ="请输入部门";
			}
		}	

		private void cmdDelete_ServerClick(object sender,System.EventArgs e)
		{
			switch(UDS.Components.Department.Delete(DeptID))
			{
				case 0:
					Response.Redirect("ListView.aspx?DeptID="+DeptID+"&Refresh=1");
					break;
				case -1:
					Response.Write("<script laguage='javascript'>alert('有下级子部门，不能删除！');</script>");
					break;
				case -2:
					Response.Write("<script laguage='javascript'>alert('部门有成员，不能删除！');</script>");
					break;
				default:
					break;
			}

		}

		private void cmdModify_ServerClick(object sender,System.EventArgs e)
		{
			if(txtDepartmentName.Text.Trim()!="")
			{
				if((UDS.Components.Department.Modify(DeptID,txtDepartmentName.Text,txtMDepartmentRemark.Text)==0))
				{
					if((txtuOnDutyTime.Text.Trim()!="")&&(txtuOffDutyTime.Text.Trim()!=""))
					{
						if((UDS.Components.Department.UpdateDutyTime(DeptID,DateTime.Parse(txtuOnDutyTime.Text),DateTime.Parse(txtuOffDutyTime.Text))!=0))
						{
							Response.Write("<script laguage='javascript'>alert('修改部门出错！');</script>");
							return;
						}
					}
					else
					{
						UDS.Components.Department.DeleteDutyTime(DeptID);
					}
					Response.Redirect("ListView.aspx?DeptID="+DeptID+"&Refresh=1");
				}
				else
					Response.Write("<script laguage='javascript'>alert('修改部门出错！');</script>");
			}
			else
				litMMessage.Text ="请输入部门";
		}

		private void Operation_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void lbAddDepartment_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ODepartment.aspx?DeptID=" + DeptID.ToString() + "&DisplayType=0");
		}

		private void lbDeleteDepartment_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ODepartment.aspx?DeptID=" + DeptID.ToString() + "&DisplayType=1");
		}

		private void lbModifyDepartment_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ODepartment.aspx?DeptID=" + DeptID.ToString() + "&DisplayType=2");
		}

		private void lbMoveDepartment_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ODepartment.aspx?DeptID=" + DeptID.ToString() + "&DisplayType=3");
		}

		private void cmdMove_Click(object sender, System.EventArgs e)
		{
			UDS.Components.Department dept = new UDS.Components.Department();

			switch(dept.MoveDeparement(DeptID,Int32.Parse(lstDeparment.Items[lstDeparment.SelectedIndex].Value)))
			{
				case 0:
					Response.Write("<script laguage='javascript'>alert('移动到" + lstDeparment.Items[lstDeparment.SelectedIndex].Text +" 部门成功！');</script>");
					Response.Redirect("ListView.aspx?DeptID="+DeptID+"&Refresh=1");
					break;
				case -1:
					Response.Write("<script laguage='javascript'>alert('不能移动到下级部门！');</script>");
					break;
				default:
					break;
			}

		}

		private void cmdReturn_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("Listview.aspx?DeptID=" + DeptID.ToString());
		}

	
	}
}
