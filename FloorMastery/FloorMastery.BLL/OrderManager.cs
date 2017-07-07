using FloorMastery.Models;
using FloorMastery.Models.Interfaces;
using FloorMastery.Models.Responses;
using System;

namespace FloorMastery.BLL
{
    public class OrderManager
    {
        private IOrder _orderRepo;
        private IProduct _productRepo;
        private ITaxes _taxesRepo;

        public OrderManager(IOrder orderRepo, IProduct productRepo, ITaxes taxesRepo)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _taxesRepo = taxesRepo;
        }

        public OrderLookupResponse LookupOrders(DateTime orderDate)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            response.Order = _orderRepo.ShowOrders(orderDate);

            if(response.Order == null)
            {
                response.Success = false;
                response.Message = $"{orderDate} is not a valid date";
                return response;
            }
            else
            {
                response.Success = true;
                return response;
            }
        }

        public AddOrderResponse addOrder(Order order, DateTime orderDate)
        {
            AddOrderResponse response = new AddOrderResponse();

            response.order = _orderRepo.AddOrder(order, orderDate);

            if(response.order == null)
            {
                response.Success = false;
                response.Message = "Order cannot be added. Please try again";
                return response;
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
        public OrderLookupResponse editOrder (Order order, DateTime orderDate)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            response.IndivOrder = _orderRepo.EditOrder(orderDate, order);

            if(response.IndivOrder == null)
            {
                response.Success = false;
                response.Message = "Order couldn't be edited";
                return response;
            }
            else
            {
                response.Success = true;
                return response;
            }
        }

        public Response deleteOrder (int orderNumber, DateTime orderDate)
        {
            Response response = new Response();
            try
            {
                _orderRepo.DeleteOrder(orderDate, orderNumber);
                response.Success = true;
            }
            catch(Exception M)
            {
                response.Success = false;
                Console.WriteLine($"The selected order could not be deleted due to {M.Message}");
            }
            return response;
        }


        public TaxesResponse FindTaxes()
        {
            TaxesResponse response = new TaxesResponse();
            response.taxes = _taxesRepo.LoadTax();

            if(response.taxes == null)
            {
                response.Success = false;
                response.Message = "Taxes could not be found";
                return response;
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public ProductResponse FindProducts()
        {
            ProductResponse response = new ProductResponse();
            response.products = _productRepo.ListProducts();

            if(response.products == null)
            {
                response.Success = false;
                response.Message = "Product could not be found";
                return response;
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public OrderLookupResponse FindSelectOrder(int orderNumber, DateTime orderDate)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            response.IndivOrder = _orderRepo.FindIndivOrder(orderNumber, orderDate);

            if(response.IndivOrder == null)
            {
                response.Success = false;
                response.Message = "Order could not be found";
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
