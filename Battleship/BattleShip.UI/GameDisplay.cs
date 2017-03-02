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
            Console.WriteLine("  | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 ");
            Console.WriteLine("-------------------------------------------");

            char c = 'A';

            while (c <= 'J')
            {
                for (int numCol = 1; numCol <= 10; numCol++)
                {
                    Console.Write($"\n|{c++}");
                    for (int letterRow = 1; letterRow <= 10; letterRow++)
                    {
                        Coordinate shot = new Coordinate(letterRow, numCol);

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
        }
