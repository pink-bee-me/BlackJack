using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TwentyOne

{
    class Program
    {
        static void Main(string[] args)
        {

          

            Console.WriteLine("Welcome to the Grand Hotel and Casino. Let's start by telling me your name.");
            string playerName = Console.ReadLine();
            Console.WriteLine("And how much money did you bring today?");
            int bank = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hello, {0}. Would you like to join a game of 21 right now?", playerName); // {0} is a placeholder for playerName (which will be insewrted into the Console.WriteLine() content at the marked spot)
            string answer = Console.ReadLine().ToLower(); //use ToLower() as a means to eliminate the need for consideration of varying case input from user
            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "ya")
            {
                  // creating a new player object with name and bank for the property info
                Game game = new TwentyOneGame();
                game.Players = new List<Player>();
                Player player = new Player(playerName, bank);
                // create a new game
                game += player; // using operation overloader to add a player to the game
                player.isActivelyPlaying = true; // to know what the game should be doing while the player is active
                while (player.isActivelyPlaying && player.Balance > 0)
                {
                    game.Play();
                }
                game -= player; // if player is not actively playing or they don't have any money to play, then remove the player from the game
                                // this is done by using the operation overloader to remove  the player from the gane ( -= )
                Console.WriteLine("Thank you for playing!");
            }
            Console.WriteLine("Feel free to look around the casino. Bye for now.");
            Console.Read();
        }
    }
}

