using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery.Models.Interfaces
{
    public interface IOrder
    {
        Order FindIndivOrder (int orderNumber, DateTime date );
        //display order
        List<Order> ShowOrders(DateTime orderDate);
        //add order
        Order AddOrder(Order order, DateTime orderDate);
        //edit order
        Order EditOrder(DateTime orderDate, Order order);
        //delete order
        void DeleteOrder(DateTime orderDate, int orderNumber);        
    }
}
