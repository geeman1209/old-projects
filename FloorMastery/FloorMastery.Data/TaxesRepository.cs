using FloorMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.Models;

namespace FloorMastery.Data
{
    public class TaxesRepository : ITaxes
    {
        private static Taxes _tax = new Taxes
        {
            StateAbbreviation = "OH",
            StateName = "Ohio",
            TaxRate = 6.25M
        };
        private static Taxes _tax2 = new Taxes
        {
            StateAbbreviation = "PA",
            StateName = "Pennsylvania",
            TaxRate = 6.75M
        };
        private static Taxes _tax3 = new Taxes
        {
            StateAbbreviation = "MI",
            StateName = "Michigan",
            TaxRate = 5.75M
        };
        private static Taxes _tax4 = new Taxes
        {
            StateAbbreviation = "IN",
            StateName = "Indiana",
            TaxRate = 6.00M
        };
        public List<Taxes> LoadTax()
        {
            List<Taxes> taxList = new List<Taxes>();

            taxList.Add(_tax);
            taxList.Add(_tax2);
            taxList.Add(_tax3);
            taxList.Add(_tax4);

            return taxList;
        }
    }
}
