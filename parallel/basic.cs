using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class Program
{
  static void Main()
  {
    Parallel.For(0, 10, i => Console.WriteLine($"Hello from iteration {i} on thread {Thread.CurrentThread.ManagedThreadId}"));
  }
}
