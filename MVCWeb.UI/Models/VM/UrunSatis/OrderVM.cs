using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.UI.Models.VM
{
	public class OrderVM
	{
		public int OrderID { get; set; }
		public string CustomerID { get; set; }
		public DateTime OrderDate { get; set; } = DateTime.Now;
		public DateTime RequiredDate { get; set; }
		public DateTime ShippedDate { get; set; } = DateTime.Now;
		public int ShipVia { get; set; }
		public decimal Freight { get; set; }
		public int EmployeeID { get; set; }
		public decimal TotalPrice { get; set; }

	}
}