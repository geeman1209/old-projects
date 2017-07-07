using FloorMastery.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            string Orderpath = @"C:\Data\";
            string Productpath = @"C:\Data\Products.txt";
            string Taxespath = @"C:\Data\Taxes.txt";

            switch (mode)
            {
                case "OrderTest":
                    return new OrderManager(new OrderRepository(), new ProductRepository(), new TaxesRepository());
                case "FileProduction":
                    return new OrderManager(new FileOrderRepository(Orderpath), new FileProductRepository(Productpath), new FileTaxesRepository(Taxespath));
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
