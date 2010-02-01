using System;
using System.Data;
using System.Data.SqlClient;
//������s��x
namespace UDS.Components
{
	/// <summary>
	/// Role ��ժҪ˵����
	/// </summary>
	public class Role
	{

		public Role()
		{
			
		}
		/// <summary>
		/// ��ӽ�ɫ
		/// </summary>
		/// <param name="rolename">��ɫ��</param>
		/// <param name="roledescription">��ɫ����</param>
		/// <returns>��ɫID</returns>
		public static int Add(string rolename,string roledescription)
		{
			UDS.Components.Database db = new UDS.Components.Database();
			SqlParameter[] prams = {
										db.MakeInParam("@Role_Name",SqlDbType.VarChar,300,rolename.Trim()),
										db.MakeInParam("@Role_Description",SqlDbType.VarChar,300,roledescription.Trim())
								   };
			return(db.RunProc("sp_AddMyRole",prams));
		}
		/// <summary>
		/// ɾ����ɫ
		/// </summary>
		/// <param name="roleid">��ɫID</param>
		/// <returns>0�ɹ�1���ɹ�</returns>
		public static int Delete(int roleid)
		{
			UDS.Components.Database db = new UDS.Components.Database();
			SqlParameter[] prams = {
									   db.MakeInParam("@role_id",SqlDbType.Int,4,roleid)
								   };
			return(db.RunProc("sp_DeleteRole",prams));
		}
		/// <summary>
		/// �޸Ľ�ɫ��Ϣ
		/// </summary>
		/// <param name="roleid">��ɫID</param>
		/// <param name="rolename">��ɫ����</param>
		/// <param name="roledescription">��ɫ����</param>
		/// <returns>����ֵ��0�ɹ�1���ɹ���</returns>
		public static int Modify(int roleid,string rolename,string roledescription)
		{
			UDS.Components.Database db = new UDS.Components.Database();
			SqlParameter[] prams = {
										db.MakeInParam("@role_id",SqlDbType.Int ,4,roleid),
										db.MakeInParam("@role_name",SqlDbType.VarChar,300,rolename.Trim()),
										db.MakeInParam("@role_description",SqlDbType.VarChar,300,roledescription.Trim())
								   };
			return(db.RunProc("sp_UpdateRoleInfo",prams));
		}
		/// <summary>
		/// �ӽ�ɫ��ɾ����Ա
		/// </summary>
		/// <param name="roleid">��ɫid</param>
		/// <param name="staffid">��Աid</param>
		/// <returns>����ֵ</returns>
		public static int DelStaffFromRole(int roleid,string staffid)
		{
			UDS.Components.Database db = new UDS.Components.Database();
			SqlParameter[] prams = {
										db.MakeInParam("@Role_ID",SqlDbType.Int,4,roleid),
										db.MakeInParam("@StaffIDS",SqlDbType.VarChar,3000,staffid)
								   };
			return(db.RunProc("sp_DeleteStaffFromRole",prams));
		}
		/// <summary>
		/// �ӽ�ɫ����ӳ�Ա
		/// </summary>
		/// <param name="roleid">��ɫid</param>
		/// <param name="staffid">�ǳ�Աid</param>
		/// <returns>����ֵ</returns>
		public static int AddStaffFromRole(int roleid,string staffid)
		{
			UDS.Components.Database db = new UDS.Components.Database();
			SqlParameter[] prams = {
										db.MakeInParam("@Role_ID",SqlDbType.Int,4,roleid),
										db.MakeInParam("@StaffIDS",SqlDbType.VarChar,3000,staffid)
								   };
			return(db.RunProc("sp_AddStaffToRole",prams));
		}
		/// <summary>
		/// ����rolename�õ�roleid
		/// </summary>
		/// <param name="rolename">��ɫ����</param>
		/// <returns>��ɫid</returns>
		public static int GetRoleIDByName(string rolename)
		{
			UDS.Components.Database db = new UDS.Components.Database();
			int roleid = 0;
			SqlDataReader dr = null;
			SqlParameter[] prams = {
									   db.MakeInParam("@rolename",SqlDbType.VarChar,100,rolename),
								   };
            try
            {
                db.RunProc("sp_GetRoleIDFromName", prams, out dr);
                while (dr.Read())
                {
                    roleid = Int32.Parse(dr["role_id"].ToString());
                }
            }
            finally
            {
                db.Close();
            }
			return(roleid);
		}
		public SqlDataReader GetRoleInfo(long RoleID)
		{
			UDS.Components.Database db = new UDS.Components.Database();
			SqlDataReader dr = null;
			SqlParameter[] prams = {
									   db.MakeInParam("@RoleID",SqlDbType.Int ,4,RoleID),
			};
			db.RunProc("sp_GetRoleInfo",prams,out dr);

			return(dr);

		}

		public string GetRoleInfo(long RoleID,string FiledName)
		{
			UDS.Components.Database db = new UDS.Components.Database();
			SqlDataReader dr = null;
			SqlParameter[] prams = {
									   db.MakeInParam("@RoleID",SqlDbType.Int ,4,RoleID),
			};
			db.RunProc("sp_GetRoleInfo",prams,out dr);
			try
			{
				if(dr.Read())	
				{
					try
					{
						return dr[FiledName].ToString();
					}
					catch
					{
						return "";
					}
				}
				else
					return "";
			}
			finally
			{

                if (db != null)
                {
                    db.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                    dr.Dispose();
                }
				dr = null;
				db = null;
			}

		}


	}
}
