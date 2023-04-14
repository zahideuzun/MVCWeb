using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MVCWeb.UI.Models.DBFirst;
using MVCWeb.UI.Models.VM;
using MVCWeb.UI.Models.VM.UrunSatis;

namespace MVCWeb.UI.Mapping.MyAutoMapping
{
	public class MapProfile : Profile
	{

		public Mapper CustomerToCustomerVM()
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<Customers, CustomerVM>()
					.ForMember(cusVm => cusVm.Id, customer => customer.MapFrom(a => a.CustomerID))
					.ForMember(cusVm => cusVm.CompanyName, customer => customer.MapFrom(a => a.CompanyName)));

			return new Mapper(config);

		}

		public Mapper CustomerVMToCustomer()
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<CustomerVM, Customers>()
					.ForMember(customer => customer.CustomerID, cusVm => cusVm.MapFrom(a => a.Id))
					.ForMember(customer => customer.CompanyName, cusVm => cusVm.MapFrom(a => a.CompanyName)));
			return new Mapper(config);
		}
	}
}