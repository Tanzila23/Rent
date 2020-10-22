using POSX.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FIXED_ASSET.DAL
{
    public class ReportDAL
    {
        public static SqlConnection conn = new SqlConnection(DBConnection.GetConnectionString());
        public DataTable Outlet_Wise_Asset_Details_Report(string _bunitId, string _assetClass)

        {
            DataTable dt = new DataTable();
            if (conn.State == 0)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand("SP_RPT_ASSET_CLASS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            // @spType

            cmd.Parameters.AddWithValue("@bunit_id", Convert.ToInt32(_bunitId));
            cmd.Parameters.AddWithValue("@asset_class", Convert.ToInt32( _assetClass));
          
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);

            return dt;
         }

        public DataTable Department_User_Wise_Asset_List_Report(string _department_Id, string _user_Code)

        {
            DataTable dt = new DataTable();
            if (conn.State == 0)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand("SP_RPT_DEPARTMENT_USER_WISE_ASSET", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            // @spType

            cmd.Parameters.AddWithValue("@dep_id", _department_Id);
            cmd.Parameters.AddWithValue("@user_id", _user_Code);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);

            return dt;
        }

        public DataTable Unit_Wise_Agreement_Report(string _ProjectList, string _UnitList, string _AgreementList)

        {
            DataTable dt = new DataTable();
            if (conn.State == 0)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand("SP_RPT_UNIT_WISE_AGREEMENT", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            // @spType

            cmd.Parameters.AddWithValue("@project_id", _ProjectList);
            cmd.Parameters.AddWithValue("@unit_id", _UnitList);
            cmd.Parameters.AddWithValue("@agreement_id", _AgreementList);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);

            return dt;
        }
    }
}