using SieMarketApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SieMarketApp.Services;

public static class OrderAnalytics
{
    public static string? GetTopCustomer(IEnumerable<Order> orders)
    {
        return orders
            .GroupBy(o => o.CustomerName)
            .Select(g => new
            {
                Customer = g.Key,
                TotalSpent = g.Sum(o => o.GetFinalTotal())
            })
            .OrderByDescending(x => x.TotalSpent)
            .FirstOrDefault()?.Customer;
    }

    public static Dictionary<string, int> GetPopularProducts(IEnumerable<Order> orders)
    {
        return orders
            .SelectMany(o => o.Items)
            .GroupBy(i => i.ProductName)
            .ToDictionary(
                g => g.Key,
                g => g.Sum(i => i.Quantity)
            );
    }
}