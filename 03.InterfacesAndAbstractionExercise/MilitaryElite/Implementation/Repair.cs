using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Implementation
{
    public class Repair : IRepair
    {
        public Repair(string name, int workedHours)
        {
            Name = name;
            WorkedHours = workedHours;
        }

        public string Name { get; set; }

        public int WorkedHours { get; set; }

        public override string ToString()
        {
            return $"Part Name: {Name} Hours Worked: {WorkedHours}";
        }
    }
}
