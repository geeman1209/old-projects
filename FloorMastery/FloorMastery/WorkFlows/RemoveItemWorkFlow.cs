using FloorMastery.BLL;
using FloorMastery.BLL.Rules;
using FloorMastery.Models;
using FloorMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery.WorkFlows
{
   public class RemoveItemWorkFlow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();

            Console.WriteLine("    Remove Order");
            Console.WriteLine("--------------------");
            
                DateTime date = ConsoleIO.GetValidDate();
                OrderLookupResponse response = manager.LookupOrders(date);
                if (response.Success == false)
                {
                    Console.WriteLine("An error occurred: ");
                    Console.WriteLine($"{response.Message}");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    int orderNumber = ConsoleIO.GetOrderNumber(date);
                    OrderLookupResponse SelectedOrder = manager.FindSelectOrder(orderNumber, date);
                    Console.WriteLine("\nHere is the order you've selected: ");
                    ConsoleIO.DisplayOneOrder(SelectedOrder.IndivOrder);


                    string YesOrNo = ConsoleIO.GetYesorNo();
                    if (YesOrNo.ToUpper() == "Y")
                    {
                    Console.WriteLine("Order will be deleted.");
                    manager.deleteOrder(orderNumber, date);
                    }
                    else
                    {
                        Console.WriteLine("Order will not be removed");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                }
            
        }
    }
}
