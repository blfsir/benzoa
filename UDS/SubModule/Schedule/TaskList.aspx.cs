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
	/// TaskList 的摘要说明。
	/// </summary>
	public class TaskList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgList;
		public  string Username="",ActualUsername="";
		protected string Action;
		protected System.Web.UI.HtmlControls.HtmlTable  tblContainer;
		protected System.Web.UI.WebControls.LinkButton lnkbtnToday;
		protected System.Web.UI.WebControls.LinkButton lnkbtnHistory;
		protected System.Web.UI.WebControls.LinkButton lnkbtnFinished;
		protected System.Web.UI.WebControls.Button btnNew;
		protected System.Web.UI.WebControls.Button btnAccept;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.DropDownList listStaff;
		protected System.Web.UI.WebControls.Button btnSubscribe;
		protected System.Web.UI.WebControls.LinkButton Linkbutton1;
		protected System.Web.UI.WebControls.Table Table1;
		protected System.Web.UI.WebControls.Button btnWeeklyView;
		protected System.Web.UI.WebControls.Label lblInstru;
		public static int displayType;
		protected System.Web.UI.WebControls.Button btnCancelSubscription;
		protected System.Web.UI.WebControls.LinkButton lnkbtnArranged;
		public static string SchBeginDate;
		private void Page_Load(object sender, System.EventArgs e)
		{			
			
			if(!Page.IsPostBack)
			{
				HttpCookie UserCookie = Request.Cookies["Username"];
				if(Session["Username"]==null)
				{
                    Session["Username"] = Server.UrlDecode(UserCookie.Value);
				}
                ActualUsername = Server.UrlDecode(UserCookie.Value);// UserCookie.Value.ToString();	
				Session["ActualUsername"] = ActualUsername;
				Username = (string)Session["Username"];

				populateData();
				SetStatus();	
				displayType  = Request.QueryString["displayType"]!=null?Int32.Parse(Request.QueryString["displayType"]):1;
				SchBeginDate = Request.QueryString["SchBeginDate"]!=null?Request.QueryString["SchBeginDate"]:DateTime.Today.AddDays(-(Convert.ToInt32(DateTime.Today.DayOfWeek))+1).ToShortDateString();
				if(Request.QueryString["SchBeginDate"]!=null)
				{
					this.lnkbtnFinished .Enabled = false;
					this.lnkbtnHistory .Enabled  = false;
					this.lnkbtnToday .Enabled	 = false;
					this.Linkbutton1.Enabled	 = false;
					this.btnAccept .Enabled		 = false;
					this.btnCancel.Enabled	     = false;
					this.btnNew .Enabled		 = false;
					this.lnkbtnArranged .Enabled = false;
					this.btnWeeklyView .Text	 = "返回";
					PopulateWeeklyData();
				
				}
				else
				{
					InitData();
				}
				
				
				//Response.Write(DateTime.Today.AddDays(-(Convert.ToInt32(DateTime.Today.DayOfWeek))+1).ToShortDateString()); 
			}
			else
			{
			
				//				if(Page.FindControl("Table1").ID=="")
				//PopulateDateToTable(Calendar1.SelectedDate ,Calendar1.SelectedDates .Count);
				
				
			}
	
			//Response.Write(Session["Username"].ToString());
		
		}

		private void InitData()
		{
			Username = (string)Session["Username"];

			this.tblContainer.Rows[0].Cells[0].Attributes.Add("background","../../images/maillistbutton2.gif");
			this.btnNew.Attributes["onclick"]= "var newwin=window.open('Manage.aspx','newtask','toolbar=yes,scrollbars=yes,width=800,height=600,resizable=yes');newwin.moveTo(0,0);newwin.focus();";
				
				
			Task task = new Task();
			this.dgList.Visible = true;
			this.btnAccept .Visible = true;
			this.btnCancel.Visible = true;
			
			//this.lnkbtnAdd.Attributes.Add("onclick","return dialwinprocess('"+DateTime.Today.ToShortDateString()+"','8','1','0')");
			//this.lnkbtnAdd.Attributes.Add("onclick","self.location='CalendarView.aspx?Action=1';return true;");
			DataTable mydb = Tools.ConvertDataReaderToDataTable(task.GetAllTaskBySomeone(DateTime.Today.ToShortDateString(),Username,displayType));
			this.dgList .DataSource = mydb.DefaultView;
			this.dgList.DataBind();
			setgrid();
			mydb.Dispose();
			for(int t=0;t<4;t++)
			{
				if(t==displayType-1)
					this.tblContainer.Rows[0].Cells[t].Attributes.Add("background","../../images/maillistbutton2.gif");
				else
					this.tblContainer.Rows[0].Cells[t].Attributes.Add("background","../../images/maillistbutton1.gif");
			}
		}

		private void PopulateWeeklyData()
		{
			this.dgList .Visible = false;
			this.lblInstru .Visible = false;
			this.Table1 .Visible = true;
		
			

			this.Table1.Rows.Clear();
			//Response.Write("<table width=\"49%\" border=\"1\" align=\"center\" class=\"top\"><tr><td width=\"2%\"  bgcolor=\"#A692F5\">&nbsp;</td>	<td width=\"18%\">未确认任务</td> <td width=\"2%\" bgcolor=\"BlanchedAlmond\">&nbsp;</td> <td width=\"18%\">已确认任务</td></tr></table>");
			//System.Globalization.DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek = System.DayOfWeek.Monday;
			//System.Globalization.DateTimeFormatInfo.CurrentInfo.DayNames=new String[]{"七","一","二","三","四","五","六"};
			PopulateDateToTable(DateTime.Parse(SchBeginDate),6);
		}


		#region 绑定数据至表格
		public void PopulateDateToTable(DateTime sDate,int dayCount)
		{
			
			string Username = (string)Session["Username"];
			string[] UnameStr = System.Text.RegularExpressions.Regex.Split(Username,",");					
			Task task = new Task();
		
			#region 初始化日程数据	
			int[][] TaskData = new int[1][];
			Hashtable htcolorlist = new Hashtable();
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
				a = task.GetTop5DayTaskList(tmpDate,UnameStr[0].ToString());

				//	TaskData[0] = new int[]{0,0,0,0,0,13,14,15,16,17,18};
				//				TaskData[1] = new int[]{8,9,10,11,0,0,0,0,0,0,0};
				//				TaskData[2] = new int[]{0,9,10,11,12,13,0,0,0,0,0};
				//				TaskData[3] = new int[]{8,9,10,11,12,13,14,15,0,0,0};
				//				TaskData[4] = new int[]{0,0,0,0,0,0,0,0,0,17,18};
				for(int k=0;k<a.Length;k++)
				{
					TaskData[k] = task.GetTaskPeriod(tmpDate,UnameStr[0],Int32.Parse(a[k].ToString()));
				}
				DaySch.Add(TaskData);
				DayTask.Add(a);			
			}
			
			#endregion
		
			
			int numcells = dayCount;
			//	int startTimeNo = 8;	
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
		
			TableRow r = new TableRow();
			// 生成一个第一列，列头为时间
			TableCell c = null;
					
			if(Username!="")
			{
			
				
				for (int i=0; i<numcells+1; i++) 
				{
				
					string s = sDate.AddDays(i-1).ToShortDateString()==DateTime.Today.ToShortDateString()?"<font color=white><b>"+DateTime.Today.ToShortDateString()+"</b></font>":sDate.AddDays(i-1).ToShortDateString();
					LiteralControl lc = new LiteralControl((i==0)?"<font color=white>&nbsp;&nbsp; 时段&nbsp;&nbsp;&nbsp;    ":"<font color=white>"+s+"&nbsp;&nbsp;&nbsp;"+UDS.Components.Tools.ConvertDayOfWeekToZh(sDate.AddDays(i-1).DayOfWeek)+"</font>");
					if(i==numcells)
						lc.Text +="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href=tasklist.aspx?SchBeginDate="+DateTime.Parse(SchBeginDate).AddDays(-7).ToShortDateString()+"><font color=white size=3><</font></a>&nbsp;&nbsp;&nbsp; <a href=tasklist.aspx?SchBeginDate="+DateTime.Parse(SchBeginDate).AddDays(7).ToShortDateString()+"><font color=white size=3>></font></a>";
					c = new TableCell();
					c.CssClass = "top";
					c.BackColor = Color.FromName("#337FB2");
					c.Controls.Add(lc);	
					r.Cells.Add(c);
				}
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
								c.Controls.Add(new LiteralControl("<div style='position:absolute; width:86px; height:76px; z-index:1'><font size=3>"+a[0].ToString()+"</font></div>"));
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
			
							for(int q=0;q<TaskData.Length;q++)
							{
								
								int[][] tmp =  (int[][])DaySch[i];
								String[] a = (String[])DayTask[i];
								TableCell nc = new TableCell();
								
								bool flag=false;
							//	string col = "";
								string taskid = "";
								
								
								//　遍历五个任务时间数组，看有没有被占
								for(int co=0;co<TaskData.Length;co++)
								{
									if(Int32.Parse(tmp[co][j].ToString())!=0)
									{	
										flag = true;
										taskid = a[co].ToString();
									}
								}
							
								if(flag)
								{
								
									nc.Controls.Add(new LiteralControl("<font color=#C597DD>0"+"</font>"));
									nc.BackColor=Color.FromName("#C597DD");
									nc.Style.Add("cursor","hand");
										nc.Attributes.Add("onclick","return dialwinprocess('"+sDate.AddDays(i-1).ToShortDateString()+"','"+(8+j).ToString()+"','2','"+taskid+"')");
							

								}
								else
								{
								
									nc.Controls.Add(new LiteralControl("<font color=#FFFFFF>0</font>"));
								
								}
								nr.Cells.Add(nc);
				
							}					
					
					
							newtable.CellPadding = 0;
							newtable.CellSpacing = 0;
							newtable.GridLines = System.Web.UI.WebControls .GridLines.Both;
							newtable.BorderWidth = 0;
							newtable.Rows.Add(nr);
							// 新table设置结束
				
							c.Controls.Add(newtable);
						}

						r.Cells.Add(c);
					}
					Table1.CellPadding = 0;
					Table1.CellSpacing = 0;
					Table1.GridLines = System.Web.UI.WebControls .GridLines.Horizontal;
					Table1.BorderWidth = 1;
					Table1.Rows.Add(r);
				
				}

			}
		
		}

		#endregion

		public void SetStatus()
		{
			string Username = (string)Session["Username"];
			string ActualUsername = (string)Session["ActualUsername"];
			
			this.btnAccept.Enabled = (Username.ToLower()==ActualUsername.ToLower());
			this.btnCancel.Enabled = (Username.ToLower()==ActualUsername.ToLower());
		
			this.btnNew.Enabled	   = (Username.ToLower()==ActualUsername.ToLower());
			this.btnSubscribe.Visible = (Username.ToLower()!=ActualUsername.ToLower());
			
			this.btnSubscribe.Enabled = (Username.ToLower()!=ActualUsername.ToLower());
		
		}
		
		public void populateData()
		{
			#region 协同人员列表初始化
			string Username = (string)Session["Username"];
			UDS.Components .Staff staff = new UDS.Components .Staff();
			try
			{
				listStaff.DataTextField = "RealName";
				listStaff.DataValueField = "Staff_Name";
				listStaff.DataSource =  staff.GetStaffFromPosition(ActualUsername);
				listStaff.DataBind();
				foreach(ListItem li in listStaff.Items)
				{
					if(li.Value.ToLower() ==Username.ToLower())
					{
						li.Selected =true;
					}
				}
//				listStaff.SelectedItem .Value = Username;
//				listStaff.SelectedItem .Text = UDS.Components .Staff.GetRealNameByUsername(Username);
				
				
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
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
			this.listStaff.SelectedIndexChanged += new System.EventHandler(this.listStaff_SelectedIndexChanged);
			this.lnkbtnToday.Click += new System.EventHandler(this.lnkbtnToday_Click);
			this.lnkbtnHistory.Click += new System.EventHandler(this.lnkbtnHistory_Click);
			this.lnkbtnFinished.Click += new System.EventHandler(this.lnkbtnFinished_Click);
			this.Linkbutton1.Click += new System.EventHandler(this.Linkbutton1_Click);
			this.lnkbtnArranged.Click += new System.EventHandler(this.lnkbtnArranged_Click);
			this.btnWeeklyView.Click += new System.EventHandler(this.btnWeeklyView_Click);
			this.btnCancelSubscription.Click += new System.EventHandler(this.btnCancelSubscription_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public string GetStatus(string str)
		{
			
			switch (str) 
			{
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

		public string GetPeriodByPeriodID(string EndTime,string begintime,string endtime)
		{
			if(begintime=="0"&&endtime=="0")
			{
				return DateTime.Parse(EndTime).ToShortTimeString()+"(截止)";
			}
			else if(begintime=="1"&&endtime=="20")
			{
				return "(全天)";
			}
			else
			{
			
				
				int b = Int32.Parse(begintime);
				int e = Int32.Parse(endtime);
				DateTime dt = new DateTime(1999,1,1,8,0,0,0);
				TimeSpan ts = new TimeSpan(0,0,(b-1)*30,0,0);
				DateTime bt = dt.Add(ts);
				DateTime et = bt.Add(new TimeSpan(0,0,(e-b+1)*30,0,0));
				return bt.ToShortTimeString()+"-"+et.ToShortTimeString();
			}
			
		}
		
		public string GetRealName(string Username)
		{
			if(Username!="")
				return UDS.Components.Staff.GetRealNameByUsername(Username);
			else
				return "";
		}

		public string GetRealNameStr(string Username)
		{
			if(Username!="")
				return UDS.Components.Staff.GetRealNameStrByUsernameStr(Username,3);
			else
				return "";
		}


		public string GetType(string type)
		{
			string Type="";
			if(type!="")
			{
				switch (Int32.Parse(type)) 
				{
					case 1:
						Type="会议";
						break;
					case 2:
						Type="文案";
						break;
					case 3:
						Type="来访";
						break;
					case 4:
						Type="电话";
						break;
					case 5:
						Type="走访";
						break;
					case 6:
						Type="外出";
						break;
					case 7:
						Type="假期";
						break;
					case 8:
						Type="出差";
						break;
			
				}
				return Type;
			}
			else
				return "";

		}

		public string GetProjectName(string project)
		{
			if(project!="")
				return UDS.Components .ProjectClass .GetProjectName (Int32.Parse(project));
			else
				return "";
		}

		private void setgrid()
		{
			foreach(DataGridItem dgi in this.dgList .Items)
			{
				Label lb=(Label)(dgi.Cells[3].Controls[1]);
				if(lb.Text=="?") dgi.BackColor=Color.AliceBlue ;
			}
		}
		
		#region 翻页事件
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			Username = (string)Session["Username"];
			this.dgList .CurrentPageIndex = e.NewPageIndex;
			Task task = new Task();
			DataTable mydb = Tools.ConvertDataReaderToDataTable(task.GetAllTaskBySomeone(DateTime.Today.ToShortDateString(),Username,displayType));
			this.dgList .DataSource = mydb.DefaultView;
			this.dgList.DataBind();
			setgrid();
		}
		#endregion

	
	
		private void btnList_Click(object sender, System.EventArgs e)
		{
			string Username = (string)Session["Username"];
			Task task = new Task();
			this.dgList.Visible = true;
			this.btnCancel .Visible = true;
			this.btnAccept .Visible = true;
			DataTable mydb = Tools.ConvertDataReaderToDataTable(task.GetTodayTaskBySomeone(DateTime.Today.ToShortDateString(),Username,1));
			this.dgList .DataSource = mydb.DefaultView;
			this.dgList.DataBind();
			setgrid();
			mydb.Dispose();
		}

		private void lnkbtnAccept_Click(object sender, System.EventArgs e)
		{
			string Username = (string)Session["Username"];
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
					Response.Write("<script language=javascript>alert('操作成功!');window.location='TaskList.aspx';</script>");
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
			string Username = (string)Session["Username"];
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
					Response.Write("<script language=javascript>alert('操作成功!');window.location='TaskList.aspx';</script>");
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
			string Username = (string)Session["Username"];
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
					Response.Write("<script language=javascript>alert('操作成功!');window.location='TaskList.aspx';</script>");
					//Response.AddHeader("Refresh","1");
				}
				catch(Exception ex)
				{
					UDS.Components .Error.Log(ex.ToString());
					Server.Transfer("../Error.aspx");
				}
			}
		
		}


	

		private void lnkbtnToday_Click(object sender, System.EventArgs e)
		{
			string Username = (string)Session["Username"];
			this.btnCancelSubscription.Visible = false;
			this.btnCancel.Visible = true;
			displayType = 1;
			this.tblContainer.Rows[0].Cells[0].Attributes.Add("background","../../images/maillistbutton2.gif");
			this.tblContainer.Rows[0].Cells[1].Attributes.Add("background","../../images/maillistbutton1.gif");
			this.tblContainer.Rows[0].Cells[2].Attributes.Add("background","../../images/maillistbutton1.gif");
			this.tblContainer.Rows[0].Cells[3].Attributes.Add("background","../../images/maillistbutton1.gif");
			this.tblContainer.Rows[0].Cells[4].Attributes.Add("background","../../images/maillistbutton1.gif");
			Task task = new Task();
			DataTable mydb = Tools.ConvertDataReaderToDataTable(task.GetAllTaskBySomeone(DateTime.Today.ToShortDateString(),Username,displayType));
			this.dgList .DataSource = mydb.DefaultView;
			this.dgList.DataBind();
			setgrid();
			mydb.Dispose();
			
		}

		private void lnkbtnHistory_Click(object sender, System.EventArgs e)
		{
			string Username = (string)Session["Username"];
			this.btnCancelSubscription.Visible = false;
			this.btnCancel.Visible = true;
			displayType = 2;
			this.tblContainer.Rows[0].Cells[1].Attributes.Add("background","../../images/maillistbutton2.gif");
			this.tblContainer.Rows[0].Cells[0].Attributes.Add("background","../../images/maillistbutton1.gif");
			this.tblContainer.Rows[0].Cells[2].Attributes.Add("background","../../images/maillistbutton1.gif");
			this.tblContainer.Rows[0].Cells[3].Attributes.Add("background","../../images/maillistbutton1.gif");
			this.tblContainer.Rows[0].Cells[4].Attributes.Add("background","../../images/maillistbutton1.gif");
			Task task = new Task();
			DataTable mydb = Tools.ConvertDataReaderToDataTable(task.GetAllTaskBySomeone(DateTime.Today.ToShortDateString(),Username,displayType));
			this.dgList .DataSource = mydb.DefaultView;
			this.dgList.DataBind();
			setgrid();
			mydb.Dispose();
			
		}

		private void lnkbtnFinished_Click(object sender, System.EventArgs e)
		{
			string Username = (string)Session["Username"];
			this.btnCancelSubscription.Visible = false;
			this.btnCancel.Visible = false;
			displayType = 3;
			this.tblContainer.Rows[0].Cells[2].Attributes.Add("background","../../images/maillistbutton2.gif");
			this.tblContainer.Rows[0].Cells[0].Attributes.Add("background","../../images/maillistbutton1.gif");
			this.tblContainer.Rows[0].Cells[1].Attributes.Add("background","../../images/maillistbutton1.gif");
			this.tblContainer.Rows[0].Cells[3].Attributes.Add("background","../../images/maillistbutton1.gif");
			this.tblContainer.Rows[0].Cells[4].Attributes.Add("background","../../images/maillistbutton1.gif");
			Task task = new Task();
			DataTable mydb = Tools.ConvertDataReaderToDataTable(task.GetAllTaskBySomeone(DateTime.Today.ToShortDateString(),Username,displayType));
			this.dgList .DataSource = mydb.DefaultView;
			this.dgList.DataBind();
			//	setgrid();
			mydb.Dispose();
			
		}

		private void btnAccept_Click(object sender, System.EventArgs e)
		{
			string Username = (string)Session["Username"];
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
					Response.Write("<script language=javascript>alert('操作成功!');window.location='TaskList.aspx';</script>");
					//Response.AddHeader("Refresh","1");
				}
				catch(Exception ex)
				{
					UDS.Components .Error.Log(ex.ToString());
					Server.Transfer("../Error.aspx");
				}
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			string Username = (string)Session["Username"];
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
					Response.Write("<script language=javascript>alert('操作成功!');window.location='TaskList.aspx';</script>");
					//Response.AddHeader("Refresh","1");
				}
				catch(Exception ex)
				{
					UDS.Components .Error.Log(ex.ToString());
					Server.Transfer("../Error.aspx");
				}
			}
		}

		private void btnFinish_Click(object sender, System.EventArgs e)
		{
			string Username = (string)Session["Username"];
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
					Response.Write("<script language=javascript>alert('操作成功!');window.location='TaskList.aspx';</script>");
					//Response.AddHeader("Refresh","1");
				}
				catch(Exception ex)
				{
					UDS.Components .Error.Log(ex.ToString());
					Server.Transfer("../Error.aspx");
				}
			}
		}

		public void listStaff_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session["Username"]=this.listStaff.SelectedItem .Value.ToString();
			string Username = (string)Session["Username"];
			string ActualUsername = (string)Session["ActualUsername"];
			if(this.btnWeeklyView.Text == "周览")
			{
				Response.Redirect("TaskList.aspx?displayType=1");
			}
			else
			{
				this.lnkbtnFinished .Enabled = false;
				this.lnkbtnHistory .Enabled  = false;
				this.lnkbtnToday .Enabled	 = false;
				this.Linkbutton1.Enabled	 = false;
				this.btnAccept .Enabled		 = false;
				this.btnCancel.Enabled	     = false;
				this.btnNew .Enabled		 = false;
				this.btnWeeklyView .Text = "返回";
				PopulateWeeklyData();
				SetStatus();
				this.btnSubscribe .Enabled			 = false;
				
			}


		}

		private void btnSubscribe_Click(object sender, System.EventArgs e)
		{
			string Username = (string)Session["Username"];
			string ActualUsername = (string)Session["ActualUsername"];
			string ids = "";
			Task task = new Task();
			foreach(DataGridItem dgi in this.dgList .Items)
			{
				CheckBox cb=(CheckBox)(dgi.Cells[0].Controls[1]);
				Label  lb=(Label)(dgi.Cells[1].Controls[3]);
				if (cb.Checked==true)
				{
					try
					{
						ids = dgList.DataKeys[dgi.ItemIndex].ToString();
						if(task.AddTaskSubscription(ActualUsername,Username,Int32.Parse(ids),Convert.ToDateTime(lb.Text.ToString()).ToShortDateString()))
						Response.Write("<script language=javascript>alert('订阅成功!');window.location='TaskList.aspx?displayType="+displayType.ToString()+"';</script>");
					}
					catch(Exception dbex)
					{
						UDS.Components .Error.Log(dbex.ToString());
						Server.Transfer("../Error.aspx");
					}
					
				}	
			}
			
				
		}

		

		private void Linkbutton1_Click(object sender, System.EventArgs e)
		{
			string ActualUsername = (string)Session["ActualUsername"];
			string Username = (string)Session["Username"];
			this.btnCancelSubscription.Visible = (ActualUsername.ToLower()==Username.ToLower());
			displayType = 4;
			this.tblContainer.Rows[0].Cells[3].Attributes.Add("background","../../images/maillistbutton2.gif");
			this.tblContainer.Rows[0].Cells[0].Attributes.Add("background","../../images/maillistbutton1.gif");
			this.tblContainer.Rows[0].Cells[1].Attributes.Add("background","../../images/maillistbutton1.gif");
			this.tblContainer.Rows[0].Cells[2].Attributes.Add("background","../../images/maillistbutton1.gif");
			this.tblContainer.Rows[0].Cells[4].Attributes.Add("background","../../images/maillistbutton1.gif");
			Task task = new Task();
			DataTable mydb = Tools.ConvertDataReaderToDataTable(task.GetAllTaskBySomeone(DateTime.Today.ToShortDateString(),Username,displayType));
			this.dgList .DataSource = mydb.DefaultView;
			this.dgList.DataBind();
			//	setgrid();
			mydb.Dispose();
		
		}

		private void btnWeeklyView_Click(object sender, System.EventArgs e)
		{
			if(this.btnWeeklyView .Text == "周览")
			{
			
				this.lnkbtnFinished .Enabled = false;
				this.lnkbtnHistory .Enabled  = false;
				this.lnkbtnToday .Enabled	 = false;
				this.Linkbutton1.Enabled	 = false;
				this.btnAccept .Enabled		 = false;
				this.btnCancel.Enabled	     = false;
				this.btnNew .Enabled		 = false;
				this.lnkbtnArranged.Enabled  = false;
				this.btnWeeklyView .Text	 = "返回";
				PopulateWeeklyData();
			}
			else if(this.btnWeeklyView .Text == "返回")
			{
				this.lnkbtnFinished .Enabled = true;
				this.lnkbtnHistory .Enabled  = true;
				this.lnkbtnToday .Enabled	 = true;
				this.Linkbutton1.Enabled	 = true;
				this.lnkbtnArranged .Enabled = true;
				this.btnAccept .Enabled		 = true;
				this.btnCancel.Enabled	     = true;
				this.btnNew .Enabled		 = true;
				this.lblInstru .Visible      = true;
				this.btnWeeklyView .Text	 = "周览";
				InitData();
			}
			SetStatus();
			
		}

		private void btnCancelSubscription_Click(object sender, System.EventArgs e)
		{
			string ActualUsername = (string)Session["ActualUsername"];
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
					task.DeleteTaskSubscription(ActualUsername,ids);
					
					Response.Write("<script language=javascript>alert('操作成功!');window.location='TaskList.aspx?displayType="+displayType+"';</script>");
					//Response.AddHeader("Refresh","1");
				}
				catch(Exception ex)
				{
					UDS.Components .Error.Log(ex.ToString());
					Server.Transfer("../Error.aspx");
				}
			}
		}

		private void lnkbtnArranged_Click(object sender, System.EventArgs e)
		{
			string ActualUsername = (string)Session["ActualUsername"];
			string Username = (string)Session["Username"];
			//this.btnCancelSubscription.Visible = (ActualUsername.ToLower()==Username.ToLower());
			this.btnCancelSubscription.Visible = false;
			this.btnCancel.Visible = false;
			displayType = 5;
			this.tblContainer.Rows[0].Cells[3].Attributes.Add("background","../../images/maillistbutton1.gif");
			this.tblContainer.Rows[0].Cells[0].Attributes.Add("background","../../images/maillistbutton1.gif");
			this.tblContainer.Rows[0].Cells[1].Attributes.Add("background","../../images/maillistbutton1.gif");
			this.tblContainer.Rows[0].Cells[2].Attributes.Add("background","../../images/maillistbutton1.gif");
			this.tblContainer.Rows[0].Cells[4].Attributes.Add("background","../../images/maillistbutton2.gif");
			Task task = new Task();
			DataTable mydb = Tools.ConvertDataReaderToDataTable(task.GetAllTaskBySomeone(DateTime.Today.ToShortDateString(),Username,displayType));
			this.dgList .DataSource = mydb.DefaultView;
			this.dgList.DataBind();
			//	setgrid();
			mydb.Dispose();
		
		}

	
	}
}
