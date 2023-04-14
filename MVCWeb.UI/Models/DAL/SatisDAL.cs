using MVCWeb.UI.Models.DBFirst;
using MVCWeb.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Transactions;
using System.Web;
using MVCWeb.UI.Mapping.SatisMapping;
using MVCWeb.UI.Models.VM.UrunSatis;
using MVCWeb.UI.Result;

namespace MVCWeb.UI.Models.DAL
{
	public static class SatisDAL
	{
		public static MyResult SatisYap(SatisVM satis)
		{
			using (TransactionScope scope = new TransactionScope())
			{
				try
				{
					using (NorthwindEntities db = new NorthwindEntities())
					{
						var stokMiktari = db.Products.SingleOrDefault(x=>x.ProductID==satis.OrderDetailInfo.ProductID).UnitsInStock;

						if (stokMiktari<=satis.OrderDetailInfo.Quantity)
						{
							return new MyResult()
							{
								isSuccess = false,
								message = "Stok Yetersiz!!!"
							};
						}

						Orders eklenmisSiparis = db.Orders.Add(new SatisVMMapping().OrderVMToOrder(satis.OrderInfo));
						satis.OrderDetailInfo.OrderID = eklenmisSiparis.OrderID;
						db.Order_Details.Add(new SatisVMMapping().OrderDetailVMToOrderDetail(satis.OrderDetailInfo));

						var guncellenecekUrunBilgisi = db.Products.Where(a => a.ProductID == satis.OrderDetailInfo.ProductID).SingleOrDefault();
						guncellenecekUrunBilgisi.UnitsInStock -= satis.OrderDetailInfo.Quantity;

						UrunDAL urunDal = new UrunDAL();
						
						var guncellenecekUrun = db.Products.Where(p => p.ProductID == satis.OrderDetailInfo.ProductID)
							.SingleOrDefault();
						urunDal.StoktanDusur(Convert.ToInt32(guncellenecekUrun.UnitsInStock), satis.OrderDetailInfo.Quantity);

						
						db.SaveChanges();
					}
					
					scope.Complete();

					return new MyResult()
					{
						message = "Ürün Satın Alındı.",
						isSuccess = true,
					};
				}
				catch (Exception e)
				{
					scope.Dispose();
					return new MyResult()
					{
						message = e.ToString(),
						isSuccess = false,
					};
				}
			}
			
		}
	}
}