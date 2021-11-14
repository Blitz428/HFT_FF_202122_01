using DYLHS5_HFT_2021221.Data;
using DYLHS5_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Repository
{
    public abstract class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(XYZDbContext ctx) : base(ctx)
        {
        }
        protected XYZDbContext ctx;

        public void AddNew(Product newInstance)
        {
            ctx.Add(newInstance);
        }

        public void DeleteOld(Product oldInstance)
        {
            ctx.Remove(oldInstance);
        }

        public IQueryable<Product> GetAll()
        {
            return ctx.Set<Product>();
        }

        public abstract Product GetById(int id);
    }
}
