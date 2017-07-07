using FloorMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.Models;

namespace FloorMastery.Data
{
    public class OrderRepository : IOrder
    {
        public static List<Order> publicOrders;

        public OrderRepository()
        {
            List<Order> publicOrders = new List<Order>();
            if(publicOrders.Count == 0)
            {
                publicOrders.Add(_order);
                publicOrders.Add(_orderDos);
            }
        }

        private static Order _order = new Order
        {
            OrderDate = new DateTime(2017, 03, 03),
            OrderNumber = 1,
            CustomerName = "Donald Duck",
            State = "OH",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
        };

        private static Order _orderDos = new Order
        {
            OrderDate = new DateTime(2017, 03, 03),
            OrderNumber = 2,
            CustomerName = "DarkWing Duck",
            State = "OH",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
        };

        public List<Order> ShowOrders(DateTime orderDate)
        {
            List<Order> order = new List<Order>();

            if (orderDate != _order.OrderDate)
            {
                return null;
            }
            else
            {
                order.Add(_order);
                order.Add(_orderDos);
            }

            return order;
        }

        public Order AddOrder(Order order, DateTime orderDate)
        {
            List<Order> orders = ShowOrders(orderDate);

            if(orders == null)
            {
                orders = new List<Order>();
                orders.Add(order);
                order.OrderNumber = 1;
                return order;
            }
            else
            {
                order.OrderNumber = orders.Max(o => o.OrderNumber) + 1;
            }

            orders.Add(order);
            return order;
        }

        public Order EditOrder(DateTime orderDate, Order order)
        {
            //Load List of orders by date
            List<Order> orders = ShowOrders(orderDate);

            //Find the specific order by order#
            int specificO = orders.FindIndex(o => o.OrderNumber == order.OrderNumber);

            //save the specific order 
             return order = orders[specificO];
        }

        public void DeleteOrder(DateTime orderDate, int orderNumber)
        {
            List<Order> orders = ShowOrders(orderDate);

            Order OnetoDelete = orders.Find(o => o.OrderNumber == orderNumber);

            orders.Remove(OnetoDelete);
        }

        public Order FindIndivOrder(int orderNumber, DateTime date )
        {
            List<Order> orders = ShowOrders(date);

            Order IndividualOrder = orders.Find(o => o.OrderNumber == orderNumber);

            return IndividualOrder;
        }

    }
}
