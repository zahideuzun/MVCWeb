using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVCWeb.UI.Models.Validation;

namespace MVCWeb.UI.Models.VM.AccountVM
{
	public class MyUserVM
	{
		[Display(Name = "Kullanıcı Id")]
		public int Id { get; set; }
		[Display(Name = "Kullanıcı Adı")]
		[Required]
		[StringLength(24)]
		public string FirstName { get; set; }
		[Display(Name = "Kullanıcı Soyadı")]
		[Required]
		public string LastName { get; set; }
		[Display(Name = "Şifre")]
		[Required]
		public string Password { get; set; }
		[Display(Name = "Şu anki yaşınız")]
		[AgeControl(18,50)]
		public int Age { get; set; }
		public bool RememberMe { get; set; }
		public bool ForgetMe { get; set; }
	}
	[MetadataType(typeof(MyUserVM))]
	public partial class MyUser
	{

	}
}