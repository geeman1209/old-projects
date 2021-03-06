﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using BattleShip.BLL.Requests;

namespace BattleShip.UI
{
    public class GameInput
    {
        public string getPlayerNames(string playerPrompt)
        {
            String getV;
            do
            {
                Console.WriteLine("{0} - Please enter your name: ", playerPrompt);
                getV = Console.ReadLine();
                if (getV.Length > 2)
                {
                    break;
                }
                Console.WriteLine("Please enter at least a 2 character name...Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            } while (true);
            return getV;
        }

        public Coordinate GetSuperSecretCoordinates()
        {
            int x;
            int y;
            Console.WriteLine("Please enter your coordinates: x is 1-10, y is A-J...enter coordinates as follows A1, B1, etc.");
            string coord = Console.ReadLine();

            while (string.IsNullOrEmpty(coord))
            {
                    Console.WriteLine("Empty coordinates are not valid");
                    Console.WriteLine("Please enter your coordinates: x is 1-10, y is A-J...enter coordinates as follow A1, B1, etc.");
                    coord = Console.ReadLine();
            }

            string yCoord = coord.Substring(0, 1).ToLower();
            string xCoord = coord.Substring(1, coord.Length - 1);
            
            y = CoordConverter(yCoord);

            while (true)
            {
                if ((int.TryParse(xCoord, out x)))
                {
                    return new Coordinate(y, x);
                }
                else
                {
                    Console.WriteLine("Please enter valid coordinates");
                    break;                    
                }   
            }
            return GetSuperSecretCoordinates();
        }

        public int CoordConverter(string yCoord)
        {
            switch (yCoord)
            {
                case "a":
                    return 1;
                case "b":
                    return 2;
                case "c":
                    return 3;
                case "d":
                    return 4;
                case "e":
                    return 5;
                case "f":
                    return 6;
                case "g":
                    return 7;
                case "h":
                    return 8;
                case "i":
                    return 9;
                case "j":
                    return 10;
                default:
                    return 0;
            }
        }

        public ShipDirection GetShipDirection()
        {
            string value;
            while (true)
            {
                Console.WriteLine("Please enter a direction(up, down, left, right): ");
                value = Console.ReadLine();

                switch(value.ToLower())
                {
                    case "up":
                        return ShipDirection.Up;
                    case "down":
                        return ShipDirection.Down;
                    case "right":
                        return ShipDirection.Right;
                    case "left":
                        return ShipDirection.Left;
                    default:
                        Console.WriteLine("Not a valid direction");
                        break;
                }
            }
        }
    }
}
