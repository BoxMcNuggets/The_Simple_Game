using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Simple_Game.Models;
using The_Simple_Game.Business;

namespace The_Simple_Game.Presentation
{
    public class GameViewModel : ObservableObject
    {
        private GameBusiness _gameBusiness;
        private Gameboard _gameboard;
        private (Player playerOne, Player playerTwo) _currentPlayers;
        private Player _player1;
        private Player _player2;
        private string _messageBoxContent;
        private string _done;

        public Gameboard Gameboard
        {
            get { return _gameboard; }
            set
            {
                _gameboard = value;
                OnPropertyChanged(nameof(Gameboard));
            }
        }
        public Player PlayerX
        {
            get { return _player1; }
            set
            {
                _player1 = value;
                OnPropertyChanged(nameof(PlayerX));
            }
        }
        public Player PlayerO
        {
            get { return _player2; }
            set
            {
                _player2 = value;
                OnPropertyChanged(nameof(PlayerO));
            }
        }
        public string Done
        {
            get { return _done; }
            set
            {
                _done = value;
                OnPropertyChanged(nameof(Done));
            }
        }
        public string MessageBoxContent
        {
            get { return _messageBoxContent; }
            set
            {
                _messageBoxContent = value;
                OnPropertyChanged(nameof(MessageBoxContent));
            }
        }
        public GameViewModel()
        {
            _gameBusiness = new GameBusiness();

            InitializeGame();
        }
        private void InitializeGame()
        {
            _currentPlayers = _gameBusiness.GetCurrentPlayers();

            _player1 = _currentPlayers.playerOne;
            _player2 = _currentPlayers.playerTwo;

            _gameboard = new Gameboard();

            _gameboard.CurrentRoundState = Gameboard.GameboardState.Player1Turn;
            MessageBoxContent = "Player ▇ Moves";
        }
        public void PlayerMove(int row, int column)
        {
            if (_gameboard.GameboardPositionAvailable(new GameboardPosition(row, column)))
            {
                if (_gameboard.CurrentRoundState == Gameboard.GameboardState.Player1Turn)
                {
                    Gameboard.CurrentBoard[row][column] = Gameboard.PLAYER_PIECE_1;
                    OnPropertyChanged(nameof(Gameboard));
                    _gameboard.CurrentRoundState = Gameboard.GameboardState.Player2Turn;
                    MessageBoxContent = "Player ⬤ Moves";
                }
                else
                {
                    Gameboard.CurrentBoard[row][column] = Gameboard.PLAYER_PIECE_2;
                    OnPropertyChanged(nameof(Gameboard));
                    _gameboard.CurrentRoundState = Gameboard.GameboardState.Player1Turn;
                    MessageBoxContent = "Player ▇ Moves";
                }
                UpdateCurrentRoundState();
            }
        }
        internal void GameCommand(string commandName)
        {
            switch (commandName)
            {
                case "NewGame":
                    _gameboard.InitializeGameboard();
                    OnPropertyChanged(nameof(Gameboard));

                    _gameboard.CurrentRoundState = Gameboard.GameboardState.Player1Turn;
                    break;

                case "ResetGame":
                    _gameboard.InitializeGameboard();
                    OnPropertyChanged(nameof(Gameboard));

                    _gameboard.CurrentRoundState = Gameboard.GameboardState.Player1Turn;
                    break;

                case "QuitSave":
                    _gameBusiness.SaveAllPlayers();
                    break;

                case "Quit":
                    
                    break;

                default:
                    
                    break;
            }
        }
        public async void TheEnclosingMethod()
        {
            await Task.Delay(5000);
        }
        public void UpdateCurrentRoundState()
        {
            _gameboard.UpdateGameboardState();
            if (_gameboard.CurrentRoundState == Gameboard.GameboardState.NoWin)
            {
                PlayerO.Ties++;
                PlayerX.Ties++;
                MessageBoxContent = "No Winner";
                TheEnclosingMethod();
                _gameboard = new Gameboard();
                
            }
            else if (_gameboard.CurrentRoundState == Gameboard.GameboardState.Player1Win)
            {
                PlayerX.Wins++;
                PlayerO.Losses++;
                MessageBoxContent = "Player ▇ Wins!";
                TheEnclosingMethod();
                _gameboard = new Gameboard();
            }
            else if (_gameboard.CurrentRoundState == Gameboard.GameboardState.Player2Win)
            {
                PlayerO.Wins++;
                PlayerX.Losses++;
                MessageBoxContent = "Player ⬤ Wins!";
                TheEnclosingMethod();
                _gameboard = new Gameboard();
            }
        }
    }
}
