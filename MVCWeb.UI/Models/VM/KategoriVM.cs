using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWeb.UI.Models.VM
{
	public class KategoriVM
	{
		[Key]
		public int ID { get; set; }
		//[Display(Name ="Kategori Adını Giriniz.")]
		public string KategoriAdi { get; set; }
		[Required]
		public string KategoriAciklama { get; set; }

		public bool IsActive { get; set; } = true;

	}
}