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
namespace UDS.Inc
{
    /// <summary>
    /// ControlHeader ��ժҪ˵����
    /// </summary>
    public class NewControlHeader : System.Web.UI.Page
    {

        //protected System.Web.UI.WebControls.Label lbl_Hour;
        //protected System.Web.UI.WebControls.Label lbl_Minute;
        //protected System.Web.UI.WebControls.Label lbl_year;
        //protected System.Web.UI.WebControls.Label lbl_month;
        //protected System.Web.UI.WebControls.Label lbl_day;
        //protected System.Web.UI.WebControls.Label lbl_Second;
        //protected System.Web.UI.HtmlControls.HtmlGenericControl sys_bulletin;

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                //BBSClass bbsclass = new BBSClass();
                ////��ʾϵͳ����

                //SqlDataReader dr_sysbulletin = bbsclass.GetDeskTopBulletin();
                //string innerstring = "";
                //try
                //{
                //    while (dr_sysbulletin.Read())
                //    {
                //        innerstring += "<a href='../SubModule/UnitiveDocument/BBS/Display.aspx?BoardID=" + dr_sysbulletin["board_id"].ToString() + "&ItemID=" + dr_sysbulletin["item_id"].ToString() + "' target='_blank' title='" + dr_sysbulletin["content"].ToString() + "'>" + "aaa" + "</a><font size=2>(" + DateTime.Parse(dr_sysbulletin["send_time"].ToString()).ToString() + ")  </font>";
                //    }
                //}
                //finally
                //{
                //    dr_sysbulletin.Close();
                //    dr_sysbulletin.Dispose();
                //}
                //sys_bulletin.InnerHtml = innerstring;



                ////��ʾʱ��
                //lbl_Hour.Text = DateTime.Now.Hour.ToString();
                //lbl_Minute.Text = DateTime.Now.Minute.ToString();
                //lbl_Second.Text = DateTime.Now.Second.ToString();
                //lbl_year.Text = DateTime.Now.Date.Year.ToString();
                //lbl_month.Text = DateTime.Now.Date.Month.ToString();
                //lbl_day.Text = DateTime.Now.Date.Day.ToString();
                //��ʾ�����ڵĿ�������
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
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
    }
}
