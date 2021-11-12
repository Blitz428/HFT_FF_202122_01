using DYLHS5_HFT_2021221.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Repository
{
    public abstract class Repository<T>: IRepository<T> where T : class
    {
        protected XYZDbContext ctx;
        public Repository(XYZDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void AddNew(T newInstance)
        {
            ctx.Add(newInstance);
        }

        public void DeleteOld(T oldInstance)
        {
            ctx.Remove(oldInstance);
        }

        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }

        public abstract T GetById(int id);
    }
}
