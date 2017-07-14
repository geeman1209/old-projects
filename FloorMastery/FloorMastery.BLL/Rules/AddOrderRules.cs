using FloorMastery.Models;
using FloorMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery.BLL.Rules
{
    public class AddOrderRules
    {
        public Response CheckFutureDate(string input)
        {
            Response response = new Response();
            DateTime date;
            if (string.IsNullOrEmpty(input))
            {
                response.Success = false;
                response.Message = "This field cannot be left blank";
                return response;
            }

            if (!DateTime.TryParse(input, out date))
            {
                response.Success = false;
                response.Message = "Please enter a valid date.";
                return response;
            }
            else if(DateTime.Parse(input) < DateTime.Now)
            {
                response.Success = false;
                response.Message = "Dates must be in the future";
                return response;
            }
            else
            {
                response.Success = true;
                return response;
            }
        }

        public Response CheckString(string userInput)
        {
            Response response = new Response();
            bool stringPattern = System.Text.RegularExpressions.Regex.IsMatch(userInput, @"^[a-zA-Z0-9., ]+$");

            if (string.IsNullOrEmpty(userInput))
            {
                response.Success = false;
                response.Message = "This field cannot be left blank.";
                return response;
            }
            else if (stringPattern == false)
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

        public static Response CheckProduct(List<Products> product, string input)
        {
            Response response = new Response();
            bool productName = product.Exists(p => p.ProductType.ToUpper() == input.ToUpper());

            if (string.IsNullOrEmpty(input))
            {
                response.Success = false;
                response.Message = "This field cannot be left blank.";
                return response;
            }

            else if (productName == false)
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

        public Response CheckState(List<Taxes> taxes, string input)
        {
            Response response = new Response();
            bool stateName = taxes.Exists(s => s.StateName.ToUpper() == input.ToUpper());

            if (string.IsNullOrEmpty(input))
            {
                response.Success = false;
                response.Message = "This field cannot be left blank.";
                return response;
            }

            else if (stateName == false)
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

        public Response CheckArea(string Input)
        {
            Response response = new Response();
            decimal result;
            if (string.IsNullOrEmpty(Input))
            {
                response.Success = false;
                response.Message = "This field cannot be left blank";
                return response;
            }
            else if(!decimal.TryParse(Input, out result))
            {
                response.Success = false;
                response.Message = "Enter a valid number";
                return response;
            }
            else if (decimal.Parse(Input) < 100)
            {
                response.Success = false;
                response.Message = "Please enter an area at least 100 square feet";
                return response;
            }
            else
            {
                response.Success = true;
                return response;
            }
        }
    }
}
