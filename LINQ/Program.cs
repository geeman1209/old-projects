using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {

        static void Main()
        {
            PrintAllProducts();
              List<Product> allProducts = DataLoader.LoadProducts();
              allProducts.OrderBy(prod => prod.ProductID).ToList().ForEach(prod => { Console.WriteLine(prod.ProductID +" "+ prod.ProductName); });

            PrintAllCustomers();
       List<Customer> allCusties = DataLoader.LoadCustomers();
       allCusties.OrderBy(cust => cust.CustomerID).ToList().ForEach(cust => { Console.WriteLine(cust.CustomerID + " " + cust.CompanyName); });
    
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            List<Product> products = DataLoader.LoadProducts();

            var outOfStock = from noStock in products
                             where noStock.UnitsInStock == 0
                             select noStock;

            foreach(var product in outOfStock)
            {
                Console.WriteLine(product.ProductName);
            }
 
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            List<Product> products = DataLoader.LoadProducts();

            var inStock = from yesStock in products
                             where yesStock.UnitsInStock > 0 && yesStock.UnitPrice >= 3.00M
                             select yesStock;

            foreach (var product in inStock)
            {
                Console.WriteLine(product.ProductName);
            }

        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var washCust = from washCu in customers
                           where washCu.Region == "WA"
                           select washCu;

            foreach (var cust in washCust)
            {
                Console.WriteLine(cust.CompanyName);

                foreach(var order in cust.Orders)
                {
                    Console.WriteLine(order.OrderID + "   " + order.OrderDate +"    "+ order.Total);
                }
            }

        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            List<Product> products = DataLoader.LoadProducts();

            var anon = from stock in products
                       select new
                       {
                           stockName = stock.ProductName
                        };

            foreach (var product in anon)
            {
                Console.WriteLine(product.stockName);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            List<Product> products = DataLoader.LoadProducts();

            var newPrice = from price in products
                           where price.UnitPrice > 0
                           select new
                           {
                               ID = price.ProductID,  
                               upCharge = (price.UnitPrice*0.25M  + price.UnitPrice),
                               Name = price.ProductName,
                               Category = price.Category,
                               Stock = price.UnitsInStock

                           };

            foreach (var product in newPrice)
            {
                Console.WriteLine(product.ID + "  "+ product.Name+ "  "+ product.Category+"  "+product.upCharge+"  "+product.Stock);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            List<Product> products = DataLoader.LoadProducts();

            var newPrice = from price in products
                           where price.UnitPrice > 0
                           select new
                           {
                               Name = price.ProductName.ToUpper(),
                               Category = price.Category.ToUpper(),
                           };

            foreach (var product in newPrice)
            {
                Console.WriteLine(product.Name + "  " + product.Category);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            List<Product> products = DataLoader.LoadProducts();

            var newPrice = from price in products
                           where price.UnitPrice > 0
                           select new
                           {
                               ID = price.ProductID,
                               Price = price.UnitPrice,
                               Name = price.ProductName,
                               Category = price.Category,
                               Stock = price.UnitsInStock,
                               Reorder = price.UnitsInStock < 3 ? "Reorder" : " "
                           };

            foreach (var product in newPrice)
            {
                Console.WriteLine(product.ID + "  " + product.Name + "  " + product.Category + "  " + product.Price + "  " + product.Stock + "    " + product.Reorder);
            }
    }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            List<Product> products = DataLoader.LoadProducts();

            var newPrice = from price in products
                           where price.UnitPrice > 0
                           select new
                           {
                               ID = price.ProductID,
                               Price =  price.UnitPrice,
                               Name = price.ProductName,
                               Category = price.Category,
                               Stock = price.UnitsInStock,
                               StockValue = (price.UnitsInStock * price.UnitPrice)

                           };

            foreach (var product in newPrice)
            {
                Console.WriteLine(product.ID + "  " + product.Name + "  " + product.Category + "  " + product.Price + "  " + product.Stock+ "  "+ product.StockValue);
            }
        
         }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            int[] num = DataLoader.NumbersA;
            var even = num.Where(n => n % 2 == 0).ToList();

            foreach(var numBa in even)
            {
                Console.WriteLine(numBa);
            }     
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var selectCust = from customer in customers
                             where customer.Orders.All(f => f.Total < 500.00M)
                             select customer;

            foreach(var customer in selectCust)
            {
                Console.WriteLine(customer.CompanyName + "    " + customer.CustomerID);
                {
                    foreach(var cust in customer.Orders)
                    {
                        Console.WriteLine(cust.Total);
                    }
                }
            }


        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            int[] oddnums = DataLoader.NumbersC;

            var oddities = oddnums.Where(n => n % 2 == 1);

            var top3 = (from tops in oddities
                        orderby tops ascending
                        select tops).Take(3);

            foreach(var num in top3)
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            int[] numB = DataLoader.NumbersB;

            var skip3 = (from nums in numB
                         select nums).Skip(3);

            foreach (var num in skip3)
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var washCust = from washCu in customers
                           where washCu.Region == "WA"
                           select washCu;

            foreach (var cust in washCust)
            {
                var lastOrder = cust.Orders.Last();
                Console.WriteLine(cust.CompanyName+ "     " + lastOrder);
            }

        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            int[] numC = DataLoader.NumbersC;

            var bigG = numC.TakeWhile(n => n < 6);

            foreach(int num in bigG)
            {
                Console.WriteLine(num);
            }

        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            int[] numC = DataLoader.NumbersC;

            var takeNum = (from num in numC
                           select num).Skip(4);

            foreach(var numBa in takeNum)
            {
                Console.WriteLine(numBa);
            }

        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            List<Product> products = DataLoader.LoadProducts();

            var alphaProds = from prods in products
                             orderby prods.ProductName ascending
                             select prods;

            foreach(var name in alphaProds)
            {
                Console.WriteLine(name.ProductName);
            }
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            List<Product> products = DataLoader.LoadProducts();

            var StockProds = from prods in products
                             orderby prods.UnitsInStock descending
                             select prods;

            foreach (var name in StockProds)
            {
                Console.WriteLine(name.ProductName+ "   "+ name.UnitsInStock);
            }
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            List<Product> products = DataLoader.LoadProducts();

            var orderedProds = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

            foreach (var name in orderedProds)
            {
                Console.WriteLine(name.ProductName + "        " + name.Category+"        "+name.UnitPrice);
            }
        }
    /// <summary>
    /// Print NumbersB in reverse order
    /// </summary>
    static void Exercise19()
        {
            int[] nums = DataLoader.NumbersB;

            var reverseNum = nums.Reverse();
            
            foreach(var numBa in reverseNum)
            {
                Console.WriteLine(numBa);
            }       
                
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            List<Product> products = DataLoader.LoadProducts();

            var alphaProds = products.GroupBy(p => p.Category);

            foreach (var name in alphaProds)
            {
                Console.WriteLine(name.Key);

                foreach(var group in name)
                {
                    Console.WriteLine(group.ProductName);
                }
            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var result = (from customer in customers
                          select new
                          {
                              companyName = customer.CompanyName,
                              YearGroups = (from order in customer.Orders
                                            group order by order.OrderDate.Year into sortedOrders
                                            select new
                                            {
                                                Year = sortedOrders.Key,
                                                MonthGroups = from order in sortedOrders
                                                              group order by order.OrderDate.Month into monthlyOrders
                                                              select new { Month = monthlyOrders.Key, Orders = monthlyOrders }
                                            }).ToList()
                          }).ToList();

            foreach(var headache in result)
            {
                Console.WriteLine(headache.companyName);
                Console.WriteLine("---------------------");
                Console.WriteLine("");
                foreach(var year in headache.YearGroups)
                {
                    Console.WriteLine(year.Year);
                    foreach (var month in year.MonthGroups)
                    {
                        var getOrderTotal = from o in month.Orders
                                            select o.Total;

                        foreach(var p in getOrderTotal)
                        {
                            Console.WriteLine($"{month.Month} - {p}");
                            Console.WriteLine("");
                        }

                    }
                }

            }

        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            List<Product> products = DataLoader.LoadProducts();

            var categories = from p in products
                             select p.Category;

            var narrow = categories.Distinct().ToList();
                              

            foreach(var category in narrow)
            {
                Console.WriteLine(category);
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            List<Product> products = DataLoader.LoadProducts();

            var exists = from p in products
                         select p.ProductID;

                bool check = exists.Equals(789);

                if(check)
                {
                    Console.WriteLine("Does exist");
                }

                else
                {
                    Console.WriteLine("Doesn't exist.Try another product");
                    
                }
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            List<Product> products = DataLoader.LoadProducts();

            var unoStock = from p in products
                           where p.UnitsInStock == 0 
                          select p;

            var narrow = unoStock.Distinct();

            foreach (var unit in narrow)
            {
                Console.WriteLine(unit.Category);
               // Console.WriteLine(unit.ProductName + "  " + unit.UnitsInStock);
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            List<Product> products = DataLoader.LoadProducts();

            var noStock = products.GroupBy(p => p.Category).Where(o => o.All(n => n.UnitsInStock > 0));

            foreach(var unit in noStock)
            {
                Console.WriteLine(unit.Key);
            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            int[] numsA = DataLoader.NumbersA;

            var oddA = numsA.Where(n => n % 2 == 1).Count();

            Console.WriteLine(oddA);
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            List<Customer> customers = DataLoader.LoadCustomers();
            var anon = from c in customers
                       select new
                       {
                           CustomerID = c.CustomerID,
                           count = c.Orders.Count(),
                        };

        foreach(var comp in anon)
            {
                Console.WriteLine(comp.CustomerID + "             " + comp.count);
            }


        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            List<Product> product = DataLoader.LoadProducts();

            var lowest = product.GroupBy(p => p.Category);

            foreach (var p in lowest)
            {
                var countStock = (from k in p
                                 select k).Count();

                Console.WriteLine(p.Key);
                Console.WriteLine(countStock);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            List<Product> product = DataLoader.LoadProducts();

            var lowest = product.GroupBy(p => p.Category);

            foreach (var p in lowest)
            {
                var totalUnits = (from k in p
                                 select k.UnitsInStock).Sum();

                Console.WriteLine(p.Key);
                Console.WriteLine(totalUnits);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            List<Product> product = DataLoader.LoadProducts();

            var lowest = product.GroupBy(p => p.Category);

                foreach(var p in lowest)
            {
                var getName = (from k in p select k.ProductName).Min();
                var narrowLow = (from k in p
                                select k.UnitPrice).Min();

                Console.WriteLine(p.Key);
                Console.WriteLine(getName);
                Console.WriteLine(narrowLow);
                
            }
        } 

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            List<Product> products = DataLoader.LoadProducts();

            var productos = products.GroupBy(p => p.Category).OrderByDescending(a => a.Average(u => u.UnitPrice)).Take(3);

            foreach(var p in productos)
            {
                Console.WriteLine(p.Key);
                Console.WriteLine(p.Average(c => c.UnitPrice));
            }
        }
    }
}
