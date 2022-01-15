using MilitaryElite.Implementation;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<int, ISoldier> soldiers = new Dictionary<int, ISoldier>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandInfo = command.Split();
                string action = commandInfo[0];
                int id = int.Parse(commandInfo[1]);
                string firstName = commandInfo[2];
                string lastName = commandInfo[3];

                if (action == "Private")
                {
                    decimal salary = decimal.Parse(commandInfo[4]);

                    IPrivate @private = new Private(id, firstName, lastName, salary);

                    soldiers.Add(id, @private);
                }
                else if (action == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(commandInfo[4]);

                    ILieutenantGeneral lieutenantGeneral = 
                        new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < commandInfo.Length; i++)
                    {
                        int inputId = int.Parse(commandInfo[i]);

                        IPrivate @private = soldiers[inputId] as IPrivate;

                        lieutenantGeneral.Privates.Add(@private);
                    }
                    soldiers.Add(id, lieutenantGeneral);
                }
                else if (action  == "Engineer")
                {
                    decimal salary = decimal.Parse(commandInfo[4]);
                    string corpsAsString = commandInfo[5];

                    bool isValidEnum = 
                        Enum.TryParse(corpsAsString, out Corps result);

                    if (!isValidEnum)
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    IEngineer engineer = 
                        new Engineer(id, firstName, lastName, salary, result);

                    for (int i = 6; i < commandInfo.Length; i += 2)
                    {
                        string partName = commandInfo[i];
                        int hours = int.Parse(commandInfo[i + 1]);

                        IRepair repair = new Repair(partName, hours);

                        engineer.Repairs.Add(repair);
                    }

                    soldiers.Add(id, engineer);
                }
                else if (action == "Commando")
                {
                    decimal salary = decimal.Parse(commandInfo[4]);
                    string corpsAsString = commandInfo[5];

                    bool isValidEnum =
                        Enum.TryParse(corpsAsString, out Corps result);

                    if (!isValidEnum)
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    ICommando commando = 
                        new Commando(id, firstName, lastName, salary, result);

                    for (int i = 6; i < commandInfo.Length; i += 2)
                    {
                        string missionCode = commandInfo[i];
                        string missionStateAsString = commandInfo[i + 1];

                        bool isValidMission =
                            Enum.TryParse(missionStateAsString, out State state);

                        if (!isValidEnum)
                        {
                            continue;
                        }

                        IMissions mission = new Mission(missionCode, state);

                        commando.Missions.Add(mission);
                    }

                    soldiers.Add(id, commando);
                }
                else if (action == "Spy")
                {
                    int codeNumber = int.Parse(commandInfo[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiers.Add(id, spy);
                }

                command = Console.ReadLine();
            }

            foreach (var item in soldiers)
            {
                Console.WriteLine(item.Value.ToString());
            }

        }
    }
}
