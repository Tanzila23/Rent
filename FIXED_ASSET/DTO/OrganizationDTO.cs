using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIXED_ASSET.DTO
{
	public class OrganizationDTO
	{
		public OrganizationDTO()
		{
			this.Organizations = new List<SelectListItem>();
		}

		public string Organization_Type { get; set; }
		public int Organization_ID { get; set; }
		public string Area_ID { get; set; }
		public string External_ID { get; set; }
		public string Organization_Name { get; set; }
		public int? Organization_TypeID { get; set; }
		public int Root_ID { get; set; }
		public int Company_ID { get; set; }
		public int Address_ID { get; set; }
		public int Contact_ID { get; set; }
		public string Email_ID { get; set; }
		public int Grade { get; set; }
		public string Website { get; set; }
		public string VatRegNo { get; set; }
		public int Instance_ID { get; set; }
		public string Created_By { get; set; }
		public DateTime Created_at { get; set; }


		public List<SelectListItem> Organizations { get; set; }


		public int Sequence { get; set; }
	}
}