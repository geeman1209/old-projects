using FloorMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.Models;
using System.IO;

namespace FloorMastery.Data
{
    public class FileProductRepository : IProduct
    {
        private string _path2file;

        public FileProductRepository(string path2file)
        {
            _path2file = path2file;
        }

        public List<Products> ListProducts()
        {
            List<Products> products = new List<Products>();

            if (File.Exists(_path2file))
            {
                using (StreamReader reader = new StreamReader(_path2file))
                {
                    reader.ReadLine();
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        Products product = new Products();

                        string[] columns = line.Split(',');

                        product.ProductType = columns[0];
                        product.CostPerSquareFoot = decimal.Parse(columns[1]);
                        product.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                        products.Add(product);
                    }
                }
              
            }
            else
            {
                throw new Exception("File does not exist");
            }

            return products;
        }
    }
}
