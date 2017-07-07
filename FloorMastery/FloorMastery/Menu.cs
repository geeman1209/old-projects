using FloorMastery.WorkFlows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery
{
    public static class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("***********************************");
                Console.WriteLine("* Flooring Program");
                Console.WriteLine("*");
                Console.WriteLine("* 1. Display Orders");
                Console.WriteLine("* 2. Add Order");
                Console.WriteLine("* 3. Edit Order ");
                Console.WriteLine("* 4. Remove Order ");
                Console.WriteLine("* 5. Quit ");
                Console.WriteLine("*");
                Console.WriteLine("***********************************");

                Console.Write("\nEnter Selection: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        DisplayOrderWorkFlow displayOrder = new DisplayOrderWorkFlow();
                        displayOrder.Execute();
                        break;
                    case "2":
                        AddOrderWorkFlow addOrder = new AddOrderWorkFlow();
                        addOrder.Execute();
                        break;
                    case "3":
                        EditOrderWorkFlow editOrder = new EditOrderWorkFlow();
                        editOrder.Execute();
                        break;
                    case "4":
                        RemoveItemWorkFlow removeOrder = new RemoveItemWorkFlow();
                        removeOrder.Execute();
                        break;
                    case "5":
                        return;
                }
            }
        }
    }
}
