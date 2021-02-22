using The_Simple_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Simple_Game.Data
{
    public class DataServiceSeed : IDataService
    {
        public List<Player> ReadAll()
        {
            return new List<Player>()
            {
                new Player()
                {
                    Name = "Kyle",
                    Wins = 0,
                    Losses = 0,
                    Ties = 0
                },

                new Player()
                {
                    Name = "CJ",
                    Wins = 0,
                    Losses = 0,
                    Ties = 0
                }
            };
        }

        public void WriteAll(List<Player> players)
        {

        }
    }
}

