using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIXED_ASSET.DTO
{
	public class SegmentDTO
	{
		public int S_ID { get; set; }
		public int SEG_ID { get; set; }
        public string SEGEN_ID { get; set; }
        public string SHORTNAME { get; set; }
		public string Description { get; set; }
        public string CLASS_NAME { get; set; }
        public string CAT_ID { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string CATEGORY_NAME { get; set; }
        public string Status { get; set; }
        public bool CREATED_BY { get; set; }
       
    }
}