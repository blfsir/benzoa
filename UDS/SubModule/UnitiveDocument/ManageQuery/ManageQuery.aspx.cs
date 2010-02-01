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

namespace UDS.SubModule.UnitiveDocument.ManageQuery
{
	/// <summary>
	/// ManageQuery ��ժҪ˵����
	/// </summary>
	public class ManageQuery : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl iNormalMedia;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				SqlDataReader dataReader = null;
                try
                {
                    DocumentClass dc = new DocumentClass();
                    dataReader = dc.GetManageQueryDetail();
                    if (dataReader.Read())
                    {
                        this.iNormalMedia.Attributes["src"] = "../Document/" + dataReader["FileVisualPath"].ToString();
                        dataReader.Close();
                    }
                    else
                    {
                        Response.Write("���������ĵ�!");

                    }
                    dc = null;
                }
                finally
                { dataReader.Close(); }
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
