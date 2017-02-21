using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (getV.Length > 2) break;
                Console.WriteLine("Please enter at least a 2 character name...Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            } while (true);
            return getV;
        }
    }
}
