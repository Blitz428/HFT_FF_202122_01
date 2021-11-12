using DYLHS5_HFT_2021221.Data;
using DYLHS5_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Repository
{
    public abstract class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(XYZDbContext ctx) : base(ctx)
        {
        }
    }
}
