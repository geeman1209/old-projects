using FloorMastery.BLL;
using FloorMastery.BLL.Rules;
using FloorMastery.Models;
using FloorMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery
{
    public class ConsoleIO
    {

        public static void DisplayOrderDetails(List<Order> order)
        {
            foreach (Order ord in order)
            {
                decimal formattedMaterials = Convert.ToDecimal(string.Format("{0:0.00}", ord.MaterialCost));
                decimal formattedLabor = Convert.ToDecimal(string.Format("{0:0.00}", ord.LaborCost));
                decimal formattedTax = Convert.ToDecimal(string.Format("{0:0.00}", ord.Tax));
                decimal formattedTotal = Convert.ToDecimal(string.Format("{0:0.00}", ord.Total));

                Console.WriteLine("***************************************");
                Console.WriteLine($"[{ord.OrderNumber}][{ord.OrderDate}]");
                Console.WriteLine($"[{ord.CustomerName}]");
                Console.WriteLine($"[{ord.State}]");
                Console.WriteLine($"Product:[{ord.ProductType}]");
                Console.WriteLine($"Materials:[{formattedMaterials}]");
                Console.WriteLine($"Labor:[{formattedLabor}]");
                Console.WriteLine($"Tax:[{formattedTax}]");
                Console.WriteLine($"Total:[{formattedTotal}]");
                Console.WriteLine("***************************************");
            }
        }

        public static void DisplayProducts(List<Products> products)
        {
            foreach (Products product in products)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"ProductType: {product.ProductType}");
                Console.WriteLine($"CostPerSqFt: {product.CostPerSquareFoot}");
                Console.WriteLine($"LaborCostPerSqFt:{product.LaborCostPerSquareFoot}");
                Console.WriteLine("-----------------------------");
            }
        }

        public static void DisplayTaxes(List<Taxes> taxes)
        {
            foreach (Taxes tax in taxes)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"StateName: {tax.StateName}");
                Console.WriteLine($"StateAbrv: {tax.StateAbbreviation}");
                Console.WriteLine($"TaxRate:{tax.TaxRate}");
                Console.WriteLine("-----------------------------");
            }
        }

        public static void DisplayOneOrder(Order order)
        {
            decimal formattedMaterials = Convert.ToDecimal(string.Format("{0:0.00}", order.MaterialCost));
            decimal formattedLabor = Convert.ToDecimal(string.Format("{0:0.00}", order.LaborCost));
            decimal formattedTax = Convert.ToDecimal(string.Format("{0:0.00}", order.Tax));
            decimal formattedTotal = Convert.ToDecimal(string.Format("{0:0.00}", order.Total));

            Console.WriteLine("***************************************");
            Console.WriteLine($"[{order.OrderNumber}][{order.OrderDate}]");
            Console.WriteLine($"Customer Name: [{order.CustomerName}]");
            Console.WriteLine($"State: [{order.State}]");
            Console.WriteLine($"Product:[{order.ProductType}]");
            Console.WriteLine($"Materials:[{formattedMaterials}]");
            Console.WriteLine($"Labor:[{formattedLabor}]");
            Console.WriteLine($"Tax:[{formattedTax}]");
            Console.WriteLine($"Total:[{formattedTotal}]");
            Console.WriteLine("***************************************");
        }

        public static DateTime GetOrderDate()
        {
            while(true)
            {
                RemoveOrderRules rules = new RemoveOrderRules();
                Response response = new Response();
                DateTime orderDate;
                
                Console.WriteLine("Enter a date for your order: ");
                string input = Console.ReadLine();

                response = rules.ValiDate(input);

                if(response.Success == false)
                {
                    Console.WriteLine("Something is incorrect:");
                    Console.WriteLine($"\n{response.Message}");
                    Console.WriteLine("Please any key to try again");
                    Console.ReadKey();
                }
                else
                {
                    orderDate = DateTime.Parse(input);
                    return orderDate;
                }
            }
        }

        public string GetEditedName(Order order)
        {
            string userInput = Console.ReadLine();

            EditOrderRules rules = new EditOrderRules();

            Response response = rules.VerifyString(userInput);

            if(response.Success == false)
            {
                order.CustomerName = order.CustomerName;
            }
            else
            {
                order.CustomerName = userInput;
            }
            return order.CustomerName;
        }

        public string GetEditedState(Order order, List<Taxes> taxes)
        {
            while (true)
            {
                string userInput = Console.ReadLine();
                EditOrderRules rules = new EditOrderRules();

                Response response = rules.VerifyState(taxes, userInput);

                if (response.Success == false)
                {
                    Console.WriteLine($"{response.Message}");
                    if (response.Message == "The current information will be saved.")
                    {
                        order.State = order.State;
                    }
                }
                else
                {
                    order.State = userInput;
                }
                return order.State;
            } 
        }

        public string GetEditedProduct(Order order, List<Products> product)
        {
            string userInput = Console.ReadLine();
            Response response = new Response();

            response = EditOrderRules.VerifyProduct(product, userInput);

            if (response.Success == false)
            {
                Console.WriteLine($"{response.Message}");
                if(response.Message == "The current information will be saved.")
                {
                    order.ProductType = order.ProductType;
                }
            }
            else
            {
                order.ProductType = userInput;
            }
            return order.ProductType;
        }

        public static decimal GetEditedArea(Order order)
        {

            while (true)
            {
                string userInput;
                Response response;
                EditOrderRules rules = new EditOrderRules();

                Console.WriteLine("\nEnter area: ");

                userInput = Console.ReadLine();
                response = rules.VerifyArea(userInput);

                if (response.Success == false)
                {
                    Console.WriteLine($"{response.Message}");
                    if (response.Message == "\nThe current information will be saved.")
                    {
                        order.Area = order.Area;
                        return order.Area;
                    }
                }
                else
                {
                    decimal finalArea = decimal.Parse(userInput);
                    return finalArea;
                }
            }
        }

        public static string GetYesorNo()
        {
            string input;
            Response response = new Response();

            while(true)
            { 
           Console.WriteLine("Would you like to proceed? Y or N?: ");
            input = Console.ReadLine();

               response = EditOrderRules.VerifyYoN(input);

                if(response.Success == false)
                {
                    Console.WriteLine($"{response.Message}");
                }
                else if(response.Success == true)
                {
                    return input;
                }
                else
                {
                    return response.Message;
                }
            }
        }



        public static DateTime GetValidDate()
        {
            DateTime date;
            
            while(true)
            {
                Response response = new Response();
                RemoveOrderRules rules = new RemoveOrderRules();

                Console.WriteLine("Enter a date: ");
                string input = Console.ReadLine();
                response = rules.ValiDate(input);

                if(response.Success == false)
                {
                    Console.WriteLine($"\n{response.Message}");
                    Console.WriteLine("Press any key to try again.");
                    Console.ReadKey();
                }

                else
                {
                    date = DateTime.Parse(input);
                    return date;
                }
            }
        }

        public static DateTime GetFutureOrderDate()
        {
            DateTime oDate;
                      
            while (true)
            {
                AddOrderRules rules = new AddOrderRules();
                Response response = new Response();

                Console.WriteLine("Enter a Date: ");
                string orderDate = Console.ReadLine();

                response = rules.CheckFutureDate(orderDate);

                if(response.Success == false)
                {
                    Console.WriteLine($"{response.Message}");
                }
                else
                {
                    oDate = DateTime.Parse(orderDate);
                    return oDate;
                }                
            }
        }

        public static int GetArea()
        {
            while (true)
            {
                Response response = new Response();
                AddOrderRules rules = new AddOrderRules();

                Console.WriteLine("\nPlease enter the square feet of the desired area:");
                string input = Console.ReadLine();
                response = rules.CheckArea(input);

                if(response.Success == false)
                {
                    Console.WriteLine($"{response.Message}");
                }
                else
                {
                    int userInt = int.Parse(input);
                    return userInt;
                }
            }
        }

        public static string GetAddInput()
        {
            while (true)
            {
                Response response = new Response();
                AddOrderRules rules = new AddOrderRules();

                Console.WriteLine("Enter Customer Name: ");

                string input = Console.ReadLine();

                response = rules.CheckString(input);

                if(response.Success == false)
                {
                    Console.WriteLine($"{response.Message}");
                }
                else
                {
                    return input;
                }

            }
        }

        public static int GetOrderNumber(DateTime date)
        {
            int orderNumber;
            while (true)
            {
                Console.WriteLine("\nEnter the order number: ");
                string input = Console.ReadLine();
                RemoveOrderRules rules = new RemoveOrderRules();
                Response response = new Response();

                response = rules.ValidOrderNumber(input, date);

                if (response.Success == false)
                {
                    Console.WriteLine("\nSomething went wrong: ");
                    Console.WriteLine($"\n{response.Message}");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    return orderNumber = int.Parse(input);
                }
            }

        }

        public static string GetAddProduct(List<Products> products)
        {
            while (true)
            {
                Response response = new Response();
                string product = Console.ReadLine();

                response = AddOrderRules.CheckProduct(products, product);

                if(response.Success == false)
                {
                    Console.WriteLine($"{response.Message}");
                }
                else
                {
                    return product;
                }
            }
        }

        public static string GetAddState(List<Taxes> taxes)
        {
            while (true)
            {
                AddOrderRules rules = new AddOrderRules();
                Response response = new Response();
                string state = Console.ReadLine();

                response = rules.CheckState(taxes, state);

                if (response.Success == false)
                {
                    Console.WriteLine($"{response.Message}");
                }
                else
                {
                    return state;
                }
            }
        }

        public static Order ApplyTax( List<Taxes> taxes, Order order1)
        {
            string stateName = order1.State.ToUpper();
  
            foreach(Taxes tax in taxes)
            {
                if(stateName == tax.StateName.ToUpper())
                {
                    order1.TaxRate = tax.TaxRate;
                    return order1;
                }
            }
            return order1;
        }

        public static Order ApplyProduct(List<Products> products, Order order2)
        {
            string product = order2.ProductType.ToUpper();

            foreach (Products prod in products)
            {
                if (product == prod.ProductType.ToUpper())
                {
                    order2.CostPerSquareFoot = prod.CostPerSquareFoot;
                    order2.LaborCostPerSquareFoot = prod.LaborCostPerSquareFoot;
                    return order2;
                }
            }

            return order2;
        }

    }
}
