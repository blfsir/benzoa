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

namespace UDS.SubModule.SM
{
	/// <summary>
	/// MsgHistory ��ժҪ˵����
	/// </summary>
	public class MsgHistory : System.Web.UI.Page
	{
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			string Sender		 = (Request.QueryString["Sender"]!=null)?Request.QueryString["Sender"].ToString():"";
			string Receiver		 = (Request.QueryString["Receiver"]!=null)?Request.QueryString["Receiver"].ToString():"";
			if(!Page.IsPostBack)
			{
				BindGrid(Sender,Receiver);
			}
		}


		#region ���ݰ���DataGrid
		/// <summary>
		/// ���û��������¼��ʾ��datagrid��
		/// </summary>
		protected void BindGrid(string Sender,string Receiver) 
		{   
			try
			{
				SMS sm = new SMS();
				SqlDataReader dr = sm.GetHistory(Sender,Receiver);
                try
                {
                    while (dr.Read())
                    {
                        Response.Write("<font color=red size=2>(" + dr["sendtime"].ToString() + ")" + dr["sender"].ToString() + "</font><br><font color=blue size=2>" + dr["content"].ToString() + "</font><br>");
                    }
                }
                finally
                {
                   
                    if (dr != null)
                    {

                        dr.Close();
                    }
                }
			//	DataTable datatable	  = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
			//	Response.Write(datatable.Rows.Count );
			//	DataView source       = datatable.DefaultView;
			//	DataGrid1.DataSource = dr;
			//	DataGrid1.DataBind(); 
			}
			catch
			{
				Server.Transfer("../Error.aspx");
			}
		}
		#endregion

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
