using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIXED_ASSET.DTO
{
	public class SubCategoryDTO
	{
		public int S_ID { get; set; }
		public int C_ID { get; set; }
		public string SEN_ID { get; set; }
		public string SHNAME { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
		public string Status { get; set; }
	}
}