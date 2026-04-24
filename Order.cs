using System;

namespace OrderApp
{
    // This class holds the data for an individual order
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public double Amount { get; set; }

        // A simple constructor to make creating orders easier later
        public Order(int id, string name, double amount)
        {
            OrderId = id;
            CustomerName = name;
            Amount = amount;
        }
    }
}