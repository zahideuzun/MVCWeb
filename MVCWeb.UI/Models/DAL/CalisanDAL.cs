using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCWeb.UI.Models.VM;
using MVCWeb.UI.Models.VM.UrunSatis;

namespace MVCWeb.UI.Models.DAL
{
	public class CalisanDAL
	{
		NorthwindEntities db = new NorthwindEntities();
		public List<EmployeeVM> CalisanlariListele()
		{
			return (from e in db.Employees
				select new EmployeeVM()
				{
					Id = e.EmployeeID,
					FirstName = e.FirstName,
					LastName = e.LastName,
				}).ToList();
		}

		public string EmployeeLogin(string kullaniciAdi, string kullaniciSoyad)
		{
			string kullaniciLogin = db.Employees
				.SingleOrDefault(e => e.FirstName == kullaniciAdi && e.LastName ==kullaniciSoyad ).FirstName;
			return kullaniciLogin;
		}
	}
}