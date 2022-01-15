using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Foods;

namespace WildFarm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Animal> farm = new List<Animal>();
            Food food = null;

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] animalInfo = 
                    command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string[] foodInfo = 
                    Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string animalType = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                if (animalType == nameof(Cat) || animalType == nameof(Tiger))
                {
                    string habitat = animalInfo[3];
                    string breed = animalInfo[4];

                    if (animalType == nameof(Cat))
                    {
                        farm.Add(new Cat(name, weight, habitat, breed));
                    }

                    else
                    {
                        farm.Add(new Tiger(name, weight, habitat, breed));
                    }
                }

                else if (animalType == nameof(Mouse) || animalType == nameof(Dog))
                {
                    string habitat = animalInfo[3];

                    if (animalType == nameof(Mouse))
                    {
                        farm.Add(new Mouse(name, weight, habitat));
                    }

                    else
                    {
                        farm.Add(new Dog(name, weight, habitat));
                    }
                }

                else if (animalType == nameof(Owl) || animalType == nameof(Hen))
                {
                    double wingSize = double.Parse(animalInfo[3]);

                    if (animalType == nameof(Owl))
                    {
                        farm.Add(new Owl(name, weight, wingSize));
                    }
                    else
                    {
                        farm.Add(new Hen(name, weight, wingSize));
                    }
                }

                string foodType = foodInfo[0];
                int quantity = int.Parse(foodInfo[1]);

                if (foodType == "Fruit")
                {
                    food = new Fruit(quantity);
                }

                else if (foodType == "Meat")
                {
                    food = new Meat(quantity); 
                }

                else if (foodType == "Seeds")
                {
                    food = new Seeds(quantity);
                }

                else if (foodType == "Vegetable")
                {
                    food = new Vegetable(quantity);
                }

                try
                {
                    var currAnimal = farm.Find(x => x.Name == name);
                    Console.WriteLine(currAnimal.ProduceSound());
                    currAnimal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                command = Console.ReadLine();
            }

            farm.ForEach(Console.WriteLine);
        }
    }
}
