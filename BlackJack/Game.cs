using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
   public abstract class Game // all other games inherit properties from the game class but we will never make an instance of the game class
    {
        public List<Player> Players { get; set; }
        public string Name { get; set; }
       



        public abstract void Play(); //abstract method: states that any class inheriting this class(game) MUST implement this method(Play())

        public virtual void ListPlayers() // virtual methods in abstract class: means that this method gets inherited but can be overriden to alter the workings of the method or the implementation or makes it customizable.
        {
            foreach (Player player in Players)
            {
                Console.WriteLine(player.Name);
            }
        }
    }
}
