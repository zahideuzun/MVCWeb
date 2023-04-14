using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCWeb.UI.Models.VM;

namespace MVCWeb.UI.Models.DAL
{
	public class MusteriDAL
	{
		NorthwindEntities db = new NorthwindEntities();
		public List<CustomerVM> MusterileriListele()
		{
			return (from m in db.Customers
				select new CustomerVM()
				{
					Id = m.CustomerID,
					CompanyName = m.CompanyName
				}).ToList();
		}
	}
}