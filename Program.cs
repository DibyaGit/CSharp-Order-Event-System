using System;
using OrderApp.Services; // This connects to your folder

namespace OrderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Initialize the Processor and Services
            OrderProcessor processor = new OrderProcessor();
            EmailService emailService = new EmailService();
            SMSService smsService = new SMSService();
            LoggerService loggerService = new LoggerService();

            // 2. Subscribe to the event (The Multicast Delegate)
            // This links the event to the specific methods in our services
            processor.OnOrderPlaced += emailService.SendEmail;
            processor.OnOrderPlaced += smsService.SendSMS;
            processor.OnOrderPlaced += loggerService.LogOrder;

            // 3. Create a sample order
            Order myOrder = new Order(101, "John Doe", 250.00);

            // 4. Process the order and trigger notifications
            processor.ProcessOrder(myOrder);

            // 5. Dynamic Unsubscribe (Bonus/Requirement)
            // Let's say the customer doesn't want SMS anymore
            Console.WriteLine("\n--- Unsubscribing SMS Service ---");
            processor.OnOrderPlaced -= smsService.SendSMS;

            // Process another order to see the change
            Order secondOrder = new Order(102, "Jane Smith", 450.00);
            processor.ProcessOrder(secondOrder);

            // Keep the console window open
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}