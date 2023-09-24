using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class GenerateInvoicesSystem
{
  static void Main(string[] args)
  {
    Console.WriteLine("Simulation of invoice calculation in a billing system with parallelism.\n");

    List<Invoice> invoices = GenerateInvoices(100); // Generate 100 example invoices.

    // Divide invoices into batches for parallel calculation.
    int batchSize = 10;
    var batches = PartitionInvoices(invoices, batchSize);

    // Calculate the total for each batch in parallel.
    Parallel.ForEach(batches, batch =>
    {
      CalculateBatchTotal(batch);
    });

    Console.WriteLine("\nInvoice calculation completed. Details of some invoices:\n");

    // Display details of some invoices as examples.
    for (int i = 0; i < 5; i++)
    {
      Console.WriteLine($"Invoice {invoices[i].InvoiceNumber}: Total = ${invoices[i].Total}");
    }
  }

  // Class representing an invoice with items.
  class Invoice
  {
    public int InvoiceNumber { get; set; }
    public List<InvoiceItem> Items { get; set; }
    public decimal Total { get; set; }
  }

  // Class representing an item in an invoice.
  class InvoiceItem
  {
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
  }

  // Generate example invoices with items.
  static List<Invoice> GenerateInvoices(int count)
  {
    var invoices = new List<Invoice>();
    Random random = new Random();

    for (int i = 1; i <= count; i++)
    {
      var invoice = new Invoice
      {
        InvoiceNumber = i,
        Items = new List<InvoiceItem>()
      };

      // Add random items to the invoice.
      int itemCount = random.Next(1, 5);
      for (int j = 1; j <= itemCount; j++)
      {
        var item = new InvoiceItem
        {
          Description = $"Item {j}",
          Price = (decimal)random.NextDouble() * 100,
          Quantity = random.Next(1, 10)
        };
        invoice.Items.Add(item);
      }

      invoices.Add(invoice);
    }

    return invoices;
  }

  // Divide a list of invoices into batches.
  static List<List<Invoice>> PartitionInvoices(List<Invoice> invoices, int batchSize)
  {
    return invoices
        .Select((invoice, index) => new { Invoice = invoice, Index = index })
        .GroupBy(x => x.Index / batchSize)
        .Select(group => group.Select(x => x.Invoice).ToList())
        .ToList();
  }

  // Calculate the total for a batch of invoices.
  static void CalculateBatchTotal(List<Invoice> batch)
  {
    foreach (var invoice in batch)
    {
      invoice.Total = invoice.Items.Sum(item => item.Price * item.Quantity);
    }
  }
}
