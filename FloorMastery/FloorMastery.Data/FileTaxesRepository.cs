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
    public class FileTaxesRepository : ITaxes
    {
        private string _path2file;

        public FileTaxesRepository(string path2file)
        {
            _path2file = path2file;
        }

        public List<Taxes> LoadTax()
        {
            List<Taxes> taxList = new List<Taxes>();

            if (File.Exists(_path2file))
            {
                using (StreamReader reader = new StreamReader(_path2file))
                {
                    reader.ReadLine();
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        Taxes tax = new Taxes();

                        string[] columns = line.Split(',');

                        tax.StateAbbreviation = columns[0];
                        tax.StateName = columns[1];
                        tax.TaxRate = decimal.Parse(columns[2]);

                        taxList.Add(tax);
                    }
                }

            }
            else
            {
                throw new Exception("File does not exist");
            }

            return taxList;
        }
    }
}
