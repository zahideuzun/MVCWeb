using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWeb.UI.Models.DAL;
using MVCWeb.UI.Models.VM.UrunSatis;

namespace MVCWeb.UI.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        public ActionResult Index()
        {
            SatisVM vm = new SatisVM();
            vm.Products = UrunListesineDonustur();
            vm.Shippers = KargoListesineDonustur();
            vm.Customers = MusteriListesineDonustur();
            
			return View(vm);
        }

		[NonAction]
		private List<SelectListItem> MusteriListesineDonustur()
		{
			var musteriVm = new SatisVM();
			musteriVm.Customers = new MusteriDAL().MusterileriListele()
				.Select(mv => new SelectListItem()
				{
					Value = mv.Id.ToString(),
					Text = mv.CompanyName
				}).ToList();
			return musteriVm.Customers;
		}

		[NonAction]
		private List<SelectListItem> KargoListesineDonustur()
		{
			var kargoVm = new SatisVM();
			kargoVm.Shippers= new KargoDAL().KargoSirketiListele()
				.Select(kv => new SelectListItem()
				{
					Value = kv.KargoId.ToString(),
					Text = kv.KargoAdi
				}).ToList();
			return kargoVm.Shippers;
		}

		[NonAction]
		private List<SelectListItem> UrunListesineDonustur()
		{
			var satisVm = new SatisVM();
			satisVm.Products = new UrunDAL().UrunleriListele()
				.Select(uv => new SelectListItem()
				{
					Value = uv.UrunId.ToString(),
					Text = uv.UrunAdi
				}).ToList();
			return satisVm.Products;
		}
		
		[HttpPost]
        public ActionResult Index(SatisVM satis)
        {
	        if (ModelState.IsValid)
	        {
		        SatisDAL.SatisYap(satis);
	        }
            //dbye ekle
            return RedirectToAction("Index");
        }
        

	}
}