using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCWeb.UI.Models.DBFirst;
using MVCWeb.UI.Models.VM;
using MVCWeb.UI.Models.VM.UrunSatis;

namespace MVCWeb.UI.Mapping.SatisMapping
{
	public class SatisVMMapping
	{
		public Orders OrderVMToOrder(OrderVM donusturulecekOrderVm)
		{
			return new Orders()
			{
				OrderID = donusturulecekOrderVm.OrderID,
				CustomerID = donusturulecekOrderVm.CustomerID,
				OrderDate = donusturulecekOrderVm.OrderDate,
				RequiredDate = donusturulecekOrderVm.RequiredDate,
				ShippedDate = donusturulecekOrderVm.ShippedDate,
				ShipVia = donusturulecekOrderVm.ShipVia,
				Freight = donusturulecekOrderVm.Freight,
				EmployeeID = donusturulecekOrderVm.EmployeeID,
			};
		}

		public void OrderToOrderVM()
		{

		}

		public void OrderDetailToOrderDetailVM()
		{

		}

		public Order_Details OrderDetailVMToOrderDetail(OrderDetailVM donusturulecekDetayVm)
		{
			return new Order_Details()
			{
				OrderID = donusturulecekDetayVm.OrderID,
				ProductID = donusturulecekDetayVm.ProductID,
				UnitPrice = donusturulecekDetayVm.UnitPrice,
				Quantity = donusturulecekDetayVm.Quantity,
				Discount = donusturulecekDetayVm.Discount,
			};
		}
	}
}