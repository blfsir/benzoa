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
	/// ViewDayTask ��ժҪ˵����
	/// </summary>
	public class ViewDayTask : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Table Table1;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected static string CookieUsername;
		private void Page_Load(object sender, System.EventArgs e)
		{
						
			if(!Page.IsPostBack)
			{
				//System.Globalization.DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek = System.DayOfWeek.Monday;
				//System.Globalization.DateTimeFormatInfo.CurrentInfo.DayNames=new String[]{"��","һ","��","��","��","��","��"};
				
				//��ʾһ�ܼ�¼
				//PopulateDateToTable(DateTime.Today.AddDays(-(Convert.ToInt32(DateTime.Today.DayOfWeek))+1),6);
				//��ʾһ��
				HttpCookie UserCookie = Request.Cookies["Username"];
                CookieUsername = Server.UrlDecode(Request.Cookies["UserName"].Value);
				string UnameStr = Request.QueryString["UnameStr"]!=null?Request.QueryString["UnameStr"]:CookieUsername;
				string CurrDate = Request.QueryString["Date"]!=null?Request.QueryString["Date"]:DateTime.Today.ToShortDateString();
				Schedule.Manage .UnameStr=UnameStr;
				
				DateTime dt = Convert.ToDateTime(CurrDate);
				// ��������table,������1,��ʼ���� 2,�������� 3,�û����ַ���
				PopulateDateToTable(dt,1,UnameStr);
				
				if(UnameStr=="")
				{
					this.lblTitle .Text = "����ִ����!������ѡ��һ��";
		
				}
			}

		}

		public void PopulateDateToTable(DateTime sDate,int dayCount,string Username)
		{
            
		 
			string[] UnameStr = System.Text.RegularExpressions.Regex.Split(Username,",");
			
						
			Task task = new Task();
		
			#region ��ʼ���ճ�����	
			int[][] TaskData = new int[1][];
			
			// ��ʼ����������ArrayList
			//			ArrayList demoDayData = new ArrayList();	
			//			demoDayData.Add(9);
			//			demoDayData.Add(10);
			//			demoDayData.Add(11);
			//			demoDayData.Add(12);
			
			
			//			int[][] TaskData = new int[5][];  //ÿ�յ���������
			//			TaskData[0] = new int[]{0,0,0,0,0,13,14,15,16,17,18};
			//			TaskData[1] = new int[]{8,9,10,11,0,0,0,0,0,0,0};
			//			TaskData[2] = new int[]{0,9,10,11,12,13,0,0,0,0,0};
			//			TaskData[3] = new int[]{8,9,10,11,12,13,14,15,0,0,0};
			//			TaskData[4] = new int[]{0,0,0,0,0,0,0,0,0,17,18};
			//			demoData[5] = new int[]{0,0,0,0,0,0,0,0};
			//			demoData[6] = new int[]{0,0,0,0,0,0,0,0};
			//			demoData[7] = new int[]{0,0,0,0,0,0,0,0};
			// �����к͵�Ԫ��
			ArrayList DaySch = new ArrayList(dayCount+1);//����ѡ��������������� ��1����Ϊ������һ��Ϣ��
			ArrayList DayTask = new ArrayList(dayCount+1); //��¼ÿ���ǰ��������ID
			DaySch.Add(new int[5][]);  //����һ������
			DayTask.Add(new String[5]);
			for(int p=0;p<UnameStr.Length;p++)
			{
				TaskData = new int[5][];
				string tmpDate = sDate.ToShortDateString();
				String[] a = new String[5];
				a = task.GetTop5DayTaskList(tmpDate,UnameStr[p].ToString());

				//	TaskData[0] = new int[]{0,0,0,0,0,13,14,15,16,17,18};
				//				TaskData[1] = new int[]{8,9,10,11,0,0,0,0,0,0,0};
				//				TaskData[2] = new int[]{0,9,10,11,12,13,0,0,0,0,0};
				//				TaskData[3] = new int[]{8,9,10,11,12,13,14,15,0,0,0};
				//				TaskData[4] = new int[]{0,0,0,0,0,0,0,0,0,17,18};
				for(int k=0;k<a.Length;k++)
				{
					TaskData[k] = task.GetTaskPeriod(tmpDate,UnameStr[p],Int32.Parse(a[k].ToString()));
				}
				DaySch.Add(TaskData);
				DayTask.Add(a);			
			}
			
			#endregion
		
			
			int numcells = UnameStr.Length;
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
		
			#region ��ɫ����
			ArrayList colorlist = new ArrayList(5);
			Random ro=new Random();
			string[] colorArray = task.GetTop5ConfirmedTaskList(sDate.ToShortDateString(),Username);
			for(int p=0;p<colorArray.Length;p++)
			{
				int ca = ro.Next(0,255);
				int cb = ro.Next(0,255);
				int cc = ro.Next(0,255);
				colorlist.Add(System.Drawing.Color.FromArgb(ca,cb,cc).ToArgb().ToString("X").Substring(2));
				//							if(colorArray[p].ToString()=="0")
				//								colorlist.Add(Color.FromName("#A692F5"));
				//							else
				//								colorlist.Add(Color.BlanchedAlmond);

			}
						#endregion	
			
			//  ��ʼ����ͷ
			#region ��ʼ����ͷ
			TableRow r = new TableRow();
			// ����һ����һ�У���ͷΪʱ��
			TableCell c = null;
			c = new TableCell();
			c.CssClass = "top";
			c.Controls.Add(new LiteralControl(""+sDate.ToString("yyyy/MM/dd")+"</font>&nbsp;&nbsp;&nbsp;    "));	
			r.Cells.Add(c);
			
			if(Username!="")
			{
			
				for (int i=0; i<numcells; i++) 
				{
					string tmp = "";
					if(UnameStr.Length>1)
					{
						for(int cu=0;cu<UnameStr.Length;cu++)
						{
						
							if(cu!=i)
							{
								tmp+=UnameStr[cu].ToString()+",";
							}
						}
					}

					if(tmp.Length!=0)
						tmp = tmp.Substring(0,tmp.Length-1);
				
					string s = "<a href='ViewDayTask.aspx?UnameStr="+tmp+"'>"+UDS.Components .Staff.GetRealNameByUsername(UnameStr[i].ToString())+"</a>";

					c = new TableCell();
					c.CssClass = "top";
					c.Controls.Add(new LiteralControl("&nbsp;"+s+"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));	
					//c.Controls.Add(new LiteralControl((i==0)?"&nbsp;&nbsp; "+sDate.ToShortDateString()+"&nbsp;&nbsp;&nbsp;    ":s+"&nbsp;&nbsp;&nbsp;"+UDS.Components.Tools.ConvertDayOfWeekToZh(sDate.AddDays(i-1).DayOfWeek)));	
					r.Cells.Add(c);
				}
			
			#endregion
				//			Table1.CellPadding = 0;
				//			Table1.CellSpacing = 0;
				Table1.Rows.Add(r);
				// ��ʼ����ͷ����

				// ����ʱ��ι�����8��
				for (int j=0; j<numrows; j++) 
				{
            
					r = new TableRow();
                
					// ÿ�и���ѡ�������������
					for (int i=0; i<UnameStr.Length+1; i++) 
					{
					

						c = new TableCell();
					
						Table newtable = new Table();
					
						if (i==0)
							if(j%2==0)
							{
								string []a = period[j].ToString().Split('-');
								//c.Controls.Add(new LiteralControl("<div style='position:absolute; width:86px; height:76px; z-index:1'><font size=3>aa"+a[0].ToString()+"</font></div>"));
								c.Controls.Add(new LiteralControl(" "+a[0].ToString()+" "));
							}
							else
								c.Controls.Add(new LiteralControl(""));
						else
						{ //������ǵ�һ��
					
							//					newtable.BorderWidth = 0;
							//newtable.GridLines = System.Web.UI.WebControls .GridLines.Vertical;
							// ��ĳ������table���ÿ�ʼ
							newtable = new Table();
							TableRow nr = new TableRow();
			
						
		
					
							for(int q=0;q<TaskData.Length;q++)
							{
							
				
			
								int[][] tmp =  (int[][])DaySch[i];
								String[] a = (String[])DayTask[i];
								TableCell nc = new TableCell();
							
								bool flag=false;
								string col = "";
								//�������������ʱ�����飬����û�б�ռ
								for(int co=0;co<TaskData.Length;co++)
								{
									if(Int32.Parse(tmp[co][j].ToString())!=0)
									{	
										flag = true;
										col  = colorlist[co].ToString();			
									}
								}
								//	Response.Write(flag.ToString());
								if(flag)
								{
								
									nc.Controls.Add(new LiteralControl("<font color="+col+">*"+"</font>"));
									nc.BackColor=Color.FromName(col);
									nc.Height = 20;
									//								nc.BackColor=(System.Drawing.Color)colorlist[q];
									//								nc.Attributes.Add("onclick","return dialwinprocess('"+sDate.AddDays(i-1).ToShortDateString()+"','"+(startTimeNo+j).ToString()+"','2','"+a[q]+"')");
									//								nc.Style.Add("cursor","hand");
							

								}
								else
								{
								
									nc.Controls.Add(new LiteralControl("<font color=#FFFFFF>0</font>"));
									nc.Height=20;
									//		nc.BackColor=Color.FromName("#FFF8F7");
									//								nc.Attributes.Add("onclick","return dialwinprocess('"+sDate.AddDays(i-1).ToShortDateString()+"','"+(startTimeNo+j).ToString()+"','1','0')");
									//								nc.Attributes.Add("OnMouseOver","return high( this );");
									//								nc.Attributes.Add("OnMouseOut","return low( this );");
									//nc.Attributes.Add("onclick","return dialwinprocess('"+q.ToString()+j.ToString()+tmp[q][j].ToString()+"')");
									//		nc.Style.Add("cursor","hand");
									//							System.Drawing.ColorConverter cc=new System.Drawing.ColorConverter();
									//							newtable.BackColor=(System.Drawing.Color)cc.ConvertFromString("#FF9900");
									//						
								
								}
								nr.Cells.Add(nc);
				
							}					
					
					
							newtable.CellPadding = 0;
							newtable.CellSpacing = 0;
							newtable.GridLines = System.Web.UI.WebControls .GridLines.Both;
							newtable.BorderWidth = 0;
							newtable.Rows.Add(nr);
							// ��table���ý���
				
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


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN���õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
