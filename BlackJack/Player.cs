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

        public Player(string playerName, int bank)
        {
            Name = playerName;
            Balance = bank;
            Hand = new List<Card>();
        }

   
        public List<Card> Hand { get; set; }
        public int Balance { get; set; }
        public string Name { get; set; }
        public bool isActivelyPlaying { get; set; }
        public bool Stay { get; set; }

        public int[] Bets { get; set; }

        public bool Bet(int amount)
        {
            if (Balance - amount < 0) // logic: if amont player is betting is larger than his balance 
            {                         // then he can't bet that much!!! :) 
                Console.WriteLine("You don't have enough money in the bank to place a bet that size.");
                return false;
            }
            else
            {
                Balance -= amount; // else we will subtract the bet amount from the players balance giving us an updated player balance
                return true; // returns true, meaning " bet accepted"
            }
        }

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

