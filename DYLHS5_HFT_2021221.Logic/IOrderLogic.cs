using DYLHS5_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Logic
{
    public interface IOrderLogic
    {
        IQueryable<Order> GetAll();
        void Create(Order order);
        IQueryable<Order> ReadAll();
        void Update(Order order);
        void Delete(int? orderId);
        Order GetOne(int? orderId);

    }
}
