using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using MVCWeb.UI.Models.DBFirst;
using MVCWeb.UI.Models.VM;

namespace MVCWeb.UI.Models.DAL
{
	public class UrunDAL
	{
		NorthwindEntities db = new NorthwindEntities();

		public bool UrunBilgileriyleEklemeYap(DBProductAddVM vm)
		{
			db.Products.Add(new Products()
			{
				CategoryID = vm.Kategorisi,
				UnitsInStock = vm.StokMiktari,
				ProductName = vm.UrunAdi,
				UnitPrice = vm.UrunFiyati,
				SupplierID = vm.Tedarikcisi
			});
			return db.SaveChanges() > 0;
		}

		public List<UrunVM> UrunleriListele()
		{
			return (from p in db.Products
					where p.UnitsInStock >0
				select new UrunVM()
				{
					UrunId = p.ProductID,
					UrunAdi = p.ProductName
				}).ToList();
		}

		public int StoktanDusur(int productId, short quantity)
		{
			var product = db.Products.FirstOrDefault(p => p.ProductID == productId);
			if (product != null)
			{
				product.UnitsInStock -= quantity;

				return db.SaveChanges();
			}

			return 0;
		}
		public UrunVM UrunBilgisiniGetir(int urunId)
		{
			var urun = db.Products.FirstOrDefault(p => p.ProductID == urunId);
			if (urun != null)
			{
				return new UrunVM
				{
					UrunId = urun.ProductID,
					UrunAdi = urun.ProductName,
					UrunStok = urun.UnitsInStock,
					UrunFiyati = urun.UnitPrice
				};
			}
			return null;
		}

	}
}