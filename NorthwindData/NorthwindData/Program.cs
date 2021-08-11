using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace NorthwindData
{
    class Program
    {
        static void Main(string[] args)
        {

           
            
            using (var db = new NorthwindContext())
            {
				//Exercise 1
				//1.1 customers from paris or london including address
				// Query Syntax
				Console.WriteLine("1.1 Query Syntax");
                var CustomersQuery1 =
                    from c in db.Customers
                    where c.City == "Paris" || c.City == "London"
                    select c;

                foreach (var cu in CustomersQuery1)
                {
					Console.WriteLine($"CustomerID: {cu.CustomerId}  CompanyName: {cu.CompanyName} \tAddress: {cu.Address + " " + cu.City +" " + cu.Country}");
                }

				// Method Syntax 

				Console.WriteLine("\n1.1 Method Syntax");
                var CustomerQuery2 = db.Customers.Where(c => (c.City == "Paris" || c.City == "London")).Select(c =>c);
                foreach (var cu in CustomerQuery2)
                {
                    Console.WriteLine($"CustomerID: {cu.CustomerId}  CompanyName: {cu.CompanyName} \tAddress: {cu.Address + " " + cu.City +" " + cu.Country}");
                }

                //1.2 list all products stored in bottles
                // Query Syntax
                Console.WriteLine("\n1.2 Query Syntax");
                var bottleQuery1 = 
                    from p in db.Products
                    where p.QuantityPerUnit.Contains("bottle")
                    select p;

                foreach (var bottle in bottleQuery1)
                {
					Console.WriteLine($"{bottle.ProductName}");
                }
                
                // Method Syntax 
                Console.WriteLine("\n1.2 Method Syntax");
                var bottleQuery2 = db.Products.Where(p => p.QuantityPerUnit.Contains("bottle")).Select(p =>p);
                foreach (var bottle in bottleQuery2)
                {
                    Console.WriteLine($"{bottle.ProductName}");
                }

                //1.3
                // Query Syntax
                // Method Syntax 

                //1.4
                // Query Syntax
                // Method Syntax 


















                /*
                var ordersQuery =
                    from order in db.Orders.Include (o => o.Customer)
                    where order.Freight > 750
                    select order;
                foreach (var order in ordersQuery)
                {
                    if (order.Customer !=null)
						Console.WriteLine($"{order.Customer.CompanyName} of {order.Customer.City} paid {order.Freight}" +
                            $"for shipping");
                }

                var ordersQuery2 =
                    db.Orders.Include(o => o.Customer).Include(c => c.OrderDetails).Where(o => o.Freight > 750).Select(o => o);
                foreach (var o in ordersQuery2)
                {
					Console.WriteLine($"{o.OrderId} was made by {o.Customer.CompanyName}");
                    foreach (var od in o.OrderDetails) 
                    {
						Console.WriteLine($"\t ProductId: {od.ProductId}");
                    }
                }

                var ordersQuery3 =
                    db.Orders.Include(o => o.Customer).Include(c => c.OrderDetails).ThenInclude(od => od.Product).Where(o => o.Freight > 750);
                foreach (var o in ordersQuery3)
                {
					Console.WriteLine($"Order {o.OrderId} was made by {o.Customer.CompanyName}"
                        );
                    foreach (var od in o.OrderDetails)
                    {
						Console.WriteLine($"\t ProductId: {od.ProductId} - Product: {od.Product.ProductName} - " +
                            $"Quantity: {od.Quantity}");
                    }
                }

                var orderQuerryUsingJoin =
                    from order in db.Orders
                    where order.Freight > 750
                    join customer in db.Customers on order.CustomerId equals customer.CustomerId
                    select new { CustomerContactName = customer.ContactName, City = customer.City, Freight = order.Freight };

                foreach (var result in orderQuerryUsingJoin)
                {
					Console.WriteLine($"{result.CustomerContactName} of {result.City} paid {result.Freight} for shipping");
                }

                var orderCustomerBerlinParisQuery =
                    from o in db.Orders
                    join c in db.Customers on o.CustomerId equals c.CustomerId
                    where c.City == "Berlin" || c.City == "Paris"
                    select new { o.OrderId, c.CompanyName };
                foreach (var item in orderCustomerBerlinParisQuery)
                {
					Console.WriteLine($"Order with ID{item.OrderId} was ordered by {item.CompanyName}");
                }
                */
            }
        }

        public static long fibonacci(long num)
        {
            
            long[] array = new long[2];
            array.SetValue(1, 0);
            array.SetValue(2, 1);
            long even_sum = 0;
            //for (long i = 1; i <num; i++)
            while (even_sum<4000000)

            {
                long old_value = array[1];
                long new_value = array[0] + array[1];
                array.SetValue(new_value, 1);
                array.SetValue(old_value, 0);

                if (array[1] % 2 == 0)
                {
                    even_sum += array[1];
                }
            }

            return even_sum;
        }

        public static List<int> multiplesFive(int max)
        {
            List<int> multiplesFiveList = new List<int> { };
            for (int i = 1; i <= max; i++)
            {
                if (i%5==0) multiplesFiveList.Add(i);
            }
            return multiplesFiveList;
        }
    }
}
