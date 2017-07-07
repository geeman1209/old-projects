using FloorMastery.Models;
using FloorMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery.BLL.Rules
{
    public class RemoveOrderRules
    {
        public Response ValiDate(string userInput)
        {
            OrderManager manager = OrderManagerFactory.Create();
            Response response = new Response();
            DateTime date;

            if (string.IsNullOrEmpty(userInput))
            {
                response.Success = false;
                response.Message = "This field cannot be left blank";
                return response;
            }

            if(!DateTime.TryParse(userInput, out date))
            {
                response.Success = false;
                response.Message = "Please enter a valid date.";
                return response;
            }
            else
            {
                response.Success = true;
                return response;
            }
        }

        public Response ValidOrderNumber(string input, DateTime orderDate)
        {
            Response response = new Response();
            int orderNumber;

            if (string.IsNullOrEmpty(input))
            {
                response.Success = false;
                response.Message = "This field cannot be left blank";
                return response;
            }
            else if(!int.TryParse(input, out orderNumber))
            {
                response.Success = false;
                response.Message = "You did not enter a valid number.";
                return response;
            }
            else
            {
                response.Success = true;
                response = CheckOrderExists(int.Parse(input), orderDate);
                return response;
            } 
                    
        }

        public Response CheckOrderExists(int input, DateTime orderDate)
        {
            Response response = new Response();
            OrderLookupResponse selectOrder = new OrderLookupResponse();
            OrderManager manager = OrderManagerFactory.Create();

            selectOrder = manager.FindSelectOrder(input, orderDate);
            
            if(selectOrder.IndivOrder == null)
            {
                response.Success = false;
                response.Message = "There are no orders for this date";
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
