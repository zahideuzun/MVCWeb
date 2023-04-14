using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWeb.UI.Models;
using MVCWeb.UI.Models.DAL;
using MVCWeb.UI.Models.VM;

namespace MVCWeb.UI.Controllers
{
	public class DefaultController : Controller
	{
		// GET: Default

		public ActionResult ToolBox002()
		{
			return View(new SoftwareVM() { Id = 1, Key = "C#", Value = "kfhjkhdfg" });
		}
		public ActionResult MyDropDownListFor()
		{
			//List<SehirVM> sehirler = new List<SehirVM>()
			//{
			//	new SehirVM(){SehirAdi = "izmir", SehirId = 1},
			//	new SehirVM(){SehirAdi = "ankara", SehirId = 2},
			//	new SehirVM(){SehirAdi = "adana", SehirId = 3},

			//};
			//ViewBag.sehirler = new SelectList(sehirler, "SehirId", "SehirAdi");

			//return View(new SehirVM()
			//{
			//	SehirAdi = "malatya",
			//	SehirId = 22
			//});
			return View();
		}

		[HttpPost]
		public ActionResult MyDropDownListFor(SehirVM vm)
		{
			return RedirectToAction("MyDropDownListFor");
		}

		public ActionResult Index()
		{
			// string[] hede = {"melike","bekir","berkan" };

			//viewdata view bag, temp data , tupples,object data(view)

			ViewData["isim"] = "melike";
			ViewBag.hede = "melike";
			TempData.Add("isim", "melike");

			Person p = new Person();
			p.Ad = "bekir";
			p.Soyad = "hede";

			return View(p);
			//return Json(null); ;
			//return PartialView(); 
			//return Content("");
		}
		//snipped
		public ActionResult Index2()
		{
			var hede = TempData["isim"];
			return View();
		}

		/// <summary>
		/// adi,fiyati,stok miktari,kategorisi,tedarikcisi
		/// kategorisi: adi id
		/// tedarikcisi: adi id
		/// </summary>
		/// <returns></returns>
		public ActionResult UrunEkle()
		{
			ViewBag.hede = "onay";
			return View(new UrunEkleVM()
			{
				KategoriListesi = KategoriListesineDonustur(),
				TedarikciListesi = TedarikciListesineDonustur()
			});
		}

		[NonAction]
		private List<SelectListItem> TedarikciListesineDonustur()
		{
			return new TedarikciDAL().TedarikciGetir()
				.Select(tv => new SelectListItem()
				{
					Value = tv.Id.ToString(),
					Text = tv.TedarikciAdi
				}).ToList();
		}

		[NonAction]
		private List<SelectListItem> KategoriListesineDonustur()
		{
			return new KategoriDAL().KategoriGetir()
				.Select(kv => new SelectListItem { Value = kv.ID.ToString(), Text = kv.KategoriAdi })
				.ToList();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult UrunEkle(UrunEkleVM vm)
		{
			#region MyRegion
			//bool b = new UrunDAL().UrunBilgileriyleEklemeYAP(new DBProductAddVM()
			//{
			//    UrunFiyati = vm.UrunFiyati,
			//    Kategorisi = vm.Kategorisi,
			//    StokMiktari = vm.StokMiktari,
			//    Tedarikcisi = vm.Tedarikcisi,
			//    UrunAdi = vm.UrunAdi
			//});
			// return b == true ? RedirectToAction("UrunEkle") : RedirectToAction("Index"); 
			#endregion

			if (!ModelState.IsValid)
			{
				//varsa burada hata sayfasina yönlendirilir
				return RedirectToAction("Index");
			}

			return RedirectToAction(new UrunDAL().UrunBilgileriyleEklemeYap(new DBProductAddVM()
			{
				UrunFiyati = vm.UrunFiyati,
				Kategorisi = vm.Kategorisi,
				StokMiktari = vm.StokMiktari,
				Tedarikcisi = vm.Tedarikcisi,
				UrunAdi = vm.UrunAdi
			}) ? "UrunEkle" : "Index");

		}
	}
}