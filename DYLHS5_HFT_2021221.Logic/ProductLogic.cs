using DYLHS5_HFT_2021221.Models;
using DYLHS5_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Logic
{
    public class ProductLogic : IProductLogic
    {
        private IProductRepository repo;
        public ProductLogic(IProductRepository repo)
        {
            this.repo = repo;
        }
        public IQueryable<Product> GetAll()
        {
            return repo.GetAll();
        }

        public void Create(Product product)
        {
            repo.Create(product);
        }

        public void Delete(int productId)
        {
            repo.Delete(productId);
        }

        public IQueryable<Product> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Product product)
        {
            repo.Update(product);
        }

        public Product GetOne(int productId)
        {
            return repo.ReadOne(productId);
        }
    }
}
