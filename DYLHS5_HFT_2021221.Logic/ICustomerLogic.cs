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
        void Create(Customer brand);
        IQueryable<Customer> ReadAll();
        void Update(Customer brand);
        void Delete(int brandId);
    }
}
