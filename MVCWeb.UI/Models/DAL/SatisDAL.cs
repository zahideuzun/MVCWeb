using MVCWeb.UI.Models.DBFirst;
using MVCWeb.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using MVCWeb.UI.Mapping.SatisMapping;
using MVCWeb.UI.Models.VM.UrunSatis;

namespace MVCWeb.UI.Models.DAL
{
	public static class SatisDAL
	{
		public static void SatisYap(SatisVM satis)
		{
			using (TransactionScope scope = new TransactionScope())
			{
				try
				{
					using (NorthwindEntities db = new NorthwindEntities())
					{
						Orders eklenmisSiparis = db.Orders.Add(new SatisVMMapping().OrderVMToOrder(satis.OrderInfo));
						satis.OrderDetailInfo.OrderID = eklenmisSiparis.OrderID;
						db.Order_Details.Add(new SatisVMMapping().OrderDetailVMToOrderDetail(satis.OrderDetailInfo));
						

						UrunDAL urunDal = new UrunDAL();
						
						var guncellenecekUrun = db.Products.Where(p => p.ProductID == satis.OrderDetailInfo.ProductID)
							.SingleOrDefault();
						urunDal.StoktanDusur(Convert.ToInt32(guncellenecekUrun.UnitsInStock), satis.OrderDetailInfo.Quantity);
						
						db.SaveChanges();
					}
					
					scope.Complete();
				}
				catch (Exception e)
				{
					scope.Dispose();
				}
			}
			
			
			
		}

	}
}