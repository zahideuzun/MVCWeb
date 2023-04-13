using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWeb.UI.Models;

namespace MVCWeb.UI.Controllers
{
    public class DefaultController : Controller
    {
		// GET: Default
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
	}
}