using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIXED_ASSET.DTO
{
    public class ViewDepartmentDTO
    {
        public int DEPT_ID { get; set; }
        public string EXTERNAL_ID { get; set; }
        public string DESCRIPTION { get; set; }
        public string CODE { get; set; }
        public string STATUS { get; set; }
        public bool CREATED_BY { get; set; }
    }
}