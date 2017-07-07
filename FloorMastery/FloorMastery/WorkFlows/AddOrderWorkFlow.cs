using FloorMastery.BLL;
using FloorMastery.Models;
using FloorMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery.WorkFlows
{
    public class AddOrderWorkFlow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order newishOrder = new Order();
            TaxesResponse taxresponse = manager.FindTaxes();
            ProductResponse prodresponse = manager.FindProducts();

            Console.Clear();
            Console.WriteLine("       Add an order");
            Console.WriteLine("***************************");
           
            DateTime orderDate = ConsoleIO.GetFutureOrderDate();
            string CustieName = ConsoleIO.GetAddInput();
           
            Console.WriteLine("\nHere is the list of approved States: ");
            ConsoleIO.DisplayTaxes(taxresponse.taxes);

            Console.WriteLine("Enter State Name: ");
            string Appliedstate = ConsoleIO.GetAddState(taxresponse.taxes);

            newishOrder.State = Appliedstate;
            newishOrder.OrderDate = orderDate;
            newishOrder.CustomerName = CustieName;

            ConsoleIO.ApplyTax(taxresponse.taxes, newishOrder);
            Console.WriteLine("\nHere are the available product types: ");
            ConsoleIO.DisplayProducts(prodresponse.products);

            Console.WriteLine("\nPlease choose your product: ");
            string productType = ConsoleIO.GetAddProduct(prodresponse.products);

            newishOrder.ProductType = productType;

            ConsoleIO.ApplyProduct(prodresponse.products, newishOrder);

            int area = ConsoleIO.GetArea();

            newishOrder.Area = area;

            ConsoleIO.DisplayOneOrder(newishOrder);
            string userAnswer = ConsoleIO.GetYesorNo();

            if(userAnswer.ToUpper() == "Y")
            {
                AddOrderResponse addResponse = manager.addOrder(newishOrder, newishOrder.OrderDate);
                if (addResponse.Success)
                {
                    Console.WriteLine("The order has been added.");
                }
                else
                {
                    Console.WriteLine("Please try again. An error occurred");
                }
            }
            else
            {
                Console.WriteLine("The order was cancelled");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

        }
    }
}
