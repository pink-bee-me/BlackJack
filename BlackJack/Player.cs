using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public class Player
    {

        public Player(playerName, bank)
        {
            this.Name = playerName;
            this.Balance = bank;



        }
        public List<Card> Hand { get; set; }
        public int Balance { get; set; }
        public string Name { get; set; }
        public bool IsActivelyPlaying { get; set; }

        public static Game operator+ (Game game, Player player)
            {
            game.Players.Add(player);
            return game;
            }
        public static Game operator- (Game game, Player player)
    {
        game.Players.Remove(player);
            return game;
    }
    }


}

