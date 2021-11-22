using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DYLHS5_HFT_2021221.Logic;
using DYLHS5_HFT_2021221.Models;
using DYLHS5_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;

namespace DYLHS5_HFT_2021221.Test
{
    [TestFixture]
    class BrandLogicTests
    {
        IBrandLogic logic;
        Brand brand1 = new Brand() { BrandName = "Gucci" };
        Brand brand2 = new Brand() { BrandName = "Adidas" };
        public void Setup()
        {
            Mock<IBrandRepository> mockedRepo = new Mock<IBrandRepository>();



            mockedRepo.Setup(x => x.ReadAll())
                .Returns((IQueryable<Brand>)new List<Product>() {
                    new Product() {
                        ProductName = "Classic",
                        BasePrice = 50000,
                        Size=42,
                        Color= "Red",
                        Brand= brand1},
                    new Product() {
                        ProductName = "LadyGaga",
                        BasePrice = 70000,
                        Size=40,
                        Color= "Black",
                        Brand= brand1},
                    new Product() {
                        ProductName = "Suprome",
                        BasePrice = 20000,
                        Size=43,
                        Color= "Orange",
                        Brand= brand1},
                    new Product() {
                        ProductName = "Striped",
                        BasePrice = 50000,
                        Size=41,
                        Color= "White",
                        Brand= brand2},
                    new Product() {
                        ProductName = "Freck",
                        BasePrice = 36000,
                        Size=42,
                        Color= "DarkBrown",
                        Brand= brand2},
                    }.AsQueryable());

            logic = new BrandLogic(mockedRepo.Object);

            
        }
        [Test]
        public void TestCreate()
        {
            Product product = new Product()
            {
                ProductName = "Designer",
                BasePrice = 36000,
                Size = 42,
                Color = "DarkBrown",
                Brand = brand1
            };

            

            

        }

        [Test]
        public void TestCase2() { }

        public void TestCase3()
        {

        }
        public void TestCase4()
        {

        }
        public void TestCase5() { }

    }
}
