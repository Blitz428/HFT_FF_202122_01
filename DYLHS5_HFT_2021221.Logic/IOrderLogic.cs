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
        void Create(Order order);
        IQueryable<Order> ReadAll();
        void Update(Order order);
        void Delete(int orderId);
    }
}
