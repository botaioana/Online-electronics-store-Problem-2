using System.Collections.Generic;
using System.Linq;

namespace SieMarketApp.Models;

public class Order
{
    public string CustomerName { get; set; } = string.Empty;
    public List<OrderItem> Items { get; set; } = new();

    public decimal GetTotalBeforeDiscount()
        => Items.Sum(i => i.GetTotal());

    public decimal GetFinalTotal()
    {
        var total = GetTotalBeforeDiscount();
        return total > 500m ? total * 0.9m : total;
    }
}