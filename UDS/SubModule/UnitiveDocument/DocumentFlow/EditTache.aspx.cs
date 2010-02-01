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
	/// EditTache 的摘要说明。
	/// </summary>
	public class EditTache : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtTacheName;
		protected System.Web.UI.WebControls.DropDownList cboFlowRule;
		protected System.Web.UI.WebControls.RadioButton chkFinishYes;
		protected System.Web.UI.WebControls.RadioButton chkFinishNO;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtRemark;
		protected System.Web.UI.WebControls.Button cmdPrevious;
		protected System.Web.UI.WebControls.Button cmdFinish;
		protected System.Web.UI.WebControls.Button cmdDelete;
		protected System.Web.UI.WebControls.Button cmdCancel;
		protected System.Web.UI.WebControls.Button cmdNext;
		protected System.Web.UI.WebControls.RadioButton radPassNumYes;
		protected System.Web.UI.WebControls.RadioButton radPassNumNo;
		protected System.Web.UI.HtmlControls.HtmlGenericControl PassNum;
		protected System.Web.UI.WebControls.TextBox txtPassNum;		
		private long FlowID;
		private long StepID;
		protected System.Web.UI.WebControls.Label labStep;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkAllPass;
		protected System.Web.UI.WebControls.Label labFlowName;
		protected System.Web.UI.WebControls.Button cmdReturn;
		protected System.Web.UI.WebControls.CheckBox chkLocalAlert;
		protected System.Web.UI.WebControls.CheckBox chkUrgencyAlert;
		protected System.Web.UI.WebControls.TextBox txtBaseHour;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanAlert;
		protected System.Web.UI.WebControls.TextBox txtPeriod;
		protected System.Web.UI.WebControls.TextBox txtCycTimes;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator4;
		private bool bIsExistStep;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面			
			FlowID = Request.QueryString["FlowID"]!=null?Int32.Parse(Request.QueryString["FlowID"].ToString()):0;
			StepID = Request.QueryString["StepID"]!=null?Int32.Parse(Request.QueryString["StepID"].ToString()):0;

			if(!Page.IsPostBack)
				Bangding();

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
			this.radPassNumYes.CheckedChanged += new System.EventHandler(this.radPassNumYes_CheckedChanged);
			this.radPassNumNo.CheckedChanged += new System.EventHandler(this.radPassNumNo_CheckedChanged);
			this.chkUrgencyAlert.CheckedChanged += new System.EventHandler(this.chkUrgencyAlert_CheckedChanged);
			this.cmdPrevious.Click += new System.EventHandler(this.cmdPrevious_Click);
			this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			this.cmdFinish.Click += new System.EventHandler(this.cmdFinish_Click);
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			this.cmdReturn.Click += new System.EventHandler(this.cmdReturn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void Bangding()
		{
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
			
			bIsExistStep = StepID>df.GetMaxStep(FlowID)?false:true;
			labStep.Text = "步骤:第" + StepID.ToString() + "步";
			labFlowName.Text = df.GetFlowTitle(FlowID);

			if(bIsExistStep==true)
			{
				DataTable dt;
				df.GetStep(FlowID,StepID,out dt);
				if(dt.Rows.Count >0)
				{
					txtTacheName.Text = dt.Rows[0]["Step_Name"].ToString();
					txtRemark.Text	  = dt.Rows[0]["Step_Remark"].ToString();

					if(dt.Rows[0]["RightToFinish"].ToString()=="True")
					{
						chkFinishYes.Checked = true;
						chkFinishNO.Checked  = false;
					}
					else
					{
						chkFinishYes.Checked = false;
						chkFinishNO.Checked  = true;
					}
					txtPassNum.Text = dt.Rows[0]["PassNum"].ToString();
					if(Int32.Parse(txtPassNum.Text)==0)
					{
						radPassNumYes.Checked = false;
						radPassNumNo.Checked = true;
						PassNum.Style["display"] = "none";
					}
					else
					{
						radPassNumNo.Checked = false;
						radPassNumYes.Checked = true;
						PassNum.Style["display"] = "";
						if(Int32.Parse(txtPassNum.Text)==-1)
						{
							chkAllPass.Checked = true;
						}
						else
						{
							chkAllPass.Checked = false;
						}
						
					}
					for(int i=0;i<cboFlowRule.Items.Count;i++)
					{
						if(cboFlowRule.Items[i].Value.ToString()==dt.Rows [0]["Flow_Rule"].ToString() )
							cboFlowRule.SelectedIndex = i;
					}
					if(dt.Rows[0]["localalert"].ToString()=="True")					
						chkLocalAlert.Checked = true;
					else
						chkLocalAlert.Checked = false;

					if(Int32.Parse(dt.Rows[0]["cycTimes"].ToString())>0)
					{
						chkUrgencyAlert.Checked		= true;
						spanAlert.Style["display"]	= "";
						txtBaseHour.Text			= dt.Rows[0]["BaseHour"].ToString();
						txtCycTimes.Text			= dt.Rows[0]["CycTimes"].ToString();
						txtPeriod.Text				= dt.Rows[0]["Period"].ToString();
					}
					else
					{
						chkUrgencyAlert.Checked		= false;
						spanAlert.Style["display"]	= "none";
						txtBaseHour.Text			= "0";
						txtCycTimes.Text			= "0";
						txtPeriod.Text				= "0";
					}

				}
				df = null;
				cmdDelete.Enabled =true;
			}
			else
			{
				spanAlert.Style["display"]	= "none";
				txtBaseHour.Text			= "0";
				txtCycTimes.Text			= "0";
				txtPeriod.Text				= "0";
				cmdDelete.Enabled = false;
			}

			cmdCancel.Attributes.Add("onclick","return confirm('是否删除此流程？');");

		}

		private void cmdNext_Click(object sender, System.EventArgs e)
		{
			String UserName					= Server.UrlDecode(Request.Cookies["UserName"].Value);
			UDS.Components.DocumentFlow df	= new UDS.Components.DocumentFlow();
			int iPassNum;
			if(radPassNumNo.Checked ==true)
			{
				iPassNum = 0;
			}
			else
			{
				iPassNum = Int32.Parse(txtPassNum.Text);
			}
			int iBaseHour;
			int iCycTimes;
			int iPeriod;

			if(chkUrgencyAlert.Checked ==true)
			{
				iBaseHour	= Int32.Parse(txtBaseHour.Text);
				iCycTimes	= Int32.Parse(txtCycTimes.Text);
				iPeriod		= Int32.Parse(txtPeriod.Text);

			}
			else
			{
				iBaseHour	= 0;
				iCycTimes	= 0;
				iPeriod		= 0;
			}

			//判断此流程的步骤是否存在			
			if(StepID>df.GetMaxStep(FlowID))
			{
				
				if(df.AddStep(FlowID,txtTacheName.Text,txtRemark.Text,chkFinishYes.Checked?1:0,Int32.Parse(cboFlowRule.SelectedItem.Value),iPassNum,chkLocalAlert.Checked?1:0,iBaseHour,iCycTimes,iPeriod)>0)
				{										
					StepID +=1;
					Server.Transfer("EditTache.aspx?FlowID=" + FlowID.ToString() + "&StepID=" + StepID.ToString());			
				}
				else
				{
					Server.Transfer("../../Error.aspx");				
				}				
			}
			else
			{
				if(df.UpdateStep(FlowID,StepID,txtTacheName.Text,txtRemark.Text,chkFinishYes.Checked?1:0,Int32.Parse(cboFlowRule.SelectedItem.Value),iPassNum,chkLocalAlert.Checked?1:0,iBaseHour,iCycTimes,iPeriod)==0)
				{
					StepID +=1;
					Server.Transfer("EditTache.aspx?FlowID=" + FlowID.ToString() + "&StepID=" + StepID.ToString());			
				}
				else
				{
					Server.Transfer("../../Error.aspx");				
				}				
			}			
		}

		private void cmdFinish_Click(object sender, System.EventArgs e)
		{
			String UserName					= Server.UrlDecode(Request.Cookies["UserName"].Value);
			UDS.Components.DocumentFlow df	= new UDS.Components.DocumentFlow();
			int iPassNum;
			if(radPassNumNo.Checked ==true)
			{
				iPassNum = 0;
			}
			else
			{
				iPassNum = Int32.Parse(txtPassNum.Text);
			}

			int iBaseHour;
			int iCycTimes;
			int iPeriod;

			if(chkUrgencyAlert.Checked ==true)
			{
				iBaseHour	= Int32.Parse(txtBaseHour.Text);
				iCycTimes	= Int32.Parse(txtCycTimes.Text);
				iPeriod		= Int32.Parse(txtPeriod.Text);

			}
			else
			{
				iBaseHour	= 0;
				iCycTimes	= 0;
				iPeriod		= 0;
			}

			//判断此流程的步骤是否存在			
			if(StepID>df.GetMaxStep(FlowID))
			{
				
				if(df.AddStep(FlowID,txtTacheName.Text,txtRemark.Text,chkFinishYes.Checked?1:0,Int32.Parse(cboFlowRule.SelectedItem.Value),iPassNum,chkLocalAlert.Checked?1:0,iBaseHour,iCycTimes,iPeriod)>0)
				{										
					Server.Transfer("ManageFlow.aspx?FlowID=" + FlowID.ToString());				}
				else
				{
					Server.Transfer("../../Error.aspx");				
				}				
			}
			else
			{
				if(df.UpdateStep(FlowID,StepID,txtTacheName.Text,txtRemark.Text,chkFinishYes.Checked?1:0,Int32.Parse(cboFlowRule.SelectedItem.Value),iPassNum,chkLocalAlert.Checked?1:0,iBaseHour,iCycTimes,iPeriod)==0)
				{
					Server.Transfer("ManageFlow.aspx?FlowID=" + FlowID.ToString());					
				}
				else
				{
					Server.Transfer("../../Error.aspx");				
				}				
			}			
			
		}

		private void radPassNumYes_CheckedChanged(object sender, System.EventArgs e)
		{
			PassNum.Style["display"] = "";
		}

		private void radPassNumNo_CheckedChanged(object sender, System.EventArgs e)
		{
			PassNum.Style["display"] = "none";
		}

		private void chkAllMember_ServerChange(object sender, System.EventArgs e)
		{
		
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			//删除流程
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
			if(df.DeleteFlow(FlowID)==0)
			{
				Server.Transfer("Listview.aspx");
			}
			else
			{
				Server.Transfer("../../Error.aspx");				
			}				

		}

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			//删除此步
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
			df.DeleteStep(FlowID,StepID);
			df = null;

			if(StepID>1)
			{
				StepID -=1;
				Server.Transfer("EditTache.aspx?FlowID=" + FlowID.ToString() + "&StepID=" + StepID.ToString());			
			}
			else
			{
				Server.Transfer("EditFlow.aspx?FlowID=" + FlowID.ToString());			
			}
		}

		private void cmdPrevious_Click(object sender, System.EventArgs e)
		{
			if(StepID>1)
			{
				StepID -=1;
				Server.Transfer("EditTache.aspx?FlowID=" + FlowID.ToString() + "&StepID=" + StepID.ToString());			
			}
			else
			{
				Server.Transfer("EditFlow.aspx?FlowID=" + FlowID.ToString());			
			}
		
		}

		private void cmdReturn_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ManageFlow.aspx?FlowID=" + FlowID.ToString());
		}

		private void chkUrgencyAlert_CheckedChanged(object sender, System.EventArgs e)
		{			
			if(chkUrgencyAlert.Checked ==true)			
				spanAlert.Style["display"] = "";			
			else
				spanAlert.Style["display"] = "none";			
		}

	}
}
