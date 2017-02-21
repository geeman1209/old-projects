using BattleShip.BLL.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class GameFlow
    {
        private GameInput _gameIn;
        private GameDisplay _gameView;
        private Board _board;
        private bool _gameVictory;
        private string[] _playerNames = new string[2];

        public GameFlow(GameInput gameIn, GameDisplay gameView, Board board)
        {
            this._gameIn = gameIn;
            this._gameView = gameView;
            this._board = board;
        }

        public void Start()
        {
            displayStartScreen();

            getPlayerNames();

            while (!_gameVictory)
            {
                displayBoardSTate();
                promptForShipCoordinate();
                placeToken();
            }
        }
        private void displayStartScreen()
        {
            _gameView.DisplayWelcome();
        }

        private void getPlayerNames()
        {
            _playerNames[0] = _gameIn.getPlayerNames("Player 1");
            _playerNames[1] = _gameIn.getPlayerNames("Player 2");
        }

        private void placeToken()
        {
            throw new NotImplementedException();
        }

        private void promptForShipCoordinate()
        {
            throw new NotImplementedException();
        }

        private void displayBoardSTate()
        {
            throw new NotImplementedException();
        }



    }
}
