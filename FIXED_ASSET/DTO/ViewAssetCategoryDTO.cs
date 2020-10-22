using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIXED_ASSET.DTO
{
    public class ViewAssetCategoryDTO
    {
        public int CAT_ID { get; set; }
        public string EXTERNAL_ID { get; set; }
        public string CLASS_ID { get; set; }
        public string CLASS_NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string CODE { get; set; }
        public string STATUS { get; set; }
        public bool CREATED_BY { get; set; }
    }
    public class ViewManufactureDTO
    {
        public int MANF_ID { get; set; }
        public string EXTERNAL_ID { get; set; }
        public string DESCRIPTION { get; set; }
        public string STATUS { get; set; }
        public string COUNTRY { get; set; }
        public string COUNTRY_NAME { get; set; }
        public string URL { get; set; }
        [AllowHtml]
        public string LOGO_EXT { get; set; }
        //public byte[] Image { get; set; }
        public string PHN_NO { get; set; }
        public string ADDRESS { get; set; }
        public bool CREATED_BY { get; set; }
    }
    public class ViewSupplierDTO
    {
        public int SUP_TYPE_ID { get; set; }
        public string EXTERNAL_ID { get; set; }
        public string TYPE { get; set; }
        public string Status { get; set; }
        public bool CREATED_BY { get; set; }
    }

    public class ViewSupplierDetailsDTO
    {
        public int SUPPLIER_ID { get; set; }
        public string EXTERNAL_ID { get; set; }
        public string SUP_TYPE { get; set; }
        public string NAME { get; set; }
        public string ADDRESS { get; set; }
        public string CITY_ID { get; set; }
        public string CITY_NAME { get; set; }
        public string STATE_ID { get; set; }
        public string COUNTRY_ID { get; set; }
        public string Country_Name { get; set; }
        public string ZIP { get; set; }
        public string URL { get; set; }
        public string CONDITION { get; set; }
        public string SUPPLIER_STATUS { get; set; }
        public bool CREATED_BY { get; set; }
    }
    public class ViewBankAccountDetailsDTO
    {
        public int Bank_ID { get; set; }
        public string EXTERNAL_ID { get; set; }
        public string SUPPLIER_ID { get; set; }
        public string Bankk_ID { get; set; }
        public string Bank_Name { get; set; }
        public string BRANCH { get; set; }
        public string Branch_Name { get; set; }
        public string DISTRICT { get; set; }
        public string District_Name { get; set; }
        public string ACC_NAME { get; set; }
        public string ACC_NUMBER { get; set; }
        public string CURRENCY { get; set; }
        public string PRIMARY { get; set; }
        public string STATUS { get; set; }
        public bool CREATED_BY { get; set; }
    }
    public class ViewContactDetailsDTO
    {
        public int CONTACT_ID { get; set; }
        public string NAME { get; set; }
        public string PHONE { get; set; }
        public string EMAIL { get; set; }
        public string NOTE { get; set; }
        public string STATUS { get; set; }
        public bool CREATED_BY { get; set; }
    }
    public class ModelDTO
    {
        public int MODEL_ID { get; set; }
        public string EXTERNAL_ID { get; set; }
        public string MODEL_NAME { get; set; }
        public string CLASS_ID { get; set; }
        public string CLASS_NAME { get; set; }
        public string CAT_ID { get; set; }
        public string CATEGORY_NAME { get; set; }
        public string SEG_ID { get; set; }
        public string SEGMENT_NAME { get; set; }
        public string MAN_ID { get; set; }
        public string MANUFACTURE_NAME { get; set; }
        public string SUP_ID { get; set; }
        public string SUPPLIER_NAME { get; set; }
        public string MODEL_NO { get; set; }
        public string NOTES { get; set; }
        public string LOGO_EXT { get; set; }
        public bool CREATED_BY { get; set; }
    }
    public class Users
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class ComponentDTO
    {
        public string MST_TAG { get; set; }
        public string ASSET_CLASS { get; set; }
        public string CLASS_NAME { get; set; }
        public string CAT_ID { get; set; }
        public string CATEGORY_NAME { get; set; }
        public string SEG_ID { get; set; }
        public string SEGMENT_NAME { get; set; }
        public string MAN_ID { get; set; }
        public string MANUFACTURE_NAME { get; set; }
        public string MOD_ID { get; set; }
        public string MODEL_NAME { get; set; }
        public string SUPP_ID { get; set; }
        public string SUPPLIER_NAME { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string SIZE { get; set; }
        public string UOM_ID { get; set; }
         public string UNIT_NAME { get; set; }
        public string COLOR_ID { get; set; }
        public string COLOR_NAME { get; set; }
        public string P_COST { get; set; }
        public bool CREATED_BY { get; set; }
    }
    public class ArticleMatrixDTO
    {
        public int ARTMID { get; set; }
        public int? MATRIXID { get; set; }
        //public int MATRIX_TYPE { get; set; }
        public string AttributeName { get; set; }
        public string EXTID { get; set; }
        public string DISCODE { get; set; }
        public string DESCRIPTION { get; set; }
        public string STATUS { get; set; }
    }
    public class PeripheralDTO
    {
       
        public string ASSET_CODE { get; set; }
        public string DESCRIPTION { get; set; }
        public string ASSET_CLASS { get; set; }
        public string ASSET_CLASS_NAME { get; set; }
        public string CAT_ID { get; set; }
        public string CATEGORY_NAME { get; set; }
        public string SEG_ID { get; set; }
        public string SEGMENT_NAME { get; set; }
        public string QUANTITY { get; set; }
        public bool CREATED_BY { get; set; }

    }
    //public class TransferDTO
    //{

    //    public string ASSET_CODE { get; set; }
    //    public string DESCRIPTION { get; set; }
    //    public string ASSET_CLASS { get; set; }
    //    public string ASSET_CLASS_NAME { get; set; }
    //    public string CAT_ID { get; set; }
    //    public string CATEGORY_NAME { get; set; }
    //    public string SEG_ID { get; set; }
    //    public string SEGMENT_NAME { get; set; }
    //    public string QUANTITY { get; set; }
    //    public bool CREATED_BY { get; set; }

    //}
    public class AssetDTO
    {

        public string ASSET_CODE { get; set; }
        // public string ASS_PCODE { get; set; }
        public string MANUFACTURE_NAME { get; set; }
        public string ASSET_CLASS { get; set; }
        public string CLASS_NAME { get; set; }
        public string CAT_ID { get; set; }
        public string CATEGORY_NAME { get; set; }
        public string SEG_ID { get; set; }
        public string SEGMENT_NAME { get; set; }
        public string PARENT_MST_TAG { get; set; }
        public string ASSET_INTTAG { get; set; }

        public string ASSET_EXTTAG { get; set; }
        public string MAIN_ASSET { get; set; }
        public string SUPP_ID { get; set; }
        public string SUPPLIER_NAME { get; set; }
        public string MOD_ID { get; set; }
        public string MODEL_NAME { get; set; }
        public string ASS_CCODE { get; set; }
       // public string CHILD_MST_TAG { get; set; }
       // public string CHILD_ASSET { get; set; }
        public string TOTAL_ASSET { get; set; }
        public string REQ_QUANTITY { get; set; }
        public string P_COST { get; set; }
        public string SUB_TOTAL { get; set; }

        public string TAX { get; set; }
        //public string CHILD_MST_TAG { get; set; }
        public bool CREATED_BY { get; set; }

    }
    public class AssetDetailsDTO
    {
        public string PERIPHERAL_CODE { get; set; }
        public string ASSET_IDFNO { get; set; }
        public string Organization_Name { get; set; }
        public string MAIN_ASSET_CODE { get; set; }
        public int ASSET_CODE { get; set; }
      // public string P_CODE { get; set; }
        public string MAIN_ASSET { get; set; }
        public string CHILD_ASSET { get; set; }
        public string TYPE_ID { get; set; }
        public string QUANTITY { get; set; }
        public string ASSET_CLASS { get; set; }
        public string CLASS_NAME { get; set; }
        public string CAT_ID { get; set; }
        public string CATEGORY_NAME { get; set; }
        public string SEG_ID { get; set; }
        public string SEGMENT_NAME { get; set; }
        public string MOD_ID { get; set; }
        public string MODEL_NAME { get; set; }
        public string MAN_ID { get; set; }
        public string MANUFACTURE { get; set; }
        public string ASSET_INTTAG { get; set; }
        public string ASSET_EXTTAG { get; set; }
        public string SERIAL_NO { get; set; }
        public string P_SERIAL_NO { get; set; }
        public string SERV_TAG { get; set; }
        public string ORD_NO { get; set; }
        public string ORD_DATE { get; set; }
        public string CHALLAN_NO { get; set; }
        public string GRC_DATE { get; set; }
        public string SUP_ID { get; set; }
        public string SUPPLIER_NAME { get; set; }
        public string P_COST { get; set; }
        public string S_PRICE { get; set; }
        public string TAX_AMT { get; set; }
         public string DISCOUNT { get; set; }
         public string LAND_VALUE { get; set; }
        public string NET_AMT { get; set; }
        public string DEP_RULEID { get; set; }
        public string DEP_AMT { get; set; }
        public string BOOK_VALUE { get; set; }
        public string SALVAGE_VALUE { get; set; }
        public string UDF_VALUE { get; set; }
        public string WARRANTY { get; set; }
        public string WAR_TYPE { get; set; }
        public string ASS_EFFDATE { get; set; }
        public string ASS_LIFE { get; set; }
        public string LF_TYPE { get; set; }
        public string ASS_DISPDATE { get; set; }
        public string ASS_CONID { get; set; }
        public string STATUS { get; set; }
        public string BUNIT_ID { get; set; }
        //public string Organization_Name { get; set; }
        public string DEP_ID { get; set; }
        public string DEPT_NAME { get; set; }
        public string USER_ID { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string P_CODE { get; set; }
       
        //public string CHILD_MST_TAG { get; set; }
        public bool CREATED_BY { get; set; }

    }
    public class ViewProjectDTO
    {
        public int Project_ID { get; set; }
        public string External_ID { get; set; }
        public string Project_Name { get; set; }
        public string Project_Type { get; set; }
        public string Start_Date { get; set; }
        public string Area_ID { get; set; }
        public string Area { get; set; }
        public string Address { get; set; }
       // public string Phone { get; set; }
        public string Space { get; set; }
        public string Reference_ID { get; set; }
        public string Reference_Name { get; set; }
        public string Reference_Contact { get; set; }
        public string Status { get; set; }
        public bool Created_By { get; set; }
    }
    public class ViewRentUnitDTO
    {
        public int UNIT_ID { get; set; }
        public string PROJECT_ID { get; set; }
        public string Project_Name { get; set; }
        public string EXTERNAL_ID { get; set; }
        public string UNIT_NAME { get; set; }
        public string ADDRESS { get; set; }                                                                                                                                        
        public string SPACE { get; set; }
        public string SPACE_UNIT { get; set; }
        public string UNIT_TYPE { get; set; }
        public string REMARKS { get; set; }
        public string STATUS { get; set; }
        public bool CREATED_BY { get; set; }
    }
    public class ViewRentLandlordDTO
    {
        public int Landlord_ID { get; set; }
        public string Name { get; set; }
        public string Phone_1 { get; set; }
        public string Phone_2 { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public bool Created_By { get; set; }
    }
    public class ViewAgreementDTO
    {
        public int Agreement_ID { get; set; }
        public string External_ID { get; set; }
        public string Project_ID { get; set; }
        public string Project_Name { get; set; }
        public string Unit_ID { get; set; }
        public string UNIT_NAME { get; set; }
        public string Contract_Type { get; set; }
        public string Advnace_Amt { get; set; }
        public string Start_DT_Agg { get; set; }
        public string Tenor { get; set; }
        public string End_DT_Agg { get; set; }
        public string Rent_Pay { get; set; }
        public string M_Rent_Tax_Base { get; set; }
        public string Agg_HO_Date { get; set; }
        public string Act_HO_Date { get; set; }
        public string Rent_Count { get; set; }
        public string Act_RStrt_Date { get; set; }
        public string Act_REnd_Date { get; set; }
        public string Act_AdvSrt_Date { get; set; }
        public string Adv_Adjust_Amt { get; set; }
        public string Notice_Period { get; set; }
        public string AIT_Paid { get; set; }
        public string Rent_Inc_Perc { get; set; }
        public string Inc_Interval { get; set; }
        public string Payment_Terms { get; set; }
        public string Rent_Pay_Date { get; set; }
        public string B_M_Rent { get; set; }
        public string B_M_Tax { get; set; }
        public string Status { get; set; }
        public bool Created_By { get; set; }
    }
    public class ViewRentShareDTO
    {
        public int LND_SHAREID { get; set; }
        public string LINE_ID { get; set; }
        public string PROJECT_ID { get; set; }
        public string Project_Name { get; set; }
        public string UNIT_ID { get; set; }
        public string UNIT_NAME { get; set; }
        public string LAND_ID { get; set; }
        public string LANDLORD_NAME { get; set; }
        public string SHARE { get; set; }
        public string STATUS { get; set; }
        public bool CREATED_BY { get; set; }
    }
    public class ViewRentVatDTO
    {
        public int VAT_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string VSTART_DATE { get; set; }
        public string VEND_DATE { get; set; }
        public string VAT_PER { get; set; }
        public string REMARKS { get; set; }
        public string STATUS { get; set; }
        public bool CREATE_BY { get; set; }
    }
    public class ViewRentAITDTO
    {
        public int AIT_ID { get; set; }
        public string AIT_NAME { get; set; }
        public string AIT_DESCRIPTION { get; set; }
        public string ESTRT_DATE { get; set; }
        public string EEND_DATE { get; set; }
        public string AIT_PER { get; set; }
        public string REMARKS { get; set; }
        public string STATUS { get; set; }
        public bool CREATE_BY { get; set; }
    }
    public class ViewAgreementSlotDTO
    {
     //   public int AIT_ID { get; set; }
        public string START_DATE { get; set; }
        public string END_DATE { get; set; }
        public string AMOUNT { get; set; }
       
    }
    public class ViewRentIncrementDTO
    {
        public int Increment_ID { get; set; }
        public string Agreement_ID { get; set; }
        public string Project_ID { get; set; }
        public string Project_Name { get; set; }
        public string Unit_ID { get; set; }
        public string Inc_RStrt_Date { get; set; }
        public string Inc_REnd_Date { get; set; }
        public string Inc_Amount { get; set; }
        public string STATUS { get; set; }
        public bool CREATED_BY { get; set; }
    }

    public class ViewRentDetailsDTO
    {
       // public int Agreement_ID { get; set; }
        public string year { get; set; }
        public string month { get; set; }
        public string Inc_Amount { get; set; }
        public string Inc_Vat { get; set; }

    }
    public class ViewRentPaymentsDTO
    {
        // public int Agreement_ID { get; set; }
        //[DataType(DataType.Date)]
        public string Doc_Date { get; set; }
        public string rent_details_id { get; set; }
        public string Expec_R_P_Date { get; set; }
        public string Project_ID { get; set; }
        public string Project_Name { get; set; }
        public string Unit_ID { get; set; }
        public string UNIT_NAME { get; set; }
        public string Agreement_ID { get; set; }
        public string External_ID { get; set; }
        public string Advnace_Amt { get; set; }
        //public string balance_advance { get; set; }
        public string balance { get; set; }
        public string ADV { get; set; }
        public string M_rent { get; set; }
        public string M_Rent_Tax_Base { get; set; }
        public string balance_Advance { get; set; }
        public string AIT_Paid { get; set; }
        public string VT { get; set; }
        public string AT { get; set; }
        public string VT_Amt { get; set; }
        public string AIT_Amt { get; set; }
        public string R_Disc { get; set; }
        public string AIT_Disc { get; set; }
        public string VAT_Disc { get; set; }
        public string ADV_Disc { get; set; }
    }

    public class ViewRentPayeeDTO
    {
        public int RENT_PAYEEID { get; set; }
        public string PROJECT_ID { get; set; }
        public string Project_Name { get; set; }
        public string UNIT_ID { get; set; }
        public string UNIT_NAME { get; set; }
        public string LAND_ID { get; set; }
        public string LANDLORD_NAME { get; set; }
        public string PAYEE_NAME { get; set; }
        public string RELATION { get; set; }
        public string CASH { get; set; }
        public string M_BANK { get; set; }
        public string M_BANK_AMOUNT { get; set; }
        public string BANK_ID { get; set; }
        public string DISTRICT { get; set; }
        public string BRANCH { get; set; }
        public string ROU_NUM { get; set; }
        public string ACC_NUM { get; set; }
        public string AMOUNT { get; set; }
        public string STATUS { get; set; }
        public bool CREATED_BY { get; set; }
    }
    public class ViewTenorDTO
    {
        // public int Agreement_ID { get; set; }
        public string DateAdd { get; set; }
      
    }
    public class ViewRentDiscountDTO
    {
        public int Discount_ID { get; set; }
        public string External_ID { get; set; }
        public string Project_ID { get; set; }
        public string Project_Name { get; set; }
        public string Unit_ID { get; set; }
        public string UNIT_NAME { get; set; }
        public string Agreement_ID { get; set; }
        public string Start_DT { get; set; }
        public string End_DT { get; set; }
        public string Rent_Disc_Type { get; set; }
        public string Rent_Disc_Amount { get; set; }
        public string Adv_Adj_Type { get; set; }
        public string Adv_Adj_Amount { get; set; }
        public string AIT_CalType { get; set; }
        public string AIT_Amount { get; set; }
        public string Status { get; set; }
        public bool CREATED_BY { get; set; }
    }

    public class ViewModelDTO
    {
        public int AGREEMENT_ID { get; set; }
        public string STAMP_NO { get; set; }
        public string IMAGE_TITLE { get; set; }

        public string ImagePath { get; set; }
        public HttpPostedFileBase IMAGE_UPLOAD { get; set; }
    }
}

