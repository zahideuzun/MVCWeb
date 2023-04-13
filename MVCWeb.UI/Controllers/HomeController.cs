using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.UI.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home

		/*
         rooting  => adres çubuğu =query string 


         */

		[HttpGet]// server a gelen ilk istek.
		public ActionResult Index()
		{
			Koydol();

			return View();
		}
		[NonAction]
		public void Koydol()
		{

		}

		//http verb  get,post,put,delete,trace,option,head
		[HttpGet]// server a gelen ilk istek.
		public string Index2()
		{
			return "hello MVC ";
		}
	}
}