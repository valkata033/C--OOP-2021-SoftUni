using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IBirthable> iBirthable = new List<IBirthable>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputInfo = input.Split();
                string type = inputInfo[0];

                if (type == "Pet")
                {
                    string name = inputInfo[1];
                    string birthdate = inputInfo[2];

                    IBirthable pet = new Pet(name, birthdate);

                    iBirthable.Add(pet);
                }

                else if (type == "Citizen")
                {
                    string name = inputInfo[1];
                    int age = int.Parse(inputInfo[2]);
                    string id = inputInfo[3];
                    string birthdate = inputInfo[4];

                    IBirthable citizen = new Citizen(id, name, age, birthdate);

                    iBirthable.Add(citizen);
                }

                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            List<IBirthable> targets = iBirthable
                .Where(x => x.Birthdate.EndsWith(year)).ToList();

            foreach (var item in targets)
            {
                Console.WriteLine(item.Birthdate.TrimEnd());
            }

        }
    }
}
