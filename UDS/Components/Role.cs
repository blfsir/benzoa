using System;
using System.Data;
using System.Data.SqlClient;
//５１ａsｐx
namespace UDS.Components
{
	/// <summary>
	/// Role 的摘要说明。
	/// </summary>
	public class Role
	{

		public Role()
		{
			
		}
		/// <summary>
		/// 添加角色
		/// </summary>
		/// <param name="rolename">角色名</param>
		/// <param name="roledescription">角色描述</param>
		/// <returns>角色ID</returns>
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
		/// 删除角色
		/// </summary>
		/// <param name="roleid">角色ID</param>
		/// <returns>0成功1不成功</returns>
		public static int Delete(int roleid)
		{
			UDS.Components.Database db = new UDS.Components.Database();
			SqlParameter[] prams = {
									   db.MakeInParam("@role_id",SqlDbType.Int,4,roleid)
								   };
			return(db.RunProc("sp_DeleteRole",prams));
		}
		/// <summary>
		/// 修改角色信息
		/// </summary>
		/// <param name="roleid">角色ID</param>
		/// <param name="rolename">角色名称</param>
		/// <param name="roledescription">角色描述</param>
		/// <returns>返回值（0成功1不成功）</returns>
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
		/// 从角色中删除成员
		/// </summary>
		/// <param name="roleid">角色id</param>
		/// <param name="staffid">成员id</param>
		/// <returns>返回值</returns>
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
		/// 从角色中添加成员
		/// </summary>
		/// <param name="roleid">角色id</param>
		/// <param name="staffid">非成员id</param>
		/// <returns>返回值</returns>
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
		/// 根据rolename得到roleid
		/// </summary>
		/// <param name="rolename">角色名称</param>
		/// <returns>角色id</returns>
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
