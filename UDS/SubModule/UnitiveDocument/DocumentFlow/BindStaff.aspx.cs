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
	/// BangdingRole 的摘要说明。
	/// </summary>
	public class BindStaff : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button cmdAdd;
		protected System.Web.UI.WebControls.Button cmdDelete;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ListBox lstCurRole;
		protected System.Web.UI.WebControls.ListBox lstAllRole;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Button cmdAddPositon;
		protected System.Web.UI.WebControls.Button cmdDeletePosition;
		protected System.Web.UI.WebControls.ListBox lstCurPosition;
		protected System.Web.UI.WebControls.ListBox lstAllPosition;
		protected System.Web.UI.WebControls.Button cmdAddStaff;
		protected System.Web.UI.WebControls.Button cmdDeleteStaff;
		protected System.Web.UI.WebControls.Button cmdDeleteTeam;
		protected System.Web.UI.WebControls.Button cmdAddTeam;
		protected System.Web.UI.WebControls.ListBox lstCurTeam;
		protected System.Web.UI.WebControls.ListBox lstAllTeam;
		protected System.Web.UI.WebControls.ListBox lstCurStaff;
		protected System.Web.UI.WebControls.ListBox lstAllStaff;
		public int FlowID;
		protected System.Web.UI.WebControls.Label labTitle;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.ListBox lstAllTeamLeader;
		protected System.Web.UI.WebControls.Button cmdDeleteTeamLeader;
		protected System.Web.UI.WebControls.Button cmdAddTeamLeader;
		protected System.Web.UI.WebControls.ListBox lstCurTeamLeader;
		protected System.Web.UI.WebControls.Button cmdReturn;
		protected System.Web.UI.WebControls.ListBox lstAllMember;
		public int StepID;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			FlowID = Request.QueryString["FlowID"]==""?0:Int32.Parse(Request.QueryString["FlowID"].ToString());
			StepID = Request.QueryString["StepID"]==""?0:Int32.Parse(Request.QueryString["StepID"].ToString());
			if(!Page.IsPostBack)
			{				
				Bangding();
			}
		}
		private void InitCurRole()
		{
			SqlDataReader dr; //存放人物的数据
			Database mySQL = new Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID)
										};
			
			mySQL.RunProc("sp_Flow_GetBangdingRole",parameters,out dr);
			lstCurRole.Items.Clear();
            try
            {
                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    lstCurRole.Items.Add(new ListItem(dr["role_name"].ToString(), dr["role_id"].ToString()));

                }
            }
            finally
            {
          
                if (dr != null)
                {

                     if (dr != null){dr.Close();}
                }
                dr = null;
            }
			
		}
		private void InitAllRole()
		{
			SqlDataReader dr; //存放人物的数据
			Database mySQL = new Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID)

										};
			
			mySQL.RunProc("sp_Flow_GetNotBangdingRole",parameters,out dr);
			lstAllRole.Items.Clear();
            try
            {
                while (dr.Read())
                {
                    lstAllRole.Items.Add(new ListItem(dr["role_name"].ToString(), dr["role_id"].ToString()));
                }
            }
            finally
            {
                if (dr != null)
                {

                    dr.Close();
                }
                dr = null;
            }
		}
		private void InitCurPosition()
		{
			SqlDataReader dr; //存放人物的数据
			Database mySQL = new Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID)

										};
			
			mySQL.RunProc("sp_Flow_GetBangdingPosition",parameters,out dr);
			lstCurPosition.Items.Clear();
            try
            {
                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    lstCurPosition.Items.Add(new ListItem(dr["Position_name"].ToString(), dr["Position_id"].ToString()));

                }
            }
            finally
            {
                if (dr != null)
                {

                    dr.Close();
                }
                dr = null;
            }
		}
		private void InitAllPosition()
		{
			SqlDataReader dr; //存放人物的数据
			Database mySQL = new Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID)

										};
			
			mySQL.RunProc("sp_Flow_GetNotBangdingPosition",parameters,out dr);
			lstAllPosition.Items.Clear();
            try
            {
                while (dr.Read())
                {
                    lstAllPosition.Items.Add(new ListItem(dr["Position_name"].ToString(), dr["Position_id"].ToString()));
                }
            }
            finally
            {
                 if (dr != null){dr.Close();}
                dr = null;
            }

		}		
		private void InitCurTeam()
		{
			SqlDataReader dr; //存放人物的数据
			Database mySQL = new Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID)

										};
	
			mySQL.RunProc("sp_Flow_GetBangdingTeam",parameters,out dr);
			lstCurTeam.Items.Clear();
            try
            {
                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    lstCurTeam.Items.Add(new ListItem(dr["Team_name"].ToString(), dr["Team_id"].ToString()));

                }
            }
            finally
            {
                 if (dr != null){dr.Close();}
                dr = null;
            }

		}
		private void InitAllTeam()
		{
			SqlDataReader dr; //存放人物的数据
			Database mySQL = new Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID)

										};
			
			mySQL.RunProc("sp_Flow_GetNotBangdingTeam",parameters,out dr);
			lstAllTeam.Items.Clear();
            try
            {
                while (dr.Read())
                {
                    lstAllTeam.Items.Add(new ListItem(dr["Team_name"].ToString(), dr["Team_id"].ToString()));
                }
            }
            finally
            {
                 if (dr != null){dr.Close();}
                dr = null;
            }
		}		

		private void InitCurTeamLeader()
		{
			SqlDataReader dr; //存放人物的数据
			Database mySQL = new Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID)

										};
	
			mySQL.RunProc("sp_Flow_GetBangdingTeamLeader",parameters,out dr);
			lstCurTeamLeader.Items.Clear();
            try
            {
                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    lstCurTeamLeader.Items.Add(new ListItem(dr["Team_name"].ToString(), dr["Team_id"].ToString()));

                }
            }
            finally
            {
                 if (dr != null){dr.Close();}
                dr = null;
            }

		}
		private void InitAllTeamLeader()
		{
			SqlDataReader dr; //存放人物的数据
			Database mySQL = new Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID)

										};
			
			mySQL.RunProc("sp_Flow_GetNotBangdingTeamLeader",parameters,out dr);
			lstAllTeamLeader.Items.Clear();
            try
            {
                while (dr.Read())
                {
                    lstAllTeamLeader.Items.Add(new ListItem(dr["Team_name"].ToString(), dr["Team_id"].ToString()));
                }
            }
            finally
            {

                 if (dr != null){dr.Close();}
                dr = null;
            }

		}		
		private void InitCurStaff()
		{
			SqlDataReader dr; //存放人物的数据
			Database mySQL = new Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID)

										};

			mySQL.RunProc("sp_Flow_GetBangdingStaff",parameters,out dr);
			lstCurStaff.Items.Clear();
            try
            {
                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    lstCurStaff.Items.Add(new ListItem(dr["Staff_name"].ToString(), dr["Staff_id"].ToString()));

                }
            }
            finally
            {
                 if (dr != null){dr.Close();}

                dr = null;
            }
		}
		private void InitAllStaff()
		{
			SqlDataReader dr; //存放人物的数据
			Database mySQL = new Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID)

										};
			
			mySQL.RunProc("sp_Flow_GetNotBangdingStaff",parameters,out dr);
			lstAllStaff.Items.Clear();
            try
            {
                while (dr.Read())
                {
                    lstAllStaff.Items.Add(new ListItem(dr["Staff_name"].ToString(), dr["Staff_id"].ToString()));
                }
            }
            finally
            {
                 if (dr != null){dr.Close();}
                dr = null;
            }

		}

		private void InitAllMember()
		{
			SqlDataReader dr; //存放人物的数据
			Database mySQL = new Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID)

										};
			
			mySQL.RunProc("sp_Flow_GetAllBindMember",parameters,out dr);
			lstAllMember.Items.Clear();
            try
            {
                while (dr.Read())
                {
                    lstAllMember.Items.Add(new ListItem(dr["RealName"].ToString(), dr["Staff_id"].ToString()));
                }
            }
            finally
            {
                 if (dr != null){dr.Close();}
                dr = null;
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
			this.lstCurRole.SelectedIndexChanged += new System.EventHandler(this.lstCurRole_SelectedIndexChanged);
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			this.lstAllRole.SelectedIndexChanged += new System.EventHandler(this.lstAllRole_SelectedIndexChanged);
			this.cmdAddPositon.Click += new System.EventHandler(this.cmdAddPositon_Click);
			this.cmdDeletePosition.Click += new System.EventHandler(this.cmdDeletePosition_Click);
			this.cmdAddTeam.Click += new System.EventHandler(this.cmdAddTeam_Click);
			this.cmdDeleteTeam.Click += new System.EventHandler(this.cmdDeleteTeam_Click);
			this.cmdAddTeamLeader.Click += new System.EventHandler(this.cmdAddTeamLeader_Click);
			this.cmdDeleteTeamLeader.Click += new System.EventHandler(this.cmdDeleteTeamLeader_Click);
			this.cmdAddStaff.Click += new System.EventHandler(this.cmdAddStaff_Click);
			this.cmdDeleteStaff.Click += new System.EventHandler(this.cmdDeleteStaff_Click);
			this.cmdReturn.Click += new System.EventHandler(this.cmdReturn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region 绑定数据库
		private void Bangding()
		{		
			InitHeadLine();
			InitCurRole();
			InitAllRole();

			InitCurPosition();
			InitAllPosition();

			InitCurTeam();
			InitAllTeam();

			InitCurTeamLeader();
			InitAllTeamLeader();


			InitCurStaff();
			InitAllStaff();

			InitAllMember();

		}
		#endregion
		private void InitHeadLine()
		{
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
			labTitle.Text = df.GetFlowTitle(FlowID) + "->" +  df.GetStepTitle(FlowID,StepID);
			df = null;
		}
		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			if(lstAllRole.SelectedIndex >=0)
			{
				Database mySQL = new Database();
                try
                {
                    foreach (ListItem li in lstAllRole.Items)
                    {
                        if (li.Selected == true)
                        {
                            SqlParameter[] parameters = {
														mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
														mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID),
														mySQL.MakeInParam("@RoleID",SqlDbType.Int ,4,Int32.Parse (li.Value)  )
													};

                            mySQL.RunProc("sp_Flow_AddBangdingRole", parameters);
                        }
                    }
                }
                finally
                {
                    mySQL.Close();
                    mySQL = null;
                }
				//Response.Write("<script language='javascript'>alert('绑定成功！');</script>");
				Bangding();

			}
		}

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			if(lstCurRole.SelectedIndex>=0)
			{
				Database mySQL = new Database();				
				foreach(ListItem li in lstCurRole.Items)
				{
					if(li.Selected ==true)
					{
						SqlParameter[] parameters = {
														mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
														mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID),
														//mySQL.MakeInParam("@RoleID",SqlDbType.Int ,4,Int32.Parse(lstCurRole.Items[lstCurRole.SelectedIndex].Value)  )
														mySQL.MakeInParam("@RoleID",SqlDbType.Int ,4,Int32.Parse(li.Value)  )
													};
			
						mySQL.RunProc("sp_Flow_DeleteBangdingRole",parameters);
					}
				}
				mySQL.Close();
				mySQL = null;
				//Response.Write("<script language='javascript'>alert('取消绑定成功！');</script>");		
				Bangding();
			}
		}

		private void lstAllRole_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void cmdReturn_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ManageFlow.aspx?FlowID=" + FlowID.ToString());
		}

		private void cmdAddPositon_Click(object sender, System.EventArgs e)
		{
			if(lstAllPosition.SelectedIndex >=0)
			{
				Database mySQL = new Database();
				foreach(ListItem li in lstAllPosition.Items )
				{
					if(li.Selected ==true)
					{
						SqlParameter[] parameters = {
														mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
														mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID),
														mySQL.MakeInParam("@PositionID",SqlDbType.Int ,4,Int32.Parse (li.Value)  )
													};
			
						mySQL.RunProc("sp_Flow_AddBangdingPosition",parameters);
					}
				}
				mySQL.Close();
				mySQL = null;
				Bangding();

			}		
		}

		private void cmdDeletePosition_Click(object sender, System.EventArgs e)
		{
			if(lstCurPosition.SelectedIndex>=0)
			{
				Database mySQL = new Database();
				foreach(ListItem li in lstCurPosition.Items )
				{
					if(li.Selected ==true)
					{
						SqlParameter[] parameters = {
														mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
														mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID),
														mySQL.MakeInParam("@PositionID",SqlDbType.Int ,4,Int32.Parse (li.Value)  )
													};
			
						mySQL.RunProc("sp_Flow_DeleteBangdingPosition",parameters);
					}
				}
				mySQL.Close();
				mySQL = null;
				//Response.Write("<script language='javascript'>alert('取消绑定成功！');</script>");		
				Bangding();
			}
		
		}

		private void cmdDeleteTeam_Click(object sender, System.EventArgs e)
		{
			if(lstCurTeam.SelectedIndex>=0)
			{
				Database mySQL = new Database();
				foreach(ListItem li in lstCurTeam.Items )
				{
					if(li.Selected==true)
					{
						SqlParameter[] parameters = {
														mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
														mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID),
														mySQL.MakeInParam("@TeamID",SqlDbType.Int ,4,Int32.Parse (li.Value)  )
													};
			
						mySQL.RunProc("sp_Flow_DeleteBangdingTeam",parameters);
					}
				}
				mySQL.Close();
				mySQL = null;
				//Response.Write("<script language='javascript'>alert('取消绑定成功！');</script>");		
				Bangding();
			}
		
		}

		private void cmdDeleteStaff_Click(object sender, System.EventArgs e)
		{
			if(lstCurStaff.SelectedIndex>=0)
			{
				Database mySQL = new Database();
				foreach(ListItem li in lstCurStaff.Items)
				{
					if(li.Selected ==true)
					{
						SqlParameter[] parameters = {
														mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
														mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID),
														mySQL.MakeInParam("@StaffID",SqlDbType.Int ,4,Int32.Parse (li.Value)  )
													};
			
						mySQL.RunProc("sp_Flow_DeleteBangdingStaff",parameters);
					}
				}
				mySQL.Close();
				mySQL = null;
				//Response.Write("<script language='javascript'>alert('取消绑定成功！');</script>");		
				Bangding();
			}
		
		}

		private void cmdAddTeam_Click(object sender, System.EventArgs e)
		{
			if(lstAllTeam.SelectedIndex >=0)
			{
				Database mySQL = new Database();
				foreach(ListItem li in lstAllTeam.Items)
				{
					if(li.Selected ==true)
					{
						SqlParameter[] parameters = {
														mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
														mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID),
														mySQL.MakeInParam("@TeamID",SqlDbType.Int ,4,Int32.Parse (li.Value)  )
													};
			
						mySQL.RunProc("sp_Flow_AddBangdingTeam",parameters);
					}
				}
				mySQL.Close();
				mySQL = null;
				Bangding();

			}		
		
		}

		private void cmdAddStaff_Click(object sender, System.EventArgs e)
		{
			if(lstAllStaff.SelectedIndex >=0)
			{
				Database mySQL = new Database();
				foreach(ListItem li in lstAllStaff.Items)
				{
					if(li.Selected ==true)
					{
						SqlParameter[] parameters = {
														mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
														mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID),
														mySQL.MakeInParam("@StaffID",SqlDbType.Int ,4,Int32.Parse (li.Value)  )
													};
			
						mySQL.RunProc("sp_Flow_AddBangdingStaff",parameters);
					}
				}
				mySQL.Close();
				mySQL = null;
				Bangding();

			}		
		
		}

		private void lstCurRole_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void cmdAddTeamLeader_Click(object sender, System.EventArgs e)
		{
			if(lstAllTeamLeader.SelectedIndex >=0)
			{
				Database mySQL = new Database();
				foreach(ListItem li in lstAllTeamLeader.Items)
				{
					if(li.Selected ==true)
					{
						SqlParameter[] parameters = {
														mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
														mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID),
														mySQL.MakeInParam("@TeamID",SqlDbType.Int ,4,Int32.Parse (li.Value)  )
													};
			
						mySQL.RunProc("sp_Flow_AddBangdingTeamLeader",parameters);
					}
				}
				mySQL.Close();
				mySQL = null;
				Bangding();

			}				
		}

		private void cmdDeleteTeamLeader_Click(object sender, System.EventArgs e)
		{
			if(lstCurTeamLeader.SelectedIndex>=0)
			{
				Database mySQL = new Database();
				foreach(ListItem li in lstCurTeamLeader.Items )
				{
					if(li.Selected==true)
					{
						SqlParameter[] parameters = {
														mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
														mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID),
														mySQL.MakeInParam("@TeamID",SqlDbType.Int ,4,Int32.Parse (li.Value)  )
													};
			
						mySQL.RunProc("sp_Flow_DeleteBangdingTeamLeader",parameters);
					}
				}
				mySQL.Close();
				mySQL = null;
				//Response.Write("<script language='javascript'>alert('取消绑定成功！');</script>");		
				Bangding();
			}		
		}
	}
}
