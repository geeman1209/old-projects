using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
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
        private bool _gameVictory = false;
        private Coordinate shotFired;
        private string[] _playerNames = new string[2];
        private bool _gameEnd = false;
        private bool _isTurn = true;

        private Board _player1board;
        private Board _player2board;
        private FireShotResponse response;

        public void Start()
        {
            _gameView = new GameDisplay();
            _gameView.DisplayWelcome();

            _gameIn = new GameInput();
            getPlayerNames();

            pickFirstTurn();

           _player1board = new Board();
           _player2board = new Board();

            _gameView.PrintBoard(_player1board, _playerNames[0]);
            PlaytheGame();
        }


        private void pickFirstTurn()
        {
            Random _turn = new Random();
            int x = _turn.Next(1, 3);
            if (x <= 2)
            {
                _isTurn = false;
            }

        }

        private void PlaytheGame()
        {
            while (!_gameEnd)
            {
                foreach(ShipType ship in Enum.GetValues(typeof(ShipType)))
                {
                    promptForShipCoordinate(_playerNames[0], _player1board, ship);
                    Console.Clear();
                }

                foreach(ShipType ship in Enum.GetValues(typeof(ShipType)))
                {
                    promptForShipCoordinate(_playerNames[1], _player2board, ship);
                    Console.Clear();
                }

                while (!_gameVictory)
                {
                    if (_isTurn)
                    {

                        _gameView.PrintBoard(_player2board, _playerNames[1]);
                        fireAtWill(_playerNames[0]);

                        FireShotResponse response = _player2board.FireShot(shotFired);

                        HitorNot(response);
                        _gameView.PrintBoard(_player2board, _playerNames[1]);
                        Console.ReadKey();
                        Console.Clear();
                    }

                    else
                    {
                        _gameView.PrintBoard(_player1board, _playerNames[0]);
                        fireAtWill(_playerNames[1]);

                        response = _player1board.FireShot(shotFired);

                        HitorNot(response);
                        _gameView.PrintBoard(_player1board, _playerNames[0]);
                        Console.ReadKey();
                        Console.Clear();
                    }
                }         
            }
        }

        private void HitorNot(FireShotResponse response)
        {
          
            while (true)
            {
                switch (response.ShotStatus)
                {
                    case ShotStatus.Duplicate:
                        Console.WriteLine("You've already picked this coordinate. Please choose a different one.");
                        return;
                    case ShotStatus.Invalid:
                        Console.WriteLine("Please choose another coordinate, this one is off the board.");
                        Console.ReadKey();
                        return;
                    case ShotStatus.Miss:
                        Console.WriteLine("You've missed!");
                        _isTurn = !_isTurn;
                        return;
                    case ShotStatus.Hit:
                        Console.WriteLine("You've hit something!");
                        _isTurn = !_isTurn;
                        return;
                    case ShotStatus.HitAndSunk:
                        Console.WriteLine("You've sunk their {0}", response.ShipImpacted);
                        _isTurn = !_isTurn;
                        return;
                    case ShotStatus.Victory:
                        Console.WriteLine("Hooray!!! You've sunk all of the opposing ships! You won!...Go get yourself something nice, you've earned it!");
                        Console.WriteLine("Would you like to play again?!? yes or no");
                        string answer = Console.ReadLine();
                        if (answer.ToLower() == "no")
                        {
                            _gameEnd = true;
                            _gameVictory = true;
                        }

                        return;
                    default:
                        Console.WriteLine("Please try again");
                        break;
                }
            }
        }

        private void getPlayerNames()
        {
            _playerNames[0] = _gameIn.getPlayerNames("Player 1");
            _playerNames[1] = _gameIn.getPlayerNames("Player 2");
        }

        private void promptForShipCoordinate(string _firstPlayer, Board board, ShipType type)
        {
            PlaceShipRequest placeRequest = new PlaceShipRequest();

            while(true)
            {
                Console.WriteLine($"{_firstPlayer}, enter coordinates to place your {type}");

                Coordinate coordinate = _gameIn.GetSuperSecretCoordinates();
                ShipDirection direction = _gameIn.GetShipDirection();

                placeRequest.Coordinate = coordinate;
                placeRequest.Direction = direction;
                placeRequest.ShipType = type;

                ShipPlacement validate = board.PlaceShip(placeRequest);

                switch (validate)
                {
                    case ShipPlacement.NotEnoughSpace:
                        Console.WriteLine("Sorry, it isn't valid due to the coordinate being off the board.");
                        break;
                    case ShipPlacement.Overlap:
                        Console.WriteLine("Two ships cannot share the same space...why?...Boundary issues");
                        break;
                    case ShipPlacement.Ok:
                        Console.WriteLine("Good! This space is available");
                        return;
                }
            } 
        }

        private void fireAtWill(string playerName)
        {
            Console.WriteLine($"{playerName}, take a shot!");
            shotFired = _gameIn.GetSuperSecretCoordinates();
        }
    }

 

}
