using FloorMastery.BLL;
using FloorMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery.WorkFlows
{
    public class DisplayOrderWorkFlow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Lookup orders");
            Console.WriteLine("-----------------------");

            DateTime date = ConsoleIO.GetOrderDate();
            OrderLookupResponse response = manager.LookupOrders(date);

            if (response.Success)
            {                
                ConsoleIO.DisplayOrderDetails(response.Order);
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
