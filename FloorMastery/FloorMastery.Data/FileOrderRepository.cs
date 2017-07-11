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
   public class FileOrderRepository : IOrder
    {
        private string _path2file = @"C:\Data\";
        private string _formattedPath;

        public FileOrderRepository(string path2file)
        {
            _path2file = path2file;
        }
        public Order AddOrder(Order order, DateTime orderDate)
        {
            _formattedPath = CreateFormattedFile(orderDate);
            List<Order> orders = ShowOrders(orderDate);
            if(orders == null)
            {
                 orders = new List<Order>();
            }

            if (!File.Exists(_formattedPath))
            {
                CreateFormattedFile(orderDate);
                order.OrderNumber = 1;
            }
            else
            {
                order.OrderNumber = orders.Max(o => o.OrderNumber) + 1;
            }

            orders.Add(order);
            CreateFile(orders);
            return order;
        }

        public void DeleteOrder(DateTime orderDate, int orderNumber)
        {
            List<Order> orders = ShowOrders(orderDate);

            Order order = orders.Find(o => o.OrderNumber == orderNumber);

            orders.Remove(order);

            Order firstOrder = orders.Find(o => o.OrderNumber == 1);

            if (orders.Count > 0)
            {
                if(orders.Exists(o => o.OrderNumber == 1))
                {
                    firstOrder.OrderNumber = 1;
                }
                else
                {
                    foreach (var ord in orders)
                    {
                        --ord.OrderNumber;
                    }
                }
            }

            CreateFile(orders);
        }

        public void CreateEditOrder(List<Order> orders)
        {
                CreateFile(orders);
        }

        public Order FindIndivOrder(int orderNumber, DateTime date)
        {
            Order order = new Order();
            List<Order> orders = ShowOrders(date);

            order = orders.Find(o => o.OrderNumber == orderNumber);

            return order;
        }

        public List<Order> ShowOrders(DateTime orderDate)
        {
            _formattedPath = CreateFormattedFile(orderDate);
            List<Order> orders = new List<Order>();

            if (File.Exists(_formattedPath))
            {
                using (StreamReader reader = new StreamReader(_formattedPath))
                {
                    reader.ReadLine();
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        Order newOrder = new Order();

                        string[] columns = line.Split(',');

                        newOrder.OrderNumber = int.Parse(columns[0]);
                        newOrder.CustomerName = columns[1];
                        newOrder.State = columns[2];
                        newOrder.TaxRate = decimal.Parse(columns[3]);
                        newOrder.ProductType = columns[4];
                        newOrder.Area = decimal.Parse(columns[5]);
                        newOrder.CostPerSquareFoot = decimal.Parse(columns[6]);
                        newOrder.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                        newOrder.MaterialCost = decimal.Parse(columns[8]);
                        newOrder.LaborCost = decimal.Parse(columns[9]);
                        newOrder.Tax = decimal.Parse(columns[10]);
                        newOrder.Total = decimal.Parse(columns[11]);

                        orders.Add(newOrder);
                    }
                }

            }
            else
            {
                return null;
            }
            return orders;
        }
        private void CreateFile(List<Order> Order)
        {
            if (File.Exists(_formattedPath))
                File.Delete(_formattedPath);

            using (StreamWriter writer = new StreamWriter(_formattedPath))
            {
                writer.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                foreach(var order in Order)
                {
                    writer.WriteLine(CreateOrderLine(order));
                }
            }
        }

        private string CreateOrderLine(Order order)
        {
            decimal formattedMaterials = Convert.ToDecimal(string.Format("{0:0.00}", order.MaterialCost));
            decimal formattedLabor = Convert.ToDecimal(string.Format("{0:0.00}", order.LaborCost));
            decimal formattedTax = Convert.ToDecimal(string.Format("{0:0.00}", order.Tax));
            decimal formattedTotal = Convert.ToDecimal(string.Format("{0:0.00}", order.Total));

            return string.Format($"{order.OrderNumber},{order.CustomerName.ToString()},{order.State.ToString()},{order.TaxRate},{order.ProductType.ToString()},{order.Area},{order.CostPerSquareFoot},{order.LaborCostPerSquareFoot},{formattedMaterials},{formattedLabor},{formattedTax},{formattedTotal}");
        }

        private string CreateFormattedFile(DateTime orderDate)
        {
            string formattedPath = Path.Combine(_path2file, string.Format("Orders_{0:MMddyyyy}.txt", orderDate));
            return formattedPath;
        }

        public Order EditOrder(DateTime orderDate, Order order)
        {
            _formattedPath = CreateFormattedFile(orderDate);

            List<Order> orders = ShowOrders(orderDate);
            int orderLocation = orders.FindIndex(o => o.OrderNumber == order.OrderNumber);
            orders[orderLocation] = order;
            CreateEditOrder(orders);
            return order;
        }
    }
}
