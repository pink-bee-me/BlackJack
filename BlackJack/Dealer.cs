using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
   public class Dealer
    {
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public int Balance { get; set; }

        public void Deal(List<Card> Hand)
        {
            Hand.Add(Deck.Cards.First()); // adding the card to the hand
            Console.WriteLine(Deck.Cards.First().ToString() + "\n"); // writing  to console what card was added to the hand and then adding a new line (a space kind of)
            Deck.Cards.RemoveAt(0);
        }

    }
}
