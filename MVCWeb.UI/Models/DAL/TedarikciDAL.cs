using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCWeb.UI.Models.VM;

namespace MVCWeb.UI.Models.DAL
{
	public class TedarikciDAL
	{
		NorthwindEntities db = new NorthwindEntities();
		public List<TedarikciVM> TedarikciGetir()
		{
			return (from t in db.Suppliers
				select new TedarikciVM()
				{
					Id = t.SupplierID,
					TedarikciAdi = t.CompanyName
				}).ToList();

		}
	}
}