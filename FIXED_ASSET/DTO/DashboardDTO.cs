using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIXED_ASSET.DTO
{
	public class DashboardDTO
	{
		public string CHANNEL { get; set; }
		public int CID { get; set; }
		public string Category { get; set; }
		public int FULL_QTY { get; set; }
		public int FULL_COST { get; set; }
		public int FULL_AMOUNT { get; set; }
	}
}