using DYLHS5_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Repository
{
    public interface IOrderRepository
    {
        void Create(Order order);
        Order ReadOne(int? orderId);
        IQueryable<Order> ReadAll();
        void Update(Order order);
        void Delete(int? orderId);
        IQueryable<Order> GetAll();
    }
}
