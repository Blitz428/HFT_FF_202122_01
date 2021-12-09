using DYLHS5_HFT_2021221.Models;
using DYLHS5_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Logic
{
    public class ShopLogic :IShopLogic
    {
        private IOrderRepository orderRepo;
        private IProductRepository productRepo;
        private ICustomerRepository customerRepo;

        public ShopLogic(ICustomerRepository customerRepo,IOrderRepository orderRepo, IProductRepository productRepo)
        {
            this.productRepo = productRepo;
            this.orderRepo = orderRepo;
            this.customerRepo = customerRepo;
        }

        public IEnumerable<Order>GetOrdersByCustomername(string customername) //gives back the orders of the specified customer
        {

            return  from x in this.orderRepo.ReadAll()
                    join customer in this.customerRepo.ReadAll()
                    on x.CustomerId equals customer.CustomerId
                    where customer.CustomerName == customername
                    select x;


           
        }
        public IEnumerable<KeyValuePair<Order,string>>GetAddressesOfOrders()
        {
            return from x in orderRepo.ReadAll()
                   join customer in customerRepo.ReadAll()
                   on x.CustomerId equals customer.CustomerId
                   where customer.CustomerId == x.CustomerId
                   where customer.Address !=null
                   select new KeyValuePair<Order, string>(x, customer.Address);

        }

        public IEnumerable<Product> GetProductsWeNeedToTransport()
        {
            return from product in productRepo.ReadAll()
                   join order in orderRepo.ReadAll()
                   on product.ProductId equals order.ProductId
                   where order.ProductId == product.ProductId
                   where order.IsTransportRequired==true
                   select product;
        }


        

    }
}
