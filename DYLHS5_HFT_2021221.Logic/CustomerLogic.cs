using DYLHS5_HFT_2021221.Logic.Exceptions;
using DYLHS5_HFT_2021221.Models;
using DYLHS5_HFT_2021221.Repository;
using System.Collections.Generic;
using System.Linq;

namespace DYLHS5_HFT_2021221.Logic
{
    public class CustomerLogic : ICustomerLogic
    {
        private ICustomerRepository repo;

        public CustomerLogic(ICustomerRepository repo)
        {
            this.repo = repo;
        }
        public void Create(Customer customer)
        {
            if (customer.CustomerId==null)
            {
                throw new IdMissingException("Missing customer ID");
            }
            if (customer.CustomerName==null)
            {
                throw new ProductOrCustomerNameMissingException("Missing cutomer name");
            }
            repo.Create(customer);
        }

        public void Delete(int customerId)
        {
            repo.Delete(customerId);
        }

        public IQueryable<Customer> GetAll()
        {
            return repo.GetAll();
        }

        public Customer GetOne(int customerId)
        {
            return repo.ReadOne(customerId);
        }

        public IQueryable<Customer> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Customer customer)
        {
            repo.Update(customer);
        }



        


    }
}

