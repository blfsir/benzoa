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
using System.Timers;
using UDS.Components;

namespace UDS.SubModule.Login
{
	/// <summary>
	/// checkout ��ժҪ˵����
	/// </summary>
	public class checkout : System.Web.UI.Page
	{
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//���ڲ���
			try
			{
				WA_Duty wd = new WA_Duty(Int32.Parse(Request.Cookies["UserID"].Value.Trim()));
				int DutyStat = 0;
				DutyStat = wd.HaveCompletedDuty(DateTime.Now);
				//��鵱���Ƿ��Ѿ�����ϰ࿼��
				if((DutyStat!=-1) && (DutyStat!=0))
				{
						if(wd.CheckStatus(DutyAction.OffDuty)) //û������
						{
							wd.RecordOffDutyData(DutyStat,DateTime.Now,true,"");
							//������ҳ���ʾ�ɹ�
							Response.Write("<script language=javascript>window.open('../WorkAttendance/checksucessful.aspx?login=out','_blank','height=200,width=400,status=no,toolbar=no,menubar=no,location=no')</script>");
						}
						else//����
						{
							//��ת����д����ҳ��
							Response.Write("<script language=javascript>location.href='../WorkAttendance/Default.aspx?notnormal=1&login=out';</script>");
						}	
				}
				Response.Write("<script>window.parent.parent.location.href='logout.aspx';</script>");
			}
			
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.Message);
				Server.Transfer("../Error.aspx");
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

		private void btnexit_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("logout.aspx");
		}

		private void Repeater1_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
		
		}

	}
}
