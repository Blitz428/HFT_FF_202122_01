using DYLHS5_HFT_2021221.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Client
{
    public static class MenuMethods
    {
        private const string Enter = "Enter id here: ";
        private const string PressEnter = "Press Enter";
        private const string Selected = "\n:: Selected Item ::\n";
        private const string Other = "Try an other ID:";
        private const string Saved = "Saved!";


        public static void ListAllC(CustomerLogic customerLogic)
        {
            Console.WriteLine("All customers:");
            customerLogic?.ReadAll()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        public static void ListAllC(OrderLogic orderLogic)
        {
            Console.WriteLine("All orders:");
            orderLogic?.ReadAll()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        public static void ListAllC(ProductLogic productLogic)
        {
            Console.WriteLine("All products:");
            productLogic?.ReadAll()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        public static void GetOne(CustomerLogic customerLogic)
        {
            int id = int.Parse(Enter.ToString());

            Console.WriteLine(customerLogic?.GetOne(id).ToString());

            Console.ReadLine();
        }
        public static void GetOne(OrderLogic orderLogic)
        {
            int id = int.Parse(Enter.ToString());

            Console.WriteLine(orderLogic?.GetOne(id).ToString());

            Console.ReadLine();
        }
        public static void GetOne(ProductLogic productLogic)
        {
            int id = int.Parse(Enter.ToString());

            Console.WriteLine(productLogic?.GetOne(id).ToString());

            Console.ReadLine();
        }


    }
}
