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
	public class CategoryDAL
	{

		public static SqlConnection conn = new SqlConnection(DBConnection.GetConnectionString());

		CategoryDTO categoryDTO = new CategoryDTO();

		public List<CategoryDTO> GetCategories()
		{
			List<CategoryDTO> categoryList = new List<CategoryDTO>();

			using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
			{
				SqlCommand cmd = new SqlCommand("USP_Category", con);
				cmd.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				con.Open();
				da.Fill(dt);
				con.Close();
				if (categoryList != null)
				{
					categoryList = (from DataRow dr in dt.Rows
									select new CategoryDTO()
									{
										C_ID = Convert.ToInt32(dr["C_ID"]),
										E_ID = dr.IsNull("E_ID") ? null : Convert.ToString(dr["E_ID"]),
										SHNAME = dr.IsNull("SHNAME") ? null : Convert.ToString(dr["SHNAME"]),
										Description = dr.IsNull("Description") ? null : Convert.ToString(dr["Description"]),
										Status = dr.IsNull("Status") ? null : Convert.ToBoolean(dr["Status"]) == true ? "Active" : "InActive",
										tST = Convert.ToBoolean(dr["Status"])
									}).ToList();
				}

			}

			return categoryList;
		}

		public DataTable SaveCategory(NewCategoryDTO categoryDTO, string userid)
		{
			try
			{

				DataTable dt = new DataTable();
				if (conn.State == 0)
				{
					conn.Open();
				}
				SqlCommand cmd = new SqlCommand("SP_CATEGORY", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@eID", categoryDTO.eID);
				cmd.Parameters.AddWithValue("@sName", categoryDTO.sName);
				cmd.Parameters.AddWithValue("@dEsc", categoryDTO.dEsc);
				cmd.Parameters.AddWithValue("@cBy", userid);
				cmd.Parameters.AddWithValue("@sTatus", categoryDTO.sTatus);
				cmd.Parameters.AddWithValue("@sT", 1);
				SqlDataAdapter adpt = new SqlDataAdapter(cmd);
				adpt.Fill(dt);
				return dt;

			}
			catch (Exception ex)
			{
				throw ex.InnerException;

			}
		}

		public DataTable UpdateCategory(NewCategoryDTO categoryDTO, string userid)
		{
			try
			{

				DataTable dt = new DataTable();
				if (conn.State == 0)
				{
					conn.Open();
				}
				SqlCommand cmd = new SqlCommand("SP_CATEGORY", conn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@eID", categoryDTO.eID);
				cmd.Parameters.AddWithValue("@sName", categoryDTO.sName);
				cmd.Parameters.AddWithValue("@dEsc", categoryDTO.dEsc);
				cmd.Parameters.AddWithValue("@cBy", userid);
				cmd.Parameters.AddWithValue("@sTatus", categoryDTO.sTatus);
				cmd.Parameters.AddWithValue("@sT", 2);
				SqlDataAdapter adpt = new SqlDataAdapter(cmd);
				adpt.Fill(dt);
				return dt;

			}
			catch (Exception ex)
			{
				throw ex.InnerException;

			}
		}

		public DataTable SaveSubCategory(SubCategoryDTO subCategoryDTO)
		{
			try
			{

				DataTable dt = new DataTable();
				if (conn.State == 0)
				{
					conn.Open();
				}
				SqlCommand cmd = new SqlCommand("SP_SUBCATEGORY", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@C_ID", subCategoryDTO.C_ID);
				cmd.Parameters.AddWithValue("@SEN_ID", subCategoryDTO.SEN_ID);
				cmd.Parameters.AddWithValue("@SHNAME", subCategoryDTO.SHNAME);
				cmd.Parameters.AddWithValue("@Descritpin", subCategoryDTO.Description);
				cmd.Parameters.AddWithValue("@sTatus", Convert.ToBoolean(subCategoryDTO.Status));
				cmd.Parameters.AddWithValue("@sT", 1);
				SqlDataAdapter adpt = new SqlDataAdapter(cmd);
				adpt.Fill(dt);
				return dt;

			}
			catch (Exception ex)
			{
				throw ex.InnerException;

			}
		}

		public DataTable UpdateSubCategory(SubCategoryDTO subCategoryDTO)
		{
			try
			{

				DataTable dt = new DataTable();
				if (conn.State == 0)
				{
					conn.Open();
				}
				SqlCommand cmd = new SqlCommand("SP_SUBCATEGORY", conn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@C_ID", subCategoryDTO.C_ID);
				cmd.Parameters.AddWithValue("@SEN_ID", subCategoryDTO.S_ID);
				cmd.Parameters.AddWithValue("@SHNAME", subCategoryDTO.SHNAME);
				cmd.Parameters.AddWithValue("@Descritpin", subCategoryDTO.Description);
				cmd.Parameters.AddWithValue("@sTatus", Convert.ToBoolean(subCategoryDTO.Status));
				cmd.Parameters.AddWithValue("@sT", 2);
				SqlDataAdapter adpt = new SqlDataAdapter(cmd);
				adpt.Fill(dt);
				return dt;

			}
			catch (Exception ex)
			{
				throw ex.InnerException;

			}
		}

		public List<SubCategoryDTO> GetSubCategories()
		{
			List<SubCategoryDTO> subCategoryList = new List<SubCategoryDTO>();

			if (conn.State == 0)
			{
				conn.Open();
			}

			SqlCommand cmd = new SqlCommand("SP_SUBCATEGORY_LIST", conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			if (subCategoryList != null)
			{
				subCategoryList = (from DataRow dr in dt.Rows
								   select new SubCategoryDTO()
								   {
									   CategoryName = dr.IsNull("Description") ? null : Convert.ToString(dr["Description"]),
									   S_ID = Convert.ToInt32(dr["S_ID"]),
									   SEN_ID = dr.IsNull("SEN_ID") ? null : Convert.ToString(dr["SEN_ID"]),
									   SHNAME = dr.IsNull("SHNAME") ? null : Convert.ToString(dr["SHNAME"]),
									   Description = dr.IsNull("Descritpin") ? null : Convert.ToString(dr["Descritpin"]),
									   Status = dr.IsNull("Status") ? null : Convert.ToBoolean(dr["Status"]) == true ? "Active" : "InActive"
								   }).ToList();
			}



			return subCategoryList;
		}

        public List<SegmentDTO> GetSegments()
        {
            List<SegmentDTO> segmentList = new List<SegmentDTO>();

            if (conn.State == 0)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand("USP_Segment_List", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (segmentList != null)
            {
                segmentList = (from DataRow dr in dt.Rows
                               select new SegmentDTO()
                               {
                                   Category = dr.IsNull("Categroy") ? null : Convert.ToString(dr["Categroy"]),
                                   Subcategory = dr.IsNull("Descritpin") ? null : Convert.ToString(dr["Descritpin"]),
                                   SEG_ID = Convert.ToInt16(dr["SEG_ID"]),
                                   SEGEN_ID = dr.IsNull("SEGEN_ID") ? null : Convert.ToString(dr["SEGEN_ID"]),
                                   SHORTNAME = dr.IsNull("SHORTNAME") ? null : Convert.ToString(dr["SHORTNAME"]),
                                   Description = dr.IsNull("Description") ? null : Convert.ToString(dr["Description"]),
                                   Status = dr.IsNull("Status") ? null : Convert.ToBoolean(dr["Status"]) == true ? "ACTIVE" : "INACTIVE"
                               }).ToList();
            }



            return segmentList;
        }

        public DataTable SaveSegment(SegmentDTO segment)
        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("SP_SEGMENT", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@S_ID", segment.S_ID);
                cmd.Parameters.AddWithValue("@SEGEN_ID", segment.SEGEN_ID);
                cmd.Parameters.AddWithValue("@SHORTNAME", segment.SHORTNAME);
                cmd.Parameters.AddWithValue("@Description", segment.Description);
                cmd.Parameters.AddWithValue("@sTatus", segment.Status);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                throw ex.InnerException;

            }
        }

        public DataTable UpdateSegment(SegmentDTO segment)
        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("SP_SEGMENT", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@S_ID", segment.S_ID);
                cmd.Parameters.AddWithValue("@SEGEN_ID", segment.SEG_ID);
                cmd.Parameters.AddWithValue("@SHORTNAME", segment.SHORTNAME);
                cmd.Parameters.AddWithValue("@Description", segment.Description);
                cmd.Parameters.AddWithValue("@sTatus", segment.Status);
                cmd.Parameters.AddWithValue("@sT", 2);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                throw ex.InnerException;

            }
        }


        public List<CategoryDTO> GetOldCategories()
		{
			DataTable dt = new DataTable();
			if (conn.State == 0)
			{
				conn.Open();
			}

			SqlCommand cmd = new SqlCommand("SP_OldCategoryList", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(dt);



			List<CategoryDTO> categoryList = new List<CategoryDTO>();

			if (categoryList != null)
			{
				categoryList = (from DataRow dr in dt.Rows
								select new CategoryDTO()
								{
									C_ID = Convert.ToInt32(dr["Cid"]),
									Description = dr.IsNull("Description") ? null : Convert.ToString(dr["Description"]),
								}).ToList();
			}

			return categoryList;

		}

		public DataTable SaveOldCategory(string description)
		{
			try
			{

				DataTable dt = new DataTable();
				if (conn.State == 0)
				{
					conn.Open();
				}
				SqlCommand cmd = new SqlCommand("SP_RPTCATEGORY", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@cID", 0);
				cmd.Parameters.AddWithValue("@dEsc", description);
				cmd.Parameters.AddWithValue("@sT", 1);
				SqlDataAdapter adpt = new SqlDataAdapter(cmd);
				adpt.Fill(dt);
				return dt;

			}
			catch (Exception ex)
			{
				throw ex.InnerException;

			}
		}

		public DataTable UpdateOldCategory(string description, int cid)
		{
			try
			{

				DataTable dt = new DataTable();
				if (conn.State == 0)
				{
					conn.Open();
				}
				SqlCommand cmd = new SqlCommand("SP_RPTCATEGORY", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@cID", cid);
				cmd.Parameters.AddWithValue("@dEsc", description);
				cmd.Parameters.AddWithValue("@sT", 2);
				SqlDataAdapter adpt = new SqlDataAdapter(cmd);
				adpt.Fill(dt);
				return dt;

			}
			catch (Exception ex)
			{
				throw ex.InnerException;

			}
		}


		public List<SubCategoryDTO> GetOldSubCategories()
		{
			DataTable dt = new DataTable();
			if (conn.State == 0)
			{
				conn.Open();
			}

			SqlCommand cmd = new SqlCommand("SP_OldSubCategory_List", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@CatID", SqlDbType.Int).Value = 0;
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(dt);



			List<SubCategoryDTO> subCategoryList = new List<SubCategoryDTO>();

			if (subCategoryList != null)
			{
				subCategoryList = (from DataRow dr in dt.Rows
								   select new SubCategoryDTO()
								   {
									   S_ID = Convert.ToInt32(dr["Sid"]),
									   C_ID = Convert.ToInt32(dr["Cid"]),
									   CategoryName = dr.IsNull("Category") ? null : Convert.ToString(dr["Category"]),
									   Description = dr.IsNull("SubCategory") ? null : Convert.ToString(dr["SubCategory"]),
								   }).ToList();
			}

			return subCategoryList;

		}

		public DataTable SaveOldSubCategory(string description, int cid)
		{
			try
			{

				DataTable dt = new DataTable();
				if (conn.State == 0)
				{
					conn.Open();
				}
				SqlCommand cmd = new SqlCommand("SP_RPTSUBCATEGORY", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@cID", cid);
				cmd.Parameters.AddWithValue("@dEsc", description);
				cmd.Parameters.AddWithValue("@sT", 1);
				SqlDataAdapter adpt = new SqlDataAdapter(cmd);
				adpt.Fill(dt);
				return dt;

			}
			catch (Exception ex)
			{
				throw ex.InnerException;

			}
		}

		public DataTable UpdateOldSubCategory(string description, int cid, int sid)
		{
			try
			{

				DataTable dt = new DataTable();
				if (conn.State == 0)
				{
					conn.Open();
				}

				SqlCommand cmd = new SqlCommand("SP_RPTSUBCATEGORY", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@sID", sid);
				cmd.Parameters.AddWithValue("@cID", cid);
				cmd.Parameters.AddWithValue("@dEsc", description);
				cmd.Parameters.AddWithValue("@sT", 2);
				SqlDataAdapter adpt = new SqlDataAdapter(cmd);
				adpt.Fill(dt);
				return dt;

			}
			catch (Exception ex)
			{
				throw ex.InnerException;

			}
		}

	}
}