using System;
using System.Collections.Generic;
using System.Linq;

namespace Program2
{
    class Order
    {
        public int OrderID { get; set; }
        public string ProductName { get; set; }
        public int CustomerID { get; set; }
    }

    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>
        {
            new Order { OrderID = 1, ProductName = "Product A", CustomerID = 101 },
            new Order { OrderID = 2, ProductName = "Product B", CustomerID = 102 },
            new Order { OrderID = 3, ProductName = "Product C", CustomerID = 101 },
            new Order { OrderID = 4, ProductName = "Product D", CustomerID = 103 },
        };

            List<Customer> customers = new List<Customer>
        {
            new Customer { CustomerID = 101, CustomerName = "Alice" },
            new Customer { CustomerID = 102, CustomerName = "Bob" },
            new Customer { CustomerID = 103, CustomerName = "Charlie" },
        };

            // Using Join to combine orders and customers based on CustomerID
            var query = from order in orders
                        join customer in customers on order.CustomerID equals customer.CustomerID
                        select new
                        {
                            OrderID = order.OrderID,
                            ProductName = order.ProductName,
                            CustomerName = customer.CustomerName
                        };

            // Displaying the result
            foreach (var result in query)
            {
                Console.WriteLine($"OrderID: {result.OrderID}, Product: {result.ProductName}, Customer: {result.CustomerName}");
            }

            //Distinct
            var uniqueCustomerIDs = orders.Select(order => order.CustomerID).Distinct();
            Console.WriteLine("Distinct Customer IDs:");
            foreach (var id in uniqueCustomerIDs)
            {
                Console.WriteLine(id);
            }

            //Except
            var ordersByNonExistingCustomers = orders.Except(orders.Join(customers, order => order.CustomerID, customer => customer.CustomerID, (order, customer) => order));
            Console.WriteLine("Distinct Customer IDs:");
            foreach (var id in uniqueCustomerIDs)
            {
                Console.WriteLine(id);
            }

            //intersection
            var ordersByCommonCustomers = orders.Intersect(orders.Join(customers, order => order.CustomerID, customer => customer.CustomerID, (order, customer) => order));
            Console.WriteLine("\nOrders by Common Customers:");
            foreach (var order in ordersByCommonCustomers)
            {
                Console.WriteLine($"OrderID: {order.OrderID}, Product: {order.ProductName}, CustomerID: {order.CustomerID}");
            }

            //union
            var allOrders = orders.Union(orders.Join(customers, order => order.CustomerID, customer => customer.CustomerID, (order, customer) => order));
            Console.WriteLine("\nAll Orders (including duplicates):");
            foreach (var order in allOrders)
            {
                Console.WriteLine($"OrderID: {order.OrderID}, Product: {order.ProductName}, CustomerID: {order.CustomerID}");
            }

            // GroupJoin orders and customers based on CustomerID
            var groupedOrders = customers
                .GroupJoin(
                    orders,
                    customer => customer.CustomerID,
                    order => order.CustomerID,
                    (customer, customerOrders) => new
                    {
                        CustomerName = customer.CustomerName,
                        Orders = customerOrders
                    });

            // Displaying the result
            foreach (var group in groupedOrders)
            {
                Console.WriteLine($"Customer: {group.CustomerName}");
                foreach (var order in group.Orders)
                {
                    Console.WriteLine($"  OrderID: {order.OrderID}, Product: {order.ProductName}");
                }
            }
        }
    }
}