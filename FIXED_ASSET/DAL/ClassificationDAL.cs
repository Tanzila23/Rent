using FIXED_ASSET.DTO;
using POSX.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FIXED_ASSET.DAL
{
    public class ClassificationDAL
    {
        public static SqlConnection conn = new SqlConnection(DBConnection.GetConnectionString());

        CategoryDTO categoryDTO = new CategoryDTO();
        //public DataTable SaveClassification(ClassificationDTO classificationDTO, string userid)
        //{
        //    try
        //    {

        //        DataTable dt = new DataTable();
        //        if (conn.State == 0)
        //        {
        //            conn.Open();
        //        }
        //        SqlCommand cmd = new SqlCommand("SP_CLASSIFICATION", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@eID", classificationDTO.eID);
        //        cmd.Parameters.AddWithValue("@code", classificationDTO.code);
        //        cmd.Parameters.AddWithValue("@dEsc", classificationDTO.dEsc);
        //        cmd.Parameters.AddWithValue("@cBy", userid);
        //        cmd.Parameters.AddWithValue("@sTatus", classificationDTO.sTatus);
        //        cmd.Parameters.AddWithValue("@sT", 1);
        //        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
        //        adpt.Fill(dt);
        //        return dt;

        //    }
        //   catch (Exception ex)
        //    {
        //        throw ex.InnerException;

        //    }
        //}
        public DataTable SaveClassification(string eID, string code, string dEsc, string userid, bool sTatus)
        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_CLASSIFICATION", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", eID);
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@dEsc", dEsc);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ViewClassificationDTO> GetClassification()
        {
            List<ViewClassificationDTO> classificationList = new List<ViewClassificationDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_CLASSIFICATION", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (classificationList != null)
                {
                    classificationList = (from DataRow dr in dt.Rows
                                    select new ViewClassificationDTO()
                                    {
                                        CLASS_ID = Convert.ToInt32(dr["CLASS_ID"]),
                                        EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                                        CODE = dr.IsNull("CODE") ? null : Convert.ToString(dr["CODE"]),
                                        DESCRIPTION = dr.IsNull("DESCRIPTION") ? null : Convert.ToString(dr["DESCRIPTION"]),
                                        STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
                                        CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                    }).ToList();
                }

            }

            return classificationList;
        }
        public ViewClassificationDTO getData(int classId)
        {
            ViewClassificationDTO Cat = new ViewClassificationDTO();
          

            if (conn.State == 0)
            {
                conn.Open();
            }

            if (classId != 0)
            {

                string selectData = "select CLASS_ID,EXTERNAL_ID,DESCRIPTION,CODE,STATUS  from ASS_CLASSIFICATION where CLASS_ID = " + classId + "";

                


                SqlCommand cmd = new SqlCommand(selectData, conn);

                

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ViewClassificationDTO()
                           {
                               CLASS_ID = Convert.ToInt32(dr["CLASS_ID"]),
                               EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                               CODE = dr.IsNull("CODE") ? null : Convert.ToString(dr["CODE"]),
                               DESCRIPTION = dr.IsNull("DESCRIPTION") ? null : Convert.ToString(dr["DESCRIPTION"]),
                               STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
                              
                           }).FirstOrDefault();
                }


            }
            return Cat;
        }

        public DataTable UpdateClassification(string eID, string code, string dEsc, string userid, bool sTatus
       )
        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("SP_CLASSIFICATION", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", eID);
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@dEsc", dEsc);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
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

        public DataTable SaveDepartment(string eID, string code, string dEsc, string userid, bool sTatus)
        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_DEPARTMENT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", eID);
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@dEsc", dEsc);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ViewDepartmentDTO> GetDepartment()
        {
            List<ViewDepartmentDTO> departmentList = new List<ViewDepartmentDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_DEPARTMENT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (departmentList != null)
                {
                    departmentList = (from DataRow dr in dt.Rows
                                          select new ViewDepartmentDTO()
                                          {
                                              DEPT_ID = Convert.ToInt32(dr["DEPT_ID"]),
                                              EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                                              CODE = dr.IsNull("CODE") ? null : Convert.ToString(dr["CODE"]),
                                              DESCRIPTION = dr.IsNull("DESCRIPTION") ? null : Convert.ToString(dr["DESCRIPTION"]),
                                              STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
                                              CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                          }).ToList();
                }

            }

            return departmentList;
        }
        public ViewDepartmentDTO getDepartmentData(int deptId)
        {
            ViewDepartmentDTO Cat = new ViewDepartmentDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (deptId != 0)
            {

                string selectData = "select DEPT_ID,EXTERNAL_ID,DESCRIPTION,CODE,STATUS  from ASS_DEPARTMENT where DEPT_ID = " + deptId + "";




                SqlCommand cmd = new SqlCommand(selectData, conn);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ViewDepartmentDTO()
                           {
                               DEPT_ID = Convert.ToInt32(dr["DEPT_ID"]),
                               EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                               CODE = dr.IsNull("CODE") ? null : Convert.ToString(dr["CODE"]),
                               DESCRIPTION = dr.IsNull("DESCRIPTION") ? null : Convert.ToString(dr["DESCRIPTION"]),
                               STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",

                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public DataTable UpdateDepartment(string eID, string code, string dEsc, string userid, bool sTatus
  )
        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("SP_DEPARTMENT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", eID);
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@dEsc", dEsc);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
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
        public DataTable GetClassList()
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_ClASSLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }

        public DataTable GetReasonList()
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_REASONLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetUserList()
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_User_List", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetDepartmentList()
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_Department_List", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetLocationWiseDepartmentList( string _org_id)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_Loc_Dep_List", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@org_id", _org_id);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetSupplierList()
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_SUPPLIERLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetSupplierItemList(string _model_list)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_ITEMSUPPLIERLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Model_ID", _model_list);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetManufactureList(string _model_list)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_MANUFACTURELIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Model_ID", _model_list);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetManufactureModelList()
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_MODELMANUFACTURELIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
               // cmd.Parameters.AddWithValue("@Model_ID", _model_list);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public List<ArticleMatrixDTO> SizeDropDownList()
        {
            List<ArticleMatrixDTO> articleMatrixList = new List<ArticleMatrixDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_Matrix_List", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Maxtrix_TypeID", 102);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (articleMatrixList != null)
                {
                    articleMatrixList = (from DataRow dr in dt.Rows
                                         select new ArticleMatrixDTO()
                                         {
                                             ARTMID = Convert.ToInt32(dr["ARTMID"]),
                                             EXTID = dr.IsNull("EXTID") ? null : Convert.ToString(dr["EXTID"]),
                                             DISCODE = Convert.ToString(dr["DISCODE"]),
                                             DESCRIPTION = dr.IsNull("DESCRIPTION") ? null : Convert.ToString(dr["DESCRIPTION"])
                                             // STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive"
                                         }).ToList();
                }

            }

            return articleMatrixList;
        }
        public List<ArticleMatrixDTO> ColorDropDownList()
        {
            List<ArticleMatrixDTO> articleMatrixList = new List<ArticleMatrixDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_Matrix_List", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Maxtrix_TypeID", 101);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (articleMatrixList != null)
                {
                    articleMatrixList = (from DataRow dr in dt.Rows
                                         select new ArticleMatrixDTO()
                                         {
                                             ARTMID = Convert.ToInt32(dr["ARTMID"]),
                                             EXTID = dr.IsNull("EXTID") ? null : Convert.ToString(dr["EXTID"]),
                                             DISCODE = Convert.ToString(dr["DISCODE"]),
                                             DESCRIPTION = dr.IsNull("DESCRIPTION") ? null : Convert.ToString(dr["DESCRIPTION"])
                                             //  STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive"
                                         }).ToList();
                }

            }

            return articleMatrixList;
        }
        public DataTable BindConversionUnit()
        {
            DataTable dt = new DataTable();
            if (conn.State == 0)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SP_CONVERSION_LIST", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UNITID", "");
            cmd.Parameters.AddWithValue("@sT", 3);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            return dt;
        }
        public DataTable SaveAssetCategory(string eID, string cNAME,string code, string dEsc, string userid, bool sTatus)
        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_ASS_CATEGORY", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", eID);
                cmd.Parameters.AddWithValue("@clID", cNAME);
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@dEsc", dEsc);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ViewAssetCategoryDTO> GetAssestsCategory()
        {
            List<ViewAssetCategoryDTO> assetCategoryList = new List<ViewAssetCategoryDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_ASSEST_CATEGORY", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetCategoryList != null)
                {
                    assetCategoryList = (from DataRow dr in dt.Rows
                                          select new ViewAssetCategoryDTO()
                                          {
                                              CAT_ID = Convert.ToInt32(dr["CAT_ID"]),
                                              EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                                              CLASS_ID = dr.IsNull("CLASS_ID") ? null : Convert.ToString(dr["CLASS_ID"]),
                                              CLASS_NAME = dr.IsNull("CLASS_NAME") ? null : Convert.ToString(dr["CLASS_NAME"]),
                                              DESCRIPTION = dr.IsNull("DESCRIPTION") ? null : Convert.ToString(dr["DESCRIPTION"]),
                                              CODE = dr.IsNull("CODE") ? null : Convert.ToString(dr["CODE"]),
                                              STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
                                              CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                          }).ToList();
                }

            }

            return assetCategoryList;
        }
        public ViewAssetCategoryDTO getAssetCategoryData(int catId)
        {
            ViewAssetCategoryDTO Cat = new ViewAssetCategoryDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (catId != 0)
            {

                string selectData = "SELECT CAT_ID, a.EXTERNAL_ID,a.CLASS_ID, ac.DESCRIPTION AS CLASS_NAME, a.DESCRIPTION,a.CODE, a.STATUS, a.CREATED_BY FROM ASS_CATEGORY a  INNER JOIN ASS_CLASSIFICATION ac ON a.CLASS_ID = ac.CLASS_ID  where CAT_ID = " + catId + "";


                SqlCommand cmd = new SqlCommand(selectData, conn);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ViewAssetCategoryDTO()
                           {
                               CAT_ID = Convert.ToInt32(dr["CAT_ID"]),
                               EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                               CLASS_ID = dr.IsNull("CLASS_ID") ? null : Convert.ToString(dr["CLASS_ID"]),
                               CLASS_NAME = dr.IsNull("CLASS_NAME") ? null : Convert.ToString(dr["CLASS_NAME"]),
                               DESCRIPTION = dr.IsNull("DESCRIPTION") ? null : Convert.ToString(dr["DESCRIPTION"]),
                               CODE = dr.IsNull("CODE") ? null : Convert.ToString(dr["CODE"]),
                               STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
                              
                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public DataTable UpdateAssetCategory(string eID, string cNAME,string code, string dEsc, string userid, bool sTatus
        )
        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SP_ASS_CATEGORY", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", eID);
                cmd.Parameters.AddWithValue("@clID", cNAME);
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@dEsc", dEsc);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
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
        public DataTable GetCategoryList(string _classId)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_ASS_CATEGORY_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Class_ID", _classId);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public long GETSERILANO(string docType)
        {
            long value = 0;

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_GETSERILANO", con);
                cmd.Parameters.AddWithValue("@DOCTYPE", docType);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                value = int.Parse(dt.Rows[0]["LASTSERIALNO"].ToString());

                return value;
            }
        }
        public DataTable GetAssetList( string _segmentId)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_ASSET_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //cmd.Parameters.AddWithValue("@clID", _classId);
                //cmd.Parameters.AddWithValue("@catID", _catId);
                cmd.Parameters.AddWithValue("@segmentID", _segmentId);
                cmd.Parameters.AddWithValue("@typeID", 1);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetAssetParentList(string _classId)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_ASSET_P_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Class_ID", _classId);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetAssetInitialTagList(string _asset_list)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_ASSET_INITIAL_TAG_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Asset_IDFNO", _asset_list);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetPeripheralList( string _segmentId)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_PERIPHERAL_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //cmd.Parameters.AddWithValue("@clID", _classId);
                //cmd.Parameters.AddWithValue("@catID", _catId);
                cmd.Parameters.AddWithValue("@segmentID", _segmentId);
                cmd.Parameters.AddWithValue("@typeID", 2);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetComponentList(string _segmentId)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_COMPONENT_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //cmd.Parameters.AddWithValue("@clID", _classId);
                //cmd.Parameters.AddWithValue("@catID", _catId);
                cmd.Parameters.AddWithValue("@segmentID", _segmentId);
                cmd.Parameters.AddWithValue("@typeID", 3);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetSegmentList(string _catId)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_ASS_SEGMENTLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //cmd.Parameters.AddWithValue("@Class_ID", _classId);
                cmd.Parameters.AddWithValue("@Cat_ID", _catId);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetModelList(string _segmentId)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_ASS_MODELIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //cmd.Parameters.AddWithValue("@Class_ID", _classId);
                //cmd.Parameters.AddWithValue("@Cat_ID", _catId);
                cmd.Parameters.AddWithValue("@Segment_ID", _segmentId);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }

        public DataTable SaveSegment(string eID, string cNAME, string catName, string code, string dEsc, string userid, bool sTatus)
        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_ASS_SEGMENT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", eID);
                cmd.Parameters.AddWithValue("@clID", cNAME);
                cmd.Parameters.AddWithValue("@catID", catName);
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@dEsc", dEsc);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ViewSegmentDTO> GetAssestsSegment()
        {
            List<ViewSegmentDTO> assetSegmentList = new List<ViewSegmentDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_ASSEST_SEGMENT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetSegmentList != null)
                {
                    assetSegmentList = (from DataRow dr in dt.Rows
                                         select new ViewSegmentDTO()
                                         {
                                             SEG_ID = Convert.ToInt32(dr["SEG_ID"]),
                                             EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                                             CLASS_ID = dr.IsNull("CLASS_ID") ? null : Convert.ToString(dr["CLASS_ID"]),
                                             CLASS_NAME = dr.IsNull("CLASS_NAME") ? null : Convert.ToString(dr["CLASS_NAME"]),
                                             CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
                                             CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
                                             SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
                                             CODE = dr.IsNull("CODE") ? null : Convert.ToString(dr["CODE"]),
                                             STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
                                             CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                         }).ToList();
                }

            }

            return assetSegmentList;
        }
        public ViewSegmentDTO getSegmentData(int segId)
        {
            ViewSegmentDTO Cat = new ViewSegmentDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (segId != 0)
            {

                string selectData = "SELECT SEG_ID, a.EXTERNAL_ID,a.DESCRIPTION AS SEGMENT_NAME,a.CODE, a.CLASS_ID, ac.DESCRIPTION AS CLASS_NAME,a.CAT_ID,ca.DESCRIPTION AS CATEGORY_NAME, a.STATUS, a.CREATED_BY FROM ASS_SEGMENT a INNER JOIN ASS_CLASSIFICATION ac ON a.CLASS_ID=ac.CLASS_ID INNER JOIN ASS_CATEGORY ca on a.CAT_ID=ca.CAT_ID where SEG_ID = " + segId + "";


                SqlCommand cmd = new SqlCommand(selectData, conn);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ViewSegmentDTO()
                           {
                               SEG_ID = Convert.ToInt32(dr["SEG_ID"]),
                               EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                               CLASS_ID = dr.IsNull("CLASS_ID") ? null : Convert.ToString(dr["CLASS_ID"]),
                               CLASS_NAME = dr.IsNull("CLASS_NAME") ? null : Convert.ToString(dr["CLASS_NAME"]),
                               CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
                               CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
                               SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
                               CODE = dr.IsNull("CODE") ? null : Convert.ToString(dr["CODE"]),
                               STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
                               CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public DataTable UpdateSegment(string eID, string cNAME, string catName, string code, string dEsc, string userid, bool sTatus
       )
        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SP_ASS_SEGMENT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", eID);
                cmd.Parameters.AddWithValue("@clID", cNAME);
                cmd.Parameters.AddWithValue("@catID", catName);
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@dEsc", dEsc);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
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
        //public DataTable GetCountryList()
        //{
        //    using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
        //    {
        //        SqlCommand cmd = new SqlCommand("SP_COUNTRYLIST", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        con.Open();
        //        da.Fill(dt);
        //        con.Close();
        //        return dt;
        //    }
        //}
        public DataTable GetSupTypeList()
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_SUPPLIERTYPELIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public List<CountryDTO> GetCountryList(string Country_ID, int SpType)
        {
            List<CountryDTO> CountryList = new List<CountryDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_Country_City", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Country_ID", Country_ID);
                cmd.Parameters.AddWithValue("@SpType", SpType);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (CountryList != null)
                {
                    CountryList = (from DataRow dr in dt.Rows
                                   select new CountryDTO()
                                   {
                                       Country_ID = Convert.ToInt32(dr["Country_ID"]),
                                       Country_Name = Convert.ToString(dr["Country_Name"]).Trim()
                                   }).ToList();
                }

            }

            return CountryList;
        }
        public List<CityDTO> GetCityList(int Country_ID, int SpType)
        {
            List<CityDTO> CityList = new List<CityDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_Country_City", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Country_ID", Country_ID);
                cmd.Parameters.AddWithValue("@SpType", SpType);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (CityList != null)
                {
                    CityList = (from DataRow dr in dt.Rows
                                select new CityDTO()
                                {
                                    City_ID = Convert.ToInt32(dr["City_ID"]),
                                    City_Name = Convert.ToString(dr["City_Name"]).Trim()
                                }).ToList();
                }

            }

            return CityList;
        }

        public List<VendorDTO> GetBankList(string Bank_ID, string District_Code, int SpType)
        {
            List<VendorDTO> categoryList = new List<VendorDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_Bank_Selection", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Bank_ID", Bank_ID);
                cmd.Parameters.AddWithValue("@District_Code", District_Code);
                cmd.Parameters.AddWithValue("@SpType", SpType);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (categoryList != null)
                {
                    categoryList = (from DataRow dr in dt.Rows
                                    select new VendorDTO()
                                    {
                                        Bank_ID = Convert.ToInt32(dr["Bank_ID"]),
                                        Bank_Name = Convert.ToString(dr["Bank_Name"]).Trim()
                                    }).ToList();
                }

            }

            return categoryList;
        }
        public List<VendorDTO> GetDistrictList(int Bank_ID, string District_Code, int SpType)
        {
            List<VendorDTO> vendorList = new List<VendorDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_Bank_Selection", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Bank_ID", Bank_ID);
                cmd.Parameters.AddWithValue("@District_Code", District_Code);
                cmd.Parameters.AddWithValue("@SpType", SpType);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (vendorList != null)
                {
                    vendorList = (from DataRow dr in dt.Rows
                                  select new VendorDTO()
                                  {
                                      District_Code = Convert.ToInt32(dr["District_Code"]),
                                      District_Name = Convert.ToString(dr["District_Name"]).Trim()
                                  }).ToList();
                }

            }

            return vendorList;
        }

        public List<VendorDTO> GetBranchList(int Bank_ID, int District_Code, int SpType)
        {
            List<VendorDTO> vendorList = new List<VendorDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_Bank_Selection", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Bank_ID", Bank_ID);
                cmd.Parameters.AddWithValue("@District_Code", District_Code);
                cmd.Parameters.AddWithValue("@SpType", SpType);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (vendorList != null)
                {
                    vendorList = (from DataRow dr in dt.Rows
                                  select new VendorDTO()
                                  {
                                      Branch_Code = Convert.ToString(dr["Branch_Code"]),
                                      Branch_Name = Convert.ToString(dr["Branch_Name"]).Trim()
                                  }).ToList();
                }

            }

            return vendorList;
        }
        public DataTable SaveManufacture(string eID, string dEsc,string cCount,string url,string logo,string phnno,string address, string userid, bool sTatus)
        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_MANUFACTURE", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", eID);
                cmd.Parameters.AddWithValue("@dEsc", dEsc);
                cmd.Parameters.AddWithValue("@country", cCount);
                cmd.Parameters.AddWithValue("@url", url);
                cmd.Parameters.AddWithValue("@logo", logo);
                cmd.Parameters.AddWithValue("@phnno", phnno);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ViewManufactureDTO> GetManufacture()      {
            List<ViewManufactureDTO> assetManufactureList = new List<ViewManufactureDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_MANUFACTURE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetManufactureList != null)
                {
                    assetManufactureList = (from DataRow dr in dt.Rows
                                         select new ViewManufactureDTO()
                                         {
                                             MANF_ID = Convert.ToInt32(dr["MANF_ID"]),
                                             EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                                             DESCRIPTION = dr.IsNull("DESCRIPTION") ? null : Convert.ToString(dr["DESCRIPTION"]),
                                             COUNTRY = dr.IsNull("COUNTRY") ? null : Convert.ToString(dr["COUNTRY"]),
                                             COUNTRY_NAME = dr.IsNull("COUNTRY_NAME") ? null : Convert.ToString(dr["COUNTRY_NAME"]),
                                             URL = dr.IsNull("URL") ? null : Convert.ToString(dr["URL"]),
                                             LOGO_EXT = dr.IsNull("LOGO_EXT") ? null : Convert.ToString(dr["LOGO_EXT"]),
                                             PHN_NO = dr.IsNull("PHN_NO") ? null : Convert.ToString(dr["PHN_NO"]),
                                             ADDRESS = dr.IsNull("ADDRESS") ? null : Convert.ToString(dr["ADDRESS"]),
                                             STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
                                             CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                         }).ToList();
                }

            }

            return assetManufactureList;
        }
        public ViewManufactureDTO getManufactureData(int manfId)
        {
            ViewManufactureDTO Cat = new ViewManufactureDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (manfId != 0)
            {

                string selectData = "select MANF_ID,EXTERNAL_ID,DESCRIPTION,STATUS,COUNTRY,AC.Country_Name AS COUNTRY_NAME,URL,LOGO_EXT,PHN_NO,ADDRESS,CREATED_BY from ASS_MANUFACTURE INNER JOIN COUNTRY AC ON ASS_MANUFACTURE.COUNTRY=AC.Country_ID where MANF_ID = " + manfId + "";


                SqlCommand cmd = new SqlCommand(selectData, conn);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ViewManufactureDTO()
                           {
                               MANF_ID = Convert.ToInt32(dr["MANF_ID"]),
                               EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                               DESCRIPTION = dr.IsNull("DESCRIPTION") ? null : Convert.ToString(dr["DESCRIPTION"]),
                               COUNTRY = dr.IsNull("COUNTRY") ? null : Convert.ToString(dr["COUNTRY"]),
                               COUNTRY_NAME = dr.IsNull("COUNTRY_NAME") ? null : Convert.ToString(dr["COUNTRY_NAME"]),
                               URL = dr.IsNull("URL") ? null : Convert.ToString(dr["URL"]),
                               LOGO_EXT = dr.IsNull("LOGO_EXT") ? null : Convert.ToString(dr["LOGO_EXT"]),
                               PHN_NO = dr.IsNull("PHN_NO") ? null : Convert.ToString(dr["PHN_NO"]),
                               ADDRESS = dr.IsNull("ADDRESS") ? null : Convert.ToString(dr["ADDRESS"]),
                               STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",

                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public DataTable UpdateManufacture(string eID, string dEsc, string cCount, string url, string logo, string phnno, string address, string userid, bool sTatus
       )
        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SP_MANUFACTURE", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", eID);
                cmd.Parameters.AddWithValue("@dEsc", dEsc);
                cmd.Parameters.AddWithValue("@country", cCount);
                cmd.Parameters.AddWithValue("@url", url);
                cmd.Parameters.AddWithValue("@logo", logo);
                cmd.Parameters.AddWithValue("@phnno", phnno);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
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
        #region [////////////// Supplier///////////]
        public DataTable SaveSupplier(string eID, string type, string userid, bool sTatus)
        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_SUP_TYPE", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", eID);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ViewSupplierDTO> GetSupplier()
        {
            List<ViewSupplierDTO> assetCategoryList = new List<ViewSupplierDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_SUP_TYPE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetCategoryList != null)
                {
                    assetCategoryList = (from DataRow dr in dt.Rows
                                         select new ViewSupplierDTO()
                                         {
                                             SUP_TYPE_ID = Convert.ToInt32(dr["SUP_TYPE_ID"]),
                                             EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                                             TYPE = dr.IsNull("TYPE") ? null : Convert.ToString(dr["TYPE"]),
                                             Status = dr.IsNull("Status") ? null : Convert.ToBoolean(dr["Status"]) == true ? "Active" : "InActive",
                                             CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                         }).ToList();
                }

            }

            return assetCategoryList;
        }
        public ViewSupplierDTO getSupplierData(int supplierId)
        {
            ViewSupplierDTO Cat = new ViewSupplierDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (supplierId != 0)
            {

                string selectData = " SELECT SUP_TYPE_ID, EXTERNAL_ID, TYPE, Status, CREATED_BY FROM ASS_SUP_TYPE  where SUP_TYPE_ID = " + supplierId + "";


                SqlCommand cmd = new SqlCommand(selectData, conn);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ViewSupplierDTO()
                           {
                               SUP_TYPE_ID = Convert.ToInt32(dr["SUP_TYPE_ID"]),
                               EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                               TYPE = dr.IsNull("TYPE") ? null : Convert.ToString(dr["TYPE"]),
                               Status = dr.IsNull("Status") ? null : Convert.ToBoolean(dr["Status"]) == true ? "Active" : "InActive",
                             

                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public DataTable UpdateSupplier(string eID, string type, string userid, bool sTatus
        )
        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }


                SqlCommand cmd = new SqlCommand("SP_SUP_TYPE", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", eID);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
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
       
        public List<ViewSupplierDetailsDTO> GetSupplierDetails()
        {
            List<ViewSupplierDetailsDTO> assetManufactureList = new List<ViewSupplierDetailsDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_SUPPLIER", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetManufactureList != null)
                {
                    assetManufactureList = (from DataRow dr in dt.Rows
                                            select new ViewSupplierDetailsDTO()
                                            {
                                                SUPPLIER_ID = Convert.ToInt32(dr["SUPPLIER_ID"]),
                                                EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                                                NAME = dr.IsNull("NAME") ? null : Convert.ToString(dr["NAME"]),
                                                ADDRESS = dr.IsNull("ADDRESS") ? null : Convert.ToString(dr["ADDRESS"]),
                                                CITY_ID = dr.IsNull("CITY_ID") ? null : Convert.ToString(dr["CITY_ID"]),
                                                CITY_NAME = dr.IsNull("CITY_NAME") ? null : Convert.ToString(dr["CITY_NAME"]),
                                                STATE_ID = dr.IsNull("STATE_ID") ? null : Convert.ToString(dr["STATE_ID"]),
                                                COUNTRY_ID = dr.IsNull("COUNTRY_ID") ? null : Convert.ToString(dr["COUNTRY_ID"]),
                                                Country_Name = dr.IsNull("Country_Name") ? null : Convert.ToString(dr["Country_Name"]),
                                                ZIP = dr.IsNull("ZIP") ? null : Convert.ToString(dr["ZIP"]),
                                                URL = dr.IsNull("URL") ? null : Convert.ToString(dr["URL"]),
                                                CONDITION = dr.IsNull("CONDITION") ? null : Convert.ToString(dr["CONDITION"]),
                                                SUPPLIER_STATUS = dr.IsNull("SUPPLIER_STATUS") ? null : Convert.ToBoolean(dr["SUPPLIER_STATUS"]) == true ? "Active" : "InActive",
                                                CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                            }).ToList();
                }

            }

            return assetManufactureList;
        }
        public ViewSupplierDetailsDTO getSupplierDetailsData(int supId)
        {
            ViewSupplierDetailsDTO Cat = new ViewSupplierDetailsDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (supId != 0)
            {

                string selectData = "select SUPPLIER_ID,EXTERNAL_ID,SUP_TYPE,NAME,ADDRESS,AP.CITY_ID,CT.City_Name AS CITY_NAME,STATE_ID,AP.COUNTRY_ID, C.Country_Name,ZIP,URL,CONDITION,STATUS AS SUPPLIER_STATUS,CREATED_BY from ASS_SUPPLIER AP INNER JOIN COUNTRY C ON  C.Country_ID=AP.COUNTRY_ID INNER JOIN CITY CT ON  AP.CITY_ID=CT.CITY_ID  where SUPPLIER_ID = " + supId + "";


                SqlCommand cmd = new SqlCommand(selectData, conn);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ViewSupplierDetailsDTO()
                           {
                               SUPPLIER_ID = Convert.ToInt32(dr["SUPPLIER_ID"]),
                               EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                               SUP_TYPE = dr.IsNull("SUP_TYPE") ? null : Convert.ToString(dr["SUP_TYPE"]),
                               NAME = dr.IsNull("NAME") ? null : Convert.ToString(dr["NAME"]),
                               ADDRESS = dr.IsNull("ADDRESS") ? null : Convert.ToString(dr["ADDRESS"]),
                               CITY_ID = dr.IsNull("CITY_ID") ? null : Convert.ToString(dr["CITY_ID"]),
                               CITY_NAME = dr.IsNull("CITY_NAME") ? null : Convert.ToString(dr["CITY_NAME"]),
                               STATE_ID = dr.IsNull("STATE_ID") ? null : Convert.ToString(dr["STATE_ID"]),
                               COUNTRY_ID = dr.IsNull("COUNTRY_ID") ? null : Convert.ToString(dr["COUNTRY_ID"]),
                               Country_Name = dr.IsNull("Country_Name") ? null : Convert.ToString(dr["Country_Name"]),
                               ZIP = dr.IsNull("ZIP") ? null : Convert.ToString(dr["ZIP"]),
                               URL = dr.IsNull("URL") ? null : Convert.ToString(dr["URL"]),
                               CONDITION = dr.IsNull("CONDITION") ? null : Convert.ToString(dr["CONDITION"]),
                               SUPPLIER_STATUS = dr.IsNull("SUPPLIER_STATUS") ? null : Convert.ToBoolean(dr["SUPPLIER_STATUS"]) == true ? "Active" : "InActive",
                              
                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public DataTable UpdateSupplierDetails(string eID, string name, string type, string address, string city, string state, string country, string zip, string url, string creditPeriod,string condition, string userid, string sTatus
      )
        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SP_SUPPLIER", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", eID);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@cityID", city);
                cmd.Parameters.AddWithValue("@stateID", state);
                cmd.Parameters.AddWithValue("@countryID", country);
                cmd.Parameters.AddWithValue("@zip", zip);
                cmd.Parameters.AddWithValue("@url", url);
                cmd.Parameters.AddWithValue("@creditPeriod", creditPeriod);
                cmd.Parameters.AddWithValue("@condition", condition);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
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
        public DataTable UpdateSupplierBankAccount(string eID, string sID, string bank, string district, string branch, string accName, string accNumber, string currency, string primary, string userid, string sTatus)
        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_SUP_BANK_ACC", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", eID);
                //cmd.Parameters.AddWithValue("@supID", sID);
                cmd.Parameters.AddWithValue("@bank", bank);
                cmd.Parameters.AddWithValue("@district", district);
                cmd.Parameters.AddWithValue("@branch", branch);
                cmd.Parameters.AddWithValue("@accName", accName);
                cmd.Parameters.AddWithValue("@accNumber", accNumber);
                cmd.Parameters.AddWithValue("@currency", currency);
                cmd.Parameters.AddWithValue("@primary", primary);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
                cmd.Parameters.AddWithValue("@sT", 2);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable UpdateContact(string sID,string name, string phone, string email, string note, string userid, string sTatus)
        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_ASS_SUP_CONTACT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
               // cmd.Parameters.AddWithValue("@cID", null);
                cmd.Parameters.AddWithValue("@supID", sID);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@note", note);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
                cmd.Parameters.AddWithValue("@sT", 2);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable SaveSupplierDetails( string eID, string name, string type, string address, string city, string state, string country, string zip, string url,string creditPeriod,string condition, string userid, string sTatus)
        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_SUPPLIER", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", eID);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@cityID", city);
                cmd.Parameters.AddWithValue("@stateID", state);
                cmd.Parameters.AddWithValue("@countryID", country);
                cmd.Parameters.AddWithValue("@zip", zip);
                cmd.Parameters.AddWithValue("@url", url);
                cmd.Parameters.AddWithValue("@creditPeriod", creditPeriod);
                cmd.Parameters.AddWithValue("@condition", condition);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable SaveSupplierBankAccount(string eID, string sID, string bank,string district, string branch, string accName, string accNumber, string currency, string primary, string userid, string sTatus)
        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_SUP_BANK_ACC", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", eID);
               // cmd.Parameters.AddWithValue("@supID", sID);
                cmd.Parameters.AddWithValue("@bank", bank);
                cmd.Parameters.AddWithValue("@district", district);
                cmd.Parameters.AddWithValue("@branch", branch);
                cmd.Parameters.AddWithValue("@accName", accName);
                cmd.Parameters.AddWithValue("@accNumber", accNumber);
                cmd.Parameters.AddWithValue("@currency", currency);
                cmd.Parameters.AddWithValue("@primary", primary);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable SaveContact(string cID,string name, string phone, string email, string note, string userid, string sTatus)
        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_ASS_SUP_CONTACT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@cID", cID);
                //cmd.Parameters.AddWithValue("@supID", sID);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@note", note);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        public List<ViewBankAccountDetailsDTO> GetBankAccount(int supId)
        {
            List<ViewBankAccountDetailsDTO> assetSegmentList = new List<ViewBankAccountDetailsDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_SUP_BANK_ACC", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@supId", SqlDbType.Int).Value = supId;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetSegmentList != null)
                {
                    assetSegmentList = (from DataRow dr in dt.Rows
                                        select new ViewBankAccountDetailsDTO()
                                        {
                                            Bank_ID = Convert.ToInt32(dr["Bank_ID"]),
                                            EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                                            Bankk_ID = dr.IsNull("Bankk_ID") ? null : Convert.ToString(dr["Bankk_ID"]),
                                            Bank_Name = dr.IsNull("Bank_Name") ? null : Convert.ToString(dr["Bank_Name"]),
                                            DISTRICT = dr.IsNull("DISTRICT") ? null : Convert.ToString(dr["DISTRICT"]),
                                            District_Name = dr.IsNull("District_Name") ? null : Convert.ToString(dr["District_Name"]),
                                            BRANCH = dr.IsNull("BRANCH") ? null : Convert.ToString(dr["BRANCH"]),
                                            Branch_Name = dr.IsNull("Branch_Name") ? null : Convert.ToString(dr["Branch_Name"]),
                                            ACC_NAME = dr.IsNull("ACC_NAME") ? null : Convert.ToString(dr["ACC_NAME"]),
                                            ACC_NUMBER = dr.IsNull("ACC_NUMBER") ? null : Convert.ToString(dr["ACC_NUMBER"]),
                                            CURRENCY = dr.IsNull("CURRENCY") ? null : Convert.ToString(dr["CURRENCY"]),
                                            PRIMARY = dr.IsNull("PRIMARY") ? null : Convert.ToString(dr["PRIMARY"]),
                                            STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
                                            CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                        }).ToList();
                }

            }

            return assetSegmentList;
        }
        public ViewBankAccountDetailsDTO getBankAccountDetailsData(int bankId)
        {
            ViewBankAccountDetailsDTO Cat = new ViewBankAccountDetailsDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (bankId != 0)
            {

                string selectData = "select ba.Bank_ID, ba.EXTERNAL_ID,ba.SUPPLIER_ID,ba.Bank_Name as Bankk_ID,br.Bank_Name,ba.BRANCH,br.Branch_Name,ba.DISTRICT,br.District_Name,ba.ACC_NAME,ba.ACC_NUMBER,ba.CURRENCY,ba.[PRIMARY],ba.STATUS ,CREATED_BY from ASS_SUP_BANK_ACC ba INNER JOIN BANK_ROUTING br ON ba.BANK_NAME=br.Bank_ID and ba.BRANCH=br.Branch_Code and ba.DISTRICT=br.District_Code where ba.Bank_ID = " + bankId + "";


                SqlCommand cmd = new SqlCommand(selectData, conn);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ViewBankAccountDetailsDTO()
                           {
                               Bank_ID = Convert.ToInt32(dr["Bank_ID"]),
                               EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                               Bankk_ID = dr.IsNull("Bankk_ID") ? null : Convert.ToString(dr["Bankk_ID"]),
                               Bank_Name = dr.IsNull("Bank_Name") ? null : Convert.ToString(dr["Bank_Name"]),
                               DISTRICT = dr.IsNull("DISTRICT") ? null : Convert.ToString(dr["DISTRICT"]),
                               District_Name = dr.IsNull("District_Name") ? null : Convert.ToString(dr["District_Name"]),
                               BRANCH = dr.IsNull("BRANCH") ? null : Convert.ToString(dr["BRANCH"]),
                               Branch_Name = dr.IsNull("Branch_Name") ? null : Convert.ToString(dr["Branch_Name"]),
                               ACC_NAME = dr.IsNull("ACC_NAME") ? null : Convert.ToString(dr["ACC_NAME"]),
                               ACC_NUMBER = dr.IsNull("ACC_NUMBER") ? null : Convert.ToString(dr["ACC_NUMBER"]),
                               CURRENCY = dr.IsNull("CURRENCY") ? null : Convert.ToString(dr["CURRENCY"]),
                               PRIMARY = dr.IsNull("PRIMARY") ? null : Convert.ToString(dr["PRIMARY"]),
                               STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",

                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public List<ViewContactDetailsDTO> GetContact(int supId)
        {
            List<ViewContactDetailsDTO> assetSegmentList = new List<ViewContactDetailsDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_ASS_SUP_CONTACT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@supId", SqlDbType.Int).Value = supId;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetSegmentList != null)
                {
                    assetSegmentList = (from DataRow dr in dt.Rows
                                        select new ViewContactDetailsDTO()
                                        {
                                            CONTACT_ID = Convert.ToInt32(dr["CONTACT_ID"]),
                                            NAME = dr.IsNull("NAME") ? null : Convert.ToString(dr["NAME"]),
                                            PHONE = dr.IsNull("PHONE") ? null : Convert.ToString(dr["PHONE"]),
                                            EMAIL = dr.IsNull("EMAIL") ? null : Convert.ToString(dr["EMAIL"]),
                                            NOTE = dr.IsNull("NOTE") ? null : Convert.ToString(dr["NOTE"]),
                                            STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
                                            CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                        }).ToList();
                }

            }

            return assetSegmentList;
        }
        public ViewContactDetailsDTO getContactDetailsData(int contactId)
        {
            ViewContactDetailsDTO Cat = new ViewContactDetailsDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (contactId != 0)
            {

                string selectData = "select CONTACT_ID,NAME,PHONE,EMAIL,NOTE,STATUS,CREATED_BY from ASS_SUP_CONTACT where CONTACT_ID = " + contactId + "";




                SqlCommand cmd = new SqlCommand(selectData, conn);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ViewContactDetailsDTO()
                           {
                               CONTACT_ID = Convert.ToInt32(dr["CONTACT_ID"]),
                               NAME = dr.IsNull("NAME") ? null : Convert.ToString(dr["NAME"]),
                               PHONE = dr.IsNull("PHONE") ? null : Convert.ToString(dr["PHONE"]),
                               EMAIL = dr.IsNull("EMAIL") ? null : Convert.ToString(dr["EMAIL"]),
                               NOTE = dr.IsNull("NOTE") ? null : Convert.ToString(dr["NOTE"]),
                               STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",

                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public DataTable SaveModel(string eID, string dEsc,string cNAME, string catName,string segName,string manName, string SupplierList,string modelNo,string notes,string logo, string userid)

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_ASS_MODEL", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", eID);
                cmd.Parameters.AddWithValue("@dEsc", dEsc);
                cmd.Parameters.AddWithValue("@clID", cNAME);
                cmd.Parameters.AddWithValue("@catID", catName);
                cmd.Parameters.AddWithValue("@segID", segName);
                cmd.Parameters.AddWithValue("@manID", manName);
                cmd.Parameters.AddWithValue("@supID", SupplierList);
                cmd.Parameters.AddWithValue("@modelno", modelNo);
                cmd.Parameters.AddWithValue("@notes", notes);
                cmd.Parameters.AddWithValue("@logo ", logo);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ModelDTO> GetAssestsModel()
        {
            List<ModelDTO> assetModelList = new List<ModelDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_ASS_MODEL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetModelList != null)
                {
                    assetModelList = (from DataRow dr in dt.Rows
                                        select new ModelDTO()
                                        {
                                            MODEL_ID = Convert.ToInt32(dr["MODEL_ID"]),
                                            EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                                            CLASS_ID = dr.IsNull("CLASS_ID") ? null : Convert.ToString(dr["CLASS_ID"]),
                                            CLASS_NAME = dr.IsNull("CLASS_NAME") ? null : Convert.ToString(dr["CLASS_NAME"]),
                                            CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
                                            CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
                                            SEG_ID = dr.IsNull("SEG_ID") ? null : Convert.ToString(dr["SEG_ID"]),
                                            SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
                                            MAN_ID = dr.IsNull("MAN_ID") ? null : Convert.ToString(dr["MAN_ID"]),
                                            MANUFACTURE_NAME = dr.IsNull("MANUFACTURE_NAME") ? null : Convert.ToString(dr["MANUFACTURE_NAME"]),
                                            SUP_ID = dr.IsNull("SUP_ID") ? null : Convert.ToString(dr["SUP_ID"]),
                                            SUPPLIER_NAME = dr.IsNull("SUPPLIER_NAME") ? null : Convert.ToString(dr["SUPPLIER_NAME"]),
                                            MODEL_NAME = dr.IsNull("MODEL_NAME") ? null : Convert.ToString(dr["MODEL_NAME"]),
                                            MODEL_NO = dr.IsNull("MODEL_NO") ? null : Convert.ToString(dr["MODEL_NO"]),
                                            NOTES = dr.IsNull("NOTES") ? null : Convert.ToString(dr["NOTES"]),
                                            LOGO_EXT = dr.IsNull("LOGO_EXT") ? null : Convert.ToString(dr["LOGO_EXT"]),
                                            CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                        }).ToList();
                }

            }

            return assetModelList;
        }
        public List<PeripheralDTO> GetPeripheral()
        {
            List<PeripheralDTO> assetModelList = new List<PeripheralDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_ASS_PEREPHERAL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetModelList != null)
                {
                    assetModelList = (from DataRow dr in dt.Rows
                                      select new PeripheralDTO()
                                      {
                                          // ASSET_CODE = Convert.ToInt32(dr["ASSET_CODE"]),
                                          ASSET_CODE = dr.IsNull("ASSET_CODE") ? null : Convert.ToString(dr["ASSET_CODE"]),
                                          DESCRIPTION = dr.IsNull("DESCRIPTION") ? null : Convert.ToString(dr["DESCRIPTION"]),
                                          ASSET_CLASS = dr.IsNull("ASSET_CLASS") ? null : Convert.ToString(dr["ASSET_CLASS"]),
                                          ASSET_CLASS_NAME = dr.IsNull("ASSET_CLASS_NAME") ? null : Convert.ToString(dr["ASSET_CLASS_NAME"]),
                                          CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
                                          CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
                                          SEG_ID = dr.IsNull("SEG_ID") ? null : Convert.ToString(dr["SEG_ID"]),
                                          SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
                                          QUANTITY = dr.IsNull("QUANTITY") ? null : Convert.ToString(dr["QUANTITY"]),
                                          CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                      }).ToList();
                }

            }

            return assetModelList;
        }

        public List<PeripheralDTO> GetAssetPackage()
        {
            List<PeripheralDTO> assetModelList = new List<PeripheralDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_ASS_DATA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetModelList != null)
                {
                    assetModelList = (from DataRow dr in dt.Rows
                                      select new PeripheralDTO()
                                      {
                                          // ASSET_CODE = Convert.ToInt32(dr["ASSET_CODE"]),
                                          ASSET_CODE = dr.IsNull("ASSET_CODE") ? null : Convert.ToString(dr["ASSET_CODE"]),
                                          DESCRIPTION = dr.IsNull("DESCRIPTION") ? null : Convert.ToString(dr["DESCRIPTION"]),
                                          ASSET_CLASS = dr.IsNull("ASSET_CLASS") ? null : Convert.ToString(dr["ASSET_CLASS"]),
                                          ASSET_CLASS_NAME = dr.IsNull("ASSET_CLASS_NAME") ? null : Convert.ToString(dr["ASSET_CLASS_NAME"]),
                                          CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
                                          CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
                                          SEG_ID = dr.IsNull("SEG_ID") ? null : Convert.ToString(dr["SEG_ID"]),
                                          SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
                                          QUANTITY = dr.IsNull("QUANTITY") ? null : Convert.ToString(dr["QUANTITY"]),
                                          CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                      }).ToList();
                }

            }

            return assetModelList;
        }
        public List<AssetDTO> GetTransfer()
        {
            List<AssetDTO> assetModelList = new List<AssetDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_ASS_TRANS_TMP_VIEW", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetModelList != null)
                {
                    assetModelList = (from DataRow dr in dt.Rows
                                      select new AssetDTO()
                                      {
                                          // ASSET_CODE = Convert.ToInt32(dr["ASSET_CODE"]),
                                          ASSET_CODE = dr.IsNull("ASSET_CODE") ? null : Convert.ToString(dr["ASSET_CODE"]),
                                          ASSET_CLASS = dr.IsNull("ASSET_CLASS") ? null : Convert.ToString(dr["ASSET_CLASS"]),
                                          CLASS_NAME = dr.IsNull("CLASS_NAME") ? null : Convert.ToString(dr["CLASS_NAME"]),
                                          CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
                                          CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
                                          SEG_ID = dr.IsNull("SEG_ID") ? null : Convert.ToString(dr["SEG_ID"]),
                                          SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
                                          //ASS_PCODE = dr.IsNull("ASS_PCODE") ? null : Convert.ToString(dr["ASS_PCODE"]),
                                          PARENT_MST_TAG = dr.IsNull("PARENT_MST_TAG") ? null : Convert.ToString(dr["PARENT_MST_TAG"]),
                                          ASSET_INTTAG = dr.IsNull("ASSET_INTTAG") ? null : Convert.ToString(dr["ASSET_INTTAG"]),
                                          ASSET_EXTTAG = dr.IsNull("ASSET_EXTTAG") ? null : Convert.ToString(dr["ASSET_EXTTAG"]),
                                          MAIN_ASSET = dr.IsNull("MAIN_ASSET") ? null : Convert.ToString(dr["MAIN_ASSET"]),
                                          SUPP_ID = dr.IsNull("SUPP_ID") ? null : Convert.ToString(dr["SUPP_ID"]),
                                          SUPPLIER_NAME = dr.IsNull("SUPPLIER_NAME") ? null : Convert.ToString(dr["SUPPLIER_NAME"]),
                                          MOD_ID = dr.IsNull("MOD_ID") ? null : Convert.ToString(dr["MOD_ID"]),
                                          MODEL_NAME = dr.IsNull("MODEL_NAME") ? null : Convert.ToString(dr["MODEL_NAME"]),
                                          REQ_QUANTITY = dr.IsNull("REQ_QUANTITY") ? null : Convert.ToString(dr["REQ_QUANTITY"]),
                                          P_COST = dr.IsNull("P_COST") ? null : Convert.ToString(dr["P_COST"]),
                                          SUB_TOTAL = dr.IsNull("SUB_TOTAL") ? null : Convert.ToString(dr["SUB_TOTAL"]),
                                          TAX = dr.IsNull("TAX") ? null : Convert.ToString(dr["TAX"]),
                                          TOTAL_ASSET = dr.IsNull("TOTAL_ASSET") ? null : Convert.ToString(dr["TOTAL_ASSET"]),
                                          CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                      }).ToList();
                }

            }

            return assetModelList;
        }
        public List<AssetDTO> GetAsset()
        {
            List<AssetDTO> assetModelList = new List<AssetDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_ASS_CMASTER_VIEW", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetModelList != null)
                {
                    assetModelList = (from DataRow dr in dt.Rows
                                      select new AssetDTO()
                                      {
                                          // ASSET_CODE = Convert.ToInt32(dr["ASSET_CODE"]),
                                          ASSET_CODE = dr.IsNull("ASSET_CODE") ? null : Convert.ToString(dr["ASSET_CODE"]),
                                          ASSET_CLASS = dr.IsNull("ASSET_CLASS") ? null : Convert.ToString(dr["ASSET_CLASS"]),
                                          CLASS_NAME = dr.IsNull("CLASS_NAME") ? null : Convert.ToString(dr["CLASS_NAME"]),
                                          CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
                                          CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
                                          SEG_ID = dr.IsNull("SEG_ID") ? null : Convert.ToString(dr["SEG_ID"]),
                                          SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
                                          //ASS_PCODE = dr.IsNull("ASS_PCODE") ? null : Convert.ToString(dr["ASS_PCODE"]),
                                          PARENT_MST_TAG = dr.IsNull("PARENT_MST_TAG") ? null : Convert.ToString(dr["PARENT_MST_TAG"]),
                                          MAIN_ASSET = dr.IsNull("MAIN_ASSET") ? null : Convert.ToString(dr["MAIN_ASSET"]),
                                          SUPP_ID = dr.IsNull("SUPP_ID") ? null : Convert.ToString(dr["SUPP_ID"]),
                                          SUPPLIER_NAME = dr.IsNull("SUPPLIER_NAME") ? null : Convert.ToString(dr["SUPPLIER_NAME"]),
                                          MOD_ID = dr.IsNull("MOD_ID") ? null : Convert.ToString(dr["MOD_ID"]),
                                          MODEL_NAME = dr.IsNull("MODEL_NAME") ? null : Convert.ToString(dr["MODEL_NAME"]),
                                          MANUFACTURE_NAME = dr.IsNull("MANUFACTURE_NAME") ? null : Convert.ToString(dr["MANUFACTURE_NAME"]),
                                          //ASS_CCODE = dr.IsNull("ASS_CCODE") ? null : Convert.ToString(dr["ASS_CCODE"]),
                                          //CHILD_MST_TAG = dr.IsNull("CHILD_MST_TAG") ? null : Convert.ToString(dr["CHILD_MST_TAG"]),
                                          //CHILD_ASSET = dr.IsNull("CHILD_ASSET") ? null : Convert.ToString(dr["CHILD_ASSET"]),
                                          TOTAL_ASSET = dr.IsNull("TOTAL_ASSET") ? null : Convert.ToString(dr["TOTAL_ASSET"]),
                                          CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                      }).ToList();
                }

            }

            return assetModelList;
        }
        public List<PeripheralDTO> GetComponent()
        {
            List<PeripheralDTO> assetModelList = new List<PeripheralDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_ASS_COMPONENT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetModelList != null)
                {
                    assetModelList = (from DataRow dr in dt.Rows
                                      select new PeripheralDTO()
                                      {
                                          // ASSET_CODE = Convert.ToInt32(dr["ASSET_CODE"]),
                                          ASSET_CODE = dr.IsNull("ASSET_CODE") ? null : Convert.ToString(dr["ASSET_CODE"]),
                                          DESCRIPTION = dr.IsNull("DESCRIPTION") ? null : Convert.ToString(dr["DESCRIPTION"]),
                                          ASSET_CLASS = dr.IsNull("ASSET_CLASS") ? null : Convert.ToString(dr["ASSET_CLASS"]),
                                          ASSET_CLASS_NAME = dr.IsNull("ASSET_CLASS_NAME") ? null : Convert.ToString(dr["ASSET_CLASS_NAME"]),
                                          CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
                                          CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
                                          SEG_ID = dr.IsNull("SEG_ID") ? null : Convert.ToString(dr["SEG_ID"]),
                                          SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
                                          QUANTITY = dr.IsNull("QUANTITY") ? null : Convert.ToString(dr["QUANTITY"]),
                                          CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                      }).ToList();
                }

            }

            return assetModelList;
        }
        public ModelDTO getModelData(int modelId)
        {
            ModelDTO Cat = new ModelDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (modelId != 0)
            {

                string selectData = "SELECT MODEL_ID, a.EXTERNAL_ID,a.MODEL_NAME, a.CLASS_ID, ac.DESCRIPTION AS CLASS_NAME,a.CAT_ID,ca.DESCRIPTION AS CATEGORY_NAME,a.SEG_ID,se.DESCRIPTION AS SEGMENT_NAME,a.MAN_ID,m.DESCRIPTION AS MANUFACTURE_NAME,a.SUP_ID,S.NAME AS SUPPLIER_NAME,a.MODEL_NO,a.NOTES,a.LOGO_EXT,a.CREATED_BY FROM ASS_MODEL a INNER JOIN ASS_CLASSIFICATION ac ON a.CLASS_ID = ac.CLASS_ID INNER JOIN ASS_CATEGORY ca on a.CAT_ID = ca.CAT_ID    INNER JOIN ASS_SEGMENT se on a.SEG_ID = se.SEG_ID INNER JOIN ASS_MANUFACTURE m on a.MAN_ID=m.MANF_ID INNER JOIN ASS_SUPPLIER s on a.SUP_ID=s.SUPPLIER_ID where MODEL_ID = " + modelId + "";


                SqlCommand cmd = new SqlCommand(selectData, conn);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ModelDTO()
                           {
                               MODEL_ID = Convert.ToInt32(dr["MODEL_ID"]),
                               EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                               CLASS_ID = dr.IsNull("CLASS_ID") ? null : Convert.ToString(dr["CLASS_ID"]),
                               CLASS_NAME = dr.IsNull("CLASS_NAME") ? null : Convert.ToString(dr["CLASS_NAME"]),
                               CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
                               CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
                               SEG_ID = dr.IsNull("SEG_ID") ? null : Convert.ToString(dr["SEG_ID"]),
                               SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
                               MAN_ID = dr.IsNull("MAN_ID") ? null : Convert.ToString(dr["MAN_ID"]),
                               MANUFACTURE_NAME = dr.IsNull("MANUFACTURE_NAME") ? null : Convert.ToString(dr["MANUFACTURE_NAME"]),
                               SUP_ID = dr.IsNull("SUP_ID") ? null : Convert.ToString(dr["SUP_ID"]),
                               SUPPLIER_NAME = dr.IsNull("SUPPLIER_NAME") ? null : Convert.ToString(dr["SUPPLIER_NAME"]),
                               MODEL_NAME = dr.IsNull("MODEL_NAME") ? null : Convert.ToString(dr["MODEL_NAME"]),
                               MODEL_NO = dr.IsNull("MODEL_NO") ? null : Convert.ToString(dr["MODEL_NO"]),
                               NOTES = dr.IsNull("NOTES") ? null : Convert.ToString(dr["NOTES"]),
                               LOGO_EXT = dr.IsNull("LOGO_EXT") ? null : Convert.ToString(dr["LOGO_EXT"]),
                              // CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public DataTable UpdateModel(string eID, string dEsc, string cNAME, string catName, string segName, string manName, string SupplierList, string modelNo, string notes, string logo, string userid
      )
        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SP_ASS_MODEL", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", eID);
                cmd.Parameters.AddWithValue("@dEsc", dEsc);
                cmd.Parameters.AddWithValue("@clID", cNAME);
                cmd.Parameters.AddWithValue("@catID", catName);
                cmd.Parameters.AddWithValue("@segID", segName);
                cmd.Parameters.AddWithValue("@manID", manName);
                cmd.Parameters.AddWithValue("@supID", SupplierList);
                cmd.Parameters.AddWithValue("@modelno", modelNo);
                cmd.Parameters.AddWithValue("@notes", notes);
                cmd.Parameters.AddWithValue("@logo ", logo);
                cmd.Parameters.AddWithValue("@cBy", userid);
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
        public DataTable SaveComponent(long assetCode, string masterTag, string ClassList, string TypeId, string Modellist, string SupplierList, string Name, string Description, string Size,string DUOMId, string Color, string PurchaseCost, string AutoSl, string userid)

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open(); 
                }



                SqlCommand cmd = new SqlCommand("SP_ASS_MASTER_COMPONENT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@assetCode", assetCode);
                cmd.Parameters.AddWithValue("@mstTag", masterTag);
                cmd.Parameters.AddWithValue("@clID", ClassList);
                cmd.Parameters.AddWithValue("@typeID ", TypeId);
                cmd.Parameters.AddWithValue("@modelID", Modellist);
                cmd.Parameters.AddWithValue("@supID", SupplierList);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@description", Description);
                cmd.Parameters.AddWithValue("@size ", Size);
                cmd.Parameters.AddWithValue("@uomID", DUOMId);
                //cmd.Parameters.AddWithValue("@company", null);
                //cmd.Parameters.AddWithValue("@location", null);
                cmd.Parameters.AddWithValue("@colorID", Color);
                cmd.Parameters.AddWithValue("@purchaseCost", PurchaseCost);
                cmd.Parameters.AddWithValue("@autoSl", AutoSl);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable SaveperipheralData(string code, string TypeId, string ClassList,string Quantity,string userid)

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_ASS_MASTER_TMP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@typeID ", TypeId);
                cmd.Parameters.AddWithValue("@clID", ClassList);
                cmd.Parameters.AddWithValue("@qty", Quantity);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable SaveAssetTransfer(string asset,string initialTag, string externalTag,string userid)

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_ASSET_TRANS_TMP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", asset);
                cmd.Parameters.AddWithValue("@initialTag", initialTag);
                cmd.Parameters.AddWithValue("@externalTag", externalTag);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable DeleteperipheralData(string code,string userid)

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_ASS_MASTER_TMP_DELETE", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sT", 3);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable SaveAsset(string masterTag, string ClassList, string TypeId, string Modellist, string SupplierList, string Name, string Description, string Size, string DUOMId, string Color, string PurchaseCost, string PeripheralList, string AutoSl, string userid)

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_ASS_MASTER_TMP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mstTag", masterTag);
                cmd.Parameters.AddWithValue("@clID", ClassList);
                cmd.Parameters.AddWithValue("@typeID ", TypeId);
                cmd.Parameters.AddWithValue("@modelID", Modellist);
                cmd.Parameters.AddWithValue("@supID", SupplierList);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@description", Description);
                cmd.Parameters.AddWithValue("@size ", Size);
                cmd.Parameters.AddWithValue("@uomID", DUOMId);
                //cmd.Parameters.AddWithValue("@company", null);
                //cmd.Parameters.AddWithValue("@location", null);
                cmd.Parameters.AddWithValue("@colorID", Color);
                cmd.Parameters.AddWithValue("@purchaseCost", PurchaseCost);
                cmd.Parameters.AddWithValue("@parentCode", PeripheralList);
                cmd.Parameters.AddWithValue("@autoSl", AutoSl);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ComponentDTO> GetAssestsComponent()
        {
            List<ComponentDTO> assetModelList = new List<ComponentDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_ASS_COMPONENT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetModelList != null)
                {
                    assetModelList = (from DataRow dr in dt.Rows
                                      select new ComponentDTO()
                                      {
                                          //MST_TAG = Convert.ToInt32(dr["MST_TAG"]),
                                          MST_TAG = dr.IsNull("MST_TAG") ? null : Convert.ToString(dr["MST_TAG"]),
                                          ASSET_CLASS = dr.IsNull("ASSET_CLASS") ? null : Convert.ToString(dr["ASSET_CLASS"]),
                                          CLASS_NAME = dr.IsNull("CLASS_NAME") ? null : Convert.ToString(dr["CLASS_NAME"]),
                                          CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
                                          CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
                                          SEG_ID = dr.IsNull("SEG_ID") ? null : Convert.ToString(dr["SEG_ID"]),
                                          SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
                                          MOD_ID = dr.IsNull("MOD_ID") ? null : Convert.ToString(dr["MOD_ID"]),
                                          MODEL_NAME = dr.IsNull("MODEL_NAME") ? null : Convert.ToString(dr["MODEL_NAME"]),
                                          MAN_ID = dr.IsNull("MAN_ID") ? null : Convert.ToString(dr["MAN_ID"]),
                                          MANUFACTURE_NAME = dr.IsNull("MANUFACTURE_NAME") ? null : Convert.ToString(dr["MANUFACTURE_NAME"]),
                                          SUPP_ID = dr.IsNull("SUPP_ID") ? null : Convert.ToString(dr["SUPP_ID"]),
                                          SUPPLIER_NAME = dr.IsNull("SUPPLIER_NAME") ? null : Convert.ToString(dr["SUPPLIER_NAME"]),
                                          NAME = dr.IsNull("NAME") ? null : Convert.ToString(dr["NAME"]),
                                          DESCRIPTION = dr.IsNull("DESCRIPTION") ? null : Convert.ToString(dr["DESCRIPTION"]),
                                          SIZE = dr.IsNull("SIZE") ? null : Convert.ToString(dr["SIZE"]),
                                          UOM_ID = dr.IsNull("UOM_ID") ? null : Convert.ToString(dr["UOM_ID"]),
                                          UNIT_NAME = dr.IsNull("UNIT_NAME") ? null : Convert.ToString(dr["UNIT_NAME"]),
                                          COLOR_ID = dr.IsNull("COLOR_ID") ? null : Convert.ToString(dr["COLOR_ID"]),
                                          COLOR_NAME = dr.IsNull("COLOR_NAME") ? null : Convert.ToString(dr["COLOR_NAME"]),
                                          P_COST = dr.IsNull("P_COST") ? null : Convert.ToString(dr["P_COST"]),
                                         // LOGO_EXT = dr.IsNull("LOGO_EXT") ? null : Convert.ToString(dr["LOGO_EXT"]),
                                          CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                      }).ToList();
                }

            }

            return assetModelList;
        }
        public ComponentDTO getComponentData(int masterTag)
        {
            ComponentDTO Cat = new ComponentDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (masterTag != 0)
            {

                string selectData = " SELECT  a.MST_TAG,a.ASSET_CLASS, ac.DESCRIPTION AS CLASS_NAME,mo.CAT_ID,ca.DESCRIPTION AS CATEGORY_NAME,mo.SEG_ID,s.DESCRIPTION AS SEGMENT_NAME,mo.MAN_ID,m.DESCRIPTION AS MANUFACTURE_NAME,a.MOD_ID,mo.MODEL_NAME AS MODEL_NAME,a.SUPP_ID,ma.NAME AS SUPPLIER_NAME,a.NAME,a.DESCRIPTION,a.SIZE,a.UOM_ID,cu.UNIT_NAME,a.COLOR_ID,am.DESCRIPTION AS COLOR_NAME,a.P_COST,a.CREATED_BY FROM ASSET_MASTER a INNER JOIN ASS_CLASSIFICATION ac ON a.ASSET_CLASS=ac.CLASS_ID INNER JOIN ASS_MODEL mo on a.MOD_ID=mo.MODEL_ID INNER JOIN ASS_SUPPLIER ma on a.SUPP_ID=ma.SUPPLIER_ID INNER JOIN ASS_CATEGORY ca ON ca.CAT_ID=mo.CAT_ID INNER JOIN ASS_SEGMENT s ON s.SEG_ID=mo.SEG_ID INNER JOIN ASS_MANUFACTURE m ON m.MANF_ID=mo.MAN_ID left JOIN ARTICLEMATRIX am ON a.COLOR_ID=am.ARTMID left JOIN CONVERSIONUNIT cu ON a.UOM_ID=cu.UNIT_ID where MST_TAG = " + masterTag + "";


                SqlCommand cmd = new SqlCommand(selectData, conn);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ComponentDTO()
                           {
                               MST_TAG = dr.IsNull("MST_TAG") ? null : Convert.ToString(dr["MST_TAG"]),
                               ASSET_CLASS = dr.IsNull("ASSET_CLASS") ? null : Convert.ToString(dr["ASSET_CLASS"]),
                               CLASS_NAME = dr.IsNull("CLASS_NAME") ? null : Convert.ToString(dr["CLASS_NAME"]),
                               CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
                               CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
                               SEG_ID = dr.IsNull("SEG_ID") ? null : Convert.ToString(dr["SEG_ID"]),
                               SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
                               MOD_ID = dr.IsNull("MOD_ID") ? null : Convert.ToString(dr["MOD_ID"]),
                               MODEL_NAME = dr.IsNull("MODEL_NAME") ? null : Convert.ToString(dr["MODEL_NAME"]),
                               MAN_ID = dr.IsNull("MAN_ID") ? null : Convert.ToString(dr["MAN_ID"]),
                               MANUFACTURE_NAME = dr.IsNull("MANUFACTURE_NAME") ? null : Convert.ToString(dr["MANUFACTURE_NAME"]),
                               SUPP_ID = dr.IsNull("SUPP_ID") ? null : Convert.ToString(dr["SUPP_ID"]),
                               SUPPLIER_NAME = dr.IsNull("SUPPLIER_NAME") ? null : Convert.ToString(dr["SUPPLIER_NAME"]),
                               NAME = dr.IsNull("NAME") ? null : Convert.ToString(dr["NAME"]),
                               DESCRIPTION = dr.IsNull("DESCRIPTION") ? null : Convert.ToString(dr["DESCRIPTION"]),
                               SIZE = dr.IsNull("SIZE") ? null : Convert.ToString(dr["SIZE"]),
                               UOM_ID = dr.IsNull("UOM_ID") ? null : Convert.ToString(dr["UOM_ID"]),
                               UNIT_NAME = dr.IsNull("UNIT_NAME") ? null : Convert.ToString(dr["UNIT_NAME"]),
                               COLOR_ID = dr.IsNull("COLOR_ID") ? null : Convert.ToString(dr["COLOR_ID"]),
                               COLOR_NAME = dr.IsNull("COLOR_NAME") ? null : Convert.ToString(dr["COLOR_NAME"]),
                               P_COST = dr.IsNull("P_COST") ? null : Convert.ToString(dr["P_COST"]),
                               // CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public DataTable SavePeripheral(string eID, string dEsc, string cNAME, string catName, string segName, string mName, string manNAME, string sName, string serialNo,string company,string location, string description, string remark, string orderNumber, string purchaseDate, string purchaseCost, string department, string user, string logo, string userid)

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_ASS_PERIPHERAL", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", eID);
                cmd.Parameters.AddWithValue("@dEsc", dEsc);
                cmd.Parameters.AddWithValue("@clID ", cNAME);
                cmd.Parameters.AddWithValue("@catID", catName);
                cmd.Parameters.AddWithValue("@segmentID", segName);
                cmd.Parameters.AddWithValue("@modelID", mName);
                cmd.Parameters.AddWithValue("@manID", manNAME);
                cmd.Parameters.AddWithValue("@supID ", sName);
                cmd.Parameters.AddWithValue("@serial", serialNo);
                cmd.Parameters.AddWithValue("@company", company);
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@remarks", remark);
                cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
                cmd.Parameters.AddWithValue("@purchaseDate", purchaseDate);
                cmd.Parameters.AddWithValue("@purchaseCost ", purchaseCost);
                cmd.Parameters.AddWithValue("@department ", department);
                cmd.Parameters.AddWithValue("@user ", user);
                cmd.Parameters.AddWithValue("@logo ", logo);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable SaveAssetCMaster(long assetCMasterCode, string asset_list, string userid)

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_ASS_CMASTER", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@adId", assetCMasterCode);
                cmd.Parameters.AddWithValue("@aPCode", asset_list);
                cmd.Parameters.AddWithValue("@status ", 1);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //public AssetDetailsDTO getAssetMasterDetailsData(int assetCode)
        //{
        //    AssetDetailsDTO Cat = new AssetDetailsDTO();


        //    if (conn.State == 0)
        //    {
        //        conn.Open();
        //    }

        //    if (assetCode != 0)
        //    {

        //        string selectData = "  Select ASSET_IDFNO, di.ASSET_CODE,am.DESCRIPTION AS MAIN_ASSET,di.ASSET_CLASS,ASSET_INTTAG,ASSET_EXTTAG,SERIAL_NO,SERV_TAG,ORD_NO,ORD_DATE,CHALLAN_NO,GRC_DATE,di.P_COST,S_PRICE,TAX_AMT,DISCOUNT,LAND_VALUE,NET_AMT,DEP_RULEID,DEP_AMT,BOOK_VALUE,SALVAGE_VALUE,UDF_VALUE,WARRANTY,WAR_TYPE,ASS_EFFDATE,ASS_LIFE,LF_TYPE,ASS_DISPDATE,ASS_CONID,BUNIT_ID,DEP_ID,USER_ID,P_CODE,di.CREATED_BY from ASSET_DETAILSINFO di INNER JOIN ASSET_MASTER am on di.ASSET_CODE =am.ASSET_CODE  where di.ASSET_CODE = " + assetCode + "";


        //        SqlCommand cmd = new SqlCommand(selectData, conn);



        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();

        //        da.Fill(dt);

        //        if (Cat != null)
        //        {
        //            Cat = (from DataRow dr in dt.Rows
        //                   select new AssetDetailsDTO()
        //                   {
        //                       ASSET_CODE = dr.IsNull("ASSET_CODE") ? null : Convert.ToString(dr["ASSET_CODE"]),
        //                       MAIN_ASSET = dr.IsNull("MAIN_ASSET") ? null : Convert.ToString(dr["MAIN_ASSET"]),
        //                       ASSET_INTTAG = dr.IsNull("ASSET_INTTAG") ? null : Convert.ToString(dr["ASSET_INTTAG"]),
        //                       ASSET_EXTTAG = dr.IsNull("ASSET_EXTTAG") ? null : Convert.ToString(dr["ASSET_EXTTAG"]),
        //                       SERIAL_NO = dr.IsNull("SERIAL_NO") ? null : Convert.ToString(dr["SERIAL_NO"]),
        //                       ORD_NO = dr.IsNull("ORD_NO") ? null : Convert.ToString(dr["ORD_NO"]),
        //                       ORD_DATE = dr.IsNull("ORD_DATE") ? null : Convert.ToString(dr["ORD_DATE"]),
        //                       GRC_DATE = dr.IsNull("GRC_DATE") ? null : Convert.ToString(dr["GRC_DATE"]),
        //                       P_COST = dr.IsNull("P_COST") ? null : Convert.ToString(dr["P_COST"]),
        //                       //MAIN_ASSET = dr.IsNull("MAIN_ASSET") ? null : Convert.ToString(dr["MAIN_ASSET"]),
        //                       //SUPP_ID = dr.IsNull("SUPP_ID") ? null : Convert.ToString(dr["SUPP_ID"]),
        //                       //SUPPLIER_NAME = dr.IsNull("SUPPLIER_NAME") ? null : Convert.ToString(dr["SUPPLIER_NAME"]),
        //                       //MOD_ID = dr.IsNull("MOD_ID") ? null : Convert.ToString(dr["MOD_ID"]),
        //                       //MODEL_NAME = dr.IsNull("MODEL_NAME") ? null : Convert.ToString(dr["MODEL_NAME"]),
        //                       ////ASS_CCODE = dr.IsNull("ASS_CCODE") ? null : Convert.ToString(dr["ASS_CCODE"]),
        //                       ////CHILD_MST_TAG = dr.IsNull("CHILD_MST_TAG") ? null : Convert.ToString(dr["CHILD_MST_TAG"]),
        //                       ////CHILD_ASSET = dr.IsNull("CHILD_ASSET") ? null : Convert.ToString(dr["CHILD_ASSET"]),
        //                       //TOTAL_ASSET = dr.IsNull("TOTAL_ASSET") ? null : Convert.ToString(dr["TOTAL_ASSET"]),
        //                       CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
        //                       // CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
        //                   }).FirstOrDefault();
        //        }


        //    } 
        //    return Cat;
        //}
        public List<AssetDetailsDTO> getAssetMasterDetailsData(int assetCode)
        {
            List<AssetDetailsDTO> assetModelList = new List<AssetDetailsDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                if (assetCode != 0)
                {

                  //  string selectData = "  Select ASSET_IDFNO, di.ASSET_CODE,am.DESCRIPTION AS MAIN_ASSET,di.ASSET_CLASS,ASSET_INTTAG,ASSET_EXTTAG,SERIAL_NO,SERV_TAG,ORD_NO,ORD_DATE,CHALLAN_NO,GRC_DATE,di.P_COST,S_PRICE,TAX_AMT,DISCOUNT,LAND_VALUE,NET_AMT,DEP_RULEID,DEP_AMT,BOOK_VALUE,SALVAGE_VALUE,UDF_VALUE,WARRANTY,WAR_TYPE,ASS_EFFDATE,ASS_LIFE,LF_TYPE,ASS_DISPDATE,ASS_CONID,BUNIT_ID,DEP_ID,USER_ID,P_CODE,di.CREATED_BY from ASSET_DETAILSINFO di INNER JOIN ASSET_MASTER am on di.ASSET_CODE =am.ASSET_CODE  where di.ASSET_CODE = " + assetCode + "";

                    SqlCommand cmd = new SqlCommand("USP_ASS_MASTER_DETAILS_VIEW", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@asset_code", SqlDbType.Int).Value = assetCode;
                    
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    con.Open();
                    da.Fill(dt);
                    con.Close();
                    if (assetModelList != null)
                    {
                        assetModelList = (from DataRow dr in dt.Rows
                                          select new AssetDetailsDTO()
                                          {
                                              ASSET_CODE = Convert.ToInt32(dr["ASSET_CODE"]),
                                              ASSET_IDFNO = dr.IsNull("ASSET_IDFNO") ? null : Convert.ToString(dr["ASSET_IDFNO"]),
                                              P_CODE = dr.IsNull("P_CODE") ? null : Convert.ToString(dr["P_CODE"]),
                                              MAIN_ASSET = dr.IsNull("MAIN_ASSET") ? null : Convert.ToString(dr["MAIN_ASSET"]),
                                              ASSET_INTTAG = dr.IsNull("ASSET_INTTAG") ? null : Convert.ToString(dr["ASSET_INTTAG"]),
                                              ASSET_EXTTAG = dr.IsNull("ASSET_EXTTAG") ? null : Convert.ToString(dr["ASSET_EXTTAG"]),
                                              SERIAL_NO = dr.IsNull("SERIAL_NO") ? null : Convert.ToString(dr["SERIAL_NO"]),
                                              ORD_NO = dr.IsNull("ORD_NO") ? null : Convert.ToString(dr["ORD_NO"]),
                                              ORD_DATE = dr.IsNull("ORD_DATE") ? null : Convert.ToString(dr["ORD_DATE"]),
                                              GRC_DATE = dr.IsNull("GRC_DATE") ? null : Convert.ToString(dr["GRC_DATE"]),
                                              P_COST = dr.IsNull("P_COST") ? null : Convert.ToString(dr["P_COST"]),
                                              SUP_ID = dr.IsNull("SUP_ID") ? null : Convert.ToString(dr["SUP_ID"]),
                                              BUNIT_ID = dr.IsNull("BUNIT_ID") ? null : Convert.ToString(dr["BUNIT_ID"]),
                                              DEP_ID = dr.IsNull("DEP_ID") ? null : Convert.ToString(dr["DEP_ID"]),
                                              DEPT_NAME = dr.IsNull("DEPT_NAME") ? null : Convert.ToString(dr["DEPT_NAME"]),
                                              USER_ID = dr.IsNull("USER_ID") ? null : Convert.ToString(dr["USER_ID"]),
                                              EMPLOYEE_NAME = dr.IsNull("EMPLOYEE_NAME") ? null : Convert.ToString(dr["EMPLOYEE_NAME"]),
                                              SUPPLIER_NAME = dr.IsNull("SUPPLIER_NAME") ? null : Convert.ToString(dr["SUPPLIER_NAME"]),
                                              Organization_Name = dr.IsNull("Organization_Name") ? null : Convert.ToString(dr["Organization_Name"]),
                                              CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                          }).ToList();
                    }

                }
            }
            return assetModelList;
        }
        public List<AssetDetailsDTO> getAssetPeripheralMasterDetailsData(int assetCode)
        {
            List<AssetDetailsDTO> assetModelList = new List<AssetDetailsDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                if (assetCode != 0)
                {

                    //  string selectData = "  Select ASSET_IDFNO, di.ASSET_CODE,am.DESCRIPTION AS MAIN_ASSET,di.ASSET_CLASS,ASSET_INTTAG,ASSET_EXTTAG,SERIAL_NO,SERV_TAG,ORD_NO,ORD_DATE,CHALLAN_NO,GRC_DATE,di.P_COST,S_PRICE,TAX_AMT,DISCOUNT,LAND_VALUE,NET_AMT,DEP_RULEID,DEP_AMT,BOOK_VALUE,SALVAGE_VALUE,UDF_VALUE,WARRANTY,WAR_TYPE,ASS_EFFDATE,ASS_LIFE,LF_TYPE,ASS_DISPDATE,ASS_CONID,BUNIT_ID,DEP_ID,USER_ID,P_CODE,di.CREATED_BY from ASSET_DETAILSINFO di INNER JOIN ASSET_MASTER am on di.ASSET_CODE =am.ASSET_CODE  where di.ASSET_CODE = " + assetCode + "";

                    SqlCommand cmd = new SqlCommand("USP_ASS_MASTER_DETAILS_PERIPHERAL_LIST", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@parent_code", SqlDbType.Int).Value = assetCode;
                   // cmd.Parameters.AddWithValue("@typeID", 2);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    con.Open();
                    da.Fill(dt);
                    con.Close();
                    if (assetModelList != null)
                    {
                        assetModelList = (from DataRow dr in dt.Rows
                                          select new AssetDetailsDTO()
                                          {
                                             // ASSET_CODE = Convert.ToInt32(dr["ASSET_CODE"]),
                                              ASSET_IDFNO = dr.IsNull("ASSET_IDFNO") ? null : Convert.ToString(dr["ASSET_IDFNO"]),
                                              P_CODE = dr.IsNull("P_CODE") ? null : Convert.ToString(dr["P_CODE"]),
                                              MAIN_ASSET_CODE = dr.IsNull("MAIN_ASSET_CODE") ? null : Convert.ToString(dr["MAIN_ASSET_CODE"]),
                                              PERIPHERAL_CODE = dr.IsNull("PERIPHERAL_CODE") ? null : Convert.ToString(dr["PERIPHERAL_CODE"]),
                                              // PERIPHERAL_CODE = Convert.ToInt32(dr["PERIPHERAL_CODE"]),
                                              CHILD_ASSET = dr.IsNull("CHILD_ASSET") ? null : Convert.ToString(dr["CHILD_ASSET"]),
                                              CLASS_NAME = dr.IsNull("CLASS_NAME") ? null : Convert.ToString(dr["CLASS_NAME"]),
                                              CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
                                              CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
                                              SEG_ID = dr.IsNull("SEG_ID") ? null : Convert.ToString(dr["SEG_ID"]),
                                              SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
                                              MOD_ID = dr.IsNull("MOD_ID") ? null : Convert.ToString(dr["MOD_ID"]),
                                              MODEL_NAME = dr.IsNull("MODEL_NAME") ? null : Convert.ToString(dr["MODEL_NAME"]),
                                              MAN_ID = dr.IsNull("MAN_ID") ? null : Convert.ToString(dr["MAN_ID"]),
                                              MANUFACTURE = dr.IsNull("MANUFACTURE") ? null : Convert.ToString(dr["MANUFACTURE"]),
                                              ASSET_INTTAG = dr.IsNull("ASSET_INTTAG") ? null : Convert.ToString(dr["ASSET_INTTAG"]),
                                              ASSET_EXTTAG = dr.IsNull("ASSET_EXTTAG") ? null : Convert.ToString(dr["ASSET_EXTTAG"]),
                                              P_SERIAL_NO = dr.IsNull("P_SERIAL_NO") ? null : Convert.ToString(dr["P_SERIAL_NO"]),
                                              ORD_NO = dr.IsNull("ORD_NO") ? null : Convert.ToString(dr["ORD_NO"]),
                                              ORD_DATE = dr.IsNull("ORD_DATE") ? null : Convert.ToString(dr["ORD_DATE"]),
                                              GRC_DATE = dr.IsNull("GRC_DATE") ? null : Convert.ToString(dr["GRC_DATE"]),
                                              QUANTITY = dr.IsNull("QUANTITY") ? null : Convert.ToString(dr["QUANTITY"]),
                                              P_COST = dr.IsNull("P_COST") ? null : Convert.ToString(dr["P_COST"]),
                                              SUP_ID = dr.IsNull("SUP_ID") ? null : Convert.ToString(dr["SUP_ID"]),
                                              SUPPLIER_NAME = dr.IsNull("SUPPLIER_NAME") ? null : Convert.ToString(dr["SUPPLIER_NAME"]),
                                              CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                          }).ToList();
                    }

                }
            }
            return assetModelList;
        }
        public List<AssetDetailsDTO> MasterPeripheralList()
        {
            List<AssetDetailsDTO> assetModelList = new List<AssetDetailsDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_ASS_MASTER_PERIPHERAL_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetModelList != null)
                {
                    assetModelList = (from DataRow dr in dt.Rows
                                      select new AssetDetailsDTO()
                                      {
                                          // ASSET_CODE = Convert.ToInt32(dr["ASSET_CODE"]),
                                          ASSET_IDFNO = dr.IsNull("ASSET_IDFNO") ? null : Convert.ToString(dr["ASSET_IDFNO"]),
                                          P_CODE = dr.IsNull("P_CODE") ? null : Convert.ToString(dr["P_CODE"]),
                                          MAIN_ASSET_CODE = dr.IsNull("MAIN_ASSET_CODE") ? null : Convert.ToString(dr["MAIN_ASSET_CODE"]),
                                          PERIPHERAL_CODE = dr.IsNull("PERIPHERAL_CODE") ? null : Convert.ToString(dr["PERIPHERAL_CODE"]),
                                          // PERIPHERAL_CODE = Convert.ToInt32(dr["PERIPHERAL_CODE"]),
                                          CHILD_ASSET = dr.IsNull("CHILD_ASSET") ? null : Convert.ToString(dr["CHILD_ASSET"]),
                                          CLASS_NAME = dr.IsNull("CLASS_NAME") ? null : Convert.ToString(dr["CLASS_NAME"]),
                                          CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
                                          CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
                                          SEG_ID = dr.IsNull("SEG_ID") ? null : Convert.ToString(dr["SEG_ID"]),
                                          SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
                                          MOD_ID = dr.IsNull("MOD_ID") ? null : Convert.ToString(dr["MOD_ID"]),
                                          MODEL_NAME = dr.IsNull("MODEL_NAME") ? null : Convert.ToString(dr["MODEL_NAME"]),
                                          MAN_ID = dr.IsNull("MAN_ID") ? null : Convert.ToString(dr["MAN_ID"]),
                                          MANUFACTURE = dr.IsNull("MANUFACTURE") ? null : Convert.ToString(dr["MANUFACTURE"]),
                                          ASSET_INTTAG = dr.IsNull("ASSET_INTTAG") ? null : Convert.ToString(dr["ASSET_INTTAG"]),
                                          ASSET_EXTTAG = dr.IsNull("ASSET_EXTTAG") ? null : Convert.ToString(dr["ASSET_EXTTAG"]),
                                          P_SERIAL_NO = dr.IsNull("P_SERIAL_NO") ? null : Convert.ToString(dr["P_SERIAL_NO"]),
                                          ORD_NO = dr.IsNull("ORD_NO") ? null : Convert.ToString(dr["ORD_NO"]),
                                          ORD_DATE = dr.IsNull("ORD_DATE") ? null : Convert.ToString(dr["ORD_DATE"]),
                                          GRC_DATE = dr.IsNull("GRC_DATE") ? null : Convert.ToString(dr["GRC_DATE"]),
                                          // QUANTITY = dr.IsNull("QUANTITY") ? null : Convert.ToString(dr["QUANTITY"]),
                                          P_COST = dr.IsNull("P_COST") ? null : Convert.ToString(dr["P_COST"]),
                                          SUP_ID = dr.IsNull("SUP_ID") ? null : Convert.ToString(dr["SUP_ID"]),
                                          SUPPLIER_NAME = dr.IsNull("SUPPLIER_NAME") ? null : Convert.ToString(dr["SUPPLIER_NAME"]),
                                          CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                      }).ToList();
                }

            }

            return assetModelList;
        }
        public List<AssetDetailsDTO> MasterComponentList()
        {
            List<AssetDetailsDTO> assetModelList = new List<AssetDetailsDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_ASS_MASTER_COMPONENT_LIST ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetModelList != null)
                {
                    assetModelList = (from DataRow dr in dt.Rows
                                      select new AssetDetailsDTO()
                                      {
                                          // ASSET_CODE = Convert.ToInt32(dr["ASSET_CODE"]),
                                          ASSET_IDFNO = dr.IsNull("ASSET_IDFNO") ? null : Convert.ToString(dr["ASSET_IDFNO"]),
                                          P_CODE = dr.IsNull("P_CODE") ? null : Convert.ToString(dr["P_CODE"]),
                                          MAIN_ASSET_CODE = dr.IsNull("MAIN_ASSET_CODE") ? null : Convert.ToString(dr["MAIN_ASSET_CODE"]),
                                          PERIPHERAL_CODE = dr.IsNull("PERIPHERAL_CODE") ? null : Convert.ToString(dr["PERIPHERAL_CODE"]),
                                          // PERIPHERAL_CODE = Convert.ToInt32(dr["PERIPHERAL_CODE"]),
                                          CHILD_ASSET = dr.IsNull("CHILD_ASSET") ? null : Convert.ToString(dr["CHILD_ASSET"]),
                                          CLASS_NAME = dr.IsNull("CLASS_NAME") ? null : Convert.ToString(dr["CLASS_NAME"]),
                                          CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
                                          CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
                                          SEG_ID = dr.IsNull("SEG_ID") ? null : Convert.ToString(dr["SEG_ID"]),
                                          SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
                                          MOD_ID = dr.IsNull("MOD_ID") ? null : Convert.ToString(dr["MOD_ID"]),
                                          MODEL_NAME = dr.IsNull("MODEL_NAME") ? null : Convert.ToString(dr["MODEL_NAME"]),
                                          MAN_ID = dr.IsNull("MAN_ID") ? null : Convert.ToString(dr["MAN_ID"]),
                                          MANUFACTURE = dr.IsNull("MANUFACTURE") ? null : Convert.ToString(dr["MANUFACTURE"]),
                                          ASSET_INTTAG = dr.IsNull("ASSET_INTTAG") ? null : Convert.ToString(dr["ASSET_INTTAG"]),
                                          ASSET_EXTTAG = dr.IsNull("ASSET_EXTTAG") ? null : Convert.ToString(dr["ASSET_EXTTAG"]),
                                          SERIAL_NO = dr.IsNull("SERIAL_NO") ? null : Convert.ToString(dr["SERIAL_NO"]),
                                          ORD_NO = dr.IsNull("ORD_NO") ? null : Convert.ToString(dr["ORD_NO"]),
                                          ORD_DATE = dr.IsNull("ORD_DATE") ? null : Convert.ToString(dr["ORD_DATE"]),
                                          GRC_DATE = dr.IsNull("GRC_DATE") ? null : Convert.ToString(dr["GRC_DATE"]),
                                          // QUANTITY = dr.IsNull("QUANTITY") ? null : Convert.ToString(dr["QUANTITY"]),
                                          P_COST = dr.IsNull("P_COST") ? null : Convert.ToString(dr["P_COST"]),
                                          SUP_ID = dr.IsNull("SUP_ID") ? null : Convert.ToString(dr["SUP_ID"]),
                                          SUPPLIER_NAME = dr.IsNull("SUPPLIER_NAME") ? null : Convert.ToString(dr["SUPPLIER_NAME"]),
                                          CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                      }).ToList();
                }

            }

            return assetModelList;
        }
        //public AssetDetailsDTO MasterPeripheralList()
        //{
        //    AssetDetailsDTO assetModelList = new AssetDetailsDTO();

        //    using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
        //    {



        //        SqlCommand cmd = new SqlCommand("USP_ASS_MASTER_PERIPHERAL_LIST", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        con.Open();
        //        da.Fill(dt);
        //        con.Close();
        //        if (assetModelList != null)
        //            {
        //                assetModelList = (from DataRow dr in dt.Rows
        //                                  select new AssetDetailsDTO()
        //                                  {
        //                                      // ASSET_CODE = Convert.ToInt32(dr["ASSET_CODE"]),
        //                                      ASSET_IDFNO = dr.IsNull("ASSET_IDFNO") ? null : Convert.ToString(dr["ASSET_IDFNO"]),
        //                                      P_CODE = dr.IsNull("P_CODE") ? null : Convert.ToString(dr["P_CODE"]),
        //                                      MAIN_ASSET_CODE = dr.IsNull("MAIN_ASSET_CODE") ? null : Convert.ToString(dr["MAIN_ASSET_CODE"]),
        //                                      PERIPHERAL_CODE = dr.IsNull("PERIPHERAL_CODE") ? null : Convert.ToString(dr["PERIPHERAL_CODE"]),
        //                                      // PERIPHERAL_CODE = Convert.ToInt32(dr["PERIPHERAL_CODE"]),
        //                                      CHILD_ASSET = dr.IsNull("CHILD_ASSET") ? null : Convert.ToString(dr["CHILD_ASSET"]),
        //                                      CLASS_NAME = dr.IsNull("CLASS_NAME") ? null : Convert.ToString(dr["CLASS_NAME"]),
        //                                      CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
        //                                      CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
        //                                      SEG_ID = dr.IsNull("SEG_ID") ? null : Convert.ToString(dr["SEG_ID"]),
        //                                      SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
        //                                      MOD_ID = dr.IsNull("MOD_ID") ? null : Convert.ToString(dr["MOD_ID"]),
        //                                      MODEL_NAME = dr.IsNull("MODEL_NAME") ? null : Convert.ToString(dr["MODEL_NAME"]),
        //                                      MAN_ID = dr.IsNull("MAN_ID") ? null : Convert.ToString(dr["MAN_ID"]),
        //                                      MANUFACTURE = dr.IsNull("MANUFACTURE") ? null : Convert.ToString(dr["MANUFACTURE"]),
        //                                      ASSET_INTTAG = dr.IsNull("ASSET_INTTAG") ? null : Convert.ToString(dr["ASSET_INTTAG"]),
        //                                      ASSET_EXTTAG = dr.IsNull("ASSET_EXTTAG") ? null : Convert.ToString(dr["ASSET_EXTTAG"]),
        //                                      P_SERIAL_NO = dr.IsNull("P_SERIAL_NO") ? null : Convert.ToString(dr["P_SERIAL_NO"]),
        //                                      ORD_NO = dr.IsNull("ORD_NO") ? null : Convert.ToString(dr["ORD_NO"]),
        //                                      ORD_DATE = dr.IsNull("ORD_DATE") ? null : Convert.ToString(dr["ORD_DATE"]),
        //                                      GRC_DATE = dr.IsNull("GRC_DATE") ? null : Convert.ToString(dr["GRC_DATE"]),
        //                                     // QUANTITY = dr.IsNull("QUANTITY") ? null : Convert.ToString(dr["QUANTITY"]),
        //                                      P_COST = dr.IsNull("P_COST") ? null : Convert.ToString(dr["P_COST"]),
        //                                      SUP_ID = dr.IsNull("SUP_ID") ? null : Convert.ToString(dr["SUP_ID"]),
        //                                      SUPPLIER_NAME = dr.IsNull("SUPPLIER_NAME") ? null : Convert.ToString(dr["SUPPLIER_NAME"]),
        //                                      CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
        //                                  }).FirstOrDefault();
        //            }

        //        }

        //    return assetModelList;
        //}


        public AssetDetailsDTO getAssetDetailsPeripheralList(int parentCode,int peripheralCode)
        {
            AssetDetailsDTO Cat = new AssetDetailsDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (peripheralCode != 0)
            {

                //string selectData = "SELECT MODEL_ID, a.EXTERNAL_ID,a.MODEL_NAME, a.CLASS_ID, ac.DESCRIPTION AS CLASS_NAME,a.CAT_ID,ca.DESCRIPTION AS CATEGORY_NAME,a.SEG_ID,se.DESCRIPTION AS SEGMENT_NAME,a.MAN_ID,m.DESCRIPTION AS MANUFACTURE_NAME,a.SUP_ID,S.NAME AS SUPPLIER_NAME,a.MODEL_NO,a.NOTES,a.LOGO_EXT,a.CREATED_BY FROM ASS_MODEL a INNER JOIN ASS_CLASSIFICATION ac ON a.CLASS_ID = ac.CLASS_ID INNER JOIN ASS_CATEGORY ca on a.CAT_ID = ca.CAT_ID    INNER JOIN ASS_SEGMENT se on a.SEG_ID = se.SEG_ID INNER JOIN ASS_MANUFACTURE m on a.MAN_ID=m.MANF_ID INNER JOIN ASS_SUPPLIER s on a.SUP_ID=s.SUPPLIER_ID where MODEL_ID = " + modelId + "";

                SqlCommand cmd = new SqlCommand("USP_ASS_MASTER_PERIPHERAL_LIST_edit", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // SqlCommand cmd = new SqlCommand(selectData, conn);
                //  cmd.Parameters.AddWithValue("@parent_code", SqlDbType.Int).Value = assetDetailsCode;
               cmd.Parameters.AddWithValue("@parent_code", parentCode);
                cmd.Parameters.AddWithValue("@Asset_code", peripheralCode);
               // cmd.Parameters.AddWithValue("@parent_code", assetDetailsCode);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new AssetDetailsDTO()
                           {
                               ASSET_IDFNO = dr.IsNull("ASSET_IDFNO") ? null : Convert.ToString(dr["ASSET_IDFNO"]),
                               MAIN_ASSET_CODE = dr.IsNull("MAIN_ASSET_CODE") ? null : Convert.ToString(dr["MAIN_ASSET_CODE"]),
                               PERIPHERAL_CODE = dr.IsNull("PERIPHERAL_CODE") ? null : Convert.ToString(dr["PERIPHERAL_CODE"]),
                               CHILD_ASSET = dr.IsNull("CHILD_ASSET") ? null : Convert.ToString(dr["CHILD_ASSET"]),
                               TYPE_ID = dr.IsNull("TYPE_ID") ? null : Convert.ToString(dr["TYPE_ID"]),
                               ASSET_CLASS = dr.IsNull("ASSET_CLASS") ? null : Convert.ToString(dr["ASSET_CLASS"]),
                               CLASS_NAME = dr.IsNull("CLASS_NAME") ? null : Convert.ToString(dr["CLASS_NAME"]),
                               CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
                               CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
                               SEG_ID = dr.IsNull("SEG_ID") ? null : Convert.ToString(dr["SEG_ID"]),
                               SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
                               MOD_ID = dr.IsNull("MOD_ID") ? null : Convert.ToString(dr["MOD_ID"]),
                               MODEL_NAME = dr.IsNull("MODEL_NAME") ? null : Convert.ToString(dr["MODEL_NAME"]),
                               MAN_ID = dr.IsNull("MAN_ID") ? null : Convert.ToString(dr["MAN_ID"]),
                               MANUFACTURE = dr.IsNull("MANUFACTURE") ? null : Convert.ToString(dr["MANUFACTURE"]),
                               ASSET_INTTAG = dr.IsNull("ASSET_INTTAG") ? null : Convert.ToString(dr["ASSET_INTTAG"]),
                               ASSET_EXTTAG = dr.IsNull("ASSET_EXTTAG") ? null : Convert.ToString(dr["ASSET_EXTTAG"]),
                               P_SERIAL_NO = dr.IsNull("P_SERIAL_NO") ? null : Convert.ToString(dr["P_SERIAL_NO"]),
                               SERV_TAG = dr.IsNull("SERV_TAG") ? null : Convert.ToString(dr["SERV_TAG"]),
                               ORD_NO = dr.IsNull("ORD_NO") ? null : Convert.ToString(dr["ORD_NO"]),
                               ORD_DATE = dr.IsNull("ORD_DATE") ? null : Convert.ToString(dr["ORD_DATE"]),
                               CHALLAN_NO = dr.IsNull("CHALLAN_NO") ? null : Convert.ToString(dr["CHALLAN_NO"]),
                               GRC_DATE = dr.IsNull("GRC_DATE") ? null : Convert.ToString(dr["GRC_DATE"]),
                               SUP_ID = dr.IsNull("SUP_ID") ? null : Convert.ToString(dr["SUP_ID"]),
                               SUPPLIER_NAME = dr.IsNull("SUPPLIER_NAME") ? null : Convert.ToString(dr["SUPPLIER_NAME"]),
                               P_COST = dr.IsNull("P_COST") ? null : Convert.ToString(dr["P_COST"]),
                               S_PRICE = dr.IsNull("S_PRICE") ? null : Convert.ToString(dr["S_PRICE"]),
                               TAX_AMT = dr.IsNull("TAX_AMT") ? null : Convert.ToString(dr["TAX_AMT"]),
                               DISCOUNT = dr.IsNull("DISCOUNT") ? null : Convert.ToString(dr["DISCOUNT"]),
                               LAND_VALUE = dr.IsNull("LAND_VALUE") ? null : Convert.ToString(dr["LAND_VALUE"]),
                               NET_AMT = dr.IsNull("NET_AMT") ? null : Convert.ToString(dr["NET_AMT"]),
                               DEP_RULEID = dr.IsNull("DEP_RULEID") ? null : Convert.ToString(dr["DEP_RULEID"]),
                               DEP_AMT = dr.IsNull("DEP_AMT") ? null : Convert.ToString(dr["DEP_AMT"]),
                               BOOK_VALUE = dr.IsNull("BOOK_VALUE") ? null : Convert.ToString(dr["BOOK_VALUE"]),
                               SALVAGE_VALUE = dr.IsNull("SALVAGE_VALUE") ? null : Convert.ToString(dr["SALVAGE_VALUE"]),
                               UDF_VALUE = dr.IsNull("UDF_VALUE") ? null : Convert.ToString(dr["UDF_VALUE"]),
                               WARRANTY = dr.IsNull("WARRANTY") ? null : Convert.ToString(dr["WARRANTY"]),
                               WAR_TYPE = dr.IsNull("WAR_TYPE") ? null : Convert.ToString(dr["WAR_TYPE"]),
                               ASS_EFFDATE = dr.IsNull("ASS_EFFDATE") ? null : Convert.ToString(dr["ASS_EFFDATE"]),
                               ASS_LIFE = dr.IsNull("ASS_LIFE") ? null : Convert.ToString(dr["ASS_LIFE"]),
                               LF_TYPE = dr.IsNull("LF_TYPE") ? null : Convert.ToString(dr["LF_TYPE"]),
                               ASS_DISPDATE = dr.IsNull("ASS_DISPDATE") ? null : Convert.ToString(dr["ASS_DISPDATE"]),
                               ASS_CONID = dr.IsNull("ASS_CONID") ? null : Convert.ToString(dr["ASS_CONID"]),
                               STATUS = dr.IsNull("STATUS") ? null : Convert.ToString(dr["STATUS"]),
                               BUNIT_ID = dr.IsNull("BUNIT_ID") ? null : Convert.ToString(dr["BUNIT_ID"]),
                               DEP_ID = dr.IsNull("DEP_ID") ? null : Convert.ToString(dr["DEP_ID"]),
                               USER_ID = dr.IsNull("USER_ID") ? null : Convert.ToString(dr["USER_ID"]),
                               P_CODE = dr.IsNull("P_CODE") ? null : Convert.ToString(dr["P_CODE"]),
                               CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                               // CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public AssetDetailsDTO getAssetPeripheralList(int peripheralCode)
        {
            AssetDetailsDTO Cat = new AssetDetailsDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (peripheralCode != 0)
            {

                //string selectData = "SELECT MODEL_ID, a.EXTERNAL_ID,a.MODEL_NAME, a.CLASS_ID, ac.DESCRIPTION AS CLASS_NAME,a.CAT_ID,ca.DESCRIPTION AS CATEGORY_NAME,a.SEG_ID,se.DESCRIPTION AS SEGMENT_NAME,a.MAN_ID,m.DESCRIPTION AS MANUFACTURE_NAME,a.SUP_ID,S.NAME AS SUPPLIER_NAME,a.MODEL_NO,a.NOTES,a.LOGO_EXT,a.CREATED_BY FROM ASS_MODEL a INNER JOIN ASS_CLASSIFICATION ac ON a.CLASS_ID = ac.CLASS_ID INNER JOIN ASS_CATEGORY ca on a.CAT_ID = ca.CAT_ID    INNER JOIN ASS_SEGMENT se on a.SEG_ID = se.SEG_ID INNER JOIN ASS_MANUFACTURE m on a.MAN_ID=m.MANF_ID INNER JOIN ASS_SUPPLIER s on a.SUP_ID=s.SUPPLIER_ID where MODEL_ID = " + modelId + "";

                SqlCommand cmd = new SqlCommand("USP_ASS_MASTER_PERIPHERAL_edit", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Asset_code", peripheralCode);
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new AssetDetailsDTO()
                           {
                               ASSET_IDFNO = dr.IsNull("ASSET_IDFNO") ? null : Convert.ToString(dr["ASSET_IDFNO"]),
                               MAIN_ASSET_CODE = dr.IsNull("MAIN_ASSET_CODE") ? null : Convert.ToString(dr["MAIN_ASSET_CODE"]),
                               PERIPHERAL_CODE = dr.IsNull("PERIPHERAL_CODE") ? null : Convert.ToString(dr["PERIPHERAL_CODE"]),
                               CHILD_ASSET = dr.IsNull("CHILD_ASSET") ? null : Convert.ToString(dr["CHILD_ASSET"]),
                               TYPE_ID = dr.IsNull("TYPE_ID") ? null : Convert.ToString(dr["TYPE_ID"]),
                               ASSET_CLASS = dr.IsNull("ASSET_CLASS") ? null : Convert.ToString(dr["ASSET_CLASS"]),
                               CLASS_NAME = dr.IsNull("CLASS_NAME") ? null : Convert.ToString(dr["CLASS_NAME"]),
                               CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
                               CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
                               SEG_ID = dr.IsNull("SEG_ID") ? null : Convert.ToString(dr["SEG_ID"]),
                               SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
                               MOD_ID = dr.IsNull("MOD_ID") ? null : Convert.ToString(dr["MOD_ID"]),
                               MODEL_NAME = dr.IsNull("MODEL_NAME") ? null : Convert.ToString(dr["MODEL_NAME"]),
                               MAN_ID = dr.IsNull("MAN_ID") ? null : Convert.ToString(dr["MAN_ID"]),
                               MANUFACTURE = dr.IsNull("MANUFACTURE") ? null : Convert.ToString(dr["MANUFACTURE"]),
                               ASSET_INTTAG = dr.IsNull("ASSET_INTTAG") ? null : Convert.ToString(dr["ASSET_INTTAG"]),
                               ASSET_EXTTAG = dr.IsNull("ASSET_EXTTAG") ? null : Convert.ToString(dr["ASSET_EXTTAG"]),
                               P_SERIAL_NO = dr.IsNull("P_SERIAL_NO") ? null : Convert.ToString(dr["P_SERIAL_NO"]),
                               SERV_TAG = dr.IsNull("SERV_TAG") ? null : Convert.ToString(dr["SERV_TAG"]),
                               ORD_NO = dr.IsNull("ORD_NO") ? null : Convert.ToString(dr["ORD_NO"]),
                               ORD_DATE = dr.IsNull("ORD_DATE") ? null : Convert.ToString(dr["ORD_DATE"]),
                               CHALLAN_NO = dr.IsNull("CHALLAN_NO") ? null : Convert.ToString(dr["CHALLAN_NO"]),
                               GRC_DATE = dr.IsNull("GRC_DATE") ? null : Convert.ToString(dr["GRC_DATE"]),
                               SUP_ID = dr.IsNull("SUP_ID") ? null : Convert.ToString(dr["SUP_ID"]),
                               SUPPLIER_NAME = dr.IsNull("SUPPLIER_NAME") ? null : Convert.ToString(dr["SUPPLIER_NAME"]),
                               P_COST = dr.IsNull("P_COST") ? null : Convert.ToString(dr["P_COST"]),
                               S_PRICE = dr.IsNull("S_PRICE") ? null : Convert.ToString(dr["S_PRICE"]),
                               TAX_AMT = dr.IsNull("TAX_AMT") ? null : Convert.ToString(dr["TAX_AMT"]),
                               DISCOUNT = dr.IsNull("DISCOUNT") ? null : Convert.ToString(dr["DISCOUNT"]),
                               LAND_VALUE = dr.IsNull("LAND_VALUE") ? null : Convert.ToString(dr["LAND_VALUE"]),
                               NET_AMT = dr.IsNull("NET_AMT") ? null : Convert.ToString(dr["NET_AMT"]),
                               DEP_RULEID = dr.IsNull("DEP_RULEID") ? null : Convert.ToString(dr["DEP_RULEID"]),
                               DEP_AMT = dr.IsNull("DEP_AMT") ? null : Convert.ToString(dr["DEP_AMT"]),
                               BOOK_VALUE = dr.IsNull("BOOK_VALUE") ? null : Convert.ToString(dr["BOOK_VALUE"]),
                               SALVAGE_VALUE = dr.IsNull("SALVAGE_VALUE") ? null : Convert.ToString(dr["SALVAGE_VALUE"]),
                               UDF_VALUE = dr.IsNull("UDF_VALUE") ? null : Convert.ToString(dr["UDF_VALUE"]),
                               WARRANTY = dr.IsNull("WARRANTY") ? null : Convert.ToString(dr["WARRANTY"]),
                               WAR_TYPE = dr.IsNull("WAR_TYPE") ? null : Convert.ToString(dr["WAR_TYPE"]),
                               ASS_EFFDATE = dr.IsNull("ASS_EFFDATE") ? null : Convert.ToString(dr["ASS_EFFDATE"]),
                               ASS_LIFE = dr.IsNull("ASS_LIFE") ? null : Convert.ToString(dr["ASS_LIFE"]),
                               LF_TYPE = dr.IsNull("LF_TYPE") ? null : Convert.ToString(dr["LF_TYPE"]),
                               ASS_DISPDATE = dr.IsNull("ASS_DISPDATE") ? null : Convert.ToString(dr["ASS_DISPDATE"]),
                               ASS_CONID = dr.IsNull("ASS_CONID") ? null : Convert.ToString(dr["ASS_CONID"]),
                               STATUS = dr.IsNull("STATUS") ? null : Convert.ToString(dr["STATUS"]),
                               BUNIT_ID = dr.IsNull("BUNIT_ID") ? null : Convert.ToString(dr["BUNIT_ID"]),
                               DEP_ID = dr.IsNull("DEP_ID") ? null : Convert.ToString(dr["DEP_ID"]),
                               USER_ID = dr.IsNull("USER_ID") ? null : Convert.ToString(dr["USER_ID"]),
                               P_CODE = dr.IsNull("P_CODE") ? null : Convert.ToString(dr["P_CODE"]),
                               CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                               // CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public AssetDetailsDTO getAssetDetailsComponentList(int parentCode, int peripheralCode)
        {
            AssetDetailsDTO Cat = new AssetDetailsDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (peripheralCode != 0)
            {

                //string selectData = "SELECT MODEL_ID, a.EXTERNAL_ID,a.MODEL_NAME, a.CLASS_ID, ac.DESCRIPTION AS CLASS_NAME,a.CAT_ID,ca.DESCRIPTION AS CATEGORY_NAME,a.SEG_ID,se.DESCRIPTION AS SEGMENT_NAME,a.MAN_ID,m.DESCRIPTION AS MANUFACTURE_NAME,a.SUP_ID,S.NAME AS SUPPLIER_NAME,a.MODEL_NO,a.NOTES,a.LOGO_EXT,a.CREATED_BY FROM ASS_MODEL a INNER JOIN ASS_CLASSIFICATION ac ON a.CLASS_ID = ac.CLASS_ID INNER JOIN ASS_CATEGORY ca on a.CAT_ID = ca.CAT_ID    INNER JOIN ASS_SEGMENT se on a.SEG_ID = se.SEG_ID INNER JOIN ASS_MANUFACTURE m on a.MAN_ID=m.MANF_ID INNER JOIN ASS_SUPPLIER s on a.SUP_ID=s.SUPPLIER_ID where MODEL_ID = " + modelId + "";

                SqlCommand cmd = new SqlCommand("USP_ASS_MASTER_COMPONENT_edit", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // SqlCommand cmd = new SqlCommand(selectData, conn);
                //  cmd.Parameters.AddWithValue("@parent_code", SqlDbType.Int).Value = assetDetailsCode;
                cmd.Parameters.AddWithValue("@parent_code", parentCode);
                cmd.Parameters.AddWithValue("@Asset_code", peripheralCode);
                // cmd.Parameters.AddWithValue("@parent_code", assetDetailsCode);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new AssetDetailsDTO()
                           {
                               ASSET_IDFNO = dr.IsNull("ASSET_IDFNO") ? null : Convert.ToString(dr["ASSET_IDFNO"]),
                               MAIN_ASSET_CODE = dr.IsNull("MAIN_ASSET_CODE") ? null : Convert.ToString(dr["MAIN_ASSET_CODE"]),
                               PERIPHERAL_CODE = dr.IsNull("PERIPHERAL_CODE") ? null : Convert.ToString(dr["PERIPHERAL_CODE"]),
                               CHILD_ASSET = dr.IsNull("CHILD_ASSET") ? null : Convert.ToString(dr["CHILD_ASSET"]),
                               TYPE_ID = dr.IsNull("TYPE_ID") ? null : Convert.ToString(dr["TYPE_ID"]),
                               ASSET_CLASS = dr.IsNull("ASSET_CLASS") ? null : Convert.ToString(dr["ASSET_CLASS"]),
                               CLASS_NAME = dr.IsNull("CLASS_NAME") ? null : Convert.ToString(dr["CLASS_NAME"]),
                               CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
                               CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
                               SEG_ID = dr.IsNull("SEG_ID") ? null : Convert.ToString(dr["SEG_ID"]),
                               SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
                               MOD_ID = dr.IsNull("MOD_ID") ? null : Convert.ToString(dr["MOD_ID"]),
                               MODEL_NAME = dr.IsNull("MODEL_NAME") ? null : Convert.ToString(dr["MODEL_NAME"]),
                               MAN_ID = dr.IsNull("MAN_ID") ? null : Convert.ToString(dr["MAN_ID"]),
                               MANUFACTURE = dr.IsNull("MANUFACTURE") ? null : Convert.ToString(dr["MANUFACTURE"]),
                               ASSET_INTTAG = dr.IsNull("ASSET_INTTAG") ? null : Convert.ToString(dr["ASSET_INTTAG"]),
                               ASSET_EXTTAG = dr.IsNull("ASSET_EXTTAG") ? null : Convert.ToString(dr["ASSET_EXTTAG"]),
                               SERIAL_NO = dr.IsNull("SERIAL_NO") ? null : Convert.ToString(dr["SERIAL_NO"]),
                               SERV_TAG = dr.IsNull("SERV_TAG") ? null : Convert.ToString(dr["SERV_TAG"]),
                               ORD_NO = dr.IsNull("ORD_NO") ? null : Convert.ToString(dr["ORD_NO"]),
                               ORD_DATE = dr.IsNull("ORD_DATE") ? null : Convert.ToString(dr["ORD_DATE"]),
                               CHALLAN_NO = dr.IsNull("CHALLAN_NO") ? null : Convert.ToString(dr["CHALLAN_NO"]),
                               GRC_DATE = dr.IsNull("GRC_DATE") ? null : Convert.ToString(dr["GRC_DATE"]),
                               SUP_ID = dr.IsNull("SUP_ID") ? null : Convert.ToString(dr["SUP_ID"]),
                               SUPPLIER_NAME = dr.IsNull("SUPPLIER_NAME") ? null : Convert.ToString(dr["SUPPLIER_NAME"]),
                               P_COST = dr.IsNull("P_COST") ? null : Convert.ToString(dr["P_COST"]),
                               S_PRICE = dr.IsNull("S_PRICE") ? null : Convert.ToString(dr["S_PRICE"]),
                               TAX_AMT = dr.IsNull("TAX_AMT") ? null : Convert.ToString(dr["TAX_AMT"]),
                               DISCOUNT = dr.IsNull("DISCOUNT") ? null : Convert.ToString(dr["DISCOUNT"]),
                               LAND_VALUE = dr.IsNull("LAND_VALUE") ? null : Convert.ToString(dr["LAND_VALUE"]),
                               NET_AMT = dr.IsNull("NET_AMT") ? null : Convert.ToString(dr["NET_AMT"]),
                               DEP_RULEID = dr.IsNull("DEP_RULEID") ? null : Convert.ToString(dr["DEP_RULEID"]),
                               DEP_AMT = dr.IsNull("DEP_AMT") ? null : Convert.ToString(dr["DEP_AMT"]),
                               BOOK_VALUE = dr.IsNull("BOOK_VALUE") ? null : Convert.ToString(dr["BOOK_VALUE"]),
                               SALVAGE_VALUE = dr.IsNull("SALVAGE_VALUE") ? null : Convert.ToString(dr["SALVAGE_VALUE"]),
                               UDF_VALUE = dr.IsNull("UDF_VALUE") ? null : Convert.ToString(dr["UDF_VALUE"]),
                               WARRANTY = dr.IsNull("WARRANTY") ? null : Convert.ToString(dr["WARRANTY"]),
                               WAR_TYPE = dr.IsNull("WAR_TYPE") ? null : Convert.ToString(dr["WAR_TYPE"]),
                               ASS_EFFDATE = dr.IsNull("ASS_EFFDATE") ? null : Convert.ToString(dr["ASS_EFFDATE"]),
                               ASS_LIFE = dr.IsNull("ASS_LIFE") ? null : Convert.ToString(dr["ASS_LIFE"]),
                               LF_TYPE = dr.IsNull("LF_TYPE") ? null : Convert.ToString(dr["LF_TYPE"]),
                               ASS_DISPDATE = dr.IsNull("ASS_DISPDATE") ? null : Convert.ToString(dr["ASS_DISPDATE"]),
                               ASS_CONID = dr.IsNull("ASS_CONID") ? null : Convert.ToString(dr["ASS_CONID"]),
                               STATUS = dr.IsNull("STATUS") ? null : Convert.ToString(dr["STATUS"]),
                               BUNIT_ID = dr.IsNull("BUNIT_ID") ? null : Convert.ToString(dr["BUNIT_ID"]),
                               DEP_ID = dr.IsNull("DEP_ID") ? null : Convert.ToString(dr["DEP_ID"]),
                               USER_ID = dr.IsNull("USER_ID") ? null : Convert.ToString(dr["USER_ID"]),
                               P_CODE = dr.IsNull("P_CODE") ? null : Convert.ToString(dr["P_CODE"]),
                               CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                               // CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public AssetDetailsDTO getAssetDetailsComponent(int peripheralCode)
        {
            AssetDetailsDTO Cat = new AssetDetailsDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (peripheralCode != 0)
            {

                //string selectData = "SELECT MODEL_ID, a.EXTERNAL_ID,a.MODEL_NAME, a.CLASS_ID, ac.DESCRIPTION AS CLASS_NAME,a.CAT_ID,ca.DESCRIPTION AS CATEGORY_NAME,a.SEG_ID,se.DESCRIPTION AS SEGMENT_NAME,a.MAN_ID,m.DESCRIPTION AS MANUFACTURE_NAME,a.SUP_ID,S.NAME AS SUPPLIER_NAME,a.MODEL_NO,a.NOTES,a.LOGO_EXT,a.CREATED_BY FROM ASS_MODEL a INNER JOIN ASS_CLASSIFICATION ac ON a.CLASS_ID = ac.CLASS_ID INNER JOIN ASS_CATEGORY ca on a.CAT_ID = ca.CAT_ID    INNER JOIN ASS_SEGMENT se on a.SEG_ID = se.SEG_ID INNER JOIN ASS_MANUFACTURE m on a.MAN_ID=m.MANF_ID INNER JOIN ASS_SUPPLIER s on a.SUP_ID=s.SUPPLIER_ID where MODEL_ID = " + modelId + "";

                SqlCommand cmd = new SqlCommand("USP_ASS_MASTER_COMPONENT_lIST_edit", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Asset_code", peripheralCode);
                // cmd.Parameters.AddWithValue("@parent_code", assetDetailsCode);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new AssetDetailsDTO()
                           {
                               ASSET_IDFNO = dr.IsNull("ASSET_IDFNO") ? null : Convert.ToString(dr["ASSET_IDFNO"]),
                               MAIN_ASSET_CODE = dr.IsNull("MAIN_ASSET_CODE") ? null : Convert.ToString(dr["MAIN_ASSET_CODE"]),
                               PERIPHERAL_CODE = dr.IsNull("PERIPHERAL_CODE") ? null : Convert.ToString(dr["PERIPHERAL_CODE"]),
                               CHILD_ASSET = dr.IsNull("CHILD_ASSET") ? null : Convert.ToString(dr["CHILD_ASSET"]),
                               TYPE_ID = dr.IsNull("TYPE_ID") ? null : Convert.ToString(dr["TYPE_ID"]),
                               ASSET_CLASS = dr.IsNull("ASSET_CLASS") ? null : Convert.ToString(dr["ASSET_CLASS"]),
                               CLASS_NAME = dr.IsNull("CLASS_NAME") ? null : Convert.ToString(dr["CLASS_NAME"]),
                               CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
                               CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
                               SEG_ID = dr.IsNull("SEG_ID") ? null : Convert.ToString(dr["SEG_ID"]),
                               SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
                               MOD_ID = dr.IsNull("MOD_ID") ? null : Convert.ToString(dr["MOD_ID"]),
                               MODEL_NAME = dr.IsNull("MODEL_NAME") ? null : Convert.ToString(dr["MODEL_NAME"]),
                               MAN_ID = dr.IsNull("MAN_ID") ? null : Convert.ToString(dr["MAN_ID"]),
                               MANUFACTURE = dr.IsNull("MANUFACTURE") ? null : Convert.ToString(dr["MANUFACTURE"]),
                               ASSET_INTTAG = dr.IsNull("ASSET_INTTAG") ? null : Convert.ToString(dr["ASSET_INTTAG"]),
                               ASSET_EXTTAG = dr.IsNull("ASSET_EXTTAG") ? null : Convert.ToString(dr["ASSET_EXTTAG"]),
                               SERIAL_NO = dr.IsNull("SERIAL_NO") ? null : Convert.ToString(dr["SERIAL_NO"]),
                               SERV_TAG = dr.IsNull("SERV_TAG") ? null : Convert.ToString(dr["SERV_TAG"]),
                               ORD_NO = dr.IsNull("ORD_NO") ? null : Convert.ToString(dr["ORD_NO"]),
                               ORD_DATE = dr.IsNull("ORD_DATE") ? null : Convert.ToString(dr["ORD_DATE"]),
                               CHALLAN_NO = dr.IsNull("CHALLAN_NO") ? null : Convert.ToString(dr["CHALLAN_NO"]),
                               GRC_DATE = dr.IsNull("GRC_DATE") ? null : Convert.ToString(dr["GRC_DATE"]),
                               SUP_ID = dr.IsNull("SUP_ID") ? null : Convert.ToString(dr["SUP_ID"]),
                               SUPPLIER_NAME = dr.IsNull("SUPPLIER_NAME") ? null : Convert.ToString(dr["SUPPLIER_NAME"]),
                               P_COST = dr.IsNull("P_COST") ? null : Convert.ToString(dr["P_COST"]),
                               S_PRICE = dr.IsNull("S_PRICE") ? null : Convert.ToString(dr["S_PRICE"]),
                               TAX_AMT = dr.IsNull("TAX_AMT") ? null : Convert.ToString(dr["TAX_AMT"]),
                               DISCOUNT = dr.IsNull("DISCOUNT") ? null : Convert.ToString(dr["DISCOUNT"]),
                               LAND_VALUE = dr.IsNull("LAND_VALUE") ? null : Convert.ToString(dr["LAND_VALUE"]),
                               NET_AMT = dr.IsNull("NET_AMT") ? null : Convert.ToString(dr["NET_AMT"]),
                               DEP_RULEID = dr.IsNull("DEP_RULEID") ? null : Convert.ToString(dr["DEP_RULEID"]),
                               DEP_AMT = dr.IsNull("DEP_AMT") ? null : Convert.ToString(dr["DEP_AMT"]),
                               BOOK_VALUE = dr.IsNull("BOOK_VALUE") ? null : Convert.ToString(dr["BOOK_VALUE"]),
                               SALVAGE_VALUE = dr.IsNull("SALVAGE_VALUE") ? null : Convert.ToString(dr["SALVAGE_VALUE"]),
                               UDF_VALUE = dr.IsNull("UDF_VALUE") ? null : Convert.ToString(dr["UDF_VALUE"]),
                               WARRANTY = dr.IsNull("WARRANTY") ? null : Convert.ToString(dr["WARRANTY"]),
                               WAR_TYPE = dr.IsNull("WAR_TYPE") ? null : Convert.ToString(dr["WAR_TYPE"]),
                               ASS_EFFDATE = dr.IsNull("ASS_EFFDATE") ? null : Convert.ToString(dr["ASS_EFFDATE"]),
                               ASS_LIFE = dr.IsNull("ASS_LIFE") ? null : Convert.ToString(dr["ASS_LIFE"]),
                               LF_TYPE = dr.IsNull("LF_TYPE") ? null : Convert.ToString(dr["LF_TYPE"]),
                               ASS_DISPDATE = dr.IsNull("ASS_DISPDATE") ? null : Convert.ToString(dr["ASS_DISPDATE"]),
                               ASS_CONID = dr.IsNull("ASS_CONID") ? null : Convert.ToString(dr["ASS_CONID"]),
                               STATUS = dr.IsNull("STATUS") ? null : Convert.ToString(dr["STATUS"]),
                               BUNIT_ID = dr.IsNull("BUNIT_ID") ? null : Convert.ToString(dr["BUNIT_ID"]),
                               DEP_ID = dr.IsNull("DEP_ID") ? null : Convert.ToString(dr["DEP_ID"]),
                               USER_ID = dr.IsNull("USER_ID") ? null : Convert.ToString(dr["USER_ID"]),
                               P_CODE = dr.IsNull("P_CODE") ? null : Convert.ToString(dr["P_CODE"]),
                               CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                               // CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public List<AssetDetailsDTO> getAssetComponentMasterDetailsData(int assetCode)
        {
            List<AssetDetailsDTO> assetModelList = new List<AssetDetailsDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                if (assetCode != 0)
                {

                    //  string selectData = "  Select ASSET_IDFNO, di.ASSET_CODE,am.DESCRIPTION AS MAIN_ASSET,di.ASSET_CLASS,ASSET_INTTAG,ASSET_EXTTAG,SERIAL_NO,SERV_TAG,ORD_NO,ORD_DATE,CHALLAN_NO,GRC_DATE,di.P_COST,S_PRICE,TAX_AMT,DISCOUNT,LAND_VALUE,NET_AMT,DEP_RULEID,DEP_AMT,BOOK_VALUE,SALVAGE_VALUE,UDF_VALUE,WARRANTY,WAR_TYPE,ASS_EFFDATE,ASS_LIFE,LF_TYPE,ASS_DISPDATE,ASS_CONID,BUNIT_ID,DEP_ID,USER_ID,P_CODE,di.CREATED_BY from ASSET_DETAILSINFO di INNER JOIN ASSET_MASTER am on di.ASSET_CODE =am.ASSET_CODE  where di.ASSET_CODE = " + assetCode + "";

                    SqlCommand cmd = new SqlCommand("USP_ASS_MASTER_DETAILS_COMPONENT_LIST", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@parent_code", SqlDbType.Int).Value = assetCode;
                    // cmd.Parameters.AddWithValue("@typeID", 2);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    con.Open();
                    da.Fill(dt);
                    con.Close();
                    if (assetModelList != null)
                    {
                        assetModelList = (from DataRow dr in dt.Rows
                                          select new AssetDetailsDTO()
                                          {
                                              // ASSET_CODE = Convert.ToInt32(dr["ASSET_CODE"]),
                                              ASSET_IDFNO = dr.IsNull("ASSET_IDFNO") ? null : Convert.ToString(dr["ASSET_IDFNO"]),
                                              P_CODE = dr.IsNull("P_CODE") ? null : Convert.ToString(dr["P_CODE"]),
                                              MAIN_ASSET_CODE = dr.IsNull("MAIN_ASSET_CODE") ? null : Convert.ToString(dr["MAIN_ASSET_CODE"]),
                                              PERIPHERAL_CODE = dr.IsNull("PERIPHERAL_CODE") ? null : Convert.ToString(dr["PERIPHERAL_CODE"]),
                                              // PERIPHERAL_CODE = Convert.ToInt32(dr["PERIPHERAL_CODE"]),
                                              CHILD_ASSET = dr.IsNull("CHILD_ASSET") ? null : Convert.ToString(dr["CHILD_ASSET"]),
                                              ASSET_INTTAG = dr.IsNull("ASSET_INTTAG") ? null : Convert.ToString(dr["ASSET_INTTAG"]),
                                              ASSET_EXTTAG = dr.IsNull("ASSET_EXTTAG") ? null : Convert.ToString(dr["ASSET_EXTTAG"]),
                                              SERIAL_NO = dr.IsNull("SERIAL_NO") ? null : Convert.ToString(dr["SERIAL_NO"]),
                                              ORD_NO = dr.IsNull("ORD_NO") ? null : Convert.ToString(dr["ORD_NO"]),
                                              ORD_DATE = dr.IsNull("ORD_DATE") ? null : Convert.ToString(dr["ORD_DATE"]),
                                              GRC_DATE = dr.IsNull("GRC_DATE") ? null : Convert.ToString(dr["GRC_DATE"]),
                                              QUANTITY = dr.IsNull("QUANTITY") ? null : Convert.ToString(dr["QUANTITY"]),
                                              P_COST = dr.IsNull("P_COST") ? null : Convert.ToString(dr["P_COST"]),
                                              SUP_ID = dr.IsNull("SUP_ID") ? null : Convert.ToString(dr["SUP_ID"]),
                                              SUPPLIER_NAME = dr.IsNull("SUPPLIER_NAME") ? null : Convert.ToString(dr["SUPPLIER_NAME"]),
                                              CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                          }).ToList();
                    }

                }
            }
            return assetModelList;
        }
        public List<AssetDetailsDTO> getAssetMasterDetailsChildData(int assetDetailsCode)
        {
            List<AssetDetailsDTO> assetModelList = new List<AssetDetailsDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                if (assetDetailsCode != 0)
                {

                    //  string selectData = "  Select ASSET_IDFNO, di.ASSET_CODE,am.DESCRIPTION AS MAIN_ASSET,di.ASSET_CLASS,ASSET_INTTAG,ASSET_EXTTAG,SERIAL_NO,SERV_TAG,ORD_NO,ORD_DATE,CHALLAN_NO,GRC_DATE,di.P_COST,S_PRICE,TAX_AMT,DISCOUNT,LAND_VALUE,NET_AMT,DEP_RULEID,DEP_AMT,BOOK_VALUE,SALVAGE_VALUE,UDF_VALUE,WARRANTY,WAR_TYPE,ASS_EFFDATE,ASS_LIFE,LF_TYPE,ASS_DISPDATE,ASS_CONID,BUNIT_ID,DEP_ID,USER_ID,P_CODE,di.CREATED_BY from ASSET_DETAILSINFO di INNER JOIN ASSET_MASTER am on di.ASSET_CODE =am.ASSET_CODE  where di.ASSET_CODE = " + assetCode + "";

                    SqlCommand cmd = new SqlCommand("USP_ASS_MASTER_DETAILS_CHILD_VIEW", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@parent_code", SqlDbType.Int).Value = assetDetailsCode;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    con.Open();
                    da.Fill(dt);
                    con.Close();
                    if (assetModelList != null)
                    {
                        assetModelList = (from DataRow dr in dt.Rows
                                          select new AssetDetailsDTO()
                                          {
                                              ASSET_IDFNO = dr.IsNull("ASSET_IDFNO") ? null : Convert.ToString(dr["ASSET_IDFNO"]),
                                              // ASSET_CODE = dr.IsNull("ASSET_CODE") ? null : Convert.ToString(dr["ASSET_CODE"]),
                                              ASSET_CODE = Convert.ToInt32(dr["ASSET_CODE"]),
                                              MAIN_ASSET = dr.IsNull("MAIN_ASSET") ? null : Convert.ToString(dr["MAIN_ASSET"]),
                                              ASSET_INTTAG = dr.IsNull("ASSET_INTTAG") ? null : Convert.ToString(dr["ASSET_INTTAG"]),
                                              ASSET_EXTTAG = dr.IsNull("ASSET_EXTTAG") ? null : Convert.ToString(dr["ASSET_EXTTAG"]),
                                              SERIAL_NO = dr.IsNull("SERIAL_NO") ? null : Convert.ToString(dr["SERIAL_NO"]),
                                              ORD_NO = dr.IsNull("ORD_NO") ? null : Convert.ToString(dr["ORD_NO"]),
                                              ORD_DATE = dr.IsNull("ORD_DATE") ? null : Convert.ToString(dr["ORD_DATE"]),
                                              GRC_DATE = dr.IsNull("GRC_DATE") ? null : Convert.ToString(dr["GRC_DATE"]),
                                              P_COST = dr.IsNull("P_COST") ? null : Convert.ToString(dr["P_COST"]),
                                              SUP_ID = dr.IsNull("SUP_ID") ? null : Convert.ToString(dr["SUP_ID"]),
                                              SUPPLIER_NAME = dr.IsNull("SUPPLIER_NAME") ? null : Convert.ToString(dr["SUPPLIER_NAME"]),
                                              CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                          }).ToList();
                    }

                }
            }
            return assetModelList;
        }
        public AssetDetailsDTO Edit_Asset_Data(int assetDetailsCode)
        {
            AssetDetailsDTO Cat = new AssetDetailsDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (assetDetailsCode != 0)
            {

                //string selectData = "SELECT MODEL_ID, a.EXTERNAL_ID,a.MODEL_NAME, a.CLASS_ID, ac.DESCRIPTION AS CLASS_NAME,a.CAT_ID,ca.DESCRIPTION AS CATEGORY_NAME,a.SEG_ID,se.DESCRIPTION AS SEGMENT_NAME,a.MAN_ID,m.DESCRIPTION AS MANUFACTURE_NAME,a.SUP_ID,S.NAME AS SUPPLIER_NAME,a.MODEL_NO,a.NOTES,a.LOGO_EXT,a.CREATED_BY FROM ASS_MODEL a INNER JOIN ASS_CLASSIFICATION ac ON a.CLASS_ID = ac.CLASS_ID INNER JOIN ASS_CATEGORY ca on a.CAT_ID = ca.CAT_ID    INNER JOIN ASS_SEGMENT se on a.SEG_ID = se.SEG_ID INNER JOIN ASS_MANUFACTURE m on a.MAN_ID=m.MANF_ID INNER JOIN ASS_SUPPLIER s on a.SUP_ID=s.SUPPLIER_ID where MODEL_ID = " + modelId + "";

                SqlCommand cmd = new SqlCommand("USP_ASS_MASTER_DETAILS_CHILD_EDIT_VIEW", conn);
                cmd.CommandType = CommandType.StoredProcedure;
               // SqlCommand cmd = new SqlCommand(selectData, conn);
              //  cmd.Parameters.AddWithValue("@parent_code", SqlDbType.Int).Value = assetDetailsCode;
                cmd.Parameters.AddWithValue("@parent_code", assetDetailsCode);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new AssetDetailsDTO()
                           {
                               ASSET_IDFNO = dr.IsNull("ASSET_IDFNO") ? null : Convert.ToString(dr["ASSET_IDFNO"]),
                               MAIN_ASSET_CODE = dr.IsNull("MAIN_ASSET_CODE") ? null : Convert.ToString(dr["MAIN_ASSET_CODE"]),
                               ASSET_CODE = Convert.ToInt32(dr["ASSET_CODE"]),
                               MAIN_ASSET = dr.IsNull("MAIN_ASSET") ? null : Convert.ToString(dr["MAIN_ASSET"]),
                               TYPE_ID = dr.IsNull("TYPE_ID") ? null : Convert.ToString(dr["TYPE_ID"]),
                              // QUANTITY = dr.IsNull("QUANTITY") ? null : Convert.ToString(dr["QUANTITY"]),
                               ASSET_CLASS = dr.IsNull("ASSET_CLASS") ? null : Convert.ToString(dr["ASSET_CLASS"]),
                               CLASS_NAME = dr.IsNull("CLASS_NAME") ? null : Convert.ToString(dr["CLASS_NAME"]),
                               CAT_ID = dr.IsNull("CAT_ID") ? null : Convert.ToString(dr["CAT_ID"]),
                               CATEGORY_NAME = dr.IsNull("CATEGORY_NAME") ? null : Convert.ToString(dr["CATEGORY_NAME"]),
                               SEG_ID = dr.IsNull("SEG_ID") ? null : Convert.ToString(dr["SEG_ID"]),
                               SEGMENT_NAME = dr.IsNull("SEGMENT_NAME") ? null : Convert.ToString(dr["SEGMENT_NAME"]),
                               MOD_ID = dr.IsNull("MOD_ID") ? null : Convert.ToString(dr["MOD_ID"]),
                               MODEL_NAME = dr.IsNull("MODEL_NAME") ? null : Convert.ToString(dr["MODEL_NAME"]),
                               MAN_ID = dr.IsNull("MAN_ID") ? null : Convert.ToString(dr["MAN_ID"]),
                               MANUFACTURE = dr.IsNull("MANUFACTURE") ? null : Convert.ToString(dr["MANUFACTURE"]),
                               ASSET_INTTAG = dr.IsNull("ASSET_INTTAG") ? null : Convert.ToString(dr["ASSET_INTTAG"]),
                               ASSET_EXTTAG = dr.IsNull("ASSET_EXTTAG") ? null : Convert.ToString(dr["ASSET_EXTTAG"]),
                               SERIAL_NO = dr.IsNull("SERIAL_NO") ? null : Convert.ToString(dr["SERIAL_NO"]),
                               SERV_TAG = dr.IsNull("SERV_TAG") ? null : Convert.ToString(dr["SERV_TAG"]),
                               ORD_NO = dr.IsNull("ORD_NO") ? null : Convert.ToString(dr["ORD_NO"]),
                               ORD_DATE = dr.IsNull("ORD_DATE") ? null : Convert.ToString(dr["ORD_DATE"]),
                               CHALLAN_NO = dr.IsNull("CHALLAN_NO") ? null : Convert.ToString(dr["CHALLAN_NO"]),
                               GRC_DATE = dr.IsNull("GRC_DATE") ? null : Convert.ToString(dr["GRC_DATE"]),
                               SUP_ID = dr.IsNull("SUP_ID") ? null : Convert.ToString(dr["SUP_ID"]),
                               SUPPLIER_NAME = dr.IsNull("SUPPLIER_NAME") ? null : Convert.ToString(dr["SUPPLIER_NAME"]),
                               P_COST = dr.IsNull("P_COST") ? null : Convert.ToString(dr["P_COST"]),
                               S_PRICE = dr.IsNull("S_PRICE") ? null : Convert.ToString(dr["S_PRICE"]),
                               TAX_AMT = dr.IsNull("TAX_AMT") ? null : Convert.ToString(dr["TAX_AMT"]),
                               DISCOUNT = dr.IsNull("DISCOUNT") ? null : Convert.ToString(dr["DISCOUNT"]),
                               LAND_VALUE = dr.IsNull("LAND_VALUE") ? null : Convert.ToString(dr["LAND_VALUE"]),
                               NET_AMT = dr.IsNull("NET_AMT") ? null : Convert.ToString(dr["NET_AMT"]),
                               DEP_RULEID = dr.IsNull("DEP_RULEID") ? null : Convert.ToString(dr["DEP_RULEID"]),
                               DEP_AMT = dr.IsNull("DEP_AMT") ? null : Convert.ToString(dr["DEP_AMT"]),
                               BOOK_VALUE = dr.IsNull("BOOK_VALUE") ? null : Convert.ToString(dr["BOOK_VALUE"]),
                               SALVAGE_VALUE = dr.IsNull("SALVAGE_VALUE") ? null : Convert.ToString(dr["SALVAGE_VALUE"]),
                               UDF_VALUE = dr.IsNull("UDF_VALUE") ? null : Convert.ToString(dr["UDF_VALUE"]),
                               WARRANTY = dr.IsNull("WARRANTY") ? null : Convert.ToString(dr["WARRANTY"]),
                               WAR_TYPE = dr.IsNull("WAR_TYPE") ? null : Convert.ToString(dr["WAR_TYPE"]),
                               ASS_EFFDATE = dr.IsNull("ASS_EFFDATE") ? null : Convert.ToString(dr["ASS_EFFDATE"]),
                               ASS_LIFE = dr.IsNull("ASS_LIFE") ? null : Convert.ToString(dr["ASS_LIFE"]),
                               LF_TYPE = dr.IsNull("LF_TYPE") ? null : Convert.ToString(dr["LF_TYPE"]),
                               ASS_DISPDATE = dr.IsNull("ASS_DISPDATE") ? null : Convert.ToString(dr["ASS_DISPDATE"]),
                               ASS_CONID = dr.IsNull("ASS_CONID") ? null : Convert.ToString(dr["ASS_CONID"]),
                               STATUS = dr.IsNull("STATUS") ? null : Convert.ToString(dr["STATUS"]),
                               BUNIT_ID = dr.IsNull("BUNIT_ID") ? null : Convert.ToString(dr["BUNIT_ID"]),
                               Organization_Name = dr.IsNull("Organization_Name") ? null : Convert.ToString(dr["Organization_Name"]),
                               DEP_ID = dr.IsNull("DEP_ID") ? null : Convert.ToString(dr["DEP_ID"]),
                               DEPT_NAME = dr.IsNull("DEPT_NAME") ? null : Convert.ToString(dr["DEPT_NAME"]),
                               USER_ID = dr.IsNull("USER_ID") ? null : Convert.ToString(dr["USER_ID"]),
                               P_CODE = dr.IsNull("P_CODE") ? null : Convert.ToString(dr["P_CODE"]),
                               CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                               // CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public DataTable GetOutletList()
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_Outlet_List", con);//@ART_CODE
                cmd.CommandType = CommandType.StoredProcedure;



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable UpdateAssetDetails(string idfId, string serial_No,string order_No, string Order_Date, string challan_No, string Receive_Date,
        string warranty,string warranty_Type,string Efective_Date,string Disposed_Date,string condition_Id, string department_Id, string outletSelect, string status, string user_Code,string userid)
        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SP_ASSET_DETAILSINFO", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdfID", idfId);
                //cmd.Parameters.AddWithValue("@asset_Code", asset);
                cmd.Parameters.AddWithValue("@serialNo", serial_No);
                cmd.Parameters.AddWithValue("@ordNo", order_No);
                cmd.Parameters.AddWithValue("@ordDate", Order_Date);
                cmd.Parameters.AddWithValue("@challanNo", challan_No);
                cmd.Parameters.AddWithValue("@grDate", Receive_Date);
                cmd.Parameters.AddWithValue("@warranty ", warranty);
                cmd.Parameters.AddWithValue("@warType", warranty_Type);
                cmd.Parameters.AddWithValue("@assEffDate", Efective_Date);
                cmd.Parameters.AddWithValue("@assDispdate", Disposed_Date);
                cmd.Parameters.AddWithValue("@assConId", condition_Id);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@bunitId", department_Id);
                cmd.Parameters.AddWithValue("@depId ", outletSelect);
                cmd.Parameters.AddWithValue("@userId", user_Code);
                //cmd.Parameters.AddWithValue("@pCode ", asset);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sT", 2);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public DataTable UpdateMasterPeripheral(string asset_Code, string extTag, string serialNo, string pCode, string userid
    )
        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SP_MASTER_PERIPHERAL_UPDATE", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@asset_Code", asset_Code);
                cmd.Parameters.AddWithValue("@extTag", extTag);
                cmd.Parameters.AddWithValue("@serialNo", serialNo);
                cmd.Parameters.AddWithValue("@pCode", pCode);
                cmd.Parameters.AddWithValue("@cBy", userid);
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
        public DataTable UpdatePeripheralDetails(string asset_Code, string extTag, string serialNo,  string userid
  )
        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SP_PERIPHERAL_MASTER_UPDATE", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@asset_Code", asset_Code);
                cmd.Parameters.AddWithValue("@extTag", extTag);
                cmd.Parameters.AddWithValue("@serialNo", serialNo);
                //cmd.Parameters.AddWithValue("@pCode", pCode);
                cmd.Parameters.AddWithValue("@cBy", userid);
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
        public DataTable SaveLocationDepartment(string outletSelect, string department_Id)

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_ASS_LOC_DEP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orgID", outletSelect);
                cmd.Parameters.AddWithValue("@depId", department_Id);
                 cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public DataTable Article_Sl_Check(string article_prefix)
        {
            //  List<Article_Sl_Check> Article_Sl_Check = new List<Article_Sl_Check>();


            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("USP_Article_Sl_Check", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@article_prefix", article_prefix);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }

        }

        public DataTable GetAreaList()
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_Area_List", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetReferenceList()
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_SYS_Employee_View", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        //public string GetInvoice_No(string _OutLetRegNo)
        //{
        //    long value = 0;
        //    string InvoiceNo = string.Empty;
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        if (conn.State == 0)
        //        {
        //            conn.Open();
        //        }


        //        SqlCommand cmd = new SqlCommand("SP_GETSERILANO", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@DOCTYPE", _OutLetRegNo);
        //        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
        //        adpt.Fill(dt);
        //        conn.Close();
        //        value = int.Parse(dt.Rows[0].ToString());
        //        return value;
               
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }


        //}
        public DataTable SaveProject(long projectID, string projectName, string projectType,string Start_Date,string areaName, string address, string phoneNumber, string space,string referenceName,string referenceContact, bool sTatus, string userid)

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_PROJECT_MASTER", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", projectID);
                cmd.Parameters.AddWithValue("@projectName", projectName);
                cmd.Parameters.AddWithValue("@projectType ", projectType);
                cmd.Parameters.AddWithValue("@start_date ", Start_Date);
                cmd.Parameters.AddWithValue("@areaId", areaName);
                cmd.Parameters.AddWithValue("@address", address);
               // cmd.Parameters.AddWithValue("@phnno", phoneNumber);
                cmd.Parameters.AddWithValue("@space", space);
                cmd.Parameters.AddWithValue("@refereneID ", referenceName);
                cmd.Parameters.AddWithValue("@refereneContact ", referenceContact);
                cmd.Parameters.AddWithValue("@sTatus ", sTatus);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ViewProjectDTO> GetProject()
        {
            List<ViewProjectDTO> assetProjectList = new List<ViewProjectDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_PROJECT_MASTER", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetProjectList != null)
                {
                    assetProjectList = (from DataRow dr in dt.Rows
                                            select new ViewProjectDTO()
                                            {
                                                Project_ID = Convert.ToInt32(dr["Project_ID"]),
                                                External_ID = dr.IsNull("External_ID") ? null : Convert.ToString(dr["External_ID"]),
                                                Project_Name = dr.IsNull("Project_Name") ? null : Convert.ToString(dr["Project_Name"]),
                                                Project_Type = dr.IsNull("Project_Type") ? null : Convert.ToString(dr["Project_Type"]),
                                                Start_Date = dr.IsNull("Start_Date") ? null : Convert.ToString(dr["Start_Date"]),
                                                Area_ID = dr.IsNull("Area_ID") ? null : Convert.ToString(dr["Area_ID"]),
                                                Area= dr.IsNull("Area") ? null : Convert.ToString(dr["Area"]),
                                                Address = dr.IsNull("Address") ? null : Convert.ToString(dr["Address"]),
                                                Space = dr.IsNull("Space") ? null : Convert.ToString(dr["Space"]),
                                                Reference_ID = dr.IsNull("Reference_ID") ? null : Convert.ToString(dr["Reference_ID"]),
                                                Reference_Name = dr.IsNull("Reference_Name") ? null : Convert.ToString(dr["Reference_Name"]),
                                                Reference_Contact = dr.IsNull("Reference_Contact") ? null : Convert.ToString(dr["Reference_Contact"]),
                                                Status  = dr.IsNull("Status") ? null : Convert.ToBoolean(dr["Status"]) == true ? "Active" : "InActive",
                                                Created_By  = Convert.ToBoolean(dr["Created_By"])
                                            }).ToList();
                }

            }

            return assetProjectList;
        }
        public ViewProjectDTO getProjectData(int projectId)
        {
            ViewProjectDTO Cat = new ViewProjectDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (projectId != 0)
            {

                string selectData = "select Project_ID,External_ID,Project_Name,Project_Type,Start_Date,Area_ID,AR.Area, Address,Space,Reference_ID,EM.Name AS Reference_Name,Reference_Contact,PM.Status,PM.Created_By from PROJECT_MASTER PM INNER JOIN AREAMASTER AR ON PM.Area_ID=AR.AreaID INNER JOIN EMPLOYEE_MASTER EM ON PM.Reference_ID=EM.EMP_ID where Project_ID = " + projectId + "";


                SqlCommand cmd = new SqlCommand(selectData, conn);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ViewProjectDTO()
                           {
                               Project_ID = Convert.ToInt32(dr["Project_ID"]),
                               External_ID = dr.IsNull("External_ID") ? null : Convert.ToString(dr["External_ID"]),
                               Project_Name = dr.IsNull("Project_Name") ? null : Convert.ToString(dr["Project_Name"]),
                               Project_Type = dr.IsNull("Project_Type") ? null : Convert.ToString(dr["Project_Type"]),
                               Start_Date = dr.IsNull("Start_Date") ? null : Convert.ToString(dr["Start_Date"]),
                               Area_ID = dr.IsNull("Area_ID") ? null : Convert.ToString(dr["Area_ID"]),
                               Area = dr.IsNull("Area") ? null : Convert.ToString(dr["Area"]),
                               Address = dr.IsNull("Address") ? null : Convert.ToString(dr["Address"]),
                              // Phone = dr.IsNull("Phone") ? null : Convert.ToString(dr["Phone"]),
                               Space = dr.IsNull("Space") ? null : Convert.ToString(dr["Space"]),
                               Reference_ID = dr.IsNull("Reference_ID") ? null : Convert.ToString(dr["Reference_ID"]),
                               Reference_Name = dr.IsNull("Reference_Name") ? null : Convert.ToString(dr["Reference_Name"]),
                               Reference_Contact = dr.IsNull("Reference_Contact") ? null : Convert.ToString(dr["Reference_Contact"]),
                               Status = dr.IsNull("Status") ? null : Convert.ToBoolean(dr["Status"]) == true ? "Active" : "InActive",

                           }).FirstOrDefault();
                }


            }
            return Cat;
        }

        public DataTable UpdateProject(string projectID, string projectName, string projectType, string Start_Date, string areaName, string address, string phoneNumber, string space, string referenceName, string referenceContact, bool sTatus, string userid)

        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SP_PROJECT_MASTER", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@eID", projectID);
                cmd.Parameters.AddWithValue("@projectName", projectName);
                cmd.Parameters.AddWithValue("@projectType ", projectType);
                cmd.Parameters.AddWithValue("@start_date ", Start_Date);
                cmd.Parameters.AddWithValue("@areaId", areaName);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@phnno", phoneNumber);
                cmd.Parameters.AddWithValue("@space", space);
                cmd.Parameters.AddWithValue("@refereneID ", referenceName);
                cmd.Parameters.AddWithValue("@refereneContact ", referenceContact);
                cmd.Parameters.AddWithValue("@sTatus ", sTatus);
                cmd.Parameters.AddWithValue("@cBy", userid);
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
        public DataTable SaveUnit(string unitId, string ProjectList, string unitName, string address, string space,string spaceUnit, string unitType, string remarks,bool sTatus, string userid)

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_RENT_UNIT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", unitId);
                cmd.Parameters.AddWithValue("@projectID", ProjectList);
                cmd.Parameters.AddWithValue("@dEsc", unitName);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@space", space);
                cmd.Parameters.AddWithValue("@spaceUnit", spaceUnit);
                cmd.Parameters.AddWithValue("@unitType", unitType);
                cmd.Parameters.AddWithValue("@remarks", remarks);
                cmd.Parameters.AddWithValue("@sTatus ", sTatus);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ViewRentUnitDTO> GetUnit()
        {
            List<ViewRentUnitDTO> rentUnitList = new List<ViewRentUnitDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_RENT_UNIT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Project_ID", ProjectList);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (rentUnitList != null)
                {
                    rentUnitList = (from DataRow dr in dt.Rows
                                        select new ViewRentUnitDTO()
                                        {
                                            UNIT_ID = Convert.ToInt32(dr["UNIT_ID"]),
                                            PROJECT_ID = dr.IsNull("PROJECT_ID") ? null : Convert.ToString(dr["PROJECT_ID"]),
                                            Project_Name = dr.IsNull("Project_Name") ? null : Convert.ToString(dr["Project_Name"]),
                                            EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                                            UNIT_NAME = dr.IsNull("UNIT_NAME") ? null : Convert.ToString(dr["UNIT_NAME"]),
                                            ADDRESS = dr.IsNull("ADDRESS") ? null : Convert.ToString(dr["ADDRESS"]),
                                            SPACE = dr.IsNull("SPACE") ? null : Convert.ToString(dr["SPACE"]),
                                            SPACE_UNIT = dr.IsNull("SPACE_UNIT") ? null : Convert.ToString(dr["SPACE_UNIT"]),
                                            UNIT_TYPE = dr.IsNull("UNIT_TYPE") ? null : Convert.ToString(dr["UNIT_TYPE"]),
                                            REMARKS = dr.IsNull("REMARKS") ? null : Convert.ToString(dr["REMARKS"]),
                                            STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
                                            CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                        }).ToList();
                }

            }

            return rentUnitList;
        }
        public ViewRentUnitDTO getUnitData(int unitId)
        {
            ViewRentUnitDTO Cat = new ViewRentUnitDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (unitId != 0)
            {

                string selectData = " SELECT UNIT_ID,RU.PROJECT_ID,PM.Project_Name, RU.EXTERNAL_ID, UNIT_NAME,RU.ADDRESS,RU.SPACE,SPACE_UNIT,UNIT_TYPE,REMARKS,RU.STATUS,RU.CREATED_BY FROM RENT_UNIT RU INNER JOIN PROJECT_MASTER PM on PM.Project_ID =RU.PROJECT_ID where UNIT_ID = " + unitId + "";


                SqlCommand cmd = new SqlCommand(selectData, conn);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ViewRentUnitDTO()
                           {
                               UNIT_ID = Convert.ToInt32(dr["UNIT_ID"]),
                               PROJECT_ID = dr.IsNull("PROJECT_ID") ? null : Convert.ToString(dr["PROJECT_ID"]),
                               Project_Name = dr.IsNull("Project_Name") ? null : Convert.ToString(dr["Project_Name"]),
                               EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                               UNIT_NAME = dr.IsNull("UNIT_NAME") ? null : Convert.ToString(dr["UNIT_NAME"]),
                               ADDRESS = dr.IsNull("ADDRESS") ? null : Convert.ToString(dr["ADDRESS"]),
                               SPACE = dr.IsNull("SPACE") ? null : Convert.ToString(dr["SPACE"]),
                               SPACE_UNIT = dr.IsNull("SPACE_UNIT") ? null : Convert.ToString(dr["SPACE_UNIT"]),
                               UNIT_TYPE = dr.IsNull("UNIT_TYPE") ? null : Convert.ToString(dr["UNIT_TYPE"]),
                               REMARKS = dr.IsNull("REMARKS") ? null : Convert.ToString(dr["REMARKS"]),
                               STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",

                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public DataTable updateUnit(string unitId, string ProjectList, string unitName, string address, string space, string spaceUnit, string unitType, string remarks, bool sTatus, string userid)

        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SP_RENT_UNIT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@eID", unitId);
                cmd.Parameters.AddWithValue("@projectID", ProjectList);
                cmd.Parameters.AddWithValue("@dEsc", unitName);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@space", space);
                cmd.Parameters.AddWithValue("@spaceUnit", spaceUnit);
                cmd.Parameters.AddWithValue("@unitType", unitType);
                cmd.Parameters.AddWithValue("@remarks", remarks);
                cmd.Parameters.AddWithValue("@sTatus ", sTatus);
                cmd.Parameters.AddWithValue("@cBy", userid);
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
        public DataTable SaveLandlord(string landlordId, string landlordName, string phone_1, string phone_2, string address, string email, int _instanceId, bool sTatus, string userid)

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_RENT_LANDLORD", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@landlordID", landlordId);
                cmd.Parameters.AddWithValue("@name", landlordName);
                cmd.Parameters.AddWithValue("@phone_1", phone_1);
                cmd.Parameters.AddWithValue("@phone_2", phone_2);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@instanceId", _instanceId);
                cmd.Parameters.AddWithValue("@sTatus ", sTatus);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ViewRentLandlordDTO> GetLandlord()
        {
            List<ViewRentLandlordDTO> rentUnitList = new List<ViewRentLandlordDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_RENT_LANDLORD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (rentUnitList != null)
                {
                    rentUnitList = (from DataRow dr in dt.Rows
                                    select new ViewRentLandlordDTO()
                                    {
                                        Landlord_ID = Convert.ToInt32(dr["Landlord_ID"]),
                                        Name = dr.IsNull("Name") ? null : Convert.ToString(dr["Name"]),
                                        Phone_1 = dr.IsNull("Phone_1") ? null : Convert.ToString(dr["Phone_1"]),
                                        Phone_2 = dr.IsNull("Phone_2") ? null : Convert.ToString(dr["Phone_2"]),
                                        Address = dr.IsNull("Address") ? null : Convert.ToString(dr["Address"]),
                                        Email = dr.IsNull("Email") ? null : Convert.ToString(dr["Email"]),
                                        Status = dr.IsNull("Status") ? null : Convert.ToBoolean(dr["Status"]) == true ? "Active" : "InActive",
                                        Created_By = Convert.ToBoolean(dr["Created_By"])
                                    }).ToList();
                }

            }

            return rentUnitList;
        }
        public ViewRentLandlordDTO getLandlordData(int landlordId)
        {
            ViewRentLandlordDTO Cat = new ViewRentLandlordDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (landlordId != 0)
            {

                string selectData = " SELECT Landlord_ID, Name, Phone_1, Phone_2,Address,Email,Status, Created_By FROM RENT_LANDLORD where Landlord_ID = " + landlordId + "";


                SqlCommand cmd = new SqlCommand(selectData, conn);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ViewRentLandlordDTO()
                           {
                               Landlord_ID = Convert.ToInt32(dr["Landlord_ID"]),
                               Name = dr.IsNull("Name") ? null : Convert.ToString(dr["Name"]),
                               Phone_1 = dr.IsNull("Phone_1") ? null : Convert.ToString(dr["Phone_1"]),
                               Phone_2 = dr.IsNull("Phone_2") ? null : Convert.ToString(dr["Phone_2"]),
                               Address = dr.IsNull("Address") ? null : Convert.ToString(dr["Address"]),
                               Email = dr.IsNull("Email") ? null : Convert.ToString(dr["Email"]),
                               Status = dr.IsNull("Status") ? null : Convert.ToBoolean(dr["Status"]) == true ? "Active" : "InActive",

                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public DataTable updateLandlord(string landlordId, string landlordName, string phone_1, string phone_2, string address, string email, int _instanceId, bool sTatus, string userid)

        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }


                SqlCommand cmd = new SqlCommand("SP_RENT_LANDLORD", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@landlordID", landlordId);
                cmd.Parameters.AddWithValue("@name", landlordName);
                cmd.Parameters.AddWithValue("@phone_1", phone_1);
                cmd.Parameters.AddWithValue("@phone_2", phone_2);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@instanceId", _instanceId);
                cmd.Parameters.AddWithValue("@sTatus ", sTatus);
                cmd.Parameters.AddWithValue("@cBy", userid);
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
        public DataTable GetRentProjectList()
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_PROJECTLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetRentLandlordList()
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_RENT_LANDLORDLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetUnitLandlordList(string _unitId)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_UNIT_WISE_LANDLORD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@unit_ID", _unitId);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetUnitList(string _projectId)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_RENT_UNITLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Project_ID", _projectId);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetAgreementist(string _unitId)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_RENT_AGREEMENTLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Unit_ID", _unitId);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable SaveAgreement(string agreementId, string ProjectList, string UnitList, string contractType, string start_Date_of_Agreement, string Tenor, string end_Date_of_Agreement, string advance_Amount, string rent_Pay,string monthlyRentTaxBased,
            string agrement_Hand_Over_Date, string actual_Hand_Over_Date,string rent_Count,string actual_Rent_Start_Date,string actual_Rent_End_Date,string actual_Advance_Start_Date,string advance_Adjustment_Amount,
            string notice_Period, string aIT_Paid_By, string increment_Type, string rent_Increment,string increment_Intervale,string payment_Term, int _instanceId, string Rent_Pay_Date,string remRent,string remTax, bool sTatus, string userid)

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_RENT_AGREEMENT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", agreementId);
                cmd.Parameters.AddWithValue("@projectID", ProjectList);
                cmd.Parameters.AddWithValue("@unitID ", UnitList);
                cmd.Parameters.AddWithValue("@contractType ", contractType);
                cmd.Parameters.AddWithValue("@startDateAgg", start_Date_of_Agreement);
                cmd.Parameters.AddWithValue("@tenor", Tenor);
                cmd.Parameters.AddWithValue("@endDateAgg", end_Date_of_Agreement);
                cmd.Parameters.AddWithValue("@advanceAmount", advance_Amount);
                cmd.Parameters.AddWithValue("@rentPay ", rent_Pay);
                cmd.Parameters.AddWithValue("@mRentTaxBase ", monthlyRentTaxBased);
                cmd.Parameters.AddWithValue("@aggHoDate ", agrement_Hand_Over_Date);
                cmd.Parameters.AddWithValue("@actHoDate", actual_Hand_Over_Date);
                cmd.Parameters.AddWithValue("@rentCount", rent_Count);
                cmd.Parameters.AddWithValue("@actRStartDate ", actual_Rent_Start_Date);
                cmd.Parameters.AddWithValue("@actREndDate ", actual_Rent_End_Date);
                cmd.Parameters.AddWithValue("@actAdvStartDate", actual_Advance_Start_Date);
                cmd.Parameters.AddWithValue("@advAdjustAmount", advance_Adjustment_Amount);
                //cmd.Parameters.AddWithValue("@balanceAdvance", balanceAdvance);
                cmd.Parameters.AddWithValue("@noticePriod", notice_Period);
                cmd.Parameters.AddWithValue("@aitPaid", aIT_Paid_By );
                cmd.Parameters.AddWithValue("@rentIncType  ", increment_Type);
                cmd.Parameters.AddWithValue("@rentIncPer  ", rent_Increment);
                cmd.Parameters.AddWithValue("@incInterval ", increment_Intervale);
                cmd.Parameters.AddWithValue("@paymentTerm ", payment_Term);
                cmd.Parameters.AddWithValue("@instanceId ", _instanceId);
                cmd.Parameters.AddWithValue("@rentPayDate ", Rent_Pay_Date);
                cmd.Parameters.AddWithValue("@bMRent ", remRent);
                cmd.Parameters.AddWithValue("@bMTax ", remTax);
                cmd.Parameters.AddWithValue("@sTatus ", sTatus);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ViewAgreementDTO> AgreementList()
      {
            List<ViewAgreementDTO> assetProjectList = new List<ViewAgreementDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_RENT_AGREEMENT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetProjectList != null)
                {
                    assetProjectList = (from DataRow dr in dt.Rows
                                        select new ViewAgreementDTO()
                                        {
                                            Agreement_ID = Convert.ToInt32(dr["Agreement_ID"]),
                                            External_ID = dr.IsNull("External_ID") ? null : Convert.ToString(dr["External_ID"]),
                                            Project_ID = dr.IsNull("Project_ID") ? null : Convert.ToString(dr["Project_ID"]),
                                            Project_Name = dr.IsNull("Project_Name") ? null : Convert.ToString(dr["Project_Name"]),
                                            Unit_ID = dr.IsNull("Unit_ID") ? null : Convert.ToString(dr["Unit_ID"]),
                                            UNIT_NAME = dr.IsNull("UNIT_NAME") ? null : Convert.ToString(dr["UNIT_NAME"]),
                                            Contract_Type = dr.IsNull("Contract_Type") ? null : Convert.ToString(dr["Contract_Type"]),
                                            Advnace_Amt = dr.IsNull("Advnace_Amt") ? null : Convert.ToString(dr["Advnace_Amt"]),
                                            Start_DT_Agg = dr.IsNull("Start_DT_Agg") ? null : Convert.ToString(dr["Start_DT_Agg"]),
                                            Tenor = dr.IsNull("Tenor") ? null : Convert.ToString(dr["Tenor"]),
                                            End_DT_Agg = dr.IsNull("End_DT_Agg") ? null : Convert.ToString(dr["End_DT_Agg"]),
                                            Rent_Pay = dr.IsNull("Rent_Pay") ? null : Convert.ToString(dr["Rent_Pay"]),
                                            M_Rent_Tax_Base = dr.IsNull("M_Rent_Tax_Base") ? null : Convert.ToString(dr["M_Rent_Tax_Base"]),
                                            Agg_HO_Date = dr.IsNull("Agg_HO_Date") ? null : Convert.ToString(dr["Agg_HO_Date"]),
                                            Act_HO_Date = dr.IsNull("Act_HO_Date") ? null : Convert.ToString(dr["Act_HO_Date"]),
                                            Rent_Count = dr.IsNull("Rent_Count") ? null : Convert.ToString(dr["Rent_Count"]),
                                            Act_RStrt_Date = dr.IsNull("Act_RStrt_Date") ? null : Convert.ToString(dr["Act_RStrt_Date"]),
                                            Act_REnd_Date = dr.IsNull("Act_REnd_Date") ? null : Convert.ToString(dr["Act_REnd_Date"]),
                                            Act_AdvSrt_Date = dr.IsNull("Act_AdvSrt_Date") ? null : Convert.ToString(dr["Act_AdvSrt_Date"]),
                                            Adv_Adjust_Amt = dr.IsNull("Adv_Adjust_Amt") ? null : Convert.ToString(dr["Adv_Adjust_Amt"]),
                                            Notice_Period = dr.IsNull("Notice_Period") ? null : Convert.ToString(dr["Notice_Period"]),
                                            AIT_Paid = dr.IsNull("AIT_Paid") ? null : Convert.ToString(dr["AIT_Paid"]),
                                            Rent_Inc_Perc = dr.IsNull("Rent_Inc_Perc") ? null : Convert.ToString(dr["Rent_Inc_Perc"]),
                                            Inc_Interval = dr.IsNull("Inc_Interval") ? null : Convert.ToString(dr["Inc_Interval"]),
                                            Payment_Terms = dr.IsNull("Payment_Terms") ? null : Convert.ToString(dr["Payment_Terms"]),
                                            Rent_Pay_Date = dr.IsNull("Rent_Pay_Date") ? null : Convert.ToString(dr["Rent_Pay_Date"]),
                                            B_M_Rent = dr.IsNull("B_M_Rent") ? null : Convert.ToString(dr["B_M_Rent"]),
                                            B_M_Tax = dr.IsNull("B_M_Tax") ? null : Convert.ToString(dr["B_M_Tax"]),
                                            Status = dr.IsNull("Status") ? null : Convert.ToBoolean(dr["Status"]) == true ? "Active" : "InActive",
                                            Created_By = Convert.ToBoolean(dr["Created_By"])
                                        }).ToList();
                }

            }

            return assetProjectList;
        }
        //public List<ViewAgreementDTO> NewAgreementList()
        //{
        //    List<ViewAgreementDTO> assetProjectList = new List<ViewAgreementDTO>();

        //    using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
        //    {
        //        SqlCommand cmd = new SqlCommand("USP_RENT_NEWAGREEMENT", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        con.Open();
        //        da.Fill(dt);
        //        con.Close();
        //        if (assetProjectList != null)
        //        {
        //            assetProjectList = (from DataRow dr in dt.Rows
        //                                select new ViewAgreementDTO()
        //                                {
        //                                    Agreement_ID = Convert.ToInt32(dr["Agreement_ID"]),
        //                                    External_ID = dr.IsNull("External_ID") ? null : Convert.ToString(dr["External_ID"]),
        //                                    Project_ID = dr.IsNull("Project_ID") ? null : Convert.ToString(dr["Project_ID"]),
        //                                    Project_Name = dr.IsNull("Project_Name") ? null : Convert.ToString(dr["Project_Name"]),
        //                                    Unit_ID = dr.IsNull("Unit_ID") ? null : Convert.ToString(dr["Unit_ID"]),
        //                                    UNIT_NAME = dr.IsNull("UNIT_NAME") ? null : Convert.ToString(dr["UNIT_NAME"]),
        //                                    Contract_Type = dr.IsNull("Contract_Type") ? null : Convert.ToString(dr["Contract_Type"]),
        //                                    Advnace_Amt = dr.IsNull("Advnace_Amt") ? null : Convert.ToString(dr["Advnace_Amt"]),
        //                                    Start_DT_Agg = dr.IsNull("Start_DT_Agg") ? null : Convert.ToString(dr["Start_DT_Agg"]),
        //                                    Tenor = dr.IsNull("Tenor") ? null : Convert.ToString(dr["Tenor"]),
        //                                    End_DT_Agg = dr.IsNull("End_DT_Agg") ? null : Convert.ToString(dr["End_DT_Agg"]),
        //                                    Rent_Pay = dr.IsNull("Rent_Pay") ? null : Convert.ToString(dr["Rent_Pay"]),
        //                                    M_Rent_Tax_Base = dr.IsNull("M_Rent_Tax_Base") ? null : Convert.ToString(dr["M_Rent_Tax_Base"]),
        //                                    Agg_HO_Date = dr.IsNull("Agg_HO_Date") ? null : Convert.ToString(dr["Agg_HO_Date"]),
        //                                    Act_HO_Date = dr.IsNull("Act_HO_Date") ? null : Convert.ToString(dr["Act_HO_Date"]),
        //                                    Rent_Count = dr.IsNull("Rent_Count") ? null : Convert.ToString(dr["Rent_Count"]),
        //                                    Act_RStrt_Date = dr.IsNull("Act_RStrt_Date") ? null : Convert.ToString(dr["Act_RStrt_Date"]),
        //                                    Act_REnd_Date = dr.IsNull("Act_REnd_Date") ? null : Convert.ToString(dr["Act_REnd_Date"]),
        //                                    Act_AdvSrt_Date = dr.IsNull("Act_AdvSrt_Date") ? null : Convert.ToString(dr["Act_AdvSrt_Date"]),
        //                                    Adv_Adjust_Amt = dr.IsNull("Adv_Adjust_Amt") ? null : Convert.ToString(dr["Adv_Adjust_Amt"]),
        //                                    Notice_Period = dr.IsNull("Notice_Period") ? null : Convert.ToString(dr["Notice_Period"]),
        //                                    AIT_Paid = dr.IsNull("AIT_Paid") ? null : Convert.ToString(dr["AIT_Paid"]),
        //                                    Rent_Inc_Perc = dr.IsNull("Rent_Inc_Perc") ? null : Convert.ToString(dr["Rent_Inc_Perc"]),
        //                                    Inc_Interval = dr.IsNull("Inc_Interval") ? null : Convert.ToString(dr["Inc_Interval"]),
        //                                    Payment_Terms = dr.IsNull("Payment_Terms") ? null : Convert.ToString(dr["Payment_Terms"]),
        //                                    Rent_Pay_Date = dr.IsNull("Rent_Pay_Date") ? null : Convert.ToString(dr["Rent_Pay_Date"]),
        //                                    B_M_Rent = dr.IsNull("B_M_Rent") ? null : Convert.ToString(dr["B_M_Rent"]),
        //                                    B_M_Tax = dr.IsNull("B_M_Tax") ? null : Convert.ToString(dr["B_M_Tax"]),
        //                                    Status = dr.IsNull("Status") ? null : Convert.ToBoolean(dr["Status"]) == true ? "Active" : "InActive",
        //                                    Created_By = Convert.ToBoolean(dr["Created_By"])
        //                                }).ToList();
        //        }

        //    }

        //    return assetProjectList;
        //}
        public ViewAgreementDTO getAgreementData(int agreementId)
        {
            ViewAgreementDTO Cat = new ViewAgreementDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (agreementId != 0)
            {

                string selectData = " SELECT Agreement_ID,RA.External_ID,RA.Project_ID,PM.Project_Name,RA.Unit_ID,RU.UNIT_NAME,Contract_Type,Advnace_Amt,convert(varchar(10), Start_DT_Agg, 120) Start_DT_Agg,Tenor, convert(varchar(10), End_DT_Agg, 120) End_DT_Agg, Rent_Pay,M_Rent_Tax_Base,convert(varchar(10), Agg_HO_Date, 120)Agg_HO_Date,convert(varchar(10), Act_HO_Date, 120)Act_HO_Date,Rent_Count,convert(varchar(10), Act_RStrt_Date, 120) Act_RStrt_Date,convert(varchar(10), Act_REnd_Date, 120)Act_REnd_Date,convert(varchar(10), Act_AdvSrt_Date, 120)Act_AdvSrt_Date,Adv_Adjust_Amt,Notice_Period,AIT_Paid,Rent_Inc_Perc,Inc_Interval,Payment_Terms,Rent_Pay_Date,B_M_Rent,B_M_Tax, RA.Status, RA.CREATED_BY FROM RENT_AGREEMENT RA INNER JOIN PROJECT_MASTER PM ON RA.Project_ID =PM.Project_ID INNER JOIN RENT_UNIT RU on RA.Unit_ID=RU.UNIT_ID  where RA.External_ID = " + agreementId + "";


                SqlCommand cmd = new SqlCommand(selectData, conn);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ViewAgreementDTO()
                           {
                               Agreement_ID = Convert.ToInt32(dr["Agreement_ID"]),
                               External_ID = dr.IsNull("External_ID") ? null : Convert.ToString(dr["External_ID"]),
                               Project_ID = dr.IsNull("Project_ID") ? null : Convert.ToString(dr["Project_ID"]),
                               Project_Name = dr.IsNull("Project_Name") ? null : Convert.ToString(dr["Project_Name"]),
                               Unit_ID = dr.IsNull("Unit_ID") ? null : Convert.ToString(dr["Unit_ID"]),
                               UNIT_NAME = dr.IsNull("UNIT_NAME") ? null : Convert.ToString(dr["UNIT_NAME"]),
                               Contract_Type = dr.IsNull("Contract_Type") ? null : Convert.ToString(dr["Contract_Type"]),
                               Advnace_Amt = dr.IsNull("Advnace_Amt") ? null : Convert.ToString(dr["Advnace_Amt"]),
                               Start_DT_Agg = dr.IsNull("Start_DT_Agg") ? null : Convert.ToString(dr["Start_DT_Agg"]),
                               Tenor = dr.IsNull("Tenor") ? null : Convert.ToString(dr["Tenor"]),
                               End_DT_Agg = dr.IsNull("End_DT_Agg") ? null : Convert.ToString(dr["End_DT_Agg"]),
                               Rent_Pay = dr.IsNull("Rent_Pay") ? null : Convert.ToString(dr["Rent_Pay"]),
                               M_Rent_Tax_Base = dr.IsNull("M_Rent_Tax_Base") ? null : Convert.ToString(dr["M_Rent_Tax_Base"]),
                               Agg_HO_Date = dr.IsNull("Agg_HO_Date") ? null : Convert.ToString(dr["Agg_HO_Date"]),
                               Act_HO_Date = dr.IsNull("Act_HO_Date") ? null : Convert.ToString(dr["Act_HO_Date"]),
                               Rent_Count = dr.IsNull("Rent_Count") ? null : Convert.ToString(dr["Rent_Count"]),
                               Act_RStrt_Date = dr.IsNull("Act_RStrt_Date") ? null : Convert.ToString(dr["Act_RStrt_Date"]),
                               Act_REnd_Date = dr.IsNull("Act_REnd_Date") ? null : Convert.ToString(dr["Act_REnd_Date"]),
                               Act_AdvSrt_Date = dr.IsNull("Act_AdvSrt_Date") ? null : Convert.ToString(dr["Act_AdvSrt_Date"]),
                               Adv_Adjust_Amt = dr.IsNull("Adv_Adjust_Amt") ? null : Convert.ToString(dr["Adv_Adjust_Amt"]),
                               Notice_Period = dr.IsNull("Notice_Period") ? null : Convert.ToString(dr["Notice_Period"]),
                               AIT_Paid = dr.IsNull("AIT_Paid") ? null : Convert.ToString(dr["AIT_Paid"]),
                               Rent_Inc_Perc = dr.IsNull("Rent_Inc_Perc") ? null : Convert.ToString(dr["Rent_Inc_Perc"]),
                               Inc_Interval = dr.IsNull("Inc_Interval") ? null : Convert.ToString(dr["Inc_Interval"]),
                               Payment_Terms = dr.IsNull("Payment_Terms") ? null : Convert.ToString(dr["Payment_Terms"]),
                               Rent_Pay_Date = dr.IsNull("Rent_Pay_Date") ? null : Convert.ToString(dr["Rent_Pay_Date"]),
                               B_M_Rent = dr.IsNull("B_M_Rent") ? null : Convert.ToString(dr["B_M_Rent"]),
                               B_M_Tax = dr.IsNull("B_M_Tax") ? null : Convert.ToString(dr["B_M_Tax"]),
                               Status = dr.IsNull("Status") ? null : Convert.ToBoolean(dr["Status"]) == true ? "Active" : "InActive",
                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public DataTable UpdateAgreement(string agreementId, string ProjectList, string UnitList, string contractType, string start_Date_of_Agreement, string Tenor, string end_Date_of_Agreement, string advance_Amount, string rent_Pay,string monthlyRentTaxBased,
            string agrement_Hand_Over_Date, string actual_Hand_Over_Date, string rent_Count, string actual_Rent_Start_Date, string actual_Rent_End_Date, string actual_Advance_Start_Date, string advance_Adjustment_Amount,
            string notice_Period, string aIT_Paid_By, string increment_Type,string rent_Increment, string increment_Intervale, string payment_Term, int _instanceId, string Rent_Pay_Date, string remRent, string remTax, bool sTatus, string userid)

        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }

                

                SqlCommand cmd = new SqlCommand("SP_RENT_AGREEMENT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", agreementId);
                cmd.Parameters.AddWithValue("@projectID", ProjectList);
                cmd.Parameters.AddWithValue("@unitID ", UnitList);
                cmd.Parameters.AddWithValue("@contractType ", contractType);
                cmd.Parameters.AddWithValue("@startDateAgg", start_Date_of_Agreement);
                cmd.Parameters.AddWithValue("@tenor", Tenor);
                cmd.Parameters.AddWithValue("@endDateAgg", end_Date_of_Agreement);
                cmd.Parameters.AddWithValue("@advanceAmount", advance_Amount);
                cmd.Parameters.AddWithValue("@rentPay ", rent_Pay);
                cmd.Parameters.AddWithValue("@mRentTaxBase ", monthlyRentTaxBased);
                cmd.Parameters.AddWithValue("@aggHoDate ", agrement_Hand_Over_Date);
                cmd.Parameters.AddWithValue("@actHoDate", actual_Hand_Over_Date);
                cmd.Parameters.AddWithValue("@rentCount", rent_Count);
                cmd.Parameters.AddWithValue("@actRStartDate ", actual_Rent_Start_Date);
                cmd.Parameters.AddWithValue("@actREndDate ", actual_Rent_End_Date);
                cmd.Parameters.AddWithValue("@actAdvStartDate", actual_Advance_Start_Date);
                cmd.Parameters.AddWithValue("@advAdjustAmount", advance_Adjustment_Amount);
                cmd.Parameters.AddWithValue("@noticePriod", notice_Period);
                cmd.Parameters.AddWithValue("@aitPaid", aIT_Paid_By);
                cmd.Parameters.AddWithValue("@rentIncType  ", increment_Type);
                cmd.Parameters.AddWithValue("@rentIncPer  ", rent_Increment);
                cmd.Parameters.AddWithValue("@incInterval ", increment_Intervale);
                cmd.Parameters.AddWithValue("@paymentTerm ", payment_Term);
                cmd.Parameters.AddWithValue("@instanceId ", _instanceId);
                cmd.Parameters.AddWithValue("@rentPayDate ", Rent_Pay_Date);
                cmd.Parameters.AddWithValue("@bMRent ", remRent);
                cmd.Parameters.AddWithValue("@bMTax ", remTax);
                cmd.Parameters.AddWithValue("@sTatus ", sTatus);
                cmd.Parameters.AddWithValue("@cBy", userid);
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
        public List<ViewRentUnitDTO> GetUnitView(int ProjectList)
        {
            List<ViewRentUnitDTO> rentUnitList = new List<ViewRentUnitDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_RENT_UNIT_VIEW", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Project_ID", ProjectList);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (rentUnitList != null)
                {
                    rentUnitList = (from DataRow dr in dt.Rows
                                    select new ViewRentUnitDTO()
                                    {
                                        UNIT_ID = Convert.ToInt32(dr["UNIT_ID"]),
                                        PROJECT_ID = dr.IsNull("PROJECT_ID") ? null : Convert.ToString(dr["PROJECT_ID"]),
                                        Project_Name = dr.IsNull("Project_Name") ? null : Convert.ToString(dr["Project_Name"]),
                                        EXTERNAL_ID = dr.IsNull("EXTERNAL_ID") ? null : Convert.ToString(dr["EXTERNAL_ID"]),
                                        UNIT_NAME = dr.IsNull("UNIT_NAME") ? null : Convert.ToString(dr["UNIT_NAME"]),
                                        ADDRESS = dr.IsNull("ADDRESS") ? null : Convert.ToString(dr["ADDRESS"]),
                                        SPACE = dr.IsNull("SPACE") ? null : Convert.ToString(dr["SPACE"]),
                                        SPACE_UNIT = dr.IsNull("SPACE_UNIT") ? null : Convert.ToString(dr["SPACE_UNIT"]),
                                        UNIT_TYPE = dr.IsNull("UNIT_TYPE") ? null : Convert.ToString(dr["UNIT_TYPE"]),
                                        REMARKS = dr.IsNull("REMARKS") ? null : Convert.ToString(dr["REMARKS"]),
                                        STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
                                        CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                    }).ToList();
                }

            }

            return rentUnitList;
        }

        public List<ViewAgreementDTO> GetUnitAgreementView(int unitId)
        {
            List<ViewAgreementDTO> assetProjectList = new List<ViewAgreementDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_RENT_UNITAGREEMENT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Unit_ID", unitId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetProjectList != null)
                {
                    assetProjectList = (from DataRow dr in dt.Rows
                                        select new ViewAgreementDTO()
                                        {
                                            Agreement_ID = Convert.ToInt32(dr["Agreement_ID"]),
                                            External_ID = dr.IsNull("External_ID") ? null : Convert.ToString(dr["External_ID"]),
                                            Project_ID = dr.IsNull("Project_ID") ? null : Convert.ToString(dr["Project_ID"]),
                                            Project_Name = dr.IsNull("Project_Name") ? null : Convert.ToString(dr["Project_Name"]),
                                            Unit_ID = dr.IsNull("Unit_ID") ? null : Convert.ToString(dr["Unit_ID"]),
                                            UNIT_NAME = dr.IsNull("UNIT_NAME") ? null : Convert.ToString(dr["UNIT_NAME"]),
                                            Contract_Type = dr.IsNull("Contract_Type") ? null : Convert.ToString(dr["Contract_Type"]),
                                            Advnace_Amt = dr.IsNull("Advnace_Amt") ? null : Convert.ToString(dr["Advnace_Amt"]),
                                            Start_DT_Agg = dr.IsNull("Start_DT_Agg") ? null : Convert.ToString(dr["Start_DT_Agg"]),
                                            Tenor = dr.IsNull("Tenor") ? null : Convert.ToString(dr["Tenor"]),
                                            End_DT_Agg = dr.IsNull("End_DT_Agg") ? null : Convert.ToString(dr["End_DT_Agg"]),
                                            Rent_Pay = dr.IsNull("Rent_Pay") ? null : Convert.ToString(dr["Rent_Pay"]),
                                            M_Rent_Tax_Base = dr.IsNull("M_Rent_Tax_Base") ? null : Convert.ToString(dr["M_Rent_Tax_Base"]),
                                            Agg_HO_Date = dr.IsNull("Agg_HO_Date") ? null : Convert.ToString(dr["Agg_HO_Date"]),
                                            Act_HO_Date = dr.IsNull("Act_HO_Date") ? null : Convert.ToString(dr["Act_HO_Date"]),
                                            Rent_Count = dr.IsNull("Rent_Count") ? null : Convert.ToString(dr["Rent_Count"]),
                                            Act_RStrt_Date = dr.IsNull("Act_RStrt_Date") ? null : Convert.ToString(dr["Act_RStrt_Date"]),
                                            Act_REnd_Date = dr.IsNull("Act_REnd_Date") ? null : Convert.ToString(dr["Act_REnd_Date"]),
                                            Act_AdvSrt_Date = dr.IsNull("Act_AdvSrt_Date") ? null : Convert.ToString(dr["Act_AdvSrt_Date"]),
                                            Adv_Adjust_Amt = dr.IsNull("Adv_Adjust_Amt") ? null : Convert.ToString(dr["Adv_Adjust_Amt"]),
                                            Notice_Period = dr.IsNull("Notice_Period") ? null : Convert.ToString(dr["Notice_Period"]),
                                            AIT_Paid = dr.IsNull("AIT_Paid") ? null : Convert.ToString(dr["AIT_Paid"]),
                                            Rent_Inc_Perc = dr.IsNull("Rent_Inc_Perc") ? null : Convert.ToString(dr["Rent_Inc_Perc"]),
                                            Inc_Interval = dr.IsNull("Inc_Interval") ? null : Convert.ToString(dr["Inc_Interval"]),
                                            Payment_Terms = dr.IsNull("Payment_Terms") ? null : Convert.ToString(dr["Payment_Terms"]),
                                            Rent_Pay_Date = dr.IsNull("Rent_Pay_Date") ? null : Convert.ToString(dr["Rent_Pay_Date"]),
                                            B_M_Rent = dr.IsNull("B_M_Rent") ? null : Convert.ToString(dr["B_M_Rent"]),
                                            B_M_Tax = dr.IsNull("B_M_Tax") ? null : Convert.ToString(dr["B_M_Tax"]),
                                            Status = dr.IsNull("Status") ? null : Convert.ToBoolean(dr["Status"]) == true ? "Active" : "InActive",
                                            Created_By = Convert.ToBoolean(dr["Created_By"])
                                        }).ToList();
                }

            }

            return assetProjectList;
        }
    
        public DataTable SaveRentShare(int lndShareId,int ProjectList, int UnitList, int LandlordList, int share, bool sTatus, string userid)

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                 SqlCommand cmd = new SqlCommand("SP_RENT_SHARE", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@landShareID", lndShareId);
                cmd.Parameters.AddWithValue("@projectID", ProjectList);
                cmd.Parameters.AddWithValue("@unitID", UnitList);
                cmd.Parameters.AddWithValue("@landID", LandlordList);
                cmd.Parameters.AddWithValue("@share", share);
                cmd.Parameters.AddWithValue("@sTatus ", sTatus);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ViewRentShareDTO> GetRentShare()
        {
            List<ViewRentShareDTO> rentUnitList = new List<ViewRentShareDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_RENT_SHARE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (rentUnitList != null)
                {
                    rentUnitList = (from DataRow dr in dt.Rows
                                    select new ViewRentShareDTO()
                                    {
                                        LND_SHAREID = Convert.ToInt32(dr["LND_SHAREID"]),
                                        LINE_ID = dr.IsNull("LINE_ID") ? null : Convert.ToString(dr["LINE_ID"]),
                                        PROJECT_ID = dr.IsNull("PROJECT_ID") ? null : Convert.ToString(dr["PROJECT_ID"]),
                                        Project_Name = dr.IsNull("Project_Name") ? null : Convert.ToString(dr["Project_Name"]),
                                        UNIT_ID = dr.IsNull("UNIT_ID") ? null : Convert.ToString(dr["UNIT_ID"]),
                                        UNIT_NAME = dr.IsNull("UNIT_NAME") ? null : Convert.ToString(dr["UNIT_NAME"]),
                                        LAND_ID = dr.IsNull("LAND_ID") ? null : Convert.ToString(dr["LAND_ID"]),
                                        LANDLORD_NAME = dr.IsNull("LANDLORD_NAME") ? null : Convert.ToString(dr["LANDLORD_NAME"]),
                                        SHARE = dr.IsNull("SHARE") ? null : Convert.ToString(dr["SHARE"]),
                                        STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
                                        CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                    }).ToList();
                }

            }

            return rentUnitList;
        }
        public ViewRentShareDTO getRentShareData(int landlordShareId)
        {
            ViewRentShareDTO Cat = new ViewRentShareDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (landlordShareId != 0)
            {

                string selectData = "SELECT LND_SHAREID,LINE_ID,RS.PROJECT_ID,PM.Project_Name,RS.UNIT_ID,RU.UNIT_NAME,RS.LAND_ID,RL.Name as LANDLORD_NAME, SHARE,RS.STATUS,RS.CREATED_BY FROM RENT_SHARE RS INNER JOIN PROJECT_MASTER PM ON RS.PROJECT_ID=PM.Project_ID INNER JOIN RENT_UNIT RU ON RS.UNIT_ID=RU.UNIT_ID INNER JOIN RENT_LANDLORD RL on RS.LAND_ID=RL.Landlord_ID where LND_SHAREID = " + landlordShareId + "";


                SqlCommand cmd = new SqlCommand(selectData, conn);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ViewRentShareDTO()
                           {
                               LND_SHAREID = Convert.ToInt32(dr["LND_SHAREID"]),
                               LINE_ID = dr.IsNull("LINE_ID") ? null : Convert.ToString(dr["LINE_ID"]),
                               PROJECT_ID = dr.IsNull("PROJECT_ID") ? null : Convert.ToString(dr["PROJECT_ID"]),
                               Project_Name = dr.IsNull("Project_Name") ? null : Convert.ToString(dr["Project_Name"]),
                               UNIT_ID = dr.IsNull("UNIT_ID") ? null : Convert.ToString(dr["UNIT_ID"]),
                               UNIT_NAME = dr.IsNull("UNIT_NAME") ? null : Convert.ToString(dr["UNIT_NAME"]),
                               LAND_ID = dr.IsNull("LAND_ID") ? null : Convert.ToString(dr["LAND_ID"]),
                               LANDLORD_NAME = dr.IsNull("LANDLORD_NAME") ? null : Convert.ToString(dr["LANDLORD_NAME"]),
                               SHARE = dr.IsNull("SHARE") ? null : Convert.ToString(dr["SHARE"]),
                               STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",

                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public DataTable updateRentShare(int LandShare_Id,int ProjectList, int UnitList, int LandlordList, int share, bool sTatus, string userid)

        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }


                SqlCommand cmd = new SqlCommand("SP_RENT_SHARE", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@landShareID", LandShare_Id);
                cmd.Parameters.AddWithValue("@projectID", ProjectList);
                cmd.Parameters.AddWithValue("@unitID", UnitList);
                cmd.Parameters.AddWithValue("@landID", LandlordList);
                cmd.Parameters.AddWithValue("@share", share);
                cmd.Parameters.AddWithValue("@sTatus ", sTatus);
                cmd.Parameters.AddWithValue("@cBy", userid);
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
        public DataTable SaveRentVat(string vatId, string name, string description, string vat_Start_Date, string vat_End_Date, string vat_Percentage, string remarks, bool sTatus, string userid)

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_RENT_VAT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                //  cmd.Parameters.AddWithValue("@vatID", landlordId);
                cmd.Parameters.AddWithValue("@vatID", vatId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@vStartDate", vat_Start_Date);
                cmd.Parameters.AddWithValue("@vEndDate", vat_End_Date);
                cmd.Parameters.AddWithValue("@vatPer", vat_Percentage);
                cmd.Parameters.AddWithValue("@remarks", remarks);
                cmd.Parameters.AddWithValue("@sTatus ", sTatus);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ViewRentVatDTO> GetRentVat()
        {
            List<ViewRentVatDTO> rentUnitList = new List<ViewRentVatDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_RENT_VAT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (rentUnitList != null)
                {
                    rentUnitList = (from DataRow dr in dt.Rows
                                    select new ViewRentVatDTO()
                                    {
                                        VAT_ID = Convert.ToInt32(dr["VAT_ID"]),
                                        NAME = dr.IsNull("NAME") ? null : Convert.ToString(dr["NAME"]),
                                        DESCRIPTION = dr.IsNull("DESCRIPTION") ? null : Convert.ToString(dr["DESCRIPTION"]),
                                        VSTART_DATE = dr.IsNull("VSTART_DATE") ? null : Convert.ToString(dr["VSTART_DATE"]),
                                        VEND_DATE = dr.IsNull("VEND_DATE") ? null : Convert.ToString(dr["VEND_DATE"]),
                                        VAT_PER = dr.IsNull("VAT_PER") ? null : Convert.ToString(dr["VAT_PER"]),
                                        REMARKS = dr.IsNull("REMARKS") ? null : Convert.ToString(dr["REMARKS"]),
                                        STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
                                        CREATE_BY = Convert.ToBoolean(dr["CREATE_BY"])
                                    }).ToList();
                }

            }

            return rentUnitList;
        }
        public ViewRentVatDTO getRentVatData(int vatId)
        {
            ViewRentVatDTO Cat = new ViewRentVatDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (vatId != 0)
            {

                string selectData = " SELECT VAT_ID, NAME, DESCRIPTION,convert(varchar(10), VSTART_DATE, 120)VSTART_DATE,convert(varchar(10), VEND_DATE, 120)VEND_DATE,VAT_PER,REMARKS,STATUS,CREATE_BY FROM RENT_VAT where VAT_ID = " + vatId + "";


                SqlCommand cmd = new SqlCommand(selectData, conn);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ViewRentVatDTO()
                           {
                                VAT_ID = Convert.ToInt32(dr["VAT_ID"]),
                                        NAME = dr.IsNull("NAME") ? null : Convert.ToString(dr["NAME"]),
                                        DESCRIPTION = dr.IsNull("DESCRIPTION") ? null : Convert.ToString(dr["DESCRIPTION"]),
                                        VSTART_DATE = dr.IsNull("VSTART_DATE") ? null : Convert.ToString(dr["VSTART_DATE"]),
                                        VEND_DATE = dr.IsNull("VEND_DATE") ? null : Convert.ToString(dr["VEND_DATE"]),
                                        VAT_PER = dr.IsNull("VAT_PER") ? null : Convert.ToString(dr["VAT_PER"]),
                                        REMARKS = dr.IsNull("REMARKS") ? null : Convert.ToString(dr["REMARKS"]),
                                        STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",

                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public DataTable updateRentVat(string vat_Id,string name, string description, string vat_Start_Date, string vat_End_Date, string vat_Percentage, string remarks, bool sTatus, string userid)

        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }


                SqlCommand cmd = new SqlCommand("SP_RENT_VAT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@vatID", vat_Id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@vStartDate", vat_Start_Date);
                cmd.Parameters.AddWithValue("@vEndDate", vat_End_Date);
                cmd.Parameters.AddWithValue("@vatPer", vat_Percentage);
                cmd.Parameters.AddWithValue("@remarks", remarks);
                cmd.Parameters.AddWithValue("@sTatus ", sTatus);
                cmd.Parameters.AddWithValue("@cBy", userid);
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
        public DataTable SaveRentAIT(string aitId,string name, string description, string ait_Start_Date, string ait_End_Date, string ait_Percentage, string remarks, bool sTatus, string userid)

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_RENT_AIT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                //  cmd.Parameters.AddWithValue("@vatID", landlordId);
                cmd.Parameters.AddWithValue("@aitID", aitId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@aStartDate", ait_Start_Date);
                cmd.Parameters.AddWithValue("@aEndDate", ait_End_Date);
                cmd.Parameters.AddWithValue("@aitPer", ait_Percentage);
                cmd.Parameters.AddWithValue("@remarks", remarks);
                cmd.Parameters.AddWithValue("@sTatus ", sTatus);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ViewRentAITDTO> GetRentAIT()
        {
            List<ViewRentAITDTO> rentUnitList = new List<ViewRentAITDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_RENT_AIT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (rentUnitList != null)
                {
                    rentUnitList = (from DataRow dr in dt.Rows
                                    select new ViewRentAITDTO()
                                    {
                                        AIT_ID = Convert.ToInt32(dr["AIT_ID"]),
                                        AIT_NAME = dr.IsNull("AIT_NAME") ? null : Convert.ToString(dr["AIT_NAME"]),
                                        AIT_DESCRIPTION = dr.IsNull("AIT_DESCRIPTION") ? null : Convert.ToString(dr["AIT_DESCRIPTION"]),
                                        ESTRT_DATE = dr.IsNull("ESTRT_DATE") ? null : Convert.ToString(dr["ESTRT_DATE"]),
                                        EEND_DATE = dr.IsNull("EEND_DATE") ? null : Convert.ToString(dr["EEND_DATE"]),
                                        AIT_PER = dr.IsNull("AIT_PER") ? null : Convert.ToString(dr["AIT_PER"]),
                                        REMARKS = dr.IsNull("REMARKS") ? null : Convert.ToString(dr["REMARKS"]),
                                        STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
                                        CREATE_BY = Convert.ToBoolean(dr["CREATE_BY"])
                                    }).ToList();
                }

            }

            return rentUnitList;
        }
        public ViewRentAITDTO getRentAITData(int AITId)
        {
            ViewRentAITDTO Cat = new ViewRentAITDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (AITId != 0)
            {

                string selectData = " SELECT AIT_ID, AIT_NAME, AIT_DESCRIPTION,convert(varchar(10), ESTRT_DATE, 120)ESTRT_DATE,convert(varchar(10), EEND_DATE, 120)EEND_DATE,AIT_PER,REMARKS,STATUS,CREATE_BY FROM RENT_AIT where AIT_ID = " + AITId + "";


                SqlCommand cmd = new SqlCommand(selectData, conn);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ViewRentAITDTO()
                           {
                               AIT_ID = Convert.ToInt32(dr["AIT_ID"]),
                               AIT_NAME = dr.IsNull("AIT_NAME") ? null : Convert.ToString(dr["AIT_NAME"]),
                               AIT_DESCRIPTION = dr.IsNull("AIT_DESCRIPTION") ? null : Convert.ToString(dr["AIT_DESCRIPTION"]),
                               ESTRT_DATE = dr.IsNull("ESTRT_DATE") ? null : Convert.ToString(dr["ESTRT_DATE"]),
                               EEND_DATE = dr.IsNull("EEND_DATE") ? null : Convert.ToString(dr["EEND_DATE"]),
                               AIT_PER = dr.IsNull("AIT_PER") ? null : Convert.ToString(dr["AIT_PER"]),
                               REMARKS = dr.IsNull("REMARKS") ? null : Convert.ToString(dr["REMARKS"]),
                               STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public DataTable updateRentAIT(string art_id,string name, string description, string ait_Start_Date, string ait_End_Date, string ait_Percentage, string remarks, bool sTatus, string userid)

        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }


                SqlCommand cmd = new SqlCommand("SP_RENT_AIT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                //  cmd.Parameters.AddWithValue("@vatID", landlordId);
                cmd.Parameters.AddWithValue("@aitID", art_id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@aStartDate", ait_Start_Date);
                cmd.Parameters.AddWithValue("@aEndDate", ait_End_Date);
                cmd.Parameters.AddWithValue("@aitPer", ait_Percentage);
                cmd.Parameters.AddWithValue("@remarks", remarks);
                cmd.Parameters.AddWithValue("@sTatus ", sTatus);
                cmd.Parameters.AddWithValue("@cBy", userid);
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
        public DataTable SaveRentIntervale(string ProjectList, string UnitList, string AgreementList, string intervale_Count, string intervale_Start_Date, string intervale_End_Date, string intervale_Amount, string userid)

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_RENT_INTV", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                //  cmd.Parameters.AddWithValue("@vatID", landlordId);
                cmd.Parameters.AddWithValue("@projectID", ProjectList);
                cmd.Parameters.AddWithValue("@unitID", UnitList);
                cmd.Parameters.AddWithValue("@agreementID", AgreementList);
                cmd.Parameters.AddWithValue("@intCnt", intervale_Count);
                cmd.Parameters.AddWithValue("@intStartDate", intervale_Start_Date);
                cmd.Parameters.AddWithValue("@intEndDate", intervale_End_Date);
                cmd.Parameters.AddWithValue("@intAmt ", intervale_Amount);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            } 
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable SaveRentIncrement(string agreementId, string ProjectList, string UnitList, string StartDateList, string EndDateList, string Increment_AmountList,string Increment_VatList, string  userid, string sTatus)
        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_RENT_INCREMENT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@agreementID", agreementId);
                // cmd.Parameters.AddWithValue("@supID", sID);
                cmd.Parameters.AddWithValue("@projectID", ProjectList);
                cmd.Parameters.AddWithValue("@unitID", UnitList);
                cmd.Parameters.AddWithValue("@incStartDate", StartDateList);
                cmd.Parameters.AddWithValue("@incEndDate", EndDateList);
                cmd.Parameters.AddWithValue("@incAmount", Increment_AmountList);
                cmd.Parameters.AddWithValue("@incVat", Increment_VatList);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //public ViewRentIncrementDTO getAgreementIncrementData(int agreementId)
        //{
        //    ViewRentIncrementDTO Cat = new ViewRentIncrementDTO();


        //    if (conn.State == 0)
        //    {
        //        conn.Open();
        //    }

        //    if (agreementId != 0)
        //    {

        //        string selectData = "SELECT Increment_ID,Agreement_ID,RI.Project_ID,PM.Project_Name, RI.Unit_ID, Inc_RStrt_Date,Inc_REnd_Date,RI.Inc_Amount,RI.STATUS,RI.CREATED_BY FROM RENT_INCREMENT RI INNER JOIN PROJECT_MASTER PM on PM.Project_ID =RI.PROJECT_ID where RI.Agreement_ID= " + agreementId + "";


        //        SqlCommand cmd = new SqlCommand(selectData, conn);



        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();

        //        da.Fill(dt);

        //        if (Cat != null)
        //        {
        //            Cat = (from DataRow dr in dt.Rows
        //                   select new ViewRentIncrementDTO()
        //                   {
        //                       Increment_ID = Convert.ToInt32(dr["Increment_ID"]),
        //                       Agreement_ID = dr.IsNull("Agreement_ID") ? null : Convert.ToString(dr["Agreement_ID"]),
        //                       Project_ID = dr.IsNull("Project_ID") ? null : Convert.ToString(dr["Project_ID"]),
        //                       Project_Name = dr.IsNull("Project_Name") ? null : Convert.ToString(dr["Project_Name"]),
        //                       Unit_ID = dr.IsNull("Unit_ID") ? null : Convert.ToString(dr["Unit_ID"]),
        //                       Inc_RStrt_Date = dr.IsNull("Inc_RStrt_Date") ? null : Convert.ToString(dr["Inc_RStrt_Date"]),
        //                       Inc_REnd_Date = dr.IsNull("Inc_REnd_Date") ? null : Convert.ToString(dr["Inc_REnd_Date"]),
        //                       Inc_Amount = dr.IsNull("Inc_Amount") ? null : Convert.ToString(dr["Inc_Amount"]),
        //                       STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
        //                   }).ToList();
        //        }


        //    }
        //    return Cat;
        //}

        public List<ViewRentIncrementDTO> getAgreementIncrementData(int agreementId)
        {
            List<ViewRentIncrementDTO> rentUnitList = new List<ViewRentIncrementDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_RENT_INCREMENT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@agreement_ID", agreementId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (rentUnitList != null)
                {
                    rentUnitList = (from DataRow dr in dt.Rows
                                    select new ViewRentIncrementDTO()
                                    {
                                        Increment_ID = Convert.ToInt32(dr["Increment_ID"]),
                                        Agreement_ID = dr.IsNull("Agreement_ID") ? null : Convert.ToString(dr["Agreement_ID"]),
                                        Project_ID = dr.IsNull("Project_ID") ? null : Convert.ToString(dr["Project_ID"]),
                                        Project_Name = dr.IsNull("Project_Name") ? null : Convert.ToString(dr["Project_Name"]),
                                        Unit_ID = dr.IsNull("Unit_ID") ? null : Convert.ToString(dr["Unit_ID"]),
                                        Inc_RStrt_Date = dr.IsNull("Inc_RStrt_Date") ? null : Convert.ToString(dr["Inc_RStrt_Date"]),
                                        Inc_REnd_Date = dr.IsNull("Inc_REnd_Date") ? null : Convert.ToString(dr["Inc_REnd_Date"]),
                                        Inc_Amount = dr.IsNull("Inc_Amount") ? null : Convert.ToString(dr["Inc_Amount"]),
                                        STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
                                        CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                    }).ToList();
                }

            }

            return rentUnitList;
        }

        public List<ViewRentDetailsDTO> Get_Agreement_Details(int agreementId)
      {
            List<ViewRentDetailsDTO> assetProjectList = new List<ViewRentDetailsDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_RENT_INCREMENT_DETAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@agreement_ID", agreementId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetProjectList != null)
                {
                    assetProjectList = (from DataRow dr in dt.Rows
                                        select new ViewRentDetailsDTO()
                                        {
//Agreement_ID = Convert.ToInt32(dr["Agreement_ID"]),
                                            year = dr.IsNull("year") ? null : Convert.ToString(dr["year"]),
                                            month = dr.IsNull("month") ? null : Convert.ToString(dr["month"]),
                                            Inc_Amount = dr.IsNull("Inc_Amount") ? null : Convert.ToString(dr["Inc_Amount"]),
                                            Inc_Vat = dr.IsNull("Inc_Vat") ? null : Convert.ToString(dr["Inc_Vat"]),
                                        }).ToList();
                }

            }

            return assetProjectList;
        }

        public List<ViewRentPaymentsDTO> Get_Payment_Details(string first_Day_Of_Month, string end_Day_Of_Month)
        {
            List<ViewRentPaymentsDTO> assetProjectList = new List<ViewRentPaymentsDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_RENT_PAYMENT_GENERTAE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@s_date", first_Day_Of_Month);
                cmd.Parameters.AddWithValue("@e_date", end_Day_Of_Month);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetProjectList != null)
                {
                    assetProjectList = (from DataRow dr in dt.Rows
                                        select new ViewRentPaymentsDTO()
                                        {
                                            //Agreement_ID = Convert.ToInt32(dr["Agreement_ID"]),
                                            Doc_Date = dr.IsNull("Doc_Date") ? null : Convert.ToString(dr["Doc_Date"]),
                                            rent_details_id = dr.IsNull("rent_details_id") ? null : Convert.ToString(dr["rent_details_id"]),
                                            Expec_R_P_Date = dr.IsNull("Expec_R_P_Date") ? null : Convert.ToString(dr["Expec_R_P_Date"]),
                                            Project_ID = dr.IsNull("Project_ID") ? null : Convert.ToString(dr["Project_ID"]),
                                            Project_Name = dr.IsNull("Project_Name") ? null : Convert.ToString(dr["Project_Name"]),
                                            Unit_ID = dr.IsNull("Unit_ID") ? null : Convert.ToString(dr["Unit_ID"]),
                                            UNIT_NAME = dr.IsNull("UNIT_NAME") ? null : Convert.ToString(dr["UNIT_NAME"]),
                                            // Agreement_ID = dr.IsNull("Agreement_ID") ? null : Convert.ToString(dr["Agreement_ID"]),
                                            External_ID = dr.IsNull("External_ID") ? null : Convert.ToString(dr["External_ID"]),
                                            Advnace_Amt = dr.IsNull("Advnace_Amt") ? null : Convert.ToString(dr["Advnace_Amt"]),
                                            balance = dr.IsNull("balance") ? null : Convert.ToString(dr["balance"]),
                                            ADV = dr.IsNull("ADV") ? null : Convert.ToString(dr["ADV"]),
                                            M_rent = dr.IsNull("M_rent") ? null : Convert.ToString(dr["M_rent"]),
                                            M_Rent_Tax_Base = dr.IsNull("M_Rent_Tax_Base") ? null : Convert.ToString(dr["M_Rent_Tax_Base"]),
                                            balance_Advance = dr.IsNull("balance_Advance") ? null : Convert.ToString(dr["balance_Advance"]),
                                            AIT_Paid = dr.IsNull("AIT_Paid") ? null : Convert.ToString(dr["AIT_Paid"]),
                                            VT = dr.IsNull("VT") ? null : Convert.ToString(dr["VT"]),
                                            AT = dr.IsNull("AT") ? null : Convert.ToString(dr["AT"]),
                                            VT_Amt = dr.IsNull("VT_Amt") ? null : Convert.ToString(dr["VT_Amt"]),
                                            AIT_Amt = dr.IsNull("AIT_Amt") ? null : Convert.ToString(dr["AIT_Amt"]),
                                            R_Disc = dr.IsNull("R_Disc") ? null : Convert.ToString(dr["R_Disc"]),
                                            AIT_Disc = dr.IsNull("AIT_Disc") ? null : Convert.ToString(dr["AIT_Disc"]),
                                            VAT_Disc = dr.IsNull("VAT_Disc") ? null : Convert.ToString(dr["VAT_Disc"]),
                                            ADV_Disc = dr.IsNull("ADV_Disc") ? null : Convert.ToString(dr["ADV_Disc"]),
                                        }).ToList();
                }

            }

            return assetProjectList;
        }

        public DataTable SaveRentDetails(int agreementId, string ProjectList, string UnitList, string ExpecRentPayDateList, string actual_Rent_Pay_Date,string advance_Amount,
            string Increment_AmountList, string monthly_advance_adjust, string Increment_VatList,string monthly_AIT_agree,string monthly_AIT_not_agree,string VAT, string userid, string sTatus)
        
        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_RENT_DETAILS", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@agreementID", agreementId);
                cmd.Parameters.AddWithValue("@projectID", ProjectList);
                cmd.Parameters.AddWithValue("@unitID", UnitList);
                cmd.Parameters.AddWithValue("@expec_R_P_Date", ExpecRentPayDateList);
                cmd.Parameters.AddWithValue("@actual_R_P_Date", actual_Rent_Pay_Date);
                cmd.Parameters.AddWithValue("@advanceInitialy", advance_Amount);
                cmd.Parameters.AddWithValue("@mRent", Increment_AmountList);
                cmd.Parameters.AddWithValue("@mAdvaAdjust", monthly_advance_adjust);
                cmd.Parameters.AddWithValue("@mRentTaxBase", Increment_VatList);
                cmd.Parameters.AddWithValue("@mAITAgree", monthly_AIT_agree);
                cmd.Parameters.AddWithValue("@mAITNotAgree", monthly_AIT_not_agree);
                cmd.Parameters.AddWithValue("@VAT", VAT);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable SaveRentPayee(int rentPayee_Id, int ProjectList, int UnitList, int LandlordList, string payee_Name,string relation, string cash,
            string mobile_Banking_Type,string mobile_Banking_Amount,string BankName_0,string BankDistrict_0,string BranchName_0,
            string routing_Number,string account_Number,string amount,  bool sTatus, string userid)

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_RENT_PAYEE", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rentPayeeID", rentPayee_Id);
                cmd.Parameters.AddWithValue("@projectID", ProjectList);
                cmd.Parameters.AddWithValue("@unitID", UnitList);
                cmd.Parameters.AddWithValue("@landID", LandlordList);
                cmd.Parameters.AddWithValue("@payeeName", payee_Name);
                cmd.Parameters.AddWithValue("@relation", relation);
                cmd.Parameters.AddWithValue("@cash", cash);
                cmd.Parameters.AddWithValue("@mBank", mobile_Banking_Type);
                cmd.Parameters.AddWithValue("@mBankAmount", mobile_Banking_Amount);
                cmd.Parameters.AddWithValue("@bankId", BankName_0);
                cmd.Parameters.AddWithValue("@district", BankDistrict_0);
                cmd.Parameters.AddWithValue("@branch", BranchName_0);
                cmd.Parameters.AddWithValue("@rouNum", routing_Number);
                cmd.Parameters.AddWithValue("@accNum", account_Number);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@sTatus ", sTatus);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ViewRentPayeeDTO> GetRentPayee()
        {
            List<ViewRentPayeeDTO> rentUnitList = new List<ViewRentPayeeDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_RENT_PAYEE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (rentUnitList != null)
                {
                    rentUnitList = (from DataRow dr in dt.Rows
                                    select new ViewRentPayeeDTO()
                                    {
                                        RENT_PAYEEID = Convert.ToInt32(dr["RENT_PAYEEID"]),
                                        PROJECT_ID = dr.IsNull("PROJECT_ID") ? null : Convert.ToString(dr["PROJECT_ID"]),
                                        Project_Name = dr.IsNull("Project_Name") ? null : Convert.ToString(dr["Project_Name"]),
                                        UNIT_ID = dr.IsNull("UNIT_ID") ? null : Convert.ToString(dr["UNIT_ID"]),
                                        UNIT_NAME = dr.IsNull("UNIT_NAME") ? null : Convert.ToString(dr["UNIT_NAME"]),
                                        LAND_ID = dr.IsNull("LAND_ID") ? null : Convert.ToString(dr["LAND_ID"]),
                                        LANDLORD_NAME = dr.IsNull("LANDLORD_NAME") ? null : Convert.ToString(dr["LANDLORD_NAME"]),
                                        PAYEE_NAME = dr.IsNull("PAYEE_NAME") ? null : Convert.ToString(dr["PAYEE_NAME"]),
                                        RELATION = dr.IsNull("RELATION") ? null : Convert.ToString(dr["RELATION"]),
                                        CASH = dr.IsNull("CASH") ? null : Convert.ToString(dr["CASH"]),
                                        M_BANK = dr.IsNull("M_BANK") ? null : Convert.ToString(dr["M_BANK"]),
                                        M_BANK_AMOUNT = dr.IsNull("M_BANK_AMOUNT") ? null : Convert.ToString(dr["M_BANK_AMOUNT"]),
                                        BANK_ID = dr.IsNull("BANK_ID") ? null : Convert.ToString(dr["BANK_ID"]),
                                        DISTRICT = dr.IsNull("DISTRICT") ? null : Convert.ToString(dr["DISTRICT"]),
                                        BRANCH = dr.IsNull("BRANCH") ? null : Convert.ToString(dr["BRANCH"]),
                                        ROU_NUM = dr.IsNull("ROU_NUM") ? null : Convert.ToString(dr["ROU_NUM"]),
                                        ACC_NUM = dr.IsNull("ACC_NUM") ? null : Convert.ToString(dr["ACC_NUM"]),
                                        AMOUNT = dr.IsNull("AMOUNT") ? null : Convert.ToString(dr["AMOUNT"]),
                                        STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
                                        CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                    }).ToList();
                }

            }

            return rentUnitList;
        }
        public List<ViewRentPayeeDTO> GetShareRentPayee(int landId)
        {
            List<ViewRentPayeeDTO> rentUnitList = new List<ViewRentPayeeDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_SHARE_RENT_PAYEE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@landId", landId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (rentUnitList != null)
                {
                    rentUnitList = (from DataRow dr in dt.Rows
                                    select new ViewRentPayeeDTO()
                                    {
                                        RENT_PAYEEID = Convert.ToInt32(dr["RENT_PAYEEID"]),
                                        PROJECT_ID = dr.IsNull("PROJECT_ID") ? null : Convert.ToString(dr["PROJECT_ID"]),
                                        Project_Name = dr.IsNull("Project_Name") ? null : Convert.ToString(dr["Project_Name"]),
                                        UNIT_ID = dr.IsNull("UNIT_ID") ? null : Convert.ToString(dr["UNIT_ID"]),
                                        UNIT_NAME = dr.IsNull("UNIT_NAME") ? null : Convert.ToString(dr["UNIT_NAME"]),
                                        LAND_ID = dr.IsNull("LAND_ID") ? null : Convert.ToString(dr["LAND_ID"]),
                                        LANDLORD_NAME = dr.IsNull("LANDLORD_NAME") ? null : Convert.ToString(dr["LANDLORD_NAME"]),
                                        PAYEE_NAME = dr.IsNull("PAYEE_NAME") ? null : Convert.ToString(dr["PAYEE_NAME"]),
                                        RELATION = dr.IsNull("RELATION") ? null : Convert.ToString(dr["RELATION"]),
                                        CASH = dr.IsNull("CASH") ? null : Convert.ToString(dr["CASH"]),
                                        M_BANK = dr.IsNull("M_BANK") ? null : Convert.ToString(dr["M_BANK"]),
                                        M_BANK_AMOUNT = dr.IsNull("M_BANK_AMOUNT") ? null : Convert.ToString(dr["M_BANK_AMOUNT"]),
                                        BANK_ID = dr.IsNull("BANK_ID") ? null : Convert.ToString(dr["BANK_ID"]),
                                        DISTRICT = dr.IsNull("DISTRICT") ? null : Convert.ToString(dr["DISTRICT"]),
                                        BRANCH = dr.IsNull("BRANCH") ? null : Convert.ToString(dr["BRANCH"]),
                                        ROU_NUM = dr.IsNull("ROU_NUM") ? null : Convert.ToString(dr["ROU_NUM"]),
                                        ACC_NUM = dr.IsNull("ACC_NUM") ? null : Convert.ToString(dr["ACC_NUM"]),
                                        AMOUNT = dr.IsNull("AMOUNT") ? null : Convert.ToString(dr["AMOUNT"]),
                                        STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",
                                        CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                    }).ToList();
                }

            }

            return rentUnitList;
        }
        public ViewRentPayeeDTO getRentPayeeData(int rentPayeeId)
        {
            ViewRentPayeeDTO Cat = new ViewRentPayeeDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (rentPayeeId != 0)
            {

                string selectData = "SELECT DISTINCT RENT_PAYEEID,RP.PROJECT_ID,PM.Project_Name,RP.UNIT_ID,RU.UNIT_NAME,RP.LAND_ID,RL.Name as LANDLORD_NAME, PAYEE_NAME,RELATION,CASH,M_BANK,RP.M_BANK_AMOUNT,RP.BANK_ID, RP.DISTRICT,RP.BRANCH,RP.ROU_NUM,RP.ACC_NUM,RP.AMOUNT,RP.STATUS,RP.CREATED_BY FROM RENT_PAYEE RP INNER JOIN PROJECT_MASTER PM ON RP.PROJECT_ID=PM.Project_ID INNER JOIN RENT_UNIT RU ON RP.UNIT_ID=RU.UNIT_ID INNER JOIN RENT_LANDLORD RL on RP.LAND_ID=RL.Landlord_ID  where RENT_PAYEEID = " + rentPayeeId + "";


                SqlCommand cmd = new SqlCommand(selectData, conn);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ViewRentPayeeDTO()
                           {
                               RENT_PAYEEID = Convert.ToInt32(dr["RENT_PAYEEID"]),
                               PROJECT_ID = dr.IsNull("PROJECT_ID") ? null : Convert.ToString(dr["PROJECT_ID"]),
                               Project_Name = dr.IsNull("Project_Name") ? null : Convert.ToString(dr["Project_Name"]),
                               UNIT_ID = dr.IsNull("UNIT_ID") ? null : Convert.ToString(dr["UNIT_ID"]),
                               UNIT_NAME = dr.IsNull("UNIT_NAME") ? null : Convert.ToString(dr["UNIT_NAME"]),
                               LAND_ID = dr.IsNull("LAND_ID") ? null : Convert.ToString(dr["LAND_ID"]),
                               LANDLORD_NAME = dr.IsNull("LANDLORD_NAME") ? null : Convert.ToString(dr["LANDLORD_NAME"]),
                               PAYEE_NAME = dr.IsNull("PAYEE_NAME") ? null : Convert.ToString(dr["PAYEE_NAME"]),
                               RELATION = dr.IsNull("RELATION") ? null : Convert.ToString(dr["RELATION"]),
                               CASH = dr.IsNull("CASH") ? null : Convert.ToString(dr["CASH"]),
                               M_BANK = dr.IsNull("M_BANK") ? null : Convert.ToString(dr["M_BANK"]),
                               M_BANK_AMOUNT = dr.IsNull("M_BANK_AMOUNT") ? null : Convert.ToString(dr["M_BANK_AMOUNT"]),
                               BANK_ID = dr.IsNull("BANK_ID") ? null : Convert.ToString(dr["BANK_ID"]),
                               DISTRICT = dr.IsNull("DISTRICT") ? null : Convert.ToString(dr["DISTRICT"]),
                               BRANCH = dr.IsNull("BRANCH") ? null : Convert.ToString(dr["BRANCH"]),
                               ROU_NUM = dr.IsNull("ROU_NUM") ? null : Convert.ToString(dr["ROU_NUM"]),
                               ACC_NUM = dr.IsNull("ACC_NUM") ? null : Convert.ToString(dr["ACC_NUM"]),
                               AMOUNT = dr.IsNull("AMOUNT") ? null : Convert.ToString(dr["AMOUNT"]),
                               STATUS = dr.IsNull("STATUS") ? null : Convert.ToBoolean(dr["STATUS"]) == true ? "Active" : "InActive",

                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public DataTable updateRentPayee(int rentPayee_Id, int ProjectList, int UnitList, int LandlordList, string payee_Name, string relation, string cash,
            string mobile_Banking_Type, string mobile_Banking_Amount, string BankName_0, string BankDistrict_0, string BranchName_0,
            string routing_Number, string account_Number, string amount, bool sTatus, string userid)

        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }


                SqlCommand cmd = new SqlCommand("SP_RENT_PAYEE", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rentPayeeID", rentPayee_Id);
                cmd.Parameters.AddWithValue("@projectID", ProjectList);
                cmd.Parameters.AddWithValue("@unitID", UnitList);
                cmd.Parameters.AddWithValue("@landID", LandlordList);
                cmd.Parameters.AddWithValue("@payeeName", payee_Name);
                cmd.Parameters.AddWithValue("@relation", relation);
                cmd.Parameters.AddWithValue("@cash", cash);
                cmd.Parameters.AddWithValue("@mBank", mobile_Banking_Type);
                cmd.Parameters.AddWithValue("@mBankAmount", mobile_Banking_Amount);
                cmd.Parameters.AddWithValue("@bankId", BankName_0);
                cmd.Parameters.AddWithValue("@district", BankDistrict_0);
                cmd.Parameters.AddWithValue("@branch", BranchName_0);
                cmd.Parameters.AddWithValue("@rouNum", routing_Number);
                cmd.Parameters.AddWithValue("@accNum", account_Number);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@sTatus ", sTatus);
                cmd.Parameters.AddWithValue("@cBy", userid);
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
        public DataTable GetRentYearList()
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_ACCYEARLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetMonthList(string _yearId)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_ACCMONTHLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@year", _yearId);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetFirstDayOfMonthList()
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_ACCF_DAYMLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetEndDayOfMonthList()
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SP_ACCE_DAYMLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable SaveRentPayment(string first_Day_Of_Month, string ExpecRentPayDateList, string ActRentPayDateList, string ProjectList, string UnitList, string AgreementList,
           string BalanceList, string Monthly_rentList, string AdvadjustList, string TaxrentList,string AitpaidList, string AitperList, string AitamountList, string VatperList,string VatamtList,
          string DiscrentList,string DiscaitList,string DiscvatList,string DiscadvList,  string MonthlyRentPaymentList, string MonthlyRentExpenseList, string AdjustedBalanceList,string RentDetailsIdList, string userid, string sTatus)

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_RENT_PAYMENT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accPrdID", first_Day_Of_Month);
                cmd.Parameters.AddWithValue("@agreementID", AgreementList);
                cmd.Parameters.AddWithValue("@projectID", ProjectList);
                cmd.Parameters.AddWithValue("@unitID", UnitList);
                cmd.Parameters.AddWithValue("@expecRPDate", ExpecRentPayDateList);
                cmd.Parameters.AddWithValue("@actualRPDate", ActRentPayDateList);
                cmd.Parameters.AddWithValue("@rentDetailsId", RentDetailsIdList);
                cmd.Parameters.AddWithValue("@prvBlnAmt", BalanceList);
                cmd.Parameters.AddWithValue("@mRentAmt", Monthly_rentList);
                cmd.Parameters.AddWithValue("@mAdjAmt", AdvadjustList);
                cmd.Parameters.AddWithValue("@mRntTax", TaxrentList);
                cmd.Parameters.AddWithValue("@aitPer", AitperList);
                cmd.Parameters.AddWithValue("@aitAmt", AitamountList);
                cmd.Parameters.AddWithValue("@aitAgree", AitpaidList);
                cmd.Parameters.AddWithValue("@vatPer", VatperList);
                cmd.Parameters.AddWithValue("@vatAmt", VatamtList);
                cmd.Parameters.AddWithValue("@rentDiscAmt", DiscrentList);
                cmd.Parameters.AddWithValue("@aitDiscAmt", DiscaitList);
                cmd.Parameters.AddWithValue("@vatDiscAmt", DiscvatList);
                cmd.Parameters.AddWithValue("@discAdjAmt", DiscadvList);
                cmd.Parameters.AddWithValue("@mRentPayment", MonthlyRentPaymentList);
                cmd.Parameters.AddWithValue("@mRentExpense", MonthlyRentExpenseList);
                cmd.Parameters.AddWithValue("@mAdjBalance", AdjustedBalanceList);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus", sTatus);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ViewTenorDTO> Get_Tenor(int Tenor,string start_Date_of_Agreement)
        {
            List<ViewTenorDTO> assetProjectList = new List<ViewTenorDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_RENT_TENOR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@da", Tenor);
                cmd.Parameters.AddWithValue("@data", start_Date_of_Agreement);
                cmd.Parameters.AddWithValue("@a",1);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetProjectList != null)
                {
                    assetProjectList = (from DataRow dr in dt.Rows
                                        select new ViewTenorDTO()
                                        {
                                            //Agreement_ID = Convert.ToInt32(dr["Agreement_ID"]),
                                            DateAdd = dr.IsNull("DateAdd") ? null : Convert.ToString(dr["DateAdd"])
                                           
                                        }).ToList();
                }

            }

            return assetProjectList;
        }
        public List<ViewTenorDTO> GetRentStartDate(int Tenor, string start_Date_of_Agreement)
        {
            List<ViewTenorDTO> assetProjectList = new List<ViewTenorDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_RENT_TENOR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@da", Tenor);
                cmd.Parameters.AddWithValue("@data", start_Date_of_Agreement);
                cmd.Parameters.AddWithValue("@a",2);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetProjectList != null)
                {
                    assetProjectList = (from DataRow dr in dt.Rows
                                        select new ViewTenorDTO()
                                        {
                                            //Agreement_ID = Convert.ToInt32(dr["Agreement_ID"]),
                                            DateAdd = dr.IsNull("DateAdd") ? null : Convert.ToString(dr["DateAdd"])

                                        }).ToList();
                }

            }

            return assetProjectList;
        }
        public List<ViewTenorDTO> GetEndOfRent(int Tenor, string actual_Rent_Start_Date)
        {
            List<ViewTenorDTO> assetProjectList = new List<ViewTenorDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_RENT_END", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@da", Tenor);
                cmd.Parameters.AddWithValue("@data", actual_Rent_Start_Date);
                cmd.Parameters.AddWithValue("@a", 1);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (assetProjectList != null)
                {
                    assetProjectList = (from DataRow dr in dt.Rows
                                        select new ViewTenorDTO()
                                        {
                                            //Agreement_ID = Convert.ToInt32(dr["Agreement_ID"]),
                                            DateAdd = dr.IsNull("DateAdd") ? null : Convert.ToString(dr["DateAdd"])

                                        }).ToList();
                }

            }

            return assetProjectList;
        }
        public DataTable SaveDiscount(string discountId,string ProjectList, string UnitList, string AgreementList, string discount_Rent_Start_Date, string discount_Rent_End_Date, string rent_Discount_Type, string rent_Amount, string advance_Calculate_Type, string advance_Amount,
           string aIT_Calculate_Type, string aIT_Amount, bool sTatus, string userid)
          

        {
            DataTable dt = new DataTable();

            try
            {
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_RENT_DISCOUNT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", discountId);
                cmd.Parameters.AddWithValue("@projectID", ProjectList);
                cmd.Parameters.AddWithValue("@unitID ", UnitList);
                cmd.Parameters.AddWithValue("@agreementID ", AgreementList);
                cmd.Parameters.AddWithValue("@startDate", discount_Rent_Start_Date);
                cmd.Parameters.AddWithValue("@endDate", discount_Rent_End_Date);
                cmd.Parameters.AddWithValue("@renDiscType", rent_Discount_Type);
                cmd.Parameters.AddWithValue("@renDiscAmount", rent_Amount);
                cmd.Parameters.AddWithValue("@advAdjustmentType ", advance_Calculate_Type);
                cmd.Parameters.AddWithValue("@advAmount ", advance_Amount);
                cmd.Parameters.AddWithValue("@aitCalculateType ", aIT_Calculate_Type);
                cmd.Parameters.AddWithValue("@aitAmount", aIT_Amount);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus ", sTatus);
                cmd.Parameters.AddWithValue("@sT", 1);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ViewRentDiscountDTO> GetRentDiscount()
        {
            List<ViewRentDiscountDTO> rentUnitList = new List<ViewRentDiscountDTO>();

            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("USP_RENT_DISCOUNT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (rentUnitList != null)
                {
                    rentUnitList = (from DataRow dr in dt.Rows
                                    select new ViewRentDiscountDTO()
                                    {
                                        Discount_ID = Convert.ToInt32(dr["Discount_ID"]),
                                        External_ID = dr.IsNull("External_ID") ? null : Convert.ToString(dr["External_ID"]),
                                        Project_ID = dr.IsNull("Project_ID") ? null : Convert.ToString(dr["Project_ID"]),
                                        Project_Name = dr.IsNull("Project_Name") ? null : Convert.ToString(dr["Project_Name"]),
                                        Unit_ID = dr.IsNull("Unit_ID") ? null : Convert.ToString(dr["Unit_ID"]),
                                        UNIT_NAME = dr.IsNull("UNIT_NAME") ? null : Convert.ToString(dr["UNIT_NAME"]),
                                        Agreement_ID = dr.IsNull("Agreement_ID") ? null : Convert.ToString(dr["Agreement_ID"]),
                                        Start_DT = dr.IsNull("Start_Date") ? null : Convert.ToString(dr["Start_Date"]),
                                        End_DT = dr.IsNull("End_DT") ? null : Convert.ToString(dr["End_DT"]),
                                        Rent_Disc_Type = dr.IsNull("Rent_Disc_Type") ? null : Convert.ToString(dr["Rent_Disc_Type"]),
                                        Rent_Disc_Amount = dr.IsNull("Rent_Disc_Amount") ? null : Convert.ToString(dr["Rent_Disc_Amount"]),
                                        Adv_Adj_Type = dr.IsNull("Adv_Adj_Type") ? null : Convert.ToString(dr["Adv_Adj_Type"]),
                                        Adv_Adj_Amount = dr.IsNull("Adv_Adj_Amount") ? null : Convert.ToString(dr["Adv_Adj_Amount"]),
                                        AIT_CalType = dr.IsNull("AIT_CalType") ? null : Convert.ToString(dr["AIT_CalType"]),
                                        AIT_Amount = dr.IsNull("AIT_Amount") ? null : Convert.ToString(dr["AIT_Amount"]),
                                        Status = dr.IsNull("Status") ? null : Convert.ToBoolean(dr["Status"]) == true ? "Active" : "InActive",
                                        CREATED_BY = Convert.ToBoolean(dr["CREATED_BY"])
                                    }).ToList();
                }

            }

            return rentUnitList;
        }
        public ViewRentDiscountDTO getRentDiscountData(int discountId)
        {
            ViewRentDiscountDTO Cat = new ViewRentDiscountDTO();


            if (conn.State == 0)
            {
                conn.Open();
            }

            if (discountId != 0)
            {

                string selectData = "  SELECT Discount_ID ,RD.External_ID,RD.Project_ID,PM.Project_Name,RD.Unit_ID,RU.UNIT_NAME,RD.Agreement_ID,convert(varchar(10), Start_Date, 120)Start_Date,convert(varchar(10), End_DT, 120)End_DT,Rent_Disc_Type, Rent_Disc_Amount,RD.Adv_Adj_Type,Adv_Adj_Amount, AIT_CalType,AIT_Amount,RD.Status,RD.CREATED_BY FROM RENT_DISCOUNT RD INNER JOIN PROJECT_MASTER PM ON PM.Project_ID=RD.Project_ID INNER JOIN RENT_UNIT RU on RU.UNIT_ID =RD.Unit_ID where Discount_ID = " + discountId + "";


                SqlCommand cmd = new SqlCommand(selectData, conn);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (Cat != null)
                {
                    Cat = (from DataRow dr in dt.Rows
                           select new ViewRentDiscountDTO()
                           {

                               Discount_ID = Convert.ToInt32(dr["Discount_ID"]),
                               External_ID = dr.IsNull("External_ID") ? null : Convert.ToString(dr["External_ID"]),
                               Project_ID = dr.IsNull("Project_ID") ? null : Convert.ToString(dr["Project_ID"]),
                               Project_Name = dr.IsNull("Project_Name") ? null : Convert.ToString(dr["Project_Name"]),
                               Unit_ID = dr.IsNull("Unit_ID") ? null : Convert.ToString(dr["Unit_ID"]),
                               UNIT_NAME = dr.IsNull("UNIT_NAME") ? null : Convert.ToString(dr["UNIT_NAME"]),
                               Agreement_ID = dr.IsNull("Agreement_ID") ? null : Convert.ToString(dr["Agreement_ID"]),
                               Start_DT = dr.IsNull("Start_Date") ? null : Convert.ToString(dr["Start_Date"]),
                               End_DT = dr.IsNull("End_DT") ? null : Convert.ToString(dr["End_DT"]),
                               Rent_Disc_Type = dr.IsNull("Rent_Disc_Type") ? null : Convert.ToString(dr["Rent_Disc_Type"]),
                               Rent_Disc_Amount = dr.IsNull("Rent_Disc_Amount") ? null : Convert.ToString(dr["Rent_Disc_Amount"]),
                               Adv_Adj_Type = dr.IsNull("Adv_Adj_Type") ? null : Convert.ToString(dr["Adv_Adj_Type"]),
                               Adv_Adj_Amount = dr.IsNull("Adv_Adj_Amount") ? null : Convert.ToString(dr["Adv_Adj_Amount"]),
                               AIT_CalType = dr.IsNull("AIT_CalType") ? null : Convert.ToString(dr["AIT_CalType"]),
                               AIT_Amount = dr.IsNull("AIT_Amount") ? null : Convert.ToString(dr["AIT_Amount"]),
                               Status = dr.IsNull("Status") ? null : Convert.ToBoolean(dr["Status"]) == true ? "Active" : "InActive",
                           }).FirstOrDefault();
                }


            }
            return Cat;
        }
        public DataTable UpdateRentDiscount(string discountId, string ProjectList, string UnitList, string AgreementList, string discount_Rent_Start_Date, string discount_Rent_End_Date, string rent_Discount_Type, string rent_Amount, string advance_Calculate_Type, string advance_Amount,
           string aIT_Calculate_Type, string aIT_Amount, bool sTatus, string userid)

        {
            try
            {

                DataTable dt = new DataTable();
                if (conn.State == 0)
                {
                    conn.Open();
                }



                SqlCommand cmd = new SqlCommand("SP_RENT_DISCOUNT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eID", discountId);
                cmd.Parameters.AddWithValue("@projectID", ProjectList);
                cmd.Parameters.AddWithValue("@unitID ", UnitList);
                cmd.Parameters.AddWithValue("@agreementID ", AgreementList);
                cmd.Parameters.AddWithValue("@startDate", discount_Rent_Start_Date);
                cmd.Parameters.AddWithValue("@endDate", discount_Rent_End_Date);
                cmd.Parameters.AddWithValue("@renDiscType", rent_Discount_Type);
                cmd.Parameters.AddWithValue("@renDiscAmount", rent_Amount);
                cmd.Parameters.AddWithValue("@advAdjustmentType ", advance_Calculate_Type);
                cmd.Parameters.AddWithValue("@advAmount ", advance_Amount);
                cmd.Parameters.AddWithValue("@aitCalculateType ", aIT_Calculate_Type);
                cmd.Parameters.AddWithValue("@aitAmount", aIT_Amount);
                cmd.Parameters.AddWithValue("@cBy", userid);
                cmd.Parameters.AddWithValue("@sTatus ", sTatus);
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

        public int checkRentDetails(int agreement_id)
        {
           
            if (conn.State == 0)
            {
                conn.Open();
            }
          
                string selectData = "SELECT count(Agreement_ID) from RENT_DETAILS  where Agreement_ID  = " + agreement_id + "";
                SqlCommand cmd = new SqlCommand(selectData, conn);
                int count = (int)cmd.ExecuteScalar();
            return count;

        }
        public int checkRentIncrement(string agreement_id)
        {

            if (conn.State == 0)
            {
                conn.Open();
            }

            string selectData = "SELECT count(Agreement_ID) from RENT_INCREMENT  where Agreement_ID = " + agreement_id + "";
            SqlCommand cmd = new SqlCommand(selectData, conn);
            int count = (int)cmd.ExecuteScalar();
            return count;

        }
        public int checkRentPayment(string first_Day_Of_Month)
        {

            if (conn.State == 0)
            {
                conn.Open();
            }

            string selectData = "SELECT count(ACC_PrdID) from RENT_PAYMENT  where ACC_PrdID = " + first_Day_Of_Month + "";
            SqlCommand cmd = new SqlCommand(selectData, conn);
            int count = (int)cmd.ExecuteScalar();
            return count;

        }
    }
}
