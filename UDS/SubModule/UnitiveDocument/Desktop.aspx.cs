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
namespace UDS.SubModule.UnitiveDocument
{
	/// <summary>
	/// Desktop 的摘要说明。
	/// </summary>
	public class Desktop : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlImage IMG2;
		protected System.Web.UI.HtmlControls.HtmlImage IMG1;
		protected System.Web.UI.WebControls.DataGrid dgList;
		protected System.Web.UI.HtmlControls.HtmlImage IMG3;
		protected System.Web.UI.HtmlControls.HtmlImage Img4;
		protected System.Web.UI.WebControls.DataGrid dgDocList;
		protected System.Web.UI.WebControls.DataGrid dgMailList;
		protected System.Web.UI.WebControls.DataGrid dgAppDocList;
        protected System.Web.UI.WebControls.DataGrid dgFlowList;
        protected System.Web.UI.WebControls.DataGrid dgBoard;
        
		protected static string Username;

        public bool isAdmin =false;	
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			HttpCookie UserCookie = Request.Cookies["Username"];
			Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

            if (Username.Equals("admin"))
                isAdmin = true;

			if(!Page.IsPostBack)
			{
				//考勤操作
				DutyOperation();
				Bangding();
                BandBoard();
                BandFlow();
               // BandDoc();
				bindtaskgrid();
			}
		}

		private void DutyOperation()
		{
            //try
            //{
            //    WA_Duty wd = new WA_Duty(Int32.Parse(Request.Cookies["UserID"].Value.Trim()));
            //    int Duty = wd.HaveCompletedDuty(DateTime.Now);
            //    //检查当天是否已经完成上班考勤
            //    if(Duty==-1)
            //    {
            //        if(wd.CheckStatus(DutyAction.OnDuty)) //没有迟到
            //        {
            //            wd.RecordOnDutyData(DateTime.Now,true,"").ToString();
            //            //弹出新页面表示成功
            //            Response.Write("<script language=javascript>window.open('../WorkAttendance/checksucessful.aspx?login=in','_blank','height=200,width=400,status=no,toolbar=no,menubar=no,location=no')</script>");
            //        }
            //        else//迟到
            //        {
            //            //跳转到填写理由页面
            //            Response.Redirect("../WorkAttendance/Default.aspx?notnormal=1&login=in");
            //        }	

            //    }
            //}
            //catch(Exception ex)
            //{
            //    UDS.Components.Error.Log(ex.Message);
            //    Server.Transfer("../Error.aspx");
            //}
		}

		public void bindtaskgrid()
		{
			UDS.Components.Task task = new UDS.Components.Task();
			DataTable mydb = Tools.ConvertDataReaderToDataTable(task.GetAllTaskBySomeone(DateTime.Today.ToShortDateString(),Username,1));
		
			if(mydb.Rows.Count<5)
			{
				int tmp = 5-mydb.Rows.Count;
				for(int i=0;i<tmp;i++)
				{
					DataRow myDataRow = mydb.NewRow();
					myDataRow[0] = "-";
                    myDataRow[0] = "-";
					mydb.Rows.Add(myDataRow);
					
				}
			}
			this.dgList .DataSource = mydb.DefaultView;
			this.dgList.DataBind();
			// setgrid();
			mydb.Dispose();
		}

		public string GetStatus(string str)
		{
			
			switch (str) 
			{
                case "0":
                    return "待定"; // 待定
                case "1":
                    return " 待办"; // 待办
                case "2":
                    return "完成"; // 完成
                default:
					return "";
			}
			

		}

		public string GetPeriodByPeriodID(string EndTime,string begintime,string endtime)
		{
			if(begintime=="0"&&endtime=="0")
			{
				if(EndTime!="")
					return DateTime.Parse(EndTime).ToShortTimeString();
				else
					return "-";

			}
			else
			{
				if(begintime==""&&endtime=="")
				{
					return "-";
				}
				int b = Int32.Parse(begintime);
				int e = Int32.Parse(endtime);
				DateTime dt = new DateTime(1999,1,1,8,0,0,0);
				TimeSpan ts = new TimeSpan(0,0,(b-1)*30,0,0);
				DateTime bt = dt.Add(ts);
				DateTime et = bt.Add(new TimeSpan(0,0,(e-b+1)*30,0,0));
				return bt.ToShortTimeString()+"-"+et.ToShortTimeString();
			}
			
		}

		public string GetDateString(string DateString)
		{
			if(DateString=="")
				return "";
			 else
				 return DateTime.Parse(DateString).ToShortDateString();
		}

		public string GetRealName(string Username)
		{
			if(Username!="")
				return UDS.Components.Staff.GetRealNameByUsername(Username);
			else
				return "-";
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
			// foreach(DataGridItem dgi in this.dgList .Items)
			{
				// Label lb=(Label)(dgi.Cells[2].Controls[1]);
				// if(lb.Text=="?") dgi.BackColor=Color.AliceBlue ;
			}
		}
		
		#region 翻页事件
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			this.dgList .CurrentPageIndex = e.NewPageIndex;
			UDS.Components.Task task = new UDS.Components.Task();
			DataTable mydb = Tools.ConvertDataReaderToDataTable(task.GetTodayTaskBySomeone(DateTime.Today.ToShortDateString(),Username,1));
			this.dgList .DataSource = mydb.DefaultView;
			this.dgList.DataBind();
			setgrid();
			
		}
		#endregion

		#region 绑定DBGRID

        private void BandBoard() //公告
        {
            SqlDataReader dr = null; //存放人物的数据
            Database mySQL = new Database();
            try
            {
                SqlParameter[] parameters = {
											mySQL.MakeInParam("@BoardID",SqlDbType.Int ,4,0)
										};

                mySQL.RunProc("sp_Flow_GetBoard", parameters, out dr);

                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);
                 //AddBlankRowInDataTable(5, ref dt);
                //DataView dv = new DataView(dt);
                if (dt.Rows.Count < 5)
                {
                    int tmp = 5 - dt.Rows.Count;
                    for (int i = 0; i < tmp; i++)
                    {
                        DataRow myDataRow = dt.NewRow();
                        
                        myDataRow[3] = "-";
                        dt.Rows.Add(myDataRow);

                    }
                }
                dgBoard.DataSource = dt;
                dgBoard.DataBind();
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
        private void BandFlow()
        {
            SqlDataReader dr; //存放人物的数据
            Database mySQL = new Database();
            string UserName;

            UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);


            SqlParameter[] parameters = {
											mySQL.MakeInParam("@StaffName",SqlDbType.VarChar ,300,UserName)
										};

            mySQL.RunProc("sp_Flow_GetMyFlow", parameters, out dr);
            try
            {
                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);
                if (dt.Rows.Count < 5)
                {
                    int tmp = 5 - dt.Rows.Count;
                    for (int i = 0; i < tmp; i++)
                    {
                        DataRow myDataRow = dt.NewRow();
                        
                        myDataRow[2] = "-";
                        dt.Rows.Add(myDataRow);

                    }
                }

                dgFlowList.DataSource = dt.DefaultView;
                dgFlowList.DataBind();
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

        //private void BandDoc()
        //{
        //    SqlDataReader dr; //存放人物的数据
        //    UDS.Components.Desktop myDesktop = new UDS.Components.Desktop();
        //    String UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);

        //    dr = myDesktop.GetMyDocument(UserName, 10);
        //    DataTable dt = Tools.ConvertDataReaderToDataTable(dr);
        //    if (dt.Rows.Count < 5)
        //    {
        //        int tmp = 5 - dt.Rows.Count;
        //        for (int i = 0; i < tmp; i++)
        //        {
        //            DataRow myDataRow = dt.NewRow();
        //            myDataRow[2] = "-";
        //            dt.Rows.Add(myDataRow);

        //        }
        //    }
        //    dgDocList.DataSource = dt.DefaultView;
        //    dgDocList.DataBind();
        //}
		private void Bangding()
        {
            SqlDataReader dr= null; //存放人物的数据
            try
            {
               
                UDS.Components.Desktop myDesktop = new UDS.Components.Desktop();
                String UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);

                dr = myDesktop.GetMyDocument(UserName, 10);
                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);
                if (dt.Rows.Count < 5)
                {
                    int tmp = 5 - dt.Rows.Count;
                    for (int i = 0; i < tmp; i++)
                    {
                        DataRow myDataRow = dt.NewRow();
                        myDataRow[2] = "";
                        
                        dt.Rows.Add(myDataRow);

                    }
                }
                dgDocList.DataSource = dt.DefaultView;
                dgDocList.DataBind();


                dr = myDesktop.GetMyMail(UserName, 1);
                dt = Tools.ConvertDataReaderToDataTable(dr);
                if (dt.Rows.Count < 5)
                {
                    int tmp = 5 - dt.Rows.Count;
                    for (int i = 0; i < tmp; i++)
                    {
                        DataRow myDataRow = dt.NewRow();
                        myDataRow[0] = "-";
                         	myDataRow[3] = "-";
                        myDataRow[7] = "-";
                        dt.Rows.Add(myDataRow);

                    }
                }
                //			DataView dv = dt.DefaultView;
                //			dv.Sort = "MailSendDate Desc";
                //AddBlankRowInDataTable(5, ref dt);
                dgMailList.DataSource = dt.DefaultView;
                dgMailList.DataBind();

                dr = myDesktop.GetMyApprove(UserName, 2);
                dt = Tools.ConvertDataReaderToDataTable(dr);
                if (dt.Rows.Count < 5)
                {
                    int tmp = 5 - dt.Rows.Count;
                    for (int i = 0; i < tmp; i++)
                    {
                        DataRow myDataRow = dt.NewRow();
                        myDataRow[0] = "-";
                        dt.Rows.Add(myDataRow);

                    }
                }
                dgAppDocList.DataSource = dt.DefaultView;
                dgAppDocList.DataBind();
            }
            finally
            {
                dr.Close();
            }
		}
		#endregion

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
			this.dgDocList.SelectedIndexChanged += new System.EventHandler(this.dgDocList_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dgDocList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

        public void AddBlankRowInDataTable(int total, ref DataTable dt)
        {
            int count = dt.Rows.Count;
            for (int i = count; i < total; i++)
            {
                DataRow dr = dt.NewRow();
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dc.DataType.Name == "Int32")
                        dr[dc.ColumnName] = DBNull.Value;
                    else if (dc.DataType.Name == "DateTime")
                        dr[dc.ColumnName] = DBNull.Value;
                    else if (dc.DataType.Name == "Int16")
                        dr[dc.ColumnName] = DBNull.Value;
                    else if (dc.DataType.Name == "Byte")
                        dr[dc.ColumnName] = DBNull.Value;
                    else
                        dr[dc.ColumnName] = "";
                }
                dt.Rows.Add(dr);
            }
        }

        protected void dgBoard_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
           
        }

        protected void dgBoard_ItemCreated(object sender, DataGridItemEventArgs e)
        {
           
        }

        protected void dgBoard_DataBinding(object sender, EventArgs e)
        {
           
           
        }


	}
}
