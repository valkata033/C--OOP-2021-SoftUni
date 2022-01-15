using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    interface ICommando : ISpecialisedSoldier
    {
        public List<IMissions> Missions { get; set; }

        void CompleteMission(string codeName);
    }
}
