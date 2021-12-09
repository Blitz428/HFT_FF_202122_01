using DYLHS5_HFT_2021221.Models;
using DYLHS5_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Logic
{
    public class ShopLogic : IShopLogic
    {
        private IOrderRepository orderRepo;
        private IProductRepository productRepo;
        private ICustomerRepository customerRepo;

        public ShopLogic(ICustomerRepository customerRepo, IOrderRepository orderRepo, IProductRepository productRepo)
        {
            this.productRepo = productRepo;
            this.orderRepo = orderRepo;
            this.customerRepo = customerRepo;
        }

        public IEnumerable<Order> GetOrdersByCustomername(string customername) //gives back the orders of the specified customer
        {

            return from order in orderRepo.ReadAll()
                   join customer in customerRepo.ReadAll()
                   on order.CustomerId equals customer.CustomerId
                   where customer.CustomerName == customername
                   select order;



        }
        public IEnumerable<KeyValuePair<Order, string>> GetAddressesOfOrders()
        {
            return from order in orderRepo.ReadAll()
                   join customer in customerRepo.ReadAll()
                   on order.CustomerId equals customer.CustomerId
                   where customer.Address != null
                   select new KeyValuePair<Order, string>(order, customer.Address);

        }

        public IEnumerable<Product> GetProductsWeNeedToTransport()
        {
            return from product in productRepo.ReadAll()
                   join order in orderRepo.ReadAll()
                   on product.ProductId equals order.ProductId
                   where order.IsTransportRequired == true
                   select product;
        }

        public IEnumerable<Customer> GetCustomersWithThisSize(int size)
        {
            return from customer in customerRepo.ReadAll()
                   join order in orderRepo.ReadAll()
                   on customer.CustomerId equals order.CustomerId
                   join product in productRepo.ReadAll()
                   on order.ProductId equals product.ProductId
                   where product.Size == size
                   select customer;

        }

        public IEnumerable<KeyValuePair<Customer, Order>> GetPrePaidOrdersByCustomers()
        {
            return from customer in customerRepo.ReadAll()
                   join order in orderRepo.ReadAll()
                   on customer.CustomerId equals order.CustomerId
                   where order.IsPrePaid == true
                   select new KeyValuePair<Customer, Order>(customer, order);



        }




    }
}
