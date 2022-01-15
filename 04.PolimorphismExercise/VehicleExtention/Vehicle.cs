using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleExtention
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelConsumption;
        private double fuelQuantity;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (value > tankCapacity)
                {
                    value = 0;
                }

                fuelQuantity = value;
            }

        }

        public virtual double FuelConsumption
        {
            get => fuelConsumption;
            set => fuelConsumption = value;
        }

        public double TankCapacity 
        {
            get => tankCapacity; 
            set => tankCapacity = value; 
        }

        public bool IsEmpty { get; set; }

        public bool CanDrive(double km)
            => FuelQuantity - (km * FuelConsumption) >= 0;

        public void Drive(double km)
        {
            this.FuelQuantity -= FuelConsumption * km;
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (FuelQuantity + liters > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters;
        }
    }
}
