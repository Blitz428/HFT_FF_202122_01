using DYLHS5_HFT_2021221.Data;
using DYLHS5_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Repository
{
    public abstract class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(XYZDbContext ctx) : base(ctx)
        {
        }
        protected XYZDbContext ctx;

        public void AddNew(Brand newInstance)
        {
            ctx.Add(newInstance);
        }

        public void DeleteOld(Brand oldInstance)
        {
            ctx.Remove(oldInstance);
        }

        public IQueryable<Brand> GetAll()
        {
            return ctx.Set<Brand>();
        }

        public abstract Brand GetById(int id);

    }
}
