using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWeb.UI.Models.DAL;
using MVCWeb.UI.Models.DBFirst;
using MVCWeb.UI.Models.VM;

namespace MVCWeb.UI.Controllers
{
    public class KategoriIslemController : Controller
    {
		public KategoriIslemController()
		{
		}

		//post-back ?
		// GET: KategoriIslem
		//public ActionResult Index()
		//{
		//	return View(new KategoriDAL().KategoriGetir()/*.OrderBy(a=>a.ID)*/);
		//}

		//[HttpPost]
		public ActionResult Index(KategoriVM kategori)
		{
			if (ModelState.IsValid)
			{
				if (HttpContext.Request.HttpMethod == "POST")
				{
					int eklenenSatirSayisi = new KategoriDAL().KategoriyiVeriTabanınaEkle(kategori);
					if (eklenenSatirSayisi > 0)
					{
						return RedirectToAction("Index");
					}
					return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
				}
			}

			return View(new KategoriDAL().KategoriGetir());
		}

		public ActionResult Duzenle(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
			}

			KategoriVM gelenDataBilgisi = new KategoriDAL().IDBilgisineGoreKategoriBilgileriniGetir(id);
			if (gelenDataBilgisi == null)
			{
				return HttpNotFound();
			}
			return View(gelenDataBilgisi);
		}

		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Duzenle(KategoriVM vm)
		{
			int eklenenSAtirSayisi = new KategoriDAL().KategoriyiVeriTabanındaDuzenle(vm);
			#region MyRegion
			//return eklenenSAtirSayisi > 0
			//    ? RedirectToAction("Index")
			//    : new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest); 
			#endregion

			if (eklenenSAtirSayisi > 0)
			{
				return RedirectToAction("Index");
			}
			return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
		}

		public ActionResult Ekle()
		{
			return View();
		}

		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Ekle(KategoriVM kategoriVm)
		{
			int eklenenSatirSayisi = new KategoriDAL().KategoriyiVeriTabanınaEkle(kategoriVm);

			if (eklenenSatirSayisi > 0)
			{
				return RedirectToAction("Index");
			}
			return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

		}

		public ActionResult KategoriSil(int id)
		{
			
			int silinecekKategoriBilgisi = new KategoriDAL().KategoriSil(id);
			if (silinecekKategoriBilgisi > 0)
			{
				return RedirectToAction("Index");
			}
			return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
		}
	}
}