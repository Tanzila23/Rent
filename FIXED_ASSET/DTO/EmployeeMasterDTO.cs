using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIXED_ASSET.DTO
{
	public class EmployeeMasterDTO
	{
		public long EMP_ID { get; set; }
		public string Name { get; set; }
		public int R_ID { get; set; }
		public bool Status { get; set; }
	}

	public class EmployeeDTO
	{
		public int EMP_ID { get; set; }
		public string Name { get; set; }
		public string Role_ID { get; set; }
		public string RNAME { get; set; }
		public string Assigned_BU_ID { get; set; }
		[DataType(DataType.Date)]
		public DateTime Start_Date { get; set; }
		[DataType(DataType.Date)]
		public DateTime End_Date { get; set; }
		//public int R_ID { get; set; }
	}
}