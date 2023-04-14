using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVCWeb.UI.Models.VM;
using MVCWeb.UI.Models.DBFirst;
using System.Data.Entity;

namespace MVCWeb.UI.Models.DAL
{
	public class KategoriDAL
	{
		NorthwindEntities db = new NorthwindEntities();
		public List<KategoriVM> KategoriGetir()
		{
			return (from c in db.Categories
					where c.IsActive == true
					orderby c.CategoryID
					select new KategoriVM()
					{
						ID = c.CategoryID,
						KategoriAdi = c.CategoryName,
						KategoriAciklama = c.Description,
					}).ToList();

		}
		public KategoriVM IDBilgisineGoreKategoriBilgileriniGetir(int? kategoriID)
		{
			var hede = db.Categories
				.Where(a => a.CategoryID == kategoriID)
				.Select(a => new KategoriVM() { ID = a.CategoryID, KategoriAdi = a.CategoryName, KategoriAciklama = a.Description})
				.SingleOrDefault();
			return hede;
		}

		public int KategoriyiVeriTabanınaEkle(KategoriVM kategori)
		{
			db.Categories.Add(new Categories()
			{
				CategoryName = kategori.KategoriAdi,
				Description = kategori.KategoriAciklama,
				IsActive = kategori.IsActive
			});
			return db.SaveChanges();
		}

		public int KategoriyiVeriTabanındaDuzenle(KategoriVM duzenlenmisData)
		{
			// attach
			var kategori = db.Categories.Find(duzenlenmisData.ID);
			db.Categories.Attach(kategori);
			//db.Entry(kategori).Property(x => x.CategoryName).IsModified = true;
			db.Entry(kategori).State = EntityState.Modified;
			kategori.CategoryName = duzenlenmisData.KategoriAdi;

			return db.SaveChanges();
		}

		public int KategoriSil(int id)
		{
			var kategori = db.Categories.Find(id);
			kategori.IsActive = false;
			db.Entry(kategori).State = EntityState.Modified;
			return db.SaveChanges();
		}
	}
}