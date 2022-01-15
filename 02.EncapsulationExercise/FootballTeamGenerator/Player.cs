using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get => name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value; 
            }
        }

        
        public int Endurance 
        { 
            get => endurance;
            private set
            {
                ValidateStat(nameof(Endurance), value);
                endurance = value;
            }
        }
        public int Sprint 
        { 
            get => sprint;
            private set
            {
                ValidateStat(nameof(Sprint), value);
                sprint = value;
            }
        }
        public int Dribble 
        { 
            get => dribble;
            private set
            {
                ValidateStat(nameof(Dribble), value);
                dribble = value;
            }
        }
        public int Passing 
        { 
            get => passing;
            private set
            {
                ValidateStat(nameof(Passing), value);
                passing = value;
            }
        }
        public int Shooting 
        { 
            get => shooting;
            private set
            {
                ValidateStat(nameof(Shooting), value);
                shooting = value;
            }
        }

        public double Stats => (Shooting + Passing + Dribble + Sprint + Endurance) / 5.0;

        private void ValidateStat(string name, int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{name} should be between 0 and 100.");
            }
        }

    }
}
