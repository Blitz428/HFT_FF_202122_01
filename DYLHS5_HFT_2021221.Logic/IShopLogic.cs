using DYLHS5_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Logic
{
    public interface IShopLogic
    {
        IEnumerable<Order> GetOrdersByCustomername(string customername);

        IEnumerable<KeyValuePair<Order, string>> GetAddressesOfOrders();

        IEnumerable<Product> GetProductsWeNeedToTransport();

        IEnumerable<Customer> GetCustomersWithThisSize(int size);


    }
}
