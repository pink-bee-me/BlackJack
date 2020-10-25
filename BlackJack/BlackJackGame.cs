using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class BlackJackGame : Game
    {
        public override void Play() // have to use the override keyword because it is an inherited abstract method from the Game Class
        {
            throw new NotImplementedException();
        }

        public override void ListPlayers()
        {
            Console.WriteLine("BlackJack Players:");
            base.ListPlayers();
        }

    }
}
