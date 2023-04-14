using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWeb.UI.Models.VM
{
	public class DBProductAddVM
	{
		public string UrunAdi { get; set; }
		public decimal UrunFiyati { get; set; }
		public short StokMiktari { get; set; }
		public int Kategorisi { get; set; }
		public int Tedarikcisi { get; set; }

	}
}