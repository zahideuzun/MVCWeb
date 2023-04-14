using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWeb.UI.Models.VM
{
	public class UrunVM
	{
		public int UrunId { get; set; }
		public string UrunAdi { get; set; }
		public short? UrunStok { get; set; }
		public decimal? UrunFiyati { get; set; }
	}
}