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

namespace UDS.SubModule.Staff.Sch
{
	/// <summary>
	/// Search ��ժҪ˵����
	/// </summary>
	public class Search : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbx_Name;
		protected System.Web.UI.WebControls.DropDownList ddl_Position;
		protected System.Web.UI.WebControls.LinkButton lbtn_Others;
		protected System.Web.UI.WebControls.Button btn_Search;
		protected System.Web.UI.WebControls.LinkButton lbtn_SelectField;
		protected System.Web.UI.HtmlControls.HtmlTable table_Field;
		protected System.Web.UI.WebControls.Button btn_In;
		protected System.Web.UI.WebControls.Button btn_Out;
		protected System.Web.UI.WebControls.ListBox lbx_Fields;
		protected System.Web.UI.WebControls.ListBox lbx_SelectedFields;

		private string TopTable = "";

		#region ��ѯѡ��
		//��½��������
		public string StaffName
		{
			get
			{
				return tbx_Name.Text;
			}
		}

		//��ѡְλ
		public int Postion
		{
			get
			{
				return Int32.Parse(ddl_Position.SelectedValue);
			}
		}

		//�ֻ�����
		public string Mobile
		{
			get
			{	
				return tbx_Mobile.Text;
			}
		}

		//Email
		public string Email
		{
			get
			{	
				return tbx_Email.Text;
			}
		}

		//�Ա�
		public string Gender
		{
			get
			{
				return ddl_Gender.SelectedValue;
			}
		}

		//�ֻ�ѡ��
		public bool MobileSwitch
		{
			get
			{
				return cbx_Mobile.Checked;
			}
		}

		//Emailѡ��
		public bool EmailSwitch
		{
			get
			{
				return cbx_Email.Checked;
			}
		}
	
		//�Ա�ѡ��
		public bool GenderSwitch
		{
			get
			{
				return cbx_Gender.Checked;
			}
		}

		//��ѯѡ��
		public string SearchBound
		{
			get
			{
				return ddl_SearchBound.SelectedValue;
			}
		}
		//��ʾ���ֶ�,������datagrid�������
		public int[] SelectedFields
		{
			get
			{
				int[] number = new int[lbx_SelectedFields.Items.Count];
				for(int i=0;i<number.Length;i++)
				{
					number[i] = Int32.Parse(lbx_SelectedFields.Items[i].Value);
				}
				return number;
			}
		}

		//ѡ�е��ֶ���
		public string[] SelectedFieldsName
		{
			get
			{
				string[] name = new string[lbx_SelectedFields.Items.Count];
				for(int i=0;i<name.Length;i++)
				{
					name[i] = FieldsName[Int32.Parse(lbx_SelectedFields.Items[i].Value)];
				}
				return name;
			}
		}
		#endregion

		private System.Web.UI.WebControls.ListItem[] Fields ={
																 new ListItem("�û���","0"),
																 new ListItem("����","1"),
																 new ListItem("�ֻ�","2"),
																 new ListItem("�Ա�","3"),
																 new ListItem("Email","4"),
																 new ListItem("ְλ","5"),
		};
		protected System.Web.UI.HtmlControls.HtmlTable table_Other;
		protected System.Web.UI.WebControls.DropDownList ddl_Gender;
		protected System.Web.UI.WebControls.CheckBox cbx_Gender;
		protected System.Web.UI.WebControls.TextBox tbx_Email;
		protected System.Web.UI.WebControls.CheckBox cbx_Email;
		protected System.Web.UI.WebControls.TextBox tbx_Mobile;
		protected System.Web.UI.WebControls.CheckBox cbx_Mobile;
		protected System.Web.UI.WebControls.DropDownList ddl_SearchBound;

		private string[] FieldsName = {"StaffName","RealName","Mobile","Gender","Email","PositionName"};

		private void Page_Load(object sender, System.EventArgs e)
		{
			cbx_Mobile.Attributes["onclick"] = "document.getElementById('tbx_Mobile').disabled = !document.getElementById('tbx_Mobile').disabled";
			cbx_Email.Attributes["onclick"] = "document.getElementById('tbx_Email').disabled = !document.getElementById('tbx_Email').disabled";
			cbx_Gender.Attributes["onclick"] = "document.getElementById('ddl_Gender').disabled = !document.getElementById('ddl_Gender').disabled";
			if(!Page.IsPostBack)
			{
				table_Other.Visible = false;
				table_Field.Visible = false;
				BindPosition();

				BindDefaultField();
				ViewState["TopTable"] = TopTable;
			}
			else
			{
				TopTable = ViewState["TopTable"].ToString();
			}
		}

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
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
			this.lbtn_Others.Click += new System.EventHandler(this.lbtn_Others_Click);
			this.lbtn_SelectField.Click += new System.EventHandler(this.lbtn_SelectField_Click);
			this.btn_Out.Click += new System.EventHandler(this.btn_Out_Click);
			this.lbx_Fields.SelectedIndexChanged += new System.EventHandler(this.lbx_Fields_SelectedIndexChanged);
			this.btn_In.Click += new System.EventHandler(this.btn_In_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindPosition()
		{
			Database db = new Database();
			SqlDataReader dr=null;
            try
            {
                db.RunProc("SP_Ext_GetPosition", out dr);
                ddl_Position.DataSource = dr;
                ddl_Position.DataTextField = "Position_Name";
                ddl_Position.DataValueField = "Position_ID";
                ddl_Position.DataBind();
                ddl_Position.Items.Insert(0, new ListItem("ȫ��ְλ", "0"));
            }
            finally
            {
                if (db != null)
                { db.Close(); }
                if (dr != null)
                {

                    dr.Close();
                }
            }
		}

		private void BindDefaultField()
		{
			foreach(ListItem li in Fields)
			{
				lbx_SelectedFields.Items.Add(li);
			}

		}
		private void lbtn_Others_Click(object sender, System.EventArgs e)
		{
			table_Other.Visible = !table_Other.Visible;
			if(table_Other.Visible == true)
			{
				lbtn_Others.Text = "������ѯѡ��<<<";
			}
			else
			{
				lbtn_Others.Text = "������ѯѡ��>>>";
			}
		}

		private void cbx_Gender_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btn_Search_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ResultList.aspx");

		}

		private void btn_In_Click(object sender, System.EventArgs e)
		{
			if(lbx_Fields.SelectedItem!=null)
			{
				lbx_SelectedFields.Items.Add(lbx_Fields.SelectedItem);
				lbx_Fields.Items.Remove(lbx_Fields.SelectedItem);
				if(lbx_Fields.Items.Count!=0)
					lbx_Fields.Items[0].Selected = true;
				lbx_SelectedFields.Items[lbx_SelectedFields.SelectedIndex].Selected = false;
			}
			
		}

		private void btn_Out_Click(object sender, System.EventArgs e)
		{
			if(lbx_SelectedFields.SelectedItem!=null)
			{
				lbx_Fields.Items.Add(lbx_SelectedFields.SelectedItem);
				lbx_SelectedFields.Items.Remove(lbx_SelectedFields.SelectedItem);
				if(lbx_SelectedFields.Items.Count!=0)
					lbx_SelectedFields.Items[0].Selected = true;
				lbx_Fields.Items[lbx_Fields.SelectedIndex].Selected = false;
			}
			
		}

		private void lbtn_SelectField_Click(object sender, System.EventArgs e)
		{
			table_Field.Visible = !table_Field.Visible;
			if(table_Field.Visible == true)
			{
				lbtn_SelectField.Text = "ѡ����ʾ�ֶ�<<<";
			}
			else
			{
				lbtn_SelectField.Text = "ѡ����ʾ�ֶ�>>>";
			}
		}

		private void lbx_Fields_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		
	}
}
