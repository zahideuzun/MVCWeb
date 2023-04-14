using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCWeb.UI.Models.DBFirst;

namespace MVCWeb.UI.Models.VM.UrunSatis
{
	public class OrderDetailVM
	{
		public int OrderID { get; set; }
		public int ProductID { get; set; }
		public decimal UnitPrice { get; set; }
		public short Quantity { get; set; }
		public float Discount { get; set; }
		
	
	}
}