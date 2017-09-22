using System;
using System.Linq;

namespace DemoLinQ
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // The Three Parts of a LINQ Query:
            //  1. Data source.
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            // 2. Query creation.
            // evenNumQuery is an IEnumerable<int>.
            var evenNumQuery =
                from num in numbers
                where (num % 2) == 0
                select num;
            foreach (int num in evenNumQuery)
            {
                Console.Write("{0,1} ", num);
            }

            Console.WriteLine("");

            // Query select & order.
            Customer[] customers = {
                new Customer("David", "London"),
                new Customer("Joe", "London"),
                new Customer("May", "New York")
            };
            var queryLondonCustomers =
                from cust in customers
                where cust.City == "London"// && cust.Name == "David"
                orderby cust.Name ascending
                select cust;
            foreach (var customer in queryLondonCustomers)
            {
                Console.WriteLine(customer.Name);
            }

            // Query group.
            var queryCustomersByCity =
                from cust in customers
                group cust by cust.City into custGroup
                where custGroup.Count() > 2
                orderby custGroup.Key ascending
                select custGroup;

            foreach (var customerGroup in queryCustomersByCity)
            {
                Console.WriteLine(customerGroup.Key);
                foreach (Customer customer in customerGroup)
                {
                    Console.WriteLine("  {0}", customer.Name);
                }
            }

            // Query joining.
            Distributor[] distributors = {
                new Distributor("David", "London"),
                new Distributor("Joe", "London"),
                new Distributor("May", "New York")
            };

            var innerJoinQuery =
                from cust in customers
                join dist in distributors on cust.City equals dist.City
                //from cust in queryCustomersByCity
                //join dist in distributors on cust.Key equals dist.City
                select new
                {
                    CustomerName = cust.Name,
                    DistributorName = dist.Name
                };

            foreach (var newData in innerJoinQuery)
            {
                Console.WriteLine(newData.CustomerName + " " + newData.DistributorName);
            }
        }
    }

    class Customer
    {
        string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        string _city;
        public string City
        {
            get => _city;
            set => _city = value;
        }

        public Customer(string name, string city)
        {
            this._name = name;
            this._city = city;
        }
    }

    class Distributor : Customer
    {
        public Distributor(string name, string city) : base(name, city)
        {
        }
    }
}
