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

namespace UDS.SubModule.Schedule
{
	/// <summary>
	/// CalendarList 的摘要说明。
	/// </summary>
	public class CalendarView : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgList;
		protected static string Username;
		protected string Action;
		protected System.Web.UI.HtmlControls.HtmlTable  tblContainer;
		protected System.Web.UI.WebControls.Table Table1;
		protected System.Web.UI.WebControls.DropDownList listStaff;
		protected System.Web.UI.WebControls.LinkButton lnkbtnToday;
		protected System.Web.UI.WebControls.LinkButton lnkbtnHistory;
		protected System.Web.UI.WebControls.LinkButton lnkbtnFinished;
		protected System.Web.UI.WebControls.LinkButton lnkbtnReturn;
		protected System.Web.UI.WebControls.LinkButton lnkbtnAccept;
		protected System.Web.UI.WebControls.LinkButton lnkbtnCancel;
		protected System.Web.UI.WebControls.LinkButton lnkbtnFinish;
		protected System.Web.UI.WebControls.LinkButton lnkbtnAdd;
		protected System.Web.UI.WebControls.LinkButton lnkbtnNew;
		protected static int displayType=1;
		private void Page_Load(object sender, System.EventArgs e)
		{
			HttpCookie UserCookie = Request.Cookies["Username"];
            Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

			if(!Page.IsPostBack)
			{
				
				Action = Request.QueryString["Action"]!=null?Request.QueryString["Action"]:"1";
				this.tblContainer.Rows[0].Cells[0].Attributes.Add("background","../../images/maillistbutton2.gif");
				this.lnkbtnNew.Attributes["onclick"]= "var newwin=window.open('Manage.aspx','newtask','toolbar=yes,scrollbars=yes,width=800,height=600,resizable=yes');newwin.moveTo(0,0);newwin.focus();";
				if(Action=="1")
				{
				
					Task task = new Task();
					this.dgList.Visible = true;
					this.lnkbtnAccept .Visible = true;
					this.lnkbtnCancel.Visible = true;
					this.lnkbtnFinish .Visible = true;
					this.lnkbtnAdd.Visible = true;
					//this.lnkbtnAdd.Attributes.Add("onclick","return dialwinprocess('"+DateTime.Today.ToShortDateString()+"','8','1','0')");
					//this.lnkbtnAdd.Attributes.Add("onclick","self.location='CalendarView.aspx?Action=1';return true;");
					DataTable mydb = Tools.ConvertDataReaderToDataTable(task.GetTodayTaskBySomeone(DateTime.Today.ToShortDateString(),Username,1));
					this.dgList .DataSource = mydb.DefaultView;
					this.dgList.DataBind();
					setgrid();
					mydb.Dispose();
				}
			
				if(Action=="2")
				{
					Response.Write("<table width=\"49%\" border=\"1\" align=\"center\" class=\"top\"><tr><td width=\"2%\"  bgcolor=\"#A692F5\">&nbsp;</td>	<td width=\"18%\">未确认任务</td> <td width=\"2%\" bgcolor=\"BlanchedAlmond\">&nbsp;</td> <td width=\"18%\">已确认任务</td></tr></table>");
					this.dgList.Visible = false;
					this.lnkbtnAccept .Visible = false;
					this.lnkbtnCancel .Visible = false;
					this.lnkbtnFinish .Visible = false;
					this.lnkbtnAdd.Visible = false;
					this.lnkbtnToday .Visible = false;
					this.lnkbtnHistory.Visible = false;
					this.lnkbtnFinished .Visible = false;
					this.tblContainer.Rows[0].Cells[1].Attributes.Add("background","");
					this.tblContainer.Rows[0].Cells[0].Attributes.Add("background","");
					this.tblContainer.Rows[0].Cells[2].Attributes.Add("background","");
					System.Globalization.DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek = System.DayOfWeek.Monday;
					System.Globalization.DateTimeFormatInfo.CurrentInfo.DayNames=new String[]{"七","一","二","三","四","五","六"};
					PopulateListView();
					PopulateDateToTable(DateTime.Today.AddDays(-(Convert.ToInt32(DateTime.Today.DayOfWeek))+1),6);
					this.lnkbtnReturn .Visible = true;
					
				}
				//Response.Write(DateTime.Today.AddDays(-(Convert.ToInt32(DateTime.Today.DayOfWeek))+1).ToShortDateString()); 
			}
			else
			{
//				if(Page.FindControl("Table1").ID=="")
				//PopulateDateToTable(Calendar1.SelectedDate ,Calendar1.SelectedDates .Count);
				
				
			}
			//Response.Write(Calendar1.SelectedDate .ToShortDateString());
			
		}
	
	

		

		#region 初始化下拉列表框
		/// <summary>
		/// 对下拉列表进行初始化
		/// </summary>
		private void PopulateListView() 
		{
			
			#region 协同人员列表初始化
			UDS.Components .Staff staff = new UDS.Components .Staff();
			try
			{
				listStaff.DataTextField = "RealName";
				listStaff.DataValueField = "Staff_Name";
				listStaff.DataSource =  staff.GetStaffFromPosition(Username);
				listStaff.DataBind();
				listStaff.Items.Insert(0,new ListItem("本人的日程记录","0"));
				listStaff.SelectedIndex = 0;
			}
			catch(Exception e)
			{
				UDS.Components.Error.Log(e.ToString());
				Server.Transfer("../Error.aspx");
			}
			finally
			{
				staff = null;
			}
			#endregion
			
		}
		#endregion

		public class demodat
		{
			private int m_StartTime;
			private int m_EndTime;	
				
			public int StartTime 
			{	
				//文件ID
				get { return m_StartTime; }
				set { m_StartTime = value; }
			}

			public int EndTime 
			{	
				//文档ID
				get { return m_EndTime; }
				set { m_EndTime = value; }
			}
			
		}

		public void PopulateDateToTable(DateTime sDate,int dayCount)
		{
		    
			if(this.listStaff.SelectedIndex!=0)
			{
				Username = this.listStaff .SelectedItem.Value;
			}
			
			Task task = new Task();
			int[][] TaskData = new int[5][];
			
			// 初始化天数据至ArrayList
			//			ArrayList demoDayData = new ArrayList();	
			//			demoDayData.Add(9);
			//			demoDayData.Add(10);
			//			demoDayData.Add(11);
			//			demoDayData.Add(12);
			
			
//			int[][] TaskData = new int[5][];  //每日的任务数据
//			TaskData[0] = new int[]{0,0,0,0,0,13,14,15,16,17,18};
//			TaskData[1] = new int[]{8,9,10,11,0,0,0,0,0,0,0};
//			TaskData[2] = new int[]{0,9,10,11,12,13,0,0,0,0,0};
//			TaskData[3] = new int[]{8,9,10,11,12,13,14,15,0,0,0};
//			TaskData[4] = new int[]{0,0,0,0,0,0,0,0,0,17,18};
			//			demoData[5] = new int[]{0,0,0,0,0,0,0,0};
			//			demoData[6] = new int[]{0,0,0,0,0,0,0,0};
			//			demoData[7] = new int[]{0,0,0,0,0,0,0,0};
			// 生成行和单元格
			ArrayList DaySch = new ArrayList(dayCount+1);//根据选择的天数生成数组 加1是因为会增加一信息列
			ArrayList DayTask = new ArrayList(dayCount+1); //记录每天的前五条任务ID
			DaySch.Add(new int[5][]);  //加入一个废列
			DayTask.Add(new String[5]);
			for(int p=0;p<dayCount;p++)
			{
				TaskData = new int[5][];
				string tmpDate = sDate.AddDays(p).ToString();
				String[] a = new String[5];
				a = task.GetTop5DayTaskList(tmpDate,Username);

			//	TaskData[0] = new int[]{0,0,0,0,0,13,14,15,16,17,18};
//				TaskData[1] = new int[]{8,9,10,11,0,0,0,0,0,0,0};
//				TaskData[2] = new int[]{0,9,10,11,12,13,0,0,0,0,0};
//				TaskData[3] = new int[]{8,9,10,11,12,13,14,15,0,0,0};
//				TaskData[4] = new int[]{0,0,0,0,0,0,0,0,0,17,18};
				for(int k=0;k<a.Length;k++)
				{
					TaskData[k] = task.GetTaskPeriod(tmpDate,Username,Int32.Parse(a[k].ToString()));
				}
				DaySch.Add(TaskData);
				DayTask.Add(a);			
			}
			
			
		
			
			int numcells = dayCount;
			int startTimeNo = 8;	
			SqlDataReader dataReader = null;
			dataReader =  task.GetPeriodInfo();
			ArrayList period = new ArrayList();
            try
            {
                while (dataReader.Read())
                    period.Add(dataReader[1].ToString());
            }
            finally
            {
                dataReader.Close();
            }
			int numrows = period.Count;
			
			
			//  初始化表头
			#region 初始化表头
			TableRow r = new TableRow();
			TableCell c = null;
			for (int i=0; i<numcells+1; i++) 
			{
				
				string s = sDate.AddDays(i-1).ToShortDateString()==DateTime.Today.ToShortDateString()?"<font color=red><b>"+DateTime.Today.ToShortDateString()+"</b></font>":sDate.AddDays(i-1).ToShortDateString();
				
				c = new TableCell();
				c.CssClass = "top";
				c.Controls.Add(new LiteralControl((i==0)?"&nbsp;&nbsp; 时段&nbsp;&nbsp;&nbsp;    ":s+"&nbsp;&nbsp;&nbsp;"+UDS.Components.Tools.ConvertDayOfWeekToZh(sDate.AddDays(i-1).DayOfWeek)));	
				r.Cells.Add(c);
			}
			#endregion
			//			Table1.CellPadding = 0;
			//			Table1.CellSpacing = 0;
			Table1.Rows.Add(r);
			// 初始化表头结束

			// 根据时间段共生成8行
			for (int j=0; j<numrows; j++) 
			{
            
				r = new TableRow();
                
				// 每行根据选择的天数生成列
				for (int i=0; i<dayCount+1; i++) 
				{
					
					c = new TableCell();
					
					Table newtable = new Table();
					
					if (i==0)
						if(j%2==0)
						{
							string []a = period[j].ToString().Split('-');
							c.Controls.Add(new LiteralControl("<div style='position:absolute; width:86px; height:76px; z-index:1'><font size=5>"+a[0].ToString()+"</font></div>"));
						}
						else
							c.Controls.Add(new LiteralControl("-"));
					else
					{ //如果不是第一列
					
						//					newtable.BorderWidth = 0;
						//newtable.GridLines = System.Web.UI.WebControls .GridLines.Vertical;
						// 在某列中新table设置开始
						newtable = new Table();
						TableRow nr = new TableRow();
			
						#region 颜色代码
						ArrayList colorlist = new ArrayList(5);
						Random ro=new Random();
						string[] colorArray = task.GetTop5ConfirmedTaskList(sDate.AddDays(i-1).ToShortDateString(),Username);
						for(int p=0;p<colorArray.Length;p++)
						{
							//				int ca = ro.Next(0,255);
							//				int cb = ro.Next(0,255);
							//				int cc = ro.Next(0,255);
							//				colorlist.Add(System.Drawing.Color.FromArgb(ca,cb,cc));
							if(colorArray[p].ToString()=="0")
								colorlist.Add(Color.FromName("#A692F5"));
							else
								colorlist.Add(Color.BlanchedAlmond);

						}
						#endregion	
		
					
						for(int q=0;q<TaskData.Length;q++)
						{
							
							
							int[][] tmp =  (int[][])DaySch[i];
							String[] a = (String[])DayTask[i];
							TableCell nc = new TableCell();
							
							

							if(Int32.Parse(tmp[q][j].ToString())!=0)
							{
								nc.Controls.Add(new LiteralControl("*"));
								nc.BackColor=(System.Drawing.Color)colorlist[q];
								nc.Attributes.Add("onclick","return dialwinprocess('"+sDate.AddDays(i-1).ToShortDateString()+"','"+(startTimeNo+j).ToString()+"','2','"+a[q]+"')");
								nc.Style.Add("cursor","hand");
							

							}
							else
							{
								
							    nc.Controls.Add(new LiteralControl("<font color=#FFF8F7>0</font>"));
							    nc.BackColor=Color.FromName("#FFF8F7");
								nc.Attributes.Add("onclick","return dialwinprocess('"+sDate.AddDays(i-1).ToShortDateString()+"','"+(startTimeNo+j).ToString()+"','1','0')");
								nc.Attributes.Add("OnMouseOver","return high( this );");
								nc.Attributes.Add("OnMouseOut","return low( this );");
								//nc.Attributes.Add("onclick","return dialwinprocess('"+q.ToString()+j.ToString()+tmp[q][j].ToString()+"')");
								nc.Style.Add("cursor","hand");
								//							System.Drawing.ColorConverter cc=new System.Drawing.ColorConverter();
								//							newtable.BackColor=(System.Drawing.Color)cc.ConvertFromString("#FF9900");
								//						
							}
							nr.Cells.Add(nc);
				
						}					
					
					
						newtable.CellPadding = 1;
						newtable.CellSpacing = 1;
						newtable.GridLines = System.Web.UI.WebControls .GridLines.Both;
						newtable.BorderWidth = 0;
						newtable.Rows.Add(nr);
						// 新table设置结束
				
						c.Controls.Add(newtable);
					}

					r.Cells.Add(c);
				}
				Table1.CellPadding = 1;
				Table1.CellSpacing = 1;
				Table1.GridLines = System.Web.UI.WebControls .GridLines.Horizontal;
				Table1.BorderWidth = 1;
				Table1.Rows.Add(r);
				
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
			this.lnkbtnToday.Click += new System.EventHandler(this.lnkbtnToday_Click);
			this.lnkbtnHistory.Click += new System.EventHandler(this.lnkbtnHistory_Click);
			this.lnkbtnFinished.Click += new System.EventHandler(this.lnkbtnFinished_Click);
			this.lnkbtnReturn.Click += new System.EventHandler(this.lnkbtnReturn_Click);
			this.lnkbtnNew.Click += new System.EventHandler(this.lnkbtnNew_Click);
			this.lnkbtnAccept.Click += new System.EventHandler(this.lnkbtnAccept_Click);
			this.lnkbtnCancel.Click += new System.EventHandler(this.lnkbtnCancel_Click);
			this.lnkbtnFinish.Click += new System.EventHandler(this.lnkbtnFinish_Click);
			this.lnkbtnAdd.Click += new System.EventHandler(this.lnkbtnAdd_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public string GetStatus(string str)
		{
			
			switch (str) {
			case "0":
					return "?"; // 待定
			case "1":
					return "!"; // 待办
			case "2":
					return "√"; // 完成
			default:
					return "";
			}
			

		}

		public string GetPeriodByPeriodID(string begintime,string endtime)
		{
			int b = Int32.Parse(begintime);
			int e = Int32.Parse(endtime);
			DateTime dt = new DateTime(1999,1,1,8,0,0,0);
			TimeSpan ts = new TimeSpan(0,0,(b-1)*30,0,0);
			DateTime bt = dt.Add(ts);
			DateTime et = bt.Add(new TimeSpan(0,0,(e-b+1)*30,0,0));
			return bt.ToShortTimeString()+"----"+et.ToShortTimeString();
			
		}
		
	
		private void setgrid()
		{
			foreach(DataGridItem dgi in this.dgList .Items)
			{
				Label lb=(Label)(dgi.Cells[4].Controls[1]);
				if(lb.Text=="?") dgi.BackColor=Color.AliceBlue ;
			}
		}
		
		#region 翻页事件
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			this.dgList .CurrentPageIndex = e.NewPageIndex;
			Task task = new Task();
			DataTable mydb = Tools.ConvertDataReaderToDataTable(task.GetTodayTaskBySomeone(DateTime.Today.ToShortDateString(),Username,displayType));
			this.dgList .DataSource = mydb.DefaultView;
			this.dgList.DataBind();
			setgrid();
			
		}
		#endregion

		private void btnChart_Click(object sender, System.EventArgs e)
		{
			//　打印图示代码
			Response.Write("<table width=\"49%\" border=\"1\" align=\"center\" class=\"top\"><tr><td width=\"2%\"  bgcolor=\"#A692F5\">&nbsp;</td>	<td width=\"18%\">未确认任务</td> <td width=\"2%\" bgcolor=\"BlanchedAlmond\">&nbsp;</td> <td width=\"18%\">已确认任务</td></tr></table>");
			this.dgList.Visible = false;
			this.lnkbtnAccept .Visible = false;
			this.lnkbtnCancel .Visible = false;
			this.lnkbtnFinish .Visible = false;
			this.lnkbtnAdd.Visible = false;
			System.Globalization.DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek = System.DayOfWeek.Monday;
			System.Globalization.DateTimeFormatInfo.CurrentInfo.DayNames=new String[]{"七","一","二","三","四","五","六"};
			PopulateListView();
			PopulateDateToTable(DateTime.Today.AddDays(-(Convert.ToInt32(DateTime.Today.DayOfWeek))+1),6);
					
		}

	
		private void btnList_Click(object sender, System.EventArgs e)
		{
			Task task = new Task();
			this.dgList.Visible = true;
			this.lnkbtnCancel .Visible = true;
			this.lnkbtnFinish .Visible = true;
			this.lnkbtnAccept .Visible = true;
			this.lnkbtnAdd.Visible = true;
			DataTable mydb = Tools.ConvertDataReaderToDataTable(task.GetTodayTaskBySomeone(DateTime.Today.ToShortDateString(),Username,1));
			this.dgList .DataSource = mydb.DefaultView;
			this.dgList.DataBind();
			setgrid();
			mydb.Dispose();
		}

		private void lnkbtnAccept_Click(object sender, System.EventArgs e)
		{
			string ids = "";
			foreach(DataGridItem dgi in this.dgList .Items)
			{
				CheckBox cb=(CheckBox)(dgi.Cells[0].Controls[1]);
				if (cb.Checked==true)
				{
					ids += dgList.DataKeys[dgi.ItemIndex].ToString()+",";				
				}	
			}
			
			if(ids!="")
			{
				ids = ids.Substring(0,ids.Length-1);
				Task task = new Task();
				try
				{
					task.DealTask(ids,1,Username,DateTime.Today.ToShortDateString());
					Response.Write("<script language=javascript>alert('操作成功!');window.location='CalendarView.aspx?Action=1';</script>");
					//Response.AddHeader("Refresh","1");
				}
				catch(Exception ex)
				{
					UDS.Components .Error.Log(ex.ToString());
					Server.Transfer("../Error.aspx");
				}
			}
		}

		private void lnkbtnCancel_Click(object sender, System.EventArgs e)
		{
			string ids = "";
			foreach(DataGridItem dgi in this.dgList .Items)
			{
				CheckBox cb=(CheckBox)(dgi.Cells[0].Controls[1]);
				if (cb.Checked==true)
				{
					ids += dgList.DataKeys[dgi.ItemIndex].ToString()+",";				
				}	
			}
			
			if(ids!="")
			{
				ids = ids.Substring(0,ids.Length-1);
				Task task = new Task();
				try
				{
					task.DealTask(ids,0,Username,DateTime.Today .ToShortDateString());
					Response.Write("<script language=javascript>alert('操作成功!');window.location='CalendarView.aspx?Action=1';</script>");
					//Response.AddHeader("Refresh","1");
				}
				catch(Exception ex)
				{
					UDS.Components .Error.Log(ex.ToString());
					Server.Transfer("../Error.aspx");
				}
			}
		
		}

		private void lnkbtnFinish_Click(object sender, System.EventArgs e)
		{
			string ids = "";
			foreach(DataGridItem dgi in this.dgList .Items)
			{
				CheckBox cb=(CheckBox)(dgi.Cells[0].Controls[1]);
				if (cb.Checked==true)
				{
					ids += dgList.DataKeys[dgi.ItemIndex].ToString()+",";				
				}	
			}
			
			if(ids!="")
			{
				ids = ids.Substring(0,ids.Length-1);
				Task task = new Task();
				try
				{
					task.DealTask(ids,2,Username,DateTime.Today.ToShortDateString());
					Response.Write("<script language=javascript>alert('操作成功!');window.location='CalendarView.aspx?Action=1';</script>");
					//Response.AddHeader("Refresh","1");
				}
				catch(Exception ex)
				{
					UDS.Components .Error.Log(ex.ToString());
					Server.Transfer("../Error.aspx");
				}
			}
		
		}

		private void lnkbtnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("CalendarView.aspx?Action=2");
		}

		private void lnkbtnReturn_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("CalendarView.aspx?Action=1");
		}

		private void lnkbtnToday_Click(object sender, System.EventArgs e)
		{
			this.tblContainer.Rows[0].Cells[0].Attributes.Add("background","../../images/maillistbutton2.gif");
			this.tblContainer.Rows[0].Cells[1].Attributes.Add("background","../../images/maillistbutton1.gif");
			this.tblContainer.Rows[0].Cells[2].Attributes.Add("background","../../images/maillistbutton1.gif");
			Task task = new Task();
			DataTable mydb = Tools.ConvertDataReaderToDataTable(task.GetTodayTaskBySomeone(DateTime.Today.ToShortDateString(),Username,1));
			this.dgList .DataSource = mydb.DefaultView;
			this.dgList.DataBind();
			setgrid();
			mydb.Dispose();
			displayType = 1;
		}

		private void lnkbtnHistory_Click(object sender, System.EventArgs e)
		{
			this.tblContainer.Rows[0].Cells[1].Attributes.Add("background","../../images/maillistbutton2.gif");
			this.tblContainer.Rows[0].Cells[0].Attributes.Add("background","../../images/maillistbutton1.gif");
			this.tblContainer.Rows[0].Cells[2].Attributes.Add("background","../../images/maillistbutton1.gif");
			Task task = new Task();
			DataTable mydb = Tools.ConvertDataReaderToDataTable(task.GetTodayTaskBySomeone(DateTime.Today.ToShortDateString(),Username,2));
			this.dgList .DataSource = mydb.DefaultView;
			this.dgList.DataBind();
			setgrid();
			mydb.Dispose();
			displayType = 2;
		}

		private void lnkbtnFinished_Click(object sender, System.EventArgs e)
		{
			this.tblContainer.Rows[0].Cells[2].Attributes.Add("background","../../images/maillistbutton2.gif");
			this.tblContainer.Rows[0].Cells[0].Attributes.Add("background","../../images/maillistbutton1.gif");
			this.tblContainer.Rows[0].Cells[1].Attributes.Add("background","../../images/maillistbutton1.gif");
			Task task = new Task();
			DataTable mydb = Tools.ConvertDataReaderToDataTable(task.GetTodayTaskBySomeone(DateTime.Today.ToShortDateString(),Username,3));
			this.dgList .DataSource = mydb.DefaultView;
			this.dgList.DataBind();
		//	setgrid();
			mydb.Dispose();
			displayType = 3;
		}

		private void lnkbtnNew_Click(object sender, System.EventArgs e)
		{
			//Response.Redirect("Manage.aspx");
		}

		

		
	}
}
