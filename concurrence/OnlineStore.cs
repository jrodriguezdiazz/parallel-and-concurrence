using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class OnlineStore
{
  static void Main(string[] args)
  {
    Console.WriteLine("Welcome to the Online Store Order Processing System!");

    int numberOfOrders = 10; // Number of orders to process

    List<Task> orderTasks = new List<Task>();

    for (int i = 1; i <= numberOfOrders; i++)
    {
      int orderNumber = i;
      Task orderTask = Task.Run(() => ProcessOrder(orderNumber));
      orderTasks.Add(orderTask);
    }

    Task.WhenAll(orderTasks).Wait(); // Wait for all tasks to complete

    Console.WriteLine("All orders have been processed. Thank you for shopping with us!");
  }

  static void ProcessOrder(int orderNumber)
  {
    string customerName = "Customer" + orderNumber;

    // Simulate order processing
    Console.WriteLine($"{customerName} is placing an order...");
    Task.Delay(2000).Wait(); // Simulate time needed for order processing

    Console.WriteLine($"{customerName}'s order has been processed.");
  }
}
