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
	/// Index ��ժҪ˵����
	/// </summary>
	public class Index : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnRead;
		protected System.Web.UI.WebControls.DataGrid dgMsgList;
		protected System.Web.UI.WebControls.Button btnDelete;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			string Username		 = (Request.QueryString["Username"]!=null)?Request.QueryString["Username"].ToString():Server.UrlDecode(Request.Cookies["UserName"].Value);
			string DispType		 = (Request.QueryString["DispType"]!=null)?Request.QueryString["DispType"].ToString():"1";
			if(!Page.IsPostBack)
			{
				BindGrid(Username,DispType);
				Session["MsgDispType"] = DispType;
				this.btnDelete.Attributes ["onclick"]="javascript:return confirm('��ȷ��Ҫɾ����?');";
			}
		}

		#region ���ݰ���DataGrid
		/// <summary>
		/// ���û��Ķ�Ѷ��¼��ʾ��datagrid��
		/// </summary>
		protected void BindGrid(string Username,string DispType) 
		{   
			SMS sm = new SMS();
			SqlDataReader dr = null;
			if(DispType=="1") //�ҵ����Ľ���
			{
				try
				{
					dr = sm.GetMyReceive(Username);
					dgMsgList.DataSource = UDS.Components.Tools.ConvertDataReaderToDataTable(dr).DefaultView;
					dgMsgList.DataBind();
				}
				catch
				{
					Server.Transfer("../Error.aspx");
				}
			}
			
			
			if(DispType=="2") //��������
			{
				try
				{
					dr = sm.GetMySent(Username);
					dgMsgList.DataSource = UDS.Components.Tools.ConvertDataReaderToDataTable(dr).DefaultView;
					dgMsgList.DataBind();
				}
				catch
				{
					Server.Transfer("../Error.aspx");
				}

			}

			switch (DispType)
			{
				case "1":
					dgMsgList.Columns[2].Visible = false; //�������ռ���
					break;
				case "2":
					dgMsgList.Columns[1].Visible = false; //�������ռ���
					this.btnRead .Visible = false;         //�������İ�ť
					this.btnDelete .Visible = false;       //����ɾ����ť
					break;
				default: 
					break;
			}


			sm = null;
			dr = null;
		}
		#endregion


		#region ��ҳ�¼�
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dgMsgList.CurrentPageIndex = e.NewPageIndex;
			BindGrid(Server.UrlDecode(Request.Cookies["UserName"].Value),Session["MsgDispType"]!=null?Session["MsgDispType"].ToString():"1");
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
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.ID = "Index";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			SMS sm		= new SMS();
			string ids			  = "";
			foreach(DataGridItem dgi in dgMsgList.Items)
			{
				CheckBox cb=(CheckBox)(dgi.Cells[0].Controls[1]);
				if (cb.Checked==true)
				{
					int i		= dgi.ItemIndex;
					string id	= dgMsgList.DataKeys[i].ToString();				
					ids+= id+",";
				}
			}
			if(ids.EndsWith(",")) ids = ids.Substring(0,ids.Length-1);
			//ѡ��Ϊ��
			if( ids==String.Empty)
			{
				Response.Write("<script language=javascript>alert('��ѡ����Ϣ!');window.location='Index.aspx?DispType="+Session["MsgDispType"].ToString()+"';</script>");
			}
			else
			{
				if(sm.MsgDelete(ids))
				{
					Response.Write("<script language=javascript>alert('��Ѷɾ���ɹ�!');window.location='Index.aspx?DispType="+Session["MsgDispType"].ToString()+"';</script>");
				}
			}
		
		}

		private void btnRead_Click(object sender, System.EventArgs e)
		{
			SMS sm		= new SMS();
			string Username		 = (Request.QueryString["Username"]!=null)?Request.QueryString["Username"].ToString():Server.UrlDecode(Request.Cookies["UserName"].Value);
			string ids			  = "";
			foreach(DataGridItem dgi in dgMsgList.Items)
			{
				CheckBox cb=(CheckBox)(dgi.Cells[0].Controls[1]);
				if (cb.Checked==true)
				{
					int i		= dgi.ItemIndex;
					string id	= dgMsgList.DataKeys[i].ToString();				
					ids+= id+",";
				}
			}
			if(ids.EndsWith(",")) ids = ids.Substring(0,ids.Length-1);
			//ѡ��Ϊ��
			if( ids==String.Empty)
			{
				Response.Write("<script language=javascript>alert('��ѡ����Ϣ!');window.location='Index.aspx?DispType="+Session["MsgDispType"].ToString()+"';</script>");
			}
			else
			{
				if(sm.ReadMsg(ids,Username))
				{
					Response.Write("<script language=javascript>alert('��Ѷ����!');window.location='Index.aspx?DispType="+Session["MsgDispType"].ToString()+"';</script>");
				}
			}
		
		
		}
	}
}
