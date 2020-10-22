using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIXED_ASSET.DTO
{
    public class ViewSegmentDTO
    {
        public int SEG_ID { get; set; }
        public string EXTERNAL_ID { get; set; }
        public string SEGMENT_NAME { get; set; }
        public string CODE { get; set; }
        public string CLASS_ID { get; set; }
        public string CLASS_NAME { get; set; }
        public string CAT_ID { get; set; }
        public string CATEGORY_NAME { get; set; }
        public string STATUS { get; set; }
        public bool CREATED_BY { get; set; }
    }
}