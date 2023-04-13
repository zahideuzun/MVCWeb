using MVCWeb.UI.Models.DAL;
using MVCWeb.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace MVCWeb.UI.Controllers
{
    public class KategoriIslemAjaxController : Controller
    {
		public ActionResult Index()
		{
			return View();
		}

		//Duzenle

		//[HttpGet]
		public ActionResult KategoriListele()
		{
			var values = JsonConvert.SerializeObject(new KategoriDAL().KategoriGetir());
			return Json(values, JsonRequestBehavior.AllowGet);
		}


		public ActionResult IdyeGoreKategoriGetir(int id)
		{
			KategoriVM gelenDataBilgisi = new KategoriDAL().IDBilgisineGoreKategoriBilgileriniGetir(id);
			var values = JsonConvert.SerializeObject(gelenDataBilgisi);
			return Json(values, JsonRequestBehavior.AllowGet);
		}


		[HttpPost]
		public ActionResult Ekle(KategoriVM kategoriVm)
		{
			int eklenenSatirSayisi = new KategoriDAL().KategoriyiVeriTabanınaEkle(kategoriVm);

			if (eklenenSatirSayisi > 0)
			{
				var values = JsonConvert.SerializeObject(kategoriVm);
				return Json(values);
			}
			return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

		}
		//public ActionResult KategoriSil(int id)
		//{

		//	int silinecekKategoriBilgisi = new KategoriDAL().KategoriSil(id);
		//	if (silinecekKategoriBilgisi > 0)
		//	{
				
		//	}
		//	return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
		//}
	}
}