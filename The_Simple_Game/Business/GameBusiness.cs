using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Simple_Game.Presentation;
using The_Simple_Game.Models;
using The_Simple_Game.Data;

namespace The_Simple_Game.Business
{
    public class GameBusiness
    {
        public enum GameStatus
        {
            QUIT,
            QUIT_SAVE
        }

        List<Player> _allPlayers;

        Player _playerOne;
        Player _playerTwo;

        IDataService _dataService;

        public GameBusiness()
        {
            InitializeDataService();
            InitializeGame();
        }

        private void InitializeDataService()
        {
            _dataService = new DataServiceSeed();
        }

        private void InitializeGame()
        {

            _allPlayers = _dataService.ReadAll();

            _playerOne = _allPlayers.FirstOrDefault(p => p.Name == "Kyle");
            _playerTwo = _allPlayers.FirstOrDefault(p => p.Name == "CJ");
        }

        public List<Player> GetAllPlayers()
        {
            return _dataService.ReadAll();
        }

        public void SaveAllPlayers()
        {
            _dataService.WriteAll(_allPlayers);
        }

        public (Player playerOne, Player playerTwo) GetCurrentPlayers()
        {
            _playerOne = _allPlayers.FirstOrDefault(p => p.Name == "Kyle");
            _playerTwo = _allPlayers.FirstOrDefault(p => p.Name == "CJ");
            (Player playerOne, Player playerTwo) currentPlayers = (_playerOne, _playerTwo);

            return currentPlayers;
        }


    }
}
