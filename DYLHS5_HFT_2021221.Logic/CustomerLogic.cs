using DYLHS5_HFT_2021221.Models;
using DYLHS5_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Logic
{
    public class CustomerLogic : ICustomerLogic
    {
        ICustomerRepository repo;

        public CustomerLogic(ICustomerRepository repo)
        {
            this.repo = repo;
        }
        public void Create(Customer brand)
        {
            repo.Create(brand);
        }

        public void Delete(int brandId)
        {
            repo.Delete(brandId);
        }

        public IQueryable<Customer> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Customer brand)
        {
            repo.Update(brand);
        }
    }
}
