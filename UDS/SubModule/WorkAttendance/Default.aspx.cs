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
	/// _Default ��ժҪ˵����
	/// </summary>
	public class _Default : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnCheckAttendance;
		protected System.Web.UI.WebControls.Label lblDutyMessage;
		protected System.Web.UI.WebControls.TextBox txtAttendanceMemo;
		protected System.Web.UI.WebControls.DataGrid grdWeekAttendanceData;
		protected System.Web.UI.WebControls.Label lbl_Hour;
		protected System.Web.UI.WebControls.Label lbl_Minute;
		protected System.Web.UI.WebControls.Label lbl_Second;

		private static bool DutyStatus = true;
		protected System.Web.UI.WebControls.Label lbl_Time;//����״̬ true�ϰ� false�°�
		private static int staffid;
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				staffid = Int32.Parse(Request.Cookies["UserID"].Value.Trim());
				//����û���½���ٵ�
				if(Request.QueryString["notnormal"]!=null)
				{
					if((Request.QueryString["login"]!=null) &&(Request.QueryString["login"].ToString()=="in" ))
					{
						btnCheckAttendance.Text = "�ϰ�";
						DutyStatus = true;
						btnCheckAttendance.CommandArgument = "notnormal";
						lblDutyMessage.Text = "�ϰ�ٵ�������д���ɣ�";
						txtAttendanceMemo.Visible = true;
					}
					else if((Request.QueryString["login"]!=null) &&(Request.QueryString["login"].ToString()=="out" ))
					{
						btnCheckAttendance.Text = "�°�";
						DutyStatus = false;
						btnCheckAttendance.CommandArgument = "notnormal";
						lblDutyMessage.Text = "�°����ˣ�����д���ɣ�";
						txtAttendanceMemo.Visible = true;
					}
					
				}
				else  //����û��Ƿ��Ѿ�����
				{
					WA_Duty wd = new WA_Duty(Int32.Parse(Request.Cookies["UserID"].Value.Trim()));
					if(wd.HaveCompletedDuty(DateTime.Now)==0 )
					{
						lblDutyMessage.Text = "���Ѿ�����˽���Ŀ��ڣ�";
						btnCheckAttendance.Visible = false;

					}
					else
					{
						if(!wd.HaveCheckedDuty(DateTime.Now))
						{
							btnCheckAttendance.Text = "�ϰ�";
							DutyStatus = true;
						}
						else
						{
							btnCheckAttendance.Text = "�°�";
							DutyStatus = false;
						}
					}	
				}
				//��ʾʱ��
				lbl_Hour.Text = DateTime.Now.Hour.ToString();
				lbl_Minute.Text = DateTime.Now.Minute.ToString();
				lbl_Second.Text = DateTime.Now.Second.ToString();
				//��ʾ�����ڵĿ�������
				GridBind();
			}
			else
			{
				btnCheckAttendance.Text = "���ڴ���������";
			}
			
		}
		//�󶨿���������ʾgrid
		private void GridBind()
		{
			string weekstartdate,weekenddate;
			weekstartdate = weekenddate = DateTime.Now.ToShortDateString();
			switch((int)DateTime.Now.DayOfWeek)
			{
				case 0:
					weekstartdate = DateTime.Now.AddDays(-6).ToShortDateString();
					weekenddate   = DateTime.Now.ToShortDateString();
					break;
				case 1:
					weekstartdate = DateTime.Now.ToShortDateString();
					weekenddate   = DateTime.Now.AddDays(6).ToShortDateString();
					break;
				case 2:
					weekstartdate = DateTime.Now.AddDays(-1).ToShortDateString();
					weekenddate   = DateTime.Now.AddDays(5).ToShortDateString();
					break;
				case 3:
					weekstartdate = DateTime.Now.AddDays(-2).ToShortDateString();
					weekenddate   = DateTime.Now.AddDays(4).ToShortDateString();
					break;
				case 4:
					weekstartdate = DateTime.Now.AddDays(-3).ToShortDateString();
					weekenddate   = DateTime.Now.AddDays(3).ToShortDateString();
					break;
				case 5:
					weekstartdate = DateTime.Now.AddDays(-4).ToShortDateString();
					weekenddate   = DateTime.Now.AddDays(2).ToShortDateString();
					break;
				case 6:
					weekstartdate = DateTime.Now.AddDays(-5).ToShortDateString();
					weekenddate   = DateTime.Now.AddDays(1).ToShortDateString();
					break;
			}

			Database db = new Database();
			SqlDataReader dr=null;
            try
            {
                SqlParameter[] prams = {
									   db.MakeInParam("@begintime",SqlDbType.DateTime,8,weekstartdate),
									   db.MakeInParam("@endtime",SqlDbType.DateTime,8,weekenddate),
									   db.MakeInParam("@ids",SqlDbType.VarChar,1000,staffid),
									   db.MakeInParam("@idtype",SqlDbType.VarChar,50,"staff")
								   };
                db.RunProc("sp_WA_GetAttendanceData", prams, out dr);
                DataTable table = Tools.ConvertDataReaderToDataTable(dr);
                grdWeekAttendanceData.DataSource = table.DefaultView;
                grdWeekAttendanceData.DataBind();
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
			this.btnCheckAttendance.Click += new System.EventHandler(this.btnCheckAttendance_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		protected void btnCheckAttendance_Click(object sender, System.EventArgs e)
		{
			try
			{
				WA_Duty wd = new WA_Duty(Int32.Parse(Request.Cookies["UserID"].Value.Trim()));
				//��鵱���Ƿ��Ѿ���ɿ���
				int Duty = wd.HaveCompletedDuty(DateTime.Now);
				if(Duty==0)
				{
					lblDutyMessage.Text = "���Ѿ�����˽���Ŀ��ڣ�";
					btnCheckAttendance.Visible = false;

				}
				else
				{
					//����Ƿ�ٵ�����
					if(DutyStatus==true) //�ϰ࿼��
					{
						if(((Button)(sender)).CommandArgument.ToString()!="notnormal")
						{
							if(wd.CheckStatus(DutyAction.OnDuty))
							{
								wd.RecordOnDutyData(DateTime.Now,true,"").ToString();
								lblDutyMessage.Text = "�����ϰ�û�гٵ������ڳɹ���";
								btnCheckAttendance.Visible = false;
								DutyStatus = false;
							}
							else
							{
								lblDutyMessage.Text = "�ϰ�ٵ�������д���ɣ�";
								txtAttendanceMemo.Visible = true;
								btnCheckAttendance.Text = "�ϰ�";
								btnCheckAttendance.CommandArgument = "notnormal";
							}
						}
						else
						{
							wd.RecordOnDutyData(DateTime.Now,false,txtAttendanceMemo.Text).ToString();
							lblDutyMessage.Text = "�ϰ�ٵ������ڳɹ���";
							txtAttendanceMemo.Visible = false;
							btnCheckAttendance.Visible = false;
							DutyStatus = false;
							btnCheckAttendance.CommandArgument = "";
						}
					}
					else  //�°࿼��
					{
						if(((Button)(sender)).CommandArgument.ToString()!="notnormal")
						{
							if(wd.CheckStatus(DutyAction.OffDuty))
							{
								wd.RecordOffDutyData(Duty,DateTime.Now,true,"");
								lblDutyMessage.Text = "�����°�û�����ˡ����ڳɹ���";
								btnCheckAttendance.Visible = false;
								DutyStatus = true;
							}
							else
							{
								lblDutyMessage.Text = "�°����ˣ�����д���ɣ�";
								txtAttendanceMemo.Visible = true;
								btnCheckAttendance.Text = "�°�";
								btnCheckAttendance.CommandArgument = "notnormal";
							}
						}
						else
						{
							wd.RecordOffDutyData(Duty,DateTime.Now,false,txtAttendanceMemo.Text);
							lblDutyMessage.Text = "�°����ˡ����ڳɹ���";
							txtAttendanceMemo.Visible = false;
							btnCheckAttendance.Visible = false;
							DutyStatus = true;
							btnCheckAttendance.CommandArgument = "";
						}	

					}
				}
				GridBind();
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.Message);
				Server.Transfer("../Error.aspx");
			}
			
		}

	}
}
