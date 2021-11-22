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

        public void Create(Product product)
        {
            ctx.Products.Add(product);
            ctx.SaveChanges();
        }

        public Product ReadOne(int productId)
        {
            return ctx.Products.FirstOrDefault(x => x.ProductId == productId);
        }

        public IQueryable<Product> ReadAll()
        {
            return ctx.Products;
        }

        public void Update(Product product)
        {
            Product old = ReadOne(product.ProductId);

            old.Brand = product.Brand;
            old.Orders = product.Orders;
            old.BrandID = product.BrandID;
            old.Orders = product.Orders;
            old.BasePrice = product.BasePrice;
            old.Size = product.Size;
            old.Color = product.Color;
            old.ProductName = product.ProductName;

            ctx.SaveChanges();
            
        }

        public void Delete(int productId)
        {
            ctx.Products.Remove(ReadOne(productId));
            ctx.SaveChanges();
        }
    }
}
