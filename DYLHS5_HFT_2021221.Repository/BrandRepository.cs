﻿using DYLHS5_HFT_2021221.Data;
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
        XYZDbContext ctx;
        public BrandRepository(XYZDbContext ctx) : base(ctx)
        {
            this.ctx = ctx;
        }

        public void Create(Brand brand)
        {
            ctx.Brands.Add(brand);
            ctx.SaveChanges();
        }

        public void Delete(int brandId)
        {
            ctx.Brands.Remove(ReadOne(brandId));
            ctx.SaveChanges();
        }

        public IQueryable<Brand> ReadAll()
        {
            return ctx.Brands;
        }

        public Brand ReadOne(int brandId)
        {
            return ctx.Brands.FirstOrDefault(x => x.BrandId == brandId);
        }

        public void Update(Brand brand)
        {
            Brand old = ReadOne(brand.BrandId);

            old.BrandName = brand.BrandName;
            old.Products = brand.Products;
            
            ctx.SaveChanges();
        }
    }
}