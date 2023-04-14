using MVCWeb.UI.Models.VM.AccountVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWeb.UI.Models.DAL;

namespace MVCWeb.UI.Controllers
{
	public class AccountController : Controller
	{
		// GET: Account
		/*
         State management => cookie (her bilgi string olarak tutulur)

         */
		public ActionResult Index()
		{
			MyUserVM vm = new MyUserVM();
			if (Request.Cookies["bilgiler"] != null)
			{
				//inputlari doldur
				var httpCookie = Request.Cookies["bilgiler"];
				vm.FirstName = httpCookie.Values["username"];
			}
			return View(vm);
		}
		[HttpPost]
		public ActionResult Index(MyUserVM vm)
		{
			CalisanDAL calisanDal = new CalisanDAL();

			var girisYapanKullanici = calisanDal.EmployeeLogin(vm.FirstName, vm.LastName);

			if (string.IsNullOrEmpty(girisYapanKullanici))
			{
				ViewBag.HataMesaji = "Kullanıcı adı veya şifre hatalı";
				return View("Index", vm);
			}

			HttpCookie cookie = new HttpCookie("bilgiler");
			// beni unut yap cookileri sil! 
			//todo dbye gidip kullanici var mi kontrol et!
			if (vm.RememberMe)
			{
				//eger isaretli ise kullanici adi soyadi yas bilgisini hatirlamak istiyorum
				cookie.Expires = DateTime.Now.AddDays(1);
				cookie.Values.Add("username", vm.FirstName);
				HttpContext.Response.Cookies.Add(cookie);
			}
			else if (vm.ForgetMe)
			{
				cookie.Expires = DateTime.Now.AddDays(-1);
				HttpContext.Response.Cookies.Add(cookie);
			}
			return RedirectToAction("Index", "Satis");

		}

	}
}