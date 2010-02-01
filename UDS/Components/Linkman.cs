using System;
using System.Data;
using System.Data.SqlClient;

namespace UDS.Components
{
	/// <summary>
	/// Linkman ��ժҪ˵����
	/// </summary>
	public class MyLinkman
	{
		public MyLinkman()
		{
		}

		#region �õ���ϵ���б�
		/// <summary>
		/// �õ��ҵ���ϵ��
		/// </summary>
		/// <param name="type">��ϵ������(0:������ϵ��1:Ա����ϵ��2:�ͻ���ϵ��3:�Զ�����ϵ��)</param>
		/// <param name="staffid">�û�id</param>
		/// <returns></returns>
		public SqlDataReader GetMyLinkman(int type,int staffid)
		{
			UDS.Components.Database data = new UDS.Components.Database();
			SqlParameter[] prams = {
									    data.MakeInParam("@type",SqlDbType.Int,4,type),
										data.MakeInParam("@staffid",SqlDbType.Int,4,staffid)
			};
			SqlDataReader dr = null;
			data.RunProc("sp_Linkman_GetList",prams,out dr);
			return(dr);
		}
		#endregion

		#region �õ��Զ�����ϵ��
		/// <summary>
		/// �õ��Զ�����ϵ��
		/// </summary>
		/// <returns></returns>
		public SqlDataReader GetCustomLinkman(int id)
		{
			UDS.Components.Database data = new UDS.Components.Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@id",SqlDbType.Int,4,id)
								   };
			SqlDataReader dr = null;
			data.RunProc("sp_Linkman_GetCustomLinkman",prams,out dr);
			return(dr);
			
		}
		#endregion

		#region �õ��Զ�����ϵ�����

		public SqlDataReader GetCustomLinkmanType(int id)
		{
			UDS.Components.Database data = new UDS.Components.Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@id",SqlDbType.Int,4,id)
								   };
			SqlDataReader dr = null;
			data.RunProc("sp_Linkman_GetCustomLinkmanTypeByCustomLinkmanID",prams,out dr);
			return(dr);
		}

		#endregion

		#region ���������ϵ�˷����ϵ����
		/// <summary>
		/// ���������ϵ�˷����ϵ����
		/// </summary>
		/// <returns></returns>
		public SqlDataReader GetLinkmanTypeRelation()
		{
			UDS.Components.Database data = new UDS.Components.Database();
			SqlDataReader dr = null;
			data.RunProc("sp_Linkman_GetAllLinkmanTypeData",out dr);
			return(dr);
		}
		#endregion

		#region ����Զ�����ϵ��
		/// <summary>
		/// ����Զ�����ϵ��
		/// </summary>
		/// <param name="clinkman">CustomLinkman�ṹ</param>
		/// <returns>��ӵ�ID</returns>
		public int AddCustomLinkman(CustomLinkman clinkman,int staffid)
		{
			int result = 0;
			UDS.Components.Database data = new UDS.Components.Database();
			SqlParameter[] prams = {
									    data.MakeInParam("@name",SqlDbType.VarChar,100,clinkman.Name),
										data.MakeInParam("@Gender",SqlDbType.Bit,1,clinkman.Gender),
										data.MakeInParam("@UnitTelephone",SqlDbType.VarChar,50,clinkman.UnitTelephone),
										data.MakeInParam("@Email",SqlDbType.VarChar,50,clinkman.Email),
										data.MakeInParam("@UnitAddress",SqlDbType.VarChar,200,clinkman.UnitAddress),
										data.MakeInParam("@UnitZip",SqlDbType.VarChar,50,clinkman.UnitZip),
										data.MakeInParam("@FamilyAddress",SqlDbType.VarChar,200,clinkman.FamilyAddress),
										data.MakeInParam("@FamilyZip",SqlDbType.VarChar,50,clinkman.FamilyZip),
										data.MakeInParam("@Mobile",SqlDbType.VarChar,100,clinkman.Mobile),
										data.MakeInParam("@FamilyTelephone",SqlDbType.VarChar,100,clinkman.FamilyTelephone),
										data.MakeInParam("@Memo",SqlDbType.VarChar,1000,clinkman.Memo),
										data.MakeInParam("@Staffid",SqlDbType.Int,4,staffid),
										data.MakeInParam("@Age",SqlDbType.VarChar,50,clinkman.Age)
								   };
			result = data.RunProc("sp_Linkman_AddCustomLinkman",prams);
		
			if(clinkman.Type.IndexOf(',',0)!=-1)
			{
				string [] arrtype = clinkman.Type.Split(',');
				for(int i = 0;i<arrtype.Length;i++)
				{
					if(arrtype[i].Trim()!="")
					{
						SqlParameter[] prams1 = {
													data.MakeInParam("@typeid",SqlDbType.Int,4,arrtype[i]),
													data.MakeInParam("@id",SqlDbType.Int,4,result)	
												};
						data.RunProc("sp_Linkman_AddCustomLinkmanType",prams1);
					}
				}
			}
			
			return(result);
		}
		
		#endregion

		#region �����Զ�����ϵ��
		/// <summary>
		/// �����Զ�����ϵ��
		/// </summary>
		/// <param name="mlinkman"></param>
		public void UpdateCustomLinkman(CustomLinkman clinkman)
		{
			UDS.Components.Database data = new UDS.Components.Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@ID",SqlDbType.Int,4,clinkman.ID),
									   data.MakeInParam("@name",SqlDbType.VarChar,100,clinkman.Name),
									   data.MakeInParam("@Gender",SqlDbType.Bit,1,clinkman.Gender),
									   data.MakeInParam("@UnitTelephone",SqlDbType.VarChar,50,clinkman.UnitTelephone),
									   data.MakeInParam("@Email",SqlDbType.VarChar,50,clinkman.Email),
									   data.MakeInParam("@UnitAddress",SqlDbType.VarChar,200,clinkman.UnitAddress),
									   data.MakeInParam("@UnitZip",SqlDbType.VarChar,50,clinkman.UnitZip),
									   data.MakeInParam("@FamilyAddress",SqlDbType.VarChar,200,clinkman.FamilyAddress),
									   data.MakeInParam("@FamilyZip",SqlDbType.VarChar,50,clinkman.FamilyZip),
									   data.MakeInParam("@Mobile",SqlDbType.VarChar,100,clinkman.Mobile),
									   data.MakeInParam("@FamilyTelephone",SqlDbType.VarChar,100,clinkman.FamilyTelephone),
									   data.MakeInParam("@Memo",SqlDbType.VarChar,1000,clinkman.Memo),
									   data.MakeInParam("@Age",SqlDbType.VarChar,50,clinkman.Age),
									   data.MakeInParam("@Type",SqlDbType.VarChar,200,clinkman.Type)
								   };
			data.RunProc("sp_Linkman_UpdateCustomLinkman",prams);
		}
		#endregion

		#region ����Զ�����ϵ�˷���

		/// <summary>
		/// ����Զ�����ϵ�˷���
		/// </summary>
		/// <returns></returns>
		public SqlDataReader GetCustomLinkmanType()
		{
			UDS.Components.Database data = new UDS.Components.Database();
			SqlDataReader dr = null;
			data.RunProc("sp_Linkman_GetCustomLinkmanType",out dr);
			return(dr);
		}

		#endregion

		#region ���ݷ���õ��Զ�����ϵ��
		/// <summary>
		/// ���ݷ���õ��Զ�����ϵ��
		/// </summary>
		/// <param name="type">���id</param>
		/// <returns></returns>
		public SqlDataReader GetCustomLinkmanByType(int type,int staffid)
		{
			UDS.Components.Database data = new UDS.Components.Database();
			SqlParameter[] prams = {
										data.MakeInParam("@typeid",SqlDbType.Int,4,type),
										data.MakeInParam("@staffid",SqlDbType.Int,4,staffid)
								   };
			SqlDataReader dr = null;
			data.RunProc("sp_Linkman_GetCustomLinkmanByType",prams,out dr);
			return(dr);

		}
		#endregion

		#region �����Զ�����ϵ�˷���
		/// <summary>
		/// �����Զ�����ϵ�˷���
		/// </summary>
		/// <param name="mlinkman"></param>
		public void UpdateCustomLinkmanType(CustomLinkman clinkman)
		{
			UDS.Components.Database data = new UDS.Components.Database();
			if(clinkman.Type.IndexOf(',',0)!=-1)
			{
				string [] arrtype = clinkman.Type.Split(',');
				for(int i = 0;i<arrtype.Length;i++)
				{
					if(arrtype[i].Trim()!="")
					{
						SqlParameter[] prams1 = {
													data.MakeInParam("@typeid",SqlDbType.Int,4,arrtype[i]),
													data.MakeInParam("@id",SqlDbType.Int,4,clinkman.ID)	
												};
						data.RunProc("sp_Linkman_AddCustomLinkmanType",prams1);
					}
				}
			}
		}
		#endregion

		#region �����ϵ�˵���ϵ���б�
		/// <summary>
		/// �����ϵ�˵���ϵ���б�
		/// </summary>
		/// <param name="type">��ϵ�����1:Ա����ϵ��2:�ͻ���ϵ��3:�Զ�����ϵ��</param>
		/// <param name="id">��ϵ��id</param>
		/// <param name="staffid">�û�id</param>
		public void AddLinkmanToList(int type,int id,int staffid)
		{
			Database db = new Database();
			SqlParameter[] prams = {
									     db.MakeInParam("@type",SqlDbType.Int,4,type),
										 db.MakeInParam("@id",SqlDbType.Int,4,id),
										 db.MakeInParam("@staffid",SqlDbType.Int,4,staffid)
			};
			db.RunProc("sp_Linkman_AddToLinkmanList",prams);
		}
		#endregion

		#region ɾ����ϵ���б��е���ϵ��
		/// <summary>
		/// ɾ����ϵ���б��е���ϵ��
		/// </summary>
		/// <param name="id">��ϵ���б��е�id</param>
		public void DelLinkmanFromList(int type,int linkmanid)
		{
			Database db = new Database();
			SqlParameter[] prams = {
									   db.MakeInParam("@type",SqlDbType.Int,4,type),
									   db.MakeInParam("@linkmanid",SqlDbType.Int,4,linkmanid)
								   };
			db.RunProc("sp_Linkman_DelLinkmanFromList",prams);
		}
		#endregion

		#region �������Ƿ��Ѿ�����ϵ���б���
		/// <summary>
		/// �������Ƿ��Ѿ�����ϵ���б���
		/// </summary>
		/// <param name="type">��ϵ������(0:������ϵ��1:Ա����ϵ��2:�ͻ���ϵ��3:�Զ�����ϵ��)</param>
		/// <param name="staffid">�û�id</param>
		/// <param name="id">��ϵ��id</param>
		/// <returns></returns>
		public bool HaveInList(int type,int staffid,int id)
		{
			UDS.Components.Database data = new UDS.Components.Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@type",SqlDbType.Int,4,type),
									   data.MakeInParam("@staffid",SqlDbType.Int,4,staffid),
									   data.MakeInParam("@id",SqlDbType.Int,4,id)
								   };
			return((data.RunProc("sp_Linkman_HaveInList",prams)==1)?true:false);
		}
		#endregion

	}

	#region �Զ�����ϵ�˽ṹ
	/// <summary>
	/// �Զ�����ϵ�˽ṹ
	/// </summary>
	public class CustomLinkman
	{
		private int m_id;
		private string m_name="";
		private bool m_gender;
		private string m_email="";
		private string m_unittelephone="";
		private string m_unitaddress="";
		private string m_unitzip="";
		private string m_familytelephone="";
		private string m_familyaddress="";
		private string m_familyzip="";
		private string m_type="";
		private string m_mobile="";
		private string m_memo="";
		private string m_age = "";

		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			get{return m_id;}
			set{m_id = value;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Name
		{
			get{return m_name;}
			set{m_name = value;}
		}

		/// <summary>
		/// �Ա�
		/// </summary>
		public bool Gender
		{
			get{return m_gender;}
			set{m_gender = value;}
		}


		/// <summary>
		/// Email
		/// </summary>
		public string Email
		{
			get{return m_email;}
			set{m_email = value;}
		}

		/// <summary>
		/// ��λ�绰
		/// </summary>
		public string UnitTelephone
		{
			get{return m_unittelephone;}
			set{m_unittelephone = value;}
		}
		/// <summary>
		/// ��λ��ַ
		/// </summary>
		public string UnitAddress
		{
			get{return m_unitaddress;}
			set{m_unitaddress = value;}
		}

		/// <summary>
		/// ��λ�ʱ�
		/// </summary>
		public string UnitZip
		{
			get{return m_unitzip;}
			set{m_unitzip = value;}
		}

		/// <summary>
		/// ��ͥ�绰
		/// </summary>
		public string FamilyTelephone
		{
			get{return m_familytelephone;}
			set{m_familytelephone = value;}
		}

		/// <summary>
		/// ��ͥ��ַ
		/// </summary>
		public string FamilyAddress
		{
			get{return m_familyaddress;}
			set{m_familyaddress = value;}
		}

		/// <summary>
		/// ��ͥ�ʱ�
		/// </summary>
		public string FamilyZip
		{
			get{return m_familyzip;}
			set{m_familyzip = value;}
		}

		/// <summary>
		/// ��������
		/// </summary>
		public string Type
		{
			get{return m_type;}
			set{m_type = value;}
		}

		/// <summary>
		/// �ֻ�
		/// </summary>
		public string Mobile
		{
			get{return m_mobile;}
			set{m_mobile = value;}
		}

		/// <summary>
		/// ��ע
		/// </summary>
		public string Memo
		{
			get{return m_memo;}
			set{m_memo = value;}
		}

		/// <summary>
		/// ����
		/// </summary>
		public string Age
		{
			get{return m_age;}
			set{m_age = value;}
		}
	}
	#endregion
}
