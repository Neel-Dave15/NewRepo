using System;
using System.Collections.Generic;

public abstract class Vehicle
{
    public string Model { get; private set; }
    public string Type { get; private set; }

    protected Vehicle(string model, string type)
    {
        Model = model;
        Type = type;
    }
}

public class Car : Vehicle
{
    public Car(string model) : base(model, "Car") { }
}

public class Truck : Vehicle
{
    public Truck(string model) : base(model, "Truck") { }
}

public class ParkingSpot
{
    public int SpotNumber { get; }
    public Vehicle ParkedVehicle { get; private set; }

    public bool IsOccupied => ParkedVehicle != null;

    public ParkingSpot(int spotNumber)
    {
        SpotNumber = spotNumber;
    }

    public bool ParkVehicle(Vehicle vehicle)
    {
        if (IsOccupied) return false;
        ParkedVehicle = vehicle;
        Console.WriteLine($"{vehicle.Type} {vehicle.Model} parked at spot {SpotNumber}.");
        return true;
    }

    public void RemoveSpot()
    {
        if (IsOccupied)
        {
            Console.WriteLine($"{ParkedVehicle.Type} {ParkedVehicle.Model} left spot {SpotNumber}.");
            ParkedVehicle = null;
        }
        else
        {
            Console.WriteLine($"Spot {SpotNumber} is already empty.");
        }
    }
}

public class ParkingLot
{
    private List<ParkingSpot> spots;

    public int Capacity => spots.Count;
    public int AvailableSpots => spots.FindAll(spot => !spot.IsOccupied).Count;

    public ParkingLot(int capacity)
    {
        spots = new List<ParkingSpot>();
        for (int i = 1; i <= capacity; i++)
        {
            spots.Add(new ParkingSpot(i));
        }
    }

    public bool ParkVehicle(Vehicle vehicle)
    {
        ParkingSpot availableSpot = spots.Find(spot => !spot.IsOccupied);
        if (availableSpot == null)
        {
            Console.WriteLine("Parking lot is full.");
            return false;
        }
        return availableSpot.ParkVehicle(vehicle);
    }

    public void RemoveSpot(int spotNumber)
    {
        if (spotNumber > 0 && spotNumber <= Capacity)
        {
            spots[spotNumber - 1].RemoveSpot();
        }
        else
        {
            Console.WriteLine("Invalid spot number.");
        }
    }

    public void DisplayParkingStatus()
    {
        Console.WriteLine("\nParking Lot Status:");
        foreach (var spot in spots)
        {
            string status = spot.IsOccupied
                ? $"Occupied by {spot.ParkedVehicle.Type} {spot.ParkedVehicle.Model}"
                : "Available";
            Console.WriteLine($"Spot {spot.SpotNumber}: {status}");
        }
        Console.WriteLine($"Available Spots: {AvailableSpots}/{Capacity}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter parking lot capacity: ");
        int capacity = int.Parse(Console.ReadLine());

        ParkingLot parkingLot = new ParkingLot(capacity);

        while (true)
        {
            Console.WriteLine("\n1. Park vehicle");
            Console.WriteLine("2. Empty spot");
            Console.WriteLine("3. Display status");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter vehicle type (Car/Truck): ");
                    string type = Console.ReadLine();
                    Console.Write("Enter vehicle model: ");
                    string model = Console.ReadLine();

                    Vehicle vehicle = type.ToLower() == "car" ? new Car(model) : new Truck(model);
                    parkingLot.ParkVehicle(vehicle);
                    break;

                case 2:
                    Console.Write("Enter spot number to Remove: ");
                    int spotNumber = int.Parse(Console.ReadLine());
                    parkingLot.RemoveSpot(spotNumber);
                    break;

                case 3:
                    parkingLot.DisplayParkingStatus();
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
