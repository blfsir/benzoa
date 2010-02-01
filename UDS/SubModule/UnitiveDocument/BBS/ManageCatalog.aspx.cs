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

namespace UDS.SubModule.BBS
{
	/// <summary>
	/// ManageCatalog ��ժҪ˵����
	/// </summary>
	public class ManageCatalog : System.Web.UI.Page
	{
		private  string m_Action;
		private  string m_CatalogID;
		protected  string classid;
	
		protected System.Web.UI.HtmlControls.HtmlInputText TxtCatalogName;
		protected System.Web.UI.HtmlControls.HtmlTextArea TxtCatalogDescription;
		protected System.Web.UI.HtmlControls.HtmlInputButton cmdOK;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvcatalogname;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				m_CatalogID = (Request.QueryString["CatalogID"]!=null)?Request.QueryString["CatalogID"].ToString():"";
				m_Action  = (Request.QueryString["action"]!=null)?Request.QueryString["action"].ToString():"";
				classid  = (Request.QueryString["classID"]!=null)?Request.QueryString["classID"].ToString():"";
				
				ViewState["m_CatalogID"] = m_CatalogID;
				ViewState["m_Action"] = m_Action;
				ViewState["classid"] = classid;

				if (m_Action != "")
				{
					if (m_Action == "AddCatalog")
					{
						//�����Ŀ
						cmdOK.Value = "���";
                  	
					}
					if (m_Action == "ModifyCatalog") 
					{
						//�༩����
						cmdOK.Value = "�޸�";
						ReviseModifyCatalog();
					}
				}
			}
			else
			{
				m_CatalogID = ViewState["m_CatalogID"].ToString();
				m_Action = ViewState["m_Action"].ToString();
				classid = ViewState["classid"].ToString();
			}
		}

		#region �༩����ʱ���ؼ���ֵ

		public void ReviseModifyCatalog()
		{
			SqlDataReader dataReader = null; 
			BBSClass BBS = new BBSClass();
            try
            {
                if (m_CatalogID != "")
                {
                    dataReader = BBS.GetModifyBBSCatalog(Int32.Parse(m_CatalogID));
                    dataReader.Read();
                    this.TxtCatalogName.Value = dataReader["catalog_name"].ToString();
                    this.TxtCatalogDescription.Value = dataReader["catalog_description"].ToString();
                    BBS = null;
                    dataReader.Close();
                    dataReader = null;
                }
            }
            catch (Exception ex)
            {
                UDS.Components.Error.Log(ex.ToString());
                Server.Transfer("../../Error.aspx");
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
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
			this.cmdOK.ServerClick += new System.EventHandler(this.cmdOK_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void cmdOK_ServerClick(object sender, System.EventArgs e)
		{
			if (m_Action == "AddCatalog" )
			{
				//��������
				BBSClass BBS = new BBSClass(); 
				BBSCatalog Catalog = new BBSCatalog();
				HttpCookie UserCookie = Request.Cookies["Username"];
				String Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

				//try
				{
					Catalog.CatalogName = TxtCatalogName.Value;
					Catalog.CatalogDescription = TxtCatalogDescription.Value;
					BBS.AddBBSCatalog(Catalog);
					Server.Transfer("Catalog.aspx?classID="+classid);
				}
				//catch (Exception ex)
				{
				//	UDS.Components.Error.Log(ex.ToString());
				//	Server.Transfer("../../Error.aspx");
				}
				//finally 
				{
					BBS = null;
					Catalog = null;
				}
			}
			else if (m_Action == "ModifyCatalog")
			{
				//�༩���
				BBSClass BBS = new BBSClass(); 
				BBSCatalog Catalog = new BBSCatalog();
				HttpCookie UserCookie = Request.Cookies["Username"];
				String Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

				//try
				{
					Catalog.CatalogID = Int32.Parse(m_CatalogID);
					Catalog.CatalogName = this.TxtCatalogName.Value;
					Catalog.CatalogDescription = this.TxtCatalogDescription.Value;
					BBS.EditBBSCatalog (Catalog);
					Server.Transfer("Catalog.aspx?classID="+classid);
					
				}
				//catch (Exception ex)
				{
				//	UDS.Components.Error.Log(ex.ToString());
				//	Server.Transfer("../../Error.aspx");
				}
				//finally 
				{
					BBS = null;
					Catalog = null;
				}
			}
		}
	}
}
