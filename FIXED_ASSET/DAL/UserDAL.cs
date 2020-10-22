using FIXED_ASSET.DTO;
using POSX.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FIXED_ASSET.DAL
{
	public class UserDAL
	{
		public static SqlConnection conn = new SqlConnection(DBConnection.GetConnectionString());

		public DataTable UserLogin_Check(string _UName, string _Pass, string _pKey, string _oRg)
		{
			DataTable dt = new DataTable();
			if (conn.State == 0)
			{
				conn.Open();
			}
			SqlCommand cmd = new SqlCommand("SP_ULogin", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@pLid", SqlDbType.NVarChar).Value = _UName;
			cmd.Parameters.Add("@pPass", SqlDbType.NVarChar).Value = _Pass;
			cmd.Parameters.Add("@pKey", SqlDbType.NVarChar).Value = _pKey;
			cmd.Parameters.Add("@oRg", SqlDbType.NVarChar).Value = _oRg;
			SqlDataAdapter adpt = new SqlDataAdapter(cmd);
			adpt.Fill(dt);

			return dt;
		}

		public DataTable UserMenuDetails(string _UName, string _pKey, string _oRg)
		{
			DataTable dt = new DataTable();
			if (conn.State == 0)
			{
				conn.Open();
			}
			SqlCommand cmd = new SqlCommand("SP_Authentication", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@pLid", SqlDbType.NVarChar).Value = _UName;
			cmd.Parameters.Add("@pKey", SqlDbType.NVarChar).Value = _pKey;
			cmd.Parameters.Add("@oRg", SqlDbType.NVarChar).Value = _oRg;
			SqlDataAdapter adpt = new SqlDataAdapter(cmd);
			adpt.Fill(dt);
			return dt;
		}

		public DataTable UserMenuRoleDetails(int RoleID)
		{
			DataTable dt = new DataTable();
			if (conn.State == 0)
			{
				conn.Open();
			}
			SqlCommand cmd = new SqlCommand("USP_SYS_Role_MenuStatus", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = RoleID;
			SqlDataAdapter adpt = new SqlDataAdapter(cmd);
			adpt.Fill(dt);
			return dt;
		}

		public DataTable Sales_Barcode_View()
		{
			DataTable dt = new DataTable();
			if (conn.State == 0)
			{
				conn.Open();
			}
			SqlCommand cmd = new SqlCommand("USP_Sales_Barcode_View", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter adpt = new SqlDataAdapter(cmd);
			adpt.Fill(dt);
			return dt;
		}

		public List<RoleDTO> GetRoles()
		{
			List<RoleDTO> roleList = new List<RoleDTO>();

			using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
			{
				SqlCommand cmd = new SqlCommand("USP_SYS_Role_View", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				con.Open();
				da.Fill(dt);
				con.Close();
				if (roleList != null)
				{
					roleList = (from DataRow dr in dt.Rows
								select new RoleDTO()
								{
									R_ID = Convert.ToInt32(dr["R_ID"]),
									RNAME = Convert.ToString(dr["RNAME"]),
									STATUS = Convert.ToBoolean(dr["STATUS"])
								}).ToList();
				}

			}

			return roleList;
		}

		public List<EmployeeDTO> GetEmplyees()
		{
			List<EmployeeDTO> employeeList = new List<EmployeeDTO>();

			using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
			{
				con.Open();
				SqlCommand cmd = new SqlCommand("USP_SYS_Salesforce_Assign_View", con);
				cmd.CommandType = CommandType.StoredProcedure;

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();

				da.Fill(dt);
				con.Close();
				if (employeeList != null)
				{
					employeeList = (from DataRow dr in dt.Rows
									select new EmployeeDTO
									{
										EMP_ID = Convert.ToInt32(dr["EMP_ID"]),
										Name = Convert.ToString(dr["Name"]),
										RNAME = Convert.ToString(dr["EMP_ROLE"]),
										Assigned_BU_ID = Convert.ToString(dr["Assigned_BU_ID"]),
										Start_Date = Convert.ToDateTime(dr["Start_Date"]),
										End_Date = Convert.ToDateTime(dr["End_Date"])
									}).ToList();
				}

			}

			return employeeList;
		}


		public bool AddRole(RoleDTO roleDTO)
		{
			bool flag;

			using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
			{
				if (con.State == 0)
				{
					con.Open();
				}

				SqlCommand cmd = new SqlCommand("USP_SYS_Role_Entry", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@RoleName", roleDTO.RNAME);
				cmd.Parameters.AddWithValue("@Status", roleDTO.STATUS);

				int i = cmd.ExecuteNonQuery();
				if (i > 0)
				{
					flag = true;
				}
				else
				{
					flag = false;
				}
			}
			return flag;
		}

		public bool UpdateUserRole(RoleEmpDTO roleEmpDTO)
		{
			bool flag;

			using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
			{
				if (con.State == 0)
				{
					con.Open();
				}

				SqlCommand cmd = new SqlCommand("USP_SYS_EMPRole_Update", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@RoleID", roleEmpDTO.RoleID);
				cmd.Parameters.AddWithValue("@EmpID", roleEmpDTO.EmpID);

				int i = cmd.ExecuteNonQuery();
				if (i > 0)
				{
					flag = true;
				}
				else
				{
					flag = false;
				}
			}
			return flag;
		}

		public bool Salesforce_Assign(int EmpID, int BusinessUnitID, string StartDt, string Created_By)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
				{
					if (con.State == 0)
					{
						con.Open();
					}

					SqlCommand cmd = new SqlCommand("USP_SYS_Salesforce_Assign_Posting", con);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@EmpID", EmpID);
					cmd.Parameters.AddWithValue("@BusinessUnitID", BusinessUnitID);
					cmd.Parameters.AddWithValue("@StartDt", StartDt);
					cmd.Parameters.AddWithValue("@Created_By", Created_By);

					int i = cmd.ExecuteNonQuery();
					if (i > 0)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				//return false;
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}


		public bool UpdateMenupermission(int R_ID, string ME_ID)
		{
			bool flag;

			using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
			{
				if (con.State == 0)
				{
					con.Open();
				}
				// var menu = string.Join(",", ME_ID);
				SqlCommand cmd = new SqlCommand("USP_Update_Menupermission", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@R_ID", R_ID);
				cmd.Parameters.AddWithValue("@ME_ID", ME_ID);

				int i = cmd.ExecuteNonQuery();
				if (i > 0)
				{
					flag = true;
				}
				else
				{
					flag = false;
				}
			}
			return flag;
		}


		public int DuplicateCount(RoleDTO roleDTO)
		{
			List<RoleDTO> _checkUnique = (from d in GetRoles()
										  where d.RNAME == roleDTO.RNAME
										  select d).ToList();
			return _checkUnique.Count;
		}


		public List<OrganizationDTO> GetBusinessUnitList()
		{
			List<OrganizationDTO> employeeList = new List<OrganizationDTO>();

			using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
			{
				SqlCommand cmd = new SqlCommand("USP_Organization_List", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				con.Open();
				da.Fill(dt);
				con.Close();
				if (employeeList != null)
				{
					employeeList = (from DataRow dr in dt.Rows
									select new OrganizationDTO
									{
										Organization_ID = Convert.ToInt32(dr["Organization_ID"]),
										Organization_Name = Convert.ToString(dr["Organization_Name"])
									}).ToList();
				}

			}

			return employeeList;
		}

		public List<EmployeeDTO> Employee_Lookup(int employeeID)
		{
			List<EmployeeDTO> employeeList = new List<EmployeeDTO>();

			using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
			{
				// con.Open();
				SqlCommand cmd = new SqlCommand("USP_SYS_Employee_Lookup", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@EmpID", employeeID);
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				con.Open();
				da.Fill(dt);
				con.Close();
				if (employeeList != null)
				{
					employeeList = (from DataRow dr in dt.Rows
									select new EmployeeDTO
									{
										EMP_ID = Convert.ToInt32(dr["EMP_ID"]),
										Name = Convert.ToString(dr["Name"]),
										RNAME = Convert.ToString(dr["RoleName"]),
									}).ToList();
				}

			}

			return employeeList;
		}
		public int GetBusinessUnit_ID(string _OutLetRegNo)
		{
			int BusinessUnit_ID = 0;

			DataTable dt = new DataTable();
			if (conn.State == 0)
			{
				conn.Open();
			}
			SqlCommand cmd = new SqlCommand("USP_SYS_Organization_View", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@External_ID", SqlDbType.NVarChar).Value = _OutLetRegNo;
			cmd.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter adpt = new SqlDataAdapter(cmd);
			adpt.Fill(dt);
			DataRow[] foundRows;
			foundRows = dt.Select();

			foreach (DataRow row in foundRows)
			{
				BusinessUnit_ID = Convert.ToInt32(row["Business_ID"].ToString());
			}
			return BusinessUnit_ID;
		}
	}
}