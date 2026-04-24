using System;

namespace OrderApp
{
    // 1. Define the Delegate (The blueprint for the notification methods)
    public delegate void OrderPlacedHandler(Order order);

    public class OrderProcessor
    {
        // 2. Define the Event using the delegate
        public event OrderPlacedHandler OnOrderPlaced;

        public void ProcessOrder(Order order)
        {
            Console.WriteLine($"Order Placed: {order.OrderId}");

            // 3. Trigger the event (Notify all subscribers)
            // The ?. ensures it only runs if someone has subscribed (null-safe)
            OnOrderPlaced?.Invoke(order);
        }
    }
}