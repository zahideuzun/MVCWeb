using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCWeb.UI.Models.VM.UrunSatis;

namespace MVCWeb.UI.Models.DAL
{
	public class KargoDAL
	{
		NorthwindEntities db = new NorthwindEntities();
		public List<KargoVM> KargoSirketiListele()
		{
			return (from k in db.Shippers
				select new KargoVM()
				{
					KargoId = k.ShipperID,
					KargoAdi = k.CompanyName
				}).ToList();
		}
	}
}