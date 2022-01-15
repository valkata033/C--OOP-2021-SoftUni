using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface IMissions
    {
        public string CodeName { get; set; }

        public State State { get; set; }

    }
}
