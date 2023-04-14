using MVCWeb.UI.Models.DBFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.UI.Models.VM.UrunSatis
{
	public class SatisVM
	{
		public OrderVM OrderInfo { get; set; }
		public OrderDetailVM OrderDetailInfo { get; set; }
		public Products ProductList { get; set; }
		public List<SelectListItem> Employees { get; set; }
		public List<SelectListItem> Products { get; set; }
		public List<SelectListItem> Customers { get; set; }
		public List<SelectListItem> Shippers { get; set; }
	}
}
