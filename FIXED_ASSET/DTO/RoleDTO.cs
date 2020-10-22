using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIXED_ASSET.DTO
{
	public class RoleDTO
	{
		public int R_ID { get; set; }
		public string RNAME { get; set; }
		public bool STATUS { get; set; }
	}



	public class RoleEmpDTO
	{
		public int RoleID { get; set; }
		public int EmpID { get; set; }
	}
}