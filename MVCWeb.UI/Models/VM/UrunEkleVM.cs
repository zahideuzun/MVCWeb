using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.UI.Models.VM
{
	public class UrunEkleVM
	{
		public string UrunAdi { get; set; }
		public decimal UrunFiyati { get; set; }
		public short StokMiktari { get; set; }
		public int Kategorisi { get; set; }
		public int Tedarikcisi { get; set; }


		public List<SelectListItem> KategoriListesi { get; set; }
		public List<SelectListItem> TedarikciListesi { get; set; }

	}
}