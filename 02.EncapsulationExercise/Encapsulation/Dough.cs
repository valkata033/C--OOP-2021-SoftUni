using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        Dictionary<string, double> flourTypeCalories = 
            new Dictionary<string, double>
        {
            { "white", 1.5 },
            { "wholegrain", 1 }
        };

        Dictionary<string, double> bakingTechniqueCalories = 
            new Dictionary<string, double>
        {
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1 }
        };

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get 
            { 
                return flourType; 
            }

            private set 
            {
                if (!flourTypeCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value; 
            }
        }

        public string BakingTechnique
        {
            get 
            {
                return bakingTechnique; 
            }

            private set 
            {
                if (!bakingTechniqueCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value; 
            }
        }

        public double Weight
        {
            get 
            {
                return weight; 
            }

            private set 
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                weight = value; 
            }
        }

        public double Calories => 2 * Weight * flourTypeCalories[FlourType.ToLower()] *
            bakingTechniqueCalories[BakingTechnique.ToLower()];
                

    }
}
