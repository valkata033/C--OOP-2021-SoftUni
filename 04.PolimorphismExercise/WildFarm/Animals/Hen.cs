﻿using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override void Eat(Food food)
        {
            double gainWeight = food.Quantity * 0.35;
            Weight += gainWeight;
            FoodEaten += food.Quantity;
        }
    }
}
