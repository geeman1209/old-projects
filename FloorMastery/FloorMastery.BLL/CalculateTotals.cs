using FloorMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery.BLL
{
    public class CalculateTotals
    {

        public decimal MaterialCost(Order order) {
           return order.MaterialCost =  order.CostPerSquareFoot * order.Area;
        }

        public decimal LaborCost(Order order) {
           return  order.LaborCost = order.LaborCostPerSquareFoot * order.Area;
        }

        public decimal Tax(Order order) {
            return order.Tax = ((order.LaborCost + order.MaterialCost)* (order.TaxRate/100));           
        }

        public decimal Total(Order order) {
            return order.Total = order.MaterialCost + order.LaborCost + order.Tax;     
        }
    }
}
