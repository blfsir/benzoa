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
using System.Data.SqlClient;
using UDS.Components;

namespace UDS.SubModule.UnitiveDocument.DocumentFlow
{
	/// <summary>
	/// Query 的摘要说明。
	/// </summary>
	public class Query : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddlFlow;
		protected System.Web.UI.WebControls.Button cmdAdd;
		protected System.Web.UI.WebControls.Button cmdDelete;
		protected System.Web.UI.WebControls.TextBox txtValue;
		protected System.Web.UI.WebControls.Table tabResult;
		protected System.Web.UI.WebControls.DropDownList ddlCompare;
		protected System.Web.UI.WebControls.CheckBoxList cblDisplay;
		protected System.Web.UI.WebControls.Button cmdQuery;
		protected System.Web.UI.WebControls.ListBox lbCondition;
		protected System.Web.UI.WebControls.DropDownList ddlStatistic;
		protected System.Web.UI.WebControls.DropDownList ddlCondition;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
				FillFlow(ddlFlow);
			
		}

		void FillFlow(DropDownList ddl)
		{
			SqlDataReader dr=null; //存放人物的数据
			Database mySQL = new Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,0)
										};
			try{
			mySQL.RunProc("sp_Flow_GetFlow",parameters,out dr);
			
			DataTable dt =Tools.ConvertDataReaderToDataTable(dr);

			dr.Close();			
			ddl.DataSource = dt.DefaultView;
			ddl.DataTextField = "Flow_Name";
			ddl.DataValueField = "Flow_ID";
			ddl.DataBind();
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
			if(ddl.Items.Count >0)
			{
				FillDisplayColumn();
				
			}


		}

		private void FillFieldName(CheckBoxList cblField,long iFlowID)
		{
			
			SqlDataReader dr=null; //存放人物的数据
			Database mySQL = new Database();
			try{
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,iFlowID),
											mySQL.MakeInParam("@Judged",SqlDbType.Bit ,1,0)
										};
			
			mySQL.RunProc("sp_flow_getstyle_description",parameters,out dr);
			cblField.Items.Clear();			

			while(dr.Read())
			{
				cblField.Items.Add(new ListItem(dr["Field_Description"].ToString(),dr["Field_Name"].ToString()));				
				
			}
			cblField.Items.Add(new ListItem("流程名","Flow_Name"));		
			cblField.Items.Add(new ListItem("拟稿日期","Doc_Added_Date"));								
			cblField.Items.Add(new ListItem("撰搞人","RealName"));
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
				
		
			
			for(int i=0;i<cblField.Items.Count;i++)
			{
				cblField.Items[i].Selected = true;
			}
			
		}
		private void FillFieldName(DropDownList ddl,long iFlowID)
		{
			
			SqlDataReader dr=null; //存放人物的数据
			Database mySQL = new Database();
            try
            {
                SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,iFlowID),
											mySQL.MakeInParam("@Judged",SqlDbType.Bit ,1,0)
										};

                mySQL.RunProc("sp_flow_getstyle_description", parameters, out dr);
                ddl.Items.Clear();

                while (dr.Read())
                {
                    ddl.Items.Add(new ListItem(dr["Field_Description"].ToString(), (dr["Judged"].ToString() == "True" ? "1" : "0") + dr["Field_Name"].ToString()));
                }
                dr.Close();
                dr = null;

                ddl.Items.Add(new ListItem("拟稿日期", "2Doc_Added_Date"));
                ddl.Items.Add(new ListItem("拟稿人", "0realname"));
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
		}

		private void FillStatisticFieldName(DropDownList ddl,long iFlowID)
		{
			
			SqlDataReader dr=null; //存放人物的数据
			Database mySQL = new Database();
            try
            {
                SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,iFlowID),
											mySQL.MakeInParam("@Judged",SqlDbType.Bit ,1,1)
										};

                mySQL.RunProc("sp_flow_getstyle_description", parameters, out dr);
                ddl.Items.Clear();

                while (dr.Read())
                {
                    ddl.Items.Add(new ListItem(dr["Field_Description"].ToString(), (dr["Judged"].ToString() == "True" ? "1" : "0") + dr["Field_Name"].ToString()));
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
			 
			
		}
		void FillDisplayColumn()
		{
			FillFieldName(cblDisplay,Int32.Parse(ddlFlow.Items[ddlFlow.SelectedIndex].Value)); 
			FillFieldName(ddlCondition,Int32.Parse(ddlFlow.Items[ddlFlow.SelectedIndex].Value)); 

			FillStatisticFieldName(ddlStatistic,Int32.Parse(ddlFlow.Items[ddlFlow.SelectedIndex].Value));
			lbCondition.Items.Clear();
			
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
			this.ddlFlow.SelectedIndexChanged += new System.EventHandler(this.ddlFlow_SelectedIndexChanged);
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			this.cmdQuery.Click += new System.EventHandler(this.cmdQuery_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ddlFlow_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDisplayColumn();
		}

		private void cmdQuery_Click(object sender, System.EventArgs e)
		{
		
			string strDisplayColumn="Doc_ID,Doc_Builder_ID,Flow_ID as flow_id,Step_ID";
			string strCondition = "Flow_ID = " + ddlFlow.SelectedItem.Value.ToString();

			for(int i=0;i<cblDisplay.Items.Count;i++)
			{
				if(cblDisplay.Items[i].Selected ==true)
				{
					strDisplayColumn = strDisplayColumn + "," + cblDisplay.Items[i].Value.ToString() + " AS " + cblDisplay.Items[i].Text;
				}
			}
			
			for(int j=0;j<lbCondition.Items.Count;j++)
			{
				strCondition = strCondition + " And " + lbCondition.Items[j].Value.ToString();
			}

//			Response.Write("<script language='javascript'>alert('" + strDisplayColumn + "');</script>");

			UDS.Components.Database db = new Database();
			SqlDataReader dr=null;
			int iRow = 0;

			SqlParameter[] parameters = {
											db.MakeInParam("@SelectColumns",SqlDbType.VarChar  ,3000,strDisplayColumn),
											db.MakeInParam("@Conditions",SqlDbType.VarChar  ,3000,strCondition),
											db.MakeInParam("@FlowID",SqlDbType.Int   ,4,Int32.Parse(ddlFlow.SelectedItem.Value))										
										};
            try
            {
				tabResult.Rows.Clear();

				db.RunProc("sp_Flow_GetDefineQueryDocument",parameters,out dr);		

				if(dr.FieldCount>=6)
				{				
					do
					{
						
						TableRow  tr = new TableRow();
						AddRow(tr,dr,iRow==0?true:false);
						tabResult.Rows.Add(tr);				
						tr.BorderWidth = 1;
						iRow = iRow + 1;
						
					}while(dr.Read());
				}				
				if(ddlStatistic.SelectedIndex >=0)
					AddStatistic(tabResult,dr.FieldCount-4,ddlStatistic.SelectedItem.Value.Substring(1),ddlStatistic.SelectedItem.Text,strCondition,Int32.Parse(ddlFlow.SelectedItem.Value));
                //dr.Close();
            }
            finally
            {
                if (db != null)
                {
                    db.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                }
                db = null;

            }

			
			//Int32.Parse(ddlFlow.SelectedItem.Value)

		}

		void AddStatistic(Table tab,int ColumnSpan,string StatisticField,string StatisticName,string Condition,long FlowID)
		{
			UDS.Components.Database db = new Database();
			SqlDataReader dr=null;

			SqlParameter[] parameters = {
											db.MakeInParam("@SelectColumns",SqlDbType.VarChar  ,3000,"SUM(CONVERT(INT," + StatisticField + ")) AS " + StatisticField),
											db.MakeInParam("@Conditions",SqlDbType.VarChar  ,3000,Condition),
											db.MakeInParam("@FlowID",SqlDbType.Int   ,4,FlowID)										
										};
			try
			{
				db.RunProc("sp_Flow_GetDefineQueryDocument",parameters,out dr);		
				if(dr.Read())
					AddRow(tab,ColumnSpan,StatisticName +"总计:" + dr[StatisticField].ToString());
			}
			finally
            {
                if (db != null)
                {
                    db.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                }	
			}

		}
		void AddRow(TableRow  tr,SqlDataReader dr,bool bCaption)
		{
           
                for (int i = 4; i < dr.FieldCount; i++)
                {
                    TableCell tc = new TableCell();
                    if (bCaption == false)
                        tc.Text = dr.GetValue(i).ToString();
                    else
                    {
                        tc.Text = dr.GetName(i).ToString();
                        tc.BackColor = Color.FromArgb(0xf8, 0xf8, 0xf8);
                    }
                    tr.Controls.Add(tc);
                }
           
		}

		void AddRow(Table  tab,int ColumSpan,string Caption)
		{
			TableRow tr = new TableRow();
			
			TableCell tc = new TableCell();
			tc.Text = Caption;
			tc.ColumnSpan = ColumSpan;
			tc.BackColor = Color.FromArgb(0xf8,0xf8,0xf8);
			tr.BorderWidth =  1;
			tr.Controls.Add(tc);
			tab.Controls.Add(tr);
		}
		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			if(lbCondition.SelectedIndex >=0)
			{
				lbCondition.Items.Remove(lbCondition.SelectedItem);
			}
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			string ListText;
			string ListValue;
			if(ddlCondition.SelectedIndex >=0)
			{
				switch(ddlCondition.SelectedItem.Value.Substring(0,1))
				{
					case "0":
						ListText		= ddlCondition.SelectedItem.Text  + ddlCompare.SelectedItem.Text  + txtValue.Text;
						if(ddlCompare.SelectedIndex !=6)
							ListValue		= ddlCondition.SelectedItem.Value.Substring(1) + ddlCompare.SelectedItem.Value  + "'" + txtValue.Text + "'";
						else
							ListValue		= ddlCondition.SelectedItem.Value.Substring(1) + ddlCompare.SelectedItem.Value  + "'%" + txtValue.Text + "%'";
						lbCondition.Items.Add(new ListItem(ListText ,ListValue));
						break;
					case "1":
						if(ddlCompare.SelectedIndex!=6)
						{
							try
							{
								int i = Int32.Parse(txtValue.Text);
								ListText	= ddlCondition.SelectedItem.Text  + ddlCompare.SelectedItem.Text  + txtValue.Text;
								ListValue	=" IsNumeric(" + ddlCondition.SelectedItem.Value.Substring(1) + ")>0 and " + ddlCondition.SelectedItem.Value.Substring(1) + ddlCompare.SelectedItem.Value + txtValue.Text;
								lbCondition.Items.Add(new ListItem(ListText ,ListValue));
							}
							catch(Exception ex)
							{
								Response.Write("<script language='javascript'>alert('请输入数字！');</script>");
							}
						}
						else
						{
							Response.Write("<script language='javascript'>alert('不能用此参数！');</script>");
						}
						break;
					case "2":						
						try
						{
							DateTime tt = DateTime.Parse(txtValue.Text);
							ListText	= ddlCondition.SelectedItem.Text  + ddlCompare.SelectedItem.Text  + txtValue.Text;
							ListValue	= ddlCondition.SelectedItem.Value.Substring(1) + ddlCompare.SelectedItem.Value  + "'" + txtValue.Text + "'";
							lbCondition.Items.Add(new ListItem(ListText ,ListValue));
						}
						catch(Exception ex)
						{
							Response.Write("<script language='javascript'>alert('请输入正确的日期！');</script>");
							//UDS.Components.Error.Log(ex.ToString());
						}
						break;
					case "3":
						break;
				}
			}
		}

		private void cblDisplay_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}
