using DYLHS5_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Logic
{
    public interface ICustomerLogic
    {
        void Create(Customer customer);
        IQueryable<Customer> ReadAll();
        void Update(Customer customer);
        void Delete(int customerId);
    }
}
