using System;

namespace VehicleExtention
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carLitersPerKm = double.Parse(carInfo[2]);
            double carFuelCapacity = double.Parse(carInfo[3]);
            
            string[] truckInfo = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckLitersPerKm = double.Parse(truckInfo[2]);
            double truckFuelCapacity = double.Parse(truckInfo[3]);
            
            string[] busInfo = Console.ReadLine().Split();
            double busFuelQuantity = double.Parse(busInfo[1]);
            double busLitersPerKm = double.Parse(busInfo[2]);
            double busFuelCapacity = double.Parse(busInfo[3]);

            IVehicle car = new Car(carFuelQuantity, carLitersPerKm, carFuelCapacity);
            IVehicle truck = new Truck(truckFuelQuantity, truckLitersPerKm, truckFuelCapacity);
            IVehicle bus = new Bus(busFuelQuantity, busLitersPerKm, busFuelCapacity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();
                string action = commands[0];
                string type = commands[1];
                double value = double.Parse(commands[2]);

                try
                {
                    if (action == "Drive")
                    {
                        if (type == "Car")
                        {
                            if (car.CanDrive(value))
                            {
                                car.Drive(value);
                                Console.WriteLine($"Car travelled {value} km");
                            }
                            else
                            {
                                Console.WriteLine("Car needs refueling");
                            }
                        }

                        else if (type == "Truck")
                        {
                            if (truck.CanDrive(value))
                            {
                                truck.Drive(value);
                                Console.WriteLine($"Truck travelled {value} km");
                            }
                            else
                            {
                                Console.WriteLine("Truck needs refueling");
                            }
                        }
                        else if (type == "Bus")
                        {
                            bus.IsEmpty = false;
                            if (bus.CanDrive(value))
                            {
                                bus.Drive(value);
                                Console.WriteLine($"Bus travelled {value} km");
                            }
                            else
                            {
                                Console.WriteLine("Bus needs refueling");
                            }
                        }
                    }

                    else if (action == "Refuel")
                    {
                        if (type == "Car")
                        {
                            car.Refuel(value);
                        }

                        else if (type == "Truck")
                        {
                            truck.Refuel(value);
                        }

                        else if (type == "Bus")
                        {
                            bus.Refuel(value);
                        }
                    }

                    else if (action == "DriveEmpty")
                    {
                        bus.IsEmpty = true;
                        if (bus.CanDrive(value))
                        {
                            bus.Drive(value);
                            Console.WriteLine($"Bus travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Bus needs refueling");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
