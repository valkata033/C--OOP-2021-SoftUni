﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
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

        public int Rating
            =>players.Count == 0 
            ? 0
            : (int)Math.Round(players.Average(x => x.Stats));

        public void Addplayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(x => x.Name == playerName);

            if (player == null)
            {
                throw new InvalidOperationException($"Player {playerName} is not in {this.Name} team.");
            }

            players.Remove(player);
        }
    }
}
