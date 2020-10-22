using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIXED_ASSET.DTO
{
    public class ClassificationDTO
    {
        public string eID { get; set; }
        public string code { get; set; }
        public string dEsc { get; set; }
        public string cBy { get; set; }
        public bool sTatus { get; set; }
        //public DateTime cAt { get; set; }
        public string sT { get; set; }
    }
    public class ViewClassificationDTO
    {
        public int CLASS_ID { get; set; }
        public string EXTERNAL_ID { get; set; }
        public string DESCRIPTION { get; set; }
        public string CODE { get; set; }
        public string STATUS { get; set; }
        public bool CREATED_BY { get; set; }
        
    }
    public class CountryDTO
    {
        public int Country_ID { get; set; }
        public string Country_Name { get; set; }
    }
    public class CityDTO
    {
        public int City_ID { get; set; }
        public string City_Name { get; set; }
        public int Country_ID { get; set; }
    }
    public class VendorDTO
    {
        public int Bank_ID { get; set; }
        public string Bank_Name { get; set; }
        public int District_Code { get; set; }
        public string District_Name { get; set; }
        public string Branch_Code { get; set; }
        public string Branch_Name { get; set; }
    }
    //public class ViewModelDTO
    //{
    //   public IEnumerable<HttpPostedFileBase> FileBases { get; set; }
    //}
}