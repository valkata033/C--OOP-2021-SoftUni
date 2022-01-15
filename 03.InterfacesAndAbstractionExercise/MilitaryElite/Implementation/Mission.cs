using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Implementation
{
    public class Mission : IMissions
    {
        public Mission(string codeName, State state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; set; }
        public State State { get; set; }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
