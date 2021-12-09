using DYLHS5_HFT_2021221.Logic.Exceptions;
using DYLHS5_HFT_2021221.Models;
using DYLHS5_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Logic
{
    public class OrderLogic : IOrderLogic
    {
        private IOrderRepository orderRepo;

        public OrderLogic(IOrderRepository orderRepo)
        {
            this.orderRepo = orderRepo;
        }
        public IQueryable<Order> GetAll()
        {
            return orderRepo.GetAll();
        }

        public void Create(Order order)
        {
            if (order.Product.ProductName==null ||order.Customer.CustomerName==null)
            {
                throw new ProductOrCustomerNameMissingException("The customers or products name is missing, can't create that order.");
            }
            if (order.Product==null || order.Customer ==null)
            {
                throw new NullReferenceException("Missing product or customer while creating order.");
            }
            if (order.IsTransportRequired==null || order.IsPrePaid==null)
            {
                throw new BooleanExpressionsAreNullException("One of the boolean expressions are missing, please fix.");
            }
            if (order.OrderId==null)
            {
                throw new IdMissingException("Missing order ID");
            }
            orderRepo.Create(order);

        }

        public void Delete(int? orderId)
        {
            orderRepo.Delete(orderId);
        }

        public IQueryable<Order> ReadAll()
        {
            return orderRepo.ReadAll();
        }

        public void Update(Order order)
        {
            orderRepo.Update(order);
        }
        public Order GetOne(int? orderId)
        {
            return orderRepo.ReadOne(orderId);
        }

    }
}
