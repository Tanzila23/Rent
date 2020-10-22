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
	public class DashboardDAL
	{
		public static SqlConnection conn = new SqlConnection(DBConnection.GetConnectionString());


		public DataTable Dashboard_Sales_Summary(int _BusinessUnit_ID, string _Created_By)
		{
			DataTable dt = new DataTable();
			if (conn.State == 0)
			{
				conn.Open();
			}
			//  @BusinessUnit_ID INT, @Created_By nvarchar(50)

			SqlCommand cmd = new SqlCommand("USP_Dashboard_Sales_Summary", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@BusinessUnit_ID", _BusinessUnit_ID);
			cmd.Parameters.AddWithValue("@Created_By", _Created_By);
			SqlDataAdapter adpt = new SqlDataAdapter(cmd);
			adpt.Fill(dt);

			return dt;
		}

		public DataTable Outlet_Daily_Closing(int _BusinessUnit_ID, string _StartDate, string _EndDate)
		{
			DataTable dt = new DataTable();
			if (conn.State == 0)
			{
				conn.Open();
			}
			//  @BusinessUnit_ID INT, @Created_By nvarchar(50)

			SqlCommand cmd = new SqlCommand("Report_Outlet_Daily_Closing", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@BusinessUnit_ID", _BusinessUnit_ID);
			cmd.Parameters.AddWithValue("@StartDate", _StartDate);
			cmd.Parameters.AddWithValue("@EndDate", _EndDate);
			SqlDataAdapter adpt = new SqlDataAdapter(cmd);
			adpt.Fill(dt);

			return dt;
		}


		public DataTable Get_Retail_Margin_LINECHART(string _FrmDate, string _ToDate, int _spType)
		{
			DataTable dt = new DataTable();
			if (conn.State == 0)
			{
				conn.Open();
			}
			//  @BusinessUnit_ID INT, @Created_By nvarchar(50)

			SqlCommand cmd = new SqlCommand("RPT_RMARGIN", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@StartDate", _FrmDate);
			cmd.Parameters.AddWithValue("@EndDate", _ToDate);
			cmd.Parameters.AddWithValue("@Type", _spType);

			SqlDataAdapter adpt = new SqlDataAdapter(cmd);
			adpt.Fill(dt);

			return dt;
		}

		public DataTable Get_Dashboard_Stockfigure(int _Bunit_ID, int _StorageID, int _rptype)
		{
			DataTable dt = new DataTable();
			if (conn.State == 0)
			{
				conn.Open();
			}
			//  @BusinessUnit_ID INT, @Created_By nvarchar(50)

			SqlCommand cmd = new SqlCommand("RPT_DASHBOARD_STOCKFIGURE", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@Bunit_ID", _Bunit_ID);
			cmd.Parameters.AddWithValue("@StorageID", _StorageID);
			cmd.Parameters.AddWithValue("@rptype", _rptype);

			SqlDataAdapter adpt = new SqlDataAdapter(cmd);
			adpt.Fill(dt);

			return dt;
		}

		public DataTable Get_Dashboard_Dlvfigure(int _Bunit_ID, int _StorageID, int _rptype)
		{
			DataTable dt = new DataTable();
			if (conn.State == 0)
			{
				conn.Open();
			}
			//  @BusinessUnit_ID INT, @Created_By nvarchar(50)

			SqlCommand cmd = new SqlCommand("RPT_DASHBOARD_DLVFIGURE", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@Bunit_ID", _Bunit_ID);
			cmd.Parameters.AddWithValue("@StorageID", _StorageID);
			cmd.Parameters.AddWithValue("@rptype", _rptype);

			SqlDataAdapter adpt = new SqlDataAdapter(cmd);
			adpt.Fill(dt);

			return dt;
		}


		public DataTable Get_Dashboard_Rcvfigure(int _Bunit_ID, int _StorageID, int _rptype)
		{
			DataTable dt = new DataTable();
			if (conn.State == 0)
			{
				conn.Open();
			}
			//  @BusinessUnit_ID INT, @Created_By nvarchar(50)

			SqlCommand cmd = new SqlCommand("RPT_DASHBOARD_RCVFIGURE", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@Bunit_ID", _Bunit_ID);
			cmd.Parameters.AddWithValue("@StorageID", _StorageID);
			cmd.Parameters.AddWithValue("@rptype", _rptype);

			SqlDataAdapter adpt = new SqlDataAdapter(cmd);
			adpt.Fill(dt);

			return dt;
		}

		public List<DashboardDTO> Get_Dashboard_Stock_Figure_Category(int _Bunit_ID, int _ChID, int _rptype)
		{
			List<DashboardDTO> dashboardDTOs = new List<DashboardDTO>();

			DataTable dt = new DataTable();
			if (conn.State == 0)
			{
				conn.Open();
			}
			//  @BusinessUnit_ID INT, @Created_By nvarchar(50)

			SqlCommand cmd = new SqlCommand("RPT_DASHBOARD_STOCKFIGURECAT", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@Bunit_ID", _Bunit_ID);
			cmd.Parameters.AddWithValue("@ChID", _ChID);
			cmd.Parameters.AddWithValue("@rptype", _rptype);

			SqlDataAdapter adpt = new SqlDataAdapter(cmd);
			adpt.Fill(dt);


			if (dashboardDTOs != null)
			{
				dashboardDTOs = (from DataRow dr in dt.Rows
								 select new DashboardDTO()
								 {
									 CHANNEL = dr.IsNull("CHANNEL") ? null : Convert.ToString(dr["CHANNEL"]),
									 CID = dr.IsNull("CID") ? 0 : Convert.ToInt32(dr["CID"]),
									 Category = dr.IsNull("Category") ? null : Convert.ToString(dr["Category"]),
									 FULL_AMOUNT = dr.IsNull("FULL_AMOUNT") ? 0 : Convert.ToInt32(dr["FULL_AMOUNT"]),
									 FULL_COST = dr.IsNull("FULL_COST") ? 0 : Convert.ToInt32(dr["FULL_COST"]),
									 FULL_QTY = dr.IsNull("FULL_QTY") ? 0 : Convert.ToInt32(dr["FULL_QTY"])
								 }).ToList();
			}

			return dashboardDTOs;
		}

		public DataTable Get_Dashboard_Stock_Figure(int _Bunit_ID, int _ChID, int _rptype)
		{
			//List<DashboardDTO> dashboardDTOs = new List<DashboardDTO>();

			DataTable dt = new DataTable();
			if (conn.State == 0)
			{
				conn.Open();
			}
			//  @BusinessUnit_ID INT, @Created_By nvarchar(50)

			SqlCommand cmd = new SqlCommand("RPT_DASHBOARD_STOCKFIGURECAT", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@Bunit_ID", _Bunit_ID);
			cmd.Parameters.AddWithValue("@ChID", _ChID);
			cmd.Parameters.AddWithValue("@rptype", _rptype);

			SqlDataAdapter adpt = new SqlDataAdapter(cmd);
			adpt.Fill(dt);




			return dt;
		}

		public DataTable Get_Dashboard_Order_Delivery_Status(int _ChID, string _Start_Date, string _End_Date)
		{
			//List<DashboardDTO> dashboardDTOs = new List<DashboardDTO>();

			DataTable dt = new DataTable();
			if (conn.State == 0)
			{
				conn.Open();
			}
			//  @BusinessUnit_ID INT, @Created_By nvarchar(50)

			try
			{
				SqlCommand cmd = new SqlCommand("RPT_DASHBOARD_ORDDLVSTAT", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@StartDT", _Start_Date);
				cmd.Parameters.AddWithValue("@EndDT", _End_Date);
				cmd.Parameters.AddWithValue("@ChID", _ChID);

				SqlDataAdapter adpt = new SqlDataAdapter(cmd);
				adpt.Fill(dt);
			}
			catch (Exception ex)
			{

				throw ex;
			}


			return dt;
		}


		public DataTable GetChannelList()
		{
			using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
			{
				SqlCommand cmd = new SqlCommand("USP_AllChannel_List", con);
				cmd.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				con.Open();
				da.Fill(dt);
				con.Close();
				return dt;
			}
		}

		public DataTable MainAsset()
		{
			DataTable dt = new DataTable();
			string constr = DBConnection.GetConnectionString();
			string sql = "SELECT COUNT(adi.ASSET_CODE) 'TOTAL_ASSET'FROM ASSET_MASTER am LEFT JOIN ASSET_DETAILSINFO adi ON am.ASSET_CODE = adi.ASSET_CODE where TYPE_ID = '1'";
			using (SqlConnection conn = new SqlConnection(constr))
			{
				using (SqlCommand cmd = new SqlCommand(sql))
				{
					cmd.Connection = conn;
					using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
					{
						sda.Fill(dt);
					}
				}
			}

			return dt;
		}

		public DataTable PERIPHERAL()
		{
			DataTable dt = new DataTable();
			string constr = DBConnection.GetConnectionString();
			string sql = " SELECT COUNT(adi.ASSET_CODE) 'TOTAL_PERIPHERAL' FROM ASSET_MASTER am LEFT JOIN ASSET_DETAILSINFO adi ON am.ASSET_CODE = adi.ASSET_CODE where TYPE_ID = '2'";
			using (SqlConnection conn = new SqlConnection(constr))
			{
				using (SqlCommand cmd = new SqlCommand(sql))
				{
					cmd.Connection = conn;
					using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
					{
						sda.Fill(dt);
					}
				}
			}

			return dt;
		}

		public DataTable COMPONENT()
		{
			DataTable dt = new DataTable();
			string constr = DBConnection.GetConnectionString();
			string sql = " SELECT COUNT(adi.ASSET_CODE) 'TOTAL_COMPONENT' FROM ASSET_MASTER am LEFT JOIN ASSET_DETAILSINFO adi ON am.ASSET_CODE = adi.ASSET_CODE where TYPE_ID = '3'";
			using (SqlConnection conn = new SqlConnection(constr))
			{
				using (SqlCommand cmd = new SqlCommand(sql))
				{
					cmd.Connection = conn;
					using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
					{
						sda.Fill(dt);
					}
				}
			}

			return dt;
		}
        public DataTable Outlet()
        {
            DataTable dt = new DataTable();
            string constr = DBConnection.GetConnectionString();
            string sql = "select count(Project_ID)TOTAL_OUTLET from PROJECT_MASTER";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.Connection = conn;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }

            return dt;
        }
        public DataTable RENT()
        {
            DataTable dt = new DataTable();
            string constr = DBConnection.GetConnectionString();
            string sql = "SELECT SUM(cast (M_Rent AS decimal(8,2)))AS Total_Rent from RENT_DETAILS rd INNER JOIN ACC_PERIOD  ac on ac.YEAR=year(Expec_R_P_Date) and ac.MONTH=month(Expec_R_P_Date) where ac.STATUS=1";


            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.Connection = conn;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }

            return dt;
        }
        public DataTable Tax()
        {
            DataTable dt = new DataTable();
            string constr = DBConnection.GetConnectionString();
            string sql = "SELECT SUM(cast (M_Rent_Tax_Base AS decimal(8,2)))AS Total_Tax  FROM RENT_DETAILS rd INNER JOIN ACC_PERIOD  ac on ac.YEAR=year(Expec_R_P_Date) and ac.MONTH=month(Expec_R_P_Date) where ac.STATUS=1";



            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.Connection = conn;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }

            return dt;
        }
        public DataTable AIT()
        {
            DataTable dt = new DataTable();
            string constr = DBConnection.GetConnectionString();
            string sql = "SELECT SUM(cast (M_AIT_Agree AS decimal(8,2)))AS Total_AIT  FROM RENT_DETAILS rd INNER JOIN ACC_PERIOD  ac on ac.YEAR=year(Expec_R_P_Date) and ac.MONTH=month(Expec_R_P_Date) where ac.STATUS=1";



            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.Connection = conn;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }

            return dt;
        }
        public DataTable VAT()
        {
            DataTable dt = new DataTable();
            string constr = DBConnection.GetConnectionString();
            string sql = "SELECT SUM(cast (VAT AS decimal(8,2)))AS Total_VAT  FROM RENT_DETAILS rd INNER JOIN ACC_PERIOD  ac on ac.YEAR=year(Expec_R_P_Date) and ac.MONTH=month(Expec_R_P_Date) where ac.STATUS=1";



            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.Connection = conn;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public DataTable MONTH_WISE_RENT(string _FrmDate)
        {

            DataTable dt = new DataTable();
            if (conn.State == 0)
            {
                conn.Open();
            }

            try
            {

                //@StartDt DATE,	@EndDt DATE, @AREAID VARCHAR(200), @BUNITID VARCHAR(200), @RPTYP INT
                SqlCommand cmd = new SqlCommand("SP_RENT_DASHBOARD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Year", _FrmDate);
                 SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable RENT_NOTICE_PERIOD(string _vYear,string _vMonth)
        {

            DataTable dt = new DataTable();
            if (conn.State == 0)
            {
                conn.Open();
            }

            try
            {

                //@StartDt DATE,	@EndDt DATE, @AREAID VARCHAR(200), @BUNITID VARCHAR(200), @RPTYP INT
                SqlCommand cmd = new SqlCommand("SP_RENT_NOTICE_PERIOD_DASHBOARD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Year", _vYear);
                cmd.Parameters.AddWithValue("@Month", _vMonth);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public DataTable RENT_AGREEMENT_NOTICE_PERIOD(string _vYear, string _vMonth)
        {

            DataTable dt = new DataTable();
            if (conn.State == 0)
            {
                conn.Open();
            }

            try
            {

                //@StartDt DATE,	@EndDt DATE, @AREAID VARCHAR(200), @BUNITID VARCHAR(200), @RPTYP INT
                SqlCommand cmd = new SqlCommand("SP_RENT_AG_HO_DASHBOARD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Year", _vYear);
                cmd.Parameters.AddWithValue("@Month", _vMonth);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}