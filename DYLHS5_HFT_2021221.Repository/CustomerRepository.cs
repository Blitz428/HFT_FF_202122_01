﻿using DYLHS5_HFT_2021221.Data;
using DYLHS5_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Repository
{
    public abstract class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        XYZDbContext ctx;
        public CustomerRepository(XYZDbContext ctx) : base(ctx)
        {
            this.ctx = ctx;
        }

        public void Create(Customer brand) //C
        {
            ctx.Customers.Add(brand);
            ctx.SaveChanges();
        }

        public void Delete(int customerId) //D
        {
            ctx.Customers.Remove(ReadOne(customerId));
            ctx.SaveChanges();
        }

        public IQueryable<Customer> ReadAll() //R1
        {
            return ctx.Customers;
        }

        public Customer ReadOne(int customerId) //R2
        {
            return ctx.Customers.FirstOrDefault(x => x.CustomerId == customerId);
        }

        public void Update(Customer customer) //U
        {
            Customer old = ReadOne(customer.CustomerId);

            old.CustomerId=customer.CustomerId;
            old.CustomerName=customer.CustomerName;
            old.Address=customer.Address;
            old.Orders=customer.Orders;
            old.PhoneNumber=customer.PhoneNumber;

            ctx.SaveChanges();
        }
    }
}