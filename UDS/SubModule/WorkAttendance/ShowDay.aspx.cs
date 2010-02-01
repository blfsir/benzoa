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

namespace UDS.SubModule.WorkAttendance
{
	/// <summary>
	/// ShowDay 的摘要说明。
	/// </summary>
	public class ShowDay : System.Web.UI.Page
	{
	
		protected System.Web.UI.HtmlControls.HtmlTable daytable;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hcellstatus;
		protected string indaycolor;//应该出勤天数的背景色
		protected System.Web.UI.WebControls.Button btnsubmit;
		protected System.Web.UI.WebControls.Button lblMessage;
		protected string outdaycolor;//无需出勤天数的背景色
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 
			indaycolor = "#EBFFE5";
			outdaycolor = "#ffffef";
			if(!Page.IsPostBack)
			{
				try
				{
					
					UDS.Components.WA_Duty wa = new UDS.Components.WA_Duty();
					string begintime,endtime;
					begintime = (Request.QueryString["begintime"]==null)?DateTime.Now.ToString():Request.QueryString["begintime"].ToString();
					endtime = (Request.QueryString["endtime"]==null)?DateTime.Now.ToString():Request.QueryString["endtime"].ToString();
					
					BindData(begintime,endtime);
				}
				catch(Exception ex)
				{
					UDS.Components.Error.Log(ex.Message);
					Server.Transfer("../Error.aspx");
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
			this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
			this.lblMessage.Click += new System.EventHandler(this.lblMessage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindData(string begintime,string endtime)
		{
			int j = 0;
			Database db = new Database();
			SqlDataReader dr = null;
            try
            {
                SqlParameter[] prams = {
									   db.MakeInParam("@begintime",SqlDbType.DateTime,8,begintime),
									   db.MakeInParam("@endtime",SqlDbType.DateTime,8,endtime)
								   };
                db.RunProc("sp_WA_GetDayData", prams, out dr);
                bool outwhile = false;
                while (!outwhile)
                {
                    HtmlTableRow row = new HtmlTableRow();
                    row.Height = "30";
                    while (row.Cells.Count < 7)
                    {
                        if (!dr.Read())
                        {
                            //填补空余列
                            int blankcells = 7 - row.Cells.Count;
                            for (int i = 0; i < blankcells; i++)
                            {
                                HtmlTableCell tmpcell = new HtmlTableCell();
                                tmpcell.InnerHtml = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                                row.Cells.Add(tmpcell);
                            }
                            daytable.Rows.Add(row);
                            outwhile = true;
                            break;
                        }
                        HtmlTableCell col = new HtmlTableCell();
                        switch (DateTime.Parse(dr[0].ToString()).DayOfWeek.ToString())
                        {
                            case "Monday": j = 1; break;
                            case "Tuesday": j = 2; break;
                            case "Wednesday": j = 3; break;
                            case "Thursday": j = 4; break;
                            case "Friday": j = 5; break;
                            case "Saturday": j = 6; break;
                            case "Sunday": j = 7; break;
                            default:
                                break;
                        }
                        col.ID = dr["id"].ToString();
                        col.Align = "center";
                        if (Convert.ToBoolean(dr["needduty"]) == true)
                        {
                            col.Style.Add("background-color", indaycolor);
                        }
                        else
                        {
                            col.Style.Add("background-color", outdaycolor);
                        }
                        col.InnerText = DateTime.Parse(dr["datetime"].ToString()).Month.ToString() + "-" + DateTime.Parse(dr["datetime"].ToString()).Day.ToString();

                        //如果当前日期紧接前面的日期就添加列
                        if ((row.Cells.Count + 1) == j)
                        {
                            col.Style.Add("cursor", "hand");
                            row.Cells.Add(col);
                            col.Attributes["onclick"] = "Click_Cell(this);";
                        }
                        else
                        {
                            int blankcell = j - row.Cells.Count - 1;
                            //补充缺掉的cell
                            if (blankcell > 0)
                            {
                                for (int k = 0; k < blankcell; k++)
                                {
                                    HtmlTableCell tmpcol = new HtmlTableCell();
                                    //tmpcol.BgColor = outdaycolor;
                                    tmpcol.InnerText = "";
                                    row.Cells.Add(tmpcol);
                                }
                                col.Style.Add("cursor", "hand");
                                row.Cells.Add(col);
                                col.Attributes["onclick"] = "Click_Cell(this);";

                            }
                            else
                            {
                                blankcell = j + 6 - row.Cells.Count;
                                for (int k = 0; k < blankcell; k++)
                                {
                                    if (row.Cells.Count == 7)
                                    {
                                        daytable.Rows.Add(row);
                                    }
                                    else
                                    {
                                        HtmlTableCell tmpcol = new HtmlTableCell();
                                        //tmpcol.BgColor = outdaycolor;
                                        tmpcol.InnerText = "";
                                        row.Cells.Add(tmpcol);
                                    }
                                    col.Style.Add("cursor", "hand");
                                    row.Cells.Add(col);
                                    col.Attributes["onclick"] = "if(this.style.backgroundColor=='" + indaycolor + "') this.style.backgroundColor = '" + outdaycolor + "';else this.style.backgroundColor = '" + indaycolor + "';Click_Cell(this);this.blur();";
                                }
                            }

                        }
                        //添加完列判断是否需要添加行
                        if (row.Cells.Count == 7)
                        {
                            daytable.Rows.Add(row);
                        }
                    }
                }
            }
            finally//关闭db
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


		private void btnsubmit_Click(object sender, System.EventArgs e)
		{
			string tmpstr = hcellstatus.Value;
			string indaystr,outdaystr;
			indaystr = outdaystr = "";
			string[] arrdate = tmpstr.Split(',');
			string[] tmp = new string[2];

			Database db = new Database();
			SqlParameter[] prams = new SqlParameter[2]; 

			for(int i=0;i<arrdate.Length;i++)
			{
				if(arrdate[i].Trim()!="")
				{
					tmp = arrdate[i].Split(':');
					if(Int32.Parse(tmp[1].ToString())%2==0) //偶数上班日期
						indaystr = indaystr + tmp[0] + ",";
					else
						outdaystr = outdaystr + tmp[0] + ",";
				}
			}
			outdaystr = (outdaystr.Length==0)?"":outdaystr.Substring(0,outdaystr.Length-1);
			indaystr = (indaystr.Length==0)?"":indaystr.Substring(0,indaystr.Length-1);
			try
			{
				if(indaystr!="")
				{
					prams[0] = db.MakeInParam("@datetimestr",SqlDbType.VarChar,8000,indaystr);
					prams[1] = db.MakeInParam("@type",SqlDbType.Bit,1,1);
					db.RunProc("sp_WA_ChangeDaySetting",prams);
				}
				if(outdaystr!="")
				{
					prams[0] = db.MakeInParam("@datetimestr",SqlDbType.VarChar,8000,outdaystr);
					prams[1] = db.MakeInParam("@type",SqlDbType.Bit,1,0);
					db.RunProc("sp_WA_ChangeDaySetting",prams);
				}
				daytable.Visible = false;
				btnsubmit.Visible = false;
				lblMessage.Visible = true;

				db.Dispose();
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.Message);
				Server.Transfer("../Error.aspx");
			}
			
		}

		private void lblMessage_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.close();</script>");
		}


		
	}
}
