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
   public class EditOrderWorkFlow
    {
        public void Execute()
        {
            Console.Clear();

            OrderManager manager = OrderManagerFactory.Create();           
            TaxesResponse taxResponse = manager.FindTaxes();
            ProductResponse prodResponse = manager.FindProducts();

            Console.WriteLine("         Edit Order        ");
            Console.WriteLine("--------------------------------");

            DateTime orderDatedit = ConsoleIO.GetOrderDate();
            int orderNumber = ConsoleIO.GetOrderNumber(orderDatedit);

            OrderLookupResponse selectOrder = manager.FindSelectOrder(orderNumber, orderDatedit);

            if(selectOrder.Success == false)
            {
                Console.WriteLine($"An error occurred: {selectOrder.Message}");

            }
            else
            {
                Order editOrder = selectOrder.IndivOrder;
                editOrder.OrderDate = orderDatedit;
                ConsoleIO console = new ConsoleIO();

                Console.WriteLine($"\nEnter Customer Name({editOrder.CustomerName}): ");
                string editedName = console.GetEditedName(editOrder);
                editedName = editOrder.CustomerName;

                Console.WriteLine("\nHere is the list of available states: ");
                ConsoleIO.DisplayTaxes(taxResponse.taxes);

                Console.WriteLine($"\nEnter a State ({editOrder.State}): ");
                string editedState = console.GetEditedState(editOrder, taxResponse.taxes);
                editOrder.State = editedState;

                ConsoleIO.ApplyTax(taxResponse.taxes, editOrder);

                Console.WriteLine("\nAvailable Product Types: ");
                ConsoleIO.DisplayProducts(prodResponse.products);

                Console.WriteLine($"\nEnter a Product Type ({editOrder.ProductType}): ");
                string editedProduct = console.GetEditedProduct(editOrder, prodResponse.products);
                editOrder.ProductType = editedProduct;

                ConsoleIO.ApplyProduct(prodResponse.products, editOrder);

                Console.WriteLine($"\nCurrent area ({editOrder.Area})");
                decimal area = ConsoleIO.GetEditedArea(editOrder);
                editOrder.Area = area;

                PutitAllTogether(editOrder);
                ConsoleIO.DisplayOneOrder(editOrder);

                string YayOrNay = ConsoleIO.GetYesorNo();

                if (YayOrNay.ToUpper() == "Y")
                {
                    OrderLookupResponse resp = manager.editOrder(editOrder, editOrder.OrderDate);
                    if (resp.Success == true)
                    {
                        Console.WriteLine($"Order Number {editOrder.OrderNumber} has been changed");
                    }

                }
                else if (YayOrNay.ToUpper() == "N")
                {
                    Console.WriteLine("\nEdits are cancelled");
                    Console.WriteLine("\nPress any key to continue");
                    Console.ReadKey();
                }
                else if (YayOrNay.Length > 1 || YayOrNay.Length < 1)
                {
                    ConsoleIO.GetYesorNo();
                }
            }
              
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();

            }

        public Order PutitAllTogether(Order order)
        {
            CalculateTotals calculator = new CalculateTotals();
            order.MaterialCost = calculator.MaterialCost(order);
            order.LaborCost = calculator.LaborCost(order);
            order.Tax = calculator.Tax(order);
            order.Total = calculator.Total(order);

            return order;
        }

    }
  }

