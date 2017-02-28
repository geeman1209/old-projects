using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class GameDisplay
    {
        public void DisplayWelcome()
        {
            Console.WriteLine("Welcome to Battleship!!");
        }

        public void PrintBoard(Board board, string playerName)
        {
            Console.WriteLine("  | A | B | C | D | E | F | G | H | I | J ");
            Console.WriteLine("------------------------------------------");
            for (int numRow = 1; numRow <= 10; numRow++)
            {
                Console.Write($"\n|{numRow}");
                for (int letterCol = 1; letterCol <= 10; letterCol++)
                {
                    Coordinate shot = new Coordinate(letterCol, numRow);

                    if (board.ShotHistory.ContainsKey(shot))
                    {
                        ShotHistory value = board.ShotHistory[shot];

                        switch (value)
                        {
                            case ShotHistory.Miss:
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("|");
                                Console.Write(" M ");
                                Console.ResetColor();
                                break;
                            case ShotHistory.Hit:
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("|");
                                Console.Write(" H ");
                                Console.ResetColor();
                                break;
                        }

                    }

                    else
                    {
                        Console.Write("|   ");
                    }
                }
            }

            Console.WriteLine();
        }
    }
                            
        }
