using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


class SearchParallel
{
  static void Main(string[] args)
  {
    Foo().Wait();
  }
  static async Task Foo()
  {
    Console.WriteLine("CSV Parallel Search Example");

    string csvFilePath = "supermarket.csv"; // Replace with your CSV file path

    // Read the CSV file and store the data in a list of objects
    List<Item> items = await ReadCsvAsync(csvFilePath);

    // Perform parallel search
    string searchTerm = "icum"; // Replace with the desired search term
    List<Item> searchResults = await ParallelSearchAsync(items, searchTerm);

    // Print the results
    Console.WriteLine($"Results for '{searchTerm}':");
    foreach (var result in searchResults)
    {
      Console.WriteLine($"~~~~~\nItem Code: {result.ItemCode}\nItem Name: {result.ItemName}\nCategory Code: {result.CategoryCode}Category Name: {result.CategoryName}");
    }
  }

  static async Task<List<Item>> ReadCsvAsync(string filePath)
  {
    List<Item> items = new List<Item>();

    using (StreamReader reader = new StreamReader(filePath))
    {
      // Read the first line (headers) and discard it if needed
      await reader.ReadLineAsync();

      while (!reader.EndOfStream)
      {
        string line = await reader.ReadLineAsync();
        string[] values = line.Split(',');

        // Ensure there are enough values in the line before processing
        if (values.Length >= 4)
        {
          Item item = new Item
          {
            ItemCode = values[0],
            ItemName = values[1],
            CategoryCode = values[2],
            CategoryName = values[3]
          };

          items.Add(item);
        }
      }
    }

    return items;
  }

  static async Task<List<Item>> ParallelSearchAsync(List<Item> items, string searchTerm)
  {
    return await Task.Run(() =>
    {
      // Perform parallel search using LINQ
      List<Item> results = items.AsParallel()
              .Where(item =>
                  item.ItemCode.Contains(searchTerm) ||
                  item.ItemName.Contains(searchTerm) ||
                  item.CategoryCode.Contains(searchTerm) ||
                  item.CategoryName.Contains(searchTerm))
              .ToList();

      return results;
    });
  }
}

class Item
{
  public string ItemCode { get; set; }
  public string ItemName { get; set; }
  public string CategoryCode { get; set; }
  public string CategoryName { get; set; }
}
