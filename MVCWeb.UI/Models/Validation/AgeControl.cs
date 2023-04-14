using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWeb.UI.Models.Validation
{
	public class AgeControl : ValidationAttribute
	{
		private int _yasBaslangic = 0;
		private int _yasBitis = 0;
		public AgeControl(int yasBaslangic, int yasBitis)
		{
			_yasBaslangic = yasBaslangic;
			_yasBitis = yasBitis;
		}

		public override bool IsValid(object value)
		{
			int gelenDeger = Convert.ToInt32(value);
			if (gelenDeger<_yasBaslangic || gelenDeger > _yasBitis)
			{
				//hata
				ErrorMessage = "belirtilen aralik disinda bir deger girilmeye calisildi!";
				return false;
			}
			return true;
		}
	}
}