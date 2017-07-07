using FloorMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.Models;

namespace FloorMastery.Data
{
    public class ProductRepository : IProduct
    {
        public List<Products> ListProducts()
        {
            List<Products> prodList = new List<Products>();

            prodList.Add(new Products() { ProductType="Carpet", CostPerSquareFoot=2.25M, LaborCostPerSquareFoot=2.10M });
            prodList.Add(new Products() { ProductType = "Laminate", CostPerSquareFoot = 1.75M, LaborCostPerSquareFoot = 2.10M });
            prodList.Add(new Products() { ProductType = "Tile", CostPerSquareFoot = 3.50M, LaborCostPerSquareFoot = 4.15M });
            prodList.Add(new Products() { ProductType = "Wood", CostPerSquareFoot = 5.15M, LaborCostPerSquareFoot = 4.75M });

            return prodList;
        }
    }
}
