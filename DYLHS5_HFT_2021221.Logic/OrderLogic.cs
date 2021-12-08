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
        private IOrderRepository repo;

        public OrderLogic(IOrderRepository repo)
        {
            this.repo = repo;
        }
        public IQueryable<Order> GetAll()
        {
            return repo.GetAll();
        }

        public void Create(Order order)
        {
            repo.Create(order);
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
            
        }

        public void Delete(int orderId)
        {
            repo.Delete(orderId);
        }

        public IQueryable<Order> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Order order)
        {
            repo.Update(order);
        }



        public double HighestPrice()
        {
            return repo.ReadAll().Max(x => x.Product.Price)??0;
        }


        public IEnumerable<Customer> CustomersBiggerThanThisShoeSize(int size) //returns the customers that have bigger shoe size than the parameter
        { 
        
            return repo.ReadAll().Where(x=>x.Product.Size > size).Select(x=>x.Customer);
        
        }
        

        public IEnumerable<Order> OrderFindByColor(string color) //finds the orders with the specified shoe color
        {
            return repo.ReadAll().Where(x => x.Product.Color == color).Select(x => x);
        }

        public IEnumerable<string> CustomerFindByPrePaidOrder() //finds the customers with prepaid orders
        {
            return repo.ReadAll().Where(x=>x.IsPrePaid==true).Select(x => x.Customer.CustomerName).Distinct();
        }

        public IEnumerable<string> CustomersWhoNeedTransport() //finds the customers who need transport for their order(s)
        {
            return repo.ReadAll().Where(x=>x.IsTransportRequired==true).Select(x => x.Customer.CustomerName).Distinct();
        }

        public Order GetOne(int orderId)
        {
            return repo.ReadOne(orderId);
        }
    }
}
