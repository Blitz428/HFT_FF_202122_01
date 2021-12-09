using ConsoleTools;
using DYLHS5_HFT_2021221.Data;
using DYLHS5_HFT_2021221.Logic;
using DYLHS5_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace DYLHS5_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            XYZDbContext dbContext = new XYZDbContext();
            Console.WriteLine("Client started successfully.");

            RestService restService = new RestService("http://localhost:27588/");
            List<Order> orders = new List<Order>();
            List<Product> products = new List<Product>();
            List<Customer> customers = new List<Customer>();
            Order order = new Order();
            Product product = new Product();
            Customer customer = new Customer();

            var menu = new ConsoleMenu()

                //READALL
                .Add("Get all...", () => new ConsoleMenu()
                .Add("Orders", () =>
                {
                    restService.Get<Order>("/order").ForEach(order => Console.WriteLine(order.ToString()));
                    Console.ReadLine();
                })
                .Add("Products", () =>
                {
                    products = restService.Get<Product>("/product");
                    foreach (Product product in products)
                    {
                        Console.WriteLine("Id:" + product.ProductId + "Name:" + product.ProductName + "Color:" + product.Color + "Size:" + product.Size + "Price:" + product.Price + "FT");
                    }
                    Console.ReadLine();
                })
                .Add("Customers", () =>
                {
                    customers = restService.Get<Customer>("/customer");
                    foreach (Customer customer in customers)
                    {
                        Console.WriteLine("Id:" + customer.CustomerId + "Name:" + customer.CustomerName + "Phone:" + customer.PhoneNumber + "Address:" + customer.Address);
                    }
                    Console.ReadLine();
                })
                .Add("Back", ConsoleMenu.Close).Show())

                //READ
                .Add("Get one...", ()=>new ConsoleMenu()
                .Add("Order", () =>
                {
                    Console.WriteLine("Enter an id!");
                    int id = int.Parse(Console.ReadLine());
                    order = restService.GetSingle<Order>("/order/"+id);
                    Console.WriteLine("Id:" + order.OrderId + "Order time:" + order.OrderTime + "Prepaid:" + order.IsPrePaid + "Transport needed:" + order.IsTransportRequired);
                    Console.ReadLine();
                })
                .Add("Product", () =>
                {
                    Console.WriteLine("Enter an id!");
                    int id = int.Parse(Console.ReadLine());
                    product = restService.GetSingle<Product>("/product/" + id);
                    Console.WriteLine("Id:" + product.ProductId + "Name:" + product.ProductName + "Color:" + product.Color + "Size:" + product.Size + "Price:" + product.Price + "FT");
                    Console.ReadLine();
                })
                .Add("Customer", () =>
                {
                    Console.WriteLine("Enter an id!");
                    int id = int.Parse(Console.ReadLine());
                    customer = restService.GetSingle<Customer>("/customer/" + id);
                    Console.WriteLine("Id:" + customer.CustomerId + "Name:" + customer.CustomerName + "Phone:" + customer.PhoneNumber + "Address:" + customer.Address);
                    Console.ReadLine();
                })
                .Add("Back", ConsoleMenu.Close).Show())

                //CREATE
                .Add("Create new...",()=>new ConsoleMenu()
                .Add("Order", () => { })
                .Add("Product", () => { })
                .Add("Customer", () => { })
                .Add("Back", ConsoleMenu.Close).Show())


                .Add(">> EXIT", ConsoleMenu.Close);


            menu.Show();
        } 
        
    }
}
