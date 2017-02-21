using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            GameInput gameIn = new GameInput();
            GameDisplay gameView = new GameDisplay();
            Board board = new Board();
            GameFlow game = new GameFlow(gameIn, gameView, board);
            game.Start();
        }
    }
}
