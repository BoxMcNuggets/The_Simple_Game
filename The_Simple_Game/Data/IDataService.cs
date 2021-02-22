using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Simple_Game.Models;

namespace The_Simple_Game.Data
{
    public interface IDataService
    {
        List<Player> ReadAll();
        void WriteAll(List<Player> players);
    }
}
