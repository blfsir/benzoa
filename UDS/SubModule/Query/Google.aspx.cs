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

namespace UDS.SubModule.Query
{
	/// <summary>
	/// Google ��ժҪ˵����
	/// </summary>
	public class Google : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button cmdSearch;
		protected System.Web.UI.WebControls.Panel panPreference;
		protected System.Web.UI.WebControls.TextBox txtKey;
		protected System.Web.UI.WebControls.LinkButton lbPerference;
		protected System.Web.UI.WebControls.CheckBox chkTitle;
		protected System.Web.UI.WebControls.CheckBox chkContent;
		protected System.Web.UI.WebControls.CheckBox chkAttach;
		protected System.Web.UI.WebControls.CheckBox chkDocument;
		protected System.Web.UI.WebControls.CheckBox chkMail;
		protected System.Web.UI.WebControls.CheckBox chkAuthor;
		protected System.Web.UI.WebControls.Label lblKey;
	
		private void Page_Load(object sender, System.EventArgs e)
		{			
			
		}
		//
		//
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
			this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
			this.lbPerference.Click += new System.EventHandler(this.lbPerference_Click);
			this.chkDocument.CheckedChanged += new System.EventHandler(this.chkDocument_CheckedChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lbPerference_Click(object sender, System.EventArgs e)
		{
			panPreference.Visible=!panPreference.Visible;
			if(!panPreference.Visible)
				lbPerference.Text = "ƫ������<<";			
			else
				lbPerference.Text = "ƫ������>>";
		}

		private void cmdSearch_Click(object sender, System.EventArgs e)
		{
			int Range =0;
			int SearchType =0;

			if(chkTitle.Checked ==true)
				Range = Range +1;
			if(chkContent.Checked ==true)
				Range = Range +2;
			if(chkAuthor.Checked ==true)
				Range = Range +4;
			if(chkAttach.Checked ==true)
				Range = Range +8;			
			if(chkDocument.Checked ==true)
				SearchType +=1;
			if(chkMail.Checked ==true)
				SearchType +=2;
//			if(chkBBS.Checked ==true)
//				SearchType +=4;
			if(Range==0)
			{
				Response.Write("<script language='javascript'>alert('����ѡ���ѯ��Χ��');</script>");
				return;
			}
			if(SearchType==0)
			{
				 Response.Write("<script language='javascript'>alert('����ѡ���ѯ���ͣ�');</script>");
				 return;
			}
			string KeyString;
			
			if(txtKey.Text =="")
				KeyString="%"; //Response.Write("<script language='javascript'>alert('������ؼ��֣�');</script>");
			else
				KeyString =txtKey.Text ;
			if((Range&0x08)==0x08)
			{
				if(KeyString.Length<=1)
				{
					if((KeyString.ToUpper().CompareTo(" ")>=0&&KeyString.ToUpper().CompareTo("~")<=0)||(KeyString.CompareTo("0")>=0&&KeyString.CompareTo("9")<=0))				
						Response.Write("<script language='javascript'>alert('��������ʱ���ܲ�ѯ����һ���ַ���');</script>");
					else
						Response.Redirect("Listview.aspx?Key="+KeyString + "&Range=" + Range.ToString() + "&SearchType=" + SearchType.ToString() );			
				}
				else
					Response.Redirect("Listview.aspx?Key="+KeyString + "&Range=" + Range.ToString() + "&SearchType=" + SearchType.ToString() );			
			}
			else
				Response.Redirect("Listview.aspx?Key="+KeyString + "&Range=" + Range.ToString() + "&SearchType=" + SearchType.ToString() );			

		}

		private void txtKey_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void chkDocument_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}
