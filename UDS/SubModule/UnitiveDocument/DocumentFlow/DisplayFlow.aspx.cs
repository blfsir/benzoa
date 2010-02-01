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
	/// DisplayFlow 的摘要说明。
	/// </summary>
	/// 
	public class DisplayFlow : System.Web.UI.Page
	{
		public long			FlowID;

        protected System.Web.UI.WebControls.Panel pt;

        protected System.Web.UI.HtmlControls.HtmlImage imgFlow;
        protected System.Web.UI.HtmlControls.HtmlAnchor viewpic;
        

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			FlowID = Int32.Parse(Request.QueryString["FlowID"]!=null?Request.QueryString["FlowID"].ToString():"0");

			Bind();
		}
		void Bind()
		{
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();


            string flowChat = "";
            flowChat=df.GetFlowAttachName(FlowID);
            if(flowChat.Length <=0)
            {
                imgFlow.Src = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/")) + "/Attachment/" + "noimg.jpg";
                viewpic.HRef = imgFlow.Src;
            }
            else
            {
                imgFlow.Src = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/")) + "/Attachment/" +flowChat ;
                viewpic.HRef = imgFlow.Src;
            }
			DataTable dt;

			Table		tt		= new Table();
			TableRow	tr		= new TableRow();
			TableCell	tc		= new TableCell();

			tt.Style.Add("font-size","10pt");
			tt.Width			= Unit.Percentage(100);
			tt.HorizontalAlign  = HorizontalAlign.Center;
			
			AddRow(tt,df.GetFlowTitle(FlowID),Color.FromArgb(250,250,250));
						
			df.GetStep(FlowID,0,out dt);

			for(int i=0;i<dt.Rows.Count;i++)
			{							
								
				AddStep(tt,dt.Rows[i],i+1);				
				AddRow(tt,"<span lang='EN-US' style='font-size: 10.5pt; font-family: Wingdings'>ò</span>",Color.FromArgb(250,250,250));
				
			}

			df = null;

			AddRow(tt,"<a href='#' onclick='history.back();'>流程结束</a>",Color.FromArgb(250,250,250));


			pt.Controls.Add(tt);
           
			
		}

		void AddRow(Table tab,string Label,string Caption)
		{

			TableRow tr = new TableRow();
			TableCell td1 = new TableCell();
			TableCell td2 = new TableCell();

			td1.Text = Label;
			td1.HorizontalAlign = HorizontalAlign.Right;
			td1.BackColor = Color.FromArgb(240,240,240);
			td1.Style.Add("width","100px");
			td2.Text = Caption;
			td2.HorizontalAlign = HorizontalAlign.Left ;
			td2.Style.Add("width","300px");

			tr.Cells.Add(td1);
			tr.Cells.Add(td2);

			tab.Rows.Add(tr);

		}
		void AddRow(Table tab,string Label,string Caption,Color BackColor)
		{

			TableRow tr = new TableRow();
			TableCell td1 = new TableCell();
			TableCell td2 = new TableCell();

			td1.Text = Label;
			td1.HorizontalAlign = HorizontalAlign.Right;
			td1.BackColor		= BackColor;		

			td2.Text			= Caption;
			td2.HorizontalAlign = HorizontalAlign.Left ;
			td2.BackColor		= BackColor;

			td1.Style.Add("width","100px");			
			td2.Style.Add("width","300px");
			

			tr.Cells.Add(td1);
			tr.Cells.Add(td2);

			tab.Rows.Add(tr);

		}

		void AddRow(Table tab,string Label,Color BackColor)
		{

			TableRow tr = new TableRow();
			TableCell td = new TableCell();

			td.Text = Label;
			td.HorizontalAlign = HorizontalAlign.Center;
			td.BackColor = BackColor;

			tr.Cells.Add(td);

			tab.Rows.Add(tr);

		}

		void AddStep(Table tab,DataRow dd,int Step)
		{			
			Table		tt	= new Table();
			TableRow	tr	= new TableRow();
			TableCell	tc	= new TableCell();
			long		top	= 300+500 * Step;

			tt.HorizontalAlign = HorizontalAlign.Center;
			tt.Style.Add("left","100px");			
			tt.Style.Add("top",top.ToString() + "px");
			//tt.Style.Add("BORDER-COLLAPSE","collapse");
			tt.Style.Add("width","400px");
			tt.Style.Add("font-size","10pt");

			tt.BorderColor		= Color.FromArgb(0,0,0);
			tt.BorderWidth		= 1;

			

			AddRow(tt,"第" + Step.ToString() + "步",dd["step_name"].ToString(),Color.FromArgb(255,245,245));
			switch(dd["Flow_rule"].ToString())
			{
				case "0":
					AddRow(tt,"流程规则","按人员");
					break;
				case "1":
					AddRow(tt,"流程规则","按职位");
					break;
				case "2":
					AddRow(tt,"流程规则","按项目");
					break;
			}

			AddRow(tt,"强制结束",dd["RightToFinish"].ToString()=="True"?"能":"否");
			if(Int32.Parse(dd["passnum"].ToString())>0)
				AddRow(tt,"是否会签",dd["passnum"].ToString() + "人会签");
			else if(Int32.Parse(dd["passnum"].ToString())==0)
				AddRow(tt,"是否会签","不需要会签");
			else if(Int32.Parse(dd["passnum"].ToString())<0)
				AddRow(tt,"是否会签","全体通过！");

			tc.Controls.Add(tt);

			//添加条件跳转
			if(Int32.Parse(dd["jump_count"].ToString())>0)
			{
				UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();

				DataTable dt;
				df.GetJump(FlowID,Step,0,out dt);
				for(int i=0;i<dt.Rows.Count;i++)
				{
					AddRow(tt,"条件" + dt.Rows[i]["Priority"].ToString() ,dt.Rows[i]["Field_Description"].ToString() + dt.Rows[i]["compare"].ToString() + dt.Rows[i]["comparevalue"].ToString() + "<span lang='EN-US' style='font-family: Wingdings'>&eth;</span>" + dt.Rows[i]["step_name"].ToString());
				}

				df = null;
			}

			tr.Cells.Add(tc);

			tab.Rows.Add(tr);

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
