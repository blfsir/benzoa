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

namespace UDS.SubModule.AssignRule
{
	/// <summary>
	/// RightList ��ժҪ˵����
	/// </summary>
	public class RightList : System.Web.UI.Page
	{
		private string UserName;
		protected System.Web.UI.WebControls.Button cmdOK;
		protected System.Web.UI.WebControls.CheckBoxList Act;
		private long	ClassID;
		private string	SrcID;
		protected System.Web.UI.WebControls.Button cmdReturn;
		private string	DisplayType;
	
		private void Page_Load(object sender, System.EventArgs e)
		{

			UserName	= Server.UrlDecode(Request.Cookies["UserName"].Value);
			ClassID		= Request.QueryString["ClassID"]		!=null?Int32.Parse(Request.QueryString["ClassID"].ToString())	:0;
			SrcID		= Request.QueryString["SrcID"]			!=null?Request.QueryString["SrcID"].ToString()					:"";
			DisplayType = Request.QueryString["DisplayType"]	!=null?Request.QueryString["DisplayType"].ToString()			:"";

			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				FillRightList(UserName,ClassID);
			}
		}

		private void FillRightList(string pUserName,long pClassID)
		{
			UDS.Components.AssignRights ar = new UDS.Components.AssignRights();
			SqlDataReader dr;
			ar.GetProcessList(pUserName,pClassID,out dr);

			Act.Items.Clear();
            try
            {
                while (dr.Read())
                {
                    Act.Items.Add(new ListItem(dr["proc_name"].ToString(), dr["proc_id"].ToString()));
                }
            }
            finally
            {
                 
                if (dr != null)
                {

                    dr.Close();
                }
            }
				

			ar = null;
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
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			this.cmdReturn.Click += new System.EventHandler(this.cmdReturn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdOK_Click(object sender, System.EventArgs e)
		{		
			bool bChecked=false;
			UDS.Components.AssignRights ar = new UDS.Components.AssignRights();

			for(int i=0;i<Act.Items.Count;i++)
			{
				if(Act.Items[i].Selected ==true)
				{
					
		
					ar.AddRight(Int32.Parse(SrcID),ClassID,Int32.Parse(DisplayType)+1,Int32.Parse(Act.Items[i].Value));


					bChecked = true;
				}
			}

			ar = null;

			if(bChecked==false)
				Response.Write("<script laguage='javascript'>alert('��ѡ��Ҫ��ӵ�Ȩ��');</script>");
			else
			{
				string url="RightListView.aspx?ObjID="  + SrcID.ToString() + "&DisplayType=" + DisplayType.ToString();
				Response.Write("<script laguage='javascript'>parent.location='" + url + "';</script>");
				
			}

		}

		private void cmdReturn_Click(object sender, System.EventArgs e)
		{
			if(SrcID.ToString()!="")
			{
				string url="RightListView.aspx?ObjID="  + SrcID.ToString() + "&DisplayType=" + DisplayType.ToString();
				Response.Write("<script laguage='javascript'>parent.location='" + url + "';</script>");
			}
			else
			{
				Response.Write("<script laguage='javascript'>history.back();</script>");
			}
						
			
		}

	
	}
}
