using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    abstract class Vehicle
    {
        public double Speed { get; set; }
        public int Capacity { get; set; }

        public Vehicle(double speed, int capacity)
        {
            Speed = speed;
            Capacity = capacity;
        }

        public abstract void Move();
    }

    class Human
    {
        public double Speed { get; set; }

        public Human(double speed)
        {
            Speed = speed;
        }

        public void Move()
        {
            Console.WriteLine($"Людина рухається зі швидкістю {Speed} км/год.");
        }
    }

    class Car : Vehicle
    {
        public Car(double speed, int capacity) : base(speed, capacity) { }

        public override void Move()
        {
            Console.WriteLine($"Автомобіль рухається зі швидкістю {Speed} км/год, вміщує {Capacity} пасажирів.");
        }
    }

    class Bus : Vehicle
    {
        public Bus(double speed, int capacity) : base(speed, capacity) { }

        public override void Move()
        {
            Console.WriteLine($"Автобус рухається зі швидкістю {Speed} км/год, вміщує {Capacity} пасажирів.");
        }
    }

    class Train : Vehicle
    {
        public Train(double speed, int capacity) : base(speed, capacity) { }

        public override void Move()
        {
            Console.WriteLine($"Поїзд рухається зі швидкістю {Speed} км/год, вміщує {Capacity} пасажирів.");
        }
    }

    class Route
    {
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public double Distance { get; set; }

        public Route(string startPoint, string endPoint, double distance)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Distance = distance;
        }

        public double CalculateTravelTime(Vehicle vehicle)
        {
            return Distance / vehicle.Speed;
        }
    }

    class TransportNetwork
    {
        private List<Vehicle> vehicles = new();
        private List<Route> routes = new();

        public void AddVehicle(Vehicle vehicle) => vehicles.Add(vehicle);

        public void AddRoute(Route route) => routes.Add(route);

        public void Simulate()
        {
            foreach (var vehicle in vehicles)
            {
                foreach (var route in routes)
                {
                    Console.WriteLine($"Транспорт: {vehicle.GetType().Name}");
                    vehicle.Move();
                    Console.WriteLine($"Маршрут: {route.StartPoint} → {route.EndPoint}, Відстань: {route.Distance} км.");
                    Console.WriteLine($"Час у дорозі: {route.CalculateTravelTime(vehicle):F2} год.\n");
                }
            }
        }
    }

    class Program1
    {
        static void Main()
        {
            var car = new Car(100, 5);
            var bus = new Bus(60, 50);
            var train = new Train(200, 300);

            var route1 = new Route("Київ", "Львів", 540);
            var route2 = new Route("Одеса", "Харків", 750);

            var network = new TransportNetwork();
            network.AddVehicle(car);
            network.AddVehicle(bus);
            network.AddVehicle(train);

            network.AddRoute(route1);
            network.AddRoute(route2);

            network.Simulate();
        }
    }
}
