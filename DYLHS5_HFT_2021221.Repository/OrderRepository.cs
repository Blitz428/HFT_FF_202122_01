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

        public void Create(Order order)
        {
            ctx.Orders.Add(order);
            ctx.SaveChanges();
        }

        public Order ReadOne(int orderId)
        {
            return ctx.Orders.FirstOrDefault(x=>x.OrderId==orderId);
        }

        public IQueryable<Order> ReadAll()
        {
            return ctx.Orders;
        }

        public void Update(Order order)
        {
            Order old = ReadOne(order.OrderId);

            old.Product = order.Product;
            

            ctx.SaveChanges();
            
        }

        public void Delete(int orderId)
        {
            ctx.Orders.Remove(ReadOne(orderId));
            ctx.SaveChanges();
        }
    }
}
