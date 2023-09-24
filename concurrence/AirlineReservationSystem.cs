using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class AirlineReservationSystem
{
    private static object lockObj = new object();
    private static List<string> availableFlights = new List<string> { "Flight1", "Flight2", "Flight3" };

    static async Task Main(string[] args)
    {
        Console.WriteLine("Welcome to the Airline Reservation System!");
        Console.WriteLine("Available flights: Flight1, Flight2, Flight3");

        int numberOfPassengers = 5; // Number of passengers making reservations

        List<Task> reservationTasks = new List<Task>();

        for (int i = 1; i <= numberOfPassengers; i++)
        {
            int passengerNumber = i;
            Task reservationTask = Task.Run(() => MakeReservation(passengerNumber));
            reservationTasks.Add(reservationTask);
        }

        await Task.WhenAll(reservationTasks);

        Console.WriteLine("All reservations are complete. Thank you for booking with us!");
    }

    static void MakeReservation(int passengerNumber)
    {
        string passengerName = "Passenger" + passengerNumber;
        string selectedFlight;

        lock (lockObj)
        {
            if (availableFlights.Count > 0)
            {
                // Simulate selecting a flight
                selectedFlight = availableFlights[0];
                availableFlights.RemoveAt(0);
            }
            else
            {
                Console.WriteLine($"Sorry, {passengerName}, no available flights.");
                return;
            }
        }

        // Simulate reservation process
        Console.WriteLine($"{passengerName} is booking {selectedFlight}...");
        Task.Delay(2000).Wait(); // Simulate time needed for booking

        Console.WriteLine($"{passengerName} has successfully booked {selectedFlight}.");
    }
}
