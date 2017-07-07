using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.Models;
using FloorMastery.Models.Responses;

namespace FloorMastery.BLL.Rules
{
    public class EditOrderRules
    {
        public Response VerifyString(string userInput)
        {
            Response response = new Response();
            bool stringPattern = System.Text.RegularExpressions.Regex.IsMatch(userInput, @"^[a-zA-Z0-9., ]+$");

            if (string.IsNullOrEmpty(userInput))
            {
              response.Success = false;
              response.Message = "The current information will stay saved.";
              return response;
            }
            else if(stringPattern == false)
            {
                response.Success = false;
                response.Message = "Your input is not formatted properly";
                return response;
            }
            else
            {
                response.Success = true;

            }         
                return response;
        }

        public static Response VerifyProduct(List<Products> product, string input)
        {
            Response response = new Response();

            if (string.IsNullOrEmpty(input))
            {
                response.Success = false;
                response.Message = "The current information will be saved.";
                return response;
            }

            else if(input.Equals(product.Find(o => o.ProductType.ToLower() != input.ToLower())))
            {
                response.Success = false;
                response.Message = "This product is not available.";
                return response;
            }
            else
            {
                response.Success = true;
                return response;
            }

        }

        public Response VerifyState(List<Taxes> taxes, string input)
        {
            Response response = new Response();

            if (string.IsNullOrEmpty(input))
            {
                response.Success = false;
                response.Message = "The current information will be saved.";
                return response;
            }

            else if (input.Equals(taxes.Find(o => o.StateName.ToLower() != input.ToLower())))
            {
                response.Success = false;
                response.Message = "The tax rate for this state is currently unavailable";
                return response;
            }
            else
            {
                response.Success = true;
                return response;
            }
        }

        public Response VerifyArea(string Input)
        {
            Response response = new Response();
            decimal result;

                if (string.IsNullOrEmpty(Input))
                {
                    response.Success = false;
                    response.Message = "\nThe current information will be saved.";
                    return response;
                }
                else if (decimal.Parse(Input) < 100)
                {
                    response.Success = false;
                    response.Message = "\nPlease enter an area of at least 100 square feet";
                    return response;
                }
                else if (!decimal.TryParse(Input, out result))
                {
                    response.Success = false;
                    response.Message = "Enter a valid number";
                    return response;
                }
                else
                {
                    response.Success = true;
                    return response;
                }           
        }

        public static DateTime VerifyDate()
        {
            DateTime oDate;

            while (true)
            {
                Console.WriteLine("Enter a Date: ");
                string orderDate = Console.ReadLine();

                if (!DateTime.TryParse(orderDate, out oDate))
                {
                    Console.WriteLine("Please try again");
                    Console.ReadKey();
                }
                else
                {
                    return oDate = DateTime.Parse(orderDate);
                }

                return oDate;
            }
        }

        public static Response VerifyYoN(string userinput)
        {
            Response response = new Response();

            switch (userinput.ToUpper())
            {
                case "Y":
                    response.Success = true;
                    return response;
                case "N":
                    response.Success = false;
                    response.Message = "Edited order will be cancelled.";
                    return response;
                default:
                    response.Message = "Please enter Y or N";
                    return response;
            }
           
        }
    }
}

