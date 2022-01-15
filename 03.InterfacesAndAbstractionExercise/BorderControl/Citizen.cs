using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : Iidentifiable, IBirthable
    {
        public Citizen(string id, string name, int age, string birthdate)
        {
            Id = id;
            Name = name;
            Age = age;
            Birthdate = birthdate;
        }

        public string Id { get; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Birthdate { get; }
    }
}
