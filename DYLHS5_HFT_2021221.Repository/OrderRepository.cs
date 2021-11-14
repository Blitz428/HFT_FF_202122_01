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
        protected XYZDbContext ctx;

        public void AddNew(Order newInstance)
        {
            ctx.Add(newInstance);
        }

        public void DeleteOld(Order oldInstance)
        {
            ctx.Remove(oldInstance);
        }

        public IQueryable<Order> GetAll()
        {
            return ctx.Set<Order>();
        }

        public abstract Order GetById(int id);
    }
}
