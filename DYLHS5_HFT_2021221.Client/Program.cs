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
                    Console.WriteLine("Order Id:" + order.OrderId + "Order time:" + order.OrderTime + "Prepaid:" + order.IsPrePaid + "Transport needed:" + order.IsTransportRequired);
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
                .Add("Order", () => 
                {
                    Console.WriteLine("Is the order prepaid? y/n");
                    bool prepaid;
                    if (Console.ReadLine().Equals('y'))
                    {
                        prepaid = true;
                    }
                    else
                    {
                        prepaid = false;
                    }

                    Console.WriteLine("Does the order require transport? y/n");
                    bool isTransportRequired;
                    if (Console.ReadLine().Equals('y'))
                    {
                        isTransportRequired = true;
                    }
                    else
                    {
                        isTransportRequired = false;
                    }
                    restService.Post<Order>(new Order { IsPrePaid = prepaid, IsTransportRequired = isTransportRequired, }, "/order");
                    Console.WriteLine("Order added!");
                    Console.ReadLine();
                })
                .Add("Product", () => 
                {
                    Console.WriteLine("Add product name!");
                    string name= Console.ReadLine();
                    Console.WriteLine("Add product color!");
                    string color = Console.ReadLine();
                    Console.WriteLine("Add product size!");
                    int size = int.Parse(Console.ReadLine());
                    Console.WriteLine("Add product price!");
                    double price=double.Parse(Console.ReadLine());

                    restService.Post<Product>(new Product { ProductName = name, Color = color, Price = price, Size = size }, "/product");
                    Console.WriteLine("Product added!");
                    Console.ReadLine();
                })
                .Add("Customer", () => 
                {
                    Console.WriteLine("Add customer name!");
                    string name = Console.ReadLine();
                    Console.WriteLine("Add customer phone number!");
                    long number = long.Parse(Console.ReadLine());
                    Console.WriteLine("Add customer address!");
                    string address = Console.ReadLine();

                    restService.Post<Customer>(new Customer { Address = address, CustomerName = name, PhoneNumber = number }, "/customer");
                    Console.WriteLine("Customer added!");
                    Console.ReadLine();

                })
                .Add("Back", ConsoleMenu.Close).Show())

                 //UPDATE
                 .Add("Update...", () => new ConsoleMenu()
                 .Add("Order", () => 
                 {
                     Console.WriteLine("Which order do you want to update?");
                     int id = int.Parse(Console.ReadLine());

                     Console.WriteLine("Is the order prepaid? y/n");
                     bool prepaid;
                     if (Console.ReadLine().Equals('y'))
                     {
                         prepaid = true;
                     }
                     else
                     {
                         prepaid = false;
                     }

                     Console.WriteLine("Does the order require transport? y/n");
                     bool isTransportRequired;
                     if (Console.ReadLine().Equals('y'))
                     {
                         isTransportRequired = true;
                     }
                     else
                     {
                         isTransportRequired = false;
                     }
                     restService.Put<Order>(new Order {OrderId=id,IsPrePaid = prepaid, IsTransportRequired = isTransportRequired, }, "/order");
                     Console.WriteLine("Order updated!");
                     Console.ReadLine();
                 })
                 .Add("Product", () =>
                 {
                     Console.WriteLine("Add product name!");
                     string name = Console.ReadLine();
                     Console.WriteLine("Add product color!");
                     string color = Console.ReadLine();
                     Console.WriteLine("Add product size!");
                     int size = int.Parse(Console.ReadLine());
                     Console.WriteLine("Add product price!");
                     double price = double.Parse(Console.ReadLine());

                     restService.Put<Product>(new Product { ProductName = name, Color = color, Price = price, Size = size }, "/product");
                     Console.WriteLine("Product updated!");
                     Console.ReadLine();

                 })
                 .Add("Customer", () =>
                 {
                     Console.WriteLine("Add customer name!");
                     string name = Console.ReadLine();
                     Console.WriteLine("Add customer phone number!");
                     long number = long.Parse(Console.ReadLine());
                     Console.WriteLine("Add customer address!");
                     string address = Console.ReadLine();

                     restService.Put<Customer>(new Customer { Address = address, CustomerName = name, PhoneNumber = number }, "/customer");
                     Console.WriteLine("Customer updated!");
                     Console.ReadLine();

                 })
                 .Add("Back", ConsoleMenu.Close).Show())


                 .Add("Delete...", () => new ConsoleMenu()
                 .Add("Order", () =>
                 {
                     Console.WriteLine("Please enter the order's Id");
                     int id =int.Parse(Console.ReadLine());
                     foreach(Order order in restService.Get<Order>("/order"))
                     {
                         if (id==order.OrderId)
                         {
                             restService.Delete(id, "/order");
                         }


                     }
                     Console.WriteLine("Order deleted!");
                     Console.ReadLine();
                 })
                 .Add("Product", () =>
                 {
                     Console.WriteLine("Please enter the product's Id");
                     int id = int.Parse(Console.ReadLine());
                     foreach (Product product in restService.Get<Product>("/product"))
                     {
                         if (id == product.ProductId)
                         {
                             restService.Delete(id, "/product");
                         }


                     }
                     Console.WriteLine("Product deleted!");
                     Console.ReadLine();
                 })
                 .Add("Customer", () =>
                 {
                     Console.WriteLine("Please enter the customer's Id");
                     int id = int.Parse(Console.ReadLine());
                     foreach (Customer customer in restService.Get<Customer>("/customer"))
                     {
                         if (id == customer.CustomerId)
                         {
                             restService.Delete(id, "/customer");
                         }


                     }
                     Console.WriteLine("Customer deleted!");
                     Console.ReadLine();
                 })
                 .Add("Back", ConsoleMenu.Close).Show())

                 //NON-CRUDS
                 .Add("NON-CRUDS...", () => new ConsoleMenu()
                 .Add("GetOrdersByCustomername", () =>
                 {
                     Console.WriteLine("Please enter the customer's name");
                     int id = int.Parse(Console.ReadLine());
                     Console.WriteLine();
                     orders = restService.Get<Order>("order");

                 
                    
                 })
                 .Add("GetAddressesOfOrders", () =>
                 {

                 })
                 .Add("GetProductsWeNeedToTransport", () =>
                 {
                     products = restService.Get<Product>("/product-transport");
                     foreach (Product product in products)
                     {
                         Console.WriteLine("Id:" + product.ProductId + "Name:" + product.ProductName + "Color:" + product.Color + "Size:" + product.Size + "Price:" + product.Price + "FT");
                     }
                     Console.ReadLine();
                 })
                 .Add("GetCustomersWithThisSize", () =>
                 {

                 })
                 .Add("GetPrePaidOrdersByCustomers", () =>
                 {

                 })


                 .Add("Back", ConsoleMenu.Close).Show())



                 .Add(">> EXIT", ConsoleMenu.Close);


            menu.Show();
        } 
        
    }
}
