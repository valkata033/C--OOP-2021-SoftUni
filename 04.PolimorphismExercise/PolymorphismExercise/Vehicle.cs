using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelConsumption;
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity 
        { 
            get => fuelQuantity; 
            set => fuelQuantity = value; 
        }

        public virtual double FuelConsumption 
        { 
            get => fuelConsumption; 
            set => fuelConsumption = value; 
        }

        public bool CanDrive(double km)
            => FuelQuantity - (km * FuelConsumption) >= 0;

        public void Drive(double km)
        {
            this.FuelQuantity -= FuelConsumption * km;
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
