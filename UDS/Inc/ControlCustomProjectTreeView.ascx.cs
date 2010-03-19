//51-aspx
namespace UDS.Inc
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Microsoft.Web.UI.WebControls;
	using UDS.Components;
	using System.Data.SqlClient;

	/// <summary>
	///		ControlCustomProjectTreeView ��ժҪ˵����
	/// </summary>
	public class ControlCustomProjectTreeView : System.Web.UI.UserControl
	{
		protected DataTable dataTbl1,dataTbl2;
		protected Microsoft.Web.UI.WebControls.TreeView tv1;

		private string _imagepath = "";
		private bool _displayfunctionnode = true;
		private int _rightcode = 1;
		public string _username = "";

		/// <summary>
		/// ͼƬ·��
		/// </summary>
		public string ImagePath
		{
			get
			{
				return _imagepath;
			}
			set
			{
				_imagepath = value;
			}
		}


		/// <summary>
		/// ��ʾ���ܽڵ�
		/// </summary>
		public bool DisplayFunctionNode
		{
			get
			{
				return _displayfunctionnode;
			}
			set
			{
				_displayfunctionnode = value;
			}
		}


		/// <summary>
		/// ���Ȩ
		/// </summary>
		public int RightCode
		{
			get
			{
				return _rightcode; 
			}
			set
			{
				_rightcode = value;
			}
		}


		/// <summary>
		/// �û���
		/// </summary>
		public string UserName
		{
			get
			{
				return _username;
			}
			set
			{
				_username = value;
			}
		}

		public int SelectedClassIndex
		{
			get
			{
				//if(tv1.SelectedNodeIndex!="0")
					return Int32.Parse(tv1.GetNodeFromIndex(tv1.SelectedNodeIndex).ID);
				//else
				//	return 0;
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
		}

		public void Bind()
		{
			InitRootNodeDataTable();
			InitTreeRootNode(tv1.Nodes);
			tv1.ExpandLevel = 1;
		}

		/// <summary>
		/// ��ʼ�� RootNode DataTable
		/// </summary>
		private void InitRootNodeDataTable()
		{
			Database data = new Database();
			SqlDataReader dataReader = null;
			String username = Server.UrlDecode(Request.Cookies["UserName"].Value);
			SqlParameter[] prams = {
									   data.MakeInParam("@UserName",      SqlDbType.VarChar , 20, _username),
									   data.MakeInParam("@RightCode",      SqlDbType.Int , 1, _rightcode),
									   data.MakeInParam("@IncludeFunctionNode",      SqlDbType.Int , 1,(_displayfunctionnode==false)? 0:1)	
								   };
			try
			{
				data.RunProc("sp_GetShowClass", prams,out dataReader);
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
				//UDS.Components.Error.Log(ex.ToString());
			}
			dataTbl1 = UDS.Components.Tools.ConvertDataReaderToDataTable(dataReader); 
			dataTbl1.TableName = "TreeView";
		}

		/// <summary>
		/// ��ʼ�� ChildNode DataTable
		/// </summary>
		private void InitChildNodeDataTable(int ClassParentID)
		{
			Database data = new Database();
			SqlDataReader dataReader = null;
			SqlParameter[] prams = {
									   data.MakeInParam("@Class_id",      SqlDbType.Int  , 20, ClassParentID)
								   };
			try
			{
				data.RunProc("sp_GetAllChildClass", prams,out dataReader);
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
				//UDS.Components.Error.Log(ex.ToString());
			}
			dataTbl2 = UDS.Components.Tools.ConvertDataReaderToDataTable(dataReader); 
			dataTbl2.TableName = "TreeView";
		}

		/// <summary>
		/// ��ʼ��TreeView �� RootNode
		/// </summary>
        private void InitTreeRootNode(Microsoft.Web.UI.WebControls.TreeNodeCollection TNC)
		{
			DataView dataView  = new DataView();
			dataView		   = dataTbl1.Copy().DefaultView;
			dataView.RowFilter = "ClassParentID = ClassID";
			foreach(DataRowView drv in dataView)
			{
                Microsoft.Web.UI.WebControls.TreeNode tn = new Microsoft.Web.UI.WebControls.TreeNode();
				tn.ID		   = drv["ClassID"].ToString();
				tn.Text		   = drv["ClassName"].ToString();
				tn.ImageUrl    = GetIcon(drv["ClassType"].ToString(),_imagepath);
				//tn.NavigateUrl = "# onclick='alert('dddd')'";
				//tn.Target      = "self";
				TNC.Add(tn);
				InitChildNodeDataTable(Int32.Parse(tn.ID.ToString()));
				InitTreeChildNode(tn.Nodes,tn.ID);
			}
			dataTbl1 = null;
			dataTbl2 = null;
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
                Microsoft.Web.UI.WebControls.TreeNode tn = new Microsoft.Web.UI.WebControls.TreeNode();
				tn.ID		   = drv["ClassID"].ToString();
				tn.Text		   = drv["ClassName"].ToString();
				tn.ImageUrl    = GetIcon(drv["ClassType"].ToString(),_imagepath);
				//tn.NavigateUrl = "#";
				//tn.Target      = "parent";
				TNC.Add(tn);
				InitTreeChildNode(tn.Nodes,tn.ID);
			}
		}	
		
		#region ��ȡ�ڵ�ͼ��
		/// <summary>
		/// ��ȡ�ڵ�ͼ��
		/// </summary>
		private string GetIcon(string ClassType,string imagepath)
		{
			string rtnValue = imagepath;
			switch (ClassType)
			{
				case "0":
                    rtnValue += "��������2.gif";
					break;
				case "1":
                    rtnValue += "�ĵ�����2.gif";
					break;
				case "2":
                    rtnValue += "�ҵ��ʼ�2.gif";
					break;
				case "3":
                    rtnValue += "��˾��̳2.gif";
					break;
				case "4":
                    rtnValue += "��Ա����2.gif";
					break;
				case "5":
					rtnValue+= "help_page.gif" ;
					break;
				case "6":
                    rtnValue += "�ҵ�����2.gif";
					break;
				case "7":
                    rtnValue += "�ҵ��ʼ�2.gif";
					break;
				case "8":
                    rtnValue += "�ĵ�����2.gif";
					break;
				case "9":
                    rtnValue += "������ת2.gif";
					break;
				case "10":
					rtnValue+= "ClientManage.gif" ;
					break;
				case "11":
					rtnValue+= "myLinkman.gif" ;
					break;
				case "12":
                    rtnValue += "ְλ����2.gif";
					break;
				case "13":
                    rtnValue += "��ɫ����2.gif";
					break;
				case "14":
                    rtnValue += "���ڹ���2.gif";
					break;
                case "50":
                    rtnValue += "��˾����2.gif";
                    break;
                case "55":
                    rtnValue += "�ĵ�����2.gif";
                    break;
                case "52":
                    rtnValue += "��������2.gif"; //��������
                    break;
                case "57": //�칫�������
                    rtnValue += "�칫�һ������2.gif";
                    break;

                case "58": //�ƻ��ܽ�
                    rtnValue += "�ƻ��ܽ�2.gif";
                    break;

                case "59": //��ԴԤ��
                    rtnValue += "��ԴԤ��2.gif";
                    break;

                case "60": //�豸����
                    rtnValue += "�豸����2.gif";
                    break;
				default: 
					rtnValue+= "red_ball.gif";
					break;
			}
			return rtnValue;
		}
		#endregion

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		�����֧������ķ��� - ��Ҫʹ�ô���༭��
		///		�޸Ĵ˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
