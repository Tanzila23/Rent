using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIXED_ASSET.DTO
{
	public class NewCategoryDTO
	{
		public string eID { get; set; }
		public string sName { get; set; }
		public string dEsc { get; set; }
		public string cBy { get; set; }
		public bool sTatus { get; set; }
		//public DateTime cAt { get; set; }
		public string responseMessage { get; set; }
	}

	public class CategoryDTO
	{
		public int C_ID { get; set; }
		public string E_ID { get; set; }
		public int S_ID { get; set; }
		public int SEG_ID { get; set; }
		public string SHNAME { get; set; }
		public string Description { get; set; }
		public string Status { get; set; }
		public bool tST { get; set; }
		public string SEGEN_ID { get; set; }
	}
}