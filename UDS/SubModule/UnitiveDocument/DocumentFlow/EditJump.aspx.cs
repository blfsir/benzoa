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
	/// EditJump 的摘要说明。
	/// </summary>
	public class EditJump : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button cmdInsert;
		protected System.Web.UI.WebControls.TextBox txtContant;
		protected System.Web.UI.WebControls.DropDownList ddCompare;
		protected System.Web.UI.WebControls.DropDownList ddFieldName;
		protected System.Web.UI.WebControls.DropDownList ddStep;
		public int FlowID;
		protected System.Web.UI.WebControls.DataGrid dgJumpList;
		protected System.Web.UI.WebControls.Button cmdReturn;
		protected System.Web.UI.WebControls.Label labTitle;
		protected System.Web.UI.WebControls.DropDownList ddlFlowRule;
		public int StepID;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面	
			FlowID = Request.QueryString["FlowID"]==""?0:Int32.Parse(Request.QueryString["FlowID"].ToString());
			StepID = Request.QueryString["StepID"]==""?0:Int32.Parse(Request.QueryString["StepID"].ToString());

			if(!Page.IsPostBack)
			{
				Bind();
			}
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
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
			this.cmdInsert.Click += new System.EventHandler(this.cmdInsert_Click);
			this.cmdReturn.Click += new System.EventHandler(this.cmdReturn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Bind()
		{
			InitHeadLine();
			InitDataGrid();
			FillStep(ddStep,FlowID);
			FillFieldName(ddFieldName,FlowID);
			if(ddFieldName.Items.Count <1||ddStep.Items.Count <1)
				cmdInsert.Enabled = false;
			else
				cmdInsert.Enabled = true;
		}
		private void FillFieldName(DropDownList ddField,long iFlowID)
		{
			ddField.Items.Clear();
			SqlDataReader dr; //存放人物的数据
			Database mySQL = new Database();
			
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,iFlowID)
										};
			
			mySQL.RunProc("sp_flow_getstyle_description",parameters,out dr);
			ddField.Items.Clear();
            try
            {
                while (dr.Read())
                {
                    ddField.Items.Add(new ListItem(dr["Field_Description"].ToString(), dr["Field_Name"].ToString()));
                }
            }
            finally
            {
                if (mySQL != null)
                {
                    mySQL.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                }
                dr = null;
            }

			ddField.Items.Add(new ListItem("《职级》","caste"));

		}
		private void FillStep(DropDownList ddStep,long iFlowID)
		{
			SqlDataReader dr; //存放人物的数据
			Database mySQL = new Database();
			
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,iFlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,0)
										};
			
			mySQL.RunProc("sp_Flow_GetStep",parameters,out dr);
			ddStep.Items.Clear();
            try
            {
                while (dr.Read())
                {
                    ddStep.Items.Add(new ListItem(dr["Step_name"].ToString(), dr["Step_id"].ToString()));
                }
            }
            finally
            {
                if (mySQL != null)
                {
                    mySQL.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                }
                dr = null;
            }

			ddStep.Items.Add(new ListItem("《结束文档》","0"));								

			
		}
		public string GetTranslateFlowRule(string FlowRule)
		{
			switch(FlowRule)
			{
				case "0":
					return "按人员";
				case "1":
					return "按职位";
				case "2":
					return "按项目";
				default:
					return "无";
			}
		}
		private void InitHeadLine()
		{
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
			labTitle.Text = df.GetFlowTitle(FlowID) + "->" +  df.GetStepTitle(FlowID,StepID);
			df = null;
		}
		private void InitDataGrid()
		{
			SqlDataReader dr; //存放人物的数据
			Database mySQL = new Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID),
											mySQL.MakeInParam("@Priority",SqlDbType.Int ,4,0)
										};
			
			mySQL.RunProc("sp_Flow_GetJump",parameters,out dr);
            try
            {
                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);
                dr.Close();
                dr = null;
                dgJumpList.DataSource = dt.DefaultView;
                dgJumpList.DataBind();
            }
            finally
            {
                if (mySQL != null)
                {
                    mySQL.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                }
            }

		}		
		public string TranslateCompare(string strCompare)
		{			
			string CompareChar="";
			switch(Int32.Parse(strCompare))
			{
				case 6:
					CompareChar = "<>";
					break;
				case 1:
					CompareChar = ">";
					break;
				case 2:
					CompareChar = "<";
					break;
				case 3:
					CompareChar = "=";
					break;
				case 4:
					CompareChar =">=";
					break;
				case 5:
					CompareChar = "<=";
					break;
				default:
					break;
			}
			return CompareChar;
		}
		#region 获取节点图标
		/// <summary>
		/// 获取节点图标
		/// </summary>
		private string GetIcon(int IcnoNO)
		{
			string rtnValue = "../../../DataImages/";
			switch (IcnoNO)
			{
				default: 
					rtnValue+= "red_ball.gif";
					break;
			}
			return rtnValue;
		}
		#endregion		
		
		#region 翻页事件
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dgJumpList.CurrentPageIndex = e.NewPageIndex;
		}
		#endregion

		private void cmdInsert_Click(object sender, System.EventArgs e)
		{
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
			df.AddJump(FlowID,StepID,ddFieldName.Items[ddFieldName.SelectedIndex].Value.ToString(),ddCompare.Items[ddCompare.SelectedIndex].Text ,Double.Parse(txtContant.Text),Int32.Parse(ddStep.Items[ddStep.SelectedIndex].Value),Int32.Parse(ddlFlowRule.SelectedItem.Value));
			df = null;
			Bind();		
		}

		public void MyGrid_Delete(object sender,DataGridCommandEventArgs e)
		{
			string Priority = dgJumpList.DataKeys[e.Item.ItemIndex].ToString();
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
			df.DeleteJump(FlowID,StepID,Int32.Parse(Priority));
			df = null;
			Bind();				
		}
		public void MyGrid_Move(object sender,DataGridCommandEventArgs e)
		{			
			string Priority = dgJumpList.DataKeys[e.Item.ItemIndex].ToString();
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
			df.MoveUpJump(FlowID,StepID,Int32.Parse(Priority));
			df = null;
			Bind();				
		}

		private void cmdReturn_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ManageFlow.aspx?FlowID=" + FlowID.ToString());
		}

	}
}
