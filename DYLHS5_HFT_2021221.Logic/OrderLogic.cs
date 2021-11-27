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
        IOrderRepository repo;

        public OrderLogic(IOrderRepository repo)
        {
            this.repo = repo;
        }

        public void Create(Order order)
        {
            repo.Create(order);
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

        public IEnumerable<KeyValuePair<string, double>> HighestPricedOrder() //returns the highest priced order
        {
            return repo.ReadAll().GroupBy(x => x.Product)
                .Select(x => new KeyValuePair<string, double>(x.Key.ProductName, x.Max(x => x.Product.Price) ?? 0));
                

        }

        public double HighestPrice()
        {
            return repo.ReadAll().Max(x => x.Product.Price)??0;
        }


        public IEnumerable<KeyValuePair<string, double>> SumOrdersOfCustomers() //summerizes the money spent by the customers
        {
            return repo.ReadAll().GroupBy(x => x.Customer)
                .Select(x => new KeyValuePair<string, double>(x.Key.CustomerName,x.Sum(x=>x.Product.Price) ??0));

        }

        public IEnumerable<Order> OrderFindByColor(string color) //finds the orders with the specified shoe color
        {
            return repo.ReadAll().Where(x => x.Product.Color == color).Select(x => x);
        }

        public IEnumerable<string> CustomerFindByPrePaidOrder() //finds the customers with prepaid orders
        {
            return repo.ReadAll().Where(x=>x.IsPrePaid==true).Select(x => x.Customer.CustomerName);
        }

        public IEnumerable<string> CustomersWhoNeedTransport() //finds the customers who need transport for their order(s)
        {
            return repo.ReadAll().Where(x=>x.IsPrePaid==true).Select(x => x.Customer.CustomerName);
        }
    
        
    }
}
