using DYLHS5_HFT_2021221.Logic;
using DYLHS5_HFT_2021221.Models;
using DYLHS5_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DYLHS5_HFT_2021221.Test
{
    [TestFixture]
    class OrderLogicTests
    {
        IOrderLogic logic;

        [SetUp]
        public void Setup()
        {
            Mock<IOrderRepository> mockedRepo = new Mock<IOrderRepository>();

            Product dorko1 = new Product() { ProductName = "BOUNCE", Color = "BROWN", Size = 41, Price = 24999 };
            Product dorko2 = new Product() { ProductName = "CARBONITE", Color = "BLACK", Size = 42, Price = 24999 };

            Product adidas1 = new Product() { ProductName = "ORIGINALS CONTINENTAL 80 STRIPES", Color = "BLACK", Size = 42, Price = 29999 };
            Product adidas2 = new Product() { ProductName = "PERFORMANCE HOOPS MID 2.0 K", Color = "BLACK", Size = 40, Price = 14999 };

            Product nike1 = new Product() { ProductName = "AIR PRESTO", Color = "ORANGE", Size = 40, Price = 44999 };
            Product nike2 = new Product() { ProductName = "REVOLUTION 5", Color = "GREY", Size = 45, Price = 19999 };

            Product converse1 = new Product() { ProductName = "RIVAL", Color = "GREY", Size = 41, Price = 24999 };
            Product converse2 = new Product() { ProductName = "COURTLANDT", Color = "GREY", Size = 44, Price = 9999 };

            Product vans1 = new Product() { ProductName = "OLD SKOOL", Color = "BLUE", Size = 41, Price = 29999 };
            Product vans2 = new Product() { ProductName = "ULTRARANGE EXO", Color = "BLACK", Size = 40, Price = 39999 };

            Customer customer1 = new Customer() { CustomerName = "A.Aladár", PhoneNumber = 06701234567, Address = "Randomcím1" };
            Customer customer2 = new Customer() { CustomerName = "B.Bence", PhoneNumber = 06701234568 };
            Customer customer3 = new Customer() { CustomerName = "C.Cecília", PhoneNumber = 06701234569, Address = "Randomcim2" };
            Customer customer4 = new Customer() { CustomerName = "D.Dávid", PhoneNumber = 06701234570 };
            Customer customer5 = new Customer() { CustomerName = "E.Elvira", PhoneNumber = 06701234571 };

            mockedRepo.Setup(x => x.ReadAll())
                .Returns(new List<Order>()
            {
                    new Order() //1
                    {
                        Product = dorko1,
                        Customer = customer1,
                        IsPrePaid = true,
                        IsTransportRequired = false
                    },
                    new Order() //2
                    {
                        Product = dorko2,
                        Customer = customer2,
                        IsPrePaid = false,
                        IsTransportRequired = true
                    },
                    new Order() //3
                    {
                        Product = adidas1,
                        Customer = customer1,
                        IsPrePaid = true,
                        IsTransportRequired = false
                    },
                    new Order() //4
                    {
                        Product = adidas2,
                        Customer = customer2,
                        IsPrePaid = true,
                        IsTransportRequired = true
                    },
                    new Order() //5
                    {
                        Product = nike1,
                        Customer = customer3,
                        IsPrePaid = false,
                        IsTransportRequired = false
                    },
                    new Order()
                    {
                        Product = nike2,
                        Customer = customer4,
                        IsPrePaid = true,
                        IsTransportRequired = false
                    },
                    new Order()
                    {
                        Product = converse1,
                        Customer = customer3,
                        IsPrePaid = false,
                        IsTransportRequired = false
                    },
                    new Order()
                    {
                        Product = converse2,
                        Customer = customer4,
                        IsPrePaid = true,
                        IsTransportRequired = true
                    },
                    new Order()
                    {
                        Product = vans1,
                        Customer = customer5,
                        IsPrePaid = true,
                        IsTransportRequired = true
                    },
                    new Order()
                    {
                        Product = vans2,
                        Customer = customer5,
                        IsPrePaid = true,
                        IsTransportRequired = true
                    },


            }.AsQueryable());

            logic = new OrderLogic(mockedRepo.Object);

        }

        [Test] //Create Exception #1
        public void CreateOrderMissingProductNameTest()
        {
            Product dorko3 = new Product() { Color = "GREEN", Size = 42, Price = 20099 };
            Customer customer6 = new Customer() { CustomerName = "F.Ferenc", PhoneNumber = 06701234572, Address = "Randomcím3" };

            var createdOrder = new Order()
            {
                Product = dorko3,
                Customer = customer6,
                IsPrePaid = true,
                IsTransportRequired = true
            };

            Assert.Throws<ProductOrCustomerNameMissingException>(() => logic.Create(createdOrder));
        }

        [Test] //Create Exception #2
        public void CreateOrderMissingCustomerTest()
        {
            Product dorko3 = new Product() { ProductName = "TEST", Color = "GREEN", Size = 42, Price = 20099 };
            var createdOrder = new Order()
            {
                Product = dorko3,
                IsPrePaid = true,
                IsTransportRequired = true
            };

            Assert.Throws<NullReferenceException>(() => logic.Create(createdOrder));
        }

        [Test] //Create Exception #3
        public void CreateBooleanExpressionMissingTest()
        {
            Product dorko3 = new Product() { ProductName = "TEST", Color = "GREEN", Size = 42, Price = 20099 };
            Customer customer6 = new Customer() { CustomerName = "F.Ferenc", PhoneNumber = 06701234572, Address = "Randomcím3" };
            var createdOrder = new Order()
            {
                Product = dorko3,
                Customer = customer6,

            };

            Assert.Throws<BooleanExpressionsAreNullException>(() => logic.Create(createdOrder));

        }

        [Test]
        public void CustomersWhoNeedTransportTest()
        {
            Assert.AreEqual(3, logic.CustomersWhoNeedTransport().Count()); //Bence,Dávid,Elvira

        }

        [Test]
        public void CustomerFindByPrePaidOrderTest()
        {
            Assert.AreEqual(4, logic.CustomerFindByPrePaidOrder().Count()); //Aladár,Bence,Dávid,Elvira
        }

        [Test]
        public void OrderFindByColorTest()
        {

            Assert.AreEqual(4, logic.OrderFindByColor("BLACK").Count()); //dorko2,adidas1,adidas2,vans2

        }

        [Test]
        public void CustomersBiggerThanThisShoeSizeTest()
        {
            Assert.AreEqual(7, logic.CustomersBiggerThanThisShoeSize(40).Count());
        }

        [Test]
        public void HighestPricedOrderTest()
        {
            Assert.AreEqual(49000, logic.HighestPricedOrder());

        }

        [Test]
        public void ReadAllTest()
        {
            Assert.AreEqual(10, logic.ReadAll().Count());
        }

        [Test]
        public void UpdateOrderTest()
        {
            Product dorko3 = new Product() {ProductName = "TEST", Color = "GREEN", Size = 42, Price = 20099 };
            Customer customer6 = new Customer() {CustomerName = "F.Ferenc", PhoneNumber = 06701234572, Address = "Randomcím3" };
            Order test = new Order() {IsPrePaid = true, IsTransportRequired = false, Product = dorko3, Customer = customer6 };

            logic.Update(test);

            Assert.IsTrue(logic.ReadAll().Contains(test));
            

        }

    }
}
