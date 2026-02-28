using SieMarketApp.Models;
using SieMarketApp.Services;

var orders = new List<Order>
{
    new Order
    {
        CustomerName = "Alice",
        Items =
        {
            new OrderItem { ProductName = "Laptop", Quantity = 1, UnitPrice = 900m },
            new OrderItem { ProductName = "Mouse", Quantity = 2, UnitPrice = 25m }
        }
    },
    new Order
    {
        CustomerName = "Bob",
        Items =
        {
            new OrderItem { ProductName = "Monitor", Quantity = 2, UnitPrice = 200m },
            new OrderItem { ProductName = "Keyboard", Quantity = 1, UnitPrice = 80m }
        }
    },
    new Order
    {
        CustomerName = "Alice",
        Items =
        {
            new OrderItem { ProductName = "Headphones", Quantity = 3, UnitPrice = 60m }
        }
    }
};

Console.WriteLine("=== Order Totals ===");
foreach (var order in orders)
{
    Console.WriteLine($"{order.CustomerName} -> {order.GetFinalTotal():0.00} €");
}

Console.WriteLine($"\nTop customer: {OrderAnalytics.GetTopCustomer(orders)}");

Console.WriteLine("\nPopular products:");
foreach (var p in OrderAnalytics.GetPopularProducts(orders))
{
    Console.WriteLine($"{p.Key}: {p.Value}");
}