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
    }
}
