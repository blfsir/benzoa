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
using UDS.Inc;
using UDS.Components;
using Microsoft.Web.UI.WebControls;

namespace UDS.SubModule.AssginRule
{
	/// <summary>
	/// ClassTree ��ժҪ˵����
	/// </summary>
	public class ClassTree : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button OK;
		protected DataTable dataTbl1,dataTbl2;
		protected Microsoft.Web.UI.WebControls.TreeView TreeView1;
	
		/// <summary>
		/// ��ʾҪ��ʾ�ĸ��ڵ��ID
		/// </summary>

		private string SrcID;
		private string DisplayType;

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			SrcID		= Request.QueryString["SrcID"]			!=null?Request.QueryString["SrcID"].ToString()		:"";
			DisplayType = Request.QueryString["DisplayType"]	!=null?Request.QueryString["DisplayType"].ToString():"";

			if(!Page.IsPostBack)
			{	
				InitRootNodeDataTable();
				InitTreeRootNode(TreeView1.Nodes);
				TreeView1.ExpandLevel = 1;
			}
					
			
		}
	
		private void ExpandNode(string NodeID)
		{
			
			
		}

		#region ��DataReader תΪ DataTable
		/// <summary>
		/// ��DataReader תΪ DataTable
		/// </summary>
		/// <param name="DataReader">DataReader</param>
		public DataTable ConvertDataReaderToDataTable(SqlDataReader dataReader)
		{
			DataTable datatable = new DataTable();
            try
            {
                DataTable schemaTable = dataReader.GetSchemaTable();
                //��̬�����
                foreach (DataRow myRow in schemaTable.Rows)
                {
                    DataColumn myDataColumn = new DataColumn();
                    myDataColumn.DataType = System.Type.GetType("System.String");
                    myDataColumn.ColumnName = myRow[0].ToString();
                    datatable.Columns.Add(myDataColumn);
                }
                //�������
                while (dataReader.Read())
                {
                    DataRow myDataRow = datatable.NewRow();
                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        myDataRow[i] = dataReader[i].ToString();
                    }
                    datatable.Rows.Add(myDataRow);
                    myDataRow = null;
                }
                schemaTable = null;
            }
            finally
            {
                dataReader.Close();
                dataReader.Dispose();
            }
			return datatable;
		}
		#endregion

		/// <summary>
		/// ��ʼ�� RootNode DataTable
		/// </summary>
		private void InitRootNodeDataTable()
		{
			Database data = new Database();
			SqlDataReader dataReader = null;
            try
            {
                String username = Server.UrlDecode(Request.Cookies["UserName"].Value);
                SqlParameter[] prams = {
									   data.MakeInParam("@UserName",      SqlDbType.VarChar , 20, username)
									
								   };
                try
                {
                    data.RunProc("sp_GetShowClass", prams, out dataReader);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                    //UDS.Components.Error.Log(ex.ToString());
                }
                dataTbl1 = ConvertDataReaderToDataTable(dataReader);
                dataTbl1.TableName = "TreeView";
            }
            finally
            {

                if (data != null)
                {
                    data.Close();
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                }
            }
		}

		/// <summary>
		/// ��ʼ�� ChildNode DataTable
		/// </summary>
		private void InitChildNodeDataTable(int ClassParentID)
		{
			Database data = new Database();
			SqlDataReader dataReader = null;
            try
            {
                SqlParameter[] prams = {
									   data.MakeInParam("@Class_id",      SqlDbType.Int  , 20, ClassParentID)
								   };
                try
                {
                    data.RunProc("sp_GetAllChildClass", prams, out dataReader);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                    //UDS.Components.Error.Log(ex.ToString());
                }
                dataTbl2 = ConvertDataReaderToDataTable(dataReader);
                dataTbl2.TableName = "TreeView";
            }
            finally
            {

                if (data != null)
                {
                    data.Close();
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                }
            }
		}

		/// <summary>
		/// ��ʼ��TreeView �� RootNode
		/// </summary>
        private void InitTreeRootNode(Microsoft.Web.UI.WebControls.TreeNodeCollection TNC)
		{
			DataView dataView  = new DataView();
			dataView		   = dataTbl1.Copy().DefaultView;
			//	dataView.RowFilter = "ClassParentID = ClassID";
			foreach(DataRowView drv in dataView)
			{	
				Microsoft.Web.UI.WebControls.TreeNode tn    = new Microsoft.Web.UI.WebControls.TreeNode();
				tn.ID		   = drv["ClassID"].ToString();
				tn.Text		   = "<span onmousemove=javascript:title='"+drv["ClassName"]+"'>"+drv["ClassName"].ToString()+"</span>";
				tn.ImageUrl    = GetIcon(drv["ClassType"].ToString());
				tn.NavigateUrl = "RightList.aspx?ClassID="+drv["ClassID"].ToString() + "&SrcID=" + SrcID.ToString() + "&DisplayType=" + DisplayType.ToString();
				tn.Target      = "RightList";
				TNC.Add(tn);
				InitChildNodeDataTable(Int32.Parse(tn.ID.ToString()));
				InitTreeChildNode(tn.Nodes,tn.ID);
			}
			dataTbl1 = null;
			dataTbl2 = null;

			Microsoft.Web.UI.WebControls.TreeNode tnn    = new Microsoft.Web.UI.WebControls.TreeNode();
			tnn.ID		   = "0";
			tnn.Text		   = "<span onmousemove=javascript:title='ȫ�ֶ���'>ȫ�ֶ���</span>";
			tnn.ImageUrl    = GetIcon("-1");
			tnn.NavigateUrl = "RightList.aspx?ClassID=0&SrcID=" + SrcID.ToString() + "&DisplayType=" + DisplayType.ToString();
			tnn.Target      = "RightList";
			TNC.Add(tnn);

			

		}	

		/// <summary>
		/// ��ʼ��TreeView �� ChildNode
		/// </summary>
        private void InitTreeChildNode(Microsoft.Web.UI.WebControls.TreeNodeCollection TNC, string classParentID)
		{
			DataView dataView  = new DataView();
			dataView		   = dataTbl2.Copy().DefaultView ;
			dataView.RowFilter = "ClassParentID = " + classParentID + "";
			foreach(DataRowView drv in dataView)
			{	
				Microsoft.Web.UI.WebControls.TreeNode tn    = new Microsoft.Web.UI.WebControls.TreeNode();
				tn.ID		   = drv["ClassID"].ToString();
				tn.Text		   = "<span onmousemove=javascript:title='"+drv["ClassName"]+"'>"+drv["ClassName"].ToString()+"</span>";
				tn.ImageUrl    = GetIcon(drv["ClassType"].ToString());
				tn.NavigateUrl = "RightList.aspx?ClassID="+drv["ClassID"].ToString() + "&SrcID=" + SrcID.ToString() + "&DisplayType=" + DisplayType.ToString();
				tn.Target      = "RightList";
				TNC.Add(tn);
				InitTreeChildNode(tn.Nodes,tn.ID);
			}
		}	
			
		#region ��ȡ�ڵ�ͼ��
		/// <summary>
		/// ��ȡ�ڵ�ͼ��
		/// </summary>
		private string GetIcon(string ClassType)
		{
			string rtnValue = "../../DataImages/";
			switch (ClassType)
			{
				case "0":
					rtnValue+= "flag.gif" ;
					break;
				case "1":
					rtnValue+= "myDoc.gif" ;
					break;
				case "2":
					rtnValue+= "mail.gif" ;
					break;
				case "3":
					rtnValue+= "page.gif" ;
					break;
				case "4":
					rtnValue+= "staff.gif" ;
					break;
				case "5":
					rtnValue+= "help_page.gif" ;
					break;
				case "6":
					rtnValue+= "MyTask.gif";
					break;
				case "7":
					rtnValue+= "mail.gif" ;
					break;
				case "8":
					rtnValue+= "myDoc.gif" ;
					break;
				case "9":
					rtnValue+= "DocFlow.gif" ;
					break;
				case "10":
					rtnValue+= "ClientManage.gif" ;
					break;
				case "11":
					rtnValue+= "myLinkman.gif" ;
					break;
				case "12":
					rtnValue+= "position.gif" ;
					break;
				case "13":
					rtnValue+= "role.gif" ;
					break;
				case "14":
					rtnValue+= "kaoqin.gif" ;
					break;
				case "15":
					rtnValue+= "workadmin.gif" ;
					break;
				case "16":
					rtnValue+= "message.gif" ;
					break;
                case "50":
                    rtnValue += "board.gif";
                    break;
                case "55":
                    rtnValue += "myDoc.gif";
                    break;

                case "52":
                    rtnValue += "t1.jpg";
                    break;
                case "57": //�칫�������
                    rtnValue += "t2.jpg";
                    break;

                case "58": //�ƻ��ܽ�
                    rtnValue += "t3.jpg";
                    break;

                case "59": //��ԴԤ��
                    rtnValue += "t4.jpg";
                    break;

                case "60": //�豸����
                    rtnValue += "t5.jpg";
                    break;
				default: 
					rtnValue+= "red_ball.gif";
					break;
			}
			return rtnValue;
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
		
		///		�����֧������ķ��� - ��Ҫʹ��
		///		����༭���޸Ĵ˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		



	}
}
